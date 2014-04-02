Imports System.Data.SqlClient
Imports System.Data
Partial Class Customer_Print_Emp_Status
    Inherits System.Web.UI.Page

    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else

            Dim Print_from_empstatus As String
            Dim Print_to_empstatus As String
            Dim dt1, dt2 As DateTime

            dt1 = Convert.ToDateTime(Session("todt_grid2"))
            dt2 = Convert.ToDateTime(Session("fromdt_grid2"))

            Dim new_from_empstatus, new_to_empstatus As String
            new_from_empstatus = Date.Parse(Session("fromdt_grid2")).ToString("yyyy-MM-dd")
            new_to_empstatus = Date.Parse(Session("todt_grid2")).ToString("yyyy-MM-dd")
            Print_from_empstatus = Session("fromdt_grid2")
            Print_to_empstatus = Session("todt_grid2")


            Print_from_empstatus = Date.Parse(Print_from_empstatus).ToString("dd-MMM-yyyy")
            Print_from_empstatus = Print_from_empstatus.Replace("-", " ")
            Print_to_empstatus = Date.Parse(Print_to_empstatus).ToString("dd-MMM-yyyy")
            Print_to_empstatus = Print_to_empstatus.Replace("-", " ")
            Dim emp_grid2 As String
            Dim str_SQL_emp As String
            emp_grid2 = Session("emp_grid2")


            str_SQL_emp = "Select * from tbl_Loan,tbl_customer where Emp_Status='" & emp_grid2 & "' and tbl_loan.status<>0 and tbl_loan.status<>2  and Loan_Date>= ' " & Print_from_empstatus & "' and Loan_Date<= ' " & Print_to_empstatus & "' and tbl_loan.customer_id=tbl_customer.customer_id"


            Dim cmd_empstatus As New SqlCommand
            Dim ds_empstatus As New DataSet
            Dim adap_empstatus As SqlDataAdapter

            cmd_empstatus.CommandText = str_SQL_emp
            cmd_empstatus.Connection = open_con.return_con
            adap_empstatus = New SqlDataAdapter(cmd_empstatus)
            adap_empstatus.Fill(ds_empstatus)
            Dim int_No As Integer
            int_No = ds_empstatus.Tables(0).Rows.Count


            Response.Write("<body onload='window.print();' ondblClick='JavaScript:history.go(-1);'>")
            Response.Write("<br/>")
            Response.Write("<br/>")
            Response.Write("<div align='left'>")
            Response.Write("<span style='font-size:18px;font-style:italic'>")
            Response.Write("Employment Statistics Report for the period " & Print_from_empstatus & " to " & Print_to_empstatus)
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

            If Not ds_empstatus.Tables(0).Rows.Count = 0 Then
                Dim i As Integer = 0
                For i = 0 To ds_empstatus.Tables(0).Rows.Count - 1



                    With Response
                        .Write("<tr>")
                        .Write("<td style='border: 1px solid #C0C0C0;text-align:center'>&nbsp;" & ds_empstatus.Tables(0).Rows(i).Item("Customer_ID").ToString & "</td>")
                        .Write("<td style='border: 1px solid #C0C0C0;text-align:left'>&nbsp;" & ds_empstatus.Tables(0).Rows(i).Item("Given_Name").ToString & "</td>")
                        .Write("<td style='border: 1px solid #C0C0C0;text-align:left'>&nbsp;" & ds_empstatus.Tables(0).Rows(i).Item("Last_Name").ToString & "</td>")
                        .Write("<td style='border: 1px solid #C0C0C0;text-align:center'>&nbsp;" & ds_empstatus.Tables(0).Rows(i).Item("Loan_ID").ToString & "</td>")
                        .Write("<td style='border: 1px solid #C0C0C0;text-align:center'>&nbsp;" & open_con.fn_FormatMPDate(ds_empstatus.Tables(0).Rows(i).Item("Loan_Date").ToString) & "&nbsp;</td>")
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
            cmd_empstatus.Dispose()
            ds_empstatus.Dispose()
            adap_empstatus.Dispose()
            open_con.return_con.Dispose()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
