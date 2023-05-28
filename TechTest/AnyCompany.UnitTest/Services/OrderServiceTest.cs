using AnyCompany.Data.Interface;
using AnyCompany.Domain.Models;
using AnyCompany.Services.Implementation;
using Moq;

namespace AnyCompany.Tests.Services
{
    public class OrderServiceTests
    {
        [Fact]
        public async Task PlaceOrderAsync_Should_Succeed_When_Order_IsValid()
        {
            // Arrange
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var customerRepositoryMock = new Mock<ICustomerRepository>();

            var order = new Order
            {
                OrderId = 1,
                Amount = 100,
               
            };

            var customer = new Customer
            {
                CustomerId = 1,
                Name = "Justice",
                DateOfBirth = DateTime.Parse("1990-01-01"),
                Country = "South Africa"
            };

            orderRepositoryMock.Setup(x => x.SaveAsync(order)).Returns(Task.FromResult(true));
            customerRepositoryMock.Setup(x => x.LoadAsync(1)).Returns(Task.FromResult(customer));

            var orderService = new OrderService(orderRepositoryMock.Object, customerRepositoryMock.Object);

            // Act
            var result = await orderService.PlaceOrderAsync(order, customer.CustomerId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task PlaceOrderAsync_Should_Return_False_When_Order_Amount_Is_Zero()
        {
            // Arrange
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var customerRepositoryMock = new Mock<ICustomerRepository>();

            var orderService = new OrderService(orderRepositoryMock.Object, customerRepositoryMock.Object);

            var order = new Order
            {
                OrderId = 1,
                Amount = 0,
                
            };

            var customer = new Customer
            {
                CustomerId = 1,
                Name = "Justice",
                DateOfBirth = DateTime.Parse("1990-01-01"),
                Country = "South Africa"
            };

            orderRepositoryMock.Setup(x => x.SaveAsync(order)).Returns(Task.FromResult(true));
            customerRepositoryMock.Setup(x => x.LoadAsync(1)).Returns(Task.FromResult(customer));

            // Act
            var result = await orderService.PlaceOrderAsync(order, 1);

            // Assert
            Assert.False(result);
        }
    }
}
