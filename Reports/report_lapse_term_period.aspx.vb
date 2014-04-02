Imports System.Data
Partial Class Reports_report_lapse_term_period
    Inherits System.Web.UI.Page
    Dim objClass As New Class1
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
            Using obj As New clsReport()
                lblHead.Text = " " & txtFrmDate.Text & "  to  " & txtToDate.Text
                Dim ds As DataSet = obj.getLoanTermLapseReport(Date.Parse(txtFrmDate.Text), Date.Parse(txtToDate.Text))
                Dim sort As String = ""
                If drpSort.SelectedItem.Text = "Date of Loan" Then
                    sort = "Loan_Date"
                ElseIf drpSort.SelectedItem.Text = "Customer ID" Then
                    sort = "Customer_ID"
                ElseIf drpSort.SelectedItem.Text = "Customer Name" Then
                    sort = "Given_Name, Last_Name"
                Else
                    sort = "Customer_ID"
                End If
                Dim sb As New StringBuilder()
                Dim sf As String = clsGeneral.GetStringFormat()
                sb.Append("<table  width='99%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                sb.Append("<tr >")
                sb.Append("<th width='7%' class='center'>No</th>")
                sb.Append("<th width='27%' class='center'>Customer Name</th>")
                sb.Append("<th width='8%' class='center'>Loan</th>")
                sb.Append("<th width='14%' class='center'>Loan Date</th>")
                sb.Append("<th width='5%' class='center'>Term</th>")
                sb.Append("<th width='10%' class='center'>Amount</th>")
                sb.Append("<th width='8%' class='center'>Outstanding</th>")
                sb.Append("<th width='13%' class='center'>Last Payment</th>")
                sb.Append("<th width='8%' class='center'>Days Overdue</th>")
                sb.Append("</tr>")
                Dim dv As DataView = ds.Tables(0).DefaultView()
                dv.Sort = sort
                Dim outStadAmtTotal As Decimal = 0
                If ds.Tables(0).Rows.Count > 0 Then


                    For Each rowView As DataRowView In dv
                        Dim dr As DataRow = rowView.Row
                        Dim outStadamt As Decimal = objClass.outstanding_amt(CInt(dr("Loan_ID")))
                        If (outStadamt > 0) Then
                            Dim custNo As String = Convert.ToString(dr("Customer_ID"))
                            Dim CustName As String = Convert.ToString(dr("Given_Name")) & " " & Convert.ToString(dr("Last_Name"))
                            Dim loanNo As String = Convert.ToString(dr("Loan_ID"))
                            Dim LoanDate As Date = Convert.ToDateTime(dr("Loan_Date"))
                            Dim term As String = Convert.ToString(dr("Tp"))
                            Dim loanAmt As Decimal = Convert.ToDecimal(dr("Amount"))
                            Dim LastPaymt As String = ""
                            Using objloan As New clsLoan()
                                LastPaymt = objloan.GetLastPayment(CInt(loanNo))
                            End Using
                            Dim dayOd As String = Convert.ToString(dr("dif"))
                            outStadAmtTotal = outStadAmtTotal + outStadamt
                            sb.Append("<tr >")
                            sb.Append("<td align='left'>" & custNo & "</td>")
                            sb.Append("<td align='left'>" & CustName & "</td>")
                            sb.Append("<td align='left'>" & loanNo & "</td>")
                            sb.Append("<td align='center'>" & String.Format(clsGeneral.GetDateFormat("/"), LoanDate) & "</td>")
                            sb.Append("<td align='center'>" & term & "</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, loanAmt) & "</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, outStadamt) & "</td>")
                            sb.Append("<td align='center'>" & LastPaymt & "</td>")
                            sb.Append("<td align='center'>" & dayOd & "</td>")
                            sb.Append("</tr>")
                        End If

                    Next
                    sb.Append("<tr >")

                    sb.Append("<th align='right'  colspan='6'> <b>Total</b></th>")
                    sb.Append("<th align='right'>" & String.Format(sf, outStadAmtTotal) & "</th>")
                    sb.Append("<th align='right'  colspan='2'> &nbsp;</th>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    Literal1.Text = sb.ToString()
                    btnPrint.Visible = True
                Else
                    Literal1.Text = ""
                    btnPrint.Visible = False

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
