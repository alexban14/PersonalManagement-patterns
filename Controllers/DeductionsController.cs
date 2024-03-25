using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalManagement.DAL;
using PersonalManagement.Factories;
using PersonalManagement.Models;
using PersonalManagement.Repositories;

namespace PersonalManagement.Controllers
{
    public class DeductionsController : Controller
    {
        private IFactory<Deduction> deductionFactory;
        private readonly DeductionsRepository deductionsRepository;
        private readonly DeductionTypesRepository deductionTypesRepository;
        private readonly EmployeesRepository employeesRepository;

        public DeductionsController()
        {
            deductionFactory = new DeductionFactory();
            deductionsRepository = new DeductionsRepository();
            deductionTypesRepository = new DeductionTypesRepository();
            employeesRepository = new EmployeesRepository();
        }

        // GET: Deductions
        public ActionResult Index()
        {
            return View(deductionsRepository.GetAll());
        }

        // GET: Deductions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Deduction deduction = deductionsRepository.GetDeductionByID(id.Value);

            if (deduction == null)
            {
                return HttpNotFound();
            }
            return View(deduction);
        }

        // GET: Deductions/Create
        public ActionResult Create()
        {
            ViewBag.DeductionTypeID = new SelectList(deductionTypesRepository.GetAll(), "ID", "Name");
            ViewBag.EmployeeID = new SelectList(employeesRepository.GetAll(), "ID", "Name");
            return View();
        }

        // POST: Deductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Sum,EmployeeID,DeductionTypeID")] Deduction deduction)
        {
            if (ModelState.IsValid)
            {
                Deduction newDeduction = deductionFactory.Create(deduction.Sum, deduction.EmployeeID, deduction.DeductionTypeID);

                deductionsRepository.CreateDeduction(newDeduction);

                return RedirectToAction("Index");
            }

            ViewBag.DeductionTypeID = new SelectList(deductionTypesRepository.GetAll(), "ID", "Name", deduction.DeductionTypeID);
            ViewBag.EmployeeID = new SelectList(employeesRepository.GetAll(), "ID", "Name", deduction.EmployeeID);
            return View(deduction);
        }

        // GET: Deductions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Deduction deduction = deductionsRepository.GetDeductionByID(id.Value);

            if (deduction == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeductionTypeID = new SelectList(deductionTypesRepository.GetAll(), "ID", "Name", deduction.DeductionTypeID);
            ViewBag.EmployeeID = new SelectList(employeesRepository.GetAll(), "ID", "Name", deduction.EmployeeID);

            return View(deduction);
        }

        // POST: Deductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Sum,EmployeeID,DeductionTypeID")] Deduction deduction)
        {
            if (ModelState.IsValid)
            {
                deductionsRepository.UpdateDeduction(deduction);

                return RedirectToAction("Index");
            }

            ViewBag.DeductionTypeID = new SelectList(deductionTypesRepository.GetAll(), "ID", "Name", deduction.DeductionTypeID);
            ViewBag.EmployeeID = new SelectList(employeesRepository.GetAll(), "ID", "Name", deduction.EmployeeID);

            return View(deduction);
        }

        // GET: Deductions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Deduction deduction = deductionsRepository.GetDeductionByID(id.Value);

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
            Deduction deduction = deductionsRepository.GetDeductionByID(id);
            deductionsRepository.DeleteDeduction(deduction);

            return RedirectToAction("Index");
        }
    }
}
