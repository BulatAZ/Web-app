#pragma checksum "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\ChangeStatus.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "212adff209755f780c0dae177646c16e9d4e69cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Requests_ChangeStatus), @"mvc.1.0.view", @"/Views/Requests/ChangeStatus.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Requests/ChangeStatus.cshtml", typeof(AspNetCore.Views_Requests_ChangeStatus))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"212adff209755f780c0dae177646c16e9d4e69cf", @"/Views/Requests/ChangeStatus.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31c00c09162de4a4a5279e54ac51880c75d51122", @"/Views/_ViewImports.cshtml")]
    public class Views_Requests_ChangeStatus : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RequestAccounting3.Models.Requests.RequestChange>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeStatus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Requests", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\ChangeStatus.cshtml"
  
    ViewData["Title"] = "Change status";

#line default
#line hidden
            BeginContext(106, 862, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a79aa249bc66427091135b5220b21055", async() => {
                BeginContext(178, 317, true);
                WriteLiteral(@"
    <table class=""table-condensed"">
        <tr>
            <td>ID</td>
            <td>Author id</td>
            <td>Customer name</td>
            <td>Phone</td>
            <td>Text</td>
            <td>Request date</td>
            <td>Choose status</td>
        </tr>
        <tr>
            <td>");
                EndContext();
                BeginContext(496, 8, false);
#line 17 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\ChangeStatus.cshtml"
           Write(Model.id);

#line default
#line hidden
                EndContext();
                BeginContext(504, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(528, 16, false);
#line 18 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\ChangeStatus.cshtml"
           Write(Model.operatorId);

#line default
#line hidden
                EndContext();
                BeginContext(544, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(568, 23, false);
#line 19 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\ChangeStatus.cshtml"
           Write(Model.customerFirstName);

#line default
#line hidden
                EndContext();
                BeginContext(591, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(593, 22, false);
#line 19 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\ChangeStatus.cshtml"
                                    Write(Model.customerLastName);

#line default
#line hidden
                EndContext();
                BeginContext(615, 24, true);
                WriteLiteral(" </td>\r\n            <td>");
                EndContext();
                BeginContext(640, 19, false);
#line 20 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\ChangeStatus.cshtml"
           Write(Model.customerPhone);

#line default
#line hidden
                EndContext();
                BeginContext(659, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(683, 10, false);
#line 21 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\ChangeStatus.cshtml"
           Write(Model.text);

#line default
#line hidden
                EndContext();
                BeginContext(693, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(717, 17, false);
#line 22 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\ChangeStatus.cshtml"
           Write(Model.requestDate);

#line default
#line hidden
                EndContext();
                BeginContext(734, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(758, 75, false);
#line 23 "C:\Users\bulat.zamanov\source\repos\RequestAccounting3\RequestAccounting3\Views\Requests\ChangeStatus.cshtml"
           Write(Html.DropDownListFor(model => model.statusId, ViewBag.Status as SelectList));

#line default
#line hidden
                EndContext();
                BeginContext(833, 128, true);
                WriteLiteral("</td>\r\n    </tr>\r\n</table>\r\n<div class=\"form-group\">\r\n    <input type=\"submit\" value=\"Save\" class=\"btn btn-default\" />\r\n</div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(968, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RequestAccounting3.Models.Requests.RequestChange> Html { get; private set; }
    }
}
#pragma warning restore 1591
