<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pull_system2.aspx.vb" Inherits="TablerosV2.pull_system2" %>
 

 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
    <title>Página sin título</title>
    <meta http-equiv="refresh" content="60" />   
      <link rel="stylesheet" href="css/jquery-ui.css" />

  <script  type="text/javascript"src="js/jquery-1.9.1.js"></script>

  <script  type="text/javascript" src="js/jquery-ui.js"></script> 
  <style type="text/css">
      
 
      .OpcH
{
        height:28px;
        width:46px;
    -moz-opacity: 0.5;
     -webkit-opacity: 0.5; 
     -ms-filter:"progid:DXImageTransform.Microsoft.Alpha(Opacity=50)"; 
     filter: alpha(opacity=50); 
     opacity: 0.5;
}
    .OpcV
{
        width:28px;
        height:46px;
    -moz-opacity: 0.5;
     -webkit-opacity: 0.5; 
     -ms-filter:"progid:DXImageTransform.Microsoft.Alpha(Opacity=50)"; 
     filter: alpha(opacity=50); 
     opacity: 0.5;
}
 
    
     .lblTotA
{  
   
    font-family:Calibri;
    font-size:13px;
    color:Blue;
    
    
    }
    
    
     
      
    
     
    
    
                       
            
  .cssPull{
  display:block;
  border:none;
  background-color:
  transparent;
  position:absolute;
  top:30px;
  left:1100px;
  width:300px;
  height:100px;
  }
  
   /*========================*/
 /* 3. Arrow tooltip (final)
  ========================
  colours:
  #fcc | rgba(255,205,205,0.7)
  #fee | rgba(225,238,238,0.7)
  #333 | rgba(51,51,51,0.7)
  #c99 | rgba(204,153,153,0.7)
  */

  /* tooltip basic link styles */
   .tool{
   position:absolute; 
 
border:2px solid rgba(204,153,153,0.9);
width:15em; 
margin:1em; 
padding:4px; 
 background:#fcffff;
   }
  .tooltip:link,
  .tooltip:visited {
    position:absolute;
    text-decoration:underline;
  }
  .tooltip:hover {
    text-decoration:none; /* remove underline on tooltip text */
   
  }


  /* tooltip body text */
  .tooltip:hover:before {
    display:block;
    background:#fcffff;
    /*
    background:-webkit-gradient(linear, 0 0, 0 100%, from(rgba(255,205,205,0.9)), to(rgba(228,230,230,0.9)));
    background:-moz-linear-gradient(rgba(255,205,205,0.9), rgba(228,230,230,0.9));
    background:-o-linear-gradient(rgba(255,205,205,0.9), rgba(228,230,230,0.9));
    background:linear-gradient(rgba(255,205,205,0.9), rgba(228,230,230,0.9));
    */
    content:attr(data-tooltip); /* this link attribute contains tooltip text */
    position:fixed;
    z-index: 999999;
    float:top right;
     font-size:0.99em;
    color:rgba(51,51,51,0.9);
     left:1060px;
     top:150px;
    /* 
    bottom:(border-width*-1)+px;ensure link text is visible under tooltip 
    right:-200px;  align both tooltip and link right edges */
    
    width:15em;  /* a reasonable width to wrap tooltip text */
    text-align:center;
    padding:4px;
    border:2px solid rgba(204,153,153,0.9);
    
    /*webkit-border-radius:6px;
       -moz-border-radius:6px;
        -ms-border-radius:6px;
         -o-border-radius:6px;
            border-radius:6px;
    -webkit-box-shadow:-2px -2px 2px rgba(20,20,20,0.4);
       -moz-box-shadow:-2px -2px 2px rgba(20,20,20,0.4);
        -ms-box-shadow:-2px -2px 2px rgba(20,20,20,0.4);
         -o-box-shadow:-2px -2px 2px rgba(20,20,20,0.4);
            box-shadow:-2px -2px 2px rgba(20,20,20,0.4);*/
  }

  /* styles shared by both triangles */
  .tooltip:hover span:before,
  .tooltip:hover span:after {
    content:"";
    position:absolute;
    border-style:solid;
   
  }
  /* outer triangle: for border */
  .tooltip:hover span:before {
  
    bottom:5px; /* value = tooltip:hover:before (border-width*2)+1 */
    right:40px; /* controls horizontal position */
    border-width:16px 16px 0; /* top, right-left, bottom */
    border-color:rgba(204,153,153,0.9) transparent; /* top/bottom, right-left (lazy becasue bottom is 0) */
  }

  /* inner triangle: for fill */
  .tooltip:hover span:after {
  
    bottom:8px; /* value = tooltip:before (border-width*2) */
    right:42px; /* above 'right' value + 2 */
    border-width:14px 14px 0; /* 2 less than above */
    border-color:rgba(225,238,238,0.95) transparent; /* tweak opacity by eye/eyedropper to obscure outer triangle colour */
  }
  
