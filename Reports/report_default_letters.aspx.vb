Imports System.Data
Partial Class Reports_report_default_letters
    Inherits System.Web.UI.Page

   

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Me.IsPostBack = False Then
            Dim dt As String = String.Format(clsGeneral.GetDateFormat(), System.DateTime.Now)
            txtFrmDate.Text = dt
            txtToDate.Text = dt
            bindReport()
            pnlPrint.Visible = False
        End If
    End Sub
    Sub chkAdmin()
        If clsGeneral.ChkAdmin() = True Then
            Link_Administration.Visible = True
        Else
            Link_Administration.Text = "User"
            Link_Administration.PostBackUrl = "~/Customer/UpdatePassword.aspx"

        End If
    End Sub
    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            bindReport()
            Session("ctrl") = pnlPrint
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>")
        Catch ex As Exception

        End Try
    End Sub

   

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            bindReport()
            pnlPrint.Visible = True
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
        End Try
    End Sub

    Private Sub bindReport()
        Try
            Using obj As New clsReport()
                Dim ds As DataSet = obj.getDefaultLetterNotices(Date.Parse(txtFrmDate.Text), Date.Parse(txtToDate.Text), drp.SelectedItem.Text)
                Dim sf As String = clsGeneral.GetStringFormat()
                If drp.SelectedItem.Text = "Created Notices" Then
                    Dim total As Decimal = 0
                    lblHead1.Text = drp.SelectedItem.Text
                    lblHead.Text = " " & txtFrmDate.Text & "  to  " & txtToDate.Text
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim sb As New StringBuilder()
                        sb.Append("<table  width='100%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                        sb.Append("<tr >")
                        sb.Append("<th width='15%' class='center'>Customer ID</th>")
                        sb.Append("<th width='25%' class='center'>Customer Name</th>")
                        sb.Append("<th width='25%' class='center'>Description</th>")
                        sb.Append("<th width='16%' class='center'>Loan/LOC No</th>")
                        sb.Append("<th width='19%' class='center'>Notice Created On</th>")
                        sb.Append("</tr>")
                        Dim dr As DataRow
                        For Each dr In ds.Tables(0).Rows

                            Dim custNo As String = Convert.ToString(dr("Customer_ID"))
                            Dim custName As String = Convert.ToString(dr("Given_Name")) & " " & Convert.ToString(dr("Last_Name"))
                            Dim Description As String = Convert.ToString(dr("Description"))
                            Dim LoanID As String = Convert.ToString(dr("Loan_ID"))
                            Dim dudate As Date = Convert.ToDateTime(dr("Notice_Created_On"))
                            sb.Append("<tr >")
                            sb.Append("<td align='left'>" & custNo & "</td>")
                            sb.Append("<td align='left'>" & custName & "</td>")
                            sb.Append("<td align='left'>" & Description & "</td>")
                            sb.Append("<td align='center'>" & LoanID & "</td>")
                            sb.Append("<td align='center'>" & String.Format(sf, dudate) & "</td>")
                            sb.Append("</tr>")
                        Next
                        sb.Append("</table>")
                        Literal1.Text = sb.ToString()
                        btnPrint.Visible = True
                    Else
                        Literal1.Text = ""
                        btnPrint.Visible = False
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & " There are no notices created for the given date range and the selected method of repayment " & "');", True)

                    End If
                ElseIf drp.SelectedItem.Text = "Expired Notices" Then
                    lblHead1.Text = drp.SelectedItem.Text
                    lblHead.Text = " " & txtFrmDate.Text & "  to  " & txtToDate.Text
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim sb As New StringBuilder()
                        sb.Append("<table  width='100%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                        sb.Append("<tr >")
                        sb.Append("<th width='15%' class='center'>Customer ID</th>")
                        sb.Append("<th width='25%' class='center'>Customer Name</th>")
                        sb.Append("<th width='25%' class='center'>Description</th>")
                        sb.Append("<th width='16%' class='center'>Loan/LOC No</th>")
                        sb.Append("<th width='19%' class='center'>Notice Expired On</th>")
                        sb.Append("</tr>")
                        Dim dr As DataRow
                        For Each dr In ds.Tables(0).Rows
                            Dim custNo As String = Convert.ToString(dr("Customer_ID"))
                            Dim custName As String = Convert.ToString(dr("Given_Name")) & " " & Convert.ToString(dr("Last_Name"))
                            Dim Description As String = Convert.ToString(dr("Description"))
                            Dim LoanID As String = Convert.ToString(dr("Loan_ID"))
                            Dim dudate As Date = Convert.ToDateTime(dr("Notice_Expires_On"))
                            sb.Append("<tr >")
                            sb.Append("<td align='left'>" & custNo & "</td>")
                            sb.Append("<td align='left'>" & custName & "</td>")
                            sb.Append("<td align='left'>" & Description & "</td>")
                            sb.Append("<td align='center'>" & LoanID & "</td>")
                            sb.Append("<td align='center'>" & String.Format(clsGeneral.GetDateFormat(), dudate) & "</td>")
                            sb.Append("</tr>")
                        Next
                        sb.Append("</table>")
                        Literal1.Text = sb.ToString()
                        btnPrint.Visible = True
                    Else
                        Literal1.Text = ""
                        btnPrint.Visible = False
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & " There are no notices expired for the given date range and the selected method of repayment " & "');", True)
                    End If
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class
