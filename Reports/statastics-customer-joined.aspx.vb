Imports System.Data
Partial Class Reports_statastics_customer_joined
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Me.IsPostBack = False Then
            Dim dt As String = String.Format(clsGeneral.GetDateFormat(), System.DateTime.Now)
            txtfrom_loanstatus.Text = dt
            txtto_loanstatus.Text = dt
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
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        pnlPrint.Visible = True
        Try
            Using obj As New clsReport()
                lblHead.Text = txtfrom_loanstatus.Text & " to " & txtto_loanstatus.Text
                Dim sb As New StringBuilder()
                Dim sf As String = clsGeneral.GetStringFormat()
                Dim sd As String = clsGeneral.GetDateFormat()
                Dim ds As DataSet = obj.GetCustomerJoinedOnReport(Date.Parse(txtfrom_loanstatus.Text), Date.Parse(txtto_loanstatus.Text))
                'If ds.Tables(0).Rows.Count > 0 Then
                '    sb.Append("<table  width='70%' cellpadding='0' cellspacing='0' align='centre' class='tblreport'>")
                '    sb.Append("<tr >")
                '    sb.Append("<th width='25%' class='center'>Total Customer</th>")
                '    sb.Append("<th width='25%' class='center'>Total Loans</th>")
                '    sb.Append("<th width='25%' class='center'>Total Amount</th>")
                '    sb.Append("<th width='25%' class='center'>Total Fees</th>")
                '    sb.Append("</tr>")

                '    Dim TotalCustomer As Integer = ds.Tables(0).Rows(0).Item("TotalCustomer")
                '    Dim TotalLoans As Integer = ds.Tables(1).Rows(0).Item("Total_Loans")
                '    Dim TotalLoanAmount As Decimal = Convert.ToDecimal(ds.Tables(2).Rows(0).Item("Total_LoanAmount"))
                '    Dim TotalLoanFees As Decimal = Convert.ToDecimal(ds.Tables(3).Rows(0).Item("Total_Fees"))
                '    sb.Append("<tr>")
                '    sb.Append("<td align='center'>" & TotalCustomer & "</td>")
                '    sb.Append("<td align='center'>" & TotalLoans & "</td>")
                '    sb.Append("<td align='center'>" & String.Format(sf, TotalLoanAmount) & "</td>")
                '    sb.Append("<td align='center'>" & String.Format(sf, TotalLoanFees) & "</td>")
                '    sb.Append("</tr>")
                '    sb.Append("</table>")

                '    Literal1.Text = sb.ToString()
                '    btnPrint.Visible = True
                'Else
                '    Literal1.Text = ""
                '    btnPrint.Visible = True
                'End If
                Dim sb1 As New StringBuilder()
                If ds.Tables(0).Rows.Count > 0 Then
                    sb1.Append("<table  width='99%' cellpadding='0' cellspacing='0' align='centre' class='tblreport'>")
                    sb1.Append("<tr >")
                    sb1.Append("<th width='5%' class='center'>No</th>")
                    sb1.Append("<th width='8%' class='center'>Customer_ID</th>")
                    sb1.Append("<th width='25%' class='center'>Customer</th>")
                    'sb1.Append("<th width='8%' class='center'>State</th>")
                    'sb1.Append("<th width='8%' class='center'>Loan ID</th>")
                    sb1.Append("<th width='15%' class='center'>Amount</th>")
                    sb1.Append("<th width='15%' class='center'>Date Joined</th>")
                    'sb1.Append("<th width='8%' class='center'>Term</th>")
                    'sb1.Append("<th width='17%' class='center'>Marketing Phrase</th>")
                    sb1.Append("</tr>")

                    Dim dr As DataRow
                    Dim custCount As Integer = 0
                    Dim id As Integer = 1
                    Dim total As Decimal = 0
                    For Each dr In ds.Tables(0).Rows
                        sb1.Append("<tr >")
                        Dim cust_id As String = Convert.ToString(dr("Customer_ID"))
                        Dim cust_name As String = Convert.ToString(dr("Name"))
                        'Dim State As String = Convert.ToString(dr("State"))
                        'Dim Loan_ID As String = Convert.ToString(dr("Loan_ID"))
                        Dim amt As Decimal = Convert.ToDecimal(dr("Request_Amount"))
                        Dim dateJoined As String = Convert.ToDateTime(dr("Date_Joined"))
                        'Dim Term As String = Convert.ToString(dr("Term"))
                        'Dim Marketing As String = Convert.ToString(dr("Marketing_Text"))
                        total = total + amt
                        sb1.Append("<td align='center'>" & id & "</td>")
                        sb1.Append("<td align='left'>" & cust_id & "</td>")
                        sb1.Append("<td align='left'>" & cust_name & "</td>")
                        'sb1.Append("<td align='center'>" & State & "</td>")
                        'sb1.Append("<td align='left'>" & Loan_ID & "</td>")
                        sb1.Append("<td align='right'>" & String.Format(sf, amt) & "</td>")
                        sb1.Append("<td align='center'>" & String.Format(sd, dateJoined) & "</td>")
                        'sb1.Append("<td align='center'>" & Term & "</td>")
                        'sb1.Append("<td align='left'>" & Marketing & "</td>")

                        sb1.Append("</tr>")
                        id = id + 1
                        custCount = custCount + 1
                    Next


                    sb1.Append("<tr>")
                    sb1.Append("<td colspan='4' style='border: 1px solid #C0C0C0;text-align:right'><b>Number of customers found for the above period: &nbsp;</b></td>")
                    sb1.Append("<td style='border: 1px solid #C0C0C0;text-align:right'><b>" & custCount & "</b></td>")
                    sb1.Append("</tr>")



                    'sb.Append("<tr >")

                    'sb1.Append("<th align='right' colspan='4' > <b>Total</b></th>")
                    'sb1.Append("<th align='right'>" & String.Format(sf, total) & "</th>")
                    'sb1.Append("<th > &nbsp;</th>")
                    'sb1.Append("<th > &nbsp;</th>")
                    'sb1.Append("<th > &nbsp;</th>")
                    'sb1.Append("</tr>")
                    sb1.Append("</table>")
                    Literal2.Text = sb1.ToString()
                    btnPrint.Visible = True
                    'Button1.Visible = True
                Else
                    Literal2.Text = ""
                    btnPrint.Visible = False
                    'Button1.Visible = False
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Session("ctrl") = pnlPrint
        ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>")
    End Sub
End Class
