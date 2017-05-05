using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moelyrics.Services.Metadata.Api.Controllers.V1.ViewModels;
using Moelyrics.Services.Metadata.Domain.AggregatesModel.ArtistAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArtistController : Controller
    {
        private readonly IArtistRepository _artistRepo;
        private readonly IMapper _mapper;

        public ArtistController(IArtistRepository artistRepo, IMapper mapper)
        {
            _artistRepo = artistRepo;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetArtist(int id)
        {
            var artist = await _artistRepo.GetAsync(id);
            if (artist is null)
                return NotFound();
            return Ok(_mapper.Map<ArtistViewModel>(artist));
        }
    }
}
