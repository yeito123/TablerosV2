Imports TablerosV2LibTypes

Partial Public Class zcrmCuestionarioEntregaDetalle
    Inherits System.Web.UI.Page

    Const TCUESTIONARIO = 2
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtFecha.Text = DateTime.Now.ToString
            llenaAsesores()
            llenaPreguntas()
            'Session("idencuestaservicio") = "2"
            If Session("idencuestaservicio") Is Nothing Then
                iniciavalores("0")
            Else
                txtFechaEstatus.Text = Now.Date.ToShortDateString
                txtOrden.Text = Session("Orden")
                txtCliente.Text = Session("nom_cliente")
                iniciavalores(Session("idencuestaservicio"))

            End If


        Else
            txtFecha.Text = DateTime.Now.ToString
        End If

    End Sub
    Sub llenaPreguntas()

        Dim dt As New DataTable
        Dim sqry As String = ""
        sqry = "SELECT  ID_PREGUNTA, DESCRIPCION, TCONTROL, Opciones FROM EncuestaServicioMZDConfig  where  TCUESTIONARIO=" & TCUESTIONARIO & " order by id_pregunta asc" '  where Tipo='Asesor' order by Nombre_empleado"
        dt = BDClass.SQLtoDataTable(sqry, True)
        dgPreguntas.DataSource = dt
        dgPreguntas.DataBind()

    End Sub

    Sub llenaAsesores()

        Dim dt As New DataTable
        Dim sqry As String = ""
        sqry = "SELECT distinct id_empleado,Nombre_empleado from  dim_vendedor" '  where Tipo='Asesor' order by Nombre_empleado"
        sqry = "SELECT distinct id_empleado,Nombre_empleado from dim_empleado where id_tipo_empleado='VENTAS'    order by Nombre_empleado"

        dt = BDClass.SQLtoDataTable(sqry, True)
        CboAsesor.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            CboAsesor.Items.Add(New ListItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
        Next
    End Sub

    Sub iniciavalores(ByVal bSnIdEcuesta As String)
        CboAsesor.SelectedIndex = -1


        If Not txtOrden.Text = "" Then

            Dim dt As New DataTable
            Dim sqry As String = "", svalor As String = ""
            sqry = "Select Mail, cp, telefono, tipoauto, direccion, colonia, cliente From bi_capnet..V_DatosCliente_ventas where no_orden= '" & Session("Orden") & "'"
            dt = bdclass.SQLtoDataTable(sqry, True)
            If dt.Rows.Count > 0 Then

                txtCliente.Text = IIf(dt.Rows(0).Item("cliente") Is DBNull.Value, "", dt.Rows(0).Item("cliente").ToString)
                txtDireccion.Text = IIf(dt.Rows(0).Item("direccion") Is DBNull.Value, "", dt.Rows(0).Item("direccion").ToString)
                txtColonia.Text = IIf(dt.Rows(0).Item("colonia") Is DBNull.Value, "", dt.Rows(0).Item("colonia").ToString)
                txtTipoAuto.Text = IIf(dt.Rows(0).Item("tipoauto") Is DBNull.Value, "", dt.Rows(0).Item("tipoauto").ToString)
                txtTelefono.Text = IIf(dt.Rows(0).Item("telefono") Is DBNull.Value, "", dt.Rows(0).Item("telefono").ToString)
                txtCP.Text = IIf(dt.Rows(0).Item("cp") Is DBNull.Value, "", dt.Rows(0).Item("cp").ToString)
                txtCorreo.Text = IIf(dt.Rows(0).Item("mail") Is DBNull.Value, "", dt.Rows(0).Item("mail").ToString)
            Else
                txtCliente.Text = "Sin dato"
                txtDireccion.Text = "Sin dato"
                txtColonia.Text = "Sin dato"
                txtTipoAuto.Text = "Sin dato"
                txtTelefono.Text = "Sin dato"
                txtCP.Text = "Sin dato"
                txtCorreo.Text = "Sin dato"
            End If
        End If

        Try
            CboAsesor.Items.FindByValue(Session("ID_ASESOR")).Selected = True
        Catch ex As Exception
        End Try


        If bSnIdEcuesta = "0" Then
            pnlAdicionales.Visible = False
            pnlFooter.Visible = True
            pnlGuardar.Visible = True
            txtFechaEstatus.Visible = False

            cboEstatusLlamada.Visible = False
            lblEstatusLlamada.Visible = False

            lblID.Text = "1"
        ElseIf bSnIdEcuesta = "1" Then



            pnlAdicionales.Visible = True


            txtObservacionesGer.ReadOnly = True
            pnlFooter.Visible = False
            pnlGuardar.Visible = True
            lblID.Text = "1"
            txtCliente.Text = Session("nom_cliente")
            'PosicionaValoreGuardadosxOrden(txtOrden.Text.Trim, txtCliente.Text)
        Else


            pnlAdicionales.Visible = True
            pnlFooter.Visible = False
            pnlGuardar.Visible = True
            txtFechaEstatus.Visible = False

            cboEstatusLlamada.Visible = False
            lblEstatusLlamada.Visible = False
            txtObservacionesSeg.Visible = False
            lblObservacionesSeg.Visible = False
            lblID.Text = "1"
            txtCliente.Text = Session("nom_cliente")
            ' PosicionaValoreGuardadosxOrden(txtOrden.Text, txtCliente.Text)

        End If


    End Sub

    Sub INSERTAR(ByVal sIdPregunta As Integer, ByVal sValor As String)

        Dim dt As New DataTable
        Dim sqry As String = ""
        If sValor.Length < 25 Then
            sqry = "INSERT INTO EncuestaServicioMZD(TCUESTIONARIO,orden,EstatusEncuesta, nom_cliente, id_asesor, fecha_captura, id_pregunta, id_linea, valor) " _
                    & " VALUES(" & TCUESTIONARIO & "," _
                    & "'" & txtOrden.Text.Trim & "',0," _
                    & "'" & txtCliente.Text.Trim & "'," _
                    & "'" & CboAsesor.SelectedItem.Value & "'," _
                    & "cast('" & IIf(Session("sFechaCaptura") Is Nothing, String.Format("{0:s}", CDate(Date.Now.ToShortDateString)), String.Format("{0:s}", CDate(Session("sFechaCaptura")))) & "' as datetime)," _
                    & "" & sIdPregunta & ",1,'" & sValor & "'" _
                    & ")"

            bdclass.ExecuteQuery(sqry, True)

        Else
            Dim ilinea As Integer, a As Integer, desc As String
            ilinea = 1
            a = 1

            Do While Not ilinea >= sValor.Length
                desc = Mid(sValor, ilinea, 25)
                ilinea = ilinea + 25
                sqry = "INSERT INTO EncuestaServicioMZD(TCUESTIONARIO,orden,EstatusEncuesta,nom_cliente, id_asesor, fecha_captura, id_pregunta, id_linea, valor) " _
                    & " VALUES(" & TCUESTIONARIO & "," _
                    & "'" & txtOrden.Text.Trim & "',0," _
                    & "'" & txtCliente.Text.Trim & "'," _
                    & "'" & CboAsesor.SelectedItem.Value & "'," _
                    & "cast('" & String.Format("{0:s}", CDate(Date.Now.ToShortDateString)) & "' as datetime)," _
                    & "" & sIdPregunta & "," & a & ",'" & desc & "'" _
                    & ")"

                BDClass.ExecuteQuery(sqry, True)
                a = a + 1
            Loop
        End If

        If (Not Session("idencuestaservicio") Is Nothing) And cboEstatusLlamada.SelectedItem.Value.Length > 0 Then
            sqry = "update EncuestaServicioMZD set  EstatusEncuesta=" & Session("idencuestaservicio") & ", Fecha_Estatus=cast('" & String.Format("{0:s}", CDate(txtFechaEstatus.Text)) & "' as datetime), EStatus='" & cboEstatusLlamada.SelectedItem.Text & "' where orden='" & txtOrden.Text.Trim & "' and TCUESTIONARIO=" & TCUESTIONARIO & " and nom_cliente='" & txtCliente.Text.Trim & "'"

            BDClass.ExecuteQuery(sqry, True)
        End If

    End Sub

    Protected Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click


        Dim dt As New DataTable
        Dim sqry As String = ""
        sqry = "SELECT * FROM EncuestaServicioMZD where ORDEN = '" & txtOrden.Text.Trim & "' and TCUESTIONARIO=" & TCUESTIONARIO & " and nom_cliente='" & txtCliente.Text.Trim & "'"
        dt = bdclass.SQLtoDataTable(sqry, True)
        If dt.Rows.Count > 0 Then
            Session("sFechaCaptura") = dt.Rows(0).Item("fecha_captura").ToString()

            sqry = "DELETE EncuestaServicioMZD where ORDEN = '" & txtOrden.Text.Trim & "' and TCUESTIONARIO=" & TCUESTIONARIO & " and nom_cliente='" & txtCliente.Text.Trim & "'"
            bdclass.ExecuteQuery(sqry, True)
        Else
            Session.Remove("sFechaCaptura")
        End If

        Dim svalor As String

        For i = 0 To dgPreguntas.Items.Count - 1
            Select Case dgPreguntas.Items(i).Cells(2).Text.ToLower
                Case "option"
                    svalor = obtenValor("opt_" & dgPreguntas.Items(i).Cells(0).Text)
                    INSERTAR(CInt(dgPreguntas.Items(i).Cells(0).Text), svalor)
                Case "text"
                    svalor = obtenValor("txt_" & dgPreguntas.Items(i).Cells(0).Text)
                    INSERTAR(CInt(dgPreguntas.Items(i).Cells(0).Text), svalor)
                Case Else
            End Select

        Next


        If Not Session("idencuestaservicio") Is Nothing Then

            If Session("idencuestaservicio") = "1" Then
                INSERTAR(-1, txtObservacionesSeg.Text)


            Else

                INSERTAR(-2, txtObservacionesGer.Text)


            End If
        End If

        llenaPreguntas()
    End Sub



    Protected Sub ImgBtnRef_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnRef.Click
        Session("Orden") = txtOrden.Text
        If Session("idencuestaservicio") Is Nothing Then
            iniciavalores("0")
        Else
            txtFechaEstatus.Text = Now.Date.ToShortDateString
            iniciavalores(Session("idencuestaservicio"))
        End If
        'PosicionaValoreGuardadosxOrden(txtOrden.Text, txtCliente.Text)
    End Sub
    Private Function obtenValor(ByVal ItemRequest As String) As String
        For Each nRequest As String In Request.Form
            If nRequest.LastIndexOf(ItemRequest.Trim) > -1 Then
                Return Request.Form(nRequest).Trim
            End If
        Next
        Return ""
    End Function
    Protected Sub imgSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSalir.Click


        Session.Remove("Orden")
        Session.Remove("nom_cliente")
        If Session("idencuestaservicio") Is Nothing And Not Session("Otrosencuestaservicio") Is Nothing Then
            Dim sPagina As String = Session("Otrosencuestaservicio")
            Response.Redirect(sPagina)
            Session.Remove("Otrosencuestaservicio")
        End If

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
    Protected Sub cmdVOC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVOC.Click
        If txtOrden.Text.Trim.Length = 0 Then Exit Sub

        Dim dt As New DataTable
        Dim sqry As String = "", svalor As String = ""
        sqry = "Select Mail, cp, telefono, tipoauto, direccion, colonia, cliente, vin From bi_capnet..V_DatosCliente_ventas where no_orden= '" & txtOrden.Text & "'"
        dt = BDClass.SQLtoDataTable(sqry, True)

        If dt.Rows.Count > 0 Then
            Session("nombre_Cliente") = dt.Rows(0)("cliente")
            Session("VIN") = dt.Rows(0)("vin").ToString().Trim()
            'Session("N_O") = APPClassCRM.ObtenNorden(Session("VIN"))
            Session.Remove("RefVoc")
            ClientScript.RegisterClientScriptBlock(GetType(Page), "popPrincipal", "<script>      var xwin=window.open('crmcuestionariovoc.aspx', '', 'status=yes,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=yes,modal=yes,dependable=yes;');xwin.moveTo(0,0); </script>")

        End If


    End Sub

    Private Sub dgPreguntas_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPreguntas.PreRender
        Dim ioption As RadioButtonList, itext As TextBox
        Dim sOpciones() As String
        Dim sqry As String, dt As New DataTable
        'Session("Orden") = txtOrden.Text
        'Session("Cliente") = txtCliente.Text
        sqry = "SELECT * FROM EncuestaServicioMZD where orden = '" & Session("Orden") & "' and TCUESTIONARIO=" & TCUESTIONARIO & " and nom_cliente='" & Session("Cliente") & "' order by id_pregunta asc"
        sqry = "SELECT * FROM EncuestaServicioMZD where orden = '" & Session("Orden") & "' and TCUESTIONARIO=" & TCUESTIONARIO & "  order by id_pregunta asc"

        dt = BDClass.SQLtoDataTable(sqry, True)



        If dt.Rows.Count > 0 Then
            txtCliente.Text = dt.Rows(0).Item("NOM_CLIENTE").ToString.Trim
            CboAsesor.SelectedIndex = -1
            Try
                CboAsesor.Items.FindByValue(dt.Rows(0).Item("ID_ASESOR").ToString).Selected = True
            Catch ex As Exception
            End Try
        End If



        For i = 0 To dgPreguntas.Items.Count - 1

            Select Case dgPreguntas.Items(i).Cells(2).Text.ToLower
                Case "option"
                    ioption = New RadioButtonList
                    ioption.ID = "opt_" & dgPreguntas.Items(i).Cells(0).Text
                    ioption.RepeatDirection = WebControls.RepeatDirection.Horizontal
                    sOpciones = Split(dgPreguntas.Items(i).Cells(3).Text.ToUpper, ",")
                    For Each s In sOpciones

                        ioption.Items.Add(New ListItem(s.Trim, s.Trim))
                    Next
                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.RowFilter = "id_pregunta=" & dgPreguntas.Items(i).Cells(0).Text & ""
                        If dt.DefaultView.Count > 0 Then
                            Try
                                ioption.Items.FindByValue(dt.DefaultView(0)("valor")).Selected = True
                            Catch ex As Exception

                            End Try

                        End If
                    End If



                    dgPreguntas.Items(i).FindControl("PLHOLDER").Controls.Add(ioption)
                Case "text"
                    itext = New TextBox
                    itext.ID = "txt_" & dgPreguntas.Items(i).Cells(0).Text
                    itext.Style.Value = "width:830px;height:60px;"
                    itext.TextMode = TextBoxMode.MultiLine
                    itext.CssClass = "lstM"
                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.RowFilter = "id_pregunta=" & dgPreguntas.Items(i).Cells(0).Text & ""
                        If dt.DefaultView.Count > 0 Then
                            For Each s In dt.DefaultView
                                Try
                                    itext.Text = itext.Text & s("valor")
                                Catch ex As Exception

                                End Try

                            Next

                        End If
                    End If

                    dgPreguntas.Items(i).FindControl("PLHOLDERTXT").Controls.Add(itext)
                Case Else

            End Select
        Next

        If dt.Rows.Count > 0 Then
            dt.DefaultView.RowFilter = "id_pregunta=-1"
            If dt.DefaultView.Count > 0 Then
                For Each s In dt.DefaultView
                    txtObservacionesSeg.Text = txtObservacionesSeg.Text & s("valor")
                Next

            End If
        End If
        If dt.Rows.Count > 0 Then
            dt.DefaultView.RowFilter = "id_pregunta=-2"
            If dt.DefaultView.Count > 0 Then
                For Each s In dt.DefaultView
                    txtObservacionesGer.Text = txtObservacionesGer.Text & s("valor")
                Next

            End If
        End If


    End Sub
End Class
