using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseAcess;

namespace DelmonERP.Controllers
{
    public class tblBranchesController : Controller
    {
        private CloudErpV1Entities1 db = new CloudErpV1Entities1();

        // GET: tblBranches
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["ECompanyID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int companyid = 0;
            companyid = Convert.ToInt32(Convert.ToString(Session["ECompanyID"]));
            var tblBranches = db.tblBranches.Include(t => t.tblBranchType).Where(c=>c.CompanyID== companyid);
            return View(tblBranches.ToList());

        }

        // GET: tblBranches/Details/5
        public ActionResult Details(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["ECompanyID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBranch tblBranch = db.tblBranches.Find(id);
            if (tblBranch == null)
            {
                return HttpNotFound();
            }
            return View(tblBranch);
        }

        // GET: tblBranches/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["ECompanyID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int companyid = 0;
            companyid = Convert.ToInt32(Convert.ToString(Session["ECompanyID"]));
            ViewBag.BrchID = new SelectList(db.tblBranches.Where(c => c.CompanyID == companyid).ToList(), "BranchID", "BranchName",0);
            ViewBag.BranchTypeID = new SelectList(db.tblBranchTypes, "BranchTypeID", "BranchType",0);
         
            return View();
        }

        // POST: tblBranches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( tblBranch tblBranch)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["ECompanyID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int companyid = 0;
            companyid = Convert.ToInt32(Convert.ToString(Session["ECompanyID"]));
            tblBranch.CompanyID = companyid;
            if (ModelState.IsValid)
            {
                db.tblBranches.Add(tblBranch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        
            ViewBag.BrchID = new SelectList(db.tblBranches.Where(c => c.CompanyID == companyid).ToList(), "BranchID", "BranchName");

            ViewBag.BranchTypeID = new SelectList(db.tblBranchTypes, "BranchTypeID", "BranchType", tblBranch.BranchTypeID);
            return View(tblBranch);
        }

        // GET: tblBranches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["ECompanyID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int companyid = 0;
            companyid = Convert.ToInt32(Convert.ToString(Session["ECompanyID"]));
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBranch tblBranch = db.tblBranches.Find(id);
            if (tblBranch == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrchID = new SelectList(db.tblBranches.Where(c => c.CompanyID == companyid).ToList(), "BranchID", "BranchName",tblBranch.BranchID);
            ViewBag.BranchTypeID = new SelectList(db.tblBranchTypes, "BranchTypeID", "BranchType", tblBranch.BranchTypeID);
            return View(tblBranch);
        }

        // POST: tblBranches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblBranch tblBranch)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["ECompanyID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int companyid = 0;
            companyid = Convert.ToInt32(Convert.ToString(Session["ECompanyID"]));
            tblBranch.CompanyID = companyid;

            if (ModelState.IsValid)
            {
                db.Entry(tblBranch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrchID = new SelectList(db.tblBranches.Where(c => c.CompanyID == companyid).ToList(), "BranchID", "BranchName", tblBranch.BrchID);
            ViewBag.BranchTypeID = new SelectList(db.tblBranchTypes, "BranchTypeID", "BranchType", tblBranch.BranchTypeID);
            return View(tblBranch);
        }

        // GET: tblBranches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["ECompanyID"])))
            {
                return RedirectToAction("Login", "Home");
            }
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBranch tblBranch = db.tblBranches.Find(id);
            if (tblBranch == null)
            {
                return HttpNotFound();
            }
            return View(tblBranch);
        }

        // POST: tblBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBranch tblBranch = db.tblBranches.Find(id);
            db.tblBranches.Remove(tblBranch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
