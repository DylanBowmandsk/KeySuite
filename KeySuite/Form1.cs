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

namespace KeySuite
{
    public partial class Form1 : Form
    {

        public int currentRow = 0;

        public Form1()
        {
            InitializeComponent();
            if (CheckForInternetConnection() == true)
                internetStatusLabel.Text = "Internet Connection: Connected";

            if (DatabaseUtils.fillTable(dataGridView1))
                databaseStatusLabel.Text = "Database Status: Connected";
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentRow = e.RowIndex;

            if (currentRow >= 0)
            {
                string steam_url = dataGridView1.Rows[currentRow].Cells[4].Value.ToString();
                string g2a_url = dataGridView1.Rows[currentRow].Cells[5].Value.ToString();
                string price = PythonUtils.getSteamPrice(steam_url);
                string[] marketData = PythonUtils.getG2aData(g2a_url);

                if(price != "forbidden" && price != "" && steam_url != null)
                    retailValueLabel.Text = price;
                else
                {
                    retailValueLabel.Text = "N/A";
                }

                if(marketData[0] != "forbidden" && marketData[0] != "" && g2a_url != null)
                {

                    keysOnMarketLabel.Text = marketData[0];
                    marketPriceLabel.Text = marketData[1];
                }
                else
                {
                    keysOnMarketLabel.Text = "N/A";
                    marketPriceLabel.Text = "N/A";
                }
            }
        }


        private void addEntryButton_Click(object sender, EventArgs e)
        {
            AddForm addform = new AddForm(this);
            addform.Show();

            this.Enabled = false;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            DatabaseUtils.fillTable(dataGridView1);
        }

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

        private void searchButton_Click(object sender, EventArgs e)
        {
            DatabaseUtils.searchTable(dataGridView1, searchBox.Text, categoryComboBox.Text);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
