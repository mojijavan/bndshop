
namespace _01_BndShopQuery.Contracts.ProductCategory
{
    public class ProductCategoryTopRefrence
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string PName { get; set; }
        public string Label { get; set; }
        public string Slug { get; set; }
        public string ParentSlug { get; set; }
    }
}
