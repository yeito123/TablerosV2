Imports TablerosV2LibTypes
Partial Public Class sccPermisosChips
    Inherits System.Web.UI.Page

    Protected Sub cmdRegresar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdRegresar.Click
        Response.Redirect("Inicio.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If InStr(Page.AppRelativeVirtualPath, Session("URL")) = 0 Or Session("URL") Is Nothing Then Response.Redirect("Inicio.aspx")

        If Not Page.IsPostBack Then
            LlenacbogUs()
            LlenacbopUs2()
            LlenacboOPS()
            LlenacboOBS()

        End If

        LlenaGVPermisos()


    End Sub

    Sub LlenacbogUs()
        Dim dt As New Data.DataTable, i As Integer

        dt = BDClass.SQLtoDataTable("select cvegrupo, descripcion from sccGrupos", False)

        cboGrupoPP.Items.Clear()
        For i = 0 To dt.Rows.Count - 1

            cboGrupoPP.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))
        Next

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


        dt = BDClass.SQLtoDataTable("select cveOPERACION, descripcion from sccOperaciones where cveoperacion not in  (" & SCC.EOperaciones.Acceder & ") ", False)
        cboOperacion.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cboOperacion.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))

        Next
    End Sub
    Sub LlenacboOBS()
        Dim dt As New Data.DataTable, i As Integer


        dt = BDClass.SQLtoDataTable("select cveObjeto, descripcion from sccObjetos where cveObjeto in (" & SCC.EObjetos.CHIPASESOR & "," & SCC.EObjetos.CHIPCITAS & "," & SCC.EObjetos.CHIPTECNICOS & ") order by cveObjeto desc ", False)
        cboObjeto.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cboObjeto.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))

        Next
    End Sub

    Sub LlenaGVPermisos()
        gvPermisos.DataSource = BDClass.SQLtoDataTable("select a.cveGrupo,(select distinct descripcion from SccGrupos where cveGrupo=a.cveGrupo) Grupo, a.cvePerfil,(select distinct  descripcion from SccPerfiles where cveGrupo=a.cveGrupo and cvePerfil=a.cvePerfil) Perfil, a.cvePermiso, a.cveObjeto, (select distinct descripcion from SccObjetos where cveObjeto=a.cveObjeto) as Objeto, a.cveOperacion, (select distinct descripcion from SccOperaciones where cveOperacion=a.cveOperacion) Operacion, a.valor from SccPermisos a where a.cveGrupo=" & cboGrupoPP.SelectedItem.Value & " and a.cvePerfil=" & cboPerfilPP.SelectedItem.Value & "  and a.cveObjeto in (" & SCC.EObjetos.CHIPASESOR & "," & SCC.EObjetos.CHIPCITAS & "," & SCC.EObjetos.CHIPTECNICOS & ") order by a.cveGrupo, a.cvePerfil, a.cvePermiso", False)
        gvPermisos.DataBind()
    End Sub


    Protected Sub imgPPEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvPermisos.SelectedIndex = sender.parent.parent.dataitemindex
        BDClass.ExecuteQuery("DELETE SccPermisos   WHERE cveGrupo=" & gvPermisos.Rows(gvPermisos.SelectedIndex).Cells(1).Text & " and cveperfil=" & gvPermisos.Rows(gvPermisos.SelectedIndex).Cells(3).Text & " and cvePermiso=" & gvPermisos.Rows(gvPermisos.SelectedIndex).Cells(5).Text & "", False)
        LlenaGVPermisos()
    End Sub


    Private Function obtenValor(ByVal ItemRequest As String) As String
        For Each nRequest As String In Request.Form
            If nRequest.LastIndexOf(ItemRequest.Trim) > -1 Then
                Return Request.Form(nRequest).Trim
            End If
        Next
        Return ""
    End Function

    Function txt(ByVal sId As String, ByVal sValor As String) As TextBox
        Dim obj As New TextBox
        obj.ID = sId
        obj.Text = sValor
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



    Protected Sub cboPerfilPP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPerfilPP.SelectedIndexChanged
        LlenaGVPermisos()
    End Sub




    Protected Sub cmdGuardarPermiso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardarPermiso.Click
        BDClass.ExecuteQuery("insert into  SccPermisos values (" & cboGrupoPP.SelectedItem.Value & "," & cboPerfilPP.SelectedItem.Value & ",(select (isnull(max(cvepermiso),0) + 1) from SccPermisos where cveGrupo=" & cboGrupoPP.SelectedItem.Value & " and cvePerfil=" & cboPerfilPP.SelectedItem.Value & ") , " & cboObjeto.SelectedItem.Value & "," & cboOperacion.SelectedItem.Value & ",1)", False)
        LlenaGVPermisos()

    End Sub

End Class
