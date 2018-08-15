<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="tblPullCamiones.aspx.vb" Inherits="TablerosV2.tblPullCamiones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

	<title>PUll SYStem</title>
	<%--<meta http-equiv="refresh" content="10" />--%>
	<link rel="stylesheet" href="css/jquery-ui.css" />
	<script type="text/javascript" src="js/jquery-1.9.1.js"></script>
	<script type="text/javascript" src="js/jquery-ui.js"></script>
	<style type="text/css">
		body {
			background-color: #AAA7AA;
		}

		.OpcH {
			height: 28px;
			width: 46px;
			-moz-opacity: 0.5;
			-webkit-opacity: 0.5;
			-ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=50)";
			filter: alpha(opacity=50);
			opacity: 0.5;
		}

		.OpcV {
			width: 28px;
			height: 46px;
			-moz-opacity: 0.5;
			-webkit-opacity: 0.5;
			-ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=50)";
			filter: alpha(opacity=50);
			opacity: 0.5;
		}

		.textdiv {
			font-size: 12px;
			font-family: verdana;
			font-weight: bold;
			background-color: white;
			text-align: left;
			background-position: left top;
			// width:55px;
			height: 15px;
			color: black;
			// text-shadow: 0.1em 0.1em 0.1em black;
			// filter: progid:DXImageTransform.Microsoft.Shadow(direction=135,strength=0,color=999999);
		}

		.textResumen {
			display: none;
			border: none;
			background-color: transparent;
			position: absolute;
			top: 270px;
			left: 1020px;
			width: 300px;
			height: 100px;
		}

		.dQA {
			display: block;
			border: none;
			background-color: transparent;
			position: absolute;
			top: 0px;
			left: 1050px;
			width: 70%;
			height: 100%;
		}

		.divtitulo {
			position: absolute;
			top: 0%;
			left: 0%;
			width: 100%;
			height: 10%;
		}

		.divcuerpo {
			position: absolute;
			top: 10%;
			left: 0%;
			width: 100%;
			height: 85%;
		}

		.divpie {
			position: absolute;
			top: 90%;
			left: 0%;
			width: 100%;
			height: 10%;
		}
	</style>
	<script type="text/javascript" language="javascript">
		var bSubmit = false

		function Location(sDiv) {
			bSubmit = true;
			document.getElementById("dhtml").value = sDiv;
			__doPostBack('__Page', sDiv);
		}
		function handleEnter(inField, e) {
			var charCode;

			if (e && e.which) {
				charCode = e.which;
			} else if (window.event) {
				e = window.event;
				charCode = e.keyCode;
			}

			if (charCode == 13) {


				document.getElementById('btnBuscar').fireEvent("OnClick");

				return false;

			}
			else {
				return false;

			}


		}
		function buscaChp(sValue) {
			bSubmit = true;
			document.getElementById("dhtml").value = sValue;
			__doPostBack('__Page', "dhtml");
		}

		function buscaChpOrd() {



			var i = 0;
			var selObj = document.getElementById('selOptChipsHdd');
			for (i = 0; i < selObj.options.length; i++) {
				if (document.getElementById("inOptChips").value == selObj.options[i].text) {
					document.getElementById("dhtml").value = selObj.options[i].value;
					bSubmit = true;
					__doPostBack('__Page', "dhtml");
					return true;
				}

			}

			bSubmit = false;
			alert("La orden " + document.getElementById("dhtml").value + " no fue encontrada");

			return true;


		}



		function mReloj() {
			var momentoActual = new Date();

			try {

				document.getElementById("nreloj").value = momentoActual.toLocaleString();


			}
			catch (e) { alert(e.toString()); }
			setTimeout("mReloj()", 1000)
		}


		function fSubmit() {
			return bSubmit;
		}

		function doNothing() {
			bSubmit = false;
			var e = window.event;

			e.cancelBubble = true;
			e.returnValue = false;

			if (e.stopPropagation) {
				e.stopPropagation();
				e.preventDefault();
			}


		}

		$(function () {
			$(document).tooltip({
				track: true
			});

			$('.refMensaje').click(function () {
				__doPostBack('Timer1', '');
			});
		});



	</script>



