using System;

namespace EventExplorer.Api.Services.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException(int categoryId)
            : base($"Kategória nem található a következő id-vel: {categoryId}")
        {
        }
    }
}
