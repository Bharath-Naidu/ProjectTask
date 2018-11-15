using DAL_RetrivingEmployeeDetails.Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DAL_RetrivingEmployeeDetails.Repositary
{
    public class DatabaseLinking
    {
        string DatabaseConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        public void UploadEmployeeDetails(Employee employee,Project project)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = DatabaseConnectionString;
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("Proc_UploadEmployeeDetails", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 500).Value = employee.Name;
                    sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar, 1000).Value = employee.Address;
                    sqlCommand.Parameters.Add("@salary", SqlDbType.Decimal).Value = employee.Salary;
                    sqlCommand.Parameters.Add("@designation", SqlDbType.NVarChar, 1000).Value = employee.Designation;
                    sqlCommand.Parameters.Add("@active", SqlDbType.Bit).Value = employee.Active;
                    sqlCommand.Parameters.Add("@projectname", SqlDbType.NVarChar, 1000).Value = project.ProjectName;
                    sqlCommand.Parameters.Add("@starting", SqlDbType.DateTime).Value = project.Starting;
                    sqlCommand.Parameters.Add("@ending", SqlDbType.DateTime).Value = project.Ending;
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DataTable RetriveEmployeeDetails(string name)
        {

            DataTable ds = new DataTable();
            Employee employee=new Employee();
            Project project = new Project();
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = DatabaseConnectionString;
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("Proc_EmployeeDetails", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 500).Value = name;
                    sqlCommand.ExecuteNonQuery();
                    ds = new DataTable();
                    ds.Load(sqlCommand.ExecuteReader());

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ds;
        }
    }
}
