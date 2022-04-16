using System;

namespace EventExplorer.Api.Services.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(int userId)
            : base($"Felhasználó nem található a következő id-vel: {userId}")
        {
        }
    }
}
