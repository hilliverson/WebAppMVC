using System;
using System.Collections.Generic;

namespace WebAppMVC.Models.EF
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
