<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="_zrecepcionLlegadas.aspx.vb" Inherits="TablerosV2._zrecepcionLlegadas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"/>
    <title>Recepción de vehículos</title>
    <!--<link rel="stylesheet" href="css/generales.css" />-->
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css"/>
    <script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <style type="text/css">
        .cssMPGVPop {
            background-color: #F0F0F0;
            border: solid 1px #2F4F4F;
            text-align: center;
            vertical-align: top;
            font-size: 16px;
            font-family: arial;
        }

        .cssDefault {
            width: 97%;
            font-size: 14px;
        }

        .cssLink {
            color: #A8BBCE;
        }

        .cssImg {
            width: 21px;
            display: block;
            cursor: auto;
        }

        .cssImgHdd {
            width: 21px;
            display: none;
        }



        .DivInfoAD {
            display: block;
            overflow:no-display ;
            height: 200px;
            width: 300px;
            background-color: gainsboro;
            scrollbar-face-color: #FFFFFF;
            scrollbar-shadow-color: #003366;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #FDFDFE;
            scrollbar-arrow-color: #003366;
        }

        .GrdOver {
            overflow: auto;
            height: 400px;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
        }

        .GrdOver2 {
            height: 180px;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
            color: White;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 15px;
            font-weight: bold;
        }

        .GrdOver2b {
            height: 220px;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
            color: White;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 15px;
            font-weight: normal;
        }

        .GrdOver3 {
            border: 1px solid #dd9BC7;
            color: White;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 15px;
            font-weight: bold;
        }

        .GrdOver4 {
            border: 1px solid #009BC7;
            color: White;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 15px;
            font-weight: bold;
        }

        .GrdOver5 {
            overflow: auto;
            height: 75px;
            width: 915px;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
            color: White;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 15px;
            font-weight: normal;
        }

        .txtM {
            border: solid 1px #173344;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
            width: 100px;
        }

        .txtV {
            border: solid 1px #173344;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
            width: 200px;
        }

        .clsInterfazMenu {
            background-color: #bdcde5;
            font-size: 15px;
            font-family: Calibri;
            width: 500px;
        }

        .resaltar {
            background-color: #FF0;
        }
    </style>

    <script type="text/javascript">
        var xwin


        function ocultardivInfoAD() {

            var obj = document.getElementById('divInfoAD');
            if (obj.style.display == 'none') { obj.style.display = 'block' }
            else { obj.style.display = 'none' }

            // Preload(false, 'divloader', 'divprn');
            // window.opener.PostB();

            //window.close();

        }
        function PostBScript() {


            __doPostBack('OkButtonMPGV', '');
            // Preload(false, 'divloader', 'divprn');
            // window.opener.PostB();

            //window.close();

        }
        function doBuscaPlacas() {


            __doPostBack('cmdBuscaPlacas', '');
            // Preload(false, 'divloader', 'divprn');
            // window.opener.PostB();

            //window.close();

        }
        function PostBScript2() {


            __doPostBack('OkButtonMPGV2', '');
            // Preload(false, 'divloader', 'divprn');
            // window.opener.PostB();

            //window.close();

        }
        function PostBScript3() {


            __doPostBack('OkButtonMPGV3', '');
            // Preload(false, 'divloader', 'divprn');
            // window.opener.PostB();

            //window.close();

        }
        function noneScript() {
            //        var obj = document.getElementById('divInfoAD');
            //        obj.style.display = 'none';
            // Preload(false, 'divloader', 'divprn');
        }
        $.expr[':'].icontains = function (obj, index, meta, stack) {
            return (obj.textContent || obj.innerText || jQuery(obj).text() || '').toLowerCase().indexOf(meta[3].toLowerCase()) >= 0;
        };
        $(document).ready(function () {

            $("#divNuevo").hide();

            $('#btnNuevo').click(function () {
                $("#divNuevo").toggle(400);

            });

            $('input').keypress(function (e) {
                if (e.which == 13) {
                    return false;
                }
            });

            $('#buscador').keyup(function () {
                buscar = $(this).val();

                var jo1 = $("#dg1").find("tr");
                if (jQuery.trim(buscar) != '') { jo1.parents('tr').hide(); } else { jo1.parents('tr').show(); }
                var jo2 = $("#dg2").find("tr");
                if (jQuery.trim(buscar) != '') { jo2.parents('tr').hide(); } else { jo2.parents('tr').show(); }

                $('#dg1 a').removeClass('resaltar');
                if (jQuery.trim(buscar) != '') {
                    $("#dg1 a:icontains('" + buscar + "')").addClass('resaltar');
                    var jo = $("#dg1 a:icontains('" + buscar + "')").parents('tr');
                    jo.show();
                }
                $('#dg2 span').removeClass('resaltar');
                if (jQuery.trim(buscar) != '') {
                    $("#dg2 span:icontains('" + buscar + "')").addClass('resaltar');
                    var jo = $("#dg2 span:icontains('" + buscar + "')").parents('tr');
                    jo.show();
                }
            });





        });

        $(function () {
            $(".table").parent().addClass("table-responsive");
        });
    </script>

    <meta http-equiv="refresh" content="180" />
