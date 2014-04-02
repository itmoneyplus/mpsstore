Imports System.Data.SqlClient
Imports System.Data
Partial Class Reports_Print_ResS_Report
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Dim new_from_statsnew, new_to_statsnew As String

            new_from_statsnew = Date.Parse(Session("new_from_stats")).ToString("yyyy-MM-dd")
            new_to_statsnew = Date.Parse(Session("new_to_stats")).ToString("yyyy-MM-dd")

            Dim new_from_stats, new_to_stats As Date
            new_from_stats = Session("new_from_stats")
            new_to_stats = Session("new_to_stats")
            Label2.Visible = True
            Label2.Text = "Residential Statistics Report for the period " & new_from_stats.ToString("dd-MMM-yyyy").Replace("-", " ") & " to " & new_to_stats.ToString("dd-MMM-yyyy").Replace("-", " ")


            Dim str_stats As String

            str_stats = "SELECT Tbl_loan.customer_id,Tbl_loan.loan_id,Tbl_loan.amount,Tbl_Customer.Residential_Status FROM Tbl_loan,Tbl_Customer WHERE  Loan_Date>= '" & new_from_statsnew & "'  AND Loan_Date <=  '" & new_to_statsnew & "' and Tbl_loan.Status<>0 and Tbl_loan.Status<>2 and Tbl_Customer.customer_id=Tbl_Loan.customer_id  "

            Dim cmd_stats As New SqlCommand
            Dim ds_stats As New DataSet
            Dim adap_stats As SqlDataAdapter
            cmd_stats.Connection = open_con.return_con
            cmd_stats.CommandText = str_stats
            adap_stats = New SqlDataAdapter(cmd_stats)
            adap_stats.Fill(ds_stats)
            Dim stats_count As String
            stats_count = ds_stats.Tables(0).Rows.Count

            Dim int_own, int_rent, int_boarding, int_mortgage, int_other As Integer

            If Val(stats_count) <> 0 Then
                Dim tot_stat As Integer
                tot_stat = ds_stats.Tables(0).Rows.Count
                Dim i As Integer
                For i = 0 To ds_stats.Tables(0).Rows.Count - 1

                    If ds_stats.Tables(0).Rows(i).Item(3).ToString = "Rent" Then
                        int_rent = int_rent + 1
                    ElseIf ds_stats.Tables(0).Rows(i).Item(3).ToString = "Own" Then
                        int_own = int_own + 1
                    ElseIf ds_stats.Tables(0).Rows(i).Item(3).ToString = "Boarding" Then
                        int_boarding = int_boarding + 1
                    ElseIf ds_stats.Tables(0).Rows(i).Item(3).ToString = "Mortgage" Then
                        int_mortgage = int_mortgage + 1
                    Else
                        int_other = int_other + 1
                    End If
                Next
                Dim rent, own, board, mort, other As String
                rent = "Rent"
                own = "Own"
                board = "Boarding"
                mort = "Mortgage"
                other = "Other"

                Response.Write("<table id='tbl' border='1' width='60%' style='font-size:16px;border:1 solid gray; border-collapse: collapse;z-index: 1; left: 20px; top:50px; position: absolute' cellpadding='0' cellspacing='0' >")
                Response.Write("<tr>")
                Response.Write("<td align='left'><b>Residential Status</b></td>")
                Response.Write("<td align='right'><b>Number</b></td>")
                Response.Write("<td align='right'><b>Percentage</b></td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>&nbsp;</td>")
                Response.Write("<td align='right'>&nbsp;</td>")
                Response.Write("<td align='right'>&nbsp; </td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>Rent</td>")
                Response.Write("<td align='right'>" & int_rent & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_rent, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>Own</td>")
                Response.Write("<td align='right'>" & int_own & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_own, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>Boarding</td>")
                Response.Write("<td align='right'>" & int_boarding & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_boarding, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>Mortgage</td>")
                Response.Write("<td align='right'>" & int_mortgage & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_mortgage, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>Other</td>")
                Response.Write("<td align='right'>" & int_other & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_other, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='right'><b>Total</b></td>")
                Response.Write("<td align='right'>" & tot_stat & "</td>")
                Response.Write("<td align='right'>100.00%</td>")
                Response.Write("</tr>")

                Response.Write("</table >")
            Else
                Label2.Text = " No Records for the period " & new_from_stats.ToString("dd-MMM-yyyy").Replace("-", " ") & " to " & new_to_stats.ToString("dd-MMM-yyyy").Replace("-", " ") & "!!!"
            End If

            cmd_stats.Dispose()
            ds_stats.Dispose()
            cmd_stats.Dispose()
            adap_stats.Dispose()
        End If
    End Sub
End Class
