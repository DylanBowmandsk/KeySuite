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

            this.cdTextBox.Text = this.currentKey.cdkey;
            this.productTextBox.Text = this.currentKey.product;
            this.supplierTextBox.Text = this.currentKey.supplier;
            this.distributorTextBox.Text = this.currentKey.distributor;
            this.steamUrlTextBox.Text = this.currentKey.steam_url;
            this.g2aUrlTextBox.Text = this.currentKey.g2a_url;
            this.regionTextBox.Text = this.currentKey.region;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (validateInput())
                editEntry();
        }

        private int editEntry()
        {
            Key key = new Key(cdTextBox.Text,
            productTextBox.Text,
            supplierTextBox.Text,
            distributorTextBox.Text,
            steamUrlTextBox.Text,
            g2aUrlTextBox.Text,
            regionTextBox.Text);
            int response = DatabaseUtils.modifyEntry(key, currentKey.cdkey);
            if (response > 0)
            {
                DatabaseUtils.fillTable(root.dataGridView1);
            }
            this.Close();
            return response;
        }

            private bool validateInput()
        {
            if (cdTextBox.Text.Length < 5)
                MessageBox.Show("No CDkey entered");
            else if (productTextBox.Text.Length == 0)
                MessageBox.Show("No product entered");
            else if (supplierTextBox.Text.Length == 0)
                MessageBox.Show("No supplier entered");
            else if (distributorTextBox.Text.Length == 0)
                MessageBox.Show("No distributor entered");
            else if (regionTextBox.Text.Length == 0)
                MessageBox.Show("No region entered");
            else
            {
                return true;
            }
            return false;
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
