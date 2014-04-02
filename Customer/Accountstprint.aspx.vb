Imports System.Data.SqlClient
Imports System.Data

Partial Class Customer_Accountstprint
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Dim txtstartdt, txtenddt As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else

            Try

                Dim str_ACLN As String
                str_ACLN = "Australian Credit Licence Number 391104"
                txtstartdt = Session("startdt")
                txtenddt = Session("enddt")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim str_SQL, str_SQL1, str_SQL2, str_SQL3, str_SQL4 As String

                str_SQL = " SELECT  Tbl_Payment.Loan_ID, Tbl_Payment.Payment_ID, Tbl_Payment.Payment_Status as description, Tbl_Payment.Amount, Tbl_Payment.Payment_Date, Tbl_Payment.Payment_Method, Tbl_Payment.Fee_Status "
                str_SQL = str_SQL & " FROM Tbl_Payment WHERE   Tbl_Payment.Amount > 0 AND  Tbl_Payment.Payment_Status = 'Paid' AND Tbl_Payment.Loan_ID=" & Session("accst_id")

                str_SQL = str_SQL & " UNION SELECT ALL Tbl_Payment.Loan_ID, Tbl_Payment.Payment_ID, Tbl_Payment.Transaction_Status, Tbl_Payment.Amount, Tbl_Payment.Transaction_Date, Tbl_Payment.Payment_Method, Tbl_Payment.Fee_Status "
                str_SQL = str_SQL & " FROM Tbl_Payment WHERE Tbl_Payment.Amount > 0 AND Tbl_Payment.Transaction_Status ='Waived' AND Tbl_Payment.Loan_ID= " & Session("accst_id")

                str_SQL = str_SQL & " UNION SELECT ALL Tbl_Payment.Loan_ID, Tbl_Payment.Payment_ID, Tbl_Payment.transaction_status, Tbl_Payment.Amount, Tbl_Payment.Transaction_Date, Tbl_Payment.Payment_Method, Tbl_Payment.Fee_Status "
                str_SQL = str_SQL & " FROM Tbl_Payment WHERE Tbl_Payment.Amount > 0 AND Tbl_Payment.transaction_status = 'Dishonour' AND Tbl_Payment.Loan_ID= " & Session("accst_id")

                str_SQL = str_SQL & " UNION SELECT  Tbl_Payment.Loan_ID, Tbl_Payment.Payment_ID, Tbl_Payment.Description, Tbl_Payment.Amount, Tbl_Payment.Date_Updated, Tbl_Payment.Payment_Method, Tbl_Payment.Fee_Status "
                str_SQL = str_SQL & " FROM Tbl_Payment WHERE Tbl_Payment.Amount > 0 AND Tbl_Payment.Fee_Status in ('Credit fee', 'Draw down', 'dishonoured fee', 'Cancellation fee', 'Variation fee', 'Letter of demand fee', 'Default notice fee', 'Arear notice fee', 'Statement of account fee', 'Enforcement fee') AND Tbl_Payment.Loan_ID=" & Session("accst_id")
                str_SQL = str_SQL & " ORDER BY Tbl_Payment.Payment_Date, Tbl_Payment.Payment_ID, Tbl_Payment.Amount "

                Dim ds_Account, ds_CustomerAddress, ds_Branch_Detail, ds_loan, ds_Loan_Fees As New DataSet
                Dim adap_Account, adap_CustomerAddress, adap_Branch_Detail, adap_loan, adap_Loan_Fees As SqlDataAdapter
                Dim cmd_actst, cmd_CustomerAddress, cmd_Branch_Detail, cmd_loan, cmd_Loan_Fees As New SqlCommand

                cmd_actst.CommandText = str_SQL
                cmd_actst.Connection = open_con.return_con
                adap_Account = New SqlDataAdapter(cmd_actst)
                adap_Account.Fill(ds_Account)

                str_SQL1 = " SELECT * FROM Tbl_Customer WHERE Customer_ID = " & open_con.customer_id_val

                cmd_CustomerAddress.CommandText = str_SQL1
                cmd_CustomerAddress.Connection = open_con.return_con
                adap_CustomerAddress = New SqlDataAdapter(cmd_CustomerAddress)
                adap_CustomerAddress.Fill(ds_CustomerAddress)

                str_SQL2 = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val
                cmd_Branch_Detail.CommandText = str_SQL2
                cmd_Branch_Detail.Connection = open_con.return_con
                adap_Branch_Detail = New SqlDataAdapter(cmd_Branch_Detail)
                adap_Branch_Detail.Fill(ds_Branch_Detail)

                str_SQL3 = "SELECT * FROM tbl_loan WHERE loan_id= " & Session("accst_id")
                cmd_loan.CommandText = str_SQL3
                cmd_loan.Connection = open_con.return_con
                adap_loan = New SqlDataAdapter(cmd_loan)
                adap_loan.Fill(ds_loan)
                Session("ln_amt") = ds_loan.Tables(0).Rows(0).Item("Amount").ToString

                str_SQL4 = "Select * FROM Tbl_Loan_Fee WHERE Loan_ID = " & Session("accst_id")
                cmd_Loan_Fees.CommandText = str_SQL4
                cmd_Loan_Fees.Connection = open_con.return_con
                adap_Loan_Fees = New SqlDataAdapter(cmd_Loan_Fees)
                adap_Loan_Fees.Fill(ds_Loan_Fees)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ''''''''''for outer table
                Response.Write("<table style='border-collapse: collapse; margin-left:.2in; width:610;height:312' cellpadding='0' cellspacing='0'>")
                Response.Write("<tr>")
                Response.Write("<td valign='top' style='width: 610; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in;height:312'>")
                Response.Write("<p class='MsoNormal' style='text-align: center'><b>")
                Response.Write("<span lang='EN-AU' style='font-size: 14.0pt; color: black; text-decoration:underline'>")
                Response.Write("Statement of Loan ")
                Response.Write("</span></b></p>")
                Response.Write("<p class='MsoNormal'>")
                Response.Write("&nbsp;")
                Response.Write("</p>")


                Response.Write("<p class='MsoNormal' style='text-align:Right'>")
                Response.Write(str_ACLN)
                Response.Write("</p>")
                Response.Write("<p class='MsoNormal' style='text-align:Right'>")
                Response.Write("Abaz Pty Ltd A.C.N 118 434 021")
                Response.Write("</p>")
                Response.Write("<p class='MsoNormal' style='text-align:Right'>")
                Response.Write("c/-" & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Trading_Name").ToString)
                Response.Write("</p>")
                Response.Write("<p class='MsoNormal' style='text-align:Right'>")
                Response.Write(ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_Branch_Detail.Tables(0).Rows(0).Item("Suburb").ToString & ", " & ds_Branch_Detail.Tables(0).Rows(0).Item("State").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Post_Code").ToString)
                Response.Write("</p>")
                Response.Write("<p class='MsoNormal' style='text-align:Right'>")
                Response.Write("Tel: " & ds_Branch_Detail.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_Branch_Detail.Tables(0).Rows(0).Item("Fax_Number").ToString)
                Response.Write("</p>")
                Response.Write("<p class='MsoNormal'><b>&nbsp;Date:</b>&nbsp;")

                Dim day_loan_new, month_loan_new, year_loan, sup_string_new As String
                day_loan_new = Val(Left(System.DateTime.Now.Date, 2))
                sup_string_new = open_con.check_day(System.DateTime.Now.Day)
                month_loan_new = open_con.check_month(System.DateTime.Now.Month)
                year_loan = System.DateTime.Now.Year
                Response.Write(day_loan_new & sup_string_new & " " & month_loan_new & " " & year_loan)
                Response.Write("</p>")

                Response.Write("<p class='MsoNormal'>")
                Response.Write("&nbsp;")
                Response.Write("&nbsp;")
                Response.Write("</p>")

                Response.Write("<p class='MsoNormal'>")
                Response.Write(ds_CustomerAddress.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("Last_Name").ToString)
                Response.Write("</p>")

                Response.Write("<p class='MsoNormal'>")
                Dim Unit_No As String

                Unit_No = ds_CustomerAddress.Tables(0).Rows(0).Item("Unit_No").ToString()
                If Len(Unit_No) <> 0 Then
                    Response.Write(ds_CustomerAddress.Tables(0).Rows(0).Item("Unit_No").ToString() & "/" & ds_CustomerAddress.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("Street_Name").ToString)
                    Response.Write("</p>")
                Else
                    Response.Write(ds_CustomerAddress.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("Street_Name").ToString)
                    Response.Write("</p>")
                End If


                Response.Write("<p class='MsoNormal'>")
                Response.Write(ds_CustomerAddress.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("State").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("Post_Code").ToString)
                Response.Write("</p>")

                Response.Write("<p class='MsoNormal' style='text-align:Right'><b>From</b>&nbsp;")

                Dim txtstartdt_new As String
                Dim month_new, year_new, day_new As String
                txtstartdt_new = CDate(txtstartdt).ToString("dd/MMM/yyyy")
                day_new = Left(txtstartdt_new, 2)
                Dim pos_int_Total1 As Integer
                pos_int_Total1 = InStr(1, txtstartdt_new, "/")

                month_new = Mid(txtstartdt_new, pos_int_Total1 + 1, 3)
                year_new = Val(Right(txtstartdt_new, 4))
                txtstartdt_new = day_new & "-" & month_new & "-" & year_new
                Response.Write(txtstartdt_new & "&nbsp;")
                Response.Write("<b>To</b>&nbsp;")

                Dim txtenddt_new As String
                Dim month_end_new, year_end_new, day_end_new As String
                txtenddt_new = CDate(txtenddt).ToString("dd/MMM/yyyy")
                day_end_new = Left(txtenddt_new, 2)
                pos_int_Total1 = InStr(1, txtenddt_new, "/")
                month_end_new = Mid(txtenddt_new, pos_int_Total1 + 1, 3)
                year_end_new = Val(Right(txtenddt_new, 4))
                txtenddt_new = day_end_new & "-" & month_end_new & "-" & year_end_new
                Response.Write(txtenddt_new & "&nbsp;")
                Response.Write("</p>")

                Response.Write("<p class='MsoNormal' style='text-align:Right'><b>Customer No:</b>")
                Response.Write(open_con.customer_id_val & "&nbsp;")
                Response.Write("<b>Loan No:</b>")
                Response.Write(Session("accst_id"))
                Response.Write("</p>")
                Response.Write("<p class='MsoNormal'>")
                Response.Write("<br/>")
                Response.Write("<br/>")
                Response.Write("</p>")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Response.Write("<div align=center>")
                Response.Write("<table border='1' width='610'  style='border-collapse: collapse' bordercolor='#C0C0C0' cellpadding='0' cellspacing='0' height='38' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0' >")
                Response.Write("<tr>")
                Response.Write("<td bgcolor='#EFEFEF' style='text-align:center;width:100;height:30;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Date</td>")
                Response.Write("<td bgcolor='#EFEFEF' style='text-align:center;width:234;height:30;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Transaction details</td>")
                Response.Write("<td  style='text-align:center;width:83;height:30;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Debit</td>")
                Response.Write("<td style='text-align:center;width:83;height:30;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Credit</td>")
                Response.Write("<td style='text-align:center;width:110;height:30;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Balance</td>")
                Response.Write("</tr>")

                Dim str_Description As String
                Dim dtm_Transaction_Date As String
                Dim int_Amount As Double
                Dim int_Amount_new As String
                Dim int_Balance As Double
                Dim int_Balance_new As String
                Dim int_Loan_Amount As Single
                Dim bln_Opening_Balance_Displayed As Boolean

                int_Loan_Amount = Session("ln_amt")
                int_Balance = int_Loan_Amount
                bln_Opening_Balance_Displayed = False
                str_Description = "Loan Amount"
                int_Amount = open_con.check_amount_format(Math.Round(CDbl(int_Loan_Amount), 2))
                int_Amount_new = open_con.new_amount(int_Amount)

                int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Loan_Amount), 2))
                int_Balance_new = open_con.new_amount(int_Balance)
                dtm_Transaction_Date = Session("loan_date")
                Dim transdate As String
                transdate = dtm_Transaction_Date
                Dim month_trans, year_trans, day_trans As String
                transdate = CDate(transdate).ToString("dd/MMM/yyyy")
                day_trans = Left(transdate, 2)
                pos_int_Total1 = InStr(1, transdate, "/")


                month_trans = Mid(transdate, pos_int_Total1 + 1, 3)
                year_trans = Val(Right(transdate, 4))
                txtstartdt_new = day_trans & "-" & month_trans & "-" & year_trans
                dtm_Transaction_Date = txtstartdt_new

                If Session("loan_date") >= txtstartdt And Session("loan_date") <= txtenddt Then
                    Response.Write("<tr>")
                    Response.Write("<td style='width:100;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(dtm_Transaction_Date & "&nbsp;&nbsp;")
                    Response.Write("</td>")
                    Response.Write("<td style='width:234;height:16' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("Opening balance")
                    Response.Write("</td>")
                    Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("&nbsp;")
                    Response.Write("</td>")
                    Response.Write("<td  style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("&nbsp;")
                    Response.Write("</td>")
                    Response.Write("<td style='width:110;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("$00.00" & "&nbsp;" & "&nbsp;" & "&nbsp;" & "&nbsp;")
                    Response.Write("</td>")
                    Response.Write("</tr>")
                    Response.Write("<tr>")
                    Response.Write("<td style='width:100;height:16;text-align:right'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(dtm_Transaction_Date & "&nbsp;&nbsp;")
                    Response.Write("</td>")
                    Response.Write("<td style='width:234;height:16' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(str_Description)
                    Response.Write("</td>")
                    Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(int_Amount_new)
                    Response.Write("</td>")
                    Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("&nbsp;")
                    Response.Write("</td>")
                    Response.Write("<td style='width:110;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(int_Balance_new & "Dr")
                    Response.Write("</td>")
                    Response.Write("</tr>")



                    bln_Opening_Balance_Displayed = True

                End If
                If Not ds_Loan_Fees.Tables(0).Rows.Count = 0 Then

                    For i As Integer = 0 To ds_Loan_Fees.Tables(0).Rows.Count - 1

                        If Session("loan_date") >= txtstartdt And Session("loan_date") <= txtenddt Then
                            str_Description = ds_Loan_Fees.Tables(0).Rows(i).Item("Description").ToString
                            int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds_Loan_Fees.Tables(0).Rows(i).Item("Fee")), 2))
                            int_Amount_new = open_con.new_amount(int_Amount)
                            int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance + ds_Loan_Fees.Tables(0).Rows(i).Item("Fee")), 2))
                            int_Balance_new = open_con.new_amount(int_Balance)
                            dtm_Transaction_Date = txtstartdt_new
                            Response.Write("<tr>")
                            Response.Write("<td style='width:100;height:16;text-align:right'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(dtm_Transaction_Date & "&nbsp;&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:234;height:16' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(str_Description)
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Amount_new)
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write("&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:110;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Balance_new & "Dr")
                            Response.Write("</td>")
                            Response.Write("</tr>")
                        End If
                    Next

                End If

                Dim strNoticesIDs, strPaymentIDs, strFeeIDs, strDishonourIDs, strWaiveIDs As String

                strNoticesIDs = "0"
                strPaymentIDs = "0"
                strNoticesIDs = "0"
                strFeeIDs = "0"
                strDishonourIDs = "0"
                strWaiveIDs = "0"

                For j As Integer = 0 To ds_Account.Tables(0).Rows.Count - 1

                    If bln_Opening_Balance_Displayed = False And ds_Account.Tables(0).Rows(j).Item("Payment_Date").ToString >= txtstartdt Then
                        Response.Write("<tr>")
                        Response.Write("<td style='width:100;height:16;text-align:center'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                        Dim startdt_new As String
                        startdt_new = CDate(txtstartdt).ToString("dd/MMM/yyyy")
                        Dim month_startdt, year_startdt, day_startdt As String

                        day_startdt = Left(startdt_new, 2)


                        pos_int_Total1 = InStr(1, startdt_new, "/")
                        month_startdt = Mid(startdt_new, pos_int_Total1 + 1, 3)
                        year_startdt = Val(Right(startdt_new, 4))
                        startdt_new = day_startdt & "-" & month_startdt & "-" & year_startdt
                        txtstartdt = startdt_new
                        Response.Write(txtstartdt)
                        Response.Write("</td>")
                        Response.Write("<td style='width:234;height:16' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                        Response.Write("Opening balance")
                        Response.Write("</td>")
                        Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                        Response.Write("&nbsp;")
                        Response.Write("</td>")
                        Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                        Response.Write("&nbsp;")
                        Response.Write("</td>")
                        Response.Write("<td style='width:110;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                        Response.Write(int_Balance_new & "Dr")
                        Response.Write("</td>")
                        Response.Write("</tr>")

                        bln_Opening_Balance_Displayed = True

                    End If





                    If (ds_Account.Tables(0).Rows(j).Item("Fee_Status").ToString = "Arear notice fee" Or ds_Account.Tables(0).Rows(j).Item("Fee_Status").ToString = "Variation fee" Or ds_Account.Tables(0).Rows(j).Item("Fee_Status").ToString = "Letter of demand fee" Or ds_Account.Tables(0).Rows(j).Item("Fee_Status").ToString = "Default notice fee" Or ds_Account.Tables(0).Rows(j).Item("Fee_Status").ToString = "Statement of account fee" Or ds_Account.Tables(0).Rows(j).Item("Fee_Status").ToString = "Enforcement fee") And str_count(strNoticesIDs, ds_Account.Tables(0).Rows(j).Item("Payment_ID")) = 0 Then
                        If Trim(ds_Account.Tables(0).Rows(j).Item("Fee_Status").ToString) = "Arear notice fee" Then
                            str_Description = "Arrears notice fee"
                        Else
                            str_Description = ds_Account.Tables(0).Rows(j).Item("Fee_Status").ToString
                        End If

                        int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds_Account.Tables(0).Rows(j).Item("Amount").ToString), 2))
                        int_Amount_new = open_con.new_amount(int_Amount)
                        int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance + ds_Account.Tables(0).Rows(j).Item("Amount").ToString), 2))
                        int_Balance_new = open_con.new_amount(int_Balance)
                        dtm_Transaction_Date = ds_Account.Tables(0).Rows(j).Item("Payment_Date")
                        Dim transdate_new As String
                        transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
                        Dim month_trans_new, year_trans_new, day_trans_new As String

                        day_trans_new = Left(transdate_new, 2)
                        pos_int_Total1 = InStr(1, transdate_new, "/")
                        month_trans_new = Mid(transdate_new, pos_int_Total1 + 1, 3)
                        year_trans_new = Val(Right(transdate_new, 4))
                        transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
                        dtm_Transaction_Date = transdate_new
                        If ds_Account.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt And ds_Account.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt Then


                            Response.Write("<tr>")
                            Response.Write("<td style='width:100;height:16;text-align:right'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(dtm_Transaction_Date & "&nbsp;&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:234;height:16' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(str_Description)
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Amount_new)
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write("&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:110;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Balance_new & "Dr")
                            Response.Write("</td>")
                            Response.Write("</tr>")


                        End If
                        strNoticesIDs = strNoticesIDs & ds_Account.Tables(0).Rows(j).Item("Payment_ID").ToString & ","

                    ElseIf ds_Account.Tables(0).Rows(j).Item("description").ToString = "Paid" And str_count(strPaymentIDs, ds_Account.Tables(0).Rows(j).Item("Payment_ID").ToString) = 0 Then

                        If Trim(ds_Account.Tables(0).Rows(j).Item("Payment_Method").ToString) = "Cas" Then
                            str_Description = "Payment made by cash"
                        ElseIf Trim(ds_Account.Tables(0).Rows(j).Item("Payment_Method").ToString) = "Chq" Then
                            str_Description = "Payment made by cheque"
                        ElseIf Trim(ds_Account.Tables(0).Rows(j).Item("Payment_Method").ToString) = "Sal" Then
                            str_Description = "Payment made by salary deduction"
                        ElseIf Trim(ds_Account.Tables(0).Rows(j).Item("Payment_Method").ToString) = "Cre" Then
                            str_Description = "Payment made by Credit"
                        Else
                            str_Description = "Payment made by direct debit"
                        End If

                        dtm_Transaction_Date = ds_Account.Tables(0).Rows(j).Item("Payment_Date")
                        Dim transdate_new As String
                        transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
                        Dim month_trans_new, year_trans_new, day_trans_new As String

                        day_trans_new = Left(transdate_new, 2)

                        pos_int_Total1 = InStr(1, transdate_new, "/")
                        month_trans_new = Mid(transdate_new, pos_int_Total1 + 1, 3)
                        year_trans_new = Val(Right(transdate_new, 4))
                        transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
                        dtm_Transaction_Date = transdate_new

                        int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds_Account.Tables(0).Rows(j).Item("Amount").ToString), 2))
                        int_Amount_new = open_con.new_amount(int_Amount)
                        int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance - ds_Account.Tables(0).Rows(j).Item("Amount").ToString), 2))
                        int_Balance_new = open_con.new_amount(int_Balance)
                        If ds_Account.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt And ds_Account.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt Then
                            Response.Write("<tr>")
                            Response.Write("<td style='width:100;height:16;text-align:right'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(dtm_Transaction_Date & "&nbsp;&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:234;height:16' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(str_Description)
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write("&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Amount_new)
                            Response.Write("</td>")
                            Response.Write("<td style='width:110;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Balance_new & "Dr")
                            Response.Write("</td>")
                            Response.Write("</tr>")
                        End If
                        strPaymentIDs = strPaymentIDs & ds_Account.Tables(0).Rows(j).Item("Payment_ID") & ","
                    ElseIf ds_Account.Tables(0).Rows(j).Item("description").ToString = "Dishonour" And str_count(strDishonourIDs, ds_Account.Tables(0).Rows(j).Item("Payment_ID")) = 0 Then

                        If ds_Account.Tables(0).Rows(j).Item("Payment_Method") = "Chq" Then
                            str_Description = "Cheque Payment dishonoured"
                        Else
                            str_Description = "Direct debit dishonoured"
                        End If

                        int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds_Account.Tables(0).Rows(j).Item("Amount")), 2))
                        int_Amount_new = open_con.new_amount(int_Amount)
                        int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance + ds_Account.Tables(0).Rows(j).Item("Amount")), 2))
                        int_Balance_new = open_con.new_amount(int_Balance)
                        dtm_Transaction_Date = ds_Account.Tables(0).Rows(j).Item("Payment_Date")
                        Dim transdate_new As String
                        transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
                        Dim month_trans_new, year_trans_new, day_trans_new As String
                        day_trans_new = Left(transdate_new, 2)

                        pos_int_Total1 = InStr(1, transdate_new, "/")
                        month_trans_new = Mid(transdate_new, pos_int_Total1 + 1, 3)
                        year_trans_new = Val(Right(transdate_new, 4))
                        transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
                        dtm_Transaction_Date = transdate_new




                        If ds_Account.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt And ds_Account.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt Then

                            Response.Write("<tr>")
                            Response.Write("<td style='width:100;height:16;text-align:right'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(dtm_Transaction_Date & "&nbsp;&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:234;height:16' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(str_Description)
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Amount_new)
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write("&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:110;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Balance_new & "Dr")
                            Response.Write("</td>")
                            Response.Write("</tr>")

                        End If

                        strDishonourIDs = strDishonourIDs & ds_Account.Tables(0).Rows(j).Item("Payment_ID") & ","

                    ElseIf (ds_Account.Tables(0).Rows(j).Item("Fee_Status").ToString = "Dishonoured fee" Or ds_Account.Tables(0).Rows(j).Item("Fee_Status").ToString = "Cancellation fee") And str_count(strFeeIDs, ds_Account.Tables(0).Rows(j).Item("Payment_ID")) = 0 Then

                        str_Description = ds_Account.Tables(0).Rows(j).Item("Fee_Status")
                        int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds_Account.Tables(0).Rows(j).Item("Amount")), 2))
                        int_Amount_new = open_con.new_amount(int_Amount)
                        int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance + ds_Account.Tables(0).Rows(j).Item("Amount")), 2))
                        int_Balance_new = open_con.new_amount(int_Balance)
                        dtm_Transaction_Date = ds_Account.Tables(0).Rows(j).Item("Payment_Date")
                        Dim transdate_new As String
                        transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
                        Dim month_trans_new, year_trans_new, day_trans_new As String

                        day_trans_new = Left(transdate_new, 2)


                        pos_int_Total1 = InStr(1, transdate_new, "/")
                        month_trans_new = open_con.cal_short_month_new(Mid(transdate_new, pos_int_Total1 + 1, 3))
                        year_trans_new = Val(Right(transdate_new, 4))
                        transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
                        dtm_Transaction_Date = transdate_new


                        If ds_Account.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt And ds_Account.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt Then
                            Response.Write("<tr>")
                            Response.Write("<td style='width:100;height:16;text-align:right'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(dtm_Transaction_Date & "&nbsp;&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:234;height:16' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(str_Description)
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Amount_new)
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write("&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:110;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Balance_new & "Dr")
                            Response.Write("</td>")
                            Response.Write("</tr>")
                        End If
                        strFeeIDs = strFeeIDs & ds_Account.Tables(0).Rows(j).Item("Payment_ID") & ","

                    ElseIf ds_Account.Tables(0).Rows(j).Item("Description").ToString = "Waived" And str_count(strWaiveIDs, ds_Account.Tables(0).Rows(j).Item("Payment_ID")) = 0 Then

                        str_Description = ds_Account.Tables(0).Rows(j).Item("Description")
                        int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds_Account.Tables(0).Rows(j).Item("Amount")), 2))
                        int_Amount_new = open_con.new_amount(int_Amount)
                        int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance - ds_Account.Tables(0).Rows(j).Item("Amount")), 2))
                        int_Balance_new = open_con.new_amount(int_Balance)
                        dtm_Transaction_Date = ds_Account.Tables(0).Rows(j).Item("Payment_Date")
                        Dim transdate_new As String
                        transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
                        Dim month_trans_new, year_trans_new, day_trans_new As String

                        day_trans_new = Left(transdate_new, 2)

                        pos_int_Total1 = InStr(1, transdate_new, "/")
                        month_trans_new = Mid(transdate_new, pos_int_Total1 + 1, 3)
                        year_trans_new = Val(Right(transdate_new, 4))
                        transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
                        dtm_Transaction_Date = transdate_new

                        If ds_Account.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt And ds_Account.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt Then

                            Response.Write("<tr>")
                            Response.Write("<td style='width:100;height:16;text-align:right'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(dtm_Transaction_Date & "&nbsp;&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:234;height:16' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write("Amount " & LCase(str_Description))
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write("&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Amount_new)
                            Response.Write("</td>")
                            Response.Write("<td style='width:110;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Balance_new & "Dr")
                            Response.Write("</td>")
                            Response.Write("</tr>")

                        End If

                        strWaiveIDs = strWaiveIDs & ds_Account.Tables(0).Rows(j).Item("Payment_ID") & ","

                    ElseIf ds_Account.Tables(0).Rows(j).Item("Description").ToString = "Draw down" Or ds_Account.Tables(0).Rows(j).Item("Description").ToString = "Credit fee" Then
                        If Trim(ds_Account.Tables(0).Rows(j).Item("Description")) = "Credit fee" Then
                            str_Description = "Draw down fee"
                        Else
                            str_Description = ds_Account.Tables(0).Rows(j).Item("Description").ToString
                        End If
                        int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds_Account.Tables(0).Rows(j).Item("Amount")), 2))
                        int_Amount_new = open_con.new_amount(int_Amount)
                        int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance + ds_Account.Tables(0).Rows(j).Item("Amount")), 2))
                        int_Balance_new = open_con.new_amount(int_Balance)
                        dtm_Transaction_Date = ds_Account.Tables(0).Rows(j).Item("Payment_Date")
                        Dim transdate_new As String
                        transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
                        Dim month_trans_new, year_trans_new, day_trans_new As String

                        day_trans_new = Left(transdate_new, 2)


                        pos_int_Total1 = InStr(1, transdate_new, "/")
                        month_trans_new = Mid(transdate_new, pos_int_Total1 + 1, 3)
                        year_trans_new = Val(Right(transdate_new, 4))
                        transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
                        dtm_Transaction_Date = transdate_new


                        If ds_Account.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt And ds_Account.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt Then
                            Response.Write("<tr>")
                            Response.Write("<td style='width:100;height:16;text-align:right'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(dtm_Transaction_Date & "&nbsp;&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:234;height:16' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(str_Description)
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Amount_new)
                            Response.Write("</td>")
                            Response.Write("<td style='width:83;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write("&nbsp;")
                            Response.Write("</td>")
                            Response.Write("<td style='width:110;height:16;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                            Response.Write(int_Balance_new & "Dr")
                            Response.Write("</td>")
                            Response.Write("</tr>")

                        End If
                    End If
                Next

                Response.Write("</table>")
                Response.Write("</div>")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("</table>")
                ''''''close all connections
                ds_Account.Dispose()
                ds_Branch_Detail.Dispose()
                ds_CustomerAddress.Dispose()
                ds_loan.Dispose()
                ds_Loan_Fees.Dispose()
                cmd_actst.Dispose()
                cmd_Branch_Detail.Dispose()
                cmd_CustomerAddress.Dispose()
                cmd_loan.Dispose()
                cmd_Loan_Fees.Dispose()
                adap_Account.Dispose()
                adap_Branch_Detail.Dispose()
                adap_CustomerAddress.Dispose()
                adap_loan.Dispose()
                adap_Loan_Fees.Dispose()
                open_con.return_con.Dispose()


            Catch ex As Exception
                Response.Write("Error: " & ex.Message)
                open_con.return_con.Dispose()
            End Try
        End If
    End Sub
    Function str_count(ByVal StringToSearch As String, ByVal StringToFind As String) As Long
        If Len(StringToFind) Then
            str_count = UBound(Split(StringToSearch, StringToFind))
        End If
    End Function
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
