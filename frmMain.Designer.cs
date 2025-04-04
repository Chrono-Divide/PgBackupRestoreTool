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
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.radioRemote = new System.Windows.Forms.RadioButton();
            this.radioLocal = new System.Windows.Forms.RadioButton();
            this.labelHost = new System.Windows.Forms.Label();
            this.comboBoxHost = new System.Windows.Forms.ComboBox();

            this.groupBoxBackup = new System.Windows.Forms.GroupBox();
            this.labelBackupFile = new System.Windows.Forms.Label();
            this.textBoxBackupFile = new System.Windows.Forms.TextBox();
            this.buttonBrowseBackup = new System.Windows.Forms.Button();
            this.radioBackupCustom = new System.Windows.Forms.RadioButton();
            this.radioBackupPlain = new System.Windows.Forms.RadioButton();
            this.buttonBackup = new System.Windows.Forms.Button();

            this.groupBoxRestore = new System.Windows.Forms.GroupBox();
            this.labelRestoreFile = new System.Windows.Forms.Label();
            this.textBoxRestoreFile = new System.Windows.Forms.TextBox();
            this.buttonBrowseRestore = new System.Windows.Forms.Button();
            this.radioRestoreCustom = new System.Windows.Forms.RadioButton();
            this.radioRestorePlain = new System.Windows.Forms.RadioButton();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.buttonDeleteAndRestore = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();

            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();

            this.groupBoxConnection.SuspendLayout();
            this.groupBoxBackup.SuspendLayout();
            this.groupBoxRestore.SuspendLayout();
            this.SuspendLayout();

            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.buttonTestConnection);
            this.groupBoxConnection.Controls.Add(this.labelPort);
            this.groupBoxConnection.Controls.Add(this.textBoxPort);
            this.groupBoxConnection.Controls.Add(this.radioRemote);
            this.groupBoxConnection.Controls.Add(this.radioLocal);
            this.groupBoxConnection.Controls.Add(this.labelHost);
            this.groupBoxConnection.Controls.Add(this.comboBoxHost);
            this.groupBoxConnection.Location = new System.Drawing.Point(10, 10);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(580, 100);
            this.groupBoxConnection.TabIndex = 0;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection Settings";

            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Location = new System.Drawing.Point(450, 60);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(120, 30);
            this.buttonTestConnection.TabIndex = 6;
            this.buttonTestConnection.Text = "Test Connection";
            this.buttonTestConnection.UseVisualStyleBackColor = true;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);

            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(400, 22);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(38, 20);
            this.labelPort.TabIndex = 4;
            this.labelPort.Text = "Port:";

            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(440, 20);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(80, 27);
            this.textBoxPort.TabIndex = 5;

            // 
            // radioRemote
            // 
            this.radioRemote.AutoSize = true;
            this.radioRemote.Location = new System.Drawing.Point(150, 60);
            this.radioRemote.Name = "radioRemote";
            this.radioRemote.Size = new System.Drawing.Size(81, 24);
            this.radioRemote.TabIndex = 2;
            this.radioRemote.Text = "Remote";
            this.radioRemote.UseVisualStyleBackColor = true;
            this.radioRemote.CheckedChanged += new System.EventHandler(this.radioRemote_CheckedChanged);

            // 
            // radioLocal
            // 
            this.radioLocal.AutoSize = true;
            this.radioLocal.Location = new System.Drawing.Point(60, 60);
            this.radioLocal.Name = "radioLocal";
            this.radioLocal.Size = new System.Drawing.Size(66, 24);
            this.radioLocal.TabIndex = 1;
            this.radioLocal.Text = "Local";
            this.radioLocal.UseVisualStyleBackColor = true;
            this.radioLocal.CheckedChanged += new System.EventHandler(this.radioLocal_CheckedChanged);

            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(10, 22);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(43, 20);
            this.labelHost.TabIndex = 0;
            this.labelHost.Text = "Host:";

            // 
            // comboBoxHost
            // 
            this.comboBoxHost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.comboBoxHost.FormattingEnabled = true;
            this.comboBoxHost.Location = new System.Drawing.Point(60, 20);
            this.comboBoxHost.Name = "comboBoxHost";
            this.comboBoxHost.Size = new System.Drawing.Size(320, 28);
            this.comboBoxHost.TabIndex = 3;
            this.comboBoxHost.Enabled = false;

            // 
            // groupBoxBackup
            // 
            this.groupBoxBackup.Controls.Add(this.labelBackupFile);
            this.groupBoxBackup.Controls.Add(this.textBoxBackupFile);
            this.groupBoxBackup.Controls.Add(this.buttonBrowseBackup);
            this.groupBoxBackup.Controls.Add(this.radioBackupCustom);
            this.groupBoxBackup.Controls.Add(this.radioBackupPlain);
            this.groupBoxBackup.Controls.Add(this.buttonBackup);
            this.groupBoxBackup.Location = new System.Drawing.Point(10, 120);
            this.groupBoxBackup.Name = "groupBoxBackup";
            this.groupBoxBackup.Size = new System.Drawing.Size(580, 120);
            this.groupBoxBackup.TabIndex = 1;
            this.groupBoxBackup.TabStop = false;
            this.groupBoxBackup.Text = "Backup";

            // 
            // labelBackupFile
            // 
            this.labelBackupFile.AutoSize = true;
            this.labelBackupFile.Location = new System.Drawing.Point(10, 30);
            this.labelBackupFile.Name = "labelBackupFile";
            this.labelBackupFile.Size = new System.Drawing.Size(89, 20);
            this.labelBackupFile.TabIndex = 0;
            this.labelBackupFile.Text = "Backup file:";

            // 
            // textBoxBackupFile
            // 
            this.textBoxBackupFile.Location = new System.Drawing.Point(100, 30);
            this.textBoxBackupFile.Name = "textBoxBackupFile";
            this.textBoxBackupFile.Size = new System.Drawing.Size(340, 27);
            this.textBoxBackupFile.TabIndex = 1;

            // 
            // buttonBrowseBackup
            // 
            this.buttonBrowseBackup.Location = new System.Drawing.Point(450, 30);
            this.buttonBrowseBackup.Name = "buttonBrowseBackup";
            this.buttonBrowseBackup.Size = new System.Drawing.Size(100, 27);
            this.buttonBrowseBackup.TabIndex = 2;
            this.buttonBrowseBackup.Text = "Browse...";
            this.buttonBrowseBackup.UseVisualStyleBackColor = true;
            this.buttonBrowseBackup.Click += new System.EventHandler(this.ButtonBrowseBackup_Click);

            // 
            // radioBackupCustom
            // 
            this.radioBackupCustom.AutoSize = true;
            this.radioBackupCustom.Checked = true;
            this.radioBackupCustom.Location = new System.Drawing.Point(100, 65);
            this.radioBackupCustom.Name = "radioBackupCustom";
            this.radioBackupCustom.Size = new System.Drawing.Size(147, 24);
            this.radioBackupCustom.TabIndex = 3;
            this.radioBackupCustom.TabStop = true;
            this.radioBackupCustom.Text = "Custom format (-F c)";
            this.radioBackupCustom.UseVisualStyleBackColor = true;

            // 
            // radioBackupPlain
            // 
            this.radioBackupPlain.AutoSize = true;
            this.radioBackupPlain.Location = new System.Drawing.Point(270, 65);
            this.radioBackupPlain.Name = "radioBackupPlain";
            this.radioBackupPlain.Size = new System.Drawing.Size(116, 24);
            this.radioBackupPlain.TabIndex = 4;
            this.radioBackupPlain.TabStop = false;
            this.radioBackupPlain.Text = "Plain SQL (.sql)";
            this.radioBackupPlain.UseVisualStyleBackColor = true;

            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(450, 65);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(100, 30);
            this.buttonBackup.TabIndex = 5;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.ButtonBackup_Click);

            // 
            // groupBoxRestore
            // 
            this.groupBoxRestore.Controls.Add(this.labelRestoreFile);
            this.groupBoxRestore.Controls.Add(this.textBoxRestoreFile);
            this.groupBoxRestore.Controls.Add(this.buttonBrowseRestore);
            this.groupBoxRestore.Controls.Add(this.radioRestoreCustom);
            this.groupBoxRestore.Controls.Add(this.radioRestorePlain);
            this.groupBoxRestore.Controls.Add(this.buttonRestore);
            this.groupBoxRestore.Controls.Add(this.buttonDeleteAndRestore);
            this.groupBoxRestore.Controls.Add(this.buttonDelete);
            this.groupBoxRestore.Location = new System.Drawing.Point(10, 250);
            this.groupBoxRestore.Name = "groupBoxRestore";
            this.groupBoxRestore.Size = new System.Drawing.Size(580, 180);
            this.groupBoxRestore.TabIndex = 2;
            this.groupBoxRestore.TabStop = false;
            this.groupBoxRestore.Text = "Restore";

            // 
            // labelRestoreFile
            // 
            this.labelRestoreFile.AutoSize = true;
            this.labelRestoreFile.Location = new System.Drawing.Point(10, 30);
            this.labelRestoreFile.Name = "labelRestoreFile";
            this.labelRestoreFile.Size = new System.Drawing.Size(88, 20);
            this.labelRestoreFile.TabIndex = 0;
            this.labelRestoreFile.Text = "Backup file:";

            // 
            // textBoxRestoreFile
            // 
            this.textBoxRestoreFile.Location = new System.Drawing.Point(100, 30);
            this.textBoxRestoreFile.Name = "textBoxRestoreFile";
            this.textBoxRestoreFile.Size = new System.Drawing.Size(340, 27);
            this.textBoxRestoreFile.TabIndex = 1;

            // 
            // buttonBrowseRestore
            // 
            this.buttonBrowseRestore.Location = new System.Drawing.Point(450, 30);
            this.buttonBrowseRestore.Name = "buttonBrowseRestore";
            this.buttonBrowseRestore.Size = new System.Drawing.Size(100, 27);
            this.buttonBrowseRestore.TabIndex = 2;
            this.buttonBrowseRestore.Text = "Browse...";
            this.buttonBrowseRestore.UseVisualStyleBackColor = true;
            this.buttonBrowseRestore.Click += new System.EventHandler(this.ButtonBrowseRestore_Click);

            // 
            // radioRestoreCustom
            // 
            this.radioRestoreCustom.AutoSize = true;
            this.radioRestoreCustom.Checked = true;
            this.radioRestoreCustom.Location = new System.Drawing.Point(100, 65);
            this.radioRestoreCustom.Name = "radioRestoreCustom";
            this.radioRestoreCustom.Size = new System.Drawing.Size(147, 24);
            this.radioRestoreCustom.TabIndex = 3;
            this.radioRestoreCustom.TabStop = true;
            this.radioRestoreCustom.Text = "Custom format (-F c)";
            this.radioRestoreCustom.UseVisualStyleBackColor = true;

            // 
            // radioRestorePlain
            // 
            this.radioRestorePlain.AutoSize = true;
            this.radioRestorePlain.Location = new System.Drawing.Point(270, 65);
            this.radioRestorePlain.Name = "radioRestorePlain";
            this.radioRestorePlain.Size = new System.Drawing.Size(116, 24);
            this.radioRestorePlain.TabIndex = 4;
            this.radioRestorePlain.TabStop = false;
            this.radioRestorePlain.Text = "Plain SQL (.sql)";
            this.radioRestorePlain.UseVisualStyleBackColor = true;

            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(100, 110);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(100, 30);
            this.buttonRestore.TabIndex = 5;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.ButtonRestore_Click);

            // 
            // buttonDeleteAndRestore
            // 
            this.buttonDeleteAndRestore.Location = new System.Drawing.Point(220, 110);
            this.buttonDeleteAndRestore.Name = "buttonDeleteAndRestore";
            this.buttonDeleteAndRestore.Size = new System.Drawing.Size(150, 30);
            this.buttonDeleteAndRestore.TabIndex = 6;
            this.buttonDeleteAndRestore.Text = "Delete && Restore";
            this.buttonDeleteAndRestore.UseVisualStyleBackColor = true;
            this.buttonDeleteAndRestore.Click += new System.EventHandler(this.ButtonDeleteAndRestore_Click);

            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(390, 110);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 30);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);

            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(10, 440);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(580, 130);
            this.textBoxLog.TabIndex = 3;

            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 410);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(580, 25);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;

            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(600, 580);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.groupBoxRestore);
            this.Controls.Add(this.groupBoxBackup);
            this.Controls.Add(this.groupBoxConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PostgreSQL Backup/Restore Tool";

            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.groupBoxBackup.ResumeLayout(false);
            this.groupBoxBackup.PerformLayout();
            this.groupBoxRestore.ResumeLayout(false);
            this.groupBoxRestore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
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
        private System.Windows.Forms.Button buttonDeleteAndRestore;
        private System.Windows.Forms.Button buttonDelete;

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
