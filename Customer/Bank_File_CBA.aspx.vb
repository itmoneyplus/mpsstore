Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Customer_Bank_File_CBA
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Dim cba_date, str_Filepath As String
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Confirms that an HtmlForm control is rendered for the specified ASP.NET server control at run time.
    End Sub
    Protected Sub Btn_cba_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_cba.Click
        Try
            If Txt_date_cba.Text = "" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a date!!!" & "');", True)
                Exit Sub
            ElseIf CDate(Txt_date_cba.Text) < System.DateTime.Now.Date Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid future date!!!" & "');", True)
                GridView1.Visible = False
                Exit Sub
            ElseIf Val(Txt_date_cba.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                GridView1.Visible = False
                Exit Sub
            Else
                grid_databind()
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
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
            e.Row.Cells(1).Text = "$ " & Session("tot_cba_amt")
            e.Row.Cells.RemoveAt(4)
            e.Row.Cells.RemoveAt(5)
        End If
    End Sub
    Protected Sub cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancel_cba.Click
        Response.Redirect("AddSearch.aspx", False)
    End Sub
    Protected Sub cba_print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cba_print.Click
        Response.Redirect("../Reports/CBA_rep.aspx", False)
    End Sub
    Sub grid_databind()

        cba_date = Date.Parse(Txt_date_cba.Text).ToString("yyyy-MM-dd")
        Session("cba_date") = cba_date

        Dim cmd_cba, cmd_cba_new As New SqlCommand
        Dim str_cba, str_cba_new As String
        Dim cmd_pay As New SqlCommand
        cmd_pay.Connection = open_con.return_con
        cmd_pay.CommandText = "update tbl_payment set description=null where description='' and due_date = '" & cba_date & "'"
        cmd_pay.ExecuteNonQuery()
        cmd_pay.Dispose()


        str_cba = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Given_Name, Tbl_Customer.Last_Name, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Bank_Account.BSB, Tbl_Loan.Loan_ID, Tbl_Loan.Loan_Type, Tbl_Payment.Amount, Tbl_Payment.Due_Date, Tbl_Payment.Payment_Method, Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.BSB "
        str_cba = str_cba & " FROM ((Tbl_Customer INNER JOIN Tbl_Loan ON Tbl_Customer.Customer_ID = Tbl_Loan.Customer_ID) INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID) ON Tbl_Loan.Loan_ID = Tbl_Payment.Loan_ID) INNER JOIN Tbl_Bank_Account ON Tbl_Loan.Bank_Account_ID = Tbl_Bank_Account.Bank_Account_ID "
        str_cba = str_cba & " WHERE (((Tbl_Payment.Amount)<>0) AND ((Tbl_Payment.Due_Date)='" & cba_date & "') AND ((Tbl_Payment.Payment_Method)='CBA') AND ((Tbl_Payment_1.Update_ID) Is Null) AND ((Tbl_Loan.Status)='1') AND ((Tbl_Payment.Description)='Arear notice fee' Or (Tbl_Payment.Description)='Statement of account fee' Or (Tbl_Payment.Description)='Variation fee' Or (Tbl_Payment.Description)='Default notice fee' Or (Tbl_Payment.Description)='Letter of demand fee' Or (Tbl_Payment.Description)='Dishonoured fee' Or (Tbl_Payment.Description)='Enforcement fee' Or (Tbl_Payment.Description) Is Null) AND ((Tbl_Payment.Transaction_Status) Is Null) AND ((Tbl_Payment.Payment_Date) Is Null or (Tbl_Payment.Payment_Date) =''  ))"
        str_cba = str_cba & " ORDER BY Tbl_Customer.Last_Name, Tbl_Customer.Given_Name "

        cmd_cba.CommandText = str_cba
        cmd_cba.Connection = open_con.return_con
        Dim dataadap_cba As SqlDataAdapter
        Dim ds_cba As New DataSet
        dataadap_cba = New SqlDataAdapter(cmd_cba)
        dataadap_cba.Fill(ds_cba)

        str_cba_new = "Select sum(tbl_payment.amount)"
        str_cba_new = str_cba_new & " FROM ((Tbl_Customer INNER JOIN Tbl_Loan ON Tbl_Customer.Customer_ID = Tbl_Loan.Customer_ID) INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID) ON Tbl_Loan.Loan_ID = Tbl_Payment.Loan_ID) INNER JOIN Tbl_Bank_Account ON Tbl_Loan.Bank_Account_ID = Tbl_Bank_Account.Bank_Account_ID "
        str_cba_new = str_cba_new & " WHERE (((Tbl_Payment.Amount)<>0) AND ((Tbl_Payment.Due_Date)='" & cba_date & "') AND ((Tbl_Payment.Payment_Method)='CBA') AND ((Tbl_Payment_1.Update_ID) Is Null) AND ((Tbl_Loan.Status)='1') AND ((Tbl_Payment.Description)='Arear notice fee' Or (Tbl_Payment.Description)='Statement of account fee' Or (Tbl_Payment.Description)='Variation fee' Or (Tbl_Payment.Description)='Default notice fee' Or (Tbl_Payment.Description)='Letter of demand fee' Or (Tbl_Payment.Description)='Dishonoured fee' Or (Tbl_Payment.Description)='Enforcement fee' Or (Tbl_Payment.Description) Is Null) AND ((Tbl_Payment.Transaction_Status) Is Null) AND ((Tbl_Payment.Payment_Date) Is Null)) "

        cmd_cba_new.CommandText = str_cba_new
        cmd_cba_new.Connection = open_con.return_con
        Dim dataadap_cba_new As SqlDataAdapter
        Dim ds_cba_new As New DataSet
        dataadap_cba_new = New SqlDataAdapter(cmd_cba_new)
        dataadap_cba_new.Fill(ds_cba_new)

        Dim tot_cba_amt As String
        If ds_cba.Tables(0).Rows.Count = 0 Then
            GridView1.Visible = False
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "There are no direct debit payments due on " & Txt_date_cba.Text & "');", True)
            Txt_date_cba.Text = ""
            cba_print.Visible = False
            cancel_cba.Visible = False
            debit_cba.Visible = False
            cmd_cba.Dispose()
            ds_cba.Dispose()
            dataadap_cba.Dispose()
            cmd_cba_new.Dispose()
            ds_cba_new.Dispose()
            dataadap_cba_new.Dispose()
            open_con.return_con.Dispose()
            Exit Sub
        Else
            tot_cba_amt = ds_cba_new.Tables(0).Rows(0).Item(0).ToString
            Dim pos_dot As Integer
            pos_dot = InStr(1, tot_cba_amt, ".")
            If pos_dot = 0 Then
                tot_cba_amt = tot_cba_amt & "00"
            ElseIf pos_dot > 0 Then
                Dim right_amt As String
                Dim left_amt As String
                right_amt = Mid(tot_cba_amt, pos_dot + 1, 2)
                If Len(right_amt) = 1 Then
                    tot_cba_amt = tot_cba_amt & "0"
                Else
                    left_amt = Mid(tot_cba_amt, 1, pos_dot)
                    tot_cba_amt = left_amt & right_amt
                End If

            End If


            Session("tot_cba_amt") = tot_cba_amt
            GridView1.Visible = True
            GridView1.DataSource = ds_cba
            GridView1.DataBind()
            cba_print.Visible = True
            cancel_cba.Visible = True
            debit_cba.Visible = True
            cmd_cba.Dispose()
            ds_cba.Dispose()
            dataadap_cba.Dispose()

            cmd_cba_new.Dispose()
            ds_cba_new.Dispose()
            dataadap_cba_new.Dispose()
            open_con.return_con.Dispose()
        End If

    End Sub

    Protected Sub debit_cba_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles debit_cba.Click

        Try
            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then

                Dim str_Entry_Type_0, str_Entry_Type_1, str_Entry_Type_7, str_abaFileName, str_FileName, new_cba_date As String
                Dim bln_CreatFile_cba As Boolean
                Dim int_Counter, int_record As Integer
                Dim fs As FileStream = Nothing
                Dim oWrite As System.IO.StreamWriter = Nothing
                Dim new_total1 As String
                Dim new_total2 As String

                cba_date = Date.Parse(Txt_date_cba.Text).ToString("yyyy-MM-dd")
                If Txt_date_cba.Text <> "" Then
                    If Day(Trim(Txt_date_cba.Text)) < 10 Then
                        str_FileName = "0" & Day(Txt_date_cba.Text)
                    Else
                        str_FileName = Day(Txt_date_cba.Text)
                    End If
                    If Month(Trim(Txt_date_cba.Text)) < 10 Then
                        str_FileName = str_FileName & "0" & Month(Txt_date_cba.Text)
                    Else
                        str_FileName = str_FileName & Month(Txt_date_cba.Text)
                    End If
                    str_FileName = str_FileName & Right(Year(Txt_date_cba.Text), 2)
                    Session(" str_FileName") = str_FileName
                End If

                Dim cmd_cba_branch As New SqlCommand
                Dim str_SQL_cba As String
                cmd_cba_branch.CommandText = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val
                cmd_cba_branch.Connection = open_con.return_con

                Dim adap_cba_branch As SqlDataAdapter
                Dim ds_cba_branch As New DataSet
                Dim int_Total As Single
                adap_cba_branch = New SqlDataAdapter(cmd_cba_branch)
                adap_cba_branch.Fill(ds_cba_branch)
                Dim branch_count As String
                branch_count = ds_cba_branch.Tables(0).Rows.Count.ToString

                If Val(branch_count) <> 0 Then
                    Dim cmd_Customer_List As New SqlCommand
                    Dim adap_Customer_List As SqlDataAdapter
                    Dim ds_Customer_List As New DataSet

                    str_SQL_cba = " SELECT Tbl_Customer.Customer_ID,Tbl_Loan.Loan_ID,Tbl_Payment.Payment_ID, Tbl_Customer.Given_Name, Tbl_Customer.Last_Name, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Bank_Account.BSB, Tbl_Loan.Loan_ID, Tbl_Loan.Loan_Type, Tbl_Payment.Amount, Tbl_Payment.Due_Date, Tbl_Payment.Payment_Method, Tbl_Bank_Account.Account_Name, Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.BSB "
                    str_SQL_cba = str_SQL_cba & " FROM ((Tbl_Customer INNER JOIN Tbl_Loan ON Tbl_Customer.Customer_ID = Tbl_Loan.Customer_ID) INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID) ON Tbl_Loan.Loan_ID = Tbl_Payment.Loan_ID) INNER JOIN Tbl_Bank_Account ON Tbl_Loan.Bank_Account_ID = Tbl_Bank_Account.Bank_Account_ID "
                    str_SQL_cba = str_SQL_cba & " WHERE (((Tbl_Payment.Amount)<>0) AND ((Tbl_Payment.Due_Date)='" & cba_date & "') AND ((Tbl_Payment.Payment_Method)='CBA') AND ((Tbl_Payment_1.Update_ID) Is Null) AND ((Tbl_Loan.Status)='1') AND ((Tbl_Payment.Description)='Arear notice fee' Or (Tbl_Payment.Description)='Enforcement fee' or (Tbl_Payment.Description)='Statement of account fee' Or (Tbl_Payment.Description)='Variation fee' Or (Tbl_Payment.Description)='Default notice fee' Or (Tbl_Payment.Description)='Letter of demand fee' Or (Tbl_Payment.Description)='Dishonoured fee' Or (Tbl_Payment.Description) Is Null) AND ((Tbl_Payment.Transaction_Status) Is Null) AND ((Tbl_Payment.Payment_Date) Is Null or (Tbl_Payment.Payment_Date) ='' )) "
                    str_SQL_cba = str_SQL_cba & " ORDER BY Tbl_Customer.Customer_ID "

                    cmd_Customer_List.CommandText = str_SQL_cba
                    cmd_Customer_List.Connection = open_con.return_con
                    adap_Customer_List = New SqlDataAdapter(cmd_Customer_List)
                    adap_Customer_List.Fill(ds_Customer_List)

                    For i As Integer = 0 To ds_Customer_List.Tables(0).Rows.Count - 1

                        If ds_Customer_List.Tables(0).Rows(i).Item("BSB").ToString <> "" Then
                            Dim cmd_upd_bank As New SqlCommand
                            Dim str_SQL_bank As String

                            str_SQL_bank = "UPDATE Tbl_Payment SET Tbl_Payment.Payment_Status = 'Paid', Tbl_Payment.Payment_Date = '" & cba_date & "'"
                            str_SQL_bank = str_SQL_bank & " WHERE (((Tbl_Payment.Due_Date)= '" & cba_date & "') AND ((customer_id ) = ' " & ds_Customer_List.Tables(0).Rows(i).Item(0).ToString & "') AND ((payment_id ) = ' " & ds_Customer_List.Tables(0).Rows(i).Item(2).ToString & "') AND ((loan_id ) = ' " & ds_Customer_List.Tables(0).Rows(i).Item(1).ToString & "') AND (Tbl_Payment.Transaction_Status is null) AND ((Tbl_Payment.Payment_Method)='CBA') AND ((Tbl_Payment.Payment_Date) Is Null))"
                            cmd_upd_bank.CommandText = str_SQL_bank
                            cmd_upd_bank.Connection = open_con.return_con
                            cmd_upd_bank.ExecuteNonQuery()
                            cmd_upd_bank.Dispose()
                            bln_CreatFile_cba = True
                            int_Total = int_Total + ds_Customer_List.Tables(0).Rows(i).Item("Amount")
                        Else
                            bln_CreatFile_cba = False
                            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "CBA Debit file can not be created due to incomplete customer banking details" & "');", True)
                            Exit For

                        End If
                    Next

                    If bln_CreatFile_cba = True Then
                        str_FileName = Replace(Session(" str_FileName"), " ", "_")
                        str_FileName = Replace(str_FileName, ",_", "")
                        new_cba_date = str_FileName
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
                        If Len(Day(Trim(Txt_date_cba.Text))) = 1 Then
                            str_abaFileName = Left(Replace(str_FileName, " ", ""), 4) & Right(Replace(str_FileName, " ", ""), 2)
                        Else
                            str_abaFileName = Left(Replace(str_FileName, " ", ""), 5) & Right(Replace(str_FileName, " ", ""), 2)
                        End If
                        str_Filepath = Server.MapPath("~\@CBA_Dr\" & str_abaFileName & ".aba")

                        int_Counter = 65
                        For int_Counter = 65 To 90
                            If (System.IO.File.Exists(Server.MapPath("~\@CBA_Dr\" & str_abaFileName & Chr(int_Counter) & ".aba"))) = False Then
                                fs = File.Create(Server.MapPath("~\@CBA_Dr\" & str_abaFileName & Chr(int_Counter) & ".aba"))
                                str_abaFileName = str_abaFileName & Chr(int_Counter)
                                Exit For
                            End If
                        Next

                        str_Entry_Type_0 = "0                 "

                        str_Entry_Type_0 = str_Entry_Type_0 & "01CBA       "

                        str_Entry_Type_0 = str_Entry_Type_0 & UCase(open_con.fn_Set_Data(ds_cba_branch.Tables(0).Rows(0).Item("CBA_User_Name").ToString, 26, "right", " "))

                        str_Entry_Type_0 = str_Entry_Type_0 & "0"

                        str_Entry_Type_0 = str_Entry_Type_0 & ds_cba_branch.Tables(0).Rows(0).Item("CBA_User_ID1").ToString

                        str_Entry_Type_0 = str_Entry_Type_0 & "DIRECT DEBIT"

                        str_Entry_Type_0 = str_Entry_Type_0 & new_cba_date  'Date in 000000.aba format

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

                            str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(ds_cba_branch.Tables(0).Rows(0).Item("CBA_BSB").ToString, 7, "left", " ")

                            str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(ds_cba_branch.Tables(0).Rows(0).Item("CBA_Account_No").ToString, 9, "left", " ")

                            str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data("Abaz", 16, "right", " ")

                            str_Entry_Type_1 = str_Entry_Type_1 & "00000000"

                            oWrite.WriteLine(str_Entry_Type_1)

                            int_Total = int_Total + FormatNumber(ds_Customer_List.Tables(0).Rows(j).Item("Amount"), 2)

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


                        str_Entry_Type_1 = "1" & ds_cba_branch.Tables(0).Rows(0).Item("CBA_BSB").ToString

                        str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(ds_cba_branch.Tables(0).Rows(0).Item("CBA_Account_No").ToString, 9, "left", " ")

                        str_Entry_Type_1 = str_Entry_Type_1 & " 50"

                        str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(new_total2, 10, "left", "0")

                        str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data("Abaz", 32, "right", " ")

                        str_Entry_Type_1 = str_Entry_Type_1 & "                  " & ds_cba_branch.Tables(0).Rows(0).Item("CBA_BSB").ToString

                        str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data(ds_cba_branch.Tables(0).Rows(0).Item("CBA_Account_No").ToString, 9, "left", " ")

                        str_Entry_Type_1 = str_Entry_Type_1 & open_con.fn_Set_Data("Abaz", 16, "right", " ")

                        str_Entry_Type_1 = str_Entry_Type_1 & "00000000"

                        int_record = int_record + 1

                        oWrite.WriteLine(str_Entry_Type_1)

                        str_Entry_Type_7 = "7999-999" & "            " & "0000000000"

                        str_Entry_Type_7 = str_Entry_Type_7 & open_con.fn_Set_Data(new_total2, 10, "left", "0")

                        str_Entry_Type_7 = str_Entry_Type_7 & open_con.fn_Set_Data(new_total2, 10, "left", "0") & "                        "

                        str_Entry_Type_7 = str_Entry_Type_7 & open_con.fn_Set_Data(int_record, 6, "left", "0") & "                                        "

                        oWrite.WriteLine(str_Entry_Type_7)


                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & str_abaFileName & ".aba" & " has been created !!! " & "');", True)
                        Txt_date_cba.Text = ""
                        GridView1.Visible = False

                        cmd_cba_branch.Dispose()
                        cmd_Customer_List.Dispose()
                        adap_Customer_List.Dispose()
                        ds_Customer_List.Dispose()
                        adap_cba_branch.Dispose()
                        ds_cba_branch.Dispose()
                        oWrite.Close()
                        fs.Close()

                        'insert table CBA file
                        insert_table_cba(str_abaFileName & ".aba", Date.Now)

                        Dim dv As DataView = Getdata()
                        GridView_cba.DataSource = dv
                        GridView_cba.DataBind()
                    Else
                        Txt_date_cba.Text = ""
                        GridView1.Visible = False
                        cmd_cba_branch.Dispose()
                        cmd_Customer_List.Dispose()
                        adap_Customer_List.Dispose()
                        ds_Customer_List.Dispose()
                        adap_cba_branch.Dispose()
                        ds_cba_branch.Dispose()
                        oWrite.Close()
                        fs.Close()

                    End If
                End If
              
            Else
                grid_databind()

            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
            Txt_date_cba.Text = ""
            GridView1.Visible = False

        End Try

    End Sub
    Dim Sort_Direction As String = "Name_CBA_Files ASC"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")

        chkAdmin()

        If Not IsPostBack Then
            'ViewState("SortExpr") = Sort_Direction
            Dim dv As DataView = Getdata()
            GridView_cba.DataSource = dv
            GridView_cba.DataBind()
        End If

        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            If bind_grid() = True Then
                Label_cba.Visible = True
                Button_ShowAll.Visible = True
            Else
                Label_cba.Visible = False
                Button_ShowAll.Visible = False
            End If
            cba_print.Visible = False
            cancel_cba.Visible = False
            debit_cba.Visible = False
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

    ' gridview  CBA files
    Function bind_grid() As Boolean
        Try
            Dim cmd_document As New SqlCommand
            Dim str_document As String
            str_document = " SELECT Name_CBA_Files, Date_Created FROM Tbl_CBA_Files "
            cmd_document.Connection = open_con.return_con
            cmd_document.CommandText = str_document
            cmd_document.ExecuteNonQuery()
            Dim adap_document As SqlDataAdapter
            adap_document = New SqlDataAdapter(cmd_document)
            Dim ds_document As New DataSet
            adap_document.Fill(ds_document)

            If ds_document.Tables(0).Rows(0).Item(0).ToString() = "" Then

                bind_grid = False
                GridView_cba.Visible = False
                Label_cba.Visible = False
                Button_ShowAll.Visible = False
                Button_Hidden.Visible = False
            Else

                GridView_cba.Visible = True
                Label_cba.Visible = True
                'GridView_cba.DataSource = ds_document
                'GridView_cba.DataBind()
                bind_grid = True
                Button_ShowAll.Visible = True
                Button_Hidden.Visible = False

            End If
            open_con.return_con.Dispose()
            cmd_document.Dispose()
            adap_document.Dispose()
            ds_document.Dispose()


        Catch ex As Exception


        End Try

    End Function
    Protected Sub insert_table_cba(ByVal filename As String, ByVal date_created As DateTime)

        Try

            Dim cmd_insert_table As New SqlCommand
            cmd_insert_table.CommandText = "insert into Tbl_CBA_Files values(@filename ,@date_created  )"

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
            Dim filePath As String = GridView_cba.DataKeys(gvrow.RowIndex).Value.ToString()
            'Response.AddHeader("Content-Disposition", "attachment;filename=""" & filePath & """")
            'Response.TransmitFile("H:/WebSpace/cuykynsi/moneyplus.com.au/wwwroot/site/uploads/" & filePath)

            Response.AddHeader("Content-Disposition", "attachment;filename=""" & filePath & """")
            'Response.TransmitFile("H:/WebSpace/cuykynsi/moneyplus.com.au/backOffice/@CBA_Dr/" & filePath)
            'Response.TransmitFile("H:/WebSpace/cuykynsi/test1.moneyplus.com.au/backOffice/@CBA_Dr/" & filePath)
            Response.TransmitFile("~/@CBA_Dr/" & filePath)
            Response.End()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub GridView_cba_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView_cba.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='none';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFBD6'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            e.Row.Attributes.Add("ondblClick", ClientScript.GetPostBackClientHyperlink(GridView_cba, "Select$" & e.Row.RowIndex))

        End If
    End Sub
    Protected Sub PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GridView_cba.PageIndex = e.NewPageIndex
        Dim dv As DataView = showall_grid()
        GridView_cba.DataSource = dv
        GridView_cba.DataBind()
    End Sub
    Private Function Getdata() As DataView
        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ToString())
            Dim ds As New DataSet()
            'Dim strSelectCmd As String = "SELECT    * from Tbl_CBA_Files  WHERE Date_Created >= dateadd(day,datediff(day,1,GETDATE()),0) OR Date_Created = dateadd(day,datediff(day,0,GETDATE()),0)"
            Dim strSelectCmd As String = "SELECT    * from Tbl_CBA_Files    WHERE   CBA_ID = (SELECT MAX(CBA_ID)  FROM Tbl_CBA_Files)"
            Dim da As New SqlDataAdapter(strSelectCmd, conn)
            da.Fill(ds, "Tbl_CBA_Files")
            Dim dv As DataView = ds.Tables("Tbl_CBA_Files").DefaultView
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
        GridView_cba.DataSource = Getdata()
        GridView_cba.DataBind()
    End Sub
    Function showall_grid() As DataView
        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ToString())
            Dim ds As New DataSet()
            Dim strSelectCmd As String = "SELECT    * from Tbl_CBA_Files "
            Dim da As New SqlDataAdapter(strSelectCmd, conn)
            da.Fill(ds, "Tbl_CBA_File")
            Dim dv As DataView = ds.Tables("Tbl_CBA_File").DefaultView
            'dv.Sort = ViewState("SortExpr").ToString()

            Return dv
        End Using

    End Function

    Protected Sub Button_ShowAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_ShowAll.Click
        Dim dv As DataView = showall_grid()
        GridView_cba.DataSource = dv
        GridView_cba.DataBind()
        Button_Hidden.Visible = True
        Button_ShowAll.Visible = False
    End Sub
    Protected Sub Button_Hidden_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Hidden.Click
        Dim dv As DataView = Getdata()
        GridView_cba.DataSource = dv
        GridView_cba.DataBind()
        Button_Hidden.Visible = False
        Button_ShowAll.Visible = True
    End Sub

    Protected Sub GridView_cba_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView_cba.PageIndexChanging

    End Sub
End Class
