using Microsoft.EntityFrameworkCore;
using Pri.CleanArchitecture.Music.Core.Entities;
using Pri.CleanArchitecture.Music.Core.Interfaces;
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

        public RecordRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<Record> AddAsync(Record toRecord)
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
            return await _applicationDbContext.Records.ToListAsync();
        }

        public Task<Record> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
