Imports TablerosV2LibTypes
Partial Class zEntregas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' MOSTRARRESUMEN()
        If Not Page.IsPostBack Then
            LlenadgPrincipal()
            'LLENAColores()

            llenaVehiculos()
            LlenadgAnteriores()

            dg2.Visible = False

        End If

    End Sub

    Protected Sub imgDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'If CType(sender, CheckBox).Checked Then

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
        ' sqry = "Select * from TYT_LV_TBL_CONTROL_CITAS_header where  year(fecha)=" & Date.Now.Year & " and month(fecha)=" & Date.Now.Month & " and day(fecha)=" & Date.Now.Day & "  and NUMCITA<>'0' AND NOORDEN ='0'   order by HORAASESOR asc"

        sqry = " select * from v_header_recepcion order by horaasesor asc"



        dt = BDClass.SQLtoDataTable(sqry, False)
        Session("dtGrid") = dt
        dg1.DataSource = dt
        dg1.DataBind()
        dg1.CurrentPageIndex = 0


    End Sub
    Sub LlenadgAnteriores()
        Dim dt As New DataTable
        Dim sqry As String = ""

        Dim ipage As Integer = dg1.CurrentPageIndex
        ' sqry = "Select * from TYT_LV_TBL_CONTROL_CITAS_header where  year(fecha)=" & Date.Now.Year & " and month(fecha)=" & Date.Now.Month & " and day(fecha)=" & Date.Now.Day & "  and NUMCITA<>'0' AND NOORDEN ='0'   order by HORAASESOR asc"
        sqry = "SELECT  * from v_header_recepcion_anterior"

        'response.write(sqry)
        dt = BDClass.SQLtoDataTable(sqry, False)
        Session("dtGrid") = dt
        dg2.DataSource = dt
        dg2.DataBind()
        dg2.CurrentPageIndex = 0


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

    'Sub LLENAColores()
    '    
    '    Dim dt As New DataTable
    '    'Dim sqry As String = ""
    '    'sqry = "SELECT DISTINCT YEAR_MODELO  from V_INVENTARIO_AUTOS "
    '    'dt = bdclass.SQLtoDataTable(sqry, True)
    '    cboColor.Items.Clear()

    '    ' cboColor.Items.Add(New ListItem(dt.Rows(i).Item(0), dt.Rows(i).Item(0)))
    '    cboColor.Items.Add(New ListItem("Blanco", "Blanco"))
    '    cboColor.Items.Add(New ListItem("Negro", "Negro"))
    '    cboColor.Items.Add(New ListItem("Gris", "Gris"))
    '    cboColor.Items.Add(New ListItem("Rojo", "Rojo"))
    '    cboColor.Items.Add(New ListItem("Azul", "Azul"))
    '    cboColor.Items.Add(New ListItem("Amarillo", "Amarillo"))
    '    cboColor.Items.Add(New ListItem("Verde", "Verde"))

    'End Sub
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
            '    link = New LinkButton
            '    link.ID = "lnkPlacas_" & i
            '    link.Text = dg1.Items(i).Cells(1).Text.Trim

            '    dg1.Items(i).Cells(1).Controls.Add(link)
            '    AddHandler CType(dg1.Items(i).Cells(1).FindControl("lnkPlacas_" & i), LinkButton).Click, AddressOf LinkButton1_Click
        Next

    End Sub




    Protected Sub imgSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSalir.Click
        Response.Redirect("inicio.aspx")
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

        End If

    End Sub



    Sub guardarLlegada(ByVal id_hd As String, sTorre As String, SPLACAS As String)





        Dim sqry As String
        sqry = " Update  " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & " set  horallegada=getdate(), colorprisma='" & sTorre.Trim & "' where  id_hd='" & id_hd & "' "



        BDClass.ExecuteQuery(sqry, False)

        If SPLACAS.Trim.Length > 0 Then


            sqry = " Update  "
            sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & "  set noplacas='" & SPLACAS & "'"
            sqry += " where  id_hd ='" & id_hd & "' "

            BDClass.ExecuteQuery(sqry, False)

            sqry = " Update  "
            sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasRegistro") & "  set noplacas='" & SPLACAS & "'"
            sqry += " where  id_hd ='" & id_hd & "' "

            BDClass.ExecuteQuery(sqry, False)

        End If

        LlenadgPrincipal()
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

            guardarLlegada(dt.Rows(0).Item(0).ToString, "", dt.Rows(0).Item(1).ToString)



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

            guardarLlegada(dt.Rows(0).Item(0).ToString, "", dt.Rows(0).Item(1).ToString)



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
                guardarLlegada(lblInf2.Text, txtTorre.Text, txtModPlacas.Text)
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
            Case "32"
                GuardaEntrega2(lblInf1.Text, False)

            Case "22"
                GuardaEntrega2(lblInf1.Text, True)
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
    Protected Sub chkEntrega_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)



        lblInf1.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
        lblInf2.Text = dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(15).Text 'id_hd




        If CType(sender, CheckBox).Checked Then
            lblMSG.Text = "¿Esta seguro de que el vehiculo con placas " & dg1.Items(sender.parent.parent.itemindex).Cells(1).Text & " se retira?"

            If dg1.Items(sender.parent.parent.itemindex).Cells(11).Text = "Con Cita" Then
                lblOp.Text = 20

            Else
                lblOp.Text = 21

            End If


        Else
            lblMSG.Text = "¿El vehiculo con placas " & dg1.Items(sender.parent.parent.itemindex).Cells(1).Text & "  NO se retira?"

            If dg1.Items(sender.parent.parent.itemindex).Cells(11).Text = "Con Cita" Then
                lblOp.Text = 30
            Else
                lblOp.Text = 31
            End If

        End If
        mOSTTRARoCULTAR("Entrega")
        MPGV.Show()
    End Sub

    Protected Sub chkEntrega2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)



        lblInf1.Text = dg2.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(6).Text
        'r() 'esponse.write(lblInf1.Text)



        If CType(sender, CheckBox).Checked Then
            lblMSG.Text = "¿Esta seguro de que el vehiculo con placas " & CType(dg2.Items(sender.parent.parent.itemindex).FindControl("lblNoPacas"), Label).Text & " se retira?"
            lblOp.Text = 22


            'Else
            '    lblMSG.Text = "¿El vehiculo con placas " & dg2.Items(sender.parent.parent.itemindex).Cells(0).Text & "  NO se retira?"
            '    lblOp.Text = 32


        End If
        mOSTTRARoCULTAR("Entrega")
        MPGV.Show()
    End Sub

    Sub MOSTRARRESUMEN()


        Dim dt As DataTable
        Dim sqry As String

        Dim iAutosR As Integer = 0, iAutosE As Integer = 0, iAutosL As Integer = 0
        Dim inoshows As Integer = 0, icitaspuntuales As Integer = 0
        Dim showsimpuntuales As Integer = 0, isCitas As Integer = 0
        Dim iCitasa As Integer = 0

        sqry = " SELECT * from " & System.Web.Configuration.WebConfigurationManager.AppSettings("v_contadores_recepcion") & " "



        dt = BDClass.SQLtoDataTable(sqry, False)



        iAutosR = If(dt.Rows(0).Item("AutosR") Is DBNull.Value, 0, dt.Rows(0).Item("AutosR"))
        iAutosE = If(dt.Rows(0).Item("AutosE") Is DBNull.Value, 0, dt.Rows(0).Item("AutosE"))
        iAutosL = If(dt.Rows(0).Item("AutosL") Is DBNull.Value, 0, dt.Rows(0).Item("AutosL"))
        iCitasa = If(dt.Rows(0).Item("CitasA") Is DBNull.Value, 0, dt.Rows(0).Item("CitasA"))
        icitaspuntuales = If(dt.Rows(0).Item("CitasP") Is DBNull.Value, 0, dt.Rows(0).Item("CitasP"))





        Dim SCONTROL As String
        SCONTROL = "<div style='border:none;background-color:transparent;position:absolute;top:0px;left:690px;width:370px;height:100px;'>"
        SCONTROL += "<table style='border:solid thin silver;background-color:transparent;font-size:10px;font-family:arial;'  cellspacing='1'>"

        SCONTROL += "<tr>"
        SCONTROL += " <td  align='center'>Total Autos Recibidos</td><td  align='cennter'>Total Autos Retirados</td><td  align='center'>Citas Arribadas</td> <td  align='center'>Citas Puntuales</td> <td  align='center'>Autos en Lavado</td> "
        SCONTROL += "</td>"
        SCONTROL += "</tr>"
        SCONTROL += "<tr>"
        SCONTROL += "<td  align='center'>" & iAutosR & "</td><td  align='center'>" & iAutosE & "</td> <td  align='center'>" & iCitasa & "</td><td  align='center'>" & icitaspuntuales & "</td><td  align='center'>" & iAutosL & "</td> "
        SCONTROL += "</td>"
        SCONTROL += "</tr>"


        SCONTROL += "</table></div>"
        Dim obj1 As HtmlGenericControl = New HtmlGenericControl("div")
        obj1.InnerHtml = SCONTROL
        form1.Controls.Add(obj1)





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

    Sub GuardaEntrega2(ByVal id_hd As String, ByVal sRetiro As Boolean)

        Dim sqry As String = ""




        If sRetiro Then

            sqry = " Update  "
            sqry += "    " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & "  set horaretiro=getdate(), Status_OS='Entregado' "
            sqry += " where id_hd='" & id_hd & "'  "

            BDClass.ExecuteQuery(sqry, False)





        Else
            sqry = " Update  "
            sqry += "    " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasHD") & "  set horaretiro=NULL, Status_OS='ListoParaEntregar' "
            sqry += " where id_hd='" & id_hd & "'  "

            BDClass.ExecuteQuery(sqry, False)




        End If

        LlenadgPrincipal()
        LlenadgAnteriores()
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
            dg2.Visible = True

        Else

            dg1.Visible = True
            dg2.Visible = False
        End If
    End Sub

    'Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As MenuEventArgs) Handles LinkButton3.Click, LinkButton4.Click
    '    If Int32.Parse(CType(sender, LinkButton).CommandArgument) = 0 Then

    '        dg1.Visible = False
    '        dg2.Visible = True

    '    Else

    '        dg1.Visible = True
    '        dg2.Visible = False
    '    End If
    'End Sub



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


    Protected Sub dg1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dg1.SelectedIndexChanged

    End Sub



End Class
