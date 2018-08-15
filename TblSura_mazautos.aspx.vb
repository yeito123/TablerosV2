Imports TablerosV2LibTypes
Imports System.Data

Public Class TblSura_mazautos
	Inherits System.Web.UI.Page

	Dim m As String = ""

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Me.IsPostBack Then
			llenaPagina()
		End If
	End Sub
	Protected Sub llenaPagina()
		llenaTblCuerpo()
	End Sub


	Private Sub llenaTblCuerpo()
		Dim dt As DataTable
		Dim num As String = "0"
		num = "select * from TABLEROV2HYP.DBO.v_informe_sura"
		dt = BDClass.SQLtoDataTable(num, False)
		If dt.Rows.Count > 0 Then
			GridCuerpoAsesores.DataSource = dt
			GridCuerpoAsesores.DataBind()
		Else
			GridCuerpoAsesores.Visible = False
		End If
	End Sub

	Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
		llenaTblCuerpo()
	End Sub




	Protected Function calculaTiempo(inicios As DateTime, fin As DateTime) As Integer
		Dim numero As Integer
		numero = DateDiff(DateInterval.Day, inicios, fin)
		Return numero
	End Function
End Class