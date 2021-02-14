using StoreakApiService.Core.Attributes;
using System;

namespace ECommerceTestApi.Models.Category
{
    public class ActionCategoryModel
    {
        [RequiredValue(ErrorMessage = "NameRequired")]
        public string Name { get; set; }

        public Guid? ChildCategoryId { get; set; }
    }
}
