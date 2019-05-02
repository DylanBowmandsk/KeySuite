using KeySuite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeySuiteTests
{
    public class TestingUtils
    {
        /// <summary>
        /// This class functions exactly the same as the databaseutils class
        /// the only difference is the table it connects to
        /// please see database utils for documentation on usage
        /// </summary>
        private static string connectionString = @"Data Source=localhost;Initial Catalog=KeySuite;Integrated Security=True";

        public static bool refresh()
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
                    SqlDataAdapter dataAdapter = new SqlDataAdapter($"select * from keystest where {category} like '%{searchTerm}%'", sqlcon);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO keystest VALUES (@cdkey, @product, @supplier, @distributor, @steam_url, @g2a_url, @region)", sqlcon);
                    cmd.Parameters.AddWithValue("@cdkey", key.cdkey);
                    cmd.Parameters.AddWithValue("@product", key.product);
                    cmd.Parameters.AddWithValue("@supplier", key.supplier);
                    cmd.Parameters.AddWithValue("@distributor", key.distributor);
                    if(key.steam_url == "")
                        cmd.Parameters.AddWithValue("@steam_url", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@steam_url", key.steam_url);
                    if(key.g2a_url == "")
                        cmd.Parameters.AddWithValue("@g2a_url", DBNull.Value);
                    else
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

        public static int modifyEntry(Key key, string currentKey)
        {
            int response;

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("Update keystest set cdkey = @cdkey, product = @product, supplier = @supplier," +
                        " distributor = @distributor, steam_url = @steam_url, g2a_url = @g2a_url, region = @region WHERE cdkey = @current ", sqlcon);
                    cmd.Parameters.AddWithValue("@cdkey", key.cdkey);
                    cmd.Parameters.AddWithValue("@product", key.product);
                    cmd.Parameters.AddWithValue("@supplier", key.supplier);
                    cmd.Parameters.AddWithValue("@distributor", key.distributor);
                    if (key.steam_url == "")
                        cmd.Parameters.AddWithValue("@steam_url", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@steam_url", key.steam_url);
                    if (key.g2a_url == "")
                        cmd.Parameters.AddWithValue("@g2a_url", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@g2a_url", key.g2a_url);
                    cmd.Parameters.AddWithValue("@region", key.region);
                    cmd.Parameters.AddWithValue("@current", currentKey);
                    response = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
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
                    SqlCommand cmd = new SqlCommand("delete from keystest where cdkey = @current", sqlcon);
                    cmd.Parameters.AddWithValue("@current",current);
                    response = cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                response = 0;
            }
            return response;
        }

        public static int deleteAll()
        {
            int response;

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("delete from keystest", sqlcon);
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
