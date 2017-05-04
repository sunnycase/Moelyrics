using MediatR;
using Microsoft.EntityFrameworkCore;
using Moelyrics.Web.Domain.AggregatesModel.ArtistAggregate;
using Moelyrics.Web.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moelyrics.Web.Domain.AggregatesModel.AlbumAggregate;
using Microsoft.EntityFrameworkCore.Metadata;
using Moelyrics.Web.Domain.AggregatesModel.TrackAggregate;

namespace Moelyrics.Web.Infrastructure
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }

        private readonly IMediator _mediator;
        public AppDbContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(ConfigureArtist);
            modelBuilder.Entity<Album>(ConfigureAlbum);
            modelBuilder.Entity<Track>(ConfigureTrack);
        }

        private void ConfigureArtist(EntityTypeBuilder<Artist> config)
        {
            config.ToTable("artist");

            config.HasKey(o => o.Id);

            config.Ignore(o => o.DomainEvents);

            config.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();

            config.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            config.HasIndex(o => o.Name)
                .IsUnique(false);

            config.Metadata.FindNavigation(nameof(Artist.Albums))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureAlbum(EntityTypeBuilder<Album> config)
        {
            config.ToTable("album");

            config.HasKey(o => o.Id);

            config.Ignore(o => o.DomainEvents);

            config.Property(o => o.Title)
                .HasMaxLength(200)
                .IsRequired();

            config.HasIndex(o => o.Title)
                .IsUnique(false);

            config.Metadata.FindNavigation(nameof(Album.Artists))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureTrack(EntityTypeBuilder<Track> config)
        {
            config.ToTable("track");

            config.HasKey(o => o.Id);

            config.Ignore(o => o.DomainEvents);

            config.Property(o => o.Title)
                .HasMaxLength(200)
                .IsRequired();

            config.HasIndex(o => o.Title)
                .IsUnique(false);

            config.HasIndex(o => o.SHA1)
                .IsUnique(false);

            config.Metadata.FindNavigation(nameof(Track.Artists))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);


            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed throught the DbContext will be commited
            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
