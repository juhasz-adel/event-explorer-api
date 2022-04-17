using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Requests;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace EventExplorer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [EnableCors("CORS")]
    public class OrganizersController : ControllerBase
    {
        private readonly OrganizerService _organizerService;
        private readonly IMapper _mapper;

        public OrganizersController(
            OrganizerService organizerService,
            IMapper mapper
        )
        {
            _organizerService = organizerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrganizers()
        {
            var organizers =
                _organizerService.GetOrganizers();

            var organizerResponseResources =
                _mapper.Map<IEnumerable<Organizer>, IEnumerable<OrganizerResponseResource>>(organizers);

            return Ok(organizerResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrganizer(int id)
        {
            try
            {
                var organizer =
                        _organizerService.GetOrganizer(id);

                var organizerResponseResource =
                    _mapper.Map<Organizer, OrganizerResponseResource>(organizer);

                return Ok(organizerResponseResource);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOrganizer([FromBody] CreateOrganizerRequestResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var organizer =
                        _mapper.Map<CreateOrganizerRequestResource, Organizer>(request);

                _organizerService.Add(organizer);

                organizer =
                    _organizerService.GetOrganizer(organizer.Id);

                var organizerResponseResource =
                    _mapper.Map<Organizer, OrganizerResponseResource>(organizer);

                return Ok(organizerResponseResource);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
