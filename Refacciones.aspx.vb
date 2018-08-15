Imports TablerosV2LibTypes

Public Class Refacciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtFecha.Text = Date.Now.ToShortDateString
            llenagrid()
        End If
    End Sub
    Protected Sub lnkPieza_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If CType(sender, CheckBox).Checked Then

        lblOp.Text = 1
        lblInf1.Text = dgAusencias.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text
        
        mOSTTRARoCULTAR("pieza")

        MPGV.Show()

        'Else

        'End If
    End Sub
    Protected Sub lnkNoparte_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If CType(sender, CheckBox).Checked Then

        lblOp.Text = 2
        lblInf1.Text = dgAusencias.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text

        mOSTTRARoCULTAR("noparte")

        MPGV.Show()

        'Else

        'End If
    End Sub
    Protected Sub lnkObservaciones_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If CType(sender, CheckBox).Checked Then

        lblOp.Text = 3
        lblInf1.Text = dgAusencias.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).Cells(1).Text

        mOSTTRARoCULTAR("observaciones")

        MPGV.Show()

        'Else

        'End If
    End Sub
    Sub mOSTTRARoCULTAR(SOPCION As String)
        lblModPieza.Visible = False
        txtModPieza.Visible = False
        lblModNoparte.Visible = False
        txtModNoparte.Visible = False
        lblModObservaciones.Visible = False
        txtModObservaciones.Visible = False
       

        Select Case SOPCION
            Case "pieza"
                lblModPieza.Visible = True
                txtModPieza.Text = ""
                txtModPieza.Visible = True
            Case "noparte"
                lblModNoparte.Visible = True
                txtModNoparte.Text = ""
                txtModNoparte.Visible = True
            Case "observaciones"
                lblModObservaciones.Visible = True
                txtModObservaciones.Text = ""
                txtModObservaciones.Visible = True

        End Select

    End Sub
    Sub guardarPieza()
        Dim sqry As String = ""

        If BDClass.SQLtoDataTable("select * from  TB_CITAS_refacciones where  id =" & lblInf1.Text & "", False).Rows.Count = 0 Then
             sqry = " insert into  "
            sqry += "     TB_CITAS_refacciones(id)  values  (" & lblInf1.Text & ") "

            BDClass.ExecuteQuery(sqry, False)
        End If


        sqry = " Update  "
        sqry += "     TB_CITAS_refacciones set pieza='" & txtModPieza.Text.Trim & "'"
        sqry += " where  id =" & lblInf1.Text & " "
        BDClass.ExecuteQuery(sqry, False)
         

    End Sub

    Sub guardarParte()
        Dim sqry As String = ""

        If BDClass.SQLtoDataTable("select * from  TB_CITAS_refacciones where  id =" & lblInf1.Text & "", False).Rows.Count = 0 Then
            sqry = " insert into  "
            sqry += "     TB_CITAS_refacciones(id)  values  (" & lblInf1.Text & ") "

            BDClass.ExecuteQuery(sqry, False)
        End If


        sqry = " Update  "
        sqry += "     TB_CITAS_refacciones set noparte='" & txtModNoparte.Text.Trim & "'"
        sqry += " where  id =" & lblInf1.Text & " "
        BDClass.ExecuteQuery(sqry, False)


    End Sub

    Sub guardarObservaciones()
        Dim sqry As String = ""

        If BDClass.SQLtoDataTable("select * from  TB_CITAS_refacciones where  id =" & lblInf1.Text & "", False).Rows.Count = 0 Then
            sqry = " insert into  "
            sqry += "     TB_CITAS_refacciones(id)  values  (" & lblInf1.Text & ") "

            BDClass.ExecuteQuery(sqry, False)
        End If


        sqry = " Update  "
        sqry += "     TB_CITAS_refacciones set observaciones='" & txtModObservaciones.Text.Trim & "'"
        sqry += " where  id =" & lblInf1.Text & " "
        BDClass.ExecuteQuery(sqry, False)


    End Sub
    Protected Sub OkButtonMPGV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OkButtonMPGV.Click

        Select Case lblOp.Text
            Case "1"
                guardarPieza()
            Case "2"
                guardarParte()
            Case "3"
                guardarObservaciones()

        End Select
        llenagrid()
    End Sub
    Sub llenagrid()
        Dim sqry As String = "select idref, pieza, noparte, observacionesrefa,fecharefaccion,id,  convert(varchar,FECHA, 103)  FECHA    ,HORA      ,ASESOR  ,ORDEN    ,MODELO      ,PLACAS      ,VIN      ,TECNICO      ,TELEFONO            ,año ,OBSERVACIONES, iRefacciones  from v_Prepicking_2_ref " 'where convert(varchar,fecha,12)=convert(varchar,cast('" & String.Format("{0:s}", CDate(txtFecha.Text)) & "' as datetime),12)"
        Dim dt As New DataTable
        dt = BDClass.SQLtoDataTable(sqry, False)
        dgAusencias.DataSource = dt
        dgAusencias.DataBind()
    End Sub

    Protected Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        llenagrid()
    End Sub

    Protected Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        Dim sqry As String = "select  irefacciones as refacciones,fecharefaccion,id,  convert(varchar,FECHA, 103)  FECHA    ,HORA      ,ASESOR  ,ORDEN    ,MODELO      ,PLACAS      ,VIN      ,TECNICO      ,TELEFONO            ,año ,OBSERVACIONES, pieza, noparte, observacionesrefa  from v_Prepicking_2_ref " ' where convert(varchar,fecha,12)=convert(varchar,cast('" & String.Format("{0:s}", CDate(txtFecha.Text)) & "' as datetime),12)"
        Dim dt As New DataTable
        dt = BDClass.SQLtoDataTable(sqry, False)
        ExportDataSetToExcel(dt)
    End Sub
    Sub ExportDataSetToExcel(ByVal dt As DataTable)
        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "prepick.xls"))
        HttpContext.Current.Response.ContentType = "application/ms-excel"
        Dim sw As System.IO.StringWriter = New System.IO.StringWriter
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim dg As New GridView
        dg.DataSource = dt
        dg.DataBind()
        dg.RenderControl(htw)
        '  render the htmlwriter into the response
        HttpContext.Current.Response.Write(sw.ToString)
        HttpContext.Current.Response.End()
    End Sub

    Private Sub imgSalir_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgSalir.Click
        Response.Redirect("Inicio.aspx")
    End Sub
    Protected Sub chkRefacciones_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sqry As String = ""


        If CType(sender, CheckBox).Checked Then
            sqry = " Update  "
            sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasRegistro") & " set continua=1 where id='" & dgAusencias.Items(sender.parent.parent.itemindex).Cells(1).Text & "' "

            BDClass.ExecuteQuery(sqry, False)


            sqry = " Update  "
            sqry += "   TB_CITAS_refacciones set fecharefaccion=getdate() where id='" & dgAusencias.Items(sender.parent.parent.itemindex).Cells(1).Text & "' "

            BDClass.ExecuteQuery(sqry, False)


            'Else
            '    sqry = " Update  "
            '    sqry += "   " & System.Web.Configuration.WebConfigurationManager.AppSettings("dmsCitasRegistro") & " set continua=0 where id='" & dgAusencias.Items(sender.parent.parent.itemindex).Cells(1).Text & "' "


            '    BDClass.ExecuteQuery(sqry, False)
        End If

        llenagrid()
    End Sub
End Class