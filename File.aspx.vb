Imports TablerosV2LibTypes
Public Class File
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub cmdEliminar_Click(sender As Object, e As ImageClickEventArgs) Handles cmdEliminar.Click
        Dim attach As New attach
        Dim tcuestionario As String = Request.QueryString("tcuestionario")
        Dim noorden As String = Request.QueryString("noorden")
        Dim idimg As String = Request.QueryString("idimg")
        attach.Eliminar(tcuestionario, noorden, idimg)
    End Sub
End Class