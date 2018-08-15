<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="RecepcionCitas.aspx.vb" Inherits="TablerosV2.RecepcionCitas" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>FORD JALBRA</title>
    <link href="App_Themes/THEME1/StyleSheetRecepcionSeguimiento2.css" rel="stylesheet" />
    <script type="text/javascript" src="JS/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="JS/JavaScriptRecepcionSeguimiento.js"></script>

    <!-- Inicia Relativo a ModalWindowEffects -->
    <link href="res/ModalWindowEffects/css/component.css" rel="stylesheet" />
    <script type="text/javascript" src="res/ModalWindowEffects/js/modernizr.custom.js"></script>
    <!-- classie.js by @desandro: https://github.com/desandro/classie -->
    <script type="text/javascript" src="res/ModalWindowEffects/js/classie.js"></script>
    <script type="text/javascript" src="res/ModalWindowEffects/js/modalEffects.js"></script>
    <!-- Termina Relativo a ModalWindowEffects -->
    <script type="text/javascript">
        function VerificarClienteLlego() {
            if (document.querySelector('#md-content-text').innerHTML.length > 0)
                classie.add(document.querySelector('#<%= Panel1.ClientID %>'), 'md-show');
        }
    </script>
        <style type="text/css">
        @-moz-keyframes mymove {
            0% {
                background-color: red;
            }
            50% {
                background-color: transparent;
            }
            100% {
                background-color: transparent;
            }
        }

@-webkit-keyframes mymove {
            0% {
                background-color: red;
            }
            50% {
                background-color: transparent;
            }
            100% {
                background-color: transparent;
            }
        }

@keyframes mymove {
            0% {
                background-color: red;
            }
            50% {
                background-color: transparent;
            }
            100% {
                background-color: transparent;
            }
        }

        @-moz-keyframes mymove2 {
            0% {
                background-color: orange;
            }
            50% {
                background-color: transparent;
            }
            100% {
                background-color: transparent;
            }
        }

@-webkit-keyframes mymove2 {
            0% {
                background-color: orange;
            }
            50% {
                background-color: transparent;
            }
            100% {
                background-color: transparent;
            }
        }

