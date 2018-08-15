<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PreciosCT.aspx.vb" Inherits="TablerosV2.PreciosCT" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: Black;">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    <!--<link href="App_Themes/THEME1/StyleSheetRecepcionSeguimiento2.css" rel="stylesheet" />-->
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css">
    <title>AUTOSUR</title>
</head>
<body>
    <form id="form1" runat="server" background-color="black">
        <asp:ScriptManager runat="server" ID="ScriptManager1" EnablePartialRendering="true"
            AsyncPostBackTimeout="10" />
        <%--este timer es el que cambiara tanto la imagen como los precios--%>
        <asp:Timer ID="Timer1" runat="server" Interval="10000" Enabled="true" OnTick="timer1_tick">
        </asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divimg" runat="server" class="container" style="width: 100%; height: 100%; position: absolute;">
                 <div id="imgLOgoEmpresa" runat="server" style="width:200px; height:100px; position: absolute; top: 8%; left: 78% " >
                    <img  alt="" src="img/agenciaLogoPrecios.PNG" style="width: 100%; height:100%"; />
                </div>   
                     <%--<img id="image1" runat="server" src="" alt="" style="width: 100%; height: 100%;"/>--%>
                    <div id="precios" runat="server" class="container" style="position: absolute; top: 45%; left: 0%; width: 100%">
                        <div id="divLabel1" runat="server" class="table-responsive" style="position: absolute; left: 9%">
                            <asp:Label ID="lbl1" runat="server" CssClass="csslabel"></asp:Label>
                        </div>
                        <div id="divLabel2" runat="server" class="table-responsive" style="position: absolute; top: 45%; left: 28%">
                            <asp:Label ID="lbl2" runat="server" CssClass="csslabel"></asp:Label>
                        </div>
                        <div id="divLabel3" runat="server" class="table-responsive" style="position: absolute; top: 45%; left: 45%">
                            <asp:Label ID="lbl3" runat="server" CssClass="csslabel"></asp:Label>
                        </div>
                        <div id="divLabel4" runat="server" class="table-responsive" style="position: absolute; top: 45%; left: 62%">
                            <asp:Label ID="lbl4" runat="server" CssClass="csslabel"></asp:Label>
                        </div>
                        <div id="divLabel5" runat="server" class="table-responsive" style="position: absolute; top: 45%; left: 80%">
                            <asp:Label ID="lbl5" runat="server" CssClass="csslabel"></asp:Label>
                        </div>
                        <div id="divLabel6" runat="server" class="container" style="position: absolute; top: 27%; left: 73%;">
                        <asp:Label ID="lbl6" runat="server" CssClass="csslabel"></asp:Label>
                    </div>
                     <%--    <div id="divLabel7" runat="server" class="container" style="position: absolute; top: 27%; left: 73%;">
                        <asp:Label ID="lbl7" runat="server" CssClass="csslabel"></asp:Label>
                    </div>--%>
                    </div>                    
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
