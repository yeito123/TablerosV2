Imports TablerosV2LibTypes

Partial Public Class _zcrmCuestionarioDetalle
    Inherits System.Web.UI.Page

    Const TCUESTIONARIO = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Request("noorden") Is Nothing Then
                Me.txtOrden.Text = Request("noorden").ToString
            End If

            txtFecha.Text = DateTime.Now.ToString
            llenaAsesores()
            llenaPreguntas()

            iniciavalores()
        Else
            txtFecha.Text = DateTime.Now.ToString
        End If

    End Sub
    Sub llenaPreguntas()

        Dim dt As New DataTable
        Dim sqry As String = ""
        sqry = "SELECT  ID_PREGUNTA, DESCRIPCION, TCONTROL, Opciones FROM dbo.EncuestaServicioMZDConfig  where  TCUESTIONARIO=" & TCUESTIONARIO & " order by id_pregunta asc" '  where Tipo='Asesor' order by Nombre_empleado"
        dt = BDClass.SQLtoDataTable(sqry, False)
        Session("dtPreguntas") = dt
        Dim dtTemp As New DataTable
        dtTemp.Columns.Add("ID_PREGUNTA")
        dtTemp.Columns.Add("ID_LINEA")
        dtTemp.Columns.Add("VALOR")
        dtTemp.Columns.Add("CONTESTADA")

        For i = 0 To dt.Rows.Count - 1
            dtTemp.Rows.Add(New Object() {dt.Rows(i).Item(0), 0, "", 0})
            'dtTemp.Rows.Add(New Object() {dt.Rows(i).Item(0)})
        Next
        dgPreguntas.PageIndex = 0
        Session("dtRespuestas") = dtTemp

        dgPreguntas.DataSource = dt
        dgPreguntas.DataBind()


    End Sub
    Sub llenaAsesores()

        Dim dt As New DataTable
        Dim sqry As String = ""
        'sqry = "SELECT distinct id_empleado,Nombre_empleado from  dim_empleado" '  where Tipo='Asesor' order by Nombre_empleado"
        sqry = "select distinct cveasesor,nombre from  sccUsuarios where cveAsesor != ''"
        dt = BDClass.SQLtoDataTable(sqry, False)
        CboAsesor.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            CboAsesor.Items.Add(New ListItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
        Next
    End Sub
    Sub GuardarDatos()


        Dim sqry As String
        sqry = "update  fv_datoscliente set Mail='" & txtCorreo.Text.Trim & "', cp='" & txtCP.Text.Trim & "'," _
        & " telefono='" & txtTelefono.Text.Trim & "', Celular='" & txtCelular.Text.Trim & "',Cumpleaños='" & txtCumpleaños.Text.Trim & "'," _
        & " tipoauto='" & txtTipoAuto.Text.Trim & "', direccion='" & txtDireccion.Text.Trim & "', colonia='" & txtColonia.Text.Trim & "'," _
         & " cliente='" & txtClientenombre.Text.Trim & "'  where no_orden= '" & Session("Orden") & "'"

        BDClass.ExecuteQuery(sqry, False)



    End Sub
    Sub iniciavalores()
        CboAsesor.SelectedIndex = -1

        Dim dtRespuestas As DataTable = Session("dtRespuestas")
        Session("FinVisible") = False
        Session("ASVisible") = True

        If Not txtOrden.Text = "" Then


            Dim dt As New DataTable
            Dim sqry As String = "", svalor As String = ""
            sqry = "Select * From v_datoscliente where no_orden= " & Session("Orden") & ""
            'response.write(sqry)           
            dt = BDClass.SQLtoDataTable(sqry, False)
            If dt.Rows.Count > 0 Then
                txtOrden1.Text = txtOrden.Text
                txtClientenombre.Text = IIf(dt.Rows(0).Item("cliente") Is DBNull.Value, "", dt.Rows(0).Item("cliente").ToString)
                txtDireccion.Text = IIf(dt.Rows(0).Item("direccion") Is DBNull.Value, "", dt.Rows(0).Item("direccion").ToString)
                txtColonia.Text = IIf(dt.Rows(0).Item("colonia") Is DBNull.Value, "", dt.Rows(0).Item("colonia").ToString)
                txtTipoAuto.Text = IIf(dt.Rows(0).Item("tipoauto") Is DBNull.Value, "", dt.Rows(0).Item("tipoauto").ToString)
                txtTelefono.Text = IIf(dt.Rows(0).Item("telefono") Is DBNull.Value, "", dt.Rows(0).Item("telefono").ToString)
                txtCP.Text = IIf(dt.Rows(0).Item("cp") Is DBNull.Value, "", dt.Rows(0).Item("cp").ToString)
                txtCorreo.Text = IIf(dt.Rows(0).Item("mail") Is DBNull.Value, "", dt.Rows(0).Item("mail").ToString)
                txtCelular.Text = IIf(dt.Rows(0).Item("Celular") Is DBNull.Value, "", dt.Rows(0).Item("Celular").ToString)
                txtCumpleaños.Text = IIf(dt.Rows(0).Item("Cumpleaños") Is DBNull.Value, "", dt.Rows(0).Item("Cumpleaños").ToString)
                Session("ID_ASESOR") = IIf(dt.Rows(0).Item("asesor") Is DBNull.Value, "", dt.Rows(0).Item("asesor").ToString)
            Else
                txtClientenombre.Text = "Sin dato"
                txtDireccion.Text = "Sin dato"
                txtColonia.Text = "Sin dato"
                txtTipoAuto.Text = "Sin dato"
                txtTelefono.Text = "Sin dato"
                txtCP.Text = "Sin dato"
                txtCorreo.Text = "Sin dato"
                txtCelular.Text = "Sin dato"
                txtCumpleaños.Text = "Sin Dato"
            End If
        End If

        Try
            CboAsesor.Items.FindByValue(Session("ID_ASESOR")).Selected = True
        Catch ex As Exception
        End Try




    End Sub


    Sub INSERTAR(ByVal sIdPregunta As Integer, ByVal sValor As String)

        Dim dt As New DataTable
        Dim sqry As String = ""
        If sValor.Length < 50 Then
            sqry = "INSERT INTO EncuestaServicioMZD(TCUESTIONARIO,orden,EstatusEncuesta, nom_cliente, id_asesor, fecha_captura, id_pregunta, id_linea, valor) " _
                    & " VALUES(" & TCUESTIONARIO & "," _
                    & "'" & txtOrden.Text.Trim & "',0," _
                    & "'" & txtClientenombre.Text.Trim & "'," _
                    & "'" & If(CboAsesor.SelectedItem Is Nothing, 0, CboAsesor.SelectedItem.Value) & "'," _
                    & "cast('" & IIf(Session("sFechaCaptura") Is Nothing, String.Format("{0:s}", CDate(Date.Now.ToShortDateString)), String.Format("{0:s}", CDate(Session("sFechaCaptura")))) & "' as datetime)," _
                    & "" & sIdPregunta & ",1,'" & sValor & "'" _
                    & ")"

            BDClass.ExecuteQuery(sqry, False)

        Else
            Dim ilinea As Integer, a As Integer, desc As String
            ilinea = 1
            a = 1

            Do While Not ilinea >= sValor.Length
                desc = Mid(sValor, ilinea, 25)
                ilinea = ilinea + 25
                sqry = "INSERT INTO EncuestaServicioMZD(TCUESTIONARIO,orden,EstatusEncuesta,nom_cliente, id_asesor, fecha_captura, id_pregunta, id_linea, valor) " _
                    & " VALUES(1," _
                    & "'" & txtOrden.Text.Trim & "',0," _
                    & "'" & txtClientenombre.Text.Trim & "'," _
                    & "'" & CboAsesor.SelectedItem.Value & "'," _
                    & "cast('" & String.Format("{0:s}", CDate(Date.Now.ToShortDateString)) & "' as datetime)," _
                    & "" & sIdPregunta & "," & a & ",'" & desc & "'" _
                    & ")"

                BDClass.ExecuteQuery(sqry, False)
                a = a + 1
            Loop
        End If



    End Sub
    Private Function obtenValor(ByVal ItemRequest As String) As String
        For Each nRequest As String In Request.Form
            If nRequest.LastIndexOf(ItemRequest.Trim) > -1 Then
                Return Request.Form(nRequest).Trim
            End If
        Next
        Return ""
    End Function


    Protected Sub cmdGuardar1(ByVal IiNDEX As Integer)


        Dim sqry As String = ""
        Dim svalor As String
        ' ID_PREGUNTA, DESCRIPCION, TCONTROL, Opciones 

        sqry = "DELETE EncuestaServicioMZD where ORDEN = '" & txtOrden.Text.Trim & "' and " _
        & " TCUESTIONARIO=" & TCUESTIONARIO & "  and ID_PREGUNTA='" & CType(Session("DTPREGUNTAS"), DataTable).Rows(IiNDEX).Item("ID_PREGUNTA") & "'"
        '  sqry = "DELETE EncuestaServicioMZD where ORDEN = '" & txtOrden.Text.Trim & "' and TCUESTIONARIO=" & TCUESTIONARIO & " "
        BDClass.ExecuteQuery(sqry, False)
        Select Case CType(Session("DTPREGUNTAS"), DataTable).Rows(IiNDEX).Item("TCONTROL").ToString.ToLower.Trim
            Case "option"
                svalor = obtenValor("opt_" & CType(Session("DTPREGUNTAS"), DataTable).Rows(IiNDEX).Item("ID_PREGUNTA").ToString)
                INSERTAR(CInt(CType(Session("DTPREGUNTAS"), DataTable).Rows(IiNDEX).Item("ID_PREGUNTA").ToString), svalor)
            Case "text"
                svalor = obtenValor("txt_" & CType(Session("DTPREGUNTAS"), DataTable).Rows(IiNDEX).Item("ID_PREGUNTA").ToString)
                INSERTAR(CInt(CType(Session("DTPREGUNTAS"), DataTable).Rows(IiNDEX).Item("ID_PREGUNTA").ToString), svalor)

            Case "checkl"
                svalor = obtenValor("opt_" & CType(Session("DTPREGUNTAS"), DataTable).Rows(IiNDEX).Item("ID_PREGUNTA").ToString)
                INSERTAR(CInt(CType(Session("DTPREGUNTAS"), DataTable).Rows(IiNDEX).Item("ID_PREGUNTA").ToString), svalor)
            Case Else
        End Select



    End Sub


    Protected Sub ImgBtnRef_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnRef.Click

        Session("Orden") = txtOrden.Text

        MultiView1.ActiveViewIndex = 1

        iniciavalores()

        'PosicionaValoreGuardadosxOrden(txtOrden.Text, txtCliente.Text)
    End Sub
    Protected Sub ImgBtnRef1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnRef1.Click
        'Session("Orden") = txtOrden.Text
        'Session("Cliente") = txtClientenombre.Text

        MultiView1.ActiveViewIndex = 2
        'GuardarDatos()
        Session("Orden") = txtOrden.Text
        Session("Cliente") = txtClientenombre.Text.Trim
        Session("tipoaauto") = txtTipoAuto.Text.Trim
        llenaPreguntas()
        'iniciavalores()

        'PosicionaValoreGuardadosxOrden(txtOrden.Text, txtCliente.Text)
    End Sub
    Protected Sub imgSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSalir.Click


        Session.Remove("Orden")
        Session.Remove("Cliente")
        Session.Remove("tipoaauto")
        If Session("idencuestaservicio") Is Nothing Then
            Response.Redirect("Inicio.aspx")
        Else
            If Session("idencuestaservicio") = "1" Then
                Response.Redirect("zcrmseguimiento.aspx")
            ElseIf Session("idencuestaservicio") = "2" Then
                Response.Redirect("zcrmgerencia.aspx")
            End If
        End If

    End Sub

    Protected Sub dgPreguntas_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPreguntas.PageIndexChanged


    End Sub

    Protected Sub dgPreguntas_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dgPreguntas.PageIndexChanging
        Dim I As Integer = dgPreguntas.PageIndex
        If obtenValor("opt_" & CType(Session("DTPREGUNTAS"), DataTable).Rows(I).Item("ID_PREGUNTA").ToString).Trim.Length <> 0 Then
            cmdGuardar1(I)
            Try
                dgPreguntas.PageIndex = e.NewPageIndex
                I = dgPreguntas.PageIndex
            Catch ex As Exception

            End Try


        End If



        Dim dt As New DataTable
        If Not Session("DTPREGUNTAS") Is Nothing Then
            dt = Session("DTPREGUNTAS")
        End If
        dgPreguntas.DataSource = dt
        dgPreguntas.DataBind()


        If I = CType(Session("DTPREGUNTAS"), DataTable).Rows.Count - 2 Then
            Session("FinVisible") = True
            Session("ASVisible") = False

        Else
            Session("FinVisible") = False
            Session("ASVisible") = True

        End If
        If I = CType(Session("DTPREGUNTAS"), DataTable).Rows.Count - 1 Then

            pnlFooter.Visible = True
            ' dgPreguntas.Items(0).FindControl("imgFin").Visible = True
        Else

            pnlFooter.Visible = False
            ' dgPreguntas.Items(0).FindControl("imgFin").Visible = False
        End If

    End Sub

    Private Sub dgPreguntas_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPreguntas.PreRender
        Dim ioption As RadioButtonList, itext As TextBox, ichkl As CheckBoxList, iimg As New ImageButton
        Dim sOpciones() As String
        Dim sqry As String, dt As New DataTable
        'Session("Orden") = txtOrden.Text
        'Session("Cliente") = txtCliente.Text
        sqry = "SELECT * FROM EncuestaServicioMZD where orden = '" & Session("Orden") & "' and TCUESTIONARIO=" & TCUESTIONARIO & "  order by id_pregunta asc"
        'sqry = "SELECT * FROM EncuestaServicioMZD where orden = '" & Session("Orden") & "' and TCUESTIONARIO=" & TCUESTIONARIO & "  order by id_pregunta asc"

        dt = BDClass.SQLtoDataTable(sqry, False)



        If dt.Rows.Count > 0 Then
            txtClientenombre.Text = dt.Rows(0).Item("NOM_CLIENTE").ToString.Trim
            CboAsesor.SelectedIndex = -1
            Try
                CboAsesor.Items.FindByValue(dt.Rows(0).Item("ID_ASESOR").ToString).Selected = True
            Catch ex As Exception
            End Try
        End If



        For i = 0 To dgPreguntas.Rows.Count - 1

            Select Case dgPreguntas.Rows(i).Cells(2).Text.ToLower.Trim
                Case "option"
                    ioption = New RadioButtonList
                    ioption.ID = "opt_" & dgPreguntas.Rows(i).Cells(0).Text
                    ioption.RepeatDirection = WebControls.RepeatDirection.Horizontal
                    sOpciones = Split(dgPreguntas.Rows(i).Cells(3).Text.ToUpper, ",")
                    For Each s In sOpciones

                        ioption.Items.Add(New ListItem(s.Trim, s.Trim))
                    Next
                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.RowFilter = "id_pregunta=" & dgPreguntas.Rows(i).Cells(0).Text & ""
                        If dt.DefaultView.Count > 0 Then
                            Try
                                ioption.Items.FindByValue(dt.DefaultView(0)("valor")).Selected = True
                            Catch ex As Exception

                            End Try

                        End If
                    End If



                    dgPreguntas.Rows(i).FindControl("PLHOLDER").Controls.Add(ioption)

                Case "checkl"
                    ichkl = New CheckBoxList
                    ichkl.ID = "chkl_" & dgPreguntas.Rows(i).Cells(0).Text
                    ichkl.RepeatDirection = WebControls.RepeatDirection.Horizontal
                    sOpciones = Split(dgPreguntas.Rows(i).Cells(3).Text.ToUpper, ",")
                    For Each s In sOpciones

                        ichkl.Items.Add(New ListItem(s.Trim, s.Trim))
                    Next
                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.RowFilter = "id_pregunta=" & dgPreguntas.Rows(i).Cells(0).Text & ""
                        If dt.DefaultView.Count > 0 Then
                            Try
                                ichkl.Items.FindByValue(dt.DefaultView(0)("valor")).Selected = True
                            Catch ex As Exception

                            End Try

                        End If
                    End If
                Case "text"
                    itext = New TextBox
                    itext.ID = "txt_" & dgPreguntas.Rows(i).Cells(0).Text
                    itext.Style.Value = "width:830px;height:60px;"
                    itext.TextMode = TextBoxMode.MultiLine
                    itext.CssClass = "lstM"
                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.RowFilter = "id_pregunta=" & dgPreguntas.Rows(i).Cells(0).Text & ""
                        If dt.DefaultView.Count > 0 Then
                            For Each s In dt.DefaultView
                                Try
                                    itext.Text = itext.Text & s("valor")
                                Catch ex As Exception

                                End Try

                            Next

                        End If
                    End If

                    dgPreguntas.Rows(i).FindControl("PLHOLDERTXT").Controls.Add(itext)
                Case "image"
                   

                    sOpciones = Split(dgPreguntas.Rows(i).Cells(3).Text.ToUpper, ",")
                    For Each s In sOpciones
                        iimg = New ImageButton
                        iimg.ID = "iimg_" & dgPreguntas.Rows(i).Cells(0).Text
                        'iimg.Style.Value = "width:830px;height:60px;"
                        iimg.ImageUrl = s.Trim
                        dgPreguntas.Rows(i).FindControl("PLHOLDER").Controls.Add(iimg)
                         
                    Next

                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.RowFilter = "id_pregunta=" & dgPreguntas.Rows(i).Cells(0).Text & ""
                        If dt.DefaultView.Count > 0 Then
                            Try
                                ' ioption.Items.FindByValue(dt.DefaultView(0)("valor")).Selected = True
                            Catch ex As Exception

                            End Try

                        End If
                    End If

                     
                Case Else

            End Select
        Next





    End Sub
    Function EnviarSMS() As DataTable
        Dim sqry As String, dt As New DataTable, dt2 As New DataTable, itext As String = ""
        Dim i As Integer, b As Boolean = False
        sqry = "SELECT b.descripcion,a.valor, b.tcontrol , a.id_linea FROM EncuestaServicioMZD a inner join EncuestaServicioMZDconfig b on a.tcuestionario=b.tcuestionario and a.id_pregunta=b.id_pregunta  where a.orden = '" & Session("Orden") & "' and a.TCUESTIONARIO=" & TCUESTIONARIO & "  order by a.id_pregunta asc"

        dt = BDClass.SQLtoDataTable(sqry, False)
        dt2 = dt.Clone



        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("tcontrol").ToString.ToLower.Trim <> "text" Then
                If dt.Rows(i).Item("valor").ToString.Trim.ToLower <> "si" And _
                            dt.Rows(i).Item("valor").ToString.Trim.ToLower <> "totalmente satisfecho" Then
                    dt2.ImportRow(dt.Rows(i))
                    b = True

                End If
            End If

        Next
        dt.DefaultView.RowFilter = "tcontrol='text'  "
        dt.DefaultView.Sort = "id_linea asc "
        If dt.DefaultView.Count > 0 Then
            For Each s In dt.DefaultView
                Try
                    itext = itext & s("valor")
                Catch ex As Exception

                End Try

            Next

        End If
        dt2.Rows.Add(New Object() {"comentarios", itext, "text", "1"})
        'For i = 0 To dt.Select.Count - 1
        '    If dt.Rows(i).Item("valor").ToString.Trim.ToLower = "no" Or _
        '    dt.Rows(i).Item("valor").ToString.Trim.ToLower = "satisfecho" Or _
        '    dt.Rows(i).Item("valor").ToString.Trim.ToLower = "poco satisfecho" Or _
        '    dt.Rows(i).Item("valor").ToString.Trim.ToLower = "nada satisfecho" Then
        '        dt2.ImportRow(dt.Rows(i))

        '    End If
        'Next

        ' System.IO.File.AppendAllText("C:\capital\logs\MAIL.txt", vbCrLf & dt2.rows.count & "_" & dt.rows.count & "_" & b & vbCrLf)

        If b = False Then
            dt2.Rows.Clear()
        End If
        Return dt2
    End Function
    Function EnviarMail() As DataTable
        Dim sqry As String, dt As New DataTable, dt2 As New DataTable, itext As String = ""
        Dim i As Integer
        sqry = "SELECT b.descripcion,a.valor, b.tcontrol , a.id_linea FROM EncuestaServicioMZD a inner join EncuestaServicioMZDconfig b on a.tcuestionario=b.tcuestionario and a.id_pregunta=b.id_pregunta  where a.orden = '" & Session("Orden") & "' and a.TCUESTIONARIO=" & TCUESTIONARIO & "  order by a.id_pregunta asc"

        dt = BDClass.SQLtoDataTable(sqry, False)
        dt2 = dt.Clone
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("tcontrol").ToString.ToLower.Trim <> "text" Then
                If dt.Rows(i).Item("valor").ToString.Trim.ToLower.Trim = "no" Or _
                            dt.Rows(i).Item("valor").ToString.Trim.ToLower.Trim = "satisfecho" Or _
                            dt.Rows(i).Item("valor").ToString.Trim.ToLower.Trim = "poco satisfecho" Or _
                            dt.Rows(i).Item("valor").ToString.Trim.ToLower.Trim = "nada satisfecho" Then
                    dt2.ImportRow(dt.Rows(i))

                End If
            End If

        Next
        dt.DefaultView.RowFilter = "tcontrol='TEXT'  "
        dt.DefaultView.Sort = "id_linea asc "
        If dt.DefaultView.Count > 0 Then
            For Each s In dt.DefaultView
                Try
                    itext = itext & s("valor")
                Catch ex As Exception

                End Try

            Next

        End If
        dt2.Rows.Add(New Object() {"Comentarios: ", itext, "text", "1"})
       

        Return dt2
    End Function
    Protected Sub imgFin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim I As Integer = dgPreguntas.PageIndex
        cmdGuardar1(I)
        Dim dt As DataTable = EnviarSMS()
        Dim sqry As String = "", sms As String = ""

        If dt.Rows.Count > 0 Then

            Dim OBJMAIL As CRMEnvioCorreos.Mail




            OBJMAIL = New CRMEnvioCorreos.Mail
            OBJMAIL.From = System.Web.Configuration.WebConfigurationManager.AppSettings.Item("MailFROM").ToString
            OBJMAIL.MailAddress = System.Web.Configuration.WebConfigurationManager.AppSettings.Item("MailAddress").ToString
            OBJMAIL.MailServer = System.Web.Configuration.WebConfigurationManager.AppSettings.Item("MailSMTP").ToString
            OBJMAIL.MailUId = System.Web.Configuration.WebConfigurationManager.AppSettings.Item("MailAddress").ToString
            OBJMAIL.MailPwd = System.Web.Configuration.WebConfigurationManager.AppSettings.Item("MailPwd").ToString

            OBJMAIL.TO = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "CorreoTo")
            OBJMAIL.CC = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "CorreoCC")
            OBJMAIL.Subject = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "correoSubject")
            OBJMAIL.Body = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "correoBody")

            OBJMAIL.Body = Replace(OBJMAIL.Body, "/cliente/", " " & Session("cliente") & " ")
            OBJMAIL.Body = Replace(OBJMAIL.Body, "/orden/", " " & Session("orden") & " ")
            OBJMAIL.Body = Replace(OBJMAIL.Body, "/vehiculo/", " " & Session("tipoaauto") & " ")

            OBJMAIL.Subject = Replace(OBJMAIL.Subject, "/cliente/", " " & Session("cliente") & " ")
            OBJMAIL.Subject = Replace(OBJMAIL.Subject, "/orden/", " " & Session("orden") & " ")
            OBJMAIL.Subject = Replace(OBJMAIL.Subject, "/vehiculo/", " " & Session("tipoaauto") & " ")

            'OBJMAIL.Body = "El cliente " & Session("Cliente").ToString.Trim & " con la orden " & Session("Orden").ToString.Trim & " y auto " & Session("tipoaauto").ToString.Trim & " contesto las siguientes preguntas" & vbCrLf & vbCrLf
            'OBJMAIL.Subject = "Encuesta de Satisfacción del Ciente (Servicio), cliente insatisfecho " & Session("Cliente").ToString.Trim & "  Orden " & Session("Orden").ToString.Trim

            OBJMAIL.Body = OBJMAIL.Body & vbCrLf & vbCrLf
            For I = 0 To dt.Rows.Count - 1
                OBJMAIL.Body = OBJMAIL.Body & dt.Rows(I).Item(0).ToString.Trim & vbCrLf
                OBJMAIL.Body = OBJMAIL.Body & dt.Rows(I).Item(1).ToString.Trim & vbCrLf
                OBJMAIL.Body = OBJMAIL.Body & vbCrLf & vbCrLf

            Next



            'RESPONSE.WRITE("HERE")
            Session("EstByNomEstMensaje") = OBJMAIL.EnviaMail3(Nothing, True, 587)
            If Session("EstByNomEstMensaje") = "CorreoEnviado" Then
                BDClass.inErr(vbCrLf & "correcto" & vbCrLf, "enviomail.txt")

            Else
                BDClass.inErr(vbCrLf & Session("EstByNomEstMensaje") & vbCrLf, "enviomail.txt")

            End If



        End If



        ' End If

        Session.Remove("Orden")
        Session.Remove("Cliente")
        pnlFooter.Visible = False
        Session("FinVisible") = False
        Session("ASVisible") = True
        MultiView1.ActiveViewIndex = 0

    End Sub




End Class
