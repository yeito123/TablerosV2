<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="zcrmGerencia.aspx.vb" Inherits="TablerosV2.zcrmGerencia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        
        .cmdHidden
        {
            visibility: hidden;
            display: none;
        }
        .style2
        {
            width: 24px;
        }
        .style3
        {
            width: 180px;
        }
        .style4
        {
            width: 220px;
        }
        .GrdOver2
        {
            overflow: auto;
            height: 120px;
            width: 400px;
            scrollbar-face-color: #FFFFFF;
            scrollbar-shadow-color: #003366;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #FDFDFE;
            scrollbar-arrow-color: #003366;
        }
        .GrdOver3
        {
            overflow: auto;
            width: 100%;
            height: 90px;
            scrollbar-face-color: #FFFFFF;
            scrollbar-shadow-color: #003366;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #FDFDFE;
            scrollbar-arrow-color: #003366;
        }
        .GrdOver4
        {
            overflow: auto;
            width: 100%;
            height: 30px;
            background-color: snow;
            scrollbar-face-color: #FFFFFF;
            scrollbar-shadow-color: #003366;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #FDFDFE;
            scrollbar-arrow-color: #003366;
        }
        .DivInfoAD
        {
            display: block;
            overflow: auto;
            height: 300px;
            width: 895px;
            scrollbar-face-color: #FFFFFF;
            scrollbar-shadow-color: #003366;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #FDFDFE;
            scrollbar-arrow-color: #003366;
        }
        .DivCorreo
        {
            z-index: 10010;
            background-color: White;
            position: absolute;
            left: 0px;
            right: 0px;
            display: block;
            overflow: auto;
            height: 100%;
            width: 100%;
            scrollbar-face-color: #FFFFFF;
            scrollbar-shadow-color: #003366;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #FDFDFE;
            scrollbar-arrow-color: #003366;
        }
        .DivInfoADb
        {
            display: block;
            overflow: auto;
            height: 100px;
            width: 250px;
            scrollbar-face-color: #FFFFFF;
            scrollbar-shadow-color: #003366;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #FDFDFE;
            scrollbar-arrow-color: #003366;
        }
        .lstM
        {
            border: solid 1px #173344;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
            width: 200px;
            height: 117px;
            scrollbar-face-color: #FFFFFF;
            scrollbar-shadow-color: #88A3BD;
            scrollbar-highlight-color: #88A3BD;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #FDFDFE;
            scrollbar-arrow-color: #88A3BD;
        }
        
        .Label1
        {
            border-bottom: solid 1px #173344;
            font-family: Arial;
            font-size: 14px;
             font-variant:small-caps;
            font-weight: bold;
            color:MidnightBlue;
           
        }
        .cboM
        {
            border: solid 1px #173344;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
            width: 350px;
        }
        .cboM1
        {
            border: solid 1px #173344;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
            width: 80px;
        }
        .txtM
        {
            border: solid 1px #173344;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
            width: 150px;
        }
        .tblM
        {
            border: solid 1px #000080;
            font-family: Arial;
            color: #000080;
            font-size: 11px;
            font-weight: bold;
            width: 150px;
            height: 100%;
        }
        .cssMPGVPop
        {
            background-color: #E4E4E4;
            border: solid 1px #2F4F4F;
            text-align: center;
            vertical-align: top;
            font-size: 12px;
            font-family: arial;
        }
            .grd{width:100%;}
    </style>

    <script type="text/javascript">
        var xwin
        function fAbrirPop() {
            var h = window.screen.availHeight;
            var w = window.screen.availWidth;
            xwin = window.open('crmConsultaCliente.aspx', '', 'width=' + h + ';height=' + w + ';edge=sunken,status=yes,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=yes,modal=yes,dependable=yes;');
        }
        function PostB() {
            __doPostBack('cmdActualizar', '');

        }

        function ocultardivInfoAD() {

            var obj = document.getElementById('divInfoAD');
            if (obj.style.display == 'none') { obj.style.display = 'block' }
            else { obj.style.display = 'none' }
            var obj2 = document.getElementById('divcboUsuarios2');

            try {
                if (obj2.style.display == 'none') { obj2.style.display = 'block' }
                else { obj2.style.display = 'none' }
                var obj3 = document.getElementById('divcboStatus2');
                if (obj3.style.display == 'none') { obj3.style.display = 'block' }
                else { obj3.style.display = 'none' }
            }
            catch (Error) { }
            // Preload(false, 'divloader', 'divprn');
            // window.opener.PostB();

            //window.close();

        }
        function PostBScript() {


            __doPostBack('OkButtonMPGV', '');
            // Preload(false, 'divloader', 'divprn');
            // window.opener.PostB();

            //window.close();

        }
        function utxtMuestraArchivo() {
            __doPostBack('ucmdCargar', '');


        }
        function noneScript() {
            //        var obj = document.getElementById('divInfoAD');
            //        obj.style.display = 'none';
            // Preload(false, 'divloader', 'divprn');
        }
    </script>

