using InterSport.Domain.Interfaces.Repositories;
using InterSport.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace InterSport.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository()
        {
        }
        public async Task<T> AddAsync(T entity)
        {
            using (var _context = new InterSportContext())
            {
                await _context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task DeleteAsync(T entity)
        {
            using (var _context = new InterSportContext())
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var _context = new InterSportContext())
            {
                return await _context.Set<T>().ToListAsync();
            }
        }

        public virtual async Task<T> GetByIdAsync(T id)
        {
            using (var _context = new InterSportContext())
            {
                return await _context.Set<T>().FindAsync(id);
            }

        }

        public async Task UpdateAsync(T entity)
        {
            using (var _context = new InterSportContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
