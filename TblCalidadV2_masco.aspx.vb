Imports TablerosV2LibTypes

Public Class TblCalidadV2_masco
	Inherits System.Web.UI.Page
	Dim m As String = ""


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Me.IsPostBack Then
			llenavehiculos()
			llenaPendientes()
			llenafinalizados1()
		End If
	End Sub

	Protected Sub muestraMensaje()
		Response.Write("<script>window.alert('" & m & "');</script>")
	End Sub

	Protected Sub btnSalir_Click(sender As Object, e As ImageClickEventArgs)
		Response.Redirect("Inicio.aspx")
		Session.Remove("opc")
	End Sub

	Protected Sub imgAgregarNUevo_Click(sender As Object, e As ImageClickEventArgs)
		Dim n As Integer = CInt(lblPanelAgregarNuevoActivo.Text)
		If (n = 0) Then
			Me.pnlAgregarNuevo.Style("display") = "inline"
			lblPanelAgregarNuevoActivo.Text = "1"
		Else
			Me.pnlAgregarNuevo.Style("display") = "none"
			lblPanelAgregarNuevoActivo.Text = "0"
		End If
	End Sub

	Sub llenavehiculos()
		Dim dt As New DataTable
		Dim sqry As String = "", i As Integer

		'Llena los vehiculos que pueden agregar y que estan en taller
		sqry = "SELECT DISTINCT * from   v_interfaz_retrabajos_vehiculos order by noplacas asc,noorden desc "
		dt = BDClass.SQLtoDataTable(sqry, False)
		cmdVehiduloEntaller.Items.Clear()
		For i = 0 To dt.Rows.Count - 1
			cmdVehiduloEntaller.Items.Add(New ListItem("Placas: " & dt.Rows(i).Item("noplacas"), dt.Rows(i).Item("id")))
		Next

		'llena el tipo de vehiculos que manejan en el taller
		sqry = "select * from tb_vehiculos"
		dt.Clear()
		dt = BDClass.SQLtoDataTable(sqry, False)
		cboVehiculo.Items.Clear()
		If (dt.Rows.Count > 0) Then
			For i = 0 To dt.Rows.Count - 1
				cboVehiculo.Items.Add(New ListItem(dt.Rows(i).Item(0)))
			Next
		End If

		'llena los usuarios de calidad
		m = ""
		m = Validaciones.getCvePerfil("Calidad")
		If m <> "" Then
			dt.Clear()
			dt = Validaciones.getUsuariosPerfil(m)
			cmbUsuariosCalidad.Items.Clear()
			If dt.Rows.Count > 0 Then
				For i = 0 To dt.Rows.Count - 1
					cmbUsuariosCalidad.Items.Add(New ListItem(dt.Rows(i).Item("Nombre"), dt.Rows(i).Item("cveUsuario")))
				Next
			End If
		End If
	End Sub

	Protected Sub Menu1_MenuItemClick(ByVal sender As Object,
		  ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick
		multiview1.ActiveViewIndex = Int32.Parse(e.Item.Value)
		desactivarcontroles()
		llenafinalizados1()
	End Sub

	Protected Sub imgAgregarNUevo_Click1(sender As Object, e As ImageClickEventArgs)
		Dim Sqry As String
		Dim sEjecuta As String
		Dim num As String = cmdVehiduloEntaller.SelectedItem.Value.ToString
		Dim i As Integer = 0
		Dim dt = devuelveInfo(num)
		If dt.Rows.Count > 0 Then
			Dim id As String = dt.Rows(i).Item("id")
			Dim idhd As String = dt.Rows(i).Item("id_hd")
			Dim noOrden As String = dt.Rows(i).Item("noOrden")
			Dim noPlacas As String = dt.Rows(i).Item("noPlacas")
			Dim servicio As String = dt.Rows(i).Item("servicio")
			Dim status As String = dt.Rows(i).Item("status")
			Dim tecnivo As String = dt.Rows(i).Item("tecnico")
			Dim vehiculo As String = dt.Rows(i).Item("vehiculo")
			Dim color As String = dt.Rows(i).Item("color")
			Dim control As String = dt.Rows(i).Item("control")
			Dim usuario As String = "en desarrollo"
			Sqry = "INSERT INTO [TB_CITAS_CALIDAD] "
			Sqry += "([ID] "
			Sqry += ",[id_hd] "
			Sqry += ",[noorden] "
			Sqry += ",[noplacas] "
			Sqry += ",[fecha] "
			Sqry += ",[servicio] "
			Sqry += ",[status] "
			Sqry += ",[tecnico] "
			Sqry += ",[vehiculo] "
			Sqry += ",[color] "
			Sqry += ",[Usuario] "
			Sqry += ",[control]) "
			Sqry += "VALUES "
			Sqry += "('" & id & "', "
			Sqry += "'" & idhd & "', "
			Sqry += "'" & noOrden & "', "
			Sqry += "'" & noPlacas & "', "
			Sqry += "" & "getdate()" & ", "
			Sqry += "'" & servicio & "', "
			Sqry += "'" & status & "', "
			Sqry += "'" & tecnivo & "', "
			Sqry += "'" & vehiculo & "', "
			Sqry += "'" & color & "', "
			Sqry += "'" & usuario & "', "
			Sqry += "'" & control & "')"
			sEjecuta = BDClass.ExecuteQuery(Sqry, False)
			m = sEjecuta
			llenavehiculos()
			llenaPendientes()
			'GridView1.Focus()
		Else
			m = num
			muestraMensaje()
		End If

	End Sub
	Private Function devuelveInfo(ByVal n As String) As DataTable
		Dim dt As DataTable
		Dim sql As String
		sql = "select "
		sql += "ID, "
		sql += "id_hd, "
		sql += "noorden, "
		sql += "noplacas, "
		sql += "GETDATE() As fecha, "
		sql += "servicioCapturado As servicio, "
		sql += "'Pendiente' as Status, "
		sql += "idTecnico As tecnico, "
		sql += "vehiculo As vehiculo, "
		sql += "color As color, "
		sql += "'Calidad' as control "
		sql += " From Tb_CITAS "
		sql += "Where "
		sql += "ID = '" & n & "'"
		dt = BDClass.SQLtoDataTable(sql, False)
		Return dt
	End Function

	Protected Sub llenaPendientes()
		Dim sqry As String
		Dim dt As New Data.DataTable, dt2 As New Data.DataTable
		Dim objCHIPColCom As New ChipHYPComCollection
		Dim sComentarios As String = ""
		sqry = " select * from v_calidad"
		dt = BDClass.SQLtoDataTable(sqry, False)
		If (dt.Rows.Count > 0) Then
			GridPendientes.DataSource = dt
			GridPendientes.DataBind()
			GridPendientes.Visible = True
		Else
			dt = Nothing
			m = "No hay procesos de calidad pendientes"
			muestraMensaje()
			Me.GridPendientes.DataSource = dt
			Me.GridPendientes.DataBind()
			GridPendientes.Visible = False
		End If
	End Sub

	Protected Sub imgNuevoOK_Click(sender As Object, e As ImageClickEventArgs)
		Dim id As String = 0
		Dim idhd As String = 0
		Dim noOrden As String = 0
		Dim noPlacas As String = txtPlacas.Text.Trim
		Dim servicio As String = cmdServicios.Text.Trim
		Dim status As String = "Pendiente"
		Dim tecnivo As String = 0
		Dim vehiculo As String = cboVehiculo.Text.Trim
		Dim color As String = cboColor.Text.Trim
		Dim control As String = "Preliminar"
		Dim usuario As String = "en desarrollo"
		Dim Sqry As String
		Dim sEjecuta As String
		Sqry = "INSERT INTO [TB_CITAS_CALIDAD] "
		Sqry += "([ID] "
		Sqry += ",[id_hd] "
		Sqry += ",[noorden] "
		Sqry += ",[noplacas] "
		Sqry += ",[fecha] "
		Sqry += ",[servicio] "
		Sqry += ",[status] "
		Sqry += ",[tecnico] "
		Sqry += ",[vehiculo] "
		Sqry += ",[color] "
		Sqry += ",[Usuario] "
		Sqry += ",[control]) "
		Sqry += "VALUES "
		Sqry += "('" & id & "', "
		Sqry += "'" & idhd & "', "
		Sqry += "'" & noOrden & "', "
		Sqry += "'" & noPlacas & "', "
		Sqry += "" & "getdate()" & ", "
		Sqry += "'" & servicio & "', "
		Sqry += "'" & status & "', "
		Sqry += "'" & tecnivo & "', "
		Sqry += "'" & vehiculo & "', "
		Sqry += "'" & color & "', "
		Sqry += "'" & usuario & "', "
		Sqry += "'" & control & "')"
		sEjecuta = BDClass.ExecuteQuery(Sqry, False)
		m = sEjecuta
		llenavehiculos()
		llenaPendientes()
		'GridView1.Focus()
	End Sub

	Protected Sub imgIniciar_Click(sender As Object, e As ImageClickEventArgs)
		Dim selectedindex = CType(sender.Parent.Parent, DataGridItem).ItemIndex
		Me.GridPendientes.SelectedIndex = selectedindex
		Dim num As Integer = CInt(GridPendientes.SelectedItem.Cells(11).Text)
		Dim taller As String = GridPendientes.SelectedItem.Cells(13).Text
		lblIdInterno.Text = num
		Me.mpe.Show()
		cmbUsuariosCalidad.Visible = True
		If taller = "Tablero" Then
			Session("opc") = 1
		Else
			Session("opc") = 5
		End If
	End Sub

	Protected Sub imgcalidadOk_Click(sender As Object, e As ImageClickEventArgs)
		Dim selectedindex = CType(sender.Parent.Parent, DataGridItem).ItemIndex
		Me.GridPendientes.SelectedIndex = selectedindex
		Dim num As Integer = CInt(GridPendientes.SelectedItem.Cells(11).Text)
		Dim inicio As String = CStr(GridPendientes.SelectedItem.Cells(6).Text)
		Dim taller As String = GridPendientes.SelectedItem.Cells(13).Text
		lblIdInterno.Text = num
		lblInicio.Text = inicio
		If taller = "Tablero" Then
			Session("opc") = 2
		Else
			Session("opc") = 6
		End If
		Me.mpe.Show()
		txtcomentarios.Visible = True
		lblComentarios.Visible = True
	End Sub

	Protected Sub imgRetrabajo_Click(sender As Object, e As ImageClickEventArgs)
		Dim selectedindex = CType(sender.Parent.Parent, DataGridItem).ItemIndex
		Me.GridPendientes.SelectedIndex = selectedindex
		Dim num As Integer = CInt(GridPendientes.SelectedItem.Cells(11).Text)
		Dim id As Integer = CInt(GridPendientes.SelectedItem.Cells(0).Text)
		Dim inicio As String = CStr(GridPendientes.SelectedItem.Cells(6).Text)
		lblIdInterno.Text = num
		lblidInterno2.Text = id
		lblInicio.Text = inicio
		Session("opc") = 4
		Me.mpe.Show()
		txtcomentarios.Visible = True
		lblComentarios.Visible = True
	End Sub

	Protected Sub btnOK_Click(sender As Object, e As EventArgs)
		Dim num As Integer = lblIdInterno.Text
		Dim sql As String
		Select Case (Session("opc"))
			Case 1
				Dim usuario As String = cmbUsuariosCalidad.SelectedItem.Value.ToString
				sql = "UPDATE TB_CITAS_CALIDAD SET fecha_hora_ini = GETDATE(), STATUS = 'Iniciada', Usuario = '" & usuario & "' WHERE ID_CALIDAD = '" & num & "'"
				BDClass.ExecuteQuery(sql, False)
				llenaPendientes()
				cmbUsuariosCalidad.Visible = False
			Case 2
				If validarInicio(num) Then
					If validarcomentarios() Then
						sql = "UPDATE TB_CITAS_CALIDAD SET fecha_hora_Fin = GETDATE(), STATUS = 'Finalizada' , comentarios = '" & txtcomentarios.Text.Trim & "' WHERE ID_CALIDAD = '" & num & "'"
						m = BDClass.ExecuteQuery(sql, False)
						llenaPendientes()
					Else
						m = "Debe agregar un comentario para seguir"
						muestraMensaje()
					End If
				Else
					m = "Debe estar iniciada para poder finalizarla " & lblInicio.Text
					muestraMensaje()
				End If
			Case 4
				If validarInicio(num) Then
					If validarcomentarios() Then
						Dim id As Integer = lblidInterno2.Text
						If (id <> 0) Then
							sql = " INSERT INTO Tb_CITAS_RETRABAJOS(idAsesor, idTecnico, fecha, noPlacas,numcita, Cliente, Vehiculo, Color, Ano, Cilindros, Servicio, tipoCliente, noOrden, horaAsesor, conCita, enUso, idServicio, vin, servicioCapturado, CarryOver, Status, vhRecepcion, vhInventario, id_hd,iditem,observaciones) "
							sql += " select  idasesor, idtecnico, getdate(), noplacas,numcita, cliente, vehiculo, color, Ano, cilindros, servicio,'Retrabajo', noorden, horaasesor , concita, enuso, idservicio, vin, serviciocapturado, carryover, 'Pendiente', 1, 1, id_hd ,id,'" & txtcomentarios.Text.Trim & "' from  Tb_CITAS where  id='" & id & "'"
							m = BDClass.ExecuteQuery(sql, False)
						End If
						sql = "UPDATE TB_CITAS_CALIDAD SET fecha_hora_fin = GETDATE(), STATUS = 'Finalizada', control = 'Retrabajo', comentarios = '" & txtcomentarios.Text.Trim & "' WHERE ID_CALIDAD = '" & num & "'"
						m = BDClass.ExecuteQuery(sql, False)
						'm = id
						'muestraMensaje()
						llenaPendientes()
					Else
						m = "Debe agregar un comentario para seguir"
						muestraMensaje()
					End If
				Else
					m = "Debe estar iniciada para poder finalizarla " & lblInicio.Text
					muestraMensaje()
				End If
			Case 5
				Dim usuario As String = cmbUsuariosCalidad.SelectedItem.Value.ToString
				sql = "update tablerov2hyp.dbo.TYT_LV_TBL_CONTROL_CITAS  set fecha_Hora_ini_Oper = GETDATE(), Status = 'Iniciada', USUARIO = '" & usuario & "' WHERE ID = '" & num & "'"
				BDClass.ExecuteQuery(sql, False)
				llenaPendientes()
				cmbUsuariosCalidad.Visible = False
			Case 6
				'If validarInicio(num) Then
				If validarcomentarios() Then
						sql = "UPDATE  tablerov2hyp.dbo.TYT_LV_TBL_CONTROL_CITAS SET fecha_hora_Fin_oper = GETDATE(), STATUS = 'Terminado' , Observaciones = '" & txtcomentarios.Text.Trim & "' WHERE ID = '" & num & "'"
						m = BDClass.ExecuteQuery(sql, False)
						llenaPendientes()
					Else
						m = "Debe agregar un comentario para seguir"
						muestraMensaje()
					End If
				'Else
				'm = "Debe estar iniciada para poder finalizarla " & lblInicio.Text
				'muestraMensaje()
				'End If

		End Select
		txtcomentarios.Text = ""
	End Sub

	Protected Function validarcomentarios()
		If txtcomentarios.Text.Length < 3 Then
			Return False
		Else
			Return True
		End If
	End Function

	Protected Function validarInicio(ByVal num As Integer)
		Dim Sql As String = "SELECT ID_CALIDAD, FECHA_HORA_INI FROM TB_CITAS_CALIDAD WHERE ID_CALIDAD = '" & num & "' AND FECHA_HORA_INI IS NOT NULL"
		Dim DT As DataTable = New DataTable
		DT = BDClass.SQLtoDataTable(Sql, False)
		If Not DT.Rows.Count > 0 Then
			Return False
		Else
			Return True
		End If
	End Function


	Protected Sub llenafinalizados()
		Dim dt As New DataTable
		Dim sQRY As String = ""
		sQRY = "select a.* from V_CALIDAD_FINALIZADOS a WHERE  fecha   between cast('" & String.Format("{0:s}", CDate(txtFec1.Text).AddDays(-1)) & "' as datetime) and cast('" & String.Format("{0:s}", CDate(txtFec2.Text).AddDays(1)) & "' as datetime)  order by a.fecha  desc"
		dt = BDClass.SQLtoDataTable(sQRY, False)
		Me.gridfinalizados.DataSource = dt
		Me.gridfinalizados.DataBind()
		Me.gridfinalizados.Style("display") = "inline"
	End Sub

	Protected Sub llenafinalizados1()
		txtFec1.Text = Date.Now.Date
		txtFec2.Text = Date.Now.Date
		Dim dt As New DataTable
		Dim sQRY As String = ""
		sQRY = "select * from V_CALIDAD_FINALIZADOS a WHERE  convert(date,fecha) = convert(date,getdate())"
		dt = BDClass.SQLtoDataTable(sQRY, False)
		Me.gridfinalizados.DataSource = dt
		Me.gridfinalizados.DataBind()
		Me.gridfinalizados.Style("display") = "inline"
	End Sub

	Protected Sub desactivarcontroles()
		If Me.lblagregarunidad.Style("display") = "none" Then
			Me.lblagregarunidad.Style("display") = "inline"
			Me.buscador0.Style("display") = "inline"
			Me.cmdVehiduloEntaller.Style("display") = "inline"
			Me.imgAgregar.Style("display") = "inline"
			Me.imgAgregarNUevo.Style("display") = "inline"
		Else
			Me.lblagregarunidad.Style("display") = "none"
			Me.buscador0.Style("display") = "none"
			Me.cmdVehiduloEntaller.Style("display") = "none"
			Me.imgAgregar.Style("display") = "none"
			Me.imgAgregarNUevo.Style("display") = "none"
		End If
	End Sub

	Protected Sub CmdBuscarLavadorFinish_Click(sender As Object, e As EventArgs)
		llenafinalizados()
	End Sub
End Class