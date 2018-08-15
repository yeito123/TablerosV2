﻿<%@ Page Language="VB" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="_tblCalidad.aspx.vb" Inherits="TablerosV2._tblCalidad" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="Controles/ctlSalir.ascx" tagname="ctlSalir" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">


</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Calidad</title>
    <link rel="stylesheet" href="css/generales.css" />
     <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css"/>
    <script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <style type="text/css">
        .resaltar {
            background-color: #FF0;
        }
        .style1
        {
            width: 145px;
        }
    </style>
    <script type="text/javascript">

        $.expr[':'].icontains = function (obj, index, meta, stack) {
            return (obj.textContent || obj.innerText || jQuery(obj).text() || '').toLowerCase().indexOf(meta[3].toLowerCase()) >= 0;
        };


        $(document).ready(function () {
            //copy options
            var options = $('#cboVehiculo option').clone();
            //react on keyup in textbox
            $('#buscador0').keyup(function () {
                var val = $(this).val().toLowerCase();
                $('#cboVehiculo').empty();
                //take only the options containing your filter text or all if empty
                options.filter(function (idx, el) {
                    return val === '' || $(el).text().toLowerCase().indexOf(val) >= 0;
                }).appendTo('#cboVehiculo');//add it to listS
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

                var jo1 = $("#GridView1").find("tr");
                if (jQuery.trim(buscar) != '') { jo1.parents('tr').hide(); } else { jo1.parents('tr').show(); }
                var jo2 = $("#GvFinish").find("tr");
                if (jQuery.trim(buscar) != '') { jo2.parents('tr').hide(); } else { jo2.parents('tr').show(); }

                $('#GridView1 a').removeClass('resaltar');

                if (jQuery.trim(buscar) != '') {
                    $("#GridView1 td:icontains('" + buscar + "')").addClass('resaltar');
                    jo = $("#GridView1 td:icontains('" + buscar + "')").parents('tr');
                    jo.show();
                }

                $('#GvFinish a').removeClass('resaltar');

                if (jQuery.trim(buscar) != '') {

                    $("#GvFinish td:icontains('" + buscar + "')").addClass('resaltar');
                    jo3 = $("#GvFinish td:icontains('" + buscar + "')").parents('tr');
                    jo3.show();
                }
            });





        });


    </script>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1" />
        <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="TextBox3"
            PopupControlID="ModalPanel" DropShadow="True" Enabled="true" Drag="true" CancelControlID="CmdCancecalr">
        </ajaxToolkit:ModalPopupExtender>


        <asp:Panel ID="ModalPanel" runat="server" class="table-responsive">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" horizntalAlign="center" BackColor="#273A56" ForeColor="White" Visible="False"
                            Width="192px" Height="24px" Text="Comentarios"></asp:Label>
                        <asp:TextBox ID="txtComentariosLavado" runat="server" TextMode="MultiLine" Width="100%" Visible="false"></asp:TextBox>

                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="OKButton" runat="server" Text="OK" OnClick="OKButton_Click" Width="265px" />
                    </td>
                    <td>
                        <asp:Button ID="CmdCancecalr" runat="server" Text="Cancelar" Width="245px" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="PnlPleca" BorderColor="#273A56" BorderStyle="Solid">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Image runat="server" ID="imgEnca1" ImageUrl="~/IMG/logoheader.png" />
                    </td>
                    <td>
                        <asp:Label ID="LblEnca" runat="server" Font-Bold="true" Font-Size="Larger" ForeColor="#273A56"
                            Style="font-size: xx-large" Text="Calidad"></asp:Label>
                    </td>
                    <td align="right">
                        <uc1:ctlSalir ID="ctlSalir1" runat="server" />
                        <asp:ImageButton ID="imgRefrescar" runat="server" AlternateText="Refrescar" ImageUrl="img/Refresh.png" Style="" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Menu ID="Menu1" runat="server" DynamicMenuItemStyle-BorderColor="White"
            DynamicHoverStyle-BorderStyle="Solid" Orientation="Horizontal" BorderColor="White"
            BorderStyle="Solid" StaticEnableDefaultPopOutImage="true" OnMenuItemClick="Menu1_MenuItemClick" style="margin-top:2em;Width=25%; height:25%;">
            <Items>
                <asp:MenuItem ImageUrl="~/IMG/CmdGral.jpg" Text=" " Value="0"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/IMG/CmdFinalizados.jpg" Text=" " Value="1"></asp:MenuItem>
            </Items>
        </asp:Menu>

        <div class="container-fluid" style="padding-top:2em;">
            <br />
            <label class="label"  style="color:Black; font-size:30px;padding-top:2em;">Agregar unidad a pruebas de calidad:</label>
            <input name="buscador0" id="buscador0" class="form-control input-sm" type="text" style="color:Black; font-size:15px;margin-top:2em;" />
            <asp:DropDownList ID="cboVehiculo" runat="server" CssClass="form-control input-sm" style="color:Black; font-size:15px;margin-top:2em;"></asp:DropDownList>            
            <asp:ImageButton runat="server" ID="imgAgregar" ImageUrl="img/aceptar.png" ToolTip="Iniciar"
                Width="2%" Height="2%"  />           
        </div>

        <div style="width:50%; padding-bottom:2em;">       
            <label class="label"  style="color:Black; font-size:30px;">Buscar:</label>
            <input name="buscador" id="buscador" style="width:300px; height:30px;" />         
        </div>

        <div class="container-fluid">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="Tab1" runat="server">
            <div class="table-responsive">
                <table class="table-responsive" align="center">

                    <tr valign="top" class="table-responsive" style="width:100%;">
                        <td class="table-responsive" style="width: 100%">
                            <table class="table-responsive">
                                <tr class="table-responsive" style="width:100%; padding-top:2em" align="center">
                                    <td class="table-responsive" style="width:100%;">
                                        <asp:DataGrid ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                                            Height="100%" AllowPaging="fALSE" BackColor="White" ForeColor="Black" CssClass="table-responsive">
                                            <HeaderStyle BackColor="#273A56" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundColumn DataField="id" HeaderText="idItem" ReadOnly="True"
                                                    Visible="False">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="noorden" HeaderText="Orden"
                                                    Visible="true" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="noplacas" HeaderText="Placas" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="vehiculo" HeaderText="Modelo"
                                                    Visible="true" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="color" HeaderText="Color" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="tecnico" HeaderText="Tecnico"
                                                    Visible="true" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="servicio" HeaderText="Descripcion"
                                                    ReadOnly="True" Visible="true">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="usuario" HeaderText="Usuario" Visible="false" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="fecha_Hora_ini" HeaderText="Inicio"
                                                    Visible="False" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Fecha_hora_fin" HeaderText="Hora"
                                                    ReadOnly="True" Visible="true">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="id_hd" HeaderText=""
                                                    ReadOnly="True" Visible="false">

                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="comentarios" HeaderText="Observaciones"
                                                    ReadOnly="True" Visible="true">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="status" HeaderText="Estatus"
                                                    ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Modificar">
                                                    <ItemTemplate>
                                                        <table class="table" style="text-align:center;">
                                                            <tr>
                                                                <td>
                                                                    <asp:ImageButton runat="server" ID="ImgIniciar" ImageUrl="~/IMG/Verde.JPG" ToolTip="Iniciar"
                                                                        OnClick="ImgIniciar_Click" Width="40px" Height="40px" />
                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton runat="server" ID="ImageFin" ImageUrl="~/IMG/AZUL.JPG" ToolTip="Prueba OK"
                                                                        OnClick="ImgFinalizar_Click" Width="40px" Height="40px" />

                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton runat="server" ID="ImageNOOK" ImageUrl="~/IMG/Rojo.JPG" ToolTip="Prueba Fallo"
                                                                        OnClick="ImgFallo_Click" Width="40px" Height="40px" />

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label runat="server" ID="LblINIC" Text="Iniciar Prueba"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="LblFinic" Text="Prueba OK"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label1" Text="Prueba Fallo"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                            </Columns>

                                            <SelectedItemStyle BackColor="LightGray" />
                                        </asp:DataGrid>
                                    </td>
                                    <td class="style1"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </div> 
            </asp:View>
            <asp:View ID="Tab2" runat="server">
                <table cellpadding="0" cellspacing="0">
                    <tr valign="top">
                        <td>
                            <asp:Panel runat="server" ID="PnlFinish" BorderColor="Silver" BorderStyle="Solid">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="LblGVFinish" Text="Atendidos/Finalizados" ForeColor="Silver"
                                                Font-Size="Large" Font-Bold="true">      
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="LblLAvadoresFinish" Text="Lavador:" ForeColor="Silver"
                                                            BorderColor="Silver" BorderStyle="Solid" Width="113px"></asp:Label>
                                                    </td>

                                                    <td>de:<asp:TextBox ID="txtFec1" runat="server"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender runat="server" ID="txtFec1Ex" TargetControlID="txtFec1" Format="dd/MM/yyyy" PopupButtonID="txtFec1"></ajaxToolkit:CalendarExtender>

                                                    </td>
                                                    <td>al:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtFec2" runat="server"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender runat="server" ID="txtFec2Ex" TargetControlID="txtFec2" Format="dd/MM/yyyy" PopupButtonID="txtFec2"></ajaxToolkit:CalendarExtender>
                                                        <asp:Button ID="CmdBuscarLavadorFinish" runat="server" BackColor="#BDB1B1"
                                                            BorderColor="#273A56" ForeColor="#273A56" Text="Filtrar" Width="216px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataGrid runat="server" ID="GvFinish" AutoGenerateColumns="False" BackColor="White"
                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="1239px" CssClass="CSSTableGenerator">
                                                <Columns>
                                                    <asp:BoundColumn DataField="id" HeaderText="idItem" ReadOnly="True"
                                                        Visible="False">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="noorden" HeaderText="Orden"
                                                        Visible="true" ReadOnly="True">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="noplacas" HeaderText="Placas" ReadOnly="True">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="vehiculo" HeaderText="Modelo"
                                                        Visible="true" ReadOnly="True">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="color" HeaderText="Color" ReadOnly="True" Visible="true">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Tecnico" HeaderText="Tecnico"
                                                        Visible="true" ReadOnly="True">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="vehiculo" HeaderText="Vehiculo"
                                                        ReadOnly="True" Visible="false">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundColumn>

                                                    <asp:BoundColumn DataField="fecha" HeaderText="Fecha"
                                                        Visible="true" ReadOnly="True">
                                                        <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Fecha_hora_fin" HeaderText="Hora Fin"
                                                        ReadOnly="True" Visible="true">
                                                        <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="id_hd" HeaderText=""
                                                        ReadOnly="True" Visible="false">
                                                        <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="usuario" HeaderText="Usuario"
                                                        ReadOnly="True">
                                                        <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="status" HeaderText="Estatus"
                                                        ReadOnly="True" Visible="true">
                                                        <ItemStyle HorizontalAlign="Center" Width="180px" />

                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="comentarios" HeaderText="Comentarios"
                                                        Visible="true" ReadOnly="True"></asp:BoundColumn>

                                                    <asp:TemplateColumn HeaderText="" Visible="true">
                                                        <ItemTemplate>
                                                            <table style="width: 0px; height: 0px;">
                                                                <tr>
                                                                    <td></td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>


                                                </Columns>
                                                <SelectedItemStyle BackColor="LightGray" />
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        </div>
        <asp:TextBox ID="TextBox3" runat="server" Height="1px" Style="z-index: 108; left: 536px; position: absolute; top: 2168px"
            Width="1px">
        </asp:TextBox>
    </form>
</body>
</html>
