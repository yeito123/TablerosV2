<%@ Page Language="vb" AutoEventWireup="false" enableViewState="true" CodeBehind="TProgreso.aspx.vb" Inherits="TablerosV2.TProgreso" %>

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
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
    <style type="text/css">
       
        .cssHeader000 {
    text-align: left;
    font-family:   Lucida Grande,Lucida Sans,Arial,sans-serif;
    font-size: 20pt;
    width:100%;
      color:#74852E;
}
    .modalBack {
            background-color: black;
            filter: alpha(opacity=90);
            opacity: 0.8;
            z-index: 10000;
        }
        .clDivInterfaz {
            
             width: 150%;
             
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
         .cdivdedit2 {
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
    </style>

    <script type="text/javascript">

        var arrAsesores = [];
         
        arrAsesores[0] = "ASESOR";
        
        
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
                x = coordenadaXElemento - anchoElemento-100;
                y = coordenadaYElemento + altoElemento*2;

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

           
        }
        function mReloj() {
            momentoActual = new Date();
            
            try {
                document.getElementById("nreloj").value = momentoActual.format("dd/MM/yyyy hh:mm:ss tt");
                
            }
            catch (e) {}
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
			$("#divdedit2").hide();



            

            $('#cmdCancelComen').click(function (e) {
                $("#pnlComent").hide();
                e.preventDefault();
                e.stopPropagation();
                
                // __doPostBack('cmdGuardarComen', '');

            });
            $('#cmdCanceltxtxedit2').click(function (e) {
                $("#divdedit2").hide();
                e.preventDefault();
                e.stopPropagation();

                // __doPostBack('cmdGuardarComen', '');

            });

            $('#buttonHide').click(function () {
                $("#intdivInterfaz").toggle(400);

            });
           
 
 
            
            if ($.inArray($('#lblUsr').text().toLowerCase(), arrAsesores) < 0) {
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
                                case 'edit2':

                                    document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
                                    document.getElementById("lblInfoChip").value = 'El chip  ' + $('#' + document.getElementById("dhtml").value.split('.')[0] + '')[0].innerText + '  tiene un servicio de: ' + Math.round((document.getElementById("dhtml").value.split('.')[3] / 59) * 60) + '  minutos.';
                                    $find("mpe").show();

 

                                    break;

                                case 'comen':
                                    //Location('rvsn25_' + el[0].id);
                                    document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
                                    $("#pnlComent").show();
                                    $("#pnlComent").css({ zindex: 19999 })


                                    var dmy = dd.elements['pnlComent'];
                                    dmy.css.zIndex = 19999;
                                    dmy.moveTo(pos.docX, pos.docY);
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


                $("div.menu3").contextMenu({
                    menu: 'miMenu3'
                },
                     function (action, el, pos) {
                         switch (action) {
                             case 'add':
                                 //Location('rvsn25_' + el[0].id);
                                 //document.getElementById("imgBtnUpd_DMS").fireEvent("onclick", "");
                                 __doPostBack('imgBtnUpd_DMS', '');

                                 break;
                             case 'Refa':
                                 //Location('rvsn25_' + el[0].id);
                                 //document.getElementById("imgBtnUpd_DMS").fireEvent("onclick", "");
                                 $("#cboStop").val(2)
                                 __doPostBack('imgBtnUpd_DMS2', '');
                                 //Location('add_' + el[0].id);
                                 break;
                             case 'Auto':
                                 //Location('rvsn25_' + el[0].id);
                                 //document.getElementById("imgBtnUpd_DMS").fireEvent("onclick", "");
                                 $("#cboStop").val(3)
                                 __doPostBack('imgBtnUpd_DMS2', '');
                                 //Location('add_' + el[0].id);
                                 break;
                             case 'Ruta':
                                 //Location('rvsn25_' + el[0].id);
                                 //document.getElementById("imgBtnUpd_DMS").fireEvent("onclick", "");
                                 $("#cboStop").val(5)
                                 __doPostBack('imgBtnUpd_DMS2', '');
                                 //Location('add_' + el[0].id);
                                 break;
                             case 'Cali':
                                 //Location('rvsn25_' + el[0].id);
                                 //document.getElementById("imgBtnUpd_DMS").fireEvent("onclick", "");
                                 $("#cboStop").val(6)
                                 __doPostBack('imgBtnUpd_DMS2', '');
                                 //Location('add_' + el[0].id);
                                 break;
                             case 'Carry':
                                 //Location('rvsn25_' + el[0].id);
                                 //document.getElementById("imgBtnUpd_DMS").fireEvent("onclick", "");
                                 $("#cboStop").val(4)
                                 __doPostBack('imgBtnUpd_DMS2', '');
                                 //Location('add_' + el[0].id);
                                 break;
                             case 'TOT':
                                 //Location('rvsn25_' + el[0].id);
                                 //document.getElementById("imgBtnUpd_DMS").fireEvent("onclick", "");
                                 $("#cboStop").val(7)
                                 __doPostBack('imgBtnUpd_DMS2', '');
                                 //Location('add_' + el[0].id);
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
            }

 


        });
        $.expr[':'].icontains = function (obj, index, meta, stack) {
            return (obj.textContent || obj.innerText || jQuery(obj).text() || '').toLowerCase().indexOf(meta[3].toLowerCase()) >= 0;
        };
      //  $.post("TProgreso.aspx", { data: arrM }, function (r) { /* callback */ }, "text");
        $(document).ready(function () {

 
            $('#txtFind').keyup(function () {
                buscar = $(this).val();
                
                $('div[id*="ds"]').css({ "border-top": "0px solid black", "border-left": "1px solid black", "border-right": "1px solid black", "border-bottom": "1px solid black" });
                if (jQuery.trim(buscar) != '') {
                    $("div[id*='ds']:icontains('" + buscar + "')").css({ "border": "5px solid #ff0"  });
                }
            });
        });


  
        function chkMChk(obj) {
            obj = document.getElementById("chkM");
            if (obj.checked) {
               // document.getElementById("bMulti").value = arrM;
             //   alert(arrM[arrM.length - 1] + '__' + arrM.length)
                //alert(document.getElementById("bMulti").value);
                
            }
            else {
                //   alert('UCH');
                // alert(document.getElementById("bMulti").value);
                for (var i = arrM.length - 1; i >= 0; i--) {
                    document.getElementById(arrM[i].split('.')[0]).style.backgroundColor = arrMcolors[i];

                    
                }

                arrM = [];
                arrMcolors = [];
                document.getElementById("iMulti").value = '';
                //__doPostBack('__Page', '');
                //document.getElementById("bMulti").value = '0';
            }
        }
      
            


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
        <ul id="miMenu3" class="contextMenu3">
            <li class="edit">  <a href="#add">Grabar</a></li>
			<li class="edit" style="background-color: #BDB76B;"><a href="#Refa">Cambiar a Det. por Refacciones</a>  </li>
         <li class="edit" style="background-color: #FFA07A;"> <a href="#Auto">Cambiar a Det. por Autorizacion</a> </li>
     <%--    <li class="edit" style="background-color: #8FBC8B;"> <a href="#Ruta">Cambiar a Det. por Prueba Ruta</a></li>--%>
         <%-- <li class="edit" style="background-color: #cc9900;"> <a href="#Cali">Cambiar a Det. por Calidad</a></li>--%>
             <li class="edit" style="background-color: #D3D3D3;"> <a href="#Carry">Cambiar a Det. por En Proceso</a></li>
             <li class="edit" style="background-color: #660099;"> <a href="#TOT">Cambiar a Det. por TOT</a></li>
         
			  
		</ul>
           
      <ul id="miMenu" class="contextMenu">
			<li class="edit">    
            
            <a href="#move">Mover</a>  </li>
         <li class="edit"> <a href="#del">Borrar</a> </li>
         <li class="edit"> <a href="#edit">Modificar tiempos</a></li>
          <li class="edit2"> <a href="#edit2">Modificar tiempos captura</a></li>
                     <li class="comen"> <a href="#comen">Comentario</a></li>
          <%-- <li class="kdwD"> <a href="#kdwD">Diagnostico</a></li>
           <li class="kdwO"> <a href="#kdwO">Instruccion de Trabajo</a></li>--%>
			  
		</ul>
         <ul id="miMenu2" class="contextMenu">
			<li class="edit">
            
            
            <a href="#add">Grabar</a></li>
                   
			  
		</ul>
       
    <div id="topfix0" runat="server"  style="background-image: url('img/pleca_azulP.png'); background-repeat:repeat-x;  
          position: absolute; top: 0px; left: 0px;width:100%; ">
         
    </div>
     <div id="leftfix" runat="server" style="width: 92px;
          position: absolute;  left: 0px;background-color:white;z-index: 3001;">
         
    </div>
    <div id="floatdiv" style="background-image: url('img/pleca_azulP.png');background-repeat:repeat-x; position: absolute;
           left: 0px; top: 0px; z-index: 3002;width:100%;" runat="server">
          <input type="text" id="nreloj" name="nreloj" size="20"  style="z-index:4999;color:black;position:absolute;top:40px;left:700px;border:0;font-size:12px; font-weight:bold;" onfocus="window.document.form.nreloj.blur()" />

          <div id="buscador" style="  z-index:4999;   position: absolute; top:7px;   left:700px; color:black; ">
            <table><tr>
                 <td>

                            
                               Buscar <asp:TextBox ID="txtFind" runat="server"   Font-Size="11px" Style="width: 100px;" Visible="true"/>
                             
                                <asp:ImageButton ID="imgFind" runat="server" ImageUrl="img/Find_32x32.png"
                                    Style="height: 20px;" Visible="false"/>
                            </td>
                <td>
                    Edicion Multiple
                      <span   onchange="chkMChk(this);"   >
        <input id="chkM" name="chkM" type="checkbox" />
          
        </span>

                </td>

                   </tr></table>

        </div>
 
 
         <img  alt="" src="~/img/AgenciaLogoHeader.png" id="imgLogo1" runat="server" style="position: relative;z-index: 3003;height:3em;  " />
        <input type="text" value=""  runat="server" id="mymenu" style="z-index: 1000; left: 450px; position: absolute;
            top: 5px; display:none;  " />
        <input type="text" value=""  runat="server" id="dhtml" style="z-index: 1000; left: 550px; position: absolute;
            top: 5px; display:none; " />
       <input type="text" value="Fecha: " style="z-index: 1000; left: 15px; position: absolute;
            top: 20px;display:none; " />
        <asp:Label ID="lblCalendar" runat="server" Style="display:none;z-index: 1000; left: 75px; position: absolute;
            top: 20px; display:none; " Text=""></asp:Label>
        <input type="text" id="inptUsr" value="Usuario: " style="z-index: 1000; left: 15px; position: absolute;
            top: 35px;display:none; "   />
        <asp:Label ID="lblUsr" runat="server" Style="z-index: 1000; left: 75px; position: absolute;
            top: 35px;display:none; " Text=""></asp:Label>
      <input type="text" value="" runat="server" id="dhtmlChp" style="z-index: 1000; left: 850px;
            position: absolute; top: 5px;display:none; " />
        <input type="text" value=""  runat="server" id="dhMenu" style="z-index: 1000; left: 550px; position: absolute;
            top: 5px;display:none; " />
        <input type="hidden"  visible="true" runat="server"  id="iMulti"  value=""/>
       
        

      
         
    </div>
         <div id="dchp" style="background-position: left top; z-index:4999;  
        Left: 0px; width: 214px; position: absolute; Top: 0px; height: 90px; display:none;  "
        runat="server" visible="false" >
        <asp:Label ID="Modelo" runat="server"   Style="z-index: 100;
            left: 15px; position: absolute; top: 16px;display:none; " Text="Modelo:"   Width="72px"
            Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Tolerancia" runat="server"   Style="z-index: 101;
            left: 96px; position: absolute; top: 26px;display:none; " Text=""   Width="70px"
            Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Orden" runat="server"  Style="z-index: 102;
            left: 96px; position: absolute; top: 15px;display:none; " Text="Orden:"   Width="70px"
            Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Placas" runat="server"  Style="z-index: 103;
            left: 16px; position: absolute; top: 55px;display:none; " Text="Servicio:"   Height="16px"
            Width="72px" Font-Names="Calibri"></asp:Label>        
        <asp:Label ID="Service" runat="server"   Style="z-index: 106;
            left: 96px; position: absolute; top: 40px;display:none; " Text="Placas:"   Width="100px"
            Font-Names="Calibri"></asp:Label>
    </div>
      
   
         
    <div style="z-index: 3003; left: 0px; width: 1121px; position: absolute; height: 200px; " id="divInterfaz"
        runat="server" visible="true">
            <asp:ImageButton ID="imgRefrescar" runat="server" ImageUrl="img/Refresh.png"
                                            Style="height: 24px;left: 50px; position: absolute; top: 10px; z-index: 5000;" AlternateText="Refrescar" />

       <div id="divCalendar"  >
            <asp:TextBox ID="txtCalendar" AutoPostBack="true" runat="server" Style="display: none;
                z-index: 1000; left: 10px; position: absolute; top: 10px;" Text="Fecha" Width="1px"
                Height="1px" Font-Size="Medium" Font-Bold="False" ForeColor="White" />
            <img alt="" id="imgclCalendar" src="img/calendar.png" style="cursor: auto; z-index: 5000;
                left: 10px; position: absolute; top: 10px; background-color: Silver; border-bottom: solid 1px navy;
                width: 22px;" />
            <ajaxToolkit:CalendarExtender runat="server" Format="dd/MM/yyyy" OnClientShown="calendarShown"
                Animated="true" ID="clCalendarEx" TargetControlID="txtCalendar" PopupPosition="Right"
                PopupButtonID="imgclCalendar">
            </ajaxToolkit:CalendarExtender>
        </div>

          
         
  
        <table cellspacing="0" cellpadding="0"  class="clDivInterfaz">
                
                <tr>
               
                <td>
               
       
  <div class="gvContainer">
        <table style="width:90%; ">
                     <tr>
                         <td>
                             &nbsp;<table style="width:100%;">
                                 <tr>
                                     <td class="auto-style1">
                                         <table width="100%"><tr><td>
 

                                         <asp:RadioButtonList ID="rdlBuscar" RepeatDirection="Horizontal" runat="server" Visible="true">
                                             <asp:ListItem Selected="True">Orden</asp:ListItem>
                                             <asp:ListItem>Placas</asp:ListItem>
                                         </asp:RadioButtonList> 
                               
                                                    </td><td>
                                        <asp:TextBox ID="txtBuscar" runat="server" Height="12px" Font-Size="11px" Style="width: 50px;" Visible="true"/>
                            
                                <asp:ImageButton ID="imgBuscar" runat="server" ImageUrl="img/Find_32x32.png"
                                    Style="height: 20px;" Visible="true"/>
                                                    </td><td>

 Ordenes <asp:DropDownList ID="cboOrdenes" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                         </td></tr></table>

                                     </td>
                                     <td>
                                         <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" RepeatDirection="Horizontal" runat="server" Visible="false">
                          <asp:ListItem Value="0">Todos</asp:ListItem>
                        <asp:ListItem Value="2" style="background-color: #BDB76B;">Repuestos</asp:ListItem>
                        <asp:ListItem Value="3" style="background-color: #FFA07A;">Autorizacion</asp:ListItem>
                        <asp:ListItem Value="4" style="background-color: #D3D3D3;">En Proceso</asp:ListItem>
                       <%-- <asp:ListItem Value="5" style="background-color: #8FBC8B;">PruebaRuta</asp:ListItem>--%>
<%--                        <asp:ListItem Value="6" style="background-color: #cc9900;">Calidad</asp:ListItem>--%>
                      <asp:ListItem Value="7" style="background-color: #660099;">TOT</asp:ListItem>
                                         </asp:RadioButtonList>
         <asp:Menu ID="Menu1"   runat="server" DynamicMenuItemStyle-BorderColor="White"
        DynamicHoverStyle-BorderStyle="Solid" Orientation="Horizontal" 
                StaticEnableDefaultPopOutImage="False" OnMenuItemClick="Menu1_MenuItemClick" 
                DynamicHorizontalOffset="2"  ForeColor="#284E98" 
                StaticSubMenuIndent="10px"  CssClass="clsInterfazMenu">
             <StaticSelectedStyle BackColor="#507CD1" />
             <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
             
<DynamicHoverStyle BorderStyle="Solid" BackColor="#284E98" ForeColor="White"></DynamicHoverStyle>

             <DynamicMenuStyle BackColor="#B5C7DE" />
             <DynamicSelectedStyle BackColor="#507CD1" />

<DynamicMenuItemStyle BorderColor="White" HorizontalPadding="5px" VerticalPadding="2px"></DynamicMenuItemStyle>
             <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
        <Items>
            <asp:MenuItem   Text="Ordenes" Value="0"></asp:MenuItem>
             <asp:MenuItem   Text="Captura" Value="2"></asp:MenuItem>
            <asp:MenuItem   Text="Detenidos" Value="1"></asp:MenuItem>
             <asp:MenuItem   Text="Reprocesos" Value="3"></asp:MenuItem>
             <asp:MenuItem   Text="Paradas" Value="4"></asp:MenuItem>
            <asp:MenuItem Selectable="false" SeparatorImageUrl="~/img/SEPARADORl.gif" Text=""></asp:MenuItem>
               <asp:MenuItem    Text="SALIR" Value="5" ></asp:MenuItem>
              
        </Items>
    </asp:Menu>
                                     </td>
                                 </tr>
                             </table>
                            </td>

                     </tr>

                 </table>
                        <table   cellpadding="0" cellspacing="0     " style="width:90%; " class="style1">
                            <tr  >
                                 <td   valign="top" align="left">
<div id="divLeyendas" runat="server" visible="false" class="gvContainer1">
    <table><tr valign="top"><td>

            <asp:DataList ID="DataList2" runat="server" CellPadding="0" RepeatDirection="Vertical"
                                            RepeatLayout="Table" Font-Size="12px" Font-Names="Calibri" 
                                            HorizontalAlign="Left" CellSpacing="0">
                                            <ItemTemplate>
                                                <div style="border: solid 1px gray;" > 
                                                 <asp:Label ID="Label1" runat="server" Width="50px"  Text='<%# Eval("color") %>' />
                                                    <asp:Label ID="lblcveAsesor" runat="server" Text='<%# Eval("nombre") %>' />
                                                     
                                                </div>
                                            </ItemTemplate>
                                            <FooterStyle    />
                                            <AlternatingItemStyle   />
                                            <ItemStyle   />
                                            <SelectedItemStyle   />
                                            <HeaderStyle    />
                                        </asp:DataList>
               </td><td>

                   <img id="nomenclatura" alt="" src="img/SIMBOLOGIA.gif" onmouseover="mostrarTooltip(this,getElementById('tblNom').innerHTML)" />
                   
                   <div  id="tblNom" style="display:none;">
           <table   cellpadding="1" cellspacing="1"    id="tblNom">
                            <tr>
                                <td style="width: 25px; background-color:  <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dg")%>;">
                                  &nbsp;
                                     </td>   <td style="width: 200px;">
                                    Arribos con cita



                                </td>
                                </tr>
                            <tr>
                                <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dn")%>;">&nbsp;</td>
                                <td style="width: 200px;">
                                    No Arribo
                                </td>

                            </tr>
                            <tr>

                                <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "db")%>;">&nbsp;</td>
                                <td style="width: 200px;">
                                    Arribos sin cita
                                </td>
                                </tr>
                            <tr>

                                <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dgi")%>;">&nbsp;</td>
                                <td style="width: 200px;">
                                    Arribos con cita por internet
                                </td>
                                </tr>
                            <tr>

                                    <td style="width: 25px; background-color:  <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dl")%>;">&nbsp;</td>
                                <td style="width: 200px;">
                                        Servicio Terminado
                                    </td>


                            </tr>
                            <tr>
                                <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw5")%>;">&nbsp;</td>
                                <td style="width: 200px;">
                                    Detenido Prueba de Ruta</td>
                                </tr>
                            <tr>

                                    <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw3")%>;">&nbsp;</td>
                                <td style="width: 200px;">
                                        Detenido Autorizacion</td>

                            </tr>
                            <tr>
                                 <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw2")%>;">&nbsp;</td>
                                <td style="width: 200px;">
                                    Detenido Refacciones</td>

                                </tr>
                            <tr>

                                    <td style="width: 25px; background-color:  <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw4")%>;">&nbsp;
                                         </td>
                                <td style="width: 200px;">
                                        Detenido En proceso</td>


                                         </tr>

                                         <tr>
                                  <td style="width: 25px; background-color:  <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw7")%>;">&nbsp;</td>
                                             <td style="width: 200px;">
                                    Detenido TOT</td>




                                         </tr>
                        </table>


 </div>
                        </td></tr></table>
                       
                    </div>
                 <div id="leftfix0"    runat="server" class="clDivInterfazDtlst">

            </div>
                </td>
                                    <td   valign="top" align="left"> 
                                    
                                       
                            
                            
                                         <asp:datagrid ID="gvDMS" runat="server" AutoGenerateColumns="False"  
                Style=" width: 700px;"  CellPadding="1" ForeColor="#333333" 
                        GridLines="Horizontal" Font-Names="Calibri"     >
                        
                <Columns>
                
                    <asp:BoundColumn DataField="ASYS_RENGLON" HeaderText="NO." 
                                SortExpression="ASYS_RENGLON" Visible="false" >
                                <ItemStyle Width="25px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="noOrden" HeaderText="ORDEN" 
                                SortExpression="noOrden"  Visible="false" >
                                <ItemStyle Width="25px" />
                            </asp:BoundColumn>
                             <asp:TemplateColumn HeaderText="noOrden"> <ItemTemplate> 
                            <asp:TextBox ID="txtCapOrden" runat="server" width="50px"></asp:TextBox> 
                            </ItemTemplate> </asp:TemplateColumn>
                            <asp:BoundColumn DataField="horaAsesor" HeaderText="CITA" 
                                SortExpression="horaAsesor" >
                                <ItemStyle Width="25px" />
                            </asp:BoundColumn>
                           <asp:TemplateColumn HeaderText="Cliente"> <ItemTemplate> 
                            <asp:TextBox ID="txtCliente" runat="server" width="200px"></asp:TextBox> 
                            </ItemTemplate> </asp:TemplateColumn>

                            <asp:BoundColumn DataField="noPlacas" HeaderText="PLACAS" 
                                SortExpression="noPlacas" >
                                <ItemStyle Width="25px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="vehiculo" HeaderText="MODELO" 
                                SortExpression="vehiculo" >
                                <ItemStyle Width="50px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="servicioCapturado" HeaderText="DESCRIPCION" 
                                SortExpression="servicioCapturado" >
                                <ItemStyle Width="200px" />
                            </asp:BoundColumn>
                             <asp:TemplateColumn HeaderText="DESCRIPCION">  <ItemTemplate> 
                        <asp:DropDownList ID="cboCapServicio" Width="250" runat="server" onchange='buscaTm(this.value, this.id);'></asp:DropDownList> 
                             <asp:DropDownList ID="arr2T" Width="250" runat="server" style='display:none;'></asp:DropDownList> 
                        
                             </ItemTemplate> </asp:TemplateColumn>
                             
                                 <asp:TemplateColumn HeaderText="servicio"> <ItemTemplate> 
                            <asp:TextBox ID="txtservicio" Text="60" runat="server" width="35px"></asp:TextBox> 
                            </ItemTemplate> </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Torre"> <ItemTemplate> 
                            <asp:TextBox ID="txtTorre" runat="server" width="50px"></asp:TextBox> 
                            </ItemTemplate> </asp:TemplateColumn>
                            
                                 <asp:BoundColumn DataField="ano" Visible="false" />
                                  
                                    <asp:BoundColumn DataField="color" HeaderText="" 
                                  visible="false" />
                                  <asp:BoundColumn DataField="cilindros" HeaderText="" 
                                  visible="false" />
                                   <asp:BoundColumn DataField="idAsesor" HeaderText="" 
                                  visible="false" />
                                  <asp:BoundColumn DataField="colorprisma" HeaderText="" 
                                  visible="false" />
                                    <asp:BoundColumn DataField="id_hd" HeaderText="" SortExpression="id_hd"   Visible="true"/> 
                                   <%--<asp:BoundColumn DataField="seriecolorprisma"  HeaderText="sTorre" Visible="true"/>--%>
                    <asp:TemplateColumn >
                    <ItemTemplate>
                    <asp:ImageButton   runat="server"  ID="sel" ImageUrl="img/accept.gif" 
                            onclick="sel_Click1"    Visible="false"  />
                     
                         <asp:ImageButton   runat="server"  ID="ImageButton1" ImageUrl="img/accept.gif"  Visible="true"
                            onclick="sel_Click1"   />
                     
                      
                    </ItemTemplate>
                    
                    </asp:TemplateColumn>
                     
                       
                    
                </Columns>
                
                <ItemStyle BackColor="White" Height="5px" ForeColor="#333333" Font-Size="12px" Font-Bold="False" />
                <FooterStyle BackColor="#5D7B9D"   ForeColor="White" Font-Size="5px" Font-Bold="False"/>
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Size="1px" Font-Bold="False" />
                <SelectedItemStyle BackColor="#EFFE83"   ForeColor="#333333" Font-Size="12px" 
                        Font-Bold="True" />
                <HeaderStyle   BackColor="#001340" 
                    Font-Bold="True" ForeColor="White" Font-Size="12px"  CssClass="EncdsabezadoFijo"/>
                        <EditItemStyle BackColor="#999999" />
                <AlternatingItemStyle BackColor="White" ForeColor="#333333" Font-Size="12px" Font-Bold="False" />
            </asp:datagrid>

                                    </td>
                            
                              
                            </tr>

                             
                           
                        </table>
                    </div>          
               
         
          
                   
            </td>
             <td align="center">
                 
                  <table cellpadding="0" cellspacing="1"  >
                      <tr>
                           

                       

                            

                            <td align="left" colspan="1">
                             <asp:RadioButtonList runat="server" ID="lstFind" TextAlign="right" RepeatDirection="Vertical" 
                                    CellPadding="0" CellSpacing="0" Visible="false">
                            <asp:ListItem Text="Buscar Placas" Value="1" Selected="True">
                            </asp:ListItem>
                            <asp:ListItem  Text="Buscar Orden" Value="2">                            
                            </asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                            </tr>
                            
                     
                            <tr><td>
                                 <asp:ImageButton ID="imgBtnMve_DMS" runat="server"    Visible="false" />
       
                             <asp:ImageButton ID="imgBtnDel_DMS" runat="server"   Visible="false" />
                            
                            <asp:ImageButton ID="imgBtnCut_CHP" runat="server"    Visible="false" />
                             
                            <asp:ImageButton ID="imgBtnPrs_CHP" runat="server"   Visible="false" />
                            
                            <asp:ImageButton ID="imgBtnUpd_DMS" runat="server"   Visible="false" />
                                <asp:ImageButton ID="imgBtnUpd_DMS2" runat="server"   Visible="false" />
                             <asp:DropDownList ID="cboStop" runat="server" AutoPostBack="False"  style="display:none;">
                        <asp:ListItem Value="1">...</asp:ListItem>
                        <asp:ListItem Value="2" style="background-color: #BDB76B;">Repuestos</asp:ListItem>
                        <asp:ListItem Value="3" style="background-color: #FFA07A;">Autorizacion</asp:ListItem>
                        <asp:ListItem Value="4" style="background-color: #D3D3D3;">En Proceso</asp:ListItem>
                       <%-- <asp:ListItem Value="5" style="background-color: #8FBC8B;">PruebaRuta</asp:ListItem>--%>
                       <%-- <asp:ListItem Value="6" style="background-color: #cc9900;">Calidad</asp:ListItem>--%>
                      <asp:ListItem Value="7" style="background-color: #660099;">TOT</asp:ListItem>
                
                    </asp:DropDownList>
                            <asp:ImageButton ID="imgBtnRpt_DMS" runat="server"    Visible="false" />
                             
                             <asp:ImageButton ID="imgBtnTme_CHP" runat="server"   Visible="false" />
                                <asp:ImageButton ID="imgBtnDgn_Kdw" runat="server" ToolTip="Diagnóstico" Height="16px" Width="24px"  Visible="false" />
                              <asp:ImageButton ID="imgBtnWrk_Kdw" runat="server" ToolTip="Instrucción de trabajo" Height="16px" Width="24px" ImageUrl="~/img/move_f.gif" Visible="false" />
                            </td></tr>
                      <tr><td>
                            <asp:ImageButton ID="imgBtnOut_DMS" runat="server" ImageUrl="~/img/Salir.PNG"  Visible="false"  /> 
                            </td></tr>
                           
                            </table>
                  

                         <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo" style="display:none;" />

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
        
        
         <ajaxtoolkit:modalpopupextender id="MPGV" runat="server" backgroundcssclass="watermarked"
            cancelcontrolid="NoButtonMPGV" dropshadow="false" okcontrolid="OkButtonMPGV"
            oncancelscript="Cancel()" onokscript="PostB()" popupcontrolid="PopupMPGV" 
            targetcontrolid="cmdNuevo" x="40" y="10"    popupdraghandlecontrolid="PopupMPGV">
    </ajaxtoolkit:modalpopupextender>
        <asp:panel id="PopupMPGV" runat="server" style="display: block; ">
        <asp:Panel ID="PopupDragHandleMPGV" runat="Server" CssClass="" HorizontalAlign="Left">
            <div id="divPopupDragHandleMPGV" runat="server" >
              

             <div id="divifra" runat="server"  style=" left: 0px; position: absolute; top: 0px;">
              <%-- <iframe id="ifra" src="whuxgaHYPmainDet.aspx" height="555px" width="1265px"></iframe>--%>
             <p style="text-align: center;">
                <asp:Button ID="OkButtonMPGV" runat="server" BackColor="#eeeeee" BorderColor="Black"
                    Font-Bold="True" ForeColor="#000066" Text="Guardar" Width="100px" style="display:none;" />
                <asp:Button ID="NoButtonMPGV" runat="server" BackColor="#eeeeee" BorderColor="#2F4F4F"
                    Font-Bold="True" ForeColor="#000066" Text="Cerrar" Width="100px" />
            </p>
             </div>
          
            </div>
             
           
         
        </asp:Panel>
    </asp:panel>
    
        <div   id="pnlComent" class="cpnlComent">
            
            <table>
                <tr><td>Escriba su comentario</td></tr>
                <tr><td><asp:TextBox runat="server" ID="txtComen" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td><asp:Button runat="server" ID="cmdGuardarComen" Text="Guardar" /><asp:Button runat="server" ID="cmdCancelComen" Text="Cancelar" /></td></tr>

            </table>
        </div>
         <div class="cdivdedit2" id="divdedit2"><table><tr><td>Tiempo Minutos<asp:TextBox runat="server" ID="txtedit2"></asp:TextBox> </td></tr>
             <tr><td><asp:Button runat="server" ID="cmdGuardartxt2dit2" Text="Guardar" /><asp:Button runat="server" ID="cmdCanceltxtxedit2" Text="Cancelar" /></td></tr>
                               </table></div>

		 <!-- esto lo agrego Yeison para cambiar la forma en la que se modifican los chips ojala sirva te estoy avisando ;) -->

        <asp:Button runat="server" ID="btnmodal3"
            Style="display: none" Text="muestramodal" />
        <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="btnmodal3" PopupControlID="PanelDetalle"  
            Enabled="true" Drag="true" DropShadow="true" BackgroundCssClass="modalBack" CancelControlID="btnCancelar">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" ID="PanelDetalle" Style="display: none; background: white; width: 80%; height: auto">
            <div class="modal-dialog modal-sm"  role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <%--<asp:Button runat="server" type="button" CssClass="close" data-dismiss="modal" aria-label="Close" Text="x"></asp:Button>--%>
                        <h4 class="modal-title" id="myModalLabel">Modificar</h4>
                    </div>
                    <div class="modal-body" style="width: 100%;">
						<asp:Label ID="lblId" runat="server" Text=""    style="display:none;"></asp:Label>
						<textarea readonly="readonly" id="lblInfoChip" name="lblInfoChip" cols="30" rows="2" style="border:none"   > </textarea>
                          
                        <div id="dvlform" class="form-group form-lg" style="padding: 1em; width: 100%;">                            
                            <asp:Label runat="server" ID="lblTiempo" Text="Tiempo en minutos: "></asp:Label>
                            <asp:TextBox ID="txtMinutos" runat="server" TextMode="SingleLine"
                                ReadOnly="false"
                                placeholder="Minutos"
                                CssClass="form-control" Style="width:100%;"></asp:TextBox>
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



       floatingMenu.move = function() {
           floatingMenu.menu.style.left = '1' + 'px';
           floatingMenu.menu.style.top = floatingMenu.nextY + 'px';

           document.getElementById("dhtml").value = "divcitas";

           var my_date;
           var my_item;
           var my_cita;
           var my_serv;

           //my_item = dd.elements['topfix0'];
           //my_item.moveTo(my_item.defx, floatingMenu.nextY + 400);

           my_cita = dd.elements['divInterfaz'];
           //my_cita = document.getElementById("divInterfaz");
           my_cita.moveTo(floatingMenu.nextX  , floatingMenu.nextY + document.documentElement.clientHeight - document.getElementById('divInterfaz').offsetHeight  -10);
           my_cita = dd.elements['leftfix'];
           //my_cita = document.getElementById("divInterfaz");

           my_cita.moveTo(floatingMenu.nextX, 93);
 
           
           my_cita = dd.elements['imgLogo1'];
           //my_cita = document.getElementById("divInterfaz");
           my_cita.moveTo(floatingMenu.nextX , floatingMenu.nextY );
           my_cita = dd.elements['imgLogo0'];
           //my_cita = document.getElementById("divInterfaz");
           my_cita.moveTo(floatingMenu.nextX, 5);

          // my_cita = dd.elements['divCalendar'];
           //my_cita = document.getElementById("divInterfaz");
          
           //my_cita = document.getElementById("divInterfaz");
           my_cita.moveTo(floatingMenu.nextX + 1250 + 'px', 94);
           //my_cita = dd.elements['divFind'];

           //my_cita.moveTo(floatingMenu.nextX + document.documentElement.clientWidth - document.getElementById('divFind').offsetWidth - 550, 7);

           my_cita = dd.elements['dhtml'];
           //my_cita = document.getElementById("divInterfaz");
           my_cita.moveTo(floatingMenu.nextX + 300, floatingMenu.nextY + 'px');

           my_cita = dd.elements['divifra'];
           //my_cita = document.getElementById("divInterfaz");
           my_cita.moveTo(floatingMenu.nextX , floatingMenu.nextY + 'px');
           

           //            my_serv = dd.elements['divServicios'];
           //            my_serv.moveTo(my_serv.defx, floatingMenu.nextY + 307);

           //            my_cita = dd.elements['divCitas'];
           //            my_cita.moveTo(my_cita.defx, floatingMenu.nextY + 450);

       }

       floatingMenu.computeShifts = function() {
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

       floatingMenu.calculateCornerX = function() {
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

       floatingMenu.calculateCornerY = function() {
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

       floatingMenu.doFloat = function() {
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
       floatingMenu.addEvent = function(element, listener, handler) {
           if (typeof element[listener] != 'function' ||
           typeof element[listener + '_num'] == 'undefined') {
               element[listener + '_num'] = 0;
               if (typeof element[listener] == 'function') {
                   element[listener + 0] = element[listener];
                   element[listener + '_num']++;
               }
               element[listener] = function(e) {
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

       floatingMenu.init = function() {
           floatingMenu.initSecondary();
           floatingMenu.doFloat();
       };

       // Some browsers init scrollbars only after
       // full document load.
       floatingMenu.initSecondary = function() {
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
