<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="zRecepcionAsesoresC.aspx.vb" Inherits="TablerosV2.zRecepcionAsesoresC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link rel="stylesheet" href="css/generales.css" />
    <%--<link rel="stylesheet" href="anytime.css" />
    <script src="js/jquery.js"></script>
    <script src="js/anytime.js"></script>--%>
      <script  type="text/javascript" src="js/jquery-1.9.1.js"></script>
     <script type="text/javascript" src="js/jquery-ui.js"></script>  
    <script type="text/javascript" src="JS/JavaScriptRecepcionSeguimiento.js"></script>

    <style type="text/css">
    html{     }
   
         .cssMPGVPop
        {
            
            text-align: center;
            vertical-align: top;
            font-size: 12px;
            font-family: arial;
            margin:0px;padding:0px;
            background-color:#bbbbea;
	 
	width:100%;
	box-shadow: 10px 10px 5px #888888;
	border:1px solid #010028;
	
	-moz-border-radius-bottomleft:6px;
	-webkit-border-bottom-left-radius:6px;
	border-bottom-left-radius:6px;
	
	-moz-border-radius-bottomright:6px;
	-webkit-border-bottom-right-radius:6px;
	border-bottom-right-radius:6px;
	
	-moz-border-radius-topright:6px;
	-webkit-border-top-right-radius:6px;
	border-top-right-radius:6px;
	
	-moz-border-radius-topleft:6px;
	-webkit-border-top-left-radius:6px;
	border-top-left-radius:6px;
           
	 
        }
        .cssDefault
        {
            width: 97%;
            font-size: 16px;
        }
        .cssLink
        {
            color: #A8BBCE;
        }
        .cssImg
        {
            width: 21px;
            display: block;
        }
        .cssImgHdd
        {
            width: 21px;
            display: none;
        }
         .grd{width:100%;}
        .GrdOver
        {
            height: 250px;
             overflow:auto;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
        }
        .GrdOver2
        {
       overflow:auto;
            height: 300px;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
            
        }
        .GrdOver2b
        {
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
            font-weight: ;
        }
        .GrdOver3
        {
             
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
        .GrdOver4
        {
            border: 0px solid #009BC7;            
            color: Black;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 18px;
            font-weight: bold;
        }
       
          .GrdOver5
        {
            overflow:auto;
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
            font-weight: bold ;
        }
          
.resaltar{background-color:#FF0;}
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

              function PostBScript() {


                  __doPostBack('cmdGuardar', '');
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
                     
                    
                      $('#dgLibres span').removeClass('resaltar');
                      if (jQuery.trim(buscar) != '') {
                          $("#dgLibres span:icontains('" + buscar + "')").addClass('resaltar');
                      }
                      $('#dg1 span').removeClass('resaltar');
                      if (jQuery.trim(buscar) != '') {
                          $("#dg1 span:icontains('" + buscar + "')").addClass('resaltar');
                      }
                  });
              });
    </script>
<%--<meta http-equiv="refresh" content="30" />--%>
</head>
<body> 
    <form id="form1" runat="server">
    
         
            

    
