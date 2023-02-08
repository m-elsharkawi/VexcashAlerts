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
    public class AlertTypeDataController : IAlertTypeDataAccess
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public AlertTypeDataController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("DbConnectionString");
        }
        public async Task<AlertType> GetAlertType(int id)
        {
            AlertType alertType = new AlertType();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT AlertTypeName FROM dbo.AlertType WHERE AlertTypeId = @AlertTypeId";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@AlertTypeId", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            alertType.AlertTypeName = reader.GetString(0);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return alertType;
        }
    }
}
