using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace MidwayCore
{
    public struct Midway
    {
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
        /// The header of a MMP file.
        /// </summary>
        const string MmpHeader = "MMP";
        /// <summary>
        /// The major version Midway.dll (stored in each .mmp file). Useful to maintain backwards compatibility with old midway point files.
        /// </summary>
        const byte MajorVersion = 1;
        /// <summary>
        /// The minor version of Midway.dll (stored in each .mmp file). Useful to maintain backwards compatibility with old midway point files.
        /// </summary>
        const byte MinorVersion = 0;
        /// <summary>
        /// The bugfix version of Midway.dll (stored in each .mmp file). Useful to maintain backwards compatibility with old midway point files.
        /// </summary>
        const byte BugfixVersion = 1;
        /// <summary>
        /// The total amount of levels in SMW.
        /// </summary>
        const int maxLevels = 96;
        /// <summary>
        /// The total amount of midway points you can have per level.
        /// </summary>
        const int maxMidways = 256;
        #endregion

        #region Constructors
        /// <summary>
        /// Generates a midway point from a hexadecimal string. See <see cref="CalculateMidway(string)"/> for more details.
        /// </summary>
        /// <param name="value">The hexadecimal value as a string.</param>
        public Midway(string value)
        {
            Destination = 0;
            Secondary = false;
            Water = false;

            CalculateMidway(value);
        }
        /// <summary>
        /// Generates a midway point from a hexadecimal string. See <see cref="CalculateMidway(int)"/> for more details.
        /// </summary>
        /// <param name="value">The value as it is inserted in SMW.</param>
        public Midway(int value)
        {
            Destination = 0;
            Secondary = false;
            Water = false;

            CalculateMidway(value);
        }
        /// <summary>
        /// Generates a midway point using a destination, a secondary exit flag and a water level flag
        /// </summary>
        /// <param name="destination">The level or secondary exit the midway point leads to (masked out).</param>
        /// <param name="secondary">Whether the destination</param>
        /// <param name="water">Whether the level is a water level or not. (Only set if <paramref name="secondary"/> is set to true)</param>
        public Midway(int destination, bool secondary, bool water)
        {
            Secondary = secondary;
            Water = water;
            Destination = destination & (secondary ? 0x1fff : 0x01ff);
        }
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
            Destination = value & 0x01FF;
            if (Secondary = Convert.ToBoolean(value & SecondaryFlag))
            {
                Destination = value & 0x1FFF;
                Water = Convert.ToBoolean(value & WaterFlag);
            }
        }
        /// <summary>
        /// Checks whether the midway point is an empty.
        /// </summary>
        /// <returns>Returns true if <see cref="Destination"/> is 0 and <see cref="Secondary"/> and <see cref="Water"/> are false.</returns>
        public bool IsEmpty()
        {
            return (Destination == 0) && !Secondary && !(Water && Secondary);
        }
        /// <summary>
        /// Converts this midway point into a byte array (destination low, destination high, secondary, water).
        /// </summary>
        /// <param name="major">The major version from which the array was read.</param>
        /// <param name="minor">The minor version from which the array was read.</param>
        /// <param name="bugfix">The bugfix version from which the array was read.</param>
        /// <returns>The midway point expressed as a byte array of four bytes</returns>
        public byte[] ConvertToBytes(int major = MajorVersion, int minor = MinorVersion, int bugfix = BugfixVersion)
        {
            byte[] value = new byte[4];
            value[0] = (byte)(Destination >> 0);
            value[1] = (byte)(Destination >> 8);
            value[2] = (byte)(Secondary ? 1 : 0);
            value[3] = (byte)(Water ? 1 : 0);
            return value;
        }
        /// <summary>
        /// Calculates the midway point from a four byte array.
        /// </summary>
        /// <param name="input">The four byte array with the midway point data.</param>
        /// <param name="major">The major version from which the array was read.</param>
        /// <param name="minor">The minor version from which the array was read.</param>
        /// <param name="bugfix">The bugfix version from which the array was read.</param>
        public void ConvertFromBytes(byte[] input, int major = MajorVersion, int minor = MinorVersion, int bugfix = BugfixVersion)
        {
            if (input.Length != 4) throw new ArgumentException("Each midway point takes exactly four bytes.");
            Destination = (input[0] << 0) | (input[1] << 8);
            Secondary = input[2] != 0;
            Water = input[3] != 0 && Secondary;
            Destination &= Secondary ? 0x1fff : 0x01ff;
        }
        /// <summary>
        /// Converts the midway point into a hexadecimal string
        /// </summary>
        /// <returns>Return the value as a string (same format as in Multiple Midway Points).</returns>
        public override string ToString()
        {
            int value = Destination;
            value |= Secondary ? SecondaryFlag : 0;
            value |= Water && Secondary ? WaterFlag : 0;
            return "$" + value.ToString("X4");
        }
        #endregion

        #region Public Static Functions
        /// <summary>
        /// Transforms an array of midway points into an array of bytes (<see cref="ConvertToBytes(int, int, int)"/> for more information).
        /// </summary>
        /// <remarks>The first six bytes are <see cref="MmpHeader"/> and the version numbers (major, minor, bugfix).</remarks>
        /// <param name="midways">The array of the midway points (should be a [<see cref="maxLevels"/>, <see cref="maxMidways"/>] array.</param>
        /// <param name="major_">The major version (for backwards compatibility).</param>
        /// <param name="minor_">The minor version (for backwards compatibility).</param>
        /// <param name="bugfix_">The bugfix version (for backwards compatibility).</param>
        /// <returns>The binary array of midway points</returns>
        public static byte[] ToBinary(Midway[,] midways, byte major_ = MajorVersion, byte minor_ = MinorVersion, byte bugfix_ = BugfixVersion)
        {
            byte[] data;
            byte[] version = new byte[] { major_, minor_, bugfix_ };

            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(Encoding.ASCII.GetBytes(MmpHeader), 0, MmpHeader.Length);
                stream.Write(version, 0, version.Length);

                for (int i = 0; i < maxLevels; i++)
                {
                    for (int j = 0; j < maxMidways; j++)
                    {
                        stream.Write(midways[i, j].ConvertToBytes(), 0, 4);
                    }
                }

                data = stream.ToArray();
            }

            return data;
        }
        /// <summary>
        /// Creates an array of midway points from a byte array.
        /// </summary>
        /// <remarks>Remember that the first six bytes should be <see cref="MmpHeader"/> and the version numbers (major, minor, bugfix)</remarks>
        /// <param name="data">The binary data which contains the midway points.</param>
        /// <param name="major_">The major version (for backwards compatibility).</param>
        /// <param name="minor_">The minor version (for backwards compatibility).</param>
        /// <param name="bugfix_">The bugfix version (for backwards compatibility).</param>
        /// <returns>A [<see cref="maxLevels"/>, <see cref="maxMidways"/>] array of midway points.</returns>
        public static Midway[,] FromBinary(byte[] data, byte major_ = MajorVersion, byte minor_ = MinorVersion, byte bugfix_ = BugfixVersion)
        {
            int iData = 0;
            Midway[,] midways = new Midway[maxLevels, maxMidways];
            byte[] header = new byte[3];
            int major, minor, bugfix;   // Placeholder

            // Header stuff
            Array.Copy(data, iData, header, 0, 3);
            if (Encoding.ASCII.GetString(header) != MmpHeader) throw new ArgumentException("This file is not a proper .mmp file.");
            major = data[3];    //
            minor = data[4];    // Store version number to local variables.
            bugfix = data[5];   //

            iData += 6; // Increment byte index.

            // Loop starts here.
            for (int i = 0; i < maxLevels; i++)
            {
                for (int j = 0; j < maxMidways; j++)
                {
                    // For each midway point, get four bytes 
                    midways[i, j].ConvertFromBytes(data.SubArray(iData, 4));
                    iData += 4;
                }
            }
            return midways;
        }
        /// <summary>
        /// Opens multi_midway_tables.asm and generates an array of midway points.
        /// </summary>
        /// <returns>The 2D midway point table from the ASM file.</returns>
        public static Midway[,] ImportAsm(Stream stream)
        {
            // Generate a maxLevels * maxMidways Midway array.
            Midway[,] midways = new Midway[maxLevels, maxMidways];
            try
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
                    int iLevel = 0;
                    bool containsData;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        containsData = false;

                        int iStart = 0;
                        int iMidway = 0;
                        int commentIndex = line.IndexOf(';');

                        // Ignore comments
                        if (commentIndex >= 0) line = line.Substring(0, commentIndex);
                        // Remove leading spaces and tabs to prevent confusions.
                        char[] charsToTrim = { ' ', '\t' };
                        line = line.Trim(charsToTrim);

                        if (line.Length < 3) continue;  // This includes lines which are less than 3 chars long.
                        if (line.Substring(0, 3) != "dw ") continue; // Now check if the line starts with a "dw " (start of a table).

                        // Let's go!
                        while ((iStart = line.IndexOf('$', iStart)) >= 0)
                        {
                            try
                            {
                                midways[iLevel, iMidway].CalculateMidway(line.Substring(++iStart, 4));
                                containsData = true;
                            }
                            catch (ArgumentException ex)
                            {
                                throw new ArgumentException(ex.Message);
                            }

                            // Increment the index to get the next midway point, increment the starting index.
                            iMidway++;
                            iStart++;
                        }
                        if (containsData)
                        {
                            if (++iLevel > 96)
                            {
                                throw new ArgumentOutOfRangeException("Error: Multi_midway_tables.asm isn't a valid file.");
                            }
                        }
                    }
                    // Before we return, we have to make sure there have been enough levels to read.
                    if (iLevel != 96)
                    {
                        throw new ArgumentOutOfRangeException("Error: Multi_midway_tables.asm isn't a valid file.");
                    }
                }
            }
            catch (IOException ex)
            {
                throw new IOException("Error: Multi_midway_tables.asm couldn't be read: " + ex.Message);
            }
            return midways;
        }
        /// <summary>
        /// Exports the ASM file into a midway point.
        /// </summary>
        /// <param name="midways"></param>
        public static void ExportAsm(Midway[,] midways, Stream stream)
        {
            // Okay, here is the trick: We want to minimise the amount of midway point.
            int maxIndex = 0;   // Required since the value is set in the loop and may not necesserily be set if its skipped.
            for (int i = 0; i < maxLevels; i++)
            {
                int j;  // j is the midway point counter and only named so to be consistent with loop count names.
                for (j = 0; j < 256; j++)
                {
                    if (midways[i, j].IsEmpty()) break; // Only increment the counter until an empty midway point is reached.
                }
                if (maxIndex < j) maxIndex = j;   // Remember: If the loop is broken, the values are still kept as they are.
            }

            if (maxIndex == 0)
            {
                throw new ArgumentException("No midway point has been set.");
            }

            // This is where the file generation starts.
            using (stream)
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    // Header
                    writer.WriteLine("@includefrom multi_midway.asm");
                    writer.WriteLine();
                    writer.WriteLine("!total_midpoints = $" + maxIndex.ToString("X04"));
                    writer.WriteLine();
                    writer.WriteLine("level_mid_tables:");

                    // Generate a line including comments
                    for (int i = 0; i < maxLevels; i++)
                    {
                        StringBuilder line = new StringBuilder();
                        for (int j = 0; j < maxIndex; j++)
                        {
                            line.Append(j == 0 ? "dw " : ", ");   // First row always is a dw.
                            line.Append(midways[i, j]);
                        }
                        line.Append($"\t; Level {(i > 0x24 ? i + 0xdc : i):X}");

                        writer.WriteLine(line.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Removes any unused Midway point (<see cref="IsEmpty"/> for the definition details.).
        /// </summary>
        /// <param name="midwayTable">The table which should be compressed.</param>
        public static void CompressTable(ref Midway[,] midwayTable)
        {
            // Create a new, empty table
            Midway[,] newTable = new Midway[maxLevels, maxMidways];

            // For each level...
            for (int j = 0; j < maxLevels; j++)
            {
                // Index for the new table
                int iNew = 0;

                for (int iOld = 0; iOld < maxMidways; iOld++)
                {
                    // Only copy the old midway point value 
                    if (!midwayTable[j, iOld].IsEmpty()) newTable[j, iNew++] = midwayTable[j, iOld];
                }
            }

            midwayTable = newTable;
        }
        #endregion
    }

    internal static class Helper
    {
        #region Helper Functions
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
        #endregion
    }
}
