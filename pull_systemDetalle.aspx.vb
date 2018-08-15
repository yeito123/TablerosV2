Imports TablerosV2LibTypes
Partial Public Class pull_systemDetalle

    Inherits System.Web.UI.Page

    Private Sub pull_systemDetalle_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim sOrdenDetalle = Request("sOrdenDetalle")
        LlenaGRid()
        Exit Sub
        
 

    End Sub
    Sub LlenaGRid(Optional iPullLinks As String = "")
        Dim sqry As String
        'Dim sPullLinks As String = Request("PullLinks")

        'If iPullLinks <> "" Then sPullLinks = iPullLinks

         


        Dim dt As New DataTable, DT2 As New DataTable
        'dt = BDClass.SQLtoDataTable(sqry, False)
        Dim sOrdenDetalle = Request("sOrdenDetalle")

        If sOrdenDetalle <> "" Then
            If dt.Rows.Count = 0 Then
                sqry = "select distinct convert(varchar, b.fecha, 110) fecha,  convert(varchar,d.noOrden) noOrden, b.Cliente, b.noPlacas, d.serviciocapturado Fase, b.status  ,Fecha_hora_Status   from  TB_CITAS d  WITH(NOLOCK)   inner join tb_ciTAS_HEADER_NW b  WITH(NOLOCK)  on d.id_hd=b.id_hd   where d.servicioCapturado<>'Lavado' and  d.NOORDEN='" & sOrdenDetalle & "' order by   b.Fecha_hora_Status asc"
                DT2 = BDClass.SQLtoDataTable(sqry, False)

                If DT2.Rows.Count > 0 Then
                    lblStatus.Text = DT2.Rows(0).Item("status")
                    dt = DT2.Copy
                End If
            End If

        End If

        dg1.DataSource = dt
        dg1.DataBind()

    End Sub

    Private Sub dg1_PreRender(sender As Object, e As EventArgs) Handles dg1.PreRender
        Dim sOrdenDetalle = Request("sOrdenDetalle")
        If sOrdenDetalle <> "" Then
            Dim i As Integer = 0
            For i = 0 To dg1.Items.Count - 1
                If dg1.Items(i).Cells(1).Text = sOrdenDetalle Then
                    dg1.SelectedIndex = i
                    dg1.Items(i).Focus()

                End If
            Next
        End If

    End Sub
End Class
