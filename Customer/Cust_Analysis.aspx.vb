Imports System.Data.SqlClient
Imports System.Data
Partial Class Customer_Cust_Analysis
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Val(txtfrom.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            ElseIf Val(txtto.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid ending date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            ElseIf CDate(txtfrom.Text) > CDate(txtto.Text) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid future date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            Else

                If RadioButtonList1.SelectedItem.Text = " Employment" Then
                    emp_stats()
                ElseIf RadioButtonList1.SelectedItem.Text = " Residential" Then
                    residential_stats()
                ElseIf RadioButtonList1.SelectedItem.Text = " Loans" Then
                    loan_stats()
                ElseIf RadioButtonList1.SelectedItem.Text = " Age" Then
                    age_status()
                ElseIf RadioButtonList1.SelectedItem.Text = " Gender" Then
                    sex_stats()
                End If


            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try


       
    End Sub

    Sub age_status()

        Session("loan_stats") = "true"

        Dim Print_from_stats As String
        Dim Print_to_stats As String

        Print_from_stats = txtfrom.Text
        Print_to_stats = txtto.Text

        Dim new_from_stats As String
        Dim new_to_stats As String
        new_from_stats = Date.Parse(Print_from_stats).ToString("yyyy-MM-dd")
        new_to_stats = Date.Parse(Print_to_stats).ToString("yyyy-MM-dd")
        Session("new_from_stats") = new_from_stats
        Session("new_to_stats") = new_to_stats

        Print_from_stats = Date.Parse(Print_from_stats).ToString("dd-MMM-yyyy")
        Print_from_stats = Print_from_stats.Replace("-", " ")
        Print_to_stats = Date.Parse(Print_to_stats).ToString("dd-MMM-yyyy")
        Print_to_stats = Print_to_stats.Replace("-", " ")



        Label2.Visible = True
        Label2.Text = "Age Statistics Report for the period " & Print_from_stats & " to " & Print_to_stats

        Dim str_stats As String

        str_stats = "SELECT Tbl_loan.customer_id,Tbl_loan.loan_id,Tbl_loan.amount,Tbl_Customer.Date_Of_Birth FROM Tbl_loan,Tbl_Customer WHERE  Loan_Date>= '" & new_from_stats & "'  AND Loan_Date <=  '" & new_to_stats & "' and Tbl_loan.Status<>0 and Tbl_loan.Status<>2 and Tbl_Customer.customer_id=Tbl_Loan.customer_id "


        Dim cmd_stats As New SqlCommand
        Dim ds_stats As New DataSet
        Dim adap_stats As SqlDataAdapter
        cmd_stats.Connection = open_con.return_con
        cmd_stats.CommandText = str_stats
        adap_stats = New SqlDataAdapter(cmd_stats)
        adap_stats.Fill(ds_stats)
        Dim stats_count As String
        stats_count = ds_stats.Tables(0).Rows.Count
        Dim int_group1, int_group2, int_group3, int_group4, int_group5, int_group6 As Integer
        If Val(stats_count) <> 0 Then
            Dim tot_stat As Integer
            tot_stat = ds_stats.Tables(0).Rows.Count
            Dim i As Integer
            For i = 0 To ds_stats.Tables(0).Rows.Count - 1
                Dim cust_date As Date
                cust_date = CDate(ds_stats.Tables(0).Rows(i).Item(3)).ToString("dd-MM-yyyy")
                Dim age As Integer
                age = System.DateTime.Now.Date.Year - cust_date.Year

                If age >= 18 And age <= 25 Then
                    int_group1 = int_group1 + 1
                ElseIf age >= 26 And age <= 35 Then
                    int_group2 = int_group2 + 1
                ElseIf age >= 36 And age <= 45 Then
                    int_group3 = int_group3 + 1
                ElseIf age >= 46 And age <= 55 Then
                    int_group4 = int_group4 + 1
                ElseIf age >= 56 And age <= 65 Then
                    int_group5 = int_group5 + 1
                ElseIf age >= 66 Then
                    int_group6 = int_group6 + 1
                End If
            Next

            Dim sbage As New StringBuilder()
            'sbage.Append("<table id='tbl' border='1' width='60%' style='font-size:16px;border:1 solid gray; border-collapse: collapse;z-index: 1; left: 285px; top:450px; position: absolute' cellpadding='0' cellspacing='0' >")
            sbage.Append("<table id='tbl'cellpadding='0' cellspacing='0' class='tblreport_new' >")
            sbage.Append("<tr>")
            sbage.Append("<td align='center'><b>Age</b></td>")
            sbage.Append("<td align='right'><b>Number</b></td>")
            sbage.Append("<td align='right'><b>Percentage</b></td>")
            sbage.Append("</tr>")
            sbage.Append("<tr>")
            sbage.Append("<td align='left'>&nbsp;</td>")
            sbage.Append("<td align='right'>&nbsp;</td>")
            sbage.Append("<td align='right'>&nbsp; </td>")
            sbage.Append("</tr>")
            sbage.Append("<tr>")
            sbage.Append("<td align='center'>18-25</td>")
            sbage.Append("<td align='right'>" & int_group1 & "</td>")
            sbage.Append("<td align='right'>" & open_con.calculate_cent(int_group1, tot_stat) & "</td>")
            sbage.Append("<tr>")
            sbage.Append("<td align='center'>26-35</td>")
            sbage.Append("<td align='right'>" & int_group2 & "</td>")
            sbage.Append("<td align='right'>" & open_con.calculate_cent(int_group2, tot_stat) & "</td>")
            sbage.Append("</tr>")
            sbage.Append("<tr>")
            sbage.Append("<td align='center'>36-45</td>")
            sbage.Append("<td align='right'>" & int_group3 & "</td>")
            sbage.Append("<td align='right'>" & open_con.calculate_cent(int_group3, tot_stat) & "</td>")
            sbage.Append("</tr>")
            sbage.Append("<tr>")
            sbage.Append("<td align='center'>46-55</td>")
            sbage.Append("<td align='right'>" & int_group4 & "</td>")
            sbage.Append("<td align='right'>" & open_con.calculate_cent(int_group4, tot_stat) & "</td>")
            sbage.Append("</tr>")
            sbage.Append("<tr>")
            sbage.Append("<td align='center'>56-65</td>")
            sbage.Append("<td align='right'>" & int_group5 & "</td>")
            sbage.Append("<td align='right'>" & open_con.calculate_cent(int_group5, tot_stat) & "</td>")
            sbage.Append("</tr>")
            sbage.Append("<tr>")
            sbage.Append("<td align='center'>Over 66</td>")
            sbage.Append("<td align='right'>" & int_group6 & "</td>")
            sbage.Append("<td align='right'>" & open_con.calculate_cent(int_group6, tot_stat) & "</td>")
            sbage.Append("</tr>")
            sbage.Append("<tr>")
            sbage.Append("<td align='center'><b>Total</b></td>")
            sbage.Append("<td align='right'>" & tot_stat & "</td>")
            sbage.Append("<td align='right'>100.00%</td>")
            sbage.Append("</tr>")
            sbage.Append("<tr>")
            sbage.Append("<td colspan='14' style='border-color:white;text-align:center'>")

            sbage.Append("<br/>")
            sbage.Append("<br/>")

            sbage.Append("<input type='button' ID='Button1'  value='Re-Create Again'   onclick='return ClearTextboxes() ' />")
            sbage.Append("&nbsp;&nbsp;&nbsp;")
            sbage.Append("<input ID='Button3' type='button' value='View & Print' onclick='return Button3_onclick()'/>")
            sbage.Append("</td>")
            sbage.Append("</tr>")
            sbage.Append("</table >")
            Literal1.Text = sbage.ToString()
        Else
            Literal1.Text = ""
            Label2.Text = " No Records for the period " & Print_from_stats & " to " & Print_to_stats & "!!!"
        End If


        cmd_stats.Dispose()
        ds_stats.Dispose()
        cmd_stats.Dispose()
        adap_stats.Dispose()
    End Sub

    Sub loan_stats()


        Session("loan_stats") = "true"

        Dim Print_from_stats As String
        Dim Print_to_stats As String

        Print_from_stats = txtfrom.Text
        Print_to_stats = txtto.Text

        Dim new_from_stats As String
        Dim new_to_stats As String
        new_from_stats = Date.Parse(Print_from_stats).ToString("yyyy-MM-dd")
        new_to_stats = Date.Parse(Print_to_stats).ToString("yyyy-MM-dd")

        Session("new_from_stats") = new_from_stats
        Session("new_to_stats") = new_to_stats

        Print_from_stats = Date.Parse(Print_from_stats).ToString("dd-MMM-yyyy")
        Print_from_stats = Print_from_stats.Replace("-", " ")
        Print_to_stats = Date.Parse(Print_to_stats).ToString("dd-MMM-yyyy")
        Print_to_stats = Print_to_stats.Replace("-", " ")



        Label2.Visible = True
        Label2.Text = "Loans Statistics Report for the period " & Print_from_stats & " to " & Print_to_stats


        Dim str_stats As String

        str_stats = "SELECT customer_id,loan_id,amount  FROM Tbl_loan WHERE  Loan_Date>= '" & new_from_stats & "'  AND Loan_Date <=  '" & new_to_stats & "' and Status<>0 and Status<>2"

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
            Dim sbLoan As New StringBuilder()

            'Response.Write("<table id='tbl' border='1' width='60%' style='font-size:16px;border:1 solid gray; border-collapse: collapse;z-index: 1; left: 285px; top:450px; position: absolute' cellpadding='0' cellspacing='0' >")
            sbLoan.Append("<table id='tbl' cellpadding='0' cellspacing='0' class='tblreport_new' >")
            sbLoan.Append("<tr>")
            sbLoan.Append("<td align='left'><b>Loan</b></td>")
            sbLoan.Append("<td align='right'><b>Number</b></td>")
            sbLoan.Append("<td align='right'><b>Percentage</b></td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr>")
            sbLoan.Append("<td align='left'>&nbsp;</td>")
            sbLoan.Append("<td align='right'>&nbsp;</td>")
            sbLoan.Append("<td align='right'>&nbsp; </td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 100 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_100 & "');"">")
            sbLoan.Append("<td align='left'>$100.00</td>")
            sbLoan.Append("<td align='right'>" & int_100 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_100, tot_stat) & "</td>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 200 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_200 & "');"">")
            sbLoan.Append("<td align='left'>$200.00</td>")
            sbLoan.Append("<td align='right'>" & int_200 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_200, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 300 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_300 & "');"">")
            sbLoan.Append("<td align='left'>$300.00</td>")
            sbLoan.Append("<td align='right'>" & int_300 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_300, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 400 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_400 & "');"">")
            sbLoan.Append("<td align='left'>$400.00</td>")
            sbLoan.Append("<td align='right'>" & int_400 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_400, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 500 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_500 & "');"">")
            sbLoan.Append("<td align='left'>$500.00</td>")
            sbLoan.Append("<td align='right'>" & int_500 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_500, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 600 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_600 & "');"">")
            sbLoan.Append("<td align='left'>$600.00</td>")
            sbLoan.Append("<td align='right'>" & int_600 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_600, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 700 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_700 & "');"">")
            sbLoan.Append("<td align='left'>$700.00</td>")
            sbLoan.Append("<td align='right'>" & int_700 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_700, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 800 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_800 & "');"">")
            sbLoan.Append("<td align='left'>$800.00</td>")
            sbLoan.Append("<td align='right'>" & int_800 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_800, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 900 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_900 & "');"">")
            sbLoan.Append("<td align='left'>$900.00</td>")
            sbLoan.Append("<td align='right'>" & int_900 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_900, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 1000 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_1000 & "');"">")
            sbLoan.Append("<td align='left'>$1000.00</td>")
            sbLoan.Append("<td align='right'>" & int_1000 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_1000, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 1100 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_1100 & "');"">")
            sbLoan.Append("<td align='left'>$1100.00</td>")
            sbLoan.Append("<td align='right'>" & int_1100 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_1100, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 1200 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_1200 & "');"">")
            sbLoan.Append("<td align='left'>$1200.00</td>")
            sbLoan.Append("<td align='right'>" & int_1200 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_1200, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 1300 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_1300 & "');"">")
            sbLoan.Append("<td align='left'>$1300.00</td>")
            sbLoan.Append("<td align='right'>" & int_1300 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_1300, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 1400 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_1400 & "');"">")
            sbLoan.Append("<td align='left'>$1400.00</td>")
            sbLoan.Append("<td align='right'>" & int_1400 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_1400, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 1500 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_1500 & "');"">")
            sbLoan.Append("<td align='left'>$1500.00</td>")
            sbLoan.Append("<td align='right'>" & int_1500 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_1500, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 2000 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_2000 & "');"">")
            sbLoan.Append("<td align='left'>$2000.00</td>")
            sbLoan.Append("<td align='right'>" & int_2000 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_2000, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 2500 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_2500 & "');"">")
            sbLoan.Append("<td align='left'>$2500.00</td>")
            sbLoan.Append("<td align='right'>" & int_2500 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_2500, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 3000 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_3000 & "');"">")
            sbLoan.Append("<td align='left'>$3000.00</td>")
            sbLoan.Append("<td align='right'>" & int_3000 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_3000, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 3500 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_3500 & "');"">")
            sbLoan.Append("<td align='left'>$3500.00</td>")
            sbLoan.Append("<td align='right'>" & int_3500 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_3500, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 4000 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_4000 & "');"">")
            sbLoan.Append("<td align='left'>$4000.00</td>")
            sbLoan.Append("<td align='right'>" & int_4000 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_4000, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 4500 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_4500 & "');"">")
            sbLoan.Append("<td align='left'>$4500.00</td>")
            sbLoan.Append("<td align='right'>" & int_4500 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_4500, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 5000 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_5000 & "');"">")
            sbLoan.Append("<td align='left'>$5000.00</td>")
            sbLoan.Append("<td align='right'>" & int_5000 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_5000, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 5500 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_5500 & "');"">")
            sbLoan.Append("<td align='left'>$5500.00</td>")
            sbLoan.Append("<td align='right'>" & int_5500 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_5500, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_more('" & 6000 & "','" & new_from_stats & "','" & new_to_stats & "','" & int_6000 & "',this);"">")
            sbLoan.Append("<td align='left'>$6000.00</td>")
            sbLoan.Append("<td align='right'>" & int_6000 & "</td>")
            sbLoan.Append("<td align='right'>" & open_con.calculate_cent(int_6000, tot_stat) & "</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr>")
            sbLoan.Append("<td align='right'><b>Total</b></td>")
            sbLoan.Append("<td align='right'>" & tot_stat & "</td>")
            sbLoan.Append("<td align='right'>100.00%</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("<tr>")
            sbLoan.Append("<td colspan='14' style='border-color:white;text-align:center'>")

            sbLoan.Append("<br/>")
            sbLoan.Append("<br/>")

            sbLoan.Append("<input type='button' ID='Button1'  value='Re-Create Again'   onclick='return ClearTextboxes() ' />")
            sbLoan.Append("&nbsp;&nbsp;&nbsp;")
            sbLoan.Append("<input ID='Button4' type='button' value='View & Print' onclick='return Button4_onclick()'/>")
            sbLoan.Append("</td>")
            sbLoan.Append("</tr>")
            sbLoan.Append("</table >")
            Literal1.Text = sbLoan.ToString()
        Else
            Literal1.Text = ""
            Label2.Text = " No Records for the period " & Print_from_stats & " to " & Print_to_stats & "!!!"
        End If
    

        cmd_stats.Dispose()
        ds_stats.Dispose()
        cmd_stats.Dispose()
        adap_stats.Dispose()
    End Sub


    Sub sex_stats()


        Session("loan_stats") = "true"

        Dim Print_from_stats As String
        Dim Print_to_stats As String

        Print_from_stats = txtfrom.Text
        Print_to_stats = txtto.Text

        Dim new_from_stats As String
        Dim new_to_stats As String
        new_from_stats = Date.Parse(Print_from_stats).ToString("yyyy-MM-dd")
        new_to_stats = Date.Parse(Print_to_stats).ToString("yyyy-MM-dd")

        Session("new_from_stats") = new_from_stats
        Session("new_to_stats") = new_to_stats

        Print_from_stats = Date.Parse(Print_from_stats).ToString("dd-MMM-yyyy")
        Print_from_stats = Print_from_stats.Replace("-", " ")
        Print_to_stats = Date.Parse(Print_to_stats).ToString("dd-MMM-yyyy")
        Print_to_stats = Print_to_stats.Replace("-", " ")



        Label2.Visible = True
        Label2.Text = "Gender Statistics Report for the period " & Print_from_stats & " to " & Print_to_stats


        Dim str_stats As String

        str_stats = "SELECT Tbl_loan.customer_id,Tbl_loan.loan_id,Tbl_loan.amount,Tbl_Customer.title FROM Tbl_loan,Tbl_Customer WHERE  Loan_Date>= '" & new_from_stats & "'  AND Loan_Date <=  '" & new_to_stats & "' and Tbl_loan.Status<>0 and Tbl_loan.Status<>2 and Tbl_Customer.customer_id=Tbl_Loan.customer_id "

        Dim cmd_stats As New SqlCommand
        Dim ds_stats As New DataSet
        Dim adap_stats As SqlDataAdapter
        cmd_stats.Connection = open_con.return_con
        cmd_stats.CommandText = str_stats
        adap_stats = New SqlDataAdapter(cmd_stats)
        adap_stats.Fill(ds_stats)
        Dim stats_count As String
        stats_count = ds_stats.Tables(0).Rows.Count

        Dim int_male, int_female As Integer



        If Val(stats_count) <> 0 Then
            Dim tot_stat As Integer
            tot_stat = ds_stats.Tables(0).Rows.Count
            Dim i As Integer
            For i = 0 To ds_stats.Tables(0).Rows.Count - 1

                If ds_stats.Tables(0).Rows(i).Item(3).ToString = "Ms" Then
                    int_female = int_female + 1
                ElseIf ds_stats.Tables(0).Rows(i).Item(3).ToString = "Mrs" Then
                    int_female = int_female + 1
                ElseIf ds_stats.Tables(0).Rows(i).Item(3).ToString = "Miss" Then
                    int_female = int_female + 1
                ElseIf ds_stats.Tables(0).Rows(i).Item(3).ToString = "Mr" Then
                    int_male = int_male + 1
                End If
            Next
            Dim fem, male As String
            fem = "f"
            male = "m"

            Dim ss As New StringBuilder()

            'Response.Write("<table id='tbl' border='1' width='60%' style='font-size:16px;border:1 solid gray; border-collapse: collapse;z-index: 1; left: 285px; top:450px; position: absolute' cellpadding='0' cellspacing='0' >")
            ss.Append("<table id='tbl' cellpadding='0' cellspacing='0' class='tblreport_new' >")
            ss.Append("<tr>")
            ss.Append("<td align='left'><b>Loan</b></td>")
            ss.Append("<td align='right'><b>Number</b></td>")
            ss.Append("<td align='right'><b>Percentage</b></td>")
            ss.Append("</tr>")
            ss.Append("<tr>")
            ss.Append("<td align='left'>&nbsp;</td>")
            ss.Append("<td align='right'>&nbsp;</td>")
            ss.Append("<td align='right'>&nbsp; </td>")
            ss.Append("</tr>")
            ss.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_sex('" & fem & "','" & new_from_stats & "','" & new_to_stats & "','" & int_female & "');"">")
            ss.Append("<td align='left'>Female</td>")
            ss.Append("<td align='right'>" & int_female & "</td>")
            ss.Append("<td align='right'>" & open_con.calculate_cent(int_female, tot_stat) & "</td>")
            ss.Append("</tr>")
            ss.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_sex('" & male & "','" & new_from_stats & "','" & new_to_stats & "','" & int_male & "');"">")
            ss.Append("<td align='left'>Male</td>")
            ss.Append("<td align='right'>" & int_male & "</td>")
            ss.Append("<td align='right'>" & open_con.calculate_cent(int_male, tot_stat) & "</td>")
            ss.Append("</tr>")
            ss.Append("<tr>")
            ss.Append("<td align='right'><b>Total</b></td>")
            ss.Append("<td align='right'>" & tot_stat & "</td>")
            ss.Append("<td align='right'>100.00%</td>")
            ss.Append("</tr>")
            ss.Append("<tr>")
            ss.Append("<td colspan='14' style=' border-color:white;text-align:center'>")

            ss.Append("<br/>")
            ss.Append("<br/>")

            ss.Append("<input type='button' ID='Button1'  value='Re-Create Again'  onclick='ClearTextboxes()' />")
            ss.Append("&nbsp;&nbsp;&nbsp;")
            ss.Append("<input ID='Button5' type='button' value='View & Print' onclick='return Button5_onclick()'/>")
            ss.Append("</td>")
            ss.Append("</tr>")
            ss.Append("</table >")
            Literal1.Text = ss.ToString()
        Else
            Literal1.Text = ""
            Label2.Text = " No Records for the period " & Print_from_stats & " to " & Print_to_stats & "!!!"
        End If
    
        cmd_stats.Dispose()
        ds_stats.Dispose()
        cmd_stats.Dispose()
        adap_stats.Dispose()
    End Sub
    Sub emp_stats()


        Session("loan_stats") = "true"

        Dim Print_from_stats As String
        Dim Print_to_stats As String

        Print_from_stats = txtfrom.Text
        Print_to_stats = txtto.Text

        Dim new_from_stats As String
        Dim new_to_stats As String
        new_from_stats = Date.Parse(Print_from_stats).ToString("yyyy-MM-dd")
        new_to_stats = Date.Parse(Print_to_stats).ToString("yyyy-MM-dd")
        Session("new_from_stats") = new_from_stats
        Session("new_to_stats") = new_to_stats

        Print_from_stats = Date.Parse(Print_from_stats).ToString("dd-MMM-yyyy")
        Print_from_stats = Print_from_stats.Replace("-", " ")
        Print_to_stats = Date.Parse(Print_to_stats).ToString("dd-MMM-yyyy")
        Print_to_stats = Print_to_stats.Replace("-", " ")



        Label2.Visible = True
        Label2.Text = "Employment Statistics Report for the period " & Print_from_stats & " to " & Print_to_stats


        Dim str_stats As String

        str_stats = "SELECT Tbl_loan.customer_id,Tbl_loan.loan_id,Tbl_loan.amount,Tbl_Customer.Emp_Status FROM Tbl_loan,Tbl_Customer WHERE  Loan_Date>= '" & new_from_stats & "'  AND Loan_Date <=  '" & new_to_stats & "' and Tbl_loan.Status<>0 and Tbl_loan.Status<>2 and Tbl_Customer.customer_id=Tbl_Loan.customer_id  "

        Dim cmd_stats As New SqlCommand
        Dim ds_stats As New DataSet
        Dim adap_stats As SqlDataAdapter
        cmd_stats.Connection = open_con.return_con
        cmd_stats.CommandText = str_stats
        adap_stats = New SqlDataAdapter(cmd_stats)
        adap_stats.Fill(ds_stats)
        Dim stats_count As String
        stats_count = ds_stats.Tables(0).Rows.Count

        Dim int_parttime, int_permanent, int_casual, int_other As Integer

        If Val(stats_count) <> 0 Then
            Dim tot_stat As Integer
            tot_stat = ds_stats.Tables(0).Rows.Count
            Dim i As Integer
            For i = 0 To ds_stats.Tables(0).Rows.Count - 1

                If ds_stats.Tables(0).Rows(i).Item(3).ToString = "Part Time" Then
                    int_parttime = int_parttime + 1
                ElseIf ds_stats.Tables(0).Rows(i).Item(3).ToString = "Permanent" Then
                    int_permanent = int_permanent + 1
                ElseIf ds_stats.Tables(0).Rows(i).Item(3).ToString = "Casual" Then
                    int_casual = int_casual + 1
                Else
                    int_other = int_other + 1
                End If
            Next
            Dim per, part, cas, other As String
            per = "Permanent"
            part = "Part Time"
            cas = "Casual"
            other = "Other"

            Dim sb As New StringBuilder()

            'Response.Write("<table id='tbl' border='1' width='60%' style='font-size:16px;border:1 solid gray; border-collapse: collapse;z-index: 1; left: 285px; top:450px; position: absolute' cellpadding='0' cellspacing='0' >")
            sb.Append("<table id='tbl' cellpadding='0' cellspacing='0' class='tblreport_new' >")
            sb.Append("<tr>")
            sb.Append("<td align='left'><b>Employment Status</b></td>")
            sb.Append("<td align='right'><b>Number</b></td>")
            sb.Append("<td align='right'><b>Percentage</b></td>")
            sb.Append("</tr>")
            sb.Append("<tr>")
            sb.Append("<td align='left'>&nbsp;</td>")
            sb.Append("<td align='right'>&nbsp;</td>")
            sb.Append("<td align='right'>&nbsp; </td>")
            sb.Append("</tr>")
            sb.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_emp('" & per & "','" & new_from_stats & "','" & new_to_stats & "','" & int_permanent & "');"">")
            sb.Append("<td align='left'>Permanent</td>")
            sb.Append("<td align='right'>" & int_permanent & "</td>")
            sb.Append("<td align='right'>" & open_con.calculate_cent(int_permanent, tot_stat) & "</td>")
            sb.Append("</tr>")
            sb.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_emp('" & part & "','" & new_from_stats & "','" & new_to_stats & "','" & int_parttime & "');"">")
            sb.Append("<td align='left'>Part Time</td>")
            sb.Append("<td align='right'>" & int_parttime & "</td>")
            sb.Append("<td align='right'>" & open_con.calculate_cent(int_parttime, tot_stat) & "</td>")
            sb.Append("</tr>")
            sb.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_emp('" & cas & "','" & new_from_stats & "','" & new_to_stats & "','" & int_casual & "');"">")
            sb.Append("<td align='left'>Casual</td>")
            sb.Append("<td align='right'>" & int_casual & "</td>")
            sb.Append("<td align='right'>" & open_con.calculate_cent(int_casual, tot_stat) & "</td>")
            sb.Append("</tr>")
            sb.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_emp('" & other & "','" & new_from_stats & "','" & new_to_stats & "','" & int_other & "');"">")
            sb.Append("<td align='left'>Other</td>")
            sb.Append("<td align='right'>" & int_other & "</td>")
            sb.Append("<td align='right'>" & open_con.calculate_cent(int_other, tot_stat) & "</td>")
            sb.Append("</tr>")
            sb.Append("<tr>")
            sb.Append("<td align='right'><b>Total</b></td>")
            sb.Append("<td align='right'>" & tot_stat & "</td>")
            sb.Append("<td align='right'>100.00%</td>")
            sb.Append("</tr>")
            sb.Append("<tr>")
            sb.Append("<td colspan='14' style='border-color:white;text-align:center'>")

            sb.Append("<br/>")
            sb.Append("<br/>")

            sb.Append("<input type='button' ID='Button1'  value='Re-Create Again'  onclick='ClearTextboxes()' />")
            sb.Append("&nbsp;&nbsp;&nbsp;")
            sb.Append("<input ID='Button6' type='button' value='View & Print' onclick='return Button6_onclick()'/>")
            sb.Append("</td>")
            sb.Append("</tr>")
            sb.Append("</table >")
            Literal1.Text = sb.ToString()
        Else
            Literal1.Text = ""
            Label2.Text = " No Records for the period " & Print_from_stats & " to " & Print_to_stats & "!!!"
        End If
   
        cmd_stats.Dispose()
        ds_stats.Dispose()
        cmd_stats.Dispose()
        adap_stats.Dispose()



    End Sub

    Sub residential_stats()


        Session("loan_stats") = "true"

        Dim Print_from_stats As String
        Dim Print_to_stats As String

        Print_from_stats = txtfrom.Text
        Print_to_stats = txtto.Text

        Dim new_from_stats As String
        Dim new_to_stats As String
        new_from_stats = Date.Parse(Print_from_stats).ToString("yyyy-MM-dd")
        new_to_stats = Date.Parse(Print_to_stats).ToString("yyyy-MM-dd")
        Session("new_from_stats") = new_from_stats
        Session("new_to_stats") = new_to_stats

        Print_from_stats = Date.Parse(Print_from_stats).ToString("dd-MMM-yyyy")
        Print_from_stats = Print_from_stats.Replace("-", " ")
        Print_to_stats = Date.Parse(Print_to_stats).ToString("dd-MMM-yyyy")
        Print_to_stats = Print_to_stats.Replace("-", " ")



        Label2.Visible = True
        Label2.Text = "Residential Statistics Report for the period " & Print_from_stats & " to " & Print_to_stats


        Dim str_stats As String

        str_stats = "SELECT Tbl_loan.customer_id,Tbl_loan.loan_id,Tbl_loan.amount,Tbl_Customer.Residential_Status FROM Tbl_loan,Tbl_Customer WHERE  Loan_Date>= '" & new_from_stats & "'  AND Loan_Date <=  '" & new_to_stats & "' and Tbl_loan.Status<>0 and Tbl_loan.Status<>2 and Tbl_Customer.customer_id=Tbl_Loan.customer_id  "

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

            Dim srs As New StringBuilder()

            'Response.Write("<table id='tbl' border='1' width='60%' style='font-size:16px;border:1 solid gray; border-collapse: collapse;z-index: 1; left: 285px; top:450px; position: absolute' cellpadding='0' cellspacing='0' >")
            srs.Append("<table id='tbl' cellpadding='0' cellspacing='0' class='tblreport_new'>")
            srs.Append("<tr>")
            srs.Append("<td align='left'><b>Residential Status</b></td>")
            srs.Append("<td align='right'><b>Number</b></td>")
            srs.Append("<td align='right'><b>Percentage</b></td>")
            srs.Append("</tr>")
            srs.Append("<tr>")
            srs.Append("<td align='left'>&nbsp;</td>")
            srs.Append("<td align='right'>&nbsp;</td>")
            srs.Append("<td align='right'>&nbsp; </td>")
            srs.Append("</tr>")
            srs.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_Res('" & rent & "','" & new_from_stats & "','" & new_to_stats & "','" & int_rent & "');"">")
            srs.Append("<td align='left'>Rent</td>")
            srs.Append("<td align='right'>" & int_rent & "</td>")
            srs.Append("<td align='right'>" & open_con.calculate_cent(int_rent, tot_stat) & "</td>")
            srs.Append("</tr>")
            srs.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_Res('" & own & "','" & new_from_stats & "','" & new_to_stats & "','" & int_own & "');"">")
            srs.Append("<td align='left'>Own</td>")
            srs.Append("<td align='right'>" & int_own & "</td>")
            srs.Append("<td align='right'>" & open_con.calculate_cent(int_own, tot_stat) & "</td>")
            srs.Append("</tr>")
            srs.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_Res('" & board & "','" & new_from_stats & "','" & new_to_stats & "','" & int_boarding & "');"">")
            srs.Append("<td align='left'>Boarding</td>")
            srs.Append("<td align='right'>" & int_boarding & "</td>")
            srs.Append("<td align='right'>" & open_con.calculate_cent(int_boarding, tot_stat) & "</td>")
            srs.Append("</tr>")
            srs.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_Res('" & mort & "','" & new_from_stats & "','" & new_to_stats & "','" & int_mortgage & "');"">")
            srs.Append("<td align='left'>Mortgage</td>")
            srs.Append("<td align='right'>" & int_mortgage & "</td>")
            srs.Append("<td align='right'>" & open_con.calculate_cent(int_mortgage, tot_stat) & "</td>")
            srs.Append("</tr>")
            srs.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_Res('" & other & "','" & new_from_stats & "','" & new_to_stats & "','" & int_other & "');"">")
            srs.Append("<td align='left'>Other</td>")
            srs.Append("<td align='right'>" & int_other & "</td>")
            srs.Append("<td align='right'>" & open_con.calculate_cent(int_other, tot_stat) & "</td>")
            srs.Append("</tr>")
            srs.Append("<tr>")
            srs.Append("<td align='right'><b>Total</b></td>")
            srs.Append("<td align='right'>" & tot_stat & "</td>")
            srs.Append("<td align='right'>100.00%</td>")
            srs.Append("</tr>")
            srs.Append("<tr>")
            srs.Append("<td colspan='14' style='border-color:white;text-align:center'>")

            srs.Append("<br/>")
            srs.Append("<br/>")

            srs.Append("<input type='button' ID='Button1'  value='Re-Create Again'  onclick='ClearTextboxes()' />")
            srs.Append("&nbsp;&nbsp;&nbsp;")
            srs.Append("<input ID='Button7' type='button' value='View & Print' onclick='return Button7_onclick()'/>")
            srs.Append("</td>")
            srs.Append("</tr>")
            srs.Append("</table >")
            Literal1.Text = srs.ToString()
        Else
            Literal1.Text = ""
            Label2.Text = "No Records for the period " & Print_from_stats & " to " & Print_to_stats & "!!!"
        End If

        cmd_stats.Dispose()
        ds_stats.Dispose()
        cmd_stats.Dispose()
        adap_stats.Dispose()



    End Sub



    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged

        txtfrom.Text = ""
        txtto.Text = ""

        If RadioButtonList1.SelectedItem.Text = " Employment" Then
            panel2.Visible = True
            Label2.Visible = False
        ElseIf RadioButtonList1.SelectedItem.Text = " Residential" Then
            panel2.Visible = True
            Label2.Visible = False
        ElseIf RadioButtonList1.SelectedItem.Text = " Loans" Then
            panel2.Visible = True
            Label2.Visible = False
        ElseIf RadioButtonList1.SelectedItem.Text = " Age" Then
            panel2.Visible = True
            Label2.Visible = False
        ElseIf RadioButtonList1.SelectedItem.Text = " Gender" Then
            panel2.Visible = True
            Label2.Visible = False
        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
        End If
    End Sub
    Sub chkAdmin()
        If clsGeneral.ChkAdmin() = True Then
            Link_Administration.Visible = True
        Else
            Link_Administration.Text = "User"
            Link_Administration.PostBackUrl = "~/Customer/UpdatePassword.aspx"

        End If
    End Sub
    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub

End Class
