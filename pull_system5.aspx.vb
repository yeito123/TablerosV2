Imports TablerosV2LibTypes
Partial Public Class pull_system5
    Inherits System.Web.UI.Page


    Sub PINTACHIPS()
        Dim OBJCOL As New CHIPPullCollection, objchip As ChipPull, bAlarm As Boolean, sMsgAlarm As String = ""
        Dim sColor As String, oChip As String, iNivel As Integer = 0
        Dim imgLst As New ArrayList(), y 
        OBJCOL = OBJCOL.ObtenChips3()
        Session("ColPullChips") = OBJCOL
        For i = 1 To OBJCOL.Count
            Try


                objchip = OBJCOL.Item(i - 1)
                sColor = TablerosUtilsHyP.ObtenColorAsesor(objchip.IDASESOR)
                oChip = Left(objchip.OCHIP, 2)

                bAlarm = False
                sMsgAlarm = ""

                If objchip.taginfo.Trim.Length = 0 Then

                    If Not objchip.CHIPOP Is Nothing Then
                        If CDate(objchip.CHIPOP.FECHA.ToShortDateString & " " & objchip.CHIPOP.HORACITA) <= Date.Now And objchip.CHIPOP.STATUS.ToLower = "pendiente" And objchip.CHIPOP.SERVICIOCAPTURADO <> "Lavado" Then
                            bAlarm = True
                            sMsgAlarm = "Retrasado para iniciar"
                        ElseIf CDate(objchip.CHIPOP.FECHA.ToShortDateString & " " & objchip.CHIPOP.HORACITA).AddMinutes(CInt(objchip.CHIPOP.SERVICIO)) <= Date.Now And objchip.CHIPOP.STATUS.ToLower = "iniciada" And objchip.CHIPOP.SERVICIOCAPTURADO <> "Lavado" Then
                            bAlarm = True
                            sMsgAlarm = "Retrasado para finalizar"
                        ElseIf DateDiff(DateInterval.Minute, CDate(objchip.CHIPOP.FECHA.ToShortDateString & " " & objchip.CHIPOP.HORACITA), Date.Now) > 45 And objchip.CHIPOP.STATUS.ToLower = "en lavado" And objchip.CHIPOP.SERVICIOCAPTURADO = "Lavado" Then
                            bAlarm = True
                            sMsgAlarm = "Retrasado para Lavar"
                        ElseIf DateDiff(DateInterval.Day, CDate(objchip.CHIPOP.FECHA.ToShortDateString & " " & objchip.CHIPOP.HORACITA), Date.Now) > 45 And objchip.CHIPOP.STATUS.ToLower = "detenida" And objchip.CHIPOP.SERVICIOCAPTURADO <> "Lavado" Then
                            bAlarm = True
                            sMsgAlarm = "Detenido por mas de 5 dias"
                        End If
                    End If

                    Select Case Left(objchip.IDFICHA, 1)
                        Case "y"

                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("y"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("y") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ESTATUS</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y
                                If InStr(objchip.taginfo, "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.STATUSOS & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>") = 0 Then
                                    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.STATUSOS & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>"

                                End If
                            Next
                            objchip.taginfo += "</table>"

                        Case "v"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("v"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("v") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ESTATUS</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y
                                If InStr(objchip.taginfo, "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.STATUSOS & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>") = 0 Then
                                    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.STATUSOS & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>"

                                End If
                            Next
                            objchip.taginfo += "</table>"

                        Case "u"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("u"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("u") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ESTATUS</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y

                                If InStr(objchip.taginfo, "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.STATUSOS & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>") = 0 Then
                                    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.STATUSOS & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>"

                                End If
                            Next
                            objchip.taginfo += "</table>"
                        Case "m"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("m"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("m") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS TERMINADO</td><td align=center>ASESOR</td></tr>"
                            For Each p As ChipPull In y
                                objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td></tr>"
                            Next
                            objchip.taginfo += "</table>"
                        Case "q"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("q"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("q") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y
                                objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td><td>" & p.CHIPOP.SERVICIOCAPTURADO & "</td></tr>"
                            Next
                            objchip.taginfo += "</table>"
                        Case "a"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("a"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("a") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y
                                'If p.CHIPOP Is Nothing Then
                                '    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>--</td></tr>"

                                'Else
                                objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>"

                                ' End If
                            Next
                            objchip.taginfo += "</table>"
                        Case "g"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("g"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("g") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y
                                objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td><td>" & p.CHIPOP.SERVICIOCAPTURADO & "</td></tr>"
                            Next
                            objchip.taginfo += "</table>"
                        Case "e"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("e"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("e") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y
                                'If p.CHIPOP Is Nothing Then
                                '    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>--</td></tr>"

                                'Else
                                objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>"

                                ' End If
                            Next
                            objchip.taginfo += "</table>"
                        Case "f"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("f"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("f") Select (p.noplacas)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>PLACAS</td><td align=center>MODELO</td><td align=center>DIAS</td><td align=center>VEHICULO</td></tr>"
                            For Each p As ChipPull In y
                                'If p.CHIPOP Is Nothing Then
                                '    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>--</td></tr>"

                                'Else
                                objchip.taginfo += "<tr><td>" & p.NOPLACAS & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.VEHICULO & "</td></tr>"

                                ' End If
                            Next
                            objchip.taginfo += "</table>"
                            'Case "h"
                            '    y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("h"))
                            '    objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("h") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            '    objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            '    For Each p As ChipPull In y
                            '        'If p.CHIPOP Is Nothing Then
                            '        '    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>--</td></tr>"

                            '        'Else
                            '        objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>"

                            '        ' End If
                            '    Next
                            '    objchip.taginfo += "</table>"
                        Case "s"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("s"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("s") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y
                                'If p.CHIPOP Is Nothing Then
                                '    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>--</td></tr>"

                                'Else
                                objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>"

                                ' End If
                            Next
                            objchip.taginfo += "</table>"
                        Case "i"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("i"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("i") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y
                                'If p.CHIPOP Is Nothing Then
                                '    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>--</td></tr>"

                                'Else
                                objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>"

                                ' End If
                            Next
                            objchip.taginfo += "</table>"
                        Case "x"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("x"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("x") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ASESOR</td><td align=center>SERVICIO</td><td align=center>REFACCION</td></tr>"
                            For Each p As ChipPull In y
                                'If p.CHIPOP Is Nothing Then
                                '    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>--</td></tr>"

                                'Else
                                objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td><td>" & p.OBSERVACIONES & "</td></tr>"

                                ' End If
                            Next
                            objchip.taginfo += "</table>"
                        Case "o"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("o"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("o") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            'objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("p") Select p.NOORDEN.Distinct).Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y
                                'If p.CHIPOP Is Nothing Then
                                '    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>--</td></tr>"

                                'Else
                                objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>"

                                ' End If
                            Next
                            objchip.taginfo += "</table>"
                        Case "j"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("j"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("j") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y
                                objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>"
                            Next
                            objchip.taginfo += "</table>"
                        Case "p"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("p"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("p") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y
                                'If p.CHIPOP Is Nothing Then
                                '    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>--</td></tr>"

                                'Else
                                objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td><td>" & p.SERVICIOCAPTURADO & "</td></tr>"

                                ' End If
                            Next
                            objchip.taginfo += "</table>"
                        Case "n"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("n"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("n") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ASESOR</td><td align=center>SERVICIO</td></tr>"
                            For Each p As ChipPull In y
                                objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td><td>" & p.CHIPOP.SERVICIOCAPTURADO & "</td></tr>"
                            Next
                            objchip.taginfo += "</table>"
                        Case "f"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("f"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("f") Select (p.noplacas)).Distinct.Count
                            objchip.taginfo = "</table><tr><td align=center>PLACAS</td><td align=center>MODELO</td><td align=center>DIAS DE ESPERA</td></tr> "
                            For Each p As ChipPull In y
                                objchip.taginfo += "<tr><td>" & p.NOPLACAS & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHA, Date.Now) & "</td></tr>"
                            Next
                            objchip.taginfo += "</table>"
                        Case "l"
                            y = (From p In OBJCOL Where p.IdFicha.ToString.StartsWith("l"))
                            objchip.STATUS = "" & (From p In OBJCOL Where p.IDFICHA.ToString.StartsWith("l") Select Int32.Parse(p.NOORDEN)).Distinct.Count
                            objchip.taginfo = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS DETENIDO</td><td align=center>ASESOR</td></tr>"
                            Try

                                For Each p As ChipPull In y
                                    objchip.taginfo += "<tr><td>" & p.NOORDEN & "</td><td>" & p.VEHICULO & "</td><td  align=center>" & DateDiff(DateInterval.Day, p.FECHAHORAFINOPER, Date.Now) & "</td><td>" & p.IDASESOR & "</td></tr>"
                                Next
                                objchip.taginfo += "</table>"
                            Catch ex As Exception
                                If System.IO.Directory.Exists(BDClass.sErrLogs) Then
                                    System.IO.File.AppendAllText(BDClass.sErrLogs & "Err_exquery.txt", vbCrLf & ex.ToString & vbCrLf & vbCrLf)

                                End If
                            End Try

                    End Select


                    imgLst.Add("ds" & String.Format("{0:000}", i))

                    chipBoard(i, objchip, sColor, bAlarm, sMsgAlarm)

                End If
            Catch ex As Exception

            End Try
        Next
        Session("imgLst") = imgLst
    End Sub
    Function imageCHIP(ByVal sChip As String, ByVal obj As ChipPull, ByRef stext As String, ByRef sTecnico As String, ByRef sLeft As String, ByRef sstop As String, ByRef btecnico As Boolean) As String
        btecnico = False

        sTecnico = ""
        If obj.NUMCITA <> 0 Then
            imageCHIP = obj.IMGCC
        Else
            imageCHIP = obj.IMGSC
        End If
        stext = obj.CAMPOMOSTRAR

        'If obj.ESBAHIA Then
        '    sTecnico = TablerosUtils.ObtenNombreTecnicos(obj.CHIPOP.IDTECNICO)
        '    btecnico = obj.ESBAHIA
        'End If

        Select Case sChip
            Case Is = "h"
                sLeft = (obj.FICHALEFT + 48) & "px"
                sstop = (obj.FICHATOP) & "px"
            Case Is = "s"
                sLeft = (obj.FICHALEFT + 48) & "px"
                sstop = (obj.FICHATOP) & "px"
            Case Is = "i"
                sLeft = (obj.FICHALEFT + 48) & "px"
                sstop = (obj.FICHATOP) & "px"
            Case Is = "m"
                sLeft = (obj.FICHALEFT + 48) & "px"
                sstop = (obj.FICHATOP) & "px"

            Case Is = "j"
                sLeft = (obj.FICHALEFT + 48) & "px"
                sstop = (obj.FICHATOP) & "px"

            Case Is = "r"
                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"

            Case Is = "g"

                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"

            Case Is = "f"
                sLeft = (obj.FICHALEFT + 48) & "px"
                sstop = (obj.FICHATOP) & "px"

            Case Is = "x"

                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"
            Case Is = "o"

                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"
            Case Is = "p"

                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"
            Case Is = "a"

                sLeft = (obj.FICHALEFT + 48) & "px"
                sstop = (obj.FICHATOP) & "px"

            Case Is = "k"

                sLeft = (obj.FICHALEFT - 35) & "px"
                sstop = (obj.FICHATOP) & "px"

            Case Is = "q"


                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"

            Case Is = "l"

                sLeft = (obj.FICHALEFT - 35) & "px"
                sstop = (obj.FICHATOP) & "px"

            Case Is = "w"

                sLeft = (obj.FICHALEFT - 35) & "px"
                sstop = (obj.FICHATOP) & "px"


            Case Is = "z"

                sLeft = (obj.FICHALEFT - 35) & "px"
                sstop = (obj.FICHATOP) & "px"
            Case Is = "t"

                sLeft = (obj.FICHALEFT - 35) & "px"
                sstop = (obj.FICHATOP) & "px"

            Case Is = "b"

                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"

            Case Is = "u"

                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"
            Case Is = "v"

                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"
            Case Is = "y"

                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"
            Case Is = "e"

                sLeft = (obj.FICHALEFT) & "px"
                sstop = (obj.FICHATOP + 48) & "px"

        End Select



        Return imageCHIP

    End Function
    Sub chipBoard(ByVal numberChip As Integer, ByVal obj As ChipPull, ByVal sColor As String, bAlarm As Boolean, sMsgAlarm As String)


        Dim sDiv, sWidth, sHeight, sImageChip, stext, sTecnico, sLeft, ssHeight As String
        Dim bTecnico As Boolean
        sDiv = "ds" & String.Format("{0:000}", numberChip)


        sImageChip = imageCHIP(Left(obj.IDFICHA, 1), obj, stext, sTecnico, sLeft, ssHeight, bTecnico)

        sWidth = "46px"
        sHeight = "46px"

        displayChip(numberChip, obj.IDFICHA, obj.FICHALEFT & "px", obj.FICHATOP & "px", sWidth, sHeight, sImageChip, sColor, stext, sTecnico, sLeft, ssHeight, bTecnico, obj, bAlarm, sMsgAlarm)




    End Sub
    Sub displayChip(ByVal iItem As Integer, ByVal sDiv As String, ByVal sL As String, ByVal sT As String, ByVal sWidth As String, ByVal sHeight As String, ByVal sImageChip As String, ByVal sColor As String, ByVal stext As String, ByVal sTecnico As String, ByVal sleftTexto As String, ByVal stopTexto As String, ByVal btecnico As Boolean, ByVal objChip As ChipPull, ByVal bAlarm As Boolean, sMsgAlarm As String)


        Dim iDiv As Integer
        Dim lbl1 As String, sComentarios As String

        Select Case Left(sDiv, 1)

            Case "h"
                sComentarios = "Vehiculo: " & objChip.VEHICULO & vbCrLf & " Placas: " & objChip.NOPLACAS & vbCrLf & "   Cliente: " & objChip.CLIENTE

            Case "s"
                sComentarios = "Vehiculo: " & objChip.VEHICULO & vbCrLf & " Placas: " & objChip.NOPLACAS & vbCrLf & "   Cliente: " & objChip.CLIENTE

            Case "i"
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
        Dim ixImg
        Select Case Left(sDiv, 1)
            Case "u", "v", "g", "q", "x", "n", "a", "f", "l", "y", "o", "p", "e", "f", "m", "j", "s", "i"
                ixImg = New LinkButton
                ixImg.ID = sDiv
                'ixImg.Src = sImageChip
                ixImg.Style.Add("position", "absolute")
                ixImg.Style.Add("border", "solid 0px " & sColor)
                ixImg.Style.Add("Left", sL)
                ixImg.Style.Add("top", sT)
                ixImg.Style.Add("cursor", "hand")
                'ixImg.Attributes.Add("ondblclick", "Location('" & ixImg.ID & "')")

                ixImg.Attributes.Add("class", "textdiv2")
                ixImg.text = objChip.STATUS
                'ixImg.text = CHIPPullCollection.ObtenTotal(Left(sDiv, 1))
            Case Else
                ixImg = New HtmlImage
                ixImg.ID = sDiv
                ixImg.Src = sImageChip
                ixImg.Style.Add("position", "absolute")
                ixImg.Style.Add("border", "solid 3px " & sColor)
                ixImg.Style.Add("Left", sL)
                ixImg.Style.Add("top", sT)
                ixImg.Style.Add("cursor", "hand")
                ixImg.Attributes.Add("ondblclick", "Location('" & ixImg.ID & "')")
        End Select





        Dim ixdivTec As New HtmlGenericControl("div")
        ixdivTec.ID = "ctlTec_" & sDiv
        Dim ixdivBahia As New HtmlGenericControl("div")
        ixdivBahia.ID = "ctlTecBahia_" & sDiv

        Dim ixdiv As New HtmlGenericControl("div")
        ixdiv.ID = "ctl_" & sDiv


        ixdiv.Style.Add("Left", sleftTexto)
        ixdiv.Style.Add("top", stopTexto)

        ixdiv.Style.Add("position", "absolute")

        ixdiv.Style.Add("clear", "none")
        ixdiv.Style.Add("z-index", "1500")


        If bAlarm Then
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
        Select Case Left(sDiv, 1)
            Case "u", "v", "g", "q", "x", "n", "a", "f", "l", "y", "o", "p", "e", "f", "m", "j", "s", "i"
                ixdiv.InnerText = ""
                ixImg.Attributes.Add("onmouseover", "mostrarTooltip(this,'" & objChip.taginfo & "');")

            Case Else
                ixdiv.InnerText = stext
                If stext.Trim.Length > 3 Then ixdiv.InnerText = Left(stext, Fix(stext.Length / 2)) & " " & Right(stext, System.Math.Round(stext.Length / 2))
                ixdiv.Attributes.Add("class", "textdiv")
                ixImg.Attributes.Add("title", sComentarios)
        End Select



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


        Me.form1.Controls.Add(ixImg)
        Me.form1.Controls.Add(ixdiv)
        If btecnico Then
            Me.form1.Controls.Add(ixdivTec)
            Me.form1.Controls.Add(ixdivBahia)
        End If



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

        PINTACHIPS()

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

        'Dim OBJCOL As New CHIPPullCollection

        'OBJCOL = Session("ColChips")


        sqry = "select distinct  c.NOMBRE_EMPLEADO Tecnico, a.NOORDEN Orden, a.status Estatus"
        sqry += " from tyt_lv_tbl_control_citas_header_nw a inner join tyt_lv_tbl_control_citas b"
        sqry += " on a.NOORDEN=b.noOrden inner join TYT_LV_TECNICOS c on c.ID_EMPLEADO=b.idTecnico "
        sqry += " where isnull(a.status, '')<>'Entregado' and isnull(a.status, '')<>'' and a.NOORDEN<>0"

        sqry = " select * from TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_Tecnicos"
        sqry = " select * from TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_Tecnicos_separado"



        dt = BDClass.SQLtoDataTable(sqry, False)
        dt.Rows.Add(New Object() {"", dt.Compute("sum(ref)", ""), dt.Compute("sum(aut)", ""), dt.Compute("sum(tot)", ""), dt.Compute("sum(asig)", "")})
        dgTecnicosOrdenes.DataSource = dt
        dgTecnicosOrdenes.DataBind()

        'Dim dttemp As New DataTable
        'dttemp = CType(dgTecnicosOrdenes.DataSource, DataTable)
        'dttemp.Rows.Add(dttemp.NewRow)

        '  dv.InnerHtml += "<td>" & CType(dgTecnicosOrdenes.DataSource, DataTable).Compute("sum(ref)", "") & "</td>"
        'Dim dv As New HtmlControls.HtmlGenericControl("div")
        'dv.InnerHtml = "<table><tr><td></td>"
        'dv.InnerHtml += "<td>" & dt.Compute("sum(ref)", "") & "</td>"
        'dv.InnerHtml += "<td>" & dt.Compute("sum(aut)", "") & "</td>"
        'dv.InnerHtml += "<td>" & dt.Compute("sum(tot)", "") & "</td>"
        'dv.InnerHtml += "<td>" & dt.Compute("sum(asig)", "") & "</td>"
        'dv.InnerHtml += "</tr></table>"



        'Dim inoshow As Integer = 0, ienespera As Integer = 0, ienrampa As Integer = 0

        'sqry = "select count(id_hd) as cuenta "
        'sqry += " from TYT_LV_TBL_CONTROL_CITAS_HEADER_nw "
        'sqry += " where  convert(varchar,fecha,12)=convert(varchar,getdate(),12) and numcita<>'0' "
        'sqry += " and  convert(datetime, horaasesor)<dateadd(minute,-5, convert(datetime,convert(varchar,getdate(),108) )) and horallegada is null"


        'dt = BDClass.SQLtoDataTable(sqry, False)
        'inoshow = dt.Rows(0).Item(0)




        'ienrampa = (From p In OBJCOL Where p.status = "EnBahia").Count



        'ienespera = (From p In OBJCOL Where p.status = "Recepcion").Count

        'Dim SCONTROL As String
        'SCONTROL = "<div  class='textResumen'>"
        'SCONTROL += "<table style='border:solid thin silver;background-color:transparent;font-size:10px;font-family:arial;'>"

        'SCONTROL += "<tr>"
        'SCONTROL += "<td  align='left'>SIN RECEPCION</td><td  align='left'>NO SHOW</td><td  align='left'>EN SERVICIO</td> "
        'SCONTROL += ""
        'SCONTROL += "</tr>"
        'SCONTROL += "<tr>"
        'SCONTROL += "<td  align='center'>" & ienespera & "</td><td  align='center'>" & inoshow & "</td><td  align='center'>" & ienrampa & "</td> "
        'SCONTROL += ""
        'SCONTROL += "</tr>"




        'If OBJCOL.Count > 0 Then
        '    SCONTROL += "<tr>"

        '    SCONTROL += "<td colspan=2 >BUSCAR PLACAS:</td><td><select id='selOptChips' onchange='buscaChp(this.value);'> "
        '    SCONTROL += "<option value=''>--</option>"
        '    y = From p As ChipPull In OBJCOL Select p Order By p.NOPLACAS Ascending
        '    For Each obj As ChipPull In y
        '        SCONTROL += "<option value='" & obj.IDFICHA & "'>" & obj.NOPLACAS & "</option>"
        '    Next


        '    SCONTROL += "</select>"
        '    'SCONTROL=+= " <input type=button id='cmdinptBuscar'  name='cmdinptBuscar' onclick=buscaChp(getElementById('selOptChips').value);>"
        '    SCONTROL += "</td>"

        '    SCONTROL += "</tr><tr>"
        '    SCONTROL += "<td colspan=2 >BUSCAR ORDEN:</td><td><input type='text' id='inOptChips'  style='width:70px;'/><input type='button' style='width:30px;' onclick='buscaChpOrd();' id='btninOptChips'/> "
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


        'SCONTROL += "</table></div>"
        'Dim obj1 As HtmlGenericControl = New HtmlGenericControl("div")
        'obj1.InnerHtml = SCONTROL
        'form1.Controls.Add(obj1)

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

    Private Sub dgTecnicosOrdenes_PreRender(sender As Object, e As EventArgs) Handles dgTecnicosOrdenes.PreRender
        Dim sqry As String = "", dt As New DataTable, dt2 As New DataTable
        Dim scontrol As String

        sqry = " select a.*, case when tipo='a' then 'DetenidoAutorizacion'  when tipo='x' then 'DetenidoRefacciones'  when tipo='j' then 'HyP'  when tipo='e' then 'Estetica'  when tipo='o' then 'DetenidoTot'  when tipo='p' then 'DetenidoVarios'  else '' end status, TIPO from  TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_Tecnicos_detalle a left outer join dbo.TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_hlp z on  a.noorden=z.noorden and a.scapturado=z.descripcion  "
        'sqry += "  where  NOMBRE_ASESOR='" & dgTecnicosOrdenes.Items(i).Cells(0).Text & "'"
        dt = BDClass.SQLtoDataTable(sqry, False)

        For i = 0 To dgTecnicosOrdenes.Items.Count - 1
            'sqry = " select a.*, case when tipo='a' then 'DetenidoAutorizacion'  when tipo='x' then 'DetenidoRefacciones'  when tipo='j' then 'HyP'  when tipo='e' then 'Estetica'  when tipo='o' then 'DetenidoTot'  when tipo='p' then 'DetenidoVarios'  else '' end status from  TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_Tecnicos_detalle a left outer join dbo.TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_hlp z on  a.noorden=z.noorden and a.scapturado=z.descripcion  "
            'sqry += "  where  NOMBRE_ASESOR='" & dgTecnicosOrdenes.Items(i).Cells(0).Text & "'"
            'dt = BDClass.SQLtoDataTable2(sqry, False)

            dt.DefaultView.RowFilter = "NOMBRE_empleado='" & dgTecnicosOrdenes.Items(i).Cells(0).Text & "' and tipo='x'"
            If dt.DefaultView.Count > 0 Then


                scontrol = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS PENDIENTE</td><td align=center>SERVICIO</td><td align=center>ESTATUS</td><td align=center>ASESOR</td><td align=center>REFA</td></tr>"

                For k = 0 To dt.DefaultView.Count - 1
                    sqry = "select ref from  fv_TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_tmp where  orden='" & dt.DefaultView(k).Item(0).ToString.Trim & "' and serviciocapturado='" & dt.DefaultView(k).Item("scapturado").ToString.Trim & "' and   ISNULL(Ref,'NULL')<>'NULL'"
                    dt2 = BDClass.SQLtoDataTable(sqry, False)
                    scontrol += "<tr><td align=center>" & dt.DefaultView(k).Item(0) & "</td><td  align=left>" & dt.DefaultView(k).Item(4) & "</td><td  align=center>" & dt.DefaultView(k).Item(1) & "</td><td  align=left>" & dt.DefaultView(k).Item(2) & "</td><td  align=left>" & dt.DefaultView(k).Item("status") & "</td><td  align=left>" & dt.DefaultView(k).Item("asesor") & "</td><td><table>"
                    For ik = 0 To dt2.Rows.Count - 1
                        scontrol += "<tr><td>"
                        scontrol += dt2.Rows(ik).Item(0).ToString
                        scontrol += "</td></tr>"
                    Next
                    scontrol += "</table></td></tr>"
                Next
                scontrol += "</table>"





                CType(dgTecnicosOrdenes.Items(i).FindControl("lblTotalR"), LinkButton).Attributes.Add("onmouseover", "mostrarTooltip(this,'" & scontrol & "');")

            End If


        Next
        For i = 0 To dgTecnicosOrdenes.Items.Count - 1
            'sqry = " select a.*, case when tipo='a' then 'DetenidoAutorizacion'  when tipo='x' then 'DetenidoRefacciones'  when tipo='j' then 'HyP'  when tipo='e' then 'Estetica'  when tipo='o' then 'DetenidoTot'  when tipo='p' then 'DetenidoVarios'  else '' end status from  TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_Tecnicos_detalle a left outer join dbo.TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_hlp z on  a.noorden=z.noorden and a.scapturado=z.descripcion  "
            'sqry += "  where  NOMBRE_ASESOR='" & dgTecnicosOrdenes.Items(i).Cells(0).Text & "'"
            'dt = BDClass.SQLtoDataTable2(sqry, False)

            dt.DefaultView.RowFilter = "NOMBRE_empleado='" & dgTecnicosOrdenes.Items(i).Cells(0).Text & "' and tipo='a'"
            If dt.DefaultView.Count > 0 Then

                scontrol = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS PENDIENTE</td><td align=center>SERVICIO</td><td align=center>ESTATUS</td><td align=center>ASESOR</td></tr>"

                For k = 0 To dt.DefaultView.Count - 1
                    scontrol += "<tr><td align=center>" & dt.DefaultView(k).Item(0) & "</td><td  align=left>" & dt.DefaultView(k).Item(4) & "</td><td  align=center>" & dt.DefaultView(k).Item(1) & "</td><td  align=left>" & dt.DefaultView(k).Item(2) & "</td><td  align=left>" & dt.DefaultView(k).Item("status") & "</td><td  align=left>" & dt.DefaultView(k).Item("asesor") & "</td></tr>"
                Next
                scontrol += "</table>"

                CType(dgTecnicosOrdenes.Items(i).FindControl("lblTotalA"), LinkButton).Attributes.Add("onmouseover", "mostrarTooltip(this,'" & scontrol & "');")

            End If


        Next
        For i = 0 To dgTecnicosOrdenes.Items.Count - 1
            'sqry = " select a.*, case when tipo='a' then 'DetenidoAutorizacion'  when tipo='x' then 'DetenidoRefacciones'  when tipo='j' then 'HyP'  when tipo='e' then 'Estetica'  when tipo='o' then 'DetenidoTot'  when tipo='p' then 'DetenidoVarios'  else '' end status from  TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_Tecnicos_detalle a left outer join dbo.TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_hlp z on  a.noorden=z.noorden and a.scapturado=z.descripcion  "
            'sqry += "  where  NOMBRE_ASESOR='" & dgTecnicosOrdenes.Items(i).Cells(0).Text & "'"
            'dt = BDClass.SQLtoDataTable2(sqry, False)

            dt.DefaultView.RowFilter = "NOMBRE_empleado='" & dgTecnicosOrdenes.Items(i).Cells(0).Text & "' and tipo='o'"
            If dt.DefaultView.Count > 0 Then

                scontrol = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS PENDIENTE</td><td align=center>SERVICIO</td><td align=center>ESTATUS</td><td align=center>ASESOR</td></tr>"

                For k = 0 To dt.DefaultView.Count - 1
                    scontrol += "<tr><td align=center>" & dt.DefaultView(k).Item(0) & "</td><td  align=left>" & dt.DefaultView(k).Item(4) & "</td><td  align=center>" & dt.DefaultView(k).Item(1) & "</td><td  align=left>" & dt.DefaultView(k).Item(2) & "</td><td  align=left>" & dt.DefaultView(k).Item("status") & "</td><td  align=left>" & dt.DefaultView(k).Item("asesor") & "</td></tr>"
                Next
                scontrol += "</table>"

                CType(dgTecnicosOrdenes.Items(i).FindControl("lblTotalT"), LinkButton).Attributes.Add("onmouseover", "mostrarTooltip(this,'" & scontrol & "');")

            End If


        Next
        For i = 0 To dgTecnicosOrdenes.Items.Count - 1
            'sqry = " select a.*, case when tipo='a' then 'DetenidoAutorizacion'  when tipo='x' then 'DetenidoRefacciones'  when tipo='j' then 'HyP'  when tipo='e' then 'Estetica'  when tipo='o' then 'DetenidoTot'  when tipo='p' then 'DetenidoVarios'  else '' end status from  TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_Tecnicos_detalle a left outer join dbo.TYT_LV_TBL_CONTROL_CITAS_DMS_contadores_hlp z on  a.noorden=z.noorden and a.scapturado=z.descripcion  "
            'sqry += "  where  NOMBRE_ASESOR='" & dgTecnicosOrdenes.Items(i).Cells(0).Text & "'"
            'dt = BDClass.SQLtoDataTable2(sqry, False)

            dt.DefaultView.RowFilter = "NOMBRE_empleado='" & dgTecnicosOrdenes.Items(i).Cells(0).Text & "' and tipo='y'"
            If dt.DefaultView.Count > 0 Then

                scontrol = "<table><tr><td align=center>ORDEN</td><td align=center>MODELO</td><td align=center>DIAS PENDIENTE</td><td align=center>SERVICIO</td><td align=center>ESTATUS</td><td align=center>ASESOR</td></tr>"

                For k = 0 To dt.DefaultView.Count - 1
                    scontrol += "<tr><td align=center>" & dt.DefaultView(k).Item(0) & "</td><td  align=left>" & dt.DefaultView(k).Item(4) & "</td><td  align=center>" & dt.DefaultView(k).Item(1) & "</td><td  align=left>" & dt.DefaultView(k).Item(2) & "</td><td  align=left>" & dt.DefaultView(k).Item("status") & "</td><td  align=left>" & dt.DefaultView(k).Item("asesor") & "</td></tr>"
                Next
                scontrol += "</table>"

                CType(dgTecnicosOrdenes.Items(i).FindControl("lblTotalAS"), LinkButton).Attributes.Add("onmouseover", "mostrarTooltip(this,'" & scontrol & "');")

            End If


        Next

        dgTecnicosOrdenes.Items(dgTecnicosOrdenes.Items.Count - 1).CssClass = "datagridHD2"


    End Sub
End Class
