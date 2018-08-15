<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pull_system.aspx.vb" Inherits="TablerosV2.pull_system" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

	<title>PUll SYStem</title>
	<%--<meta http-equiv="refresh" content="10" />--%>
	<link rel="stylesheet" href="css/jquery-ui.css" />
	<script type="text/javascript" src="js/jquery-1.9.1.js"></script>
	<script type="text/javascript" src="js/jquery-ui.js"></script>
	<style type="text/css">
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
			display: block;
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
<body onload="mReloj()" style="background-image: url(img/toyota_cn_servicio_8B.PNG);">


	<form id="form1" runat="server">
		<script type="text/javascript" src="js/wz_dragdrop.jser" onsubmit="return fSubmit();">
		 </script>
		<asp:ScriptManager ID="scrp1" runat="server" ></asp:ScriptManager>
		<asp:Timer runat="server" ID="Timer1" Enabled="false" Interval="10000"></asp:Timer>
		<asp:HiddenField runat="server" ID="hiddenURLSiguiente" />
		<!-- Por codigo en el on_load de la pagina o en el init le pones un valor a ese hidden field -->
		<script type="text/javascript">
			let segundos = 10
			setTimeout(() => { window.location = $('#hiddenURLSiguiente').val() }, segundos * 1000)
		</script>
		<input type="text" id="nreloj" name="nreloj" size="20" style="z-index: 8999; background-color: transparent; color: black; position: absolute; top: 230px; left: 1050px; border: 0; font-size: 14px; font-weight: bold;" readonly />

		<div id="floatdiv" style="position: absolute; width: 1225px; height: 90px; left: 0px; top: 0px; z-index: 3002;"
			runat="server">

			<img alt="" src="img/agenciaLOGOHeader.PNG" style="position: relative; top: 10px; left: 1020px;" />
			<asp:ImageButton runat="server" ID="ImageButton2"
				Width="1px" OnClientClick="doNothing();" onkeyress="doNothing();" Style="display: none; position: relative; top: -40px; left: 1025x;" />
			<asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="img/logout.png"
				Width="40px" OnClientClick="javascript:bSubmit = true;" OnClick="ImageButton1_Click" onkeyress="doNothing();" Style="position: relative; top: -40px; left: 1050px;" />
			<input type="text" value="" runat="server" id="dhtml" style="z-index: 1000; left: 550px; position: absolute; top: 5px; background-color: Transparent; border: none; font-size: 1px; font-family: Arial; color: White; font-weight: bold;" />
			<input type="text" value="Fecha: " style="z-index: 1000; left: 600px; position: absolute; top: 10px; background-color: Transparent; border: none; font-size: 1px; font-family: Arial; color: White; font-weight: bold;" />
			<asp:Label ID="lblCalendar" runat="server" Style="z-index: 1000; left: 675px; position: absolute; top: 10px; background-color: Transparent; border: none; font-size: 1px; font-family: Arial; color: White; font-weight: bold;"
				Text=""></asp:Label>
			<input type="text" value="Usuario: " style="z-index: 1000; left: 600px; position: absolute; top: 25px; background-color: Transparent; border: none; font-size: 1px; font-family: Arial; color: White; font-weight: bold;" />
			<asp:Label ID="lblUsr" runat="server" Style="z-index: 1000; left: 675px; position: absolute; top: 25px; background-color: Transparent; border: none; font-size: 1px; font-family: Arial; color: White; font-weight: bold;"
				Text=""></asp:Label>
			<asp:TextBox ID="txtUpdateBoard" runat="server" BackColor="Transparent" BorderColor="Transparent"
				BorderStyle="None" ForeColor="Black" Height="1px" Style="z-index: 107; left: 1px; position: absolute; top: 1px"
				Width="1px" AutoPostBack="True"></asp:TextBox>

		</div>
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


		<div style="position: absolute; left: 1020px; top: 420px; width: 290px; border: 1px solid black; font-weight: bold;">
			<table>
				<tr>
					<td>Asesores
      <asp:DataList ID="DataList1" runat="server" CellPadding="0" RepeatDirection="Vertical"
		  RepeatLayout="Table" Font-Size="12px" Font-Names="Calibri"
		  HorizontalAlign="right" CellSpacing="1">
		  <ItemTemplate>
			  <div style="border: solid 1px gray;">
				  <asp:Label ID="Label1" runat="server" Width="80px" Text='<%# Eval("color") %>' />
				  <asp:Label ID="lblcveAsesor" runat="server" Text='<%# Eval("nombre") %>' />

			  </div>
		  </ItemTemplate>
		  <FooterStyle />
		  <AlternatingItemStyle />
		  <ItemStyle />
		  <SelectedItemStyle />
		  <HeaderStyle />
	  </asp:DataList>

					</td>
					<td valign="top">
						<table>
							<tr>
								<td style="background-color: Red; width: 30px;">&nbsp;</td>
								<td>Con cita</td>
							</tr>
							<tr>
								<td style="background-color: blue; width: 30px;">&nbsp;</td>
								<td>Sin Cita</td>
							</tr>
						</table>

					</td>
				</tr>
			</table>


		</div>
	</form>



</body>
</html>
