using AnyCompany.Data.Interface;
using AnyCompany.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AnyCompany.Data.Repositories
{
    public class OrderRepository: RepositoryBase, IOrderRepository
    {
        public OrderRepository(IConfiguration configuration)
            : base(configuration)
        { 
        }
        public async Task SaveAsync(Order order)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand("INSERT INTO Orders VALUES (@OrderId, @Amount, @VAT)", connection);

                command.Parameters.AddWithValue("@OrderId", order.OrderId);
                command.Parameters.AddWithValue("@Amount", order.Amount);
                command.Parameters.AddWithValue("@VAT", order.VAT);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
