#pragma checksum "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\Home\SysDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a6a83053235959db730789a5368ef20dcbbf79d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SysDetails), @"mvc.1.0.view", @"/Views/Home/SysDetails.cshtml")]
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
#line 1 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\_ViewImports.cshtml"
using Student_Hostel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\_ViewImports.cshtml"
using Student_Hostel.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a6a83053235959db730789a5368ef20dcbbf79d", @"/Views/Home/SysDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6238afcd82c2026c55d674019901d3d1504ecfee", @"/_ViewImports.cshtml")]
    public class Views_Home_SysDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SysUserDetail>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\r\n    <h2>显示管理员信息</h2>\r\n");
            WriteLiteral("    <div>\r\n        员工号：");
#nullable restore
#line 11 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\Home\SysDetails.cshtml"
       Write(Model.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        姓名：");
#nullable restore
#line 14 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\Home\SysDetails.cshtml"
      Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        性别 ：");
#nullable restore
#line 17 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\Home\SysDetails.cshtml"
       Write(Model.Sex);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        电话：");
#nullable restore
#line 20 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\Home\SysDetails.cshtml"
      Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        <div>\r\n            密码：");
#nullable restore
#line 24 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\Home\SysDetails.cshtml"
          Write(Model.Pwd);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <a href=\"/Home/SysEdit\">修改</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SysUserDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591
