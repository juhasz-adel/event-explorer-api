using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Requests;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence;
using EventExplorer.Api.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EventExplorer.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventsController(
            EventRepository eventRepository,
            IMapper mapper
            )
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events =
                _eventRepository.GetEvents();

            var eventResponseResources =
                _mapper.Map<IEnumerable<Event>, IEnumerable<EventResponseResource>>(events);

            return Ok(eventResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEvent(int id)
        {
            var @event =
                _eventRepository.GetEvent(id);
                
            if (@event == null)
            {
                return NotFound("Event not found with id: " + id);
            }

            var eventResponseResource =
                _mapper.Map<Event, EventResponseResource>(@event);

            return Ok(eventResponseResource);
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] CreateEventRequestResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = _mapper.Map<CreateEventRequestResource, Event>(request);

            _eventRepository.Add(@event);

            @event = _eventRepository.GetEvent(@event.Id);

            var eventResponseResource = _mapper.Map<Event, EventResponseResource>(@event);

            return Ok(eventResponseResource);
        }
    }
}
