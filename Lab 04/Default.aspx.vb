Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

        Dim connStr As String = "Server=localhost;Database=SSMS;Integrated Security=True"
        Dim query As String = "SELECT Employee_Name, Email, Salary FROM Employee"

        Dim conn As New SqlConnection(connStr)
        Dim cmd As New SqlCommand(query, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()

        Try
            conn.Open()
            adapter.Fill(dt)
            gridEmployees.DataSource = dt
            gridEmployees.DataBind()
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class
