using KeySuite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeySuiteTests
{
    class TestingUtils
    {

        private static string connectionString = @"Data Source=localhost;Initial Catalog=KeySuite;Integrated Security=True";

        public static bool fillTable()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from keystest", sqlcon);
                    return true;
                }
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        public static bool searchTable(string searchTerm, string category)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter($"select * from keys where {category} like '%{searchTerm}%'", sqlcon);
                    return true;
                }
            }
            catch (SqlException e)
            {
                return false;
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
            catch (SqlException e)
            {
                response = 0;
            }

            return response;
        }
    }
}
