#pragma checksum "D:\mahboy\Project\School\School\Views\Products\ListOfProducts.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ae9b0f7a286a05ae1fc6b0eef5d32fe4161f665e85f6d486349555a6a04b3a30"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(School.Pages.Products.Views_Products_ListOfProducts), @"mvc.1.0.view", @"/Views/Products/ListOfProducts.cshtml")]
namespace School.Pages.Products
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\mahboy\Project\School\School\Views\_ViewImports.cshtml"
using School

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"ae9b0f7a286a05ae1fc6b0eef5d32fe4161f665e85f6d486349555a6a04b3a30", @"/Views/Products/ListOfProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"5e55d1596bbe152d1c44c4dae46165bf205fabf82f75b1ee4ecc55d7267c4a94", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_ListOfProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<School.Domain.ViewModels.LoginAndRegistration.ListOfProductsViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "price-asc", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "price-desc", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToArchive", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Archive", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\mahboy\Project\School\School\Views\Products\ListOfProducts.cshtml"
  
    Layout = "Layout4";
    ViewData["Title"] = "Товары";

#line default
#line hidden
#nullable disable

            WriteLiteral(@"

<div class=""container-list-products"">
    <div class=""link-page"">
        <a href=""/Home/SiteInformation"">Главная</a> >
        <a href=""/Catalog/Catalog"">Категории</a> >
        Товары
    </div>
    <div class=""filter"">
        <h3>Фильтр</h3>
    </div>
</div>
<div class=""sorts"">
    <label for=""sort-options"">Сортировать по:</label>
    <select id=""sort-options"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae9b0f7a286a05ae1fc6b0eef5d32fe4161f665e85f6d486349555a6a04b3a306214", async() => {
                WriteLiteral("Цена: от меньшей к большей");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae9b0f7a286a05ae1fc6b0eef5d32fe4161f665e85f6d486349555a6a04b3a307425", async() => {
                WriteLiteral("Цена: от большей к меньшей");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </select>\r\n\r\n</div>\r\n<div class=\"container-products\">\r\n    <div class=\"list-products\">\r\n");
#nullable restore
#line 29 "D:\mahboy\Project\School\School\Views\Products\ListOfProducts.cshtml"
         foreach (var item in Model.Products)
        {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <div class=\"tour-item\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 875, "\"", 896, 1);
            WriteAttributeValue("", 881, 
#nullable restore
#line 32 "D:\mahboy\Project\School\School\Views\Products\ListOfProducts.cshtml"
                       item.PathImage

#line default
#line hidden
#nullable disable
            , 881, 15, false);
            EndWriteAttribute();
            WriteLiteral(" alt=\"Товар\" class=\"item-tour-img\" />\r\n            <div class=\"item-info\">\r\n                <h2>");
            Write(
#nullable restore
#line 34 "D:\mahboy\Project\School\School\Views\Products\ListOfProducts.cshtml"
                     item.Name

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</h2>\r\n                <p>");
            Write(
#nullable restore
#line 35 "D:\mahboy\Project\School\School\Views\Products\ListOfProducts.cshtml"
                    item.Opisanie

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n            </div>\r\n            <table>\r\n                <tbody>\r\n                    <tr>\r\n                        <td><strong>");
            Write(
#nullable restore
#line 40 "D:\mahboy\Project\School\School\Views\Products\ListOfProducts.cshtml"
                                     item.Price

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" руб</strong></td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae9b0f7a286a05ae1fc6b0eef5d32fe4161f665e85f6d486349555a6a04b3a3010592", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"productId\"");
                BeginWriteAttribute("value", " value=\"", 1423, "\"", 1439, 1);
                WriteAttributeValue("", 1431, 
#nullable restore
#line 46 "D:\mahboy\Project\School\School\Views\Products\ListOfProducts.cshtml"
                                                              item.Id

#line default
#line hidden
#nullable disable
                , 1431, 8, false);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"productName\"");
                BeginWriteAttribute("value", " value=\"", 1500, "\"", 1518, 1);
                WriteAttributeValue("", 1508, 
#nullable restore
#line 47 "D:\mahboy\Project\School\School\Views\Products\ListOfProducts.cshtml"
                                                                item.Name

#line default
#line hidden
#nullable disable
                , 1508, 10, false);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"price\"");
                BeginWriteAttribute("value", " value=\"", 1573, "\"", 1592, 1);
                WriteAttributeValue("", 1581, 
#nullable restore
#line 48 "D:\mahboy\Project\School\School\Views\Products\ListOfProducts.cshtml"
                                                          item.Price

#line default
#line hidden
#nullable disable
                , 1581, 11, false);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"quantity\" value=\"1\" /> <!-- Или передайте нужное количество -->\r\n                <button type=\"submit\" class=\"btn btn-heart\">Архив</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n            <!-- Форма для добавления товара в корзину -->\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae9b0f7a286a05ae1fc6b0eef5d32fe4161f665e85f6d486349555a6a04b3a3014316", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"productId\"");
                BeginWriteAttribute("value", " value=\"", 1999, "\"", 2015, 1);
                WriteAttributeValue("", 2007, 
#nullable restore
#line 56 "D:\mahboy\Project\School\School\Views\Products\ListOfProducts.cshtml"
                                                              item.Id

#line default
#line hidden
#nullable disable
                , 2007, 8, false);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <button type=\"submit\" class=\"btn btn-primary\">В корзину</button>\r\n                <button type=\"submit\" class=\"btn btn-primary\">Купить</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 61 "D:\mahboy\Project\School\School\Views\Products\ListOfProducts.cshtml"
        }

#line default
#line hidden
#nullable disable

            WriteLiteral("    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<School.Domain.ViewModels.LoginAndRegistration.ListOfProductsViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
