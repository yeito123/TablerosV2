Imports TablerosV2LibTypes
Public Class FileAux
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim attach As New attach
        Dim dt As New DataTable

        Dim tcuestionario As String = Request.QueryString("tcuestionario")
        Dim noorden As String = Request.QueryString("noorden")
        Dim idimg As String = Request.QueryString("idimg")

        dt = attach.LeerBinario(tcuestionario, noorden, idimg)
        If dt.Rows.Count > 0 Then

            Response.ContentType = Trim(dt.Rows(0).Item(1))
            Response.BinaryWrite(dt.Rows(0).Item(0))

            dt = Nothing

        End If

    End Sub

    
End Class