Imports TablerosV2LibTypes.HandlerExample.MyHttpHandler

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub ImgDetalle_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        '---aqui se manda mostrar el pop , se pasan variables etcetc
        modalDetalle.Show()
    End Sub

    Private Sub btnModal_Click(sender As Object, e As EventArgs) Handles btnModal.Click
        '--nada, este boton es solo requisito
    End Sub

    Private Sub okbutton_Click(sender As Object, e As EventArgs) Handles okbutton.Click
        'aqui se hace lo que se debe hacer cuando das click, OkControlID en el control modal
        Response.Write("Listo")
    End Sub
End Class