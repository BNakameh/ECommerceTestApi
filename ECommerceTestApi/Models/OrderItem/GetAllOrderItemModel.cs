using System;

namespace ECommerceTestApi.Models.OrderItem
{
    public class GetAllOrderItemModel
    {
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public long OrderItemCount { get; set; }

        public string SerialNum { get; set; }

        public long ItemCount { get; set; }
        public string Name { get; set; }
        public double SellPrice { get; set; }
        public double BuyPrice { get; set; }
    }
}
