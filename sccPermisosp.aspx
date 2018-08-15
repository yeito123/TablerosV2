<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sccPermisosp.aspx.vb" Inherits="TablerosV2.sccPermisosp" %>

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
                        <asp:MenuItem Text="Usuarios" Value="1"></asp:MenuItem>
                        <asp:MenuItem Text="Permisos" Value="2"></asp:MenuItem>
                        <asp:MenuItem Text="Perfiles" Value="0"></asp:MenuItem>
                        <asp:MenuItem Text="Objetos" Value="3"></asp:MenuItem>
                       <%-- <asp:MenuItem Text="pantallas" Value="4"></asp:MenuItem>--%>
                    </Items>
                </asp:Menu>
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
                    <asp:View ID="View1" runat="server">

                        <table style="width: 100%;">
                            <tr>
                                <td valign="top">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" Text="Grupo"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGrupoG" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label13" runat="server" Text="Descripcion"></asp:Label>
                                                <asp:TextBox ID="txtGrupoDescG" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="cmdGuardarGrupo" runat="server" Text="Agregar Grupo" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label10" runat="server" Text="Grupo"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="cboGrupoP" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="Perfil"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPerfilP" runat="server"></asp:TextBox>
                                                &nbsp;<asp:Label ID="Label12" runat="server" Text="Descripcion"></asp:Label>
                                                <asp:TextBox ID="txtPerfilDescripcionP" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="cmdGuardarPerfil" runat="server" Text="Agregar Perfil" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvGrupos" runat="server" BackColor="White"
                                        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                                        CellSpacing="1" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgGEliminar0" runat="server" ImageUrl="img/delete.gif" OnClick="imgGEliminar_Click"
                                                        ToolTip="Eliminar" />
                                                    <asp:ImageButton ID="imgGEditar0" runat="server" ImageUrl="img/edit.gif" OnClick="imgGEditar_Click"
                                                        ToolTip="Editar" />
                                                    <asp:ImageButton ID="imgGConfirmar0" runat="server"
                                                        OnClick="imgGConfirmar_Click" ImageUrl="img/accept.gif" ToolTip="Confirmar" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                    </asp:GridView>
                                </td>
                                <td>
                                    <asp:GridView ID="gvPerfiles" runat="server" BackColor="White"
                                        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                                        CellSpacing="1" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgPEliminar" runat="server" ImageUrl="img/delete.gif" OnClick="imgPEliminar_Click"
                                                        ToolTip="Eliminar" />
                                                    <asp:ImageButton ID="imgPEditar" runat="server" ImageUrl="img/edit.gif" OnClick="imgPEditar_Click"
                                                        ToolTip="Editar" />
                                                    <asp:ImageButton ID="imgPConfirmar" runat="server"
                                                        OnClick="imgPConfirmar_Click" ImageUrl="img/accept.gif" ToolTip="Confirmar" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Grupo"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="cboGrupoU" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Perfil"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="cboPerfilU" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>

                                    <asp:Label ID="Label1" runat="server" Text="User ID"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                                <td>&nbsp;
                                    <asp:Label ID="Label8" runat="server" Text="Confirmar Password"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtPass0" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                                <td>&nbsp;<asp:Label ID="Label4" runat="server" Text="Correo E"></asp:Label>
                                    &nbsp;
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                </td>
                                <td>&nbsp;
                                    <asp:Label ID="Label5" runat="server" Text="Color"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="cboColor" runat="server">
                                    </asp:DropDownList>
                                    <asp:Button ID="cmdRefreshColores" runat="server" BackColor="#CCCCCC"
                                        BorderStyle="Solid" BorderWidth="1px" Text="Mas colores" Width="85px" />
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label18" runat="server" Text="Clave Asesor"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtAsesorID" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right"></td>
                                <td align="left">
                                    <asp:Button ID="cmdGuardarUsr" runat="server" Text="Agregar Usuario" />
                                </td>
                            </tr>
                        </table>
                                </td>
                            </tr>
                            <tr>
                                <td>Si desea mas opciones de colores de click nuevamente en editar
                        <asp:GridView ID="gvUsuarios" runat="server" CellPadding="4"
                            ForeColor="#333333" GridLines="None">
                            <Columns>

                                <asp:TemplateField>
                                    <ItemTemplate>

                                        <asp:ImageButton runat="server" ID="imgUEliminar" ToolTip="Eliminar" ImageUrl="img/delete.gif" OnClick="imgUEliminar_Click" />
                                        <asp:ImageButton runat="server" ID="imgUEditar" ToolTip="Editar" ImageUrl="img/edit.gif" OnClick="imgUEditar_Click" />
                                        <asp:ImageButton runat="server" ToolTip="Confirmar" ImageUrl="img/accept.gif" ID="imgUConfirmar"
                                            OnClick="imgUConfirmar_Click" />

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
                    <asp:View ID="View3" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;* Los permisos se aplicaran a todos los usuarios del mismo perfil
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Grupo"></asp:Label>
                                    <asp:DropDownList ID="cboGrupoPP" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text="Perfil"></asp:Label>
                                    <asp:DropDownList ID="cboPerfilPP" AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text="Operacion"></asp:Label>
                                    <asp:DropDownList ID="cboOperacion" AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Text="Objeto"></asp:Label>
                                    <asp:DropDownList ID="cboObjeto" runat="server">
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
                                <td>&nbsp;<asp:GridView ID="gvPermisos" runat="server" CellPadding="4"
                                    ForeColor="#333333" GridLines="None">
                                    <Columns>

                                        <asp:TemplateField>
                                            <ItemTemplate>

                                                <asp:ImageButton runat="server" ID="imgPPEliminar" ToolTip="Eliminar" ImageUrl="img/delete.gif" OnClick="imgPPEliminar_Click" />


                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle BackColor="#E3EAEB" />
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;
                         <table style="width: 100%;">
                             <tr>
                                 <td>
                                     <asp:Label ID="Label19" runat="server" Text="Objeto"></asp:Label>
                                     &nbsp;<asp:TextBox ID="txtOcveObjeto" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:Label ID="Label20" runat="server" Text="Descripcion"></asp:Label>
                                     <asp:TextBox ID="txtoDescripcion" runat="server"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>&nbsp;</td>
                                 <td>
                                     <asp:Button ID="cmdAgregaObjeto" runat="server" Text="Agregar Objeto" />
                                 </td>
                             </tr>
                         </table>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;<asp:GridView ID="gvObjetos" runat="server" CellPadding="4"
                                    ForeColor="#333333" GridLines="None">
                                    <Columns>

                                        <asp:TemplateField>
                                            <ItemTemplate>

                                                <asp:ImageButton runat="server" ID="imgOEliminar" ToolTip="Eliminar" ImageUrl="img/delete.gif" OnClick="imgOEliminar_Click" />
                                                <asp:ImageButton runat="server" ID="imgOEditar" ToolTip="Editar" ImageUrl="img/edit.gif" OnClick="imgOEditar_Click" />
                                                <asp:ImageButton runat="server" ToolTip="Confirmar" ImageUrl="img/accept.gif" ID="imgOConfirmar"
                                                    OnClick="imgOConfirmar_Click" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle BackColor="#E3EAEB" />
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    </asp:MultiView>
                </div>
            </div>
                </form>
</body>
</html>

