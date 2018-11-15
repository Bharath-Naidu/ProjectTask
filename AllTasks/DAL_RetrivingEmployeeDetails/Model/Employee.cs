using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_RetrivingEmployeeDetails.Model
{
    public class Employee
    {
        public string Name { set; get; }
        public string Address { set; get; }
        public decimal Salary { set; get; }
        public string Designation { set; get; }
        public bool Active { set; get; }
    }
}
