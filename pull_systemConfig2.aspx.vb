Imports TablerosV2LibTypes
Partial Public Class pull_systemConfig2
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
        Dim sqry As String, i As Integer
        Dim dt As New DataTable, dtPos As New DataTable


        Dim objCHIPCol As New CHIPPullCollection
        Dim objCHIP As New ChipPull
        sqry = "SELECT * FROM pullconfig"
        dtPos = BDClass.SQLtoDataTable(sqry, False)
        'Me.form1.Style.Remove("background-image")
        'Me.form1.Style.Add("background-image", dtPos.Rows(0).Item(0))


        Session("PullConfig") = dtPos
        sqry = "SELECT idFicha, fichaTop, fichaLeft, IMGCCITA, IMGSCITA FROM TB_CHIP_PULL where nivel=" & iiNivel & ""
        dtPos = BDClass.SQLtoDataTable(sqry, False)



        Dim sColor As String, iNivel As Integer = 0
        Dim imgLst As New ArrayList()

        For i = 0 To dtPos.Rows.Count - 1
            objCHIP = New ChipPull

            objCHIP.IDFICHA = dtPos.Rows(i)(0)
            objCHIP.FICHATOP = dtPos.DefaultView(i)(1)
            objCHIP.FICHALEFT = dtPos.DefaultView(i)(2)
            objCHIP.IMGCC = dtPos.DefaultView(i)(3)
            objCHIP.IMGSC = dtPos.DefaultView(i)(4)
            objCHIP.CONCITA = True
            sColor = "#000000"
            objCHIPCol.Add(objCHIP)
            imgLst.Add(objCHIP.IDFICHA)
            chipBoard(i, objCHIP, sColor)
        Next
        Session("imgLst") = imgLst
    End Sub

    Function imageCHIP(ByVal sChip As String, ByVal obj As ChipPull, ByRef stext As String, ByRef sTecnico As String, ByRef sLeft As String, ByRef sstop As String, ByRef btecnico As Boolean) As String
        btecnico = False
        stext = obj.IDFICHA
        sTecnico = ""

        Select Case sChip
            Case Is = "h"
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"

                'sTecnico = TablerosUtils.ObtenNombreTecnicos(obj.IDTECNICO)
                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If
            Case Is = "r"
                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"

                'sTecnico = TablerosUtils.ObtenNombreTecnicos(obj.IDTECNICO)
                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If
            Case Is = "g"
                'stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"

                'sTecnico = TablerosUtils.ObtenNombreTecnicos(obj.IDTECNICO)
                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If

            Case Is = "f"
                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"

                'sTecnico = TablerosUtils.ObtenNombreTecnicos(obj.IDTECNICO)
                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If
            Case Is = "x"
                'stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"

                ' sTecnico = TablerosUtils.ObtenNombreTecnicos(obj.IDTECNICO)
                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If
            Case Is = "k"
                'stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"

                ' sTecnico = TablerosUtils.ObtenNombreTecnicos(obj.IDTECNICO)
                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If
            Case Is = "q"

                'stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"

                ' sTecnico = TablerosUtils.ObtenNombreTecnicos(obj.IDTECNICO)
                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If
            Case Is = "l"
                ' stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"

                'sTecnico = TablerosUtils.ObtenNombreTecnicos(obj.IDTECNICO)
                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If
            Case Is = "w"
                ' stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"

                ' sTecnico = TablerosUtils.ObtenNombreTecnicos(obj.IDTECNICO)
                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If
            Case Is = "z"
                'stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"

                ' sTecnico = TablerosUtils.ObtenNombreTecnicos(obj.IDTECNICO)
                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If
            Case Is = "t"
                ' stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT - 40) & "px"
                sstop = (obj.FICHATOP) & "px"

                ' sTecnico = TablerosUtils.ObtenNombreTecnicos(obj.IDTECNICO)
                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If

            Case Is = "b"
                ' stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"

                sTecnico = TablerosUtilsHyP.ObtenNombreTecnicos(obj.IDTECNICO)
                btecnico = True
                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If

            Case Else
                ' stext = obj.NOORDEN
                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"

                If obj.CONCITA Then
                    imageCHIP = obj.IMGCC
                Else
                    imageCHIP = obj.IMGSC
                End If
        End Select

        Return imageCHIP

    End Function
    Sub chipBoard(ByVal numberChip As Integer, ByVal obj As ChipPull, ByVal sColor As String)


        Dim sDiv, sWidth, sHeight, sImageChip, stext, sTecnico, sLeft, ssHeight As String
        Dim bTecnico As Boolean
        sDiv = "ds" & String.Format("{0:000}", numberChip)


        sImageChip = imageCHIP(Left(obj.IDFICHA, 1), obj, stext, sTecnico, sLeft, ssHeight, bTecnico)

        sWidth = "46px"
        sHeight = "46px"

        displayChip(numberChip, obj.IDFICHA, obj.FICHALEFT & "px", obj.FICHATOP & "px", sWidth, sHeight, sImageChip, sColor, stext, sTecnico, sLeft, ssHeight, bTecnico)




    End Sub
    Sub displayChip(ByVal iItem As Integer, ByVal sDiv As String, ByVal sL As String, ByVal sT As String, ByVal sWidth As String, ByVal sHeight As String, ByVal sImageChip As String, ByVal sColor As String, ByVal stext As String, ByVal sTecnico As String, ByVal sleftTexto As String, ByVal stopTexto As String, ByVal btecnico As Boolean)


        Dim iDiv As Integer
        Dim lbl1 As String

        iDiv = Val(Right(sDiv, 3))
        lbl1 = "lb" & Right(sDiv, 3) & "1"

        Dim ixImg As New HtmlGenericControl("div")
        ixImg.ID = sDiv
        'ixImg.Src = sImageChip
        'ixImg.Style.Add("background-image", "url(" & sImageChip & ")")
        ixImg.Style.Add("position", "absolute")
        ixImg.Style.Add("draggable", "true")
        ixImg.Style.Add("border", "solid 3px " & sColor)
        ixImg.Style.Add("Left", sL)
        ixImg.Style.Add("top", sT)
        ixImg.Style.Add("cursor", "hand")

        ixImg.Attributes.Add("ondblclick", "Location('" & ixImg.ID & "')")
        If InStr(sImageChip, "h_l.") > 0 Then
            ixImg.InnerHtml = "<img src='" & sImageChip & "' class='imgdivH'/>"

        Else
            ixImg.InnerHtml = "<img src='" & sImageChip & "' class='imgdivV'/>"
        End If



        'ixImg.Attributes.Add("ondrop", "LocationDrop('" & ixImg.ID & "')")
        ' ixImg.Attributes.Add("ondrop", "javascript:alert('event has been triggered');")



        Dim ixdivTec As New HtmlGenericControl("div")
        ixdivTec.ID = "ctlTec_" & sDiv
        Dim ixdivBahia As New HtmlGenericControl("div")
        ixdivBahia.ID = "ctlTecBahia_" & sDiv

        Dim ixdiv As New HtmlGenericControl("div")
        ixdiv.ID = "ctl_" & sDiv


        ixdiv.Style.Add("Left", sleftTexto)
        ixdiv.Style.Add("top", stopTexto)
        ' ixdiv.Style.Add("width", "35px")
        'ixdiv.Style.Add("height", "23px")
        ixdiv.Style.Add("position", "absolute")
        ixdiv.Style.Add("border-top-style", "solid")
        ixdiv.Style.Add("border-top-color", sColor)
        ixdiv.Style.Add("border-bottom-color", sColor)
        ixdiv.Style.Add("clear", "none")
        ixdiv.Style.Add("z-index", "1500")
        'ixdiv.Style.Add("font-size", "10px")
        ' ixdiv.Style.Add("text-align", "center")
        'ixdiv.Style.Add("background-position", "left top")
        'ixdiv.Style.Add("background-color", "gainsboro")
        ixdiv.InnerText = Left(stext, Fix(stext.Length / 2)) & " " & Right(stext, System.Math.Round(stext.Length / 2))
        ixdiv.Attributes.Add("class", "textdiv")

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
        ixdivBahia.Style.Add("top", (Val(stopTexto) - 30) & "px")
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


        Me.form1.Controls.Add(ixImg)
        Me.form1.Controls.Add(ixdiv)
        If btecnico Then
            Me.form1.Controls.Add(ixdivTec)
            '  Me.form1.Controls.Add(ixdivBahia)
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
        'If InStr(Page.AppRelativeVirtualPath, Session("URL")) = 0 Or Session("URL") Is Nothing Then Response.Redirect("Inicio.aspx")

        If Not Page.IsPostBack Then
            PINTACHIPS(lstNivel.SelectedItem.Value)
        End If


        'MOSTRARRESUMEN()

        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If InStr(sdhtml, "Trash") > 0 Then
            EliminarChip(sdhtml)
        ElseIf InStr(sdhtml, "Update") > 0 Then
            If InStr(sdhtml, "Horizontal") > 0 Or InStr(sdhtml, "Vertical") > 0 Then
                GuardaChip(sdhtml)
            Else
                ActualizaChip(sdhtml)
            End If

        ElseIf InStr(sdhtml, "dchp") > 0 Then
            PINTACHIPS(lstNivel.SelectedItem.Value)
        ElseIf sdhtml.Length = 3 Then
            PINTACHIPS(lstNivel.SelectedItem.Value)
        End If
        'If sdhtml.Length = 3 Then
        '    dchp.Visible = True
        '    AbrirChip(sdhtml)

        'Else
        '    dchp.Visible = False
        'End If
    End Sub
    Sub GuardaChip(ByVal sChip As String)

        Dim sqry As String
        Dim dt As New DataTable
        Dim sImg As String = Split(sChip, ".")(1)
        Dim sImgCC As String = ""
        Dim sImgSC As String = ""
        Dim sIdFicha As String = "", idFicha As Integer, ibahia As Integer = 0
        Select Case sImg
            Case "HorizontalChip"
                Select Case cboColorChip.SelectedItem.Value
                    Case "Red"
                        sImgSC = "img/pullsystemtoyota/v_blue_h_l.png"
                        sImgCC = "img/pullsystemtoyota/v_red_h_l.png"
                    Case "Blue"
                        sImgCC = "img/pullsystemtoyota/v_blue_h_l.png"
                        sImgSC = "img/pullsystemtoyota/v_red_h_l.png"
                End Select

            Case "VerticalChip"
                Select Case cboColorChip.SelectedItem.Value
                    Case "Red"
                        sImgSC = "img/pullsystemtoyota/v_blue_v_l.png"
                        sImgCC = "img/pullsystemtoyota/v_red_v_l.png"
                    Case "Blue"
                        sImgCC = "img/pullsystemtoyota/v_blue_v_l.png"
                        sImgSC = "img/pullsystemtoyota/v_red_v_l.png"
                End Select

        End Select

        sIdFicha = cboChips.SelectedItem.Value


        sqry = "SELECT max(CONVERT(INT,right(idficha,2))) FROM TB_CHIP_PULL WHERE  LEFT(idficha,1)='" & sIdFicha & "'"
        dt = BDClass.SQLtoDataTable(sqry, False)

        If CInt(IIf(dt.Rows(0).Item(0) Is DBNull.Value, 0, dt.Rows(0).Item(0).ToString)) = 0 Then
            idFicha = 1
        Else
            idFicha = CInt(dt.Rows(0).Item(0).ToString) + 1
        End If

        If sIdFicha = "b" Then
            sqry = "SELECT isnull(max(bahia),0) FROM TB_CHIP_PULL WHERE  LEFT(idficha,1)='" & sIdFicha & "'"
            dt = BDClass.SQLtoDataTable(sqry, False)

            If CInt(dt.Rows(0).Item(0).ToString) = 0 Then
                ibahia = 1
            Else
                ibahia = CInt(dt.Rows(0).Item(0).ToString) + 1
            End If
            sqry = "insert into TB_CHIP_PULL(idFicha, FichaLeft, FichaTop,imgCCita,imgSCita, bahia, nivel) values ('" & sIdFicha & String.Format("{0:00}", idFicha) & "'," & Split(sChip, ".")(2) & " ," & Split(sChip, ".")(3) & ",'" & sImgCC & "','" & sImgSC & "'," & ibahia & ", " & cboNivel.SelectedItem.Value & ")"
            BDClass.ExecuteQuery(sqry, False)

        Else
            sqry = "insert into TB_CHIP_PULL(idFicha, FichaLeft, FichaTop,imgCCita,imgSCita, nivel) values ('" & sIdFicha & String.Format("{0:00}", idFicha) & "'," & Split(sChip, ".")(2) & " ," & Split(sChip, ".")(3) & ",'" & sImgCC & "','" & sImgSC & "'," & cboNivel.SelectedItem.Value & ")"
            BDClass.ExecuteQuery(sqry, False)

        End If




        Select Case cboColorChip.SelectedItem.Value
            Case "Red"
                sqry = "UPDATE   TB_CHIP_PULL SET imgCCita='img/v_red_v_l.gif',imgSCita='img/v_blue_v_l.gif' where imgccita='img/v_blue_v_l.gif' or imgccita='img/v_red_v_l.gif'"
                BDClass.ExecuteQuery(sqry, False)
                sqry = "UPDATE   TB_CHIP_PULL SET imgCCita='img/v_red_h_l.gif',imgSCita='img/v_blue_h_l.gif' where imgccita='img/v_blue_h_l.gif' or imgccita='img/v_red_h_l.gif'"
                BDClass.ExecuteQuery(sqry, False)

            Case "Blue"
                sqry = "UPDATE   TB_CHIP_PULL SET imgCCita='img/v_blue_v_l.gif',imgSCita='img/v_red_v_l.gif' where imgccita='img/v_blue_v_l.gif' or imgccita='img/v_red_v_l.gif'"
                BDClass.ExecuteQuery(sqry, False)
                sqry = "UPDATE   TB_CHIP_PULL SET imgCCita='img/v_blue_h_l.gif',imgSCita='img/v_red_h_l.gif' where imgccita='img/v_blue_h_l.gif' or imgccita='img/v_red_h_l.gif'"
                BDClass.ExecuteQuery(sqry, False)
        End Select

        PINTACHIPS(lstNivel.SelectedItem.Value)

    End Sub
    Sub ActualizaChip(ByVal sChip As String)

        Dim sqry As String
        Dim dt As New DataTable



        sqry = "update TB_CHIP_PULL set fichaLeft=" & Split(sChip, ".")(2) & " , fichaTop=" & Split(sChip, ".")(3) & ", nivel=" & cboNivel.SelectedItem.Value & " where idFicha='" & Split(sChip, ".")(1) & "'"
        BDClass.ExecuteQuery(sqry, False)
        PINTACHIPS(lstNivel.SelectedItem.Value)

    End Sub
    Sub EliminarChip(ByVal sChip As String)

        Dim sqry As String
        Dim dt As New DataTable



        sqry = "delete TB_CHIP_PULL where idFicha='" & Split(sChip, ".")(1) & "'"
        BDClass.ExecuteQuery(sqry, False)
        PINTACHIPS(lstNivel.SelectedItem.Value)

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



        'sqry = "select distinct noPlacas Placa, conCita, noOrden, Fecha_Hora_ini_Oper, fecha_Hora_Fin_Oper, Status, Cliente " _
        '                                        & "  from  dbo.TYT_LV_TBL_CONTROL_CITAS " _
        '                                        & " where Year(fecha) = year(getdate())  And Month(fecha) =  Month(getdate()) And Day(fecha) =day(getdate())  " _
        '                                        & "   and servicioCapturado <> 'Lavado' and ConCita=1 and noOrden<>0  and vhRecepcion=0"

        sqry = "select distinct a.noPlacas Placa, a.conCita, a.noOrden, a.Cliente,a.ColorPrisma  " _
                                                  & "  from  dbo.TYT_LV_TBL_CONTROL_CITAS a  inner join dbo.TYT_LV_TBL_CONTROL_CITAS_HEADER b on a.vin=b.vin " _
                                                  & " where Year(a.fecha) = year(getdate()) And Month(a.fecha) = Month(getdate()) And Day(a.fecha) =  day(getdate()) " _
                                                  & "   and a.ConCita=1 and a.numcita<>0 and a.Fecha_Hora_ini_Oper is null and b.HoraIEntrega is null and (not b.HoraFRecepcion is null)" _
                                                   & "   union all" _
           & "   ( select distinct a.noPlacas Placa, 0 as conCita, a.noOrden, a.Cliente, a.ColorPrisma  from dbo.TYT_LV_TBL_CONTROL_CITAS a inner join dbo.TYT_LV_TBL_CONTROL_CITAS_HEADER b   on a.vin=b.vin   inner join TYT_LV_TBL_CONTROL_CITAS_HEADER_RECEPCION c on c.noPlacas=b.noplacas " _
           & "    where  Year(a.fecha) = year(getdate()) And Month(a.fecha) =  Month(getdate()) And Day(a.fecha) = day(getdate())  and a.Fecha_Hora_ini_Oper is null  and c.HoraIEntrega is null and (not c.HoraFRecepcion is null) )"


        sqry = "select distinct noPlacas Placa, conCita, noOrden,  Cliente " _
                                               & "  from  dbo.TYT_LV_TBL_CONTROL_CITAS_header " _
                                               & " where Year(fecha) = year(getdate())  And Month(fecha) =  Month(getdate()) And Day(fecha) =  day(getdate()) " _
                                               & "      and (horaIRecepcion is null) and (not horaLlegada is null) and ( horaretiro is null) " _
         & "   union all" _
         & "   (select distinct noPlacas Placa, 0 as conCita, '0' as noOrden, Cliente from dbo.TYT_LV_TBL_CONTROL_CITAS_HEADER_RECEPCION" _
         & "    where  Year(fecha) = year(getdate())  And Month(fecha) =  Month(getdate()) And Day(fecha) =  day(getdate())  and (horaIRecepcion is null) and (not horaLlegada is null) and ( horaretiro is null) )"


        dt = BDClass.SQLtoDataTable(sqry, False)
        ienespera = dt.Rows.Count

        Dim SCONTROL As String
        SCONTROL = "<div style='visible:display;border:none;background-color:transparent;position:absolute;top:0px;left:890px;width:300px;height:100px;'>"
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

        Response.Redirect("Inicio.aspx")
    End Sub

    Private Sub pull_systemConfig_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        Dim OBJARRAY As ArrayList = CType(Session("imgLst"), ArrayList)
        'OBJARRAY.Add("ds00")
        OBJARRAY.Add("HorizontalChip")
        OBJARRAY.Add("VerticalChip")
        OBJARRAY.Add("imgTrash")
        OBJARRAY.Add("divInterfaz")
        Dim va_Enumerator As System.Collections.IEnumerator = OBJARRAY.GetEnumerator()
        Dim sScript As String = ""
        sScript += "" & vbCrLf
        sScript += "" & vbCrLf
        sScript += " SET_DHTML("
        While va_Enumerator.MoveNext()

            sScript += "" & Chr(34) & va_Enumerator.Current & Chr(34) & "+RESIZABLE, "

        End While
        sScript = Left(sScript, Len(sScript) - 2)
        sScript += ");" & vbCrLf
        sScript += "" & vbCrLf
        sScript += "" & vbCrLf
        scrmgr1.RegisterStartupScript(Me, Page.GetType, "TabGraphDHTML", sScript, True)
        If dchp.Visible Then
            scrmgr1.RegisterStartupScript(Me, Page.GetType, "dchpFocus", "document.getElementById('dchp').focus();", True)
        End If
    End Sub
    Protected Sub cmdCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCargar.Click

        If Trim(System.IO.Path.GetFileName(Me.txtArchivo.PostedFile.FileName)) = "" Then Exit Sub
        Me.txtArchivo.PostedFile.SaveAs(Page.Request.PhysicalApplicationPath & "img\toyota_cn_servicio_8B.png")
        '   Me.txtArchivo.PostedFile.SaveAs(Page.Request.PhysicalApplicationPath & Replace(CType(Session("PullConfig"), DataTable).Rows(0).Item(0), "/", "\"))
        PINTACHIPS(lstNivel.SelectedItem.Value)
    End Sub


    Protected Sub lstNivel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNivel.SelectedIndexChanged
        nBody.Style.Remove("background-image")
        Select Case lstNivel.SelectedItem.Value
            Case "0"
                nBody.Style.Add("background-image", "url(img/PullSystemToyota/View1.png)")
            Case "1"
                nBody.Style.Add("background-image", "url(img/PullSystemToyota/View2.png)")
            Case "2"
                nBody.Style.Add("background-image", "url(img/PullSystemToyota/View3.png)")
        End Select
        'style="background-image: url(img/toyota_cn_servicio_8B.PNG);"
        PINTACHIPS(lstNivel.SelectedItem.Value)
    End Sub
End Class
