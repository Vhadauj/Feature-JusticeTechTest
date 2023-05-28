using AnyCompany.Data.Interface;
using AnyCompany.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Data.Repositories
{
    public  class CustomerRepository: RepositoryBase, ICustomerRepository
    {  
        public CustomerRepository(IConfiguration configuration)
            : base(configuration)
        {          
        }
        public  async Task<Customer> LoadAsync(int customerId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Customer WHERE CustomerId = @CustomerId", connection);
                command.Parameters.AddWithValue("@CustomerId", customerId);

                var reader = await command.ExecuteReaderAsync();

                if (!reader.Read())
                {
                    return null;
                }

                var customer = new Customer();
                customer.Name = reader["Name"].ToString();
                customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                customer.Country = reader["Country"].ToString();

                return customer;
            }
        }
    }
}
