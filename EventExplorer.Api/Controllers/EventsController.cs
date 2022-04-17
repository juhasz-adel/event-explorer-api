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
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;
        private readonly IMapper _mapper;

        public EventsController(
            EventService eventService,
            IMapper mapper
        )
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events =
                _eventService.GetEvents();

            var eventResponseResources =
                _mapper.Map<IEnumerable<Event>, IEnumerable<EventResponseResource>>(events);

            return Ok(eventResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEvent(int id)
        {
            try
            {
                var @event =
                        _eventService.GetEvent(id);

                var eventResponseResource =
                    _mapper.Map<Event, EventResponseResource>(@event);

                return Ok(eventResponseResource);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] CreateEventRequestResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var @event =
                        _mapper.Map<CreateEventRequestResource, Event>(request);

                _eventService.Add(@event);

                @event =
                    _eventService.GetEvent(@event.Id);

                var eventResponseResource =
                    _mapper.Map<Event, EventResponseResource>(@event);

                return Ok(eventResponseResource);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
