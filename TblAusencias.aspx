<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TblAusencias.aspx.vb" Inherits="TablerosV2.TblAusencias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Ausencias</title>
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
    <script src="Bootstrap/js/jquery-3.2.0.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <style type="text/css">
        .cssHeader {
            background-image: url(img/fondoHeader.png);
            background-size: cover;
            background-repeat: no-repeat;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form-inline">
        <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />
        <div class="container cssHeader jumbotron" style="width: 100%;">
            <div id="divheader" class="container form-group page-header">
                <div id="divImagenLogo" class="form-inline">
                    <asp:Image runat="server" ID="ImgLogo" ImageUrl="~/img/AgenciaLogoHeader.png" Width="260px" Height="60px" Style="float: left;" />
                    <asp:ImageButton runat="server"
                        ID="btnSalir" ImageUrl="~/img/BtnSalir.png" Width="12em" Height="6em" Style="float: right;" OnClick="btnSalir_Click" />
                </div>
            </div>
        </div>
        <div id="divCuerpo" class="container" style="width: 100%; padding-top: 2em;">
            <div id="divHeaderCuerpo" class="form-group" style="width: 100%;">
                <div class="form-inline" style="float: left; width: 100%;">
                    <asp:Label ID="lblTecnico" runat="server" Text="Técnico:" For="cmbTecnico" Style="font-size: 2em; color: black;"></asp:Label>
                    <asp:DropDownList ID="cmbTecnico" runat="server" CssClass="form-control dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbTecnico_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-inline" style="position: absolute; left: 80%;">
                    <asp:ImageButton runat="server"
                        ID="imgMenuAgregar" AlternateText="agregar"
                        Style="position: relative;" ImageUrl="~/img/imgbtnAgregar.png"
                        Width="4em" Height="4em" OnClick="imgMenuAgregar_Click" />
                    <asp:ImageButton runat="server"
                        ID="imgMenuBorrar"
                        AlternateText="Borrar"
                        Style="position: relative;"
                        ImageUrl="~/img/imgBtnBorrar.png"
                        Width="4em" Height="4em" OnClick="imgMenuBorrar_Click" />
                </div>
            </div>
            <div id="divImgAgregar" class="container" style="padding-top: 3em; width: 100%">
                <asp:Panel runat="server" ID="pnlAgregar" Style="display: none;">
                    <asp:Label runat="server" ID="txtActivo" Style="display: none;" Text="0" />
                    <div class="checkbox-inline">
                        <asp:Label runat="server" ID="lblPeriodo" Text="Periodo"></asp:Label>
                        <asp:CheckBox runat="server" ID="checkPeriodo" CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="checkPeriodo_CheckedChanged" />
                    </div>
                    <div id="divPanelFechaIni" class="form-group">
                        <asp:Label runat="server" Style="display: none;" ID="lblcheck" Text="0"></asp:Label>
                        <asp:Label runat="server" ID="lblDiaInicio" Text="Dia Inicio: "></asp:Label>
                        <asp:TextBox runat="server" ID="txtFechaInicio" CssClass="form-control" placeholder="Fecha Inicio" autofocus=""></asp:TextBox>
                        <ajaxToolkit:CalendarExtender
                            runat="server"
                            ID="cldFechaInicio"
                            TargetControlID="txtFechaInicio"
                            PopupButtonID="txtFechaInicio"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </div>
                    <div id="divPanelFechaFin" class="form-group">
                        <asp:Label runat="server" ID="lblDiaFin" Text="Dia Fin: " Style="display: none"></asp:Label>
                        <asp:TextBox runat="server" ID="txtfechaFin" CssClass="form-control" placeholder="Fecha fin" Style="display: none"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender
                            runat="server"
                            ID="cldFechaFIn"
                            TargetControlID="txtFechaFin"
                            PopupButtonID="txtFechaFin"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </div>
                    <div id="divHoraInicio" class="form-group">
                        <asp:Label runat="server" ID="lblHoraInicio" Text="Hora Inicio: "></asp:Label>
                        <asp:DropDownList runat="server" ID="cmdHoraInicio" CssClass="form-control" placeholder="Hora inicio"></asp:DropDownList>
                    </div>
                    <div id="divHoraFin" class="form-group">
                        <asp:Label runat="server" ID="lblHoraFin" Text="Hora Fin: "></asp:Label>
                        <asp:DropDownList runat="server" ID="cmdHoraFin" CssClass="form-control" placeholder="Hora fin"></asp:DropDownList>
                    </div>
                    <div id="divTipo" class="form-group">
                        <asp:Label runat="server" ID="lblTipo" Text="Tipo: "></asp:Label>
                        <asp:DropDownList runat="server" ID="cmdTIpo" CssClass="form-control" placeholder="Tipo"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:ImageButton
                            runat="server"
                            ID="imgIncertar" ImageUrl="~/img/imgAceptar.png"
                            Style="float: right;"
                            Width="3em" Height="3em"
                            OnClick="imgIncertar_Click" />
                    </div>

                </asp:Panel>
            </div>
            <div id="divImgBorrar" class="container" style="padding-top: 3em; width: 100%">
                <asp:Panel runat="server" ID="pnlBorrar" Style="display: none;">
                    <asp:Label runat="server" ID="lblBorrarActivo" Style="display: none;" Text="0" />
                    <div id="diviBorrar" class="form-group">
                        <asp:Label runat="server" ID="lblBorrar" Text="Dia Inicio: "></asp:Label>
                        <asp:TextBox runat="server" ID="txtDiaIBorrar" CssClass="form-control" placeholder="Fecha Inicio" autofocus=""></asp:TextBox>
                        <ajaxToolkit:CalendarExtender
                            runat="server"
                            ID="CldCalendarIBorrar"
                            TargetControlID="txtDiaIBorrar"
                            PopupButtonID="txtDiaIBorrar"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </div>
                    <div id="DivFborrar" class="form-group">
                        <asp:Label runat="server" ID="lblFFBorrar" Text="Dia Fin: "></asp:Label>
                        <asp:TextBox runat="server" ID="txtFFBorrar" CssClass="form-control" placeholder="Fecha fin"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender
                            runat="server"
                            ID="cldCalendarFBorrar"
                            TargetControlID="txtFFBorrar"
                            PopupButtonID="txtFFBorrar"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </div>
                    <div id="divTuoiFin" class="form-group">
                        <asp:Label runat="server" ID="lblTipoBorrar" Text="Tipo: "></asp:Label>
                        <asp:DropDownList runat="server" ID="cmdTipoBorrar" CssClass="form-control" placeholder="Tipo"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:ImageButton
                            runat="server"
                            ID="ImgBorrar" ImageUrl="~/img/imgAceptarBorrar.png"
                            Style="float: right;"
                            Width="3em" Height="3em"
                            OnClick="ImgBorrar_Click" />
                    </div>
                </asp:Panel>
            </div>
            <div id="divGirdAusencias" class="container tab-content table-responsive" style="padding-top: 4em; text-align: center;">
                <asp:DataGrid runat="server" ID="GridTecnicos" Visible="false" CssClass=" table table-striped table-condensed" GridLines="None"
                    AutoGenerateColumns="false" Width="100%">
                    <%--<HeaderStyle BackColor="#034EC6" ForeColor="White" HorizontalAlign="Center" />--%>
                    <ItemStyle />
                    <Columns>
                        <asp:BoundColumn DataField="ID_EMPLEADO" HeaderText="" Visible="false" />
                        <asp:BoundColumn DataField="nombre_empleado" HeaderText="Nombre" Visible="true" />
                        <asp:BoundColumn DataField="ID_TIPO_EMPLEADO" HeaderText="Tipo Empleado" Visible="true" />
                        <asp:BoundColumn DataField="fecha" HeaderText="Fecha" Visible="true" />
                        <asp:BoundColumn DataField="E1" HeaderText="Inicio" Visible="true" />
                        <asp:BoundColumn DataField="S1" HeaderText="Fin" Visible="true" />
                        <asp:BoundColumn DataField="C1" HeaderText="" Visible="false" />
                        <asp:BoundColumn DataField="tausencia" HeaderText="Tipo de ausencia" Visible="true" />
                        <asp:TemplateColumn HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:ImageButton
                                    runat="server" ID="imgEliminar"
                                    ImageUrl="~/img/imgAceptarBorrar.png"
                                    Width="1.5em"
                                    Height="1.5em"
                                    OnClick="imgEliminar_Click" />
                            </ItemTemplate>
                        </asp:TemplateColumn>

                    </Columns>
                </asp:DataGrid>
            </div>
        </div>
    </form>
</body>
</html>
