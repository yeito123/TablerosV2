Imports TablerosV2LibTypes


'se usa la columna vehiculootro de tb_citas para saber la bahia en la que ira el carro
' se creo la tabla tb_tecnicos_bahias_camiones para saber que bahia corresponde a cada tecnico siendo (a,b o c)


Public Class tblPullCamiones
	Inherits System.Web.UI.Page

	Sub PINTACHIPS()
		Dim OBJCOL As New CHIPPullCollection, objchip As ChipPull, bAlarm As Boolean, sMsgAlarm As String = ""
		Dim sColor As String, oChip As String, iNivel As Integer = 0, bAlarmF As Boolean = False
		Dim imgLst As New ArrayList()

		OBJCOL = OBJCOL.ObtenChips
		Session("ColPullChips") = OBJCOL
		For i = 1 To OBJCOL.Count
			objchip = OBJCOL.Item(i - 1)
			sColor = TablerosUtilsHyP.ObtenColorAsesor(objchip.IDASESOR)
			oChip = Left(objchip.OCHIP, 2)

			bAlarm = False
			sMsgAlarm = ""
			If Not objchip.CHIPOP Is Nothing Then
				If CDate(objchip.CHIPOP.FECHA.ToShortDateString).AddHours(Val(Left(objchip.CHIPOP.HORARAMPA, 2))).AddMinutes(Val(Right(objchip.CHIPOP.HORARAMPA, 2))) <= Date.Now And objchip.CHIPOP.STATUS.ToLower = "pendiente" And objchip.CHIPOP.SERVICIOCAPTURADO <> "Lavado" And (Left(objchip.IDFICHA, 1) = "f") Then
					bAlarm = True
					sMsgAlarm = "Retrasado para iniciar"
				End If
			End If

			imgLst.Add("ds" & String.Format("{0:000}", i))

			chipBoard(i, objchip, sColor, bAlarm, sMsgAlarm, bAlarmF)
		Next
		Session("imgLst") = imgLst
	End Sub

	Private Sub llenaContador()
		Dim dt As DataTable
		Dim num As String = "0"
		Dim s As String = "TODOS"

		dt = New DataTable
		dt = Validaciones.getcontadorAsesor(s)
		If dt.Rows.Count > 0 Then
			gridContadorAsesor.DataSource = dt
			gridContadorAsesor.DataBind()
		End If
	End Sub

	Function imageCHIP(ByVal sChip As String, ByVal obj As ChipPull, ByRef stext As String, ByRef sTecnico As String, ByRef sLeft As String, ByRef sstop As String, ByRef btecnico As Boolean) As String
		btecnico = False

		sTecnico = ""
		If obj.NUMCITA <> "0" Then
			imageCHIP = obj.IMGCC
		Else
			imageCHIP = obj.IMGSC
		End If

		imageCHIP = buscarurlImagen(obj.IDHD)

		If imageCHIP = "" Then
			imageCHIP = obj.IMGCC
		End If


		stext = obj.CAMPOMOSTRAR

		If obj.ESBAHIA Then
			sTecnico = TablerosUtilsHyP.ObtenNombreTecnicos(obj.CHIPOP.IDTECNICO)
			btecnico = obj.ESBAHIA
		End If
		obj.FICHALEFT = obj.FICHALEFT
		Select Case sChip
			Case Is = "h"
				sLeft = (obj.FICHALEFT - 35) & "px"
				sstop = (obj.FICHATOP) & "px"

			Case Is = "r"
				sLeft = (obj.FICHALEFT) & "px"
				sstop = (obj.FICHATOP + 35) & "px"

			Case Is = "g"

				sLeft = (obj.FICHALEFT) & "px"
				sstop = (obj.FICHATOP + 48) & "px"

			Case Is = "f"

				sLeft = (obj.FICHALEFT) & "px"
				sstop = (obj.FICHATOP + 48) & "px"

			Case Is = "x"

				sLeft = (obj.FICHALEFT - 35) & "px"
				sstop = (obj.FICHATOP) & "px"
			Case Is = "c"

				sLeft = (obj.FICHALEFT - 35) & "px"
				sstop = (obj.FICHATOP) & "px"
			Case Is = "d"

				sLeft = (obj.FICHALEFT - 35) & "px"
				sstop = (obj.FICHATOP) & "px"

			Case Is = "a"

				sLeft = (obj.FICHALEFT - 35) & "px"
				sstop = (obj.FICHATOP) & "px"


			Case Is = "n"

				sLeft = (obj.FICHALEFT) & "px"
				sstop = (obj.FICHATOP + 48) & "px"



			Case Is = "i"

				sLeft = (obj.FICHALEFT - 35) & "px"
				sstop = (obj.FICHATOP) & "px"


			Case Is = "k"

				sLeft = (obj.FICHALEFT - 35) & "px"
				sstop = (obj.FICHATOP) & "px"

			Case Is = "q"


				sLeft = (obj.FICHALEFT - 35) & "px"
				sstop = (obj.FICHATOP) & "px"

			Case Is = "l"

				sLeft = (obj.FICHALEFT - 35) & "px"
				sstop = (obj.FICHATOP) & "px"

			Case Is = "w"

				sLeft = (obj.FICHALEFT - 35) & "px"
				sstop = (obj.FICHATOP) & "px"


			Case Is = "z"

				sLeft = (obj.FICHALEFT) & "px"
				sstop = (obj.FICHATOP + 48) & "px"
			Case Is = "t"

				sLeft = (obj.FICHALEFT - 35) & "px"
				sstop = (obj.FICHATOP) & "px"


			Case Is = "b"

				sLeft = (obj.FICHALEFT) & "px"
				sstop = (obj.FICHATOP + 48) & "px"


		End Select

		Return imageCHIP

	End Function
	Sub chipBoard(ByVal numberChip As Integer, ByVal obj As ChipPull, ByVal sColor As String, bAlarm As Boolean, sMsgAlarm As String, ByVal bAlarmF As Boolean)


		Dim sDiv, sWidth, sHeight, sImageChip, stext, sTecnico, sLeft, ssHeight As String
		Dim bTecnico As Boolean
		sDiv = "ds" & String.Format("{0:000}", numberChip)


		sImageChip = imageCHIP(Left(obj.IDFICHA, 1), obj, stext, sTecnico, sLeft, ssHeight, bTecnico)

		sWidth = "46px"
		sHeight = "46px"

		displayChip(numberChip, obj.IDFICHA, obj.FICHALEFT & "px", obj.FICHATOP & "px", sWidth, sHeight, sImageChip, sColor, stext, sTecnico, sLeft, ssHeight, bTecnico, obj, bAlarm, sMsgAlarm, bAlarmF)




	End Sub
	Sub displayChip(ByVal iItem As Integer, ByVal sDiv As String, ByVal sL As String, ByVal sT As String, ByVal sWidth As String, ByVal sHeight As String, ByVal sImageChip As String, ByVal sColor As String, ByVal stext As String, ByVal sTecnico As String, ByVal sleftTexto As String, ByVal stopTexto As String, ByVal btecnico As Boolean, ByVal objChip As ChipPull, ByVal bAlarm As Boolean, sMsgAlarm As String, bAlarmF As Boolean)


		Dim iDiv As Integer
		Dim lbl1 As String, sComentarios As String

		Select Case Left(sDiv, 1)

			Case "h"
				sComentarios = "Vehiculo: " & objChip.VEHICULO & vbCrLf & " Placas: " & objChip.NOPLACAS & vbCrLf & "   Cliente: " & objChip.CLIENTE

			Case "r"
				sComentarios = "Vehiculo: " & objChip.VEHICULO & vbCrLf & " Placas: " & objChip.NOPLACAS & vbCrLf & "Cliente: " & objChip.CLIENTE
			Case Else
				If Not objChip.CHIPOP Is Nothing Then
					sComentarios = "Orden: " & objChip.NOORDEN & vbCrLf & " Placas:" & objChip.NOPLACAS & vbCrLf & "    Vehiculo: " & objChip.VEHICULO & vbCrLf & "   Servicio: " & objChip.CHIPOP.SERVICIOCAPTURADO & vbCrLf & "    Duracion: " & objChip.CHIPOP.SERVICIO & "      minutos" & vbCrLf & "  Tecnico: " & sTecnico & " N° Econimico: " & objChip.COLORPRISMA & " Cliente: " & objChip.CLIENTE & "     Observaciones: " & objChip.OBSERVACIONES & "" & vbCrLf & ""

				Else
					sComentarios = "Orden: " & objChip.NOORDEN & vbCrLf & " Placas:" & objChip.NOPLACAS & vbCrLf & "    Vehiculo: " & objChip.VEHICULO & vbCrLf & "   " & vbCrLf & "   Observaciones: " & objChip.OBSERVACIONES & "" & vbCrLf & ""

				End If

		End Select

		iDiv = Val(Right(sDiv, 3))
		lbl1 = "lb" & Right(sDiv, 3) & "1"

		Dim ixImg As New HtmlImage
		ixImg.ID = sDiv
		ixImg.Attributes.Add("class", "imagencarro")
		ixImg.Src = sImageChip
		ixImg.Style.Add("position", "absolute")
		ixImg.Style.Add("border", "solid 2px " & sColor)
		ixImg.Style.Add("Left", sL)
		ixImg.Style.Add("top", sT)
		ixImg.Style.Add("cursor", "hand")
		ixImg.Attributes.Add("ondblclick", "Location('" & ixImg.ID & "')")

		Dim IXdIVaLPHA As New HtmlGenericControl
		IXdIVaLPHA.ID = sDiv & "alpha"
		IXdIVaLPHA.Style.Add("position", "absolute")
		IXdIVaLPHA.Style.Add("background-color", sColor)
		IXdIVaLPHA.Style.Add("Left", sL)
		IXdIVaLPHA.Style.Add("top", sT)
		If InStr(sImageChip.ToUpper, "H") Then

			IXdIVaLPHA.Attributes.Add("class", "OpcH")
		Else

			IXdIVaLPHA.Attributes.Add("class", "OpcV")
		End If

		IXdIVaLPHA.Style.Add("cursor", "hand")
		IXdIVaLPHA.Attributes.Add("ondblclick", "Location('" & ixImg.ID & "')")


		Dim ixdivTec As New HtmlGenericControl("div")
		ixdivTec.ID = "ctlTec_" & sDiv
		Dim ixdivBahia As New HtmlGenericControl("div")
		ixdivBahia.ID = "ctlTecBahia_" & sDiv

		Dim ixdiv As New HtmlGenericControl("div")
		ixdiv.ID = "ctl_" & sDiv

		ixdiv.Style.Add("Left", Val(sL) + System.Web.Configuration.WebConfigurationManager.AppSettings.Item("imgleft").ToString & "px")
		ixdiv.Style.Add("top", Val(sT) + System.Web.Configuration.WebConfigurationManager.AppSettings.Item("imgtop").ToString & "px")


		ixdiv.Style.Add("position", "absolute")
		ixdiv.Style.Add("clear", "none")
		ixdiv.Style.Add("z-index", "6500")
		ixdiv.Attributes.Add("class", "textdiv")
		ixdiv.InnerText = stext
		Try
			If stext.Trim.Length > 4 Then ixdiv.InnerText = Left(stext, 3) & " " & Right(stext, Len(stext) - 3)

		Catch ex As Exception
		End Try


		Try
			'--===============================================================================
			'Desde acá Yeison programo alerta para chips iniciados y no finalizados en el pull

			Dim tiempoT As TimeSpan = Date.Now.TimeOfDay - objChip.CHIPOP.FECHAHORAINIOPER.TimeOfDay
			Dim tiempoH = CInt(tiempoT.Hours) * 60
			Dim tiempoM = CInt(tiempoT.Minutes)

			Dim tiempoTrancu As DateTime = objChip.CHIPOP.FECHAHORAINIOPER.AddMinutes(tiempoH + tiempoM)
			Dim tiempoIDeal As DateTime = objChip.CHIPOP.FECHAHORAINIOPER.AddMinutes(objChip.CHIPOP.SERVICIO)
			If tiempoTrancu >= tiempoIDeal Then
				Dim ixdivAlertF As New HtmlImage
				ixdivAlertF.ID = sDiv & "Alert"
				ixdivAlertF.Src = "~/img/blink.gif"
				ixdivAlertF.Style.Add("Left", "0")
				ixdivAlertF.Style.Add("top", "0")
				ixdivAlertF.Style.Add("cursor", "hand")
				ixdivAlertF.Style.Add("position", "absolute")
				ixdivAlertF.Style.Add("width", "100%")
				ixdivAlertF.Style.Add("height", "100%")
				ixdiv.Style.Add("z-index", "1501")
				ixdiv.Controls.Add(ixdivAlertF)
			End If
			'--===============================================================================
		Catch ex As Exception

		End Try

		ixImg.Attributes.Add("title", sComentarios)
		IXdIVaLPHA.Attributes.Add("title", sComentarios)


		ixdivTec.Style.Add("Left", (Val(sL) + 50) & "px")
		ixdivTec.Style.Add("top", (Val(stopTexto) - 30) & "px")
		ixdivTec.Style.Add("width", "45px")
		ixdivTec.Style.Add("position", "absolute")
		ixdivTec.Style.Add("border-bottom-style", "solid")
		ixdivTec.Style.Add("border-bottom-color", "#000333")
		ixdivTec.Style.Add("border-bottom-width", "0px")
		ixdivTec.Style.Add("clear", "none")
		ixdivTec.Style.Add("z-index", "1500")
		ixdivTec.Style.Add("font-size", "9px")
		ixdivTec.Style.Add("font-weight", "bold")
		ixdivTec.Style.Add("text-align", "center")
		ixdivTec.Style.Add("background-position", "left top")
		ixdivTec.Style.Add("background-color", "white")
		ixdivTec.Style.Add("filter", "alpha(opacity=80)")
		'ixdivTec.InnerText = sTecnico

		ixdivBahia.Style.Add("Left", (Val(sL) + 35) & "px")
		ixdivBahia.Style.Add("top", (Val(stopTexto)) & "px")
		ixdivBahia.Style.Add("width", "20px")
		ixdivBahia.Style.Add("height", "16px")
		ixdivBahia.Style.Add("position", "absolute")
		ixdivBahia.Style.Add("border-bottom-style", "solid")
		ixdivBahia.Style.Add("border-bottom-color", "#000333")
		ixdivBahia.Style.Add("border-bottom-width", "0px")
		ixdivBahia.Style.Add("clear", "none")
		ixdivBahia.Style.Add("z-index", "1500")
		ixdivBahia.Style.Add("font-size", "14px")
		ixdivBahia.Style.Add("font-weight", "bold")
		ixdivBahia.Style.Add("text-align", "center")
		ixdivBahia.Style.Add("background-position", "left top")
		'ixdivBahia.InnerText = String.Format("{0:0}", Val(Replace(sDiv, "b", "")))
		'ixdivBahia.Style.Add("Visible", "false")


		Me.divimg.Controls.Add(ixImg)

		Me.divimg.Controls.Add(IXdIVaLPHA)
		Me.divimg.Controls.Add(ixdiv)
		If btecnico Then            '
			Me.divimg.Controls.Add(ixdivTec)
			Me.divimg.Controls.Add(ixdivBahia)
		End If

		'Me.form1.Controls.Add(ixImg)

		'Me.form1.Controls.Add(IXdIVaLPHA)
		'Me.form1.Controls.Add(ixdiv)
		'If btecnico Then            '
		'	Me.form1.Controls.Add(ixdivTec)
		'	Me.form1.Controls.Add(ixdivBahia)
		'End If



	End Sub

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		objectsAttribute()

	End Sub
	Private Sub AbrirChip(ByVal iId As String)
		Dim OBJCOL As New CHIPPullCollection
		OBJCOL = Session("ColPullChips")

		dchp.Style.Remove("Left")
		dchp.Style.Remove("Top")
		For Each obj As ChipPull In OBJCOL
			If obj.IDFICHA = iId Then

				Modelo.Text = "Mod: " & obj.VEHICULO
				Tolerancia.Text = "Cita: " & obj.NUMCITA
				Service.Text = "" & obj.SERVICIOCAPTURADO
				Orden.Text = "Orden " & obj.NOORDEN
				Placas.Text = "Placa: " & obj.NOPLACAS
				dchp.Style.Add("Left", obj.FICHALEFT & "px")
				dchp.Style.Add("Top", obj.FICHATOP & "px")

				dchp.Focus()
				Exit For
			End If

		Next

	End Sub


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		LlenaAsesores()
		'llenaRuta()
		PINTACHIPS()
		llenaContador()

		MOSTRARRESUMEN()

		Dim sdhtml As String = ""
		Try
			sdhtml = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
		Catch ex As Exception

		End Try


		If sdhtml.Length = 3 Then
			dchp.Visible = True
			AbrirChip(sdhtml)

		Else
			dchp.Visible = False
		End If
	End Sub

	Sub MOSTRARRESUMEN()


		Dim dt As DataTable
		Dim sqry As String
		Dim bd As New BDClass

		Dim OBJCOL As New CHIPPullCollection
		Dim y
		OBJCOL = Session("ColPullChips")

		Dim inoshow As Integer = 0, ienespera As Integer = 0, ienrampa As Integer = 0

		sqry = "select count(id_hd) as cuenta "
		sqry += " from TB_CITAS_HEADER_nw "
		sqry += " where  convert(varchar,fecha,12)=convert(varchar,getdate(),12) and numcita<>'0' "
		sqry += " and  convert(datetime, horaasesor)<dateadd(minute,-5, convert(datetime,convert(varchar,getdate(),108) )) and horallegada is null"


		dt = BDClass.SQLtoDataTable(sqry, False)
		inoshow = dt.Rows(0).Item(0)




		ienrampa = (From p In OBJCOL Where p.status = "EnBahia").Count



		ienespera = (From p In OBJCOL Where p.status = "Recepcion").Count

		Dim SCONTROL As String
		SCONTROL = "<div  class='textResumen'>"
		SCONTROL += "<table style='border:solid thin silver;background-color:transparent;font-size:10px;font-family:arial;'>"

		SCONTROL += "<tr>"
		SCONTROL += "<td  align='center'>SIN RECEPCION</td><td  align='center'>NO SHOW</td><td  align='center'>EN SERVICIO</td> "
		SCONTROL += ""
		SCONTROL += "</tr>"
		SCONTROL += "<tr>"
		SCONTROL += "<td  align='left'>" & ienespera & "</td><td  align='left'>" & inoshow & "</td><td  align='left'>" & ienrampa & "</td> "
		SCONTROL += ""
		SCONTROL += "</tr>"




		If OBJCOL.Count > 0 Then
			SCONTROL += "<tr>"

			SCONTROL += "<td colspan=2 >BUSCAR PLACAS:</td><td><select id='selOptChips' onchange='buscaChp(this.value);'> "
			SCONTROL += "<option value=''>--</option>"
			y = From p As ChipPull In OBJCOL Select p Order By p.NOPLACAS Ascending
			For Each obj As ChipPull In y
				SCONTROL += "<option value='" & obj.IDFICHA & "'>" & obj.NOPLACAS & "</option>"
			Next


			SCONTROL += "</select>"
			'SCONTROL=+= " <input type=button id='cmdinptBuscar'  name='cmdinptBuscar' onclick=buscaChp(getElementById('selOptChips').value);>"
			SCONTROL += "</td>"

			SCONTROL += "</tr><tr>"
			SCONTROL += "<td colspan=2 >BUSCAR ORDEN:</td><td><input type='text' id='inOptChips'  style='width:70px;'/><input type='button' style='width:30px;' onclick='buscaChpOrd();' id='btninOptChips'/> "
			SCONTROL += "<select id='selOptChipsHdd' style='display:none;'> "
			SCONTROL += "<option value=''>--</option>"

			For Each obj As ChipPull In OBJCOL
				SCONTROL += "<option value='" & obj.IDFICHA & "'>" & obj.NOORDEN & "</option>"

			Next

			SCONTROL += "</select>"
			'SCONTROL=+= " <input type=button id='cmdinptBuscar'  name='cmdinptBuscar' onclick=buscaChp(getElementById('selOptChips').value);>"
			SCONTROL += "</td>"

			SCONTROL += "</tr>"
		End If


		SCONTROL += "</table></div>"
		Dim obj1 As HtmlGenericControl = New HtmlGenericControl("div")
		obj1.InnerHtml = SCONTROL
		form1.Controls.Add(obj1)

	End Sub

	Sub objectsAttribute()
		dchp.Attributes.Add("onclick", "Location('dchp')")
	End Sub


	Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
		TablerosUtilsHyP.Salir()
		Response.Redirect("Inicio.aspx")
	End Sub

	Sub LlenaAsesores()
		Dim dt As New DataTable
		Dim sqry As String = ""


		sqry = "Select nombre,color from SccUsuarios  WHERE cveasesor<>'' and not cveAsesor is null "
		dt = BDClass.SQLtoDataTable(sqry, False)



	End Sub


	'--================================================================
	'Yeison cambio de paginas
	Protected Sub llenaRuta()
		Dim dt As DataTable = New DataTable
		Dim s As String
		s = "SELECT [pasaracitas] FROM [TB_PANTALLAS_BIENVENIDA] where idPantalla like '%pull%'"
		dt = BDClass.SQLtoDataTable(s, False)
		If dt.Rows.Count > 0 Then
			s = dt.Rows(0).Item("pasaracitas")
		Else
			s = "Pull_system.aspx"
		End If
		'Me.hiddenURLSiguiente.Value = s
		'muestraMensaje2("todo ok")
	End Sub

	Protected Sub muestraMensaje2(ByVal m As String)
		Response.Write("<script>window.alert('" & m & "');</script>")
	End Sub

	'--cambia el carrito que se muestra
	Private Function buscarurlImagen(ByVal num As Integer) As String
		Dim tipo As String
		Dim sql As String = "SELECT CONTACTOTELEFONO FROM TB_CITAS_HEADER_NW WHERE ID_HD = '" & num & "'"
		Dim url As String
		url = ""
		Dim DT As DataTable
		DT = BDClass.SQLtoDataTable(sql, False)

		If DT.Rows.Count > 0 Then
			tipo = DT.Rows(0).Item(0)
		Else
			tipo = "nada"
		End If

		Select Case tipo
			Case "BUS"
				url = "IMG/CAMBUS.GIF"
			Case "SPRINTER"
				url = "IMG/CAMSPRINT.GIF"
			Case "Tracto"
				url = "IMG/CAMTRACK.GIF"
		End Select

		Return url

	End Function




	'--=================================================================
End Class


