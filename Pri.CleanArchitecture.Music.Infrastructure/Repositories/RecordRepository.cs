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
    public class RecordRepository : BaseRepository<Record>, IRecordRepository
    {
        public RecordRepository(ApplicationDbContext applicationDbContext, ILogger<IBaseRepository<Record>> logger) 
            : base(applicationDbContext, logger)
        {
        }

        public override IQueryable<Record> GetAll()
        {
            return base.GetAll();
        }

        public override Task<IEnumerable<Record>> GetAllAsync()
        {
            return base.GetAllAsync();
        }

        public override Task<Record> GetByIdAsync(int id)
        {
            return base.GetByIdAsync(id);
        }

        public Task<IEnumerable<Record>> GetRecordsByArtistIdAsync(int artistId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Record>> GetRecordsByGenreIdAsync(int genreId)
        {
            throw new NotImplementedException();
        }
    }
}
