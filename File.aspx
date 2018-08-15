<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="File.aspx.vb" Inherits="TablerosV2.File" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function cerrarpop() {

            this.window.close();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ImageButton ID="cmdEliminar" runat="server" ImageUrl="~/img/Delete_32x32.png" AlternateText="Eliminar" oncllientclick="cerrarpop()" ImageAlign="Right" />
    <div runat="server" id="divcont">
        <iframe src='FileAux.aspx?<%= "tcuestionario=" & Request.QueryString("tcuestionario") & "&noorden=" & Request.QueryString("noorden") & "&idimg=" & Request.QueryString("idimg") & ""%>' 
             scrolling="no"  style="width: 1000px;
height: 694px;
overflow: hidden;
border: none;"></iframe>
    </div>
    </form>
</body>
</html>
