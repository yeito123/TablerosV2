<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Refacciones.aspx.vb" Inherits="TablerosV2.Refacciones" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="css/generales.css" />
    <style type="text/css">

    .grd
    {
        width:90%;
        }
    
    </style>
    <script>

        function PostBScript() {


            __doPostBack('OkButtonMPGV', '');
            

        }
    </script>
</head>
<body style="background-image:url(img/zoomzoom.JPG); ">
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="Server" id="ScriptManager1" />
<div style=" ">
<table style="width:100%;"><tr><td><img id="IMG1" runat="server" src="~/img/agencialogoheader.png" /></td>
<td><asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="False" Font-Names="Arial"
            Font-Size="Large" ForeColor="Navy" Text="Refacciones" Width="176px"></asp:Label></td>
            <td> <asp:ImageButton ID="imgSalir" runat="server" AlternateText="Salir" 
            ImageUrl="img/logout.png" /></td></tr></table>
    
        
       
            </div>
    <div style=" z-index:100;"> 
    
       
        <table style="width: 50%;">
            <tr>
               
            
                <td>
                    Fecha:
                    <asp:TextBox ID="txtFecha" runat="server" enabled="false"></asp:TextBox>
                   <%--  <ajaxToolkit:CalendarExtender runat="server"   id="txtFechaex" TargetControlID="txtFecha" Format="dd/MM/yyyy" PopupButtonID="txtFecha" ></ajaxToolkit:CalendarExtender>--%>

                    <asp:Button ID="cmdAgregar" runat="server" Text="Consultar" Visible="false" />

                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="cmdExport" runat="server" Text="Exportar" />
                </td>
            </tr>
        </table> 
    </div>
    <div   >
        <asp:DataGrid ID="dgAusencias" runat="server" Font-Size="12px" GridLines="None"
              CellPadding="4" ForeColor="#333333" CssClass="CSSTableGenerator" AutoGenerateColumns="false">
            <EditItemStyle BackColor="#999999" Font-Names="Arial" />
            <AlternatingItemStyle BackColor="White" Font-Names="Arial" />
            <ItemStyle BackColor="#F7F6F3" Font-Names="Arial" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="11px" ForeColor="White"
                Font-Names="Arial" />
            <Columns>
                <asp:TemplateColumn HeaderText="Refacciones" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkRefacciones" AutoPostBack="true" Text="" 
                                                    oncheckedchanged="chkRefacciones_CheckedChanged" Checked='<%# Eval("iRefacciones") %>' Enabled="true"/>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                
                                        <asp:BoundColumn DataField="id" HeaderText="Id"  />
                
                                        <asp:BoundColumn DataField="fecha" HeaderText="Fecha"  />
                
                                        <asp:BoundColumn DataField="hora" HeaderText="Hora"  />
                
                                        <asp:BoundColumn DataField="asesor" HeaderText="Asesor"  />
                
                                        <asp:BoundColumn DataField="orden" HeaderText="Orden"  />
                
                                        <asp:BoundColumn DataField="modelo" HeaderText="Modelo"  />
                
                                        <asp:BoundColumn DataField="placas" HeaderText="Placas"  />
                
                                        <asp:BoundColumn DataField="vin" HeaderText="Vin"  />
                
                                        <asp:BoundColumn DataField="tecnico" HeaderText="Tecnico"  />
                
                                        <asp:BoundColumn DataField="Observaciones" HeaderText="Observaciones"  />

                   <asp:TemplateColumn HeaderText="Pieza" ItemStyle-HorizontalAlign="Center">  <ItemTemplate>
                                <table>
                                    <tr>

                                        <td>
                                            <asp:LinkButton ID="lnkCliente" runat="server" OnClick="lnkPieza_Click"><%# If(Eval("pieza").ToString.Trim.Length > 0, Eval("pieza"), "ninguno")%></asp:LinkButton></td>
                                    </tr>
                                </table>


                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn> 

                
                   <asp:TemplateColumn HeaderText="No Parte" ItemStyle-HorizontalAlign="Center">  <ItemTemplate>
                                <table>
                                    <tr>

                                        <td>
                                            <asp:LinkButton ID="lnkNoparte" runat="server" OnClick="lnkNoparte_Click"><%# If(Eval("noparte").ToString.Trim.Length > 0, Eval("noparte"), "ninguno")%></asp:LinkButton></td>
                                    </tr>
                                </table>


                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn> 

                
                   <asp:TemplateColumn HeaderText="Observaciones" ItemStyle-HorizontalAlign="Center">  <ItemTemplate>
                                <table>
                                    <tr>

                                        <td>
                                            <asp:LinkButton ID="lnkObservaciones" runat="server" OnClick="lnkObservaciones_Click"><%# If(Eval("observacionesrefa").ToString.Trim.Length > 0, Eval("observacionesrefa"), "ninguno")%></asp:LinkButton></td>
                                    </tr>
                                </table>


                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn> 


                  <asp:BoundColumn DataField="IREFACCIONES" HeaderText="irefacciones"  />

         </Columns>
                 
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                 
        </asp:DataGrid>
    </div>
        
        <div>
            <asp:Button runat="server" ID="cmdMPGV" Style="display: none;" />

            <ajaxToolkit:ModalPopupExtender ID="MPGV" runat="server"
                BackgroundCssClass="watermarked" CancelControlID="NoButtonMPGV"
                DropShadow="false" OkControlID="OkButtonMPGV" OnCancelScript="noneScript()"
                OnOkScript="PostBScript()" PopupControlID="PopupMPGV"
                TargetControlID="cmdMPGV" Drag="true">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="PopupMPGV" runat="server">
                <div id="ModalPopupMPGV">

                    <asp:Panel ID="PopupDragHandleMPGV" runat="Server" CssClass="modal-dialog">

                        <div class="modal-content">
                            <div class="modal-body">
                                <div class="form-group">
                                    <asp:Label ID="lblOp" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblInf1" runat="server" Visible="false"></asp:Label>
                                    
                                    <asp:Label runat="server" ID="lblModPieza" Visible="false" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Pieza"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtModPieza"></asp:TextBox>


                                      <asp:Label runat="server" ID="lblModNoparte" Visible="false" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="No. parte"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtModNoparte"></asp:TextBox>

                                      <asp:Label runat="server" ID="lblModObservaciones" Visible="false" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Observaciones"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtModObservaciones" TextMode="MultiLine"></asp:TextBox>
                                    
                                     
                                </div>

                                <div style="text-align: center;">
                                    <div class="btn-group" style="display: inline-block;">
                                      
                                        <asp:Button ID="OkButtonMPGV" runat="server" CssClass="btn btn-primary" Style="float: none;" Text="Si" />

                                        <asp:Button ID="NoButtonMPGV" runat="server" Text="No"
                                            CssClass="btn btn-default" Style="float: none;" />

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
