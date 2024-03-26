using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Repositories
{
    public interface IRepository<T> where T : class
    {
        bool Create(T entity);
        bool Edit(T entity);
        bool Delete(T entity);
        T GetById(int? id);
        IEnumerable<T> GetAll();
    }
}