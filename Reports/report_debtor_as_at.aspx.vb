Imports System.Data
Partial Class Reports_report_debtor_as_at
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Me.IsPostBack = False Then
            Try
                Dim dt As String = String.Format(clsGeneral.GetDateFormat(), System.DateTime.Now)
                txtToDate.Text = dt
                '  bindReport()
                pnlPrint.Visible = False
            Catch ex As Exception

            End Try
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

    Sub bindReport()
        Try
            Using obj As New clsReport()
                lblHead.Text = " " & txtToDate.Text
                Dim ds As DataSet = obj.getDebtorsasATReport(Date.Parse(txtToDate.Text))
                Dim sf As String = clsGeneral.GetStringFormat()
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim sb As New StringBuilder()
                    Dim total As Decimal = 0
                    sb.Append("<table  width='100%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                    sb.Append("<tr >")
                    sb.Append("<th width='5%' class='center'>No</th>")
                    sb.Append("<th width='15%' class='center'>Customer ID</th>")
                    sb.Append("<th width='35%' class='center'>Customer Name </th>")
                    sb.Append("<th width='15%' class='center'>Loan/LOC No</th>")
                    sb.Append("<th width='25%' class='center'>Outstanding Amount</th>")
                    sb.Append("</tr>")
                    Dim dr As DataRow
                    Dim int_Amount_OutStanding As Decimal = 0
                    Dim id As Integer = 1
                    For Each dr In ds.Tables(0).Rows

                        int_Amount_OutStanding = Convert.ToDecimal(dr("LoanLOC_Amounts"))
                        Dim custNo As String = Convert.ToString(dr("Customer_ID"))
                        Dim custName As String = Convert.ToString(dr("Given_Name")) & " " & Convert.ToString(dr("Last_Name"))
                        Dim LoanID As String = Convert.ToString(dr("Loan_ID"))
                        If ds.Tables(1).Rows.Count > 0 Then
                            Dim drlf As DataRow
                            For Each drlf In ds.Tables(1).Rows
                                If LoanID = drlf("Loan_ID") Then
                                    int_Amount_OutStanding = int_Amount_OutStanding + Convert.ToDecimal(drlf("LoanLOC_Fees"))
                                End If
                            Next
                        End If

                        If ds.Tables(2).Rows.Count > 0 Then
                            Dim drldef As DataRow
                            For Each drldef In ds.Tables(2).Rows
                                If LoanID = drldef("Loan_ID") Then
                                    int_Amount_OutStanding = int_Amount_OutStanding + Convert.ToDecimal(drldef("DDEF"))
                                End If
                            Next
                        End If

                        If ds.Tables(3).Rows.Count > 0 Then
                            Dim drpw As DataRow
                            For Each drpw In ds.Tables(3).Rows
                                If LoanID = drpw("Loan_ID") Then
                                    int_Amount_OutStanding = int_Amount_OutStanding - Convert.ToDecimal(drpw("PaymentWaived"))
                                End If
                            Next
                        End If
                        If int_Amount_OutStanding > 0 Then
                            sb.Append("<tr  onclick=""javascript:fn_View_Record1('" & custNo & "','" & Convert.ToString(dr("Given_Name")) & "','" & Convert.ToString(dr("Last_Name")) & "');"">")
                            sb.Append("<td align='center'>" & id & "</td>")
                            sb.Append("<td align='left'>" & custNo & "</td>")
                            sb.Append("<td align='left'>" & custName & "</td>")
                            sb.Append("<td align='center'>" & LoanID & "</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Amount_OutStanding) & "</td>")
                            sb.Append("</tr >")
                            total = total + int_Amount_OutStanding
                            id = id + 1
                        End If

                        'Dim id As Integer = ds.Tables(0).Rows.IndexOf(dr) + 1
                        'Dim custNo As String = Convert.ToString(dr("Customer_ID"))
                        'Dim custName As String = Convert.ToString(dr("Given_Name")) & " " & Convert.ToString(dr("Last_Name"))
                        'Dim LoanID As String = Convert.ToString(dr("Loan_ID"))
                        'Dim amt As Decimal = Convert.ToDecimal(dr("LoanLOC_Amounts"))
                        'Dim LoanFee As Decimal = Convert.ToDecimal(dr("LoanFees"))
                        'Dim DDEF As Decimal = Convert.ToDecimal(dr("DDEF"))
                        'Dim PaymentWaived As Decimal = Convert.ToDecimal(dr("PaymentWaived"))

                        'Dim osamt As Decimal = (amt + LoanFee + DDEF) - (PaymentWaived)
                        'total = total + osamt

                        'sb.Append("<tr  onclick=""javascript:fn_View_Record1('" & custNo & "','" & Convert.ToString(dr("Given_Name")) & "','" & Convert.ToString(dr("Last_Name")) & "');"">")
                        'sb.Append("<td align='center'>" & id & "</td>")
                        'sb.Append("<td align='left'>" & custNo & "</td>")
                        'sb.Append("<td align='left'>" & custName & "</td>")
                        'sb.Append("<td align='center'>" & LoanID & "</td>")
                        'sb.Append("<td align='right'>" & String.Format(sf, osamt) & "</td>")
                        'sb.Append("</tr >")
                    Next
                sb.Append("</tr>")
                sb.Append("<th align='right'  colspan='4'> <b>Total</b></th>")
                sb.Append("<th align='right'>" & String.Format(clsGeneral.GetStringFormat(), total) & "</th>")
                sb.Append("</tr>")
                sb.Append("</table>")
                Literal1.Text = sb.ToString()
                btnPrint.Visible = True
                Else

                Literal1.Text = ""
                btnPrint.Visible = False
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & " There are no debtors for the given date range " & "');", True)
                End If
            End Using
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
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

        End Try
    End Sub
End Class
