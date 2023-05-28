using AnyCompany.Data.Interface;
using AnyCompany.Domain.Models;
using AnyCompany.Services.Interface;

namespace AnyCompany.Services.Implementation
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICustomerRepository customerRepository;
        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            this.orderRepository = orderRepository;
            this.customerRepository = customerRepository;
        }

        public async Task<bool> PlaceOrderAsync(Order order, int customerId)
        {
            Customer customer = await customerRepository.LoadAsync(customerId);

            if (order.Amount == 0)
                return false;

            if (customer.Country == "UK")
                order.VAT = 0.2d;
            else
                order.VAT = 0;

            await orderRepository.SaveAsync(order);

            return true;
        }
    }
}
