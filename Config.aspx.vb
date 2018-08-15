Imports TablerosV2LibTypes

Partial Public Class Config
    Inherits System.Web.UI.Page


    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick
        MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value)
        llenacbocolores()
    End Sub
    Protected Sub cmdRegresar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdRegresar.Click
        Response.Redirect("Inicio.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If InStr(Page.AppRelativeVirtualPath, Session("URL")) = 0 Or Session("URL") Is Nothing Then Response.Redirect("Inicio.aspx")

        If Not Page.IsPostBack Then

            LlenacboTECS()
            llenacbocolores()


            LlenacboOps()
        End If
        'LlenaGVGrupos()
        'LlenaGVPerfiles()
        LlenaChips()
        LlenaGVTecnicos()
        'LlenaGVPermisos()
        'LlenaObjetos()

    End Sub
    Sub LlenacboOps()
        
        cboGrupo.DataSource = SCCParametros.ObtenParametrosDT(Request.Url.Segments(Request.Url.Segments.Length - 1))
        cboGrupo.DataTextField = "valor"
        cboGrupo.DataValueField = "valor"
        cboGrupo.DataBind()
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

    Sub LlenacboTECS()
        Dim dt As New Data.DataTable
        Dim T As New TimeSpan(6, 0, 0)
        Dim TF As New TimeSpan(22, 0, 0)

        cboEntradaLV.Items.Clear()
        cboSalidaLV.Items.Clear()
        cboComidaLV.Items.Clear()
        cboEntradaSabado.Items.Clear()
        cboSalidaSabado.Items.Clear()
        cboComidaSabado.Items.Clear()
        Do While T < TF
            cboEntradaLV.Items.Add(New ListItem(String.Format("{0:00}", T.Hours) & ":" & String.Format("{0:00}", T.Minutes)))
            cboSalidaLV.Items.Add(New ListItem(String.Format("{0:00}", T.Hours) & ":" & String.Format("{0:00}", T.Minutes)))
            cboComidaLV.Items.Add(New ListItem(String.Format("{0:00}", T.Hours) & ":" & String.Format("{0:00}", T.Minutes)))
            cboEntradaSabado.Items.Add(New ListItem(String.Format("{0:00}", T.Hours) & ":" & String.Format("{0:00}", T.Minutes)))
            cboSalidaSabado.Items.Add(New ListItem(String.Format("{0:00}", T.Hours) & ":" & String.Format("{0:00}", T.Minutes)))
            cboComidaSabado.Items.Add(New ListItem(String.Format("{0:00}", T.Hours) & ":" & String.Format("{0:00}", T.Minutes)))
            T = (New TimeSpan(T.Hours, T.Minutes + 30, T.Seconds))
        Loop



    End Sub

    Function cboTecs(ByVal sId As String, ByVal SvALOR As String) As DropDownList
        Dim obj As New DropDownList
        obj.ID = sId
        obj.Items.Clear()
        Dim T As New TimeSpan(6, 0, 0)
        Dim TF As New TimeSpan(22, 0, 0)
        Do While T < TF
            obj.Items.Add(New ListItem(String.Format("{0:00}", T.Hours) & ":" & String.Format("{0:00}", T.Minutes)))
            T = (New TimeSpan(T.Hours, T.Minutes + 30, T.Seconds))
        Loop
        Try
            obj.Items.FindByText(SvALOR).Selected = True
        Catch ex As Exception

        End Try
        Return obj
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
    Function cboCamposChips(ByVal sId As String, ByVal SvALOR As String) As DropDownList




        Dim obj As New DropDownList
        obj.ID = sId
        obj.Items.Clear()

        obj.Items.Add(New ListItem("Orden", "noorden"))
        obj.Items.Add(New ListItem("Cita", "numcita"))
        obj.Items.Add(New ListItem("Torre", "colorPrisma"))
        obj.Items.Add(New ListItem("Placas", "noPlacas"))
        obj.Items.Add(New ListItem("VIN", "vin"))
        obj.Items.Add(New ListItem("Nombre Cliente", "Cliente"))

        Try
            obj.Items.FindByValue(SvALOR).Selected = True
        Catch ex As Exception

        End Try
        Return obj
    End Function

    Sub LlenaGVTecnicos()
        Dim sqry As String
        sqry = "SELECT     Tb_TECNICOS.ID_EMPLEADO as ID, Tb_TECNICOS.NOMBRE_EMPLEADO AS NOMBRE,Tb_TECNICOS.ID_TIPO_EMPLEADO AS GRUPO,Tb_TECNICOS.BAHIA, Tb_TECNICOS.COLOR_TECNICO AS COLOR, "
        sqry += " Tb_TECNICOS.HORA_ENT_LV AS [ENTRA LV], Tb_TECNICOS.HORA_SAL_LV AS [SALE LV], Tb_TECNICOS.HORA_COMER  AS [COME LV], Tb_TECNICOS.MIN_COMER_LV AS [T COMIDA], Tb_TECNICOS.HORA_ENT_S  AS [ENTRA S], "
        sqry += " Tb_TECNICOS.HORA_SAL_S AS [SALE SAB], Tb_TECNICOS.HORA_COMER_S AS [COME S], Tb_TECNICOS.MIN_COMER_S AS [T COMIDA] "
        sqry += "  "
        sqry += "  "
        sqry += " FROM         Tb_TECNICOS order by Tb_TECNICOS.BAHIA asc"
        sqry += " "
        gvTecnicos.DataSource = BDClass.SQLtoDataTable(sqry, False)
        gvTecnicos.DataBind()
    End Sub
    Sub LlenaChips()
        Dim sqry As String

        sqry = " select a.*, b.Descripcion as Menu , b.url from SccParametros a inner join SccObjetos b  on a.cveObjeto=b.cveObjeto order by cveObjeto asc, cveParametro asc"
        sqry += " "
        gvChips.DataSource = BDClass.SQLtoDataTable(sqry, False)
        gvChips.DataBind()
    End Sub






    Protected Sub imgUEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim SQRY As String
        gvTecnicos.SelectedIndex = sender.parent.parent.dataitemindex
        SQRY = "DELETE Tb_TECNICOS   WHERE id_empleado='" & gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(1).Text.Trim & "'  "
        BDClass.ExecuteQuery(SQRY, False)
        reorganizar()
    End Sub

    Protected Sub imgUEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvTecnicos.SelectedIndex = sender.parent.parent.dataitemindex
        gvTecnicos.Rows(gvTecnicos.SelectedIndex).FindControl("imgUConfirmar").Visible = True
        gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(2).Controls.Add(txt("txtNT", gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(2).Text))
        gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(5).Controls.Add(cboColores("cboCol1", gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(5).Text))
        gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(6).Controls.Add(cboTecs("cboELV", gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(6).Text))
        gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(7).Controls.Add(cboTecs("cboSLV", gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(7).Text))
        gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(8).Controls.Add(cboTecs("cboCLV", gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(8).Text))
        gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(9).Controls.Add(txt("txtTLV", gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(9).Text))
        gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(10).Controls.Add(cboTecs("cboES", gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(10).Text))
        gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(11).Controls.Add(cboTecs("cboSS", gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(11).Text))
        gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(12).Controls.Add(cboTecs("cboCS", gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(12).Text))
        gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(13).Controls.Add(txt("txtTS", gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(13).Text))

    End Sub

	Protected Sub imgUConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		gvTecnicos.SelectedIndex = sender.parent.parent.dataitemindex
		'BDClass.ExecuteQuery("update  Tb_TECNICOS  set nombre_empleado='" & obtenValor("txtNT") & "',color_tecnico='" & obtenValor("cboCol1") & "', HORA_ENT_LV='" & obtenValor("cboELV") & "',HORA_SAL_LV='" & obtenValor("cboSLV") & "',HORA_COMER='" & obtenValor("cboCLV") & "',MIN_COMER_LV='" & obtenValor("txtTLV") & "' ,  HORA_ENT_S='" & obtenValor("cboES") & "',HORA_SAL_S='" & obtenValor("cboSS") & "',HORA_COMER_S='" & obtenValor("cboCS") & "',MIN_COMER_S='" & obtenValor("txtTS") & "' WHERE BAHIA=" & gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(4).Text & "", False)
		Dim sql As String = "UPDATE TB_TECNICOS SET NOMBRE_EMPLEADO = '" & obtenValor("txtNT") & "'   WHERE BAHIA='" & gvTecnicos.Rows(gvTecnicos.SelectedIndex).Cells(4).Text & "'"
		BDClass.ExecuteQuery(sql, False)
		gvTecnicos.Rows(gvTecnicos.SelectedIndex).FindControl("imgUConfirmar").Visible = False
		LlenaGVTecnicos()
	End Sub

	Protected Sub imgChipConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvTecnicos.SelectedIndex = sender.parent.parent.dataitemindex
        BDClass.ExecuteQuery("update  sccParametros  set  valor='" & obtenValor("txtValor") & "',valor2='" & obtenValor("txtValor2") & "' WHERE cveObjeto=" & gvChips.Rows(gvChips.SelectedIndex).Cells(1).Text & " and cveParametro='" & gvChips.Rows(gvChips.SelectedIndex).Cells(2).Text & "'", False)
        LlenaChips()
    End Sub
    Protected Sub imgChipEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        gvChips.SelectedIndex = sender.parent.parent.dataitemindex
        gvChips.Rows(gvChips.SelectedIndex).FindControl("imgChipConfirmar").Visible = True
        gvChips.Rows(gvChips.SelectedIndex).Cells(4).Controls.Add(txt2("txtValor", gvChips.Rows(gvChips.SelectedIndex).Cells(4).Text))
        gvChips.Rows(gvChips.SelectedIndex).Cells(5).Controls.Add(txt2("txtValor2", gvChips.Rows(gvChips.SelectedIndex).Cells(5).Text))

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
        'obj.Text = Replace(obj.Text, "amp;", "")
        obj.Text = Replace(obj.Text, "&nbsp;", "")
        'obj.Text = Replace(obj.Text, ";", "")
        'obj.Text = Replace(obj.Text, "&", "")
        Return obj
    End Function
    Function txt2(ByVal sId As String, ByVal sValor As String) As TextBox
        Dim obj As New TextBox
        obj.ID = sId
        obj.Text = sValor
        'obj.Text = Replace(obj.Text, "amp;", "")
        obj.Text = Replace(obj.Text, "&nbsp;", "")
        'obj.Text = Replace(obj.Text, ";", "")
        'obj.Text = Replace(obj.Text, "&", "")
        obj.Font.Size = "12"
        obj.TextMode = TextBoxMode.MultiLine
        Return obj
    End Function

    Function cboPerfil(ByVal sId As String, ByVal sValor As String, ByVal sFiltro As String) As DropDownList
        Dim dt As New Data.DataTable, i As Integer


        dt = BDClass.SQLtoDataTable("select cveperfil, descripcion from sccPerfiles where cveGrupo=" & sFiltro & "", False)

        Dim obj As DropDownList
        obj = New DropDownList
        obj.ID = sId
        obj.Items.Clear()


        For i = 0 To dt.Rows.Count - 1
            obj.Items.Add(New ListItem(dt.Rows(i)(1), dt.Rows(i)(0)))
        Next

        Try
            obj.Items.FindByValue(sValor).Selected = True
        Catch ex As Exception

        End Try

        Return obj
    End Function

    Protected Sub cmdGuardarTec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardarTec.Click
        Dim sqry As String = "", dt As New DataTable

        If txtIdEmpleado.Text.Trim.Length = 0 Or (Not IsNumeric(txtMinComidaSabado.Text)) Or (Not IsNumeric(txtMinutosComidaLV.Text)) Or cboEntradaLV.SelectedIndex = cboSalidaLV.SelectedIndex Or cboEntradaSabado.SelectedIndex = cboSalidaSabado.SelectedIndex Then
            TablerosUtilsHyP.iMsgBox(Me.Page, "Existe algun error en los datos proporcionados")
            Exit Sub
        End If

        dt = BDClass.SQLtoDataTable("SELECT ID_EMPLEADO  FROM Tb_TECNICOS where ID_EMPLEADO='" & txtIdEmpleado.Text & "'", False)
        If dt.Rows.Count > 0 Then
            TablerosUtilsHyP.iMsgBox(Me.Page, "La bahia o tecnico ya existen")
            Exit Sub
        End If


        sqry = "insert into  Tb_TECNICOS (ID_EMPLEADO,id_tipo_empleado, NOMBRE_EMPLEADO, Nivel, nombre_asesor,BAHIA, COLOR_TECNICO, HORA_ENT_LV, HORA_SAL_LV, HORA_COMER,MIN_COMER_LV, HORA_ENT_S,  HORA_SAL_S, HORA_COMER_S,  MIN_COMER_S)" _
        & "values ('" & txtIdEmpleado.Text & "','" & cboGrupo.SelectedItem.Value & "','" & txtNombreTec.Text & "','','', 0,'" & cboColor.SelectedItem.Text & "', '" _
        & cboEntradaLV.SelectedItem.Value & "','" & cboSalidaLV.SelectedItem.Value & "','" & cboComidaLV.SelectedItem.Value & "', " & txtMinutosComidaLV.Text & ",'" _
         & cboEntradaSabado.SelectedItem.Value & "','" & cboSalidaSabado.SelectedItem.Value & "','" & cboComidaSabado.SelectedItem.Value & "', " & txtMinComidaSabado.Text & ")"
        If BDClass.ExecuteQuery(sqry, False) = "OK" Then
            reorganizar()
        End If

    End Sub
    Sub reorganizar()
        Dim sqry As String = "", dt As New DataTable, dt2 As New DataTable
        Dim INEXTPOSY As Integer, IINCREMENTOPOSY As Integer

       

        dt2 = BDClass.SQLtoDataTable("select  distinct *  FROM Tb_TECNICOS  ORDER BY   convert(int,bahia) ASC ", False)
        For i = 1 To dt2.Rows.Count
            sqry = "update Tb_TECNICOS set bahia= " & i & " where id_empleado='" & dt2.Rows(i - 1).Item("id_empleado") & "' and bahia=" & dt2.Rows(i - 1).Item("bahia") & " and ID_TIPO_EMPLEADO='" & dt2.Rows(i - 1).Item("ID_TIPO_EMPLEADO") & "' "
            BDClass.ExecuteQuery(sqry, False)
        Next

        dt = BDClass.SQLtoDataTable("select  distinct convert(int,bahia) BAHIA  FROM Tb_TECNICOS  ORDER BY  convert(int,bahia) ASC ", False)


        BDClass.ExecuteQuery("delete Tb_PRG_CHIP_Y", False)
        INEXTPOSY = 95
        IINCREMENTOPOSY = 30
        For J = 0 To dt.Rows.Count - 1
            BDClass.ExecuteQuery("INSERT INTO Tb_PRG_CHIP_Y(NIVELTECNICO, BAHIATECNICO, POSY) VALUES('1'," & dt.Rows(J)("bahia") & "," & INEXTPOSY & ")", False)
            INEXTPOSY = INEXTPOSY + IINCREMENTOPOSY
            BDClass.ExecuteQuery("INSERT INTO Tb_PRG_CHIP_Y(NIVELTECNICO, BAHIATECNICO, POSY) VALUES('0'," & dt.Rows(J)("bahia") & "," & INEXTPOSY & ")", False)

            INEXTPOSY = INEXTPOSY + IINCREMENTOPOSY
        Next


        BDClass.ExecuteQuery("delete Tb_PRG_CHIP_Y_CITAS", False)
        INEXTPOSY = 95
        IINCREMENTOPOSY = 30

        For J = 0 To dt.Rows.Count - 1
            BDClass.ExecuteQuery("INSERT INTO Tb_PRG_CHIP_Y_CITAS(NIVELTECNICO, BAHIATECNICO, POSY) VALUES('1'," & dt.Rows(J)("bahia") & "," & INEXTPOSY & ")", False)
            
            INEXTPOSY = INEXTPOSY + IINCREMENTOPOSY
        Next



        LlenaGVTecnicos()
        llenacbocolores()
    End Sub


    Protected Sub cmdRefreshColores_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRefreshColores.Click
        llenacbocolores()
    End Sub

    Protected Sub cmdReorganizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdReorganizar.Click
        Dim sqry As String = "", dt As New DataTable
        Dim INEXTPOSY As Integer, IINCREMENTOPOSY As Integer



        INEXTPOSY = 95
        IINCREMENTOPOSY = 27
        dt = BDClass.SQLtoDataTable("select  bahia as  bahiatecnico,isnull(NIVELTECNICO, 0) NIVELTECNICO, POSY  FROM Tb_PRG_CHIP_Y  right outer join Tb_TECNICOS on Tb_PRG_CHIP_Y.bahiaTecnico= Tb_TECNICOS.BAHIA  ORDER BY BAHIATECNICO ASC, isnull(NIVELTECNICO, 0) desc ", False)




        For I = 0 To dt.Rows.Count - 1

            If BDClass.SQLtoDataTable("select  bahiatecnico,NIVELTECNICO, POSY  FROM Tb_PRG_CHIP_Y  where   BAHIATECNICO=" & dt(I)("BAHIATECNICO") & " ORDER BY BAHIATECNICO ASC,NIVELTECNICO DESC ", False).Rows.Count = 0 Then
                BDClass.ExecuteQuery("insert into Tb_PRG_CHIP_Y( nombreTecnico, nivelTecnico, bahiaTecnico, bahiaExpress, posY, horaEntrada, horaSalida, horaComida) values (null, 0," & dt(I)("BAHIATECNICO") & ", null, " & INEXTPOSY & ", null, null, null )", False)
                INEXTPOSY = INEXTPOSY + IINCREMENTOPOSY
                BDClass.ExecuteQuery("insert into Tb_PRG_CHIP_Y( nombreTecnico, nivelTecnico, bahiaTecnico, bahiaExpress, posY, horaEntrada, horaSalida, horaComida) values (null, 1," & dt(I)("BAHIATECNICO") & ", null, " & INEXTPOSY & ", null, null, null )", False)
                INEXTPOSY = INEXTPOSY + IINCREMENTOPOSY
            Else
                BDClass.ExecuteQuery("UPDATE Tb_PRG_CHIP_Y SET POSY=" & INEXTPOSY & " WHERE NIVELTECNICO='" & dt(I)("NIVELTECNICO") & "' AND  BAHIATECNICO=" & dt(I)("BAHIATECNICO") & "", False)
                INEXTPOSY = INEXTPOSY + IINCREMENTOPOSY
            End If


        Next


        INEXTPOSY = 95
        IINCREMENTOPOSY = 30



        dt = BDClass.SQLtoDataTable("select  NOMBRETECNICO,bahiatecnico,  POSY  FROM TYT_LV_CC_TBL_POS_CHIP_Y  ORDER BY NOMBRETECNICO ASC, BAHIATECNICO ASC ", False)
        For I = 0 To dt.Rows.Count - 1
            BDClass.ExecuteQuery("UPDATE TYT_LV_CC_TBL_POS_CHIP_Y SET POSY=" & INEXTPOSY & " WHERE NOMBRETECNICO='" & dt(I)("NOMBRETECNICO") & "' AND  BAHIATECNICO=" & dt(I)("BAHIATECNICO") & "", False)
            INEXTPOSY = INEXTPOSY + IINCREMENTOPOSY
        Next


        LlenaGVTecnicos()
        llenacbocolores()
    End Sub

    Private Sub gvChips_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvChips.PreRender
        Dim converter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color))
        Dim color As System.Drawing.Color
        For i = 0 To gvChips.Rows.Count - 1
            Try
                If InStr(gvChips.Rows(i).Cells(4).Text, "#") > 0 Then
                    color = converter.ConvertFromString(gvChips.Rows(i).Cells(4).Text)
                    gvChips.Rows(i).Cells(4).BackColor = color
                End If

            Catch ex As Exception

            End Try

        Next
    End Sub

    Protected Sub gvTecnicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvTecnicos.SelectedIndexChanged

    End Sub
End Class
