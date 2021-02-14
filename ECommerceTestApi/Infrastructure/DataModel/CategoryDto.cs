using StoreakApiService.Core.Context.DataModel;
using System;
using System.Collections.Generic;

namespace ECommerceTestApi.Infrastructure.DataModel
{
    public class CategoryDto : TrackableDto
    {
        #region Constuctor

        public CategoryDto()
        {
            Items = new List<ItemDto>();
        }
        #endregion

        public string Name { get; set; }

        public int LevelDeep { get; set; }

        #region Navigation Properties

        public Guid? ChildCategoryId { get; set; }
        public virtual CategoryDto ChildCategory { get; set; }


        public virtual ICollection<ItemDto> Items { get; set; }
        #endregion

    }
}
