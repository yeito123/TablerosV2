Imports TablerosV2LibTypes

Public Class _recepcionCitas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Session("pantalla") = 1
            Session("tiempoPantalla") = 1
        End If
        Timer1.Interval = Session("tiempoPantalla") * 1000


    End Sub

    Protected Sub timer1_tick()
        Validaciones.cambiarPantalla()
    End Sub

End Class