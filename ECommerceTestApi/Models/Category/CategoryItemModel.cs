namespace ECommerceTestApi.Models.Category
{
    public class CategoryItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Count { get; set; }

        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
    }
}
