using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MidwayCore;

namespace MMP
{
    public partial class MainWindow : Form
    {
        Midway[,] midways;

        DataTable levels;

        private int iLevel;
        private int iMidway;

        public MainWindow()
        {
            InitializeComponent();

            midways = new Midway[96, 256];

            levels.Columns.Add("Display", typeof(int));
            levels.Columns.Add("Value", typeof(int));

            for(int i = 0; i < 96; i++)
            {
                DataRow row = levels.NewRow();

                row["Display"] = i > 24 ? i - 0xDC : i;
                row["Value"] = i;
            }
        }
    }
}
