Imports TablerosV2LibTypes
Imports System.Data

Public Class TblPullRecepcion
	Inherits System.Web.UI.Page
	Dim pantalla As String

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		llenaPie()
		inicializaVariables()
		llenaPull()
		cargaFechaHora()
	End Sub

	Private Sub llenaPull()
		pintaCarros("divR_")
		pintaCarros("divRa_")
		pintaCarros("divEs_")
		pintaCarros("divEb_")
		pintaCarros("divEl_")
		pintaCarros("divLe_")
	End Sub
	Private Sub inicializaVariables()
		Dim interval As Integer
		interval = Validaciones.getTiempoTimer("%tblPullRecepcion%") 'trae el tiempo que debe permanecer esta pantalla
		'Timer5.Interval = interval * 1000
		pantalla = Validaciones.getpantallaTimer("%tblPullRecepcion%") 'trae la pantalla a la que debe dirigirse
	End Sub


	Private Sub llenaPie()
		Dim sql As String = "select * from sccParametros where cveParametro = 'iInfoAgencia'"
		Dim dt As DataTable = New DataTable()
		dt = BDClass.SQLtoDataTable(sql, False)
		If dt.Rows.Count > 0 Then
			Dim mensaje = dt.Rows(0).Item("Valor") + " | " + dt.Rows(0).Item("Valor2")
			lblPie.Text = mensaje
		End If
	End Sub

	Protected Sub muestraMensaje2(m As String)
		Response.Write("<script>window.alert('" & m & "');</script>")
	End Sub

	Protected Sub timer5_tick(sender As Object, e As EventArgs) Handles Timer5.Tick
		Response.Redirect("recepcion_mazda.aspx")
	End Sub

	Protected Sub cargaCarros()

	End Sub


	Protected Sub pintaCarros(ByVal ref As String)
		Dim dt As DataTable = New DataTable()
		Dim n As Integer
		Select Case ref
			'recepcion
			Case "divR_"
				dt = Validaciones.ChipsStatus("Recepcion", 5)
				n = dt.Rows.Count
				If n > 0 Then
					For i = 0 To n - 1
						displayCarro(ref & (i + 101), dt.Rows(i).Item("noPlacas"), "lblR_" & (i + 101))
					Next
				End If
			'recepcion asesores
			Case "divRa_"
				dt = Validaciones.ChipsStatus("RecepcionAsesor", 4)
				n = dt.Rows.Count
				If n > 0 Then
					For i = 0 To n - 1
						displayCarro(ref & (i + 101), dt.Rows(i).Item("noPlacas"), "lblRa_" & (i + 101))
					Next
				End If
			'espera servicio
			Case "divEs_"
				dt = Validaciones.ChipsStatusbahia("EsperaServicio", 4)
				n = dt.Rows.Count
				If n > 0 Then
					For i = 0 To n - 1
						displayCarro(ref & (i + 101), dt.Rows(i).Item("noPlacas"), "lblEs_" & (i + 101))
					Next
				End If
			'en bahia
			Case "divEb_"
				dt = Validaciones.ChipsStatusbahia("EnBahia", 5)
				n = dt.Rows.Count
				If n > 0 Then
					For i = 0 To n - 1
						displayCarro(ref & (dt.Rows(i).Item("bahia") + 100), dt.Rows(i).Item("noPlacas"), "lblEb_" & (dt.Rows(i).Item("bahia") + 100))
					Next
				End If
			'en lavado
			Case "divEl_"
				dt = Validaciones.ChipsStatusLavado("lavado", 3)
				n = dt.Rows.Count
				If n > 0 Then
					For i = 0 To n - 1
						displayCarro(ref & (i + 101), dt.Rows(i).Item("noPlacas"), "lblEl_" & (i + 101))
					Next
				End If
			'listo entrega
			Case "divLe_"
				dt = Validaciones.ChipsStatusTerminado("Terminado", 6)
				n = dt.Rows.Count
				If n > 0 Then
					For i = 0 To n - 1
						displayCarro(ref & (i + 101), dt.Rows(i).Item("noPlacas"), "lblLe_" & (i + 101))
					Next
				End If
		End Select
	End Sub

	Private Sub displayCarro(ByVal id As String, ByVal placa As String, ByVal label As String)
		Dim d As Panel = Me.FindControl(id)
		Dim l As Label = Me.FindControl(label)
		d.Style("display") = "inline"
		l.Text = placa
	End Sub

	Protected Sub cargaFechaHora()
		Dim hora As String
		Dim smes As String
		Dim minutos As String

		hora = Date.Now.Hour()
		minutos = Date.Now.Minute()
		If minutos < 10 Then
			minutos = "0" & minutos
		End If
		If (hora < 12) Then
			hora = hora & ":" & minutos & " a.m"
		Else
			If (hora > 12) Then
				hora = (hora - 12) & ":" & minutos & " p.m"
			Else
				hora = hora & ":" & minutos & " p.m"
			End If
		End If

		Dim d(11) As String


		Dim dia As String = getdias(7, Date.Now.DayOfWeek)
		Dim mes As String = getdias(12, Date.Now.Month)
		Dim dias As Integer = Date.Now.Day

		Me.nMes.Text = mes & " " & dias & ", " & dia
		Me.nreloj.Text = hora


	End Sub


	Private Function getdias(ByVal n As Integer, ByVal NUM As Integer) As String
		Dim Respuesta As String
		Dim v(n) As String
		If n = 7 Then
			v(0) = "LUNES"
			v(1) = "MARTES"
			v(2) = "MIERCOLES"
			v(3) = "JUEVES"
			v(4) = "VIERNES"
			v(5) = "SABADO"
			v(6) = "DOMINGO"
		Else
			v(0) = "ENERO"
			v(1) = "FEBRERO"
			v(2) = "MARZO"
			v(3) = "ABRIL"
			v(4) = "MAYO"
			v(5) = "JUNIO"
			v(6) = "JULIO"
			v(7) = "AGOSTO"
			v(8) = "SEPTIEMBRE"
			v(9) = "OCTUBRE"
			v(10) = "NOVIEMBRE"
			v(11) = "DICIEMBRE"
		End If

		For i = 0 To v.Length - 1
			If i = NUM - 1 Then
				Respuesta = v(i)
			End If
		Next
		Return Respuesta
	End Function

End Class