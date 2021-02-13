using System;

namespace ECommerceTestApi.Models.Category
{
    public class ActionCategoryModel
    {
        public string Name { get; set; }

        public Guid? ChildCategoryId { get; set; }
    }
}
