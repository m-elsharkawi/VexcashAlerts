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
    public class AlertLogDataController : IAlertLogDataAccess
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public AlertLogDataController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("DbConnectionString");
        }
        public async Task<bool> InsertAlertLog(AlertLog alertLog)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "insert into AlertLog (CustomerId, AlertText) values (@CustomerId, @AlertText)";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", alertLog.CustomerId);
                    command.Parameters.AddWithValue("@AlertText", alertLog.AlertText);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if(rowsAffected> 0) { return true; }
                }
            }
            return false;
        }
    }
}
