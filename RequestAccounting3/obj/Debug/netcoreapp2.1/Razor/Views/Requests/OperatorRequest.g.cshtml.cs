#pragma checksum "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\OperatorRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f71e6e968d15aad3b83de2937ad2a90e244fac5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Requests_OperatorRequest), @"mvc.1.0.view", @"/Views/Requests/OperatorRequest.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Requests/OperatorRequest.cshtml", typeof(AspNetCore.Views_Requests_OperatorRequest))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f71e6e968d15aad3b83de2937ad2a90e244fac5f", @"/Views/Requests/OperatorRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31c00c09162de4a4a5279e54ac51880c75d51122", @"/Views/_ViewImports.cshtml")]
    public class Views_Requests_OperatorRequest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RequestAccounting3.Models.Requests.RequestView>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Requests/Create"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("navbar-brand"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 6, true);
            WriteLiteral("    \r\n");
            EndContext();
            BeginContext(78, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\OperatorRequest.cshtml"
      
        ViewData["Title"] = "Request list";
    

#line default
#line hidden
            BeginContext(140, 70, true);
            WriteLiteral("\r\n    <h3>Requests</h3>\r\n    <ul class=\"nav navbar-nav\">\r\n        <li>");
            EndContext();
            BeginContext(210, 64, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a412f5407694d1ba33671a3a6a3c25b", async() => {
                BeginContext(259, 11, true);
                WriteLiteral("New request");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(274, 289, true);
            WriteLiteral(@"</li>
    </ul>

    <table class=""table-condensed"">
        <tr>
            <td>ID</td>
            <td>Customer name</td>
            <td>Phone</td>
            <td>Text</td>
            <td>Status</td>
            <td>Request date</td>
            <td></td>
        </tr>
");
            EndContext();
#line 23 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\OperatorRequest.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(612, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(651, 7, false);
#line 26 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\OperatorRequest.cshtml"
               Write(item.id);

#line default
#line hidden
            EndContext();
            BeginContext(658, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(686, 22, false);
#line 27 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\OperatorRequest.cshtml"
               Write(item.customerFirstName);

#line default
#line hidden
            EndContext();
            BeginContext(708, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(710, 21, false);
#line 27 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\OperatorRequest.cshtml"
                                       Write(item.customerLastName);

#line default
#line hidden
            EndContext();
            BeginContext(731, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(759, 18, false);
#line 28 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\OperatorRequest.cshtml"
               Write(item.customerPhone);

#line default
#line hidden
            EndContext();
            BeginContext(777, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(805, 9, false);
#line 29 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\OperatorRequest.cshtml"
               Write(item.text);

#line default
#line hidden
            EndContext();
            BeginContext(814, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(842, 11, false);
#line 30 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\OperatorRequest.cshtml"
               Write(item.status);

#line default
#line hidden
            EndContext();
            BeginContext(853, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(881, 16, false);
#line 31 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\OperatorRequest.cshtml"
               Write(item.requestDate);

#line default
#line hidden
            EndContext();
            BeginContext(897, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 33 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\OperatorRequest.cshtml"
        }

#line default
#line hidden
            BeginContext(934, 14, true);
            WriteLiteral("    </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RequestAccounting3.Models.Requests.RequestView>> Html { get; private set; }
    }
}
#pragma warning restore 1591
