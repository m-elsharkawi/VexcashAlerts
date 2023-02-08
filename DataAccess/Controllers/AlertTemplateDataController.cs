using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Controllers
{
    public class AlertTemplateDataController : IAlertTemplateDataAccess
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public AlertTemplateDataController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("DbConnectionString");
        }
        public async Task<AlertTemplate> GetAlertTemplate(int id)
        {
            AlertTemplate alertTemplate = new AlertTemplate();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT AlertTemplateName, AlertTypeId, AlertSubject, AlertText FROM dbo.AlertTemplate WHERE AlertTemplateId = @AlertTemplateId";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@AlertTemplateId", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            alertTemplate.AlertTemplateName = reader.GetString(0);
                            alertTemplate.AlertTypeId = reader.GetInt32(1);
                            alertTemplate.AlertSubject = reader.GetString(2);
                            alertTemplate.AlertText = reader.GetString(3);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return alertTemplate;
        }

        public async Task<AlertTemplate> GetAlertTemplate(string alterTemplateName)
        {
            AlertTemplate alertTemplate = new AlertTemplate();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT AlertTemplateName, AlertTypeId, AlertSubject, AlertText FROM dbo.AlertTemplate WHERE AlertTemplateName = @AlertTemplateName";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@AlertTemplateName", alterTemplateName);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            alertTemplate.AlertTemplateName = reader.GetString(0);
                            alertTemplate.AlertTypeId = reader.GetInt32(1);
                            alertTemplate.AlertSubject = reader.GetString(2);
                            alertTemplate.AlertText = reader.GetString(3);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return alertTemplate;
        }
    }
}
