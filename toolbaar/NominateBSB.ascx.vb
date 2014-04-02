Imports System.Data.SqlClient
Imports System.Data

Partial Class toolbaar_NominateBSB
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
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFBD6'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            e.Row.Attributes.Add("ondblClick", Me.Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex))
        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Dim row_index As Integer
        row_index = GridView1.SelectedRow.RowIndex
        ''''''''''''this is used to calculate no. of rows in a grid
        Session("row_index") = GridView1.SelectedRow.RowIndex

        If GridView1.Rows(row_index).Cells.Item(0).Text = "&nbsp;" Then
            Session("bsb") = ""
        Else
            Session("bsb") = GridView1.Rows(row_index).Cells.Item(0).Text
        End If
        If GridView1.Rows(row_index).Cells.Item(1).Text = "&nbsp;" Then
            Session("account_number") = ""
        Else
            Session("account_number") = GridView1.Rows(row_index).Cells.Item(1).Text
        End If
        If GridView1.Rows(row_index).Cells.Item(2).Text = "&nbsp;" Then
            Session("bank_name") = ""
        Else
            Session("bank_name") = GridView1.Rows(row_index).Cells.Item(2).Text
        End If
        'Session("account_name") = Session("Customer_namebank")
        If GridView1.Rows(row_index).Cells.Item(3).Text = "&nbsp;" Then
            Session("suburb") = ""
        Else
            Session("suburb") = GridView1.Rows(row_index).Cells.Item(3).Text
        End If
        If GridView1.Rows(row_index).Cells.Item(4).Text = "&nbsp;" Then
            Session("state") = ""
        Else
            Session("state") = GridView1.Rows(row_index).Cells.Item(4).Text
        End If
        If GridView1.Rows(row_index).Cells.Item(5).Text = "&nbsp;" Then
            Session("postcode") = ""
        Else
            Session("postcode") = GridView1.Rows(row_index).Cells.Item(5).Text
        End If
        If GridView1.Rows(row_index).Cells.Item(6).Text = "&nbsp;" Then
            Session("bank_address") = ""
        Else
            Session("bank_address") = GridView1.Rows(row_index).Cells.Item(6).Text
        End If

        If GridView1.Rows(row_index).Cells.Item(7).Text = "&nbsp;" Then
            Session("Bank_Account_ID") = ""
        Else
            Session("Bank_Account_ID") = GridView1.Rows(row_index).Cells.Item(7).Text
        End If
        If GridView1.Rows(row_index).Cells.Item(8).Text = "&nbsp;" Then
            Session("Account_Name") = ""
        Else
            Session("Account_Name") = GridView1.Rows(row_index).Cells.Item(8).Text
        End If
        txtAccountName.Text = Session("account_name")
        txtAccountNumber.Text = Session("account_number")
        txtBankAddress.Text = Session("bank_address")
        txtBankName.Text = Session("bank_name")
        txtBankPostCode.Text = Session("postcode")
        txtBankState.Text = Session("state")
        txtBankSuburb.Text = Session("suburb")
        txtBSB.Text = Session("bsb")


        If row_index < 0 Then
            Session("row_index") = -1
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        e.Row.Cells(5).Visible = False
        e.Row.Cells(6).Visible = False
        e.Row.Cells(7).Visible = False
        e.Row.Cells(8).Visible = False
    End Sub
    Protected Sub Btnnominate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnnominate.Click
        Try
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
            GridView1.Visible = True
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
            Label1.Visible = False
            Btnnominate.Visible = True
            LinkButton1.Visible = False
            GridView1.DataSource = ds_getbank.Tables(0)
            GridView1.DataBind()
            ds_getbank.Dispose()
            GridView1.Visible = True
        Else
            Label1.Visible = True
            Btnnominate.Visible = False
            LinkButton1.Visible = True
      
        End If
      
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
