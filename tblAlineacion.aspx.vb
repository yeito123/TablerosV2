Imports TablerosV2LibTypes
Imports System.Data

Partial Class tblalineacion
    Inherits System.Web.UI.Page




    Dim sqry As String = ""
    Dim i As Integer
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If (Request.ServerVariables("http_user_agent").IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) <> -1) Or (Request.ServerVariables("http_user_agent").IndexOf("Chrome", StringComparison.CurrentCultureIgnoreCase) <> -1) Then
            Page.ClientTarget = "uplevel"
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            txtFec1.Text = Date.Now.ToShortDateString
            txtFec2.Text = Date.Now.ToShortDateString
            llenavehiculos()
        End If
        llenaLavado()
        Session("grd1Index") = -1
    End Sub
    Sub llenavehiculos()
        Dim dt As New DataTable
        Dim sqry As String = "", i As Integer
        sqry = "SELECT DISTINCT * from   v_interfaz_retrabajos_vehiculos order by noplacas asc,noorden desc "
        dt = BDClass.SQLtoDataTable(sqry, False)
        cboVehiculo.Items.Clear()

        For i = 0 To dt.Rows.Count - 1
            cboVehiculo.Items.Add(New ListItem("Placas: " & dt.Rows(i).Item("noplacas") & "     Orden:" & dt.Rows(i).Item("noorden") & "    Operacion: " & dt.Rows(i).Item("serviciocapturado").ToString().Trim, dt.Rows(i).Item("id")))

        Next

    End Sub
    Sub llenaLavado()
        Session("fechaAAAA") = Date.Today.Year
        Session("fechaMM") = Date.Today.Month
        Session("fechaDD") = Date.Today.Day
        Session("Status_OS") = "ABIERTA"

        Dim dt As New Data.DataTable, dt2 As New Data.DataTable
        Dim objCHIPColCom As New ChipHYPComCollection
        Dim sComentarios As String = ""
        sqry = "select noorden, noplacas, fecha, fecha_hora_ini, fecha_hora_fin, servicioCapturado, status from tb_citas_alineacion where status <> 'Finalizada'"

        dt = BDClass.SQLtoDataTable(sqry, False)
        dt2 = dt.Clone





        For i As Integer = 0 To dt.Rows.Count - 1
            If dt2.Select("noplacas='" & dt.Rows(i)("NOPLACAS") & "'").Length = 0 Then

                'objCHIPColCom = objCHIPColCom.ObtenComentarios(dt.Rows(i)("id"), "Terminado")

                sComentarios = ""
                'For Each d As ChipHYPCom In objCHIPColCom

                '    sComentarios = sComentarios & "Fecha: " & d._fecha.ToShortDateString & " " & d._fecha.ToShortTimeString & ", " & vbCrLf
                '    sComentarios = sComentarios & "Usuario: " & d._cveUsuario & vbCrLf
                '    sComentarios = sComentarios & "   " & d._comentario & vbCrLf
                'Next

                'If sComentarios.Trim.Length > 0 Then
                '    Try
                '        dt.Rows(i)("observaciones") = sComentarios
                '        dt.AcceptChanges()
                '    Catch ex As Exception
                '        dt.Rows(i)("observaciones") = Date.Now.ToString
                '        dt.AcceptChanges()
                '    End Try
                'End If
                dt2.Rows.Add(dt.Rows(i).ItemArray)

            End If
        Next

        GridView1.DataSource = dt2
        GridView1.DataBind()

        BuscarFiltro()

        HabilitaControles()

    End Sub
    Protected Sub Menu1_MenuItemClick(ByVal sender As Object,
          ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick
        MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value)
        llenaLavado()
    End Sub
    Protected Sub ImageButton5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton5.Click
        Response.Redirect("inicio.aspx")
    End Sub


    Protected Sub ImgIniciar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Label2.Visible = False
        txtComentariosLavado.Visible = False
        Dim i As Integer
        i = CType(sender.parent.parent, DataGridItem).ItemIndex
        GridView1.SelectedIndex = i
        InhabilitaControles(i)
        Session("OPC") = 1

        Me.mpe.Show()
    End Sub
    Protected Sub ImgFinalizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        txtComentariosLavado.Text = ""
        Label2.Visible = True
        txtComentariosLavado.Visible = True
        Dim i As Integer
        i = CType(sender.parent.parent, DataGridItem).ItemIndex
        GridView1.SelectedIndex = i
        InhabilitaControles(i)
        Session("OPC") = 2

        Me.mpe.Show()
    End Sub
    Protected Sub ImgFallo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Label2.Visible = True
        txtComentariosLavado.Visible = True
        Dim i As Integer
        i = CType(sender.parent.parent, DataGridItem).ItemIndex
        GridView1.SelectedIndex = i
        InhabilitaControles(i)
        Session("OPC") = 3

        Me.mpe.Show()
    End Sub
    Protected Sub imgAgregar_Click(sender As Object, e As ImageClickEventArgs) Handles imgAgregar.Click
        Dim Sqry As String
        Dim sEjecuta As String
        Sqry = " Update Tb_CITAS set " _
                       & " status_os='Calidad'  " _
                       & " " _
                      & "  where id='" & cboVehiculo.SelectedItem.Value & "'" & " AND servicioCapturado <> 'Lavado' "


        sEjecuta = BDClass.ExecuteQuery(Sqry, False)
        llenavehiculos()
        llenaLavado()
        Session.Remove("OPC")
        GridView1.Focus()

    End Sub
    Protected Sub OKButton_Click(ByVal sender As Object, ByVal e As EventArgs)


        Dim Sqry As String
        Dim sEjecuta As String

        Dim DT As New DataTable
        If Not Session("OPC") Is Nothing Then

            Select Case Session("OPC")
                Case 1


                    GridView1.Items(GridView1.SelectedIndex).Cells(5).Text = DateTime.Now
                    Sqry = " Update Tb_CITAS_ALINEACION set " _
                        & " status='Iniciada'  " _
                        & " " _
                       & "  where noorden='" & GridView1.Items(GridView1.SelectedIndex).Cells(0).Text & "'"


                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)


                Case 2

                    GridView1.Items(GridView1.SelectedIndex).Cells(5).Text = DateTime.Now
                    Sqry = " Update Tb_CITAS_ALINEACION set " _
                        & " status='Finalizada'  " _
                        & " " _
                       & "  where noorden='" & GridView1.Items(GridView1.SelectedIndex).Cells(0).Text & "'"

                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)



                    'Sqry = " INSERT INTO Tb_CITAS_RETRABAJOS(idAsesor, idTecnico, fecha, noPlacas,numcita, Cliente, Vehiculo, Color, Ano, Cilindros, Servicio, tipoCliente, noOrden, horaAsesor, conCita, enUso, idServicio, vin, servicioCapturado, CarryOver, Status, vhRecepcion, vhInventario, id_hd,iditem,observaciones) "
                    'Sqry += " select  idasesor, idtecnico, getdate(), noplacas,numcita, cliente, vehiculo, color, Ano, cilindros, servicio,'Calidad', noorden, horaasesor , concita, enuso, idservicio, vin, serviciocapturado, carryover, 'Terminado', 1, 1, id_hd ,id,'" & txtComentariosLavado.Text.Trim & "' from  Tb_CITAS where  id='" & GridView1.Items(GridView1.SelectedIndex).Cells(0).Text & "'"
                    'sEjecuta = BDClass.ExecuteQuery(Sqry, False)





                Case 3

                    GridView1.Items(GridView1.SelectedIndex).Cells(8).Text = DateTime.Now
                    Sqry = " Update Tb_CITAS set " _
                        & " status_os='Finalizada'   " _
                        & " " _
                       & "  where id='" & GridView1.Items(GridView1.SelectedIndex).Cells(0).Text & "'" & " AND servicioCapturado <> 'Lavado' "

                    sEjecuta = BDClass.ExecuteQuery(Sqry, False)



                    'Sqry = " INSERT INTO Tb_CITAS_RETRABAJOS(idAsesor, idTecnico, fecha, noPlacas,numcita, Cliente, Vehiculo, Color, Ano, Cilindros, Servicio, tipoCliente, noOrden, horaAsesor, conCita, enUso, idServicio, vin, servicioCapturado, CarryOver, Status, vhRecepcion, vhInventario, id_hd,iditem, observaciones) "
                    'Sqry += " select  idasesor, idtecnico, getdate(), noplacas,numcita, cliente, vehiculo, color, Ano, cilindros, servicio,'Retrabajo', noorden, horaasesor , concita, enuso, idservicio, vin, serviciocapturado, carryover, 'Pendiente', 1, 1, id_hd ,id,'" & txtComentariosLavado.Text.Trim & "' from  Tb_CITAS where  id='" & GridView1.Items(GridView1.SelectedIndex).Cells(0).Text & "'"
                    'sEjecuta = BDClass.ExecuteQuery(Sqry, False)



            End Select
            llenaLavado()
            Session.Remove("OPC")
        End If
        GridView1.Focus()
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Session.Remove("OPC")
        llenaLavado()
    End Sub
    Private Sub InhabilitaControles(ByVal i As Integer)
        Dim j As Integer
        For j = 0 To GridView1.Items.Count - 1
            If Me.GridView1.Items(j).ItemIndex = i Then
            Else
                Me.GridView1.Items(j).Enabled = False
            End If
        Next
    End Sub
    Private Sub HabilitaControles()
        Dim j As Integer
        For j = 0 To GridView1.Items.Count - 1
            Me.GridView1.Items(j).Enabled = True
        Next
    End Sub


    Sub BuscarFiltro()
        Dim dt As New DataTable
        Dim sQRY As String = ""



        sQRY = "select [noOrden],[noPlacas],[fecha],[fecha_hora_ini],[fecha_hora_fin],[servicioCapturado],[Status]  FROM [dbo].[TB_CITAS_ALINEACION] where fecha between '" + CDate(txtFec1.Text) + "' and '" + CDate(txtFec2.Text) + "' And status = 'Finalizada'"

        dt = BDClass.SQLtoDataTable(sQRY, False)
        Me.GvFinish.DataSource = dt
        Me.GvFinish.DataBind()

    End Sub

    Protected Sub imgRefrescar_Click(sender As Object, e As ImageClickEventArgs) Handles imgRefrescar.Click
        Response.Redirect("tblAlineacion.aspx")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class
