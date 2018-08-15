<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TblPullRecepcion.aspx.vb" Inherits="TablerosV2.TblPullRecepcion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	 <meta http-equiv="refresh" content="120" /> 
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
		<asp:Timer ID="Timer5" runat="server" Enabled="true" Interval="120000" OnTick="timer5_tick"></asp:Timer>
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
				<div id="divTitulo" style="background-color: #a02d2d; height: 7%; top: 5%; text-align: center; width: 30%; left: 35%; position: absolute;">
					<asp:Label
						ID="lblTitulo"
						runat="server"
						Text="AVANCE DEL VEHICULO EN EL TALLER"
						CssClass="label1">
					</asp:Label>
				</div>
				<div id="divInFocitas" class="divMapaRuta">
					<div id="divMapa" class="divImgPull">
						<!--Recepcion-->
						<asp:Panel  runat="server" id="divR_101" class="divCarritoH" style="left: 5%; top: 8%;">
							<asp:label runat="server" id="lblR_101" Text="PRUEBA" CssClass="lblPlacah"></asp:label>
						</asp:Panel>
						<asp:panel id="divR_102" runat="server" class="divCarritoH" style="left: 5%; top: 24%;">
							<asp:label runat="server" id="lblR_102" Text="PRUEBA" CssClass="lblPlacah"></asp:label>
						</asp:panel>
						<asp:panel id="divR_103" runat="server" class="divCarritoH" style="left: 5%; top: 44%;">
							<asp:label runat="server" id="lblR_103" Text="PRUEBA" CssClass="lblPlacah"></asp:label>
						</asp:panel>
						<asp:panel id="divR_104" runat="server" class="divCarritoH" style="left: 5%; top: 64%;">
							<asp:label runat="server" id="lblR_104" Text="PRUEBA" CssClass="lblPlacah"></asp:label>
						</asp:panel>
						<asp:panel id="divR_105" runat="server" class="divCarritoH" style="left: 5%; top: 84%;">
							<asp:label runat="server" id="lblR_105" Text="PRUEBA" CssClass="lblPlacah"></asp:label>
						</asp:panel>
						<!--recepcion asesores-->
						<asp:panel id="divRa_101" runat="server" class="divCarritoV" style="left: 21%; top: 8%;">
							<asp:label runat="server" id="lblRa_101" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divRa_102" runat="server" class="divCarritoV" style="left: 27%; top: 8%;">
							<asp:label runat="server" id="lblRa_102" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divRa_103" runat="server" class="divCarritoV" style="left: 33%; top: 8%;">
							<asp:label runat="server" id="lblRa_103" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divRa_104" runat="server" class="divCarritoV" style="left: 39%; top: 8%;">
							<asp:label runat="server" id="lblRa_104" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<!--espera servicio-->
						<asp:panel id="divEs_101" runat="server" class="divCarritoV" style="left: 52%; top: 8%;">
							<asp:label runat="server" id="lblEs_101" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divEs_102" runat="server" class="divCarritoV" style="left: 58%; top: 8%;">
							<asp:label runat="server" id="lblEs_102" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divEs_103" runat="server" class="divCarritoV" style="left: 64%; top: 8%;">
							<asp:label runat="server" id="lblEs_103" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divEs_104" runat="server" class="divCarritoV" style="left: 70%; top: 8%;">
							<asp:label runat="server" id="lblEs_104" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<!--En Bahia-->
						<asp:panel id="divEb_101" runat="server" class="divCarritoH" style="left: 87%; top: 8%;">
							<asp:label runat="server" id="lblEb_101" Text="PRUEBA" CssClass="lblPlacah"></asp:label>
						</asp:panel>
						<asp:panel id="divEb_102" runat="server" class="divCarritoH" style="left: 87%; top: 24%;">
							<asp:label runat="server" id="lblEb_102" Text="PRUEBA" CssClass="lblPlacah"></asp:label>
						</asp:panel>
						<asp:panel id="divEb_103" runat="server" class="divCarritoH" style="left: 87%; top: 44%;">
							<asp:label runat="server" id="lblEb_103" Text="PRUEBA" CssClass="lblPlacah"></asp:label>
						</asp:panel>
						<asp:panel id="divEb_104" runat="server" class="divCarritoH" style="left: 87%; top: 64%;">
							<asp:label runat="server" id="lblEb_104" Text="PRUEBA" CssClass="lblPlacah"></asp:label>
						</asp:panel>
						<asp:panel id="divEb_105" runat="server" class="divCarritoH" style="left: 87%; top: 84%;">
							<asp:label runat="server" id="lblEb_105" Text="PRUEBA" CssClass="lblPlacah"></asp:label>
						</asp:panel>
						<!--en lavado-->
						<asp:panel id="divEl_101" runat="server" class="divCarritoV" style="left: 59.5%; top: 64%;">
							<asp:label runat="server" id="lblEl_101" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divEl_102" runat="server" class="divCarritoV" style="left: 65.5%; top: 64%;">
							<asp:label runat="server" id="lblEl_102" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divEl_103" runat="server" class="divCarritoV" style="left: 71.5%; top: 64%;">
							<asp:label runat="server" id="lblEl_103" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<!--LISTO PARA ENTREGAR-->
						<asp:panel id="divLe_101" runat="server" class="divCarritoV" style="left: 20.5%; top: 64%;">
							<asp:label runat="server" id="lblLe_101" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divLe_102" runat="server" class="divCarritoV" style="left: 26.5%; top: 64%;">
							<asp:label runat="server" id="lblLe_102" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divLe_103" runat="server" class="divCarritoV" style="left: 32.5%; top: 64%;">
							<asp:label runat="server" id="lblLe_103" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divLe_104" runat="server" class="divCarritoV" style="left: 38.5%; top: 64%;">
							<asp:label runat="server" id="lblLe_104" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divLe_105" runat="server" class="divCarritoV" style="left: 44.5%; top: 64%;">
							<asp:label runat="server" id="lblLe_105" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
						<asp:panel id="divLe_106" runat="server" class="divCarritoV" style="left: 50.5%; top: 64%;">
							<asp:label runat="server" id="lblLe_106" Text="PRUEBA" CssClass="lblPlacav"></asp:label>
						</asp:panel>
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
