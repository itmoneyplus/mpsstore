Imports System.Data

Partial Class Reports_report_directdebit_dishonoured
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

            '  bindReport()
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
    Sub bindReport()
        Try
            lblHead.Text = " " & txtFrmDate.Text & "  to  " & txtToDate.Text
            Using obj As New clsReport()
                Dim sf As String = clsGeneral.GetStringFormat()
                Dim df As String = clsGeneral.GetDateFormat()
                Dim ds As DataSet = obj.getDirectDebitDishonoured(Date.Parse(txtFrmDate.Text), Date.Parse(txtToDate.Text))
                Dim sb As New StringBuilder()
                Dim total As Decimal = 0
                Dim TotalFees As Decimal = 0
                If ds.Tables(0).Rows.Count > 0 Then
                    sb.Append("<table  width='100%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                    sb.Append("<tr >")
                    sb.Append("<th width='5%' class='center'>No</th>")
                    sb.Append("<th width='10%' class='center'>Customer ID</th>")
                    sb.Append("<th width='36%' class='center'>Customer Name </th>")
                    sb.Append("<th width='10%' class='center'>Loan No</th>")
                    sb.Append("<th width='15%' class='center'>Date</th>")
                    sb.Append("<th width='12%' class='center'>Payment</th>")
                    sb.Append("<th width='12%' class='center'>Dishonour Fee</th>")
                    sb.Append("</tr>")
                    Dim dr As DataRow
                    Dim id As Integer = 1
                    For Each dr In ds.Tables(0).Rows

                        '= ds.Tables(0).Rows.IndexOf(dr) + 1
                        Dim custNo As String = Convert.ToString(dr("Customer_ID"))
                        Dim custName As String = Convert.ToString(dr("Given_Name")) & " " & Convert.ToString(dr("Last_Name"))
                        Dim LoanID As String = Convert.ToString(dr("Loan_ID"))
                        Dim desc As String = Convert.ToString(dr("Description"))
                        Dim TransDesc As String = Convert.ToString(dr("Transaction_Status"))
                        Dim tdate As DateTime = Convert.ToDateTime(dr("Transaction_Date"))
                        Dim amt As Decimal = Convert.ToDecimal(dr("Amount"))
                        If amt > 0 Then
                            Dim dish As String = ""
                            Dim fees As String = ""
                            If desc = "" And TransDesc = "Dishonour" Then
                                total = total + amt
                                dish = String.Format(sf, amt)
                            ElseIf desc = "Dishonoured fee" And TransDesc = "" Then
                                TotalFees = TotalFees + amt
                                fees = String.Format(sf, amt)
                            End If
                            sb.Append("<tr >")
                            sb.Append("<td align='left'>" & id & "</td>")
                            sb.Append("<td align='left'>" & custNo & "</td>")
                            sb.Append("<td align='left'>" & custName & "</td>")
                            sb.Append("<td align='center'>" & LoanID & "</td>")
                            sb.Append("<td align='center'>" & String.Format(df, tdate) & "</td>")

                            sb.Append("<td align='right'>" & dish & "</td>")
                            sb.Append("<td align='right'>" & fees & "</td>")
                            sb.Append("</tr>")
                            id = id + 1
                        End If
                       
                    Next
                    sb.Append("<tr>")
                    sb.Append("<th align='right'  colspan='5'> <b>Total</b></th>")
                    sb.Append("<th align='right'>" & String.Format(sf, total) & "</th>")
                    sb.Append("<th align='right'  colspan='0'>" & String.Format(sf, TotalFees) & "</th>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    Literal1.Text = sb.ToString()
                    btnPrint.Visible = True
                Else
                    Literal1.Text = ""
                    btnPrint.Visible = False
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & " There are no dishonour for the given date range and the selected method of repayment " & "');", True)
                End If

            End Using
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            bindReport()
            pnlPrint.Visible = True
        Catch ex As Exception

        End Try
    End Sub

   
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Session("ctrl") = pnlPrint
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>")
        Catch ex As Exception

        End Try
    End Sub
End Class
