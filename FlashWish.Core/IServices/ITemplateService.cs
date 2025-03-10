using FlashWish.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashWish.Core.IServices
{
    public interface ITemplateService
    {
        Task<IEnumerable<TemplateDTO>> GetAllTemplatesAsync();
        TemplateDTO? GetTemplateById(int id);
        TemplateDTO AddTemplate(TemplateDTO template);
        TemplateDTO? UpdateTemplate(int id, TemplateDTO template);
        bool DeleteTemplate(int id);
    }
}