</head>
<body>

    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />

        <div class="container">

            <div class="row">
                <div class="col-md-12">


                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <img src="img/AgenciaLogoHeader.png" style="float: left;" /></td>
                            <td>


                                <asp:ImageButton ID="imgSalir" runat="server" AlternateText="Salir" Style="float: right;" ImageUrl="img/logout.png" />
                            </td>
                        </tr>
                    </table>

                </div>
            </div>




        </div>
    
        <div class="row">
            <div class="col-sm-4">
                <div class="btn-group" style="display: inline-block;">
                    <asp:Menu ID="Menu1" runat="server" DynamicMenuItemStyle-BorderColor="White"
                        DynamicHoverStyle-BorderStyle="Solid" Orientation="Horizontal"
                        StaticEnableDefaultPopOutImage="False" OnMenuItemClick="Menu1_MenuItemClick"
                        DynamicHorizontalOffset="2"
                        StaticSubMenuIndent="12px" CssClass="btn btn-default" BackColor="#F7F6F3" Font-Names="Verdana" Font-Size="1em" ForeColor="#7C6F57">
                        <StaticSelectedStyle BackColor="#5D7B9D" />
                        <StaticMenuItemStyle HorizontalPadding="0px" VerticalPadding="0px" />
                        <DynamicHoverStyle BorderStyle="Solid" BackColor="#7C6F57" ForeColor="White"></DynamicHoverStyle>

                        <DynamicMenuStyle BackColor="#F7F6F3" />
                        <DynamicSelectedStyle BackColor="#5D7B9D" />

                        <DynamicMenuItemStyle BorderColor="White" HorizontalPadding="0px" VerticalPadding="0px"></DynamicMenuItemStyle>
                        <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                        <Items>
                            <asp:MenuItem Text="Anteriores" Value="0"></asp:MenuItem>
                            <asp:MenuItem Text="De Hoy" Value="1"></asp:MenuItem>
                            <asp:MenuItem Selectable="false"></asp:MenuItem>
                        </Items>
                    </asp:Menu>
                </div>
            </div>
            <div class="col-sm-4 form-inline">
                <div class="form-group">
                    <label>Buscar:</label>
                    <input name="buscador" id="buscador" class="form-control input-sm" type="text" />
                </div>
            </div>
            <div class="col-sm-4">
            </div>
        </div>


        <div class="row">
            <div class="col-md-12">
                <asp:DataGrid ID="dg1" runat="server" GridLines="None" AutoGenerateColumns="False" CssClass="table table-striped table-condensed" ShowHeaderWhenEmpty="true">
                    <ItemStyle />
                    <Columns>
                        <asp:TemplateColumn HeaderText="Placa" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td style="padding-right: 1em;">
                                            <asp:ImageButton ID="imgDelete" runat="server" AlternateText="Eliminar" OnClick="imgDelete_Click" ImageUrl="img/Delete_32x32.png" />
                                        </td>
                                        <td style="padding-right: 1em;">
                                            <asp:Label ID="lblIdVehiculo" runat="server" Text='<%# Eval("idVehiculo") %>'></asp:Label></td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><%# Eval("NOPlacas") %></asp:LinkButton></td>
                                    </tr>
                                </table>


                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="NOPlacas" HeaderText="Placas" Visible="false" />
                        <asp:TemplateColumn HeaderText="Cliente" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table>
                                    <tr>

                                        <td>
                                            <asp:LinkButton ID="lnkCliente" runat="server" OnClick="lnkCliente_Click"><%# If(Eval("Cliente").ToString.Trim.Length > 0, Eval("Cliente"), "ninguno")%></asp:LinkButton></td>
                                    </tr>
                                </table>


                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Vehiculo" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lnkVehiculo" runat="server" OnClick="lnkVehiculo_Click"><%# Eval("Vehiculo")%></asp:LinkButton></td>
                                    </tr>
                                </table>


                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateColumn>
                        <%-- <asp:BoundColumn DataField="Cliente" HeaderText="Cliente" />
                                            <asp:BoundColumn DataField="Vehiculo" HeaderText="Modelo" />--%>
                        <asp:BoundColumn DataField="HoraAsesor" HeaderText="Hora Cita" DataFormatString="{0:t}" />
                        <asp:BoundColumn DataField="Asesor" Visible="true" HeaderText="Asesor" />

                        <asp:TemplateColumn HeaderText="Recibir" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkRecibido" AutoPostBack="true" Text=""
                                    OnCheckedChanged="chkRecibido_CheckedChanged" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>

                        <asp:BoundColumn DataField="Horallegada" HeaderText="Hora Llegada" />
                        <asp:TemplateColumn HeaderText="Salida" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkEntrega" AutoPostBack="true" Text=""  Enabled="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>

                        <asp:BoundColumn DataField="HoraRetiro" HeaderText="Hora Retiro" />
                        <asp:BoundColumn DataField="colorPrisma" Visible="false" HeaderText="Torre" />
                        <asp:BoundColumn DataField="cCita" Visible="true" HeaderText="" />
                        <asp:BoundColumn DataField="vin" Visible="true" HeaderText="vin" />
                        <asp:BoundColumn DataField="numcita" Visible="true" HeaderText="Cita" />
                        <asp:BoundColumn DataField="fecha_hora_Com" Visible="false" HeaderText="Fecha Entrega" />
                        <asp:BoundColumn DataField="idve" Visible="false" HeaderText="id_hd" />
                        <asp:TemplateColumn HeaderText="Torre" Visible="false">
                            <ItemTemplate>
                                <table>

                                    <tr>

                                        <td>
                                            <asp:Label ID="lblTorre2" runat="server" Visible="false" Text='<%# Eval("idVehiculo") %>'></asp:Label></td>
                                        <td>
                                            <asp:LinkButton ID="lnkTorre2" runat="server" OnClick="lnkTorre2_Click"><%# If(Eval("colorPrisma").ToString.Trim.Length > 0, Eval("colorPrisma"), "ninguno")%></asp:LinkButton></td>
                                    </tr>
                                </table>
                            </ItemTemplate>

                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="Fecha Hora Entrega">
                            <ItemTemplate>
                                <table>

                                    <tr>

                                        <td>
                                            <asp:Label ID="lblIdVehiculo2" runat="server" Visible="false" Text='<%# Eval("idVehiculo")%>'></asp:Label></td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click2"><%# If(Eval("fecha_hora_Com").ToString.Trim.Length>0 ,Eval("fecha_hora_Com"),"ninguna")%></asp:LinkButton></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateColumn>

                        <asp:BoundColumn DataField="noOrden" Visible="true" HeaderText="Orden" />

                    </Columns>
                    <HeaderStyle Wrap="True" />
                    <FooterStyle HorizontalAlign="Right" />
                    <AlternatingItemStyle BorderColor="White" />
                    <PagerStyle BackColor="#4E1414" ForeColor="White" HorizontalAlign="Center" />
                </asp:DataGrid>

 

            </div>

        </div>

        <div>
            <asp:Button runat="server" ID="cmdMPGV" Style="display: none;" />

            <ajaxToolkit:ModalPopupExtender ID="MPGV" runat="server"
                BackgroundCssClass="watermarked" CancelControlID="NoButtonMPGV"
                DropShadow="false" OkControlID="OkButtonMPGV" OnCancelScript="noneScript()"
                OnOkScript="PostBScript()" PopupControlID="PopupMPGV"
                TargetControlID="cmdMPGV" Drag="true">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="PopupMPGV" runat="server">
                <div id="ModalPopupMPGV">

                    <asp:Panel ID="PopupDragHandleMPGV" runat="Server" CssClass="modal-dialog">

                        <div class="modal-content">
                            <div class="modal-body">
                                <div class="form-group">
                                    <asp:Label ID="lblOp" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblInf1" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblInf2" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblInf3" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblMSG" runat="server" Text=""></asp:Label>
                                    <asp:Label runat="server" ID="lblModCliente" Visible="false" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Cliente"></asp:Label>
                                    <asp:Label runat="server" ID="lblTorre" Visible="false" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Torre:"></asp:Label>
                                    <asp:Label runat="server" ID="lblModfecha" Visible="false" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Fecha Entrega:"></asp:Label>
                                    <asp:Label runat="server" ID="lblModPlacas" Visible="false" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Placas:"></asp:Label>
                                    <asp:Label runat="server" ID="lblModVehiculo" Visible="false" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Placas:"></asp:Label>
                                    <asp:Label runat="server" ID="lblEliminar" Visible="false" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Confirma eliminar este registro"></asp:Label>

                                    <asp:TextBox runat="server" ID="txtModFecha"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender runat="server" ID="txtModFechaex" TargetControlID="txtModFecha" Format="dd/MM/yyyy hh:mm" PopupButtonID="txtModFecha"></ajaxToolkit:CalendarExtender>
                                    <asp:TextBox runat="server" ID="txtTorre"></asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtModPlacas"></asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtModCliente"></asp:TextBox>
                                    <asp:DropDownList ID="cboModVehiculo" runat="server" Font-Size="15px" Font-Bold="True">
                                    </asp:DropDownList>
                                </div>

                                <div style="text-align: center;">
                                    <div class="btn-group" style="display: inline-block;">
                                        <%--  <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-primary" Text="Si" style="float: none;" /><!--
                                        --><asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-default" Text="No" style="float: none;" OnClick="NoButtonMPGV_Click" />--%>


                                        <asp:ImageButton ID="imgokDdModPlacas" runat="server" ImageUrl="img/aceptar.png"
                                            ToolTip="OK" Style="display: none; width: 20px;" />
                                        <asp:Button ID="imgokModPlacas" runat="server" BackColor="#eeeeee"
                                            BorderColor="#2F4F4F" Font-Bold="True" ForeColor="#000066" Text="Guardar placa y recibir"
                                            Width="165px" Style="display: none;" />

                                        <asp:Button ID="OkButtonMPGV" runat="server" CssClass="btn btn-primary" Style="float: none;" Text="Si" />

                                        <asp:Button ID="NoButtonMPGV" runat="server" Text="No"
                                            CssClass="btn btn-default" Style="float: none;" />

                                    </div>
                                </div>
                            </div>
                        </div>













                    </asp:Panel>

                </div>



            </asp:Panel>




        </div>








    </form>
</body>
</html>
