Imports TablerosV2LibTypes
Partial Public Class _zRecepcionAsesoresD
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '    If InStr(Page.AppRelativeVirtualPath, Session("URL")) = 0 Or Session("URL") Is Nothing Then Response.Redirect("Login.aspx")
        lblIdAsesor.Text = Session("idUsuario")
        lblIdAsesor.Visible = False
        If Not Page.IsPostBack Then
            txtCalendar.Text = Date.Now.ToShortDateString
            LlenadgPrincipal(txtCalendar.Text)
            LlenadgLibres(txtCalendar.Text)

        End If

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
            sqry += " select top 1 idAsesor, null, (select getdate()), noPlacas, Cliente, Vehiculo, Color, Ano, Cilindros, 60, tipoCliente, noOrden, horaAsesor, case when NUMCITA<>'0' then 1   else 0 end, 0, '151', vin, 'Lavado', null, 'EN LAVADO', 0, 0, numcita, colorPrisma, comentariosLavado , id_hd"
            sqry += " from tb_citas_header_nw where  id_hd =" & sinf2 & " "

            BDClass.ExecuteQuery(sqry, False)

            sqry = " UPDATE tb_citas_header_nw  set tipolavado='00' "
            sqry += "     where  id_hd =" & sinf2 & " "

            BDClass.ExecuteQuery(sqry, False)
        End If
        LlenadgPrincipal(txtCalendar.Text)
        LlenadgLibres(txtCalendar.Text)

    End Sub
 
    Sub LlenadgLibres(sfecha As String)
        Dim dt As New DataTable
        Dim sqry As String = ""

        Dim ipage As Integer = dgLibres.CurrentPageIndex
        Try
            sqry += " Select * "
            sqry += " from " & System.Web.Configuration.WebConfigurationManager.AppSettings("v_zrececpcionDLibres") & "  where convert(varchar,fecha,12)=convert(varchar,cast('" & String.Format("{0:s}", CDate(sfecha)) & "' as datetime),12) and isnull(idasesor, '')<>'" & Session("cveAsesor") & "'"


            dt = BDClass.SQLtoDataTable(sqry, False)
            Session("dgnrecepcionAsesores") = dt
            dgLibres.DataSource = dt
            dgLibres.DataBind()
            dgLibres.CurrentPageIndex = 0
            Session("dgnrecepcionAsesores") = dt

        Catch ex As Exception

        End Try


    End Sub
    Sub LlenadgPrincipal(sFecha As String)
        Dim dt As New DataTable
        Dim sqry As String = ""

        Dim ipage As Integer = dg1.CurrentPageIndex
        Try

            sqry += " Select * "
            sqry += " from " & System.Web.Configuration.WebConfigurationManager.AppSettings("v_zrececpcionDCC") & " where convert(varchar,fecha,12)=convert(varchar,cast('" & String.Format("{0:s}", CDate(sFecha)) & "' as datetime),12) and isnull(idasesor, '')='" & Session("cveAsesor") & "'"

            dt = BDClass.SQLtoDataTable(sqry, False)
            Session("dtGrid") = dt
            dg1.DataSource = dt
            dg1.DataBind()
            dg1.CurrentPageIndex = 0
            Session("dtGrid") = dt
        Catch ex As Exception

        End Try



    End Sub
    Sub MosttrarOcultar(SOPCION As String, sinf As String)
        
        lblModfecha.Visible = False
        txtModFecha.Visible = False
        lblModComentarios.Visible = False
        txtModComentarios.Visible = False
         
        lblTorre.Visible = False
        txtTorre.Visible = False
        lblOrden.Visible = False
        txtOrden.Visible = False


        
        lblMSG.Text = ""
        lblInf1.Text = Split(sinf, "__")(0) ' id_hd
        lblInf2.Text = Split(sinf, "__")(1) 'hora llegada
        'Eval("idve") & "__" & If(Eval("horallegada") Is DBNull.Value, "00:00", Eval("horallegada")) & "__" & Eval("Cliente") & "__" & Eval("noplacas") & "__" & Eval("VIN") & "__" & Eval("fecha_hora_com") & "__" & Eval("vehiculo") & "__" & Eval("colorprisma")
        Select Case SOPCION
            Case "Ini1"

                lblMSG.Text = "Desea Iniciar Recepcion? "


            Case "Ini2"

                lblMSG.Text = "Desea Deshacer Inicio de Recepcion? "

            Case "Fin1"

                lblMSG.Text = "Desea Finalizar Recepcion? "
                If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "RecepAsesorCaptOs").ToString = "1" Then
                    lblMSG.Text = " Capture numero de Orden"
                    lblTorre.Visible = True
                    txtTorre.Visible = True
                    lblOrden.Visible = True
                    txtOrden.Visible = True
                    txtTorre.Text = Split(sinf, "__")(5)
                    txtOrden.Text = Split(sinf, "__")(6)

                End If


            Case "Fin2"

                lblMSG.Text = "Desea Deshacer Fin de Recepcion? "

                'If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "RecepAsesorCaptOs").ToString = "1" Then
                '    lblMSG.Text = " Capture numero de Orden"
                '    lblTorre.Visible = True
                '    txtTorre.Visible = True
                '    lblOrden.Visible = True
                '    txtOrden.Visible = True
                '    txtTorre.Text = Split(sinf, "__")(5)
                '    txtOrden.Text = Split(sinf, "__")(6)

                'End If


            Case "COMENTARIOS"

                lblMSG.Text = "Agregar Comentarios "

                lblModComentarios.Visible = True
                txtModComentarios.Visible = True
                txtModComentarios.Text = Split(sinf, "__")(7)


            Case "ENTREGA"

                lblMSG.Text = "Fecha Promesa"
                lblModfecha.Visible = True
                txtModFecha.Visible = True
                txtModFecha.Text = Split(sinf, "__")(8)

            Case "ORDEN"
                lblMSG.Text = "Agregar numero de orden"
                lblTorre.Visible = True
                txtTorre.Visible = True
                lblOrden.Visible = True
                txtOrden.Visible = True
                txtTorre.Text = Split(sinf, "__")(5)
                txtOrden.Text = Split(sinf, "__")(6)







        End Select

    End Sub

    Protected Sub lnkObservaciones_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim sinf As String = CType(dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text
        lblOp.Text = 3

        MosttrarOcultar("COMENTARIOS", sinf)
        MPGV.Show()

    End Sub

    Protected Sub lnkFecha_Hora_Com_Click(ByVal sender As Object, ByVal e As EventArgs)


        Dim sinf As String = CType(dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text
        lblOp.Text = 4

        MosttrarOcultar("ENTREGA", sinf)
        MPGV.Show()


    End Sub




    Protected Sub chkInicio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sinf As String = CType(dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text


        If CType(sender, CheckBox).Checked = True Then
            lblOp.Text = 1
            MosttrarOcultar("Ini1", sinf)

        Else
            lblOp.Text = 11
            MosttrarOcultar("Ini2", sinf)

        End If

      
        MPGV.Show()



      
    End Sub
    Protected Sub chkFin_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sinf As String = CType(dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text
        lblOp.Text = 2

        If CType(sender, CheckBox).Checked = True Then
            lblOp.Text = 2
            MosttrarOcultar("Fin1", sinf)
        Else
            lblOp.Text = 21

            MosttrarOcultar("Fin2", sinf)
        End If


        MPGV.Show()
    End Sub


    Protected Sub chkSCInicio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sinf As String = CType(dgLibres.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text


        If CType(sender, CheckBox).Checked = True Then
            lblOp.Text = 1
            MosttrarOcultar("Ini1", sinf)

        Else
            lblOp.Text = 11
            MosttrarOcultar("Ini2", sinf)

        End If


        MPGV.Show()
    End Sub

    Protected Sub chkSCFin_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sinf As String = CType(dgLibres.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text
        lblOp.Text = 2

        If CType(sender, CheckBox).Checked = True Then
            lblOp.Text = 2
            MosttrarOcultar("Fin1", sinf)
        Else
            lblOp.Text = 21

            MosttrarOcultar("Fin2", sinf)
        End If


        MPGV.Show()
    End Sub

    Sub iMsgBox(ByVal s As String)
        Dim sControl As New HtmlGenericControl("div")
        sControl.ID = "divsMessage"
        sControl.Style.Value = "display:block;z-index:1000;position:absolute;top:0;left:0;width:100%;height:100%;margin:0 0 0 0;"
        sControl.InnerHtml = "<div style='filter:alpha(opacity=70);display:block;z-index:1001;position:absolute;top:0;left:0;width:100%;height:100%;margin:0 0 0 0;cursor:hand;background-color: #eeeeee;'></div><div style='z-index:1002;display:block;position:absolute;top:200px;left:300px;width:400px;border:solid 1px silver;text-align:center;font-variant:small-caps;font-family:Arial;font-size:14px;color:#000000;background-color:#02839B;'><table><tr><td style='background-color:Ivory;'>" & s & "</td></tr><tr><td><input type='button' value='OK' onclick='OcultaDiv();' style='width:100px;border:solid 2px black;background-color:#ffffff;cursor:hand;'/></td></tr></table></div>"
        Page.Form.Controls.Add(sControl)
        Page.ClientScript.RegisterClientScriptBlock(GetType(Page), "OcultaDiv", "<script>function OcultaDiv(){document.getElementById('divsMessage').style.display='none';} </script>")
    End Sub
    Sub fin(chk As Boolean, idhd As String)
        Dim sqry As String = ""

        If chk Then
            sqry = " Update  "
            sqry += "    " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set horaFRecepcion=getdate() "
            sqry += " where  convert(varchar,fecha,12)=convert(varchar,getdate(),12)  and   id_hd='" & idhd & "'"

           

            BDClass.ExecuteQuery(sqry, False)
        Else

            sqry = " Update  "
            sqry += "    " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set horaFRecepcion=NULL "
            sqry += " where  convert(varchar,fecha,12)=convert(varchar,getdate(),12)  and   id_hd='" & idhd & "'"

            BDClass.ExecuteQuery(sqry, False)
        End If

        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "RecepAsesorCaptOs").ToString = "1" Then
            sqry = " Update  "
            sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set colorprisma='" & txtTorre.Text.Trim & "', noorden='" & IIf(txtOrden.Text.Trim.Length = 0, "0", txtOrden.Text) & "' "
            sqry += " where     ID_HD='" & idhd & "'  "
            BDClass.ExecuteQuery(sqry, False)
        End If

         

    End Sub
    Sub inicio(chk As Boolean, idhd As String)
        Dim sqry As String = ""

        If chk Then
            sqry = " Update  "
            sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set horaIRecepcion=getdate(), idasesor='" & HttpContext.Current.Session("cveAsesor") & "' "
            sqry += " where   convert(varchar,fecha,12)=convert(varchar,getdate(),12)  and id_hd='" & idhd & "' "

            BDClass.ExecuteQuery(sqry, False)

        Else
            sqry = " Update  "
            sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set horaIRecepcion=NULL, idasesor='" & HttpContext.Current.Session("cveAsesor") & "' "
            sqry += " where  convert(varchar,fecha,12)=convert(varchar,getdate(),12)  and id_hd='" & idhd & "' "

            BDClass.ExecuteQuery(sqry, False)



        End If
        
         
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
            


                If CType(dg1.DataSource, DataTable).Rows(i).Item("tipoLavado") Is DBNull.Value Then
                    CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).SelectedIndex = -1
                Else
                    CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).SelectedIndex = CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).Items.IndexOf(CType(dg1.Items(i).FindControl("rdlLavado"), RadioButtonList).Items.FindByValue(CType(dg1.DataSource, DataTable).Rows(i).Item("tipoLavado")))

                End If
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


                If CType(dgLibres.DataSource, DataTable).Rows(i).Item("tipoLavado") Is DBNull.Value Then
                    CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).SelectedIndex = -1
                Else

                    CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).SelectedIndex = CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).Items.IndexOf(CType(dgLibres.Items(i).FindControl("rdlLavado"), RadioButtonList).Items.FindByValue(CType(dgLibres.DataSource, DataTable).Rows(i).Item("tipoLavado")))


                End If
            End If
            


        Next
    End Sub
    

  
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
    Private Sub OkButtonMPGV_Click(sender As Object, e As EventArgs) Handles OkButtonMPGV.Click

        Select Case lblOp.Text
            Case "1"
                inicio(True, lblInf1.Text)
                ' guardarfecha(lblInf2.Text, txtModFecha.Text)
            Case "11"
                inicio(False, lblInf1.Text)
                ' guardarfecha(lblInf2.Text, txtModFecha.Text)
            Case "2"
                fin(True, lblInf1.Text)
                '  guardarComentarios(lblInf2.Text, txtModComentarios.Text)
            Case "21"
                fin(False, lblInf1.Text)

            Case "3"
                guardarComentarios(lblInf1.Text, txtModComentarios.Text.Trim)

            Case "4"
                guardarfecha(lblInf1.Text, txtModFecha.Text.Trim)
        End Select
     
        LlenadgPrincipal(txtCalendar.Text)
        LlenadgLibres(txtCalendar.Text)

    End Sub

    Private Sub txtCalendar_TextChanged(sender As Object, e As EventArgs) Handles txtCalendar.TextChanged
        LlenadgPrincipal(txtCalendar.Text)
        LlenadgLibres(txtCalendar.Text)
    End Sub
End Class

 