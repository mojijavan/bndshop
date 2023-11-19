

using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPropertyAgg
{
    public class ProductProperty
    {
        public long Id { get; private set; }
        public long ProductId { get; private set; }
        public Product Product { get; private set; }
        public string Name { get; private set; }
        public string Value { get; private set; }
    }
}
