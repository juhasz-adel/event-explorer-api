using EventExplorer.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventExplorer.Api.Persistence.Repositories
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories
                .SingleOrDefault(category => category.Id == id);
        }

        public Category Add(Category category)
        {
            var addedCategory = _context.Categories.Add(category);
            _context.SaveChanges();

            return addedCategory.Entity;
        }
    }
}
