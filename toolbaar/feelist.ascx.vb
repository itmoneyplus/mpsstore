
Partial Class toolbaar_feelist
    Inherits System.Web.UI.UserControl

   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If txtCreditRefReportFee.Text = "" Then

            txtCreditRefReportFee.Text = "10.00"
        Else
            txtCreditRefReportFee.Text = txtCreditRefReportFee.Text
        End If

        If txtGuaranteePreparation.Text = "" Then
            txtGuaranteePreparation.Text = "50.00"
        Else
            txtGuaranteePreparation.Text = txtGuaranteePreparation.Text
        End If

        If txtBillOfSalePreparation.Text = "" Then
            txtBillOfSalePreparation.Text = "50.00"
        Else
            txtBillOfSalePreparation.Text = txtBillOfSalePreparation.Text
        End If

        If txtREVsInquiry.Text = "" Then
            txtREVsInquiry.Text = "15.00"
        Else
            txtREVsInquiry.Text = txtREVsInquiry.Text
        End If

        If txtREVsRegistration.Text = "" Then
            txtREVsRegistration.Text = "15.00"
        Else
            txtREVsRegistration.Text = txtREVsRegistration.Text
        End If

        If txtStamping.Text = "" Then
            txtStamping.Text = "0.00"
        Else
            txtStamping.Text = txtStamping.Text
        End If

        If txtValuation.Text = "" Then
            txtValuation.Text = "0.00"
        Else
            txtValuation.Text = txtValuation.Text
        End If
        Dim total As String
        total = CInt(txtCreditRefReportFee.Text) + CInt(txtGuaranteePreparation.Text) + CInt(txtBillOfSalePreparation.Text) + CInt(txtREVsInquiry.Text) + CInt(txtREVsRegistration.Text) + CInt(txtStamping.Text) + CInt(txtValuation.Text) & ".00"

        txtTotal.Text = total


    End Sub
End Class
