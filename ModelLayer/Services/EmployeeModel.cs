using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
    public class EmployeeModel
    {
        public int empId { get; set; }
        public string empName { get; set; }
        public string profileImg { get; set; }
        public string gender { get; set; }
        public string department { get; set; }
        public int salary { get; set; }
        public DateTime startDate { get; set; }
        public string notes { get; set; }
    }
}
