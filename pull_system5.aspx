<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pull_system5.aspx.vb" Inherits="TablerosV2.pull_system5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html  xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
    <title>Página sin título</title>
    <meta http-equiv="refresh" content="3000000" /> 
     <link rel="stylesheet" href="css/jquery-ui.css" />    
     <script  type="text/javascript" src="js/jquery-1.9.1.js"></script>
     <script type="text/javascript" src="js/jquery-ui.js"></script>   
<style type="text/css">
.textdiv{
 font-size:12px;
  font-family:arial;
   background-color:#FFF;
   text-align:left; 
   background-position:left top;
   width:33px;
    height:29px;
    
} 
.textdiv2{
 font-size:16px;
  font-family:arial;
   background-color:#FFF;
   text-align:left;  
   color:white;
   font-weight:bold;
     background:#285513;
/* for IE */
  filter:alpha(opacity=80);
  /* CSS3 standard */
  opacity:0.80;
   box-shadow: 5px 5px 5px #333;
   width:33px;
   text-align:center;
} 
.textResumen{
display:block;
border:none;
background-color:transparent;
position:absolute;
top:110px;
left:990px;
width:300px;
height:100px;
}
    .datagrid table {
        border-collapse: collapse;
        text-align: left;
        width: 100%;
    }

    .divdatagrid {
        position: absolute;
        top: 400px;
        left: 20px;
        width: 325px;
        height:400px;
        font: normal 20px/150% Arial, Helvetica, sans-serif;
        background: #fff;
        overflow: auto;
         scrollbar-face-color: #36752D;
	        scrollbar-shadow-color: #36752D;
	        scrollbar-highlight-color: #36752D;
	        scrollbar-3dlight-color: #36752D;
	        scrollbar-darkshadow-color: #F6F4FD;
	        scrollbar-track-color: #FDFDFE;
	        scrollbar-arrow-color: #36752D;
        border: 0px solid #36752D;
        -webkit-border-radius: 10px;
        -moz-border-radius: 10px;
        border-radius: 10px;       

    }
    .datagrid {
        
        width: 290px;
         
        font: normal 20px/150% Arial, Helvetica, sans-serif;
        background: #fff;
        overflow: no-display;
        border: 1px solid #36752D;
        -webkit-border-radius: 10px;
        -moz-border-radius: 10px;
        border-radius: 10px;       

    }

        .datagrid table td, .datagrid table th {
            padding: 1px 1px;
        }

        .datagrid table thead th {
            background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #36752D), color-stop(1, #275420) );
            background: -moz-linear-gradient( center top, #36752D 5%, #275420 100% );
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#36752D', endColorstr='#275420');
            background-color: #36752D;
            color: #FFFFFF;
            font-size: 10px;
            font-weight: bold;
            border-left: 4px solid #36752D;
            text-align: center;
        }
        .datagridHD {
            background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #36752D), color-stop(1, #275420) );
            background: -moz-linear-gradient( center top, #36752D 5%, #275420 100% );
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#36752D', endColorstr='#275420');
            background-color: #36752D;
            color: #FFFFFF;
            font-size: 10px;
            font-weight: bold;
            border-left: 4px solid #36752D;
            text-align: center; 
        }

        .datagridHD2 {
            background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #36752D), color-stop(1, #275420) );
            background: -moz-linear-gradient( center top, #36752D 5%, #275420 100% );
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#36752D', endColorstr='#275420');
            background-color: gainsboro;
            color: #FFFFFF;
            font-size: 10px;
            font-weight: bold;
            border-left: 4px solid #36752D;
            text-align: center; 
        }

            .datagrid table thead th:first-child {
                border: none;
            }

        .datagrid table tbody td {
            color: #275420;
            border-left: 4px solid #C6FFC2;
            font-size: 18px;
            font-weight: bold;
        }
        .datagridIT{
            color: #275420;
            border-left: 4px solid #C6FFC2;
            font-weight: bold;
            font-size: 10px; 
        }

        .datagrid table tbody .alt td {
            background: #DFFFDE;
            color: #275420;
        }

        .datagrid table tbody td:first-child {
            border-left: none;
        }

        .datagrid table tbody tr:last-child td {
            border-bottom: none;
        }


        .i1    {
    display:inline-table;
    background:#285513;
    font-size:14px;
    
    width:170px;
    padding:20px;
    color:#fff; 
    z-index: 2199;
    bottom: 10px;
    left: 50px  ;
    border: 2px solid #333;
/* for IE */
  filter:alpha(opacity=83);
  /* CSS3 standard */
  opacity:0.83;
   box-shadow: 5px 5px 5px #333;

}
         .tbldet1    {
    
    background:#285513;
    font-size:12px;
    
    width:170px;
      
    border: 2px solid #333;
 

}

.toolTipA{
    height:200px;
    background: rgba(14, 82, 11, 0.86);
    border: 2px solid #285513;
    border-radius: 5px;
    box-shadow: 5px 5px 5px #333;
    color: #ffffff;
    font-size: 0.8em;
    padding: 10px 10px 10px 35px;
    max-width: 600px;
    position: absolute;
    z-index: 1500;   
    background:#285513;
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
    <script  type="text/javascript" language="javascript">
        var bSubmit = false;
        function mostrarTooltip(elemento, mensaje) {

            // Si no existe aun el tooltip se crea
            if (!document.getElementById(elemento.id + "tp")) {

                // Dimensiones del elemento al que se quiere añadir el tooltip
                anchoElemento = $('#' + elemento.id).width();
                altoElemento = $('#' + elemento.id).height();

                // Coordenadas del elemento al que se quiere añadir el tooltip
                coordenadaXElemento = $('#' + elemento.id).position().left;
                coordenadaYElemento = $('#' + elemento.id).position().top;

                // Coordenadas en las que se colocara el tooltip
                x = coordenadaXElemento + anchoElemento / 2 + 20;
                y = coordenadaYElemento + altoElemento / 2 + 10;

                // Crea el tooltip con sus atributos
                var tooltip = document.createElement('div');
                tooltip.id = elemento.id + "tp";
                tooltip.className = 'toolTipA';
                tooltip.innerHTML = mensaje;
                tooltip.style.left = x + "px";
                tooltip.style.top = y + "px";

                // Añade el tooltip
                document.body.appendChild(tooltip);
            }

            // Cambia la opacidad del tooltip y lo muestra o lo oculta (Si el raton esta encima del elemento se muestra el tooltip y sino se oculta)
            $('#' + elemento.id).hover(
                function () {
                    try {
                     //   $(".toolTipA").show();
                        tooltip.style.display = "block";
                        $('#' + tooltip.id).animate({ "opacity": .86 });
                        $('#' + tooltip.id).animate({ "zIndex": 9999 });
                        $('#' + tooltip.id).focus();
                    }
                    catch (e) { }
                },
                function () {
                    try {
                        //$(".toolTipA").();
                        //tooltip.style.display = "none";
                        //$('#' + tooltip.id).animate({ "opacity": .86 });
                        //$('#' + tooltip.id).animate({ "zIndex": 9999 });

                        $('#' + tooltip.id).animate({ "opacity": 0 });
                        $('#' + tooltip.id).animate({ "zIndex": 9999 });
                        setTimeout(
                            function () {
                                tooltip.style.display = "none";
                            },
                            3
                        );
                    }
                    catch (e) { }

                }
            );
        }
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
            $(document).tooltip("option", "tooltipClass", "i1");
        });

	</script>
    
    
    
</head>
<body  style="background-image: url(img/toyota_cn_servicio_8B.PNG);">

    <form id="form1" runat="server" onsubmit="return fSubmit();">
    
    <script type="text/javascript" src="js/wz_dragdrop.js"> </script>  
     
          
    <div id="floatdiv" style="position: absolute;
        width: 1225px; height: 90px; left: 0px; top: 0px; z-index: 3002;" runat="server">
         <img  alt="" src="img/agenciaLOGOHeader.PNG" style="position: absolute; top: 240px; left: 610px;" />
         <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="img/logout2.png"
                    Width="1px"   OnClientClick="doNothing();" onkeyress="doNothing();" style="position: absolute; top: 40px; left: 1000px;"  />
          <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="img/logout.png"
                    Width="40px" OnClientClick="javascript:bSubmit = true;" OnClick="ImageButton1_Click"  onkeyress="doNothing();"  style="position: absolute; top: 20px; left: 1000px;"  />
        <input type="text" value=""  runat="server" id="dhtml" style="z-index: 1000; left: 550px; position: absolute;
            top: 5px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: White; font-weight: bold;" />
       <input type="text" value="Fecha: " style="z-index: 1000; left: 600px; position: absolute;
            top: 10px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: White; font-weight: bold;" />
        <asp:Label ID="lblCalendar" runat="server" Style="z-index: 1000; left: 675px; position: absolute;
            top: 10px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: White; font-weight: bold;" Text=""></asp:Label>
        <input type="text" value="Usuario: " style="z-index: 1000; left: 600px; position: absolute;
            top: 25px; background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: White; font-weight: bold;" />
        <asp:Label ID="lblUsr" runat="server" Style="z-index: 1000; left: 675px; position: absolute;
            top: 25px;  background-color: Transparent; border: none; font-size: 12px; font-family: Arial;
            color: White; font-weight: bold;" Text=""></asp:Label>
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

    
     <div style=" position: absolute; left:1150px;top: 300px;width:250px; Font-Face:Calibri; border:1px  solid black;Font-Size:11px; font-weight: bold;">
     <table><tr><td>
      ASESORES
      <asp:DataList ID="DataList1" runat="server"  CellPadding="0" RepeatDirection="Vertical"
                                            RepeatLayout="Table" Font-Size="11px" Font-weight="normal" 
                                            HorizontalAlign="Right" CellSpacing="1" >
                                            <ItemTemplate>
                                                <div style="border: solid 1px gray;" > 
                                                 <asp:Label ID="Label1" runat="server" Width="80px" Text='<%# Eval("color") %>' />
                                                    <asp:Label ID="lblcveAsesor" runat="server" Text='<%# Eval("nombre") %>' />
                                                     
                                                </div>
                                            </ItemTemplate>
                                            <FooterStyle    />
                                            <AlternatingItemStyle   />
                                            <ItemStyle   />
                                            <SelectedItemStyle   />
                                            <HeaderStyle    />
                                        </asp:DataList>
    
     </td>
     <td valign="top">
     <table>
     <tr><td style="background-color:green; width:30px;">&nbsp;</td><td>Con cita</td></tr>
     <tr><td style="background-color:blue;width:30px;" >&nbsp;</td><td>Sin Cita</td></tr>
     </table>
     
     </td>
     </tr></table>
   
    
    </div>
       <div class="divdatagrid">
    <asp:DataGrid ID="dgTecnicosOrdenes" runat="server"   CellPadding="1" CellSpacing="0" CssClass="datagrid" AutoGenerateColumns="false">
       <Columns>
           <asp:BoundColumn DataField="NOMBRE_EMPLEADO" HeaderText="Tecnico">
           </asp:BoundColumn>
           <asp:BoundColumn DataField="ref" ItemStyle-HorizontalAlign="Center" HeaderText="Total" Visible="false"></asp:BoundColumn>
            <asp:BoundColumn DataField="aut" ItemStyle-HorizontalAlign="Center" HeaderText="Total" Visible="false"></asp:BoundColumn>
            <asp:BoundColumn DataField="tot" ItemStyle-HorizontalAlign="Center" HeaderText="Total" Visible="false"></asp:BoundColumn>
            <asp:BoundColumn DataField="asig" ItemStyle-HorizontalAlign="Center" HeaderText="Total" Visible="false"></asp:BoundColumn>
          <asp:TemplateColumn HeaderText="Ref" ItemStyle-HorizontalAlign="Center"   ItemStyle-Font-Size="12PX" >
              <ItemTemplate >
                  <asp:LinkButton id="lblTotalR" runat="server" ForeColor="DarkOliveGreen" text='<%# Eval("ref")%>'></asp:LinkButton>

              </ItemTemplate>

          </asp:TemplateColumn>
           <asp:TemplateColumn HeaderText="Aut" ItemStyle-HorizontalAlign="Center"   ItemStyle-Font-Size="12PX" >
              <ItemTemplate >
                  <asp:LinkButton id="lblTotalA" runat="server" ForeColor="DarkOliveGreen" text='<%# Eval("aut")%>'></asp:LinkButton>

              </ItemTemplate>

          </asp:TemplateColumn>
           <asp:TemplateColumn HeaderText="TOT" ItemStyle-HorizontalAlign="Center"   ItemStyle-Font-Size="12PX" >
              <ItemTemplate >
                  <asp:LinkButton id="lblTotalT" runat="server" ForeColor="DarkOliveGreen" text='<%# Eval("tot")%>'></asp:LinkButton>

              </ItemTemplate>

          </asp:TemplateColumn>
           <asp:TemplateColumn HeaderText="Asig" ItemStyle-HorizontalAlign="Center"   ItemStyle-Font-Size="12PX" >
              <ItemTemplate >
                  <asp:LinkButton id="lblTotalAS" runat="server" ForeColor="DarkOliveGreen" text='<%# Eval("asig") %>'></asp:LinkButton>

              </ItemTemplate>

          </asp:TemplateColumn>

       </Columns>
        
         <HeaderStyle CssClass="datagridHD" />
          <ItemStyle CssClass="datagridIT" />
        <FooterStyle CssClass="datagridHD" />

    </asp:DataGrid>
            </div>
    </form>

   
    
</body>
</html>
