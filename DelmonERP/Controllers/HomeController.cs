using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DelmonERP.Controllers
{
    public class HomeController : Controller
    {
        DatabaseAcess.CloudErpV1Entities1 db = new DatabaseAcess.CloudErpV1Entities1();
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["ECompanyID"])))
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["UserTypeID"] = string.Empty;
            Session["FullName"] = string.Empty;
            Session["Email"] = string.Empty;
            Session["ContactNo"] = string.Empty;
            Session["UserName"] = string.Empty;
            Session["Password"] = string.Empty;
            Session["IsActive"] = string.Empty;
            Session["EmployeeID"] = string.Empty;
            Session["EName"] = string.Empty;
            Session["EPhoto"] = string.Empty;
            Session["EDesignation"] = string.Empty;
            Session["EBranchID"] = string.Empty;
            Session["ECompanyID"] = string.Empty;

            return View("Login");
        }

        [HttpPost]
        public ActionResult LoginUser(string email,string password)
        {
            var user = db.tblUsers.Where( u=> u.Email== email && u.Password == password && u.IsActive==true).FirstOrDefault();
            if (user != null)
            {
                Session["UserID"] = user.UserID;
                Session["UserTypeID"] = user.UserTypeID;
                Session["FullName"] = user.FullName;
                Session["Email"] = user.Email;
                Session["ContactNo"] = user.ContactNo;
                Session["UserName"] = user.UserName;
                Session["Password"] = user.Password;
                Session["IsActive"] = user.IsActive;
                var EmployeeDetails = db.tblEmployees.Where(e => e.UserID == user.UserID).FirstOrDefault();
                if (EmployeeDetails == null)
                {
                    ViewBag.Message = "Please Contact to Adminstrator !";
                    Session["UserTypeID"] = string.Empty;
                    Session["FullName"] = string.Empty;
                    Session["Email"] = string.Empty;
                    Session["ContactNo"] = string.Empty;
                    Session["UserName"] = string.Empty;
                    Session["Password"] = string.Empty;
                    Session["IsActive"] = string.Empty;
                    Session["EmployeeID"] = string.Empty;
                    Session["EName"] = string.Empty;
                    Session["EPhoto"] = string.Empty;
                    Session["EDesignation"] = string.Empty;
                    Session["EBranchID"] = string.Empty;
                    Session["ECompanyID"] = string.Empty;

                    return View("Login");
                }

                Session["EmployeeID"] = EmployeeDetails.EmployeeID;
                Session["EName"] = EmployeeDetails.Name;
                Session["EPhoto"] = EmployeeDetails.Photo;
                Session["EDesignation"] = EmployeeDetails.Designation;
                Session["EBranchID"] = EmployeeDetails.BranchID;
                Session["ECompanyID"] = EmployeeDetails.CompanyID;

                var Company = db.tblCompanies.Where(c => c.CompanyID == EmployeeDetails.CompanyID).FirstOrDefault();

                if (Company == null)
                {
                    ViewBag.Message = "Please Contact to Adminstrator !";
                    Session["UserTypeID"] = string.Empty;
                    Session["FullName"] = string.Empty;
                    Session["Email"] = string.Empty;
                    Session["ContactNo"] = string.Empty;
                    Session["UserName"] = string.Empty;
                    Session["Password"] = string.Empty;
                    Session["IsActive"] = string.Empty;
                    Session["EmployeeID"] = string.Empty;
                    Session["EName"] = string.Empty;
                    Session["EPhoto"] = string.Empty;
                    Session["EDesignation"] = string.Empty;
                    Session["EBranchID"] = string.Empty;
                    Session["ECompanyID"] = string.Empty;

                    return View("Login");


                }
                Session["CName"] = Company.Name;
                Session["Logo"] = Company.Logo;




                return RedirectToAction("Index");

            }
            else
            {

                ViewBag.Message = "Incorrect creditionals";
                Session["UserTypeID"] = string.Empty;
                Session["FullName"] = string.Empty;
                Session["Email"] = string.Empty;
                Session["ContactNo"] = string.Empty;
                Session["UserName"] = string.Empty;
                Session["Password"] = string.Empty;
                Session["IsActive"] = string.Empty;
                Session["EmployeeID"] = string.Empty;
                Session["EName"] = string.Empty;
                Session["EPhoto"] = string.Empty;
                Session["EDesignation"] = string.Empty;
                Session["EBranchID"] = string.Empty;
                Session["ECompanyID"] = string.Empty;


            }


            return View("Login");
        }
        public ActionResult ForgetPassword()
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