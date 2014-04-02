Imports System.Data
Imports System.Data.SqlClient
Partial Class Customer_Print_CreditDue
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try


                Dim Print_from_Credit As String
                Dim Print_to_Credit As String
                Print_from_Credit = Session("from_Credit")
                Print_to_Credit = Session("to_Credit")
                Dim new_from_Credit As DateTime
                Dim new_to_Credit As DateTime
                new_from_Credit = Date.Parse(Print_from_Credit)
                new_to_Credit = Date.Parse(Print_to_Credit)
                Print_from_Credit = new_from_Credit.ToString("dd-MMM-yyyy")
                Print_from_Credit = Print_from_Credit.Replace("-", " ")
                Print_to_Credit = new_to_Credit.ToString("dd-MMM-yyyy")
                Print_to_Credit = Print_to_Credit.Replace("-", " ")

                Dim cmd_due As New SqlCommand
                Dim adap_due As SqlDataAdapter
                Dim ds_due As New DataSet
                Dim str_due As String

                str_due = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Customer.Employer, Tbl_Customer.Payroll_Transfer, Tbl_Payment.Payment_ID, Tbl_Payment.Loan_ID, Tbl_Payment.Payment_Method, Tbl_Payment.Amount, Tbl_Payment.Due_Date "
                str_due = str_due & " FROM (Tbl_Customer INNER JOIN Tbl_Loan ON Tbl_Customer.Customer_ID = Tbl_Loan.Customer_ID) INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID ) ON Tbl_Loan.Loan_ID = Tbl_Payment.Loan_ID "
                str_due = str_due & " WHERE (Tbl_Payment.Payment_Method='Cre' AND Tbl_Payment_1.Update_ID Is NULL AND Tbl_Loan.Status = '1' AND Tbl_Payment.Transaction_Status is NULL AND (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description='')  AND Tbl_Payment.Amount <> 0 AND Tbl_Payment.Payment_Date Is NULL AND Tbl_Payment.Due_Date >='" & Print_from_Credit & "' AND Tbl_Payment.Due_Date <='" & Print_to_Credit & "')"
                str_due = str_due & " ORDER BY Tbl_Payment.Payment_Method,  Tbl_Payment.Due_Date, Tbl_Customer.Customer_ID"
                cmd_due.CommandText = str_due
                cmd_due.Connection = open_con.return_con
                adap_due = New SqlDataAdapter(cmd_due)
                adap_due.Fill(ds_due)

                Response.Write("<body onload='window.print();' ondblClick='JavaScript:history.go(-1);'>")
                Response.Write("<div style='text-align:center'>")
                Response.Write("<table border='1' width='100%' style='font-size:16px;border:0 solid #FFFFFF; border-collapse: collapse' cellpadding='0' cellspacing='0' bordercolor='#C0C0C0'>")
                Response.Write("<tr>")
                Response.Write("<td style='text-align:center;font-weight:bold'>")
                Response.Write("Credit Due Report from ")
                Response.Write(Print_from_Credit)
                Response.Write(" to ")
                Response.Write(Print_to_Credit)
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("</table>")
                Response.Write("</div>")
                Response.Write("<div style='text-align:center'>")
                Response.Write("<table border='1' width='100%' style='font-size:16px;border:0 solid #FFFFFF; border-collapse: collapse' cellpadding='0' cellspacing='0' bordercolor='#C0C0C0'>")
                Response.Write("<tr>")
                Response.Write("<td bgcolor='#EFEFEF' style='text-align:center;font-weight:bold' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>S</td>")
                Response.Write("<td  style='width:300;text-align:center;font-weight:bold'  bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Cust No</td>")
                Response.Write("<td  style='width:500;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Customer Name</td>")
                Response.Write("<td  style='width:500;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Transfer Reference</td>")
                Response.Write("<td  style='width:300;text-align:center;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Loan No</td>")
                Response.Write("<td  style='width:400;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Due Date</td>")
                Response.Write("<td  style='width:200;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Amount</td>")
                Response.Write("</tr>")

                Dim tot_creditdue As Double

                For i As Integer = 0 To ds_due.Tables(0).Rows.Count - 1
                    Response.Write("<tr>")
                    Response.Write("<td style='text-align:center' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write("<input type='checkbox'/>")
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:center;width:200' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(CInt(ds_due.Tables(0).Rows(i).Item("Customer_ID").ToString))
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:left;width:500' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_due.Tables(0).Rows(i).Item("Given_Name").ToString & " " & ds_due.Tables(0).Rows(i).Item("Last_Name").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:center;width:500' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_due.Tables(0).Rows(i).Item("Payroll_Transfer").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:center;width:300' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(CInt(ds_due.Tables(0).Rows(i).Item("Loan_ID").ToString))
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:center' width='300' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Dim creditdue_date As DateTime
                    creditdue_date = Date.Parse(ds_due.Tables(0).Rows(i).Item("Due_Date").ToString)
                    Dim new_creditdue_date As String
                    new_creditdue_date = creditdue_date.ToString("dd-MMM-yyyy")
                    Response.Write(new_creditdue_date.Replace("-", " "))
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:right;width:200' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Dim amt_creditdue As Double
                    amt_creditdue = CDbl(ds_due.Tables(0).Rows(i).Item("Amount").ToString)
                    amt_creditdue = open_con.check_amount_format(Math.Round(amt_creditdue, 2))
                    Dim new_amt_creditdue As String
                    new_amt_creditdue = open_con.new_amount(amt_creditdue)
                    tot_creditdue = tot_creditdue + amt_creditdue
                    Response.Write(new_amt_creditdue)
                    Response.Write("</td>")
                    Response.Write("</tr>")
                Next

                Response.Write("<tr>")
                Response.Write("<td  colspan='6' style='font-weight:bold;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write("Total:")
                Response.Write("</td>")
                Response.Write("<td style='font-weight:bold;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                tot_creditdue = open_con.check_amount_format(Math.Round(tot_creditdue, 2))
                Dim new_tot_creditdue As String
                new_tot_creditdue = open_con.new_amount(tot_creditdue)
                Response.Write(new_tot_creditdue)
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("</table>")
                Response.Write("</div>")
                Response.Write("</body>")
                ''''close connections
                open_con.return_con.Dispose()
                cmd_due.Dispose()
                ds_due.Dispose()
                adap_due.Dispose()

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
