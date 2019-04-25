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
            if (validateInput())
                addEntry();
        }

        private Boolean validateInput()
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

        private int addEntry()
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
            if (response == 0)
            {
                MessageBox.Show("Duplicate key");
                return response;
            }
            else
            {
                this.Close();
                DatabaseUtils.fillTable(root.dataGridView1);
                return response;
            }
            
        }
    }
}
