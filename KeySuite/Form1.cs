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

        public int currentRow = -1;

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
            if (currentRow >= 0)
            {
                string currentKey = dataGridView1.Rows[currentRow].Cells[0].Value.ToString();
                MessageBox.Show(currentKey);
                EditForm addform = new EditForm(this, currentKey);
                addform.Show();
                this.Enabled = false;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (currentRow > -1)
            {
                string currentKey = dataGridView1.Rows[currentRow].Cells[0].Value.ToString();
                DatabaseUtils.deleteEntry(currentKey);
                DatabaseUtils.fillTable(dataGridView1);
            }
            else
            {
                MessageBox.Show("Please select an entry to delete");
            }
        }
    }
}
