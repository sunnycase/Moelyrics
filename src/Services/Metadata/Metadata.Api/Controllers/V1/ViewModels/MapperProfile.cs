using AutoMapper;
using Moelyrics.Services.Metadata.Domain.AggregatesModel.AlbumAggregate;
using Moelyrics.Services.Metadata.Domain.AggregatesModel.ArtistAggregate;
using Moelyrics.Services.Metadata.Domain.AggregatesModel.LyricAggregate;
using Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Api.Controllers.V1.ViewModels
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Artist, ArtistViewModel>(MemberList.Destination);
            CreateMap<Album, AlbumViewModel>(MemberList.Destination);
            CreateMap<Track, TrackViewModel>(MemberList.Destination);
            CreateMap<Lyric, LyricViewModel>(MemberList.Destination);
        }
    }
}
