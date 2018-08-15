<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TblNoShow.aspx.vb" Inherits="TablerosV2.TblNoShow" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>No Show</title>
	<link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
	<script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
	<script src="Bootstrap/js/bootstrap.min.js"></script>
	<script type="text/javascript">
		function salir() {
			alert("mensaje de alerta");
			var obj = document.getElementById("imgDetalle");
			if (obj) {
				obj.click();
			}
		}

		$.expr[':'].icontains = function (obj, index, meta, stack) {
			return (obj.textContent || obj.innerText || jQuery(obj).text() || '').toLowerCase().indexOf(meta[3].toLowerCase()) >= 0;
		};
		$(document).ready(function () {
			$('#buscador').keyup(function () {
				buscar = $(this).val();
				var jo1 = $("#GridCuerpoAsesores").find("tr");
				if (jQuery.trim(buscar) != '') { jo1.parents('tr').hide(); } else { jo1.parents('tr').show(); }

				$('#GridCuerpoAsesores tr').removeClass('resaltar');
				if (jQuery.trim(buscar) != '') {
					$("#GridCuerpoAsesores td:icontains('" + buscar + "')").addClass('resaltar');
					var jo = $("#GridCuerpoAsesores td:icontains('" + buscar + "')").parents('tr');
					jo.show();
				}
			});		
		});


	</script>
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
					<li class="active"><a href="tblNoShow.aspx">No Shows</a></li>
					<li><a href="Prepickin.aspx">Prepikin</a></li>
					
				</ul>
				<ul class="nav navbar-nav navbar-right">
					<li><a href="inicio.aspx"><span class="glyphicon glyphicon-arrow-left"></span>Salir</a></li>
				</ul>
			</div>
		</nav>
		<div id="DIvHeader" class="page-header" style="width: 100%; height: 30%; position: relative;">
			<div class="form-inline">
				<h1>NO SHOWS
                    <small>Informacion de Personas que no asistieron</small>
				</h1>

			</div>
		</div>
		<div>
			<div id="DivHeader" class="form-inline" style="width: 100%; position: relative; padding: 2em;">
				<div id="divCmdAsesores" class="form-group container">					
					<asp:TextBox ID="txtFechaEntrada" placeholder="Fecha Entrada" runat="server" CssClass=" form-control" OnTextChanged="txtFechaEntrada_TextChanged" AutoPostBack="true"></asp:TextBox>
					<ajaxtoolkit:CalendarExtender
						runat="server"
						ID="cldFechaEntrada"
						TargetControlID="txtFechaEntrada"
						PopupButtonID="txtFechaEntrada"
						Format="dd/MM/yyyy">
					</ajaxtoolkit:CalendarExtender>					
				</div>
			</div>
			<div id="DivCuerpo" class="auto-style3" style="padding: 2em;">
				<asp:DataGrid runat="server" ID="GridCuerpoAsesores" CssClass="table-responsive table-condensed"
					AutoGenerateColumns="false" Width="100%">
					<HeaderStyle BackColor="#034EC6" ForeColor="White" HorizontalAlign="Center" />
					<ItemStyle ForeColor="Black" HorizontalAlign="Center" />
					<Columns>				
						<asp:BoundColumn DataField="id_hd" HeaderText="id" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="noplacas" HeaderText="Placas" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="numcita" HeaderText="Cita" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="cliente" HeaderText="Cliente" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="contactoNombre" HeaderText="Email" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="ContactoTelefono" HeaderText="Telefono" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="Fecha_hora_cita" HeaderText="Fecha" ReadOnly="true" Visible="true"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
			</div>
		</div>
	</form>
</body>
</html>
