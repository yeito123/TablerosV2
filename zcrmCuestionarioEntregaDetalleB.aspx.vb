Imports TablerosV2LibTypes

Partial Public Class zcrmCuestionarioEntregaDetalleB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtFecha.Text = DateTime.Now.ToString
            llenaAsesores()
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
    Sub llenaAsesores()

        Dim dt As New DataTable
        Dim sqry As String = ""
        sqry = "SELECT distinct id_empleado,Nombre_empleado from  dim_vendedor" '  where Tipo='Asesor' order by Nombre_empleado"
        dt = bdclass.SQLtoDataTable(sqry, True)
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

            'TXT10.ReadOnly = True
            ''TXT9.ReadOnly = True
            ''TXT11.ReadOnly = True
            'OPT1.Enabled = False
            'OPT2.Enabled = False
            'OPT3.Enabled = False
            'OPT4.Enabled = False
            'OPT5.Enabled = False
            'OPT6.Enabled = False
            'OPT7.Enabled = False
            'OPT8.Enabled = False

            pnlAdicionales.Visible = True


            txtObservacionesGer.ReadOnly = True
            pnlFooter.Visible = False
            pnlGuardar.Visible = True
            lblID.Text = "1"
            txtCliente.Text = Session("nom_cliente")
            PosicionaValoreGuardadosxOrden(txtOrden.Text.Trim, txtCliente.Text)
        Else

            TXT10.ReadOnly = True
            'TXT9.ReadOnly = True
            'TXT11.ReadOnly = True
            OPT1.Enabled = False
            OPT2.Enabled = False
            OPT3.Enabled = False
            OPT4.Enabled = False
            OPT5.Enabled = False
            'OPT6.Enabled = False
            'OPT7.Enabled = False
            'OPT8.Enabled = False
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
            PosicionaValoreGuardadosxOrden(txtOrden.Text, txtCliente.Text)

        End If


    End Sub

    Sub INSERTAR(ByVal sIdPregunta As Integer, ByVal sValor As String)

        Dim dt As New DataTable
        Dim sqry As String = ""
        If sValor.Length < 25 Then
            sqry = "INSERT INTO EncuestaServicioMZD(TCUESTIONARIO,orden,EstatusEncuesta, nom_cliente, id_asesor, fecha_captura, id_pregunta, id_linea, valor) " _
                    & " VALUES(2," _
                    & "'" & txtOrden.Text.Trim & "',0," _
                    & "'" & txtCliente.Text.Trim & "'," _
                    & "'" & CboAsesor.SelectedItem.Value & "'," _
                    & "cast('" & IIf(Session("sFechaCaptura") Is Nothing, String.Format("{0:s}", CDate(Date.Now.ToShortDateString)), String.Format("{0:s}", CDate(Session("sFechaCaptura")))) & "' as datetime)," _
                    & "" & sIdPregunta & ",1,'" & sValor & "'" _
                    & ")"

            BDClass.ExecuteQuery(sqry, True)

        Else
            Dim ilinea As Integer, a As Integer, desc As String
            ilinea = 1
            a = 1

            Do While Not ilinea >= sValor.Length
                desc = Mid(sValor, ilinea, 25)
                ilinea = ilinea + 25
                sqry = "INSERT INTO EncuestaServicioMZD(TCUESTIONARIO,orden,EstatusEncuesta,nom_cliente, id_asesor, fecha_captura, id_pregunta, id_linea, valor) " _
                    & " VALUES(2," _
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
            sqry = "update EncuestaServicioMZD set  EstatusEncuesta=" & Session("idencuestaservicio") & ", Fecha_Estatus=cast('" & String.Format("{0:s}", CDate(txtFechaEstatus.Text)) & "' as datetime), EStatus='" & cboEstatusLlamada.SelectedItem.Text & "' where orden='" & txtOrden.Text.Trim & "' and TCUESTIONARIO=2 and nom_cliente='" & txtCliente.Text.Trim & "'"

            BDClass.ExecuteQuery(sqry, True)
        End If

    End Sub

    Protected Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click


        Dim dt As New DataTable
        Dim sqry As String = ""
        sqry = "SELECT * FROM EncuestaServicioMZD where ORDEN = '" & txtOrden.Text.Trim & "' and TCUESTIONARIO=2 and nom_cliente='" & txtCliente.Text.Trim & "'"
        dt = BDClass.SQLtoDataTable(sqry, True)
        If dt.Rows.Count > 0 Then
            Session("sFechaCaptura") = dt.Rows(0).Item("fecha_captura").ToString()

            sqry = "DELETE EncuestaServicioMZD where ORDEN = '" & txtOrden.Text.Trim & "' and TCUESTIONARIO=2 and nom_cliente='" & txtCliente.Text.Trim & "'"
            BDClass.ExecuteQuery(sqry, True)
        Else
            Session.Remove("sFechaCaptura")
        End If

        If Not OPT1.SelectedItem Is Nothing Then INSERTAR(1, OPT1.SelectedItem.Value)
        If Not OPT2.SelectedItem Is Nothing Then INSERTAR(2, OPT2.SelectedItem.Value)
        If Not OPT3.SelectedItem Is Nothing Then INSERTAR(3, OPT3.SelectedItem.Value)
        If Not OPT4.SelectedItem Is Nothing Then INSERTAR(4, OPT4.SelectedItem.Value)
        If Not OPT5.SelectedItem Is Nothing Then INSERTAR(5, OPT5.SelectedItem.Value)
        'If Not OPT6.SelectedItem Is Nothing Then INSERTAR(6, OPT6.SelectedItem.Value)
        'If Not OPT7.SelectedItem Is Nothing Then INSERTAR(7, OPT7.SelectedItem.Value)
        'If Not OPT8.SelectedItem Is Nothing Then INSERTAR(8, OPT8.SelectedItem.Value)
        'INSERTAR(9, TXT9.Text)
        INSERTAR(10, TXT10.Text)
        'INSERTAR(11, TXT11.Text)


        If Not Session("idencuestaservicio") Is Nothing Then

            If Session("idencuestaservicio") = "1" Then
                'If Not optAdic.SelectedItem Is Nothing Then INSERTAR(12, optAdic.SelectedItem.Value)
                INSERTAR(13, txtObservacionesSeg.Text)

                'INSERTAR(15, txtRespuesta1.Text)
                'INSERTAR(16, txtRespuesta2.Text)
                'INSERTAR(17, txtRespuesta3.Text)
                'INSERTAR(18, txtRespuesta4.Text)
                'INSERTAR(19, txtRespuesta5.Text)
                'INSERTAR(20, txtNoPorque.Text)
            Else
                'If Not optAdic.SelectedItem Is Nothing Then INSERTAR(12, optAdic.SelectedItem.Value)

                INSERTAR(14, txtObservacionesGer.Text)
                'INSERTAR(15, txtRespuesta1.Text)
                'INSERTAR(16, txtRespuesta2.Text)
                'INSERTAR(17, txtRespuesta3.Text)
                'INSERTAR(18, txtRespuesta4.Text)
                'INSERTAR(19, txtRespuesta5.Text)
                'INSERTAR(20, txtNoPorque.Text)

            End If
        End If


    End Sub

    Sub PosicionaValoreGuardadosxOrden(ByVal sOrden As String, ByVal scliente As String)

        Dim dt As New DataTable, i As Integer
        Dim sqry As String = "", svalor As String = "", sQ9 As String = "", sQ10 As String = "", sQ11 As String = ""
        Dim sQ13 As String = "", sQ14 As String = "", sQ15 As String = "", sQ16 As String = "", sQ17 As String = ""
        Dim sQ18 As String = "", sQ19 As String = "", sQ20 As String = ""
        sqry = "SELECT * FROM EncuestaServicioMZD where orden = '" & sOrden & "' and TCUESTIONARIO=2 and nom_cliente='" & scliente & "' order by id_pregunta asc"
        dt = BDClass.SQLtoDataTable(sqry, True)
        OPT1.SelectedIndex = -1
        OPT2.SelectedIndex = -1
        OPT3.SelectedIndex = -1
        OPT4.SelectedIndex = -1
        OPT5.SelectedIndex = -1
        'OPT6.SelectedIndex = -1
        'OPT7.SelectedIndex = -1
        'OPT8.SelectedIndex = -1
        ' optAdic.SelectedIndex = -1

        ' TXT9.Text = ""
        TXT10.Text = ""
        'TXT11.Text = ""
        ' txtNoPorque.Text = ""
        'txtRespuesta1.Text = ""
        'txtRespuesta2.Text = ""
        'txtRespuesta3.Text = ""
        'txtRespuesta4.Text = ""
        'txtRespuesta5.Text = ""
        txtObservacionesSeg.Text = ""
        txtObservacionesGer.Text = ""

        'txtRespuesta1.Text = ""
        For i = 0 To dt.Rows.Count - 1
            txtCliente.Text = dt.Rows(i).Item("NOM_CLIENTE").ToString.Trim
            CboAsesor.SelectedIndex = -1
            Try
                CboAsesor.Items.FindByValue(dt.Rows(i).Item("ID_ASESOR").ToString).Selected = True
            Catch ex As Exception
            End Try
            Select Case CInt(dt.Rows(i).Item("id_pregunta").ToString)
                Case 1
                    OPT1.Items.FindByValue(dt.Rows(i).Item("valor").ToString.Trim).Selected = True

                Case 2
                    OPT2.Items.FindByValue(dt.Rows(i).Item("valor").ToString.Trim).Selected = True
                Case 3
                    OPT3.Items.FindByValue(dt.Rows(i).Item("valor").ToString.Trim).Selected = True
                Case 4
                    OPT4.Items.FindByValue(dt.Rows(i).Item("valor").ToString.Trim).Selected = True
                Case 5
                    OPT5.Items.FindByValue(dt.Rows(i).Item("valor").ToString.Trim).Selected = True
                    'Case 6
                    '    If dt.Rows(i).Item("valor").ToString.Trim.ToUpper = "SI" Then
                    '        OPT6.SelectedIndex = 0
                    '    Else
                    '        OPT6.SelectedIndex = 1
                    '    End If
                    'Case 7
                    '    If dt.Rows(i).Item("valor").ToString.Trim.ToUpper = "SI" Then
                    '        OPT7.SelectedIndex = 0
                    '    Else
                    '        OPT7.SelectedIndex = 1
                    '    End If
                    'Case 8
                    '    If dt.Rows(i).Item("valor").ToString.Trim.ToUpper = "SI" Then
                    '        OPT8.SelectedIndex = 0
                    '    Else
                    '        OPT8.SelectedIndex = 1
                    '    End If

                    'Case 9
                    '    If sQ9.Trim.Length = 0 Then
                    '        Dim dr_0() As DataRow, k As Integer
                    '        dr_0 = dt.Select("id_pregunta=9", "id_linea asc")
                    '        For k = 0 To dr_0.Length - 1
                    '            sQ9 = sQ9 & dr_0(k).Item("valor").ToString
                    '        Next
                    '        TXT9.Text = sQ9
                    '    End If
                Case 10
                    If sQ10.Trim.Length = 0 Then
                        Dim dr_0() As DataRow, k As Integer
                        dr_0 = dt.Select("id_pregunta=10", "id_linea asc")
                        For k = 0 To dr_0.Length - 1
                            sQ10 = sQ10 & dr_0(k).Item("valor").ToString
                        Next
                        TXT10.Text = sQ10
                    End If
                    'Case 11
                    '    If sQ11.Trim.Length = 0 Then
                    '        Dim dr_0() As DataRow, k As Integer
                    '        dr_0 = dt.Select("id_pregunta=11", "id_linea asc")
                    '        For k = 0 To dr_0.Length - 1
                    '            sQ11 = sQ11 & dr_0(k).Item("valor").ToString
                    '        Next
                    '        TXT11.Text = sQ11
                    '    End If
                    'Case 12
                    '    If dt.Rows(i).Item("valor").ToString.Trim.ToUpper = "SI" Then
                    '        optAdic.SelectedIndex = 0
                    '    Else
                    '        optAdic.SelectedIndex = 1
                    '    End If

                Case 13

                    If sQ13.Trim.Length = 0 Then
                        Dim dr_0() As DataRow, k As Integer
                        dr_0 = dt.Select("id_pregunta=13", "id_linea asc")
                        For k = 0 To dr_0.Length - 1
                            sQ13 = sQ13 & dr_0(k).Item("valor").ToString
                        Next
                        txtObservacionesSeg.Text = sQ13
                    End If
                Case 14

                    If sQ14.Trim.Length = 0 Then
                        Dim dr_0() As DataRow, k As Integer
                        dr_0 = dt.Select("id_pregunta=14", "id_linea asc")
                        For k = 0 To dr_0.Length - 1
                            sQ14 = sQ14 & dr_0(k).Item("valor").ToString
                        Next
                        txtObservacionesGer.Text = sQ14
                    End If


                    'Case 15

                    '    If sQ15.Trim.Length = 0 Then
                    '        Dim dr_0() As DataRow, k As Integer
                    '        dr_0 = dt.Select("id_pregunta=15", "id_linea asc")
                    '        For k = 0 To dr_0.Length - 1
                    '            sQ15 = sQ15 & dr_0(k).Item("valor").ToString
                    '        Next
                    '        txtRespuesta1.Text = sQ15
                    '    End If

                    'Case 16

                    '    If sQ16.Trim.Length = 0 Then
                    '        Dim dr_0() As DataRow, k As Integer
                    '        dr_0 = dt.Select("id_pregunta=16", "id_linea asc")
                    '        For k = 0 To dr_0.Length - 1
                    '            sQ16 = sQ16 & dr_0(k).Item("valor").ToString
                    '        Next
                    '        txtRespuesta2.Text = sQ16
                    '    End If

                    'Case 17

                    '    If sQ17.Trim.Length = 0 Then
                    '        Dim dr_0() As DataRow, k As Integer
                    '        dr_0 = dt.Select("id_pregunta=17", "id_linea asc")
                    '        For k = 0 To dr_0.Length - 1
                    '            sQ17 = sQ17 & dr_0(k).Item("valor").ToString
                    '        Next
                    '        txtRespuesta3.Text = sQ17
                    '    End If
                    'Case 18

                    '    If sQ18.Trim.Length = 0 Then
                    '        Dim dr_0() As DataRow, k As Integer
                    '        dr_0 = dt.Select("id_pregunta=18", "id_linea asc")
                    '        For k = 0 To dr_0.Length - 1
                    '            sQ18 = sQ18 & dr_0(k).Item("valor").ToString
                    '        Next
                    '        txtRespuesta4.Text = sQ18
                    '    End If

                    'Case 19

                    '    If sQ19.Trim.Length = 0 Then
                    '        Dim dr_0() As DataRow, k As Integer
                    '        dr_0 = dt.Select("id_pregunta=19", "id_linea asc")
                    '        For k = 0 To dr_0.Length - 1
                    '            sQ19 = sQ19 & dr_0(k).Item("valor").ToString
                    '        Next
                    '        txtRespuesta5.Text = sQ19
                    '    End If

                    'Case 20

                    '    If sQ20.Trim.Length = 0 Then
                    '        Dim dr_0() As DataRow, k As Integer
                    '        dr_0 = dt.Select("id_pregunta=20", "id_linea asc")
                    '        For k = 0 To dr_0.Length - 1
                    '            sQ20 = sQ20 & dr_0(k).Item("valor").ToString
                    '        Next
                    '        txtNoPorque.Text = sQ20
                    '    End If
            End Select
        Next

    End Sub


    Protected Sub ImgBtnRef_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnRef.Click
        Session("Orden") = txtOrden.Text
        If Session("idencuestaservicio") Is Nothing Then
            iniciavalores("0")
        Else
            txtFechaEstatus.Text = Now.Date.ToShortDateString
            iniciavalores(Session("idencuestaservicio"))
        End If
        PosicionaValoreGuardadosxOrden(txtOrden.Text, txtCliente.Text)
    End Sub
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
            Else
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
End Class
