using System;
using System.Collections.Generic;

namespace ECommerceTestApi.Models.Order
{
    public class GetOrderModel
    {
        public Guid Id { get; set; }
        public string SerialNum { get; set; }

        public IEnumerable<OrderItemModel> OrderItems { get; set; }
    }
}
