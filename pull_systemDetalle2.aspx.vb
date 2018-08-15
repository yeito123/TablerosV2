Imports TablerosV2LibTypes
Partial Public Class pull_systemDetalle2
    Inherits System.Web.UI.Page

    Private Sub pull_systemDetalle_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim sOrdenDetalle = Request("sOrdenDetalle")
        Dim iPullLinks As String
        If sOrdenDetalle <> "" Then
            If CType(Session("dtGenerales"), DataTable).Select("noorden='" & sOrdenDetalle & "'").Length > 0 Then

                Select Case Left(CType(Session("dtGenerales"), DataTable).Select("noorden='" & sOrdenDetalle & "'")(0)("idficha"), 1)
                    Case "f"
                        iPullLinks = "lblTotF"
                    Case "v"
                        iPullLinks = "lblTotV"
                    Case "o"
                        iPullLinks = "lblTotO"
                    Case "s"
                        iPullLinks = "lblTotS"
                    Case "d"
                        iPullLinks = "lblTotD"
                    Case "n"
                        iPullLinks = "lblTotN"
                    Case "m"
                        iPullLinks = "lblTotM"
                    Case "g"
                        iPullLinks = "lblTotG"
                    Case "l"
                        iPullLinks = "lblTotL"
                    Case "p"
                        iPullLinks = "lblTotP"
                    Case "a"
                        iPullLinks = "lblTotA"
                    Case "b"
                        iPullLinks = "lblTotB"
                    Case "e"
                        iPullLinks = "lblTotE"
                    Case "w"
                        iPullLinks = "lblTotW"
                    Case "u"
                        iPullLinks = "lblToTU"
                    Case "j"
                        iPullLinks = "lblTotJ"
                    Case "q"
                        iPullLinks = "lblToTQ"
                    Case "x"
                        iPullLinks = "lblToTX"
                    Case "y"
                        iPullLinks = "lblToty"
                    Case "c"
                        iPullLinks = "lblTotc"
                    Case "z"
                        iPullLinks = "lblTotz"

                End Select
                LlenaGRid(iPullLinks)
                'Page.ClientScript.RegisterClientScriptBlock(GetType(Page), "popPullDet", "<script>      var xwin=window.open('pull_systemDetalle.aspx', '', 'status=yes,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=yes,modal=yes,dependable=yes;'); </script>")
            Else
                'Dim OBJCOL As New CHIPPullCollection
                ' OBJCOL.ObtenChipsAllFacturadas()
                If CType(Session("dtGenerales2"), DataTable).Select("noorden='" & sOrdenDetalle & "'").Length > 0 Then
                    LlenaGRid()
                    '  Page.ClientScript.RegisterClientScriptBlock(GetType(Page), "popPullDet", "<script>      var xwin=window.open('pull_systemDetalle.aspx', '', 'status=yes,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=yes,modal=yes,dependable=yes;'); </script>")
                Else
                    Response.Clear()
                    lblStatus.Text = "No se encontro orden " & sOrdenDetalle
                    '   Page.ClientScript.RegisterClientScriptBlock(GetType(Page), "popPullDet", "<script> alert('No se encontro la orden " & Split(sdhtml, "_")(0) & "');</script>")
                End If
            End If


        Else
            LlenaGRid()
        End If


    End Sub
    Sub LlenaGRid(Optional iPullLinks As String = "")
        Dim sqry As String
        Dim sPullLinks As String = Request("PullLinks")
        Dim sAsesor As String = Request("Asesor")

        If Not sAsesor Is Nothing Then
            lblStatus.Text = Request("Asesor")
            sqry = "select * from  v_detalle_pull_asesor x where  x.nombre='" & sAsesor & "'  order by  convert(varchar, x.fecha, 110)  "
            Dim dt As New DataTable
            dt = BDClass.SQLtoDataTable(sqry, False)

            Session("dtDetalle") = dt
            dg1.DataSource = dt
            dg1.DataBind()

        Else
            If iPullLinks <> "" Then sPullLinks = iPullLinks


            '  lblStatus.Text = "En Espera de Servicio"
            sqry = "select distinct a.* from  v_detalle_pull_asesor2 a   where isnull(idficha,'') like  '%" & Replace(sPullLinks, "lblTot", "") & "%' order by  a.[fecha DMS] desc      "



            Dim dt As New DataTable, DT2 As New DataTable
            dt = BDClass.SQLtoDataTable(sqry, False)
            Dim sOrdenDetalle = Request("sOrdenDetalle")


            Session("dtDetalle") = dt
            dg1.DataSource = dt
            dg1.DataBind()
        End If




    End Sub

    Protected Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        ExportDataSetToExcel()
    End Sub
    Sub ExportDataSetToExcel()
        Dim dt As DataTable
        If Session("dtDetalle") Is Nothing Then Exit Sub
        dt = Session("dtDetalle")
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
        Session.Remove("dtDetalle")
    End Sub
    Private Sub dg1_PreRender(sender As Object, e As EventArgs) Handles dg1.PreRender
        Dim sOrdenDetalle = Request("sOrdenDetalle")
        If sOrdenDetalle <> "" Then
            Dim i As Integer = 0
            For i = 0 To dg1.Items.Count - 1
                If dg1.Items(i).Cells(2).Text = sOrdenDetalle Then
                    dg1.SelectedIndex = i
                    dg1.Items(i).Focus()

                End If
            Next
        End If

    End Sub

End Class
