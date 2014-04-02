Imports System.Data.SqlClient
Imports System.Data
Partial Class Customer_letter_debit_cancel
    Inherits System.Web.UI.Page

    Dim open_con As New Class1
    Dim cmd_str, cmd_str1, cmd_debit_Notices, cmd_debit_DueDate, cmd_debit_variation, cmd_debit_dishonour As New SqlCommand
    Dim cmd_payroll_Notices, cmd_payroll_DueDate, cmd_payroll_variation, cmd_payroll_dishonour As New SqlCommand
    Dim str_adap, str1_adap, adap_debit_Notices, adap_debit_DueDate, adap_debit_variation, adap_debit_dishonour As SqlDataAdapter
    Dim adap_payroll_Notices, adap_payroll_DueDate, adap_payroll_variation, adap_payroll_dishonour As SqlDataAdapter
    Dim ds_str, ds_str1, ds_debit_Notices, ds_debit_DueDate, ds_debit_variation, ds_debit_dishonour As New DataSet
    Dim ds_payroll_Notices, ds_payroll_DueDate, ds_payroll_variation, ds_payroll_dishonour As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try

                Dim str_ACLN As String
                str_ACLN = "Australian Credit Licence Number 391104"

                Dim str, str1, str2, str3, str4, str5, str6 As String
                Dim str2_payroll, str3_payroll, str4_payroll, str5_payroll, str6_payroll As String

                str = "SELECT sys_Branch.Branch_ID, sys_User.Given_Name, sys_User.Last_Name "
                str = str & " FROM sys_Branch INNER JOIN sys_User ON sys_Branch.Branch_ID = sys_User.Branch_ID "
                str = str & " WHERE sys_User.User_Type='Manager' "
                cmd_str.CommandText = str
                cmd_str.Connection = open_con.return_con
                str_adap = New SqlDataAdapter(cmd_str)
                str_adap.Fill(ds_str)


                str1 = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val
                cmd_str1.CommandText = str1
                cmd_str1.Connection = open_con.return_con
                str1_adap = New SqlDataAdapter(cmd_str1)
                str1_adap.Fill(ds_str1)



                If Session("Description") = "Direct Debit Cancel" Then
                    Panel1.Visible = True
                    Panel2.Visible = False
                    Try
                        str2 = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Title, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Customer.M_Address,Tbl_Customer.M_Street_Name, Tbl_Customer.M_Suburb, Tbl_Customer.M_State, Tbl_Customer.M_Post_Code, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code, Tbl_Payment.Amount, Tbl_Payment.Due_Date, Tbl_Payment.Transaction_Date, Tbl_Payment.Notice_NO,Tbl_Customer.Unit_no,Tbl_Customer.M_Unit_No, "
                        str2 = str2 & " Tbl_Notice.Loan_ID, Tbl_Notice.Amount_Outstanding, Tbl_Notice.Notice_Created_On, Tbl_Notice.Notice_Created_On, Tbl_Notice.Payment_ID, Tbl_Notice.Notice_ID FROM (Tbl_Customer INNER JOIN Tbl_Payment ON Tbl_Customer.Customer_ID=Tbl_Payment.Customer_ID) INNER JOIN Tbl_Notice ON Tbl_Payment.Payment_ID=Tbl_Notice.Payment_ID "
                        str2 = str2 & " WHERE Tbl_Notice.Notice_ID = '" & Session("Notice_ID") & "'"
                        cmd_debit_Notices.CommandText = str2
                        cmd_debit_Notices.Connection = open_con.return_con
                        adap_debit_Notices = New SqlDataAdapter(cmd_debit_Notices)
                        adap_debit_Notices.Fill(ds_debit_Notices)

                        str3 = " SELECT Tbl_Payment.Due_Date FROM Tbl_Payment WHERE Loan_ID = " & ds_debit_Notices.Tables(0).Rows(0).Item("Loan_ID") & " AND Notice_NO = " & ds_debit_Notices.Tables(0).Rows(0).Item("Notice_ID") & " AND Date_Updated = '" & Date.Parse(ds_debit_Notices.Tables(0).Rows(0).Item("Transaction_Date")).ToString("yyyy-MM-dd") & "'"
                        str3 = str3 & " AND Fee_Status is NULL"
                        cmd_debit_DueDate.CommandText = str3
                        cmd_debit_DueDate.Connection = open_con.return_con
                        adap_debit_DueDate = New SqlDataAdapter(cmd_debit_DueDate)
                        adap_debit_DueDate.Fill(ds_debit_DueDate)


                        str4 = " SELECT Tbl_Payment.Amount, Tbl_Payment.Due_Date FROM Tbl_Payment WHERE Loan_ID = " & ds_debit_Notices.Tables(0).Rows(0).Item("Loan_ID") & " AND Notice_NO = " & ds_debit_Notices.Tables(0).Rows(0).Item("Notice_ID") & " AND Date_Updated = '" & Date.Parse(ds_debit_Notices.Tables(0).Rows(0).Item("Transaction_Date")).ToString("yyyy-MM-dd") & "'"
                        str4 = str4 & " AND Fee_Status = 'Variation Fee'"
                        cmd_debit_variation.CommandText = str4
                        cmd_debit_variation.Connection = open_con.return_con
                        adap_debit_variation = New SqlDataAdapter(cmd_debit_variation)
                        adap_debit_variation.Fill(ds_debit_variation)



                        Dim int_variation As Double
                        If Not ds_debit_variation.Tables(0).Rows.Count = 0 Then
                            int_variation = Math.Round(CDbl(ds_debit_variation.Tables(0).Rows(0).Item("Amount")), 2)
                        Else
                            int_variation = 0.0
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        str5 = " SELECT Tbl_Payment.Amount FROM Tbl_Payment WHERE Loan_ID = " & ds_debit_Notices.Tables(0).Rows(0).Item("Loan_ID") & " AND Notice_NO = " & ds_debit_Notices.Tables(0).Rows(0).Item("Notice_ID") & " AND Date_Updated = '" & Date.Parse(ds_debit_Notices.Tables(0).Rows(0).Item("Transaction_Date")).ToString("yyyy-MM-dd") & "'"
                        str5 = str5 & " AND Fee_Status = 'Dishonoured Fee'"

                        cmd_debit_dishonour.CommandText = str5
                        cmd_debit_dishonour.Connection = open_con.return_con
                        adap_debit_dishonour = New SqlDataAdapter(cmd_debit_dishonour)
                        adap_debit_dishonour.Fill(ds_debit_dishonour)

                        Dim int_Dishonour As Double
                        If Not ds_debit_dishonour.Tables(0).Rows.Count = 0 Then
                            int_Dishonour = Math.Round(CDbl(ds_debit_dishonour.Tables(0).Rows(0).Item("Amount")), 2)
                        Else
                            int_Dishonour = 0.0
                        End If



                        'lblstdetail.Text = ds_str1.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_str1.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_str1.Tables(0).Rows(0).Item("Suburb").ToString & ", " & ds_str1.Tables(0).Rows(0).Item("State").ToString & " " & ds_str1.Tables(0).Rows(0).Item("Post_Code").ToString
                        'lblcnctdetail.Text = "Tel: " & ds_str1.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_str1.Tables(0).Rows(0).Item("Fax_Number").ToString
                        Dim day_noticecre, month_noticecre, year_noticecre As String
                        Dim month_cre As String
                        day_noticecre = Val(Left(Date.Parse(ds_debit_Notices.Tables(0).Rows(0).Item("Notice_Created_On")).ToString("dd-MMM-yyyy"), 2))
                        month_noticecre = Date.Parse(ds_debit_Notices.Tables(0).Rows(0).Item("Notice_Created_On")).Month
                        year_noticecre = Date.Parse(ds_debit_Notices.Tables(0).Rows(0).Item("Notice_Created_On")).Year
                        Dim sup_string As String

                        If day_noticecre = 1 Then
                            sup_string = "<sup>st</sup>"
                        ElseIf day_noticecre = 21 Then
                            sup_string = "<sup>st</sup>"
                        ElseIf day_noticecre = 31 Then
                            sup_string = "<sup>st</sup>"
                        ElseIf day_noticecre = 2 Then
                            sup_string = "<sup>nd</sup>"
                        ElseIf day_noticecre = 22 Then
                            sup_string = "<sup>nd</sup>"
                        ElseIf day_noticecre = 3 Then
                            sup_string = "<sup>rd</sup>"
                        ElseIf day_noticecre = 23 Then
                            sup_string = "<sup>rd</sup>"
                        Else
                            sup_string = "<sup>th</sup>"
                        End If
                        If month_noticecre = "1" Then
                            month_cre = "January"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                            lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre


                        ElseIf month_noticecre = "2" Then
                            month_cre = "February"


                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                            lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre


                        ElseIf month_noticecre = "3" Then
                            month_cre = "March"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                            lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                        ElseIf month_noticecre = "4" Then
                            month_cre = "April"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                            lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                        ElseIf month_noticecre = "5" Then
                            month_cre = "May"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                            lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre


                        ElseIf month_noticecre = "6" Then
                            month_cre = "June"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                            lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                        ElseIf month_noticecre = "7" Then
                            month_cre = "July"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                            lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                        ElseIf month_noticecre = "8" Then
                            month_cre = "August"

                            ' Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                            lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                        ElseIf month_noticecre = "9" Then
                            month_cre = "September"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                            lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                        ElseIf month_noticecre = "10" Then
                            month_cre = "October"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                            lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                        ElseIf month_noticecre = "11" Then
                            month_cre = "November"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                            lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        ElseIf month_noticecre = "12" Then
                            month_cre = "December"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                            lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                        End If

                        lblloanid.Text = ds_debit_Notices.Tables(0).Rows(0).Item("Loan_ID")
                        lblname.Text = ds_debit_Notices.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("Last_Name").ToString

                        If ds_debit_Notices.Tables(0).Rows(0).Item("M_Address").ToString <> "" And ds_debit_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString <> "" Then

                            Dim M_Unit_No As String

                            M_Unit_No = Trim(ds_debit_Notices.Tables(0).Rows(0).Item("M_Unit_No").ToString())

                            If Len(M_Unit_No) <> 0 Then
                                lbladd.Text = ds_debit_Notices.Tables(0).Rows(0).Item("M_Unit_No").ToString & "/" & ds_debit_Notices.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("M_Street_Name").ToString
                                lblst.Text = ds_debit_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("M_Post_Code").ToString
                            Else
                                lbladd.Text = ds_debit_Notices.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("M_Street_Name").ToString
                                lblst.Text = ds_debit_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("M_Post_Code").ToString
                            End If

                        Else

                            Dim Unit_No As String

                            Unit_No = Trim(ds_debit_Notices.Tables(0).Rows(0).Item("Unit_No").ToString())

                            If Len(Unit_No) <> 0 Then
                                lbladd.Text = ds_debit_Notices.Tables(0).Rows(0).Item("Unit_No").ToString & "/" & ds_debit_Notices.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("Street_Name").ToString
                                lblst.Text = ds_debit_Notices.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("State").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("Post_Code").ToString

                            Else
                                lbladd.Text = ds_debit_Notices.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("Street_Name").ToString
                                lblst.Text = ds_debit_Notices.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("State").ToString & " " & ds_debit_Notices.Tables(0).Rows(0).Item("Post_Code").ToString

                            End If
                        End If

                        If ds_debit_Notices.Tables(0).Rows(0).Item("Title").ToString <> "" Then
                            lbltitle.Text = "Dear" & " " & ds_debit_Notices.Tables(0).Rows(0).Item("Title").ToString & "  " & ds_debit_Notices.Tables(0).Rows(0).Item("Last_Name").ToString

                        Else
                            lbltitle.Text = "Dear" & " " & ds_debit_Notices.Tables(0).Rows(0).Item("Last_Name").ToString
                        End If

                        Dim amt_notice As Double
                        amt_notice = CDbl(ds_debit_Notices.Tables(0).Rows(0).Item("Amount").ToString)
                        lblamt.Text = open_con.newamount(amt_notice)
                        Dim dt As String
                        dt = Date.Parse(ds_debit_Notices.Tables(0).Rows(0).Item("Due_Date")).ToString("dd-MMM-yyyy")
                        lbldt.Text = dt.Replace("-", " ")

                        If Val(int_variation) <> 0 Then
                            lblvar.Visible = True
                            lblvarfee.Visible = True
                            lblfeetotal.Visible = True
                            lblvarfee.Text = open_con.new_amount(CDbl(int_variation))
                        Else
                            lblvar.Visible = True
                            lblvarfee.Visible = True
                            lblfeetotal.Visible = True
                            lblvarfee.Text = "$0.00"
                        End If
                       
                        Dim redt As String
                        redt = Date.Parse(ds_debit_DueDate.Tables(0).Rows(0).Item("Due_Date")).ToString("dd-MMM-yyyy")
                        lblredt.Text = redt.Replace("-", " ")

                        Dim var_amt As Double
                        If Val(int_variation) <> 0 Then

                            var_amt = Math.Round(CDbl(ds_debit_variation.Tables(0).Rows(0).Item("Amount")), 2)
                        Else
                            var_amt = 0.0

                        End If

                        Dim dis_amt As Double
                        If Val(int_Dishonour) <> 0 Then

                            dis_amt = Math.Round(CDbl(ds_debit_dishonour.Tables(0).Rows(0).Item("Amount")), 2)
                        Else
                            dis_amt = 0.0

                        End If

                        Dim total_amt As Double
                        total_amt = Math.Round(CDbl(ds_debit_Notices.Tables(0).Rows(0).Item("Amount")), 2) + var_amt + dis_amt
                        lbltotal.Text = open_con.newamount(total_amt)
                        closs_debit_con()
                        open_con.return_con.Dispose()
                    Catch ex As Exception
                        Response.Write("Error: " & ex.Message)
                        open_con.return_con.Dispose()
                    End Try



                ElseIf Session("Description") = "Payroll Cancel" Then

                    Panel2.Visible = True
                    Panel1.Visible = False
                    Try

                        str2_payroll = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Title, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Customer.M_Address,Tbl_Customer.M_Street_Name, Tbl_Customer.M_Suburb, Tbl_Customer.M_State, Tbl_Customer.M_Post_Code, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code, Tbl_Payment.Amount, Tbl_Payment.Due_Date, Tbl_Payment.Transaction_Date, Tbl_Payment.Notice_NO,Tbl_Customer.Unit_No,Tbl_Customer.M_Unit_No, "
                        str2_payroll = str2_payroll & " Tbl_Notice.Loan_ID, Tbl_Notice.Amount_Outstanding, Tbl_Notice.Notice_Created_On, Tbl_Notice.Notice_Created_On, Tbl_Notice.Payment_ID, Tbl_Notice.Notice_ID FROM (Tbl_Customer INNER JOIN Tbl_Payment ON Tbl_Customer.Customer_ID=Tbl_Payment.Customer_ID) INNER JOIN Tbl_Notice ON Tbl_Payment.Payment_ID=Tbl_Notice.Payment_ID "
                        str2_payroll = str2_payroll & " WHERE Tbl_Notice.Notice_ID = '" & Session("Notice_ID") & "'"

                        cmd_payroll_Notices.CommandText = str2_payroll
                        cmd_payroll_Notices.Connection = open_con.return_con
                        adap_payroll_Notices = New SqlDataAdapter(cmd_payroll_Notices)
                        adap_payroll_Notices.Fill(ds_payroll_Notices)

                        str3_payroll = " SELECT Tbl_Payment.Due_Date FROM Tbl_Payment WHERE Loan_ID = " & ds_payroll_Notices.Tables(0).Rows(0).Item("Loan_ID") & " AND Notice_NO = " & ds_payroll_Notices.Tables(0).Rows(0).Item("Notice_ID") & " AND Date_Updated = '" & Date.Parse(ds_payroll_Notices.Tables(0).Rows(0).Item("Transaction_Date")).ToString("yyyy-MM-dd") & "'"
                        str3_payroll = str3_payroll & " AND Fee_Status is NULL"
                        cmd_payroll_DueDate.CommandText = str3_payroll
                        cmd_payroll_DueDate.Connection = open_con.return_con
                        adap_payroll_DueDate = New SqlDataAdapter(cmd_payroll_DueDate)
                        adap_payroll_DueDate.Fill(ds_payroll_DueDate)


                        str4_payroll = " SELECT Tbl_Payment.Amount, Tbl_Payment.Due_Date FROM Tbl_Payment WHERE Loan_ID = " & ds_payroll_Notices.Tables(0).Rows(0).Item("Loan_ID") & " AND Notice_NO = " & ds_payroll_Notices.Tables(0).Rows(0).Item("Notice_ID") & " AND Date_Updated = '" & Date.Parse(ds_payroll_Notices.Tables(0).Rows(0).Item("Transaction_Date")).ToString("yyyy-MM-dd") & "'"
                        str4_payroll = str4_payroll & " AND Fee_Status = 'Variation Fee'"

                        cmd_payroll_variation.CommandText = str4_payroll
                        cmd_payroll_variation.Connection = open_con.return_con
                        adap_payroll_variation = New SqlDataAdapter(cmd_payroll_variation)
                        adap_payroll_variation.Fill(ds_payroll_variation)



                        Dim int_variation_payroll As Double
                        If Not ds_payroll_variation.Tables(0).Rows.Count = 0 Then
                            int_variation_payroll = Math.Round(CDbl(ds_payroll_variation.Tables(0).Rows(0).Item("Amount")), 2)
                        Else
                            int_variation_payroll = 0.0
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        str5_payroll = " SELECT Tbl_Payment.Amount FROM Tbl_Payment WHERE Loan_ID= " & ds_payroll_Notices.Tables(0).Rows(0).Item("Loan_ID") & " AND Notice_NO = " & ds_payroll_Notices.Tables(0).Rows(0).Item("Notice_ID") & " AND Date_Updated = '" & Date.Parse(ds_payroll_Notices.Tables(0).Rows(0).Item("Transaction_Date")).ToString("yyyy-MM-dd") & "'"
                        str5_payroll = str5_payroll & " AND Fee_Status = 'Dishonoured Fee'"

                        cmd_payroll_dishonour.CommandText = str5_payroll
                        cmd_payroll_dishonour.Connection = open_con.return_con
                        adap_payroll_dishonour = New SqlDataAdapter(cmd_payroll_dishonour)
                        adap_payroll_dishonour.Fill(ds_payroll_dishonour)

                        Dim int_Dishonour_payroll As Double
                        If Not ds_payroll_dishonour.Tables(0).Rows.Count = 0 Then
                            int_Dishonour_payroll = Math.Round(CDbl(ds_payroll_dishonour.Tables(0).Rows(0).Item("Amount")), 2)
                        Else
                            int_Dishonour_payroll = 0.0
                        End If

                        If Val(int_Dishonour_payroll) <> 0 Then
                            lblfee1.Visible = True
                            lblfee1.Text = open_con.new_amount(CDbl(int_Dishonour_payroll))
                        Else
                            lblfee1.Visible = False
                            lblfee1.Text = "$0.00"
                        End If

                        'lblstdetail1.Text = ds_str1.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_str1.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_str1.Tables(0).Rows(0).Item("Suburb").ToString & ", " & ds_str1.Tables(0).Rows(0).Item("State").ToString & " " & ds_str1.Tables(0).Rows(0).Item("Post_Code").ToString
                        'lblcnctdetail1.Text = "Tel: " & ds_str1.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_str1.Tables(0).Rows(0).Item("Fax_Number").ToString

                        Dim day_noticecrep, month_noticecrep, year_noticecrep As String
                        Dim month_crepp As String
                        day_noticecrep = Val(Left(Date.Parse(ds_payroll_Notices.Tables(0).Rows(0).Item("Notice_Created_On")).ToString("dd-MMM-yyyy"), 2))
                        month_noticecrep = Date.Parse(ds_payroll_Notices.Tables(0).Rows(0).Item("Notice_Created_On")).Month
                        year_noticecrep = Date.Parse(ds_payroll_Notices.Tables(0).Rows(0).Item("Notice_Created_On")).Year
                        Dim sup_stringp As String
                        If day_noticecrep = 1 Then
                            sup_stringp = "<sup>st</sup>"
                        ElseIf day_noticecrep = 21 Then
                            sup_stringp = "<sup>st</sup>"
                        ElseIf day_noticecrep = 31 Then
                            sup_stringp = "<sup>st</sup>"
                        ElseIf day_noticecrep = 2 Then
                            sup_stringp = "<sup>nd</sup>"
                        ElseIf day_noticecrep = 22 Then
                            sup_stringp = "<sup>nd</sup>"
                        ElseIf day_noticecrep = 3 Then
                            sup_stringp = "<sup>rd</sup>"
                        ElseIf day_noticecrep = 23 Then
                            sup_stringp = "<sup>rd</sup>"
                        Else
                            sup_stringp = "<sup>th</sup>"
                        End If
                        If month_noticecrep = "1" Then
                            month_crepp = "January"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep & "</div>")
                            lbldate2.Text = day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep


                        ElseIf month_noticecrep = "2" Then
                            month_crepp = "February"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep & "</div>")
                            lbldate2.Text = day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep

                        ElseIf month_noticecrep = "3" Then
                            month_crepp = "March"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep & "</div>")
                            lbldate2.Text = day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep
                        ElseIf month_noticecrep = "4" Then
                            month_crepp = "April"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep & "</div>")
                            lbldate2.Text = day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep

                        ElseIf month_noticecrep = "5" Then
                            month_crepp = "May"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep & "</div>")
                            lbldate2.Text = day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep
                        ElseIf month_noticecrep = "6" Then
                            month_crepp = "June"
                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep & "</div>")
                            lbldate2.Text = day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep

                        ElseIf month_noticecrep = "7" Then
                            month_crepp = "July"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep & "</div>")
                            lbldate2.Text = day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep

                        ElseIf month_noticecrep = "8" Then
                            month_crepp = "August"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep & "</div>")
                            lbldate2.Text = day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep

                        ElseIf month_noticecrep = "9" Then
                            month_crepp = "September"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep & "</div>")
                            lbldate2.Text = day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep

                        ElseIf month_noticecrep = "10" Then
                            month_crepp = "October"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep & "</div>")
                            lbldate2.Text = day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep

                        ElseIf month_noticecrep = "11" Then
                            month_crepp = "November"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep & "</div>")
                            lbldate2.Text = day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep

                        ElseIf month_noticecrep = "12" Then
                            month_crepp = "December"

                            'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep & "</div>")
                            lbldate2.Text = day_noticecrep & sup_stringp & " " & month_crepp & " " & year_noticecrep

                        End If
                        lblloanid1.Text = ds_payroll_Notices.Tables(0).Rows(0).Item("Loan_ID")
                        lblname1.Text = ds_payroll_Notices.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("Last_Name").ToString

                        If ds_payroll_Notices.Tables(0).Rows(0).Item("M_Address").ToString <> "" And ds_payroll_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString <> "" Then
                            Dim M_Unit_No As String

                            M_Unit_No = Trim(ds_payroll_Notices.Tables(0).Rows(0).Item("M_Unit_No").ToString())
                            If Len(M_Unit_No) <> 0 Then
                                lbladd1.Text = ds_payroll_Notices.Tables(0).Rows(0).Item("M_Unit_No").ToString & "/" & ds_payroll_Notices.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("M_Street_Name").ToString
                                lblst1.Text = ds_payroll_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("M_Post_Code").ToString

                            Else
                                lbladd1.Text = ds_payroll_Notices.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("M_Street_Name").ToString
                                lblst1.Text = ds_payroll_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("M_Post_Code").ToString

                            End If

                        Else
                            Dim Unit_No As String

                            Unit_No = Trim(ds_payroll_Notices.Tables(0).Rows(0).Item("Unit_No").ToString())
                            If Len(Unit_No) <> 0 Then
                                lbladd1.Text = ds_payroll_Notices.Tables(0).Rows(0).Item("Unit_No").ToString & "/" & ds_payroll_Notices.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("Street_Name").ToString
                                lblst1.Text = ds_payroll_Notices.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("State").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("Post_Code").ToString

                            Else
                                lbladd1.Text = ds_payroll_Notices.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("Street_Name").ToString
                                lblst1.Text = ds_payroll_Notices.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("State").ToString & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("Post_Code").ToString

                            End If

                        End If

                        If ds_payroll_Notices.Tables(0).Rows(0).Item("Title").ToString <> "" Then
                            lbltitle1.Text = "Dear" & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("Title").ToString & "  " & ds_payroll_Notices.Tables(0).Rows(0).Item("Last_Name").ToString

                        Else
                            lbltitle1.Text = "Dear" & " " & ds_payroll_Notices.Tables(0).Rows(0).Item("Last_Name").ToString

                        End If
                        Dim amt_payroll As Double
                        amt_payroll = CDbl(ds_payroll_Notices.Tables(0).Rows(0).Item("Amount").ToString)
                        lblamt1.Text = open_con.newamount(amt_payroll)

                        Dim dt1 As String
                        dt1 = Date.Parse(ds_payroll_Notices.Tables(0).Rows(0).Item("Due_Date")).ToString("dd-MMM-yyyy")
                        lbldt1.Text = dt1.Replace("-", " ")



                        If Val(int_variation_payroll) <> 0 Then
                            lblvar1.Visible = True
                            lblvarfee1.Visible = True
                            lblfeetotalpay.Visible = True
                            lblvarfee1.Text = open_con.new_amount(int_variation_payroll)
                        Else
                            lblvar1.Visible = True
                            lblvarfee1.Visible = True
                            lblfeetotalpay.Visible = True
                            lblvarfee1.Text = "$0.00"
                        End If
                        lblTotal_Payroll_dish.Text = open_con.new_amount(int_variation_payroll + int_Dishonour_payroll) 'Decimal.Parse(open_con.new_amount(int_Dishonour_payroll) + open_con.new_amount(int_variation_payroll))
                        Dim redt1 As String
                        redt1 = Date.Parse(ds_payroll_DueDate.Tables(0).Rows(0).Item("Due_Date")).ToString("dd-MMM-yyyy")
                        lblredt1.Text = redt1.Replace("-", " ")
                        Dim var_amt_payroll As Double
                        If Val(int_variation_payroll) <> 0 Then

                            var_amt_payroll = Math.Round(CDbl(ds_payroll_variation.Tables(0).Rows(0).Item("Amount")), 2)
                        Else
                            var_amt_payroll = 0.0

                        End If

                        Dim dis_amt_payroll As Double
                        If Val(int_Dishonour_payroll) <> 0 Then

                            dis_amt_payroll = Math.Round(CDbl(ds_payroll_dishonour.Tables(0).Rows(0).Item("Amount")), 2)
                        Else
                            dis_amt_payroll = 0.0

                        End If
                        Dim total_amt_payroll As Double
                        total_amt_payroll = Math.Round(CDbl(ds_payroll_Notices.Tables(0).Rows(0).Item("Amount")), 2) + var_amt_payroll + dis_amt_payroll
                        lbltotal1.Text = open_con.newamount(total_amt_payroll)
                        closs_payroll_con()
                        open_con.return_con.Dispose()
                    Catch ex As Exception
                        Response.Write("Error: " & ex.Message)
                        open_con.return_con.Dispose()
                    End Try
                End If
            Catch ex As Exception
                Response.Write("Error: " & ex.Message)
                open_con.return_con.Dispose()
            End Try
        End If
    End Sub
    Sub closs_debit_con()
        cmd_str.Dispose()
        cmd_str1.Dispose()
        cmd_debit_dishonour.Dispose()
        cmd_debit_DueDate.Dispose()
        cmd_debit_Notices.Dispose()
        cmd_debit_variation.Dispose()
        ds_str.Dispose()
        ds_str1.Dispose()
        ds_debit_dishonour.Dispose()
        ds_debit_DueDate.Dispose()
        ds_debit_Notices.Dispose()
        ds_debit_variation.Dispose()
        str_adap.Dispose()
        str1_adap.Dispose()
        adap_debit_dishonour.Dispose()
        adap_debit_DueDate.Dispose()
        adap_debit_Notices.Dispose()
        adap_debit_variation.Dispose()
    End Sub
    Sub closs_payroll_con()
        cmd_str.Dispose()
        cmd_str1.Dispose()
        cmd_payroll_dishonour.Dispose()
        cmd_payroll_DueDate.Dispose()
        cmd_payroll_Notices.Dispose()
        cmd_payroll_variation.Dispose()
        ds_str.Dispose()
        ds_str1.Dispose()
        ds_payroll_dishonour.Dispose()
        ds_payroll_DueDate.Dispose()
        ds_payroll_Notices.Dispose()
        ds_payroll_variation.Dispose()
        str_adap.Dispose()
        str1_adap.Dispose()
        adap_payroll_dishonour.Dispose()
        adap_payroll_DueDate.Dispose()
        adap_payroll_Notices.Dispose()
        adap_payroll_variation.Dispose()
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
