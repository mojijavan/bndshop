#pragma checksum "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9be930b15574ba0129307959f5ab8894f2e4ffe7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Inventory.Areas_Administration_Pages_Inventory_OperationLog), @"mvc.1.0.view", @"/Areas/Administration/Pages/Inventory/OperationLog.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Administration/Pages/Inventory/OperationLog.cshtml", typeof(ServiceHost.Pages.Inventory.Areas_Administration_Pages_Inventory_OperationLog))]
namespace ServiceHost.Pages.Inventory
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9be930b15574ba0129307959f5ab8894f2e4ffe7", @"/Areas/Administration/Pages/Inventory/OperationLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Areas/Administration/Pages/_ViewImports.cshtml")]
    public class Areas_Administration_Pages_Inventory_OperationLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<InventoryManagement.Application.Contract.Inventory.InventoryOperationViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(100, 550, true);
            WriteLiteral(@"
<div class=""modal-header"">
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
    <h4 class=""modal-title"">سوابق گردش انبار</h4>
</div>

<div class=""modal-body"">
    <table class=""table table-bordered"">
        <thead>
            <tr>
                <th>#</th>
                <th>تعداد</th>
                <th>تاریخ</th>
                <th>عملیات</th>
                <th>موجودی فعلی</th>
                <th>عملگر</th>
                <th>توضیحات</th>
        </thead>
        <tbody>
");
            EndContext();
#line 23 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(707, 19, true);
            WriteLiteral("                <tr");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 726, "\"", 791, 2);
            WriteAttributeValue("", 734, "text-white", 734, 10, true);
#line 25 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
WriteAttributeValue(" ", 744, item.Operation ? "bg-success" : "bg-danger", 745, 46, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(792, 27, true);
            WriteLiteral(">\r\n                    <td>");
            EndContext();
            BeginContext(820, 7, false);
#line 26 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                   Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(827, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(859, 10, false);
#line 27 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                   Write(item.Count);

#line default
#line hidden
            EndContext();
            BeginContext(869, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(901, 18, false);
#line 28 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                   Write(item.OperationDate);

#line default
#line hidden
            EndContext();
            BeginContext(919, 33, true);
            WriteLiteral("</td>\r\n                    <td>\r\n");
            EndContext();
#line 30 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                         if (item.Operation)
                        {

#line default
#line hidden
            BeginContext(1025, 49, true);
            WriteLiteral("                            <span>افزایش</span>\r\n");
            EndContext();
#line 33 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1158, 47, true);
            WriteLiteral("                            <span>کاهش</span>\r\n");
            EndContext();
#line 37 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                        }

#line default
#line hidden
            BeginContext(1232, 51, true);
            WriteLiteral("                    </td>\r\n                    <td>");
            EndContext();
            BeginContext(1284, 17, false);
#line 39 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                   Write(item.CurrentCount);

#line default
#line hidden
            EndContext();
            BeginContext(1301, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1333, 13, false);
#line 40 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                   Write(item.Operator);

#line default
#line hidden
            EndContext();
            BeginContext(1346, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1378, 16, false);
#line 41 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                   Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1394, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 43 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
            }

#line default
#line hidden
            BeginContext(1439, 179, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n<div class=\"modal-footer\">\r\n        <button type=\"button\" class=\"btn btn-default waves-effect\" data-dismiss=\"modal\">بستن</button>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<InventoryManagement.Application.Contract.Inventory.InventoryOperationViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
