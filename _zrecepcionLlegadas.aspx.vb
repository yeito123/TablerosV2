Imports TablerosV2LibTypes
Partial Class _zRecepcionLlegadas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            LlenadgPrincipal()

  
        End If

    End Sub

    Protected Sub imgDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)


        lblOp.Text = 2
        lblInf1.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
        lblInf2.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd
        lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(2).Text.Trim 'cliente
        lblMSG.Text = ""

        mOSTTRARoCULTAR("ELIMINAR")

        MPGV.Show()



    End Sub

    Sub ELIMINAR(IDHD As String)
        Dim sqry As String = ""
 

        sqry = "delete  tb_citas_header_nw  where id_hd='" & IDHD & "' "

        BDClass.ExecuteQuery(sqry, False)
        LlenadgPrincipal()


    End Sub
    Sub LlenadgPrincipal()
        Dim dt As New DataTable
        Dim sqry As String = ""

        Dim ipage As Integer = dg1.CurrentPageIndex
 
        sqry = " select * from v_header_recepcion order by horaasesor asc"



        dt = BDClass.SQLtoDataTable(sqry, False)
        Session("dtGrid") = dt
        dg1.DataSource = dt
        dg1.DataBind()
        dg1.CurrentPageIndex = 0


    End Sub
  

    Protected Sub dg1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dg1.PageIndexChanged
        dg1.CurrentPageIndex = e.NewPageIndex
        Dim dt As New DataTable
        If Not Session("dtGrid") Is Nothing Then
            dt = Session("dtGrid")
        End If
        dg1.DataSource = dt
        dg1.DataBind()
    End Sub
    
    
   
    Protected Sub dg1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg1.PreRender

        For i = 0 To dg1.Items.Count - 1

            If IsDate(dg1.Items(i).Cells(7).Text.Trim) Then
                CType(dg1.Items(i).FindControl("chkRecibido"), CheckBox).Checked = True
            Else
                CType(dg1.Items(i).FindControl("chkRecibido"), CheckBox).Checked = False
            End If


            If IsDate(dg1.Items(i).Cells(9).Text.Trim) Then
                CType(dg1.Items(i).FindControl("chkEntrega"), CheckBox).Checked = True
            Else
                CType(dg1.Items(i).FindControl("chkEntrega"), CheckBox).Checked = False
            End If
         Next

    End Sub




    Protected Sub imgSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSalir.Click
        Response.Redirect("inicio.aspx")
    End Sub

      


    Protected Sub chkRecibido_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If CType(sender, CheckBox).Checked Then

            lblOp.Text = "1"
            lblInf1.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
            lblInf2.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd


            lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(2).Text.Trim 'cliente
            lblMSG.Text = "¿El vehiculo con placas " & dg1.Items(sender.parent.parent.itemindex).Cells(1).Text & " ya llego?"

            mOSTTRARoCULTAR("PLACAS")
            MPGV.Show()

            If lblInf2.Text = "0" And dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(13).Text.Trim <> "0" Then
                lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(13).Text.Trim 'numcita
                lblOp.Text = "01"
            End If
            If lblInf2.Text = "0" And dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(18).Text.Trim <> "0" Then
                lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(18).Text.Trim 'noorden
                lblOp.Text = "02"
            End If

        Else
            lblOp.Text = "0"
            lblInf1.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
            lblInf2.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd


            lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(2).Text.Trim 'cliente
            lblMSG.Text = "Se quitara la recepcion del vehiculo " & dg1.Items(sender.parent.parent.itemindex).Cells(1).Text & " "

            mOSTTRARoCULTAR("PLACAS")
            MPGV.Show()

            If lblInf2.Text = "0" And dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(13).Text.Trim <> "0" Then
                lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(13).Text.Trim 'numcita
                lblOp.Text = "01"
            End If
            If lblInf2.Text = "0" And dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(18).Text.Trim <> "0" Then
                lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(18).Text.Trim 'noorden
                lblOp.Text = "02"
            End If
        End If

    End Sub



    Sub guardarLlegada(ByVal id_hd As String, sTorre As String, SPLACAS As String, brecibir As Boolean)
        Dim sqry As String


        If brecibir Then
            sqry = " Update  " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set  horallegada=getdate(), colorprisma='" & sTorre.Trim & "' where  id_hd='" & id_hd & "' "
            BDClass.ExecuteQuery(sqry, False)

        Else
            sqry = " Update  " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set  horallegada=NULL, colorprisma='' where  id_hd='" & id_hd & "' "
            BDClass.ExecuteQuery(sqry, False)

        End If





        LlenadgPrincipal()
    End Sub

     
    Protected Sub OkButtonMPGV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OkButtonMPGV.Click

        Select Case lblOp.Text
           
            Case "1"
                guardarLlegada(lblInf2.Text, txtTorre.Text, txtModPlacas.Text, True)
            Case "0"
                guardarLlegada(lblInf2.Text, txtTorre.Text, txtModPlacas.Text, False)

            Case "2"
                ELIMINAR(lblInf2.Text)
            Case "20"
                GuardaEntrega(True, lblInf2.Text)
            Case "21"
                GuardaEntrega(True, lblInf2.Text)
            Case "30"
                GuardaEntrega(False, lblInf2.Text)
            Case "31"
                GuardaEntrega(False, lblInf2.Text)
           
            Case "0"
                guardarPlacas()

                LlenadgPrincipal()
            Case "12"
                guardarTorre()

                LlenadgPrincipal()
            Case "13"
                guardarCliente()

                LlenadgPrincipal()
            Case "14"
                guardarVehiculo()

                LlenadgPrincipal()
            Case "11"
                guardarfechaHoraCom()
                LlenadgPrincipal()
        End Select

    End Sub
   
   
    Sub GuardaEntrega(ByVal sRetiro As Boolean, ByVal id_hd As String)

        Dim sqry As String = ""


        If sRetiro Then

            sqry = " Update  "
            sqry += "    " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set horaretiro=getdate() "
            sqry += " where  id_hd=" & id_hd & "   "
            BDClass.ExecuteQuery(sqry, False)
        Else
            sqry = " Update  "
            sqry += "    " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set horaretiro=NULL "
            sqry += " where  id_hd=" & id_hd & "   "


            BDClass.ExecuteQuery(sqry, False)
        End If

        LlenadgPrincipal()

    End Sub
     
    Sub guardarPlacas()
        Dim sqry As String = ""


        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & "  set noplacas='" & txtModPlacas.Text.Trim & "'"
        sqry += " where  id_hd =" & lblInf2.Text & " "

        BDClass.ExecuteQuery(sqry, False)

        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasRegistro") & "  set noplacas='" & txtModPlacas.Text.Trim & "'"
        sqry += " where  id_hd =" & lblInf2.Text & " "

        BDClass.ExecuteQuery(sqry, False)


    End Sub
    Sub guardarTorre()
        Dim sqry As String = ""


        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & "  set colorprisma='" & txtTorre.Text.Trim & "'"
        sqry += " where  id_hd =" & lblInf2.Text & " "

        BDClass.ExecuteQuery(sqry, False)

        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasRegistro") & "  set colorprisma='" & txtTorre.Text.Trim & "'"
        sqry += " where  id_hd =" & lblInf2.Text & " "

        BDClass.ExecuteQuery(sqry, False)


    End Sub
    Sub guardarCliente()
        Dim sqry As String = ""


        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & "  set Cliente='" & txtModCliente.Text.Trim & "'"
        sqry += " where  id_hd =" & lblInf2.Text & " "

        BDClass.ExecuteQuery(sqry, False)

        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasRegistro") & "  set Cliente='" & txtModCliente.Text.Trim & "'"
        sqry += " where  id_hd =" & lblInf2.Text & " "

        BDClass.ExecuteQuery(sqry, False)


    End Sub
    Sub guardarVehiculo()
        Dim sqry As String = ""


        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & "  set Vehiculo='" & cboModVehiculo.SelectedItem.Text.Trim & "'"
        sqry += " where  id_hd =" & lblInf2.Text & " "

        BDClass.ExecuteQuery(sqry, False)

        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasRegistro") & "  set Vehiculo='" & cboModVehiculo.SelectedItem.Text.Trim & "'"
        sqry += " where  id_hd =" & lblInf2.Text & " "

        BDClass.ExecuteQuery(sqry, False)


    End Sub

    Sub guardarfechaHoraCom()
        Dim sqry As String = ""
        ''  If InStr(txtModFecha.Text.ToLower, "&nbsp;") > 0 Or IsDate(txtModFecha.Text.ToLower) = False Then lblInf1.Text = ""

        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set fecha_hora_com=cast('" & String.Format("{0:s}", CDate(txtModFecha.Text)) & "' as datetime) "
        sqry += " where     id_hd =" & lblInf2.Text & " "

        BDClass.ExecuteQuery(sqry, False)

    End Sub
    Protected Sub imgokModPlacas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgokModPlacas.Click
        guardarPlacas()

        lblInf1.Text = txtModPlacas.Text.Trim
        LlenadgPrincipal()
        lblModPlacas.Visible = False
        txtModPlacas.Text = ""

        OkButtonMPGV_Click(sender, e)
    End Sub


    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick

        If Int32.Parse(e.Item.Value) = 0 Then
            dg1.Visible = False


        Else

            dg1.Visible = True

        End If
    End Sub

     



    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If CType(sender, CheckBox).Checked Then

        lblOp.Text = 0
        lblInf1.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
        lblInf2.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd
        lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(2).Text.Trim 'cliente
        lblMSG.Text = ""

        mOSTTRARoCULTAR("PLACAS")

        MPGV.Show()

        'Else

        'End If
    End Sub
    Sub mOSTTRARoCULTAR(SOPCION As String)
        lblModPlacas.Visible = False
        lblTorre.Visible = False
        lblModCliente.Visible = False
        lblModfecha.Visible = False
        lblModVehiculo.Visible = False
        txtModPlacas.Visible = False
        txtTorre.Visible = False
        txtModCliente.Visible = False
        txtModFecha.Visible = False
        cboModVehiculo.Visible = False
        lblEliminar.Visible = False

        Select Case SOPCION
            Case "PLACAS"
                lblModPlacas.Visible = True
                txtModPlacas.Text = lblInf1.Text
                txtModPlacas.Visible = True
            Case "CLIENTE"


                txtModCliente.Visible = True
                lblModCliente.Visible = True

            Case "VEHICULO"
                lblModVehiculo.Visible = True
                cboModVehiculo.Visible = True



            Case "TORRE"


                lblTorre.Visible = True
                txtTorre.Visible = True
                txtTorre.Text = lblInf3.Text

            Case "FECHAE"

                lblModfecha.Visible = True
                txtModFecha.Text = lblInf1.Text
                txtModFecha.Visible = True

            Case "ELIMINAR"
                lblEliminar.Visible = True
        End Select

    End Sub

    Protected Sub lnkCliente_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If CType(sender, CheckBox).Checked Then

        lblOp.Text = 13
        lblInf1.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
        lblInf2.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd
        lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(2).Text.Trim 'cliente
        lblMSG.Text = ""
        mOSTTRARoCULTAR("CLIENTE")

        MPGV.Show()

        'Else

        'End If
    End Sub
    Protected Sub lnkVehiculo_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If CType(sender, CheckBox).Checked Then

        lblOp.Text = 14
        lblInf1.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
        lblInf2.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd
        lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(2).Text.Trim 'cliente
        lblMSG.Text = ""

        mOSTTRARoCULTAR("VEHICULO")
        MPGV.Show()

        'Else

        'End If
    End Sub
    Protected Sub lnkTorre2_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If CType(sender, CheckBox).Checked Then

        lblOp.Text = 12
        lblInf1.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
        lblInf2.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd
        lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(10).Text.Trim 'torre
        lblMSG.Text = ""
        mOSTTRARoCULTAR("TORRE")
        MPGV.Show()

        'Else

        'End If
    End Sub


    Protected Sub LinkButton1_Click2(ByVal sender As Object, ByVal e As EventArgs)
        'If CType(sender, CheckBox).Checked Then

        lblOp.Text = 11
        lblInf1.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(14).Text 'placas
        lblInf2.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd
        lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(2).Text.Trim 'cliente
        lblMSG.Text = ""

        mOSTTRARoCULTAR("FECHAE")
        MPGV.Show()

        'Else

        'End If
    End Sub

     



End Class
