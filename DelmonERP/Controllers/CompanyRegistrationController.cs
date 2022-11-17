using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseAcess;
using DelmonERP.Models;

namespace DelmonERP.Controllers
{
    public class CompanyRegistrationController : Controller
     
    {
        CloudErpV1Entities1 db = new CloudErpV1Entities1();
        // GET: CompanyRegistration

        public ActionResult RegistrationForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistrationForm(
            
            string UserName,
            string Password,
            string CPassword,
            string EName,
            string EContactNo,
            string EEmail,
            string ECNIC,
            string EDesignation,
            string EDescription,
            float  EMonthlySalary,
            string EAddress,
            string CName,
            string BranchName,
            string  BranchContact,
            string  BranchAddress
            )
        {
            try
            {
                 if (!string.IsNullOrEmpty(UserName)
                    && !string.IsNullOrEmpty(Password)
                    && !string.IsNullOrEmpty(CPassword)
                    && !string.IsNullOrEmpty(EName)
                    && !string.IsNullOrEmpty(EContactNo)
                    && !string.IsNullOrEmpty(EEmail)
                    && !string.IsNullOrEmpty(ECNIC)
                    && !string.IsNullOrEmpty(EDesignation)
                    && !string.IsNullOrEmpty(EDescription)
                    && !string.IsNullOrEmpty(EAddress)
                    && EMonthlySalary > 0
                    && !string.IsNullOrEmpty(BranchName)
                    && !string.IsNullOrEmpty(BranchContact)
                    && !string.IsNullOrEmpty(BranchAddress)
                    && !string.IsNullOrEmpty(CName)
                       )
                {
                    var company = new tblCompany()
                    {
                        Name = CName ,
                        Logo = string.Empty
                    };
                    db.tblCompanies.Add(company);
                    db.SaveChanges();

                    var branch = new tblBranch()
                    {
                        BranchName = BranchName,
                        BranchContact = BranchContact,
                        BranchAddress = BranchAddress,
                        BranchTypeID = 1,
                        CompanyID = company.CompanyID,
                        BrchID = null

                    };
                    db.tblBranches.Add(branch);
                    db.SaveChanges();


                    var user = new tblUser()
                    {
                        ContactNo = EContactNo,
                        UserName = UserName,
                        Password = Password,
                        IsActive = true,
                        Email = EEmail,
                        FullName = EName,
                        UserTypeID = 2

                    };
                    db.tblUsers.Add(user);
                    db.SaveChanges();

                    var employee = new tblEmployee()
                    {
                        Address = EAddress,
                        BranchID = branch.BranchID,
                        CNIC = ECNIC,
                        CompanyID = company.CompanyID,
                        ContactNo = EContactNo,
                        Designation = EDesignation,
                        Email = EEmail,
                        MonthlySalary = EMonthlySalary,
                        UserID = user.UserID,
                        Name = EName,
                        Description = string.Empty
                    };
                    db.tblEmployees.Add(employee);
                    db.SaveChanges();

                    ViewBag.Message= "Registration Successfully ";
                    return RedirectToAction("Login","Home");
                }
                else
                {
                    ViewBag.Message = "Please Provide Correct Details !";
                    return View("RegistrationForm");
                }
            }

            catch (Exception ex)
            {
                //     ViewBag.Message = "Please Contact To Administrator !";
                    ViewBag.Message = ex;

                return View();
            }

         

        }
    }
}