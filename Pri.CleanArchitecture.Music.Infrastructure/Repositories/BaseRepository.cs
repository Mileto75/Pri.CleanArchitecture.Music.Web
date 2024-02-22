using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pri.CleanArchitecture.Music.Core.Entities;
using Pri.CleanArchitecture.Music.Core.Interfaces.Repositories;
using Pri.CleanArchitecture.Music.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Music.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<IBaseRepository<T>> _logger;

        public BaseRepository(ApplicationDbContext applicationDbContext, ILogger<IBaseRepository<T>> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public async Task<bool> AddAsync(T toAdd)
        {
            _applicationDbContext.Set<T>().Add(toAdd);
            try
            {
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbUpdateException)
            {
                _logger.LogError(dbUpdateException.Message);
                return false;
            }
        }

        public Task<bool> DeleteAsync(T toDelete)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _applicationDbContext
                .Set<T>().AsQueryable();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _applicationDbContext
                .Set<T>()
                .ToListAsync();
        }

        public virtual Task<T> GetByIdAsync(int id)
        {
            return _applicationDbContext
                .Set<T>()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public Task<bool> UpdateAsync(T toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
