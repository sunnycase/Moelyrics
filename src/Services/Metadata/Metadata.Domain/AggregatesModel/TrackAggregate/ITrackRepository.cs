using Moelyrics.Services.Metadata.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackAggregate
{
    public interface ITrackRepository : IRepository<Track>
    {
        Task<Track> AddAsync(Track track);
        void Update(Track track);
        Task<Track> GetAsync(int id);
    }
}
