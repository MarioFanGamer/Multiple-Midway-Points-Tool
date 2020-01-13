using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMP
{
    public partial class LongMessage : Form
    {
        public LongMessage(string message, string title = null)
        {
            InitializeComponent();

            messageBox.Text = message;
            this.Text = title;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
