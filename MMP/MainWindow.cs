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
        #region Constants
        const string MmpAsm = "multi_midway_tables.asm";
        #endregion

        #region Private Variables
        private Midway[,] midways;

        private int iLevel = 0;
        private int iMidway = 0;

        private string mmpName = null;
        private string romName = null;
        private string directory;

        private bool _unsaved;
        #endregion

        #region Private Fields
        private bool UnsavedChanges
        {
            get
            {
                return _unsaved;
            }
            set
            {
                _unsaved = value;
                Text = "MMP Tool" + (_unsaved ? "*" : "");
            }
        }
        #endregion

        #region Constructor
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

            // Taken straight from Vitor's UberASM code. >_>
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            directory = Environment.CurrentDirectory + "\\";

            UnsavedChanges = false;
        }
        #endregion

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
        /// Removes any unnecessary midway points (see <see cref="Midway.CompressTable(ref Midway[,])"/> for more information) and sets the index to zero.
        /// </summary>
        private void CompressTable()
        {
            // Let's save some freespace!
            Midway.CompressTable(ref midways);

            // Set the midway point index to zero
            iMidway = 0;
            midwayNum.Value = 0;

            // Now update the GUI
            UpdateMidway();
        }
        /// <summary>
        /// Resets the midway point table
        /// </summary>
        private void Reset()
        {
            for (int i = 0; i < 96; i++)
            {
                // Set the first value to the level number...
                midways[i, 0].CalculateMidway(i);
                for (int j = 1; j < 256; j++)
                {
                    // . and clear out the rest
                    midways[i, 0].CalculateMidway(0);
                }
            }
        }
        /// <summary>
        /// Opens up <see cref="saveMmpDialog"/> and saves the midway points either as a binary file or as a text file.
        /// </summary>
        /// <param name="saveAs">If true then force to open <see cref="saveMmpDialog"/></param>
        private void SaveMidwayPoints(bool saveAs = false)
        {
            if (string.IsNullOrEmpty(mmpName) || saveAs)
            {
                if (saveMmpDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                mmpName = saveMmpDialog.FileName;
            }
            string extension = Path.GetExtension(mmpName);
            try
            {
                if (extension == ".asm" || extension == ".txt")
                {
                    SaveAsmTable(mmpName);
                }
                else
                {
                    SaveMmpFile(mmpName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error appeared when saving the midway point file: " + ex.Message, "Couldn't save midway points", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Opens up <see cref="openMmpDialog"/> and saves the midway points either as a binary file or as a text file.
        /// </summary>
        private void LoadMidwayPoints()
        {
            if (UnsavedChanges)
            {
                DialogResult result = MessageBox.Show("Warning, there are unsaved changes! Do you really want to overwrite the changes?", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (result)
                {
                    case DialogResult.Yes:
                        bool unsaved = true;
                        while (unsaved)
                        {
                            try
                            {
                                if (saveMmpDialog.ShowDialog() != DialogResult.OK)
                                {
                                    return;
                                }
                                string extension = Path.GetExtension(mmpName);
                                if (extension == ".asm" || extension == ".txt")
                                {
                                    SaveAsmTable(mmpName);
                                }
                                else
                                {
                                    SaveMmpFile(mmpName);
                                }
                                unsaved = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error appeared when saving the midway point file: " + ex.Message, "Couldn't save midway points", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                            }
                        }
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        return;
                }
            }
            if (openMmpDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    mmpName = openMmpDialog.FileName;
                    string extension = Path.GetExtension(mmpName);
                    if (extension == ".asm" || extension == ".txt")
                    {
                        LoadAsmTable(mmpName);
                    }
                    else
                    {
                        LoadMmpFile(mmpName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error appeared when opening the midway point file: " + ex.Message, "Couldn't save midway points", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
        }
        /// <summary>
        /// Calls a <see cref="SaveFileDialog"/> and saves a .mmp file.
        /// </summary>
        private void SaveMmpFile(string filename)
        {
            try
            {
                File.WriteAllBytes(filename, Midway.ToBinary(midways));
                UnsavedChanges = false;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (IOException)
            {
                throw new IOException("The MMP file couldn't be written. Please check the permission.");
            }
        }
        /// <summary>
        /// Calls an <see cref="OpenFileDialog"/> and opens a .mmp file.
        /// </summary>
        private void LoadMmpFile(string filename)
        {
            try
            {
                midways = Midway.FromBinary(File.ReadAllBytes(filename));
                UpdateMidway();
                UnsavedChanges = false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error appeared when saving the midway point file: " + ex.Message);
            }
        }
        /// <summary>
        /// Calls a <see cref="SaveFileDialog"/> and exports the table as an ASM file.
        /// </summary>
        private void SaveAsmTable(string filename)
        {
            try
            {
                CompressTable();
                Midway.ExportAsm(midways, new FileStream(filename, FileMode.Create));
                UnsavedChanges = false;
                UpdateMidway();

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error appeared when exporting the ASM file: " + ex.Message, "Couldn't export table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("The ASM file couldn't be exported. Please check the permission.", "Couldn't export table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Calls an <see cref="OpenFileDialog"/> and exports the table as an ASM file.
        /// </summary>
        private void LoadAsmTable(string filename)
        {
            try
            {
                midways = Midway.ImportAsm(new FileStream(filename, FileMode.Open));
                UpdateMidway();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error appeared when importing the ASM file: " + ex.Message, "Couldn't import the table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Opens up an <see cref="OpenFileDialog"/> and get the ROM name (it doesn't actually open it).
        /// </summary>
        private void LoadRom()
        {
            if (patchRomDialog.ShowDialog() == DialogResult.OK)
            {
                romName = patchRomDialog.FileName;
            }
            return;
        }
        /// <summary>
        /// Picks a ROM through a <see cref="SaveFileDialog"/> if not specified (or forced) and patch multi_midway.asm.
        /// </summary>
        private void PatchRom(bool saveAs = false)
        {
            try
            {
                // Similar as in ExportAsmTable(): Compress the tables first.
                CompressTable();

                // Now we save the midway points with a fixed name.
                Midway.ExportAsm(midways, new FileStream(directory + MmpAsm, FileMode.Create));
                UnsavedChanges = false;
            }
            catch
            {
                MessageBox.Show("Cannot create multi_midway_table.asm. Please check the file's permission or whether it's already in use.", "Cannot create " + MmpAsm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Asar.init())
            {
                Asar.reset();
                if (string.IsNullOrEmpty(romName) || saveAs)
                {
                    if (patchRomDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    romName = patchRomDialog.FileName;
                }

                try
                {
                    // Remember that Asar expects headerless ROMs.
                    // The code seperates the raw data from the header.
                    byte[] fullRom = File.ReadAllBytes(patchRomDialog.FileName);

                    int lHeader = fullRom.Length & 0x7fff;
                    byte[] header = new byte[lHeader];
                    byte[] rom = new byte[fullRom.Length - lHeader];
                    Array.Copy(fullRom, 0, header, 0, lHeader);
                    Array.Copy(fullRom, lHeader, rom, 0, fullRom.Length - lHeader);

                    // Patching starts...
                    if (Asar.patch(directory + "multi_midway.asm", ref rom))
                    {
                        try
                        {
                            // Now it's time to merge them back.
                            fullRom = new byte[rom.Length + lHeader];
                            Array.Copy(header, 0, fullRom, 0, lHeader);
                            Array.Copy(rom, 0, fullRom, lHeader, rom.Length);

                            File.WriteAllBytes(patchRomDialog.FileName, fullRom);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("An error appeared when patching Multiple Midway Points: " + ex.Message, "ROM couldn't be written", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Asar.close();
                            return;
                        }
                        StringBuilder warningBuilder = new StringBuilder();
                        foreach (var warning in Asar.getwarnings())
                        {
                            warningBuilder.AppendLine(warning.Fullerrdata);
                        }
                        string warnings = warningBuilder.ToString();
                        string fullWarning = !string.IsNullOrEmpty(warnings) ? "The following warnings appeared:\n" + warnings : "";
                        using (LongMessage message = new LongMessage("Multiple Midway Points has been inserted successfully. It uses " + Asar.getprints()[0] + " bytes of freespace.\n" + fullWarning, "Patching successful"))
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
                    MessageBox.Show("An error appeared when patching Multiple Midway Points: " + ex.Message, "ROM couldn't be opened", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    Asar.close();
                }
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
            UnsavedChanges = true;
            UpdateMidway();
        }

        private void midwayNum_ValueChanged(object sender, EventArgs e)
        {
            iMidway = (int)((NumericUpDown)sender).Value;
            UnsavedChanges = true;
            UpdateMidway();
        }
        #endregion

        #region Private functions (form, midway point)
        private void destinationIndex_ValueChanged(object sender, EventArgs e)
        {
            midways[iLevel, iMidway].Destination = (int)((NumericUpDown)sender).Value;
            UnsavedChanges = true;
            UpdateMidway();
        }

        private void secondaryLevel_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;

            midways[iLevel, iMidway].Secondary = secondaryLevel.Checked;
            waterLevel.Enabled = checkBox.Checked;
            destinationIndex.Maximum = secondaryLevel.Checked ? 0x1fff : 0x01ff;
            if (destinationIndex.Value > destinationIndex.Value) destinationIndex.Value = destinationIndex.Maximum;
            UnsavedChanges = true;
            UpdateMidway();
        }

        private void waterLevel_CheckedChanged(object sender, EventArgs e)
        {
            midways[iLevel, iMidway].Water = waterLevel.Checked;
            UnsavedChanges = true;
            UpdateMidway();
        }
        #endregion

        #region Private Functions (form, tool strip)

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMidwayPoints();
        }
        private void saveMidwayPointsAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMidwayPoints(true);
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMidwayPoints();
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

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }
        #endregion

        #region Private Functions (form, buttons)
        private void saveSettings_Click(object sender, EventArgs e)
        {
            SaveMidwayPoints((ModifierKeys & Keys.Shift) == Keys.Shift);
        }

        private void loadSettings_Click(object sender, EventArgs e)
        {
            LoadMidwayPoints();
        }

        private void patchRom_Click(object sender, EventArgs e)
        {
            PatchRom((ModifierKeys & Keys.Shift) == Keys.Shift);
        }
        private void loadROM_Click(object sender, EventArgs e)
        {
            LoadRom();
        }
        #endregion

        #region Private Functions (Special)
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UnsavedChanges)
            {
                DialogResult result = MessageBox.Show("You have got unsaved changes? Would you like to save the midway points first?", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (result)
                {
                    case DialogResult.Yes:
                        bool unsaved = true;
                        while (unsaved)
                        {
                            try
                            {
                                if (saveMmpDialog.ShowDialog() != DialogResult.OK)
                                {
                                    e.Cancel = true;
                                    return;
                                }
                                string fileName = saveMmpDialog.FileName;
                                string extension = Path.GetExtension(fileName);
                                if (extension == ".asm" || extension == ".txt")
                                {
                                    SaveAsmTable(fileName);
                                }
                                else
                                {
                                    SaveMmpFile(fileName);
                                }
                                unsaved = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error appeared when saving the midway point file: " + ex.Message, "Couldn't save midway points", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                            }
                        }
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        e.Cancel = true;
                        return;
                }
            }
        }
        #endregion
    }
}
