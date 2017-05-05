using Moelyrics.Services.Metadata.Domain.AggregatesModel.AlbumAggregate;
using Moelyrics.Services.Metadata.Domain.Infrastructure;
using Moelyrics.Services.Metadata.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Infrustructure.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AppDbContext _appDbContext;
        public IUnitOfWork UnitOfWork => _appDbContext;

        public AlbumRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Album> AddAsync(Album album)
        {
            return (await _appDbContext.AddAsync(album)).Entity;
        }

        public Task<Album> GetAsync(int id)
        {
            return _appDbContext.FindAsync<Album>(id);
        }

        public void Update(Album album)
        {
            _appDbContext.Update(album);
        }
    }
}
