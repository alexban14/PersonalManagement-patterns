using PersonalManagement.DAL;
using PersonalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Repositories
{
    public class DeductionTypesRepository
    {

        PersonalManagementContext context;

        public DeductionTypesRepository()
        {
            context = new PersonalManagementContext();
        }

        public IEnumerable<DeductionType> GetAll()
        {
            return context.DeductionTypes.ToList();
        }

        public DeductionType GetByID(int ID)
        {
            return context.DeductionTypes.Find(ID);
        }

        public bool CreateDeductionType(DeductionType deductionType)
        {
            context.DeductionTypes.Add(deductionType);

            return context.SaveChanges() > 0;
        }

        public bool UpdateDeductionType(DeductionType deductionType)
        {
            context.Entry(deductionType).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteDeductionType(DeductionType deductionType)
        {
            context.Entry(deductionType).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
        
    }
}