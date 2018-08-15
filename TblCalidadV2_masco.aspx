<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TblCalidadV2_masco.aspx.vb" Inherits="TablerosV2.TblCalidadV2_masco" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Calidad</title>
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
    <script src="Bootstrap/js/jquery-3.2.0.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <style type="text/css">
        .cssHeader {
            background-image: url(img/imgHeaderCaliad.png);
            background-size: cover;
            background-repeat: no-repeat;
        }

        .modalBack {
            background-color: black;
            filter: alpha(opacity=90);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            //copy options
            var options = $('#cmdVehiduloEntaller option').clone();
            //react on keyup in textbox
            $('#buscador0').keyup(function () {
                var val = $(this).val().toLowerCase();
                $('#cmdVehiduloEntaller').empty();
                //take only the options containing your filter text or all if empty
                options.filter(function (idx, el) {
                    return val === '' || $(el).text().toLowerCase().indexOf(val) >= 0;
                }).appendTo('#cmdVehiduloEntaller');//add it to listS
            });
        });
        $(document).ready(function () {


            $('input').keypress(function (e) {
                if (e.which == 13) {
                    return false;
                }
            });


            $('#buscador').keyup(function () {
                buscar = $(this).val();

                var jo1 = $("#GridPendientes").find("tr");
                if (jQuery.trim(buscar) != '') { jo1.parents('tr').hide(); } else { jo1.parents('tr').show(); }
                var jo2 = $("#gridfinalizados").find("tr");
                if (jQuery.trim(buscar) != '') { jo2.parents('tr').hide(); } else { jo2.parents('tr').show(); }

                $('#GridPendientes a').removeClass('resaltar');

                if (jQuery.trim(buscar) != '') {
                    $("#GridPendientes td:icontains('" + buscar + "')").addClass('resaltar');
                    jo = $("#GridPendientes td:icontains('" + buscar + "')").parents('tr');
                    jo.show();
                }

                $('#gridfinalizados a').removeClass('resaltar');

                if (jQuery.trim(buscar) != '') {

                    $("#gridfinalizados td:icontains('" + buscar + "')").addClass('resaltar');
                    jo3 = $("#gridfinalizados td:icontains('" + buscar + "')").parents('tr');
                    jo3.show();
                }
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server" class="form-inline">
        <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />
        <div class="container cssHeader jumbotron" style="width: 100%;">
            <div id="divheader" class="container form-group page-header">
                <div id="divImagenLogo" class="form-inline">
                    <asp:Image runat="server" ID="ImgLogo" ImageUrl="~/img/AgenciaLogoHeader.png" Width="260px" Height="60px" Style="float: left;" />
                    <asp:ImageButton runat="server"
                        ID="btnSalir" ImageUrl="~/img/BtnSalir.png" Width="12em" Height="6em" Style="float: right;" OnClick="btnSalir_Click" />
                </div>
            </div>
        </div>
        <div id="DivCuerpoPAg" class="container" style="width: 100%;">
            <div id="divmenu" class="container">
                <asp:Menu ID="Menu1" Width="168px" runat="server" DynamicMenuItemStyle-BorderColor="White"
                    DynamicHoverStyle-BorderStyle="Solid" Orientation="Horizontal" BorderColor="White"
                    BorderStyle="Solid" StaticEnableDefaultPopOutImage="true" OnMenuItemClick="Menu1_MenuItemClick">
                    <Items>
                        <asp:MenuItem Text="Pendientes" Value="0"></asp:MenuItem>
                        <asp:MenuItem Text="Finalizados " Value="1"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </div>
            <div id="header_cuerpo" class="container" style="float: left;">
                <br />
                <asp:Label
                    runat="server"
                    CssClass="label"
                    ID="lblagregarunidad"
                    Text="Agregar unidad:"
                    Style="font-size: 2em; color: black;"></asp:Label>
                <asp:TextBox runat="server" name="buscador0" ID="buscador0" class="form-control input-sm" type="text" />
                <asp:DropDownList ID="cmdVehiduloEntaller" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                <asp:ImageButton runat="server" ID="imgAgregar" ImageUrl="~/img/imgAceptar.png" ToolTip="Iniciar"
                    Width="2.5em" Height="2.5em" OnClick="imgAgregarNUevo_Click1" />
                <asp:ImageButton
                    runat="server"
                    ID="imgAgregarNUevo"
                    ImageUrl="~/img/imgbtnAgregar.png"
                    Width="3em"
                    Height="3em"
                    Style="float: right;" OnClick="imgAgregarNUevo_Click" />
            </div>
            <div id="divPanelAgregarNuevo" class="container form-group">
                <div id="divImgAgregar" class="container" style="padding-top: 3em; width: 100%">
                    <asp:Panel runat="server" ID="pnlAgregarNuevo" Style="display: none;">
                        <asp:Label runat="server" ID="lblPanelAgregarNuevoActivo" Style="display: none;" Text="0" />
                        <div class="form-group">
                            <label>Placas:</label>
                            <asp:TextBox ID="txtPlacas" runat="server" Visible="true" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Vehículo:</label>
                            <asp:DropDownList ID="cboVehiculo" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Color:</label>
                            <asp:DropDownList ID="cboColor" runat="server" CssClass="form-control input-sm">
                                <asp:ListItem>Blanco</asp:ListItem>
                                <asp:ListItem>Negro</asp:ListItem>
                                <asp:ListItem>Azul</asp:ListItem>
                                <asp:ListItem>Rojo</asp:ListItem>
                                <asp:ListItem>Gris</asp:ListItem>
                                <asp:ListItem>Amarillo</asp:ListItem>
                                <asp:ListItem>Verde</asp:ListItem>
                                <asp:ListItem>Cafe</asp:ListItem>
                                <asp:ListItem>Naranja</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>servicio:</label>
                            <asp:DropDownList ID="cmdServicios" runat="server" CssClass="form-control input-sm">
                                <asp:ListItem>Revision Preliminar</asp:ListItem>
                                <asp:ListItem>Otro</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:ImageButton
                            ID="imgNuevoOK"
                            runat="server"
                            ImageUrl="~/img/imgAceptar.png"
                            ToolTip="Nuevo"
                            Width="2.5em"
                            Height="2.5em"
                            Style="float: right;"
                            OnClick="imgNuevoOK_Click" />
                    </asp:Panel>
                </div>
            </div>
             <asp:TextBox runat="server" name="buscador" ID="buscador" class="form-control input-sm" type="text" placeholder="Buscar"  />
            <asp:MultiView ID="multiview1" runat="server" ActiveViewIndex="0">
                <asp:View runat="server" ID="tblPendientes">
                   
                    <div class="container" style="text-align: center; width: 100%; padding-top: 3em;">
                        <asp:DataGrid runat="server" ID="GridPendientes" Visible="false" CssClass=" table table-striped table-condensed" GridLines="None"
                            AutoGenerateColumns="false" Width="100%">
                            <%--<HeaderStyle BackColor="#034EC6" ForeColor="White" HorizontalAlign="Center" />--%>
                            <ItemStyle />
                            <Columns>
                                <asp:BoundColumn DataField="id" HeaderText="id" Visible="false" />
                                <asp:BoundColumn DataField="id_hd" HeaderText="Header" Visible="false" />
                                <asp:BoundColumn DataField="noorden" HeaderText="Orden Servicio" Visible="true" />
                                <asp:BoundColumn DataField="noplacas" HeaderText="Placas" Visible="true" />
                                <asp:BoundColumn DataField="vehiculo" HeaderText="Modelo" Visible="true" />
                                <asp:BoundColumn DataField="fecha" HeaderText="Fecha" Visible="true" />
                                <asp:BoundColumn DataField="fecha_hora_ini" HeaderText="Inicio" Visible="true" />
                                <asp:BoundColumn DataField="tecnico" HeaderText="Tecnico" Visible="true" />
                                <asp:BoundColumn DataField="servicio" HeaderText="Operacion" Visible="true" />
                                <asp:BoundColumn DataField="comentarios" HeaderText="Comentarios" Visible="true" />
                                <asp:BoundColumn DataField="status" HeaderText="Estado" Visible="true" />
                                <asp:BoundColumn DataField="id_calidad" HeaderText="Id Interno Calidad" Visible="false" />
                                <asp:BoundColumn DataField="Control" HeaderText="Tipo" Visible="true" />
								<asp:BoundColumn DataField="Base" HeaderText="Taller" Visible="true" />
                                <asp:TemplateColumn HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:ImageButton
                                            runat="server" ID="imgIniciar"
                                            ImageUrl="~/IMG/AZUL.JPG"
                                            Width="1em"
                                            Height="1em"
                                            OnClientClick="javascript:if(!confirm('¿Seguro desea Iniciar este Vehículo?'))return false"
                                            OnClick="imgIniciar_Click" />
                                        <asp:ImageButton
                                            runat="server" ID="imgcalidadOk"
                                            ImageUrl="~/IMG/VERDE.JPG"
                                            Width="1em"
                                            Height="1em"
                                            OnClick="imgcalidadOk_Click" />
                                        <asp:ImageButton
                                            runat="server" ID="imgRutaok"
                                            ImageUrl="~/img/imgAceptarBorrar.png"
                                            Width="1em"
                                            Height="1em"
                                            Visible="false" />
                                        <asp:ImageButton
                                            runat="server" ID="imgRetrabajo"
                                            ImageUrl="~/IMG/Rojo.JPG"
                                            Width="1em"
                                            Height="1em"
                                            OnClick="imgRetrabajo_Click" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>

                            </Columns>
                        </asp:DataGrid>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="multiviwe2">
                    <div class="container" style="text-align: center; width: 100%; padding-top: 3em;">
                        <div class="form-group">
                            <asp:Label runat="server" ID="LblGVFinish" Text="Atendidos/Finalizados" ForeColor="Silver"
                                Font-Size="Large" Font-Bold="true">      
                            </asp:Label>
                            <asp:TextBox ID="txtFec1" runat="server" placeholder="Fecha Inicio" required=""></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="txtFec1Ex" TargetControlID="txtFec1" Format="dd/MM/yyyy" PopupButtonID="txtFec1"></ajaxToolkit:CalendarExtender>
                            <asp:TextBox ID="txtFec2" runat="server" placeholder="Fecha Fin" required=""></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="txtFec2Ex" TargetControlID="txtFec2" Format="dd/MM/yyyy" PopupButtonID="txtFec2"></ajaxToolkit:CalendarExtender>
                            <asp:Button ID="CmdBuscarLavadorFinish" runat="server" CssClass="btn btn-default" OnClick="CmdBuscarLavadorFinish_Click" Text="Filtrar" />
                        </div>
                        <div class="container" style="width: 100%; padding-top: 3em;">
                            <asp:DataGrid runat="server" ID="gridfinalizados" Visible="true" CssClass=" table table-striped table-condensed" GridLines="None"
                                AutoGenerateColumns="false" Width="100%">
                                <%--<HeaderStyle BackColor="#034EC6" ForeColor="White" HorizontalAlign="Center" />--%>
                                <ItemStyle />
                                <Columns>
                                    <asp:BoundColumn DataField="noorden" HeaderText="Orden Servicio" Visible="true" />
                                    <asp:BoundColumn DataField="noplacas" HeaderText="Placas" Visible="true" />
                                    <asp:BoundColumn DataField="fecha" HeaderText="Fecha" Visible="true" />
                                    <asp:BoundColumn DataField="fecha_hora_ini" HeaderText="Inicio" Visible="true" />
                                    <asp:BoundColumn DataField="fecha_hora_fin" HeaderText="Fin" Visible="true" />
                                    <asp:BoundColumn DataField="tecnico" HeaderText="Tecnico" Visible="true" />
                                    <asp:BoundColumn DataField="servicio" HeaderText="Operacion" Visible="true" />
                                    <asp:BoundColumn DataField="comentarios" HeaderText="Comentarios" Visible="true" />
                                    <asp:BoundColumn DataField="control" HeaderText="Estado" Visible="true" />
                                    <asp:BoundColumn DataField="Usuario" HeaderText="Encargado" Visible="true" />
                                    <asp:BoundColumn DataField="id_calidad" HeaderText="Id Interno Calidad" Visible="false" />
                                </Columns>
                            </asp:DataGrid>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
            <asp:Button runat="server" ID="btnmodal3"
                Style="display: none" Text="muestramodal" />
            <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="btnmodal3" PopupControlID="PanelDetalle"
                Enabled="true" Drag="true" DropShadow="true" BackgroundCssClass="modalBack" CancelControlID="btnCancelar">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel runat="server" ID="PanelDetalle" Style="display: none; background: white; width: 80%; height: auto">
                <div class="modal-dialog modal-sm" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <%--<asp:Button runat="server" type="button" CssClass="close" data-dismiss="modal" aria-label="Close" Text="x"></asp:Button>--%>
                            <h4 class="modal-title" id="myModalLabel">Confirmación</h4>
                        </div>
                        <div class="modal-body" style="width: 100%;">
                            <div id="dvlform" class="form-group form-lg" style="padding: 1em; width: 100%;">
                                <asp:Label ID="lblIdInterno" runat="server" Text="" Style="display: none;"></asp:Label>
                                <asp:Label ID="lblidInterno2" runat="server" Text="" Style="display: none;"></asp:Label>
                                <asp:Label ID="lblInicio" runat="server" Text="" Style="display: none;"></asp:Label>
                                <asp:DropDownList runat="server" ID="cmbUsuariosCalidad" class="form-control" placeHolder="Usuario" Visible="false"></asp:DropDownList>
                                <asp:Label ID="lblComentarios" runat="server" Text="Comentarios: " Visible="false"></asp:Label>
                                <asp:TextBox ID="txtcomentarios" Visible="false" runat="server" TextMode="MultiLine"
                                    ReadOnly="false"
                                    placeholder="El comentario es obligatorio"
                                    CssClass="form-control" Style="width=100%;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" type="button" ID="btnCancelar" class="btn btn-default" Text="Cerrar"></asp:Button>
                            <asp:Button runat="server" type="button" ID="btnOK" class="btn btn-default" Text="Aceptar" OnClick="btnOK_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
