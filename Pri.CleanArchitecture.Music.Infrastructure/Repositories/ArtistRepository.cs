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
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ArtistRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<bool> AddAsync(Artist newArtist)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Artist toDelete)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Artist> GetAll()
        {
            return  _applicationDbContext.Artists.AsQueryable();
        }

        public Task<IEnumerable<Artist>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Artist> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Artist toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
