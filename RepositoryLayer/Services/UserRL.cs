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
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    cmd.Parameters.AddWithValue("@ProfileImg", employeeModel.ProfileImg);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);
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
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeId);
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
                            EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                            EmployeeName = dr["EmployeeName"].ToString(),
                            ProfileImg = dr["ProfileImg"].ToString(),
                            Gender = dr["Gender"].ToString(),
                            Department = dr["Department"].ToString(),
                            Salary = Convert.ToInt32(dr["Salary"]),
                            StartDate = Convert.ToDateTime(dr["StartDate"]),
                            Notes = dr["Notes"].ToString()
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
                    string sqlQuery = "SELECT * FROM EmployeeDetails WHERE EmployeeId= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        employeeModel.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        employeeModel.EmployeeName = dr["EmployeeName"].ToString();
                        employeeModel.ProfileImg = dr["ProfileImg"].ToString();
                        employeeModel.Gender = dr["Gender"].ToString();
                        employeeModel.Department = dr["Department"].ToString();
                        employeeModel.Salary = Convert.ToInt32(dr["Salary"]);
                        employeeModel.StartDate = Convert.ToDateTime(dr["StartDate"]);
                        employeeModel.Notes = dr["Notes"].ToString();
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
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeId);
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    cmd.Parameters.AddWithValue("@ProfileImg", employeeModel.ProfileImg);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);
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
