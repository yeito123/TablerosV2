<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="tblOrganigrama.aspx.vb" Inherits="TablerosV2.tblOrganigrama" %>

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
			

	</script>
</head>
<body onload="mreloj()">
	<form id="form1" runat="server">
		<asp:ScriptManager runat="server" ID="ScriptManager1"
			EnablePartialRendering="true" AsyncPostBackTimeout="600" />
		<asp:Timer ID="Timer5" runat="server" Enabled="true"></asp:Timer>
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
								class="reloj" readonly="true"
								/>
						</div>
						<div id="divmesAno" class="mes">
							<asp:label
								runat="server"
								type="text"
								id="nMes"
								name="nMes"
								class="nmes" readonly="true"
								/>
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
				<%--<div id="divTitulo" style="background-color: #a02d2d; height: 7%; top: 5%; text-align: center; width: 30%; left: 35%; position: absolute;">
					<asp:Label
						ID="lblTitulo"
						runat="server"
						Text="AVANCE DEL VEHICULO EN EL TALLER"
						CssClass="label1">
					</asp:Label>
				</div>--%>
				<div id="divInFocitas" class="divorganigrama">
					<div id="divMapa" class="divorg">
						<div id="myCarousel" class="carousel slide"  data-ride="carousel">
							<!-- Indicators -->
							<ol class="carousel-indicators">
								<li data-target="#myCarousel" data-slide-to="0" class="active"></li>
								<li data-target="#myCarousel" data-slide-to="1"></li>
								<li data-target="#myCarousel" data-slide-to="2"></li>
								<li data-target="#myCarousel" data-slide-to="3"></li>
								<li data-target="#myCarousel" data-slide-to="4"></li>
								<li data-target="#myCarousel" data-slide-to="5"></li>
								<%--<li data-target="#myCarousel" data-slide-to="6"></li>
								<li data-target="#myCarousel" data-slide-to="7"></li>--%>
							</ol>

							<!-- Wrapper for slides -->
							<div class="carousel-inner">
								<div class="item active">
									<img src="img/O_1.PNG" alt="Los Angeles">
								</div>

								<div class="item">
									<img src="img/O_2.PNG" alt="Chicago">
								</div>

								<div class="item">
									<img src="img/O_3.PNG" alt="New York">
								</div>
								<div class="item">
									<img src="img/O_4.PNG" alt="New York">
								</div>
								<div class="item">
									<img src="img/O_5.PNG" alt="New York">
								</div>
								<div class="item">
									<img src="img/O_6.PNG" alt="New York">
								</div>
								<%--<div class="item">
									<img src="img/O_7.PNG" alt="New York">
								</div>
								<div class="item">
									<img src="img/O_8.PNG" alt="New York">
								</div>--%>
							</div>

							<!-- Left and right controls -->
							<a class="left carousel-control" href="#myCarousel" data-slide="prev">
								<span class="glyphicon glyphicon-chevron-left"></span>
								<span class="sr-only">Previous</span>
							</a>
							<a class="right carousel-control" href="#myCarousel" data-slide="next">
								<span class="glyphicon glyphicon-chevron-right"></span>
								<span class="sr-only">Next</span>
							</a>
						</div>
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
