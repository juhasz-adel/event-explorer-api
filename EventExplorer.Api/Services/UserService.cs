using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence.Repositories;
using EventExplorer.Api.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace EventExplorer.Api.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly EventRepository _eventRepository;

        public UserService(
            UserRepository userRepository,
            EventRepository eventRepository
        )
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public User GetUser(int id)
        {
            var user = _userRepository.GetUser(id);

            if (user is null)
            {
                throw new UserNotFoundException(id);
            }

            return user;
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }
    }
}
