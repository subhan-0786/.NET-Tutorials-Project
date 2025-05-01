Imports System.Data.SqlClient
Imports System.Data

Partial Class Search
    Inherits System.Web.UI.Page

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        Dim conStr As String = "Data Source=localhost;Initial Catalog=SSMS;Integrated Security=True"
        Dim query As String = "SELECT * FROM Product WHERE Product_Name LIKE @product"

        Using con As New SqlConnection(conStr)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@product", "%" & txtSearch.Text.Trim() & "%")
                Using adapter As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    If dt.Rows.Count > 0 Then
                        gvResults.Visible = True
                        gvResults.DataSource = dt
                        gvResults.DataBind()
                    Else
                        gvResults.Visible = False
                    End If
                End Using
            End Using
        End Using
    End Sub
End Class