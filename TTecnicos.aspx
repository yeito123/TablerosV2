<%@ Page Language="vb" AutoEventWireup="false" EnableViewState="true" CodeBehind="TTecnicos.aspx.vb" Inherits="TablerosV2.TTecnicos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<meta http-equiv="refresh" content="120" />
	<script src="JS/wz_dragdrop.js" type="text/javascript"></script>

	<script src="JS/wz_jsgraphics.js" type="text/javascript"></script>
	<link rel="stylesheet" href="css/jquery-ui.css" />
	<link href="css/jquery.contextMenu.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="JS/jquery-1.9.1.js"></script>
	<script type="text/javascript" src="JS/jquery-ui.js"></script>
	<script type="text/javascript" src="js/jquery.contextMenu.js"></script>
	<link rel="stylesheet" href="css/generales.css" />
	<style type="text/css">
		.cssHeader000 {
			text-align: left;
			font-family: Lucida Grande,Lucida Sans,Arial,sans-serif;
			font-size: 20pt;
			width: 100%;
			color: #74852E;
		}

		.clDivInterfaz {
			width: 100%;
			font-size: 13px;
			font-weight: bold;
			border-top-style: solid;
			border-bottom-style: solid;
			background: rgba(14, 82, 11, 0.86);
			border: 2px solid #285513;
			border-radius: 5px;
			box-shadow: 5px 5px 5px #333;
			color: #000000;
			font-size: 0.8em;
			padding: 10px 10px 10px 35px;
			position: absolute;
			z-index: 1500;
			background: #a4b1b5;
			/* for IE */
			/* CSS3 standard */
			box-shadow: 5px 5px 5px #333;
			overflow: auto;
		}

		.clsInterfazMenu {
			background-color: #bdcde5;
			font-size: 15px;
			font-family: Calibri;
			width: 500px;
		}

		.clDivInterfazDtlst {
			color: black;
		}

		.clExt {
			position: relative;
		}

		.style1 {
			color: White;
		}

		.cpnlComent {
			position: absolute;
			top: 0;
			left: 0;
			z-index: 199999;
			background-color: Gray;
			font-size: 15px;
		}

		.gvContainer {
			overflow: auto;
			height: 160px;
			overflow-x: visible;
			scrollbar-face-color: #FFFFFF;
			scrollbar-shadow-color: #003366;
			scrollbar-highlight-color: #003366;
			scrollbar-3dlight-color: #F6F4FD;
			scrollbar-darkshadow-color: #F6F4FD;
			scrollbar-track-color: #FDFDFE;
			scrollbar-arrow-color: #003366;
		}

		.gvContainer1 {
			height: 160px;
			color: black;
			font-size: 12px;
			font-family: Calibri;
		}

		.gvContainer3 {
			height: 160px;
		}

		.gvContainer2 {
			overflow: auto;
			height: 60px;
			scrollbar-face-color: #FFFFFF;
			scrollbar-shadow-color: #003366;
			scrollbar-highlight-color: #003366;
			scrollbar-3dlight-color: #F6F4FD;
			scrollbar-darkshadow-color: #F6F4FD;
			scrollbar-track-color: #FDFDFE;
			scrollbar-arrow-color: #003366;
		}

		.EncabezadoFijo {
			position: absolute;
			top: 45px;
		}

		.auto-style1 {
			width: 220px;
		}
	</style>

	<script type="text/javascript">

		var TRange = null

		function busca(str) {
			if (parseInt(navigator.appVersion) < 4) return;
			var strFound;
			if (window.find) {

				strFound = self.find(str);
				if (!strFound) {
					strFound = self.find(str, 0, 1)
					while (self.find(str, 0, 1)) continue
				}
			}
			else if (navigator.appName.indexOf("Microsoft") != -1) {

				if (TRange != null) {
					TRange.collapse(false)
					strFound = TRange.findText(str)
					if (strFound) TRange.select()
				}
				if (TRange == null || strFound == 0) {
					TRange = self.document.body.createTextRange()
					// TRange = self.document.getElementById('gvDMS').createTextRange()
					strFound = TRange.findText(str)
					if (strFound) TRange.select()
				}
			}
			else if (navigator.appName == "Opera") {
				alert("Opera no soporta busqueda")
				return;
			}
			if (!strFound) alert("'" + str + "' no fue encontrada")
			return;
		}
		function calendarShown(sender, args) {
			sender._popupBehavior._element.style.zIndex = 10005;
			sender._popupBehavior._element.style.top = '100px';
			sender._popupBehavior._element.style.absolute = 'absolute';

		}
		function Location(sDiv) {
			document.getElementById("dhtml").value = sDiv;
			__doPostBack('__Page', sDiv);

			//document.getElementById("cmdNuevo").fireEvent("onclick", "");
			//window.frames.ifra.dopost();  

			// __doPostBack('__Page', sDiv);
		}
		function fnSalir() {

			window.location.href = "Inicio.aspx";

		}
		function mReloj() {
			momentoActual = new Date();
			try {
				document.getElementById("nreloj").value = momentoActual.format("dd/MM/yyyy hh:mm:ss tt");
			}
			catch (e) { }
			setTimeout("mReloj()", 1000)
		}

		function PostB() {
			__doPostBack('OkButtonMPGV', '');

		}
		function buscaTrabajo() {
			var str = document.getElementById('txtbuscar').value;
			busca('Orden:' + str);
			return false;

		}
		function PostB() {
			__doPostBack('OkButtonMPGV', '');

		}
		function Cancel() {
			return false;
		}
		function Alerta() {
			alerta('Hola');
		}
		//$(document).ready(function () {
		//    var winterfaz = document.getElementById("wInterfaz").value;
		//    //alert(winterfaz);
		//    if (winterfaz != "1121px") {
		//        $(".gvContainer").css({
		//            'width': '35px',
		//            'height': '25px'
		//        });
		//        $("#divInterfaz").css({
		//            'width': '35px',
		//            'height': '25px'
		//        });
		//    }
		//    else {
		//        $("#divInterfaz").css({
		//            'width': '1121px',
		//            'height': '200px'
		//        });
		//        $(".gvContainer").css({
		//            'width': '100%',
		//            'height': ''
		//        });


		//        // $("#wInterfaz").val('15px');

		//    }





		//$('#imgRefrescar').dblclick(function () {
		//    alert('hola');
		//    var width = val($("#divInterfaz").css('width'));


		//        if (width >= "112") {
		//            $(".gvContainer").css({
		//            'width':'35px',
		//            'height': '25px'
		//        });

		//            $("#divInterfaz").css({
		//                'width': '35px',
		//                'height': '25px'
		//            });
		//            $("#wInterfaz").val('15px');
		//            document.getElementById("wInterfaz").value = '15px';

		//        }

		//        else {
		//            $("#divInterfaz").css({
		//                'width': '1121px',
		//                'height': '200px'
		//            });
		//            $(".gvContainer").css({
		//                'width':'100%',
		//                'height': ''
		//            });

		//            $("#wInterfaz").val('1121px');
		//            document.getElementById("wInterfaz").value = '1121px';

		//        }





		//   });

		//});



		$(document).ready(function () {
			$(function () {
				var zIndexNumber = 1000;
				// Put your target element(s) in the selector below!
				$("menu").each(function () {
					$(this).css('zIndex', zIndexNumber);
					zIndexNumber -= 10;
				});
			});



			$('#imgColapsar').click(function () {
				//  alert('hola');
				var width = $("#divInterfaz").css('width').replace(/\D/g, '');

				// alert(width);
				if (width >= 300) {
					$("#divInterfaz").css({
						'width': '35px'
					});
					$("#imgRefrescar").css({ 'display': 'none' });
				}

				else {
					$("#divInterfaz").css({
						'width': '650px'
					});
					$("#imgRefrescar").css({ 'display': 'block' });

				}
			});

			// Show menu when #myDiv is clicked
			$("div.menu").contextMenu({
				menu: 'miMenu'
			},
				function (action, el, pos) {
					if ($("#dhtml").val().split(".").length < 4) { return false; }
					// if ($("#dhtml").val) { return false; }
					switch (action) {
						case 'Lavar':
							//Location('rvsn25_' + el[0].id);
							document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
							__doPostBack('btnLavar', '');
							// Location('move_' + el[0].id);
							break;
						case 'NoAuto':
							//Location('rvsn25_' + el[0].id);
							document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
							__doPostBack('btnNoAutoriza', '');
							// Location('move_' + el[0].id);
							break;
						case 'ini':
							//Location('rvsn25_' + el[0].id);
							//document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
							//__doPostBack('btnIni', '');

							document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
							//document.getElementById("lblInfoChip").value = 'El chip  ' + $('#' + document.getElementById("dhtml").value.split('.')[0] + '')[0].innerText + '  tiene un servicio de: ' + Math.round((document.getElementById("dhtml").value.split('.')[3] / 59) * 60) + '  minutos.';
							$find("mpe").show();
							// Location('move_' + el[0].id);
							break;
						case 'init':
							//Location('rvsn25_' + el[0].id);
							document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
							__doPostBack('btnInit', '');
							// Location('move_' + el[0].id);
							break;
						case 'kdwD':
							//Location('rvsn25_' + el[0].id);
							document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
							__doPostBack('imgBtnDgn_Kdw', '');
							// Location('move_' + el[0].id);
							break;
						case 'kdwO':
							//Location('rvsn25_' + el[0].id);
							document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
							__doPostBack('imgBtnWrk_Kdw', '');
							// Location('move_' + el[0].id);
							break;
						case 'det':
							//Location('rvsn25_' + el[0].id);
							//__doPostBack('btnStop', '');
							document.getElementById("dhtml").value = document.getElementById("dhMenu").value;

							$("#pnlDetencion").show();
							$("#pnlDetencion").css({ zindex: 19999 })


							var dmy = dd.elements['pnlDetencion'];
							dmy.css.zIndex = 19999;
							dmy.moveTo(pos.docX, pos.docY);

							//var dmy = document.getElementById('pnlDetencion');
							//dmy.style.display = 'block';
							//$('#pnlDetencion').animate({
							//    left: pos.docX,
							//    top: pos.docY
							//});


							break;
						case 'fin':
							//Location('rvsn25_' + el[0].id
							//document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
							//__doPostBack('btnFin', '');

							document.getElementById("dhtml").value = document.getElementById("dhMenu").value;

							$("#pnlFin").show();
							$("#pnlFin").css({ zindex: 19999 })


							var dmy = dd.elements['pnlFin'];
							dmy.css.zIndex = 19999;
							dmy.moveTo(pos.docX, pos.docY);

							//var dmy = document.getElementById('pnlFin');
							//dmy.style.display = 'block';
							//$('#pnlFin').animate({
							//    left: pos.docX,
							//    top: pos.docY
							//});



							break;
						case 'comen':
							//Location('rvsn25_' + el[0].id);
							document.getElementById("dhtml").value = document.getElementById("dhMenu").value;


							$("#pnlComent").show();
							$("#pnlComent").css({ zindex: 19999 })


							var dmy = dd.elements['pnlComent'];
							dmy.css.zIndex = 19999;
							dmy.moveTo(pos.docX, pos.docY);

							//var dmy = document.getElementById('pnlComent');
							//dmy.style.display = 'block';

							//$('#pnlComent').animate({
							//    left: pos.docX,
							//    top: pos.docY
							//});


							break;
						//					        case 'cut': 
						//					            Location('NQ_' + el[0].id); 
						//					            break; 

						//					        case 'cuaas': 
						//					             
						//					                   
						//					                    $(document).unbind('click'); 
						//					                
						//					            //Location('NQ_' + el[0].id); 
						//					            //evt.stopPropagation(); 
						//					            break; 
						default:
							alert(
								'Action: ' + action + '\n\n' +
								'Element ID: ' + $(el).attr('id') + '\n\n' +
								'X: ' + pos.x + '  Y: ' + pos.y + ' (relative to element)\n\n' +
								'X: ' + pos.docX + '  Y: ' + pos.docY + ' (relative to document)'
							);
							break;
					}

				});
			$("span.menu").contextMenu({
				menu: 'miMenu2'
			},
				function (action, el, pos) {
					switch (action) {
						case 'add':
							//Location('rvsn25_' + el[0].id);
							//document.getElementById("imgBtnUpd_DMS").fireEvent("onclick", "");
							__doPostBack('imgBtnUpd_DMS', '');
							//Location('add_' + el[0].id);
							break;
						//					        case 'cut': 
						//					            Location('NQ_' + el[0].id); 
						//					            break; 

						//					        case 'cuaas': 
						//					             
						//					                   
						//					                    $(document).unbind('click'); 
						//					                
						//					            //Location('NQ_' + el[0].id); 
						//					            //evt.stopPropagation(); 
						//					            break; 
						default:
							alert(
								'Action: ' + action + '\n\n' +
								'Element ID: ' + $(el).attr('id') + '\n\n' +
								'X: ' + pos.x + '  Y: ' + pos.y + ' (relative to element)\n\n' +
								'X: ' + pos.docX + '  Y: ' + pos.docY + ' (relative to document)'
							);
							break;
					}

				});

			//            $("#form1").contextMenu({
			//                menu: 'miMenu2'
			//            },
			//					function (action, el, pos) {
			//					    switch (action) {

			//					        case 'paste':
			//					            Location('paste_' + pos.x + '_' + pos.y);
			//					            break;
			//					        default:
			//					            alert(
			//						'Action: ' + action + '\n\n' +

			//						'X: ' + pos.x + '  Y: ' + pos.y + ' (relative to element)\n\n' +
			//						'X: ' + pos.docX + '  Y: ' + pos.docY + ' (relative to document)'
			//						);
			//					            break;
			//					    }

			//					});


		});
		$.expr[':'].icontains = function (obj, index, meta, stack) {
			return (obj.textContent || obj.innerText || jQuery(obj).text() || '').toLowerCase().indexOf(meta[3].toLowerCase()) >= 0;
		};
		$(document).ready(function () {
			$("#pnlComent").hide();
			$("#pnlDetencion").hide();
			$("#pnlFin").hide();

			$('#cmdCancelComen').click(function (e) {
				//var dmy = document.getElementById('pnlComent');
				//dmy.style.display = 'none';
				//e.preventDefault();

				$("#pnlComent").hide();
				e.preventDefault();

				// __doPostBack('cmdGuardarComen', '');

			});

			$('#cmdCancelComenDet').click(function (e) {

				$("#pnlDetencion").hide();
				//var dmy = document.getElementById('pnlDetencion');
				//dmy.style.display = 'none';
				e.preventDefault()
				// __doPostBack('cmdGuardarComen', '');

			});
			$('#Button2').click(function (e) {
				$("#pnlFin").hide();
				//var dmy = document.getElementById('pnlFin');
				//dmy.style.display = 'none';
				e.preventDefault();

				// evt.stopPropagation();

				return false;
				// __doPostBack('cmdGuardarComen', '');

			});
			$('#txtFind').keyup(function () {
				buscar = $(this).val();
				//$('#form1 a').removeClass('resaltar');
				//if (jQuery.trim(buscar) != '') {
				//    $("#form1 a:icontains('" + buscar + "')").addClass('resaltar');
				//}
				//$('#form1 span').removeClass('resaltar');
				//if (jQuery.trim(buscar) != '') {
				//    $("#form1 span:icontains('" + buscar + "')").addClass('resaltar');
				//}
				$('div[id*="ds"]').css({ "border-top": "0px solid black", "border-left": "1px solid black", "border-right": "1px solid black", "border-bottom": "1px solid black" });
				if (jQuery.trim(buscar) != '') {
					$("div[id*='ds']:icontains('" + buscar + "')").css({ "border": "5px solid #ff0" });
				}
			});
		});
	</script>


