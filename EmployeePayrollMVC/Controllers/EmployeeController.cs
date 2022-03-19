using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        IUserBL userBL;
        public EmployeeController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        public IActionResult Index()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            employees = this.userBL.EmployeeList().ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = this.userBL.GetEmployeeData(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                userBL.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = userBL.GetEmployeeData(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeModel employeeModel)
        {
            if (id != employeeModel.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                userBL.UpdateEmployee(employeeModel);
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = userBL.GetEmployeeData(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            userBL.DeleteEmployee(userBL.GetEmployeeData(id));
            return RedirectToAction("Index");
        }
    }
}