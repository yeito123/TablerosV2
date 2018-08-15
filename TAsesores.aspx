<%@ Page Language="vb" AutoEventWireup="false" enableViewState="true" CodeBehind="TAsesores.aspx.vb" Inherits="TablerosV2.TAsesores" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="ZedGraph.Web" Namespace="ZedGraph.Web" TagPrefix="cc22" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
<meta http-equiv="refresh" content="600" />
   <script src="JS/wz_dragdrop.js" type="text/javascript"></script>

    <script src="JS/wz_jsgraphics.js" type="text/javascript"></script>
     <link rel="stylesheet" href="css/jquery-ui.css" />    
       <link href="css/jquery.contextMenu.css" rel="stylesheet" type="text/css" />
     <script  type="text/javascript" src="JS/jquery-1.9.1.js"></script>
     <script type="text/javascript" src="JS/jquery-ui.js"></script>
         <script type="text/javascript" src="js/jquery.contextMenu.js"  ></script>
    <link rel="stylesheet" href="css/generales.css" />   
         <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css"/>
    <style type="text/css">
       
        .cssHeader000 {
    text-align: left;
    font-family:   Lucida Grande,Lucida Sans,Arial,sans-serif;
    font-size: 20pt;
    width:100%;
      color:#74852E;
}
   
        .clDivInterfaz {
            
             width: 110%;
             
              font-size:13px; 
              font-weight:bold;
               border-top-style:solid; 
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
    background:#a4b1b5;
/* for IE */
  filter:alpha(opacity=86);
  /* CSS3 standard */
  opacity:0.86;
   box-shadow: 5px 5px 5px #333;
   overflow: auto;
         


        }
        .clsInterfazMenu {
            background-color:#bdcde5;
            font-size:15px;
            font-family:Calibri;
           
            width:500px;


        }
         .clDivInterfazDtlst {
            color:black;

        }
        .clExt
        {
            position: relative;
        }
        .style1{
        color:White;
        }
          .cllabel {
              font-size:12px;
            
            color:darkgreen;
        }
           .cllabel2 {
            font-size:12px;
            color:darkblue;
        }
            .cllabel3 {
            font-size:12px;
            color:white;
        }
        .cpnlComent {
         position: absolute;
            z-index: 10005;
            background-color: Gray;
            filter: alpha(opacity=75);
        }
          .gvContainer
        {
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
           .gvContainer1
        {
                       
            height: 160px;
            color:black;
              font-size:12px;
            font-family:Calibri;
            position:absolute;
            top:5px;
            left:950px;
            z-index:1601;
           
        }
           .gvContainer3
        {
                       
            height: 160px;
           
        }
          .gvContainer2
        {
             overflow: auto;             
             height:60px;
             
            scrollbar-face-color: #FFFFFF;
            scrollbar-shadow-color: #003366;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #FDFDFE;
            scrollbar-arrow-color: #003366;
        }
         .EncabezadoFijo
        {
            position:absolute;
            top:45px;
            
         
            
        }
        .auto-style1 {
            width: 220px;
        }
        
.resaltar{background-color:#FF0;}
.toolTipA{
    height:200px;
    background: rgba(87, 96, 135, 0.96);
    border: 2px solid #285513;
    border-radius: 5px;
    box-shadow: 5px 5px 5px #333;
    color: #ffffff;
    font-size: 0.8em;
    padding: 10px 10px 10px 35px;
    max-width: 600px;
    width:300px;
    position: absolute;
    z-index: 1500;   
    
/* for IE */
  filter:alpha(opacity=93);
  /* CSS3 standard */
  opacity:0.93;
   box-shadow: 5px 5px 5px #333;
   overflow: auto;
         scrollbar-face-color: #36752D;
	        scrollbar-shadow-color: #36752D;
	        scrollbar-highlight-color: #36752D;
	        scrollbar-3dlight-color: #36752D;
	        scrollbar-darkshadow-color: #F6F4FD;
	        scrollbar-track-color: #FDFDFE;
	        scrollbar-arrow-color: #36752D;

}

        .bck {
            background-color:aliceblue;

        }
    </style>

    <script type="text/javascript">



        function chkSelF() { return true; }

        function mostrarTooltip(elemento, mensaje) {
            var patternst = '/\d+/';

            // Si no existe aun el tooltip se crea
            if (!document.getElementById(elemento.id + "tp")) {

                // Dimensiones del elemento al que se quiere añadir el tooltip
                anchoElemento = $('#' + elemento.id).width();
                altoElemento = $('#' + elemento.id).height();

                // Coordenadas del elemento al que se quiere añadir el tooltip


                //var lint = $('#divInterfaz').width().match(patternst);

                coordenadaXElemento = $('#' + elemento.id).offset().left;
                // alert(coordenadaXElemento);
                coordenadaYElemento = $('#' + elemento.id).position().top;

                // Coordenadas en las que se colocara el tooltip
                x = coordenadaXElemento - anchoElemento - 100;
                y = coordenadaYElemento + altoElemento * 1.5;

                // Crea el tooltip con sus atributos
                var tooltip = document.createElement('div');
                tooltip.id = elemento.id + "tp";
                tooltip.className = 'toolTipA';
                tooltip.innerHTML = mensaje;
                tooltip.style.left = x + "px";
                tooltip.style.top = y + "px";

                // Añade el tooltip
                //document.body.appendChild(tooltip);
                document.getElementById("divInterfaz").appendChild(tooltip);
            }

            // Cambia la opacidad del tooltip y lo muestra o lo oculta (Si el raton esta encima del elemento se muestra el tooltip y sino se oculta)
            $('#' + elemento.id).hover(
                function () {
                    try {
                        $(".toolTipA").show();
                        tooltip.style.display = "block";
                        $('#' + tooltip.id).animate({ "opacity": .86 });
                        $('#' + tooltip.id).animate({ "zIndex": 9999 });
                    }
                    catch (e) { }
                },
                function () {
                    try {
                        $(".toolTipA").hide();
                        tooltip.style.display = "none";
                        $('#' + tooltip.id).animate({ "opacity": .86 });
                        $('#' + tooltip.id).animate({ "zIndex": 9999 });

                        //$('#' + tooltip.id).animate({ "opacity": 0 });
                        //$('#' + tooltip.id).animate({ "zIndex": 9999 });
                        //setTimeout(
                        //    function () {
                        //        tooltip.style.display = "block";
                        //    },
                        //    1
                        //);
                    }
                    catch (e) { }

                }
            );
        }
        function buscaTm(sValue, sCserv) {
            var i = 0;
            var elem = sCserv.split('_');
            var txtObj = document.getElementById(elem[0] + '_' + elem[1] + '_txtservicio');
            var selObj = document.getElementById(elem[0] + '_' + elem[1] + '_arr2T');
            for (i = 0; i < selObj.options.length; i++) {
                if (sValue == selObj.options[i].value) {
                    txtObj.value = selObj.options[i].text;
                    return false;
                }
            }
        }

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
        }
        function Location(sDiv) {
            document.getElementById("dhtml").value = sDiv;
            __doPostBack('__Page', sDiv);

            //document.getElementById("cmdNuevo").fireEvent("onclick", "");
            //window.frames.ifra.dopost();  

            // __doPostBack('__Page', sDiv);
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
        $(document).ready(function () {
            $('#intdivInterfaz').show();
            $("#pnlComent").hide();
            $('#buttonHide').click(function () {
                $("#intdivInterfaz").toggle(400);

            });
            $('#cmdCancelComen').click(function () {
                evt.stopPropagation();
                // __doPostBack('cmdGuardarComen', '');

            });
        });

        $(document).ready(function () {

            // Show menu when #myDiv is clicked
            $("div.menu").contextMenu({
                menu: 'miMenu'
            },
					function (action, el, pos) {
					    switch (action) {
					        case 'move':
					            //Location('rvsn25_' + el[0].id);
					            document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
					            __doPostBack('imgBtnMve_DMS', '');
					            // Location('move_' + el[0].id);
					            break;

					        case 'Lavar':
					            //Location('rvsn25_' + el[0].id);
					            document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
					            __doPostBack('imgBtnLavarUpd', '');
					            // Location('move_' + el[0].id);
					            break;
					        case 'ini':
					            //Location('rvsn25_' + el[0].id);
					            document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
					            __doPostBack('btnIni', '');
					            // Location('move_' + el[0].id);
					            break;
					        case 'fin':
					            //Location('rvsn25_' + el[0].id);
					            document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
					            __doPostBack('btnFin', '');
					            // Location('move_' + el[0].id);
					            break;

 
					        case 'del':
					            //Location('rvsn25_' + el[0].id);
					            document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
					            __doPostBack('imgBtnDel_DMS', '');
					            // Location('move_' + el[0].id);
					            break;
					        case 'edit':
					            //Location('rvsn25_' + el[0].id);
					            document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
					            __doPostBack('imgBtnTme_CHP', '');
					            // Location('move_' + el[0].id);
					            break;
					        case 'comen':
					            //Location('rvsn25_' + el[0].id);
					            document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
					            $("#pnlComent").show();
					            $("#pnlComent").css({ left: pos.docX });
					            $("#pnlComent").css({ top: pos.docY });
					            // Location('move_' + el[0].id);
					            break;
					            
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
            $("div.menu2").contextMenu({
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
                           case 'edit':
                               //Location('rvsn25_' + el[0].id);
                               document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
                               __doPostBack('imgBtnTme_CHP', '');
                               // Location('move_' + el[0].id);
                               break;
                           case 'move':
                               //Location('rvsn25_' + el[0].id);
                               document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
                               __doPostBack('imgBtnMve_DMS', '');
                               // Location('move_' + el[0].id);
                               break;
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

             

        });
        $.expr[':'].icontains = function (obj, index, meta, stack) {
            return (obj.textContent || obj.innerText || jQuery(obj).text() || '').toLowerCase().indexOf(meta[3].toLowerCase()) >= 0;
        };
        $(document).ready(function () {
            $('#txtFind').keyup(function () {
                buscar = $(this).val();
               
                $('div[id*="ds"]').css({ "border-top": "0px solid black", "border-left": "1px solid black", "border-right": "1px solid black", "border-bottom": "1px solid black" });
                if (jQuery.trim(buscar) != '') {
                    $("div[id*='ds']:icontains('" + buscar + "')").css({ "border": "5px solid #ff0" });
                }
            });
        });



        ads = new Array();

        $(document).ready(function () {

            $('span.ixdivchk').click(function () {
                $("#intdivInterfaz").toggle(400);
                alert($('span.ixdivchk').prop('checked'));
                if ($('span.ixdivchk').attr("checked") == true) { alert('verdadeso'); }


            });

        });

        $.expr[':'].icontains = function (obj, index, meta, stack) {
            return (obj.textContent || obj.innerText || jQuery(obj).text() || '').toLowerCase().indexOf(meta[3].toLowerCase()) >= 0;
        };
        $(document).ready(function () {
            //$("div.menu").each(function (i) {
            //    backColor[$(this).attr("id")] = $(this).css("bck");
            //});
           
            $("div.menu").hover(function () {
                var jo = $("div.menu");
                jo.css("background-color", "#00AED0");
                jo = $("div.menu2");
                jo.css("background-color", "#00AED0");

                var obj = $("#" + $(this).attr("id"));
                obj.css("background-color", "#FFD700");
                var buscar = obj.text().replace('I', '').replace('D', '').replace('T', '');
                jo = $("div.menu:icontains('" + buscar + "')");
                jo.css("background-color", "#FFD700");
                jo = $("div.menu2:icontains('" + buscar + "')");
                jo.css("background-color", "#FFD700");


            });

            $("div.menu2").hover(function () {
                var jo = $("div.menu");
                jo.css("background-color", "#00AED0");
                jo = $("div.menu2");
                jo.css("background-color", "#00AED0");
                
                var obj = $("#" + $(this).attr("id"));
                obj.css("background-color", "#FFD700");
                var buscar = obj.text().replace('I', '').replace('D', '').replace('T', '');
                jo = $("div.menu:icontains('" + buscar + "')");
                jo.css("background-color", "#FFD700");
                jo = $("div.menu2:icontains('" + buscar + "')");
                jo.css("background-color", "#FFD700");
               

            });
            

                
        })

    </script>


</head>
<body  onload="mReloj()">
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" AsyncPostBackTimeout="0" ID="scrmgr1">
    </asp:ScriptManager>
          
         <div id="ind1" runat="server" style="position: absolute; top: 0; left: 0;z-index:999;">
            <div>
            <%--   <table style=" font-size:14px;">
                   <tr><td style="background-color:darkgreen;width:30px;" >&nbsp;</td><td>Con Cita</td></tr>
                    <tr><td style="background-color: darkblue; width:30px;">&nbsp;</td><td>Sin Cita</td></tr>     
                   <tr><td style="background-color:greenyellow;width:30px;" >&nbsp;</td><td>Terminado</td></tr> 
     
     </table>--%>

            </div>
             <asp:DataGrid ID="dgIndicadores" runat="server" AutoGenerateColumns="false"  
                    ShowHeader="false" ShowFooter="false" CellPadding="0" CellSpacing="0" CssClass="clIndicadores" >
                    <AlternatingItemStyle BackColor="White" Font-Names="Arial" Font-Size="1px"  ForeColor="White"  />
                    <ItemStyle BackColor="White" Font-Names="Arial" Font-Size="1px"  ForeColor="White" />
                    <HeaderStyle BackColor="White" Font-Bold="True" Font-Size="1px" ForeColor="White"
                        Font-Names="Arial" />
                    <Columns>
                        <asp:BoundColumn DataField="id" HeaderText="" Visible="false" />
                         <asp:BoundColumn DataField="ocupadoc" HeaderText="" Visible="false" />
                          <asp:BoundColumn DataField="ocupados" HeaderText="" Visible="false" />
                         <asp:BoundColumn DataField="total" HeaderText="" Visible="false" />
                         <asp:BoundColumn DataField="dia" HeaderText="" Visible="false" />
                                         
                       
                        <asp:TemplateColumn HeaderText=""  >
                            <ItemTemplate>
                                <div runat="server" id="divzed" >
                                    <table ><tr> <td><cc22:ZedGraphWeb    OnRenderGraph="ZedGraphWeb1_RenderGraph" ID="ZedGraphWeb1" runat="server"
                                    FontSpec-Size="2" Legend-FontSpec-Size="0"  Margins-Bottom="0" Margins-Left="0" Margins-Right="0" Margins-Top="0"
                                    Height="25" ChartBorder-IsVisible="false" IsFontsScaled="false" Legend-IsVisible="false"
                                      XAxis-FontSpec-Size="1" XAxis-Scale-FontSpec-Size="10"
                                    IsShowTitle="false" XAxis-IsShowTitle="false" YAxis-IsShowTitle="false" YAxis-IsVisible="false"
                                    XAxis-IsVisible="true"   Width="120" XAxis-AxisColor="Maroon" PaneBorder-IsVisible="False"
                                    PaneFill-Color="snow">
                                </cc22:ZedGraphWeb></td><td>
                                     <asp:Label runat="server" id="lblPercentage" CssClass="cllabel" > </asp:Label></td><td>
                                    <asp:Label runat="server" id="lblPercentage2" CssClass="cllabel2" > </asp:Label></td><td>
                                               <asp:Label runat="server" id="lblPercentage3" CssClass="cllabel3" > </asp:Label>
                                                        </td></tr></table>
                               
                                    
                                </div>
                              
                            </ItemTemplate>
                            
                        </asp:TemplateColumn>
                        

                    </Columns>
                </asp:DataGrid>


        </div>
        
           
      <ul id="miMenu" class="contextMenu">
			<li class="edit">    
            
            <a href="#move">Mover</a>  </li>          
        <li class="edit"> <a href="#edit">Modificar</a></li>
           <li class="ini"> <a href="#ini">Iniciar</a></li>
           <li class="fin"> <a href="#fin">Terminar</a></li>
         <%--  <li class="edit">   <a href="#ini">Iniciar</a>  </li>         
         <li class="edit"> <a href="#fin">Finalizar</a></li>--%>
          
                     <li class="comen"> <a href="#comen">Comentario</a></li>
           
           
           


          <%-- <li class="kdwD"> <a href="#kdwD">Diagnostico</a></li>
           <li class="kdwO"> <a href="#kdwO">Instruccion de Trabajo</a></li>--%>
			  
		</ul>
         <ul id="miMenu2" class="contextMenu">
				<li class="edit"><a href="#move">Mover</a>  </li>
               
         <li class="edit"> <a href="#edit">Modificar</a></li>
                   
			  
		</ul>
    <div id="topfix0" runat="server"  style="background-image:url('img/pleca_azulA.png'); background-repeat:repeat-x; height: 100%;
          position: absolute; top: 0px; left: 0px;width:100%; ">
         
    </div>
     <div id="leftfix"  runat="server" style=" width:92px; position:absolute;  left: 0px;background-color:white;z-index: 3001;">
         
    </div>
    <div id="floatdiv" style="background-image:url('img/pleca_azulA.png'); background-repeat:repeat-x; position: absolute;
          height: 100%; left: 0px; top: 0px; z-index: 3002; width:100%;" runat="server">
          <input type="text" id="nreloj" name="nreloj" size="20"  style="display:none;z-index:4999;color:black;position:absolute;top:40px;left:700px;border:0;font-size:12px; font-weight:bold;" onfocus="window.document.form.nreloj.blur()" />

        <div id="divFind" style="z-index: 4999; position: absolute; top: 7px; left: 600px; background-color: #003366;">
            <table class="table-condensed" style="background-color: transparent; color: white; border: groove 1px white;">
                <tr>
                    <td>Buscar
                        <asp:TextBox ID="txtFind" runat="server" ForeColor="Black" Visible="true" />

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
 
        
        <img  alt="" src="~/img/AgenciaLogoHeader.png" id="imgLogo1" runat="server" style="position: relative;z-index: 3003;height:3em;  " />
         <input type="text" value=""  runat="server" id="mymenu" style="z-index: 1000; left: 450px; position: absolute;
            top: 5px; background-color: transparent; border: none;  color: black;  " />
        <input type="text" value=""  runat="server" id="dhtml" style="z-index: 1000; left: 550px; position: absolute;
            top: 5px; background-color: transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: transparent; font-weight: bold;" />
       <input type="text" value="Fecha: " style="z-index: 1000; left: 15px; position: absolute;
            top: 20px; background-color: Transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: transparent; font-weight: bold;" />
        <asp:Label ID="lblCalendar" runat="server" Style="display:none;z-index: 1000; left: 75px; position: absolute;
            top: 20px; background-color: Transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: White; font-weight: bold;" Text=""></asp:Label>
        <input type="text" value="Usuario: " style="z-index: 1000; left: 15px; position: absolute;
            top: 35px; background-color: Transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: White; font-weight: bold; display:none;" />
        <asp:Label ID="lblUsr" runat="server" Style="z-index: 1000; left: 75px; position: absolute;
            top: 35px; background-color: Transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: White; font-weight: bold;display:none;" Text=""></asp:Label>
      <input type="text" value="" runat="server" id="dhtmlChp" style="z-index: 1000; left: 850px;
            position: absolute; top: 5px; background-color: Transparent; border: none; font-size: 12px;
            font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif; color: transparent; font-weight: bold;" />
        <input type="text" value=""  runat="server" id="dhMenu" style="z-index: 1000; left: 550px; position: absolute;
            top: 5px; background-color: transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: transparent; font-weight: bold;" />
       
        
        
    </div>
         <div id="dchp" style="background-position: left top; z-index:4999;  
        Left: 0px; width: 214px; position: absolute; Top: 0px; height:  0px; border-left-color: blue;
        border-bottom-color: blue; border-top-color: blue; border-right-color: blue; font-family: 'Calibri'; background-color: white; background-image: url(img/chipText.PNG); "
        runat="server" visible="false" >
        <asp:Label ID="Modelo" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 100;
            left: 15px; position: absolute; top: 16px" Text="Modelo:"   Width="72px"
            Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Tolerancia" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 101;
            left: 96px; position: absolute; top: 26px" Text=""   Width="70px"
            Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Orden" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 102;
            left: 96px; position: absolute; top: 15px" Text="Orden:"   Width="70px"
            Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Placas" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 103;
            left: 16px; position: absolute; top: 55px" Text="Servicio:"   Height="16px"
            Width="72px" Font-Names="Calibri"></asp:Label>        
        <asp:Label ID="Service" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 106;
            left: 96px; position: absolute; top: 40px" Text="Placas:"   Width="100px"
            Font-Names="Calibri"></asp:Label>
    </div>
      
   
         
    <div style="z-index: 3003; left: 0px; position: absolute;  background-color:white; " id="divInterfaz"
        runat="server" visible="false">
          
          
         
  
        <table cellspacing="0" cellpadding="0" class="container" width="30%" style="background-color:azure;">
                
                <tr>
               
                <td>


                    <div class="gvContainer"> 

                                    <div id="leftfix0" runat="server" class="clDivInterfazDtlst">
                                    </div>
                                
                    </div>




                </td>
             <td align="center">
                 
                  <table cellpadding="0" cellspacing="1"  >
                    
                            <tr><td>
                                 <asp:ImageButton ID="imgBtnMve_DMS" runat="server"    Visible="false" />
                                  <asp:ImageButton ID="imgBtnLavarUpd" runat="server"    Visible="false" />
       
                             <asp:ImageButton ID="imgBtnDel_DMS" runat="server"   Visible="false" />
                            
                            <asp:ImageButton ID="imgBtnCut_CHP" runat="server"    Visible="false" />
                             
                            <asp:ImageButton ID="imgBtnPrs_CHP" runat="server"   Visible="false" />
                            
                            <asp:ImageButton ID="imgBtnUpd_DMS" runat="server"   Visible="false" />
                                <asp:ImageButton ID="imgBtnUpd_DMS2" runat="server"   Visible="false" />
                            
                 
                            <asp:ImageButton ID="imgBtnRpt_DMS" runat="server"    Visible="false" />
                             
                             <asp:ImageButton ID="imgBtnTme_CHP" runat="server"   Visible="false" />
                                <asp:ImageButton ID="imgBtnDgn_Kdw" runat="server" ToolTip="Diagnóstico" Height="16px" Width="24px"  Visible="false" />
                              <asp:ImageButton ID="imgBtnWrk_Kdw" runat="server" ToolTip="Instrucción de trabajo" Height="16px" Width="24px" ImageUrl="~/img/move_f.gif" Visible="false" />
                             <asp:ImageButton ID="btnIni" runat="server" ImageUrl="img/tecInicio.PNG" Visible="false" />
                    <asp:ImageButton ID="btnFin" runat="server" ImageUrl="img/tecFin.PNG" Visible="false" />
                            </td></tr>
                      <tr><td>
                           
                            </td></tr>
                           
                            </table>
                   

                    </td>
            </tr>
             
            
        </table>
         
      
    </div>
  
    <div id="topfix1" style="top: 0px; height: 0px; ">

        <script type="text/javascript">
    <!--              
            jg_doc.paint();
            jg_doc2.paint();
    //-->
        </script>

       

    </div>
        
        
       
        <div   id="pnlComent" class="cpnlComent">
            
            <table>
                <tr><td>Escriba su comentario</td></tr>
                <tr><td><asp:TextBox runat="server" ID="txtComen" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td><asp:Button runat="server" ID="cmdGuardarComen" Text="Guardar" /><asp:Button runat="server" ID="cmdCancelComen" Text="Cancelar" /></td></tr>

            </table>
        </div>

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
        //my_cita.moveTo(floatingMenu.nextX, floatingMenu.nextY + document.documentElement.clientHeight - document.getElementById('divInterfaz').offsetHeight - 10);
        my_cita = dd.elements['leftfix'];
        //my_cita = document.getElementById("divInterfaz");

        my_cita.moveTo(floatingMenu.nextX, 93);


        my_cita = dd.elements['imgLogo1'];
        //my_cita = document.getElementById("divInterfaz");
        my_cita.moveTo(floatingMenu.nextX, floatingMenu.nextY);
        my_cita = dd.elements['imgLogo0'];
        //my_cita = document.getElementById("divInterfaz");
        my_cita.moveTo(floatingMenu.nextX, 5);

        // my_cita = dd.elements['divCalendar'];
        //my_cita = document.getElementById("divInterfaz");

        //my_cita = document.getElementById("divInterfaz");
        my_cita.moveTo(floatingMenu.nextX + 1250 + 'px', 94);
        my_cita = dd.elements['divFind'];

        my_cita.moveTo(floatingMenu.nextX + document.documentElement.clientWidth - document.getElementById('divFind').offsetWidth - 550, 7);

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
