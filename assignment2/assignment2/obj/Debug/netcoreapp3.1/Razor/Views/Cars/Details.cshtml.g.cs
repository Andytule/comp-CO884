#pragma checksum "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9044007e588adeefbebf5469dbda598559989fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cars_Details), @"mvc.1.0.view", @"/Views/Cars/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cars/Details.cshtml", typeof(AspNetCore.Views_Cars_Details))]
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
#line 1 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\_ViewImports.cshtml"
using assignment2;

#line default
#line hidden
#line 2 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\_ViewImports.cshtml"
using assignment2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9044007e588adeefbebf5469dbda598559989fb", @"/Views/Cars/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7d14921b6e9a473ffe36cf77cfbdf8a2e29f453", @"/Views/_ViewImports.cshtml")]
    public class Views_Cars_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<assignment2.Models.Car>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(31, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(76, 126, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Car</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(203, 40, false);
#line 14 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Make));

#line default
#line hidden
            EndContext();
            BeginContext(243, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(307, 36, false);
#line 17 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
       Write(Html.DisplayFor(model => model.Make));

#line default
#line hidden
            EndContext();
            BeginContext(343, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(406, 41, false);
#line 20 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Model));

#line default
#line hidden
            EndContext();
            BeginContext(447, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(511, 37, false);
#line 23 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
       Write(Html.DisplayFor(model => model.Model));

#line default
#line hidden
            EndContext();
            BeginContext(548, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(611, 41, false);
#line 26 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Color));

#line default
#line hidden
            EndContext();
            BeginContext(652, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(716, 37, false);
#line 29 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
       Write(Html.DisplayFor(model => model.Color));

#line default
#line hidden
            EndContext();
            BeginContext(753, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(816, 40, false);
#line 32 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Year));

#line default
#line hidden
            EndContext();
            BeginContext(856, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(920, 36, false);
#line 35 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
       Write(Html.DisplayFor(model => model.Year));

#line default
#line hidden
            EndContext();
            BeginContext(956, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1019, 48, false);
#line 38 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PurchaseDate));

#line default
#line hidden
            EndContext();
            BeginContext(1067, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1131, 44, false);
#line 41 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
       Write(Html.DisplayFor(model => model.PurchaseDate));

#line default
#line hidden
            EndContext();
            BeginContext(1175, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1238, 46, false);
#line 44 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Kilometres));

#line default
#line hidden
            EndContext();
            BeginContext(1284, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1348, 42, false);
#line 47 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
       Write(Html.DisplayFor(model => model.Kilometres));

#line default
#line hidden
            EndContext();
            BeginContext(1390, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1438, 54, false);
#line 52 "C:\Users\andyt\Desktop\assignment2\assignment2\Views\Cars\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1492, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1500, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9044007e588adeefbebf5469dbda598559989fb9205", async() => {
                BeginContext(1522, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1538, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<assignment2.Models.Car> Html { get; private set; }
    }
}
#pragma warning restore 1591