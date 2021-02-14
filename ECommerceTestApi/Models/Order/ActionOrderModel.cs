using StoreakApiService.Core.Attributes;
using System.Collections.Generic;

namespace ECommerceTestApi.Models.Order
{
    public class ActionOrderModel
    {
        [RequiredValue(ErrorMessage = "SerialNumRequired")]
        public string SerialNum { get; set; }

        public IList<OrderItemModel> OrderItems { get; set; }
    }
}
