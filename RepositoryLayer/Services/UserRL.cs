using Microsoft.Extensions.Configuration;
using ModelLayer.Services;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly IConfiguration configuration;
        public UserRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayroll_MVC")))
                {
                    SqlCommand cmd = new SqlCommand("addEmployeeDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empName", employeeModel.empName);
                    cmd.Parameters.AddWithValue("@profileImg", employeeModel.profileImg);
                    cmd.Parameters.AddWithValue("@gender", employeeModel.gender);
                    cmd.Parameters.AddWithValue("@department", employeeModel.department);
                    cmd.Parameters.AddWithValue("@salary", employeeModel.salary);
                    cmd.Parameters.AddWithValue("@startDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@notes", employeeModel.notes);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void DeleteEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayroll_MVC")))
                {
                    SqlCommand cmd = new SqlCommand("deleteEmployeeDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empId", employeeModel.empId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<EmployeeModel> EmployeeList()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayroll_MVC")))
                {
                    SqlCommand cmd = new SqlCommand("getEmployeeDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EmployeeModel employeeModel = new EmployeeModel()
                        {
                            empId = Convert.ToInt32(dr["empId"]),
                            empName = dr["empName"].ToString(),
                            profileImg = dr["profileImg"].ToString(),
                            gender = dr["gender"].ToString(),
                            department = dr["department"].ToString(),
                            salary = Convert.ToInt32(dr["salary"]),
                            startDate = Convert.ToDateTime(dr["startDate"]),
                            notes = dr["notes"].ToString()
                        };
                        employees.Add(employeeModel);
                    }
                    con.Close();
                }
                return employees;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayroll_MVC")))
                {
                    string sqlQuery = "SELECT * FROM EmployeeDetails WHERE empId= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        employeeModel.empId = Convert.ToInt32(dr["empId"]);
                        employeeModel.empName = dr["empName"].ToString();
                        employeeModel.profileImg = dr["profileImg"].ToString();
                        employeeModel.gender = dr["gender"].ToString();
                        employeeModel.department = dr["department"].ToString();
                        employeeModel.salary = Convert.ToInt32(dr["salary"]);
                        employeeModel.startDate = Convert.ToDateTime(dr["startDate"]);
                        employeeModel.notes = dr["notes"].ToString();
                    }
                    con.Close();
                }
                return employeeModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayroll_MVC")))
                {
                    SqlCommand cmd = new SqlCommand("updateEmployeeDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empId", employeeModel.empId);
                    cmd.Parameters.AddWithValue("@empName", employeeModel.empName);
                    cmd.Parameters.AddWithValue("@profileImg", employeeModel.profileImg);
                    cmd.Parameters.AddWithValue("@gender", employeeModel.gender);
                    cmd.Parameters.AddWithValue("@department", employeeModel.department);
                    cmd.Parameters.AddWithValue("@salary", employeeModel.salary);
                    cmd.Parameters.AddWithValue("@startDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@notes", employeeModel.notes);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
