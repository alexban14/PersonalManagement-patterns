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
    public class DeductionTypesController : Controller
    {
        private readonly IFactory<DeductionType> deductionTypeFactory;
        private readonly DeductionTypesRepository deductionTypesRepository;

        public DeductionTypesController()
        {
            deductionTypeFactory = new DeductionTypeFactory();
            deductionTypesRepository = new DeductionTypesRepository();
        }

        // GET: DeductionTypes
        public ActionResult Index()
        {
            return View(deductionTypesRepository.GetAll());
        }

        // GET: DeductionTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeductionType deductionType = deductionTypesRepository.GetByID(id.Value);

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
                DeductionType newDeductionType = deductionTypeFactory.Create(deductionType.Name);

                deductionTypesRepository.CreateDeductionType(newDeductionType);

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

            DeductionType deductionType = deductionTypesRepository.GetByID(id.Value);

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
                deductionTypesRepository.UpdateDeductionType(deductionType);

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

            DeductionType deductionType = deductionTypesRepository.GetByID(id.Value);

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
            DeductionType deductionType = deductionTypesRepository.GetByID(id);

            deductionTypesRepository.DeleteDeductionType(deductionType);

            return RedirectToAction("Index");
        }
    }
}
