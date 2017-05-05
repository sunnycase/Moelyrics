using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Moelyrics.Services.Metadata.Infrastructure;

namespace Moelyrics.Services.Metadata.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170505074248_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Moelyrics.Services.Metadata.Domain.AggregatesModel.AlbumAggregate.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("Year");

                    b.HasKey("Id");

                    b.HasIndex("Title");

                    b.ToTable("album");
                });

            modelBuilder.Entity("Moelyrics.Services.Metadata.Domain.AggregatesModel.AlbumArtist", b =>
                {
                    b.Property<int>("AlbumId");

                    b.Property<int>("ArtistId");

                    b.HasKey("AlbumId", "ArtistId");

                    b.HasIndex("ArtistId");

                    b.ToTable("albumArtist");
                });

            modelBuilder.Entity("Moelyrics.Services.Metadata.Domain.AggregatesModel.ArtistAggregate.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("artist");
                });

            modelBuilder.Entity("Moelyrics.Services.Metadata.Domain.AggregatesModel.LyricAggregate.Lyric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LrcFileName");

                    b.Property<int>("Reliability");

                    b.Property<int>("TrackId");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("lyric");
                });

            modelBuilder.Entity("Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackAggregate.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan?>("Length");

                    b.Property<string>("SHA1");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("SHA1");

                    b.HasIndex("Title");

                    b.ToTable("track");
                });

            modelBuilder.Entity("Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackArtist", b =>
                {
                    b.Property<int>("TrackId");

                    b.Property<int>("ArtistId");

                    b.HasKey("TrackId", "ArtistId");

                    b.HasIndex("ArtistId");

                    b.ToTable("trackArtist");
                });

            modelBuilder.Entity("Moelyrics.Services.Metadata.Domain.AggregatesModel.AlbumArtist", b =>
                {
                    b.HasOne("Moelyrics.Services.Metadata.Domain.AggregatesModel.AlbumAggregate.Album", "Album")
                        .WithMany("AlbumArtists")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Moelyrics.Services.Metadata.Domain.AggregatesModel.ArtistAggregate.Artist", "Artist")
                        .WithMany("AlbumArtists")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Moelyrics.Services.Metadata.Domain.AggregatesModel.LyricAggregate.Lyric", b =>
                {
                    b.HasOne("Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackAggregate.Track")
                        .WithMany("Lyrics")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackArtist", b =>
                {
                    b.HasOne("Moelyrics.Services.Metadata.Domain.AggregatesModel.ArtistAggregate.Artist", "Artist")
                        .WithMany("TrackArtists")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackAggregate.Track", "Track")
                        .WithMany("TrackArtists")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
