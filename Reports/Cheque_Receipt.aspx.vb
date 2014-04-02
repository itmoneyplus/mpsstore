Imports System.Data
Imports System.Data.SqlClient
Partial Class Reports_Cheque_Receipt
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
          
            Dim Cheque_Cashing_ID As Integer
            Cheque_Cashing_ID = Request("Cheque_Cashing_ID")
            If Cheque_Cashing_ID <> 0 Then
                Session("Cheque_Cashing_ID") = Cheque_Cashing_ID
            End If

            If Cheque_Cashing_ID = 0 Then
                Cheque_Cashing_ID = Session("Cheque_Cashing_ID")
            End If
            Dim str_SQL, str_SQL1, str_SQL2 As String
            Dim ds_CustomerAddress, ds_Branch_Detail, ds_receipt As New DataSet
            Dim adap_CustomerAddress, adap_Branch_Detail, adap_receipt As SqlDataAdapter
            Dim cmd_CustomerAddress, cmd_Branch_Detail, cmd_receipt As New SqlCommand

            str_SQL = "Select * from Tbl_Cheque_Cashing Where Cheque_Cashing_ID =" & Cheque_Cashing_ID
            cmd_receipt.CommandText = str_SQL
            cmd_receipt.Connection = open_con.return_con
            adap_receipt = New SqlDataAdapter(cmd_receipt)
            adap_receipt.Fill(ds_receipt)

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



            Response.Write("<table style='border-collapse: collapse; margin-left:.5in; border:0px solid gray;width:580' cellpadding='0' cellspacing='0'>")

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
            Response.Write("<td  style='text-align:Right;font-size:16.5px'>")
            Response.Write(ds_Branch_Detail.Tables(0).Rows(0).Item("Company_Name").ToString & " (ABN " & ds_Branch_Detail.Tables(0).Rows(0).Item("ACN").ToString & ")")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td  style='text-align:Right;font-size:16.5px'>")
            Response.Write("T/As" & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Trading_Name").ToString & "&nbsp;")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td  style='text-align:Right;font-size:16.5px'>")
            Response.Write(ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_Branch_Detail.Tables(0).Rows(0).Item("Suburb").ToString & ", " & ds_Branch_Detail.Tables(0).Rows(0).Item("State").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Post_Code").ToString & "&nbsp;")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td  style='text-align:Right;font-size:16.5px'>")
            Response.Write("Tel: " & ds_Branch_Detail.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_Branch_Detail.Tables(0).Rows(0).Item("Fax_Number").ToString & "&nbsp;")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td  style='text-align:Right;font-size:16.5px'>&nbsp;")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr><td >&nbsp;</td></tr>")
            Response.Write("<tr>")
            Response.Write("<td  style='text-align:center;font-size:17px;font-weight:bold;text-decoration:underline'>")
            Response.Write("Cheque Cashed Receipt")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td  style='text-align:Right;font-size:16.5px'>&nbsp;")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr>")
            Response.Write("<td  style='text-align:left;font-size:16.5px;font-weight:bold' >&nbsp;Date:&nbsp;")

            Dim day_loan_new, month_loan_new, year_loan, sup_string_new As String
            day_loan_new = Val(Left(System.DateTime.Now.Date, 2))
            sup_string_new = open_con.check_day(System.DateTime.Now.Day)
            month_loan_new = open_con.cal_short_month(System.DateTime.Now.Month)
            year_loan = System.DateTime.Now.Year
            Response.Write(day_loan_new & " " & month_loan_new & " " & year_loan)
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr><td >&nbsp;</td></tr>")
            Response.Write("<tr><td >&nbsp;" & ds_CustomerAddress.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("Last_Name").ToString & "</td></tr>")
            Response.Write("<tr><td >&nbsp;" & ds_CustomerAddress.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("Street_Name").ToString & "</td></tr>")
            Response.Write("<tr><td >&nbsp;" & ds_CustomerAddress.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("State").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("Post_Code").ToString & "</td></tr>")
            Response.Write("<tr><td >&nbsp;</td></tr>")
            Response.Write("<tr><td >&nbsp;</td></tr>")
            Response.Write("<tr>")
            Response.Write("<td  style='text-align:left;font-size:17px;font-weight:bold'>")
            Response.Write("Cheque cashing details:-")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr><td >&nbsp;</td></tr>")
            Response.Write("</table>")

            Response.Write("<table style='border-collapse: collapse; margin-left:.7in; border:0px solid gray;width:250' cellpadding='0' cellspacing='0'>")
            Response.Write("<tr style='text-align:left;font-size:16.5px'>")
            Response.Write("<td  style='text-align:left;font-size:16.5px'><p style='margin-top:2.0pt ; margin-bottom:2.0pt '>")
            Response.Write("Cheque from/ drawer name</p></td><td></td><td>" & ds_receipt.Tables(0).Rows(0).Item("Cheque_Name").ToString & "</b>")
            Response.Write("</td>")
            Response.Write("</tr>")

            Response.Write("<tr style='text-align:left;font-size:16.5px'>")
            Response.Write("<td  style='text-align:left;font-size:16.5px'>")
            Response.Write("Cheque value</td><td></td><td><b>" & "$" & FormatNumber(ds_receipt.Tables(0).Rows(0).Item("Cheque_Amount").ToString, 2) & "</b>")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr><td>&nbsp;</td></tr>")
            Response.Write("<tr><td>&nbsp;</td></tr>")
            Response.Write("</table>")
            Response.Write("<table style='border-collapse: collapse; margin-left:.7in; border:0px solid gray;width:350' cellpadding='0' cellspacing='0'>")
            Response.Write("<tr style='text-align:left;font-size:16.5px'>")
            Response.Write("<td  style='text-align:left;font-size:16.5px'><p style='margin-top:7.0pt ; margin-bottom:7.0pt '>")
            Response.Write("Cash Paid</p></td><td></td><td>" & "$" & FormatNumber(ds_receipt.Tables(0).Rows(0).Item("Pay_Cash_Now").ToString, 2))
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr style='text-align:left;font-size:16.5px'>")
            Response.Write("<td  style='text-align:left;font-size:16.5px'><p style=' margin-bottom:7.0pt '>")
            Response.Write("Cashing fee</p></td><td></td><td>" & "$" & FormatNumber(ds_receipt.Tables(0).Rows(0).Item("Cheque_Fee").ToString, 2))
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr style='text-align:left;font-size:16.5px'>")
            Response.Write("<td  style='text-align:left;font-size:16.5px'>")
            Response.Write("</td><td></td><td><p style='margin-top:7.0pt'>" & "------------")
            Response.Write("</p></td>")
            Response.Write("</tr>")
            Response.Write("<tr style='text-align:left;font-size:16.5px'>")
            Response.Write("<td>")
            Response.Write("</td><td style='text-align:left;font-size:16.5px'><b>Total</b></td><td><b>$" & FormatNumber(Val(ds_receipt.Tables(0).Rows(0).Item("Pay_Cash_Now").ToString) + Val(ds_receipt.Tables(0).Rows(0).Item("Cheque_Fee").ToString), 2) & "</b>")
            Response.Write("</td>")
            Response.Write("</tr>")
            Response.Write("<tr><td>&nbsp;</td></tr>")
            Response.Write("<tr><td>&nbsp;</td></tr>")
            Response.Write("</table>")
            Response.Write("<table style='border-collapse: collapse; margin-left:.5in; border:0px solid gray;width:540' cellpadding='0' cellspacing='0'>")
            Response.Write("<tr style='text-align:left;font-size:16.5px'>")
            Response.Write("<td>Customer Signature</td><td>______________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td><td>______________________</td>")
            Response.Write("</tr>")
            Response.Write("<tr><td>&nbsp;</td></tr>")
            Response.Write("<tr><td>&nbsp;</td></tr>")
            Response.Write("<tr style='text-align:left;font-size:16.5px'>")
            Response.Write("<td>" & ds_CustomerAddress.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_CustomerAddress.Tables(0).Rows(0).Item("Last_Name").ToString & "</td><td></td><td>" & ds_Branch_Detail.Tables(0).Rows(0).Item("Trading_Name").ToString & "&nbsp;Officer</td>")
            Response.Write("</tr>")
            Response.Write("</table>")
          


            adap_Branch_Detail.Dispose()
            adap_CustomerAddress.Dispose()
            adap_receipt.Dispose()
            ds_Branch_Detail.Dispose()
            ds_CustomerAddress.Dispose()
            ds_receipt.Dispose()
            cmd_Branch_Detail.Dispose()
            cmd_CustomerAddress.Dispose()
            cmd_receipt.Dispose()
        End If
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
