
Partial Class OrdenTecnico
    Inherits System.Web.UI.Page


    Dim sSelCmd As String

    Public Sub Alert(ByVal oPagina As System.Web.UI.Page, ByVal sMensaje As String)

        Dim sScript As String = "<SCRIPT language='javascript'> alert('" & sMensaje & "'); </SCRIPT>"

        If Not oPagina.IsStartupScriptRegistered("Alert") Then
            oPagina.RegisterStartupScript("Alert", sScript)
        End If

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
            'I &#205;
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
        End Try

    End Function


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


    Protected Sub asignaCampos()
        Try

            'nombreCliente.Text = Session("Cliente_AutoSys")
            'Session("fechaDiagnostico") = Session("fecha_AutoSys")
            'Session("nombreAsesor") = Session("idAsesor_AutoSys")

            Dim gv40 As New GridView
            Dim gv_36 As New GridView

            sSelCmd = "SELECT id," _
                    & "TipoTrabajo," _
                    & "CAST(LavaCoche AS varchar(1)) AS LavaCoche," _
                    & "CAST(Refaccion AS varchar(1)) AS Refaccion," _
                    & "LLaves,Bahia,HeadFecha,Cliente,NombreModelo,Placas,FechaTermino,HoraTermino,MinutoTermino,FechaEntrega,HoraEntrega,MinutoEntrega," _
                    & "NoOrden,NoTrabajo,DOFU,Asesor,Modelo,Serie,Motor,Telefono_1,Email_1," _
                    & "CAST(Info_1_Casa AS varchar(1)) AS Info_1_Casa,CAST(Info_1_Trabajo AS varchar(1)) AS Info_1_Trabajo," _
                    & "CAST(Info_1_Celular AS varchar(1)) AS Info_1_Celular,CAST(Trabajo_Adicional AS varchar(1)) AS Trabajo_Adicional," _
                    & "CAST(Trabajo_Detencion AS varchar(1)) AS Trabajo_Detencion,CAST(Trabajo_Otro AS varchar(1)) AS Trabajo_Otro," _
                    & "txt_Trabajo_Otro,Detalle_1,NoParte_1,Cantidad_1,Resulta_1,Detalle_2,NoParte_2,Cantidad_2,Resulta_2,Detalle_3,NoParte_3,Cantidad_3,Resulta_3," _
                    & "Detalle_4,NoParte_4,Cantidad_4,Resulta_4,Trabajo_1,Pieza_1,Amount_1,Costo_1," _
                    & "CAST(Stock_1 AS varchar(1)) AS Stock_1," _
                    & "ETA_11,ETA_12,Trabajo_2,Pieza_2,Amount_2,Costo_2," _
                    & "CAST(Stock_2 AS varchar(1)) AS Stock_2," _
                    & "ETA_21,ETA_22,Trabajo_3,Pieza_3,Amount_3,Costo_3," _
                    & "CAST(Stock_3  AS varchar(1)) AS Stock_3," _
                    & "ETA_31,ETA_32,Trabajo_4,Pieza_4,Amount_4,Costo_4,Costo_5," _
                    & "CAST(Stock_4 AS varchar(1)) AS Stock_4," _
                    & "ETA_41,ETA_42,FechaConta,HoraConta,MinutoConta,NombreConta,CambioFechaTermino,CambioHoraTermino,CambioMinutoTermino,CambioFechaEntrega," _
                    & "CambioHoraEntrega,CambioMinutoEntrega,FechaIni_1,HoraIni_1,MinutoIni_1,FechaFin_1,HoraFin_1,MinutoFin_1,TimeHoraIni_1,TimeMinutoIni_1," _
                    & "Tecnico_1," _
                    & "CAST(ControlCalidad_11 AS varchar(1)) AS ControlCalidad_11,CAST(ControlCalidad_12 AS varchar(1)) AS ControlCalidad_12,CAST(ControlCalidad_13 AS varchar(1)) AS ControlCalidad_13," _
                    & "Calidad_1,FechaIni_2,HoraIni_2,MinutoIni_2,FechaFin_2,HoraFin_2,MinutoFin_2,TimeHoraIni_2,TimeMinutoIni_2,Tecnico_2," _
                    & "CAST(ControlCalidad_21 AS varchar(1)) AS ControlCalidad_21,CAST(ControlCalidad_22 AS varchar(1)) AS ControlCalidad_22,CAST(ControlCalidad_23 AS varchar(1)) AS ControlCalidad_23," _
                    & "Calidad_2,FechaIni_3,HoraIni_3,MinutoIni_3,FechaFin_3,HoraFin_3,MinutoFin_3,TimeHoraIni_3,TimeMinutoIni_3,Tecnico_3," _
                    & "CAST(ControlCalidad_31 AS varchar(1)) AS ControlCalidad_31,CAST(ControlCalidad_32 AS varchar(1)) AS ControlCalidad_32,CAST(ControlCalidad_33 AS varchar(1)) AS ControlCalidad_33," _
                    & "Calidad_3,FechaIni_4,HoraIni_4,MinutoIni_4,FechaFin_4,HoraFin_4,MinutoFin_4,TimeHoraIni_4,TimeMinutoIni_4,Tecnico_4," _
                    & "CAST(ControlCalidad_41 AS varchar(1)) AS ControlCalidad_41,CAST(ControlCalidad_42 AS varchar(1)) AS ControlCalidad_42,CAST(ControlCalidad_43 AS varchar(1)) AS ControlCalidad_43," _
                    & "Calidad_4,Comentario,Observacion," _
                    & "CAST(CfrEntrega_1 AS varchar(1)) AS CfrEntrega_1,CAST(CfrEntrega_2 AS varchar(1)) AS CfrEntrega_2,CAST(CfrEntrega_3 AS varchar(1)) AS CfrEntrega_3,CAST(CfrEntrega_4 AS varchar(1)) AS CfrEntrega_4," _
                    & "FechaAviso,HoraAviso,MinutoAviso," _
                    & "CAST(CfrExplicacion_11 AS varchar(1)) AS CfrExplicacion_11,CAST(CfrExplicacion_12 AS varchar(1)) AS CfrExplicacion_12," _
                    & "CAST(CfrExplicacion_13 AS varchar(1)) AS CfrExplicacion_13,CAST(CfrExplicacion_14 AS varchar(1)) AS CfrExplicacion_14," _
                    & "CAST(CfrExplicacion_21 AS varchar(1)) AS CfrExplicacion_21,CAST(CfrExplicacion_22 AS varchar(1)) AS CfrExplicacion_22," _
                    & "CAST(CfrExplicacion_23 AS varchar(1)) AS CfrExplicacion_23,CAST(CfrExplicacion_24 AS varchar(1)) AS CfrExplicacion_24," _
                    & "CfrFechaEntrega,CfrHoraEntrega,CfrMinutoEntrega," _
                    & "CAST(Cfr_Cliente_1 AS varchar(1)) AS Cfr_Cliente_1,CAST(Cfr_Cliente_2 AS varchar(1)) AS Cfr_Cliente_2,CAST(Cfr_Cliente_3 AS varchar(1)) AS Cfr_Cliente_3," _
                    & "CfrClienteOtro,CfrConfirmadoPor,CfrNombre1,CfrNombre2,CfrNombre3,CfrNombre4,PlanFechaPSFU,PlanHoraPSFU,PlanMinutoPSFU," _
                    & "CAST(InfContacto_1 AS varchar(1)) AS InfContacto_1,CAST(InfContacto_2 AS varchar(1)) AS InfContacto_2,CAST(InfContacto_3 AS varchar(1)) AS InfContacto_3," _
                    & "CAST(Info_2_Casa AS varchar(1)) AS Info_2_Casa,CAST(Info_2_Trabajo AS varchar(1)) AS Info_2_Trabajo,CAST(Info_2_Celular AS varchar(1)) AS Info_2_Celular," _
                    & "Telefono_2,Email_2,Otro_2,RealFechaPSFU,RealHoraPSFU,RealMinutoPSFU," _
                    & "CAST(PSFU_Cliente_1 AS varchar(1)) AS PSFU_Cliente_1,CAST(PSFU_Cliente_2 AS varchar(1)) AS PSFU_Cliente_2,CAST(PSFU_Cliente_3 AS varchar(1)) AS PSFU_Cliente_3," _
                    & "PSFUClienteOtro," _
                    & "CAST(PSFUcontacto_1 AS varchar(1)) AS PSFUcontacto_1,CAST(PSFUcontacto_2 AS varchar(1)) AS PSFUcontacto_2,CAST(PSFUcontacto_3 AS varchar(1)) AS PSFUcontacto_3," _
                    & "FechaLLamar, HoraLLamar, MinutoLLamar, FechaRepetir, HoraRepetir, MinutoRepetir, PSFUnombre, PSFUconfirma, " _
                    & "CAST(CfrFechaEntrega_1 AS varchar(1)) AS CfrFechaEntrega_1" _
                    & "  FROM TYT_KDW_FORMATO_TRABAJO WHERE idCita = " & "'" & Session("OS") & "'"

            'response.write(sSelCmd)

            SqlDataSource40.SelectCommand = sSelCmd

            gv40.DataSource = SqlDataSource40
            gv40.DataBind()

            If gv40.Rows.Count > 0 Then



                If gv40.Rows(0).Cells(1).Text <> "" And gv40.Rows(0).Cells(1).Text <> Nothing And gv40.Rows(0).Cells(1).Text <> "&nbsp;" Then txtTipoTrabajo.Text = gv40.Rows(0).Cells(1).Text

                If Val(gv40.Rows(0).Cells(2).Text) = 1 Then cbl_LavaCoche.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(3).Text) = 1 Then cbl_Refaccion.Items(0).Selected = True

                If gv40.Rows(0).Cells(4).Text <> "" And gv40.Rows(0).Cells(4).Text <> Nothing And gv40.Rows(0).Cells(4).Text <> "&nbsp;" Then txtLLaves.Text = gv40.Rows(0).Cells(4).Text
                If gv40.Rows(0).Cells(5).Text <> "" And gv40.Rows(0).Cells(5).Text <> Nothing And gv40.Rows(0).Cells(5).Text <> "&nbsp;" Then txtBahia.Text = gv40.Rows(0).Cells(5).Text
                If gv40.Rows(0).Cells(6).Text <> "" And gv40.Rows(0).Cells(6).Text <> Nothing And gv40.Rows(0).Cells(6).Text <> "&nbsp;" Then txtHeadFecha.Text = gv40.Rows(0).Cells(6).Text


                If gv40.Rows(0).Cells(7).Text <> "" And gv40.Rows(0).Cells(7).Text <> Nothing And gv40.Rows(0).Cells(7).Text <> "&nbsp;" Then txtCliente.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(7).Text))


                If gv40.Rows(0).Cells(8).Text <> "" And gv40.Rows(0).Cells(8).Text <> Nothing And gv40.Rows(0).Cells(8).Text <> "&nbsp;" Then txtNombreModelo.Text = gv40.Rows(0).Cells(8).Text
                If gv40.Rows(0).Cells(9).Text <> "" And gv40.Rows(0).Cells(9).Text <> Nothing And gv40.Rows(0).Cells(9).Text <> "&nbsp;" Then txtPlacas.Text = gv40.Rows(0).Cells(9).Text
                If gv40.Rows(0).Cells(10).Text <> "" And gv40.Rows(0).Cells(10).Text <> Nothing And gv40.Rows(0).Cells(10).Text <> "&nbsp;" Then txtFechaTermino.Text = gv40.Rows(0).Cells(10).Text

                If gv40.Rows(0).Cells(11).Text <> "" And gv40.Rows(0).Cells(11).Text <> Nothing And gv40.Rows(0).Cells(11).Text <> "&nbsp;" Then txtHoraTermino.Text = gv40.Rows(0).Cells(11).Text
                If gv40.Rows(0).Cells(12).Text <> "" And gv40.Rows(0).Cells(12).Text <> Nothing And gv40.Rows(0).Cells(12).Text <> "&nbsp;" Then txtMinutoTermino.Text = gv40.Rows(0).Cells(12).Text

                If gv40.Rows(0).Cells(13).Text <> "" And gv40.Rows(0).Cells(13).Text <> Nothing And gv40.Rows(0).Cells(13).Text <> "&nbsp;" Then txtFechaEntrega.Text = gv40.Rows(0).Cells(13).Text

                If gv40.Rows(0).Cells(14).Text <> "" And gv40.Rows(0).Cells(14).Text <> Nothing And gv40.Rows(0).Cells(14).Text <> "&nbsp;" Then txtHoraEntrega.Text = gv40.Rows(0).Cells(14).Text
                If gv40.Rows(0).Cells(15).Text <> "" And gv40.Rows(0).Cells(15).Text <> Nothing And gv40.Rows(0).Cells(15).Text <> "&nbsp;" Then txtMinutoEntrega.Text = gv40.Rows(0).Cells(15).Text

                If gv40.Rows(0).Cells(16).Text <> "" And gv40.Rows(0).Cells(16).Text <> Nothing And gv40.Rows(0).Cells(16).Text <> "&nbsp;" Then txtNoOrden.Text = gv40.Rows(0).Cells(16).Text
                If gv40.Rows(0).Cells(17).Text <> "" And gv40.Rows(0).Cells(17).Text <> Nothing And gv40.Rows(0).Cells(17).Text <> "&nbsp;" Then txtNoTrabajo.Text = gv40.Rows(0).Cells(17).Text
                If gv40.Rows(0).Cells(18).Text <> "" And gv40.Rows(0).Cells(18).Text <> Nothing And gv40.Rows(0).Cells(18).Text <> "&nbsp;" Then txtDOFU.Text = gv40.Rows(0).Cells(18).Text
                If gv40.Rows(0).Cells(19).Text <> "" And gv40.Rows(0).Cells(19).Text <> Nothing And gv40.Rows(0).Cells(19).Text <> "&nbsp;" Then txtAsesor.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(19).Text))
                If gv40.Rows(0).Cells(20).Text <> "" And gv40.Rows(0).Cells(20).Text <> Nothing And gv40.Rows(0).Cells(20).Text <> "&nbsp;" Then txtModelo.Text = gv40.Rows(0).Cells(20).Text
                If gv40.Rows(0).Cells(21).Text <> "" And gv40.Rows(0).Cells(21).Text <> Nothing And gv40.Rows(0).Cells(21).Text <> "&nbsp;" Then txtSerie.Text = gv40.Rows(0).Cells(21).Text
                If gv40.Rows(0).Cells(22).Text <> "" And gv40.Rows(0).Cells(22).Text <> Nothing And gv40.Rows(0).Cells(22).Text <> "&nbsp;" Then txtMotor.Text = gv40.Rows(0).Cells(22).Text
                If gv40.Rows(0).Cells(23).Text <> "" And gv40.Rows(0).Cells(23).Text <> Nothing And gv40.Rows(0).Cells(23).Text <> "&nbsp;" Then txtTelefono_1.Text = gv40.Rows(0).Cells(23).Text
                If gv40.Rows(0).Cells(24).Text <> "" And gv40.Rows(0).Cells(24).Text <> Nothing And gv40.Rows(0).Cells(24).Text <> "&nbsp;" Then txtEmail_1.Text = gv40.Rows(0).Cells(24).Text

                If Val(gv40.Rows(0).Cells(25).Text) = 1 Then rbl_Info_1.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(26).Text) = 1 Then rbl_Info_1.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(27).Text) = 1 Then rbl_Info_1.Items(2).Selected = True

                If Val(gv40.Rows(0).Cells(28).Text) = 1 Then rbl_CambioFecha.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(29).Text) = 1 Then rbl_CambioFecha.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(30).Text) = 1 Then rbl_CambioFecha.Items(2).Selected = True

                If gv40.Rows(0).Cells(31).Text <> "" And gv40.Rows(0).Cells(31).Text <> Nothing And gv40.Rows(0).Cells(31).Text <> "&nbsp;" Then txtTrabajo_Otro.Text = gv40.Rows(0).Cells(31).Text

                If gv40.Rows(0).Cells(32).Text <> "" And gv40.Rows(0).Cells(32).Text <> Nothing And gv40.Rows(0).Cells(32).Text <> "&nbsp;" Then Session("Detalle_1") = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(32).Text))
                If gv40.Rows(0).Cells(33).Text <> "" And gv40.Rows(0).Cells(33).Text <> Nothing And gv40.Rows(0).Cells(33).Text <> "&nbsp;" Then Session("NoParte_1") = gv40.Rows(0).Cells(33).Text
                If gv40.Rows(0).Cells(34).Text <> "" And gv40.Rows(0).Cells(34).Text <> Nothing And gv40.Rows(0).Cells(34).Text <> "&nbsp;" Then Session("Cantidad_1") = gv40.Rows(0).Cells(34).Text
                If gv40.Rows(0).Cells(35).Text <> "" And gv40.Rows(0).Cells(35).Text <> Nothing And gv40.Rows(0).Cells(35).Text <> "&nbsp;" Then Session("Resulta_1") = gv40.Rows(0).Cells(35).Text
                If gv40.Rows(0).Cells(36).Text <> "" And gv40.Rows(0).Cells(36).Text <> Nothing And gv40.Rows(0).Cells(36).Text <> "&nbsp;" Then Session("Detalle_2") = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(36).Text))
                If gv40.Rows(0).Cells(37).Text <> "" And gv40.Rows(0).Cells(37).Text <> Nothing And gv40.Rows(0).Cells(37).Text <> "&nbsp;" Then Session("NoParte_2") = gv40.Rows(0).Cells(37).Text
                If gv40.Rows(0).Cells(38).Text <> "" And gv40.Rows(0).Cells(38).Text <> Nothing And gv40.Rows(0).Cells(38).Text <> "&nbsp;" Then Session("Cantidad_2") = gv40.Rows(0).Cells(38).Text
                If gv40.Rows(0).Cells(39).Text <> "" And gv40.Rows(0).Cells(39).Text <> Nothing And gv40.Rows(0).Cells(39).Text <> "&nbsp;" Then Session("Resulta_2") = gv40.Rows(0).Cells(39).Text
                If gv40.Rows(0).Cells(40).Text <> "" And gv40.Rows(0).Cells(40).Text <> Nothing And gv40.Rows(0).Cells(40).Text <> "&nbsp;" Then Session("Detalle_3") = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(40).Text))
                If gv40.Rows(0).Cells(41).Text <> "" And gv40.Rows(0).Cells(41).Text <> Nothing And gv40.Rows(0).Cells(41).Text <> "&nbsp;" Then Session("NoParte_3") = gv40.Rows(0).Cells(41).Text
                If gv40.Rows(0).Cells(42).Text <> "" And gv40.Rows(0).Cells(42).Text <> Nothing And gv40.Rows(0).Cells(42).Text <> "&nbsp;" Then Session("Cantidad_3") = gv40.Rows(0).Cells(42).Text
                If gv40.Rows(0).Cells(43).Text <> "" And gv40.Rows(0).Cells(43).Text <> Nothing And gv40.Rows(0).Cells(43).Text <> "&nbsp;" Then Session("Resulta_3") = gv40.Rows(0).Cells(43).Text
                If gv40.Rows(0).Cells(44).Text <> "" And gv40.Rows(0).Cells(44).Text <> Nothing And gv40.Rows(0).Cells(44).Text <> "&nbsp;" Then Session("Detalle_4") = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(44).Text))
                If gv40.Rows(0).Cells(45).Text <> "" And gv40.Rows(0).Cells(45).Text <> Nothing And gv40.Rows(0).Cells(45).Text <> "&nbsp;" Then Session("NoParte_4") = gv40.Rows(0).Cells(45).Text
                If gv40.Rows(0).Cells(46).Text <> "" And gv40.Rows(0).Cells(46).Text <> Nothing And gv40.Rows(0).Cells(46).Text <> "&nbsp;" Then Session("Cantidad_4") = gv40.Rows(0).Cells(46).Text
                If gv40.Rows(0).Cells(47).Text <> "" And gv40.Rows(0).Cells(47).Text <> Nothing And gv40.Rows(0).Cells(47).Text <> "&nbsp;" Then Session("Resulta_4") = gv40.Rows(0).Cells(47).Text

                If gv40.Rows(0).Cells(48).Text <> "" And gv40.Rows(0).Cells(48).Text <> Nothing And gv40.Rows(0).Cells(48).Text <> "&nbsp;" Then txtTrabajo_1.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(48).Text))
                If gv40.Rows(0).Cells(49).Text <> "" And gv40.Rows(0).Cells(49).Text <> Nothing And gv40.Rows(0).Cells(49).Text <> "&nbsp;" Then txtPieza_1.Text = gv40.Rows(0).Cells(49).Text
                If gv40.Rows(0).Cells(50).Text <> "" And gv40.Rows(0).Cells(50).Text <> Nothing And gv40.Rows(0).Cells(50).Text <> "&nbsp;" Then txtAmount_1.Text = gv40.Rows(0).Cells(50).Text
                If gv40.Rows(0).Cells(51).Text <> "" And gv40.Rows(0).Cells(51).Text <> Nothing And gv40.Rows(0).Cells(51).Text <> "&nbsp;" Then txtCosto_1.Text = gv40.Rows(0).Cells(51).Text

                ddl_Stock_1.SelectedValue = Val(gv40.Rows(0).Cells(52).Text)

                If gv40.Rows(0).Cells(53).Text <> "" And gv40.Rows(0).Cells(53).Text <> Nothing And gv40.Rows(0).Cells(53).Text <> "&nbsp;" Then txtETA_11.Text = gv40.Rows(0).Cells(53).Text
                If gv40.Rows(0).Cells(54).Text <> "" And gv40.Rows(0).Cells(54).Text <> Nothing And gv40.Rows(0).Cells(54).Text <> "&nbsp;" Then txtETA_12.Text = gv40.Rows(0).Cells(54).Text
                If gv40.Rows(0).Cells(55).Text <> "" And gv40.Rows(0).Cells(55).Text <> Nothing And gv40.Rows(0).Cells(55).Text <> "&nbsp;" Then txtTrabajo_2.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(55).Text))
                If gv40.Rows(0).Cells(56).Text <> "" And gv40.Rows(0).Cells(56).Text <> Nothing And gv40.Rows(0).Cells(56).Text <> "&nbsp;" Then txtPieza_2.Text = gv40.Rows(0).Cells(56).Text
                If gv40.Rows(0).Cells(57).Text <> "" And gv40.Rows(0).Cells(57).Text <> Nothing And gv40.Rows(0).Cells(57).Text <> "&nbsp;" Then txtAmount_2.Text = gv40.Rows(0).Cells(57).Text
                If gv40.Rows(0).Cells(58).Text <> "" And gv40.Rows(0).Cells(58).Text <> Nothing And gv40.Rows(0).Cells(58).Text <> "&nbsp;" Then txtCosto_2.Text = gv40.Rows(0).Cells(58).Text

                ddl_Stock_2.SelectedValue = Val(gv40.Rows(0).Cells(59).Text)

                If gv40.Rows(0).Cells(60).Text <> "" And gv40.Rows(0).Cells(60).Text <> Nothing And gv40.Rows(0).Cells(60).Text <> "&nbsp;" Then txtETA_21.Text = gv40.Rows(0).Cells(60).Text
                If gv40.Rows(0).Cells(61).Text <> "" And gv40.Rows(0).Cells(61).Text <> Nothing And gv40.Rows(0).Cells(61).Text <> "&nbsp;" Then txtETA_22.Text = gv40.Rows(0).Cells(61).Text
                If gv40.Rows(0).Cells(62).Text <> "" And gv40.Rows(0).Cells(62).Text <> Nothing And gv40.Rows(0).Cells(62).Text <> "&nbsp;" Then txtTrabajo_3.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(62).Text))
                If gv40.Rows(0).Cells(63).Text <> "" And gv40.Rows(0).Cells(63).Text <> Nothing And gv40.Rows(0).Cells(63).Text <> "&nbsp;" Then txtPieza_3.Text = gv40.Rows(0).Cells(63).Text
                If gv40.Rows(0).Cells(64).Text <> "" And gv40.Rows(0).Cells(64).Text <> Nothing And gv40.Rows(0).Cells(64).Text <> "&nbsp;" Then txtAmount_3.Text = gv40.Rows(0).Cells(64).Text
                If gv40.Rows(0).Cells(65).Text <> "" And gv40.Rows(0).Cells(65).Text <> Nothing And gv40.Rows(0).Cells(65).Text <> "&nbsp;" Then txtCosto_3.Text = gv40.Rows(0).Cells(65).Text

                ddl_Stock_3.SelectedValue = Val(gv40.Rows(0).Cells(66).Text)

                If gv40.Rows(0).Cells(67).Text <> "" And gv40.Rows(0).Cells(67).Text <> Nothing And gv40.Rows(0).Cells(67).Text <> "&nbsp;" Then txtETA_31.Text = gv40.Rows(0).Cells(67).Text
                If gv40.Rows(0).Cells(68).Text <> "" And gv40.Rows(0).Cells(68).Text <> Nothing And gv40.Rows(0).Cells(68).Text <> "&nbsp;" Then txtETA_32.Text = gv40.Rows(0).Cells(68).Text
                If gv40.Rows(0).Cells(69).Text <> "" And gv40.Rows(0).Cells(69).Text <> Nothing And gv40.Rows(0).Cells(69).Text <> "&nbsp;" Then txtTrabajo_4.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(69).Text))
                If gv40.Rows(0).Cells(70).Text <> "" And gv40.Rows(0).Cells(70).Text <> Nothing And gv40.Rows(0).Cells(70).Text <> "&nbsp;" Then txtPieza_4.Text = gv40.Rows(0).Cells(70).Text
                If gv40.Rows(0).Cells(71).Text <> "" And gv40.Rows(0).Cells(71).Text <> Nothing And gv40.Rows(0).Cells(71).Text <> "&nbsp;" Then txtAmount_4.Text = gv40.Rows(0).Cells(71).Text
                If gv40.Rows(0).Cells(72).Text <> "" And gv40.Rows(0).Cells(72).Text <> Nothing And gv40.Rows(0).Cells(72).Text <> "&nbsp;" Then txtCosto_4.Text = gv40.Rows(0).Cells(72).Text
                If gv40.Rows(0).Cells(73).Text <> "" And gv40.Rows(0).Cells(73).Text <> Nothing And gv40.Rows(0).Cells(73).Text <> "&nbsp;" Then txtCosto_5.Text = gv40.Rows(0).Cells(73).Text

                Session("costo") = 0
                If IsNumeric(txtCosto_1.Text) Then Session("costo") = Session("costo") + Val(txtCosto_1.Text)
                If IsNumeric(txtCosto_2.Text) Then Session("costo") = Session("costo") + Val(txtCosto_2.Text)
                If IsNumeric(txtCosto_3.Text) Then Session("costo") = Session("costo") + Val(txtCosto_3.Text)
                If IsNumeric(txtCosto_4.Text) Then Session("costo") = Session("costo") + Val(txtCosto_4.Text)
                txtCosto_5.Text = Session("costo")

                ddl_Stock_4.SelectedValue = Val(gv40.Rows(0).Cells(74).Text)

                If gv40.Rows(0).Cells(75).Text <> "" And gv40.Rows(0).Cells(75).Text <> Nothing And gv40.Rows(0).Cells(75).Text <> "&nbsp;" Then txtETA_41.Text = gv40.Rows(0).Cells(75).Text
                If gv40.Rows(0).Cells(76).Text <> "" And gv40.Rows(0).Cells(76).Text <> Nothing And gv40.Rows(0).Cells(76).Text <> "&nbsp;" Then txtETA_42.Text = gv40.Rows(0).Cells(76).Text
                If gv40.Rows(0).Cells(77).Text <> "" And gv40.Rows(0).Cells(77).Text <> Nothing And gv40.Rows(0).Cells(77).Text <> "&nbsp;" Then txtFechaConta.Text = gv40.Rows(0).Cells(77).Text
                If gv40.Rows(0).Cells(78).Text <> "" And gv40.Rows(0).Cells(78).Text <> Nothing And gv40.Rows(0).Cells(78).Text <> "&nbsp;" Then txtHoraConta.Text = gv40.Rows(0).Cells(78).Text
                If gv40.Rows(0).Cells(79).Text <> "" And gv40.Rows(0).Cells(79).Text <> Nothing And gv40.Rows(0).Cells(79).Text <> "&nbsp;" Then txtMinutoConta.Text = gv40.Rows(0).Cells(79).Text
                If gv40.Rows(0).Cells(80).Text <> "" And gv40.Rows(0).Cells(80).Text <> Nothing And gv40.Rows(0).Cells(80).Text <> "&nbsp;" Then txtNombreConta.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(80).Text))
                If gv40.Rows(0).Cells(81).Text <> "" And gv40.Rows(0).Cells(81).Text <> Nothing And gv40.Rows(0).Cells(81).Text <> "&nbsp;" Then txtCambioFechaTermino.Text = gv40.Rows(0).Cells(81).Text
                If gv40.Rows(0).Cells(82).Text <> "" And gv40.Rows(0).Cells(82).Text <> Nothing And gv40.Rows(0).Cells(82).Text <> "&nbsp;" Then txtCambioHoraTermino.Text = gv40.Rows(0).Cells(82).Text
                If gv40.Rows(0).Cells(83).Text <> "" And gv40.Rows(0).Cells(83).Text <> Nothing And gv40.Rows(0).Cells(83).Text <> "&nbsp;" Then txtCambioMinutoTermino.Text = gv40.Rows(0).Cells(83).Text
                If gv40.Rows(0).Cells(84).Text <> "" And gv40.Rows(0).Cells(84).Text <> Nothing And gv40.Rows(0).Cells(84).Text <> "&nbsp;" Then txtCambioFechaEntrega.Text = gv40.Rows(0).Cells(84).Text
                If gv40.Rows(0).Cells(85).Text <> "" And gv40.Rows(0).Cells(85).Text <> Nothing And gv40.Rows(0).Cells(85).Text <> "&nbsp;" Then txtCambioHoraEntrega.Text = gv40.Rows(0).Cells(85).Text
                If gv40.Rows(0).Cells(86).Text <> "" And gv40.Rows(0).Cells(86).Text <> Nothing And gv40.Rows(0).Cells(86).Text <> "&nbsp;" Then txtCambioMinutoEntrega.Text = gv40.Rows(0).Cells(86).Text
                If gv40.Rows(0).Cells(87).Text <> "" And gv40.Rows(0).Cells(87).Text <> Nothing And gv40.Rows(0).Cells(87).Text <> "&nbsp;" Then txtFechaIni_1.Text = gv40.Rows(0).Cells(87).Text
                If gv40.Rows(0).Cells(88).Text <> "" And gv40.Rows(0).Cells(88).Text <> Nothing And gv40.Rows(0).Cells(88).Text <> "&nbsp;" Then txtHoraIni_1.Text = gv40.Rows(0).Cells(88).Text
                If gv40.Rows(0).Cells(89).Text <> "" And gv40.Rows(0).Cells(89).Text <> Nothing And gv40.Rows(0).Cells(89).Text <> "&nbsp;" Then txtMinutoIni_1.Text = gv40.Rows(0).Cells(89).Text
                If gv40.Rows(0).Cells(90).Text <> "" And gv40.Rows(0).Cells(90).Text <> Nothing And gv40.Rows(0).Cells(90).Text <> "&nbsp;" Then txtFechaFin_1.Text = gv40.Rows(0).Cells(90).Text
                If gv40.Rows(0).Cells(91).Text <> "" And gv40.Rows(0).Cells(91).Text <> Nothing And gv40.Rows(0).Cells(91).Text <> "&nbsp;" Then txtHoraFin_1.Text = gv40.Rows(0).Cells(91).Text
                If gv40.Rows(0).Cells(92).Text <> "" And gv40.Rows(0).Cells(92).Text <> Nothing And gv40.Rows(0).Cells(92).Text <> "&nbsp;" Then txtMinutoFin_1.Text = gv40.Rows(0).Cells(92).Text
                If gv40.Rows(0).Cells(93).Text <> "" And gv40.Rows(0).Cells(93).Text <> Nothing And gv40.Rows(0).Cells(93).Text <> "&nbsp;" Then txtTimeHoraIni_1.Text = gv40.Rows(0).Cells(93).Text
                If gv40.Rows(0).Cells(94).Text <> "" And gv40.Rows(0).Cells(94).Text <> Nothing And gv40.Rows(0).Cells(94).Text <> "&nbsp;" Then txtTimeMinutoIni_1.Text = gv40.Rows(0).Cells(94).Text
                If gv40.Rows(0).Cells(95).Text <> "" And gv40.Rows(0).Cells(95).Text <> Nothing And gv40.Rows(0).Cells(95).Text <> "&nbsp;" Then txtTecnico_1.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(95).Text))

                If Val(gv40.Rows(0).Cells(96).Text) = 1 Then cbl_CC_1.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(97).Text) = 1 Then cbl_CC_1.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(98).Text) = 1 Then cbl_CC_1.Items(2).Selected = True

                If gv40.Rows(0).Cells(99).Text <> "" And gv40.Rows(0).Cells(99).Text <> Nothing And gv40.Rows(0).Cells(99).Text <> "&nbsp;" Then txtCalidad_1.Text = gv40.Rows(0).Cells(99).Text
                If gv40.Rows(0).Cells(100).Text <> "" And gv40.Rows(0).Cells(100).Text <> Nothing And gv40.Rows(0).Cells(100).Text <> "&nbsp;" Then txtFechaIni_2.Text = gv40.Rows(0).Cells(100).Text
                If gv40.Rows(0).Cells(101).Text <> "" And gv40.Rows(0).Cells(101).Text <> Nothing And gv40.Rows(0).Cells(101).Text <> "&nbsp;" Then txtHoraIni_2.Text = gv40.Rows(0).Cells(101).Text
                If gv40.Rows(0).Cells(102).Text <> "" And gv40.Rows(0).Cells(102).Text <> Nothing And gv40.Rows(0).Cells(102).Text <> "&nbsp;" Then txtMinutoIni_2.Text = gv40.Rows(0).Cells(102).Text
                If gv40.Rows(0).Cells(103).Text <> "" And gv40.Rows(0).Cells(103).Text <> Nothing And gv40.Rows(0).Cells(103).Text <> "&nbsp;" Then txtFechaFin_2.Text = gv40.Rows(0).Cells(103).Text
                If gv40.Rows(0).Cells(104).Text <> "" And gv40.Rows(0).Cells(104).Text <> Nothing And gv40.Rows(0).Cells(104).Text <> "&nbsp;" Then txtHoraFin_2.Text = gv40.Rows(0).Cells(104).Text
                If gv40.Rows(0).Cells(105).Text <> "" And gv40.Rows(0).Cells(105).Text <> Nothing And gv40.Rows(0).Cells(105).Text <> "&nbsp;" Then txtMinutoFin_2.Text = gv40.Rows(0).Cells(105).Text
                If gv40.Rows(0).Cells(106).Text <> "" And gv40.Rows(0).Cells(106).Text <> Nothing And gv40.Rows(0).Cells(106).Text <> "&nbsp;" Then txtTimeHoraIni_2.Text = gv40.Rows(0).Cells(106).Text
                If gv40.Rows(0).Cells(107).Text <> "" And gv40.Rows(0).Cells(107).Text <> Nothing And gv40.Rows(0).Cells(107).Text <> "&nbsp;" Then txtTimeMinutoIni_2.Text = gv40.Rows(0).Cells(107).Text
                If gv40.Rows(0).Cells(108).Text <> "" And gv40.Rows(0).Cells(108).Text <> Nothing And gv40.Rows(0).Cells(108).Text <> "&nbsp;" Then txtTecnico_2.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(108).Text))

                If Val(gv40.Rows(0).Cells(109).Text) = 1 Then cbl_CC_2.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(110).Text) = 1 Then cbl_CC_2.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(111).Text) = 1 Then cbl_CC_2.Items(2).Selected = True

                If gv40.Rows(0).Cells(112).Text <> "" And gv40.Rows(0).Cells(112).Text <> Nothing And gv40.Rows(0).Cells(112).Text <> "&nbsp;" Then txtCalidad_2.Text = gv40.Rows(0).Cells(112).Text
                If gv40.Rows(0).Cells(113).Text <> "" And gv40.Rows(0).Cells(113).Text <> Nothing And gv40.Rows(0).Cells(113).Text <> "&nbsp;" Then txtFechaIni_3.Text = gv40.Rows(0).Cells(113).Text
                If gv40.Rows(0).Cells(114).Text <> "" And gv40.Rows(0).Cells(114).Text <> Nothing And gv40.Rows(0).Cells(114).Text <> "&nbsp;" Then txtHoraIni_3.Text = gv40.Rows(0).Cells(114).Text
                If gv40.Rows(0).Cells(115).Text <> "" And gv40.Rows(0).Cells(115).Text <> Nothing And gv40.Rows(0).Cells(115).Text <> "&nbsp;" Then txtMinutoIni_3.Text = gv40.Rows(0).Cells(115).Text
                If gv40.Rows(0).Cells(116).Text <> "" And gv40.Rows(0).Cells(116).Text <> Nothing And gv40.Rows(0).Cells(116).Text <> "&nbsp;" Then txtFechaFin_3.Text = gv40.Rows(0).Cells(116).Text
                If gv40.Rows(0).Cells(117).Text <> "" And gv40.Rows(0).Cells(117).Text <> Nothing And gv40.Rows(0).Cells(117).Text <> "&nbsp;" Then txtHoraFin_3.Text = gv40.Rows(0).Cells(117).Text
                If gv40.Rows(0).Cells(118).Text <> "" And gv40.Rows(0).Cells(118).Text <> Nothing And gv40.Rows(0).Cells(118).Text <> "&nbsp;" Then txtMinutoFin_3.Text = gv40.Rows(0).Cells(118).Text
                If gv40.Rows(0).Cells(119).Text <> "" And gv40.Rows(0).Cells(119).Text <> Nothing And gv40.Rows(0).Cells(119).Text <> "&nbsp;" Then txtTimeHoraIni_3.Text = gv40.Rows(0).Cells(119).Text
                If gv40.Rows(0).Cells(120).Text <> "" And gv40.Rows(0).Cells(120).Text <> Nothing And gv40.Rows(0).Cells(120).Text <> "&nbsp;" Then txtTimeMinutoIni_3.Text = gv40.Rows(0).Cells(120).Text
                If gv40.Rows(0).Cells(121).Text <> "" And gv40.Rows(0).Cells(121).Text <> Nothing And gv40.Rows(0).Cells(121).Text <> "&nbsp;" Then txtTecnico_3.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(121).Text))

                If Val(gv40.Rows(0).Cells(122).Text) = 1 Then cbl_CC_3.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(123).Text) = 1 Then cbl_CC_3.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(124).Text) = 1 Then cbl_CC_3.Items(2).Selected = True


                If gv40.Rows(0).Cells(125).Text <> "" And gv40.Rows(0).Cells(125).Text <> Nothing And gv40.Rows(0).Cells(125).Text <> "&nbsp;" Then txtCalidad_3.Text = gv40.Rows(0).Cells(125).Text
                If gv40.Rows(0).Cells(126).Text <> "" And gv40.Rows(0).Cells(126).Text <> Nothing And gv40.Rows(0).Cells(126).Text <> "&nbsp;" Then txtFechaIni_4.Text = gv40.Rows(0).Cells(126).Text
                If gv40.Rows(0).Cells(127).Text <> "" And gv40.Rows(0).Cells(127).Text <> Nothing And gv40.Rows(0).Cells(127).Text <> "&nbsp;" Then txtHoraIni_4.Text = gv40.Rows(0).Cells(127).Text
                If gv40.Rows(0).Cells(128).Text <> "" And gv40.Rows(0).Cells(128).Text <> Nothing And gv40.Rows(0).Cells(128).Text <> "&nbsp;" Then txtMinutoIni_4.Text = gv40.Rows(0).Cells(128).Text
                If gv40.Rows(0).Cells(129).Text <> "" And gv40.Rows(0).Cells(129).Text <> Nothing And gv40.Rows(0).Cells(129).Text <> "&nbsp;" Then txtFechaFin_4.Text = gv40.Rows(0).Cells(129).Text
                If gv40.Rows(0).Cells(130).Text <> "" And gv40.Rows(0).Cells(130).Text <> Nothing And gv40.Rows(0).Cells(130).Text <> "&nbsp;" Then txtHoraFin_4.Text = gv40.Rows(0).Cells(130).Text
                If gv40.Rows(0).Cells(131).Text <> "" And gv40.Rows(0).Cells(131).Text <> Nothing And gv40.Rows(0).Cells(131).Text <> "&nbsp;" Then txtMinutoFin_4.Text = gv40.Rows(0).Cells(131).Text
                If gv40.Rows(0).Cells(132).Text <> "" And gv40.Rows(0).Cells(132).Text <> Nothing And gv40.Rows(0).Cells(132).Text <> "&nbsp;" Then txtTimeHoraIni_4.Text = gv40.Rows(0).Cells(132).Text
                If gv40.Rows(0).Cells(133).Text <> "" And gv40.Rows(0).Cells(133).Text <> Nothing And gv40.Rows(0).Cells(133).Text <> "&nbsp;" Then txtTimeMinutoIni_4.Text = gv40.Rows(0).Cells(133).Text
                If gv40.Rows(0).Cells(134).Text <> "" And gv40.Rows(0).Cells(134).Text <> Nothing And gv40.Rows(0).Cells(134).Text <> "&nbsp;" Then txtTecnico_4.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(134).Text))

                If Val(gv40.Rows(0).Cells(135).Text) = 1 Then cbl_CC_4.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(136).Text) = 1 Then cbl_CC_4.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(137).Text) = 1 Then cbl_CC_4.Items(2).Selected = True


                If gv40.Rows(0).Cells(138).Text <> "" And gv40.Rows(0).Cells(138).Text <> Nothing And gv40.Rows(0).Cells(138).Text <> "&nbsp;" Then txtCalidad_4.Text = gv40.Rows(0).Cells(138).Text
                If gv40.Rows(0).Cells(139).Text <> "" And gv40.Rows(0).Cells(139).Text <> Nothing And gv40.Rows(0).Cells(139).Text <> "&nbsp;" Then txtComentario.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(139).Text))
                If gv40.Rows(0).Cells(140).Text <> "" And gv40.Rows(0).Cells(140).Text <> Nothing And gv40.Rows(0).Cells(140).Text <> "&nbsp;" Then txtObservacion.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(140).Text))


                If Val(gv40.Rows(0).Cells(141).Text) = 1 Then cbl_CfrEntrega.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(142).Text) = 1 Then cbl_CfrEntrega.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(143).Text) = 1 Then cbl_CfrEntrega.Items(2).Selected = True
                If Val(gv40.Rows(0).Cells(144).Text) = 1 Then cbl_CfrEntrega.Items(3).Selected = True

                If gv40.Rows(0).Cells(145).Text <> "" And gv40.Rows(0).Cells(145).Text <> Nothing And gv40.Rows(0).Cells(145).Text <> "&nbsp;" Then txtFechaAviso.Text = gv40.Rows(0).Cells(145).Text
                If gv40.Rows(0).Cells(146).Text <> "" And gv40.Rows(0).Cells(146).Text <> Nothing And gv40.Rows(0).Cells(146).Text <> "&nbsp;" Then txtHoraAviso.Text = gv40.Rows(0).Cells(146).Text
                If gv40.Rows(0).Cells(147).Text <> "" And gv40.Rows(0).Cells(147).Text <> Nothing And gv40.Rows(0).Cells(147).Text <> "&nbsp;" Then txtMinutoAviso.Text = gv40.Rows(0).Cells(147).Text

                If Val(gv40.Rows(0).Cells(148).Text) = 1 Then cbl_CfrExplicacion_1.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(149).Text) = 1 Then cbl_CfrExplicacion_1.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(150).Text) = 1 Then cbl_CfrExplicacion_1.Items(2).Selected = True
                If Val(gv40.Rows(0).Cells(151).Text) = 1 Then cbl_CfrExplicacion_1.Items(3).Selected = True

                If Val(gv40.Rows(0).Cells(152).Text) = 1 Then cbl_CfrExplicacion_2.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(153).Text) = 1 Then cbl_CfrExplicacion_2.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(154).Text) = 1 Then cbl_CfrExplicacion_2.Items(2).Selected = True
                If Val(gv40.Rows(0).Cells(155).Text) = 1 Then cbl_CfrExplicacion_2.Items(3).Selected = True



                If gv40.Rows(0).Cells(156).Text <> "" And gv40.Rows(0).Cells(156).Text <> Nothing And gv40.Rows(0).Cells(156).Text <> "&nbsp;" Then txtCfrFechaEntrega.Text = gv40.Rows(0).Cells(156).Text
                If gv40.Rows(0).Cells(157).Text <> "" And gv40.Rows(0).Cells(157).Text <> Nothing And gv40.Rows(0).Cells(157).Text <> "&nbsp;" Then txtCfrHoraEntrega.Text = gv40.Rows(0).Cells(157).Text
                If gv40.Rows(0).Cells(158).Text <> "" And gv40.Rows(0).Cells(158).Text <> Nothing And gv40.Rows(0).Cells(158).Text <> "&nbsp;" Then txtCfrMinutoEntrega.Text = gv40.Rows(0).Cells(158).Text


                If Val(gv40.Rows(0).Cells(159).Text) = 1 Then rbl_Cfr_Cliente.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(160).Text) = 1 Then rbl_Cfr_Cliente.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(161).Text) = 1 Then rbl_Cfr_Cliente.Items(2).Selected = True


                If gv40.Rows(0).Cells(162).Text <> "" And gv40.Rows(0).Cells(162).Text <> Nothing And gv40.Rows(0).Cells(162).Text <> "&nbsp;" Then txtCfrClienteOtro.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(162).Text))
                If gv40.Rows(0).Cells(163).Text <> "" And gv40.Rows(0).Cells(163).Text <> Nothing And gv40.Rows(0).Cells(163).Text <> "&nbsp;" Then txtCfrConfirmadoPor.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(163).Text))
                If gv40.Rows(0).Cells(164).Text <> "" And gv40.Rows(0).Cells(164).Text <> Nothing And gv40.Rows(0).Cells(164).Text <> "&nbsp;" Then txtCfrNombre1.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(164).Text))
                If gv40.Rows(0).Cells(165).Text <> "" And gv40.Rows(0).Cells(165).Text <> Nothing And gv40.Rows(0).Cells(165).Text <> "&nbsp;" Then txtCfrNombre2.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(165).Text))
                If gv40.Rows(0).Cells(166).Text <> "" And gv40.Rows(0).Cells(166).Text <> Nothing And gv40.Rows(0).Cells(166).Text <> "&nbsp;" Then txtCfrNombre3.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(166).Text))
                If gv40.Rows(0).Cells(167).Text <> "" And gv40.Rows(0).Cells(167).Text <> Nothing And gv40.Rows(0).Cells(167).Text <> "&nbsp;" Then txtCfrNombre4.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(167).Text))
                If gv40.Rows(0).Cells(168).Text <> "" And gv40.Rows(0).Cells(168).Text <> Nothing And gv40.Rows(0).Cells(168).Text <> "&nbsp;" Then txtPlanFechaPSFU.Text = gv40.Rows(0).Cells(168).Text
                If gv40.Rows(0).Cells(169).Text <> "" And gv40.Rows(0).Cells(169).Text <> Nothing And gv40.Rows(0).Cells(169).Text <> "&nbsp;" Then txtPlanHoraPSFU.Text = gv40.Rows(0).Cells(169).Text
                If gv40.Rows(0).Cells(170).Text <> "" And gv40.Rows(0).Cells(170).Text <> Nothing And gv40.Rows(0).Cells(170).Text <> "&nbsp;" Then txtPlanMinutoPSFU.Text = gv40.Rows(0).Cells(170).Text


                If Val(gv40.Rows(0).Cells(171).Text) = 1 Then cbl_InfContacto.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(172).Text) = 1 Then cbl_InfContacto.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(173).Text) = 1 Then cbl_InfContacto.Items(2).Selected = True

                If Val(gv40.Rows(0).Cells(174).Text) = 1 Then rbl_Info_2.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(175).Text) = 1 Then rbl_Info_2.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(176).Text) = 1 Then rbl_Info_2.Items(0).Selected = True


                If gv40.Rows(0).Cells(177).Text <> "" And gv40.Rows(0).Cells(177).Text <> Nothing And gv40.Rows(0).Cells(177).Text <> "&nbsp;" Then txtTelefono_2.Text = gv40.Rows(0).Cells(177).Text
                If gv40.Rows(0).Cells(178).Text <> "" And gv40.Rows(0).Cells(178).Text <> Nothing And gv40.Rows(0).Cells(178).Text <> "&nbsp;" Then txtEmail_2.Text = gv40.Rows(0).Cells(178).Text
                If gv40.Rows(0).Cells(179).Text <> "" And gv40.Rows(0).Cells(179).Text <> Nothing And gv40.Rows(0).Cells(179).Text <> "&nbsp;" Then txtOtro_2.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(179).Text))
                If gv40.Rows(0).Cells(180).Text <> "" And gv40.Rows(0).Cells(180).Text <> Nothing And gv40.Rows(0).Cells(180).Text <> "&nbsp;" Then txtRealFechaPSFU.Text = gv40.Rows(0).Cells(180).Text
                If gv40.Rows(0).Cells(181).Text <> "" And gv40.Rows(0).Cells(181).Text <> Nothing And gv40.Rows(0).Cells(181).Text <> "&nbsp;" Then txtRealHoraPSFU.Text = gv40.Rows(0).Cells(181).Text
                If gv40.Rows(0).Cells(182).Text <> "" And gv40.Rows(0).Cells(182).Text <> Nothing And gv40.Rows(0).Cells(182).Text <> "&nbsp;" Then txtRealMinutoPSFU.Text = gv40.Rows(0).Cells(182).Text

                If Val(gv40.Rows(0).Cells(183).Text) = 1 Then rbl_PSFU_Cliente.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(184).Text) = 1 Then rbl_PSFU_Cliente.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(185).Text) = 1 Then rbl_PSFU_Cliente.Items(2).Selected = True

                If gv40.Rows(0).Cells(186).Text <> "" And gv40.Rows(0).Cells(186).Text <> Nothing And gv40.Rows(0).Cells(186).Text <> "&nbsp;" Then txtPSFUClienteOtro.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(186).Text))

                If Val(gv40.Rows(0).Cells(187).Text) = 1 Then cbl_PSFUcontacto.Items(0).Selected = True
                If Val(gv40.Rows(0).Cells(188).Text) = 1 Then cbl_PSFUcontacto.Items(1).Selected = True
                If Val(gv40.Rows(0).Cells(189).Text) = 1 Then cbl_PSFUcontacto.Items(2).Selected = True


                If gv40.Rows(0).Cells(190).Text <> "" And gv40.Rows(0).Cells(190).Text <> Nothing And gv40.Rows(0).Cells(190).Text <> "&nbsp;" Then txtFechaLLamar.Text = gv40.Rows(0).Cells(190).Text
                If gv40.Rows(0).Cells(191).Text <> "" And gv40.Rows(0).Cells(191).Text <> Nothing And gv40.Rows(0).Cells(191).Text <> "&nbsp;" Then txtHoraLLamar.Text = gv40.Rows(0).Cells(191).Text
                If gv40.Rows(0).Cells(192).Text <> "" And gv40.Rows(0).Cells(192).Text <> Nothing And gv40.Rows(0).Cells(192).Text <> "&nbsp;" Then txtMinutoLLamar.Text = gv40.Rows(0).Cells(192).Text
                If gv40.Rows(0).Cells(193).Text <> "" And gv40.Rows(0).Cells(193).Text <> Nothing And gv40.Rows(0).Cells(193).Text <> "&nbsp;" Then txtFechaRepetir.Text = gv40.Rows(0).Cells(193).Text
                If gv40.Rows(0).Cells(194).Text <> "" And gv40.Rows(0).Cells(194).Text <> Nothing And gv40.Rows(0).Cells(194).Text <> "&nbsp;" Then txtHoraRepetir.Text = gv40.Rows(0).Cells(194).Text
                If gv40.Rows(0).Cells(195).Text <> "" And gv40.Rows(0).Cells(195).Text <> Nothing And gv40.Rows(0).Cells(195).Text <> "&nbsp;" Then txtMinutoRepetir.Text = gv40.Rows(0).Cells(195).Text
                If gv40.Rows(0).Cells(196).Text <> "" And gv40.Rows(0).Cells(196).Text <> Nothing And gv40.Rows(0).Cells(196).Text <> "&nbsp;" Then txtPSFUnombre.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(196).Text))
                If gv40.Rows(0).Cells(197).Text <> "" And gv40.Rows(0).Cells(197).Text <> Nothing And gv40.Rows(0).Cells(197).Text <> "&nbsp;" Then txtPSFUconfirma.Text = checarCaracterEspañol(Trim(gv40.Rows(0).Cells(197).Text))

                If Val(gv40.Rows(0).Cells(198).Text) = 1 Then cbl_EntregaAsesor.Items(0).Selected = True

            Else

                sSelCmd = "SELECT id, fecha, Cliente, Vehiculo, noPlacas, horaEntrega, noOrden, idAsesor, Vehiculo, telefonos, c.USUARIO, idCliente, vin" _
                        & " tipoCliente, FECHA_ENTREGA, idCitaAnterior, Kilometraje, ContactoNombre, ContactoTelefono, hora1, minuto1, hora2, minuto2, " _
                        & " clienteTrae, concesionaroRecoge, vehiculoPropietario, vehiculoFamiliar, vehiculoOtro, vehiculoOtroTexto, u.nombre" _
                        & "  FROM Tb_CITAS c" _
                        & "  left outer JOIN sccUsuarios u" _
                        & "  ON c.idAsesor = u.cveAsesor and   isnull(u.cveAsesor,'')<>'' " _
                        & " WHERE noOrden = " & "'" & Session("OS") & "'" _
                        & " ORDER BY horaEntrega DESC"

                SqlDataSource_36.SelectCommand = sSelCmd

                gv_36.DataSource = SqlDataSource_36
                gv_36.DataBind()

                If gv_36.Rows.Count > 0 Then

                    'txtTipoTrabajo.Text = gv_36.Rows(0).Cells(13).Text

                    txtHeadFecha.Text = Left(gv_36.Rows(0).Cells(1).Text, 10)
                    txtCliente.Text = checarCaracterEspañol(Trim(gv_36.Rows(0).Cells(2).Text))
                    txtNombreModelo.Text = gv_36.Rows(0).Cells(3).Text
                    txtPlacas.Text = gv_36.Rows(0).Cells(4).Text
                    txtFechaTermino.Text = Left(gv_36.Rows(0).Cells(1).Text, 10)

                    txtHoraTermino.Text = Val(Left(gv_36.Rows(0).Cells(5).Text, 2))
                    txtMinutoTermino.Text = Val(Right(gv_36.Rows(0).Cells(5).Text, 2))

                    txtFechaEntrega.Text = Left(gv_36.Rows(0).Cells(1).Text, 10)
                    'txtFechaEntrega.Text = gv_36.Rows(0).Cells(14).Text

                    Dim iHora As Integer
                    Dim iMinuto As Integer

                    iHora = Val(txtHoraTermino.Text)
                    iMinuto = Val(txtMinutoTermino.Text)

                    If iMinuto + 15 >= 60 Then
                        iHora = iHora + 1
                        iMinuto = (iMinuto + 15) - 60
                    Else
                        iMinuto = iMinuto + 15
                    End If


                    txtHoraEntrega.Text = iHora
                    txtMinutoEntrega.Text = iMinuto

                    txtNoOrden.Text = gv_36.Rows(0).Cells(6).Text

                    'txtAsesor.Text = gv_36.Rows(0).Cells(7).Text
                    txtAsesor.Text = checarCaracterEspañol(Trim(gv_36.Rows(0).Cells(28).Text))

                    txtModelo.Text = gv_36.Rows(0).Cells(3).Text
                    txtSerie.Text = ""
                    txtMotor.Text = ""
                    If gv_36.Rows(0).Cells(18).Text <> "&nbsp;" And gv_36.Rows(0).Cells(18).Text <> "" And gv_36.Rows(0).Cells(18).Text <> "0" Then txtTelefono_1.Text = gv_36.Rows(0).Cells(18).Text
                    If gv_36.Rows(0).Cells(18).Text <> "&nbsp;" And gv_36.Rows(0).Cells(18).Text <> "" And gv_36.Rows(0).Cells(18).Text <> "0" Then txtTelefono_2.Text = gv_36.Rows(0).Cells(18).Text




                End If
            End If

        Catch eexc As Exception
            Session("lblError") = eexc.Message

            Alert(Me.Page, Session("lblError"))
        End Try

    End Sub

    Protected Function formatoFechas() As Boolean
        Try
            Dim bReturn As Boolean

            bReturn = True


            If txtHeadFecha.Text <> "" And txtHeadFecha.Text <> Nothing Then
                If Not IsDate(txtHeadFecha.Text) Then
                    Alert(Me.Page, "¡Fecha instrucción de trabajo incorrecta!")

                    bReturn = False
                    Exit Function
                End If
            End If
            If txtFechaConta.Text <> "" And txtFechaConta.Text <> Nothing Then
                If Not IsDate(txtFechaConta.Text) Then
                    Alert(Me.Page, "¡Fecha contacto incorrecta!")

                    bReturn = False
                    Exit Function
                End If
            End If
            If txtFechaAviso.Text <> "" And txtFechaAviso.Text <> Nothing Then
                If Not IsDate(txtFechaAviso.Text) Then
                    Alert(Me.Page, "¡Fecha aviso incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtPlanFechaPSFU.Text <> "" And txtPlanFechaPSFU.Text <> Nothing Then
                If Not IsDate(txtPlanFechaPSFU.Text) Then
                    Alert(Me.Page, "¡Fecha PSFU planeada incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtRealFechaPSFU.Text <> "" And txtRealFechaPSFU.Text <> Nothing Then
                If Not IsDate(txtRealFechaPSFU.Text) Then
                    Alert(Me.Page, "¡Fecha PSFU real incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtFechaTermino.Text <> "" And txtFechaTermino.Text <> Nothing Then
                If Not IsDate(txtFechaTermino.Text) Then
                    Alert(Me.Page, "¡Fecha termino incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtFechaEntrega.Text <> "" And txtFechaEntrega.Text <> Nothing Then
                If Not IsDate(txtFechaEntrega.Text) Then
                    Alert(Me.Page, "¡Fecha termino incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtCambioFechaTermino.Text <> "" And txtCambioFechaTermino.Text <> Nothing Then
                If Not IsDate(txtCambioFechaTermino.Text) Then
                    Alert(Me.Page, "¡Fecha cambio termino incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If

            If txtFechaIni_1.Text <> "" And txtFechaIni_1.Text <> Nothing Then
                If Not IsDate(txtFechaIni_1.Text) Then
                    Alert(Me.Page, "¡Fecha inicio instrucción 1 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtFechaIni_2.Text <> "" And txtFechaIni_2.Text <> Nothing Then
                If Not IsDate(txtFechaIni_2.Text) Then
                    Alert(Me.Page, "¡Fecha inicio instrucción 2 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtFechaIni_3.Text <> "" And txtFechaIni_3.Text <> Nothing Then
                If Not IsDate(txtFechaIni_3.Text) Then
                    Alert(Me.Page, "¡Fecha inicio instrucción 3 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtFechaIni_4.Text <> "" And txtFechaIni_4.Text <> Nothing Then
                If Not IsDate(txtFechaIni_4.Text) Then
                    Alert(Me.Page, "¡Fecha inicio instrucción 4 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtFechaFin_1.Text <> "" And txtFechaFin_1.Text <> Nothing Then
                If Not IsDate(txtFechaFin_1.Text) Then
                    Alert(Me.Page, "¡Fecha termino instrucción 1 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtFechaFin_2.Text <> "" And txtFechaFin_2.Text <> Nothing Then
                If Not IsDate(txtFechaFin_2.Text) Then
                    Alert(Me.Page, "¡Fecha termino instrucción 2 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtFechaFin_3.Text <> "" And txtFechaFin_3.Text <> Nothing Then
                If Not IsDate(txtFechaFin_3.Text) Then
                    Alert(Me.Page, "¡Fecha termino instrucción 3 incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtFechaFin_4.Text <> "" And txtFechaFin_4.Text <> Nothing Then
                If Not IsDate(txtFechaFin_4.Text) Then
                    Alert(Me.Page, "¡Fecha termino instrucción 4 incorrecta!")

                    bReturn = False
                    Exit Function
                End If
            End If


            If txtCfrFechaEntrega.Text <> "" And txtCfrFechaEntrega.Text <> Nothing Then
                If Not IsDate(txtCfrFechaEntrega.Text) Then
                    Alert(Me.Page, "¡Fecha confirmación entrega incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtPlanFechaPSFU.Text <> "" And txtPlanFechaPSFU.Text <> Nothing Then
                If Not IsDate(txtPlanFechaPSFU.Text) Then
                    Alert(Me.Page, "¡Fecha PSFU planeada incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If
            If txtRealFechaPSFU.Text <> "" And txtRealFechaPSFU.Text <> Nothing Then
                If Not IsDate(txtRealFechaPSFU.Text) Then
                    Alert(Me.Page, "¡Fecha PSFU Real incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If


            If txtFechaLLamar.Text <> "" And txtFechaLLamar.Text <> Nothing Then
                If Not IsDate(txtFechaLLamar.Text) Then
                    Alert(Me.Page, "¡Fecha proxima llamada incorrecta!")
                    bReturn = False
                    Exit Function
                End If
            End If


            If txtFechaRepetir.Text <> "" And txtFechaRepetir.Text <> Nothing Then
                If Not IsDate(txtFechaRepetir.Text) Then
                    Alert(Me.Page, "¡Fecha proxima llamada programada incorrecta!")
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


            Session("TipoTrabajo") = txtTipoTrabajo.Text

            If cbl_LavaCoche.Items(0).Selected Then Session("LavaCoche") = 1 Else Session("LavaCoche") = 0
            If cbl_Refaccion.Items(0).Selected Then Session("Refaccion") = 1 Else Session("Refaccion") = 0

            Session("LLaves") = txtLLaves.Text
            Session("Bahia") = txtBahia.Text
            Session("HeadFecha") = txtHeadFecha.Text
            Session("Cliente") = txtCliente.Text
            Session("NombreModelo") = txtNombreModelo.Text
            Session("Placas") = txtPlacas.Text
            Session("FechaTermino") = txtFechaTermino.Text
            Session("HoraTermino") = txtHoraTermino.Text
            Session("MinutoTermino") = txtMinutoTermino.Text
            Session("FechaEntrega") = txtFechaEntrega.Text
            Session("HoraEntrega") = txtHoraEntrega.Text
            Session("MinutoEntrega") = txtMinutoEntrega.Text
            Session("NoOrden") = txtNoOrden.Text
            Session("NoTrabajo") = txtNoTrabajo.Text
            Session("DOFU") = txtDOFU.Text
            Session("Asesor") = txtAsesor.Text
            Session("Modelo") = txtModelo.Text
            Session("Serie") = txtSerie.Text
            Session("Motor") = txtMotor.Text
            Session("Telefono_1") = txtTelefono_1.Text
            Session("Email_1") = txtEmail_1.Text

            If rbl_Info_1.Items(0).Selected Then Session("Info_1_Casa") = 1 Else Session("Info_1_Casa") = 0
            If rbl_Info_1.Items(1).Selected Then Session("Info_1_Trabajo") = 1 Else Session("Info_1_Trabajo") = 0
            If rbl_Info_1.Items(2).Selected Then Session("Info_1_Celular") = 1 Else Session("Info_1_Celular") = 0


            If rbl_CambioFecha.Items(0).Selected Then Session("Trabajo_Adicional") = 1 Else Session("Trabajo_Adicional") = 0
            If rbl_CambioFecha.Items(1).Selected Then Session("Trabajo_Detencion") = 1 Else Session("Trabajo_Detencion") = 0
            If rbl_CambioFecha.Items(2).Selected Then Session("Trabajo_Otro") = 1 Else Session("Trabajo_Otro") = 0

            Session("txt_Trabajo_Otro") = txtTrabajo_Otro.Text

            Session("Detalle_1") = ""
            Session("NoParte_1") = ""
            Session("Cantidad_1") = 0
            Session("Resulta_1") = ""
            Session("Detalle_2") = ""
            Session("NoParte_2") = ""
            Session("Cantidad_2") = 0
            Session("Resulta_2") = ""
            Session("Detalle_3") = ""
            Session("NoParte_3") = ""
            Session("Cantidad_3") = 0
            Session("Resulta_3") = ""
            Session("Detalle_4") = ""
            Session("NoParte_4") = ""
            Session("Cantidad_4") = 0
            Session("Resulta_4") = ""

            Session("Trabajo_1") = txtTrabajo_1.Text
            Session("Pieza_1") = txtPieza_1.Text
            Session("Amount_1") = txtAmount_1.Text
            Session("Costo_1") = txtCosto_1.Text

            Session("Stock_1") = ddl_Stock_1.SelectedValue

            Session("ETA_11") = txtETA_11.Text
            Session("ETA_12") = txtETA_12.Text
            Session("Trabajo_2") = txtTrabajo_2.Text
            Session("Pieza_2") = txtPieza_2.Text
            Session("Amount_2") = txtAmount_2.Text
            Session("Costo_2") = txtCosto_2.Text

            Session("Stock_2") = ddl_Stock_2.SelectedValue

            Session("ETA_21") = txtETA_21.Text
            Session("ETA_22") = txtETA_22.Text
            Session("Trabajo_3") = txtTrabajo_3.Text
            Session("Pieza_3") = txtPieza_3.Text
            Session("Amount_3") = txtAmount_3.Text
            Session("Costo_3") = txtCosto_3.Text

            Session("Stock_3") = ddl_Stock_3.SelectedValue

            Session("ETA_31") = txtETA_31.Text
            Session("ETA_32") = txtETA_32.Text
            Session("Trabajo_4") = txtTrabajo_4.Text
            Session("Pieza_4") = txtPieza_4.Text
            Session("Amount_4") = txtAmount_4.Text
            Session("Costo_4") = txtCosto_4.Text
            Session("Costo_5") = txtCosto_5.Text

            Session("Stock_4") = ddl_Stock_4.SelectedValue

            Session("ETA_41") = txtETA_41.Text
            Session("ETA_42") = txtETA_42.Text
            Session("FechaConta") = txtFechaConta.Text
            Session("HoraConta") = txtHoraConta.Text
            Session("MinutoConta") = txtMinutoConta.Text
            Session("NombreConta") = txtNombreConta.Text
            Session("CambioFechaTermino") = txtCambioFechaTermino.Text
            Session("CambioHoraTermino") = txtCambioHoraTermino.Text
            Session("CambioMinutoTermino") = txtCambioMinutoTermino.Text
            Session("CambioFechaEntrega") = txtCambioFechaEntrega.Text
            Session("CambioHoraEntrega") = txtCambioHoraEntrega.Text
            Session("CambioMinutoEntrega") = txtCambioMinutoEntrega.Text
            Session("FechaIni_1") = txtFechaIni_1.Text
            Session("HoraIni_1") = txtHoraIni_1.Text
            Session("MinutoIni_1") = txtMinutoIni_1.Text
            Session("FechaFin_1") = txtFechaFin_1.Text
            Session("HoraFin_1") = txtHoraFin_1.Text
            Session("MinutoFin_1") = txtMinutoFin_1.Text
            Session("TimeHoraIni_1") = txtTimeHoraIni_1.Text
            Session("TimeMinutoIni_1") = txtTimeMinutoIni_1.Text
            Session("Tecnico_1") = txtTecnico_1.Text

            If cbl_CC_1.Items(0).Selected Then Session("ControlCalidad_11") = 1 Else Session("ControlCalidad_11") = 0
            If cbl_CC_1.Items(1).Selected Then Session("ControlCalidad_12") = 1 Else Session("ControlCalidad_12") = 0
            If cbl_CC_1.Items(2).Selected Then Session("ControlCalidad_13") = 1 Else Session("ControlCalidad_13") = 0

            Session("Calidad_1") = txtCalidad_1.Text
            Session("FechaIni_2") = txtFechaIni_2.Text
            Session("HoraIni_2") = txtHoraIni_2.Text
            Session("MinutoIni_2") = txtMinutoIni_2.Text
            Session("FechaFin_2") = txtFechaFin_2.Text
            Session("HoraFin_2") = txtHoraFin_2.Text
            Session("MinutoFin_2") = txtMinutoFin_2.Text
            Session("TimeHoraIni_2") = txtTimeHoraIni_2.Text
            Session("TimeMinutoIni_2") = txtTimeMinutoIni_2.Text
            Session("Tecnico_2") = txtTecnico_2.Text

            If cbl_CC_2.Items(0).Selected Then Session("ControlCalidad_21") = 1 Else Session("ControlCalidad_21") = 0
            If cbl_CC_2.Items(1).Selected Then Session("ControlCalidad_22") = 1 Else Session("ControlCalidad_22") = 0
            If cbl_CC_2.Items(2).Selected Then Session("ControlCalidad_23") = 1 Else Session("ControlCalidad_23") = 0

            Session("Calidad_2") = txtCalidad_2.Text
            Session("FechaIni_3") = txtFechaIni_3.Text
            Session("HoraIni_3") = txtHoraIni_3.Text
            Session("MinutoIni_3") = txtMinutoIni_3.Text
            Session("FechaFin_3") = txtFechaFin_3.Text
            Session("HoraFin_3") = txtHoraFin_3.Text
            Session("MinutoFin_3") = txtMinutoFin_3.Text
            Session("TimeHoraIni_3") = txtTimeHoraIni_3.Text
            Session("TimeMinutoIni_3") = txtTimeMinutoIni_3.Text
            Session("Tecnico_3") = txtTecnico_3.Text

            If cbl_CC_3.Items(0).Selected Then Session("ControlCalidad_31") = 1 Else Session("ControlCalidad_31") = 0
            If cbl_CC_3.Items(1).Selected Then Session("ControlCalidad_32") = 1 Else Session("ControlCalidad_32") = 0
            If cbl_CC_3.Items(2).Selected Then Session("ControlCalidad_33") = 1 Else Session("ControlCalidad_33") = 0

            Session("Calidad_3") = txtCalidad_3.Text
            Session("FechaIni_4") = txtFechaIni_4.Text
            Session("HoraIni_4") = txtHoraIni_4.Text
            Session("MinutoIni_4") = txtMinutoIni_4.Text
            Session("FechaFin_4") = txtFechaFin_4.Text
            Session("HoraFin_4") = txtHoraFin_4.Text
            Session("MinutoFin_4") = txtMinutoFin_4.Text
            Session("TimeHoraIni_4") = txtTimeHoraIni_4.Text
            Session("TimeMinutoIni_4") = txtTimeMinutoIni_4.Text
            Session("Tecnico_4") = txtTecnico_4.Text

            If cbl_CC_4.Items(0).Selected Then Session("ControlCalidad_41") = 1 Else Session("ControlCalidad_41") = 0
            If cbl_CC_4.Items(1).Selected Then Session("ControlCalidad_42") = 1 Else Session("ControlCalidad_42") = 0
            If cbl_CC_4.Items(2).Selected Then Session("ControlCalidad_43") = 1 Else Session("ControlCalidad_43") = 0


            Session("Calidad_4") = txtCalidad_4.Text
            Session("Comentario") = txtComentario.Text
            Session("Observacion") = txtObservacion.Text

            If cbl_CfrEntrega.Items(0).Selected Then Session("CfrEntrega_1") = 1 Else Session("CfrEntrega_1") = 0
            If cbl_CfrEntrega.Items(1).Selected Then Session("CfrEntrega_2") = 1 Else Session("CfrEntrega_2") = 0
            If cbl_CfrEntrega.Items(2).Selected Then Session("CfrEntrega_3") = 1 Else Session("CfrEntrega_3") = 0
            If cbl_CfrEntrega.Items(3).Selected Then Session("CfrEntrega_4") = 1 Else Session("CfrEntrega_4") = 0

            Session("FechaAviso") = txtFechaAviso.Text
            Session("HoraAviso") = txtHoraAviso.Text
            Session("MinutoAviso") = txtMinutoAviso.Text

            If cbl_CfrExplicacion_1.Items(0).Selected Then Session("CfrExplicacion_11") = 1 Else Session("CfrExplicacion_11") = 0
            If cbl_CfrExplicacion_1.Items(1).Selected Then Session("CfrExplicacion_12") = 1 Else Session("CfrExplicacion_12") = 0
            If cbl_CfrExplicacion_1.Items(2).Selected Then Session("CfrExplicacion_13") = 1 Else Session("CfrExplicacion_13") = 0
            If cbl_CfrExplicacion_1.Items(3).Selected Then Session("CfrExplicacion_14") = 1 Else Session("CfrExplicacion_14") = 0

            If cbl_CfrExplicacion_2.Items(0).Selected Then Session("CfrExplicacion_21") = 1 Else Session("CfrExplicacion_21") = 0
            If cbl_CfrExplicacion_2.Items(1).Selected Then Session("CfrExplicacion_22") = 1 Else Session("CfrExplicacion_22") = 0
            If cbl_CfrExplicacion_2.Items(2).Selected Then Session("CfrExplicacion_23") = 1 Else Session("CfrExplicacion_23") = 0
            'If cbl_CfrExplicacion_2.Items(3).Selected Then Session("CfrExplicacion_24") = 1 Else Session("CfrExplicacion_24") = 0

            If cbl_EntregaAsesor.Items(0).Selected Then Session("CfrFechaEntrega_1") = 1 Else Session("CfrFechaEntrega_1") = 0

            Session("CfrFechaEntrega") = txtCfrFechaEntrega.Text
            Session("CfrHoraEntrega") = txtCfrHoraEntrega.Text
            Session("CfrMinutoEntrega") = txtCfrMinutoEntrega.Text

            If rbl_Cfr_Cliente.Items(0).Selected Then Session("Cfr_Cliente_1") = 1 Else Session("Cfr_Cliente_1") = 0
            If rbl_Cfr_Cliente.Items(1).Selected Then Session("Cfr_Cliente_2") = 1 Else Session("Cfr_Cliente_2") = 0
            If rbl_Cfr_Cliente.Items(2).Selected Then Session("Cfr_Cliente_3") = 1 Else Session("Cfr_Cliente_3") = 0

            Session("CfrClienteOtro") = txtCfrClienteOtro.Text
            Session("CfrConfirmadoPor") = txtCfrConfirmadoPor.Text
            Session("CfrNombre1") = txtCfrNombre1.Text
            Session("CfrNombre2") = txtCfrNombre2.Text
            Session("CfrNombre3") = txtCfrNombre3.Text
            Session("CfrNombre4") = txtCfrNombre4.Text
            Session("PlanFechaPSFU") = txtPlanFechaPSFU.Text
            Session("PlanHoraPSFU") = txtPlanHoraPSFU.Text
            Session("PlanMinutoPSFU") = txtPlanMinutoPSFU.Text

            If cbl_InfContacto.Items(0).Selected Then Session("InfContacto_1") = 1 Else Session("InfContacto_1") = 0
            If cbl_InfContacto.Items(1).Selected Then Session("InfContacto_2") = 1 Else Session("InfContacto_2") = 0
            If cbl_InfContacto.Items(2).Selected Then Session("InfContacto_3") = 1 Else Session("InfContacto_3") = 0

            If rbl_Info_2.Items(0).Selected Then Session("Info_2_Casa") = 1 Else Session("Info_2_Casa") = 0
            If rbl_Info_2.Items(1).Selected Then Session("Info_2_Trabajo") = 1 Else Session("Info_2_Trabajo") = 0
            If rbl_Info_2.Items(2).Selected Then Session("Info_2_Celular") = 1 Else Session("Info_2_Celular") = 0

            Session("Telefono_2") = txtTelefono_2.Text
            Session("Email_2") = txtEmail_2.Text
            Session("Otro_2") = txtOtro_2.Text
            Session("RealFechaPSFU") = txtRealFechaPSFU.Text
            Session("RealHoraPSFU") = txtRealHoraPSFU.Text
            Session("RealMinutoPSFU") = txtRealMinutoPSFU.Text

            If rbl_PSFU_Cliente.Items(0).Selected Then Session("PSFU_Cliente_1") = 1 Else Session("PSFU_Cliente_1") = 0
            If rbl_PSFU_Cliente.Items(1).Selected Then Session("PSFU_Cliente_2") = 1 Else Session("PSFU_Cliente_2") = 0
            If rbl_PSFU_Cliente.Items(2).Selected Then Session("PSFU_Cliente_3") = 1 Else Session("PSFU_Cliente_3") = 0

            Session("PSFUClienteOtro") = txtPSFUClienteOtro.Text


            If cbl_PSFUcontacto.Items(0).Selected Then Session("PSFUcontacto_1") = 1 Else Session("PSFUcontacto_1") = 0
            If cbl_PSFUcontacto.Items(1).Selected Then Session("PSFUcontacto_2") = 1 Else Session("PSFUcontacto_2") = 0
            If cbl_PSFUcontacto.Items(2).Selected Then Session("PSFUcontacto_3") = 1 Else Session("PSFUcontacto_3") = 0

            Session("FechaLLamar") = txtFechaLLamar.Text
            Session("HoraLLamar") = txtHoraLLamar.Text
            Session("MinutoLLamar") = txtMinutoLLamar.Text

            Session("FechaRepetir") = txtFechaRepetir.Text
            Session("HoraRepetir") = txtHoraRepetir.Text
            Session("MinutoRepetir") = txtMinutoRepetir.Text


            Session("PSFUnombre") = txtPSFUnombre.Text
            Session("PSFUconfirma") = txtPSFUconfirma.Text


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

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        'Create/Update
        Try

            Dim gv40 As New GridView

            If formatoFechas() Then


                asignaVariables()

                Session("idCita") = Session("OS")

                sSelCmd = "SELECT * FROM TYT_KDW_FORMATO_TRABAJO WHERE idCita = " & "'" & Session("idCita") & "'"
                SqlDataSource40.SelectCommand = sSelCmd

                gv40.DataSource = SqlDataSource40
                gv40.DataBind()

                If gv40.Rows.Count = 0 Then SqlDataSource40.Insert() Else SqlDataSource40.Update()

            End If
        Catch eexc As Exception
            Session("lblError") = eexc.Message
        End Try

    End Sub

    Protected Sub cbl_EntregaAsesor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl_EntregaAsesor.SelectedIndexChanged

        Try
            If cbl_EntregaAsesor.Items(0).Selected Then

                txtCfrFechaEntrega.Text = Left(Date.Now.ToString, 10)

                txtCfrHoraEntrega.Text = Date.Now.Hour
                txtCfrMinutoEntrega.Text = Date.Now.Minute
            End If

        Catch eexc As Exception
            Session("lblError") = eexc.Message
        End Try

    End Sub

End Class
