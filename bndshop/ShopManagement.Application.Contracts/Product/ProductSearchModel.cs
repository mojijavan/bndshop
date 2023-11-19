namespace ShopManagement.Application.Contracts.Product
{
    public class ProductSearchModel
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public long CategoryId { get; set; }
    }
}