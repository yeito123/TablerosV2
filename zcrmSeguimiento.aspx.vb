Imports TablerosV2LibTypes

Partial Public Class zcrmSeguimiento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("Usuario") Is Nothing Then
        '    RESPONSE.REDIRECT("Login.aspx")
        'End If

        'Page.GetPostBackEventReference(Page)
        If Not Page.IsPostBack Then
            txtFecha.Text = Date.Now.ToShortDateString
            txtFechaFin.Text = Date.Now.ToShortDateString
            LlenaGrid(True)
            filtrar()
        Else
            If Session("dtRsultados") Is Nothing Then
                LlenaGrid(True)
                'End If
            End If
        End If

    End Sub
    Sub LlenaGrid(ByVal bRestablecer As Boolean)
        Dim dt As New DataTable
        Dim sqry As String = ""
       
        'Dim sCamposBase() As String = New String() {"Orden", "Asesor", "ComExtra", "Fecha_Captura"}

        sqry = "SELECT distinct Orden, Nom_Cliente, min(Fecha_Captura) as fecha_captura, estatus, fecha_estatus from EncuestaServicioMZD  group by orden,NOM_CLIENTE, ESTATUS, FECHA_ESTATUS "
        If bRestablecer Then

            dt = BDClass.SQLtoDataTable(sqry, True)
            Session("dtRsultados") = dt
        Else
            If Session("dtRsultados") Is Nothing Then

                dt = BDClass.SQLtoDataTable(sqry, True)
                Session("dtRsultados") = dt
            Else
                dt = Session("dtRsultados")
            End If
        End If
        'dt.DefaultView.Sort = "Orden ASC"
        Me.dg1.DataSource = dt
        dg1.CurrentPageIndex = 0
        dg1.DataBind()
    End Sub

    'Protected Sub GridView1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg1.ItemCommand
    '    If e.CommandName = "Detalle" Then
    '        Session("VIN") = dg1.Items(e.Item.ItemIndex).Cells(2).Text
    '        Session("ID_CLIENTE") = dg1.Items(e.Item.ItemIndex).Cells(3).Text
    '        Session("NOMBRE_CLIENTE") = dg1.Items(e.Item.ItemIndex).Cells(4).Text
    '        Session("CurrentPageIndex") = dg1.CurrentPageIndex
    '        Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "AbrirPop", "<script>  fAbrirPop();</script>")



    '    End If

    'End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        'Dim objapp As New APPClassCRM
        'Dim dt As DataTable = objapp.ObtenUsuarios

        'If Not Session("EstReasignar") Is Nothing Then
        '    Exit Sub
        'End If

        'Dim dtSource As DataTable

        'If Session("idClase").ToString.Trim.ToLower <> "administrador" Then



        '    dtSource = objapp.ObtenerEstrategiasUsrActivas(Session("Usuario").ToString)


        '    'For i = 0 To dtSource.Rows.Count - 1
        '    '    Try
        '    '        If (CDate(dtSource.Rows(i).Item("FechaInicial").ToString.Trim) > Now.Date Or CDate(dtSource.Rows(i).Item("FechaFinal").ToString.Trim) < Now.Date) And CInt(dtSource.Rows(i).Item("Estatus")) = 0 Then
        '    '            objapp.ActualizaEstrategiasEstatus(dtSource.Rows(i).Item("ID_ASIGNACION").ToString.Trim, dtSource.Rows(i).Item("UsuarioAsignado").ToString.Trim, dtSource.Rows(i).Item("Descripcion").ToString.Trim, 1)
        '    '        End If
        '    '    Catch ex As Exception

        '    '    End Try
        '    'Next

        '    'dtSource = objapp.ObtenerEstrategiasUsrActivas(Session("Usuario").ToString)

        'Else
        '    If Session("EstByNomEst") Is Nothing Or Session("EstByNomEst") = "" Then

        '    ElseIf Session("EstByNomEst") = "C" Then
        '        'MPGV.Show()
        '        Exit Sub
        '    ElseIf Session("EstByNomEst") = "E" Then
        '        'MPGV.Show()
        '        Exit Sub
        '    ElseIf Session("EstByNomEst") = "I" Then

        '        'MPGV.Show()
        '        Exit Sub
        '    Else

        '    End If

        '    Try
        '        If Session("EstByUsr") Is Nothing Or Session("EstByUsr") = "--" Then
        '            dtSource = objapp.ObtenerEstrategiasAll
        '        Else

        '            dtSource = objapp.ObtenerEstrategiasUsr(Session("EstByUsr"))
        '        End If
        '    Catch
        '        dtSource = objapp.ObtenerEstrategiasAll
        '    End Try

        '   


        '    'For i = 0 To dtSource.Rows.Count - 1
        '    '    Try
        '    '        If (CDate(dtSource.Rows(i).Item("FechaInicial").ToString.Trim) > Now.Date Or CDate(dtSource.Rows(i).Item("FechaFinal").ToString.Trim) < Now.Date) And CInt(dtSource.Rows(i).Item("Estatus")) = 0 Then
        '    '            objapp.ActualizaEstrategiasEstatus(dtSource.Rows(i).Item("ID_ASIGNACION").ToString.Trim, dtSource.Rows(i).Item("UsuarioAsignado").ToString.Trim, dtSource.Rows(i).Item("Descripcion").ToString.Trim, 1)
        '    '        End If
        '    '    Catch ex As Exception

        '    '    End Try
        '    'Next
        '    Try
        '        If Session("EstByUsr") Is Nothing Or Session("EstByUsr") = "--" Then
        '            dtSource = objapp.ObtenerEstrategiasAll
        '        Else
        '            dtSource = objapp.ObtenerEstrategiasUsr(Session("EstByUsr"))
        '        End If
        '    Catch
        '        dtSource = objapp.ObtenerEstrategiasAll
        '    End Try

        '    If (Not Session("EstByEst") Is Nothing) And (Session("EstByEst") <> "--") Then
        '        Dim drdtSource() As DataRow = dtSource.Copy.Select("estatus=" & Session("EstByEst") & "")
        '        dtSource.Clear()

        '        For i = 0 To drdtSource.Length - 1
        '            dtSource.Rows.Add(drdtSource(i).ItemArray)
        '        Next
        '    Else
        '        Session("EstByEst") = "0"
        '        'cboStatus.Items.FindByValue(Session("EstByEst")).Selected = True
        '        Dim drdtSource() As DataRow = dtSource.Copy.Select("estatus=" & Session("EstByEst") & "")
        '        dtSource.Clear()

        '        For i = 0 To drdtSource.Length - 1
        '            dtSource.Rows.Add(drdtSource(i).ItemArray)
        '        Next
        '    End If

        '    dt = New DataTable

        'End If
        'dtSource = objapp.ObtenerEstrategiasParaRenovar()

        'For i = 0 To dtSource.Rows.Count - 1
        '    Try
        '        objapp.ActualizaEstrategiasAutorenovable(dtSource.Rows(i).Item("ID_ASIGNACION").ToString.Trim, dtSource.Rows(i).Item("UsuarioAsignado").ToString.Trim, dtSource.Rows(i).Item("Descripcion").ToString.Trim)
        '    Catch ex As Exception

        '    End Try
        'Next
    End Sub

    Protected Sub GridView1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg1.ItemCommand
        If e.CommandName = "Detalle" Then

            Session("idencuestaservicio") = "1"
            Session("Orden") = dg1.Items(e.Item.ItemIndex).Cells(0).Text()
            Session("nom_cliente") = dg1.Items(e.Item.ItemIndex).Cells(1).Text()
            Response.Redirect("ZCRMCUESTIONARIODETALLE.aspx")
        ElseIf e.CommandName = "EntregaDetalle" Then
            Session("idencuestaservicio") = "1"
            Session("Orden") = dg1.Items(e.Item.ItemIndex).Cells(0).Text()
            Session("nom_cliente") = dg1.Items(e.Item.ItemIndex).Cells(1).Text()
            Response.Redirect("ZCRMCUESTIONARIOENTREGADETALLE.aspx")
        End If
    End Sub
    Protected Sub dg1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dg1.PageIndexChanged
        dg1.CurrentPageIndex = e.NewPageIndex
        Dim dt As New DataTable
        If Not Session("dtRsultados") Is Nothing Then
            dt = Session("dtRsultados")
        End If
        dg1.DataSource = dt
        dg1.DataBind()
    End Sub

    Sub LlenaContadores()
        Dim DTResul As New DataTable
        DTResul = Session("dtRsultados")


        lblNumClientes.Text = DTResul.DefaultView.Count



    End Sub
    Sub filtrar()
        Dim dt As New DataTable
        dt = Session("dtRsultados")
        Dim sffiltro As String = "FECHA_CAPTURA>='" & txtFecha.Text & "' and FECHA_CAPTURA<='" & txtFechaFin.Text & "'"

        If txtCliente.Text.Trim.Length > 0 Then
            If sffiltro.Length > 0 Then
                sffiltro = "NOM_CLIENTE LIKE '%" & txtCliente.Text.Trim & "%' AND " & sffiltro
            Else
                sffiltro = "NOM_CLIENTE LIKE '%" & txtCliente.Text.Trim & "%'"
            End If
            ' dt.DefaultView.RowFilter = sffiltro
        End If

        If txtReferencia.Text.Trim.Length > 0 Then
            If sffiltro.Length > 0 Then
                sffiltro = "orden LIKE '%" & txtReferencia.Text.Trim & "%' AND " & sffiltro
            Else
                sffiltro = "orden LIKE '%" & txtReferencia.Text.Trim & "%'"
            End If
            'dt.DefaultView.RowFilter = sffiltro
        End If
        If cboEstatus.SelectedItem.Value.Trim.Length > 0 Then
            If sffiltro.Length > 0 Then
                sffiltro = "Estatus = '" & cboEstatus.SelectedItem.Value.Trim & "' AND " & sffiltro
            Else
                sffiltro = "Estatus = '" & cboEstatus.SelectedItem.Value.Trim & "'"
            End If
            'dt.DefaultView.RowFilter = sffiltro
        End If
        'If CboAsesor.SelectedItem.Value <> "--" Then
        '    If sffiltro.Length > 0 Then
        '        sffiltro = "ID_ASESOR = '" & CboAsesor.SelectedItem.Value & "' AND " & sffiltro
        '    Else
        '        sffiltro = "ID_ASESOR = '" & CboAsesor.SelectedItem.Value & "'"
        '    End If
        '    '  dt.DefaultView.RowFilter = sffiltro
        'End If
        dt.DefaultView.RowFilter = sffiltro
        Session("dtRsultados") = dt
        Me.dg1.DataSource = dt
        dg1.CurrentPageIndex = 0
        dg1.DataBind()
        LlenaContadores()
    End Sub
    Protected Sub cmdBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        filtrar()
    End Sub


    Protected Sub imgSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSalir.Click
        Session.Remove("idencuestaservicio")
        Session.Remove("Orden")
        Session.Remove("nom_cliente")
        Session.Remove("dtRsultados")
        Response.Redirect("Inicio.aspx")
    End Sub
    Function bSSERVICIOENTREGA(ByVal sOrden As String, ByVal tCuestionario As Integer, ByVal sCliente As String) As Boolean

        Dim dt As New DataTable
        Dim sqry As String = ""
       


        sqry = "SELECT top 1   Orden, Nom_Cliente, Fecha_Captura, estatus, fecha_estatus from EncuestaServicioMZD where Orden='" & sOrden & "'  and tcuestionario=" & tCuestionario & " and nom_cliente='" & sCliente & "' "
        dt = BDClass.SQLtoDataTable(sqry, True)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Protected Sub dg1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg1.PreRender
        Dim i As Integer

        For i = 0 To dg1.Items.Count - 1
            If bSSERVICIOENTREGA(dg1.Items(i).Cells(0).Text, 1, dg1.Items(i).Cells(1).Text.Trim) Then
                CType(dg1.Items(i).FindControl("imgDetalle"), ImageButton).Visible = True
            Else
                CType(dg1.Items(i).FindControl("imgDetalle"), ImageButton).Visible = False
            End If
            If bSSERVICIOENTREGA(dg1.Items(i).Cells(0).Text, 2, dg1.Items(i).Cells(1).Text.Trim) Then
                CType(dg1.Items(i).FindControl("imgEntregaDetalle"), ImageButton).Visible = True
            Else
                CType(dg1.Items(i).FindControl("imgEntregaDetalle"), ImageButton).Visible = False
            End If

        Next

    End Sub
End Class
