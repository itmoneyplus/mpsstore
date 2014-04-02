Imports System.Data
Partial Class Reports_report_loan_decline
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
                Dim sb As New StringBuilder()
                Dim ds As DataSet = obj.GetLoanDeclineReport(Date.Parse(txtFrmDate.Text), Date.Parse(txtToDate.Text))
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim total As Decimal = 0
                    sb.Append("<table  width='100%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                    sb.Append("<tr >")
                    sb.Append("<th width='5%' class='center'>No</th>")
                    sb.Append("<th width='13%' class='center'>Customer ID</th>")
                    sb.Append("<th width='39%' class='center'>Customer Name </th>")
                    sb.Append("<th width='10%' class='center'>Loan No</th>")
                    sb.Append("<th width='15%' class='center'>Date</th>")
                    sb.Append("<th width='13%' class='center'>Amount</th>")
                    sb.Append("</tr>")
                    Dim dr As DataRow
                    For Each dr In ds.Tables(0).Rows
                        sb.Append("<tr >")
                        Dim id As Integer = ds.Tables(0).Rows.IndexOf(dr) + 1
                        Dim custNo As String = Convert.ToString(dr("Customer_ID"))
                        Dim custName As String = Convert.ToString(dr("Given_Name")) & " " & Convert.ToString(dr("Last_Name"))
                        Dim LoanID As String = Convert.ToString(dr("Loan_ID"))
                        Dim LoanDate As Date = Convert.ToDateTime(dr("Loan_Date"))
                        Dim amt As Decimal = Convert.ToDecimal(dr("Amount"))
                        total = total + amt
                        sb.Append("<td align='left'>" & id & "</td>")
                        sb.Append("<td align='left'>" & custNo & "</td>")
                        sb.Append("<td align='left'>" & custName & "</td>")
                        sb.Append("<td align='center'>" & LoanID & "</td>")
                        sb.Append("<td align='left'>" & String.Format(df, LoanDate) & "</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, amt) & "</td>")
                        sb.Append("</tr>")
                    Next

                    sb.Append("<tr>")
                    sb.Append("<th align='right'  colspan='5'> <b>Total</b></th>")
                    sb.Append("<th align='right'>" & String.Format(sf, total) & "</th>")
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

        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Session("ctrl") = pnlPrint
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>")
        Catch ex As Exception
            Throw ex
        End Try
        
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            bindReport()
            pnlPrint.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
