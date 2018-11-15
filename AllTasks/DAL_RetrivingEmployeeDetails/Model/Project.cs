using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_RetrivingEmployeeDetails.Model
{
    public class Project
    {
        public int EmployeId { set; get; }
        public string ProjectName { set; get; }
        public DateTime Starting { set; get; }
        public DateTime Ending { set; get; }
    }
}
