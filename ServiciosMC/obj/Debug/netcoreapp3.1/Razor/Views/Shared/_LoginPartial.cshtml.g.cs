#pragma checksum "C:\Users\gabi_\OneDrive\Documentos\PORTAL\PortalServiciosMC\ServiciosMC\Views\Shared\_LoginPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3274a6c283a06d597d0578fdb5600048ca333bc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LoginPartial), @"mvc.1.0.view", @"/Views/Shared/_LoginPartial.cshtml")]
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
#line 1 "C:\Users\gabi_\OneDrive\Documentos\PORTAL\PortalServiciosMC\ServiciosMC\Views\_ViewImports.cshtml"
using ServiciosMC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gabi_\OneDrive\Documentos\PORTAL\PortalServiciosMC\ServiciosMC\Views\_ViewImports.cshtml"
using ServiciosMC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3274a6c283a06d597d0578fdb5600048ca333bc6", @"/Views/Shared/_LoginPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57c72fc012a2d3bda8492b1b12857bb8d70486cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LoginPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("loginForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3274a6c283a06d597d0578fdb5600048ca333bc63667", async() => {
                WriteLiteral(@"
        <div id=""cont-login"">

            <h3 class=""mb-3 mt-3"">INICIO DE SESIÓN</h3>
            <div class=""mb-3"">
                <input type=""text"" class=""form-control"" id=""txtUser"" style=""text-transform:uppercase;"" placeholder=""Usuario"" required>
            </div>
            <div class=""mb-3"">
                <input type=""password"" class=""form-control"" id=""txtPasswd"" placeholder=""Contraseña"" required>
            </div>
            <div class=""mb-3"">
                <button type=""submit"" class=""btn botonIngreso"" id=""btnIngreso"">Ingresar</button>
            </div>
            <div class=""mb-3"">
                <a href=""#!"" class=""link-secondary text-decoration-none small-link"">¿Olvidaste tu contraseña?</a>
            </div>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


  
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
<script>
    function Autenticar() {
    var usuario = $('#txtUser').val().toUpperCase();
    var password = $('#txtPasswd').val();
    var dataFormAut = new FormData();
    dataFormAut.append(""Usuario"", usuario);
    dataFormAut.append(""Password"", password);
        document.getElementById('contenedor-loader').style.display = 'flex';
        formactivo(true);
    $.ajax({
        url: '");
#nullable restore
#line 34 "C:\Users\gabi_\OneDrive\Documentos\PORTAL\PortalServiciosMC\ServiciosMC\Views\Shared\_LoginPartial.cshtml"
         Write(Url.Action("Autenticacion","Login"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n        type: \"POST\",\r\n        data: dataFormAut,\r\n        contentType: false,\r\n        processData: false,\r\n        success: function (data) {\r\n            console.log(data);\r\n            if (data.estado) {\r\n                window.location.href = \'");
#nullable restore
#line 42 "C:\Users\gabi_\OneDrive\Documentos\PORTAL\PortalServiciosMC\ServiciosMC\Views\Shared\_LoginPartial.cshtml"
                                   Write(Url.Action("Index", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
            } else {
                dialogoEG({
                    type: ""error"",
                    title: ""Error al iniciar sesión"",
                    mensaje: data.mensaje,
                    confirmar: ""Aceptar"",
                    img: ""img/error.png""
                }).then(() => {
                    formactivo(false);
                });
            }
        },
        error: function (xhr, status, error) {
            dialogoEG({
                type: ""error"",
                title: ""Error al iniciar sesión"",
                mensaje: ""Ocurrió un error durante la autenticación. Contacte al administrador."",
                confirmar: ""Aceptar"",
                img: ""img/error.png""
            }).then(() => {
                formactivo(false);
            });
        },
        complete: function () {
            document.getElementById('contenedor-loader').style.display = 'none';
        }
    });

    return false;
    }

    function formactivo(accion) {
  ");
            WriteLiteral(@"      document.getElementById('btnIngreso').disabled = accion;
        document.getElementById('txtUser').disabled = accion;
        document.getElementById('txtPasswd').disabled = accion;
    }

    document.getElementById('loginForm').addEventListener('submit', function (event) {
        if (this.checkValidity()) {
            event.preventDefault();

            Autenticar();


        }
    });

</script>
");
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
