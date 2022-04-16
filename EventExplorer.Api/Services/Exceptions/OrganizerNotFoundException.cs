using System;

namespace EventExplorer.Api.Services.Exceptions
{
    public class OrganizerNotFoundException : Exception
    {
        public OrganizerNotFoundException(int organizerId)
            : base($"Rendezvényszervező nem található a következő id-vel: {organizerId}")
        {
        }
    }
}
