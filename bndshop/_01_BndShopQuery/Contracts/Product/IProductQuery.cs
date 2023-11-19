using System.Collections.Generic;
using ShopManagement.Application.Contracts.Order;

namespace _01_BndShopQuery.Contracts.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetProductDetails(string slug);
        SlickSliderModel SlickSlider(string id);
        List<ProductQueryModel> Search(string value);
        List<CartItem> CheckInventoryStatus(List<CartItem> cartItems);
    }
}
