using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Api.Controllers.V1.ViewModels
{
    public class LyricViewModel
    {
        public int Reliability { get; set; }
        public string LrcFileName { get; set; }
    }
}