</head>
<body onload="mReloj()">
	<form id="form1" runat="server">
		<asp:ScriptManager runat="server" AsyncPostBackTimeout="0" ID="scrmgr1">
		</asp:ScriptManager>
		<asp:Timer ID="Timer13" runat="server" Enabled="false" Interval="12000"></asp:Timer>

		<input type="hidden" runat="server" id="wInterfaz" />

		<div id="miMenu" class="contextMenu">
			<ul>
				<li class="edit">


					<a href="#ini">Iniciar</a>  </li>
				<li class="edit"><a href="#det">Detener</a> </li>
				<li class="edit"><a href="#fin">Finalizar</a></li>
				<li class="comen"><a href="#comen">Comentario</a></li>
				<li class="init"><a href="#init">Reiniciar</a>  </li>
				<%--<li class="NoAuto"> <a href="#NoAuto">No Autoriza</a>  </li>
           <li class="edit"> <a href="#Lavar">Lavar</a>  </li>
           <li class="kdwD"> <a href="#kdwD">Diagnostico</a></li>
           <li class="kdwO"> <a href="#kdwO">Instruccion de Trabajo</a></li> --%>
			</ul>

		</div>

		<ul id="miMenu2" class="contextMenu">
			<li class="edit">


				<a href="#add">Grabar</a></li>


		</ul>

		<div id="topfix0" runat="server" style="background-image: url('img/pleca_azulT.png'); background-repeat: repeat-x; position: absolute; top: 0px; left: 0px; width: 100%;">
		</div>
		<div id="leftfix" runat="server" style="width: 92px; position: absolute; left: 0px; background-color: white; z-index: 3001;">
		</div>
		<div id="floatdiv" style="background-image: url('img/pleca_azulT.png'); background-repeat: repeat-x; position: absolute; left: 0px; top: 0px; z-index: 3002; width: 100%;"
			runat="server">
			<input type="text" id="nreloj" name="nreloj" size="20" style="display: none; z-index: 4999; color: black; position: absolute; top: 40px; left: 700px; border: 0; font-size: 12px; font-weight: bold;" onfocus="window.document.form.nreloj.blur()" />


			<div id="divFind" style="z-index: 4999; position: absolute; top: 7px; left: 600px; background-color: #003366;">
				<table class="table-condensed" style="background-color: transparent; color: white; border: groove 1px white;">
					<tr>
						<td>Buscar
                        <asp:TextBox ID="txtFind" runat="server" ForeColor="Black" Visible="true" />
							<asp:TextBox ID="txtBuscar" runat="server" ForeColor="Black" Visible="false" />

							<asp:ImageButton ID="imgBuscar" runat="server" ImageUrl="img/Find_32x32.png"
								Style="height: 20px;" Visible="false" />
							<asp:ImageButton ID="imgFind" runat="server" ImageUrl="img/Find_32x32.png"
								Style="height: 20px;" Visible="false" />
						</td>
						<td>
							<asp:ImageButton ID="imgRefrescar" runat="server" ImageUrl="img/Refresh.png"
								Style="height: 24px;" AlternateText="Refrescar" />
						</td>
						<td>
							<div id="divCalendar">
								<asp:TextBox ID="txtCalendar" AutoPostBack="true" runat="server" Style="display: none;" Text="Fecha"
									Font-Size="Medium" Font-Bold="False" ForeColor="White" />
								<img alt="" id="imgclCalendar" src="img/calendar.png" style="cursor: auto; background-color: Silver; border-bottom: solid 1px navy; width: 22px;" />
								<ajaxToolkit:CalendarExtender runat="server" Format="dd/MM/yyyy" OnClientShown="calendarShown"
									Animated="true" ID="clCalendarEx" TargetControlID="txtCalendar" PopupPosition="Right"
									PopupButtonID="imgclCalendar">
								</ajaxToolkit:CalendarExtender>
							</div>

						</td>
						<td align="right">

							<asp:ImageButton ID="imgBtnOut_DMS" runat="server" ImageUrl="~/img/logout2.png" Visible="true" Style="background-color: white;" />
						</td>

					</tr>
				</table>

			</div>


			<img alt="" src="~/img/AgenciaLogoHeader.png" id="imgLogo1" runat="server" style="position: relative; z-index: 3003; height: 3em;" />
			<input type="text" value="" runat="server" id="mymenu" style="z-index: 1000; left: 450px; position: absolute; top: 5px; background-color: transparent; border: none; color: transparent;" />
			<input type="text" value="" runat="server" id="dhtml" style="z-index: 1000; left: 550px; position: absolute; top: 5px; display: none;" />
			<input type="text" value="Fecha: " style="z-index: 1000; left: 15px; position: absolute; top: 20px; display: none;" />
			<asp:Label ID="lblCalendar" runat="server" Style="z-index: 1000; left: 75px; position: absolute; top: 20px; display: none;"
				Text=""></asp:Label>
			<input type="text" value="Usuario: " style="z-index: 1000; left: 15px; position: absolute; top: 35px; display: none;" />
			<asp:Label ID="lblUsr" runat="server" Style="z-index: 1000; left: 75px; position: absolute; top: 35px; display: none;"
				Text=""></asp:Label>
			<input type="text" value="" runat="server" id="dhtmlChp" style="z-index: 1000; left: 850px; position: absolute; top: 5px; display: none;" />

			<input type="text" value="" runat="server" id="dhMenu" style="z-index: 1000; left: 550px; position: absolute; top: 5px; display: none;" />



		</div>
		<div id="dchp" style="background-position: left top; z-index: 4999; left: 0px; width: 214px; position: absolute; top: 0px; display: none;"
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

		<div style="z-index: 3003; left: 0px; width: 650px; position: absolute; height: 200px;" id="divInterfaz"
			runat="server" visible="false">







			<table cellspacing="0" cellpadding="0" class="clDivInterfaz">

				<tr>

					<td>


						<div class="gvContainer">

							<table cellpadding="0" cellspacing="0     " style="width: 90%; display: block;" class="style1">
								<tr>
									<td valign="top" align="left">

										<div id="divLeyendas" runat="server" class="gvContainer1">
											<table>
												<tr valign="top">
													<td>

														<asp:DataList ID="DataList2" runat="server" CellPadding="0" RepeatDirection="Vertical"
															RepeatLayout="Table" Font-Size="12px" Font-Names="Calibri"
															HorizontalAlign="Left" CellSpacing="0">
															<ItemTemplate>
																<div style="border: solid 1px gray;">
																	<asp:Label ID="Label1" runat="server" Width="50px" Text='<%# Eval("color") %>' />
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
													<td>

														<table cellpadding="1" cellspacing="1" style="width: 90%;">
															<tr>
																<td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dg")%>;">&nbsp;
																</td>
																<td style="width: 200px;">Arribos con cita
                                
                                
                                    
																</td>
															</tr>
															<tr>
																<td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dn")%>;">&nbsp;</td>
																<td style="width: 200px;">No arribo
																</td>

															</tr>
															<tr>

																<td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "db")%>;">&nbsp;</td>
																<td style="width: 200px;">Arribos sin cita
																</td>
															</tr>
															<tr>

																<td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dgi")%>;">&nbsp;</td>
																<td style="width: 200px;">Arribos con cita por internet
																</td>
															</tr>
															<tr>

																<td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dl")%>;">&nbsp;</td>
																<td style="width: 200px;">Servicio Terminado
																</td>


															</tr>
															<tr>
																<td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw5")%>;">&nbsp;</td>
																<td style="width: 200px;">Detenido Prueba de Ruta</td>
															</tr>
															<tr>

																<td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw3")%>;">&nbsp;</td>
																<td style="width: 200px;">Detenido Autorizacion</td>

															</tr>
															<tr>
																<td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw2")%>;">&nbsp;</td>
																<td style="width: 200px;">Detenido Refacciones</td>

															</tr>
															<tr>

																<td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw4")%>;">&nbsp;
																</td>
																<td style="width: 200px;">Detenido En proceso</td>


															</tr>


															<tr>
																<td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw7")%>;">&nbsp;</td>
																<td style="width: 200px;">Detenido TOT</td>




															</tr>
														</table>
													</td>
												</tr>
											</table>
										</div>
										<div id="leftfix0" runat="server" class="clDivInterfazDtlst">
										</div>
									</td>


								</tr>



							</table>
						</div>





					</td>
					<td align="center">

						<table cellpadding="0" cellspacing="1">
							<tr>






								<td align="left" colspan="1">
									<asp:RadioButtonList runat="server" ID="lstFind" TextAlign="right" RepeatDirection="Vertical"
										CellPadding="0" CellSpacing="0" Visible="false">
										<asp:ListItem Text="Buscar Placas" Value="1" Selected="True">
										</asp:ListItem>
										<asp:ListItem Text="Buscar Orden" Value="2">                            
										</asp:ListItem>
									</asp:RadioButtonList>
								</td>
							</tr>



							<tr>
								<td>
									<asp:ImageButton ID="btnStop1" runat="server" ImageUrl="img/tecParar.PNG" Visible="false" />

									<asp:ImageButton ID="btnInit" runat="server" ImageUrl="img/tecReiniciar.PNG" Visible="false" />
									<asp:ImageButton ID="btnIni" runat="server" ImageUrl="img/tecInicio.PNG" Visible="false" />
									<asp:ImageButton ID="btnFin1" runat="server" ImageUrl="img/tecFin.PNG" Visible="false" />
									<asp:ImageButton ID="imgBtnDgn_Kdw" runat="server" ToolTip="Diagnóstico" Height="16px" Width="24px" Visible="false" />
									<asp:ImageButton ID="imgBtnWrk_Kdw" runat="server" ToolTip="Instrucción de trabajo" Height="16px" Width="24px" ImageUrl="~/img/move_f.gif" Visible="false" />
									<asp:ImageButton ID="btnNoAutoriza" runat="server" ToolTip="NoAutoriza" Height="16px" Width="24px" ImageUrl="~/img/move_f.gif" Visible="false" />
									<asp:ImageButton ID="btnLvd" runat="server" Visible="false" ImageUrl="~/img/Lavado.PNG" />


								</td>
							</tr>


						</table>


						<asp:Button ID="cmdNuevo" runat="server" Text="Nuevo" Style="display: none;" />

					</td>
				</tr>

			</table>


		</div>

		<div id="topfix1" style="top: 0px; height: 760px; width: 1225px;">

			<script type="text/javascript">
    <!--              
		jg_doc.paint();
    //-->
			</script>



		</div>



		<ajaxToolkit:ModalPopupExtender ID="MPGV" runat="server" BackgroundCssClass="watermarked"
			CancelControlID="NoButtonMPGV" DropShadow="false" OkControlID="OkButtonMPGV"
			OnCancelScript="Cancel()" OnOkScript="PostB()" PopupControlID="PopupMPGV"
			TargetControlID="cmdNuevo" PopupDragHandleControlID="PopupMPGV">
		</ajaxToolkit:ModalPopupExtender>
		<asp:Panel ID="PopupMPGV" runat="server" Style="display: block;">
			<asp:Panel ID="PopupDragHandleMPGV" runat="Server" HorizontalAlign="Left">
				<div id="divPopupDragHandleMPGV" runat="server">
					<div id="divifra" runat="server" style="left: 0px; position: absolute; top: 0px;">
						<%-- <iframe id="ifra" src="whuxgaHYPmainDet.aspx" height="555px" width="1265px"></iframe>--%>
						<p style="text-align: center;">
							<asp:Button ID="OkButtonMPGV" runat="server" BackColor="#eeeeee" BorderColor="Black"
								Font-Bold="True" ForeColor="#000066" Text="Guardar" Width="100px" Style="display: none;" />
							<asp:Button ID="NoButtonMPGV" runat="server" BackColor="#eeeeee" BorderColor="#2F4F4F"
								Font-Bold="True" ForeColor="#000066" Text="Cerrar" Width="100px" />
						</p>
					</div>

				</div>



			</asp:Panel>
		</asp:Panel>

		<div id="pnlComent" class="cpnlComent">

			<table>
				<tr>
					<td>Escriba su comentario</td>
				</tr>
				<tr>
					<td>
						<asp:TextBox runat="server" ID="txtComen" Font-Size="14px" TextMode="MultiLine"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Button runat="server" ID="cmdGuardarComen" Text="Guardar" /><asp:Button runat="server" ID="cmdCancelComen" Text="Cancelar" /></td>
				</tr>

			</table>
		</div>

		<div id="pnlFin" class="cpnlComent">

			<table>
				<tr>
					<td>Desea Finalizar</td>
				</tr>
				<tr>
					<td>
						<asp:TextBox runat="server" ID="txtComenFin" Font-Size="14px" TextMode="MultiLine" /></td>
					<td>Lavar:
						<asp:RadioButtonList runat="server" ID="rdlLavar" RepeatDirection="Horizontal">
							<asp:ListItem Text="Si" Value="1" Selected="True"></asp:ListItem>
							<asp:ListItem Text="No" Value="0"></asp:ListItem>
						</asp:RadioButtonList></td>
				</tr>
				<tr>
					<td>
						<asp:Button runat="server" ID="btnFin3" Text="Finalizar y Enviar a Calidad" />
						<asp:Button runat="server" ID="btnFin4" Text="Finalizar y Hacer Prueba De Ruta" Visible="false" />
						<asp:Button runat="server" ID="btnFin" Text="Finalizar" />
						<asp:Button runat="server" ID="Button2" Text="Cancelar" /></td>
				</tr>
			</table>
		</div>
		<div id="pnlDetencion" class="cpnlComent">
			<table>
				<tr>
					<td>Elija un Motivo de detencion</td>
				</tr>
				<tr>
					<td>
						<asp:DropDownList ID="cboStop" runat="server" AutoPostBack="False" Visible="True">
							<asp:ListItem Value="1">...</asp:ListItem>
							<asp:ListItem Value="2" style="background-color: #BDB76B;">Repuestos</asp:ListItem>
							<asp:ListItem Value="3" style="background-color: #FFA07A;">Autorizacion</asp:ListItem>
							<asp:ListItem Value="4" style="background-color: #D3D3D3;">En Proceso</asp:ListItem>
							<asp:ListItem Value="5" style="background-color: #8FBC8B;">PruebaRuta</asp:ListItem>
							<%--    <asp:ListItem Value="6" style="background-color: #cc9900;">Calidad</asp:ListItem>--%>
							<asp:ListItem Value="7" style="background-color: #660099;">TOT</asp:ListItem>
							<asp:ListItem Value="9" style="background-color: #DA70D6;">BodyShop</asp:ListItem>
							<asp:ListItem Value="10" style="background-color: #DA7000;">AsistTecnica</asp:ListItem>
						</asp:DropDownList>

					</td>
				</tr>
				<tr>
					<td>Tipo de detencion: </td>
				</tr>
				<tr>
					<td>
						<asp:DropDownList ID="cmbtipodetencion" runat="server" AutoPostBack="False" Visible="True">
							<asp:ListItem Value="1">...</asp:ListItem>
							<asp:ListItem Value="2" style="background-color: #BDB76B;">Normal</asp:ListItem>
							<asp:ListItem Value="3" style="background-color: #FFA07A;">En Sitio</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td>Escriba su comentario</td>
				</tr>
				<tr>
					<td>
						<asp:TextBox runat="server" ID="txtComenDet" Font-Size="14px" TextMode="MultiLine"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Button runat="server" ID="btnStop" Text="Detener" />
						<asp:Button runat="server" ID="cmdCancelComenDet" Text="Cancelar" /></td>
				</tr>
			</table>
		</div>

		<!-- esto lo agrego Yeison para cambiar la forma en la que se modifican los chips ojala sirva te estoy avisando ;) -->

		<asp:Button runat="server" ID="btnmodal3"
			Style="display: none" Text="muestramodal" />
		<ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="btnmodal3" PopupControlID="PanelDetalle"
			Enabled="true" Drag="true" DropShadow="true" BackgroundCssClass="modalBack" CancelControlID="btnCancelar">
		</ajaxToolkit:ModalPopupExtender>
		<asp:Panel runat="server" ID="PanelDetalle" Style="display: none; background: white; width: 80%; height: auto">
			<div class="modal-dialog modal-sm" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<%--<asp:Button runat="server" type="button" CssClass="close" data-dismiss="modal" aria-label="Close" Text="x"></asp:Button>--%>
						<h4 class="modal-title" id="myModalLabel">Modificar</h4>
					</div>
					<div class="modal-body" style="width: 100%;">
						<asp:Label ID="lblId" runat="server" Text="" Style="display: none;"></asp:Label>
						<textarea readonly="readonly" id="lblInfoChip" name="lblInfoChip" cols="30" rows="2" style="border: none; display: none;"> </textarea>

						<div id="dvlform" class="form-group form-lg" style="padding: 1em; width: 100%;">
							<asp:Label runat="server" ID="lblbahia" Text="Puesto de trabajo: "></asp:Label>
							<asp:DropDownList ID="cmbbahia" runat="server" TextMode="SingleLine"
								ReadOnly="false"
								placeholder="Puesto"
								CssClass="form-control" Style="width: 100%;" onchange="document.getElementById('soloExpress').style.display=this.value=='Express'?'':'none';">
								<asp:ListItem>A</asp:ListItem>
								<asp:ListItem>B</asp:ListItem>
								<asp:ListItem>C</asp:ListItem>
								<asp:ListItem>Express</asp:ListItem>
							</asp:DropDownList>
							<div id="soloExpress" style="display: none;">
								<asp:Label runat="server" ID="lblBahiaXpress" Text="Puesto de trabajo: "></asp:Label>
								<asp:DropDownList ID="cbobahiaExpress" runat="server" TextMode="SingleLine"
									ReadOnly="false"
									placeholder="N bahia"
									CssClass="form-control" Style="width: 100%;">
									<asp:ListItem>14</asp:ListItem>
									<asp:ListItem>15</asp:ListItem>
									<asp:ListItem>16</asp:ListItem>
								</asp:DropDownList>
								<asp:Label runat="server" ID="lblPuesto" Text="Puesto de trabajo: "></asp:Label>
								<asp:DropDownList ID="cboPuesto" runat="server" TextMode="SingleLine"
									ReadOnly="false"
									placeholder="N puesto"
									CssClass="form-control" Style="width: 100%;">
									<asp:ListItem>a</asp:ListItem>
									<asp:ListItem>b</asp:ListItem>
									<asp:ListItem>c</asp:ListItem>
								</asp:DropDownList>
							</div>
						</div>
					</div>
					<div class="modal-footer">
						<asp:Button runat="server" type="button" ID="btnOK" class="btn btn-default" Text="Aceptar" OnClick="btnOK_Click"></asp:Button>
						<asp:Button runat="server" type="button" ID="btnCancelar" class="btn btn-default" Text="Cerrar"></asp:Button>
					</div>
				</div>
			</div>
		</asp:Panel>
		<!-- hasta acá no te molestes porfa jejejejeje -->

	</form>

