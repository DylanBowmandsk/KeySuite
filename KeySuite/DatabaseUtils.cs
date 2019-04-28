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
    public static class DatabaseUtils
    {
        /// <summary>
        /// the main string used to connect to the database
        /// for info on connection strings see https://www.connectionstrings.com/sql-server/
        /// for example for this one to work the user must have a sqlserver
        /// with a trusted connection login and a database called KeySuite
        /// </summary>
        private static  string connectionString = @"Data Source=localhost;Initial Catalog=KeySuite;Integrated Security=True";
        
        /// <summary>
        /// populates the elements of the table
        /// </summary>
        /// <param name="gridView">the main forms dataGridView</param>
        /// <returns>returns true if a connection is open and false if not</returns>
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
            catch(SqlException e)
            {
                return false;
            }
        }

        /// <summary>
        /// searches the database table and updates the main DataGridView with results
        /// </summary>
        /// <param name="gridView">the main forms dataGridView</param>
        /// <param name="searchTerm">the term the user is searching for...duh</param>
        /// <param name="category">which part of the table the search term is compared to</param>
        /// <returns>
        /// true if table is searched
        /// false if not
        /// </returns>
        public static bool searchTable(DataGridView gridView,string searchTerm,string category)
        {
            try
            { 
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter($"select * from keys where {category} like '%{searchTerm}%'", sqlcon);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    gridView.DataSource = table;
                    return true;
                }
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        /// <summary>
        /// inserts a value to the database from the addForm
        /// </summary>
        /// <param name="key">the Key object generetaed from the data input in the Addform</param>
        /// <returns>
        /// if the return is 1 an entry has been made
        /// if the return is 0 a key is duplicate
        /// </returns>
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
            catch(SqlException e)
            {
                response = 0;
            }

            return response;
        }

        /// <summary>
        /// modifies a current listing in the database with updated data from the EditForm
        /// </summary>
        /// <param name="key">the new key data being updated</param>
        /// <param name="currentKey">the current key to be searched for in the database for the set command</param>
        /// <returns>
        /// returns 1 if an entry was updated
        /// returns 0 if not
        /// </returns>
        public static int modifyEntry(Key key, string currentKey)
        {
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
            catch(SqlException e)
            {
                response = 0;
            }

            return response;
        }

        /// <summary>
        /// deletes an entry from the database
        /// </summary>
        /// <param name="current">the current key user for the delete claus</param>
        /// <returns>
        /// returns 1 if deletion was successful
        /// return 0 if not
        /// </returns>
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
            catch(SqlException e)
            {
                response = 0;
            }
            return response;
        }
    }
}
