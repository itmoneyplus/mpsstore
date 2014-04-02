Imports System.Data.SqlClient
Imports System.Data

Partial Class Customer_Pay_Schedule
    Inherits System.Web.UI.Page

    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Dim pay_sch_loanid As Integer

            If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
                pay_sch_loanid = Session("beg_loan_id")

            ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                pay_sch_loanid = Session("beg_loan_id")

            ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                pay_sch_loanid = Session("cur_loan_id")

            ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                pay_sch_loanid = Session("cur_loan_id")

            ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                pay_sch_loanid = Session("beg_loan_id")

            ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False Then

                pay_sch_loanid = Session("cur_loan_id")
            End If

            Dim str_SQL_paysch As String
            Dim payschfrom, payschto As String

            payschfrom = Session("payschfrom")
            payschto = Session("payschto")

            If payschfrom = "" And payschto = "" Then

                str_SQL_paysch = "select MAX(due_date),min(Due_date) from Tbl_Payment where loan_id =" & pay_sch_loanid
                Dim cmd As New SqlCommand
                Dim ds As New DataSet
                Dim adap As New SqlDataAdapter
                cmd.CommandText = str_SQL_paysch
                cmd.Connection = open_con.return_con
                adap = New SqlDataAdapter(cmd)
                adap.Fill(ds)

                payschfrom = ds.Tables(0).Rows(0).Item(1).ToString
                payschto = ds.Tables(0).Rows(0).Item(0).ToString

                payschfrom = Date.Parse(payschfrom).ToString("yyyy-MM-dd")
                payschto = Date.Parse(payschto).ToString("yyyy-MM-dd")

                cmd.Dispose()
                ds.Dispose()
                adap.Dispose()



                str_SQL_paysch = " SELECT Tbl_Payment.Loan_ID, Tbl_Payment.Amount, Tbl_Payment.Payment_Method, Tbl_Payment.Due_Date "
                str_SQL_paysch = str_SQL_paysch & " FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID "
                str_SQL_paysch = str_SQL_paysch & " WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Cancellation fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND Tbl_Payment.Transaction_Status is null AND Tbl_Payment.Payment_Date is NULL "

                If Trim(payschfrom) <> "" And Trim(payschto) <> "" Then
                    str_SQL_paysch = str_SQL_paysch & " AND Tbl_Payment.Due_Date >= '" & payschfrom & "' AND Tbl_Payment.Due_Date <= '" & payschto & "'"
                    str_SQL_paysch = str_SQL_paysch & " AND Tbl_Payment.Loan_ID= " & pay_sch_loanid & " AND Tbl_Payment.Amount <> 0 AND Tbl_Payment_1.Update_ID Is Null ORDER BY  Tbl_Payment.Due_Date "
                Else
                    str_SQL_paysch = str_SQL_paysch & " AND Tbl_Payment.Loan_ID= " & pay_sch_loanid & " AND Tbl_Payment.Amount <> 0 AND Tbl_Payment_1.Update_ID Is Null ORDER BY  Tbl_Payment.Due_Date "
                End If
            Else
                payschfrom = Date.Parse(payschfrom).ToString("yyyy-MM-dd")
                payschto = Date.Parse(payschto).ToString("yyyy-MM-dd")
                str_SQL_paysch = " SELECT Tbl_Payment.Loan_ID, Tbl_Payment.Amount, Tbl_Payment.Payment_Method, Tbl_Payment.Due_Date "
                str_SQL_paysch = str_SQL_paysch & " FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID "
                str_SQL_paysch = str_SQL_paysch & " WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Cancellation fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND Tbl_Payment.Transaction_Status is null AND Tbl_Payment.Payment_Date is NULL "

                If Trim(payschfrom) <> "" And Trim(payschto) <> "" Then
                    str_SQL_paysch = str_SQL_paysch & " AND Tbl_Payment.Due_Date >= '" & payschfrom & "' AND Tbl_Payment.Due_Date <= '" & payschto & "'"
                    str_SQL_paysch = str_SQL_paysch & " AND Tbl_Payment.Loan_ID= " & pay_sch_loanid & " AND Tbl_Payment.Amount <> 0 AND Tbl_Payment_1.Update_ID Is Null ORDER BY  Tbl_Payment.Due_Date "
                Else
                    str_SQL_paysch = str_SQL_paysch & " AND Tbl_Payment.Loan_ID= " & pay_sch_loanid & " AND Tbl_Payment.Amount <> 0 AND Tbl_Payment_1.Update_ID Is Null ORDER BY  Tbl_Payment.Due_Date "
                End If
            End If

            Dim cmd_Customerpaysch As New SqlCommand
            Dim ds_Customerpaysch As New DataSet
            Dim adap_Customerpaysch As SqlDataAdapter

            cmd_Customerpaysch.CommandText = str_SQL_paysch
            cmd_Customerpaysch.Connection = open_con.return_con
            adap_Customerpaysch = New SqlDataAdapter(cmd_Customerpaysch)
            adap_Customerpaysch.Fill(ds_Customerpaysch)

            Dim str_SQL As String
            Dim cmd_Customer As New SqlCommand
            Dim ds_Customer As New DataSet
            Dim adap_Customer As SqlDataAdapter





            str_SQL = " SELECT * FROM Tbl_Customer WHERE Customer_ID = " & open_con.customer_id_val

            cmd_Customer.CommandText = str_SQL
            cmd_Customer.Connection = open_con.return_con
            adap_Customer = New SqlDataAdapter(cmd_Customer)
            adap_Customer.Fill(ds_Customer)


            Dim cmd_Branch_Detail As New SqlCommand
            Dim ds_Branch_Detail As New DataSet
            Dim adap_Branch_Detail As SqlDataAdapter

            str_SQL = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val

            cmd_Branch_Detail.CommandText = str_SQL
            cmd_Branch_Detail.Connection = open_con.return_con
            adap_Branch_Detail = New SqlDataAdapter(cmd_Branch_Detail)
            adap_Branch_Detail.Fill(ds_Branch_Detail)

            Dim str_SQL_Bank As String

            If Session("beg_status") = "" Then

                str_SQL_Bank = " SELECT Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.Bank_Name, Tbl_Bank_Account.BSB "
                str_SQL_Bank = str_SQL_Bank & " FROM Tbl_Bank_Account INNER JOIN Tbl_Customer ON Tbl_Bank_Account.Bank_Account_ID = Tbl_Customer.Bank_Account_ID and Tbl_Customer.Customer_ID =" & open_con.customer_id_val


            ElseIf Session("beg_status") = "Pending" Then

                str_SQL_Bank = " SELECT Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.Bank_Name, Tbl_Bank_Account.BSB "
                str_SQL_Bank = str_SQL_Bank & " FROM Tbl_Bank_Account INNER JOIN Tbl_Customer ON Tbl_Bank_Account.Bank_Account_ID = Tbl_Customer.Bank_Account_ID  and Tbl_Customer.Customer_ID =" & open_con.customer_id_val

            Else

                str_SQL_Bank = " SELECT Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.Bank_Name, Tbl_Bank_Account.BSB "
                str_SQL_Bank = str_SQL_Bank & " FROM Tbl_Bank_Account INNER JOIN Tbl_Loan ON Tbl_Bank_Account.Bank_Account_ID = Tbl_Loan.Bank_Account_ID "
                str_SQL_Bank = str_SQL_Bank & " WHERE Tbl_Loan.Loan_ID = " & pay_sch_loanid

            End If


            Dim cmd_bank As New SqlCommand
            Dim ds_bank As New DataSet
            Dim adap_bank As SqlDataAdapter

            cmd_bank.CommandText = str_SQL_Bank
            cmd_bank.Connection = open_con.return_con
            adap_bank = New SqlDataAdapter(cmd_bank)
            adap_bank.Fill(ds_bank)
            Dim str_Bank_Name, str_BSB, str_Account_Number As String
            Dim str As String
            str = ds_bank.Tables(0).Rows.Count
            If Not Val(str) = 0 Then
                str_Bank_Name = ds_bank.Tables(0).Rows(0).Item("Bank_Name").ToString
                Session("str_Bank_Name") = str_Bank_Name
                str_BSB = ds_bank.Tables(0).Rows(0).Item("BSB").ToString
                Session("str_BSB") = str_BSB
                str_Account_Number = ds_bank.Tables(0).Rows(0).Item("Account_Number").ToString
                Session("str_Account_Number") = str_Account_Number
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Nominate the bank Account" & "');", True)
                str_Bank_Name = 0
                Session("str_Bank_Name") = 0
                str_BSB = 0
                Session("str_BSB") = 0
                str_Account_Number = 0
                Session("str_Account_Number") = 0
            End If


            Dim str_ACLN As String
            str_ACLN = "Australian Credit Licence Number 391104"

            Response.Write("<table style='border-collapse: collapse; margin-left:.8in; width:610;height:220' cellpadding='0' cellspacing='0'>")
            Response.Write("<tr>")
            Response.Write("<td>")

            Response.Write("<p class='MsoNormal_p_contract_new' style='text-align: center'><b>")
            Response.Write("<span lang='EN-AU' style='font-size: 19px; color: black'>")
            Response.Write("Payment Schedule ")
            Response.Write("</span></b></p>")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td>")
            Response.Write(" <img src='../Images/MPNoticeLogo.jpg' alt='logo' style='height:110px; width: 200px'/>")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:Right'>")
            Response.Write(str_ACLN)
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:Right'>")
            Response.Write("Abaz Pty Ltd A.C.N 118 434 021")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:Right'>")
            Response.Write("c/-" & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Trading_Name").ToString)
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:Right'>")
            Response.Write(ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_Branch_Detail.Tables(0).Rows(0).Item("Suburb").ToString & ", " & ds_Branch_Detail.Tables(0).Rows(0).Item("State").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Post_Code").ToString)
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:Right'>")
            Response.Write("Tel: " & ds_Branch_Detail.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_Branch_Detail.Tables(0).Rows(0).Item("Fax_Number").ToString)
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:Left'>")
            Response.Write("<b>Date:</b>")

            Dim day_loan_new, month_loan_new, year_loan As String
            day_loan_new = Val(Left(System.DateTime.Now.Date, 2))

            month_loan_new = open_con.check_month(System.DateTime.Now.Month)
            year_loan = System.DateTime.Now.Year
            Response.Write(day_loan_new & " " & month_loan_new & " " & year_loan)
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:Right'>")
            Response.Write("<b>Customer No:</b>")
            Response.Write(open_con.customer_id_val & "&nbsp;")
            Response.Write("<b>Loan No:</b>")
            Response.Write(pay_sch_loanid)
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:Right'>")
            Response.Write("<b>Total amount outstanding for this loan:</b>")

            ''''''''''''''''''''''''''''''''''''''

            Dim int_Total As Single = 0

            For i As Integer = 0 To ds_Customerpaysch.Tables(0).Rows.Count - 1


                int_Total = int_Total + ds_Customerpaysch.Tables(0).Rows(i).Item("Amount")

            Next


            '''''''''''''''''''''''''

            Dim new_total2 As String
            new_total2 = change_format_new(Math.Round((CDbl(int_Total)), 2))
            Session("new_total2") = new_total2
            Response.Write("$" & new_total2 & "&nbsp;")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("</table>")
            Response.Write("<br/>")
            Response.Write("<table style='border-collapse: collapse; margin-left:.8in; width:610;height:50px' cellpadding='0' cellspacing='0'>")

            Response.Write("<tr>")
            Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:left'>")
            Response.Write(ds_Customer.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_Customer.Tables(0).Rows(0).Item("Last_Name").ToString)
            Response.Write("</td>")
            Response.Write("<td  style='text-align:left'>")
            Response.Write("&nbsp;<b>Bank:</b>" & " " & Session("str_Bank_Name"))
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")

            Dim unit_no As String
            unit_no = ds_Customer.Tables(0).Rows(0).Item("Unit_No").ToString
            If Len(unit_no) = 0 Then
                Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:left'>")
                Response.Write(ds_Customer.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Customer.Tables(0).Rows(0).Item("Street_Name").ToString)
                Response.Write("</td>")
            Else
                Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:left'>")
                Response.Write(ds_Customer.Tables(0).Rows(0).Item("Unit_No").ToString & "/" & ds_Customer.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Customer.Tables(0).Rows(0).Item("Street_Name").ToString)
                Response.Write("</td>")

            End If

            Response.Write("<td  style='text-align:left'>")
            Response.Write("&nbsp;<b>BSB:</b>" & " " & Session("str_BSB"))
            Response.Write("</td>")
            Response.Write("</tr>")

            Response.Write("<tr>")
            Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:left'>")
            Response.Write(ds_Customer.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_Customer.Tables(0).Rows(0).Item("State").ToString & " " & ds_Customer.Tables(0).Rows(0).Item("Post_Code").ToString)
            Response.Write("</td>")
            Response.Write("<td  style='text-align:left'>")
            Response.Write("&nbsp;<b>ACC:</b>" & " " & Session("str_Account_Number"))
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td class='MsoNormal_p_contract_new' style='text-align:left'>")
            Response.Write("&nbsp;")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("</table>")
            Response.Write("<table border='1' width='630'  style='margin-left:.6in;border-collapse: collapse' bordercolor='#C0C0C0' cellpadding='0' cellspacing='0' height='10' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0' >")
            Response.Write("<tr>")
            Response.Write("<td bgcolor='#EFEFEF' style='text-align:center;width:200;height:10;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Amount</td>")
            Response.Write("<td bgcolor='#EFEFEF' style='text-align:center;width:150;height:10;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Payment Due On</td>")
            Response.Write("<td bgcolor='#EFEFEF' style='text-align:center;width:200;height:10;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Payment Method</td>")

            Response.Write("</tr>")

            Dim str_Method As String


            For i As Integer = 0 To ds_Customerpaysch.Tables(0).Rows.Count - 1
                Response.Write("<tr>")
                If ds_Customerpaysch.Tables(0).Rows(i).Item("Payment_Method").ToString = "NAB" Or ds_Customerpaysch.Tables(0).Rows(i).Item("Payment_Method").ToString = "CBA" Then
                    str_Method = "Direct Debit"
                    Session("str_Method") = str_Method
                ElseIf ds_Customerpaysch.Tables(0).Rows(i).Item("Payment_Method").ToString = "Cas" Then
                    str_Method = "Cash"
                    Session("str_Method") = str_Method
                ElseIf ds_Customerpaysch.Tables(0).Rows(i).Item("Payment_Method").ToString = "Sal" Then
                    str_Method = "Salary deduction"
                    Session("str_Method") = str_Method
                ElseIf ds_Customerpaysch.Tables(0).Rows(i).Item("Payment_Method").ToString = "Chq" Then
                    str_Method = "Cheque"
                    Session("str_Method") = str_Method
                ElseIf ds_Customerpaysch.Tables(0).Rows(i).Item("Payment_Method").ToString = "HOD" Then
                    str_Method = "On Hold"
                    Session("str_Method") = str_Method
                ElseIf ds_Customerpaysch.Tables(0).Rows(i).Item("Payment_Method").ToString = "WOF" Then
                    str_Method = "Written-Off"
                    Session("str_Method") = str_Method
                ElseIf ds_Customerpaysch.Tables(0).Rows(i).Item("Payment_Method").ToString = "Def" Then
                    str_Method = "Default"
                    Session("str_Method") = str_Method
                ElseIf ds_Customerpaysch.Tables(0).Rows(i).Item("Payment_Method").ToString = "Cre" Then
                    str_Method = "Credit"
                    Session("str_Method") = str_Method

                End If

                int_Total = Math.Round(CDbl(ds_Customerpaysch.Tables(0).Rows(i).Item("Amount")), 2)
                Dim new_total1_new As String
                new_total1_new = change_format_new(int_Total)
                If Len(new_total1_new) = 4 Then
                    Response.Write("<td  style='width:200;height:10' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & "$&nbsp;&nbsp;&nbsp;&nbsp;" & new_total1_new)
                    Response.Write("</td>")
                ElseIf Len(new_total1_new) = 5 Then
                    Response.Write("<td  style='width:200;height:10' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & "$&nbsp;&nbsp;" & new_total1_new)
                    Response.Write("</td>")
                ElseIf Len(new_total1_new) = 6 Then
                    Response.Write("<td  style='width:200;height:10' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & "$" & new_total1_new)
                    Response.Write("</td>")
                ElseIf Len(new_total1_new) = 7 Then
                    Response.Write("<td  style='width:200;height:10' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & "$" & new_total1_new)
                    Response.Write("</td>")
                End If

                Response.Write("<td style='text-align:center;width:150;height:10' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Dim due_date As Date
                due_date = ds_Customerpaysch.Tables(0).Rows(i).Item("Due_Date").ToString
                Response.Write(due_date.ToString("dd-MMM-yyyy").Replace("-", " "))
                Response.Write("</td>")
                Response.Write("<td style='text-align:center;width:200;height:10' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write(Session("str_Method"))
                Response.Write("</td>")
                Response.Write("</tr>")
            Next

            If Len(Session("new_total2")) = 7 Then
                Response.Write("<tr>")

                Response.Write("<td style='width:200;height:10;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><span style='text-align:left'>&nbsp;&nbsp;&nbsp;&nbsp;Total:" & "&nbsp;&nbsp;$" & Session("new_total2") & "</td>")
                Response.Write("<td  style='text-align:center;width:150;height:10;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'></td>")
                Response.Write("<td  style='text-align:center;width:200;height:10;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'></td>")
                Response.Write("</tr>")
            Else
                Response.Write("<tr>")
                Response.Write("<td style='width:200;height:10;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><span style='text-align:left'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total:" & "&nbsp;&nbsp;$" & Session("new_total2") & "</td>")
                Response.Write("<td  style='text-align:center;width:150;height:10;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'></td>")
                Response.Write("<td  style='text-align:center;width:200;height:10;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'></td>")
                Response.Write("</tr>")

            End If

            Response.Write("</table>")
            '''''''''''''''''''''''''''''''''''''''''''''''''''




        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

      
    End Sub

    Function change_format_new(ByVal int_Total As Single) As String

        Dim int_total1, new_total2, new_total1 As String
        int_total1 = CStr(int_Total)
        '''''''''''''''''''find position of (.)
        Dim pos_int_Total1 As Integer
        pos_int_Total1 = InStr(1, int_total1, ".")
        If pos_int_Total1 = 0 Then
            new_total2 = int_total1 & ".00"
            Return new_total2
        Else
            '''''''''''finding the starting part

            new_total1 = Mid(int_total1, 1, pos_int_Total1 - 1)
            '''''''''''''''finding the ending part

            new_total2 = Mid(int_total1, pos_int_Total1, int_total1.Length)

            If Len(new_total2) = 2 Then
                new_total2 = new_total1 & new_total2 & "0"
                Return new_total2
            ElseIf Len(new_total2) > 2 Then

                Dim pos_int_Total2 As Integer
                pos_int_Total2 = InStr(1, new_total2, ".")

                Dim new_amt As String
                new_amt = Mid(new_total2, pos_int_Total2 + 1, 2)



                new_total2 = new_total1 & "." & new_amt

                Return new_total2
            Else
                new_total2 = new_total1 & "." & new_total2
                Return new_total2
            End If
        End If


    End Function
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
