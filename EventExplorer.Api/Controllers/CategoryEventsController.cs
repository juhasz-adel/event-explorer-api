using System;
using System.Collections.Generic;
using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EventExplorer.Api.Controllers
{
    [ApiController]
    [Route("/api/categories/{id:int}/events")]
    [EnableCors("CORS")]
    public class CategoryEventsController : ControllerBase
    {
        private readonly EventService _eventService;
        private readonly IMapper _mapper;

        public CategoryEventsController(
            EventService eventService,
            IMapper mapper
        )
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategoryEvents(int id)
        {
            var events =
                _eventService.GetEvents(id);

            var eventResponseResources =
                _mapper.Map<IEnumerable<Event>, IEnumerable<EventResponseResource>>(events);

            return Ok(eventResponseResources);
        }
    }
}
