using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application.ZarinPal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class ApproveModel : PageModel
    {

        private readonly IOrderApplication _orderApplication;

        public ApproveModel(IOrderApplication orderApplication)
        {
            _orderApplication = orderApplication;
        }

        public class tempToken
        {
            public string token;
            public string ResNum; public string state; public string MID;
            public string RefNum;
            public string TraceNo; public string CustomerRefNum; public string CardHashPan; public string transactionAmount; public string userId;
            public string emailAddress; public string mobileNo; public string ApproveState;
        }
        public tempToken resultTemp;
        public string result1;
        public string result2;
    
        public ActionResult OnPost()
        {
           
            result1 = "empty";
            result2 = "empty";
           
            resultTemp = new tempToken();
          
            if (Request.Form["state"] == "OK")
            {
                resultTemp.token = Request.Form["token"].ToString();
                resultTemp.ResNum = Request.Form["ResNum"].ToString();
                //resultTemp.state = Request.Form["state"].ToString();
                //resultTemp.MID = Request.Form["MID"].ToString();
                //resultTemp.RefNum = Request.Form["token"].ToString();
                //resultTemp.TraceNo = Request.Form["TraceNo"].ToString();
                //resultTemp.CustomerRefNum = Request.Form["CustomerRefNum"].ToString();
                //resultTemp.CardHashPan = Request.Form["CardHashPan"].ToString();             
                //resultTemp.transactionAmount = Request.Form["transactionAmount"].ToString();
                //resultTemp.userId = Request.Form["userId"].ToString();
                //resultTemp.emailAddress = Request.Form["emailAddress"].ToString();
                //resultTemp.mobileNo = Request.Form["mobileNo"].ToString();
                                         
                resultTemp.ApproveState = "NOK";
                // tokens = _orderApplication.GetTokenWithOrderId(Convert.ToInt64(resultTemp.ResNum));
                generateTokenForApprove TokenForApprove = new generateTokenForApprove()
                {
                    RefNum = Request.Form["RefNum"].ToString(),
                    Token = resultTemp.token

                };
                TokenForApprove.WSContext.UserId = "411398675";
                TokenForApprove.WSContext.Password = "073571";

                var request = (HttpWebRequest)WebRequest.Create("https://ref.sayancard.ir/ref-payment/RestServices/mts/verifyMerchantTrans/");

                var postData = JsonConvert.SerializeObject(TokenForApprove);

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

                if (json.ContainsKey("Result")) if (json.GetValue("Result").ToString() == "erSucceed")
                    {
                        resultTemp.ApproveState = "OK";
                        var paymentResult = new PaymentResult();
                        paymentResult = paymentResult.Succeeded("سفارش شما با موفقیت ثبت و پرداخت گردید", resultTemp.RefNum.ToString());
                        //_orderApplication.PaymentSucceeded(Convert.ToInt64(resultTemp.ResNum),resultTemp.RefNum);
                        return RedirectToPage("/PaymentResult", paymentResult);
                    }
                    else
                    {
                        var paymentResult = new PaymentResult();
                        paymentResult = paymentResult.Failed("پرداخت سفارش شما با مشکل مواجه گردیده است.در صورت کسر از حساب شما مبلغ توسط سامانه بازگردانده خواهد شد");
                        return RedirectToPage("/PaymentResult", paymentResult);
                    }
            }
           
            var paymentResult1 = new PaymentResult();
            paymentResult1 = paymentResult1.Failed("پرداخت سفارش شما با مشکل مواجه گردیده است.در صورت کسر از حساب شما مبلغ توسط سامانه بازگردانده خواهد شد");
            return RedirectToPage("/PaymentResult", paymentResult1);

        }
        private class wSContext
        {
            public string UserId { get; set; }
            public string Password { get; set; }
        }
        private class generateTokenForApprove
        {
            public wSContext WSContext = new wSContext();
            public string Token { get; set; }
            public string RefNum { get; set; }


        }
    }
}
