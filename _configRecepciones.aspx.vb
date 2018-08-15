Imports TablerosV2LibTypes

Public Class _configRecepciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            llenaHoras()
            llenaOrden()
            llenagrid()
        End If
    End Sub

    Private Sub llenaHoras()
        Dim ini As New TimeSpan(6, 0, 0)
        Dim fin As New TimeSpan(22, 0, 0)
        While ini < fin
            Me.cboHoras_ini.Items.Add(New ListItem(String.Format("{0:00}", ini.Hours) & ":" & String.Format("{0:00}", ini.Minutes)))
            Me.cboHoras_fin.Items.Add(New ListItem(String.Format("{0:00}", ini.Hours) & ":" & String.Format("{0:00}", ini.Minutes)))
            ini = (New TimeSpan(ini.Hours, ini.Minutes + 30, ini.Seconds))
        End While
    End Sub

    Private Sub llenaOrden()
        Me.cbo_orden.Items.Clear()
        Dim n As Integer = 1, lim As Integer = 10
        Dim dt As New Data.DataTable
        Dim sql As String
        sql = "select orden from tb_pantallas_bienvenidas"
        dt = BDClass.SQLtoDataTable(sql, False)
        If (dt.Rows.Count() > 0) Then
            While n < lim + 1
                If Not (buscarorden(dt, n)) Then
                    Me.cbo_orden.Items.Add(n)
                    n += 1
                End If
                n += 1
            End While
        Else
            While n < lim + 1
                Me.cbo_orden.Items.Add(n)
                n += 1
            End While
        End If
    End Sub


    Private Function buscarorden(ByVal dt As Data.DataTable, ByVal n As Integer) As Boolean
        For i = 0 To dt.Rows.Count() - 1
            If (dt.Rows(i).Item("orden") = n) Then
                Return True
            End If
        Next
        Return False
    End Function

    Protected Sub agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim activo As Boolean
        Dim sql As String
        Dim ejecuta As String
        If Me.activa.Checked Then
            activo = True
        Else
            activo = False
        End If
        sql = " INSERT INTO TB_PANTALLAS_BIENVENIDAS ([orden],[nombre],[tiempo],[hora_ini],[Hora_fin],[activo])"
        sql += " VALUES "
        sql += "('" & cbo_orden.SelectedItem.ToString & "','" & cboPantallas.SelectedItem.ToString & "','" & cmb_tiempo.SelectedItem.ToString & "','" _
            & cboHoras_ini.SelectedItem.ToString & "','18:00','" & activo & "')"
        ejecuta = BDClass.ExecuteQuery(sql, False)
        llenagrid()
        llenaOrden()
    End Sub

    Private Sub llenagrid()
        Dim sql As String
        Dim dt As Data.DataTable
        sql = "SELECT [id],[orden],[nombre],[tiempo],[hora_ini],[Hora_fin],[activo] FROM [dbo].[TB_PANTALLAS_BIENVENIDAS]"
        dt = BDClass.SQLtoDataTable(sql, False)
        gvpantallas.DataSource = dt
        gvpantallas.DataBind()
    End Sub
    Protected Sub imgUEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim SQRY As String
        'Dim ii As Integer = CType(sender.parent.parent.parent, GridViewRow).DataItemIndex
        gvpantallas.SelectedIndex = sender.parent.parent.dataitemindex
        SQRY = "DELETE from  TB_PANTALLAS_BIENVENIDAS  WHERE id = '" & gvpantallas.Rows(gvpantallas.SelectedIndex()).Cells(1).Text & "'"
        BDClass.ExecuteQuery(SQRY, False)
        llenagrid()
        llenaOrden()
    End Sub

    Protected Sub activar(sender As Object, e As EventArgs)
        Dim SQRY As String
        Dim ejecutar As String
        'Dim ii As Integer = CType(sender.parent.parent.parent, GridViewRow).DataItemIndex
        gvpantallas.SelectedIndex = sender.parent.parent.dataitemindex
        Dim dt As New Data.DataTable
        SQRY = "SELECT ACTIVO FROM TB_PANTALLAS_BIENVENIDAS WHERE ID = '" & gvpantallas.Rows(gvpantallas.SelectedIndex()).Cells(1).Text & "'"
        dt = BDClass.SQLtoDataTable(SQRY, False)

        If (CInt(dt.Rows(0).Item("ACTIVO")) = 0) Then
            SQRY = "UPDATE TB_PANTALLAS_BIENVENIDAS SET ACTIVO = '1' WHERE ID = '" & gvpantallas.Rows(gvpantallas.SelectedIndex()).Cells(1).Text & "'"
        Else
            SQRY = "UPDATE TB_PANTALLAS_BIENVENIDAS SET ACTIVO = '0' WHERE ID = '" & gvpantallas.Rows(gvpantallas.SelectedIndex()).Cells(1).Text & "'"
        End If
        ejecutar = BDClass.ExecuteQuery(SQRY, False)
        llenagrid()
        llenaOrden()
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Response.Redirect("Login.aspx")
    End Sub


End Class