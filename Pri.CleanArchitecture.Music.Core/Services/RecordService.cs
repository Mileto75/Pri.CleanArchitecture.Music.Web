using Pri.CleanArchitecture.Music.Core.Interfaces;
using Pri.CleanArchitecture.Music.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Music.Core.Services
{
    public class RecordService : IRecordService
    {
        public Task<RecordResultModel> CreateRecordAsync(RecordCreateRequestModel recordCreateRequestModel)
        {
            throw new NotImplementedException();
        }

        public Task<RecordResultModel> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RecordResultModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RecordResultModel> GetRecordsByGenreIdAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        public Task<RecordResultModel> SearchByArtistAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<RecordResultModel> SearchByPropertyAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<RecordResultModel> SearchByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }
    }
}
