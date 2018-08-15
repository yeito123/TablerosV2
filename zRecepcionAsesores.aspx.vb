Imports TablerosV2LibTypes
Partial Public Class zRecepcionAsesores
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '    If InStr(Page.AppRelativeVirtualPath, Session("URL")) = 0 Or Session("URL") Is Nothing Then Response.Redirect("Login.aspx")
        lblIdAsesor.Text = Session("idUsuario")
        lblIdAsesor.Visible = False
        If Not Page.IsPostBack Then
            LlenadgPrincipal()
            LlenadgLibres()
            MOSTRARRESUMEN()
        End If

    End Sub
    Sub MOSTRARRESUMEN()
         

        Dim dt As DataTable
        Dim sqry As String


        Dim inoshows As Integer = 0, ishows As Integer = 0, showspuntuales As Integer = 0
        Dim showsimpuntuales As Integer = 0, isCitas As Integer = 0
        Dim iCitas As Integer = 0

        sqry = " SELECT * from " & System.Web.Configuration.WebConfigurationManager.AppSettings("v_contadores_shows") & " "



        dt = BDClass.SQLtoDataTable(sqry, False)

        

        isCitas = dt.Select("cCita=0").Length
        iCitas = dt.Select("cCita=1").Length
        inoshows = dt.Select("cCita=1 and shows=0").Length
        ishows = dt.Select("cCita=1 and shows=1").Length

        showsimpuntuales = dt.Select("cCita=1 and showimpuntual=1").Length
        showspuntuales = dt.Select("cCita=1 and showpuntual=1").Length

 

         
        Dim SCONTROL As String
        SCONTROL = "<div style='border:none;background-color:transparent;position:absolute;top:0px;left:690px;width:370px;height:100px;'>"
        SCONTROL += "<table style='border:solid thin silver;background-color:transparent;font-size:10px;font-family:arial;'  cellspacing='1'>"

        SCONTROL += "<tr>"
        SCONTROL += "<td  align='center'>Total Citas</td><td  align='center'>Total sin Cita</td><td  align='cennter'>Shows</td><td  align='center'>No shows</td> <td  align='center'>Shows puntuales</td> <td  align='center'>Shows Impuntuales</td> "
        SCONTROL += "</td>"
        SCONTROL += "</tr>"
        SCONTROL += "<tr>"
        SCONTROL += "<td  align='center'>" & iCitas & "</td><td  align='center'>" & isCitas & "</td><td  align='center'>" & ishows & "</td><td  align='center'>" & inoshows & "</td><td  align='center'>" & showspuntuales & "</td><td  align='center'>" & showsimpuntuales & "</td> "
        SCONTROL += "</td>"
        SCONTROL += "</tr>"


        SCONTROL += "</table></div>"
        Dim obj1 As HtmlGenericControl = New HtmlGenericControl("div")
        obj1.InnerHtml = SCONTROL
        form1.Controls.Add(obj1)

    End Sub
    Sub LlenadgLibres()
        Dim dt As New DataTable
        Dim sqry As String = ""

        Dim ipage As Integer = dgLibres.CurrentPageIndex
        sqry = "select ROW_NUMBER() OVER( ORDER BY horallegada ASC ) as idVehiculo,VIN, NOPLACAS, FECHA,CLIENTE, vehiculo,ano as YEAR_MODELO, COLOR, horallegada, horaretiro,(select top 1 nombre from sccusuarios a where idasesor=isnull(a.cveAsesor,'') and isnull(a.cveAsesor,'')<>'' ) as asesor, 0 as cCita ,  horaIRecepcion, horaFRecepcion,  horaIEntrega, id_hd from " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " where convert(varchar,fecha,112)=convert(varchar,getdate(),112)   and  (not horallegada is null)  and horaretiro is null and isnull(numcita,0)=0 "


        dt = BDClass.SQLtoDataTable(sqry, False)
        Session("dtGrid1") = dt
        dgLibres.DataSource = dt
        dgLibres.DataBind()
        dgLibres.CurrentPageIndex = 0
        Session("dtGrid1") = dt


    End Sub
    Sub LlenadgPrincipal()

        Dim dt As New DataTable
        Dim sqry As String = ""

        Dim ipage As Integer = dg1.CurrentPageIndex
        sqry += " Select ROW_NUMBER() OVER( ORDER BY horallegada ASC ) as idVehiculo,VIN,NOPLACAS, FECHA,CLIENTE, vehiculo,'' as year_modelo, b.COLOR, left(convert(varchar,horallegada,108), 5) horallegada,left(convert(varchar,horaretiro,108), 5) horaretiro,left(convert(varchar,horaasesor,108), 5) horaasesor,idasesor, a.nombre as asesor, 1 as cCita, left(convert(varchar,horaIRecepcion,108), 5) horaIRecepcion,left(convert(varchar,horaFRecepcion,108), 5)  horaFRecepcion,left(convert(varchar,horaIEntrega,108), 5) horaIEntrega, numcita,id_hd "
        sqry += " from " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " b left outer join sccusuarios a on idasesor=a.cveasesor and    isnull(a.cveAsesor,'')<>''  "
        sqry += " where  convert(varchar,fecha,112)=convert(varchar,getdate(),112)   and isnull(numcita,'0')<>'0' and (not horallegada is null) and horaretiro is null  " 'AND IDASESOR='" & lblIdAsesor.Text & "' "

        dt = BDClass.SQLtoDataTable(sqry, False)
        Session("dtGrid") = dt
        dg1.DataSource = dt
        dg1.DataBind()
        dg1.CurrentPageIndex = 0
        Session("dtGrid") = dt


    End Sub

    Protected Sub chkInicio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sqry As String = ""

        If CType(sender, CheckBox).Checked = True Then
            If CType(sender, CheckBox).Checked Then
                sqry = " Update  "
                sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set horaIRecepcion=getdate(), idasesor='" & HttpContext.Current.Session("cveAsesor") & "' "
                sqry += " where   convert(varchar,fecha,12)=convert(varchar,getdate(),12)  and id_hd='" & dg1.Items(sender.parent.parent.itemindex).Cells(15).Text & "' "

                BDClass.ExecuteQuery(sqry, False)
                sqry = " Update  "
                sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set horaIRecepcion=getdate(), idasesor='" & HttpContext.Current.Session("cveAsesor") & "' "
                sqry += " where  convert(varchar,fecha,12)=convert(varchar,getdate(),12)  and id_hd='" & dg1.Items(sender.parent.parent.itemindex).Cells(15).Text & "' "

                BDClass.ExecuteQuery(sqry, False)


            Else

            End If
            LlenadgPrincipal()
            Session("noPlacas") = dg1.Items(sender.parent.parent.itemindex).Cells(2).Text
            'Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "Servicios", "<script>  var xwin=window.open('zRecepcionAsesoresServicios.aspx', '', 'status=no,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=no,modal=yes,dependable=no;');xwin.resizeTo(750,470);xwin.moveTo(0,0); </script>")

        Else

        End If
    End Sub
    Protected Sub chkFin_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sqry As String = ""

        If CType(sender, CheckBox).Checked = True Then
            If CType(sender, CheckBox).Checked Then
                sqry = " Update  "
                sqry += "    " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set horaFRecepcion=getdate() "
                sqry += " where  convert(varchar,fecha,12)=convert(varchar,getdate(),12)  and   id_hd='" & dg1.Items(sender.parent.parent.itemindex).Cells(15).Text & "'"

                BDClass.ExecuteQuery(sqry, False)
                sqry = " Update  "
                sqry += "    " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set horaFRecepcion=getdate() "
                sqry += " where  convert(varchar,fecha,12)=convert(varchar,getdate(),12)  and   id_hd='" & dg1.Items(sender.parent.parent.itemindex).Cells(15).Text & "'"

                BDClass.ExecuteQuery(sqry, False)
            Else

            End If
            txtOrden.Text = ""
            txtTorre.Text = ""
            txtFPromesa.Text = Date.Now.ToShortDateString & " "

            ' If dg1.Items(sender.parent.parent.itemindex).Cells(1).Text <> "&nbsp;" And Len(dg1.Items(sender.parent.parent.itemindex).Cells(1).Text.Trim) > 0 Then
            Session("numcita") = dg1.Items(sender.parent.parent.itemindex).Cells(14).Text
            Session("noPlacas") = dg1.Items(sender.parent.parent.itemindex).Cells(2).Text
            Session("VIN") = dg1.Items(sender.parent.parent.itemindex).Cells(1).Text
            Session("idhd") = dg1.Items(sender.parent.parent.itemindex).Cells(15).Text
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "Servicios", "<script>  var xwin=window.open('zRecepcionAsesoresServiciosOrden.aspx', '', 'status=no,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=no,modal=yes,dependable=yes;');xwin.resizeTo(750,470);xwin.moveTo(0,0); </script>")
            LlenadgPrincipal()
            MPGV.Show()
            LlenadgPrincipalServs()
            'End If

        End If
    End Sub
    

    Protected Sub chkSCInicio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sqry As String = ""

        If CType(sender, CheckBox).Checked = True Then
            If CType(sender, CheckBox).Checked Then
                sqry = " Update  "
                sqry += "    " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set horaIRecepcion=getdate(), idasesor='" & HttpContext.Current.Session("cveAsesor") & "' "
                sqry += " where  id_hd='" & dgLibres.Items(sender.parent.parent.itemindex).Cells(13).Text & "' "

                BDClass.ExecuteQuery(sqry, False)
            Else

            End If
            LlenadgLibres()

            If dgLibres.Items(sender.parent.parent.itemindex).Cells(1).Text <> "&nbsp;" And Len(dgLibres.Items(sender.parent.parent.itemindex).Cells(1).Text.Trim) > 0 Then
                Session("noPlacas") = dgLibres.Items(sender.parent.parent.itemindex).Cells(2).Text
                'Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "Servicios", "<script>  var xwin=window.open('zRecepcionAsesoresServicios.aspx', '', 'status=no,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=no,modal=yes,dependable=yes;');xwin.resizeTo(750,470);xwin.moveTo(0,0); </script>")

            End If

        Else

        End If
    End Sub

    Sub iMsgBox(ByVal s As String)
        Dim sControl As New HtmlGenericControl("div")
        sControl.ID = "divsMessage"
        sControl.Style.Value = "display:block;z-index:1000;position:absolute;top:0;left:0;width:100%;height:100%;margin:0 0 0 0;"
        sControl.InnerHtml = "<div style='filter:alpha(opacity=70);display:block;z-index:1001;position:absolute;top:0;left:0;width:100%;height:100%;margin:0 0 0 0;cursor:hand;background-color: #eeeeee;'></div><div style='z-index:1002;display:block;position:absolute;top:200px;left:300px;width:400px;border:solid 1px silver;text-align:center;font-variant:small-caps;font-family:Arial;font-size:14px;color:#000000;background-color:#02839B;'><table><tr><td style='background-color:Ivory;'>" & s & "</td></tr><tr><td><input type='button' value='OK' onclick='OcultaDiv();' style='width:100px;border:solid 2px black;background-color:#ffffff;cursor:hand;'/></td></tr></table></div>"
        Page.Form.Controls.Add(sControl)
        Page.ClientScript.RegisterClientScriptBlock(GetType(Page), "OcultaDiv", "<script>function OcultaDiv(){document.getElementById('divsMessage').style.display='none';} </script>")
    End Sub
    Protected Sub chkSCFin_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sqry As String = ""

        If CType(sender, CheckBox).Checked = True Then
            If CType(sender, CheckBox).Checked Then
                sqry = " Update  "
                sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set horaFRecepcion=getdate()"
                sqry += " where    id_hd='" & dgLibres.Items(sender.parent.parent.itemindex).Cells(13).Text & "' "

                BDClass.ExecuteQuery(sqry, False)

            Else

            End If

            txtOrden.Text = ""
            txtTorre.Text = ""
            txtFPromesa.Text = Date.Now.ToShortDateString & " "
            ' If dg1.Items(sender.parent.parent.itemindex).Cells(1).Text <> "&nbsp;" And Len(dg1.Items(sender.parent.parent.itemindex).Cells(1).Text.Trim) > 0 Then
            Session("numcita") = "0"
            Session("noPlacas") = dgLibres.Items(sender.parent.parent.itemindex).Cells(2).Text
            Session("VIN") = dgLibres.Items(sender.parent.parent.itemindex).Cells(1).Text
            Session("idhd") = dgLibres.Items(sender.parent.parent.itemindex).Cells(13).Text
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "Servicios", "<script>  var xwin=window.open('zRecepcionAsesoresServiciosOrden.aspx', '', 'status=no,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=no,modal=yes,dependable=yes;');xwin.resizeTo(750,470);xwin.moveTo(0,0); </script>")
            LlenadgLibres()
            MPGV.Show()
            LlenadgPrincipalServs()
            'End If
        End If
    End Sub

    Protected Sub imgSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSalir.Click
        Response.Redirect("inicio.aspx")
    End Sub



    Protected Sub dg1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg1.PreRender
        For i = 0 To dg1.Items.Count - 1


            If IsDate(dg1.Items(i).Cells(13).Text.Trim) Then
                CType(dg1.Items(i).FindControl("chkFin"), CheckBox).Checked = True
                CType(dg1.Items(i).FindControl("chkFin"), CheckBox).Enabled = False
            Else
                CType(dg1.Items(i).FindControl("chkFin"), CheckBox).Checked = False
                CType(dg1.Items(i).FindControl("chkFin"), CheckBox).Enabled = True
            End If

            If IsDate(dg1.Items(i).Cells(12).Text.Trim) Then
                CType(dg1.Items(i).FindControl("chkInicio"), CheckBox).Checked = True
                CType(dg1.Items(i).FindControl("chkInicio"), CheckBox).Enabled = False
            Else
                CType(dg1.Items(i).FindControl("chkInicio"), CheckBox).Checked = False
                CType(dg1.Items(i).FindControl("chkInicio"), CheckBox).Enabled = True
                CType(dg1.Items(i).FindControl("chkFin"), CheckBox).Enabled = False
            End If


        Next
    End Sub

    Protected Sub dgLibres_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgLibres.PreRender
        For i = 0 To dgLibres.Items.Count - 1



            If IsDate(dgLibres.Items(i).Cells(12).Text.Trim) Then
                CType(dgLibres.Items(i).FindControl("chkSCFin"), CheckBox).Checked = True
                CType(dgLibres.Items(i).FindControl("chkSCFin"), CheckBox).Enabled = False
            Else
                CType(dgLibres.Items(i).FindControl("chkSCFin"), CheckBox).Checked = False
                CType(dgLibres.Items(i).FindControl("chkSCFin"), CheckBox).Enabled = True
            End If

            If IsDate(dgLibres.Items(i).Cells(11).Text.Trim) Then
                CType(dgLibres.Items(i).FindControl("chkSCInicio"), CheckBox).Checked = True
                CType(dgLibres.Items(i).FindControl("chkSCInicio"), CheckBox).Enabled = False
            Else
                CType(dgLibres.Items(i).FindControl("chkSCInicio"), CheckBox).Checked = False
                CType(dgLibres.Items(i).FindControl("chkSCInicio"), CheckBox).Enabled = True
                CType(dgLibres.Items(i).FindControl("chkSCFin"), CheckBox).Enabled = False
            End If


        Next
    End Sub
    Sub LlenadgPrincipalServs()
        'Dim objAPP As New APPClass
        Dim DT As New DataTable

        LBLVIN.Text = Trim(Session("VIN"))
        LBLORDEN.Text = Session("numcita")
        LBLPLACAS.Text = Session("noPlacas")
        'gvServiciosH.DataSource = APPClassTableroPT.Obten_CONTROL_CITAS_DMSbyPlacas(LBLPLACAS.Text, LBLVIN.Text)
        'gvServiciosH.DataBind()


    End Sub
    Private Sub cmdServicios_Click(sender As Object, e As System.EventArgs) Handles cmdServicios.Click
        LlenadgPrincipalServs()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As System.EventArgs) Handles cmdGuardar.Click
        If txtOrden.Text.Trim.Length = 0 Or txtTorre.Text.Trim.Length = 0 Or txtFPromesa.Text.Trim.Length = 0 Then
            MPGV.Show()
            LlenadgPrincipalServs()
            Exit Sub
        End If
        Dim dfechapromesa As DateTime

        Try
            dfechapromesa = CDate(txtFPromesa.Text)
        Catch ex As Exception

        End Try


        Dim sqry As String
        sqry = "select "

        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set colorprisma='" & txtTorre.Text.Trim & "', fechaHoraPromesa=cast('" & String.Format("{0:s}", dfechapromesa) & "' as datetime), noorden='" & IIf(txtOrden.Text.Trim.Length = 0, "0", txtOrden.Text) & "' "
        sqry += " where     ID_HD=" & Session("idhd") & "  "

        BDClass.ExecuteQuery(sqry, False)

        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasRegistro") & " set colorprisma='" & txtTorre.Text.Trim & "', fecha_hora_com=cast('" & String.Format("{0:s}", dfechapromesa) & "' as datetime), noorden='" & IIf(txtOrden.Text.Trim.Length = 0, "0", txtOrden.Text) & "'  "
        sqry += " where    ID_HD=" & Session("idhd") & " "

        If BDClass.ExecuteQuery(sqry, False) <> "OK" Then
            MPGV.Show()
            LlenadgPrincipalServs()
        Else
            guardaTLavado()
        End If

    End Sub
    Sub guardaTLavado()
        Dim sLavado As String = RadioButtonList2.SelectedItem.Value
        If sLavado = "Normal" Then
            sLavado += " " & RadioButtonList1.SelectedItem.Value

        ElseIf sLavado = "Previo" Then
            sLavado += " " & RadioButtonList1.SelectedItem.Value

        End If

        sLavado = "Lavado: " & sLavado
        Dim sqry As String = ""
        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set Observaciones='" & sLavado & "'"
        sqry += " where     ID_HD=" & Session("idhd") & "   "

        BDClass.ExecuteQuery(sqry, False)

    End Sub

End Class

 