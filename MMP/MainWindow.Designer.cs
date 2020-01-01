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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.patchROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.waterLevel = new System.Windows.Forms.CheckBox();
            this.secondaryLevel = new System.Windows.Forms.CheckBox();
            this.destinationBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveSettings = new System.Windows.Forms.Button();
            this.loadSettings = new System.Windows.Forms.Button();
            this.exportASM = new System.Windows.Forms.Button();
            this.importASM = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.patchRom = new System.Windows.Forms.Button();
            this.levelNum = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator2,
            this.patchROMToolStripMenuItem,
            this.toolStripSeparator3,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.openToolStripMenuItem.Text = "&Open Midway Points";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saveToolStripMenuItem.Text = "&Save Midway Points";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.importToolStripMenuItem.Text = "&Import from ASM File";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.exportToolStripMenuItem.Text = "&Export to ASM File";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // patchROMToolStripMenuItem
            // 
            this.patchROMToolStripMenuItem.Name = "patchROMToolStripMenuItem";
            this.patchROMToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.patchROMToolStripMenuItem.Text = "Patch to ROM";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(185, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.waterLevel);
            this.groupBox1.Controls.Add(this.secondaryLevel);
            this.groupBox1.Controls.Add(this.destinationBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // waterLevel
            // 
            this.waterLevel.AutoSize = true;
            this.waterLevel.Enabled = false;
            this.waterLevel.Location = new System.Drawing.Point(65, 82);
            this.waterLevel.Name = "waterLevel";
            this.waterLevel.Size = new System.Drawing.Size(84, 17);
            this.waterLevel.TabIndex = 2;
            this.waterLevel.Text = "Water Level";
            this.waterLevel.UseVisualStyleBackColor = true;
            // 
            // secondaryLevel
            // 
            this.secondaryLevel.AutoSize = true;
            this.secondaryLevel.Location = new System.Drawing.Point(67, 59);
            this.secondaryLevel.Name = "secondaryLevel";
            this.secondaryLevel.Size = new System.Drawing.Size(77, 17);
            this.secondaryLevel.TabIndex = 1;
            this.secondaryLevel.Text = "Secondary";
            this.secondaryLevel.UseVisualStyleBackColor = true;
            // 
            // destinationBox
            // 
            this.destinationBox.FormattingEnabled = true;
            this.destinationBox.Location = new System.Drawing.Point(6, 32);
            this.destinationBox.Name = "destinationBox";
            this.destinationBox.Size = new System.Drawing.Size(203, 21);
            this.destinationBox.TabIndex = 0;
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
            this.saveSettings.Location = new System.Drawing.Point(12, 178);
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Size = new System.Drawing.Size(105, 23);
            this.saveSettings.TabIndex = 3;
            this.saveSettings.Text = "Save Settings";
            this.saveSettings.UseVisualStyleBackColor = true;
            // 
            // loadSettings
            // 
            this.loadSettings.Location = new System.Drawing.Point(123, 178);
            this.loadSettings.Name = "loadSettings";
            this.loadSettings.Size = new System.Drawing.Size(104, 23);
            this.loadSettings.TabIndex = 3;
            this.loadSettings.Text = "Load Settings";
            this.loadSettings.UseVisualStyleBackColor = true;
            // 
            // exportASM
            // 
            this.exportASM.Location = new System.Drawing.Point(12, 207);
            this.exportASM.Name = "exportASM";
            this.exportASM.Size = new System.Drawing.Size(105, 23);
            this.exportASM.TabIndex = 3;
            this.exportASM.Text = "Export ASM";
            this.exportASM.UseVisualStyleBackColor = true;
            // 
            // importASM
            // 
            this.importASM.Location = new System.Drawing.Point(123, 207);
            this.importASM.Name = "importASM";
            this.importASM.Size = new System.Drawing.Size(105, 23);
            this.importASM.TabIndex = 3;
            this.importASM.Text = "Import ASM";
            this.importASM.UseVisualStyleBackColor = true;
            // 
            // patchRom
            // 
            this.patchRom.Location = new System.Drawing.Point(12, 236);
            this.patchRom.Name = "patchRom";
            this.patchRom.Size = new System.Drawing.Size(105, 23);
            this.patchRom.TabIndex = 3;
            this.patchRom.Text = "Patch ROM";
            this.patchRom.UseVisualStyleBackColor = true;
            // 
            // levelNum
            // 
            this.levelNum.FormattingEnabled = true;
            this.levelNum.Location = new System.Drawing.Point(12, 40);
            this.levelNum.Name = "levelNum";
            this.levelNum.Size = new System.Drawing.Size(105, 21);
            this.levelNum.TabIndex = 4;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(124, 40);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(103, 20);
            this.numericUpDown1.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 271);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.levelNum);
            this.Controls.Add(this.importASM);
            this.Controls.Add(this.patchRom);
            this.Controls.Add(this.exportASM);
            this.Controls.Add(this.loadSettings);
            this.Controls.Add(this.saveSettings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox waterLevel;
        private System.Windows.Forms.CheckBox secondaryLevel;
        private System.Windows.Forms.ComboBox destinationBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveSettings;
        private System.Windows.Forms.Button loadSettings;
        private System.Windows.Forms.Button exportASM;
        private System.Windows.Forms.Button importASM;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button patchRom;
        private System.Windows.Forms.ComboBox levelNum;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

