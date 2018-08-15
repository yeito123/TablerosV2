Imports TablerosV2LibTypes


Partial Public Class RecepcionCitas2
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitulo.Text = BDClass.SQLtoDataTable("Select * from sccPantallaBienvenida with(nolock) where activo=1 ", False).Rows(0).Item("leyendaBienvenida").ToString().ToUpper()

            LlenadgPrincipal()


        End If

    End Sub

    Sub LlenadgPrincipal()
        Dim dt As New DataTable
        Dim sqry As String = ""
       
        Dim ipage As Integer = dg1.CurrentPageIndex
        ' sqry = "Select * from TYT_LV_TBL_CONTROL_CITAS_header where  year(fecha)=" & Date.Now.Year & " and month(fecha)=" & Date.Now.Month & " and day(fecha)=" & Date.Now.Day & "  and NUMCITA<>'0' AND NOORDEN ='0'   order by HORAASESOR asc"
        sqry = "Select  * from  " & System.Web.Configuration.WebConfigurationManager.AppSettings.Item("vreceppcioncitasCC").ToString & " ORDER BY HORAASESOR asc"

        dt = BDClass.SQLtoDataTable(sqry, False)
        Session("dtGrid") = dt
        dg1.CurrentPageIndex = 0


        If dg1.PageCount < 1 Then
            dg1.CurrentPageIndex = 0
        Else
            Try

                If (ipage + 1) < dg1.PageCount Then
                    dg1.CurrentPageIndex = ipage + 1
                Else
                    dg1.CurrentPageIndex = 0
                End If

            Catch
                dg1.CurrentPageIndex = 0
            End Try

        End If


        dg1.DataSource = dt

        dg1.DataBind()

    End Sub
    'Sub LlenadgSinCita()
    '    Dim dt As New DataTable
    '    Dim sqry As String = ""
    '   
    '    Dim ipage As Integer = dgOcupados.CurrentPageIndex
    '    sqry = "Select  left(b.nombre_empleado,10) as nombre_empleado ,a.HORARECEPCION,a.horaasesor, a.noplacas, left(a.cliente,25) as cliente, left(a.serviciocapturado,20) as serviciocapturado,  left(convert(varchar(2),noPrisma)+colorPrisma, 8) as color, left(a.vehiculo,8) as vehiculo, a.horaPromesa, a.estatus_orden FROM  tablero.dbo.TYT_LV_TBL_CONTROL_CITAS_HEADER AS a LEFT OUTER JOIN  totald_bi.dbo.DIM_EMPLEADO AS b ON a.idasesor = b.ID_EMPLEADO WHERE  year(a.Fecha_hora_com)=" & Date.Now.Year & " and month(a.Fecha_hora_com)=" & Date.Now.Month & " and day(a.Fecha_hora_com)=" & Date.Now.Day & "  AND a.NUMCITA='0' AND a.NOORDEN <>'0' AND a.HORARECEPCION IS NOT NULL AND a.estatus_orden<>'facturado' AND a.estatus_orden<>'Facturada' AND a.horaPromesa IS NOT NULL"
    '    dt = obj.SQLtoDataTable(sqry, False)
    '    Session("dtGrid") = dt

    '    dgOcupados.DataSource = dt

    '    dgOcupados.DataBind()
    '    dgOcupados.CurrentPageIndex = 0

    '    Try
    '        dgOcupados.CurrentPageIndex = IIf((ipage + 1) >= (CInt(Fix(dt.Rows.Count / dgOcupados.PageSize) + 1)), 0, ipage + 1)

    '    Catch
    '        dgOcupados.CurrentPageIndex = 0
    '    End Try
    'End Sub


    Protected Sub dg1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dg1.PageIndexChanged
        'dg1.CurrentPageIndex = e.NewPageIndex
        'Dim dt As New DataTable
        'If Not Session("dtGrid") Is Nothing Then
        '    dt = Session("dtGrid")
        'End If
        'dg1.DataSource = dt
        'dg1.DataBind()
    End Sub

    Protected Sub dg1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg1.PreRender
        Dim ttime As TimeSpan
        For i = 0 To dg1.Items.Count - 1
            If dg1.Items(i).Cells(7).Text.Trim = "&nbsp;" Or dg1.Items(i).Cells(7).Text.Trim = "" Then
                CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "NO llega"
            Else
                CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "Arribo"
                'Resume Next
            End If

            Try
                CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
                CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
                CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
                dg1.Items(i).BackColor = Drawing.Color.White
                dg1.Items(i).ForeColor = Drawing.Color.Black

                'ttime = New TimeSpan(dg1.Items(i).Cells(0).Text.Split(":")(0), dg1.Items(i).Cells(0).Text.Split(":")(1), 0)
                ttime = New TimeSpan(CDate(dg1.Items(i).Cells(0).Text).Hour, CDate(dg1.Items(i).Cells(0).Text).Minute, 0)

                If (New TimeSpan(Now.Hour, Now.Minute, Now.Second) - ttime).Hours > 0 And CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "NO llega" Then
                    CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
                    CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
                    CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "block"
                    dg1.Items(i).BackColor = Drawing.Color.Firebrick
                    dg1.Items(i).ForeColor = Drawing.Color.White
                Else
                    If (New TimeSpan(Now.Hour, Now.Minute, Now.Second) - ttime).Minutes > 5 And CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "NO llega" Then
                        CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
                        CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
                        CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "block"
                        dg1.Items(i).BackColor = Drawing.Color.Firebrick
                        dg1.Items(i).ForeColor = Drawing.Color.White
                    ElseIf (New TimeSpan(Now.Hour, Now.Minute, Now.Second) - ttime).Minutes < 5 And (New TimeSpan(Now.Hour, Now.Minute, Now.Second) - ttime).Minutes > 0 And CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "NO llega" Then
                        CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
                        CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "block"
                        CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
                        dg1.Items(i).BackColor = Drawing.Color.Beige
                        dg1.Items(i).ForeColor = Drawing.Color.Black
                    ElseIf (New TimeSpan(Now.Hour, Now.Minute, Now.Second) - ttime).Minutes <= 0 And CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "NO llega" Then
                        CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "block"
                        CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
                        CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
                        dg1.Items(i).BackColor = Drawing.Color.OliveDrab
                        dg1.Items(i).ForeColor = Drawing.Color.White
                    ElseIf CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "Arribo" Then

                        If (ttime - New TimeSpan(dg1.Items(i).Cells(7).Text.Split(":")(0), dg1.Items(i).Cells(7).Text.Split(":")(1), 0)).Minutes < -5 Then
                            CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
                            CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "block"
                            CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
                            dg1.Items(i).BackColor = Drawing.Color.Beige
                            dg1.Items(i).ForeColor = Drawing.Color.White
                        Else
                            CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "block"
                            CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
                            CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
                            dg1.Items(i).BackColor = Drawing.Color.OliveDrab
                            dg1.Items(i).ForeColor = Drawing.Color.White
                        End If

                    End If
                End If

            Catch ex As Exception

            End Try


        Next


    End Sub



    'Protected Sub dgOcupados_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgOcupados.PreRender
    '    Dim ttime As TimeSpan
    '    For i = 0 To dgOcupados.Items.Count - 1

    '        Try
    '            If dgOcupados.Items(i).Cells(8).Text.Trim.ToLower = "terminado" Or dgOcupados.Items(i).Cells(8).Text.Trim.ToLower = "cerrado" Then
    '                CType(dgOcupados.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "block"
    '                CType(dgOcupados.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
    '                CType(dgOcupados.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
    '            Else
    '                ttime = New TimeSpan(dgOcupados.Items(i).Cells(7).Text.Split(":")(0), dgOcupados.Items(i).Cells(7).Text.Split(":")(1), 0)
    '                If (ttime - New TimeSpan(Now.Hour, Now.Minute, Now.Second)).Minutes > 6 Then
    '                    CType(dgOcupados.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "block"
    '                    CType(dgOcupados.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
    '                    CType(dgOcupados.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
    '                ElseIf (ttime - New TimeSpan(Now.Hour, Now.Minute, Now.Second)).Minutes < 6 And (ttime - New TimeSpan(Now.Hour, Now.Minute, Now.Second)).Minutes > 0 Then
    '                    CType(dgOcupados.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
    '                    CType(dgOcupados.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "block"
    '                    CType(dgOcupados.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
    '                ElseIf (ttime - New TimeSpan(Now.Hour, Now.Minute, Now.Second)).Minutes < -6 Then
    '                    CType(dgOcupados.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
    '                    CType(dgOcupados.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
    '                    CType(dgOcupados.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "block"
    '                End If
    '            End If
    '        Catch ex As Exception

    '        End Try


    '    Next
    'End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick


        LlenadgPrincipal()

    End Sub

    Private Sub Timer3_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer3.Tick

        LlenadgPrincipal()
    End Sub
End Class
