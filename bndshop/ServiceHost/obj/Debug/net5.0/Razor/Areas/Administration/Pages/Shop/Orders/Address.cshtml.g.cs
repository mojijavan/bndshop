#pragma checksum "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Shop\Orders\Address.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f8848527da31bcd6d6069b14eb73aeac327c765"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shop.Orders.Areas_Administration_Pages_Shop_Orders_Address), @"mvc.1.0.view", @"/Areas/Administration/Pages/Shop/Orders/Address.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Administration/Pages/Shop/Orders/Address.cshtml", typeof(ServiceHost.Pages.Shop.Orders.Areas_Administration_Pages_Shop_Orders_Address))]
namespace ServiceHost.Pages.Shop.Orders
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f8848527da31bcd6d6069b14eb73aeac327c765", @"/Areas/Administration/Pages/Shop/Orders/Address.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Areas/Administration/Pages/_ViewImports.cshtml")]
    public class Areas_Administration_Pages_Shop_Orders_Address : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AddressManagement.Application.Contracts.Address.EditAddress>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(77, 223, true);
            WriteLiteral("\r\n<div class=\"modal-header\">\r\n    <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">×</button>\r\n    <h4 class=\"modal-title\">آدرس</h4>\r\n</div>\r\n\r\n<div class=\"modal-body\">    \r\n    <div>\r\n        <p>");
            EndContext();
            BeginContext(301, 17, false);
#line 13 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Shop\Orders\Address.cshtml"
      Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(318, 165, true);
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n<div class=\"modal-footer\">\r\n        <button type=\"button\" class=\"btn btn-default waves-effect\" data-dismiss=\"modal\">بستن</button>\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AddressManagement.Application.Contracts.Address.EditAddress> Html { get; private set; }
    }
}
#pragma warning restore 1591
