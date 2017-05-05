using Moelyrics.Services.Metadata.Domain.AggregatesModel.ArtistAggregate;
using Moelyrics.Services.Metadata.Domain.AggregatesModel.LyricAggregate;
using Moelyrics.Services.Metadata.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackAggregate
{
    public class Track : Entity, IAggregateRoot
    {
        private int? _albumId;
        private List<TrackArtist> _trackArtists;
        public IEnumerable<TrackArtist> TrackArtists => _trackArtists;
        public IEnumerable<Artist> Artists => TrackArtists.Select(o => o.Artist).ToList().AsReadOnly();

        public string Title { get; private set; }
        public TimeSpan? Length { get; private set; }
        public string SHA1 { get; private set; }

        private List<Lyric> _lyrics;
        public IEnumerable<Lyric> Lyrics => _lyrics.AsReadOnly();

        protected Track()
        {
            _trackArtists = new List<TrackArtist>();
            _lyrics = new List<Lyric>();
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
