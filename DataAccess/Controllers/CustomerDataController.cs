using DataAccess.Interfaces;
using DataAccess.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Controllers
{
    public class CustomerDataController : ICustomerDataAccess
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public CustomerDataController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("DbConnectionString");
        }
        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer = new Customer();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT CustomerName, CreditNumber, Amount, PhoneNumber, Email, DueDate FROM dbo.Customer WHERE CustomerId = @CustomerId";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            customer.CustomerName = reader.GetString(0);
                            customer.CreditNumber = reader.GetString(1);
                            customer.Amount = reader.GetDecimal(2);
                            customer.PhoneNumber = reader.GetString(3);
                            customer.Email = reader.GetString(4);
                            customer.DueDate = reader.GetDateTime(5);
                            customer.CustomerId = id;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return customer;
        }

        public async Task<Customer> GetCustomer(string creditNumber)
        {
            Customer customer = new Customer();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT CustomerName, CreditNumber, Amount, PhoneNumber, Email, DueDate, CustomerId FROM dbo.Customer WHERE CreditNumber = @CreditNumber";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CreditNumber", creditNumber);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            customer.CustomerName = reader.GetString(0);
                            customer.CreditNumber = reader.GetString(1);
                            customer.Amount = reader.GetDecimal(2);
                            customer.PhoneNumber = reader.GetString(3);
                            customer.Email = reader.GetString(4);
                            customer.DueDate = reader.GetDateTime(5);
                            customer.CustomerId = reader.GetInt32(6);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return customer;
        }
    }
}