</head>
<body onload="mReloj()">


	<form id="form1" runat="server">

		<%--scripts desconocidos--%>
		<script type="text/javascript" src="js/wz_dragdrop.jser" onsubmit="return fSubmit();">
		 </script>
		<asp:ScriptManager ID="scrp1" runat="server" ></asp:ScriptManager>
		<asp:Timer runat="server" ID="Timer1" Enabled="false" Interval="10000"></asp:Timer>		
		 <%--hasta acá--%>

		<%--reloj--%>
		<div runat="server" id="divTitulo" class="divtitulo" >
				<input 
					type="text" 
					id="nreloj" 
					name="nreloj" 
					size="20" 
					style="z-index: 8999; 
					background-color: transparent; 
					color: black; 
					position: absolute; 
					top:8%; 
					left: 0%; 
					border: 0; 
					font-size: 2em; 
					font-weight: bold;" 
					readonly />

				<div id="divContadores" style="position: absolute; left: 20%; top: 8%;">
					<asp:DataGrid runat="server" ID="gridContadorAsesor" CssClass="table table-striped table-condensed"
						AutoGenerateColumns="false" Width="25%" GridLines="None">
						<Columns>
							<asp:BoundColumn DataField="Autorizacion" HeaderText="Autorizacion" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="CarryOver" HeaderText="Proceso" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="Repuestos" HeaderText="Repuestos" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="Calidad" HeaderText="Calidad" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="Lavado" HeaderText="Lavado" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="EsperaServicio" HeaderText="Servicio" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="EnBahia" HeaderText="Iniciado" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="Terminado" HeaderText="Terminado" ReadOnly="true" Visible="true"></asp:BoundColumn>
						</Columns>
					</asp:DataGrid>
				</div>
				<div id="imgLOgoEmpresa" runat="server" style="width:20%; height:100%; position: absolute; top: 8%; left: 68% " >
					<img  alt="" src="img/AgenciaLogoHeader.png" style="width: 100%; height:100%"; />                    
				</div> 
			<asp:ImageButton 
				runat="server" 
				ID="ImageButton1" 
				ImageUrl="img/logout.png"
				Width="40px" 
				OnClientClick="javascript:bSubmit = true;" 
				OnClick="ImageButton1_Click" 
				onkeyress="doNothing();" 
				Style="position: absolute; 
				top: 8%; 
				left: 93%;" />
		</div>
		<%--fin--%>

		<%--imagen de fondo cuerpo--%>
		 <div id="divimg" runat="server" class="divcuerpo">
               <img id="imgfondo" src="img/imgpullprincipal.png" style="width:100%; height:100%;" />
			 <%--informacion importante capturada--%>
		<div id="floatdiv" style=" display:none; position:absolute; width: 1225px; height: 90px; left: 0px; top: 0px; z-index: 3002;"	runat="server">				
			<input type="text" value="" runat="server" id="dhtml" style="z-index: 1000; left: 550px; position: absolute; top: 5px; background-color: Transparent; border: none; font-size: 1px; font-family: Arial; color: White; font-weight: bold;" />
			<input type="text" value="Fecha: " style=" display:none;z-index: 1000;"/>
			<asp:Label ID="lblCalendar" runat="server"  Style=" display:none;z-index: 1000;" Text=""></asp:Label>
			<input type="text" value="Usuario: " style="display:none; z-index: 1000;"/>
			<asp:Label ID="lblUsr" runat="server" Style="display:none; z-index: 1000;" Text=""></asp:Label>			
		</div>
		<%--hasta aca--%>

		<div id="dchp" style="filter: alpha(opacity=90); background-position: left top; z-index: 4999; left: 0px; width: 214px; position: absolute; top: 0px; height: 90px; border-left-color: blue; border-bottom-color: blue; border-top-color: blue; border-right-color: blue; font-family: 'Calibri'; background-color: white; background-image: url(img/chipTextPull.PNG);"
			runat="server" visible="false">
			<asp:Label ID="Modelo" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 100; left: 15px; position: absolute; top: 16px"
				Text="Modelo:" Width="72px"
				Font-Names="Calibri"></asp:Label>
			<asp:Label ID="Tolerancia" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 101; left: 96px; position: absolute; top: 26px"
				Text="" Width="70px"
				Font-Names="Calibri"></asp:Label>
			<asp:Label ID="Orden" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 102; left: 96px; position: absolute; top: 15px"
				Text="Orden:" Width="70px"
				Font-Names="Calibri"></asp:Label>
			<asp:Label ID="Placas" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 103; left: 16px; position: absolute; top: 55px"
				Text="Servicio:" Height="16px"
				Width="72px" Font-Names="Calibri"></asp:Label>
			<asp:Label ID="Service" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 106; left: 96px; position: absolute; top: 40px"
				Text="Placas:" Width="100px"
				Font-Names="Calibri"></asp:Label>
		</div>		
		</div>
		<%--hasta aca--%>		
	</form>
	<script>

		let carros = document.querySelectorAll(".OpcV,.textdiv,.imagencarro")
		let alto = 563//document.getElementById("divimg").clientHeight
		let anche = 1343
		for (let carro of carros) {
			var v = (carro.style.top.replace("px", "") / alto) * 100 // (tcaroo / tdiv) * 100
			var p = (carro.style.left.replace("px", "") / alto) * 100 // (tcaroo / tdiv) * 100
			//carro.style.top=(carro.style.top.replace("px","")*5)
			carro.style.top = v + "%"
			carro.style.left = p + "%"
		}
			
		// Ancho 1364
		// Alto 563
		document.getElementById("divimg").clientWidth
	</script>
</body>
</html>
