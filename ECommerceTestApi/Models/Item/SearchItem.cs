using StoreakApiService.Core.Context;

namespace ECommerceTestApi.Models.Item
{
    public class SearchItem
    {
        public string Name { get; set; }
        public long Count { get; set; }
        public double SellPrice { get; set; }

        public PagingParams pagingParams { get; set; }
    }
}
