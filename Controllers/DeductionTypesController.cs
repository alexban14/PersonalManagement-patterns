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
    public class DeductionTypesController : Controller
    {
        private readonly IFactory<DeductionType> _deductionTypeFactory;
        private readonly IRepository<DeductionType> _repository;

        public DeductionTypesController()
        {
            _deductionTypeFactory = new DeductionTypeFactory();
            _repository = new LoggingRepository<DeductionType>(new DeductionTypesRepository(), new FileLogger("deductionTypes_controller_log"));
        }

        // GET: DeductionTypes
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: DeductionTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeductionType deductionType = _repository.GetById(id.Value);

            if (deductionType == null)
            {
                return HttpNotFound();
            }
            return View(deductionType);
        }

        // GET: DeductionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeductionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] DeductionType deductionType)
        {
            if (ModelState.IsValid)
            {
                DeductionType newDeductionType = _deductionTypeFactory.Create(deductionType.Name);

                _repository.Create(newDeductionType);

                return RedirectToAction("Index");
            }

            return View(deductionType);
        }

        // GET: DeductionTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeductionType deductionType = _repository.GetById(id.Value);

            if (deductionType == null)
            {
                return HttpNotFound();
            }
            return View(deductionType);
        }

        // POST: DeductionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] DeductionType deductionType)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(deductionType);

                return RedirectToAction("Index");
            }
            return View(deductionType);
        }

        // GET: DeductionTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeductionType deductionType = _repository.GetById(id.Value);

            if (deductionType == null)
            {
                return HttpNotFound();
            }
            return View(deductionType);
        }

        // POST: DeductionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeductionType deductionType = _repository.GetById(id);

            _repository.Delete(deductionType);

            return RedirectToAction("Index");
        }
    }
}
