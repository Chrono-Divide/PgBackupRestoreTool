using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgBackupRestoreTool
{
    public partial class frmMain : Form
    {
        // -------------------------
        //  (1) 預設值
        // -------------------------
        private const string DEFAULT_USER = "admin";
        private const string DEFAULT_PASSWORD = "admin";
        private const string DEFAULT_DATABASE = "bks";

        // -------------------------
        //  (2) 實際使用
        // -------------------------
        private string PG_USER = DEFAULT_USER;
        private string PG_PASSWORD = DEFAULT_PASSWORD;
        private string PG_DATABASE = DEFAULT_DATABASE;

        // 已知的 IP 清單（從設定檔載入）
        private List<string> knownIPs = new List<string>();

        // PostgreSQL 預設 port
        private const string DEFAULT_PORT = "5432";

        // 用於記憶上次文件瀏覽位置
        private string lastDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // 設定檔路徑：exe 同級
        private string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.conf");

        public frmMain()
        {
            InitializeComponent();

            string fullVersion = Assembly.GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion ?? "unknown";
            // 只取 "+" 前的部分
            string displayVersion = fullVersion.Split('+')[0];
            this.Text = $"PostgreSQL Backup/Restore Tool v{displayVersion}";

            // 讀取外部檔 (若無則建空檔)
            LoadConfig();

            // 預設連線模式：Local
            radioLocal.Checked = true;
            textBoxPort.Text = DEFAULT_PORT;

            // 預設備份格式：Plain SQL (.sql)
            radioBackupPlain.Checked = true;
            // 預設還原格式：Plain SQL (.sql)
            radioRestorePlain.Checked = true;

            // Restore 按鈕無論選擇何種模式都保持可用
            buttonRestore.Enabled = true;
        }

        // -------------------------------------------------------
        //  UI控件啟用/禁用
        // -------------------------------------------------------
        private void ToggleControls(bool enable)
        {
            groupBoxConnection.Enabled = enable;
            groupBoxBackup.Enabled = enable;
            groupBoxRestore.Enabled = enable;
            // textBoxLog 保持只讀
        }

        // -------------------------------------------------------
        //  按鈕事件
        // -------------------------------------------------------
        private async void buttonTestConnection_Click(object sender, EventArgs e)
        {
            ToggleControls(false);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Visible = true;

            try
            {
                string host = GetHost();
                string port = textBoxPort.Text.Trim();
                // 使用 psql -l 列出所有 DB
                string arguments = $"-U {PG_USER} -h {host} -p {port} -l";

                bool success = await RunProcessAndCheckSuccess("psql", arguments);

                if (success)
                {
                    Log("Connection test SUCCESS.");

                    // 若成功且該 IP 未在清單中，就加進去並更新檔案
                    if (!knownIPs.Contains(host))
                    {
                        knownIPs.Add(host);
                        comboBoxHost.Items.Add(host);
                        SaveConfig();
                    }

                    // 載入可選 schema 列表
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

        private void ButtonBrowseBackup_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Choose backup file path to save";
                sfd.Filter = "Dump File (*.dump)|*.dump|SQL File (*.sql)|*.sql|All Files (*.*)|*.*";
                sfd.InitialDirectory = lastDirectory;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    textBoxBackupFile.Text = sfd.FileName;
                    lastDirectory = Path.GetDirectoryName(sfd.FileName);
                }
            }
        }

        private void ButtonBrowseRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a backup file to restore";
                ofd.Filter = "Dump File (*.dump)|*.dump|SQL File (*.sql)|*.sql|All Files (*.*)|*.*";
                ofd.InitialDirectory = lastDirectory;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBoxRestoreFile.Text = ofd.FileName;
                    lastDirectory = Path.GetDirectoryName(ofd.FileName);
                }
            }
        }

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

        // -------------------------------------------------------
        //  切換到 Local / Remote
        // -------------------------------------------------------
        private void radioLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLocal.Checked)
            {
                comboBoxHost.Text = "localhost";
                comboBoxHost.Enabled = false;
            }
        }

        private void radioRemote_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRemote.Checked)
            {
                comboBoxHost.Enabled = true;
                if (string.IsNullOrWhiteSpace(comboBoxHost.Text) || comboBoxHost.Text == "localhost")
                    comboBoxHost.Text = "";
            }
        }

        // -------------------------------------------------------
        //  取得 Host
        // -------------------------------------------------------
        private string GetHost()
        {
            return radioLocal.Checked
                ? "localhost"
                : comboBoxHost.Text.Trim();
        }

        // -------------------------------------------------------
        //  Backup
        // -------------------------------------------------------
        private async Task BackupAsync()
        {
            string filePath = textBoxBackupFile.Text;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Log("Please specify the backup file path.");
                return;
            }

            bool isCustom = radioBackupCustom.Checked;
            string host = GetHost();
            string port = textBoxPort.Text.Trim();

            // pg_dump -U <user> -h <host> -p <port> [-F c] [-c] [-C] -f "filePath" <db>
            string arguments = $"-U {PG_USER} -h {host} -p {port} ";
            if (isCustom)
            {
                // Custom binary format
                arguments += $"-F c -f \"{filePath}\" ";
                Log($"Starting backup (Custom format)...");
            }
            else
            {
                // Plain SQL + --clean + --create: 包含 DROP IF EXISTS 及 CREATE
                arguments += $"-c -C -f \"{filePath}\" ";
                Log($"Starting backup (Plain SQL with clean & create)...");
            }
            arguments += PG_DATABASE;

            Log($"Command: pg_dump {arguments}");
            await RunProcessAsync("pg_dump", arguments);
        }

        // -------------------------------------------------------
        //  Restore
        // -------------------------------------------------------
        private async Task RestoreAsync()
        {
            string filePath = textBoxRestoreFile.Text;
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                Log("Please select a valid backup file to restore.");
                return;
            }

            bool isCustom = radioRestoreCustom.Checked;
            string host = GetHost();
            string port = textBoxPort.Text.Trim();

            if (isCustom)
            {
                // pg_restore -U <user> -h <host> -p <port> -d <db> -c "filePath"
                string arguments = $"-U {PG_USER} -h {host} -p {port} -d {PG_DATABASE} -c \"{filePath}\"";
                Log("Starting restore using pg_restore (Custom format)...");
                Log($"Command: pg_restore {arguments}");
                await RunProcessAsync("pg_restore", arguments);
            }
            else
            {
                // Plain SQL restore，先選擇性清理 schema
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
        //  執行外部程式（以 UTF8 環境）
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

                    using (var process = new Process())
                    {
                        process.StartInfo = psi;
                        process.Start();

                        string output = process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();
                        process.WaitForExit();

                        if (!string.IsNullOrEmpty(output))
                            Log(output.Trim());
                        if (!string.IsNullOrEmpty(error))
                            Log(error.Trim());

                        Log($"{fileName} exited with code: {process.ExitCode}");
                    }
                }
                catch (Exception ex)
                {
                    Log($"Error occurred when running {fileName}: {ex.Message}");
                }
            });
        }

        /// <summary>
        /// 僅用於「Test Connection」，判斷 exit code == 0 即成功。
        /// </summary>
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

                    using (var process = new Process())
                    {
                        process.StartInfo = psi;
                        process.Start();

                        process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();
                        process.WaitForExit();

                        result = (process.ExitCode == 0);
                        if (!result && !string.IsNullOrEmpty(error))
                            Log($"[TestConnection Error]: {error.Trim()}");
                    }
                }
                catch (Exception ex)
                {
                    Log($"RunProcessAndCheckSuccess error: {ex.Message}");
                }
            });

            return result;
        }

        // -------------------------------------------------------
        //  載入可選 Schema 列表
        // -------------------------------------------------------
        private async Task LoadSchemasAsync()
        {
            try
            {
                comboBoxSchema.Items.Clear();
                string host = GetHost();
                string port = textBoxPort.Text.Trim();
                string sql = "SELECT schema_name FROM information_schema.schemata WHERE schema_name NOT IN ('pg_catalog','information_schema') ORDER BY schema_name;";
                string arguments = $"-U {PG_USER} -h {host} -p {port} -d {PG_DATABASE} -t -c \"{sql}\"";
                var output = await RunProcessAndCaptureOutput("psql", arguments);

                var schemas = output.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(s => s.Trim())
                                    .Where(s => s.Length > 0);

                foreach (var schema in schemas)
                    comboBoxSchema.Items.Add(schema);

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
            string result = string.Empty;

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

                    using (var process = new Process())
                    {
                        process.StartInfo = psi;
                        process.Start();
                        result = process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();
                        process.WaitForExit();
                        if (!string.IsNullOrEmpty(error))
                            Log(error.Trim());
                    }
                }
                catch (Exception ex)
                {
                    Log($"RunProcessAndCaptureOutput error: {ex.Message}");
                }
            });

            return result;
        }

        // -------------------------------------------------------
        //  日誌
        // -------------------------------------------------------
        private void Log(string message)
        {
            if (textBoxLog.InvokeRequired)
            {
                textBoxLog.Invoke(new Action(() =>
                {
                    textBoxLog.AppendText($"{DateTime.Now}: {message}{Environment.NewLine}");
                }));
            }
            else
            {
                textBoxLog.AppendText($"{DateTime.Now}: {message}{Environment.NewLine}");
            }
        }

        // -------------------------------------------------------
        //  讀寫設定檔
        // -------------------------------------------------------
        private void LoadConfig()
        {
            try
            {
                if (!File.Exists(configFilePath))
                {
                    File.WriteAllText(configFilePath, "");
                    return;
                }

                var lines = File.ReadAllLines(configFilePath);
                foreach (var rawLine in lines)
                {
                    string line = rawLine.Trim();
                    if (line.Length == 0 || line.StartsWith("#")) continue;

                    int idx = line.IndexOf('=');
                    if (idx < 0) continue;

                    string key = line.Substring(0, idx).Trim();
                    string value = line.Substring(idx + 1).Trim();

                    switch (key.ToUpper())
                    {
                        case "PG_USER":
                            PG_USER = value;
                            break;
                        case "PG_PASSWORD":
                            PG_PASSWORD = value;
                            break;
                        case "PG_DATABASE":
                            PG_DATABASE = value;
                            break;
                        case "KNOWN_IPS":
                            var ips = value.Split(';').Select(x => x.Trim()).Where(x => x.Length > 0).ToList();
                            knownIPs.AddRange(ips);
                            break;
                    }
                }

                foreach (var ip in knownIPs)
                    comboBoxHost.Items.Add(ip);
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
                string ipLine = knownIPs.Count > 0
                    ? "KNOWN_IPS=" + string.Join(";", knownIPs)
                    : "";

                var linesToWrite = new List<string>
                {
                    "# Config file for PgBackupRestoreTool",
                    $"PG_USER={PG_USER}",
                    $"PG_PASSWORD={PG_PASSWORD}",
                    $"PG_DATABASE={PG_DATABASE}",
                    ipLine
                }.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

                File.WriteAllLines(configFilePath, linesToWrite);
            }
            catch (Exception ex)
            {
                Log($"SaveConfig error: {ex.Message}");
            }
        }
    }
}
