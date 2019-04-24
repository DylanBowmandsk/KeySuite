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
    public partial class AddForm : Form
    {
        public Form1 root { get;}
        public AddForm(Form1 root)
        {
            this.root = root;
            InitializeComponent();
        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            root.Enabled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int response;
            Key key = new Key(cdTextBox.Text,
                productTextBox.Text,
                supplierTextBox.Text,
                distributorTextBox.Text,
                steamUrlTextBox.Text,
                g2aUrlTextBox.Text,
                regionTextBox.Text);
            response = DatabaseUtils.insertEntry(key);
            if (response > 0)
            {
                this.Close();
                DatabaseUtils.fillTable(root.dataGridView1);
            }
            if (response == 0)
                MessageBox.Show("Duplicate key");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
