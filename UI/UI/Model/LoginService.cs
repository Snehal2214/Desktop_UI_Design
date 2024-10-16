using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UI.View;

namespace UI.Model
{
    public class LoginService
    {
        SqlConnection ObjSqlConnection;
        SqlCommand ObjSqlCommand;

        public LoginService()
        {
            ObjSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            ObjSqlCommand = new SqlCommand();
            ObjSqlCommand.Connection = ObjSqlConnection;
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;

        }

        public bool Checklogin(LoginModel loginModel) 
        {
            bool IsChecked = false;
            try 
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "Check_Login";

                ObjSqlCommand.Parameters.AddWithValue("@Username", loginModel.Username);
                ObjSqlCommand.Parameters.AddWithValue("@Password", loginModel.Password);

                ObjSqlConnection.Open();

                int count = Convert.ToInt32(ObjSqlCommand.ExecuteScalar());

                if (count == 1) 
                {
                    DetailsForm detailForm = new DetailsForm();
                    detailForm.Show();
                    this.ObjSqlConnection.Close();
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }

            return IsChecked;
        }
       

    }
}
