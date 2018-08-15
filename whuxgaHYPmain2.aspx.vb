
Imports ZedGraph.Web
Imports System.Drawing
Imports TablerosV2LibTypes
Imports System.Data.Linq
Partial Public Class whuxgaHYPmain2
    Inherits System.Web.UI.Page
    Const iTablero As Integer = 2
    Dim bref As Boolean
    Dim iFechaIni As DateTime ' = Date.Now.AddDays(CInt(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumdias")))
    Dim iFechaFin As DateTime '= Date.Now.AddDays(CInt(SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumdias")))
    Dim iFechaHoy As DateTime
    Dim ifactorh As Double = 59.437

    Dim iHorai As Decimal = 0
    Dim inumHoras As Decimal = 0
    Property pgvDms() As Boolean
        Get
            Return Session("_pgvdms")
        End Get
        Set(ByVal value As Boolean)
            Session("_pgvdms") = value
        End Set
    End Property

    Private Sub whuxgaPT_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Not Page.IsPostBack Then
            txtCalendar.Text = Date.Now.ToShortDateString
            lblCalendar.Text = txtCalendar.Text
            'refreshDMS()
            lblUsr.Text = Session("Usuario")

        End If
        iFechaHoy = CDate(Date.Now)
        iFechaIni = iFechaHoy.Now.AddDays(-1 * CInt(SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumdias")))
        iFechaFin = iFechaHoy.Now.AddDays(CInt(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumdias")))
        inumHoras = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumhoras")

        iHorai = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "ihorai")
    End Sub

    Sub LlenaAsesores()

        Dim dt As New DataTable
        Dim sqry As String = ""


        sqry = "Select nombre_empleado,color_tecnico from tb_ASESORES  order   by bahia asc "
        dt = BDClass.SQLtoDataTable(sqry, False)

        DataList1.DataSource = dt

        DataList1.DataBind()

    End Sub
 
    Protected Sub DataList1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataList1.PreRender
        For i = 0 To DataList1.Items.Count - 1
            Try
                CType(DataList1.Items(i).Controls(1), Label).Style.Value = "color:" & CType(DataList1.Items(i).Controls(1), Label).Text & ";background-color:" & CType(DataList1.Items(i).Controls(1), Label).Text & ";"

            Catch ex As Exception

            End Try
        Next
    End Sub
    Private Sub AbrirChip(ByVal iId As Int64, ByVal ssTop As String, ByVal ssLeft As String)
        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        dchp.Style.Remove("Left")
        dchp.Style.Remove("Top")
        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then

                Modelo.Text = "Mod: " & obj.VEHICULO
                Tolerancia.Text = "H.Tol: " & obj.HORATOLERANCIA
                Service.Text = "" & obj.SERVICIOCAPTURADO
                Orden.Text = "Orden " & obj.NOORDEN
                Placas.Text = "Placa: " & obj.NOPLACAS
                dchp.Style.Add("Left", ssLeft)
                dchp.Style.Add("Top", ssTop)

                dchp.Focus()
                Exit For
            End If

        Next

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If InStr(Page.AppRelativeVirtualPath, Session("URL")) = 0 Or Session("URL") Is Nothing Then Response.Redirect("Inicio.aspx")
        lblmessage.Text = ""
        'If Not Request("dat") Is Nothing Then
        '    If Request("dat") <> "" Then
        '        lblmessage.Text = Request("dat")

        '    End If
        'End If


        LlenaAsesores()

        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value

        If Not Page.IsPostBack Then
            bref = True
        End If
        sITablero()
        '  Try
        PINTACHIPS()
        '    Catch ex As Exception

        '    End Try


        If sdhtml = "dchp" Then
            dchp.Visible = False
        ElseIf Left(sdhtml, 3) = "div" Then
            dchp.Visible = False
        ElseIf Left(sdhtml, 4) = "ds00." Then
            dchp.Visible = False
        ElseIf Left(sdhtml, 6) = "txtMec" Then
            dchp.Visible = False
        ElseIf sdhtml.Split(".").Length < 2 And sdhtml.Length > 0 Then
            AbrirChip(CType(Me.FindControl(sdhtml).Controls(1), HtmlInputHidden).Value, CType(Me.FindControl(sdhtml), HtmlGenericControl).Style.Item("top"), CType(Me.FindControl(sdhtml), HtmlGenericControl).Style.Item("left"))
            dchp.Visible = True
        Else
            dchp.Visible = False
        End If
    End Sub
    Sub sITablero()
        ' If bref = False Then Exit Sub
        bref = False
        'cboHoraCita.Items.Clear()
        'Dim I As Integer
        'For I = 0 To 18
        '    cboHoraCita.Items.Add(New ListItem(String.Format("{0:HH:mm}", CDate(iFechaHoy.ToShortDateString).AddHours(9).AddMinutes(30 * I))))
        'Next

        Dim OBJCOL As New CHIPHYPCollection, objchip As ChipHYP, k As Integer
        Dim dtAusencias As New DataView

        Session("dtAusencias") = dtAusencias
        Dim OBJCOLP As New CHIPHYPCollection
        OBJCOLP = OBJCOLP.ObtenChipsAllCitas2P(Request.Url.Segments(Request.Url.Segments.Length - 1), CDate(lblCalendar.Text), True)
        Session("ColChipsP") = OBJCOLP


        Dim dr() As DataRow
        Dim dtPosP As New DataTable
        dtPosP.Columns.Add("Orden")
        dtPosP.Columns.Add("idTecnico")
        dtPosP.Columns.Add("Nombre")
        dtPosP.Columns.Add("Color")
        dtPosP.Columns.Add("Placas")
        dtPosP.Columns.Add("Cliente")
        dtPosP.Columns.Add("Vehiculo")
        dtPosP.Columns.Add("Servicio")
        dtPosP.Columns.Add("id", GetType(Int32))
        Dim col0 = (From p In OBJCOLP Order By p.noplacas Ascending, p.id Ascending Select p)

        For Each a As ChipHYP In col0
            If dtPosP.Select("placas='" & a.NOPLACAS & "'").Count = 0 And (a.TIPOCLIENTE.ToLower.Trim() = "recepcion" Or a.TIPOCLIENTE.ToLower.Trim() = "entrega") Then
                dtPosP.Rows.Add(New Object() {a.NOORDEN, a.IDASESOR, TablerosUtilsHyP.ObtenNombreTecnicosv2(a.IDASESOR), TablerosUtilsHyP.ObtenColorAsesorV2(a.IDASESOR), a.NOPLACAS, a.CLIENTE, a.VEHICULO, a.SERVICIO, a.ID})
            End If
        Next

        dr = dtPosP.Select("", "idTecnico asc")

        Dim imgLstPosOrd As New DataTable
        imgLstPosOrd.Columns.Add("idTecnico")
        imgLstPosOrd.Columns.Add("noorden")
        imgLstPosOrd.Columns.Add("noplacas")
        imgLstPosOrd.Columns.Add("cliente")
        imgLstPosOrd.Columns.Add("tipocliente")
        imgLstPosOrd.Rows.Clear()

        For I = 0 To dr.Count - 1
            If imgLstPosOrd.Select("noplacas='" & dr(I).Item("Placas") & "'").Count = 0 Then
                imgLstPosOrd.Rows.Add(New Object() {dr(I).Item("idTecnico"), dr(I).Item("Orden"), dr(I).Item("Placas"), dr(I).Item("Cliente")})
            End If
            If imgLstPosOrd.Select("idTecnico='" & dr(I).Item("idTecnico") & "'").Count < 2 Then
                imgLstPosOrd.Rows.Add(New Object() {dr(I).Item("idTecnico"), dr(I).Item("Orden"), dr(I).Item("Placas"), dr(I).Item("Cliente")})
            End If

        Next




        ''For I = 0 To OBJCOLP.Count - 1
        ''    objchip = OBJCOLP.Item(I)
        ''    If imgLstPosOrd.Select("noplacas='" & objchip.NOPLACAS & "'").Count = 0 Then
        ''        imgLstPosOrd.Rows.Add(New Object() {objchip.ID, objchip.NOORDEN, objchip.NOPLACAS, objchip.CLIENTE, objchip.TIPOCLIENTE})
        ''    End If
        ''Next


        Dim sScript As String = ""
        Dim iNumbahias As Integer ' = dt.Rows.Count
        Dim ilargo As Integer = 0
        Dim iwidth As Integer = "1500"

        iNumbahias = imgLstPosOrd.Rows.Count


        iwidth = ((ifactorh * inumHoras) * (DateDiff(DateInterval.Day, iFechaIni, iFechaFin)))

        floatdiv.Style.Remove("width")
        floatdiv.Style.Add("width", iwidth + 190 & "px")
        topfix0.Style.Remove("width")
        topfix0.Style.Add("width", iwidth + 190 & "px")
        If iTablero <> 1 Then
            iNumbahias = iNumbahias ' * 2
        End If
        ilargo = ((iNumbahias) * 30) + 92



        'If form1.FindControl("txtPos") Is Nothing Then
        '    'Dim txtPos As New HtmlGenericControl("div")
        '    'txtPos = New HtmlGenericControl("div")
        '    'txtPos.ID = "txtPos"
        '    'txtPos.Style.Value = "position:absolute;left:" & CInt(((((Date.Now.DayOfYear - Date.Now.AddMonths(-1).DayOfYear - 2 - CDATES.iDomingos(Date.Now)) * 24) + Date.Now.Hour) / 3) * 9.437) & "px;top:0px;width:1px;height:1px;background-color:White;Font-weight:bold;font-family:Arial;font-size:10px;border:solid 1px silver;text-align:center;"
        '    'form1.Controls.Add(txtPos)
        'End If



        sScript += "<script type='text/javascript'>" & vbCrLf
        sScript += "var jg_doc = new jsGraphics();" & vbCrLf
        'If (Date.Now.DayOfYear - Date.Now.AddDays(SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumdias")).DayOfYear) < 0 Then
        '    sScript += "var days = " & Date.Now.DayOfYear + (New Date(Date.Now.Year, Date.Now.Month, 1).AddDays(-1).DayOfYear - Date.Now.AddMonths(-1).DayOfYear - CDATES.iDomingos(Date.Now)) & ";" & vbCrLf
        'Else
        sScript += "var days = " & DateDiff(DateInterval.Day, iFechaHoy.Now.AddDays(-1 * SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumdias")), iFechaHoy.Now) & ";" & vbCrLf
        'End If
        sScript += "var hours = " & iFechaHoy.Now.Hour & ";" & vbCrLf
        sScript += "var minutes = " & iFechaHoy.Now.Minute & ";" & vbCrLf
        sScript += "var ifac = 0.05*94;" & vbCrLf
        'sScript += "if(hours<10||hours>18    ){if(hours>18){hours=-" & inumHoras & ";minutes=0;} else{hours=0;minutes=0;} } else {hours=hours-" & inumHoras & ";}" & vbCrLf

        sScript += "if(hours<" & iHorai & "||hours>" & iHorai + inumHoras - 1 & "){"
        sScript += "hours=0;minutes=0; "
        sScript += "} else {hours=hours-" & iHorai & ";}" & vbCrLf

        sScript += "jg_doc.setColor('#CCFFCC');" & vbCrLf
        sScript += "lx = (days*" & inumHoras & ") + (hours);" & vbCrLf
        sScript += "if (lx > ifac) {" & vbCrLf
        sScript += "lx = (days*" & inumHoras & ") + (hours) ;" & vbCrLf
        sScript += "lx = (lx) * " & ifactorh & ";" & vbCrLf
        sScript += "lx = parseInt(lx);" & vbCrLf
        sScript += "jg_doc.fillRect(92, 94, lx, " & ilargo - 92 & ");}" & vbCrLf


        ''''
        sScript += " var ejeX=206; var ejeY=94; " & vbCrLf
        If iTablero <> 1 Then
            sScript += " for(var d_i = 1; d_i <= " & iNumbahias & "; d_i++){ " & vbCrLf
        Else
            sScript += " for(var d_i = 1; d_i <= " & iNumbahias * 6 & "; d_i++){ " & vbCrLf

        End If

        sScript += "    ejeY += 30; " & vbCrLf
        sScript += "    if (d_i == " & iNumbahias & " || d_i == " & iNumbahias * 2 & "  || d_i == " & iNumbahias * 3 & "  || d_i == " & iNumbahias * 4 & " || d_i == " & iNumbahias * 5 & "){" & vbCrLf
        sScript += "        jg_doc.setColor('Black');   jg_doc.fillRect(0, ejeY, " & iwidth + 92 & ", 2);} " & vbCrLf
        sScript += "    else{jg_doc.setColor('Darkslategray');jg_doc.drawLine(0, ejeY, " & iwidth + 92 & ", ejeY);} " & vbCrLf

        sScript += " }" & vbCrLf

        sScript += "jg_doc.setColor('Lightcoral');" & vbCrLf
        sScript += "jg_doc.drawLine(92, 0, 92, " & ilargo & "); " & vbCrLf
        sScript += "jg_doc.setColor('Black');" & vbCrLf
        sScript += "jg_doc.fillRect(" & iwidth + 92 & ", 0, 3, " & ilargo & ");" & vbCrLf
        sScript += " jg_doc.setColor('Black'); " & vbCrLf


        sScript += "jg_doc.fillRect(0, " & ilargo & ", " & iwidth + 92 & ", 3);" & vbCrLf

        sScript += "jg_doc.setColor('Silver'); " & vbCrLf
        sScript += "var posX = 92; var posX2=92;var posX22=92;" & vbCrLf
        sScript += "for(var d_i = 1; d_i <= " & CInt(System.Math.Round(iwidth / (ifactorh * inumHoras))) & "; d_i++){" & vbCrLf
        sScript += "            for(var d_j = 1; d_j < " & inumHoras + 1 & "; d_j++){" & vbCrLf
        sScript += "                jg_doc.setColor('yellow'); jg_doc.drawLine(posX2, 92, posX2, " & ilargo & ");" & vbCrLf

        sScript += "                    for(var d_jj = 1; d_jj < " & ((inumHoras * 6) + 1) & "; d_jj++){" & vbCrLf
        sScript += "                    jg_doc.setColor('silver'); jg_doc.drawLine(posX22, 92, posX22, " & ilargo & ");" & vbCrLf
        sScript += "                    posX22=posX22+" & (ifactorh / 6) & ";}" & vbCrLf

        sScript += "                posX2=posX2+" & ifactorh & ";}" & vbCrLf
        sScript += "        jg_doc.setColor('Navy'); jg_doc.drawLine(posX, 92, posX, " & ilargo & "); " & vbCrLf
        sScript += "        jg_doc.setColor('red'); jg_doc.drawLine(posX+" & ((ifactorh * inumHoras) / 2) & ", 92, posX+" & ((ifactorh * inumHoras) / 2) & ", " & ilargo & "); " & vbCrLf
        ' sScript += "        jg_doc.setColor('Silver'); jg_doc.drawLine(posX+37.75, 92, posX+37.75, " & ilargo & "); " & vbCrLf
        sScript += "     posX = posX+" & (ifactorh * inumHoras) & ";}" & vbCrLf

        sScript += " " & vbCrLf


        sScript += " //SET_DHTML('ds00'); " & vbCrLf
        sScript += " jg_doc.paint();" & vbCrLf
        sScript += "" & vbCrLf


        sScript += "</script>" & vbCrLf
        Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "TabGraph", sScript)


        Dim ddate As Date = iFechaHoy.AddDays(-1 * SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumdias"))
        Dim txtDia2 As HtmlGenericControl, txthoras As HtmlGenericControl
        Dim dtPosDias As New DataTable, idomingos As Integer
        dtPosDias.Columns.Add("dia", New Date().GetType)
        dtPosDias.Columns.Add("posleft", New Integer().GetType)
        dtPosDias.Rows.Clear()
        For I = 1 To DateDiff(DateInterval.Day, iFechaIni, iFechaFin)


            txtDia2 = New HtmlGenericControl("div")
            txthoras = New HtmlGenericControl("div")
            dtAusencias.RowFilter = "fecha='#" & String.Format("{0:s}", ddate.AddDays(I - 1).ToShortDateString) & "#'"

            'If dtAusencias.Count > 0 Then  

            'Else


            txtDia2.ID = "txtDia" & ddate.AddDays(I - 1).DayOfYear



            If ddate.AddDays(I - 1).DayOfWeek = DayOfWeek.Sunday Then
                txtDia2.Style.Value = "position:absolute;left:" & 91 + ((ifactorh * inumHoras) * ((I - 1))) & "px;top:70px;width:" & (ifactorh * inumHoras) & "px;height:20px;background-color:darkgray;color:white;Font-weight:bold;font-family:Arial;font-size:10px;border:solid 1px silver;text-align:center;"

                txtDia2.InnerText = ddate.AddDays(I - 1).ToShortDateString
                dtPosDias.Rows.Add(New Object() {CDate(txtDia2.InnerText), 91 + ((ifactorh * inumHoras) * ((I - 1)))})

            Else


                txtDia2.Style.Value = "position:absolute;left:" & 91 + ((ifactorh * inumHoras) * ((I - 1))) & "px;top:70px;width:" & (ifactorh * inumHoras) & "px;height:20px;background-color:White;Font-weight:bold;font-family:Arial;font-size:10px;border:solid 1px silver;text-align:center;"

                txtDia2.InnerText = ddate.AddDays(I - 1).ToShortDateString
                dtPosDias.Rows.Add(New Object() {CDate(txtDia2.InnerText), 91 + ((ifactorh * inumHoras) * ((I - 1)))})
                txthoras.InnerHtml = "<table  width='" & (ifactorh * inumHoras) & "px' class='tblhoras'><tr>"

            End If

            For k = iHorai To inumHoras + iHorai - 1
                txthoras.InnerHtml = txthoras.InnerHtml + "<td width='" & ifactorh & "px'>" & k & "</td>"
            Next
            txthoras.InnerHtml = txthoras.InnerHtml + "</tr></table>"

            If form1.FindControl(txtDia2.ID) Is Nothing Then
                txtDia2.Controls.Add(txthoras)
                floatdiv.Controls.Add(txtDia2)
            End If
            ' End If





        Next
        Session("dtPosDias") = dtPosDias

        'OBJCOL = OBJCOL.ObtenChipsAllCitas("", 0)


        'Dim imgLstPosDMS As New DataTable


        'Session("ColChipsDMS") = OBJCOL

        'imgLstPosDMS = New DataTable
        'imgLstPosDMS.Columns.Add("ID")
        'imgLstPosDMS.Columns.Add("noorden")
        'imgLstPosDMS.Columns.Add("idservicio")
        'imgLstPosDMS.Columns.Add("noplacas")
        'imgLstPosDMS.Columns.Add("cliente")
        'imgLstPosDMS.Rows.Clear()

        'For I = 1 To OBJCOL.Count
        '    objchip = OBJCOL.Item(I - 1)
        '    imgLstPosDMS.Rows.Add(New Object() {objchip.ID, objchip.NOORDEN, objchip.IDSERVICIO, objchip.NOPLACAS, objchip.CLIENTE})

        'Next

        'gvDMS.DataSource = imgLstPosDMS
        'gvDMS.DataBind()
        ''DMS


        Dim imgLst As New ArrayList()

        Session("imgLst") = imgLst



        Dim txtOrd As Label, TXTmEC As Label

        Dim dtPos As New DataTable, ktop As Integer = 0, iktop As Integer
        dtPos.Columns.Add("idTecnico")

        dtPos.Columns.Add("IdControl")

        dtPos.Columns.Add("posY")
        dtPos.Columns.Add("Orden")
        dtPos.Columns.Add("idTecnicoP")
        dtPos.Columns.Add("Placas")




        Dim II As Integer = leftfix.Controls.Count

        For I = (II - 1) To 0 Step -1
            If Left(leftfix.Controls(I).ID, 7) = "txtOrd_" Then
                leftfix.Controls.RemoveAt(I)
            ElseIf Left(leftfix.Controls(I).ID, 7) = "TXTmEC_" Then
                leftfix.Controls.RemoveAt(I)
            End If
        Next



        ktop = 0
        Dim ITOT As Decimal, x As String, col


        dr = dtPosP.Select("", "idTecnico asc, id desc")
        For I = 0 To dr.Count - 1
            If dtPos.Select("idTecnico='" & dr(I).Item("idTecnico") & "'").Count = 0 Then
                TXTmEC = New Label
                TXTmEC.ID = "TXTmEC_" & dr(I).Item("idTecnico") & "_" & I
                TXTmEC.Style.Value = "position:absolute;left:1px;top:" & ktop + 2 & "px;width:85px;height:26px;background-color:" & dr(I).Item("color") & ";Font-weight:bold;font-family:Arial;font-size:10px;border:solid 1px black;"
                TXTmEC.Text = dr(I).Item("Nombre")
                leftfix.Controls.Add(TXTmEC)

                ktop = ktop + 30
            End If


            txtOrd = New Label
            txtOrd.ID = "txtOrd_" & dr(I).Item("Orden") & I
            txtOrd.Style.Value = "position:absolute;left:40px;top:" & ktop + 2 & "px;width:45px;height:26px;background-color:White;Font-weight:bold;font-family:Arial;font-size:10px;border:solid 1px black;"
            txtOrd.Text = dr(I).Item("Placas")

            ITOT = (From p In OBJCOLP Where p.NOORDEN = dr(I).Item("Orden") Group p By key = p.NOORDEN Into g = Sum(CInt(p.SERVICIO)) Select g).First
            ITOT = System.Math.Round(ITOT / 60, 1)
            leftfix.Controls.Add(txtOrd)

            txtOrd.ToolTip = "Cliente: " & dr(I).Item("Cliente") & vbCrLf & "Placas: " & dr(I).Item("Placas") & vbCrLf & "Vehiculo: " & dr(I).Item("Vehiculo") & vbCrLf & "Total Servicio: " & ITOT & " horas"
            leftfix.Controls.Add(txtOrd)

            dtPos.Rows.Add(New Object() {dr(I).Item("idTecnico"), txtOrd.ID, ktop + 94, dr(I).Item("Orden"), dtPosP.Select("Orden='" & dr(I).Item("Orden") & "'")(0)("idTecnico"), dr(I).Item("Placas")})

            ktop = ktop + 30
        Next



        Session("dtPosY1") = dtPos

    End Sub
    Sub _moverchip(sdhtml As String, im As Integer)
        Dim iId As Int64, iPosx As Int32, iPosY As Int32, sHora As String
        ' Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 5) = "ds00." Then Exit Sub
        For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
            If Left(d.id, 5) = "ctlll" Then
                iId = d.Value
            End If
        Next

        '  iId = CType(Me.FindControl(Split(sdhtml, ".")(0)).Controls(1), HtmlInputHidden).Value
        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        'sHora = String.Format("{0:HH:mm}", CDate(String.Format("{00:d}", iHorai) & ":00").AddMinutes((((Decimal.Round(CDec((Val(iPosx) - 92) / ifactorh), 2) - Fix(CDec((Val(iPosx) - 92) / ifactorh))) / (ifactorh / inumHoras)) * ifactorh) * 60))
        sHora = String.Format("{0:HH:mm}", CDate(New Date(Now.Year, Now.Month, Now.Day, iHorai, 0, 0)).AddMinutes((((Decimal.Round(CDec((Val(iPosx) - 92) / (ifactorh * inumHoras)), 2) - Fix(CDec((Val(iPosx) - 92) / (ifactorh * inumHoras)))) / ifactorh) * (ifactorh * inumHoras)) * 60))

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")


        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then
                obj.TOPPX = iPosY
                obj.LEFTPX = iPosx
                obj.HORARAMPA = sHora
                If Validar(obj, "M") Then
                    TablerosUtilsHyP.MoverChipAse(obj, iPosY, iPosx, ifactorh * inumHoras, inumHoras, iHorai, obj.TIPOCLIENTE.ToLower)
                End If


                Exit For
            End If
        Next
    End Sub
    Private Sub imgBtnMve_DMS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnMve_DMS.Click


        Dim schip As String = "", stexto As String = ""
        Dim ileft As Integer = CInt(((24) / 3) * 9.437)
        ' sMensajes = New ArrayList
        schip = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        _moverchip(schip, 0)

        'If iMulti.Value.Split(",").Length < 2 Then
        '    schip = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        '    _moverchip(schip, 0)
        'Else
        '    For i As Integer = 0 To Me.iMulti.Value.Split(",").Length() - 1

        '        schip = iMulti.Value.Split(",")(i)
        '        _moverchip(schip, Me.iMulti.Value.Split(",").Length())
        '    Next

        'End If
        ''For Each s As String In sMensajes
        ''    stexto += s & "</br>"
        ''Next
        ''If stexto.Length > 0 Then TablerosUtilsHyP.iMsgBox(Me, stexto, ileft)

        'iMulti.Value = ""






        Dim objc As New ArrayList()
        For Each d In Me.form1.Controls
            If Left(d.id, 2) = "ds" Or Left(d.id, 5) = "ctlll" Then
                objc.Add(d.id)
            End If
        Next
        For Each d In objc
            If Left(d, 2) = "ds" Or Left(d, 5) = "ctlll" Then
                Me.form1.Controls.Remove(Me.form1.FindControl(d))
            End If
        Next
        bref = True

        sITablero()

        PINTACHIPS()

    End Sub
    Private Sub txtCalendar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCalendar.TextChanged

        lblCalendar.Text = txtCalendar.Text

    End Sub
    'Sub buscadms(ByVal sOrden As String)
    '    'DMS
    '    Dim OBJCOL As New CHIPHYPCollection, objchip As ChipHYP
    '    OBJCOL = OBJCOL.ObtenChipsAllDMS(sOrden)
    '    Session("ColChipsDMS") = OBJCOL

    '    Dim imgLstPosDMS As New DataTable
    '    imgLstPosDMS.Columns.Add("ID")
    '    imgLstPosDMS.Columns.Add("noorden")
    '    imgLstPosDMS.Columns.Add("idservicio")
    '    imgLstPosDMS.Columns.Add("noplacas")
    '    imgLstPosDMS.Columns.Add("cliente")
    '    imgLstPosDMS.Rows.Clear()

    '    For i = 1 To OBJCOL.Count
    '        objchip = OBJCOL.Item(i - 1)
    '        imgLstPosDMS.Rows.Add(New Object() {objchip.ID, objchip.NOORDEN, objchip.IDSERVICIO, objchip.NOPLACAS, objchip.CLIENTE})

    '    Next

    '    gvDMS.DataSource = imgLstPosDMS
    '    gvDMS.DataBind()
    '    'DMS

    'End Sub
    'Sub buscadmsCita(ByVal sCita As String)
    '    'DMS
    '    Dim OBJCOL As New CHIPHYPCollection, objchip As ChipHYP
    '    OBJCOL = OBJCOL.ObtenChipsAllDMSCita(sCita)
    '    Session("ColChipsDMS") = OBJCOL

    '    Dim imgLstPosDMS As New DataTable
    '    imgLstPosDMS.Columns.Add("ID")
    '    imgLstPosDMS.Columns.Add("noorden")
    '    imgLstPosDMS.Columns.Add("idservicio")
    '    imgLstPosDMS.Columns.Add("noplacas")
    '    imgLstPosDMS.Columns.Add("cliente")
    '    imgLstPosDMS.Rows.Clear()

    '    For i = 1 To OBJCOL.Count
    '        objchip = OBJCOL.Item(i - 1)
    '        imgLstPosDMS.Rows.Add(New Object() {objchip.ID, objchip.NOORDEN, objchip.IDSERVICIO, objchip.NOPLACAS, objchip.CLIENTE})

    '    Next

    '    gvDMS.DataSource = imgLstPosDMS
    '    gvDMS.DataBind()
    '    'DMS

    'End Sub
    Sub PINTACHIPS()

        Dim OBJCOL As New CHIPHYPCollection, objchip As ChipHYP, sstop As String
        Dim sColor As String, sColorServicio As String = "", oChip As String, iNivel As Integer = 0
        Dim imgLst As New ArrayList(), bAlarm As Boolean = False
        Dim dtAusencias As New DataView
        If Not Session("dtAusencias") Is Nothing Then
            dtAusencias = Session("dtAusencias")
        End If

        imgLst = Session("imgLst")
        Dim slefti As Integer
        Dim slefts As String

        'OBJCOL = OBJCOL.ObtenChipsAllP()
        OBJCOL = Session("ColChipsP")
        For i = 1 To OBJCOL.Count
            objchip = OBJCOL.Item(i - 1)
            ' sColorServicio = TablerosUtilsHyP.ObtenColorIdSErvicio(objchip.IDSERVICIO)
            sColor = TablerosUtilsHyP.ObtenColorAsesorV2(objchip.IDASESOR)
            oChip = Left(objchip.OCHIP, 2)


            If objchip.CARRYOVER Then oChip = "dp"
            If objchip.SERVICIO < 60 Then oChip = "dr"
            If objchip.SERVICIO >= 60 Then oChip = "dr"
            If objchip.SERVICIO >= 120 Then oChip = "dg"

            If objchip.CONCITA Then oChip = "dg"
            If objchip.CONCITA = False Then oChip = "db"


            Select Case objchip.TIPOCLIENTE.ToLower()
                Case "recepcion"
                    oChip = "dgre"
                Case "entrega"
                    oChip = "dgen"
                Case "lavado"
                    oChip = "dgl"
                Case "express"
                    oChip = "dge"
                Case Else
                    oChip = oChip

            End Select


            If objchip.STATUS.ToLower = "detenida" Then
                Select Case objchip.IDMOTIVOPARO
                    Case "2"
                        oChip = "dw2"
                    Case "3"
                        oChip = "dw3"
                    Case "4"
                        oChip = "dw4"
                    Case "5"
                        oChip = "dw5"
                    Case "6"
                        oChip = "dw6"
                    Case "7"
                        oChip = "dw7"
                End Select
            End If


            If objchip.STATUS.ToLower = "detenida" Or objchip.STATUS.ToLower = "iniciada" Or objchip.STATUS.ToLower = "reiniciada" Then
                iNivel = 0
            Else
                iNivel = 1
            End If
            If objchip.STATUS.ToLower = "terminado" Then
                oChip = "dl"
                iNivel = 0
            End If

            'If objchip.VHSERVERMINADO = False Then
            '    If objchip.VHRECEPCION = False And CDate(Date.Now.ToShortDateString & " " & objchip.HORAASESOR) < Date.Now Then
            '        If objchip.CARRYOVER = False Then
            '            If CDate(Date.Now.ToShortDateString & " " & objchip.HORACITA) < Date.Now Then
            '                oChip = "dn"

            '            End If
            '        End If

            '    End If
            'End If




            imgLst.Add("ds" & String.Format("{0:000}", i))


            If Not Session("dtPosY1") Is Nothing Then
                If CType(Session("dtPosY1"), DataTable).Select("Orden='" & objchip.NOORDEN & "' and Placas='" & objchip.NOPLACAS & "'").Count > 0 Then
                    sstop = CType(Session("dtPosY1"), DataTable).Select("Orden='" & objchip.NOORDEN & "' and Placas='" & objchip.NOPLACAS & "' ")(0)("posY")
                Else
                    sstop = 0
                End If
            Else
                sstop = 0
            End If

            If CDate(objchip.FECHA.ToShortDateString & " " & objchip.HORARAMPA) <= Date.Now And objchip.STATUS.ToLower = "pendiente" Then
                bAlarm = True
            Else
                bAlarm = False
            End If
            If objchip.STATUSOS <> "SSINCARGO" And objchip.STATUSOS <> "Facturado" And objchip.STATUSOS <> "Remisionado" Then
                'chipBoard(i, oChip, objchip.IDCHIP, CInt((objchip.SERVICIO / 60) * 9.437), objchip.NOORDEN, ((CDate(objchip.FECHA).DayOfYear - (Date.Now.AddMonths(-1).DayOfYear)) * 75.5) + IIf(((CDate(objchip.HORARAMPA).Hour - 9 - 1) * 9.437) > 0, ((CDate(objchip.HORARAMPA).Hour - 9 - 1) * 9.437), 0) + 92 & "px", sstop & "px", sColor, sColorServicio, objchip.ID, objchip.SERVICIOCAPTURADO, objchip.SERVICIO, objchip.OBSERVACIONES)
                slefti = ((Math.Abs(DateDiff(DateInterval.Day, (iFechaIni), CDate(objchip.FECHA.ToShortDateString()))) + 1) * (ifactorh * inumHoras)) + IIf(((CDate(objchip.HORARAMPA).TimeOfDay().TotalHours * ifactorh) - (ifactorh * iHorai)) > 0, ((CDate(objchip.HORARAMPA).TimeOfDay().TotalHours * ifactorh) - (ifactorh * iHorai)), 0) + 92
                If slefti < 0 Then slefti = slefti * -1
                slefts = slefti & "px"

                chipBoard(i, oChip, objchip.IDCHIP, CInt((objchip.SERVICIO / 60) * ifactorh), objchip.NOORDEN, slefts, sstop & "px", sColor, sColorServicio, objchip.ID, objchip.SERVICIOCAPTURADO, objchip.SERVICIO, objchip.OBSERVACIONES, bAlarm, objchip)

            End If

        Next

        Session("imgLst") = imgLst



    End Sub
    'Sub PINTAAusencias()


    '    Dim sColor As String, sColorServicio As String, oChip As String, iNivel As Integer = 0
    '    Dim imgLst As New ArrayList(), bAlarm As Boolean = False
    '    Dim dtAusencias As New DataTable

    '    dtAusencias = TablerosUtilsHyP.ObtenAusenciasTodoDia()


    '    imgLst = Session("imgLst")
    '    Dim slefti As Integer
    '    Dim slefts As String

    '    'OBJCOL = OBJCOL.ObtenChipsAllP()
    '    OBJCOL = Session("ColChipsP")
    '    For i = 1 To OBJCOL.Count
    '        objchip = OBJCOL.Item(i - 1)
    '        sColorServicio = UTableroHyP.ObtenColorServicioFase(objchip.IDSERVICIO)
    '        sColor = UTableroHyP.ObtenColorAsesor(objchip.IDASESOR)
    '        oChip = Left(objchip.OCHIP, 2)


    '        If objchip.CARRYOVER Then oChip = "dp"
    '        If objchip.SERVICIO < 60 Then oChip = "dr"
    '        If objchip.SERVICIO >= 60 Then oChip = "dr"
    '        If objchip.SERVICIO >= 120 Then oChip = "dg"

    '        If objchip.CONCITA Then oChip = "dg"
    '        If objchip.CONCITA = False Then oChip = "db"


    '        If objchip.STATUS.ToLower = "detenida" Then
    '            Select Case objchip.IDMOTIVOPARO
    '                Case "2"
    '                    oChip = "dw2"
    '                Case "3"
    '                    oChip = "dw3"
    '                Case "4"
    '                    oChip = "dw4"
    '                Case "5"
    '                    oChip = "dw5"
    '                Case "6"
    '                    oChip = "dw6"
    '                Case "7"
    '                    oChip = "dw7"
    '            End Select
    '        End If


    '        If objchip.STATUS.ToLower = "detenida" Or objchip.STATUS.ToLower = "iniciada" Or objchip.STATUS.ToLower = "reiniciada" Then
    '            iNivel = 0
    '        Else
    '            iNivel = 1
    '        End If
    '        If objchip.STATUS.ToLower = "terminado" Then
    '            oChip = "dl"
    '            iNivel = 0
    '        End If

    '        If objchip.VHSERVERMINADO = False Then
    '            If objchip.VHRECEPCION = False And CDate(Date.Now.ToShortDateString & " " & objchip.HORAASESOR) < Date.Now Then
    '                If objchip.CARRYOVER = False Then
    '                    If CDate(Date.Now.ToShortDateString & " " & objchip.HORACITA) < Date.Now Then
    '                        oChip = "dn"

    '                    End If
    '                End If

    '            End If
    '        End If

    '        imgLst.Add("ds" & String.Format("{0:000}", i))


    '        If Not Session("dtPosY1") Is Nothing Then
    '            If CType(Session("dtPosY1"), DataTable).Select("Orden='" & objchip.NOORDEN & "'").Count > 0 Then
    '                sstop = CType(Session("dtPosY1"), DataTable).Select("Orden='" & objchip.NOORDEN & "'")(0)("posY")
    '            Else
    '                sstop = 0
    '            End If
    '        Else
    '            sstop = 0
    '        End If

    '        If CDate(objchip.FECHA.ToShortDateString & " " & objchip.HORARAMPA) <= Date.Now And objchip.STATUS.ToLower = "pendiente" Then
    '            bAlarm = True
    '        Else
    '            bAlarm = False
    '        End If
    '        If objchip.STATUSOS <> "SSINCARGO" And objchip.STATUSOS <> "Facturado" And objchip.STATUSOS <> "Remisionado" Then
    '            'chipBoard(i, oChip, objchip.IDCHIP, CInt((objchip.SERVICIO / 60) * 9.437), objchip.NOORDEN, ((CDate(objchip.FECHA).DayOfYear - (Date.Now.AddMonths(-1).DayOfYear)) * 75.5) + IIf(((CDate(objchip.HORARAMPA).Hour - 9 - 1) * 9.437) > 0, ((CDate(objchip.HORARAMPA).Hour - 9 - 1) * 9.437), 0) + 92 & "px", sstop & "px", sColor, sColorServicio, objchip.ID, objchip.SERVICIOCAPTURADO, objchip.SERVICIO, objchip.OBSERVACIONES)
    '            slefti = ((Math.Abs(DateDiff(DateInterval.Day, (iFechaIni), CDate(objchip.FECHA)) - CDATES.iDomingos3(objchip.FECHA, SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumdias"))) + 1) * 75.5) + IIf(((CDate(objchip.HORARAMPA).Hour * 9.437) - (9 * 9.437)) > 0, ((CDate(objchip.HORARAMPA).Hour * 9.437) - (9 * 9.437)), 0) + 92
    '            If slefti < 0 Then slefti = slefti * -1
    '            slefts = slefti & "px"

    '            chipBoard(i, oChip, objchip.IDCHIP, CInt((objchip.SERVICIO / 60) * 9.437), objchip.NOORDEN, slefts, sstop & "px", sColor, sColorServicio, objchip.ID, objchip.SERVICIOCAPTURADO, objchip.SERVICIO, objchip.OBSERVACIONES, bAlarm, objchip)

    '        End If

    '    Next
    '    
    '    Session("imgLst") = imgLst



    'End Sub
    Function ObtenToppx(ByVal noorden As String, ByVal sidservicio As String, ByVal snoplacas As String, ByVal scliente As String, ByVal iNivel As Integer) As String
        Dim dt As DataTable = Session("imgLstPosMec")
        dt.DefaultView.RowFilter = "noorden='" & noorden & "' and idservicio='" & sidservicio & "' and noplacas='" & snoplacas & "' and cliente='" & scliente & "'"
        If dt.DefaultView.Count > 0 Then
            If iNivel = 1 Then
                Return CInt(dt.DefaultView(0)("toppx")) + 25 & "px"
            Else
                Return dt.DefaultView(0)("toppx") & "px"
            End If

        Else
            Return "0px"
        End If

    End Function

    Sub AplicaNivel(ByVal noorden As String, ByVal sidservicio As String, ByVal snoplacas As String, ByVal scliente As String, ByVal iNivel As Integer)
        Dim dt As DataTable = Session("imgLstPosMec")
        Dim LBL As HtmlGenericControl, LBL2 As HtmlGenericControl
        dt.DefaultView.RowFilter = "noorden='" & noorden & "' and idservicio='" & sidservicio & "' and noplacas='" & snoplacas & "' and cliente='" & scliente & "'"
        If dt.DefaultView.Count > 0 Then
            LBL = New HtmlGenericControl("div")
            LBL2 = New HtmlGenericControl("div")
            If iNivel = 1 Then
                LBL.ID = dt.DefaultView(0)("idControl") & "lblStT" & dt.DefaultView(0)("idservicio")
                LBL.Style.Value = "position:absolute;left:70px;top:25px;width:15px;height:20px;background-color:transparent;Font-weight:bold;font-family:Arial;font-size:10px;border:solid 1px black;"
                LBL.InnerText = "T"
                LBL2.ID = dt.DefaultView(0)("idControl") & "lblStT2" & dt.DefaultView(0)("idservicio")
                LBL2.Style.Value = "position:absolute;left:0px;top:0px;background-color:transparent;"
                LBL2.InnerText = CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Text
                ' LBL. = "Trabajando"
                CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Controls.Add(LBL2)
                CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Controls.Add(LBL)

            Else
                LBL.ID = dt.DefaultView(0)("idControl") & "lblStP" & dt.DefaultView(0)("idservicio")
                LBL.Style.Value = "position:absolute;left:70px;top:0px;width:15px;height:20px;background-color:transparent;Font-weight:bold;font-family:Arial;font-size:10px;border:solid 1px black;"
                LBL.InnerText = "P"
                LBL2.ID = dt.DefaultView(0)("idControl") & "lblStP2" & dt.DefaultView(0)("idservicio")
                LBL2.Style.Value = "position:absolute;left:0px;top:0px;background-color:transparent;"
                LBL2.InnerText = CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Text
                ' LBL.ToolTip = "Planeado"
                CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Controls.Add(LBL2)
                CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Controls.Add(LBL)
            End If


        End If

    End Sub
    Function imageCHIP(ByVal sChip As String) As String


        Return SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), sChip)


    End Function

    Sub chipBoard(ByVal numberChip As Integer, ByVal sChip As String, ByVal iItem As Integer, ByVal iTime As Integer, ByRef sTexto As String, ByVal sL As String, ByVal sT As String, ByVal sColor As String, ByVal sColorServicio As String, ByVal iId As Integer, ByVal sServicioCapturado As String, ByVal sServicio As String, ByVal sObservaciones As String, ByVal bAlarm As Boolean, ByVal objChip As ChipHYP)


        Dim sDiv, sWidth, sImageChip As String
        Dim iWidth As Integer

        Dim lbl1, lbl2, lbl3, lbl4 As String
        Dim iPos1 As Integer



        sDiv = "ds" & String.Format("{0:000}", numberChip)

        sImageChip = imageCHIP(sChip)

        ' iWidth = (iTime * 76) / 60

        sWidth = iTime & "px"


        lbl1 = sTexto

        iPos1 = InStr(lbl1, "@")
        If iPos1 > 0 Then
            lbl2 = Mid(lbl1, iPos1 + 1, Len(lbl1) - iPos1)
            lbl1 = Mid(lbl1, 1, iPos1 - 1)

            iPos1 = InStr(lbl2, "@")
            If iPos1 > 0 Then
                lbl3 = Mid(lbl2, iPos1 + 1, Len(lbl2) - iPos1)
                lbl2 = Mid(lbl2, 1, iPos1 - 1)
            End If

            iPos1 = InStr(lbl3, "@")
            If iPos1 > 0 Then
                lbl4 = Mid(lbl3, iPos1 + 1, Len(lbl3) - iPos1)
                lbl3 = Mid(lbl3, 1, iPos1 - 1)
            End If
        End If


        displayChip(iId, sDiv, sL, sT, sWidth, sImageChip, sColor, sColorServicio, iTime, lbl1, sChip, lbl3, lbl4, sServicioCapturado, sServicio, sObservaciones, bAlarm, objChip)




    End Sub
    Sub displayChip(ByVal iItem As Integer, ByVal sDiv As String, ByVal sL As String, ByVal sT As String, ByVal sWidth As String, ByVal sImageChip As String, ByVal sColor As String, ByVal scolorservicio As String, ByVal iTime As Integer, ByVal lblChp1 As String, ByVal lblChp2 As String, ByVal lblChp3 As String, ByVal lblChp4 As String, ByVal sServiciocapturado As String, ByVal sServicio As String, ByVal sObservaciones As String, ByVal bAlarm As Boolean, ByVal objchip As ChipHYP)


        Dim iDiv As Integer
        Dim lbl1 As String

        iDiv = Val(Right(sDiv, 3))
        lbl1 = "lb" & Right(sDiv, 3) & "1"

        Dim ixdivId As New HtmlInputHidden
        ixdivId.Value = iItem
        ixdivId.ID = "ctlll_" & iItem

        Dim ixdiv As New HtmlGenericControl("div")
        ixdiv.ID = sDiv

        ixdiv.Style.Add("Left", sL)
        ixdiv.Style.Add("top", sT)
        ixdiv.Style.Add("width", sWidth)
        ixdiv.Style.Add("height", "23px")
        ixdiv.Style.Add("cursor", "hand")
        ixdiv.Style.Add("background-color", sImageChip)
        ixdiv.Style.Add("position", "absolute")
        ixdiv.Visible = True
        ixdiv.Attributes.Add("class", "menu")
        If objchip.TIPOCLIENTE.ToLower <> "publica" And objchip.TIPOCLIENTE.ToLower <> "prioridad" Then
            ixdiv.Style.Add("border-top-style", "solid")
            ixdiv.Style.Add("border-top-color", sColor)
            ixdiv.Style.Add("border-left-color", "black")
            ixdiv.Style.Add("border-right-color", "black")
            ixdiv.Style.Add("border-bottom-color", "black")
            ixdiv.Style.Add("border-left-style", "solid")
            ixdiv.Style.Add("border-right-style", "solid")
            ixdiv.Style.Add("border-bottom-style", "solid")
            ixdiv.Style.Add("border-left-width", "1px")
            ixdiv.Style.Add("border-right-width", "1px")
            ixdiv.Style.Add("border-bottom-width", "1px")
        ElseIf objchip.TIPOCLIENTE.ToLower = "prioridad" Then
            ixdiv.Style.Add("background-color", "firebrick")
            ixdiv.Style.Add("border-top-style", "solid")
            ixdiv.Style.Add("border-top-color", sColor)
            ixdiv.Style.Add("border-left-color", "red")
            ixdiv.Style.Add("border-right-color", "red")
            ixdiv.Style.Add("border-bottom-color", "red")
            ixdiv.Style.Add("border-left-style", "solid")
            ixdiv.Style.Add("border-right-style", "solid")
            ixdiv.Style.Add("border-bottom-style", "solid")
            ixdiv.Style.Add("border-left-width", "2px")
            ixdiv.Style.Add("border-right-width", "2px")
            ixdiv.Style.Add("border-bottom-width", "2px")
        Else

            ixdiv.Style.Add("border-top-style", "solid")
            ixdiv.Style.Add("border-top-color", sColor)
            ixdiv.Style.Add("border-left-color", "red")
            ixdiv.Style.Add("border-right-color", "red")
            ixdiv.Style.Add("border-bottom-color", "red")
            ixdiv.Style.Add("border-left-style", "solid")
            ixdiv.Style.Add("border-right-style", "solid")
            ixdiv.Style.Add("border-bottom-style", "solid")
            ixdiv.Style.Add("border-left-width", "2px")
            ixdiv.Style.Add("border-right-width", "2px")
            ixdiv.Style.Add("border-bottom-width", "2px")
        End If
       

        'If Left(lblChp2, 2) = "dw" Then ixdiv.Style.Add("Filter", "Chroma(Color=#FFFFFF)Wave(Add=0, Freq=5, LightStrength=20, Phase=220, Strenght=10)")
        ixdiv.Style.Add("clear", "none")
        ixdiv.Style.Add("z-index", "1500")
        ixdiv.Style.Add("font-size", "10px")
        ixdiv.Style.Add("font-weight", "normal")
        ixdiv.Style.Add("text-align", "center")
        ixdiv.Style.Add("background-position", "left top")
        
        Dim sComentarios As String = ""

        For Each d As ChipHYPCom In objchip._HypComentarios
            sComentarios = sComentarios & "--- Comentarios Estatus: " & d._Status & "---" & vbCrLf
            sComentarios = sComentarios & "Fecha: " & d._fecha.ToShortDateString & " " & d._fecha.ToShortTimeString & ", "
            sComentarios = sComentarios & "Usuario: " & d._cveUsuario & vbCrLf
            sComentarios = sComentarios & "   " & d._comentario & vbCrLf

        Next

        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sToolTip") = "" Then
            ixdiv.Attributes.Add("title", "no info")

        Else
            ixdiv.Attributes.Add("title", BDClass.SQLtoDataTable(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "sToolTip") & " where id=" & objchip.ID & " and tipocliente='" & objchip.TIPOCLIENTE & "'", False).Rows(0).Item(0).ToString())

        End If





        ixdiv.Attributes.Add("ondblclick", "Location('" & ixdiv.ID & "')")
        ' If objchip.CONCITA = True Then
        '    ixdiv.InnerText = "CITA-" & objchip.CAMPOMOSTRAR
        'Else
        ixdiv.InnerText = objchip.CAMPOMOSTRAR
        'End If

        If Left(objchip.STATUS.ToUpper, 1) = "I" Or Left(objchip.STATUS.ToUpper, 1) = "R" Or Left(objchip.STATUS.ToUpper, 1) = "D" Or Left(objchip.STATUS.ToUpper, 1) = "T" Then
            Dim ixdivsT As New HtmlGenericControl("div")
            ixdivsT.ID = sDiv & "ST"

            ixdivsT.Style.Add("Left", "0")
            ixdivsT.Style.Add("top", "11px")
            ixdivsT.Style.Add("cursor", "hand")
            ixdivsT.Style.Add("position", "absolute")
            ixdivsT.Style.Add("width", "100%")
            ixdivsT.Style.Add("height", "12px")
             ixdivsT.Style.Add("font-size", "10px")
            ixdivsT.Style.Add("text-align", "center")
            ixdivsT.Style.Add("font-weight", "bold")
            ixdivsT.InnerText = Left(objchip.STATUS.ToUpper, 1)
             ixdiv.Controls.Add(ixdivsT)

        End If
      
        If bAlarm Then
            Dim ixdivAlert As New HtmlImage
            ixdivAlert.ID = sDiv & "Alert"
            ixdivAlert.Src = "~/img/blink.gif"
            ixdivAlert.Style.Add("Left", "0")
            ixdivAlert.Style.Add("top", "0")
            ixdivAlert.Style.Add("cursor", "hand")
            ixdivAlert.Style.Add("position", "absolute")
            ixdivAlert.Style.Add("width", "100%")
            ixdivAlert.Style.Add("height", "100%")
            
            ixdiv.Controls.Add(ixdivAlert)

        End If

        ixdiv.Controls.Add(ixdivId)
        Me.form1.Controls.Add(ixdiv)

    End Sub

    Sub displayAusencia(ByVal iItem As Integer, ByVal sDiv As String, ByVal sL As String, ByVal sT As String, ByVal sWidth As String, ByVal sImageChip As String, ByVal sColor As String, ByVal scolorservicio As String, ByVal iTime As Integer, ByVal lblChp1 As String, ByVal lblChp2 As String, ByVal lblChp3 As String, ByVal lblChp4 As String, ByVal sServiciocapturado As String, ByVal sServicio As String, ByVal sObservaciones As String)


        Dim iDiv As Integer
        Dim lbl1 As String

        iDiv = Val(Right(sDiv, 3))
        lbl1 = "lb" & Right(sDiv, 3) & "1"

     
        Dim ixdiv As New HtmlGenericControl("div")
        ixdiv.ID = sDiv

        ixdiv.Style.Add("Left", sL)
        ixdiv.Style.Add("top", sT)
        ixdiv.Style.Add("width", sWidth)
        ixdiv.Style.Add("height", "23px")
        ixdiv.Style.Add("cursor", "hand")
        ixdiv.Style.Add("background-color", scolorservicio)
        ixdiv.Style.Add("position", "absolute")
        ixdiv.Visible = True

        ixdiv.Style.Add("border-top-style", "solid")
        ixdiv.Style.Add("border-top-color", sColor)
        ixdiv.Style.Add("border-left-color", "black")
        ixdiv.Style.Add("border-right-color", "black")
        ixdiv.Style.Add("border-bottom-color", "black")
        ixdiv.Style.Add("border-left-style", "solid")
        ixdiv.Style.Add("border-right-style", "solid")
        ixdiv.Style.Add("border-bottom-style", "solid")
        ixdiv.Style.Add("border-left-width", "1px")
        ixdiv.Style.Add("border-right-width", "1px")
        ixdiv.Style.Add("border-bottom-width", "1px")
         


        'If Left(lblChp2, 2) = "dw" Then ixdiv.Style.Add("Filter", "Chroma(Color=#FFFFFF)Wave(Add=0, Freq=5, LightStrength=20, Phase=220, Strenght=10)")
        ixdiv.Style.Add("clear", "none")
        ixdiv.Style.Add("z-index", "1500")
        ixdiv.Style.Add("font-size", "10px")
        ixdiv.Style.Add("font-weight", "normal")
        ixdiv.Style.Add("text-align", "center")
        ixdiv.Style.Add("background-position", "left top")

        Dim sComentarios As String = ""

       

        
        ixdiv.Attributes.Add("title", "Entrega: ")
 
 
        
            ixdiv.InnerText = lblChp1


        
        Me.form1.Controls.Add(ixdiv)

    End Sub

    Private Sub whuxgaPT_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        Dim OBJARRAY As ArrayList = CType(Session("imgLst"), ArrayList)
        'Dim OBJARRAYDAYS As ArrayList = CType(Session("imgLstDays"), ArrayList)

        'OBJARRAY.Add("divInterfaz")
        'OBJARRAY.Add("leftfix0")

        Dim va_Enumerator As System.Collections.IEnumerator = OBJARRAY.GetEnumerator()
        Dim sScript As String = ""
        sScript += "" & vbCrLf
        sScript += "" & vbCrLf
        sScript += " SET_DHTML("
        While va_Enumerator.MoveNext()

            sScript += "" & Chr(34) & va_Enumerator.Current & Chr(34) & "+RESIZABLE, "


        End While

        sScript += "" & Chr(34) & "divifra" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "imgLogo1" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "imgLogo0" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "divInterfaz" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "leftfix" & Chr(34) & "+NO_DRAG, "

        sScript += "" & Chr(34) & "divFind" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "dhtml" & Chr(34) & "+NO_DRAG, "
        sScript = Left(sScript, Len(sScript) - 2)
        sScript += ");" & vbCrLf
        sScript += "document.getElementById('txtPos').scrollIntoView(true); " & vbCrLf
        'While va_Enumerator.MoveNext()
        '    If Left(va_Enumerator.Current, 2) = "ds" Then
        '        sScript += "document.getElementById('" & va_Enumerator.Current & "').fireEvent('onclick', '');" & vbCrLf
        '    End If


        'End While


        sScript += "" & vbCrLf
        scrmgr1.RegisterStartupScript(Me, Page.GetType, "TabGraphDHTML", sScript, True)
        If dchp.Visible Then
            scrmgr1.RegisterStartupScript(Me, Page.GetType, "dchpFocus", "document.getElementById('dchp').focus();", True)
        End If
    End Sub



    Private Sub imgBtnOut_DMS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOut_DMS.Click
        TablerosUtilsHyP.Salir()
        Response.Redirect("Inicio.aspx")
    End Sub

    'Private Sub imgBtnMve_DMS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnMve_DMS.Click
    '    Dim iId As Int64, iPosx As Int32, iPosY As Int32
    '    Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
    '    If Split(sdhtml, ".").Length < 2 Then Exit Sub
    '    If Left(sdhtml, 5) = "ds00." Then Exit Sub
    '    iId = CType(Me.FindControl(Split(sdhtml, ".")(0)).Controls(1), HtmlInputHidden).Value
    '    iPosx = CInt(Split(sdhtml, ".")(1))
    '    iPosY = CInt(Split(sdhtml, ".")(2))

    '    Dim OBJCOL As New CHIPHYPCollection
    '    OBJCOL = Session("ColChipsP")


    '    For Each obj As ChipHYP In OBJCOL
    '        If obj.ID = iId Then
    '            obj.TOPPX = iPosY
    '            obj.LEFTPX = iPosx
    '            'If Validar(obj, "M") Then TablerosUtils.MoverChipPRG(obj, iPosY, iPosx)
    '            UTableroHyP.MoverChipPRG(obj, iPosY, iPosx, inumHoras, iHorai, ifactorh)
    '            Exit For
    '        End If
    '    Next

    '    Dim objc As New ArrayList()
    '    For Each d In Me.form1.Controls
    '        If Left(d.id, 2) = "ds" Or Left(d.id, 5) = "ctlll" Then
    '            objc.Add(d.id)
    '        End If
    '    Next
    '    For Each d In objc
    '        If Left(d, 2) = "ds" Or Left(d, 5) = "ctlll" Then
    '            Me.form1.Controls.Remove(Me.form1.FindControl(d))
    '        End If
    '    Next
    '    bref = True
    '    sITablero()
    '    PINTACHIPS()

    'End Sub
    'Protected Sub imgBtnTme_CHP_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnTme_CHP.Click
    '    Dim iId As Int64, iTiempo As Int32, iPosx As Int32, iPosY As Int32
    '    Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
    '    If Split(sdhtml, ".").Length < 2 Then Exit Sub
    '    If Left(sdhtml, 5) = "ds00." Then Exit Sub

    '    iTiempo = CInt(Split(sdhtml, ".")(3))
    '    iTiempo = System.Math.Round(Decimal.Round(CDec(iTiempo / ifactorh), 2) * 60, MidpointRounding.AwayFromZero)

    '    'iTiempo = CInt((iTiempo) * (5 / 6.33))
    '    iPosx = CInt(Split(sdhtml, ".")(1))
    '    iPosY = CInt(Split(sdhtml, ".")(2))
    '    iId = CType(Me.FindControl(Split(sdhtml, ".")(0)).Controls(1), HtmlInputHidden).Value

    '    Dim OBJCOL As New CHIPHYPCollection
    '    OBJCOL = Session("ColChipsP")

    '    For Each obj As ChipHYP In OBJCOL
    '        If obj.ID = iId Then
    '            obj.LEFTPX = iPosx
    '            obj.TOPPX = iPosY
    '            obj.SERVICIO = iTiempo
    '            '  If Validar(obj, "T") Then UTableroHyP.AumentarChipPRG(obj, iTiempo)
    '            UTableroHyP.AumentarChipPRG(obj, iTiempo)
    '            Exit For
    '        End If

    '    Next

    '    Dim objc As New ArrayList()
    '    For Each d In Me.form1.Controls
    '        If Left(d.id, 2) = "ds" Or Left(d.id, 5) = "ctlll" Then
    '            objc.Add(d.id)
    '        End If
    '    Next
    '    For Each d In objc
    '        If Left(d, 2) = "ds" Or Left(d, 5) = "ctlll" Then
    '            Me.form1.Controls.Remove(Me.form1.FindControl(d))
    '        End If
    '    Next
    '    bref = True
    '    sITablero()
    '    PINTACHIPS()
    'End Sub
    Function Validar(ByVal obj As ChipHYP, ByVal iOperacion As String) As Boolean

        Select Case iOperacion


            Case "M"
                If obj.TIPOCLIENTE.ToLower <> "recepcion" And obj.TIPOCLIENTE.ToLower <> "entrega" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "Solo se pueden mover recepciones y entregas", lblmessage)
                    Return False
                End If
                If obj.STATUS = "Terminado" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede mover una operacion terminada", lblmessage)
                    Return False
                End If

                If obj.STATUS = "Iniciada" Or obj.STATUS = "Reiniciada" Then
                    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede mover una operacion Iniciada", lblmessage)


                    Return False
                End If

                'If SCC.SolPermisosBol(SCC.EObjetos.CHIPHYPjdt, SCC.EOperaciones.Mover) = False Then
                '    TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para mover esta operacion", lblmessage)
                '    Return False
                'End If
                'If SCC.SolPermisosBol(SCC.EObjetos.CHIPHYPjdt, SCC.EOperaciones.Mover) = True And SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "imoverchipadelante") <> "1" Then

                '    If Val(obj.LEFTPX) > Val(UTableroHyP.ObtenLeftxHora(obj, iFechaIni, inumHoras, iHorai, ifactorh)) Then
                '        TablerosUtilsHyP.iMsgBox(Me.Page, "No puede mover a una fecha posterior esta operacion", lblmessage)
                '        Return False
                '    End If



        End Select

        If iOperacion = "B" Then Return True



        Return True
    End Function

    'Protected Sub imgBtnDel_DMS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnDel_DMS.Click
    '    'sITablero()
    '    Try
    '        'PINTACHIPS()
    '        Dim iId As Int64
    '        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
    '        If Split(sdhtml, ".").Length < 2 Then Exit Sub
    '        If Left(sdhtml, 5) = "ds00." Then Exit Sub
    '        For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
    '            If Left(d.id, 5) = "ctlll" Then
    '                iId = d.Value
    '            End If
    '        Next
    '        ' iId = CType(Me.FindControl(Split(sdhtml, ".")(0)).Controls(1), HtmlInputHidden).Value

    '        Dim OBJCOL As New CHIPHYPCollection
    '        OBJCOL = Session("ColChipsP")

    '        For Each obj As ChipHYP In OBJCOL
    '            If obj.ID = iId Then
    '                If Validar(obj, "B") Then
    '                    UTableroHyP.BorrarChipPRGALL(obj)
    '                Else
    '                    Exit For
    '                End If

    '                Exit For
    '            End If

    '        Next




    '        'Dim objc As New ArrayList()
    '        'For Each d In Me.form1.Controls
    '        '    If Left(d.id, 2) = "ds" Or Left(d.id, 5) = "ctlll" Then
    '        '        objc.Add(d.id)
    '        '    End If
    '        'Next
    '        'For Each d In objc
    '        '    If Left(d, 2) = "ds" Or Left(d, 5) = "ctlll" Then
    '        '        Me.form1.Controls.Remove(Me.form1.FindControl(d))
    '        '    End If
    '        'Next

    '        'bref = True
    '        'sITablero()
    '        'PINTACHIPS()
    '    Catch ex As Exception
    '        'Dim objc As New ArrayList()
    '        'For Each d In Me.form1.Controls
    '        '    If Left(d.id, 2) = "ds" Or Left(d.id, 5) = "ctlll" Then
    '        '        objc.Add(d.id)
    '        '    End If
    '        'Next
    '        'For Each d In objc
    '        '    If Left(d, 2) = "ds" Or Left(d, 5) = "ctlll" Then
    '        '        Me.form1.Controls.Remove(Me.form1.FindControl(d))
    '        '    End If
    '        'Next

    '    End Try


    '    limpiaform()
    '    bref = True
    '    sITablero()
    '    PINTACHIPS()
    '    'Response.Redirect("whuxgaHYPmain2.aspx")

    'End Sub
    Sub limpiaform()
        Dim objc As New ArrayList()
        For Each d In Me.form1.Controls
            If Left(d.id, 2) = "ds" Or Left(d.id, 5) = "ctlll" Then
                objc.Add(d.id)
            End If
        Next
        For Each d In objc
            If Left(d, 2) = "ds" Or Left(d, 5) = "ctlll" Then
                Me.form1.Controls.Remove(Me.form1.FindControl(d))
            End If
        Next
    End Sub



    Private Sub whuxgaPT_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Not Page.IsPostBack Then
            TablerosUtilsHyP.Salir()
        End If
    End Sub

    'Private Sub imgRefreshAll_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgRefreshAll.Click
    '    'refreshDMS()
    'End Sub
    Protected Sub imgFind_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgFind.Click

        'Exit Sub


    End Sub


    'Private Sub gvDMS_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDMS.PreRender
    '    'Dim dv As DataView

    '    'Dim OBJCOL As New CHIPHYPCollection, objchip As ChipHYP, ik As Integer, ii As Integer, kk As Integer
    '    'Dim dtFases As New DataTable
    '    'OBJCOL = Session("ColChipsDMS")
    '    'Dim txtMec As HtmlGenericControl
    '    ''Dim itr As AsyncPostBackTrigger
    '    ''UPGUARDAV.Triggers.Clear()

    '    ''itr = New AsyncPostBackTrigger


    '    ''itr.ControlID = imgbtnBuscar.ID
    '    ''itr.EventName = "Click"
    '    ''UPGUARDAV.Triggers.Add(itr)
    '    'For i = 0 To gvDMS.Items.Count - 1
    '    '    dtFases = TablerosUtilsHyP.ObtenFases2()
    '    '    CType(gvDMS.Items(i).FindControl("dgCatTrabajos"), DataGrid).DataSource = dtFases
    '    '    CType(gvDMS.Items(i).FindControl("dgCatTrabajos"), DataGrid).DataBind()

    '    '    For kk = 0 To CType(gvDMS.Items(i).FindControl("dgCatTrabajos"), DataGrid).Items.Count - 1
    '    '        For k = 0 To dtFases.Rows.Count - 1
    '    '            CType(CType(gvDMS.Items(i).FindControl("dgCatTrabajos"), DataGrid).Items(kk).FindControl("cboPosiciones"), DropDownList).Items.Add(k)
    '    '        Next
    '    '        CType(CType(gvDMS.Items(i).FindControl("dgCatTrabajos"), DataGrid).Items(kk).FindControl("cboPosiciones"), DropDownList).Items(kk).Selected = True

    '    '    Next


    '    '    'itr = New AsyncPostBackTrigger
    '    '    'itr.ControlID = CType(gvDMS.Items(i).FindControl("cmdAgregarTrabajo"), Button).UniqueID
    '    '    'itr.EventName = "Click"
    '    '    'UPGUARDAV.Triggers.Add(itr)



    '    '    'For ik = 0 To CType(gvDMS.Items(i).FindControl("dgCatTrabajos"), DataGrid).Items.Count - 1
    '    '    '    itr = New AsyncPostBackTrigger
    '    '    '    itr.ControlID = CType(gvDMS.Items(i).FindControl("dgCatTrabajos"), DataGrid).Items(ik).FindControl("btnUp").UniqueID
    '    '    '    itr.EventName = "Click"
    '    '    '    UPGUARDAV.Triggers.Add(itr)
    '    '    '    itr = New AsyncPostBackTrigger
    '    '    '    itr.ControlID = CType(gvDMS.Items(i).FindControl("dgCatTrabajos"), DataGrid).Items(ik).FindControl("btnDown").UniqueID
    '    '    '    itr.EventName = "Click"
    '    '    '    UPGUARDAV.Triggers.Add(itr)


    '    '    'Next
    '    'Next
    '    'Dim converter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color))
    '    'Dim color As System.Drawing.Color
    '    'For i = 0 To gvDMS.Items.Count - 1
    '    '    For j = 0 To CType(gvDMS.Items(i).FindControl("dgCatTrabajos"), DataGrid).Items.Count - 1
    '    '        CType(gvDMS.Items(i).FindControl("dgCatTrabajos"), DataGrid).Items(j).Cells(2).BackColor = converter.ConvertFromString(CType(gvDMS.Items(i).FindControl("dgCatTrabajos"), DataGrid).Items(j).Cells(1).Text)
    '    '    Next


    '    '    dv = New DataView(UTableroHyP.ObtenTecnicosXTipoFASE(UTableroHyP.FaseIni.defLaminado).ToTable)
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("cboILaminero"), DropDownList).Visible = False
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("lblLaminero"), Label).Visible = False
    '    '    CType(gvDMS.Items(i).FindControl("cboILaminero"), DropDownList).Items.Clear()
    '    '    CType(gvDMS.Items(i).FindControl("cboILaminero"), DropDownList).Items.Add(New ListItem("--", "--"))
    '    '    For Each k In dv

    '    '        CType(gvDMS.Items(i).FindControl("cboILaminero"), DropDownList).Items.Add(New ListItem(k("nombre_empleado"), k("id_empleado")))
    '    '    Next

    '    '    dv = New DataView(UTableroHyP.ObtenTecnicosXTipoFASE(UTableroHyP.FaseIni.defAlistamiento).ToTable)
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("cboIAlistador"), DropDownList).Visible = False
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("lblAlistamiento"), Label).Visible = False

    '    '    CType(gvDMS.Items(i).FindControl("cboIAlistador"), DropDownList).Items.Clear()
    '    '    CType(gvDMS.Items(i).FindControl("cboIAlistador"), DropDownList).Items.Add(New ListItem("--", "--"))
    '    '    For Each k In dv

    '    '        CType(gvDMS.Items(i).FindControl("cboIAlistador"), DropDownList).Items.Add(New ListItem(k("nombre_empleado"), k("id_empleado")))
    '    '    Next

    '    '    dv = New DataView(UTableroHyP.ObtenTecnicosXTipoFASE(UTableroHyP.FaseIni.defArmado).ToTable)
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("cboArmado"), DropDownList).Visible = False
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("lblArmado"), Label).Visible = False

    '    '    CType(gvDMS.Items(i).FindControl("cboArmado"), DropDownList).Items.Clear()
    '    '    CType(gvDMS.Items(i).FindControl("cboArmado"), DropDownList).Items.Add(New ListItem("--", "--"))
    '    '    For Each k In dv
    '    '        CType(gvDMS.Items(i).FindControl("cboArmado"), DropDownList).Items.Add(New ListItem(k("nombre_empleado"), k("id_empleado")))
    '    '    Next

    '    '    dv = New DataView(UTableroHyP.ObtenTecnicosXTipoFASE(UTableroHyP.FaseIni.defDesarmado).ToTable)
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("cboDesarmado"), DropDownList).Visible = False
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("lblDesarmado"), Label).Visible = False
    '    '    CType(gvDMS.Items(i).FindControl("cboDesarmado"), DropDownList).Items.Clear()
    '    '    CType(gvDMS.Items(i).FindControl("cboDesarmado"), DropDownList).Items.Add(New ListItem("--", "--"))
    '    '    For Each k In dv
    '    '        CType(gvDMS.Items(i).FindControl("cboDesarmado"), DropDownList).Items.Add(New ListItem(k("nombre_empleado"), k("id_empleado")))
    '    '    Next


    '    '    dv = New DataView(UTableroHyP.ObtenTecnicosXTipoFASE(UTableroHyP.FaseIni.defMecanica).ToTable)
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("cboMecanico"), DropDownList).Visible = False
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("lblMecanico"), Label).Visible = False
    '    '    CType(gvDMS.Items(i).FindControl("cboMecanico"), DropDownList).Items.Clear()
    '    '    CType(gvDMS.Items(i).FindControl("cboMecanico"), DropDownList).Items.Add(New ListItem("--", "--"))
    '    '    For Each k In dv
    '    '        CType(gvDMS.Items(i).FindControl("cboMecanico"), DropDownList).Items.Add(New ListItem(k("nombre_empleado"), k("id_empleado")))
    '    '    Next

    '    '    dv = New DataView(UTableroHyP.ObtenTecnicosXTipoFASE(UTableroHyP.FaseIni.defAlineacion).ToTable)
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("cboAlineacion"), DropDownList).Visible = False
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("lblAlineacion"), Label).Visible = False
    '    '    CType(gvDMS.Items(i).FindControl("cboAlineacion"), DropDownList).Items.Clear()
    '    '    CType(gvDMS.Items(i).FindControl("cboAlineacion"), DropDownList).Items.Add(New ListItem("--", "--"))
    '    '    For Each k In dv
    '    '        CType(gvDMS.Items(i).FindControl("cboAlineacion"), DropDownList).Items.Add(New ListItem(k("nombre_empleado"), k("id_empleado")))
    '    '    Next

    '    '    dv = New DataView(UTableroHyP.ObtenTecnicosXTipoFASE(UTableroHyP.FaseIni.defPintura).ToTable)
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("cboPintura"), DropDownList).Visible = False
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("lblPintura"), Label).Visible = False
    '    '    CType(gvDMS.Items(i).FindControl("cboPintura"), DropDownList).Items.Clear()
    '    '    CType(gvDMS.Items(i).FindControl("cboPintura"), DropDownList).Items.Add(New ListItem("--", "--"))
    '    '    For Each k In dv
    '    '        CType(gvDMS.Items(i).FindControl("cboPintura"), DropDownList).Items.Add(New ListItem(k("nombre_empleado"), k("id_empleado")))
    '    '    Next

    '    '    dv = New DataView(UTableroHyP.ObtenTecnicosXTipoFASE(UTableroHyP.FaseIni.defPinturaExpress).ToTable)
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("cboPinturaExpress"), DropDownList).Visible = False
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("lblPinturaExpress"), Label).Visible = False
    '    '    CType(gvDMS.Items(i).FindControl("cboPinturaExpress"), DropDownList).Items.Clear()
    '    '    CType(gvDMS.Items(i).FindControl("cboPinturaExpress"), DropDownList).Items.Add(New ListItem("--", "--"))
    '    '    For Each k In dv
    '    '        CType(gvDMS.Items(i).FindControl("cboPinturaExpress"), DropDownList).Items.Add(New ListItem(k("nombre_empleado"), k("id_empleado")))
    '    '    Next

    '    '    dv = New DataView(UTableroHyP.ObtenTecnicosXTipoFASE(UTableroHyP.FaseIni.defpULIDO).ToTable)
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("cboPulido"), DropDownList).Visible = False
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("lblPulido"), Label).Visible = False
    '    '    CType(gvDMS.Items(i).FindControl("cboPulido"), DropDownList).Items.Clear()
    '    '    CType(gvDMS.Items(i).FindControl("cboPulido"), DropDownList).Items.Add(New ListItem("--", "--"))
    '    '    For Each k In dv
    '    '        CType(gvDMS.Items(i).FindControl("cboPulido"), DropDownList).Items.Add(New ListItem(k("nombre_empleado"), k("id_empleado")))
    '    '    Next

    '    '    dv = New DataView(UTableroHyP.ObtenTecnicosXTipoFASE(UTableroHyP.FaseIni.defLavado).ToTable)
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("cboLavado"), DropDownList).Visible = False
    '    '    If dv.Count <= 1 Then CType(gvDMS.Items(i).FindControl("lblLavado"), Label).Visible = False
    '    '    CType(gvDMS.Items(i).FindControl("cboLavado"), DropDownList).Items.Clear()
    '    '    CType(gvDMS.Items(i).FindControl("cboLavado"), DropDownList).Items.Add(New ListItem("--", "--"))
    '    '    For Each k In dv
    '    '        CType(gvDMS.Items(i).FindControl("cboLavado"), DropDownList).Items.Add(New ListItem(k("nombre_empleado"), k("id_empleado")))
    '    '    Next



    '    '    For Each objchip In OBJCOL

    '    '        If objchip.NOORDEN = gvDMS.Items(i).Cells(0).Text Then
    '    '            gvDMS.Items(i).FindControl("divHOrden")

    '    '            CType(gvDMS.Items(i).FindControl("divHOrden"), HtmlGenericControl).Style.Value = "width:" & (ifactorh * inumHoras) & "px;height:60px;background-color:" & UTableroHyP.ObtenColorAsesor(objchip.IDASESOR) & ";Font-weight:bold;font-family:Arial;font-size:11px;border:solid 1px transparent;vertical-align:middle;color:black;"
    '    '            CType(gvDMS.Items(i).FindControl("divHOrden"), HtmlGenericControl).InnerText = objchip.NOPLACAS & vbCrLf & " Orden:" & objchip.NOORDEN
    '    '            CType(gvDMS.Items(i).FindControl("divHOrden"), HtmlGenericControl).Attributes.Add("title", "Cliente: " & objchip.CLIENTE & vbCrLf & "Servicio: " & objchip.SERVICIOCAPTURADO & vbCrLf & "Comentarios: " & objchip.OBSERVACIONES & "")
    '    '            CType(gvDMS.Items(i).FindControl("hOrden"), HtmlInputHidden).Value = objchip.ID & "___" & objchip.NOORDEN & "___" & objchip.NOPLACAS & "___" & objchip.IDSERVICIO & "___" & objchip.COLORPRISMA & "___" & objchip.CLIENTE & "___" & objchip.ASYSRENGLON & "___" & objchip.SERVICIOCAPTURADO & "___" & objchip.HORAASESOR & "___" & objchip.VEHICULO & "___" & objchip.VIN & "___" & objchip.AÑO & "___" & objchip.COLOR & "___" & objchip.IDASESOR & "___" & objchip.TELEFONOS & "___" & objchip.TIPOCLIENTE
    '    '            Exit For
    '    '        End If
    '    '    Next

    '    'Next

    'End Sub
    Protected Sub cmdAgregarTrabajo_Click(ByVal sender As Object, ByVal e As EventArgs)
        '    Try
        '        Dim objChip As New ChipHYP, i As Integer
        '        Dim ColObjChips As New CHIPHYPCollection
        '        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        '        Dim iPosiciones(CType(sender.parent.parent.parent.findcontrol("dgCatTrabajos"), DataGrid).Items.Count - 1) As Integer
        '        Dim iPosiciones2(CType(sender.parent.parent.parent.findcontrol("dgCatTrabajos"), DataGrid).Items.Count - 1) As Integer
        '        Dim sValores() As String = Split(sender.parent.parent.parent.findcontrol("hOrden").value, "___")



        '        For i = 0 To CType(sender.parent.parent.parent.findcontrol("dgCatTrabajos"), DataGrid).Items.Count - 1
        '            iPosiciones2(i) = CInt(CType(CType(sender.parent.parent.parent.findcontrol("dgCatTrabajos"), DataGrid).Items(i).Cells(3).FindControl("cboPosiciones"), DropDownList).SelectedItem.Text)
        '        Next

        '        For i = 0 To iPosiciones2.Length - 1
        '            iPosiciones(iPosiciones2(i)) = i
        '        Next

        '        For i = 0 To iPosiciones.Length - 1

        '            objChip = New ChipHYP
        '            If IsNumeric(CType(CType(sender.parent.parent.parent.findcontrol("dgCatTrabajos"), DataGrid).Items(iPosiciones(i)).Cells(3).FindControl("txtHorasTrabajo"), TextBox).Text) Then
        '                objChip.SERVICIO = CInt(CType(CType(sender.parent.parent.parent.findcontrol("dgCatTrabajos"), DataGrid).Items(iPosiciones(i)).Cells(3).FindControl("txtHorasTrabajo"), TextBox).Text * 60)
        '            Else
        '                objChip.SERVICIO = 0
        '            End If


        '            If CInt(objChip.SERVICIO) > 0 Then
        '                objChip.NOORDEN = sValores(1)
        '                objChip.ASYSRENGLON = sValores(6)
        '                objChip.NOPLACAS = sValores(2)
        '                objChip.IDSERVICIO = CType(sender.parent.parent.parent.findcontrol("dgCatTrabajos"), DataGrid).Items(iPosiciones(i)).Cells(0).Text
        '                objChip.CLIENTE = sValores(5)
        '                objChip.COLORPRISMA = sValores(4)
        '                objChip.SERVICIOCAPTURADO = CType(sender.parent.parent.parent.findcontrol("dgCatTrabajos"), DataGrid).Items(iPosiciones(i)).Cells(2).Text
        '                objChip.OBSERVACIONES = CType(CType(sender.parent.parent.parent.findcontrol("dgCatTrabajos"), DataGrid).Items(iPosiciones(i)).Cells(4).FindControl("txtDescripcion"), TextBox).Text
        '                objChip.HORAASESOR = sValores(8)
        '                objChip.VEHICULO = sValores(9)
        '                objChip.VIN = sValores(10)
        '                objChip.AÑO = sValores(11)
        '                objChip.COLOR = sValores(12)
        '                objChip.IDASESOR = sValores(13)
        '                objChip.TELEFONOS = sValores(14)
        '                objChip.CILINDROS = 0
        '                objChip.TIPOCLIENTE = sValores(15)
        '                objChip.CONCITA = False
        '                objChip.NUMCITA = 0
        '                objChip.CONTINUARA = True
        '                objChip.ENUSO = True
        '                objChip.VHRECEPCION = True
        '                objChip.VHINVENTARIO = True
        '                objChip.VHREPARANDO = False
        '                objChip.VHREPROGRAMADO = False
        '                objChip.VHSERVCANCELADO = False
        '                objChip.VHSERVERMINADO = False
        '                objChip.HORATOLERANCIA = objChip.HORAASESOR
        '                objChip.TIEMPOORIGINAL = objChip.SERVICIO

        '                If objChip.IDSERVICIO = UTableroHyP.FaseIni.defLaminado And CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboILaminero"), DropDownList).SelectedItem.Value <> "--" Then
        '                    ColObjChips = UTableroHyP.ColObtenUltimoxServicioChip(Request.Url.Segments(Request.Url.Segments.Length - 1), inumHoras, iHorai, objChip.IDSERVICIO, objChip.SERVICIO, objChip.NOORDEN, if(IsDate(lblFechaCita.Text) And chkCita.Checked, CDate(lblFechaCita.Text & " " & Request("cboHoraCita")), new date()),CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboILaminero"), DropDownList).SelectedItem.Value  )
        '                ElseIf objChip.IDSERVICIO = UTableroHyP.FaseIni.defAlineacion And CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboAlineacion"), DropDownList).SelectedItem.Value <> "--" Then
        '                    ColObjChips = UTableroHyP.ColObtenUltimoxServicioChip(Request.Url.Segments(Request.Url.Segments.Length - 1), inumHoras, iHorai, objChip.IDSERVICIO, objChip.SERVICIO, objChip.NOORDEN, if(IsDate(lblFechaCita.Text) And chkCita.Checked, CDate(lblFechaCita.Text & " " & Request("cboHoraCita")), new date()),CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboAlineacion"), DropDownList).SelectedItem.Value)
        '                ElseIf objChip.IDSERVICIO = UTableroHyP.FaseIni.defArmado And CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboArmado"), DropDownList).SelectedItem.Value <> "--" Then
        '                    ColObjChips = UTableroHyP.ColObtenUltimoxServicioChip(Request.Url.Segments(Request.Url.Segments.Length - 1), inumHoras, iHorai, objChip.IDSERVICIO, objChip.SERVICIO, objChip.NOORDEN, if(IsDate(lblFechaCita.Text) And chkCita.Checked, CDate(lblFechaCita.Text & " " & Request("cboHoraCita")), new date()),CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboArmado"), DropDownList).SelectedItem.Value)
        '                ElseIf objChip.IDSERVICIO = UTableroHyP.FaseIni.defDesarmado And CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboDesarmado"), DropDownList).SelectedItem.Value <> "--" Then
        '                    ColObjChips = UTableroHyP.ColObtenUltimoxServicioChip(Request.Url.Segments(Request.Url.Segments.Length - 1), inumHoras, iHorai, objChip.IDSERVICIO, objChip.SERVICIO, objChip.NOORDEN, if(IsDate(lblFechaCita.Text) And chkCita.Checked, CDate(lblFechaCita.Text & " " & Request("cboHoraCita")), new date()),CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboDesarmado"), DropDownList).SelectedItem.Value)
        '                ElseIf objChip.IDSERVICIO = UTableroHyP.FaseIni.defMecanica And CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboMecanico"), DropDownList).SelectedItem.Value <> "--" Then
        '                    ColObjChips = UTableroHyP.ColObtenUltimoxServicioChip(Request.Url.Segments(Request.Url.Segments.Length - 1), inumHoras, iHorai, objChip.IDSERVICIO, objChip.SERVICIO, objChip.NOORDEN, if(IsDate(lblFechaCita.Text) And chkCita.Checked, CDate(lblFechaCita.Text & " " & Request("cboHoraCita")), new date()),CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboMecanico"), DropDownList).SelectedItem.Value)
        '                ElseIf objChip.IDSERVICIO = UTableroHyP.FaseIni.defAlistamiento And CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboIAlistador"), DropDownList).SelectedItem.Value <> "--" Then
        '                    ColObjChips = UTableroHyP.ColObtenUltimoxServicioChip(Request.Url.Segments(Request.Url.Segments.Length - 1), inumHoras, iHorai, objChip.IDSERVICIO, objChip.SERVICIO, objChip.NOORDEN, if(IsDate(lblFechaCita.Text) And chkCita.Checked, CDate(lblFechaCita.Text & " " & Request("cboHoraCita")), new date()),CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboIAlistador"), DropDownList).SelectedItem.Value)
        '                ElseIf objChip.IDSERVICIO = UTableroHyP.FaseIni.defPintura And CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboPintura"), DropDownList).SelectedItem.Value <> "--" Then
        '                    ColObjChips = UTableroHyP.ColObtenUltimoxServicioChip(Request.Url.Segments(Request.Url.Segments.Length - 1), inumHoras, iHorai, objChip.IDSERVICIO, objChip.SERVICIO, objChip.NOORDEN,if(IsDate(lblFechaCita.Text) And chkCita.Checked, CDate(lblFechaCita.Text & " " & Request("cboHoraCita")), new date()), CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboPintura"), DropDownList).SelectedItem.Value)
        '                ElseIf objChip.IDSERVICIO = UTableroHyP.FaseIni.defPinturaExpress And CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboPinturaExpress"), DropDownList).SelectedItem.Value <> "--" Then
        '                    ColObjChips = UTableroHyP.ColObtenUltimoxServicioChip(Request.Url.Segments(Request.Url.Segments.Length - 1), inumHoras, iHorai, objChip.IDSERVICIO, objChip.SERVICIO, objChip.NOORDEN,if(IsDate(lblFechaCita.Text) And chkCita.Checked, CDate(lblFechaCita.Text & " " & Request("cboHoraCita")), new date()), CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboPinturaExpress"), DropDownList).SelectedItem.Value)
        '                ElseIf objChip.IDSERVICIO = UTableroHyP.FaseIni.defpULIDO And CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboPulido"), DropDownList).SelectedItem.Value <> "--" Then
        '                    ColObjChips = UTableroHyP.ColObtenUltimoxServicioChip(Request.Url.Segments(Request.Url.Segments.Length - 1), inumHoras, iHorai, objChip.IDSERVICIO, objChip.SERVICIO, objChip.NOORDEN, if(IsDate(lblFechaCita.Text) And chkCita.Checked, CDate(lblFechaCita.Text & " " & Request("cboHoraCita")), new date()),CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboPulido"), DropDownList).SelectedItem.Value)
        '                ElseIf objChip.IDSERVICIO = UTableroHyP.FaseIni.defLavado And CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboLavado"), DropDownList).SelectedItem.Value <> "--" Then
        '                    ColObjChips = UTableroHyP.ColObtenUltimoxServicioChip(Request.Url.Segments(Request.Url.Segments.Length - 1), inumHoras, iHorai, objChip.IDSERVICIO, objChip.SERVICIO, objChip.NOORDEN, if(IsDate(lblFechaCita.Text) And chkCita.Checked, CDate(lblFechaCita.Text & " " & Request("cboHoraCita")), new date()),CType(CType(sender.parent.parent.parent, DataGridItem).FindControl("cboLavado"), DropDownList).SelectedItem.Value)
        '                Else
        '                    ColObjChips = UTableroHyP.ColObtenUltimoxServicioChip(Request.Url.Segments(Request.Url.Segments.Length - 1), inumHoras, iHorai, objChip.IDSERVICIO, objChip.SERVICIO, objChip.NOORDEN,if(IsDate(lblFechaCita.Text) And chkCita.Checked, CDate(lblFechaCita.Text & " " & Request("cboHoraCita")), new date()), Nothing)
        '                End If

        '                For k = 0 To ColObjChips.Count - 1
        '                    objChip = New ChipHYP
        '                    objChip.IDCHIP = TablerosUtils.MaxChip 'por mientras
        '                    objChip.NOORDEN = sValores(1)
        '                    objChip.ASYSRENGLON = sValores(6)
        '                    objChip.NOPLACAS = sValores(2)
        '                    objChip.IDSERVICIO = CType(sender.parent.parent.parent.findcontrol("dgCatTrabajos"), DataGrid).Items(iPosiciones(i)).Cells(0).Text
        '                    objChip.CLIENTE = sValores(5)
        '                    objChip.COLORPRISMA = sValores(4)
        '                    objChip.SERVICIOCAPTURADO = CType(sender.parent.parent.parent.findcontrol("dgCatTrabajos"), DataGrid).Items(iPosiciones(i)).Cells(2).Text
        '                    objChip.OBSERVACIONES = CType(CType(sender.parent.parent.parent.findcontrol("dgCatTrabajos"), DataGrid).Items(iPosiciones(i)).Cells(4).FindControl("txtDescripcion"), TextBox).Text
        '                    objChip.HORAASESOR = sValores(8)
        '                    objChip.VEHICULO = sValores(9)
        '                    objChip.VIN = sValores(10)
        '                    objChip.AÑO = sValores(11)
        '                    objChip.COLOR = sValores(12)
        '                    objChip.IDASESOR = sValores(13)
        '                    objChip.TELEFONOS = sValores(14)
        '                    objChip.CILINDROS = 0
        '                    objChip.TIPOCLIENTE = sValores(15)
        '                    If chkUrgente.Checked Then objChip.TIPOCLIENTE = "Prioridad"
        '                    objChip.CONCITA = False
        '                    objChip.NUMCITA = 0
        '                    objChip.CONTINUARA = True
        '                    objChip.ENUSO = True
        '                    objChip.VHRECEPCION = True
        '                    objChip.VHINVENTARIO = True
        '                    objChip.VHREPARANDO = False
        '                    objChip.VHREPROGRAMADO = False
        '                    objChip.VHSERVCANCELADO = False
        '                    objChip.VHSERVERMINADO = False
        '                    objChip.HORATOLERANCIA = ColObjChips(k).HORAASESOR
        '                    objChip.TIEMPOORIGINAL = ColObjChips(k).SERVICIO
        '                    objChip.HORARECEPCION = ColObjChips(k).HORATOLERANCIA

        '                    objChip.IDTECNICO = ColObjChips(k).idtecnico
        '                    objChip.IDSERVICIO = ColObjChips(k).IDSERVICIO
        '                    objChip.FECHA = ColObjChips(k).fecha



        '                    objChip.SERVICIO = ColObjChips(k).servicio

        '                    If objChip.SERVICIO Is Nothing Then objChip.SERVICIO = 1
        '                    If IsNumeric(objChip.SERVICIO) = False Then objChip.SERVICIO = 1

        '                    objChip.HORACITA = ColObjChips(k).HORACITA
        '                    objChip.FECHAENTREGA = ColObjChips(k).FECHAENTREGA
        '                    objChip.IDTECNICOASI = ColObjChips(k).IDTECNICOASI
        '                    objChip.HORARAMPA = ColObjChips(k).HORARAMPA
        '                    objChip.NOMBREDIA = ColObjChips(k).NOMBREDIA
        '                    objChip.FECHAAGENDADO = ColObjChips(k).FECHAAGENDADO
        '                    objChip.FECHAORIGINAL = ColObjChips(k).FECHAORIGINAL
        '                    objChip.HORAENTREGA = ColObjChips(k).HORAENTREGA



        '                    objChip.STATUS = "Pendiente"
        '                    objChip.STATUSOS = "ABIERTA"
        '                    objChip.USUARIO = HttpContext.Current.Session("sUser")

        '                    objChip.OCHIP = "dg" & objChip.SERVICIO & objChip.IDCHIP

        '                    If Validar(objChip, "G") Then
        '                        If objChip.SERVICIO > 0 Then

        '                            UTableroHyP.GuardarChip(objChip)

        '                        End If

        '                    Else


        '                        Exit For
        '                    End If
        '                Next
        '            End If
        '        Next

        '    Catch ex As Exception
        '        System.IO.File.AppendAllText(BDClass.sErrLogs & "Err_exquery.txt", vbCrLf & ex.ToString & vbCrLf)
        '    End Try
        '    limpiaform()
        '    bref = True
        '    sITablero()
        '    PINTACHIPS()
    End Sub



    'Protected Sub imgbtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnBuscar.Click

    '    ' buscadms(txtbuscar.Text.Trim)
    'End Sub

    'Private Sub imgbtnBuscarCita_Click(sender As Object, e As ImageClickEventArgs) Handles imgbtnBuscarCita.Click
    '    ' buscadmsCita(txtbuscarCita.Text.Trim)
    'End Sub
End Class