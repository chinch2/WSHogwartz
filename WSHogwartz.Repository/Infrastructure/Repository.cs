using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSHogwartz.Repository.Infrastructure.Interfaces;

namespace WSHogwartz.Repository.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await Context.Set<TEntity>().FindAsync(id);
            Context.Set<TEntity>().Remove(entityToDelete);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
