Imports TablerosV2LibTypes
Imports System.Data


Public Class TblHistorial
	Inherits System.Web.UI.Page
	Dim m As String = ""

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Me.IsPostBack Then
			llenaPagina()
		End If
	End Sub
	Protected Sub llenaPagina()
		llenaTblCuerpoInicial()
	End Sub


	Private Sub llenaTblCuerpo()
		Dim dt As DataTable
		Dim num As String = "0"
		Dim s As String = ""
		If (txtPlacas1.Text.Trim.Count > 0) Then
			If (txtPlacas1.Text.Trim.Count = 6) Then
				s = txtPlacas1.Text.Trim
				dt = Validaciones.getHistorial(s, 1)
				GridCuerpoAsesores.DataSource = dt
				GridCuerpoAsesores.DataBind()
			Else
				m = "Debe ingresar una placa Valida."
				muestraMensaje()
			End If
		End If
		If (txtFechaEntrada.Text.Trim.Count > 0) Then
			s = String.Format("{0:s}", CDate(txtFechaEntrada.Text.Trim))
			dt = Validaciones.getHistorial(s, 3)
			GridCuerpoAsesores.DataSource = dt
			GridCuerpoAsesores.DataBind()
		Else
			If (txtFechaSalida.Text.Trim.Count > 0) Then
				s = String.Format("{0:s}", CDate(txtFechaSalida.Text.Trim))
				dt = Validaciones.getHistorial(s, 4)
				GridCuerpoAsesores.DataSource = dt
				GridCuerpoAsesores.DataBind()
			End If
		End If
	End Sub

	'Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
	'	llenaTblCuerpo()
	'End Sub


	Protected Sub imgdet_Click(sender As Object, e As ImageClickEventArgs)
		Dim selectedindex = CType(sender.Parent.Parent, DataGridItem).ItemIndex
		Me.GridCuerpoAsesores.SelectedIndex = selectedindex
		Dim num As Integer = CInt(GridCuerpoAsesores.SelectedItem.Cells(9).Text)
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
			txtDiasEstado.Text = infodetalleHeader.HoraRetiro1
			dt = Validaciones.getDetalleHistorial(infodetalleHeader.Id_hd1)
			If (dt.Rows.Count > 0) Then
				GridDetalles.DataSource = dt
				GridDetalles.DataBind()
			End If
		End If
		Me.mpe.Show()
	End Sub

	Protected Sub btnSalir_Click(sender As Object, e As ImageClickEventArgs)
		Response.Redirect("inicio.aspx")
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
		Next
	End Sub


	Protected Sub muestraMensaje()
		Response.Write("<script>window.alert('" & m & "');</script>")
	End Sub

	Protected Sub txtPlacas1_TextChanged(sender As Object, e As EventArgs)
		llenaTblCuerpo()
		txtPlacas1.Text = ""
	End Sub

	Private Sub llenaTblCuerpoInicial()
		Dim dt As DataTable
		Dim num As String = "0"
		Dim s As String = ""
		dt = Validaciones.getHistorial(s, 2)
		GridCuerpoAsesores.DataSource = dt
		GridCuerpoAsesores.DataBind()
	End Sub

	Protected Sub txtFechaSalida_TextChanged(sender As Object, e As EventArgs)
		llenaTblCuerpo()
		txtFechaSalida.Text = ""
	End Sub

	Protected Sub txtFechaEntrada_TextChanged(sender As Object, e As EventArgs)
		llenaTblCuerpo()
		txtFechaEntrada.Text = ""
	End Sub

	Protected Sub lnkPlacas_Click(sender As Object, e As EventArgs)
		Dim selectedindex = CType(sender.Parent.Parent, DataGridItem).ItemIndex
		Me.GridCuerpoAsesores.SelectedIndex = selectedindex
		Dim num As String = GridCuerpoAsesores.SelectedItem.Cells(12).Text
		Dim dt As DataTable = New DataTable
		dt = Validaciones.getHistorial(num, 1)
		GridCuerpoAsesores.DataSource = dt
		GridCuerpoAsesores.DataBind()
	End Sub
End Class