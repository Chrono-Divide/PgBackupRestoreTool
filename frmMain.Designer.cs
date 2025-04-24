namespace PgBackupRestoreTool
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up used resources.
        /// </summary>
        /// <param name="disposing">true if managed resources should be released; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            groupBoxConnection = new GroupBox();
            buttonTestConnection = new Button();
            labelPort = new Label();
            textBoxPort = new TextBox();
            radioRemote = new RadioButton();
            radioLocal = new RadioButton();
            labelHost = new Label();
            comboBoxHost = new ComboBox();
            groupBoxBackup = new GroupBox();
            labelBackupFile = new Label();
            textBoxBackupFile = new TextBox();
            buttonBrowseBackup = new Button();
            radioBackupCustom = new RadioButton();
            radioBackupPlain = new RadioButton();
            buttonBackup = new Button();
            groupBoxRestore = new GroupBox();
            labelRestoreFile = new Label();
            textBoxRestoreFile = new TextBox();
            buttonBrowseRestore = new Button();
            radioRestoreCustom = new RadioButton();
            radioRestorePlain = new RadioButton();
            buttonRestore = new Button();
            textBoxLog = new TextBox();
            progressBar1 = new ProgressBar();
            groupBoxConnection.SuspendLayout();
            groupBoxBackup.SuspendLayout();
            groupBoxRestore.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxConnection
            // 
            groupBoxConnection.Controls.Add(buttonTestConnection);
            groupBoxConnection.Controls.Add(labelPort);
            groupBoxConnection.Controls.Add(textBoxPort);
            groupBoxConnection.Controls.Add(radioRemote);
            groupBoxConnection.Controls.Add(radioLocal);
            groupBoxConnection.Controls.Add(labelHost);
            groupBoxConnection.Controls.Add(comboBoxHost);
            groupBoxConnection.Location = new Point(10, 10);
            groupBoxConnection.Name = "groupBoxConnection";
            groupBoxConnection.Size = new Size(580, 100);
            groupBoxConnection.TabIndex = 0;
            groupBoxConnection.TabStop = false;
            groupBoxConnection.Text = "Connection Settings";
            // 
            // buttonTestConnection
            // 
            buttonTestConnection.Location = new Point(450, 60);
            buttonTestConnection.Name = "buttonTestConnection";
            buttonTestConnection.Size = new Size(100, 30);
            buttonTestConnection.TabIndex = 6;
            buttonTestConnection.Text = "Test Connection";
            buttonTestConnection.UseVisualStyleBackColor = true;
            buttonTestConnection.Click += buttonTestConnection_Click;
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Location = new Point(408, 23);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(32, 15);
            labelPort.TabIndex = 4;
            labelPort.Text = "Port:";
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(450, 20);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(100, 23);
            textBoxPort.TabIndex = 5;
            // 
            // radioRemote
            // 
            radioRemote.AutoSize = true;
            radioRemote.Location = new Point(150, 60);
            radioRemote.Name = "radioRemote";
            radioRemote.Size = new Size(65, 19);
            radioRemote.TabIndex = 2;
            radioRemote.Text = "Remote";
            radioRemote.UseVisualStyleBackColor = true;
            radioRemote.CheckedChanged += radioRemote_CheckedChanged;
            // 
            // radioLocal
            // 
            radioLocal.AutoSize = true;
            radioLocal.Location = new Point(60, 60);
            radioLocal.Name = "radioLocal";
            radioLocal.Size = new Size(53, 19);
            radioLocal.TabIndex = 1;
            radioLocal.Text = "Local";
            radioLocal.UseVisualStyleBackColor = true;
            radioLocal.CheckedChanged += radioLocal_CheckedChanged;
            // 
            // labelHost
            // 
            labelHost.AutoSize = true;
            labelHost.Location = new Point(10, 22);
            labelHost.Name = "labelHost";
            labelHost.Size = new Size(35, 15);
            labelHost.TabIndex = 0;
            labelHost.Text = "Host:";
            // 
            // comboBoxHost
            // 
            comboBoxHost.Enabled = false;
            comboBoxHost.FormattingEnabled = true;
            comboBoxHost.Location = new Point(60, 20);
            comboBoxHost.Name = "comboBoxHost";
            comboBoxHost.Size = new Size(320, 23);
            comboBoxHost.TabIndex = 3;
            // 
            // groupBoxBackup
            // 
            groupBoxBackup.Controls.Add(labelBackupFile);
            groupBoxBackup.Controls.Add(textBoxBackupFile);
            groupBoxBackup.Controls.Add(buttonBrowseBackup);
            groupBoxBackup.Controls.Add(radioBackupCustom);
            groupBoxBackup.Controls.Add(radioBackupPlain);
            groupBoxBackup.Controls.Add(buttonBackup);
            groupBoxBackup.Location = new Point(10, 120);
            groupBoxBackup.Name = "groupBoxBackup";
            groupBoxBackup.Size = new Size(580, 120);
            groupBoxBackup.TabIndex = 1;
            groupBoxBackup.TabStop = false;
            groupBoxBackup.Text = "Backup";
            // 
            // labelBackupFile
            // 
            labelBackupFile.AutoSize = true;
            labelBackupFile.Location = new Point(10, 30);
            labelBackupFile.Name = "labelBackupFile";
            labelBackupFile.Size = new Size(68, 15);
            labelBackupFile.TabIndex = 0;
            labelBackupFile.Text = "Backup file:";
            // 
            // textBoxBackupFile
            // 
            textBoxBackupFile.Location = new Point(100, 30);
            textBoxBackupFile.Name = "textBoxBackupFile";
            textBoxBackupFile.Size = new Size(340, 23);
            textBoxBackupFile.TabIndex = 1;
            // 
            // buttonBrowseBackup
            // 
            buttonBrowseBackup.Location = new Point(450, 30);
            buttonBrowseBackup.Name = "buttonBrowseBackup";
            buttonBrowseBackup.Size = new Size(100, 27);
            buttonBrowseBackup.TabIndex = 2;
            buttonBrowseBackup.Text = "Browse...";
            buttonBrowseBackup.UseVisualStyleBackColor = true;
            buttonBrowseBackup.Click += ButtonBrowseBackup_Click;
            // 
            // radioBackupCustom
            // 
            radioBackupCustom.AutoSize = true;
            radioBackupCustom.Location = new Point(246, 71);
            radioBackupCustom.Name = "radioBackupCustom";
            radioBackupCustom.Size = new Size(134, 19);
            radioBackupCustom.TabIndex = 3;
            radioBackupCustom.Text = "Custom format (-F c)";
            radioBackupCustom.UseVisualStyleBackColor = true;
            // 
            // radioBackupPlain
            // 
            radioBackupPlain.AutoSize = true;
            radioBackupPlain.Checked = true;
            radioBackupPlain.Location = new Point(100, 71);
            radioBackupPlain.Name = "radioBackupPlain";
            radioBackupPlain.Size = new Size(104, 19);
            radioBackupPlain.TabIndex = 4;
            radioBackupPlain.TabStop = true;
            radioBackupPlain.Text = "Plain SQL (.sql)";
            radioBackupPlain.UseVisualStyleBackColor = true;
            // 
            // buttonBackup
            // 
            buttonBackup.Location = new Point(450, 65);
            buttonBackup.Name = "buttonBackup";
            buttonBackup.Size = new Size(100, 30);
            buttonBackup.TabIndex = 5;
            buttonBackup.Text = "Backup";
            buttonBackup.UseVisualStyleBackColor = true;
            buttonBackup.Click += ButtonBackup_Click;
            // 
            // groupBoxRestore
            // 
            groupBoxRestore.Controls.Add(labelRestoreFile);
            groupBoxRestore.Controls.Add(textBoxRestoreFile);
            groupBoxRestore.Controls.Add(buttonBrowseRestore);
            groupBoxRestore.Controls.Add(radioRestoreCustom);
            groupBoxRestore.Controls.Add(radioRestorePlain);
            groupBoxRestore.Controls.Add(buttonRestore);
            groupBoxRestore.Location = new Point(10, 250);
            groupBoxRestore.Name = "groupBoxRestore";
            groupBoxRestore.Size = new Size(580, 120);
            groupBoxRestore.TabIndex = 2;
            groupBoxRestore.TabStop = false;
            groupBoxRestore.Text = "Restore";
            // 
            // labelRestoreFile
            // 
            labelRestoreFile.AutoSize = true;
            labelRestoreFile.Location = new Point(10, 30);
            labelRestoreFile.Name = "labelRestoreFile";
            labelRestoreFile.Size = new Size(68, 15);
            labelRestoreFile.TabIndex = 0;
            labelRestoreFile.Text = "Backup file:";
            // 
            // textBoxRestoreFile
            // 
            textBoxRestoreFile.Location = new Point(100, 30);
            textBoxRestoreFile.Name = "textBoxRestoreFile";
            textBoxRestoreFile.Size = new Size(340, 23);
            textBoxRestoreFile.TabIndex = 1;
            // 
            // buttonBrowseRestore
            // 
            buttonBrowseRestore.Location = new Point(450, 30);
            buttonBrowseRestore.Name = "buttonBrowseRestore";
            buttonBrowseRestore.Size = new Size(100, 27);
            buttonBrowseRestore.TabIndex = 2;
            buttonBrowseRestore.Text = "Browse...";
            buttonBrowseRestore.UseVisualStyleBackColor = true;
            buttonBrowseRestore.Click += ButtonBrowseRestore_Click;
            // 
            // radioRestoreCustom
            // 
            radioRestoreCustom.AutoSize = true;
            radioRestoreCustom.Location = new Point(246, 70);
            radioRestoreCustom.Name = "radioRestoreCustom";
            radioRestoreCustom.Size = new Size(134, 19);
            radioRestoreCustom.TabIndex = 3;
            radioRestoreCustom.Text = "Custom format (-F c)";
            radioRestoreCustom.UseVisualStyleBackColor = true;
            // 
            // radioRestorePlain
            // 
            radioRestorePlain.AutoSize = true;
            radioRestorePlain.Checked = true;
            radioRestorePlain.Location = new Point(100, 70);
            radioRestorePlain.Name = "radioRestorePlain";
            radioRestorePlain.Size = new Size(104, 19);
            radioRestorePlain.TabIndex = 4;
            radioRestorePlain.TabStop = true;
            radioRestorePlain.Text = "Plain SQL (.sql)";
            radioRestorePlain.UseVisualStyleBackColor = true;
            // 
            // buttonRestore
            // 
            buttonRestore.Location = new Point(450, 70);
            buttonRestore.Name = "buttonRestore";
            buttonRestore.Size = new Size(100, 30);
            buttonRestore.TabIndex = 5;
            buttonRestore.Text = "Restore";
            buttonRestore.UseVisualStyleBackColor = true;
            buttonRestore.Click += ButtonRestore_Click;
            // 
            // textBoxLog
            // 
            textBoxLog.Location = new Point(12, 407);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.ReadOnly = true;
            textBoxLog.ScrollBars = ScrollBars.Vertical;
            textBoxLog.Size = new Size(580, 130);
            textBoxLog.TabIndex = 3;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 376);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(580, 25);
            progressBar1.TabIndex = 4;
            progressBar1.Visible = false;
            // 
            // frmMain
            // 
            ClientSize = new Size(600, 545);
            Controls.Add(progressBar1);
            Controls.Add(textBoxLog);
            Controls.Add(groupBoxRestore);
            Controls.Add(groupBoxBackup);
            Controls.Add(groupBoxConnection);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PostgreSQL Backup/Restore Tool";
            groupBoxConnection.ResumeLayout(false);
            groupBoxConnection.PerformLayout();
            groupBoxBackup.ResumeLayout(false);
            groupBoxBackup.PerformLayout();
            groupBoxRestore.ResumeLayout(false);
            groupBoxRestore.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.ComboBox comboBoxHost;
        private System.Windows.Forms.RadioButton radioLocal;
        private System.Windows.Forms.RadioButton radioRemote;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonTestConnection;

        private System.Windows.Forms.GroupBox groupBoxBackup;
        private System.Windows.Forms.Label labelBackupFile;
        private System.Windows.Forms.TextBox textBoxBackupFile;
        private System.Windows.Forms.Button buttonBrowseBackup;
        private System.Windows.Forms.RadioButton radioBackupCustom;
        private System.Windows.Forms.RadioButton radioBackupPlain;
        private System.Windows.Forms.Button buttonBackup;

        private System.Windows.Forms.GroupBox groupBoxRestore;
        private System.Windows.Forms.Label labelRestoreFile;
        private System.Windows.Forms.TextBox textBoxRestoreFile;
        private System.Windows.Forms.Button buttonBrowseRestore;
        private System.Windows.Forms.RadioButton radioRestoreCustom;
        private System.Windows.Forms.RadioButton radioRestorePlain;
        private System.Windows.Forms.Button buttonRestore;

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
