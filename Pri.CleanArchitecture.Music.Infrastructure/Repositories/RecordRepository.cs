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
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Record toDelete)
        {
            _applicationDbContext.Records.Remove(toDelete);
            return await SaveChangesAsync();
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

        public async Task<IEnumerable<Record>> GetRecordsByArtistIdAsync(int artistId)
        {
            return await _applicationDbContext
                .Records
                .Include(r => r.Genre)
                .Include(r => r.Properties)
                .Include(r => r.Artist)
                .Where(r => r.ArtistId == artistId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Record>> GetRecordsByGenreIdAsync(int genreId)
        {
            return await _applicationDbContext
                .Records
                .Include(r => r.Genre)
                .Include(r => r.Properties)
                .Include(r => r.Artist)
                .Where(r => r.GenreId == genreId)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Record toUpdate)
        {
            _applicationDbContext.Records.Update(toUpdate);
            return await SaveChangesAsync();
        }
        private async Task<bool> SaveChangesAsync()
        {
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
    }
}
