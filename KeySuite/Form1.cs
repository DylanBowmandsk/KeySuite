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
        string connectionString = @"Data Source=localhost;Initial Catalog=KeySuite;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            using(SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from keys", sqlcon);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm addform = new AddForm(this);
            addform.Show();
            this.Hide();
        }

    }
}
