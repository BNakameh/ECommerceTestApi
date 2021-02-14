using System;
using System.Collections.Generic;

namespace ECommerceTestApi.Models.Category
{
    public class GetCategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CategoryItemModel> Items { get; set; }
    }
}
