#pragma checksum "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13354b752c0fd454f8bca54d534675b764d8a496"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_List), @"mvc.1.0.view", @"/Views/Order/List.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\_ViewImports.cshtml"
using PartsCatalog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\_ViewImports.cshtml"
using PartsCatalog.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\_ViewImports.cshtml"
using PartsCatalog.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\_ViewImports.cshtml"
using PartsCatalog.Infrastructure;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13354b752c0fd454f8bca54d534675b764d8a496", @"/Views/Order/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8588c6000c95141c6cf2829206ded2da589f119", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ListOrdersViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "/css/modal.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-href-include", "/lib/fontawesome/css/*.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MarkShipped", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
  
    ViewBag.Title = "Zamówienia";
    Layout = "_AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13354b752c0fd454f8bca54d534675b764d8a4965824", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "13354b752c0fd454f8bca54d534675b764d8a4966086", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 8 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "13354b752c0fd454f8bca54d534675b764d8a4967802", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.HrefInclude = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <link href=\"https://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css\" rel=\"stylesheet\">\r\n    \r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 15 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
 if (Model.Orders.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-bordered table-striped\">\r\n        <tr>\r\n            <th>Klient</th>\r\n            <th>Szczegóły klienta</th>\r\n            <th colspan=\"2\">Opis</th>\r\n            <th></th></tr>\r\n");
#nullable restore
#line 23 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
         foreach (Order o in Model.Orders)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n");
#nullable restore
#line 26 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                 foreach (var person in Model.Users)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                     if (person.Id == o.userId)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <th>");
#nullable restore
#line 30 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                       Write(person.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 30 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                    Write(person.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                        <th>
                            <button id=""mod"" class=""btn btn-secondary"">Details</button>
                            
                            <div id=""myModal"" class=""modal"">
                                <div class=""modal-content"">
                                    <span class=""close"">&times;</span>
                                    <p>");
#nullable restore
#line 37 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                  Write(person.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 37 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                               Write(person.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>\r\n                                        ");
#nullable restore
#line 38 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                   Write(person.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 38 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                                   Write(person.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 38 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                                                Write(person.Zip);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                                        ");
#nullable restore
#line 39 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                   Write(person.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 39 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                                  Write(person.Line1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 39 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                                                      if (@person.Line2 != null) { 

#line default
#line hidden
#nullable disable
            WriteLiteral("/ ");
#nullable restore
#line 39 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                                                                                      Write(person.Line2);

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                                                                                                               }

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>                                        \r\n                                        ");
#nullable restore
#line 40 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                   Write(person.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 40 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                                                 Write(person.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    \r\n                                    </p>\r\n                                </div>\r\n                            </div>\r\n\r\n                        </th>\r\n");
#nullable restore
#line 47 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th>Produkt</th>\r\n                <th>Ilość</th>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13354b752c0fd454f8bca54d534675b764d8a49615979", async() => {
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"orderId\"");
                BeginWriteAttribute("value", " value=\"", 2118, "\"", 2136, 1);
#nullable restore
#line 53 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
WriteAttributeValue("", 2126, o.OrderID, 2126, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <button type=\"submit\" class=\"btn btn-sm btn-danger\">\r\n                            Zrealizowane\r\n                        </button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
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
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 61 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
             foreach (CartLine line in o.Lines)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"2\"></td>\r\n                    <td>");
#nullable restore
#line 65 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                   Write(line.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 66 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
                   Write(line.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td></td>\r\n                </tr>\r\n");
#nullable restore
#line 69 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </table>\r\n");
#nullable restore
#line 73 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"

                    
                            
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">Brak niezrealizowanych zamówień</div>\r\n");
#nullable restore
#line 80 "C:\Users\asd\Desktop\projekt\2\PartsCatalog\Views\Order\List.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<script>

    'use strict';
    
    var modal = document.getElementById(""myModal"");

    let btn = document.querySelectorAll('#mod');

    var span = document.getElementsByClassName(""close"")[0];

    const over = document.querySelector('#overSpan');

    const openModal = function() 
    {
        modal.style.display = ""block"";
    }

    const closeModal = function() 
    {
        modal.style.display = ""none"";
    }



    btn.forEach(button => button.addEventListener('click', openModal));

    span.addEventListener('click', closeModal); 

    over.addEventListener('click', closeModal); 
        
console.log(btn);

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ListOrdersViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
