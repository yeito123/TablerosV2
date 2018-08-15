<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pull_systemDetalle2.aspx.vb" Inherits="TablerosV2.pull_systemDetalle2" %>
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
    <title>Página sin título</title>
    <meta http-equiv="refresh" content="55" />   
      <link rel="stylesheet" href="css/jquery-ui.css" />

  <script  type="text/javascript"src="js/jquery-1.9.1.js"></script>

  <script  type="text/javascript" src="js/jquery-ui.js"></script> 
  <style type="text/css">
      
      .LBLST{
   color:Navy
  }
  .TBLHEAD
  {
       font-size:20px;
       font-family:Calibri;
       font-weight:bold;
       font-variant: small-caps;
       
      
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
  </style>   

    <script  type="text/javascript" language="javascript">
      
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
		$(function () {
		    $(document).tooltip({
		        track: true
		    });
		});
	
	</script>
    
    
</head>
<body >

    <form id="form1" runat="server" >
    
    
      <div>
      <table class="TBLHEAD" style="width:100%;">
        <tr>
            <td>
                Detalle de Pull System</td>
             
            <td>
                <asp:Label ID="lblStatus" runat="server" CssClass="LBLST" Text=""></asp:Label>
            </td>
             
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="cmdExport" runat="server" Text="Exportar" />
            </td>
             
        </tr>
        <tr>
            <td colspan="2">
                <asp:DataGrid ID="dg1" runat="server" Font-Size="12px"
                                    Font-Bold="False" Font-Italic="False" 
              Font-Names="Arial Rounded MT Bold" Font-Overline="False"
                                    Font-Strikeout="False" Font-Underline="False" 
              CssClass="cssDefault" Width="850px" BackColor="White" BorderColor="#CCCCCC" 
              BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Horizontal" 
                    ForeColor="Black" >
          <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
          <HeaderStyle BackColor="#003366" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
          <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    
                                </asp:DataGrid>
    </td>
        </tr>
        </table>
     
    </div>
    
    
    </form>

   
    
    

   
    
</body>
</html>
