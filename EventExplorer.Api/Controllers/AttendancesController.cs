using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Requests;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EventExplorer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AttendancesController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;
        private readonly IMapper _mapper;

        public AttendancesController(
            AttendanceService attendanceService,
            IMapper mapper
        )
        {
            _attendanceService = attendanceService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateAttendance([FromBody] AttendanceRequestResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var attendance =
                    _mapper.Map<AttendanceRequestResource, Attendance>(request);

                _attendanceService.Add(attendance);

                attendance =
                    _attendanceService.GetAttendance(attendance.EventId, attendance.UserId);

                var attendanceResponseResource =
                    _mapper.Map<Attendance, AttendanceResponseResource>(attendance);

                return Ok(attendanceResponseResource);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