<asp:Label ID="lblIdAsesor" runat="server"></asp:Label>
 <asp:Button ID="cmdServicios" runat="server"  style="display:none;" Text="" />

    
          <table style="width:99%;">
    <tr>
    <td align="left"> <asp:Image ID="Image1" runat="server" ImageUrl="img/agenciaLOGOHeader.png" /></td>
    
    <td align="right"> <asp:ImageButton  ID="imgSalir" runat="server" AlternateText="Salir"  ImageUrl="img/logout.png" /></td>
     
    </tr>
    </table>
    <div>
         <ajaxToolkit:ToolkitScriptManager runat="server" id="ToolkitScriptManager1" 
            EnablePartialRendering="true" AsyncPostBackTimeout="600" />	
            
              <ajaxtoolkit:modalpopupextender id="MPGV" runat="server" backgroundcssclass="watermarked"
            cancelcontrolid="cmdCancelar" dropshadow="false" okcontrolid="cmdGuardar"
            oncancelscript="noneScript()" onokscript="PostBScript()" popupcontrolid="PopupMPGV"
            targetcontrolid="cmdServicios" x="200" y="100" drag="true" popupdraghandlecontrolid="PopupMPGV">
    </ajaxtoolkit:modalpopupextender>
         <asp:panel id="PopupMPGV" runat="server" style="display: block; width: 950px;">
        <asp:Panel ID="PopupDragHandleMPGV" runat="Server" CssClass="cssMPGVPop">
             
              
    
        <table style="width: 95%;"   >
        
        <tr>
        
            <td>No. Torre :  <asp:TextBox ID="txtTorre" runat="server"></asp:TextBox>  
            </td>
      
            <td>Orden:  <asp:TextBox ID="txtOrden"  runat="server"></asp:TextBox>  
            </td>

       
           <td>
           <asp:Button ID="cmdCancelar" runat="server" style="display:none;" Text="Cancelar" />
            </td>
      
        </tr>
           
            <tr>
                <td colspan=2 align="center">
                           <div id="divServiciosH"   runat="server" style=" text-align:center; display:block;">
           
           
                               <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" />
           
           
             </div></td></tr></table></asp:Panel></asp:panel>

        
 <asp:Button runat="server" ID="cmdMPGV2" Style="display: none;" />

          <ajaxToolkit:ModalPopupExtender ID="MPGV2" runat="server"
            BackgroundCssClass="watermarked" CancelControlID="NoButtonMPGV2"
            DropShadow="false" OkControlID="OkButtonMPGV2" OnCancelScript="noneScript()"
            OnOkScript="PostBScript2()" PopupControlID="PopupMPGV2"
            TargetControlID="cmdMPGV2" X="350" Y="120" Drag="true">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="PopupMPGV2" runat="server" Style="display: none; width: 450px;">
            <asp:Panel ID="PopupDragHandleMPGV2" runat="Server" CssClass="cssMPGVPop">
                <div id="divPopupDragHandleMPGV2" runat="server">
                </div>

                <table>


                    <tr>
                        <td>
                            <asp:Label ID="lblOp" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblInf1" runat="server" Visible="false"></asp:Label>
                        </td>
                        <asp:Label ID="lblInf2" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblInf3" runat="server" Visible="false"></asp:Label>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMSG" runat="server" Text=""></asp:Label>

                        </td>

                    </tr>
                </table>
                <table style="width: 100%;">
                    
                    <tr>
                        <td align="center">

                            <asp:Label runat="server" ID="lbllblModfecha" Style="display: none; color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Fecha Entrega:"></asp:Label>


                            <asp:Label runat="server" ID="lbllblModComentarios" Style="display: none; color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Placas:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtModFecha" Style="display: none;"></asp:TextBox>
                              <ajaxToolkit:CalendarExtender runat="server" id="txtModFechaex" TargetControlID="txtModFecha" Format="dd/MM/yyyy hh:mm" PopupButtonID="txtModFecha"></ajaxToolkit:CalendarExtender>
              
                            <asp:TextBox runat="server" ID="txtModComentarios" TextMode="MultiLine" Style="display: none;"></asp:TextBox>
                             

                        </td>
                    </tr>
                    
                </table>
                <p style="text-align: center;">
                    <table>

                        <tr>
                            <td>
                                 
                                
                                <asp:Button ID="OkButtonMPGV2" runat="server" BackColor="#eeeeee"
                                    BorderColor="Black" Font-Bold="True" ForeColor="#000066" Text="Si"
                                    Width="100px" /></td>
                            <td>
                                <asp:Button ID="NoButtonMPGV2" runat="server" BackColor="#eeeeee"
                                    BorderColor="#2F4F4F" Font-Bold="True" ForeColor="#000066" Text="No"
                                    Width="100px" /></td>
                        </tr>
                    </table>
                </p>






            </asp:Panel>
        </asp:Panel>


        <table style="width: 99%;">
            <tr>  <td>   Buscar&nbsp;
                         <input name="buscador" id="buscador" type="text" /> </td></tr>
       
            <tr>
                <td>
  
       
       <h3 >Con Cita</h3>
                    <div class="GrdOver">
                        <asp:DataGrid ID="dg1" runat="server" AutoGenerateColumns="False" ForeColor="#333333"
                             CellPadding="2" GridLines="None" Font-Bold="False" Font-Italic="False"
                            Font-Names="Arial" Font-Overline="False" Font-Size="14px" Font-Strikeout="False"
                            Font-Underline="False"      CssClass="CSSTableGenerator"
                            AllowPaging="false" >
                            <ItemStyle ForeColor="black" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" />
                            <Columns>
                               <asp:BoundColumn DataField="idVehiculo"  HeaderText="Vehiculo"   />  
                                <asp:BoundColumn DataField="VIN" HeaderText="VIN"  /> 
                                      <asp:BoundColumn DataField="noPlacas" HeaderText="Placas"  />                          
                               
                                        <asp:BoundColumn DataField="Cliente" HeaderText="Cliente"  />
                                        <asp:BoundColumn DataField="Vehiculo" HeaderText="Modelo" />
                                         <asp:BoundColumn DataField="YEAR_MODELO" HeaderText="Año" />
                                        <asp:BoundColumn DataField="COLOR" HeaderText="Color" />
                                        <asp:BoundColumn DataField="Asesor" HeaderText="Asesor" />
                                                                       <asp:BoundColumn DataField="HoraAsesor" HeaderText="HoraProgramada"   />
                                                                         <asp:BoundColumn DataField="HoraLlegada" HeaderText="HoraLlegada"   />          
                                        <asp:TemplateColumn HeaderText="Inicio" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkInicio" AutoPostBack="true" Text="" 
                                                    oncheckedchanged="chkInicio_CheckedChanged" Enabled="false"/>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                         <asp:TemplateColumn HeaderText="Fin" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkFin" AutoPostBack="true" Enabled="false" oncheckedchanged="chkFin_CheckedChanged" Text="" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                          
                                         <asp:BoundColumn DataField="HoraIRecepcion" HeaderText="HoraIRecepcion" Visible="false"   />
                                       <asp:BoundColumn DataField="HoraFRecepcion" HeaderText="HoraFRecepcion"   Visible="false" />
                                        <asp:BoundColumn DataField="numcita" HeaderText="numcita"   Visible="false" />
                                 <asp:BoundColumn DataField="id_hd"  Visible="false" />

                                <asp:TemplateColumn>
                                    <ItemTemplate>

                                        <asp:RadioButtonList ID="rdlLavado" AutoPostBack="true" runat="server" 
                RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlLavado_SelectedIndexChanged"  HeaderText="Lavado">
                <asp:ListItem Value="0"  Selected="true">Lavar al final</asp:ListItem>
                 <asp:ListItem Value="1">No lavar al final</asp:ListItem>
                <asp:ListItem Value="00">Lavar ahora (genera una op de lavado)</asp:ListItem>
                
            </asp:RadioButtonList>
                                        </ItemTemplate></asp:TemplateColumn>
                                        <asp:TemplateColumn  HeaderText="Fecha Entrega">
                                    <ItemTemplate>

                                       <table>
                                                        <tr>
                                                             
                                                            <td>
                                                                <asp:LinkButton ID="lnkFecha_Hora_Com" runat="server" OnClick="lnkFecha_Hora_Com_Click"><%# If(Eval("fecha_hora_com").ToString.Trim.Length > 0, Eval("fecha_hora_com"), "ninguno")%></asp:LinkButton></td>
                                                        </tr>
                                                    </table>

                                    </ItemTemplate></asp:TemplateColumn>

                                        <asp:TemplateColumn  HeaderText="Observaciones para Lavado">
                                    <ItemTemplate>

                                        
                                          <table>
                                                        <tr>
                                                             
                                                            <td>
                                                                <asp:LinkButton ID="lnkObservaciones" runat="server" OnClick="lnkObservaciones_Click"><%# If(Eval("comentarioslavado").ToString.Trim.Length > 0, Eval("comentarioslavado"), "ninguno")%></asp:LinkButton></td>
                                                        </tr>
                                                    </table>

                                    </ItemTemplate></asp:TemplateColumn>

                                   
                                        
                                       
                            </Columns>
                            <HeaderStyle BackColor="#999999" ForeColor="Black" Wrap="True" Font-Bold="True" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Font-Size="12" />
                            <FooterStyle BackColor="#003366" Font-Bold="True" ForeColor="White" Font-Italic="False"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#4F7575" Font-Bold="True" ForeColor="White" Font-Italic="False"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                            <PagerStyle Visible="false" />
                            <AlternatingItemStyle BorderColor="White" ForeColor="black" Font-Bold="False" Font-Italic="False"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                        </asp:DataGrid>
                    </div>
                     
    
                </td>
            </tr>
            <tr>
                <td>
                     
                            
                                <div class="GrdOver3">
                                  <h3 >Sin Cita</h3>
                                   
                                   
                                        <asp:DataGrid ID="dgLibres" runat="server" AutoGenerateColumns="False" ForeColor="#333333"
                                            Font-Size="14px" CellPadding="2" GridLines="None" Font-Bold="False" Font-Italic="False"
                                            Font-Names="Arial" Font-Overline="False" Font-Strikeout="False" 
                                            Font-Underline="False"    
                                            AllowPaging="false"    CssClass="CSSTableGenerator">
                                            <ItemStyle ForeColor="black" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                Font-Strikeout="False"  Font-Underline="False" />
                                                 <Columns>
                               <asp:BoundColumn DataField="idVehiculo"  HeaderText="Vehiculo"   />  
                                  <asp:BoundColumn DataField="VIN" HeaderText="VIN" />
                                      <asp:BoundColumn DataField="noPlacas" HeaderText="Placas"  />                          
                               
                                        <asp:BoundColumn DataField="Cliente" HeaderText="Cliente"  />
                                        <asp:BoundColumn DataField="Vehiculo" HeaderText="Modelo" />
                                           <asp:BoundColumn DataField="YEAR_MODELO" HeaderText="Año" />
                                        <asp:BoundColumn DataField="COLOR" HeaderText="Color" />     
                                        
                                            <asp:BoundColumn DataField="Horallegada" HeaderText="HoraLlegada"   />                                   
                                          <asp:BoundColumn DataField="Asesor" HeaderText="Asesor" />                                      
                                        <asp:TemplateColumn HeaderText="Inicio" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkSCInicio" AutoPostBack="true" Text="" 
                                                    Enabled="false" oncheckedchanged="chkSCInicio_CheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                         <asp:TemplateColumn HeaderText="Fin" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkSCFin" AutoPostBack="true"  Enabled="false" oncheckedchanged="chkSCFin_CheckedChanged" Text="" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                         
                                          <asp:BoundColumn DataField="HoraIRecepcion" HeaderText="HoraIRecepcion" Visible="false"   />
                                       <asp:BoundColumn DataField="HoraFRecepcion" HeaderText="HoraFRecepcion"   Visible="false" />
                                         <asp:BoundColumn DataField="id_hd"  Visible="false" />
                            
                                                         <asp:TemplateColumn HeaderText="Lavado">
                                    <ItemTemplate>

                                        <asp:RadioButtonList ID="rdlLavado" AutoPostBack="true" runat="server" 
                RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlLavado_SelectedIndexChanged">
              <asp:ListItem Value="0"  Selected="true">Lavar al final</asp:ListItem>
                 <asp:ListItem Value="1">No lavar al final</asp:ListItem>
                <asp:ListItem Value="00">Lavar ahora (genera una op de lavado)</asp:ListItem>
                
            </asp:RadioButtonList>
                                        </ItemTemplate></asp:TemplateColumn>
                                        <asp:TemplateColumn  HeaderText="Fecha Entrega">
                                    <ItemTemplate>

                                       <table>
                                                        <tr>
                                                             
                                                            <td>
                                                                <asp:LinkButton ID="lnkFecha_Hora_Com" runat="server" OnClick="lnkFecha_Hora_Com_Click"><%# If(Eval("fecha_hora_com").ToString.Trim.Length > 0, Eval("fecha_hora_com"), "ninguno")%></asp:LinkButton></td>
                                                        </tr>
                                                    </table>

                                    </ItemTemplate></asp:TemplateColumn>

                                        <asp:TemplateColumn  HeaderText="Observaciones para Lavado">
                                    <ItemTemplate>

                                        
                                          <table>
                                                        <tr>
                                                             
                                                            <td>
                                                                <asp:LinkButton ID="lnkObservaciones" runat="server" OnClick="lnkObservaciones_Click"><%# If(Eval("comentarioslavado").ToString.Trim.Length > 0, Eval("comentarioslavado"), "ninguno")%></asp:LinkButton></td>
                                                        </tr>
                                                    </table>

                                    </ItemTemplate></asp:TemplateColumn>

                            
                                                                
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
    </form>
</body>
</html>
