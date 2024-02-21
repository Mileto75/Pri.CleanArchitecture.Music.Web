using Microsoft.EntityFrameworkCore;
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
        private readonly IGenreRepository _genreRepository;
        private readonly IArtistRepository _artistRepository;

        public RecordService(IRecordRepository recordRepository, IGenreRepository genreRepository, IArtistRepository artistRepository)
        {
            _recordRepository = recordRepository;
            _genreRepository = genreRepository;
            _artistRepository = artistRepository;
        }

        public async Task<RecordResultModel> CreateRecordAsync(RecordCreateRequestModel recordCreateRequestModel)
        {
            //check if genreId exists
            if(await _genreRepository.GetAll().AnyAsync(g => g.Id == recordCreateRequestModel.GenreId == false))
            {
                return new RecordResultModel
                {
                    IsSucces = false,
                    Errors = new List<string> { "Genre does not exist!" }
                };
            }
            //check if artistId exists
            if(await _artistRepository.GetAll().AnyAsync(a => a.Id == recordCreateRequestModel.ArtistId
            == false)) 
            {
                return new RecordResultModel
                {
                    IsSucces = false,
                    Errors = new List<string> { "Artist does not exist!" }
                };
            }
            var record = new Record
            {
                Title = recordCreateRequestModel.Title,
                GenreId = recordCreateRequestModel.GenreId,
                ArtistId = recordCreateRequestModel.ArtistId,
                Price = recordCreateRequestModel.Price,
            };
            //call the repo
            var result = await _recordRepository.AddAsync(record);
            //check  result
            if(result)
            {
                return new RecordResultModel
                {
                    IsSucces = true,
                    Records = new List<Record> { record },
                };
            }
            return new RecordResultModel
            {
                IsSucces = false,
                Errors = new List<string> { "Record not created!" }
            };
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