@keyframes mymove2 {
            0% {
                background-color: orange;
            }
            50% {
                background-color: transparent;
            }
            100% {
                background-color: transparent;
            }
        }

        .lblArriboDemorado {
            -moz-animation: mymove infinite;
            -o-animation: mymove infinite;
            -webkit-animation: mymove infinite;
            animation: mymove infinite;
            -moz-animation-duration: 2s;
            -o-animation-duration: 2s;
            -webkit-animation-duration: 2s;
            animation-duration: 2s;
        }
	.lblArriboAnticipado {
            -moz-animation: mymove2 infinite;
            -o-animation: mymove2 infinite;
            -webkit-animation: mymove2 infinite;
            animation: mymove2 infinite;
            -moz-animation-duration: 2s;
            -o-animation-duration: 2s;
            -webkit-animation-duration: 2s;
            animation-duration: 2s;
	}
    </style>
    <script type="text/javascript">
        function verificarAnimacion() {
            $(".lblArribo").each(function () {
                if ($(this).html() == "Demorado") {
                    $(this).attr("class", $(this).attr("class") + " lblArriboDemorado")
                } else if ($(this).html() == "Anticipado") {
                    $(this).attr("class", $(this).attr("class") + " lblArriboAnticipado")
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1"
            EnablePartialRendering="true" AsyncPostBackTimeout="600" />
        <!-- Este Timer es para dg1, dgLibres y modal -->
        <asp:Timer ID="Timer1" runat="server" Interval="15000"></asp:Timer>
        <asp:Timer ID="Timer2" runat="server" Enabled="false" OnTick="Timer2_Tick"></asp:Timer>




        <div class="cssHeader000">
            BIENVENIDA FORD JALBRA
        </div>


        <table class="cssTable001">
            <thead>
                <tr>
                    <th align="left" style="font-size: 15pt"></th>
                    <th align="left" style="font-size: 15pt">&nbsp;</th>
                </tr>
            </thead>
            <tbody>

                <tr>

                    <td valign="top" rowspan="1" class="frmclass">

                        <asp:UpdatePanel ID="UPGUARDAV" runat="server" UpdateMode="Conditional">

                            <ContentTemplate>
                                <asp:Timer ID="Timer11" Interval="2000" Enabled="true" runat="server">
                                </asp:Timer>
                                <input type="text" runat="server" id="nreloj" name="nreloj" size="20"
                                    style="position: absolute; top: 15px; left: 1350px; color: white;" />
                                <asp:DataGrid ID="dg1" runat="server" AutoGenerateColumns="False" CssClass="cssTable000"
                                    AllowPaging="true" PageSize="10" Width="1000px" GridLines="none">

                                    <Columns>
                                        <asp:BoundColumn DataField="HoraAsesor" HeaderText="Hora">
                                            <ItemStyle Width="75px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Vehiculo" HeaderText="Unidad" />
                                        <asp:BoundColumn DataField="noPlacas" HeaderText="Placa" />

                                        <asp:BoundColumn DataField="Cliente" HeaderText="Cliente" ReadOnly="True" />
                                        <asp:BoundColumn DataField="ServicioCapturado" HeaderText="Servicio" />
                                        <asp:BoundColumn DataField="nombre_empleado" HeaderText="Asesor" />
                                        <asp:BoundColumn DataField="HoraRecepcion" HeaderText="" />

                                        <asp:TemplateColumn HeaderText="">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArribo" runat="server" Text=""></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn>
                                            <ItemTemplate>
                                                <img id="imgGreen" runat="server" name="imgGreen" src="img/semaforo_verde.gif" class="cssImg" align="middle" />
                                                <img id="imgYellow" runat="server" name="imgGreen" src="img/semaforo_yellow.gif" class="cssImgHdd" align="middle" />
                                                <img id="imgRed" runat="server" name="imgGreen" src="img/semaforo_rojo.gif" class="cssImgHdd" align="middle" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <HeaderStyle CssClass="cssTable000th" Font-Bold="true" Font-Size="23px" BackColor="#CC0000" BorderStyle="Solid" BorderWidth="1px" BorderColor="White" />
                                    <ItemStyle Font-Bold="true" Font-Size="18px" />

                                    <PagerStyle Visible="false" />

                                </asp:DataGrid>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>


                    </td>

                    <td valign="middle" rowspan="3" class="frmclass">

                      <%--  <iframe width="400" height="290" id="Video1"
                            src="https://www.youtube.com/embed/ijUT9G7pq58?feature=player_embedded&autoplay=1&controls=0&loop=1&playlist=ijUT9G7pq58&rel=0&showinfo=0&autohide=1&color=white&iv_load_policy=3&theme=light"></iframe>--%>

                    </td>
                </tr>


                <tr>

                    <td valign="top" class="frmclass">
                        <br />
                        &nbsp;</td>

                </tr>


                <tr>

                    <td valign="top" class="frmclass">
                        <asp:UpdatePanel ID="UPGUARDAV2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Timer ID="Timer12" Interval="5000" Enabled="true" runat="server">
                                </asp:Timer>

                                <asp:DataGrid ID="dgLibres" runat="server" AutoGenerateColumns="False" CssClass="cssTable000"
                                    AllowPaging="true" PageSize="10" Width="1000px" GridLines="none">

                                    <Columns>
                                        <asp:BoundColumn DataField="Hora" HeaderText="TIPO">
                                            <ItemStyle Width="75px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Vehiculo" HeaderText="Vehiculo" />
                                        <asp:BoundColumn DataField="noPlacas" HeaderText="Placas" />
                                        <asp:BoundColumn DataField="Color" HeaderText="Cono" />
                                        <asp:BoundColumn DataField="Cliente" HeaderText="Cliente" ReadOnly="True" />
                                        <asp:BoundColumn DataField="ServicioCapturado" HeaderText="Servicio" />
                                        <asp:BoundColumn DataField="nombre_empleado" HeaderText="Asesor" />
                                        <asp:BoundColumn DataField="HoraPromesa" HeaderText="Hora Promesa">
                                            <ItemStyle Width="90px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="estatus_orden" HeaderText="Estatus" />
                                        <asp:TemplateColumn>
                                            <ItemTemplate>
                                                <img id="imgGreen" runat="server" src="img/semaforo_verde.gif" class="cssImg" align="middle" />
                                                <img id="imgYellow" runat="server" src="img/semaforo_yellow.gif" class="cssImgHdd" align="middle" />
                                                <img id="imgRed" runat="server" src="img/semaforo_rojo.gif" class="cssImgHdd" align="middle" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateColumn>
                                    </Columns>

                                    <HeaderStyle CssClass="cssTable000th" Font-Bold="true" Font-Size="23px" BackColor="#CC0000" BorderStyle="Solid" BorderWidth="1px" BorderColor="White" />
                                    <ItemStyle Font-Bold="true" Font-Size="18px" />

                                    <PagerStyle Visible="false" />

                                </asp:DataGrid>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <br />
                        <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#dddddd"
                            RepeatDirection="Horizontal" RepeatLayout="Table" Font-Size="17px">
                            <ItemTemplate>
                                <div style="border: solid 1px gray;">
                                    Placas:
                <asp:Label ID="lblnoPlacas" runat="server"
                    Text='<%# Eval("noPlacas") %>'>
                </asp:Label>


                                </div>

                            </ItemTemplate>

                            <FooterStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
                            <AlternatingItemStyle BackColor="#000000" />
                            <ItemStyle BackColor="#000000" />
                            <SelectedItemStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
                        </asp:DataList>

                    </td>
                </tr>


            </tbody>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" CssClass="md-modal md-effect-13">
                    <div class="md-content">
                        <h3>¡Bienvenido!</h3>
                        <div>
                            <div id="md-content-text">
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>

    </form>
    <div class="md-overlay"></div>
    <!-- the overlay element -->
</body>
</html>
