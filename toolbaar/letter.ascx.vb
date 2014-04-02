Imports System.Data.SqlClient
Imports System
Imports System.Data
Partial Class toolbaar_letter
    Inherits System.Web.UI.UserControl
    Dim open_con As New Class1
    Dim max_payment_id As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            If Page.IsPostBack = True Then
                letter_panel_show()
            End If
        End If
    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='none';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFBD6'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            e.Row.Attributes.Add("ondblClick", Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex))
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row_index As Integer
        row_index = GridView1.SelectedRow.RowIndex
        Dim description As String
        description = GridView1.Rows(row_index).Cells.Item(0).Text
        Session("Description") = description
        Dim Notice_ID As String
        Notice_ID = GridView1.Rows(row_index).Cells.Item(3).Text
        Session("Notice_ID") = Notice_ID
        If description = "Dishonour Letter" Then
            Response.Redirect("./letter_container.aspx", False)
        ElseIf description = "Direct Debit Cancel" Then
            Response.Redirect("./letter_debitpayroll.aspx", False)
        ElseIf description = "Payroll Cancel" Then
            Response.Redirect("./letter_debitpayroll.aspx", False)
        ElseIf description = "Enforcement Letter" Then
            Response.Redirect("Enforcementletter.aspx", False)
        ElseIf description = "Contract Dishonour" Then
            Response.Redirect("Contract dishonour.aspx", False)
        End If

    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.Cells.Item(1).Text = "&nbsp;" Then
            e.Row.Cells(1).Text = ""
        ElseIf e.Row.Cells.Item(1).Text = "Notice created on" Then
            e.Row.Cells.Item(1).Text = "Notice created on"
        Else
            e.Row.Cells(1).Text = Date.Parse(e.Row.Cells(1).Text).ToString("dd-MMM-yyyy")
        End If
        If e.Row.Cells.Item(2).Text = "&nbsp;" Then
            e.Row.Cells(2).Text = ""
        ElseIf e.Row.Cells.Item(2).Text = "Notice expires on" Then
            e.Row.Cells.Item(2).Text = "Notice expires on"
        Else
            e.Row.Cells(2).Text = Date.Parse(e.Row.Cells(2).Text).ToString("dd-MMM-yyyy")
        End If

        e.Row.Cells(3).Visible = False
    End Sub
    Sub letter_bind(ByVal loan_id As Integer)
        Try
            Dim strSQL_notice As String
            Dim cmd_notice As New SqlCommand
            Dim adap_notice As SqlDataAdapter
            Dim ds_notice As New DataSet

            strSQL_notice = " SELECT * FROM Tbl_Notice WHERE Tbl_Notice.Loan_ID = " & loan_id & " ORDER BY Tbl_Notice.Notice_Created_On DESC "

            cmd_notice.CommandText = strSQL_notice
            cmd_notice.Connection = open_con.return_con
            adap_notice = New SqlDataAdapter(cmd_notice)
            adap_notice.Fill(ds_notice)

            If ds_notice.Tables(0).Rows.Count = 0 Then
                lbl_letter.Visible = True
                GridView1.Visible = False
                cancel_letter.Visible = False
                letter_enf.Visible = False
                cmd_notice.Dispose()
                ds_notice.Dispose()
                adap_notice.Dispose()
                open_con.return_con.Dispose()
                Exit Sub
            Else
                lbl_letter.Visible = False
                GridView1.Visible = True
                GridView1.DataSource = ds_notice
                GridView1.DataBind()
                cancel_letter.Visible = True
                letter_enf.Visible = True
                cmd_notice.Dispose()
                ds_notice.Dispose()
                adap_notice.Dispose()
                open_con.return_con.Dispose()
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Protected Sub cancel_letter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancel_letter.Click
        Panel1.Visible = False
        Session("letter") = 0
        Session("bank_nom") = False
        Session("loan_st") = 0
        Session("sch_history") = 0
        Dim panel_2 As Panel = Page.FindControl("panel2")
        panel_2.Visible = True
        Dim panel_3 As Panel = Page.FindControl("panel3")
        panel_3.Visible = True
        Dim panel_4 As Panel = Page.FindControl("panel4")
        panel_4.Visible = False
        Dim panel_5 As Panel = Page.FindControl("panel5")
        panel_5.Visible = False
        Dim panel_6 As Panel = Page.FindControl("panel6")
        panel_6.Visible = False
        '''''''to disable waive buttons
        Dim btnwaive1_letter As Button = Page.FindControl("tool_7").FindControl("btnwaive1")
        btnwaive1_letter.Visible = False
        Dim btncncl_letter As Button = Page.FindControl("tool_7").FindControl("btncncl")
        btncncl_letter.Visible = False
        ''''''''''''to disable enforcement buttons
        Dim btnenfrc_letter As Button = Page.FindControl("tool_7").FindControl("btnenfrc")
        btnenfrc_letter.Visible = False
        Dim btncncl_enf_letter As Button = Page.FindControl("tool_7").FindControl("btncncl_enf")
        btncncl_enf_letter.Visible = False

        ''''''''''to disable cancel buttons

        Dim btncncl_save_letter As Button = Page.FindControl("tool_7").FindControl("btncncl_save")
        btncncl_save_letter.Visible = False
        Dim btncnl_cncl_letter As Button = Page.FindControl("tool_7").FindControl("btncnl_cncl")
        btncnl_cncl_letter.Visible = False

        ''''''''''''''''''''''''''to disable payment buttons
        Dim btnsave_pay_letter As Button = Page.FindControl("tool_7").FindControl("btnsave_pay")
        btnsave_pay_letter.Visible = False
        Dim btncncl_pay_letter As Button = Page.FindControl("tool_7").FindControl("btncncl_pay")
        btncncl_pay_letter.Visible = False

        '''''''''''''''to disable modify buttons
        Dim btnsave_mod_letter As Button = Page.FindControl("tool_7").FindControl("btnsave_mod")
        btnsave_mod_letter.Visible = False
        Dim btncncl_mod_letter As Button = Page.FindControl("tool_7").FindControl("btncncl_mod")
        btncncl_mod_letter.Visible = False

        '''''''''''''''to disable dishonour buttons
        Dim btnsave_dis_letter As Button = Page.FindControl("tool_7").FindControl("btnsave_dis")
        btnsave_dis_letter.Visible = False
        Dim btncncl_dis_letter As Button = Page.FindControl("tool_7").FindControl("btncncl_dis")
        btncncl_dis_letter.Visible = False

    End Sub

    Protected Sub letter_enf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles letter_enf.Click
        Try
            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then


                Dim str_check_SQL As String
                Dim cmd_check_SQL As New SqlCommand
                Dim adap_check_SQL As SqlDataAdapter
                Dim ds_check_SQL As New DataSet

                str_check_SQL = " SELECT max(Tbl_Notice.Loan_ID) AS Loan_ID, max(Tbl_Notice.Amount_Outstanding) AS Amount_Outstanding, max(Tbl_Notice.Notice_Expires_On) AS Notice_Expires_On, max(Tbl_Notice.Notice_Created_On) AS Notice_Created_On, max(Tbl_Notice.Description) AS Description FROM Tbl_Notice"
                str_check_SQL = str_check_SQL & " WHERE (Tbl_Notice.Description='1st Notice' Or Tbl_Notice.Description ='Default 2' Or Tbl_Notice.Description='Demand' Or Tbl_Notice.Description='Dishonour letter' Or Tbl_Notice.Description='Contract Dishonour') "
                str_check_SQL = str_check_SQL & " GROUP BY Tbl_Notice.Loan_ID HAVING max(Tbl_Notice.Loan_ID) = " & Session("enf_loan_id")
                cmd_check_SQL.CommandText = str_check_SQL
                cmd_check_SQL.Connection = open_con.return_con
                adap_check_SQL = New SqlDataAdapter(cmd_check_SQL)
                adap_check_SQL.Fill(ds_check_SQL)

                If Not ds_check_SQL.Tables(0).Rows.Count = 0 Then


                    Dim str_check_SQL1 As String
                    Dim cmd_check_SQL1 As New SqlCommand
                    Dim str_check_SQL2 As String
                    Dim cmd_check_SQL2 As New SqlCommand
                    Dim str_check_SQL3 As String
                    Dim cmd_check_SQL3 As New SqlCommand
                    Dim str_check_SQL4 As String
                    Dim cmd_check_SQL4 As New SqlCommand
                    Dim adap_check_SQL4 As SqlDataAdapter
                    Dim ds_check_SQL4 As New DataSet
                    str_check_SQL3 = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Description, Due_Date, Amount, Payment_Method, Transaction_Date, Date_Updated, Fee_Status) values "
                    str_check_SQL3 = str_check_SQL3 & " ("
                    str_check_SQL3 = str_check_SQL3 & Session("enf_loan_id") & ","
                    str_check_SQL3 = str_check_SQL3 & open_con.customer_id_val & ","
                    str_check_SQL3 = str_check_SQL3 & "'Enforcement fee'" & ",@enf_date,"
                    str_check_SQL3 = str_check_SQL3 & "20.00" & ","
                    str_check_SQL3 = str_check_SQL3 & "'Def'" & ",@trns_date,@upd_date,"
                    str_check_SQL3 = str_check_SQL3 & "'Enforcement fee'" & ")"
                    cmd_check_SQL3.CommandText = str_check_SQL3

                    cmd_check_SQL3.Parameters.Add("@enf_date", SqlDbType.Date).Value = System.DateTime.Now.Date
                    cmd_check_SQL3.Parameters.Add("@trns_date", SqlDbType.Date).Value = System.DateTime.Now.Date
                    cmd_check_SQL3.Parameters.Add("@upd_date", SqlDbType.Date).Value = System.DateTime.Now.Date
                    cmd_check_SQL3.Connection = open_con.return_con
                    cmd_check_SQL3.ExecuteNonQuery()

                    str_check_SQL4 = "Select max(payment_id) from Tbl_Payment "
                    cmd_check_SQL4.Connection = open_con.return_con
                    cmd_check_SQL4.CommandText = str_check_SQL4
                    adap_check_SQL4 = New SqlDataAdapter(cmd_check_SQL4)
                    adap_check_SQL4.Fill(ds_check_SQL4)

                    If Not ds_check_SQL4.Tables(0).Rows.Count = 0 Then
                        max_payment_id = CInt(ds_check_SQL4.Tables(0).Rows(0).Item(0).ToString)
                    End If



                    Dim str_amount_due As String

                    str_amount_due = "SELECT Tbl_Payment.Loan_ID, Sum(Tbl_Payment.Amount) AS Amount_Outstanding FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID "
                    str_amount_due = str_amount_due & "WHERE (((Tbl_Payment.Description)='Arear notice fee' Or (Tbl_Payment.Description)='Statement of account fee' Or (Tbl_Payment.Description)='Variation fee' Or (Tbl_Payment.Description)='Default notice fee' Or (Tbl_Payment.Description)='Letter of demand fee' Or (Tbl_Payment.Description)='Dishonoured fee' Or (Tbl_Payment.Description)='Enforcement fee' Or (Tbl_Payment.Description) Is Null OR Tbl_Payment.Description = '') AND ((Tbl_Payment.Transaction_Status) Is Null) AND ((Tbl_Payment.Payment_Date) Is Null) AND ((Tbl_Payment_1.Update_ID) Is Null)) "
                    str_amount_due = str_amount_due & "GROUP BY Tbl_Payment.Loan_ID HAVING Tbl_Payment.Loan_ID=" & Session("enf_loan_id") & "ORDER BY Tbl_Payment.Loan_ID "
                    Dim cmd_amount_due As New SqlCommand
                    Dim adap_amount_due As SqlDataAdapter
                    Dim ds_amount_due As New DataSet
                    cmd_amount_due.CommandText = str_amount_due
                    cmd_amount_due.Connection = open_con.return_con
                    cmd_amount_due.ExecuteNonQuery()
                    adap_amount_due = New SqlDataAdapter(cmd_amount_due)
                    adap_amount_due.Fill(ds_amount_due)

                    str_check_SQL1 = "Insert into Tbl_Notice(Customer_ID, Loan_ID,Payment_id, Amount_Outstanding, Description, Previous_Notice_Created_On, Notice_Expires_On, User_ID, Notice_Created_On) values "
                    str_check_SQL1 = str_check_SQL1 & "(" & open_con.customer_id_val & "," & Session("enf_loan_id") & "," & max_payment_id & ",@amt_enf" & ",'Enforcement Letter',@prev_date,@exp_date,"
                    str_check_SQL1 = str_check_SQL1 & open_con.user_id_val & ",@tod_date)"
                    cmd_check_SQL1.CommandText = str_check_SQL1
                  
                    Dim enf_amt As Double
                    If Val(ds_amount_due.Tables(0).Rows.Count) = 0 Then

                        enf_amt = CDbl(20)
                    Else

                        enf_amt = ds_amount_due.Tables(0).Rows(0).Item(1).ToString + CDbl(20)
                    End If

                    cmd_check_SQL1.Parameters.Add("@amt_enf", SqlDbType.Money).Value = enf_amt
                    cmd_check_SQL1.Parameters.Add("@prev_date", SqlDbType.Date).Value = ds_check_SQL.Tables(0).Rows(0).Item("Notice_Created_On")
                    cmd_check_SQL1.Parameters.Add("@exp_date", SqlDbType.Date).Value = System.DateTime.Now.Date.AddDays(30)
                    cmd_check_SQL1.Parameters.Add("@tod_date", SqlDbType.Date).Value = System.DateTime.Now.Date
                    cmd_check_SQL1.Connection = open_con.return_con
                    cmd_check_SQL1.ExecuteNonQuery()



                    str_check_SQL2 = " UPDATE Tbl_Payment SET Tbl_Payment.Payment_Method = 'Def'"
                    str_check_SQL2 = str_check_SQL2 & " WHERE (Tbl_Payment.Description='Arear notice fee' Or Tbl_Payment.Description='Statement of account fee' Or Tbl_Payment.Description='Variation fee' Or Tbl_Payment.Description='Default notice fee' Or Tbl_Payment.Description='Letter of demand fee' Or Tbl_Payment.Description='Dishonoured fee' Or Tbl_Payment.Description Is Null OR Tbl_Payment.Description = '') And Tbl_Payment.Payment_Date Is Null And Tbl_Payment.Loan_ID= " & Session("enf_loan_id")
                    cmd_check_SQL2.CommandText = str_check_SQL2
                    cmd_check_SQL2.Connection = open_con.return_con
                    cmd_check_SQL2.ExecuteNonQuery()






                    If Page.IsPostBack = True Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Enforcement letter has been created, $20.00 Default notice fee has been added." & "');", True)

                        Dim panel_2 As Panel = Page.FindControl("panel2")
                        panel_2.Visible = True
                        Dim panel_3 As Panel = Page.FindControl("panel3")
                        panel_3.Visible = False
                        Dim panel_4 As Panel = Page.FindControl("panel4")
                        panel_4.Visible = True
                    End If


                    letter_panel_show()
                    adap_check_SQL.Dispose()
                    ds_check_SQL.Dispose()
                    cmd_check_SQL.Dispose()
                    cmd_check_SQL1.Dispose()
                    cmd_check_SQL2.Dispose()
                    cmd_check_SQL3.Dispose()
                    open_con.return_con.Dispose()

                Else
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Enforcement letter can not be created at this time." & "');", True)
                    Exit Sub

                End If
            Else

            End If
        Catch ex As Exception
            Dim cmd_del_fee As New SqlCommand("sp_delete_enf_fee", open_con.return_con)
            cmd_del_fee.CommandType = CommandType.StoredProcedure
            cmd_del_fee.Parameters.Add("@a", SqlDbType.Int).Value = max_payment_id
            cmd_del_fee.ExecuteNonQuery()
            open_con.return_con.Dispose()
            cmd_del_fee.Dispose()
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub
    Sub letter_panel_show()

        Panel1.Visible = True
        Dim loan_id As Integer
        If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

            loan_id = Session("beg_loan_id")
            Session("enf_loan_id") = loan_id
            letter_bind(loan_id)
        ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
            loan_id = Session("beg_loan_id")
            Session("enf_loan_id") = loan_id
            letter_bind(loan_id)

        ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

            loan_id = Session("cur_loan_id")
            Session("enf_loan_id") = loan_id
            letter_bind(loan_id)

        ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

            loan_id = Session("cur_loan_id")
            Session("enf_loan_id") = loan_id
            letter_bind(loan_id)

        ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

            loan_id = Session("beg_loan_id")
            Session("enf_loan_id") = loan_id
            letter_bind(loan_id)

        ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False Then

            loan_id = Session("cur_loan_id")
            Session("enf_loan_id") = loan_id
            letter_bind(loan_id)

        End If

    End Sub
End Class
