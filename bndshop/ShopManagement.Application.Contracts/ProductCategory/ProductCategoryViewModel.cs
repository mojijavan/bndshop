namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Picture { get; set; }
        public string CreationDate { get; set; }
        public long ProductsCount { get; set; }
        public long ParentId { get; set; }
        public bool IsRemoved { get; set; }
    }
}