using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        void AddEmployee(EmployeeModel employeeModel);
        List<EmployeeModel> EmployeeList();
        EmployeeModel GetEmployeeData(int? id);
        void UpdateEmployee(EmployeeModel employeeModel);
        void DeleteEmployee(EmployeeModel employeeModel);
    }
}
