Imports TablerosV2LibTypes

Imports System.Data
Partial Public Class Ausencias
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        If Not Page.IsPostBack Then
            llenacbosinifin()
            llenaEmpleados()
            llenagrid()


        End If
        If rdlModalidad.Items(0).Selected Then
            ausDia.Visible = True
            ausPeriodo.Visible = False
        Else
            ausDia.Visible = False
            ausPeriodo.Visible = True
        End If

    End Sub
    Sub llenacbosinifin()
        Dim sqry As String = ""
        Dim i As Integer


        Dim dt As New DataTable

        sqry = "SELECT DISTINCT hora FROM Tb_PRG_CHIP_X  "

        dt = BDClass.SQLtoDataTable(sqry, False)
        cboIni.Items.Clear()
        cboFin.Items.Clear()

        For i = 0 To dt.Rows.Count - 1
            cboIni.Items.Add(New ListItem(dt.Rows(i).Item(0)))
            cboFin.Items.Add(New ListItem(dt.Rows(i).Item(0)))
            cboIniPer.Items.Add(New ListItem(dt.Rows(i).Item(0)))
            cboFinPer.Items.Add(New ListItem(dt.Rows(i).Item(0)))

        Next

    End Sub
    Sub llenaEmpleados()
        Dim sqry As String = ""
        Dim i As Integer

        Dim dt As New DataTable

        txtPCalVigInicio.Text = Date.Now.ToShortDateString

        txtfecfin.Text = Date.Now.ToShortDateString

        txtfecini.Text = Date.Now.ToShortDateString

        sqry = "SELECT DISTINCT id_empleado,nombre_empleado, id_tipo_empleado FROM tb_tecnicos  order by id_tipo_empleado, nombre_empleado asc "

        dt = BDClass.SQLtoDataTable(sqry, False)


        cboEmpleados.Items.Clear()

        cboEmpleados2.Items.Clear()

        For i = 0 To dt.Rows.Count - 1
            cboEmpleados.Items.Add(New ListItem(dt.Rows(i).Item(1) & "(" & dt.Rows(i).Item(2) & ")", dt.Rows(i).Item(0)))
            cboEmpleados2.Items.Add(New ListItem(dt.Rows(i).Item(1) & "(" & dt.Rows(i).Item(2) & ")", dt.Rows(i).Item(0)))
            cbomodTecnicos.Items.Add(New ListItem(dt.Rows(i).Item(1) & "(" & dt.Rows(i).Item(2) & ")", dt.Rows(i).Item(0)))
        Next
    End Sub
    Sub llenagrid()
        Dim sqry As String = ""


        Dim dt As New DataTable

        sqry = "SELECT a.id_empleado, a.ID_TIPO_EMPLEADO, a.fecha, a.e1, a.s1, a.c1, b.nombre_empleado, a.tausencia from tb_ausencias a inner join tb_tecnicos b on a.ID_EMPLEADO=b.ID_EMPLEADO where  periodo is null   order by a.fecha desc, a.id_empleado desc"

        dt = BDClass.SQLtoDataTable(sqry, False)
        dgAusencias.DataSource = dt
        dgAusencias.DataBind()

        '  sqry = "SELECT a.id_empleado, a.ID_TIPO_EMPLEADO, a.fecha,  b.nombre_empleado from tb_ausencias a inner join tb_tecnicos b on a.ID_EMPLEADO=b.ID_EMPLEADO where  not a.ausenciaTotal is null   order by a.fecha desc, a.id_empleado desc"
        sqry = "SELECT periodo,a.id_empleado,  convert(VARCHAR,min(a.fecha), 103) +  ' - ' +  CONVERT(VARCHAR,max(a.fecha) , 103) periodo_s, a.e1, a.s1,  b.nombre_empleado, a.tausencia "
        sqry += " from tb_ausencias a inner join tb_tecnicos b on a.ID_EMPLEADO=b.ID_EMPLEADO"
        sqry += "  where Not periodo Is null"
        sqry += " GROUP BY periodo, a.ID_EMPLEADO,   a.E1, a.S1, b.NOMBRE_EMPLEADO, a.tausencia"
        sqry += " order by convert(VARCHAR,min(a.fecha), 103) +  ' - ' +  CONVERT(VARCHAR,max(a.fecha), 103) desc"

        dt = BDClass.SQLtoDataTable(sqry, False)
        dgAusenciasPeriodo.DataSource = dt
        dgAusenciasPeriodo.DataBind()
    End Sub



    Protected Sub imgSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSalir.Click
        Response.Redirect("Inicio.aspx")
    End Sub

    Protected Sub cmdEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim sqry As String = ""
        sqry = "delete  tb_ausencias  where id_empleado='" & dgAusencias.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(0).Text & "' and fecha=cast('" & String.Format("{0:s}", CDate(dgAusencias.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(3).Text)) & "' as datetime)"
        BDClass.ExecuteQuery(sqry, False)
        llenagrid()
    End Sub
    Protected Sub cmdEliminar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim sqry As String = ""
        sqry = "delete  tb_ausencias  where periodo='" & dgAusenciasPeriodo.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(0).Text & "'"
        BDClass.ExecuteQuery(sqry, False)
        llenagrid()
    End Sub

    Protected Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        Dim sqry As String = ""
        sqry = "insert into  tb_ausencias(ID_EMPLEADO,ID_TIPO_EMPLEADO,fecha,E1,S1, tausencia) values ('" & cboEmpleados.SelectedItem.Value & "','" & cboEmpleados.SelectedItem.Text.Substring(InStr(cboEmpleados.SelectedItem.Text, "("), InStr(cboEmpleados.SelectedItem.Text, ")") - InStr(cboEmpleados.SelectedItem.Text, "(") - 1) & "',cast('" & String.Format("{0:s}", CDate(txtPCalVigInicio.Text.Trim)) & "' as datetime),'" & cboIni.SelectedItem.Text.Trim & "','" & cboFin.SelectedItem.Text.Trim & "', '" & cboTipo.SelectedItem.Text & "')"
        BDClass.ExecuteQuery(sqry, False)
        llenaEmpleados()
        llenagrid()
    End Sub

    Private Sub cmdAgregarPeriodo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregarPeriodo.Click
        Dim sqry As String = "", dt As New DataTable
        Dim speriodo As Integer
        sqry = "SELECT max(isnull(periodo, 0))+1 mperiodo from tb_ausencias "

        dt = BDClass.SQLtoDataTable(sqry, False)
        speriodo = dt.Rows(0).Item(0)
        Dim idias As Integer = DateDiff(DateInterval.Day, CDate(CDate(txtfecini.Text).ToShortDateString), CDate(CDate(txtfecfin.Text).ToShortDateString))
        For i = 0 To idias
            sqry = "insert into  tb_ausencias(ID_EMPLEADO,ID_TIPO_EMPLEADO,fecha,E1,S1, tausencia, periodo) values ('" & cboEmpleados2.SelectedItem.Value & "','" & cboEmpleados2.SelectedItem.Text.Substring(InStr(cboEmpleados2.SelectedItem.Text, "("), InStr(cboEmpleados2.SelectedItem.Text, ")") - InStr(cboEmpleados2.SelectedItem.Text, "(") - 1) & "',cast('" & String.Format("{0:s}", CDate(CDate(txtfecini.Text.Trim).ToShortDateString).AddDays(i)) & "' as datetime),'" & cboIniPer.SelectedItem.Text.Trim & "','" & cboFinPer.SelectedItem.Text.Trim & "', '" & cboTipo2.SelectedItem.Text & "', " & speriodo & ")"

            ' sqry = "insert into  tb_ausencias(ID_EMPLEADO,ID_TIPO_EMPLEADO,fecha,ausenciaTotal, tausencia) values ('" & cboEmpleados2.SelectedItem.Value & "','" & cboEmpleados2.SelectedItem.Text.Substring(InStr(cboEmpleados2.SelectedItem.Text, "("), InStr(cboEmpleados2.SelectedItem.Text, ")") - InStr(cboEmpleados2.SelectedItem.Text, "(") - 1) & "',cast('" & String.Format("{0:s}", CDate(CDate(txtfecini.Text.Trim).ToShortDateString).AddDays(i)) & "' as datetime),1, '" & cboTipo2.SelectedItem.Text & "')"

            BDClass.ExecuteQuery(sqry, False)
        Next
        llenaEmpleados()
        llenagrid()
    End Sub

    Protected Sub OKButton_Click(sender As Object, e As EventArgs)
        Dim sqry As String = ""
        Dim idias As Integer = DateDiff(DateInterval.Day, CDate(CDate(fechaIni.Text).ToShortDateString), CDate(CDate(FechaFin.Text).ToShortDateString))
        For i = 0 To idias
            sqry = "delete  tb_ausencias  where id_empleado='" & cbomodTecnicos.SelectedItem.Value & "' and fecha between cast('" & String.Format("{0:s}", CDate(CDate(txtfecini.Text.Trim).ToShortDateString)) & "' as datetime) " _
            & " ' and cast('" & String.Format("{0:s}", CDate(CDate(txtfecfin.Text.Trim).ToShortDateString)) & "' as datetime)"


            BDClass.ExecuteQuery(sqry, False)
        Next
        llenaEmpleados()
        llenagrid()
    End Sub


End Class