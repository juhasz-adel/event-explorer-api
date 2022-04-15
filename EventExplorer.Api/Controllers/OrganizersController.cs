using AutoMapper;
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
    public class OrganizersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrganizersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrganizers()
        {
            var organizers =
                _context.Organizers.ToList();

            var organizerResponseResources =
                _mapper.Map<IEnumerable<Organizer>, IEnumerable<OrganizerResponseResource>>(organizers);

            return Ok(organizerResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrganizer(int id)
        {
            var organizer =
                _context.Organizers
                .SingleOrDefault(o => o.Id == id);

            if (organizer == null)
            {
                return NotFound("Organizer not found with id: " + id);
            }

            var organizerResponseResource =
                _mapper.Map<Organizer, CategoryResponseResource>(organizer);

            return Ok(organizerResponseResource);
        }
    }
}
