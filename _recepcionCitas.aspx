<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="_recepcionCitas.aspx.vb" Inherits="TablerosV2._recepcionCitas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class:"container">
        <asp:ScriptManager runat="server" ID="ScriptManager1" EnablePartialRendering="true"
        AsyncPostBackTimeout="10" />
        <asp:Timer ID="Timer1" runat="server" Enabled="true" OnTick="timer1_tick">
        </asp:Timer>
    </div>
    </form>
</body>
</html>
