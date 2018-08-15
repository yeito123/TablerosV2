Imports TablerosV2LibTypes
Partial Public Class sccPermisosp
    Inherits System.Web.UI.Page


    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick
        MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value)

    End Sub
    Protected Sub cmdRegresar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdRegresar.Click
        Response.Redirect("Inicio.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If InStr(Page.AppRelativeVirtualPath, Session("URL")) = 0 Or Session("URL") Is Nothing Then Response.Redirect("Inicio.aspx")

        If Not Page.IsPostBack Then
            LlenacbogUs()
            LlenacbopUs()
            LlenacboOPS()
            LlenacboOBS()
            llenacbocolores()
        End If
        LlenaGVGrupos()
        LlenaGVPerfiles()
        LlenaGVUsuarios()
        LlenaGVPermisos()
        LlenaObjetos()

    End Sub
    Sub llenacbocolores()
        Dim c As New System.Drawing.Color
        Dim ialpha, ired, igreen, iblue As Integer
        Dim shex As String
        cboColor.Items.Clear()
        For i = 0 To 20
            ialpha = Fix(Rnd() * 256)
            ired = Fix(Rnd() * 256)
            igreen = Fix(Rnd() * 256)
            iblue = Fix(Rnd() * 256)
            c = System.Drawing.Color.FromArgb(ialpha, ired, igreen, iblue)
            shex = Right(Hex(c.ToArgb), 6)
            cboColor.Items.Add(New ListItem("#" & shex))
            cboColor.Items(i).Attributes.Add("Style", "Background-color:#" & shex & ";")
        Next
    End Sub
    Sub LlenacbogUs()
        Dim dt As New Data.DataTable, i As Integer

        dt = BDClass.SQLtoDataTable("select cvegrupo, descripcion from sccGrupos", False)
        cboGrupoU.Items.Clear()
        cboGrupoP.Items.Clear()
        cboGrupoPP.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cboGrupoU.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))
            cboGrupoP.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))
            cboGrupoPP.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))
        Next

    End Sub
    Sub LlenacbopUs()
        Dim dt As New Data.DataTable, i As Integer


        dt = BDClass.SQLtoDataTable("select cveperfil, descripcion from sccPerfiles where cveGrupo=" & cboGrupoU.SelectedItem.Value & "", False)
        cboPerfilU.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cboPerfilU.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))


        Next
        LlenacbopUs2()
    End Sub
    Sub LlenacbopUs2()
        Dim dt As New Data.DataTable, i As Integer


        dt = BDClass.SQLtoDataTable("select cveperfil, descripcion from sccPerfiles where cveGrupo=" & cboGrupoPP.SelectedItem.Value & "", False)
        cboPerfilPP.Items.Clear()
        For i = 0 To dt.Rows.Count - 1

            cboPerfilPP.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))

        Next
    End Sub
    Sub LlenacboOPS()
        Dim dt As New Data.DataTable, i As Integer


        dt = BDClass.SQLtoDataTable("select cveOPERACION, descripcion from sccOperaciones where cveoperacion in (" & SCC.EOperaciones.Acceder & ") ", False)
        cboOperacion.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cboOperacion.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))

        Next
    End Sub
    Sub LlenacboOBS()
        Dim dt As New Data.DataTable, i As Integer


        dt = BDClass.SQLtoDataTable("select cveObjeto, descripcion from sccObjetos where cveObjeto>0 order by cveObjeto ", False)
        cboObjeto.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cboObjeto.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))

        Next
    End Sub

    Sub LlenaGVGrupos()
        gvGrupos.DataSource = BDClass.SQLtoDataTable("select distinct cveGrupo,descripcion from SccGrupos ", False)
        gvGrupos.DataBind()
    End Sub
    Sub LlenaObjetos()
        gvObjetos.DataSource = BDClass.SQLtoDataTable("select distinct cveObjeto,descripcion, URL, Menu, OrdenMenu from SccObjetos where cveObjeto>0", False)
        gvObjetos.DataBind()
    End Sub
    Sub LlenaGVPerfiles()
        gvPerfiles.DataSource = BDClass.SQLtoDataTable("select a.cveGrupo,(select distinct descripcion from SccGrupos where cveGrupo=a.cveGrupo) Grupo, a.cvePerfil, a.Descripcion  from SccPerfiles a order by a.cveGrupo, a.cvePerfil", False)
        gvPerfiles.DataBind()
    End Sub
    Sub LlenaGVUsuarios()
        gvUsuarios.DataSource = BDClass.SQLtoDataTable("select a.cveGrupo, (select distinct descripcion from SccGrupos where cveGrupo=a.cveGrupo) Grupo, a.cvePerfil, (select distinct descripcion from SccPerfiles where cveGrupo=a.cveGrupo and cvePerfil=a.cvePerfil) Perfil ,a.cveUsuario, a.Nombre, a.correoE, a.Color, a.cveAsesor from SccUsuarios a order by a.cveGrupo, a.cvePerfil, a.cveUsuario", False)
        gvUsuarios.DataBind()

    End Sub
    Sub LlenaGVPermisos()
        gvPermisos.DataSource = BDClass.SQLtoDataTable("select a.cveGrupo,(select distinct descripcion from SccGrupos where cveGrupo=a.cveGrupo) Grupo, a.cvePerfil,(select distinct  descripcion from SccPerfiles where cveGrupo=a.cveGrupo and cvePerfil=a.cvePerfil) Perfil, a.cvePermiso, a.cveObjeto, (select distinct descripcion from SccObjetos where cveObjeto=a.cveObjeto) as Objeto, a.cveOperacion, (select distinct descripcion from SccOperaciones where cveOperacion=a.cveOperacion) Operacion, a.valor from SccPermisos a where a.cveGrupo=" & cboGrupoPP.SelectedItem.Value & " and a.cvePerfil=" & cboPerfilPP.SelectedItem.Value & " and a.cveoperacion=" & cboOperacion.SelectedItem.Value & " and a.cveObjeto>0 order by a.cveGrupo, a.cvePerfil, a.cvePermiso", False)
        gvPermisos.DataBind()
    End Sub

    Protected Sub imgPEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvPerfiles.SelectedIndex = sender.parent.parent.dataitemindex
        BDClass.ExecuteQuery("DELETE SccPerfiles   WHERE cveGrupo=" & gvPerfiles.Rows(gvPerfiles.SelectedIndex).Cells(1).Text & " and cveperfil=" & gvPerfiles.Rows(gvPerfiles.SelectedIndex).Cells(3).Text & "", False)
        LlenaGVPerfiles()
        LlenacbopUs()
    End Sub

    Protected Sub imgPEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvPerfiles.SelectedIndex = sender.parent.parent.dataitemindex

        gvPerfiles.Rows(gvPerfiles.SelectedIndex).Cells(4).Controls.Add(txt("txtPDescripcion", gvPerfiles.Rows(gvPerfiles.SelectedIndex).Cells(4).Text))
        gvPerfiles.Rows(gvPerfiles.SelectedIndex).Cells(2).Controls.Add(cboGrupo("cboPGrupo", gvPerfiles.Rows(gvPerfiles.SelectedIndex).Cells(1).Text))


    End Sub

    Protected Sub imgPConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvPerfiles.SelectedIndex = sender.parent.parent.dataitemindex
        BDClass.ExecuteQuery("update  SccPerfiles  set descripcion='" & obtenValor("txtPDescripcion") & "', cveGrupo=" & obtenValor("cboPGrupo") & "  WHERE cveGrupo=" & gvPerfiles.Rows(gvPerfiles.SelectedIndex).Cells(1).Text & " and cveperfil=" & gvPerfiles.Rows(gvPerfiles.SelectedIndex).Cells(3).Text & "", False)
        LlenaGVPerfiles()
        LlenacbopUs()
    End Sub
    Protected Sub imgPPEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvPermisos.SelectedIndex = sender.parent.parent.dataitemindex
        BDClass.ExecuteQuery("DELETE SccPermisos   WHERE cveGrupo=" & gvPermisos.Rows(gvPermisos.SelectedIndex).Cells(1).Text & " and cveperfil=" & gvPermisos.Rows(gvPermisos.SelectedIndex).Cells(3).Text & " and cvePermiso=" & gvPermisos.Rows(gvPermisos.SelectedIndex).Cells(5).Text & "", False)
        LlenaGVPermisos()
    End Sub


    Protected Sub imgUEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvUsuarios.SelectedIndex = sender.parent.parent.dataitemindex
        BDClass.ExecuteQuery("DELETE SccUsuarios   WHERE cveUsuario='" & gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(5).Text & "' and  cveGrupo=" & gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(1).Text & " and cveperfil=" & gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(3).Text & "", False)
        LlenaGVUsuarios()
    End Sub

    Protected Sub imgUEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvUsuarios.SelectedIndex = sender.parent.parent.dataitemindex
        gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(4).Controls.Add(cboPerfil("cboUPerfil", gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(3).Text, gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(1).Text))
        gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(6).Controls.Add(txt("txtUNombre", gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(6).Text))
        gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(7).Controls.Add(txt("txtUCorreo", gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(7).Text))
        gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(8).Controls.Add(cboColores("txtUColor", gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(8).Text))
        gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(9).Controls.Add(txt("txtcveAsesor", gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(9).Text))

    End Sub

    Protected Sub imgUConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvUsuarios.SelectedIndex = sender.parent.parent.dataitemindex
        BDClass.ExecuteQuery("update  SccUsuarios  set  cvePerfil=" & obtenValor("cboUPerfil") & ",nombre='" & obtenValor("txtUNombre") & "', correoE='" & obtenValor("txtUCorreo") & "', color='" & obtenValor("txtUColor") & "', cveAsesor='" & obtenValor("txtcveAsesor") & "'  WHERE cveUsuario='" & gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(5).Text & "' and  cveGrupo=" & gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(1).Text & " and cveperfil=" & gvUsuarios.Rows(gvUsuarios.SelectedIndex).Cells(3).Text & "", False)
        LlenaGVUsuarios()

    End Sub
    Protected Sub imgGEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvGrupos.SelectedIndex = sender.parent.parent.dataitemindex
        BDClass.ExecuteQuery("DELETE SCCGrupos  WHERE cveGrupo=" & gvGrupos.Rows(gvGrupos.SelectedIndex).Cells(1).Text & "", False)
        LlenaGVGrupos()
        LlenacbogUs()
    End Sub

    Protected Sub imgGEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvGrupos.SelectedIndex = sender.parent.parent.dataitemindex
        gvGrupos.Rows(gvGrupos.SelectedIndex).Cells(2).Controls.Add(txt("txtGDescripcion", gvGrupos.Rows(gvGrupos.SelectedIndex).Cells(2).Text))

    End Sub

    Protected Sub imgGConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvGrupos.SelectedIndex = sender.parent.parent.dataitemindex
        BDClass.ExecuteQuery("update  SCCGrupos  set descripcion='" & obtenValor("txtGDescripcion") & "'  WHERE cveGrupo=" & gvGrupos.Rows(gvGrupos.SelectedIndex).Cells(1).Text & " ", False)
        LlenaGVGrupos()
        LlenacbogUs()
    End Sub
    Protected Sub imgOEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvObjetos.SelectedIndex = sender.parent.parent.dataitemindex
        BDClass.ExecuteQuery("DELETE SCCObjetos  WHERE cveObjeto=" & gvObjetos.Rows(gvObjetos.SelectedIndex).Cells(1).Text & "", False)
        LlenaObjetos()
        LlenacboOBS()
    End Sub

    Protected Sub imgOEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvObjetos.SelectedIndex = sender.parent.parent.dataitemindex
        gvObjetos.Rows(gvObjetos.SelectedIndex).Cells(2).Controls.Add(txt("txtODescripcion", gvObjetos.Rows(gvObjetos.SelectedIndex).Cells(2).Text))
        gvObjetos.Rows(gvObjetos.SelectedIndex).Cells(3).Controls.Add(txt("txtOURL", gvObjetos.Rows(gvObjetos.SelectedIndex).Cells(3).Text))
        gvObjetos.Rows(gvObjetos.SelectedIndex).Cells(4).Controls.Add(txt("txtOMenu", gvObjetos.Rows(gvObjetos.SelectedIndex).Cells(4).Text))
        gvObjetos.Rows(gvObjetos.SelectedIndex).Cells(5).Controls.Add(txt("txtOordMenu", gvObjetos.Rows(gvObjetos.SelectedIndex).Cells(5).Text))

    End Sub

    Protected Sub imgOConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvObjetos.SelectedIndex = sender.parent.parent.dataitemindex
        BDClass.ExecuteQuery("update  SCCObjetos  set descripcion='" & obtenValor("txtODescripcion") & "', URL='" & obtenValor("txtOURL") & "', Menu='" & obtenValor("txtOMenu") & "', OrdenMenu=" & obtenValor("txtOordMenu") & "  WHERE cveObjeto=" & gvObjetos.Rows(gvObjetos.SelectedIndex).Cells(1).Text & " ", False)
        LlenaObjetos()
        LlenacboOBS()
    End Sub
    Private Function obtenValor(ByVal ItemRequest As String) As String
        For Each nRequest As String In Request.Form
            If nRequest.LastIndexOf(ItemRequest.Trim) > -1 Then
                Return Request.Form(nRequest).Trim
            End If
        Next
        Return ""
    End Function
    Function cboColores(ByVal sId As String, ByVal SvALOR As String) As DropDownList

        Dim c As New System.Drawing.Color
        Dim ialpha, ired, igreen, iblue As Integer
        Dim shex As String


        Dim obj As New DropDownList
        obj.ID = sId
        obj.Items.Clear()

        For i = 0 To 20
            ialpha = Fix(Rnd() * 256)
            ired = Fix(Rnd() * 256)
            igreen = Fix(Rnd() * 256)
            iblue = Fix(Rnd() * 256)
            c = System.Drawing.Color.FromArgb(ialpha, ired, igreen, iblue)
            shex = Right(Hex(c.ToArgb), 6)
            obj.Items.Add(New ListItem("#" & shex))
            obj.Items(i).Attributes.Add("Style", "Background-color:#" & shex & ";")
        Next
        Try
            obj.Items.FindByText(SvALOR).Selected = True
        Catch ex As Exception

        End Try
        Return obj
    End Function
    Function txt(ByVal sId As String, ByVal sValor As String) As TextBox
        Dim obj As New TextBox
        obj.ID = sId
        obj.Text = sValor
        obj.Text = Replace(obj.Text, "amp;", "")
        obj.Text = Replace(obj.Text, "nbsp;", "")
        obj.Text = Replace(obj.Text, ";", "")
        obj.Text = Replace(obj.Text, "&", "")
        Return obj
    End Function
    Function cboGrupo(ByVal sId As String, ByVal sValor As String) As DropDownList
        Dim dt As New Data.DataTable, i As Integer

        dt = BDClass.SQLtoDataTable("select distinct  cvegrupo, descripcion from sccGrupos", False)


        Dim obj As New DropDownList
        obj.Items.Clear()
        obj.ID = sId
        For i = 0 To dt.Rows.Count - 1
            obj.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))

        Next
        Try
            obj.Items.FindByValue(sValor).Selected = True
        Catch ex As Exception

        End Try

        Return obj
    End Function
    Function cboPerfil(ByVal sId As String, ByVal sValor As String, ByVal sFiltro As String) As DropDownList
        Dim dt As New Data.DataTable, i As Integer


        dt = BDClass.SQLtoDataTable("select cveperfil, descripcion from sccPerfiles where cveGrupo=" & sFiltro & "", False)

        Dim obj As New DropDownList
        obj.Items.Clear()
        obj.ID = sId
        obj.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            obj.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))
        Next
        obj.Items.FindByValue(sValor).Selected = True
        Return obj
    End Function

    Protected Sub cmdGuardarUsr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardarUsr.Click
        If txtPass.Text <> txtPass0.Text Or txtUserID.Text.Length = 0 Or txtPass.Text.Trim = "" Then

            txtPass.Text = ""
            txtPass0.Text = ""
            TablerosUtilsHyP.iMsgBox(Me.Page, "La verificacion de password no coincide")
            txtPass.Focus()
            Exit Sub
        End If
        BDClass.ExecuteQuery("insert into  SccUsuarios values (" & cboGrupoU.SelectedItem.Value & "," & cboPerfilU.SelectedItem.Value & ", '" & txtUserID.Text.Trim & "','" & FormsAuthentication.HashPasswordForStoringInConfigFile(txtPass.Text, "SHA1") & "', '" & txtNombre.Text.Trim & "','" & txtEmail.Text.Trim & "','" & cboColor.SelectedItem.Text & "', '" & txtAsesorID.Text.Trim & "')", False)
        llenacbocolores()
        LlenaGVUsuarios()
    End Sub


    Protected Sub cboGrupoU_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGrupoU.SelectedIndexChanged
        LlenacbopUs()
    End Sub


    Protected Sub cmdGuardarGrupo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardarGrupo.Click
        BDClass.ExecuteQuery("insert into  SccGrupos values (" & txtGrupoG.Text.Trim & ",'" & txtGrupoDescG.Text.Trim & "')", False)
        LlenaGVGrupos()
        LlenacbogUs()
    End Sub

    Protected Sub cmdGuardarPerfil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardarPerfil.Click
        BDClass.ExecuteQuery("insert into  SccPerfiles values (" & cboGrupoP.SelectedItem.Value & "," & txtPerfilP.Text.Trim & ",'" & txtPerfilDescripcionP.Text.Trim & "')", False)
        LlenaGVPerfiles()
        LlenacbopUs()
    End Sub

    Protected Sub cboGrupoU0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGrupoPP.SelectedIndexChanged
        LlenacbopUs()
        LlenaGVPermisos()
    End Sub

    Protected Sub cboPerfilPP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPerfilPP.SelectedIndexChanged
        LlenaGVPermisos()
    End Sub

    Protected Sub cboOperacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOperacion.SelectedIndexChanged
        LlenaGVPermisos()
    End Sub



    Protected Sub cmdGuardarPermiso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardarPermiso.Click
        BDClass.ExecuteQuery("insert into  SccPermisos values (" & cboGrupoPP.SelectedItem.Value & "," & cboPerfilPP.SelectedItem.Value & ",(select (isnull(max(cvepermiso),0) + 1) from SccPermisos where cveGrupo=" & cboGrupoPP.SelectedItem.Value & " and cvePerfil=" & cboPerfilPP.SelectedItem.Value & ") ," & cboObjeto.SelectedItem.Value & "," & cboOperacion.SelectedItem.Value & ",1)", False)
        LlenaGVPermisos()

    End Sub

    Protected Sub cmdAgregaObjeto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAgregaObjeto.Click
        BDClass.ExecuteQuery("insert into  SccoBJETOS(CVEoBJETO, Descripcion) values (" & txtOcveObjeto.Text & ",'" & txtoDescripcion.Text & "')", False)
        LlenaObjetos()
        LlenacboOBS()
    End Sub

    Protected Sub cmdRefreshColores_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRefreshColores.Click
        llenacbocolores()
    End Sub

    Private Sub gvUsuarios_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvUsuarios.PreRender
        Dim converter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color))
        Dim color As System.Drawing.Color
        For i = 0 To gvUsuarios.Rows.Count - 1
            Try
                color = converter.ConvertFromString(gvUsuarios.Rows(i).Cells(8).Text)
                gvUsuarios.Rows(i).Cells(8).BackColor = color
            Catch ex As Exception

            End Try

        Next
    End Sub
End Class
