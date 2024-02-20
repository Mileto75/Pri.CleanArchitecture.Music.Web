using Pri.CleanArchitecture.Music.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Music.Core.Interfaces.Repositories
{
    public interface IRecordRepository
    {
        //CRUD
        Task<IEnumerable<Record>> GetAllAsync();
        Task<Record> GetByIdAsync(int id);
        IQueryable<Record> GetAll();
        Task<bool> AddAsync(Record toRecord);
        Task<bool> UpdateAsync(Record toUpdate);
        Task<bool> DeleteAsync(Record toDelete);
        Task<bool> GetRecordsByGenreIdAsync(int genreId);
        Task<bool> GetRecordsByArtistIdAsync(int genreId);
    }
}
