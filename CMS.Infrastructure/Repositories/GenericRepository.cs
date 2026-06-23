using CMS.Infrastructre.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly Mydbcontext _context;
        protected readonly DbSet<T> _dbSet;


        public GenericRepository(Mydbcontext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        
        
        }
        public async Task<T> CreateAsync(T entity)
        {

            await _dbSet.AddAsync(entity);
            return entity;
            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity ==  null) return false;
            _dbSet.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAyc()
        {
            var entities = await _dbSet.ToListAsync();
            return entities;
        }

        public async Task<T> GetAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return null;
            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
    }
}
