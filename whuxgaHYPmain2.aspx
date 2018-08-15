<%@ Page Language="vb"  AutoEventWireup="false" CodeBehind="whuxgaHYPmain2.aspx.vb"
    Inherits="TablerosV2.whuxgaHYPmain2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <meta http-equiv="refresh" content="6000" />
    <script src="JS/wz_dragdrop2.js" type="text/javascript"></script>
    <script src="JS/wz_jsgraphics.js" type="text/javascript"></script>
   
      <link type='text/css' href='css/HypGeneral.css' rel='stylesheet' media='screen' />
       <link rel="stylesheet" href="css/jquery-ui.css" />    

        <link href="css/jquery.contextMenu.css" rel="stylesheet" type="text/css" />
     <script  type="text/javascript" src="JS/jquery-1.9.1.js"></script>
     <script type="text/javascript" src="JS/jquery-ui.js"></script>
         <script type="text/javascript" src="js/jquery.contextMenu.js"  ></script>
 <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
  
    <link type='text/css' href='css/umodal.css' rel='stylesheet' media='screen' />
    <script type='text/javascript' src='js/jquery.simplemodal.js'></script>
<script type='text/javascript' src='js/umodal.js'></script>


     <style type="text/css">
         .to_center {margin-left:auto; margin-right:auto;}
            .floated {float:left;}

     </style>
    <script type="text/javascript">
        var ids = ["dhtml"];
        var backs = ['transparent'];
        function calendarShown(sender, args) {
            sender._popupBehavior._element.style.zIndex = 10005;
        }

        function Location(sDiv) {

            document.getElementById("cmdNuevo").fireEvent("onclick", "");
            // window.frames.ifra.dopost();


        }
        function Location2(sDiv) {
            document.getElementById("lblNuevo2").value = sDiv;
            document.getElementById("cmdNuevo2").fireEvent("onclick", "");
            // window.frames.ifra.dopost();  


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
        function chkFI(obj) {
            if (obj.checked == true) {
                document.getElementById('lblFechaCita').disabled = false;
                document.getElementById('cboHoraCita').disabled = false;
                document.getElementById('chkCita').disabled = false;
            }
            else {
                document.getElementById('lblFechaCita').disabled = true;
                document.getElementById('cboHoraCita').disabled = true;
                document.getElementById('chkCita').disabled = true;
            }
        }
        function f(obj) {
            return true;
        }
        
        

         
        $.expr[':'].icontains = function (obj, index, meta, stack) {
            return (obj.textContent || obj.innerText || jQuery(obj).text() || '').toLowerCase().indexOf(meta[3].toLowerCase()) >= 0;
        };
        
        $(document).ready(function () {

            window.scrollTo($("div[id*='txtDia']:icontains('" + new Date().format('dd/MM/yyyy') + "')").offset().left - 300, $("div[id*='txtDia']:icontains('" + new Date().format('dd/MM/yyyy') + "')").offset().top - 400);

            if ($("#lblmessage").text() != '') {
                $("input.umodal").trigger("click");
            }

            $('div[id*="ds"]').hover(function (e) {

                mostrarTooltip(this, this.title);
                $(this).tooltip({ disabled: true });
            });

            $('#intdivInterfaz').show();

            $('#buttonHide').click(function () {
                $("#intdivInterfaz").toggle(400);

            });

            $("#lblFechaCita").datepicker({ dateFormat: 'dd/mm/yy' });
            $('#txtFind').keyup(function () {
                buscar = $(this).val();

                //$('div[id*="ds"]').css({ "border-left": "1px solid black", "border-right": "1px solid black", "border-bottom": "1px solid black" });
                for (var i = 0; i < ids.length; i++) {
                    document.getElementById(ids[i]).style['background-color'] = backs[i];
                }

                if (jQuery.trim(buscar) != '') {
                    var jo = $("div[id*='ds']:icontains('" + buscar + "')");
                    for (var i = 0; i < jo.length; i++) {
                        ids.push(jo[i].id);
                        backs.push(document.getElementById(jo[i].id).style['background-color']);
                        jo[i].style['background-color'] = 'yellow';
                    }

                    window.scrollTo($("div[id*='ds']:icontains('" + buscar + "')").offset().left - 300, $("div[id*='ds']:icontains('" + buscar + "')").offset().top - 400);
                    //$("div[class*='menu']:icontains('" + buscar + "')").effect("highlight", { color: "yellow" }, 5000);
                }
            });
            $('#txtbuscar').keyup(function () {
                buscar = $(this).val();

                var jo1 = $("div[id*='divHOrden']");
                if (jQuery.trim(buscar) != '') { jo1.parent().parent().hide(); } else { jo1.parent().parent().show(); }
              
               
                if (jQuery.trim(buscar) != '') {
                    
                   
                    var jo = $("div[id*='divHOrden']:icontains('" + buscar + "')").parent().parent();
                    jo.show();
                    
                }

                

            });
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
                           
                          case 'edit':
                              //Location('rvsn25_' + el[0].id);
                              document.getElementById("dhtml").value = document.getElementById("dhMenu").value;
                              __doPostBack('imgBtnTme_CHP', '');
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" AsyncPostBackTimeout="0" ID="scrmgr1">
    </asp:ScriptManager>
         <ul id="miMenu" class="contextMenu">
			<li class="edit">    
            
            <a href="#move">Mover</a>  </li>
         
       <%--  <li class="edit"> <a href="#edit">Modificar</a></li>--%>
         
			  
		</ul>
    <div id="topfix0" runat="server" style="background-image: url('img/pleca_azulA.png');
        background-repeat: repeat-x; height: 90px; position: absolute; top: 0px; left: 3px;
        width: 100%;">
        <img alt="" src="img/LOGOHeader.PNG" id="imgLogo0" runat="server" style="position: relative;
            top: 5px; left: 950px;" />
    </div>
    <div id="leftfix" runat="server" style="width: 92px; position: absolute; left: 0px;
        background-color: white; z-index: 3001;">
    </div>
    <div id="floatdiv" style="background-image: url('img/pleca_azulA.png'); background-repeat: repeat-x;
        position: absolute; height: 90px; left: 0px; top: 0px; z-index: 3002; width: 100%;"
        runat="server">

        <div id="divFind"   style="  z-index:4999;   position: absolute; top:7px;   left:600px; background-color:#003366;   ">
            <table   class="table-condensed"    style="  background-color:transparent;  color:white; border:groove 1px white;"><tr>
                 <td>
                            Buscar <asp:TextBox ID="txtFind" runat="server"   Font-Size="11px" Style="width: 100px;" Visible="true"/>
                             
                                <asp:ImageButton ID="imgFind" runat="server" ImageUrl="img/Find_32x32.png"
                                    Style="height: 20px;" Visible="false"/>
                            </td>
                   

                <td>
                      

                </td>
                <td>
                     <asp:ImageButton ID="imgRefrescar" runat="server" ImageUrl="img/Refresh.png"
                                            Style="height: 24px; " AlternateText="Refrescar" />
     

                </td>
                 <td align="right">
                     <asp:ImageButton ID="imgBtnOut_DMS" runat="server" ImageUrl="~/img/logout2.PNG" style=" background-color:white;" />
                    </td>
                   </tr></table>

        </div>

         <img  alt="" src="img/AgenciaLogoHeader.PNG" id="imgLogo1" runat="server" style="position: relative;z-index: 3003;height:4em; " />
         <input type="text" value=""  runat="server" id="mymenu" style="z-index: 1000; left: 450px; position: absolute;
            top: 5px; background-color: transparent; border: none;  color: black;  " />
        <input type="text" value="" runat="server" id="dhtml" style="z-index: 1000; left: 550px;
            position: absolute; top: 5px; background-color: Transparent; border: none; font-size: 12px;
            font-family: Arial; color: transparent; font-weight: bold;" />
        <input type="text" value="Fecha: " style="z-index: 1000; left: 15px; position: absolute;
            top: 20px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: transparent; font-weight: bold;" />
        <asp:Label ID="lblCalendar" runat="server" Style="z-index: 1000; left: 75px; position: absolute;
            top: 20px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: White; font-weight: bold;" Text=""></asp:Label>
        <input type="text" value="Usuario: " style="z-index: 1000; left: 15px; position: absolute;
            top: 35px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: White; font-weight: bold;" />
        <asp:Label ID="lblUsr" runat="server" Style="z-index: 1000; left: 75px; position: absolute;
            top: 35px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: White; font-weight: bold;" Text=""></asp:Label>
        <input type="text" value="" runat="server" id="dhtmlChp" style="z-index: 1000; left: 850px;
            position: absolute; top: 5px; background-color: Transparent; border: none; font-size: 12px;
            font-family: Arial; color: transparent; font-weight: bold;" />
         <input type="text" value=""  runat="server" id="dhMenu" style="z-index: 1000; left: 550px; position: absolute;
            top: 5px; background-color: transparent; border: none; font-size: 12px; font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;
            color: transparent; font-weight: bold;" />
        <div id="divCalendar">
            <asp:TextBox ID="txtCalendar" AutoPostBack="true" runat="server" Style="display: block;
                z-index: 1000; left: 1235px; position: absolute; top: 90px" Text="Fecha" Width="1px"
                Height="1px" Font-Size="Medium" Font-Bold="False" ForeColor="White"  />
           
             <div id="divFindd" runat="server" style="cursor: hand; z-index: 5000; position: absolute;
                top: 120px; background-color: white; border-top: solid 1px navy; border-bottom: solid 1px navy;
                height: 395px; width: 95px; font-size: 11px; display:none;">
                <table cellpadding="0" cellspacing="5">
                    <tr>
                        <td align="left" colspan="1">
                            <asp:RadioButtonList runat="server" ID="lstFind" TextAlign="right" RepeatDirection="Vertical"
                                CellPadding="0" CellSpacing="0" Visible="false">
                                <asp:ListItem Text="Buscar Orden" Value="2">                            
                                </asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                     
                </table>
                <table class="table-condensed" >
                    <tr>
                        <td>
                            <asp:ImageButton ID="imgBtnMve_DMS" runat="server" ImageUrl="~/img/MoverCita.PNG"
                                Visible="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="imgBtnDel_DMS" runat="server" ImageUrl="~/img/BorrarCita.PNG"
                                Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="imgBtnCut_CHP" runat="server" ImageUrl="~/img/Cortar.PNG" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="imgBtnPrs_CHP" runat="server" ImageUrl="~/img/Pegar.PNG" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="imgBtnUpd_DMS" runat="server" ImageUrl="~/img/GrabarCita.PNG"
                                Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="imgBtnRpt_DMS" runat="server" ImageUrl="~/img/Prepicking.PNG"
                                Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="imgBtnTme_CHP" runat="server" ImageUrl="~/img/AumentaTiempo.PNG"
                                Visible="false" />
                        </td>
                    </tr>
                     
                </table>
            </div>
        </div>
    </div>
    <div id="dchp" style="background-position: left top; z-index: 4999; left: 0px; width: 214px;
        position: absolute; top: 0px; height: 90px; border-left-color: blue; border-bottom-color: blue;
        border-top-color: blue; border-right-color: blue; font-family: 'Calibri'; background-color: white;
        background-image: url(img/chipText.PNG);" runat="server" visible="false">
        <asp:Label ID="Modelo" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 100;
            left: 15px; position: absolute; top: 16px" Text="Modelo:" Width="72px" Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Tolerancia" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 101;
            left: 96px; position: absolute; top: 26px" Text="" Width="70px" Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Orden" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 102;
            left: 96px; position: absolute; top: 15px" Text="Orden:" Width="70px" Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Placas" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 103;
            left: 16px; position: absolute; top: 55px" Text="Servicio:" Height="16px" Width="72px"
            Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Service" runat="server" Font-Size="10px" ForeColor="Black" Style="z-index: 106;
            left: 96px; position: absolute; top: 40px" Text="Placas:" Width="100px" Font-Names="Calibri"></asp:Label>
    </div>
    <div style="z-index: 3003;  width: 1265px; position: absolute; " id="divInterfaz" runat="server" visible="true">
         <a href="#" id="buttonHide"  class="ui-state-default ui-corner-all" >Mostrar/Ocultar</a>
       <div id="intdivInterfaz">
        <table cellspacing="0" cellpadding="0" style="border-width: 2px; border-color: #001340;
            width: 100%;   font-size: 15px; font-weight: bold; border-top-style: solid;
            border-bottom-style: solid;  background-color:azure; ">
            <tr>
               
                <td>

                     <table   cellpadding="1" cellspacing="1"    id="tblNom">
                            <tr>
                                <td style="width: 25px; background-color:  <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dgre")%>;">
                                  &nbsp;
                                     </td>   <td style="width: 200px;">
                                    Recepcion



                                </td>
                                </tr>
                            <tr>
                                <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dgen")%>;">&nbsp;</td>
                                <td style="width: 200px;">
                                    Entrega
                                </td>

                            </tr>
                            <tr>

                                <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dg")%>;">&nbsp;</td>
                                <td style="width: 200px;">
                                    Servicio con cita
                                </td>
                                </tr>
                         <tr>

                                <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "db")%>;">&nbsp;</td>
                                <td style="width: 200px;">
                                    Servicio sin cita
                                </td>
                                </tr>
                            <tr>

                                <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dgl")%>;">&nbsp;</td>
                                <td style="width: 200px;">
                                   Lavado
                                </td>
                                </tr>
                            
                        </table>


                </td>
                 <td valign="top" align="right"  >
                                    <div id="leftfix0" runat="server">
                                    </div>
                                </td>
                <td>
                    
                         
                                    <asp:DataList ID="DataList1" runat="server" CellPadding="0" RepeatDirection="Vertical"
                                        RepeatLayout="Table" Font-Size="12px" Font-Names="Calibri"  
                                        CellSpacing="1">
                                        <ItemTemplate>
                                            <div style="border: solid 1px gray;">
                                                <asp:Label ID="Label1" runat="server" Width="80px" Text='<%# Eval("color_tecnico") %>' />
                                                <asp:Label ID="lblcveAsesor" runat="server" Text='<%# Eval("nombre_empleado") %>' />
                                            </div>
                                        </ItemTemplate>
                                        <FooterStyle />
                                        <AlternatingItemStyle />
                                        <ItemStyle />
                                        <SelectedItemStyle />
                                        <HeaderStyle />
                                    </asp:DataList>
                                
                    
                </td>
                <td style="  background-color: #001E3D;" align="center">
                    
                    <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo" Style="display: none;" />
                    <asp:Button ID="cmdup" runat="server" Text="Nuevo" Style="display: none;" />
                    <asp:Button ID="cmddwn" runat="server" Text="Nuevo" Style="display: none;" />
                    <asp:Label ID="lblNuevo2" runat="server" Style="display: none;" />
                </td>
            </tr>
        </table>
        </div>
    </div>
    <div id="topfix1" style="top: 0px; height: 760px; width: 1225px;">
    </div>
     
          <div id="umodal-modal-content">
			<div id="umodal-modal-title">Informacion</div>
			<div class="close"><a href="#" class="simplemodal-close">x</a></div>
			<div id="umodal-modal-data">
				
                <asp:label runat="server" ID="lblmessage" ></asp:label>
				 <p><br /></p>
                    <div id="umodal-modal-footer">

                    <p><button class="simplemodal-close">Cerrar</button> <span>(ESC o click)</span></p>
			        <input type='button' name='umodal'  class='umodal demo' style="display:none;"/>
            
                     </div>
            </div>
            
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

       

        my_cita = dd.elements['divInterfaz'];
       
        my_cita.moveTo(floatingMenu.nextX + 94, floatingMenu.nextY + document.documentElement.clientHeight - document.getElementById('divInterfaz').offsetHeight);
        my_cita = dd.elements['leftfix'];
         

        my_cita.moveTo(floatingMenu.nextX, 93);
        

        my_cita = dd.elements['imgLogo1'];
    
        my_cita.moveTo(floatingMenu.nextX , floatingMenu.nextY);
        my_cita = dd.elements['imgLogo0'];
       
        my_cita.moveTo(floatingMenu.nextX + 1000, 5);

        my_cita = dd.elements['divFind'];
        
        my_cita.moveTo(floatingMenu.nextX + document.documentElement.clientWidth - document.getElementById('divFind').offsetWidth - 550, 7);
       
        my_cita = dd.elements['dhtml'];
      
        my_cita.moveTo(floatingMenu.nextX + 300, 0 + 'px');

        my_cita = dd.elements['divifra'];
        
        my_cita.moveTo(floatingMenu.nextX, floatingMenu.nextY + 'px');


        

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


        floatingMenu.computeShifts();

        var cornerX = floatingMenu.calculateCornerX();

        var stepX = (cornerX - floatingMenu.nextX) * .5;
        if (Math.abs(stepX) < .5) {
            stepX = cornerX - floatingMenu.nextX;
        }

        var cornerY = floatingMenu.calculateCornerY();

        var stepY = (cornerY - floatingMenu.nextY) * .5;
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

    ///////////////////////////////////////////////////////////////////////
    //       function addEvent(obj, type, fn) {
    //           if (obj.addEventListener) {
    //               obj.addEventListener(type, fn, false);
    //           }
    //           else if (obj.attachEvent) {
    //               obj["e" + type + fn] = fn;
    //               obj[type + fn] = function() { obj["e" + type + fn](window.event); }
    //               obj.attachEvent("on" + type, obj[type + fn]);
    //           }
    //           else {
    //               obj["on" + type] = obj["e" + type + fn];
    //           }
    //       }

    //       function addEventByName(ObjName, event, func) {
    //           MyEle = document.getElementsByName(ObjName);
    //           addEvent(MyEle[0], event, func);
    //       }

    //       addEventByName("txtBox", 'blur', function() {
    //           alert('hello');
    //       });

    //--></script>
</html>