.resaltar{background-color:#FF0;}
  </style>   

    <script  type="text/javascript" language="javascript">

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
                    if (strFound) { alert(TRange.id); var ob = document.getElementById(TRange.parentElement().id); TRange.style.width = '200px'; ob.style.fontWeight = 'bold'; TRange.select(); }
                }
                if (TRange == null || strFound == 0) {
                    TRange = self.document.body.createTextRange()
                    // TRange = self.document.getElementById('gvDMS').createTextRange()
                    strFound = TRange.findText(str)
                    if (strFound) { alert(TRange.id); var ob = document.getElementById(TRange.parentElement().id); TRange.style.width = '200px'; ob.style.fontWeight = 'bold'; TRange.select(); }
                }
            }
            else if (navigator.appName == "Opera") {
                alert("Opera no soporta busqueda")
                return;
            }
            if (!strFound) alert("'" + str + "' no fue encontrada")
            return;
        }
        function Location(sDiv) {
            document.getElementById("dhtml").value = sDiv;
            __doPostBack('__Page', sDiv);
        }
        
	function buscaChp(sValue){
	    document.getElementById("dhtml").value = sValue;
	    __doPostBack('__Page', "dhtml");
		}

		function buscaChpOrd() {



		    var i = 0;
		    var selObj = document.getElementById('selOptChipsHdd');
		    for (i = 0; i < selObj.options.length; i++) {
		        if (document.getElementById("inOptChips").value == selObj.options[i].text) {
		            document.getElementById("dhtml").value = selObj.options[i].value;
		            busca(document.getElementById("inOptChips").value);
		            return true;
		        }
		    }
		    //  alert(document.getElementById("inOptChips").value);
		    var h = window.screen.availHeight;
		    var w = window.screen.availWidth;
		     xwin = window.open('pull_systemDetalle2.aspx?sOrdenDetalle=' + document.getElementById("inOptChips").value, '', 'width=' + h + ';height=' + w + ';edge=sunken,status=yes,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=yes,modal=yes,dependable=yes;');


		   // document.getElementById("dhtml").value = document.getElementById("inOptChips").value + "_buscar";
		   //// document.getElementById('divBack').style.display = "block";
		 

		   // __doPostBack('__Page', '');
		   //// alert('No se encontro la orden ' + document.getElementById("inOptChips").value);


		}



		function showTooltip(control) {
		    var ttext = control.getAttribute('data-tooltip');
		    var tt = document.createElement('SPAN');
		    var tnode = document.createTextNode(ttext);
		    tt.appendChild(tnode);
		    control.parentNode.insertBefore(tt, control.nextSibling);
		    //tnode.className = "tool";
		    tt.style.left = control.style.left;
		    tt.style.top = control.style.top;
		    tt.style.zIndex = control.style.zIndex + 200;
		    tt.className = "tool";
		    control.title = "";
		}
		function hideTooltip(control) {
		    if (control.nextSibling.id == '') {
		        //var ttext = control.nextSibling.childNodes[0].nodeValue;
		        control.parentNode.removeChild(control.nextSibling);
		        //control.title = ttext;
		    }
		}
		//$(document).ready(function () {
		//    $('#inOptChips').keyup(function () {
		//        buscar = $(this).val();
		//        $('div').removeClass('resaltar');
		//        if (jQuery.trim(buscar) != '') {
		//            $("div:contains('" + buscar + "')").addClass('resaltar');
		//        }
		         
		//    });
		//});

		$(function () {
		    $(document).tooltip({
		        track: true
		    });
		});
	
		$(function () {
		    $("a").click(function (e) {
		        e.preventDefault();

		         
		        var h = window.screen.availHeight;
		        var w = window.screen.availWidth;

		        if (this.text.indexOf('Total') >= 0) {
		             xwin = window.open('pull_systemDetalle2.aspx?PullLinks=' + this.id, '', 'width=' + h + ';height=' + w + ';edge=sunken,status=yes,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=yes,modal=yes,dependable=yes;');

		        }
		        else {
		           
		            xwin = window.open('pull_systemDetalle2.aspx?Asesor=' + this.text, '', 'width=' + h + ';height=' + w + ';edge=sunken,status=yes,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=yes,modal=yes,dependable=yes;');

		        }




		    });
		});
		 

	</script>
    
    
</head>
<body style="background-image: url(img/toyota_cn_servicio_8B.PNG);">

    <form id="form1" runat="server" >
    
     <asp:ScriptManager runat="server" AsyncPostBackTimeout="0" ID="scrmgr1">
    </asp:ScriptManager>
