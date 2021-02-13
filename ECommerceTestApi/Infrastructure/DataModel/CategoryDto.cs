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
            CategoryItems = new List<CategoryItemDto>();
        }
        #endregion

        public string Name { get; set; }

        public int LevelDeep { get; set; }

        #region Navigation Properties

        public Guid? ChildCategoryId { get; set; }
        public virtual CategoryDto ChildCategory { get; set; }


        public virtual ICollection<CategoryItemDto> CategoryItems { get; set; }
        #endregion

    }
}
