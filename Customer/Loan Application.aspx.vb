Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports AjaxControlToolkit
Imports System.Globalization
Partial Class Services_Loan_Application
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
            str_SQL = " SELECT *  FROM Tbl_Customer   where  "
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
                    Label3.Visible = False
                    Exit Sub
                Else
                    txtsearch.Text = ""
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                    Label3.Visible = True
                End If
                open_con.return_con.Dispose()
                adap.Dispose()
                cmd.Dispose()
            Else
                If Page.IsPostBack = False Then
                Else
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid Customer Name or ID!!!" & "');", True)
                End If
            End If

        Catch ex As Exception
            ' Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub

    Protected Sub LinkButton_AddCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_AddCustomer.Click
        Response.Redirect("./Personal_Form.aspx", False)
    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='none';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFBD6'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            e.Row.Attributes.Add("ondblClick", ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex))
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.Cells.Item(4).Text = "&nbsp;" Then
            e.Row.Cells(4).Text = ""
        ElseIf e.Row.Cells.Item(4).Text = "Request Amount" Then
            e.Row.Cells.Item(4).Text = "Request Amount"
        Else
            e.Row.Cells(4).Text = CStr(e.Row.Cells(4).Text.ToString)
        End If

    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

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
        Response.Redirect("./detail.aspx", False)

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
            Session("flag_beginning") = False
            Session("beg_status") = ""

            If LinkButton2.Visible = True And Session("check_flag") = True Then
                Session("show_panel") = True
                panel1.Visible = True
                Panel2.Visible = True
                Label4.Visible = False
                txtTotal1.Visible = False
                LinkButton2.Visible = False

            End If
            If Page.IsPostBack = False Then
                LinkButton2.Visible = True
                Label4.Visible = True
                txtTotal1.Visible = True
            End If


            If Session("show_panel") = False Then
                panel1.Visible = False
                Panel2.Visible = False
            Else
                panel1.Visible = True
                Panel2.Visible = True
            End If

            If txtvarfee.Text = "" Then
                txtvarfee.Text = "0.0"
            End If
            If txtTotal1.Text = "" Then
                txtTotal1.Text = "0.0"
            End If


            If txtsearch.Text = "" And txtAmount.Text <> "" And r_load <> True Then
                create_schedule()
            ElseIf txtsearch.Text <> "" Then
                btnsearch_Click(Nothing, Nothing)

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
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click

        Session("check_flag") = True
        LinkButton3.Focus()

        If Session("check_flag") = True Then
            Dim dts As New TextBox
            dts = Toolbaar4.FindControl("txtTotal")
            dts.Text = Val(dts.Text) + Val(txtAmount.Text) + Val(txtApplicationFee.Text) + Val(txtCreditFee.Text) + Val(txtvarfee.Text)
            dts.Text = dts.Text & ".00"
        End If
        LinkButton3.Visible = True
        LinkButton2.Visible = False
        Session("show_panel") = True
        panel1.Visible = True
        Panel2.Visible = True
        Label4.Visible = False
        Label5.Visible = False
        txtTotal1.Visible = False


    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        txtTotal1.Focus()
        Session("show_panel") = False
        Session("check_flag") = False
        If Session("check_flag") = False Then
            txtTotal1.Text = Val(txtAmount.Text) + Val(txtApplicationFee.Text) + Val(txtCreditFee.Text)
            txtTotal1.Text = txtTotal1.Text + ".00"
        End If
        LinkButton2.Visible = True
        LinkButton3.Visible = False
        panel1.Visible = False
        Panel2.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        txtTotal1.Visible = True
        If txtTotal1.Text = "" Then
            txtTotal1.Text = "0.0"
        End If
        If txtAmount.Text = "" Then
            txtAmount.Text = "0.0"
        End If

        If txtApplicationFee.Text = "" Then
            txtApplicationFee.Text = "0.0"
        End If

        If txtCreditFee.Text = "" Then
            txtCreditFee.Text = "0.0"
        End If
        If txtvarfee.Text = "" Then
            txtvarfee.Text = "0.0"
        End If

    End Sub
    Protected Sub OnTextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim txt As TextBox = DirectCast(sender, TextBox)
        Dim ID As String = txt.Text
        Dim lak As Label = Page.FindControl("lbl" & Format(Val(Right(txt.ID, 2)), "00"))
        Dim dt As DateTime = txt.Text
        lak.Text = dt.DayOfWeek.ToString
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "Alert", "<script type = 'text/javascript'>alert('" & ID & " fired OnTextChanged event');" & txt.Text & "</script>")
    End Sub
    Protected Sub create_schedule()
        Try
            If Val(txtFirstPayment.Text) = 0 And Session("show_loan_msg") = False And Session("loan_summ") = False Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid first payment date!!!" & "');", True)
                Exit Sub
            Else
                Dim check_date As DateTime
                Dim cal_date As DateTime
                check_date = System.DateTime.Now.Date.ToString("dd/MM/yyyy")
                Dim dt As DateTime

                dt = Date.Parse(txtFirstPayment.Text)

                If dt < check_date Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid first payment date!!!" & "');", True)
                    Exit Sub
                Else

                    If txtFirstPayment.Text < check_date.AddDays(60) Then
                        Dim tbl As Table = New Table()
                        Dim day_flag As Boolean
                        PlaceHolder1.Controls.Clear()
                        PlaceHolder1.Controls.Add(tbl)
                        tbl.BorderWidth = "1"
                        txtTotal1.Text = Val(txtAmount.Text) + Val(txtApplicationFee.Text) + Val(txtCreditFee.Text) + Val(txtvarfee.Text)
                        txtTotal1.Text = txtTotal1.Text & ".00"
                        If IsNumeric(txtAmount.Text) = True And Val(txtAmount.Text) <> 0 And drpFrequency.SelectedItem.Text <> "" And Val(txtFirstPayment.Text) <> 0 And _
                            Val(txtNoOfPayment.Text) <> "0" And IsNumeric(txtNoOfPayment.Text) = True And Val(drpPeriod.SelectedItem.Text) <> 0 Then
                            Dim int_Total_Loan_Amount As Integer
                            Dim dtm_First_Payment As Date
                            Dim day As String
                            dtm_First_Payment = txtFirstPayment.Text
                            If Session("show_panel") = True Then
                                Dim dts1 As New TextBox
                                dts1 = Toolbaar4.FindControl("txtCreditRefReportFee")
                                dts1.Text = Val(dts1.Text) & ".00"

                                Dim dts2 As New TextBox
                                dts2 = Toolbaar4.FindControl("txtGuaranteePreparation")
                                dts2.Text = Val(dts2.Text) & ".00"

                                Dim dts3 As New TextBox
                                dts3 = Toolbaar4.FindControl("txtBillofSalePreparation")
                                dts3.Text = Val(dts3.Text) & ".00"

                                Dim dts4 As New TextBox
                                dts4 = Toolbaar4.FindControl("txtREVsInquiry")
                                dts4.Text = Val(dts4.Text) & ".00"

                                Dim dts5 As New TextBox
                                dts5 = Toolbaar4.FindControl("txtREVsRegistration")
                                dts5.Text = Val(dts5.Text) & ".00"

                                Dim dts6 As New TextBox
                                dts6 = Toolbaar4.FindControl("txtStamping")
                                dts6.Text = Val(dts6.Text) & ".00"

                                Dim dts7 As New TextBox
                                dts7 = Toolbaar4.FindControl("txtValuation")
                                dts7.Text = Val(dts7.Text) & ".00"
                                Session("otherFee") = Val(dts1.Text) + Val(dts2.Text) + Val(dts3.Text) + Val(dts4.Text) + Val(dts5.Text) + Val(dts6.Text) + Val(dts7.Text)
                                int_Total_Loan_Amount = Val(txtTotal1.Text) + Val(dts1.Text) + Val(dts2.Text) + Val(dts3.Text) + Val(dts4.Text) + Val(dts5.Text) + Val(dts6.Text) + Val(dts7.Text)
                                Dim ds As New TextBox
                                ds = Toolbaar4.FindControl("txttotal")
                                ds.Text = int_Total_Loan_Amount & ".00"
                                Session("loanapp_outamt") = Val(ds.Text) + ".00"
                            Else
                                int_Total_Loan_Amount = CInt(txtTotal1.Text)
                                Session("loanapp_outamt") = Val(int_Total_Loan_Amount) + ".00"
                            End If


                            Dim int_SinglePayment As Double

                            int_SinglePayment = FormatNumber(int_Total_Loan_Amount / txtNoOfPayment.Text)
                            int_SinglePayment = open_con.fn_Round_to_Nearest_Five(int_SinglePayment)
                            Dim count_totalSinglePayment As Double
                            Dim icount As Integer
                            Dim repay As Label = New Label()
                            Dim snno As Label = New Label()
                            Dim space As Label = New Label()
                            Dim dayf As Label = New Label()
                            Dim duedate As Label = New Label()
                            Dim amount As Label = New Label()
                            Dim modes As Label = New Label()
                            repay.Text = "Re-Payment Schedule:"
                            snno.Text = "SNo."
                            space.Text = ""
                            dayf.Text = "Week Day"
                            duedate.Text = "Repayment Date"
                            amount.Text = "Amount"
                            modes.Text = "Method of Repayment"
                            repay.Font.Bold = True
                            repay.Font.Size = "12"
                            repay.Font.Italic = True
                            snno.Font.Bold = True
                            dayf.Font.Bold = True
                            duedate.Font.Bold = True
                            modes.Font.Bold = True
                            amount.Font.Bold = True
                            repay.Width = "160"
                            repay.Style.Add("text-align", "left")
                            snno.Width = "50"
                            space.Width = "10"
                            snno.Style.Add("text-align", "center")
                            dayf.Width = "90"
                            dayf.Style.Add("text-align", "center")
                            duedate.Width = "130"
                            duedate.Style.Add("text-align", "center")
                            modes.Width = "160"
                            modes.Style.Add("text-align", "center")
                            amount.Width = "100"
                            amount.Style.Add("text-align", "center")
                            Dim tcr As TableCell = New TableCell()
                            Dim trr As TableRow = New TableRow()
                            tcr.Controls.Add(repay)
                            trr.Cells.Add(tcr)
                            tbl.Rows.Add(trr)
                            Dim tcm As TableCell = New TableCell()
                            Dim trm As TableRow = New TableRow()
                            tcm.Controls.Add(snno)
                            tcm.Controls.Add(space)
                            tcm.Controls.Add(dayf)
                            tcm.Controls.Add(duedate)
                            tcm.Controls.Add(amount)
                            tcm.Controls.Add(modes)
                            trm.Cells.Add(tcm)
                            tbl.Rows.Add(trm)
                            For icount = 1 To txtNoOfPayment.Text

                                For i As Integer = 1 To 1
                                    Dim day1 As String
                                    Dim tc As TableCell = New TableCell()

                                    Dim txtBox As TextBox = New TextBox()
                                    txtBox.Enabled = True
                                    txtBox.ID = "txtbox" & Format(icount, "00")
                                    txtBox.Attributes.Add("onchange", "setlbl('" + Format(icount, "00") + "');")

                                    '========================

                                    Dim ca As New CalendarExtender
                                    ca.ID = "ca" & icount
                                    ca.Format = "dd/MM/yyyy"
                                    ca.TargetControlID = txtBox.ID
                                    ca.CssClass = "red"
                                    ca.OnClientShowing = "showDate"
                                    ca.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
                                    '===========================
                                    Dim txtBoxQ As TextBox = New TextBox()
                                    txtBoxQ.ID = "txtb" & Format(icount, "00")
                                    txtBoxQ.Enabled = True

                                    '===========================

                                    Dim label3 As Label = New Label()
                                    label3.ID = "lab" & Format(icount, "00")
                                    label3.Style.Add("text-align", "right")

                                    '================================
                                    Dim label4 As Label = New Label
                                    label4.ID = "lel" & Format(icount, "00")

                                    '==========================================

                                    Dim label1 As Label = New Label()
                                    label1.ID = "lal" & Format(icount, "00")

                                    '==========================================
                                    Dim label2 As Label = New Label()
                                    label2.ID = "lbl" & Format(icount, "00")
                                    label2.Style.Add("text-align", "center")

                                    '==========================================

                                    Dim drp As DropDownList = New DropDownList
                                    drp.ID = "drp" & icount
                                    'drp.Items.Add(drpMethodOfPayment.SelectedItem.Text)
                                    drp.Items.Add("NAB")
                                    drp.Items.Add("Cas")
                                    drp.Items.Add("Sal")
                                    drp.Items.Add("Chq")
                                    drp.Items.Add("CBA")
                                    drp.Items.Add("Cre")
                                    If drpMethodOfPayment.SelectedItem.Text = "NAB" Then
                                        drp.Text = "NAB"
                                    ElseIf drpMethodOfPayment.SelectedItem.Text = "Cas" Then
                                        drp.Text = "Cas"
                                    ElseIf drpMethodOfPayment.SelectedItem.Text = "Sal" Then
                                        drp.Text = "Sal"
                                    ElseIf drpMethodOfPayment.SelectedItem.Text = "Chq" Then
                                        drp.Text = "Chq"
                                    ElseIf drpMethodOfPayment.SelectedItem.Text = "CBA" Then
                                        drp.Text = "CBA"
                                    ElseIf drpMethodOfPayment.SelectedItem.Text = "Cre" Then
                                        drp.Text = "Cre"

                                    End If
                                    Dim tr As TableRow = New TableRow()
                                    For j As Integer = 1 To 1

                                        label1.Text = icount
                                        label1.Width = "50"
                                        label1.Style.Add("text-align", "center")
                                        label1.Font.Bold = True
                                        tc.Controls.Add(label1)

                                        If icount = txtNoOfPayment.Text Then

                                            int_SinglePayment = int_Total_Loan_Amount - count_totalSinglePayment

                                            If drpFrequency.SelectedItem.Text = "Weekly" Then
                                                If txtNoOfPayment.Text = "1" Then
                                                    cal_date = txtFirstPayment.Text
                                                    day = cal_date.DayOfWeek.ToString
                                                Else
                                                    cal_date = cal_date.AddDays(7)
                                                    day = cal_date.DayOfWeek.ToString
                                                End If

                                            ElseIf drpFrequency.SelectedItem.Text = "Fortnightly" Then
                                                If txtNoOfPayment.Text = "1" Then
                                                    cal_date = txtFirstPayment.Text
                                                    day = cal_date.DayOfWeek.ToString
                                                Else
                                                    cal_date = cal_date.AddDays(14)
                                                    day = cal_date.DayOfWeek.ToString
                                                End If
                                            Else
                                                If txtNoOfPayment.Text = "1" Then
                                                    cal_date = txtFirstPayment.Text
                                                    day = cal_date.DayOfWeek.ToString
                                                Else

                                                    cal_date = cal_date.AddDays(30)
                                                    day = cal_date.DayOfWeek.ToString
                                                End If
                                            End If
                                            If day = "Saturday" Then
                                                label2.ForeColor = Drawing.Color.Red
                                                txtBox.Enabled = True
                                                day_flag = True

                                            End If

                                            If day = "Sunday" Then
                                                label2.ForeColor = Drawing.Color.Red
                                                txtBox.Enabled = True
                                                day_flag = True
                                            End If


                                            If day_flag = True Then
                                                label2.Text = ""
                                                day1 = cal_date.DayOfWeek.ToString
                                                label2.Text = cal_date.DayOfWeek.ToString & "?"
                                                day_flag = False
                                            Else
                                                label2.Text = ""
                                                day1 = cal_date.DayOfWeek.ToString
                                                label2.Text = cal_date.DayOfWeek.ToString
                                                day_flag = False

                                            End If
                                            txtBox.Style.Add("text-align", "center")
                                            txtBox.Text = cal_date
                                            label3.Text = "$"
                                            label4.Text = ""
                                            txtBoxQ.Style.Add("text-align", "center")
                                            Dim amt_payable As Double
                                            amt_payable = Math.Round(open_con.fn_Round_to_Nearest_Five(int_SinglePayment), 2)
                                            txtBoxQ.Text = open_con.newamount(amt_payable)
                                            tc.Controls.Add(label2)
                                            tc.Controls.Add(txtBox)
                                            tc.Controls.Add(ca)
                                            tc.Controls.Add(label3)
                                            tc.Controls.Add(txtBoxQ)
                                            tc.Controls.Add(label4)
                                            tc.Controls.Add(drp)
                                            tr.Cells.Add(tc)
                                            txtBox.Width = "80"
                                            label3.Width = "45"
                                            label4.Width = "45"
                                            txtBoxQ.Width = "60"
                                            label2.Width = "120"
                                            drp.Width = "80"
                                            tbl.Rows.Add(tr)


                                        Else
                                            If icount = 1 Then
                                                cal_date = CDate(txtFirstPayment.Text)
                                                day = cal_date.DayOfWeek.ToString
                                            Else
                                                If drpFrequency.SelectedItem.Text = "Weekly" Then
                                                    cal_date = cal_date.AddDays(7)
                                                    day = cal_date.DayOfWeek.ToString

                                                ElseIf drpFrequency.SelectedItem.Text = "Fortnightly" Then
                                                    cal_date = cal_date.AddDays(14)
                                                    day = cal_date.DayOfWeek.ToString

                                                Else
                                                    cal_date = cal_date.AddDays(30)
                                                    day = cal_date.DayOfWeek.ToString

                                                End If

                                            End If

                                            If day = "Saturday" Then
                                                label2.ForeColor = Drawing.Color.Red
                                                txtBox.Enabled = True

                                                day_flag = True
                                            End If
                                            If day = "Sunday" Then
                                                label2.ForeColor = Drawing.Color.Red
                                                txtBox.Enabled = True
                                                day_flag = True
                                            End If
                                            day1 = ""

                                            If day_flag = True Then
                                                label2.Text = ""
                                                day1 = cal_date.DayOfWeek.ToString
                                                label2.Text = day1 & "?"
                                                day_flag = False
                                            Else
                                                label2.Text = ""
                                                day1 = cal_date.DayOfWeek.ToString
                                                label2.Text = day1
                                                day_flag = False
                                            End If

                                            label3.Text = "$"
                                            label4.Text = ""
                                            txtBoxQ.Style.Add("text-align", "center")

                                            Dim amt_payable As Double
                                            amt_payable = Math.Round(open_con.fn_Round_to_Nearest_Five(int_SinglePayment), 2)
                                            txtBoxQ.Text = open_con.newamount(amt_payable)
                                            txtBox.Style.Add("text-align", "center")
                                            txtBox.Text = cal_date
                                            tc.Controls.Add(label2)
                                            tc.Controls.Add(txtBox)
                                            tc.Controls.Add(ca)
                                            tc.Controls.Add(label3)
                                            tc.Controls.Add(txtBoxQ)
                                            tc.Controls.Add(label4)
                                            tc.Controls.Add(drp)
                                            count_totalSinglePayment = count_totalSinglePayment + Math.Round(CDbl(int_SinglePayment), 2)
                                            tr.Cells.Add(tc)
                                            txtBox.Width = "80"
                                            label3.Width = "45"
                                            label4.Width = "45"
                                            txtBoxQ.Width = "60"
                                            label2.Width = "120"
                                            drp.Width = "80"
                                            tbl.Rows.Add(tr)

                                        End If
                                    Next
                                Next
                            Next
                        End If

                        PlaceHolder1.Controls.Clear()
                        PlaceHolder1.Controls.Add(tbl)
                        PlaceHolder1.Controls.Add(New LiteralControl("<br>"))

                    Else
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid first payment date!!!" & "');", True)
                        Exit Sub
                    End If
                End If
            End If

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub
    Function fn_getAppCrFee1(ByVal Amount As String, ByVal p As String) As Boolean

        Try
            Dim cmd_get_fee As New SqlCommand
            Dim str_get_fee As String
            Dim period As Integer
            If Val(Amount) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid loan amount!!!" & "');", True)
                Exit Function
            Else

                Amount = CInt(Amount)
            End If

            If Val(txtFirstPayment.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid first payment date!!!" & "');", True)
                txtFirstPayment.Focus()
                Exit Function

            End If
            If Val(txtNoOfPayment.Text) = 0 Then

                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid number of payments!!!" & "');", True)
                txtNoOfPayment.Focus()
                Exit Function
            End If

            If IsNumeric(txtNoOfPayment.Text) = False Then

                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid number of payments!!!" & "');", True)
                txtNoOfPayment.Focus()
                Exit Function
            End If
            If Val(p) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select valid payment term!!!" & "');", True)
                drpPeriod.Focus()
                Exit Function
            Else
                period = Left(p, 1)

            End If
            'If Val(l) = 0 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select a loan term!!!" & "');", True)
            '    drpLoanTerm.Focus()

            '    Exit Function

            'Else
            '    loanterm = Left(l, 2)

            'End If

            str_get_fee = "SELECT Amount, Application_Fee, Credit_Fee FROM sys_Loan_Fee Where Amount = " & CInt(Amount) & " AND Period = " & CInt(period)
            cmd_get_fee.Connection = open_con.return_con
            cmd_get_fee.CommandText = str_get_fee
            cmd_get_fee.ExecuteNonQuery()
            Dim adap_get_fee As New SqlDataAdapter(cmd_get_fee)
            Dim ds_get_fee As New DataSet
            adap_get_fee.Fill(ds_get_fee)
            If ds_get_fee.Tables(0).Rows.Count <> 0 Then
                txtCreditFee.Text = ds_get_fee.Tables(0).Rows(0).Item(2).ToString & ".00"
                txtApplicationFee.Text = ds_get_fee.Tables(0).Rows(0).Item(1).ToString & ".00"
                txtTotal1.Text = Val(txtAmount.Text) + Val(txtCreditFee.Text) + Val(txtApplicationFee.Text) + Val(txtvarfee.Text)
                create_schedule()
                Session("get_fee") = True
                cmd_get_fee.Dispose()
                adap_get_fee.Dispose()
                ds_get_fee.Dispose()
                Return True
            Else
                txtTotal1.Text = Val(txtAmount.Text) + Val(txtCreditFee.Text) + Val(txtApplicationFee.Text) + Val(txtvarfee.Text)
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Fee doesnot exist in the fee table!!!" & "');", True)
                txtAmount.Focus()
                create_schedule()
                Return False

            End If

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Function
    Protected Sub txtAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.PreRender
        If Val(txtAmount.Text) = 0 Then
            txtAmount.Focus()
        Else
            If txtFirstPayment.Text <> "" Then

                If txtNoOfPayment.Text <> "" Then
                    If drpPeriod.SelectedItem.Text <> "" Then
                        fn_getAppCrFee1(txtAmount.Text, drpPeriod.Text)
                        'If drpLoanTerm.SelectedItem.Text <> "" Then
                        '    fn_getAppCrFee1(txtAmount.Text, drpPeriod.Text, drpLoanTerm.Text)
                        'Else
                        '    Exit Sub
                        'End If
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            Else

                Exit Sub
            End If


        End If

    End Sub
    'Protected Sub drpLoanTerm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpLoanTerm.SelectedIndexChanged

    'End Sub

    Protected Sub drpFrequency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpFrequency.SelectedIndexChanged
        create_schedule()
    End Sub
    Private Function FindOccurence(ByVal substr As String) As Integer
        Dim reqstr As String = Request.Form.ToString()
        Return ((reqstr.Length - reqstr.Replace(substr, "").Length) / substr.Length)
    End Function
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Session("bank_nom") = False
        Session("letter") = 0
        Session("sch_history") = 0
        Session("loan_st") = 0
        Session("r_load") = "True"
        Session("Pay_re") = False
        Session("pay_sch") = False
        If txtsearch.Text <> "" Then
            flag_val = True
        End If
        If flag_val = True And r_load <> True Then
            Panel3.Visible = False
            Session("Show") = 0
            binddata()
        End If
    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            For i = 1 To Val(txtNoOfPayment.Text)
                If i < 10 Then
                    Dim txt_dt As TextBox = Page.FindControl("txtbox" & "0" & i)
                    If CDate(txt_dt.Text) < CDate(txtFirstPayment.Text) Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid future date!!!" & "');", True)
                        Exit Sub

                    End If
                Else
                    Dim txt_dt As TextBox = Page.FindControl("txtbox" & i)
                    If CDate(txt_dt.Text) < CDate(txtFirstPayment.Text) Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid future date!!!" & "');", True)
                        Exit Sub

                    End If
                End If
            Next

            If (Val(txtAmount.Text) <= 1000) Then
                If Val(txtNoOfPayment.Text) = 1 Then
                    Dim txt_amt As TextBox = Page.FindControl("txtb" & "0" & 1)
                    If Val(txt_amt.Text) = Val(txtTotal1.Text) Then
                        Dim day As Integer = 0
                        'day = CDate(txtFirstPayment.Text).Day - DateTime.Now.Day
                        day = DateDiff(DateInterval.Day, DateTime.Now.Date, CDate(txtFirstPayment.Text))
                        If (day <= 15) Then
                            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "SACCs term minimum 15 days!!" & "');", True)
                            Exit Sub
                        End If
                    End If
                End If
            End If

            'Validation for Teller No.
            If ddlTeller.SelectedItem.Value = "0" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select Teller No.!!!" & "');", True)
                Exit Sub
            End If

            Dim cmd_loan As New SqlCommand
            Dim str_loan As String
            str_loan = "insert into tbl_loan(Customer_ID,Amount,Frequency,Period,First_Payment,No_Of_Payment,Method_of_Disbursement,User_ID,Status,User_Machine_ID,Loan_Date,Term,Loan_Time,flag,loan_Type)values(@Customer_ID,@Amount,@Frequency,@Period,@First_Payment,@No_Of_Payment,@Method_of_Disbursement,@User_ID,@Status,@User_Machine_ID,@Loan_Date,@Term,@Loan_Time,@flag,'Loan')"
            cmd_loan.CommandText = str_loan
            cmd_loan.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
            cmd_loan.Parameters.Add("@Amount", SqlDbType.Int).Value = Val(Trim(txtAmount.Text))
            Session("Amount") = Val(Trim(txtAmount.Text))
            Session("loanapp_amt") = Val(Trim(txtAmount.Text)) & ".00"
            cmd_loan.Parameters.Add("@Frequency", SqlDbType.Int).Value = drpFrequency.SelectedItem.Value
            If drpFrequency.SelectedItem.Value = "7" Then
                Session("loanapp_freq") = "Weekly"
            ElseIf drpFrequency.SelectedItem.Value = "14" Then
                Session("loanapp_freq") = "Fortnightly"
            Else
                Session("loanapp_freq") = "Monthly"
            End If
            Session("loanapp_amtpaid") = "0.0"
            cmd_loan.Parameters.Add("@Period", SqlDbType.Int).Value = Left(Trim(drpPeriod.SelectedItem.Text), 1)
            Session("loanapp_period") = Left(Trim(drpPeriod.SelectedItem.Text), 1) & "month(s)"
            cmd_loan.Parameters.Add("@First_Payment", SqlDbType.DateTime).Value = CDate(txtFirstPayment.Text)
            cmd_loan.Parameters.Add("@No_Of_Payment", SqlDbType.Int).Value = Val(Trim(txtNoOfPayment.Text))
            cmd_loan.Parameters.Add("@Method_of_Disbursement", SqlDbType.VarChar, 50).Value = drpMethodOfDisbursement.SelectedItem.Text
            cmd_loan.Parameters.Add("@User_ID", SqlDbType.Int).Value = open_con.user_id_val
            cmd_loan.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = "0"
            cmd_loan.Parameters.Add("@User_Machine_ID", SqlDbType.VarChar, 50).Value = ddlTeller.SelectedItem.Text  'Request.ServerVariables("REMOTE_ADDR")
            Session("loan_Date") = DateTime.Now.Date
            Session("loanapp_date") = DateTime.Now.Date
            cmd_loan.Parameters.Add("@Loan_Date", SqlDbType.DateTime).Value = Session("loan_Date")
            cmd_loan.Parameters.Add("@Term", SqlDbType.VarChar, 50).Value = ""
            'If Val(drpLoanTerm.SelectedItem.Value) = 12 Then
            '    Session("loanapp_term") = "12months"
            'Else
            '    Session("loanapp_term") = "24months"
            'End If
            Session("loan_Time") = DateTime.Now.ToString("t")
            cmd_loan.Parameters.Add("@Loan_Time", SqlDbType.VarChar, 10).Value = Session("loan_Time")
            cmd_loan.Parameters.Add("@flag", SqlDbType.Int).Value = "0"
            cmd_loan.Connection = open_con.return_con
            cmd_loan.ExecuteNonQuery()
            cmd_loan.Dispose()
            open_con.return_con.Dispose()
            Session("loan_summ") = True
            Session("show_msg") = True

        Catch ex As Exception

            Response.Write("Error: " & ex.Message)
            Session("loan_summ") = False
            Exit Sub
        End Try

        Try
            Dim cmd_loan_id As New SqlCommand
            Dim str_loan_id As String
            str_loan_id = "select loan_id from tbl_loan where Customer_ID=@Customer_ID and Amount=@Amount and Loan_Date=@Loan_Date and Loan_Time=@Loan_Time and flag=@flag"
            cmd_loan_id.CommandText = str_loan_id
            cmd_loan_id.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
            cmd_loan_id.Parameters.Add("@Amount", SqlDbType.Money).Value = Session("Amount")
            cmd_loan_id.Parameters.Add("@Loan_Date", SqlDbType.DateTime).Value = Session("loan_Date")
            cmd_loan_id.Parameters.Add("@Loan_Time", SqlDbType.VarChar, 10).Value = Session("loan_Time")
            cmd_loan_id.Parameters.Add("@flag", SqlDbType.Int).Value = "0"
            cmd_loan_id.Connection = open_con.return_con
            cmd_loan_id.ExecuteNonQuery()
            Dim adap_loan_id As New SqlDataAdapter(cmd_loan_id)
            Dim ds_loan_id As New DataSet
            adap_loan_id.Fill(ds_loan_id)
            If ds_loan_id.Tables(0).Rows.Count = 1 Then
                Session("cur_loan_id") = ds_loan_id.Tables(0).Rows(0).Item(0).ToString
            End If
            cmd_loan_id.Dispose()
            adap_loan_id.Dispose()
            ds_loan_id.Dispose()
            open_con.return_con.Dispose()

            Dim cmd_upd_flg As New SqlCommand
            Dim str_flg As String
            str_flg = "update tbl_loan set flag=1 where Customer_ID=@Customer_ID and loan_id=@loan_id and Amount=@Amount and Loan_Date=@Loan_Date and Loan_Time=@Loan_Time "
            cmd_upd_flg.CommandText = str_flg
            cmd_upd_flg.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
            cmd_upd_flg.Parameters.Add("@Amount", SqlDbType.Money).Value = Session("Amount")
            cmd_upd_flg.Parameters.Add("@Loan_Date", SqlDbType.DateTime).Value = Session("loan_Date")
            cmd_upd_flg.Parameters.Add("@Loan_Time", SqlDbType.VarChar, 10).Value = Session("loan_Time")
            cmd_upd_flg.Parameters.Add("@loan_id", SqlDbType.Int).Value = Session("cur_loan_id")
            cmd_upd_flg.Connection = open_con.return_con
            cmd_upd_flg.ExecuteNonQuery()
            cmd_upd_flg.Dispose()
            open_con.return_con.Dispose()

            If Val(txtApplicationFee.Text) <> 0 Then
                Dim cmd_appfee As New SqlCommand
                Dim str_appfee As String
                Dim desc_app As String
                Dim loan_appfee As String
                desc_app = "Defer Establishment Fee"
                loan_appfee = txtApplicationFee.Text
                Session("loanapp_appfee") = Val(txtApplicationFee.Text) & ".00"
                str_appfee = "insert into Tbl_Loan_Fee(Loan_ID,Description,Fee) values(@Loan_ID,@Description,@Fee) "
                cmd_appfee.CommandText = str_appfee
                cmd_appfee.Parameters.Add("@Loan_ID", SqlDbType.Int).Value = Session("cur_loan_id")
                cmd_appfee.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = desc_app
                cmd_appfee.Parameters.Add("@Fee", SqlDbType.Money).Value = loan_appfee
                cmd_appfee.Connection = open_con.return_con
                cmd_appfee.ExecuteNonQuery()
                cmd_appfee.Dispose()
                open_con.return_con.Dispose()

            Else
                Session("loanapp_appfee") = "0.0"
            End If
            If Val(txtCreditFee.Text) <> 0 Then

                Dim cmd_crefee As New SqlCommand
                Dim str_crefee As String
                Dim desc_cre As String
                Dim loan_crefee As String
                desc_cre = "Credit Fee"
                loan_crefee = txtCreditFee.Text
                Session("loanapp_crefee") = Val(txtCreditFee.Text) & ".00"

                str_crefee = "insert into Tbl_Loan_Fee(Loan_ID,Description,Fee) values(@Loan_ID,@Description,@Fee) "
                cmd_crefee.CommandText = str_crefee
                cmd_crefee.Parameters.Add("@Loan_ID", SqlDbType.Int).Value = Session("cur_loan_id")
                cmd_crefee.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = desc_cre
                cmd_crefee.Parameters.Add("@Fee", SqlDbType.Money).Value = loan_crefee
                cmd_crefee.Connection = open_con.return_con
                cmd_crefee.ExecuteNonQuery()
                cmd_crefee.Dispose()
                open_con.return_con.Dispose()


            Else
                Session("loanapp_crefee") = "0.0"
            End If
            If Session("Check_flag") = True Then

                Dim cmd_otrfee As New SqlCommand
                Dim str_otrfee As String
                Dim desc_otr As String
                Dim loan_otrfee As String
                desc_otr = "Other Fee"
                loan_otrfee = Session("otherFee")
                Session("loanapp_otrfee") = loan_otrfee + ".00"
                str_otrfee = "insert into Tbl_Loan_Fee(Loan_ID,Description,Fee) values(@Loan_ID,@Description,@Fee) "
                cmd_otrfee.CommandText = str_otrfee
                cmd_otrfee.Parameters.Add("@Loan_ID", SqlDbType.Int).Value = Session("cur_loan_id")
                cmd_otrfee.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = desc_otr
                cmd_otrfee.Parameters.Add("@Fee", SqlDbType.Money).Value = loan_otrfee
                cmd_otrfee.Connection = open_con.return_con
                cmd_otrfee.ExecuteNonQuery()
                cmd_otrfee.Dispose()
                open_con.return_con.Dispose()

            Else
                Session("loanapp_otrfee") = "0.0"
            End If
            If Val(txtvarfee.Text) <> 0 Then

                Dim cmd_varfee As New SqlCommand
                Dim str_varfee As String
                Dim desc_var As String
                Dim loan_varfee As String
                desc_var = "Variation Fee"
                loan_varfee = txtvarfee.Text
                Session("loanapp_varfee") = Val(txtvarfee.Text) & ".00"
                str_varfee = "insert into Tbl_Loan_Fee(Loan_ID,Description,Fee) values(@Loan_ID,@Description,@Fee) "
                cmd_varfee.CommandText = str_varfee
                cmd_varfee.Parameters.Add("@Loan_ID", SqlDbType.Int).Value = Session("cur_loan_id")
                cmd_varfee.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = desc_var
                cmd_varfee.Parameters.Add("@Fee", SqlDbType.Money).Value = loan_varfee
                cmd_varfee.Connection = open_con.return_con
                cmd_varfee.ExecuteNonQuery()
                cmd_varfee.Dispose()
                open_con.return_con.Dispose()

            Else
                Session("loanapp_varfee") = "0.0"
            End If

            Dim i As Integer

            For i = 1 To Val(txtNoOfPayment.Text)
                If i < 10 Then
                    Dim txt_dt As TextBox = Page.FindControl("txtbox" & "0" & i)
                    Dim txt_amt As TextBox = Page.FindControl("txtb" & "0" & i)
                    Dim drp_frm As DropDownList = Page.FindControl("drp" & i)
                    Dim cmd_payment As New SqlCommand
                    cmd_payment.CommandText = "insert into tbl_payment(Customer_ID,Loan_ID,Due_Date,Contract_Date,Amount,Payment_Method,Date_Updated)values(" & open_con.customer_id_val & "," & Session("cur_loan_id") & ",@due_date,@contract_date," & txt_amt.Text & ",'" & drp_frm.SelectedItem.Text & "',@date_now)"
                    cmd_payment.Parameters.Add("@due_date", SqlDbType.DateTime).Value = CDate(txt_dt.Text)
                    cmd_payment.Parameters.Add("@contract_date", SqlDbType.DateTime).Value = CDate(txt_dt.Text)
                    cmd_payment.Parameters.Add("@date_now", SqlDbType.DateTime).Value = DateTime.Now.Date
                    cmd_payment.Connection = open_con.return_con
                    cmd_payment.ExecuteNonQuery()
                    open_con.return_con.Dispose()
                Else
                    Dim txt_dt As TextBox = Page.FindControl("txtbox" & i)
                    Dim txt_amt As TextBox = Page.FindControl("txtb" & i)
                    Dim drp_frm As DropDownList = Page.FindControl("drp" & i)
                    Dim cmd_payment As New SqlCommand
                    cmd_payment.CommandText = "insert into tbl_payment(Customer_ID,Loan_ID,Due_Date,Contract_Date,Amount,Payment_Method,Date_Updated)values(" & open_con.customer_id_val & "," & Session("cur_loan_id") & ",@due_date,@contract_date," & txt_amt.Text & ",'" & drp_frm.SelectedItem.Text & "',@date_now)"
                    cmd_payment.Parameters.Add("@due_date", SqlDbType.DateTime).Value = CDate(txt_dt.Text)
                    cmd_payment.Parameters.Add("@contract_date", SqlDbType.DateTime).Value = CDate(txt_dt.Text)
                    cmd_payment.Parameters.Add("@date_now", SqlDbType.DateTime).Value = DateTime.Now.Date
                    cmd_payment.Connection = open_con.return_con
                    cmd_payment.ExecuteNonQuery()
                    open_con.return_con.Dispose()
                End If
            Next
            Session("show_loan_msg") = True
            Session("check_flag") = False
            Session("show_panel") = False
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
            Session("show_loan_msg") = False
            Exit Sub
        End Try

        If Session("show_loan_msg") = True And Session("loan_summ") = True Then
            Response.Redirect("LoanSummary.aspx", False)
        End If
    End Sub
    Protected Sub btncreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncreate.Click
        If LinkButton2.Visible = True And Session("check_flag") = True Then
            Session("show_panel") = True
            panel1.Visible = True
            Panel2.Visible = True
            Label4.Visible = False
            txtTotal1.Visible = False
            LinkButton2.Visible = False
        End If
        If Val(txtAmount.Text) = 0 Then
            txtAmount.Focus()
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter valid loan amount!!!" & "');", True)
        Else
            If txtFirstPayment.Text <> "" Then
                txtNoOfPayment.Focus()
                If txtNoOfPayment.Text <> "" Then
                    drpPeriod.Focus()

                    If drpPeriod.SelectedItem.Text <> "" Then
                        create_schedule()
                        'drpLoanTerm.Focus()
                        'If drpLoanTerm.SelectedItem.Text <> "" Then

                        'Else
                        '    Exit Sub
                        'End If
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter all the required details!!!" & "');", True)
                Exit Sub
            End If
        End If
    End Sub
    Protected Sub btncal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncal.Click
        If LinkButton2.Visible = True And Session("check_flag") = True Then
            Session("show_panel") = True
            panel1.Visible = True
            Panel2.Visible = True
            Label4.Visible = False
            txtTotal1.Visible = False
            LinkButton2.Visible = False
        End If
        fn_getAppCrFee1(txtAmount.Text, drpPeriod.SelectedItem.Text)
    End Sub
    

 
    Protected Sub drpPeriod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpPeriod.SelectedIndexChanged
        fn_getAppCrFee1(txtAmount.Text, drpPeriod.Text)
    End Sub

    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub


End Class
