using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Application.Contracts
{
    public class PaymentMethod
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        private PaymentMethod(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static List<PaymentMethod> GetList()
        {
            return new List<PaymentMethod>
            {
                new PaymentMethod(1, "پرداخت اینترنتی بانک سپه",
                    "در مدل شما به درگاه پرداخت اینترنتی هدایت شده و درلحظه پرداخت وجه را انجام خواهید داد."),

                new PaymentMethod(2, "پرداخت در محل",
                    "در این مدل، ابتدا سفارش ثبت شده و سپس وجه به صورت نقدی در زمان تحویل کالا، دریافت خواهد شد."),
                //new PaymentMethod(1, "پرداخت اینترنتی زرین پال",
                //    "در مدل شما به درگاه پرداخت اینترنتی هدایت شده و درلحظه پرداخت وجه را انجام خواهید داد."),
                new PaymentMethod(3, "مراجعه حضوری به فروشگاه",
                "در این مدل، شما با حضور در محل فروشگاه اجناس خود را تحویل خواهید گرفت. در این روش هزینه ارسال دریافت نمی گردد."),
                 };
        }

        public static PaymentMethod GetBy(long id)
        {
            return GetList().FirstOrDefault(x => x.Id == id);
        }
    }
}