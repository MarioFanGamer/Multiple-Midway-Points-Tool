using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsarCLR;
using MidwayCore;
using MMP.Properties;

namespace MMP
{
    public partial class MainWindow : Form
    {
        Midway[,] midways;

        private int iLevel;
        private int iMidway;

        public MainWindow()
        {
            InitializeComponent();

            midways = new Midway[96, 256];

            // Create a DataTable which contains the level numbers and its values.
            DataTable levels = new DataTable();

            levels.Columns.Add("Display", typeof(string));
            levels.Columns.Add("Value", typeof(int));

            for (int i = 0; i < 96; i++)
            {
                DataRow row = levels.NewRow();

                int levelIndex = (i > 0x24 ? i + 0xDC : i);

                row["Display"] = "Level " + levelIndex.ToString("X");   // If bigger than 24, it's a submap translevel.
                row["Value"] = i;

                levels.Rows.Add(row);

                midways[i, 0].Destination = levelIndex;
            }

            levelNum.DisplayMember = "Display";
            levelNum.ValueMember = "Value";
            levelNum.DataSource = levels;

            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        #region Private functions (non-form)
        /// <summary>
        /// If the value is update in any way (level index changed, midway points loaded, etc.), update the widgets for the current midway point.
        /// <remarks>Keep in mind that the indeces are set in <see cref="iLevel"/> and <see cref="iMidway"/>.</remarks>
        /// </summary>
        private void UpdateMidway()
        {
            // I know this copies the midway point (it's a struct and not a class) but hey, it's more clear this way.
            Midway currentMidway = midways[iLevel, iMidway];

            destinationIndex.Value = currentMidway.Destination;
            secondaryLevel.Checked = currentMidway.Secondary;
            waterLevel.Checked = currentMidway.Water;
        }
        /// <summary>
        /// Calls a <see cref="SaveFileDialog"/> and saves a .mmp file.
        /// </summary>
        private void SaveMidwayPoints()
        {
            try
            {
                if (saveMmpDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveMmpDialog.FileName, Midway.ToBinary(midways));
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error appeared when opening the midway point file: " + ex.Message);
            }
        }
        /// <summary>
        /// Calls an <see cref="OpenFileDialog"/> and saves a .mmp file.
        /// </summary>
        private void LoadMidwayPoints()
        {
            try
            {
                if (openMmpDialog.ShowDialog() == DialogResult.OK)
                {
                    midways = Midway.FromBinary(File.ReadAllBytes(openMmpDialog.FileName));
                    UpdateMidway();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error appeared when saving the midway point file: " + ex.Message);
            }
            finally
            {
                UpdateMidway();
            }
        }
        /// <summary>
        /// Calls an <see cref="SaveFileDialog"/> and exports the table as an ASM file.
        /// </summary>
        private void ExportAsmTable()
        {
            try
            {
                // Let's save some freespace!
                Midway.CompressTable(ref midways);
                UpdateMidway();

                // Set the midway point index to zero
                iMidway = 0;
                midwayNum.Value = 0;

                // Now we save the midway points
                if (exportAsmDialog.ShowDialog() == DialogResult.OK)
                {
                    Midway.ExportAsm(midways, exportAsmDialog.OpenFile());
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error appeared when exporting the ASM file: " + ex.Message);
            }
        }
        /// <summary>
        /// Calls an <see cref="OpenFileDialog"/> and exports the table as an ASM file.
        /// </summary>
        private void ImportAsmTable()
        {
            try
            {
                if (importAsmDialog.ShowDialog() == DialogResult.OK)
                {
                    midways = Midway.ImportAsm(importAsmDialog.OpenFile());
                    UpdateMidway();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error appeared when importing the ASM file: " + ex.Message);
            }
        }
        /// <summary>
        /// Picks a ROM through an <see cref="OpenFileDialog"/> and patch multi_midway.asm.
        /// </summary>
        private void PatchRom()
        {
            if (Asar.init())
            {
                if (patchRomDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] rom = File.ReadAllBytes(patchRomDialog.FileName);

                        if (Asar.patch("multi_midway.asm", ref rom))
                        {
                            try
                            {
                                File.WriteAllBytes(patchRomDialog.FileName, rom);
                            }
                            catch (IOException ex)
                            {
                                MessageBox.Show("An error appeared when patching Multiple Midway Points: " + ex, "ROM couldn't be written", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Asar.close();
                                return;
                            }
                            StringBuilder warnings = new StringBuilder();
                            foreach (var warning in Asar.getwarnings())
                            {
                                warnings.AppendLine(warning.Fullerrdata);
                            }
                            using (LongMessage message = new LongMessage("Multiple Midway Points has been inserted successfully. It uses " + Asar.getprints()[0] + " bytes of freespace.\nThe following warnings appeared:\n" + warnings.ToString(), "Patching successful"))
                            {
                                message.ShowDialog(this);
                            }
                        }
                        else
                        {
                            MessageBox.Show("An error appeared when patching Multiple Midway Points. See mmp.log for more information.", "ROM couldn't be patched", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            using (FileStream stream = new FileStream("mmp.log", FileMode.Create))
                            {
                                using (StreamWriter writer = new StreamWriter(stream))
                                {
                                    foreach (var warning in Asar.getwarnings())
                                    {
                                        writer.WriteLine(warning.Fullerrdata);
                                    }
                                    foreach (var error in Asar.geterrors())
                                    {
                                        writer.WriteLine(error.Fullerrdata);
                                    }
                                }
                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("An error appeared when patching Multiple Midway Points: " + ex, "ROM couldn't be opened", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                Asar.close();
            }
            else
            {
                MessageBox.Show("Asar couldn't be started. (Perhaps asar.dll is missing or a wrong version is used?)", "Couldn't open Asar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Private functions (form, indices)
        private void levelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            midwayNum.Value = 0;
            iLevel = (int)levelNum.SelectedValue;
            iMidway = 0;
            UpdateMidway();
        }

        private void midwayNum_ValueChanged(object sender, EventArgs e)
        {
            iMidway = (int)((NumericUpDown)sender).Value;
            UpdateMidway();
        }
        #endregion

        #region Private functions (form, midway point)
        private void destinationIndex_ValueChanged(object sender, EventArgs e)
        {
            midways[iLevel, iMidway].Destination = (int)((NumericUpDown)sender).Value;
            UpdateMidway();
        }

        private void secondaryLevel_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;

            midways[iLevel, iMidway].Secondary = secondaryLevel.Checked;
            waterLevel.Enabled = checkBox.Checked;
            destinationIndex.Maximum = secondaryLevel.Checked ? 0x1fff : 0x01ff;
            if (destinationIndex.Value > destinationIndex.Value) destinationIndex.Value = destinationIndex.Maximum;
        }

        private void waterLevel_CheckedChanged(object sender, EventArgs e)
        {
            midways[iLevel, iMidway].Water = waterLevel.Checked;
        }
        #endregion

        #region Private Functions (form, tool strip)
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMidwayPoints();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMidwayPoints();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportAsmTable();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportAsmTable();
        }

        private void patchROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatchRom();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LongMessage message = new LongMessage(Resources.About, "About this Software"))
            {
                message.ShowDialog(this);
            }
        }
        #endregion

        #region Private Functions (form, buttons)
        private void saveSettings_Click(object sender, EventArgs e)
        {
            SaveMidwayPoints();
        }

        private void loadSettings_Click(object sender, EventArgs e)
        {
            LoadMidwayPoints();
        }

        private void exportASM_Click(object sender, EventArgs e)
        {
            ExportAsmTable();
        }

        private void importASM_Click(object sender, EventArgs e)
        {
            ImportAsmTable();
        }

        private void patchRom_Click(object sender, EventArgs e)
        {
            PatchRom();
        }
        #endregion
    }
}
