using Microsoft.EntityFrameworkCore;
using news.core.Repositories.Interfaces;
using news.domain.Contexts;
using news.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.core.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context) => _context = context;

        public async Task CreateAsync(T model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public abstract IQueryable<T> BaseQuery();

        public async Task DeleteAsync(T model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await BaseQuery().ToListAsync();
        }

        public async Task UpdateAsync(T model)
        {
            await _context.SaveChangesAsync();
        }
    }
}
