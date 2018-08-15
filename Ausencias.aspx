<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Ausencias.aspx.vb" Inherits="TablerosV2.Ausencias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
    <script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <title>Página sin título</title>
</head>
<body style="background-image: url(img/zoomzoom.JPG);">
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <img id="IMG1" runat="server" src="~/img/agencialogoheader.png" /></td>
                    <td>
                        <asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="False" Font-Names="Arial"
                            Font-Size="Large" ForeColor="Navy" Text="Ausencias" Width="176px"></asp:Label></td>
                    <td>
                        <asp:ImageButton ID="imgSalir" runat="server" AlternateText="Salir"
                            ImageUrl="img/Previous_32x32.png" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="rdlModalidad" AutoPostBack="true" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Selected="True" Value="1">por dia</asp:ListItem>
                            <asp:ListItem Value="2">por periodo</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>



        </div>
        <div id="ausDia" runat="server" visible="false">
            <div>


                <table style="width: 100%;">
                    <tr>

                        <td align="center">Empleado</td>
                        <td align="center">Dia
                        </td>
                        <td>Inicio de la Ausencia (hh:mm)</td>
                        <td>Fin de la Ausencia (hh:mm)</td>
                        <td>Tipo</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>


                        <td>
                            <asp:DropDownList ID="cboEmpleados" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td> <asp:TextBox ID="txtPCalVigInicio" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="txtPCalVigInicioEX" TargetControlID="txtPCalVigInicio" Format="dd/MM/yyyy" PopupButtonID="txtPCalVigInicio"></ajaxToolkit:CalendarExtender>


                        </td>
                        <td align="center">
                            <asp:DropDownList ID="cboIni" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="cboFin" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="cboTipo" runat="server">
                                 <asp:ListItem Selected="True" Text="W3 - Tiempo en horas de formación que reciben los aprendices y ayudantes"></asp:ListItem>
                        <asp:ListItem Text="W5 - Tiempo en horas de vacaciones Días de vacaciones o días festivos"></asp:ListItem>
                        <asp:ListItem Text="W6 - Tiempo en horas de capacitación"></asp:ListItem>
                        <asp:ListItem Text="W7 - Tiempo en horas por incapacidad"></asp:ListItem>
                         <asp:ListItem Text="W9 - Tiempo descanso"></asp:ListItem>
                        <asp:ListItem Text="Falta"></asp:ListItem>
  			
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="cmdAgregar" runat="server" Text="Agregar" />
                        </td>
                    </tr>
                </table>
                &nbsp;
            </div>
            <div>
                <asp:DataGrid ID="dgAusencias" runat="server" AutoGenerateColumns="false" Font-Size="Small"
                    ShowHeader="True" BorderStyle="Solid" BorderWidth="1px" GridLines="Horizontal"
                    Width="590px">
                    <EditItemStyle BackColor="#2461BF" Font-Names="Arial" Font-Size="11px" />
                    <AlternatingItemStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                    <ItemStyle BackColor="#EFF3FB" Font-Names="A    rial" Font-Size="11px" />
                    <HeaderStyle BackColor="#000066" Font-Bold="True" Font-Size="11px" ForeColor="White"
                        Font-Names="Arial" />
                    <Columns>
                        <asp:BoundColumn DataField="ID_EMPLEADO" HeaderText="" Visible="TRUE" />
                        <asp:BoundColumn DataField="nombre_empleado" HeaderText="" Visible="true" />
                        <asp:BoundColumn DataField="ID_TIPO_EMPLEADO" HeaderText="" Visible="true" />
                        <asp:BoundColumn DataField="fecha" HeaderText="" Visible="true" />
                        <asp:BoundColumn DataField="E1" HeaderText="Inicio" Visible="true" />
                        <asp:BoundColumn DataField="S1" HeaderText="Fin" Visible="true" />
                        <asp:BoundColumn DataField="C1" HeaderText="" Visible="false" />
                          <asp:BoundColumn DataField="tausencia" HeaderText="tipo" Visible="true" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEliminar" runat="server" CommandName="Eliminar" ImageUrl="~/img/Delete_32x32.png"
                                    ImageAlign="Bottom" Height="16px" Width="16px"
                                    OnClick="cmdEliminar_Click" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </div>
        </div>
        <div id="ausPeriodo" runat="server" visible="true">
            <div>


                <table style="width: 100%;">
                    <tr>

                        <td>Empleado</td>

                        <td>Inicio </td>
                        <td>Fin </td>
                        <td>Inicio de la Ausencia (hh:mm)</td>
                        <td>Fin de la Ausencia (hh:mm)</td>
                        <td>Tipo</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>


                        <td>
                            <asp:DropDownList ID="cboEmpleados2" runat="server">
                            </asp:DropDownList>
                        </td>

                        <td>&nbsp;<asp:TextBox ID="txtfecini" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="txtfeciniex" TargetControlID="txtfecini" Format="dd/MM/yyyy" PopupButtonID="txtfecini"></ajaxToolkit:CalendarExtender>

                        </td>
                        <td>&nbsp;<asp:TextBox ID="txtfecfin" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="txtfecfinex" TargetControlID="txtfecfin" Format="dd/MM/yyyy" PopupButtonID="txtfecfin"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="cboIniPer" runat="server">
                            </asp:DropDownList>
                        </td>

                        <td align="center">
                            <asp:DropDownList ID="cboFinPer" runat="server">
                            </asp:DropDownList>

                        </td>
                        <td>
                            <asp:DropDownList ID="cboTipo2" runat="server">
                                 <asp:ListItem Selected="True" Text="W3 - Tiempo en horas de formación que reciben los aprendices y ayudantes"></asp:ListItem>
                        <asp:ListItem Text="W5 - Tiempo en horas de vacaciones Días de vacaciones o días festivos"></asp:ListItem>
                        <asp:ListItem Text="W6 - Tiempo en horas de capacitación"></asp:ListItem>
                        <asp:ListItem Text="W7 - Tiempo en horas por incapacidad"></asp:ListItem>
                         <asp:ListItem Text="W9 - Tiempo descanso"></asp:ListItem>
                                <asp:ListItem Text="10%"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="cmdAgregarPeriodo" runat="server" Text="Agregar" />
                        </td>
                    </tr>
                </table>
                &nbsp;
            </div>
            <div>
                <asp:DataGrid ID="dgAusenciasPeriodo" runat="server" AutoGenerateColumns="false" Font-Size="Small"
                    ShowHeader="True" BorderStyle="Solid" BorderWidth="1px" GridLines="Horizontal"
                    Width="590px">
                    <EditItemStyle BackColor="#2461BF" Font-Names="Arial" Font-Size="11px" />
                    <AlternatingItemStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                    <ItemStyle BackColor="#EFF3FB" Font-Names="A    rial" Font-Size="11px" />
                    <HeaderStyle BackColor="#000066" Font-Bold="True" Font-Size="11px" ForeColor="White"
                        Font-Names="Arial" />
                    <Columns>
                         <asp:BoundColumn DataField="periodo" HeaderText="" Visible="false" />
                        <asp:BoundColumn DataField="ID_EMPLEADO" HeaderText="" Visible="TRUE" />
                        <asp:BoundColumn DataField="nombre_empleado" HeaderText="" Visible="true" />
                       
                        <asp:BoundColumn DataField="periodo_s" HeaderText="Periodo" Visible="true" />
                        <asp:BoundColumn DataField="E1" HeaderText="Inicio" Visible="true" />
                        <asp:BoundColumn DataField="S1" HeaderText="Fin" Visible="true" />
                           <asp:BoundColumn DataField="tausencia" HeaderText="tipo" Visible="true" />

                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEliminar" runat="server" CommandName="Eliminar" ImageUrl="~/img/Delete_32x32.png"
                                    ImageAlign="Bottom" Height="16px" Width="16px"
                                    OnClick="cmdEliminar2_Click" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </div>
        </div>
        <div>


            <asp:Panel ID="ModalPanel" runat="server" CssClass="modal-dialog" Visible="false">
                <table id="tblEliminar" class="table table-striped table-condensed table-bordered">
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblModVehiculo" Visible="true" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Tecnico:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cbomodTecnicos" runat="server" Font-Size="15px" Font-Bold="True">
                            </asp:DropDownList></td>
                        <td>
                            <asp:Label runat="server" ID="lblModfecha" Visible="true" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Fecha Inicio:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="fechaIni"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="TxtfechaIniex" TargetControlID="fechaIni" Format="dd/MM/yyyy hh:mm" PopupButtonID="fechaIni"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblfechaFin" Visible="true" Style="color: MIDNIGHTBLUE; cursor: auto; font-size: 11px; font-weight: BOLD;" Text="Fecha Fin:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="FechaFin"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="txtFechaFinex" TargetControlID="FechaFin" Format="dd/MM/yyyy hh:mm" PopupButtonID="fechaFin"></ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                </table>
                <table class="table-responsive table" style="left:25%;">
                    <tr>
                        <td>
                            <asp:Button ID="OKButton" runat="server" Text="OK" Width="20em" OnClick="OKButton_Click" />
                        </td>
                        <td>
                            <asp:Button ID="CmdCancecalr" runat="server" Text="Cancelar" Width="20em" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>