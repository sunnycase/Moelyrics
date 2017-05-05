using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Api.Controllers.V1.ViewModels
{
    public class TrackViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan? Length { get; set; }
        public string SHA1 { get; set; }
    }
}
