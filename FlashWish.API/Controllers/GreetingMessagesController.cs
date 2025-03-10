using AutoMapper;
using FlashWish.API.PostModels;
using FlashWish.Core.DTOs;
using FlashWish.Core.Entities;
using FlashWish.Core.IServices;
using FlashWish.Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlashWish.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingMessagesController : ControllerBase
    {
        private readonly IGreetingMessageService _greetingMessageService;
        private readonly IMapper _mapper;
        public GreetingMessagesController(IGreetingMessageService greetingMessageService, IMapper mapper)
        {
            _greetingMessageService = greetingMessageService;
            _mapper = mapper;
        }
        // GET: api/<GreetingMessagesController>
        [HttpGet]
        public async Task<ActionResult<GreetingMessageDTO>> GetAsync()
        {
            var greetingMessages = await _greetingMessageService.GetAllMessagesAsync();
            if (greetingMessages == null) { return NotFound(); }
            return Ok(greetingMessages);
        }

        // GET api/<GreetingMessagesController>/5
        [HttpGet("{id}")]
        public ActionResult<GreetingMessageDTO> Get(int id)
        {
            var greetingMessage = _greetingMessageService.GetGreetingMessageById(id);
            if (greetingMessage == null) { return NotFound(id); }
            return greetingMessage;
        }

        // POST api/<GreetingMessagesController>
        [HttpPost]
        public ActionResult<GreetingMessageDTO> Post([FromBody] GreetingMessagePostModel message)
        {
            var greetingDTO = _mapper.Map<GreetingMessageDTO>(message);
            if (greetingDTO == null) { return NotFound(); }
            return _greetingMessageService.AddGreetingMessage(greetingDTO);
        }

        // PUT api/<GreetingMessagesController>/5
        [HttpPut("{id}")]
        public ActionResult<GreetingMessageDTO> Put(int id, [FromBody] GreetingMessagePostModel message)
        {
            var greetingDTO = _mapper.Map<GreetingMessageDTO>(message);
            greetingDTO = _greetingMessageService.UpdateGreetingMessage(id, greetingDTO);
            if (greetingDTO == null) { return NotFound(); }
            return greetingDTO;
        }

        // DELETE api/<GreetingMessagesController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var isDeleted = _greetingMessageService.DeleteGreetingMessage(id);
            if (!isDeleted) { return NotFound(); }
            return isDeleted;
        }
    }
}
