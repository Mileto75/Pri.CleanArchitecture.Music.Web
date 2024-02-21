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
    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext _ApplicationDbContext;

        public GenreRepository(ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;
        }

        public Task<bool> AddAsync(Genre newGenre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Genre toDelete)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Genre> GetAll()
        {
            return _ApplicationDbContext.Genres.AsQueryable();
        }

        public Task<IEnumerable<Genre>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Genre toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
