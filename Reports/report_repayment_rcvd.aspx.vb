Imports System.Data

Partial Class Reports_report_repayment_rcvd
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
            btnPrint.Visible = False
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
                Dim ds As DataSet = obj.getRepaymentReceived(Date.Parse(txtFrmDate.Text), Date.Parse(txtToDate.Text), drpPymtMethod.SelectedItem.Text)
                Dim sb As New StringBuilder()
                Dim total As Decimal = 0
                If ds.Tables(0).Rows.Count > 0 Then
                    sb.Append("<table  width='99%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                    sb.Append("<tr >")
                    sb.Append("<th width='13%' class='center'>Customer No</th>")
                    sb.Append("<th width='25%' class='center'>Customer Name</th>")
                    sb.Append("<th width='10%' class='center'>Loan No </th>")
                    sb.Append("<th width='10%' class='center'>Method</th>")
                    sb.Append("<th width='15%' class='center'>Due Date</th>")
                    sb.Append("<th width='15%' class='center'>Payment Date</th>")
                    sb.Append("<th width='12%' class='center'>Amount</th>")
                    sb.Append("</tr>")
                    Dim dr As DataRow
                    For Each dr In ds.Tables(0).Rows
                        sb.Append("<tr >")
                        Dim custNo As String = Convert.ToString(dr("Customer_ID"))
                        Dim custName As String = Convert.ToString(dr("Given_Name")) & " " & Convert.ToString(dr("Last_Name"))
                        Dim LoanNo As String = Convert.ToString(dr("Loan_ID"))
                        Dim pmethod As String = Convert.ToString(dr("Payment_Method"))
                        Dim dudate As String = Convert.ToDateTime(dr("Due_Date"))
                        Dim paymentDate As String = Convert.ToDateTime(dr("Payment_Date"))
                        Dim amt As Decimal = Convert.ToDecimal(dr("Amount"))
                        total = total + amt
                        sb.Append("<td align='left'>" & custNo & "</td>")
                        sb.Append("<td align='left'>" & custName & "</td>")
                        sb.Append("<td align='left'>" & LoanNo & "</td>")
                        sb.Append("<td align='center'>" & pmethod & "</td>")
                        sb.Append("<td align='center'>" & dudate & "</td>")
                        sb.Append("<td align='center'>" & paymentDate & "</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, amt) & "</td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("<tr >")
                    'sb.Append("<th > &nbsp;</th>")
                    'sb.Append("<th > &nbsp;</th>")
                    'sb.Append("<th > &nbsp;</th>")
                    'sb.Append("<th > &nbsp;</th>")
                    'sb.Append("<th > &nbsp;</th>")
                    sb.Append("<th align='right' colspan='6' > <b>Total</b></th>")
                    sb.Append("<th align='right'>" & String.Format(sf, total) & "</th>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    Literal1.Text = sb.ToString()
                    btnPrint.Visible = True
                Else
                    Literal1.Text = ""
                    btnPrint.Visible = False
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & " There are no Re-Payments due for the given date range and the selected method of repayment " & "');", True)
                End If
            End Using



        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
        End Try
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            If CDate(txtFrmDate.Text) > CDate(txtToDate.Text) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid future date!!!" & "');", True)
                Exit Sub
            End If
            bindReport()
            pnlPrint.Visible = True
            btnPrint.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            bindReport()
            Session("ctrl") = pnlPrint
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>")
        Catch ex As Exception

        End Try
    End Sub
End Class
