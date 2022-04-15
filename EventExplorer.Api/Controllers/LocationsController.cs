using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Requests;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventExplorer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LocationsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetLocations()
        {
            var locations =
                _context.Locations.ToList();

            var locationResponseResources =
                _mapper.Map<IEnumerable<Location>, IEnumerable<LocationResponseResource>>(locations);

            return Ok(locationResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetLocation(int id)
        {
            var location = _context.Locations.SingleOrDefault(l => l.Id == id);

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

            var location = _mapper.Map<CreateLocationRequestResource, Location>(request);

            _context.Locations.Add(location);
            _context.SaveChanges();

            var locationResponseResource = _mapper.Map<Location, LocationResponseResource>(location);

            return Ok(locationResponseResource);
        }
    }
}
