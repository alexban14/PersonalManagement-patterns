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
using PersonalManagement.Services;

namespace PersonalManagement.Controllers
{
    public class DeductionsController : Controller
    {
        private IFactory<Deduction> _deductionFactory;
        private readonly IRepository<Deduction> _deductionsRepository;
        private readonly IRepository<DeductionType> _deductionTypesRepository;
        private readonly IRepository<Employee> _employeesRepository;

        public DeductionsController()
        {
            FileLogger logger = new FileLogger("decuctions_controller_log");

            _deductionFactory = new DeductionFactory();
            _deductionsRepository = new LoggingRepository<Deduction>(new DeductionsRepository(), logger);
            _deductionTypesRepository = new LoggingRepository<DeductionType>(new DeductionTypesRepository(), logger);
            _employeesRepository = new LoggingRepository<Employee>(new EmployeesRepository(), logger);
        }

        // GET: Deductions
        public ActionResult Index()
        {
            return View(_deductionsRepository.GetAll());
        }

        // GET: Deductions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Deduction deduction = _deductionsRepository.GetById(id.Value);

            if (deduction == null)
            {
                return HttpNotFound();
            }
            return View(deduction);
        }

        // GET: Deductions/Create
        public ActionResult Create()
        {
            ViewBag.DeductionTypeID = new SelectList(_deductionTypesRepository.GetAll(), "ID", "Name");
            ViewBag.EmployeeID = new SelectList(_employeesRepository.GetAll(), "ID", "Name");
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
                Deduction newDeduction = _deductionFactory.Create(deduction.Sum, deduction.EmployeeID, deduction.DeductionTypeID);

                _deductionsRepository.Create(newDeduction);

                return RedirectToAction("Index");
            }

            ViewBag.DeductionTypeID = new SelectList(_deductionTypesRepository.GetAll(), "ID", "Name", deduction.DeductionTypeID);
            ViewBag.EmployeeID = new SelectList(_employeesRepository.GetAll(), "ID", "Name", deduction.EmployeeID);
            return View(deduction);
        }

        // GET: Deductions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Deduction deduction = _deductionsRepository.GetById(id.Value);

            if (deduction == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeductionTypeID = new SelectList(_deductionTypesRepository.GetAll(), "ID", "Name", deduction.DeductionTypeID);
            ViewBag.EmployeeID = new SelectList(_employeesRepository.GetAll(), "ID", "Name", deduction.EmployeeID);

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
                _deductionsRepository.Edit(deduction);

                return RedirectToAction("Index");
            }

            ViewBag.DeductionTypeID = new SelectList(_deductionTypesRepository.GetAll(), "ID", "Name", deduction.DeductionTypeID);
            ViewBag.EmployeeID = new SelectList(_employeesRepository.GetAll(), "ID", "Name", deduction.EmployeeID);

            return View(deduction);
        }

        // GET: Deductions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Deduction deduction = _deductionsRepository.GetById(id.Value);

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
            Deduction deduction = _deductionsRepository.GetById(id);
            _deductionsRepository.Delete(deduction);

            return RedirectToAction("Index");
        }
    }
}
