using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataManager
{
    public class SqlHelper
    {
        //private string connectionString = "Data Source=SNEHAL\\SQLEXPRESS;Initial Catalog=Akaut;Integrated Security=True";
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        public SqlHelper()
        {

        }
        public async Task<DataSet> ExecuteDataSet(string query, Dictionary<string, object> parameters)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync();
                    SqlCommand cmd = new SqlCommand(query, con);
                    if (parameters != null)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.AddWithValue(item.Key, item.Value ?? DBNull.Value);
                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        //Insert, Update, Delete.
        public async Task<int> ExecuteNonQueryAsync(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (parameters != null)
                        {
                            foreach (var item in parameters)
                            {
                                cmd.Parameters.AddWithValue(item.Key, item.Value ?? DBNull.Value);

                            }
                        }

                        // Execute the command and return the number of affected rows
                        return await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("An error occurred while executing the command: " + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("An unexpected error occurred: " + ex.Message);
            }
        }

    }
}











