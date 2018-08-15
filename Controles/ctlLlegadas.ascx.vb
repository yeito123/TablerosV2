Imports TablerosV2LibTypes
Public Class ctlLegadas
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MOSTRARRESUMEN()
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


        dg1.DataSource = dt
        dg1.DataBind()







    End Sub
End Class