<%--     <div id="divBack" style="width:100%;height:100%;  background-color:rgba(51,51,51,0.6); display:none;"></div>--%>
          
    <div id="floatdiv" runat="server"   style="position: absolute;
        width: 1225px; height:0px; left: 0px; top: 0px; z-index: 3002;" >
        
          <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="img/logout.png"
                    Width="40px" OnClick="ImageButton1_Click"  style="position: relative; top: 85px; left: 1280px; z-index:-1;"  />
        <input type="text" value=""  runat="server" id="dhtml" style="z-index: 1000; left: 550px; position: absolute;
            top: 5px; background-color: transparent; border: none; font-size: 12px; font-family: Arial;
            color: transparent; font-weight: bold;display:none;" />
       <input type="text" value="Fecha: " style="z-index: 1000; left: 600px; position: absolute;
            top: 10px; background-color: transparent; border: none; font-size: 12px; font-family: Arial;
            color: transparent; font-weight: bold;display:none;" />
        <asp:Label ID="lblCalendar" runat="server" Style="z-index: 1000; left: 675px; position: absolute;
            top: 10px; background-color: transparent; border: none; font-size: 12px; font-family: Arial;
            color: transparent; font-weight: bold;display:none;" Text=""></asp:Label>
        <input type="text" value="Usuario: " style="z-index: 1000; left: 600px; position: absolute;
            top: 25px; background-color: transparent; border: none; font-size: 12px; font-family: Arial;
            color: transparent; font-weight: bold;display:none;" />
        <asp:Label ID="lblUsr" runat="server" Style="z-index: 1000; left: 675px; position: absolute;
            top: 25px; background-color: transparent; border: none; font-size: 12px; font-family: Arial;
            color: transparent; font-weight: bold;display:none;" Text=""></asp:Label>
        <asp:TextBox ID="txtUpdateBoard" runat="server" BackColor="Transparent" BorderColor="Transparent"
            BorderStyle="None" ForeColor="Black" Height="1px" Style="z-index: 107;
            left: 1px; position: absolute; top: 1px;display:none;"   Width="1px"  AutoPostBack="True"></asp:TextBox>
            
    </div>
         <div id="dchp" style="filter:alpha(opacity=90);background-position: left top; z-index:4999;  
        Left: 0px; width: 214px; position: absolute; Top: 0px; height: 90px; border-left-color: blue;
        border-bottom-color: blue; border-top-color: blue; border-right-color: blue;
        font-family: 'Calibri'; background-color: white; background-image: url(img/chipTextPull.PNG); "
        runat="server" visible="false" onclick="javascript:this.style.display='none';" >
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

    
      <div style=" position: absolute;left:1114px; top: 863px; width:180px; border:1px solid black; font-weight: bold; font-size:12px; font-family:Arial;">
     <table>
        <tr><td>
            <table style="width:100%;"><tr><td>
                Publicas

                       </td> <td style=" background-color:red; width:50%; "></td></tr></table>
            
            </td>

           
        </tr> 
         <tr><td>
      Asesores

      <asp:DataList ID="DataList1" runat="server"  CellPadding="0" RepeatDirection="Vertical"
                                            RepeatLayout="Table" Font-Size="12px" Font-Names="Calibri" 
                                            HorizontalAlign="Right" CellSpacing="1" >
                                            <ItemTemplate>
                                                <div style="border: solid 1px gray;" > 
                                                 <asp:Label ID="Label1" runat="server" Width="60px" Text='<%# Eval("color") %>' />
                                                 <%--   <asp:Label ID="lblcveAsesor" runat="server" Text='<%# Eval("nombre") %>' />--%>
                                                     <asp:LinkButton  ID="lblcveAsesor"  runat="server" visible="true"  ><%# Eval("nombre") %> </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <FooterStyle    />
                                            <AlternatingItemStyle   />
                                            <ItemStyle   />
                                            <SelectedItemStyle   />
                                            <HeaderStyle    />
                                        </asp:DataList>
    
     </td>
     
     </tr>
     <tr>
     <td>
     
       <asp:DataList ID="DataList2" runat="server"  CellPadding="0" RepeatDirection="Vertical"
                                            RepeatLayout="Table" Font-Size="12px" Font-Names="Calibri" 
                                            HorizontalAlign="Right" CellSpacing="1" style="display:none;"  >
                                            <ItemTemplate>
                                                <div style="border: solid 1px gray;" > 
                                                 <asp:Label ID="Label1" runat="server" Width="60px" Text='<%# Eval("color") %>' />
