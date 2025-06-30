using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgBackupRestoreTool
{
    public partial class frmMain : Form
    {
        // ---------- inner class ----------
        public class DbConfig
        {
            public List<string> ConnectionStrings { get; set; } = new();
            public string LastUsedConnection { get; set; } = "";
        }

        // ---------- constants / fields ----------
        private const string DEFAULT_PORT = "5432";
        private string PG_USER = "";
        private string PG_PASSWORD = "";
        private string PG_DATABASE = "";
        private bool _connected;
        private Process? _runningProcess;

        private string lastDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private readonly string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbconfig.json");
        private DbConfig dbConfig = new();

        // ---------- ctor ----------
        public frmMain()
        {
            InitializeComponent();

            string version = Assembly.GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "unknown";
            Text = $"PostgreSQL Backup/Restore Tool v{version.Split('+')[0]}";

            LoadConfig();
            SetConnectedState(false);
        }

        // ---------- UI state ----------
        private void SetConnectedState(bool connected)
        {
            _connected = connected;
            groupBoxBackup.Enabled = connected;
            groupBoxRestore.Enabled = connected;

            if (!connected)
            {
                comboBoxSchema.Enabled = false;
                checkBoxClean.Enabled = false;
                checkBoxDrop.Enabled = false;
            }
        }

        private void ComboBoxSchema_SelectedIndexChanged(object? _, EventArgs __)
        {
            bool enable = comboBoxSchema.Enabled && comboBoxSchema.SelectedItem != null;
            checkBoxClean.Enabled = enable;
            checkBoxDrop.Enabled = enable;
        }

        private void EnableAbort(bool enable)
        {
            if (buttonAbort.InvokeRequired)
                buttonAbort.Invoke(new Action(() => buttonAbort.Enabled = enable));
            else
                buttonAbort.Enabled = enable;
        }

        // ---------- connection string ----------
        private void PrepareConnectionInfo(out string host, out string port)
        {
            string conn = comboBoxHost.Text.Trim();

            var dict = conn.Split(';', StringSplitOptions.RemoveEmptyEntries)
                           .Select(p => p.Split('=', 2))
                           .Where(a => a.Length == 2)
                           .ToDictionary(a => a[0].Trim().ToLowerInvariant(),
                                         a => a[1].Trim());

            host = dict.TryGetValue("host", out var h) ? h : "localhost";
            port = dict.TryGetValue("port", out var p) ? p : DEFAULT_PORT;
            PG_USER = dict.TryGetValue("username", out var u) ? u : "";
            PG_PASSWORD = dict.TryGetValue("password", out var pw) ? pw : "";
            PG_DATABASE = dict.TryGetValue("database", out var db) ? db : "";
        }

        // ---------- Connect ----------
        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            ToggleControls(false);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Visible = true;

            try
            {
                PrepareConnectionInfo(out string host, out string port);
                var args = new[] { "-U", PG_USER, "-h", host, "-p", port, "-l" };
                bool success = await RunProcessAndCheckSuccessAsync("psql", args, logStdOut: false);

                if (success)
                {
                    Log("Connection test SUCCESS.", Color.Green);
                    SaveConfig();
                    SetConnectedState(true);
                    await LoadSchemasAsync();
                }
                else
                {
                    Log("Connection test FAILED.", Color.Red);
                    SetConnectedState(false);
                }
            }
            finally
            {
                progressBar1.Visible = false;
                ToggleControls(true);
            }
        }

        // ---------- File dialogs ----------
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
                lastDirectory = Path.GetDirectoryName(sfd.FileName)!;
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
                lastDirectory = Path.GetDirectoryName(ofd.FileName)!;
            }
        }

        // ---------- Backup ----------
        private async void ButtonBackup_Click(object sender, EventArgs e)
        {
            ToggleControls(false);
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Visible = true;
            EnableAbort(true);

            try { await BackupAsync(); }
            finally
            {
                progressBar1.Visible = false;
                ToggleControls(true);
                EnableAbort(false);
            }
        }

        private async Task BackupAsync()
        {
            string filePath = textBoxBackupFile.Text;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Log("Please specify the backup file path.", Color.Orange);
                return;
            }

            PrepareConnectionInfo(out string host, out string port);
            bool isCustom = radioBackupCustom.Checked;

            List<string> args = new() { "-U", PG_USER, "-h", host, "-p", port };

            if (isCustom)
            {
                args.AddRange(new[] { "-F", "c", "-v", "-f", filePath });
                Log("Starting backup (Custom format, verbose)...", Color.Blue);
            }
            else
            {
                args.AddRange(new[] { "-c", "-C", "-v", "-f", filePath });
                Log("Starting backup (Plain SQL with clean & create, verbose)...", Color.Blue);
            }

            args.Add(PG_DATABASE);
            Log($"Command: pg_dump {string.Join(' ', args)}", Color.DimGray);

            await RunProcessStreamingAsync("pg_dump", args);
        }

        // ---------- Restore ----------
        private async void ButtonRestore_Click(object sender, EventArgs e)
        {
            ToggleControls(false);
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Visible = true;
            EnableAbort(true);

            try { await RestoreAsync(); }
            finally
            {
                progressBar1.Visible = false;
                ToggleControls(true);
                EnableAbort(false);
            }
        }

        private async Task RestoreAsync()
        {
            string filePath = textBoxRestoreFile.Text;
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                Log("Please select a valid backup file to restore.", Color.Orange);
                return;
            }

            PrepareConnectionInfo(out string host, out string port);
            bool isCustom = radioRestoreCustom.Checked;

            if (isCustom)   // ----- Custom (.dump) -----
            {
                int totalItems = await GetTocItemCountAsync(filePath);
                if (totalItems <= 0) totalItems = 1;

                Log($"Starting restore using pg_restore (Custom, verbose)... Total TOC items: {totalItems}", Color.Blue);
                var args = new[]
                {
                    "-U", PG_USER, "-h", host, "-p", port,
                    "--clean", "--create", "--verbose",
                    "--dbname", PG_DATABASE,
                    filePath
                };
                Log($"Command: pg_restore {string.Join(' ', args)}", Color.DimGray);
                await RunPgRestoreWithProgressAsync("pg_restore", args, totalItems);
            }
            else            // ----- Plain SQL (.sql) -----
            {
                bool doDrop = checkBoxDrop.Checked;
                bool doClean = checkBoxClean.Checked;

                if ((doDrop || doClean) && comboBoxSchema.SelectedItem != null)
                {
                    string schema = comboBoxSchema.SelectedItem.ToString()!;
                    if ((doDrop || doClean) && schema.Equals("public", StringComparison.OrdinalIgnoreCase))
                    {
                        if (MessageBox.Show(
                                "You are about to DROP the default 'public' schema.\nAll objects inside will be removed.\nContinue?",
                                "Confirm DROP public schema",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            Log("User cancelled dropping the 'public' schema. Restore aborted.", Color.Orange);
                            return;
                        }
                    }

                    string dropSql = doClean
                        ? $"DROP SCHEMA IF EXISTS \"{schema}\" CASCADE; CREATE SCHEMA \"{schema}\";"
                        : $"DROP SCHEMA IF EXISTS \"{schema}\" CASCADE;";

                    Log($"{(doClean ? "Dropping & recreating" : "Dropping")} schema '{schema}'...", Color.Blue);
                    var dropArgs = new[]
                    {
                        "-U", PG_USER, "-h", host, "-p", port,
                        "-d", PG_DATABASE, "-c", dropSql
                    };
                    await RunProcessStreamingAsync("psql", dropArgs);
                }

                Log("Starting restore using psql (Plain SQL, echo-all)...", Color.Blue);
                var args2 = new[]
                {
                    "-U", PG_USER, "-h", host, "-p", port,
                    "-d", PG_DATABASE, "--echo-all",
                    "-f", filePath
                };
                Log($"Command: psql {string.Join(' ', args2)}", Color.DimGray);
                await RunProcessStreamingAsync("psql", args2);
            }
        }

        // ---------- Abort ----------
        private void buttonAbort_Click(object sender, EventArgs e)
        {
            try
            {
                if (_runningProcess != null && !_runningProcess.HasExited)
                {
                    _runningProcess.Kill(true);
                    Log("[Aborted] User cancelled running process.", Color.OrangeRed);
                }
            }
            catch (Exception ex)
            {
                Log($"Abort error: {ex.Message}", Color.Red);
            }
        }

        // ---------- Streaming process ----------
        private async Task RunProcessStreamingAsync(string exe, IEnumerable<string> args)
        {
            await Task.Run(() =>
            {
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = exe,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    psi.Environment["PGPASSWORD"] = PG_PASSWORD;
                    psi.Environment["PGCLIENTENCODING"] = "UTF8";
                    foreach (var a in args) psi.ArgumentList.Add(a);

                    using var p = new Process { StartInfo = psi, EnableRaisingEvents = true };
                    _runningProcess = p;

                    p.OutputDataReceived += (_, e) =>
                    {
                        if (e.Data == null) return;
                        Log(e.Data);
                    };
                    p.ErrorDataReceived += (_, e) =>
                    {
                        if (e.Data == null) return;
                        Log(e.Data, Color.Red);
                    };

                    p.Start();
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                    p.WaitForExit();

                    Log($"{exe} exited with code: {p.ExitCode}", Color.DimGray);
                }
                catch (Exception ex)
                {
                    Log($"Error running {exe}: {ex.Message}", Color.Red);
                }
                finally
                {
                    _runningProcess = null;
                }
            });
        }

        // ---------- pg_restore progress ----------
        private async Task RunPgRestoreWithProgressAsync(string exe, IEnumerable<string> args, int total)
        {
            await Task.Run(() =>
            {
                var regex = new Regex(@"processing item (\d+)/(\d+)", RegexOptions.IgnoreCase);
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = exe,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    psi.Environment["PGPASSWORD"] = PG_PASSWORD;
                    psi.Environment["PGCLIENTENCODING"] = "UTF8";
                    foreach (var a in args) psi.ArgumentList.Add(a);

                    using var p = new Process { StartInfo = psi };
                    _runningProcess = p;

                    p.OutputDataReceived += (_, e) =>
                    {
                        if (e.Data == null) return;
                        Log(e.Data);

                        var m = regex.Match(e.Data);
                        if (m.Success && int.TryParse(m.Groups[1].Value, out int current))
                        {
                            int percent = (int)(current * 100.0 / total);
                            progressBar1.Invoke(new Action(() =>
                            {
                                progressBar1.Style = ProgressBarStyle.Continuous;
                                progressBar1.Value = Math.Min(percent, 100);
                            }));
                        }
                    };
                    p.ErrorDataReceived += (_, e) =>
                    {
                        if (e.Data == null) return;
                        Log(e.Data, Color.Red);
                    };

                    p.Start();
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                    p.WaitForExit();

                    Log($"{exe} exited with code: {p.ExitCode}", Color.DimGray);
                }
                catch (Exception ex)
                {
                    Log($"Error running {exe}: {ex.Message}", Color.Red);
                }
                finally
                {
                    progressBar1.Invoke(new Action(() => progressBar1.Value = 100));
                    _runningProcess = null;
                }
            });
        }

        private async Task<int> GetTocItemCountAsync(string dumpFile)
        {
            int count = 0;
            await Task.Run(() =>
            {
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = "pg_restore",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    psi.ArgumentList.Add("-l");
                    psi.ArgumentList.Add(dumpFile);

                    using var p = Process.Start(psi)!;
                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                    count = output.Split('\n').Count(l => !string.IsNullOrWhiteSpace(l));
                }
                catch (Exception ex)
                {
                    Log($"GetTocItemCountAsync error: {ex.Message}", Color.Red);
                }
            });
            return count;
        }

        // ---------- exit-code check ----------
        private async Task<bool> RunProcessAndCheckSuccessAsync(string exe, IEnumerable<string> args, bool logStdOut = true)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = exe,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                psi.Environment["PGPASSWORD"] = PG_PASSWORD;
                psi.Environment["PGCLIENTENCODING"] = "UTF8";

                psi.ArgumentList.Add("-w");
                foreach (var a in args) psi.ArgumentList.Add(a);

                using var p = Process.Start(psi)!;

                var stdTask = p.StandardOutput.ReadToEndAsync();
                var errTask = p.StandardError.ReadToEndAsync();
                await Task.WhenAll(stdTask, errTask, p.WaitForExitAsync());

                if (logStdOut && !string.IsNullOrWhiteSpace(stdTask.Result))
                    Log(stdTask.Result.Trim(), Color.Black);

                if (p.ExitCode != 0 && !string.IsNullOrWhiteSpace(errTask.Result))
                    Log(errTask.Result.Trim(), Color.Red);

                return p.ExitCode == 0;
            }
            catch (Exception ex)
            {
                Log($"RunProcessAndCheckSuccessAsync error: {ex.Message}", Color.Red);
                return false;
            }
        }

        // ---------- load schema list ----------
        private async Task LoadSchemasAsync()
        {
            try
            {
                comboBoxSchema.Items.Clear();
                PrepareConnectionInfo(out string host, out string port);

                string sql = "SELECT schema_name FROM information_schema.schemata " +
                             "WHERE schema_name NOT IN ('pg_catalog','information_schema') " +
                             "ORDER BY schema_name;";

                var args = new[]
                {
                    "-U", PG_USER, "-h", host, "-p", port,
                    "-d", PG_DATABASE, "-t", "-c", sql
                };
                string output = await RunProcessAndCaptureOutput("psql", args);

                var schemas = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(s => s.Trim()).Where(s => s.Length > 0);

                foreach (var s in schemas) comboBoxSchema.Items.Add(s);

                if (comboBoxSchema.Items.Count > 0)
                {
                    comboBoxSchema.SelectedIndex = 0;
                    comboBoxSchema.Enabled = true;
                    checkBoxClean.Enabled = true;
                    checkBoxDrop.Enabled = true;
                    Log("Schema list loaded.", Color.Green);
                }
                else
                {
                    comboBoxSchema.Enabled = false;
                    checkBoxClean.Enabled = false;
                    checkBoxDrop.Enabled = false;
                    Log("No schema found.", Color.Orange);
                }
            }
            catch (Exception ex)
            {
                Log($"LoadSchemasAsync error: {ex.Message}", Color.Red);
            }
        }

        private async Task<string> RunProcessAndCaptureOutput(string exe, IEnumerable<string> args)
        {
            string result = "";
            await Task.Run(() =>
            {
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = exe,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    psi.Environment["PGPASSWORD"] = PG_PASSWORD;
                    psi.Environment["PGCLIENTENCODING"] = "UTF8";
                    foreach (var a in args) psi.ArgumentList.Add(a);

                    using var p = Process.Start(psi)!;
                    result = p.StandardOutput.ReadToEnd();
                    string err = p.StandardError.ReadToEnd();
                    p.WaitForExit();

                    if (!string.IsNullOrEmpty(err))
                        Log(err.Trim(), Color.Red);
                }
                catch (Exception ex)
                {
                    Log($"RunProcessAndCaptureOutput error: {ex.Message}", Color.Red);
                }
            });
            return result;
        }

        // ---------- Log ----------
        private void Log(string message, Color? color = null)
        {
            string[] lines = message.Replace("\r", "").Split('\n');
            if (lines.Length == 0) return;

            for (int i = 0; i < lines.Length; i++)
            {
                string lineText = i == 0 ? lines[i] : "    " + lines[i];
                string line = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss}: {lineText}{Environment.NewLine}";

                void Append()
                {
                    richTextBoxLog.SelectionStart = richTextBoxLog.TextLength;
                    richTextBoxLog.SelectionLength = 0;
                    richTextBoxLog.SelectionColor = color ?? Color.Black;
                    richTextBoxLog.AppendText(line);
                    richTextBoxLog.SelectionColor = richTextBoxLog.ForeColor;
                }

                if (richTextBoxLog.InvokeRequired)
                    richTextBoxLog.Invoke(new Action(Append));
                else
                    Append();
            }
        }

        // ---------- Config ----------
        private void LoadConfig()
        {
            try
            {
                if (!File.Exists(configFilePath))
                {
                    string def = $"Host=localhost;Port={DEFAULT_PORT};Username=admin;Password=admin;Database=bks";
                    dbConfig = new DbConfig
                    {
                        ConnectionStrings = new List<string> { def },
                        LastUsedConnection = def
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
                foreach (var cs in dbConfig.ConnectionStrings) comboBoxHost.Items.Add(cs);
                comboBoxHost.SelectedItem = dbConfig.LastUsedConnection;
            }
            catch (Exception ex)
            {
                Log($"LoadConfig error: {ex.Message}", Color.Red);
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
                Log($"SaveConfig error: {ex.Message}", Color.Red);
            }
        }

        // ---------- Toggle ----------
        private void ToggleControls(bool enable)
        {
            groupBoxConnection.Enabled = enable;
            groupBoxBackup.Enabled = enable && _connected;
            groupBoxRestore.Enabled = enable && _connected;
        }

        // ---------- Kill Sessions ----------
        private async void ButtonKillSessions_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "This will forcibly terminate ALL other sessions on the database.\nContinue?",
                    "Terminate connections",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            ToggleControls(false);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Visible = true;

            try
            {
                PrepareConnectionInfo(out string host, out string port);
                string sql = @"
                    SELECT pg_terminate_backend(pid)
                    FROM pg_stat_activity
                    WHERE datname = current_database()
                      AND pid <> pg_backend_pid();";

                var args = new[] { "-U", PG_USER, "-h", host, "-p", port, "-d", PG_DATABASE, "-c", sql };
                Log("Terminating other sessions...", Color.Blue);
                await RunProcessStreamingAsync("psql", args);
            }
            finally
            {
                progressBar1.Visible = false;
                ToggleControls(true);
            }
        }

        private void CheckBoxMutualExclusive(object? sender, EventArgs e)
        {
            if (sender == checkBoxClean && checkBoxClean.Checked)
                checkBoxDrop.Checked = false;
            else if (sender == checkBoxDrop && checkBoxDrop.Checked)
                checkBoxClean.Checked = false;
        }

        private void textBoxRestoreFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBoxRestoreFile_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
                textBoxRestoreFile.Text = files[0];
        }
    }
}
