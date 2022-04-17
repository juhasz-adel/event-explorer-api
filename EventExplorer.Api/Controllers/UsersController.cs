using AutoMapper;
using EventExplorer.Api.Controllers.Resources.Requests;
using EventExplorer.Api.Controllers.Resources.Responses;
using EventExplorer.Api.Models;
using EventExplorer.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace EventExplorer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [EnableCors("CORS")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UsersController(
            UserService userService,
            IMapper mapper
        )
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users =
                _userService.GetUsers();

            var userResponseResources =
                _mapper.Map<IEnumerable<User>, IEnumerable<UserResponseResource>>(users);

            return Ok(userResponseResources);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user =
                    _userService.GetUser(id);

                var userResponseResource =
                    _mapper.Map<User, UserResponseResource>(user);

                return Ok(userResponseResource);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequestResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user =
                    _mapper.Map<CreateUserRequestResource, User>(request);

                _userService.Add(user);

                user =
                    _userService.GetUser(user.Id);

                var userResponseResource =
                    _mapper.Map<User, UserResponseResource>(user);

                return Ok(userResponseResource);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}