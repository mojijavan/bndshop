namespace ShopManagement.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int CustomerDiscountRate { get; set; }
        public int ColleagueDiscountRate { get; set; }
        public double CustomerUnitPrice { get; set; }
        public double ColleagueUnitPrice { get; set; }
        public string Picture { get; set; }
        public string  CreationDate { get; set; }
        public bool IsInStock { get; set; }
        public long Count { get; set; }
        public string Category { get; set; }
        public long CategoryId { get; set; }
        public bool IsRemoved { get; set; }
    }
}