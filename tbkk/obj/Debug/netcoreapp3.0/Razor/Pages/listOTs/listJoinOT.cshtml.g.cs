#pragma checksum "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a846725fc26373aeeef0f7de3a1d179f93be0c04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(tbkk.Pages.listOTs.Pages_listOTs_listJoinOT), @"mvc.1.0.razor-page", @"/Pages/listOTs/listJoinOT.cshtml")]
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
#line 1 "D:\tbkk\tbkk\tbkk\Pages\_ViewImports.cshtml"
using tbkk;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{searchString?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a846725fc26373aeeef0f7de3a1d179f93be0c04", @"/Pages/listOTs/listJoinOT.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1001f92a60c1a37f53eadf389bf666c1fdc42288", @"/Pages/_ViewImports.cshtml")]
    public class Pages_listOTs_listJoinOT : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded mx-auto d-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
  
    ViewData["Title"] = "listJoinOT";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""content-wrapper"">
    <div name=""55555"" class=""card-layout"">


        <h1>History OT</h1>
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item active"">Overtime</li>
            <li class=""breadcrumb-item active"">History OT</li>
        </ol>


        <div class=""row"">
            <div class=""col"">
                <dl class=""row"">
                    <dt class=""col-sm-6 text-right"">
                        Name:
                    </dt>
                    <dd class=""col-sm-6"">
                        ");
#nullable restore
#line 26 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                   Write(Html.DisplayFor(model => model.Employee.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 26 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                                                                        Write(Html.DisplayFor(model => model.Employee.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n\r\n\r\n                    <dt class=\"col-sm-6 text-right\">\r\n                        ");
#nullable restore
#line 32 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                   Write(Html.DisplayNameFor(model => model.Employee.Employee_CompanyID));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n                    </dt>\r\n                    <dd class=\"col-sm-6 \">\r\n                        ");
#nullable restore
#line 35 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                   Write(Html.DisplayFor(model => model.Employee.Company.CompanyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-6 text-right\">\r\n                        ");
#nullable restore
#line 39 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                   Write(Html.DisplayNameFor(model => model.Employee.Employee_DepartmentID));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n                    </dt>\r\n                    <dd class=\"col-sm-6\">\r\n                        ");
#nullable restore
#line 42 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                   Write(Html.DisplayFor(model => model.Employee.Department.DepartmentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-6 text-right\">\r\n                        ");
#nullable restore
#line 46 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                   Write(Html.DisplayNameFor(model => model.Employee.Employee_PositionID));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n                    </dt>\r\n                    <dd class=\"col-sm-6\">\r\n                        ");
#nullable restore
#line 49 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                   Write(Html.DisplayFor(model => model.Employee.Position.PositionName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n\r\n                    <dt class=\"col-sm-6 text-right\">\r\n                        Hour OT:\r\n                    </dt>\r\n                    <dd class=\"col-sm-6\">\r\n                        ");
#nullable restore
#line 57 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                   Write(Html.DisplayFor(model => model.countHourOT));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Hour\r\n                    </dd>\r\n                </dl>\r\n\r\n\r\n            </div>\r\n\r\n            <div class=\"col\">\r\n                <div>\r\n\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a846725fc26373aeeef0f7de3a1d179f93be0c047537", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2213, "~/Upload/", 2213, 9, true);
#nullable restore
#line 67 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
AddHtmlAttributeValue("", 2222, Model.Employee.Image, 2222, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 67 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
AddHtmlAttributeValue("", 2282, Model.Employee.Image, 2282, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                </div>


            </div>
        </div>


        <br />
        <br />











        <div class=""card mb-3"">
            <div class=""card-header"">
                <i class=""fas fa-table""></i>
                History Table
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
#line 104 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                               Write(Html.DisplayNameFor(model => model.DetailOT[0].Hour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n\r\n                                <th>\r\n                                    ");
#nullable restore
#line 108 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                               Write(Html.DisplayNameFor(model => model.DetailOT[0].Part));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 111 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                               Write(Html.DisplayNameFor(model => model.DetailOT[0].FoodSet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 116 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                             foreach (var item in Model.DetailOT)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n\r\n");
#nullable restore
#line 121 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                                          
                                            DateTime date = item.TimeStart;
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        ");
#nullable restore
#line 125 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                                   Write(date.ToString("dddd, dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 129 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Hour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n\r\n\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 134 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Part.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 137 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.FoodSet.NameSet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n\r\n                                </tr>\r\n");
#nullable restore
#line 141 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>

                </div>
            </div>
        </div>






        <!-- /.container-fluid
         <td>
                            <a asp-page=""./../listOTs/EditJoinOT"" asp-route-id=""item.DetailOTID"">Edit</a> |

                            <a asp-page=""./Delete"" asp-route-id=""item.DetailOTID"">Delete</a>
                        </td>
        -->
       
    </div>
    <!-- /.content-wrapper -->
</div>




");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        var nav = document.getElementById(\"Management\");\r\n        var nav2 = document.getElementById(\"Management OT\");\r\n");
#nullable restore
#line 173 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
           if (Model.Employee.Position.PositionName.Equals("Manager") || Model.Employee.Position.PositionName.Equals("admin"))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                WriteLiteral("nav.style.display = \"block\";\r\n");
#nullable restore
#line 176 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
            }
            if (Model.Employee.Department.DepartmentName.Equals("Human Resource") || Model.Employee.Position.PositionName.Equals("admin"))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                WriteLiteral("nav2.style.display = \"block\";\r\n");
#nullable restore
#line 180 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
            }
        

#line default
#line hidden
#nullable disable
                WriteLiteral("         var name = document.getElementById(\"nav_name\").innerHTML = \"Name: ");
#nullable restore
#line 182 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                                                                      Write(Model.Employee.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 182 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                                                                                                Write(Model.Employee.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Position: ");
#nullable restore
#line 182 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                                                                                                                                   Write(Model.Employee.Position.PositionName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n        var img = document.getElementById(\"myImg\").src = \"/Upload/");
#nullable restore
#line 183 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
                                                             Write(Model.Employee.Image);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n    </script>\r\n");
#nullable restore
#line 185 "D:\tbkk\tbkk\tbkk\Pages\listOTs\listJoinOT.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<tbkk.Pages.listOTs.listJoinOTModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<tbkk.Pages.listOTs.listJoinOTModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<tbkk.Pages.listOTs.listJoinOTModel>)PageContext?.ViewData;
        public tbkk.Pages.listOTs.listJoinOTModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
