<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="TablerosV2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"/>
    <title>Iniciar sesión</title>
    <link rel="stylesheet" href="css/generales.css" />
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css"/>
    <script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-lg-12">
                    <asp:Image ID="Image1" runat="server" ImageUrl="img/agencialogoheader.png" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-8 col-lg-8 col-sm-12">
                    <asp:Label ID="lblStat" runat="server" Text="" Font-Size="20px" Font-Names="Arial"></asp:Label>
                </div>
                <div class="col-md-4 col-lg-4 col-sm-12">
                    <asp:Panel ID="Panel1" runat="server" CssClass="panel panel-default" style="background-color:rgb(255, 255, 255) silver; border: 2px solid #133355;">
                        <div class="panel-body">
                            <div class="form-horizontal" role="form" style="width: 100%;">
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Usuario:</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control input-sm" TabIndex="1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Contraseña:</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control input-sm"  TextMode="Password" TabIndex="2"> </asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12" style="text-align: right;">
                                        <asp:ImageButton ID="imgbtnLogin" runat="server" ToolTip="Aceptar" TabIndex="3" AlternateText="Aceptar" Height="32px" ImageUrl="img/aceptar.png" Width="40px" />
                                        <asp:ImageButton ID="imgbtnPassword" runat="server" TabIndex="10" ToolTip="Cambiar contraseña" AlternateText="Contraseña" ImageUrl="img/contraseña.png" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" Visible="False" style="border-top-style: solid; border-bottom-style: solid; border: 2px solid #133355; border-radius: 5px; box-shadow: 5px 5px 5px #333; opacity: 0.86; background-color: lightsteelblue;" CssClass="panel panel-default">
                        <div class="panel-body">
                            <div class="form-horizontal" style="width: 100%;">
                                <div class="form-group">
                                    <label class="col-sm-6 control-label">Antigua contraseña:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control input-sm" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-6 control-label">Nueva contraseña:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtNewPAssword" runat="server" CssClass="form-control input-sm" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-6 control-label">Verificar contraseña:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtVerifyPassword" runat="server" CssClass="form-control input-sm" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12" style="text-align: right;">
                                        <asp:ImageButton ID="imgbtnGuardar" runat="server" ToolTip="Guardar" AlternateText="Guardar" ImageUrl="img/aceptar.png" />
                                        <asp:ImageButton ID="imgbtnCancel" runat="server" ToolTip="Cerrar" AlternateText="Cerrar" ImageUrl="img/delete_32x32.png" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
