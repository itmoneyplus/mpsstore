
Partial Class email_loan_preapproval
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            bindCustomer()
        End If
    End Sub
    Private Sub bindCustomer()
        Try
            lblCustomer.Text = clsGeneral.GetQueryString("name")
        Catch ex As Exception

        End Try
    End Sub

End Class
