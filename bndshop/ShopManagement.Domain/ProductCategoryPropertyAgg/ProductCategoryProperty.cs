
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Domain.ProductCategoryPropertyAgg
{
    public class ProductCategoryProperty
    {
        public long Id { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category { get;  set; }
        public string Name { get; private set; }
        public int Priority { get; private set; }
    }
}
