<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="zRecepcionAsesoresServiciosOrden.aspx.vb" Inherits="TablerosV2.zRecepcionAsesoresServiciosOrden" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <style type="text/css">
    html{ overflow:hidden;   }
        .cssDefault
        {
            width: 97%;
            font-size: 16px;
        }
        .cssLink
        {
            color: #A8BBCE;
        }
        .cssImg
        {
            width: 21px;
            display: block;
        }
        .cssImgHdd
        {
            width: 21px;
            display: none;
        }
        .GrdOver
        {
            height: 0px;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
        }
         .GrdOver2
        {	overflow: auto;
        height:270px;
            width: 720px;
            scrollbar-face-color: #fffffff;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #0e0e0e;
            scrollbar-darkshadow-color: #0e0e0e;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
            color: black;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 16px;
            font-weight: bold;
        }
        .GrdOver2b
        {
            height: 0px;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
            color: BLACK;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 16px;
            font-weight: ;
        }
        .GrdOver3
        {
            border: 1px solid #dd9BC7;
            color: Black;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 18px;
            font-weight: bold;
            width: 700px; 
            'height:300px;
        }
        .GrdOver3b
        {
           
            width: 700px; 
            height:400px;
        }
          
                
        .GrdOver4
        {
            border: 0px solid #009BC7;            
            color: Black;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 18px;
            font-weight: bold;
        }
          .GrdOver5
        {
            overflow: auto;
            height: 75px;
            width: 902px;
            scrollbar-face-color: #000000;
            scrollbar-shadow-color: #0033ff;
            scrollbar-highlight-color: #003366;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #003366;
            scrollbar-arrow-color: #0033ff;
            color: BLACK;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 16px;
            font-weight: ;
        }
    </style>
    
    
<%--<meta http-equiv="refresh" content="30" />--%>
</head>
<body bgcolor="#ffffff" > 
    <form id="form1" runat="server">
    
         
           
      <asp:ScriptManager runat="server" id="ScriptManager1b" 
            EnablePartialRendering="true" AsyncPostBackTimeout="600" />		 

     <table style="width:97%;">
    <tr>
    <td align="left"> <asp:Image ID="Image1" runat="server" 
            ImageUrl="img/AgenciaLogoHeader.png" /></td>
    
    <td align="right"> <asp:ImageButton  ID="imgSalir" runat="server" 
            AlternateText="Salir"  onclientclick="window.close();" 
            ImageUrl="img/logout.png" /></td>
     
    </tr>
    </table>
          
    <div>
        <table style="width: 95%;">
        <tr>
        <td>Placas: <asp:Label ID="LBLPLACAS" runat="server"   Font-Bold="True" Font-Names="arial"
                Font-Size="12px" 
                Text="" ></asp:Label> </td>
        <td>Orden: <asp:Label ID="LBLORDEN" runat="server"   Font-Bold="True" Font-Names="arial"
                Font-Size="12px" 
                Text="" ></asp:Label> </td>
        <td>VIN:
         <asp:Label ID="LBLVIN" runat="server"   Font-Bold="True" Font-Names="arial"
                Font-Size="12px" 
                Text="" ></asp:Label>
        </td>
      
        </tr>
           
      
           
            <tr>
                <td colspan=3>
                 <asp:Label ID="Label1" runat="server" BackColor="gainsboro"  Font-Bold="True" Font-Names="arial"
                Font-Size="Small" 
                Text="ORDEN DE SERVICIOS" Width="592px"></asp:Label>
                           <div id="divServiciosH" class="GrdOver2" runat="server" style=" display:block;">
           
           
             
        
            <asp:GridView ID="gvServiciosH" runat="server"   AutoGenerateColumns="True"
               Font-Names="arial" Font-Size="11px"  
                 Width="700px">
               
                <Columns/>
                                       <RowStyle BackColor="Gainsboro" />
                <HeaderStyle BackColor="#BED8D8" />
            </asp:GridView>
        
        </div>
  
                </td>
            </tr>
        
        </table>
    </div>
    </form>
</body>
</html>
