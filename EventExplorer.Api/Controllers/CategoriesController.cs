using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Requests;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EventExplorer.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(
            CategoryRepository categoryRepository,
            IMapper mapper
            )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories =
                _categoryRepository.GetCategories();

            var categoryResponseResources =
                _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResponseResource>>(categories);

            return Ok(categoryResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCategory(int id)
        {
            var category =
                _categoryRepository.GetCategory(id);

            if (category == null)
            {
                return NotFound("Category not found with id: " + id);
            }

            var categoryResponseResource =
                _mapper.Map<Category, CategoryResponseResource>(category);

            return Ok(categoryResponseResource);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryRequestResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category =
                _mapper.Map<CreateCategoryRequestResource, Category>(request);

            _categoryRepository.Add(category);

            category =
                _categoryRepository.GetCategory(category.Id);

            var categoryResponseResource =
                _mapper.Map<Category, CategoryResponseResource>(category);

            return Ok(categoryResponseResource);
        }
    }
}
