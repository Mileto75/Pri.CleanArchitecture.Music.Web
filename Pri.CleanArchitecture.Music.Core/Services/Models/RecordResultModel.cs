using Pri.CleanArchitecture.Music.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Music.Core.Services.Models
{
    public class RecordResultModel : BaseResultModel
    {
        public IEnumerable<Record> Records { get; set; }
    }
}
