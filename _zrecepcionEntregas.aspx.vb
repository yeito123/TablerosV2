Imports TablerosV2LibTypes

Partial Class _nzRecepcionEntregas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            LlenadgPrincipal()
            

        End If

    End Sub
     
     
    Sub LlenadgPrincipal()
        Dim dt As New DataTable
        Dim sqry As String = ""

        Dim ipage As Integer = dg1.CurrentPageIndex
        ' sqry = "Select * from TYT_LV_TBL_CONTROL_CITAS_header where  year(fecha)=" & Date.Now.Year & " and month(fecha)=" & Date.Now.Month & " and day(fecha)=" & Date.Now.Day & "  and NUMCITA<>'0' AND NOORDEN ='0'   order by HORAASESOR asc"

        sqry = " select * from v_header_recepcion_anterior order by horallegada desc"



        dt = BDClass.SQLtoDataTable(sqry, False)
        Session("dgnrecepcionEntregas") = dt
        dg1.DataSource = dt
        dg1.DataBind()
        dg1.CurrentPageIndex = 0


    End Sub



    Protected Sub dg1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dg1.PageIndexChanged
        dg1.CurrentPageIndex = e.NewPageIndex
        Dim dt As New DataTable
        If Not Session("dgnrecepcionEntregas") Is Nothing Then
            dt = Session("dgnrecepcionEntregas")
        End If
        dg1.DataSource = dt
        dg1.DataBind()
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


    End Sub
    Protected Sub OkButtonMPGV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OkButtonMPGV.Click

        Select Case lblOp.Text


            Case "1"
                GuardaEntrega(True, lblInf1.Text)
                LlenadgPrincipal()
                If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "Encuesta") = "1" And lblInf3.Text <> "0" And lblInf3.Text <> "" Then

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "Encuesta", "<script>  var xwin=window.open('_zcrmCuestionarioDetalle.aspx?noorden=" & lblInf3.Text & "', '', 'status=no,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=no,modal=yes,dependable=yes;');xwin.resizeTo(750,470);xwin.moveTo(0,0); </script>")


                    '                    Response.Redirect("_zcrmCuestionarioDetalle?noorden=" & lblInf3.Text)
                End If

        End Select

    End Sub

     

    Protected Sub lnkPlacas_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If CType(sender, CheckBox).Checked Then
        Dim sinf As String = CType(dg1.Items(CType(sender.parent.parent, DataGridItem).ItemIndex).FindControl("lblInfi"), Label).Text
        lblOp.Text = 1
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
        lblInf3.Text = Split(sinf, "__")(6) ' noorden
        lblInf2.Text = Split(sinf, "__")(1) 'hora llegada
        'Eval("idve") & "__" & If(Eval("horallegada") Is DBNull.Value, "00:00", Eval("horallegada")) & "__" & Eval("Cliente") & "__" & Eval("noplacas") & "__" & Eval("VIN") & "__" & Eval("fecha_hora_com") & "__" & Eval("vehiculo") & "__" & Eval("colorprisma")
        Select Case SOPCION
            Case "PLACAS"

                lblMSG.Text = "Desea Entregar el vehiculo? "

                  
        End Select

    End Sub
 
End Class
