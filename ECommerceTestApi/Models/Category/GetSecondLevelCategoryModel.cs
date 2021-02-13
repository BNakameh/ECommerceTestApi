using System.Collections.Generic;

namespace ECommerceTestApi.Models.Category
{
    public class GetSecondLevelCategoryModel : CategoryModel
    {
        public IEnumerable<GetThirdLevelCategoryModel> GetThirdLevelCategories { get; set; }
    }
}
