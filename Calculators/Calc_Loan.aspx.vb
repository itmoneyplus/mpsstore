Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports AjaxControlToolkit
Imports System.Globalization
Partial Class Calc_Loan
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Dim flag_val As Boolean = False
    Dim r_load As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        

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

   

End Class
