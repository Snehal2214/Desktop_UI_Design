using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class DetailService
    {
        SqlConnection ObjSqlConnection;
        SqlCommand ObjSqlCommand;
        public DetailService()
        {
            ObjSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            ObjSqlCommand = new SqlCommand();
            ObjSqlCommand.Connection = ObjSqlConnection;
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;
           
        }
        public bool Add(DetailsModel ObjNewdetailsModel)
        {
            bool IsAdded = false;
            
            try
            {
                string fullName = $"{ObjNewdetailsModel.FirstName } {ObjNewdetailsModel.LastName }";
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "insertDetails";

                ObjSqlCommand.Parameters.AddWithValue("@Name", fullName);
                ObjSqlCommand.Parameters.AddWithValue("@Company_Name", ObjNewdetailsModel.Company_Name );
                ObjSqlCommand.Parameters.AddWithValue("@Phone_No", ObjNewdetailsModel.Phone_No );
                ObjSqlCommand.Parameters.AddWithValue("@Email", ObjNewdetailsModel.Email );
                ObjSqlCommand.Parameters.AddWithValue("@Address", ObjNewdetailsModel.Address );
                ObjSqlCommand.Parameters.AddWithValue("@City", ObjNewdetailsModel.City );
                ObjSqlCommand.Parameters.AddWithValue("@State", ObjNewdetailsModel.State );

                ObjSqlConnection.Open();

                int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
                IsAdded = NoOfRowsAffected > 0;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }

            return IsAdded;
        }
    }
}
