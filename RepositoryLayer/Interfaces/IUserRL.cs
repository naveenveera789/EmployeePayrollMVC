using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        void AddEmployee(EmployeeModel employeeModel);
        List<EmployeeModel> EmployeeList();
        EmployeeModel GetEmployeeData(int? id);
        void UpdateEmployee(EmployeeModel employeeModel);
        void DeleteEmployee(EmployeeModel employeeModel);
    }
}
