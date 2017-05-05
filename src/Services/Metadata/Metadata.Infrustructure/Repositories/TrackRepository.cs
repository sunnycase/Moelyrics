using Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moelyrics.Services.Metadata.Domain.Infrastructure;

namespace Moelyrics.Services.Metadata.Infrastructure.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly AppDbContext _appDbContext;
        public IUnitOfWork UnitOfWork => _appDbContext;

        public TrackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Track> AddAsync(Track track)
        {
            return (await _appDbContext.AddAsync(track)).Entity;
        }

        public Task<Track> GetAsync(int id)
        {
            return _appDbContext.FindAsync<Track>(id);
        }

        public void Update(Track track)
        {
            _appDbContext.Update(track);
        }
    }
}
