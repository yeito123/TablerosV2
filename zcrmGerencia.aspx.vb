Imports TablerosV2LibTypes

Partial Public Class zcrmGerencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("Usuario") Is Nothing Then
        '    RESPONSE.REDIRECT("Login.aspx")
        'End If

        'Page.GetPostBackEventReference(Page)
        If Not Page.IsPostBack Then
            LlenaGrid(True)
            txtFecha.Text = Date.Now.ToShortDateString
            txtFechaFin.Text = Date.Now.ToShortDateString
            filtrar()
        Else
            If Session("dtRsultados") Is Nothing Then
                LlenaGrid(True)
            End If
        End If
    End Sub

    Sub LlenaGrid(ByVal bRestablecer As Boolean)
        Dim dt As New DataTable
        Dim sqry As String = ""

        sqry = "SELECT distinct Orden, Nom_Cliente, min(Fecha_Captura) as fecha_captura, estatus, fecha_estatus from EncuestaServicioMZD group by orden,NOM_CLIENTE, ESTATUS, FECHA_ESTATUS"
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

        Me.dg1.DataSource = dt
        dg1.CurrentPageIndex = 0
        dg1.DataBind()
    End Sub
    Protected Sub GridView1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg1.ItemCommand
        If e.CommandName = "Detalle" Then
            Session("idencuestaservicio") = "2"
            Session("Orden") = dg1.Items(e.Item.ItemIndex).Cells(0).Text()
            Session("nom_cliente") = dg1.Items(e.Item.ItemIndex).Cells(1).Text()
            Response.Redirect("ZCRMCUESTIONARIODETALLE.aspx")
        ElseIf e.CommandName = "EntregaDetalle" Then
            Session("idencuestaservicio") = "2"
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
