using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Music.Core.Services.Models
{
    public class BaseResultModel
    {
        public bool IsSucces { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
