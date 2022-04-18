using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence.Repositories;
using EventExplorer.Api.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace EventExplorer.Api.Services
{
    public class EventService
    {
        private readonly EventRepository _eventRepository;

        public EventService(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IEnumerable<Event> GetEvents()
        {
            return _eventRepository.GetEvents();
        }

        public IEnumerable<Event> GetEvents(int categoryId)
        {
            var events = _eventRepository.GetEvents();

            return events
                .Where(@event => @event.CategoryId == categoryId)
                .ToList();
        }

        public Event GetEvent(int id)
        {
            var @event = _eventRepository.GetEvent(id);

            if (@event is null)
            {
                throw new EventNotFoundException(id);
            }

            return @event;
        }

        public void Add(Event @event)
        {
            _eventRepository.Add(@event);
        }
    }
}
