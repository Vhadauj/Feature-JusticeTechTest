using AnyCompany.Domain.Models;
using System.Threading.Tasks;

namespace AnyCompany.Services.Interface
{
    public interface IOrderService
    {
        Task<bool> PlaceOrderAsync(Order order, int customerId);
    }
}
