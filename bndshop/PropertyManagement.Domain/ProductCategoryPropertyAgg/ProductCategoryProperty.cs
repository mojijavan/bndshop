

namespace PropertyManagement.Domain.ProductCategoryPropertyAgg
{
    public class ProductCategoryProperty
    {
        public long Id { get; private set; }
        public long CategoryId { get; private set; }
        
        public string Name { get; private set; }
        public int Priority { get; private set; }
    }
}
