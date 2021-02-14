using System.Collections.Generic;
using System.Linq;

namespace ECommerceTestApi.Models.Item
{
    public class GetItemReportModel
    {
        public long TotalCount => Count.Sum();
        public double TotalBuyPrice => BuyPrice.Sum();

        public List<long>Count { get; set; }
        public List<double>SellPrice { get; set; }
        public List<double>BuyPrice { get; set; }
    }
}
