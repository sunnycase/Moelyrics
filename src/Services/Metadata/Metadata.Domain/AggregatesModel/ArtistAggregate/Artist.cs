using Moelyrics.Services.Metadata.Domain.AggregatesModel.AlbumAggregate;
using Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackAggregate;
using Moelyrics.Services.Metadata.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Domain.AggregatesModel.ArtistAggregate
{
    public class Artist : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        private List<AlbumArtist> _albumArtists;
        public IEnumerable<AlbumArtist> AlbumArtists => _albumArtists;
        public IEnumerable<Album> Albums => AlbumArtists.Select(o => o.Album).ToList().AsReadOnly();

        private List<TrackArtist> _trackArtists;
        public IEnumerable<TrackArtist> TrackArtists => _trackArtists;
        public IEnumerable<Track> Tracks => TrackArtists.Select(o => o.Track).ToList().AsReadOnly();

        protected Artist()
        {
            _albumArtists = new List<AlbumArtist>();
            _trackArtists = new List<TrackArtist>();
        }

        public Artist(string name)
            : this()
        {
            Name = name;
        }
    }
}
