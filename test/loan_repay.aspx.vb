
Partial Class test_loan_repay
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Try
                bindLoan()
            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

    Private Sub bindLoan()
        Try
            Dim LoanID As Integer = 1277 'clsGeneral.GetQueryString("id")


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
