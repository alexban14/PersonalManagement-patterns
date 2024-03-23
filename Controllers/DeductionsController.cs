using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalManagement.DAL;
using PersonalManagement.Models;

namespace PersonalManagement.Controllers
{
    public class DeductionsController : Controller
    {
        private PersonalManagementContext db = new PersonalManagementContext();

        // GET: Deductions
        public ActionResult Index()
        {
            var deductions = db.Deductions.Include(d => d.Employee);
            return View(deductions.ToList());
        }

        // GET: Deductions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deduction deduction = db.Deductions.Find(id);
            if (deduction == null)
            {
                return HttpNotFound();
            }
            return View(deduction);
        }

        // GET: Deductions/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name");
            return View();
        }

        // POST: Deductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DeductionType,Sum,EmployeeID")] Deduction deduction)
        {
            if (ModelState.IsValid)
            {
                db.Deductions.Add(deduction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", deduction.EmployeeID);
            return View(deduction);
        }

        // GET: Deductions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deduction deduction = db.Deductions.Find(id);
            if (deduction == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", deduction.EmployeeID);
            return View(deduction);
        }

        // POST: Deductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DeductionType,Sum,EmployeeID")] Deduction deduction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deduction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", deduction.EmployeeID);
            return View(deduction);
        }

        // GET: Deductions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deduction deduction = db.Deductions.Find(id);
            if (deduction == null)
            {
                return HttpNotFound();
            }
            return View(deduction);
        }

        // POST: Deductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deduction deduction = db.Deductions.Find(id);
            db.Deductions.Remove(deduction);
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
