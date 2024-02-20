using Microsoft.AspNetCore.Mvc;
using Pri.CleanArchitecture.Music.Core.Interfaces;
using Pri.CleanArchitecture.Music.Web.ViewModels;

namespace Pri.CleanArchitecture.Music.Web.Controllers
{
    public class RecordsController : Controller
    {
        private readonly IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _recordService.GetAllAsync();
            if(result.IsSucces)
            {
                //set the viewmodel
                var recordsIndexViewModel = new RecordsIndexViewModel
                {
                    Records = result.Records.Select(r =>
                    new RecordsDetailViewModel
                    {
                        Id = r.Id,
                        Title = r.Title,
                        Artist = r.Artist.Name,
                        Genre = r.Genre.Name,
                    })
                };
                return View(recordsIndexViewModel);
            }
            return View("Error",result.Errors);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _recordService.GetByIdAsync(id);
            if(result.IsSucces)
            {
                var recordsDetailViewModel = new RecordsDetailViewModel
                {
                    Id = result.Records.First().Id,
                    Title = result.Records.First().Title,
                    Artist = result.Records.First().Artist.Name,
                    Genre = result.Records.First().Genre.Name,
                };
                return View(recordsDetailViewModel);
            }
            Response.StatusCode = 404;
            return View("Error", result.Errors);
        }
    }
}
