using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Runtime;
using IronPython.Hosting;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;

namespace KeySuite
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// keeps track of the current row active
        /// </summary>
        public int currentRow = 0;

        /// <summary>
        /// constructor for MainForm
        /// checks for internet connection and updates status bar
        /// fills datagridview with database rows and updates status bar
        /// disables buttons of database is not connected
        /// sets the default of the combobox selector
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            if (CheckForInternetConnection() == true)
                internetStatusLabel.Text = "Internet Connection: Connected\t";
            if (DatabaseUtils.fillTable(dataGridView1))
                databaseStatusLabel.Text = "Database Status: Connected\t";
            else
            {
                searchBox.Enabled = false;
                searchButton.Enabled = false;
                addEntryButton.Enabled = false;
                editButton.Enabled = false;
                refreshButton.Enabled = false;
                deleteButton.Enabled = false;
                MessageBox.Show("No database connection\nRead manual and make sure settings are configured properly");
            }

            categoryComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// when a cell is clicked data is extracted from the table
        /// data is forwarded to python script methods to be webscraped
        /// markdown percentage is generated
        /// UI is updated in turn
        /// </summary>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentRow = e.RowIndex;

            if (currentRow >= 0)
            {
                //urls for webscraping
                string steam_url = dataGridView1.Rows[currentRow].Cells[4].Value.ToString();
                string g2a_url = dataGridView1.Rows[currentRow].Cells[5].Value.ToString();

                //initiators for running python scripts
                string steamPrice = PythonUtils.getSteamPrice(steam_url);
                string g2aKeys = PythonUtils.getG2aKeysData(g2a_url);
                string g2aPrice = PythonUtils.getG2aPrice(g2a_url);

                //format strings
                removeEscapes(ref steamPrice);
                removeEscapes(ref g2aKeys);
                removeEscapes(ref g2aPrice);

                //generate markdown percentage
                getMarkdown(steamPrice, g2aPrice);

                //sets values on UI
                setSteamValue(steamPrice);
                setG2aKeys(g2aKeys);
                setG2aPrice(g2aPrice);
            }
        }

        /// <summary>
        /// converts string to decimal format
        /// updates ui to reflect results
        /// </summary>
        /// <param name="steamPrice"></param>
        /// <param name="g2aPrice"></param>
        private void getMarkdown(string steamPrice, string g2aPrice)
        {
            if(Double.TryParse(steamPrice, out double steamDouble) &&
                Double.TryParse(g2aPrice, out double g2aDouble))
            {
                double result = g2aDouble / steamDouble;
                if (result < 0)
                    markdownLabel.Text = result.ToString();
            }
        }

        /// <summary>
        /// removes excapes from string
        /// </summary>
        /// <param name="input">returns non escaped string</param>
        private void removeEscapes(ref string input)
        {
            input = input.Replace("\r\n", "");
            input = input.Replace("£","");
        }

        /// <summary>
        /// validates g2aPrice and sets label for g2aPrice
        /// </summary>
        /// <param name="g2aPrice"></param>
        private void setG2aPrice(string g2aPrice)
        {
            if (g2aPrice != "")
                marketPriceLabel.Text = g2aPrice;
            else
                marketPriceLabel.Text = "N/A";
        }   

        /// <summary>
        /// validates g2aKeys and sets label for g2aKeys
        /// </summary>
        /// <param name="g2aKeys"></param>
        private void setG2aKeys(string g2aKeys)
        {
            if (g2aKeys != "")
                keysOnMarketLabel.Text = g2aKeys;
            else
                keysOnMarketLabel.Text = "N/A";
        }

        /// <summary>
        /// validates steamPrice and sets label for steamPrice
        /// </summary>
        /// <param name="steamPrice"></param>
        private void setSteamValue(string steamPrice)
        {
            if (steamPrice != "forbidden" && steamPrice != "")
                retailValueLabel.Text = steamPrice;
            else
            {
                retailValueLabel.Text = "N/A";
            }
        }

        /// <summary>
        /// generates an AddForm
        /// disables main form
        /// </summary>
        private void addEntryButton_Click(object sender, EventArgs e)
        {
            AddForm addform = new AddForm(this);
            addform.Show();

            this.Enabled = false;
        }

        /// <summary>
        ///  refreshes the dataviewtable with current rows
        /// </summary>
        private void refreshButton_Click(object sender, EventArgs e)
        {
            DatabaseUtils.fillTable(dataGridView1);
        }

        /// <summary>
        /// takes data from the dataviewtable
        /// uses data to create a key object
        /// creates EditForm with key as a parameter
        /// disables current
        /// </summary>
        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("No entries available");
            }
            else
            { 
                string currentKey = dataGridView1.Rows[currentRow].Cells[0].Value.ToString();
                string product = dataGridView1.Rows[currentRow].Cells[1].Value.ToString();
                string supplier = dataGridView1.Rows[currentRow].Cells[2].Value.ToString();
                string distributor = dataGridView1.Rows[currentRow].Cells[3].Value.ToString();
                string steam_url = dataGridView1.Rows[currentRow].Cells[4].Value.ToString();
                string g2a_url = dataGridView1.Rows[currentRow].Cells[5].Value.ToString();
                string region = dataGridView1.Rows[currentRow].Cells[6].Value.ToString();

                EditForm editForm = new EditForm(this, new Key(currentKey,
                    product,
                    supplier,
                    distributor,
                    steam_url,
                    g2a_url,
                    region));
                editForm.Show();

                this.Enabled = false;
                
            }
        }

        /// <summary>
        /// if there is no currently selected cell displays error
        /// if not deletes a current key selected from database
        /// </summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("No entries available");
            }
            else
            {
                string currentKey = dataGridView1.Rows[currentRow].Cells[0].Value.ToString();

                DatabaseUtils.deleteEntry(currentKey);
                DatabaseUtils.fillTable(dataGridView1);

                currentRow = 0;
            }

        }

        /// <summary>
        /// uses the combo box to select category
        /// searches database using the searchbox
        /// </summary>
        private void searchButton_Click(object sender, EventArgs e)
        {
            DatabaseUtils.searchTable(dataGridView1, searchBox.Text, categoryComboBox.Text);
        }

        /// <summary>
        /// has same functionality as clicking edit button/
        /// </summary>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(currentRow > 0) { 
                string currentKey = dataGridView1.Rows[currentRow].Cells[0].Value.ToString();
                string product = dataGridView1.Rows[currentRow].Cells[1].Value.ToString();
                string supplier = dataGridView1.Rows[currentRow].Cells[2].Value.ToString();
                string distributor = dataGridView1.Rows[currentRow].Cells[3].Value.ToString();
                string steam_url = dataGridView1.Rows[currentRow].Cells[4].Value.ToString();
                string g2a_url = dataGridView1.Rows[currentRow].Cells[5].Value.ToString();
                string region = dataGridView1.Rows[currentRow].Cells[6].Value.ToString();

                EditForm editForm = new EditForm(this, new Key(currentKey,
                    product,
                    supplier,
                    distributor,
                    steam_url,
                    g2a_url,
                    region));
                editForm.Show();

                this.Enabled = false;
            }
        }

        /// <summary>
        /// checks the network for a 200 response from google
        /// </summary>
        /// <returns>
        /// true if connected
        /// flse if not
        /// </returns>
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
