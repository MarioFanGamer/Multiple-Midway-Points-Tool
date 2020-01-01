using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace MidwayCore
{
    public class Midway
    {
        #region Constructors
        /// <summary>
        /// Generates an empty midway point (destination = level 000).
        /// </summary>
        public Midway()
        {
            Destination = 0;
            Secondary = false;
            Water = false;
        }
        /// <summary>
        /// Generates a midway point from a hexadecimal string. See <see cref="CalculateMidway(string)"/> for more details.
        /// </summary>
        /// <param name="value">The hexadecimal value as a string.</param>
        public Midway(string value)
        {
            CalculateMidway(value);
        }
        /// <summary>
        /// Generates a midway point from a hexadecimal string. See <see cref="CalculateMidway(int)"/> for more details.
        /// </summary>
        /// <param name="value">The value as it is inserted in SMW.</param>
        public Midway(int value)
        {
            CalculateMidway(value);
        }
        /// <summary>
        /// Generates a midway point
        /// </summary>
        /// <param name="destination">The level or secondary exit the midway point leads to (masked out).</param>
        /// <param name="secondary">Whether the destination</param>
        /// <param name="water">Whether the level is a water level or not. (Only set if <paramref name="secondary"/> is set to true)</param>
        public Midway(int destination, bool secondary, bool water)
        {
            Secondary = secondary;
            Water = secondary ? water : false; // Only set water level if secondary is active.
            Destination = destination & (secondary ? 0x1fff : 0x01ff);
        }
        #endregion

        #region Constants
        /// <summary>
        /// The bit which enables secondary exits
        /// </summary>
        const int SecondaryFlag = 0x8000;
        /// <summary>
        /// The big which enables water levels;
        /// </summary>
        const int WaterFlag = 0x4000;
        /// <summary>
        /// The total amount of levels in SMW.
        /// </summary>
        const int maxLevels = 95;
        /// <summary>
        /// The total amount of midway points you can have per level.
        /// </summary>
        const int maxMidways = 256;
        #endregion

        #region Public Fields
        /// <summary>
        /// The destination which is either the level number (up to 0x1FF) or the secondary exit index (up to 0x1FFF).
        /// </summary>
        public int Destination { get; set; }
        /// <summary>
        /// Whether the destination is a level or secondary exit
        /// </summary>
        public bool Secondary { get; set; }
        /// <summary>
        /// Whether the level is a water level or not.
        /// </summary>
        /// <remarks>This is only enabled with a secondary exit.</remarks>
        public bool Water { get; set; }
        #endregion

        #region Public Functions
        /// <summary>
        /// Sets the midway point properties with a string.
        /// </summary>
        /// <remarks>Only allows hexadeximal values, sorry. :(</remarks>
        /// <param name="value">The hexadecimal value as a string.</param>
        public void CalculateMidway(string value)
        {
            try
            {
                CalculateMidway(Int32.Parse(value, NumberStyles.HexNumber, CultureInfo.CurrentCulture));
            }
            catch (FormatException)
            {
                throw new ArgumentException("The string contains invalid characters.");
            }
        }
        /// <summary>
        /// Sets the value of the string with a given number. Uses the rules from Multiple Midway Points.
        /// </summary>
        /// <remarks>
        /// Bits 0 to 8 are the destination (up to bit 12 if secondary),
        /// bit 15 is the secondary flag and,
        /// if secondary active, bit 14 the water level flag.
        /// </remarks>
        /// <param name="value">The value as it is inserted in SMW.</param>
        public void CalculateMidway(int value)
        {
            Destination &= 0x01FF;
            if (Secondary = Convert.ToBoolean(value & SecondaryFlag))
            {
                Destination = value & 0x1FFF;
                Water = Convert.ToBoolean(value & WaterFlag);
            }
        }
        public void CopyMidway(Midway old)
        {
            this.Destination = old.Destination;
            this.Secondary = old.Secondary;
            this.Water = old.Water;
        }
        /// <summary>
        /// Checks whether the midway point is an empty.
        /// </summary>
        /// <returns>Returns true if <see cref="Destination"/> is 0 and <see cref="Secondary"/> and <see cref="Water"/> are false.</returns>
        public bool IsEmpty()
        {
            return (Destination == 0) || !Secondary || !Water;
        }
        /// <summary>
        /// Converts the midway point into a hexadecimal
        /// </summary>
        /// <returns>Return the value as a string (same format as in Multiple Midway Points).</returns>
        public override string ToString()
        {
            int value = Destination;
            value |= Secondary ? SecondaryFlag : 0;
            value |= Water ? WaterFlag : 0;
            return "$" + string.Format("04X", value & 0xffff);
        }
        #endregion

        #region Public Static Functions
        /// <summary>
        /// Opens multi_midway_tables.asm and generates.
        /// </summary>
        /// <returns>The 2D midway point table from the ASM file.</returns>
        public static Midway[,] ImportAsm()
        {
            // Generate a maxLevels * maxMidways Midway array.
            Midway[,] midways = new Midway[maxLevels, maxMidways];
            try
            {
                using (FileStream stream = new FileStream("multi_midway_tables.asm", FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        // The difficult part is to read the arrays.
                        // Remember there is a variable amount of lines in table.
                        // The trick is to only read lines which have got a '$' in it
                        // In order to verify the file, it needs to have the following conditions:
                        // - There are 96 different rows with data for 96 levels
                        // - Each table is a 16-bit table.
                        // Failing any of the conditions means: It's not a valid file.
                        // There is no checks for the length.
                        int level = 0;
                        int index = 0;
                        bool containsData;
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            containsData = false;

                            int startIndex = 0;
                            int commentIndex = line.IndexOf(';');

                            // Ignore comments
                            if (commentIndex >= 0) line = line.Substring(0, commentIndex);

                            while ((startIndex = line.IndexOf('$', startIndex)) >= 0)
                            {
                                try
                                {
                                    midways[level, index].CalculateMidway(line.Substring(startIndex++, 4));
                                    containsData = true;
                                }
                                catch (ArgumentException ex)
                                {
                                    throw new ArgumentException(ex.Message);
                                }

                                // Increment the index to get the next midway point, increment the starting index.
                                index++;
                                startIndex++;
                            }
                            if (containsData)
                            {
                                if (++level > 96)
                                {
                                    throw new ArgumentOutOfRangeException("It seems like multi_midway_tables.asm isn't a valid file.");
                                }
                            }
                        }
                        // Before we return, we have to make sure there have been enough levels to read.
                        if (level != 96)
                        {
                            throw new ArgumentOutOfRangeException("It seems like multi_midway_tables.asm isn't a valid file.");
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                throw new IOException("It seems like multi_midway_tables.asm couldn't be read: " + ex.Message);
            }
            return midways;
        }

        public static void ExportAsm(Midway[,] midways)
        {
            // Okay, here is the trick: We want to minimise the amount of midway point.
            int maxIndex = 0;   // Required since the value is set in the loop and may not necesserily be set if its skipped.
            for (int i = 0; i < maxLevels; i++)
            {
                int j;  // j is the midway point counter and only named so to be consistent with loop count names.
                for (j = 0; i < 256; j++)
                {
                    if (midways[i, j].IsEmpty()) break; // Only increment the counter until an empty midway point is reached.
                }
                maxIndex = j;   // Remember: If the loop is broken, the values are still kept as they are.
            }

            // This is where the file generation starts.
            using (FileStream stream = new FileStream("multi_midway_tables.asm", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    // Header
                    writer.WriteLine("@includefrom multi_midway.asm");
                    writer.WriteLine("!total_midpoints = $" + string.Format("04X", maxIndex));
                    writer.WriteLine();

                    // Generate a line including comments
                    for (int i = 0; i < maxLevels; i++)
                    {
                        StringBuilder line = new StringBuilder();
                        for (int j = 0; i < maxIndex; j++)
                        {
                            line.Append(j == 0 ? "dw $" : ", $");   // First row always is a dw.
                            line.Append(midways[i, j]);
                        }
                        line.Append("\t; Level ");
                        line.Append(string.Format("X", i > 0x24 ? i - 0xdc : i));

                        writer.WriteLine(line.ToString());
                    }
                }
            }
        }

        public static void CompressTable(ref Midway[,] oldTable)
        {
            // Create a new, empty table
            Midway[,] newTable = new Midway[maxLevels, maxMidways];

            // For each level...
            for(int j = 0; j < maxLevels; j++)
            {
                // Index for the new table
                int iNew = 0;

                for(int iOld = 0; iOld < maxMidways; iOld++)
                {
                    // Only copy the old midway point value 
                    if(!oldTable[j, iOld].IsEmpty()) newTable[j, iNew++].CopyMidway(oldTable[j, iOld]);
                }
            }

            oldTable = newTable;
        }
        #endregion
    }
}
