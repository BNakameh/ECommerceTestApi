using System;

namespace ECommerceTestApi.Models.Category
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int LevelDeep { get; set; }
    }
}
