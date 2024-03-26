using PersonalManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Repositories
{
    public class LoggingRepository<T> : IRepository<T>  where T : class
    {
        private readonly IRepository<T> repository;
        private readonly ILogger logger;

        public LoggingRepository(IRepository<T> repository, ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public bool Create(T entity)
        {
            try
            {
                logger.LogCreation(typeof(T).Name, $"New entity created: {entity}");
                return repository.Create(entity);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        public bool Edit(T entity)
        {
            try
            {
                logger.LogEdit(typeof(T).Name, $"Entity with id: {entity} edited.");
                return repository.Edit(entity);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                logger.LogDeletion(typeof(T).Name, $"Entity deleted: {entity}");
                return repository.Delete(entity);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        public T GetById(int? id)
        {
            try
            {
                var entity = repository.GetById(id);
                return entity;
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                var entities = repository.GetAll();
                return entities;
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }
    }
}