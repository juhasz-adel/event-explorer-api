using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence.Repositories;
using EventExplorer.Api.Services.Exceptions;
using System.Collections.Generic;

namespace EventExplorer.Api.Services
{
    public class OrganizerService
    {
        private readonly OrganizerRepository _organizerRepository;

        public OrganizerService(OrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }

        public IEnumerable<Organizer> GetOrganizers()
        {
            return _organizerRepository.GetOrganizers();
        }

        public Organizer GetOrganizer(int id)
        {
            var organizer = _organizerRepository.GetOrganizer(id);

            if (organizer is null)
            {
                throw new OrganizerNotFoundException(id);
            }

            return organizer;
        }

        public void Add(Organizer organizer)
        {
            _organizerRepository.Add(organizer);
        }
    }
}
