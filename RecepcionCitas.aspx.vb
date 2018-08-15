Imports TablerosV2LibTypes
Partial Public Class RecepcionCitas
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '    Timer2.Interval = Session("tiempoPantalla") * 1000
        If Not Page.IsPostBack Then
            LlenadgPrincipal()
            If Now.Hour >= 14 Then
                If Session("Entrega") = "1" Then
                    LlenarDataGridPrincipalEntregas()
                    Session("Entrega") = "0"
                Else
                    LlenadgPrincipal()
                    Session("Entrega") = "1"
                End If
            Else
                LlenadgPrincipal()
            End If
            LlenadgLibres()
            'MostrarMensajeClienteLlegando()
        End If
    End Sub

    Private Sub MostrarMensajeClienteLlegando()
        Literal1.Text = ""
        Dim dt = BDClass.SQLtoDataTable("select * from Tb_Citas where datediff(minute, getdate(),cast((select top 1 horallegada from tb_citas_header_nw where tb_citas_header_nw.id_hd = Tb_Citas.id_hd) as time)) between -2 and 0 order by fecha desc", False)
        If dt.Rows.Count > 0 Then
            Panel1.Visible = True
            For Each Fila As DataRow In dt.Rows
                If Fila("NUMCITA") <> "0" Then
                    Literal1.Text &= "<p>¡Bienvenido señor(a) " & Fila("Cliente") & "!</p>"
                Else
                    Literal1.Text &= "<p>¡Bienvenido señor(a) con placas " & Fila("noPlacas") & "!</p>"
                End If

            Next
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "modal", "VerificarClienteLlego();", True)
        End If


        'Esta parte es para prueba
        'Literal1.Text &= "<p>¡Bienvenido señor(a) Angel Ulises Velásquez Hernández!</p>"
        'Literal1.Text &= "<p>¡Bienvenido señor(a) José Antonio Sánchez Gonzáles!</p>"
        'sScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "modal", "VerificarClienteLlego();", True)
    End Sub

    Private Sub LlenarDataGridPrincipalEntregas()
        Dim dt As New DataTable
        Dim sqry As String = ""
       
        Dim ipage As Integer = dg1.CurrentPageIndex
        ' sqry = "Select * from TYT_LV_TBL_CONTROL_CITAS_header where  year(fecha)=" & Date.Now.Year & " and month(fecha)=" & Date.Now.Month & " and day(fecha)=" & Date.Now.Day & "  and NUMCITA<>0 AND NOORDEN =0   order by HORAASESOR asc"
        sqry = "Select  * from  " & System.Web.Configuration.WebConfigurationManager.AppSettings.Item("vreceppcioncitasCC").ToString & " where datediff(hour, GETDATE(), cast(CAST(GETDATE() AS date) as datetime) + cast(horaasesor as time)) between -1 and 1 ORDER BY HORAASESOR asc"
        dt = BDClass.SQLtoDataTable("SELECT     LEFT(b.Nombre, 8) AS nombre_empleado, LEFT(CONVERT(varchar, a.fechaHoraPromesa, 108), 5) AS horaasesor, LEFT(CONVERT(varchar, a.HoraIEntrega, 108), 5) " _
        & "              AS horarecepcion, a.noPlacas, LEFT(a.Cliente, 20) AS cliente, LEFT " _
        & "                  ((SELECT     TOP (1) servicioCapturado " _
        & "                      FROM         dbo.Tb_CITAS AS c " _
        & "                      WHERE     (id_hd = a.id_hd) AND (servicioCapturado <> 'Lavado')), 20) AS serviciocapturado, LEFT(a.colorPrisma, 8) AS color, LEFT(a.Vehiculo, 8) AS vehiculo,  " _
        & "              CONVERT(varchar, a.fechaHoraPromesa, 112) AS horapromesa, LEFT(ISNULL(a.Status, ''), 8) AS estatus_orden " _
        & "FROM         dbo.Tb_CITAS_HEADER_NW AS a LEFT OUTER JOIN " _
        & "              dbo.SccUsuarios AS b ON a.idasesor = b.cveAsesor AND ISNULL(b.cveAsesor, '') <> '' " _
        & "WHERE     (datediff(hour, fechaHoraPromesa, getdate()) between -1 and 1) AND (ISNULL(a.Status, '') <> 'Entregado')", False)
        Session("dtGrid") = dt
        dg1.CurrentPageIndex = 0

        dg1.DataSource = dt

        If dg1.PageCount < 1 Or CInt(dt.Rows.Count / dg1.PageSize) < dg1.PageCount Then
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

        dg1.DataBind()
    End Sub

    Sub LlenadgLibres()
        Dim dt As New DataTable, dt2 As New DataTable
        Dim sqry As String = ""
       
        Dim ipage As Integer = dgLibres.CurrentPageIndex


        '  sqry = " Select  left(b.Nombre,8) as nombre_empleado ,CASE WHEN a.TIPOCLIENTE='CITAS' THEN 'CITA' ELSE 'SINCITA' END as Hora, a.noplacas,  left(a.cliente,20) as cliente, '' as serviciocapturado,  left(colorPrisma, 8) as color, left(a.vehiculo,8) as vehiculo, left(convert(varchar, a.fechahorapromesa, 108), 5) horapromesa, left(isnull(a.status, ''),8) as estatus_orden FROM   Tb_CITAS_HEADER_NW AS a LEFT OUTER JOIN   sccUsuarios AS b ON a.idasesor = b.cveasesor and   isnull(b.cveAsesor,'')<>'' WHERE   convert(varchar,a.fecha,112)=convert(varchar,getdate(),112)   AND a.NUMCITA='0'   AND isnull(a.status, '')<>'Entregado' AND isnull(a.status, '')<>'Facturada' AND a.horallegada IS NOT NULL"
        sqry = "Select  * from  " & System.Web.Configuration.WebConfigurationManager.AppSettings.Item("vreceppcioncitasSC").ToString & ""

        dt = BDClass.SQLtoDataTable(sqry, False)



        Session("dtGridLibres") = dt
        dgLibres.CurrentPageIndex = 0
        dgLibres.DataSource = dt

        If dgLibres.PageCount < 1 Or CInt(dt.Rows.Count / dgLibres.PageSize) < dgLibres.PageCount Then
            dgLibres.CurrentPageIndex = 0
        Else
            Try

                If (ipage + 1) < dgLibres.PageCount Then
                    dgLibres.CurrentPageIndex = ipage + 1
                Else
                    dgLibres.CurrentPageIndex = 0
                End If

            Catch
                dgLibres.CurrentPageIndex = 0
            End Try
        End If



        dgLibres.DataBind()

    End Sub
    Sub LlenadgPrincipal()
        Dim dt As New DataTable
        Dim sqry As String = ""
       
        Dim ipage As Integer = dg1.CurrentPageIndex
        ' sqry = "Select * from TYT_LV_TBL_CONTROL_CITAS_header where  year(fecha)=" & Date.Now.Year & " and month(fecha)=" & Date.Now.Month & " and day(fecha)=" & Date.Now.Day & "  and NUMCITA<>'0' AND NOORDEN ='0'   order by HORAASESOR asc"
        sqry = "Select  * from  " & System.Web.Configuration.WebConfigurationManager.AppSettings.Item("vreceppcioncitasCC").ToString & ""

        dt = BDClass.SQLtoDataTable(sqry, False)
        Session("dtGrid") = dt
        dg1.CurrentPageIndex = 0



        dg1.DataSource = dt



        If dg1.PageCount < 1 Or CInt(dt.Rows.Count / dg1.PageSize) < dg1.PageCount Then
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

        dg1.DataBind()

        ' ScriptManager.RegisterStartupScript(UPGUARDAV, UPGUARDAV.GetType(), "animacion", "verificarAnimacion();", True)
    End Sub




    Protected Sub dg1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg1.PreRender
        Dim bllegada As Boolean = False
        Dim ttime As TimeSpan, ttimenow As TimeSpan
        For i = 0 To dg1.Items.Count - 1
            If dg1.Items(i).Cells(6).Text.Trim = "&nbsp;" Or dg1.Items(i).Cells(6).Text.Trim = "" Then
                bllegada = False
            Else
                bllegada = True
            End If
            CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
            CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
            CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
            Try
                ttime = New TimeSpan(CDate(dg1.Items(i).Cells(0).Text).Hour, CDate(dg1.Items(i).Cells(0).Text).Minute, 0)

                If bllegada Then
                    ttimenow = New TimeSpan(CDate(dg1.Items(i).Cells(6).Text).Hour, CDate(dg1.Items(i).Cells(6).Text).Minute, 0)
                    CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "block"
                    CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
                    CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
                    If (ttimenow - ttime).TotalMinutes < 10 And (ttimenow - ttime).Minutes > 0 Then
                        CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "A tiempo"
                    ElseIf (ttimenow - ttime).TotalMinutes = 0 Then
                        CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "A tiempo"
                    ElseIf (ttimenow - ttime).TotalMinutes < -0 Then
                        CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "Anticipado"
                    ElseIf (ttimenow - ttime).TotalMinutes > 10 Then
                        CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "Demorado"
                    End If
                Else
                    ttimenow = New TimeSpan(Now.Hour, Now.Minute, Now.Second)
                    CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "No llega"
                    If (ttimenow - ttime).TotalMinutes > -10 And (ttimenow - ttime).TotalMinutes < 10 Then
                        CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
                        CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "block"
                        CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
                    ElseIf (ttimenow - ttime).TotalMinutes > 10 Then
                        CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
                        CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
                        CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "block"
                    End If
                End If
            Catch ex As Exception
                If CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "" Then
                    CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
                    CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "none"
                    CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
                End If
            End Try
        Next
    End Sub



    Protected Sub dgLibres_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgLibres.PreRender
        Dim ttime As TimeSpan
        For i = 0 To dgLibres.Items.Count - 1

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
        LlenadgLibres()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        nreloj.Value = Date.Now.ToShortTimeString
        LlenadgPrincipal()
        LlenadgLibres()
        MostrarMensajeClienteLlegando()
    End Sub

    Protected Sub timer2_tick()
        Session("pantalla") += 1
        Validaciones.cambiarPantalla()
    End Sub

    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

    End Sub
End Class
