using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4_Kudvenkat.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Countries = new List<string>()
            {
                "India",
                "USA",
                "Canada",
                "UK"
            };

            return View();
        }

          //public string Index(string id, string name)
        //{
        //    return "Id = " + id + " Name = " + name;
        //}

        //public string GetDetails()
        //{
        //    return "GetDetailsMethod";
        //}

 


      

       

    }
}
