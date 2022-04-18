using EventExplorer.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EventExplorer.Api.Persistence.Repositories
{
    public class EventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Event> GetEvents()
        {
            return _context.Events
                .Include(@event => @event.Organizer)
                .Include(@event => @event.Category)
                .Include(@event => @event.Location)
                .OrderBy(@event => @event.StartDate)
                .ToList();
        }

        public Event GetEvent(int id)
        {
            return _context.Events
                .Include(@event => @event.Organizer)
                .Include(@event => @event.Category)
                .Include(@event => @event.Location)
                .SingleOrDefault(@event => @event.Id == id);
        }

        public void Add(Event @event)
        {
            _context.Events.Add(@event);
            _context.SaveChanges();
        }
    }
}
