using Pri.CleanArchitecture.Music.Core.Entities;
using Pri.CleanArchitecture.Music.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Music.Core.Interfaces.Repositories
{
    public interface IArtistRepository
    {
        //CRUD
        Task<IEnumerable<Artist>> GetAllAsync();
        Task<Artist> GetByIdAsync(int id);
        IQueryable<Artist> GetAll();
        Task<bool> AddAsync(Artist newArtist);
        Task<bool> UpdateAsync(Artist toUpdate);
        Task<bool> DeleteAsync(Artist toDelete);
    }
}
