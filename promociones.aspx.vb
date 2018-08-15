Imports TablerosV2LibTypes

Public Class promociones
    Inherits System.Web.UI.Page
    Dim img As New HtmlImage
    Dim Imagen As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer13.Interval = Session("tiempoPantalla") * 1000
        If Not Me.IsPostBack Then
            Me.titulo.Text = Session("nombreAgencia")
            llenaprecios()
        End If
    End Sub
    'Carga tanto imagenes como informacion
    Private Sub llenaprecios()
        img.Src = ""
        Imagen = ""
        'Session("ref") = Session("ref") + 1
        Imagen = "img/promocion.png"
        img.Src = Imagen
        img.Style.Add("width", "100%")
        img.Style.Add("height", "100%")
        divimg.Controls.Add(img)
    End Sub
    Protected Sub Timer13_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer13.Tick
        Session("pantalla") += 1
        Validaciones.cambiarPantalla()
    End Sub
End Class