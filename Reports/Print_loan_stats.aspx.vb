Imports System.Data.SqlClient
Imports System.Data
Partial Class Customer_Print_loan_stats
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else

            Dim Print_from_loanstatus As String
            Dim Print_to_loanstatus As String
            Dim dt1, dt2 As DateTime

            dt1 = Convert.ToDateTime(Session("todt_grid2"))
            dt2 = Convert.ToDateTime(Session("fromdt_grid2"))

            Dim new_from_loanstatus, new_to_loanstatus As String
            new_from_loanstatus = Date.Parse(Session("fromdt_grid2")).ToString("yyyy-MM-dd")
            new_to_loanstatus = Date.Parse(Session("todt_grid2")).ToString("yyyy-MM-dd")
            Print_from_loanstatus = Session("fromdt_grid2")
            Print_to_loanstatus = Session("todt_grid2")


            Print_from_loanstatus = Date.Parse(Print_from_loanstatus).ToString("dd-MMM-yyyy")
            Print_from_loanstatus = Print_from_loanstatus.Replace("-", " ")
            Print_to_loanstatus = Date.Parse(Print_to_loanstatus).ToString("dd-MMM-yyyy")
            Print_to_loanstatus = Print_to_loanstatus.Replace("-", " ")
            Dim amt_grid2 As String
            Dim str_SQL_loans As String
            amt_grid2 = Session("amt_grid2")


            str_SQL_loans = "Select * from tbl_Loan,tbl_customer where Amount='" & Session("amt_grid2") & "' and tbl_loan.status<>0 and tbl_loan.status<>2 and Loan_Date>= ' " & new_from_loanstatus & "' and Loan_Date<= ' " & new_to_loanstatus & "' and tbl_loan.customer_id=tbl_customer.customer_id"


            Dim cmd_loan As New SqlCommand
            Dim ds_loan As New DataSet
            Dim adap_loan As SqlDataAdapter

            cmd_loan.CommandText = str_SQL_loans
            cmd_loan.Connection = open_con.return_con
            adap_loan = New SqlDataAdapter(cmd_loan)
            adap_loan.Fill(ds_loan)
            Dim int_No As Integer
            int_No = ds_loan.Tables(0).Rows.Count


            Response.Write("<body onload='window.print();' ondblClick='JavaScript:history.go(-1);'>")
            Response.Write("<br/>")
            Response.Write("<br/>")
            Response.Write("<div align='left'>")
            Response.Write("<span style='font-size:18px;font-style:italic'>")
            Response.Write("Loans Statistics Report for the period " & Print_from_loanstatus & " to " & Print_to_loanstatus)
            Response.Write("</span>")
            Response.Write("</div>")
            Response.Write("<br/>")
            Response.Write("<div align='center'>")
            Response.Write("<table border='1' width='97%' style='font-size:16px;border:0 solid gray; border-collapse: collapse' cellpadding='0' cellspacing='0'>")
            Response.Write("<tr>")
            Response.Write("<td style='border: 1px solid #C0C0C0;background-color:#EEEEEE;text-align:center'><b>&nbsp;Customer ID</b></td>")
            Response.Write("<td style='border: 1px solid #C0C0C0;background-color:#EEEEEE;text-align:center'><b>&nbsp;Given Name</b></td>")
            Response.Write("<td style='border: 1px solid #C0C0C0;background-color:#EEEEEE;text-align:center'><b>&nbsp;Last Name</b></td>")
            Response.Write("<td style='border: 1px solid #C0C0C0;background-color:#EEEEEE;text-align:center'><b>&nbsp;Loan ID</b></td>")
            Response.Write("<td style='border: 1px solid #C0C0C0;background-color:#EEEEEE;text-align:center'><b>Date of Loan&nbsp;</b></td> ")
            Response.Write("</tr>")

            If Not ds_loan.Tables(0).Rows.Count = 0 Then
                Dim i As Integer = 0
                For i = 0 To ds_loan.Tables(0).Rows.Count - 1



                    With Response
                        .Write("<tr>")
                        .Write("<td style='border: 1px solid #C0C0C0;text-align:center'>&nbsp;" & ds_loan.Tables(0).Rows(i).Item("Customer_ID").ToString & "</td>")
                        .Write("<td style='border: 1px solid #C0C0C0;text-align:left'>&nbsp;" & ds_loan.Tables(0).Rows(i).Item("Given_Name").ToString & "</td>")
                        .Write("<td style='border: 1px solid #C0C0C0;text-align:left'>&nbsp;" & ds_loan.Tables(0).Rows(i).Item("Last_Name").ToString & "</td>")
                        .Write("<td style='border: 1px solid #C0C0C0;text-align:center'>&nbsp;" & ds_loan.Tables(0).Rows(i).Item("Loan_ID").ToString & "</td>")
                        .Write("<td style='border: 1px solid #C0C0C0;text-align:center'>&nbsp;" & open_con.fn_FormatMPDate(ds_loan.Tables(0).Rows(i).Item("Loan_Date").ToString) & "&nbsp;</td>")
                        .Write("</tr>")
                    End With



                Next
            End If


            Response.Write("<tr>")
            Response.Write("<td colspan='4' style='border: 1px solid #C0C0C0;text-align:right'><b>Total Loans&nbsp;</b></td>")
            Response.Write("<td style='border: 1px solid #C0C0C0;text-align:left'>&nbsp;&nbsp;<b>" & int_No & "</b></td>")
            Response.Write("</tr>")
            Response.Write("</table>")
            Response.Write("</div>")
            Response.Write("</body>")
            cmd_loan.Dispose()
            ds_loan.Dispose()
            adap_loan.Dispose()
            open_con.return_con.Dispose()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
