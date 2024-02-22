﻿using Microsoft.EntityFrameworkCore;
using Pri.CleanArchitecture.Music.Core.Entities;
using Pri.CleanArchitecture.Music.Core.Interfaces.Repositories;
using Pri.CleanArchitecture.Music.Core.Interfaces.Services;
using Pri.CleanArchitecture.Music.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public async Task<ResultModel<Record>> CreateRecordAsync(RecordCreateRequestModel recordCreateRequestModel)
        {
            //check if genreId exists
            if(await _genreRepository.GetAll().AnyAsync(g => g.Id == recordCreateRequestModel.GenreId) == false)
            {
                return new ResultModel<Record>
                {
                    IsSucces = false,
                    Errors = new List<string> { "Genre does not exist!" }
                };
            }
            //check if artistId exists
            if(await _artistRepository.GetAll().AnyAsync(a => a.Id == recordCreateRequestModel.ArtistId)
            == false) 
            {
                return new ResultModel<Record>
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
                return new ResultModel<Record>
                {
                    IsSucces = true,
                    Value =  record,
                };
            }
            return new ResultModel<Record>
            {
                IsSucces = false,
                Errors = new List<string> { "Record not created!" }
            };
        }

        public async Task<ResultModel<Record>> DeleteRecordAsync(int id)
        {
            var record = await _recordRepository.GetByIdAsync(id);
            if(record == null)
            {
                return new ResultModel<Record>
                {
                    IsSucces = false,
                    Errors = new List<string> { "Record does not exist!" }
                };
            }
            if(await _recordRepository.DeleteAsync(record))
            {
                return new ResultModel<Record> { IsSucces = true };
            }
            return new ResultModel<Record>
            {
                IsSucces = false,
                Errors = new List<string> { "Some error occurred!" }
            };
        }

        public async Task<ResultModel<IEnumerable<Record>>> GetAllAsync()
        {
            //get the records from the RecordRepository
            var records = await _recordRepository.GetAllAsync();
            //check if count > 0
            var recordResultModel = new ResultModel<IEnumerable<Record>>();
            if (records.Count() > 0) 
            {
                recordResultModel.Value = records;
                recordResultModel.IsSucces = true;
                return recordResultModel;
            }
            recordResultModel.Errors = new List<string> { "No records found!" };
            return recordResultModel;
        }

        public async Task<ResultModel<Record>> GetByIdAsync(int id)
        {
            //get the record
            var record = await _recordRepository.GetByIdAsync(id);
            var recordresultModel = new ResultModel<Record>();
            //check if exists
            if(record == null)
            {
                recordresultModel.Errors = new List<string> { "Record not found!" };
                return recordresultModel;
            }
            recordresultModel.Value =  record ;
            recordresultModel.IsSucces = true;
            return recordresultModel;
        }

        public async Task<ResultModel<IEnumerable<Record>>> GetRecordsByGenreIdAsync(int genreId)
        {
            var records = await _recordRepository.GetRecordsByGenreIdAsync(genreId);
            if(records.Count() > 0)
            {
                return new ResultModel<IEnumerable<Record>>
                {
                    Value = records,
                    IsSucces = true
                };
            }
            return new ResultModel<IEnumerable<Record>>
            {
                IsSucces = false,
                Errors = new List<string> { "No records found" }
            };
        }

        public async Task<ResultModel<IEnumerable<Record>>> SearchByArtistAsync(string name)
        {
            var records = await _recordRepository.GetAll()
                .Include(r => r.Artist)
                .Include(r => r.Genre)
                .Include(r => r.Properties)
                .Where(r => r.Artist.Name.ToUpper().Contains(name.ToUpper()))
                .ToListAsync();
            if (records.Count() > 0)
            {
                return new ResultModel<IEnumerable<Record>>
                {
                    Value = records,
                    IsSucces = true
                };
            }
            return new ResultModel<IEnumerable<Record>>
            {
                IsSucces = false,
                Errors = new List<string> { "No records found" }
            };
        }

        public async Task<ResultModel<IEnumerable<Record>>> SearchByPropertyAsync(string name)
        {
            var records = await _recordRepository.GetAll()
                .Include(r => r.Artist)
                .Include(r => r.Genre)
                .Include(r => r.Properties)
                .Where(r => r.Properties.Any(p => p.Name.ToUpper().Contains(name.ToUpper())))
                .ToListAsync();
            if (records.Count() > 0)
            {
                return new ResultModel<IEnumerable<Record>>
                {
                    Value = records,
                    IsSucces = true
                };
            }
            return new ResultModel<IEnumerable<Record>>
            {
                IsSucces = false,
                Errors = new List<string> { "No records found" }
            };
        }

        public async Task<ResultModel<IEnumerable<Record>>> SearchByTitleAsync(string title)
        {
            var records = await _recordRepository.GetAll()
                .Include(r => r.Artist)
                .Include(r => r.Genre)
                .Include(r => r.Properties)
                .Where(r => r.Title.ToUpper().Contains(title.ToUpper()))
                .ToListAsync();
            if (records.Count() > 0)
            {
                return new ResultModel<IEnumerable<Record>>
                {
                    Value = records,
                    IsSucces = true
                };
            }
            return new ResultModel<IEnumerable<Record>>
            {
                IsSucces = false,
                Errors = new List<string> { "No records found" }
            };
        }

        public async Task<ResultModel<Record>> UpdateRecordAsync(RecordUpdateRequestModel recordUpdateRequestModel)
        {
            //check if genreId exists
            if (await _genreRepository.GetAll().AnyAsync(g => g.Id == recordUpdateRequestModel.GenreId) == false)
            {
                return new ResultModel<Record>
                {
                    IsSucces = false,
                    Errors = new List<string> { "Genre does not exist!" }
                };
            }
            //check if artistId exists
            if (await _genreRepository.GetAll().AnyAsync(g => g.Id == recordUpdateRequestModel.ArtistId) == false)
            {
                return new ResultModel<Record>
                {
                    IsSucces = false,
                    Errors = new List<string> { "Artist does not exist!" }
                };
            }
            //check if record exists
            var record = await _recordRepository.GetByIdAsync(recordUpdateRequestModel.Id);
            if(record == null)
            {
                return new ResultModel<Record>
                {
                    IsSucces = false,
                    Errors = new List<string> { "Record not found" }
                };
            }
            //update
            record.Title = recordUpdateRequestModel.Title;
            record.GenreId = recordUpdateRequestModel.GenreId;
            record.ArtistId = recordUpdateRequestModel.ArtistId;
            record.Price = recordUpdateRequestModel.Price;
            if(await  _recordRepository.UpdateAsync(record))
            {
                return new ResultModel<Record>
                {
                    IsSucces = true,
                    Value = record,
                };
            }
            return new ResultModel<Record>
            {
                IsSucces = false,
                Errors = new List<string> { "Record update failed!" }
            };
        }
    }
}
