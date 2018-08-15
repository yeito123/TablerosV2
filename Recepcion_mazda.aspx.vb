Imports TablerosV2LibTypes
Imports System.Data

Public Class Recepcion_mazda
	Inherits System.Web.UI.Page
	Dim pantalla As String

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		cargarCitas()
		llenaPie()
		inicializaVariables()
		cargaFechaHora()
	End Sub


	Private Sub inicializaVariables()
		Dim interval As Integer
		interval = Validaciones.getTiempoTimer("%recepcion_mazda%") 'trae el tiempo que debe permanecer esta pantalla
		Timer5.Interval = interval * 1000
		pantalla = Validaciones.getpantallaTimer("%recepcion_mazda%") 'trae la pantalla a la que debe dirigirse
	End Sub
	Protected Sub cargarCitas()
		Dim dt As New DataTable
		Dim sqry As String = ""
		Dim obj As New BDClass
		Dim ipage As Integer = gridInfoCitas.CurrentPageIndex
		' sqry = "Select * from TYT_LV_TBL_CONTROL_CITAS_header where  year(fecha)=" & Date.Now.Year & " and month(fecha)=" & Date.Now.Month & " and day(fecha)=" & Date.Now.Day & "  and NUMCITA<>'0' AND NOORDEN ='0'   order by HORAASESOR asc"
		sqry = "Select  * from  " & System.Web.Configuration.WebConfigurationManager.AppSettings.Item("vreceppcioncitasAll").ToString & " ORDER BY HORAASESOR asc"

		dt = obj.SQLtoDataTable(sqry, False)
		Session("dtGrid") = dt
		gridInfoCitas.CurrentPageIndex = 0

		If gridInfoCitas.PageCount < 1 Then
			gridInfoCitas.CurrentPageIndex = 0
		Else
			Try

				If (ipage + 1) < gridInfoCitas.PageCount Then
					gridInfoCitas.CurrentPageIndex = ipage + 1
				Else
					gridInfoCitas.CurrentPageIndex = 0
				End If

			Catch
				gridInfoCitas.CurrentPageIndex = 0
			End Try

		End If


		gridInfoCitas.DataSource = dt

		gridInfoCitas.DataBind()

		'ScriptManager.RegisterStartupScript(UPGUARDAV, UPGUARDAV.GetType(), "animacion", "verificarAnimacion();", True)
	End Sub

	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		cargarCitas()
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

	Protected Sub infoCitas_preRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridInfoCitas.PreRender
		Dim i As Integer = 0
		Dim n As Integer = Me.gridInfoCitas.Items.Count
		Dim s As String
		Dim img As Image
		For i = 0 To n - 1
			s = Me.gridInfoCitas.Items(i).Cells(6).Text.Trim
			Me.gridInfoCitas.Items(i).Cells(0).Style("color") = "#FDFBFB"
			Me.gridInfoCitas.Items(i).Cells(4).Style("color") = "#851e31"
			Me.gridInfoCitas.Items(i).Cells(4).Style("font-weight") = "bold"
			Me.gridInfoCitas.Items(i).Cells(3).Style("color") = "#FDFBFB"
			Me.gridInfoCitas.Items(i).Cells(3).Style("font-weight") = "bold"
			Me.gridInfoCitas.Items(i).Cells(5).Style("color") = "#FDFBFB"
			If ((i Mod 2) = 0) Then
				Me.gridInfoCitas.Items(i).Style("background-color") = "#212524"
			Else
				Me.gridInfoCitas.Items(i).Style("background-color") = "#282829"
			End If

			If (s = "DEMORADO") Then
				img = Me.gridInfoCitas.Items(i).FindControl("imgRetrasado")
				img.Style("display") = "inline"
				Me.gridInfoCitas.Items(i).Cells(6).Style("color") = "#851e31"
				'Me.gridInfoCitas.Items(i).Cells(6).Style("font-weight") = "bold"
			Else
				If s = "NO LLEGA" Then
					img = Me.gridInfoCitas.Items(i).FindControl("imgDemorado")
					img.Style("display") = "inline"
				Else
					img = Me.gridInfoCitas.Items(i).FindControl("imgATiempo")
					img.Style("display") = "inline"
				End If
			End If
		Next
	End Sub

	Protected Sub timer5_tick(sender As Object, e As EventArgs) Handles Timer5.Tick
		Response.Redirect("tblmap_ruta.aspx")
	End Sub

	Protected Sub Timer11_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer11.Tick
		cargarCitas()
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

		Me.nMes.Text = mes & " " & dias & ", "
		Me.nDia.Text = dia
		Me.nDia.Style("font-weight") = "bold"
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