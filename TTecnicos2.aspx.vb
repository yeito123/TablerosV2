
Imports TablerosV2LibTypes
Partial Public Class TTecnicos2
    Inherits System.Web.UI.Page
    Const iTablero As Integer = 2
    Dim bref As Boolean
    Dim inumHoras As Integer = 0
    Dim inumDias As Integer = 0
    Const inumLeft As Integer = 0
    Dim iHorai As Integer = 0, ifactor2 As Double
    Dim ifac As Double = (59.4) * inumHoras
    Dim iCurrentV As Integer = 0
    Dim iTotalV As Integer = 0

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

        ifactor2 = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "Relacion2")



        ifac = (59.4) * inumHoras
        ifac = ifac * ifactor2

        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "Leyendas") <> "" Then
            divLeyendas.Visible = True
        Else
            divLeyendas.Visible = False
        End If
        If Session("iCurrentV") Is Nothing Then Session("iCurrentV") = iCurrentV

    End Sub


    'Sub LlenaListaServicios()
    '    Dim dt As New DataTable
    '    Dim sqry As String = ""


    '    sqry = "Select distinct idConcepto, isnull(describeconcepto,''),describeconcepto ,color from " & System.Web.Configuration.WebConfigurationManager.AppSettings("tbServicios") & "  "
    '    dt = BDClass.SQLtoDataTable(sqry, False)

    '    DataList1.DataSource = dt

    '    DataList1.DataBind()

    'End Sub
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
                Orden.Text = "Orden " & obj.IDBLINSUR
                Placas.Text = "Placa: " & obj.NOPLACAS
                dchp.Style.Add("Left", ssLeft)
                dchp.Style.Add("Top", ssTop)

                dchp.Focus()
                Exit For
            End If

        Next

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' If InStr(Page.AppRelativeVirtualPath, Session("URL")) = 0 Or Session("URL") Is Nothing Then Response.Redirect("Login.aspx")
        LlenaAsesores()
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Not Page.IsPostBack Then
            bref = True
        End If
        If Session("fase") Is Nothing Then
            Session("fase") = 0
        End If

        iniciaTablero(True, txtBuscar.Text)


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
    Private Sub DataList2_PreRender(sender As Object, e As EventArgs) Handles DataList2.PreRender
        For i = 0 To DataList2.Items.Count - 1
            Try
                CType(DataList2.Items(i).Controls(1), Label).Style.Value = "color:" & CType(DataList2.Items(i).Controls(1), Label).Text & ";background-color:" & CType(DataList2.Items(i).Controls(1), Label).Text & ";"

            Catch ex As Exception

            End Try
        Next
    End Sub
    Sub LlenaAsesores()
        Dim dt As New DataTable
        Dim sqry As String = ""


        sqry = "Select nombre,color from SccUsuarios  WHERE isnull(cveasesor,'')<>'' "
        dt = BDClass.SQLtoDataTable(sqry, False)

        DataList2.DataSource = dt

        DataList2.DataBind()

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



        iTotalV = dt0.Count





        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumtecs") <> "" And Not Session("iCurrentV") Is Nothing Then
            iCurrentV = Session("iCurrentV")
            dt0.RowFilter = "idrow>" & iCurrentV & " and idrow<=" & iCurrentV + CInt(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumtecs")) & ""

        End If


        Dim txtMec As Label, txtNiv As Label
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

        Dim II As Integer = leftfix.Controls.Count
        For i = (II - 1) To 0 Step -1
            If Left(leftfix.Controls(i).ID, 6) = "txtMec" Then
                leftfix.Controls.RemoveAt(i)
            ElseIf Left(leftfix.Controls(i).ID, 6) = "txtNiv" Then
                leftfix.Controls.RemoveAt(i)
            End If
        Next
        Dim ITOT As Decimal
        Dim converter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color))
        Dim color As System.Drawing.Color, sColor As String





        For i = 0 To dt0.Count - 1


            ITOT = 0
            txtMec = New Label
            txtMec.ID = "txtMec" & dt0(i)("Bahia") & i
            sColor = dt0(i)("color")
            'color = color.FromArgb(255, 255 - (CType(converter.ConvertFromString(sColor), System.Drawing.Color).R), 255 - (CType(converter.ConvertFromString(sColor), System.Drawing.Color).G), 255 - (CType(converter.ConvertFromString(sColor), System.Drawing.Color).B))

            txtMec.Style.Value = "position:absolute;left:1px;top:" & ktop + 2 & "px;width:85px;height:52px;background-color:" & dt0(i)("color") & ";color:" & System.Drawing.ColorTranslator.ToHtml(color) & ";Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:0.688em;border:solid 1px black;"
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


                If CDate(txtCalendar.Text).AddDays(j).DayOfWeek <> DayOfWeek.Saturday Then


                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioC" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("hora_comer")) And dt0(i)("min_comer_lv") <> "0" Then
                        sPosX1 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("hora_comer")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("hora_comer")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("hora_comer")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92
                        sPosX2 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("hora_comer")).AddMinutes(dt0(i)("min_comer_lv")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("hora_comer")).AddMinutes(dt0(i)("min_comer_lv")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("hora_comer")).AddMinutes(dt0(i)("min_comer_lv")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92

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
                        sPosX1 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_SAL_LV")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("HORA_SAL_LV")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("HORA_SAL_LV")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92

                        sPosX2 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + ((inumHoras) * 60 * ((ifac / inumHoras) / 60)) + 92

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
                        sPosX1 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + 92
                        sPosX2 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_ENT_LV")).Hour * 60) + CDate(dt0(i)("HORA_ENT_LV")).Minute - (iHorai * 60)) > 0, ((CDate(dt0(i)("HORA_ENT_LV")).Hour * 60) + CDate(dt0(i)("HORA_ENT_LV")).Minute - (iHorai * 60)), 0) + 92
                        sPosX2 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + ((TimeSpan.Parse(dt0(i)("HORA_ENT_LV")).TotalMinutes - (iHorai * 60)) * ((ifac / inumHoras) / 60)) + 92
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
                        sPosX1 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("hora_comer_s")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("hora_comer_s")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("hora_comer_s")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92
                        sPosX2 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92

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
                        sPosX1 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_SAL_S")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("HORA_SAL_S")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("HORA_SAL_S")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92

                        sPosX2 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + ((inumHoras) * 60 * ((ifac / inumHoras) / 60)) + 92

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
                        sPosX1 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + 92
                        sPosX2 = ((CDate(txtCalendar.Text).DayOfYear - (CDate(txtCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_ENT_S")).Hour * 60) + CDate(dt0(i)("HORA_ENT_S")).Minute - (iHorai * 60)) > 0, ((CDate(dt0(i)("HORA_ENT_S")).Hour * 60) + CDate(dt0(i)("HORA_ENT_S")).Minute - (iHorai * 60)), 0) + 92

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
            If iTablero <> 1 Then
                txtNiv = New Label
                txtNiv.ID = "txtNiv" & dt0(i)("Bahia") & i & "A"
                txtNiv.Style.Value = "position:absolute;left:90px;top:" & ktop + 94 & "px;width:5px;height:24px;background-color:White;Font-weight:bold;font-family:Arial;font-size:10px;border:solid 1px silver;"
                txtNiv.Text = "P"
                form1.Controls.Add(txtNiv)
                txtNiv = New Label
                txtNiv.ID = "txtNiv" & dt0(i)("Bahia") & i & "B"
                txtNiv.Style.Value = "position:absolute;left:90px;top:" & ktop + 94 + 25 & "px;width:5px;height:24px;background-color:White;Font-weight:bold;font-family:Arial;font-size:10px;border:solid 1px silver;"
                txtNiv.Text = "T"
                form1.Controls.Add(txtNiv)
            End If
            dt.DefaultView.RowFilter = "Bahia='" & dt0(i)("Bahia") & "' "
            dvTecnicos = dt.DefaultView
            'dtPos.Rows.Add(New Object() {dt0(i)("id_empleado"), txtMec.ID, ktop + 2, txtNiv.ID, dvTecnicos(0)("noorden"), ktop + 94})

            For k = 0 To dvTecnicos.Count - 1

                'txtNiv = New Label
                'txtNiv.ID = "txtNiv" & dt0(i)("Bahia") & "_" & i & "_" & dvTecnicos(k)("noorden")
                'txtNiv.Style.Value = "position:absolute;left:31px;top:" & ktop + 2 & "px;width:55px;height:26px;background-color:#eeeee0;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:10px;border:solid 1px black;"
                'txtNiv.Text = dvTecnicos(k)("noplacas")
                'leftfix.Controls.Add(txtNiv)
                dtPos.Rows.Add(New Object() {dt0(i)("id_empleado"), txtMec.ID, ktop + 2, txtMec.ID, dvTecnicos(k)("noorden"), ktop + 94})
                ITOT = ITOT + Val(dvTecnicos(k)("servicio"))

                'ktop = ktop + 27





            Next
            ITOT = System.Math.Round(ITOT / 60, 1)
            txtMec.ToolTip = "Total Servicios: " & ITOT & " horas"

            leftfix.Controls.Add(txtMec)


            ktop = ktop + 60

        Next

        Session("dtPosY") = dtPos


        Session.Remove("ObtenAusencias")
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



        iTotalV = dt.Count





        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumtecs") <> "" And Not Session("iCurrentV") Is Nothing Then
            iCurrentV = Session("iCurrentV")
            dt.RowFilter = "idrow>" & iCurrentV & " and idrow<=" & iCurrentV + CInt(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumtecs")) & ""



        End If

        iNumbahias = dt.Count

        Session("ColChipsP") = OBJCOL


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
        ilargo = ((iNumbahias) * 60) + 92

        If bTecnicos Then

            'If form1.FindControl("txtPos") Is Nothing Then
            '    Dim txtPos As New HtmlGenericControl("div")
            '    txtPos = New HtmlGenericControl("div")
            '    txtPos.ID = "txtPos"
            '    txtPos.Style.Value = "position:absolute;left:" & CInt(((((Date.Now.DayOfYear - Date.Now.AddDays(-1).DayOfYear - 2 - CDATES.iDomingos(Date.Now)) * 24) + Date.Now.Hour) / 3) * 9.4369999999999994) & "px;top:0px;width:1px;height:1px;background-color:White;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:10px;border:solid 1px silver;text-align:center;"
            '    form1.Controls.Add(txtPos)
            'End If



            sScript += "<script type='text/javascript'>" & vbCrLf
            sScript += "var jg_doc = new jsGraphics();" & vbCrLf
            'sScript += "var days = " & Date.Now.DayOfYear + (3 - Date.Now.DayOfYear - 2) - CDATES.iDomingos(Date.Now) & ";" & vbCrLf

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
            sScript += "lx = parseInt(lx*" & ifactor2 & ");" & vbCrLf
            sScript += "jg_doc.fillRect(92, 94, lx, " & ilargo - 92 & ");}" & vbCrLf


            ''
            sScript += " var ejeX=206; var ejeY=94; " & vbCrLf
            If iTablero <> 1 Then
                sScript += " for(var d_i = 1; d_i <= " & iNumbahias & "; d_i++){ " & vbCrLf
            Else
                sScript += " for(var d_i = 1; d_i <= " & iNumbahias * 6 & "; d_i++){ " & vbCrLf

            End If
            ' " & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid") & "

            sScript += "    ejeY += 60; " & vbCrLf
            sScript += "    if (d_i == " & iNumbahias & " || d_i == " & iNumbahias * 2 & "  || d_i == " & iNumbahias * 3 & "  || d_i == " & iNumbahias * 4 & " || d_i == " & iNumbahias * 5 & "){" & vbCrLf
            sScript += "        jg_doc.setColor('Black');   jg_doc.fillRect(0, ejeY, " & iwidth + 92 & ", 2);} " & vbCrLf
            sScript += "    else{jg_doc.setColor('Darkslategray');jg_doc.drawLine(0, ejeY, " & iwidth + 92 & ", ejeY);} " & vbCrLf

            sScript += "    jg_doc.setColor('#EEEEE0');jg_doc.fillRect(0, ejeY-30, " & iwidth + 92 & ", 30); " & vbCrLf
            'sScript += "    jg_doc.setColor('#E0FFFF');jg_doc.fillRect(0, ejeY-60, " & iwidth + 92 & ", 30); " & vbCrLf

            sScript += " }" & vbCrLf


            '


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

            sScript += " for(var d_d = 1; d_d < 13; d_d++){ posX3=posX3+(4.95*" & ifactor2 & ");" & vbCrLf
            sScript += " jg_doc.setColor('" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid") & "'); jg_doc.drawLine(posX3, 92, posX3, " & ilargo & ");" & vbCrLf
            sScript += "               }" & vbCrLf

            sScript += "                jg_doc.setColor('" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid") & "'); jg_doc.drawLine(posX2, 92, posX2, " & ilargo & ");" & vbCrLf
            sScript += "                jg_doc.setColor('" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid2") & "'); jg_doc.drawLine(posX2+((60/2)*" & ifactor2 & "), 92, posX2+((60/2)*" & ifactor2 & "), " & ilargo & ");" & vbCrLf
            'sScript += "                jg_doc.setColor('Snow'); jg_doc.drawLine(posX2+(59.437/2), 92, posX2+(59.437/2), " & ilargo & ");" & vbCrLf


            sScript += "                posX2=posX2+(59.437*" & ifactor2 & ");}" & vbCrLf
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

            Dim ddate As Date = Now.Date.AddDays(-inumLeft)
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
                txtDia3.InnerHtml = "<table border='0' cellspacing=0 cellpadding=0  ><tr>"
                For ii = 0 To inumHoras - 1
                    txtDia3.InnerHtml = txtDia3.InnerHtml & "<td  style='border:solid 1px black; width:" & Math.Round(ifac / inumHoras, MidpointRounding.ToEven) & "px;background-color:White;' >" & String.Format("{00:d}", ii + iHorai) & ":00</td>"

                Next
                txtDia3.InnerHtml = txtDia3.InnerHtml & "</tr></table>"
                txtDia2.Controls.Add(txtDia3)
                If form1.FindControl(txtDia2.ID) Is Nothing Then
                    floatdiv.Controls.Add(txtDia2)
                End If
                'If ddate.AddDays(i - 1).DayOfWeek <> DayOfWeek.Sunday Then 'sunday
                '    txtDia2.ID = "txtDia" & ddate.AddDays(i - 1).DayOfYear

                '    txtDia2.Style.Value = "position:absolute;left:" & 91 + (475.5 * ((i - 1) - idomingos)) & "px;top:70px;width:475.5px;height:20px;background-color:White;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:15px;border:solid 1px silver;text-align:center;"

                '    txtDia2.InnerText = ddate.AddDays(i - 1).ToShortDateString
                '    dtPosDias.Rows.Add(New Object() {CDate(txtDia2.InnerText), 91 + (475.5 * ((i - 1) - idomingos))})

                '    txtDia3.Style.Value = "width:59.5px;height:10px;background-color:White;Font-weight:bold;font-family:Arial;font-size:12px;border:solid 1px silver;text-align:center;"
                '    txtDia3.InnerHtml = "<table border='1'  style='width:475.5px;'><tr><td>09:00</td><td>10:00</td><td>11:00</td><td>12:00</td><td>13:00</td><td>14:00</td><td>16:00</td><td>17:00</td></tr></table>"
                '    txtDia2.Controls.Add(txtDia3)

                '    If form1.FindControl(txtDia2.ID) Is Nothing Then
                '        floatdiv.Controls.Add(txtDia2)
                '    End If


                'Else
                '    idomingos = idomingos + 1
                'End If


                ' floatdiv.Controls.Add(txtDia.ID)

            Next
            Session("dtPosDias") = dtPosDias
        End If



        'DataList1.DataSource = dtFases

        'DataList1.DataBind()


        Dim imgLst As New ArrayList()
        Dim xleft As Integer = -100, III As Integer = 20
        imgLst.Clear()

        Dim imgLstPosMec As New DataTable
        imgLstPosMec.Columns.Add("ID")
        imgLstPosMec.Columns.Add("noorden")
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

            txtMec.Style.Value = "position:absolute;top:" & ((Fix((i - 1) / III)) * 32) + 75 & "px;left:" & xleft + 5 & "px;width:100px;height:50px;background-color:" & "#fff" & ";Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:12px;border:solid 1px black;"
            txtMec.Text = objchip.NOPLACAS & " Orden:" & objchip.IDBLINSUR & vbCrLf & "Unidad: " & objchip.VEHICULO & vbCrLf & "Bahia: " & objchip.NOPRISMA
            txtMec.ToolTip = "Tipo: " & objchip.TIPOCLIENTE & vbCrLf & "Servicio: " & objchip.SERVICIOCAPTURADO & vbCrLf & "Comentarios: " & objchip.OBSERVACIONES & ""
            dtTemp = TablerosUtilsHyP.ObtenServiciosxNoorden(objchip.NOORDEN)
            If dtTemp.Rows.Count > 0 Then
                txtMec.ToolTip += vbCrLf & "Tareas:" & vbCrLf
                For ii As Integer = 0 To dtTemp.Rows.Count - 1
                    txtMec.ToolTip += "- " & dtTemp.Rows(ii).Item(0).ToString & vbCrLf
                Next
            End If


            txtMec.Attributes.Add("class", "menu")
            leftfix0.Controls.Add(txtMec)
            imgLst.Add(txtMec.ID)

            imgLstPosMec.Rows.Add(New Object() {objchip.ID, objchip.NOORDEN, objchip.IDSERVICIO, objchip.NOPLACAS, objchip.CLIENTE, txtMec.ID, 95 + ((50) * (i - 1))})
            AgregaInfo(txtMec.ID, objchip.ID & "___" & objchip.NOORDEN & "___" & objchip.NOPLACAS & "___" & objchip.IDSERVICIO & "___" & objchip.COLORPRISMA & "___" & objchip.CLIENTE & "___" & objchip.ASYSRENGLON & "___" & objchip.SERVICIOCAPTURADO & "___" & objchip.HORAASESOR & "___" & objchip.VEHICULO & "___" & objchip.VIN & "___" & objchip.AÑO & "___" & objchip.COLOR & "___" & objchip.IDASESOR & "___" & objchip.TELEFONOS & "___" & objchip.SERVICIO & "___" & objchip.IDITEM & "___" & objchip.NOPRISMA & "___" & objchip.TIPOCLIENTE & "___" & objchip.FECHA & "___" & objchip.HORAASESOR & "___" & objchip.IDBLINSUR)

            'objchip.NOORDEN = sValores(1)

            'objchip.NOPLACAS = sValores(2)
            'objchip.IDSERVICIO = sValores(3)
            'objchip.SERVICIO = 24 '*
            'objchip.COLORPRISMA = sValores(4)
            'objchip.CLIENTE = sValores(5)
            'objchip.ASYSRENGLON = sValores(6)
            'objchip.SERVICIOCAPTURADO = sValores(7)
            'objchip.HORAASESOR = sValores(8)
            'objchip.VEHICULO = sValores(9)
            'objchip.VIN = sValores(10)
            'objchip.AÑO = sValores(11)
            'objchip.COLOR = sValores(12)
            'objchip.IDASESOR = sValores(13)
            'objchip.TELEFONOS = sValores(14)
        Next

        Session("imgLst") = imgLst
        Session("imgLstPosMec") = imgLstPosMec







        iniciaTablero2()
        PINTACHIPS()
        Session.Remove("ObtenAusencias")
    End Sub
    Protected Sub lblDescFase_click(ByVal sender As Object, ByVal e As EventArgs)
        Session("fase") = CType(CType(sender.parent, DataListItem).FindControl("lblFase"), Label).Text

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
        Dim sstop As String
        Dim imgLst As New ArrayList(), bAlarm As Boolean = False, bAlarmF As Boolean = False
        imgLst = Session("imgLst")


        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "CitasVista").ToString = "1" Then
            OBJCOL = OBJCOL.ObtenChipsAllPCitasView(Request.Url.Segments(Request.Url.Segments.Length - 1), CDate(lblCalendar.Text))

        Else
            OBJCOL = OBJCOL.ObtenChipsAllP(Request.Url.Segments(Request.Url.Segments.Length - 1), CDate(lblCalendar.Text))

        End If

        Session("ColChipsP") = OBJCOL
        For i = 1 To OBJCOL.Count
            bAlarmF = False
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
                    Case "servicio", "cita normal", "cita", "citas"
                        oChip = "dg"
                    Case "reclamacion", "reclamaciones"
                        oChip = "dgr"
                    Case "express"
                        oChip = "dge"
                    Case "retrabajo"
                        oChip = "dwr"
                    Case "internet"
                        oChip = "dgi"
                    Case "diagnostico"
                        oChip = "dgd"
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
                If objchip.STATUS.ToLower = "detenida" Or objchip.STATUS.ToLower = "iniciada" Or objchip.STATUS.ToLower = "reiniciada" Then
                    iNivel = 0

                    sstop = CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.NOORDEN & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") + 30 & "px"
                Else
                    iNivel = 1
                    sstop = CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.NOORDEN & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") & "px"
                End If

                If objchip.STATUS.ToLower = "terminado" Then
                    If objchip.STATUSOS = "Calidad" Or objchip.STATUSOS = "PruebaRuta" Or objchip.STATUSOS = "EnPruebaCalidad" Then
                        oChip = "dwc"
                        iNivel = 0
                        sstop = CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.NOORDEN & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") + 30 & "px"
                    Else
                        oChip = "dl"
                        iNivel = 0
                        sstop = CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.NOORDEN & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") + 30 & "px"
                    End If
                End If
            Catch ex As Exception
                sstop = "0px"
            End Try


            If objchip.VHSERVERMINADO = False Then
                If objchip.VHRECEPCION = False And CDate(objchip.FECHA.ToShortDateString & " " & objchip.HORAASESOR).AddMinutes(15) < Date.Now Then
                    If objchip.CARRYOVER = False And objchip.TIPOCLIENTE.Trim.ToLower <> "express" Then
                        If CDate(objchip.FECHA.ToShortDateString & " " & objchip.HORACITA) < Date.Now Then
                            oChip = "dn"

                        End If
                    End If

                End If
            End If

            imgLst.Add("ds" & String.Format("{0:000}", i))

            If CDate(objchip.FECHA.ToShortDateString & " " & objchip.HORARAMPA) <= Date.Now And objchip.STATUS.ToLower = "pendiente" Then
                bAlarm = True
            Else
                bAlarm = False
            End If

            If objchip.STATUS.ToLower = "iniciada" Then
                Dim tiempoT As TimeSpan = Date.Now.TimeOfDay - objchip.FECHAHORAINIOPER.TimeOfDay
                Dim tiempoH = CInt(tiempoT.Hours) * 60
                Dim tiempoM = CInt(tiempoT.Minutes)

                Dim tiempoTrancu As DateTime = objchip.FECHAHORAINIOPER.AddMinutes(tiempoH + tiempoM)
                Dim tiempoIDeal As DateTime = objchip.FECHAHORAINIOPER.AddMinutes(objchip.SERVICIO)
                If tiempoTrancu >= tiempoIDeal Then
                    bAlarmF = True
                End If
            End If

            If objchip.STATUSOS <> "SSINCARGO" And objchip.STATUSOS <> "Facturado" And objchip.STATUSOS <> "Remisionado" Then
                Try
                    If Val(sstop) <> 0 Then
                        'chipBoard(i, oChip, objchip.IDCHIP, CInt((objchip.SERVICIO / 60) * 9.437), objchip.NOORDEN, ((CDate(objchip.FECHA).DayOfYear - (Date.Now.AddMonths(-1).DayOfYear)) * 75.5) + IIf(((CDate(objchip.HORARAMPA).Hour - 9 - 1) * 9.437) > 0, ((CDate(objchip.HORARAMPA).Hour - 9 - 1) * 9.437), 0) + 92 & "px", CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.NOORDEN & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") & "px", sColor, sColorServicio, objchip.ID, objchip.NOPLACAS, objchip.SERVICIO, objchip.OBSERVACIONES)
                        chipBoard(i, oChip, objchip.IDCHIP, CInt((objchip.SERVICIO / 60) * (ifac / inumHoras)), objchip.VEHICULO, ((CDate(objchip.FECHA).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(objchip.HORARAMPA).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(objchip.HORARAMPA).Hour * 60) - (iHorai * 60)) + CDate(objchip.HORARAMPA).Minute) * ((ifac / inumHoras) / 60)), 0) + 92 & "px", sstop, sColor, sColorServicio, objchip.ID, objchip.SERVICIOCAPTURADO, objchip.SERVICIO, objchip.OBSERVACIONES, bAlarm, objchip, bAlarmF)
                        '((CDate(objchip.HORARAMPA).Minute +((CDate(objchip.HORARAMPA).Hour * 60) - (9 * 60)) ) * (59/60) )+92
                    End If
                Catch ex As Exception

                End Try
            End If

        Next

        Session("imgLst") = imgLst
    End Sub
    Sub AgregaInfo(ByVal sIdControl As String, ByVal sString As String)

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

    Function ObtenToppx(ByVal noorden As String, ByVal sidservicio As String, ByVal snoplacas As String, ByVal scliente As String, ByVal iNivel As Integer) As String
        Dim dt As DataTable = Session("imgLstPosMec")
        dt.DefaultView.RowFilter = "noorden='" & noorden & "' and idservicio='" & sidservicio & "' and noplacas='" & snoplacas & "' and cliente='" & scliente & "'"
        If dt.DefaultView.Count > 0 Then
            If iNivel = 1 Then
                Return CInt(dt.DefaultView(0)("toppx")) + 25 & "px"
            Else
                Return dt.DefaultView(0)("toppx") & "px"
            End If

        Else
            Return "0px"
        End If

    End Function

    Sub AplicaNivel(ByVal noorden As String, ByVal sidservicio As String, ByVal snoplacas As String, ByVal scliente As String, ByVal iNivel As Integer)
        Dim dt As DataTable = Session("imgLstPosMec")
        Dim LBL As HtmlGenericControl, LBL2 As HtmlGenericControl
        dt.DefaultView.RowFilter = "noorden='" & noorden & "' and idservicio='" & sidservicio & "' and noplacas='" & snoplacas & "' and cliente='" & scliente & "'"
        If dt.DefaultView.Count > 0 Then
            LBL = New HtmlGenericControl("div")
            LBL2 = New HtmlGenericControl("div")
            If iNivel = 1 Then
                LBL.ID = dt.DefaultView(0)("idControl") & "lblStT" & dt.DefaultView(0)("idservicio")
                LBL.Style.Value = "position:absolute;left:70px;top:25px;width:15px;height:20px;background-color:transparent;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:10px;border:solid 1px black;"
                LBL.InnerText = "T"
                LBL2.ID = dt.DefaultView(0)("idControl") & "lblStT2" & dt.DefaultView(0)("idservicio")
                LBL2.Style.Value = "position:absolute;left:0px;top:0px;background-color:transparent;"
                LBL2.InnerText = CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Text
                ' LBL. = "Trabajando"
                CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Controls.Add(LBL2)
                CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Controls.Add(LBL)

            Else
                LBL.ID = dt.DefaultView(0)("idControl") & "lblStP" & dt.DefaultView(0)("idservicio")
                LBL.Style.Value = "position:absolute;left:70px;top:0px;width:15px;height:20px;background-color:transparent;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:10px;border:solid 1px black;"
                LBL.InnerText = "P"
                LBL2.ID = dt.DefaultView(0)("idControl") & "lblStP2" & dt.DefaultView(0)("idservicio")
                LBL2.Style.Value = "position:absolute;left:0px;top:0px;background-color:transparent;"
                LBL2.InnerText = CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Text
                ' LBL.ToolTip = "Planeado"
                CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Controls.Add(LBL2)
                CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Controls.Add(LBL)
            End If


        End If

    End Sub

    Function imageCHIP(ByVal sChip As String, ByVal objChip As ChipHYP) As String

        Return SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), sChip)



    End Function


    Sub chipBoard(ByVal numberChip As Integer, ByVal sChip As String, ByVal iItem As Integer, ByVal iTime As Integer, ByRef sTexto As String, ByVal sL As String, ByVal sT As String, ByVal sColor As String, ByVal sColorServicio As String, ByVal iId As Integer, ByVal sServicioCapturado As String, ByVal sServicio As String, ByVal sObservaciones As String, ByVal bAlarm As Boolean, ByVal objChip As ChipHYP, ByVal bAlarmF As Boolean)


        Dim sDiv, sWidth, sImageChip As String


        Dim lbl1 As String = "", lbl2 As String = "", lbl3 As String = "", lbl4 As String = ""
        Dim iPos1 As Integer



        sDiv = "ds" & String.Format("{0:000}", numberChip)

        sImageChip = imageCHIP(sChip, objChip)

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


        displayChip(iId, sDiv, sL, sT, sWidth, sImageChip, sColor, sColorServicio, iTime, lbl1, sChip, lbl3, lbl4, sServicioCapturado, sServicio, sObservaciones, bAlarm, objChip, bAlarmF)




    End Sub
    Sub displayChip(ByVal iItem As Integer, ByVal sDiv As String, ByVal sL As String, ByVal sT As String, ByVal sWidth As String, ByVal sImageChip As String, ByVal sColor As String, ByVal scolorservicio As String, ByVal iTime As Integer, ByVal lblChp1 As String, ByVal lblChp2 As String, ByVal lblChp3 As String, ByVal lblChp4 As String, ByVal sServiciocapturado As String, ByVal sServicio As String, ByVal sObservaciones As String, ByVal bAlarm As Boolean, ByVal objChip As ChipHYP, ByVal bAlarmF As Boolean)


        Dim iDiv As Integer
        Dim lbl1 As String

        iDiv = Val(Right(sDiv, 3))
        lbl1 = "lb" & Right(sDiv, 3) & "1"

        Dim ixdivId As New HtmlInputHidden
        ixdivId.Value = iItem
        ixdivId.ID = "ctlll_" & iItem

        Dim ixdiv As New HtmlGenericControl("div")
        ixdiv.ID = sDiv

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





        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "colorcaptura").ToString = "1" Then
            ' ixdiv.Style.Add("filter", "progid:DXImageTransform.Microsoft.gradient(startColorstr=" & sImageChip & ", endColorstr=" & TablerosUtilsHyP.ObtenColorIdSErvicio(objChip.IDSERVICIO) & ", GradientType=3)")
            '   ixdiv.Style.Add("background", "-webkit-gradient(radial,center center,0,center center,60,from(#FFFFFF),to(" & sImageChip & "))")
            ixdiv.Style.Add("background", "-moz-linear-gradient(left, " & sImageChip & ", " & TablerosUtilsHyP.ObtenColorIdSErvicio(objChip.IDSERVICIO) & ")")
            '  ixdiv.Style.Add("background", "-moz-radial-gradient(40% 40%, farthest-side, #ffffff, " & sImageChip & ")")
            'ixdiv.Style.Add("background", "-moz-radial-gradient(40% 40%, farthest-side, #ffffff, " & sImageChip & ")")
            ixdiv.Style.Add("background", "-webkit-linear-gradient(left, " & sImageChip & ", " & TablerosUtilsHyP.ObtenColorIdSErvicio(objChip.IDSERVICIO) & ")")
            ' ixdiv.Style.Add("background", "-ms-radial-gradient(80% 20%, closest-corner, " & sImageChip & ", " & TablerosUtilsHyP.ObtenColorIdSErvicio(objChip.IDSERVICIO) & ")")
        Else
            If objChip.IDCHIP = 0 Then
                ixdiv.Style.Add("filter", "progid:DXImageTransform.Microsoft.gradient(startColorstr=#ffffff, endColorstr=" & sImageChip & ", GradientType=3)")
                '   ixdiv.Style.Add("background", "-webkit-gradient(radial,center center,0,center center,60,from(#FFFFFF),to(" & sImageChip & "))")
                ixdiv.Style.Add("background", "-moz-radial-gradient(40% 40%, farthest-side, #ffffff, " & sImageChip & ")")
                '  ixdiv.Style.Add("background", "-moz-radial-gradient(40% 40%, farthest-side, #ffffff, " & sImageChip & ")")

                ixdiv.Style.Add("background", "-webkit-radial-gradient(30% 30%, farthest-corner, #FFFFFF 30%, " & sImageChip & " 100%)")
            End If
        End If



        Dim sComentarios As String = ""
        For Each d As ChipHYPCom In objChip._HypComentarios
            sComentarios = sComentarios & "--- Comentarios en " & d._Status & "---" & vbCrLf
            sComentarios = sComentarios & "Fecha: " & d._fecha.ToShortDateString & " " & d._fecha.ToShortTimeString & ", "
            sComentarios = sComentarios & "Usuario: " & d._cveUsuario & vbCrLf
            sComentarios = sComentarios & "   " & d._comentario & vbCrLf
        Next
        If objChip.CONCITA = True Then
            ixdiv.Attributes.Add("title", "--CITA " & objChip.NUMCITA & "-- HoraCita " & objChip.HORAASESOR & vbCrLf & "Orden:" & objChip.NOORDEN & vbCrLf & "Vehiculo: " & objChip.VEHICULO & " " & objChip.COLOR & vbCrLf & " Placas: " & objChip.NOPLACAS & vbCrLf & " Torre: " & objChip.COLORPRISMA & vbCrLf & "VIN: " & objChip.VIN & vbCrLf & "Servicio: " & sServiciocapturado & vbCrLf & "Duracion: " & System.Math.Round((sServicio / 60), 2) & " horas" & vbCrLf & "Observaciones: " & sObservaciones & "" & vbCrLf & "Estatus: " & objChip.STATUS.ToUpper & "" & vbCrLf & sComentarios)

        Else
            ixdiv.Attributes.Add("title", "Orden:" & objChip.NOORDEN & vbCrLf & "Vehiculo: " & objChip.VEHICULO & " " & objChip.COLOR & vbCrLf & " Placas: " & objChip.NOPLACAS & vbCrLf & " Torre: " & objChip.COLORPRISMA & vbCrLf & "VIN: " & objChip.VIN & vbCrLf & "Servicio: " & sServiciocapturado & vbCrLf & "Duracion: " & System.Math.Round((sServicio / 60), 2) & " horas" & vbCrLf & "Observaciones: " & sObservaciones & "" & vbCrLf & "Estatus: " & objChip.STATUS.ToUpper & "" & vbCrLf & sComentarios)

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

        If bAlarmF Then
            Dim ixdivAlertF As New HtmlImage
            ixdivAlertF.ID = sDiv & "Alert"
            ixdivAlertF.Src = "~/img/blink.gif"
            ixdivAlertF.Style.Add("Left", "0")
            ixdivAlertF.Style.Add("top", "0")
            ixdivAlertF.Style.Add("cursor", "hand")
            ixdivAlertF.Style.Add("position", "absolute")
            ixdivAlertF.Style.Add("width", "100%")
            ixdivAlertF.Style.Add("height", "100%")

            'ixdivAlert.Style.Add("background-color", "Transparent")
            'ixdivAlert.Style.Add("filter", "alpha(opacity = 20)")

            ixdiv.Style.Add("z-index", "1501")
            ixdiv.Controls.Add(ixdivAlertF)
        End If

        If sComentarios.Length > 0 Then
            Dim ixdivcomen As New HtmlGenericControl("div")
            ixdivcomen.ID = sDiv & "_comen"
            ixdivcomen.Style.Add("bottom", "70%")
            ixdivcomen.Style.Add("left", "90%")
            ixdivcomen.Style.Add("position", "relative")
            ixdivcomen.Style.Add("width", "6px")
            ixdivcomen.Style.Add("height", "9px")
            ixdivcomen.Style.Add("color", "#fff")
            ixdivcomen.Style.Add("background-color", "darkblue")
            ixdivcomen.InnerText = "1"
            ixdivcomen.Style.Add("font-weight", "bold")
            ixdivcomen.Style.Add("text-align", "center")
            ixdivcomen.Style.Add("font-size", "7px")
            ixdiv.Controls.Add(ixdivcomen)
        End If

        ixdiv.Controls.Add(ixdivId)
        Me.form1.Controls.Add(ixdiv)

    End Sub
    Protected Sub Timer13_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer13.Tick

        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumtecs") <> "" Then

            iCurrentV = iCurrentV + CInt(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumtecs"))
            If iCurrentV >= iTotalV Then
                iCurrentV = 0
            End If
            Session("iCurrentV") = iCurrentV
        End If


    End Sub

    Private Sub whuxgaPT_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumtecsT") <> "" Then
            Timer13.Interval = CInt(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumtecsT")) * 1000
        Else
            Timer13.Enabled = False
        End If
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



    Private Sub whuxgaPT_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Not Page.IsPostBack Then
            TablerosUtilsHyP.Salir()
        End If
    End Sub

    'Private Sub imgRefreshAll_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgRefreshAll.Click
    '    'refreshDMS()
    'End Sub
    Protected Sub imgFind_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgFind.Click


        iniciaTablero(False)

        Exit Sub


    End Sub

    Private Sub MPGV_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MPGV.PreRender
        Session("DATEHYP") = Date.Now.ToShortDateString
    End Sub

    Protected Sub imgBuscar_Click(sender As Object, e As ImageClickEventArgs) Handles imgBuscar.Click


        iniciaTablero(True, txtBuscar.Text)
    End Sub
    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick

        If Int32.Parse(e.Item.Value) = 0 Then
            Session.Remove("rbDet")

            iniciaTablero(False, txtBuscar.Text)
            'PINTACHIPS()
        ElseIf Int32.Parse(e.Item.Value) = 5 Then
            TablerosUtilsHyP.Salir()
            Response.Redirect("Inicio.aspx")
        Else


            Session("rbDet") = True
            iniciaTablero(False, txtBuscar.Text, True)
            ' PINTACHIPS()
        End If
    End Sub

    Private Sub cmdGuardarComen_Click(sender As Object, e As EventArgs) Handles cmdGuardarComen.Click
        Dim iId As Int64, iTiempo As Int32, iPosx As Int32, iPosY As Int32
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtmlChp"), HtmlInputText).Value

        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        iTiempo = CInt(Split(sdhtml, ".")(3))
        iTiempo = CInt((iTiempo) * (5 / 6.33))
        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
            If Left(d.id, 5) = "ctlll" Then
                iId = d.Value
            End If
        Next

        'iId = CType(Me.FindControl(Split(sdhtml, ".")(0)).Controls(1), HtmlInputHidden).Value

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
        iniciaTablero(True, txtBuscar.Text)

    End Sub
    Protected Sub btnIni_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIni.Click
        Dim iId As Int64, iTiempo As Int32, iPosx As Int32, iPosY As Int32
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        iTiempo = CInt(Split(sdhtml, ".")(3))
        iTiempo = CInt((iTiempo) * (5 / 6.33))
        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
            If Left(d.id, 5) = "ctlll" Then
                iId = d.Value
            End If
        Next

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then



                If Validar(obj, "I") Then
                    obj.VHREPARANDO = True
                    obj.VHSERVERMINADO = False
                    obj.STATUS = "Iniciada"
                    obj.STATUSOS = "EN PROCESO"
                    obj.FECHAHORAFINOPER = Nothing
                    obj.FECHAHORAPARO = Nothing
                    obj.FECHAHORAREINICIO = Nothing
                    obj.FECHAHORACIERREOS = Nothing
                    obj.FECHAHORAAPERTURAOS = Date.Now
                    obj.FECHAHORAINIOPER = Date.Now
                    obj.IDMOTIVOPARO = Nothing
                    TablerosUtilsHyP.Operaciones(obj, "I")
                End If



                Exit For
            End If

        Next

        iniciaTablero(True, txtBuscar.Text)


    End Sub
    Function Validar(ByVal obj As ChipHYP, ByVal sOperacion As String) As Boolean
        If obj.IDCHIP = 0 Then
            TablerosUtilsHyP.iMsgBox(Me.Page, "Este chip aun no ha sido recibido ")

            Return False
        End If
        Dim DT As New DataTable

        Select Case sOperacion
            Case "I"
                'If obj.VHRECEPCION = False Then
                '    TablerosUtilsHyP.iMsgBox(Me.Page, "La unidad no ha sido recibida")
                '    Return False
                'End If

                If obj.NOORDEN = "0" Then
                    If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "campoenlace") <> "" Then
                        If TablerosUtilsHyP.ActualizarOrden(obj, SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "campoenlace")) = "0" Then
                            TablerosUtilsHyP.iMsgBox(Me.Page, "No puede Iniciar sin numero de orden asignado")
                            Return False
                        End If
                    Else

                        If TablerosUtilsHyP.ActualizarOrden(obj, "noplacas") = "0" Then
                            TablerosUtilsHyP.iMsgBox(Me.Page, "No puede Iniciar sin numero de orden asignado")
                            Return False
                        End If
                    End If

                End If
                If obj.STATUS = "Terminado" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "La operacion ya esta terminada")
                    Return False
                End If
                If obj.STATUS = "Terminado" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "La operacion ya esta terminada")
                    Return False
                End If
                If obj.STATUS <> "Pendiente" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "La operacion ya esta iniciada")
                    Return False
                End If
                Dim OBJCOL As New CHIPHYPCollection
                OBJCOL = Session("ColChipsP")
                If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iMInicio") <> "1" Then
                    For Each iobj As ChipHYP In OBJCOL
                        If iobj.IDTECNICO = obj.IDTECNICO And obj.FECHA = iobj.FECHA And iobj.ID <> obj.ID Then
                            If iobj.STATUS = "Iniciada" Then
                                TablerosUtilsHyP.iMsgBox(Me.Page, "Ya existe otra tarea iniciada en esta bahia")
                                Return False
                            End If
                        End If
                    Next
                End If

                If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "ChpIniSec") = "1" Then
                    For Each iobj As ChipHYP In OBJCOL
                        If iobj.IDTECNICO = obj.IDTECNICO And obj.FECHA.ToShortDateString = iobj.FECHA.ToShortDateString And iobj.ID <> obj.ID And DateDiff(DateInterval.Minute, CDate(iobj.HORARAMPA), CDate(obj.HORARAMPA)) > 0 Then
                            If iobj.STATUS = "Pendiente" Or iobj.STATUS = "Iniciada" Then
                                TablerosUtilsHyP.iMsgBox(Me.Page, "Hay una tarea previa pendiente por iniciar o finalizar")
                                Return False
                            End If
                        End If
                    Next
                End If


                If SCC.SolPermisosBol(SCC.EObjetos.CHIPTECNICOS, SCC.EOperaciones.Iniciar) = False Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  iniciar esta operacion")
                    Return False
                End If

            Case "D"
                'If obj.VHRECEPCION = False Then
                '    TablerosUtilsHyP.iMsgBox(Me.Page, "La unidad no ha sido recibida")
                '    Return False
                'End If
                If obj.STATUS = "Detenida" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "La operacion ya esta detenida")
                    Return False
                End If
                If obj.STATUS = "Terminado" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "La operacion ya esta terminada")
                    Return False
                End If
                If obj.STATUS <> "Iniciada" And obj.STATUS <> "Reiniciada" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe iniciar primero la tarea")
                    Return False
                End If
                If cboStop.SelectedIndex < 1 Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe seleccionar un motivo de paro")
                    Return False
                End If
                If SCC.SolPermisosBol(SCC.EObjetos.CHIPTECNICOS, SCC.EOperaciones.Detener) = False Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  iniciar esta detener")
                    Return False
                End If


                If txtComenDet.Text.Trim.Length <= 3 Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe Agregar Un Comentario")
                    Return False
                End If

                'If obj.OBSERVACIONES = "" Then
                '    TablerosUtilsHyP.iMsgBox(Me.Page, "debe ingresar un Comnetario para detenerlo")
                '    Return False
                ''End If
            Case "R"
                'If obj.VHRECEPCION = False Then
                '    TablerosUtilsHyP.iMsgBox(Me.Page, "La unidad no ha sido recibida")
                '    Return False
                'End If
                If obj.IDMOTIVOPARO <> "5" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Solo esta permitido reiniciar la prueba de ruta")
                    Return False
                End If
                If obj.STATUS = "Terminado" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "La operacion ya esta terminada")
                    Return False
                End If
                If obj.STATUS <> "Detenida" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Para reiniciar la operacion debe estar detenida")
                    Return False
                End If
                If SCC.SolPermisosBol(SCC.EObjetos.CHIPTECNICOS, SCC.EOperaciones.Reiniciar) = False Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  reiniciar esta operacion")
                    Return False
                End If

            Case "FNAutoriza"
                'If obj.VHRECEPCION = False Then
                '    TablerosUtilsHyP.iMsgBox(Me.Page, "La unidad no ha sido recibida")
                '    Return False
                'End If
                If obj.IDMOTIVOPARO <> "3" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Solo esta permitido en detenidos por autorizacion")
                    Return False
                End If
                If obj.STATUS = "Terminado" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "La operacion ya esta terminada")
                    Return False
                End If

                If obj.STATUS <> "Iniciada" And obj.STATUS <> "Reiniciada" And obj.STATUS <> "Detenida" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Para finializar la operacion, debe estar iniciada")
                    Return False
                End If
                If SCC.SolPermisosBol(SCC.EObjetos.CHIPTECNICOS, SCC.EOperaciones.Terminar) = False Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  terminar esta operacion")
                    Return False
                End If




            Case "F"
                'If obj.VHRECEPCION = False Then
                '    TablerosUtilsHyP.iMsgBox(Me.Page, "La unidad no ha sido recibida")
                '    Return False
                'End If
                If obj.STATUS = "Terminado" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "La operacion ya esta terminada")
                    Return False
                End If

                If obj.STATUS <> "Iniciada" And obj.STATUS <> "Reiniciada" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Para finializar la operacion, debe estar iniciada")
                    Return False
                End If
                If SCC.SolPermisosBol(SCC.EObjetos.CHIPTECNICOS, SCC.EOperaciones.Terminar) = False Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  terminar esta operacion")
                    Return False
                End If

                If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iDiagnostico") = "1" Then
                    DT = TablerosUtilsHyP.ObtenOrdenTrabajoKdw(obj.NOORDEN)
                    If DT.Rows.Count > 0 Then
                        If DT.Rows(0).Item("comentario").ToString.Trim.Length = 0 Then
                            TablerosUtilsHyP.iMsgBox(Me.Page, "Debe agregar comentarios en la Hoja de instruccion de trabajo para finalizar")
                            Return False
                        End If
                    Else

                        TablerosUtilsHyP.iMsgBox(Me.Page, "Debe agregar comentarios en la Hoja de instruccion de trabajo para finalizar")
                        Return False

                    End If
                End If

            Case "RR"

                'If obj.VHRECEPCION = False Then
                '    TablerosUtilsHyP.iMsgBox(Me.Page, "La unidad no ha sido recibida")
                '    Return False
                'End If
                If obj.STATUS = "Pendiente" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Debe iniciar primero la tarea")
                    Return False
                End If
                If obj.STATUS = "Terminado" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "La operacion ya esta terminada")
                    Return False
                End If

                If SCC.SolPermisosBol(SCC.EObjetos.CHIPTECNICOS, SCC.EOperaciones.Restablecer) = False Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  restablecer esta operacion")
                    Return False
                End If
        End Select


        Return True
    End Function


    Private Sub btnInit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnInit.Click
        Dim iId As Int64, iTiempo As Int32, iPosx As Int32, iPosY As Int32
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        iTiempo = CInt(Split(sdhtml, ".")(3))
        iTiempo = CInt((iTiempo) * (5 / 6.33))
        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
            If Left(d.id, 5) = "ctlll" Then
                iId = d.Value
            End If
        Next

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then

                If Validar(obj, "R") Then
                    obj.STATUS = "Reiniciada"
                    TablerosUtilsHyP.Operaciones(obj, "R")
                End If

                Exit For
            End If

        Next

        iniciaTablero(True, txtBuscar.Text)

    End Sub
    Private Sub btnFinalizar(sender As Object, e As EventArgs, bCalidad As Boolean, bprueba As Boolean)
        Dim iId As Int64, iTiempo As Int32, iPosx As Int32, iPosY As Int32
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        iTiempo = CInt(Split(sdhtml, ".")(3))
        iTiempo = CInt((iTiempo) * (5 / 6.33))
        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
            If Left(d.id, 5) = "ctlll" Then
                iId = d.Value
            End If
        Next



        '  TablerosUtilsHyP.iMsgBoxYN(Me.Page, "No puede Iniciar sin numero de orden asignado")

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then

                If Validar(obj, "F") Then
                    obj.VHREPARANDO = False
                    obj.VHSERVERMINADO = True
                    obj.STATUS = "Terminado"


                    If bCalidad = False And bprueba = False Then
                        obj.STATUSOS = "Finalizada"
                    Else
                        If bCalidad = False And bprueba = True Then
                            obj.STATUSOS = "PruebaRuta"
                        Else
                            obj.STATUSOS = "Calidad"
                        End If
                    End If

                    ' If txtComenFin.Text.Trim.Length > 0 Then
                    ' ChipHYPCom.GuardaComentario(obj, txtComenFin.Text.Trim)
                    'txtComenFin.Text = ""
                    'End If
                    TablerosUtilsHyP.Operaciones(obj, "F")


                    obj.SERVICIOCAPTURADO = "Lavado"
                    obj.STATUS = "EN LAVADO"
                    obj.IDSERVICIO = "151"
                    obj.ENUSO = True
                    obj.VHRECEPCION = True
                    obj.VHINVENTARIO = True

                    'TablerosUtils.GrabaLavado(obj)
                End If

                Exit For
            End If

        Next

        iniciaTablero(True, txtBuscar.Text)
    End Sub
    'Private Sub btnFin3_Click(sender As Object, e As EventArgs) Handles btnFin3.Click
    '    btnFinalizar(sender, e, True, False)

    '    iniciaTablero(True, txtBuscar.Text)

    'End Sub

    'Private Sub btnFin4_Click(sender As Object, e As EventArgs) Handles btnFin4.Click
    '    btnFinalizar(sender, e, False, True)

    '    iniciaTablero(True, txtBuscar.Text)

    'End Sub

    Private Sub btnFin_Click(sender As Object, e As EventArgs) Handles btnFin.Click
        btnFinalizar(sender, e, False, False)
        iniciaTablero(True, txtBuscar.Text)
        'Dim iId As Int64, iTiempo As Int32, iPosx As Int32, iPosY As Int32
        'Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        'If Split(sdhtml, ".").Length < 2 Then Exit Sub
        'iTiempo = CInt(Split(sdhtml, ".")(3))
        'iTiempo = CInt((iTiempo) * (5 / 6.33))
        'iPosx = CInt(Split(sdhtml, ".")(1))
        'iPosY = CInt(Split(sdhtml, ".")(2))
        'For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
        '    If Left(d.id, 5) = "ctlll" Then
        '        iId = d.Value
        '    End If
        'Next



        'TablerosUtilsHyP.iMsgBoxYN(Me.Page, "No puede Iniciar sin numero de orden asignado")

        'Dim OBJCOL As New CHIPHYPCollection
        'OBJCOL = Session("ColChipsP")

        'For Each obj As ChipHYP In OBJCOL
        '    If obj.ID = iId Then

        '        If Validar(obj, "F") Then
        '            obj.VHREPARANDO = False
        '            obj.VHSERVERMINADO = True
        '            obj.STATUS = "Terminado"
        '            obj.STATUSOS = "Finalizada"
        '            TablerosUtilsHyP.Operaciones(obj, "F")


        '            obj.SERVICIOCAPTURADO = "Lavado"
        '            obj.STATUS = "EN LAVADO"
        '            obj.IDSERVICIO = "151"
        '            obj.ENUSO = True
        '            obj.VHRECEPCION = True
        '            obj.VHINVENTARIO = True

        '            'TablerosUtils.GrabaLavado(obj)
        '        End If

        '        Exit For
        '    End If

        'Next

        'iniciaTablero(True, txtBuscar.Text)
    End Sub

    Private Sub btnNoAutoriza_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNoAutoriza.Click
        Dim iId As Int64, iTiempo As Int32, iPosx As Int32, iPosY As Int32
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        iTiempo = CInt(Split(sdhtml, ".")(3))
        iTiempo = CInt((iTiempo) * (5 / 6.33))
        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
            If Left(d.id, 5) = "ctlll" Then
                iId = d.Value
            End If
        Next





        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then

                If Validar(obj, "FNAutoriza") Then
                    obj.VHREPARANDO = False
                    obj.VHSERVERMINADO = True
                    obj.STATUS = "Terminado"
                    obj.STATUSOS = "Finalizada"
                    TablerosUtilsHyP.Operaciones(obj, "FF")




                    'TablerosUtils.GrabaLavado(obj)
                End If

                Exit For
            End If

        Next


    End Sub


    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Dim iId As Int64, iTiempo As Int32, iPosx As Int32, iPosY As Int32
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        iTiempo = CInt(Split(sdhtml, ".")(3))
        iTiempo = CInt((iTiempo) * (5 / 6.33))
        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
            If Left(d.id, 5) = "ctlll" Then
                iId = d.Value
            End If
        Next

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then
                If Validar(obj, "D") Then

                    obj.STATUS = "Detenida"
                    obj.CONTINUARA = False
                    obj.ENBAHIAENESTACION = False
                    obj.IDMOTIVOPARO = cboStop.SelectedItem.Value

                    TablerosUtilsHyP.Operaciones(obj, "D")
                    ' TablerosUtils.GrabaDetenida(obj, IIf(cboStop.SelectedItem.Text.ToLower = "en proceso", "Carryover", cboStop.SelectedItem.Text))
                    If txtComenDet.Text.Trim.Length > 0 Then
                        ChipHYPCom.GuardaComentario(obj, txtComenDet.Text.Trim)
                        txtComenDet.Text = ""
                    End If

                End If

                Exit For
            End If

        Next

        iniciaTablero(True, txtBuscar.Text)

    End Sub

    Private Sub imgBtnDgn_Kdw_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnDgn_Kdw.Click
        Dim iId As Int64
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 5) = "ds00." Then Exit Sub

        For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
            If Left(d.id, 5) = "ctlll" Then
                iId = d.Value
            End If
        Next

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

    Private Sub imgBtnWrk_Kdw_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnWrk_Kdw.Click
        Dim iId As Int64
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 5) = "ds00." Then Exit Sub

        For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
            If Left(d.id, 5) = "ctlll" Then
                iId = d.Value
            End If
        Next

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then
                Session("OS") = obj.NOORDEN

                Exit For
            End If

        Next
        Try

            Dim scriptString As String = "<script language='JavaScript'>" _
                                               & " window.open('OrdenTecnico.aspx', 'windowWrk', 'scrollbars=yes, toolbar=yes, top=0, left=0, width=1265, height=613, resize=no');</script>"

            Page.ClientScript.RegisterStartupScript(GetType(Page), "ShowWork", scriptString)

        Catch eexc As Exception
            Session("Error") = eexc.Message
        End Try
    End Sub

    Protected Sub btnLvd_Click(sender As Object, e As ImageClickEventArgs) Handles btnLvd.Click

        Dim iId As Int64
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtmlChp"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub

        For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
            If Left(d.id, 5) = "ctlll" Then
                iId = d.Value
                '    Response.Write("id: " & iId)
            End If
        Next
        ' iId = CType(Me.FindControl(Split(sdhtml, ".")(0)).Controls(1), HtmlInputHidden).Value

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then


                TablerosUtilsHyP.GrabaLavado(obj)
                Exit For
            End If




        Next

        Dim objc As New ArrayList()
        For Each d In Me.form1.Controls
            If Left(d.id, 2) = "ds" Or Left(d.id, 5) = "ctlll" Then
                objc.Add(d.id)
            End If
        Next
        For Each d In objc
            If Left(d, 2) = "ds" Or Left(d, 5) = "ctlll" Then
                Me.form1.Controls.Remove(Me.form1.FindControl(d))
            End If
        Next
        bref = True
        iniciaTablero(True)
        PINTACHIPS()


    End Sub

    Private Sub imgRefrescar_Click(sender As Object, e As ImageClickEventArgs) Handles imgRefrescar.Click
        iniciaTablero(True, txtBuscar.Text)
    End Sub


End Class