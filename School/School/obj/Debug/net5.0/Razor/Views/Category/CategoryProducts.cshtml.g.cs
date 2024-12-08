#pragma checksum "D:\Project\School\School\Views\Category\CategoryProducts.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "30444c97a5033f27def1ad1e47a1d1e5aa09e29064a810029d6ac0b22b28bdfc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(School.Pages.Category.Views_Category_CategoryProducts), @"mvc.1.0.view", @"/Views/Category/CategoryProducts.cshtml")]
namespace School.Pages.Category
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
#line 1 "D:\Project\School\School\Views\_ViewImports.cshtml"
using School

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"30444c97a5033f27def1ad1e47a1d1e5aa09e29064a810029d6ac0b22b28bdfc", @"/Views/Category/CategoryProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"5e55d1596bbe152d1c44c4dae46165bf205fabf82f75b1ee4ecc55d7267c4a94", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Category_CategoryProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<School.Domain.ViewModels.LoginAndRegistration.CategoryProductsViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Project\School\School\Views\Category\CategoryProducts.cshtml"
  
    Layout = "Layout2";
    ViewData["Title"] = "Категории";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<div class=\"grid-container\">\r\n");
#nullable restore
#line 9 "D:\Project\School\School\Views\Category\CategoryProducts.cshtml"
     if (Model != null && Model.Count > 0)
    {
        

#line default
#line hidden
#nullable disable

#nullable restore
#line 11 "D:\Project\School\School\Views\Category\CategoryProducts.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable

            WriteLiteral("            <div class=\"card-category\"");
            BeginWriteAttribute("onclick", " onclick=\"", 328, "\"", 423, 5);
            WriteAttributeValue("", 338, "window.location.href", 338, 20, true);
            WriteAttributeValue(" ", 358, "=", 359, 2, true);
            WriteAttributeValue(" ", 360, "\'", 361, 2, true);
            WriteAttributeValue("", 362, 
#nullable restore
#line 13 "D:\Project\School\School\Views\Category\CategoryProducts.cshtml"
                                                                         Url.Action("ListOfProducts","Products", new {Id = item.Id})

#line default
#line hidden
#nullable disable
            , 362, 60, false);
            WriteAttributeValue("", 422, "\'", 422, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"card-overlay\">\r\n                    <div class=\"card-title\">");
            Write(
#nullable restore
#line 15 "D:\Project\School\School\Views\Category\CategoryProducts.cshtml"
                                             item.Name

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 18 "D:\Project\School\School\Views\Category\CategoryProducts.cshtml"
        }

#line default
#line hidden
#nullable disable

#nullable restore
#line 18 "D:\Project\School\School\Views\Category\CategoryProducts.cshtml"
         
    }
    else
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <p>Нет доступных категорий.</p>\r\n");
#nullable restore
#line 23 "D:\Project\School\School\Views\Category\CategoryProducts.cshtml"
    }

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n");
#nullable restore
#line 25 "D:\Project\School\School\Views\Category\CategoryProducts.cshtml"
     if (ViewData["ErrorMessage"] != null)
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <div class=\"alert alert-danger\">\r\n            ");
            Write(
#nullable restore
#line 28 "D:\Project\School\School\Views\Category\CategoryProducts.cshtml"
             ViewData["ErrorMessage"]

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("   \r\n        </div>\r\n");
#nullable restore
#line 30 "D:\Project\School\School\Views\Category\CategoryProducts.cshtml"
    }

#line default
#line hidden
#nullable disable

            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<School.Domain.ViewModels.LoginAndRegistration.CategoryProductsViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591