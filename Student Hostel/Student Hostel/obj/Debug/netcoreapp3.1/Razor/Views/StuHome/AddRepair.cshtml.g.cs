#pragma checksum "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\AddRepair.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "487d51c4fc622e259135d51d47b12b6c9d4784d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StuHome_AddRepair), @"mvc.1.0.view", @"/Views/StuHome/AddRepair.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"487d51c4fc622e259135d51d47b12b6c9d4784d1", @"/Views/StuHome/AddRepair.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6238afcd82c2026c55d674019901d3d1504ecfee", @"/_ViewImports.cshtml")]
    public class Views_StuHome_AddRepair : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Dormitory>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("AddRepair"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\AddRepair.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <!DOCTYPE html>\r\n    <html>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "487d51c4fc622e259135d51d47b12b6c9d4784d14943", async() => {
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
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "487d51c4fc622e259135d51d47b12b6c9d4784d16441", async() => {
                WriteLiteral(@"
        <nav class=""navbar navbar-expand-sm bg-primary navbar-dark"">
            <ul class=""navbar-nav"">
                <li class=""nav-item"">
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
                    <a class=");
                WriteLiteral(@"""nav-link dropdown-toggle"" data-toggle=""dropdown"" href=""#"">请假</a>
                    <div class=""dropdown-menu"">
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
            WriteLiteral("\r\n</html>\r\n<div class=\"container\">\r\n    <h2>报修登记</h2>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "487d51c4fc622e259135d51d47b12b6c9d4784d19528", async() => {
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <label for=\"DormitoryId\">报修宿舍:</label>\r\n            <select class=\"select\" name=\"DormitoryId\">\r\n");
#nullable restore
#line 61 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\AddRepair.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "487d51c4fc622e259135d51d47b12b6c9d4784d110239", async() => {
#nullable restore
#line 63 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\AddRepair.cshtml"
                                        Write(item.DorName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\AddRepair.cshtml"
                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 64 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\AddRepair.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </select>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label for=\"time\">报修时间:</label>\r\n            <input type=\"text\" class=\"form-control\" name=\"time\"");
                BeginWriteAttribute("value", " value=\"", 3182, "\"", 3190, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
        </div>
        <div class=""form-group"">
            <label for=""Remark"">报修项目：</label>
            <input type=""text"" class=""form-control"" name=""Remark"">
        </div>
        <button type=""submit"" class=""btn btn-primary"">确认</button>
        <label class=""col-form-label"">");
#nullable restore
#line 76 "I:\202009070157-张文静-学生宿舍管理系统\1.源代码\Student Hostel\Student Hostel\Views\StuHome\AddRepair.cshtml"
                                 Write(ViewBag.Msg);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n\r\n\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Dormitory>> Html { get; private set; }
    }
}
#pragma warning restore 1591