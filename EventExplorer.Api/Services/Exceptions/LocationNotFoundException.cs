using System;

namespace EventExplorer.Api.Services.Exceptions
{
    public class LocationNotFoundException : Exception
    {
        public LocationNotFoundException(int locationId)
            : base($"Helyszín nem található a következő id-vel: {locationId}")
        {
        }
    }
}
