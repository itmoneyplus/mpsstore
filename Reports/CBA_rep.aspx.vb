Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Customer_CBA_rep
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try


                Dim cba_date As String
                cba_date = Session("cba_date")
                Dim show_cba_date As DateTime
                show_cba_date = Date.Parse(cba_date)
                Dim cmd_cba As New SqlCommand
                Dim str_cba As String
                Dim cmd_pay As New SqlCommand
                cmd_pay.Connection = open_con.return_con
                cmd_pay.CommandText = "update tbl_payment set description=null where description='' and due_date = '" & cba_date & "'"
                cmd_pay.ExecuteNonQuery()
                cmd_pay.Dispose()
                str_cba = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Given_Name, Tbl_Customer.Last_Name, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Bank_Account.BSB, Tbl_Loan.Loan_ID, Tbl_Loan.Loan_Type, Tbl_Payment.Amount, Tbl_Payment.Due_Date, Tbl_Payment.Payment_Method, Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.BSB "
                str_cba = str_cba & " FROM ((Tbl_Customer INNER JOIN Tbl_Loan ON Tbl_Customer.Customer_ID = Tbl_Loan.Customer_ID) INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID) ON Tbl_Loan.Loan_ID = Tbl_Payment.Loan_ID) INNER JOIN Tbl_Bank_Account ON Tbl_Loan.Bank_Account_ID = Tbl_Bank_Account.Bank_Account_ID "
                str_cba = str_cba & " WHERE (((Tbl_Payment.Amount)<>0) AND ((Tbl_Payment.Due_Date)='" & cba_date & "') AND ((Tbl_Payment.Payment_Method)='CBA') AND ((Tbl_Payment_1.Update_ID) Is Null) AND ((Tbl_Loan.Status)='1') AND ((Tbl_Payment.Description)='Arear notice fee' Or (Tbl_Payment.Description)='Statement of account fee' Or (Tbl_Payment.Description)='Variation fee' Or (Tbl_Payment.Description)='Default notice fee' Or (Tbl_Payment.Description)='Letter of demand fee' Or (Tbl_Payment.Description)='Dishonoured fee' Or (Tbl_Payment.Description)='Enforcement fee' Or (Tbl_Payment.Description) Is Null) AND ((Tbl_Payment.Transaction_Status) Is Null) AND ((Tbl_Payment.Payment_Date) Is Null)) "
                str_cba = str_cba & " ORDER BY Tbl_Customer.Last_Name, Tbl_Customer.Given_Name "
                cmd_cba.CommandText = str_cba
                cmd_cba.Connection = open_con.return_con
                Dim dataadap_cba As SqlDataAdapter
                Dim ds_cba As New DataSet
                dataadap_cba = New SqlDataAdapter(cmd_cba)
                dataadap_cba.Fill(ds_cba)
                Response.Write("<body onload='window.print();' ondblClick='JavaScript:history.go(-1);'>")
                Response.Write("<div style='text-align:center'>")
                Response.Write("<span style='font-size:18px'>")
                Response.Write("List of customer (s) for ")
                Response.Write("</span>")
                Response.Write("<span style='color:red;font-size:18px'>")
                Response.Write("<b>")
                Response.Write("CBA")
                Response.Write("</b>")
                Response.Write("</span>")
                Response.Write("<span style='font-size:18px'>")
                Response.Write(" Debit file - date: ")
                Response.Write("</span>")
                Response.Write(show_cba_date.ToString("dd-MMM-yyyy"))
                Response.Write("</div>")
                Response.Write("<div style='text-align:center'>")
                Response.Write("<table border='1' width='100%' style='border:0 solid #FFFFFF; border-collapse: collapse' cellpadding='0' cellspacing='0' bordercolor='#C0C0C0'>")
                Response.Write("<tr>")
                Response.Write("<td  style='width:220;height:20;text-align:left' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>Customer ID</b></td>")
                Response.Write("<td  style='width:200;height:20;text-align:center' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>Given Name</b></td>")
                Response.Write("<td  style='width:200;height:20;text-align:center' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>Last Name</b></td>")
                Response.Write("<td  style='width:200;height:20;text-align:center' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>Amount</b></td>")
                Response.Write("<td  style='width:180;height:20;text-align:center' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>BSB</b></td>")
                Response.Write("<td  style='width:180;height:20;text-align:center' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>Account No.</b></td>")
                Response.Write("<td  style='width:80;height:20;text-align:center' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>Type</b></td>")
                Response.Write("<td  style='width:80;height:20;text-align:center' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'><b>ID</b></td>")
                Response.Write("</tr>")
                '''''''''''''''''''''''''''''''''''''''''''''
                Dim tot_cba As Double
                Dim i As Integer
                For i = 0 To ds_cba.Tables(0).Rows.Count - 1
                    Response.Write("<tr>")
                    Response.Write("<td style='width:150;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(Session("branch_prefix") & " " & CInt(ds_cba.Tables(0).Rows(i).Item("Customer_ID").ToString))
                    Response.Write("</td>")
                    Response.Write("<td style='width:400;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_cba.Tables(0).Rows(i).Item("Given_Name").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='width:400;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_cba.Tables(0).Rows(i).Item("Last_Name").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='width:200;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Dim amt_cba As String
                    amt_cba = CDbl(ds_cba.Tables(0).Rows(i).Item("Amount").ToString)
                    tot_cba = tot_cba + CDbl(ds_cba.Tables(0).Rows(i).Item("Amount").ToString)

                    '''''''''''''''''''''''for amount
                    Dim new_total1 As String
                    new_total1 = open_con.new_amount(amt_cba)
                    Response.Write(new_total1)
                    Response.Write("</td>")
                    Response.Write("<td style='width:250;text-align:center' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_cba.Tables(0).Rows(i).Item("BSB").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='width:180;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_cba.Tables(0).Rows(i).Item("Account_Number").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='width:100;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_cba.Tables(0).Rows(i).Item("Loan_Type").ToString)
                    Response.Write("</td>")
                    Response.Write("<td style='width:120;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                    Response.Write(ds_cba.Tables(0).Rows(i).Item("Loan_ID").ToString)
                    Response.Write("</td>")
                    Response.Write("</tr>")
                Next

                Dim new_tot2 As String
                new_tot2 = open_con.new_amount(tot_cba)

                Response.Write("<tr>")
                Response.Write("<td  colspan='2' style='font-weight:bold;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write("</td>")
                Response.Write("<td  style='font-weight:bold;text-align:center' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write("Total:")
                Response.Write("</td>")
                Response.Write("<td  style='font-weight:bold;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write(new_tot2)
                Response.Write("</td>")
                'Response.Write("<td  colspan='4'  style='font-weight:bold;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                'Response.Write(new_tot2)
                'Response.Write("</td>")
                Response.Write("</tr>")
                Response.Write("</table>")
                Response.Write("</div>")
                Response.Write("</body>")
                ds_cba.Dispose()
                dataadap_cba.Dispose()
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
