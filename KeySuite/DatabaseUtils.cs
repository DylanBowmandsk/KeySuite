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

        public static int insertEntry(AddForm form)
        {
            int response = 0;

            try { 
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO keys VALUES (@cdkey, @product, @supplier, @distributor, @steam_url, @g2a_url, @region)", sqlcon);
                    cmd.Parameters.AddWithValue("@cdkey", form.cdTextBox.Text);
                    cmd.Parameters.AddWithValue("@product", form.productTextBox.Text);
                    cmd.Parameters.AddWithValue("@supplier", form.supplierTextBox.Text);
                    cmd.Parameters.AddWithValue("@distributor", form.distributorTextBox.Text);
                    cmd.Parameters.AddWithValue("@steam_url", form.steamUrlTextBox.Text);
                    cmd.Parameters.AddWithValue("@g2a_url", form.g2aUrlTextBox.Text);
                    cmd.Parameters.AddWithValue("@region", form.regionTextBox.Text);
                    response = cmd.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                response = -1;
            }
            


            return response;
        }

        public static int modifyEntry(EditForm form) {

            int response = 0;

            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Update keys set cdkey = @cdkey, product = @product, supplier = @supplier," +
                    " distributor = @distributor, steam_url = @steam_url, g2a_url = @g2a_url, region = @region WHERE cdkey = @current ", sqlcon);
                cmd.Parameters.AddWithValue("@cdkey", form.cdTextBox.Text);
                cmd.Parameters.AddWithValue("@product", form.productTextBox.Text);
                cmd.Parameters.AddWithValue("@supplier", form.supplierTextBox.Text);
                cmd.Parameters.AddWithValue("@distributor", form.distributorTextBox.Text);
                cmd.Parameters.AddWithValue("@steam_url", form.steamUrlTextBox.Text);
                cmd.Parameters.AddWithValue("@g2a_url", form.g2aUrlTextBox.Text);
                cmd.Parameters.AddWithValue("@region", form.regionTextBox.Text);
                cmd.Parameters.AddWithValue("@current", form.currentKey);
                response = cmd.ExecuteNonQuery();
            }
            return response;
        }
        public static int deleteEntry(string current) 
        {
            int response = 0;

            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("delete from keys where cdkey = @current", sqlcon);
                cmd.Parameters.AddWithValue("@current", current);
                response = cmd.ExecuteNonQuery();
            }
            return response;
        }
    }
}
