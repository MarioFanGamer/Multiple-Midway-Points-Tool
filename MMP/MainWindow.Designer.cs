namespace MMP
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMidwayPointsAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.destinationIndex = new System.Windows.Forms.NumericUpDown();
            this.waterLevel = new System.Windows.Forms.CheckBox();
            this.secondaryLevel = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveSettings = new System.Windows.Forms.Button();
            this.patchRom = new System.Windows.Forms.Button();
            this.levelNum = new System.Windows.Forms.ComboBox();
            this.midwayNum = new System.Windows.Forms.NumericUpDown();
            this.saveMmpDialog = new System.Windows.Forms.SaveFileDialog();
            this.openMmpDialog = new System.Windows.Forms.OpenFileDialog();
            this.exportAsmDialog = new System.Windows.Forms.SaveFileDialog();
            this.importAsmDialog = new System.Windows.Forms.OpenFileDialog();
            this.patchRomDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadROM = new System.Windows.Forms.Button();
            this.loadSettings = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destinationIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midwayNum)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(239, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveMidwayPointsAsToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadROMToolStripMenuItem,
            this.patchROMToolStripMenuItem,
            this.toolStripSeparator3,
            this.resetToolStripMenuItem,
            this.toolStripSeparator4,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.saveToolStripMenuItem.Text = "&Save Midway Points";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveMidwayPointsAsToolStripMenuItem
            // 
            this.saveMidwayPointsAsToolStripMenuItem.Name = "saveMidwayPointsAsToolStripMenuItem";
            this.saveMidwayPointsAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveMidwayPointsAsToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.saveMidwayPointsAsToolStripMenuItem.Text = "Save Midway Points as...";
            this.saveMidwayPointsAsToolStripMenuItem.Click += new System.EventHandler(this.saveMidwayPointsAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.openToolStripMenuItem.Text = "&Open Midway Points";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(324, 6);
            // 
            // loadROMToolStripMenuItem
            // 
            this.loadROMToolStripMenuItem.Name = "loadROMToolStripMenuItem";
            this.loadROMToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadROMToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.loadROMToolStripMenuItem.Text = "Load ROM";
            // 
            // patchROMToolStripMenuItem
            // 
            this.patchROMToolStripMenuItem.Name = "patchROMToolStripMenuItem";
            this.patchROMToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.patchROMToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.patchROMToolStripMenuItem.Text = "Patch to ROM";
            this.patchROMToolStripMenuItem.Click += new System.EventHandler(this.patchROMToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(324, 6);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(324, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.destinationIndex);
            this.groupBox1.Controls.Add(this.waterLevel);
            this.groupBox1.Controls.Add(this.secondaryLevel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // destinationIndex
            // 
            this.destinationIndex.Hexadecimal = true;
            this.destinationIndex.Location = new System.Drawing.Point(9, 33);
            this.destinationIndex.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.destinationIndex.Name = "destinationIndex";
            this.destinationIndex.Size = new System.Drawing.Size(200, 20);
            this.destinationIndex.TabIndex = 3;
            this.destinationIndex.ValueChanged += new System.EventHandler(this.destinationIndex_ValueChanged);
            // 
            // waterLevel
            // 
            this.waterLevel.AutoSize = true;
            this.waterLevel.Enabled = false;
            this.waterLevel.Location = new System.Drawing.Point(65, 82);
            this.waterLevel.Name = "waterLevel";
            this.waterLevel.Size = new System.Drawing.Size(84, 17);
            this.waterLevel.TabIndex = 5;
            this.waterLevel.Text = "Water Level";
            this.waterLevel.UseVisualStyleBackColor = true;
            this.waterLevel.CheckedChanged += new System.EventHandler(this.waterLevel_CheckedChanged);
            // 
            // secondaryLevel
            // 
            this.secondaryLevel.AutoSize = true;
            this.secondaryLevel.Location = new System.Drawing.Point(67, 59);
            this.secondaryLevel.Name = "secondaryLevel";
            this.secondaryLevel.Size = new System.Drawing.Size(77, 17);
            this.secondaryLevel.TabIndex = 4;
            this.secondaryLevel.Text = "Secondary";
            this.secondaryLevel.UseVisualStyleBackColor = true;
            this.secondaryLevel.CheckedChanged += new System.EventHandler(this.secondaryLevel_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Destination";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Midway Point";
            // 
            // saveSettings
            // 
            this.saveSettings.Location = new System.Drawing.Point(123, 178);
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Size = new System.Drawing.Size(105, 23);
            this.saveSettings.TabIndex = 7;
            this.saveSettings.Text = "Save Settings";
            this.saveSettings.UseVisualStyleBackColor = true;
            this.saveSettings.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // patchRom
            // 
            this.patchRom.Location = new System.Drawing.Point(123, 207);
            this.patchRom.Name = "patchRom";
            this.patchRom.Size = new System.Drawing.Size(105, 23);
            this.patchRom.TabIndex = 9;
            this.patchRom.Text = "Patch ROM";
            this.patchRom.UseVisualStyleBackColor = true;
            this.patchRom.Click += new System.EventHandler(this.patchRom_Click);
            // 
            // levelNum
            // 
            this.levelNum.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.levelNum.FormattingEnabled = true;
            this.levelNum.Location = new System.Drawing.Point(12, 40);
            this.levelNum.Name = "levelNum";
            this.levelNum.Size = new System.Drawing.Size(105, 21);
            this.levelNum.TabIndex = 1;
            this.levelNum.SelectedIndexChanged += new System.EventHandler(this.levelNum_SelectedIndexChanged);
            // 
            // midwayNum
            // 
            this.midwayNum.Hexadecimal = true;
            this.midwayNum.Location = new System.Drawing.Point(124, 40);
            this.midwayNum.Name = "midwayNum";
            this.midwayNum.Size = new System.Drawing.Size(103, 20);
            this.midwayNum.TabIndex = 2;
            this.midwayNum.ValueChanged += new System.EventHandler(this.midwayNum_ValueChanged);
            // 
            // saveMmpDialog
            // 
            this.saveMmpDialog.DefaultExt = "mmp";
            this.saveMmpDialog.Filter = "Multiple Midway Point Files (.mpp)|*.mmp|Binary Files (.bin)|*.bin|ASM Files|*.as" +
    "m|Text Files|*.txt|All Files|*.*";
            // 
            // openMmpDialog
            // 
            this.openMmpDialog.DefaultExt = "mmp";
            this.openMmpDialog.Filter = "Multiple Midway Point Files (.mpp, .bin)|*.mmp;*.bin|ASM/Text Files (.asm, .txt)|" +
    "*.asm;*.txt|All Files|*.*";
            // 
            // exportAsmDialog
            // 
            this.exportAsmDialog.DefaultExt = "asm";
            this.exportAsmDialog.FileName = "multi_midway_tables.asm";
            this.exportAsmDialog.Filter = "Multiple Midway Point Files (.mpp, .bin)|*.mmp;*.bin|ASM/Text Files (.asm, .txt)|" +
    "*.asm;*.txt|All Files|*.*";
            // 
            // importAsmDialog
            // 
            this.importAsmDialog.DefaultExt = "asm";
            this.importAsmDialog.FileName = "multi_midway_tables.asm";
            this.importAsmDialog.Filter = "65c816 ASM File (.asm)|*.asm|All Files|*.*";
            // 
            // patchRomDialog
            // 
            this.patchRomDialog.Filter = "SNES ROM image (.sfc, .smc)|*.sfc;*smc|All Files|*.*";
            // 
            // loadROM
            // 
            this.loadROM.Location = new System.Drawing.Point(12, 207);
            this.loadROM.Name = "loadROM";
            this.loadROM.Size = new System.Drawing.Size(105, 23);
            this.loadROM.TabIndex = 8;
            this.loadROM.Text = "Load ROM";
            this.loadROM.UseVisualStyleBackColor = true;
            this.loadROM.Click += new System.EventHandler(this.loadROM_Click);
            // 
            // loadSettings
            // 
            this.loadSettings.Location = new System.Drawing.Point(12, 178);
            this.loadSettings.Name = "loadSettings";
            this.loadSettings.Size = new System.Drawing.Size(105, 23);
            this.loadSettings.TabIndex = 6;
            this.loadSettings.Text = "Load Settings";
            this.loadSettings.UseVisualStyleBackColor = true;
            this.loadSettings.Click += new System.EventHandler(this.loadSettings_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 242);
            this.Controls.Add(this.loadROM);
            this.Controls.Add(this.loadSettings);
            this.Controls.Add(this.midwayNum);
            this.Controls.Add(this.levelNum);
            this.Controls.Add(this.patchRom);
            this.Controls.Add(this.saveSettings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "MMP Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destinationIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midwayNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox waterLevel;
        private System.Windows.Forms.CheckBox secondaryLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveSettings;
        private System.Windows.Forms.Button patchRom;
        private System.Windows.Forms.ComboBox levelNum;
        private System.Windows.Forms.NumericUpDown midwayNum;
        private System.Windows.Forms.NumericUpDown destinationIndex;
        private System.Windows.Forms.SaveFileDialog saveMmpDialog;
        private System.Windows.Forms.OpenFileDialog openMmpDialog;
        private System.Windows.Forms.SaveFileDialog exportAsmDialog;
        private System.Windows.Forms.OpenFileDialog importAsmDialog;
        private System.Windows.Forms.OpenFileDialog patchRomDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMidwayPointsAsToolStripMenuItem;
        private System.Windows.Forms.Button loadROM;
        private System.Windows.Forms.Button loadSettings;
        private System.Windows.Forms.ToolStripMenuItem loadROMToolStripMenuItem;
    }
}

