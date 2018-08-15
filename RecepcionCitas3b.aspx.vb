Imports TablerosV2LibTypes
Partial Public Class RecepcionCitas3b
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            LlenadgPrincipal()

            ' LlenadgLibres()

        End If
    End Sub



    'Sub LlenadgLibres()
    '    Dim dt As New DataTable, dt2 As New DataTable
    '    Dim sqry As String = "", i As Integer
    '   
    '    Dim ipage As Integer = dgLibres.CurrentPageIndex


    '    '  sqry = " Select  left(b.Nombre,8) as nombre_empleado ,CASE WHEN a.TIPOCLIENTE='CITAS' THEN 'CITA' ELSE 'SINCITA' END as Hora, a.noplacas,  left(a.cliente,20) as cliente, '' as serviciocapturado,  left(colorPrisma, 8) as color, left(a.vehiculo,8) as vehiculo, left(convert(varchar, a.fechahorapromesa, 108), 5) horapromesa, left(isnull(a.status, ''),8) as estatus_orden FROM   Tb_CITAS_HEADER_NW AS a LEFT OUTER JOIN   sccUsuarios AS b ON a.idasesor = b.cveasesor and   isnull(b.cveAsesor,'')<>'' WHERE   convert(varchar,a.fecha,112)=convert(varchar,getdate(),112)   AND a.NUMCITA='0'   AND isnull(a.status, '')<>'Entregado' AND isnull(a.status, '')<>'Facturada' AND a.horallegada IS NOT NULL"
    '    sqry = "Select  * from  " & System.Web.Configuration.WebConfigurationManager.AppSettings.Item("vreceppcioncitasPrecios").ToString & ""

    '    dt = obj.SQLtoDataTable(sqry, False)



    '    Session("dtGridLibres") = dt
    '    dgLibres.CurrentPageIndex = 0

    '    If dgLibres.PageCount < 1 Then
    '        dgLibres.CurrentPageIndex = 0
    '    Else
    '        Try

    '            If (ipage + 1) < dgLibres.PageCount Then
    '                dgLibres.CurrentPageIndex = ipage + 1
    '            Else
    '                dgLibres.CurrentPageIndex = 0
    '            End If

    '        Catch
    '            dgLibres.CurrentPageIndex = 0
    '        End Try
    '    End If

    '    dgLibres.DataSource = dt

    '    dgLibres.DataBind()

    'End Sub
    Sub LlenadgPrincipal()
        Dim dt As New DataTable
        Dim sqry As String = ""
       
        Dim ipage As Integer = dg1.CurrentPageIndex
        ' sqry = "Select * from TYT_LV_TBL_CONTROL_CITAS_header where  year(fecha)=" & Date.Now.Year & " and month(fecha)=" & Date.Now.Month & " and day(fecha)=" & Date.Now.Day & "  and NUMCITA<>'0' AND NOORDEN ='0'   order by HORAASESOR asc"
        sqry = "Select  * from  " & System.Web.Configuration.WebConfigurationManager.AppSettings.Item("vreceppcioncitasEntregasAll").ToString & " ORDER BY HORAASESOR asc"

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

        ScriptManager.RegisterStartupScript(UPGUARDAV, UPGUARDAV.GetType(), "animacion", "verificarAnimacion();", True)
    End Sub




    Protected Sub dg1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg1.PreRender
        Dim bllegada As Boolean = False
        'Dim ttime As TimeSpan, ttimenow As TimeSpan

        For i = 0 To dg1.Items.Count - 1

            'If dg1.Items(i).Cells(9).Text.Trim = "0" Then
            '    dg1.Items(i).BackColor = Drawing.Color.Snow
            '    dg1.Items(i).ForeColor = Drawing.Color.Black
            'Else
            '    dg1.Items(i).BackColor = Drawing.Color.LightSteelBlue
            '    dg1.Items(i).ForeColor = Drawing.Color.White
            'End If

            'If dg1.Items(i).Cells(6).Text.Trim = "&nbsp;" Or dg1.Items(i).Cells(6).Text.Trim = "" Then
            '    bllegada = False
            'Else
            '    bllegada = True
            'End If
            CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
            CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
            CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
            '    Try
            '        ttime = New TimeSpan(CDate(dg1.Items(i).Cells(0).Text).Hour, CDate(dg1.Items(i).Cells(0).Text).Minute, 0)

            '        If bllegada Then
            '            ttimenow = New TimeSpan(CDate(dg1.Items(i).Cells(6).Text).Hour, CDate(dg1.Items(i).Cells(6).Text).Minute, 0)
            '            CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "block"
            '            CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
            '            CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
            '            If (ttimenow - ttime).Minutes < 10 And (ttimenow - ttime).Minutes > 0 Then
            '                CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "A tiempo"
            '            ElseIf (ttimenow - ttime).Minutes = 0 Then
            '                CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "A tiempo"
            '            ElseIf (ttimenow - ttime).Minutes < -0 Then
            '                CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "Anticipado"
            '            ElseIf (ttimenow - ttime).Minutes > 10 Then
            '                CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "Demorado"
            '            End If
            '        Else
            '            ttimenow = New TimeSpan(Now.Hour, Now.Minute, Now.Second)
            '            CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "No llega"
            '            If (ttimenow - ttime).Minutes > -10 And (ttimenow - ttime).Minutes < 10 Then
            '                CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
            '                CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "block"
            '                CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
            '            ElseIf (ttimenow - ttime).Minutes > 10 Then
            '                CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
            '                CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
            '                CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "block"
            '            End If
            '        End If
            '    Catch ex As Exception
            '        If CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "" Then
            '            CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
            '            CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
            '            CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
            '        End If
            '    End Try
        Next
    End Sub



    Protected Sub dgLibres_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgLibres.PreRender
        Dim ttime As TimeSpan
        Dim dt As New DataTable
        Dim sqry As String

        sqry = "Select  * from  " & System.Web.Configuration.WebConfigurationManager.AppSettings.Item("vreceppcioncitasPrecios").ToString & ""

        dt = BDClass.SQLtoDataTable(sqry, False)



        For i = 0 To dgLibres.Items.Count - 1
            dt.DefaultView.RowFilter = "id_mto='" & dgLibres.Items(i).Cells(0).Text.Trim & "'"
            CType(dgLibres.Items(i).FindControl("dtDet"), DataGrid).DataSource = dt.DefaultView
            CType(dgLibres.Items(i).FindControl("dtDet"), DataGrid).DataBind()
            '    CType(dgLibres.Items(i).FindControl("lblTotal"), Label).Text = (dt.Compute("Sum(Total)", "id_mto = '" & dgLibres.Items(i).Cells(0).Text.Trim & "'"))

            Try

                If dgLibres.Items(i).Cells(8).Text.Trim.ToLower = "terminado" Or dgLibres.Items(i).Cells(8).Text.Trim.ToLower = "terminadoqa" Then
                    CType(dgLibres.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "block"
                    CType(dgLibres.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
                    CType(dgLibres.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
                Else
                    ttime = New TimeSpan(dgLibres.Items(i).Cells(7).Text.Split(":")(0), dgLibres.Items(i).Cells(7).Text.Split(":")(1), 0)
                    If (ttime - New TimeSpan(Now.Hour, Now.Minute, Now.Second)).Minutes > 6 Then
                        CType(dgLibres.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "block"
                        CType(dgLibres.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
                        CType(dgLibres.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
                    ElseIf (ttime - New TimeSpan(Now.Hour, Now.Minute, Now.Second)).Minutes < 6 And (ttime - New TimeSpan(Now.Hour, Now.Minute, Now.Second)).Minutes > 0 Then
                        CType(dgLibres.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
                        CType(dgLibres.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "block"
                        CType(dgLibres.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
                    ElseIf (ttime - New TimeSpan(Now.Hour, Now.Minute, Now.Second)).Minutes < -6 Then
                        CType(dgLibres.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
                        CType(dgLibres.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
                        CType(dgLibres.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "block"
                    End If
                End If

            Catch ex As Exception

            End Try


        Next
    End Sub



    Protected Sub Timer11_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer11.Tick
        nreloj.Value = Date.Now.ToShortTimeString
        LlenadgPrincipal()


    End Sub
    Protected Sub Timer12_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer12.Tick
        nreloj.Value = Date.Now.ToShortTimeString

        ' LlenadgLibres()


    End Sub
    Protected Sub Timer13_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer13.Tick

        Response.Redirect("RecepcionCitas3.aspx")


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        nreloj.Value = Date.Now.ToShortTimeString
        LlenadgPrincipal()

        'LlenadgLibres()

    End Sub
End Class
