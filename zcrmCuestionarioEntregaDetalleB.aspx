<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="zcrmCuestionarioEntregaDetalleB.aspx.vb" Inherits="TablerosV2.zcrmCuestionarioEntregaDetalleB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Encuesta de Calidad (Servicio)</title>
    <style type="text/css">
        .style1
        {
            width: 745px;
        }
        .style5
        {
            width: 850px;
        }
        .style6
        {
            width: 102px;
        }
        .style7
        {
            width: 106px;
        }
        .style8
        {
            width: 154px;
        }
        .style9
        {
            width: 105px;
        }
        .lstM
        {
            border: 1px solid #460000;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
            scrollbar-face-color: #FFFFFF;
            scrollbar-shadow-color: #D07575;
            scrollbar-highlight-color: #D07575;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #FDFDFE;
            scrollbar-arrow-color: #D07575;
        }
        .txt{
            border: 1px solid #460000;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
        }
        
        .lblErr{
            font-size: 20px;
            color:"#FF0000";
            background-color:#FF0000;            
        }
        .cmd{
          background-color:#ffffff ;
         color:"#4D1111";
           border:solid 1px #000000;
            font-weight:bold;
             font-family:Arial;
             font-size:16px;
          
        }
        .cbo{
            border: 1px solid #460000;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
        }
        .lblTitulo{
            border:none;
            font-family: Arial;
            font-size: 20px;
            font-weight: bold;
             font-variant:small-caps;
            color: #752D17;
        }
        .div2{
         border: 2px inset #460000;
            font-family: Helvetica;
            font-size: 12px;
            font-weight: normal;
        
        }
        div{
          
            font-family: Helvetica;
            font-size: 12px;
            font-weight: normal;
        
        }
        .style10
        {
            width: 684px;
        }
        .style11
        {
            width: 46px;
        }
        .style12
        {
            height: 19px;
            width: 848px;
        }
        .style13
        {
            text-align: center;
            font-weight: bold;
            width: 103px;
            height: 19px;
        }
        .style14
        {
            text-align: center;
            font-weight: bold;
            width: 100px;
            height: 19px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
     <ajaxToolkit:ToolkitScriptManager runat="Server" id="ScriptManager1" />
    <div style="width: 1069px" >
        <asp:Panel runat="server" ID="pNLCT1" Width="1065px" cssclass="div2">
            <table>
                <tr>
                    <td>
                        <asp:Image runat="server" ID="Imglogo1" ImageUrl="~/img/AgenciaLogoHeader.png" />
                    </td>
                    <td class="style1">
                        <asp:Label runat="server" ID="LblTitulo" Text="ENCUESTA DE CALIDAD DE ENTREGA DE VEHICULOS"
                          CssClass="lblTitulo"></asp:Label>
                    </td>
                    <td>
                        
                    <table style="width:100%;">
                        <tr>
                                <td>
                                    <asp:Label ID="lblID" runat="server" Font-Size="10px" Visible="False" ></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgSalir" runat="server" BackColor="#F4F4F4" 
                                        ImageUrl="~/img/Previous_32x32.png" ToolTip="Regresar"  />
                                        </td>
                            </tr>
                            <tr>
                                <td style=" font-weight:bold;">
                                    Fecha
                                </td>
                                <th colspan="2">
                                    <asp:TextBox ID="txtFecha" runat="server" Width="154px" CssClass="txt" Enabled="false"></asp:TextBox>
                                </th>
                            </tr> 
                            <tr>
                                <td style=" font-weight:bold;">
                                    No. Factura</td>
                                <td>
                                    <asp:TextBox ID="txtOrden" runat="server" Width="144px" CssClass="txt" ></asp:TextBox>
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="ImgBtnRef" ImageUrl="~/img/aceptar.png"  />
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                </tr>
            </table>
            <table>
             <tr>
                    <td style=" font-weight:bold;">
                        Nombre Cliente:</td>
                    <td class="style10">
                        <asp:TextBox ID="txtCliente" runat="server" Width="651px"  CssClass="txt" ></asp:TextBox>
                    </td>
                    <td style=" font-weight:bold;" class="style11">
                        Asesor</td>
                    <td valign="bottom">
                        <asp:DropDownList ID="CboAsesor" runat="server"  Width="195px"  CssClass="cbo">
                        </asp:DropDownList>
                       
                    </td>
                </tr>
                <tr>
                    <td style=" font-weight:bold;">
                    Dirección:</td>
                    <td class="style10">
                        <asp:TextBox ID="txtDireccion"  runat="server" Width="651px"  CssClass="txt"  Enabled="false"></asp:TextBox>
                    </td>
                    <td  style=" font-weight:bold;" class="style11">
                        Colonia:</td>
                    <td class="style10">
                        <asp:TextBox ID="txtColonia"  runat="server" Width="195px"  CssClass="txt"  Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style=" font-weight:bold;">
                    Tipo de Auto:</td>
                    <td >
                        <asp:TextBox ID="txtTipoAuto" runat="server" Width="651px"  CssClass="txt"  Enabled="false"></asp:TextBox>
                    </td>
                    <td style=" font-weight:bold;" class="style11">
                    Telefono:</td>
                    <td class="style10">
                        <asp:TextBox ID="txtTelefono" runat="server" Width="195px"  CssClass="txt"  Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style=" font-weight:bold;">
                    C.P.:</td>
                    <td>
                        <asp:TextBox ID="txtCP" runat="server" Width="651px"  CssClass="txt"  Enabled="false"></asp:TextBox>
                    </td>
                    <td style=" font-weight:bold;" class="style11">
                    Correo:</td>
                    <td class="style10">
                        <asp:TextBox ID="txtCorreo"  runat="server" Width="195px"  CssClass="txt" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="PnlPReguntas" CssClass="div2">
            <table>
                <tr>
                    <td style="text-align: left">
                        <asp:Label runat="server" ID="LblLeyenda" Text="E=EXCELENTE <pre style='display:inline'>&#09;</pre> B=BUENO <pre style='display:inline'>&#09;</pre> R=REGULAR <pre style='display:inline'>&#09;</pre> M=MALO <pre style='display:inline'>&#09;</pre> P=PESIMO"
                            Style="text-align: center" Font-Bold="True" Font-Size="14px"></asp:Label>
                    </td>
                </tr>
            </table>
            <table bgcolor="Silver">
                <tr>
                    <td bgcolor="White" class="style12">
                        <asp:Label runat="server" ID="Lblpregunta1" Text="Seleccione la opcion mas acertada."
                            Style="font-weight: 700" Width="825px"></asp:Label>
                    </td>
                   
                </tr>
            </table>
            <table>
                <tr>
                    <td class="style5">
                        <asp:Label runat="server" ID="Lbl12" Text="1.- ¿CLARIDAD EN LA INFORMACION DEL MANEJO TOTAL DE SU UNIDAD?"></asp:Label>
                    </td>
                   
                    <td class="style6" bgcolor="#CCCCCC">
                        <asp:RadioButtonList ID="OPT1" runat="server"  
                                        RepeatDirection="Horizontal" Width="192px">
                                        <asp:ListItem Value="E"></asp:ListItem>
                                        <asp:ListItem Value="B"></asp:ListItem>    
                                         <asp:ListItem Value="R"></asp:ListItem>    
                                          <asp:ListItem Value="M"></asp:ListItem>    
                                           <asp:ListItem Value="P"></asp:ListItem>                                        
                                    </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                <td class="style5">
                        <asp:Label runat="server" ID="Label2" Text="2.- ¿FACILIDADES OTORGADAS PARA LA ENTREGA DE SU AUTO?"></asp:Label>
                    </td>
                    <td class="style5" bgcolor="#CCCCCC">
                        <asp:RadioButtonList ID="OPT2" runat="server"  
                                        RepeatDirection="Horizontal" Width="192px">
                                             <asp:ListItem Value="E"></asp:ListItem>
                                        <asp:ListItem Value="B"></asp:ListItem>    
                                         <asp:ListItem Value="R"></asp:ListItem>    
                                          <asp:ListItem Value="M"></asp:ListItem>    
                                           <asp:ListItem Value="P"></asp:ListItem>                                                
                                    </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label runat="server" ID="Label3" Text="3.-¿ENTREGA DE DOCUMENTACION COMPLETA?"></asp:Label>
                    </td>
                    
                    <td class="style6" bgcolor="#CCCCCC">
                         <asp:RadioButtonList ID="OPT3" runat="server"  
                                        RepeatDirection="Horizontal" Width="192px">
                                             <asp:ListItem Value="E"></asp:ListItem>
                                        <asp:ListItem Value="B"></asp:ListItem>    
                                         <asp:ListItem Value="R"></asp:ListItem>    
                                          <asp:ListItem Value="M"></asp:ListItem>    
                                           <asp:ListItem Value="P"></asp:ListItem>                                        
                                    </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label runat="server" ID="Label4" Text="4.- ¿AGILIDAD EN EL TRAMITE DE COMPRA?"></asp:Label>
                    </td>
                     
                    <td class="style6" bgcolor="#CCCCCC">
                       <asp:RadioButtonList ID="OPT4" runat="server"  
                                        RepeatDirection="Horizontal" Width="192px">
                                               <asp:ListItem Value="E"></asp:ListItem>
                                        <asp:ListItem Value="B"></asp:ListItem>    
                                         <asp:ListItem Value="R"></asp:ListItem>    
                                          <asp:ListItem Value="M"></asp:ListItem>    
                                           <asp:ListItem Value="P"></asp:ListItem>                                 
                                    </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label runat="server" ID="Label5" Text="5.- ¿EL AUTO ESTUVO LISTO A LA HORA CONVENIDA?"></asp:Label>
                    </td>
                     
                    <td class="style6" bgcolor="#CCCCCC">
                       <asp:RadioButtonList ID="OPT5" runat="server"  
                                        RepeatDirection="Horizontal" Width="192px">
                                             <asp:ListItem Value="E"></asp:ListItem>
                                        <asp:ListItem Value="B"></asp:ListItem>    
                                         <asp:ListItem Value="R"></asp:ListItem>    
                                          <asp:ListItem Value="M"></asp:ListItem>    
                                           <asp:ListItem Value="P"></asp:ListItem>                 
                                    </asp:RadioButtonList>
                    </td>
                </tr>
                
                 
                
                <tr>
                <td>
                       <asp:Label runat="server" ID="Label28" Text="SUGERENCIAS"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:TextBox runat="server" ID="TXT10" Width="825px" Height="58px" CssClass="lstM" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                
                </tr>
                 
                 
                </table>
                <asp:Panel ID="pnlAdicionales" runat="server">
                
                <table>
                
                            
                    
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblObservacionesSeg" Text="Observaciones Seguimiento"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtObservacionesSeg" Width="825px" Height="30px" CssClass="lstM" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                    <td>
                        <asp:Label runat="server" ID="lblObservacionesGer" Text="Observaciones Gerencia"></asp:Label>
                    </td>
                </tr>
              
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtObservacionesGer" Width="825px" Height="30px" CssClass="lstM" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>     
                <tr>
                <td>  
        
                                        
                                      
                                        
                                         
                                        </td>
                                        
                                    </tr>
                
                </table>
                </asp:Panel>
                
                   <asp:Panel ID="pnlFooter" runat="server" HorizontalAlign="Center">
                <table>
                <tr><td>   &nbsp;</td></tr>
                <tr><td style=" font-weight:bold;"> Muchas Gracias</td></tr>
                <tr><td>   &nbsp;</td></tr>
                <tr><td style=" font-weight:bold;"> Atentamente</td></tr>
                <tr><td>   &nbsp;</td></tr>
                <tr><td style=" font-weight:bold;"> Gerencia de Servicio</td></tr>
                <tr><td style=" font-weight:bold;"> Mazda</td></tr>
                <tr><td>   &nbsp;</td></tr>
               
               
            </table>
            </asp:Panel>
        </asp:Panel>
        
         <asp:Panel ID="pnlGuardar" runat="server" HorizontalAlign="Center">
                 
                
                 
                          <table>
                   <tr>
                     <td>  <asp:Label runat="server" ID="lblEstatusLlamada" Text="Estatus"></asp:Label>
                            <asp:DropDownList ID="cboEstatusLlamada" runat="server" Font-Size="11px"   Width="150px">
                               <asp:ListItem Text="--" Value=""></asp:ListItem>
                                <asp:ListItem Text="Contactado" Value="Contactado"></asp:ListItem>
                                <asp:ListItem Text="Recado" Value="Recado"></asp:ListItem>
                                <asp:ListItem Text="Mensaje de texto" Value="Mensaje de texto"></asp:ListItem>
                                <asp:ListItem Text="Volver a llamar" Value="Volver a llamar"></asp:ListItem>
                                <asp:ListItem Text="No contactado" Value="No contactado"></asp:ListItem>
                                 <asp:ListItem Text="No autoriza llamada" Value="No autoriza llamada"></asp:ListItem>
                            </asp:DropDownList>
                                           </td>
                                        <td align="center">  <asp:TextBox ID="txtFechaEstatus" runat="server" Visible="true" ReadOnly="true" CssClass="cboM"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender runat="server" id="txtFechaEstatusEx" TargetControlID="txtFechaEstatus" Format="dd/MM/yyyy" PopupButtonID="txtFechaEstatus"></ajaxToolkit:CalendarExtender>  </td>
                                                 
                                                   
                                        </tr>
                                     <tr>
                    <td align="center">
                        <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" cssclass="cmd"/>
                    </td>
                    <td>
                                        <asp:Button ID="cmdVOC" runat="server" cssclass="cmd"
                                         Text="Cuestionario Quejas" />
                                        </td>
                </tr>
                </table></asp:Panel>
    </div>
    </form>
</body>
</html>
