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

        /// only getters are required here as setting the values mid edit could cause destructive edits
        private MainForm root { get; }
        private Key currentKey { get;}
        
        ///<summary>
        /// constructor for EditForm
        /// initialises the EditForm inputs with data from the data table
        ///</summary>
        /// <param name="root">The preceeding calling form</param>
        /// <param name="=currentKey">the key from the table that is being editted</param>
        public EditForm(MainForm root, Key currentKey)
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

        /// <summary>
        /// if validateInput method returns true editEntry is called
        /// </summary>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (validateInput())
                editEntry();
        }

        /// <summary>
        /// creates a key object to be pushed to the DataUtils.modifyEntry method
        /// refreshes table if successfull and closes current window
        /// flashes error message if response is zero displaying that the key is a duplicate
        /// </summary>
        /// <returns>
        /// the amount of indexes affected
        /// </returns>
        private int editEntry()
        {
            //instance of Key class generated
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
                this.Close();
                return response;
            }
            else if (response == 0)
            {
                MessageBox.Show("Duplicate key");
                return response;
            }
            return response;
        }

        /// <summary>
        /// validates the forms inputs 
        /// </summary>
        /// <returns>
        /// true if valid
        /// flase if not valid
        /// </returns>
        private bool validateInput()
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
        /// re-enables use of the calling window when the EditForm is closed
        /// </summary>
        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            root.Enabled = true;
        }

        /// <summary>
        /// Cancels operation and closes the EditForm
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
