using Moelyrics.Web.Domain.AggregatesModel.ArtistAggregate;
using Moelyrics.Web.Domain.AggregatesModel.TrackAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Web.Domain.AggregatesModel
{
    class TrackArtist
    {
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
