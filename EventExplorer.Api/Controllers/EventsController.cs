using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventExplorer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EventsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events =
                _context.Events
                .Include(e => e.Organizer)
                .Include(e => e.Category)
                .Include(e => e.Location)
                .ToList();

            var eventResponseResources =
                _mapper.Map<IEnumerable<Event>, IEnumerable<EventResponseResource>>(events);

            return Ok(eventResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEvent(int id)
        {
            var @event =
                _context.Events
                .Include(e => e.Organizer)
                .Include(e => e.Category)
                .Include(e => e.Location)
                .SingleOrDefault(e => e.Id == id);

            if (@event == null)
            {
                return NotFound("Event not found with id: " + id);
            }

            var eventResponseResource =
                _mapper.Map<Event, EventResponseResource>(@event);

            return Ok(eventResponseResource);
        }
    }
}
