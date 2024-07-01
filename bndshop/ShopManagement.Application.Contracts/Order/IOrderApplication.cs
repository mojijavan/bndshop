using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Order
{
    public interface IOrderApplication
    {
        long PlaceOrder(Cart cart);
        double GetAmountBy(long id);
        void Cancel(long id);
        string PaymentSucceeded(long orderId, long refId);
        void SetTokenForOrderId(long orderId,string token);
        string GetTokenWithOrderId(long orderId);
        List<OrderItemViewModel> GetItems(long orderId);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
    }
}