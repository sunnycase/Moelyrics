using Moelyrics.Web.Domain.AggregatesModel.AlbumAggregate;
using Moelyrics.Web.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Web.Domain.AggregatesModel.ArtistAggregate
{
    public class Artist : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        private List<ArtistAlbum> _albums;
        public IEnumerable<Album> Albums => _albums.Select(o => o.Album).ToList().AsReadOnly();
        protected Artist()
        {
            _albums = new List<ArtistAlbum>();
        }

        public Artist(string name)
            : this()
        {
            Name = name;
        }
    }
}
