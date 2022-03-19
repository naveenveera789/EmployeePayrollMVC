using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ProfileImg { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}
