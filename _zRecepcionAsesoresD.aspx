<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="_zRecepcionAsesoresD.aspx.vb" Inherits="TablerosV2._zRecepcionAsesoresD" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="Controles/ctlResumen.ascx" TagName="ctlResumen" TagPrefix="uc1" %>
<%@ Register Src="Controles/ctlSalir.ascx" TagName="ctlSalir" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>Recepción de vehículos</title>
    <link rel="stylesheet" href="css/generales.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
   
    
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
    <script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="JS/JavaScriptRecepcionSeguimiento.js"></script>

    <style type="text/css">
        html {
        }



        .cssDefault {
            width: 97%;
            font-size: 16px;
        }

        .cssLink {
            color: #A8BBCE;
        }

        .cssImg {
            width: 21px;
            display: block;
        }

        .cssImgHdd {
            width: 21px;
            display: none;
        }

        .grd {
            width: 100%;
        }

        .GrdOver {
            height: 250px;
            overflow: auto;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
        }

        .GrdOver2 {
            overflow: auto;
            height: 300px;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
        }

        .GrdOver2b {
            height: 0px;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
            color: White;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 16px;
            font-weight:;
        }

        .GrdOver3 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 18px;
            font-weight: bold;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
        }

        .GrdOver4 {
            border: 0px solid #009BC7;
            color: Black;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 18px;
            font-weight: bold;
        }

        .GrdOver5 {
            overflow: auto;
            height: 75px;
            width: 902px;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
            color: White;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 16px;
            font-weight: bold;
        }


        .resaltar {
            background-color: #FF0;
        }
    </style>
    <%-- <script>
        AnyTime.picker("txtModFecha",
          { format: "%W, %M %D in the Year %z %E", firstDOW: 1 });
        $("#txtModFecha").AnyTime_picker(
          {
              format: "%H:%i", labelTitle: "Hora",
              labelHour: "Hora", labelMinute: "Minuto"
          });
  </script>--%>
    <script type="text/javascript">
        function calendarShown(sender, args) {
            sender._popupBehavior._element.style.zIndex = 10005;
        }
        
        function PostBScript() {


            __doPostBack('OkButtonMPGV', '');
            // Preload(false, 'divloader', 'divprn');
            // window.opener.PostB();

            //window.close();

        }

        function noneScript() {
            //        var obj = document.getElementById('divInfoAD');
            //        obj.style.display = 'none';
            // Preload(false, 'divloader', 'divprn');
        }
        function Location(sDiv) {

            document.getElementById("cmdServicios").fireEvent("onclick", "");

        }
        function dateselect(ev) {
            var calendarBehavior1 = $find("txtFPromesaex");
            var d = calendarBehavior1._selectedDate;
            var now = new Date();
            calendarBehavior1.get_element().value = d.format("dd/MM/yyyy") + " " + now.format("HH:mm:ss")
        }

        $.expr[':'].icontains = function (obj, index, meta, stack) {
            return (obj.textContent || obj.innerText || jQuery(obj).text() || '').toLowerCase().indexOf(meta[3].toLowerCase()) >= 0;
        };


        $(document).ready(function () {
            $('#buscador').keyup(function () {
                buscar = $(this).val();


                var jo1 = $("#dg1").find("tr");
                if (jQuery.trim(buscar) != '') { jo1.parents('tr').hide(); } else { jo1.parents('tr').show(); }
                var jo2 = $("#dgLibres").find("tr");
                if (jQuery.trim(buscar) != '') { jo2.parents('tr').hide(); } else { jo2.parents('tr').show(); }
                $('#dg1 a').removeClass('resaltar');
                if (jQuery.trim(buscar) != '') {
                    $("#dg1 a:icontains('" + buscar + "')").addClass('resaltar');
                    var jo = $("#dg1 a:icontains('" + buscar + "')").parents('tr');
                    jo.show();
                }
                $('#dgLibres a').removeClass('resaltar');
                if (jQuery.trim(buscar) != '') {
                    $("#dgLibres a:icontains('" + buscar + "')").addClass('resaltar');
                    var jo = $("#dgLibres a:icontains('" + buscar + "')").parents('tr');
                    jo.show();
                }
            });
        });




        //$(document).ready(function () {
        //    $('#buscador').keyup(function () {
        //        buscar = $(this).val();
        //        $('#dg1 a').removeClass('resaltar');
        //        if (jQuery.trim(buscar) != '') {
        //            $("#dg1 a:icontains('" + buscar + "')").addClass('resaltar');

        //            $("#dg1 a:icontains('" + buscar + "')").focus();
        //            $('#buscador').focus()
        //        }
        //        $('#dgLibres a').removeClass('resaltar');
        //        if (jQuery.trim(buscar) != '') {
        //            $("#dgLibres a:icontains('" + buscar + "')").addClass('resaltar');
        //            $("#dgLibres a:icontains('" + buscar + "')").focus();
        //            $('#buscador').focus()
        //        }
        //    });
        //});
    </script>
    <%--<meta http-equiv="refresh" content="30" />--%>
