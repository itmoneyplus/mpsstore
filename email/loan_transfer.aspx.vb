Imports System.Data
Partial Class email_loan_transfer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            bindEmail()
        End If
    End Sub
    Private Sub bindEmail()
        Try
            Using obj As New clsLoan()
                Dim ds As DataSet = obj.GetLoadDetailsByID(clsGeneral.GetQueryString("lid"))
                If ds.Tables(0).Rows.Count > 0 Then
                    '    lblAmount.Text = String.Format(clsGeneral.GetStringFormat(), ds.Tables(0).Rows(0).Item("Amount"))
                    lblCustomer.Text = Convert.ToString(ds.Tables(0).Rows(0).Item("Given_Name"))
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
