﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public double Amount { get; set; }
        public double VAT { get; set; }
    }
}
