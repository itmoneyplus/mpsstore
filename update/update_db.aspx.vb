
Partial Class update_update_db
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text <> "" Then
                Using obj As New clsDbUpdate()
                    obj.updateDB(TextBox1.Text)
                    lblMsg.Text = "Data Updated Sucessfully.."
                End Using

            End If
        Catch ex As Exception
            lblMsg.Text = ex.Message
        End Try
       
    End Sub
End Class
