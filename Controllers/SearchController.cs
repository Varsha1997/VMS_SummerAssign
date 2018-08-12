using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMS_SummerAssign.Models;
using PagedList;

namespace VMS_SummerAssign.Controllers
{
    public class SearchController : Controller
    {
        VolunteerDbContext db = new VolunteerDbContext();
        public ActionResult Search(string option, string search,int?pageNumber)
        {
            if (option == "FName")
            {
                return View(db.Volunteers.Where(X => X.FName.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 3));

            }
            else //if (option == "LName")
            {
                return View(db.Volunteers.Where(X => X.LName.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 3));

            }
            //else
            //{
               // return View(db.Volunteers.Where(X => X.Gender.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 3));

            //}
        }
        //[HttpPost]
       // public ActionResult Create(FormCollection collection)
        //{
          //  try
          //  {
          //      return RedirectToAction("Index");
          //  }
         //   catch
         //   {
          //      return View();
          //  }
      //  }
       // public ActionResult Edit(int id)
       // {

       // }
    }
}