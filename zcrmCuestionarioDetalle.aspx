<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="zcrmCuestionarioDetalle.aspx.vb" Inherits="TablerosV2.zcrmCuestionarioDetalle" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Encuesta de Calidad (Servicio)</title>
    <style type="text/css">
        .nodisplay
        {
            display:none;
            }
     b{
    font-size:15px;}
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
            width: 300px;
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
               .grd100
        {
            width:60%;
        }
               .grd70
        {
            width:20%;
        }
		.style15
		{
		width: 200px;
		}
        </style>
</head>
<body>
    <form id="form1" runat="server">
     <ajaxToolkit:ToolkitScriptManager runat="Server" id="ScriptManager1" />
    <div style="width: 1000px" >
        <asp:Panel runat="server" ID="pNLCT1" Width="1000px" cssclass="div2">
        <table  style="width: 100%;"><tr><td> <asp:Image runat="server" ID="Imglogo1" ImageUrl="~/img/headercuestionarioGM.png" /></td>
        <td align="center"><asp:Label ID="LBL1"   runat="server" Font-Size="20px" font-family="Arial" font-weight="bold"   >SISTEMA DE MEDICION SEMANAL</asp:Label>
         </td>
         <td><asp:ImageButton ID="imgSalir" runat="server" BackColor="#F4F4F4" 
                                        ImageUrl="~/img/Previous_32x32.png" ToolTip="Regresar"  /></td>
         </tr>
         <tr><td></td>
         <td align="center"><asp:Label ID="LBL2" runat="server" Font-Size="18px" font-family="Arial" font-weight="bold"   >Encuesta de buzon de posventa</asp:Label></td>
         <td></td>
         </tr>
         </table>
        
            <table>
                <tr>
                    <td>
                       
                    </td>
                    <td class="style1">
                    <asp:Image runat="server" ID="Imglogo2" ImageUrl="~/img/headercuestionario.png" />
                        
                    </td>
                    <td>
                        
                    <table style="width:100%;">
                        <tr>
                                <td>
                                    <asp:Label ID="lblID" runat="server" Font-Size="10px" Visible="False" ></asp:Label>
                                </td>
                                <td>
                                    
                                        </td>
                            </tr>
                            <tr>
                                <td style=" font-weight:bold;">
                                    No. Orden</td>
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
                        Usuario:</td>
                    <td class="style15">
                        <asp:TextBox ID="txtClientenombre" runat="server" Width="400px"  CssClass="txt" ></asp:TextBox>
                    </td>
                    <td style=" font-weight:bold;"  >
                    Telefono:</td>
                    <td class="style15">
                    <asp:TextBox ID="txtlada" runat="server" Width="25px"  CssClass="txt"  Enabled="false"></asp:TextBox>
                        <asp:TextBox ID="txtTelefono" runat="server" Width="165px"  CssClass="txt"  Enabled="false"></asp:TextBox>
                    </td>
					
                </tr>
                <tr>
                    <td style=" font-weight:bold;">
                    Empresa de Flotillas:</td>
                    <td class="style10">
                        <asp:TextBox ID="txtDireccion"  runat="server" Width="400px"  CssClass="txt"   ></asp:TextBox>
                    </td>
                    <td style=" font-weight:bold;">
                    Vehiculo:</td>
                    <td class="style15" >
                        <asp:TextBox ID="txtTipoAuto" runat="server" Width="195px"  CssClass="txt"  Enabled="false"></asp:TextBox>
                    </td>
                   
                </tr>
				 
                <tr>
                 <td style=" font-weight:bold;"  >
                    Correo:</td>
                    <td class="style15">
                        <asp:TextBox ID="txtCorreo"  runat="server" Width="400px"  CssClass="txt" Enabled="false"></asp:TextBox>
                    </td>
                     <td style=" font-weight:bold;">
                                    Fecha
                                </td>
                                <td colspan="1">
                                    <asp:TextBox ID="txtFecha" runat="server" Width="195px" CssClass="txt" Enabled="false"></asp:TextBox>
                                </td>
                                
                    
					
                </tr>
                <tr>
               
                 <td  style=" font-weight:bold;"  >
                        Mejor horario para contactarlo:</td>
                    <td class="style10">
                        <asp:TextBox ID="txtColonia"  runat="server" Width="400px"  CssClass="txt"   ></asp:TextBox>
                    </td>
                    <td style=" font-weight:bold;" >
                        Asesor</td>
                    <td valign="bottom">
                        <asp:DropDownList ID="CboAsesor" runat="server"  Width="195px"  CssClass="cbo">
                        </asp:DropDownList>
                       
                    </td>
                    
						<asp:TextBox ID="txtCelular" runat="server" width="195px" CssClass="txt" visible="False"></asp:TextBox>
						 
                        <asp:TextBox ID="txtCP" runat="server" Width="195px"  CssClass="txt"  visible="false"></asp:TextBox>
                    
						<asp:TextBox ID="txtCumpleaños" runat="server" width="250px" CssClass="txt" visible="false"></asp:TextBox>
						 
              </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="PnlPReguntas" CssClass="div2">
            <table>
                <tr>
                    <td style="text-align: left">
                        <asp:Label runat="server" ID="LblLeyenda" Text=""
                            Style="text-align: center"></asp:Label>
                    </td>
                </tr>
            </table>
            <table >
             <tr>
                 <td class="style5" colspan="1">
                     <asp:DataGrid ID="dgPreguntas" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1px" CellPadding="7" CellSpacing="3" CssClass="grd100" Font-Size="Small" GridLines="Horizontal" ShowHeader="False">
                         <ItemStyle Font-Size="12px" />
                         <Columns>
                             <asp:BoundColumn DataField="ID_PREGUNTA" HeaderText="" Visible="false" />
                             <asp:TemplateColumn>
                                 <ItemTemplate>
                                     <asp:PlaceHolder ID="PLHOLDERTXT" runat="server">
                                         <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("DESCRIPCION") %>' width="800px"></asp:Label>
                                         <asp:PlaceHolder ID="PLHOLDER" runat="server"></asp:PlaceHolder>
                                     </asp:PlaceHolder>
                                 </ItemTemplate>
                                 <ItemStyle BackColor="#F8F8FC" CssClass="grd100" Font-Bold="True" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="12px" Font-Strikeout="False" Font-Underline="False" />
                             </asp:TemplateColumn>
                             <asp:BoundColumn DataField="tcontrol" HeaderText="" Visible="false" />
                             <asp:BoundColumn DataField="opciones" HeaderText="" Visible="false" />
                             <asp:TemplateColumn>
                                 <ItemTemplate>
                                 </ItemTemplate>
                                 <ItemStyle Font-Size="10px" />
                             </asp:TemplateColumn>
                         </Columns>
                     </asp:DataGrid>
                 </td>
                 
                 
                </table>
                <asp:Panel ID="pnlAdicionales" runat="server">
                
              
               
                <table>
               
                <tr><td>   &nbsp;</td></tr>
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
                <table class="grd100">
                <tr><td>   &nbsp;</td></tr>
                <tr><td style=" font-weight:bold;"> Muchas Gracias</td></tr>
                <tr><td>   &nbsp;</td></tr>
                <tr><td style=" font-weight:bold;"> Atentamente</td></tr>
                <tr><td>   &nbsp;</td></tr>
                <tr><td style=" font-weight:bold;"> Gerencia de Servicio</td></tr>
                <tr><td style=" font-weight:bold;"> Autonova </td></tr>
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
                                             <ajaxToolkit:CalendarExtender runat="server" id="txtFechaEstatusEx" TargetControlID="txtFechaEstatus" Format="dd/MM/yyyy" PopupButtonID="txtFechaEstatus"></ajaxToolkit:CalendarExtender>
                                                    
                                              </td>
                                                
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
