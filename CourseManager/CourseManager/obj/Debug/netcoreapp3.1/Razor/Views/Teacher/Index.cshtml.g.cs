#pragma checksum "C:\Users\ZMiles\classwork-miles-zach\CourseManager\CourseManager\Views\Teacher\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a1b61d858b813210c9ecc964b4ba365dbdec6cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_Index), @"mvc.1.0.view", @"/Views/Teacher/Index.cshtml")]
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
#line 1 "C:\Users\ZMiles\classwork-miles-zach\CourseManager\CourseManager\Views\_ViewImports.cshtml"
using CourseManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ZMiles\classwork-miles-zach\CourseManager\CourseManager\Views\_ViewImports.cshtml"
using CourseManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1b61d858b813210c9ecc964b4ba365dbdec6cc", @"/Views/Teacher/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86a0572f074d3b8a640e694913b8cb8b34518460", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Teacher>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<table>\r\n\r\n");
#nullable restore
#line 7 "C:\Users\ZMiles\classwork-miles-zach\CourseManager\CourseManager\Views\Teacher\Index.cshtml"
     foreach (Teacher t in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 10 "C:\Users\ZMiles\classwork-miles-zach\CourseManager\CourseManager\Views\Teacher\Index.cshtml"
           Write(Html.ActionLink(t.Name, "Details", new { id = t.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 11 "C:\Users\ZMiles\classwork-miles-zach\CourseManager\CourseManager\Views\Teacher\Index.cshtml"
           Write(t.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 12 "C:\Users\ZMiles\classwork-miles-zach\CourseManager\CourseManager\Views\Teacher\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id = t.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>Delete</td>\r\n        </tr>\r\n");
#nullable restore
#line 15 "C:\Users\ZMiles\classwork-miles-zach\CourseManager\CourseManager\Views\Teacher\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Teacher>> Html { get; private set; }
    }
}
#pragma warning restore 1591