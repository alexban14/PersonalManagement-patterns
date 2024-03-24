using PersonalManagement.DAL;
using PersonalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Repositories
{
    public class EmployeesRepository
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

        public Employee GetEmployeeByID(int ID)
        {
            return context.Employees.Find(ID);
        }

        public bool CreateEmployee(Employee employee)
        {
            context.Employees.Add(employee);

            return context.SaveChanges() > 0;
        }

        public bool UpdateEmployee(Employee employee)
        {
            context.Entry(employee).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteEmployee(Employee employee)
        {
            context.Entry(employee).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}