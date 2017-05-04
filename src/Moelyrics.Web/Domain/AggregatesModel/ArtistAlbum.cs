using Moelyrics.Web.Domain.AggregatesModel.AlbumAggregate;
using Moelyrics.Web.Domain.AggregatesModel.ArtistAggregate;
using Moelyrics.Web.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Web.Domain.AggregatesModel
{
    class ArtistAlbum
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
