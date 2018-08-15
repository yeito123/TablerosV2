Public Class ctlSalir
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub imgSalir_Click(sender As Object, e As ImageClickEventArgs) Handles imgSalir.Click


        TablerosV2LibTypes.Utils.Salir(Page.AppRelativeVirtualPath)





    End Sub
End Class