using Pri.CleanArchitecture.Music.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Music.Core.Interfaces
{
    public interface IRecordRepository
    {
        //CRUD
        Task<IEnumerable<Record>> GetAllAsync();
        Task<Record> GetByIdAsync(int id);
        IQueryable<Record> GetAll();
        Task<Record> AddAsync(Record toRecord);
    }
}
