Imports System.Data.SqlClient
Imports System.Data
Partial Class toolbaar_NominateBank
    Inherits System.Web.UI.UserControl
    Dim open_con As New Class1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("flag_beginning") = True And Session("beg_status") <> "Declined" And Session("flag_approve") = False Then
            Dim str_select_bnk As String
            str_select_bnk = "select Bank_Account_ID from tbl_loan where loan_id=" & Session("beg_loan_id")
            select_bank(str_select_bnk, Session("beg_loan_id"))
        Else
        End If
        If Session("nominate_msg") = True Then
            Dim str_select_bnk As String
            str_select_bnk = "select Bank_Account_ID from tbl_loan where loan_id=" & Session("cur_loan_id")
            select_bank(str_select_bnk, Session("cur_loan_id"))
        Else
        End If
        If Session("flag_beginning") = False And Session("beg_status") <> "Declined" And Session("flag_approve") = True Then
            Dim str_select_bnk As String
            str_select_bnk = "select Bank_Account_ID from tbl_loan where loan_id=" & Session("cur_loan_id")
            select_bank(str_select_bnk, Session("cur_loan_id"))
        Else
        End If
    End Sub

    Sub select_bank(ByVal str_select_bnk As String, ByVal loan_id As Integer)
        Try
            Dim cmd_nominate_id As New SqlCommand
            cmd_nominate_id.CommandText = str_select_bnk
            cmd_nominate_id.Connection = open_con.return_con
            cmd_nominate_id.ExecuteNonQuery()
            Dim adap_nominate_id As New SqlDataAdapter(cmd_nominate_id)
            Dim ds_nominate_id As New DataSet
            adap_nominate_id.Fill(ds_nominate_id)
            Dim bank_id As String
            bank_id = ds_nominate_id.Tables(0).Rows(0).Item(0).ToString

            If Val(bank_id) = 0 Then
                If Not Page.IsPostBack Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No bank account is nominated !!!" & "');", True)
                End If
            Else

                Dim cmd_bank As New SqlCommand
                Dim str_bank As String
                str_bank = "select * from Tbl_Bank_Account where customer_id=" & open_con.customer_id_val & " and Bank_Account_ID=" & Val(ds_nominate_id.Tables(0).Rows(0).Item(0))
                cmd_bank.Connection = open_con.return_con
                cmd_bank.CommandText = str_bank
                cmd_bank.ExecuteNonQuery()
                Dim adap_bank As SqlDataAdapter
                adap_bank = New SqlDataAdapter(cmd_bank)
                Dim ds_bank As New DataSet
                adap_bank.Fill(ds_bank)
                If (ds_bank.Tables(0).Rows.Count) = 0 Then
                    If Page.IsPostBack = False Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No bank account is nominated !!!" & "');", True)
                    End If
                    adap_bank.Dispose()
                    cmd_bank.Dispose()
                    get_bank()

                    cmd_nominate_id.Dispose()
                    adap_nominate_id.Dispose()
                    open_con.return_con.Dispose()
                    Exit Sub
                Else
                    txtBankName.Text = ds_bank.Tables(0).Rows(0).Item("Bank_Name").ToString
                    txtBankAddress.Text = ds_bank.Tables(0).Rows(0).Item("Bank_Address").ToString
                    txtBSB.Text = ds_bank.Tables(0).Rows(0).Item("BSB").ToString
                    txtBankSuburb.Text = ds_bank.Tables(0).Rows(0).Item("Bank_Suburb").ToString
                    txtAccountNumber.Text = ds_bank.Tables(0).Rows(0).Item("Account_Number").ToString
                    txtBankState.Text = ds_bank.Tables(0).Rows(0).Item("Bank_State").ToString
                    txtAccountName.Text = ds_bank.Tables(0).Rows(0).Item("Account_Name").ToString
                    txtBankPostCode.Text = ds_bank.Tables(0).Rows(0).Item("Bank_Post_Code").ToString
                    adap_bank.Dispose()
                    cmd_bank.Dispose()
                    ds_bank.Dispose()
                    Session("Nominate_BSB") = True
                    Session("bank_flag_loanap") = True

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            get_bank()
            txtAccountName.Text = Session("Customer_namebank")
            cmd_nominate_id.Dispose()
            adap_nominate_id.Dispose()
            open_con.return_con.Dispose()


        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub

    Sub get_bank()
        Dim ds_getbank As New DataSet
        ds_getbank = open_con.find_bank(open_con.customer_id_val)
        If ds_getbank.Tables(0).Rows.Count <> 0 Then
            'Label1.Visible = False
            Btnnominate.Visible = True
            LinkButton1.Visible = False


            ''Create Table'''
            Dim tbl As Table = New Table()
            tbl.ID = "tbl_dynamic"
            tbl.Style.Add("border-style", "none")
            tbl.Style.Add("border-width", "1px")
            tbl.Style.Add(" border-color", "gray")
            tbl.Style.Add("width", "100%")

            Dim rdb As Label = New Label()
            rdb.Text = "Select"
            rdb.Font.Bold = True
            rdb.Width = "80"
            rdb.Height = "20"
            rdb.Style.Add("font-size", "12px")
            rdb.Style.Add("font-family", "MS Sans Serif")
            rdb.Style.Add("font-weight", "bold")
            rdb.Style.Add("text-align", "center")
            rdb.Style.Add("background-color", "#D9D8DA")
            rdb.Style.Add(" border-style", "solid")
            rdb.Style.Add(" border-width", "1px")
            rdb.Style.Add(" border-color", "gray")

            Dim bsb As Label = New Label()
            bsb.Text = "BSB"
            bsb.Font.Bold = True
            bsb.Width = "120"
            bsb.Height = "20"
            bsb.Style.Add("font-size", "12px")
            bsb.Style.Add("font-family", "MS Sans Serif")
            bsb.Style.Add("font-weight", "bold")
            bsb.Style.Add("text-align", "center")
            bsb.Style.Add("background-color", "#D9D8DA")
            bsb.Style.Add(" border-style", "solid")
            bsb.Style.Add(" border-width", "1px")
            bsb.Style.Add(" border-color", "gray")

            Dim account_id As Label = New Label()
            account_id.Text = "Account"
            account_id.Font.Bold = True
            account_id.Width = "150"
            account_id.Height = "20"
            account_id.Style.Add("font-size", "12px")
            account_id.Style.Add("font-family", "MS Sans Serif")
            account_id.Style.Add("font-weight", "bold")
            account_id.Style.Add("text-align", "center")
            account_id.Style.Add("background-color", "#D9D8DA")
            account_id.Style.Add(" border-style", "solid")
            account_id.Style.Add(" border-width", "1px")
            account_id.Style.Add(" border-color", "gray")

            Dim bank_name As Label = New Label()
            bank_name.Text = "Bank Name"
            bank_name.Font.Bold = True
            bank_name.Width = "200"
            bank_name.Height = "20"
            bank_name.Style.Add("font-size", "12px")
            bank_name.Style.Add("font-family", "MS Sans Serif")
            bank_name.Style.Add("font-weight", "bold")
            bank_name.Style.Add("text-align", "center")
            bank_name.Style.Add("background-color", "#D9D8DA")
            bank_name.Style.Add(" border-style", "solid")
            bank_name.Style.Add(" border-width", "1px")
            bank_name.Style.Add(" border-color", "gray")

            Dim suburb As Label = New Label()
            suburb.Text = "Suburb"
            suburb.Font.Bold = True
            suburb.Width = "200"
            suburb.Height = "20"
            suburb.Style.Add("font-size", "12px")
            suburb.Style.Add("font-family", "MS Sans Serif")
            suburb.Style.Add("font-weight", "bold")
            suburb.Style.Add("text-align", "center")
            suburb.Style.Add("background-color", "#D9D8DA")
            suburb.Style.Add(" border-style", "solid")
            suburb.Style.Add(" border-width", "1px")
            suburb.Style.Add(" border-color", "gray")

            Dim account_name As Label = New Label()
            account_name.Text = "Account Name"
            account_name.Font.Bold = True
            account_name.Width = "200"
            account_name.Height = "20"
            account_name.Style.Add("font-size", "12px")
            account_name.Style.Add("font-family", "MS Sans Serif")
            account_name.Style.Add("font-weight", "bold")
            account_name.Style.Add("text-align", "center")
            account_name.Style.Add("background-color", "#D9D8DA")
            account_name.Style.Add(" border-style", "solid")
            account_name.Style.Add(" border-width", "1px")
            account_name.Style.Add(" border-color", "gray")



            Dim tcm As TableCell = New TableCell()
            Dim trm As TableRow = New TableRow()
            tcm.Style.Add("border-style", "solid")
            tcm.Style.Add("border-width", "1px")
            tcm.Style.Add(" border-color", "gray")
            trm.Style.Add("border-style", "solid")
            trm.Style.Add("border-width", "1px")
            trm.Style.Add(" border-color", "gray")
            tcm.Controls.Add(rdb)
            tcm.Controls.Add(bsb)
            tcm.Controls.Add(account_id)
            tcm.Controls.Add(bank_name)
            tcm.Controls.Add(suburb)
            tcm.Controls.Add(account_name)
            trm.Cells.Add(tcm)
            tbl.Rows.Add(trm)

            If ds_getbank.Tables(0).Rows.Count = 0 Then
                Session("count1") = 0
            End If

            For icount As Integer = 0 To ds_getbank.Tables(0).Rows.Count - 1
                Session("count1") = ds_getbank.Tables(0).Rows.Count
                Dim tc As TableCell = New TableCell()
                Dim tr As TableRow = New TableRow()
                tc.Style.Add("border-style", "solid")
                tc.Style.Add("border-width", "1px")
                tc.Style.Add(" border-color", "gray")
                tr.Style.Add("border-style", "solid")
                tr.Style.Add("border-width", "1px")
                tr.Style.Add(" border-color", "gray")

                Dim radio_repay As RadioButton = New RadioButton
                radio_repay.GroupName = "radio_repay1"
                radio_repay.ID = "radio_repay" & Format(icount, "00")
                radio_repay.Style.Add("text-align", "center")
                radio_repay.Width = "80"
                radio_repay.Height = "20"
                radio_repay.Visible = "True"

                Dim label1 As Label = New Label()
                label1.Width = "120"
                label1.Height = "20"
                label1.ID = "lab1" & Format(icount, "00")
                label1.Style.Add("font-size", "12px")
                label1.Style.Add("font-family", "MS Sans Serif")
                label1.Style.Add("font-weight", "bold")
                label1.Style.Add("text-align", "center")

                Dim label2 As Label = New Label()
                label2.Width = "150"
                label2.Height = "20"
                label2.ID = "lab2" & Format(icount, "00")
                label2.Style.Add("font-size", "12px")
                label2.Style.Add("font-family", "MS Sans Serif")
                label2.Style.Add("font-weight", "bold")
                label2.Style.Add("text-align", "center")

                Dim label3 As Label = New Label()
                label3.Width = "200"
                label3.Height = "20"
                label3.ID = "lab3" & Format(icount, "00")
                label3.Style.Add("font-size", "12px")
                label3.Style.Add("font-family", "MS Sans Serif")
                label3.Style.Add("font-weight", "bold")
                label3.Style.Add("text-align", "center")

                Dim label4 As Label = New Label()
                label4.Width = "200"
                label4.Height = "20"
                label4.ID = "lab4" & Format(icount, "00")
                label4.Style.Add("font-size", "12px")
                label4.Style.Add("font-family", "MS Sans Serif")
                label4.Style.Add("font-weight", "bold")
                label4.Style.Add("text-align", "center")

                Dim label5 As Label = New Label()
                label5.Width = "200"
                label5.Height = "20"
                label5.ID = "lab5" & Format(icount, "00")
                label5.Style.Add("font-size", "12px")
                label5.Style.Add("font-family", "MS Sans Serif")
                label5.Style.Add("font-weight", "bold")
                label5.Style.Add("text-align", "center")

                Dim label6 As Label = New Label()
                label6.Width = "200"
                label6.Height = "20"
                label6.ID = "lab6" & Format(icount, "00")
                label6.Style.Add("font-size", "12px")
                label6.Style.Add("font-family", "MS Sans Serif")
                label6.Style.Add("font-weight", "bold")
                label6.Style.Add("text-align", "center")
                label6.Visible = False

                Dim label7 As Label = New Label()
                label7.Width = "200"
                label7.Height = "20"
                label7.ID = "lab7" & Format(icount, "00")
                label7.Style.Add("font-size", "12px")
                label7.Style.Add("font-family", "MS Sans Serif")
                label7.Style.Add("font-weight", "bold")
                label7.Style.Add("text-align", "center")
                label7.Visible = False

                Dim label8 As Label = New Label()
                label8.Width = "200"
                label8.Height = "20"
                label8.ID = "lab8" & Format(icount, "00")
                label8.Style.Add("font-size", "12px")
                label8.Style.Add("font-family", "MS Sans Serif")
                label8.Style.Add("font-weight", "bold")
                label8.Style.Add("text-align", "center")
                label8.Visible = False

                Dim label9 As Label = New Label()
                label9.Width = "200"
                label9.Height = "20"
                label9.ID = "lab9" & Format(icount, "00")
                label9.Style.Add("font-size", "12px")
                label9.Style.Add("font-family", "MS Sans Serif")
                label9.Style.Add("font-weight", "bold")
                label9.Style.Add("text-align", "center")
                label9.Visible = False

                label1.Text = ds_getbank.Tables(0).Rows(icount).Item("BSB").ToString
                label2.Text = ds_getbank.Tables(0).Rows(icount).Item("Account_Number").ToString
                label3.Text = ds_getbank.Tables(0).Rows(icount).Item("Bank_Name").ToString
                label4.Text = ds_getbank.Tables(0).Rows(icount).Item("Bank_Suburb").ToString
                label5.Text = ds_getbank.Tables(0).Rows(icount).Item("Account_Name").ToString
                label6.Text = ds_getbank.Tables(0).Rows(icount).Item("Bank_Account_ID").ToString
                label7.Text = ds_getbank.Tables(0).Rows(icount).Item("Bank_Address").ToString
                label8.Text = ds_getbank.Tables(0).Rows(icount).Item("Bank_State").ToString
                label9.Text = ds_getbank.Tables(0).Rows(icount).Item("Bank_Post_Code").ToString
                tc.Controls.Add(radio_repay)
                tc.Controls.Add(label1)
                tc.Controls.Add(label2)
                tc.Controls.Add(label3)
                tc.Controls.Add(label4)
                tc.Controls.Add(label5)
                tc.Controls.Add(label6)
                tc.Controls.Add(label7)
                tc.Controls.Add(label8)
                tc.Controls.Add(label9)
                tr.Cells.Add(tc)
                tbl.Rows.Add(tr)
            Next


            PlaceHolder1.Controls.Clear()
            PlaceHolder1.Controls.Add(tbl)
            ds_getbank.Dispose()

            'GridView1.DataSource = ds_getbank.Tables(0)
            'GridView1.DataBind()
            'ds_getbank.Dispose()
            'GridView1.Visible = True
        Else
            'Label1.Visible = True
            Btnnominate.Visible = False
            LinkButton1.Visible = True
        End If
    End Sub

    Protected Sub Btnnominate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnnominate.Click
        Dim sessionString As String
        Dim i As Integer = Session("count1")
        Dim radio_dis As New RadioButton
        Try
            For j = 0 To Session("count1") - 1
                radio_dis = Me.FindControl("radio_repay" & "0" & j)
                If radio_dis.Checked = True Then

                    Dim bank_details As New Label

                    bank_details = Me.FindControl("lab1" & Format(j, "00"))
                    sessionString = bank_details.Text
                    Session("bsb") = sessionString

                    bank_details = Me.FindControl("lab2" & Format(j, "00"))
                    sessionString = bank_details.Text
                    Session("account_number") = sessionString

                    bank_details = Me.FindControl("lab3" & Format(j, "00"))
                    sessionString = bank_details.Text
                    Session("bank_name") = sessionString

                    bank_details = Me.FindControl("lab4" & Format(j, "00"))
                    sessionString = bank_details.Text
                    Session("suburb") = sessionString

                    bank_details = Me.FindControl("lab5" & Format(j, "00"))
                    sessionString = bank_details.Text
                    Session("account_name") = sessionString

                    bank_details = Me.FindControl("lab6" & Format(j, "00"))
                    sessionString = bank_details.Text
                    Session("Bank_Account_ID") = sessionString

                    bank_details = Me.FindControl("lab7" & Format(j, "00"))
                    sessionString = bank_details.Text
                    Session("bank_address") = sessionString

                    bank_details = Me.FindControl("lab8" & Format(j, "00"))
                    sessionString = bank_details.Text
                    Session("state") = sessionString

                    bank_details = Me.FindControl("lab9" & Format(j, "00"))
                    sessionString = bank_details.Text
                    Session("postcode") = sessionString



                    txtAccountName.Text = Session("account_name")
                    txtAccountNumber.Text = Session("account_number")
                    txtBankAddress.Text = Session("bank_address")
                    txtBankName.Text = Session("bank_name")
                    txtBankPostCode.Text = Session("postcode")
                    txtBankState.Text = Session("state")
                    txtBankSuburb.Text = Session("suburb")
                    txtBSB.Text = Session("bsb")
                End If
            Next

            'Get the checked Radiobutton
            If Session("Bank_Account_ID") = "" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No account has been selected for direct debit!!!" & "');", True)
                Exit Sub
            End If

            If Session("nominate_msg") = True Then
                Dim str_acc, str_acc1 As String
                str_acc = "UPDATE Tbl_Loan set Bank_Account_ID = " & Session("Bank_Account_ID") & " WHERE Loan_ID = " & Session("cur_loan_id")
                str_acc1 = "UPDATE Tbl_Customer set Bank_Account_ID = " & Session("Bank_Account_ID") & " WHERE Customer_ID = " & open_con.customer_id_val
                nominatebnk_selection(str_acc, str_acc1)
                Exit Sub
            Else
            End If

            If Session("flag_beginning") = True Then
                Dim str_acc, str_acc1 As String
                str_acc = "UPDATE Tbl_Loan set Bank_Account_ID = " & Session("Bank_Account_ID") & " WHERE Loan_ID = " & Session("beg_loan_id")
                str_acc1 = "UPDATE Tbl_Customer set Bank_Account_ID = " & Session("Bank_Account_ID") & " WHERE Customer_ID = " & open_con.customer_id_val
                nominatebnk_selection(str_acc, str_acc1)
                Exit Sub
            Else
            End If

            'If Session("beg_status") = "" Then
            '    Dim str_acc, str_acc1 As String
            '    str_acc = "UPDATE Tbl_Loan set Bank_Account_ID = " & Session("Bank_Account_ID") & " WHERE Loan_ID = " & Session("cur_loan_id")
            '    str_acc1 = "UPDATE Tbl_Customer set Bank_Account_ID = " & Session("Bank_Account_ID") & " WHERE Customer_ID = " & open_con.customer_id_val
            '    nominatebnk_selection(str_acc, str_acc1)
            'End If

            If Session("beg_status") = "Pending" Then
                Dim str_acc, str_acc1 As String
                str_acc = "UPDATE Tbl_Loan set Bank_Account_ID = " & Session("Bank_Account_ID") & " WHERE Loan_ID = " & Session("beg_loan_id")
                str_acc1 = "UPDATE Tbl_Customer set Bank_Account_ID = " & Session("Bank_Account_ID") & " WHERE Customer_ID = " & open_con.customer_id_val
                nominatebnk_selection(str_acc, str_acc1)
            End If

        Catch ex As Exception
            Session("Nominate_BSB") = False
            Response.Write("Error: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Sub nominatebnk_selection(ByVal str_acc As String, ByVal str_acc1 As String)
        Try
            If Session("row_index") < 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No account has been selected for direct debit!!!" & "');", True)
                Exit Sub
            End If
            Dim cmd_acc As New SqlCommand
            cmd_acc.Connection = open_con.return_con
            cmd_acc.CommandText = str_acc
            cmd_acc.ExecuteNonQuery()
            cmd_acc.Dispose()
            open_con.return_con.Dispose()
            Dim cmd_acc_new As New SqlCommand
            cmd_acc_new.Connection = open_con.return_con
            cmd_acc_new.CommandText = str_acc1
            cmd_acc_new.ExecuteNonQuery()
            cmd_acc_new.Dispose()
            open_con.return_con.Dispose()
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Selected account is nominated for direct debit!!!" & "');", True)
            'GridView1.Visible = True
            Btnnominate.Visible = True
            Session("Nominate_BSB") = True
            Session("Bank_Account_ID") = ""
            txtAccountName.Text = Session("account_name")
            txtAccountNumber.Text = Session("account_number")
            txtBankAddress.Text = Session("bank_address")
            txtBankName.Text = Session("bank_name")
            txtBankPostCode.Text = Session("postcode")
            txtBankState.Text = Session("state")
            txtBankSuburb.Text = Session("suburb")
            txtBSB.Text = Session("bsb")
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub

End Class
