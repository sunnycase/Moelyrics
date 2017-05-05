using Moelyrics.Services.Metadata.Domain.AggregatesModel.ArtistAggregate;
using Moelyrics.Services.Metadata.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Domain.AggregatesModel.AlbumAggregate
{
    public class Album : Entity, IAggregateRoot
    {
        private List<AlbumArtist> _albumArtists;
        public IEnumerable<AlbumArtist> AlbumArtists => _albumArtists;
        public IEnumerable<Artist> Artists => AlbumArtists.Select(o => o.Artist).ToList().AsReadOnly();

        public string Title { get; private set; }
        public int? Year { get; private set; }

        protected Album()
        {
            _albumArtists = new List<AlbumArtist>();
        }

        public Album(string title, int? year = null)
            :this()
        {
            Title = title;
            Year = year;
        }
    }
}
