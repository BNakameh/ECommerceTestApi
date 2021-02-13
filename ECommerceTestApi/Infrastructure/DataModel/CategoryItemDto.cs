using StoreakApiService.Core.Context.DataModel;
using System;

namespace ECommerceTestApi.Infrastructure.DataModel
{
    public class CategoryItemDto : TrackableDto
    {
        #region Constuctor

        public CategoryItemDto()
        {
        }
        #endregion

        #region Navigation Properties

        public virtual CategoryDto Category { get; set; }
        public Guid? CategoryId { get; set; }

        public virtual ItemDto Item { get; set; }
        public Guid? ItemId { get; set; }
        #endregion
    }
}
