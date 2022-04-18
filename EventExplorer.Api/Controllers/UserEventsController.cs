using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EventExplorer.Api.Controllers.Resources.Queries;
using Microsoft.AspNetCore.Cors;

namespace EventExplorer.Api.Controllers
{
    [ApiController]
    [Route("api/users/{userId:int}/events/")]
    [EnableCors("CORS")]
    public class UserEventsController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;
        private readonly IMapper _mapper;

        public UserEventsController(
            AttendanceService attendanceService,
            IMapper mapper
        )
        {
            _attendanceService = attendanceService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUpcomingUserEvents(int userId, [FromQuery] EventFilterQuery query)
        {
            try
            {
                var events = query.IsUpcoming
                    ? _attendanceService.GetUpcomingUserEvents(userId)
                    : _attendanceService.GetFurtherUserEvents(userId);

                var eventResponseResources =
                    _mapper.Map<IEnumerable<Event>, IEnumerable<EventResponseResource>>(events);

                return Ok(eventResponseResources);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
