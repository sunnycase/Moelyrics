using Moelyrics.Services.Metadata.Domain.AggregatesModel.AlbumAggregate;
using Moelyrics.Services.Metadata.Domain.AggregatesModel.ArtistAggregate;
using Moelyrics.Services.Metadata.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Domain.AggregatesModel
{
    public class AlbumArtist
    {
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
