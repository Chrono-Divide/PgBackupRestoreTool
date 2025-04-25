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
            groupBoxConnection = new GroupBox();
            labelConnectionString = new Label();
            comboBoxHost = new ComboBox();
            buttonConnect = new Button();
            groupBoxBackup = new GroupBox();
            labelBackupFile = new Label();
            textBoxBackupFile = new TextBox();
            buttonBrowseBackup = new Button();
            radioBackupPlain = new RadioButton();
            radioBackupCustom = new RadioButton();
            buttonBackup = new Button();
            groupBoxRestore = new GroupBox();
            ButtonKillSessions = new Button();
            checkBoxDrop = new CheckBox();
            labelRestoreFile = new Label();
            textBoxRestoreFile = new TextBox();
            buttonBrowseRestore = new Button();
            radioRestorePlain = new RadioButton();
            radioRestoreCustom = new RadioButton();
            labelSchema = new Label();
            comboBoxSchema = new ComboBox();
            checkBoxClean = new CheckBox();
            buttonRestore = new Button();
            progressBar1 = new ProgressBar();
            textBoxLog = new TextBox();
            groupBoxConnection.SuspendLayout();
            groupBoxBackup.SuspendLayout();
            groupBoxRestore.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxConnection
            // 
            groupBoxConnection.Controls.Add(labelConnectionString);
            groupBoxConnection.Controls.Add(comboBoxHost);
            groupBoxConnection.Controls.Add(buttonConnect);
            groupBoxConnection.Location = new Point(10, 10);
            groupBoxConnection.Name = "groupBoxConnection";
            groupBoxConnection.Size = new Size(599, 72);
            groupBoxConnection.TabIndex = 0;
            groupBoxConnection.TabStop = false;
            groupBoxConnection.Text = "Connection";
            // 
            // labelConnectionString
            // 
            labelConnectionString.AutoSize = true;
            labelConnectionString.Location = new Point(10, 30);
            labelConnectionString.Name = "labelConnectionString";
            labelConnectionString.Size = new Size(104, 15);
            labelConnectionString.TabIndex = 0;
            labelConnectionString.Text = "Connection string:";
            // 
            // comboBoxHost
            // 
            comboBoxHost.FormattingEnabled = true;
            comboBoxHost.Location = new Point(120, 27);
            comboBoxHost.Name = "comboBoxHost";
            comboBoxHost.Size = new Size(367, 23);
            comboBoxHost.TabIndex = 1;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(493, 25);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(100, 27);
            buttonConnect.TabIndex = 2;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // groupBoxBackup
            // 
            groupBoxBackup.Controls.Add(labelBackupFile);
            groupBoxBackup.Controls.Add(textBoxBackupFile);
            groupBoxBackup.Controls.Add(buttonBrowseBackup);
            groupBoxBackup.Controls.Add(radioBackupPlain);
            groupBoxBackup.Controls.Add(radioBackupCustom);
            groupBoxBackup.Controls.Add(buttonBackup);
            groupBoxBackup.Location = new Point(10, 88);
            groupBoxBackup.Name = "groupBoxBackup";
            groupBoxBackup.Size = new Size(599, 120);
            groupBoxBackup.TabIndex = 1;
            groupBoxBackup.TabStop = false;
            groupBoxBackup.Text = "Backup";
            // 
            // labelBackupFile
            // 
            labelBackupFile.AutoSize = true;
            labelBackupFile.Location = new Point(10, 34);
            labelBackupFile.Name = "labelBackupFile";
            labelBackupFile.Size = new Size(68, 15);
            labelBackupFile.TabIndex = 0;
            labelBackupFile.Text = "Backup file:";
            // 
            // textBoxBackupFile
            // 
            textBoxBackupFile.Location = new Point(120, 30);
            textBoxBackupFile.Name = "textBoxBackupFile";
            textBoxBackupFile.Size = new Size(367, 23);
            textBoxBackupFile.TabIndex = 1;
            // 
            // buttonBrowseBackup
            // 
            buttonBrowseBackup.Location = new Point(493, 28);
            buttonBrowseBackup.Name = "buttonBrowseBackup";
            buttonBrowseBackup.Size = new Size(100, 27);
            buttonBrowseBackup.TabIndex = 2;
            buttonBrowseBackup.Text = "Browse...";
            buttonBrowseBackup.UseVisualStyleBackColor = true;
            buttonBrowseBackup.Click += ButtonBrowseBackup_Click;
            // 
            // radioBackupPlain
            // 
            radioBackupPlain.AutoSize = true;
            radioBackupPlain.Checked = true;
            radioBackupPlain.Location = new Point(155, 77);
            radioBackupPlain.Name = "radioBackupPlain";
            radioBackupPlain.Size = new Size(104, 19);
            radioBackupPlain.TabIndex = 3;
            radioBackupPlain.TabStop = true;
            radioBackupPlain.Text = "Plain SQL (.sql)";
            radioBackupPlain.UseVisualStyleBackColor = true;
            // 
            // radioBackupCustom
            // 
            radioBackupCustom.AutoSize = true;
            radioBackupCustom.Location = new Point(301, 77);
            radioBackupCustom.Name = "radioBackupCustom";
            radioBackupCustom.Size = new Size(134, 19);
            radioBackupCustom.TabIndex = 4;
            radioBackupCustom.Text = "Custom format (-F c)";
            radioBackupCustom.UseVisualStyleBackColor = true;
            // 
            // buttonBackup
            // 
            buttonBackup.Location = new Point(493, 71);
            buttonBackup.Name = "buttonBackup";
            buttonBackup.Size = new Size(100, 30);
            buttonBackup.TabIndex = 5;
            buttonBackup.Text = "Backup";
            buttonBackup.UseVisualStyleBackColor = true;
            buttonBackup.Click += ButtonBackup_Click;
            // 
            // groupBoxRestore
            // 
            groupBoxRestore.Controls.Add(ButtonKillSessions);
            groupBoxRestore.Controls.Add(checkBoxDrop);
            groupBoxRestore.Controls.Add(labelRestoreFile);
            groupBoxRestore.Controls.Add(textBoxRestoreFile);
            groupBoxRestore.Controls.Add(buttonBrowseRestore);
            groupBoxRestore.Controls.Add(radioRestorePlain);
            groupBoxRestore.Controls.Add(radioRestoreCustom);
            groupBoxRestore.Controls.Add(labelSchema);
            groupBoxRestore.Controls.Add(comboBoxSchema);
            groupBoxRestore.Controls.Add(checkBoxClean);
            groupBoxRestore.Controls.Add(buttonRestore);
            groupBoxRestore.Location = new Point(10, 214);
            groupBoxRestore.Name = "groupBoxRestore";
            groupBoxRestore.Size = new Size(599, 180);
            groupBoxRestore.TabIndex = 2;
            groupBoxRestore.TabStop = false;
            groupBoxRestore.Text = "Restore";
            // 
            // ButtonKillSessions
            // 
            ButtonKillSessions.Location = new Point(493, 97);
            ButtonKillSessions.Name = "ButtonKillSessions";
            ButtonKillSessions.Size = new Size(100, 30);
            ButtonKillSessions.TabIndex = 10;
            ButtonKillSessions.Text = "Terminate";
            ButtonKillSessions.UseVisualStyleBackColor = true;
            ButtonKillSessions.Click += ButtonKillSessions_Click;
            // 
            // checkBoxDrop
            // 
            checkBoxDrop.AutoSize = true;
            checkBoxDrop.Checked = true;
            checkBoxDrop.CheckState = CheckState.Checked;
            checkBoxDrop.Location = new Point(301, 146);
            checkBoxDrop.Name = "checkBoxDrop";
            checkBoxDrop.Size = new Size(171, 19);
            checkBoxDrop.TabIndex = 9;
            checkBoxDrop.Text = "Drop schema before restore";
            checkBoxDrop.UseVisualStyleBackColor = true;
            checkBoxDrop.CheckedChanged += CheckBoxMutualExclusive;
            // 
            // labelRestoreFile
            // 
            labelRestoreFile.AutoSize = true;
            labelRestoreFile.Location = new Point(10, 33);
            labelRestoreFile.Name = "labelRestoreFile";
            labelRestoreFile.Size = new Size(68, 15);
            labelRestoreFile.TabIndex = 0;
            labelRestoreFile.Text = "Backup file:";
            // 
            // textBoxRestoreFile
            // 
            textBoxRestoreFile.Location = new Point(120, 30);
            textBoxRestoreFile.Name = "textBoxRestoreFile";
            textBoxRestoreFile.Size = new Size(367, 23);
            textBoxRestoreFile.TabIndex = 1;
            // 
            // buttonBrowseRestore
            // 
            buttonBrowseRestore.Location = new Point(493, 28);
            buttonBrowseRestore.Name = "buttonBrowseRestore";
            buttonBrowseRestore.Size = new Size(100, 27);
            buttonBrowseRestore.TabIndex = 2;
            buttonBrowseRestore.Text = "Browse...";
            buttonBrowseRestore.UseVisualStyleBackColor = true;
            buttonBrowseRestore.Click += ButtonBrowseRestore_Click;
            // 
            // radioRestorePlain
            // 
            radioRestorePlain.AutoSize = true;
            radioRestorePlain.Checked = true;
            radioRestorePlain.Location = new Point(155, 66);
            radioRestorePlain.Name = "radioRestorePlain";
            radioRestorePlain.Size = new Size(104, 19);
            radioRestorePlain.TabIndex = 3;
            radioRestorePlain.TabStop = true;
            radioRestorePlain.Text = "Plain SQL (.sql)";
            radioRestorePlain.UseVisualStyleBackColor = true;
            // 
            // radioRestoreCustom
            // 
            radioRestoreCustom.AutoSize = true;
            radioRestoreCustom.Location = new Point(301, 66);
            radioRestoreCustom.Name = "radioRestoreCustom";
            radioRestoreCustom.Size = new Size(134, 19);
            radioRestoreCustom.TabIndex = 4;
            radioRestoreCustom.Text = "Custom format (-F c)";
            radioRestoreCustom.UseVisualStyleBackColor = true;
            // 
            // labelSchema
            // 
            labelSchema.AutoSize = true;
            labelSchema.Location = new Point(10, 103);
            labelSchema.Name = "labelSchema";
            labelSchema.Size = new Size(51, 15);
            labelSchema.TabIndex = 5;
            labelSchema.Text = "Schema:";
            // 
            // comboBoxSchema
            // 
            comboBoxSchema.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSchema.Location = new Point(120, 100);
            comboBoxSchema.Name = "comboBoxSchema";
            comboBoxSchema.Size = new Size(367, 23);
            comboBoxSchema.TabIndex = 6;
            // 
            // checkBoxClean
            // 
            checkBoxClean.AutoSize = true;
            checkBoxClean.Location = new Point(120, 146);
            checkBoxClean.Name = "checkBoxClean";
            checkBoxClean.Size = new Size(174, 19);
            checkBoxClean.TabIndex = 7;
            checkBoxClean.Text = "Clean schema before restore";
            checkBoxClean.UseVisualStyleBackColor = true;
            checkBoxClean.CheckedChanged += CheckBoxMutualExclusive;
            // 
            // buttonRestore
            // 
            buttonRestore.Location = new Point(493, 139);
            buttonRestore.Name = "buttonRestore";
            buttonRestore.Size = new Size(100, 30);
            buttonRestore.TabIndex = 8;
            buttonRestore.Text = "Restore";
            buttonRestore.UseVisualStyleBackColor = true;
            buttonRestore.Click += ButtonRestore_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(10, 400);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(599, 25);
            progressBar1.TabIndex = 9;
            progressBar1.Visible = false;
            // 
            // textBoxLog
            // 
            textBoxLog.Location = new Point(10, 431);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.ReadOnly = true;
            textBoxLog.ScrollBars = ScrollBars.Vertical;
            textBoxLog.Size = new Size(599, 107);
            textBoxLog.TabIndex = 10;
            // 
            // frmMain
            // 
            ClientSize = new Size(621, 550);
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

        private GroupBox groupBoxConnection;
        private Label labelConnectionString;
        private ComboBox comboBoxHost;
        private Button buttonConnect;

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
        private CheckBox checkBoxDrop;
        private Button ButtonKillSessions;
    }
}
