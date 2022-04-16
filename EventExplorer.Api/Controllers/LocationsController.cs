using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Requests;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EventExplorer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class LocationsController : ControllerBase
    {
        private readonly LocationService _locationService;
        private readonly IMapper _mapper;

        public LocationsController(
            LocationService locationService,
            IMapper mapper
        )
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetLocations()
        {
            var locations =
                _locationService.GetLocations();

            var locationResponseResources =
                _mapper.Map<IEnumerable<Location>, IEnumerable<LocationResponseResource>>(locations);

            return Ok(locationResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetLocation(int id)
        {
            try
            {
                var location =
                        _locationService.GetLocation(id);

                var locationResponseResource =
                    _mapper.Map<Location, LocationResponseResource>(location);

                return Ok(locationResponseResource);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateLocation([FromBody] CreateLocationRequestResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var location =
                    _mapper.Map<CreateLocationRequestResource, Location>(request);

                _locationService.Add(location);

                location =
                    _locationService.GetLocation(location.Id);

                var locationResponseResource =
                    _mapper.Map<Location, LocationResponseResource>(location);

                return Ok(locationResponseResource);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
