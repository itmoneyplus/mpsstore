Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class Customer_NAB_rep
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try
                Dim nab_date As String
                nab_date = Session("nab_date")
                Dim show_nab_date As DateTime
                show_nab_date = Date.Parse(nab_date)
                Dim cmd_nab As New SqlCommand
                Dim str_nab As String
                Dim cmd_pay As New SqlCommand
                cmd_pay.Connection = open_con.return_con
                cmd_pay.CommandText = "update tbl_payment set description=null where description='' and due_date = '" & nab_date & "'"
                cmd_pay.ExecuteNonQuery()
                cmd_pay.Dispose()
                str_nab = "SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Given_Name, Tbl_Customer.Last_Name, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Bank_Account.BSB, Tbl_Loan.Loan_ID, Tbl_Loan.Loan_Type, Tbl_Payment.Amount, Tbl_Payment.Due_Date, Tbl_Payment.Payment_Method, Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.BSB "
                str_nab = str_nab & " FROM ((Tbl_Customer INNER JOIN Tbl_Loan ON Tbl_Customer.Customer_ID = Tbl_Loan.Customer_ID) INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID) ON Tbl_Loan.Loan_ID = Tbl_Payment.Loan_ID) INNER JOIN Tbl_Bank_Account ON Tbl_Loan.Bank_Account_ID = Tbl_Bank_Account.Bank_Account_ID "
                str_nab = str_nab & " WHERE (((Tbl_Payment.Amount)<>0) AND ((Tbl_Payment.Due_Date)='" & nab_date & "') AND ((Tbl_Payment.Payment_Method)='NAB') AND ((Tbl_Payment_1.Update_ID) Is Null) AND ((Tbl_Loan.Status)='1') AND ((Tbl_Payment.Description)='Arear notice fee' Or (Tbl_Payment.Description)='Statement of account fee' Or (Tbl_Payment.Description)='Variation fee' Or (Tbl_Payment.Description)='Default notice fee' Or (Tbl_Payment.Description)='Letter of demand fee' Or (Tbl_Payment.Description)='Dishonoured fee' Or (Tbl_Payment.Description)='Enforcement fee' Or (Tbl_Payment.Description) Is Null) AND ((Tbl_Payment.Transaction_Status) Is Null) AND ((Tbl_Payment.Payment_Date) Is Null)) "
                str_nab = str_nab & "ORDER BY Tbl_Customer.Last_Name, Tbl_Customer.Given_Name,Tbl_Payment.Amount "
                cmd_nab.CommandText = str_nab
                cmd_nab.Connection = open_con.return_con
                Dim dataadap_nab As SqlDataAdapter
                Dim ds_nab As New DataSet
                dataadap_nab = New SqlDataAdapter(cmd_nab)
                dataadap_nab.Fill(ds_nab)

                Response.Write("<body onload='window.print();' ondblClick='JavaScript:history.go(-1);'>")
                Response.Write("<div style='text-align:center'>")
                Response.Write("<span style='font-size:18px'>")
                Response.Write("List of customer (s) for ")
                Response.Write("</span>")
                Response.Write("<span style='color:red;font-size:18px'>")
                Response.Write("<b>")
                Response.Write("NAB")
                Response.Write("</b>")
                Response.Write("</span>")
                Response.Write("<span style='font-size:18px'>")
                Response.Write(" Debit file - date: ")
                Response.Write("</span>")
                Response.Write(show_nab_date.ToString("dd-MMM-yyyy"))
                Response.Write("</div>")
                Response.Write("<div style='text-align:center'>")
                Response.Write("<table border='1' width='100%' style='border:0 solid #FFFFFF; border-collapse: collapse' cellpadding='0' cellspacing='0' bordercolor='#C0C0C0'>")
                Response.Write("<tr>")
                Response.Write("<td style='width:220;text-align:left;height:20;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>Customer ID</b></td>")
                Response.Write("<td style='width:200;text-align:center;height:20;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>Given Name</b></td>")
                Response.Write("<td style='width:200;text-align:center;height:20;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>Last Name</b></td>")
                Response.Write("<td style='width:200;text-align:center;height:20;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>Amount</b></td>")
                Response.Write("<td style='width:180;text-align:center;height:20;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>BSB</b></td>")
                Response.Write("<td style='width:180;text-align:center;height:20;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>Account No.</b></td>")
                Response.Write("<td style='width:80;text-align:center;height:20;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>Type</b></td>")
                Response.Write("<td style='width:80;text-align:center;height:20;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>ID</b></td>")
                Response.Write("</tr>")
                '''''''''''''''''''''''''''''''''''''''''''''
                Dim tot_nab As Double
                Dim i As Integer
                For i = 0 To ds_nab.Tables(0).Rows.Count - 1
                    Response.Write("<tr>")
                    Response.Write("<td style='width:150;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(Session("branch_prefix") & " " & CInt(ds_nab.Tables(0).Rows(i).Item("Customer_ID").ToString))
                    Response.Write("</td>")
                    Response.Write("<td style='width:400;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_nab.Tables(0).Rows(i).Item("Given_Name").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='width:400;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_nab.Tables(0).Rows(i).Item("Last_Name").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='width:200;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Dim amt_nab As String
                    amt_nab = CDbl(ds_nab.Tables(0).Rows(i).Item("Amount").ToString)
                    tot_nab = tot_nab + CDbl(ds_nab.Tables(0).Rows(i).Item("Amount").ToString)


                    '''''''''''''''''''''''for amount

                    Dim new_total1 As String
                    new_total1 = open_con.new_amount(amt_nab)

                    Response.Write(new_total1)
                    Response.Write("</td>")
                    Response.Write("<td style='width:250;text-align:center' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_nab.Tables(0).Rows(i).Item("BSB").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='width:180;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_nab.Tables(0).Rows(i).Item("Account_Number").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='width:100;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_nab.Tables(0).Rows(i).Item("Loan_Type").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='width:120;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_nab.Tables(0).Rows(i).Item("Loan_ID").ToString)
                    Response.Write("</td>")
                    Response.Write("</tr>")
                Next


                Dim new_tot1 As String
                new_tot1 = open_con.new_amount(tot_nab)

                Response.Write("<tr>")
                Response.Write("<td  colspan='2' style='font-weight:bold;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write("</td>")
                Response.Write("<td  style='font-weight:bold;text-align:center' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write("Total:")
                Response.Write("</td>")
                Response.Write("<td  style='font-weight:bold;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write(new_tot1)
                Response.Write("</td>")
                Response.Write("<td  colspan='4'  style='font-weight:bold;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("</table>")
                Response.Write("</div>")
                Response.Write("</body>")
                ds_nab.Dispose()
                dataadap_nab.Dispose()
                open_con.return_con.Dispose()

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
