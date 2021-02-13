using StoreakApiService.Core.Context.DataModel;
using System.Collections.Generic;

namespace ECommerceTestApi.Infrastructure.DataModel
{
    public class ItemDto : TrackableDto
    {
        #region Constructor

        public ItemDto()
        {
            OrderItems = new List<OrderItemDto>();
            CategoryItems = new List<CategoryItemDto>();
        }
        #endregion

        public string Name { get; set; }
        public long Count { get; set; }

        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }

        #region Navigation Properties

        public virtual ICollection<OrderItemDto> OrderItems { get; set; }
        public virtual ICollection<CategoryItemDto> CategoryItems { get; set; }
        #endregion
    }
}
