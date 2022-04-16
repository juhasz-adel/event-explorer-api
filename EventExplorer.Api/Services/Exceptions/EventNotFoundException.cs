using System;

namespace EventExplorer.Api.Services.Exceptions
{
    public class EventNotFoundException : Exception
    {
        public EventNotFoundException(int eventId)
            : base($"Esemény nem található a következő id-vel: {eventId}")
        {
        }
    }
}
