Imports System.Data.SqlClient


Partial Class Registeration
    Inherits System.Web.UI.Page

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs)
        Dim conStr As String = "Data Source=localhost;Initial Catalog=SSMS;Integrated Security=True"
        Dim query As String = "INSERT INTO Customer (Customer_name, Address, Phone) VALUES (@FullName, @Address, @Phone)"

        Using con As New SqlConnection(conStr)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@FullName", txtName.Text.Trim())
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        ' Optional: Show a success message or clear form
        Response.Write("<script>alert('Registration successful!');</script>")
    End Sub
End Class
