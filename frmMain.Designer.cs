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
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.comboBoxHost = new System.Windows.Forms.ComboBox();
            this.buttonTestConnection = new System.Windows.Forms.Button();

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
            this.labelSchema = new System.Windows.Forms.Label();
            this.comboBoxSchema = new System.Windows.Forms.ComboBox();
            this.checkBoxClean = new System.Windows.Forms.CheckBox();

            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();

            this.groupBoxConnection.SuspendLayout();
            this.groupBoxBackup.SuspendLayout();
            this.groupBoxRestore.SuspendLayout();
            this.SuspendLayout();

            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.labelConnectionString);
            this.groupBoxConnection.Controls.Add(this.comboBoxHost);
            this.groupBoxConnection.Controls.Add(this.buttonTestConnection);
            this.groupBoxConnection.Location = new System.Drawing.Point(10, 10);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(580, 90);
            this.groupBoxConnection.TabIndex = 0;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection";
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(10, 30);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(117, 15);
            this.labelConnectionString.TabIndex = 0;
            this.labelConnectionString.Text = "Connection string:";
            // 
            // comboBoxHost
            // 
            this.comboBoxHost.FormattingEnabled = true;
            this.comboBoxHost.Location = new System.Drawing.Point(135, 27);
            this.comboBoxHost.Name = "comboBoxHost";
            this.comboBoxHost.Size = new System.Drawing.Size(330, 23);
            this.comboBoxHost.TabIndex = 1;
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Location = new System.Drawing.Point(480, 25);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(90, 27);
            this.buttonTestConnection.TabIndex = 2;
            this.buttonTestConnection.Text = "Test";
            this.buttonTestConnection.UseVisualStyleBackColor = true;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // groupBoxBackup
            // 
            this.groupBoxBackup.Controls.Add(this.labelBackupFile);
            this.groupBoxBackup.Controls.Add(this.textBoxBackupFile);
            this.groupBoxBackup.Controls.Add(this.buttonBrowseBackup);
            this.groupBoxBackup.Controls.Add(this.radioBackupCustom);
            this.groupBoxBackup.Controls.Add(this.radioBackupPlain);
            this.groupBoxBackup.Controls.Add(this.buttonBackup);
            this.groupBoxBackup.Location = new System.Drawing.Point(10, 110);
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
            this.labelBackupFile.Size = new System.Drawing.Size(68, 15);
            this.labelBackupFile.TabIndex = 0;
            this.labelBackupFile.Text = "Backup file:";
            // 
            // textBoxBackupFile
            // 
            this.textBoxBackupFile.Location = new System.Drawing.Point(100, 30);
            this.textBoxBackupFile.Name = "textBoxBackupFile";
            this.textBoxBackupFile.Size = new System.Drawing.Size(340, 23);
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
            this.radioBackupCustom.Location = new System.Drawing.Point(246, 71);
            this.radioBackupCustom.Name = "radioBackupCustom";
            this.radioBackupCustom.Size = new System.Drawing.Size(134, 19);
            this.radioBackupCustom.TabIndex = 3;
            this.radioBackupCustom.Text = "Custom format (-F c)";
            this.radioBackupCustom.UseVisualStyleBackColor = true;
            // 
            // radioBackupPlain
            // 
            this.radioBackupPlain.AutoSize = true;
            this.radioBackupPlain.Checked = true;
            this.radioBackupPlain.Location = new System.Drawing.Point(100, 71);
            this.radioBackupPlain.Name = "radioBackupPlain";
            this.radioBackupPlain.Size = new System.Drawing.Size(104, 19);
            this.radioBackupPlain.TabIndex = 4;
            this.radioBackupPlain.TabStop = true;
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
            this.groupBoxRestore.Controls.Add(this.labelSchema);
            this.groupBoxRestore.Controls.Add(this.comboBoxSchema);
            this.groupBoxRestore.Controls.Add(this.checkBoxClean);
            this.groupBoxRestore.Location = new System.Drawing.Point(10, 240);
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
            this.labelRestoreFile.Size = new System.Drawing.Size(68, 15);
            this.labelRestoreFile.TabIndex = 0;
            this.labelRestoreFile.Text = "Backup file:";
            // 
            // textBoxRestoreFile
            // 
            this.textBoxRestoreFile.Location = new System.Drawing.Point(100, 30);
            this.textBoxRestoreFile.Name = "textBoxRestoreFile";
            this.textBoxRestoreFile.Size = new System.Drawing.Size(340, 23);
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
            this.radioRestoreCustom.Location = new System.Drawing.Point(246, 70);
            this.radioRestoreCustom.Name = "radioRestoreCustom";
            this.radioRestoreCustom.Size = new System.Drawing.Size(134, 19);
            this.radioRestoreCustom.TabIndex = 3;
            this.radioRestoreCustom.Text = "Custom format (-F c)";
            this.radioRestoreCustom.UseVisualStyleBackColor = true;
            // 
            // radioRestorePlain
            // 
            this.radioRestorePlain.AutoSize = true;
            this.radioRestorePlain.Checked = true;
            this.radioRestorePlain.Location = new System.Drawing.Point(100, 70);
            this.radioRestorePlain.Name = "radioRestorePlain";
            this.radioRestorePlain.Size = new System.Drawing.Size(104, 19);
            this.radioRestorePlain.TabIndex = 4;
            this.radioRestorePlain.TabStop = true;
            this.radioRestorePlain.Text = "Plain SQL (.sql)";
            this.radioRestorePlain.UseVisualStyleBackColor = true;
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(450, 130);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(100, 30);
            this.buttonRestore.TabIndex = 5;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.ButtonRestore_Click);
            // 
            // labelSchema
            // 
            this.labelSchema.AutoSize = true;
            this.labelSchema.Location = new System.Drawing.Point(10, 100);
            this.labelSchema.Name = "labelSchema";
            this.labelSchema.Size = new System.Drawing.Size(51, 15);
            this.labelSchema.TabIndex = 6;
            this.labelSchema.Text = "Schema:";
            // 
            // comboBoxSchema
            // 
            this.comboBoxSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSchema.Location = new System.Drawing.Point(100, 95);
            this.comboBoxSchema.Name = "comboBoxSchema";
            this.comboBoxSchema.Size = new System.Drawing.Size(200, 23);
            this.comboBoxSchema.TabIndex = 7;
            // 
            // checkBoxClean
            // 
            this.checkBoxClean.AutoSize = true;
            this.checkBoxClean.Location = new System.Drawing.Point(320, 97);
            this.checkBoxClean.Name = "checkBoxClean";
            this.checkBoxClean.Size = new System.Drawing.Size(174, 19);
            this.checkBoxClean.TabIndex = 8;
            this.checkBoxClean.Text = "Clean schema before restore";
            this.checkBoxClean.UseVisualStyleBackColor = true;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(10, 430);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(580, 110);
            this.textBoxLog.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 400);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(580, 25);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(600, 550);
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
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.ComboBox comboBoxHost;
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
        private System.Windows.Forms.Label labelSchema;
        private System.Windows.Forms.ComboBox comboBoxSchema;
        private System.Windows.Forms.CheckBox checkBoxClean;

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
