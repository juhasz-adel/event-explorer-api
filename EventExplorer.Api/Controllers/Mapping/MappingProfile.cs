using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Requests;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;

namespace EventExplorer.Api.Controllers.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model to response resource
            CreateMap<Category, CategoryResponseResource>();

            // Request resource to model
            CreateMap<CreateCategoryRequestResource, Category>();
        }
    }
}
