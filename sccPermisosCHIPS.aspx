<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sccPermisosCHIPS.aspx.vb" Inherits="TablerosV2.sccPermisosChips" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
         <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View3" runat="server">
        
            <table style="width: 100%;">
                <tr>
                    <td>
                        &nbsp;* Los permisos sobre chips se aplicaran a todos los usuarios del mismo perfil
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Grupo"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="cboGrupoPP" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text="Perfil"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="cboPerfilPP" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text="Operacion"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="cboOperacion" runat="server">
                                    </asp:DropDownList>
                                </td>
                                 <td>
                                    <asp:Label ID="Label17" runat="server" Text="Objeto"></asp:Label>
                                    <asp:DropDownList ID="cboObjeto"   runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="cmdGuardarPermiso" runat="server" Text="Agregar Permiso" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td> 
                        &nbsp;<asp:GridView ID="gvPermisos" runat="server" CellPadding="4" 
                            ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgPPEliminar" runat="server" ImageUrl="img/delete.gif" 
                                            onclick="imgPPEliminar_Click" ToolTip="Eliminar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#E3EAEB" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="#E3EAEB" />
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

 