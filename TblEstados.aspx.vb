Imports TablerosV2LibTypes
Imports System.Data

Public Class TblEstados
	Inherits System.Web.UI.Page
	Dim m As String = ""

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Me.IsPostBack Then
			llenaPagina()
		End If
	End Sub
	Protected Sub llenaPagina()
		llenaCmdAsesor()
		llenaTblCuerpo()
	End Sub
	Protected Sub llenaCmdAsesor()
		Dim dt As DataTable
		Dim num As Integer = Validaciones.getCvePerfil("asesores")
		If (num < 0) Then
			Response.Redirect("inicio.aspx")
		Else
			dt = New DataTable
			dt = Validaciones.getUsuariosPerfil(num)
			If (dt.Rows.Count > 0) Then
				For i = 0 To dt.Rows.Count - 1
					cmdAsesores.Items.Add(New ListItem(dt.Rows(i).Item("Nombre"), dt.Rows(i).Item("cveUsuario")))
				Next
				cmdAsesores.Items.Add(New ListItem("TODOS", "TODOS"))
			Else
				m = "no se encontro ningun dato"
				Response.Write("<script>window.alert('" & m & "');</script>")
			End If
		End If
	End Sub

	Private Sub llenaTblCuerpo()
		Dim dt As DataTable
		Dim num As String = "0"
		Dim s As String = cmdAsesores.SelectedItem.Value.ToString
		If s <> "TODOS" Then
			num = Validaciones.IdAsesor(s)
			If Not (num.Equals("")) Then
				dt = New DataTable
				dt = Validaciones.DatosAsesor(num)
				If (dt.Rows.Count > 0) Then
					GridCuerpoAsesores.Visible = True
					GridCuerpoAsesores.DataSource = dt
					GridCuerpoAsesores.DataBind()
				Else
					GridCuerpoAsesores.Visible = False
				End If
				dt = Validaciones.getcontadorAsesor(num)
				If (dt.Rows.Count > 0) Then
					gridContadorAsesor.Visible = True
					gridContadorAsesor.DataSource = dt
					gridContadorAsesor.DataBind()
				Else
					gridContadorAsesor.Visible = False
				End If
			End If
		Else
			dt = New DataTable
			dt = Validaciones.DatosAsesorTodos(s)
			If (dt.Rows.Count > 0) Then
				GridCuerpoAsesores.DataSource = dt
				GridCuerpoAsesores.DataBind()
			End If
			'm = s
			'muestraMensaje()
			dt = Validaciones.getcontadorAsesor(s)
			If dt.Rows.Count > 0 Then
				gridContadorAsesor.DataSource = dt
				gridContadorAsesor.DataBind()
			End If
		End If

	End Sub

	Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
		llenaTblCuerpo()
	End Sub

	Protected Sub ImgMensaje_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim selectedindex = CType(sender.Parent.Parent, DataGridItem).ItemIndex
		Me.GridCuerpoAsesores.SelectedIndex = selectedindex
		Dim num As Integer = CInt(GridCuerpoAsesores.SelectedItem.Cells(8).Text)
		If (Not IsDBNull(num)) Then
			Dim infoMsj As ChipHeader = New ChipHeader(num)

			'm += "Telefono: " & infoMsj.Telefonos1
			'm += " Señor " & infoMsj.Cliente1 & " queremos informarle de la manera mas atenta que su vehículo "
			'm += "Con Placas: " & infoMsj.NoPlacas1 & " Ya se encuentra listo y puede pasar por el cuando guste."
			'Response.Write("<script>window.alert('" & m & "');</script>")

			m = "https://web.whatsapp.com://send?text=" & "Telefono: " & infoMsj.Telefonos1
			m += " Señor " & infoMsj.Cliente1 & " queremos informarle de la manera mas atenta que su vehículo "
			m += "Con Placas " & infoMsj.NoPlacas1 & " Ya se encuentra listo y puede pasar por el cuando guste."



			'Me.lblTexto.Text = "https://web.whatsapp.com://send?text=" & m
			'Me.mpe2.Show()
			Response.Redirect(m)
		Else
			m = "hay algo mal en la captura el numero"
			Response.Write("<script>window.alert('" & m & "');</script>")
		End If


	End Sub

	Protected Sub imgdet_Click(sender As Object, e As ImageClickEventArgs)
		Dim selectedindex = CType(sender.Parent.Parent, DataGridItem).ItemIndex
		Me.GridCuerpoAsesores.SelectedIndex = selectedindex
		Dim num As Integer = CInt(GridCuerpoAsesores.SelectedItem.Cells(8).Text)
		'txtCliente.Text = "Por fin hp"
		Dim dt As DataTable = New DataTable
		If (Not IsDBNull(num)) Then
			Dim infodetalleHeader As ChipHeader = New ChipHeader(num)
			Dim sql As String = "select nombre from sccUsuarios where cveasesor = '" & infodetalleHeader.IdAsesor1 & "'"
			dt = BDClass.SQLtoDataTable(sql, False)
			If (dt.Rows.Count > 0) Then
				lblAsesordet.Text = "|| Asesor Encargado: " & dt.Rows(0).Item("nombre").ToString
			Else
				lblAsesordet.Text = "Asesor Encargado: Sin Coincidencias"
			End If
			Me.InfoIdhd.Text = num
			lblTitulo.Text = "STATUS GENERAL: " & infodetalleHeader.Status1
			txtCliente.Text = infodetalleHeader.Cliente1
			txtTelefono.Text = infodetalleHeader.Telefonos1
			txtPlacas.Text = infodetalleHeader.NoPlacas1
			txtOrden.Text = infodetalleHeader.Noorden1
			txtIngreso.Text = infodetalleHeader.Horallegada1
			txtPromesa.Text = infodetalleHeader.Fecha_hora_com1
			Dim diasTaller As Integer = calculaTiempo(infodetalleHeader.Horallegada1, Date.Now())
			Dim diasUltEstado As Integer = calculaTiempo(infodetalleHeader.Fecha_hora_Status1, Date.Now())
			txtDiasTaller.Text = diasTaller
			txtDiasEstado.Text = diasUltEstado
			dt = Validaciones.getDetalle(infodetalleHeader.Id_hd1)
			If (dt.Rows.Count > 0) Then
				GridDetalles.DataSource = dt
				GridDetalles.DataBind()
			End If
		End If
		Me.mpe.Show()
	End Sub


	Protected Function calculaTiempo(inicios As DateTime, fin As DateTime) As Integer
		Dim numero As Integer
		numero = DateDiff(DateInterval.Day, inicios, fin)
		Return numero
	End Function


	Protected Sub cuerpoAsesores_preRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCuerpoAsesores.PreRender
		Dim i As Integer = 0
		Dim n As Integer = Me.GridCuerpoAsesores.Items.Count
		Dim s As String
		For i = 0 To n - 1
			s = Me.GridCuerpoAsesores.Items(i).Cells(9).Text.Trim
            If (s = "1") Then
                Me.GridCuerpoAsesores.Items(i).Style("background-color") = "#F5BCA9"
            End If
            If (s = "2") Then
                Me.GridCuerpoAsesores.Items(i).Style("background-color") = "#8EF171  "
            End If

        Next
	End Sub

	'Protected Sub cuerpoAsesores_preRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalles.PreRender
	'	Dim i As Integer = 0
	'	Dim n As Integer = Me.GridDetalles.Items.Count
	'	Dim s As String
	'	For i = 0 To n - 1
	'		s = Me.GridCuerpoAsesores.Items(i).Cells(9).Text.Trim
	'		If (s = "1") Then
	'			Me.GridDetalles.Items(i).Style("background-color") = "#F5BCA9"
	'		End If
	'	Next
	'End Sub

	Protected Sub muestraMensaje()
		'Cuando trabajas con UpdatePanel tienes que usar Scripts Asyncrono, y se ponen así:
		ScriptManager.RegisterStartupScript(pnlPanle, pnlPanle.GetType(), "script1", "<script>window.alert('" & m & "');</script>", False)
	End Sub

	Protected Sub muestraMensaje2()
		Response.Write("<script>window.alert('" & m & "');</script>")
	End Sub
	Protected Sub btnMsn_Click(sender As Object, e As EventArgs) Handles btnMsn.Click
		Dim idhd As String = lblPLacaMsg.Value.Trim
		Dim msj As String = lblMensaje.Value.Trim
		Dim sql As String = ""
		sql = "INSERT INTO TB_MENSAJES_WPP (ID_HD, FECHA_HORA, MENSAJE) "
		sql += "VALUES ('" & idhd & "', GETDATE(), '" & msj & "')"
		BDClass.ExecuteQuery(sql, False)
	End Sub



	Protected Sub cmdEstados_SelectedIndexChanged(sender As Object, e As EventArgs)
		Dim Num As String = Me.InfoIdhd.Text
		Dim stat As String = Me.cmdEstados.SelectedItem.Value
		Dim sql As String = "EXEC ISP_CAMBIAR_ESTADO '" & Num & "','" & stat & "'"
		BDClass.ExecuteQuery(sql, False)
		'Me.cmdEstados.SelectedItem.Value = 0
	End Sub

    Protected Sub btnPdf_Click(sender As Object, e As EventArgs)
        Dim formato As String = System.Web.Configuration.WebConfigurationManager.AppSettings("url_ssl_pdf")
        Dim selectedindex = CType(sender.Parent.Parent, DataGridItem).ItemIndex
        Me.GridCuerpoAsesores.SelectedIndex = selectedindex
        Dim num As Integer = CInt(GridCuerpoAsesores.SelectedItem.Cells(0).Text)
        Dim url As String = "http://10.30.86.41:3000/api/ssl/Tecnico/getPDFLista/orden/" & num & "/checklist/" & formato & ".pdf"
        Response.Redirect(url)
    End Sub

    Protected Sub btncontrato_Click(sender As Object, e As EventArgs)
        Dim formato As String = System.Web.Configuration.WebConfigurationManager.AppSettings("contrato_ssl_pdf")
        Dim selectedindex = CType(sender.Parent.Parent, DataGridItem).ItemIndex
        Me.GridCuerpoAsesores.SelectedIndex = selectedindex
        Dim num As Integer = CInt(GridCuerpoAsesores.SelectedItem.Cells(0).Text)
        Dim url As String = formato & num & ".pdf"

    End Sub

    'Protected Sub btnSalida_Click(sender As Object, e As EventArgs) Handles btnSalida.Click
    '	Dim num As Integer = CInt(lblPLacaMsg.Value.Trim)
    '	Dim sql As String = ""
    '	sql = "update tb_citas_header_nw set horaretiro = getdate() where id_hd = '" & num & "'"
    '	BDClass.ExecuteQuery(sql, False)
    '	GridCuerpoAsesores.Visible = False
    '	llenaTblCuerpo()
    'End Sub
End Class