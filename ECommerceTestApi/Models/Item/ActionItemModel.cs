using StoreakApiService.Core.Attributes;
using System;

namespace ECommerceTestApi.Models.Item
{
    public class ActionItemModel
    {
        [RequiredValue(ErrorMessage = "NameRequired")]
        public string Name { get; set; }

        [RequiredRange(1, 10000, ErrorMessage = "QuantityMustBePositive")]
        public long Count { get; set; }

        [RequiredRange(1, 10000, ErrorMessage = "PriceMustBePositive")]
        public double BuyPrice { get; set; }

        [RequiredRange(1, 10000, ErrorMessage = "PriceMustBePositive")]
        public double SellPrice { get; set; }

        [RequiredId(ErrorMessage = "MustBeSelected")]
        public Guid? CategoryId { get; set; }

        public Guid PrevCategoryId { get; set; }
    }
}
