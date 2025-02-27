using AutoMapper;
using FlashWish.API.PostModels;
using FlashWish.Core.DTOs;
using FlashWish.Core.Entities;
using FlashWish.Core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlashWish.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetAsync()
        {
           var users=await _userService.GetAllUsersAsync();
            if(users==null) return NotFound();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = _userService.GetUserById(id);
            if(user==null) return NotFound();
            return user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserPostModel user)
        {
            var userDTO=_mapper.Map<UserDTO>(user);
            if(userDTO==null)
                return NotFound();
            return _userService.AddUser(userDTO);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<UserDTO> Put(int id, [FromBody] UserPostModel user)
        {
            var userDTO=_mapper.Map<UserDTO>(user);
            userDTO=_userService.UpdateUser(id, userDTO);
            if(userDTO==null) return NotFound();
            return userDTO;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var isDeleted = _userService.DeleteUser(id);
            if(!isDeleted) return NotFound();
            return isDeleted;

        }
    }
}
