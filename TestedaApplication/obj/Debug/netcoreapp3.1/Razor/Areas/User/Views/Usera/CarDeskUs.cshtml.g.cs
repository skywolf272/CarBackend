#pragma checksum "C:\programming\c# ASP\Testion\TestedaApplication\TestedaApplication\Areas\User\Views\Usera\CarDeskUs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9af8e48c0afe1733867e64ba3e6fb23801be1a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Usera_CarDeskUs), @"mvc.1.0.view", @"/Areas/User/Views/Usera/CarDeskUs.cshtml")]
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
#line 1 "C:\programming\c# ASP\Testion\TestedaApplication\TestedaApplication\Areas\User\Views\Usera\CarDeskUs.cshtml"
using TestedaApplication.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9af8e48c0afe1733867e64ba3e6fb23801be1a1", @"/Areas/User/Views/Usera/CarDeskUs.cshtml")]
    public class Areas_User_Views_Usera_CarDeskUs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Car>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\programming\c# ASP\Testion\TestedaApplication\TestedaApplication\Areas\User\Views\Usera\CarDeskUs.cshtml"
  
    Layout = "~/Views/Shared/_LayoutUs.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <p>");
#nullable restore
#line 9 "C:\programming\c# ASP\Testion\TestedaApplication\TestedaApplication\Areas\User\Views\Usera\CarDeskUs.cshtml"
  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <img class=\"img-thumbnail\"");
            BeginWriteAttribute("src", " src=\"", 190, "\"", 208, 1);
#nullable restore
#line 10 "C:\programming\c# ASP\Testion\TestedaApplication\TestedaApplication\Areas\User\Views\Usera\CarDeskUs.cshtml"
WriteAttributeValue("", 196, Model.Image, 196, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 209, "\"", 226, 1);
#nullable restore
#line 10 "C:\programming\c# ASP\Testion\TestedaApplication\TestedaApplication\Areas\User\Views\Usera\CarDeskUs.cshtml"
WriteAttributeValue("", 215, Model.Name, 215, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n    <p>");
#nullable restore
#line 11 "C:\programming\c# ASP\Testion\TestedaApplication\TestedaApplication\Areas\User\Views\Usera\CarDeskUs.cshtml"
  Write(Model.WholeDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <button class=\"btn btn-outline-info\">Взять напрокат</button>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Car> Html { get; private set; }
    }
}
#pragma warning restore 1591