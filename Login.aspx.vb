Imports TablerosV2LibTypes
Partial Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub imgbtnLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnLogin.Click
        txtOldPassword.Text = ""
        txtNewPAssword.Text = ""
        txtVerifyPassword.Text = ""
        Panel2.Visible = False
        Dim sContraseña As String
        sContraseña = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1")

        SCC.ObtenPermisos(txtUsuario.Text, sContraseña)

        Dim surl As String = SCC.SolPermisos(SCC.EObjetos.Inicio, SCC.EOperaciones.Acceder)
        If surl.Length > 0 Then
            lblStat.Text = "Hola"
            Validaciones.insertaLogs(Session("Usuario"), Request.Url.Segments(Request.Url.Segments.Length - 1), "LOGGIN")
            Response.Redirect(surl)
        Else
            lblStat.Text = "Acceso denegado"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Validaciones.nombreAgencia()
        txtUsuario.Focus()
    End Sub

    Protected Sub imgbtnPassword_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnPassword.Click
        txtOldPassword.Text = ""
        txtNewPAssword.Text = ""
        txtVerifyPassword.Text = ""
        Panel2.Visible = True
    End Sub

    Protected Sub imgbtnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnCancel.Click
        txtOldPassword.Text = ""
        txtNewPAssword.Text = ""
        txtVerifyPassword.Text = ""
        Panel2.Visible = False
    End Sub

    Protected Sub imgbtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnGuardar.Click
        Dim sContraseña As String, sNewContraseña As String
        If txtNewPAssword.Text <> txtVerifyPassword.Text Then
            txtOldPassword.Text = ""
            txtNewPAssword.Text = ""
            txtVerifyPassword.Text = ""
            lblStat.Text = "La verificación de contraseña falló"
            Exit Sub
        End If

        sContraseña = FormsAuthentication.HashPasswordForStoringInConfigFile(txtOldPassword.Text, "SHA1")
        sNewContraseña = FormsAuthentication.HashPasswordForStoringInConfigFile(txtNewPAssword.Text, "SHA1")
        SCC.ObtenPermisos(txtUsuario.Text, sContraseña)

        Dim surl As String = SCC.SolPermisos(SCC.EObjetos.Inicio, SCC.EOperaciones.Acceder)
        If surl.Length > 0 Then
            SCC.CambiaPass(txtUsuario.Text, sNewContraseña, sContraseña)
            txtOldPassword.Text = ""
            txtNewPAssword.Text = ""
            txtVerifyPassword.Text = ""
            Panel2.Visible = False
            lblStat.Text = "Contraseña cambiada correctamente"
        Else
            txtOldPassword.Text = ""
            txtNewPAssword.Text = ""
            txtVerifyPassword.Text = ""
            lblStat.Text = "El cambio de contraseña falló"
            Exit Sub
        End If
    End Sub
End Class