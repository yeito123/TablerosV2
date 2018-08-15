Imports TablerosV2LibTypes

Public Class pantallaPrecios
    Inherits System.Web.UI.Page
    Dim img As New HtmlImage
    Dim Imagen As String
    Dim n As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("ref") = Session("ref") + 1
        n = calcularNumero()
        If (Session("ref") < n) Then
            llenaprecios()
        End If
    End Sub

    Private Function calcularNumero()
        Dim dt As DataTable
        Dim sql As String
		sql = "SELECT CANTIDADDEPANTALLAS FROM TB_PANTALLAS_BIENVENIDA --WHERE IDPANTALLA LIKE '%PRECIO%' "
		dt = BDClass.SQLtoDataTable(sql, False)
        Return dt.Rows(0).Item("CANTIDADDEPANTALLAS")
    End Function

    'Carga tanto imagenes como informacion
    Private Sub llenaprecios()
        img.Src = ""
        Imagen = ""
        'Session("ref") = Session("ref") + 1
        Imagen = "img/bienvenida_" & Session("ref") & ".png"
        img.Src = Imagen
        img.Style.Add("width", "100%")
        img.Style.Add("height", "100%")
        divimg.Controls.Add(img)
        llenaLabels()
		llenaAceite()
	End Sub


    'Private Sub llenainfotaller()
    '    img.Src = ""
    '    Imagen = ""
    '    'Session("ref") = Session("ref") + 1
    '    Imagen = "img/bienvenida_6.png"
    '    img.Src = Imagen
    '    img.Style.Add("width", "100%")
    '    img.Style.Add("height", "100%")
    '    divimg.Controls.Add(img)
    '    lbl1.Visible = True
    '    lbl2.Visible = True
    '    lbl3.Visible = True
    '    lbl4.Visible = True
    '    lbl5.Visible = True
    '    lbl6.Visible = True
    '    'llenaLabels()
    '    'llenaAceite()
    'End Sub
    'cambia las imagenes y los datos de la misma
    Protected Sub timer1_tick()
		If (Session("ref") > n - 1) Then
			Session.Remove("ref")
			Dim dt As DataTable = New DataTable
			Dim s As String = "SELECT [pasaracitas] FROM [TB_PANTALLAS_BIENVENIDA] --where idPantalla like '%precio%'"
			dt = BDClass.SQLtoDataTable(s, False)
			If dt.Rows.Count > 0 Then
				s = dt.Rows(0).Item("pasaracitas")
			Else
				s = "Pantallaprecios.aspx"
			End If
			Response.Redirect(s)
		End If
	End Sub
    'Trae la informacion de la base de datos.
    Private Function TraeLosPrecios(ByVal n As Integer, ByVal b As Boolean) As DataTable
        Dim dt As DataTable
        Dim sql As String
        If (b) Then
            sql = "SELECT a.marca, a.modelo, a.ano, a.kilometraje, a.valor FROM v_precios_MTO as a WHERE a.marca =  '" & n & "' order by a.kilometraje"
        Else
            sql = "SELECT a.marca, a.modelo, a.ano, a.kilometraje, a.valor FROM v_precios_MTO_5000 as a WHERE a.marca =  '" & n & "' order by a.kilometraje"
        End If
        dt = BDClass.SQLtoDataTable(sql, False)
        Return dt
    End Function


    Private Sub llenaLabels()
        If (Session()("ref") < n) Then
            Dim dt As DataTable = TraeLosPrecios(Session("ref"), True)
            lbl1.Text = "$" & Format(dt.Rows(0).Item("valor"), "##,##")
            lbl2.Text = "$" & Format(dt.Rows(1).Item("valor"), "##,##")
            lbl3.Text = "$" & Format(dt.Rows(2).Item("valor"), "##,##")
			lbl4.Text = "$" & Format(dt.Rows(3).Item("valor"), "##,##")
			lbl5.Text = "$" & Format(dt.Rows(4).Item("valor"), "##,##")
			'lbl6.Text = "$" & Format(dt.Rows(5).Item("valor"), "##,##")
			'lbl7.Text = "$" & Format(dt.Rows(6).Item("valor"), "##,##")
		End If
	End Sub

    Private Sub llenaAceite()
        If (Session()("ref") < n) Then
            Dim dt As DataTable = TraeLosPrecios(Session("ref"), False)
            lbl6.Text = "$" & Format(dt.Rows(0).Item("valor"), "##,##")
        End If
    End Sub
End Class