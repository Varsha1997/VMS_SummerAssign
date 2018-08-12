using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMS_SummerAssign.Models;

namespace VMS_SummerAssign.Controllers
{
    public class HomeController : Controller
    {
        VolunteerDbContext db = new VolunteerDbContext();
        public ActionResult Search()
        {
            List<Volunteer> VolunteerList = db.Volunteers.ToList();
            return View(VolunteerList);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}