Imports ZedGraph.Web
Imports System.Drawing
Imports TablerosV2LibTypes

Partial Public Class TCita
    Inherits System.Web.UI.Page
    Const iTablero As Integer = 1
    Dim bref As Boolean
    Dim inumHoras As Integer = 0
    Dim inumDias As Integer = 0
    Const inumLeft As Integer = 0
    Dim iHorai As Integer = 0
    Dim ifac As Double = (59.4) * inumHoras

    Property pgvDms() As Boolean
        Get
            Return Session("_pgvdms")
        End Get
        Set(ByVal value As Boolean)
            Session("_pgvdms") = value
        End Set
    End Property

    Private Sub whuxgaPT_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If SiteMap.CurrentNode IsNot Nothing Then
            'Set the next/previous/up links
            If SiteMap.CurrentNode.PreviousSibling IsNot Nothing Then
                lnkPrev.NavigateUrl = SiteMap.CurrentNode.PreviousSibling.Url
                lnkPrev.Text = "&lt; Prev (" & SiteMap.CurrentNode.PreviousSibling.Title & ")"
            Else
                lnkPrev.NavigateUrl = String.Empty
                lnkPrev.Text = "&lt; Prev"
            End If

            If SiteMap.CurrentNode.ParentNode IsNot Nothing Then
                lnkUp.NavigateUrl = SiteMap.CurrentNode.ParentNode.Url
                lnkUp.Text = "Up (" & SiteMap.CurrentNode.ParentNode.Title & ")"
            Else
                lnkUp.NavigateUrl = String.Empty
                lnkUp.Text = "Up"
            End If

            If SiteMap.CurrentNode.NextSibling IsNot Nothing Then
                lnkNext.NavigateUrl = SiteMap.CurrentNode.NextSibling.Url
                lnkNext.Text = "(" & SiteMap.CurrentNode.NextSibling.Title & ") Next &gt;"
            Else
                lnkNext.NavigateUrl = String.Empty
                lnkNext.Text = "Next &gt;"
            End If
        End If
        If Not Page.IsPostBack Then
            txtCalendar.Text = Date.Now.ToShortDateString
            lblCalendar.Text = txtCalendar.Text
            'refreshDMS()
            lblUsr.Text = Session("Usuario")
        End If

        inumHoras = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumhoras")
        inumDias = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumdias")
        iHorai = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "ihorai")
        ifac = (59.4) * inumHoras



    End Sub

    Sub LlenaAsesores()
        Dim dt As New DataTable
        Dim sqry As String = ""


        sqry = "Select nombre,color from SccUsuarios  WHERE cveasesor<>'' and not cveAsesor is null "
        dt = BDClass.SQLtoDataTable(sqry, False)

        DataList1.DataSource = dt

        DataList1.DataBind()

    End Sub


    Protected Sub DataList1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataList1.PreRender
        Dim converter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color))
        Dim color As System.Drawing.Color
        For i = 0 To DataList1.Items.Count - 1
            Try
                'color = color.FromArgb(255, 255 - (CType(converter.ConvertFromString(CType(DataList2.Items(i).Controls(1), Label).Text), System.Drawing.Color).R), 255 - (CType(converter.ConvertFromString(CType(DataList2.Items(i).Controls(1), Label).Text), System.Drawing.Color).G), 255 - (CType(converter.ConvertFromString(CType(DataList2.Items(i).Controls(1), Label).Text), System.Drawing.Color).B))

                CType(DataList1.Items(i).Controls(3), LinkButton).Style.Value = "background-color:" & CType(DataList1.Items(i).Controls(1), Label).Text & ";color:" & System.Drawing.ColorTranslator.ToHtml(color) & ";"
                CType(DataList1.Items(i).Controls(3), LinkButton).ForeColor = color.Black
            Catch ex As Exception

            End Try
        Next
    End Sub
    Private Sub AbrirChip(ByVal iId As Int64, ByVal ssTop As String, ByVal ssLeft As String)
        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        dchp.Style.Remove("Left")
        dchp.Style.Remove("Top")
        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then

                Modelo.Text = "Mod: " & obj.VEHICULO
                Tolerancia.Text = "H.Tol: " & obj.HORATOLERANCIA
                Service.Text = "" & obj.SERVICIOCAPTURADO
                Orden.Text = "Cita " & obj.NUMCITA
                Placas.Text = "Placa: " & obj.NOPLACAS
                dchp.Style.Add("Left", ssLeft)
                dchp.Style.Add("Top", ssTop)

                dchp.Focus()
                Exit For
            End If

        Next

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If InStr(Page.AppRelativeVirtualPath, Session("URL")) = 0 Or Session("URL") Is Nothing Then Response.Redirect("Login.aspx")
        ' LlenaAsesores()
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Not Page.IsPostBack Then
            bref = True
        End If
        If Session("fase") Is Nothing Then
            Session("fase") = 0
        End If

        'iniciaTablero(True, txtBuscar.Text)
        If Not Page.IsPostBack Then
            iniciaTablero(True, txtBuscar.Text)

        ElseIf Not Session("clkMenu") Is Nothing Then
            '   menuItem(Session("clkMenuid"), True)
        Else
            ' iniciaTablero(True, txtBuscar.Text)
        End If

        If sdhtml = "dchp" Then
            dchp.Visible = False
        ElseIf Left(sdhtml, 3) = "div" Then
            dchp.Visible = False
        ElseIf Left(sdhtml, 4) = "ds00." Then
            dchp.Visible = False
        ElseIf Left(sdhtml, 4) = "add_" Then
            dchp.Visible = False
            'Revision25(Split(sdhtml, "_")(1))
        ElseIf Left(sdhtml, 6) = "txtMec" Then
            dchp.Visible = False
        ElseIf sdhtml.Split(".").Length = 0 And sdhtml.Length > 0 Then
            AbrirChip(CType(Me.FindControl(sdhtml).Controls(1), HtmlInputHidden).Value, CType(Me.FindControl(sdhtml), HtmlGenericControl).Style.Item("top"), CType(Me.FindControl(sdhtml), HtmlGenericControl).Style.Item("left"))
            dchp.Visible = True
        Else
            dchp.Visible = False
        End If

    End Sub
    Sub iniciaTablero2()
        Dim dt As New DataTable
        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "CitasVista").ToString = "1" Then
            dt = TablerosUtilsHyP.ObtenTecnicosMasVehiculosChipsView
        Else
            dt = TablerosUtilsHyP.ObtenTecnicosMasVehiculos
        End If


        Dim dt0 As DataView = TablerosUtilsHyP.ObtenTecnicos.DefaultView

        Dim dvTecnicos As DataView

        Dim dtAusencias As DataView
        Dim dtHlpHorarios As New DataTable
        dtHlpHorarios.Columns.Add("idTecnico")
        dtHlpHorarios.Columns.Add("NombreTecnico")
        dtHlpHorarios.Columns.Add("Bahia")
        dtHlpHorarios.Columns.Add("HoraEnt")
        dtHlpHorarios.Columns.Add("HoraSal")
        dtHlpHorarios.Columns.Add("HoraComer")
        dtHlpHorarios.Columns.Add("Comida")
        dtHlpHorarios.Columns.Add("PosY")
        dtHlpHorarios.Columns.Add("PosX")
        dtHlpHorarios.Columns.Add("dia")

        Dim txtMec As Label
        Dim txtHorario As Label, sPosX1 As Integer = 0, sPosX2 As Integer = 0
        '    leftfix.Controls.Clear()
        Dim dtPos As New DataTable, ktop As Integer
        dtPos.Columns.Add("IdTecnico")
        dtPos.Columns.Add("IdControl")
        dtPos.Columns.Add("posY")
        dtPos.Columns.Add("IdControlP")
        dtPos.Columns.Add("OrdenP")
        dtPos.Columns.Add("posYP")

        'dtPos.Columns.Add("posb")

        ktop = 0


        Dim ITOT As Decimal
        Dim converter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color))
        Dim color As System.Drawing.Color, sColor As String





        For i = 0 To dt0.Count - 1
            ITOT = 0
            txtMec = New Label
            txtMec.ID = "txtMec" & dt0(i)("Bahia") & i
            sColor = dt0(i)("color")
            'color = color.FromArgb(255, 255 - (CType(converter.ConvertFromString(sColor), System.Drawing.Color).R), 255 - (CType(converter.ConvertFromString(sColor), System.Drawing.Color).G), 255 - (CType(converter.ConvertFromString(sColor), System.Drawing.Color).B))

            txtMec.Style.Value = "position:absolute;left:1px;top:" & ktop + 2 & "px;width:85px;height:26px;background-color:" & dt0(i)("color") & ";color:" & System.Drawing.ColorTranslator.ToHtml(color) & ";Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:0.688em;border:solid 1px black;"
            txtMec.Text = dt0(i)("nombre_empleado")

            '--------------Horario Comida
            For j = 0 To inumDias - 1


                '---------Ausencias-----------
                'idia = TablerosUtils.ObtenPosYTecnicosCC(dt.Rows(i)("Bahia"))(0).Item(0)
                dtAusencias = TablerosUtilsHyP.ObtenAusenciasA1(dt0(i)("id_empleado"), CDate(lblCalendar.Text).AddDays(j))
                If dtAusencias.Count > 0 Then
                    For iai = 0 To dtAusencias.Count - 1
                        txtHorario = New Label
                        txtHorario.ID = "txtAusencia" & dt0(i)("Bahia") & i & "_" & j & "_" & iai
                        If IsDate(dtAusencias(iai).Item(1)) Then
                            sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dtAusencias(iai).Item(1)).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dtAusencias(iai).Item(1)).Hour * 60) - (iHorai * 60)) + CDate(dtAusencias(iai).Item(1)).Minute) * ((ifac / inumHoras) / 60)), 0) + 92
                            sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dtAusencias(iai).Item(2)).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dtAusencias(iai).Item(2)).Hour * 60) - (iHorai * 60)) + CDate(dtAusencias(iai).Item(2)).Minute) * ((ifac / inumHoras) / 60)), 0) + 92
                            ' sPosX2 = TablerosUtilsHyP.ObtenPosXxHora(dtAusencias(II).Item(2))
                            ' sPosX1 = TablerosUtilsHyP.ObtenPosXxHora(dtAusencias(II).Item(1))

                            If InStr(dtAusencias(iai).Item("tausencia"), "%") > 0 Then
                                If iTablero <> 1 Then
                                    txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:48px;background-color:orange;Font-weight:normal;font-family:Arial;font-size:10px;border:solid 1px black;text-align: center;vertical-align: middle;color:black;"
                                Else
                                    txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:24px;background-color:orange;Font-weight:normal;font-family:Arial;font-size:10px;border:solid 1px black;text-align: center;vertical-align: middle;color:black;"
                                End If
                            Else
                                If iTablero <> 1 Then
                                    txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:48px;background-color:Gray;Font-weight:normal;font-family:Arial;font-size:10px;border:solid 1px black;text-align: center;vertical-align: middle;color:white;"
                                Else
                                    txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:24px;background-color:Gray;Font-weight:normal;font-family:Arial;font-size:10px;border:solid 1px black;text-align: center;vertical-align: middle;color:white;"
                                End If
                            End If

                            txtHorario.Text = dtAusencias(iai).Item("tausencia")
                            Try
                                form1.Controls.Add(txtHorario)
                            Catch ex As Exception
                                LimpiaForm()
                                form1.Controls.Add(txtHorario)
                            End Try
                        End If
                    Next
                End If

                '---------Ausencias-----------


                If CDate(lblCalendar.Text).AddDays(j).DayOfWeek <> DayOfWeek.Saturday Then


                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioC" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("hora_comer")) And dt0(i)("min_comer_lv") <> "0" Then
                        sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("hora_comer")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("hora_comer")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("hora_comer")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92
                        sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("hora_comer")).AddMinutes(dt0(i)("min_comer_lv")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("hora_comer")).AddMinutes(dt0(i)("min_comer_lv")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("hora_comer")).AddMinutes(dt0(i)("min_comer_lv")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92



                        'sPosX2 = TablerosUtils.ObtenPosXxHora(String.Format("{0:HH:mm}", CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s"))))
                        'sPosX1 = TablerosUtils.ObtenPosXxHora(dt0(i)("hora_comer"))
                        If iTablero <> 1 Then
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:54px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dc")
                        Else
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:27px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dc")
                        End If
                        txtHorario.Text = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dc")
                        Try
                            form1.Controls.Add(txtHorario)
                        Catch ex As Exception
                            LimpiaForm()
                            form1.Controls.Add(txtHorario)
                        End Try
                    End If
                    '----------------------


                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioSALLV" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("HORA_SAL_LV")) Then
                        sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_SAL_LV")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("HORA_SAL_LV")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("HORA_SAL_LV")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92

                        sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + ((inumHoras) * 60 * ((ifac / inumHoras) / 60)) + 92
                        dtHlpHorarios.Rows.Add(New Object() {dt0(i)("id_empleado"), dt0(i)("nombre_empleado"), dt0(i)("Bahia"), dt0(i)("hora_ent_lv"), dt0(i)("hora_sal_lv"), dt0(i)("hora_comer"), dt0(i)("min_comer_lv"), ktop + 94 & "px", sPosX1 + (j * (ifac)) & "px", CInt(CDate(lblCalendar.Text).AddDays(j).DayOfWeek)})

                        'sPosX2 = TablerosUtils.ObtenPosXxHora(String.Format("{0:HH:mm}", CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s"))))
                        'sPosX1 = TablerosUtils.ObtenPosXxHora(dt0(i)("hora_comer"))
                        If iTablero <> 1 Then
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:54px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Else
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:27px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        End If
                        txtHorario.Text = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Try
                            form1.Controls.Add(txtHorario)
                        Catch ex As Exception
                            LimpiaForm()
                            form1.Controls.Add(txtHorario)
                        End Try
                    End If
                    '----------------------
                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioLV" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("HORA_ENT_LV")) Then
                        sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + 92
                        sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_ENT_LV")).Hour * 60) + CDate(dt0(i)("HORA_ENT_LV")).Minute - (iHorai * 60)) > 0, ((CDate(dt0(i)("HORA_ENT_LV")).Hour * 60) + CDate(dt0(i)("HORA_ENT_LV")).Minute - (iHorai * 60)), 0) + 92

                        'sPosX2 = TablerosUtils.ObtenPosXxHora(String.Format("{0:HH:mm}", CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s"))))
                        'sPosX1 = TablerosUtils.ObtenPosXxHora(dt0(i)("hora_comer"))
                        If iTablero <> 1 Then
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:54px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Else
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:27px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        End If
                        txtHorario.Text = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Try
                            form1.Controls.Add(txtHorario)
                        Catch ex As Exception
                            LimpiaForm()
                            form1.Controls.Add(txtHorario)
                        End Try
                    End If
                    '----------------------
                Else
                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioCSa" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("hora_comer_s")) And dt0(i)("min_comer_s") <> "0" Then
                        sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("hora_comer_s")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("hora_comer_s")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("hora_comer_s")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92
                        sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92

                        'sPosX2 = TablerosUtils.ObtenPosXxHora(String.Format("{0:HH:mm}", CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s"))))
                        'sPosX1 = TablerosUtils.ObtenPosXxHora(dt0(i)("hora_comer"))
                        If iTablero <> 1 Then
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:54px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dc")
                        Else
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:27px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dc")
                        End If
                        txtHorario.Text = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dc")
                        Try
                            form1.Controls.Add(txtHorario)
                        Catch ex As Exception
                            LimpiaForm()
                            form1.Controls.Add(txtHorario)
                        End Try
                    End If
                    '----------------------


                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioSALSa" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("HORA_SAL_S")) Then
                        sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_SAL_S")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("HORA_SAL_S")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("HORA_SAL_S")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92

                        sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + ((inumHoras) * 60 * ((ifac / inumHoras) / 60)) + 92
                        dtHlpHorarios.Rows.Add(New Object() {dt0(i)("id_empleado"), dt0(i)("nombre_empleado"), dt0(i)("Bahia"), dt0(i)("hora_ent_s"), dt0(i)("hora_sal_s"), dt0(i)("hora_comer_s"), dt0(i)("min_comer_s"), ktop + 94 & "px", sPosX1 + (j * (ifac)) & "px", CInt(CDate(lblCalendar.Text).AddDays(j).DayOfWeek)})

                        'sPosX2 = TablerosUtils.ObtenPosXxHora(String.Format("{0:HH:mm}", CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s"))))
                        'sPosX1 = TablerosUtils.ObtenPosXxHora(dt0(i)("hora_comer"))
                        If iTablero <> 1 Then
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:54px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Else
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:27px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        End If
                        txtHorario.Text = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Try
                            form1.Controls.Add(txtHorario)
                        Catch ex As Exception
                            LimpiaForm()
                            form1.Controls.Add(txtHorario)
                        End Try
                    End If
                    '----------------------
                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioENTSa" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("HORA_ENT_S")) Then
                        sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + 92
                        sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_ENT_S")).Hour * 60) + CDate(dt0(i)("HORA_ENT_S")).Minute - (iHorai * 60)) > 0, ((CDate(dt0(i)("HORA_ENT_S")).Hour * 60) + CDate(dt0(i)("HORA_ENT_S")).Minute - (iHorai * 60)), 0) + 92

                        'sPosX2 = TablerosUtils.ObtenPosXxHora(String.Format("{0:HH:mm}", CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s"))))
                        'sPosX1 = TablerosUtils.ObtenPosXxHora(dt0(i)("hora_comer"))
                        If iTablero <> 1 Then
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:54px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Else
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:27px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        End If
                        txtHorario.Text = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Try
                            form1.Controls.Add(txtHorario)
                        Catch ex As Exception
                            LimpiaForm()
                            form1.Controls.Add(txtHorario)
                        End Try
                    End If
                End If


            Next
            ' dtPos.Rows.Add(New Object() {dt0(i)("id_empleado"), txtMec.ID, ktop + 2, txtNiv.ID, dvTecnicos(k)("noorden"), ktop + 94})

            dt.DefaultView.RowFilter = "Bahia='" & dt0(i)("Bahia") & "' "
            dvTecnicos = dt.DefaultView
            'dtPos.Rows.Add(New Object() {dt0(i)("id_empleado"), txtMec.ID, ktop + 2, txtNiv.ID, dvTecnicos(0)("noorden"), ktop + 94})

            For k = 0 To dvTecnicos.Count - 1

                'txtNiv = New Label
                'txtNiv.ID = "txtNiv" & dt0(i)("Bahia") & "_" & i & "_" & dvTecnicos(k)("noorden")
                'txtNiv.Style.Value = "position:absolute;left:31px;top:" & ktop + 2 & "px;width:55px;height:26px;background-color:#eeeee0;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:10px;border:solid 1px black;"
                'txtNiv.Text = dvTecnicos(k)("noplacas")
                'leftfix.Controls.Add(txtNiv)
                dtPos.Rows.Add(New Object() {dt0(i)("id_empleado"), txtMec.ID, ktop + 2, txtMec.ID, dvTecnicos(k)("id"), ktop + 94})
                ITOT = ITOT + Val(dvTecnicos(k)("servicio"))
                '--para indicadores

                'ktop = ktop + 27


            Next
            Session("dthlphorarios") = dtHlpHorarios
            ITOT = System.Math.Round(ITOT / 60, 1)
            txtMec.ToolTip = "Total Servicios: " & ITOT & " horas"

            leftfix.Controls.Add(txtMec)


            ktop = ktop + 30

        Next

        Session("dtPosY") = dtPos


        Session.Remove("ObtenAusencias")
    End Sub
    Sub LlenaComboCitas(s As String)
        Dim OBJCOLO As New CHIPHYPCollection
        OBJCOLO = OBJCOLO.ObtenChipsAllCitasCita()
        cboOrdenes.Items.Clear()
        For Each objD As ChipHYP In OBJCOLO
            If cboOrdenes.Items.IndexOf(cboOrdenes.Items.FindByText(objD.NUMCITA)) < 0 Then
                cboOrdenes.Items.Add(New ListItem(objD.NUMCITA))
            End If
        Next
        Try
            cboOrdenes.SelectedIndex = cboOrdenes.Items.IndexOf(cboOrdenes.Items.FindByText(s))
        Catch ex As Exception
            cboOrdenes.SelectedIndex = 0
        End Try
    End Sub
    Sub iniciaTablero(ByVal bTecnicos As Boolean, Optional sVehiculo As String = "", Optional bDetenidos As Boolean = False)
        LimpiaForm()
        Dim dtTemp As DataTable

        'If bref = False Then Exit Sub
        bref = False
        Dim sScript As String = ""
        Dim iNumbahias As Integer ' = dt.Rows.Count
        Dim ilargo As Integer = 0
        Dim iwidth As Integer = "7500"
        Dim dt As DataView = TablerosUtilsHyP.ObtenTecnicos.DefaultView
        Dim OBJCOL As New CHIPHYPCollection, objchip As ChipHYP

        Dim iNivel As Integer = 0
        Dim txtMec As Label
        Dim imgLstInfo As New ArrayList()
        Session("imgLstInfo") = imgLstInfo

        If bDetenidos Or Not Session("rbDet") Is Nothing Then
        Else
            If sVehiculo <> "" Then
                OBJCOL = OBJCOL.ObtenChipsAllCitas(sVehiculo, rdlBuscar.SelectedIndex)



            Else
                OBJCOL = OBJCOL.ObtenChipsAllCitas("", 0)
            End If
            If Not Page.IsPostBack Then
                LlenaComboCitas("")
            ElseIf txtBuscar.Text.Trim <> "" Then
                LlenaComboCitas(txtBuscar.Text.Trim)
            ElseIf cboOrdenes.SelectedIndex > -1 Then
                LlenaComboCitas(cboOrdenes.Items(cboOrdenes.SelectedIndex).Text)
            End If
        End If




        iNumbahias = dt.Count
        Session("ColChips") = OBJCOL


        'iwidth = 75.5 * (Date.DaysInMonth(Now.Year, Now.Month) + Date.DaysInMonth(Now.AddMonths(1).Year, Now.AddMonths(1).Month))
        ' iwidth = (475.5 * (3 - CDATES.iDomingos)) 'sundays
        iwidth = ifac * (inumDias)
        floatdiv.Style.Remove("width")
        floatdiv.Style.Add("width", iwidth + 190 & "px")
        topfix0.Style.Remove("width")
        topfix0.Style.Add("width", iwidth + 190 & "px")
        If iTablero <> 1 Then
            iNumbahias = iNumbahias '* 2
        End If
        ilargo = ((iNumbahias) * 30) + 92

        If bTecnicos Then



            sScript += "<script type='text/javascript'>" & vbCrLf
            sScript += "var jg_doc = new jsGraphics();" & vbCrLf
            'sScript += "var days = " & CDate(lblCalendar.Text).DayOfYear + (3 - CDate(lblCalendar.Text).DayOfYear - 2) - CDATES.iDomingos(CDate(lblCalendar.Text)) & ";" & vbCrLf

            sScript += "var hours = " & Date.Now.Hour & ";" & vbCrLf
            sScript += "var minutes = " & Date.Now.Minute & ";" & vbCrLf
            sScript += "var ifac = 0.05*94;" & vbCrLf
            sScript += "if(hours<" & iHorai & "||hours>" & iHorai + inumHoras - 1 & "){"
            sScript += "hours=0;minutes=0; "
            sScript += "} else {hours=hours-" & iHorai & ";}" & vbCrLf
            sScript += "jg_doc.setColor('" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTiempo") & "');" & vbCrLf
            sScript += "lx = ((hours * 60) + minutes);(lx *(59.437/2));lx=lx+ifac;" & vbCrLf
            sScript += "if (lx > ifac) {" & vbCrLf
            sScript += "lx =  ((hours * 60) + minutes) - ifac; ;" & vbCrLf
            sScript += "" & vbCrLf
            sScript += "lx = parseInt(lx);" & vbCrLf
            sScript += "jg_doc.fillRect(92, 94, lx, " & ilargo - 92 & ");}" & vbCrLf


            ''''
            sScript += " var ejeX=206; var ejeY=94; " & vbCrLf

            sScript += " for(var d_i = 1; d_i <= " & iNumbahias & "; d_i++){ " & vbCrLf



            sScript += "    ejeY += 30; " & vbCrLf
            sScript += "    if (d_i == " & iNumbahias & " || d_i == " & iNumbahias * 2 & "  || d_i == " & iNumbahias * 3 & "  || d_i == " & iNumbahias * 4 & " || d_i == " & iNumbahias * 5 & "){" & vbCrLf
            sScript += "        jg_doc.setColor('Black');   jg_doc.fillRect(0, ejeY, " & iwidth + 92 & ", 2);} " & vbCrLf
            sScript += "    else{jg_doc.setColor('Darkslategray');jg_doc.drawLine(0, ejeY, " & iwidth + 92 & ", ejeY);} " & vbCrLf

            ' sScript += "    jg_doc.setColor('#EEEEE0');jg_doc.fillRect(0, ejeY-30, " & iwidth + 92 & ", 30); " & vbCrLf
            'sScript += "    jg_doc.setColor('#E0FFFF');jg_doc.fillRect(0, ejeY-60, " & iwidth + 92 & ", 30); " & vbCrLf

            sScript += " }" & vbCrLf


            '''''


            sScript += "jg_doc.setColor('Lightcoral');" & vbCrLf
            sScript += "jg_doc.drawLine(92, 0, 92, " & ilargo & "); " & vbCrLf
            sScript += "jg_doc.setColor('Black');" & vbCrLf
            sScript += "jg_doc.fillRect(" & iwidth + 92 & ", 0, 3, " & ilargo & ");" & vbCrLf
            sScript += " jg_doc.setColor('Black'); " & vbCrLf


            sScript += "jg_doc.fillRect(0, " & ilargo & ", " & iwidth + 92 & ", 3);" & vbCrLf

            sScript += "jg_doc.setColor('Silver'); " & vbCrLf
            sScript += "var posX = 92,posX2=92;posX3=92;" & vbCrLf
            sScript += "for(var d_i = 1; d_i <= " & System.Math.Round(iwidth / ifac) & "; d_i++){" & vbCrLf
            sScript += "            for(var d_j = 1; d_j < " & inumHoras + 1 & "; d_j++){" & vbCrLf
            '  sScript += "                jg_doc.setColor('Snow'); jg_doc.drawLine(posX2+(59.437/2), 92, posX2+(59.437/2), " & ilargo & ");" & vbCrLf
            sScript += " for(var d_d = 1; d_d < 13; d_d++){ posX3=posX3+4.95;" & vbCrLf
            sScript += " jg_doc.setColor('" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid") & "'); jg_doc.drawLine(posX3, 92, posX3, " & ilargo & ");" & vbCrLf
            sScript += "               }" & vbCrLf
            sScript += "                jg_doc.setColor('" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid") & "'); jg_doc.drawLine(posX2, 92, posX2, " & ilargo & ");" & vbCrLf
            sScript += "                jg_doc.setColor(' " & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid2") & "'); jg_doc.drawLine(posX2+(60/2), 92, posX2+(60/2), " & ilargo & ");" & vbCrLf

            sScript += "                posX2=posX2+59.437;}" & vbCrLf
            sScript += "        jg_doc.setColor('Navy'); jg_doc.drawLine(posX, 92, posX, " & ilargo & "); " & vbCrLf

            'sScript += "        jg_doc.setColor('Silver'); jg_doc.drawLine(posX+37.75, 92, posX+37.75, " & ilargo & "); " & vbCrLf
            sScript += "     posX = posX+" & ifac & ";}" & vbCrLf




            sScript += " " & vbCrLf


            sScript += " //SET_DHTML('ds00'); " & vbCrLf
            sScript += " " & vbCrLf
            sScript += "" & vbCrLf


            sScript += "</script>" & vbCrLf

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "TabGraph", sScript)


            ''  Exit Sub

            Dim ddate As Date '= Now.Date.AddDays(-inumLeft)
            ddate = CDate(lblCalendar.Text).AddDays(-inumLeft)
            Dim txtDia2 As HtmlGenericControl
            Dim txtDia3 As HtmlGenericControl

            Dim dtPosDias As New DataTable, ktop As Integer = 0
            dtPosDias.Columns.Add("dia", New Date().GetType)
            dtPosDias.Columns.Add("posleft", New Integer().GetType)
            dtPosDias.Rows.Clear()


            For i = 1 To inumDias

                txtDia3 = New HtmlGenericControl("div")
                txtDia2 = New HtmlGenericControl("div")
                txtDia2.ID = "txtDia" & ddate.AddDays(i - inumLeft).DayOfYear

                txtDia2.Style.Value = "border:none;position:absolute;left:" & 91 + ((ifac) * (i - 1)) & "px;top:50px;width:" & ifac & "px;height:40px;background-color:White;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:15px;text-align:center;"

                txtDia2.InnerText = ddate.AddDays(i - 1).ToShortDateString

                dtPosDias.Rows.Add(New Object() {CDate(txtDia2.InnerText), 91 + ((ifac) * (i - 1))})
                txtDia3.Style.Value = "width:" & ifac & "px;height:10px;background-color:White;Font-weight:bold;font-family:Arial;font-size:12px;text-align:center;"
                txtDia3.InnerHtml = "<table border='0' cellspacing=0 cellpadding=0   ><tr>"
                For ii = 0 To inumHoras - 1
                    txtDia3.InnerHtml = txtDia3.InnerHtml & "<td  style='border:solid 1px black; width:" & Math.Round(ifac / inumHoras, MidpointRounding.ToEven) & "px;background-color:White;' >" & String.Format("{00:d}", ii + iHorai) & ":00</td>"

                Next
                txtDia3.InnerHtml = txtDia3.InnerHtml & "</tr></table>"
                txtDia2.Controls.Add(txtDia3)
                If form1.FindControl(txtDia2.ID) Is Nothing Then
                    floatdiv.Controls.Add(txtDia2)
                End If



            Next
            Session("dtPosDias") = dtPosDias
        End If



        Dim imgLst As New ArrayList()
        Dim xleft As Integer = -100, III As Integer = 20
        imgLst.Clear()

        Dim imgLstPosMec As New DataTable
        imgLstPosMec.Columns.Add("ID")
        imgLstPosMec.Columns.Add("numcita")
        imgLstPosMec.Columns.Add("idservicio")
        imgLstPosMec.Columns.Add("noplacas")
        imgLstPosMec.Columns.Add("cliente")
        imgLstPosMec.Columns.Add("idcontrol")
        imgLstPosMec.Columns.Add("toppx")
        imgLstPosMec.Rows.Clear()

        leftfix0.Controls.Clear()

        For i = 1 To OBJCOL.Count


            txtMec = New Label
            txtMec.ID = "txtMec_" & i
            objchip = OBJCOL.Item(i - 1)

            xleft = xleft + 110
            If (i / III) - Fix(i / III) = 0 Then
                xleft = 220
            End If

            txtMec.Style.Value = "position:absolute;top:" & ((Fix((i - 1) / III)) * 32) + 75 & "px;left:" & xleft + 5 & "px;width:100px;background-color:" & "#fff" & ";Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:12px;border:solid 1px black;"
            txtMec.Text = objchip.NOPLACAS & " Cita:" & objchip.NUMCITA & vbCrLf & objchip.CLIENTE & vbCrLf & "Unidad: " & objchip.VEHICULO & vbCrLf & "FechaCita: " & objchip.FECHAORIGINAL.ToShortDateString & " " & String.Format("{0:hh:mm}", CDate(objchip.HORAASESOR)) & vbCrLf & "Duracion: " & objchip.SERVICIO
            txtMec.ToolTip = "Servicio: " & objchip.SERVICIOCAPTURADO & vbCrLf & "Comentarios: " & objchip.OBSERVACIONES & ""
            dtTemp = TablerosUtilsHyP.ObtenServiciosxNoorden(objchip.NUMCITA)
            If dtTemp.Rows.Count > 0 Then
                txtMec.ToolTip += vbCrLf & "Tareas:" & vbCrLf
                For ii As Integer = 0 To dtTemp.Rows.Count - 1
                    txtMec.ToolTip += "- " & dtTemp.Rows(ii).Item(0).ToString & vbCrLf
                Next
            End If


            txtMec.Attributes.Add("class", "menu")
            leftfix0.Controls.Add(txtMec)
            imgLst.Add(txtMec.ID)

            imgLstPosMec.Rows.Add(New Object() {objchip.ID, objchip.NUMCITA, objchip.IDSERVICIO, objchip.NOPLACAS, objchip.CLIENTE, txtMec.ID, 95 + ((50) * (i - 1))})
            AgregaInfo(txtMec.ID, objchip.ID & "___" & objchip.NUMCITA & "___" & objchip.NOPLACAS & "___" & objchip.IDSERVICIO & "___" & objchip.COLORPRISMA & "___" & objchip.CLIENTE & "___" & objchip.ASYSRENGLON & "___" & objchip.SERVICIOCAPTURADO & "___" & objchip.HORAASESOR & "___" & objchip.VEHICULO & "___" & objchip.VIN & "___" & objchip.AÑO & "___" & objchip.COLOR & "___" & objchip.IDASESOR & "___" & objchip.TELEFONOS & "___" & objchip.SERVICIO & "___" & objchip.IDITEM & "___" & objchip.NOPRISMA & "___" & objchip.TIPOCLIENTE & "___" & objchip.FECHA.ToShortDateString & "___" & objchip.HORAASESOR & "___" & objchip.IDBLINSUR & "___" & objchip.OBSERVACIONES)


        Next

        Session("imgLst") = imgLst
        Session("imgLstPosMec") = imgLstPosMec


        iniciaTablero2()
        PINTACHIPS()
        Session.Remove("ObtenAusencias")
    End Sub
    Protected Sub lblDescFase_click(ByVal sender As Object, ByVal e As EventArgs)
        Session("fase") = CType(CType(sender.parent, DataListItem).FindControl("lblFase"), Label).Text


        bref = True
        iniciaTablero(True, txtBuscar.Text)

    End Sub
    Private Sub txtCalendar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCalendar.TextChanged

        lblCalendar.Text = txtCalendar.Text
        iniciaTablero(True, txtBuscar.Text)
    End Sub
    Sub PINTACHIPS()


        Dim OBJCOL As New CHIPHYPCollection, objchip As ChipHYP
        Dim sColor As String, sColorServicio As String, oChip As String, iNivel As Integer = 0
        'Dim dtDetenidos As New DataTable, dtIniciados As New DataTable, i As Integer, k As Integer, sLeft As Double, swidth As Integer
        Dim sstop As String, ssleft As String
        Dim imgLst As New ArrayList(), bAlarm As Boolean = False
        Dim imgLst2 As New ArrayList()
        Session("imgLst2") = imgLst2



        imgLst = Session("imgLst")

        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "CitasVista").ToString = "1" Then
            OBJCOL = OBJCOL.ObtenChipsAllPCitasView(Request.Url.Segments(Request.Url.Segments.Length - 1), CDate(lblCalendar.Text))

        Else
            OBJCOL = OBJCOL.ObtenChipsAllP(Request.Url.Segments(Request.Url.Segments.Length - 1), CDate(lblCalendar.Text))

        End If



        Session("ColChipsP") = OBJCOL
        For i = 1 To OBJCOL.Count
            objchip = OBJCOL.Item(i - 1)
            sColorServicio = "#fff" 'TablerosUtilsHyP.ObtenColorServicioFaseII(objchip.IDSERVICIO)
            sColor = TablerosUtilsHyP.ObtenColorAsesor(objchip.IDASESOR)
            oChip = Left(objchip.OCHIP, 2)


            If objchip.CARRYOVER Then oChip = "dp"
            If objchip.SERVICIO < 60 Then oChip = "dr"
            If objchip.SERVICIO >= 60 Then oChip = "dr"
            If objchip.SERVICIO >= 120 Then oChip = "dg"

            If objchip.CONCITA Then
                Select Case objchip.TIPOCLIENTE.Trim.ToLower
                    Case "servicio", "cita normal"
                        oChip = "dg"
                    Case "reclamacion", "reclamaciones"
                        oChip = "dgr"
                    Case "retrabajo"
                        oChip = "dwr"
                    Case "express"
                        oChip = "dge"
                    Case "internet"
                        oChip = "dgi"
                    Case Else
                        oChip = "dg"
                End Select

            End If

            If objchip.CONCITA = False Then
                If objchip.TIPOCLIENTE.Trim.ToLower = "waste" Then
                    oChip = "dgw"
                ElseIf objchip.TIPOCLIENTE.Trim.ToLower = "retrabajo" Then
                    oChip = "dwr"
                Else
                    oChip = "db"
                End If

            End If

            If objchip.STATUS.ToLower = "detenida" Then
                oChip = "dw" & objchip.IDMOTIVOPARO
            End If

            Try
                sstop = CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.ID & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") & "px"

                If objchip.STATUS.ToLower = "detenida" Or objchip.STATUS.ToLower = "iniciada" Or objchip.STATUS.ToLower = "reiniciada" Then
                    iNivel = 1

                    ' sstop = CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.ID & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") + 30 & "px"
                Else
                    iNivel = 1
                    ' sstop = CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.ID & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") & "px"
                End If

                If objchip.STATUS.ToLower = "terminado" Then

                    oChip = "dl"
                    iNivel = 0
                    'sstop = CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.NOORDEN & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") + 30 & "px"

                End If
            Catch ex As Exception
                sstop = "0px"
            End Try


            If objchip.VHSERVERMINADO = False Then
                If objchip.VHRECEPCION = False And CDate(objchip.FECHA.ToShortDateString & " " & objchip.HORAASESOR) < Date.Now Then
                    If objchip.CARRYOVER = False Then
                        If CDate(objchip.FECHA.ToShortDateString & " " & objchip.HORACITA) < Date.Now Then
                            oChip = "dn"

                        End If
                    End If

                End If
            End If

            imgLst.Add("ds" & String.Format("{0:000}", i))
            If Not Session("buscaChip") Is Nothing Then
                Select Case lstFind.SelectedItem.Value
                    Case "1"
                        If objchip.NOPLACAS.Trim.ToLower = txtFind.Text.Trim.ToLower Then
                            oChip = "busqueda"

                        End If
                    Case "2"
                        If objchip.NUMCITA.ToString.Trim.ToLower = txtFind.Text.Trim.ToLower Then
                            oChip = "busqueda"
                        End If
                End Select
            End If
            If CDate(objchip.FECHA.ToShortDateString & " " & objchip.HORARAMPA) <= Date.Now And objchip.STATUS.ToLower = "pendiente" Then
                bAlarm = True
            Else
                bAlarm = False
            End If
            If objchip.STATUSOS <> "SSINCARGO" And objchip.STATUSOS <> "Facturado" And objchip.STATUSOS <> "Remisionado" Then
                Try
                    If CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear > CDate(objchip.FECHA).DayOfYear Then


                        ssleft = ((DateDiff(DateInterval.Day, CDate(lblCalendar.Text).AddDays(-inumLeft), CDate(objchip.FECHA))) * ifac) + IIf(((CDate(objchip.HORARAMPA).Hour * 60) - (iHorai * 60)) >= 0, ((((CDate(objchip.HORARAMPA).Hour * 60) - (iHorai * 60)) + CDate(objchip.HORARAMPA).Minute) * ((ifac / inumHoras) / 60)), 0) + 92
                    Else
                        ssleft = ((CDate(objchip.FECHA).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(objchip.HORARAMPA).Hour * 60) - (iHorai * 60)) >= 0, ((((CDate(objchip.HORARAMPA).Hour * 60) - (iHorai * 60)) + CDate(objchip.HORARAMPA).Minute) * ((ifac / inumHoras) / 60)), 0) + 92
                    End If


                    'chipBoard(i, oChip, objchip.IDCHIP, CInt((objchip.SERVICIO / 60) * 9.437), objchip.NOORDEN, ((CDate(objchip.FECHA).DayOfYear - (CDate(lblCalendar.Text).AddMonths(-1).DayOfYear)) * 75.5) + IIf(((CDate(objchip.HORARAMPA).Hour - 9 - 1) * 9.437) > 0, ((CDate(objchip.HORARAMPA).Hour - 9 - 1) * 9.437), 0) + 92 & "px", CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.NOORDEN & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") & "px", sColor, sColorServicio, objchip.ID, objchip.NOPLACAS, objchip.SERVICIO, objchip.OBSERVACIONES)
                    chipBoard(i, oChip, objchip.IDCHIP, CInt((objchip.SERVICIO / 60) * (ifac / inumHoras)), objchip.VEHICULO, ssleft & "px", sstop, sColor, sColorServicio, objchip.ID, objchip.SERVICIOCAPTURADO, objchip.SERVICIO, objchip.OBSERVACIONES, bAlarm, objchip)
                    '((CDate(objchip.HORARAMPA).Minute +((CDate(objchip.HORARAMPA).Hour * 60) - (9 * 60)) ) * (59/60) )+92
                Catch ex As Exception

                End Try
            End If

        Next
        Session.Remove("buscaChip")
        Session("imgLst") = imgLst
        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "IndicadoresCitas").ToString = "1" Then
            llenaindicadores()
        End If

    End Sub
    Sub AgregaInfo(ByVal sIdControl As String, ByVal sString As String)
        Dim imgLstInfo As New ArrayList()
        imgLstInfo = CType(Session("imgLstInfo"), ArrayList)
        imgLstInfo.Add("lblInfo" & sIdControl & "--" & sString)
        Session("imgLstInfo") = imgLstInfo
        Dim LBL As HtmlGenericControl
        LBL = New HtmlGenericControl("div")
        Try
            If form1.FindControl("lblInfo" & sIdControl) Is Nothing Then
                LBL.ID = "lblInfo" & sIdControl
                LBL.Style.Value = "display:none;"
                LBL.InnerText = sString

                form1.Controls.Add(LBL)
            Else

                CType(form1.FindControl("lblInfo" & sIdControl), HtmlGenericControl).InnerText = sString

            End If
        Catch ex As Exception

        End Try





    End Sub



    Function imageCHIP(ByVal sChip As String) As String


        Return SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), sChip)

    End Function


    Sub chipBoard(ByVal numberChip As Integer, ByVal sChip As String, ByVal iItem As Integer, ByVal iTime As Integer, ByRef sTexto As String, ByVal sL As String, ByVal sT As String, ByVal sColor As String, ByVal sColorServicio As String, ByVal iId As Integer, ByVal sServicioCapturado As String, ByVal sServicio As String, ByVal sObservaciones As String, ByVal bAlarm As Boolean, ByVal objChip As ChipHYP)


        Dim sDiv, sWidth, sImageChip As String


        Dim lbl1 As String = "", lbl2 As String = "", lbl3 As String = "", lbl4 As String = ""
        Dim iPos1 As Integer



        sDiv = "ds" & String.Format("{0:000}", numberChip)

        sImageChip = imageCHIP(sChip)

        ' iWidth = (iTime * 76) / 60

        sWidth = iTime & "px"


        lbl1 = sTexto

        iPos1 = InStr(lbl1, "@")
        If iPos1 > 0 Then
            lbl2 = Mid(lbl1, iPos1 + 1, Len(lbl1) - iPos1)
            lbl1 = Mid(lbl1, 1, iPos1 - 1)

            iPos1 = InStr(lbl2, "@")
            If iPos1 > 0 Then
                lbl3 = Mid(lbl2, iPos1 + 1, Len(lbl2) - iPos1)
                lbl2 = Mid(lbl2, 1, iPos1 - 1)
            End If

            iPos1 = InStr(lbl3, "@")
            If iPos1 > 0 Then
                lbl4 = Mid(lbl3, iPos1 + 1, Len(lbl3) - iPos1)
                lbl3 = Mid(lbl3, 1, iPos1 - 1)
            End If
        End If


        displayChip(iId, sDiv, sL, sT, sWidth, sImageChip, sColor, sColorServicio, iTime, lbl1, sChip, lbl3, lbl4, sServicioCapturado, sServicio, sObservaciones, bAlarm, objChip)




    End Sub
    Sub displayChip(ByVal iItem As Integer, ByVal sDiv As String, ByVal sL As String, ByVal sT As String, ByVal sWidth As String, ByVal sImageChip As String, ByVal sColor As String, ByVal scolorservicio As String, ByVal iTime As Integer, ByVal lblChp1 As String, ByVal lblChp2 As String, ByVal lblChp3 As String, ByVal lblChp4 As String, ByVal sServiciocapturado As String, ByVal sServicio As String, ByVal sObservaciones As String, ByVal bAlarm As Boolean, ByVal objChip As ChipHYP)


        Dim iDiv As Integer
        Dim lbl1 As String
        Dim imgList As New ArrayList()
        iDiv = Val(Right(sDiv, 3))
        lbl1 = "lb" & Right(sDiv, 3) & "1"

        Dim ixdivId As New HtmlInputHidden
        ixdivId.Value = iItem
        ixdivId.ID = "ctlll_" & iItem

        Dim ixdiv As New HtmlGenericControl("div")
        ixdiv.ID = sDiv

        imgList = CType(Session("imgLst2"), ArrayList)
        imgList.Add(ixdiv.ID & "__" & objChip.ID)
        Session("imgLst2") = imgList


        Dim converter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color))
        Dim color As System.Drawing.Color
        'color = color.FromArgb(255, 255 - (CType(converter.ConvertFromString(scolorservicio), System.Drawing.Color).R), 255 - (CType(converter.ConvertFromString(scolorservicio), System.Drawing.Color).G), 255 - (CType(converter.ConvertFromString(scolorservicio), System.Drawing.Color).B))

        ixdiv.Style.Add("Left", sL)
        ixdiv.Style.Add("top", sT)
        ixdiv.Style.Add("width", sWidth)
        ixdiv.Style.Add("height", "27px")
        ixdiv.Style.Add("cursor", "hand")
        'If Left(lblChp2, 2) <> "dl" And Left(lblChp2, 2) <> "dw" Then
        '    ixdiv.Style.Add("background-color", scolorservicio)
        'Else
        ixdiv.Style.Add("background-color", sImageChip)
        ' End If
        ixdiv.Style.Add("color", System.Drawing.ColorTranslator.ToHtml(color))
        ixdiv.Style.Add("position", "absolute")
        ixdiv.Visible = True
        ixdiv.Style.Add("border-top-style", "solid")
        ixdiv.Style.Add("border-top-color", sColor)
        ixdiv.Style.Add("border-left-color", "black")
        ixdiv.Style.Add("border-right-color", "black")
        ixdiv.Style.Add("border-bottom-color", "black")
        ixdiv.Style.Add("border-left-style", "solid")
        ixdiv.Style.Add("border-right-style", "solid")
        ixdiv.Style.Add("border-bottom-style", "solid")
        ixdiv.Style.Add("border-left-width", "1px")
        ixdiv.Style.Add("border-right-width", "1px")
        ixdiv.Style.Add("border-bottom-width", "1px")
        'If Left(lblChp2, 2) = "dw" Then ixdiv.Style.Add("Filter", "Chroma(Color=#FFFFFF)Wave(Add=0, Freq=5, LightStrength=20, Phase=220, Strenght=10)")
        ixdiv.Style.Add("clear", "none")
        ixdiv.Style.Add("z-index", "1500")
        ixdiv.Style.Add("font-size", "10px")
        ixdiv.Style.Add("font-weight", "normal")
        ixdiv.Style.Add("text-align", "center")
        ixdiv.Attributes.Add("class", "menu")
        ixdiv.Style.Add("background-position", "left top")

        If objChip.IDCHIP = 0 Then
            ixdiv.Style.Add("filter", "progid:DXImageTransform.Microsoft.gradient(startColorstr=#ffffff, endColorstr=" & sImageChip & ", GradientType=3)")
            '   ixdiv.Style.Add("background", "-webkit-gradient(radial,center center,0,center center,60,from(#FFFFFF),to(" & sImageChip & "))")
            ixdiv.Style.Add("background", "-moz-radial-gradient(40% 40%, farthest-side, #ffffff, " & sImageChip & ")")
            '  ixdiv.Style.Add("background", "-moz-radial-gradient(40% 40%, farthest-side, #ffffff, " & sImageChip & ")")

            ixdiv.Style.Add("background", "-webkit-radial-gradient(30% 30%, farthest-corner, #FFFFFF 30%, " & sImageChip & " 100%)")
        End If


        Dim sComentarios As String = ""
        For Each d As ChipHYPCom In objChip._HypComentarios
            sComentarios = sComentarios & "--- Comentarios en " & d._Status & "---" & vbCrLf
            sComentarios = sComentarios & "Fecha: " & d._fecha.ToShortDateString & " " & d._fecha.ToShortTimeString & ", "
            sComentarios = sComentarios & "Usuario: " & d._cveUsuario & vbCrLf
            sComentarios = sComentarios & "   " & d._comentario & vbCrLf
        Next



        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sToolTip") = "" Then
            ixdiv.Attributes.Add("title", "no info")

        Else
            ixdiv.Attributes.Add("title", BDClass.SQLtoDataTable(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sToolTip") & " where id=" & objChip.ID & " and tipocliente='" & objChip.TIPOCLIENTE & "'", False).Rows(0).Item(0).ToString())

        End If


        '   ixdiv.Attributes.Add("ondblclick", "Location('" & ixdiv.ID & "')")



        ixdiv.InnerText = objChip.CAMPOMOSTRAR.Trim()



        If Left(objChip.STATUS.ToUpper, 1) = "I" Or Left(objChip.STATUS.ToUpper, 1) = "R" Or Left(objChip.STATUS.ToUpper, 1) = "D" Or Left(objChip.STATUS.ToUpper, 1) = "T" Then
            Dim ixdivsT As New HtmlGenericControl("div")
            ixdivsT.ID = sDiv & "ST"

            ixdivsT.Style.Add("Left", "0")
            ixdivsT.Style.Add("top", "11px")
            ixdivsT.Style.Add("cursor", "hand")
            ixdivsT.Style.Add("position", "absolute")
            ixdivsT.Style.Add("width", "100%")
            ixdivsT.Style.Add("height", "12px")
            'ixdivAlert.Style.Add("background-color", "Transparent")
            ' ixdivsT.Style.Add("filter", "alpha(opacity = 20)")
            ixdivsT.Style.Add("font-size", "10px")
            ixdivsT.Style.Add("text-align", "center")
            ixdivsT.Style.Add("font-weight", "bold")
            ixdivsT.InnerText = Left(objChip.STATUS.ToUpper, 1)
            ' ixdiv.Style.Add("z-index", "1501")
            ixdiv.Controls.Add(ixdivsT)

        End If

        If bAlarm Then
            Dim ixdivAlert As New HtmlImage
            ixdivAlert.ID = sDiv & "Alert"
            ixdivAlert.Src = "~/img/blinkyellow.gif"
            ixdivAlert.Style.Add("Left", "0")
            ixdivAlert.Style.Add("top", "0")
            ixdivAlert.Style.Add("cursor", "hand")
            ixdivAlert.Style.Add("position", "absolute")
            ixdivAlert.Style.Add("width", "100%")
            ixdivAlert.Style.Add("height", "100%")
            'ixdivAlert.Style.Add("background-color", "Transparent")
            'ixdivAlert.Style.Add("filter", "alpha(opacity = 20)")

            ' ixdiv.Style.Add("z-index", "1501")
            ixdiv.Controls.Add(ixdivAlert)

        End If

        ixdiv.Controls.Add(ixdivId)
        Me.form1.Controls.Add(ixdiv)

    End Sub


    Private Sub whuxgaPT_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        Dim OBJARRAY As ArrayList = CType(Session("imgLst"), ArrayList)
        'Dim OBJARRAYDAYS As ArrayList = CType(Session("imgLstDays"), ArrayList)

        'OBJARRAY.Add("divInterfaz")
        'OBJARRAY.Add("leftfix0")

        Dim va_Enumerator As System.Collections.IEnumerator = OBJARRAY.GetEnumerator()
        Dim sScript As String = ""
        sScript += "" & vbCrLf
        sScript += "" & vbCrLf
        sScript += " SET_DHTML("
        While va_Enumerator.MoveNext()

            sScript += "" & Chr(34) & va_Enumerator.Current & Chr(34) & "+RESIZABLE, "


        End While

        sScript += "" & Chr(34) & "divifra" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "imgLogo1" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "imgLogo0" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "divInterfaz" & Chr(34) & ", "
        sScript += "" & Chr(34) & "leftfix" & Chr(34) & "+NO_DRAG, "

        sScript += "" & Chr(34) & "divFind" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "dhtml" & Chr(34) & "+NO_DRAG, "
        sScript = Left(sScript, Len(sScript) - 2)
        sScript += ");" & vbCrLf
        'sScript += "document.getElementById('txtPos').scrollIntoView(true); " & vbCrLf
        'While va_Enumerator.MoveNext()
        '    If Left(va_Enumerator.Current, 2) = "ds" Then
        '        sScript += "document.getElementById('" & va_Enumerator.Current & "').fireEvent('onclick', '');" & vbCrLf
        '    End If


        'End While


        sScript += "" & vbCrLf
        scrmgr1.RegisterStartupScript(Me, Page.GetType, "TabGraphDHTML", sScript, True)
        If dchp.Visible Then
            scrmgr1.RegisterStartupScript(Me, Page.GetType, "dchpFocus", "document.getElementById('dchp').focus();", True)
        End If
    End Sub


    Function obtenid(s As String) As Int64
        Dim OBJARRAY As ArrayList = CType(Session("imgLst2"), ArrayList)

        Dim va_Enumerator As System.Collections.IEnumerator = OBJARRAY.GetEnumerator()

        While va_Enumerator.MoveNext()
            If Split(va_Enumerator.Current, "__")(0) = s Then
                Return Int64.Parse(Split(va_Enumerator.Current, "__")(1))
            End If


        End While

        Return 0
    End Function
    Private Sub imgBtnMve_DMS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnMve_DMS.Click
        Dim iId As Int64, iPosx As Int32, iPosY As Int32, shora As String
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 5) = "ds00." Then Exit Sub
        'For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
        '    If Left(d.id, 5) = "ctlll" Then
        '        iId = d.Value
        '    End If
        'Next
        iId = obtenid(Split(sdhtml, ".")(0))
        If iId = 0 Then Exit Sub
        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        shora = String.Format("{0:HH:mm}", CDate(String.Format("{00:d}", iHorai) & ":00").AddMinutes((((Decimal.Round(CDec((Val(iPosx) - 92) / ifac), 2) - Fix(CDec((Val(iPosx) - 92) / ifac))) / (ifac / inumHoras)) * ifac) * 60))

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")


        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then
                obj.TOPPX = iPosY
                obj.LEFTPX = iPosx
                obj.HORARAMPA = shora
                If Validar(obj, "M") Then
                    TablerosUtilsHyP.MoverChipCitas(obj, iPosY, iPosx, ifac, inumHoras, iHorai)
                End If
                Exit For
            End If
        Next
        '


        bref = True
        iniciaTablero(True, txtBuscar.Text)

    End Sub
    Protected Sub imgBtnTme_CHP_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnTme_CHP.Click
        Dim iId As Int64, iTiempo As Int32, iPosx As Int32, iPosY As Int32, shora As String
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 5) = "ds00." Then Exit Sub

        iTiempo = CInt(Split(sdhtml, ".")(3))
        iTiempo = System.Math.Round(Decimal.Round(CDec(iTiempo / 59), 2) * 60, MidpointRounding.AwayFromZero)

        'iTiempo = CInt((iTiempo) * (5 / 6.33))
        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        'For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
        '    If Left(d.id, 5) = "ctlll" Then
        '        iId = d.Value
        '    End If
        'Next
        shora = String.Format("{0:HH:mm}", CDate(String.Format("{00:d}", iHorai) & ":00").AddMinutes((((Decimal.Round(CDec((Val(iPosx) - 92) / ifac), 2) - Fix(CDec((Val(iPosx) - 92) / ifac))) / (ifac / inumHoras)) * ifac) * 60))

        iId = obtenid(Split(sdhtml, ".")(0))
        If iId = 0 Then Exit Sub

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then
                obj.LEFTPX = iPosx
                obj.TOPPX = iPosY
                obj.SERVICIO = iTiempo
                obj.HORARAMPA = shora
                If Validar(obj, "T") Then
                    TablerosUtilsHyP.AumentarChipPRG(obj, iTiempo)
                End If

                Exit For
            End If

        Next


        bref = True
        iniciaTablero(True, txtBuscar.Text)

    End Sub
    Function Validar(ByVal obj As ChipHYP, ByVal iOperacion As String) As Boolean

        'If obj.IDCHIP = 0 Then
        '    TablerosUtilsHyP.iMsgBox(Me.Page, "Este chip aun no ha sido recibido ")

        '    Return False
        'End If


        Dim ileft As Integer = CInt(((24) / 3) * 9.437)


        Select Case iOperacion
            Case "G"

                If DateDiff(DateInterval.Day, obj.FECHA, obj.FECHAORIGINAL) <> 0 And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iValidacionDiaCita") = "1" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede grabar la cita a un dia distino de " & obj.FECHAORIGINAL.ToShortDateString, ileft)

                    Return False
                End If
                Try
                    If obj.FECHA < obj.FECHAORIGINAL.AddMinutes(If(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCitasToleracia") = "", "20", SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCitasToleracia"))) Then

                        TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede asignar antes de la hora programada", ileft)

                        Return False
                    End If
                Catch ex As Exception
                    TablerosUtilsHyP.iMsgBox(Me.Page, "hora cita no valida", ileft)

                    Return False
                End Try


                If obj.USUARIO.Trim.ToLower <> HttpContext.Current.Session("Usuario").ToString().Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxUsuario") = "1" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Solo el usuario " & obj.USUARIO.Trim.ToLower & " tiene permisos sobre esta tarea", ileft)
                    Return False
                End If





                If SCC.SolPermisosBol(SCC.EObjetos.CHIPCITAS, SCC.EOperaciones.Grabar) = False Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  grabar esta operacion", ileft)
                    Return False
                End If

                If Session("cveAsesor").ToString.Trim.ToLower <> obj.IDASESOR.Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxAsesor") = "1" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, " Solo " & obj.IDASESOR.Trim.ToLower & " tiene permisos para  grabar esta operacion", ileft)
                    Return False
                End If

            Case "M"

                If obj.STATUS = "Terminado" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede mover una operacion terminada", ileft)
                    Return False
                End If

                If obj.STATUS = "Iniciada" Or obj.STATUS = "Reiniciada" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede mover una operacion Iniciada", ileft)
                    Return False
                End If
                If obj.USUARIO.Trim.ToLower <> HttpContext.Current.Session("Usuario").ToString().Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxUsuario") = "1" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Solo el usuario " & obj.USUARIO.Trim.ToLower & " tiene permisos sobre esta tarea", ileft)
                    Return False
                End If
                'If obj.FECHA < s Then

                '    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede asignar antes de la hora programada", ileft)

                '    Return False
                'End If
                If SCC.SolPermisosBol(SCC.EObjetos.CHIPCITAS, SCC.EOperaciones.Mover) = False Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  mover esta operacion", ileft)
                    Return False
                End If
                If Session("cveAsesor").ToString.Trim.ToLower <> obj.IDASESOR.Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxAsesor") = "1" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, " Solo " & obj.IDASESOR.Trim.ToLower & " tiene permisos para  mover esta operacion", ileft)
                    Return False
                End If
            Case "B"
                If obj.STATUS = "Terminado" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede borrar una operacion terminada", ileft)
                    Return False
                End If

                If obj.STATUS = "Detenida" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede borrar una operacion detenida", ileft)
                    Return False
                End If

                If obj.STATUS = "Iniciada" Or obj.STATUS = "Reiniciada" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede borrar una operacion Iniciada", ileft)
                    Return False
                End If
                If obj.USUARIO.Trim.ToLower <> HttpContext.Current.Session("Usuario").ToString().Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxUsuario") = "1" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Solo el usuario " & obj.USUARIO.Trim.ToLower & " tiene permisos sobre esta tarea", ileft)
                    Return False
                End If
                If SCC.SolPermisosBol(SCC.EObjetos.CHIPCITAS, SCC.EOperaciones.Borrar) = False Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  borrar esta operacion", ileft)
                    Return False
                End If
                If Session("cveAsesor").ToString.Trim.ToLower <> obj.IDASESOR.Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxAsesor") = "1" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, " Solo " & obj.IDASESOR.Trim.ToLower & " tiene permisos para  borrar esta operacion", ileft)
                    Return False
                End If
            Case "T"
                If obj.STATUS = "Terminado" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede modificar una operacion terminada", ileft)
                    Return False
                End If

                If obj.STATUS = "Iniciada" Or obj.STATUS = "Reiniciada" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede modificar una operacion Iniciada", ileft)
                    Return False
                End If
                If obj.USUARIO.Trim.ToLower <> HttpContext.Current.Session("Usuario").ToString().Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxUsuario") = "1" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Solo el usuario " & obj.USUARIO.Trim.ToLower & " tiene permisos sobre esta tarea", ileft)
                    Return False
                End If
                If SCC.SolPermisosBol(SCC.EObjetos.CHIPCITAS, SCC.EOperaciones.Modificar) = False Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para modificar esta operacion", ileft)
                    Return False
                End If
                If Session("cveAsesor").ToString.Trim.ToLower <> obj.IDASESOR.Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxAsesor") = "1" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, " Solo " & obj.IDASESOR.Trim.ToLower & " tiene permisos para  modificar esta operacion", ileft)
                    Return False
                End If
        End Select

        If iOperacion = "B" Then Return True



        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")


        Dim iwidthServ As Integer = 0
        Dim widthServ As Integer = 0
        Dim dt As New DataTable
        dt = HttpContext.Current.Session("dtPosDias")
        Dim dFecha As DateTime
        Dim sHora As String
        Dim itfecha As Date


        sHora = String.Format("{0:HH:mm}", CDate(String.Format("{00:d}", iHorai) & ":00").AddMinutes((((Decimal.Round(CDec((Val(obj.LEFTPX) - 92) / ifac), 2) - Fix(CDec((Val(obj.LEFTPX) - 92) / ifac))) / (ifac / inumHoras)) * ifac) * 60))
        itfecha = dt.Select("posLeft<=" & obj.LEFTPX & " and posLeft + " & ifac & ">" & obj.LEFTPX & "")(0).Item("dia")
        dFecha = CDate(itfecha.ToShortDateString & " " & sHora)
        Dim fhora As String

        For Each iobj As ChipHYP In OBJCOL
            fhora = iobj.HORARAMPA
            If iobj.ID <> obj.ID And TablerosUtilsHyP.ObtenIdTecnicosCitas(obj.TOPPX).ToLower = iobj.IDTECNICO.ToLower And dFecha.DayOfWeek = iobj.FECHA.DayOfWeek And sHora = fhora And iobj.STATUS = "Pendiente" Then
                iwidthServ = (iobj.SERVICIO * 60) / 60
                widthServ = (obj.SERVICIO * 60) / 60
                'Dim s As String = "EL que mueves: " & obj.ID & " " & dFecha.DayOfWeek & " la fecha: " & dFecha & " se trunca con :" & iobj.ID & " en el dia " & iobj.FECHA.DayOfWeek & " revisar."
                's += " de este: " & iobj.FECHA
                'muestraMensaje(s)
                If TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) >= TablerosUtilsHyP.ObtenPosXxHora(iobj.HORARAMPA) And TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) < (TablerosUtilsHyP.ObtenPosXxHora(iobj.HORARAMPA) + iwidthServ) Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria")
                    Return False

                ElseIf (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) + widthServ) > (TablerosUtilsHyP.ObtenPosXxHora(iobj.HORARAMPA)) And (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) + widthServ) <= (TablerosUtilsHyP.ObtenPosXxHora(iobj.HORARAMPA) + iwidthServ) Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria")
                    Return False
                ElseIf (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA)) <= (TablerosUtilsHyP.ObtenPosXxHora(iobj.HORARAMPA)) And (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) + widthServ) >= (TablerosUtilsHyP.ObtenPosXxHora(iobj.HORARAMPA) + iwidthServ) Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria")
                    Return False
                End If
            End If

        Next



        'For Each iobj As ChipHYP In OBJCOL
        '    If iobj.ID <> obj.ID And TablerosUtilsHyP.ObtenIdTecnicosCitas(obj.TOPPX).ToLower = iobj.IDTECNICO.ToLower And obj.FECHA.DayOfWeek = iobj.FECHA.DayOfWeek And iobj.STATUS = "Pendiente" Then
        '        iwidthServ = (iobj.SERVICIO * 60) / 60
        '        widthServ = (obj.SERVICIO * 60) / 60
        '        If obj.LEFTPX >= (Val(iobj.LEFTPX)) And obj.LEFTPX < (Val(iobj.LEFTPX) + iwidthServ) Then
        '            TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria con  la orden  " & iobj.NOORDEN)
        '            Return False

        '        ElseIf (obj.LEFTPX + widthServ) > (Val(iobj.LEFTPX)) And (obj.LEFTPX + widthServ) <= (Val(iobj.LEFTPX) + iwidthServ) Then
        '            TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria con  la orden " & iobj.NOORDEN)
        '            Return False
        '        ElseIf (obj.LEFTPX) <= (Val(iobj.LEFTPX)) And (obj.LEFTPX + widthServ) >= (Val(iobj.LEFTPX) + iwidthServ) Then
        '            TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria con  la orden " & iobj.NOORDEN)
        '            Return False
        '        End If

        '    End If

        'Next




        'Dim iwidthServ As Integer = 0
        'Dim widthServ As Integer = 0
        'For Each iobj As Chip In OBJCOL
        '    If iobj.ID <> obj.ID And TablerosUtils.ObtenIdTecnicosPR(obj.TOPPX).ToLower = iobj.IDTECNICO.ToLower Then
        '        iwidthServ = (iobj.SERVICIO * 76) / 60
        '        widthServ = (obj.SERVICIO * 76) / 60
        '        If obj.LEFTPX >= (Val(iobj.LEFTPX)) And obj.LEFTPX < (Val(iobj.LEFTPX) + iwidthServ) Then
        '            TablerosUtils.iMsgBox(Me.Page, "El chip se encimaria con  la orden  " & iobj.NOORDEN)
        '            Return False

        '        ElseIf (obj.LEFTPX + widthServ) > (Val(iobj.LEFTPX)) And (obj.LEFTPX + widthServ) <= (Val(iobj.LEFTPX) + iwidthServ) Then
        '            TablerosUtils.iMsgBox(Me.Page, "El chip se encimaria con  la orden " & iobj.NOORDEN)
        '            Return False
        '        End If
        '    End If

        'Next

        'For Each iobj As Chip In OBJCOL
        '    If iobj.NOPLACAS.Trim = obj.NOPLACAS.Trim And iobj.ID <> obj.ID And obj.VIN.Trim = iobj.VIN.Trim Then
        '        iwidthServ = (iobj.SERVICIO * 76) / 60
        '        widthServ = (obj.SERVICIO * 76) / 60
        '        If obj.LEFTPX >= (Val(iobj.LEFTPX)) And obj.LEFTPX <= (Val(iobj.LEFTPX) + iwidthServ) Then
        '            TablerosUtils.iMsgBox(Me.Page, "El vehiculo con la placa " & iobj.NOPLACAS & ", vin " & obj.VIN & ", no puede estar en dos bahias a la vez")
        '            Return False

        '        ElseIf (obj.LEFTPX + widthServ) >= (Val(iobj.LEFTPX)) And (obj.LEFTPX + widthServ) <= (Val(iobj.LEFTPX) + iwidthServ) Then
        '            TablerosUtils.iMsgBox(Me.Page, "El vehiculo con la placa " & iobj.NOPLACAS & ", vin " & obj.VIN & ", no puede estar en dos bahias a la vez")
        '            Return False
        '        End If
        '    End If
        'Next

        'Dim sPosX1 As Integer = 0, sPosX2 As Integer = 0
        'Dim dtTecnicos As DataTable = TablerosUtils.ObtenTecnicos, dtv As DataView
        'dtTecnicos.DefaultView.RowFilter = "id_empleado='" & obj.IDTECNICO & "'"
        'dtv = dtTecnicos.DefaultView
        'widthServ = (obj.SERVICIO * 76) / 60
        'If dtv.Count > 0 Then
        '    If obj.NOMBREDIA = "6" Then
        '        sPosX2 = TablerosUtils.ObtenPosXxHora(dtv(0)("hora_sal_s"))
        '        sPosX1 = TablerosUtils.ObtenPosXxHora(dtv(0)("hora_ent_s"))
        '    Else
        '        sPosX2 = TablerosUtils.ObtenPosXxHora(dtv(0)("hora_sal_lv"))
        '        sPosX1 = TablerosUtils.ObtenPosXxHora(dtv(0)("hora_ent_lv"))
        '    End If
        '    If obj.LEFTPX < sPosX1 Or obj.LEFTPX >= sPosX2 Then
        '        TablerosUtils.iMsgBox(Me.Page, "El chip solo se puede grabar entre la hora de entrada y la hora de salida: " & obj.NOORDEN)
        '        Return False
        '    ElseIf (obj.LEFTPX + widthServ) > sPosX2 Then
        '        TablerosUtils.iMsgBox(Me.Page, "El chip se extiende mas alla de la hora de salida: " & obj.NOORDEN)
        '        Return False
        '    End If
        'End If

        Return True
    End Function

    Protected Sub imgBtnDel_DMS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnDel_DMS.Click
        Dim iId As Int64
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 5) = "ds00." Then Exit Sub
        'For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
        '    If Left(d.id, 5) = "ctlll" Then
        '        iId = d.Value
        '    End If
        'Next
        iId = obtenid(Split(sdhtml, ".")(0))
        If iId = 0 Then Exit Sub

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then
                If Validar(obj, "B") Then
                    TablerosUtilsHyP.BorrarChipPRG(obj)
                End If

                Exit For
            End If

        Next


        bref = True
        iniciaTablero(True, txtBuscar.Text)


    End Sub
    Function obtenInfo(s As String) As String
        Dim OBJARRAY As ArrayList = CType(Session("imgLstInfo"), ArrayList)

        Dim va_Enumerator As System.Collections.IEnumerator = OBJARRAY.GetEnumerator()

        While va_Enumerator.MoveNext()
            If Split(va_Enumerator.Current, "--")(0) = s Then
                Return Split(va_Enumerator.Current, "--")(1)
            End If




        End While

        Return 0
    End Function
    Protected Sub imgBtnUpd_DMS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnUpd_DMS.Click

        Dim objChip As New ChipHYP, objChip2 As New ChipHYP



        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        'muestraMensaje(sdhtml)
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 7) <> "txtMec_" Then Exit Sub

        ' Dim sValores() As String = Split(CType(Me.FindControl("lblInfo" & Split(sdhtml, ".")(0)), HtmlGenericControl).InnerText, "___")
        Dim sValores() As String = Split(obtenInfo("lblInfo" & Split(sdhtml, ".")(0)), "___")
        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChips")

        objChip.OCHIPWIDTH = CInt(Split(sdhtml, ".")(3))
        objChip.LEFTPX = CInt(Split(sdhtml, ".")(1))
        objChip.TOPPX = CInt(Split(sdhtml, ".")(2))
        objChip.IDCHIP = TablerosUtilsHyP.MaxChip


        '  AgregaInfo(


        Dim dFecha As DateTime, sHora As String, sselect As String, sultimochip As Boolean = False
        Dim dt As New DataTable, itfecha As Date
        Dim sscosto As String = ""
        dt = HttpContext.Current.Session("dtPosDias")

        sHora = String.Format("{0:HH:mm}", CDate(String.Format("{00:d}", iHorai) & ":00").AddMinutes((((Decimal.Round(CDec((Val(objChip.LEFTPX) - 92) / ifac), 2) - Fix(CDec((Val(objChip.LEFTPX) - 92) / ifac))) / (ifac / inumHoras)) * ifac) * 60))
        sselect = "posLeft<=" & objChip.LEFTPX & " and (posLeft + " & CInt(ifac) & ")>" & objChip.LEFTPX & ""
        itfecha = dt.Select(sselect)(0).Item("dia")
        dFecha = CDate(itfecha.ToShortDateString & " " & sHora)


        objChip.IDITEM = sValores(16)
        objChip.NUMCITA = sValores(1)
        objChip.ASYSRENGLON = sValores(6)
        objChip.NOPLACAS = sValores(2)
        objChip.IDSERVICIO = sValores(3)
        objChip.SERVICIO = sValores(15)
        If objChip.SERVICIO = "0" Then objChip.SERVICIO = "15"
        objChip.CLIENTE = sValores(5)
        objChip.COLORPRISMA = sValores(4)
        objChip.SERVICIOCAPTURADO = sValores(7)
        objChip.HORAASESOR = String.Format("{0:HH:mm}", CDate(sValores(8)))
        objChip.VEHICULO = sValores(9)
        objChip.VIN = sValores(10)
        objChip.AÑO = sValores(11)
        objChip.COLOR = sValores(12)
        objChip.IDASESOR = sValores(13)
        objChip.TELEFONOS = sValores(14)
        objChip.NOPRISMA = sValores(17)

        objChip.CILINDROS = 0
        objChip.TIPOCLIENTE = sValores(18)
        objChip.IDBLINSUR = sValores(21)
        objChip.CONCITA = True

        objChip.NOORDEN = "0"
        objChip.CONTINUARA = True
        objChip.ENUSO = True
        objChip.VHRECEPCION = False
        objChip.VHINVENTARIO = True
        objChip.VHREPARANDO = False
        objChip.VHREPROGRAMADO = False
        objChip.VHSERVCANCELADO = False
        objChip.VHSERVERMINADO = False
        objChip.HORATOLERANCIA = objChip.HORAASESOR
        objChip.HORACITA = sHora
        objChip.IDTECNICO = TablerosUtilsHyP.ObtenIdTecnicosCitas(objChip.TOPPX)

        objChip.HORAENTREGA = String.Format("{0:00}", CDate(objChip.HORACITA).AddMinutes(objChip.SERVICIO).Hour) & ":" & String.Format("{0:00}", CDate(objChip.HORACITA).AddMinutes(objChip.SERVICIO).Minute)
        objChip.HORARECEPCION = objChip.HORATOLERANCIA
        objChip.HORARAMPA = objChip.HORACITA
        objChip.NOMBREDIA = CDate(txtCalendar.Text).DayOfWeek
        objChip.FECHAAGENDADO = Date.Now
        objChip.FECHAORIGINAL = CDate(sValores(19)).AddMinutes(CDate(sValores(20)).Minute).AddHours(CDate(sValores(20)).Hour)
        objChip.FECHA = dFecha
        objChip.FECHAENTREGA = objChip.FECHA
        objChip.STATUS = "Pendiente"
        objChip.STATUSOS = "ABIERTA"
        objChip.USUARIO = lblUsr.Text
        objChip.OCHIP = "dg" & objChip.SERVICIO & objChip.IDCHIP

        objChip.OBSERVACIONES = ""
        ' objChip.FECHA = CDate(sValores(19))

        sultimochip = TablerosUtilsHyP.UltimoChipCita(objChip.NUMCITA)
        sscosto = TablerosUtilsHyP.ObtenCosto(objChip.NUMCITA)
        If Validar(objChip, "G") Then
            If Not (Validaciones.validaAnteriores(objChip.NOPLACAS)) Then
                TablerosUtilsHyP.GuardarChip(objChip)
                If sultimochip Then
                    Dim m As String = "La cita " & objChip.NUMCITA & " se agendo el " & objChip.FECHA.ToShortDateString & " a las " & objChip.HORAASESOR & " con un costo de " & sscosto & " y con el asesor " & TablerosUtilsHyP.ObtenNombreAsesor(objChip.IDASESOR)
                    Response.Write("<script>window.alert('" & m & "');</script>")
                End If
            Else
                Dim m As String = "EL vehiculo con placas " & objChip.NOPLACAS & " Tiene un Registo Pendiente por darle salida, por ende no se puede agendar una nueva cita, dele salida al registro pendiente he intentelo nuevamente"
                Response.Write("<script>window.alert('" & m & "');</script>")
            End If
        End If


        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iDiagnostico") = "1" And SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "iDiagnostico") = objChip.IDSERVICIO Then

            Session("NF") = TablerosUtilsHyP.ObtenIdCita(objChip.NUMCITA)

            Dim scriptString As String = "<script language='JavaScript'>" _
                                               & " window.open('Diagnostico.aspx', '', 'fullscreen=yes, scrollbars=auto');</script>"

            Page.ClientScript.RegisterStartupScript(GetType(Page), "ShowValue", scriptString)

        End If

        bref = True
        iniciaTablero(True, txtBuscar.Text)
    End Sub

    'Protected Sub sel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Select Case CType(sender.parent.parent.parent.parent, DataGrid).ID
    '        Case gvDetenidos.ID
    '            Me.pgvDms = False
    '            gvDetenidos.SelectedIndex = CType(sender.parent.parent, DataGridItem).ItemIndex

    '            gvDetenidos.Focus()
    '            gvDetenidos.SelectedItem.Focus()
    '        Case gvDMS.ID
    '            Me.pgvDms = True
    '            gvDMS.SelectedIndex = CType(sender.parent.parent, DataGridItem).ItemIndex
    '            gvDMS.Focus()
    '            gvDMS.SelectedItem.Focus()
    '    End Select

    'End Sub



    Private Sub whuxgaPT_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Not Page.IsPostBack Then
            TablerosUtilsHyP.Salir()
        End If
    End Sub

    'Private Sub imgRefreshAll_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgRefreshAll.Click
    '    'refreshDMS()
    'End Sub
    Protected Sub imgFind_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgFind.Click

        Session("buscaChip") = True
        iniciaTablero(False)

        Exit Sub


    End Sub

    Private Sub MPGV_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MPGV.PreRender
        Session("DATEHYP") = CDate(lblCalendar.Text).ToShortDateString
    End Sub
    Protected Sub cboOrdenes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrdenes.SelectedIndexChanged
        Dim s As String
        s = cboOrdenes.Items(sender.SelectedIndex).Text
        iniciaTablero(True, s)
        LlenaComboCitas(s)

    End Sub
    Protected Sub imgBuscar_Click(sender As Object, e As ImageClickEventArgs) Handles imgBuscar.Click

        iniciaTablero(True, txtBuscar.Text)

    End Sub
    Sub nuevoDMS()
        pnlNuevaCita.Visible = True
        gvDMS.Visible = False
        Dim dt As New DataTable
        Dim sqry As String = ""


        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "placas") <= 0 Then
            txtPlacas.Visible = False
            imgBuscaPlaca.Visible = False
        End If


        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "cliente") <= 0 Then
            txtCliente.Visible = False
        End If


        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "color") <= 0 Then
            txtColor.Visible = False
        End If


        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "ano") <= 0 Then
            txtAño.Visible = False
        End If

        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "cilindros") <= 0 Then
            txtCilindros.Visible = False
        End If


        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "vin") <= 0 Then
            txtVin.Visible = False
            imgBuscaVIN.Visible = False
        End If

        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "telefono") <= 0 Then
            txtTelefono.Visible = False
        End If

        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "correo") <= 0 Then
            txtxCorreo.Visible = False
        End If

        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "observaciones") <= 0 Then
            txtObservaciones.Visible = False
        End If
        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "asesor") <= 0 Then
            cboAsesor.Visible = False
        End If
        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "vehiculo") <= 0 Then
            cboVehiculo.Visible = False
        End If
        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "tipocita") <= 0 Then
            cboTipoCita.Visible = False
        End If
        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "campana") <= 0 Then
            rdlCampa.Visible = False
        End If
        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "movilidad") <= 0 Then
            rdlMovilidad.Visible = False
            txtMovilidad.Visible = False
        End If
        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "servicei") <= 0 Then
            rdlServiceInclusive.Visible = False
        End If
        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "garantia") <= 0 Then
            rdlGarantia.Visible = False
            txtGarantia.Visible = False
        End If

        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "medio") <= 0 Then
            rdlMedio.Visible = False

        End If
        If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "contacto") <= 0 Then
            rdlContacto.Visible = False

        End If

        txtPlacas.Text = ""

        txtVin.Text = ""

        txtCliente.Text = ""

        txtTelefono.Text = ""

        txtxCorreo.Text = ""


        txtColor.Text = ""

        txtCilindros.Text = "4"

        txtAño.Text = ""

        txtObservaciones.Text = ""

        txtNoCita.Text = TablerosUtilsHyP.ObtenNumeroCita
        txtFechaCita.Text = CDate(lblCalendar.Text).ToShortDateString
        cboDiaCita.Items.Clear()

        cboDiaCita.Items.Add(New ListItem("Lunes", "1"))
        cboDiaCita.Items.Add(New ListItem("Martes", "2"))
        cboDiaCita.Items.Add(New ListItem("Miercoles", "3"))
        cboDiaCita.Items.Add(New ListItem("Jueves", "4"))
        cboDiaCita.Items.Add(New ListItem("Viernes", "5"))
        cboDiaCita.Items.Add(New ListItem("Sabado", "6"))
        cboDiaCita.Items.Add(New ListItem("Domingo", "0"))


        Dim d As New TimeSpan(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iHoraIniInterCitas"), 0, 0)
        cboHora.Items.Clear()
        cboHora3.Items.Clear()
        Do While d < TimeSpan.Parse("" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iHoraFinInterCitas") & ":00:00")
            cboHora.Items.Add(New ListItem(String.Format("{0:00}", d.Hours) & ":" & String.Format("{0:00}", d.Minutes), String.Format("{0:00}", d.Hours) & ":" & String.Format("{0:00}", d.Minutes)))
            cboHora3.Items.Add(New ListItem(String.Format("{0:00}", d.Hours) & ":" & String.Format("{0:00}", d.Minutes), String.Format("{0:00}", d.Hours) & ":" & String.Format("{0:00}", d.Minutes)))
            d = d.Add(New TimeSpan(0, SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iMinInterCitas"), 0))
        Loop

        Dim dtCitas As New DataTable
        If Not Session("dmsCitas") Is Nothing Then
            dtCitas = CType(Session("dmsCitas"), DataTable)
            cboHora2.Items.Clear()

            For Each a As DataRow In dtCitas.Rows
                cboHora2.Items.Add(New ListItem(a.Item("idasesor") & "_" & CDate(a.Item("fecha")).ToShortDateString & "_" & a.Item("horaasesor")))
            Next
        End If


        sqry = "Select nombre,cveAsesor from SccUsuarios  WHERE cveasesor<>'' and not cveAsesor is null "
        dt = BDClass.SQLtoDataTable(sqry, False)
        cboAsesor.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cboAsesor.Items.Add(New ListItem(dt.Rows(i).Item(0), dt.Rows(i).Item(1)))
        Next

        sqry = "Select  vehiculos from Tb_VEHICULOS"
        dt = BDClass.SQLtoDataTable(sqry, False)

        cboVehiculo.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cboVehiculo.Items.Add(New ListItem(dt.Rows(i).Item(0), dt.Rows(i).Item(0)))
        Next
        session("txtTOp") = "Insert"
    End Sub
    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick

        If Int32.Parse(e.Item.Value) = 0 Then
            Session.Remove("rbDet")
            Session("buscaChip") = False
            '    iniciaTablero(True, txtBuscar.Text)
            If txtBuscar.Text.Trim <> "" Then
                iniciaTablero(True, txtBuscar.Text, False)
            ElseIf cboOrdenes.SelectedIndex >= 0 Then
                iniciaTablero(True, cboOrdenes.Items(cboOrdenes.SelectedIndex).Text, False)
            Else
                iniciaTablero(True, "", False)

            End If
            'PINTACHIPS()
            gvContainer.Visible = False
        ElseIf Int32.Parse(e.Item.Value) = 5 Then
            TablerosUtilsHyP.Salir()
            Response.Redirect("Inicio.aspx")
        Else
            Session("buscaChip") = False
            Session("rbDet") = True
            If txtBuscar.Text.Trim <> "" Then
                iniciaTablero(True, txtBuscar.Text, True)
            ElseIf cboOrdenes.SelectedIndex >= 0 Then
                iniciaTablero(True, cboOrdenes.Items(cboOrdenes.SelectedIndex).Text, True)
            Else
                iniciaTablero(True, "", True)

            End If
            ' iniciaTablero(True, txtBuscar.Text, True)
            refreshDMS()
            gvContainer.Visible = True

        End If
    End Sub
    Sub refreshDMS()
        chkAllCitas.Checked = False
        Dim dt As New DataTable
        dt = TablerosUtilsHyP.Obten_CONTROL_CITAS_DMS
        Session("dmsCitas") = dt

        gvDMS.DataSource = dt
        gvDMS.DataBind()

        'Dim i As Integer
        'For i = 0 To gvDMS.Items.Count - 1
        '    If gvDMS.Items(i).Cells(1).Text = txtBoxBuscarDMS.Text Or txtBoxBuscarDMS.Text.Trim.Length = 0 Then
        '        gvDMS.Items(i).Visible = True
        '        gvDMS.SelectedIndex = gvDMS.Items(i).ItemIndex
        '        gvDMS.SelectedItem.Focus()
        '    Else


        '        gvDMS.Items(i).Visible = False
        '    End If
        'Next
    End Sub
    Sub refreshDMSAll()
        Dim dt As New DataTable
        dt = TablerosUtilsHyP.Obten_CONTROL_CITAS_DMS_All
        Session("dmsCitas") = dt
        dt.DefaultView.RowFilter = "fecha<'#" & CDate(CDate(lblCalendar.Text).ToShortDateString) & "#'"
        gvDMS.DataSource = dt.DefaultView.ToTable.AsEnumerable.Take(30).CopyToDataTable
        gvDMS.DataBind()


    End Sub



    Private Sub cmdGuardarComen_Click(sender As Object, e As EventArgs) Handles cmdGuardarComen.Click
        Dim iId As Int64, iTiempo As Int32, iPosx As Int32, iPosY As Int32
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtmlChp"), HtmlInputText).Value

        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        iTiempo = CInt(Split(sdhtml, ".")(3))
        iTiempo = CInt((iTiempo) * (5 / 6.33))
        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        'For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
        '    If Left(d.id, 5) = "ctlll" Then
        '        iId = d.Value
        '    End If
        'Next

        'iId = CType(Me.FindControl(Split(sdhtml, ".")(0)).Controls(1), HtmlInputHidden).Value
        iId = obtenid(Split(sdhtml, ".")(0))
        If iId = 0 Then Exit Sub

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then

                If txtComen.Text.Trim.Length > 0 Then
                    ChipHYPCom.GuardaComentario(obj, txtComen.Text.Trim)
                    txtComen.Text = ""
                End If
                Exit For
            End If

        Next

        bref = True
        iniciaTablero(True, txtBuscar.Text)

    End Sub
    Sub LimpiaForm()
        Dim objc As New ArrayList()
        For Each d In Me.form1.Controls
            If Left(d.id, 13) = "txtHorarioCSa" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 15) = "txtHorarioENTSa" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 15) = "txtHorarioSALSa" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 11) = "txtHorarioC" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 11) = "txtHorarioL" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 11) = "txtHorarioS" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 11) = "txtAusencia" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 6) = "txtMec" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 6) = "txtNiv" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 2) = "ds" Or Left(d.id, 5) = "ctlll" Then
                objc.Add(d.id)
            End If
        Next
        For Each d In objc
            Me.form1.Controls.Remove(Me.form1.FindControl(d))
        Next

        Dim II As Integer = leftfix.Controls.Count
        For i = (II - 1) To 0 Step -1
            If Left(leftfix.Controls(i).ID, 6) = "txtMec" Then
                leftfix.Controls.RemoveAt(i)
            ElseIf Left(leftfix.Controls(i).ID, 6) = "txtNiv" Then
                leftfix.Controls.RemoveAt(i)
            End If
        Next


        II = floatdiv.Controls.Count
        For i = (II - 1) To 0 Step -1
            If Left(floatdiv.Controls(i).ID, 6) = "txtDia" Then
                floatdiv.Controls.RemoveAt(i)
            ElseIf Left(floatdiv.Controls(i).ID, 6) = "txtDia" Then
                floatdiv.Controls.RemoveAt(i)
            End If
        Next


    End Sub

    Sub NuevaTareaOK(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim snuevo() As String

        snuevo = New String() {gvDMS.Items(sender.parent.parent.ItemIndex).Cells(1).Text, 0, "0", obtenValor("arr1"), obtenValor("arr2"), "", "", Right(CDate(lblCalendar.Text).Ticks.ToString, 9)}
        TablerosUtilsHyP.NuevoControlCitasDMSADet(snuevo)


        CType(gvDMS.Items(sender.parent.parent.ItemIndex).FindControl("imgNuevaTareaOK"), ImageButton).Visible = False
        CType(gvDMS.Items(sender.parent.parent.ItemIndex).FindControl("imgNuevaTarea"), ImageButton).Visible = True
    End Sub
    Sub DelCita(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        If gvDMS.Items.Count = 0 Then Response.Redirect("login.aspx")

        Dim iRowParent As Integer = sender.parent.parent.ItemIndex
        Dim smsgr As String = ""
        Try
            smsgr = TablerosUtilsHyP.Borra_CONTROL_CITAS_DMS_A(gvDMS.Items(iRowParent).Cells(1).Text)
            If smsgr <> "" Then
                TablerosUtilsHyP.iMsgBox(Me.Page, smsgr)
            End If
        Catch
        End Try
        refreshDMS()
        gvContainer.Visible = True
    End Sub
    Sub NuevaTarea(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        If gvDMS.Items.Count = 0 Then Response.Redirect("login.aspx")
        Dim dt As DataTable
        Dim sqry As String
        Dim bd As New BDClass
        'CType(gvDMS.SelectedItem.FindControl("GvTareas"), DataGrid).Visible = False

        Dim SControl As String

        SControl = "<div style='border:solid white thin;background-color:gainsboro;'><br/><table><tr>"

        ' SControl += "<td  colspan='0' align='left'><select id='arr0' name='arr0' style='display:none;'>"

        'sqry = "Select id_empleado,nombre_empleado from Tb_TECNICOS"
        'dt = BDClass.SQLtoDataTable(sqry, False)
        'For i = 0 To dt.Rows.Count - 1
        '    SControl += "<option value='" & dt.Rows(i).Item(0) & "'>" & dt.Rows(i).Item(1)
        'Next
        'SControl += "</select>"
        SControl += "<td   align='left' >Servicio: </td><td  colspan='0' align='left'><select id='arr2' name='arr2' onchange='buscaTm(this.value);'>"

        sqry = "Select  idservicio,describeservicio, tiempoServicio from " & System.Web.Configuration.WebConfigurationManager.AppSettings("tbServicios") & " where NIVEL<>'W' AND (vehiculos='" & gvDMS.Items(sender.parent.parent.itemindex).Cells(5).Text.Trim & "' or vehiculos='TODOS') order by nivel asc "
        dt = BDClass.SQLtoDataTable(sqry, False)

        For i = 0 To dt.Rows.Count - 1
            SControl += "<option value='" & dt.Rows(i).Item(0) & "'>" & dt.Rows(i).Item(1).ToString.Trim
        Next
        SControl += "</select>"
        SControl += "<select id='arr2T' name='arr2T' style='display:none;'>"
        For i = 0 To dt.Rows.Count - 1
            SControl += "<option value='" & dt.Rows(i).Item(0) & "'>" & dt.Rows(i).Item(2).ToString.Trim
        Next
        SControl += "</select>"
        SControl += "</td>"
        SControl += "<td>Tiempo Servicio: </td><td><input type=text id='arr1' name='arr1'  style='width:100px;' value='60' READONLY/></td>"


        SControl += "</tr></table></div>"
        Dim obj1 As HtmlGenericControl = New HtmlGenericControl("div")
        obj1.InnerHtml = SControl
        CType(gvDMS.Items(sender.parent.parent.itemindex).FindControl("imgNuevaTareaOK"), ImageButton).Visible = True
        CType(gvDMS.Items(sender.parent.parent.itemindex).FindControl("imgNuevaTarea"), ImageButton).Visible = False


        CType(gvDMS.Items(sender.parent.parent.itemindex).FindControl("GvTareas"), DataGrid).Parent.Controls.AddAt(0, obj1)
        CType(sender, ImageButton).Focus()
        gvDMS.SelectedIndex = sender.parent.parent.itemindex

        gvDMS.SelectedItem.Focus()
    End Sub

    Protected Sub gvdms_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDMS.PreRender
        HttpContext.Current.Session.Remove("Obten_CONTROL_CITAS_DMS_A_DET")
        For i = 0 To gvDMS.Items.Count - 1
            CType(gvDMS.Items(i).FindControl("GvTareas"), DataGrid).DataSource = TablerosUtilsHyP.Obten_CONTROL_CITAS_DMS_A_DET(gvDMS.Items(i).Cells(1).Text)
            CType(gvDMS.Items(i).FindControl("GvTareas"), DataGrid).DataBind()
            If Val(gvDMS.Items(i).Cells(19).Text) > 0 Then
                gvDMS.Items(i).BackColor = Drawing.Color.LightSteelBlue
            End If
        Next
        HttpContext.Current.Session.Remove("Obten_CONTROL_CITAS_DMS_A_DET")
        Try
            gvDMS.SelectedItem.Focus()
        Catch ex As Exception
            'gvDMS.SelectedIndex = -1
            '' gvDMS.SelectedItem.Focus()
        End Try

    End Sub

    Sub gvtareas_selectindexchanged(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        If gvDMS.Items.Count = 0 Then Response.Redirect("login.aspx")

        CType(gvDMS.Items(sender.parent.parent.parent.parent.parent.parent.itemindex).FindControl("GvTareas"), DataGrid).SelectedIndex = sender.parent.parent.itemindex



        Dim iRowParent As Integer = sender.parent.parent.parent.parent.parent.parent.itemindex
        Dim iRowChild As Integer = sender.parent.parent.itemindex

        gvDMS.SelectedIndex = iRowParent

        gvDMS.SelectedItem.Focus()
        'HttpContext.Current.Session.Remove("Obten_CONTROL_CITAS_DMS_A_DET")
        'CType(gvDMS.Items(iRowParent).FindControl("GvTareas"), DataGrid).DataSource = APPClassTableroCC.Obten_CONTROL_CITAS_DMS_A_DET(gvDMS.Items(iRowParent).Cells(1).Text)
        'CType(gvDMS.Items(iRowParent).FindControl("GvTareas"), DataGrid).DataBind()
        'HttpContext.Current.Session.Remove("Obten_CONTROL_CITAS_DMS_A_DET")


    End Sub
    Sub gvtareas_del(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        If gvDMS.Items.Count = 0 Then Response.Redirect("login.aspx")

        Dim iRowParent As Integer = sender.parent.parent.parent.parent.parent.parent.itemindex
        Dim iRowChild As Integer = sender.parent.parent.itemindex

        'HttpContext.Current.Session.Remove("Obten_CONTROL_CITAS_DMS_A_DET")
        'CType(gvDMS.Items(iRowParent).FindControl("GvTareas"), DataGrid).DataSource = APPClassTableroCC.Obten_CONTROL_CITAS_DMS_A_DET(gvDMS.Items(iRowParent).Cells(1).Text)
        'CType(gvDMS.Items(iRowParent).FindControl("GvTareas"), DataGrid).DataBind()
        'HttpContext.Current.Session.Remove("Obten_CONTROL_CITAS_DMS_A_DET")
        TablerosUtilsHyP.Borra_CONTROL_CITAS_DMS_A_DET(gvDMS.Items(iRowParent).Cells(1).Text, CType(gvDMS.Items(iRowParent).FindControl("GvTareas"), DataGrid).Items(iRowChild).Cells(0).Text)

    End Sub
    Sub EditCita(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        If gvDMS.Items.Count = 0 Then Response.Redirect("login.aspx")

        Dim iRowParent As Integer = sender.parent.parent.ItemIndex

        editarCita(0, gvDMS.Items(iRowParent).Cells(1).Text)

    End Sub

    Sub editarCita(ByVal sId, Optional sNumcita = "0")
        Dim OBJCOL As New CHIPHYPCollection, sqry As String = ""
        OBJCOL = Session("ColChips")
        If sNumcita <> "0" Then
            sqry = "select * from " & System.Web.Configuration.WebConfigurationManager.AppSettings.Item("CitasCaptura").ToString & " where numcita=" & sNumcita & ""
        Else
            Dim ssId As String = CType(Me.FindControl(Split(sId, ".")(0)).Controls(1), HtmlInputHidden).Value
            For Each obj As Chip In OBJCOL
                If obj.ID = ssId Then
                    sqry = "select * from " & System.Web.Configuration.WebConfigurationManager.AppSettings.Item("CitasCaptura").ToString & " where numcita=" & obj.NUMCITA & ""

                    Exit For
                End If
            Next
        End If


        Dim dt As New DataTable, dt1 As New DataTable

        dt1 = BDClass.SQLtoDataTable(sqry, False)
        pnlNuevaCita.Visible = False

        If dt1.Rows.Count = 0 Then Exit Sub

        pnlNuevaCita.Visible = True
        gvDMS.Visible = False
        session("txtTOp") = "Update"
        txtNoCita.Text = dt1.Rows(0).Item("numcita")
        txtFechaCita.Text = CDate(dt1.Rows(0).Item("fecha").ToString).ToShortDateString
        txtPlacas.Text = dt1.Rows(0).Item("noPlacas")
        txtCliente.Text = dt1.Rows(0).Item("Cliente")
        txtColor.Text = dt1.Rows(0).Item("Color")
        txtAño.Text = dt1.Rows(0).Item("ano")
        txtCilindros.Text = dt1.Rows(0).Item("cilindros")
        'cboTipoCita.Text = dt1.Rows(0).Item("tipocliente")
        txtVin.Text = dt1.Rows(0).Item("vin")
        txtTelefono.Text = IIf(dt1.Rows(0).Item("telefono") Is DBNull.Value, "", dt1.Rows(0).Item("telefono").ToString)
        txtxCorreo.Text = IIf(dt1.Rows(0).Item("correo") Is DBNull.Value, "", dt1.Rows(0).Item("correo").ToString)
        txtObservaciones.Text = IIf(dt1.Rows(0).Item("observaciones") Is DBNull.Value, "", dt1.Rows(0).Item("observaciones").ToString)

        cboDiaCita.Items.Clear()

        cboDiaCita.Items.Add(New ListItem("Lunes", "1"))
        cboDiaCita.Items.Add(New ListItem("Martes", "2"))
        cboDiaCita.Items.Add(New ListItem("Miercoles", "3"))
        cboDiaCita.Items.Add(New ListItem("Jueves", "4"))
        cboDiaCita.Items.Add(New ListItem("Viernes", "5"))
        cboDiaCita.Items.Add(New ListItem("Sabado", "6"))
        cboDiaCita.Items.Add(New ListItem("Domingo", "0"))
        Try
            cboTipoCita.Items.FindByText(dt1.Rows(0).Item("tipocliente")).Selected = True
        Catch ex As Exception

        End Try
        Try
            cboDiaCita.Items.FindByText(dt1.Rows(0).Item("diaSemana")).Selected = True
        Catch ex As Exception

        End Try

        Dim d As New TimeSpan(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iHoraIniInterCitas"), 0, 0)
        cboHora.Items.Clear()
        cboHora3.Items.Clear()
        Do While d < TimeSpan.Parse("" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iHoraFinInterCitas") & ":00:00")
            cboHora.Items.Add(New ListItem(String.Format("{0:00}", d.Hours) & ":" & String.Format("{0:00}", d.Minutes), String.Format("{0:00}", d.Hours) & ":" & String.Format("{0:00}", d.Minutes)))
            cboHora3.Items.Add(New ListItem(String.Format("{0:00}", d.Hours) & ":" & String.Format("{0:00}", d.Minutes), String.Format("{0:00}", d.Hours) & ":" & String.Format("{0:00}", d.Minutes)))

            d = d.Add(New TimeSpan(0, SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iMinInterCitas"), 0))
        Loop
        Try
            cboHora.Items.FindByText(dt1.Rows(0).Item("horacita")).Selected = True
        Catch ex As Exception

        End Try

        sqry = "Select nombre,cveAsesor from SccUsuarios  WHERE cveasesor<>'' and not cveAsesor is null "
        dt = BDClass.SQLtoDataTable(sqry, False)
        cboAsesor.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cboAsesor.Items.Add(New ListItem(dt.Rows(i).Item(0), dt.Rows(i).Item(1)))
        Next
        Try
            cboAsesor.Items.FindByValue(dt1.Rows(0).Item("idAsesor")).Selected = True
        Catch ex As Exception

        End Try

        sqry = "Select  vehiculos from Tb_VEHICULOS"
        dt = BDClass.SQLtoDataTable(sqry, False)

        cboVehiculo.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cboVehiculo.Items.Add(New ListItem(dt.Rows(i).Item(0), dt.Rows(i).Item(0)))
        Next
        Try
            cboVehiculo.Items.FindByValue(dt1.Rows(0).Item("vehiculo")).Selected = True
        Catch ex As Exception

        End Try
    End Sub
    'Sub PegarCita(ByVal obj As Chip, ByVal sx As Int32, ByVal sy As Int32)

    '    obj.FECHA = CDate(txtCalendar.Text)
    '    obj.TOPPX = sy
    '    obj.LEFTPX = sx
    '    If Validar(obj, "M") Then TablerosUtils.MoverChipCC(obj, sy, sx)



    '    Dim objc As New ArrayList()
    '    For Each d In Me.form1.Controls
    '        If Left(d.id, 2) = "ds" Or Left(d.id, 5) = "ctlll" Then
    '            objc.Add(d.id)
    '        End If
    '    Next
    '    For Each d In objc
    '        If Left(d, 2) = "ds" Or Left(d, 5) = "ctlll" Then
    '            Me.form1.Controls.Remove(Me.form1.FindControl(d))
    '        End If
    '    Next

    '    PINTACHIPS()
    '    refreshDMS()


    'End Sub

    Protected Sub imgAceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgAceptar.Click


        Dim snuevo() As String
        '        sqry +="("
        '        sqry += " noOrden"
        '        sqry += ",idAseso"
        '        sqry += ",fecha"
        '        sqry += ",horaCita"
        '        sqry += ",noPlacas"
        '        sqry += ",Cliente"
        '        sqry += ",Vehiculo"
        '        sqry += ",Color"
        '        sqry += ",Ano"
        '        sqry += ",Cilindros"
        '        sqry += ",tipoCliente"
        '        sqry += ",vin"
        '        sqry += ",ASYS_RENGLON"
        '        sqry += ",diasemana, telefono, correo, observaciones)"


        cboDiaCita.Items.Clear()

        cboDiaCita.Items.Add(New ListItem("Lunes", "1"))
        cboDiaCita.Items.Add(New ListItem("Martes", "2"))
        cboDiaCita.Items.Add(New ListItem("Miercoles", "3"))
        cboDiaCita.Items.Add(New ListItem("Jueves", "4"))
        cboDiaCita.Items.Add(New ListItem("Viernes", "5"))
        cboDiaCita.Items.Add(New ListItem("Sabado", "6"))
        cboDiaCita.Items.Add(New ListItem("Domingo", "0"))
        Select Case session("txtTOp")
            Case "Update"
                ' snuevo = New String() {txtNoCita.Text.Trim, cboAsesor.SelectedItem.Value.Trim, "cast('" & String.Format("{0:s}", CDate(txtFechaCita.Text)) & "' as datetime)", cboHora.SelectedItem.Value.Trim, txtPlacas.Text.Trim, txtCliente.Text.Trim, cboVehiculo.SelectedItem.Value.Trim, txtColor.Text.Trim, txtAño.Text.Trim, txtCilindros.Text.Trim, cboTipoCita.Text.Trim, txtVin.Text.Trim, Right(CDate(lblCalendar.Text).Ticks.ToString, 9), cboDiaCita.Items.FindByValue(CDate(txtFechaCita.Text).DayOfWeek).Text, txtTelefono.Text.Trim, txtxCorreo.Text.Trim, Left(txtObservaciones.Text.Trim, 250)}
                snuevo = New String() {obtenValor("txtNoCita"), obtenValor("cboAsesor"), "cast('" & String.Format("{0:s}", CDate(obtenValor("txtFechaCita"))) & "' as datetime)", obtenValor("cboHora"), obtenValor("txtPlacas"), obtenValor("txtCliente"), obtenValor("cboVehiculo"), obtenValor("txtColor"), IIf(IsNumeric(obtenValor("txtAño")), obtenValor("txtAño"), "2000"), IIf(IsNumeric(obtenValor("txtCilindros")), obtenValor("txtCilindros"), "4"), obtenValor("cboTipoCita"), obtenValor("txtVin"), Right(CDate(lblCalendar.Text).Ticks.ToString, 9), cboDiaCita.Items.FindByValue(CDate(obtenValor("txtFechaCita")).DayOfWeek).Text, obtenValor("txtTelefono"), obtenValor("txtxCorreo"), Left(obtenValor("txtObservaciones"), 250), obtenValor("rdlCampa"), obtenValor("rdlMovilidad"), Left(obtenValor("txtMovilidad"), 50), obtenValor("rdlServiceInclusive"), obtenValor("rdlGarantia"), Left(obtenValor("txtGarantia"), 50), obtenValor("rdlMedio"), obtenValor("rdlContacto")}

                If Validar(snuevo, "Cita") Then
                    TablerosUtilsHyP.ActualizarControlCitasDMS(snuevo)

                    pnlNuevaCita.Visible = False
                    gvDMS.Visible = True

                End If
            Case "Insert"
                snuevo = New String() {TablerosUtilsHyP.ObtenNumeroCita.Trim, obtenValor("cboAsesor"), "cast('" & String.Format("{0:s}", CDate(obtenValor("txtFechaCita"))) & "' as datetime)", obtenValor("cboHora"), obtenValor("txtPlacas"), obtenValor("txtCliente"), obtenValor("cboVehiculo"), obtenValor("txtColor"), IIf(IsNumeric(obtenValor("txtAño")), obtenValor("txtAño"), "2000"), IIf(IsNumeric(obtenValor("txtCilindros")), obtenValor("txtCilindros"), "4"), obtenValor("cboTipoCita"), obtenValor("txtVin"), Right(CDate(lblCalendar.Text).Ticks.ToString, 9), obtenValor("txtFechaCita"), obtenValor("txtTelefono"), obtenValor("txtxCorreo"), Left(obtenValor("txtObservaciones"), 250), obtenValor("rdlCampa"), obtenValor("rdlMovilidad"), Left(obtenValor("txtMovilidad"), 50), obtenValor("rdlServiceInclusive"), obtenValor("rdlGarantia"), Left(obtenValor("txtGarantia"), 50), obtenValor("rdlMedio"), obtenValor("rdlContacto")}
                If Validar(snuevo, "Cita") Then
                    TablerosUtilsHyP.NuevoControlCitasDMSA(snuevo)
                    pnlNuevaCita.Visible = False
                    gvDMS.Visible = True
                End If
        End Select



        refreshDMS()
        gvContainer.Visible = True

    End Sub
    Private Function obtenValor(ByVal ItemRequest As String) As String
        For Each nRequest As String In Request.Form
            If nRequest.LastIndexOf(ItemRequest.Trim) > -1 Then
                Return Request.Form(nRequest).Trim
            End If
        Next
        Return ""
    End Function
    Function Validar(ByVal sArray() As String, ByVal ioperacion As String) As Boolean
        gvDMS.SelectedIndex = -1
        '        sqry +="("
        '        sqry += " noOrden"
        '        sqry += ",idAseso"
        '        sqry += ",fecha"
        '        sqry += ",horaCita"
        '        sqry += ",noPlacas"
        '        sqry += ",Cliente"
        '        sqry += ",Vehiculo"
        '        sqry += ",Color"
        '        sqry += ",Ano"
        '        sqry += ",Cilindros"
        '        sqry += ",tipoCliente"
        '        sqry += ",vin"
        '        sqry += ",ASYS_RENGLON"
        '        sqry += ",diasemana, telefono, correo)"
        Select Case ioperacion
            Case "Cita"
                For i = 0 To sArray.Length - 1
                    If sArray(i).Trim.Length = 0 Then
                        Select Case i
                            Case 4
                                If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "placas") > 0 Then
                                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe capturar las Placas")
                                    Return False
                                End If

                            Case 5
                                If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "cliente") > 0 Then
                                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe capturar el Cliente")
                                    Return False
                                End If

                            Case 7
                                If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "color") > 0 Then
                                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe capturar el Color")
                                    Return False
                                End If

                            Case 8
                                If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "ano") > 0 Then
                                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe capturar el año")
                                    Return False
                                End If
                            Case 9
                                If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "cilindros") > 0 Then
                                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe capturar Cilindros")
                                    Return False
                                End If
                                'Case 10
                                '    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe capturar el Tipo Cliente")
                                '    Return False
                            Case 11
                                If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "vin") > 0 Then
                                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe capturar el vin")
                                    Return False
                                End If
                            Case 14
                                If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "telefono") > 0 Then
                                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe capturar el telefono")
                                    Return False
                                End If
                            Case 15
                                If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "correo") > 0 Then
                                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe capturar el correo")
                                    Return False
                                End If
                            Case 16
                                If InStr(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sCamposCaptura"), "observaciones") > 0 Then
                                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe capturar las observaciones")
                                    Return False
                                End If
                        End Select
                    End If
                Next

            Case "Operacion"
        End Select


        Return True
    End Function

    Protected Sub imgCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles imgCancelar.Click
        pnlNuevaCita.Visible = False
        gvDMS.Visible = True

    End Sub

    Private Sub imgNuevoDMS_Click(sender As Object, e As ImageClickEventArgs) Handles imgNuevoDMS.Click
        Session("buscaChip") = False
        Session("rbDet") = True
        iniciaTablero(False, txtBuscar.Text, True)

        nuevoDMS()
    End Sub

    Private Sub chkAllCitas_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllCitas.CheckedChanged

        If chkAllCitas.Checked Then

            refreshDMSAll()
        Else
            refreshDMS()
        End If
    End Sub

    Private Sub imgBtnDgn_Kdw_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnDgn_Kdw.Click
        Dim iId As Int64
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 5) = "ds00." Then Exit Sub

        'For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
        '    If Left(d.id, 5) = "ctlll" Then
        '        iId = d.Value
        '    End If
        'Next
        iId = obtenid(Split(sdhtml, ".")(0))
        If iId = 0 Then Exit Sub

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then
                Session("NF") = obj.ID

                Exit For
            End If

        Next

        Dim scriptString As String = "<script language='JavaScript'>" _
                                           & " window.open('Diagnostico.aspx', '', 'fullscreen=yes, scrollbars=auto');</script>"

        Page.ClientScript.RegisterStartupScript(GetType(Page), "ShowValue", scriptString)

        bref = True
        iniciaTablero(True, txtBuscar.Text)

    End Sub

    Private Sub imgRefrescar_Click(sender As Object, e As ImageClickEventArgs) Handles imgRefrescar.Click
        iniciaTablero(True, txtBuscar.Text)
    End Sub


    Sub ZedGraphWeb1_RenderGraph(ByVal webObject As ZedGraph.Web.ZedGraphWeb, ByVal g As System.Drawing.Graphics, ByVal pane As ZedGraph.MasterPane)


        Dim myPane As ZedGraph.GraphPane = pane(0)
        myPane.XAxis.Title.Text = "X-Axis"
        myPane.YAxis.Title.Text = "Y-Axis"
        Dim dthlhorarios As DataTable = Session("dthlphorarios")

        Dim iIndex As Integer = CType(webObject.Parent.Parent.Parent, DataGridItem).ItemIndex

        'If Not IsNumeric(CType(dgEstrategias.Items(iIndex).FindControl("lblContactados"), System.Web.UI.WebControls.Label).Text) Then Exit Sub
        'If Not IsNumeric(CTypse(dgEstrategias.Items(iIndex).FindControl("lblTotal"), System.Web.UI.WebControls.Label).Text) Then Exit Sub

        Dim x6() As Double = {0}
        dthlhorarios.DefaultView.RowFilter = "idTecnico='" & dgIndicadores.Items(iIndex).Cells(0).Text & "'"
        If dthlhorarios.DefaultView.Count > 0 Then
            x6 = New Double() {DateDiff(DateInterval.Minute, CType(dthlhorarios.DefaultView(0)("horaEnt"), Date), CType(dthlhorarios.DefaultView(0)("horaSal"), Date)) - CInt(dthlhorarios.DefaultView(0)("comida"))}
        End If


        Dim x3() As Double = {CInt(dgIndicadores.Items(iIndex).Cells(1).Text)}
        Dim x4() As Double = {CInt(dgIndicadores.Items(iIndex).Cells(2).Text)}
        Dim x5() As Double = {CInt(dgIndicadores.Items(iIndex).Cells(3).Text)}
        Dim xllenoint As Double = x6(0) - (x3(0) + x4(0))

        Dim xlleno() As Double = {If(xllenoint < 0, 0, xllenoint)}


        CType(dgIndicadores.Items(iIndex).FindControl("lblPercentage"), System.Web.UI.WebControls.Label).Text = "nadita"
        'Dim x4() As Double = {CInt(CType(dgEstrategias.Items(iIndex).FindControl("lblTotal"), System.Web.UI.WebControls.Label).Text) - CInt(CType(dgEstrategias.Items(iIndex).FindControl("lblContactados"), System.Web.UI.WebControls.Label).Text)}

        Dim labels() As String = {TablerosUtilsHyP.ObtenNombreTecnicos(dgIndicadores.Items(iIndex).Cells(0).Text)}
        Dim legend As ZedGraph.Legend
        Dim myCurve As ZedGraph.BarItem
        myCurve = myPane.AddBar("Con Cita", x3, Nothing, Color.CadetBlue)
        myCurve.Label.IsVisible = True
        myCurve.Label.Text = "prueba"
        myCurve.Bar.Fill.RangeMax = x6(0)

        myCurve.Bar.Fill = New ZedGraph.Fill(Color.Olive, Color.DarkGreen, Color.Olive, 0.0F)
        myCurve = myPane.AddBar("Sin Cita", x4, Nothing, Color.Maroon)
        myCurve.Bar.Fill.RangeMax = x6(0)
        myCurve.Bar.Fill = New ZedGraph.Fill(Color.DarkBlue, Color.DarkBlue, Color.SkyBlue, 0.0F)
        'myCurve = myPane.AddBar("terminado", x5, Nothing, Color.Maroon)
        'myCurve.Bar.Fill.RangeMax = x6(0)
        'myCurve.Bar.Fill = New ZedGraph.Fill(Color.GreenYellow, Color.YellowGreen, Color.GreenYellow, 0.0F)
        myCurve = myPane.AddBar("lleno", New Double() {xlleno(0)}, Nothing, Color.Snow)
        myCurve.Bar.Fill.RangeMax = xlleno(0)
        myCurve.Bar.Fill = New ZedGraph.Fill(Color.Snow, Color.Snow, Color.Snow, 0.0F)

        CType(dgIndicadores.Items(iIndex).FindControl("lblPercentage"), System.Web.UI.WebControls.Label).Text = CInt(x3(0) / x6(0) * 100) & "%"
        CType(dgIndicadores.Items(iIndex).FindControl("lblPercentage2"), System.Web.UI.WebControls.Label).Text = CInt(x4(0) / x6(0) * 100) & "%"
        CType(dgIndicadores.Items(iIndex).FindControl("lblPercentage3"), System.Web.UI.WebControls.Label).Text = CInt((x6(0) - x4(0) - x3(0)) / x6(0) * 100) & "%"




        'CType(dgIndicadores.Items(iIndex).FindControl("lblPercentage"), System.Web.UI.WebControls.Label).Text = CInt(x3(0)) & "mins."
        'CType(dgIndicadores.Items(iIndex).FindControl("lblPercentage2"), System.Web.UI.WebControls.Label).Text = CInt(x4(0)) & "mins."
        'CType(dgIndicadores.Items(iIndex).FindControl("lblPercentage3"), System.Web.UI.WebControls.Label).Text = CInt(x6(0) - x4(0) - x3(0)) & "mins."

        'myPane.Legend.Fill = New ZedGraph.Fill(Color.White, Color.FromArgb(255, 255, 250), 1200.0F)
        'myPane.Legend.IsVisible = True

        myPane.BarSettings.Base = ZedGraph.BarBase.Y
        myPane.YAxis.Scale.TextLabels = labels


        myPane.YAxis.Type = ZedGraph.AxisType.Text

        myPane.XAxis.MajorTic.IsBetweenLabels = True
        Dim myText As ZedGraph.TextObj = New ZedGraph.TextObj("Interesting / nPoint", 230.0F, 70.0F)
        myText.FontSpec.FontColor = Color.Red
        myText.Location.AlignH = ZedGraph.AlignH.Center
        myText.Location.AlignV = ZedGraph.AlignV.Top
        myPane.GraphObjList.Add(myText)



        myPane.Chart.Fill = New ZedGraph.Fill(Color.Gray, Color.Snow, 45.0F)

        myPane.BarSettings.Type = ZedGraph.BarType.Stack
        ' myCurve.CreateBarLabels(myPane, False, 45.0F)
        pane.AxisChange(g)

    End Sub
    Sub llenaindicadores()
        Dim objCHIPCol As New CHIPHYPCollection, dr As DataRow
        Dim dtIndicadores As New DataTable

        dtIndicadores.Columns.Add("id")
        dtIndicadores.Columns.Add("ocupadoc")
        dtIndicadores.Columns.Add("ocupados")
        dtIndicadores.Columns.Add("total")
        dtIndicadores.Columns.Add("dia")
        Dim y, x, w, z
        Dim i As Integer = 0

        objCHIPCol = Session("ColChipsP")

        If objCHIPCol Is Nothing Then Exit Sub

        Dim iFecha As Date = CDate(txtCalendar.Text)
        Dim iFechaIni As New Date(CDate(iFecha).AddDays(-CInt(iFecha.DayOfWeek) + 1).Year, CDate(iFecha).AddDays(-CInt(iFecha.DayOfWeek) + 1).Month, CDate(iFecha).AddDays(-CInt(iFecha.DayOfWeek) + 1).Day)
        Dim iFechaFin As New Date(CDate(iFecha).AddDays(inumDias - CInt(iFecha.DayOfWeek)).Year, CDate(iFecha).AddDays(inumDias - CInt(iFecha.DayOfWeek)).Month, CDate(iFecha).AddDays(inumDias - CInt(iFecha.DayOfWeek)).Day)

        Do While iFechaIni <= iFechaFin
            i = i + 1
            y = (From p As ChipHYP In objCHIPCol Where p.FECHA.ToShortDateString = iFechaIni.ToShortDateString And p.IDTECNICO <> "" Select p.IDTECNICO).Distinct()

            For Each c In y
                x = (From p As ChipHYP In objCHIPCol Where p.FECHA.ToShortDateString = iFechaIni.ToShortDateString And p.IDTECNICO = c.ToString() And p.NUMCITA <> 0 Group p By p.IDTECNICO Into Group Select total = Group.Sum(Function(p) (p.SERVICIO))).FirstOrDefault()
                w = (From p As ChipHYP In objCHIPCol Where p.FECHA.ToShortDateString = iFechaIni.ToShortDateString And p.IDTECNICO = c.ToString() And p.NUMCITA = 0 Group p By p.IDTECNICO Into Group Select total = Group.Sum(Function(p) (p.SERVICIO))).FirstOrDefault()
                z = (From p As ChipHYP In objCHIPCol Where p.FECHA.ToShortDateString = iFechaIni.ToShortDateString And p.IDTECNICO = c.ToString() Group p By p.IDTECNICO Into Group Select total = Group.Sum(Function(p) (p.SERVICIO))).FirstOrDefault()

                dr = dtIndicadores.NewRow
                dr.ItemArray = New Object() {c, IIf(x Is Nothing, 0, x), IIf(x Is Nothing, 0, w), z, CInt(iFechaIni.DayOfWeek)}
                dtIndicadores.Rows.Add(dr)
            Next

            iFechaIni = iFechaIni.AddDays(1)
        Loop
        dgIndicadores.DataSource = dtIndicadores
        dgIndicadores.DataBind()

    End Sub
    Private Sub dgIndicadores_PreRender(sender As Object, e As EventArgs) Handles dgIndicadores.PreRender
        Dim dthlhorarios As DataTable = Session("dthlphorarios")
        Dim i As Integer
        Dim sfilter As String = ""
        For i = 0 To dgIndicadores.Items.Count - 1
            sfilter = "idTecnico='" & dgIndicadores.Items(i).Cells(0).Text & "' and dia='" & dgIndicadores.Items(i).Cells(4).Text & "'"

            dthlhorarios.DefaultView.RowFilter = sfilter
            If dthlhorarios.DefaultView.Count > 0 Then
                CType(dgIndicadores.Items(i).FindControl("divzed"), HtmlGenericControl).Style.Value = "position:absolute;left:" & dthlhorarios.DefaultView(0)("posx") & ";top:" & dthlhorarios.DefaultView(0)("posy") & ";"

            End If
        Next

    End Sub

    Protected Sub muestraMensaje(ByVal m As String)
        Response.Write("<script>window.alert('" & m & "');</script>")
    End Sub

    Protected Sub muestraMensaje2(ByVal m As String)
        Response.Write("<script>window.alert('" & m & "');</script>")
    End Sub
End Class