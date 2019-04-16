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

namespace KeySuite
{
    public partial class Form1 : Form
    {

        public int currentRow = 0;

        public Form1()
        {
            InitializeComponent();
            DatabaseUtils.fillTable(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentRow = e.RowIndex;
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
    }
}
