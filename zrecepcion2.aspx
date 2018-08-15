<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="zrecepcion2.aspx.vb" Inherits="TablerosV2.zrecepcion2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="css/generales.css" />
       <script  type="text/javascript" src="js/jquery-1.9.1.js"></script>
     <script type="text/javascript" src="js/jquery-ui.js"></script>   
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

        .DivNuevo {
            width: 100%;
            display: none;
            z-index: 1000;
            position: absolute;
            top: 0;
            background-color: white;
        }

        .DivInfoAD {
            display: block;
            overflow: no-display;
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
            background-color:#bdcde5;
            font-size:15px;
            font-family:Calibri;
           
            width:500px;


        }
        
.resaltar{background-color:#FF0;}
 
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
            $('#buscador').keyup(function () {
                buscar = $(this).val();
                $('#dg1 a').removeClass('resaltar');
                if (jQuery.trim(buscar) != '') {
                    $("#dg1 a:icontains('" + buscar + "')").addClass('resaltar');
                }
                $('#dg2 span').removeClass('resaltar');
                if (jQuery.trim(buscar) != '') {
                    $("#dg2 span:icontains('" + buscar + "')").addClass('resaltar');
                }
            });
        });
    </script>

    <meta http-equiv="refresh" content="180" />
</head>
<body>

    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />
        
        <div>
<table style="width:100%;"><tr><td><asp:Image ID="Image1" runat="server" ImageUrl="img/agenciaLOGOHeader.png" /></td>
    <td align="right">

                    <img name="imgNuevo" style="cursor: auto; width: 34px;" src="img/Add_32x32.png"
                        alt="Nuevo" onclick="if(document.getElementById('divNuevo').style.display=='none'){document.getElementById('divNuevo').style.display='block';}else{document.getElementById('divNuevo').style.display='none';}" />
        <asp:ImageButton ID="imgSalir" runat="server" AlternateText="Salir" ImageUrl="img/logout.png" />
                        </td>
    </tr><tr><td>
                         <asp:Menu ID="Menu1"   runat="server" DynamicMenuItemStyle-BorderColor="White"
        DynamicHoverStyle-BorderStyle="Solid" Orientation="Horizontal" 
                StaticEnableDefaultPopOutImage="False" OnMenuItemClick="Menu1_MenuItemClick" 
                DynamicHorizontalOffset="2"  ForeColor="#284E98" 
                StaticSubMenuIndent="10px"  CssClass="clsInterfazMenu">
             <StaticSelectedStyle BackColor="#507CD1" />
             <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
<DynamicHoverStyle BorderStyle="Solid" BackColor="#284E98" ForeColor="White"></DynamicHoverStyle>

             <DynamicMenuStyle BackColor="#B5C7DE" />
             <DynamicSelectedStyle BackColor="#507CD1" />

