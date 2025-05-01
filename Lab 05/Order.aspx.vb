Imports System.Data.SqlClient
Imports System.Data

Partial Class Order
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadProducts()
        End If
    End Sub

    Private Sub LoadProducts()
        Dim conStr As String = "Data Source=localhost;Initial Catalog=SSMS;Integrated Security=True"
        Dim query As String = "SELECT Product_ID, Product_Name FROM Product ORDER BY Product_Name"

        Using con As New SqlConnection(conStr)
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    Using adapter As New SqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        If dt.Rows.Count > 0 Then
                            ddlProduct.DataSource = dt
                            ddlProduct.DataTextField = "Product_Name"
                            ddlProduct.DataValueField = "Product_ID"
                            ddlProduct.DataBind()

                            ' Add a default prompt item
                            ddlProduct.Items.Insert(0, New ListItem("-- Select Product --", ""))
                        End If
                    End Using
                Catch ex As Exception
                    lblMessage.Text = "Error loading products: " & ex.Message
                    lblMessage.Visible = True
                End Try
            End Using
        End Using
    End Sub

    Protected Sub btnPlaceOrder_Click(sender As Object, e As EventArgs)
        If ddlProduct.SelectedIndex = 0 Then
            lblMessage.Text = "Please select a product."
            lblMessage.Visible = True
            Return
        End If

        If Not IsNumeric(txtQuantity.Text) OrElse CInt(txtQuantity.Text) <= 0 Then
            lblMessage.Text = "Please enter a valid quantity."
            lblMessage.Visible = True
            Return
        End If

        Dim productID As Integer = CInt(ddlProduct.SelectedValue)
        Dim quantity As Integer = CInt(txtQuantity.Text)

        ' Here you would normally insert the order into your database
        ' For this example, I'll just show verification that data was received

        Dim conStr As String = "Data Source=localhost;Initial Catalog=SSMS;Integrated Security=True"

        ' Check if the requested quantity is available in stock
        Dim checkStockQuery As String = "SELECT Stock_Quantity, Product_Name FROM Product WHERE Product_ID = @ProductID"

        Using con As New SqlConnection(conStr)
            Try
                con.Open()

                ' First check if we have enough inventory
                Dim availableStock As Integer = 0
                Dim productName As String = ""

                Using cmdCheck As New SqlCommand(checkStockQuery, con)
                    cmdCheck.Parameters.AddWithValue("@ProductID", productID)

                    Using reader As SqlDataReader = cmdCheck.ExecuteReader()
                        If reader.Read() Then
                            availableStock = CInt(reader("Stock_Quantity"))
                            productName = reader("Product_Name").ToString()
                        End If
                    End Using
                End Using

                If quantity > availableStock Then
                    lblMessage.Text = "Sorry, we only have " & availableStock & " units of " & productName & " in stock."
                    lblMessage.Visible = True
                    Return
                End If

                ' Process the order (in a real app, you would insert into Orders table)
                ' For now, just update the stock quantity
                Dim updateStockQuery As String = "UPDATE Product SET Stock_Quantity = Stock_Quantity - @Quantity WHERE Product_ID = @ProductID"

                Using cmdUpdate As New SqlCommand(updateStockQuery, con)
                    cmdUpdate.Parameters.AddWithValue("@ProductID", productID)
                    cmdUpdate.Parameters.AddWithValue("@Quantity", quantity)

                    Dim rowsAffected As Integer = cmdUpdate.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        lblMessage.Text = "Order placed successfully! Ordered " & quantity & " units of " & productName
                        lblMessage.ForeColor = System.Drawing.Color.Green
                        lblMessage.Visible = True

                        ' Reset the form
                        ddlProduct.SelectedIndex = 0
                        txtQuantity.Text = ""
                    Else
                        lblMessage.Text = "Error placing order. Please try again."
                        lblMessage.ForeColor = System.Drawing.Color.Red
                        lblMessage.Visible = True
                    End If
                End Using
            Catch ex As Exception
                lblMessage.Text = "Error: " & ex.Message
                lblMessage.ForeColor = System.Drawing.Color.Red
                lblMessage.Visible = True
            End Try
        End Using
    End Sub
End Class