#pragma checksum "C:\Users\Admin\Desktop\PRN_SWP\PRN_GroceryStoreManagement\PRN_GroceryStoreManagement\Views\Shared\FeedbackList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bef66688c1fc406cf3ccfe2620f83b7b7f316baa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_FeedbackList), @"mvc.1.0.view", @"/Views/Shared/FeedbackList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bef66688c1fc406cf3ccfe2620f83b7b7f316baa", @"/Views/Shared/FeedbackList.cshtml")]
    public class Views_Shared_FeedbackList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("page-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onload", new global::Microsoft.AspNetCore.Html.HtmlString("GetUnSeenFeedbackList()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bef66688c1fc406cf3ccfe2620f83b7b7f316baa3510", async() => {
                WriteLiteral("\r\n\r\n        <meta charset=\"utf-8\">\r\n        <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n        <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 274, "\"", 284, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n        <meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 315, "\"", 325, 0);
                EndWriteAttribute();
                WriteLiteral(@">

        <title>Phản hồi từ thu ngân</title>

        <!-- Custom fonts for this template-->
        <link href=""/storeowner/vendor/fontawesome-free/css/all.min.css"" rel=""stylesheet"" type=""text/css"">
        <link
            href=""https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i""
            rel=""stylesheet"">

        <!-- Custom styles for this template-->
        <link href=""/storeowner/css/gsm-storeowner-stylesheet1.css"" rel=""stylesheet"">
        <!-- Link jquery for sidebar -->
        <script src=""//code.jquery.com/jquery.min.js""></script>
        <link rel=""apple-touch-icon"" sizes=""57x57"" href=""/storeowner/favicon/apple-icon-57x57.png"">
        <link rel=""apple-touch-icon"" sizes=""60x60"" href=""/storeowner/favicon/apple-icon-60x60.png"">
        <link rel=""apple-touch-icon"" sizes=""72x72"" href=""/storeowner/favicon/apple-icon-72x72.png"">
        <link rel=""apple-touch-icon"" sizes=""76x76"" href=""/storeowner/favicon/apple-icon-76x7");
                WriteLiteral(@"6.png"">
        <link rel=""apple-touch-icon"" sizes=""114x114"" href=""/storeowner/favicon/apple-icon-114x114.png"">
        <link rel=""apple-touch-icon"" sizes=""120x120"" href=""/storeowner/favicon/apple-icon-120x120.png"">
        <link rel=""apple-touch-icon"" sizes=""144x144"" href=""/storeowner/favicon/apple-icon-144x144.png"">
        <link rel=""apple-touch-icon"" sizes=""152x152"" href=""/storeowner/favicon/apple-icon-152x152.png"">
        <link rel=""apple-touch-icon"" sizes=""180x180"" href=""/storeowner/favicon/apple-icon-180x180.png"">
        <link rel=""icon"" type=""image/png"" sizes=""192x192""  href=""/storeowner/favicon/android-icon-192x192.png"">
        <link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""/storeowner/favicon/favicon-32x32.png"">
        <link rel=""icon"" type=""image/png"" sizes=""96x96"" href=""/storeowner/favicon/favicon-96x96.png"">
        <link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""/storeowner/favicon/favicon-16x16.png"">
        <link rel=""manifest"" href=""/storeowner/favicon/manifest.json");
                WriteLiteral("\">\r\n        <meta name=\"msapplication-TileColor\" content=\"#ffffff\">\r\n        <meta name=\"msapplication-TileImage\" content=\"/ms-icon-144x144.png\">\r\n        <meta name=\"theme-color\" content=\"#ffffff\">\r\n    ");
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
            WriteLiteral("\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bef66688c1fc406cf3ccfe2620f83b7b7f316baa7525", async() => {
                WriteLiteral(@"  

        <!-- Page Wrapper -->
        <div id=""wrapper"">

            <!-- Sidebar -->
            <div id=""sidebar-placeholder"">
            </div>
            <script>
                $.get(""Sidebar"", function (data) {
                    $(""#sidebar-placeholder"").replaceWith(data);
                });
            </script>
            <!-- End of Sidebar -->

            <!-- Content Wrapper -->
            <div id=""content-wrapper"">

                <!-- Main Content -->
                <div id=""content"">

                    <!-- Begin Page Content -->
                    <div class=""container-fluid"">

                        <!-- Page Heading -->
                        <div class=""d-sm-flex align-items-center justify-content-between my-3"">
                            <h1 class=""mb-0"" id=""header-page"">PHẢN HỒI</h1>
                        </div>

                        <!-- Divider -->
                        <hr class=""sidebar-divider mb-2"">              

         ");
                WriteLiteral(@"               <div class=""row"">
                            <div class=""card shadow mb-2 col-12"">
                                <div class=""card-header py-2 row justify-content-between"">
                                    <div class=""d-inline-block mt-2 ml-3"">
                                        <h4 class=""m-0 font-weight-bold text-primary d-inline-block"">PHẢN HỒI TỪ THU NGÂN</h4>
                                        <h4 class=""m-0 font-weight-bold text-primary d-inline-block"" id=""seen-feedback-number""></h4>
                                    </div>
                                    <div class=""d-flex row"">
                                        <div class=""input-group-text d-flex mr-2"">
                                            <input id=""seen-feedback-display"" type=""checkbox"" onchange=""displayFeedback(this)"">
                                        </div>
                                        <label class=""mt-2 mr-5"" for=""seen-feedback-display"" style=""color: black;"">
         ");
                WriteLiteral(@"                                   Hiển thị tất cả phản hồi
                                        </label>
                                    </div>
                                </div>

                                <div class=""card-body"">
                                    <div class=""text-center"">
                                        <table class=""table table-striped table-border-custom"" id=""feedbackTable"">
                                            <thead>
                                                <tr>
                                                    <th scope=""col"" class=""table-heading"" style=""width:5%;""></th>
                                                    <th scope=""col"" class=""table-heading"" style=""width:13%;"">Thời gian</th>
                                                    <th scope=""col"" class=""table-heading"" style=""width:52%;"">Nội dung</th>
                                                    <th scope=""col"" class=""table-heading"" style=""width:20%;"">Tên thu ngâ");
                WriteLiteral(@"n</th>
                                                    <th scope=""col"" class=""table-heading"" style=""width:10%;""></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- /.container-fluid -->

                </div>
                <!-- End of Main Content -->

            </div>
            <!-- End of Content Wrapper -->

        </div>
        <!-- End of Page Wrapper -->

        <!-- Scroll to Top Button-->
        <a class=""scroll-to-top rounded"" href=""#page-top"">
            <i class=""fas fa-angle-up""></i>
        </a>
        
        <!-- Bootstrap core JavaScript");
                WriteLiteral(@"-->
        <script src=""/storeowner/vendor/jquery/jquery.min.js""></script>
        <script src=""/storeowner/vendor/bootstrap/js/bootstrap.bundle.min.js""></script>

        <!-- Core plugin JavaScript-->
        <script src=""/storeowner/vendor/jquery-easing/jquery.easing.min.js""></script>

        <!-- Custom scripts for all pages-->
        <script src=""/storeowner/js/gsm-storeowner-1.js""></script>
        <script src=""/storeowner/js/gsm-storeowner-2.js""></script>
        <script src=""/storeowner/js/feedback-storeowner.js""></script>

    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
