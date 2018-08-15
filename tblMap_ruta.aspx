<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="tblMap_ruta.aspx.vb" Inherits="TablerosV2.tblMap_ruta" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Ruta</title>
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
		//		document.getElementById("nreloj").value = hora;
		//	}
		//	catch (e) { alert(e.toString()); }
		//	setTimeout("mReloj()", 1000)
		//	//==---------------------------------
		//	//mes y dia
		//	let dias = ["LUNES", "MARTES", "MIERCOLES", "JUEVES", "VIERNES", "SABADO", "DOMINGO"];
		//	let meses = ["ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"];
		//	var mes = meses[momentoActual.getMonth()]
		//	var dia = dias[momentoActual.getDay() - 1]
		//	document.getElementById("nMes").value = mes + ' ' + momentoActual.getDate() + ', ' + dia;
		//}

		function myMap() {
			var mapOptions = {
				center: new google.maps.LatLng(10.9838039, -74.8882304),
				zoom: 10,
				mapTypeId: google.maps.MapTypeId.ROADMAP
			}
			var map = new google.maps.Map(document.getElementById("divMapa"), mapOptions);
		}

	</script>
</head>
<body onload="mreloj()">
	<form id="form1" runat="server">
		<asp:ScriptManager runat="server" ID="ScriptManager1"
			EnablePartialRendering="true" AsyncPostBackTimeout="600" />
		<asp:Timer ID="Timer5" runat="server" Enabled="true" Interval="120000" OnTick="timer5_tick"></asp:Timer>
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
							<asp:label
								runat="server"
								type="text"
								id="nreloj"
								name="nreloj"
								size="20"
								class="reloj" readonly="true" />
						</div>
						<div id="divmesAno" class="mes">
							<asp:label
								runat="server"
								type="text"
								id="nMes"
								name="nMes"
								class="nmes" readonly="true" />
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
				<div id="divTitulo" style="background-color: #a02d2d; height: 7%; top: 5%; text-align: center; width: 30%; left: 35%; position: absolute;">
					<asp:Label
						ID="lblTitulo"
						runat="server"
						Text="MAPA PRUEBA DE RUTA"
						CssClass="label1">
					</asp:Label>
				</div>
				<div id="divInFocitas" class="divMapaRuta">
					<div id="divMapa" class="imgmapa">
						<asp:Image
							runat="server"
							ImageUrl="~/img/imgMapaRuta.png"
							Width="900"
							Height="350"
							Style="border: 0; position: absolute; left: 10%; top: 5%"></asp:Image>
					</div>

				</div>
			</div>
			<%--HASTA ACÁ--%>
			<div id="divPie" class="divPie">
				<asp:Label runat="server" ID="lblPie" Text="" CssClass="lblpie"></asp:Label>
			</div>
		</div>


	</form>
</body>
</html>
