using StoreakApiService.Core.Context;

namespace ECommerceTestApi.Models.Order
{
    public class SearchOrder
    {
        public string SerialNum { get; set; }
        public PagingParams pagingParams { get; set; }
    }
}
