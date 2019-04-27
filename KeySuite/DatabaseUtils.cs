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
        private static  string connectionString = @"Data Source=localhost;Initial Catalog=KeySuite;Integrated Security=True";

        public static bool fillTable(DataGridView gridView)
        {
            try { 
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from keys", sqlcon);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    gridView.DataSource = table;
                    return true;
                }
            }
            catch(DataException e)
            {
                return false;
            }
        }

        public static void searchTable(DataGridView gridView,string searchTerm,string category)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"select * from keys where {category} like '%{searchTerm}%'", sqlcon);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                gridView.DataSource = table;
            }
        }

        public static int insertEntry(Key key)
        {
            int response;

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO keys VALUES (@cdkey, @product, @supplier, @distributor, @steam_url, @g2a_url, @region)", sqlcon);
                    cmd.Parameters.AddWithValue("@cdkey", key.cdkey);
                    cmd.Parameters.AddWithValue("@product", key.product);
                    cmd.Parameters.AddWithValue("@supplier", key.supplier);
                    cmd.Parameters.AddWithValue("@distributor", key.distributor);
                    cmd.Parameters.AddWithValue("@steam_url", key.steam_url);
                    cmd.Parameters.AddWithValue("@g2a_url", key.g2a_url);
                    cmd.Parameters.AddWithValue("@region", key.region);
                    response = cmd.ExecuteNonQuery();
                }
            }
            catch(DataException e)
            {
                response = 0;
            }
            
            return response;
        }

        public static int modifyEntry(Key key, string currentKey) {

            int response;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("Update keys set cdkey = @cdkey, product = @product, supplier = @supplier," +
                        " distributor = @distributor, steam_url = @steam_url, g2a_url = @g2a_url, region = @region WHERE cdkey = @current ", sqlcon);
                    cmd.Parameters.AddWithValue("@cdkey", key.cdkey);
                    cmd.Parameters.AddWithValue("@product", key.product);
                    cmd.Parameters.AddWithValue("@supplier", key.supplier);
                    cmd.Parameters.AddWithValue("@distributor", key.distributor);
                    cmd.Parameters.AddWithValue("@steam_url", key.steam_url);
                    cmd.Parameters.AddWithValue("@g2a_url", key.g2a_url);
                    cmd.Parameters.AddWithValue("@region", key.region);
                    cmd.Parameters.AddWithValue("@current", currentKey);
                    response = cmd.ExecuteNonQuery();
                }
            }
            catch(DataException e)
            {
                response = 0;
            }

            return response;
        }
        public static int deleteEntry(string current) 
        {
            int response;

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("delete from keys where cdkey = @current", sqlcon);
                    cmd.Parameters.AddWithValue("@current", current);
                    response = cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                response = 0;
            }
            return response;
        }
    }
}
