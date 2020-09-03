using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EmployeeManagement.Models;

namespace EmployeeManagement.Helper
{
    public class EmployeeHelper
    {
        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=D:\\Promact Infotech\\2020\\28AUG\\EmployeeManagement\\App_Data\\Database.mdf;Integrated Security = True");
        SqlDataAdapter sqlDataAdapter;
        SqlCommand sqlCommand;
        public DataSet Select_Update_Delete_EmployeeDetails(EmployeeModel employeeModel, out string message)
        {
            DataSet dataSet = new DataSet();
            message = null;
            try
            {
                sqlCommand = new SqlCommand("SP_Employee", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmployeeID", employeeModel.EmployeeID);
                sqlCommand.Parameters.AddWithValue("@Name", employeeModel.Name);
                sqlCommand.Parameters.AddWithValue("@Surname", employeeModel.Surname);
                sqlCommand.Parameters.AddWithValue("@Contact", employeeModel.Contact);
                sqlCommand.Parameters.AddWithValue("@Qualification", employeeModel.Qualification);
                sqlCommand.Parameters.AddWithValue("@Department", employeeModel.Department);
                sqlCommand.Parameters.AddWithValue("@Address", employeeModel.Address);
                sqlCommand.Parameters.AddWithValue("@flag", employeeModel.flag);
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
        public string Create_EmployeeDetails(EmployeeModel employeeModel, out string message)
        {
        DataSet dataSet = new DataSet();
            message = null;
            try
            {
                sqlCommand = new SqlCommand("SP_Employee", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmployeeID", employeeModel.EmployeeID);
                sqlCommand.Parameters.AddWithValue("@Name", employeeModel.Name);
                sqlCommand.Parameters.AddWithValue("@Surname", employeeModel.Surname);
                sqlCommand.Parameters.AddWithValue("@Contact", employeeModel.Contact);
                sqlCommand.Parameters.AddWithValue("@Qualification", employeeModel.Qualification);
                sqlCommand.Parameters.AddWithValue("@Department", employeeModel.Department);
                sqlCommand.Parameters.AddWithValue("@Address", employeeModel.Address);
                sqlCommand.Parameters.AddWithValue("@flag", employeeModel.flag);
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
        public DataSet Select_DepartmentName()
        {
            DataSet dataSet = new DataSet();
            try
            {
                sqlCommand = new SqlCommand("SP_Department", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@DepartmentID", "");
                sqlCommand.Parameters.AddWithValue("@Name", "");
                sqlCommand.Parameters.AddWithValue("@Description", "");
                sqlCommand.Parameters.AddWithValue("@flag", "GetDepartmentName_DepartmentInfo");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception en)
            {
                return dataSet;
            }
        }
    }
}
