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
        private readonly CategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryEventsController(
            CategoryService categoryService,
            IMapper mapper
        )
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategoryEvents(int id)
        {
            try
            {
                var events =
                    _categoryService.GetEvents(id);

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
