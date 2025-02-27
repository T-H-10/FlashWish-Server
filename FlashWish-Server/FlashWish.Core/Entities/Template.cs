using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashWish.Core.Entities
{
    public class Template
    {
        public int TemplateID { get; set; }
        public string TemplateName { get; set; }
        public string TemplateDescription { get; set; }
        public int CategoryID { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
