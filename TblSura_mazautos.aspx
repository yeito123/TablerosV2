<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TblSura_mazautos.aspx.vb" Inherits="TablerosV2.TblSura_mazautos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Sura</title>
	<link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
	<script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
	<script src="Bootstrap/js/bootstrap.min.js"></script>
</head>
<body style="margin-bottom: 0">
	<form id="form1" runat="server" class="form-inline">
		<ajaxtoolkit:ToolkitScriptManager ID="ScripManager1" runat="server"></ajaxtoolkit:ToolkitScriptManager>
		<nav class="navbar navbar-default">
			<div class="container-fluid">
				<div class="navbar-header">
					<a class="navbar-brand" href="Inicio.aspx">INICIO</a>
				</div>
				<ul class="nav navbar-nav">
					<li class="active"><a href="tblestados.aspx">Estados</a></li>
					<li><a href="TblSura_mazautos.aspx">Interfaz Sura</a></li>
				</ul>
				<ul class="nav navbar-nav navbar-right">
					<li><a href="inicio.aspx"><span class="glyphicon glyphicon-arrow-left"></span>Salir</a></li>
				</ul>
			</div>
		</nav>
		<div id="DIvHeader" class="page-header" style="width: 100%; height: 30%; position: relative;">
			<div class="form-inline">
				<h1>Tablero de estados
                    <small>Interfaz Sura</small>
				</h1>

			</div>
		</div>
		<div>
			<div id="DivHeader" class="form-inline" style="width: 100%; position: relative; padding: 2em;">
				<div id="divCmdAsesores" class="form-group container">
					<asp:Button runat="server" ID="btnConsultar" Text="Generar archivo y enviar" CssClass="btn-primary form-control" />
					<div class="col-sm-4 form-inline">
						<div class="form-group">
							<label>Buscar:</label>
							<input name="buscador" id="buscador" class="form-control input-sm" type="text" />
						</div>
					</div>
				</div>
			</div>
			<div id="DivCuerpo" class="auto-style3" style="padding: 2em;">
				<asp:DataGrid runat="server" ID="GridCuerpoAsesores" CssClass="table-responsive table-condensed"
					AutoGenerateColumns="false" Width="100%">
					<HeaderStyle BackColor="#034EC6" ForeColor="White" HorizontalAlign="Center" />
					<ItemStyle ForeColor="Black" HorizontalAlign="Center" />
					<Columns>
						<asp:BoundColumn DataField="nit" HeaderText="Nit" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="plate" HeaderText="Plate" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="sinister" HeaderText="Sinister" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="status" HeaderText="Status" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="date" HeaderText="Date" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="time" HeaderText="Time" ReadOnly="true" Visible="true"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
			</div>
		</div>

	</form>
</body>
</html>
