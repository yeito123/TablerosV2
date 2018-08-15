<%@ Page Language="vb" AutoEventWireup="false" EnableViewState="true" CodeBehind="zcrmCuestionarioDetalleInventario.aspx.vb" Inherits="TablerosV2.zcrmCuestionarioDetalleInventario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 745px;
        }
        .style5
        {
            width: 850px;
        }
        .style6
        {
            width: 102px;
        }
        .style7
        {
            width: 106px;
        }
        .style8
        {
            width: 154px;
        }
        .style9
        {
            width: 105px;
        }
        .lstM
        {
            border: 1px solid #460000;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
            scrollbar-face-color: #FFFFFF;
            scrollbar-shadow-color: #D07575;
            scrollbar-highlight-color: #D07575;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #FDFDFE;
            scrollbar-arrow-color: #D07575;
        }
        .txt{
            border: 1px solid #460000;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
        }
        
        .lblErr{
            font-size: 20px;
            color:"#FF0000";
            background-color:#FF0000;            
        }
        .cmd{
          background-color:#ffffff ;
         color:"#4D1111";
           border:solid 1px #000000;
            font-weight:bold;
             font-family:Arial;
             font-size:16px;
          
        }
        .cbo{
            border: 1px solid #460000;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
        }
        .lblTitulo{
            border:none;
            font-family: Arial;
            font-size: 20px;
            font-weight: bold;
             font-variant:small-caps;
            color: #000;
        }
        .div2{
         
            font-family: Helvetica;
            font-size: 12px;
            font-weight: normal;
        
        }
        div{
          
            font-family: Helvetica;
            font-size: 12px;
            font-weight: normal;
        
        }
        .style10
        {
            width: 684px;
        }
        .style11
        {
            width: 46px;
        }
        .style12
        {
            height: 19px;
            width: 848px;
        }
        .style13
        {
            text-align: center;
            font-weight: bold;
            width: 103px;
            height: 19px;
        }
        .style14
        {
            text-align: center;
            font-weight: bold;
            width: 100px;
            height: 19px;
        }
               .grd100
        {
            width:100%;
        }
               .grd70
        {
            width:70%;
        }
        center {
        background-color:#6f47d0;
        color:#FFF;
        font-size:14px;
        }
        </style>
    <script>
        function fcomboKey3(obj) {
            if (obj.value == '' || obj.value == undefined) { return false }
            var selObj = document.getElementById('CboVIN');
            var selObj2 = document.getElementById('CboVIN2');

            var val = '';
            val = obj.value.toLowerCase();
            var dsplit;

            var ik = selObj.options.length;

            for (ii = 0; ii < ik; ii++) {
                selObj.remove(0);

            }

            for (i = 0; i < selObj2.options.length; i++) {
                dsplit = selObj2.options[i].value.split("__")
                if (dsplit[0].toLowerCase().indexOf(val.toLowerCase()) >= 0) {

                    // fcombo3(selObj.options[i].text);
                    //selObj.selectedIndex = i;
                    var option = document.createElement("option");
                    option.text = selObj2.options[i].text;
                    option.value = selObj2.options[i].value;
                    // var sel = selObj2.options[selObj2.selectedIndex];
                    selObj.add(option);

                }
            }

            selObj.selectedIndex = 0;
            return false;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
     <ajaxToolkit:ToolkitScriptManager runat="Server" id="ScriptManager1" />
    <div style="width: 1069px" >
        <asp:Panel runat="server" ID="pNLCT1" Width="1065px" cssclass="div2">
            <table>
                <tr>
                    <td>
                        <asp:Image runat="server" ID="Imglogo1" ImageUrl="~/img/AgenciaLogoHeader.png" />
                    </td>
                    <td class="style1" align="center">
                        <asp:Label runat="server" ID="LblTitulo" Text="INVENTARIO DE ENTRADA NO."
                          CssClass="lblTitulo"></asp:Label>
                        <asp:TextBox ID="txtOrden" runat="server" Width="144px" CssClass="txt" ></asp:TextBox>
                                    <asp:ImageButton runat="server" ID="ImgBtnRef" ImageUrl="~/img/aceptar.png"  />
                        <br />
                        Servicio Postventa </td>
                    <td>
                        
                    <table style="width:100%;">
                        <tr>
                                <td>
                                    <asp:Label ID="lblID" runat="server" Font-Size="10px" Visible="False" ></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:ImageButton ID="imgSalir" runat="server" BackColor="#F4F4F4" 
                                        ImageUrl="~/img/Previous_32x32.png" ToolTip="Regresar"  />
                                        </td>
                            </tr>
                            <tr>
                                <td style=" font-weight:bold;">
                                    Fecha
                                </td>
                                <th>
                                    <asp:TextBox ID="txtFecha" runat="server" Width="154px" CssClass="txt" Enabled="false"></asp:TextBox>
                                </th>
                            </tr> 
                             
                            
                        </table>
                    </td>
                </tr>
            </table>
            <table style="font-weight: bold;">
             <tr>
                    <td class="style10" colspan="3">
                        Propietario:
                        <asp:TextBox ID="txtCliente" runat="server" onkeyup="fcomboKey3(this);" Width="651px"  CssClass="txt" ></asp:TextBox>
                    </td>
                    <td class="style11">
                        Serie No:
                        <asp:DropDownList ID="CboVIN" runat="server" CssClass="cbo"  >
                        </asp:DropDownList>
                         <asp:DropDownList ID="CboVIN2" runat="server"  style="display:none;" >
                        </asp:DropDownList>
                        <asp:ImageButton ID="ImgBtnRef0" runat="server" Height="16px" ImageUrl="~/img/right_32.png" Width="19px" />
                    </td>
                </tr>
                <tr>
                    <td class="style10">
                        OP:
                        <asp:TextBox ID="txtOP"  runat="server" Width="195px"  CssClass="txt"  Enabled="true"></asp:TextBox>
                    </td>
                    <td class="style10">
                        Placas:
                        <asp:TextBox ID="txtPLACAS"  runat="server" Width="195px"  CssClass="txt"  Enabled="false"></asp:TextBox>
                    </td>
                    <td class="style10">Kilometraje:
                        <asp:TextBox ID="txtKILOMETRAJE" runat="server" CssClass="txt" Enabled="true" Width="195px"></asp:TextBox>
                    </td>
                    <td class="style10">Fecha Entrada:&nbsp;<asp:TextBox ID="txtFECHAE" runat="server" CssClass="txt" Enabled="true" Width="195px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender runat="server" id="txtFECHAEex" TargetControlID="txtFECHAE" Format="dd/MM/yyyy" PopupButtonID="txtFECHAE"></ajaxToolkit:CalendarExtender>
                                                    
                    </td>
                </tr>
                <tr>
                    <td >
                        Marca:
                        <asp:TextBox ID="txtMARCA" runat="server" CssClass="txt" Enabled="false" Width="195px"></asp:TextBox>
                    </td>
                    <td class="style11" colspan="2" rowspan="1">
                        Modelo:<asp:TextBox ID="txtMODELO" runat="server" CssClass="txt" Enabled="false" Width="195px"></asp:TextBox>
                        &nbsp;</td>
                    <td class="style10">Color:<asp:TextBox ID="txtCOLOR" runat="server" CssClass="txt" Enabled="false" Width="195px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="PnlPReguntas" CssClass="div2">
            <table>
                <tr>
                    <td >
                        <asp:Label runat="server" ID="LblLeyenda" Text=""
                            Style="text-align: center"></asp:Label>
                    </td>
                </tr>
            </table>
            <table bgcolor="Silver">
                <tr>
                    <td >
                        <asp:Label runat="server" ID="Lblpregunta1" Text="" ></asp:Label>
                    </td>
                   
                </tr>
            </table>
            <table>
                <tr>
                    <td class="style5">
                        <asp:DataGrid ID="dgPreguntas" runat="server" AutoGenerateColumns="False" 
                            BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" GridLines="Horizontal" 
                            ShowHeader="False" CellPadding="7" CssClass="grd100" CellSpacing="3">
                            <ItemStyle Font-Size="11px" />
                            <Columns>
                                <asp:BoundColumn DataField="ID_PREGUNTA" HeaderText="" Visible="false" />
                                 <asp:TemplateColumn>
                                    <ItemTemplate>
                                    <asp:PlaceHolder ID="PLHOLDERTXT" runat="server">
                                    <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label>
                                    <br />
                                    
                                    </asp:PlaceHolder>
                                         
                                    </ItemTemplate>
                                    <ItemStyle BackColor="#F8F8FC" Font-Bold="True" Font-Italic="False" 
                                        Font-Names="Arial" Font-Overline="False" Font-Size="12px" 
                                        Font-Strikeout="False" Font-Underline="False" CssClass="grd70"  />
                                </asp:TemplateColumn>
                                
                                   
                                 
                                     <asp:BoundColumn DataField="tcontrol" HeaderText="" Visible="false" />
                                   <asp:BoundColumn DataField="opciones" HeaderText="" Visible="false" />
                                  
                                <asp:TemplateColumn>
                                    <ItemTemplate>
                                    <asp:PlaceHolder ID="PLHOLDER" runat="server">
                                    
                                    </asp:PlaceHolder>
                                         
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="12px" />
                                </asp:TemplateColumn>
                            </Columns>
                            <HeaderStyle Font-Names="Courier New" Wrap="True" />
                            <FooterStyle Font-Size="11px" />
                            <AlternatingItemStyle BorderColor="White" />
                        </asp:DataGrid>
                    </td>
                   
                </tr>
                 
                 
                </table>
                <asp:Panel ID="pnlAdicionales" runat="server">
                
              
               
                <table>
               
                <tr><td>   &nbsp;</td></tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblObservacionesSeg" Text="Observaciones Seguimiento"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtObservacionesSeg" Width="825px" Height="30px" CssClass="lstM" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                    <td>
                        <asp:Label runat="server" ID="lblObservacionesGer" Text="Observaciones Gerencia"></asp:Label>
                    </td>
                </tr>
              
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtObservacionesGer" Width="825px" Height="30px" CssClass="lstM" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>     
                <tr>
                <td>  
        
                                        
                                      
                                        
                                         
                                        </td>
                                        
                                    </tr>
                
                </table>
                </asp:Panel>
                
                   <asp:Panel ID="pnlFooter" runat="server" HorizontalAlign="Center">
                <table class="grd100">
                <tr><td>   &nbsp;</td></tr>
                <tr><td>   &nbsp;</td></tr>
               
               
            </table>
            </asp:Panel>
        </asp:Panel>
        
         <asp:Panel ID="pnlGuardar" runat="server" HorizontalAlign="Center">
                 
                
                 
                          <table>
                   <tr>
                     <td>  <asp:Label runat="server" ID="lblEstatusLlamada" Text="Estatus"></asp:Label>
                            <asp:DropDownList ID="cboEstatusLlamada" runat="server" Font-Size="11px"   Width="150px">
                               <asp:ListItem Text="--" Value=""></asp:ListItem>
                                <asp:ListItem Text="Contactado" Value="Contactado"></asp:ListItem>
                                <asp:ListItem Text="Recado" Value="Recado"></asp:ListItem>
                                 <asp:ListItem Text="Mensaje de texto" Value="Mensaje de texto"></asp:ListItem>
                                <asp:ListItem Text="Volver a llamar" Value="Volver a llamar"></asp:ListItem>
                                <asp:ListItem Text="No contactado" Value="No contactado"></asp:ListItem>
                                 <asp:ListItem Text="No autoriza llamada" Value="No autoriza llamada"></asp:ListItem>
                            </asp:DropDownList>
                                           </td>
                                        <td align="center">  <asp:TextBox ID="txtFechaEstatus" runat="server" Visible="true" ReadOnly="true" CssClass="cboM"></asp:TextBox>
                                             <ajaxToolkit:CalendarExtender runat="server" id="txtFechaEstatusEx" TargetControlID="txtFechaEstatus" Format="dd/MM/yyyy" PopupButtonID="txtFechaEstatus"></ajaxToolkit:CalendarExtender>
                                                    
                                              </td>
                                                
                                        </tr>
                                     <tr>
                    <td align="center">
                        <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" cssclass="cmd"/>
                    </td>
                    <td>
                                        <asp:Button ID="cmdVOC" runat="server" cssclass="cmd"
                                         Text="Cuestionario Quejas" Style="display:none;" />
                                        </td>
                </tr>
                </table></asp:Panel>
    </div>
    </form>
</body>
</html>
