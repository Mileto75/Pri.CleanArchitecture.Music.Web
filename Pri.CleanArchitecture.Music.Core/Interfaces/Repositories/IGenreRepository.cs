using Pri.CleanArchitecture.Music.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Music.Core.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        //CRUD
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id);
        IQueryable<Genre> GetAll();
        Task<bool> AddAsync(Genre newGenre);
        Task<bool> UpdateAsync(Genre toUpdate);
        Task<bool> DeleteAsync(Genre toDelete);
    }
}
