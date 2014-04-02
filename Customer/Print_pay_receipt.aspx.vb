Imports System.Data.SqlClient
Imports System.Data

Partial Class Customer_Print_pay_receipt
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else

        End If

        Try

            If Page.IsPostBack = False Then

                Dim loanpay_id As Integer
                If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

                    loanpay_id = Session("beg_loan_id")

                ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                    loanpay_id = Session("beg_loan_id")

                ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                    loanpay_id = Session("cur_loan_id")

                ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                    loanpay_id = Session("cur_loan_id")

                ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                    loanpay_id = Session("beg_loan_id")

                ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False Then

                    loanpay_id = Session("cur_loan_id")

                End If



                Dim str_SQL, str_SQL1, str_SQL2, txtfromdt, txttodt As String

                Dim ds_Receipt, ds_CustomerAddress, ds_Branch_Detail As New DataSet
                Dim adap_Receipt, adap_CustomerAddress, adap_Branch_Detail As SqlDataAdapter
                Dim cmd_Receipt, cmd_CustomerAddress, cmd_Branch_Detail As New SqlCommand

                txtfromdt = Session("from_pay")
                txttodt = Session("to_pay")

                str_SQL = " SELECT Tbl_Payment.Loan_ID, Tbl_Payment.Amount, Tbl_Payment.Payment_Method, Tbl_Payment.Payment_Date "
                str_SQL = str_SQL & " FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID "
                str_SQL = str_SQL & " WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Cancellation fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND Tbl_Payment.Payment_Date is not NULL "
                str_SQL = str_SQL & " AND Tbl_Payment.Payment_Date >= '" & txtfromdt & "' AND  Tbl_Payment.Payment_Date <= '" & txttodt & "'"
                '  str_SQL = str_SQL & " AND Tbl_Payment.Loan_ID= '" & Session("pay_loan_id") & " 'AND Tbl_Payment.Amount <> 0 AND  Tbl_Payment_1.Update_ID Is Null ORDER BY  Tbl_Payment.Payment_Date "

                ' str_SQL = str_SQL & " AND Tbl_Payment.Loan_ID= '" & Session("pay_loan_id") & " 'AND Tbl_Payment.Amount <> 0 AND  Tbl_Payment_1.Update_ID Is Null ORDER BY  Tbl_Payment.Payment_Date "

                'change for dishhonor payment reciept
                str_SQL = str_SQL & " AND Tbl_Payment.Loan_ID= '" & Session("pay_loan_id") & " 'AND Tbl_Payment.Amount <> 0 AND  Tbl_Payment_1.Update_ID Is Null AND Tbl_Payment.Transaction_Status  IS NULL ORDER BY  Tbl_Payment.Payment_Date "

                cmd_Receipt.CommandText = str_SQL
                cmd_Receipt.Connection = open_con.return_con
                adap_Receipt = New SqlDataAdapter(cmd_Receipt)
                adap_Receipt.Fill(ds_Receipt)


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



                Response.Write("<table style='border-collapse: collapse; margin-left:.2in; border:1px solid gray;width:680' cellpadding='0' cellspacing='0'>")
                Response.Write("<tr>")
                Response.Write("<td valign='top' style='font-size: 18px; color: black; font-weight:bold; text-align: center;text-decoration:underline'>")
                Response.Write("Payment Receipt")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td >")
                Response.Write("&nbsp;")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td style='text-align:left'>")
                Response.Write("&nbsp;<img src='../Images/MPNoticeLogo.jpg' alt='logo' style='height: 90px; width:200px' />")
                Response.Write("</td>")
                Response.Write("</tr>")

                Response.Write("<tr>")
                Response.Write("<td  style='text-align:Right;font-size:15.5px'>")
                Response.Write("Abaz Pty Ltd A.C.N 118 434 021" & "&nbsp;")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td  style='text-align:Right;font-size:15.5px'>")
                Response.Write("c/-" & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Trading_Name").ToString & "&nbsp;")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td  style='text-align:Right;font-size:15.5px'>")
                Response.Write(ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_Branch_Detail.Tables(0).Rows(0).Item("Suburb").ToString & ", " & ds_Branch_Detail.Tables(0).Rows(0).Item("State").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Post_Code").ToString & "&nbsp;")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td  style='text-align:Right;font-size:15.5px'>")
                Response.Write("Tel: " & ds_Branch_Detail.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_Branch_Detail.Tables(0).Rows(0).Item("Fax_Number").ToString & "&nbsp;")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td  style='text-align:left;font-size:15.5px' >&nbsp;Date:&nbsp;")

                Dim day_loan_new, month_loan_new, year_loan, sup_string_new As String
                day_loan_new = Val(Left(System.DateTime.Now.Date, 2))
                sup_string_new = open_con.check_day(System.DateTime.Now.Day)
                month_loan_new = open_con.cal_short_month(System.DateTime.Now.Month)
                year_loan = System.DateTime.Now.Year
                Response.Write(day_loan_new & " " & month_loan_new & " " & year_loan)
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td >")
                Response.Write("&nbsp;")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td  style='text-align:Right;font-size:15.5px'>")
                Response.Write("<span style='font-weight:bold'>Payment receipt from " & "</span>" & txtfromdt.Replace("-", " ") & "<span style='font-weight:bold'>" & " To " & "</span>" & txttodt.Replace("-", " ") & "&nbsp;")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td  style='text-align:Right;font-size:15.5px'>")
                Response.Write("<span style='font-weight:bold'>Customer No: " & "</span>" & open_con.customer_id_val & "<span style='font-weight:bold'>" & " Loan No: " & "</span>" & loanpay_id & "&nbsp;")
                Response.Write("</td>")
                Response.Write("</tr>")

                Response.Write("<tr>")
                Response.Write("<td  style='text-align:Right;font-size:15.5px'>")
                Response.Write("<span style='font-weight:bold'>Total amount outstanding for this loan: " & "</span>" & Session("loanapp_outamt") & "&nbsp;")
                Response.Write("</td>")
                Response.Write("</tr>")

                Response.Write("<tr>")
                Response.Write("<td >")
                Response.Write("&nbsp;")
                Response.Write("</td>")
                Response.Write("</tr>")

                Response.Write("<tr>")
                Response.Write("<td  style='text-align:left;font-size:15.5px'>")
                Response.Write("&nbsp;" & ds_CustomerAddress.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("Last_Name").ToString)
                Response.Write("</td>")
                Response.Write("</tr>")

                Response.Write("<tr>")
                Response.Write("<td  style='text-align:left;font-size:15.5px'>")
                Response.Write("&nbsp;" & ds_CustomerAddress.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("Street_Name").ToString)
                Response.Write("</td>")
                Response.Write("</tr>")


                Response.Write("<tr>")
                Response.Write("<td  style='text-align:left;font-size:15.5px'>")
                Response.Write("&nbsp;" & ds_CustomerAddress.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("State").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("Post_Code").ToString)
                Response.Write("</td>")
                Response.Write("</tr>")

                Dim amt As Double
                Dim tot_amt As Double
                Dim amt_new, tot_amtnew As String
                Dim pay_date As DateTime
                Dim pay_datenew As String
                Dim pay_met As String

                If Not ds_Receipt.Tables(0).Rows.Count = 0 Then
                    Response.Write("<tr>")
                    Response.Write("<td>")
                    Response.Write("&nbsp;")
                    Response.Write("</td>")
                    Response.Write("</tr>")
                    Response.Write("<tr>")
                    Response.Write("<td>")
                    Response.Write("&nbsp;")
                    Response.Write("</td>")
                    Response.Write("</tr>")
                    Response.Write("<tr>")
                    Response.Write("<td>")
                    Response.Write("<div style='text-align:center'>")
                    Response.Write("<table border='1'style='border-collapse: collapse;border-color:#C0C0C0;width:670;height:38' cellpadding='0' cellspacing='0' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("<tr>")
                    Response.Write("<td style='text-align:center;font-weight:bold;width:250;height:20;font-size:15.5px' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Amount</td>")
                    Response.Write("<td style='text-align:center;font-weight:bold;width:350;height:20;font-size:15.5px' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Payment Received</td>")
                    Response.Write("<td style='text-align:center;font-weight:bold;width:350;height:20;font-size:15.5px' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Payment Method</td>")
                    Response.Write("</tr>")

                    For i As Integer = 0 To ds_Receipt.Tables(0).Rows.Count - 1

                        pay_date = Date.Parse(ds_Receipt.Tables(0).Rows(i).Item("Payment_Date").ToString)
                        pay_datenew = pay_date.ToString("dd-MMM-yyyy")
                        pay_datenew = pay_datenew.Replace("-", " ")
                        amt = ds_Receipt.Tables(0).Rows(i).Item("Amount").ToString()
                        amt = open_con.check_amount_format(Math.Round(amt, 2))
                        amt_new = open_con.new_amount(amt)
                        pay_met = ds_Receipt.Tables(0).Rows(i).Item("Payment_Method").ToString
                        If pay_met = "NAB" Or pay_met = "CBA" Then
                            pay_met = "Direct Debit"
                        ElseIf pay_met = "Cas" Then
                            pay_met = "Cash"
                        ElseIf pay_met = "Sal" Then
                            pay_met = "Salary deduction"
                        ElseIf pay_met = "Chq" Then
                            pay_met = "Cheque"
                        ElseIf pay_met = "Cre" Then
                            pay_met = "Credit"

                        End If
                        Response.Write("<tr>")
                        Response.Write("<td style='text-align:right;width:250;height:20;font-size:15.5px' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                        Response.Write(amt_new & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                        Response.Write("</td>")
                        Response.Write("<td style='text-align:center;width:350;height:20;font-size:15.5px' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                        Response.Write(pay_datenew)
                        Response.Write("</td>")
                        Response.Write("<td style='text-align:center;width:350;height:20;font-size:15.5px' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                        Response.Write(pay_met)
                        Response.Write("</td>")
                        Response.Write("</tr>")
                        tot_amt = tot_amt + amt
                    Next
                    tot_amt = open_con.check_amount_format(Math.Round(tot_amt, 2))
                    tot_amtnew = open_con.new_amount(tot_amt)
                    Response.Write("<tr>")
                    Response.Write("<td style='text-align:right;font-weight:bold;width:250;height:10;font-size:15.5px' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("Total: " & "&nbsp;" & tot_amtnew & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Response.Write("</td>")
                    Response.Write("<td colspan='2' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("&nbsp;")
                    Response.Write("</td>")
                    Response.Write("</tr>")

                    Response.Write("</table>")
                    Response.Write("<br/>")
                    Response.Write("</td>")
                    Response.Write("</tr>")

                End If

                Response.Write("</table>")
                '''''''''''''''''''close connections
                adap_Branch_Detail.Dispose()
                adap_CustomerAddress.Dispose()
                adap_Receipt.Dispose()
                cmd_Branch_Detail.Dispose()
                cmd_CustomerAddress.Dispose()
                cmd_Receipt.Dispose()
                ds_Branch_Detail.Dispose()
                ds_CustomerAddress.Dispose()
                ds_Receipt.Dispose()
                open_con.return_con.Dispose()
            End If

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
