Imports System.Data.SqlClient
Imports System.Data

Partial Class Customer_Print_PayrollRec
    Inherits System.Web.UI.Page
    Dim open_con As New Class1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try

                Dim prec_from_paydue As String
                Dim prec_to_paydue As String
                prec_from_paydue = Session("rec_from_pay")
                prec_to_paydue = Session("rec_to_pay")

                Dim new_from_paydue As DateTime
                Dim new_to_paydue As DateTime
                new_from_paydue = Date.Parse(prec_from_paydue)
                new_to_paydue = Date.Parse(prec_to_paydue)

                prec_from_paydue = new_from_paydue.ToString("dd-MMM-yyyy")
                prec_from_paydue = prec_from_paydue.Replace("-", " ")
                prec_to_paydue = new_to_paydue.ToString("dd-MMM-yyyy")
                prec_to_paydue = prec_to_paydue.Replace("-", " ")
                Dim cmd_pay_rec As New SqlCommand
                Dim adap_pay_rec As SqlDataAdapter
                Dim ds_pay_rec As New DataSet
                Dim str_pay_rec As String
                str_pay_rec = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Payment.Loan_ID, Tbl_Payment.Payment_Method, Tbl_Payment.Amount,  Tbl_Payment.Due_Date, Tbl_Payment.Payment_Date "
                str_pay_rec = str_pay_rec & " FROM Tbl_Customer INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Payment_ID) ON Tbl_Customer.Customer_ID = Tbl_Payment.Customer_ID "
                str_pay_rec = str_pay_rec & " WHERE (Tbl_Payment.Payment_Method='Sal') AND Tbl_Payment.Payment_Date>='" & Session("rec_from_pay") & "' And Tbl_Payment.Payment_Date<='" & Session("rec_to_pay") & "' AND (Tbl_Payment.Description='Arear notice fee' Or Tbl_Payment.Description='Statement of account fee' Or Tbl_Payment.Description='Variation fee' Or Tbl_Payment.Description='Default notice fee' Or Tbl_Payment.Description='Letter of demand fee' Or Tbl_Payment.Description='Dishonoured fee' Or Tbl_Payment.Description = 'Enforcement fee' Or Tbl_Payment.Description Is Null or Tbl_Payment.Description = '')"
                str_pay_rec = str_pay_rec & " ORDER BY Tbl_Payment.Payment_Method, Tbl_Payment.Payment_Date "
                cmd_pay_rec.CommandText = str_pay_rec

                cmd_pay_rec.Connection = open_con.return_con
                adap_pay_rec = New SqlDataAdapter(cmd_pay_rec)
                adap_pay_rec.Fill(ds_pay_rec)

                Response.Write("<body onload='window.print();' ondblClick='JavaScript:history.go(-1);'>")
                Response.Write("<div style='text-align:center'>")
                Response.Write("<span style='font-size:16px'><b>")
                Response.Write("View Payroll Deductions Report from ")
                Response.Write(prec_from_paydue)
                Response.Write(" to ")
                Response.Write(prec_to_paydue)
                Response.Write("</b></span>")
                Response.Write("</div>")
                Response.Write("<br/>")
                Response.Write("<div style='text-align:center'>")
                Response.Write("<table border='1' width='100%' style='font-size:16px;border:0 solid #FFFFFF; border-collapse: collapse' cellpadding='0' cellspacing='0' bordercolor='#C0C0C0'>")
                Response.Write("<tr>")
                Response.Write("<td  style='width:200;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Cust No</td>")
                Response.Write("<td  style='width:500;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Customer Name</td>")
                Response.Write("<td  style='width:200;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Loan No</td>")
                Response.Write("<td  style='width:200;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Due Date</td>")
                Response.Write("<td  style='width:200;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Payment Date</td>")
                Response.Write("<td  style='width:200;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Amount</td>")
                Response.Write("</tr>")

                Dim tot_payrec As Double
                For i As Integer = 0 To ds_pay_rec.Tables(0).Rows.Count - 1
                    Response.Write("<tr>")
                    Response.Write("<td style='text-align:left;width:300' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(Session("Branch_Prefix") & " " & CInt(ds_pay_rec.Tables(0).Rows(i).Item("Customer_ID").ToString))
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:left;width:500' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_pay_rec.Tables(0).Rows(i).Item("Given_Name").ToString & " " & ds_pay_rec.Tables(0).Rows(i).Item("Last_Name").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:center;width:200' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(CInt(ds_pay_rec.Tables(0).Rows(i).Item("Loan_ID").ToString))
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:center;width:250' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Dim payrec_duedate As DateTime
                    payrec_duedate = Date.Parse(ds_pay_rec.Tables(0).Rows(i).Item("Due_Date").ToString)
                    Dim new_payrec_duedate As String
                    new_payrec_duedate = payrec_duedate.ToString("dd-MMM-yyyy")
                    Response.Write(new_payrec_duedate.Replace("-", " "))
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:center;width:250' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Dim payrec_paydate As DateTime
                    payrec_paydate = Date.Parse(ds_pay_rec.Tables(0).Rows(i).Item("Payment_Date").ToString)
                    Dim new_payrec_paydate As String
                    new_payrec_paydate = payrec_paydate.ToString("dd-MMM-yyyy")
                    Response.Write(new_payrec_paydate.Replace("-", " "))
                    Response.Write("</td>")
                    Response.Write("<td style='text-align:right;width:200' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Dim amt_payrec As Double
                    amt_payrec = CDbl(ds_pay_rec.Tables(0).Rows(i).Item("Amount").ToString)
                    amt_payrec = open_con.check_amount_format(Math.Round(amt_payrec, 2))
                    Dim new_amt_payrec As String
                    new_amt_payrec = open_con.new_amount(amt_payrec)
                    tot_payrec = tot_payrec + amt_payrec
                    Response.Write(new_amt_payrec)
                    Response.Write("</td>")
                    Response.Write("</tr>")
                Next

                Response.Write("<tr>")
                Response.Write("<td  colspan='5' style='font-weight:bold;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write("Total:")
                Response.Write("</td>")
                Response.Write("<td style='font-weight:bold;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Dim new_tot_payrec As String
                new_tot_payrec = open_con.new_amount(tot_payrec)
                Response.Write(new_tot_payrec)
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("</table>")
                Response.Write("</div>")
                Response.Write("</body>")


                ''''''''''close all the connections
                open_con.return_con.Dispose()
                cmd_pay_rec.Dispose()
                adap_pay_rec.Dispose()
                ds_pay_rec.Dispose()

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
