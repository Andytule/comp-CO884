#pragma checksum "C:\Users\andyt\Documents\School\COMP CO884 - Web Applic ASP.NET\Assignments\assignment3\assignment3\Views\Divisions\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "efafe60b179c6e0ecbdf78d221da94ceabdd8048"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Divisions_Index), @"mvc.1.0.view", @"/Views/Divisions/Index.cshtml")]
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
#line 1 "C:\Users\andyt\Documents\School\COMP CO884 - Web Applic ASP.NET\Assignments\assignment3\assignment3\Views\_ViewImports.cshtml"
using assignment3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\andyt\Documents\School\COMP CO884 - Web Applic ASP.NET\Assignments\assignment3\assignment3\Views\_ViewImports.cshtml"
using assignment3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efafe60b179c6e0ecbdf78d221da94ceabdd8048", @"/Views/Divisions/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab3879854b2ce9c1f75100917a1d3fe48d62735c", @"/Views/_ViewImports.cshtml")]
    public class Views_Divisions_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<assignment3.Models.Division>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\andyt\Documents\School\COMP CO884 - Web Applic ASP.NET\Assignments\assignment3\assignment3\Views\Divisions\Index.cshtml"
  
    ViewData["Title"] = "Divisions";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Divisions</h1>\r\n<h2>HASC features the following divisions.</h2>\r\n<table class=\"table\">\r\n    <tbody>\r\n");
#nullable restore
#line 11 "C:\Users\andyt\Documents\School\COMP CO884 - Web Applic ASP.NET\Assignments\assignment3\assignment3\Views\Divisions\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 14 "C:\Users\andyt\Documents\School\COMP CO884 - Web Applic ASP.NET\Assignments\assignment3\assignment3\Views\Divisions\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DivisionName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 17 "C:\Users\andyt\Documents\School\COMP CO884 - Web Applic ASP.NET\Assignments\assignment3\assignment3\Views\Divisions\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<p>Age is determined as of March 1 of each year.</p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<assignment3.Models.Division>> Html { get; private set; }
    }
}
#pragma warning restore 1591