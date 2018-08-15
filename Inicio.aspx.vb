Imports TablerosV2LibTypes
Partial Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Response.Redirect("Login.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("UsuarioGrupo") Is Nothing Then
            Response.Redirect("Login.aspx")
            Exit Sub
        End If
        Session("URL") = Nothing
        Dim dt As New DataTable
        dt = SCC.ObtenObjetos
        Dim dtMenus As New DataTable
        dtMenus = SCC.ObtenMenus
        Dim ss As String = ""
        Dim objMenu As New HtmlGenericControl("div")
        objMenu.Style.Value = "margin-left: 10px;"
        ulOculto.InnerHtml = "<li><a href=""#"">Bienvenido <b>" & Session("UsuarioNombre") & "</b>!!!</a></li>" _
            & "<li class=""divider""></li>"
        If SCC.SolPermisos("sccPermisosp.aspx", SCC.EOperaciones.Acceder).Length > 0 Then
            ulOculto.InnerHtml &= "<li><a href='secchlp.aspx?obj=sccPermisosp.aspx'>Permisos</a></li>"
        End If
        If SCC.SolPermisos("sccPermisosChips.aspx", SCC.EOperaciones.Acceder).Length > 0 Then
            ulOculto.InnerHtml &= "<li><a href='secchlp.aspx?obj=sccPermisosChips.aspx'>Permisos Chips</a></li>"
        End If
        If SCC.SolPermisos("Config.aspx", SCC.EOperaciones.Acceder).Length > 0 Then
            ulOculto.InnerHtml &= "<li><a href='secchlp.aspx?obj=Config.aspx'>Configuracion</a></li>"
        End If
        If SCC.SolPermisos("pull_systemConfig.aspx", SCC.EOperaciones.Acceder).Length > 0 Then
            ulOculto.InnerHtml &= "<li><a href='secchlp.aspx?obj=pull_systemConfig.aspx'>Configuracion Pull</a></li>"
        End If
        If SCC.SolPermisos("main_status.aspx", SCC.EOperaciones.Acceder).Length > 0 Then
            ulOculto.InnerHtml &= "<li><a href='secchlp.aspx?obj=main_status.aspx'>ManejoOrdenes</a></li>"
        End If
        LiteralNavigationBar.Text = ""
        For i = 0 To dtMenus.Rows.Count - 1
            dt.DefaultView.RowFilter = "Menu='" & dtMenus(i)(0) & "'"
            LiteralNavigationBar.Text &= "<li class=""dropdown"">" _
                & "    <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">" & dtMenus(i)(0) & "<b class=""caret""></b></a>" _
                & "    <ul class=""dropdown-menu"">"
            For j = 0 To dt.DefaultView.Count - 1
                LiteralNavigationBar.Text &= "<li><a href='secchlp.aspx?obj=" & dt.DefaultView(j)("URL") & "'>" & dt.DefaultView(j)("Descripcion") & "</a></li>"
            Next
            LiteralNavigationBar.Text &= "    </ul>" _
                & "</li>"
        Next
        Me.Controls.Add(objMenu)
    End Sub

End Class