</head>
<body>
    <form id="form1" runat="server">





        <asp:Label ID="lblIdAsesor" runat="server"></asp:Label>
        <asp:Button ID="cmdServicios" runat="server" Style="display: none;" Text="" />


        <table style="width: 99%;">
            <tr>
                <td align="left">
                    <asp:Image ID="Image1" runat="server" ImageUrl="img/agenciaLOGOHeader.png" /></td>

                <td align="left">
                    <uc1:ctlResumen ID="ctlResumen1" runat="server" />
                </td>

                <td align="right">
                    <uc2:ctlSalir ID="ctlSalir1" runat="server" />
                </td>

            </tr>
        </table>
        <div>
            <ajaxToolkit:ToolkitScriptManager runat="server" ID="ToolkitScriptManager1"
                EnablePartialRendering="true" AsyncPostBackTimeout="600" />






            <table style="width: 99%;">
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <h3>Fecha:</h3>
                                    <asp:TextBox ID="txtCalendar" AutoPostBack="true" runat="server" Style="display: block; z-index: 1000;"
                                        Width="200px"
                                        Font-Size="Medium" Font-Bold="False" ForeColor="black" />

                                    <ajaxToolkit:CalendarExtender runat="server" Format="dd/MM/yyyy" OnClientShown="calendarShown"
                                        Animated="true" ID="clCalendarEx" TargetControlID="txtCalendar" PopupPosition="Right"
                                        PopupButtonID="txtCalendar">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td>

                                    <h3>Buscar Placa:</h3>
                                    <input name="buscador" id="buscador" type="text" />
                                </td>
                            </tr>
                        </table>


                    </td>



                </tr>
                <tr>
                    <td>


                        <h3>&nbsp;</h3>
                        <div class="GrdOver">
                            <asp:DataGrid ID="dg1" runat="server" AutoGenerateColumns="False" ForeColor="#333333"
                                CellPadding="2" GridLines="None" Font-Bold="False" Font-Italic="False"
                                Font-Names="Arial" Font-Overline="False" Font-Size="14px" Font-Strikeout="False"
                                Font-Underline="False" CssClass="CSSTableGenerator"
                                AllowPaging="false">
                                <ItemStyle ForeColor="black" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                    Font-Strikeout="False" Font-Underline="False" />
                                <Columns>

                                    <asp:TemplateColumn  >
                                        <ItemTemplate>


                                            <asp:Label ID="lblInfi" runat="server" Text='<%# Eval("id_hd") & "__" & Eval("Cliente") & "__" & Eval("noplacas") & "__" & Eval("VIN") & "__" & Eval("vehiculo") & "__" & Eval("colorprisma") & "__" & Eval("noorden") & "__" & Eval("COMENTARIOSlAVADO") & "__" & Eval("fecha_hora_com") & "__" & If(Eval("horallegada") Is DBNull.Value, "00:00", Eval("horallegada")) & "__" & If(Eval("horaIRecepcion") Is DBNull.Value, "00:00", Eval("horaIRecepcion")) & "__" & If(Eval("horaFRecepcion") Is DBNull.Value, "00:00", Eval("horaFRecepcion"))%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      
                                    <asp:BoundColumn DataField="VIN" HeaderText="VIN" />
                                    <asp:TemplateColumn HeaderText="Placas">
                                        <ItemTemplate>



                                            <asp:LinkButton ID="lnknoPlacas" runat="server" CssClass="btn  btn-info"><%# If(Eval("noplacas").ToString.Trim.Length > 0, Eval("noplacas"), "ninguno")%></asp:LinkButton></td>
                                                     

                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:BoundColumn DataField="Cliente" HeaderText="Cliente" />
                                    <asp:BoundColumn DataField="Vehiculo" HeaderText="Modelo" />
                                    <asp:BoundColumn DataField="YEAR_MODELO" HeaderText="Año" />
                                    <asp:BoundColumn DataField="COLOR" HeaderText="Color" />
                                    <asp:BoundColumn DataField="Asesor" HeaderText="Asesor" />
                                    <asp:BoundColumn DataField="HoraAsesor" HeaderText="Hora Programada" />
                                    <asp:BoundColumn DataField="HoraLlegada" HeaderText="Hora Llegada" />
                                    <asp:TemplateColumn HeaderText="Inicio" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkInicio" AutoPostBack="true" Text=""
                                                OnCheckedChanged="chkInicio_CheckedChanged" Enabled='<%#  Eval("HoraFRecepcion") Is DBNull.Value%>'   Checked='<%# Not Eval("HoraIRecepcion") Is DBNull.Value%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Fin" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkFin" AutoPostBack="true" Enabled='<%#  Not Eval("HoraIRecepcion") Is DBNull.Value%>'   OnCheckedChanged="chkFin_CheckedChanged" Text=""  Checked='<%# Not Eval("HoraFRecepcion") Is DBNull.Value%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                        
                                    <asp:BoundColumn DataField="HoraIRecepcion" HeaderText="Hora IRecepcion" Visible="false" />
                                    <asp:BoundColumn DataField="HoraFRecepcion" HeaderText="Hora FRecepcion" Visible="false" />
                                    <asp:BoundColumn DataField="numcita" HeaderText="numcita" Visible="false" />
                                    <asp:BoundColumn DataField="id_hd" Visible="false" />

                                    <asp:TemplateColumn>
                                        <ItemTemplate>

                                            <asp:RadioButtonList ID="rdlLavado" AutoPostBack="true" runat="server"
                                                RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlLavado_SelectedIndexChanged" HeaderText="Lavado">
                                                <asp:ListItem Value="0" Selected="true">Lavar al final</asp:ListItem>
                                                <asp:ListItem Value="1">No lavar al final</asp:ListItem>
                                                <asp:ListItem Value="00">Lavar ahora (genera una op de lavado)</asp:ListItem>

                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Fecha Entrega">
                                        <ItemTemplate>

                                            <table>
                                                <tr>

                                                    <td>
                                                        <asp:LinkButton ID="lnkFecha_Hora_Com" runat="server" OnClick="lnkFecha_Hora_Com_Click"><%# If(Eval("fecha_hora_com").ToString.Trim.Length > 0, Eval("fecha_hora_com"), "ninguno")%></asp:LinkButton></td>
                                                </tr>
                                            </table>

                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="Observaciones para Lavado">
                                        <ItemTemplate>


                                            <table>
                                                <tr>

                                                    <td>
                                                        <asp:LinkButton ID="lnkObservaciones" runat="server" OnClick="lnkObservaciones_Click"><%# If(Eval("comentarioslavado").ToString.Trim.Length > 0, Eval("comentarioslavado"), "ninguno")%></asp:LinkButton></td>
                                                </tr>
                                            </table>

                                        </ItemTemplate>
                                    </asp:TemplateColumn>




                                </Columns>
                                <HeaderStyle BackColor="#999999" ForeColor="Black" Wrap="True" Font-Bold="True" Font-Italic="False"
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Font-Size="12" />
                                <FooterStyle BackColor="#003366" Font-Bold="True" ForeColor="White" Font-Italic="False"
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                <EditItemStyle BackColor="#999999" />
                                <SelectedItemStyle BackColor="#4F7575" Font-Bold="True" ForeColor="White" Font-Italic="False"
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                <PagerStyle Visible="false" />
                                <AlternatingItemStyle BorderColor="black" ForeColor="black" Font-Bold="False" Font-Italic="False"
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                            </asp:DataGrid>
                        </div>


                    </td>
                </tr>
                <tr>
                    <td>


                        <div class="GrdOver3">
                            <h3>Otros Asesores</h3>


                            <asp:DataGrid ID="dgLibres" runat="server" AutoGenerateColumns="False" ForeColor="#333333"
                                Font-Size="14px" CellPadding="2" GridLines="None" Font-Bold="False" Font-Italic="False"
                                Font-Names="Arial" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False"
                                AllowPaging="false" CssClass="CSSTableGenerator">
                                <ItemStyle ForeColor="black" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                    Font-Strikeout="False" Font-Underline="False" />
                                <Columns>

                                    <asp:TemplateColumn HeaderText="">
                                        <ItemTemplate>


                                            <asp:Label ID="lblInfi" runat="server" Text='<%# Eval("id_hd") & "__" & Eval("Cliente") & "__" & Eval("noplacas") & "__" & Eval("VIN") & "__" & Eval("vehiculo") & "__" & Eval("colorprisma") & "__" & Eval("noorden") & "__" & Eval("COMENTARIOSlAVADO") & "__" & Eval("fecha_hora_com") & "__" & If(Eval("horallegada") Is DBNull.Value, "00:00", Eval("horallegada")) & "__" & If(Eval("horaIRecepcion") Is DBNull.Value, "00:00", Eval("horaIRecepcion")) & "__" & If(Eval("horaFRecepcion") Is DBNull.Value, "00:00", Eval("horaFRecepcion"))%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                     
                                    <asp:BoundColumn DataField="VIN" HeaderText="VIN" />
                                    <asp:TemplateColumn HeaderText="Placas">
                                        <ItemTemplate>

                                            
                                                        <asp:LinkButton ID="lnknoPlacas" runat="server" CssClass="btn  btn-info"><%# If(Eval("noplacas").ToString.Trim.Length > 0, Eval("noplacas"), "ninguno")%></asp:LinkButton></td>
                                                

                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:BoundColumn DataField="Cliente" HeaderText="Cliente" />
                                    <asp:BoundColumn DataField="Vehiculo" HeaderText="Modelo" />
                                    <asp:BoundColumn DataField="YEAR_MODELO" HeaderText="Año" />
                                    <asp:BoundColumn DataField="COLOR" HeaderText="Color" />

                                    <asp:BoundColumn DataField="Horallegada" HeaderText="Hora Llegada" />
                                    <asp:BoundColumn DataField="Asesor" HeaderText="Asesor" />
                                    <asp:TemplateColumn HeaderText="Inicio" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkSCInicio" AutoPostBack="true" Text=""
                                               Enabled='<%#  Eval("HoraFRecepcion") Is DBNull.Value%>'  OnCheckedChanged="chkSCInicio_CheckedChanged" Checked='<%# Not Eval("HoraIRecepcion") Is DBNull.Value%>'  />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Fin" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkSCFin" AutoPostBack="true" Enabled='<%#  Not Eval("HoraIRecepcion") Is DBNull.Value%>' OnCheckedChanged="chkSCFin_CheckedChanged" Text=""  Checked='<%# Not Eval("HoraFRecepcion")  Is dbnull.value%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>

                                    <asp:BoundColumn DataField="HoraIRecepcion" HeaderText="Hora IRecepcion" Visible="false" />
                                    <asp:BoundColumn DataField="HoraFRecepcion" HeaderText="Hora FRecepcion" Visible="false" />
                                    <asp:BoundColumn DataField="id_hd" Visible="false" />

                                    <asp:TemplateColumn HeaderText="Lavado">
                                        <ItemTemplate>

                                            <asp:RadioButtonList ID="rdlLavado" AutoPostBack="true" runat="server"
                                                RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlLavado_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Selected="true">Lavar al final</asp:ListItem>
                                                <asp:ListItem Value="1">No lavar al final</asp:ListItem>
                                                <asp:ListItem Value="00">Lavar ahora (genera una op de lavado)</asp:ListItem>

                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Fecha Entrega">
                                        <ItemTemplate>

                                            <table>
                                                <tr>

                                                    <td>
                                                        <asp:LinkButton ID="lnkFecha_Hora_Com" runat="server" OnClick="lnkFecha_Hora_Com_Click"><%# If(Eval("fecha_hora_com").ToString.Trim.Length > 0, Eval("fecha_hora_com"), "ninguno")%></asp:LinkButton></td>
                                                </tr>
                                            </table>

                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="Observaciones para Lavado">
                                        <ItemTemplate>


                                            <table>
                                                <tr>

                                                    <td>
                                                        <asp:LinkButton ID="lnkObservaciones" runat="server" OnClick="lnkObservaciones_Click"><%# If(Eval("comentarioslavado").ToString.Trim.Length > 0, Eval("comentarioslavado"), "ninguno")%></asp:LinkButton></td>
                                                </tr>
                                            </table>

                                        </ItemTemplate>
                                    </asp:TemplateColumn>



                                </Columns>
                                <HeaderStyle BackColor="#999999" ForeColor="Black" Wrap="True" Font-Bold="True" Font-Italic="False"
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Font-Size="12" />
                                <FooterStyle BackColor="#003366" Font-Bold="True" ForeColor="White" Font-Italic="False"
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                <EditItemStyle BackColor="#999999" />
                                <SelectedItemStyle BackColor="#4F7575" Font-Bold="True" ForeColor="White" Font-Italic="False"
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                <PagerStyle Visible="false" />
                                <AlternatingItemStyle BorderColor="black" ForeColor="black" Font-Bold="False" Font-Italic="False"
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                            </asp:DataGrid>
                        </div>


                    </td>

                </tr>

            </table>
        </div>
        <div>

            <asp:Button runat="server" ID="cmdMPGV" Style="display: none;" />

            <ajaxToolkit:ModalPopupExtender ID="MPGV" runat="server"
                BackgroundCssClass="watermarked" CancelControlID="NoButtonMPGV"
                DropShadow="false" OkControlID="OkButtonMPGV" OnCancelScript="noneScript()"
                OnOkScript="PostBScript()" PopupControlID="PopupMPGV"
                TargetControlID="cmdMPGV" X="350" Y="120" Drag="true">
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



                                    <table id="tblMod" class="table table-striped table-condensed">

                                        <tr>
                                            <td align="center">

                                                <asp:Label runat="server" ID="lblModfecha" Style="  color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Fecha Entrega:"></asp:Label>

                                                    <asp:TextBox runat="server" ID="txtModFecha" Style=" "></asp:TextBox>
                                                 <ajaxToolkit:CalendarExtender runat="server" ID="txtModFechaex" TargetControlID="txtModFecha" Format="dd/MM/yyyy hh:mm" PopupButtonID="txtModFecha"></ajaxToolkit:CalendarExtender>

                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblModComentarios" Style="  color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Comentarios:"></asp:Label>

                                               
                                                <asp:TextBox runat="server" ID="txtModComentarios" TextMode="MultiLine" Style=" "></asp:TextBox>


                                            </td>
                                             <td>
                                                <asp:Label runat="server" ID="lblTorre" Style=" color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Torre:"></asp:Label>

                                               
                                                 <asp:TextBox ID="txtTorre" runat="server"></asp:TextBox>

                                            </td>
                                             <td>
                                                <asp:Label runat="server" ID="lblOrden" Style=" color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Orden:"></asp:Label>

                                               
                                                <asp:TextBox ID="txtOrden" runat="server"></asp:TextBox>

                                            </td>
                                        </tr>
                                       

                                       
                                    </table>
                                </div>


                                <div style="text-align: center;">
                                    <div class="btn-group" style="display: inline-block;">

                                        <asp:Button ID="OkButtonMPGV" runat="server" BackColor="#eeeeee"
                                            BorderColor="Black" Font-Bold="True" ForeColor="#000066" Text="Si"
                                            Width="100px" />
                                        <asp:Button ID="NoButtonMPGV" runat="server" BackColor="#eeeeee"
                                            BorderColor="#2F4F4F" Font-Bold="True" ForeColor="#000066" Text="No"
                                            Width="100px" />


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
