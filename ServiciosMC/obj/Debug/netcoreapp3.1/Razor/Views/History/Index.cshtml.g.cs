#pragma checksum "C:\Users\gabi_\OneDrive\Documentos\PORTAL\PortalServiciosMC\ServiciosMC\Views\History\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "490978c29db20dc21058534d486979f5730fba74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_History_Index), @"mvc.1.0.view", @"/Views/History/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"490978c29db20dc21058534d486979f5730fba74", @"/Views/History/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57c72fc012a2d3bda8492b1b12857bb8d70486cb", @"/Views/_ViewImports.cshtml")]
    public class Views_History_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"es\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "490978c29db20dc21058534d486979f5730fba743317", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Listado de Pedidos</title>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
        }

        table, th, td {
            border: 1px solid black;
        }

        th, td {
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }
    </style>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "490978c29db20dc21058534d486979f5730fba744784", async() => {
                WriteLiteral(@"

    <h2>Listado de Pedidos</h2>

    <table id=""tabla-pedidos"" class=""table"">
        <thead>
            <tr>
                <th>Folio</th>
                <th>Cliente</th>
                <th>Fecha</th>
                <th>Estado</th>
                <th>Observaciones</th>
            </tr>
        </thead>
        <tbody id=""tbody-pedidos"">
            <!-- Las filas se agregarán aquí dinámicamente -->
        </tbody>
    </table>


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
















<script src=""https://kit.fontawesome.com/a076d05399.js""></script>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
<script type=""text/javascript"">
    let usuarioLogin = """";
    $(document).ready(function () {
                 $.ajax({
                    url: '");
#nullable restore
#line 71 "C:\Users\gabi_\OneDrive\Documentos\PORTAL\PortalServiciosMC\ServiciosMC\Views\History\Index.cshtml"
                     Write(Url.Action("obtengoUsuario", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    type: ""POST"",
                    success: function (usuario) {
                        usuarioLogin = usuario;
                        llenarTabla();
                    },
                    error: function (xhr, status, error) {
                        console.error(""Error al obtener el usuario:"", error);
                    }
                });
        });
 function consultaPedidos() {
    return new Promise((resolve, reject) => {
        let pedidosUltimoEstado = {}; // Definir el objeto para almacenar el último estado de cada folio
        let pedidosConUltimoEstado = []; // Inicializar la lista de pedidos con el último estado

        console.log(""consultaPedidos - usuarioLogin: "" + usuarioLogin);

        let parametros = {
            infoUsuario: {
                usuario: usuarioLogin
            }
        };

        document.getElementById('contenedor-loader').style.display = 'flex';

        $.ajax({
            url: '");
#nullable restore
#line 98 "C:\Users\gabi_\OneDrive\Documentos\PORTAL\PortalServiciosMC\ServiciosMC\Views\History\Index.cshtml"
             Write(Url.Action("listaPedidos", "History"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            type: ""POST"",
            data: parametros,
            success: function (data) {
                if (!data.success) {
                    console.log(data.errorMensaje);
                    dialogoEG({
                        type: ""error"",
                        title: ""Error consulta de pedidos"",
                        mensaje: data.errorMensaje,
                        confirmar: ""Aceptar"",
                        img: ""img/error.png""
                    }).then(() => {
                        // Puedes limpiar o hacer otra acción aquí si es necesario
                    });

                    // Rechazar la promesa si hay un error en la respuesta
                    reject(new Error(data.errorMensaje));
                } else {
                    const pedidos = JSON.parse(data.respuesta).listadoPedidos;
                    console.log(""pedidos:"");
                    console.log(pedidos);

                    // Iterar sobre la lista de pedidos para encontrar ");
            WriteLiteral(@"el último estado de cada folio
                    pedidos.forEach(pedido => {
                        const folio = pedido.folio;
                        // Si el folio no está en el objeto o si el estado actual es más reciente
                        if (!pedidosUltimoEstado[folio] || new Date(pedido.fecha_estado) > new Date(pedidosUltimoEstado[folio].fecha_estado)) {
                            pedidosUltimoEstado[folio] = pedido;
                        }
                    });

                    // Obtener los valores de los pedidos con el último estado
                    pedidosConUltimoEstado = Object.values(pedidosUltimoEstado);

                    // Resolver la promesa con los datos obtenidos
                    resolve(pedidosConUltimoEstado);
                }

                document.getElementById('contenedor-loader').style.display = 'none';
            },
            error: function (xhr, status, error) {
                document.getElementById('contenedor-loader').styl");
            WriteLiteral(@"e.display = 'none';
                console.log(""Error al consultar pedidos:"", error);

                dialogoEG({
                    type: ""error"",
                    title: ""Error de comunicación"",
                    mensaje: ""Ocurrió un error al obtener listado de pedidos. Intente nuevamente, si el inconveniente persiste contacte al administrador."",
                    confirmar: ""Aceptar"",
                    img: ""img/error.png""
                });

                // Rechazar la promesa en caso de error
                reject(error);
            }
        });
    });
}




    function llenarTabla() {
        const tbody = document.getElementById(""tbody-pedidos"");

        // Limpiar el contenido actual del tbody
        tbody.innerHTML = """";

        // Llamar a consultaPedidos y manejar la promesa
        consultaPedidos().then(pedidosConUltimoEstado => {
            // Recorrer la lista de pedidos
            pedidosConUltimoEstado.forEach(pedido => {
              ");
            WriteLiteral(@"  // Crear una fila para cada pedido
                const fila = document.createElement(""tr"");

                // Crear celdas para cada dato del pedido
                const celdaId = document.createElement(""td"");
                celdaId.textContent = pedido.folio;
                fila.appendChild(celdaId);

                const celdaCliente = document.createElement(""td"");
                celdaCliente.textContent = pedido.cliente;
                fila.appendChild(celdaCliente);

                const celdaProducto = document.createElement(""td"");
                celdaProducto.textContent = pedido.fecha_estado;
                fila.appendChild(celdaProducto);

                const celdaEstado = document.createElement(""td"");
                celdaEstado.textContent = pedido.estado_actual;
                fila.appendChild(celdaEstado);

                const celdaFecha = document.createElement(""td"");
                celdaFecha.textContent = pedido.observaciones;
                fila.appe");
            WriteLiteral(@"ndChild(celdaFecha);

                // Agregar la fila al tbody
                tbody.appendChild(fila);
            });
        }).catch(error => {
            console.log(""Error al llenar la tabla:"", error);
            // Aquí podrías manejar el error, por ejemplo, mostrando un mensaje en la interfaz de usuario
        });
    }


</script>");
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
