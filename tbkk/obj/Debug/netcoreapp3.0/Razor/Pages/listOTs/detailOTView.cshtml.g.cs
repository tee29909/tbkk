#pragma checksum "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a62007b3ec630c78f489a4ad315acb23ee87977"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(tbkk.Pages.listOTs.Pages_listOTs_detailOTView), @"mvc.1.0.razor-page", @"/Pages/listOTs/detailOTView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a62007b3ec630c78f489a4ad315acb23ee87977", @"/Pages/listOTs/detailOTView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1001f92a60c1a37f53eadf389bf666c1fdc42288", @"/Pages/_ViewImports.cshtml")]
    public class Pages_listOTs_detailOTView : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./../listOTs/listOT", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
  
    ViewData["Title"] = "detailOTView";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"




<div id=""content-wrapper"">
    <div name=""55555"" class=""card-layout"">



        <h1>Detail OT</h1>
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item active"">Overtime</li>
            <li class=""breadcrumb-item active"">List OT</li>
            <li class=""breadcrumb-item active"">Detail OT</li>
        </ol>

        <div>
            <h4>

                <dd class=""col-sm-10"">
");
#nullable restore
#line 28 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                      
                        DateTime date = Model.DetailOT.OT.TimeStart;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 32 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
               Write(date.ToString("dddd, dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


                </dd>
            </h4>
            <hr />

            <div class=""card "" style=""margin-top:1%"">
                <div class=""card-header"">
                    Detail
                </div>

                <div class=""card-body"">

                    <dl class=""row "">



                        <dt class=""col-sm-6 text-right"">
                            ");
#nullable restore
#line 51 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayNameFor(model => model.DetailOT.TimeStart));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-6\">\r\n                            ");
#nullable restore
#line 54 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayFor(model => model.DetailOT.TimeStart));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n\r\n                        <dt class=\"col-sm-6 text-right\">\r\n                            ");
#nullable restore
#line 58 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayNameFor(model => model.DetailOT.TimeEnd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-6\">\r\n                            ");
#nullable restore
#line 61 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayFor(model => model.DetailOT.TimeEnd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n\r\n\r\n\r\n                        <dt class=\"col-sm-6 text-right\">\r\n                            ");
#nullable restore
#line 67 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayNameFor(model => model.DetailOT.Hour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-6\">\r\n                            ");
#nullable restore
#line 70 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayFor(model => model.DetailOT.Hour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n\r\n                        <dt class=\"col-sm-6 text-right\">\r\n                            ");
#nullable restore
#line 74 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayNameFor(model => model.DetailOT.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-6\">\r\n                            ");
#nullable restore
#line 77 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayFor(model => model.DetailOT.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n\r\n                        <dt class=\"col-sm-6 text-right\">\r\n                            ");
#nullable restore
#line 81 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayNameFor(model => model.DetailOT.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-6\">\r\n                            ");
#nullable restore
#line 84 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayFor(model => model.DetailOT.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n\r\n\r\n                        <dt class=\"col-sm-6 text-right\">\r\n                            ");
#nullable restore
#line 89 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayNameFor(model => model.DetailOT.Part));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-6\">\r\n                            ");
#nullable restore
#line 92 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayFor(model => model.DetailOT.Part.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n\r\n\r\n                        <dt class=\"col-sm-6 text-right\">\r\n                            ");
#nullable restore
#line 97 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayNameFor(model => model.DetailOT.FoodSet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-6\">\r\n                            ");
#nullable restore
#line 100 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayFor(model => model.DetailOT.FoodSet.NameSet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n\r\n                        <dt class=\"col-sm-6 text-right\">\r\n                            ");
#nullable restore
#line 104 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayNameFor(model => model.DetailOT.Employee));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-6\">\r\n                            ");
#nullable restore
#line 107 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayFor(model => model.DetailOT.Employee.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 108 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                       Write(Html.DisplayFor(model => model.DetailOT.Employee.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n\r\n\r\n\r\n                    </dl>\r\n\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a62007b3ec630c78f489a4ad315acb23ee8797711376", async() => {
                WriteLiteral("Edit");
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
#line 120 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                                   WriteLiteral(Model.DetailOT.DetailOTID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a62007b3ec630c78f489a4ad315acb23ee8797713524", async() => {
                WriteLiteral("Back to List");
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
#line 121 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                                                WriteLiteral(Model.Employee.EmployeeID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n\r\n\r\n\r\n    </div>\r\n    <!-- /.container-fluid -->\r\n   \r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        var nav = document.getElementById(\"Management\");\r\n        var nav2 = document.getElementById(\"Management OT\");\r\n");
#nullable restore
#line 137 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
           if (Model.Employee.Position.PositionName.Equals("Manager") || Model.Employee.Position.PositionName.Equals("admin"))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                WriteLiteral("nav.style.display = \"block\";\r\n");
#nullable restore
#line 140 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
            }
            if (Model.Employee.Department.DepartmentName.Equals("Human Resource") || Model.Employee.Position.PositionName.Equals("admin"))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                WriteLiteral("nav2.style.display = \"block\";\r\n");
#nullable restore
#line 144 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
            }
        

#line default
#line hidden
#nullable disable
                WriteLiteral("         var name = document.getElementById(\"nav_name\").innerHTML = \"Name: ");
#nullable restore
#line 146 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                                                                      Write(Model.Employee.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 146 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                                                                                                Write(Model.Employee.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Position: ");
#nullable restore
#line 146 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                                                                                                                                   Write(Model.Employee.Position.PositionName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n        var img = document.getElementById(\"myImg\").src = \"/Upload/");
#nullable restore
#line 147 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
                                                             Write(Model.Employee.Image);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n    </script>\r\n");
#nullable restore
#line 149 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\detailOTView.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<tbkk.Pages.listOTs.detailOTViewModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<tbkk.Pages.listOTs.detailOTViewModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<tbkk.Pages.listOTs.detailOTViewModel>)PageContext?.ViewData;
        public tbkk.Pages.listOTs.detailOTViewModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
