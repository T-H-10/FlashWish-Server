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
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateService _templateService;
        private readonly IMapper _mapper;
        public TemplatesController(ITemplateService templateService, IMapper mapper)
        {
            _templateService = templateService;
            _mapper = mapper;
        }
        // GET: api/<TemplatesController>
        [HttpGet]
        public async Task<ActionResult<TemplateDTO>> GetAsync()
        {
            var templates = await _templateService.GetAllTemplatesAsync();
            if (templates == null) return NotFound();
            return Ok(templates);
        }

        // GET api/<TemplatesController>/5
        [HttpGet("{id}")]
        public ActionResult<TemplateDTO> Get(int id)
        {
            var template = _templateService.GetTemplateById(id);
            if (template == null) return NotFound(id);
            return template;
        }

        // POST api/<TemplatesController>
        [HttpPost]
        public ActionResult<TemplateDTO> Post([FromBody] TemplatePostModel template)
        {
            var templateDTO = _mapper.Map<TemplateDTO>(template);
            if (templateDTO == null)
                return NotFound();
            return _templateService.AddTemplate(templateDTO);
        }

        // PUT api/<TemplatesController>/5
        [HttpPut("{id}")]
        public ActionResult<TemplateDTO> Put(int id, [FromBody] TemplatePostModel template)
        {
            var templateDTO = _mapper.Map<TemplateDTO>(template);
            templateDTO = _templateService.UpdateTemplate(id, templateDTO);
            if (templateDTO == null) return NotFound();
            return templateDTO;
        }

        // DELETE api/<TemplatesController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var isDeleted = _templateService.DeleteTemplate(id);
            if (!isDeleted) return NotFound();
            return isDeleted;

        }
    }
}
