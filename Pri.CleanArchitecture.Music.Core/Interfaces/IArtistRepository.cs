using Pri.CleanArchitecture.Music.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Music.Core.Interfaces
{
    public interface IArtistRepository
    {
        //CRUD
        Task<IEnumerable<Artist>> GetAllAsync();
        Task<Artist> GetByIdAsync(int id);
        IQueryable<Artist> GetAll();
        Task<bool> AddAsync(Artist newArtist);
    }
}
