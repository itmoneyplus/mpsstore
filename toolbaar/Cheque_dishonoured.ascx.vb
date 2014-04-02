Imports System.Data.SqlClient
Imports System.Data
Imports AjaxControlToolkit
Partial Class toolbaar_Cheque_detail
    Inherits System.Web.UI.UserControl
    Dim open_con As New Class1
    Dim Cheque_Cashing_ID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            txtfrstpayment.Text = System.DateTime.Now.Date
          
        End If
    End Sub

    Protected Sub btncreate_sch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncreate_sch.Click
        Dim dt As DateTime
        Dim check_date As DateTime
        check_date = System.DateTime.Now.Date.ToString("dd/MM/yyyy")
        If txtfrstpayment.Text <> "" Then

            dt = Date.Parse(txtfrstpayment.Text)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid first payment date!!!" & "');", True)
            txtfrstpayment.Focus()

        End If

        If Val(txtamt.Text) = 0 Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid check amount!!!" & "');", True)
            Exit Sub
        ElseIf Val(txtfrstpayment.Text) = 0 Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid first payment date!!!" & "');", True)

        ElseIf dt < check_date Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid first payment date!!!" & "');", True)
            txtfrstpayment.Focus()
            Exit Sub
        ElseIf Val(txtnoofpay.Text) = 0 Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid no. of payments!!!" & "');", True)

        Else
            txttotfee.Text = FormatNumber((Val(txtamt.Text) + Val(txtfee.Text)), 2)
            txtamt.Text = FormatNumber(txtamt.Text, 2)

            If txtfrstpayment.Text <> "" And txtnoofpay.Text <> "" Then
                create_cheque_schedule()
            Else

            End If

        End If
    End Sub
    Protected Sub create_cheque_schedule()
        Try
            Dim tbl As Table = New Table()
            PlaceHolder1.Controls.Clear()
            PlaceHolder1.Controls.Add(tbl)
            tbl.BorderWidth = "1"

            Dim repay As Label = New Label()
            Dim snno As Label = New Label()
            Dim space As Label = New Label()
            Dim dayf As Label = New Label()
            Dim duedate As Label = New Label()
            Dim amount As Label = New Label()
            Dim modes As Label = New Label()
            repay.Text = "Re-Payment Schedule:"
            snno.Text = "SNo."
            space.Text = " "
            dayf.Text = "Week Day"
            duedate.Text = "Repayment Date"
            amount.Text = "Amount"
            modes.Text = "Method of Repayment"
            repay.Font.Bold = True
            repay.Font.Size = "14"
            repay.Font.Italic = True
            snno.Font.Bold = True
            dayf.Font.Bold = True
            duedate.Font.Bold = True
            modes.Font.Bold = True
            amount.Font.Bold = True
            repay.Width = "200"
            repay.Style.Add("text-align", "left")
            snno.Width = "100"
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


            Dim int_Total_Loan_Amount As Double
            Dim icount As Integer
            Dim dtm_First_Payment As Date
            Dim cal_date As DateTime
            Dim day As String
            Dim day_flag As Boolean
            dtm_First_Payment = txtfrstpayment.Text
            int_Total_Loan_Amount = CDbl(txtamt.Text) + CDbl(txtfee.Text)
            Dim int_SinglePayment As Double
            int_SinglePayment = FormatNumber(int_Total_Loan_Amount / txtnoofpay.Text)
            int_SinglePayment = open_con.fn_Round_to_Nearest_Five(int_SinglePayment)
            Dim count_totalSinglePayment As Double
            For icount = 1 To txtnoofpay.Text

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
               
                    '==========================================


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
                    If drpmethodpayment.SelectedItem.Text = "NAB" Then
                        drp.Text = "NAB"
                    ElseIf drpmethodpayment.SelectedItem.Text = "Cas" Then
                        drp.Text = "Cas"
                    ElseIf drpmethodpayment.SelectedItem.Text = "Sal" Then
                        drp.Text = "Sal"
                    ElseIf drpmethodpayment.SelectedItem.Text = "Chq" Then
                        drp.Text = "Chq"
                    ElseIf drpmethodpayment.SelectedItem.Text = "CBA" Then
                        drp.Text = "CBA"
                    ElseIf drpmethodpayment.SelectedItem.Text = "Cre" Then
                        drp.Text = "Cre"

                    End If
                    Dim tr As TableRow = New TableRow()
                    For j As Integer = 1 To 1

                        label1.Text = icount
                        label1.Width = "50"
                        label1.Style.Add("text-align", "left")
                        label1.Font.Bold = True
                        tc.Controls.Add(label1)

                        If icount = txtnoofpay.Text Then

                            int_SinglePayment = int_Total_Loan_Amount - count_totalSinglePayment

                            If dropfre.SelectedItem.Text = "Weekly" Then
                                If txtnoofpay.Text = "1" Then
                                    cal_date = txtfrstpayment.Text
                                    day = cal_date.DayOfWeek.ToString
                                Else
                                    cal_date = cal_date.AddDays(7)
                                    day = cal_date.DayOfWeek.ToString
                                End If

                            ElseIf dropfre.SelectedItem.Text = "Fortnightly" Then
                                If txtnoofpay.Text = "1" Then
                                    cal_date = txtfrstpayment.Text
                                    day = cal_date.DayOfWeek.ToString
                                Else
                                    cal_date = cal_date.AddDays(14)
                                    day = cal_date.DayOfWeek.ToString
                                End If
                            Else
                                If txtnoofpay.Text = "1" Then
                                    cal_date = txtfrstpayment.Text
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
                                cal_date = CDate(txtfrstpayment.Text)
                                day = cal_date.DayOfWeek.ToString
                            Else
                                If dropfre.SelectedItem.Text = "Weekly" Then
                                    cal_date = cal_date.AddDays(7)
                                    day = cal_date.DayOfWeek.ToString

                                ElseIf dropfre.SelectedItem.Text = "Fortnightly" Then
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
                            tr.Cells.Add(tc)
                            txtBox.Width = "80"
                            label3.Width = "45"
                            label4.Width = "45"
                            txtBoxQ.Width = "60"
                            label2.Width = "120"
                            drp.Width = "80"
                          
                            tbl.Rows.Add(tr)

                            count_totalSinglePayment = count_totalSinglePayment + Math.Round(CDbl(int_SinglePayment), 2)
                     

                        End If
                    Next
                Next
            Next


            PlaceHolder1.Controls.Clear()
            PlaceHolder1.Controls.Add(tbl)
            PlaceHolder1.Controls.Add(New LiteralControl("<br>"))


        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
   

End Class
