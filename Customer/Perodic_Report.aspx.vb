Imports System.Data.SqlClient
Imports System.Data

Partial Class Customer_Perodic_Report
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
   

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            If Val(txtfrom_periodic.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            ElseIf Val(txtto_perodic.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid ending date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            ElseIf CDate(txtfrom_periodic.Text) > CDate(txtto_perodic.Text) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid future date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            Else

                Perodic_Rep()
                panel2.Visible = True


            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try


        
    End Sub

    Sub Perodic_Rep()





        Dim Print_from_perodic As String
        Dim Print_to_perodic As String

        Print_from_perodic = txtfrom_periodic.Text
        Print_to_perodic = txtto_perodic.Text

        Dim new_from_perodic As String
        Dim new_to_perodic As String
        new_from_perodic = Date.Parse(Print_from_perodic).ToString("yyyy-MM-dd")
        new_to_perodic = Date.Parse(Print_to_perodic).ToString("yyyy-MM-dd")


        Print_from_perodic = Date.Parse(Print_from_perodic).ToString("dd-MMM-yyyy")
        Print_from_perodic = Print_from_perodic.Replace("-", " ")
        Print_to_perodic = Date.Parse(Print_to_perodic).ToString("dd-MMM-yyyy")
        Print_to_perodic = Print_to_perodic.Replace("-", " ")
        Dim sb As New StringBuilder()


        Label2.Visible = True
         Label2.Text = "Periodic Financial Report for the period " & Print_from_perodic & " to " & Print_to_perodic


        Dim str_SQL_defer As String


        Dim dt1, dt2 As DateTime

        dt1 = Convert.ToDateTime(txtto_perodic.Text)
        dt2 = Convert.ToDateTime(txtfrom_periodic.Text)
        Dim i As Integer = 0

        Dim tbl As Table = New Table()
        tbl.ID = "tbl_periodic"
        tbl.Style.Add("width", "980")

        Session("tot_loan_sales") = 0
        Session("tot_Brokerage_defer") = 0
        Session("tot_Brokerage_credit") = 0
        Session("tot_of_fees") = 0
        Session("tot_of_new") = 0
        Session("tot_of_exist") = 0
        Session("tot_of_cust") = 0
        Session("rec") = 0
        Session("tot_loan_sales_tot") = 0
        Session("tot_Brokerage_defer_tot") = 0
        Session("tot_Brokerage_credit_tot") = 0
        Session("tot_of_fees_tot") = 0
        Session("tot_of_new_tot") = 0
        Session("tot_of_exist_tot") = 0
        Session("tot_of_cust_tot") = 0

        dt1 = Convert.ToDateTime(txtto_perodic.Text)
        Session("dt1") = dt1
        dt2 = Convert.ToDateTime(txtfrom_periodic.Text)
        Session("dt2") = dt2

        ' Response.Write("<body>")
        '  Response.Write("<div style='text-align:center'>")


        sb.Append("<table id='tbl' border='1' width='78%' style='font-size:16px;border:0 solid gray; border-collapse: collapse;' cellpadding='0' cellspacing='0' >")
        sb.Append("<tr>")
        sb.Append("<td style='border-color:gray;background-color:#EEEEEE;text-align :center'>")
        sb.Append("</td>")
        sb.Append("<td colspan='4' style='border-color:gray;background-color:#EEEEEE;text-align :center'>")
        sb.Append("<b>Cheque Cashed</b>")
        sb.Append("</td>")
        sb.Append("<td colspan='6' style='border-color:gray;background-color:#EEEEEE;text-align :center'>")
        sb.Append("<b>Loans</b></td>")
        sb.Append("<td colspan='2' style='border-color:gray;background-color:#EEEEEE;text-align :center'>")
        sb.Append("<b>Total</b>")
        sb.Append("</td>")
        sb.Append("</tr>")
        sb.Append("<tr>")
        sb.Append("<td  style='text-align :center;border-color:gray;width:63px'>")
        sb.Append("<b> &nbsp;&nbsp;Day/Date </b></td>")

        sb.Append("<td  style='text-align :center;border-color:gray;width:100px'>")
        sb.Append("<b>Cheque Sales</b></td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:100px'>")
        sb.Append("<b>Cheque Fees</b></td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:30px'>")
        sb.Append("<b>New</b></td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:35px'>")
        sb.Append("<b>Exist</b></td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:94px'>")
        sb.Append("<b>Loan Sales</b></td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:73px'>")
        sb.Append("<b>Defer Fee</b></td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:82px'>")
        sb.Append("<b>Credit Fee</b></td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:113px'>")
        sb.Append("<b>Sub Total Fees</b></td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:31px'>")
        sb.Append("<b>New</b></td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:34px'>")
        sb.Append("<b>Exist</b></td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:81px'>")
        sb.Append("<b>Total Fees</b></td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:75px'>")
        sb.Append("<b>Total Cust</b></td>")
        sb.Append("</tr>")
        sb.Append("<tr>")

        dt1 = Convert.ToDateTime(Session("dt1"))
        dt2 = Convert.ToDateTime(Session("dt2"))


        new_from_perodic = Date.Parse(Session("dt2")).ToString("yyyy-MM-dd")

        Do While dt1 >= dt2


            Dim cmd_perodic_credit As New SqlCommand
            Dim ds_perodic_credit As New DataSet
            Dim adap_perodic_credit As SqlDataAdapter
            Dim cmd_perodic_defer As New SqlCommand
            Dim ds_perodic_defer As New DataSet
            Dim adap_perodic_defer As SqlDataAdapter
            Dim cmd_loans_exist As New SqlCommand
            Dim ds_loans_exist As New DataSet
            Dim adap_loans_exist As SqlDataAdapter
            Dim cmd_loans_new As New SqlCommand
            Dim ds_loans_new As New DataSet
            Dim adap_loans_new As SqlDataAdapter
            Dim Loan_Sales, Brokerage_defer As Double
            Loan_Sales = 0
            Brokerage_defer = 0
            Session("Loan_Sales") = 0
            Session("Brokerage_defer") = 0
            Session("Brokerage_credit") = 0
            Session("int_Loan_New") = 0
            Session("int_Loan_exist") = 0




            str_SQL_defer = " SELECT sum(Tbl_Loan.Amount) AS Loan_Sales, sum(Tbl_Loan_Fee.Fee) AS Brokerage_defer "
            str_SQL_defer = str_SQL_defer & "  FROM Tbl_Loan INNER JOIN Tbl_Loan_Fee ON Tbl_Loan.Loan_ID = Tbl_Loan_Fee.Loan_ID "
            str_SQL_defer = str_SQL_defer & "  WHERE Tbl_Loan.Status ='1' AND (Tbl_Loan_Fee.Description = 'Application Fee' OR Tbl_Loan_Fee.Description = 'Brokerage Fee' OR Tbl_Loan_Fee.Description = 'Defer App Fee' OR Tbl_Loan_Fee.Description = 'Defer Establishment Fee' OR Tbl_Loan_Fee.Description = 'Defer EST Fee') AND  Tbl_Loan.Loan_Date = '" & new_from_perodic & "'"
            cmd_perodic_defer.Connection = open_con.return_con
            cmd_perodic_defer.CommandText = str_SQL_defer
            adap_perodic_defer = New SqlDataAdapter(cmd_perodic_defer)
            adap_perodic_defer.Fill(ds_perodic_defer)



            Dim ds_perodic_count, int_Loan_Sales, int_Brokerage_defer, int_Brokerage_credit, int_total_fee_amount, int_tot_fee As String
            ds_perodic_count = ""
            int_Loan_Sales = ""
            int_Brokerage_defer = ""
            int_Brokerage_credit = ""
            int_total_fee_amount = ""
            int_tot_fee = ""
            ds_perodic_count = ds_perodic_defer.Tables(0).Rows.Count

            If Val(ds_perodic_defer.Tables(0).Rows(0).Item("Loan_Sales").ToString) <> 0 Then

                Loan_Sales = CDbl(Session("Loan_Sales")) + CDbl(ds_perodic_defer.Tables(0).Rows(0).Item("Loan_Sales").ToString)
                Brokerage_defer = CDbl(Session("Brokerage_defer")) + CDbl(ds_perodic_defer.Tables(0).Rows(0).Item("Brokerage_defer").ToString)
                Session("tot_loan_sales") = Session("tot_loan_sales") + Loan_Sales

                Session("tot_Brokerage_defer") = Session("tot_Brokerage_defer") + Brokerage_defer

                Session("Loan_Sales") = Loan_Sales
                Session("Brokerage_defer") = Brokerage_defer

                If Val(ds_perodic_count) <> 0 Then

                    If Len(Loan_Sales) > 0 And Len(Brokerage_defer) > 0 Then
                        int_Loan_Sales = "$" & FormatNumber(ds_perodic_defer.Tables(0).Rows(0).Item("Loan_Sales").ToString, 2)
                        int_Brokerage_defer = "$" & FormatNumber(ds_perodic_defer.Tables(0).Rows(0).Item("Brokerage_defer").ToString, 2)

                    Else
                        int_Loan_Sales = ""
                        int_Brokerage_defer = ""
                    End If
                    Dim str_SQL_credit As String



                    str_SQL_credit = " SELECT Sum(Tbl_Loan_Fee.Fee) AS Brokerage_credit "
                    str_SQL_credit = str_SQL_credit & "  FROM Tbl_Loan INNER JOIN Tbl_Loan_Fee ON Tbl_Loan.Loan_ID = Tbl_Loan_Fee.Loan_ID "
                    str_SQL_credit = str_SQL_credit & "  WHERE Tbl_Loan.Status ='1' AND Tbl_Loan_Fee.Description = 'Credit Fee' AND  Tbl_Loan.Loan_Date ='" & new_from_perodic & "'"

                    cmd_perodic_credit.Connection = open_con.return_con
                    cmd_perodic_credit.CommandText = str_SQL_credit
                    adap_perodic_credit = New SqlDataAdapter(cmd_perodic_credit)
                    adap_perodic_credit.Fill(ds_perodic_credit)

                    Dim ds_perodic_crecount As String

                    ds_perodic_crecount = ds_perodic_credit.Tables(0).Rows.Count

                    Dim Brokerage_credit As Double

                    Brokerage_credit = CDbl(Session("Brokerage_credit")) + CDbl(ds_perodic_credit.Tables(0).Rows(0).Item("Brokerage_credit").ToString)

                    Session("Brokerage_credit") = Brokerage_credit
                    Session("tot_Brokerage_credit") = Session("tot_Brokerage_credit") + Brokerage_credit

                    Dim total_fee_amount As Double


                    total_fee_amount = Brokerage_defer + Brokerage_credit



                    Session("tot_of_fees") = Session("tot_of_fees") + total_fee_amount


                    int_Brokerage_credit = "$" & FormatNumber(ds_perodic_credit.Tables(0).Rows(0).Item("Brokerage_credit").ToString, 2)
                    int_tot_fee = "$" & total_fee_amount
                    int_total_fee_amount = "$" & FormatNumber(total_fee_amount, 2)






                    Dim new_cust, exist_cust As Integer

                    Dim str_SQL_new_cust As String
                    str_SQL_new_cust = " SELECT Count(Tbl_Loan.Customer_ID) AS New_Customers FROM Tbl_Loan "
                    str_SQL_new_cust = str_SQL_new_cust & " WHERE Tbl_Loan.Loan_Date = '" & new_from_perodic & "' AND Tbl_Loan.Status ='1' AND"
                    str_SQL_new_cust = str_SQL_new_cust & " Tbl_Loan.Customer_ID NOT IN (Select Customer_ID FROM Tbl_Loan WHERE Tbl_Loan.Loan_Date < '" & new_from_perodic & "' AND Tbl_Loan.Status ='1') "

                    cmd_loans_new.Connection = open_con.return_con
                    cmd_loans_new.CommandText = str_SQL_new_cust
                    adap_loans_new = New SqlDataAdapter(cmd_loans_new)
                    adap_loans_new.Fill(ds_loans_new)

                    new_cust = CInt(ds_loans_new.Tables(0).Rows(0).Item(0).ToString)
                    Dim int_Loan_New As Integer

                    If new_cust > 0 Then
                        int_Loan_New = new_cust
                        Session("int_Loan_New") = new_cust

                        Session("tot_of_new") = Session("tot_of_new") + int_Loan_New

                    Else
                        int_Loan_New = 0
                    End If

                    Dim str_SQL_exist_cust As String
                    str_SQL_exist_cust = " SELECT Count(Tbl_Loan.Customer_ID) AS Exist_Customers FROM Tbl_Loan "
                    str_SQL_exist_cust = str_SQL_exist_cust & " WHERE Tbl_Loan.Loan_Date=  '" & new_from_perodic & "' AND Tbl_Loan.Status ='1' AND "
                    str_SQL_exist_cust = str_SQL_exist_cust & " Tbl_Loan.Customer_ID IN (Select Customer_ID FROM Tbl_Loan WHERE Tbl_Loan.Loan_Date <  '" & new_from_perodic & "' AND Tbl_Loan.Status ='1') "


                    cmd_loans_exist.Connection = open_con.return_con
                    cmd_loans_exist.CommandText = str_SQL_exist_cust
                    adap_loans_exist = New SqlDataAdapter(cmd_loans_exist)
                    adap_loans_exist.Fill(ds_loans_exist)

                    exist_cust = CInt(ds_loans_exist.Tables(0).Rows(0).Item(0).ToString)
                    Dim int_Loan_exist As Integer

                    If exist_cust > 0 Then
                        int_Loan_exist = exist_cust
                        Session("int_Loan_exist") = exist_cust
                        Session("tot_of_exist") = Session("tot_of_exist") + int_Loan_exist

                    Else
                        int_Loan_exist = 0
                    End If

                    Dim tot As Integer
                    Dim new_customer, old_customer As Integer
                    new_customer = Session("int_Loan_New")
                    old_customer = Session("int_Loan_exist")
                    tot = new_customer + old_customer
                    Session("tot_of_cust") = Session("tot_of_cust") + tot

                    ''''''''''''''''''''''''''''''''''''''''''

                    sb.Append("<td style='text-align :center;border-color:gray;width:63px'>")
                    sb.Append("&nbsp;&nbsp;&nbsp;" & open_con.check_day_name(dt2.Date.DayOfWeek))
                    If open_con.check_day_name(dt2.Date.DayOfWeek) = "Mon" Then
                        sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                    ElseIf open_con.check_day_name(dt2.Date.DayOfWeek) = "Tue" Then
                        sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                    ElseIf open_con.check_day_name(dt2.Date.DayOfWeek) = "Wed" Then
                        sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                    ElseIf open_con.check_day_name(dt2.Date.DayOfWeek) = "Thu" Then
                        sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                    ElseIf open_con.check_day_name(dt2.Date.DayOfWeek) = "Fri" Then
                        sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                    ElseIf open_con.check_day_name(dt2.Date.DayOfWeek) = "Sat" Then
                        sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                    ElseIf open_con.check_day_name(dt2.Date.DayOfWeek) = "Sun" Then
                        sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                    End If

                    sb.Append("<td  style='text-align :center;border-color:gray;width:100px'>")
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :center;border-color:gray;width:100px'>")
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :center;border-color:gray;width:30px'>")
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :center;border-color:gray;width:35px'>")
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :right;border-color:gray;width:94px'>")
                    sb.Append(int_Loan_Sales)
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :right;border-color:gray;width:73px'>")
                    sb.Append(int_Brokerage_defer)
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :right;border-color:gray;width:82px'>")
                    sb.Append(int_Brokerage_credit)
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :right;border-color:gray;width:113px'>")
                    sb.Append(int_total_fee_amount)
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :center;border-color:gray;width:31px'>")
                    sb.Append(new_customer)
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :center;border-color:gray;width:34px'>")
                    sb.Append(old_customer)
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :right;border-color:gray;width:81px'>")
                    sb.Append(int_tot_fee)
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :center;border-color:gray;width:75px'>")
                    sb.Append(tot)
                    sb.Append("</td>")
                    sb.Append("</tr>")

                    '''''''''''''''''''''''

                    If open_con.check_day_name(dt2.Date.DayOfWeek) = "Sat" Then
                        sb.Append("<tr style='font-weight:bold'>")
                        sb.Append("<td  style='text-align :center;border-color:gray;width:63px'>")
                        sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;Total")
                        sb.Append("</td>")

                        sb.Append("<td  style='text-align :center;border-color:gray;width:100px'>")
                        sb.Append("</td>")
                        sb.Append("<td style='text-align :center;border-color:gray;width:100px'>")
                        sb.Append("</td>")
                        sb.Append("<td style='text-align :center;border-color:gray;width:30px'>")
                        sb.Append("</td>")
                        sb.Append("<td style='text-align :center;border-color:gray;width:35px'>")
                        sb.Append("</td>")
                        sb.Append("<td style='text-align :right;border-color:gray;width:94px'>")
                        sb.Append("$" & FormatNumber(Session("tot_loan_sales"), 2))
                        sb.Append("</td>")
                        sb.Append("<td style='text-align :right;border-color:gray;width:73px'>")
                        sb.Append("$" & FormatNumber(Session("tot_Brokerage_defer"), 2))
                        sb.Append("</td>")
                        sb.Append("<td style='text-align :right;border-color:gray;width:82px'>")
                        sb.Append("$" & FormatNumber(Session("tot_Brokerage_credit"), 2))
                        sb.Append("</td>")
                        sb.Append("<td style='text-align :right;border-color:gray;width:113px'>")
                        sb.Append("$" & FormatNumber(Session("tot_of_fees"), 2))
                        sb.Append("</td>")
                        sb.Append("<td style='text-align :center;border-color:gray;width:31px'>")
                        sb.Append(Session("tot_of_new"))
                        sb.Append("</td>")
                        sb.Append("<td style='text-align :center;border-color:gray;width:34px'>")
                        sb.Append(Session("tot_of_exist"))
                        sb.Append("</td>")
                        sb.Append("<td style='text-align :right;border-color:gray;width:81px'>")
                        sb.Append("$" & FormatNumber(Session("tot_of_fees"), 2))
                        sb.Append("</td>")
                        sb.Append("<td style='text-align :center;border-color:gray;width:75px'>")
                        sb.Append(Session("tot_of_cust"))
                        sb.Append("</td>")
                        sb.Append("</tr>")
                        Session("tot_loan_sales_tot") = Session("tot_loan_sales_tot") + Session("tot_loan_sales")
                        Session("tot_Brokerage_defer_tot") = Session("tot_Brokerage_defer_tot") + Session("tot_Brokerage_defer")
                        Session("tot_Brokerage_credit_tot") = Session("tot_Brokerage_credit_tot") + Session("tot_Brokerage_credit")
                        Session("tot_of_fees_tot") = Session("tot_of_fees_tot") + Session("tot_of_fees")
                        Session("tot_of_new_tot") = Session("tot_of_new_tot") + Session("tot_of_new")
                        Session("tot_of_exist_tot") = Session("tot_of_exist_tot") + Session("tot_of_exist")
                        Session("tot_of_cust_tot") = Session("tot_of_cust_tot") + Session("tot_of_cust")
                        Session("tot_loan_sales") = 0
                        Session("tot_Brokerage_defer") = 0
                        Session("tot_Brokerage_credit") = 0
                        Session("tot_of_fees") = 0
                        Session("tot_of_new") = 0
                        Session("tot_of_exist") = 0
                        Session("tot_of_cust") = 0
                    End If


                Else




                End If





             Else


                sb.Append("<td style='text-align :center;border-color:gray;width:63px'>")
                sb.Append("&nbsp;&nbsp;&nbsp;" & open_con.check_day_name(dt2.Date.DayOfWeek))
                If open_con.check_day_name(dt2.Date.DayOfWeek) = "Mon" Then
                    sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                ElseIf open_con.check_day_name(dt2.Date.DayOfWeek) = "Tue" Then
                    sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                ElseIf open_con.check_day_name(dt2.Date.DayOfWeek) = "Wed" Then
                    sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                ElseIf open_con.check_day_name(dt2.Date.DayOfWeek) = "Thu" Then
                    sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                ElseIf open_con.check_day_name(dt2.Date.DayOfWeek) = "Fri" Then
                    sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                ElseIf open_con.check_day_name(dt2.Date.DayOfWeek) = "Sat" Then
                    sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                ElseIf open_con.check_day_name(dt2.Date.DayOfWeek) = "Sun" Then
                    sb.Append("&nbsp;" & Val(Left(dt2.Date, 2)) & open_con.check_day_new(dt2.Date) & "</td>")
                End If
                sb.Append("<td  style='text-align :center;border-color:gray;width:100px'>")
                sb.Append("</td>")
                sb.Append("<td style='text-align :center;border-color:gray;width:100px'>")
                sb.Append("</td>")
                sb.Append("<td style='text-align :center;border-color:gray;width:30px'>")
                sb.Append("</td>")
                sb.Append("<td style='text-align :center;border-color:gray;width:35px'>")
                sb.Append("</td>")
                sb.Append("<td style='text-align :right;border-color:gray;width:94px'>")
                sb.Append("")
                sb.Append("</td>")
                sb.Append("<td style='text-align :right;border-color:gray;width:73px'>")
                sb.Append("")
                sb.Append("</td>")
                sb.Append("<td style='text-align :right;border-color:gray;width:82px'>")
                sb.Append("")
                sb.Append("</td>")
                sb.Append("<td style='text-align :right;border-color:gray;width:113px'>")
                sb.Append("")
                sb.Append("</td>")
                sb.Append("<td style='text-align :center;border-color:gray;width:31px'>")
                sb.Append("")
                sb.Append("</td>")
                sb.Append("<td style='text-align :center;border-color:gray;width:34px'>")
                sb.Append("")
                sb.Append("</td>")
                sb.Append("<td style='text-align :right;border-color:gray;width:81px'>")
                sb.Append("")
                sb.Append("</td>")
                sb.Append("<td style='text-align :center;border-color:gray;width:75px'>")
                sb.Append("")
                sb.Append("</td>")
                sb.Append("</tr>")

                If open_con.check_day_name(dt2.Date.DayOfWeek) = "Sat" And dt1 <> dt2 Then

                    sb.Append("<tr style='font-weight:bold'>")
                    sb.Append("<td  style='text-align :center;border-color:gray;width:63px'>")
                    sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;Total")
                    sb.Append("</td>")
                    sb.Append("<td  style='text-align :center;border-color:gray;width:100px'>")
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :center;border-color:gray;width:100px'>")
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :center;border-color:gray;width:30px'>")
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :center;border-color:gray;width:35px'>")
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :right;border-color:gray;width:94px'>")
                    sb.Append("$" & FormatNumber(Session("tot_loan_sales"), 2))
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :right;border-color:gray;width:73px'>")
                    sb.Append("$" & FormatNumber(Session("tot_Brokerage_defer"), 2))
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :right;border-color:gray;width:82px'>")
                    sb.Append("$" & FormatNumber(Session("tot_Brokerage_credit"), 2))
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :right;border-color:gray;width:113px'>")
                    sb.Append("$" & FormatNumber(Session("tot_of_fees"), 2))
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :center;border-color:gray;width:31px'>")
                    sb.Append(Session("tot_of_new"))
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :center;border-color:gray;width:34px'>")
                    sb.Append(Session("tot_of_exist"))
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :right;border-color:gray;width:81px'>")
                    sb.Append("$" & FormatNumber(Session("tot_of_fees"), 2))
                    sb.Append("</td>")
                    sb.Append("<td style='text-align :center;border-color:gray;width:75px'>")
                    sb.Append(Session("tot_of_cust"))
                    sb.Append("</td>")
                    sb.Append("</tr>")

                    Session("tot_loan_sales_tot") = Session("tot_loan_sales_tot") + Session("tot_loan_sales")
                    Session("tot_Brokerage_defer_tot") = Session("tot_Brokerage_defer_tot") + Session("tot_Brokerage_defer")
                    Session("tot_Brokerage_credit_tot") = Session("tot_Brokerage_credit_tot") + Session("tot_Brokerage_credit")
                    Session("tot_of_fees_tot") = Session("tot_of_fees_tot") + Session("tot_of_fees")
                    Session("tot_of_new_tot") = Session("tot_of_new_tot") + Session("tot_of_new")
                    Session("tot_of_exist_tot") = Session("tot_of_exist_tot") + Session("tot_of_exist")
                    Session("tot_of_cust_tot") = Session("tot_of_cust_tot") + Session("tot_of_cust")
                    Session("tot_loan_sales") = 0
                    Session("tot_Brokerage_defer") = 0
                    Session("tot_Brokerage_credit") = 0
                    Session("tot_of_fees") = 0
                    Session("tot_of_new") = 0
                    Session("tot_of_exist") = 0
                    Session("tot_of_cust") = 0


                End If
                End If






                cmd_perodic_defer.Dispose()
                ds_perodic_defer.Dispose()
                cmd_perodic_defer.Dispose()
                cmd_perodic_credit.Dispose()
                ds_perodic_credit.Dispose()
                cmd_perodic_credit.Dispose()
                cmd_loans_exist.Dispose()
                cmd_loans_new.Dispose()
                ds_loans_exist.Dispose()
                ds_loans_new.Dispose()


          


            If i = 0 Then
                dt2 = Convert.ToDateTime(Session("dt2"))
            Else
            End If

            dt2 = dt2.AddDays(1)
            new_from_perodic = Date.Parse(dt2).ToString("yyyy-MM-dd")
            i = i + 1
        Loop
        Session("tot_loan_sales_tot") = Session("tot_loan_sales_tot") + Session("tot_loan_sales")
        Session("tot_Brokerage_defer_tot") = Session("tot_Brokerage_defer_tot") + Session("tot_Brokerage_defer")
        Session("tot_Brokerage_credit_tot") = Session("tot_Brokerage_credit_tot") + Session("tot_Brokerage_credit")
        Session("tot_of_fees_tot") = Session("tot_of_fees_tot") + Session("tot_of_fees")
        Session("tot_of_new_tot") = Session("tot_of_new_tot") + Session("tot_of_new")
        Session("tot_of_exist_tot") = Session("tot_of_exist_tot") + Session("tot_of_exist")
        Session("tot_of_cust_tot") = Session("tot_of_cust_tot") + Session("tot_of_cust")

        sb.Append("<tr style='font-weight:bold'>")
        sb.Append("<td  style='text-align :center;border-color:gray;width:63px'>")
        sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;Total")
        sb.Append("</td>")

        sb.Append("<td  style='text-align :center;border-color:gray;width:100px'>")
        sb.Append("</td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:100px'>")
        sb.Append("</td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:30px'>")
        sb.Append("</td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:35px'>")
        sb.Append("</td>")
        sb.Append("<td style='text-align :right;border-color:gray;width:94px'>")
        sb.Append("$" & FormatNumber(Session("tot_loan_sales"), 2))
        sb.Append("</td>")
        sb.Append("<td style='text-align :right;border-color:gray;width:73px'>")
        sb.Append("$" & FormatNumber(Session("tot_Brokerage_defer"), 2))
        sb.Append("</td>")
        sb.Append("<td style='text-align :right;border-color:gray;width:82px'>")
        sb.Append("$" & FormatNumber(Session("tot_Brokerage_credit"), 2))
        sb.Append("</td>")
        sb.Append("<td style='text-align :right;border-color:gray;width:113px'>")
        sb.Append("$" & FormatNumber(Session("tot_of_fees"), 2))
        sb.Append("</td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:31px'>")
        sb.Append(Session("tot_of_new"))
        sb.Append("</td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:34px'>")
        sb.Append(Session("tot_of_exist"))
        sb.Append("</td>")
        sb.Append("<td style='text-align :right;border-color:gray;width:81px'>")
        sb.Append("$" & FormatNumber(Session("tot_of_fees"), 2))
        sb.Append("</td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:75px'>")
        sb.Append(Session("tot_of_cust"))
        sb.Append("</td>")
        sb.Append("</tr>")



       


        sb.Append("<tr  style='text-align:center;font-weight:bold;background-color:#EEEEEE'>")
        sb.Append("<td  style='text-align :center;border-color:gray;width:63px'>&nbsp;&nbsp;&nbsp;")
        sb.Append("Grand")
        sb.Append("<br/>")
        sb.Append("&nbsp;&nbsp;&nbsp;" & "Total")
        sb.Append("</td>")

        sb.Append("<td  style='text-align :center;border-color:gray;width:100px'>")
        sb.Append("$" & FormatNumber(0, 2))
        sb.Append("</td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:100px'>")
        sb.Append("$" & FormatNumber(0, 2))
        sb.Append("</td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:30px'>")
        sb.Append("0")
        sb.Append("</td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:35px'>")
        sb.Append("0")
        sb.Append("</td>")
        sb.Append("<td style='text-align :right;border-color:gray;width:94px'>")
        sb.Append("$" & FormatNumber(Session("tot_loan_sales_tot"), 2))
        sb.Append("</td>")
        sb.Append("<td style='text-align :right;border-color:gray;width:73px'>")
        sb.Append("$" & FormatNumber(Session("tot_Brokerage_defer_tot"), 2))
        sb.Append("</td>")
        sb.Append("<td style='text-align :right;border-color:gray;width:82px'>")
        sb.Append("$" & FormatNumber(Session("tot_Brokerage_credit_tot"), 2))
        sb.Append("</td>")
        sb.Append("<td style='text-align :right;border-color:gray;width:113px'>")
        sb.Append("$" & FormatNumber(Session("tot_of_fees_tot"), 2))
        sb.Append("</td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:31px'>")
        sb.Append(Session("tot_of_new_tot"))
        sb.Append("</td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:34px'>")
        sb.Append(Session("tot_of_exist_tot"))
        sb.Append("</td>")
        sb.Append("<td style='text-align :right;border-color:gray;width:81px'>")
        sb.Append("$" & FormatNumber(Session("tot_of_fees_tot"), 2))
        sb.Append("</td>")
        sb.Append("<td style='text-align :center;border-color:gray;width:75px'>")
        sb.Append(Session("tot_of_cust_tot"))
        sb.Append("</td>")
        sb.Append("</tr>")


        sb.Append("<td colspan='14'  style='text-align:center;border-color:white'>")

        sb.Append("<br/>")
        sb.Append("<br/>")

        sb.Append("<input type='button' ID='Button1'  value='Re-Create Again'   onclick='return ClearTextboxes() ' />")
        sb.Append("&nbsp;&nbsp;&nbsp;")
        sb.Append("<input ID='Button2' type='button' value='View & Print' onclick='return Button2_onclick()'/>")
        sb.Append("</td>")
        sb.Append("</tr>")



        sb.Append("</table>")
        ' sb.Append("</div>")
        '  sb.Append("</body>")
        open_con.return_con.Dispose()
        Literal1.Text = sb.ToString()

    End Sub


    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
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
