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

        /// only get is available within the class for the calling form
        private MainForm root { get;}

        /// <summary>
        /// constructor for AddForm class
        /// </summary>
        /// <param name="root">the preceeding calling form</param>
        public AddForm(MainForm root)
        {
            this.root = root;
            InitializeComponent();
        }


        /// <summary>
        /// if validateInput method returns true editEntry is called
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            if (validateInput())
                addEntry();
        }

        /// <summary>
        /// creates a key object to be pushed to the DataUtils.addEntry method
        /// refreshes table if successfull and closes current window
        /// flashes error message if response is zero displaying that the key is a duplicate
        /// </summary>
        private int addEntry()
        {
            //instance of Key class generated
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

        /// <summary>
        /// validates the forms inputs 
        /// </summary>
        /// <returns>
        /// true if valid
        /// flase if not valid
        /// </returns>
        private Boolean validateInput()
        {
            if (cdTextBox.Text.Length < 5)
                MessageBox.Show("No CD key too short");
            else if (cdTextBox.Text.Length >= 50)
                MessageBox.Show("CD key too long");
            else if (productTextBox.Text.Length == 0)
                MessageBox.Show("No product entered");
            else if (productTextBox.Text.Length >= 50)
                MessageBox.Show("Product name entered too long");
            else if (supplierTextBox.Text.Length == 0)
                MessageBox.Show("No supplier entered");
            else if (supplierTextBox.Text.Length >= 50)
                MessageBox.Show("Supplier name entered too long");
            else if (distributorTextBox.Text.Length == 0)
                MessageBox.Show("No distributor entered");
            else if (distributorTextBox.Text.Length >= 50)
                MessageBox.Show("Distributor entered too long");
            else if (distributorTextBox.Text.Length >= 200)
                MessageBox.Show("Steam url too long");
            else if (g2aUrlTextBox.Text.Length >= 200)
                MessageBox.Show("G2A url too long");
            else if (regionTextBox.Text.Length == 0)
                MessageBox.Show("No region entered");
            else if (regionTextBox.Text.Length >= 50)
                MessageBox.Show("Region entered too long");
            else
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// re-enables use of the calling window when the AddForm is closed
        /// </summary>
        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            root.Enabled = true;
        }

        /// <summary>
        /// Cancels operation and closes the AddForm
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
