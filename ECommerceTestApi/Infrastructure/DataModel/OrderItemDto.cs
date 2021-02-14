using StoreakApiService.Core.Context.DataModel;
using System;

namespace ECommerceTestApi.Infrastructure.DataModel
{
    public class OrderItemDto : TrackableDto
    {
        #region Constructor

        public OrderItemDto()
        {
        }
        #endregion

        public long Count { get; set; }

        #region Navigation Properties

        public virtual ItemDto Item { get; set; }
        public Guid? ItemId { get; set; }
        public virtual OrderDto Order { get; set; }
        public Guid? OrderId { get; set; }
        #endregion
    }
}
