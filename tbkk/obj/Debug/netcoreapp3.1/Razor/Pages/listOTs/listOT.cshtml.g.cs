#pragma checksum "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "041a4e7e7b6419dbbdc123ff4e3d859fb48347c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(tbkk.Pages.listOTs.Pages_listOTs_listOT), @"mvc.1.0.razor-page", @"/Pages/listOTs/listOT.cshtml")]
namespace tbkk.Pages.listOTs
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
#line 1 "D:\สำรอง\tbkk\tbkk\Pages\_ViewImports.cshtml"
using tbkk;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"041a4e7e7b6419dbbdc123ff4e3d859fb48347c5", @"/Pages/listOTs/listOT.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1001f92a60c1a37f53eadf389bf666c1fdc42288", @"/Pages/_ViewImports.cshtml")]
    public class Pages_listOTs_listOT : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./../listOTs/addOT", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./../listOTs/detailOTView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
  
    ViewData["Title"] = "listOT";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div id=""content-wrapper"">
    <div name=""55555"" class=""card-layout"">


        <h1>List OT</h1>
        <div class=""container-fluid"">
            <ol class=""breadcrumb"">
                <li class=""breadcrumb-item active"">Overtime</li>
                <li class=""breadcrumb-item active"">List OT</li>

            </ol>


            <div class=""card mb-3"">
                <div class=""card-header"">
                    <i class=""fas fa-table""></i>
                    OT Table
                </div>

                <div class=""card-body"">
                    <div class=""table-responsive"">
                        <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                            <thead>
                                <tr>
                                    <th>
                                        Date
                                    </th>
                                    <th>
                                        ");
#nullable restore
#line 35 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                   Write(Html.DisplayNameFor(model => model.OT[0].TimeStart));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </th>\r\n                                    <th>\r\n                                        ");
#nullable restore
#line 38 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                   Write(Html.DisplayNameFor(model => model.OT[0].TimeEnd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </th>\r\n                                    <th>\r\n                                        ");
#nullable restore
#line 41 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                   Write(Html.DisplayNameFor(model => model.OT[0].TypeOT));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </th>\r\n                                    <th>\r\n                                        ");
#nullable restore
#line 44 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                   Write(Html.DisplayNameFor(model => model.OT[0].TypStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </th>
                                    <th>
                                        Action
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 52 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                 foreach (var item in Model.OT)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n\r\n\r\n");
#nullable restore
#line 58 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                              
                                                DateTime date = item.date;
                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 62 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                       Write(date.ToString("dddd, dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 68 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.TimeStart));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 71 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.TimeEnd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 74 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.TypeOT));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 77 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.TypStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n\r\n\r\n");
#nullable restore
#line 82 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                              




                                                int check = 0;
                                                int IDdetail = 0;
                                                foreach (var i in Model.DetailOT)
                                                {
                                                    if (i.Employee_EmpID == Model.Employee.EmployeeID && i.OT_OTID == item.OTID)
                                                    {
                                                        check = 1;
                                                        IDdetail = i.DetailOTID;
                                                        break;
                                                    }

                                                }

                                                if (check == 0)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "041a4e7e7b6419dbbdc123ff4e3d859fb48347c510245", async() => {
                WriteLiteral("Register");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 102 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                                                                       WriteLiteral(Model.Employee.EmployeeID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 102 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                                                                                                                  WriteLiteral(item.OTID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Did"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Did", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Did"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 103 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"

                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "041a4e7e7b6419dbbdc123ff4e3d859fb48347c513560", async() => {
                WriteLiteral("Detail");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 107 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                                                                              WriteLiteral(IDdetail);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 107 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                                                                                                        WriteLiteral(Model.Employee.EmployeeID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Did"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Did", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Did"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 108 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                                }











                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 124 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n\r\n\r\n    </div>\r\n    <!-- /.container-fluid -->\r\n   \r\n   \r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        var nav = document.getElementById(\"Management\");\r\n        var nav2 = document.getElementById(\"Management OT\");\r\n");
#nullable restore
#line 146 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
           if (Model.Employee.Position.PositionName.Equals("Manager") || Model.Employee.Position.PositionName.Equals("admin"))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                WriteLiteral("nav.style.display = \"block\";\r\n");
#nullable restore
#line 149 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
            }
            if (Model.Employee.Department.DepartmentName.Equals("Human Resource") || Model.Employee.Position.PositionName.Equals("admin"))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                WriteLiteral("nav2.style.display = \"block\";\r\n");
#nullable restore
#line 153 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
            }
        

#line default
#line hidden
#nullable disable
                WriteLiteral("         var name = document.getElementById(\"nav_name\").innerHTML = \"Name: ");
#nullable restore
#line 155 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                                                      Write(Model.Employee.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 155 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                                                                                Write(Model.Employee.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Position: ");
#nullable restore
#line 155 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                                                                                                                   Write(Model.Employee.Position.PositionName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n        var img = document.getElementById(\"myImg\").src = \"/Upload/");
#nullable restore
#line 156 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
                                                             Write(Model.Employee.Image);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n    </script>\r\n");
#nullable restore
#line 158 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\listOT.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<tbkk.Pages.listOTs.listOTModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<tbkk.Pages.listOTs.listOTModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<tbkk.Pages.listOTs.listOTModel>)PageContext?.ViewData;
        public tbkk.Pages.listOTs.listOTModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