<DynamicMenuItemStyle BorderColor="White" HorizontalPadding="5px" VerticalPadding="2px"></DynamicMenuItemStyle>
             <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
        <Items>
            <asp:MenuItem   Text="Anteriores" Value="0"></asp:MenuItem>
            <asp:MenuItem   Text="De Hoy" Value="1"></asp:MenuItem>
            <asp:MenuItem   Selectable="false"></asp:MenuItem>
            
              
        </Items> 

                      

                              
                             
                            
                           
    </asp:Menu>
                         
                    </td>
        <td>   Buscar&nbsp;
                         <input name="buscador" id="buscador" type="text" /> </td>
    </tr></table>

        </div>

        <div id="divPrn">
            <table style="width: 75%">
                <tr>
                    <td colspan="2">


                        <div id="divNuevo" class="">
                            <table style="width: 99%;">
                                <tr>

                                    <td>VIN
                                    </td>

                                    <td>
                                        <asp:Button runat="server" ID="cmdBuscaPlacas" Style="display: none;" />
                                        <asp:TextBox ID="txtPlacas" runat="server" Visible="true"
                                            CssClass="txtM" Height="22px" Width="227px" Font-Size="15px"
                                            Font-Bold="True"></asp:TextBox>

                                    </td>


                                    <td>Vehiculo
                                    </td>

                                    <td>
                                        <asp:DropDownList ID="cboVehiculo" runat="server" Font-Size="15px" Font-Bold="True">
                                        </asp:DropDownList>
                                    </td>

                                    <td>Color
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboColor" runat="server" Font-Size="15px"
                                            Font-Bold="True">
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
                                    </td>
                                    <td>Torre
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTorre2" runat="server" Visible="true"
                                            CssClass="txtM" Height="22px" Width="227px" Font-Size="15px"
                                            Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        Asesor
                                        <asp:DropDownList ID="cboAsesor" runat="server" Font-Size="15px" Font-Bold="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td>

                                        <asp:ImageButton ID="imgNuevoOK" runat="server" BackColor="#F4F4F4" ImageUrl="img/aceptar.png"
                                            ToolTip="Nuevo" />
                                    </td>
                                </tr>
                            </table>

                        </div>

                    &nbsp;</td></tr></table></div>
        
        <div>
 <asp:Button runat="server" ID="cmdMPGV" Style="display: none;" />

        <ajaxToolkit:ModalPopupExtender ID="MPGV" runat="server"
            BackgroundCssClass="watermarked" CancelControlID="NoButtonMPGV"
            DropShadow="false" OkControlID="OkButtonMPGV" OnCancelScript="noneScript()"
            OnOkScript="PostBScript()" PopupControlID="PopupMPGV"
            TargetControlID="cmdMPGV" X="350" Y="120" Drag="true">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="PopupMPGV" runat="server" Style="display: none; width: 450px;">
            <asp:Panel ID="PopupDragHandleMPGV" runat="Server" CssClass="cssMPGVPop">
                <div id="divPopupDragHandleMPGV" runat="server">
                </div>

                <table>


                    <tr>
                        <td>
                            <asp:Label ID="lblOp" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblInf1" runat="server" Visible="false"></asp:Label>                        
                        <asp:Label ID="lblInf2" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblInf3" runat="server" Visible="false"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMSG" runat="server" Text=""></asp:Label>

                        </td>

                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2">

                            <asp:Label runat="server" ID="lblModCliente"  Visible="false" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Cliente" ></asp:Label>
                            <asp:Label runat="server" ID="lblTorre"  Visible="false" Style=" color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Torre:"></asp:Label> 
                           <asp:Label runat="server" ID="lblModfecha"  Visible="false" Style="  color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Fecha Entrega:"></asp:Label>
                            <asp:Label runat="server" ID="lblModPlacas"   Visible="false" Style="  color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="VIN:"></asp:Label>
                            <asp:Label runat="server" ID="lblModVehiculo"  Visible="false" Style="  color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="VIN:"></asp:Label>
                             <asp:Label runat="server" ID="lblEliminar"  Visible="false" Style="  color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Confirma eliminar este registro"></asp:Label>
                       
 

                        </td>
                    </tr>
                    <tr>
                        <td align="center">

                          
                            <asp:TextBox runat="server" ID="txtModFecha"  ></asp:TextBox>
                              <ajaxToolkit:CalendarExtender runat="server" id="txtModFechaex" TargetControlID="txtModFecha" Format="dd/MM/yyyy hh:mm" PopupButtonID="txtModFecha"></ajaxToolkit:CalendarExtender>
                <asp:TextBox runat="server" ID="txtTorre"  ></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtModPlacas" ></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtModCliente"  ></asp:TextBox>
                             <asp:DropDownList ID="cboModVehiculo" runat="server" Font-Size="15px" Font-Bold="True"  >
                                        </asp:DropDownList>

                        </td>
                    </tr>
                     
                    
                </table>
                
                    <table>

                        <tr>
                            <td>
                                <asp:ImageButton ID="imgokDdModPlacas" runat="server" ImageUrl="img/aceptar.png"
                                    ToolTip="OK" Style="display: none; width: 20px;" />
                                <asp:Button ID="imgokModPlacas" runat="server" BackColor="#eeeeee"
                                    BorderColor="#2F4F4F" Font-Bold="True" ForeColor="#000066" Text="Guardar placa y recibir"
                                    Width="165px" Style="display: none;" />
                                
                                <asp:Button ID="OkButtonMPGV" runat="server" BackColor="#eeeeee"
                                    BorderColor="Black" Font-Bold="True" ForeColor="#000066" Text="Si"
                                    Width="100px" /></td>
                            <td>
                                <asp:Button ID="NoButtonMPGV" runat="server" BackColor="#eeeeee"
                                    BorderColor="#2F4F4F" Font-Bold="True" ForeColor="#000066" Text="No"
                                    Width="100px" /></td>
                        </tr>
                    </table>
                






            </asp:Panel>
        </asp:Panel>

        </div>

       


        <div>

 <table style="width: 97%;">
            <tr>
                <td align="left">

                    <table style="width: 100%;">
                        <tr>
                            <td valign="top">
 
                                <div>
                                    <asp:DataGrid ID="dg1" runat="server" AutoGenerateColumns="False" Font-Size="12px"
                                        Font-Bold="False" Font-Italic="False" Font-Names="Arial Rounded MT Bold" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False" CssClass="CSSTableGenerator" Width="850px">
                                        <ItemStyle Font-Size="15px" />
                                        <Columns>
                                            <asp:TemplateColumn HeaderText="VIN" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                             <td>
                                                                <asp:ImageButton ID="imgDelete" runat="server" AlternateText="Eliminar" OnClick="imgDelete_Click" ImageUrl="img/Delete_32x32.png" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblIdVehiculo" runat="server" Text='<%# Eval("idVehiculo") %>'></asp:Label></td>
                                                            <td>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><%# Eval("VIN")%></asp:LinkButton></td>
                                                        </tr>
                                                    </table>


                                                </ItemTemplate>

                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn DataField="vin" HeaderText="VIN" Visible="false" />
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
                                            <asp:BoundColumn DataField="HoraAsesor" HeaderText="Hora Cita" />
                                            <asp:BoundColumn DataField="Asesor" Visible="true" HeaderText="Asesor" />

                                            <asp:TemplateColumn HeaderText="Recibir" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chkRecibido" AutoPostBack="true" Text=""
                                                        OnCheckedChanged="chkRecibido_CheckedChanged" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateColumn>

                                            <asp:BoundColumn DataField="Horallegada" HeaderText="HoraLlegada" />
                                            <asp:TemplateColumn HeaderText="Salida" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chkEntrega" AutoPostBack="true" Text=""
                                                        OnCheckedChanged="chkEntrega_CheckedChanged" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateColumn>

                                            <asp:BoundColumn DataField="HoraRetiro" HeaderText="HoraRetiro" />
                                            <asp:BoundColumn DataField="colorPrisma" Visible="false" HeaderText="Torre" />
                                            <asp:BoundColumn DataField="cCita" Visible="true" HeaderText="Con cita" />
                                            <asp:BoundColumn DataField="vin" Visible="true" HeaderText="vin" />
                                            <asp:BoundColumn DataField="numcita" Visible="true" HeaderText="numcita" />
                                            <asp:BoundColumn DataField="fecha_hora_Com" Visible="false" HeaderText="Fecha Entrega" />
                                             <asp:BoundColumn DataField="idve" Visible="false" HeaderText="id_hd" />
                                             <asp:TemplateColumn HeaderText="Torre">
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



                                        </Columns>
                                        <HeaderStyle Wrap="True" Font-Size="15" />
                                        <FooterStyle HorizontalAlign="Right" />
                                        <AlternatingItemStyle BorderColor="White" />
                                        <PagerStyle BackColor="#4E1414" ForeColor="White" HorizontalAlign="Center"
                                            Mode="NumericPages" NextPageText="" PrevPageText="" />
                                    </asp:DataGrid>
                                </div>

                            </td>
                            <td valign="top">
                              
                                <div>
                                    <asp:DataGrid ID="dg2" runat="server" AutoGenerateColumns="False" Font-Size="12px"
                                        Font-Bold="False" Font-Italic="False"
                                        Font-Names="Arial Rounded MT Bold" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False"
                                        CssClass="CSSTableGenerator" Width="400px">
                                        <ItemStyle Font-Size="15px" />
                                        <Columns>
                                             <asp:TemplateColumn HeaderText="VIN" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblNoPacas" runat="server" Text='<%# Eval("vin")%>'></asp:Label></td>
                                                           
                                                        </tr>
                                                    </table>


                                                </ItemTemplate>

                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:TemplateColumn>
                                            <%--<asp:BoundColumn DataField="NOPlacas" HeaderText="Placas" />--%>

                                            <asp:BoundColumn DataField="Cliente" HeaderText="Cliente" />
                                            <asp:BoundColumn DataField="Vehiculo" HeaderText="Modelo" />
                                            <%-- <asp:BoundColumn DataField="COLOR" HeaderText="Color" />--%>

                                            <asp:TemplateColumn HeaderText="Salida" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chkEntregaAnt" AutoPostBack="true" Text=""
                                                        OnCheckedChanged="chkEntrega2_CheckedChanged" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateColumn>

                                            <asp:BoundColumn DataField="HoraRetiro" HeaderText="HoraRetiro" />

                                            <asp:BoundColumn DataField="cCita" Visible="false" />
                                            <asp:BoundColumn DataField="id_hd" Visible="false" />




                                        </Columns>
                                        <HeaderStyle Wrap="True" Font-Size="15" />
                                        <FooterStyle HorizontalAlign="Right" />
                                        <AlternatingItemStyle BorderColor="White" />
                                        <PagerStyle BackColor="#4E1414" ForeColor="White" HorizontalAlign="Center"
                                            Mode="NumericPages" NextPageText="" PrevPageText="" />
                                    </asp:DataGrid>
                                </div>
                            </td>
                        </tr>
                    </table>

                </td>
                <td align="right" colspan="2" valign="top">
                    &nbsp;</td>
                <td align="right" valign="top">
                    &nbsp;</td>

            </tr>
        </table>
        </div>
       


    </form>
</body>
</html>
