Imports System.Data.SqlClient
Imports System.Data
Partial Class Reports_Print_LoanS_Report
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
            Label2.Text = "Employment Statistics Report for the period " & new_from_stats.ToString("dd-MMM-yyyy").Replace("-", " ") & " to " & new_to_stats.ToString("dd-MMM-yyyy").Replace("-", " ")



            Dim str_stats As String

            str_stats = "SELECT customer_id,loan_id,amount  FROM Tbl_loan WHERE  Loan_Date>= '" & new_from_statsnew & "'  AND Loan_Date <=  '" & new_to_statsnew & "' and Status<>0 and Status<>2"

            Dim cmd_stats As New SqlCommand
            Dim ds_stats As New DataSet
            Dim adap_stats As SqlDataAdapter
            cmd_stats.Connection = open_con.return_con
            cmd_stats.CommandText = str_stats
            adap_stats = New SqlDataAdapter(cmd_stats)
            adap_stats.Fill(ds_stats)
            Dim stats_count As String
            stats_count = ds_stats.Tables(0).Rows.Count

            Dim int_100, int_200, int_300, int_400, int_500, int_600, int_700, int_800, int_900, int_1000, int_1100, int_1200, int_1300, int_1400, int_1500, int_2000, int_2500, int_3000, int_3500, int_4000, int_4500, int_5000, int_5500, int_6000 As Integer

            If Val(stats_count) <> 0 Then
                Dim tot_stat As Integer
                tot_stat = ds_stats.Tables(0).Rows.Count
                Dim i As Integer
                For i = 0 To ds_stats.Tables(0).Rows.Count - 1

                    If CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "100" Then
                        int_100 = int_100 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "200" Then
                        int_200 = int_200 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "300" Then
                        int_300 = int_300 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "400" Then
                        int_400 = int_400 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "500" Then
                        int_500 = int_500 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "600" Then
                        int_600 = int_600 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "700" Then
                        int_700 = int_700 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "800" Then
                        int_800 = int_800 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "900" Then
                        int_900 = int_900 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "1000" Then
                        int_1000 = int_1000 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "1100" Then
                        int_1100 = int_1100 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "1200" Then
                        int_1200 = int_1200 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "1300" Then
                        int_1300 = int_1300 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "1400" Then
                        int_1400 = int_1400 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "1500" Then
                        int_1500 = int_1500 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "2000" Then
                        int_2000 = int_2000 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "2500" Then
                        int_2500 = int_2500 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "3000" Then
                        int_3000 = int_3000 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "3500" Then
                        int_3500 = int_3500 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "4000" Then
                        int_4000 = int_4000 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "4500" Then
                        int_4500 = int_4500 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "5000" Then
                        int_5000 = int_5000 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "5500" Then
                        int_5500 = int_5500 + 1
                    ElseIf CInt(ds_stats.Tables(0).Rows(i).Item(2).ToString) = "6000" Then
                        int_6000 = int_6000 + 1

                    End If





                Next

                Response.Write("<table id='tbl' border='1' width='60%' style='font-size:16px;border:1 solid gray; border-collapse: collapse;z-index: 1; left: 20px; top:50px; position: absolute' cellpadding='0' cellspacing='0' >")
                Response.Write("<tr>")
                Response.Write("<td align='left'><b>Loan</b></td>")
                Response.Write("<td align='right'><b>Number</b></td>")
                Response.Write("<td align='right'><b>Percentage</b></td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>&nbsp;</td>")
                Response.Write("<td align='right'>&nbsp;</td>")
                Response.Write("<td align='right'>&nbsp; </td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$100.00</td>")
                Response.Write("<td align='right'>" & int_100 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_100, tot_stat) & "</td>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$200.00</td>")
                Response.Write("<td align='right'>" & int_200 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_200, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$300.00</td>")
                Response.Write("<td align='right'>" & int_300 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_300, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$400.00</td>")
                Response.Write("<td align='right'>" & int_400 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_400, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$500.00</td>")
                Response.Write("<td align='right'>" & int_500 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_500, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$600.00</td>")
                Response.Write("<td align='right'>" & int_600 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_600, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$700.00</td>")
                Response.Write("<td align='right'>" & int_700 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_700, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$800.00</td>")
                Response.Write("<td align='right'>" & int_800 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_800, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$900.00</td>")
                Response.Write("<td align='right'>" & int_900 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_900, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$1000.00</td>")
                Response.Write("<td align='right'>" & int_1000 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_1000, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$1100.00</td>")
                Response.Write("<td align='right'>" & int_1100 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_1100, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$1200.00</td>")
                Response.Write("<td align='right'>" & int_1200 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_1200, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$1300.00</td>")
                Response.Write("<td align='right'>" & int_1300 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_1300, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$1400.00</td>")
                Response.Write("<td align='right'>" & int_1400 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_1400, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$1500.00</td>")
                Response.Write("<td align='right'>" & int_1500 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_1500, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$2000.00</td>")
                Response.Write("<td align='right'>" & int_2000 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_2000, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$2500.00</td>")
                Response.Write("<td align='right'>" & int_2500 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_2500, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$3000.00</td>")
                Response.Write("<td align='right'>" & int_3000 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_3000, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$3500.00</td>")
                Response.Write("<td align='right'>" & int_3500 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_3500, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$4000.00</td>")
                Response.Write("<td align='right'>" & int_4000 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_4000, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$4500.00</td>")
                Response.Write("<td align='right'>" & int_4500 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_4500, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$5000.00</td>")
                Response.Write("<td align='right'>" & int_5000 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_5000, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$5500.00</td>")
                Response.Write("<td align='right'>" & int_5500 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_5500, tot_stat) & "</td>")
                Response.Write("</tr>")
                Response.Write("<tr>")
                Response.Write("<td align='left'>$6000.00</td>")
                Response.Write("<td align='right'>" & int_6000 & "</td>")
                Response.Write("<td align='right'>" & open_con.calculate_cent(int_6000, tot_stat) & "</td>")
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
