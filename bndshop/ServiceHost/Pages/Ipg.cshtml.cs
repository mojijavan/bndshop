using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RedirectAndPostCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static ServiceHost.Pages.ApproveModel;
using ShopManagement.Application.Contracts.Order;
using _0_Framework.Application.ZarinPal;

namespace ServiceHost.Pages
{
    public class IpgModel : PageModel
    {
        private readonly IOrderApplication _orderApplication;
        string TOKEN = string.Empty;
        public IpgModel(IOrderApplication orderApplication) {
            _orderApplication = orderApplication;
        }
        public ActionResult OnGet(string orderID, string amount)
        {
            generateTokenWithNoSignRequest tokenWithNoSignRequest = new generateTokenWithNoSignRequest()
            {
                Amount = _orderApplication.GetAmountBy(Convert.ToInt64(orderID)).ToString(),
                RedirectUrl = "https://bndplus.ir/Approve",
                ReserveNum = orderID,
                TransType = Type.EN_GOODS.ToString()//"EN_GOODS"
            };
            tokenWithNoSignRequest.WSContext.UserId = "411398675";
            tokenWithNoSignRequest.WSContext.Password = "073571";
            tokenWithNoSignRequest.MerchantId = 411398675.ToString();


            var request = (HttpWebRequest)WebRequest.Create("https://ref.sayancard.ir/ref-payment/RestServices/mts/generateTokenWithNoSign/");

            //var postData = "{\"UserName\":41979242,\"Password\":698583}";

            var postData = JsonConvert.SerializeObject(tokenWithNoSignRequest);


            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(responseString);
            //WSContext a = new WSContext();
            // a.
            if (json.ContainsKey("Result")) if (json.GetValue("Result").ToString() == "erSucceed")
                {
                    if (json.ContainsKey("Token")) TOKEN = json.GetValue("Token").ToString();
                    if (json.ContainsKey("SessionId")) TOKEN = json.GetValue("SessionId").ToString();
                }
                else
                {
                    var paymentResult = new PaymentResult();
                    paymentResult = paymentResult.Failed("پرداخت با مشکل مواجه شده است");
                    return RedirectToPage("/PaymentResult", paymentResult);
                }
            Dictionary<string, object> postIpgData = new Dictionary<string, object>();
            _orderApplication.SetTokenForOrderId(Convert.ToInt64(orderID), TOKEN);
            postIpgData.Add("token", TOKEN);
            postIpgData.Add("language", "fa");

            return new RedirectAndPostResult("https://say.shaparak.ir/_ipgw_/MainTemplate/payment/", postIpgData);

        }
      
        enum Type
        {
            EN_GOODS,
            EN_BILL_PAY,
            EN_VOCHER,
            EN_TOP_UP,
            EN_THP_PAY
        }

        private class wSContext
        {
            public string UserId { get; set; }
            public string Password { get; set; }
        }

        private class generateTokenWithNoSignRequest
        {
            public wSContext WSContext = new wSContext();
            public string TransType { get; set; }
            public string ReserveNum { get; set; }
            public string MerchantId { get; set; }
            public string Amount { get; set; }
            public string RedirectUrl { get; set; }

        }
    }
}
