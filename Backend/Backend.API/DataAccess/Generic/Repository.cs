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

        protected ProyectoDBContext dbcontext;
        protected DbSet<T> DbSet;
        //private readonly ProyectoDBContext dbContext;

        public Repository(ProyectoDBContext dbContext)
        {
            this.dbcontext = dbcontext;
            this.DbSet = dbcontext.Set<T>();
        }

        public virtual async Task<int> Add(T t)
        {
            await DbSet.AddAsync(t);
            await dbcontext.SaveChangesAsync();

            return (int)dbcontext.Entry(t).Property("Id").CurrentValue;
          
        }

        public virtual async Task Delete(int id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity != null)
            {
                dbcontext.Remove(entity);
                await dbcontext.SaveChangesAsync();
            }
        }


        public virtual async Task<List<T>?> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T?> GetOne(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Update(T t)
        {
            dbcontext.Update(t);
            await dbcontext.SaveChangesAsync();
        }
    }
}
