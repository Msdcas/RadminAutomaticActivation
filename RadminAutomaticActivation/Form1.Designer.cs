
namespace RadminAutomaticActivation
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtActivate = new System.Windows.Forms.Button();
            this.RichTBConsole = new System.Windows.Forms.RichTextBox();
            this.TbArchivePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.TbExtractPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RbRepList = new System.Windows.Forms.RichTextBox();
            this.BtArchivePathClear = new System.Windows.Forms.Button();
            this.BtExtractPathClear = new System.Windows.Forms.Button();
            this.RbFirstFindFiles = new System.Windows.Forms.RadioButton();
            this.RbFromFolder = new System.Windows.Forms.RadioButton();
            this.TbInFolder = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.BtLogon = new System.Windows.Forms.Button();
            this.RbActiveWin = new System.Windows.Forms.RadioButton();
            this.RbActiveRadm = new System.Windows.Forms.RadioButton();
            this.RbActiveAdm = new System.Windows.Forms.RadioButton();
            this.BtSetArchPath = new System.Windows.Forms.Button();
            this.BtSetExtractPath = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BtSetArchFolder = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.PanelPing65 = new System.Windows.Forms.Panel();
            this.LabelPing65 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.PanelPing17 = new System.Windows.Forms.Panel();
            this.PanelPingnas64 = new System.Windows.Forms.Panel();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtActivate
            // 
            this.BtActivate.Location = new System.Drawing.Point(253, 330);
            this.BtActivate.Name = "BtActivate";
            this.BtActivate.Size = new System.Drawing.Size(233, 49);
            this.BtActivate.TabIndex = 0;
            this.BtActivate.Text = "АКТИВИРОВАТЬ\r\n(удаленная сессия будет отключена)";
            this.BtActivate.UseVisualStyleBackColor = true;
            this.BtActivate.Click += new System.EventHandler(this.button1_Click);
            // 
            // RichTBConsole
            // 
            this.RichTBConsole.Location = new System.Drawing.Point(6, 229);
            this.RichTBConsole.Name = "RichTBConsole";
            this.RichTBConsole.Size = new System.Drawing.Size(480, 95);
            this.RichTBConsole.TabIndex = 1;
            this.RichTBConsole.Text = "";
            // 
            // TbArchivePath
            // 
            this.TbArchivePath.Location = new System.Drawing.Point(6, 32);
            this.TbArchivePath.Name = "TbArchivePath";
            this.TbArchivePath.Size = new System.Drawing.Size(399, 20);
            this.TbArchivePath.TabIndex = 2;
            this.TbArchivePath.Text = "\\\\nas64\\distrib\\Стандартный набор\\Remote Control\\radmin\\Radmin Server 3.5.2.1 (2)" +
    ".zip";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Путь к архиву .zip .rar или папке";
            // 
            // TbExtractPath
            // 
            this.TbExtractPath.Location = new System.Drawing.Point(6, 80);
            this.TbExtractPath.Name = "TbExtractPath";
            this.TbExtractPath.Size = new System.Drawing.Size(399, 20);
            this.TbExtractPath.TabIndex = 5;
            this.TbExtractPath.Text = "C:\\Windows\\SysWOW64\\rserver30";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Извлекать в (корень программы)";
            // 
            // RbRepList
            // 
            this.RbRepList.Location = new System.Drawing.Point(6, 116);
            this.RbRepList.Name = "RbRepList";
            this.RbRepList.Size = new System.Drawing.Size(256, 96);
            this.RbRepList.TabIndex = 7;
            this.RbRepList.Text = "newtstop.dll\nnts64helper.dll\nwsock32.dll";
            // 
            // BtArchivePathClear
            // 
            this.BtArchivePathClear.Location = new System.Drawing.Point(411, 31);
            this.BtArchivePathClear.Name = "BtArchivePathClear";
            this.BtArchivePathClear.Size = new System.Drawing.Size(26, 21);
            this.BtArchivePathClear.TabIndex = 9;
            this.BtArchivePathClear.Text = "X";
            this.BtArchivePathClear.UseVisualStyleBackColor = true;
            this.BtArchivePathClear.Click += new System.EventHandler(this.bArchivePathClear_Click);
            // 
            // BtExtractPathClear
            // 
            this.BtExtractPathClear.Location = new System.Drawing.Point(411, 79);
            this.BtExtractPathClear.Name = "BtExtractPathClear";
            this.BtExtractPathClear.Size = new System.Drawing.Size(26, 21);
            this.BtExtractPathClear.TabIndex = 10;
            this.BtExtractPathClear.Text = "X";
            this.BtExtractPathClear.UseVisualStyleBackColor = true;
            this.BtExtractPathClear.Click += new System.EventHandler(this.bExtractPathClear_Click);
            // 
            // RbFirstFindFiles
            // 
            this.RbFirstFindFiles.AutoSize = true;
            this.RbFirstFindFiles.Location = new System.Drawing.Point(274, 118);
            this.RbFirstFindFiles.Name = "RbFirstFindFiles";
            this.RbFirstFindFiles.Size = new System.Drawing.Size(128, 17);
            this.RbFirstFindFiles.TabIndex = 13;
            this.RbFirstFindFiles.Text = "первые попавшиеся";
            this.RbFirstFindFiles.UseVisualStyleBackColor = true;
            this.RbFirstFindFiles.CheckedChanged += new System.EventHandler(this.rbFirstFindFiles_CheckedChanged);
            // 
            // RbFromFolder
            // 
            this.RbFromFolder.AutoSize = true;
            this.RbFromFolder.Checked = true;
            this.RbFromFolder.Location = new System.Drawing.Point(274, 141);
            this.RbFromFolder.Name = "RbFromFolder";
            this.RbFromFolder.Size = new System.Drawing.Size(70, 17);
            this.RbFromFolder.TabIndex = 14;
            this.RbFromFolder.TabStop = true;
            this.RbFromFolder.Text = "из папки";
            this.RbFromFolder.UseVisualStyleBackColor = true;
            // 
            // TbInFolder
            // 
            this.TbInFolder.Location = new System.Drawing.Point(401, 140);
            this.TbInFolder.Name = "TbInFolder";
            this.TbInFolder.Size = new System.Drawing.Size(94, 20);
            this.TbInFolder.TabIndex = 15;
            this.TbInFolder.Text = "Med";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.BtLogon);
            this.GroupBox2.Controls.Add(this.RbActiveWin);
            this.GroupBox2.Controls.Add(this.RbActiveRadm);
            this.GroupBox2.Controls.Add(this.RbActiveAdm);
            this.GroupBox2.Location = new System.Drawing.Point(9, 423);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(507, 46);
            this.GroupBox2.TabIndex = 18;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Логин\\Пароль --не мешать выполнению";
            // 
            // BtLogon
            // 
            this.BtLogon.Location = new System.Drawing.Point(407, 16);
            this.BtLogon.Name = "BtLogon";
            this.BtLogon.Size = new System.Drawing.Size(79, 23);
            this.BtLogon.TabIndex = 4;
            this.BtLogon.Text = "Задать";
            this.BtLogon.UseVisualStyleBackColor = true;
            this.BtLogon.Click += new System.EventHandler(this.btLogon_Click);
            // 
            // RbActiveWin
            // 
            this.RbActiveWin.AutoSize = true;
            this.RbActiveWin.Location = new System.Drawing.Point(127, 19);
            this.RbActiveWin.Name = "RbActiveWin";
            this.RbActiveWin.Size = new System.Drawing.Size(104, 17);
            this.RbActiveWin.TabIndex = 2;
            this.RbActiveWin.Text = "Администратор";
            this.RbActiveWin.UseVisualStyleBackColor = true;
            // 
            // RbActiveRadm
            // 
            this.RbActiveRadm.AutoSize = true;
            this.RbActiveRadm.Checked = true;
            this.RbActiveRadm.Location = new System.Drawing.Point(65, 19);
            this.RbActiveRadm.Name = "RbActiveRadm";
            this.RbActiveRadm.Size = new System.Drawing.Size(56, 17);
            this.RbActiveRadm.TabIndex = 1;
            this.RbActiveRadm.TabStop = true;
            this.RbActiveRadm.Text = "radmin";
            this.RbActiveRadm.UseVisualStyleBackColor = true;
            // 
            // RbActiveAdm
            // 
            this.RbActiveAdm.AutoSize = true;
            this.RbActiveAdm.Location = new System.Drawing.Point(6, 19);
            this.RbActiveAdm.Name = "RbActiveAdm";
            this.RbActiveAdm.Size = new System.Drawing.Size(53, 17);
            this.RbActiveAdm.TabIndex = 0;
            this.RbActiveAdm.Text = "admin";
            this.RbActiveAdm.UseVisualStyleBackColor = true;
            // 
            // BtSetArchPath
            // 
            this.BtSetArchPath.Location = new System.Drawing.Point(444, 31);
            this.BtSetArchPath.Name = "BtSetArchPath";
            this.BtSetArchPath.Size = new System.Drawing.Size(51, 20);
            this.BtSetArchPath.TabIndex = 19;
            this.BtSetArchPath.Text = "file";
            this.BtSetArchPath.UseVisualStyleBackColor = true;
            this.BtSetArchPath.Click += new System.EventHandler(this.btSetArchPath_Click);
            // 
            // BtSetExtractPath
            // 
            this.BtSetExtractPath.Location = new System.Drawing.Point(444, 79);
            this.BtSetExtractPath.Name = "BtSetExtractPath";
            this.BtSetExtractPath.Size = new System.Drawing.Size(51, 21);
            this.BtSetExtractPath.TabIndex = 20;
            this.BtSetExtractPath.Text = "folder";
            this.BtSetExtractPath.UseVisualStyleBackColor = true;
            this.BtSetExtractPath.Click += new System.EventHandler(this.btSetExtractPath_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BtSetArchFolder
            // 
            this.BtSetArchFolder.Location = new System.Drawing.Point(444, 53);
            this.BtSetArchFolder.Name = "BtSetArchFolder";
            this.BtSetArchFolder.Size = new System.Drawing.Size(51, 20);
            this.BtSetArchFolder.TabIndex = 21;
            this.BtSetArchFolder.Text = "folder";
            this.BtSetArchFolder.UseVisualStyleBackColor = true;
            this.BtSetArchFolder.Click += new System.EventHandler(this.btSetArchFolder_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.RbFirstFindFiles);
            this.GroupBox1.Controls.Add(this.RbRepList);
            this.GroupBox1.Controls.Add(this.BtSetArchFolder);
            this.GroupBox1.Controls.Add(this.RbFromFolder);
            this.GroupBox1.Controls.Add(this.PanelPing65);
            this.GroupBox1.Controls.Add(this.TbInFolder);
            this.GroupBox1.Controls.Add(this.LabelPing65);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.TbArchivePath);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.BtSetExtractPath);
            this.GroupBox1.Controls.Add(this.PanelPing17);
            this.GroupBox1.Controls.Add(this.PanelPingnas64);
            this.GroupBox1.Controls.Add(this.TbExtractPath);
            this.GroupBox1.Controls.Add(this.RichTBConsole);
            this.GroupBox1.Controls.Add(this.BtActivate);
            this.GroupBox1.Controls.Add(this.BtSetArchPath);
            this.GroupBox1.Controls.Add(this.BtExtractPathClear);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.BtArchivePathClear);
            this.GroupBox1.Location = new System.Drawing.Point(9, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(507, 405);
            this.GroupBox1.TabIndex = 24;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Параметры";
            // 
            // PanelPing65
            // 
            this.PanelPing65.Location = new System.Drawing.Point(11, 358);
            this.PanelPing65.Name = "PanelPing65";
            this.PanelPing65.Size = new System.Drawing.Size(15, 15);
            this.PanelPing65.TabIndex = 8;
            // 
            // LabelPing65
            // 
            this.LabelPing65.AutoSize = true;
            this.LabelPing65.Location = new System.Drawing.Point(32, 358);
            this.LabelPing65.Name = "LabelPing65";
            this.LabelPing65.Size = new System.Drawing.Size(71, 13);
            this.LabelPing65.TabIndex = 7;
            this.LabelPing65.Text = "ping server65";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(32, 379);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(93, 13);
            this.Label5.TabIndex = 5;
            this.Label5.Text = "check dns 195.17";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(32, 337);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(59, 13);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "ping nas64";
            // 
            // PanelPing17
            // 
            this.PanelPing17.Location = new System.Drawing.Point(11, 379);
            this.PanelPing17.Name = "PanelPing17";
            this.PanelPing17.Size = new System.Drawing.Size(15, 15);
            this.PanelPing17.TabIndex = 3;
            // 
            // PanelPingnas64
            // 
            this.PanelPingnas64.Location = new System.Drawing.Point(11, 337);
            this.PanelPingnas64.Name = "PanelPingnas64";
            this.PanelPingnas64.Size = new System.Drawing.Size(15, 15);
            this.PanelPingnas64.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 475);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Лицензирование Radmin Server v3.5.x";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtActivate;
        private System.Windows.Forms.RichTextBox RichTBConsole;
        private System.Windows.Forms.TextBox TbArchivePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox TbExtractPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox RbRepList;
        private System.Windows.Forms.Button BtArchivePathClear;
        private System.Windows.Forms.Button BtExtractPathClear;
        private System.Windows.Forms.RadioButton RbFirstFindFiles;
        private System.Windows.Forms.RadioButton RbFromFolder;
        private System.Windows.Forms.TextBox TbInFolder;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.RadioButton RbActiveWin;
        private System.Windows.Forms.RadioButton RbActiveRadm;
        private System.Windows.Forms.RadioButton RbActiveAdm;
        private System.Windows.Forms.Button BtSetArchPath;
        private System.Windows.Forms.Button BtSetExtractPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Panel PanelPing17;
        private System.Windows.Forms.Panel PanelPingnas64;
        private System.Windows.Forms.Label LabelPing65;
        private System.Windows.Forms.Button BtSetArchFolder;
        private System.Windows.Forms.Button BtLogon;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Panel PanelPing65;
    }
}

