Imports System.Data
Imports System.Data.SqlClient

Partial Class Customer_Payroll
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim loanpayroll_id As Integer
            '''''''''''''''''''
            If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
                loanpayroll_id = Session("beg_loan_id")

            ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                loanpayroll_id = Session("beg_loan_id")

            ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                loanpayroll_id = Session("cur_loan_id")

            ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                loanpayroll_id = Session("cur_loan_id")

            ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                loanpayroll_id = Session("beg_loan_id")

            ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False Then

                loanpayroll_id = Session("cur_loan_id")
            End If


            '''''''''''''





            Session("payroll_amt_new") = 0
            Dim str_ACLN As String
            str_ACLN = "Australian Credit Licence Number 391104"

            Dim cmd_CustomerDetail, cmd_MoneyPlus, cmd_Schedule As New SqlCommand
            Dim adap_CustomerDetail, adap_MoneyPlus, adap_Schedule As SqlDataAdapter
            Dim ds_CustomerDetail, ds_MoneyPlus, ds_Schedule As New DataSet

            Dim str_SQL As String

            str_SQL = "SELECT * FROM Tbl_Customer WHERE Customer_ID = " & open_con.customer_id_val
            cmd_CustomerDetail.CommandText = str_SQL
            cmd_CustomerDetail.Connection = open_con.return_con
            adap_CustomerDetail = New SqlDataAdapter(cmd_CustomerDetail)
            adap_CustomerDetail.Fill(ds_CustomerDetail)

            str_SQL = " SELECT Tbl_Payment.Loan_ID, Tbl_Payment.Amount, Tbl_Payment.Payment_Method, Tbl_Payment.Due_Date "
            str_SQL = str_SQL & " FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID "
            str_SQL = str_SQL & " WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Cancellation fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND Tbl_Payment.Transaction_Status is null AND Tbl_Payment.Payment_Date is NULL AND (Tbl_Payment.Payment_Method = 'CBA' OR Tbl_Payment.Payment_Method = 'NAB' OR Tbl_Payment.Payment_Method = 'Sal')"
            str_SQL = str_SQL & " AND Tbl_Payment.Loan_ID= " & loanpayroll_id & " AND Tbl_Payment.Amount <> 0 AND  Tbl_Payment_1.Update_ID Is Null ORDER BY  Tbl_Payment.Due_Date "

            cmd_Schedule.CommandText = str_SQL
            cmd_Schedule.Connection = open_con.return_con
            adap_Schedule = New SqlDataAdapter(cmd_Schedule)
            adap_Schedule.Fill(ds_Schedule)

            str_SQL = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val
            cmd_MoneyPlus.CommandText = str_SQL
            cmd_MoneyPlus.Connection = open_con.return_con
            adap_MoneyPlus = New SqlDataAdapter(cmd_MoneyPlus)
            adap_MoneyPlus.Fill(ds_MoneyPlus)



            Response.Write("<table  style='margin-left:.6in;width:570'  cellpadding='0' cellspacing='0'>")
            Response.Write("<tr>")
            Response.Write("<td >")
            Response.Write("<img  src='../Images/MPNoticeLogo.jpg' style='width:200;height:110;;text-align:left' >")
            Response.Write("</td>")
            Response.Write("<td  valign='top' style='font-size:16px;text-align:right'>")
            Response.Write("<br/>")
            Response.Write("<span>" & str_ACLN & "</span>")
            Response.Write("<br/>")
            Response.Write("<span >" & "c/-" & " " & ds_MoneyPlus.Tables(0).Rows(0).Item("Trading_Name").ToString & " ABN " & ds_MoneyPlus.Tables(0).Rows(0).Item("ACN").ToString & "</span>")
            Response.Write("<br/>")
            Response.Write(ds_MoneyPlus.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_MoneyPlus.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_MoneyPlus.Tables(0).Rows(0).Item("Suburb").ToString & ", " & ds_MoneyPlus.Tables(0).Rows(0).Item("State").ToString & " " & ds_MoneyPlus.Tables(0).Rows(0).Item("Post_Code").ToString)
            Response.Write("<br/>")
            Response.Write("Tel: " & ds_MoneyPlus.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_MoneyPlus.Tables(0).Rows(0).Item("Fax_Number").ToString)
            Response.Write("<br/>")
            Response.Write("</td>")
            Response.Write("</tr>")
            Dim month_loan, year_loan, day_loan As String
            Dim tod_dt As String
            tod_dt = System.DateTime.Now.Date
            tod_dt = tod_dt.Replace("/", " ")
            day_loan = Val(Left(tod_dt, 2))

            If Len(day_loan) = 1 Then
                day_loan = "0" & day_loan
            Else
                day_loan = day_loan
            End If
            month_loan = open_con.cal_short_month(Val(Mid(tod_dt, 4, 2)))
            year_loan = Val(Right(tod_dt, 4))
            tod_dt = day_loan & " " & month_loan & " " & year_loan
            Response.Write("<tr>")
            Response.Write("<td colspan='2' valign='top' style='font-size:16px;width:300;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in'>")
            Response.Write("<br/>")
            Response.Write("<b>Date:&nbsp;</b>" & tod_dt)
            Response.Write("<br/>")
            Response.Write("<br/>")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("</table>")

            Response.Write("<table style='margin-left:.6in;width:570'  >")
            Response.Write("<tr>")
            Response.Write("<td  style='width:300;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>Payroll office:</b></td>")
            Response.Write("<td  style='width:700; padding-top: 0in; padding-bottom: 0in;font-size:16px'>" & ds_CustomerDetail.Tables(0).Rows(0).Item("Employer").ToString & "</td>")
            Response.Write("<td  style='width:300; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>Phone:</b>" & "&nbsp;&nbsp;&nbsp;" & ds_CustomerDetail.Tables(0).Rows(0).Item("E_Phone_Number").ToString & "</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td  style='width:300;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>Attention:</b></td>")
            Response.Write("<td  style='width:300; padding-top: 0in; padding-bottom: 0in;font-size:16px'>" & ds_CustomerDetail.Tables(0).Rows(0).Item("E_Contact_Person").ToString & "</td>")
            Response.Write("<td  style='width:300; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>Fax:</b>" & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & ds_CustomerDetail.Tables(0).Rows(0).Item("E_Fax_Number").ToString & "</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td  style='width:300;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>Employee No:</b></td>")
            Response.Write("<td  style='width:300; padding-top: 0in; padding-bottom: 0in;font-size:16px'>" & ds_CustomerDetail.Tables(0).Rows(0).Item("Employee_no").ToString & "</td>")
            Response.Write("<td  style='width:300; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>Email:</b>" & "&nbsp;&nbsp;&nbsp;" & ds_CustomerDetail.Tables(0).Rows(0).Item("E_Email").ToString & "</td>")
            Response.Write("</tr>")

            Response.Write("<tr>")
            Response.Write("<td>&nbsp;</td>")
            Response.Write("</tr>")
            Response.Write("</table>")
            Response.Write("<table  style='margin-left:.6in;width:570'  >")
            Response.Write("<tr>")
            Response.Write("<td colspan='2' style='width:300;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>RE:</b> PAYROLL DEDUCTION</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='2' style='width:300;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>&nbsp;</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='2' style='width:300;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>Name: </b>" & ds_CustomerDetail.Tables(0).Rows(0).Item("Given_Name").ToString & "&nbsp;" & ds_CustomerDetail.Tables(0).Rows(0).Item("Last_Name").ToString & "</td>")
            Response.Write("<td colspan='2' style='width:300;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Loan No: </b>" & loanpayroll_id & "</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='2' style='width:300;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>&nbsp;</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='3' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>")
            Response.Write("Further to our phone conversation today, our bank details are as follows:")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("</table>")
            Response.Write("<table style='margin-left:.6in;width:570'  >")



            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:300;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>ABAZ PTY LTD</b></td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:400;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>BANK:</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & ds_MoneyPlus.Tables(0).Rows(0).Item("Emp_Bank").ToString & "</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td  style='width:200;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>BSB:</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp" & ds_MoneyPlus.Tables(0).Rows(0).Item("Emp_BSB").ToString & "</td>")
            Response.Write("<td style='width:800;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:15.5px;text-align:right'><b>ACCOUNT NUMBER:</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & ds_MoneyPlus.Tables(0).Rows(0).Item("Emp_Account_No").ToString & "</td>")
            Response.Write("<td style='width:100;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>&nbsp;</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='2' style='width:300;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>&nbsp;</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:500;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>The amount to be deducted is as follows:</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='2' style='width:300;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim int_ScheduleTotal As Integer
            Dim payroll_amt As Double
            Dim payroll_amt_new As String
            Dim payroll_date As DateTime
            Dim payroll_date_new As String
            Dim payroll_first_date As DateTime
            Dim payroll_first_date_new As String
            int_ScheduleTotal = ds_Schedule.Tables(0).Rows.Count


            If ds_Schedule.Tables(0).Rows.Count = 0 Then

            ElseIf ds_Schedule.Tables(0).Rows.Count = 1 Then

                Response.Write("<table >")
                Response.Write("<tr>")
                Response.Write("<td >")
                Response.Write("&nbsp;")
                Response.Write("</td >")

                Response.Write("<td valign='top'  style='font-size:16px'>")

                For j As Integer = 0 To (int_ScheduleTotal / 2) - 1

                    payroll_amt = ds_Schedule.Tables(0).Rows(j).Item("Amount").ToString()
                    payroll_amt = open_con.check_amount_format(Math.Round(payroll_amt, 2))
                    payroll_amt_new = open_con.new_amount(payroll_amt)
                    Session("payroll_amt_new") = CDbl(Session("payroll_amt_new")) + open_con.newamount(payroll_amt)
                    Response.Write("(" & j + 1 & ")" & "&nbsp;&nbsp;" & payroll_amt_new)
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    payroll_date = ds_Schedule.Tables(0).Rows(j).Item("Due_Date").ToString()
                    payroll_date_new = payroll_date.ToString("dd/MM/yyyy")
                    Response.Write(payroll_date_new)
                    payroll_first_date = ds_Schedule.Tables(0).Rows(0).Item("Due_Date").ToString()
                    payroll_first_date_new = payroll_first_date.ToString("dd/MM/yyyy")

                Next
                Response.Write("</td>")
                Response.Write("<td >")
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                Response.Write("</td >")
                Response.Write("</tr>")
                Response.Write("</table>")



            ElseIf int_ScheduleTotal Mod 2 = 0 Then


                Response.Write("<table >")
                Response.Write("<tr>")
                Response.Write("<td >")
                Response.Write("&nbsp;")
                Response.Write("</td >")

                Response.Write("<td valign='top'  style='font-size:16px'>")
                For j As Integer = 0 To (int_ScheduleTotal / 2) - 1

                    payroll_amt = ds_Schedule.Tables(0).Rows(j).Item("Amount").ToString()
                    payroll_amt = open_con.check_amount_format(Math.Round(payroll_amt, 2))
                    payroll_amt_new = open_con.new_amount(payroll_amt)
                    Session("payroll_amt_new") = CDbl(Session("payroll_amt_new")) + open_con.newamount(payroll_amt)
                    Response.Write("(" & j + 1 & ")" & "&nbsp;&nbsp;" & payroll_amt_new)
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    payroll_date = ds_Schedule.Tables(0).Rows(j).Item("Due_Date").ToString()
                    payroll_date_new = payroll_date.ToString("dd/MM/yyyy")
                    Response.Write(payroll_date_new)
                    payroll_first_date = ds_Schedule.Tables(0).Rows(0).Item("Due_Date").ToString()
                    payroll_first_date_new = payroll_first_date.ToString("dd/MM/yyyy")

                Next
                Response.Write("</td>")
                Response.Write("<td >")
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                Response.Write("</td >")
                Response.Write("<td valign='top'  style='font-size:16px;width:20px'>")

                For k As Integer = (int_ScheduleTotal / 2) To int_ScheduleTotal - 1

                    payroll_amt = ds_Schedule.Tables(0).Rows(k).Item("Amount").ToString()
                    payroll_amt = open_con.check_amount_format(Math.Round(payroll_amt, 2))
                    payroll_amt_new = open_con.new_amount(payroll_amt)
                    Session("payroll_amt_new") = CDbl(Session("payroll_amt_new")) + open_con.newamount(payroll_amt)
                    Response.Write("(" & k + 1 & ")" & "&nbsp;&nbsp;" & payroll_amt_new)
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    payroll_date = ds_Schedule.Tables(0).Rows(k).Item("Due_Date").ToString()
                    payroll_date_new = payroll_date.ToString("dd/MM/yyyy")
                    Response.Write(payroll_date_new)

                Next

                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("</table>")


            Else


                Response.Write("<table>")
                Response.Write("<tr>")
                Response.Write("<td >")
                Response.Write("&nbsp;")
                Response.Write("</td >")

                Response.Write("<td valign='top'  style='font-size:16px'>")
                For j As Integer = 0 To (int_ScheduleTotal - 1) / 2

                    payroll_amt = ds_Schedule.Tables(0).Rows(j).Item("Amount").ToString()
                    payroll_amt = open_con.check_amount_format(Math.Round(payroll_amt, 2))
                    payroll_amt_new = open_con.new_amount(payroll_amt)
                    Session("payroll_amt_new") = CDbl(Session("payroll_amt_new")) + open_con.newamount(payroll_amt)
                    Response.Write("(" & j + 1 & ")" & "&nbsp;&nbsp;" & payroll_amt_new)
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    payroll_date = ds_Schedule.Tables(0).Rows(j).Item("Due_Date").ToString()
                    payroll_date_new = payroll_date.ToString("dd/MM/yyyy")
                    Response.Write(payroll_date_new)
                    payroll_first_date = ds_Schedule.Tables(0).Rows(0).Item("Due_Date").ToString()
                    payroll_first_date_new = payroll_first_date.ToString("dd/MM/yyyy")

                Next
                Response.Write("</td>")
                Response.Write("<td >")
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                Response.Write("</td >")
                Response.Write("<td valign='top'  style='font-size:16px;width:20px'>")

                For k As Integer = ((int_ScheduleTotal - 1) / 2) + 1 To int_ScheduleTotal - 1

                    payroll_amt = ds_Schedule.Tables(0).Rows(k).Item("Amount").ToString()
                    payroll_amt = open_con.check_amount_format(Math.Round(payroll_amt, 2))
                    payroll_amt_new = open_con.new_amount(payroll_amt)
                    Session("payroll_amt_new") = CDbl(Session("payroll_amt_new")) + open_con.newamount(payroll_amt)
                    Response.Write("(" & k + 1 & ")" & "&nbsp;&nbsp;" & payroll_amt_new)
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    payroll_date = ds_Schedule.Tables(0).Rows(k).Item("Due_Date").ToString()
                    payroll_date_new = payroll_date.ToString("dd/MM/yyyy")
                    Response.Write(payroll_date_new)

                Next

                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("</table>")


            End If




            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>Total to be repaid is therefore" & " " & open_con.new_amount(Session("payroll_amt_new")) & "</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>&nbsp;</td>")
            Response.Write("</tr>")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>1)&nbsp; Should I cease employment I agree all monies are to be credited in FULL&nbsp;to </b></td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>&nbsp;&nbsp;&nbsp;&nbsp; the above bank account.</b></td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'><b>2)&nbsp; Money plus must authorise any cancellations or changes to these dates.</b></td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>&nbsp;</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>Should you require any assistance or clarification please feel free to contact me on the</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'> above number.</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>&nbsp;</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>.......................................</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>Manager</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>&nbsp;</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>I,......................................................................................, agree to the above request</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>(customer full name)</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>&nbsp;</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>&nbsp;</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>Signature of customer........................................&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date........../......../.............</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>&nbsp;</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>&nbsp;</td>")
            Response.Write("</tr>")


            Response.Write("<tr>")
            Response.Write("<td colspan='5' style='width:700;padding-left: 5.4pt; padding-top: 0in; padding-bottom: 0in;font-size:16px'>Date faxed..................................&nbsp;&nbsp;&nbsp;&nbsp; Confirmed by..........................................</td>")
            Response.Write("</tr>")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Response.Write("</table>")


            '''''''''''''close all connections
            ds_CustomerDetail.Dispose()
            ds_MoneyPlus.Dispose()
            ds_Schedule.Dispose()
            cmd_CustomerDetail.Dispose()
            cmd_MoneyPlus.Dispose()
            cmd_Schedule.Dispose()
            adap_CustomerDetail.Dispose()
            adap_MoneyPlus.Dispose()
            adap_Schedule.Dispose()
            open_con.return_con.Dispose()


        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
            open_con.return_con.Dispose()
        End Try
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
