#pragma checksum "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f371e91d5e7d2690519174742f746f3c49cff688"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.ProductCategoryWithProduct.Pages_Shared_Components_ProductCategoryWithProduct_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/ProductCategoryWithProduct/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Pages/Shared/Components/ProductCategoryWithProduct/Default.cshtml", typeof(ServiceHost.Pages.Shared.Components.ProductCategoryWithProduct.Pages_Shared_Components_ProductCategoryWithProduct_Default))]
namespace ServiceHost.Pages.Shared.Components.ProductCategoryWithProduct
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f371e91d5e7d2690519174742f746f3c49cff688", @"/Pages/Shared/Components/ProductCategoryWithProduct/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_ProductCategoryWithProduct_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_01_BndShopQuery.Contracts.ProductCategory.ProductCategoryQueryModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(83, 895, true);
            WriteLiteral(@"
<div class=""single-row-slider-tab-area section-space"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""section-title-wrapper text-center section-space--half"">
                    <h2 class=""section-title"">محصولات ما</h2>
                    <p class=""section-subtitle"">
                        لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است
                    </p>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""tab-slider-wrapper"">
                    <div class=""tab-product-navigation"">
                        <div class=""nav nav-tabs justify-content-center"" id=""nav-tab2"" role=""tablist"">
");
            EndContext();
#line 20 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                             foreach (var category in Model)
                            {

#line default
#line hidden
            BeginContext(1071, 34, true);
            WriteLiteral("                                <a");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1105, "\"", 1175, 3);
            WriteAttributeValue("", 1113, "nav-item", 1113, 8, true);
            WriteAttributeValue(" ", 1121, "nav-link", 1122, 9, true);
#line 22 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue(" ", 1130, Model.First() == category ? "active" : "", 1131, 44, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 1176, "\"", 1205, 2);
            WriteAttributeValue("", 1181, "product-tab-", 1181, 12, true);
#line 22 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue("", 1193, category.Id, 1193, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1206, 18, true);
            WriteLiteral(" data-toggle=\"tab\"");
            EndContext();
            BeginWriteAttribute("href", "\r\n                                   href=\"", 1224, "\"", 1295, 2);
            WriteAttributeValue("", 1267, "#product-series-", 1267, 16, true);
#line 23 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue("", 1283, category.Id, 1283, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1296, 33, true);
            WriteLiteral(" role=\"tab\" aria-selected=\"true\">");
            EndContext();
            BeginContext(1330, 13, false);
#line 23 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                                  Write(category.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1343, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 24 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(1380, 107, true);
            WriteLiteral("                        </div>\r\n                    </div>\r\n                    <div class=\"tab-content\">\r\n");
            EndContext();
#line 28 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                         foreach (var category in Model)
                        {

#line default
#line hidden
            BeginContext(1572, 32, true);
            WriteLiteral("                            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1604, "\"", 1675, 4);
            WriteAttributeValue("", 1612, "tab-pane", 1612, 8, true);
            WriteAttributeValue(" ", 1620, "fade", 1621, 5, true);
            WriteAttributeValue(" ", 1625, "show", 1626, 5, true);
#line 30 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue(" ", 1630, Model.First() == category ? "active" : "", 1631, 44, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 1676, "\"", 1708, 2);
            WriteAttributeValue("", 1681, "product-series-", 1681, 15, true);
#line 30 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue("", 1696, category.Id, 1696, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1709, 1574, true);
            WriteLiteral(@" role=""tabpanel""
                                 aria-labelledby=""product-tab-1"">
                                <div class=""single-row-slider-wrapper"">
                                    <div class=""ht-slick-slider"" data-slick-setting='{
                                ""slidesToShow"": 4,
                                ""slidesToScroll"": 1,
                                ""arrows"": true,
                                ""autoplay"": false,
                                ""autoplaySpeed"": 5000,
                                ""speed"": 1000,
                                ""infinite"": true,
                                ""rtl"": true,
                                ""prevArrow"": {""buttonClass"": ""slick-prev"", ""iconClass"": ""ion-chevron-left"" },
                                ""nextArrow"": {""buttonClass"": ""slick-next"", ""iconClass"": ""ion-chevron-right"" }
                            }' data-slick-responsive='[
                                {""breakpoint"":1501, ""settings"": {""slidesToShow"": 4} },
   ");
            WriteLiteral(@"                             {""breakpoint"":1199, ""settings"": {""slidesToShow"": 4, ""arrows"": false} },
                                {""breakpoint"":991, ""settings"": {""slidesToShow"": 3, ""arrows"": false} },
                                {""breakpoint"":767, ""settings"": {""slidesToShow"": 2, ""arrows"": false} },
                                {""breakpoint"":575, ""settings"": {""slidesToShow"": 2, ""arrows"": false} },
                                {""breakpoint"":479, ""settings"": {""slidesToShow"": 1, ""arrows"": false} }
                            ]'>
");
            EndContext();
#line 52 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                         foreach (var product in category.Products)
                                        {

#line default
#line hidden
            BeginContext(3411, 240, true);
            WriteLiteral("                                            <div class=\"col\">\r\n                                                <div class=\"single-grid-product\">\r\n                                                    <div class=\"single-grid-product__image\">\r\n");
            EndContext();
#line 57 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                         if (product.HasDiscount)
                                                        {

#line default
#line hidden
            BeginContext(3793, 186, true);
            WriteLiteral("                                                            <div class=\"single-grid-product__label\">\r\n                                                                <span class=\"sale\">-");
            EndContext();
            BeginContext(3980, 20, false);
#line 60 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                               Write(product.DiscountRate);

#line default
#line hidden
            EndContext();
            BeginContext(4000, 78, true);
            WriteLiteral("%</span>\r\n                                                            </div>\r\n");
            EndContext();
#line 62 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                        }

#line default
#line hidden
            BeginContext(4137, 56, true);
            WriteLiteral("                                                        ");
            EndContext();
            BeginContext(4193, 344, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f371e91d5e7d2690519174742f746f3c49cff68813367", async() => {
                BeginContext(4245, 66, true);
                WriteLiteral("\r\n                                                            <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 4311, "\"", 4333, 1);
#line 64 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue("", 4317, product.Picture, 4317, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("title", " title=\"", 4334, "\"", 4363, 1);
#line 64 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue("", 4342, product.PictureTitle, 4342, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4364, 18, true);
                WriteLiteral(" class=\"img-fluid\"");
                EndContext();
                BeginWriteAttribute("alt", "\r\n                                                                 alt=\"", 4382, "\"", 4473, 1);
#line 65 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
WriteAttributeValue("", 4454, product.PictureAlt, 4454, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4474, 59, true);
                WriteLiteral(">\r\n                                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 63 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                 WriteLiteral(product.Slug);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4537, 415, true);
            WriteLiteral(@"
                                                    </div>
                                                    <div class=""single-grid-product__content"">
                                                        <div class=""single-grid-product__category-rating"">
                                                            <span class=""category"">
                                                                ");
            EndContext();
            BeginContext(4952, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f371e91d5e7d2690519174742f746f3c49cff68817687", async() => {
                BeginContext(5014, 16, false);
#line 71 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                                                        Write(product.Category);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 71 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                                 WriteLiteral(category.Slug);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5034, 972, true);
            WriteLiteral(@"
                                                            </span>
                                                            <span class=""rating"">
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star-outline""></i>
                                                            </span>
                                                        </div>

                                                        <h3 class=""single-grid-product__title"">
                                                            ");
            EndContext();
            BeginContext(6006, 197, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f371e91d5e7d2690519174742f746f3c49cff68821376", async() => {
                BeginContext(6058, 66, true);
                WriteLiteral("\r\n                                                                ");
                EndContext();
                BeginContext(6125, 12, false);
#line 84 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                           Write(product.Name);

#line default
#line hidden
                EndContext();
                BeginContext(6137, 62, true);
                WriteLiteral("\r\n                                                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 83 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                     WriteLiteral(product.Slug);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6203, 161, true);
            WriteLiteral("\r\n                                                        </h3>\r\n                                                        <p class=\"single-grid-product__price\">\r\n");
            EndContext();
#line 88 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                             if (product.HasDiscount)
                                                            {

#line default
#line hidden
            BeginContext(6514, 95, true);
            WriteLiteral("                                                                <span class=\"discounted-price\">");
            EndContext();
            BeginContext(6610, 25, false);
#line 90 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                          Write(product.PriceWithDiscount);

#line default
#line hidden
            EndContext();
            BeginContext(6635, 115, true);
            WriteLiteral(" تومان</span>\r\n                                                                <span class=\"main-price discounted\">");
            EndContext();
            BeginContext(6751, 17, false);
#line 91 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                               Write(product.UnitPrice);

#line default
#line hidden
            EndContext();
            BeginContext(6768, 15, true);
            WriteLiteral(" تومان</span>\r\n");
            EndContext();
#line 92 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                            }
                                                            else
                                                            {

#line default
#line hidden
            BeginContext(6975, 89, true);
            WriteLiteral("                                                                <span class=\"main-price\">");
            EndContext();
            BeginContext(7065, 17, false);
#line 95 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                                                    Write(product.UnitPrice);

#line default
#line hidden
            EndContext();
            BeginContext(7082, 15, true);
            WriteLiteral(" تومان</span>\r\n");
            EndContext();
#line 96 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                                            }

#line default
#line hidden
            BeginContext(7160, 230, true);
            WriteLiteral("                                                        </p>\r\n                                                    </div>\r\n                                                </div>\r\n                                            </div>\r\n");
            EndContext();
#line 101 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                                        }

#line default
#line hidden
            BeginContext(7433, 120, true);
            WriteLiteral("                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
            EndContext();
#line 105 "D:\jahanpoor\Projects\bndshop\Code\bndshop\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\Default.cshtml"
                        }

#line default
#line hidden
            BeginContext(7580, 108, true);
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_01_BndShopQuery.Contracts.ProductCategory.ProductCategoryQueryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
