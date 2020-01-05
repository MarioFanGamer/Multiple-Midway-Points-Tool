using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMP
{
    static class Program
    {
        private static string[] dependencies = new string[]
        {
            "Midway.dll"
        };

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Check for every non-asar.dll DLL (well, the only one).
            foreach (string dependency in dependencies)
            {
                if (!File.Exists(dependency))
                {
                    MessageBox.Show("Error: " + dependency + "is missing. Please check if the DLL is put in the same folder as this program.", "Missing DLL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
