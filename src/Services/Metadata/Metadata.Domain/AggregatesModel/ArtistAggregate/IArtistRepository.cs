using Moelyrics.Services.Metadata.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Domain.AggregatesModel.ArtistAggregate
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<Artist> AddAsync(Artist artist);
        void Update(Artist artist);
        Task<Artist> GetAsync(int id);
    }
}
