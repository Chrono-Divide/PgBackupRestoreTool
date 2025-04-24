using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PgBackupRestoreTool
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initialize the form's components.
        /// </summary>
        private void InitializeComponent()
        {
            // Connection group
            this.groupBoxConnection = new GroupBox();
            this.labelConnectionString = new Label();
            this.comboBoxHost = new ComboBox();
            this.buttonTestConnection = new Button();

            // Backup group
            this.groupBoxBackup = new GroupBox();
            this.labelBackupFile = new Label();
            this.textBoxBackupFile = new TextBox();
            this.buttonBrowseBackup = new Button();
            this.radioBackupPlain = new RadioButton();
            this.radioBackupCustom = new RadioButton();
            this.buttonBackup = new Button();

            // Restore group
            this.groupBoxRestore = new GroupBox();
            this.labelRestoreFile = new Label();
            this.textBoxRestoreFile = new TextBox();
            this.buttonBrowseRestore = new Button();
            this.radioRestorePlain = new RadioButton();
            this.radioRestoreCustom = new RadioButton();
            this.labelSchema = new Label();
            this.comboBoxSchema = new ComboBox();
            this.checkBoxClean = new CheckBox();
            this.buttonRestore = new Button();

            // Other controls
            this.progressBar1 = new ProgressBar();
            this.textBoxLog = new TextBox();

            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.labelConnectionString);
            this.groupBoxConnection.Controls.Add(this.comboBoxHost);
            this.groupBoxConnection.Controls.Add(this.buttonTestConnection);
            this.groupBoxConnection.Location = new Point(10, 10);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new Size(599, 72);
            this.groupBoxConnection.TabIndex = 0;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection";

            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new Point(10, 30);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new Size(104, 15);
            this.labelConnectionString.TabIndex = 0;
            this.labelConnectionString.Text = "Connection string:";

            // 
            // comboBoxHost
            // 
            this.comboBoxHost.FormattingEnabled = true;
            this.comboBoxHost.Location = new Point(120, 27);
            this.comboBoxHost.Name = "comboBoxHost";
            this.comboBoxHost.Size = new Size(367, 23);
            this.comboBoxHost.TabIndex = 1;

            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Location = new Point(493, 25);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new Size(100, 27);
            this.buttonTestConnection.TabIndex = 2;
            this.buttonTestConnection.Text = "Test";
            this.buttonTestConnection.UseVisualStyleBackColor = true;
            this.buttonTestConnection.Click += new EventHandler(this.buttonTestConnection_Click);

            // 
            // groupBoxBackup
            // 
            this.groupBoxBackup.Controls.Add(this.labelBackupFile);
            this.groupBoxBackup.Controls.Add(this.textBoxBackupFile);
            this.groupBoxBackup.Controls.Add(this.buttonBrowseBackup);
            this.groupBoxBackup.Controls.Add(this.radioBackupPlain);
            this.groupBoxBackup.Controls.Add(this.radioBackupCustom);
            this.groupBoxBackup.Controls.Add(this.buttonBackup);
            this.groupBoxBackup.Location = new Point(10, 88);
            this.groupBoxBackup.Name = "groupBoxBackup";
            this.groupBoxBackup.Size = new Size(599, 120);
            this.groupBoxBackup.TabIndex = 1;
            this.groupBoxBackup.TabStop = false;
            this.groupBoxBackup.Text = "Backup";

            // 
            // labelBackupFile
            // 
            this.labelBackupFile.AutoSize = true;
            this.labelBackupFile.Location = new Point(10, 34);
            this.labelBackupFile.Name = "labelBackupFile";
            this.labelBackupFile.Size = new Size(68, 15);
            this.labelBackupFile.TabIndex = 0;
            this.labelBackupFile.Text = "Backup file:";

            // 
            // textBoxBackupFile
            // 
            this.textBoxBackupFile.Location = new Point(120, 30);
            this.textBoxBackupFile.Name = "textBoxBackupFile";
            this.textBoxBackupFile.Size = new Size(367, 23);
            this.textBoxBackupFile.TabIndex = 1;

            // 
            // buttonBrowseBackup
            // 
            this.buttonBrowseBackup.Location = new Point(493, 28);
            this.buttonBrowseBackup.Name = "buttonBrowseBackup";
            this.buttonBrowseBackup.Size = new Size(100, 27);
            this.buttonBrowseBackup.TabIndex = 2;
            this.buttonBrowseBackup.Text = "Browse...";
            this.buttonBrowseBackup.UseVisualStyleBackColor = true;
            this.buttonBrowseBackup.Click += new EventHandler(this.ButtonBrowseBackup_Click);

            // 
            // radioBackupPlain
            // 
            this.radioBackupPlain.AutoSize = true;
            this.radioBackupPlain.Checked = true;
            this.radioBackupPlain.Location = new Point(155, 77);
            this.radioBackupPlain.Name = "radioBackupPlain";
            this.radioBackupPlain.Size = new Size(104, 19);
            this.radioBackupPlain.TabIndex = 3;
            this.radioBackupPlain.TabStop = true;
            this.radioBackupPlain.Text = "Plain SQL (.sql)";
            this.radioBackupPlain.UseVisualStyleBackColor = true;

            // 
            // radioBackupCustom
            // 
            this.radioBackupCustom.AutoSize = true;
            this.radioBackupCustom.Location = new Point(301, 77);
            this.radioBackupCustom.Name = "radioBackupCustom";
            this.radioBackupCustom.Size = new Size(134, 19);
            this.radioBackupCustom.TabIndex = 4;
            this.radioBackupCustom.Text = "Custom format (-F c)";
            this.radioBackupCustom.UseVisualStyleBackColor = true;

            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new Point(493, 71);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new Size(100, 30);
            this.buttonBackup.TabIndex = 5;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new EventHandler(this.ButtonBackup_Click);

            // 
            // groupBoxRestore
            // 
            this.groupBoxRestore.Controls.Add(this.labelRestoreFile);
            this.groupBoxRestore.Controls.Add(this.textBoxRestoreFile);
            this.groupBoxRestore.Controls.Add(this.buttonBrowseRestore);
            this.groupBoxRestore.Controls.Add(this.radioRestorePlain);
            this.groupBoxRestore.Controls.Add(this.radioRestoreCustom);
            this.groupBoxRestore.Controls.Add(this.labelSchema);
            this.groupBoxRestore.Controls.Add(this.comboBoxSchema);
            this.groupBoxRestore.Controls.Add(this.checkBoxClean);
            this.groupBoxRestore.Controls.Add(this.buttonRestore);
            this.groupBoxRestore.Location = new Point(10, 214);
            this.groupBoxRestore.Name = "groupBoxRestore";
            this.groupBoxRestore.Size = new Size(599, 180);
            this.groupBoxRestore.TabIndex = 2;
            this.groupBoxRestore.TabStop = false;
            this.groupBoxRestore.Text = "Restore";

            // 
            // labelRestoreFile
            // 
            this.labelRestoreFile.AutoSize = true;
            this.labelRestoreFile.Location = new Point(10, 33);
            this.labelRestoreFile.Name = "labelRestoreFile";
            this.labelRestoreFile.Size = new Size(68, 15);
            this.labelRestoreFile.TabIndex = 0;
            this.labelRestoreFile.Text = "Backup file:";

            // 
            // textBoxRestoreFile
            // 
            this.textBoxRestoreFile.Location = new Point(120, 30);
            this.textBoxRestoreFile.Name = "textBoxRestoreFile";
            this.textBoxRestoreFile.Size = new Size(367, 23);
            this.textBoxRestoreFile.TabIndex = 1;

            // 
            // buttonBrowseRestore
            // 
            this.buttonBrowseRestore.Location = new Point(493, 28);
            this.buttonBrowseRestore.Name = "buttonBrowseRestore";
            this.buttonBrowseRestore.Size = new Size(100, 27);
            this.buttonBrowseRestore.TabIndex = 2;
            this.buttonBrowseRestore.Text = "Browse...";
            this.buttonBrowseRestore.UseVisualStyleBackColor = true;
            this.buttonBrowseRestore.Click += new EventHandler(this.ButtonBrowseRestore_Click);

            // 
            // radioRestorePlain
            // 
            this.radioRestorePlain.AutoSize = true;
            this.radioRestorePlain.Checked = true;
            this.radioRestorePlain.Location = new Point(155, 66);
            this.radioRestorePlain.Name = "radioRestorePlain";
            this.radioRestorePlain.Size = new Size(104, 19);
            this.radioRestorePlain.TabIndex = 3;
            this.radioRestorePlain.TabStop = true;
            this.radioRestorePlain.Text = "Plain SQL (.sql)";
            this.radioRestorePlain.UseVisualStyleBackColor = true;

            // 
            // radioRestoreCustom
            // 
            this.radioRestoreCustom.AutoSize = true;
            this.radioRestoreCustom.Location = new Point(301, 66);
            this.radioRestoreCustom.Name = "radioRestoreCustom";
            this.radioRestoreCustom.Size = new Size(134, 19);
            this.radioRestoreCustom.TabIndex = 4;
            this.radioRestoreCustom.Text = "Custom format (-F c)";
            this.radioRestoreCustom.UseVisualStyleBackColor = true;

            // 
            // labelSchema
            // 
            this.labelSchema.AutoSize = true;
            this.labelSchema.Location = new Point(10, 103);
            this.labelSchema.Name = "labelSchema";
            this.labelSchema.Size = new Size(51, 15);
            this.labelSchema.TabIndex = 5;
            this.labelSchema.Text = "Schema:";

            // 
            // comboBoxSchema
            // 
            this.comboBoxSchema.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxSchema.Location = new Point(120, 100);
            this.comboBoxSchema.Name = "comboBoxSchema";
            this.comboBoxSchema.Size = new Size(367, 23);
            this.comboBoxSchema.TabIndex = 6;

            // 
            // checkBoxClean
            // 
            this.checkBoxClean.AutoSize = true;
            this.checkBoxClean.Location = new Point(120, 146);
            this.checkBoxClean.Name = "checkBoxClean";
            this.checkBoxClean.Size = new Size(174, 19);
            this.checkBoxClean.TabIndex = 7;
            this.checkBoxClean.Text = "Clean schema before restore";
            this.checkBoxClean.UseVisualStyleBackColor = true;

            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new Point(493, 139);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new Size(100, 30);
            this.buttonRestore.TabIndex = 8;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new EventHandler(this.ButtonRestore_Click);

            // 
            // progressBar1
            // 
            this.progressBar1.Location = new Point(10, 400);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(599, 25);
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Visible = false;

            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new Point(10, 431);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = ScrollBars.Vertical;
            this.textBoxLog.Size = new Size(599, 107);
            this.textBoxLog.TabIndex = 10;

            // 
            // frmMain
            // 
            this.ClientSize = new Size(621, 550);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.groupBoxRestore);
            this.Controls.Add(this.groupBoxBackup);
            this.Controls.Add(this.groupBoxConnection);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = FormStartPosition.CenterScreen;
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

        private GroupBox groupBoxConnection;
        private Label labelConnectionString;
        private ComboBox comboBoxHost;
        private Button buttonTestConnection;

        private GroupBox groupBoxBackup;
        private Label labelBackupFile;
        private TextBox textBoxBackupFile;
        private Button buttonBrowseBackup;
        private RadioButton radioBackupPlain;
        private RadioButton radioBackupCustom;
        private Button buttonBackup;

        private GroupBox groupBoxRestore;
        private Label labelRestoreFile;
        private TextBox textBoxRestoreFile;
        private Button buttonBrowseRestore;
        private RadioButton radioRestorePlain;
        private RadioButton radioRestoreCustom;
        private Label labelSchema;
        private ComboBox comboBoxSchema;
        private CheckBox checkBoxClean;
        private Button buttonRestore;

        private ProgressBar progressBar1;
        private TextBox textBoxLog;
    }
}
