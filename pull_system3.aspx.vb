Imports TablerosV2LibTypes
Partial Public Class pull_system3
    Inherits System.Web.UI.Page
    Sub PINTACHIPS(iiNivel As Integer)
        Dim objc As New ArrayList()
        For Each d In Me.form1.Controls
            If Left(d.id, 4) = "ctl_" Or Left(d.id, 6) = "ctlTec" Then
                objc.Add(d.id)
            End If
        Next
        For Each d In objc
            If Left(d, 4) = "ctl_" Or Left(d, 6) = "ctlTec" Then
                Me.form1.Controls.Remove(Me.form1.FindControl(d))
            End If
        Next
        Dim OBJCOL As New CHIPPullCollection, objchip As ChipPull
        Dim sColor As String, oChip As String, iNivel As Integer = 0
        Dim imgLst As New ArrayList()

        OBJCOL = OBJCOL.ObtenChips(iiNivel)
        Session("ColChips") = OBJCOL
        For i = 1 To OBJCOL.Count
            objchip = OBJCOL.Item(i - 1)
            'sColor = TablerosUtilsHyP.ObtenColorAsesor(iNivel)
            oChip = Left(objchip.OCHIP, 2)


            imgLst.Add("ds" & String.Format("{0:000}", i))

            chipBoard(i, objchip, sColor)
        Next
        Session("imgLst") = imgLst
    End Sub

    Function imageCHIP(ByVal sChip As String, ByVal obj As ChipPull, ByRef stext As String, ByRef sTecnico As String, ByRef sLeft As String, ByRef sstop As String, ByRef btecnico As Boolean) As String
        btecnico = False
        stext = obj.NOPLACAS
        sTecnico = ""

        If obj.NUMCITA <> 0 Then
            imageCHIP = obj.IMGCC
        Else
            imageCHIP = obj.IMGSC
        End If

        If Not obj.CHIPOP Is Nothing Then
            If obj.ESBAHIA And Not obj.CHIPOP.IDTECNICO Is Nothing Then
                sTecnico = TablerosUtilsHyP.ObtenNombreTecnicos(obj.CHIPOP.IDTECNICO)
                btecnico = obj.ESBAHIA
            End If

        End If



        Select Case sChip
            Case Is = "h"
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"


            Case Is = "r"
                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"

            Case Is = "g"
                ' stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"


            Case Is = "f"
                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"


            Case Is = "x"
                'stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"


            Case Is = "k"
                ' stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"


            Case Is = "q"

                ' stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"


            Case Is = "l"
                ' stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"
            Case Is = "a"

                sLeft = (obj.FICHALEFT - 35) & "px"
                sstop = (obj.FICHATOP) & "px"

            Case Is = "w"
                ' stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"


            Case Is = "z"
                ' stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"


            Case Is = "t"
                'stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"



            Case Is = "b"
                ' stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"

                'sTecnico = TablerosUtilsHyP.ObtenNombreTecnicos(obj.IDTECNICO)
                'btecnico = True


        End Select
        If InStr(imageCHIP, "h_l.") > 0 Then
            sLeft = (obj.FICHALEFT + 48) & "px"
            sstop = (obj.FICHATOP + 7) & "px"

        Else
            sLeft = (obj.FICHALEFT + 7) & "px"
            sstop = (obj.FICHATOP + 50) & "px"
        End If

        Return imageCHIP

    End Function
    Sub chipBoard(ByVal numberChip As Integer, ByVal obj As ChipPull, ByVal sColor As String)


        Dim sDiv, sWidth, sHeight, sImageChip, stext, sTecnico, sLeft, ssHeight As String
        Dim bTecnico As Boolean
        sDiv = "ds" & String.Format("{0:000}", numberChip)


        sImageChip = imageCHIP(Left(obj.IDFICHA, 1), obj, stext, sTecnico, sLeft, ssHeight, bTecnico)

        sWidth = "46px"
        sHeight = "46px"

        displayChip(numberChip, obj.IDFICHA, obj.FICHALEFT & "px", obj.FICHATOP & "px", sWidth, sHeight, sImageChip, sColor, stext, sTecnico, sLeft, ssHeight, bTecnico, obj)




    End Sub
    Sub displayChip(ByVal iItem As Integer, ByVal sDiv As String, ByVal sL As String, ByVal sT As String, ByVal sWidth As String, ByVal sHeight As String, ByVal sImageChip As String, ByVal sColor As String, ByVal stext As String, ByVal sTecnico As String, ByVal sleftTexto As String, ByVal stopTexto As String, ByVal btecnico As Boolean, ByVal objChip As ChipPull)


        Dim iDiv As Integer
        Dim lbl1 As String, sTool As String = ""

        iDiv = Val(Right(sDiv, 3))
        lbl1 = "lb" & Right(sDiv, 3) & "1"

        Dim ixImg As New HtmlImage
        ixImg.ID = sDiv
        If InStr(sImageChip, "h_l.") > 0 Then
            ixImg.Attributes.Add("class", "imgdivH")

        Else
            ixImg.Attributes.Add("class", "imgdivV")
        End If
        ixImg.Src = sImageChip
        ixImg.Style.Add("position", "absolute")
        ixImg.Style.Add("border", "solid 3px " & sColor)
        ixImg.Style.Add("Left", sL)
        ixImg.Style.Add("top", sT)
        ixImg.Style.Add("cursor", "hand")
        ixImg.Attributes.Add("ondblclick", "Location('" & ixImg.ID & "')")



        Dim ixdivTec As New HtmlGenericControl("div")
        ixdivTec.ID = "ctlTec_" & sDiv
        Dim ixdivBahia As New HtmlGenericControl("div")
        ixdivBahia.ID = "ctlTecBahia_" & sDiv

        Dim ixdiv As New HtmlGenericControl("div")
        ixdiv.ID = "ctl_" & sDiv


        ixdiv.Style.Add("Left", sleftTexto)
        ixdiv.Style.Add("top", stopTexto)
        'ixdiv.Style.Add("width", "35px")
        'ixdiv.Style.Add("height", "30px")
        ixdiv.Style.Add("position", "absolute")
        ixdiv.Style.Add("border-top-style", "solid")
        ixdiv.Style.Add("border-top-color", sColor)
        ixdiv.Style.Add("border-bottom-color", sColor)
        ixdiv.Style.Add("clear", "none")
        ixdiv.Style.Add("z-index", "1500")
        'ixdiv.Style.Add("text-shadow", "0px 3px 8px #2a2a2a")
        'ixdiv.Style.Add("font-size", "14px")
        'ixdiv.Style.Add("text-align", "center")
        ' ixdiv.Style.Add("background-position", "left top")
        'ixdiv.Style.Add("background-color", "gainsboro")
        ixdiv.InnerText = stext
        If stext.Trim.Length >= 5 Then ixdiv.InnerText = Left(stext, Fix(stext.Length / 2)) & " " & Right(stext, System.Math.Round(stext.Length / 2))

        ixdiv.Attributes.Add("class", "textdiv")
        sTool += "Orden: " & objChip.NOORDEN & vbCrLf
        sTool += "      Placa: " & objChip.NOPLACAS & vbCrLf
        sTool += "      Cliente: " & objChip.CLIENTE & vbCrLf
        sTool += "      Vehiculo: " & objChip.VEHICULO & vbCrLf
        sTool += "      Servicio: " & objChip.SERVICIOCAPTURADO & vbCrLf
        ixdiv.Attributes.Add("title", sTool)


        'objChip.NOPLACAS = IIf(dt(i)("Placa") Is DBNull.Value, "", dt(i)("Placa"))
        'objChip.CONCITA = IIf(dt(i)("concita") Is DBNull.Value, False, dt(i)("concita"))
        'objChip.CLIENTE = IIf(dt(i)("Cliente") Is DBNull.Value, "", dt(i)("Cliente"))
        'objChip.IDASESOR = IIf(dt(i)("IDASESOR") Is DBNull.Value, "", dt(i)("IDASESOR"))
        'objChip.NUMCITA = IIf(dt(i)("NUMCITA") Is DBNull.Value, 0, dt(i)("NUMCITA"))
        'objChip.VEHICULO = IIf(dt(i)("VEHICULO") Is DBNull.Value, "", dt(i)("VEHICULO"))
        'objChip.COLOR = IIf(dt(i)("color") Is DBNull.Value, "", dt(i)("color"))

        ixdivTec.Style.Add("Left", (Val(sL) - 5) & "px")
        ixdivTec.Style.Add("top", (Val(stopTexto) + 32) & "px")
        ixdivTec.Style.Add("width", "45px")
        'ixdivTec.Style.Add("height", "23px")
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
        ixdivTec.InnerText = sTecnico

        'ixdivBahia.Style.Add("Left", (Val(sL) + 35) & "px")
        'ixdivBahia.Style.Add("top", (Val(stopTexto) - 30) & "px")
        'ixdivBahia.Style.Add("width", "20px")
        'ixdivBahia.Style.Add("height", "16px")
        'ixdivBahia.Style.Add("position", "absolute")
        'ixdivBahia.Style.Add("border-bottom-style", "solid")
        'ixdivBahia.Style.Add("border-bottom-color", "#000333")
        'ixdivBahia.Style.Add("border-bottom-width", "0px")
        'ixdivBahia.Style.Add("clear", "none")
        'ixdivBahia.Style.Add("z-index", "1500")
        'ixdivBahia.Style.Add("font-size", "14px")
        'ixdivBahia.Style.Add("font-weight", "bold")
        'ixdivBahia.Style.Add("text-align", "center")
        'ixdivBahia.Style.Add("background-position", "left top")
        'ixdivBahia.InnerText = String.Format("{0:0}", Val(Replace(sDiv, "b", "")))



        MultiView1.Views(MultiView1.ActiveViewIndex).Controls.Add(ixImg)
        MultiView1.Views(MultiView1.ActiveViewIndex).Controls.Add(ixdiv)
        If btecnico Then
            MultiView1.Views(MultiView1.ActiveViewIndex).Controls.Add(ixdivTec)
            '  MultiView1.Views(MultiView1.ActiveViewIndex).Controls.Add(ixdivBahia)
        End If



    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        objectsAttribute()

    End Sub
    Private Sub AbrirChip(ByVal iId As String)
        Dim OBJCOL As New CHIPPullCollection
        OBJCOL = Session("ColChips")

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
        nBody.Style.Remove("background-image")
        nBody.Style.Remove("background-repeat")
        'Select Case MultiView1.ActiveViewIndex
        '    Case 0
        '        nBody.Style.Add("background-image", "url(img/PullSystemToyota/View1.png)")
        '        nBody.Style.Add("background-repeat", "no-repeat")
        '    Case 1
        '        nBody.Style.Add("background-image", "url(img/PullSystemToyota/View2.png)")
        '        nBody.Style.Add("background-repeat", "no-repeat")
        '    Case 2
        '        nBody.Style.Add("background-image", "url(img/PullSystemToyota/View3.png)")
        '        nBody.Style.Add("background-repeat", "no-repeat")
        'End Select
        nBody.Style.Add("background-image", "url(img/PullSystemToyota/View1.png)")
        nBody.Style.Add("background-repeat", "no-repeat")
        MultiView1.ActiveViewIndex = 0

        PINTACHIPS(MultiView1.ActiveViewIndex)

        'Try
        '    'MOSTRARRESUMEN()
        'Catch ex As Exception

        'End Try


        Try
            Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value

            If sdhtml.Length = 3 Then
                dchp.Visible = True
                AbrirChip(sdhtml)

            Else
                dchp.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub MOSTRARRESUMEN()


        Dim dt As DataTable
        Dim sqry As String
        Dim bd As New BDClass


        Dim inoshow As Integer = 0, ienespera As Integer = 0, ienrampa As Integer = 0

        sqry = "Select count(noplacas) as cuenta from TYT_LV_TBL_CONTROL_CITAS_noshow where servicioCapturado <> 'lavado' and Year(fecha) =year(getdate()) And Month(fecha) =Month(getdate()) And Day(fecha) =day(getdate())"
        dt = BDClass.SQLtoDataTable(sqry, False)
        inoshow = dt.Rows(0).Item(0)





        sqry = "select distinct NoOrden" _
                                          & " from TYT_LV_TBL_CONTROL_CITAS " _
                                          & " " _
                                          & " where Year(Fecha_Hora_ini_Oper) =year(getdate()) And Month(Fecha_Hora_ini_Oper) =Month(getdate()) And Day(Fecha_Hora_ini_Oper) =day(getdate()) " _
                                          & " and (Status ='Iniciada' or Status ='Reiniciada')  and Status_OS ='EN PROCESO' " _
                                          & "   and servicioCapturado <> 'Lavado'    and Fecha_Hora_Fin_Oper is null "
        'System.IO.File.AppendAllText("C:\Capital\pullsysv11_Daniel\pullsysv11\Logs\SQL2_SQLtoDatatable.txt", vbCrLf & sqry & vbCrLf & vbCrLf)

        dt = BDClass.SQLtoDataTable(sqry, False)
        ienrampa = dt.Rows.Count



        sqry = " select distinct noPlacas Placa, 0 as conCita, 0 as noOrden, Cliente from dbo.TYT_LV_TBL_CONTROL_CITAS_HEADER_RECEPCION" _
   & "    where  Year(fecha) = year(getdate())  And Month(fecha) =  Month(getdate()) And Day(fecha) =  day(getdate())  and (horaIRecepcion is null) and (not horaLlegada is null) and ( horaretiro is null) "


        dt = BDClass.SQLtoDataTable(sqry, False)
        ienespera = dt.Rows.Count

        Dim SCONTROL As String
        SCONTROL = "<div class='textResumen'>"
        SCONTROL += "<table style='border:solid thin silver;background-color:transparent;font-size:10px;font-family:arial;'  cellspacing='1'>"

        SCONTROL += "<tr>"
        SCONTROL += "<td  align='left'>SIN RECEPCION</td><td  align='left'>NO SHOW</td><td  align='left'>EN SERVICIO</td> "
        SCONTROL += "</td>"
        SCONTROL += "</tr>"
        SCONTROL += "<tr>"
        SCONTROL += "<td  align='center'>" & ienespera & "</td><td  align='center'>" & inoshow & "</td><td  align='center'>" & ienrampa & "</td> "
        SCONTROL += "</td>"
        SCONTROL += "</tr>"
        Dim OBJCOL As New CHIPPullCollection
        OBJCOL = Session("ColChips")



        'If OBJCOL.Count > 0 Then
        '    SCONTROL += "<tr>"

        '    SCONTROL += "<td colspan=2 >BUSCAR PLACAS:</td><td><select id='selOptChips' onchange='buscaChp(this.value);'> "
        '    SCONTROL += "<option value=''>--</option>"

        '    For Each obj As ChipPull In OBJCOL
        '        SCONTROL += "<option value='" & obj.IDFICHA & "'>" & obj.NOPLACAS & "</option>"
        '    Next


        '    SCONTROL += "</select>"
        '    'SCONTROL=+= " <input type=button id='cmdinptBuscar'  name='cmdinptBuscar' onclick=buscaChp(getElementById('selOptChips').value);>"
        '    SCONTROL += "</td>"

        '    SCONTROL += "</tr><tr>"
        '    SCONTROL += "<td colspan=2 >BUSCAR ORDEN:</td><td><input type='text' id='inOptChips'  style='width:120px;'/><input type='button' onclick='buscaChpOrd();' id='btninOptChips'/> "
        '    SCONTROL += "<select id='selOptChipsHdd' style='display:none;'> "
        '    SCONTROL += "<option value=''>--</option>"

        '    For Each obj As ChipPull In OBJCOL
        '        SCONTROL += "<option value='" & obj.IDFICHA & "'>" & obj.NOORDEN & "</option>"

        '    Next

        '    SCONTROL += "</select>"
        '    'SCONTROL=+= " <input type=button id='cmdinptBuscar'  name='cmdinptBuscar' onclick=buscaChp(getElementById('selOptChips').value);>"
        '    SCONTROL += "</td>"

        '    SCONTROL += "</tr>"
        'End If


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

    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        'Select Case MultiView1.ActiveViewIndex
        '    Case 0
        '        MultiView1.ActiveViewIndex = 1

        '    Case 1
        '        MultiView1.ActiveViewIndex = 2
        '    Case 2
        '        MultiView1.ActiveViewIndex = 0
        'End Select
        'nBody.Style.Remove("background-image")
        'Select Case MultiView1.ActiveViewIndex
        '    Case 0
        '        nBody.Style.Add("background-image", "url(img/PullSystemToyota/View1.png)")
        '    Case 1
        '        nBody.Style.Add("background-image", "url(img/PullSystemToyota/View2.png)")
        '    Case 2
        '        nBody.Style.Add("background-image", "url(img/PullSystemToyota/View3.png)")
        'End Select

        'PINTACHIPS(MultiView1.ActiveViewIndex)
        Response.Redirect("pull_system3b.aspx")
    End Sub

    Private Sub MultiView1_ActiveViewChanged(sender As Object, e As System.EventArgs) Handles MultiView1.ActiveViewChanged

    End Sub
End Class
