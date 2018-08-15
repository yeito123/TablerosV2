Imports TablerosV2LibTypes
Imports System.Data


Public Class TblNoShow
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			cargaInfoNoShow()
			llenaTblCuerpoInicial()
		End If
	End Sub


	Private Sub llenaTblCuerpoInicial()
		Dim dt As DataTable
		Dim num As String = "0"
		Dim s As String = ""
		dt = getNoShow(1, "")
		GridCuerpoAsesores.DataSource = dt
		GridCuerpoAsesores.DataBind()
	End Sub
	Protected Sub cargaInfoNoShow()
		Dim dt As DataTable
		Dim sql As String
		sql = "EXEC ISP_INFORMACION_NOSHOW"
		BDClass.ExecuteQuery(sql, False)
	End Sub


	Private Function getNoShow(ByVal SWITCH As Integer, ByVal fecha As String) As DataTable
		Dim dt As DataTable
		Dim sql As String
		Select Case SWITCH
			Case 1
				sql = "SELECT * FROM V_CITAS_NOSHOW WHERE CONVERT(DATE,FECHA_HORA_CITA) = CONVERT(DATE, GETDATE())"
			Case 2
				Dim s As String
				s = String.Format("{0:s}", CDate(fecha))
				sql = "SELECT * FROM V_CITAS_NOSHOW WHERE CONVERT(DATE,FECHA_HORA_CITA) = CONVERT(DATE, '" & s & "')"
		End Select
		dt = BDClass.SQLtoDataTable(sql, False)
		Return dt
	End Function

	Protected Sub txtFechaEntrada_TextChanged(sender As Object, e As EventArgs)
		Dim dt As DataTable
		Dim num As String = "0"
		Dim s As String = ""
		dt = getNoShow(2, txtFechaEntrada.Text.Trim)
		GridCuerpoAsesores.DataSource = dt
		GridCuerpoAsesores.DataBind()
	End Sub
End Class