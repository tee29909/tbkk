#pragma checksum "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11809aa421d04027a553ff94ef1720202d4ae8d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(tbkk.Pages.listOTs.Pages_listOTs_OTcar), @"mvc.1.0.razor-page", @"/Pages/listOTs/OTcar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11809aa421d04027a553ff94ef1720202d4ae8d0", @"/Pages/listOTs/OTcar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1001f92a60c1a37f53eadf389bf666c1fdc42288", @"/Pages/_ViewImports.cshtml")]
    public class Pages_listOTs_OTcar : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "month", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
  
    ViewData["Title"] = "OTcar";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""content-wrapper"">
    <div name=""55555"" class=""card-layout"">


        <h1>Report OT</h1>

        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item active"">Management OT</li>
            <li class=""breadcrumb-item active"">Report OT</li>

        </ol>
        <div class=""row"">
            <div class=""col-3"">


                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11809aa421d04027a553ff94ef1720202d4ae8d04682", async() => {
                WriteLiteral("\r\n\r\n                    <div class=\"form-group\">\r\n                        <h6>Month :&nbsp;</h6>\r\n\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "11809aa421d04027a553ff94ef1720202d4ae8d05072", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 28 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.search);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("&nbsp;\r\n                        <input class=\"btn btn-primary\" type=\"submit\" value=\"Search\">\r\n\r\n\r\n                    </div>\r\n\r\n\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                <button class=\"btn btn-success\" onclick=\"myFunction()\">Print</button>\r\n");
            WriteLiteral(@"            </div>
           

        </div>
        



            <br />








            <div class=""row state-overview"">
                <div class=""col-lg-3 col-sm-6"">
                    <section class=""card"" style=""background-color:azure;"">
                        <div class=""symbol terques"">
                            <i class=""fa fa-clipboard-list""></i>
                        </div>
                        <div class=""value"">
                            <h2 class=""count"">");
#nullable restore
#line 65 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
                                         Write(Model.detailList.OT);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                            <p style=""color:black"">Times</p>
                        </div>
                    </section>
                </div>
                <div class=""col-lg-3 col-sm-6"">
                    <section class=""card"" style=""background-color:#FFBAAB;"">
                        <div class=""symbol red"">
                            <i class=""fa fa-shuttle-van""></i>
                        </div>
                        <div class=""value"">
                            <h2 class="" count2"">");
#nullable restore
#line 76 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
                                           Write(Model.detailList.car);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                            <p style=""color:black"">Cars</p>
                        </div>
                    </section>
                </div>
                <div class=""col-lg-3 col-sm-6"">
                    <section class=""card"" style=""background-color:#FFF4AB;"">
                        <div class=""symbol yellow"">
                            <i class=""fa fa-utensils""></i>
                        </div>
                        <div class=""value"">
                            <h2 class=""count3"">");
#nullable restore
#line 87 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
                                          Write(Model.detailList.food);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                            <p style=""color:black"">Order Food</p>
                        </div>
                    </section>
                </div>
                <div class=""col-lg-3 col-sm-6"">
                    <section class=""card"" style=""background-color:#ABF7FF;"">
                        <div class=""symbol blue"">
                            <i class=""fa fa-dollar-sign""></i>
                        </div>
                        <div class=""value"">
                            <h2 class="" count4"">");
#nullable restore
#line 98 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
                                           Write(Model.detailList.total.ToString("c2"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                            <p style=""color:black"">Total Cost</p>
                        </div>
                    </section>
                </div>
            </div>



            <br />



            <div class=""row"">
                <div class=""col-md-6 charts-grids widget"">
                    <h4 class=""title"">Bar Chart OT Work</h4>
                    <div style="" height: 300px;"" id=""chart1""></div>

                </div>


                <div class=""col-md-6 charts-grids widget states-mdl"">
                    <h4 class=""title"">Line Chart Example</h4>
                    <div style="" height: 300px;"" id=""chart2""></div>
                </div>

            </div>
            <div class=""row"">
                <div class=""col-md-6 charts-grids widget"">
                    <h4 class=""title"">Pie Chart Example</h4>
                    <div style="" height: 300px;"" id=""chart3""></div>

                </div>
                <div class=""col-md-6 charts-grids widget"">
 ");
            WriteLiteral(@"                   <h4 class=""title"">Cost OT</h4>
                    <div style="" height: 300px;"" id=""chart4""></div>

                </div>
            </div>











            <!-- Area Chart Example-->
            <div class=""card mb-3"">
                <div class=""card-header"">
                    <i class=""fas fa-chart-area""></i>
                    Area Chart Example
                </div>
                <div class=""card-body"">
                    <div style="" height: 300px;"" id=""chart5""></div>

                </div>
                <div class=""card-footer small text-muted"">Updated yesterday at 11:59 PM</div>
            </div>



























        </div>
        <!-- /.container-fluid -->

    </div>

<script>
    function myFunction() {
        window.print();
    }
</script>




");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 202 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <script>\r\n\r\n\r\n       \r\n\r\n\r\n\r\n\r\n");
                WriteLiteral(@"













    var chart1 = new CanvasJS.Chart(""chart1"", {
	animationEnabled: true,
	theme: ""light2"", // ""light1"", ""light2"", ""dark1"", ""dark2""
	title:{
		text: ""OT Work""
	},
	axisY: {
		//title: ""Reserves(MMbbl)""
	},
	data: [{
		type: ""column"",
		showInLegend: true,
		legendMarkerColor: ""grey"",
		//legendText: ""MMbbl = one million barrels"",
		dataPoints: ");
#nullable restore
#line 287 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
               Write(Html.Raw(Json.Serialize(Model.chart1)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
	}]
});


         chart1.render();





     var chart2 = new CanvasJS.Chart(""chart2"", {
	animationEnabled: true,
	title: {
		text: ""Desktop Search Engine Market Share - 2016""
	},
	data: [{
		type: ""pie"",
		startAngle: 240,
		yValueFormatString: ""##0.00'%'"",
		indexLabel: ""{label} {y}"",
		dataPoints: [
			{y: 79.45, label: ""Google""},
			{y: 7.31, label: ""Bing""},
			{y: 7.06, label: ""Baidu""},
			{y: 4.91, label: ""Yahoo""},
			{y: 1.26, label: ""Others""}
		]
	}]
});



        chart2.render();






























		var chart3 = new CanvasJS.Chart(""chart3"", {
	animationEnabled: true,

	title:{
		text:""Fortune 500 Companies by Country""
	},
	axisX:{
		interval: 1
	},
	axisY2:{
		interlacedColor: ""rgba(1,77,101,.2)"",
		gridColor: ""rgba(1,77,101,.1)"",
		title: ""Number of Companies""
	},
	data: [{
		type: ""bar"",
		name: ""companies"",
		axisYType: ""secondary"",
		color: ""#014D65"",
		dataPoints: ");
#nullable restore
#line 370 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
               Write(Html.Raw(Json.Serialize(Model.chart3)));

#line default
#line hidden
#nullable disable
                WriteLiteral(",\r\n\t}]\r\n});\r\nchart3.render();\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\t\tvar chart4 = new CanvasJS.Chart(\"chart4\", {\r\n\tanimationEnabled: true,\r\n\ttitle:{\r\n\t\ttext: \"Cost OT(");
#nullable restore
#line 397 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
                  Write(Model.Total);

#line default
#line hidden
#nullable disable
                WriteLiteral(")\",\r\n\t\thorizontalAlign: \"left\"\r\n\t},\r\n\tdata: [{\r\n\t\ttype: \"doughnut\",\r\n\t\tstartAngle: 60,\r\n\t\t//innerRadius: 60,\r\n\t\tindexLabelFontSize: 17,\r\n\t\tindexLabel: \"{label} - #percent%\",\r\n\t\ttoolTipContent: \"<b>{label}:</b> {y} (#percent%)\",\r\n\t\tdataPoints: ");
#nullable restore
#line 407 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
               Write(Html.Raw(Json.Serialize(Model.chart4)));

#line default
#line hidden
#nullable disable
                WriteLiteral(",\r\n\t}]\r\n});\r\nchart4.render();\r\n\r\n\r\n\r\n\r\n\r\nvar chart5 = new CanvasJS.Chart(\"chart5\", {\r\n\ttheme:\"light2\",\r\n\tanimationEnabled: true,\r\n\ttitle:{\r\n\t\ttext: \"Total Cost In Year (");
#nullable restore
#line 420 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
                              Write(Model.chart5.Total.Sum(e => e.y).ToString("c2"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@")""
	},
	axisY :{
		includeZero: false,
		//title: ""Number of Viewers"",
		//suffix: ""mn""
	},
	toolTip: {
		shared: ""true""
	},
	legend:{
		cursor:""pointer"",
		itemclick : toggleDataSeries
	},
	data: [{
		type: ""spline"",
		showInLegend: true,
		yValueFormatString: ""#,##,###"",
		name: ""Total Cost"",
		dataPoints: ");
#nullable restore
#line 439 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
               Write(Html.Raw(Json.Serialize(Model.chart5.Total)));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\t},\r\n\t{\r\n\t\ttype: \"spline\",\r\n\t\tshowInLegend: true,\r\n\t\tyValueFormatString: \"#,##,###\",\r\n\t\tname: \"Cost Car\",\r\n\t\tdataPoints:  ");
#nullable restore
#line 446 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
                Write(Html.Raw(Json.Serialize(Model.chart5.CostCar)));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\t},\r\n\t{\r\n\t\ttype: \"spline\",\r\n\t\tshowInLegend: true,\r\n\t\tyValueFormatString: \"#,##,###\",\r\n\t\tname: \"Cost Food\",\r\n\t\tdataPoints:");
#nullable restore
#line 453 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
              Write(Html.Raw(Json.Serialize(Model.chart5.CostFood)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
	}]
        });



chart5.render();


        function toggleDataSeries(e) {
	if (typeof(e.dataSeries.visible) === ""undefined"" || e.dataSeries.visible ){
		e.dataSeries.visible = false;
	} else {
		e.dataSeries.visible = true;
	}

        }


    </script>

    <script>
        var nav = document.getElementById(""Management"");
        var nav2 = document.getElementById(""Management OT"");
");
#nullable restore
#line 477 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
           if (Model.Employee.Position.PositionName.Equals("Manager") || Model.Employee.Position.PositionName.Equals("admin"))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                WriteLiteral("nav.style.display = \"block\";\r\n");
#nullable restore
#line 480 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
            }
            if (Model.Employee.Department.DepartmentName.Equals("Human Resource") || Model.Employee.Position.PositionName.Equals("admin"))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                WriteLiteral("nav2.style.display = \"block\";\r\n");
#nullable restore
#line 484 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
            }
        

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        var name = document.getElementById(\"nav_name\").innerHTML = \"Name: ");
#nullable restore
#line 487 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
                                                                     Write(Model.Employee.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 487 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
                                                                                               Write(Model.Employee.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Position: ");
#nullable restore
#line 487 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
                                                                                                                                  Write(Model.Employee.Position.PositionName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n        var img = document.getElementById(\"myImg\").src = \"/Upload/");
#nullable restore
#line 488 "D:\สำรอง\tbkk\tbkk\Pages\listOTs\OTcar.cshtml"
                                                             Write(Model.Employee.Image);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n    </script>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<tbkk.Pages.listOTs.OTcarModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<tbkk.Pages.listOTs.OTcarModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<tbkk.Pages.listOTs.OTcarModel>)PageContext?.ViewData;
        public tbkk.Pages.listOTs.OTcarModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591