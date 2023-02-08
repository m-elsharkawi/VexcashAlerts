using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class AlertLog
    {
        public int AlertLogId { get; set; }
        public int CustomerId { get; set; }
        public string AlertText { get; set; }
        public string AlertTime { get; set; }
    }
}
