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
    public class RecordRepository : IRecordRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<RecordRepository> _logger;

        public RecordRepository(ApplicationDbContext applicationDbContext, ILogger<RecordRepository> logger = null)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public async Task<bool> AddAsync(Record toRecord)
        {
            _applicationDbContext.Records.Add(toRecord);
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

        public Task<bool> DeleteAsync(Record toDelete)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Record> GetAll()
        {
            return _applicationDbContext
                .Records.AsQueryable();
        }

        public async Task<IEnumerable<Record>> GetAllAsync()
        {
            return await _applicationDbContext.Records
                .Include(r => r.Genre)
                .Include(r => r.Properties)
                .Include(r => r.Artist)
                .ToListAsync();
        }

        public async Task<Record> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Records
                .Include(r => r.Genre)
                .Include(r => r.Properties)
                .Include(r => r.Artist)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<bool> GetRecordsByArtistIdAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetRecordsByGenreIdAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Record toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
