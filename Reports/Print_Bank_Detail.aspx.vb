
Partial Class Customer_Print_Bank_Detail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            If Not Page.IsPostBack Then
                If Session("bank_flag") = 0 Then
                    txtAccountName_print.Text = Session("account_name")
                    txtAccountNumber_print.Text = Session("account_number")
                    txtBankAddress_print.Text = Session("bank_address")
                    txtBankName_print.Text = Session("bank_name")
                    txtBankPostCode_print.Text = Session("postcode")
                    txtBankState_print.Text = Session("state")
                    txtBankSuburb_print.Text = Session("suburb")
                    txtBSB_print.Text = Session("bsb")
                Else
                    txtAccountName_print.Text = Session("customer_namebank")
                End If
            End If
        End If
    End Sub
End Class
