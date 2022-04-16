using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Requests;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EventExplorer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class LocationsController : ControllerBase
    {
        private readonly LocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationsController(
            LocationRepository locationRepository,
            IMapper mapper
            )
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetLocations()
        {
            var locations =
                _locationRepository.GetLocations();

            var locationResponseResources =
                _mapper.Map<IEnumerable<Location>, IEnumerable<LocationResponseResource>>(locations);

            return Ok(locationResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetLocation(int id)
        {
            var location =
                _locationRepository.GetLocation(id);

            if (location == null)
            {
                return NotFound("Location not found with id: " + id);
            }

            var locationResponseResource =
                _mapper.Map<Location, LocationResponseResource>(location);

            return Ok(locationResponseResource);
        }

        [HttpPost]
        public IActionResult CreateLocation([FromBody] CreateLocationRequestResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location =
                _mapper.Map<CreateLocationRequestResource, Location>(request);

            _locationRepository.Add(location);

            location =
                _locationRepository.GetLocation(location.Id);

            var locationResponseResource =
                _mapper.Map<Location, LocationResponseResource>(location);

            return Ok(locationResponseResource);
        }
    }
}
