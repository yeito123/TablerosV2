Imports TablerosV2LibTypes

Partial Class _nzRecepcion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            LlenadgPrincipal()
            llenaVehiculos()


        End If

    End Sub

    Protected Sub imgDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'If CType(sender, CheckBox).Checked Then
        Dim sinf As String = CType(dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text
        lblOp.Text = 2
         

        MosttrarOcultar("ELIMINAR", sinf)

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
        ' sqry = "Select * from TYT_LV_TBL_CONTROL_CITAS_header where  year(fecha)=" & Date.Now.Year & " and month(fecha)=" & Date.Now.Month & " and day(fecha)=" & Date.Now.Day & "  and NUMCITA<>'0' AND NOORDEN ='0'   order by HORAASESOR asc"

        sqry = " select * from v_header_recepcion order by horaasesor asc"



        dt = BDClass.SQLtoDataTable(sqry, False)
        Session("dgnrecepcion") = dt
        dg1.DataSource = dt
        dg1.DataBind()
        dg1.CurrentPageIndex = 0


    End Sub



    Protected Sub dg1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dg1.PageIndexChanged
        dg1.CurrentPageIndex = e.NewPageIndex
        Dim dt As New DataTable
        If Not Session("dgnrecepcion") Is Nothing Then
            dt = Session("dgnrecepcion")
        End If
        dg1.DataSource = dt
        dg1.DataBind()
    End Sub
    Function BuscaPlaca(ByVal sPlaca As String) As ArrayList

        Dim dt As New DataTable
        Dim ls As New ArrayList
        Dim sqry As String = ""
        sqry = "SELECT  top 1 * from   FV_CRM_CITAS_PROYECTADAS  where Placa='" & sPlaca & "'"
        dt = BDClass.SQLtoDataTable(sqry, True)
        ls.Add(dt.Copy)
        sqry = "Select * from TYT_LV_TBL_CONTROL_CITAS_header where noplacas='" & sPlaca & "'" '  year(fecha)=" & Date.Now.Year & " and month(fecha)=" & Date.Now.Month & ""
        dt = BDClass.SQLtoDataTable(sqry, False)
        ls.Add(dt.Copy)

        Return ls
        cboVehiculo.Focus()
    End Function


    Sub llenaVehiculos()

        Dim dt As New DataTable
        Dim sqry As String = ""
        sqry = "SELECT DISTINCT vehiculos from Tb_VEHICULOS "
        dt = BDClass.SQLtoDataTable(sqry, False)
        cboVehiculo.Items.Clear()
        cboModVehiculo.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cboVehiculo.Items.Add(New ListItem(dt.Rows(i).Item(0), dt.Rows(i).Item(0)))
            cboModVehiculo.Items.Add(New ListItem(dt.Rows(i).Item(0), dt.Rows(i).Item(0)))
        Next
        sqry = "SELECT cveasesor, nombre from sccusuarios where isnull(cveasesor,'')<>'' "
        dt = BDClass.SQLtoDataTable(sqry, False)
        cboAsesor.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cboAsesor.Items.Add(New ListItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
        Next
    End Sub '
    Protected Sub dg1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg1.PreRender

        For i = 0 To dg1.Items.Count - 1



            If IsDate(dg1.Items(i).Cells(6).Text) = False Then
                CType(dg1.Items(i).FindControl("lnkPlacas"), LinkButton).Attributes.Add("class", "btn  btn-info")
            Else

                CType(dg1.Items(i).FindControl("lnkPlacas"), LinkButton).Attributes.Add("class", "btn btn-default")
            End If

            'If IsDate(dg1.Items(i).Cells(7).Text.Trim) Then
            '    CType(dg1.Items(i).FindControl("chkRecibido"), CheckBox).Checked = True
            'Else
            '    CType(dg1.Items(i).FindControl("chkRecibido"), CheckBox).Checked = False
            'End If


            '    link = New LinkButton
            '    link.ID = "lnkPlacas_" & i
            '    link.Text = dg1.Items(i).Cells(1).Text.Trim

            '    dg1.Items(i).Cells(1).Controls.Add(link)
            '    AddHandler CType(dg1.Items(i).Cells(1).FindControl("lnkPlacas_" & i), LinkButton).Click, AddressOf LinkButton1_Click
        Next

    End Sub



 
    Protected Sub imgNuevoOK_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNuevoOK.Click
        Insertar()
        '  MOSTRARRESUMEN()
    End Sub

    Sub Insertar()
        Dim dt As New DataTable
        Dim sqry As String

        'sqry = "select * from V_citas_cliente where placa='" & txtPlacas.Text.Trim.ToUpper & "'"

        'dt = BDClass.SQLtoDataTable(sqry, False)

        'If dt.Rows.Count > 0 Then
        '    sqry = "Insert into " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " (VIN,numcita,noorden,idasesor, NOPLACAS, FECHA,CLIENTE, vehiculo, COLOR,cilindros,horallegada, colorprisma, ano, kilometraje,idop, bahia) values( '" & dt.Rows(0).Item("vin") & "','0','0','" & cboAsesor.SelectedItem.Value & "','" & txtPlacas.Text.Trim.ToUpper & "',cast('" & String.Format("{0:s}", CDate(Now.ToShortDateString)) & "' as datetime), '" & dt.Rows(0).Item("nombre_cliente") & "', '" & dt.Rows(0).Item("modelo") & "',  '" & dt.Rows(0).Item("color_exterior") & "', '" & dt.Rows(0).Item("cilindros") & "', getdate(), null,0,0,0,0)"

        'Else
        sqry = "Insert into " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " ( numcita,noorden,idasesor,NOPLACAS, FECHA,CLIENTE, vehiculo, COLOR,horallegada, colorprisma,ano, cilindros, kilometraje,idop, bahia) values('0','0','" & cboAsesor.SelectedItem.Value & "','" & txtPlacas.Text.Trim.ToUpper & "',cast('" & String.Format("{0:s}", CDate(Now.ToShortDateString)) & "' as datetime), '', '" & cboVehiculo.SelectedItem.Text & "',  '" & cboColor.SelectedItem.Text & "', getdate(),'" & txtTorre2.Text.Trim.ToUpper & "',0,0,0,0,0)"

        ' End If


        BDClass.ExecuteQuery(sqry, False)

        LlenadgPrincipal()

        txtPlacas.Text = ""
        cboVehiculo.SelectedIndex = 0
        cboColor.SelectedIndex = 0
        cboAsesor.SelectedIndex = 0


        'LlenadgPrincipal()
        'llenaInv()
    End Sub

    Protected Sub cmdBuscaPlacas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBuscaPlacas.Click
        If txtPlacas.Text.Trim.Length = 0 Then Exit Sub
        BuscaPlaca(txtPlacas.Text.Trim)
    End Sub




    Protected Sub chkRecibido_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sinf As String = CType(dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text
        If CType(sender, CheckBox).Checked Then

            lblOp.Text = "1"
            lblInf1.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
            lblInf2.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd


            lblInf3.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(2).Text.Trim 'cliente
            lblMSG.Text = "¿El vehiculo con placas " & dg1.Items(sender.parent.parent.itemindex).Cells(1).Text & " ya llego?"

            MosttrarOcultar("PLACAS", sinf)
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

        End If

    End Sub



    Sub guardarLlegada(ByVal id_hd As String)





        Dim sqry As String
        sqry = " Update  " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set  horallegada=getdate() where  id_hd='" & id_hd & "' "
        BDClass.ExecuteQuery(sqry, False)


    End Sub


    Sub guardarLlegada2(ByVal id_hd As String, snumcita As String)

        Dim dt As New DataTable



        Dim sqry As String
        sqry = "INSERT INTO Tb_CITAS("
        sqry += "	   idChip, oChip, leftPX, topPX, idBlinsur, idAsesor, idTecnico, "
        sqry += "	fecha, nombreDia, horaCita, noPlacas, Cliente, Vehiculo, Color,"
        sqry += "	Ano, Cilindros, Servicio, tipoCliente, noOrden, noPrisma, colorPrisma,"
        sqry += "	conCita, enUso, idServicio, oChipWidth, vhRecepcion, vhInventario, vhReparando,"
        sqry += "	vhReprogramado, vhServCancelado, vin, servicioCapturado, telefonos, "
        sqry += "	horaTolerancia, horaRecepcion, horaRampa, horaEntrega, horaAsesor, CarryOver, "
        sqry += "	vhServTerminado, FECHA_AGENDADO, FECHA_ORIGINAL, Status, Status_OS, valet,"
        sqry += "	USUARIO, ASYS_RENGLON, numcita, observaciones, iditem,id_hd) "
        sqry += "	select top 1 "
        sqry += "	1, 'dG0', leftPX, topPX, idBlinsur, idAsesor, idTecnico,"
        sqry += "	fecha, nombreDia, horaCita, noPlacas, Cliente, Vehiculo, Color,"
        sqry += "	Ano, Cilindros, Servicio, tipoCliente, noOrden, noPrisma, colorPrisma,"
        sqry += "	conCita, enUso, idServicio, oChipWidth, vhRecepcion, vhInventario, vhReparando,"
        sqry += "	vhReprogramado, vhServCancelado, vin, servicioCapturado, telefonos,"
        sqry += "	horaTolerancia, horaRecepcion, horaRampa, horaEntrega, horaAsesor, CarryOver,"
        sqry += "	vhServTerminado, FECHA_AGENDADO, FECHA_ORIGINAL, 'Pendiente', 'ABIERTA', valet,"
        sqry += "	USUARIO, ASYS_RENGLON, numcita, observaciones, iditem, id_hd"
        sqry += "	from v_interfaz_dms_citas_chips where numcita='" & snumcita & "'"



        BDClass.ExecuteQuery(sqry, False)


        sqry = " select  id_hd, isnull(noplacas, id_hd) from   "
        sqry += "  Tb_CITAS  "
        sqry += " WHERE numcita='" & snumcita & "' order by id_hd desc"


        dt = BDClass.SQLtoDataTable(sqry, False)


        If dt.Rows.Count > 0 Then

            guardarLlegada(dt.Rows(0).Item(0).ToString)



        End If



        '  LlenadgPrincipal()
    End Sub

    Sub guardarLlegada3(ByVal id_hd As String, noorden As String)

        Dim dt As New DataTable



        Dim sqry As String


        sqry = "Insert into " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " "
        sqry += "( numcita,noorden,idasesor,NOPLACAS, FECHA,CLIENTE, vehiculo, COLOR,horallegada, colorprisma,ano, cilindros, kilometraje,idop, bahia)	"

        sqry += " select top 1 numcita,noorden,idasesor,NOPLACAS, FECHA,CLIENTE, vehiculo, COLOR,cast('" & String.Format("{0:s}", CDate(Now.ToShortDateString)) & "' as datetime), colorprisma,ano, cilindros, kilometraje,0, 0 from v_interfaz_dms_citas_chips where noorden='" & noorden & "' "
        'sqry += " values('0','0','" & cboAsesor.SelectedItem.Value & "','" & txtPlacas.Text.Trim.ToUpper & "',, '', '" & cboVehiculo.SelectedItem.Text & "',  '" & cboColor.SelectedItem.Text & "', getdate(),'" & txtTorre2.Text.Trim.ToUpper & "',0,0,0,0,0)"	"


        BDClass.ExecuteQuery(sqry, False)




        sqry = "INSERT INTO Tb_CITAS("
        sqry += "	   idChip, oChip, leftPX, topPX, idBlinsur, idAsesor, idTecnico, "
        sqry += "	fecha, nombreDia, horaCita, noPlacas, Cliente, Vehiculo, Color,"
        sqry += "	Ano, Cilindros, Servicio, tipoCliente, noOrden, noPrisma, colorPrisma,"
        sqry += "	conCita, enUso, idServicio, oChipWidth, vhRecepcion, vhInventario, vhReparando,"
        sqry += "	vhReprogramado, vhServCancelado, vin, servicioCapturado, telefonos, "
        sqry += "	horaTolerancia, horaRecepcion, horaRampa, horaEntrega, horaAsesor, CarryOver, "
        sqry += "	vhServTerminado, FECHA_AGENDADO, FECHA_ORIGINAL, Status, Status_OS, valet,"
        sqry += "	USUARIO, ASYS_RENGLON, numcita, observaciones, iditem,id_hd) "
        sqry += "	select top 1 "
        sqry += "	1, 'dG0', leftPX, topPX, idBlinsur, idAsesor, idTecnico,"
        sqry += "	fecha, nombreDia, horaCita, noPlacas, Cliente, Vehiculo, Color,"
        sqry += "	Ano, Cilindros, Servicio, tipoCliente, noOrden, noPrisma, colorPrisma,"
        sqry += "	conCita, enUso, idServicio, oChipWidth, vhRecepcion, vhInventario, vhReparando,"
        sqry += "	vhReprogramado, vhServCancelado, vin, servicioCapturado, telefonos,"
        sqry += "	horaTolerancia, horaRecepcion, horaRampa, horaEntrega, horaAsesor, CarryOver,"
        sqry += "	vhServTerminado, FECHA_AGENDADO, FECHA_ORIGINAL, 'Pendiente', 'ABIERTA', valet,"
        sqry += "	USUARIO, ASYS_RENGLON, numcita, observaciones, iditem, id_hd"
        sqry += "	from v_interfaz_dms_citas_chips where noorden='" & noorden & "'"



        BDClass.ExecuteQuery(sqry, False)


        sqry = " select  id_hd, isnull(noplacas, id_hd) from   "
        sqry += "  Tb_CITAS  "
        sqry += " WHERE noorden='" & noorden & "' order by id_hd desc"


        dt = BDClass.SQLtoDataTable(sqry, False)


        If dt.Rows.Count > 0 Then

            guardarLlegada(dt.Rows(0).Item(0).ToString)



        End If



        '  LlenadgPrincipal()
    End Sub
    Protected Sub OkButtonMPGV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OkButtonMPGV.Click

        Select Case lblOp.Text
            Case "01"
                guardarLlegada2(lblInf2.Text, lblInf3.Text)
            Case "02"
                guardarLlegada3(lblInf2.Text, lblInf3.Text)


            Case "1"
                guardarLlegada(lblInf1.Text)
            Case "2"
                ELIMINAR(lblInf2.Text)

            Case "0"
                If lblInf2.Text = "00:00" Then

                    guardarLlegada(lblInf1.Text)
                    guardarPlacas()
                    guardarCliente()
                Else
                    guardarPlacas()
                End If

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



    Sub guardarPlacas()
        Dim sqry As String = ""


        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & "  set noplacas='" & txtModPlacas.Text.Trim & "'"
        sqry += " where  id_hd =" & lblInf1.Text & " "

        BDClass.ExecuteQuery(sqry, False)

       


    End Sub
    Sub guardarTorre()
        Dim sqry As String = ""


        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & "  set colorprisma='" & txtTorre.Text.Trim & "'"
        sqry += " where  id_hd =" & lblInf1.Text & " "

        BDClass.ExecuteQuery(sqry, False)

        


    End Sub
    Sub guardarCliente()
        Dim sqry As String = ""


        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & "  set Cliente='" & txtModCliente.Text.Trim & "'"
        sqry += " where  id_hd =" & lblInf1.Text & " "

        BDClass.ExecuteQuery(sqry, False)

        


    End Sub
    Sub guardarVehiculo()
        Dim sqry As String = ""


        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & "  set Vehiculo='" & cboModVehiculo.SelectedItem.Text.Trim & "'"
        sqry += " where  id_hd =" & lblInf1.Text & " "

        BDClass.ExecuteQuery(sqry, False)

       


    End Sub

    Sub guardarfechaHoraCom()
        Dim sqry As String = ""
        ''  If InStr(txtModFecha.Text.ToLower, "&nbsp;") > 0 Or IsDate(txtModFecha.Text.ToLower) = False Then lblInf1.Text = ""

        sqry = " Update  "
        sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set fecha_hora_com=cast('" & String.Format("{0:s}", CDate(txtModFecha.Text)) & "' as datetime) "
        sqry += " where     id_hd =" & lblInf1.Text & " "

        BDClass.ExecuteQuery(sqry, False)

    End Sub
    

    Protected Sub lnkPlacas_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If CType(sender, CheckBox).Checked Then
        Dim sinf As String = CType(dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text
        lblOp.Text = 0
        MosttrarOcultar("PLACAS", sinf)

        MPGV.Show()

        'Else

        'End If
    End Sub
    Sub MosttrarOcultar(SOPCION As String, sinf As String)
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
        lblMSG.Text = ""
        lblInf1.Text = Split(sinf, "__")(0) ' id_hd
        lblInf2.Text = Split(sinf, "__")(1) 'hora llegada
        'Eval("idve") & "__" & If(Eval("horallegada") Is DBNull.Value, "00:00", Eval("horallegada")) & "__" & Eval("Cliente") & "__" & Eval("noplacas") & "__" & Eval("VIN") & "__" & Eval("fecha_hora_com") & "__" & Eval("vehiculo") & "__" & Eval("colorprisma")
        Select Case SOPCION
            Case "PLACAS"
                If Split(sinf, "__")(1) = "00:00" Then
                    lblMSG.Text = "Desea Recibir el vehiculo? "

                    txtModCliente.Visible = True
                    txtModCliente.Text = Split(sinf, "__")(2)
                    lblModCliente.Visible = True
                Else
                    lblMSG.Text = "Modificar placas? "
                End If



                lblModPlacas.Visible = True
                txtModPlacas.Text = Split(sinf, "__")(3)
                txtModPlacas.Visible = True


            Case "CLIENTE"
                lblMSG.Text = "Modificar Cliente? "
                txtModCliente.Text = Split(sinf, "__")(2)
                txtModCliente.Visible = True
                lblModCliente.Visible = True

            Case "VEHICULO"
                lblMSG.Text = "Modificar Vehiculo? "
                cboModVehiculo.SelectedIndex = cboModVehiculo.Items.IndexOf(cboModVehiculo.Items.FindByText(Split(sinf, "__")(6)))
                lblModVehiculo.Visible = True
                cboModVehiculo.Visible = True

            Case "TORRE"
                lblMSG.Text = "Modificar Torre? "
                txtTorre.Text = Split(sinf, "__")(7)
                lblTorre.Visible = True
                txtTorre.Visible = True


            Case "FECHAE"
                lblMSG.Text = "Modificar Fecha Entrega? "
                lblModfecha.Visible = True
                txtModFecha.Text = Split(sinf, "__")(5)
                txtModFecha.Visible = True

            Case "ELIMINAR"
                lblMSG.Text = "Eliminar Vehiculo? "
                lblEliminar.Visible = True

        End Select

    End Sub

    Protected Sub lnkCliente_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sinf As String = CType(dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text

        lblOp.Text = 13
        
        MosttrarOcultar("CLIENTE", sinf)

        MPGV.Show()

        'Else

        'End If
    End Sub
    Protected Sub lnkVehiculo_Click(ByVal sender As Object, ByVal e As EventArgs)
       Dim sinf As String = CType(dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text
        lblOp.Text = 14
    

        MosttrarOcultar("VEHICULO", sinf)
        MPGV.Show()

        'Else

        'End If
    End Sub
    Protected Sub lnkTorre2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sinf As String = CType(dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text
        lblOp.Text = 12
        
        MosttrarOcultar("TORRE", sinf)
        MPGV.Show()

        'Else

        'End If
    End Sub


    Protected Sub lnkFechaE_Click2(ByVal sender As Object, ByVal e As EventArgs)
        Dim sinf As String = CType(dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text

        lblOp.Text = 11
        

        MosttrarOcultar("FECHAE", sinf)
        MPGV.Show()

        'Else

        'End If
    End Sub


End Class
