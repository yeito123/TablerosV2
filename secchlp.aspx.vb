Imports TablerosV2LibTypes
Partial Public Class secchlp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim url As String = ""
        Dim sObj As String = Request("obj")
        url = SCC.SolPermisos(sObj, SCC.EOperaciones.Acceder)
        If url.Length > 0 Then
            Session("URL") = url
            Response.Redirect(url)
        Else
            Session("URL") = Nothing
            Response.Redirect("inicio.aspx")
        End If
    End Sub

End Class