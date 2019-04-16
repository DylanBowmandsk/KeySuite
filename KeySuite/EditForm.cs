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
        private Key currentKey { get;}

        public EditForm(Form1 root, Key currentKey)
        {
            this.root = root;
            this.currentKey = currentKey;
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            int response = DatabaseUtils.modifyEntry(this,currentKey.cdkey);
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
