


Partial Class Diagnostico

    Inherits System.Web.UI.Page

    Dim sSelCmd As String


    Public Sub Alert(ByVal oPagina As System.Web.UI.Page, ByVal sMensaje As String)

        Dim sScript As String = "<SCRIPT language='javascript'> alert('" & sMensaje & "'); </SCRIPT>"

        If Not oPagina.IsStartupScriptRegistered("Alert") Then
            oPagina.RegisterStartupScript("Alert", sScript)
        End If

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Me.IsPostBack Then
                asignaCampos()
            End If

        Catch eexc As Exception
            Session("lblError") = eexc.Message
        End Try

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        'Print
        Try

        Catch eexc As Exception
            Session("lblError") = eexc.Message
        End Try
    End Sub

    Protected Function checarCaracterEspañol(ByRef sRecord As String) As String
        Try
            Dim iPos1 As Integer
            Dim sVariable As String



            '&#209; vs Ñ
            iPos1 = InStr(sRecord, "&#209;")
            If iPos1 > 0 Then
                sVariable = Mid(sRecord, 1, iPos1 - 1) & "Ñ" & Mid(sRecord, iPos1 + 6, Len(sRecord) - iPos1)
            Else
                sVariable = sRecord
            End If

            '&#241; vs ñ
            sRecord = sVariable
            iPos1 = InStr(sRecord, "&#241;")
            If iPos1 > 0 Then
                sVariable = Mid(sRecord, 1, iPos1 - 1) & "ñ" & Mid(sRecord, iPos1 + 6, Len(sRecord) - iPos1)
            Else
                sVariable = sRecord
            End If





            '&#193; vs Á
            sRecord = sVariable
            iPos1 = InStr(sRecord, "&#193;")
            If iPos1 > 0 Then
                sVariable = Mid(sRecord, 1, iPos1 - 1) & "Á" & Mid(sRecord, iPos1 + 6, Len(sRecord) - iPos1)
            Else
                sVariable = sRecord
            End If
            '&#225; vs á
            sRecord = sVariable
            iPos1 = InStr(sRecord, "&#225;")
            If iPos1 > 0 Then
                sVariable = Mid(sRecord, 1, iPos1 - 1) & "á" & Mid(sRecord, iPos1 + 6, Len(sRecord) - iPos1)
            Else
                sVariable = sRecord
            End If



            '&#201; vs É
            sRecord = sVariable
            iPos1 = InStr(sRecord, "&#201;")
            If iPos1 > 0 Then
                sVariable = Mid(sRecord, 1, iPos1 - 1) & "É" & Mid(sRecord, iPos1 + 6, Len(sRecord) - iPos1)
            Else
                sVariable = sRecord
            End If
            '&#233; vs É
            sRecord = sVariable
            iPos1 = InStr(sRecord, "&#233;")
            If iPos1 > 0 Then
                sVariable = Mid(sRecord, 1, iPos1 - 1) & "é" & Mid(sRecord, iPos1 + 6, Len(sRecord) - iPos1)
            Else
                sVariable = sRecord
            End If


            '&#205; vs Í
            sRecord = sVariable
            iPos1 = InStr(sRecord, "&#205;")
            If iPos1 > 0 Then
                sVariable = Mid(sRecord, 1, iPos1 - 1) & "Í" & Mid(sRecord, iPos1 + 6, Len(sRecord) - iPos1)
            Else
                sVariable = sRecord
            End If
            '&#237; vs í
            sRecord = sVariable
            iPos1 = InStr(sRecord, "&#237;")
            If iPos1 > 0 Then
                sVariable = Mid(sRecord, 1, iPos1 - 1) & "í" & Mid(sRecord, iPos1 + 6, Len(sRecord) - iPos1)
            Else
                sVariable = sRecord
            End If





            '&#211; vs Ó
            sRecord = sVariable
            iPos1 = InStr(sRecord, "&#211;")
            If iPos1 > 0 Then
                sVariable = Mid(sRecord, 1, iPos1 - 1) & "Ó" & Mid(sRecord, iPos1 + 6, Len(sRecord) - iPos1)
            Else
                sVariable = sRecord
            End If
            '&#243; vs ó
            sRecord = sVariable
            iPos1 = InStr(sRecord, "&#243;")
            If iPos1 > 0 Then
                sVariable = Mid(sRecord, 1, iPos1 - 1) & "ó" & Mid(sRecord, iPos1 + 6, Len(sRecord) - iPos1)
            Else
                sVariable = sRecord
            End If



            '&#218; vs Ú
            sRecord = sVariable
            iPos1 = InStr(sRecord, "&#218;")
            If iPos1 > 0 Then
                sVariable = Mid(sRecord, 1, iPos1 - 1) & "Ú" & Mid(sRecord, iPos1 + 6, Len(sRecord) - iPos1)
            Else
                sVariable = sRecord
            End If
            '&#250; vs ú
            sRecord = sVariable
            iPos1 = InStr(sRecord, "&#250;")
            If iPos1 > 0 Then
                sVariable = Mid(sRecord, 1, iPos1 - 1) & "ú" & Mid(sRecord, iPos1 + 6, Len(sRecord) - iPos1)
            Else
                sVariable = sRecord
            End If


            'A &#193;
            'E &#201;
            'I &#205inser
            'O &#211;
            'U &#218;


            'a &#225;
            'e &#233;
            'i &#237;
            'o &#243;
            'u &#250;
            'ñ &#241;



            Return sVariable
        Catch eexc As Exception
            Session("lblError") = eexc.Message
            Return ""
        End Try

    End Function



    Protected Sub asignaCampos()

        Try

            'nombreCliente.Text = Session("Cliente_AutoSys")
            'Session("fechaDiagnostico") = Session("fecha_AutoSys")
            'Session("nombreAsesor") = Session("idAsesor_AutoSys")

            Dim gv40 As New GridView


            Dim gv_36 As New GridView

            Dim sRecord As String

            sSelCmd = "SELECT id," _
                    & "fechaRecepcion,horaRecepcion,minutoRecepcion," _
                    & "CAST(Cliente_trae AS varchar(1))AS Cliente_trae,CAST(Concesionario_recoge AS varchar(1)) AS Concesionario_recoge," _
                    & "CAST(VehiculoCortesia AS varchar(1)) AS VehiculoCortesia," _
                    & "fechaEntrega,horaEntrega,minutoEntrega," _
                    & "CAST(Cliente_retira AS varchar(1)) AS Cliente_retira,CAST(Concesionario_entrega AS varchar(1)) AS Concesionario_entrega," _
                    & "nombreCliente,direccionCliente,telefonoCliente,fechaDiagnostico,nombreAsesor,noDiagnostico,noOrden,fechaConfirmacion," _
                    & "horaConfirmacion,minutoConfirmacion,nombreConfirmacion," _
                    & "CAST(Conducido_Propietario AS varchar(1)) AS Conducido_Propietario,CAST(Conducido_Familia AS varchar(1)) AS Conducido_Familia," _
                    & "CAST(Conducido_Otro AS varchar(1)) AS Conducido_Otro," _
                    & "txtVehiculoConducido,lecturaVelocimetroCita,vehiculoPlacas,DOFU,vehiculoNombreModelo,vehiculoModelo,vehiculoNoCarroceria," _
                    & "vehiculoChasis,fenomeno1,fenomeno2,fenomeno3,telefonoContacto,horaContacto1,minutoContacto1,horaContacto2,minutoContacto2," _
                    & "nombreWalkAround,fechaWalkAround,horaWalkAround,minutoWalkAround," _
                    & "CAST(Confirma_Clt AS varchar(1)) AS Confirma_Clt," _
                    & "lecturaVeloRecibe," _
                    & "CAST(Confirma_Trabajo_adicional AS varchar(1)) AS Confirma_Trabajo_adicional,CAST(Confirma_Pertenencias AS varchar(1)) AS Confirma_Pertenencias," _
                    & "CAST(Confirma_Cubre_Asiento AS varchar(1)) AS Confirma_Cubre_Asiento,CAST(Confirma_Cubre_volante_palanca AS varchar(1)) AS Confirma_Cubre_volante_palanca," _
                    & "CAST(Confirma_Tapetes AS varchar(1)) AS Confirma_Tapetes, CAST(DesdeCuando_Recientemente AS varchar(1)) AS DesdeCuando_Recientemente," _
                    & "CAST(DesdeCuando_Hace_1_semana AS varchar(1)) AS DesdeCuando_Hace_1_semana,CAST(DesdeCuando_Otro AS varchar(1)) AS DesdeCuando_Otro," _
                    & "txtDesdeCuando," _
                    & "CAST(Frecuencia_Siempre AS varchar(1)) AS Frecuencia_Siempre,CAST(Frecuencia_Ocasionalmente AS varchar(1)) AS Frecuencia_Ocasionalmente," _
                    & "CAST(Frecuencia_Solo_1_vez AS varchar(1)) AS Frecuencia_Solo_1_vez,CAST(Frecuencia_Otro AS varchar(1)) AS Frecuencia_Otro," _
                    & "txtFrecuencia," _
                    & "CAST(Lugar_Calle AS varchar(1)) AS Lugar_Calle,CAST(Lugar_Carretera AS varchar(1)) AS Lugar_Carretera," _
                    & "CAST(Lugar_Subida AS varchar(1)) AS Lugar_Subida,CAST(Lugar_Bajada AS varchar(1)) AS Lugar_Bajada,CAST(Lugar_Trafico AS varchar(1)) AS Lugar_Trafico," _
                    & "CAST(LuzAdvierte_Prendida AS varchar(1)) AS LuzAdvierte_Prendida,CAST(LuzAdvierte_Parpadeando AS varchar(1)) AS LuzAdvierte_Parpadeando," _
                    & "CAST(LuzAdvierte_Parpadeo_multiple AS varchar(1)) AS LuzAdvierte_Parpadeo_multiple," _
                    & "txtLuzAdvierte," _
                    & "CAST(Condicion_Arranque AS varchar(1)) AS Condicion_Arranque,CAST(Condicion_Parado AS varchar(1)) AS Condicion_Parado," _
                    & "CAST(Condicion_V_K AS varchar(1)) AS Condicion_V_K,CAST(Condicion_V_no_K AS varchar(1)) AS Condicion_V_no_K," _
                    & "CAST(Condicion_Acelerando AS varchar(1)) AS Condicion_Acelerando,CAST(Condicion_Desacelerando AS varchar(1)) AS Condicion_Desacelerando," _
                    & "txtVelocimetro,txtTacometro," _
                    & "CAST(Condicion_Rebasando AS varchar(1)) AS Condicion_Rebasando,CAST(Condicion_Cambiando AS varchar(1)) AS Condicion_Cambiando," _
                    & "CAST(Condicion_Retrocediendo AS varchar(1)) AS Condicion_Retrocediendo,CAST(Condicion_Frenando AS varchar(1)) AS Condicion_Frenando," _
                    & "txtNoPersonas,txtCargaVehiculo,txtCargaRemolque," _
                    & "CAST(Superficie_Plana AS varchar(1)) AS Superficie_Plana,CAST(Superficie_Desigual AS varchar(1)) AS Superficie_Desigual," _
                    & "CAST(Superficie_Aspero AS varchar(1)) AS Superficie_Aspero,CAST(Superficie_Otro AS varchar(1)) AS Superficie_Otro," _
                    & "txtSuperficie," _
                    & "CAST(Tiempo_Despejado AS varchar(1)) AS Tiempo_Despejado,CAST(Tiempo_Nublado AS varchar(1)) AS Tiempo_Nublado," _
                    & "CAST(Tiempo_Lluvia AS varchar(1)) AS Tiempo_Lluvia,CAST(Tiempo_Nieve AS varchar(1)) AS Tiempo_Nieve," _
                    & "CAST(Tiempo_Temperatura_externa AS varchar(1)) AS Tiempo_Temperatura_externa," _
                    & "txtTemperaturaExterna," _
                    & "CAST(AC_Flujo_aire AS varchar(1)) AS AC_Flujo_aire,CAST(AC_Recirculacion AS varchar(1)) AS AC_Recirculacion," _
                    & "CAST(AC_Velocidad_ventilacion AS varchar(1)) AS AC_Velocidad_ventilacion,CAST(AC_Temperatura AS varchar(1)) AS AC_Temperatura," _
                    & "txtAC_Temperatura,detalleTrabajo1,detalleTrabajo2,detalleTrabajo3,detalleTrabajo4,nombreDiag,fechaDiag,horaDiag,minutoDiag,noLLave,noBahia," _
                    & "CAST(Resultado_Descubierto AS varchar(1)) AS Resultado_Descubierto,CAST(Resultado_Prediccion AS varchar(1)) AS Resultado_Prediccion," _
                    & "motivoResulta," _
                    & "CAST(Seguimiento AS varchar(1)) AS Seguimiento," _
                    & "causa1,causa2,causa3,causa4,DTC1,DTC2,DTC3,DTC4," _
                    & "CAST(Status1_0 AS varchar(1)) AS Status1_0," _
                    & "CAST(Status2_0 AS varchar(1)) AS Status2_0," _
                    & "CAST(Status3_0 AS varchar(1)) AS Status3_0," _
                    & "CAST(Status4_0 AS varchar(1)) AS Status4_0," _
                    & "CAST(Datos1_0 AS varchar(1)) AS Datos1_0," _
                    & "CAST(Datos2_0 AS varchar(1)) AS Datos2_0," _
                    & "CAST(Datos3_0 AS varchar(1)) AS Datos3_0," _
                    & "CAST(Datos4_0 AS varchar(1)) AS Datos4_0," _
                    & "CAST(Garantia AS varchar(1)) AS Garantia," _
                    & "instruccion1,instruccion2,instruccion3,instruccion4,fechaIniInst1,fechaIniInst2,fechaIniInst3,fechaIniInst4,horaIniInst1,minutoIniInst1,horaIniInst2," _
                    & "minutoIniInst2,horaIniInst3,minutoIniInst3,horaIniInst4,minutoIniInst4,fechaFinInst1,fechaFinInst2,fechaFinInst3,fechaFinInst4,horaFinInst1," _
                    & "minutoFinInst1,horaFinInst2,minutoFinInst2,horaFinInst3,minutoFinInst3,horaFinInst4,minutoFinInst4,horaWork1,horaWork2,horaWork3,horaWork4,minutoWork1," _
                    & "minutoWork2,minutoWork3,minutoWork4," _
                    & "CAST(DTR1 AS varchar(1)) AS DTR1,CAST(DTR2 AS varchar(1)) AS DTR2,CAST(DTR3 AS varchar(1)) AS DTR3,CAST(DTR4 AS varchar(1)) AS DTR4," _
                    & "instTec1,instCnf1,instTec2,instCnf2,instTec3,instCnf3,instTec4,instCnf4,tmexDestino,tmexRespble," _
                    & "CAST(Tmex_En_proceso AS varchar(1)) AS Tmex_En_proceso,CAST(Tmex_Planeado AS varchar(1)) AS Tmex_Planeado," _
                    & "fechaTmex,horaTmex,minutoTmex," _
                    & "CAST(StatusTmex_Recurrencia AS varchar(1)) AS StatusTmex_Recurrencia," _
                    & "CAST(StatusTmex_Dificultad_identificar_causa AS varchar(1)) AS StatusTmex_Dificultad_identificar_causa," _
                    & "CAST(StatusTmex_Reparacion_dificil AS varchar(1)) AS StatusTmex_Reparacion_dificil," _
                    & "CAST(SolicitaTmex_Verificación_vehiculo AS varchar(1)) AS SolicitaTmex_Verificación_vehiculo," _
                    & "CAST(SolicitaTmex_Historial_servicio AS varchar(1)) AS SolicitaTmex_Historial_servicio," _
                    & "CAST(SolicitaTmex_Asistencia_en_reparacion AS varchar(1)) AS SolicitaTmex_Asistencia_en_reparacion," _
                    & "CAST(SolicitaTmex_Otro AS varchar(1)) AS SolicitaTmex_Otro," _
                    & "fechaSolTmex, horaSolTmex, minutoSolTmex, nombreTmex" _
                    & " FROM TYT_KDW_FORMATO_DIAGNOSTICO WHERE idCita = " & Session("NF")


            SqlDataSource40.SelectCommand = sSelCmd



            gv40.DataSource = SqlDataSource40
            gv40.DataBind()



            If gv40.Rows.Count > 0 Then

                If gv40.Rows(0).Cells(1).Text <> "" And gv40.Rows(0).Cells(1).Text <> Nothing And gv40.Rows(0).Cells(1).Text <> "&nbsp;" Then fechaRecepcion.Text = gv40.Rows(0).Cells(1).Text
                If gv40.Rows(0).Cells(2).Text <> "" And gv40.Rows(0).Cells(2).Text <> Nothing And gv40.Rows(0).Cells(2).Text <> "&nbsp;" Then horaRecepcion.Text = gv40.Rows(0).Cells(2).Text
                If gv40.Rows(0).Cells(3).Text <> "" And gv40.Rows(0).Cells(3).Text <> Nothing And gv40.Rows(0).Cells(3).Text <> "&nbsp;" Then minutoRecepcion.Text = gv40.Rows(0).Cells(3).Text

                If Val(gv40.Rows(0).Cells(4).Text) = 1 Then rbl_CltEmpTrae.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(5).Text) = 1 Then rbl_CltEmpTrae.Items(1).Selected = True

                If Val(gv40.Rows(0).Cells(6).Text) = 1 Then cbl_VehiculoCortesia.Items(0).Selected = True

                If gv40.Rows(0).Cells(7).Text <> "" And gv40.Rows(0).Cells(7).Text <> Nothing And gv40.Rows(0).Cells(7).Text <> "&nbsp;" Then fechaEntrega.Text = gv40.Rows(0).Cells(7).Text
                If gv40.Rows(0).Cells(8).Text <> "" And gv40.Rows(0).Cells(8).Text <> Nothing And gv40.Rows(0).Cells(8).Text <> "&nbsp;" Then horaEntrega.Text = gv40.Rows(0).Cells(8).Text
                If gv40.Rows(0).Cells(9).Text <> "" And gv40.Rows(0).Cells(9).Text <> Nothing And gv40.Rows(0).Cells(9).Text <> "&nbsp;" Then minutoEntrega.Text = gv40.Rows(0).Cells(9).Text

                If Val(gv40.Rows(0).Cells(10).Text) = 1 Then rbl_CltEmpRetira.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(11).Text) = 1 Then rbl_CltEmpRetira.Items(1).Selected = True




                If gv40.Rows(0).Cells(12).Text <> "" And gv40.Rows(0).Cells(12).Text <> Nothing And gv40.Rows(0).Cells(12).Text <> "&nbsp;" Then nombreCliente.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(12).Text))
                If gv40.Rows(0).Cells(13).Text <> "" And gv40.Rows(0).Cells(13).Text <> Nothing And gv40.Rows(0).Cells(13).Text <> "&nbsp;" Then direccionCliente.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(13).Text))
                If gv40.Rows(0).Cells(14).Text <> "" And gv40.Rows(0).Cells(14).Text <> Nothing And gv40.Rows(0).Cells(14).Text <> "&nbsp;" Then telefonoCliente.Text = gv40.Rows(0).Cells(14).Text
                If gv40.Rows(0).Cells(15).Text <> "" And gv40.Rows(0).Cells(15).Text <> Nothing And gv40.Rows(0).Cells(15).Text <> "&nbsp;" Then fechaDiagnostico.Text = gv40.Rows(0).Cells(15).Text
                If gv40.Rows(0).Cells(16).Text <> "" And gv40.Rows(0).Cells(16).Text <> Nothing And gv40.Rows(0).Cells(16).Text <> "&nbsp;" Then nombreAsesor.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(16).Text))
                If gv40.Rows(0).Cells(17).Text <> "" And gv40.Rows(0).Cells(17).Text <> Nothing And gv40.Rows(0).Cells(17).Text <> "&nbsp;" Then noDiagnostico.Text = gv40.Rows(0).Cells(17).Text
                If gv40.Rows(0).Cells(18).Text <> "" And gv40.Rows(0).Cells(18).Text <> Nothing And gv40.Rows(0).Cells(18).Text <> "&nbsp;" Then noOrden.Text = gv40.Rows(0).Cells(18).Text
                If gv40.Rows(0).Cells(19).Text <> "" And gv40.Rows(0).Cells(19).Text <> Nothing And gv40.Rows(0).Cells(19).Text <> "&nbsp;" Then fechaConfirmacion.Text = gv40.Rows(0).Cells(19).Text
                If gv40.Rows(0).Cells(20).Text <> "" And gv40.Rows(0).Cells(20).Text <> Nothing And gv40.Rows(0).Cells(20).Text <> "&nbsp;" Then horaConfirmacion.Text = gv40.Rows(0).Cells(20).Text
                If gv40.Rows(0).Cells(21).Text <> "" And gv40.Rows(0).Cells(21).Text <> Nothing And gv40.Rows(0).Cells(21).Text <> "&nbsp;" Then minutoConfirmacion.Text = gv40.Rows(0).Cells(21).Text
                If gv40.Rows(0).Cells(22).Text <> "" And gv40.Rows(0).Cells(22).Text <> Nothing And gv40.Rows(0).Cells(22).Text <> "&nbsp;" Then nombreConfirmacion.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(22).Text))

                If Val(gv40.Rows(0).Cells(23).Text) = 1 Then rbl_Conducido.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(24).Text) = 1 Then rbl_Conducido.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(25).Text) = 1 Then rbl_Conducido.Items(2).Selected = True

                If gv40.Rows(0).Cells(26).Text <> "" And gv40.Rows(0).Cells(26).Text <> Nothing And gv40.Rows(0).Cells(26).Text <> "&nbsp;" Then txtVehiculoConducido.Text = gv40.Rows(0).Cells(26).Text
                If gv40.Rows(0).Cells(27).Text <> "" And gv40.Rows(0).Cells(27).Text <> Nothing And gv40.Rows(0).Cells(27).Text <> "&nbsp;" Then lecturaVelocimetroCita.Text = gv40.Rows(0).Cells(27).Text
                If gv40.Rows(0).Cells(28).Text <> "" And gv40.Rows(0).Cells(28).Text <> Nothing And gv40.Rows(0).Cells(28).Text <> "&nbsp;" Then vehiculoPlacas.Text = gv40.Rows(0).Cells(28).Text
                If gv40.Rows(0).Cells(29).Text <> "" And gv40.Rows(0).Cells(29).Text <> Nothing And gv40.Rows(0).Cells(29).Text <> "&nbsp;" Then DOFU.Text = gv40.Rows(0).Cells(29).Text
                If gv40.Rows(0).Cells(30).Text <> "" And gv40.Rows(0).Cells(30).Text <> Nothing And gv40.Rows(0).Cells(30).Text <> "&nbsp;" Then vehiculoNombreModelo.Text = gv40.Rows(0).Cells(30).Text
                If gv40.Rows(0).Cells(31).Text <> "" And gv40.Rows(0).Cells(31).Text <> Nothing And gv40.Rows(0).Cells(31).Text <> "&nbsp;" Then vehiculoModelo.Text = gv40.Rows(0).Cells(31).Text
                If gv40.Rows(0).Cells(32).Text <> "" And gv40.Rows(0).Cells(32).Text <> Nothing And gv40.Rows(0).Cells(32).Text <> "&nbsp;" Then vehiculoNoCarroceria.Text = gv40.Rows(0).Cells(32).Text
                If gv40.Rows(0).Cells(33).Text <> "" And gv40.Rows(0).Cells(33).Text <> Nothing And gv40.Rows(0).Cells(33).Text <> "&nbsp;" Then vehiculoChasis.Text = gv40.Rows(0).Cells(33).Text



                'Get the String 
                Dim convString As String = gv40.Rows(0).Cells(34).Text
                'Create a StringWriter object
                Dim tw As New System.IO.StringWriter
                'Encode the HTML Code
                Server.HtmlEncode(convString, tw)
                'Decode the HTMLCode
                Server.HtmlDecode(convString, tw)
                'Display Encoded and Decoded string in MultiLine TextBox Control 
                'txtMsg.Text = tw.ToString



                If gv40.Rows(0).Cells(34).Text <> "" And gv40.Rows(0).Cells(34).Text <> Nothing And gv40.Rows(0).Cells(34).Text <> "&nbsp;" Then fenomeno1.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(34).Text))

                Session("fenomeno2") = gv40.Rows(0).Cells(35).Text
                Session("fenomeno3") = gv40.Rows(0).Cells(36).Text

                If gv40.Rows(0).Cells(37).Text <> "" And gv40.Rows(0).Cells(37).Text <> Nothing And gv40.Rows(0).Cells(37).Text <> "&nbsp;" Then telefonoContacto.Text = gv40.Rows(0).Cells(37).Text
                If gv40.Rows(0).Cells(38).Text <> "" And gv40.Rows(0).Cells(38).Text <> Nothing And gv40.Rows(0).Cells(38).Text <> "&nbsp;" Then horaContacto1.Text = gv40.Rows(0).Cells(38).Text
                If gv40.Rows(0).Cells(39).Text <> "" And gv40.Rows(0).Cells(39).Text <> Nothing And gv40.Rows(0).Cells(39).Text <> "&nbsp;" Then minutoContacto1.Text = gv40.Rows(0).Cells(39).Text
                If gv40.Rows(0).Cells(40).Text <> "" And gv40.Rows(0).Cells(40).Text <> Nothing And gv40.Rows(0).Cells(40).Text <> "&nbsp;" Then horaContacto2.Text = gv40.Rows(0).Cells(40).Text
                If gv40.Rows(0).Cells(41).Text <> "" And gv40.Rows(0).Cells(41).Text <> Nothing And gv40.Rows(0).Cells(41).Text <> "&nbsp;" Then minutoContacto2.Text = gv40.Rows(0).Cells(41).Text
                If gv40.Rows(0).Cells(42).Text <> "" And gv40.Rows(0).Cells(42).Text <> Nothing And gv40.Rows(0).Cells(42).Text <> "&nbsp;" Then nombreWalkAround.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(42).Text))
                If gv40.Rows(0).Cells(43).Text <> "" And gv40.Rows(0).Cells(43).Text <> Nothing And gv40.Rows(0).Cells(43).Text <> "&nbsp;" Then fechaWalkAround.Text = gv40.Rows(0).Cells(43).Text
                If gv40.Rows(0).Cells(44).Text <> "" And gv40.Rows(0).Cells(44).Text <> Nothing And gv40.Rows(0).Cells(44).Text <> "&nbsp;" Then horaWalkAround.Text = gv40.Rows(0).Cells(44).Text
                If gv40.Rows(0).Cells(45).Text <> "" And gv40.Rows(0).Cells(45).Text <> Nothing And gv40.Rows(0).Cells(45).Text <> "&nbsp;" Then minutoWalkAround.Text = gv40.Rows(0).Cells(45).Text

                If Val(gv40.Rows(0).Cells(46).Text) = 1 Then cbl_ConfirmaClt.Items(0).Selected = True

                If gv40.Rows(0).Cells(47).Text <> "" And gv40.Rows(0).Cells(47).Text <> Nothing And gv40.Rows(0).Cells(47).Text <> "&nbsp;" Then lecturaVeloRecibe.Text = gv40.Rows(0).Cells(47).Text


                If Val(gv40.Rows(0).Cells(48).Text) = 1 Then cbl_Confirmar.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(49).Text) = 1 Then cbl_Confirmar.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(50).Text) = 1 Then cbl_Confirmar.Items(2).Selected = True
                If Val(gv40.Rows(0).Cells(51).Text) = 1 Then cbl_Confirmar.Items(3).Selected = True
                If Val(gv40.Rows(0).Cells(52).Text) = 1 Then cbl_Confirmar.Items(4).Selected = True

                If Val(gv40.Rows(0).Cells(53).Text) = 1 Then rbl_DesdeCuando.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(54).Text) = 1 Then rbl_DesdeCuando.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(55).Text) = 1 Then rbl_DesdeCuando.Items(2).Selected = True

                If gv40.Rows(0).Cells(56).Text <> "" And gv40.Rows(0).Cells(56).Text <> Nothing And gv40.Rows(0).Cells(56).Text <> "&nbsp;" Then txtDesdeCuando.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(56).Text))


                If Val(gv40.Rows(0).Cells(57).Text) = 1 Then rbl_Frecuencia.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(58).Text) = 1 Then rbl_Frecuencia.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(59).Text) = 1 Then rbl_Frecuencia.Items(2).Selected = True
                If Val(gv40.Rows(0).Cells(60).Text) = 1 Then rbl_Frecuencia.Items(3).Selected = True

                If gv40.Rows(0).Cells(61).Text <> "" And gv40.Rows(0).Cells(61).Text <> Nothing And gv40.Rows(0).Cells(61).Text <> "&nbsp;" Then txtFrecuencia.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(61).Text))


                If Val(gv40.Rows(0).Cells(62).Text) = 1 Then cbl_Lugar.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(63).Text) = 1 Then cbl_Lugar.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(64).Text) = 1 Then cbl_Lugar.Items(2).Selected = True
                If Val(gv40.Rows(0).Cells(65).Text) = 1 Then cbl_Lugar.Items(3).Selected = True
                If Val(gv40.Rows(0).Cells(66).Text) = 1 Then cbl_Lugar.Items(4).Selected = True

                If Val(gv40.Rows(0).Cells(67).Text) = 1 Then rdl_LuzAdvierte.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(68).Text) = 1 Then rdl_LuzAdvierte.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(69).Text) = 1 Then rdl_LuzAdvierte.Items(2).Selected = True

                If gv40.Rows(0).Cells(70).Text <> "" And gv40.Rows(0).Cells(70).Text <> Nothing And gv40.Rows(0).Cells(70).Text <> "&nbsp;" Then txtLuzAdvierte.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(70).Text))

                If Val(gv40.Rows(0).Cells(71).Text) = 1 Then rbl_Condicion.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(72).Text) = 1 Then rbl_Condicion.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(73).Text) = 1 Then rbl_Condicion.Items(2).Selected = True
                If Val(gv40.Rows(0).Cells(74).Text) = 1 Then rbl_Condicion.Items(3).Selected = True
                If Val(gv40.Rows(0).Cells(75).Text) = 1 Then rbl_Condicion.Items(4).Selected = True
                If Val(gv40.Rows(0).Cells(76).Text) = 1 Then rbl_Condicion.Items(5).Selected = True

                If gv40.Rows(0).Cells(77).Text <> "" And gv40.Rows(0).Cells(77).Text <> Nothing And gv40.Rows(0).Cells(77).Text <> "&nbsp;" Then txtVelocimetro.Text = gv40.Rows(0).Cells(77).Text
                If gv40.Rows(0).Cells(78).Text <> "" And gv40.Rows(0).Cells(78).Text <> Nothing And gv40.Rows(0).Cells(78).Text <> "&nbsp;" Then txtTacometro.Text = gv40.Rows(0).Cells(78).Text

                If Val(gv40.Rows(0).Cells(79).Text) = 1 Then cbl_Condicion.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(80).Text) = 1 Then cbl_Condicion.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(81).Text) = 1 Then cbl_Condicion.Items(2).Selected = True
                If Val(gv40.Rows(0).Cells(82).Text) = 1 Then cbl_Condicion.Items(3).Selected = True

                If gv40.Rows(0).Cells(83).Text <> "" And gv40.Rows(0).Cells(83).Text <> Nothing And gv40.Rows(0).Cells(83).Text <> "&nbsp;" Then txtNoPersonas.Text = gv40.Rows(0).Cells(83).Text
                If gv40.Rows(0).Cells(84).Text <> "" And gv40.Rows(0).Cells(84).Text <> Nothing And gv40.Rows(0).Cells(84).Text <> "&nbsp;" Then txtCargaVehiculo.Text = gv40.Rows(0).Cells(84).Text
                If gv40.Rows(0).Cells(85).Text <> "" And gv40.Rows(0).Cells(85).Text <> Nothing And gv40.Rows(0).Cells(85).Text <> "&nbsp;" Then txtCargaRemolque.Text = gv40.Rows(0).Cells(85).Text

                If Val(gv40.Rows(0).Cells(86).Text) = 1 Then rbl_Superficie.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(87).Text) = 1 Then rbl_Superficie.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(88).Text) = 1 Then rbl_Superficie.Items(2).Selected = True
                If Val(gv40.Rows(0).Cells(89).Text) = 1 Then rbl_Superficie.Items(3).Selected = True

                If gv40.Rows(0).Cells(90).Text <> "" And gv40.Rows(0).Cells(90).Text <> Nothing And gv40.Rows(0).Cells(90).Text <> "&nbsp;" Then txtSuperficie.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(90).Text))


                If Val(gv40.Rows(0).Cells(91).Text) = 1 Then rbl_Tiempo.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(92).Text) = 1 Then rbl_Tiempo.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(93).Text) = 1 Then rbl_Tiempo.Items(2).Selected = True
                If Val(gv40.Rows(0).Cells(94).Text) = 1 Then rbl_Tiempo.Items(3).Selected = True
                If Val(gv40.Rows(0).Cells(95).Text) = 1 Then rbl_Tiempo.Items(4).Selected = True

                If gv40.Rows(0).Cells(96).Text <> "" And gv40.Rows(0).Cells(96).Text <> Nothing And gv40.Rows(0).Cells(96).Text <> "&nbsp;" Then txtTemperaturaExterna.Text = gv40.Rows(0).Cells(96).Text


                If Val(gv40.Rows(0).Cells(97).Text) = 1 Then rbl_AC.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(98).Text) = 1 Then rbl_AC.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(99).Text) = 1 Then rbl_AC.Items(2).Selected = True
                If Val(gv40.Rows(0).Cells(100).Text) = 1 Then rbl_AC.Items(3).Selected = True

                If gv40.Rows(0).Cells(101).Text <> "" And gv40.Rows(0).Cells(101).Text <> Nothing And gv40.Rows(0).Cells(101).Text <> "&nbsp;" Then txtAC_Temperatura.Text = gv40.Rows(0).Cells(101).Text
                If gv40.Rows(0).Cells(102).Text <> "" And gv40.Rows(0).Cells(102).Text <> Nothing And gv40.Rows(0).Cells(102).Text <> "&nbsp;" Then detalleTrabajo1.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(102).Text))
                If gv40.Rows(0).Cells(103).Text <> "" And gv40.Rows(0).Cells(103).Text <> Nothing And gv40.Rows(0).Cells(103).Text <> "&nbsp;" Then detalleTrabajo2.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(103).Text))
                If gv40.Rows(0).Cells(104).Text <> "" And gv40.Rows(0).Cells(104).Text <> Nothing And gv40.Rows(0).Cells(104).Text <> "&nbsp;" Then detalleTrabajo3.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(104).Text))
                If gv40.Rows(0).Cells(105).Text <> "" And gv40.Rows(0).Cells(105).Text <> Nothing And gv40.Rows(0).Cells(105).Text <> "&nbsp;" Then detalleTrabajo4.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(105).Text))
                If gv40.Rows(0).Cells(106).Text <> "" And gv40.Rows(0).Cells(106).Text <> Nothing And gv40.Rows(0).Cells(106).Text <> "&nbsp;" Then nombreDiag.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(106).Text))
                If gv40.Rows(0).Cells(107).Text <> "" And gv40.Rows(0).Cells(107).Text <> Nothing And gv40.Rows(0).Cells(107).Text <> "&nbsp;" Then fechaDiag.Text = gv40.Rows(0).Cells(107).Text
                If gv40.Rows(0).Cells(108).Text <> "" And gv40.Rows(0).Cells(108).Text <> Nothing And gv40.Rows(0).Cells(108).Text <> "&nbsp;" Then horaDiag.Text = gv40.Rows(0).Cells(108).Text
                If gv40.Rows(0).Cells(109).Text <> "" And gv40.Rows(0).Cells(109).Text <> Nothing And gv40.Rows(0).Cells(109).Text <> "&nbsp;" Then minutoDiag.Text = gv40.Rows(0).Cells(109).Text
                If gv40.Rows(0).Cells(110).Text <> "" And gv40.Rows(0).Cells(110).Text <> Nothing And gv40.Rows(0).Cells(110).Text <> "&nbsp;" Then noLLave.Text = gv40.Rows(0).Cells(110).Text
                If gv40.Rows(0).Cells(111).Text <> "" And gv40.Rows(0).Cells(111).Text <> Nothing And gv40.Rows(0).Cells(111).Text <> "&nbsp;" Then noBahia.Text = gv40.Rows(0).Cells(111).Text

                If Val(gv40.Rows(0).Cells(112).Text) = 1 Then rbl_Resultado.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(113).Text) = 1 Then rbl_Resultado.Items(1).Selected = True

                If gv40.Rows(0).Cells(114).Text <> "" And gv40.Rows(0).Cells(114).Text <> Nothing And gv40.Rows(0).Cells(114).Text <> "&nbsp;" Then motivoResulta.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(114).Text))


                If Val(gv40.Rows(0).Cells(115).Text) = 1 Then cbl_Seguir.Items(0).Selected = True

                If gv40.Rows(0).Cells(116).Text <> "" And gv40.Rows(0).Cells(116).Text <> Nothing And gv40.Rows(0).Cells(116).Text <> "&nbsp;" Then causa1.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(116).Text))
                If gv40.Rows(0).Cells(117).Text <> "" And gv40.Rows(0).Cells(117).Text <> Nothing And gv40.Rows(0).Cells(117).Text <> "&nbsp;" Then causa2.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(117).Text))
                If gv40.Rows(0).Cells(118).Text <> "" And gv40.Rows(0).Cells(118).Text <> Nothing And gv40.Rows(0).Cells(118).Text <> "&nbsp;" Then causa3.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(118).Text))
                If gv40.Rows(0).Cells(119).Text <> "" And gv40.Rows(0).Cells(119).Text <> Nothing And gv40.Rows(0).Cells(119).Text <> "&nbsp;" Then causa4.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(119).Text))
                If gv40.Rows(0).Cells(120).Text <> "" And gv40.Rows(0).Cells(120).Text <> Nothing And gv40.Rows(0).Cells(120).Text <> "&nbsp;" Then DTC1.Text = gv40.Rows(0).Cells(120).Text
                If gv40.Rows(0).Cells(121).Text <> "" And gv40.Rows(0).Cells(121).Text <> Nothing And gv40.Rows(0).Cells(121).Text <> "&nbsp;" Then DTC2.Text = gv40.Rows(0).Cells(121).Text
                If gv40.Rows(0).Cells(122).Text <> "" And gv40.Rows(0).Cells(122).Text <> Nothing And gv40.Rows(0).Cells(122).Text <> "&nbsp;" Then DTC3.Text = gv40.Rows(0).Cells(122).Text
                If gv40.Rows(0).Cells(123).Text <> "" And gv40.Rows(0).Cells(123).Text <> Nothing And gv40.Rows(0).Cells(123).Text <> "&nbsp;" Then DTC4.Text = gv40.Rows(0).Cells(123).Text

                ddl_Status1.SelectedValue = Val(gv40.Rows(0).Cells(124).Text)
                ddl_Status2.SelectedValue = Val(gv40.Rows(0).Cells(125).Text)
                ddl_Status3.SelectedValue = Val(gv40.Rows(0).Cells(126).Text)
                ddl_Status4.SelectedValue = Val(gv40.Rows(0).Cells(127).Text)

                ddl_Datos1.SelectedValue = Val(gv40.Rows(0).Cells(128).Text)
                ddl_Datos2.SelectedValue = Val(gv40.Rows(0).Cells(129).Text)
                ddl_Datos3.SelectedValue = Val(gv40.Rows(0).Cells(130).Text)
                ddl_Datos4.SelectedValue = Val(gv40.Rows(0).Cells(131).Text)

                If Val(gv40.Rows(0).Cells(132).Text) = 1 Then cbl_InstGrtia.Items(0).Selected = True

                If gv40.Rows(0).Cells(133).Text <> "" And gv40.Rows(0).Cells(133).Text <> Nothing And gv40.Rows(0).Cells(133).Text <> "&nbsp;" Then instruccion1.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(133).Text))
                If gv40.Rows(0).Cells(134).Text <> "" And gv40.Rows(0).Cells(134).Text <> Nothing And gv40.Rows(0).Cells(134).Text <> "&nbsp;" Then instruccion2.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(134).Text))
                If gv40.Rows(0).Cells(135).Text <> "" And gv40.Rows(0).Cells(135).Text <> Nothing And gv40.Rows(0).Cells(135).Text <> "&nbsp;" Then instruccion3.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(135).Text))
                If gv40.Rows(0).Cells(136).Text <> "" And gv40.Rows(0).Cells(136).Text <> Nothing And gv40.Rows(0).Cells(136).Text <> "&nbsp;" Then instruccion4.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(136).Text))
                If gv40.Rows(0).Cells(137).Text <> "" And gv40.Rows(0).Cells(137).Text <> Nothing And gv40.Rows(0).Cells(137).Text <> "&nbsp;" Then fechaIniInst1.Text = gv40.Rows(0).Cells(137).Text
                If gv40.Rows(0).Cells(138).Text <> "" And gv40.Rows(0).Cells(138).Text <> Nothing And gv40.Rows(0).Cells(138).Text <> "&nbsp;" Then fechaIniInst2.Text = gv40.Rows(0).Cells(138).Text
                If gv40.Rows(0).Cells(139).Text <> "" And gv40.Rows(0).Cells(139).Text <> Nothing And gv40.Rows(0).Cells(139).Text <> "&nbsp;" Then fechaIniInst3.Text = gv40.Rows(0).Cells(139).Text
                If gv40.Rows(0).Cells(140).Text <> "" And gv40.Rows(0).Cells(140).Text <> Nothing And gv40.Rows(0).Cells(140).Text <> "&nbsp;" Then fechaIniInst4.Text = gv40.Rows(0).Cells(140).Text
                If gv40.Rows(0).Cells(141).Text <> "" And gv40.Rows(0).Cells(141).Text <> Nothing And gv40.Rows(0).Cells(141).Text <> "&nbsp;" Then horaIniInst1.Text = gv40.Rows(0).Cells(141).Text
                If gv40.Rows(0).Cells(142).Text <> "" And gv40.Rows(0).Cells(142).Text <> Nothing And gv40.Rows(0).Cells(142).Text <> "&nbsp;" Then minutoIniInst1.Text = gv40.Rows(0).Cells(142).Text
                If gv40.Rows(0).Cells(143).Text <> "" And gv40.Rows(0).Cells(143).Text <> Nothing And gv40.Rows(0).Cells(143).Text <> "&nbsp;" Then horaIniInst2.Text = gv40.Rows(0).Cells(143).Text
                If gv40.Rows(0).Cells(144).Text <> "" And gv40.Rows(0).Cells(144).Text <> Nothing And gv40.Rows(0).Cells(144).Text <> "&nbsp;" Then minutoIniInst2.Text = gv40.Rows(0).Cells(144).Text
                If gv40.Rows(0).Cells(145).Text <> "" And gv40.Rows(0).Cells(145).Text <> Nothing And gv40.Rows(0).Cells(145).Text <> "&nbsp;" Then horaIniInst3.Text = gv40.Rows(0).Cells(145).Text
                If gv40.Rows(0).Cells(146).Text <> "" And gv40.Rows(0).Cells(146).Text <> Nothing And gv40.Rows(0).Cells(146).Text <> "&nbsp;" Then minutoIniInst3.Text = gv40.Rows(0).Cells(146).Text
                If gv40.Rows(0).Cells(147).Text <> "" And gv40.Rows(0).Cells(147).Text <> Nothing And gv40.Rows(0).Cells(147).Text <> "&nbsp;" Then horaIniInst4.Text = gv40.Rows(0).Cells(147).Text
                If gv40.Rows(0).Cells(148).Text <> "" And gv40.Rows(0).Cells(148).Text <> Nothing And gv40.Rows(0).Cells(148).Text <> "&nbsp;" Then minutoIniInst4.Text = gv40.Rows(0).Cells(148).Text
                If gv40.Rows(0).Cells(149).Text <> "" And gv40.Rows(0).Cells(149).Text <> Nothing And gv40.Rows(0).Cells(149).Text <> "&nbsp;" Then fechaFinInst1.Text = gv40.Rows(0).Cells(149).Text
                If gv40.Rows(0).Cells(150).Text <> "" And gv40.Rows(0).Cells(150).Text <> Nothing And gv40.Rows(0).Cells(150).Text <> "&nbsp;" Then fechaFinInst2.Text = gv40.Rows(0).Cells(150).Text
                If gv40.Rows(0).Cells(151).Text <> "" And gv40.Rows(0).Cells(151).Text <> Nothing And gv40.Rows(0).Cells(151).Text <> "&nbsp;" Then fechaFinInst3.Text = gv40.Rows(0).Cells(151).Text
                If gv40.Rows(0).Cells(152).Text <> "" And gv40.Rows(0).Cells(152).Text <> Nothing And gv40.Rows(0).Cells(152).Text <> "&nbsp;" Then fechaFinInst4.Text = gv40.Rows(0).Cells(152).Text
                If gv40.Rows(0).Cells(153).Text <> "" And gv40.Rows(0).Cells(153).Text <> Nothing And gv40.Rows(0).Cells(153).Text <> "&nbsp;" Then horaFinInst1.Text = gv40.Rows(0).Cells(153).Text
                If gv40.Rows(0).Cells(154).Text <> "" And gv40.Rows(0).Cells(154).Text <> Nothing And gv40.Rows(0).Cells(154).Text <> "&nbsp;" Then minutoFinInst1.Text = gv40.Rows(0).Cells(154).Text
                If gv40.Rows(0).Cells(155).Text <> "" And gv40.Rows(0).Cells(155).Text <> Nothing And gv40.Rows(0).Cells(155).Text <> "&nbsp;" Then horaFinInst2.Text = gv40.Rows(0).Cells(155).Text
                If gv40.Rows(0).Cells(156).Text <> "" And gv40.Rows(0).Cells(156).Text <> Nothing And gv40.Rows(0).Cells(156).Text <> "&nbsp;" Then minutoFinInst2.Text = gv40.Rows(0).Cells(156).Text
                If gv40.Rows(0).Cells(157).Text <> "" And gv40.Rows(0).Cells(157).Text <> Nothing And gv40.Rows(0).Cells(157).Text <> "&nbsp;" Then horaFinInst3.Text = gv40.Rows(0).Cells(157).Text
                If gv40.Rows(0).Cells(158).Text <> "" And gv40.Rows(0).Cells(158).Text <> Nothing And gv40.Rows(0).Cells(158).Text <> "&nbsp;" Then minutoFinInst3.Text = gv40.Rows(0).Cells(158).Text
                If gv40.Rows(0).Cells(159).Text <> "" And gv40.Rows(0).Cells(159).Text <> Nothing And gv40.Rows(0).Cells(159).Text <> "&nbsp;" Then horaFinInst4.Text = gv40.Rows(0).Cells(159).Text
                If gv40.Rows(0).Cells(160).Text <> "" And gv40.Rows(0).Cells(160).Text <> Nothing And gv40.Rows(0).Cells(160).Text <> "&nbsp;" Then minutoFinInst4.Text = gv40.Rows(0).Cells(160).Text
                If gv40.Rows(0).Cells(161).Text <> "" And gv40.Rows(0).Cells(161).Text <> Nothing And gv40.Rows(0).Cells(161).Text <> "&nbsp;" Then horaWork1.Text = gv40.Rows(0).Cells(161).Text
                If gv40.Rows(0).Cells(162).Text <> "" And gv40.Rows(0).Cells(162).Text <> Nothing And gv40.Rows(0).Cells(162).Text <> "&nbsp;" Then horaWork2.Text = gv40.Rows(0).Cells(162).Text
                If gv40.Rows(0).Cells(163).Text <> "" And gv40.Rows(0).Cells(163).Text <> Nothing And gv40.Rows(0).Cells(163).Text <> "&nbsp;" Then horaWork3.Text = gv40.Rows(0).Cells(163).Text
                If gv40.Rows(0).Cells(164).Text <> "" And gv40.Rows(0).Cells(164).Text <> Nothing And gv40.Rows(0).Cells(164).Text <> "&nbsp;" Then horaWork4.Text = gv40.Rows(0).Cells(164).Text
                If gv40.Rows(0).Cells(165).Text <> "" And gv40.Rows(0).Cells(165).Text <> Nothing And gv40.Rows(0).Cells(165).Text <> "&nbsp;" Then minutoWork1.Text = gv40.Rows(0).Cells(165).Text
                If gv40.Rows(0).Cells(166).Text <> "" And gv40.Rows(0).Cells(166).Text <> Nothing And gv40.Rows(0).Cells(166).Text <> "&nbsp;" Then minutoWork2.Text = gv40.Rows(0).Cells(166).Text
                If gv40.Rows(0).Cells(167).Text <> "" And gv40.Rows(0).Cells(167).Text <> Nothing And gv40.Rows(0).Cells(167).Text <> "&nbsp;" Then minutoWork3.Text = gv40.Rows(0).Cells(167).Text
                If gv40.Rows(0).Cells(168).Text <> "" And gv40.Rows(0).Cells(168).Text <> Nothing And gv40.Rows(0).Cells(168).Text <> "&nbsp;" Then minutoWork4.Text = gv40.Rows(0).Cells(168).Text

                If Val(gv40.Rows(0).Cells(169).Text) = 1 Then cbl_DTR1.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(170).Text) = 1 Then cbl_DTR2.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(171).Text) = 1 Then cbl_DTR3.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(172).Text) = 1 Then cbl_DTR4.Items(0).Selected = True

                If gv40.Rows(0).Cells(173).Text <> "" And gv40.Rows(0).Cells(173).Text <> Nothing And gv40.Rows(0).Cells(173).Text <> "&nbsp;" Then instTec1.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(173).Text))
                If gv40.Rows(0).Cells(174).Text <> "" And gv40.Rows(0).Cells(174).Text <> Nothing And gv40.Rows(0).Cells(174).Text <> "&nbsp;" Then instCnf1.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(174).Text))
                If gv40.Rows(0).Cells(175).Text <> "" And gv40.Rows(0).Cells(175).Text <> Nothing And gv40.Rows(0).Cells(175).Text <> "&nbsp;" Then instTec2.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(175).Text))
                If gv40.Rows(0).Cells(176).Text <> "" And gv40.Rows(0).Cells(176).Text <> Nothing And gv40.Rows(0).Cells(176).Text <> "&nbsp;" Then instCnf2.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(176).Text))
                If gv40.Rows(0).Cells(177).Text <> "" And gv40.Rows(0).Cells(177).Text <> Nothing And gv40.Rows(0).Cells(177).Text <> "&nbsp;" Then instTec3.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(177).Text))
                If gv40.Rows(0).Cells(178).Text <> "" And gv40.Rows(0).Cells(178).Text <> Nothing And gv40.Rows(0).Cells(178).Text <> "&nbsp;" Then instCnf3.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(178).Text))
                If gv40.Rows(0).Cells(179).Text <> "" And gv40.Rows(0).Cells(179).Text <> Nothing And gv40.Rows(0).Cells(179).Text <> "&nbsp;" Then instTec4.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(179).Text))
                If gv40.Rows(0).Cells(180).Text <> "" And gv40.Rows(0).Cells(180).Text <> Nothing And gv40.Rows(0).Cells(180).Text <> "&nbsp;" Then instCnf4.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(180).Text))
                If gv40.Rows(0).Cells(181).Text <> "" And gv40.Rows(0).Cells(181).Text <> Nothing And gv40.Rows(0).Cells(181).Text <> "&nbsp;" Then tmexDestino.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(181).Text))
                If gv40.Rows(0).Cells(182).Text <> "" And gv40.Rows(0).Cells(182).Text <> Nothing And gv40.Rows(0).Cells(182).Text <> "&nbsp;" Then tmexRespble.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(182).Text))


                If Val(gv40.Rows(0).Cells(183).Text) = 1 Then rbl_Tmex.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(184).Text) = 1 Then rbl_Tmex.Items(1).Selected = True

                If gv40.Rows(0).Cells(185).Text <> "" And gv40.Rows(0).Cells(185).Text <> Nothing And gv40.Rows(0).Cells(185).Text <> "&nbsp;" Then fechaTmex.Text = gv40.Rows(0).Cells(185).Text
                If gv40.Rows(0).Cells(186).Text <> "" And gv40.Rows(0).Cells(186).Text <> Nothing And gv40.Rows(0).Cells(186).Text <> "&nbsp;" Then horaTmex.Text = gv40.Rows(0).Cells(186).Text
                If gv40.Rows(0).Cells(187).Text <> "" And gv40.Rows(0).Cells(187).Text <> Nothing And gv40.Rows(0).Cells(187).Text <> "&nbsp;" Then minutoTmex.Text = gv40.Rows(0).Cells(187).Text

                If Val(gv40.Rows(0).Cells(188).Text) = 1 Then cbl_StatusTmex.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(189).Text) = 1 Then cbl_StatusTmex.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(190).Text) = 1 Then cbl_StatusTmex.Items(2).Selected = True

                If Val(gv40.Rows(0).Cells(191).Text) = 1 Then cbl_SolicitaTmex.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(192).Text) = 1 Then cbl_SolicitaTmex.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(193).Text) = 1 Then cbl_SolicitaTmex.Items(2).Selected = True
                If Val(gv40.Rows(0).Cells(194).Text) = 1 Then cbl_SolicitaTmex.Items(3).Selected = True

                If gv40.Rows(0).Cells(195).Text <> "" And gv40.Rows(0).Cells(195).Text <> Nothing And gv40.Rows(0).Cells(195).Text <> "&nbsp;" Then fechaSolTmex.Text = gv40.Rows(0).Cells(195).Text
                If gv40.Rows(0).Cells(196).Text <> "" And gv40.Rows(0).Cells(196).Text <> Nothing And gv40.Rows(0).Cells(196).Text <> "&nbsp;" Then horaSolTmex.Text = gv40.Rows(0).Cells(196).Text
                If gv40.Rows(0).Cells(197).Text <> "" And gv40.Rows(0).Cells(197).Text <> Nothing And gv40.Rows(0).Cells(197).Text <> "&nbsp;" Then minutoSolTmex.Text = gv40.Rows(0).Cells(197).Text
                If gv40.Rows(0).Cells(198).Text <> "" And gv40.Rows(0).Cells(198).Text <> Nothing And gv40.Rows(0).Cells(198).Text <> "&nbsp;" Then nombreTmex.Text = gv40.Rows(0).Cells(198).Text


            Else

                sSelCmd = "SELECT id, fecha, Cliente, Vehiculo, noPlacas, horaEntrega, noOrden, usuario AS idAsesor, Vehiculo, telefonos, USUARIO, idCliente, vin, FECHA_RECEPCION" _
                        & "  FROM Tb_CITAS " _
                        & " WHERE id = " & Session("NF")

                SqlDataSource_36.SelectCommand = sSelCmd

                gv_36.DataSource = SqlDataSource_36
                gv_36.DataBind()

                If gv_36.Rows.Count > 0 Then

                    noDiagnostico.Text = Session("NF")

                    sRecord = Trim(gv_36.Rows(0).Cells(2).Text)
                    Session("nombreCliente") = checarCaracterEspañol(sRecord)



                    fechaDiagnostico.Text = gv_36.Rows(0).Cells(1).Text
                    If gv_36.Rows(0).Cells(2).Text <> "" And gv_36.Rows(0).Cells(2).Text <> Nothing And gv_36.Rows(0).Cells(2).Text <> "&nbsp;" Then nombreCliente.Text = checarCaracterEspañol(Trim(gv_36.Rows(0).Cells(2).Text))
                    If gv_36.Rows(0).Cells(3).Text <> "" And gv_36.Rows(0).Cells(3).Text <> Nothing And gv_36.Rows(0).Cells(3).Text <> "&nbsp;" Then vehiculoNombreModelo.Text = gv_36.Rows(0).Cells(3).Text
                    If gv_36.Rows(0).Cells(4).Text <> "" And gv_36.Rows(0).Cells(4).Text <> Nothing And gv_36.Rows(0).Cells(4).Text <> "&nbsp;" Then vehiculoPlacas.Text = gv_36.Rows(0).Cells(4).Text
                    If gv_36.Rows(0).Cells(6).Text <> "" And gv_36.Rows(0).Cells(6).Text <> Nothing And gv_36.Rows(0).Cells(6).Text <> "&nbsp;" Then noOrden.Text = gv_36.Rows(0).Cells(6).Text
                    If gv_36.Rows(0).Cells(7).Text <> "" And gv_36.Rows(0).Cells(7).Text <> Nothing And gv_36.Rows(0).Cells(7).Text <> "&nbsp;" Then nombreAsesor.Text = checarCaracterEspañol(Trim(gv_36.Rows(0).Cells(7).Text))
                    If gv_36.Rows(0).Cells(3).Text <> "" And gv_36.Rows(0).Cells(3).Text <> Nothing And gv_36.Rows(0).Cells(3).Text <> "&nbsp;" Then vehiculoModelo.Text = gv_36.Rows(0).Cells(3).Text
                    If gv_36.Rows(0).Cells(9).Text <> "" And gv_36.Rows(0).Cells(9).Text <> Nothing And gv_36.Rows(0).Cells(9).Text <> "&nbsp;" Then telefonoCliente.Text = gv_36.Rows(0).Cells(9).Text

                    fechaRecepcion.Text = CType(gv_36.Rows(0).Cells(1).Text, Date)

                End If

            End If

        Catch eexc As Exception
            Session("lblError") = eexc.Message
        End Try

    End Sub

    Protected Function formatoFechas() As Boolean
        Try
            Dim bReturn As Boolean

            bReturn = True


            If fechaRecepcion.Text <> "" And fechaRecepcion.Text <> Nothing Then
                If Not IsDate(fechaRecepcion.Text) Then
                    Alert(Me.Page, "¡Fecha recepción incorrecta!")

                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaEntrega.Text <> "" And fechaEntrega.Text <> Nothing Then
                If Not IsDate(fechaEntrega.Text) Then
                    Alert(Me.Page, "¡Fecha entrega incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaDiagnostico.Text <> "" And fechaDiagnostico.Text <> Nothing Then
                If Not IsDate(fechaDiagnostico.Text) Then
                    Alert(Me.Page, "¡Fecha diagnostico incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaConfirmacion.Text <> "" And fechaConfirmacion.Text <> Nothing Then
                If Not IsDate(fechaConfirmacion.Text) Then
                    Alert(Me.Page, "¡Fecha confirmación incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaWalkAround.Text <> "" And fechaWalkAround.Text <> Nothing Then
                If Not IsDate(fechaWalkAround.Text) Then
                    Alert(Me.Page, "¡Fecha walkaround incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaDiag.Text <> "" And fechaDiag.Text <> Nothing Then
                If Not IsDate(fechaDiag.Text) Then
                    Alert(Me.Page, "¡Fecha diagnostico incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaIniInst1.Text <> "" And fechaIniInst1.Text <> Nothing Then
                If Not IsDate(fechaIniInst1.Text) Then
                    Alert(Me.Page, "¡Fecha inicio instrucción 1 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaIniInst2.Text <> "" And fechaIniInst2.Text <> Nothing Then
                If Not IsDate(fechaIniInst2.Text) Then
                    Alert(Me.Page, "¡Fecha inicio instrucción 2 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaIniInst3.Text <> "" And fechaIniInst3.Text <> Nothing Then
                If Not IsDate(fechaIniInst3.Text) Then
                    Alert(Me.Page, "¡Fecha inicio instrucción 3 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaIniInst4.Text <> "" And fechaIniInst4.Text <> Nothing Then
                If Not IsDate(fechaIniInst4.Text) Then
                    Alert(Me.Page, "¡Fecha inicio instrucción 4 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaFinInst1.Text <> "" And fechaFinInst1.Text <> Nothing Then
                If Not IsDate(fechaFinInst1.Text) Then
                    Alert(Me.Page, "¡Fecha termino instrucción 1 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaFinInst2.Text <> "" And fechaFinInst2.Text <> Nothing Then
                If Not IsDate(fechaFinInst2.Text) Then
                    Alert(Me.Page, "¡Fecha termino instrucción 2 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaFinInst3.Text <> "" And fechaFinInst3.Text <> Nothing Then
                If Not IsDate(fechaFinInst3.Text) Then
                    Alert(Me.Page, "¡Fecha termino instrucción 3 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaFinInst4.Text <> "" And fechaFinInst4.Text <> Nothing Then
                If Not IsDate(fechaFinInst4.Text) Then
                    Alert(Me.Page, "¡Fecha termino instrucción 4 incorrecta!")

                    bReturn = False
                    Exit Function
                End If
            End If


            If fechaTmex.Text <> "" And fechaTmex.Text <> Nothing Then
                If Not IsDate(fechaTmex.Text) Then
                    Alert(Me.Page, "¡Fecha timex 1 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If fechaSolTmex.Text <> "" And fechaSolTmex.Text <> Nothing Then
                If Not IsDate(fechaSolTmex.Text) Then
                    Alert(Me.Page, "¡Fecha timex 2 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If


            Return bReturn

        Catch eexc As Exception
            Session("lblError") = eexc.Message
        End Try

    End Function


    Protected Sub asignaVariables()

        Try

            Session("fechaRecepcion") = fechaRecepcion.Text
            Session("horaRecepcion") = horaRecepcion.Text
            Session("minutoRecepcion") = minutoRecepcion.Text


            If rbl_CltEmpTrae.Items(0).Selected Then Session("Cliente_trae") = 1 Else Session("Cliente_trae") = 0
            If rbl_CltEmpTrae.Items(1).Selected Then Session("Concesionario_recoge") = 1 Else Session("Concesionario_recoge") = 0

            If cbl_VehiculoCortesia.Items(0).Selected Then Session("VehiculoCortesia") = 1 Else Session("VehiculoCortesia") = 0

            Session("fechaEntrega") = fechaEntrega.Text
            Session("horaEntrega") = horaEntrega.Text
            Session("minutoEntrega") = minutoEntrega.Text

            If rbl_CltEmpRetira.Items(0).Selected Then Session("Cliente_retira") = 1 Else Session("Cliente_retira") = 0
            If rbl_CltEmpRetira.Items(1).Selected Then Session("Concesionario_entrega") = 1 Else Session("Concesionario_entrega") = 0

            Session("nombreCliente") = nombreCliente.Text
            Session("direccionCliente") = direccionCliente.Text
            Session("telefonoCliente") = telefonoCliente.Text
            Session("fechaDiagnostico") = fechaDiagnostico.Text
            Session("nombreAsesor") = nombreAsesor.Text
            Session("noDiagnostico") = noDiagnostico.Text
            Session("noOrden") = noOrden.Text
            Session("fechaConfirmacion") = fechaConfirmacion.Text
            Session("horaConfirmacion") = horaConfirmacion.Text
            Session("minutoConfirmacion") = minutoConfirmacion.Text
            Session("nombreConfirmacion") = nombreConfirmacion.Text


            If rbl_Conducido.Items(0).Selected Then Session("Conducido_Propietario") = 1 Else Session("Conducido_Propietario") = 0
            If rbl_Conducido.Items(1).Selected Then Session("Conducido_Familia") = 1 Else Session("Conducido_Familia") = 0
            If rbl_Conducido.Items(2).Selected Then Session("Conducido_Otro") = 1 Else Session("Conducido_Otro") = 0




            Session("txtVehiculoConducido") = txtVehiculoConducido.Text
            Session("lecturaVelocimetroCita") = lecturaVelocimetroCita.Text
            Session("vehiculoPlacas") = vehiculoPlacas.Text
            Session("DOFU") = DOFU.Text
            Session("vehiculoNombreModelo") = vehiculoNombreModelo.Text
            Session("vehiculoModelo") = vehiculoModelo.Text
            Session("vehiculoNoCarroceria") = vehiculoNoCarroceria.Text
            Session("vehiculoChasis") = vehiculoChasis.Text

            Session("fenomeno1") = fenomeno1.Text
            Session("fenomeno2") = ""
            Session("fenomeno3") = ""

            Session("telefonoContacto") = telefonoContacto.Text
            Session("horaContacto1") = horaContacto1.Text
            Session("minutoContacto1") = minutoContacto1.Text
            Session("horaContacto2") = horaContacto2.Text
            Session("minutoContacto2") = minutoContacto2.Text
            Session("nombreWalkAround") = nombreWalkAround.Text
            Session("fechaWalkAround") = fechaWalkAround.Text
            Session("horaWalkAround") = horaWalkAround.Text
            Session("minutoWalkAround") = minutoWalkAround.Text

            If cbl_ConfirmaClt.Items(0).Selected Then Session("Confirma_Clt") = 1 Else Session("Confirma_Clt") = 0

            Session("lecturaVeloRecibe") = lecturaVeloRecibe.Text

            If cbl_Confirmar.Items(0).Selected Then Session("Confirma_Trabajo_adicional") = 1 Else Session("Confirma_Trabajo_adicional") = 0
            If cbl_Confirmar.Items(1).Selected Then Session("Confirma_Pertenencias") = 1 Else Session("Confirma_Pertenencias") = 0
            If cbl_Confirmar.Items(2).Selected Then Session("Confirma_Cubre_Asiento") = 1 Else Session("Confirma_Cubre_Asiento") = 0
            If cbl_Confirmar.Items(3).Selected Then Session("Confirma_Cubre_volante_palanca") = 1 Else Session("Confirma_Cubre_volante_palanca") = 0
            If cbl_Confirmar.Items(4).Selected Then Session("Confirma_Tapetes") = 1 Else Session("Confirma_Tapetes") = 0

            If rbl_DesdeCuando.Items(0).Selected Then Session("DesdeCuando_Recientemente") = 1 Else Session("DesdeCuando_Recientemente") = 0
            If rbl_DesdeCuando.Items(1).Selected Then Session("DesdeCuando_Hace_1_semana") = 1 Else Session("DesdeCuando_Hace_1_semana") = 0
            If rbl_DesdeCuando.Items(2).Selected Then Session("DesdeCuando_Otro") = 1 Else Session("DesdeCuando_Otro") = 0

            Session("txtDesdeCuando") = txtDesdeCuando.Text

            If rbl_Frecuencia.Items(0).Selected Then Session("Frecuencia_Siempre") = 1 Else Session("Frecuencia_Siempre") = 0
            If rbl_Frecuencia.Items(1).Selected Then Session("Frecuencia_Ocasionalmente") = 1 Else Session("Frecuencia_Ocasionalmente") = 0
            If rbl_Frecuencia.Items(2).Selected Then Session("Frecuencia_Solo_1_vez") = 1 Else Session("Frecuencia_Solo_1_vez") = 0
            If rbl_Frecuencia.Items(3).Selected Then Session("Frecuencia_Otro") = 1 Else Session("Frecuencia_Otro") = 0

            Session("txtFrecuencia") = txtFrecuencia.Text

            If cbl_Lugar.Items(0).Selected Then Session("Lugar_Calle") = 1 Else Session("Lugar_Calle") = 0
            If cbl_Lugar.Items(1).Selected Then Session("Lugar_Carretera") = 1 Else Session("Lugar_Carretera") = 0
            If cbl_Lugar.Items(2).Selected Then Session("Lugar_Subida") = 1 Else Session("Lugar_Subida") = 0
            If cbl_Lugar.Items(3).Selected Then Session("Lugar_Bajada") = 1 Else Session("Lugar_Bajada") = 0
            If cbl_Lugar.Items(4).Selected Then Session("Lugar_Trafico") = 1 Else Session("Lugar_Trafico") = 0

            If rdl_LuzAdvierte.Items(0).Selected Then Session("LuzAdvierte_Prendida") = 1 Else Session("LuzAdvierte_Prendida") = 0
            If rdl_LuzAdvierte.Items(1).Selected Then Session("LuzAdvierte_Parpadeando") = 1 Else Session("LuzAdvierte_Parpadeando") = 0
            If rdl_LuzAdvierte.Items(2).Selected Then Session("LuzAdvierte_Parpadeo_multiple") = 1 Else Session("LuzAdvierte_Parpadeo_multiple") = 0

            Session("txtLuzAdvierte") = txtLuzAdvierte.Text



            If rbl_Condicion.Items(0).Selected Then Session("Condicion_Arranque") = 1 Else Session("Condicion_Arranque") = 0
            If rbl_Condicion.Items(1).Selected Then Session("Condicion_Parado") = 1 Else Session("Condicion_Parado") = 0
            If rbl_Condicion.Items(2).Selected Then Session("Condicion_V_K") = 1 Else Session("Condicion_V_K") = 0
            If rbl_Condicion.Items(3).Selected Then Session("Condicion_V_no_K") = 1 Else Session("Condicion_V_no_K") = 0
            If rbl_Condicion.Items(4).Selected Then Session("Condicion_Acelerando") = 1 Else Session("Condicion_Acelerando") = 0
            If rbl_Condicion.Items(5).Selected Then Session("Condicion_Desacelerando") = 1 Else Session("Condicion_Desacelerando") = 0

            Session("txtVelocimetro") = txtVelocimetro.Text
            Session("txtTacometro") = txtTacometro.Text


            If cbl_Condicion.Items(0).Selected Then Session("Condicion_Rebasando") = 1 Else Session("Condicion_Rebasando") = 0
            If cbl_Condicion.Items(1).Selected Then Session("Condicion_Cambiando") = 1 Else Session("Condicion_Cambiando") = 0
            If cbl_Condicion.Items(2).Selected Then Session("Condicion_Retrocediendo") = 1 Else Session("Condicion_Retrocediendo") = 0
            If cbl_Condicion.Items(3).Selected Then Session("Condicion_Frenando") = 1 Else Session("Condicion_Frenando") = 0

            Session("txtNoPersonas") = txtNoPersonas.Text
            Session("txtCargaVehiculo") = txtCargaVehiculo.Text
            Session("txtCargaRemolque") = txtCargaRemolque.Text

            If rbl_Superficie.Items(0).Selected Then Session("Superficie_Plana") = 1 Else Session("Superficie_Plana") = 0
            If rbl_Superficie.Items(1).Selected Then Session("Superficie_Desigual") = 1 Else Session("Superficie_Desigual") = 0
            If rbl_Superficie.Items(2).Selected Then Session("Superficie_Aspero") = 1 Else Session("Superficie_Aspero") = 0
            If rbl_Superficie.Items(3).Selected Then Session("Superficie_Otro") = 1 Else Session("Superficie_Otro") = 0

            Session("txtSuperficie") = txtSuperficie.Text

            If rbl_Tiempo.Items(0).Selected Then Session("Tiempo_Despejado") = 1 Else Session("Tiempo_Despejado") = 0
            If rbl_Tiempo.Items(1).Selected Then Session("Tiempo_Nublado") = 1 Else Session("Tiempo_Nublado") = 0
            If rbl_Tiempo.Items(2).Selected Then Session("Tiempo_Lluvia") = 1 Else Session("Tiempo_Lluvia") = 0
            If rbl_Tiempo.Items(3).Selected Then Session("Tiempo_Nieve") = 1 Else Session("Tiempo_Nieve") = 0
            If rbl_Tiempo.Items(4).Selected Then Session("Tiempo_Temperatura_externa") = 1 Else Session("Tiempo_Temperatura_externa") = 0

            Session("txtTemperaturaExterna") = txtTemperaturaExterna.Text


            If rbl_AC.Items(0).Selected Then Session("AC_Flujo_aire") = 1 Else Session("AC_Flujo_aire") = 0
            If rbl_AC.Items(1).Selected Then Session("AC_Recirculacion") = 1 Else Session("AC_Recirculacion") = 0
            If rbl_AC.Items(2).Selected Then Session("AC_Velocidad_ventilacion") = 1 Else Session("AC_Velocidad_ventilacion") = 0
            If rbl_AC.Items(3).Selected Then Session("AC_Temperatura") = 1 Else Session("AC_Temperatura") = 0

            Session("txtAC_Temperatura") = txtAC_Temperatura.Text

            Session("detalleTrabajo1") = detalleTrabajo1.Text
            Session("detalleTrabajo2") = detalleTrabajo2.Text
            Session("detalleTrabajo3") = detalleTrabajo3.Text
            Session("detalleTrabajo4") = detalleTrabajo4.Text
            Session("nombreDiag") = nombreDiag.Text
            Session("fechaDiag") = fechaDiag.Text
            Session("horaDiag") = horaDiag.Text
            Session("minutoDiag") = minutoDiag.Text
            Session("noLLave") = noLLave.Text
            Session("noBahia") = noBahia.Text



            If rbl_Resultado.Items(0).Selected Then Session("Resultado_Descubierto") = 1 Else Session("Resultado_Descubierto") = 0
            If rbl_Resultado.Items(1).Selected Then Session("Resultado_Prediccion") = 1 Else Session("Resultado_Prediccion") = 0

            Session("motivoResulta") = motivoResulta.Text

            If cbl_Seguir.Items(0).Selected Then Session("Seguimiento") = 1 Else Session("Seguimiento") = 0

            Session("causa1") = causa1.Text
            Session("causa2") = causa2.Text
            Session("causa3") = causa3.Text
            Session("causa4") = causa4.Text
            Session("DTC1") = DTC1.Text
            Session("DTC2") = DTC2.Text
            Session("DTC3") = DTC3.Text
            Session("DTC4") = DTC4.Text

            Session("Status1_0") = ddl_Status1.SelectedValue
            Session("Status2_0") = ddl_Status2.SelectedValue
            Session("Status3_0") = ddl_Status3.SelectedValue
            Session("Status4_0") = ddl_Status4.SelectedValue

            Session("Datos1_0") = ddl_Datos1.SelectedValue
            Session("Datos2_0") = ddl_Datos2.SelectedValue
            Session("Datos3_0") = ddl_Datos3.SelectedValue
            Session("Datos4_0") = ddl_Datos4.SelectedValue

            If cbl_InstGrtia.Items(0).Selected Then Session("Garantía") = 1 Else Session("Garantía") = 0

            Session("instruccion1") = instruccion1.Text
            Session("instruccion2") = instruccion2.Text
            Session("instruccion3") = instruccion3.Text
            Session("instruccion4") = instruccion4.Text
            Session("fechaIniInst1") = fechaIniInst1.Text
            Session("fechaIniInst2") = fechaIniInst2.Text
            Session("fechaIniInst3") = fechaIniInst3.Text
            Session("fechaIniInst4") = fechaIniInst4.Text
            Session("horaIniInst1") = horaIniInst1.Text
            Session("minutoIniInst1") = minutoIniInst1.Text
            Session("horaIniInst2") = horaIniInst2.Text
            Session("minutoIniInst2") = minutoIniInst2.Text
            Session("horaIniInst3") = horaIniInst3.Text
            Session("minutoIniInst3") = minutoIniInst3.Text
            Session("horaIniInst4") = horaIniInst4.Text
            Session("minutoIniInst4") = minutoIniInst4.Text
            Session("fechaFinInst1") = fechaFinInst1.Text
            Session("fechaFinInst2") = fechaFinInst2.Text
            Session("fechaFinInst3") = fechaFinInst3.Text
            Session("fechaFinInst4") = fechaFinInst4.Text
            Session("horaFinInst1") = horaFinInst1.Text
            Session("minutoFinInst1") = minutoFinInst1.Text
            Session("horaFinInst2") = horaFinInst2.Text
            Session("minutoFinInst2") = minutoFinInst2.Text
            Session("horaFinInst3") = horaFinInst3.Text
            Session("minutoFinInst3") = minutoFinInst3.Text
            Session("horaFinInst4") = horaFinInst4.Text
            Session("minutoFinInst4") = minutoFinInst4.Text
            Session("horaWork1") = horaWork1.Text
            Session("horaWork2") = horaWork2.Text
            Session("horaWork3") = horaWork3.Text
            Session("horaWork4") = horaWork4.Text
            Session("minutoWork1") = minutoWork1.Text
            Session("minutoWork2") = minutoWork2.Text
            Session("minutoWork3") = minutoWork3.Text
            Session("minutoWork4") = minutoWork4.Text

            If cbl_DTR1.Items(0).Selected Then Session("DTR1") = 1 Else Session("DTR1") = 0
            If cbl_DTR2.Items(0).Selected Then Session("DTR2") = 1 Else Session("DTR2") = 0
            If cbl_DTR3.Items(0).Selected Then Session("DTR3") = 1 Else Session("DTR3") = 0
            If cbl_DTR4.Items(0).Selected Then Session("DTR4") = 1 Else Session("DTR4") = 0

            Session("instTec1") = instTec1.Text
            Session("instCnf1") = instCnf1.Text
            Session("instTec2") = instTec2.Text
            Session("instCnf2") = instCnf2.Text
            Session("instTec3") = instTec3.Text
            Session("instCnf3") = instCnf3.Text
            Session("instTec4") = instTec4.Text
            Session("instCnf4") = instCnf4.Text
            Session("tmexDestino") = tmexDestino.Text
            Session("tmexRespble") = tmexRespble.Text



            If rbl_Tmex.Items(0).Selected Then Session("Tmex_En_proceso") = 1 Else Session("Tmex_En_proceso") = 0
            If rbl_Tmex.Items(1).Selected Then Session("Tmex_Planeado") = 1 Else Session("Tmex_Planeado") = 0

            Session("fechaTmex") = fechaTmex.Text
            Session("horaTmex") = horaTmex.Text
            Session("minutoTmex") = minutoTmex.Text

            If cbl_StatusTmex.Items(0).Selected Then Session("StatusTmex_Recurrencia") = 1 Else Session("StatusTmex_Recurrencia") = 0
            If cbl_StatusTmex.Items(1).Selected Then Session("StatusTmex_Dificultad_identificar_causa") = 1 Else Session("StatusTmex_Dificultad_identificar_causa") = 0
            If cbl_StatusTmex.Items(2).Selected Then Session("StatusTmex_Reparacion_dificil") = 1 Else Session("StatusTmex_Reparacion_dificil") = 0

            If cbl_SolicitaTmex.Items(0).Selected Then Session("SolicitaTmex_Verificación_vehiculo") = 1 Else Session("SolicitaTmex_Verificación_vehiculo") = 0
            If cbl_SolicitaTmex.Items(1).Selected Then Session("SolicitaTmex_Historial_servicio") = 1 Else Session("SolicitaTmex_Historial_servicio") = 0
            If cbl_SolicitaTmex.Items(2).Selected Then Session("SolicitaTmex_Asistencia_en_reparacion") = 1 Else Session("SolicitaTmex_Asistencia_en_reparacion") = 0
            If cbl_SolicitaTmex.Items(3).Selected Then Session("SolicitaTmex_Otro") = 1 Else Session("SolicitaTmex_Otro") = 0

            Session("fechaSolTmex") = fechaSolTmex.Text
            Session("horaSolTmex") = horaSolTmex.Text
            Session("minutoSolTmex") = minutoSolTmex.Text
            Session("nombreTmex") = nombreTmex.Text

        Catch eexc As Exception
            Session("lblError") = eexc.Message
            Alert(Me.Page, Session("lblError"))
        End Try


    End Sub


    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        'Create/update
        Try

            Dim gv40 As New GridView

            If formatoFechas() Then

                asignaVariables()

                Session("idCita") = Session("NF")

                sSelCmd = "SELECT * FROM TYT_KDW_FORMATO_DIAGNOSTICO WHERE idCita = " & "'" & Session("NF") & "'"
                SqlDataSource40.SelectCommand = sSelCmd


                gv40.DataSource = SqlDataSource40
                gv40.DataBind()

                If gv40.Rows.Count = 0 Then SqlDataSource40.Insert() Else SqlDataSource40.Update()

            End If

        Catch eexc As Exception
            Session("lblError") = eexc.Message
        End Try

    End Sub

    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
        'Delete
        Try

            asignaVariables()
            SqlDataSource40.Delete()

            ImageButton2_Click(sender, e)
        Catch eexc As Exception
            Session("Error") = eexc.Message
        End Try

    End Sub

    Protected Sub fenomeno1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fenomeno1.TextChanged
        'Alert(Me.Page, "fenomeno1_TextChanged")

    End Sub
End Class
