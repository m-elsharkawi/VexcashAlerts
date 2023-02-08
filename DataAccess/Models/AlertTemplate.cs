using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class AlertTemplate
    {
        public int AlertTemplateId { get; set; }
        public string AlertTemplateName { get; set;}
        public int AlertTypeId { get; set; }
        public string AlertSubject { get; set; }
        public string AlertText { get; set; }
    }
}
