using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgBackupRestoreTool
{
    public partial class frmMain : Form
    {
        public class DbConfig
        {
            public List<string> ConnectionStrings { get; set; } = new List<string>();
            public string LastUsedConnection { get; set; }
        }

        private const string DEFAULT_PORT = "5432";
        private string PG_USER;
        private string PG_PASSWORD;
        private string PG_DATABASE;

        private string lastDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbconfig.json");
        private DbConfig dbConfig;

        public frmMain()
        {
            InitializeComponent();

            // 版本號顯示
            string fullVersion = Assembly.GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion ?? "unknown";
            string displayVersion = fullVersion.Split('+')[0];
            this.Text = $"PostgreSQL Backup/Restore Tool v{displayVersion}";

            LoadConfig();

            // 預設選中最後用過的連接
            buttonRestore.Enabled = true;
        }

        // -------------------------------------------------------
        //  解析 comboBoxHost.Text 裡的連接字串
        // -------------------------------------------------------
        private void PrepareConnectionInfo(out string host, out string port)
        {
            string conn = comboBoxHost.Text.Trim();
            var dict = conn
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Split('=', 2))
                .Where(a => a.Length == 2)
                .ToDictionary(
                    a => a[0].Trim().ToLowerInvariant(),
                    a => a[1].Trim()
                );

            host = dict.ContainsKey("host") ? dict["host"] : "localhost";
            port = dict.ContainsKey("port") ? dict["port"] : DEFAULT_PORT;
            PG_USER = dict.ContainsKey("username") ? dict["username"] : "";
            PG_PASSWORD = dict.ContainsKey("password") ? dict["password"] : "";
            PG_DATABASE = dict.ContainsKey("database") ? dict["database"] : "";
        }

        // -------------------------------------------------------
        //  Test Connection
        // -------------------------------------------------------
        private async void buttonTestConnection_Click(object sender, EventArgs e)
        {
            ToggleControls(false);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Visible = true;

            try
            {
                PrepareConnectionInfo(out string host, out string port);
                string arguments = $"-U {PG_USER} -h {host} -p {port} -l";
                bool success = await RunProcessAndCheckSuccess("psql", arguments);

                if (success)
                {
                    Log("Connection test SUCCESS.");
                    SaveConfig();
                    await LoadSchemasAsync();
                }
                else
                {
                    Log("Connection test FAILED.");
                }
            }
            finally
            {
                progressBar1.Visible = false;
                ToggleControls(true);
            }
        }

        // -------------------------------------------------------
        //  檔案路徑選擇
        // -------------------------------------------------------
        private void ButtonBrowseBackup_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Title = "Choose backup file path to save",
                Filter = "Dump File (*.dump)|*.dump|SQL File (*.sql)|*.sql|All Files (*.*)|*.*",
                InitialDirectory = lastDirectory
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                textBoxBackupFile.Text = sfd.FileName;
                lastDirectory = Path.GetDirectoryName(sfd.FileName);
            }
        }

        private void ButtonBrowseRestore_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Select a backup file to restore",
                Filter = "Dump File (*.dump)|*.dump|SQL File (*.sql)|*.sql|All Files (*.*)|*.*",
                InitialDirectory = lastDirectory
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxRestoreFile.Text = ofd.FileName;
                lastDirectory = Path.GetDirectoryName(ofd.FileName);
            }
        }

        // -------------------------------------------------------
        //  Backup
        // -------------------------------------------------------
        private async void ButtonBackup_Click(object sender, EventArgs e)
        {
            ToggleControls(false);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Visible = true;

            try
            {
                await BackupAsync();
            }
            finally
            {
                progressBar1.Visible = false;
                ToggleControls(true);
            }
        }

        private async Task BackupAsync()
        {
            string filePath = textBoxBackupFile.Text;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Log("Please specify the backup file path.");
                return;
            }

            PrepareConnectionInfo(out string host, out string port);
            bool isCustom = radioBackupCustom.Checked;

            // pg_dump -U <user> -h <host> -p <port> [-F c] [-c] [-C] -f "filePath" <db>
            string arguments = $"-U {PG_USER} -h {host} -p {port} ";
            if (isCustom)
            {
                arguments += $"-F c -f \"{filePath}\" ";
                Log("Starting backup (Custom format)...");
            }
            else
            {
                arguments += $"-c -C -f \"{filePath}\" ";
                Log("Starting backup (Plain SQL with clean & create)...");
            }
            arguments += PG_DATABASE;

            Log($"Command: pg_dump {arguments}");
            await RunProcessAsync("pg_dump", arguments);
        }

        // -------------------------------------------------------
        //  Restore
        // -------------------------------------------------------
        private async void ButtonRestore_Click(object sender, EventArgs e)
        {
            ToggleControls(false);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Visible = true;

            try
            {
                await RestoreAsync();
            }
            finally
            {
                progressBar1.Visible = false;
                ToggleControls(true);
            }
        }

        private async Task RestoreAsync()
        {
            string filePath = textBoxRestoreFile.Text;
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                Log("Please select a valid backup file to restore.");
                return;
            }

            PrepareConnectionInfo(out string host, out string port);
            bool isCustom = radioRestoreCustom.Checked;

            if (isCustom)
            {
                string arguments = $"-U {PG_USER} -h {host} -p {port} -d {PG_DATABASE} -c \"{filePath}\"";
                Log("Starting restore using pg_restore (Custom format)...");
                Log($"Command: pg_restore {arguments}");
                await RunProcessAsync("pg_restore", arguments);
            }
            else
            {
                if (checkBoxClean.Checked && comboBoxSchema.SelectedItem != null)
                {
                    string schema = comboBoxSchema.SelectedItem.ToString();
                    Log($"Dropping and recreating schema '{schema}'...");
                    string dropSql = $"DROP SCHEMA IF EXISTS \"{schema}\" CASCADE; CREATE SCHEMA \"{schema}\";";
                    string dropArgs = $"-U {PG_USER} -h {host} -p {port} -d {PG_DATABASE} -c \"{dropSql}\"";
                    await RunProcessAsync("psql", dropArgs);
                }

                string arguments = $"-U {PG_USER} -h {host} -p {port} -d {PG_DATABASE} -f \"{filePath}\"";
                Log("Starting restore using psql (Plain SQL)...");
                Log($"Command: psql {arguments}");
                await RunProcessAsync("psql", arguments);
            }
        }

        // -------------------------------------------------------
        //  外部程式執行
        // -------------------------------------------------------
        private async Task RunProcessAsync(string fileName, string arguments)
        {
            await Task.Run(() =>
            {
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    psi.Environment["PGPASSWORD"] = PG_PASSWORD;
                    psi.Environment["PGCLIENTENCODING"] = "UTF8";

                    using var process = new Process { StartInfo = psi };
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(output)) Log(output.Trim());
                    if (!string.IsNullOrEmpty(error)) Log(error.Trim());
                    Log($"{fileName} exited with code: {process.ExitCode}");
                }
                catch (Exception ex)
                {
                    Log($"Error running {fileName}: {ex.Message}");
                }
            });
        }

        private async Task<bool> RunProcessAndCheckSuccess(string fileName, string arguments)
        {
            bool result = false;

            await Task.Run(() =>
            {
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    psi.Environment["PGPASSWORD"] = PG_PASSWORD;
                    psi.Environment["PGCLIENTENCODING"] = "UTF8";

                    using var process = new Process { StartInfo = psi };
                    process.Start();
                    process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    result = process.ExitCode == 0;
                    if (!result && !string.IsNullOrEmpty(error))
                        Log($"[TestConnection Error]: {error.Trim()}");
                }
                catch (Exception ex)
                {
                    Log($"RunProcessAndCheckSuccess error: {ex.Message}");
                }
            });

            return result;
        }

        // -------------------------------------------------------
        //  加载 schema 列表
        // -------------------------------------------------------
        private async Task LoadSchemasAsync()
        {
            try
            {
                comboBoxSchema.Items.Clear();
                PrepareConnectionInfo(out string host, out string port);

                string sql = "SELECT schema_name FROM information_schema.schemata " +
                             "WHERE schema_name NOT IN ('pg_catalog','information_schema') " +
                             "ORDER BY schema_name;";
                string arguments = $"-U {PG_USER} -h {host} -p {port} -d {PG_DATABASE} -t -c \"{sql}\"";
                var output = await RunProcessAndCaptureOutput("psql", arguments);

                var schemas = output
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .Where(s => s.Length > 0);

                foreach (var s in schemas)
                    comboBoxSchema.Items.Add(s);

                if (comboBoxSchema.Items.Count > 0)
                    comboBoxSchema.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Log($"LoadSchemasAsync error: {ex.Message}");
            }
        }

        private async Task<string> RunProcessAndCaptureOutput(string fileName, string arguments)
        {
            string result = "";

            await Task.Run(() =>
            {
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    psi.Environment["PGPASSWORD"] = PG_PASSWORD;
                    psi.Environment["PGCLIENTENCODING"] = "UTF8";

                    using var process = new Process { StartInfo = psi };
                    process.Start();
                    result = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    if (!string.IsNullOrEmpty(error))
                        Log(error.Trim());
                }
                catch (Exception ex)
                {
                    Log($"RunProcessAndCaptureOutput error: {ex.Message}");
                }
            });

            return result;
        }

        // -------------------------------------------------------
        //  日志
        // -------------------------------------------------------
        private void Log(string message)
        {
            string line = $"{DateTime.Now}: {message}{Environment.NewLine}";
            if (textBoxLog.InvokeRequired)
            {
                textBoxLog.Invoke(new Action(() => textBoxLog.AppendText(line)));
            }
            else
            {
                textBoxLog.AppendText(line);
            }
        }

        // -------------------------------------------------------
        //  讀取/寫入 dbconfig.json
        // -------------------------------------------------------
        private void LoadConfig()
        {
            try
            {
                if (!File.Exists(configFilePath))
                {
                    // 初次啟動，寫入預設
                    string defaultConn = $"Host=localhost;Port={DEFAULT_PORT};Username=admin;Password=admin;Database=bks";
                    dbConfig = new DbConfig
                    {
                        ConnectionStrings = new List<string> { defaultConn },
                        LastUsedConnection = defaultConn
                    };
                    File.WriteAllText(configFilePath,
                        JsonSerializer.Serialize(dbConfig, new JsonSerializerOptions { WriteIndented = true }));
                }
                else
                {
                    string json = File.ReadAllText(configFilePath);
                    dbConfig = JsonSerializer.Deserialize<DbConfig>(json)
                               ?? throw new Exception("Invalid dbconfig.json");
                }

                comboBoxHost.Items.Clear();
                foreach (var cs in dbConfig.ConnectionStrings)
                    comboBoxHost.Items.Add(cs);

                comboBoxHost.SelectedItem = dbConfig.LastUsedConnection;
            }
            catch (Exception ex)
            {
                Log($"LoadConfig error: {ex.Message}");
            }
        }

        private void SaveConfig()
        {
            try
            {
                string current = comboBoxHost.Text.Trim();
                if (!dbConfig.ConnectionStrings.Contains(current))
                    dbConfig.ConnectionStrings.Add(current);

                dbConfig.LastUsedConnection = current;
                File.WriteAllText(configFilePath,
                    JsonSerializer.Serialize(dbConfig, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                Log($"SaveConfig error: {ex.Message}");
            }
        }

        // -------------------------------------------------------
        //  停用/啟用 控件
        // -------------------------------------------------------
        private void ToggleControls(bool enable)
        {
            groupBoxConnection.Enabled = enable;
            groupBoxBackup.Enabled = enable;
            groupBoxRestore.Enabled = enable;
        }
    }
}
