<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Prepickin.aspx.vb" Inherits="TablerosV2.Prepickin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<link rel="stylesheet" href="css/generales.css" />
	<link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
	<script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
	<script src="Bootstrap/js/bootstrap.min.js"></script>
	<style type="text/css">
		.grd {
			width: 90%;
		}
	</style>
</head>
<body style="background-image: url(img/zoomzoom.JPG);">
	<form id="form1" runat="server">
		<ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />
		<nav class="navbar navbar-default">
			<div class="container-fluid">
				<div class="navbar-header">
					<a class="navbar-brand" href="Inicio.aspx">INICIO</a>
				</div>
				<ul class="nav navbar-nav">
					<li><a href="tblNoShow.aspx">No Shows</a></li>
					<li class="active"><a href="Prepickin.aspx">Prepikin</a></li>
					
				</ul>
				<ul class="nav navbar-nav navbar-right">
					<li><a href="inicio.aspx"><span class="glyphicon glyphicon-arrow-left"></span>Salir</a></li>
				</ul>
			</div>
		</nav>
		<div style="">
			<table style="width: 100%;">
				<tr>
					<td>
						<img id="IMG1" runat="server" src="~/img/agencialogoheader.png" style="width: 40%; height: 40%;" /></td>
					<td>
						<asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="False" Font-Names="Arial"
							Font-Size="Large" ForeColor="Navy" Text="PrePicking" Width="176px"></asp:Label></td>
					<td>
						<asp:ImageButton ID="imgSalir" runat="server" AlternateText="Salir"
							ImageUrl="img/logout.png" /></td>
				</tr>
			</table>



		</div>
		<div style="z-index: 100;">


			<table style="width: 50%;">
				<tr>


					<td>Fecha:
                    <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
						<ajaxToolkit:CalendarExtender runat="server" ID="txtFechaex" TargetControlID="txtFecha" Format="dd/MM/yyyy" PopupButtonID="txtFecha"></ajaxToolkit:CalendarExtender>

						<asp:Button ID="cmdAgregar" runat="server" Text="Consultar" />

					</td>
					<td>&nbsp;</td>
					<td>
						<asp:Button ID="cmdExport" runat="server" Text="Exportar" />
					</td>
				</tr>
			</table>
		</div>
		<div>
			<asp:DataGrid ID="dgAusencias" runat="server" Font-Size="12px" GridLines="None"
				CellPadding="4" ForeColor="#333333" CssClass="CSSTableGenerator" AutoGenerateColumns="false">
				<EditItemStyle BackColor="#999999" Font-Names="Arial" />
				<AlternatingItemStyle BackColor="White" Font-Names="Arial" />
				<ItemStyle BackColor="#F7F6F3" Font-Names="Arial" />
				<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
				<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="11px" ForeColor="White"
					Font-Names="Arial" />
				<Columns>
					<asp:BoundColumn DataField="numcita" HeaderText="Cita" Visible="true" />
					<asp:BoundColumn DataField="fecha_M" HeaderText="Fecha" Visible="true" />
					<asp:BoundColumn DataField="hora" HeaderText="Hora" Visible="true" />
					<asp:BoundColumn DataField="asesor" HeaderText="Asesor" Visible="true" />
					<asp:BoundColumn DataField="placas" HeaderText="Placa" Visible="true" />
					<asp:BoundColumn DataField="cliente" HeaderText="Cliente" Visible="true" />
					<asp:BoundColumn DataField="modelo" HeaderText="Vehiculo" Visible="true" />
					<asp:BoundColumn DataField="vin" HeaderText="Vin" Visible="true" />
					<asp:BoundColumn DataField="tecnico" HeaderText="Tecnico" Visible="true" />
					<asp:BoundColumn DataField="telefono" HeaderText="Telefono" Visible="true" />
					<asp:BoundColumn DataField="repuestose" HeaderText="Repuestos" Visible="True" />
					<asp:BoundColumn DataField="observaciones" HeaderText="Observaciones" Visible="true" />
				</Columns>
				<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
				<SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />

			</asp:DataGrid>
		</div>
	</form>
</body>
</html>
