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
    [Route("/api/[controller]/")]
    [EnableCors("CORS")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(
            CategoryService categoryService,
            IMapper mapper
        )
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories =
                _categoryService.GetCategories();

            var categoryResponseResources =
                _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResponseResource>>(categories);

            return Ok(categoryResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCategory(int id)
        {
            try
            {
                var category =
                    _categoryService.GetCategory(id);

                var categoryResponseResource =
                   _mapper.Map<Category, CategoryResponseResource>(category);

                return Ok(categoryResponseResource);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryRequestResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var category =
                    _mapper.Map<CreateCategoryRequestResource, Category>(request);

                _categoryService.Add(category);

                category =
                    _categoryService.GetCategory(category.Id);

                var categoryResponseResource =
                    _mapper.Map<Category, CategoryResponseResource>(category);

                return Ok(categoryResponseResource);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
