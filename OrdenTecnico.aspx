<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="OrdenTecnico.aspx.vb" Inherits="TablerosV2.OrdenTecnico" %>

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
    
</head>
<body>
    <form id="form1" runat="server">

    <asp:Panel ID="pnlOrdenTecnico" runat="server" Height="1224px" Style="z-index: 100; left: 16px;
        position: absolute; top: 56px" Width="1168px">

        <asp:TextBox ID="txtTipoTrabajo" runat="server" Font-Size="Small"
            Style="z-index: 100; left: 8px; position: absolute; top: 26px" Width="280px"></asp:TextBox>
        <asp:CheckBoxList ID="cbl_Refaccion" runat="server" Style="z-index: 102; left: 504px;
            position: absolute; top: 24px">
            <asp:ListItem></asp:ListItem>
        </asp:CheckBoxList>
        <asp:TextBox ID="txtLLaves" runat="server" Font-Size="Small" Style="z-index: 103;
            left: 624px; position: absolute; top: 26px" Width="128px"></asp:TextBox>
        <asp:TextBox ID="txtBahia" runat="server" Font-Size="Small" Style="z-index: 104;
            left: 768px; position: absolute; top: 26px" Width="96px"></asp:TextBox>
        <asp:TextBox ID="txtHeadFecha" runat="server" Font-Size="Small" Style="z-index: 105;
            left: 920px; position: absolute; top: 16px" Width="120px"></asp:TextBox>
        <asp:TextBox ID="txtCliente" runat="server" Font-Size="Small" Style="z-index: 106;
            left: 8px; position: absolute; top: 80px" Width="592px"></asp:TextBox>
        <asp:TextBox ID="txtNombreModelo" runat="server" Font-Size="Small" Style="z-index: 107;
            left: 8px; position: absolute; top: 128px" Width="272px"></asp:TextBox>
        <asp:TextBox ID="txtPlacas" runat="server" Font-Size="Small" Style="z-index: 108;
            left: 304px; position: absolute; top: 128px" Width="296px"></asp:TextBox>

        <asp:TextBox ID="txtFechaTermino" runat="server" Font-Size="Small" Style="z-index: 109;
            left: 288px; position: absolute; top: 184px" Width="120px"></asp:TextBox>
        <asp:TextBox ID="txtHoraTermino" runat="server" Font-Size="Small" Style="z-index: 110;
            left: 472px; position: absolute; top: 184px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtMinutoTermino" runat="server" Font-Size="Small" Style="z-index: 111;
            left: 528px; position: absolute; top: 184px" Width="32px"></asp:TextBox>

        <asp:TextBox ID="txtFechaEntrega" runat="server" Font-Size="Small" Style="z-index: 112;
            left: 288px; position: absolute; top: 240px" Width="120px"></asp:TextBox>
        <asp:TextBox ID="txtHoraEntrega" runat="server" Font-Size="Small" Style="z-index: 113;
            left: 472px; position: absolute; top: 240px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtMinutoEntrega" runat="server" Font-Size="Small" Style="z-index: 114;
            left: 528px; position: absolute; top: 240px" Width="32px"></asp:TextBox>

        <asp:TextBox ID="txtNoOrden" runat="server" Font-Size="Small" Style="z-index: 115;
            left: 712px; position: absolute; top: 56px" Width="144px"></asp:TextBox>
        <asp:TextBox ID="txtNoTrabajo" runat="server" Font-Size="Small" Style="z-index: 116;
            left: 976px; position: absolute; top: 56px" Width="72px"></asp:TextBox>

        <asp:TextBox ID="txtDOFU" runat="server" Font-Size="Small" Style="z-index: 117;
            left: 688px; position: absolute; top: 82px" Width="168px"></asp:TextBox>
        <asp:TextBox ID="txtAsesor" runat="server" Font-Size="Small" Style="z-index: 118;
            left: 928px; position: absolute; top: 82px" Width="120px"></asp:TextBox>

        <asp:TextBox ID="txtModelo" runat="server" Font-Size="Small" Style="z-index: 119;
            left: 848px; position: absolute; top: 112px" Width="192px" Height="16px"></asp:TextBox>
        <asp:TextBox ID="txtSerie" runat="server" Font-Size="Small" Style="z-index: 120;
            left: 632px; position: absolute; top: 136px" Width="408px"></asp:TextBox>
        <asp:TextBox ID="txtMotor" runat="server" Font-Size="Small" Style="z-index: 121;
            left: 632px; position: absolute; top: 160px" Width="408px"></asp:TextBox>

        <asp:TextBox ID="txtTelefono_1" runat="server" Font-Size="Small" Style="z-index: 122;
            left: 704px; position: absolute; top: 208px" Width="136px"></asp:TextBox>
        
        <asp:TextBox ID="txtEmail_1" runat="server" Font-Size="Small" Style="z-index: 123;
            left: 704px; position: absolute; top: 234px" Width="336px"></asp:TextBox>
        
        
        <asp:RadioButtonList ID="rbl_Info_1" runat="server" Font-Size="Small"
            RepeatDirection="Horizontal" Style="z-index: 124; left: 849px; position: absolute;
            top: 203px; height: 28px; width: 190px;">
            <asp:ListItem>Casa</asp:ListItem>
            <asp:ListItem>Trabajo</asp:ListItem>
            <asp:ListItem>Celular</asp:ListItem>
        </asp:RadioButtonList>


        <asp:RadioButtonList ID="rbl_CambioFecha" runat="server" Font-Size="Small" Height="1px"
            RepeatDirection="Horizontal" Style="z-index: 124; left: 192px; position: absolute;
            top: 278px" Width="336px">
            <asp:ListItem>Trabajo adicional</asp:ListItem>
            <asp:ListItem>Detenci&#243;n de trabajo</asp:ListItem>
            <asp:ListItem>Otros</asp:ListItem>
        </asp:RadioButtonList>

        <asp:TextBox ID="txtTrabajo_Otro" runat="server" Font-Size="Small" Style="z-index: 140;
            left: 536px; position: absolute; top: 280px" Width="320px" BackColor="#FFFF80"></asp:TextBox>


        <asp:TextBox ID="txtTrabajo_1" runat="server" Font-Size="Small" Style="z-index: 141;
            left: 16px; position: absolute; top: 321px" Width="270px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtPieza_1" runat="server" Font-Size="Small" Style="z-index: 142;
            left: 312px; position: absolute; top: 321px" Width="208px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtAmount_1" runat="server" Font-Size="Small" Style="z-index: 143;
            left: 540px; position: absolute; top: 321px" Width="40px" 
            BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtCosto_1" runat="server" Font-Size="Small" Style="z-index: 143;
            left: 600px; position: absolute; top: 321px; width: 62px;" 
            BackColor="#FFFF80"></asp:TextBox>
        <asp:DropDownList ID="ddl_Stock_1" runat="server" Style="z-index: 144; left: 688px;
            position: absolute; top: 321px" Width="42px" BackColor="#FFFF80">
            <asp:ListItem Value="0">...</asp:ListItem>
            <asp:ListItem Value="1">Si</asp:ListItem>
            <asp:ListItem Value="2">No</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtETA_11" runat="server" Font-Size="Small" Style="z-index: 145;
            left: 776px; position: absolute; top: 321px" Width="32px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtETA_12" runat="server" Font-Size="Small" Style="z-index: 146;
            left: 832px; position: absolute; top: 321px" Width="24px" BackColor="#FFFF80"></asp:TextBox>

        <asp:TextBox ID="txtTrabajo_2" runat="server" Font-Size="Small" Style="z-index: 147;
            left: 16px; position: absolute; top: 348px" Width="270px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtPieza_2" runat="server" Font-Size="Small" Style="z-index: 148;
            left: 312px; position: absolute; top: 348px" Width="208px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtAmount_2" runat="server" Font-Size="Small" Style="z-index: 149;
            left: 540px; position: absolute; top: 347px" Width="40px" 
            BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtCosto_2" runat="server" Font-Size="Small" Style="z-index: 149;
            left: 600px; position: absolute; top: 347px" Width="62px" 
            BackColor="#FFFF80"></asp:TextBox>
        <asp:DropDownList ID="ddl_Stock_2" runat="server" Style="z-index: 150; left: 688px;
            position: absolute; top: 348px" Width="42px" BackColor="#FFFF80">
            <asp:ListItem Value="0">...</asp:ListItem>
            <asp:ListItem Value="1">Si</asp:ListItem>
            <asp:ListItem Value="2">No</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtETA_21" runat="server" Font-Size="Small" Style="z-index: 151;
            left: 776px; position: absolute; top: 348px" Width="32px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtETA_22" runat="server" Font-Size="Small" Style="z-index: 152;
            left: 832px; position: absolute; top: 348px" Width="24px" BackColor="#FFFF80"></asp:TextBox>

        <asp:TextBox ID="txtTrabajo_3" runat="server" Font-Size="Small" Style="z-index: 153;
            left: 16px; position: absolute; top: 374px" Width="270px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtPieza_3" runat="server" Font-Size="Small" Style="z-index: 154;
            left: 312px; position: absolute; top: 374px" Width="208px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtAmount_3" runat="server" Font-Size="Small" Style="z-index: 155;
            left: 540px; position: absolute; top: 375px" Width="40px" 
            BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtCosto_3" runat="server" Font-Size="Small" Style="z-index: 155;
            left: 600px; position: absolute; top: 375px" Width="62px" 
            BackColor="#FFFF80"></asp:TextBox>
        <asp:DropDownList ID="ddl_Stock_3" runat="server" Style="z-index: 156; left: 688px;
            position: absolute; top: 374px" Width="42px" BackColor="#FFFF80">
            <asp:ListItem Value="0">...</asp:ListItem>
            <asp:ListItem Value="1">Si</asp:ListItem>
            <asp:ListItem Value="2">No</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtETA_31" runat="server" Font-Size="Small" Style="z-index: 157;
            left: 776px; position: absolute; top: 374px" Width="32px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtETA_32" runat="server" Font-Size="Small" Style="z-index: 158;
            left: 832px; position: absolute; top: 374px" Width="24px" BackColor="#FFFF80"></asp:TextBox>

        <asp:TextBox ID="txtTrabajo_4" runat="server" Font-Size="Small" Style="z-index: 159;
            left: 16px; position: absolute; top: 404px" Width="270px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtPieza_4" runat="server" Font-Size="Small" Style="z-index: 160;
            left: 312px; position: absolute; top: 404px" Width="208px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtAmount_4" runat="server" Font-Size="Small" Style="z-index: 161;
            left: 540px; position: absolute; top: 404px" Width="40px" 
            BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtCosto_4" runat="server" Font-Size="Small" Style="z-index: 161;
            left: 600px; position: absolute; top: 404px" Width="62px" 
            BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtCosto_5" runat="server" Font-Size="Small" Style="z-index: 161;
            left: 600px; position: absolute; top: 436px" Width="62px" 
            BackColor="#D6D6D6"></asp:TextBox>
        <asp:DropDownList ID="ddl_Stock_4" runat="server" Style="z-index: 162; left: 688px;
            position: absolute; top: 404px" Width="42px" BackColor="#FFFF80">
            <asp:ListItem Value="0">...</asp:ListItem>
            <asp:ListItem Value="1">Si</asp:ListItem>
            <asp:ListItem Value="2">No</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtETA_41" runat="server" Font-Size="Small" Style="z-index: 163;
            left: 776px; position: absolute; top: 404px" Width="32px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtETA_42" runat="server" Font-Size="Small" Style="z-index: 164;
            left: 832px; position: absolute; top: 404px" Width="24px" BackColor="#FFFF80"></asp:TextBox>

        <asp:TextBox ID="txtFechaConta" runat="server" Font-Size="Small" Style="z-index: 165;
            left: 898px; position: absolute; top: 323px" Width="120px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtHoraConta" runat="server" Font-Size="Small" Style="z-index: 166;
            left: 930px; position: absolute; top: 363px" Width="32px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtMinutoConta" runat="server" Font-Size="Small" Style="z-index: 167;
            left: 978px; position: absolute; top: 363px" Width="32px" BackColor="#FFFF80"></asp:TextBox>
        <asp:TextBox ID="txtNombreConta" runat="server" Font-Size="Small" Style="z-index: 168;
            left: 906px; position: absolute; top: 408px" Width="120px" BackColor="#FFFF80"></asp:TextBox>

        <asp:TextBox ID="txtCambioFechaTermino" runat="server" Font-Size="Small" Style="z-index: 169;
            left: 304px; position: absolute; top: 436px" Width="96px" BackColor="White"></asp:TextBox>
        <asp:TextBox ID="txtCambioHoraTermino" runat="server" Font-Size="Small" Style="z-index: 170;
            left: 456px; position: absolute; top: 436px" Width="24px" BackColor="White"></asp:TextBox>
        <asp:TextBox ID="txtCambioMinutoTermino" runat="server" Font-Size="Small" Style="z-index: 171;
            left: 496px; position: absolute; top: 436px" Width="24px" BackColor="White"></asp:TextBox>

        <asp:TextBox ID="txtCambioFechaEntrega" runat="server" Font-Size="Small" Style="z-index: 172;
            left: 840px; position: absolute; top: 436px" Width="96px" BackColor="White"></asp:TextBox>
        <asp:TextBox ID="txtCambioHoraEntrega" runat="server" Font-Size="Small" Style="z-index: 173;
            left: 984px; position: absolute; top: 436px" Width="24px" BackColor="White"></asp:TextBox>
        <asp:TextBox ID="txtCambioMinutoEntrega" runat="server" Font-Size="Small" Style="z-index: 174;
            left: 1016px; position: absolute; top: 436px" Width="32px" BackColor="White"></asp:TextBox>

        <asp:TextBox ID="txtFechaIni_1" runat="server" Font-Size="Small" Style="z-index: 175;
            left: 8px; position: absolute; top: 512px" Width="96px"></asp:TextBox>
        <asp:TextBox ID="txtHoraIni_1" runat="server" Font-Size="Small" Style="z-index: 176;
            left: 136px; position: absolute; top: 512px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtMinutoIni_1" runat="server" Font-Size="Small" Style="z-index: 177;
            left: 184px; position: absolute; top: 512px" Width="24px"></asp:TextBox>

        <asp:TextBox ID="txtFechaFin_1" runat="server" Font-Size="Small" Style="z-index: 175;
            left: 224px; position: absolute; top: 512px" Width="88px"></asp:TextBox>
        <asp:TextBox ID="txtHoraFin_1" runat="server" Font-Size="Small" Style="z-index: 176;
            left: 344px; position: absolute; top: 512px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtMinutoFin_1" runat="server" Font-Size="Small" Style="z-index: 177;
            left: 392px; position: absolute; top: 512px" Width="24px"></asp:TextBox>

        <asp:TextBox ID="txtTimeHoraIni_1" runat="server" Font-Size="Small" Style="z-index: 178;
            left: 440px; position: absolute; top: 512px" Width="24px"></asp:TextBox>
        <asp:TextBox ID="txtTimeMinutoIni_1" runat="server" Font-Size="Small" Style="z-index: 179;
            left: 488px; position: absolute; top: 512px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtTecnico_1" runat="server" Font-Size="Small" Style="z-index: 180;
            left: 567px; position: absolute; top: 513px" Width="120px"></asp:TextBox>
        <asp:TextBox ID="txtCalidad_1" runat="server" Font-Size="Small" Style="z-index: 181;
            left: 910px; position: absolute; top: 512px; width: 130px;"></asp:TextBox>





        <asp:TextBox ID="txtFechaIni_2" runat="server" Font-Size="Small" Style="z-index: 182;
            left: 8px; position: absolute; top: 544px" Width="96px"></asp:TextBox>
        <asp:TextBox ID="txtHoraIni_2" runat="server" Font-Size="Small" Style="z-index: 183;
            left: 136px; position: absolute; top: 544px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtMinutoIni_2" runat="server" Font-Size="Small" Style="z-index: 184;
            left: 184px; position: absolute; top: 544px" Width="24px"></asp:TextBox>
        
        <asp:TextBox ID="txtFechaFin_2" runat="server" Font-Size="Small" Style="z-index: 182;
            left: 224px; position: absolute; top: 544px" Width="88px"></asp:TextBox>
        <asp:TextBox ID="txtHoraFin_2" runat="server" Font-Size="Small" Style="z-index: 183;
            left: 344px; position: absolute; top: 544px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtMinutoFin_2" runat="server" Font-Size="Small" Style="z-index: 184;
            left: 392px; position: absolute; top: 544px" Width="24px"></asp:TextBox>

        
        <asp:TextBox ID="txtTimeHoraIni_2" runat="server" Font-Size="Small" Style="z-index: 185;
            left: 440px; position: absolute; top: 544px" Width="24px"></asp:TextBox>
        <asp:TextBox ID="txtTimeMinutoIni_2" runat="server" Font-Size="Small" Style="z-index: 186;
            left: 488px; position: absolute; top: 544px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtTecnico_2" runat="server" Font-Size="Small" Style="z-index: 187;
            left: 568px; position: absolute; top: 547px" Width="120px"></asp:TextBox>
        <asp:TextBox ID="txtCalidad_2" runat="server" Font-Size="Small" Style="z-index: 188;
            left: 911px; position: absolute; top: 546px; width: 129px;"></asp:TextBox>

        <asp:TextBox ID="txtFechaIni_3" runat="server" Font-Size="Small" Style="z-index: 189;
            left: 8px; position: absolute; top: 576px" Width="96px"></asp:TextBox>
        <asp:TextBox ID="txtHoraIni_3" runat="server" Font-Size="Small" Style="z-index: 190;
            left: 136px; position: absolute; top: 576px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtMinutoIni_3" runat="server" Font-Size="Small" Style="z-index: 191;
            left: 184px; position: absolute; top: 576px" Width="24px"></asp:TextBox>
            
        <asp:TextBox ID="txtFechaFin_3" runat="server" Font-Size="Small" Style="z-index: 189;
            left: 224px; position: absolute; top: 576px" Width="88px"></asp:TextBox>
        <asp:TextBox ID="txtHoraFin_3" runat="server" Font-Size="Small" Style="z-index: 190;
            left: 344px; position: absolute; top: 576px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtMinutoFin_3" runat="server" Font-Size="Small" Style="z-index: 191;
            left: 392px; position: absolute; top: 576px" Width="24px"></asp:TextBox>
            
        <asp:TextBox ID="txtTimeHoraIni_3" runat="server" Font-Size="Small" Style="z-index: 192;
            left: 440px; position: absolute; top: 576px" Width="24px"></asp:TextBox>
        <asp:TextBox ID="txtTimeMinutoIni_3" runat="server" Font-Size="Small" Style="z-index: 193;
            left: 488px; position: absolute; top: 576px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtTecnico_3" runat="server" Font-Size="Small" Style="z-index: 194;
            left: 567px; position: absolute; top: 578px" Width="120px"></asp:TextBox>
        <asp:TextBox ID="txtCalidad_3" runat="server" Font-Size="Small" Style="z-index: 195;
            left: 910px; position: absolute; top: 577px; width: 130px;"></asp:TextBox>

        <asp:TextBox ID="txtFechaIni_4" runat="server" Font-Size="Small" Style="z-index: 196;
            left: 8px; position: absolute; top: 608px" Width="96px"></asp:TextBox>
        <asp:TextBox ID="txtHoraIni_4" runat="server" Font-Size="Small" Style="z-index: 197;
            left: 136px; position: absolute; top: 608px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtMinutoIni_4" runat="server" Font-Size="Small" Style="z-index: 198;
            left: 184px; position: absolute; top: 608px" Width="24px"></asp:TextBox>

        <asp:TextBox ID="txtFechaFin_4" runat="server" Font-Size="Small" Style="z-index: 196;
            left: 224px; position: absolute; top: 608px" Width="88px"></asp:TextBox>
        <asp:TextBox ID="txtHoraFin_4" runat="server" Font-Size="Small" Style="z-index: 197;
            left: 344px; position: absolute; top: 608px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtMinutoFin_4" runat="server" Font-Size="Small" Style="z-index: 198;
            left: 392px; position: absolute; top: 608px" Width="24px"></asp:TextBox>

        <asp:TextBox ID="txtTimeHoraIni_4" runat="server" Font-Size="Small" Style="z-index: 199;
            left: 440px; position: absolute; top: 608px" Width="24px"></asp:TextBox>
        <asp:TextBox ID="txtTimeMinutoIni_4" runat="server" Font-Size="Small" Style="z-index: 200;
            left: 488px; position: absolute; top: 608px" Width="32px"></asp:TextBox>
        <asp:TextBox ID="txtTecnico_4" runat="server" Font-Size="Small" Style="z-index: 201;
            left: 566px; position: absolute; top: 609px" Width="120px"></asp:TextBox>
        <asp:TextBox ID="txtCalidad_4" runat="server" Font-Size="Small" Style="z-index: 202;
            left: 909px; position: absolute; top: 609px; width: 130px;"></asp:TextBox>

        <asp:TextBox ID="txtComentario" runat="server" Font-Size="Small" Style="z-index: 203;
            left: 8px; position: absolute; top: 656px" Width="504px" BackColor="#FFFF80" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="txtObservacion" runat="server" Font-Size="Small" Style="z-index: 204;
            left: 536px; position: absolute; top: 656px" Width="504px" BackColor="#FFFF80"></asp:TextBox>

        <asp:CheckBoxList ID="cbl_CfrEntrega" runat="server" Font-Size="Small"
            Style="z-index: 205; left: 104px; position: absolute; top: 688px" Width="224px" Height="96px">
            <asp:ListItem>Limpieza (exterior / interio)</asp:ListItem>
            <asp:ListItem>Remoci&#243;n items cortesia</asp:ListItem>
            <asp:ListItem>Posici&#243;n espejos asistencia</asp:ListItem>
            <asp:ListItem>Ajustes reloj y radio</asp:ListItem>
        </asp:CheckBoxList>

        <asp:TextBox ID="txtFechaAviso" runat="server" Font-Size="Small" Style="z-index: 206;
            left: 112px; position: absolute; top: 792px" Width="120px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtHoraAviso" runat="server" Font-Size="Small" Style="z-index: 207;
            left: 256px; position: absolute; top: 792px" Width="24px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtMinutoAviso" runat="server" Font-Size="Small" Style="z-index: 208;
            left: 296px; position: absolute; top: 792px" Width="24px" BackColor="RoyalBlue"></asp:TextBox>

            <asp:CheckBoxList ID="cbl_CfrExplicacion_1" runat="server" Font-Size="Small"
            Style="z-index: 209; left: 104px; position: absolute; top: 816px" Width="144px" Height="96px">
                <asp:ListItem>Detalles trabajo</asp:ListItem>
                <asp:ListItem>Explicaci&#243;n precios</asp:ListItem>
                <asp:ListItem>Confirmar resultado</asp:ListItem>
                <asp:ListItem>Walkaround</asp:ListItem>
            </asp:CheckBoxList>
            <asp:CheckBoxList ID="cbl_CfrExplicacion_2" runat="server" Font-Size="Small"
            Style="z-index: 210; left: 248px; position: absolute; top: 816px" Width="136px" Height="96px">
                <asp:ListItem>Arreglado</asp:ListItem>
                <asp:ListItem>Llenado fluidos</asp:ListItem>
                <asp:ListItem>PSFU (planeaci&#243;n)</asp:ListItem>
            </asp:CheckBoxList>

        <asp:TextBox ID="txtCfrFechaEntrega" runat="server" Font-Size="Small" Style="z-index: 211;
            left: 144px; position: absolute; top: 920px" Width="88px" 
            BackColor="RoyalBlue" Enabled="False"></asp:TextBox>
        <asp:TextBox ID="txtCfrHoraEntrega" runat="server" Font-Size="Small" Style="z-index: 212;
            left: 251px; position: absolute; top: 920px" Width="32px" 
            BackColor="RoyalBlue" Enabled="False"></asp:TextBox>
        <asp:TextBox ID="txtCfrMinutoEntrega" runat="server" Font-Size="Small" Style="z-index: 213;
            left: 296px; position: absolute; top: 920px" Width="24px" 
            BackColor="RoyalBlue" Enabled="False"></asp:TextBox>

        <asp:RadioButtonList ID="rbl_Cfr_Cliente" runat="server" Font-Size="Small" Height="24px"
            RepeatDirection="Horizontal" Style="z-index: 215; left: 105px; position: absolute;
            top: 944px; width: 198px;">
            <asp:ListItem>Propietario</asp:ListItem>
            <asp:ListItem>Familia</asp:ListItem>
            <asp:ListItem>Otro</asp:ListItem>
        </asp:RadioButtonList>

        <asp:TextBox ID="txtCfrClienteOtro" runat="server" Font-Size="Small" Style="z-index: 215;
            left: 321px; position: absolute; top: 946px; width: 199px;" 
            BackColor="RoyalBlue"></asp:TextBox>

        <asp:TextBox ID="txtCfrConfirmadoPor" runat="server" Font-Size="Small" Style="z-index: 216;
            left: 336px; position: absolute; top: 760px" Width="184px" BackColor="RoyalBlue"></asp:TextBox>

        <asp:TextBox ID="txtCfrNombre1" runat="server" Font-Size="Small" Style="z-index: 217;
            left: 336px; position: absolute; top: 712px" Width="184px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtCfrNombre2" runat="server" Font-Size="Small" Style="z-index: 218;
            left: 384px; position: absolute; top: 792px" Width="136px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtCfrNombre3" runat="server" Font-Size="Small" Style="z-index: 219;
            left: 384px; position: absolute; top: 872px" Width="136px" Height="16px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtCfrNombre4" runat="server" Font-Size="Small" Style="z-index: 220;
            left: 384px; position: absolute; top: 920px" Width="136px" BackColor="RoyalBlue"></asp:TextBox>

        <asp:TextBox ID="txtPlanFechaPSFU" runat="server" Font-Size="Small" Style="z-index: 221;
            left: 688px; position: absolute; top: 689px" Width="120px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtPlanHoraPSFU" runat="server" Font-Size="Small" Style="z-index: 222;
            left: 928px; position: absolute; top: 689px" Width="32px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtPlanMinutoPSFU" runat="server" Font-Size="Small" Style="z-index: 223;
            left: 1000px; position: absolute; top: 689px" Width="32px" BackColor="RoyalBlue"></asp:TextBox>

        <asp:CheckBoxList ID="cbl_InfContacto" runat="server" Font-Size="Small"
            Style="z-index: 224; left: 632px; position: absolute; top: 712px" Width="96px" Height="72px">
            <asp:ListItem>Nro tel&#233;fono</asp:ListItem>
            <asp:ListItem>E-mail</asp:ListItem>
            <asp:ListItem>Otro</asp:ListItem>
        </asp:CheckBoxList>
        <asp:RadioButtonList ID="rbl_Info_2" runat="server" Font-Size="Small" Height="24px"
            RepeatDirection="Horizontal" Style="z-index: 225; left: 865px; position: absolute;
            top: 712px; width: 185px;">
            <asp:ListItem>Casa</asp:ListItem>
            <asp:ListItem>Trabajo</asp:ListItem>
            <asp:ListItem>Celular</asp:ListItem>
        </asp:RadioButtonList>

        <asp:TextBox ID="txtTelefono_2" runat="server" Font-Size="Small" Style="z-index: 226;
            left: 736px; position: absolute; top: 716px" Width="128px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtEmail_2" runat="server" Font-Size="Small" Style="z-index: 227;
            left: 736px; position: absolute; top: 739px" Width="304px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtOtro_2" runat="server" Font-Size="Small" Style="z-index: 228;
            left: 736px; position: absolute; top: 763px" Width="304px" BackColor="RoyalBlue"></asp:TextBox>

        <asp:TextBox ID="txtRealFechaPSFU" runat="server" Font-Size="Small" Style="z-index: 229;
            left: 696px; position: absolute; top: 792px" Width="120px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtRealHoraPSFU" runat="server" Font-Size="Small" Style="z-index: 230;
            left: 928px; position: absolute; top: 792px" Width="24px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtRealMinutoPSFU" runat="server" Font-Size="Small" Style="z-index: 231;
            left: 992px; position: absolute; top: 792px" Width="32px" BackColor="RoyalBlue"></asp:TextBox>

        <asp:RadioButtonList ID="rbl_PSFU_Cliente" runat="server" Font-Size="Small" Height="24px"
            RepeatDirection="Horizontal" Style="z-index: 232; left: 632px; position: absolute;
            top: 818px; width: 213px;">
            <asp:ListItem>Propietario</asp:ListItem>
            <asp:ListItem>Familia</asp:ListItem>
            <asp:ListItem>Otro</asp:ListItem>
        </asp:RadioButtonList>

        <asp:TextBox ID="txtPSFUClienteOtro" runat="server" Font-Size="Small" Style="z-index: 233;
            left: 856px; position: absolute; top: 818px" Width="184px" BackColor="RoyalBlue"></asp:TextBox>

        <asp:CheckBoxList ID="cbl_PSFUcontacto" runat="server" Font-Size="Small"
            Style="z-index: 234; left: 632px; position: absolute; top: 840px" Width="248px" Height="48px">
            <asp:ListItem>Arreglado</asp:ListItem>
            <asp:ListItem>Status Seguimiento (Llamar nuevamente)</asp:ListItem>
            <asp:ListItem>No Arreglado (Cita para trabajo repetido)</asp:ListItem>
        </asp:CheckBoxList>

        <asp:TextBox ID="txtFechaLLamar" runat="server" Font-Size="Small" Style="z-index: 233;
            left: 888px; position: absolute; top: 864px" Width="72px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtHoraLLamar" runat="server" Font-Size="Small" Style="z-index: 233;
            left: 976px; position: absolute; top: 864px" Width="24px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtMinutoLLamar" runat="server" Font-Size="Small" Style="z-index: 233;
            left: 1016px; position: absolute; top: 864px" Width="24px" BackColor="RoyalBlue"></asp:TextBox>

        <asp:TextBox ID="txtFechaRepetir" runat="server" Font-Size="Small" Style="z-index: 233;
            left: 888px; position: absolute; top: 888px" Width="72px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtHoraRepetir" runat="server" Font-Size="Small" Style="z-index: 233;
            left: 976px; position: absolute; top: 888px" Width="24px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtMinutoRepetir" runat="server" Font-Size="Small" Style="z-index: 233;
            left: 1016px; position: absolute; top: 888px" Width="24px" BackColor="RoyalBlue"></asp:TextBox>
        
        <asp:TextBox ID="txtPSFUnombre" runat="server" Font-Size="Small" Style="z-index: 233;
            left: 536px; position: absolute; top: 944px" Width="232px" BackColor="RoyalBlue"></asp:TextBox>
        <asp:TextBox ID="txtPSFUconfirma" runat="server" Font-Size="Small" Style="z-index: 233;
            left: 792px; position: absolute; top: 944px" Width="248px" BackColor="RoyalBlue"></asp:TextBox>

        
        

        <asp:CheckBoxList ID="cbl_LavaCoche" runat="server" Style="z-index: 102; left: 358px;
            position: absolute; top: 24px">
            <asp:ListItem></asp:ListItem>
        </asp:CheckBoxList>

        
        

        <asp:CheckBoxList ID="cbl_CC_1" runat="server" Font-Size="XX-Small" 
            RepeatDirection="Horizontal" Style="z-index: 102; left: 732px;
            position: absolute; top: 507px; height: 31px; width: 168px;">
            <asp:ListItem>Camino</asp:ListItem>
            <asp:ListItem>Visual</asp:ListItem>
            <asp:ListItem>Estatico</asp:ListItem>
        </asp:CheckBoxList>
        <asp:CheckBoxList ID="cbl_CC_2" runat="server" Font-Size="XX-Small" 
            RepeatDirection="Horizontal" Style="z-index: 102; left: 731px;
            position: absolute; top: 542px; height: 31px; width: 168px;">
            <asp:ListItem>Camino</asp:ListItem>
            <asp:ListItem>Visual</asp:ListItem>
            <asp:ListItem>Estatico</asp:ListItem>
        </asp:CheckBoxList>
        <asp:CheckBoxList ID="cbl_CC_3" runat="server" Font-Size="XX-Small" 
            RepeatDirection="Horizontal" Style="z-index: 102; left: 732px;
            position: absolute; top: 574px; height: 31px; width: 168px;">
            <asp:ListItem>Camino</asp:ListItem>
            <asp:ListItem>Visual</asp:ListItem>
            <asp:ListItem>Estatico</asp:ListItem>
        </asp:CheckBoxList>
        <asp:CheckBoxList ID="cbl_CC_4" runat="server" Font-Size="XX-Small" 
            RepeatDirection="Horizontal" Style="z-index: 102; left: 734px;
            position: absolute; top: 606px; height: 31px; width: 168px;">
            <asp:ListItem>Camino</asp:ListItem>
            <asp:ListItem>Visual</asp:ListItem>
            <asp:ListItem>Estatico</asp:ListItem>
        </asp:CheckBoxList>
        <asp:CheckBoxList ID="cbl_EntregaAsesor" runat="server" Style="z-index: 102; left: 105px;
            position: absolute; top: 918px" AutoPostBack="True">
            <asp:ListItem></asp:ListItem>
        </asp:CheckBoxList>

        
        

        <asp:Image ID="Image2" runat="server" ImageUrl="~/img/CuestWork_12.png" Style="z-index: 99;
            left: 0px; position: absolute; top: 0px" />


        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/CuestWork_12.png" Style="z-index: 99;
            left: 0px; position: absolute; top: 0px" />


        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/Print_32x32.png"
        Style="z-index: 102; left: 1120px; position: absolute; top: 216px" />

        <input id="Button1"  onclick="backtopage()" style="z-index: 101; left: 1114px; position: absolute; top: 80px; background-image: url('img/Next_32x32.png'); width: 34px; height: 34px;"
        type="button" runat="server" /><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/aceptar.png"
        Style="z-index: 102; left: 1120px; position: absolute; top: 128px" />
        <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="Eliminar" ImageUrl="~/img/Delete_32x32.png"
            Style="z-index: 144; left: 1120px; width: 32px; position: absolute; top: 168px;
            height: 32px" />

    </asp:Panel>

    <asp:SqlDataSource ID="SqlDataSource40" runat="server" ConnectionString="<%$ ConnectionStrings:tbCS %>"
        SelectCommand="SELECT id, idCita, USUARIO, FECHA, ID_CLIENTE, VIN, TipoTrabajo, LavaCoche, Refaccion, LLaves, Bahia, HeadFecha, Cliente, NombreModelo, Placas, FechaTermino, HoraTermino, MinutoTermino, FechaEntrega, HoraEntrega, MinutoEntrega, NoOrden, NoTrabajo, DOFU, Asesor, Modelo, Serie, Motor, Telefono_1, Email_1, Info_1_Casa, Info_1_Trabajo, Info_1_Celular, Trabajo_Adicional,Trabajo_Detencion,Trabajo_Otro,txt_Trabajo_Otro, Detalle_1, NoParte_1, Cantidad_1, Resulta_1, Detalle_2, NoParte_2, Cantidad_2, Resulta_2, Detalle_3, NoParte_3, Cantidad_3, Resulta_3, Detalle_4, NoParte_4, Cantidad_4, Resulta_4, Trabajo_1, Pieza_1, Amount_1, Stock_1, ETA_11, ETA_12, Trabajo_2, Pieza_2, Amount_2, Stock_2, ETA_21, ETA_22, Trabajo_3, Pieza_3, Amount_3, Stock_3, ETA_31, ETA_32, Trabajo_4, Pieza_4, Amount_4, Stock_4, ETA_41, ETA_42, FechaConta, HoraConta, MinutoConta, NombreConta, CambioFechaTermino, CambioHoraTermino, CambioMinutoTermino, CambioFechaEntrega, CambioHoraEntrega, CambioMinutoEntrega, FechaIni_1, HoraIni_1, MinutoIni_1, FechaFin_1, HoraFin_1, MinutoFin_1, TimeHoraIni_1, TimeMinutoIni_1, Tecnico_1, Calidad_1, FechaIni_2, HoraIni_2, MinutoIni_2, FechaFin_2, HoraFin_2, MinutoFin_2, TimeHoraIni_2, TimeMinutoIni_2, Tecnico_2, Calidad_2, FechaIni_3, HoraIni_3, MinutoIni_3, FechaFin_3, HoraFin_3, MinutoFin_3, TimeHoraIni_3, TimeMinutoIni_3, Tecnico_3, Calidad_3, FechaIni_4, HoraIni_4, MinutoIni_4, FechaFin_4, HoraFin_4, MinutoFin_4, TimeHoraIni_4, TimeMinutoIni_4, Tecnico_4, Calidad_4, Comentario, Observacion, CfrEntrega_1, CfrEntrega_2, CfrEntrega_3, CfrEntrega_4, FechaAviso, HoraAviso, MinutoAviso, CfrExplicacion_11, CfrExplicacion_12, CfrExplicacion_13, CfrExplicacion_14, CfrExplicacion_21, CfrExplicacion_22, CfrExplicacion_23, CfrExplicacion_24, CfrFechaEntrega, CfrHoraEntrega, CfrMinutoEntrega, Cfr_Cliente_1, Cfr_Cliente_2, Cfr_Cliente_3, CfrClienteOtro, CfrConfirmadoPor, CfrNombre1, CfrNombre2, CfrNombre3, CfrNombre4, PlanFechaPSFU, PlanHoraPSFU, PlanMinutoPSFU, InfContacto_1, InfContacto_2, InfContacto_3, Info_2_Casa, Info_2_Trabajo, Info_2_Celular, Telefono_2, Email_2, Otro_2, RealFechaPSFU, RealHoraPSFU, RealMinutoPSFU, PSFU_Cliente_1, PSFU_Cliente_2, PSFU_Cliente_3, PSFUClienteOtro, PSFUcontacto_1, PSFUcontacto_2, PSFUcontacto_3, FechaLLamar, HoraLLamar, MinutoLLamar, FechaRepetir, HoraRepetir, MinutoRepetir, PSFUnombre, PSFUconfirma FROM TYT_KDW_FORMATO_TRABAJO"
        InsertCommand="INSERT INTO TYT_KDW_FORMATO_TRABAJO(idCita, USUARIO, FECHA, ID_CLIENTE, VIN, TipoTrabajo, LavaCoche, Refaccion, LLaves, Bahia, HeadFecha, Cliente, NombreModelo, Placas, FechaTermino, HoraTermino, MinutoTermino, FechaEntrega, HoraEntrega, MinutoEntrega, NoOrden, NoTrabajo, DOFU, Asesor, Modelo, Serie, Motor, Telefono_1, Email_1, Info_1_Casa, Info_1_Trabajo, Info_1_Celular, Trabajo_Adicional,Trabajo_Detencion,Trabajo_Otro,txt_Trabajo_Otro, Detalle_1, NoParte_1, Cantidad_1, Resulta_1, Detalle_2, NoParte_2, Cantidad_2, Resulta_2, Detalle_3, NoParte_3, Cantidad_3, Resulta_3, Detalle_4, NoParte_4, Cantidad_4, Resulta_4, Trabajo_1, Pieza_1, Amount_1, Stock_1, ETA_11, ETA_12, Trabajo_2, Pieza_2, Amount_2, Stock_2, ETA_21, ETA_22, Trabajo_3, Pieza_3, Amount_3, Stock_3, ETA_31, ETA_32, Trabajo_4, Pieza_4, Amount_4, Stock_4, ETA_41, ETA_42, FechaConta, HoraConta, MinutoConta, NombreConta, CambioFechaTermino, CambioHoraTermino, CambioMinutoTermino, CambioFechaEntrega, CambioHoraEntrega, CambioMinutoEntrega, FechaIni_1, HoraIni_1, MinutoIni_1, FechaFin_1, HoraFin_1, MinutoFin_1, TimeHoraIni_1, TimeMinutoIni_1, Tecnico_1, Calidad_1, FechaIni_2, HoraIni_2, MinutoIni_2, FechaFin_2, HoraFin_2, MinutoFin_2, TimeHoraIni_2, TimeMinutoIni_2, Tecnico_2, Calidad_2, FechaIni_3, HoraIni_3, MinutoIni_3, FechaFin_3, HoraFin_3, MinutoFin_3, TimeHoraIni_3, TimeMinutoIni_3, Tecnico_3, Calidad_3, FechaIni_4, HoraIni_4, MinutoIni_4, FechaFin_4, HoraFin_4, MinutoFin_4, TimeHoraIni_4, TimeMinutoIni_4, Tecnico_4, Calidad_4, Comentario, Observacion, CfrEntrega_1, CfrEntrega_2, CfrEntrega_3, CfrEntrega_4, FechaAviso, HoraAviso, MinutoAviso, CfrExplicacion_11, CfrExplicacion_12, CfrExplicacion_13, CfrExplicacion_14, CfrExplicacion_21, CfrExplicacion_22, CfrExplicacion_23, CfrExplicacion_24, CfrFechaEntrega, CfrHoraEntrega, CfrMinutoEntrega, Cfr_Cliente_1, Cfr_Cliente_2, Cfr_Cliente_3, CfrClienteOtro, CfrConfirmadoPor, CfrNombre1, CfrNombre2, CfrNombre3, CfrNombre4, PlanFechaPSFU, PlanHoraPSFU, PlanMinutoPSFU, InfContacto_1, InfContacto_2, InfContacto_3, Info_2_Casa, Info_2_Trabajo, Info_2_Celular, Telefono_2, Email_2, Otro_2, RealFechaPSFU, RealHoraPSFU, RealMinutoPSFU, PSFU_Cliente_1, PSFU_Cliente_2, PSFU_Cliente_3, PSFUClienteOtro, PSFUcontacto_1, PSFUcontacto_2, PSFUcontacto_3, FechaLLamar, HoraLLamar, MinutoLLamar, FechaRepetir, HoraRepetir, MinutoRepetir, PSFUnombre, PSFUconfirma) VALUES (@idCita, @USUARIO, @FECHA, @ID_CLIENTE, @VIN, @TipoTrabajo, @LavaCoche, @Refaccion, @LLaves, @Bahia, @HeadFecha, @Cliente, @NombreModelo, @Placas, @FechaTermino, @HoraTermino, @MinutoTermino, @FechaEntrega, @HoraEntrega, @MinutoEntrega, @NoOrden, @NoTrabajo, @DOFU, @Asesor, @Modelo, @Serie, @Motor, @Telefono_1, @Email_1, @Info_1_Casa, @Info_1_Trabajo, @Info_1_Celular, @Trabajo_Adicional, @Trabajo_Detencion, @Trabajo_Otro, @txt_Trabajo_Otro, @Detalle_1, @NoParte_1, @Cantidad_1, @Resulta_1, @Detalle_2, @NoParte_2, @Cantidad_2, @Resulta_2, @Detalle_3, @NoParte_3, @Cantidad_3, @Resulta_3, @Detalle_4, @NoParte_4, @Cantidad_4, @Resulta_4, @Trabajo_1, @Pieza_1, @Amount_1, @Stock_1, @ETA_11, @ETA_12, @Trabajo_2, @Pieza_2, @Amount_2, @Stock_2, @ETA_21, @ETA_22, @Trabajo_3, @Pieza_3, @Amount_3, @Stock_3, @ETA_31, @ETA_32, @Trabajo_4, @Pieza_4, @Amount_4, @Stock_4, @ETA_41, @ETA_42, @FechaConta, @HoraConta, @MinutoConta, @NombreConta, @CambioFechaTermino, @CambioHoraTermino, @CambioMinutoTermino, @CambioFechaEntrega, @CambioHoraEntrega, @CambioMinutoEntrega, @FechaIni_1, @HoraIni_1, @MinutoIni_1, @FechaFin_1, @HoraFin_1, @MinutoFin_1, @TimeHoraIni_1, @TimeMinutoIni_1, @Tecnico_1, @Calidad_1, @FechaIni_2, @HoraIni_2, @MinutoIni_2, @FechaFin_2, @HoraFin_2, @MinutoFin_2, @TimeHoraIni_2, @TimeMinutoIni_2, @Tecnico_2, @Calidad_2, @FechaIni_3, @HoraIni_3, @MinutoIni_3, @FechaFin_3, @HoraFin_3, @MinutoFin_3, @TimeHoraIni_3, @TimeMinutoIni_3, @Tecnico_3, @Calidad_3, @FechaIni_4, @HoraIni_4, @MinutoIni_4, @FechaFin_4, @HoraFin_4, @MinutoFin_4, @TimeHoraIni_4, @TimeMinutoIni_4, @Tecnico_4, @Calidad_4, @Comentario, @Observacion, @CfrEntrega_1, @CfrEntrega_2, @CfrEntrega_3, @CfrEntrega_4, @FechaAviso, @HoraAviso, @MinutoAviso, @CfrExplicacion_11, @CfrExplicacion_12, @CfrExplicacion_13, @CfrExplicacion_14, @CfrExplicacion_21, @CfrExplicacion_22, @CfrExplicacion_23, @CfrExplicacion_24, @CfrFechaEntrega, @CfrHoraEntrega, @CfrMinutoEntrega, @Cfr_Cliente_1, @Cfr_Cliente_2, @Cfr_Cliente_3, @CfrClienteOtro, @CfrConfirmadoPor, @CfrNombre1, @CfrNombre2, @CfrNombre3, @CfrNombre4, @PlanFechaPSFU, @PlanHoraPSFU, @PlanMinutoPSFU, @InfContacto_1, @InfContacto_2, @InfContacto_3, @Info_2_Casa, @Info_2_Trabajo, @Info_2_Celular, @Telefono_2, @Email_2, @Otro_2, @RealFechaPSFU, @RealHoraPSFU, @RealMinutoPSFU, @PSFU_Cliente_1, @PSFU_Cliente_2, @PSFU_Cliente_3, @PSFUClienteOtro, @PSFUcontacto_1, @PSFUcontacto_2, @PSFUcontacto_3, @FechaLLamar, @HoraLLamar, @MinutoLLamar, @FechaRepetir, @HoraRepetir, @MinutoRepetir, @PSFUnombre, @PSFUconfirma)"
        UpdateCommand="UPDATE TYT_KDW_FORMATO_TRABAJO SET USUARIO=@USUARIO, FECHA=@FECHA, ID_CLIENTE=@ID_CLIENTE, VIN=@VIN, TipoTrabajo=@TipoTrabajo, LavaCoche=@LavaCoche, Refaccion=@Refaccion, LLaves=@LLaves, Bahia=@Bahia, HeadFecha=@HeadFecha, Cliente=@Cliente, NombreModelo=@NombreModelo, Placas=@Placas, FechaTermino=@FechaTermino, HoraTermino=@HoraTermino, MinutoTermino=@MinutoTermino, FechaEntrega=@FechaEntrega, HoraEntrega=@HoraEntrega, MinutoEntrega=@MinutoEntrega, NoOrden=@NoOrden, NoTrabajo=@NoTrabajo, DOFU=@DOFU, Asesor=@Asesor, Modelo=@Modelo, Serie=@Serie, Motor=@Motor, Telefono_1=@Telefono_1, Email_1=@Email_1, Info_1_Casa=@Info_1_Casa, Info_1_Trabajo=@Info_1_Trabajo, Info_1_Celular=@Info_1_Celular, Trabajo_Adicional=@Trabajo_Adicional, Trabajo_Detencion=@Trabajo_Detencion, Trabajo_Otro=@Trabajo_Otro, txt_Trabajo_Otro=@txt_Trabajo_Otro, Detalle_1=@Detalle_1, NoParte_1=@NoParte_1, Cantidad_1=@Cantidad_1, Resulta_1=@Resulta_1, Detalle_2=@Detalle_2, NoParte_2=@NoParte_2, Cantidad_2=@Cantidad_2, Resulta_2=@Resulta_2, Detalle_3=@Detalle_3, NoParte_3=@NoParte_3, Cantidad_3=@Cantidad_3, Resulta_3=@Resulta_3, Detalle_4=@Detalle_4, NoParte_4=@NoParte_4, Cantidad_4=@Cantidad_4, Resulta_4=@Resulta_4, Trabajo_1=@Trabajo_1, Pieza_1=@Pieza_1, Amount_1=@Amount_1, Costo_1=@Costo_1, Stock_1=@Stock_1, ETA_11=@ETA_11, ETA_12=@ETA_12, Trabajo_2=@Trabajo_2, Pieza_2=@Pieza_2, Amount_2=@Amount_2, Costo_2=@Costo_2, Stock_2=@Stock_2, ETA_21=@ETA_21, ETA_22=@ETA_22, Trabajo_3=@Trabajo_3, Pieza_3=@Pieza_3, Amount_3=@Amount_3, Costo_3=@Costo_3, Stock_3=@Stock_3, ETA_31=@ETA_31, ETA_32=@ETA_32, Trabajo_4=@Trabajo_4, Pieza_4=@Pieza_4, Amount_4=@Amount_4, Costo_4=@Costo_4, Costo_5=@Costo_5, Stock_4=@Stock_4, ETA_41=@ETA_41, ETA_42=@ETA_42, FechaConta=@FechaConta, HoraConta=@HoraConta, MinutoConta=@MinutoConta, NombreConta=@NombreConta, CambioFechaTermino=@CambioFechaTermino, CambioHoraTermino=@CambioHoraTermino, CambioMinutoTermino=@CambioMinutoTermino, CambioFechaEntrega=@CambioFechaEntrega, CambioHoraEntrega=@CambioHoraEntrega, CambioMinutoEntrega=@CambioMinutoEntrega, FechaIni_1=@FechaIni_1, HoraIni_1=@HoraIni_1, MinutoIni_1=@MinutoIni_1, FechaFin_1=@FechaFin_1, HoraFin_1=@HoraFin_1, MinutoFin_1=@MinutoFin_1, TimeHoraIni_1=@TimeHoraIni_1, TimeMinutoIni_1=@TimeMinutoIni_1, Tecnico_1=@Tecnico_1, ControlCalidad_11=@ControlCalidad_11, ControlCalidad_12=@ControlCalidad_12, ControlCalidad_13=@ControlCalidad_13, Calidad_1=@Calidad_1, FechaIni_2=@FechaIni_2, HoraIni_2=@HoraIni_2, MinutoIni_2=@MinutoIni_2, FechaFin_2=@FechaFin_2, HoraFin_2=@HoraFin_2, MinutoFin_2=@MinutoFin_2, TimeHoraIni_2=@TimeHoraIni_2, TimeMinutoIni_2=@TimeMinutoIni_2, Tecnico_2=@Tecnico_2,  ControlCalidad_21=@ControlCalidad_21, ControlCalidad_22=@ControlCalidad_22, ControlCalidad_23=@ControlCalidad_23, Calidad_2=@Calidad_2, FechaIni_3=@FechaIni_3, HoraIni_3=@HoraIni_3, MinutoIni_3=@MinutoIni_3, FechaFin_3=@FechaFin_3, HoraFin_3=@HoraFin_3, MinutoFin_3=@MinutoFin_3, TimeHoraIni_3=@TimeHoraIni_3, TimeMinutoIni_3=@TimeMinutoIni_3, Tecnico_3=@Tecnico_3,  ControlCalidad_31=@ControlCalidad_31, ControlCalidad_32=@ControlCalidad_32, ControlCalidad_33=@ControlCalidad_33, Calidad_3=@Calidad_3, FechaIni_4=@FechaIni_4, HoraIni_4=@HoraIni_4, MinutoIni_4=@MinutoIni_4, FechaFin_4=@FechaFin_4, HoraFin_4=@HoraFin_4, MinutoFin_4=@MinutoFin_4, TimeHoraIni_4=@TimeHoraIni_4, TimeMinutoIni_4=@TimeMinutoIni_4, Tecnico_4=@Tecnico_4,  ControlCalidad_41=@ControlCalidad_41, ControlCalidad_42=@ControlCalidad_42, ControlCalidad_43=@ControlCalidad_43, Calidad_4=@Calidad_4, Comentario=@Comentario, Observacion=@Observacion, CfrEntrega_1=@CfrEntrega_1, CfrEntrega_2=@CfrEntrega_2, CfrEntrega_3=@CfrEntrega_3, CfrEntrega_4=@CfrEntrega_4, FechaAviso=@FechaAviso, HoraAviso=@HoraAviso, MinutoAviso=@MinutoAviso, CfrExplicacion_11=@CfrExplicacion_11, CfrExplicacion_12=@CfrExplicacion_12, CfrExplicacion_13=@CfrExplicacion_13, CfrExplicacion_14=@CfrExplicacion_14, CfrExplicacion_21=@CfrExplicacion_21, CfrExplicacion_22=@CfrExplicacion_22, CfrExplicacion_23=@CfrExplicacion_23, CfrExplicacion_24=@CfrExplicacion_24, CfrFechaEntrega_1=@CfrFechaEntrega_1, CfrFechaEntrega=@CfrFechaEntrega, CfrHoraEntrega=@CfrHoraEntrega, CfrMinutoEntrega=@CfrMinutoEntrega, Cfr_Cliente_1=@Cfr_Cliente_1, Cfr_Cliente_2=@Cfr_Cliente_2, Cfr_Cliente_3=@Cfr_Cliente_3, CfrClienteOtro=@CfrClienteOtro, CfrConfirmadoPor=@CfrConfirmadoPor, CfrNombre1=@CfrNombre1, CfrNombre2=@CfrNombre2, CfrNombre3=@CfrNombre3, CfrNombre4=@CfrNombre4, PlanFechaPSFU=@PlanFechaPSFU, PlanHoraPSFU=@PlanHoraPSFU, PlanMinutoPSFU=@PlanMinutoPSFU, InfContacto_1=@InfContacto_1, InfContacto_2=@InfContacto_2, InfContacto_3=@InfContacto_3, Info_2_Casa=@Info_2_Casa, Info_2_Trabajo=@Info_2_Trabajo, Info_2_Celular=@Info_2_Celular, Telefono_2=@Telefono_2, Email_2=@Email_2, Otro_2=@Otro_2, RealFechaPSFU=@RealFechaPSFU, RealHoraPSFU=@RealHoraPSFU, RealMinutoPSFU=@RealMinutoPSFU, PSFU_Cliente_1=@PSFU_Cliente_1, PSFU_Cliente_2=@PSFU_Cliente_2, PSFU_Cliente_3=@PSFU_Cliente_3, PSFUClienteOtro=@PSFUClienteOtro, PSFUcontacto_1=@PSFUcontacto_1, PSFUcontacto_2=@PSFUcontacto_2, PSFUcontacto_3=@PSFUcontacto_3, FechaLLamar=@FechaLLamar, HoraLLamar=@HoraLLamar, MinutoLLamar=@MinutoLLamar, FechaRepetir=@FechaRepetir, HoraRepetir=@HoraRepetir, MinutoRepetir=@MinutoRepetir, PSFUnombre=@PSFUnombre, PSFUconfirma=@PSFUconfirma WHERE idCita = @idCita" DeleteCommand="DELETE FROM TYT_KDW_FORMATO_TRABAJO WHERE idCita = @idCita">
        <InsertParameters>
            <asp:SessionParameter Name="idCita" SessionField="idCita" />
            <asp:SessionParameter Name="USUARIO" SessionField="USUARIO" />
            <asp:SessionParameter Name="FECHA" SessionField="FECHA" />
            <asp:SessionParameter Name="ID_CLIENTE" SessionField="ID_CLIENTE" />
            <asp:SessionParameter Name="VIN" SessionField="VIN" />
            <asp:SessionParameter Name="TipoTrabajo" SessionField="TipoTrabajo" />
            <asp:SessionParameter Name="LavaCoche" SessionField="LavaCoche" />
            <asp:SessionParameter Name="Refaccion" SessionField="Refaccion" />
            <asp:SessionParameter Name="LLaves" SessionField="LLaves" />
            <asp:SessionParameter Name="Bahia" SessionField="Bahia" />
            <asp:SessionParameter Name="HeadFecha" SessionField="HeadFecha" />
            <asp:SessionParameter Name="Cliente" SessionField="Cliente" />
            <asp:SessionParameter Name="NombreModelo" SessionField="NombreModelo" />
            <asp:SessionParameter Name="Placas" SessionField="Placas" />
            <asp:SessionParameter Name="FechaTermino" SessionField="FechaTermino" />
            <asp:SessionParameter Name="HoraTermino" SessionField="HoraTermino" />
            <asp:SessionParameter Name="MinutoTermino" SessionField="MinutoTermino" />
            <asp:SessionParameter Name="FechaEntrega" SessionField="FechaEntrega" />
            <asp:SessionParameter Name="HoraEntrega" SessionField="HoraEntrega" />
            <asp:SessionParameter Name="MinutoEntrega" SessionField="MinutoEntrega" />
            <asp:SessionParameter Name="NoOrden" SessionField="NoOrden" />
            <asp:SessionParameter Name="NoTrabajo" SessionField="NoTrabajo" />
            <asp:SessionParameter Name="DOFU" SessionField="DOFU" />
            <asp:SessionParameter Name="Asesor" SessionField="Asesor" />
            <asp:SessionParameter Name="Modelo" SessionField="Modelo" />
            <asp:SessionParameter Name="Serie" SessionField="Serie" />
            <asp:SessionParameter Name="Motor" SessionField="Motor" />
            <asp:SessionParameter Name="Telefono_1" SessionField="Telefono_1" />
            <asp:SessionParameter Name="Email_1" SessionField="Email_1" />
            <asp:SessionParameter Name="Info_1_Casa" SessionField="Info_1_Casa" />
            <asp:SessionParameter Name="Info_1_Trabajo" SessionField="Info_1_Trabajo" />
            <asp:SessionParameter Name="Info_1_Celular" SessionField="Info_1_Celular" />
            <asp:SessionParameter Name="Trabajo_Adicional" SessionField="Trabajo_Adicional" />
            <asp:SessionParameter Name="Trabajo_Detencion" SessionField="Trabajo_Detencion" />
            <asp:SessionParameter Name="Trabajo_Otro" SessionField="Trabajo_Otro" />
            <asp:SessionParameter Name="txt_Trabajo_Otro" SessionField="txt_Trabajo_Otro" />
            <asp:SessionParameter Name="Detalle_1" SessionField="Detalle_1" />
            <asp:SessionParameter Name="NoParte_1" SessionField="NoParte_1" />
            <asp:SessionParameter Name="Cantidad_1" SessionField="Cantidad_1" />
            <asp:SessionParameter Name="Resulta_1" SessionField="Resulta_1" />
            <asp:SessionParameter Name="Detalle_2" SessionField="Detalle_2" />
            <asp:SessionParameter Name="NoParte_2" SessionField="NoParte_2" />
            <asp:SessionParameter Name="Cantidad_2" SessionField="Cantidad_2" />
            <asp:SessionParameter Name="Resulta_2" SessionField="Resulta_2" />
            <asp:SessionParameter Name="Detalle_3" SessionField="Detalle_3" />
            <asp:SessionParameter Name="NoParte_3" SessionField="NoParte_3" />
            <asp:SessionParameter Name="Cantidad_3" SessionField="Cantidad_3" />
            <asp:SessionParameter Name="Resulta_3" SessionField="Resulta_3" />
            <asp:SessionParameter Name="Detalle_4" SessionField="Detalle_4" />
            <asp:SessionParameter Name="NoParte_4" SessionField="NoParte_4" />
            <asp:SessionParameter Name="Cantidad_4" SessionField="Cantidad_4" />
            <asp:SessionParameter Name="Resulta_4" SessionField="Resulta_4" />
            <asp:SessionParameter Name="Trabajo_1" SessionField="Trabajo_1" />
            <asp:SessionParameter Name="Pieza_1" SessionField="Pieza_1" />
            <asp:SessionParameter Name="Amount_1" SessionField="Amount_1" />
            <asp:SessionParameter Name="Costo_1" SessionField="Costo_1" />
            <asp:SessionParameter Name="Stock_1" SessionField="Stock_1" />
            <asp:SessionParameter Name="ETA_11" SessionField="ETA_11" />
            <asp:SessionParameter Name="ETA_12" SessionField="ETA_12" />
            <asp:SessionParameter Name="Trabajo_2" SessionField="Trabajo_2" />
            <asp:SessionParameter Name="Pieza_2" SessionField="Pieza_2" />
            <asp:SessionParameter Name="Amount_2" SessionField="Amount_2" />
            <asp:SessionParameter Name="Costo_2" SessionField="Costo_2" />
            <asp:SessionParameter Name="Stock_2" SessionField="Stock_2" />
            <asp:SessionParameter Name="ETA_21" SessionField="ETA_21" />
            <asp:SessionParameter Name="ETA_22" SessionField="ETA_22" />
            <asp:SessionParameter Name="Trabajo_3" SessionField="Trabajo_3" />
            <asp:SessionParameter Name="Pieza_3" SessionField="Pieza_3" />
            <asp:SessionParameter Name="Amount_3" SessionField="Amount_3" />
            <asp:SessionParameter Name="Costo_3" SessionField="Costo_3" />
            <asp:SessionParameter Name="Stock_3" SessionField="Stock_3" />
            <asp:SessionParameter Name="ETA_31" SessionField="ETA_31" />
            <asp:SessionParameter Name="ETA_32" SessionField="ETA_32" />
            <asp:SessionParameter Name="Trabajo_4" SessionField="Trabajo_4" />
            <asp:SessionParameter Name="Pieza_4" SessionField="Pieza_4" />
            <asp:SessionParameter Name="Amount_4" SessionField="Amount_4" />
            <asp:SessionParameter Name="Costo_4" SessionField="Costo_4" />
            <asp:SessionParameter Name="Costo_5" SessionField="Costo_5" />
            <asp:SessionParameter Name="Stock_4" SessionField="Stock_4" />
            <asp:SessionParameter Name="ETA_41" SessionField="ETA_41" />
            <asp:SessionParameter Name="ETA_42" SessionField="ETA_42" />
            <asp:SessionParameter Name="FechaConta" SessionField="FechaConta" />
            <asp:SessionParameter Name="HoraConta" SessionField="HoraConta" />
            <asp:SessionParameter Name="MinutoConta" SessionField="MinutoConta" />
            <asp:SessionParameter Name="NombreConta" SessionField="NombreConta" />
            <asp:SessionParameter Name="CambioFechaTermino" SessionField="CambioFechaTermino" />
            <asp:SessionParameter Name="CambioHoraTermino" SessionField="CambioHoraTermino" />
            <asp:SessionParameter Name="CambioMinutoTermino" SessionField="CambioMinutoTermino" />
            <asp:SessionParameter Name="CambioFechaEntrega" SessionField="CambioFechaEntrega" />
            <asp:SessionParameter Name="CambioHoraEntrega" SessionField="CambioHoraEntrega" />
            <asp:SessionParameter Name="CambioMinutoEntrega" SessionField="CambioMinutoEntrega" />
            <asp:SessionParameter Name="FechaIni_1" SessionField="FechaIni_1" />
            <asp:SessionParameter Name="HoraIni_1" SessionField="HoraIni_1" />
            <asp:SessionParameter Name="MinutoIni_1" SessionField="MinutoIni_1" />
            <asp:SessionParameter Name="FechaFin_1" SessionField="FechaFin_1" />
            <asp:SessionParameter Name="HoraFin_1" SessionField="HoraFin_1" />
            <asp:SessionParameter Name="MinutoFin_1" SessionField="MinutoFin_1" />
            <asp:SessionParameter Name="TimeHoraIni_1" SessionField="TimeHoraIni_1" />
            <asp:SessionParameter Name="TimeMinutoIni_1" SessionField="TimeMinutoIni_1" />
            <asp:SessionParameter Name="Tecnico_1" SessionField="Tecnico_1" />
            <asp:SessionParameter Name="ControlCalidad_11" SessionField="ControlCalidad_11" />
            <asp:SessionParameter Name="ControlCalidad_12" SessionField="ControlCalidad_12" />
            <asp:SessionParameter Name="ControlCalidad_13" SessionField="ControlCalidad_13" />
            <asp:SessionParameter Name="Calidad_1" SessionField="Calidad_1" />
            <asp:SessionParameter Name="FechaIni_2" SessionField="FechaIni_2" />
            <asp:SessionParameter Name="HoraIni_2" SessionField="HoraIni_2" />
            <asp:SessionParameter Name="MinutoIni_2" SessionField="MinutoIni_2" />
            <asp:SessionParameter Name="FechaFin_2" SessionField="FechaFin_2" />
            <asp:SessionParameter Name="HoraFin_2" SessionField="HoraFin_2" />
            <asp:SessionParameter Name="MinutoFin_2" SessionField="MinutoFin_2" />
            <asp:SessionParameter Name="TimeHoraIni_2" SessionField="TimeHoraIni_2" />
            <asp:SessionParameter Name="TimeMinutoIni_2" SessionField="TimeMinutoIni_2" />
            <asp:SessionParameter Name="Tecnico_2" SessionField="Tecnico_2" />
            <asp:SessionParameter Name="ControlCalidad_21" SessionField="ControlCalidad_21" />
            <asp:SessionParameter Name="ControlCalidad_22" SessionField="ControlCalidad_22" />
            <asp:SessionParameter Name="ControlCalidad_23" SessionField="ControlCalidad_23" />
            <asp:SessionParameter Name="Calidad_2" SessionField="Calidad_2" />
            <asp:SessionParameter Name="FechaIni_3" SessionField="FechaIni_3" />
            <asp:SessionParameter Name="HoraIni_3" SessionField="HoraIni_3" />
            <asp:SessionParameter Name="MinutoIni_3" SessionField="MinutoIni_3" />
            <asp:SessionParameter Name="FechaFin_3" SessionField="FechaFin_3" />
            <asp:SessionParameter Name="HoraFin_3" SessionField="HoraFin_3" />
            <asp:SessionParameter Name="MinutoFin_3" SessionField="MinutoFin_3" />
            <asp:SessionParameter Name="TimeHoraIni_3" SessionField="TimeHoraIni_3" />
            <asp:SessionParameter Name="TimeMinutoIni_3" SessionField="TimeMinutoIni_3" />
            <asp:SessionParameter Name="Tecnico_3" SessionField="Tecnico_3" />
            <asp:SessionParameter Name="ControlCalidad_31" SessionField="ControlCalidad_31" />
            <asp:SessionParameter Name="ControlCalidad_32" SessionField="ControlCalidad_32" />
            <asp:SessionParameter Name="ControlCalidad_33" SessionField="ControlCalidad_33" />
            <asp:SessionParameter Name="Calidad_3" SessionField="Calidad_3" />
            <asp:SessionParameter Name="FechaIni_4" SessionField="FechaIni_4" />
            <asp:SessionParameter Name="HoraIni_4" SessionField="HoraIni_4" />
            <asp:SessionParameter Name="MinutoIni_4" SessionField="MinutoIni_4" />
            <asp:SessionParameter Name="FechaFin_4" SessionField="FechaFin_4" />
            <asp:SessionParameter Name="HoraFin_4" SessionField="HoraFin_4" />
            <asp:SessionParameter Name="MinutoFin_4" SessionField="MinutoFin_4" />
            <asp:SessionParameter Name="TimeHoraIni_4" SessionField="TimeHoraIni_4" />
            <asp:SessionParameter Name="TimeMinutoIni_4" SessionField="TimeMinutoIni_4" />
            <asp:SessionParameter Name="Tecnico_4" SessionField="Tecnico_4" />
            <asp:SessionParameter Name="ControlCalidad_41" SessionField="ControlCalidad_41" />
            <asp:SessionParameter Name="ControlCalidad_42" SessionField="ControlCalidad_42" />
            <asp:SessionParameter Name="ControlCalidad_43" SessionField="ControlCalidad_43" />
            <asp:SessionParameter Name="Calidad_4" SessionField="Calidad_4" />
            <asp:SessionParameter Name="Comentario" SessionField="Comentario" />
            <asp:SessionParameter Name="Observacion" SessionField="Observacion" />
            <asp:SessionParameter Name="CfrEntrega_1" SessionField="CfrEntrega_1" />
            <asp:SessionParameter Name="CfrEntrega_2" SessionField="CfrEntrega_2" />
            <asp:SessionParameter Name="CfrEntrega_3" SessionField="CfrEntrega_3" />
            <asp:SessionParameter Name="CfrEntrega_4" SessionField="CfrEntrega_4" />
            <asp:SessionParameter Name="FechaAviso" SessionField="FechaAviso" />
            <asp:SessionParameter Name="HoraAviso" SessionField="HoraAviso" />
            <asp:SessionParameter Name="MinutoAviso" SessionField="MinutoAviso" />
            <asp:SessionParameter Name="CfrExplicacion_11" SessionField="CfrExplicacion_11" />
            <asp:SessionParameter Name="CfrExplicacion_12" SessionField="CfrExplicacion_12" />
            <asp:SessionParameter Name="CfrExplicacion_13" SessionField="CfrExplicacion_13" />
            <asp:SessionParameter Name="CfrExplicacion_14" SessionField="CfrExplicacion_14" />
            <asp:SessionParameter Name="CfrExplicacion_21" SessionField="CfrExplicacion_21" />
            <asp:SessionParameter Name="CfrExplicacion_22" SessionField="CfrExplicacion_22" />
            <asp:SessionParameter Name="CfrExplicacion_23" SessionField="CfrExplicacion_23" />
            <asp:SessionParameter Name="CfrExplicacion_24" SessionField="CfrExplicacion_24" />
            <asp:SessionParameter Name="CfrFechaEntrega_1" SessionField="CfrFechaEntrega_1" />
            <asp:SessionParameter Name="CfrFechaEntrega" SessionField="CfrFechaEntrega" />
            <asp:SessionParameter Name="CfrHoraEntrega" SessionField="CfrHoraEntrega" />
            <asp:SessionParameter Name="CfrMinutoEntrega" SessionField="CfrMinutoEntrega" />
            <asp:SessionParameter Name="Cfr_Cliente_1" SessionField="Cfr_Cliente_1" />
            <asp:SessionParameter Name="Cfr_Cliente_2" SessionField="Cfr_Cliente_2" />
            <asp:SessionParameter Name="Cfr_Cliente_3" SessionField="Cfr_Cliente_3" />
            <asp:SessionParameter Name="CfrClienteOtro" SessionField="CfrClienteOtro" />
            <asp:SessionParameter Name="CfrConfirmadoPor" SessionField="CfrConfirmadoPor" />
            <asp:SessionParameter Name="CfrNombre1" SessionField="CfrNombre1" />
            <asp:SessionParameter Name="CfrNombre2" SessionField="CfrNombre2" />
            <asp:SessionParameter Name="CfrNombre3" SessionField="CfrNombre3" />
            <asp:SessionParameter Name="CfrNombre4" SessionField="CfrNombre4" />
            <asp:SessionParameter Name="PlanFechaPSFU" SessionField="PlanFechaPSFU" />
            <asp:SessionParameter Name="PlanHoraPSFU" SessionField="PlanHoraPSFU" />
            <asp:SessionParameter Name="PlanMinutoPSFU" SessionField="PlanMinutoPSFU" />
            <asp:SessionParameter Name="InfContacto_1" SessionField="InfContacto_1" />
            <asp:SessionParameter Name="InfContacto_2" SessionField="InfContacto_2" />
            <asp:SessionParameter Name="InfContacto_3" SessionField="InfContacto_3" />
            <asp:SessionParameter Name="Info_2_Casa" SessionField="Info_2_Casa" />
            <asp:SessionParameter Name="Info_2_Trabajo" SessionField="Info_2_Trabajo" />
            <asp:SessionParameter Name="Info_2_Celular" SessionField="Info_2_Celular" />
            <asp:SessionParameter Name="Telefono_2" SessionField="Telefono_2" />
            <asp:SessionParameter Name="Email_2" SessionField="Email_2" />
            <asp:SessionParameter Name="Otro_2" SessionField="Otro_2" />
            <asp:SessionParameter Name="RealFechaPSFU" SessionField="RealFechaPSFU" />
            <asp:SessionParameter Name="RealHoraPSFU" SessionField="RealHoraPSFU" />
            <asp:SessionParameter Name="RealMinutoPSFU" SessionField="RealMinutoPSFU" />
            <asp:SessionParameter Name="PSFU_Cliente_1" SessionField="PSFU_Cliente_1" />
            <asp:SessionParameter Name="PSFU_Cliente_2" SessionField="PSFU_Cliente_2" />
            <asp:SessionParameter Name="PSFU_Cliente_3" SessionField="PSFU_Cliente_3" />
            <asp:SessionParameter Name="PSFUClienteOtro" SessionField="PSFUClienteOtro" />
            <asp:SessionParameter Name="PSFUcontacto_1" SessionField="PSFUcontacto_1" />
            <asp:SessionParameter Name="PSFUcontacto_2" SessionField="PSFUcontacto_2" />
            <asp:SessionParameter Name="PSFUcontacto_3" SessionField="PSFUcontacto_3" />
            <asp:SessionParameter Name="FechaLLamar" SessionField="FechaLLamar" />
            <asp:SessionParameter Name="HoraLLamar" SessionField="HoraLLamar" />
            <asp:SessionParameter Name="MinutoLLamar" SessionField="MinutoLLamar" />
            <asp:SessionParameter Name="FechaRepetir" SessionField="FechaRepetir" />
            <asp:SessionParameter Name="HoraRepetir" SessionField="HoraRepetir" />
            <asp:SessionParameter Name="MinutoRepetir" SessionField="MinutoRepetir" />
            <asp:SessionParameter Name="PSFUnombre" SessionField="PSFUnombre" />
            <asp:SessionParameter Name="PSFUconfirma" SessionField="PSFUconfirma" />
        </InsertParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="idCita" SessionField="idCita" />
            <asp:SessionParameter Name="USUARIO" SessionField="USUARIO" />
            <asp:SessionParameter Name="FECHA" SessionField="FECHA" />
            <asp:SessionParameter Name="ID_CLIENTE" SessionField="ID_CLIENTE" />
            <asp:SessionParameter Name="VIN" SessionField="VIN" />
            <asp:SessionParameter Name="TipoTrabajo" SessionField="TipoTrabajo" />
            <asp:SessionParameter Name="LavaCoche" SessionField="LavaCoche" />
            <asp:SessionParameter Name="Refaccion" SessionField="Refaccion" />
            <asp:SessionParameter Name="LLaves" SessionField="LLaves" />
            <asp:SessionParameter Name="Bahia" SessionField="Bahia" />
            <asp:SessionParameter Name="HeadFecha" SessionField="HeadFecha" />
            <asp:SessionParameter Name="Cliente" SessionField="Cliente" />
            <asp:SessionParameter Name="NombreModelo" SessionField="NombreModelo" />
            <asp:SessionParameter Name="Placas" SessionField="Placas" />
            <asp:SessionParameter Name="FechaTermino" SessionField="FechaTermino" />
            <asp:SessionParameter Name="HoraTermino" SessionField="HoraTermino" />
            <asp:SessionParameter Name="MinutoTermino" SessionField="MinutoTermino" />
            <asp:SessionParameter Name="FechaEntrega" SessionField="FechaEntrega" />
            <asp:SessionParameter Name="HoraEntrega" SessionField="HoraEntrega" />
            <asp:SessionParameter Name="MinutoEntrega" SessionField="MinutoEntrega" />
            <asp:SessionParameter Name="NoOrden" SessionField="NoOrden" />
            <asp:SessionParameter Name="NoTrabajo" SessionField="NoTrabajo" />
            <asp:SessionParameter Name="DOFU" SessionField="DOFU" />
            <asp:SessionParameter Name="Asesor" SessionField="Asesor" />
            <asp:SessionParameter Name="Modelo" SessionField="Modelo" />
            <asp:SessionParameter Name="Serie" SessionField="Serie" />
            <asp:SessionParameter Name="Motor" SessionField="Motor" />
            <asp:SessionParameter Name="Telefono_1" SessionField="Telefono_1" />
            <asp:SessionParameter Name="Email_1" SessionField="Email_1" />
            <asp:SessionParameter Name="Info_1_Casa" SessionField="Info_1_Casa" />
            <asp:SessionParameter Name="Info_1_Trabajo" SessionField="Info_1_Trabajo" />
            <asp:SessionParameter Name="Info_1_Celular" SessionField="Info_1_Celular" />
            <asp:SessionParameter Name="Trabajo_Adicional" SessionField="Trabajo_Adicional" />
            <asp:SessionParameter Name="Trabajo_Detencion" SessionField="Trabajo_Detencion" />
            <asp:SessionParameter Name="Trabajo_Otro" SessionField="Trabajo_Otro" />
            <asp:SessionParameter Name="txt_Trabajo_Otro" SessionField="txt_Trabajo_Otro" />
            <asp:SessionParameter Name="Detalle_1" SessionField="Detalle_1" />
            <asp:SessionParameter Name="NoParte_1" SessionField="NoParte_1" />
            <asp:SessionParameter Name="Cantidad_1" SessionField="Cantidad_1" />
            <asp:SessionParameter Name="Resulta_1" SessionField="Resulta_1" />
            <asp:SessionParameter Name="Detalle_2" SessionField="Detalle_2" />
            <asp:SessionParameter Name="NoParte_2" SessionField="NoParte_2" />
            <asp:SessionParameter Name="Cantidad_2" SessionField="Cantidad_2" />
            <asp:SessionParameter Name="Resulta_2" SessionField="Resulta_2" />
            <asp:SessionParameter Name="Detalle_3" SessionField="Detalle_3" />
            <asp:SessionParameter Name="NoParte_3" SessionField="NoParte_3" />
            <asp:SessionParameter Name="Cantidad_3" SessionField="Cantidad_3" />
            <asp:SessionParameter Name="Resulta_3" SessionField="Resulta_3" />
            <asp:SessionParameter Name="Detalle_4" SessionField="Detalle_4" />
            <asp:SessionParameter Name="NoParte_4" SessionField="NoParte_4" />
            <asp:SessionParameter Name="Cantidad_4" SessionField="Cantidad_4" />
            <asp:SessionParameter Name="Resulta_4" SessionField="Resulta_4" />
            <asp:SessionParameter Name="Trabajo_1" SessionField="Trabajo_1" />
            <asp:SessionParameter Name="Pieza_1" SessionField="Pieza_1" />
            <asp:SessionParameter Name="Amount_1" SessionField="Amount_1" />
            <asp:SessionParameter Name="Costo_1" SessionField="Costo_1" />
            <asp:SessionParameter Name="Stock_1" SessionField="Stock_1" />
            <asp:SessionParameter Name="ETA_11" SessionField="ETA_11" />
            <asp:SessionParameter Name="ETA_12" SessionField="ETA_12" />
            <asp:SessionParameter Name="Trabajo_2" SessionField="Trabajo_2" />
            <asp:SessionParameter Name="Pieza_2" SessionField="Pieza_2" />
            <asp:SessionParameter Name="Amount_2" SessionField="Amount_2" />
            <asp:SessionParameter Name="Costo_2" SessionField="Costo_2" />
            <asp:SessionParameter Name="Stock_2" SessionField="Stock_2" />
            <asp:SessionParameter Name="ETA_21" SessionField="ETA_21" />
            <asp:SessionParameter Name="ETA_22" SessionField="ETA_22" />
            <asp:SessionParameter Name="Trabajo_3" SessionField="Trabajo_3" />
            <asp:SessionParameter Name="Pieza_3" SessionField="Pieza_3" />
            <asp:SessionParameter Name="Amount_3" SessionField="Amount_3" />
            <asp:SessionParameter Name="Costo_3" SessionField="Costo_3" />
            <asp:SessionParameter Name="Stock_3" SessionField="Stock_3" />
            <asp:SessionParameter Name="ETA_31" SessionField="ETA_31" />
            <asp:SessionParameter Name="ETA_32" SessionField="ETA_32" />
            <asp:SessionParameter Name="Trabajo_4" SessionField="Trabajo_4" />
            <asp:SessionParameter Name="Pieza_4" SessionField="Pieza_4" />
            <asp:SessionParameter Name="Amount_4" SessionField="Amount_4" />
            <asp:SessionParameter Name="Costo_4" SessionField="Costo_4" />
            <asp:SessionParameter Name="Costo_5" SessionField="Costo_5" />
            <asp:SessionParameter Name="Stock_4" SessionField="Stock_4" />
            <asp:SessionParameter Name="ETA_41" SessionField="ETA_41" />
            <asp:SessionParameter Name="ETA_42" SessionField="ETA_42" />
            <asp:SessionParameter Name="FechaConta" SessionField="FechaConta" />
            <asp:SessionParameter Name="HoraConta" SessionField="HoraConta" />
            <asp:SessionParameter Name="MinutoConta" SessionField="MinutoConta" />
            <asp:SessionParameter Name="NombreConta" SessionField="NombreConta" />
            <asp:SessionParameter Name="CambioFechaTermino" SessionField="CambioFechaTermino" />
            <asp:SessionParameter Name="CambioHoraTermino" SessionField="CambioHoraTermino" />
            <asp:SessionParameter Name="CambioMinutoTermino" SessionField="CambioMinutoTermino" />
            <asp:SessionParameter Name="CambioFechaEntrega" SessionField="CambioFechaEntrega" />
            <asp:SessionParameter Name="CambioHoraEntrega" SessionField="CambioHoraEntrega" />
            <asp:SessionParameter Name="CambioMinutoEntrega" SessionField="CambioMinutoEntrega" />
            <asp:SessionParameter Name="FechaIni_1" SessionField="FechaIni_1" />
            <asp:SessionParameter Name="HoraIni_1" SessionField="HoraIni_1" />
            <asp:SessionParameter Name="MinutoIni_1" SessionField="MinutoIni_1" />
            <asp:SessionParameter Name="FechaFin_1" SessionField="FechaFin_1" />
            <asp:SessionParameter Name="HoraFin_1" SessionField="HoraFin_1" />
            <asp:SessionParameter Name="MinutoFin_1" SessionField="MinutoFin_1" />
            <asp:SessionParameter Name="TimeHoraIni_1" SessionField="TimeHoraIni_1" />
            <asp:SessionParameter Name="TimeMinutoIni_1" SessionField="TimeMinutoIni_1" />
            <asp:SessionParameter Name="Tecnico_1" SessionField="Tecnico_1" />
            <asp:SessionParameter Name="ControlCalidad_11" SessionField="ControlCalidad_11" />
            <asp:SessionParameter Name="ControlCalidad_12" SessionField="ControlCalidad_12" />
            <asp:SessionParameter Name="ControlCalidad_13" SessionField="ControlCalidad_13" />
            <asp:SessionParameter Name="Calidad_1" SessionField="Calidad_1" />
            <asp:SessionParameter Name="FechaIni_2" SessionField="FechaIni_2" />
            <asp:SessionParameter Name="HoraIni_2" SessionField="HoraIni_2" />
            <asp:SessionParameter Name="MinutoIni_2" SessionField="MinutoIni_2" />
            <asp:SessionParameter Name="FechaFin_2" SessionField="FechaFin_2" />
            <asp:SessionParameter Name="HoraFin_2" SessionField="HoraFin_2" />
            <asp:SessionParameter Name="MinutoFin_2" SessionField="MinutoFin_2" />
            <asp:SessionParameter Name="TimeHoraIni_2" SessionField="TimeHoraIni_2" />
            <asp:SessionParameter Name="TimeMinutoIni_2" SessionField="TimeMinutoIni_2" />
            <asp:SessionParameter Name="Tecnico_2" SessionField="Tecnico_2" />
            <asp:SessionParameter Name="ControlCalidad_21" SessionField="ControlCalidad_21" />
            <asp:SessionParameter Name="ControlCalidad_22" SessionField="ControlCalidad_22" />
            <asp:SessionParameter Name="ControlCalidad_23" SessionField="ControlCalidad_23" />
            <asp:SessionParameter Name="Calidad_2" SessionField="Calidad_2" />
            <asp:SessionParameter Name="FechaIni_3" SessionField="FechaIni_3" />
            <asp:SessionParameter Name="HoraIni_3" SessionField="HoraIni_3" />
            <asp:SessionParameter Name="MinutoIni_3" SessionField="MinutoIni_3" />
            <asp:SessionParameter Name="FechaFin_3" SessionField="FechaFin_3" />
            <asp:SessionParameter Name="HoraFin_3" SessionField="HoraFin_3" />
            <asp:SessionParameter Name="MinutoFin_3" SessionField="MinutoFin_3" />
            <asp:SessionParameter Name="TimeHoraIni_3" SessionField="TimeHoraIni_3" />
            <asp:SessionParameter Name="TimeMinutoIni_3" SessionField="TimeMinutoIni_3" />
            <asp:SessionParameter Name="Tecnico_3" SessionField="Tecnico_3" />
            <asp:SessionParameter Name="ControlCalidad_31" SessionField="ControlCalidad_31" />
            <asp:SessionParameter Name="ControlCalidad_32" SessionField="ControlCalidad_32" />
            <asp:SessionParameter Name="ControlCalidad_33" SessionField="ControlCalidad_33" />
            <asp:SessionParameter Name="Calidad_3" SessionField="Calidad_3" />
            <asp:SessionParameter Name="FechaIni_4" SessionField="FechaIni_4" />
            <asp:SessionParameter Name="HoraIni_4" SessionField="HoraIni_4" />
            <asp:SessionParameter Name="MinutoIni_4" SessionField="MinutoIni_4" />
            <asp:SessionParameter Name="FechaFin_4" SessionField="FechaFin_4" />
            <asp:SessionParameter Name="HoraFin_4" SessionField="HoraFin_4" />
            <asp:SessionParameter Name="MinutoFin_4" SessionField="MinutoFin_4" />
            <asp:SessionParameter Name="TimeHoraIni_4" SessionField="TimeHoraIni_4" />
            <asp:SessionParameter Name="TimeMinutoIni_4" SessionField="TimeMinutoIni_4" />
            <asp:SessionParameter Name="Tecnico_4" SessionField="Tecnico_4" />
            <asp:SessionParameter Name="ControlCalidad_41" SessionField="ControlCalidad_41" />
            <asp:SessionParameter Name="ControlCalidad_42" SessionField="ControlCalidad_42" />
            <asp:SessionParameter Name="ControlCalidad_43" SessionField="ControlCalidad_43" />
            <asp:SessionParameter Name="Calidad_4" SessionField="Calidad_4" />
            <asp:SessionParameter Name="Comentario" SessionField="Comentario" />
            <asp:SessionParameter Name="Observacion" SessionField="Observacion" />
            <asp:SessionParameter Name="CfrEntrega_1" SessionField="CfrEntrega_1" />
            <asp:SessionParameter Name="CfrEntrega_2" SessionField="CfrEntrega_2" />
            <asp:SessionParameter Name="CfrEntrega_3" SessionField="CfrEntrega_3" />
            <asp:SessionParameter Name="CfrEntrega_4" SessionField="CfrEntrega_4" />
            <asp:SessionParameter Name="FechaAviso" SessionField="FechaAviso" />
            <asp:SessionParameter Name="HoraAviso" SessionField="HoraAviso" />
            <asp:SessionParameter Name="MinutoAviso" SessionField="MinutoAviso" />
            <asp:SessionParameter Name="CfrExplicacion_11" SessionField="CfrExplicacion_11" />
            <asp:SessionParameter Name="CfrExplicacion_12" SessionField="CfrExplicacion_12" />
            <asp:SessionParameter Name="CfrExplicacion_13" SessionField="CfrExplicacion_13" />
            <asp:SessionParameter Name="CfrExplicacion_14" SessionField="CfrExplicacion_14" />
            <asp:SessionParameter Name="CfrExplicacion_21" SessionField="CfrExplicacion_21" />
            <asp:SessionParameter Name="CfrExplicacion_22" SessionField="CfrExplicacion_22" />
            <asp:SessionParameter Name="CfrExplicacion_23" SessionField="CfrExplicacion_23" />
            <asp:SessionParameter Name="CfrExplicacion_24" SessionField="CfrExplicacion_24" />
            <asp:SessionParameter Name="CfrFechaEntrega_1" SessionField="CfrFechaEntrega_1" />
            <asp:SessionParameter Name="CfrFechaEntrega" SessionField="CfrFechaEntrega" />
            <asp:SessionParameter Name="CfrHoraEntrega" SessionField="CfrHoraEntrega" />
            <asp:SessionParameter Name="CfrMinutoEntrega" SessionField="CfrMinutoEntrega" />
            <asp:SessionParameter Name="Cfr_Cliente_1" SessionField="Cfr_Cliente_1" />
            <asp:SessionParameter Name="Cfr_Cliente_2" SessionField="Cfr_Cliente_2" />
            <asp:SessionParameter Name="Cfr_Cliente_3" SessionField="Cfr_Cliente_3" />
            <asp:SessionParameter Name="CfrClienteOtro" SessionField="CfrClienteOtro" />
            <asp:SessionParameter Name="CfrConfirmadoPor" SessionField="CfrConfirmadoPor" />
            <asp:SessionParameter Name="CfrNombre1" SessionField="CfrNombre1" />
            <asp:SessionParameter Name="CfrNombre2" SessionField="CfrNombre2" />
            <asp:SessionParameter Name="CfrNombre3" SessionField="CfrNombre3" />
            <asp:SessionParameter Name="CfrNombre4" SessionField="CfrNombre4" />
            <asp:SessionParameter Name="PlanFechaPSFU" SessionField="PlanFechaPSFU" />
            <asp:SessionParameter Name="PlanHoraPSFU" SessionField="PlanHoraPSFU" />
            <asp:SessionParameter Name="PlanMinutoPSFU" SessionField="PlanMinutoPSFU" />
            <asp:SessionParameter Name="InfContacto_1" SessionField="InfContacto_1" />
            <asp:SessionParameter Name="InfContacto_2" SessionField="InfContacto_2" />
            <asp:SessionParameter Name="InfContacto_3" SessionField="InfContacto_3" />
            <asp:SessionParameter Name="Info_2_Casa" SessionField="Info_2_Casa" />
            <asp:SessionParameter Name="Info_2_Trabajo" SessionField="Info_2_Trabajo" />
            <asp:SessionParameter Name="Info_2_Celular" SessionField="Info_2_Celular" />
            <asp:SessionParameter Name="Telefono_2" SessionField="Telefono_2" />
            <asp:SessionParameter Name="Email_2" SessionField="Email_2" />
            <asp:SessionParameter Name="Otro_2" SessionField="Otro_2" />
            <asp:SessionParameter Name="RealFechaPSFU" SessionField="RealFechaPSFU" />
            <asp:SessionParameter Name="RealHoraPSFU" SessionField="RealHoraPSFU" />
            <asp:SessionParameter Name="RealMinutoPSFU" SessionField="RealMinutoPSFU" />
            <asp:SessionParameter Name="PSFU_Cliente_1" SessionField="PSFU_Cliente_1" />
            <asp:SessionParameter Name="PSFU_Cliente_2" SessionField="PSFU_Cliente_2" />
            <asp:SessionParameter Name="PSFU_Cliente_3" SessionField="PSFU_Cliente_3" />
            <asp:SessionParameter Name="PSFUClienteOtro" SessionField="PSFUClienteOtro" />
            <asp:SessionParameter Name="PSFUcontacto_1" SessionField="PSFUcontacto_1" />
            <asp:SessionParameter Name="PSFUcontacto_2" SessionField="PSFUcontacto_2" />
            <asp:SessionParameter Name="PSFUcontacto_3" SessionField="PSFUcontacto_3" />
            <asp:SessionParameter Name="FechaLLamar" SessionField="FechaLLamar" />
            <asp:SessionParameter Name="HoraLLamar" SessionField="HoraLLamar" />
            <asp:SessionParameter Name="MinutoLLamar" SessionField="MinutoLLamar" />
            <asp:SessionParameter Name="FechaRepetir" SessionField="FechaRepetir" />
            <asp:SessionParameter Name="HoraRepetir" SessionField="HoraRepetir" />
            <asp:SessionParameter Name="MinutoRepetir" SessionField="MinutoRepetir" />
            <asp:SessionParameter Name="PSFUnombre" SessionField="PSFUnombre" />
            <asp:SessionParameter Name="PSFUconfirma" SessionField="PSFUconfirma" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:SessionParameter Name="idCita" SessionField="idCita" />
        </DeleteParameters>
        
    </asp:SqlDataSource>
    <asp:Panel ID="Panel1" runat="server" Height="32px" Style="z-index: 102; left: 408px;
        position: absolute; top: 16px" Width="296px">
        <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Instrucción de Trabajo"
            Width="293px"></asp:Label></asp:Panel>
    <asp:SqlDataSource ID="SqlDataSource_36" runat="server" ConnectionString="<%$ ConnectionStrings:tbCS %>"
        DeleteCommand="DELETE  Tb_CITAS WHERE oChip = @oChip&#13;&#10;AND YEAR(fecha) = @fechaAAAA AND MONTH(fecha) = @fechaMM AND DAY(fecha) = @fechaDD"
        ProviderName="<%$ ConnectionStrings:tbCS.ProviderName %>" SelectCommand="SELECT Cliente, noPlacas, Vehiculo, Color, Ano, Cilindros, idAsesor, horaAsesor, noOrden, horaCita, idTecnico, Servicio, horaEntrega FROM Tb_CITAS WHERE id = 0">
    </asp:SqlDataSource>
    
    </form>
    
    </body>
</html>
