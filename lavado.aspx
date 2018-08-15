<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Lavado.aspx.vb" Inherits="TablerosV2.Lavado" %>
 
  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Taller de lavado</title>
	<link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
    <script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
        
     <script type="text/javascript" src="Bootstrap/js/jquery-ui.js"></script>
    <link rel="stylesheet" href="Bootstrap/css/jquery-ui.css" />    
       
     <script type="text/javascript">
        $(document).ready(function () {
                 
			     $('#txtModFecha').datepicker({
				 
                dateFormat: 'dd/mm/yy',
                onSelect: function (datetext) {
				 
                    var d = new Date(); // for now

                    var h = d.getHours();
                    h = (h < 10) ? ("0" + h) : h;

                    var m = d.getMinutes();
                    m = (m < 10) ? ("0" + m) : m;

             

                    datetext = datetext + " " + h + ":" + m ;
					 
                    $('#txtModFecha').val(datetext);
					 
					 
                }
            });
          
        });
		</script>
    <meta http-equiv="refresh" content="60" />

    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="TextBox3" 
        PopupControlID="ModalPanel"  Enabled="true" Drag="true" CancelControlID="CmdCancecalr">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="ModalPanel" runat="server" Width="522px" BorderColor="#C3C4C7" BackColor="#273A56" BorderStyle="Solid" >
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" horizntalAlign="center" BackColor="#273A56" ForeColor="White" Visible="False"
                        Width="192px" Height="24px"></asp:Label>
                </td>
            </tr>
		 
        </table>

		<asp:Panel runat="server" ID="Panelfecha">
            <table  >
                <tr>
                     
                    <td>
				<asp:TextBox runat="server" ID="txtMod" TextMode="MultiLine" Width="300px" style="display:block;"></asp:TextBox> 
    <asp:TextBox runat="server" ID="txtModFecha"  Width="300px" style="display:block;" Visible="false"></asp:TextBox> 
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="PnlParo">
            <table  >
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server"  BackColor="#273A56" ForeColor="White" Text="Motivo de paro lavado"
                            Visible="False" Width="192px" Height="24px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Visible="False" Width="192px"
                            Height="24px">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="PnlFin">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" BackColor="#273A56" ForeColor="White" Text="Clase de estacionamiento"
                            Width="160px" Visible="False" ></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                            Width="223px" Height="20px" Visible="False" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" BackColor="#273A56" ForeColor="White" Text="No. de estacionamiento"
                            Visible="False" Width="160px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList4" runat="server" Visible="False" Width="221px"
                            Height="16px">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelIni" BorderColor="Silver" BorderStyle="Solid">
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="LblCboLavadores" Text="Lavador: " BackColor="#273A56"
                            ForeColor="White" Width="130px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="CboLAvadores" Width="250px">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table>
            <tr>
                <td>
                    <asp:Button ID="OKButton" runat="server" Text="OK" OnClick="OKButton_Click" Width="265px" />
                </td>
                <td>
                    <asp:Button ID="CmdCancecalr" runat="server" Text="Cancelar" Width="245px" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="PnlPleca" BorderColor="#273A56" BorderStyle="Solid">
        <table style="width: 100%;">
            <tr>
                <td>
                       <img  alt="" src="img/AgenciaLogoHeader.PNG" id="imgLogo1" runat="server" style="position: relative;z-index: 3003;height:4em; " />
                </td>
                <td>
                    <asp:Label ID="LblEnca" runat="server" Font-Bold="true" Font-Size="Larger" ForeColor="#273A56"
                        Style="font-size: xx-large" Text="Taller de Lavado"></asp:Label>
                </td>
                <td align="right">
                    <asp:ImageButton ID="ImageButton5" runat="server" AlternateText="Regresar" ImageUrl="~/IMG/logout.png"
                        Width="51px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Menu ID="Menu1" Width="168px" runat="server" DynamicMenuItemStyle-BorderColor="White"
        DynamicHoverStyle-BorderStyle="Solid" Orientation="Horizontal" BorderColor="White"
        BorderStyle="Solid" StaticEnableDefaultPopOutImage="true" OnMenuItemClick="Menu1_MenuItemClick">
        <Items>
            <asp:MenuItem ImageUrl="~/IMG/CmdGral.jpg" Text=" "  Value="0"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/IMG/CmdFinalizados.jpg" Text=" " Value="1"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/IMG/CmdCancelados.jpg" Text=" " Value="2"></asp:MenuItem>
        </Items>
    </asp:Menu>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="Tab1" runat="server">
            <table style="width=600;heigth=400;" cellpadding="0" cellspacing="0">
                <tr valign="top">
                    <td class="TabArea" style="width: 600px">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1247px"
                                        Height="1px" AllowPaging="fALSE" BackColor="White" ForeColor="Black">
                                        <HeaderStyle BackColor="#273A56" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="" 
                                                  Visible="true" >
                                                <ItemStyle HorizontalAlign="Center" cssclass="cssdnone" Width="0px"  />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="num_pre_orden" HeaderText="num_pre_orden" SortExpression="num_pre_orden"
                                                Visible="False" ReadOnly="True">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Num_OS" HeaderText="Num OS" SortExpression="Num OS" ReadOnly="True">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Id_Operacion" HeaderText="Operacion" SortExpression="Operacion"
                                                Visible="False" ReadOnly="True">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="id_tecnico" HeaderText="id_tecnico" SortExpression="tecnico"
                                                Visible="False" ReadOnly="True">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Status" HeaderText="NumTorre" SortExpression="NumTorre"
                                                ReadOnly="True" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ReadOnly="True">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fecha_Ini_oracion" HeaderText="fecha_Ini_oracion" SortExpression="fecha_Ini_oracion"
                                                Visible="False" ReadOnly="True">
                                                <ItemStyle HorizontalAlign="Center" Width="180px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Fecha_Hora_ini_Oper" HeaderText="Fecha Hora Inicio" SortExpression="Fecha Hora Inicio"
                                                ReadOnly="True">
                                                <ItemStyle HorizontalAlign="Center" Width="180px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fecha_Hora_Fin_Oper" HeaderText="Fecha Hora Fin" SortExpression="fecha Hora Fin"
                                                ReadOnly="True">
                                                <ItemStyle HorizontalAlign="Center" Width="180px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fecha_Hora_Paro" HeaderText="Fecha Hora Paro" SortExpression="Fecha Hora Paro"
                                                ReadOnly="True" Visible="FALSE">
                                                <ItemStyle HorizontalAlign="Center" Width="180px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fecha_hora_reinicio" HeaderText="Fecha Hora Reinicio"
                                                SortExpression="Fecha Hora Reinicio" ReadOnly="True" Visible="FALSE">
                                                <ItemStyle HorizontalAlign="Center" Width="180px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="id_hd" HeaderText="idhd" SortExpression="id_hd"
                                                Visible="true" ReadOnly="true">
                                                
                                            </asp:BoundField>
                                            <asp:BoundField DataField="modelo" HeaderText="Modelo" SortExpression="Modelo" ReadOnly="True">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" ReadOnly="True">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Status_Os" HeaderText="" SortExpression="Status Os"
                                                ReadOnly="True">
                                                <ItemStyle HorizontalAlign="Center" Width="0px"  />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="colorPrisma" HeaderText="Numero de Torre" SortExpression="numero de Torre"
                                                ReadOnly="True">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="Fecha_hora_com" HeaderText="Fecha Hora Com" SortExpression="Fecha  Hora Com"
                                                ReadOnly="True" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" Width="180px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Cliente_Espera" HeaderText="C E" SortExpression="Cliente Espera"
                                                ReadOnly="True" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="Asesor" HeaderText="Asesor" SortExpression="Asesor"
                                                ReadOnly="True" Visible="true">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color"
                                                ReadOnly="True" Visible="true">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

											 


											<asp:TemplateField HeaderText="FechaHoraPromesa" SortExpression="Eliminar" Visible="true">
                                                
                                                <ItemTemplate>
                                                   <asp:LinkButton runat="server" ID="lnkFechaCita" AutoPostBack="true"  
                                                 Text='<%# If (IsDBNull(Eval("FechaHoraPromesa")),"ninguna",Eval("FechaHoraPromesa"))  %>'     OnClick="LinkButton1_Click"     />
                                                
                                                </ItemTemplate>
                                            </asp:TemplateField>


											 
										 
                                           
                                             <asp:BoundField DataField="noorden" HeaderText="TLavado" SortExpression="Observaciones"
                                                ReadOnly="True" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

											 

                                             <asp:BoundField DataField="fecha" HeaderText="" SortExpression=""
                                                ReadOnly="True" Visible="true">
                                                <ItemStyle Width="1px" cssclass="cssdnone" HorizontalAlign="Center" />
                                            </asp:BoundField>
											 
											
											<asp:TemplateField HeaderText="Comentarios" SortExpression="Eliminar" Visible="true">
                                                
                                                <ItemTemplate>
                                                   <asp:LinkButton runat="server" ID="lnkModComentarios" AutoPostBack="true"  
                                                 Text='<%# If (IsDBNull(Eval("comentarioslavado")),"ninguna",Eval("comentarioslavado"))  %>'     OnClick="LinkButton2_Click"     />
                                                
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Ini" SortExpression="Iniciar" Visible="false">
                                                <EditItemTemplate>
                                                    &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" />
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Style="position: static"
                                                        Enabled="False" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fin" SortExpression="Finalizar" Visible="false">
                                                <EditItemTemplate>
                                                    &nbsp;<asp:CheckBox ID="CheckBox2" runat="server" />
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Style="position: static"
                                                        Enabled="False" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fin" SortExpression="Eliminar" Visible="false">
                                                <EditItemTemplate>
                                                    &nbsp;<asp:CheckBox ID="CheckBox3" runat="server" />
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" Style="position: static"
                                                        Enabled="False" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton runat="server" ID="ImgIniciar" ImageUrl="~/IMG/Verde.JPG" ToolTip="Iniciar"
                                                                    OnClick="ImgIniciar_Click" Width="40px" Height="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton runat="server" ID="ImageFin" ImageUrl="~/IMG/Rojo.JPG" ToolTip="Finalizar"
                                                                    OnClick="ImgFinalizar_Click" Width="40px" Height="40px" />
                                                            </td>
                                                             <td>
                                                                <asp:ImageButton runat="server" ID="imgDelete" ImageUrl="~/IMG/Borrar.JPG" ToolTip="Eliminar"
                                                                    OnClick="ImgBorrar_Click" Width="40px" Height="40px" Visible="false" />
                                                            </td>
                                                           
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="LblINIC" Text="Iniciar"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" ID="LblFinic" Text="Finalizar"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" ID="lblEliminar" Text="Eliminar" Visible="false"></asp:Label>
                                                            </td
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <SelectedRowStyle BackColor="LightGray" />
                                    </asp:GridView>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="Tab2" runat="server">
            <table cellpadding="0" cellspacing="0">
                <tr valign="top">
                    <td>
                        <asp:Panel runat="server" ID="PnlFinish" BorderColor="Silver" BorderStyle="Solid">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="LblGVFinish" Text="Atendidos/Finalizados" ForeColor="Silver"
                                            Font-Size="Large" Font-Bold="true">      
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="LblLAvadoresFinish" Text="Lavador:" ForeColor="Silver"
                                                        BorderColor="Silver" BorderStyle="Solid" Width="113px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="CboLavadoresFinish"  Width="259px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    de:<asp:TextBox ID="txtFec1" runat="server"></asp:TextBox>
                                                     <ajaxToolkit:CalendarExtender runat="server" id="txtFec1Ex" TargetControlID="txtFec1" Format="dd/MM/yyyy" PopupButtonID="txtFec1"></ajaxToolkit:CalendarExtender>
                                                    
                                                </td>
                                                <td>
                                                    al:</td>
                                                <td>
                                                    <asp:TextBox ID="txtFec2" runat="server"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender runat="server" id="txtFec2Ex" TargetControlID="txtFec2" Format="dd/MM/yyyy" PopupButtonID="txtFec2"></ajaxToolkit:CalendarExtender>
                                                    <asp:Button ID="CmdBuscarLavadorFinish" runat="server" BackColor="#BDB1B1" 
                                                        BorderColor="#273A56" ForeColor="#273A56" Text="Filtrar" Width="216px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView runat="server" ID="GvFinish" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="1239px">
                                            <Columns>
                                                <asp:BoundField DataField="id" HeaderText="idItem" InsertVisible="False" ReadOnly="True"
                                                    SortExpression="id" Visible="true" >
                                                    <ItemStyle HorizontalAlign="Center" Width="0px"  CssClass="cssdnone/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="num_pre_orden" HeaderText="num_pre_orden" SortExpression="num_pre_orden"
                                                    Visible="False" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Num_OS" HeaderText="Num OS" SortExpression="Num OS" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Id_Operacion" HeaderText="Operacion" SortExpression="Operacion"
                                                    Visible="False" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_tecnico" HeaderText="id_tecnico" SortExpression="tecnico"
                                                    Visible="False" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="colorPrisma" HeaderText="NumTorre" SortExpression="NumTorre"
                                                    ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fecha_Ini_oracion" HeaderText="fecha_Ini_oracion" SortExpression="fecha_Ini_oracion"
                                                    Visible="False" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fecha_Hora_ini_Oper" HeaderText="Fecha Hora Inicio" SortExpression="Fecha Hora Inicio"
                                                    ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fecha_Hora_Fin_Oper" HeaderText="Fecha Hora Fin" SortExpression="fecha Hora Fin"
                                                    ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fecha_Hora_Paro" HeaderText="Fecha Hora Paro" SortExpression="Fecha Hora Paro"
                                                    ReadOnly="True" Visible="FALSE">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fecha_hora_reinicio" HeaderText="Fecha Hora Reinicio"
                                                    SortExpression="Fecha Hora Reinicio" ReadOnly="True" Visible="false">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_motivo_paro" HeaderText="id_motivo_paro" SortExpression="id_motivo_paro"
                                                    Visible="False" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="modelo" HeaderText="Modelo" SortExpression="Modelo" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Status_Os" HeaderText="Status Os" SortExpression="Status Os"
                                                    ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                
                                            <asp:BoundField DataField="noPrisma" HeaderText="No Torre" SortExpression=""
                                                ReadOnly="True" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                                <asp:BoundField DataField="Fecha_hora_com" HeaderText="Fecha Hora Com" SortExpression="Fecha  Hora Com"
                                                    ReadOnly="True" Visible="false">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cliente_Espera" HeaderText="C E" SortExpression="Cliente Espera"
                                                    Visible="false" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                  <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton runat="server" ID="ImgRetrabajo" ImageUrl="~/IMG/retrabajo.JPG" ToolTip="Iniciar"
                                                                    OnClick="ImgRetrabajo_Click" Width="40px" Height="40px" Visible="false" />
                                                            </td>
                                                            
                                                           
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="LblINIC" Text="Re Lavar" Visible="false"></asp:Label>
                                                            </td>
                                                            
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            </Columns>
                                            <RowStyle ForeColor="#000066" />
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </asp:View>
           <asp:View ID="Tab3" runat="server">
            <table cellpadding="0" cellspacing="0">
                <tr valign="top">
                    <td>
                        <asp:Panel runat="server" ID="PnlFinish1" BorderColor="Silver" BorderStyle="Solid">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="LblGVFinish1" Text="Cancelados" ForeColor="Silver"
                                            Font-Size="Large" Font-Bold="true">      
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                
                                                <td>
                                                    de:<asp:TextBox ID="txtFec11" runat="server"></asp:TextBox>
                                                     <ajaxToolkit:CalendarExtender runat="server" id="txtFec1Ex1" TargetControlID="txtFec11" Format="dd/MM/yyyy" PopupButtonID="txtFec11"></ajaxToolkit:CalendarExtender>
                                                    
                                                </td>
                                                <td>
                                                    al:</td>
                                                <td>
                                                    <asp:TextBox ID="txtFec21" runat="server"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender runat="server" id="txtFec2Ex1" TargetControlID="txtFec21" Format="dd/MM/yyyy" PopupButtonID="txtFec21"></ajaxToolkit:CalendarExtender>
                                                    <asp:Button ID="CmdBuscarLavadorFinish1" runat="server" BackColor="#BDB1B1" 
                                                        BorderColor="#273A56" ForeColor="#273A56" Text="Filtrar" Width="216px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView runat="server" ID="GvFinish1" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="1239px">
                                            <Columns>
                                                <asp:BoundField DataField="id" HeaderText="idItem" InsertVisible="False" ReadOnly="True"
                                                    SortExpression="id" Visible="true" >
                                                    <ItemStyle HorizontalAlign="Center" Width="0px"  CssClass="cssdnone/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="num_pre_orden" HeaderText="num_pre_orden" SortExpression="num_pre_orden"
                                                    Visible="False" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Num_OS" HeaderText="Num OS" SortExpression="Num OS" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Id_Operacion" HeaderText="Operacion" SortExpression="Operacion"
                                                    Visible="False" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_tecnico" HeaderText="id_tecnico" SortExpression="tecnico"
                                                    Visible="False" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="colorPrisma" HeaderText="NumTorre" SortExpression="NumTorre"
                                                    ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fecha_Ini_oracion" HeaderText="fecha_Ini_oracion" SortExpression="fecha_Ini_oracion"
                                                    Visible="False" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fecha_Hora_ini_Oper" HeaderText="Fecha Hora Inicio" SortExpression="Fecha Hora Inicio"
                                                    ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fecha_Hora_Fin_Oper" HeaderText="Fecha Hora Fin" SortExpression="fecha Hora Fin"
                                                    ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fecha_Hora_Paro" HeaderText="Fecha Hora Paro" SortExpression="Fecha Hora Paro"
                                                    ReadOnly="True" Visible="FALSE">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fecha_hora_reinicio" HeaderText="Fecha Hora Reinicio"
                                                    SortExpression="Fecha Hora Reinicio" ReadOnly="True" Visible="false">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_motivo_paro" HeaderText="id_motivo_paro" SortExpression="id_motivo_paro"
                                                    Visible="False" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="modelo" HeaderText="Modelo" SortExpression="Modelo" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Status_Os" HeaderText="Status Os" SortExpression="Status Os"
                                                    ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                
                                            <asp:BoundField DataField="noPrisma" HeaderText="No Torre" SortExpression=""
                                                ReadOnly="True" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                                <asp:BoundField DataField="Fecha_hora_com" HeaderText="Fecha Hora Com" SortExpression="Fecha  Hora Com"
                                                    ReadOnly="True" Visible="false">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cliente_Espera" HeaderText="C E" SortExpression="Cliente Espera"
                                                    Visible="false" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                  <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton runat="server" ID="ImgRetrabajo1" ImageUrl="~/IMG/retrabajo.JPG" ToolTip="Iniciar"
                                                                    OnClick="ImgRetrabajo1_Click" Width="40px" Height="40px" Visible="false" />
                                                            </td>
                                                            
                                                           
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="LblINIC1" Text="Re Lavar" Visible="false"></asp:Label>
                                                            </td>
                                                            
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            </Columns>
                                            <RowStyle ForeColor="#000066" />
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    <asp:TextBox ID="TextBox3" runat="server" Height="1px" Style="z-index: 108; left: 536px;
        position: absolute; top: 2168px" Width="1px">
    </asp:TextBox>
    </form>
</body>
</html>
