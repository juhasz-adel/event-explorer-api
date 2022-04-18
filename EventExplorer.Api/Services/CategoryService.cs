using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence.Repositories;
using EventExplorer.Api.Services.Exceptions;
using System.Collections.Generic;

namespace EventExplorer.Api.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public IEnumerable<Event> GetEvents(int categoryId)
        {
            var category = _categoryRepository.GetCategory(categoryId);

            if (category is null)
            {
                throw new CategoryNotFoundException(categoryId);
            }

            return category.Events;
        }

        public Category GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);

            if (category is null)
            {
                throw new CategoryNotFoundException(id);
            }

            return category;
        }

        public void Add(Category category)
        {
            _categoryRepository.Add(category);
        }
    }
}
