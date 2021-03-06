

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]                     // authenticate the API
    [Route("api/[controller]")]     // Route to the request to the controller
    [ApiController]                 // API Controller to control the API

    public class UsersController : ControllerBase           // Inherit from controller base
    {
        private readonly IDatingRepository _repo;           // including the Repository to the controller and add method
        private readonly IMapper _mapper;                    // Imapper iNterface of the AutoMapper 

        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }


        [HttpGet]       // Return the list of users

        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();  // calling the method from IDating repostiroy of getting users
            var usersToreturn = _mapper.Map<IEnumerable<UserForListDTO>>(users); // Maps the Users IEnumerbale that is LIst 

            return Ok(usersToreturn);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);             // calling the method from IDating reporsitory to get user
            var userToreturn = _mapper.Map<UserForDetailDTO>(user);   // userToreturn variable to execute mapping User to detail DTO
            return Ok(userToreturn);
        }

        [HttpPut("{id}")] // this is used to update an user in a API

        public async Task<IActionResult> UpdateUser(int id, UserForUpdateDTO userForUpdateDTO)
        {
            if(id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)){       // check if the user that is Puttin is the authorize user
                return Unauthorized();
            }

            var userFromRepo = await _repo.GetUser(id);
            _mapper.Map(userForUpdateDTO, userFromRepo);

            if(await _repo.SaveAll()){
                return NoContent();
            } 

            throw new Exception($"updating user with {id} failed on save");


        }



    }
}