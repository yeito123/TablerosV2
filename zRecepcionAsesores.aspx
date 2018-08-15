<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="zRecepcionAsesores.aspx.vb" Inherits="TablerosV2.zRecepcionAsesores" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link rel="stylesheet" href="css/generales.css" />
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
            font-weight: bold ;
        }
    </style>
    
          <script type="text/javascript">
              function PostBScript() {


                  __doPostBack('cmdGuardar', '');
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
        <td><asp:Label ID="serieTorre" runat="server"   Font-Bold="True" Font-Names="arial"
                Font-Size="12px" 
                Text=""  Visible="false"/>Placas: <asp:Label ID="LBLPLACAS" runat="server"   Font-Bold="True" Font-Names="arial"
                Font-Size="12px" 
                Text="" ></asp:Label> </td>
        <td>Cita: <asp:Label ID="LBLORDEN" runat="server"   Font-Bold="True" Font-Names="arial"
                Font-Size="12px" 
                Text="" ></asp:Label> </td>
        <td colspan="2">VIN:
         <asp:Label ID="LBLVIN" runat="server"   Font-Bold="True" Font-Names="arial"
                Font-Size="12px" 
                Text="" ></asp:Label>
        </td>
      
        </tr>
           
        <tr>
        <td colspan="1" align="left">
             <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="false" runat="server" 
                RepeatDirection="Horizontal" >
                <asp:ListItem Value="Normal"  Selected="true">Lavar al final</asp:ListItem>
                 <asp:ListItem Value="Previo">Lavar Primero</asp:ListItem>
                <asp:ListItem Value="No Lavado">Sin Lavado</asp:ListItem>
                
            </asp:RadioButtonList>
            <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="false" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Value="Sencillo"  Selected="true">Lavado Sencillo</asp:ListItem>
                <asp:ListItem Value="Motor">Lavado Motor</asp:ListItem>
                 
            </asp:RadioButtonList>
            </td>
       <td>No. Torre :  <asp:TextBox ID="txtTorre" runat="server"></asp:TextBox>  
            </td>
       <td>Fecha Promesa:
           <asp:TextBox ID="txtFPromesa" Width="150px" runat="server"></asp:TextBox>
            <ajaxToolkit:CalendarExtender runat="server"   id="txtFPromesaex" OnClientDateSelectionChanged="dateselect" Format="dd/MM/yyyy hh:mm:ss" TargetControlID="txtFPromesa"  PopupButtonID="txtFPromesa"></ajaxToolkit:CalendarExtender>

           <asp:Button ID="cmdCancelar" runat="server" style="display:none;" Text="Cancelar" />
            </td>
            <td>Orden:  <asp:TextBox ID="txtOrden"  runat="server"></asp:TextBox>  
            </td>
      
        </tr>
           
            <tr>
                <td colspan=4 align="center">
                           <div id="divServiciosH"   runat="server" style=" text-align:center; display:block;">
           
           
                               <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" />
           
           
             </div></td></tr></table></asp:Panel></asp:panel>
        <table style="width: 99%;">
        
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
                                            Font-Underline="False"     width="900px"
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
