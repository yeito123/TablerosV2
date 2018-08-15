Imports TablerosV2LibTypes

Partial Public Class zRecepcionAsesoresServiciosOrden
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LlenadgPrincipal()
        End If

    End Sub
    Sub LlenadgPrincipal()
        'Dim objAPP As New APPClass
        Dim sqry As String
        Dim DT As New DataTable

        LBLVIN.Text = Trim(Session("VIN"))
        LBLORDEN.Text = Session("numcita")
        LBLPLACAS.Text = Session("noPlacas")

        sqry = " SELECT * from " & System.Web.Configuration.WebConfigurationManager.AppSettings("v_historico_ordenes") & "  where placas='" & LBLPLACAS.Text & "' order by fecha desc "


        DT = BDClass.SQLtoDataTable(sqry, False)


        gvServiciosH.DataSource = DT
        gvServiciosH.DataBind()

         
    End Sub


End Class
