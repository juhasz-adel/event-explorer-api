using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Requests;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence;
using EventExplorer.Api.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventExplorer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(
            UserRepository userRepository,
            IMapper mapper
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users =
                _userRepository.GetUsers();

            var userResponseResources =
                _mapper.Map<IEnumerable<User>, IEnumerable<UserResponseResource>>(users);

            return Ok(userResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            var user =
                _userRepository.GetUser(id);

            if (user == null)
            {
                return NotFound("User not found with id: " + id);
            }

            var userResponseResource =
                _mapper.Map<User, UserResponseResource>(user);

            return Ok(userResponseResource);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequestResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user =
                _mapper.Map<CreateUserRequestResource, User>(request);

            _userRepository.Add(user);

            user =
                _userRepository.GetUser(user.Id);

            var userResponseResource =
                _mapper.Map<User, UserResponseResource>(user);

            return Ok(userResponseResource);
        }
    }
}