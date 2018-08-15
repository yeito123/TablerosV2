  <%@ Page Language="VB" AutoEventWireup="false" CodeBehind="RecepcionCitas2.aspx.vb" Inherits="TablerosV2.RecepcionCitas2" %>


	  <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

	  <html xmlns="http://www.w3.org/1999/xhtml">
		  <head id="Head1" runat="server">
			  <title>Recepcion Citas</title>
			  <link href="App_Themes/THEME1/StyleSheetRecepcionSeguimiento2.css" rel="stylesheet" />
			  <script type="text/javascript" src="JS/jquery-1.9.1.js"></script>
			  <script type="text/javascript" src="JS/JavaScriptRecepcionSeguimiento.js"></script>
		  </head>
		  <body onload="mReloj()">
			  <form id="form1" runat="server">
				  <asp:ScriptManager runat="server" id="ScriptManager1"
						 EnablePartialRendering="true" AsyncPostBackTimeout="600" />

				  <asp:Timer ID="Timer1" Interval="60000" Enabled="false"  runat="server">

				  </asp:Timer>
				  <div class="cssHeader000">
<input type="text" id="nreloj" name="nreloj" size="24"  style="color:white;" onfocus="window.document.form.nreloj.blur()" />
				<asp:Label ID="lblTitulo" runat="server" Text=" LE DA LA BIENVENIDA"></asp:Label>
                      	  
					  
				  </div>


				  <table class="cssTable001">
					  <thead>
						  <tr>
							  <th colspan="2" align="left" style="font-size: 15pt">Conoce mas acerca</th>
						  </tr>
					  </thead>
					  <tbody>

						  <tr>

							  <td valign="top">
								  <img width="280" height="170" id="Video4"
									 src="img/agencialogoheader.png"    /> 
							  </td>
							  <td  valign="top"  rowspan="2"  class="frmclass">

								  <asp:UpdatePanel ID="UPGUARDAV" runat="server" RenderMode="Block"
														  UpdateMode="Conditional">
									  <ContentTemplate>
										  <asp:DataGrid ID="dg1" runat="server" AutoGenerateColumns="False"  CssClass="cssTable000"
														AllowPaging="true" PageSize="15" Width="1000px">
											  <ItemStyle ForeColor="black" Font-Bold="False" Font-Italic="False" Font-Overline="False"
												  Font-Strikeout="False" Font-Underline="False" Font-Size="33px"  />
											  <Columns>



												  <asp:BoundColumn DataField="HoraAsesor" HeaderText="Hora"   >
													  <ItemStyle width="75px" CssClass="cssTransparency"/>
												  </asp:BoundColumn>


												  <asp:BoundColumn DataField="Cliente" HeaderText="Cliente" ReadOnly="True" >
													  <ItemStyle width="350px"  CssClass="cssTransparency" />
												  </asp:BoundColumn>
												  <asp:BoundColumn DataField="Vehiculo" HeaderText="Unidad"  Visible="true">
													  <ItemStyle   CssClass="cssTransparency" />
												  </asp:BoundColumn>
												  <asp:BoundColumn DataField="nombre_empleado" HeaderText="Asesor" >
													  <ItemStyle   CssClass="cssTransparency" />
												  </asp:BoundColumn>

												  <asp:BoundColumn DataField="noPlacas" HeaderText="Placa" Visible="true">
													  <ItemStyle   CssClass="cssTransparency" />
												  </asp:BoundColumn>
												  <asp:BoundColumn DataField="ServicioCapturado" HeaderText="Servicio" Visible="false">
													  <ItemStyle   CssClass="cssTransparency" />
												  </asp:BoundColumn>
												  <asp:BoundColumn DataField="HoraRecepcion" HeaderText="" Visible="false">
													  <ItemStyle   CssClass="cssTransparency" />
												  </asp:BoundColumn>

												  <asp:BoundColumn DataField="HoraRecepcion" HeaderText="HoraLlego" Visible="true">
													  <ItemStyle width="55px" BackColor=""  CssClass="cssTransparency" />
												  </asp:BoundColumn>
                                                   <asp:BoundColumn DataField="horapromesa" HeaderText="Fecha Com" Visible="true">
													  <ItemStyle width="55px" BackColor=""  CssClass="cssTransparency" />
												  </asp:BoundColumn>
                                              <%--    <asp:BoundColumn DataField="concita" HeaderText="Citta" Visible="true">
													  <ItemStyle width="55px" BackColor=""  CssClass="cssTransparency" />
												  </asp:BoundColumn>--%>
												  <asp:TemplateColumn HeaderText="">
													  <ItemStyle   CssClass="cssTransparency" />
													  <ItemTemplate>
														  <asp:Label ID="lblArribo" runat="server" Text=""></asp:Label>
													  </ItemTemplate>

												  </asp:TemplateColumn>
												  <asp:TemplateColumn>
													  <ItemTemplate>
														  <img id="imgGreen" runat="server" name="imgGreen" src="img/semaforo_verde.gif" class="cssImg" align="middle" />
														  <img id="imgYellow" runat="server"  name="imgGreen" src="img/semaforo_yellow.gif" class="cssImgHdd" align="middle" />
														  <img id="imgRed" runat="server"  name="imgGreen" src="img/semaforo_rojo.gif" class="cssImgHdd" align="middle" />
													  </ItemTemplate>
													  <ItemStyle Width="10px"  CssClass="cssTransparency"/>
												  </asp:TemplateColumn>
											  </Columns>
											  <HeaderStyle Font-Bold="true" Font-Size="25px" />
											  <FooterStyle BackColor="#003366" Font-Bold="True"   Font-Italic="False"
												  Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
											  <EditItemStyle BackColor="#999999" />
											  <SelectedItemStyle BackColor="#4F7575" Font-Bold="True"   Font-Italic="False"
												  Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
											  <PagerStyle Visible="false" />
											  <AlternatingItemStyle BorderColor="White"   Font-Bold="False" Font-Italic="False"
												  Font-Overline="False" Font-Strikeout="False" Font-Underline="False"  Font-Size="33px" />
										  </asp:DataGrid>
									  </ContentTemplate>
									  <Triggers>
										  <asp:AsyncPostBackTrigger ControlID="Timer3" EventName="Tick" />
									  </Triggers>
								  </asp:UpdatePanel>
								  <asp:Timer ID="Timer3" Interval="20000" Enabled="true"  runat="server"/>

							  </td>
						  </tr>


						  <tr>

							  <td  valign="top">
								  <table>
									<%--  <tr>
										  <td>
											  <iframe width="280" height="170" id="Video1"
													src="https://www.youtube.com/embed/"
												  <% Response.Write(Request.QueryString("v1"))%>?feature=player_embedded&autoplay=1&controls=0&loop=1&rel=0&showinfo=0&autohide=1&color=white&iv_load_policy=3&theme=light">
											  </iframe>

										  </td>
									  </tr>--%>
									  <tr>

										  <td>
											  <iframe width="280" height="170" id="Iframe1"
												  src="https://www.youtube.com/embed/jAQv10vbNPo?feature=player_embedded&autoplay=1&controls=0&loop=1&rel=0&showinfo=0&autohide=1&color=white&iv_load_policy=3&theme=light">
											  </iframe>
										  </td>

									  </tr>



								  </table>
							  </td>


						  </tr>


					  </tbody>
				  </table>


			  </form>
		  </body>
	  </html>
  