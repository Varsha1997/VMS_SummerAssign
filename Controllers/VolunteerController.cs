using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMS_SummerAssign.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace VMS_SummerAssign.Controllers
{
    public class VolunteerController : Controller
    {

        // Get Volunteer info
        public ActionResult Index()
        {
            VolunteerDBhandle dbhandle = new VolunteerDBhandle();
            ModelState.Clear();
            return View(dbhandle.GetVolunteer());
        }
        
        // Add Volunteer info
        public ActionResult Add()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        // Post info
        [HttpPost]
        public ActionResult Register(VolunteerModel vmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VolunteerDBhandle sdb = new VolunteerDBhandle();
                    if (sdb.AddVolunteer(vmodel))
                    {
                        ViewBag.Message = "Volunteer Details Added Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Admin");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }



        
        // Edit Volunteer info
        public ActionResult Edit(int id)
        {
            VolunteerDBhandle sdb = new VolunteerDBhandle();
            return View(sdb.GetVolunteer().Find(vmodel => vmodel.Id == id));
        }

        // post info
        [HttpPost]
        public ActionResult Edit(int id, VolunteerModel vmodel)
        {
            try
            {
                VolunteerDBhandle sdb = new VolunteerDBhandle();
                sdb.UpdateDetails(vmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // Delete Volunteer info
        public ActionResult Delete(int id)
        {
            try
            {
                VolunteerDBhandle sdb = new VolunteerDBhandle();
                if (sdb.DeleteVolunteer(id))
                {
                    ViewBag.AlertMsg = "Volunteer Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Admin()
        {
            return View();
        }

        // Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VolunteerModel vm)
        {
            string mainConn = ConfigurationManager.ConnectionStrings["VolunteerConn"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(mainConn);
            string sqlquery = "select UserName,Password from [dbo].[Volunteers] where UserName = @UserName and Password = @Password";
            sqlConn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlConn);
            sqlComm.Parameters.AddWithValue("@UserName", vm.UserName);
            sqlComm.Parameters.AddWithValue("@Password", vm.Password);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            if (sdr.Read())
            {
                Session["UserName"] = vm.UserName.ToString();
                return RedirectToAction("Admin");
            }
            else
            {
                ViewData["Message"] = "Invalid Username And Password";
            }
            sqlConn.Close();
            return View();
        }

       
    }
}
