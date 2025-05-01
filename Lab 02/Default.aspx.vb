Imports System.Web.UI
Imports Microsoft.VisualBasic

Partial Class _Default
    Inherits Page

    ' Button click event
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.ServerClick
        msg.InnerHtml &= "<br/>BUTTON CLICKED!"
    End Sub

    ' Page Load event
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = True Then
            msg.InnerHtml &= "<hr>"
        End If

        msg.InnerHtml &= "<br/>Page Load"
    End Sub

    ' Page Unload event
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        msg.InnerHtml &= "<br/>Page UnLoad"
    End Sub

    ' Page Init event
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        msg.InnerHtml &= "<br/>Page Init"
    End Sub

    ' Page PreRender event
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Me.IsPostBack = False Then
            Text1.Value = "It is confirmed that page Pre Render has occurred during FIRST REQUEST <3"
        Else
            Text1.Value = "It is confirmed that page Pre Render has occurred during POSTBACK <3"
        End If

        msg.InnerHtml &= "<br/>Page Pre Render"
    End Sub

End Class
