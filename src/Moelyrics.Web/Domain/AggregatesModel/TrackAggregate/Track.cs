using Moelyrics.Web.Domain.AggregatesModel.ArtistAggregate;
using Moelyrics.Web.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Web.Domain.AggregatesModel.TrackAggregate
{
    public class Track : Entity, IAggregateRoot
    {
        private int? _albumId;
        private List<ArtistAlbum> _artists;
        public IEnumerable<Artist> Artists => _artists.Select(o => o.Artist).ToList().AsReadOnly();

        public string Title { get; private set; }
        public TimeSpan? Length { get; private set; }
        public string SHA1 { get; private set; }

        protected Track()
        {
            _artists = new List<ArtistAlbum>();
        }

        public Track(string title, int? albumId = null, string sha1 = null, TimeSpan? length = null)
            :this()
        {
            Title = title;
            _albumId = albumId;
            SHA1 = sha1;
            Length = length;
        }
    }
}
