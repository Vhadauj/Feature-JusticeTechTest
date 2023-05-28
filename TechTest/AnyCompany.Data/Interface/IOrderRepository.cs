using AnyCompany.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Data.Interface
{
    public interface IOrderRepository
    {
        Task SaveAsync(Order order);
    }
}
