#pragma checksum "C:\Users\quan6\OneDrive\SGK\PRN_SWP\PRN_GroceryStoreManagement\PRN_GroceryStoreManagement\Views\Shared\Staff.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ba140bc9862c18bcbc846e16f68f9a035c4c226"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Staff), @"mvc.1.0.view", @"/Views/Shared/Staff.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ba140bc9862c18bcbc846e16f68f9a035c4c226", @"/Views/Shared/Staff.cshtml")]
    public class Views_Shared_Staff : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("page-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onload", new global::Microsoft.AspNetCore.Html.HtmlString("showAccountList()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ba140bc9862c18bcbc846e16f68f9a035c4c2263470", async() => {
                WriteLiteral("\r\n        <meta charset=\"utf-8\">\r\n        <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n        <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 270, "\"", 280, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n        <meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 311, "\"", 321, 0);
                EndWriteAttribute();
                WriteLiteral(@">

        <title>Quản lí tài khoản</title>

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
        <link rel=""apple-touch-icon"" sizes=""76x76"" href=""/storeowner/favicon/apple-icon-76x76.p");
                WriteLiteral(@"ng"">
        <link rel=""apple-touch-icon"" sizes=""114x114"" href=""/storeowner/favicon/apple-icon-114x114.png"">
        <link rel=""apple-touch-icon"" sizes=""120x120"" href=""/storeowner/favicon/apple-icon-120x120.png"">
        <link rel=""apple-touch-icon"" sizes=""144x144"" href=""/storeowner/favicon/apple-icon-144x144.png"">
        <link rel=""apple-touch-icon"" sizes=""152x152"" href=""/storeowner/favicon/apple-icon-152x152.png"">
        <link rel=""apple-touch-icon"" sizes=""180x180"" href=""/storeowner/favicon/apple-icon-180x180.png"">
        <link rel=""icon"" type=""image/png"" sizes=""192x192""  href=""/storeowner/favicon/android-icon-192x192.png"">
        <link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""/storeowner/favicon/favicon-32x32.png"">
        <link rel=""icon"" type=""image/png"" sizes=""96x96"" href=""/storeowner/favicon/favicon-96x96.png"">
        <link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""/storeowner/favicon/favicon-16x16.png"">
        <link rel=""manifest"" href=""/storeowner/favicon/manifest.json"">");
                WriteLiteral("\n        <meta name=\"msapplication-TileColor\" content=\"#ffffff\">\r\n        <meta name=\"msapplication-TileImage\" content=\"/ms-icon-144x144.png\">\r\n        <meta name=\"theme-color\" content=\"#ffffff\">\r\n    ");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ba140bc9862c18bcbc846e16f68f9a035c4c2267477", async() => {
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
            <div id=""content-wrapper"" class=""d-flex flex-column"">

                <!-- Main Content -->
                <div id=""content"">

                    <!-- Begin Page Content -->
                    <div class=""container-fluid"">

                        <!-- Page Heading -->
                        <div class=""d-sm-flex align-items-center justify-content-between my-3"">
                            <h1 class=""mb-0"" id=""header-page"">QUẢN LÍ NHÂN VIÊN</h1>
                        </div>

                        <!-- Divider -->
                        <hr class=""sidebar-divider");
                WriteLiteral(@" mb-2"">

                        <!-- Content Row -->
                        <div class=""row"">

                            <!-- Look up Table -->
                            <div class=""col-xl-12"">
                                <div class=""card shadow mb-4"">
                                    <div class=""card-header py-3 d-sm-flex align-items-center justify-content-between"">
                                        <h3 class=""font-weight-bold text-primary header-center my-auto"">DANH SÁCH TÀI KHOẢN</h3>

                                        <div class=""d-sm-flex align-items-center justify-content-end"">
                                            <button class=""d-flex justify-content-center align-items-center d-sm-inline-block btn btn-lg btn-primary btn-create-account""
                                                    data-toggle=""modal"" data-target=""#add-new-modal"">
                                                <span>Tạo tài khoản &nbsp;</span>
                                        ");
                WriteLiteral(@"        <i class=""fas fa-user-plus""></i>
                                            </button>

                                            <button class=""d-flex justify-content-center align-items-center d-sm-inline-block btn btn-lg btn-warning btn-change-password""
                                                    data-toggle=""modal"" data-target=""#change-password-modal"">
                                                <span>Đổi mật khẩu &nbsp;</span>
                                                <i class=""fas fa-undo""></i>
                                            </button>
                                        </div>
                                    </div>

                                    <div class=""card-body"">

                                        <!-- Look up Table Content -->
                                        <div class=""text-center small"">
                                            <table class=""table table-striped table-border-custom"">
                          ");
                WriteLiteral(@"                      <thead>
                                                    <tr>
                                                        <th scope=""col"" class=""table-heading"" style=""width:10%;""></th>
                                                        <th scope=""col"" class=""table-heading"" style=""width:25%;"">Tên đăng nhập</th>
                                                        <th scope=""col"" class=""table-heading"" style=""width:25%;"">Họ và tên</th>
                                                        <th scope=""col"" class=""table-heading"" style=""width:20%;"">Vai trò</th>
                                                        <th scope=""col"" class=""table-heading"" style=""width:10%;""></th>
                                                        <th scope=""col"" class=""table-heading"" style=""width:10%;""></th>
                                                    </tr>
                                                </thead>
                                                <tbody id=""account-li");
                WriteLiteral(@"st-area"">
                                                </tbody>
                                            </table>
                                        </div>
                                        <!--/ End of Look up Table Content -->
                                    </div>
                                </div>

                            </div>
                            <!--/ End of Look up Table -->

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

        <!-- Modal Confirm Reset Password -->
        <div class=""modal fade modal-center-position"" id=""reset-password-mod");
                WriteLiteral(@"al"" role=""dialog"" aria-hidden=""true"">
            <div class=""modal-dialog"" role=""document"">
                <div class=""modal-content"">

                    <div class=""modal-header"">
                        <h5 class=""modal-title text-primary"">Xác nhận</h5>
                        <button class=""close"" type=""button"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">×</span>
                        </button>
                    </div>

                    <div class=""modal-body"">
                        <span class=""m-0 pt-1 ml-1"">Bạn có chắc chắn muốn đặt lại mật khẩu cho tài khoản</span>
                        <span class=""m-0 text-primary pt-1 ml-1"" id=""reset-username""></span>
                        <span class=""m-0 pt-1 ml-1"">không?</span>
                    </div>

                    <div class=""modal-footer"">
                        <button class=""btn btn-primary"" onclick=""resetAccount(document.getElementById('reset-username').innerHTML)");
                WriteLiteral(@""">Đồng ý</button>
                        <button class=""btn btn-secondary"" data-dismiss=""modal"">Hủy</button>
                    </div>

                </div>
            </div>
        </div>
        <!-- End of Modal Confirm Reset Password -->

        <!-- Modal Confirm Delete Account -->
        <div class=""modal fade modal-center-position"" id=""delete-account-modal"" role=""dialog"" aria-hidden=""true"">
            <div class=""modal-dialog"" role=""document"">
                <div class=""modal-content"">

                    <div class=""modal-header"">
                        <h5 class=""modal-title text-primary"">Xác nhận</h5>
                        <button class=""close"" type=""button"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">×</span>
                        </button>
                    </div>

                    <div class=""modal-body"">
                        <span class=""m-0 pt-1 ml-1"">Bạn có chắc chắn muốn vô hiệu hóa tài khoản</span");
                WriteLiteral(@">
                        <span class=""m-0 text-primary pt-1 ml-1"" id=""delete-username""></span>
                        <span class=""m-0 pt-1 ml-1"">không?</span>
                    </div>

                    <div class=""modal-footer"">
                        <button class=""btn btn-primary"" onclick=""deleteAccount(document.getElementById('delete-username').innerHTML)"">Đồng ý</button>
                        <button class=""btn btn-secondary"" data-dismiss=""modal"">Hủy</button>
                    </div>

                </div>
            </div>
        </div>
        <!-- End of Modal Confirm Delete Account -->

        <!-- Add New Account Modal -->
        <div class=""modal fade"" id=""add-new-modal"" role=""dialog"" aria-hidden=""true"">
            <div class=""modal-dialog modal-dialog-centered"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h3 class=""modal-title text-primary my-auto"">Đăng ký tài khoản</h3>
                 ");
                WriteLiteral(@"       <button class=""close"" type=""button"" data-dismiss=""modal"" aria-label=""Close"" onclick=""clearModal()"">
                            <span aria-hidden=""true"">×</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        <div class=""form-group"">
                            <span class=""m-0 pt-1 ml-1"">Họ và tên</span>
                            <input class=""form-control modal-input"" type=""text"" id=""new-name"">
                            <p class=""modal-error"" style=""color:red"" id=""error-name""></p>
                        </div>
                        <div class=""form-group"">
                            <span class=""m-0 pt-1 ml-1"">Tên đăng nhập</span>
                            <input class=""form-control modal-input"" type=""text"" id=""new-username"">
                            <p class=""modal-error"" style=""color:red"" id=""error-username""></p>
                            <p class=""modal-error"" style=""color:red"" id=""error");
                WriteLiteral(@"-username-exist""></p>
                        </div>
                        <div class=""form-group"">
                            <span class=""m-0 pt-1 ml-1"">Mật khẩu</span>
                            <input class=""form-control modal-input"" type=""password"" id=""new-password"">
                            <p class=""modal-error"" style=""color:red"" id=""error-password""></p>
                        </div>
                        <div class=""form-group"">
                            <span class=""m-0 pt-1 ml-1"">Xác nhận mật khẩu</span>
                            <input class=""form-control modal-input"" type=""password"" id=""new-confirm"">
                            <p class=""modal-error"" style=""color:red"" id=""error-confirm""></p>
                        </div>
                        <input class=""m-0 pt-2 ml-2"" type=""radio"" name=""new-role"" id=""new-is-owner""/>
                        <span class=""m-0 pt-2"">&nbsp; Chủ tiệm</span><br>
                        <input class=""m-0 pt-2 ml-2"" type=""radio"" name=""new-");
                WriteLiteral(@"role"" id=""new-is-cashier"" checked=""checked""/>
                        <span class=""m-0 pt-2"">&nbsp; Thu ngân</span>
                    </div>

                    <div class=""modal-footer"">
                        <button class=""btn btn-primary"" onclick=""createNewAccount()"">Đăng ký</button>
                        <button class=""btn btn-secondary"" data-dismiss=""modal"" onclick=""clearModal()"">Hủy</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End of Add New Account Modal -->

        <!-- Change Pasword Modal -->
        <div class=""modal fade"" id=""change-password-modal"" tabindex=""-1"" aria-labelledby=""changePasswordLabel""
             aria-hidden=""true"">
            <div class=""modal-dialog modal-dialog-centered"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h3 class=""modal-title text-primary my-auto"" id=""changePasswordLabel"">Đổi mật khẩu</h3>
                   ");
                WriteLiteral(@"     <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"" onclick=""clearModal()"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        <form>
                            <div class=""form-group"">
                                <label for=""currentPassword"">Mật khẩu hiện tại</label>
                                <input type=""password"" class=""form-control modal-input"" id=""currentPassword""
                                       aria-describedby=""currentPassword"">
                                <span class=""modal-error"" style=""color:red"" id=""current-password-error""></span>
                            </div>
                            <div class=""form-group"">
                                <label for=""newPassword"">Mật khẩu mới</label>
                                <input type=""password"" class=""form-control modal-input"" id=""newPas");
                WriteLiteral(@"sword""
                                       aria-describedby=""newPassword"">
                                <span class=""modal-error"" style=""color:red"" id=""new-password-error""></span>
                            </div>
                            <div class=""form-group"">
                                <label for=""confirmNewPassword"">Xác nhận mật khẩu mới</label>
                                <input type=""password"" class=""form-control modal-input"" id=""confirmNewPassword""
                                       aria-describedby=""confirmNewPassword"">
                                <span class=""modal-error"" style=""color:red"" id=""confirm-password-error""></span>
                            </div>
                        </form>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-primary"" onclick=""passwordChange()"">Đổi mật khẩu</button>
                        <button type=""button"" class=""btn btn btn-secondary"" data");
                WriteLiteral(@"-dismiss=""modal"" onclick=""clearModal()"">Hủy</button>
                    </div>
                </div>
            </div>
        </div>
        <!--End of Change Password Modal-->

        <!-- Bootstrap core JavaScript-->
        <script src=""/storeowner/vendor/jquery/jquery.min.js""></script>
        <script src=""/storeowner/vendor/bootstrap/js/bootstrap.bundle.min.js""></script>

        <!-- Core plugin JavaScript-->
        <script src=""/storeowner/vendor/jquery-easing/jquery.easing.min.js""></script>

        <!-- Custom scripts for all pages-->
        <script src=""/storeowner/js/gsm-storeowner-1.js""></script>
        <script src=""/storeowner/js/gsm-storeowner-2.js""></script>
        <script src=""/storeowner/js/staff-storeowner.js""></script>
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
            WriteLiteral("\r\n</html>");
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
