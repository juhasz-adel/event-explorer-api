using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Requests;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence;
using EventExplorer.Api.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EventExplorer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class OrganizersController : ControllerBase
    {
        private readonly OrganizerRepository _organizerRepository;
        private readonly IMapper _mapper;

        public OrganizersController(
            OrganizerRepository organizerRepository,
            IMapper mapper
            )
        {
            _organizerRepository = organizerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrganizers()
        {
            var organizers =
                _organizerRepository.GetOrganizers();

            var organizerResponseResources =
                _mapper.Map<IEnumerable<Organizer>, IEnumerable<OrganizerResponseResource>>(organizers);

            return Ok(organizerResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrganizer(int id)
        {
            var organizer =
                _organizerRepository.GetOrganizer(id);

            if (organizer == null)
            {
                return NotFound("Oragnizer not found with id: " + id);
            }

            var organizerResponseResource =
                _mapper.Map<Organizer, OrganizerResponseResource>(organizer);

            return Ok(organizerResponseResource);
        }

        [HttpPost]
        public IActionResult CreateOrganizer([FromBody] CreateOrganizerRequestResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizer =
                _mapper.Map<CreateOrganizerRequestResource, Organizer>(request);

            _organizerRepository.Add(organizer);

            organizer =
                _organizerRepository.GetOrganizer(organizer.Id);

            var organizerResponseResource =
                _mapper.Map<Organizer, OrganizerResponseResource>(organizer);

            return Ok(organizerResponseResource);
        }
    }
}
