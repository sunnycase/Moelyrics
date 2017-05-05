using Moelyrics.Web.Domain.AggregatesModel.ArtistAggregate;
using Moelyrics.Web.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Web.Domain.AggregatesModel.AlbumAggregate
{
    public class Album : Entity, IAggregateRoot
    {
        private List<AlbumArtist> _artists;
        public IEnumerable<Artist> Artists => _artists.Select(o => o.Artist).ToList().AsReadOnly();

        public string Title { get; private set; }
        public int? Year { get; private set; }

        protected Album()
        {
            _artists = new List<AlbumArtist>();
        }

        public Album(string title, int? year = null)
            :this()
        {
            Title = title;
            Year = year;
        }
    }
}
