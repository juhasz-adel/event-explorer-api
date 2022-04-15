using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EventExplorer.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories =
                _context.Categories.ToList();

            var categoryResponseResources =
                _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResponseResource>>(categories);

            return Ok(categoryResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCategory(int id)
        {
            var category =
                _context.Categories
                .SingleOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound("Category not found with id: " + id);
            }

            var categoryResponseResource =
                _mapper.Map<Category, CategoryResponseResource>(category);

            return Ok(categoryResponseResource);
        }
    }
}
