Imports System.Data
Imports System.Data.SqlClient

Partial Class Customer_NAB_DD
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try

                Dim str_SQL, str_SQL_new As String
                Dim loan_id, Bank_Account_id As Integer

                Dim cmd_bank_account_id, cmd_newbank_account_id As New SqlCommand
                Dim adap_bank_account_id, adap_newbank_account_id As SqlDataAdapter
                Dim ds_bank_account_id, ds_newbank_account_id As New DataSet
                str_SQL = "select Bank_Account_ID from tbl_Customer where customer_id = " & open_con.customer_id_val
                cmd_bank_account_id.CommandText = str_SQL
                cmd_bank_account_id.Connection = open_con.return_con
                adap_bank_account_id = New SqlDataAdapter(cmd_bank_account_id)
                adap_bank_account_id.Fill(ds_bank_account_id)

                Dim str As String

                str = ds_bank_account_id.Tables(0).Rows(0).Item(0).ToString

                If Val(str) = 0 Then

                    str_SQL_new = "select max(Bank_Account_ID) from tbl_Bank_Account where customer_id = " & open_con.customer_id_val
                    cmd_newbank_account_id.CommandText = str_SQL_new
                    cmd_newbank_account_id.Connection = open_con.return_con
                    adap_newbank_account_id = New SqlDataAdapter(cmd_newbank_account_id)
                    adap_newbank_account_id.Fill(ds_newbank_account_id)
                    Bank_Account_id = ds_newbank_account_id.Tables(0).Rows(0).Item(0).ToString
                    adap_newbank_account_id.Dispose()
                Else

                    Bank_Account_id = ds_bank_account_id.Tables(0).Rows(0).Item(0).ToString
                End If

                If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

                    loan_id = Session("beg_loan_id")

                ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                    loan_id = Session("beg_loan_id")

                ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                    loan_id = Session("cur_loan_id")

                ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                    loan_id = Session("cur_loan_id")

                ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                    loan_id = Session("beg_loan_id")

                ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False Then

                    loan_id = Session("cur_loan_id")

                End If




                If Val(Session("beg_status")) = 0 Then

                    str_SQL = " SELECT Tbl_Customer.Given_Name, Tbl_Customer.Last_Name, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code,  Tbl_Bank_Account.Account_Name, Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.Bank_Name, Tbl_Bank_Account.Bank_Address, Tbl_Bank_Account.Bank_Suburb, Tbl_Bank_Account.Bank_State, Tbl_Bank_Account.Bank_Post_Code, Tbl_Bank_Account.BSB"
                    str_SQL = str_SQL & " FROM Tbl_Customer INNER JOIN  Tbl_Bank_Account  ON Tbl_Customer.Customer_ID = Tbl_Bank_Account.Customer_ID"
                    str_SQL = str_SQL & " WHERE  tbl_Customer.Customer_ID = " & open_con.customer_id_val & " and tbl_Bank_Account.Bank_Account_ID = " & Bank_Account_id

                ElseIf Session("beg_status") = "Pending" Then



                    str_SQL = " SELECT Tbl_Customer.Given_Name, Tbl_Customer.Last_Name, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code,  Tbl_Bank_Account.Account_Name, Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.Bank_Name, Tbl_Bank_Account.Bank_Address, Tbl_Bank_Account.Bank_Suburb, Tbl_Bank_Account.Bank_State, Tbl_Bank_Account.Bank_Post_Code, Tbl_Bank_Account.BSB"
                    str_SQL = str_SQL & " FROM Tbl_Customer INNER JOIN  Tbl_Bank_Account  ON Tbl_Customer.Customer_ID = Tbl_Bank_Account.Customer_ID"
                    str_SQL = str_SQL & " WHERE  tbl_Customer.Customer_ID = " & open_con.customer_id_val & "and tbl_Bank_Account.Bank_Account_ID = " & Bank_Account_id

                Else

                    str_SQL = " SELECT Tbl_Customer.Given_Name, Tbl_Customer.Last_Name, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code,  Tbl_Bank_Account.Account_Name, Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.Bank_Name, Tbl_Bank_Account.Bank_Address, Tbl_Bank_Account.Bank_Suburb, Tbl_Bank_Account.Bank_State, Tbl_Bank_Account.Bank_Post_Code, Tbl_Bank_Account.BSB"
                    str_SQL = str_SQL & " FROM Tbl_Customer INNER JOIN (Tbl_Bank_Account INNER JOIN Tbl_Loan ON Tbl_Bank_Account.Bank_Account_ID = Tbl_Loan.Bank_Account_ID) ON Tbl_Customer.Customer_ID = Tbl_Bank_Account.Customer_ID "
                    str_SQL = str_SQL & " WHERE  Tbl_Loan.Loan_ID = " & loan_id
                End If




                Dim cmd_CustomerBank As New SqlCommand
                Dim adap_CustomerBank As SqlDataAdapter
                Dim ds_CustomerBank As New DataSet

                cmd_CustomerBank.CommandText = str_SQL
                cmd_CustomerBank.Connection = open_con.return_con
                adap_CustomerBank = New SqlDataAdapter(cmd_CustomerBank)
                adap_CustomerBank.Fill(ds_CustomerBank)

                str_SQL = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val

                Dim cmd_MoneyPlus As New SqlCommand
                Dim adap_MoneyPlus As SqlDataAdapter
                Dim ds_MoneyPlus As New DataSet

                cmd_MoneyPlus.CommandText = str_SQL
                cmd_MoneyPlus.Connection = open_con.return_con
                adap_MoneyPlus = New SqlDataAdapter(cmd_MoneyPlus)
                adap_MoneyPlus.Fill(ds_MoneyPlus)

                str_SQL = "Select * from Tbl_loan Where Loan_ID =" & loan_id

                Dim cmd_loan As New SqlCommand
                Dim adap_loan As SqlDataAdapter
                Dim ds_loan As New DataSet

                cmd_loan.CommandText = str_SQL
                cmd_loan.Connection = open_con.return_con
                adap_loan = New SqlDataAdapter(cmd_loan)
                adap_loan.Fill(ds_loan)
                'Dim dtm_First_Payment As DateTime

                str_SQL = " SELECT Tbl_Payment.Loan_ID, Tbl_Payment.Amount, Tbl_Payment.Payment_Method, Tbl_Payment.Due_Date "
                str_SQL = str_SQL & " FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID "
                str_SQL = str_SQL & " WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Cancellation fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND Tbl_Payment.Transaction_Status is null AND Tbl_Payment.Payment_Date is NULL AND Tbl_Payment.Payment_Method = 'NAB'"
                str_SQL = str_SQL & " AND Tbl_Payment.Loan_ID= " & loan_id & " AND Tbl_Payment.Amount <> 0 AND Tbl_Payment_1.Update_ID Is Null ORDER BY  Tbl_Payment.Due_Date "


                Dim cmd_schedule As New SqlCommand
                Dim adap_schedule As SqlDataAdapter
                Dim ds_schedule As New DataSet

                Dim int_ScheduleTotal As Integer


                cmd_schedule.CommandText = str_SQL
                cmd_schedule.Connection = open_con.return_con
                adap_schedule = New SqlDataAdapter(cmd_schedule)
                adap_schedule.Fill(ds_schedule)



                'dtm_First_Payment = Date.Parse(ds_loan.Tables(0).Rows(i).Item("First_Payment").ToString)
                'dtm_First_Payment = dtm_First_Payment.ToString("dd/MM/yyyy")


                Response.Write("<table border='1'  style='border:1; border-width:0; border-collapse: collapse;width:730;height:800'   cellpadding='0' cellspacing='0'>")
                Response.Write("<tr>")
                Response.Write("<td colspan='2' valign='top' style='width:240;padding-left: 5.4pt; padding-top: 0in; padding-bottom:0in;height:30px'>")

                Response.Write("<img  src='../Images/MPNoticeLogo.jpg' style='border:0; width:180;height:110;text-align:left' >")
                Response.Write("<br/>")
                Response.Write("<b style='font-size:16.5px'>Direct Debit Request (NAB)</b>")
                Response.Write("<br/>")
                Response.Write("</td>")
                Response.Write("<td valign='top' style='font-size:16.5px;text-align:right;width:680; border-left: medium none; border-right: 1.0pt solid windowtext; border-top: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in;height:40px'>")
                Response.Write("<br/>")
                Response.Write("Request and Authority to debit the")
                Response.Write("<br/>")
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; account named below to pay")
                Response.Write("<br/>")
                Response.Write("Abaz Pty Ltd ACN 118 434 021")
                Response.Write("<br/>")
                Response.Write("First Floor 15 Campbell Street, Blacktown NSW 2148")
                Response.Write("<br/>")
                Response.Write("Tel: " & ds_MoneyPlus.Tables(0).Rows(0).Item("Phone_Number").ToString)


                Response.Write("</td>")
                Response.Write("</tr>")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Response.Write("<tr>")
                Response.Write("<td valign='top' style='font-size:16.5px;width:240;text-align:left; border-left: 1.0pt solid windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in'>")

                Response.Write("<b>Request and Authority to debit</b>")
                Response.Write("</td>")
                Response.Write("<td colspan='2' valign='top' style='font-size:16.5px;width:680; border-left: medium none; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in; height:195'>")

                Response.Write("<b>Surname or company name: &nbsp;</b>")
                Response.Write(ds_CustomerBank.Tables(0).Rows(0).Item("Last_Name").ToString)
                Response.Write("<br/>")
                Response.Write("<br/>")
                Response.Write("<b style='font-size:16.5px'>Given name: &nbsp;</b>")
                Response.Write(ds_CustomerBank.Tables(0).Rows(0).Item("Given_Name").ToString)
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>(&quotyou&quot)</b></p>")
                Response.Write("<p class='MsoNormal_dd' style='font-size:16.5px;text-align:justify'>Request and authorize Abaz Pty Ltd ACN 118 434 021")
                Response.Write("(User ID Number:" & ds_MoneyPlus.Tables(0).Rows(0).Item("NAB_User_ID1").ToString)
                Response.Write(") or Recovery Holdings Pty Ltd ABN 87 119 006 512")
                Response.Write(" (User ID Number:328403)")
                Response.Write(" to arrange for any amount Abaz Pty Ltd ACN 118 434 021 may debit or charge you to be debited through the Bulk Electronic Clearing System from an account held at the financial institution identified below subject to the terms and conditions of the Direct Debit Request Service Agreement and any further instruction provided below.")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td valign='top' style='font-size:16.5px;width:240; height: 100px; border-left: 1.0pt solid windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in; height:100'>")
                Response.Write("<b>Insert the name and address of&nbsp; financial institutions at which account is held</b>")
                Response.Write("</td>")
                Response.Write("<td colspan='2' valign='top' style='font-size:16.5px;width:680; height: 100px; border-left: medium none; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in;height:100'>")
                Response.Write("<b>Financial institution name </b>" & ds_CustomerBank.Tables(0).Rows(0).Item("Bank_Name").ToString)
                Response.Write("<br/>")
                Response.Write("<br/>")
                Response.Write("<b style='font-size:16.5px'>Address: </b>" & ds_CustomerBank.Tables(0).Rows(0).Item("Bank_Address").ToString)
                Response.Write("<br/>")
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                Response.Write(ds_CustomerBank.Tables(0).Rows(0).Item("Bank_Suburb").ToString & " " & ds_CustomerBank.Tables(0).Rows(0).Item("Bank_State").ToString & " " & ds_CustomerBank.Tables(0).Rows(0).Item("Bank_Post_Code").ToString)
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td valign='top' style='font-size:16.5px;width:240; border-left: 1.0pt solid windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in; height:30'>")

                Response.Write("<b style='font-size:16.5px'>Insert details of account to be debited</b>")
                Response.Write("</td>")
                Response.Write("<td colspan='2' valign='top' style='font-size:16.5px;width:680; border-left: medium none; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in;height:30'>")
                Response.Write("<b style='font-size:16.5px'>Name of account </b>" & ds_CustomerBank.Tables(0).Rows(0).Item("Account_Name").ToString)
                Response.Write("<br/>")
                Response.Write("<b style='font-size:16.5px'>BSB number</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & ds_CustomerBank.Tables(0).Rows(0).Item("BSB").ToString)
                Response.Write("<br/>")
                Response.Write("<b style='font-size:16.5px'>Account number </b>" & ds_CustomerBank.Tables(0).Rows(0).Item("Account_Number").ToString)
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td valign='top' style='font-size:16.5px;width:240; border-left: 1.0pt solid windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in;height:70'>")

                Response.Write("<b style='font-size:16.5px'>Acknowledgement</b>")
                Response.Write("</td>")
                Response.Write("<td colspan='2' valign='top'  style='font-size:16.5px;width: 680; border-left: medium none; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in; height:70'>")

                Response.Write("By signing this Direct Debit Request you acknowledge having read and understood the terms and conditions governing the debit arrangements between you and and Abaz Pty Ltd ACN 118 434 021 as set out in this Request and in your Direct Debit Request Service Agreement")

                Response.Write("<br/>")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<br/>")
                Response.Write("<td valign='top'  style='font-size:16.5px;width:240; border-left: 1.0pt solid windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in; height:55'>")
                Response.Write("<br/>")
                Response.Write("<b style='font-size:16.5px'>Payment Details</b>")
                Response.Write("<br/>")
                Response.Write("<br/>")
                Response.Write("</td>")
                Response.Write("<td colspan='2' valign='top' style='font-size:16.5px;width:680; border-left: medium none; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in;height:55'>")
                Response.Write("<br/>")

                Dim nab_amt As Double
                Dim nab_amt_new As String
                Dim nab_date As DateTime
                Dim nab_date_new As String
                Dim first_date As DateTime
                Dim first_date_new As String

                int_ScheduleTotal = ds_schedule.Tables(0).Rows.Count

                If ds_schedule.Tables(0).Rows.Count = 0 Then

                ElseIf ds_schedule.Tables(0).Rows.Count = 1 Then

                    Response.Write("<table>")
                    Response.Write("<tr>")
                    Response.Write("<td >")
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Response.Write("</td >")

                    Response.Write("<td valign='top'  style='font-size:16.5px'>")

                    For j As Integer = 0 To (int_ScheduleTotal / 2) - 1

                        nab_amt = ds_schedule.Tables(0).Rows(j).Item("Amount").ToString()
                        nab_amt = open_con.check_amount_format(Math.Round(nab_amt, 2))
                        nab_amt_new = open_con.new_amount(nab_amt)
                        Response.Write(nab_amt_new)
                        Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;")
                        nab_date = ds_schedule.Tables(0).Rows(j).Item("Due_Date").ToString()
                        nab_date_new = nab_date.ToString("dd/MM/yyyy")
                        Response.Write(nab_date_new)
                        first_date = ds_schedule.Tables(0).Rows(0).Item("Due_Date").ToString()
                        first_date_new = first_date.ToString("dd/MM/yyyy")
                        Session("frst_date") = first_date_new
                        Response.Write("<br/>")
                    Next
                    Response.Write("</td>")
                    Response.Write("<td >")
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Response.Write("</td >")
                    Response.Write("</tr>")
                    Response.Write("</table>")
                    Response.Write("<br/>")
                    Response.Write("The first debit may be made on " & Session("frst_date") & " and at intervals after that. The debit amounts and dates may vary at any intervals.")

                ElseIf int_ScheduleTotal Mod 2 = 0 Then


                    Response.Write("<table>")
                    Response.Write("<tr>")
                    Response.Write("<td >")
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Response.Write("</td >")

                    Response.Write("<td valign='top'  style='font-size:16.5px'>")
                    For j As Integer = 0 To (int_ScheduleTotal / 2) - 1

                        nab_amt = ds_schedule.Tables(0).Rows(j).Item("Amount").ToString()
                        nab_amt = open_con.check_amount_format(Math.Round(nab_amt, 2))
                        nab_amt_new = open_con.new_amount(nab_amt)
                        Response.Write(nab_amt_new)
                        Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;")
                        nab_date = ds_schedule.Tables(0).Rows(j).Item("Due_Date").ToString()
                        nab_date_new = nab_date.ToString("dd/MM/yyyy")
                        Response.Write(nab_date_new)
                        first_date = ds_schedule.Tables(0).Rows(0).Item("Due_Date").ToString()
                        first_date_new = first_date.ToString("dd/MM/yyyy")
                        Session("frst_date") = first_date_new
                        Response.Write("<br/>")
                    Next
                    Response.Write("</td>")
                    Response.Write("<td >")
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Response.Write("</td >")
                    Response.Write("<td valign='top'  style='font-size:16.5px;width:20px'>")

                    For k As Integer = (int_ScheduleTotal / 2) To int_ScheduleTotal - 1

                        nab_amt = ds_schedule.Tables(0).Rows(k).Item("Amount").ToString()
                        nab_amt = open_con.check_amount_format(Math.Round(nab_amt, 2))
                        nab_amt_new = open_con.new_amount(nab_amt)
                        Response.Write(nab_amt_new)
                        Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;")
                        nab_date = ds_schedule.Tables(0).Rows(k).Item("Due_Date").ToString()
                        nab_date_new = nab_date.ToString("dd/MM/yyyy")
                        Response.Write(nab_date_new)
                        Response.Write("<br/>")
                    Next

                    Response.Write("</td>")
                    Response.Write("</tr>")
                    Response.Write("</table>")
                    Response.Write("<br/>")
                    Response.Write("The first debit may be made on " & Session("frst_date") & " and at intervals after that. The debit amounts and dates may vary at any intervals.")
                Else


                    Response.Write("<table>")
                    Response.Write("<tr>")
                    Response.Write("<td >")
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Response.Write("</td >")

                    Response.Write("<td valign='top'  style='font-size:16.5px'>")
                    For j As Integer = 0 To (int_ScheduleTotal - 1) / 2

                        nab_amt = ds_schedule.Tables(0).Rows(j).Item("Amount").ToString()
                        nab_amt = open_con.check_amount_format(Math.Round(nab_amt, 2))
                        nab_amt_new = open_con.new_amount(nab_amt)
                        Response.Write(nab_amt_new)
                        Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;")
                        nab_date = ds_schedule.Tables(0).Rows(j).Item("Due_Date").ToString()
                        nab_date_new = nab_date.ToString("dd/MM/yyyy")
                        Response.Write(nab_date_new)
                        first_date = ds_schedule.Tables(0).Rows(0).Item("Due_Date").ToString()
                        first_date_new = first_date.ToString("dd/MM/yyyy")
                        Session("frst_date") = first_date_new
                        Response.Write("<br/>")
                    Next
                    Response.Write("</td>")
                    Response.Write("<td >")
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Response.Write("</td >")
                    Response.Write("<td valign='top'  style='font-size:16.5px;width:20px'>")

                    For k As Integer = ((int_ScheduleTotal - 1) / 2) + 1 To int_ScheduleTotal - 1

                        nab_amt = ds_schedule.Tables(0).Rows(k).Item("Amount").ToString()
                        nab_amt = open_con.check_amount_format(Math.Round(nab_amt, 2))
                        nab_amt_new = open_con.new_amount(nab_amt)
                        Response.Write(nab_amt_new)
                        Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;")
                        nab_date = ds_schedule.Tables(0).Rows(k).Item("Due_Date").ToString()
                        nab_date_new = nab_date.ToString("dd/MM/yyyy")
                        Response.Write(nab_date_new)
                        Response.Write("<br/>")
                    Next

                    Response.Write("</td>")
                    Response.Write("</tr>")
                    Response.Write("</table>")
                    Response.Write("<br/>")
                    Response.Write("The first debit may be made on " & Session("frst_date") & " and at intervals after that. The debit amounts and dates may vary at any intervals.")
                End If

                Response.Write("<br/>")
                Response.Write("<br/>")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td valign='top' style='font-size:16.5px;width:240; border-left: 1.0pt solid windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in;height:140'>")

                Response.Write("<b style='font-size:16.5px'>Insert your signature and address</b>")
                Response.Write("</td>")
                Response.Write("<td colspan='2' valign='top' style='font-size:16.5px;width:680; border-left: medium none; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in;height:60'>")
                Response.Write("<br/>")
                Response.Write("<br/>")
                Response.Write("<b>Signature.......................................</b>")
                Response.Write("<br/>")
                Response.Write("<br/>")
                Response.Write("<b style='font-size:16.5px'>Address</b> " & ds_CustomerBank.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerBank.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_CustomerBank.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_CustomerBank.Tables(0).Rows(0).Item("State").ToString & " " & ds_CustomerBank.Tables(0).Rows(0).Item("Post_Code").ToString)
                Response.Write("<br/>")
                Response.Write("<br/>")
                Response.Write("<b>Date...............................................</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                Response.Write("<br/>")
                Response.Write("<br/>")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("</table>")

                Response.Write("&nbsp;&nbsp;&nbsp;     " & "Australian Credit Licence Number 391104")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




                ''''''''close connections
                cmd_bank_account_id.Dispose()
                cmd_newbank_account_id.Dispose()
                adap_bank_account_id.Dispose()

                ds_bank_account_id.Dispose()
                ds_newbank_account_id.Dispose()
                cmd_CustomerBank.Dispose()
                cmd_MoneyPlus.Dispose()
                cmd_loan.Dispose()
                cmd_schedule.Dispose()
                adap_CustomerBank.Dispose()
                adap_MoneyPlus.Dispose()
                adap_loan.Dispose()
                adap_schedule.Dispose()
                ds_CustomerBank.Dispose()
                ds_MoneyPlus.Dispose()
                ds_loan.Dispose()
                ds_schedule.Dispose()
                open_con.return_con.Dispose()

            Catch ex As Exception

                Response.Write("Error: " & ex.Message)
                open_con.return_con.Dispose()
            End Try
        End If
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
