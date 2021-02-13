using System.Collections.Generic;

namespace ECommerceTestApi.Models.Category
{
    public class GetAllCategoryModel : CategoryModel
    {
        public IEnumerable<GetSecondLevelCategoryModel> GetSecondLevelCategories { get; set; }
    }
}
