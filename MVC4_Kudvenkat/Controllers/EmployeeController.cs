using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using MVC4_Kudvenkat.Models;
using BusinessLayer;

namespace MVC4_Kudvenkat.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();

            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            Employee employee = new Employee();

            //Add new employee to formCollection
            employee.Name = formCollection["Name"];
            employee.Gender = formCollection["Gender"];
            employee.City = formCollection["City"];
            employee.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);

            //Create object of 'EmployeeBusinessLayer' and pass new 'employee' to method 'AddEmployee' in 'EmployeeBusinessLayer'
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.AddEmployee(employee);

            return RedirectToAction("Index");
            

            //foreach (var key in formCollection.AllKeys)
            //{
            //    Response.Write("Key" + key + " ");
            //    Response.Write(formCollection[key]);
            //    Response.Write("<br/>");
            //}
            //return View();
        }

        /*
        //Getting list of employees without using Business Layer
        public ActionResult Index(int departmentId)
        {
            //Make connection to database
            EmployeeContext employeeContext = new EmployeeContext();

            //Create a list of employees on departmenId to display in view
            List<Employee> employees = employeeContext.Employees.Where(dep => dep.DepartmentId == departmentId).ToList();
            //Hand over employee object to the View
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            //Make connection to database<
            EmployeeContext employeeContext = new EmployeeContext();

            //Add employeeContext to Object of Employee
            Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeId == id);

            //Hand over employee object to the View
            return View(employee);
        }
         * */
    }
}
