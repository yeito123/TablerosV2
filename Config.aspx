<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Config.aspx.vb" Inherits="TablerosV2.Config" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
         <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/agencialogoheader.png" /></td>
                    <td align="right">
                    <asp:ImageButton runat="server" ID="cmdRegresar" ImageUrl="~/img/logout.png" />
                    
                    </td>
                </tr>
                </table>
                </div>
     
    <div>
         
        <div>
         <asp:Menu ID="Menu1" Width="168px" runat="server" DynamicMenuItemStyle-BorderColor="White"
        DynamicHoverStyle-BorderStyle="Solid" Orientation="Horizontal" 
                StaticEnableDefaultPopOutImage="False" OnMenuItemClick="Menu1_MenuItemClick" 
                BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Bold="True" 
                Font-Names="Calibri" Font-Size="15px" ForeColor="#284E98" 
                StaticSubMenuIndent="10px">
             <StaticSelectedStyle BackColor="#507CD1" />
             <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
<DynamicHoverStyle BorderStyle="Solid" BackColor="#284E98" ForeColor="White"></DynamicHoverStyle>

             <DynamicMenuStyle BackColor="#B5C7DE" />
             <DynamicSelectedStyle BackColor="#507CD1" />

<DynamicMenuItemStyle BorderColor="White" HorizontalPadding="5px" VerticalPadding="2px"></DynamicMenuItemStyle>
             <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
        <Items>
            <asp:MenuItem   Text="Tecnicos" Value="0"></asp:MenuItem>
            <asp:MenuItem   Text="Parametros de Aplicacion" Value="1"></asp:MenuItem>
              
        </Items>
    </asp:Menu>
         <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
             <asp:View ID="View2" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td>
                        &nbsp;
                        <table style="width:100%;">
                         <tr>
                            <td>
                                   
                                    <asp:Label ID="Label1" runat="server" Text="Id Empleado"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtIdEmpleado" runat="server"></asp:TextBox>
                                   
                                </td>
                                <td>
                                   
                                    <asp:Label ID="Label21" runat="server" Text="Nombre"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtNombreTec" runat="server"></asp:TextBox>
                                   
                                </td>
                              <td>
                                   
                                    &nbsp;
                                    <asp:Label ID="Label3" runat="server" Text="Grupo"></asp:Label>
                                    <asp:DropDownList ID="cboGrupo" runat="server">
                                    </asp:DropDownList>
                                   
                                </td>
                             <td>
                                   
                                    <asp:Label ID="Label6" runat="server" Text="Color"></asp:Label>
                                    <asp:DropDownList ID="cboColor" runat="server">
                                    </asp:DropDownList>
                                   
                                </td>
                                <td>
                                   
                                    <asp:Button ID="cmdRefreshColores" runat="server" BackColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Text="Mas colores" Width="85px" />
                                   
                                </td>
                                <td colspan="3">
                                    &nbsp;&nbsp;&nbsp; &nbsp;
                                </td>
                                </tr>
                                <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Entrada L-V"></asp:Label>
                                     
                                    <asp:DropDownList ID="cboEntradaLV" runat="server">
                                    <asp:ListItem Value="08:00" >07:00</asp:ListItem>
                                     <asp:ListItem Value="08:00" >08:00</asp:ListItem>
                                     <asp:ListItem Value="08:00" >09:00</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label23" runat="server" Text="Salida L-V"></asp:Label>
                                     
                                    <asp:DropDownList ID="cboSalidaLV" runat="server">
                                    <asp:ListItem Value="08:00" >07:00</asp:ListItem>
                                     <asp:ListItem Value="08:00" >08:00</asp:ListItem>
                                     <asp:ListItem Value="08:00" >09:00</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Text="Comida L-V"></asp:Label>
                                     
                                    <asp:DropDownList ID="cboComidaLV" runat="server">
                                    <asp:ListItem Value="08:00" >07:00</asp:ListItem>
                                     <asp:ListItem Value="08:00" >08:00</asp:ListItem>
                                     <asp:ListItem Value="08:00" >09:00</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label25" runat="server" Text="Minutos Comida L-V"></asp:Label>
                                     
                                   &nbsp;<asp:TextBox ID="txtMinutosComidaLV" runat="server">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label26" runat="server" Text="Entrada Sabado"></asp:Label>
                                     
                                    <asp:DropDownList ID="cboEntradaSabado" runat="server">
                                    <asp:ListItem Value="08:00" >07:00</asp:ListItem>
                                     <asp:ListItem Value="08:00" >08:00</asp:ListItem>
                                     <asp:ListItem Value="08:00" >09:00</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label27" runat="server" Text="Salida Sabado"></asp:Label>
                                     
                                    <asp:DropDownList ID="cboSalidaSabado" runat="server">
                                    <asp:ListItem Value="08:00" >07:00</asp:ListItem>
                                     <asp:ListItem Value="08:00" >08:00</asp:ListItem>
                                     <asp:ListItem Value="08:00" >09:00</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                 <td>
                                    <asp:Label ID="Label28" runat="server" Text="Comida Sabado"></asp:Label>
                                     
                                    <asp:DropDownList ID="cboComidaSabado" runat="server">
                                    <asp:ListItem Value="08:00" >07:00</asp:ListItem>
                                     <asp:ListItem Value="08:00" >08:00</asp:ListItem>
                                     <asp:ListItem Value="08:00" >09:00</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label29" runat="server" Text="Minutos Comida Sabado"></asp:Label>
                                     
                                    <asp:TextBox ID="txtMinComidaSabado" runat="server">0</asp:TextBox>
                                </td>
                               
                            </tr>
                            <tr>
                                <td>
                                    
                                </td>
                                <td align="right">
                                   
                                    <asp:Button ID="cmdGuardarTec" runat="server" Text="Agregar Tecnico" />
                                   
                                </td>
                                <td>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button ID="cmdReorganizar" runat="server" Text="Reorganizar" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                        <asp:GridView ID="gvTecnicos" runat="server" CellPadding="4" 
                            ForeColor="#333333" GridLines="None">
                             <Columns>
                            
                            <asp:TemplateField>
                              <ItemTemplate>
                              
                               <asp:ImageButton runat="server" ID="imgUEliminar" ToolTip="Eliminar" ImageUrl="img/delete.gif" onclick="imgUEliminar_Click" />
                                <asp:ImageButton runat="server" ID="imgUEditar" ToolTip="Editar" ImageUrl="img/edit.gif" onclick="imgUEditar_Click" Visible="true" />
                                  <asp:ImageButton runat="server" ToolTip="Confirmar" ImageUrl="img/accept.gif" ID="imgUConfirmar" 
                                      onclick="imgUConfirmar_Click"  Visible="false"  />
                              
                               </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </asp:View>
                        <asp:View ID="View1" runat="server">
            <table style="width: 100%;">
                 
                <tr>
                    <td>
                        
                        <asp:GridView ID="gvChips" runat="server" CellPadding="4" 
                            ForeColor="#333333" GridLines="None">
                             <Columns>
                            
                            <asp:TemplateField>
                              <ItemTemplate>
                              
                               
                                <asp:ImageButton runat="server" ID="imgUEditar" ToolTip="Editar" ImageUrl="img/edit.gif" onclick="imgChipEditar_Click" />
                                  <asp:ImageButton runat="server" ToolTip="Confirmar" ImageUrl="img/accept.gif" ID="imgChipConfirmar" 
                                      onclick="imgChipConfirmar_Click"  Visible="false"  />
                              
                               </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </asp:View>

            </asp:MultiView>
        </div>
        
        
         
        <div>
        </div>
        
        
    
    </form>
</body>
</html>
