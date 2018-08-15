<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Recepcion_mazda.aspx.vb" Inherits="TablerosV2.Recepcion_mazda" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="refresh" content="120" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Recepcion</title>
	<link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
	<link rel="stylesheet" href="css/StylosRecepcion.css" />
	<script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
	<script src="Bootstrap/js/bootstrap.min.js"></script>
	<script type="text/javascript">
		//function mreloj() {
		//	var momentoActual = new Date();
		//	var hora;
		//	var minutos
		//	//HORA
		//	try {
		//		hora = momentoActual.getHours()
		//		minutos = momentoActual.getMinutes()
		//		if (minutos < 10) { minutos = '0' + minutos }
		//		if (hora < 12) {
		//			hora = hora + ':' + minutos + ' a.m';
		//		}
		//		else {
		//			if (hora > 12) {
		//				hora = (hora - 12) + ':' + minutos + ' p.m'
		//			}
		//			else { hora = hora + ':' + minutos + ' p.m' }
		//		}
		//		document.getElementById("nreloj").textContent = hora;
		//	}
		//	catch (e) { alert(e.toString()); }
		//	setTimeout("mReloj()", 1000)
		//	//==---------------------------------
		//	//mes y dia
		//	let dias = ["LUNES", "MARTES", "MIERCOLES", "JUEVES", "VIERNES", "SABADO", "DOMINGO"];
		//	let meses = ["ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"];
		//	var mes = meses[momentoActual.getMonth()]
		//	var dia = dias[momentoActual.getDay() - 1]
		//	document.getElementById("nMes").textContent = mes + ' ' + momentoActual.getDate() + ', ' + dia;
		//}


	</script>
</head>
<body onload="mreloj()">
	<form id="form1" runat="server">
		<asp:ScriptManager runat="server" ID="ScriptManager1"
			EnablePartialRendering="true" AsyncPostBackTimeout="600" />
		<!-- Este Timer es para dg1, dgLibres y modal -->
		<asp:Timer ID="Timer1" runat="server" Interval="20000" Enabled="true"></asp:Timer>
		<asp:Timer ID="Timer5" runat="server" Enabled="false" Interval="120000"></asp:Timer>
		<!-- Por codigo en el on_load de la pagina o en el init le pones un valor a ese hidden field -->

		<div id="divCuerpototal" class="container" style="width: 100%; height: 100%; background-color: black;">
			<!--header de la pagina -->
			<div id="divHeader" class="divHeader">
				<%--logo mazda--%>
				<div id="divLogoMazda" class="divLogoMazda">
					<asp:Image
						ID="imgLogoMazda"
						runat="server"
						ImageUrl="~/img/imgLogoMazda.png"
						class="imgLogoMazda" />
				</div>
				<%--reloj y hora--%>
				<div id="divFechaHora" class="divFechaHora">
					<div id="divFechaH" class="divreloj">
						<div id="divHora" class="divhora">
							<asp:Label
								runat="server"
								type="text"
								ID="nreloj"
								name="nreloj"
								size="20"
								class="reloj" readonly="true" />
						</div>
						<div id="divmesAno" class="mes">
							<asp:Label
								runat="server"
								type="text"
								ID="nMes"
								name="nMes"
								class="nmes" readonly="true"
								style="font-family:inter"/>
							<asp:Label
								runat="server"
								type="text"
								ID="nDia"
								name="nDia"
								class="ndia" readonly="true" />

						</div>



					</div>
				</div>
				<%--logo empresa--%>
				<div id="divLogoEmpresa" class="divLogoEmpresa">
					<asp:Image
						ID="imgLogoEmpresa"
						runat="server"
						ImageUrl="~/img/AgenciaLogoHeader.png"
						class="imgLogoAgencia" />
				</div>
			</div>
			<!--Hasta acá-->
			<%--CUERPO TABLA DE CITAS Y ESO--%>
			<div id="divCuerpo" class="divcuerpo">
				<div id="divTitulo" class="divTitulo">
					<asp:Label
						ID="lblTitulo"
						runat="server"
						Text="CONOCE EL ESTADO DE TU CITA"
						CssClass="label1">
					</asp:Label>
				</div>
				<div id="divInFocitas" class="divinfocitas">
					<asp:UpdatePanel runat="server" ID="pnlCItas" UpdateMode="Conditional">
						<ContentTemplate>
							<asp:Timer ID="Timer11" Interval="20000" Enabled="true" runat="server">
							</asp:Timer>
							<asp:DataGrid
								runat="server"
								ID="gridInfoCitas"
								AutoGenerateColumns="false"
								BorderColor="#C3C3C3"
								AllowPaging="true"
								page-size="15"
								GridLines="Vertical"
								CssClass="table-responsive table-condensed griccitas">
								<HeaderStyle BackColor="#a02d2d" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
								<ItemStyle ForeColor="#C3C3C3" HorizontalAlign="Center"/>
								<PagerStyle Visible="false" />
								<Columns>
									<asp:BoundColumn DataField="HORAASESOR" HeaderText="HORA" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="VEHICULO" HeaderText="UNIDAD" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="NOPLACAS" HeaderText="PLACA" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="CLIENTE" HeaderText="CLIENTE" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="NOMBRE_EMPLEADO" HeaderText="ASESOR" ReadOnly="true" Visible="true" FooterStyle-ForeColor="#a02d2d"></asp:BoundColumn>
									<asp:BoundColumn DataField="HORARECEPCION" HeaderText="LLEGADA" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="ESTADO" HeaderText="ESTADO" ReadOnly="true" Visible="true" FooterStyle-ForeColor="#a02d2d"></asp:BoundColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:Image runat="server"
												ID="imgDemorado"
												AlternateText="ROJO"
												Style="display: none; color: red;"
												ImageUrl="~/img/img_smf_rojo.png"
												CssClass="imagen" />
											<asp:Image
												runat="server"
												ID="imgATiempo"
												AlternateText="verde"
												Style="display: none; color: green;"
												ImageUrl="~/img/img_smf_verde.png"
												CssClass="imagen" />
											<asp:Image runat="server"
												ID="imgRetrasado"
												AlternateText="naranja"
												Style="display: none; color: orange"
												ImageUrl="~/img/img_smf_naranja.png"
												CssClass="imagen" />
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid>
						</ContentTemplate>
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
						</Triggers>
					</asp:UpdatePanel>
				</div>
			</div>
			<%--HASTA ACÁ--%>
			<div id="divPie" class="divPie">
				<asp:Label runat="server" ID="lblPie" Text="" CssClass="lblpie"></asp:Label>
			</div>
		</div>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate />
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
			</Triggers>
		</asp:UpdatePanel>
	</form>
</body>
</html>
