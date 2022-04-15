using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Requests;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence;
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
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users =
                _context.Users.ToList();

            var userResponseResources =
                _mapper.Map<IEnumerable<User>, IEnumerable<UserResponseResource>>(users);

            return Ok(userResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            var user =
                _context.Users
                .SingleOrDefault(e => e.Id == id);

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

            var user = _mapper.Map<CreateUserRequestResource, User>(request);

            _context.Users.Add(user);
            _context.SaveChanges();

            var userResponseResource = _mapper.Map<User, UserResponseResource>(user);

            return Ok(userResponseResource);
        }
    }
}