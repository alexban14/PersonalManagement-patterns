using PersonalManagement.DAL;
using PersonalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Repositories
{
    public class EmployeesRepository : IRepository<Employee>
    {
        PersonalManagementContext context;

        public EmployeesRepository()
        {
            context = new PersonalManagementContext();
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int? ID)
        {
            return context.Employees.Find(ID);
        }

        public bool Create(Employee employee)
        {
            context.Employees.Add(employee);

            return context.SaveChanges() > 0;
        }

        public bool Edit(Employee employee)
        {
            context.Entry(employee).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool Delete(Employee employee)
        {
            context.Entry(employee).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}