<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="zRecepcionAsesoresEntrega.aspx.vb" Inherits="TablerosV2.zRecepcionAsesoresEntrega" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <style type="text/css">
    html{     }
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
         .grd{width:95%;}
        .GrdOver
        {
            height: 450px;
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
            border: 1px solid #dd9BC7;
            color: Black;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 18px;
            font-weight: bold;
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
    
  
</head>
<body style="background-image:url(img/zoomzoom.JPG); " > 
    <form id="form1" runat="server">
    
         
            

      <asp:ScriptManager runat="server" id="ScriptManager1b" 
            EnablePartialRendering="true" AsyncPostBackTimeout="600" />		 
<asp:Label ID="lblIdAsesor" runat="server"></asp:Label>

    
          <table style="width:97%;">
    <tr>
    <td align="left"> <asp:Image ID="Image1" runat="server" 
            ImageUrl="img/AgenciaLogoHeader.png" /></td>
    
    <td align="right"> <asp:ImageButton  ID="imgSalir" runat="server" 
            AlternateText="Salir"  ImageUrl="img/logout.png" /></td>
     
    </tr>
    </table>
    <div>
        <table style="width: 95%;">
        <tr><td>
             <table>
			 <tr><td colspan=4>
		 <asp:RadioButtonList AutoPostBack="true" runat="server" ID="rdlAsesores" 
                                                    Font-Size="15px"  Font-Bold="true"
                                                    RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlFiltro_SelectedIndexChanged" >
                                                    
                                            </asp:RadioButtonList>
		
		</td>
		
		 
		
		</tr>
		
		 <tr><td  colspan=4>
		 <asp:RadioButtonList AutoPostBack="true" runat="server" ID="rdlStatus" 
                                                    Font-Size="15px"  Font-Bold="true"
                                                    RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlStatus_SelectedIndexChanged" >
                                                    
                                            </asp:RadioButtonList>
		
		</td>
		
		 
		
		</tr>
		
		
		
		
		
		
        <tr>
         <td>Fecha I <asp:TextBox ID="txtI" runat="server" ></asp:TextBox>
                      <ajaxToolkit:CalendarExtender runat="server"   id="txtIex" TargetControlID="txtI" Format="dd/MM/yyyy" PopupButtonID="txtI"></ajaxToolkit:CalendarExtender>
</td>
<td>Fecha F 
<asp:TextBox ID="txtF" runat="server" ></asp:TextBox>
                      <ajaxToolkit:CalendarExtender runat="server"   id="txtFex" TargetControlID="txtF" Format="dd/MM/yyyy" PopupButtonID="txtF"></ajaxToolkit:CalendarExtender>
</td>
<td> Placas
<asp:TextBox ID="txtFind" runat="server" ></asp:TextBox>
</td>
<td>
 <asp:Button ID="cmdBuscar" runat="server" Text="Buscar" />
</td>
        </tr>
        </table>
        </td>
   
       
        
        
        </tr>
		
            <tr>
                <td>
  
       <div ><br />
   
                    <div  >
                        <asp:DataGrid ID="dg1" runat="server" AutoGenerateColumns="False" ForeColor="#fff"
                             CellPadding="2" GridLines="None" Font-Bold="False" Font-Italic="False"
                            Font-Names="Arial" Font-Overline="False" Font-Size="14px" Font-Strikeout="False"
                            Font-Underline="False"    CssClass="grd" >
                            <ItemStyle ForeColor="black" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" />
                            <Columns>
                               <asp:BoundColumn DataField="NOORDEN"  HeaderText="NoOrden"   />  
                                <asp:BoundColumn DataField="VIN" HeaderText="VIN"  /> 
                                      <asp:BoundColumn DataField="noPlacas" HeaderText="Placas"  />                          
                               
                                        <asp:BoundColumn DataField="Cliente" HeaderText="Cliente"  />
                                        <asp:BoundColumn DataField="Vehiculo" HeaderText="Modelo" />
                                         <asp:BoundColumn DataField="YEAR_MODELO" HeaderText="Año" />
                                        <asp:BoundColumn DataField="COLOR" HeaderText="Color" />
                                        <asp:BoundColumn DataField="Asesor" HeaderText="Asesor" />
                                                                       <asp:BoundColumn DataField="fecha" HeaderText="Fecha Ingreso" visible="true"  DataFormatString="{0:d}"  />
                                                                         <asp:BoundColumn DataField="HoraLlegada" HeaderText="HoraIngreso"  visible="True" /> 
 <asp:BoundColumn DataField="Horairecepcion" HeaderText="IRecep"  visible="True" /> 
 <asp:BoundColumn DataField="Horafrecepcion" HeaderText="FRecep"  visible="True" /> 
<asp:BoundColumn DataField="Fecha_hora_com" HeaderText="FechaPromesa"  visible="True" />  

																		 
                                        <asp:TemplateColumn HeaderText="Inicio Entrega" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkInicioE" AutoPostBack="true" Text="" 
                                                    oncheckedchanged="chkInicioE_CheckedChanged" Enabled="false"/>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                         <asp:TemplateColumn HeaderText="Fin Entrega" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkFin" AutoPostBack="true" Enabled="false" oncheckedchanged="chkFin_CheckedChanged" Text="" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                         <asp:TemplateColumn HeaderText="Test Calidad" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtFechaPromesa" Text='<%# Eval("fechahorapromesa")%>' runat="server"></asp:TextBox>
                                                 <ajaxToolkit:CalendarExtender runat="server"   id="txtFechaPromesaEX" TargetControlID="txtFechaPromesa" Format="dd/MM/yyyy" PopupButtonID="txtFechaPromesa"></ajaxToolkit:CalendarExtender>

                                                <asp:TextBox ID="txtObservaciones" Text='<%# Eval("observaciones")%>' runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                            <asp:CheckBox runat="server" ID="chkCalidad" visible="false"  Enabled="false" Text="" />
<%--                                            <asp:CheckBox runat="server" ID="chkCalidad" AutoPostBack="true"  Enabled="false" oncheckedchanged="chkCalidad_CheckedChanged" Text="" />--%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                          
                                         <asp:BoundColumn DataField="HoraIEntrega" HeaderText="HoraIEntrega" Visible="FALSE"   />
                                       <asp:BoundColumn DataField="HoraFENTREGA" HeaderText="HoraFRecepcion"   Visible="FALSE" />
                                        <asp:BoundColumn DataField="testqa" HeaderText=""   Visible="FALSE" />
                                         <asp:BoundColumn DataField="id_hd" HeaderText=""   Visible="FALSE" />
                                           <asp:BoundColumn DataField="status" HeaderText="Estatus"   Visible="true" />
                                        
                                       
                            </Columns>
                            <HeaderStyle BackColor="#999999" ForeColor="white" Wrap="True" Font-Bold="True" Font-Italic="False"
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
                    </div>
                    
    
                </td>
            </tr>
            
        
        </table>
    </div>
    </form>
</body>
</html>
