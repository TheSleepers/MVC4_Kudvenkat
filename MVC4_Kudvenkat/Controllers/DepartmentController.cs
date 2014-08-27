using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4_Kudvenkat.Models;

namespace MVC4_Kudvenkat.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/

        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();

            List<Department> departments = employeeContext.Departments.ToList();
            return View(departments);
        }

    }
}
