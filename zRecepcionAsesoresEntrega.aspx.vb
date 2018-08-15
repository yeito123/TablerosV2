Imports TablerosV2LibTypes

Partial Public Class zRecepcionAsesoresEntrega
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblIdAsesor.Text = Session("idUsuario")
        lblIdAsesor.Visible = False
        If Not Page.IsPostBack Then
            txtI.Text = Date.Now.ToShortDateString
            txtF.Text = Date.Now.ToShortDateString
            txtFind.Text = ""
            LlenadgPrincipal(CDate(txtI.Text), CDate(txtF.Text), txtFind.Text)
            LlenaAsesores()
            LlenaStatus()
        End If

    End Sub
    Sub rdlFiltro_SelectedIndexChanged()
        LlenadgPrincipal(CDate(txtI.Text), CDate(txtF.Text), txtFind.Text)
    End Sub
    Sub rdlStatus_SelectedIndexChanged()
        LlenadgPrincipal(CDate(txtI.Text), CDate(txtF.Text), txtFind.Text)
    End Sub

    Sub LlenaAsesores()

        Dim dt As New DataTable
        Dim sqry As String = ""

        Dim ipage As Integer = dg1.CurrentPageIndex
        sqry += " Select distinct nombre, cveasesor from sccusuarios  where (cveasesor<>'' and not cveasesor is null)"

        dt = BDClass.SQLtoDataTable(sqry, False)
        rdlAsesores.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            rdlAsesores.Items.Add(New ListItem(dt.Rows(i).Item(0), dt.Rows(i).Item(1)))

        Next

    End Sub
    Sub LlenaStatus()

        Dim dt As New DataTable
        Dim sqry As String = ""

        Dim ipage As Integer = dg1.CurrentPageIndex
        sqry += " Select distinct isnull(status, '')  status from TB_CITAS_HEADER_NW order by status"

        dt = BDClass.SQLtoDataTable(sqry, False)
        rdlStatus.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            rdlStatus.Items.Add(New ListItem(dt.Rows(i).Item(0), dt.Rows(i).Item(0)))

        Next

    End Sub
    Sub LlenadgPrincipalE()

        Dim dt As New DataTable
        Dim sqry As String = ""

        Dim ipage As Integer = dg1.CurrentPageIndex
        sqry += " Select ROW_NUMBER() OVER( ORDER BY horallegada ASC ) as idVehiculo,VIN,NOPLACAS, FECHA,CLIENTE, vehiculo,ano as year_modelo, b.COLOR, horallegada, horaretiro,horaasesor,idasesor, a.nombre as asesor, 1 as cCita,  horaFENTREGA, horaIEntrega, NOORDEN,  id_hd, TESTqa "
        sqry += " from TB_CITAS_HEADER_NW b inner join sccusuarios a on idasesor=a.cveasesor "
        sqry += " where     horaretiro is null  and (status='Terminado')  "


        dt = BDClass.SQLtoDataTable(sqry, False)
        Session("dtGrid") = dt
        dg1.DataSource = dt
        dg1.DataBind()
        dg1.CurrentPageIndex = 0
        Session("dtGrid") = dt


    End Sub
    Sub LlenadgPrincipal(i As Date, f As Date, s As String)

        Dim dt As New DataTable
        Dim sqry As String = "", sAse As String = "", sst As String = ""

        Dim ipage As Integer = dg1.CurrentPageIndex

        Try
            sase = rdlAsesores.SelectedItem.Value
        Catch ex As exception
            sase = ""
        End Try

        Try
            sst = rdlStatus.SelectedItem.Value
        Catch ex As exception
            sst = ""
        End Try




        If s.Trim.Length <> 0 Then
            sqry += " Select ROW_NUMBER() OVER( ORDER BY fecha desc ) as idVehiculo,VIN,NOPLACAS, FECHA,CLIENTE, vehiculo,ano as year_modelo, b.COLOR, horallegada, horaretiro,horaasesor,idasesor, a.nombre as asesor, 1 as cCita,  horaFENTREGA, horaIEntrega, NOORDEN,  id_hd, TESTqa, status, Horairecepcion, Horafrecepcion, Fecha_hora_com "
            sqry += " from TB_CITAS_HEADER_NW b left outer join sccusuarios a on idasesor=a.cveasesor "
            sqry += " where     noplacas like '%" & s & "%'  and fecha>=cast('" & String.Format("{0:s}", i) & "' as datetime) and fecha<=cast('" & String.Format("{0:s}", f) & "' as datetime)  and b.idasesor like '" & sAse & "%' and  isnull(status,'') like '" & sst & "%'  and isnull(status,'') like '%" & sst & "'    order by noorden "

        Else
            sqry += " Select ROW_NUMBER() OVER( ORDER BY fecha desc ) as idVehiculo,VIN,NOPLACAS, FECHA,CLIENTE, vehiculo,ano as year_modelo, b.COLOR, horallegada, horaretiro,horaasesor,idasesor, a.nombre as asesor, 1 as cCita,  horaFENTREGA, horaIEntrega, NOORDEN,  id_hd, TESTqa, status, Horairecepcion, Horafrecepcion, Fecha_hora_com, b.observaciones, b.fechahorapromesa "
            sqry += "  from TB_CITAS_HEADER_NW b left outer join sccusuarios a on idasesor=a.cveasesor "
            sqry += " where      fecha>=cast('" & String.Format("{0:s}", i) & "' as datetime) and fecha<=cast('" & String.Format("{0:s}", f) & "' as datetime)   and b.idasesor like '" & sAse & "%'  and  isnull(status,'') like '" & sst & "%'  and isnull(status,'') like '%" & sst & "'   order by noorden"

        End If



        'response.write(sqry)


        dt = BDClass.SQLtoDataTable(sqry, False)
        Session("dtGrid") = dt
        dg1.DataSource = dt
        dg1.DataBind()
        dg1.CurrentPageIndex = 0
        Session("dtGrid") = dt


    End Sub


    Protected Sub chkFin_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sqry As String = ""

        If CType(sender, CheckBox).Checked = True Then
            If CType(sender, CheckBox).Checked Then
                sqry = " Update  "
                sqry += "   TB_CITAS_HEADER_NW set horaFENTREGA=GETDATE() , Status_OS='ListoPEntrega' "
                sqry += " where id_hd=" & dg1.Items(sender.parent.parent.itemindex).Cells(19).Text & ""

                BDClass.ExecuteQuery(sqry, False)


            Else

            End If
            LlenadgPrincipal(CDate(txtI.Text), CDate(txtF.Text), txtFind.Text)

            If dg1.Items(sender.parent.parent.itemindex).Cells(1).Text <> "&nbsp;" And Len(dg1.Items(sender.parent.parent.itemindex).Cells(1).Text.Trim) > 0 Then
                Session("VIN") = dg1.Items(sender.parent.parent.itemindex).Cells(1).Text
                Session("noOrden") = dg1.Items(sender.parent.parent.itemindex).Cells(0).Text
                Session("noPlacas") = dg1.Items(sender.parent.parent.itemindex).Cells(2).Text
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "Servicios", "<script>  var xwin=window.open('zRecepcionAsesoresServiciosEntrega.aspx', '', 'status=no,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=yes,modal=yes,dependable=yes;');xwin.resizeTo(900,500);xwin.moveTo(0,0); </script>")

            End If
        End If
    End Sub
     Protected Sub chkInicioE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sqry As String = ""

        If CType(sender, CheckBox).Checked = True Then
            If CType(sender, CheckBox).Checked Then
                sqry = " Update  "
                sqry += "   TB_CITAS_HEADER_NW set horaIEntrega=GETDATE() "
                sqry += " where id_hd=" & dg1.Items(sender.parent.parent.itemindex).Cells(19).Text & ""

                BDClass.ExecuteQuery(sqry, False)
            Else

            End If
            LlenadgPrincipal(CDate(txtI.Text), CDate(txtF.Text), txtFind.Text)

            If dg1.Items(sender.parent.parent.itemindex).Cells(1).Text <> "&nbsp;" And Len(dg1.Items(sender.parent.parent.itemindex).Cells(1).Text.Trim) > 0 Then
                Session("VIN") = dg1.Items(sender.parent.parent.itemindex).Cells(1).Text
                Session("noOrden") = dg1.Items(sender.parent.parent.itemindex).Cells(0).Text
                Session("noPlacas") = dg1.Items(sender.parent.parent.itemindex).Cells(2).Text
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "Servicios", "<script>  var xwin=window.open('zRecepcionAsesoresServiciosOrdenB.aspx', '', 'status=no,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=no,modal=yes,dependable=yes;');xwin.resizeTo(750,470);xwin.moveTo(0,0); </script>")

            End If
        End If
    End Sub

    Protected Sub imgSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSalir.Click
        Response.Redirect("inicio.aspx")
    End Sub
    Sub iMsgBox(ByVal s As String)
        Dim sControl As New HtmlGenericControl("div")
        sControl.ID = "divsMessage"
        sControl.Style.Value = "display:block;z-index:1000;position:absolute;top:0;left:0;width:100%;height:100%;margin:0 0 0 0;"
        sControl.InnerHtml = "<div style='filter:alpha(opacity=70);display:block;z-index:1001;position:absolute;top:0;left:0;width:100%;height:100%;margin:0 0 0 0;cursor:hand;background-color: #eeeeee;'></div><div style='z-index:1002;display:block;position:absolute;top:200px;left:300px;width:400px;border:solid 1px silver;text-align:center;font-variant:small-caps;font-family:Arial;font-size:14px;color:#000000;background-color:#02839B;'><table><tr><td style='background-color:Ivory;'>" & s & "</td></tr><tr><td><input type='button' value='OK' onclick='OcultaDiv();' style='width:100px;border:solid 2px black;background-color:#ffffff;cursor:hand;'/></td></tr></table></div>"
        Page.Form.Controls.Add(sControl)
        Page.ClientScript.RegisterClientScriptBlock(GetType(Page), "OcultaDiv", "<script>function OcultaDiv(){document.getElementById('divsMessage').style.display='none';} </script>")
    End Sub

    Protected Sub dg1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg1.PreRender
        For i = 0 To dg1.Items.Count - 1


            If IsDate(dg1.Items(i).Cells(17).Text.Trim) Then
                CType(dg1.Items(i).FindControl("chkFin"), CheckBox).Checked = True
                CType(dg1.Items(i).FindControl("chkFin"), CheckBox).Enabled = False
            Else
                CType(dg1.Items(i).FindControl("chkFin"), CheckBox).Checked = False
                CType(dg1.Items(i).FindControl("chkFin"), CheckBox).Enabled = True

            End If

            If IsDate(dg1.Items(i).Cells(16).Text.Trim) Then
                CType(dg1.Items(i).FindControl("chkInicioE"), CheckBox).Checked = True
                CType(dg1.Items(i).FindControl("chkInicioE"), CheckBox).Enabled = False
            Else
                CType(dg1.Items(i).FindControl("chkInicioE"), CheckBox).Checked = False
                CType(dg1.Items(i).FindControl("chkInicioE"), CheckBox).Enabled = True
                CType(dg1.Items(i).FindControl("chkFin"), CheckBox).Enabled = False
            End If
            


        Next
    End Sub



    Protected Sub cmdBuscar_Click(sender As Object, e As System.EventArgs) Handles cmdBuscar.Click
        LlenadgPrincipal(CDate(txtI.Text), CDate(txtF.Text), txtFind.Text)
    End Sub
End Class


 