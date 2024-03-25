using PersonalManagement.DAL;
using PersonalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Repositories
{
    public class DeductionsRepository
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

        public Deduction GetDeductionByID(int ID)
        {
            return context.Deductions.Find(ID);
        }

        public bool CreateDeduction(Deduction deduction)
        {
            context.Deductions.Add(deduction);

            return context.SaveChanges() > 0;
        }

        public bool UpdateDeduction(Deduction deduction)
        {
            context.Entry(deduction).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteDeduction(Deduction deduction)
        {
            context.Entry(deduction).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}