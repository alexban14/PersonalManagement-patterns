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
    public class EmployeesController : Controller
    {
        private readonly IFactory<Employee> employeeFactory;
        private readonly EmployeesRepository employeesRepository;

        public EmployeesController()
        {
            employeeFactory = new EmployeeFactory();
            employeesRepository = new EmployeesRepository();
        }

        // GET: Employees
        public ActionResult Index(string sortOrder, string searchTerm)
        {
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.ProfessionSortParam = sortOrder ==  "profession" ? "profession_desc" : "profession";
            ViewBag.EmploymentDateSortParm = sortOrder == "employment_date" ? "employment_date_desc" : "employment_date";

            var employees = employeesRepository.GetAll();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                employees = employees.Where(e => e.Name.Contains(searchTerm) || e.LastName.Contains(searchTerm));
            }
            switch (sortOrder)
            {
                case "name":
                    employees = employees.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.Name);
                    break;
                case "profession":
                    employees = employees.OrderBy(s => s.Profession);
                    break;
                case "profession_desc":
                    employees = employees.OrderByDescending(s => s.Profession);
                    break;
                case "employment_date":
                    employees = employees.OrderBy(s => s.EmployedDate);
                    break;
                case "employment_date_desc":
                    employees = employees.OrderByDescending(s => s.EmployedDate);
                    break;
                default:
                    employees = employees.OrderBy(s => s.LastName);
                    break;
            }
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeesRepository.GetEmployeeByID(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,LastName,Profession,EmployedDate,BirthDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = employeeFactory.Create(employee.Name, employee.LastName, employee.Profession, employee.EmployedDate, employee.BirthDate);
                employeesRepository.CreateEmployee(newEmployee);

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = employeesRepository.GetEmployeeByID(id.Value);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,LastName,Profession,EmployedDate,BirthDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeesRepository.UpdateEmployee(employee);

                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = employeesRepository.GetEmployeeByID(id.Value);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = employeesRepository.GetEmployeeByID(id);
            employeesRepository.DeleteEmployee(employee);

            return RedirectToAction("Index");
        }
    }
}