</body>
<script type="text/javascript"><!--
		/* Script by: www.jtricks.com
			  * Version: 20071017
			  * Latest version:
			  * www.jtricks.com/javascript/navigation/floating.html
			  */
		var floatingMenuId = 'floatdiv';
		var floatingMenu =
			{

				/*       
				targetX: -250,
				targetY: 5,
				*/

				targetX: 3,
				targetY: 0,


				hasInner: typeof (window.innerWidth) == 'number',
				hasElement: typeof (document.documentElement) == 'object'
				&& typeof (document.documentElement.clientWidth) == 'number',

				menu:
				document.getElementById
					? document.getElementById(floatingMenuId)
					: document.all
						? document.all[floatingMenuId]
						: document.layers[floatingMenuId]
			};



		floatingMenu.move = function () {
			floatingMenu.menu.style.left = '1' + 'px';
			floatingMenu.menu.style.top = floatingMenu.nextY + 'px';

			document.getElementById("dhtml").value = "divcitas";

			var my_date;
			var my_item;
			var my_cita;
			var my_serv;

			//my_item = dd.elements['topfix0'];
			//my_item.moveTo(my_item.defx, floatingMenu.nextY + 400);

			//my_cita = dd.elements['divInterfaz'];
			////my_cita = document.getElementById("divInterfaz");
			//my_cita.moveTo(floatingMenu.nextX  , floatingMenu.nextY + document.documentElement.clientHeight - document.getElementById('divInterfaz').offsetHeight  +50);

			my_cita = dd.elements['leftfix'];
			//my_cita = document.getElementById("divInterfaz");

			my_cita.moveTo(floatingMenu.nextX, 93);




			my_cita = dd.elements['imgLogo1'];
			//my_cita = document.getElementById("divInterfaz");
			my_cita.moveTo(floatingMenu.nextX, floatingMenu.nextY);
			my_cita = dd.elements['imgLogo0'];
			//my_cita = document.getElementById("divInterfaz");
			my_cita.moveTo(floatingMenu.nextX, 5);

			my_cita = dd.elements['divFind'];
			//my_cita = document.getElementById("divInterfaz");
			my_cita.moveTo(floatingMenu.nextX + document.documentElement.clientWidth - document.getElementById('divFind').offsetWidth - 650, 1);

			my_cita = dd.elements['dhtml'];
			//my_cita = document.getElementById("divInterfaz");
			my_cita.moveTo(floatingMenu.nextX + 300, floatingMenu.nextY + 'px');

			my_cita = dd.elements['divifra'];
			//my_cita = document.getElementById("divInterfaz");
			my_cita.moveTo(floatingMenu.nextX, floatingMenu.nextY + 'px');


			//            my_serv = dd.elements['divServicios'];
			//            my_serv.moveTo(my_serv.defx, floatingMenu.nextY + 307);

			//            my_cita = dd.elements['divCitas'];
			//            my_cita.moveTo(my_cita.defx, floatingMenu.nextY + 450);

		}

		floatingMenu.computeShifts = function () {
			var de = document.documentElement;

			floatingMenu.shiftX =
				floatingMenu.hasInner
					? pageXOffset
					: floatingMenu.hasElement
						? de.scrollLeft
						: document.body.scrollLeft;
			if (floatingMenu.targetX < 0) {
				floatingMenu.shiftX +=
					floatingMenu.hasElement
						? de.clientWidth
						: document.body.clientWidth;
			}

			floatingMenu.shiftY =
				floatingMenu.hasInner
					? pageYOffset
					: floatingMenu.hasElement
						? de.scrollTop
						: document.body.scrollTop;
			if (floatingMenu.targetY < 0) {
				if (floatingMenu.hasElement && floatingMenu.hasInner) {
					// Handle Opera 8 problems
					floatingMenu.shiftY +=
						de.clientHeight > window.innerHeight
							? window.innerHeight
							: de.clientHeight
				}
				else {
					floatingMenu.shiftY +=
						floatingMenu.hasElement
							? de.clientHeight
							: document.body.clientHeight;
				}
			}
		}

		floatingMenu.calculateCornerX = function () {
			if (floatingMenu.targetX != 'center')
				return floatingMenu.shiftX + floatingMenu.targetX;

			var width = parseInt(floatingMenu.menu.offsetWidth);

			var cornerX =
				floatingMenu.hasElement
					? (floatingMenu.hasInner
						? pageXOffset
						: document.documentElement.scrollLeft) +
					(document.documentElement.clientWidth - width) / 2
					: document.body.scrollLeft +
					(document.body.clientWidth - width) / 2;
			return cornerX;
		};

		floatingMenu.calculateCornerY = function () {
			if (floatingMenu.targetY != 'center')
				return floatingMenu.shiftY + floatingMenu.targetY;

			var height = parseInt(floatingMenu.menu.offsetHeight);

			// Handle Opera 8 problems
			var clientHeight =
				floatingMenu.hasElement && floatingMenu.hasInner
					&& document.documentElement.clientHeight
					> window.innerHeight
					? window.innerHeight
					: document.documentElement.clientHeight

			var cornerY =
				floatingMenu.hasElement
					? (floatingMenu.hasInner
						? pageYOffset
						: document.documentElement.scrollTop) +
					(clientHeight - height) / 2
					: document.body.scrollTop +
					(document.body.clientHeight - height) / 2;
			return cornerY;
		};

		floatingMenu.doFloat = function () {
			var stepX, stepY;

			floatingMenu.computeShifts();

			var cornerX = floatingMenu.calculateCornerX();

			var stepX = (cornerX - floatingMenu.nextX) * .05;
			if (Math.abs(stepX) < .5) {
				stepX = cornerX - floatingMenu.nextX;
			}

			var cornerY = floatingMenu.calculateCornerY();

			var stepY = (cornerY - floatingMenu.nextY) * .05;
			if (Math.abs(stepY) < .5) {
				stepY = cornerY - floatingMenu.nextY;
			}

			if (Math.abs(stepX) > 0 ||
				Math.abs(stepY) > 0) {
				floatingMenu.nextX += stepX;
				floatingMenu.nextY += stepY;
				floatingMenu.move();
			}

			setTimeout('floatingMenu.doFloat()', 1);
		};

		// addEvent designed by Aaron Moore
		floatingMenu.addEvent = function (element, listener, handler) {
			if (typeof element[listener] != 'function' ||
				typeof element[listener + '_num'] == 'undefined') {
				element[listener + '_num'] = 0;
				if (typeof element[listener] == 'function') {
					element[listener + 0] = element[listener];
					element[listener + '_num']++;
				}
				element[listener] = function (e) {
					var r = true;
					e = (e) ? e : window.event;
					for (var i = element[listener + '_num'] - 1; i >= 0; i--) {
						if (element[listener + i](e) == false)
							r = false;
					}
					return r;
				}
			}

			//if handler is not already stored, assign it
			for (var i = 0; i < element[listener + '_num']; i++)
				if (element[listener + i] == handler)
					return;
			element[listener + element[listener + '_num']] = handler;
			element[listener + '_num']++;
		};

		floatingMenu.init = function () {
			floatingMenu.initSecondary();
			floatingMenu.doFloat();
		};

		// Some browsers init scrollbars only after
		// full document load.
		floatingMenu.initSecondary = function () {
			floatingMenu.computeShifts();
			floatingMenu.nextX = floatingMenu.calculateCornerX();
			floatingMenu.nextY = floatingMenu.calculateCornerY();
			floatingMenu.move();
		}

		if (document.layers)
			floatingMenu.addEvent(window, 'onload', floatingMenu.init);
		else {
			floatingMenu.init();
			floatingMenu.addEvent(window, 'onload',
				floatingMenu.initSecondary);
		}


    //--></script>

</html>
