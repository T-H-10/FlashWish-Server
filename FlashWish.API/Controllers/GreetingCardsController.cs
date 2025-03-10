using AutoMapper;
using FlashWish.API.PostModels;
using FlashWish.Core.DTOs;
using FlashWish.Core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlashWish.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingCardsController : ControllerBase
    {
        private readonly IGreetingCardService _greetingCardService;
        private readonly IMapper _mapper;

        public GreetingCardsController(IGreetingCardService greetingCardService, IMapper mapper)
        {
            _greetingCardService = greetingCardService;
            _mapper = mapper;
        }
        // GET: api/<GreetingCardsController>
        [HttpGet]
        public async Task<ActionResult<GreetingCardDTO>> GetAsync()
        {
            var greetingCards = await _greetingCardService.GetAllGreetingCardsAsync();
            if(greetingCards == null) { return NotFound(); }
            return Ok(greetingCards);
        }

        // GET api/<GreetingCardsController>/5
        [HttpGet("{id}")]
        public ActionResult<GreetingCardDTO> Get(int id)
        {
            var greetingCards= _greetingCardService.GetGreetingCardById(id);
            if(greetingCards == null) { return NotFound(id); }
            return greetingCards;
        }

        // POST api/<GreetingCardsController>
        [HttpPost]
        public ActionResult<GreetingCardDTO> Post([FromBody] GreetingCardPostModel greetingCard)
        {
            var greetingDTO=_mapper.Map<GreetingCardDTO>(greetingCard);
            if(greetingDTO == null) { return NotFound(); }
            return _greetingCardService.AddGreetingCard(greetingDTO);
        }

        // PUT api/<GreetingCardsController>/5
        [HttpPut("{id}")]
        public ActionResult<GreetingCardDTO> Put(int id, [FromBody] GreetingCardPostModel greetingCard)
        {
            var greetingDTO = _mapper.Map<GreetingCardDTO>(greetingCard);
            greetingDTO=_greetingCardService.UpdateGreetingCard(id, greetingDTO); 
            if(greetingDTO == null) { return NotFound(); }
            return greetingDTO;
        }

        // DELETE api/<GreetingCardsController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var isDeleted = _greetingCardService.DeleteGreetingCard(id);
            if(!isDeleted) { return NotFound(); }
            return isDeleted;
        }
    }
}
