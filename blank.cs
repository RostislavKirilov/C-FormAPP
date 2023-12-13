using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace notepad
{
    public partial class blank : Form

    {
        public string DocName = "";

        private string BufferText = "";

        public bool IsSaved = false;
        public blank()
        {
            InitializeComponent();
            TimeS.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());

            TimeS.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
