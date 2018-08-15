<%@ Page Language="VB"  CodePage="1252"   AutoEventWireup="false" CodeBehind="Diagnostico.aspx.vb" Inherits="TablerosV2.Diagnostico" %>
<%Response.Charset = 1252%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>

    <script  type="text/javascript" language="javascript">

        function backtopage() {
            var w = window.self;
            w.opener = window.self;
            w.close();
        }


    </script>


	<script language="javascript" type="text/javascript">
	    function popitup(url) {
	        newwindow = window.open(url, 'name', 'height=200,width=150');
	        if (window.focus) { newwindow.focus() }
	        return false;
	    }
	</script>



</head>
<body>
    <form id="form1" runat="server">

    <asp:Panel ID="Panel1" runat="server" Height="1216px" Style="z-index: 100; left: 16px;
        position: absolute; top: 56px" Width="1184px">
        
        <asp:TextBox ID="fechaRecepcion" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 184px; position: absolute; top: 34px" Width="80px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="horaRecepcion" runat="server" Font-Size="Small"
            Style="z-index: 133; left: 392px; position: absolute; top: 34px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoRecepcion" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 424px; position: absolute; top: 34px" Width="16px" Height="16px"></asp:TextBox>
        <asp:RadioButtonList ID="rbl_CltEmpTrae" runat="server" Font-Size="Small" Height="1px"
                RepeatDirection="Horizontal" Style="z-index: 102; left: 8px; position: absolute;
                top: 56px" Width="264px">
            <asp:ListItem Value="0">Cliente trae v.</asp:ListItem>
            <asp:ListItem Value="1">Concesionario recoge v.</asp:ListItem>
        </asp:RadioButtonList>
        <asp:CheckBoxList ID="cbl_VehiculoCortesia" runat="server" Font-Size="Small" Style="z-index: 109;
            left: 326px; position: absolute; top: 56px" TextAlign="Left">
            <asp:ListItem Value="0">Veh&#237;culo cortes&#237;a</asp:ListItem>
        </asp:CheckBoxList>
        <asp:TextBox ID="fechaEntrega" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 184px; position: absolute; top: 82px" Width="80px"></asp:TextBox>
        <asp:TextBox ID="horaEntrega" runat="server" Font-Size="Small" Height="16px" Style="z-index: 108;
            left: 392px; position: absolute; top: 82px" Width="16px"></asp:TextBox>
        <asp:TextBox ID="minutoEntrega" runat="server" Font-Size="Small" Height="16px" Style="z-index: 107;
            left: 424px; position: absolute; top: 82px" Width="16px"></asp:TextBox>
        <asp:RadioButtonList ID="rbl_CltEmpRetira" runat="server" Font-Size="Small" Height="1px"
            RepeatDirection="Horizontal" Style="z-index: 130; left: 16px; position: absolute;
            top: 104px" Width="264px">
                <asp:ListItem Value="0">Cliente retira v.</asp:ListItem>
                <asp:ListItem Value="1">Concesionario entrega v.</asp:ListItem>
         </asp:RadioButtonList>
        <asp:TextBox ID="nombreCliente" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 16px; position: absolute; top: 152px" Width="416px"></asp:TextBox>
        <asp:TextBox ID="direccionCliente" runat="server" Font-Size="Small" Height="16px"
            Style="z-index: 133; left: 16px; position: absolute; top: 176px" Width="416px"></asp:TextBox>
        <asp:TextBox ID="telefonoCliente" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 16px; position: absolute; top: 200px" Width="416px"></asp:TextBox>

        <asp:TextBox ID="fechaDiagnostico" runat="server" Font-Size="Small" Height="16px"
            Style="z-index: 106; left: 496px; position: absolute; top: 7px" Width="96px"></asp:TextBox>
        <asp:TextBox ID="nombreAsesor" runat="server" Font-Size="Small" Height="16px" Style="z-index: 105;
            left: 848px; position: absolute; top: 7px" Width="192px"></asp:TextBox>
        <asp:TextBox ID="noDiagnostico" runat="server" Font-Size="Small" Style="z-index: 104;
            left: 560px; position: absolute; top: 34px" Width="80px"></asp:TextBox>
        <asp:TextBox ID="noOrden" runat="server" Font-Size="Small" Height="16px" Style="z-index: 103;
            left: 856px; position: absolute; top: 34px" Width="80px"></asp:TextBox>
        <asp:TextBox ID="fechaConfirmacion" runat="server" Font-Size="Small" Height="16px"
            Style="z-index: 133; left: 560px; position: absolute; top: 58px" Width="80px"></asp:TextBox>
        <asp:TextBox ID="horaConfirmacion" runat="server" Font-Size="Small" Height="16px"
            Style="z-index: 133; left: 704px; position: absolute; top: 58px" Width="16px"></asp:TextBox>
        <asp:TextBox ID="minutoConfirmacion" runat="server" Font-Size="Small" Height="16px"
            Style="z-index: 133; left: 744px; position: absolute; top: 58px" Width="16px"></asp:TextBox>
        <asp:TextBox ID="nombreConfirmacion" runat="server" Font-Size="Small" Height="16px"
            Style="z-index: 133; left: 856px; position: absolute; top: 58px" Width="184px"></asp:TextBox>
        <asp:RadioButtonList ID="rbl_Conducido" runat="server" Font-Size="Small" Height="24px"
                RepeatDirection="Horizontal" Style="z-index: 131; left: 445px; position: absolute;
                top: 102px" Width="192px">
            <asp:ListItem Value="0">Propietario</asp:ListItem>
            <asp:ListItem Value="1">Familia</asp:ListItem>
            <asp:ListItem Value="2">Otro</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="txtVehiculoConducido" runat="server" Height="16px" Style="z-index: 122;
            left: 656px; position: absolute; top: 106px" Width="120px"></asp:TextBox>
        <asp:TextBox ID="lecturaVelocimetroCita" runat="server" Height="16px" Style="z-index: 122;
            left: 880px; position: absolute; top: 106px" Width="56px"></asp:TextBox>
        <asp:TextBox ID="vehiculoPlacas" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 504px; position: absolute; top: 130px" Width="80px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="DOFU" runat="server" Font-Size="Small" Style="z-index: 101;
            left: 504px; position: absolute; top: 154px" Width="80px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="vehiculoNombreModelo" runat="server" Font-Size="Small" Height="16px"
            Style="z-index: 101; left: 574px; position: absolute; top: 177px" Width="112px"></asp:TextBox>
        <asp:TextBox ID="vehiculoModelo" runat="server" Font-Size="Small" Height="16px" Style="z-index: 101;
            left: 656px; position: absolute; top: 201px" Width="112px"></asp:TextBox>
        <asp:TextBox ID="vehiculoNoCarroceria" runat="server" Font-Size="Small" Height="16px" Style="z-index: 101;
            left: 792px; position: absolute; top: 201px" Width="112px"></asp:TextBox>
        <asp:TextBox ID="vehiculoChasis" runat="server" Font-Size="Small" Height="16px" Style="z-index: 101;
            left: 928px; position: absolute; top: 201px" Width="112px"></asp:TextBox>

        <asp:TextBox ID="fenomeno1" runat="server" Font-Size="Small" Height="80px" Style="z-index: 133;
            left: 16px; position: absolute; top: 250px" Width="416px" 
            BackColor="#80FFFF" AccessKey=" " TextMode="MultiLine"></asp:TextBox>

        <asp:TextBox ID="telefonoContacto" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 72px; position: absolute; top: 360px" Width="224px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="horaContacto1" runat="server" Font-Size="Small"
            Style="z-index: 133; left: 248px; position: absolute; top: 384px" Width="16px" Height="16px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="minutoContacto1" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 280px; position: absolute; top: 384px" Width="16px" Height="16px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="horaContacto2" runat="server" Font-Size="Small"
            Style="z-index: 133; left: 144px; position: absolute; top: 384px" Width="16px" Height="16px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="minutoContacto2" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 176px; position: absolute; top: 384px" Width="16px" Height="16px" BackColor="RoyalBlue"></asp:TextBox>

        <asp:TextBox ID="nombreWalkAround" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 312px; position: absolute; top: 360px" Width="120px" Height="16px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="fechaWalkAround" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 312px; position: absolute; top: 384px" Width="56px" Height="16px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="horaWalkAround" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 384px; position: absolute; top: 384px" Width="16px" Height="16px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="minutoWalkAround" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 416px; position: absolute; top: 384px" Width="16px" Height="16px" BackColor="RoyalBlue"></asp:TextBox>
        
        <asp:CheckBoxList ID="cbl_ConfirmaClt" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
            Style="z-index: 120; left: 170px; position: absolute; top: 408px" Width="8px">
            <asp:ListItem></asp:ListItem>
        </asp:CheckBoxList>

        <asp:TextBox ID="lecturaVeloRecibe" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 216px; position: absolute; top: 424px" Width="56px" Height="16px" BackColor="RoyalBlue"></asp:TextBox>

        <asp:CheckBoxList ID="cbl_Confirmar" runat="server" Font-Size="Small" Height="16px"
            RepeatDirection="Vertical" Style="z-index: 129; left: 120px; position: absolute;
            top: 456px" Width="192px">
            <asp:ListItem>Trabajo adicional</asp:ListItem>
            <asp:ListItem>Pertenencias</asp:ListItem>
            <asp:ListItem>Cubre Asiento</asp:ListItem>
            <asp:ListItem>Cubre volante/palanca</asp:ListItem>
            <asp:ListItem>Tapetes</asp:ListItem>
        </asp:CheckBoxList>






       <asp:RadioButtonList ID="rbl_DesdeCuando" runat="server" Font-Size="Small" Height="16px"
            RepeatDirection="Horizontal" Style="z-index: 131; left: 552px; position: absolute;
            top: 248px" Width="288px">
            <asp:ListItem>Recientemente</asp:ListItem>
            <asp:ListItem>Hace 1 semana</asp:ListItem>
            <asp:ListItem>Otro</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="txtDesdeCuando" runat="server" Font-Size="Small" Height="16px" Style="z-index: 111;
            left: 848px; position: absolute; top: 250px" Width="192px" BackColor="#80FFFF"></asp:TextBox>
        <asp:RadioButtonList ID="rbl_Frecuencia" runat="server" Font-Size="Small" Height="16px"
            RepeatDirection="Horizontal" Style="z-index: 130; left: 552px; position: absolute;
            top: 272px" Width="344px">
            <asp:ListItem>Siempre</asp:ListItem>
            <asp:ListItem>Ocasionalmente</asp:ListItem>
            <asp:ListItem>Solo 1 vez</asp:ListItem>
            <asp:ListItem>Otro</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="txtFrecuencia" runat="server" Font-Size="Small" Style="z-index: 110;
            left: 896px; position: absolute; top: 280px" Width="144px" BackColor="#80FFFF"></asp:TextBox>
        <asp:CheckBoxList ID="cbl_Lugar" runat="server" Font-Size="Small" Height="8px"
            RepeatDirection="Horizontal" Style="z-index: 129; left: 552px; position: absolute;
            top: 304px" Width="336px">
            <asp:ListItem>Calle</asp:ListItem>
            <asp:ListItem>Carretera</asp:ListItem>
            <asp:ListItem>Subida</asp:ListItem>
            <asp:ListItem>Bajada</asp:ListItem>
            <asp:ListItem>Tr&#225;fico</asp:ListItem>
        </asp:CheckBoxList>
        <asp:RadioButtonList ID="rdl_LuzAdvierte" runat="server" Font-Size="Small" Height="32px"
            RepeatDirection="Horizontal" Style="z-index: 128; left: 552px; position: absolute;
            top: 328px" Width="336px">
            <asp:ListItem>Prendida</asp:ListItem>
            <asp:ListItem>Parpadeando</asp:ListItem>
            <asp:ListItem>Parpadeo multiple</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="txtLuzAdvierte" runat="server" Font-Size="Small" Style="z-index: 109;
            left: 896px; position: absolute; top: 336px" Width="144px" BackColor="#80FFFF"></asp:TextBox>
        <asp:RadioButtonList ID="rbl_Condicion" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
            Style="z-index: 127; left: 552px; position: absolute; top: 368px" Width="480px">
            <asp:ListItem>Arranque</asp:ListItem>
            <asp:ListItem>Parado</asp:ListItem>
            <asp:ListItem>V K</asp:ListItem>
            <asp:ListItem>V no K</asp:ListItem>
            <asp:ListItem>Acelerando</asp:ListItem>
            <asp:ListItem>Desacelerando</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="Label17" runat="server" BackColor="White" Font-Bold="False" Font-Size="Small"
            Style="z-index: 123; left: 560px; position: absolute; top: 400px" Text="Velocímetro"
            Width="80px"></asp:Label>
        <asp:TextBox ID="txtVelocimetro" runat="server" Height="16px" Style="z-index: 121; left: 648px;
            position: absolute; top: 400px" Width="56px" BackColor="#80FFFF"></asp:TextBox>
        <asp:Label ID="Label19" runat="server" BackColor="White" Font-Bold="False" Font-Size="Small"
            Style="z-index: 125; left: 720px; position: absolute; top: 400px" Text="km/hr"
            Width="32px"></asp:Label>
        <asp:Label ID="Label18" runat="server" BackColor="White" Font-Bold="False" Font-Size="Small"
            Style="z-index: 124; left: 856px; position: absolute; top: 400px" Text="Tacometro"
            Width="80px"></asp:Label>
        <asp:TextBox ID="txtTacometro" runat="server" Height="16px" Style="z-index: 122; left: 944px;
            position: absolute; top: 400px" Width="56px" BackColor="#80FFFF"></asp:TextBox>
        <asp:Label ID="Label20" runat="server" BackColor="White" Font-Bold="False" Font-Size="Small"
            Style="z-index: 126; left: 1016px; position: absolute; top: 400px" Text="rpm"
            Width="32px"></asp:Label>
        <asp:CheckBoxList ID="cbl_Condicion" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
            Style="z-index: 120; left: 552px; position: absolute; top: 424px" Width="496px">
            <asp:ListItem>Rebasando</asp:ListItem>
            <asp:ListItem>Cambiando de marcha</asp:ListItem>
            <asp:ListItem>Retrocediendo</asp:ListItem>
            <asp:ListItem>Frenando</asp:ListItem>
        </asp:CheckBoxList>
        <asp:Label ID="Label21" runat="server" BackColor="White" Font-Bold="False" Font-Size="Small"
            Style="z-index: 112; left: 560px; position: absolute; top: 464px" Text="No. personas"
            Width="72px"></asp:Label>
        <asp:TextBox ID="txtNoPersonas" runat="server" Style="z-index: 118; left: 640px; position: absolute;
            top: 464px" Width="32px" BackColor="#80FFFF"></asp:TextBox>
        <asp:Label ID="Label28" runat="server" BackColor="White" Font-Bold="False" Font-Size="Small"
            Style="z-index: 113; left: 688px; position: absolute; top: 464px" Text="Carga vehículo"
            Width="88px"></asp:Label>
        <asp:TextBox ID="txtCargaVehiculo" runat="server" Style="z-index: 119; left: 784px; position: absolute;
            top: 464px" Width="56px" BackColor="#80FFFF"></asp:TextBox>
        <asp:Label ID="Label29" runat="server" BackColor="White" Font-Bold="False" Font-Size="Small"
            Style="z-index: 114; left: 848px; position: absolute; top: 464px" Text="kg" Width="24px"></asp:Label>
        <asp:Label ID="Label36" runat="server" BackColor="White" Font-Bold="False" Font-Size="Small"
            Style="z-index: 116; left: 880px; position: absolute; top: 464px" Text="Carga  remolque"
            Width="88px"></asp:Label>
        <asp:TextBox ID="txtCargaRemolque" runat="server" Height="16px" Style="z-index: 115; left: 968px;
            position: absolute; top: 464px" Width="56px" BackColor="#80FFFF"></asp:TextBox>
        <asp:Label ID="Label37" runat="server" BackColor="White" Font-Bold="False" Font-Size="Small"
            Style="z-index: 117; left: 1032px; position: absolute; top: 464px" Text="kg"
            Width="16px"></asp:Label>
        <asp:RadioButtonList ID="rbl_Superficie" runat="server" Font-Size="Small" Height="16px"
            RepeatDirection="Horizontal" Style="z-index: 106; left: 552px; position: absolute;
            top: 488px" Width="344px">
            <asp:ListItem>Plana</asp:ListItem>
            <asp:ListItem>Desigual</asp:ListItem>
            <asp:ListItem>Aspero</asp:ListItem>
            <asp:ListItem>Otro</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="txtSuperficie" runat="server" Font-Size="Small" Style="z-index: 108;
            left: 896px; position: absolute; top: 492px" Width="144px" BackColor="#80FFFF"></asp:TextBox>
        <asp:RadioButtonList ID="rbl_Tiempo" runat="server" Font-Size="Small" Height="16px"
            RepeatDirection="Horizontal" Style="z-index: 105; left: 552px; position: absolute;
            top: 520px" Width="408px">
            <asp:ListItem>Despejado</asp:ListItem>
            <asp:ListItem>Nublado</asp:ListItem>
            <asp:ListItem>Lluvia</asp:ListItem>
            <asp:ListItem>Nieve</asp:ListItem>
            <asp:ListItem>Temperatura externa</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="txtTemperaturaExterna" runat="server" Font-Size="Small" Style="z-index: 107;
            left: 960px; position: absolute; top: 520px" Width="56px" BackColor="#80FFFF"></asp:TextBox>
        <asp:Label ID="Label41" runat="server" BackColor="White" Font-Bold="False" Style="z-index: 102;
            left: 1032px; position: absolute; top: 520px" Text="·c" Width="16px"></asp:Label>
        <asp:RadioButtonList ID="rbl_AC" runat="server" Font-Size="Small" Height="24px"
            RepeatDirection="Horizontal" Style="z-index: 104; left: 552px; position: absolute;
            top: 544px" Width="408px">
            <asp:ListItem>Flujo aire</asp:ListItem>
            <asp:ListItem>Recirculaci&#243;n</asp:ListItem>
            <asp:ListItem>Velocidad ventilaci&#243;n</asp:ListItem>
            <asp:ListItem>Temperatura</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="txtAC_Temperatura" runat="server" Font-Size="Small" Style="z-index: 100;
            left: 960px; position: absolute; top: 550px" Width="56px" Height="16px" BackColor="#80FFFF"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" BackColor="White" Font-Bold="False" Style="z-index: 103;
            left: 1032px; position: absolute; top: 552px" Text="·c" Width="8px"></asp:Label>


        <asp:TextBox ID="detalleTrabajo1" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 134px; position: absolute; top: 614px" Width="712px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="detalleTrabajo2" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 16px; position: absolute; top: 640px" Width="832px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="detalleTrabajo3" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 16px; position: absolute; top: 670px" Width="832px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="detalleTrabajo4" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 16px; position: absolute; top: 700px" Width="832px" BackColor="#FFFF80"></asp:TextBox>

        <asp:TextBox ID="nombreDiag" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 936px; position: absolute; top: 584px" Width="104px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="fechaDiag" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 880px; position: absolute; top: 627px" Width="56px" Height="16px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="horaDiag" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 992px; position: absolute; top: 627px" Width="16px" Height="16px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="minutoDiag" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 1024px; position: absolute; top: 627px" Width="16px" Height="16px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="noLLave" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 880px; position: absolute; top: 664px" Width="56px" Height="16px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="noBahia" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 1008px; position: absolute; top: 664px" Width="16px" Height="16px" BackColor="#FFFF80"></asp:TextBox>
        <asp:CheckBoxList ID="cbl_ReparacionDiag" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
            Style="z-index: 120; left: 960px; position: absolute; top: 704px" Width="8px" BackColor="#FFFF80">
            <asp:ListItem></asp:ListItem>
        </asp:CheckBoxList>


        <asp:RadioButtonList ID="rbl_Resultado" runat="server" Font-Size="Small"
            RepeatDirection="Horizontal" Style="z-index: 106; left: 24px; position: absolute;
            top: 739px; height: 21px;" Width="112px">
            <asp:ListItem>Descubierto</asp:ListItem>
            <asp:ListItem>Predicci&#243;n</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="motivoResulta" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 248px; position: absolute; top: 736px" Width="96px" Height="16px" BackColor="#FFFF80"></asp:TextBox>
        <asp:CheckBoxList ID="cbl_Seguir" runat="server" Font-Size="X-Small" RepeatDirection="Horizontal"
            
            Style="z-index: 120; left: 360px; position: absolute; top: 735px; width: 84px;">
            <asp:ListItem>Seguimiento</asp:ListItem>
        </asp:CheckBoxList>


        <asp:TextBox ID="causa1" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 24px; position: absolute; top: 780px" Width="408px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="causa2" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 24px; position: absolute; top: 806px" Width="408px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="causa3" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 24px; position: absolute; top: 834px" Width="408px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="causa4" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 24px; position: absolute; top: 862px" Width="408px" BackColor="#FFFF80"></asp:TextBox>

        <asp:TextBox ID="DTC1" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 488px; position: absolute; top: 780px" Width="216px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="DTC2" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 488px; position: absolute; top: 806px" Width="216px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="DTC3" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 488px; position: absolute; top: 834px" Width="216px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="DTC4" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 488px; position: absolute; top: 862px" Width="216px" BackColor="#FFFF80"></asp:TextBox>

        <asp:DropDownList ID="ddl_Status1" runat="server" Style="z-index: 102; left: 784px;
            position: absolute; top: 780px" Width="40px" BackColor="#FFFF80">
            <asp:ListItem Value="0">C</asp:ListItem>
            <asp:ListItem Value="1">P</asp:ListItem>
            <asp:ListItem Value="2">H</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddl_Status2" runat="server" Style="z-index: 102; left: 784px;
            position: absolute; top: 806px" Width="40px" BackColor="#FFFF80">
            <asp:ListItem Value="0">C</asp:ListItem>
            <asp:ListItem Value="1">P</asp:ListItem>
            <asp:ListItem Value="2">H</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddl_Status3" runat="server" Style="z-index: 102; left: 784px;
            position: absolute; top: 834px" Width="40px" BackColor="#FFFF80">
            <asp:ListItem Value="0">C</asp:ListItem>
            <asp:ListItem Value="1">P</asp:ListItem>
            <asp:ListItem Value="2">H</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddl_Status4" runat="server" Style="z-index: 102; left: 784px;
            position: absolute; top: 862px" Width="40px" BackColor="#FFFF80">
            <asp:ListItem Value="0">C</asp:ListItem>
            <asp:ListItem Value="1">P</asp:ListItem>
            <asp:ListItem Value="2">H</asp:ListItem>
        </asp:DropDownList>

        <asp:DropDownList ID="ddl_Datos1" runat="server" Style="z-index: 102; left: 920px;
            position: absolute; top: 780px" Width="100px" BackColor="#FFFF80">
            <asp:ListItem Value="0">Disponible</asp:ListItem>
            <asp:ListItem Value="1">No disponible</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddl_Datos2" runat="server" Style="z-index: 102; left: 920px;
            position: absolute; top: 806px" Width="100px" BackColor="#FFFF80">
            <asp:ListItem Value="0">Disponible</asp:ListItem>
            <asp:ListItem Value="1">No disponible</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddl_Datos3" runat="server" Style="z-index: 102; left: 920px;
            position: absolute; top: 834px" Width="100px" BackColor="#FFFF80">
            <asp:ListItem Value="0">Disponible</asp:ListItem>
            <asp:ListItem Value="1">No disponible</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddl_Datos4" runat="server" Style="z-index: 102; left: 920px;
            position: absolute; top: 862px" Width="100px" BackColor="#FFFF80">
            <asp:ListItem Value="0">Disponible</asp:ListItem>
            <asp:ListItem Value="1">No disponible</asp:ListItem>
        </asp:DropDownList>


        <asp:CheckBoxList ID="cbl_InstGrtia" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
            Style="z-index: 120; left: 368px; position: absolute; top: 883px" Width="8px">
            <asp:ListItem>Garantía</asp:ListItem>
        </asp:CheckBoxList>
        <asp:TextBox ID="instruccion1" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 32px; position: absolute; top: 920px" Width="400px"></asp:TextBox>
        <asp:TextBox ID="instruccion2" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 32px; position: absolute; top: 952px" Width="400px"></asp:TextBox>
        <asp:TextBox ID="instruccion3" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 32px; position: absolute; top: 979px" Width="400px"></asp:TextBox>
        <asp:TextBox ID="instruccion4" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 32px; position: absolute; top: 1008px" Width="400px"></asp:TextBox>

        <asp:TextBox ID="fechaIniInst1" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 464px; position: absolute; top: 920px" Width="56px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="fechaIniInst2" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 464px; position: absolute; top: 952px" Width="56px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="fechaIniInst3" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 464px; position: absolute; top: 979px" Width="56px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="fechaIniInst4" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 464px; position: absolute; top: 1008px" Width="56px" Height="16px"></asp:TextBox>

        <asp:TextBox ID="horaIniInst1" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 544px; position: absolute; top: 920px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoIniInst1" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 574px; position: absolute; top: 920px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="horaIniInst2" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 544px; position: absolute; top: 952px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoIniInst2" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 574px; position: absolute; top: 952px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="horaIniInst3" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 544px; position: absolute; top: 979px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoIniInst3" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 574px; position: absolute; top: 979px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="horaIniInst4" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 544px; position: absolute; top: 1008px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoIniInst4" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 574px; position: absolute; top: 1008px" Width="16px" Height="16px"></asp:TextBox>

        <asp:TextBox ID="fechaFinInst1" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 608px; position: absolute; top: 920px" Width="56px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="fechaFinInst2" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 608px; position: absolute; top: 952px" Width="56px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="fechaFinInst3" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 608px; position: absolute; top: 979px" Width="56px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="fechaFinInst4" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 608px; position: absolute; top: 1008px" Width="56px" Height="16px"></asp:TextBox>

        <asp:TextBox ID="horaFinInst1" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 680px; position: absolute; top: 920px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoFinInst1" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 706px; position: absolute; top: 920px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="horaFinInst2" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 680px; position: absolute; top: 952px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoFinInst2" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 706px; position: absolute; top: 952px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="horaFinInst3" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 680px; position: absolute; top: 979px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoFinInst3" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 706px; position: absolute; top: 979px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="horaFinInst4" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 680px; position: absolute; top: 1008px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoFinInst4" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 706px; position: absolute; top: 1008px" Width="16px" Height="16px"></asp:TextBox>

        <asp:TextBox ID="horaWork1" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 758px; position: absolute; top: 920px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="horaWork2" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 758px; position: absolute; top: 952px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="horaWork3" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 758px; position: absolute; top: 979px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="horaWork4" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 758px; position: absolute; top: 1008px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoWork1" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 785px; position: absolute; top: 920px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoWork2" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 785px; position: absolute; top: 952px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoWork3" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 785px; position: absolute; top: 979px" Width="16px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="minutoWork4" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 785px; position: absolute; top: 1008px" Width="16px" Height="16px"></asp:TextBox>

        <asp:CheckBoxList ID="cbl_DTR1" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
            Style="z-index: 120; left: 835px; position: absolute; top: 920px" Width="8px">
            <asp:ListItem></asp:ListItem>
        </asp:CheckBoxList>
        <asp:CheckBoxList ID="cbl_DTR2" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
            Style="z-index: 120; left: 835px; position: absolute; top: 952px" Width="8px">
            <asp:ListItem></asp:ListItem>
        </asp:CheckBoxList>
        <asp:CheckBoxList ID="cbl_DTR3" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
            Style="z-index: 120; left: 835px; position: absolute; top: 979px" Width="8px">
            <asp:ListItem></asp:ListItem>
        </asp:CheckBoxList>
        <asp:CheckBoxList ID="cbl_DTR4" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
            Style="z-index: 120; left: 835px; position: absolute; top: 1008px" Width="8px">
            <asp:ListItem></asp:ListItem>
        </asp:CheckBoxList>


        <asp:TextBox ID="instTec1" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 880px; position: absolute; top: 920px" Width="72px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="instCnf1" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 968px; position: absolute; top: 920px" Width="72px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="instTec2" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 880px; position: absolute; top: 952px" Width="72px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="instCnf2" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 968px; position: absolute; top: 952px" Width="72px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="instTec3" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 880px; position: absolute; top: 979px" Width="72px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="instCnf3" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 968px; position: absolute; top: 979px" Width="72px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="instTec4" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 880px; position: absolute; top: 1008px" Width="72px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="instCnf4" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 968px; position: absolute; top: 1008px" Width="72px" Height="16px"></asp:TextBox>


        <asp:TextBox ID="tmexDestino" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 104px; position: absolute; top: 1072px" Width="328px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="tmexRespble" runat="server" Font-Size="Small" Height="16px" Style="z-index: 133;
            left: 104px; position: absolute; top: 1128px" Width="328px" BackColor="#FFFF80"></asp:TextBox>

       <asp:RadioButtonList ID="rbl_Tmex" runat="server" Font-Size="Small" Height="1px"
            RepeatDirection="Horizontal" Style="z-index: 131; left: 72px; position: absolute;
            top: 1176px" Width="160px">
            <asp:ListItem>En proceso</asp:ListItem>
            <asp:ListItem>Planeado</asp:ListItem>
        </asp:RadioButtonList>


        <asp:TextBox ID="fechaTmex" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 296px; position: absolute; top: 1176px" Width="48px" Height="16px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="horaTmex" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 386px; position: absolute; top: 1176px" Width="16px" Height="16px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="minutoTmex" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 416px; position: absolute; top: 1176px" Width="16px" Height="16px" BackColor="#FFFF80"></asp:TextBox>

        <asp:CheckBoxList ID="cbl_StatusTmex" runat="server" Font-Size="Small" Height="1px"
            RepeatDirection="Vertical" Style="z-index: 129; left: 576px; position: absolute;
            top: 1036px" Width="192px">
            <asp:ListItem>Recurrencia</asp:ListItem>
            <asp:ListItem>Dificultad identificar causa</asp:ListItem>
            <asp:ListItem>Reparaci&#243;n dificil</asp:ListItem>
        </asp:CheckBoxList>

        <asp:CheckBoxList ID="cbl_SolicitaTmex" runat="server" Font-Size="Small" Height="1px"
            RepeatDirection="Vertical" Style="z-index: 129; left: 576px; position: absolute;
            top: 1112px" Width="192px">
            <asp:ListItem>Verificación vehículo</asp:ListItem>
            <asp:ListItem>Historial servicio</asp:ListItem>
            <asp:ListItem>Asistencia en reparación</asp:ListItem>
            <asp:ListItem>Otro</asp:ListItem>
        </asp:CheckBoxList>



        <asp:TextBox ID="fechaSolTmex" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 976px; position: absolute; top: 1072px" Width="48px" Height="16px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="horaSolTmex" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 976px; position: absolute; top: 1104px" Width="16px" Height="16px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="minutoSolTmex" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 1008px; position: absolute; top: 1104px" Width="16px" Height="16px" BackColor="#FFFF80"></asp:TextBox>

        <asp:TextBox ID="nombreTmex" runat="server" Font-Size="Small" Style="z-index: 133;
            left: 880px; position: absolute; top: 1168px" Width="160px" Height="16px" BackColor="#FFFF80"></asp:TextBox>



        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/CuestDiag_9.PNG" Style="z-index: 99;
            left: 0px; position: absolute; top: 0px" />


        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/Print_32x32.png"
        Style="z-index: 102; left: 1120px; position: absolute; top: 224px" />

        <input id="Button1" onclick="backtopage()" style="z-index: 101; left: 1117px; position: absolute; top: 72px; background-image: url('img/Next_32x32.png'); width: 33px; height: 34px;"
        type="button" runat="server" /><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/aceptar.png"
        Style="z-index: 102; left: 1120px; position: absolute; top: 128px" />
        <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="Eliminar" ImageUrl="~/img/Delete_32x32.png"
            Style="z-index: 144; left: 1120px; width: 32px; position: absolute; top: 168px;
            height: 32px" />


    </asp:Panel>
    
    
    </form>
    
    
    
    <asp:SqlDataSource ID="SqlDataSource40" runat="server" ConnectionString="<%$ ConnectionStrings:tbCS %>"
        SelectCommand="SELECT id, idCita, USUARIO, FECHA, ID_CLIENTE, VIN, fechaRecepcion, horaRecepcion, minutoRecepcion, Cliente_trae, Concesionario_recoge, VehiculoCortesia, fechaEntrega, horaEntrega, minutoEntrega, Cliente_retira, Concesionario_entrega, nombreCliente, direccionCliente, telefonoCliente, fechaDiagnostico, nombreAsesor, noDiagnostico, noOrden, fechaConfirmacion, horaConfirmacion, minutoConfirmacion, nombreConfirmacion, Conducido_Propietario, Conducido_Familia, Conducido_Otro, txtVehiculoConducido, lecturaVelocimetroCita, vehiculoPlacas, DOFU, vehiculoNombreModelo, vehiculoModelo, vehiculoNoCarroceria, vehiculoChasis, fenomeno1, fenomeno2, fenomeno3, telefonoContacto, horaContacto1, minutoContacto1, horaContacto2, minutoContacto2, nombreWalkAround, fechaWalkAround, horaWalkAround, minutoWalkAround, Confirma_Clt, lecturaVeloRecibe, Confirma_Trabajo_adicional, Confirma_Pertenencias, Confirma_Cubre_Asiento, Confirma_Cubre_volante_palanca, Confirma_Tapetes, DesdeCuando_Recientemente, DesdeCuando_Hace_1_semana, DesdeCuando_Otro, txtDesdeCuando, Frecuencia_Siempre, Frecuencia_Ocasionalmente, Frecuencia_Solo_1_vez, Frecuencia_Otro, txtFrecuencia, Lugar_Calle, Lugar_Carretera, Lugar_Subida, Lugar_Bajada, Lugar_Trafico, LuzAdvierte_Prendida, LuzAdvierte_Parpadeando, LuzAdvierte_Parpadeo_multiple, txtLuzAdvierte, Condicion_Arranque, Condicion_Parado, Condicion_V_K, Condicion_V_no_K, Condicion_Acelerando, Condicion_Desacelerando, txtVelocimetro, txtTacometro, Condicion_Rebasando, Condicion_Cambiando, Condicion_Retrocediendo, Condicion_Frenando, txtNoPersonas, txtCargaVehiculo, txtCargaRemolque, Superficie_Plana, Superficie_Desigual, Superficie_Aspero, Superficie_Otro, txtSuperficie, Tiempo_Despejado, Tiempo_Nublado, Tiempo_Lluvia, Tiempo_Nieve, Tiempo_Temperatura_externa, txtTemperaturaExterna, AC_Flujo_aire, AC_Recirculacion, AC_Velocidad_ventilacion, AC_Temperatura, txtAC_Temperatura, detalleTrabajo1, detalleTrabajo2, detalleTrabajo3, detalleTrabajo4, nombreDiag, fechaDiag, horaDiag, minutoDiag, noLLave, noBahia, Resultado_Descubierto, Resultado_Prediccion, motivoResulta, Seguimiento, causa1, causa2, causa3, causa4, DTC1, DTC2, DTC3, DTC4, Status1_0, Status2_0, Status3_0, Status4_0, Datos1_0, Datos2_0, Datos3_0, Datos4_0, Garantia, instruccion1, instruccion2, instruccion3, instruccion4, fechaIniInst1, fechaIniInst2, fechaIniInst3, fechaIniInst4, horaIniInst1, minutoIniInst1, horaIniInst2, minutoIniInst2, horaIniInst3, minutoIniInst3, horaIniInst4, minutoIniInst4, fechaFinInst1, fechaFinInst2, fechaFinInst3, fechaFinInst4, horaFinInst1, minutoFinInst1, horaFinInst2, minutoFinInst2, horaFinInst3, minutoFinInst3, horaFinInst4, minutoFinInst4, horaWork1, horaWork2, horaWork3, horaWork4, minutoWork1, minutoWork2, minutoWork3, minutoWork4, DTR1, DTR2, DTR3, DTR4, instTec1, instCnf1, instTec2, instCnf2, instTec3, instCnf3, instTec4, instCnf4, tmexDestino, tmexRespble, Tmex_En_proceso, Tmex_Planeado, fechaTmex, horaTmex, minutoTmex, StatusTmex_Recurrencia, StatusTmex_Dificultad_identificar_causa, StatusTmex_Reparacion_dificil, SolicitaTmex_Verificación_vehiculo, SolicitaTmex_Historial_servicio, SolicitaTmex_Asistencia_en_reparacion, SolicitaTmex_Otro, fechaSolTmex, horaSolTmex, minutoSolTmex, nombreTmex FROM TYT_KDW_FORMATO_DIAGNOSTICO"
        InsertCommand="INSERT INTO TYT_KDW_FORMATO_DIAGNOSTICO(idCita, USUARIO, FECHA, ID_CLIENTE, VIN, fechaRecepcion, horaRecepcion, minutoRecepcion, Cliente_trae, Concesionario_recoge, VehiculoCortesia, fechaEntrega, horaEntrega, minutoEntrega, Cliente_retira, Concesionario_entrega, nombreCliente, direccionCliente, telefonoCliente, fechaDiagnostico, nombreAsesor, noDiagnostico, noOrden, fechaConfirmacion, horaConfirmacion, minutoConfirmacion, nombreConfirmacion, Conducido_Propietario, Conducido_Familia, Conducido_Otro, txtVehiculoConducido, lecturaVelocimetroCita, vehiculoPlacas, DOFU, vehiculoNombreModelo, vehiculoModelo, vehiculoNoCarroceria, vehiculoChasis, fenomeno1, fenomeno2, fenomeno3, telefonoContacto, horaContacto1, minutoContacto1, horaContacto2, minutoContacto2, nombreWalkAround, fechaWalkAround, horaWalkAround, minutoWalkAround, Confirma_Clt, lecturaVeloRecibe, Confirma_Trabajo_adicional, Confirma_Pertenencias, Confirma_Cubre_Asiento, Confirma_Cubre_volante_palanca, Confirma_Tapetes, DesdeCuando_Recientemente, DesdeCuando_Hace_1_semana, DesdeCuando_Otro, txtDesdeCuando, Frecuencia_Siempre, Frecuencia_Ocasionalmente, Frecuencia_Solo_1_vez, Frecuencia_Otro, txtFrecuencia, Lugar_Calle, Lugar_Carretera, Lugar_Subida, Lugar_Bajada, Lugar_Trafico, LuzAdvierte_Prendida, LuzAdvierte_Parpadeando, LuzAdvierte_Parpadeo_multiple, txtLuzAdvierte, Condicion_Arranque, Condicion_Parado, Condicion_V_K, Condicion_V_no_K, Condicion_Acelerando, Condicion_Desacelerando, txtVelocimetro, txtTacometro, Condicion_Rebasando, Condicion_Cambiando, Condicion_Retrocediendo, Condicion_Frenando, txtNoPersonas, txtCargaVehiculo, txtCargaRemolque, Superficie_Plana, Superficie_Desigual, Superficie_Aspero, Superficie_Otro, txtSuperficie, Tiempo_Despejado, Tiempo_Nublado, Tiempo_Lluvia, Tiempo_Nieve, Tiempo_Temperatura_externa, txtTemperaturaExterna, AC_Flujo_aire, AC_Recirculacion, AC_Velocidad_ventilacion, AC_Temperatura, txtAC_Temperatura, detalleTrabajo1, detalleTrabajo2, detalleTrabajo3, detalleTrabajo4, nombreDiag, fechaDiag, horaDiag, minutoDiag, noLLave, noBahia, Resultado_Descubierto, Resultado_Prediccion, motivoResulta, Seguimiento, causa1, causa2, causa3, causa4, DTC1, DTC2, DTC3, DTC4, Status1_0, Status2_0, Status3_0, Status4_0, Datos1_0, Datos2_0, Datos3_0, Datos4_0, Garantia, instruccion1, instruccion2, instruccion3, instruccion4, fechaIniInst1, fechaIniInst2, fechaIniInst3, fechaIniInst4, horaIniInst1, minutoIniInst1, horaIniInst2, minutoIniInst2, horaIniInst3, minutoIniInst3, horaIniInst4, minutoIniInst4, fechaFinInst1, fechaFinInst2, fechaFinInst3, fechaFinInst4, horaFinInst1, minutoFinInst1, horaFinInst2, minutoFinInst2, horaFinInst3, minutoFinInst3, horaFinInst4, minutoFinInst4, horaWork1, horaWork2, horaWork3, horaWork4, minutoWork1, minutoWork2, minutoWork3, minutoWork4, DTR1, DTR2, DTR3, DTR4, instTec1, instCnf1, instTec2, instCnf2, instTec3, instCnf3, instTec4, instCnf4, tmexDestino, tmexRespble, Tmex_En_proceso, Tmex_Planeado, fechaTmex, horaTmex, minutoTmex, StatusTmex_Recurrencia, StatusTmex_Dificultad_identificar_causa, StatusTmex_Reparacion_dificil, SolicitaTmex_Verificación_vehiculo, SolicitaTmex_Historial_servicio, SolicitaTmex_Asistencia_en_reparacion, SolicitaTmex_Otro, fechaSolTmex, horaSolTmex, minutoSolTmex, nombreTmex) VALUES (@idCita, @USUARIO, @FECHA, @ID_CLIENTE, @VIN, @fechaRecepcion, @horaRecepcion, @minutoRecepcion, @Cliente_trae, @Concesionario_recoge, @VehiculoCortesia, @fechaEntrega, @horaEntrega, @minutoEntrega, @Cliente_retira, @Concesionario_entrega, @nombreCliente, @direccionCliente, @telefonoCliente, @fechaDiagnostico, @nombreAsesor, @noDiagnostico, @noOrden, @fechaConfirmacion, @horaConfirmacion, @minutoConfirmacion, @nombreConfirmacion, @Conducido_Propietario, @Conducido_Familia, @Conducido_Otro, @txtVehiculoConducido, @lecturaVelocimetroCita, @vehiculoPlacas, @DOFU, @vehiculoNombreModelo, @vehiculoModelo, @vehiculoNoCarroceria, @vehiculoChasis, @fenomeno1, @fenomeno2, @fenomeno3, @telefonoContacto, @horaContacto1, @minutoContacto1, @horaContacto2, @minutoContacto2, @nombreWalkAround, @fechaWalkAround, @horaWalkAround, @minutoWalkAround, @Confirma_Clt, @lecturaVeloRecibe, @Confirma_Trabajo_adicional, @Confirma_Pertenencias, @Confirma_Cubre_Asiento, @Confirma_Cubre_volante_palanca, @Confirma_Tapetes, @DesdeCuando_Recientemente, @DesdeCuando_Hace_1_semana, @DesdeCuando_Otro, @txtDesdeCuando, @Frecuencia_Siempre, @Frecuencia_Ocasionalmente, @Frecuencia_Solo_1_vez, @Frecuencia_Otro, @txtFrecuencia, @Lugar_Calle, @Lugar_Carretera, @Lugar_Subida, @Lugar_Bajada, @Lugar_Trafico, @LuzAdvierte_Prendida, @LuzAdvierte_Parpadeando, @LuzAdvierte_Parpadeo_multiple, @txtLuzAdvierte, @Condicion_Arranque, @Condicion_Parado, @Condicion_V_K, @Condicion_V_no_K, @Condicion_Acelerando, @Condicion_Desacelerando, @txtVelocimetro, @txtTacometro, @Condicion_Rebasando, @Condicion_Cambiando, @Condicion_Retrocediendo, @Condicion_Frenando, @txtNoPersonas, @txtCargaVehiculo, @txtCargaRemolque, @Superficie_Plana, @Superficie_Desigual, @Superficie_Aspero, @Superficie_Otro, @txtSuperficie, @Tiempo_Despejado, @Tiempo_Nublado, @Tiempo_Lluvia, @Tiempo_Nieve, @Tiempo_Temperatura_externa, @txtTemperaturaExterna, @AC_Flujo_aire, @AC_Recirculacion, @AC_Velocidad_ventilacion, @AC_Temperatura, @txtAC_Temperatura, @detalleTrabajo1, @detalleTrabajo2, @detalleTrabajo3, @detalleTrabajo4, @nombreDiag, @fechaDiag, @horaDiag, @minutoDiag, @noLLave, @noBahia, @Resultado_Descubierto, @Resultado_Prediccion, @motivoResulta, @Seguimiento, @causa1, @causa2, @causa3, @causa4, @DTC1, @DTC2, @DTC3, @DTC4, @Status1_0, @Status2_0, @Status3_0, @Status4_0, @Datos1_0, @Datos2_0, @Datos3_0, @Datos4_0, @Garantia, @instruccion1, @instruccion2, @instruccion3, @instruccion4, @fechaIniInst1, @fechaIniInst2, @fechaIniInst3, @fechaIniInst4, @horaIniInst1, @minutoIniInst1, @horaIniInst2, @minutoIniInst2, @horaIniInst3, @minutoIniInst3, @horaIniInst4, @minutoIniInst4, @fechaFinInst1, @fechaFinInst2, @fechaFinInst3, @fechaFinInst4, @horaFinInst1, @minutoFinInst1, @horaFinInst2, @minutoFinInst2, @horaFinInst3, @minutoFinInst3, @horaFinInst4, @minutoFinInst4, @horaWork1, @horaWork2, @horaWork3, @horaWork4, @minutoWork1, @minutoWork2, @minutoWork3, @minutoWork4, @DTR1, @DTR2, @DTR3, @DTR4, @instTec1, @instCnf1, @instTec2, @instCnf2, @instTec3, @instCnf3, @instTec4, @instCnf4, @tmexDestino, @tmexRespble, @Tmex_En_proceso, @Tmex_Planeado, @fechaTmex, @horaTmex, @minutoTmex, @StatusTmex_Recurrencia, @StatusTmex_Dificultad_identificar_causa, @StatusTmex_Reparacion_dificil, @SolicitaTmex_Verificación_vehiculo, @SolicitaTmex_Historial_servicio, @SolicitaTmex_Asistencia_en_reparacion, @SolicitaTmex_Otro, @fechaSolTmex, @horaSolTmex, @minutoSolTmex, @nombreTmex)"
        UpdateCommand="UPDATE TYT_KDW_FORMATO_DIAGNOSTICO SET idCita = @idCita, USUARIO = @USUARIO, FECHA = @FECHA, ID_CLIENTE = @ID_CLIENTE, VIN = @VIN, fechaRecepcion=@fechaRecepcion,horaRecepcion=@horaRecepcion,minutoRecepcion=@minutoRecepcion,Cliente_trae=@Cliente_trae,Concesionario_recoge=@Concesionario_recoge,VehiculoCortesia=@VehiculoCortesia,fechaEntrega=@fechaEntrega,horaEntrega=@horaEntrega,minutoEntrega=@minutoEntrega,Cliente_retira=@Cliente_retira,Concesionario_entrega=@Concesionario_entrega,nombreCliente=@nombreCliente,direccionCliente=@direccionCliente,telefonoCliente=@telefonoCliente,fechaDiagnostico=@fechaDiagnostico,nombreAsesor=@nombreAsesor,noDiagnostico=@noDiagnostico,noOrden=@noOrden,fechaConfirmacion=@fechaConfirmacion,horaConfirmacion=@horaConfirmacion,minutoConfirmacion=@minutoConfirmacion,nombreConfirmacion=@nombreConfirmacion,Conducido_Propietario=@Conducido_Propietario,Conducido_Familia=@Conducido_Familia,Conducido_Otro=@Conducido_Otro,txtVehiculoConducido=@txtVehiculoConducido,lecturaVelocimetroCita=@lecturaVelocimetroCita,vehiculoPlacas=@vehiculoPlacas,DOFU=@DOFU,vehiculoNombreModelo=@vehiculoNombreModelo,vehiculoModelo=@vehiculoModelo,vehiculoNoCarroceria=@vehiculoNoCarroceria,vehiculoChasis=@vehiculoChasis,fenomeno1=@fenomeno1,fenomeno2=@fenomeno2,fenomeno3=@fenomeno3,telefonoContacto=@telefonoContacto,horaContacto1=@horaContacto1,minutoContacto1=@minutoContacto1,horaContacto2=@horaContacto2,minutoContacto2=@minutoContacto2,nombreWalkAround=@nombreWalkAround,fechaWalkAround=@fechaWalkAround,horaWalkAround=@horaWalkAround,minutoWalkAround=@minutoWalkAround,Confirma_Clt=@Confirma_Clt,lecturaVeloRecibe=@lecturaVeloRecibe,Confirma_Trabajo_adicional=@Confirma_Trabajo_adicional,Confirma_Pertenencias=@Confirma_Pertenencias,Confirma_Cubre_Asiento=@Confirma_Cubre_Asiento,Confirma_Cubre_volante_palanca=@Confirma_Cubre_volante_palanca,Confirma_Tapetes=@Confirma_Tapetes,DesdeCuando_Recientemente=@DesdeCuando_Recientemente,DesdeCuando_Hace_1_semana=@DesdeCuando_Hace_1_semana,DesdeCuando_Otro=@DesdeCuando_Otro,txtDesdeCuando=@txtDesdeCuando,Frecuencia_Siempre=@Frecuencia_Siempre,Frecuencia_Ocasionalmente=@Frecuencia_Ocasionalmente,Frecuencia_Solo_1_vez=@Frecuencia_Solo_1_vez,Frecuencia_Otro=@Frecuencia_Otro,txtFrecuencia=@txtFrecuencia,Lugar_Calle=@Lugar_Calle,Lugar_Carretera=@Lugar_Carretera,Lugar_Subida=@Lugar_Subida,Lugar_Bajada=@Lugar_Bajada,Lugar_Trafico=@Lugar_Trafico,LuzAdvierte_Prendida=@LuzAdvierte_Prendida,LuzAdvierte_Parpadeando=@LuzAdvierte_Parpadeando,LuzAdvierte_Parpadeo_multiple=@LuzAdvierte_Parpadeo_multiple,txtLuzAdvierte=@txtLuzAdvierte,Condicion_Arranque=@Condicion_Arranque,Condicion_Parado=@Condicion_Parado,Condicion_V_K=@Condicion_V_K,Condicion_V_no_K=@Condicion_V_no_K,Condicion_Acelerando=@Condicion_Acelerando,Condicion_Desacelerando=@Condicion_Desacelerando,txtVelocimetro=@txtVelocimetro,txtTacometro=@txtTacometro,Condicion_Rebasando=@Condicion_Rebasando,Condicion_Cambiando=@Condicion_Cambiando,Condicion_Retrocediendo=@Condicion_Retrocediendo,Condicion_Frenando=@Condicion_Frenando,txtNoPersonas=@txtNoPersonas,txtCargaVehiculo=@txtCargaVehiculo,txtCargaRemolque=@txtCargaRemolque,Superficie_Plana=@Superficie_Plana,Superficie_Desigual=@Superficie_Desigual,Superficie_Aspero=@Superficie_Aspero,Superficie_Otro=@Superficie_Otro,txtSuperficie=@txtSuperficie,Tiempo_Despejado=@Tiempo_Despejado,Tiempo_Nublado=@Tiempo_Nublado,Tiempo_Lluvia=@Tiempo_Lluvia,Tiempo_Nieve=@Tiempo_Nieve,Tiempo_Temperatura_externa=@Tiempo_Temperatura_externa,txtTemperaturaExterna=@txtTemperaturaExterna,AC_Flujo_aire=@AC_Flujo_aire,AC_Recirculacion=@AC_Recirculacion,AC_Velocidad_ventilacion=@AC_Velocidad_ventilacion,AC_Temperatura=@AC_Temperatura,txtAC_Temperatura=@txtAC_Temperatura,detalleTrabajo1=@detalleTrabajo1,detalleTrabajo2=@detalleTrabajo2,detalleTrabajo3=@detalleTrabajo3,detalleTrabajo4=@detalleTrabajo4,nombreDiag=@nombreDiag,fechaDiag=@fechaDiag,horaDiag=@horaDiag,minutoDiag=@minutoDiag,noLLave=@noLLave,noBahia=@noBahia,Resultado_Descubierto=@Resultado_Descubierto,Resultado_Prediccion=@Resultado_Prediccion,motivoResulta=@motivoResulta,Seguimiento=@Seguimiento,causa1=@causa1,causa2=@causa2,causa3=@causa3,causa4=@causa4,DTC1=@DTC1,DTC2=@DTC2,DTC3=@DTC3,DTC4=@DTC4,Status1_0=@Status1_0,Status2_0=@Status2_0,Status3_0=@Status3_0,Status4_0=@Status4_0,Datos1_0=@Datos1_0,Datos2_0=@Datos2_0,Datos3_0=@Datos3_0,Datos4_0=@Datos4_0,Garantia=@Garantia,instruccion1=@instruccion1,instruccion2=@instruccion2,instruccion3=@instruccion3,instruccion4=@instruccion4,fechaIniInst1=@fechaIniInst1,fechaIniInst2=@fechaIniInst2,fechaIniInst3=@fechaIniInst3,fechaIniInst4=@fechaIniInst4,horaIniInst1=@horaIniInst1,minutoIniInst1=@minutoIniInst1,horaIniInst2=@horaIniInst2,minutoIniInst2=@minutoIniInst2,horaIniInst3=@horaIniInst3,minutoIniInst3=@minutoIniInst3,horaIniInst4=@horaIniInst4,minutoIniInst4=@minutoIniInst4,fechaFinInst1=@fechaFinInst1,fechaFinInst2=@fechaFinInst2,fechaFinInst3=@fechaFinInst3,fechaFinInst4=@fechaFinInst4,horaFinInst1=@horaFinInst1,minutoFinInst1=@minutoFinInst1,horaFinInst2=@horaFinInst2,minutoFinInst2=@minutoFinInst2,horaFinInst3=@horaFinInst3,minutoFinInst3=@minutoFinInst3,horaFinInst4=@horaFinInst4,minutoFinInst4=@minutoFinInst4,horaWork1=@horaWork1,horaWork2=@horaWork2,horaWork3=@horaWork3,horaWork4=@horaWork4,minutoWork1=@minutoWork1,minutoWork2=@minutoWork2,minutoWork3=@minutoWork3,minutoWork4=@minutoWork4,DTR1=@DTR1,DTR2=@DTR2,DTR3=@DTR3,DTR4=@DTR4,instTec1=@instTec1,instCnf1=@instCnf1,instTec2=@instTec2,instCnf2=@instCnf2,instTec3=@instTec3,instCnf3=@instCnf3,instTec4=@instTec4,instCnf4=@instCnf4,tmexDestino=@tmexDestino,tmexRespble=@tmexRespble,Tmex_En_proceso=@Tmex_En_proceso,Tmex_Planeado=@Tmex_Planeado,fechaTmex=@fechaTmex,horaTmex=@horaTmex,minutoTmex=@minutoTmex,StatusTmex_Recurrencia=@StatusTmex_Recurrencia,StatusTmex_Dificultad_identificar_causa=@StatusTmex_Dificultad_identificar_causa,StatusTmex_Reparacion_dificil=@StatusTmex_Reparacion_dificil,SolicitaTmex_Verificación_vehiculo=@SolicitaTmex_Verificación_vehiculo,SolicitaTmex_Historial_servicio=@SolicitaTmex_Historial_servicio,SolicitaTmex_Asistencia_en_reparacion=@SolicitaTmex_Asistencia_en_reparacion,SolicitaTmex_Otro=@SolicitaTmex_Otro,fechaSolTmex=@fechaSolTmex,horaSolTmex=@horaSolTmex,minutoSolTmex=@minutoSolTmex,nombreTmex=@nombreTmex WHERE idCita = @idCita" DeleteCommand="DELETE FROM TYT_KDW_FORMATO_DIAGNOSTICO WHERE idCita = @idCita">
        <InsertParameters>
            <asp:SessionParameter Name="idCita" SessionField="idCita" />
            <asp:SessionParameter Name="USUARIO" SessionField="USUARIO" />
            <asp:SessionParameter Name="FECHA" SessionField="FECHA" />
            <asp:SessionParameter Name="ID_CLIENTE" SessionField="ID_CLIENTE" />
            <asp:SessionParameter Name="VIN" SessionField="VIN" />
            <asp:SessionParameter Name="fechaRecepcion" SessionField="fechaRecepcion" />
            <asp:SessionParameter Name="horaRecepcion" SessionField="horaRecepcion" />
            <asp:SessionParameter Name="minutoRecepcion" SessionField="minutoRecepcion" />
            <asp:SessionParameter Name="Cliente_trae" SessionField="Cliente_trae" />
            <asp:SessionParameter Name="Concesionario_recoge" SessionField="Concesionario_recoge" />
            <asp:SessionParameter Name="VehiculoCortesia" SessionField="VehiculoCortesia" />
            <asp:SessionParameter Name="fechaEntrega" SessionField="fechaEntrega" />
            <asp:SessionParameter Name="horaEntrega" SessionField="horaEntrega" />
            <asp:SessionParameter Name="minutoEntrega" SessionField="minutoEntrega" />
            <asp:SessionParameter Name="Cliente_retira" SessionField="Cliente_retira" />
            <asp:SessionParameter Name="Concesionario_entrega" SessionField="Concesionario_entrega" />
            <asp:SessionParameter Name="nombreCliente" SessionField="nombreCliente" />
            <asp:SessionParameter Name="direccionCliente" SessionField="direccionCliente" />
            <asp:SessionParameter Name="telefonoCliente" SessionField="telefonoCliente" />
            <asp:SessionParameter Name="fechaDiagnostico" SessionField="fechaDiagnostico" />
            <asp:SessionParameter Name="nombreAsesor" SessionField="nombreAsesor" />
            <asp:SessionParameter Name="noDiagnostico" SessionField="noDiagnostico" />
            <asp:SessionParameter Name="noOrden" SessionField="noOrden" />
            <asp:SessionParameter Name="fechaConfirmacion" SessionField="fechaConfirmacion" />
            <asp:SessionParameter Name="horaConfirmacion" SessionField="horaConfirmacion" />
            <asp:SessionParameter Name="minutoConfirmacion" SessionField="minutoConfirmacion" />
            <asp:SessionParameter Name="nombreConfirmacion" SessionField="nombreConfirmacion" />
            <asp:SessionParameter Name="Conducido_Propietario" SessionField="Conducido_Propietario" />
            <asp:SessionParameter Name="Conducido_Familia" SessionField="Conducido_Familia" />
            <asp:SessionParameter Name="Conducido_Otro" SessionField="Conducido_Otro" />
            <asp:SessionParameter Name="txtVehiculoConducido" SessionField="txtVehiculoConducido" />
            <asp:SessionParameter Name="lecturaVelocimetroCita" SessionField="lecturaVelocimetroCita" />
            <asp:SessionParameter Name="vehiculoPlacas" SessionField="vehiculoPlacas" />
            <asp:SessionParameter Name="DOFU" SessionField="DOFU" />
            <asp:SessionParameter Name="vehiculoNombreModelo" SessionField="vehiculoNombreModelo" />
            <asp:SessionParameter Name="vehiculoModelo" SessionField="vehiculoModelo" />
            <asp:SessionParameter Name="vehiculoNoCarroceria" SessionField="vehiculoNoCarroceria" />
            <asp:SessionParameter Name="vehiculoChasis" SessionField="vehiculoChasis" />
            <asp:SessionParameter Name="fenomeno1" SessionField="fenomeno1" />
            <asp:SessionParameter Name="fenomeno2" SessionField="fenomeno2" />
            <asp:SessionParameter Name="fenomeno3" SessionField="fenomeno3" />
            <asp:SessionParameter Name="telefonoContacto" SessionField="telefonoContacto" />
            <asp:SessionParameter Name="horaContacto1" SessionField="horaContacto1" />
            <asp:SessionParameter Name="minutoContacto1" SessionField="minutoContacto1" />
            <asp:SessionParameter Name="horaContacto2" SessionField="horaContacto2" />
            <asp:SessionParameter Name="minutoContacto2" SessionField="minutoContacto2" />
            <asp:SessionParameter Name="nombreWalkAround" SessionField="nombreWalkAround" />
            <asp:SessionParameter Name="fechaWalkAround" SessionField="fechaWalkAround" />
            <asp:SessionParameter Name="horaWalkAround" SessionField="horaWalkAround" />
            <asp:SessionParameter Name="minutoWalkAround" SessionField="minutoWalkAround" />
            <asp:SessionParameter Name="Confirma_Clt" SessionField="Confirma_Clt" />
            <asp:SessionParameter Name="lecturaVeloRecibe" SessionField="lecturaVeloRecibe" />
            <asp:SessionParameter Name="Confirma_Trabajo_adicional" SessionField="Confirma_Trabajo_adicional" />
            <asp:SessionParameter Name="Confirma_Pertenencias" SessionField="Confirma_Pertenencias" />
            <asp:SessionParameter Name="Confirma_Cubre_Asiento" SessionField="Confirma_Cubre_Asiento" />
            <asp:SessionParameter Name="Confirma_Cubre_volante_palanca" SessionField="Confirma_Cubre_volante_palanca" />
            <asp:SessionParameter Name="Confirma_Tapetes" SessionField="Confirma_Tapetes" />
            <asp:SessionParameter Name="DesdeCuando_Recientemente" SessionField="DesdeCuando_Recientemente" />
            <asp:SessionParameter Name="DesdeCuando_Hace_1_semana" SessionField="DesdeCuando_Hace_1_semana" />
            <asp:SessionParameter Name="DesdeCuando_Otro" SessionField="DesdeCuando_Otro" />
            <asp:SessionParameter Name="txtDesdeCuando" SessionField="txtDesdeCuando" />
            <asp:SessionParameter Name="Frecuencia_Siempre" SessionField="Frecuencia_Siempre" />
            <asp:SessionParameter Name="Frecuencia_Ocasionalmente" SessionField="Frecuencia_Ocasionalmente" />
            <asp:SessionParameter Name="Frecuencia_Solo_1_vez" SessionField="Frecuencia_Solo_1_vez" />
            <asp:SessionParameter Name="Frecuencia_Otro" SessionField="Frecuencia_Otro" />
            <asp:SessionParameter Name="txtFrecuencia" SessionField="txtFrecuencia" />
            <asp:SessionParameter Name="Lugar_Calle" SessionField="Lugar_Calle" />
            <asp:SessionParameter Name="Lugar_Carretera" SessionField="Lugar_Carretera" />
            <asp:SessionParameter Name="Lugar_Subida" SessionField="Lugar_Subida" />
            <asp:SessionParameter Name="Lugar_Bajada" SessionField="Lugar_Bajada" />
            <asp:SessionParameter Name="Lugar_Trafico" SessionField="Lugar_Trafico" />
            <asp:SessionParameter Name="LuzAdvierte_Prendida" SessionField="LuzAdvierte_Prendida" />
            <asp:SessionParameter Name="LuzAdvierte_Parpadeando" SessionField="LuzAdvierte_Parpadeando" />
            <asp:SessionParameter Name="LuzAdvierte_Parpadeo_multiple" SessionField="LuzAdvierte_Parpadeo_multiple" />
            <asp:SessionParameter Name="txtLuzAdvierte" SessionField="txtLuzAdvierte" />
            <asp:SessionParameter Name="Condicion_Arranque" SessionField="Condicion_Arranque" />
            <asp:SessionParameter Name="Condicion_Parado" SessionField="Condicion_Parado" />
            <asp:SessionParameter Name="Condicion_V_K" SessionField="Condicion_V_K" />
            <asp:SessionParameter Name="Condicion_V_no_K" SessionField="Condicion_V_no_K" />
            <asp:SessionParameter Name="Condicion_Acelerando" SessionField="Condicion_Acelerando" />
            <asp:SessionParameter Name="Condicion_Desacelerando" SessionField="Condicion_Desacelerando" />
            <asp:SessionParameter Name="txtVelocimetro" SessionField="txtVelocimetro" />
            <asp:SessionParameter Name="txtTacometro" SessionField="txtTacometro" />
            <asp:SessionParameter Name="Condicion_Rebasando" SessionField="Condicion_Rebasando" />
            <asp:SessionParameter Name="Condicion_Cambiando" SessionField="Condicion_Cambiando" />
            <asp:SessionParameter Name="Condicion_Retrocediendo" SessionField="Condicion_Retrocediendo" />
            <asp:SessionParameter Name="Condicion_Frenando" SessionField="Condicion_Frenando" />
            <asp:SessionParameter Name="txtNoPersonas" SessionField="txtNoPersonas" />
            <asp:SessionParameter Name="txtCargaVehiculo" SessionField="txtCargaVehiculo" />
            <asp:SessionParameter Name="txtCargaRemolque" SessionField="txtCargaRemolque" />
            <asp:SessionParameter Name="Superficie_Plana" SessionField="Superficie_Plana" />
            <asp:SessionParameter Name="Superficie_Desigual" SessionField="Superficie_Desigual" />
            <asp:SessionParameter Name="Superficie_Aspero" SessionField="Superficie_Aspero" />
            <asp:SessionParameter Name="Superficie_Otro" SessionField="Superficie_Otro" />
            <asp:SessionParameter Name="txtSuperficie" SessionField="txtSuperficie" />
            <asp:SessionParameter Name="Tiempo_Despejado" SessionField="Tiempo_Despejado" />
            <asp:SessionParameter Name="Tiempo_Nublado" SessionField="Tiempo_Nublado" />
            <asp:SessionParameter Name="Tiempo_Lluvia" SessionField="Tiempo_Lluvia" />
            <asp:SessionParameter Name="Tiempo_Nieve" SessionField="Tiempo_Nieve" />
            <asp:SessionParameter Name="Tiempo_Temperatura_externa" SessionField="Tiempo_Temperatura_externa" />
            <asp:SessionParameter Name="txtTemperaturaExterna" SessionField="txtTemperaturaExterna" />
            <asp:SessionParameter Name="AC_Flujo_aire" SessionField="AC_Flujo_aire" />
            <asp:SessionParameter Name="AC_Recirculacion" SessionField="AC_Recirculacion" />
            <asp:SessionParameter Name="AC_Velocidad_ventilacion" SessionField="AC_Velocidad_ventilacion" />
            <asp:SessionParameter Name="AC_Temperatura" SessionField="AC_Temperatura" />
            <asp:SessionParameter Name="txtAC_Temperatura" SessionField="txtAC_Temperatura" />
            <asp:SessionParameter Name="detalleTrabajo1" SessionField="detalleTrabajo1" />
            <asp:SessionParameter Name="detalleTrabajo2" SessionField="detalleTrabajo2" />
            <asp:SessionParameter Name="detalleTrabajo3" SessionField="detalleTrabajo3" />
            <asp:SessionParameter Name="detalleTrabajo4" SessionField="detalleTrabajo4" />
            <asp:SessionParameter Name="nombreDiag" SessionField="nombreDiag" />
            <asp:SessionParameter Name="fechaDiag" SessionField="fechaDiag" />
            <asp:SessionParameter Name="horaDiag" SessionField="horaDiag" />
            <asp:SessionParameter Name="minutoDiag" SessionField="minutoDiag" />
            <asp:SessionParameter Name="noLLave" SessionField="noLLave" />
            <asp:SessionParameter Name="noBahia" SessionField="noBahia" />
            <asp:SessionParameter Name="Resultado_Descubierto" SessionField="Resultado_Descubierto" />
            <asp:SessionParameter Name="Resultado_Prediccion" SessionField="Resultado_Prediccion" />
            <asp:SessionParameter Name="motivoResulta" SessionField="motivoResulta" />
            <asp:SessionParameter Name="Seguimiento" SessionField="Seguimiento" />
            <asp:SessionParameter Name="causa1" SessionField="causa1" />
            <asp:SessionParameter Name="causa2" SessionField="causa2" />
            <asp:SessionParameter Name="causa3" SessionField="causa3" />
            <asp:SessionParameter Name="causa4" SessionField="causa4" />
            <asp:SessionParameter Name="DTC1" SessionField="DTC1" />
            <asp:SessionParameter Name="DTC2" SessionField="DTC2" />
            <asp:SessionParameter Name="DTC3" SessionField="DTC3" />
            <asp:SessionParameter Name="DTC4" SessionField="DTC4" />
            <asp:SessionParameter Name="Status1_0" SessionField="Status1_0" />
            <asp:SessionParameter Name="Status2_0" SessionField="Status2_0" />
            <asp:SessionParameter Name="Status3_0" SessionField="Status3_0" />
            <asp:SessionParameter Name="Status4_0" SessionField="Status4_0" />
            <asp:SessionParameter Name="Datos1_0" SessionField="Datos1_0" />
            <asp:SessionParameter Name="Datos2_0" SessionField="Datos2_0" />
            <asp:SessionParameter Name="Datos3_0" SessionField="Datos3_0" />
            <asp:SessionParameter Name="Datos4_0" SessionField="Datos4_0" />
            <asp:SessionParameter Name="Garantia" SessionField="Garantia" />
            <asp:SessionParameter Name="instruccion1" SessionField="instruccion1" />
            <asp:SessionParameter Name="instruccion2" SessionField="instruccion2" />
            <asp:SessionParameter Name="instruccion3" SessionField="instruccion3" />
            <asp:SessionParameter Name="instruccion4" SessionField="instruccion4" />
            <asp:SessionParameter Name="fechaIniInst1" SessionField="fechaIniInst1" />
            <asp:SessionParameter Name="fechaIniInst2" SessionField="fechaIniInst2" />
            <asp:SessionParameter Name="fechaIniInst3" SessionField="fechaIniInst3" />
            <asp:SessionParameter Name="fechaIniInst4" SessionField="fechaIniInst4" />
            <asp:SessionParameter Name="horaIniInst1" SessionField="horaIniInst1" />
            <asp:SessionParameter Name="minutoIniInst1" SessionField="minutoIniInst1" />
            <asp:SessionParameter Name="horaIniInst2" SessionField="horaIniInst2" />
            <asp:SessionParameter Name="minutoIniInst2" SessionField="minutoIniInst2" />
            <asp:SessionParameter Name="horaIniInst3" SessionField="horaIniInst3" />
            <asp:SessionParameter Name="minutoIniInst3" SessionField="minutoIniInst3" />
            <asp:SessionParameter Name="horaIniInst4" SessionField="horaIniInst4" />
            <asp:SessionParameter Name="minutoIniInst4" SessionField="minutoIniInst4" />
            <asp:SessionParameter Name="fechaFinInst1" SessionField="fechaFinInst1" />
            <asp:SessionParameter Name="fechaFinInst2" SessionField="fechaFinInst2" />
            <asp:SessionParameter Name="fechaFinInst3" SessionField="fechaFinInst3" />
            <asp:SessionParameter Name="fechaFinInst4" SessionField="fechaFinInst4" />
            <asp:SessionParameter Name="horaFinInst1" SessionField="horaFinInst1" />
            <asp:SessionParameter Name="minutoFinInst1" SessionField="minutoFinInst1" />
            <asp:SessionParameter Name="horaFinInst2" SessionField="horaFinInst2" />
            <asp:SessionParameter Name="minutoFinInst2" SessionField="minutoFinInst2" />
            <asp:SessionParameter Name="horaFinInst3" SessionField="horaFinInst3" />
            <asp:SessionParameter Name="minutoFinInst3" SessionField="minutoFinInst3" />
            <asp:SessionParameter Name="horaFinInst4" SessionField="horaFinInst4" />
            <asp:SessionParameter Name="minutoFinInst4" SessionField="minutoFinInst4" />
            <asp:SessionParameter Name="horaWork1" SessionField="horaWork1" />
            <asp:SessionParameter Name="horaWork2" SessionField="horaWork2" />
            <asp:SessionParameter Name="horaWork3" SessionField="horaWork3" />
            <asp:SessionParameter Name="horaWork4" SessionField="horaWork4" />
            <asp:SessionParameter Name="minutoWork1" SessionField="minutoWork1" />
            <asp:SessionParameter Name="minutoWork2" SessionField="minutoWork2" />
            <asp:SessionParameter Name="minutoWork3" SessionField="minutoWork3" />
            <asp:SessionParameter Name="minutoWork4" SessionField="minutoWork4" />
            <asp:SessionParameter Name="DTR1" SessionField="DTR1" />
            <asp:SessionParameter Name="DTR2" SessionField="DTR2" />
            <asp:SessionParameter Name="DTR3" SessionField="DTR3" />
            <asp:SessionParameter Name="DTR4" SessionField="DTR4" />
            <asp:SessionParameter Name="instTec1" SessionField="instTec1" />
            <asp:SessionParameter Name="instCnf1" SessionField="instCnf1" />
            <asp:SessionParameter Name="instTec2" SessionField="instTec2" />
            <asp:SessionParameter Name="instCnf2" SessionField="instCnf2" />
            <asp:SessionParameter Name="instTec3" SessionField="instTec3" />
            <asp:SessionParameter Name="instCnf3" SessionField="instCnf3" />
            <asp:SessionParameter Name="instTec4" SessionField="instTec4" />
            <asp:SessionParameter Name="instCnf4" SessionField="instCnf4" />
            <asp:SessionParameter Name="tmexDestino" SessionField="tmexDestino" />
            <asp:SessionParameter Name="tmexRespble" SessionField="tmexRespble" />
            <asp:SessionParameter Name="Tmex_En_proceso" SessionField="Tmex_En_proceso" />
            <asp:SessionParameter Name="Tmex_Planeado" SessionField="Tmex_Planeado" />
            <asp:SessionParameter Name="fechaTmex" SessionField="fechaTmex" />
            <asp:SessionParameter Name="horaTmex" SessionField="horaTmex" />
            <asp:SessionParameter Name="minutoTmex" SessionField="minutoTmex" />
            <asp:SessionParameter Name="StatusTmex_Recurrencia" SessionField="StatusTmex_Recurrencia" />
            <asp:SessionParameter Name="StatusTmex_Dificultad_identificar_causa" SessionField="StatusTmex_Dificultad_identificar_causa" />
            <asp:SessionParameter Name="StatusTmex_Reparacion_dificil" SessionField="StatusTmex_Reparacion_dificil" />
            <asp:SessionParameter Name="SolicitaTmex_Verificaci&#243;n_vehiculo" SessionField="SolicitaTmex_Verificaci&#243;n_vehiculo" />
            <asp:SessionParameter Name="SolicitaTmex_Historial_servicio" SessionField="SolicitaTmex_Historial_servicio" />
            <asp:SessionParameter Name="SolicitaTmex_Asistencia_en_reparacion" SessionField="SolicitaTmex_Asistencia_en_reparacion" />
            <asp:SessionParameter Name="SolicitaTmex_Otro" SessionField="SolicitaTmex_Otro" />
            <asp:SessionParameter Name="fechaSolTmex" SessionField="fechaSolTmex" />
            <asp:SessionParameter Name="horaSolTmex" SessionField="horaSolTmex" />
            <asp:SessionParameter Name="minutoSolTmex" SessionField="minutoSolTmex" />
            <asp:SessionParameter Name="nombreTmex" SessionField="nombreTmex" />
        </InsertParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="idCita" SessionField="idCita" />
            <asp:SessionParameter Name="USUARIO" SessionField="USUARIO" />
            <asp:SessionParameter Name="FECHA" SessionField="FECHA" />
            <asp:SessionParameter Name="ID_CLIENTE" SessionField="ID_CLIENTE" />
            <asp:SessionParameter Name="VIN" SessionField="VIN" />
            <asp:SessionParameter Name="fechaRecepcion" SessionField="fechaRecepcion" />
            <asp:SessionParameter Name="horaRecepcion" SessionField="horaRecepcion" />
            <asp:SessionParameter Name="minutoRecepcion" SessionField="minutoRecepcion" />
            <asp:SessionParameter Name="Cliente_trae" SessionField="Cliente_trae" />
            <asp:SessionParameter Name="Concesionario_recoge" SessionField="Concesionario_recoge" />
            <asp:SessionParameter Name="VehiculoCortesia" SessionField="VehiculoCortesia" />
            <asp:SessionParameter Name="fechaEntrega" SessionField="fechaEntrega" />
            <asp:SessionParameter Name="horaEntrega" SessionField="horaEntrega" />
            <asp:SessionParameter Name="minutoEntrega" SessionField="minutoEntrega" />
            <asp:SessionParameter Name="Cliente_retira" SessionField="Cliente_retira" />
            <asp:SessionParameter Name="Concesionario_entrega" SessionField="Concesionario_entrega" />
            <asp:SessionParameter Name="nombreCliente" SessionField="nombreCliente" />
            <asp:SessionParameter Name="direccionCliente" SessionField="direccionCliente" />
            <asp:SessionParameter Name="telefonoCliente" SessionField="telefonoCliente" />
            <asp:SessionParameter Name="fechaDiagnostico" SessionField="fechaDiagnostico" />
            <asp:SessionParameter Name="nombreAsesor" SessionField="nombreAsesor" />
            <asp:SessionParameter Name="noDiagnostico" SessionField="noDiagnostico" />
            <asp:SessionParameter Name="noOrden" SessionField="noOrden" />
            <asp:SessionParameter Name="fechaConfirmacion" SessionField="fechaConfirmacion" />
            <asp:SessionParameter Name="horaConfirmacion" SessionField="horaConfirmacion" />
            <asp:SessionParameter Name="minutoConfirmacion" SessionField="minutoConfirmacion" />
            <asp:SessionParameter Name="nombreConfirmacion" SessionField="nombreConfirmacion" />
            <asp:SessionParameter Name="Conducido_Propietario" SessionField="Conducido_Propietario" />
            <asp:SessionParameter Name="Conducido_Familia" SessionField="Conducido_Familia" />
            <asp:SessionParameter Name="Conducido_Otro" SessionField="Conducido_Otro" />
            <asp:SessionParameter Name="txtVehiculoConducido" SessionField="txtVehiculoConducido" />
            <asp:SessionParameter Name="lecturaVelocimetroCita" SessionField="lecturaVelocimetroCita" />
            <asp:SessionParameter Name="vehiculoPlacas" SessionField="vehiculoPlacas" />
            <asp:SessionParameter Name="DOFU" SessionField="DOFU" />
            <asp:SessionParameter Name="vehiculoNombreModelo" SessionField="vehiculoNombreModelo" />
            <asp:SessionParameter Name="vehiculoModelo" SessionField="vehiculoModelo" />
            <asp:SessionParameter Name="vehiculoNoCarroceria" SessionField="vehiculoNoCarroceria" />
            <asp:SessionParameter Name="vehiculoChasis" SessionField="vehiculoChasis" />
            <asp:SessionParameter Name="fenomeno1" SessionField="fenomeno1" />
            <asp:SessionParameter Name="fenomeno2" SessionField="fenomeno2" />
            <asp:SessionParameter Name="fenomeno3" SessionField="fenomeno3" />
            <asp:SessionParameter Name="telefonoContacto" SessionField="telefonoContacto" />
            <asp:SessionParameter Name="horaContacto1" SessionField="horaContacto1" />
            <asp:SessionParameter Name="minutoContacto1" SessionField="minutoContacto1" />
            <asp:SessionParameter Name="horaContacto2" SessionField="horaContacto2" />
            <asp:SessionParameter Name="minutoContacto2" SessionField="minutoContacto2" />
            <asp:SessionParameter Name="nombreWalkAround" SessionField="nombreWalkAround" />
            <asp:SessionParameter Name="fechaWalkAround" SessionField="fechaWalkAround" />
            <asp:SessionParameter Name="horaWalkAround" SessionField="horaWalkAround" />
            <asp:SessionParameter Name="minutoWalkAround" SessionField="minutoWalkAround" />
            <asp:SessionParameter Name="Confirma_Clt" SessionField="Confirma_Clt" />
            <asp:SessionParameter Name="lecturaVeloRecibe" SessionField="lecturaVeloRecibe" />
            <asp:SessionParameter Name="Confirma_Trabajo_adicional" SessionField="Confirma_Trabajo_adicional" />
            <asp:SessionParameter Name="Confirma_Pertenencias" SessionField="Confirma_Pertenencias" />
            <asp:SessionParameter Name="Confirma_Cubre_Asiento" SessionField="Confirma_Cubre_Asiento" />
            <asp:SessionParameter Name="Confirma_Cubre_volante_palanca" SessionField="Confirma_Cubre_volante_palanca" />
            <asp:SessionParameter Name="Confirma_Tapetes" SessionField="Confirma_Tapetes" />
            <asp:SessionParameter Name="DesdeCuando_Recientemente" SessionField="DesdeCuando_Recientemente" />
            <asp:SessionParameter Name="DesdeCuando_Hace_1_semana" SessionField="DesdeCuando_Hace_1_semana" />
            <asp:SessionParameter Name="DesdeCuando_Otro" SessionField="DesdeCuando_Otro" />
            <asp:SessionParameter Name="txtDesdeCuando" SessionField="txtDesdeCuando" />
            <asp:SessionParameter Name="Frecuencia_Siempre" SessionField="Frecuencia_Siempre" />
            <asp:SessionParameter Name="Frecuencia_Ocasionalmente" SessionField="Frecuencia_Ocasionalmente" />
            <asp:SessionParameter Name="Frecuencia_Solo_1_vez" SessionField="Frecuencia_Solo_1_vez" />
            <asp:SessionParameter Name="Frecuencia_Otro" SessionField="Frecuencia_Otro" />
            <asp:SessionParameter Name="txtFrecuencia" SessionField="txtFrecuencia" />
            <asp:SessionParameter Name="Lugar_Calle" SessionField="Lugar_Calle" />
            <asp:SessionParameter Name="Lugar_Carretera" SessionField="Lugar_Carretera" />
            <asp:SessionParameter Name="Lugar_Subida" SessionField="Lugar_Subida" />
            <asp:SessionParameter Name="Lugar_Bajada" SessionField="Lugar_Bajada" />
            <asp:SessionParameter Name="Lugar_Trafico" SessionField="Lugar_Trafico" />
            <asp:SessionParameter Name="LuzAdvierte_Prendida" SessionField="LuzAdvierte_Prendida" />
            <asp:SessionParameter Name="LuzAdvierte_Parpadeando" SessionField="LuzAdvierte_Parpadeando" />
            <asp:SessionParameter Name="LuzAdvierte_Parpadeo_multiple" SessionField="LuzAdvierte_Parpadeo_multiple" />
            <asp:SessionParameter Name="txtLuzAdvierte" SessionField="txtLuzAdvierte" />
            <asp:SessionParameter Name="Condicion_Arranque" SessionField="Condicion_Arranque" />
            <asp:SessionParameter Name="Condicion_Parado" SessionField="Condicion_Parado" />
            <asp:SessionParameter Name="Condicion_V_K" SessionField="Condicion_V_K" />
            <asp:SessionParameter Name="Condicion_V_no_K" SessionField="Condicion_V_no_K" />
            <asp:SessionParameter Name="Condicion_Acelerando" SessionField="Condicion_Acelerando" />
            <asp:SessionParameter Name="Condicion_Desacelerando" SessionField="Condicion_Desacelerando" />
            <asp:SessionParameter Name="txtVelocimetro" SessionField="txtVelocimetro" />
            <asp:SessionParameter Name="txtTacometro" SessionField="txtTacometro" />
            <asp:SessionParameter Name="Condicion_Rebasando" SessionField="Condicion_Rebasando" />
            <asp:SessionParameter Name="Condicion_Cambiando" SessionField="Condicion_Cambiando" />
            <asp:SessionParameter Name="Condicion_Retrocediendo" SessionField="Condicion_Retrocediendo" />
            <asp:SessionParameter Name="Condicion_Frenando" SessionField="Condicion_Frenando" />
            <asp:SessionParameter Name="txtNoPersonas" SessionField="txtNoPersonas" />
            <asp:SessionParameter Name="txtCargaVehiculo" SessionField="txtCargaVehiculo" />
            <asp:SessionParameter Name="txtCargaRemolque" SessionField="txtCargaRemolque" />
            <asp:SessionParameter Name="Superficie_Plana" SessionField="Superficie_Plana" />
            <asp:SessionParameter Name="Superficie_Desigual" SessionField="Superficie_Desigual" />
            <asp:SessionParameter Name="Superficie_Aspero" SessionField="Superficie_Aspero" />
            <asp:SessionParameter Name="Superficie_Otro" SessionField="Superficie_Otro" />
            <asp:SessionParameter Name="txtSuperficie" SessionField="txtSuperficie" />
            <asp:SessionParameter Name="Tiempo_Despejado" SessionField="Tiempo_Despejado" />
            <asp:SessionParameter Name="Tiempo_Nublado" SessionField="Tiempo_Nublado" />
            <asp:SessionParameter Name="Tiempo_Lluvia" SessionField="Tiempo_Lluvia" />
            <asp:SessionParameter Name="Tiempo_Nieve" SessionField="Tiempo_Nieve" />
            <asp:SessionParameter Name="Tiempo_Temperatura_externa" SessionField="Tiempo_Temperatura_externa" />
            <asp:SessionParameter Name="txtTemperaturaExterna" SessionField="txtTemperaturaExterna" />
            <asp:SessionParameter Name="AC_Flujo_aire" SessionField="AC_Flujo_aire" />
            <asp:SessionParameter Name="AC_Recirculacion" SessionField="AC_Recirculacion" />
            <asp:SessionParameter Name="AC_Velocidad_ventilacion" SessionField="AC_Velocidad_ventilacion" />
            <asp:SessionParameter Name="AC_Temperatura" SessionField="AC_Temperatura" />
            <asp:SessionParameter Name="txtAC_Temperatura" SessionField="txtAC_Temperatura" />
            <asp:SessionParameter Name="detalleTrabajo1" SessionField="detalleTrabajo1" />
            <asp:SessionParameter Name="detalleTrabajo2" SessionField="detalleTrabajo2" />
            <asp:SessionParameter Name="detalleTrabajo3" SessionField="detalleTrabajo3" />
            <asp:SessionParameter Name="detalleTrabajo4" SessionField="detalleTrabajo4" />
            <asp:SessionParameter Name="nombreDiag" SessionField="nombreDiag" />
            <asp:SessionParameter Name="fechaDiag" SessionField="fechaDiag" />
            <asp:SessionParameter Name="horaDiag" SessionField="horaDiag" />
            <asp:SessionParameter Name="minutoDiag" SessionField="minutoDiag" />
            <asp:SessionParameter Name="noLLave" SessionField="noLLave" />
            <asp:SessionParameter Name="noBahia" SessionField="noBahia" />
            <asp:SessionParameter Name="Resultado_Descubierto" SessionField="Resultado_Descubierto" />
            <asp:SessionParameter Name="Resultado_Prediccion" SessionField="Resultado_Prediccion" />
            <asp:SessionParameter Name="motivoResulta" SessionField="motivoResulta" />
            <asp:SessionParameter Name="Seguimiento" SessionField="Seguimiento" />
            <asp:SessionParameter Name="causa1" SessionField="causa1" />
            <asp:SessionParameter Name="causa2" SessionField="causa2" />
            <asp:SessionParameter Name="causa3" SessionField="causa3" />
            <asp:SessionParameter Name="causa4" SessionField="causa4" />
            <asp:SessionParameter Name="DTC1" SessionField="DTC1" />
            <asp:SessionParameter Name="DTC2" SessionField="DTC2" />
            <asp:SessionParameter Name="DTC3" SessionField="DTC3" />
            <asp:SessionParameter Name="DTC4" SessionField="DTC4" />
            <asp:SessionParameter Name="Status1_0" SessionField="Status1_0" />
            <asp:SessionParameter Name="Status2_0" SessionField="Status2_0" />
            <asp:SessionParameter Name="Status3_0" SessionField="Status3_0" />
            <asp:SessionParameter Name="Status4_0" SessionField="Status4_0" />
            <asp:SessionParameter Name="Datos1_0" SessionField="Datos1_0" />
            <asp:SessionParameter Name="Datos2_0" SessionField="Datos2_0" />
            <asp:SessionParameter Name="Datos3_0" SessionField="Datos3_0" />
            <asp:SessionParameter Name="Datos4_0" SessionField="Datos4_0" />
            <asp:SessionParameter Name="Garantia" SessionField="Garantia" />
            <asp:SessionParameter Name="instruccion1" SessionField="instruccion1" />
            <asp:SessionParameter Name="instruccion2" SessionField="instruccion2" />
            <asp:SessionParameter Name="instruccion3" SessionField="instruccion3" />
            <asp:SessionParameter Name="instruccion4" SessionField="instruccion4" />
            <asp:SessionParameter Name="fechaIniInst1" SessionField="fechaIniInst1" />
            <asp:SessionParameter Name="fechaIniInst2" SessionField="fechaIniInst2" />
            <asp:SessionParameter Name="fechaIniInst3" SessionField="fechaIniInst3" />
            <asp:SessionParameter Name="fechaIniInst4" SessionField="fechaIniInst4" />
            <asp:SessionParameter Name="horaIniInst1" SessionField="horaIniInst1" />
            <asp:SessionParameter Name="minutoIniInst1" SessionField="minutoIniInst1" />
            <asp:SessionParameter Name="horaIniInst2" SessionField="horaIniInst2" />
            <asp:SessionParameter Name="minutoIniInst2" SessionField="minutoIniInst2" />
            <asp:SessionParameter Name="horaIniInst3" SessionField="horaIniInst3" />
            <asp:SessionParameter Name="minutoIniInst3" SessionField="minutoIniInst3" />
            <asp:SessionParameter Name="horaIniInst4" SessionField="horaIniInst4" />
            <asp:SessionParameter Name="minutoIniInst4" SessionField="minutoIniInst4" />
            <asp:SessionParameter Name="fechaFinInst1" SessionField="fechaFinInst1" />
            <asp:SessionParameter Name="fechaFinInst2" SessionField="fechaFinInst2" />
            <asp:SessionParameter Name="fechaFinInst3" SessionField="fechaFinInst3" />
            <asp:SessionParameter Name="fechaFinInst4" SessionField="fechaFinInst4" />
            <asp:SessionParameter Name="horaFinInst1" SessionField="horaFinInst1" />
            <asp:SessionParameter Name="minutoFinInst1" SessionField="minutoFinInst1" />
            <asp:SessionParameter Name="horaFinInst2" SessionField="horaFinInst2" />
            <asp:SessionParameter Name="minutoFinInst2" SessionField="minutoFinInst2" />
            <asp:SessionParameter Name="horaFinInst3" SessionField="horaFinInst3" />
            <asp:SessionParameter Name="minutoFinInst3" SessionField="minutoFinInst3" />
            <asp:SessionParameter Name="horaFinInst4" SessionField="horaFinInst4" />
            <asp:SessionParameter Name="minutoFinInst4" SessionField="minutoFinInst4" />
            <asp:SessionParameter Name="horaWork1" SessionField="horaWork1" />
            <asp:SessionParameter Name="horaWork2" SessionField="horaWork2" />
            <asp:SessionParameter Name="horaWork3" SessionField="horaWork3" />
            <asp:SessionParameter Name="horaWork4" SessionField="horaWork4" />
            <asp:SessionParameter Name="minutoWork1" SessionField="minutoWork1" />
            <asp:SessionParameter Name="minutoWork2" SessionField="minutoWork2" />
            <asp:SessionParameter Name="minutoWork3" SessionField="minutoWork3" />
            <asp:SessionParameter Name="minutoWork4" SessionField="minutoWork4" />
            <asp:SessionParameter Name="DTR1" SessionField="DTR1" />
            <asp:SessionParameter Name="DTR2" SessionField="DTR2" />
            <asp:SessionParameter Name="DTR3" SessionField="DTR3" />
            <asp:SessionParameter Name="DTR4" SessionField="DTR4" />
            <asp:SessionParameter Name="instTec1" SessionField="instTec1" />
            <asp:SessionParameter Name="instCnf1" SessionField="instCnf1" />
            <asp:SessionParameter Name="instTec2" SessionField="instTec2" />
            <asp:SessionParameter Name="instCnf2" SessionField="instCnf2" />
            <asp:SessionParameter Name="instTec3" SessionField="instTec3" />
            <asp:SessionParameter Name="instCnf3" SessionField="instCnf3" />
            <asp:SessionParameter Name="instTec4" SessionField="instTec4" />
            <asp:SessionParameter Name="instCnf4" SessionField="instCnf4" />
            <asp:SessionParameter Name="tmexDestino" SessionField="tmexDestino" />
            <asp:SessionParameter Name="tmexRespble" SessionField="tmexRespble" />
            <asp:SessionParameter Name="Tmex_En_proceso" SessionField="Tmex_En_proceso" />
            <asp:SessionParameter Name="Tmex_Planeado" SessionField="Tmex_Planeado" />
            <asp:SessionParameter Name="fechaTmex" SessionField="fechaTmex" />
            <asp:SessionParameter Name="horaTmex" SessionField="horaTmex" />
            <asp:SessionParameter Name="minutoTmex" SessionField="minutoTmex" />
            <asp:SessionParameter Name="StatusTmex_Recurrencia" SessionField="StatusTmex_Recurrencia" />
            <asp:SessionParameter Name="StatusTmex_Dificultad_identificar_causa" SessionField="StatusTmex_Dificultad_identificar_causa" />
            <asp:SessionParameter Name="StatusTmex_Reparacion_dificil" SessionField="StatusTmex_Reparacion_dificil" />
            <asp:SessionParameter Name="SolicitaTmex_Verificaci&#243;n_vehiculo" SessionField="SolicitaTmex_Verificaci&#243;n_vehiculo" />
            <asp:SessionParameter Name="SolicitaTmex_Historial_servicio" SessionField="SolicitaTmex_Historial_servicio" />
            <asp:SessionParameter Name="SolicitaTmex_Asistencia_en_reparacion" SessionField="SolicitaTmex_Asistencia_en_reparacion" />
            <asp:SessionParameter Name="SolicitaTmex_Otro" SessionField="SolicitaTmex_Otro" />
            <asp:SessionParameter Name="fechaSolTmex" SessionField="fechaSolTmex" />
            <asp:SessionParameter Name="horaSolTmex" SessionField="horaSolTmex" />
            <asp:SessionParameter Name="minutoSolTmex" SessionField="minutoSolTmex" />
            <asp:SessionParameter Name="nombreTmex" SessionField="nombreTmex" />
            <asp:SessionParameter Name="id" SessionField="id" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:SessionParameter Name="idCita" SessionField="idCita" />
        </DeleteParameters>

    </asp:SqlDataSource>
    <asp:Panel ID="Panel2" runat="server" Height="32px" Style="z-index: 102; left: 345px;
        position: absolute; top: 2px" Width="328px">
        <asp:Label ID="Label2" runat="server" Font-Size="XX-Large" Text="Cuestionario Diagnostico"
            Width="483px" Height="37px"></asp:Label></asp:Panel>
    <asp:SqlDataSource ID="SqlDataSource_36" runat="server" ConnectionString="<%$ ConnectionStrings:tbCS %>"
        DeleteCommand="DELETE  Tb_CITAS WHERE oChip = @oChip&#13;&#10;AND YEAR(fecha) = @fechaAAAA AND MONTH(fecha) = @fechaMM AND DAY(fecha) = @fechaDD"
        ProviderName="<%$ ConnectionStrings:tbCS.ProviderName %>" SelectCommand="SELECT Cliente, noPlacas, Vehiculo, Color, Ano, Cilindros, idAsesor, horaAsesor, noOrden, horaCita, idTecnico, Servicio, horaEntrega FROM Tb_CITAS WHERE id = 0">
    </asp:SqlDataSource>

    
</body>
</html>
