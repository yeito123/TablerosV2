<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pull_systemConfig.aspx.vb" Inherits="TablerosV2.pull_systemConfig" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
    <title>Página sin título</title>
       
 <script src="JS/wz_dragdrop3.js" type="text/javascript"></script>

    <script src="JS/wz_jsgraphics3.js" type="text/javascript"></script>
    <script  type="text/javascript" language="javascript">

        function Location(sDiv) {
            document.getElementById("dhtml").value = sDiv;
            __doPostBack('__Page', sDiv);
        }
        function LocationDrop(sDiv) {
            document.getElementById("dhtml").value = sDiv;
            __doPostBack('__Page', sDiv);
        }
        function buscaChp(sValue) {
            document.getElementById("dhtml").value = sValue;
            __doPostBack('__Page', "dhtml");
        }

        function buscaChpOrd() {



            var i = 0;
            var selObj = document.getElementById('selOptChipsHdd');
            for (i = 0; i < selObj.options.length; i++) {
                if (document.getElementById("inOptChips").value == selObj.options[i].text) {
                    document.getElementById("dhtml").value = selObj.options[i].value;
                    __doPostBack('__Page', "dhtml");
                    return true;
                }
            }



        }






	</script>
    
    
    
</head>
<body style="background-image: url(img/toyota_cn_servicio_8B.PNG);">

    <form id="form1" runat="server" >
      <asp:ScriptManager runat="server" AsyncPostBackTimeout="0" ID="scrmgr1">
    </asp:ScriptManager>
    
     
          
    <div id="floatdiv" runat="server"  style="position: absolute;
        width: 1225px; height: 90px; left: 0px; top: 0px; z-index: 3002;" >
        
          <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="img/logout.png"
                    Width="40px" OnClick="ImageButton1_Click"  style="position: relative; top: 0px; left: 1200px;"  />
        <input type="text" value=""  runat="server" id="dhtml" style="z-index: 1000; left: 550px; position: absolute;
            top: 5px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: Transparent; font-weight: bold;" />
       <input type="text" value="Fecha: " style="z-index: 1000; left: 600px; position: absolute;
            top: 10px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: Transparent; font-weight: bold;" />
        <asp:Label ID="lblCalendar" runat="server" Style="z-index: 1000; left: 675px; position: absolute;
            top: 10px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: Transparent; font-weight: bold;" Text=""></asp:Label>
        <input type="text" value="Usuario: " style="z-index: 1000; left: 600px; position: absolute;
            top: 25px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: Transparent; font-weight: bold;" />
        <asp:Label ID="lblUsr" runat="server" Style="z-index: 1000; left: 675px; position: absolute;
            top: 25px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: Transparent; font-weight: bold;" Text=""></asp:Label>
        <asp:TextBox ID="txtUpdateBoard" runat="server" BackColor="Transparent" BorderColor="Transparent"
            BorderStyle="None" ForeColor="Black" Height="1px" Style="z-index: 107;
            left: 1px; position: absolute; top: 1px"   Width="1px"  AutoPostBack="True"></asp:TextBox>
            
    </div>
         <div id="dchp" style="filter:alpha(opacity=90);background-position: left top; z-index:4999;  
        Left: 0px; width: 214px; position: absolute; Top: 0px; height: 90px; border-left-color: blue;
        border-bottom-color: blue; border-top-color: blue; border-right-color: blue;
        font-family: 'Calibri'; background-color: white; background-image: url(img/chipTextPull.PNG); "
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
    <div id="imgTrash" style="z-index: 3004; left: 0px;  position: absolute; top: 450px;height:30px;">
     <img id="imgTrash1" src="img/tRASH.png" alt="" style="filter:alpha(opacity=75); height:30px; width:1228px;" />
    </div>
     <div id="HorizontalChip" style="z-index:3006;position:absolute;top:500px;left:200px; height:28px;width:46px;" > <img id="HorizontalChip1" alt="Horizontal" src="img/v_blue_h_l.gif" /></div>
     <div id="VerticalChip" style="z-index:3006;position:absolute;top:500px;left:270px; height:46px;width:28px;"> <img id="VerticalChip1" alt="Vertical" src="img/v_blue_v_l.gif"  /></div>
    
      
        <div style="z-index: 3003; left: 0px; width: 1228px; position: absolute; top: 392px;
        height: 200px; background-image: url(img/controlCitas_Silver.png);" id="divInterfaz"
        runat="server" visible="true">
           <table cellspacing="0" cellpadding="0" style="border-width: 2px; border-color: #001340;
            width: 100%; background-color: #E5E5E5; font-size: 13px; font-weight: bold; border-top-style: solid;
            border-bottom-style: solid;">
         
            <tr>
                <td colspan="4">
                    <div class="gvContainer">
                   
                        <table   cellpadding="1" cellspacing="10" style=" position:relative;left:60px; width:80%; ">
                            <tr>
                                <td>Fondo: 
                                <input id="txtArchivo" type="file" ForeColor="#191970"   runat="server" name="txtArchivo" 
                                        size="15" runat="server" />
                                <asp:Button ID="cmdCargar" runat="server"  Text="Cargar" /> 
                                </td>
                                <td>
                                Tipo:
                                      <asp:DropDownList ID="cboChips" runat="server" AutoPostBack="False" Visible="true">
                        <asp:ListItem Value="h"  >Arribo(h)</asp:ListItem>
                         <asp:ListItem Value="r"  >Recepcion Asesor(r)</asp:ListItem>                       
                        <asp:ListItem Value="f" >Espera de Servicio(f)</asp:ListItem>
                         <asp:ListItem Value="b" >En bahia(b)</asp:ListItem>      
                         <asp:ListItem Value="l">Espera de Lavado(l)</asp:ListItem>
                         <asp:ListItem Value="w"  >En lavado(w)</asp:ListItem>
                        <asp:ListItem Value="z"  >Terminado por Entregar(z)</asp:ListItem>
                        <asp:ListItem Value="t" >Terminado por entregar de dias anteriores(z)</asp:ListItem>
                         <asp:ListItem Value="g"  >Detenido Prueba de Ruta(g)</asp:ListItem>
                       <asp:ListItem Value="q"  >Detenido CarryOver(q)</asp:ListItem>
                         <asp:ListItem Value="x">Detenido Refacciones(x)</asp:ListItem>
                                          <asp:ListItem Value="i">Detenido Calidad(i)</asp:ListItem>
                          <asp:ListItem Value="n">Detenido TOT(n)</asp:ListItem>
                          <asp:ListItem Value="a">Detenido Autorizacion(a)</asp:ListItem>
                        </asp:DropDownList>
                        
                   
                                </td>
                                <td>
                                Campo a Mostrar:
                                      <asp:DropDownList ID="cboCampos" runat="server" AutoPostBack="False" Visible="true">
                      
                        </asp:DropDownList>
                        <br />
                        o expresion SQL:
                         <asp:TextBox ID="txtCampoMostrar" runat="server" TextMode="MultiLine"></asp:TextBox>
                   
                                </td>
                                <td>
                                  Orientacion:   
                    <asp:RadioButtonList ID="optOrientacion" runat ="server" RepeatDirection="Horizontal" Visible="false">
                    <asp:ListItem Value="img/v_red_h_l.gif__img/v_blue_h_l.gif" ></asp:ListItem>
                    <asp:ListItem Value="img/v_red_v_l.gif__img/v_blue_v_l.gif" ></asp:ListItem>
                    
                    </asp:RadioButtonList>
                                </td>
                                 
                            </tr>
                            <tr>
                                <td >
                                    &nbsp;
                                </td>
                                <td > Color Chip con Cita:
                                      <asp:DropDownList ID="cboColorChip" runat="server" AutoPostBack="False" Visible="true">
                        <asp:ListItem Value="Blue" style="background-color: Blue;" >&nbsp;</asp:ListItem>
                         <asp:ListItem Value="Red" style="background-color: Red;" >&nbsp;</asp:ListItem>                       
                        
                        </asp:DropDownList></td>
                                    <td  >
                                        &nbsp;
                                    </td>
                                     
                            </tr>
                            <tr>
                                <td >
                                    &nbsp;</td>
                                <td  >&nbsp;</td>
                                    <td >
                                       &nbsp;</td>
                                    
                            </tr>
                            <tr>
                                <td  >
                                    &nbsp;</td>
                                <td  >&nbsp;</td>
                                    <td >
                                        &nbsp;</td>
                                     </tr>
                        </table>
                    </div>
                </td>
            </tr>
               <tr>
                <td>
                  <img id="img1" src="img/tRASH.png" alt="" style="position:absolute;top:130px;LEFT:0px;filter:alpha(opacity=90); height:30px; width:1228px;" />
        
                </td>
                 
            </tr>
            <tr>
                <td colspan="3" align="right" valign="bottom">
                    <asp:ImageButton ID="imgBtnMve_DMS" runat="server" ImageUrl="~/img/MoverCita.PNG"
                        Visible="false" />
                    <asp:ImageButton ID="imgBtnDel_DMS" runat="server" ImageUrl="~/img/BorrarCita.PNG"
                        Visible="false" />
                    <asp:ImageButton ID="imgBtnCut_CHP" runat="server" ImageUrl="~/img/Cortar.PNG" Visible="false" />
                    <asp:ImageButton ID="imgBtnPrs_CHP" runat="server" ImageUrl="~/img/Pegar.PNG" Visible="false" />
                    <asp:ImageButton ID="imgBtnUpd_DMS" runat="server" ImageUrl="~/img/GrabarCita.PNG"
                        Visible="false" />
                    <asp:ImageButton ID="imgBtnRpt_DMS" runat="server" ImageUrl="~/img/Prepicking.PNG"
                        Visible="false" />
                    <asp:ImageButton ID="imgBtnTme_CHP" runat="server" ImageUrl="~/img/AumentaTiempo.PNG"
                        Visible="false" />
                    <asp:ImageButton ID="btnStop" runat="server" ImageUrl="~/img/tecParar.PNG" Visible="false" />
                 
                    <asp:ImageButton ID="btnInit" runat="server" ImageUrl="~/img/tecReiniciar.PNG" Visible="false" />
                    <asp:ImageButton ID="btnIni" runat="server" ImageUrl="~/img/tecInicio.PNG" Visible="false" />
                    <asp:ImageButton ID="btnFin" runat="server" ImageUrl="~/img/tecFin.PNG" Visible="false" />
                    <asp:ImageButton ID="imgBtnOut_DMS" runat="server" ImageUrl="~/img/Salir.PNG" Visible="False" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>

 <div id="topfix1" style="top: 0px; height: 760px; width: 1225px;">

    <%--    <script type="text/javascript">
    <!--
            jg_doc.paint(); 
    //-->
        </script>
 --%>


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
        var my_trash;
        var my_HorizontalChip;
        var my_VerticalChip;

        //my_item = dd.elements['topfix0'];
        //my_item.moveTo(my_item.defx, floatingMenu.nextY + 400);

        my_cita = dd.elements['divInterfaz'];
        //my_cita = document.getElementById("divInterfaz");
        my_cita.moveTo(1, floatingMenu.nextY + 445);
        //my_cita.z = 3004;

        my_trash = dd.elements['imgTrash'];
        my_trash.moveTo(1, floatingMenu.nextY + 575);
        my_trash.setZ(my_cita.z + 1, 0, 0);
        my_HorizontalChip = dd.elements['HorizontalChip'];
        my_HorizontalChip.setZ(my_cita.z + 1, 0, 0);
        my_HorizontalChip.moveTo(1050, floatingMenu.nextY + 460);
        my_VerticalChip = dd.elements['VerticalChip'];
        my_VerticalChip.setZ(my_cita.z + 1, 0, 0);
        my_VerticalChip.moveTo(1120, floatingMenu.nextY + 455);

        //my_trash.z = 3005;

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

        var stepX = (cornerX - floatingMenu.nextX) * .07;
        if (Math.abs(stepX) < .5) {
            stepX = cornerX - floatingMenu.nextX;
        }

        var cornerY = floatingMenu.calculateCornerY();

        var stepY = (cornerY - floatingMenu.nextY) * .07;
        if (Math.abs(stepY) < .5) {
            stepY = cornerY - floatingMenu.nextY;
        }

        if (Math.abs(stepX) > 0 ||
            Math.abs(stepY) > 0) {
            floatingMenu.nextX += stepX;
            floatingMenu.nextY += stepY;
            floatingMenu.move();
        }

        setTimeout('floatingMenu.doFloat()', 3);
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
