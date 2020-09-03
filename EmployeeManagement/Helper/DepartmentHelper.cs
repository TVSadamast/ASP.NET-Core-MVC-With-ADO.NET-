using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagement.Models;
using System.Configuration;

namespace EmployeeManagement.Helper
{
    public class DepartmentHelper
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Promact Infotech\\2020\\28AUG\\EmployeeManagement\\App_Data\\Database.mdf;Integrated Security=True");
        SqlDataAdapter sqlDataAdapter;
        SqlCommand sqlCommand;

        public DataSet Select_Update_Delete_DepartmentDetails(DepartmentModel departmentModel, out string message)
        {
            DataSet dataSet = new DataSet();
            message = null;
            try
            {
                sqlCommand = new SqlCommand("SP_Department", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@DepartmentID", departmentModel.DepartmentID);
                sqlCommand.Parameters.AddWithValue("@Name", departmentModel.Name);
                sqlCommand.Parameters.AddWithValue("@Description", departmentModel.Description);
                sqlCommand.Parameters.AddWithValue("@flag", departmentModel.flag);
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataSet);
                message = "Success!";
                return dataSet;
            }
            catch (Exception en)
            {
                message = en.Message;
                return dataSet;
            }
        }
        public string Create_DepartmentDetails(DepartmentModel departmentModel, out string message)
        {
            DataSet dataSet = new DataSet();
            message = null;
            try
            {
                sqlCommand = new SqlCommand("SP_Department", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@DepartmentID", departmentModel.DepartmentID);
                sqlCommand.Parameters.AddWithValue("@Name", departmentModel.Name);
                sqlCommand.Parameters.AddWithValue("@Description", departmentModel.Description);
                sqlCommand.Parameters.AddWithValue("@flag", departmentModel.flag);
                if (con.State == ConnectionState.Open)
                    sqlCommand.ExecuteNonQuery();
                else
                {
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                con.Close();

                message = "Success";
                return message;
            }
            catch (Exception en)
            {
                message = en.Message;
                return message;
            }
        }
    }
}
