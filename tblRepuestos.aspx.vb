Imports TablerosV2LibTypes
Imports System.Data

Public Class tblRepuestos
	Inherits System.Web.UI.Page
	Dim m As String = ""

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Me.IsPostBack Then
			llenaPagina()
			'btnConsultar.Attributes.Add("onclick", "return confirm('¿Seguro que ha leido las condiciones del contrato?')")
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
		Dim num As String = "Repuestos"
		If Not (num.Equals("")) Then
			dt = New DataTable
			dt = Validaciones.GetDatosRepuestos(num)
			If (dt.Rows.Count > 0) Then
				GridCuerpoAsesores.DataSource = dt
				GridCuerpoAsesores.DataBind()
			End If
		End If
	End Sub

	Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
		llenaTblCuerpo()
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
			Dim chk As CheckBox = GridCuerpoAsesores.Items(i).FindControl("chkRepuestos")
			If (s = "0") Then
				Me.GridCuerpoAsesores.Items(i).Style("background-color") = "#F5BCA9"
				chk.Checked = False
			Else
				If (s = "2") Then
					Me.GridCuerpoAsesores.Items(i).Style("background-color") = "#04B404"
					chk.Checked = True
				End If
			End If
		Next
	End Sub

	Protected Sub muestraMensaje()
		Response.Write("<script>window.alert('" & m & "');</script>")
	End Sub

	Protected Sub chkRepuestos_CheckedChanged(sender As Object, e As EventArgs)
		Dim selectedindex = CType(sender.Parent.Parent, DataGridItem).ItemIndex
		Me.GridCuerpoAsesores.SelectedIndex = selectedindex
		Dim num As Integer = CInt(GridCuerpoAsesores.SelectedItem.Cells(8).Text)
		Dim chk As CheckBox = GridCuerpoAsesores.SelectedItem.FindControl("chkRepuestos")
		If chk.Checked = True Then
			Dim rep = Validaciones.setRepuestosOk(num, True)
		Else
			Dim rep = Validaciones.setRepuestosOk(num, False)
		End If
		llenaTblCuerpo()
	End Sub
End Class