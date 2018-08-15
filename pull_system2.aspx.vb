Imports TablerosV2LibTypes
Partial Public Class pull_system2
    Inherits System.Web.UI.Page
    Sub PINTACHIPS()
        Dim OBJCOL As New CHIPPullCollection, objchip As ChipPull
        Dim sColor As String, oChip As String, iNivel As Integer = 0
        Dim imgLst As New ArrayList(), fEntregaFinal As Date, bAlarm As Boolean = False, sMsgAlarm As String = ""
        Dim c As System.IO.TextWriter, b() As Byte
        Try
            OBJCOL = OBJCOL.ObtenChipsAll2()

        Catch ex As Exception

        End Try


        'objchip.sstock = (From p As ChipPull In OBJCOL Where p.IDFICHA.StartsWith(Left(objchip.IDFICHA, 1))).Count


        Session("ColChips") = OBJCOL
        For i = 1 To OBJCOL.Count
            objchip = OBJCOL.Item(i - 1)
            objchip.sstock = (From p As ChipPull In OBJCOL Where p.IDFICHA.StartsWith(Left(objchip.IDFICHA, 1))).Count

            sColor = TablerosUtilsHyP.ObtenColorAsesor(objchip.IDASESOR)
            oChip = Left(objchip.OCHIP, 2)
            '  fEntregaFinal = UTableroHyP.ObtenFechaFinal(objchip.NOORDEN)

            imgLst.Add("ds" & String.Format("{0:000}", i))

            If CDate(objchip.FECHA.ToShortDateString & " " & objchip.HORACITA) <= Date.Now And objchip.STATUS.ToLower = "pendiente" Then
                bAlarm = True
                sMsgAlarm = "Retrasado para iniciar"
            Else
                bAlarm = False
            End If
            chipBoard(i, objchip, sColor, fEntregaFinal, bAlarm, sMsgAlarm)
        Next
        Session("imgLst") = imgLst
    End Sub

    Function imageCHIP(ByVal sChip As String, ByVal obj As ChipPull, ByRef stext As String, ByRef sTecnico As String, ByRef sLeft As String, ByRef sstop As String, ByRef btecnico As Boolean) As String
        btecnico = False
        stext = obj.campomostrar
        sTecnico = ""

        If obj.CONCITA Then
            imageCHIP = obj.IMGCC
        Else
            imageCHIP = obj.IMGSC
        End If

        If InStr(imageCHIP, "_v_l") > 0 Then
            sLeft = (obj.FICHALEFT) & "px"
            sstop = (obj.FICHATOP + 48) & "px"
            ' imageCHIP = "img/" & obj.IDASESOR & "_v.gif"
        Else

            sLeft = (obj.FICHALEFT - 35) & "px"
            sstop = (obj.FICHATOP) & "px"
            '  imageCHIP = "img/" & obj.IDASESOR & "_h.gif"
        End If


        If obj.STATUS.Trim().ToLower = "iniciada" Or obj.STATUS.Trim().ToLower = "reiniciada" Then
            sTecnico = TablerosUtilsHyP.ObtenNombreTecnicos(obj.IDTECNICO)
            btecnico = True
        End If



        Return imageCHIP

    End Function
    Sub chipBoard(ByVal numberChip As Integer, ByVal obj As ChipPull, ByVal sColor As String, ByVal fFechaFinal As Date, ByVal bAlarm As Boolean, sMsgAlarm As String)


        Dim sDiv, sWidth, sHeight, sImageChip, stext, sTecnico, sLeft, ssHeight As String
        Dim bTecnico As Boolean
        sDiv = "ds" & String.Format("{0:000}", numberChip)


        sImageChip = imageCHIP(Left(obj.IDFICHA, 1), obj, stext, sTecnico, sLeft, ssHeight, bTecnico)

        sWidth = "46px"
        sHeight = "46px"

        displayChip(numberChip, obj.IDFICHA, obj.FICHALEFT & "px", obj.FICHATOP & "px", sWidth, sHeight, sImageChip, sColor, stext, sTecnico, sLeft, ssHeight, bTecnico, obj, fFechaFinal, bAlarm, sMsgAlarm)




    End Sub
    Sub LlenaAsesores()
        Dim dt As New DataTable
        Dim sqry As String = ""


        sqry = "Select nombre,color from SccUsuarios WITH (NOLOCK)  WHERE cveasesor<>'' and not cveAsesor is null "
        dt = BDClass.SQLtoDataTable(sqry, False)

        DataList1.DataSource = dt

        DataList1.DataBind()

    End Sub
    Sub LlenaEtapas()
        Dim dt As New DataTable
        Dim sqry As String = ""


        sqry = "Select fase as nombre,color from hypfases WITH (NOLOCK)  order by idfase asc "
        dt = BDClass.SQLtoDataTable(sqry, False)

        DataList2.DataSource = dt

        DataList2.DataBind()

    End Sub
    Sub displayChip(ByVal iItem As Integer, ByVal sDiv As String, ByVal sL As String, ByVal sT As String, ByVal sWidth As String, ByVal sHeight As String, ByVal sImageChip As String, ByVal sColor As String, ByVal stext As String, ByVal sTecnico As String, ByVal sleftTexto As String, ByVal stopTexto As String, ByVal btecnico As Boolean, ByVal objChip As ChipPull, ByVal fFechaFinal As Date, ByVal bAlarm As Boolean, sMsgAlarm As String)

        CType(form1.FindControl("lblTot" & Left(objChip.IDFICHA, 1)), LinkButton).Text = CType(form1.FindControl("lblTot" & Left(objChip.IDFICHA, 1)), LinkButton).ToolTip & " " & objChip.sstock
        CType(form1.FindControl("lblTot" & Left(objChip.IDFICHA, 1)), LinkButton).Visible = True
        Dim iDiv As Integer
        Dim lbl1 As String, sComentarios As String

        Select Case Left(sDiv, 1)

            Case "h"
                sComentarios = "Vehiculo: " & objChip.VEHICULO & vbCrLf & " Placas: " & objChip.NOPLACAS & vbCrLf & "   Cliente: " & objChip.CLIENTE

            Case "r"
                sComentarios = "Vehiculo: " & objChip.VEHICULO & vbCrLf & " Placas: " & objChip.NOPLACAS & vbCrLf & "Cliente: " & objChip.CLIENTE
            Case Else
                If Not objChip.CHIPOP Is Nothing Then
                    sComentarios = "Orden: " & objChip.NOORDEN & vbCrLf & " Placas:" & objChip.NOPLACAS & vbCrLf & "    Vehiculo: " & objChip.VEHICULO & vbCrLf & "   Servicio: " & objChip.CHIPOP.SERVICIOCAPTURADO & vbCrLf & "    Duracion: " & objChip.CHIPOP.SERVICIO & "      minutos" & vbCrLf & "   Observaciones: " & objChip.OBSERVACIONES & "" & vbCrLf & ""

                Else
                    sComentarios = "Orden: " & objChip.NOORDEN & vbCrLf & " Placas:" & objChip.NOPLACAS & vbCrLf & "    Vehiculo: " & objChip.VEHICULO & vbCrLf & "   " & vbCrLf & "   Observaciones: " & objChip.OBSERVACIONES & "" & vbCrLf & ""

                End If

        End Select

        iDiv = Val(Right(sDiv, 3))
        lbl1 = "lb" & Right(sDiv, 3) & "1"

        Dim ixImg As New HtmlImage
        ixImg.ID = sDiv
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

        'ixdiv.Style.Add("Left", sleftTexto)
        'ixdiv.Style.Add("top", stopTexto)
        'ixdiv.Style.Add("width", "33px")
        'ixdiv.Style.Add("height", "23px")
        ixdiv.Style.Add("position", "absolute")
        'ixdiv.Style.Add("border-top-style", "solid")
        'ixdiv.Style.Add("border-top-color", sColor)
        'ixdiv.Style.Add("border-bottom-color", sColor)
        ixdiv.Style.Add("clear", "none")
        ixdiv.Style.Add("z-index", "6500")
        'ixdiv.Style.Add("font-size", "8px")
        'ixdiv.Style.Add("text-align", "center")
        'ixdiv.Style.Add("background-position", "left top")
        'ixdiv.Style.Add("background-color", "gainsboro")
        ixdiv.Attributes.Add("class", "textdiv")
        ixdiv.InnerText = stext
        Try
            If stext.Trim.Length > 4 Then ixdiv.InnerText = Left(stext, 3) & " " & Right(stext, Len(stext) - 3)

        Catch ex As Exception
        End Try

        'ixdiv.Attributes.Add("data-tooltip", sComentarios)
        'ixdiv.Attributes.Add("onmouseover", "showTooltip(this)")
        'ixdiv.Attributes.Add("onmouseout", "hideTooltip(this)")
        Try
            If DateDiff(DateInterval.Day, objChip.CHIPOP.FECHAHORAPARO, Date.Now) >= 8 And objChip.STATUS = "DetenidoRefacciones" Then
                Dim ixdivAlert As New HtmlImage
                ixdivAlert.ID = sDiv & "Alert"
                ixdivAlert.Src = "img/blink.gif"
                ixdivAlert.Style.Add("Left", "0")
                ixdivAlert.Style.Add("top", "0")
                ixdivAlert.Style.Add("cursor", "hand")
                ixdivAlert.Style.Add("position", "absolute")
                ixdivAlert.Style.Add("width", "100%")
                ixdivAlert.Style.Add("height", "100%")
                ixdivAlert.Attributes.Add("class", "dAlarm")

                ixdiv.Controls.Add(ixdivAlert)
                sComentarios = sComentarios & vbCrLf & "   " & vbCrLf & sMsgAlarm

            End If

            If DateDiff(DateInterval.Day, objChip.CHIPOP.FECHAHORAPARO, Date.Now) > 0 And objChip.STATUS = "DetenidoCarryOver" Then
                Dim ixdivAlert2 As New HtmlImage
                ixdivAlert2.ID = sDiv & "Alert"
                ixdivAlert2.Src = "img/blink2.gif"
                ixdivAlert2.Style.Add("Left", "0")
                ixdivAlert2.Style.Add("top", "0")
                ixdivAlert2.Style.Add("cursor", "hand")
                ixdivAlert2.Style.Add("position", "absolute")
                ixdivAlert2.Style.Add("width", "100%")
                ixdivAlert2.Style.Add("height", "100%")
                ixdivAlert2.Attributes.Add("class", "dAlarm")

                ixdiv.Controls.Add(ixdivAlert2)
                sComentarios = sComentarios & vbCrLf & "   " & vbCrLf & sMsgAlarm

            End If

            If objChip.CHIPOP.CONTINUA = True And objChip.STATUS = "DetenidoRefacciones" Then
                Dim ixdivAlert1 As New HtmlImage
                ixdivAlert1.ID = sDiv & "Alert"
                ixdivAlert1.Src = "img/blink1.gif"
                ixdivAlert1.Style.Add("Left", "0")
                ixdivAlert1.Style.Add("top", "0")
                ixdivAlert1.Style.Add("cursor", "hand")
                ixdivAlert1.Style.Add("position", "absolute")
                ixdivAlert1.Style.Add("width", "100%")
                ixdivAlert1.Style.Add("height", "100%")
                ixdivAlert1.Attributes.Add("class", "dAlarm")

                ixdiv.Controls.Add(ixdivAlert1)
                sComentarios = sComentarios & vbCrLf & "   " & vbCrLf & sMsgAlarm

            End If

        Catch ex As Exception

        End Try

        ixImg.Attributes.Add("title", sComentarios)
        IXdIVaLPHA.Attributes.Add("title", sComentarios)


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
        ixdivBahia.InnerText = String.Format("{0:0}", Val(Replace(sDiv, "b", "")))
        'If objChip.QA Then
        '    Dim ixdivQA As New HtmlImage
        '    ixdivQA.ID = sDiv & "QA"
        '    ixdivQA.Src = "img/qa.gif"

        '    ixdivQA.Style.Add("cursor", "hand")
        '    ixdivQA.Style.Add("position", "absolute")

        '    ixdivQA.Attributes.Add("class", "dQA")

        '    ixdiv.Controls.Add(ixdivQA)

        'End If

        Me.form1.Controls.Add(ixImg)

        Me.form1.Controls.Add(IXdIVaLPHA)
        Me.form1.Controls.Add(ixdiv)
        If btecnico Then
            '
            Me.form1.Controls.Add(ixdivTec)
            Me.form1.Controls.Add(ixdivBahia)
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
    Protected Sub DataList1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataList1.PreRender
        For i = 0 To DataList1.Items.Count - 1
            Try
                CType(DataList1.Items(i).Controls(1), Label).Style.Value = "color:" & CType(DataList1.Items(i).Controls(1), Label).Text & ";background-color:" & CType(DataList1.Items(i).Controls(1), Label).Text & ";"

            Catch ex As Exception

            End Try
        Next
    End Sub
    Protected Sub DataList2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataList2.PreRender
        For i = 0 To DataList2.Items.Count - 1
            Try
                CType(DataList2.Items(i).Controls(1), Label).Style.Value = "color:" & CType(DataList2.Items(i).Controls(1), Label).Text & ";background-color:" & CType(DataList2.Items(i).Controls(1), Label).Text & ";"

            Catch ex As Exception

            End Try
        Next
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value

        LlenaEtapas()
        LlenaAsesores()

        PINTACHIPS()

        MOSTRARRESUMEN()


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

        Dim y
        Dim inoshow As Integer = 0, ienespera As Integer = 0, ienrampa As Integer = 0

        'sqry = "Select count(noplacas) as cuenta from TYT_LV_TBL_CONTROL_CITAS_noshow where servicioCapturado <> 'lavado' and Year(fecha) =year(getdate()) And Month(fecha) =Month(getdate()) And Day(fecha) =day(getdate())"
        'dt = BDClass.SQLtoDataTable(sqry, False)
        'inoshow = dt.Rows(0).Item(0)





        'sqry = "select distinct NoOrden" _
        '                                  & " from TYT_LV_TBL_CONTROL_CITAS " _
        '                                  & " " _
        '                                  & " where Year(Fecha_Hora_ini_Oper) =year(getdate()) And Month(Fecha_Hora_ini_Oper) =Month(getdate()) And Day(Fecha_Hora_ini_Oper) =day(getdate()) " _
        '                                  & " and (Status ='Iniciada' or Status ='Reiniciada')  and Status_OS ='EN PROCESO' " _
        '                                  & "   and servicioCapturado <> 'Lavado'    and Fecha_Hora_Fin_Oper is null "
        ''System.IO.File.AppendAllText("C:\Capital\pullsysv11_Daniel\pullsysv11\Logs\SQL2_SQLtoDatatable.txt", vbCrLf & sqry & vbCrLf & vbCrLf)

        'dt = BDClass.SQLtoDataTable(sqry, False)
        'ienrampa = dt.Rows.Count



        ''sqry = "select distinct noPlacas Placa, conCita, noOrden, Fecha_Hora_ini_Oper, fecha_Hora_Fin_Oper, Status, Cliente " _
        ''                                        & "  from  dbo.TYT_LV_TBL_CONTROL_CITAS " _
        ''                                        & " where Year(fecha) = year(getdate())  And Month(fecha) =  Month(getdate()) And Day(fecha) =day(getdate())  " _
        ''                                        & "   and servicioCapturado <> 'Lavado' and ConCita=1 and noOrden<>'0'  and vhRecepcion=0"

        'sqry = "select distinct a.noPlacas Placa, a.conCita, a.noOrden, a.Cliente,a.ColorPrisma  " _
        '                                          & "  from  dbo.TYT_LV_TBL_CONTROL_CITAS a  inner join dbo.TYT_LV_TBL_CONTROL_CITAS_HEADER b on a.vin=b.vin " _
        '                                          & " where Year(a.fecha) = year(getdate()) And Month(a.fecha) = Month(getdate()) And Day(a.fecha) =  day(getdate()) " _
        '                                          & "   and a.ConCita=1 and a.numcita<>0 and a.Fecha_Hora_ini_Oper is null and b.HoraIEntrega is null and (not b.HoraFRecepcion is null)" _
        '                                           & "   union all" _
        '   & "   ( select distinct a.noPlacas Placa, 0 as conCita, a.noOrden, a.Cliente, a.ColorPrisma  from dbo.TYT_LV_TBL_CONTROL_CITAS a inner join dbo.TYT_LV_TBL_CONTROL_CITAS_HEADER b   on a.vin=b.vin   inner join TYT_LV_TBL_CONTROL_CITAS_HEADER_RECEPCION c on c.noPlacas=b.noplacas " _
        '   & "    where  Year(a.fecha) = year(getdate()) And Month(a.fecha) =  Month(getdate()) And Day(a.fecha) = day(getdate())  and a.Fecha_Hora_ini_Oper is null  and c.HoraIEntrega is null and (not c.HoraFRecepcion is null) )"


        'sqry = "select distinct noPlacas Placa, conCita, noOrden,  Cliente " _
        '                                       & "  from  dbo.TYT_LV_TBL_CONTROL_CITAS_header " _
        '                                       & " where Year(fecha) = year(getdate())  And Month(fecha) =  Month(getdate()) And Day(fecha) =  day(getdate()) " _
        '                                       & "      and (horaIRecepcion is null) and (not horaLlegada is null) and ( horaretiro is null) " _
        ' & "   union all" _
        ' & "   (select distinct noPlacas Placa, 0 as conCita, '0' as noOrden, Cliente from dbo.TYT_LV_TBL_CONTROL_CITAS_HEADER_RECEPCION" _
        ' & "    where  Year(fecha) = year(getdate())  And Month(fecha) =  Month(getdate()) And Day(fecha) =  day(getdate())  and (horaIRecepcion is null) and (not horaLlegada is null) and ( horaretiro is null) )"


        'dt = BDClass.SQLtoDataTable(sqry, False)
        'ienespera = dt.Rows.Count

        Dim SCONTROL As String
        SCONTROL = "<div class='cssPull' >"
        SCONTROL += "<table style='border:solid thin silver;background-color:transparent;font-size:10px;font-family:arial;'  cellspacing='1'>"

        'SCONTROL += "<tr>"
        'SCONTROL += "<td  align='left'>SIN RECEPCION</td><td  align='left'>NO SHOW</td><td  align='left'>EN SERVICIO</td> "
        'SCONTROL += "</td>"
        'SCONTROL += "</tr>"
        'SCONTROL += "<tr>"
        'SCONTROL += "<td  align='center'>" & ienespera & "</td><td  align='center'>" & inoshow & "</td><td  align='center'>" & ienrampa & "</td> "
        'SCONTROL += "</td>"
        'SCONTROL += "</tr>"
        Dim OBJCOL As New CHIPPullCollection
        OBJCOL = Session("ColChips")


        y = From p As ChipPull In OBJCOL Select p Order By p.NOPLACAS Ascending


        If OBJCOL.Count > 0 Then
            SCONTROL += "<tr>"

            SCONTROL += "<td colspan=2 >BUSCAR PLACAS:</td><td><select id='selOptChips' onchange='buscaChp(this.value);'> "
            SCONTROL += "<option value=''>--</option>"

            For Each obj As ChipPull In y
                SCONTROL += "<option value='" & obj.IDFICHA & "'>" & obj.NOPLACAS & "</option>"
            Next


            SCONTROL += "</select>"
            'SCONTROL=+= " <input type=button id='cmdinptBuscar'  name='cmdinptBuscar' onclick=buscaChp(getElementById('selOptChips').value);>"
            SCONTROL += "</td>"

            SCONTROL += "</tr><tr>"
            SCONTROL += "<td colspan=2 >BUSCAR ORDEN:</td><td><input type='text' id='inOptChips'  style='width:70px;'/><input type='button' onclick='buscaChpOrd();' id='btninOptChips'/> "
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
        'dchp.Attributes.Add("onclick", "Location('dchp')")
    End Sub


    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        TablerosUtilsHyP.Salir()
        Response.Redirect("Inicio.aspx")
    End Sub

    Protected Sub link_Click(sender As Object, e As EventArgs)
        Session.Remove("PullLinks")
        Session("PullLinks") = sender.id
        Page.ClientScript.RegisterClientScriptBlock(GetType(Page), "popPullDet", "<script>      var xwin=window.open('pull_systemDetalle2.aspx', '', 'status=yes,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=yes,modal=yes,dependable=yes;'); </script>")

    End Sub
End Class
