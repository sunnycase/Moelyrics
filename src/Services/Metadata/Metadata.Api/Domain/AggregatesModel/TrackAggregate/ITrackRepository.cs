using Moelyrics.Web.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Web.Domain.AggregatesModel.TrackAggregate
{
    public interface ITrackRepository : IRepository<Track>
    {
        Track Add(Track track);
        void Update(Track track);
        Task<Track> GetAsync(int id);
    }
}
