Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Customer_Bank_File_NAB
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Dim nab_date As String
     Dim str_Filepath As String
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Confirms that an HtmlForm control is rendered for the specified ASP.NET server control at run time.
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Txt_date.Text = "" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a date!!!" & "');", True)
                Exit Sub
            ElseIf CDate(Txt_date.Text) < System.DateTime.Now.Date Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid future date!!!" & "');", True)
                GridView1.Visible = False
                Exit Sub
            ElseIf Val(Txt_date.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                GridView1.Visible = False
                Exit Sub
            Else
                grid_databind()
            End If
        Catch ex As Exception
            Response.Write("Error : " & ex.Message)
        End Try
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.Cells.Item(3).Text = "&nbsp;" Then
            e.Row.Cells(3).Text = ""
        ElseIf e.Row.Cells.Item(3).Text = "Amount" Then
            e.Row.Cells.Item(3).Text = "Amount"
        Else
            e.Row.Cells(3).Text = CStr(e.Row.Cells(3).Text.ToString)
        End If
        If (e.Row.RowType = DataControlRowType.Footer) Then
            e.Row.Cells(0).ColumnSpan = 3
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).Style.Add("text-align", "right")
            e.Row.Cells(1).ColumnSpan = 1
            e.Row.Cells(1).Text = "$ " & Session("tot_nab_amt")
            e.Row.Cells.RemoveAt(4)
            e.Row.Cells.RemoveAt(5)
        End If
    End Sub
    Protected Sub cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancel.Click
        Response.Redirect("AddSearch.aspx", False)
    End Sub
    Sub grid_databind()

        nab_date = Date.Parse(Txt_date.Text).ToString("yyyy-MM-dd")
        Session("nab_date") = nab_date
        Dim cmd_nab, cmd_nab_new As New SqlCommand
        Dim str_nab, str_nab_new As String
        Dim cmd_pay As New SqlCommand
        cmd_pay.Connection = open_con.return_con
        cmd_pay.CommandText = "update tbl_payment set description=null where description='' and due_date = '" & nab_date & "'"
        cmd_pay.ExecuteNonQuery()
        cmd_pay.Dispose()
        str_nab = "SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Given_Name, Tbl_Customer.Last_Name, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Bank_Account.BSB, Tbl_Loan.Loan_ID, Tbl_Loan.Loan_Type, Tbl_Payment.Amount, Tbl_Payment.Due_Date, Tbl_Payment.Payment_Method, Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.BSB"
        str_nab = str_nab & " FROM ((Tbl_Customer INNER JOIN Tbl_Loan ON Tbl_Customer.Customer_ID = Tbl_Loan.Customer_ID) INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID) ON Tbl_Loan.Loan_ID = Tbl_Payment.Loan_ID) INNER JOIN Tbl_Bank_Account ON Tbl_Loan.Bank_Account_ID = Tbl_Bank_Account.Bank_Account_ID "
        str_nab = str_nab & " WHERE (((Tbl_Payment.Amount)<>0) AND ((Tbl_Payment.Due_Date)='" & nab_date & "') AND ((Tbl_Payment.Payment_Method)='NAB') AND ((Tbl_Payment_1.Update_ID) Is Null) AND ((Tbl_Loan.Status)='1') AND ((Tbl_Payment.Description)='Arear notice fee' Or (Tbl_Payment.Description)='Statement of account fee' Or (Tbl_Payment.Description)='Variation fee' Or (Tbl_Payment.Description)='Default notice fee' Or (Tbl_Payment.Description)='Letter of demand fee' Or (Tbl_Payment.Description)='Dishonoured fee' Or (Tbl_Payment.Description)='Enforcement fee' Or (Tbl_Payment.Description) Is Null) AND ((Tbl_Payment.Transaction_Status) Is Null) AND ((Tbl_Payment.Payment_Date) Is Null or (Tbl_Payment.Payment_Date) =''  )) "
        str_nab = str_nab & "ORDER BY Tbl_Customer.Last_Name, Tbl_Customer.Given_Name "

        cmd_nab.CommandText = str_nab
        cmd_nab.Connection = open_con.return_con
        Dim dataadap_nab As SqlDataAdapter
        Dim ds_nab As New DataSet
        dataadap_nab = New SqlDataAdapter(cmd_nab)
        dataadap_nab.Fill(ds_nab)

        str_nab_new = "Select sum(tbl_payment.amount)"
        str_nab_new = str_nab_new & "FROM ((Tbl_Customer INNER JOIN Tbl_Loan ON Tbl_Customer.Customer_ID = Tbl_Loan.Customer_ID) INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID) ON Tbl_Loan.Loan_ID = Tbl_Payment.Loan_ID) INNER JOIN Tbl_Bank_Account ON Tbl_Loan.Bank_Account_ID = Tbl_Bank_Account.Bank_Account_ID "
        str_nab_new = str_nab_new & " WHERE (((Tbl_Payment.Amount)<>0) AND ((Tbl_Payment.Due_Date)='" & nab_date & "') AND ((Tbl_Payment.Payment_Method)='NAB') AND ((Tbl_Payment_1.Update_ID) Is Null) AND ((Tbl_Loan.Status)='1') AND ((Tbl_Payment.Description)='Arear notice fee' Or (Tbl_Payment.Description)='Statement of account fee' Or (Tbl_Payment.Description)='Variation fee' Or (Tbl_Payment.Description)='Default notice fee' Or (Tbl_Payment.Description)='Letter of demand fee' Or (Tbl_Payment.Description)='Dishonoured fee' Or (Tbl_Payment.Description)='Enforcement fee' Or (Tbl_Payment.Description) Is Null) AND ((Tbl_Payment.Transaction_Status) Is Null) AND ((Tbl_Payment.Payment_Date) Is Null)) "

        cmd_nab_new.CommandText = str_nab_new
        cmd_nab_new.Connection = open_con.return_con
        Dim dataadap_nab_new As SqlDataAdapter
        Dim ds_nab_new As New DataSet
        dataadap_nab_new = New SqlDataAdapter(cmd_nab_new)
        dataadap_nab_new.Fill(ds_nab_new)
        Dim tot_nab_amt As String
        If ds_nab.Tables(0).Rows.Count = 0 Then
            GridView1.Visible = False
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "There are no direct debit payments due on " & Txt_date.Text & "');", True)
            Txt_date.Text = ""
            nab_print.Visible = False
            cancel.Visible = False
            debit_nab.Visible = False
            cmd_nab.Dispose()
            cmd_nab_new.Dispose()
            ds_nab.Dispose()
            ds_nab_new.Dispose()
            dataadap_nab.Dispose()
            dataadap_nab_new.Dispose()
            open_con.return_con.Dispose()
            Exit Sub
        Else

            tot_nab_amt = ds_nab_new.Tables(0).Rows(0).Item(0).ToString

            Dim pos_dot As Integer
            pos_dot = InStr(1, tot_nab_amt, ".")
            If pos_dot = 0 Then
                tot_nab_amt = tot_nab_amt & "00"
            ElseIf pos_dot > 0 Then
                Dim right_amt As String
                Dim left_amt As String
                right_amt = Mid(tot_nab_amt, pos_dot + 1, 2)
                If Len(right_amt) = 1 Then
                    tot_nab_amt = tot_nab_amt & "0"
                Else
                    left_amt = Mid(tot_nab_amt, 1, pos_dot)
                    tot_nab_amt = left_amt & right_amt
                End If

            End If
            Session("tot_nab_amt") = tot_nab_amt
            GridView1.Visible = True
            GridView1.DataSource = ds_nab
            GridView1.DataBind()
            nab_print.Visible = True
            cancel.Visible = True
            debit_nab.Visible = True
            cmd_nab.Dispose()
            cmd_nab_new.Dispose()
            ds_nab.Dispose()
            ds_nab_new.Dispose()
            dataadap_nab.Dispose()
            dataadap_nab_new.Dispose()
            open_con.return_con.Dispose()
            open_con.return_con.Dispose()
        End If

    End Sub

    Protected Sub nab_print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles nab_print.Click
        Response.Redirect("../Reports/NAB_rep.aspx", False)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()

        If Not IsPostBack Then
            'ViewState("SortExpr") = Sort_Direction
            Dim dv As DataView = Getdata()
            GridView_nab.DataSource = dv
            GridView_nab.DataBind()
        End If

        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            If bind_grid() = True Then
                Label_nab.Visible = True
                Button_ShowAll.Visible = True
            Else
                Label_nab.Visible = False
                Button_ShowAll.Visible = False
            End If

            nab_print.Visible = False
            cancel.Visible = False
            debit_nab.Visible = False
        End If
    End Sub
    Protected Sub debit_nab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles debit_nab.Click
        Try

            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then

                Dim str_Entry_Type_0, str_Entry_Type_1, str_Entry_Type_7, str_abaFileName, str_FileName As String
                Dim str_SQL_nab As String
                Dim bln_CreatFile As Boolean
                Dim int_Counter, int_record As Integer
                Dim fs As FileStream = Nothing
                Dim oWrite As System.IO.StreamWriter = Nothing
                Dim new_total1 As String
                Dim new_total2 As String
                nab_date = Date.Parse(Txt_date.Text).ToString("yyyy-MM-dd")
                If Txt_date.Text <> "" Then
                    If Day(Trim(Txt_date.Text)) < 10 Then
                        str_FileName = "0" & Day(Txt_date.Text)
                    Else
                        str_FileName = Day(Txt_date.Text)
                    End If
                    If Month(Trim(Txt_date.Text)) < 10 Then
                        str_FileName = str_FileName & "0" & Month(Txt_date.Text)
                    Else
                        str_FileName = str_FileName & Month(Txt_date.Text)
                    End If
                    str_FileName = str_FileName & Right(Year(Txt_date.Text), 2)
                    Session(" str_FileName") = str_FileName
                End If

                Dim cmd_nab_branch As New SqlCommand

                cmd_nab_branch.CommandText = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val
                cmd_nab_branch.Connection = open_con.return_con

                Dim adap_nab_branch As SqlDataAdapter
                Dim ds_nab_branch As New DataSet
                Dim int_Total As Single
                adap_nab_branch = New SqlDataAdapter(cmd_nab_branch)
                adap_nab_branch.Fill(ds_nab_branch)

                Dim branch_count As String
                branch_count = ds_nab_branch.Tables(0).Rows.Count.ToString

                If Val(branch_count) <> 0 Then
                    Dim cmd_Customer_List As New SqlCommand
                    Dim adap_Customer_List As SqlDataAdapter
                    Dim ds_Customer_List As New DataSet



                    str_SQL_nab = " SELECT Tbl_Customer.Customer_ID,Tbl_Loan.Loan_ID,Tbl_Payment.Payment_ID, Tbl_Customer.Given_Name, Tbl_Customer.Last_Name, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Bank_Account.BSB,  Tbl_Loan.Loan_Type, Tbl_Payment.Amount, Tbl_Payment.Due_Date, Tbl_Payment.Payment_Method, Tbl_Bank_Account.Account_Name, Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.BSB "
                    str_SQL_nab = str_SQL_nab & " FROM ((Tbl_Customer INNER JOIN Tbl_Loan ON Tbl_Customer.Customer_ID = Tbl_Loan.Customer_ID) INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID) ON Tbl_Loan.Loan_ID = Tbl_Payment.Loan_ID) INNER JOIN Tbl_Bank_Account ON Tbl_Loan.Bank_Account_ID = Tbl_Bank_Account.Bank_Account_ID "
                    str_SQL_nab = str_SQL_nab & " WHERE (((Tbl_Payment.Amount)<>0) AND ((Tbl_Payment.Due_Date)='" & nab_date & "')  AND ((Tbl_Payment.Payment_Method)='NAB') AND ((Tbl_Payment_1.Update_ID) Is Null) AND ((Tbl_Loan.Status)='1') AND ((Tbl_Payment.Description)='Arear notice fee' Or (Tbl_Payment.Description)='Statement of account fee' Or (Tbl_Payment.Description)='Variation fee' Or (Tbl_Payment.Description)='Enforcement fee' Or (Tbl_Payment.Description)='Default notice fee' Or (Tbl_Payment.Description)='Letter of demand fee' Or (Tbl_Payment.Description)='Dishonoured fee' Or (Tbl_Payment.Description) Is Null) AND ((Tbl_Payment.Transaction_Status) Is Null) AND ((Tbl_Payment.Payment_Date) Is Null or (Tbl_Payment.Payment_Date) =''  )) "
                    str_SQL_nab = str_SQL_nab & " ORDER BY Tbl_Customer.Customer_ID "
                    cmd_Customer_List.CommandText = str_SQL_nab
                    cmd_Customer_List.Connection = open_con.return_con
                    adap_Customer_List = New SqlDataAdapter(cmd_Customer_List)
                    adap_Customer_List.Fill(ds_Customer_List)

                    For i As Integer = 0 To ds_Customer_List.Tables(0).Rows.Count - 1



                        If ds_Customer_List.Tables(0).Rows(i).Item("BSB").ToString <> "" Then
                            Dim cmd_upd_bank As New SqlCommand
                            Dim str_SQL_bank As String

                            str_SQL_bank = "UPDATE Tbl_Payment SET Tbl_Payment.Payment_Status = 'Paid', Tbl_Payment.Payment_Date = '" & nab_date & "'"
                            str_SQL_bank = str_SQL_bank & " WHERE (((Tbl_Payment.Due_Date)= '" & nab_date & "') AND ((customer_id ) = ' " & ds_Customer_List.Tables(0).Rows(i).Item(0).ToString & "') AND ((payment_id ) = ' " & ds_Customer_List.Tables(0).Rows(i).Item(2).ToString & "') AND ((loan_id ) = ' " & ds_Customer_List.Tables(0).Rows(i).Item(1).ToString & "') AND (Tbl_Payment.Transaction_Status is null) AND ((Tbl_Payment.Payment_Method)='NAB') AND ((Tbl_Payment.Payment_Date) Is Null) )"
                            cmd_upd_bank.CommandText = str_SQL_bank
                            cmd_upd_bank.Connection = open_con.return_con
                            cmd_upd_bank.ExecuteNonQuery()
                            cmd_upd_bank.Dispose()
                            bln_CreatFile = True
                            int_Total = int_Total + ds_Customer_List.Tables(0).Rows(i).Item("Amount")
                        Else
                            bln_CreatFile = False
                            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "NAB Debit file can not be created due to incomplete customer banking details" & "');", True)
                            Exit For

                        End If

                    Next

                    If bln_CreatFile = True Then
                        str_FileName = Replace(Session(" str_FileName"), " ", "_")
                        str_FileName = Replace(str_FileName, ",_", "")

                        Dim new_date As String
                        new_date = str_FileName
                        Dim month_debit As String
                        month_debit = Mid(str_FileName, 3, 2)
                        If month_debit = "01" Then
                            str_FileName = Left(str_FileName, 2) & "Jan" & Right(str_FileName, 2)
                        ElseIf month_debit = "02" Then
                            str_FileName = Left(str_FileName, 2) & "Feb" & Right(str_FileName, 2)
                        ElseIf month_debit = "03" Then
                            str_FileName = Left(str_FileName, 2) & "Mar" & Right(str_FileName, 2)
                        ElseIf month_debit = "04" Then
                            str_FileName = Left(str_FileName, 2) & "Apr" & Right(str_FileName, 2)
                        ElseIf month_debit = "05" Then
                            str_FileName = Left(str_FileName, 2) & "May" & Right(str_FileName, 2)
                        ElseIf month_debit = "06" Then
                            str_FileName = Left(str_FileName, 2) & "Jun" & Right(str_FileName, 2)
                        ElseIf month_debit = "07" Then
                            str_FileName = Left(str_FileName, 2) & "Jul" & Right(str_FileName, 2)
                        ElseIf month_debit = "08" Then
                            str_FileName = Left(str_FileName, 2) & "Aug" & Right(str_FileName, 2)
                        ElseIf month_debit = "09" Then
                            str_FileName = Left(str_FileName, 2) & "Sep" & Right(str_FileName, 2)
                        ElseIf month_debit = "10" Then
                            str_FileName = Left(str_FileName, 2) & "Oct" & Right(str_FileName, 2)
                        ElseIf month_debit = "11" Then
                            str_FileName = Left(str_FileName, 2) & "Nov" & Right(str_FileName, 2)
                        ElseIf month_debit = "12" Then
                            str_FileName = Left(str_FileName, 2) & "Dec" & Right(str_FileName, 2)
                        End If

                        If Len(Day(Trim(Txt_date.Text))) = 1 Then
                            str_abaFileName = Left(Replace(str_FileName, " ", ""), 4) & Right(Replace(str_FileName, " ", ""), 2)
                        Else
                            str_abaFileName = Left(Replace(str_FileName, " ", ""), 5) & Right(Replace(str_FileName, " ", ""), 2)
                        End If
                        str_Filepath = Server.MapPath("~\@NAB_Dr\" & str_abaFileName & ".aba")

                        int_Counter = 65
                        For int_Counter = 65 To 90
                            If (System.IO.File.Exists(Server.MapPath("~\@NAB_Dr\" & str_abaFileName & Chr(int_Counter) & ".aba"))) = False Then
                                fs = File.Create(Server.MapPath("~\@NAB_Dr\" & str_abaFileName & Chr(int_Counter) & ".aba"))
                                str_abaFileName = str_abaFileName & Chr(int_Counter)
                                Exit For
                            End If
                        Next
                        str_Entry_Type_0 = "0                 "

                        str_Entry_Type_0 = str_Entry_Type_0 & "01NAB       "

                        str_Entry_Type_0 = str_Entry_Type_0 & UCase(open_con.fn_Set_Data(ds_nab_branch.Tables(0).Rows(0).Item("NAB_User_Name").ToString, 26, "right", " "))

                        str_Entry_Type_0 = str_Entry_Type_0 & ds_nab_branch.Tables(0).Rows(0).Item("NAB_User_ID1").ToString

                        str_Entry_Type_0 = str_Entry_Type_0 & "DIRECT DEBIT"

                        str_Entry_Type_0 = str_Entry_Type_0 & new_date   'Date in 000000.aba format

                        str_Entry_Type_0 = str_Entry_Type_0 & "                                        "

                        oWrite = New System.IO.StreamWriter(fs)
                        oWrite.WriteLine(str_Entry_Type_0)

                        int_record = 0
                        int_Total = 0

                        For j As Integer = 0 To ds_Customer_List.Tables(0).Rows.Count - 1

                            str_Entry_Type_1 = "1" & ds_Customer_List.Tables(0).Rows(j).Item("BSB").ToString

                            str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(ds_Customer_List.Tables(0).Rows(j).Item("Account_Number").ToString, 9, "left", " ")

                            str_Entry_Type_1 = str_Entry_Type_1 & " 13"

                            str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(Replace(Replace(FormatNumber(ds_Customer_List.Tables(0).Rows(j).Item("Amount"), 2), ".", ""), ",", ""), 10, "left", "0")

                            If Trim(ds_Customer_List.Tables(0).Rows(j).Item("Account_Name").ToString) <> "" Then
                                str_Entry_Type_1 = str_Entry_Type_1 & UCase(open_con.fn_Set_Data(ds_Customer_List.Tables(0).Rows(j).Item("Account_Name").ToString, 32, "right", " "))
                            Else
                                str_Entry_Type_1 = str_Entry_Type_1 & UCase(open_con.fn_Set_Data(ds_Customer_List.Tables(0).Rows(j).Item("Given_Name").ToString & " " & ds_Customer_List.Tables(0).Rows(j).Item("Last_Name").ToString, 32, "right", " "))
                            End If

                            str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(Session("branch_prefix") & ds_Customer_List.Tables(0).Rows(j).Item("Customer_ID").ToString, 18, "right", " ")

                            str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(ds_nab_branch.Tables(0).Rows(0).Item("NAB_BSB").ToString, 7, "left", " ")

                            str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(ds_nab_branch.Tables(0).Rows(0).Item("NAB_Account_No").ToString, 9, "left", " ")

                            str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data("Abaz", 16, "right", " ")

                            str_Entry_Type_1 = str_Entry_Type_1 & "00000000"

                            oWrite.WriteLine(str_Entry_Type_1)

                            int_Total = int_Total + Math.Round(CDbl(ds_Customer_List.Tables(0).Rows(j).Item("Amount")), 2)

                            int_record = int_record + 1
                        Next

                        Dim int_total1 As String
                        int_total1 = CStr(int_Total)
                        '''''''''''''''''''find position of (.)
                        Dim pos_int_Total1 As Integer
                        pos_int_Total1 = InStr(1, int_total1, ".")
                        If pos_int_Total1 = 0 Then
                            new_total2 = int_total1 & "00"
                        Else
                            '''''''''''finding the starting part

                            new_total1 = Mid(int_total1, 1, pos_int_Total1 - 1)
                            '''''''''''''''finding the ending part

                            new_total2 = Mid(int_total1, pos_int_Total1, int_total1.Length)

                            If Len(new_total2) = 2 Then
                                new_total2 = new_total1 & new_total2 & "0"
                                new_total2 = Replace(Replace(new_total2, ".", ""), ",", "")
                            ElseIf Len(new_total2) > 2 Then

                                Dim pos_int_Total2 As Integer
                                pos_int_Total2 = InStr(1, new_total2, ".")

                                Dim new_amt As String
                                new_amt = Mid(new_total2, pos_int_Total2 + 1, 2)



                                new_total2 = new_total1 & new_amt
                                new_total2 = Replace(Replace(new_total2, ".", ""), ",", "")

                            Else
                                new_total2 = new_total1 & new_total2
                                new_total2 = Replace(Replace(new_total2, ".", ""), ",", "")
                            End If

                        End If

                        str_Entry_Type_1 = "1" & ds_nab_branch.Tables(0).Rows(0).Item("NAB_BSB").ToString

                        str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(ds_nab_branch.Tables(0).Rows(0).Item("NAB_Account_No").ToString, 9, "left", " ")

                        str_Entry_Type_1 = str_Entry_Type_1 & " 50"

                        str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(new_total2, 10, "left", "0")

                        str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data("Abaz", 32, "right", " ")

                        str_Entry_Type_1 = str_Entry_Type_1 & "                  " & ds_nab_branch.Tables(0).Rows(0).Item("NAB_BSB").ToString

                        str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(ds_nab_branch.Tables(0).Rows(0).Item("NAB_Account_No").ToString, 9, "left", " ")

                        str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data("Abaz", 16, "right", " ")

                        str_Entry_Type_1 = str_Entry_Type_1 & "00000000"

                        int_record = int_record + 1

                        oWrite.WriteLine(str_Entry_Type_1)

                        str_Entry_Type_7 = "7999-999" & "            " & "0000000000"

                        str_Entry_Type_7 = str_Entry_Type_7 & open_con.fn_Set_Data(new_total2, 10, "left", "0")

                        str_Entry_Type_7 = str_Entry_Type_7 & open_con.fn_Set_Data(new_total2, 10, "left", "0") & "                        "

                        str_Entry_Type_7 = str_Entry_Type_7 & open_con.fn_Set_Data(int_record, 6, "left", "0") & "                                        "

                        oWrite.WriteLine(str_Entry_Type_7)


                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & str_abaFileName & ".aba" & " has been created!!! " & "');", True)
                        Txt_date.Text = ""
                        GridView1.Visible = False

                        cmd_nab_branch.Dispose()
                        cmd_Customer_List.Dispose()
                        adap_Customer_List.Dispose()
                        ds_Customer_List.Dispose()
                        adap_nab_branch.Dispose()
                        ds_nab_branch.Dispose()
                        oWrite.Close()
                        fs.Close()

                        'insert table nab file
                        insert_table_nab(str_abaFileName & ".aba", Date.Now)

                        Dim dv As DataView = Getdata()
                        GridView_nab.DataSource = dv
                        GridView_nab.DataBind()

                    Else
                        Txt_date.Text = ""
                        GridView1.Visible = False
                        cmd_nab_branch.Dispose()
                        cmd_Customer_List.Dispose()
                        adap_Customer_List.Dispose()
                        ds_Customer_List.Dispose()
                        adap_nab_branch.Dispose()
                        ds_nab_branch.Dispose()
                        oWrite.Close()
                        fs.Close()

                    End If

                End If


              
            Else
                grid_databind()

            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
            GridView1.Visible = False

        End Try

    End Sub
    Sub chkAdmin()
        If clsGeneral.ChkAdmin() = True Then
            Link_Administration.Visible = True
        Else
            Link_Administration.Text = "User"
            Link_Administration.PostBackUrl = "~/Customer/UpdatePassword.aspx"

        End If
    End Sub

    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub

    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub

    ' gridview  nab files
    Function bind_grid() As Boolean
        Try
            Dim cmd_document As New SqlCommand
            Dim str_document As String
            str_document = " SELECT Name_NAB_Files, Date_Created FROM Tbl_NAB_Files  "
            cmd_document.Connection = open_con.return_con
            cmd_document.CommandText = str_document
            cmd_document.ExecuteNonQuery()
            Dim adap_document As SqlDataAdapter
            adap_document = New SqlDataAdapter(cmd_document)
            Dim ds_document As New DataSet
            adap_document.Fill(ds_document)

            If ds_document.Tables(0).Rows(0).Item(0).ToString() = "" Then

                bind_grid = False
                GridView_nab.Visible = False
                Label_nab.Visible = False
                Button_ShowAll.Visible = False
                Button_Hidden.Visible = False

            Else

                GridView_nab.Visible = True
                Label_nab.Visible = True
                'GridView_nab.DataSource = ds_document
                'GridView_nab.DataBind()
                bind_grid = True
                Button_ShowAll.Visible = True
                Button_Hidden.Visible = False

            End If
            open_con.return_con.Dispose()
            cmd_document.Dispose()
            adap_document.Dispose()
            ds_document.Dispose()


        Catch ex As Exception

            Response.Write("Error: " & ex.Message)
        End Try

    End Function

    Protected Sub insert_table_nab(ByVal filename As String, ByVal date_created As DateTime)

        Try

            Dim cmd_insert_table As New SqlCommand
            cmd_insert_table.CommandText = "insert into Tbl_NAB_Files values(@filename ,@date_created  )"

            cmd_insert_table.Parameters.Add("@filename", SqlDbType.VarChar, 50).Value = filename
            cmd_insert_table.Parameters.Add("@date_created", SqlDbType.DateTime).Value = date_created

            cmd_insert_table.Connection = open_con.return_con
            cmd_insert_table.ExecuteNonQuery()
            open_con.return_con.Dispose()
            cmd_insert_table.Dispose()

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Protected Sub lnkDownload_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'Dim lnkbtn As LinkButton = TryCast(sender, LinkButton)
            Dim lnkbtn As ImageButton = TryCast(sender, ImageButton)
            Dim gvrow As GridViewRow = TryCast(lnkbtn.NamingContainer, GridViewRow)
            Dim filePath As String = GridView_nab.DataKeys(gvrow.RowIndex).Value.ToString()




            'My.Computer.Network.DownloadFile("C:\Users\Net3\Documents\30th Nov 2013\backOffice\@NAB_Dr\" & filePath, "C:\@NAB_Dr\" & filePath)
            'My.Computer.Network.DownloadFile("H:\WebSpace\cuykynsi\moneyplus.com.au\backOffice\@NAB_Dr\" & filePath, "C:\@NAB_Dr\" & filePath)
            'My.Computer.Network.DownloadFile("H:/WebSpace/cuykynsi/moneyplus.com.au/backOffice/@NAB_Dr/" & filePath, "C:\Users\Net3\Downloads\" & filePath)

            'Response.AddHeader("Content-Disposition", "attachment;filename='" & filePath & "'")
            'Response.AppendHeader("Content-Disposition", "attachment;filename='" & filePath & "'")
            'Response.TransmitFile("H:/WebSpace/cuykynsi/moneyplus.com.au/backOffice/@NAB_Dr/" & filePath)
            ' Response.TransmitFile("~/@NAB_Dr/" & filePath)

            'Response.ContentType = "aba"

            Response.AppendHeader("Content-Disposition", "attachment;filename=""" & filePath & """")
            'Response.TransmitFile("H:/WebSpace/cuykynsi/moneyplus.com.au/backOffice/@NAB_Dr/" & filePath)
            'Response.TransmitFile("H:/WebSpace/cuykynsi/test1.moneyplus.com.au/backOffice/@NAB_Dr/" & filePath)
            Response.TransmitFile(Server.MapPath("~/@NAB_Dr/" & filePath))

            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & filePath & " has been downloaded successful !!! " & "');", True)

            Response.End()
            'My.Computer.Network.DownloadFile("C:\Users\Net3\Downloads\" & filePath, "C:\@NAB_Dr\" & filePath)


        Catch ex As Exception

        End Try

    End Sub
    Protected Sub GridView_nab_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView_nab.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='none';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFBD6'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            e.Row.Attributes.Add("ondblClick", ClientScript.GetPostBackClientHyperlink(GridView_nab, "Select$" & e.Row.RowIndex))

        End If
    End Sub
    Protected Sub PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GridView_nab.PageIndex = e.NewPageIndex
        Dim dv As DataView = showall_grid()
        GridView_nab.DataSource = dv
        GridView_nab.DataBind()
    End Sub
    Private Function Getdata() As DataView
        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ToString())
            Dim ds As New DataSet()
            'Dim strSelectCmd As String = "SELECT    * from Tbl_NAB_Files WHERE Date_Created >= dateadd(day,datediff(day,1,GETDATE()),0) OR Date_Created = dateadd(day,datediff(day,0,GETDATE()),0) "
            Dim strSelectCmd As String = "SELECT    * from Tbl_NAB_Files WHERE   NAB_ID = (SELECT MAX(NAB_ID)  FROM Tbl_NAB_Files)  "
            Dim da As New SqlDataAdapter(strSelectCmd, conn)
            da.Fill(ds, "Tbl_NAB_Files")
            Dim dv As DataView = ds.Tables("Tbl_NAB_Files").DefaultView
            'dv.Sort = ViewState("SortExpr").ToString()
            Return dv
        End Using
    End Function
    Function showall_grid() As DataView
        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ToString())
            Dim ds As New DataSet()
            Dim strSelectCmd As String = "SELECT    * from Tbl_NAB_Files "
            Dim da As New SqlDataAdapter(strSelectCmd, conn)
            da.Fill(ds, "Tbl_NAB_Files")
            Dim dv As DataView = ds.Tables("Tbl_NAB_Files").DefaultView
            'dv.Sort = ViewState("SortExpr").ToString()

            Return dv
        End Using

    End Function
    Protected Sub Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim SortOrder As String() = ViewState("SortExpr").ToString().Split(" "c)
        If SortOrder(0) = e.SortExpression Then
            If SortOrder(1) = "ASC" Then
                ViewState("SortExpr") = e.SortExpression + " " + "DESC"
            Else
                ViewState("SortExpr") = e.SortExpression + " " + "ASC"
            End If
        Else
            ViewState("SortExpr") = e.SortExpression + " " + "ASC"
        End If
        GridView_nab.DataSource = Getdata()
        GridView_nab.DataBind()
    End Sub
    

    Protected Sub Button_ShowAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_ShowAll.Click
        Dim dv As DataView = showall_grid()
        GridView_nab.DataSource = dv
        GridView_nab.DataBind()
        Button_Hidden.Visible = True
        Button_ShowAll.Visible = False
    End Sub

    Protected Sub Button_Hidden_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Hidden.Click
        Dim dv As DataView = Getdata()
        GridView_nab.DataSource = dv
        GridView_nab.DataBind()
        Button_Hidden.Visible = False
        Button_ShowAll.Visible = True
    End Sub


End Class
