using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICustomerDataAccess
    {
        Task<Customer> GetCustomer(int id);
        Task<Customer> GetCustomer(string creditNumber);
    }
}
