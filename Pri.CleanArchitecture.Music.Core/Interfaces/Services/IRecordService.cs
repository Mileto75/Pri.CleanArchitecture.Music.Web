using Pri.CleanArchitecture.Music.Core.Entities;
using Pri.CleanArchitecture.Music.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Music.Core.Interfaces.Services
{
    public interface IRecordService
    {
        Task<RecordResultModel> GetAllAsync();
        Task<RecordResultModel> GetByIdAsync(int id);
        Task<RecordResultModel> SearchByTitleAsync(string title);
        Task<RecordResultModel> SearchByPropertyAsync(string name);
        Task<RecordResultModel> SearchByArtistAsync(string name);
        Task<RecordResultModel> GetRecordsByGenreIdAsync(int genreId);
        Task<RecordResultModel> CreateRecordAsync(RecordCreateRequestModel recordCreateRequestModel);
        Task<RecordResultModel> UpdateRecordAsync(RecordUpdateRequestModel recordUpdateRequestModel);
        Task<RecordResultModel> DeleteRecordAsync(int id);
    }
}
