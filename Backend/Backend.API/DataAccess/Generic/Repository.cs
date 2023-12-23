using Backend.API.DataAccess.Generic;
using Backend.API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.API.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ProyectoDBContext dbContext;

        public Repository(ProyectoDBContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual T Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();

            return entity; 
        }

        public virtual void Delete(int id)
        {
            var entity = dbContext.Set<T>().Find(id);
            if (entity != null)
            {
                dbContext.Set<T>().Remove(entity);
                dbContext.SaveChanges();
            }
        }


        public virtual List<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public virtual T? GetOne(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public virtual T Update(T entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();

            return entity;
        }
    }
}
