using System;

namespace ECommerceTestApi.Models.Order
{
    public class OrderItemModel
    {
        public Guid ItemId { get; set; }
        public long Count { get; set; }
    }
}
