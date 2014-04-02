Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows
Imports AjaxControlToolkit
Partial Class Customer_LoanSummary
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Dim flag_val As Boolean = False
    Dim r_load As Boolean
    Function fn_AdjustStringForSQL(ByVal psStringtoChange As String) As String
        Dim lStartPosition As Integer
        lStartPosition = 1
        While InStr(lStartPosition, psStringtoChange, "'")
            psStringtoChange = Left(psStringtoChange, InStr(lStartPosition, psStringtoChange, "'")) & Mid(psStringtoChange, InStr(lStartPosition, psStringtoChange, "'"), Len(psStringtoChange))
            lStartPosition = InStr(lStartPosition, psStringtoChange, "'") + 2
        End While
        fn_AdjustStringForSQL = psStringtoChange

    End Function
    Protected Sub binddata()
        Try
            r_load = True
            Dim cmd As New SqlCommand
            Dim str_SQL As String
            str_SQL = " SELECT *  FROM Tbl_Customer where  "
            If txtsearch.Text <> "" Then
                If IsNumeric(Trim(txtsearch.Text)) Then
                    str_SQL = str_SQL & "Customer_ID = " & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & " OR "
                End If
                str_SQL = str_SQL & " Given_Name like '" & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & "%'"
                str_SQL = str_SQL & " OR Last_Name like '" & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & "%'"
                str_SQL = str_SQL & " OR R_Given_Name like '" & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & "%'"
                str_SQL = str_SQL & " OR R_Last_Name like '" & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & "%'"
                str_SQL = str_SQL & " ORDER BY Given_Name, Last_Name "
                cmd.Connection = open_con.return_con
                cmd.CommandText = str_SQL
                cmd.ExecuteNonQuery()
                Dim adap As SqlDataAdapter
                adap = New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                adap.Fill(ds)
                If ds.Tables(0).Rows.Count = 0 Then

                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No such Customer Exist!!!" & "');", True)
                    txtsearch.Text = ""
                    txtsearch.Focus()
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                    label3.Visible = False
                    Exit Sub
                Else
                    txtsearch.Text = ""
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                    label3.Visible = True
                End If
                adap.Dispose()
                cmd.Dispose()
                ds.Dispose()
                open_con.return_con.Dispose()
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid Customer Name or ID!!!" & "');", True)
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)

        End Try
    End Sub
    Protected Sub LinkButton_AddCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_AddCustomer.Click
        Response.Redirect("./Personal_Form.aspx", False)
    End Sub

    Protected Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFBD6'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            e.Row.Attributes.Add("ondblClick", ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex))

        End If

    End Sub
    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.Cells.Item(4).Text = "&nbsp;" Then
            e.Row.Cells(4).Text = ""
        ElseIf e.Row.Cells.Item(4).Text = "Request Amount" Then
            e.Row.Cells.Item(4).Text = "Request Amount"
        Else
            e.Row.Cells(4).Text = CStr(e.Row.Cells(4).Text.ToString)
        End If

    End Sub
    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row_index As Integer
        row_index = GridView1.SelectedRow.RowIndex
        Dim customer_ID As Integer
        Dim last_name As String
        Dim given_name As String

        customer_ID = GridView1.Rows(row_index).Cells.Item(0).Text
        open_con.customer_id_val = customer_ID

        given_name = GridView1.Rows(row_index).Cells.Item(1).Text
        last_name = GridView1.Rows(row_index).Cells.Item(2).Text

        Session("Customer_name") = given_name & " " & last_name & " " & Session("branch_prefix") & " " & open_con.customer_id_val
        Session("Customer_namebank") = given_name & " " & last_name

        Response.Redirect("./Detail.aspx", False)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        '------ tool ---------------------

        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Label_customername.Text = Session("Customer_name")
            Session("user_type") = open_con.manager_name(Session("user_id"))

            If open_con.customer_status(open_con.customer_id_val).status = True Or open_con.followup_status(open_con.customer_id_val) = True Then
                LinkButton8.Enabled = False
                LinkButton8.Attributes.CssStyle.Add("background", "Platinum")
                LinkButton8.Attributes.CssStyle.Add("color", "white")
                LinkButton9.Enabled = False
                LinkButton9.Attributes.CssStyle.Add("background", "Platinum")
                LinkButton9.Attributes.CssStyle.Add("color", "white")
            End If


            If Session("user_type") = "Admin" Then
                If open_con.customer_status(open_con.customer_id_val).status = True Then
                    LinkButton10.Enabled = False
                    LinkButton11.Visible = True
                    LinkButton10.Attributes.CssStyle.Add("background", "Platinum")
                    LinkButton10.Attributes.CssStyle.Add("color", "white")

                Else
                    LinkButton10.Visible = True
                    LinkButton11.Visible = True

                End If


            Else
                LinkButton10.Visible = True
                LinkButton11.Enabled = False
                LinkButton11.Attributes.CssStyle.Add("background", "Platinum")
                LinkButton11.Attributes.CssStyle.Add("color", "white")

            End If

            If Session("user_type") = "Admin" Or Session("user_type") = "Manager" Then

                If open_con.followup_status(open_con.customer_id_val) = True Then
                    LinkButton12.Enabled = False
                    LinkButton13.Visible = True
                    LinkButton12.Attributes.CssStyle.Add("background", "Platinum")
                    LinkButton12.Attributes.CssStyle.Add("color", "white")
                Else
                    LinkButton12.Visible = True
                    LinkButton13.Visible = True
                End If

            Else
                LinkButton12.Visible = True
                LinkButton13.Enabled = False
                LinkButton13.Attributes.CssStyle.Add("background", "Platinum")
                LinkButton13.Attributes.CssStyle.Add("color", "white")
            End If
        End If


        '---------------------------------

        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            If Session("beg_status") = "Pending" And Val(txtsearch.Text) = 0 And Session("flag_beginning") = True Then
                If open_con.check_nominate(Session("beg_loan_id")) = True Then

                    Panel1.Visible = True
                    Panel2.Visible = True
                    Panel3.Visible = False
                    Panel4.Visible = False
                    Panel5.Visible = False
                    Panel6.Visible = False
                    Panel7.Visible = False
                    Panel8.Visible = False
                Else
                    Panel1.Visible = True
                    Panel2.Visible = True
                    Panel3.Visible = False
                    Panel4.Visible = False
                    Panel5.Visible = False
                    Panel6.Visible = False
                    Panel7.Visible = False
                    Panel8.Visible = False
                End If
                btnapprove.Visible = True
                btndecline.Visible = True

            ElseIf Session("beg_status") = "Approved" And Session("flag_approve") = False And Val(txtsearch.Text) = 0 Then

                If open_con.check_nominate(Session("beg_loan_id")) = True And Session("bank_nom") = False And Session("loan_st") = 0 And Session("letter") = 0 And Session("sch_history") = 0 And Session("pay_re") = False And Session("pay_sch") = False Then

                    Panel1.Visible = False
                    Panel2.Visible = True
                    Panel3.Visible = True
                    Panel4.Visible = False
                    Panel5.Visible = False
                    Panel6.Visible = False
                    Panel7.Visible = False
                    Label5.Visible = False
                    Panel7.Visible = False
                Else
                    Panel2.Visible = True
                    Panel3.Visible = False
                    If Session("letter") = 1 Then
                        Panel4.Visible = True
                    ElseIf Session("bank_nom") = True Then
                        Panel1.Visible = True
                    ElseIf Session("sch_history") = 1 Then
                        Panel5.Visible = True
                    ElseIf Session("loan_st") = 1 Then
                        Panel6.Visible = True
                    ElseIf Session("pay_re") = True Then
                        Panel7.Visible = True
                    ElseIf Session("pay_sch") = True Then
                        Panel8.Visible = True

                    End If
                    Label5.Visible = False
                End If

                btnapprove.Visible = False
                btndecline.Visible = False

            ElseIf Session("beg_status") = "Approved" And Session("flag_approve") = True And Val(txtsearch.Text) = 0 And Session("flag_beginning") = True Then

                If open_con.check_nominate(Session("beg_loan_id")) = True And Session("bank_nom") = False And Session("loan_st") = 0 And Session("letter") = 0 And Session("sch_history") = 0 And Session("pay_re") = False And Session("pay_sch") = False Then

                    Panel1.Visible = False
                    Panel2.Visible = True
                    Panel3.Visible = True
                    Panel4.Visible = False
                    Panel5.Visible = False
                    Panel6.Visible = False
                    Panel7.Visible = False
                    Label5.Visible = False
                    Panel7.Visible = False
                Else
                    Panel2.Visible = True
                    Panel3.Visible = False
                    If Session("letter") = 1 Then
                        Panel4.Visible = True
                    ElseIf Session("bank_nom") = True Then
                        Panel1.Visible = True
                    ElseIf Session("sch_history") = 1 Then
                        Panel5.Visible = True
                    ElseIf Session("loan_st") = 1 Then
                        Panel6.Visible = True
                    ElseIf Session("pay_re") = True Then
                        Panel7.Visible = True
                    ElseIf Session("pay_sch") = True Then
                        Panel8.Visible = True

                    End If
                    Label5.Visible = False
                End If

                btnapprove.Visible = False
                btndecline.Visible = False
            ElseIf Session("beg_status") = "Approved" And Session("flag_approve") = True And Val(txtsearch.Text) = 0 And Session("flag_beginning") = False Then

                If open_con.check_nominate(Session("cur_loan_id")) = True And Session("bank_nom") = False And Session("loan_st") = 0 And Session("letter") = 0 And Session("sch_history") = 0 And Session("pay_re") = False And Session("pay_sch") = False Then

                    Panel1.Visible = False
                    Panel2.Visible = True
                    Panel3.Visible = True
                    Panel4.Visible = False
                    Panel5.Visible = False
                    Panel6.Visible = False
                    Panel7.Visible = False
                    Label5.Visible = False
                    Panel7.Visible = False
                Else
                    Panel2.Visible = True
                    Panel3.Visible = False
                    If Session("letter") = 1 Then
                        Panel4.Visible = True
                    ElseIf Session("bank_nom") = True Then
                        Panel1.Visible = True
                    ElseIf Session("sch_history") = 1 Then
                        Panel5.Visible = True
                    ElseIf Session("loan_st") = 1 Then
                        Panel6.Visible = True
                    ElseIf Session("pay_re") = True Then
                        Panel7.Visible = True
                    ElseIf Session("pay_sch") = True Then
                        Panel8.Visible = True

                    End If
                    Label5.Visible = False
                End If

                btnapprove.Visible = False
                btndecline.Visible = False
            ElseIf Session("beg_status") = "Declined" And Val(txtsearch.Text) = 0 Then
                btnloanrepay.Visible = False
                btnprntcntrct.Visible = False
                btnnabdd.Visible = False
                btnpayroll.Visible = False
                btnpayschedule.Visible = False
                btnnominatebsb.Visible = False
                btnloanst.Visible = False
                btnschhistory.Visible = False
                btnprtcntrct.Visible = False
                btnpaymentreceipt.Visible = False
                btncbadd.Visible = False
                Panel1.Visible = False
                btnapprove.Visible = False
                btndecline.Visible = False
                Label5.Visible = True
                Panel3.Visible = False
                btnletter.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
                Panel2.Visible = True
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view Repayment Screen. Loan is Declined !!!" & "');", True)
                Exit Sub
            ElseIf Val(Session("beg_status")) = 0 And Val(txtsearch.Text) = 0 And Session("flag_approve") = False Then
                If open_con.check_nominate(Session("cur_loan_id")) = True Then

                    Panel1.Visible = True
                    Panel2.Visible = True
                    Panel3.Visible = False
                    Panel4.Visible = False
                    Panel5.Visible = False
                    Panel6.Visible = False
                    Panel7.Visible = False
                    Panel8.Visible = False
                Else
                    Panel1.Visible = True
                    Panel2.Visible = True
                    Panel3.Visible = False
                    Panel4.Visible = False
                    Panel5.Visible = False
                    Panel6.Visible = False
                    Panel7.Visible = False
                    Panel8.Visible = False
                End If
                btnapprove.Visible = True
                btndecline.Visible = True
            End If

            '''''''''''''''''''''''''''''''''''''there is no need to provide curr_loan_id coz loan can't be approved without that...
            If Session("show_msg") = True And Val(txtsearch.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Loan Details have been added!!!" & "');", True)

                Session("show_msg") = False
                Session("nominate_msg") = True
                Panel3.Visible = False
                btnloanrepay.Visible = True
                btnprntcntrct.Visible = True
                btnnabdd.Visible = True
                btnpayroll.Visible = True
                btnpayschedule.Visible = True
                btnnominatebsb.Visible = True
                btnloanst.Visible = True
                btnschhistory.Visible = True
                btnprtcntrct.Visible = True
                btnpaymentreceipt.Visible = True
                Panel1.Visible = True
                Label5.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                Session("show_msg") = False
            End If

            If Page.IsPostBack And txtsearch.Text <> "" And r_load <> True Then
                GridView1.Visible = True
                btnsearch_Click(Nothing, Nothing)
            Else
                GridView1.Visible = False
                Label5.Visible = False
                Session("bank_nom") = False
                Session("letter") = 0
                Session("sch_history") = 0
                Session("loan_st") = 0
                Session("Pay_re") = False
                Session("pay_sch") = False
                Session("r_load") = "True"
                If txtsearch.Text <> "" Then
                    flag_val = True
                End If
                If flag_val = True And r_load <> True Then
                    Panel1.Visible = False
                    Panel2.Visible = False
                    Panel3.Visible = False
                    Panel4.Visible = False
                    Panel5.Visible = False
                    Panel6.Visible = False
                    Panel7.Visible = False
                    Panel8.Visible = False
                    Session("Show") = 0
                    binddata()
                End If

            End If




            If Page.IsPostBack And txtsearch.Text = "" Then
                Dim cncl As TextBox = tool_6.FindControl("txtloanamt")
                Session("cancel_pay1") = Val(cncl.Text)
                Session("dis_var_pay1") = Val(cncl.Text)
            Else
                Dim cncl As TextBox = tool_6.FindControl("txtloanamt")
                Session("cancel_pay1") = Val(cncl.Text)
                Session("dis_var_pay1") = Val(cncl.Text)
            End If

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

    Protected Sub LinkButton10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton10.Click
        Dim cmd_black As New SqlCommand
        Dim str_black As String

        Dim confirmValue_black As String = Request.Form("confirm_value_black")
        If confirmValue_black = "Yes" Then
            str_black = "update tbl_customer set Status = 1, Status_Date= '" & System.DateTime.Now.Date & "'" & "where customer_id =" & open_con.customer_id_val
            cmd_black.Connection = open_con.return_con
            cmd_black.CommandText = str_black
            cmd_black.ExecuteNonQuery()
            cmd_black.Dispose()
            Response.Redirect("Detail.aspx")

        Else
            Exit Sub
        End If
    End Sub
    Protected Sub LinkButton11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton11.Click
        Dim cmd_reblack As New SqlCommand
        Dim str_reblack As String

        Dim confirmValue_reblack As String = Request.Form("confirm_value_reblack")
        If confirmValue_reblack = "Yes" Then
            str_reblack = "update tbl_customer set Status = 0, Status_Date= '" & System.DateTime.Now.Date & "'" & "where customer_id =" & open_con.customer_id_val
            cmd_reblack.Connection = open_con.return_con
            cmd_reblack.CommandText = str_reblack
            cmd_reblack.ExecuteNonQuery()
            cmd_reblack.Dispose()
            Response.Redirect("Detail.aspx")

        Else
            Exit Sub
        End If
    End Sub
    Protected Sub LinkButton12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton12.Click
        Dim cmd_followup As New SqlCommand
        Dim str_followup As String

        Dim confirmValue_followup As String = Request.Form("confirm_value_Followup")
        If confirmValue_followup = "Yes" Then
            str_followup = "update tbl_customer set followup = 1 where customer_id =" & open_con.customer_id_val
            cmd_followup.Connection = open_con.return_con
            cmd_followup.CommandText = str_followup
            cmd_followup.ExecuteNonQuery()
            cmd_followup.Dispose()
            Response.Redirect("Detail.aspx")

        Else
            Exit Sub
        End If
    End Sub
    Protected Sub LinkButton13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton13.Click
        Dim cmd_refollowup As New SqlCommand
        Dim str_refollowup As String

        Dim confirmValue_refollowup As String = Request.Form("confirm_value_reFollowup")
        If confirmValue_refollowup = "Yes" Then
            str_refollowup = "update tbl_customer set followup = 0 where customer_id =" & open_con.customer_id_val
            cmd_refollowup.Connection = open_con.return_con
            cmd_refollowup.CommandText = str_refollowup
            cmd_refollowup.ExecuteNonQuery()
            cmd_refollowup.Dispose()
            Response.Redirect("Detail.aspx")

        Else
            Exit Sub
        End If
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub

    Protected Sub btnapprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnapprove.Click

        Session("vis_status") = 0
        Dim ds_loan As New DataSet
        If Session("Nominate_BSB") = True And Session("nominate_msg") = True Then
            If open_con.check_nominate(Session("cur_loan_id")) = True Then
                approve_loan(Session("cur_loan_id"))

            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No bank account is nominated !!!" & "');", True)
                Exit Sub
            End If

        ElseIf Session("Nominate_BSB") = True And Session("flag_beginning") = True Then
            If open_con.check_nominate(Session("beg_loan_id")) = True Then
                approve_loan(Session("beg_loan_id"))
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No bank account is nominated !!!" & "');", True)
                Exit Sub
            End If
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No account has been selected for direct debit!!!" & "');", True)
            Exit Sub
        End If

        If Session("flag_approve") = True And Session("flag_beginning") = False Then
            btnapprove.Visible = False
            btndecline.Visible = False
            Label5.Visible = False
            btnloanrepay.Visible = True
            btnprntcntrct.Visible = True
            btnnabdd.Visible = True
            btnpayroll.Visible = True
            btnpayschedule.Visible = True
            btnnominatebsb.Visible = True
            btnloanst.Visible = True
            btnschhistory.Visible = True
            btnprtcntrct.Visible = True
            btnpaymentreceipt.Visible = True
            Panel1.Visible = False
            Panel3.Visible = True
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False
            Panel8.Visible = False
            ds_loan = open_con.calculate_loan_repay(Session("cur_loan_id"))
            show_loan_repay(ds_loan)
        ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
            btnapprove.Visible = False
            btndecline.Visible = False
            Label5.Visible = False
            btnloanrepay.Visible = True
            btnprntcntrct.Visible = True
            btnnabdd.Visible = True
            btnpayroll.Visible = True
            btnpayschedule.Visible = True
            btnnominatebsb.Visible = True
            btnloanst.Visible = True
            btnschhistory.Visible = True
            btnprtcntrct.Visible = True
            btnpaymentreceipt.Visible = True
            Panel1.Visible = False
            Panel3.Visible = True
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False
            Panel8.Visible = False
            ds_loan = open_con.calculate_loan_repay(Session("beg_loan_id"))
            show_loan_repay(ds_loan)
        End If

    End Sub
    Protected Sub btndecline_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndecline.Click


        Dim confirmValue_dec As String = Request.Form("confirm_value_dec")
        If confirmValue_dec = "Yes" Then


            If Session("Nominate_BSB") = True And Session("nominate_msg") = True Then
                If open_con.decline_loan(Session("cur_loan_id")) = True Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Recorded as declined!!!" & "');", True)
                    Session("flag_decline") = True
                End If
            ElseIf Session("Nominate_BSB") = True And Session("flag_beginning") = True Then
                If open_con.decline_loan(Session("beg_loan_id")) = True Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Recorded as declined!!!" & "');", True)
                    Session("flag_decline") = True
                End If
            ElseIf Session("nominate_msg") = True Then
                If open_con.decline_loan(Session("cur_loan_id")) = True Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Recorded as declined!!!" & "');", True)
                    Session("flag_decline") = True
                End If
            ElseIf Session("Nominate_BSB") = False And Session("flag_beginning") = True Then
                If open_con.decline_loan(Session("beg_loan_id")) = True Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Recorded as declined!!!" & "');", True)
                    Session("flag_decline") = True
                End If

            End If
        Else
            Session("flag_decline") = False
            Exit Sub
        End If

        If Session("flag_decline") = True Then
            btnloanrepay.Visible = False
            btnprntcntrct.Visible = False
            btnnabdd.Visible = False
            btnpayroll.Visible = False
            btnpayschedule.Visible = False
            btnnominatebsb.Visible = False
            btnloanst.Visible = False
            btnschhistory.Visible = False
            btnprtcntrct.Visible = False
            btnpaymentreceipt.Visible = False
            btnletter.Visible = False
            btncbadd.Visible = False
            Panel1.Visible = False
            btnapprove.Visible = False
            btndecline.Visible = False
            Label5.Visible = True

        End If

    End Sub
    Protected Sub btnloanrepay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnloanrepay.Click

        Session("re_vis") = 0
        Session("letter") = 0
        Session("bank_nom") = False
        Session("sch_history") = 0
        Session("loan_st") = 0
        Session("Pay_re") = False
        Session("pay_sch") = False
        '''''''''''''''''this is to make all the controls on second line invisible


        tool_7.FindControl("btnwaive1").Visible = False
        tool_7.FindControl("btncncl").Visible = False
        tool_7.FindControl("btnenfrc").Visible = False
        tool_7.FindControl("btncncl_enf").Visible = False
        tool_7.FindControl("btncncl_save").Visible = False
        tool_7.FindControl("btncnl_cncl").Visible = False
        tool_7.FindControl("btnsave_pay").Visible = False
        tool_7.FindControl("btncncl_pay").Visible = False
        tool_7.FindControl("btnsave_mod").Visible = False
        tool_7.FindControl("btncncl_mod").Visible = False
        tool_7.FindControl("btnsave_dis").Visible = False
        tool_7.FindControl("btncncl_dis").Visible = False
        tool_7.FindControl("btnenfee").Visible = True
        tool_7.FindControl("btnshow").Visible = True
        tool_7.FindControl("btnacpt").Visible = True
        tool_7.FindControl("btnmodsch").Visible = True
        tool_7.FindControl("btnwaive").Visible = True
        tool_7.FindControl("btncancel").Visible = True
        ''''''''''''''''''''''''
        If Session("beg_status") = "Declined" Then
            GridView1.Visible = False
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view Repayment Screen. Loan is Declined !!!" & "');", True)
            Exit Sub
        ElseIf Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

            If open_con.check_status(Session("beg_loan_id")) = True Then
                GridView1.Visible = False
                Panel1.Visible = False
                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                GridView1.Visible = False
                Panel1.Visible = False
                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            End If
        ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
            If open_con.check_status(Session("beg_loan_id")) = True Then
                GridView1.Visible = False
                Panel1.Visible = False
                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                GridView1.Visible = False
                Panel1.Visible = False
                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            End If

        ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

            If open_con.check_status(Session("cur_loan_id")) = True Then
                GridView1.Visible = False
                Panel1.Visible = False
                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                GridView1.Visible = False
                Panel1.Visible = False
                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            End If

        ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

            If open_con.check_status(Session("cur_loan_id")) = True Then
                GridView1.Visible = False
                Panel1.Visible = False
                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                GridView1.Visible = False
                Panel1.Visible = False
                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            End If

        ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

            If open_con.check_status(Session("beg_loan_id")) = True Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view Repayment Screen. Loan is not Approved !!!" & "');", True)
                Exit Sub
            Else
                GridView1.Visible = False
                Panel2.Visible = True
                Panel1.Visible = True
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view Repayment Screen. Loan is not Approved !!!" & "');", True)
            End If
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view Repayment Screen. Loan is not Approved !!!" & "');", True)
            Exit Sub


        End If


        ''''''''''''''''''''''''''

      

    End Sub
    Protected Sub btnnominatebsb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnominatebsb.Click
        Session("bank_nom") = True
        Session("loan_st") = 0
        Session("sch_history") = 0
        Session("letter") = 0
        Session("re_vis") = 0
        Session("Pay_re") = False
        Session("pay_sch") = False
        If Session("beg_status") = "Declined" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view NominateBank Screen. Loan is Declined !!!" & "');", True)
            Exit Sub

        ElseIf Session("beg_status") = "Pending" Then
            If open_con.check_status(Session("beg_loan_id")) = True Then
                Panel1.Visible = True
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
                btnloanrepay.Visible = True
                btnprntcntrct.Visible = True
                btnnabdd.Visible = True
                btnpayroll.Visible = True
                btnpayschedule.Visible = True
                btnnominatebsb.Visible = True
                btnloanst.Visible = True
                btnschhistory.Visible = True
                btnprtcntrct.Visible = True
                btnapprove.Visible = True
                btndecline.Visible = True
                btnpaymentreceipt.Visible = True
            Else
                Panel1.Visible = True
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
                btnloanrepay.Visible = True
                btnprntcntrct.Visible = True
                btnnabdd.Visible = True
                btnpayroll.Visible = True
                btnpayschedule.Visible = True
                btnnominatebsb.Visible = True
                btnloanst.Visible = True
                btnschhistory.Visible = True
                btnprtcntrct.Visible = True
                btnapprove.Visible = True
                btndecline.Visible = True
                btnpaymentreceipt.Visible = True
            End If

        ElseIf Session("beg_status") = "Approved" And Session("flag_beginning") = True Then

            Panel1.Visible = True
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False
            Panel8.Visible = False
        ElseIf Session("beg_status") = "Approved" And Session("flag_beginning") = False And Session("flag_approve") = True Then

            Panel1.Visible = True
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False
            Panel8.Visible = False
        ElseIf Session("flag_beginning") = False And Session("flag_approve") = False Then
            Panel1.Visible = True
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False
            Panel8.Visible = False

        End If


    End Sub
    Sub approve_loan(ByVal loanid As Integer)
        Try
            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then
                Dim str_apprv As String
                Dim cmd_loanapprv As New SqlCommand
                str_apprv = "Update Tbl_Loan set Tbl_Loan.Status = 1, Loan_Date =@today_date WHERE Tbl_Loan.Loan_ID =" & loanid
                cmd_loanapprv.CommandText = str_apprv
                cmd_loanapprv.Parameters.Add("@today_date", SqlDbType.DateTime).Value = DateTime.Now.Date
                cmd_loanapprv.Connection = open_con.return_con
                cmd_loanapprv.ExecuteNonQuery()
                cmd_loanapprv.Dispose()
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Recorded as Approved!!!" & "');", True)
                Session("flag_approve") = True
                Session("beg_status") = "Approved"

            Else
                Session("flag_approve") = False
                Exit Sub

                Response.Redirect("LoanSummary.aspx", False)
            End If

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub
    Sub show_loan_repay(ByVal ds As DataSet)
        Dim tbl As Table = New Table()

        tbl.Style.Add("border-style", "none")
        tbl.Style.Add("border-width", "1px")
        tbl.Style.Add(" border-color", "gray")
        tool_7.FindControl("PlaceHolder1").Controls.Clear()
        tool_7.FindControl("PlaceHolder1").Controls.Add(tbl)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim snno As Label = New Label()
        snno.Text = "No."
        snno.Font.Bold = True
        snno.Width = "30"
        snno.Style.Add("font-size", "12px")
        snno.Style.Add("font-family", "MS Sans Serif")
        snno.Style.Add("font-weight", "bold")
        snno.Style.Add("text-align", "center")
        snno.Style.Add("background-color", "#D9D8DA")
        snno.Style.Add(" border-style", "solid")
        snno.Style.Add(" border-width", "1px")
        snno.Style.Add(" border-color", "gray")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim s As LinkButton = New LinkButton

        s.ID = "s_link"
        s.Text = "Select"

        s.Font.Bold = True
        s.Width = "40"
        s.Style.Add("font-size", "12px")
        s.Style.Add("font-family", "MS Sans Serif")
        s.Style.Add("font-weight", "bold")
        s.Style.Add("text-align", "center")
        s.Style.Add("background-color", "#D9D8DA")
        s.Style.Add(" border-style", "solid")
        s.Style.Add(" border-width", "1px")
        s.Style.Add(" border-color", "gray")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim des As Label = New Label
        des.Text = "Description"
        des.Font.Bold = True
        des.Width = "110"
        des.Style.Add("font-size", "12px")
        des.Style.Add("font-family", "MS Sans Serif")
        des.Style.Add("font-weight", "bold")
        des.Style.Add("text-align", "center")
        des.Style.Add("background-color", "#D9D8DA")
        des.Style.Add(" border-style", "solid")
        des.Style.Add(" border-width", "1px")
        des.Style.Add(" border-color", "gray")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim duedt As Label = New Label
        duedt.Text = "Due Date"
        duedt.Font.Bold = True
        duedt.Width = "90"
        duedt.Style.Add("font-size", "12px")
        duedt.Style.Add("font-family", "MS Sans Serif")
        duedt.Style.Add("font-weight", "bold")
        duedt.Style.Add("text-align", "center")
        duedt.Style.Add("background-color", "#D9D8DA")
        duedt.Style.Add(" border-style", "solid")
        duedt.Style.Add(" border-width", "1px")
        duedt.Style.Add(" border-color", "gray")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim amt As Label = New Label
        amt.Text = "Amount"
        amt.Font.Bold = True
        amt.Width = "70"
        amt.Style.Add("font-size", "12px")
        amt.Style.Add("font-family", "MS Sans Serif")
        amt.Style.Add("font-weight", "bold")
        amt.Style.Add("text-align", "center")
        amt.Style.Add("background-color", "#D9D8DA")
        amt.Style.Add(" border-style", "solid")
        amt.Style.Add(" border-width", "1px")
        amt.Style.Add(" border-color", "gray")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim p As Label = New Label
        p.Text = "P"
        p.Font.Bold = True
        p.Width = "30"
        p.Style.Add("font-size", "12px")

        p.Style.Add("font-family", "MS Sans Serif")
        p.Style.Add("font-weight", "bold")
        p.Style.Add("text-align", "center")
        p.Style.Add("background-color", "#D9D8DA")
        p.Style.Add(" border-style", "solid")
        p.Style.Add(" border-width", "1px")
        p.Style.Add(" border-color", "gray")
        p.Style.Add("color", "blue")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim pdate As Label = New Label
        pdate.Text = "Payment Date"
        pdate.Font.Bold = True
        pdate.Width = "100"
        pdate.Style.Add("font-size", "12px")
        pdate.Style.Add("font-family", "MS Sans Serif")
        pdate.Style.Add("font-weight", "bold")
        pdate.Style.Add("text-align", "center")
        pdate.Style.Add("background-color", "#D9D8DA")
        pdate.Style.Add(" border-style", "solid")
        pdate.Style.Add(" border-width", "1px")
        pdate.Style.Add(" border-color", "gray")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim pmethod As Label = New Label
        pmethod.Text = "Payment Method"
        pmethod.Font.Bold = True
        pmethod.Width = "110"
        pmethod.Style.Add("font-size", "12px")
        pmethod.Style.Add("font-family", "MS Sans Serif")
        pmethod.Style.Add("font-weight", "bold")
        pmethod.Style.Add("text-align", "center")
        pmethod.Style.Add("background-color", "#D9D8DA")
        pmethod.Style.Add(" border-style", "solid")
        pmethod.Style.Add(" border-width", "1px")
        pmethod.Style.Add(" border-color", "gray")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim tdes As Label = New Label
        tdes.Text = "Transaction Description"
        tdes.Font.Bold = True
        tdes.Width = "160"
        tdes.Style.Add("font-size", "12px")
        tdes.Style.Add("font-family", "MS Sans Serif")
        tdes.Style.Add("font-weight", "bold")
        tdes.Style.Add("text-align", "center")
        tdes.Style.Add("background-color", "#D9D8DA")
        tdes.Style.Add(" border-style", "solid")
        tdes.Style.Add(" border-width", "1px")
        tdes.Style.Add(" border-color", "gray")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim tdate As Label = New Label
        tdate.Text = "Transaction Date"
        tdate.Font.Bold = True
        tdate.Width = "150"
        tdate.Style.Add("font-size", "12px")
        tdate.Style.Add("font-family", "MS Sans Serif")
        tdate.Style.Add("font-weight", "bold")
        tdate.Style.Add("text-align", "center")
        tdate.Style.Add("background-color", "#D9D8DA")
        tdate.Style.Add(" border-style", "solid")
        tdate.Style.Add(" border-width", "1px")
        tdate.Style.Add(" border-color", "gray")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim tcm As TableCell = New TableCell()
        Dim trm As TableRow = New TableRow()
        tcm.Style.Add("border-style", "solid")
        tcm.Style.Add("border-width", "1px")
        tcm.Style.Add(" border-color", "gray")
        trm.Style.Add("border-style", "solid")
        trm.Style.Add("border-width", "1px")
        trm.Style.Add(" border-color", "gray")
        tcm.Controls.Add(snno)
        tcm.Controls.Add(s)
        tcm.Controls.Add(des)
        tcm.Controls.Add(duedt)
        tcm.Controls.Add(amt)
        tcm.Controls.Add(p)
        tcm.Controls.Add(pdate)
        tcm.Controls.Add(pmethod)
        tcm.Controls.Add(tdes)
        tcm.Controls.Add(tdate)
        trm.Cells.Add(tcm)
        tbl.Rows.Add(trm)

        If ds.Tables(0).Rows.Count = 0 Then
            Session("count") = 0
        End If

        For icount As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Session("count") = ds.Tables(0).Rows.Count
            Dim tc As TableCell = New TableCell()
            Dim tr As TableRow = New TableRow()
            tc.Style.Add("border-style", "solid")
            tc.Style.Add("border-width", "1px")
            tc.Style.Add(" border-color", "gray")
            tr.Style.Add("border-style", "solid")
            tr.Style.Add("border-width", "1px")
            tr.Style.Add(" border-color", "gray")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim label1 As Label = New Label()
            label1.Width = "35"
            label1.ID = "lab1" & Format(icount, "00")
            label1.Style.Add("font-size", "12px")
            label1.Style.Add("font-family", "MS Sans Serif")
            label1.Style.Add("font-weight", "bold")
            label1.Style.Add("text-align", "center")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim check1 As CheckBox = New CheckBox
            check1.Width = "30"
            check1.ID = "chk" & Format(icount, "00")
            check1.Style.Add("text-align", "center")


            Dim label_chk As Label = New Label
            label_chk.Width = "30"
            label_chk.ID = "label_chk" & Format(icount, "00")
            label_chk.Style.Add("text-align", "center")
            label_chk.Visible = False
            ''''''''''''''''''''''''''''''''''''''''''''''
            Dim label2 As Label = New Label()
            label2.ID = "lab2" & Format(icount, "00")
            label2.Width = "130"
            label2.Style.Add("font-size", "12px")
            label2.Style.Add("font-family", "MS Sans Serif")
            label2.Style.Add("font-weight", "bold")
            label2.Style.Add("text-align", "center")
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim txtdt As TextBox = New TextBox
            txtdt.Width = "80"
            txtdt.ID = "txt" & Format(icount, "00")
            txtdt.Style.Add("font-size", "12px")
            txtdt.Style.Add("font-family", "MS Sans Serif")
            txtdt.Style.Add("font-weight", "bold")
            txtdt.Style.Add("text-align", "center")
            txtdt.Style.Add("border-style", "solid")
            txtdt.Style.Add("border-width", "1px")
            txtdt.Style.Add("border-color", "gray")
            txtdt.Style.Add("color", "black")
            txtdt.Style.Add("background-color", "white")
            txtdt.Attributes.Add("onkeydown", "return (event.keyCode!=13);")
            txtdt.Enabled = False
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim label3 As Label = New Label
            label3.ID = "lab3" & Format(icount, "00")
            label3.Text = "$"
            label3.Width = "15"
            label3.Style.Add("font-size", "12px")
            label3.Style.Add("font-family", "MS Sans Serif")
            label3.Style.Add("font-weight", "bold")
            label3.Style.Add("text-align", "right")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim txtamt As TextBox = New TextBox
            txtamt.ID = "txtamt" & Format(icount, "00")
            txtamt.Width = "50"
            txtamt.Style.Add("font-size", "12px")
            txtamt.Style.Add("font-family", "MS Sans Serif")
            txtamt.Style.Add("font-weight", "bold")
            txtamt.Style.Add("text-align", "left")
            txtamt.Style.Add("border-style", "solid")
            txtamt.Style.Add("border-width", "1px")
            txtamt.Style.Add("border-color", "gray")
            txtamt.Style.Add("color", "black")
            txtamt.Style.Add("background-color", "white")
            txtamt.Attributes.Add("onkeydown", "return (event.keyCode!=13);")
            txtamt.Enabled = False
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim pay As LinkButton = New LinkButton
            pay.ID = "pay" & Format(icount, "00")
            pay.OnClientClick = "javascripayt:alert('p stands for payayment status');"
            pay.Font.Bold = True
            pay.Width = "30"
            pay.Style.Add("font-size", "12px")
            pay.Style.Add("font-family", "MS Sans Serif")
            pay.Style.Add("font-weight", "bold")
            pay.Style.Add("text-align", "center")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim txtpaydt As TextBox = New TextBox
            txtpaydt.ID = "txtpaydt" & Format(icount, "00")
            txtpaydt.Width = "110"
            txtpaydt.Style.Add("font-size", "12px")
            txtpaydt.Style.Add("font-family", "MS Sans Serif")
            txtpaydt.Style.Add("font-weight", "bold")
            txtpaydt.Style.Add("text-align", "center")
            txtpaydt.Style.Add("border-style", "none")
            txtpaydt.TabIndex = "100"
            txtpaydt.ReadOnly = True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim label4 As Label = New Label
            label4.ID = "lab4" & Format(icount, "00")
            label4.Style.Add("font-size", "12px")
            label4.Style.Add("font-family", "MS Sans Serif")
            label4.Width = "20"
            label4.Visible = False
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim label5 As Label = New Label
            label5.ID = "lab5" & Format(icount, "00")
            label5.Text = ""
            label5.Width = "8"
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim drop As DropDownList = New DropDownList
            drop.ID = "drop" & Format(icount, "00")
            drop.Width = "90"
            drop.Style.Add("font-size", "12px")
            drop.Style.Add("font-family", "MS Sans Serif")
            drop.Style.Add("font-weight", "bold")
            drop.Style.Add("text-align", "center")
            drop.Enabled = True

            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim label6 As Label = New Label
            label6.ID = "lab6" & Format(icount, "00")
            label6.Width = "40"
            label6.Visible = False
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim label8 As Label = New Label
            label8.ID = "lab8" & Format(icount, "00")
            label8.Width = "40"
            label8.Visible = False
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim radio_repay As RadioButton = New RadioButton
            radio_repay.GroupName = "radio_repay1"
            radio_repay.ID = "radio_repay" & Format(icount, "00")
            radio_repay.Style.Add("text-align", "center")
            radio_repay.Width = "150"
            radio_repay.Visible = "False"
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim txttrans_des As TextBox = New TextBox
            txttrans_des.ID = "txttrans_des" & Format(icount, "00")
            txttrans_des.Width = "100"
            txttrans_des.Style.Add("font-size", "12px")
            txttrans_des.Style.Add("font-family", "MS Sans Serif")
            txttrans_des.Style.Add("font-weight", "bold")
            txttrans_des.Style.Add("text-align", "center")
            txttrans_des.Style.Add("border-style", "solid")
            txttrans_des.Style.Add("border-width", "1px")
            txttrans_des.Style.Add("background-color", "red")
            txttrans_des.Text = ""
            txttrans_des.ReadOnly = "true"
            txttrans_des.Visible = "False"
            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim label7 As Label = New Label
            label7.ID = "lab7" & Format(icount, "00")
            label7.Width = "50"
            label7.Visible = False
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim txttrans_date As TextBox = New TextBox
            txttrans_date.ID = "txttrans_date" & Format(icount, "00")
            txttrans_date.Width = "100"
            txttrans_date.Style.Add("font-size", "12px")
            txttrans_date.Style.Add("font-family", "MS Sans Serif")
            txttrans_date.Style.Add("font-weight", "bold")
            txttrans_date.Style.Add("text-align", "center")
            txttrans_date.Style.Add("border-style", "solid")
            txttrans_date.Style.Add("border-width", "1px")
            txttrans_date.Style.Add("background-color", "red")
            txttrans_date.ReadOnly = True
            txttrans_date.Text = System.DateTime.Now.Date
            txttrans_date.Visible = "False"

       
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For i = 1 To 1

                label1.Text = icount + 1
                label2.Text = ds.Tables(0).Rows(icount).Item("Description").ToString
                Dim due_dt As String
                due_dt = CDate(ds.Tables(0).Rows(icount).Item("Due_Date"))
                Dim due_dt_new As Date
                due_dt_new = CDate(ds.Tables(0).Rows(icount).Item("Due_Date")).ToString("dd/MM/yyyy")
                due_dt_new = due_dt_new.ToString("dd/MM/yyyy")
                Dim month_due, year_due, day_due As String

                day_due = Val(Left(due_dt, 2))
                If Len(day_due) = 1 Then
                    day_due = "0" & day_due
                End If
                Dim pos_int_Total1 As Integer
                pos_int_Total1 = InStr(1, due_dt, "/")

                month_due = open_con.cal_short_month_new(Mid(due_dt, pos_int_Total1 + 1, 2))
                year_due = Val(Right(due_dt, 4))


                due_dt = day_due & "-" & month_due & "-" & year_due

                txtdt.Text = due_dt
                Dim amt_payable As Double
                amt_payable = CDbl(ds.Tables(0).Rows(icount).Item("Amount").ToString)
                txtamt.Text = open_con.newamount(amt_payable)
                label4.Text = ds.Tables(0).Rows(icount).Item("Payment_ID").ToString
                label6.Text = ds.Tables(0).Rows(icount).Item("Contract_Date").ToString

                If ds.Tables(0).Rows(icount).Item("Payment_Status").ToString = "Paid" And ds.Tables(0).Rows(icount).Item("Transaction_Status").ToString = "Dishonour" Then
                    pay.Text = "P"
                    check1.Visible = False
                    label_chk.Visible = True
                    label_chk.Text = ""
                    radio_repay.Visible = False
                    txttrans_des.Visible = True
                    txttrans_des.Width = "150"
                    txttrans_des.Text = "Dishonour"
                    txttrans_des.Style.Add("border-style", "none")
                    txttrans_des.Style.Add("background-color", "white")

                ElseIf ds.Tables(0).Rows(icount).Item("Payment_Status").ToString = "Paid" Then
                    pay.Text = "P"
                    check1.Visible = False
                    label_chk.Visible = True
                    label_chk.Text = ""
                Else
                    pay.Text = ""
                End If

                If ds.Tables(0).Rows(icount).Item("Payment_Date").ToString = "" Then
                    txtpaydt.Text = ""
                Else
                    Dim pay_dt As String
                    pay_dt = CDate(ds.Tables(0).Rows(icount).Item("Payment_Date"))
                    Dim month_pay, year_pay, day_pay As String
                    pay_dt = pay_dt.Replace("/", " ")
                    day_pay = Val(Left(pay_dt, 2))
                    If Len(day_pay) = 1 Then
                        day_pay = "0" & day_pay
                    End If
                    month_pay = open_con.cal_short_month(Val(Mid(pay_dt, 4, 2)))
                    year_pay = Val(Right(pay_dt, 4))
                    pay_dt = day_pay & "-" & month_pay & "-" & year_pay
                    txtpaydt.Text = pay_dt
                End If
                drop.Items.Add(ds.Tables(0).Rows(icount).Item("Payment_Method").ToString)

                tc.Controls.Add(label1)
                tc.Controls.Add(check1)
                tc.Controls.Add(label_chk)
                tc.Controls.Add(label2)
                tc.Controls.Add(txtdt)
                tc.Controls.Add(label3)
                tc.Controls.Add(txtamt)
                tc.Controls.Add(pay)
                tc.Controls.Add(txtpaydt)
                tc.Controls.Add(label4)
                tc.Controls.Add(label5)
                tc.Controls.Add(drop)
                tc.Controls.Add(label6)
                tc.Controls.Add(label8)
                tc.Controls.Add(radio_repay)
                tc.Controls.Add(txttrans_des)
                tc.Controls.Add(label7)
                tc.Controls.Add(txttrans_date)
                tr.Cells.Add(tc)
                tbl.Rows.Add(tr)
                Session("acpt_due_date_mod") = due_dt
            Next

        Next

        tool_7.FindControl("PlaceHolder1").Controls.Clear()
        tool_7.FindControl("PlaceHolder1").Controls.Add(tbl)
        tool_7.FindControl("PlaceHolder1").Controls.Add(New LiteralControl("<br>"))

        
    End Sub
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Label5.Visible = False
        Session("bank_nom") = False
        Session("letter") = 0
        Session("sch_history") = 0
        Session("loan_st") = 0
        Session("Pay_re") = False
        Session("pay_sch") = False
        Session("r_load") = "True"
        If txtsearch.Text <> "" Then
            flag_val = True
        End If
        If flag_val = True And r_load <> True Then
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False
            Panel8.Visible = False
            Panel111.Visible = False            
            Session("Show") = 0
            binddata()
        End If

    End Sub

    Protected Sub btnletter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnletter.Click

        Session("letter") = 1
        Session("loan_st") = 0
        Session("bank_nom") = False
        Session("sch_history") = 0
        Session("letter") = 0
        Session("re_vis") = 0
        Session("Pay_re") = False
        Session("pay_sch") = False
        If Session("beg_status") = "Declined" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You can not view Notices & Letters .  The Loan is not approved" & "');", True)
            Exit Sub

        ElseIf Session("beg_status") = "Pending" Then
            If open_con.check_status(Session("beg_loan_id")) = True Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You can not view Notices & Letters .  The Loan is not approved" & "');", True)
                Exit Sub
            Else
                Panel1.Visible = True
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You can not view Notices & Letters .  The Loan is not approved" & "');", True)
                Exit Sub
            End If

        ElseIf Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
            If open_con.check_status(Session("beg_loan_id")) = True Then
                Panel1.Visible = False
                Panel2.Visible = True
                Panel3.Visible = False
                Panel4.Visible = True
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                Panel1.Visible = False
                Panel2.Visible = True
                Panel3.Visible = False
                Panel4.Visible = True
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            End If
        ElseIf Session("beg_status") = "Approved" And Session("flag_approve") = True Then
            If open_con.check_status(Session("cur_loan_id")) = True Then

                Panel1.Visible = False
                Panel2.Visible = True
                Panel3.Visible = False
                Panel4.Visible = True
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                Panel1.Visible = False
                Panel2.Visible = True
                Panel3.Visible = False
                Panel4.Visible = True
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            End If
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You can not view Notices & Letters .  The Loan is not approved" & "');", True)
            Exit Sub
        End If

    End Sub

    Protected Sub btnschhistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnschhistory.Click

        Session("sch_history") = 1
        Session("loan_st") = 0
        Session("bank_nom") = False
        Session("sch_history") = 0
        Session("letter") = 0
        Session("re_vis") = 0
        Session("Pay_re") = False
        Session("pay_sch") = False
        If Session("beg_status") = "Declined" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view ReSchedule History. Loan is Declined !!!" & "');", True)
            Exit Sub

        ElseIf Session("beg_status") = "Pending" Then
            If open_con.check_status(Session("beg_loan_id")) = True Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view ReSchedule History. Loan is not Approved !!!" & "');", True)
                Exit Sub
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You can not view Reschedule History. The Loan is Declined !!!" & "');", True)
            End If

        ElseIf Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
            If open_con.check_status(Session("beg_loan_id")) = True Then
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = True
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = True
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            End If
        ElseIf Session("beg_status") = "Approved" And Session("flag_approve") = True And Session("flag_beginning") = True Then

            If open_con.check_status(Session("beg_loan_id")) = True Then
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = True
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = True
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            End If
        ElseIf Session("beg_status") = "Approved" And Session("flag_approve") = True And Session("flag_beginning") = False Then
            If open_con.check_status(Session("cur_loan_id")) = True Then

                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = True
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = True
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
            End If
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You can not view Reschedule History. The Loan is not approved !!!" & "');", True)
            Exit Sub
        End If


    End Sub

    Protected Sub btnloanst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnloanst.Click

        tool_10.FindControl("panel7").Visible = True
        tool_10.FindControl("btnprnt").Visible = False
        tool_10.FindControl("btncnclst").Visible = False

        Session("loan_st") = 1
        Session("bank_nom") = False
        Session("sch_history") = 0
        Session("letter") = 0
        Session("re_vis") = 0
        Session("Pay_re") = False
        Session("pay_sch") = False
        If Session("beg_status") = "Declined" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You can not view Account Statement . Loan is Declined !!!" & "');", True)
            Exit Sub

        ElseIf Session("beg_status") = "Pending" Then
            If open_con.check_status(Session("beg_loan_id")) = True Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You can not view Account Statement . The loan is not approved" & "');", True)
                Exit Sub
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You can not view Account Statement . The Loan is not approved !!!" & "');", True)
            End If

        ElseIf Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
            If open_con.check_status(Session("beg_loan_id")) = True Then
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = True
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = True
                Panel7.Visible = False
                Panel8.Visible = False
            End If
        ElseIf Session("beg_status") = "Approved" And Session("flag_approve") = True And Session("flag_beginning") = True Then

            If open_con.check_status(Session("beg_loan_id")) = True Then
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = True
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = True
                Panel7.Visible = False
                Panel8.Visible = False
            End If
        ElseIf Session("beg_status") = "Approved" And Session("flag_approve") = True And Session("flag_beginning") = False Then
            If open_con.check_status(Session("cur_loan_id")) = True Then

                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = True
                Panel7.Visible = False
                Panel8.Visible = False
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = True
                Panel7.Visible = False
                Panel8.Visible = False
            End If
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You can not view Account Statement . The Loan is not approved !!!" & "');", True)
            Exit Sub
        End If
    End Sub

    Protected Sub btnprntcntrct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprntcntrct.Click
        Response.Redirect("Contract.aspx", False)
    End Sub

    Protected Sub btnprtcntrct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprtcntrct.Click
        Response.Redirect("PartContract.aspx", False)
    End Sub

    Protected Sub btnnabdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnabdd.Click
        Response.Redirect("NAB_DD.aspx", False)
    End Sub

    Protected Sub btncbadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncbadd.Click
        Response.Redirect("CBA_DD.aspx", False)
    End Sub

    Protected Sub btnpaymentreceipt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpaymentreceipt.Click
        Session("bank_nom") = False
        Session("loan_st") = 0
        Session("sch_history") = 0
        Session("letter") = 0
        Session("re_vis") = 0
        Session("pay_re") = True
        Session("pay_sch") = False
        tool_11.FindControl("panel1").Visible = True
        tool_11.FindControl("panel2").Visible = False

        Dim ds As New TextBox
        ds = tool_6.FindControl("txtamtout")
        Session("loanapp_outamt") = ds.Text
        If Session("beg_status") = "Declined" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view Payment Receipt. Loan is Declined !!!" & "');", True)
            Exit Sub

        ElseIf Session("beg_status") = "Pending" Then
            If open_con.check_status(Session("beg_loan_id")) = True Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view Payment Receipt . The loan is not approved" & "');", True)
                Exit Sub
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = False
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view Payment Receipt . The Loan is Declined !!!" & "');", True)
            End If

        ElseIf Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
            If open_con.check_status(Session("beg_loan_id")) = True Then
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = True
                Panel8.Visible = False
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = True
                Panel8.Visible = False
            End If
        ElseIf Session("beg_status") = "Approved" And Session("flag_approve") = True Then
            If open_con.check_status(Session("cur_loan_id")) = True Then

                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = True
                Panel8.Visible = False
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = True
                Panel8.Visible = False
            End If
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view Payment Receipt . The Loan is not approved !!!" & "');", True)
            Exit Sub
        End If
    End Sub

    Protected Sub btnpayroll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpayroll.Click
        Response.Redirect("payroll.aspx", False)
    End Sub

    Protected Sub btnpayschedule_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpayschedule.Click

        Session("bank_nom") = False
        Session("loan_st") = 0
        Session("sch_history") = 0
        Session("letter") = 0
        Session("re_vis") = 0
        Session("pay_re") = False
        Session("pay_sch") = True
        tool_11.FindControl("panel1").Visible = True
        tool_11.FindControl("panel2").Visible = False

        Dim ds As New TextBox
        ds = tool_6.FindControl("txtamtout")
        Session("loanapp_outamt") = ds.Text
        If Session("beg_status") = "Declined" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "You cannot view Payment Schedule. Loan is Declined !!!" & "');", True)
            Exit Sub

        ElseIf Session("beg_status") = "Pending" Then
            If open_con.check_status(Session("beg_loan_id")) = True Then
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = True
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = True
            End If

        ElseIf Session("beg_status") = "" Then
            If open_con.check_status(Session("cur_loan_id")) = True Then
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = True
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = True
            End If
        ElseIf Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
            If open_con.check_status(Session("beg_loan_id")) = True Then
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = True
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = True
            End If
        ElseIf Session("beg_status") = "Approved" And Session("flag_approve") = True Then
            If open_con.check_status(Session("cur_loan_id")) = True Then

                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = True
            Else
                Panel1.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
                Panel8.Visible = True
            End If
       
        End If
    End Sub
    

End Class
