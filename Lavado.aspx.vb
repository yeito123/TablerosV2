Imports TablerosV2LibTypes
Public Class Lavado
    Inherits System.Web.UI.Page


    Dim sql As String = ""
    Dim cheI, chef As New CheckBox
    Const pendinete As String = "Pendiente"
    Const iniciada As String = "Iniciada"
    Const detenida As String = "Detenida"
    Const reiniciada As String = "Reiniciada"
    Const finalizada As String = "Finalizada"
    Const terminado As String = "Terminado"
    Const mensajeIni As String = "¿Estas seguro de iniciar?"
    Const mensajeFin As String = "¿Estas seguro de finalizar?"
    Const mensajeClase As String = "¿En que Clase de Estacionamiento se deja el vehículo?"
    Const mensajeLugar As String = "¿En que No. de Estacionamiento se deja el vehículo?"
    Const vacio As String = "&nbsp;"
    Const nulo As String = ""

    Dim sqry As String = ""
    Dim i As Integer
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If (Request.ServerVariables("http_user_agent").IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) <> -1) Or (Request.ServerVariables("http_user_agent").IndexOf("Chrome", StringComparison.CurrentCultureIgnoreCase) <> -1) Then
            Page.ClientTarget = "uplevel"
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not IsPostBack Then
                LLEnadrop1()


            End If
        Catch eexc As Exception
            Session("Mensaje") = eexc.Message

        End Try

        llenalavado()
        Session("grd1Index") = -1
    End Sub
    Sub llenalavado()
        Session("fechaAAAA") = Date.Today.Year
        Session("fechaMM") = Date.Today.Month
        Session("fechaDD") = Date.Today.Day
        Session("Status_OS") = "ABIERTA"

        Dim dt As New Data.DataTable, dt2 As New Data.DataTable


        sqry = "  SELECT DISTINCT  * from " & System.Web.Configuration.WebConfigurationManager.AppSettings("v_TableroLavado") & " "

        'response.write(sqry)
        dt = BDClass.SQLtoDataTable(sqry, False)
        dt2 = dt.Clone

        For i = 0 To dt.Rows.Count - 1
            If dt2.Select("Placa='" & dt.Rows(i)(16) & "'").Length = 0 Then dt2.Rows.Add(dt.Rows(i).ItemArray)
        Next

        GridView1.DataSource = dt2
        GridView1.DataBind()

        BuscarFiltro()

        BuscarFiltro1()

        HabilitaControles()
    End Sub
    Protected Sub Menu1_MenuItemClick(ByVal sender As Object,
          ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick
        MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value)
        llenalavado()
    End Sub
    Protected Sub ImageButton5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton5.Click
        Response.Redirect("inicio.aspx")
    End Sub

    Protected Sub DropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList3.SelectedIndexChanged
        Session("idClaseLugarAuto") = DropDownList3.SelectedValue
        Colocacontrolesmpe(4)
        Me.mpe.Show()

    End Sub
    Protected Sub ImgIniciar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer
        i = CType(sender.parent.parent, GridViewRow).DataItemIndex
        GridView1.SelectedIndex = i
        InhabilitaControles(i)
        Session("OPC") = 1
        Colocacontrolesmpe(1)
        Me.mpe.Show()
    End Sub
    Protected Sub ImgRetrabajo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer
        i = CType(sender.parent.parent, GridViewRow).DataItemIndex
        GvFinish.SelectedIndex = i

        Session("OPC") = 11
        Colocacontrolesmpe(11)
        Me.mpe.Show()
    End Sub
    Protected Sub ImgRetrabajo1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer
        i = CType(sender.parent.parent, GridViewRow).DataItemIndex
        GvFinish.SelectedIndex = i

        Session("OPC") = 12
        Colocacontrolesmpe(12)
        Me.mpe.Show()
    End Sub
    Protected Sub ImgBorrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer
        i = CType(sender.parent.parent, GridViewRow).DataItemIndex
        GridView1.SelectedIndex = i
        ' InhabilitaControles(i)
        Session("OPC") = 0
        Colocacontrolesmpe(0)
        Me.mpe.Show()
    End Sub
    Protected Sub ImgFinalizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer
        i = CType(sender.parent.parent, GridViewRow).DataItemIndex
        GridView1.SelectedIndex = i
        InhabilitaControles(i)
        Session("OPC") = 4
        Colocacontrolesmpe(4)
        Me.mpe.Show()
    End Sub
    Protected Sub ImgParar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer
        i = GridView1.SelectedRow.RowIndex
        InhabilitaControles(i)
        Session("OPC") = 2
        Colocacontrolesmpe(2)
        Me.mpe.Show()
    End Sub
    Protected Sub ImgReiniciar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer
        i = GridView1.SelectedRow.RowIndex
        InhabilitaControles(i)
        Session("OPC") = 3
        Colocacontrolesmpe(3)
        Me.mpe.Show()
    End Sub
    Protected Sub OKButton_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim opc As Integer
        Dim Sqry As String

        Dim sEjecuta As String
        Dim DT As New DataTable
        If Not Session("OPC") Is Nothing Then
            opc = Session("OPC")

            Select Case opc
                Case 12


                    Sqry = "insert into TB_CITAS (idAsesor, idTecnico, fecha, noPlacas, Cliente, Vehiculo, Color, Ano, Cilindros, Servicio, tipoCliente, noOrden, horaAsesor, conCita, enUso, idServicio, vin, servicioCapturado, CarryOver, Status, vhRecepcion, vhInventario, numcita, colorPrisma, observaciones, id_hd, seriecolorprisma)   select idAsesor, idTecnico, fecha, noPlacas, Cliente, Vehiculo, Color, Ano, Cilindros, servicio, tipoCliente, noOrden, horaAsesor, conCita, enUso, '151', vin, 'Lavado', CarryOver, 'EN LAVADO', vhRecepcion, vhInventario, numcita, colorPrisma, observaciones, id_Hd, seriecolorprisma"
                    Sqry += "  from TB_CITAS_canceladas_lavado where id=" & GvFinish1.Rows(GvFinish.SelectedIndex).Cells(0).Text & ""
                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)

                    Sqry = "delete TB_CITAS_canceladas_lavado where id=" & GvFinish1.Rows(GvFinish.SelectedIndex).Cells(0).Text & ""
                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)

                    llenalavado()
                Case 11


                    Sqry = "insert into TB_CITAS (idAsesor, idTecnico, fecha, noPlacas, Cliente, Vehiculo, Color, Ano, Cilindros, Servicio, tipoCliente, noOrden, horaAsesor, conCita, enUso, idServicio, vin, servicioCapturado, CarryOver, Status, vhRecepcion, vhInventario, numcita, colorPrisma, observaciones, id_hd, seriecolorprisma)   select idAsesor, idTecnico, fecha, noPlacas, Cliente, Vehiculo, Color, Ano, Cilindros, servicio, tipoCliente, noOrden, horaAsesor, conCita, enUso, '151', vin, 'Lavado', CarryOver, 'EN LAVADO', vhRecepcion, vhInventario, numcita, colorPrisma, observaciones, id_Hd, seriecolorprisma"
                    Sqry += "  from TB_CITAS where id=" & GvFinish.Rows(GvFinish.SelectedIndex).Cells(0).Text & ""
                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)

                    llenalavado()
                Case 0
                    'Sqry = "UPDATE TB_CITAS SET Fecha_Hora_Fin_Oper = getdate(), Status = 'Cancelada', Status_OS =' where id=" & GridView1.Rows(GridView1.SelectedIndex).Cells(0).Text & ""
                    'sEjecuta = bdclass.ExecuteQuery(Sqry, false)

                    Sqry = "delete TB_CITAS    where id=" & GridView1.Rows(GridView1.SelectedIndex).Cells(0).Text & ""
                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)

                    llenalavado()


                Case 1
                    Session("Num_OS") = GridView1.Rows(GridView1.SelectedIndex).Cells(2).Text.Trim
                    Dim gv1 As New GridView

                    GridView1.Rows(GridView1.SelectedIndex).Cells(6).Text = iniciada '"Iniciada"
                    GridView1.Rows(GridView1.SelectedIndex).Cells(8).Text = DateTime.Now
                    Sqry = " Update TB_CITAS set " &
                        "Status='" & GridView1.Rows(GridView1.SelectedIndex).Cells(6).Text & "', " &
                        "Fecha_Hora_ini_Oper=GETDate()" & ", IdTecnico='" & Me.CboLAvadores.SelectedValue &
                        "' where noOrden='" & GridView1.Rows(GridView1.SelectedIndex).Cells(2).Text & "'" & " AND servicioCapturado = 'Lavado' AND (status is null or Status<>'Terminado')"
                    ' sEjecuta = bdclass.ExecuteQuery(Sqry, false)

                    Session("iAA") = CDate(GridView1.Rows(GridView1.SelectedIndex).Cells(23).Text).Year
                    Session("iMM") = CDate(GridView1.Rows(GridView1.SelectedIndex).Cells(23).Text).Month
                    Session("iDD") = CDate(GridView1.Rows(GridView1.SelectedIndex).Cells(23).Text).Day
                    Session("noPlacas") = GridView1.Rows(GridView1.SelectedIndex).Cells(14).Text
                    Session("fecha_Hora_ini_Oper") = DateTime.Now
                    Session("Status") = iniciada
                    Session("servicioCapturado") = "Lavado"
                    Sqry = "UPDATE TB_CITAS SET fecha_Hora_ini_Oper =getdate(), Status =  '" & Session("Status") &
                            "', IdTecnico='" & Me.CboLAvadores.SelectedValue & "' WHERE  id=" & GridView1.Rows(GridView1.SelectedIndex).Cells(0).Text & ""
                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)
                    llenalavado()


                Case 2
                    Session("Num_OS") = GridView1.Rows(GridView1.SelectedIndex).Cells(2).Text.Trim
                    Dim idMotivoParo As String
                    idMotivoParo = DropDownList1.SelectedValue
                    Session("index") = GridView1.SelectedIndex
                    GridView1.Rows(GridView1.SelectedIndex).Cells(10).Text = DateTime.Now
                    GridView1.Rows(GridView1.SelectedIndex).Cells(6).Text = detenida '"Detenida"                    

                    Sqry = " Update dbo.f_detalle_ord set Status='" & GridView1.Rows(GridView1.SelectedIndex).Cells(6).Text &
                           "', fecha_Hora_Paro=GETDate(), id_motivo_paro='" & idMotivoParo & "'" &
                           " where Num_OS='" & Session("num_OS") & "'" & " AND Id_Operacion = 'Lavado'" &
                           " AND (Status='ABIERTA' or Status='Iniciada' or Status='Reiniciada')"
                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)
                    GridView1.Focus()
                Case 3
                    Session("Num_OS") = GridView1.Rows(GridView1.SelectedIndex).Cells(2).Text.Trim
                    Session("index") = GridView1.SelectedIndex
                    GridView1.Rows(GridView1.SelectedIndex).Cells(11).Text = DateTime.Now
                    GridView1.Rows(GridView1.SelectedIndex).Cells(6).Text = reiniciada '"Reiniciada"                    

                    Sqry = " Update dbo.f_detalle_ord set Status='" & GridView1.Rows(GridView1.SelectedIndex).Cells(6).Text &
                            "', fecha_hora_reinicio=GETDate()" &
                             " where Num_OS='" & Session("num_OS") & "'" & " AND Id_Operacion = 'Lavado' AND Status = 'Detenida'"
                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)
                    GridView1.Focus()
                Case 4
                    Session("Num_OS") = GridView1.Rows(GridView1.SelectedIndex).Cells(2).Text.Trim
                    Session("index") = GridView1.SelectedIndex
                    Dim gv1 As New GridView
                    GridView1.Rows(Session("index")).Cells(6).Text = terminado          'finalizada
                    GridView1.Rows(Session("index")).Cells(9).Text = DateTime.Now

                    Sqry = " Update TB_CITAS set Status='" & terminado & "', fecha_Hora_Fin_Oper=GETDate()" &
                           " where noOrden='" & GridView1.Rows(GridView1.SelectedIndex).Cells(2).Text & "'" &
                           " AND servicioCapturado = 'Lavado' AND Status <> 'Terminado'"
                    'sEjecuta = bdclass.ExecuteQuery(Sqry, false)




                    Session("iAA") = CDate(GridView1.Rows(GridView1.SelectedIndex).Cells(23).Text).Year
                    Session("iMM") = CDate(GridView1.Rows(GridView1.SelectedIndex).Cells(23).Text).Month
                    Session("iDD") = CDate(GridView1.Rows(GridView1.SelectedIndex).Cells(23).Text).Day
                    Session("noPlacas") = GridView1.Rows(GridView1.SelectedIndex).Cells(14).Text

                    Session("fecha_Hora_Fin_Oper") = DateTime.Now
                    Session("Status") = terminado
                    Session("Status_OS") = finalizada
                    Session("servicioCapturado") = "Lavado"

                    Sqry = "UPDATE TB_CITAS SET Fecha_Hora_Fin_Oper = getdate(), Status = '" &
                     Session("Status") & "', Status_OS ='" &
                     Session("Status_OS") &
                     "' where id=" & GridView1.Rows(GridView1.SelectedIndex).Cells(0).Text & ""
                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)

                    Session("idClaseLugarAuto") = Me.DropDownList3.SelectedValue
                    Session("idLugarAuto") = Me.DropDownList4.SelectedValue

                    llenalavado()
                    HabilitaControles()


                Case 20


                    Sqry = "UPDATE TB_CITAS_header_nw SET fecha_hora_com =  cast('" & String.Format("{0:s}", CDate(txtModFecha.Text.Trim())) & "' as datetime)    where id_hd=" & GridView1.Rows(GridView1.SelectedIndex).Cells(12).Text & ""
                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)

                    llenalavado()
                    HabilitaControles()


                Case 21


                    Sqry = "UPDATE TB_CITAS_header_nw SET comentarioslavado =   '" &
                     txtMod.Text.Trim() & "' where id_hd=" & GridView1.Rows(GridView1.SelectedIndex).Cells(12).Text & ""
                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)

                    llenalavado()
                    HabilitaControles()

            End Select

            Session.Remove("OPC")
        End If
        GridView1.Focus()
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Session.Remove("OPC")
        llenalavado()
    End Sub
    Private Sub InhabilitaControles(ByVal i As Integer)
        Dim j As Integer
        For j = 0 To GridView1.Rows.Count - 1
            If Me.GridView1.Rows(j).RowIndex = i Then
            Else
                Me.GridView1.Rows(j).Enabled = False
            End If
        Next
    End Sub
    Private Sub HabilitaControles()
        Dim j As Integer
        For j = 0 To GridView1.Rows.Count - 1
            Me.GridView1.Rows(j).Enabled = True
        Next
    End Sub
    Private Sub Colocacontrolesmpe(ByVal opc As Integer)
        Me.Panelfecha.Visible = False
        txtModFecha.Visible = False
        txtMod.Visible = False
        Select Case opc
            Case 11 'Iniciar
                Me.Label2.Text = "¿Desea re lavar la unidad?"
                Me.Label2.Visible = True
                Me.PnlParo.Visible = False
                Me.PnlFin.Visible = False
                Me.PanelIni.Visible = False
            Case 12 'Iniciar
                Me.Label2.Text = "¿Desea re lavar la unidad?"
                Me.Label2.Visible = True
                Me.PnlParo.Visible = False
                Me.PnlFin.Visible = False
                Me.PanelIni.Visible = False
            Case 0 'Iniciar
                Me.Label2.Text = "Se eliminara la operacion"
                Me.Label2.Visible = True
                Me.PnlParo.Visible = False
                Me.PnlFin.Visible = False
                Me.PanelIni.Visible = False
            Case 1 'Iniciar
                Me.PnlParo.Visible = False
                Me.PnlFin.Visible = False
                Me.Label2.Text = mensajeIni
                Me.PanelIni.Visible = True
            Case 2 'Parar
                Me.Label2.Text = "¿Estas seguro de parar?"
                Me.PnlParo.Visible = True
                Me.PnlFin.Visible = False
            Case 3 ' Reiniciar
                Me.Label2.Text = "¿Estas seguro de reiniciar?"
            Case 4 ' Finalizar
                Me.PnlParo.Visible = False
                Me.Label2.Visible = True
                Me.Label2.Text = "¿Desea finalizar?"
                Me.PnlParo.Visible = False
                Me.PnlFin.Visible = True
                Me.PanelIni.Visible = False

            Case 20 ' fecha
                Me.PnlParo.Visible = False
                Me.Label2.Visible = True
                Me.Label2.Text = "fecha promesa"
                Me.PnlParo.Visible = False
                Me.PnlFin.Visible = False
                Me.PanelIni.Visible = False
                Me.Panelfecha.Visible = True
                txtModFecha.Visible = True
                txtMod.Visible = False
            Case 21 ' comentarios
                Me.PnlParo.Visible = False
                Me.Label2.Visible = True
                Me.Label2.Text = "Comentarios"
                Me.PnlParo.Visible = False
                Me.PnlFin.Visible = False
                Me.PanelIni.Visible = False
                Me.Panelfecha.Visible = True
                txtModFecha.Visible = False
                txtMod.Visible = True
        End Select
    End Sub
    Private Sub LLEnadrop1()
        txtFec1.Text = Date.Now.ToShortDateString
        txtFec2.Text = Date.Now.ToShortDateString
        txtFec11.Text = Date.Now.ToShortDateString
        txtFec21.Text = Date.Now.ToShortDateString
        DropDownList3.Items.Add("...")
        DropDownList4.Items.Add("...")
        Dim Sqry As String

        Dim dt As New DataTable
        Dim i As Integer
        Sqry = "SELECT * FROM tb_TECNICOS_lavadores"
        dt = BDClass.SQLtoDataTable(Sqry, False)
        Me.CboLavadoresFinish.Items.Add(New ListItem("Todos..", "TodosAll"))
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                Me.CboLAvadores.Items.Add(New ListItem(dt.Rows(i).Item("nombre_empleado"), dt.Rows(i).Item("id_empleado")))
                Me.CboLavadoresFinish.Items.Add(New ListItem(dt.Rows(i).Item("nombre_empleado"), dt.Rows(i).Item("id_empleado")))
            Next
        End If




    End Sub
    Protected Sub CmdBuscarLavadorFinish1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdBuscarLavadorFinish1.Click
        BuscarFiltro1()
    End Sub
    Protected Sub CmdBuscarLavadorFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdBuscarLavadorFinish.Click
        BuscarFiltro()
    End Sub
    Sub BuscarFiltro()
        Dim dt As New DataTable
        Dim sQRY As String = ""


        If Me.CboLavadoresFinish.SelectedValue = "TodosAll" Then
            sQRY = "SELECT DISTINCT id, idItem, noOrden  as num_pre_orden, noOrden  as Num_OS, servicioCapturado  as Id_Operacion, idTecnico as  id_tecnico, null as Nr_Seq_Exec, Status, fecha_Ini_oracion, Fecha_Hora_ini_Oper, fecha_Hora_Fin_Oper, fecha_Hora_Paro,fecha_hora_reinicio, id_motivo_paro, Iniciar, Finalizar, vehiculo as modelo, noplacas as Placa,Status_Os, Fecha_hora_com, Cliente_Espera ,  noPrisma, colorPrisma , null as nombreLugarAuto " _
                 & " FROM TB_CITAS WHERE  servicioCapturado='Lavado' AND   not Fecha_Hora_ini_Oper is null and  Status='Terminado' and  fecha_Hora_Fin_Oper between cast('" & String.Format("{0:s}", CDate(CDate(txtFec1.Text).ToShortDateString())) & "' as datetime) and cast('" & String.Format("{0:s}", CDate(CDate(txtFec2.Text).ToShortDateString()).AddDays(1)) & "' as datetime)  ORDER BY fecha_Hora_Fin_Oper DESC"

        Else
            sQRY = "SELECT DISTINCT id, idItem, noOrden  as num_pre_orden, noOrden  as Num_OS, servicioCapturado  as Id_Operacion, idTecnico as  id_tecnico, null as Nr_Seq_Exec, Status, fecha_Ini_oracion, Fecha_Hora_ini_Oper, fecha_Hora_Fin_Oper, fecha_Hora_Paro,fecha_hora_reinicio, id_motivo_paro, Iniciar, Finalizar, vehiculo as modelo, noplacas as Placa,Status_Os, Fecha_hora_com, Cliente_Espera ,  noPrisma, colorPrisma , null as nombreLugarAuto " _
                 & " FROM TB_CITAS WHERE  servicioCapturado='Lavado' AND   not Fecha_Hora_ini_Oper is null and  Status='Terminado' and idTecnico='" & Me.CboLavadoresFinish.SelectedItem.Value & "' and  fecha_Hora_Fin_Oper between cast('" & String.Format("{0:s}", CDate(CDate(txtFec1.Text).ToShortDateString())) & "' as datetime) and cast('" & String.Format("{0:s}", CDate(CDate(txtFec2.Text).ToShortDateString()).AddDays(1)) & "' as datetime)  ORDER BY fecha_Hora_Fin_Oper DESC"

        End If
        dt = BDClass.SQLtoDataTable(sQRY, False)
        Me.GvFinish.DataSource = dt
        Me.GvFinish.DataBind()

    End Sub
    Sub BuscarFiltro1()
        Dim dt As New DataTable
        Dim sQRY As String = ""


        sQRY = "SELECT DISTINCT id, idItem, noOrden  as num_pre_orden, noOrden  as Num_OS, servicioCapturado  as Id_Operacion, idTecnico as  id_tecnico, null as Nr_Seq_Exec, Status, fecha_Ini_oracion, Fecha_Hora_ini_Oper, fecha_Hora_Fin_Oper, fecha_Hora_Paro,fecha_hora_reinicio, id_motivo_paro, Iniciar, Finalizar, vehiculo as modelo, noplacas as Placa,Status_Os, Fecha_hora_com, Cliente_Espera ,  noPrisma, colorPrisma , null as nombreLugarAuto " _
             & " FROM TB_CITAS_canceladas_lavado WHERE  servicioCapturado='Lavado'  and  fecha between cast('" & String.Format("{0:s}", CDate(CDate(txtFec11.Text).ToShortDateString())) & "' as datetime) and cast('" & String.Format("{0:s}", CDate(CDate(txtFec21.Text).ToShortDateString()).AddDays(1)) & "' as datetime)  ORDER BY fecha_Hora_Fin_Oper DESC"


        ' Response.Write(sQRY)
        dt = BDClass.SQLtoDataTable(sQRY, False)
        Me.GvFinish1.DataSource = dt
        Me.GvFinish1.DataBind()

    End Sub

    Protected Sub GridView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PreRender
        Dim i As Integer
        If Session("Admin") = "1" Then
            For i = 0 To GridView1.Rows.Count - 1
                CType(GridView1.Rows(i).FindControl("imgDelete"), ImageButton).Visible = True
                CType(GridView1.Rows(i).FindControl("lblEliminar"), Label).Visible = True
            Next
        End If

        For i = 0 To GridView1.Rows.Count - 1
            If GridView1.Rows(i).Cells(12).Text.ToLower <> "true" Then
                GridView1.Rows(i).BackColor = Drawing.Color.White
            End If
        Next
    End Sub

    Protected Sub GvFinish_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GvFinish.PreRender
        Dim i As Integer
        If Session("Admin") = "1" Then
            For i = 0 To GvFinish.Rows.Count - 1
                CType(GvFinish.Rows(i).FindControl("imgRetrabajo"), ImageButton).Visible = True
                CType(GvFinish.Rows(i).FindControl("LblINIC"), Label).Visible = True
            Next
        End If
    End Sub
    Protected Sub GvFinish1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GvFinish1.PreRender
        Dim i As Integer
        If Session("Admin") = "1" Then
            For i = 0 To GvFinish1.Rows.Count - 1
                CType(GvFinish1.Rows(i).FindControl("imgRetrabajo1"), ImageButton).Visible = True
                CType(GvFinish1.Rows(i).FindControl("LblINIC1"), Label).Visible = True
            Next
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim i As Integer
        i = CType(sender.parent.parent, GridViewRow).DataItemIndex
        GridView1.SelectedIndex = i

        Session("OPC") = 20
        Colocacontrolesmpe(20)
        mpe.Show()
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim i As Integer
        i = CType(sender.parent.parent, GridViewRow).DataItemIndex
        GridView1.SelectedIndex = i

        Session("OPC") = 21
        Colocacontrolesmpe(21)
        mpe.Show()
    End Sub



End Class