using System;

namespace ECommerceTestApi.Models.Order
{
    public class GetAllOrderModel
    {
        public Guid Id { get; set; }
        public string SerialNum { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}