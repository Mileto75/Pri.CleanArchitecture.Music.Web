using Pri.CleanArchitecture.Music.Core.Entities;
using Pri.CleanArchitecture.Music.Core.Interfaces.Repositories;
using Pri.CleanArchitecture.Music.Core.Interfaces.Services;
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
        private readonly IRecordRepository _recordRepository;

        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public Task<RecordResultModel> CreateRecordAsync(RecordCreateRequestModel recordCreateRequestModel)
        {
            throw new NotImplementedException();
        }

        public async Task<RecordResultModel> GetAllAsync()
        {
            //get the records from the RecordRepository
            var records = await _recordRepository.GetAllAsync();
            //check if count > 0
            var recordResultModel = new RecordResultModel();
            if (records.Count() > 0) 
            {
                recordResultModel.Records = records;
                recordResultModel.IsSucces = true;
                return recordResultModel;
            }
            recordResultModel.Errors = new List<string> { "No records found!" };
            return recordResultModel;
        }

        public async Task<RecordResultModel> GetByIdAsync(int id)
        {
            //get the record
            var record = await _recordRepository.GetByIdAsync(id);
            var recordresultModel = new RecordResultModel();
            //check if exists
            if(record == null)
            {
                recordresultModel.Errors = new List<string> { "Record not found!" };
                return recordresultModel;
            }
            recordresultModel.Records = new List<Record> { record };
            recordresultModel.IsSucces = true;
            return recordresultModel;
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
