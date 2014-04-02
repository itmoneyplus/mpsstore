Imports System.Data
Partial Class Customer_Loan_Aprroved_Email
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            bindEmail()
        End If
    End Sub

    Private Sub bindEmail()
        Try
            Dim lid As String = clsGeneral.GetQueryString("lid")
            Dim url As String = Context.Request.Url.ToString()
            url = url.Replace("Customer/Loan_Aprroved_Email.aspx", "email/loan_approved.aspx")
            ifrmEmail.Attributes.Add("src", url)
            dvEmail.Text = clsGeneral.ScreenScrapeHtml(url)
            Using obj As New clsLoan()
                Dim ds As DataSet = obj.GetLoadDetailsByID(Integer.Parse(lid))
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblEmail.Text = Convert.ToString(ds.Tables(0).Rows(0).Item("Email"))
                    'Convert.ToString(ds.Tables(0).Rows(0).Item("Given_Name")) & "  " & "(" &
                    hdCustID.Value = ds.Tables(0).Rows(0).Item("Customer_ID")
                End If
            End Using

        Catch ex As Exception

        End Try
    End Sub

   
    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            Dim LoanId As Integer = Integer.Parse(clsGeneral.GetQueryString("lid"))
            Dim path As String = ""
            If flAttachment.HasFile Then
                Dim file As HttpPostedFile = flAttachment.PostedFile

                Dim size As Integer = file.ContentLength
                If size > 3500000 Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "File size is big!! please reduced the file size" & "');", True)
                    Exit Sub
                End If
                Dim strFileName As String = flAttachment.FileName
                path = Server.MapPath("~/email/Docs/") & strFileName
                flAttachment.SaveAs(path)
            End If
            clsGeneral.SendMail(lblEmail.Text, "Approved!!!", dvEmail.Text, path)

            Using objLoan As New clsLoan()
                objLoan.UpdateLoanEmail(LoanId, Integer.Parse(hdCustID.Value), 1)
            End Using
            Using obj As New clsCustomer()
                obj.AddCustomerEmail(hdCustID.Value, "Loan Approved Email - Loan ID:" & LoanId, dvEmail.Text, LoanId)
            End Using
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Email has been successfully sent!!!" & "');", True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
