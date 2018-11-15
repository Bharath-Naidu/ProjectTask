using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_RetrivingEmployeeDetails.Model;
using DAL_RetrivingEmployeeDetails.Repositary;

namespace RetrivingEnployeeDetails15_11_18
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("please select the option\n1.New Employee\n2.I want employee details");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            NewEmployee();
                            break;
                        case 2:
                            DisplayEmployeeDetails();
                            break;
                    }
                    Console.WriteLine("select Option 1.Continue 2.not");
                    int ch = Convert.ToInt32(Console.ReadLine());
                    Console.ReadKey();
                    if (ch != 1)
                    {
                        flag = false;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public static void NewEmployee()
        {
            try
            {
                DatabaseLinking DbCall = new DatabaseLinking();
                Employee employee = new Employee();
                Project project = new Project();
                Console.WriteLine("Please enter the name of the employee");
                employee.Name = Console.ReadLine();
                Console.WriteLine("Please enter the Address of the employee");
                employee.Address = Console.ReadLine();
                Console.WriteLine("Please enter the salary of the employee");
                employee.Salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Please enter the Designation of the employee");
                employee.Designation = Console.ReadLine();
                Console.WriteLine("These employee is Active Yes or No");
                string ch = Console.ReadLine();
                if ((ch.ToLower()).Equals("yes"))
                    employee.Active = true;
                else
                    employee.Active = false;
                Console.WriteLine("Please enter the allocated project");
                project.ProjectName = Console.ReadLine();
                Console.WriteLine("Please enter the project start like this format MM/DD/YYYY or MM-DD-YYYY");
                string Date = Console.ReadLine();
                project.Starting = Convert.ToDateTime(Date);
                Console.WriteLine("Please enter the project Ending like this format MM/DD/YYYY or MM-DD-YYYY");
                Date = Console.ReadLine();
                project.Ending = DateTime.Parse(Date);
                DbCall.UploadEmployeeDetails(employee, project);
                Console.WriteLine("Uploaded Successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void DisplayEmployeeDetails()
        {
            try {
                DatabaseLinking DbCall = new DatabaseLinking();
                Console.WriteLine("Please enter the name of the employee");
                string name = Console.ReadLine();
                DataTable ds = DbCall.RetriveEmployeeDetails(name);
                foreach (DataRow dr in ds.Rows)
                {
                    Console.WriteLine("Employe Name=" + dr["EmpName"].ToString());
                    Console.WriteLine("Employe Adress=" + dr["EmpAddress"].ToString());
                    Console.WriteLine("Employe Designation=" + dr["Designation"].ToString());
                    Console.WriteLine("Employe salary=" + dr["Salary"].ToString());
                    Console.WriteLine("Employe Active or not=" + dr["Active"].ToString());
                    Console.WriteLine("Employe project name=" + dr["ProjectName"].ToString());
                    Console.WriteLine("Employe project starting from=" + dr["Projectstarting"].ToString());
                    Console.WriteLine("Employe Ending =" + dr["Projectending"].ToString());
                    Console.WriteLine();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
