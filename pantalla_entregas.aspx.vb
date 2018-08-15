Imports TablerosV2LibTypes

Public Class pantalla_entregas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer13.Interval = Session("tiempoPantalla") * 1000
        Me.titulo.Text = Session("nombreAgencia")
        If Not Page.IsPostBack Then
            LlenadgPrincipal()
        End If

    End Sub

    Sub LlenadgPrincipal()
        Dim dt As New DataTable
        Dim sqry As String = ""

        Dim ipage As Integer = dg1.CurrentPageIndex

        sqry = "select numcita, nombre_empleado, horaasesor, noplacas, cliente, serviciocapturado, color, vehiculo, horapromesa, estatus_orden, porcentaje from [dbo].[V_ENTREGAS_ALL] order by horapromesa asc"
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
        Dim ttime As TimeSpan, ttimenow As TimeSpan
        For i = 0 To dg1.Items.Count - 1

            'If dg1.Items(i).Cells(9).Text.Trim = "0" Then
            '    dg1.Items(i).BackColor = Drawing.Color.Snow
            '    dg1.Items(i).ForeColor = Drawing.Color.Black
            'Else
            '    dg1.Items(i).BackColor = Drawing.Color.LightSteelBlue
            '    dg1.Items(i).ForeColor = Drawing.Color.White
            'End If

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
                    If (ttimenow - ttime).Minutes < 10 And (ttimenow - ttime).Minutes > 0 Then
                        CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "A tiempo"
                    ElseIf (ttimenow - ttime).Minutes = 0 Then
                        CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "A tiempo"
                    ElseIf (ttimenow - ttime).Minutes < -0 Then
                        CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "Anticipado"
                    ElseIf (ttimenow - ttime).Minutes > 10 Then
                        CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "Demorado"
                    End If
                Else
                    ttimenow = New TimeSpan(Now.Hour, Now.Minute, Now.Second)
                    CType(dg1.Items(i).FindControl("lblArribo"), Label).Text = "No llega"
                    If (ttimenow - ttime).Minutes > -10 And (ttimenow - ttime).Minutes < 10 Then
                        CType(dg1.Items(i).FindControl("imgGreen"), HtmlImage).Style("display") = "none"
                        CType(dg1.Items(i).FindControl("imgYellow"), HtmlImage).Style("display") = "block"
                        CType(dg1.Items(i).FindControl("imgRed"), HtmlImage).Style("display") = "none"
                    ElseIf (ttimenow - ttime).Minutes > 10 Then
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

    Protected Sub Timer11_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer11.Tick
        nreloj.Value = Date.Now.ToShortTimeString
        LlenadgPrincipal()

    End Sub

    Protected Sub Timer13_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer13.Tick
        Session("pantalla") += 1
        Validaciones.cambiarPantalla()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        nreloj.Value = Date.Now.ToShortTimeString
        LlenadgPrincipal()

        'LlenadgLibres()

    End Sub

End Class