<%--                                                    <asp:Label ID="lblcveEtapa" runat="server" Text='<%# Eval("nombre") %>' />--%>
                                                       <asp:LinkButton  ID="lblcveEtapa"  runat="server" visible="true"       CssClass="lblTotF" >'<%# Eval("nombre") %>' </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <FooterStyle    />
                                            <AlternatingItemStyle   />
                                            <ItemStyle   />
                                            <SelectedItemStyle   />
                                            <HeaderStyle    />
                                        </asp:DataList>
     </td>
     </tr>
     </table>
   
    
    </div>
        <div style=" position: absolute;left:1134px; top: 150px; ">
    <table style="   width:100%;" cellpadding="0" cellspacing="0"  > 
        
            <tr><td><asp:LinkButton  ID="lblTotF"  runat="server" visible="false"       CssClass="lblTotA"  tooltip="Espera de Servicio Total"></asp:LinkButton></td></tr> 
               <tr><td><asp:LinkButton ID="lblTotB" runat="server" visible="false"   CssClass="lblTotA"  tooltip="En Bahia Total"></asp:LinkButton></td></tr>
                <tr><td><asp:LinkButton ID="lblTotH" runat="server" visible="false"    CssClass="lblTotA"  tooltip="Recepcion Total"></asp:LinkButton></td></tr>
                 <tr><td><asp:LinkButton ID="lblTotR" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Recepcion Asesor Total"></asp:LinkButton></td></tr>
                  <tr><td><asp:LinkButton ID="lblTotL" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Lavadon Total"></asp:LinkButton></td></tr>
                   <tr><td><asp:LinkButton ID="lblTotT" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Terminado Total"></asp:LinkButton></td></tr>
                    <tr><td><asp:LinkButton ID="lblTotA" runat="server" visible="false"    CssClass="lblTotA"  tooltip="Detenido Autorizacion Total"></asp:LinkButton></td></tr>
                     <tr><td><asp:LinkButton ID="lblTotQ" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Detenido CarryOver Total"></asp:LinkButton></td></tr>
                      <tr><td><asp:LinkButton ID="lblTotG" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Detenido Prueba Ruta Total"></asp:LinkButton></td></tr>
                       <tr><td><asp:LinkButton ID="lblTotX" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Detenido Refacciones Total"></asp:LinkButton></td></tr>
                        <tr><td><asp:LinkButton ID="lblTotN" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Detenido TOT Total"></asp:LinkButton></td></tr>
                        <tr><td><asp:LinkButton ID="lblTotI" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Detenido Calidad Total"></asp:LinkButton></td></tr>
                         <tr><td><asp:LinkButton ID="lblTotW" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Lavado Total"></asp:LinkButton></td></tr>
                       
                        <tr><td><asp:LinkButton ID="lblTotU" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Pulido Total"></asp:LinkButton></td></tr>
                        <tr><td><asp:LinkButton ID="lblTotJ" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Varillaje Total"></asp:LinkButton></td></tr>
                          
                          <tr><td><asp:LinkButton ID="lblTotK" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Detenido CarryOver Total"></asp:LinkButton></td></tr>
 
                         <tr><td><asp:LinkButton ID="lblTotQ1" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Detenido Autorizacion Total"></asp:LinkButton></td></tr>
                         <tr><td><asp:LinkButton ID="lblTotX1" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Detenido Refacciones Total"></asp:LinkButton></td></tr>
                          <tr><td><asp:LinkButton ID="lblTotY" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Detenido por Reprogramacion Total"></asp:LinkButton></td></tr>
                         <tr><td><asp:LinkButton ID="lblTotC" runat="server" visible="false"  CssClass="lblTotA"  tooltip="Detenido por Calidad Total"></asp:LinkButton></td></tr>

                              <tr><td><asp:LinkButton ID="lblTotZ" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Terminado por entregar Total"></asp:LinkButton></td></tr>
         <tr><td><asp:LinkButton ID="lblTotT1" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Terminado por entregar de dias anteriores Total"></asp:LinkButton></td></tr>
         <tr><td><asp:LinkButton ID="lblTotN1" runat="server" visible="false"   CssClass="lblTotA"  tooltip="No cotizados Total"></asp:LinkButton></td></tr>
         <tr><td><asp:LinkButton ID="lblTotN2" runat="server" visible="false"   CssClass="lblTotA"  tooltip="No Autorizados Total"></asp:LinkButton></td></tr>
         <tr><td><asp:LinkButton ID="lblTotN3" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Perdida Total Total"></asp:LinkButton></td></tr>
         <tr><td><asp:LinkButton ID="lblTotV" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Valuacion Total"></asp:LinkButton></td></tr>
         <tr><td><asp:LinkButton ID="lblTotO" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Espera de Partes Total"></asp:LinkButton></td></tr>
         <tr><td><asp:LinkButton ID="lblTotS" runat="server" visible="false"   CssClass="lblTotA"  tooltip="En Transito Total"></asp:LinkButton></td></tr>
         <tr><td><asp:LinkButton ID="lblTotD" runat="server" visible="false"   CssClass="lblTotA"  tooltip="Autorizados por programar Total"></asp:LinkButton></td></tr>
             </table>                       
    </div>
    </form>

   
    
</body>
</html>