</head>
<body style="background-image:url(img/zoomzoom.JPG); ">
    <form id="form1" runat="server">
     <ajaxToolkit:ToolkitScriptManager runat="Server" id="ScriptManager1" />
     <h1 style="color: #666666; font-size: medium; font-family: 'Arial Narrow';">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/AgenciaLogoHeader.png" />&nbsp;
    </h1>
     <div>
    
        <table style="width:100%;">
            <tr>
                <td>
                    <table style="width:100%;">
                        <tr>
                           <td>
                                Cliente</td>
                            <td>

                                <asp:TextBox ID="txtCliente" runat="server" Width="110px"></asp:TextBox>
                            </td>
                                
                            <td>

                                Orden</td>
                            <td>
                                <asp:TextBox ID="txtReferencia" runat="server" Width="50px"></asp:TextBox>
                            </td>
                              <td>

                                Estatus</td>
                            <td>
                                <asp:DropDownList ID="cboEstatus" runat="server" AutoPostBack="true"  
                                    Width="130px" Height="19px"  >
                                     <asp:ListItem Text="---" Value=""></asp:ListItem>
                                      <asp:ListItem Text="Contactado" Value="Contactado"></asp:ListItem>
                                <asp:ListItem Text="Recado" Value="Recado"></asp:ListItem>
                                <asp:ListItem Text="Volver a llamar" Value="Volver a llamar"></asp:ListItem>
                                <asp:ListItem Text="No contactado" Value="No contactado"></asp:ListItem>
                         <asp:ListItem Text="No autoriza llamada" Value="No autoriza llamada"></asp:ListItem>
                        </asp:DropDownList></td>
                           <td>
                                Fecha Ini</td>
                            
                            <td>
                                <asp:TextBox ID="txtFecha" runat="server"   Width="70px"></asp:TextBox>
                                 <ajaxToolkit:CalendarExtender runat="server" id="txtFechaEx" TargetControlID="txtFecha" Format="dd/MM/yyyy" PopupButtonID="txtFecha"></ajaxToolkit:CalendarExtender>
                                                    
                               
                                </td>
                                 <td>
                                Fecha Fin</td>
                            
                            <td>
                                <asp:TextBox ID="txtFechaFin" runat="server"   Width="70px"></asp:TextBox>
                                 <ajaxToolkit:CalendarExtender runat="server" id="txtFechaFinex" TargetControlID="txtFechaFin" Format="dd/MM/yyyy" PopupButtonID="txtFechaFin"></ajaxToolkit:CalendarExtender>
                                 
                                
                                </td>
                            
                        <td>
                                <asp:Button ID="cmdBuscar" runat="server" Text="Buscar" 
                                    BackColor="White" BorderColor="#88A3BD" BorderStyle="Solid" BorderWidth="1px" 
                                    Font-Bold="True" Font-Names="Arial" Font-Size="16px" 
                                    Visible="TRUE" ForeColor="#4D1111" />
                                                                    </td>
                            <td align="right">

                            <asp:ImageButton ID="imgSalir" runat="server" BackColor="#F4F4F4" 
           ImageUrl="~/img/Previous_32x32.png" ToolTip="Regresar" />
                                                                    </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="border-width: thin; border-color: #4D1111; width:99%; border-top-style: solid; border-bottom-style: solid;">
                        <tr>
                            <td class="style3" valign="top">
                                </td>
                            <td class="style4" valign="top">

                                                            </td>
                            <td class="style2" valign="top">
                                </td>
                            <td valign="top" align="right" class="style5">
                            <table style=" height:100%;">
                            <tr>
                            <td valign="bottom" align="left">
                             <table class="tblM">
                                    <tr>
                                        <td>
                                            Total 
                                            </td>
                                        <td>
                                           

                                            <asp:Label ID="lblNumClientes" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                            </td>
                            </tr>
                            </table>
                               
                            </td>
                             
                        </tr>
                        </table>
                </td>
            </tr>
            </table>
    
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:DataGrid ID="dg1" runat="server" AutoGenerateColumns="False" ForeColor="#333333"
                       AllowPaging="true" PageSize="15" Font-Size="Small" CellPadding="4"
                      CssClass="grd"   GridLines="None">
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundColumn DataField="Orden" HeaderText="Orden" SortExpression="Orden"
                                ReadOnly="True">
                                <ItemStyle Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Nom_Cliente" HeaderText="Cliente" ReadOnly="True" SortExpression="nom_cliente" />

                              <asp:BoundColumn DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus"></asp:BoundColumn>
                              <asp:BoundColumn DataField="Fecha_Estatus" HeaderText="Fecha Estatus" DataFormatString = "{0:d}" SortExpression="Fecha_Estatus"></asp:BoundColumn>
                              
                            <asp:BoundColumn DataField="Fecha_Captura" HeaderText="Fecha Captura" DataFormatString = "{0:d}" SortExpression="Fecha_Captura"
                                ReadOnly="True">
                                <ItemStyle Width="150px" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Cuestionario Servicio">
                                <ItemTemplate>
                                    <asp:ImageButton CommandName="Detalle" ID="imgDetalle" runat="server" ImageUrl="~/img/Preview_32x32.png"
                                        AlternateText="Detalle" ImageAlign="Bottom"   />
                                </ItemTemplate>
                                <ItemStyle Width="10px" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn  HeaderText="Cuestionario Entrega">
                                <ItemTemplate>
                                    <asp:ImageButton CommandName="EntregaDetalle" ID="imgEntregaDetalle" runat="server" ImageUrl="~/img/Preview_32x32.png"
                                        AlternateText="Detalle" ImageAlign="Bottom"   />
                                </ItemTemplate>
                                <ItemStyle Width="10px" />
                            </asp:TemplateColumn>
                        </Columns>
                        <HeaderStyle BackColor="#797979" Font-Names="Courier New" ForeColor="White" Wrap="True"
                            Font-Bold="True" />
                        <FooterStyle BackColor="#797979" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#999999" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#797979" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages"
                            NextPageText="" PrevPageText="" />
                        <AlternatingItemStyle BackColor="White" BorderColor="White" ForeColor="#284775" />
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
