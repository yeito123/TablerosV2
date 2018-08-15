Imports TablerosV2LibTypes

Partial Public Class zRecepcionAsesoresC
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
    Protected Sub rdlLavado_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim sinf1 As String
        Dim sinf2 As String, sqry As String
        If sender.parent.parent.parent.parent.id = dg1.ID Then
            sinf1 = CType(CType(sender.parent.parent.parent.parent, DataGrid).Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("rdlLavado"), RadioButtonList).SelectedItem.Value
            sinf2 = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd
        Else
            sinf1 = CType(CType(sender.parent.parent.parent.parent, DataGrid).Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("rdlLavado"), RadioButtonList).SelectedItem.Value
            sinf2 = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(13).Text 'id_hd
        End If

        If sinf1 <> "00" Then
            sqry = " Update  "
            sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set tipolavado='" & Left(sinf1, 1) & "' "
            sqry += " where     id_hd =" & sinf2 & " "

            BDClass.ExecuteQuery(sqry, False)
        Else
            sqry = " INSERT into tb_citas (idAsesor, idTecnico, fecha, noPlacas, Cliente, Vehiculo, Color, Ano, Cilindros, Servicio, tipoCliente, noOrden, horaAsesor, conCita, enUso, idServicio, vin, servicioCapturado, CarryOver, Status, vhRecepcion, vhInventario, numcita, colorPrisma, observaciones, id_hd) "
            sqry += " select top 1 idAsesor, null, fecha, noPlacas, Cliente, Vehiculo, Color, Ano, Cilindros, 30, tipoCliente, noOrden, horaAsesor, case when NUMCITA<>'0' then 1   else 0 end, 0, '151', vin, 'Lavado', null, 'EN LAVADO', 0, 0, numcita, colorPrisma, comentariosLavado , id_hd"
            sqry += " from tb_citas_header_nw where  id_hd =" & sinf2 & " "

            BDClass.ExecuteQuery(sqry, False)

            sqry = " UPDATE tb_citas_header_nw  set tipolavado='1' "
            sqry += "     where  id_hd =" & sinf2 & " "

            BDClass.ExecuteQuery(sqry, False)
        End If
        LlenadgPrincipal()
        LlenadgLibres()

    End Sub
    Protected Sub lnkFecha_Hora_Com_Click(ByVal sender As Object, ByVal e As EventArgs)


        lblOp.Text = 1
        If sender.parent.parent.parent.parent.id = dg1.ID Then
            lblInf1.Text = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
            lblInf2.Text = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd
            lblInf3.Text = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(10).Text.Trim 'torre
        Else
            lblInf1.Text = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
            lblInf2.Text = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(13).Text 'id_hd
            lblInf3.Text = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(10).Text.Trim 'torre
        End If
        lblMSG.Text = ""

        lbllblModComentarios.Visible = False
        lbllblModfecha.Visible = True

        txtModComentarios.Visible = False
        txtModFecha.Visible = True

        txtModFecha.Style.Item("display") = "block"
        txtModComentarios.Style.Item("display") = "none"

        lbllblModComentarios.Style.Item("display") = "none"
        lbllblModfecha.Style.Item("display") = "block"

        MPGV2.Show()


    End Sub

    Protected Sub lnkObservaciones_Click(ByVal sender As Object, ByVal e As EventArgs)


        lblOp.Text = 2
        If sender.parent.parent.parent.parent.id = dg1.ID Then
            lblInf1.Text = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
            lblInf2.Text = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd
            lblInf3.Text = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(10).Text.Trim 'torre
        Else
            lblInf1.Text = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
            lblInf2.Text = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(13).Text 'id_hd
            lblInf3.Text = sender.parent.parent.parent.parent.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(10).Text.Trim 'torre
        End If

        lblMSG.Text = ""

        lbllblModComentarios.Visible = True
        lbllblModfecha.Visible = False

        txtModComentarios.Visible = True
        txtModFecha.Visible = False

        txtModFecha.Style.Item("display") = "none"
        txtModComentarios.Style.Item("display") = "block"

        lbllblModComentarios.Style.Item("display") = "block"
        lbllblModfecha.Style.Item("display") = "none"

        MPGV2.Show()

    End Sub


    Sub LlenadgLibres()
        Dim dt As New DataTable
        Dim sqry As String = ""

        Dim ipage As Integer = dgLibres.CurrentPageIndex
        sqry += " Select * "
        sqry += " from " & System.Web.Configuration.WebConfigurationManager.AppSettings("v_zrececpcionDSC") & ""


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
        sqry += " Select * "
        sqry += " from " & System.Web.Configuration.WebConfigurationManager.AppSettings("v_zrececpcionDCC") & ""

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



            Session("numcita") = dg1.Items(sender.parent.parent.itemindex).Cells(14).Text
            Session("noPlacas") = dg1.Items(sender.parent.parent.itemindex).Cells(2).Text
            Session("VIN") = dg1.Items(sender.parent.parent.itemindex).Cells(1).Text
            Session("idhd") = dg1.Items(sender.parent.parent.itemindex).Cells(15).Text
            LlenadgPrincipal()

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

                sqry = "update d SET  d.noOrden=b.noOrden,d.Fecha_hora_com=b.fecha_hora_com"
                sqry += "	FROM  dbo.Tb_CITAS_HEADER_NW d INNER JOIN dbo.v_interfaz_dms b"
                sqry += "	on d.VIN collate Latin1_General_CI_AS=b.vin"
                sqry += "	WHERE  (isnull(d.noOrden,0) =0)  "
                sqry += "	and d.id_hd='" & dgLibres.Items(sender.parent.parent.itemindex).Cells(13).Text & "'"


                BDClass.ExecuteQuery(sqry, False)


                sqry = " UPDATE A SET a.noOrden=b.NOORDEN,a.Fecha_hora_com=b.fecha_hora_com "
                sqry += "	FROM dbo.Tb_CITAS A INNER JOIN dbo.Tb_CITAS_HEADER_NW B"
                sqry += "   on a.id_hd=b.id_hd WHERE  isnull(a.noorden,0)=0    "
                sqry += "   and b.id_hd='" & dgLibres.Items(sender.parent.parent.itemindex).Cells(13).Text & "'"

                BDClass.ExecuteQuery(sqry, False)
            Else

            End If



            ' If dg1.Items(sender.parent.parent.itemindex).Cells(1).Text <> "&nbsp;" And Len(dg1.Items(sender.parent.parent.itemindex).Cells(1).Text.Trim) > 0 Then
            Session("numcita") = "0"
            Session("noPlacas") = dgLibres.Items(sender.parent.parent.itemindex).Cells(2).Text
            Session("VIN") = dgLibres.Items(sender.parent.parent.itemindex).Cells(1).Text
            Session("idhd") = dgLibres.Items(sender.parent.parent.itemindex).Cells(13).Text
            'Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "Servicios", "<script>  var xwin=window.open('zRecepcionAsesoresServiciosOrden.aspx', '', 'status=no,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=no,modal=yes,dependable=yes;');xwin.resizeTo(750,470);xwin.moveTo(0,0); </script>")
            LlenadgLibres()
            ' txtFPromesa.Text = Date.Now.ToShortDateString & " "
            'MPGV.Show()
            ' LlenadgPrincipalServs()
            'End If
        End If
    End Sub

    Protected Sub imgSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSalir.Click
        Response.Redirect("inicio.aspx")
    End Sub



    Protected Sub dg1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg1.PreRender
        Dim sqry As String
        Dim dt As New DataTable
        sqry = " SELECT * from  SccTiposLavado "


        dt = BDClass.SQLtoDataTable(sqry, False)

        For i = 0 To dg1.Items.Count - 1

            If Not dg1.DataSource Is Nothing Then
                CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).DataSource = dt
                CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).DataTextField = "Descripcion"
                CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).DataValueField = "tipoLavado"
                CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).DataBind()
                CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).Items.Add(New ListItem("Lavar Ahora", "00"))




                If CType(dg1.DataSource, DataTable).Rows(i).Item("tipoLavado") Is DBNull.Value Then
                    CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).SelectedIndex = 0
                Else
                    CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).SelectedIndex = CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).Items.IndexOf(CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).Items.FindByValue(CType(dg1.DataSource, DataTable).Rows(i).Item("tipoLavado")))

                End If
            End If
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
        Dim sqry As String
        Dim dt As New DataTable
        sqry = " SELECT * from  SccTiposLavado "


        dt = BDClass.SQLtoDataTable(sqry, False)


        For i = 0 To dgLibres.Items.Count - 1

            If Not dgLibres.DataSource Is Nothing Then
                CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).DataSource = dt
                CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).DataTextField = "Descripcion"
                CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).DataValueField = "tipoLavado"
                CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).DataBind()
                CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).Items.Add(New ListItem("Lavar Ahora", "00"))

                If CType(dgLibres.DataSource, DataTable).Rows(i).Item("tipoLavado") Is DBNull.Value Then
                    CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).SelectedIndex = 0
                Else

                    CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).SelectedIndex = CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).Items.IndexOf(CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).Items.FindByValue(CType(dgLibres.DataSource, DataTable).Rows(i).Item("tipoLavado")))


                End If
            End If
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



    End Sub
    Private Sub cmdServicios_Click(sender As Object, e As System.EventArgs) Handles cmdServicios.Click
        LlenadgPrincipalServs()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As System.EventArgs) Handles cmdGuardar.Click



        Dim sqry As String
        sqry = "select "

        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set colorprisma='" & txtTorre.Text.Trim & "', noorden='" & IIf(txtOrden.Text.Trim.Length = 0, "0", txtOrden.Text) & "' "
        sqry += " where     ID_HD=" & Session("idhd") & "  "

        BDClass.ExecuteQuery(sqry, False)

        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasRegistro") & " set colorprisma='" & txtTorre.Text.Trim & "', noorden='" & IIf(txtOrden.Text.Trim.Length = 0, "0", txtOrden.Text) & "'  "
        sqry += " where    ID_HD=" & Session("idhd") & " "


        If BDClass.ExecuteQuery(sqry, False) <> "OK" Then
            MPGV.Show()
            LlenadgPrincipalServs()
        Else
            'guardaTLavado()
        End If

    End Sub

    'Sub guardaTLavado()
    '    Dim sLavado As String = RadioButtonList2.SelectedItem.Value
    '    If sLavado = "Normal" Then
    '        sLavado += " " & RadioButtonList1.SelectedItem.Value

    '    ElseIf sLavado = "Previo" Then
    '        sLavado += " " & RadioButtonList1.SelectedItem.Value

    '    End If

    '    sLavado = "Lavado: " & sLavado
    '    Dim sqry As String = ""
    '    sqry = " Update  "
    '    sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set Observaciones='" & sLavado & "'"
    '    sqry += " where     ID_HD=" & Session("idhd") & "   "

    '    BDClass.ExecuteQuery(sqry, False)

    'End Sub
    Sub guardarfecha(sIdHd As String, svalor As String)
        Dim sqry As String = ""
        ''  If InStr(txtModFecha.Text.ToLower, "&nbsp;") > 0 Or IsDate(txtModFecha.Text.ToLower) = False Then lblInf1.Text = ""

        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set fecha_hora_com=cast('" & String.Format("{0:s}", CDate(svalor)) & "' as datetime) "
        sqry += " where     id_hd =" & sIdHd & " "

        BDClass.ExecuteQuery(sqry, False)

    End Sub
    Sub guardarComentarios(sIdHd As String, svalor As String)
        Dim sqry As String = ""
        ''  If InStr(txtModFecha.Text.ToLower, "&nbsp;") > 0 Or IsDate(txtModFecha.Text.ToLower) = False Then lblInf1.Text = ""

        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set comentariosLavado='" & Left(svalor, 250) & "' "
        sqry += " where     id_hd =" & sIdHd & " "

        BDClass.ExecuteQuery(sqry, False)

    End Sub
    Private Sub OkButtonMPGV2_Click(sender As Object, e As EventArgs) Handles OkButtonMPGV2.Click

        Select Case lblOp.Text
            Case "1"
                guardarfecha(lblInf2.Text, txtModFecha.Text)
            Case "2"
                guardarComentarios(lblInf2.Text, txtModComentarios.Text)
            Case "21"
                'GuardaLavado(lblInf2, lblInf3.Text)

        End Select
        txtModFecha.Style.Item("display") = "none"
        lbllblModfecha.Style.Item("display") = "none"
        txtModComentarios.Style.Item("display") = "none"
        lbllblModComentarios.Style.Item("display") = "none"

        '   MOSTRARRESUMEN()
        LlenadgPrincipal()
        LlenadgLibres()

    End Sub

End Class

 