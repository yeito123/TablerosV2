Imports TablerosV2LibTypes
Partial Public Class zcrmCuestionarioDetalleInventario
    Inherits System.Web.UI.Page

    Const TCUESTIONARIO = 3
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            txtFecha.Text = DateTime.Now.ToString

            llenaAsesores()




            If Not Request("vin") Is Nothing Then
                'Response.Write(Request("vin"))
                ' Response.Redirect(Left(Request.Url.AbsoluteUri.ToString, Len(Request.Url.AbsoluteUri.ToString) - 5))
                ' Session("vin") = Request.QueryString("vin")
                CboVIN.SelectedIndex = CboVIN.Items.IndexOf(CboVIN.Items.FindByText(Request("vin")))

                'For i = 0 To CboVIN.Items.Count - 1
                '    If Request("vin").ToLower.Trim = CboVIN.Items(i).Text.ToLower.Trim Then
                '        CboVIN.SelectedIndex = i
                '        Response.Write(Request("vin"))
                '        Exit For
                '    End If

                'Next
                'Response.Redirect(Left(Request.Url.AbsoluteUri.ToString, Len(Request.Url.AbsoluteUri.ToString) - (Len(Request.Url.AbsoluteUri.ToString) - InStr(Request.Url.AbsoluteUri.ToString, "?vin=")) - 1))
                txtOrden.Text = Request("noorden")
                ImgBtnRef_Click(Nothing, Nothing)
            End If



            '    llenaPreguntas()
            '    'Session("idencuestaservicio") = "2"
            '    If Session("idencuestaservicio") Is Nothing Then
            '        txtOrden.Text = Request("noorden")  'ObtenFolio()
            '        iniciavalores("0")
            '    Else
            '        txtFechaEstatus.Text = Now.Date.ToShortDateString
            '        txtOrden.Text = Session("Orden")
            '        txtCliente.Text = Session("nom_cliente")
            '        iniciavalores(Session("idencuestaservicio"))
            '    End If


            'Else
            '    txtFecha.Text = DateTime.Now.ToString
        End If

    End Sub
    Sub llenaPreguntas()
        
        Dim dt As New DataTable
        Dim sqry As String = ""
        sqry = "SELECT  ID_PREGUNTA, DESCRIPCION, TCONTROL, Opciones FROM EncuestaServicioMZDConfig  where  TCUESTIONARIO=" & TCUESTIONARIO & " order by id_pregunta asc" '  where Tipo='Asesor' order by Nombre_empleado"
        dt = bdclass.SQLtoDataTable(sqry, False)
        dgPreguntas.DataSource = dt
        dgPreguntas.DataBind()

    End Sub
    Sub llenaAsesores()

        Dim dt As New DataTable
        Dim sqry As String = ""
        sqry = "SELECT distinct cliente,vin from  v_DIM_VINES_clientes order by cliente asc, vin asc " '  where Tipo='Asesor' order by Nombre_empleado"
        dt = bdclass.SQLtoDataTable(sqry, False)
        CboVIN.Items.Clear()
        CboVIN2.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            CboVIN.Items.Add(New ListItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0) & "__" & dt.Rows(i).Item(1)))
            CboVIN2.Items.Add(New ListItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0) & "__" & dt.Rows(i).Item(1)))
        Next

    End Sub

    Sub iniciavalores(ByVal bSnIdEcuesta As String)





        Dim dt As New DataTable
        Dim sqry As String = "", svalor As String = ""
        sqry = "Select * From V_DatosCliente where no_orden= '" & Session("Orden") & "'"
        dt = bdclass.SQLtoDataTable(sqry, False)
        If dt.Rows.Count > 0 Then
            txtCliente.Text = IIf(dt.Rows(0).Item("cliente") Is DBNull.Value, "", dt.Rows(0).Item("cliente").ToString)
            txtOP.Text = IIf(dt.Rows(0).Item("op") Is DBNull.Value, "0", dt.Rows(0).Item("op").ToString)
            txtPLACAS.Text = IIf(dt.Rows(0).Item("placas") Is DBNull.Value, "", dt.Rows(0).Item("placas").ToString)
            txtKILOMETRAJE.Text = IIf(dt.Rows(0).Item("kilometraje") Is DBNull.Value, "0", dt.Rows(0).Item("kilometraje").ToString)
            txtFECHAE.Text = IIf(dt.Rows(0).Item("fechaentrada") Is DBNull.Value, Date.Now.ToShortDateString, CDate(dt.Rows(0).Item("fechaentrada").ToString).ToShortDateString)
            txtMARCA.Text = IIf(dt.Rows(0).Item("marca") Is DBNull.Value, "", dt.Rows(0).Item("marca").ToString)
            txtMODELO.Text = IIf(dt.Rows(0).Item("modelo") Is DBNull.Value, "", dt.Rows(0).Item("modelo").ToString)
            txtCOLOR.Text = IIf(dt.Rows(0).Item("color") Is DBNull.Value, "", dt.Rows(0).Item("color").ToString)
            txtFecha.Text = IIf(dt.Rows(0).Item("fechacaptura") Is DBNull.Value, Date.Now.ToShortDateString, CDate(dt.Rows(0).Item("fechacaptura").ToString).ToShortDateString)
            Try
                CboVIN.SelectedIndex = CboVIN.Items.IndexOf(CboVIN.Items.FindByText(IIf(dt.Rows(0).Item("vin") Is DBNull.Value, "", dt.Rows(0).Item("vin").ToString)))
            Catch ex As Exception
            End Try
        ElseIf CboVIN.SelectedIndex > -1 Then
            ' Response.Redirect("here")
            sqry = "Select * From V_DatosCliente where vin= '" & CboVIN.Items(CboVIN.SelectedIndex).Text & "' and idvehiculo='" & Request("idvehiculo") & "' "
            dt = bdclass.SQLtoDataTable(sqry, False)
            If dt.Rows.Count > 0 Then
                txtCliente.Text = IIf(dt.Rows(0).Item("cliente") Is DBNull.Value, "", dt.Rows(0).Item("cliente").ToString)
                txtOP.Text = "0"
                txtPLACAS.Text = IIf(dt.Rows(0).Item("placas") Is DBNull.Value, "", dt.Rows(0).Item("placas").ToString)
                txtKILOMETRAJE.Text = IIf(dt.Rows(0).Item("kilometraje") Is DBNull.Value, "0", dt.Rows(0).Item("kilometraje").ToString)
                txtFECHAE.Text = IIf(dt.Rows(0).Item("fechaentrada") Is DBNull.Value, Date.Now.ToShortDateString, dt.Rows(0).Item("fechaentrada").ToString)
                txtMARCA.Text = IIf(dt.Rows(0).Item("marca") Is DBNull.Value, "", dt.Rows(0).Item("marca").ToString)
                txtMODELO.Text = IIf(dt.Rows(0).Item("modelo") Is DBNull.Value, "", dt.Rows(0).Item("modelo").ToString)
                txtCOLOR.Text = IIf(dt.Rows(0).Item("color") Is DBNull.Value, "", dt.Rows(0).Item("color").ToString)
                txtFecha.Text = IIf(dt.Rows(0).Item("fechacaptura") Is DBNull.Value, Date.Now.ToShortDateString, dt.Rows(0).Item("fechacaptura").ToString)

            Else
                txtCliente.Text = "Sin dato"
                txtOP.Text = "0"
                txtPLACAS.Text = "Sin dato"
                txtKILOMETRAJE.Text = "0"

                txtMARCA.Text = "Sin dato"
                txtMODELO.Text = "Sin dato"
                txtCOLOR.Text = "Sin dato"
                txtFecha.Text = Date.Now.ToShortDateString
                txtFECHAE.Text = Date.Now.ToShortDateString
            End If


        End If




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
            ' PosicionaValoreGuardadosxOrden(txtOrden.Text, txtCliente.Text)
        Else

            'TXT10.ReadOnly = True
            'TXT9.ReadOnly = True
            ''TXT11.ReadOnly = True
            'OPT1.Enabled = False
            'OPT2.Enabled = False
            'OPT3.Enabled = False
            'OPT4.Enabled = False
            'OPT5.Enabled = False
            'OPT6.Enabled = False
            ''OPT7.Enabled = False
            ''OPT8.Enabled = False
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
            'PosicionaValoreGuardadosxOrden(txtOrden.Text, txtCliente.Text)

        End If


    End Sub
   
    Sub INSERTAR(ByVal sIdPregunta As Integer, ByVal sValor As String)
        
        Dim dt As New DataTable
        Dim sqry As String = ""
        If sValor.Length < 25 Then
            sqry = "INSERT INTO EncuestaServicioMZD(TCUESTIONARIO,orden,OP,EstatusEncuesta, nom_cliente,VIN, km, id_asesor,FECHA_ENTRADA, fecha_captura, id_pregunta, id_linea, valor) " _
                    & " VALUES(3," _
                    & "'" & txtOrden.Text.Trim & "','" & txtOP.Text.Trim & "',0," _
                    & "'" & txtCliente.Text.Trim & "'," _
                    & "'" & CboVIN.SelectedItem.Text & "','" & txtKILOMETRAJE.Text & "',NULL,cast('" & String.Format("{0:s}", CDate(txtFECHAE.Text)) & "' as datetime)," _
                    & "cast('" & IIf(Session("sFechaCaptura") Is Nothing, String.Format("{0:s}", CDate(Date.Now.ToShortDateString)), String.Format("{0:s}", CDate(Session("sFechaCaptura")))) & "' as datetime)," _
                    & "" & sIdPregunta & ",1,'" & sValor & "'" _
                    & ")"

            bdclass.ExecuteQuery(sqry, False)

        Else
            Dim ilinea As Integer, a As Integer, desc As String
            ilinea = 1
            a = 1

            Do While Not ilinea >= sValor.Length
                desc = Mid(sValor, ilinea, 25)
                ilinea = ilinea + 25
                sqry = "INSERT INTO EncuestaServicioMZD(TCUESTIONARIO,orden,OP,EstatusEncuesta,nom_cliente,VIN,km, id_asesor,FECHA_ENTRADA, fecha_captura, id_pregunta, id_linea, valor) " _
                    & " VALUES(3," _
                   & "'" & txtOrden.Text.Trim & "','" & txtOP.Text.Trim & "',0," _
                    & "'" & txtCliente.Text.Trim & "'," _
                   & "'" & CboVIN.SelectedItem.Text & "','" & txtKILOMETRAJE.Text & "',NULL,cast('" & String.Format("{0:s}", CDate(txtFECHAE.Text)) & "' as datetime)," _
                    & "cast('" & String.Format("{0:s}", CDate(Date.Now.ToShortDateString)) & "' as datetime)," _
                    & "" & sIdPregunta & "," & a & ",'" & desc & "'" _
                    & ")"

                bdclass.ExecuteQuery(sqry, False)
                a = a + 1
            Loop
        End If

        If (Not Session("idencuestaservicio") Is Nothing) And cboEstatusLlamada.SelectedItem.Value.Length > 0 Then
            sqry = "update EncuestaServicioMZD set  EstatusEncuesta=" & Session("idencuestaservicio") & ", Fecha_Estatus=cast('" & String.Format("{0:s}", CDate(txtFechaEstatus.Text)) & "' as datetime), EStatus='" & cboEstatusLlamada.SelectedItem.Text & "' where orden='" & txtOrden.Text.Trim & "' and TCUESTIONARIO=" & TCUESTIONARIO & " and nom_cliente='" & txtCliente.Text.Trim & "'"
            ' sqry = "update EncuestaServicioMZD set  EstatusEncuesta=" & Session("idencuestaservicio") & ", Fecha_Estatus=cast('" & String.Format("{0:s}", CDate(txtFechaEstatus.Text)) & "' as datetime), EStatus='" & cboEstatusLlamada.SelectedItem.Text & "' where orden='" & txtOrden.Text.Trim & "' and TCUESTIONARIO=" & TCUESTIONARIO & ""
            bdclass.ExecuteQuery(sqry, False)
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
    Protected Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click

        
        Dim dt As New DataTable
        Dim sqry As String = ""
        sqry = "SELECT * FROM EncuestaServicioMZD where ORDEN = '" & txtOrden.Text.Trim & "' and TCUESTIONARIO=" & TCUESTIONARIO & "  "
        ' sqry = "SELECT * FROM EncuestaServicioMZD where ORDEN = '" & txtOrden.Text.Trim & "' and TCUESTIONARIO=" & TCUESTIONARIO & ""
        dt = BDClass.SQLtoDataTable(sqry, False)
        If dt.Rows.Count > 0 Then
            Session("sFechaCaptura") = dt.Rows(0).Item("fecha_captura").ToString()

            sqry = "DELETE EncuestaServicioMZD where ORDEN = '" & txtOrden.Text.Trim & "' and TCUESTIONARIO=" & TCUESTIONARIO & "   "
            '  sqry = "DELETE EncuestaServicioMZD where ORDEN = '" & txtOrden.Text.Trim & "' and TCUESTIONARIO=" & TCUESTIONARIO & " "
            BDClass.ExecuteQuery(sqry, False)
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
                Case "1text"
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
        Session("Cliente") = txtCliente.Text
        If Session("idencuestaservicio") Is Nothing Then
            iniciavalores("0")
        Else
            txtFechaEstatus.Text = Now.Date.ToShortDateString
            iniciavalores(Session("idencuestaservicio"))
        End If
        llenaPreguntas()
    End Sub
    Protected Sub imgSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSalir.Click


        Session.Remove("Orden")
        Session.Remove("nom_cliente")
        If Session("idencuestaservicio") Is Nothing Then
            Response.Redirect("Inicio.aspx")
        Else

            Response.Redirect("zcrmseguimiento.aspx")

        End If

    End Sub
    Protected Sub cmdVOC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVOC.Click
        If txtOrden.Text.Trim.Length = 0 Then Exit Sub
        
        Dim dt As New DataTable
        Dim sqry As String = "", svalor As String = ""
        sqry = "Select Mail, cp, telefono, tipoauto, direccion, colonia, cliente, VIN From bi_capnet..V_DatosCliente where no_orden= '" & Session("Orden") & "'"
        dt = BDClass.SQLtoDataTable(sqry, False)

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
        sqry = "SELECT * FROM EncuestaServicioMZD where orden = '" & Session("Orden") & "' and TCUESTIONARIO=" & TCUESTIONARIO & "   order by id_pregunta asc"
        'sqry = "SELECT * FROM EncuestaServicioMZD where orden = '" & Session("Orden") & "' and TCUESTIONARIO=" & TCUESTIONARIO & "  order by id_pregunta asc"

        dt = BDClass.SQLtoDataTable(sqry, False)






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
                Case "1text"
                    itext = New TextBox
                    itext.ID = "txt_" & dgPreguntas.Items(i).Cells(0).Text
                    itext.Style.Value = "width:80px;"
                    itext.TextMode = TextBoxMode.SingleLine
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



    Protected Sub ImgBtnRef0_Click(sender As Object, e As ImageClickEventArgs) Handles ImgBtnRef0.Click
        iniciavalores("0")
    End Sub
End Class
