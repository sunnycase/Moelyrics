using Moelyrics.Services.Metadata.Domain.AggregatesModel.ArtistAggregate;
using Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Domain.AggregatesModel
{
    public class TrackArtist
    {
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
