<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pull_system3c.aspx.vb" Inherits="TablerosV2.pull_system3c" %>

 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%">
<head id="Head1" runat="server">
    
    <title>Página sin título</title>
    <meta http-equiv="refresh" content="30" />    
     <link rel="stylesheet" href="css/jquery-ui.css" />

  <script  type="text/javascript"src="http://code.jquery.com/jquery-1.9.1.js"></script>

  <script  type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

    
  <script type="text/javascript" language="javascript">
      $(function () {
          $(document).tooltip({
              track: true
          });
      });
  </script>


 <style type="text/css">
     body
     {
          background-color:snow;
         }
               .imgdivH{
 width:110px;}
  .imgdivV{
 height:110px;}
.textdiv
{
     
 font-size:15px;
 font-weight:bold;
  font-family:calibri;
   background-color:snow;
   text-align:center;
   text-shadow:0px 1px 1px #2a2a2a;
   background-position:left top;
     width:40px;
    height:37px;
    border:none;
    margin:0;  
} 
.textResumen{
display:none;
border:none;
background-color:transparent;
position:absolute;
top:0px;
left:800px;
width:300px;
height:100px;
}
</style>
    <script  type="text/javascript" language="javascript">
        ads = new Array(5);
        ads[0] = "http://192.168.1.30:8096/img/pullsystemtoyota/banner1.png";
        ads[1] = "http://192.168.1.30:8096/img/pullsystemtoyota/banner2.png";
        ads[2] = "http://192.168.1.30:8096/img/pullsystemtoyota/banner3.png";
        ads[3] = "http://192.168.1.30:8096/img/pullsystemtoyota/banner4.png";
        ads[4] = "http://192.168.1.30:8096/img/pullsystemtoyota/banner5.png";

        var longuitudArray = ads.length;
        var contador = 0

        contador = Math.floor((Math.random() * longuitudArray))

        var tiempo = 7
        var timer = tiempo * 1000;

        function banner() {
            contador++;
            contador = contador % longuitudArray
            document.banner.src = ads[contador];
            document.banner.style.top = window.height;
            setTimeout("banner()", timer);
        }



        window.onload = function () { banner(); }



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
		            __doPostBack('__Page', "dhtml");
		            return true;
		        }
		    }



		}
     
    
    
	
   
	
	</script>
    
    
    
</head>
<body  runat="server" id="nBody" style="width:100%;height:100%;margin:0; background-repeat:no-repeat;"  >

    <form id="form1" runat="server" >
    
     <asp:ScriptManager runat="server" AsyncPostBackTimeout="0" ID="scrmgr1">
    </asp:ScriptManager>
      <asp:Timer ID="Timer1" runat="server" Enabled="true" Interval="15000"></asp:Timer>
     
    <div id="floatdiv" runat="server"  style="position: absolute;
        width: 1225px; height: 90px; left: 0px; top: 0px; z-index: 3002;" >
         <img  alt="" src="img/agenciaLOGOHeader.PNG" style="position: relative; top: 645px; left: 520px;display:none;" />
          <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="img/logout.png"
                    Width="40px" OnClick="ImageButton1_Click"  style="position: relative; top: 50px; left:975px;"  />
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

     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
       
        </asp:View>
         <asp:View ID="View2" runat="server"  >
          
        </asp:View>
         <asp:View ID="View3" runat="server" >
           
        </asp:View>
        </asp:MultiView>   
    
    
    </form>

   
    
   <img src="" name="banner" height=130 width=850 style="position:absolute;top:600px;left:400px;z-index:1;"/>

</body>
</html>
