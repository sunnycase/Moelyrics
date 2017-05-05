using Moelyrics.Services.Metadata.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Domain.AggregatesModel.AlbumAggregate
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<Album> AddAsync(Album album);
        void Update(Album album);
        Task<Album> GetAsync(int id);
    }
}
