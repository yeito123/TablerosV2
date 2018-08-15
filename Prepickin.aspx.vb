Imports TablerosV2LibTypes

Public Class Prepickin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtFecha.Text = Date.Now.ToShortDateString
            llenagrid()
        End If
    End Sub
    Sub llenagrid()
        Dim sqry As String = ""
        Dim n As Integer
        Dim dt As New Data.DataTable, dt2 As New Data.DataTable
        Dim objCHIPColCom As New DataTable
        Dim sComentarios As String = ""
        sqry = "select * from v_Prepicking_2 where convert(varchar,fecha,12)=convert(varchar,cast('" & String.Format("{0:s}", CDate(txtFecha.Text)) & "' as datetime),12)"
        dt = BDClass.SQLtoDataTable(sqry, False)
        dt.Columns.Add("repuestose").ReadOnly = False
        dt2 = dt.Clone

        For i = 0 To dt.Rows.Count - 1
            If dt2.Select("placas='" & dt.Rows(i)("PLACAS") & "'").Length = 0 Then
                n = dt.Rows(i)("NUMCITA")
                objCHIPColCom = obtenRepuestos(n)
                sComentarios = ""
                If objCHIPColCom.Rows.Count > 0 Then
                    For j = 0 To objCHIPColCom.Rows.Count - 1
                        sComentarios = sComentarios & " " & objCHIPColCom.Rows(j)("repuesto") & " Cantidad: " & objCHIPColCom.Rows(j)("cantidad") & " -- " & vbCrLf
                    Next
                End If

                If sComentarios.Trim.Length > 0 Then
                    Try
                        dt.Rows(i).BeginEdit()
                        dt.Rows(i)("repuestose") = sComentarios
                        dt.AcceptChanges()
                        dt.Rows(i).EndEdit()
                    Catch ex As Exception
                        sComentarios = "Sin repuestos"
                        dt.Rows(i).BeginEdit()
                        dt.Rows(i)("repuestose") = sComentarios
                        dt.AcceptChanges()
                        dt.Rows(i).EndEdit()
                    End Try
                Else
                    sComentarios = "Sin repuestos"
                    dt.Rows(i).BeginEdit()
                    dt.Rows(i)("repuestose") = sComentarios
                    dt.AcceptChanges()
                    dt.Rows(i).EndEdit()
                End If
                dt2.Rows.Add(dt.Rows(i).ItemArray)
            End If
        Next
        dgAusencias.DataSource = dt2
        dgAusencias.DataBind()
    End Sub

    Protected Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        llenagrid()
    End Sub

    Protected Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        Dim sqry As String = "select *  from v_Prepicking_2 where convert(varchar,fecha,12)=convert(varchar,cast('" & String.Format("{0:s}", CDate(txtFecha.Text)) & "' as datetime),12)"
        Dim dt As New DataTable
        dt = BDClass.SQLtoDataTable(sqry, False)
        ExportDataSetToExcel(dt)
    End Sub
    Sub ExportDataSetToExcel(ByVal dt As DataTable)
        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "prepick.xls"))
        HttpContext.Current.Response.ContentType = "application/ms-excel"
        Dim sw As System.IO.StringWriter = New System.IO.StringWriter
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim dg As New GridView
        dg.DataSource = dt
        dg.DataBind()
        dg.RenderControl(htw)
        '  render the htmlwriter into the response
        HttpContext.Current.Response.Write(sw.ToString)
        HttpContext.Current.Response.End()
    End Sub

    Private Sub imgSalir_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgSalir.Click
        Response.Redirect("Inicio.aspx")
    End Sub
    Private Function obtenRepuestos(ByVal n As Integer) As DataTable
        Dim dt As DataTable
        Dim sql As String = "select id_cita, repuesto, cantidad from  V_REPUESTOS_CITAS WHERE id_cita = '" & n & "'"
        dt = BDClass.SQLtoDataTable(sql, False)
        Return dt
    End Function
    Protected Sub muestraMensaje(ByVal m As String)
        Response.Write("<script>window.alert('" & m & "');</script>")
    End Sub
End Class