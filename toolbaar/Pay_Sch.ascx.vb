
Partial Class toolbaar_Pay_Sch
    Inherits System.Web.UI.UserControl

    Protected Sub btnpayschsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpayschsearch.Click

        Try
            'If Val(txtpayschfrom.Text) = 0 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)

            '    Exit Sub
            'ElseIf Val(txtpayschto.Text) = 0 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid ending date!!!" & "');", True)

            '    Exit Sub
            'ElseIf CDate(txtpayschfrom.Text) > CDate(txtpayschto.Text) Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)

            '    Exit Sub
            'Else
            '    Session("payschfrom") = Session("from_pay")
            '    Session("payschto") = Session("to_pay")

            Response.Redirect("Pay_Schedule.aspx", False)

            'End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim from_new As DateTime
        'Dim to_new As DateTime
   
        If Page.IsPostBack = True Then
            txtpayschfrom.Text = ""
            txtpayschto.Text = ""
            '    'from_new = Date.Parse(txtpayschfrom.Text)
            '    'to_new = Date.Parse(txtpayschto.Text)
            '    'txtpayschfrom.Text = from_new.ToString("dd-MMM-yyyy")
            '    'txtpayschto.Text = to_new.ToString("dd-MMM-yyyy")
            Session("payschfrom") = txtpayschfrom.Text
            Session("payschto") = txtpayschto.Text
        Else
            '    from_new = System.DateTime.Now.Date
            '    to_new = System.DateTime.Now.Date
            '    txtpayschfrom.Text = from_new.ToString("dd-MMM-yyyy")
            '    txtpayschto.Text = to_new.ToString("dd-MMM-yyyy")
            Session("payschfrom") = txtpayschfrom.Text
            Session("payschto") = txtpayschto.Text
        End If

    End Sub

End Class
