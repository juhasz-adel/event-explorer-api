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
            CreateMap<Attendance, AttendanceResponseResource>();
            CreateMap<Category, CategoryResponseResource>();
            CreateMap<Event, EventResponseResource>();
            CreateMap<Location, LocationResponseResource>();
            CreateMap<Organizer, OrganizerResponseResource>();
            CreateMap<User, UserResponseResource>();

            // Request resource to model
            CreateMap<AttendanceRequestResource, Attendance>();
            CreateMap<CreateCategoryRequestResource, Category>();
            CreateMap<CreateEventRequestResource, Event>();
            CreateMap<CreateLocationRequestResource, Location>();
            CreateMap<CreateOrganizerRequestResource, Organizer>();
            CreateMap<CreateUserRequestResource, User>();
        }
    }
}
