<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="_zcrmCuestionarioDetalle.aspx.vb" Inherits="TablerosV2._zcrmCuestionarioDetalle" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"/>
   
    <!--<link rel="stylesheet" href="css/generales.css" />-->
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css"/>
    <script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <title>Encuesta de Calidad (Servicio)</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style5
        {
            width: 100%;
        }
                .cssnone
        {
            display:none;
        }
        .lstM
        {
            border: 1px solid #460000;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
            scrollbar-face-color: #FFFFFF;
            scrollbar-shadow-color: #D07575;
            scrollbar-highlight-color: #D07575;
            scrollbar-3dlight-color: #F6F4FD;
            scrollbar-darkshadow-color: #F6F4FD;
            scrollbar-track-color: #FDFDFE;
            scrollbar-arrow-color: #D07575;
        }
        .txt{
            border-bottom: 1px solid #460000;
            border-top: none;
            border-left: none;
            border-right: none;
            font-family: Arial;
            font-size: 15px;
            font-weight: normal;
            
        }
        .txt3{
            border:none;
            font-family: Arial;
            font-size: 12px;
            font-weight: normal;
            
        }
           .txtIni{
            border-bottom: 1px raised #460000;
            font-family: Arial;
            font-size: 20px;
            font-weight: normal;
        }
        
        .lblErr{
            font-size: 20px;
            color:"#FF0000";
            background-color:#FF0000;            
        }
        .cmd{
          background-color:#ffffff ;
         color:"#4D1111";
           border:solid 1px #000000;
            font-weight:bold;
             font-family:Arial;
             font-size:16px;
          
        }
        .cbo{
            border-bottom: 1px solid #460000;
            font-family: Arial;
            font-size: 15px;
            font-weight: normal;
        }
        .lblTitulo{
            border:none;
            font-family: Arial;
            font-size: 20px;
            font-weight: bold;
             font-variant:small-caps;
            color: #752D17;
        }
        .lblTitulo2{
            border:none;
            font-family: Arial;
            font-size: 18px;
            font-weight: NORMAL;            
            color: #000000;
        }
        .div2{
        width:100%;
         height:100%;
         border: 2px inset #460000;
            font-family: Helvetica;
            font-size: 12px;
            font-weight: normal;
        
        }
        div{
          
            font-family: Helvetica;
            font-size: 12px;
            font-weight: normal;
        
        }
        .style10
        {
            width: 684px;
        }
        .style11
        {
            width: 46px;
        }
        .style12
        {
            height: 19px;
            width: 848px;
        }
               .grd100
        {
            width:100%;
            height:100%;
        }
               .grd70
        {
            width:70%;
        }
             .grd90
        {
            width:1000PX;
        }
        .lblPregunta{
         font-size:24px;
          width:100%;
        }
        .style14
        {
            width: 17px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
     <ajaxToolkit:ToolkitScriptManager runat="Server" id="ScriptManager1" />
     
    <div class="container">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
       <asp:View ID="View0" runat="server">   
               
                <asp:Panel runat="server" ID="Panel2"   class="container">
            <table class="div2">
                <tr>
                    
                    <td >
                        <asp:Label ID="Label1" runat="server" CssClass="lblTitulo" 
                            Text="ENCUESTA DE CALIDAD DE SERVICIO"></asp:Label>
                        <asp:Label ID="lblID" runat="server" Font-Size="10px" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="txt3" Enabled="false" 
                            Width="154px"></asp:TextBox>
                        
                    </td>
                    <td  >
                        
                        <asp:ImageButton ID="imgSalir" runat="server" BackColor="#F4F4F4" 
                            ImageUrl="~/img/Previous_32x32.png" ToolTip="Regresar" />
                        
                       </td>
                </tr>
                <tr>
                  
                    <td  >
                       
                        
                         <table class="table table-striped table-condensed">
                            <tr>
                                <td class="style14" rowspan="2">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/AgenciaLogoHeader.png"  style="float: left;"/>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" CssClass="lblTitulo2" 
                                        Text="ESCRIBA SU NUMERO DE ORDEN"></asp:Label>
                                </td>
                             </tr>
                             <tr>
                                 <td valign="top">
                                 <table><tr><td>   <asp:TextBox ID="txtOrden" runat="server" class="form-control input-sm"  ></asp:TextBox></td><td> 
                                     <asp:ImageButton ID="ImgBtnRef" runat="server" 
                                         ImageUrl="~/img/continuar.gif" /></td></tr></table>
                                  
                                    
                                 </td>
                             </tr>
                         </table>
                    </td>
                    
                </tr>
            </table>
          
        </asp:Panel>
 
    </asp:View>
   <asp:View ID="View1" runat="server">   
          <asp:Panel runat="server" ID="pnlFirst">
                <asp:Panel runat="server" ID="pNLCT1"  class="col-md-12">
            <table>
                <tr>
                    <td>
                        <asp:Image runat="server" ID="Imglogo1" ImageUrl="~/img/AgenciaLogoHeader.png" />
                    </td>
                    <td  >
                        <asp:Label runat="server" ID="LblTitulo" Text="ENCUESTA DE CALIDAD DE SERVICIO"
                          CssClass="lblTitulo"></asp:Label>
                    </td>
                    <td>
                        
                    <table  class="form-group" >
                        <tr>
                                <td>
                                    No. Orden</td>
                                <td align="right">
                                    <asp:TextBox ID="txtOrden1" runat="server"  class="form-control label-info"></asp:TextBox>
                                        </td>
                            </tr>
                            
                        </table>
                    </td>
                </tr>
            </table>
            <table  class="form-group">
             <tr>
                    <td  >
                        Nombre:</td>
                    <td  >
                        <asp:TextBox ID="txtClientenombre" runat="server"    class="form-control label-info" ></asp:TextBox>
                    </td>
					<td  >
                        Asesor</td>
                    <td  >
                        <asp:DropDownList ID="CboAsesor" runat="server"  Width="195px"   class="form-control label-info">
                        </asp:DropDownList>
                       
                    </td>
                </tr>
                <tr>
                    <td  >
                    Dirección:</td>
                    <td >
                        <asp:TextBox ID="txtDireccion"  runat="server" Width="635px"   class="form-control label-info"  ></asp:TextBox>
                    </td>
                    <td >
                        Colonia:</td>
                    <td >
                        <asp:TextBox ID="txtColonia"  runat="server" Width="195px"   class="form-control label-info" ></asp:TextBox>
                    </td>
                </tr>
				</table>
				<table  class="table table-striped table-condensed">
                <tr>
                    <td >
                    Tipo de Auto:</td>
                    <td >
                        <asp:TextBox ID="txtTipoAuto" runat="server" Width="195px"   class="form-control label-info" ></asp:TextBox>
                    </td>
                    <td >
                    Telefono:</td>
                    <td >
                        <asp:TextBox ID="txtTelefono" runat="server" Width="195px"   class="form-control label-info" ></asp:TextBox>
                    </td>
					<td >
					Celular:</td>
						<td  >
						<asp:TextBox ID="txtCelular" runat="server" width="195px"  class="form-control label-info" ></asp:TextBox>
						</td>
                </tr>
                <tr>
                    <td >
                    C.P.:</td>
                    <td>
                        <asp:TextBox ID="txtCP" runat="server" Width="195px"   class="form-control label-info"  ></asp:TextBox>
                    </td>
                    <td  >
                    Correo:</td>
                    <td >
                        <asp:TextBox ID="txtCorreo"  runat="server" Width="250px"   class="form-control label-info" ></asp:TextBox>
                    </td>
					<td  >
					Fecha:</td>
					<td >
						<asp:TextBox ID="txtCumpleaños" runat="server" width="250px"  class="form-control label-info"></asp:TextBox>
						<ajaxToolkit:CalendarExtender runat="server" Format="dd/MM/yyyy"  
            Animated="true" ID="clCalendarEx" TargetControlID="txtCumpleaños" PopupPosition="BottomLeft"
            PopupButtonID="txtCumpleaños"/>
						</td>
              </tr>
                     
                    <tr>
                       
                        <td  class="col-sm-4 form-inline">
                            <asp:ImageButton ID="ImgBtnRef1" runat="server" 
                                ImageUrl="~/img/continuar.gif" />
                        </td>
                    </tr>
            </table>
        </asp:Panel>

       </asp:Panel>

    </asp:View>
     <asp:View ID="View2" runat="server">  
            <asp:Panel runat="server" ID="PnlPReguntas" class="form-group">
            <table  >
                <tr>
                    <td style="text-align: left">
                        <asp:Label runat="server" CssClass="lblTitulo2" ID="LblLeyenda" Text="Esta encuesta nos ayudará a mejorar la calidad de nuestros servicios, le suplicamos nos regale unos minutos de su valioso tiempo:"
                            Style="text-align: center"></asp:Label>
                    </td>
                </tr>
            </table>
            <table class="form-group">
                <tr>
                    <td bgcolor="White" class="style12">
                        <asp:Label runat="server" ID="Lblpregunta1"   Text="" Visible="false"
                            Width="825px"></asp:Label>
                    </td>
                   
                </tr>
            </table>
            <table class="form-group">
                <tr>
                    <td class="style5">
                        <asp:Gridview ID="dgPreguntas" runat="server" AutoGenerateColumns="False" 
                            BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" GridLines="Horizontal" 
                            ShowHeader="False" CellPadding="7" AllowPaging="true" PageSize="1" CssClass="grd100" CellSpacing="3">
                           
                            <RowStyle Font-Size="15px" />
                            <Columns>
                            
                                <asp:BoundField  DataField="ID_PREGUNTA" HeaderText="" ItemStyle-CssClass="cssnone"  />
                                 <asp:TemplateField>
                                 
                                    <ItemTemplate>
                                    <asp:PlaceHolder ID="PLHOLDERTXT" runat="server"   >
                                    <asp:Label ID="lblDesc" CssClass="lblPregunta" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label>
                                    <br />
                                    <br />
                                    <asp:PlaceHolder ID="PLHOLDER"   runat="server">
                                    
                                    </asp:PlaceHolder>
                                    </asp:PlaceHolder>
                                         
                                    </ItemTemplate>
                                    
                                    <ItemStyle BackColor="#F8F8FC" Font-Bold="True" Font-Italic="False" 
                                        Font-Names="Arial" Font-Overline="False" Font-Size="24px" 
                                        Font-Strikeout="False" Font-Underline="False" CssClass="col-md-12""  />
                                        
                                </asp:TemplateField>
                                
                                   
                                 
                                     <asp:BoundField DataField="tcontrol" HeaderText=""   ItemStyle-CssClass="cssnone" />
                                   <asp:BoundField DataField="opciones" HeaderText="" ItemStyle-CssClass="cssnone" />
                                  
                                <asp:TemplateField>
                                
                                    <ItemTemplate>
                                   
                                         
                                    </ItemTemplate>
                                    
                                    <ItemStyle Font-Size="24px" />
                                </asp:TemplateField>
                            
                            </Columns>
                             <pagertemplate>
                        <table width="100%">
                          <tr>
                            <td style="text-align:center" >
                            
                               <asp:linkbutton id="btnPrev" runat="server" Visible='<%#  session("ASVisible")  %>'  causesvalidation="False" commandargument="Prev" commandname="Page" text="Anterior" />
                             <asp:linkbutton id="btnNext" runat="server" Visible='<%#  session("ASVisible")  %>'  causesvalidation="False" commandargument="Next" commandname="Page" text="Siguiente" />                          
                              
                               <asp:ImageButton ID="imgFin" runat="server" Visible='<%#  session("FinVisible")  %>' ImageUrl="~/img/ENVIAR.png" 
                            onclick="imgFin_Click"  />
                             </td>
                          </tr>
                        </table>
                    </pagertemplate>
                            <HeaderStyle Font-Names="Courier New" Wrap="True" />
                            <FooterStyle Font-Size="30px"    />
                           
                            <AlternatingRowStyle BorderColor="White" />
                             
                            <PagerStyle  Font-Size="22px" Font-Names="Arial"  Font-Bold="true"    HorizontalAlign ="Center"/>
                             
                                                   </asp:Gridview>
                                                  
                    </td>
                    
                </tr>
                 
                 
                <tr>
                    <td class="style5">
                         
                       
                    </td>
                </tr>
                 
                 
                </table>
           
        </asp:Panel>
   <asp:Panel ID="pnlFooter" Visible="false" runat="server"  CssClass="col-sm-4 form-inline" >
                <table   >
                <tr><td>   &nbsp;</td></tr>
                <tr><td style=" font-weight:bold;"> Muchas Gracias por su tiempo</td></tr>
                <tr><td>   &nbsp;</td></tr>
                <tr><td style=" font-weight:bold;"> Atentamente</td></tr>
                <tr><td>   &nbsp;</td></tr>
                <tr><td style=" font-weight:bold;"> Gerencia de Servicio</td></tr>
                <tr><td style=" font-weight:bold;"> </td></tr>
                <tr><td>   &nbsp;</td></tr>
               
               
            </table>
            </asp:Panel>
    </asp:View>
      
    </asp:MultiView>
    
        
     </div>
    </form>
</body>
</html>
