<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="RecepcionCitas3.aspx.vb" Inherits="TablerosV2.RecepcionCitas3" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>RECEPCION</title>
	<link href="App_Themes/THEME1/StyleSheetRecepcionSeguimiento2.css" rel="stylesheet" />
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
	<script type="text/javascript" src="JS/jquery-1.9.1.js"></script>
	<script type="text/javascript" src="JS/JavaScriptRecepcionSeguimiento.js"></script>
	<link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" href="css/StylosRecepcion.css" />
	<script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
	<script src="Bootstrap/js/bootstrap.min.js"></script>

	<!-- Inicia Relativo a ModalWindowEffects -->
	<link href="res/ModalWindowEffects/css/component.css" rel="stylesheet" />
	<script type="text/javascript" src="res/ModalWindowEffects/js/modernizr.custom.js"></script>
	<!-- classie.js by @desandro: https://github.com/desandro/classie -->
	<script type="text/javascript" src="res/ModalWindowEffects/js/classie.js"></script>
	<script type="text/javascript" src="res/ModalWindowEffects/js/modalEffects.js"></script>
	<!-- Termina Relativo a ModalWindowEffects -->

	<style type="text/css">
		@-moz-keyframes mymove {
			0% {
				background-color: red;
			}

			50% {
				background-color: transparent;
			}

			100% {
				background-color: transparent;
			}
		}

		@-webkit-keyframes mymove {
			0% {
				background-color: red;
			}

			50% {
				background-color: transparent;
			}

			100% {
				background-color: transparent;
			}
		}

		@keyframes mymove {
			0% {
				background-color: red;
			}

			50% {
				background-color: transparent;
			}

			100% {
				background-color: transparent;
			}
		}

		@-moz-keyframes mymove2 {
			0% {
				background-color: orange;
			}

			50% {
				background-color: transparent;
			}

			100% {
				background-color: transparent;
			}
		}

		@-webkit-keyframes mymove2 {
			0% {
				background-color: orange;
			}

			50% {
				background-color: transparent;
			}

			100% {
				background-color: transparent;
			}
		}

		@keyframes mymove2 {
			0% {
				background-color: orange;
			}

			50% {
				background-color: transparent;
			}

			100% {
				background-color: transparent;
			}
		}

		.lblArriboDemorado {
			-moz-animation: mymove infinite;
			-o-animation: mymove infinite;
			-webkit-animation: mymove infinite;
			animation: mymove infinite;
			-moz-animation-duration: 2s;
			-o-animation-duration: 2s;
			-webkit-animation-duration: 2s;
			animation-duration: 2s;
		}

		.lblArriboAnticipado {
			-moz-animation: mymove2 infinite;
			-o-animation: mymove2 infinite;
			-webkit-animation: mymove2 infinite;
			animation: mymove2 infinite;
			-moz-animation-duration: 2s;
			-o-animation-duration: 2s;
			-webkit-animation-duration: 2s;
			animation-duration: 2s;
		}
	</style>
	<script type="text/javascript">
		function verificarAnimacion() {
			$(".lblArribo").each(function () {
				if ($(this).html() == "Demorado") {
					$(this).attr("class", $(this).attr("class") + " lblArriboDemorado")
				} else if ($(this).html() == "Anticipado") {
					$(this).attr("class", $(this).attr("class") + " lblArriboAnticipado")
				}
			});
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<asp:ScriptManager runat="server" ID="ScriptManager1"
			EnablePartialRendering="true" AsyncPostBackTimeout="600" />
		<!-- Este Timer es para dg1, dgLibres y modal -->
		<asp:Timer ID="Timer1" runat="server" Interval="20000"></asp:Timer>
		<!--<asp:Timer ID="Timer13" runat="server" Interval="60000"></asp:Timer>-->




		<div class="cssHeader000" style="color: white;">
			BIENVENIDOS CLIENTES 
		</div>


		<div class="container" style="background-color: rgba(0,0,0,0.8); color: white; text-align:center;">
			<asp:UpdatePanel ID="UPGUARDAV" runat="server" UpdateMode="Conditional">
				<ContentTemplate>
					<asp:Timer ID="Timer11" Interval="20000" Enabled="true" runat="server">
					</asp:Timer>
					<input type="text" runat="server" id="nreloj" name="nreloj" size="20"
						style="position: absolute; top: 15px; left: 1350px; color: white;" />
					<asp:DataGrid
						runat="server"
						ID="gridInfoCitas"
						AutoGenerateColumns="false"
						BorderColor="#C3C3C3"
						AllowPaging="true"
						page-size="10"
						GridLines="Vertical"
						CssClass="table-responsive table-condensed griccitas">
						<HeaderStyle BackColor="#0000FF" ForeColor="White" HorizontalAlign="Center" />
						<ItemStyle ForeColor="#C3C3C3" HorizontalAlign="Center" />
						<PagerStyle Visible="false" />
						<Columns>
							<asp:BoundColumn DataField="HORAASESOR" HeaderText="HORA" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="VEHICULO" HeaderText="UNNIDAD" ReadOnly="true" Visible="true"></asp:BoundColumn>
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
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate />
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
			</Triggers>
		</asp:UpdatePanel>

	</form>
	<div class="md-overlay"></div>
	<!-- the overlay element -->
</body>
</html>
