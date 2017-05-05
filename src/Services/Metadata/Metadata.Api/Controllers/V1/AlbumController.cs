using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moelyrics.Services.Metadata.Api.Controllers.V1.ViewModels;
using Moelyrics.Services.Metadata.Domain.AggregatesModel.AlbumAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlbumController : Controller
    {
        private readonly IAlbumRepository _albumRepo;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumRepository albumRepo, IMapper mapper)
        {
            _albumRepo = albumRepo;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAlbum(int id)
        {
            var album = await _albumRepo.GetAsync(id);
            if (album is null)
                return NotFound();
            return Ok(_mapper.Map<AlbumViewModel>(album));
        }
    }
}
