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
        public Form1 root { get; }
        public string currentKey { get;}

        public EditForm(Form1 root, string currentKey)
        {
            this.root = root;
            this.currentKey = currentKey;
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            int response = DatabaseUtils.modifyEntry(this);
            if (response > 0)
                DatabaseUtils.fillTable(root.dataGridView1);
            this.Close();
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
