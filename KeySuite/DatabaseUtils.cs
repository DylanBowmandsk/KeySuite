using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeySuite
{
    class DatabaseUtils
    {
        private static string connectionString = @"Data Source=localhost;Initial Catalog=KeySuite;Integrated Security=True";

        public static void fillTable(DataGridView gridview)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from keys", sqlcon);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                gridview.DataSource = table;
            }
        }
    }
}
