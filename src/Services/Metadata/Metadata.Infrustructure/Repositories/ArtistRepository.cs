using Moelyrics.Services.Metadata.Domain.AggregatesModel.ArtistAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using Moelyrics.Services.Metadata.Domain.Infrastructure;
using System.Threading.Tasks;
using Moelyrics.Services.Metadata.Infrastructure;

namespace Moelyrics.Services.Metadata.Infrustructure.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly AppDbContext _appDbContext;
        public IUnitOfWork UnitOfWork => _appDbContext;

        public ArtistRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Artist> AddAsync(Artist artist)
        {
            return (await _appDbContext.AddAsync(artist)).Entity;
        }

        public Task<Artist> GetAsync(int id)
        {
            return _appDbContext.FindAsync<Artist>(id);
        }

        public void Update(Artist artist)
        {
            _appDbContext.Update(artist);
        }
    }
}
