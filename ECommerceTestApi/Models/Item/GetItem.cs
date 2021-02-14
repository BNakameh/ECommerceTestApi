namespace ECommerceTestApi.Models.Item
{
    public class GetItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Count { get; set; }

        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }

        public GetLastLevelCategory Category { get; set; }
    }
}
