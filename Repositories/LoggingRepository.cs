using PersonalManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                var id = GetEntityId(entity);

                logger.LogEdit(typeof(T).Name, $"Entity edited: ID={id}.");

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
                var id = GetEntityId(entity);

                logger.LogDeletion(typeof(T).Name, $"Entity deleted: ID={id}.");
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

        // helper methods
        private int GetEntityId(T entity)
        {
            Type entityType = entity.GetType();

            PropertyInfo idProperty = entityType.GetProperty("ID");

            if (idProperty != null && idProperty.PropertyType == typeof(int))
            {
                int id = (int)idProperty.GetValue(entity);
                return id;
            }
            else
            {
                throw new InvalidOperationException("Entity does not have a valid ID property.");
            }
        }
    }
}