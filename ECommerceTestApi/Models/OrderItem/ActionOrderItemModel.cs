using StoreakApiService.Core.Attributes;

namespace ECommerceTestApi.Models.OrderItem
{
    public class ActionOrderItemModel
    {
        [RequiredRange(1, 10000, ErrorMessage = "PriceMustBePositive")]
        public long Count { get; set; }
    }
}
