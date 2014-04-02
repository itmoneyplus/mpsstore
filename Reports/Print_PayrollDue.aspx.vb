Imports System.Data
Imports System.Data.SqlClient
Partial Class Customer_Print_PayrollDue
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try


                Dim Print_from_paydue As String
                Dim Print_to_paydue As String
                Print_from_paydue = Session("from_pay_due")
                Print_to_paydue = Session("to_pay_due")
                Dim new_from_paydue As DateTime
                Dim new_to_paydue As DateTime
                new_from_paydue = Date.Parse(Print_from_paydue)
                new_to_paydue = Date.Parse(Print_to_paydue)
                Print_from_paydue = new_from_paydue.ToString("dd-MMM-yyyy")
                Print_from_paydue = Print_from_paydue.Replace("-", " ")
                Print_to_paydue = new_to_paydue.ToString("dd-MMM-yyyy")
                Print_to_paydue = Print_to_paydue.Replace("-", " ")

                Dim cmd_pay_due As New SqlCommand
                Dim adap_pay_due As SqlDataAdapter
                Dim ds_pay_due As New DataSet
                Dim str_pay_due As String




                str_pay_due = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Customer.Employer, Tbl_Customer.Payroll_Transfer, Tbl_Payment.Payment_ID, Tbl_Payment.Loan_ID, Tbl_Payment.Payment_Method, Tbl_Payment.Amount, Tbl_Payment.Due_Date "
                str_pay_due = str_pay_due & " FROM (Tbl_Customer INNER JOIN Tbl_Loan ON Tbl_Customer.Customer_ID = Tbl_Loan.Customer_ID) INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID) ON Tbl_Loan.Loan_ID = Tbl_Payment.Loan_ID "
                str_pay_due = str_pay_due & " WHERE (Tbl_Payment.Payment_Method='Sal' And Tbl_Payment_1.Update_ID Is NULL AND Tbl_Loan.Status = '1' AND Tbl_Payment.Transaction_Status is NULL AND (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' Or Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description='') AND Tbl_Payment.Amount <> 0 AND Tbl_Payment.Payment_Date Is NULL AND Tbl_Payment.Due_Date >='" & Session("from_pay_due") & "' AND Tbl_Payment.Due_Date <='" & Session("to_pay_due") & "')"
                str_pay_due = str_pay_due & " ORDER BY Tbl_Payment.Payment_Method,  Tbl_Payment.Due_Date, Tbl_Customer.Customer_ID"
                cmd_pay_due.CommandText = str_pay_due
                cmd_pay_due.Connection = open_con.return_con
                adap_pay_due = New SqlDataAdapter(cmd_pay_due)
                adap_pay_due.Fill(ds_pay_due)

                Response.Write("<body onload='window.print();' ondblClick='JavaScript:history.go(-1);'>")
                Response.Write("<div style='text-align:center'>")
                Response.Write("<table border='1' width='100%' style='font-size:16px;border:0 solid #FFFFFF; border-collapse: collapse' cellpadding='0' cellspacing='0' bordercolor='#C0C0C0'>")
                Response.Write("<tr>")
                Response.Write("<td style='text-align:center;font-weight:bold'>")
                Response.Write("Payroll Deductions Due Report from " & Print_from_paydue & " to " & Print_to_paydue)
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("</table>")
                Response.Write("</div>")
                Response.Write("<div style='text-align:center'>")
                Response.Write("<table border='1' width='100%' style='font-size:16px;border:0 solid #FFFFFF; border-collapse: collapse' cellpadding='0' cellspacing='0' bordercolor='#C0C0C0'>")
                Response.Write("<tr>")
                Response.Write("<td bgcolor='#EFEFEF' style='text-align:center;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>S</td>")
                Response.Write("<td  style='width:300;text-align:center;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Cust No</td>")
                Response.Write("<td  style='width:400;text-align:center;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Customer Name</td>")
                Response.Write("<td  style='width:400;text-align:center;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Employer</td>")
                Response.Write("<td  style='width:500;text-align:center;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Transfer Reference</td>")
                Response.Write("<td  style='width:300;text-align:center;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Loan No</td>")
                Response.Write("<td  style='width:400;text-align:center;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Due Date</td>")
                Response.Write("<td  style='width:150;text-align:center;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Amount</td>")
                Response.Write("</tr>")

                Dim tot_paydue As Double

                For i As Integer = 0 To ds_pay_due.Tables(0).Rows.Count - 1

                    Response.Write("<tr>")
                    Response.Write("<td style='text-align:center' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("<input type='checkbox'/>")
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:center;width:200' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(CInt(ds_pay_due.Tables(0).Rows(i).Item("Customer_ID").ToString))
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:left;width:500' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_pay_due.Tables(0).Rows(i).Item("Given_Name").ToString & " " & ds_pay_due.Tables(0).Rows(i).Item("Last_Name").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:left;width:500' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_pay_due.Tables(0).Rows(i).Item("Employer").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:center;width:350' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_pay_due.Tables(0).Rows(i).Item("Payroll_Transfer").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:center;width:300' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(CInt(ds_pay_due.Tables(0).Rows(i).Item("Loan_ID").ToString))
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:center;width:500' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Dim paydue_date As DateTime
                    paydue_date = Date.Parse(ds_pay_due.Tables(0).Rows(i).Item("Due_Date").ToString)
                    Dim new_paydue_date As String
                    new_paydue_date = paydue_date.ToString("dd-MMM-yyyy")
                    Response.Write(new_paydue_date.Replace("-", " "))
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:right;width:150' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Dim amt_paydue As Double
                    amt_paydue = CDbl(ds_pay_due.Tables(0).Rows(i).Item("Amount").ToString)
                    amt_paydue = open_con.check_amount_format(Math.Round(amt_paydue, 2))
                    Dim new_amt_paydue As String
                    new_amt_paydue = open_con.new_amount(amt_paydue)
                    tot_paydue = tot_paydue + amt_paydue
                    Response.Write(new_amt_paydue)
                    Response.Write("</td>")
                    Response.Write("</tr>")
                Next

                Response.Write("<tr>")
                Response.Write("<td  colspan='7' style='font-weight:bold;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write("Total:")
                Response.Write("</td>")
                Response.Write("<td style='font-weight:bold;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                tot_paydue = open_con.check_amount_format(Math.Round(tot_paydue, 2))
                Dim new_tot_paydue As String
                new_tot_paydue = open_con.new_amount(tot_paydue)
                Response.Write(new_tot_paydue)
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("</table>")
                Response.Write("</div>")
                Response.Write("</body>")
                Session("tot_paydue") = tot_paydue
                ''''close connections
                open_con.return_con.Dispose()
                cmd_pay_due.Dispose()
                ds_pay_due.Dispose()
                adap_pay_due.Dispose()
            Catch ex As Exception
                Response.Write("Error: " & ex.Message)
            End Try
        End If

    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
