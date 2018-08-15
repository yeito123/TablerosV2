<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="promociones.aspx.vb"
    Inherits="TablerosV2.promociones" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" style="background-color:Black;">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"/>
    <link href="App_Themes/THEME1/StyleSheetRecepcionSeguimiento2.css" rel="stylesheet" />
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css"/>
    <title id="titulo"></title>
</head>
<body>
    <form id="form1" runat="server" background-color="black">
    <asp:ScriptManager runat="server" ID="ScriptManager1" EnablePartialRendering="true"
        AsyncPostBackTimeout="10" />
        <asp:Timer ID="Timer13" runat="server" OnTick="Timer13_Tick"></asp:Timer>
                <div id="divimg" runat="server" class="container" style="width: 100%; height: 100%;
                position: absolute;">
                <div id="imgLOgoEmpresa" runat="server" style="width:200px; height:100px; position: absolute; top: 10%; left: 70% " >
                    <img  alt="" src="img/agenciaLogoPrecios.PNG" style="width: 100%; height:100%"; />
                </div>  
                </div>      
    </form>
</body>
</html>
