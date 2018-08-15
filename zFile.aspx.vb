Imports System.IO
Imports TablerosV2LibTypes
Public Class zFile
    Inherits System.Web.UI.Page
    Const TCUESTIONARIO = 3
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtNoorden.Value = Session("Orden") 'Request.QueryString("Noorden")
        If Not Page.IsPostBack Then
            llenaimagenes()
        End If

    End Sub
    Sub llenaimagenes()
        If Session("Orden") Is Nothing Then Exit Sub
        If Session("Orden") = "" Then Exit Sub
        Dim dt As New DataTable
        Dim attach As New attach
        dt = attach.LeerBinarios(TCUESTIONARIO, Session("Orden"))
        Dim scriptString As String = ""
        Dim ixdiv As New HtmlImage
        For i = 0 To dt.Rows.Count - 1
            ixdiv = New HtmlImage
            ixdiv.Src = "~/img/sdetalle.gif"
            ixdiv.ID = obtenValor("txtNoorden") & "_" & dt.Rows(i).Item(0)

            ixdiv.Style.Add("Left", dt.Rows(i).Item("hleft") & "px")
            ixdiv.Style.Add("top", dt.Rows(i).Item("htop") & "px")

            ixdiv.Style.Add("cursor", "hand")
            ixdiv.Style.Add("position", "absolute")
            ixdiv.Visible = True
            ixdiv.Style.Add("width", "20px")
            ixdiv.Style.Add("clear", "none")
            ixdiv.Style.Add("z-index", "1500")

            scriptString = "var xwin=window.open('File.aspx?tcuestionario=" & TCUESTIONARIO & "&noorden=" & Session("Orden") & "&idimg=" & dt.Rows(i).Item(0) & "', '', 'status=no,toolbar=no,menubar=no,personalbar=no,scrollbars=yes,resizable=yes,modal=yes,dependable=no;');xwin.resizeTo(1000,694);xwin.moveTo(0,0); "

            ixdiv.Style.Add("background-position", "left top")
            ixdiv.Attributes.Add("ondblclick", scriptString)
            Me.form1.Controls.Add(ixdiv)
        Next


    End Sub
    Protected Sub ucmdCargar_Click(sender As Object, e As EventArgs) Handles ucmdCargar.Click
        If Trim(Path.GetFileName(Me.utxtArchivo.PostedFile.FileName)) = "" Or txtNoorden.Value = "" Then Exit Sub
        Dim attach As New attach
        attach.Agregar(Me.utxtArchivo, TCUESTIONARIO, obtenValor("txtNoorden"), obtenValor("hoffsettop"), obtenValor("hoffsetleft"), obtenValor("htop"), obtenValor("hleft"))
        llenaimagenes()
    End Sub


    Private Function obtenValor(ByVal ItemRequest As String) As String
        For Each nRequest As String In Request.Form
            If nRequest.LastIndexOf(ItemRequest.Trim) > -1 Then
                Return Request.Form(nRequest).Trim
            End If
        Next
        Return ""
    End Function

    Protected Sub cmdActualizar_Click(sender As Object, e As EventArgs) Handles cmdActualizar.Click
        llenaimagenes()
    End Sub
End Class