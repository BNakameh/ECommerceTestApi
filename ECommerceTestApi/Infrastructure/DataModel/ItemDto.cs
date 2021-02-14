using StoreakApiService.Core.Context.DataModel;
using System;
using System.Collections.Generic;

namespace ECommerceTestApi.Infrastructure.DataModel
{
    public class ItemDto : TrackableDto
    {
        #region Constructor

        public ItemDto()
        {
            OrderItems = new List<OrderItemDto>();
        }
        #endregion

        public string Name { get; set; }
        public long Count { get; set; }

        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }

        #region Navigation Properties

        public virtual CategoryDto Category { get; set; }
        public Guid? CategoryId { get; set; }

        public virtual ICollection<OrderItemDto> OrderItems { get; set; }
        #endregion
    }
}
