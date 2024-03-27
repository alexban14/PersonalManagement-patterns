using PersonalManagement.DAL;
using PersonalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Repositories
{
    public class DeductionTypesRepository : IRepository<DeductionType>
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

        public DeductionType GetById(int? ID)
        {
            return context.DeductionTypes.Find(ID);
        }

        public bool Create(DeductionType deductionType)
        {
            context.DeductionTypes.Add(deductionType);

            return context.SaveChanges() > 0;
        }

        public bool Edit(DeductionType deductionType)
        {
            context.Entry(deductionType).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool Delete(DeductionType deductionType)
        {
            context.Entry(deductionType).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
        
    }
}