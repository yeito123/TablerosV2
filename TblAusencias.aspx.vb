Imports TablerosV2LibTypes

Public Class TblAusencias
    Inherits System.Web.UI.Page
    Dim m As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            llenaEmpleados()
            llenacbosinifin()
            llenaTipoAusencia()
        End If
    End Sub

    Protected Sub btnSalir_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("Inicio.aspx")
    End Sub

    Sub llenaEmpleados()
        Dim sqry As String = ""
        Dim i As Integer
        Dim obj As New BDClass
        Dim dt As New DataTable
        sqry = "SELECT DISTINCT id_empleado,nombre_empleado, id_tipo_empleado FROM TB_tecnicos  order by id_tipo_empleado, nombre_empleado asc "
        dt = obj.SQLtoDataTable(sqry, False)
        cmbTecnico.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cmbTecnico.Items.Add(New ListItem(dt.Rows(i).Item(1) & "(" & dt.Rows(i).Item(2) & ")", dt.Rows(i).Item(0)))
        Next
        Me.cmbTecnico.Items.Insert(0, "--SELECCIONAR TECNICO--")
    End Sub

    Function llenagrid(ByVal num As String) As Boolean
        Dim sqry As String = ""
        Dim obj As New BDClass
        Dim dt As New DataTable
        sqry = "SELECT a.id_empleado, a.ID_TIPO_EMPLEADO, a.fecha, a.e1, a.s1, a.c1, a.nombre_empleado, tausencia from v_TB_AUSENCIAS a  where  a.id_empleado = '" & num & "'"
        dt = obj.SQLtoDataTable(sqry, False)
        If dt.Rows.Count > 0 Then
            GridTecnicos.DataSource = dt
            GridTecnicos.DataBind()
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub cmbTecnico_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim num As String
        num = cmbTecnico.SelectedItem.Value.ToString
        If llenagrid(num) Then
            GridTecnicos.Visible = True
        Else
            If GridTecnicos.Visible = True Then
                GridTecnicos.Visible = False
            End If
            m = "El técnico que selecciono no tiene ausencias pendientes o activas"
            Response.Write("<script>window.alert('" & m & "');</script>")
        End If
    End Sub

    Protected Sub imgMenuAgregar_Click(sender As Object, e As ImageClickEventArgs)
        Dim n As Integer = CInt(txtActivo.Text)
        If (n = 0) Then
            Me.pnlAgregar.Style("display") = "inline"
            'Me.txtActivo.Style("display") = "inline"
            txtActivo.Text = "1"
        Else
            Me.pnlAgregar.Style("display") = "none"
            'Me.txtActivo.Style("display") = "none"
            txtActivo.Text = "0"
        End If
    End Sub
    Protected Sub llenacbosinifin()
        Dim sqry As String = ""
        Dim i As Integer
        Dim dt As New DataTable
        sqry = "SELECT DISTINCT top 100 percent hora, orden FROM Tb_horas order by orden asc"
        dt = BDClass.SQLtoDataTable(sqry, False)
        cmdHoraInicio.Items.Clear()
        cmdHoraFin.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cmdHoraInicio.Items.Add(New ListItem(dt.Rows(i).Item(0)))
            cmdHoraFin.Items.Add(New ListItem(dt.Rows(i).Item(0)))
        Next
    End Sub
    Protected Sub llenaTipoAusencia()
        Dim sqry As String = ""
        Dim i As Integer
        Dim dt As New DataTable
        sqry = "SELECT [id],[tipo_ausencia] FROM [TB_TIPO_AUSENCIA]"
        dt = BDClass.SQLtoDataTable(sqry, False)
        cmdTIpo.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            cmdTIpo.Items.Add(New ListItem(dt.Rows(i).Item(1)))
            cmdTipoBorrar.Items.Add(New ListItem(dt.Rows(i).Item(1)))
        Next
    End Sub
    Protected Sub imgIncertar_Click(sender As Object, e As ImageClickEventArgs)
        Dim s As String = txtfechaFin.Text
        If ((cmbTecnico.SelectedItem.Value.ToString).Equals("--SELECCIONAR TECNICO--")) Then
            m = "Debe Seleccionar un Tecnico antes de seguir"
            muestraMensaje()
            Return
        End If
        If Not (checkPeriodo.Checked) Then
            If (s.Equals("")) Then
                s = txtFechaInicio.Text.Trim
                If Not (s.Equals("")) Then
                    InsertarDia()
                Else
                    m = "Debe elegir una FECHA  para la ausencia."
                    muestraMensaje()
                    txtFechaInicio.Focus()
                End If
            End If
        Else
            Dim i As String = txtFechaInicio.Text.Trim
            Dim f As String = txtfechaFin.Text.Trim
            If Not (i.Equals("") Or f.Equals("")) Then
                insertarPeriodo()
            Else
                m = "La fecha de inicio: " & i & " o la fecha: " & f & " de fin de la ausencia estan vacías, debe elegir alguna "
                muestraMensaje()
                txtFechaInicio.Focus()
            End If
        End If
    End Sub
    Protected Sub InsertarDia()
        Dim sqry As String = ""
        Dim obj As New BDClass
        Dim num As String = cmbTecnico.SelectedItem.Value.ToString
        Dim tipoEmpleado As String = cmbTecnico.SelectedItem.Text.Substring(InStr(cmbTecnico.SelectedItem.Text, "("), InStr(cmbTecnico.SelectedItem.Text, ")") - InStr(cmbTecnico.SelectedItem.Text, "(") - 1)
        Dim fecha As String = String.Format("{0:s}", CDate(txtFechaInicio.Text.Trim))
        Dim horaIni As String = cmdHoraInicio.SelectedItem.Text.Trim
        Dim horaFin As String = cmdHoraFin.SelectedItem.Text.Trim
        Dim tipoAusencia As String = cmdTIpo.SelectedItem.Text
        If Not (horaIni = horaFin) Then
            sqry = "insert into  TB_AUSENCIAS(ID_EMPLEADO,ID_TIPO_EMPLEADO,fecha,E1,S1, tausencia) "
            sqry += "values ('" & num & "','" & tipoEmpleado & "',cast('" & fecha & "' as datetime),'" & horaIni & "','" & horaFin & "', '" & tipoAusencia & "')"
            obj.ExecuteQuery(sqry, False)
            If llenagrid(num) Then
                GridTecnicos.Visible = True
            End If
        Else
            m = "La Hora de inicio " & horaIni & " es igual a la hora de fin " & horaFin & " Deben ser diferentes."
            muestraMensaje()
            cmdHoraFin.Focus()
        End If
    End Sub

    Protected Sub insertarPeriodo()
        Dim sqry As String = ""
        Dim obj As New BDClass
        Dim num As String = cmbTecnico.SelectedItem.Value.ToString
        Dim tipoEmpleado As String = cmbTecnico.SelectedItem.Text.Substring(InStr(cmbTecnico.SelectedItem.Text, "("), InStr(cmbTecnico.SelectedItem.Text, ")") - InStr(cmbTecnico.SelectedItem.Text, "(") - 1)
        Dim fecha As String = String.Format("{0:s}", CDate(txtFechaInicio.Text.Trim))
        Dim horaIni As String = cmdHoraInicio.SelectedItem.Text.Trim
        Dim horaFin As String = cmdHoraFin.SelectedItem.Text.Trim
        Dim tipoAusencia As String = cmdTIpo.SelectedItem.Text
        Dim idias As Integer = DateDiff(DateInterval.Day, CDate(CDate(txtFechaInicio.Text).ToShortDateString), CDate(CDate(txtfechaFin.Text).ToShortDateString))
        Dim i As Integer
        If Not (horaIni = horaFin) Then
            For i = 0 To idias
                fecha = String.Format("{0:s}", CDate(CDate(txtFechaInicio.Text.Trim).ToShortDateString).AddDays(i))
                sqry = "insert into  TB_AUSENCIAS(ID_EMPLEADO,ID_TIPO_EMPLEADO,fecha,E1,S1, tausencia) "
                sqry += "values ('" & num & "','" & tipoEmpleado & "',cast('" & fecha & "' as datetime),'" & horaIni & "','" & horaFin & "', '" & tipoAusencia & "')"
                obj.ExecuteQuery(sqry, False)
            Next
            If llenagrid(num) Then
                GridTecnicos.Visible = True
            End If
        Else
            m = "La Hora de inicio " & horaIni & " es igual a la hora de fin " & horaFin & " Deben ser diferentes."
            muestraMensaje()
            cmdHoraFin.Focus()
        End If
    End Sub
    Protected Sub muestraMensaje()
        Response.Write("<script>window.alert('" & m & "');</script>")
    End Sub
    Protected Sub checkPeriodo_CheckedChanged(sender As Object, e As EventArgs)
        Dim n As Integer = CInt(lblcheck.Text)
        If (n = 0) Then
            Me.lblDiaFin.Style("display") = "inline"
            Me.txtfechaFin.Style("display") = "inline"
            lblcheck.Text = "1"
        Else
            Me.lblDiaFin.Style("display") = "none"
            Me.txtfechaFin.Style("display") = "none"
            txtfechaFin.Text = ""
            lblcheck.Text = "0"
        End If
    End Sub
    Protected Sub imgEliminar_Click(sender As Object, e As ImageClickEventArgs)
        Dim selectedindex = CType(sender.Parent.Parent, DataGridItem).ItemIndex
        Me.GridTecnicos.SelectedIndex = selectedindex
        Dim id_tecnico As Integer = CInt(GridTecnicos.SelectedItem.Cells(0).Text)
        Dim fecha As String = Convert.ToString(GridTecnicos.SelectedItem.Cells(3).Text)
        Dim tipoAusencia As String = Convert.ToString(GridTecnicos.SelectedItem.Cells(7).Text)
        Dim sql As String = ""
        sql = "DELETE FROM TB_AUSENCIAS WHERE ID_EMPLEADO = '" & id_tecnico & "' AND TAUSENCIA = '" & tipoAusencia & "' "
        sql += "AND CONVERT(DATE,FECHA) = '" & fecha & "'"
        BDClass.ExecuteQuery(sql, False)
        If llenagrid(id_tecnico) Then
            GridTecnicos.Visible = True
        End If
    End Sub

    Protected Sub imgMenuBorrar_Click(sender As Object, e As ImageClickEventArgs)
        Dim n As Integer = CInt(lblBorrarActivo.Text)
        If (n = 0) Then
            Me.pnlBorrar.Style("display") = "inline"
            'Me.txtActivo.Style("display") = "inline"
            lblBorrarActivo.Text = "1"
        Else
            Me.pnlBorrar.Style("display") = "none"
            'Me.txtActivo.Style("display") = "none"
            lblBorrarActivo.Text = "0"
        End If
    End Sub

    Protected Sub ImgBorrar_Click(sender As Object, e As ImageClickEventArgs)
        If ((cmbTecnico.SelectedItem.Value.ToString).Equals("--SELECCIONAR TECNICO--")) Then
            m = "Debe Seleccionar un Tecnico antes de seguir"
            muestraMensaje()
            Return
        End If
        Dim i As String = txtDiaIBorrar.Text.Trim
        Dim f As String = txtFFBorrar.Text.Trim
        If Not (i.Equals("") Or f.Equals("")) Then
            borrarPeriodo()
        Else
            m = "La fecha de inicio: " & i & " o la fecha: " & f & " de fin de la ausencia estan vacías, debe elegir alguna "
            muestraMensaje()
            txtDiaIBorrar.Focus()
        End If
    End Sub

    Protected Sub borrarPeriodo()
        Dim fechai As String = txtDiaIBorrar.Text.Trim
        Dim fechaf As String = txtFFBorrar.Text.Trim
        Dim id_tecnico As Integer = cmbTecnico.SelectedItem.Value.ToString
        Dim tipoAusencia As String = cmdTipoBorrar.SelectedItem.Value.ToString
        Dim idias As Integer = DateDiff(DateInterval.Day, CDate(CDate(txtDiaIBorrar.Text).ToShortDateString), CDate(CDate(txtFFBorrar.Text).ToShortDateString))
        Dim fecha As String
        Dim sql As String = ""
        For i = 0 To idias
            fecha = String.Format("{0:s}", CDate(CDate(fechai).ToShortDateString).AddDays(i))
            sql = "DELETE FROM TB_AUSENCIAS WHERE ID_EMPLEADO = '" & id_tecnico & "' AND TAUSENCIA = '" & tipoAusencia & "' "
            sql += "AND CONVERT(DATE,FECHA) = '" & fecha & "'"
            BDClass.ExecuteQuery(sql, False)
            If llenagrid(id_tecnico) Then
                GridTecnicos.Visible = True
            End If
        Next
        If llenagrid(id_tecnico) Then
            GridTecnicos.Visible = True
        End If

    End Sub
End Class