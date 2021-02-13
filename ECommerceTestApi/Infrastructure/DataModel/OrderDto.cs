using StoreakApiService.Core.Context.DataModel;
using System;
using System.Collections.Generic;

namespace ECommerceTestApi.Infrastructure.DataModel
{
    public class OrderDto : TrackableDto
    {
        #region Constructor

        public OrderDto()
        {
            OrderItems = new List<OrderItemDto>();
        }
        #endregion

        public string SerialNum { get; set; }
        public DateTime OrderDate { get; set; }

        #region Navigation Properties

        public virtual ICollection<OrderItemDto> OrderItems { get; set; }
        #endregion
    }
}
