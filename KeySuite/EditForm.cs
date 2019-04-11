using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeySuite
{
    public partial class EditForm : Form
    {
        Form1 root;

        public EditForm(Form1 root)
        {
            this.root = root;
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            root.Enabled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
