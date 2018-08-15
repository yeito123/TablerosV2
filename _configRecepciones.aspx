<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="_configRecepciones.aspx.vb" Inherits="TablerosV2._configRecepciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
    <script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <title>Configuraricon de las pantallas del tv</title>
    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 67.4em;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }

        .auto-style2 {
            display: block;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }
    </style>
</head>
<body>
    <div class="container" style="width: 100%; height: 35%;" runat="server">
        <div class="contianer" style="text-align: center; font-size: 30px; width: 100%; padding-top: 1em; border-bottom: solid; border-color: #DDDDDD;">
            CONFIGURACION DE LAS PANTALLAS QUE SE PROYECTARAN EN EL TV
        </div>
        <div class="contianer" style="padding-top: 2em;">
            <form class="form-horizontal" role="form" runat="server" style="padding-top: 1em;">
                <div class="row">
                    <div class="col-md-12 col-lg-12">
                        <%--<asp:Image runat="server" ID="ImgEnca1" ImageUrl="~/img/agencialogoheader.png" />--%>
                        <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="~/img/logout.png" Width="40px" Style="float: right;" OnClick="ImageButton1_Click" />
                    </div>
                </div>
                <div class="container" style="border: solid; padding-top: 1em; border-color: #DDDDDD; border-radius: 7px 7px;">
                    <div class="form-group">
                        <label for="cboPantallas" class="col-lg-2 control-label">PANTALLA</label>
                        <div class="col-lg-10" runat="server">
                            <asp:DropDownList ID="cboPantallas" runat="server" CssClass="form-control">
                                <asp:ListItem>RecepcionCitas3.aspx</asp:ListItem>
                                <asp:ListItem>RecepcionCitas3a.aspx</asp:ListItem>
                                <asp:ListItem>pantallaPrecios.aspx</asp:ListItem>
                                <asp:ListItem>promociones.aspx</asp:ListItem>
                                <asp:ListItem>pantalla_entregas.aspx</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="cboHoras_ini" class="col-lg-2 control-label">HORA INICIO</label>
                        <div class="col-lg-10" style="width: 10em; float: left;">
                            <asp:DropDownList ID="cboHoras_ini" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <label for="cboHoras_fin" class="col-lg-2 control-label" style="float: left">HORA FIN</label>
                        <div class="col-lg-10" style="width: 15em; float: left;">
                            <asp:DropDownList ID="cboHoras_fin" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <label for="cbo_orden" class="col-lg-2 control-label" style="float: left">ORDEN</label>
                        <div class="col-lg-10" style="width: 15em; float: left;">
                            <asp:DropDownList ID="cbo_orden" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="cbo_orden" class="col-lg-2 control-label" style="float: left">TIEMPO (S)</label>
                        <div class="auto-style1">
                            <asp:DropDownList ID="cmb_tiempo" runat="server" CssClass="auto-style2" Width="310px">
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>45</asp:ListItem>
                                <asp:ListItem>60</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-offset-2 col-lg-10" style="margin-top: 1em;">
                            <div class="checkbox" style="float: left;">
                                <label>
                                    <asp:CheckBox ID="activa" runat="server" />
                                    ACTIVAR
                                </label>
                            </div>
                        </div>
                        <div class="col-lg-offset-2 col-lg-10" style="margin-top: 1em;">
                            <asp:Button ID="btnAgregar" runat="server" class="btn btn-default" Text="AGREGAR" />
                        </div>
                    </div>
                </div>
                <div class="container" runat="server" style="padding-top: 2em; border: solid; border-color: #DDDDDD; border-radius: 7px 7px; margin-top: 2em;">
                    <asp:GridView runat="server" ID="gvpantallas" CssClass="table-responsive table table-bordered" Style="width: 100%; border: solid; padding-top: 1em; border-color: #DDDDDD; border-radius: 7px 7px;" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="imgEliminar" ToolTip="Eliminar" ImageUrl="img/delete.gif" OnClick="imgUEliminar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="id" HeaderText="" Visible="true" />
                            <asp:BoundField DataField="orden" HeaderText="ORDEN" Visible="true" />
                            <asp:BoundField DataField="nombre" HeaderText="PANTALLA" Visible="TRUE" />
                            <asp:BoundField DataField="hora_ini" HeaderText="HORA INICIO" Visible="TRUE" />
                            <asp:BoundField DataField="hora_fin" HeaderText="HORA FIN" Visible="TRUE" />
                            <asp:BoundField DataField="tiempo" HeaderText="TIEMPO" Visible="TRUE" />
                            <asp:TemplateField HeaderText="Activar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkactivo" ToolTip="editar" runat="server" AutoPostBack="true" Checked='<%# Eval("activo") %>' Enabled="true" OnCheckedChanged="activar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
