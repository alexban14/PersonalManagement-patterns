using PersonalManagement.DAL;
using PersonalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Repositories
{
    public class DeductionsRepository : IRepository<Deduction>
    {
        PersonalManagementContext context;

        public DeductionsRepository()
        {
            context = new PersonalManagementContext();
        }

        public IEnumerable<Deduction> GetAll()
        {
            return context.Deductions.ToList();
        }

        public Deduction GetById(int? ID)
        {
            return context.Deductions.Find(ID);
        }

        public bool Create(Deduction deduction)
        {
            context.Deductions.Add(deduction);

            return context.SaveChanges() > 0;
        }

        public bool Edit(Deduction deduction)
        {
            context.Entry(deduction).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool Delete(Deduction deduction)
        {
            context.Entry(deduction).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}