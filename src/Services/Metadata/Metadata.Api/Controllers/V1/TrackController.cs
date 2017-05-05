using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moelyrics.Services.Metadata.Api.Controllers.V1.ViewModels;
using Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TrackController : Controller
    {
        private readonly ITrackRepository _trackRepo;
        private readonly IMapper _mapper;

        public TrackController(ITrackRepository trackRepo, IMapper mapper)
        {
            _trackRepo = trackRepo;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTrack(int id)
        {
            var track = await _trackRepo.GetAsync(id);
            if (track is null)
                return NotFound();
            return Ok(_mapper.Map<TrackViewModel>(track));
        }

        [HttpGet("{id:int}/lyrics")]
        public async Task<IActionResult> GetTrackLyrics(int id)
        {
            var track = await _trackRepo.GetAsync(id);
            if (track is null)
                return NotFound();
            return Ok(_mapper.Map<LyricViewModel[]>(track.Lyrics));
        }

        [HttpGet("search/{title:required}")]
        public async Task<IActionResult> Search(string title, [FromQuery]string artist, [FromQuery]string album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok();
        }
    }
}
