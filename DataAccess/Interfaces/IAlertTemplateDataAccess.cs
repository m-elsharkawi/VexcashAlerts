using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IAlertTemplateDataAccess
    {
        Task<AlertTemplate> GetAlertTemplate(int id);
        Task<AlertTemplate> GetAlertTemplate(string alertTemplateName);
    }
}
