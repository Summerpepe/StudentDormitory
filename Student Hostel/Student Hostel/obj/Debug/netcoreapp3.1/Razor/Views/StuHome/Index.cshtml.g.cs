#pragma checksum "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b618dbd40ee93ee1a437bad3e443b707864d4d33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StuHome_Index), @"mvc.1.0.view", @"/Views/StuHome/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b618dbd40ee93ee1a437bad3e443b707864d4d33", @"/Views/StuHome/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6238afcd82c2026c55d674019901d3d1504ecfee", @"/_ViewImports.cshtml")]
    public class Views_StuHome_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudentDetail>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b618dbd40ee93ee1a437bad3e443b707864d4d333485", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://cdn.staticfile.org/twitter-bootstrap/4.3.1/css/bootstrap.min.css"">
    <script src=""https://cdn.staticfile.org/jquery/3.2.1/jquery.min.js""></script>
    <script src=""https://cdn.staticfile.org/popper.js/1.15.0/umd/popper.min.js""></script>
    <script src=""https://cdn.staticfile.org/twitter-bootstrap/4.3.1/js/bootstrap.min.js""></script>
");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b618dbd40ee93ee1a437bad3e443b707864d4d334951", async() => {
                WriteLiteral(@"
    <nav class=""navbar navbar-expand-sm bg-primary navbar-dark"">
        <ul class=""navbar-nav"">
            <li class=""nav-item active"">
                <a class=""nav-link"" href=""/StuHome/index"">查看个人信息</a>
            </li>
            <li class=""nav-item"">
                <a class=""nav-link "" href=""/StuHome/AbsenceIndex"">我的考勤</a>
            </li>
            <li class=""nav-item"">
                <a class=""nav-link"" href=""/StuHome/DorIndex"">查看宿舍卫生</a>
            </li>
            <li class=""nav-item dropdown"">
                <a class=""nav-link dropdown-toggle"" data-toggle=""dropdown"" href=""#"">宿舍报修与查看</a>
                <div class=""dropdown-menu"">
                    <a class=""dropdown-item"" href=""/StuHome/AddRepair"">宿舍报修</a>
                    <a class=""dropdown-item"" href=""/StuHome/RepairIndex"">报修查看</a>
                </div>
            </li>
            <li class=""nav-item dropdown"">
                <a class=""nav-link dropdown-toggle"" data-toggle=""dropdown"" href=""#"">请假</a>
      ");
                WriteLiteral(@"          <div class=""dropdown-menu"">
                    <a class=""dropdown-item"" href=""/StuHome/AddLeave"">请假</a>
                    <a class=""dropdown-item"" href=""/StuHome/MyLeave"">我的请假</a>
                </div>
            </li>
            <li class=""nav-item dropdown"">
                <a class=""nav-link dropdown-toggle"" data-toggle=""dropdown"" href=""#"">用户信息</a>
                <div class=""dropdown-menu"">
                    <a class=""dropdown-item"" href=""/StuHome/StuDetails"">查看用户</a>
                    <a class=""dropdown-item"" href=""/StuHome/StuEdit"">修改密码</a>
                </div>
            </li>
            <li class=""nav-item"">
                <a class=""nav-link"" href=""/user/logout1"">退出</a>
            </li>
        </ul>
    </nav>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</html>
<div class=""container"">
        <table class=""table table-bordered"">
            <tbody>
                <tr>
                    <td colspan=""3"" align=""center"" width=""380""><h2>学生信息</h2></td>
                </tr>
                <tr>
                    <td rowspan=""9"" cellspacing=""1px"" align=""center"" width=""260"">
");
#nullable restore
#line 63 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\Index.cshtml"
                          
                            var photoPath = "/images/" + @Model.PhotoPath;
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img");
            BeginWriteAttribute("src", " src=\"", 2880, "\"", 2896, 1);
#nullable restore
#line 66 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\Index.cshtml"
WriteAttributeValue("", 2886, photoPath, 2886, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"240\" />\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td align=\"right\" width=\"120\" height=\"40\">学号:</td>\r\n                    <td width=\"120\">");
#nullable restore
#line 71 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\Index.cshtml"
                               Write(Model.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td align=\"right\">姓名:</td>\r\n                    <td>");
#nullable restore
#line 75 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\Index.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td align=\"right\">性别:</td>\r\n                    <td>");
#nullable restore
#line 79 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\Index.cshtml"
                   Write(Model.Sex);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td align=\"right\">寝室号:</td>\r\n                    <td>");
#nullable restore
#line 83 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\Index.cshtml"
                   Write(Model.DormitoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td align=\"right\">出生日期:</td>\r\n                    <td>");
#nullable restore
#line 87 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\Index.cshtml"
                   Write(Model.Birth);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td align=\"right\">电话:</td>\r\n                    <td>");
#nullable restore
#line 91 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\Index.cshtml"
                   Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td align=\"right\">学院:</td>\r\n                    <td>");
#nullable restore
#line 95 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\Index.cshtml"
                   Write(Model.DepartmentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td align=\"right\">备注:</td>\r\n                    <td>");
#nullable restore
#line 99 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\Index.cshtml"
                   Write(Model.Remark);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudentDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591
