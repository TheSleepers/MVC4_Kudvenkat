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
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Employee employee = new Employee();
            //UpdateModel inspects(http request = posted form data, QueryString, Cookies, server variables) and populate Employee object
            //Use TryUpdateModel when using required data anotations on attributes. TryUpdateModel will never throw an exception. If using only UpdateModel the application will throw an exception
            TryUpdateModel(employee); //TryUpdateModel is true or false

            //See if there are validation errors with IsValid
            if (ModelState.IsValid)
            {
                //Create object of 'EmployeeBusinessLayer' and pass new 'employee' to method 'AddEmployee' in 'EmployeeBusinessLayer'
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmployee(employee);

                return RedirectToAction("Index");
            }
            //If there are validation errors return view
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            //Create instance of EmployeeBusinessLayer class
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            //Assign to Employee object
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.EmployeeId == Id);
            //Hand employee object to View!
            return View(employee);
        }

        [HttpPost]
        //[ActionName("Edit")]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                //Create instance of EmployeeBusinessLayer class
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                //Assign to Employee object
                employeeBusinessLayer.UpdateEmployee(employee);

                return RedirectToAction("Index");
            }
            //Hand employee object to View!
            return View(employee);
        }



        //*****************************************************************************************
        //Employee employee = new Employee();
        //Add new employee to formCollection
        //employee.Name = formCollection["Name"];
        //employee.Gender = formCollection["Gender"];
        //employee.City = formCollection["City"];
        //employee.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);   



        //foreach (var key in formCollection.AllKeys)
        //{
        //    Response.Write("Key" + key + " ");
        //    Response.Write(formCollection[key]);
        //    Response.Write("<br/>");
        //}
        //return View();


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
