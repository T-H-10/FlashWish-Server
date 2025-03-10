using AutoMapper;
using FlashWish.Core.DTOs;
using FlashWish.Core.Entities;
using FlashWish.Core.IServices;
using FlashWish.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashWish.Service.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public TemplateService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public TemplateDTO AddTemplate(TemplateDTO template)
        {
            var templateToAdd = _mapper.Map<Template>(template);
            if (template != null)
            {
                _repositoryManager.Templates.Add(templateToAdd);
                _repositoryManager.Save();
            }
            return _mapper.Map<TemplateDTO>(templateToAdd);
        }

        public bool DeleteTemplate(int id)
        {
            var templateDTO = _repositoryManager.Templates.GetByIdAsync(id);
            var templateToDelete = _mapper.Map<Template>(templateDTO);
            if (templateToDelete == null) { return false; }
            _repositoryManager.Templates.Delete(templateToDelete);
            _repositoryManager.Save();
            return true;
        }

        public async Task<IEnumerable<TemplateDTO>> GetAllTemplatesAsync()
        {
            var templates = await _repositoryManager.Templates.GetAllAsync();
            return _mapper.Map<IEnumerable<TemplateDTO>>(templates);
        }

        public TemplateDTO? GetTemplateById(int id)
        {
            var template = _repositoryManager.Templates.GetByIdAsync(id);
            return _mapper.Map<TemplateDTO>(template);
        }

        public TemplateDTO? UpdateTemplate(int id, TemplateDTO template)
        {
            if (template == null) return null;
            var templateToUpdate = _mapper.Map<Template>(template);
            _repositoryManager.Templates.Update(id, templateToUpdate);
            _repositoryManager.Save();
            return _mapper.Map<TemplateDTO?>(templateToUpdate);

        }
    }
}
