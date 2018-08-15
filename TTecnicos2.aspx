<%@ Page Language="vb" AutoEventWireup="false" enableViewState="true" CodeBehind="TTecnicos2.aspx.vb" Inherits="TablerosV2.TTecnicos2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
 <meta http-equiv="refresh" content="60" />
   <script src="JS/wz_dragdrop.js" type="text/javascript"></script>

    <script src="JS/wz_jsgraphics.js" type="text/javascript"></script>
     <link rel="stylesheet" href="css/jquery-ui.css" />    
       <link href="css/jquery.contextMenu.css" rel="stylesheet" type="text/css" />
     <script  type="text/javascript" src="JS/jquery-1.9.1.js"></script>
     <script type="text/javascript" src="JS/jquery-ui.js"></script>
         <script type="text/javascript" src="js/jquery.contextMenuIz.js"  ></script>
    <link rel="stylesheet" href="css/generales.css" />   
    <style type="text/css">
      
        .cssHeader000 {
    text-align: left;
    font-family:   Lucida Grande,Lucida Sans,Arial,sans-serif;
    font-size: 20pt;
    width:100%;
      color:#74852E;
}
    
        .clDivInterfaz {
            
             width: 100%;
             
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
        .cpnlComent {
         position: absolute;
            z-index: 10005;
            background-color: Gray;
            filter: alpha(opacity=75);
            font-size:15px;
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
            var winterfaz = document.getElementById("wInterfaz").value;
            //alert(winterfaz);
            if (winterfaz != "1121px") {
                $(".gvContainer").css({
                    'width': '35px',
                    'height': '25px'
                });
                $("#divInterfaz").css({
                    'width': '35px',
                    'height': '25px'
                });
            }
            else {
                $("#divInterfaz").css({
                    'width': '1121px',
                    'height': '200px'
                });
                $(".gvContainer").css({
                    'width': '100%',
                    'height': ''
                });


                // $("#wInterfaz").val('15px');

            }
            
            
            $("#pnlComent").hide();
            $("#pnlDetencion").hide();
            $("#pnlFin").hide();
           
            $('#cmdCancelComen').click(function (e) {
                $("#pnlComent").hide();
                e.stopPropagation();
               // __doPostBack('cmdGuardarComen', '');

            });

            $('#cmdCancelComenDet').click(function (e) {
               
                $("#pnlDetencion").hide();
                e.preventDefault()
                // __doPostBack('cmdGuardarComen', '');

            });

            $('#Button2').click(function (e) {
                ///evt.stopPropagation();
               
                $("#pnlFin").hide();
                e.preventDefault()
                // __doPostBack('cmdGuardarComen', '');

            });


            $('#divInterfaz').dblclick(function () {
                var width = $("#divInterfaz").css('width');
                
                
                if (width == "1121px") {
                    $(".gvContainer").css({
                    'width':'35px',
                    'height': '25px'
                });
               
                    $("#divInterfaz").css({
                        'width': '35px',
                        'height': '25px'
                    });
                    $("#wInterfaz").val('15px');
                    document.getElementById("wInterfaz").value = '15px';

                }
               
                else {
                    $("#divInterfaz").css({
                        'width': '1121px',
                        'height': '200px'
                    });
                    $(".gvContainer").css({
                        'width':'100%',
                        'height': ''
                    });
               
                    $("#wInterfaz").val('1121px');
                    document.getElementById("wInterfaz").value = '1121px';

                }
                
               

                

            });

        });



        $(document).ready(function () {

            // Show menu when #myDiv is clicked
            $("div.menu").contextMenu({
                menu: 'miMenu'
            },
					function (action, el, pos) {
					   
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
					            document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
					            __doPostBack('btnIni', '');
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
					            $("#pnlDetencion").css({ left: pos.docX });
					            $("#pnlDetencion").css({ top: pos.docY });
					            // Location('move_' + el[0].id);
					            break;
					        case 'fin':
					            //Location('rvsn25_' + el[0].id
					            //document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
					            //__doPostBack('btnFin', '');

					            document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
					            $("#pnlFin").show();
					            $("#pnlFin").css({ left: pos.docX });
					            $("#pnlFin").css({ top: pos.docY });
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
              <asp:Timer ID="Timer13"  Enabled="true" runat="server" Interval="12000"></asp:Timer>
       <input type="hidden" runat="server" id="wInterfaz"   />
          
      <ul id="miMenu" class="contextMenu">
			  <li class="edit">
                    
            
            <a href="#ini">Iniciar</a>  </li>
         <li class="edit"> <a href="#det">Detener</a> </li>
         <li class="edit"> <a href="#fin">Finalizar</a></li>
                     <li class="comen"> <a href="#comen">Comentario</a></li>
            <li class="init">  <a href="#init">Reiniciar</a>  </li>
           <li class="NoAuto"> <a href="#NoAuto">No Autoriza</a>  </li>
           <li class="edit"> <a href="#Lavar">Lavar</a>  </li>
          <%-- <li class="kdwD"> <a href="#kdwD">Diagnostico</a></li>
           <li class="kdwO"> <a href="#kdwO">Instruccion de Trabajo</a></li>--%>
			  
		</ul>
         <ul id="miMenu2" class="contextMenu">
			<li class="edit">
            
            
            <a href="#add">Grabar</a></li>
                   
			 
		</ul>
    <div id="topfix0" runat="server"  style="background-image: url('img/pleca_azulT.png'); background-repeat:repeat-x; height: 100%;
          position: absolute; top: 0px; left: 0px;width:100%; ">
         
    </div>
     <div id="leftfix" runat="server" style="width: 92px;
          position: absolute;  left: 0px;background-color:white;z-index: 3001;">
         
    </div>
    <div id="floatdiv" style="background-image: url('img/pleca_azulT.png');background-repeat:repeat-x; position: absolute;
          height: 100%; left: 0px; top: 0px; z-index: 3002;width:100%;" runat="server">
          <input type="text" id="nreloj" name="nreloj" size="20"  style="z-index:4999;color:black;position:absolute;top:30px;left:700px;border:0;font-size:12px; font-weight:bold;" onfocus="window.document.form.nreloj.blur()" />

 
  <div id="buscador" style="  z-index:4999;   position: absolute; top:7px;   left:700px; color:black; ">
            <table><tr>
                 <td>
                            
                               Buscar <asp:TextBox ID="txtFind" runat="server"  Font-Size="11px" Style="width: 100px;" Visible="true"/>
                             
                                <asp:ImageButton ID="imgFind" runat="server" ImageUrl="img/Find_32x32.png"
                                    Style="height: 20px;" Visible="false"/>
                            </td>

                   </tr></table>

        </div>

         <div style=" display:none; position:absolute;top:0;z-index:9999;" ><table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%; " class="cssHeader000">
             <tr>
                <td valign="top" style="padding:10px;display:none;">                    
                    <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                        <RootNodeTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("title") %>' CommandArgument='<%# Eval("url") %>' ></asp:LinkButton>
                        </RootNodeTemplate>
                    </asp:SiteMapPath>
       
                </td>            
               <td align="left">                    
                    <asp:HyperLink ID="lnkPrev" runat="server">Prev</asp:HyperLink> || <asp:HyperLink
                        ID="lnkUp" runat="server" Visible="false">Up</asp:HyperLink>   <asp:HyperLink ID="lnkNext" runat="server">Next</asp:HyperLink>
                </td>
            </tr>
        </table></div>
         <img  alt="" src="img/LOGOHeader.PNG" id="imgLogo1" runat="server" style="position: relative;z-index: 3003;" />
        <input type="text" value=""  runat="server" id="dhtml" style="z-index: 1000; left: 550px; position: absolute;
            top: 5px; background-color: transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: transparent; font-weight: bold;" />
       <input type="text" value="Fecha: " style="z-index: 1000; left: 15px; position: absolute;
            top: 20px; background-color: Transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: transparent; font-weight: bold;" />
        <asp:Label ID="lblCalendar" runat="server" Style="z-index: 1000; left: 75px; position: absolute;
            top: 20px; background-color: Transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: White; font-weight: bold;" Text=""></asp:Label>
        <input type="text" value="Usuario: " style="z-index: 1000; left: 15px; position: absolute;
            top: 35px; background-color: Transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: White; font-weight: bold;" />
        <asp:Label ID="lblUsr" runat="server" Style="z-index: 1000; left: 75px; position: absolute;
            top: 35px; background-color: Transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: White; font-weight: bold;" Text=""></asp:Label>
      <input type="text" value="" runat="server" id="dhtmlChp" style="z-index: 1000; left: 850px;
            position: absolute; top: 5px; background-color: Transparent; border: none; font-size: 12px;
            font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif; color: transparent; font-weight: bold;" />
       
         <input type="text" value=""  runat="server" id="dhMenu" style="z-index: 1000; left: 550px; position: absolute;
            top: 5px; background-color: transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: transparent; font-weight: bold;" />
       
    </div>
         <div id="dchp" style="background-position: left top; z-index:4999;  
        Left: 0px; width: 214px; position: absolute; Top: 0px; height: 90px; border-left-color: blue;
        border-bottom-color: blue; border-top-color: blue; border-right-color: blue;
        font-family: 'Calibri'; background-color: white; background-image: url(img/chipText.PNG); "
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
        
    <div style="z-index: 3003; left: 0px; width: 1121px; position: absolute; height: 200px; " id="divInterfaz"
        runat="server" visible="true">

                <asp:ImageButton ID="imgRefrescar" runat="server" ImageUrl="img/Refresh.png"
                                            Style="height: 24px;left: 50px; position: absolute; top: 10px; z-index: 5000;" AlternateText="Refrescar" />

       <div id="divCalendar"  > 
            <asp:TextBox ID="txtCalendar" AutoPostBack="true" runat="server" Style="display: block;
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
                                     <td class="auto-style1">Buscar Orden <asp:TextBox ID="txtBuscar" runat="server" Height="12px" Font-Size="11px" Style="width: 50px;" Visible="true"/>
                             
                                <asp:ImageButton ID="imgBuscar" runat="server" ImageUrl="img/Find_32x32.png"
                                    Style="height: 20px;" Visible="true"/>
                                     </td>
                                     <td>
                                          
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

 <table   cellpadding="1" cellspacing="1" style="width:90%; ">
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
                                    No show
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
                                        Detenido Carry Over</td>
                                    
                                         
                                         </tr>
          <tr>
                               
                                    <td style="width: 25px; background-color:  <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw6")%>;">&nbsp;
                                         </td>
                                <td style="width: 200px;">
                                        Detenido Calidad</td>
                                    
                                         
                                         </tr>

                                         <tr>
                                  <td style="width: 25px; background-color:  <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw7")%>;">&nbsp;</td>
                                             <td style="width: 200px;">
                                    Detenido TOT</td>

                              
                                     
                                         
                                         </tr>
                        </table>
                        </td></tr></table>
                    </div>
                 <div id="leftfix0"    runat="server" class="clDivInterfazDtlst">
                    
            </div>
                </td>
                                    <td   valign="top" align="left"> 
                                        &nbsp;</td>
                            
                              
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
                       <asp:ImageButton ID="btnStop1" runat="server" ImageUrl="img/tecParar.PNG" Visible="false" />
                   
                    <asp:ImageButton ID="btnInit" runat="server" ImageUrl="img/tecReiniciar.PNG" Visible="false" />
                    <asp:ImageButton ID="btnIni" runat="server" ImageUrl="img/tecInicio.PNG" Visible="false" />
                    <asp:ImageButton ID="btnFin1" runat="server" ImageUrl="img/tecFin.PNG" Visible="false" />
                     <asp:ImageButton ID="imgBtnDgn_Kdw" runat="server" ToolTip="Diagnóstico" Height="16px" Width="24px"  Visible="false" />
                     <asp:ImageButton ID="imgBtnWrk_Kdw" runat="server" ToolTip="Instrucción de trabajo" Height="16px" Width="24px" ImageUrl="~/img/move_f.gif" Visible="false" />
                                <asp:ImageButton ID="btnNoAutoriza" runat="server" ToolTip="NoAutoriza" Height="16px" Width="24px" ImageUrl="~/img/move_f.gif" Visible="false" />
                              <asp:ImageButton ID="btnLvd" runat="server" Visible="false"  ImageUrl="~/img/Lavado.PNG" />

                                 
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
                <tr><td><asp:TextBox runat="server" ID="txtComen" Font-Size="14px" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td><asp:Button runat="server" ID="cmdGuardarComen" Text="Guardar" /><asp:Button runat="server" ID="cmdCancelComen" Text="Cancelar" /></td></tr>

            </table>
        </div>
      
         <div   id="pnlFin" class="cpnlComent">
            
            <table>
                <tr><td>Desea Finalizar</td></tr>
                <tr><td>      
                     <asp:Button runat="server" ID="btnFin" Text="Aceptar" />
                    <asp:Button runat="server" ID="Button2" Text="Cancelar" /></td></tr>

            </table>
        </div>
         <div   id="pnlDetencion" class="cpnlComent">
            
            <table>
                <tr><td>Elija un Motivo de detencion</td></tr>
                <tr><td> <asp:DropDownList ID="cboStop" runat="server" AutoPostBack="False" Visible="True">
                        <asp:ListItem Value="1">...</asp:ListItem>
                        <asp:ListItem Value="2" style="background-color: #BDB76B;">Refacciones</asp:ListItem>
                        <asp:ListItem Value="3" style="background-color: #FFA07A;">Autorizacion</asp:ListItem>
                        <asp:ListItem Value="4" style="background-color: #D3D3D3;">En Proceso</asp:ListItem>
                        <asp:ListItem Value="5" style="background-color: #8FBC8B;">PruebaRuta</asp:ListItem>
                        <asp:ListItem Value="6" style="background-color: #cc9900;">Calidad</asp:ListItem>
                      <asp:ListItem Value="7" style="background-color: #660099;">TOT</asp:ListItem>
                
                    </asp:DropDownList></td></tr>
                <tr><td>Escriba su comentario</td></tr>
                <tr><td><asp:TextBox runat="server" ID="txtComenDet" Font-Size="14px" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td><asp:Button runat="server" ID="btnStop"  Text="Detener" />
                    <asp:Button runat="server" ID="cmdCancelComenDet" Text="Cancelar" /></td></tr>

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
           my_cita.moveTo(floatingMenu.nextX  , floatingMenu.nextY + document.documentElement.clientHeight - document.getElementById('divInterfaz').offsetHeight  -50);
           my_cita = dd.elements['leftfix'];
           //my_cita = document.getElementById("divInterfaz");

           my_cita.moveTo(floatingMenu.nextX, 93);
 
           
           my_cita = dd.elements['imgLogo1'];
           //my_cita = document.getElementById("divInterfaz");
           my_cita.moveTo(floatingMenu.nextX , floatingMenu.nextY );
           my_cita = dd.elements['imgLogo0'];
           //my_cita = document.getElementById("divInterfaz");
           my_cita.moveTo(floatingMenu.nextX, 5);

           my_cita = dd.elements['divFind'];
           //my_cita = document.getElementById("divInterfaz");
           my_cita.moveTo(floatingMenu.nextX + 1250, 94);

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
