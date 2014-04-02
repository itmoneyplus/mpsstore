Imports System.Data
Partial Class Reports_report_journal
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
                txtFrmDate.Text = dt
                txtToDate.Text = dt

                pnlPrint.Visible = False
                btnPrint.Visible = False
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
            lblHead.Text = " " & txtFrmDate.Text & "  to  " & txtToDate.Text
            Using obj As New clsReport()
                Dim ds As DataSet = obj.GetFinancialStatusReport(Date.Parse(txtFrmDate.Text), Date.Parse(txtToDate.Text))
                If ds.Tables(0).Rows.Count = 0 And ds.Tables(1).Rows.Count = 0 Then
                    Literal1.Text = ""
                    btnPrint.Visible = False
                    btnDownLoad.Visible = False
                Else
                    Dim sf As String = clsGeneral.GetStringFormat()
                    Dim sb As New StringBuilder()
                    Dim totalDr As Decimal = 0
                    Dim totalCr As Decimal = 0
                    sb.Append("<table  width='99%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                    sb.Append("<tr >")
                    sb.Append("<th width='15%' class='center'>No</th>")
                    sb.Append("<th width='40%' class='center'>Description</th>")
                    sb.Append("<th width='15%' class='center'>Account Code</th>")
                    sb.Append("<th width='15%' class='center'>Dr </th>")
                    sb.Append("<th width='15%' class='center'>Cr</th>")
                    sb.Append("</tr>")
                    Dim int_Dishonoured_fees As Decimal = 0
                    Dim int_Cancellation_fees As Decimal = 0
                    Dim int_Arear_notice_fees As Decimal = 0
                    Dim int_Default_notice_fees As Decimal = 0
                    Dim int_Letter_of_demand_fees As Decimal = 0
                    Dim int_Variation_fees As Decimal = 0
                    Dim int_Statement_of_account_fees As Decimal = 0

                    Dim dr As DataRow
                    For Each dr In ds.Tables(1).Rows
                        Dim desc As String = Convert.ToString(dr("Description"))
                        Dim amt As Decimal = Convert.ToDecimal(dr("Amount"))
                        If desc = "Dishonoured fee" Then
                            int_Dishonoured_fees = int_Dishonoured_fees + amt
                        ElseIf desc = "Cancellation fee" Then
                            int_Cancellation_fees = int_Cancellation_fees + amt
                        ElseIf desc = "Arear notice fee" Then
                            int_Arear_notice_fees = int_Arear_notice_fees + amt
                        ElseIf desc = "Default_notice_fee" Then
                            int_Default_notice_fees = int_Default_notice_fees + amt
                        ElseIf desc = "Letter of demand fee" Then
                            int_Letter_of_demand_fees = int_Letter_of_demand_fees + amt
                        ElseIf desc = "Variation fee" Then
                            int_Variation_fees = int_Variation_fees + amt
                        ElseIf desc = "Statement of account fee" Then
                            int_Statement_of_account_fees = int_Statement_of_account_fees + amt
                        End If

                    Next
                    Dim dr1 As DataRow = ds.Tables(0).Rows(0)
                    Dim int_LOC_Amount_Cash As Decimal = Convert.ToDecimal(dr1("int_LOC_Amount_Cash"))
                    Dim int_LOC_Amount_Credit As Decimal = Convert.ToDecimal(dr1("int_LOC_Amount_Credit"))
                    Dim int_LOC_Amount_Cheque As Decimal = Convert.ToDecimal(dr1("int_LOC_Amount_Cheque"))
                    Dim int_LOC_Fee As Decimal = Convert.ToDecimal(dr1("int_LOC_Fee"))
                    Dim int_Inter_DrawDown As Decimal = Convert.ToDecimal(dr1("int_Inter_DrawDown"))
                    Dim int_DrawDown As Decimal = Convert.ToDecimal(dr1("int_DrawDown"))
                    Dim int_CreditFee As Decimal = Convert.ToDecimal(dr1("int_CreditFee"))
                    Dim int_Loan_Amount_Cash As Decimal = Convert.ToDecimal(dr1("int_Loan_Amount_Cash"))
                    Dim int_Loan_Amount_Cheque As Decimal = Convert.ToDecimal(dr1("int_Loan_Amount_Cheque"))
                    Dim int_Loan_Amount_Credit As Decimal = Convert.ToDecimal(dr1("int_Loan_Amount_Credit"))
                    Dim int_Loan_Fee As Decimal = Convert.ToDecimal(dr1("int_Loan_Fee"))
                    Dim int_Cheque_Amount As Decimal = Convert.ToDecimal(dr1("int_Cheque_Amount"))
                    Dim int_Cheque_Fee As Decimal = Convert.ToDecimal(dr1("int_Cheque_Fee"))
                    Dim int_MoneyGram_Sent As Decimal = Convert.ToDecimal(dr1("int_MoneyGram_Sent"))
                    Dim int_MoneyGram_Sent_Fee As Decimal = Convert.ToDecimal(dr1("int_MoneyGram_Sent_Fee"))
                    Dim int_MoneyGram_Received As Decimal = Convert.ToDecimal(dr1("int_MoneyGram_Received"))
                    Dim int_Cash_RePayment As Decimal = Convert.ToDecimal(dr1("int_Cash_RePayment"))
                    Dim int_Payments_For_Check_Cashed_Earlier As Decimal = Convert.ToDecimal(dr1("int_Payments_For_Check_Cashed_Earlier"))
                    Dim int_Waived_fees As Decimal = Convert.ToDecimal(dr1("int_Waived_fees"))
                    Dim int_Brokerage_fees As Decimal = Convert.ToDecimal(dr1("int_Brokerage_fees"))
                    Dim int_Credit_fees As Decimal = Convert.ToDecimal(dr1("int_Credit_fees"))
                    Dim int_Total As Decimal = 0
                    Dim int_SNO As Integer = 0
                    Dim int_Loan_AND_Fee As Decimal = 0
                    If (int_LOC_Amount_Cash > 0 Or int_LOC_Amount_Cheque > 0 Or int_LOC_Amount_Credit > 0) And int_LOC_Fee > 0 Then
                        int_SNO = int_SNO + 1
                        int_Total = int_Total + int_LOC_Fee
                        Dim int_LOC_AND_Fee As Decimal = 0
                        If int_LOC_Amount_Cash > 0 Then
                            int_LOC_AND_Fee = int_LOC_AND_Fee + int_LOC_Amount_Cash
                        End If
                        If int_LOC_Amount_Credit > 0 Then
                            int_LOC_AND_Fee = int_LOC_AND_Fee + int_LOC_Amount_Credit
                        End If
                        If int_LOC_Amount_Cheque > 0 Then
                            int_LOC_AND_Fee = int_LOC_AND_Fee + int_LOC_Amount_Cheque
                        End If
                        sb.Append("<tr>")
                        sb.Append("<td align='left'>" & int_SNO & "</td>")
                        sb.Append("<td align='left'>LOC & Fee</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='center'>" & String.Format(sf, int_LOC_AND_Fee + int_LOC_Fee) & "</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("</tr>")

                        If int_LOC_Amount_Cash > 0 Then
                            int_Total = int_Total + int_LOC_Amount_Cash
                            sb.Append("<tr>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>LOC - Cash</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='center'>" & String.Format(sf, int_LOC_Amount_Cash) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_LOC_Amount_Cheque > 0 Then
                            int_Total = int_Total + int_LOC_Amount_Cheque
                            sb.Append("<tr>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>LOC - Cheque</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='center'>" & String.Format(sf, int_LOC_Amount_Cheque) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_LOC_Amount_Credit > 0 Then
                            int_Total = int_Total + int_LOC_Amount_Credit
                            sb.Append("<tr>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>LOC - D/Credit</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='center'>" & String.Format(sf, int_LOC_Amount_Credit) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_LOC_Fee > 0 Then
                            sb.Append("<tr>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>Fees</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='center'>" & String.Format(sf, int_LOC_Fee) & "</td>")
                            sb.Append("</tr>")
                        End If
                    End If
                    If int_DrawDown > 0 And int_CreditFee > 0 Then
                        int_SNO = int_SNO + 1
                        int_Total = int_Total + int_DrawDown + int_CreditFee
                        sb.Append("<tr>")
                        sb.Append("<td align='left'>" & int_SNO & "</td>")
                        sb.Append("<td align='left'>Drawdown & Fee</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='center'>" & String.Format(sf, int_DrawDown + int_CreditFee) & "</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("</tr>")

                        sb.Append("<tr>")
                        sb.Append("<td align='left'></td>")
                        sb.Append("<td align='left'>Drawdown</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='center'>" & String.Format(sf, int_DrawDown) & "</td>")
                        sb.Append("</tr>")

                        sb.Append("<tr>")
                        sb.Append("<td align='left'></td>")
                        sb.Append("<td align='left'>Fee</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='center'>" & String.Format(sf, int_CreditFee) & "</td>")
                        sb.Append("</tr>")
                    End If
                    If int_Inter_DrawDown > 0 Then
                        int_SNO = int_SNO + 1
                        int_Total = int_Total + int_Inter_DrawDown

                        sb.Append("<tr>")
                        sb.Append("<td align='left'>" & int_SNO & "</td>")
                        sb.Append("<td align='left'>Inter Branch Drawdown</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='center'>" & String.Format(sf, int_Inter_DrawDown) & "</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("</tr>")

                        sb.Append("<tr>")
                        sb.Append("<td align='left'></td>")
                        sb.Append("<td align='left'>Fee</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='center'>" & String.Format(sf, int_Inter_DrawDown) & "</td>")
                        sb.Append("</tr>")
                    End If

                    If (int_Loan_Amount_Cash > 0 Or int_Loan_Amount_Cheque > 0 Or int_Loan_Amount_Credit > 0) And int_Loan_Fee > 0 Then
                        int_SNO = int_SNO + 1
                        int_Total = int_Total + int_Loan_Fee
                        int_Loan_AND_Fee = 0

                        If int_Loan_Amount_Cash > 0 Then
                            int_Loan_AND_Fee = int_Loan_AND_Fee + int_Loan_Amount_Cash
                        End If
                        If int_Loan_Amount_Credit > 0 Then
                            int_Loan_AND_Fee = int_Loan_AND_Fee + int_Loan_Amount_Credit
                        End If
                        If int_Loan_Amount_Cheque > 0 Then
                            int_Loan_AND_Fee = int_Loan_AND_Fee + int_Loan_Amount_Cheque
                        End If

                        sb.Append("<tr>")
                        sb.Append("<td align='center'>" & int_SNO & "</td>")
                        sb.Append("<td align='left'>Loan & Fee</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_Loan_AND_Fee + int_Loan_Fee) & "</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("</tr>")
                        If int_Loan_Amount_Cash > 0 Then
                            int_Total = int_Total + int_Loan_Amount_Cash
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Loan - Cash</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Loan_Amount_Cash) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_Loan_Amount_Cheque > 0 Then
                            int_Total = int_Total + int_Loan_Amount_Cheque
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Loan - Cheque</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Loan_Amount_Cheque) & "</td>")
                            sb.Append("</tr>")
                        End If

                        If int_Loan_Amount_Credit > 0 Then
                            int_Total = int_Total + int_Loan_Amount_Credit
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Loan - D/Credit</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Loan_Amount_Credit) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_Loan_Fee > 0 Then
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Fees</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Loan_Fee) & "</td>")
                            sb.Append("</tr>")
                        End If
                        sb.Append("<tr><td align='center' colspan='5'>&nbsp;</td></tr>")
                    End If

                    If int_Payments_For_Check_Cashed_Earlier > 0 Then
                        int_SNO = int_SNO + 1
                        int_Total = int_Total + int_Payments_For_Check_Cashed_Earlier

                        sb.Append("<tr>")
                        sb.Append("<td align='center'>" & int_SNO & "</td>")
                        sb.Append("<td align='left'>Cash Payments - Cheque Cashed Earlier</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_Payments_For_Check_Cashed_Earlier) & "</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("</tr>")

                        sb.Append("<tr>")
                        sb.Append("<td align='left'></td>")
                        sb.Append("<td align='right'>Cash Payments  - Cheque Cashed Earlier</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_Payments_For_Check_Cashed_Earlier) & "</td>")
                        sb.Append("</tr>")
                        sb.Append("<tr><td align='center' colspan='5'>&nbsp;</td></tr>")
                    End If
                    If int_Cheque_Amount > 0 And int_Cheque_Fee > 0 Then
                        int_SNO = int_SNO + 1
                        int_Total = int_Total + int_Cheque_Amount + int_Cheque_Fee

                        sb.Append("<tr>")
                        sb.Append("<td align='center'>" & int_SNO & "</td>")
                        sb.Append("<td align='left'>Cheque Cashing - Cash out & Fee </td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_Cheque_Amount + int_Cheque_Fee) & "</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("</tr>")

                        sb.Append("<tr>")
                        sb.Append("<td align='left'></td>")
                        sb.Append("<td align='right'>Cheque Cashing - Cash out</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_Cheque_Amount) & "</td>")
                        sb.Append("</tr>")

                        sb.Append("<tr>")
                        sb.Append("<td align='left'></td>")
                        sb.Append("<td align='right'>Cheque Fee</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_Cheque_Fee) & "</td>")
                        sb.Append("</tr>")
                        sb.Append("<tr><td align='center' colspan='5'>&nbsp;</td></tr>")
                    End If

                    If int_MoneyGram_Sent > 0 Then
                        int_SNO = int_SNO + 1
                        int_Total = int_Total + int_MoneyGram_Sent + int_MoneyGram_Sent_Fee

                        sb.Append("<tr>")
                        sb.Append("<td align='center'>" & int_SNO & "</td>")
                        sb.Append("<td align='left'>Money Gram Sent Account &amp; Fee </td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_MoneyGram_Sent + int_MoneyGram_Sent_Fee) & "</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("</tr>")

                        sb.Append("<tr>")
                        sb.Append("<td align='left'></td>")
                        sb.Append("<td align='right'>Money Gram Sent Account</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_MoneyGram_Sent) & "</td>")
                        sb.Append("</tr>")

                        sb.Append("<tr>")
                        sb.Append("<td align='left'></td>")
                        sb.Append("<td align='right'>Money Gram Sent Account Fee</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_MoneyGram_Sent_Fee) & "</td>")
                        sb.Append("</tr>")
                        sb.Append("<tr><td align='center' colspan='5'>&nbsp;</td></tr>")
                    End If

                    If int_MoneyGram_Received > 0 Then
                        int_SNO = int_SNO + 1
                        int_Total = int_Total + int_MoneyGram_Received

                        sb.Append("<tr>")
                        sb.Append("<td align='center'>" & int_SNO & "</td>")
                        sb.Append("<td align='left'>Money Gram Received</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_MoneyGram_Received) & "</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("</tr>")

                        sb.Append("<tr>")
                        sb.Append("<td align='left'></td>")
                        sb.Append("<td align='right'>Money Gram Received Account</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_MoneyGram_Received) & "</td>")
                        sb.Append("</tr>")
                        sb.Append("<tr><td align='center' colspan='5'>&nbsp;</td></tr>")
                    End If
                    If int_Cash_RePayment > 0 Then
                        int_SNO = int_SNO + 1
                        int_Total = int_Total + int_Cash_RePayment

                        sb.Append("<tr>")
                        sb.Append("<td align='center'>" & int_SNO & "</td>")
                        sb.Append("<td align='left'>Cash Re-Payment</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_Cash_RePayment) & "</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("</tr>")

                        sb.Append("<tr>")
                        sb.Append("<td align='left'></td>")
                        sb.Append("<td align='right'>Cash Re-Payment Account</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_Cash_RePayment) & "</td>")
                        sb.Append("</tr>")
                        sb.Append("<tr><td align='center' colspan='5'>&nbsp;</td></tr>")
                    End If
                    If (int_Credit_fees + int_Brokerage_fees + int_Dishonoured_fees + int_Cancellation_fees + int_Arear_notice_fees + int_Default_notice_fees + int_Letter_of_demand_fees + int_Variation_fees + int_Statement_of_account_fees) > 0 Then
                        int_SNO = int_SNO + 1
                        sb.Append("<tr>")
                        sb.Append("<td align='center'>" & int_SNO & "</td>")
                        sb.Append("<td align='left'>Total Fee</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_Dishonoured_fees + int_Cancellation_fees + int_Arear_notice_fees + int_Default_notice_fees + int_Letter_of_demand_fees + int_Variation_fees + int_Statement_of_account_fees) & "</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("</tr>")
                        If int_Brokerage_fees > 0 Then
                            int_Total = int_Total + int_Brokerage_fees
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Application Fee</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Brokerage_fees) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_Credit_fees > 0 Then
                            int_Total = int_Total + int_Credit_fees
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Application Fee</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Credit_fees) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_Dishonoured_fees > 0 Then
                            int_Total = int_Total + int_Dishonoured_fees
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Dishonoured Fee</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Dishonoured_fees) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_Cancellation_fees > 0 Then
                            int_Total = int_Total + int_Cancellation_fees
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Cancellation fee</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Cancellation_fees) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_Arear_notice_fees > 0 Then
                            int_Total = int_Total + int_Arear_notice_fees
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Arrears notice Fee</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Arear_notice_fees) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_Default_notice_fees > 0 Then
                            int_Total = int_Total + int_Default_notice_fees
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Default notice Fee</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Default_notice_fees) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_Letter_of_demand_fees > 0 Then
                            int_Total = int_Total + int_Letter_of_demand_fees
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Letter of demand Fee</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Letter_of_demand_fees) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_Variation_fees > 0 Then
                            int_Total = int_Total + int_Variation_fees
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Variation Fee</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Variation_fees) & "</td>")
                            sb.Append("</tr>")
                        End If
                        If int_Statement_of_account_fees > 0 Then
                            int_Total = int_Total + int_Statement_of_account_fees
                            sb.Append("<tr>")
                            sb.Append("<td align='left'></td>")
                            sb.Append("<td align='right'>Statement of account Fee</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='left'>&nbsp;</td>")
                            sb.Append("<td align='right'>" & String.Format(sf, int_Statement_of_account_fees) & "</td>")
                            sb.Append("</tr>")
                        End If
                        sb.Append("<tr><td align='center' colspan='5'>&nbsp;</td></tr>")
                    End If
                    If int_Waived_fees > 0 Then
                        int_Total = int_Total + int_Waived_fees
                        sb.Append("<tr>")
                        sb.Append("<td align='left'></td>")
                        sb.Append("<td align='right'>Amount waived</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_Waived_fees) & "</td>")
                        sb.Append("</tr>")

                        sb.Append("<tr>")
                        sb.Append("<td align='center'></td>")
                        sb.Append("<td align='right'>Fee waived</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, int_Waived_fees) & "</td>")
                        sb.Append("<td align='left'>&nbsp;</td>")
                        sb.Append("</tr>")

                        sb.Append("<tr><td align='center' colspan='5'>&nbsp;</td></tr>")
                       
                    End If
                   
                    sb.Append("<tr >")
                    sb.Append("<th align='right' colspan='3'><b>Total</b></th>")
                    'sb.Append("<th align='right'></th>")
                    sb.Append("<th align='right'>" & String.Format(sf, int_Total) & "</th>")
                    sb.Append("<th align='right'>" & String.Format(sf, int_Total) & "</th>")
                    sb.Append("</tr >")
                    sb.Append("</table>")
                    Literal1.Text = sb.ToString()
                    btnPrint.Visible = True
                    btnDownLoad.Visible = True
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            bindReport()
            pnlPrint.Visible = True
            btnPrint.Visible = True
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

    Protected Sub btnDownLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownLoad.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment;filename=" & "Financialstatus_" & txtFrmDate.Text.ToString() & "_to_" & txtToDate.Text & ".xls")
            Response.Charset = ""
            Me.EnableViewState = False
            Dim sw As New System.IO.StringWriter()
            Dim htw As New System.Web.UI.HtmlTextWriter(sw)
            pnlPrint.RenderControl(htw)
            Response.Write(sw.ToString())
            Response.End()
        Catch ex As Exception

        End Try
        
    End Sub
End Class
