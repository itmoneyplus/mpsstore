Imports System.Data.SqlClient
Imports System.Data
Imports AjaxControlToolkit
Partial Class toolbaar_loanrepay
    Inherits System.Web.UI.UserControl
    Dim ds_loan As New DataSet
    Dim open_con As New Class1
    Dim chk As CheckBox
    Dim txtamt As TextBox
    Dim lab4, lab2, lab6 As Label
    Dim loan_id_new As Integer
    Protected WithEvents s As LinkButton
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try

                create_controls()
                If Session("user_type") = "Admin" Then
                    btnwaive.Visible = True

                Else
                    btnwaive.Visible = False

                End If
                If Session("beg_status") = "Declined" Then
                Else
                    If Session("user_type") = "Admin" And Session("beg_status").ToString <> "" Then
                        If Session("beg_status") <> "Pending" And Session("status") <> "1" Then

                            Dim j As String
                            j = ds_loan.Tables(0).Rows.Count
                            If j = 0 Then
                                Session("enf") = True
                            End If
                            For i As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
                                If ds_loan.Tables(0).Rows(i).Item("Payment_Status").ToString <> "Paid" Then
                                    Session("enf") = False
                                    Exit For
                                Else
                                    Session("enf") = True
                                End If
                            Next
                            If Session("enf") = False Then
                                btnwaive.Visible = True
                                btnacpt.Visible = True
                                btncancel.Visible = True
                                btnenfee.Visible = True
                                btnmodsch.Visible = True
                                btnshow.Visible = True
                                show_dis()
                            Else
                                show_dis()
                                btnsave_pay.Visible = False
                                btncncl_pay.Visible = False
                                btnshow.Visible = False
                                btnwaive1.Visible = False
                                btncncl.Visible = False
                                btnwaive.Visible = False
                                btnacpt.Visible = False
                                btncancel.Visible = False
                                'If Drppayfreq.Enabled = True Then
                                '    btnenfee.Visible = False
                                'Else

                                btnenfee.Visible = True
                                'End If

                                btnmodsch.Visible = False

                            End If
                        Else
                        End If
                    Else
                    End If
                End If

                ''''''''''''''''''''''''''''''''this is done to create the controls of enforcement schedule at run time else will give null reference exception.

                If Page.IsPostBack = True And btnenfrc.Visible = True And Session("letter") = 0 Then

                    txtPaymentAmount.Text = ""
                    lblReturn.Visible = False
                    lblRetHead.Visible = False
                    If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        enforcement_schedule()

                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        enforcement_schedule()


                    ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        enforcement_schedule()

                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        enforcement_schedule()
                    ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        enforcement_schedule()


                    ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False And Session("beg_status") <> "Declined" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        enforcement_schedule()
                    ElseIf Session("beg_status") = "Declined" Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        enforcement_schedule()
                    Else
                        If Val(Session("beg_loan_id")) <> 0 Then
                            ds_loan = find_repay(Session("beg_loan_id"))
                            enforcement_schedule()
                        Else
                            ds_loan = find_repay(Session("cur_loan_id"))
                            enforcement_schedule()
                        End If
                    End If


                End If

                ''''''''''''''for cancel schedule
                If Page.IsPostBack = True And btncncl_save.Visible = True And Session("letter") = 0 Then
                    txtPaymentAmount.Text = ""
                    lblReturn.Visible = False
                    lblRetHead.Visible = False

                    If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        cancel_schedule()

                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        cancel_schedule()


                    ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        cancel_schedule()

                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        cancel_schedule()
                    ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        cancel_schedule()


                    ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False And Session("beg_status") <> "Declined" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        cancel_schedule()

                    ElseIf Session("beg_status") = "Declined" Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        cancel_schedule()
                    Else
                        If Val(Session("beg_loan_id")) <> 0 Then
                            ds_loan = find_repay(Session("beg_loan_id"))
                            cancel_schedule()
                        Else
                            ds_loan = find_repay(Session("cur_loan_id"))
                            cancel_schedule()

                        End If
                    End If


                End If

                ''''''''''''''for dishonour schedule
                If Page.IsPostBack = True And btnsave_dis.Visible = True And Session("letter") = 0 Then
                    txtPaymentAmount.Text = ""
                    lblReturn.Visible = False
                    lblRetHead.Visible = False

                    If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        dishonour_schedule()
                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        dishonour_schedule()

                    ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        dishonour_schedule()

                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        dishonour_schedule()
                    ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        dishonour_schedule()


                    ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False And Session("beg_status") <> "Declined" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        dishonour_schedule()
                    ElseIf Session("beg_status") = "Declined" Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        dishonour_schedule()

                    Else
                        If Val(Session("beg_loan_id")) <> 0 Then
                            ds_loan = find_repay(Session("beg_loan_id"))
                            dishonour_schedule()
                        Else
                            ds_loan = find_repay(Session("cur_loan_id"))
                            dishonour_schedule()
                        End If
                    End If

                End If

                ''''''''''''for accept payment schedule
                If Page.IsPostBack = True And btncncl_pay.Visible = True And Session("letter") = 0 Then
                    If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        payment_schedule()
                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        payment_schedule()

                    ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        payment_schedule()

                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        payment_schedule()
                    ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        payment_schedule()


                    ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False And Session("beg_status") <> "Declined" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        payment_schedule()
                    ElseIf Session("beg_status") = "Declined" Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        payment_schedule()
                    Else
                        If Val(Session("beg_loan_id")) <> 0 Then
                            ds_loan = find_repay(Session("beg_loan_id"))
                            payment_schedule()
                        Else
                            ds_loan = find_repay(Session("cur_loan_id"))
                            payment_schedule()
                        End If
                    End If



                End If

                ''''''''''modify schedule

                If Page.IsPostBack = True And btnsave_mod.Visible = True And Session("letter") = 0 And Val(txtaddpaymnt.Text) <> 0 Then

                    Session("tot_SinglePayment") = 0
                    Session("tot_SinglePayment_new") = 0
                    If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        modify_schedule()
                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        modify_schedule()

                    ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        modify_schedule()

                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        modify_schedule()
                    ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        modify_schedule()


                    ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False And Session("beg_status") <> "Declined" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        modify_schedule()
                    ElseIf Session("beg_status") = "Declined" Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        modify_schedule()
                    Else
                        If Val(Session("beg_loan_id")) <> 0 Then
                            ds_loan = find_repay(Session("beg_loan_id"))
                            modify_schedule()
                        Else
                            ds_loan = find_repay(Session("cur_loan_id"))
                            modify_schedule()
                        End If
                    End If

                End If
          

            Catch ex As Exception

                Response.Write("Error: " & ex.Message)

            End Try
        End If
    End Sub
    Sub show_loan_repay(ByVal ds As DataSet)

        Dim tbl As Table = New Table()
        tbl.ID = "tbl_dynamic"
        tbl.Style.Add("border-style", "none")
        tbl.Style.Add("border-width", "1px")
        tbl.Style.Add(" border-color", "gray")
        tbl.Style.Add("width", "100%")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim snno As Label = New Label()
        snno.Text = "No."
        snno.Font.Bold = True
        snno.Width = "30"
        snno.Height = "22"
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
        AddHandler s.Click, AddressOf s_Click
        s.ID = "s_link"
        s.Text = "Select"

        s.Font.Bold = True
        s.Width = "80"
        s.Height = "22"
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
        des.Width = "150"
        des.Height = "22"
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
        duedt.Width = "150"
        duedt.Height = "22"
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
        amt.Width = "120"
        amt.Height = "22"
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
        p.Height = "22"
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
        pdate.Width = "130"
        pdate.Height = "22"
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
        pmethod.Width = "150"
        pmethod.Height = "22"
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
        tdes.Height = "22"
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
        tdate.Width = "168"
        tdate.Height = "22"
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
            label1.Width = "30"
            label1.ID = "lab1" & Format(icount, "00")
            label1.Style.Add("font-size", "12px")
            label1.Style.Add("font-family", "MS Sans Serif")
            label1.Style.Add("font-weight", "bold")
            label1.Style.Add("text-align", "center")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim check1 As CheckBox = New CheckBox
            check1.Width = "80"
            check1.ID = "chk" & Format(icount, "00")
            check1.Style.Add("text-align", "center")


            Dim label_chk As Label = New Label
            label_chk.Width = "150"
            label_chk.ID = "label_chk" & Format(icount, "00")
            label_chk.Style.Add("text-align", "center")
            label_chk.Visible = False
            ''''''''''''''''''''''''''''''''''''''''''''''
            Dim label2 As Label = New Label()
            label2.ID = "lab2" & Format(icount, "00")
            label2.Width = "160"
            label2.Style.Add("font-size", "12px")
            label2.Style.Add("font-family", "MS Sans Serif")
            label2.Style.Add("font-weight", "bold")
            label2.Style.Add("text-align", "center")
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim txtdt As TextBox = New TextBox
            txtdt.Width = "140"
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
            txtamt.Width = "110"
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
            txtpaydt.Width = "130"
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

            Dim ca_loan As New CalendarExtender
            ca_loan.ID = "ca_loan" & Format(icount, "00")
            ca_loan.Format = "dd-MMM-yyyy"
            ca_loan.TargetControlID = txtdt.ID
            ca_loan.Enabled = False
            ca_loan.OnClientShowing = "showDate"
            ca_loan.CssClass = "red"
            ca_loan.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For i = 1 To 1

                label1.Text = icount + 1
                label2.Text = ds.Tables(0).Rows(icount).Item("Description").ToString
                Dim due_dt As String
                due_dt = CDate(ds.Tables(0).Rows(icount).Item("Due_Date")).ToString("dd/MMM/yyyy")
                Dim due_dt_new As Date
                due_dt_new = CDate(ds.Tables(0).Rows(icount).Item("Due_Date"))

                Dim month_due, year_due, day_due As String

                day_due = Left(due_dt, 2)
         
                Dim pos_int_Total1 As Integer
                pos_int_Total1 = InStr(1, due_dt, "/")

                month_due = Mid(due_dt, pos_int_Total1 + 1, 3)
                year_due = Val(Right(due_dt, 4))


                due_dt = day_due & "-" & month_due & "-" & year_due

                txtdt.Text = due_dt
                Dim amt_payable As Double
                amt_payable = CDbl(ds.Tables(0).Rows(icount).Item("Amount").ToString)
                txtamt.Text = open_con.newamount(amt_payable)
                label4.Text = ds.Tables(0).Rows(icount).Item("Payment_ID").ToString
                label6.Text = ds.Tables(0).Rows(icount).Item("Contract_Date").ToString

                If ds.Tables(0).Rows(icount).Item("Payment_Status").ToString = "Paid" And ds.Tables(0).Rows(icount).Item("Transaction_Status").ToString = "Dishonour" Then
                    Dim month_dis, year_dis, day_dis As String
                    Dim dis_date As String

                    dis_date = CDate(ds.Tables(0).Rows(icount).Item("Transaction_Date")).ToString("dd/MMM/yyyy")

                    day_dis = Left(dis_date, 2)
                 
                    Dim pos_int_dis As Integer
                    pos_int_dis = InStr(1, dis_date, "/")
                    month_dis = Mid(dis_date, pos_int_dis + 1, 3)
                    year_dis = Val(Right(dis_date, 4))
                    dis_date = day_dis & "-" & month_dis & "-" & year_dis
                    txttrans_date.Visible = True
                    txttrans_date.Style.Add("border-style", "none")
                    txttrans_date.Style.Add("background-color", "white")
                    txttrans_date.Text = dis_date
                    label7.Visible = True
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
                    pay_dt = CDate(pay_dt).ToString("dd/MMM/yyyy")
                    day_pay = Left(pay_dt, 2)
                    Dim pos_int_dis As Integer
                    pos_int_dis = InStr(1, pay_dt, "/")

                    month_pay = Mid(pay_dt, pos_int_dis + 1, 3)
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
                tc.Controls.Add(ca_loan)
                tr.Cells.Add(tc)
                tbl.Rows.Add(tr)
                Session("acpt_due_date_mod") = due_dt
            Next

        Next

        PlaceHolder1.Controls.Clear()
        PlaceHolder1.Controls.Add(tbl)
        ds.Dispose()

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnwaive.Click
        set_panel()
        Dim j As Integer
        Dim cal_count As Integer = 0
        Dim check_count As Integer = 0

        For j = 0 To Session("count") - 1
            If cal_count < 10 Then

                chk = Me.FindControl("chk" & "0" & j)
                txtamt = Me.FindControl("txtamt" & "0" & j)

            Else
                chk = Me.FindControl("chk" & j)
                txtamt = Me.FindControl("txtamt" & j)

            End If
            If chk.Checked = True Then
                check_count = check_count + 1
                btnwaive1.ForeColor = Drawing.Color.Red
                btnwaive1.Visible = True
                btncncl.Width = "100"
                btncncl.Visible = True

                '''''''''''''''''''''''''''''''top line
                btnshow.Visible = False
                btnacpt.Visible = False
                btnenfee.Visible = False
                btnmodsch.Visible = False
                btnwaive.Visible = False
                btncancel.Visible = False
                '''''''''''''''''''''''''''''''''second line
                btnmake_dis.Visible = False
                btncon_dis.Visible = False
                btnenfrc.Visible = False
                btncncl_enf.Visible = False
                btncncl_save.Visible = False
                btncnl_cncl.Visible = False
                btncncl_pay.Visible = False
                btnsave_pay.Visible = False
                btnmake_dis.Visible = False
                btncon_dis.Visible = False
                cal_count = cal_count + 1
            Else
                cal_count = cal_count + 1
            End If
        Next

        If check_count = 0 Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select the payment number you want to waive!!!" & "');", True)
        Else
        End If

    End Sub
    Protected Sub btnwaive1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnwaive1.Click

        Try
            set_panel()
            Dim j As Integer
            Dim cal_count As Integer = 0

            For j = 0 To Session("count") - 1
                If cal_count < 10 Then
                    chk = Me.FindControl("chk" & "0" & j)
                    lab4 = Me.FindControl("lab4" & "0" & j)
                Else
                    chk = Me.FindControl("chk" & j)
                    lab4 = Me.FindControl("lab4" & j)
                End If
                If chk.Checked = True Then

                    Dim cmd_waive As New SqlCommand
                    Dim str_SQL As String
                    str_SQL = "Update Tbl_Payment set Transaction_Status = 'Waived',"
                    str_SQL = str_SQL & " User_ID = " & open_con.user_id_val & ","
                    str_SQL = str_SQL & " User_Machine_ID = '" & Request.ServerVariables("REMOTE_ADDR") & "',"
                    str_SQL = str_SQL & " Transaction_Date = @a"
                    str_SQL = str_SQL & " WHERE Payment_ID = " & lab4.Text
                    cmd_waive.Parameters.Add("@a", SqlDbType.DateTime).Value = DateTime.Now.Date
                    cmd_waive.CommandText = str_SQL
                    cmd_waive.Connection = open_con.return_con
                    cmd_waive.ExecuteNonQuery()
                    cmd_waive.Dispose()
                    cal_count = cal_count + 1
                Else
                    cal_count = cal_count + 1
                End If
            Next

            create_controls()
            If ds_loan.Tables(0).Rows.Count = 0 Then
                Session("enf") = True
            End If
            For i As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
                If ds_loan.Tables(0).Rows(i).Item("Payment_Status").ToString <> "Paid" Then
                    Session("enf") = False
                    Exit For
                Else
                    Session("enf") = True
                End If
            Next
            If Session("enf") = False Then
                btnwaive.Visible = True
                btnacpt.Visible = True
                btncancel.Visible = True
                btnenfee.Visible = True
                btnmodsch.Visible = True
                btnshow.Visible = True
                btnmake_dis.Visible = False
                btncon_dis.Visible = False
                btnwaive1.Visible = False
                btncncl.Visible = False
                ds_loan.Dispose()
                open_con.return_con.Dispose()
            Else
                show_dis()
                btnsave_pay.Visible = False
                btncncl_pay.Visible = False
                btnshow.Visible = False
                btnwaive1.Visible = False
                btncncl.Visible = False
                btnwaive.Visible = False
                btnacpt.Visible = False
                btncancel.Visible = False
                btnenfee.Visible = True
                btnmodsch.Visible = False
                ds_loan.Dispose()
                open_con.return_con.Dispose()
            End If

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try


    End Sub
    Protected Sub btncncl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncncl.Click
        btnwaive1.Visible = False
        btncncl.Visible = False
        set_panel()
        cancel_routine()
    End Sub
    Protected Sub btnenfee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnenfee.Click
        set_panel()
        enforcement_schedule()
    End Sub

    Sub enforcement_schedule()
        txtPaymentAmount.Text = ""
        lblReturn.Visible = False
        lblRetHead.Visible = False
        Dim tbl_new As New Table
        tbl_new = PlaceHolder1.FindControl("tbl_dynamic")
        tbl_new.ID = "tbl_new"
        Dim tr As New TableRow()
        tr.ID = "tr_enf"
        Dim td As New TableCell()
        td.ID = "td_enf"
        td.Style.Add("border-style", "solid")
        td.Style.Add("border-width", "1px")
        td.Style.Add(" border-color", "gray")
        tr.Style.Add("border-style", "solid")
        tr.Style.Add("border-width", "1px")
        tr.Style.Add(" border-color", "gray")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_new As Label = New Label()
        label_new.Width = "35"
        label_new.Style.Add("font-size", "12px")
        label_new.Style.Add("font-family", "MS Sans Serif")
        label_new.Style.Add("font-weight", "bold")
        label_new.Style.Add("text-align", "center")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label1_new As Label = New Label()
        label1_new.Width = "40"
        label1_new.Style.Add("font-size", "12px")
        label1_new.Style.Add("font-family", "MS Sans Serif")
        label1_new.Style.Add("font-weight", "bold")
        label1_new.Style.Add("text-align", "center")

        ''''''''''''''''''''''''''''''''''''''''''''''
        Dim drop_new As DropDownList = New DropDownList()
        drop_new.ID = "drop_enf"
        drop_new.Width = "105"
        drop_new.Items.Add("Variation fee")
        drop_new.Style.Add("font-size", "12px")
        drop_new.Style.Add("font-family", "MS Sans Serif")
        drop_new.Style.Add("font-weight", "bold")
        drop_new.Style.Add("text-align", "left")

        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label7_new As Label = New Label() '''''''''''''''''for spacing only
        label7_new.Width = "15"
        label7_new.Text = ""
        ''''''''''''''''''''''''''''''
        Dim txtdt_new As TextBox = New TextBox
        txtdt_new.ID = "txtdt_enf"
        txtdt_new.Width = "80"
        txtdt_new.Style.Add("font-size", "12px")
        txtdt_new.Style.Add("font-family", "MS Sans Serif")
        txtdt_new.Style.Add("font-weight", "bold")
        txtdt_new.Style.Add("text-align", "center")
        txtdt_new.Style.Add("border-style", "solid")
        txtdt_new.Style.Add("border-color", "gray")
        txtdt_new.Style.Add("border-width", "1px")
        txtdt_new.Style.Add("background-color", "pink")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label3_new As Label = New Label
        label3_new.Text = "$"
        label3_new.Width = "15"
        label3_new.Style.Add("font-size", "12px")
        label3_new.Style.Add("font-family", "MS Sans Serif")
        label3_new.Style.Add("font-weight", "bold")
        label3_new.Style.Add("text-align", "right")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtamt_new As TextBox = New TextBox
        txtamt_new.ID = "txtamt_enf"
        txtamt_new.Width = "50"
        txtamt_new.Style.Add("font-size", "12px")
        txtamt_new.Style.Add("font-family", "MS Sans Serif")
        txtamt_new.Style.Add("font-weight", "bold")
        txtamt_new.Style.Add("text-align", "center")
        txtamt_new.Style.Add("border-color", "gray")
        txtamt_new.Style.Add("border-style", "solid")
        txtamt_new.Style.Add("border-width", "1px")
        txtamt_new.Style.Add("background-color", "pink")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pay_new As LinkButton = New LinkButton
        pay_new.Width = "30"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtpaydt_new As Label = New Label
        txtpaydt_new.Width = "90"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label4_new As Label = New Label
        label4_new.Width = "15"
        label4_new.Text = ""
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label5_new As Label = New Label
        label5_new.Text = ""
        label5_new.Width = "15"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim drop1_new As DropDownList = New DropDownList
        drop1_new.ID = "paymethod_enf"
        drop1_new.Width = "90"
        drop1_new.Style.Add("font-size", "12px")
        drop1_new.Style.Add("font-family", "MS Sans Serif")
        drop1_new.Style.Add("font-weight", "bold")
        drop1_new.Style.Add("text-align", "center")
        drop1_new.Items.Add("NAB")
        drop1_new.Items.Add("Cas")
        drop1_new.Items.Add("Sal")
        drop1_new.Items.Add("Chq")
        drop1_new.Items.Add("CBA")
        drop1_new.Items.Add("Cre")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label6_new As Label = New Label
        label6_new.Text = ""
        label6_new.Width = "40"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        label_new.Text = Session("count") + 1
        label1_new.Text = ""

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ca As New CalendarExtender
        ca.ID = "ca"
        ca.Format = "dd-MMM-yyyy"
        ca.TargetControlID = txtdt_new.ID
        ca.OnClientShowing = "showDate"
        ca.CssClass = "red"
        ca.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        td.Controls.Add(label_new)
        td.Controls.Add(label1_new)
        td.Controls.Add(drop_new)
        td.Controls.Add(label7_new)
        td.Controls.Add(txtdt_new)
        td.Controls.Add(ca)
        td.Controls.Add(label3_new)
        td.Controls.Add(txtamt_new)
        td.Controls.Add(pay_new)
        td.Controls.Add(txtpaydt_new)
        td.Controls.Add(label4_new)
        td.Controls.Add(label5_new)
        td.Controls.Add(drop1_new)
        td.Controls.Add(label6_new)
        tr.Controls.Add(td)
        If Session("count") = 0 Then
            Session("count") = 0
            tbl_new.Controls.Add(tr) 'index so zero based, zero = row 1   
        Else
            tbl_new.Controls.Add(tr)
        End If
        'tbl_new.Controls.AddAt(Session("count") + 1, tr) 'index so zero based, zero = row 1   

        PlaceHolder1.Controls.Add(tbl_new)
        PlaceHolder1.Controls.Add(New LiteralControl("<br>"))
        btnenfrc.Visible = True
        btncncl_enf.Visible = True
        btnenfrc.ForeColor = Drawing.Color.Red
        btnwaive.Visible = False
        btnwaive1.Visible = False
        btncncl_enf.Width = "100"
        btncncl.Visible = False
        btnacpt.Visible = False
        btncancel.Visible = False
        btnenfee.Visible = False
        btnmodsch.Visible = False
        btnshow.Visible = False
        btnmake_dis.Visible = False
        btncon_dis.Visible = False


    End Sub

    Protected Sub btncncl_enf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncncl_enf.Click
        btnenfrc.Visible = False
        btncncl_enf.Visible = False
        cancel_routine()
        set_panel()
    End Sub

    Protected Sub btnenfrc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnenfrc.Click

        Try
            set_panel()
            Dim txtdt_enf As New TextBox
            txtdt_enf = PlaceHolder1.FindControl("txtdt_enf")
            Session("date_enf") = Trim(txtdt_enf.Text)

            '''''''''''''if the textbox is blank''''''''''checking
            If Val(Session("date_enf")) <> 0 Then

                If txtdt_enf.Text < System.DateTime.Now.Date Then
                    txtdt_enf.Focus()
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                    valid_date_enf()
                    Exit Sub
                Else
                    '''''''''''''''''''''''''''checking if date is greater then 5 years
                    Dim date_now As Date
                    date_now = System.DateTime.Now.Date.ToString("dd/MM/yyyy")
                    Dim date_new As Date
                    date_new = date_now.AddYears(5)
                    Dim date_new_enf As Date
                    date_new_enf = Date.Parse(txtdt_enf.Text)
                    date_new_enf = date_new_enf.ToString("dd/MM/yyyy")

                    If date_new_enf < date_new Then


                    Else
                        txtdt_enf.Focus()
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                        valid_date_enf()
                        Exit Sub
                    End If

                End If
            Else
                txtdt_enf.Focus()
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                valid_date_enf()
                Exit Sub
            End If

            Dim txtamt_enf As New TextBox
            txtamt_enf = PlaceHolder1.FindControl("txtamt_enf")
            Dim paymethod_enf As New DropDownList
            paymethod_enf = PlaceHolder1.FindControl("paymethod_enf")
            If Val(txtamt_enf.Text) = 0 Then
                txtamt_enf.BackColor = Drawing.Color.Red
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Fill the correct Amount!!!" & "');", True)
                Exit Sub
            End If

            If txtdt_enf.Text <> "" And Val(txtamt_enf.Text) <> 0 Then
                Dim cmd_enfrc As New SqlCommand
                Dim str_SQL As String
                str_SQL = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Description, Due_Date, Amount, Payment_Method, Transaction_Date, Fee_Status, Date_Updated) values "
                str_SQL = str_SQL & "(@loan_id,@cus_id,@enfee,@due_dt,@amt_due,@pay_method,@tdate,@fee_st,@dateupd)"
                cmd_enfrc.CommandText = str_SQL
                Dim loan_id As Integer
                If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
                    loan_id = Session("beg_loan_id")
                    cmd_enfrc.Parameters.Add("@loan_id", SqlDbType.Int).Value = loan_id
                    cmd_enfrc.Parameters.Add("@cus_id", SqlDbType.Int).Value = open_con.customer_id_val
                    cmd_enfrc.Parameters.Add("@enfee", SqlDbType.VarChar, 50).Value = "Variation fee"
                    cmd_enfrc.Parameters.Add("@due_dt", SqlDbType.DateTime).Value = txtdt_enf.Text
                    cmd_enfrc.Parameters.Add("@amt_due", SqlDbType.VarChar, 50).Value = txtamt_enf.Text
                    cmd_enfrc.Parameters.Add("@pay_method", SqlDbType.VarChar, 50).Value = paymethod_enf.SelectedItem.Text
                    cmd_enfrc.Parameters.Add("@tdate", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                    cmd_enfrc.Parameters.Add("@fee_st", SqlDbType.VarChar, 50).Value = "Variation fee"
                    cmd_enfrc.Parameters.Add("@dateupd", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                    cmd_enfrc.Connection = open_con.return_con
                    cmd_enfrc.ExecuteNonQuery()
                    cmd_enfrc.Dispose()
                    cancel_routine()
                    btnenfrc.Visible = False
                    btncncl_enf.Visible = False

                ElseIf Session("flag_approve") = True Then
                    loan_id = Session("cur_loan_id")
                    cmd_enfrc.Parameters.Add("@loan_id", SqlDbType.Int).Value = loan_id
                    cmd_enfrc.Parameters.Add("@cus_id", SqlDbType.Int).Value = open_con.customer_id_val
                    cmd_enfrc.Parameters.Add("@enfee", SqlDbType.VarChar, 50).Value = "Variation fee"
                    cmd_enfrc.Parameters.Add("@due_dt", SqlDbType.DateTime).Value = txtdt_enf.Text
                    cmd_enfrc.Parameters.Add("@amt_due", SqlDbType.VarChar, 50).Value = txtamt_enf.Text
                    cmd_enfrc.Parameters.Add("@pay_method", SqlDbType.VarChar, 50).Value = paymethod_enf.SelectedItem.Text
                    cmd_enfrc.Parameters.Add("@tdate", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                    cmd_enfrc.Parameters.Add("@fee_st", SqlDbType.VarChar, 50).Value = "Variation fee"
                    cmd_enfrc.Parameters.Add("@dateupd", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                    cmd_enfrc.Connection = open_con.return_con
                    cmd_enfrc.ExecuteNonQuery()
                    cmd_enfrc.Dispose()
                    cancel_routine()
                    btnenfrc.Visible = False
                    btncncl_enf.Visible = False
                End If

            Else

            End If
            open_con.return_con.Dispose()
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
            valid_date_enf()
        End Try
    End Sub

    Protected Sub btncnl_cncl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncnl_cncl.Click
        btncncl_save.Visible = False
        btncnl_cncl.Visible = False
        cancel_routine()
        set_panel()
    End Sub

    Protected Sub btncncl_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncncl_save.Click

        Try

            Dim txtdt_cncl As New TextBox
            txtdt_cncl = Me.FindControl("txtdt_cancel_new" & Format(Session("count_cncl"), "00"))
            Session("new_date") = txtdt_cncl.Text
            If Session("new_date") <> "" Then
                If Session("new_date") < System.DateTime.Now.Date Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                    txtdt_cncl.Focus()
                    valid_cancel_sch()
                    Exit Sub
                Else
                End If

            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                txtdt_cncl.Focus()
                valid_cancel_sch()
                Exit Sub
            End If


            Dim txtpay_cncl_new As New DropDownList
            txtpay_cncl_new = Me.FindControl("paymethod_cancel_new" & Format(Session("count_cncl"), "00"))
            Session("pay_method_new") = txtpay_cncl_new.SelectedItem.Text


            Dim txtamt_cncl As New TextBox
            txtamt_cncl = Me.FindControl("txtamt_cancel_new" & Format(Session("count_cncl"), "00"))
            Session("new_amount") = txtamt_cncl.Text

            If txtdt_cncl.Text <> "" Then
                Dim str_SQL_payment As String
                Dim cmd_cncl As New SqlCommand
                Dim adap_cncl As SqlDataAdapter
                Dim ds_cncl As New DataSet
                Dim txt_Description As String
                Dim txt_ContractDate As String
                Dim amt_dis As Double
                str_SQL_payment = " SELECT Tbl_Payment.Description, Tbl_Payment.Contract_Date,Amount "
                str_SQL_payment = str_SQL_payment & " FROM Tbl_Payment  "
                str_SQL_payment = str_SQL_payment & "  Where Loan_ID = " & Session("pay_id")
                str_SQL_payment = str_SQL_payment & "  AND Payment_ID = " & Session("payment_id")
                cmd_cncl.CommandText = str_SQL_payment
                cmd_cncl.Connection = open_con.return_con
                cmd_cncl.ExecuteNonQuery()
                adap_cncl = New SqlDataAdapter(cmd_cncl)
                adap_cncl.Fill(ds_cncl)
                txt_Description = ds_cncl.Tables(0).Rows(0).Item(0).ToString
                txt_ContractDate = ds_cncl.Tables(0).Rows(0).Item(1).ToString
                amt_dis = ds_cncl.Tables(0).Rows(0).Item(2).ToString
                adap_cncl.Dispose()
                cmd_cncl.Dispose()
                ds_cncl.Dispose()

                ''''''''''''''''This is use dto find the due amount to be saved in notice table
                Dim str_amount_due As String
                Dim amount_due As Double
                Dim cancel_dis_fee As Double
                Dim cancel_var_fee As Double
                str_amount_due = "SELECT Tbl_Payment.Loan_ID, Sum(Tbl_Payment.Amount) AS Amount_Outstanding FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID "
                str_amount_due = str_amount_due & "WHERE (((Tbl_Payment.Description)='Arear notice fee' Or (Tbl_Payment.Description)='Statement of account fee' Or (Tbl_Payment.Description)='Variation fee' Or (Tbl_Payment.Description)='Default notice fee' Or (Tbl_Payment.Description)='Letter of demand fee' Or (Tbl_Payment.Description)='Dishonoured fee' Or (Tbl_Payment.Description)='Enforcement fee' Or (Tbl_Payment.Description) Is Null OR Tbl_Payment.Description = '') AND ((Tbl_Payment.Transaction_Status) Is Null) AND ((Tbl_Payment.Payment_Date) Is Null) AND ((Tbl_Payment_1.Update_ID) Is Null)) "
                str_amount_due = str_amount_due & "GROUP BY Tbl_Payment.Loan_ID HAVING Tbl_Payment.Loan_ID=" & Session("pay_id") & "ORDER BY Tbl_Payment.Loan_ID "
                Dim cmd_amount_due As New SqlCommand
                Dim adap_amount_due As SqlDataAdapter
                Dim ds_amount_due As New DataSet
                cmd_amount_due.CommandText = str_amount_due
                cmd_amount_due.Connection = open_con.return_con
                cmd_amount_due.ExecuteNonQuery()
                adap_amount_due = New SqlDataAdapter(cmd_amount_due)
                adap_amount_due.Fill(ds_amount_due)
                If ds_amount_due.Tables(0).Rows.Count = 0 Then
                    If Val(Session("cancel_var_fee")) <> 0 Then
                        cancel_var_fee = CDbl(Session("cancel_var_fee"))
                    Else
                        cancel_var_fee = 0
                    End If
                    If Val(Session("cancel_dis_fee")) <> 0 Then
                        cancel_dis_fee = CDbl(Session("cancel_dis_fee"))
                    Else
                        cancel_dis_fee = 0
                    End If

                    amount_due = amt_dis + cancel_var_fee + cancel_dis_fee
                    Session("cancel_dis_fee") = ""
                    Session("cancel_var_fee") = ""

                Else


                    If Val(Session("cancel_var_fee")) <> 0 Then
                        cancel_var_fee = Session("cancel_var_fee")
                    Else
                        cancel_var_fee = 0
                    End If
                    If Val(Session("cancel_dis_fee")) <> 0 Then
                        cancel_dis_fee = Session("cancel_dis_fee")
                    Else
                        cancel_dis_fee = 0
                    End If

                    amount_due = ds_amount_due.Tables(0).Rows(0).Item(1) + cancel_var_fee + cancel_dis_fee
                    Session("cancel_dis_fee") = ""
                    Session("cancel_var_fee") = ""

                End If

                cmd_amount_due.Dispose()
                adap_amount_due.Dispose()
                ds_amount_due.Dispose()


                If Session("enable") = "True" Then

                    Dim txtdt_cncl_var As New TextBox
                    txtdt_cncl_var = Me.FindControl("txtdt_cancel" & Format(Session("count_cncl_var"), "00"))
                    Session("new_date_var") = txtdt_cncl_var.Text

                    If Session("new_date_var") <> "" Then
                        If Session("new_date_var") < System.DateTime.Now.Date Then
                            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                            txtdt_cncl_var.Focus()
                            valid_cancel_sch()
                            Exit Sub
                        Else

                        End If
                    Else
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                        txtdt_cncl_var.Focus()
                        valid_cancel_sch()
                        Exit Sub
                    End If
                ElseIf Session("enable") = "False" Then
                    Dim txtdt_cncl_var As New TextBox
                    txtdt_cncl_var = Me.FindControl("txtdt_cancel" & Format(Session("count_cncl_var"), "00"))
                    Session("new_date_var") = txtdt_cncl_var.Text
                    If Session("new_date_var") <> "" Then
                        If Session("new_date_var") < System.DateTime.Now.Date Then
                            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                            txtdt_cncl_var.Focus()
                            valid_cancel_sch()
                            Exit Sub
                        Else
                        End If
                    Else
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                        txtdt_cncl_var.Focus()
                        valid_cancel_sch()
                        Exit Sub
                    End If
                Else
                    If Val(txtdt_cncl.Text) = 0 Then
                        txtdt_cncl.BackColor = Drawing.Color.Red
                    ElseIf Val(txtdt_cncl.Text) = 0 Then
                        txtdt_cncl.BackColor = Drawing.Color.Red
                    End If
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter valid Due Date!!!" & "');", True)
                    Exit Sub
                End If


                ''''''''''''''''''''''''''''''To save the records in notice table
                Dim str_SQL As String
                str_SQL = "Insert into Tbl_Notice(Customer_ID, Loan_ID, Payment_ID, Amount_OutStanding, Notice_Expires_On, Description, User_ID, Notice_Created_On) values "
                str_SQL = str_SQL & "(" & open_con.customer_id_val & "," & Session("pay_id") & "," & Session("payment_id") & ",@amt_out,"

                If Session("payment_method") = "Sal" Then
                    str_SQL = str_SQL & "@notice_expires,'Payroll Cancel'," & open_con.user_id_val & ",@notice_date)"
                Else
                    str_SQL = str_SQL & "@notice_expires,'Direct Debit Cancel'," & open_con.user_id_val & ",@notice_date)"
                End If

                Dim cmd_notice As New SqlCommand
                cmd_notice.CommandText = str_SQL
                cmd_notice.Parameters.Add("@amt_out", SqlDbType.VarChar, 50).Value = amount_due
                cmd_notice.Parameters.Add("@notice_expires", SqlDbType.DateTime).Value = System.DateTime.Now.AddDays(2)
                cmd_notice.Parameters.Add("@notice_date", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                cmd_notice.Connection = open_con.return_con
                cmd_notice.ExecuteNonQuery()
                cmd_notice.Dispose()

                Dim str_sql1 As String
                str_sql1 = "Update Tbl_Payment set "
                str_sql1 = str_sql1 & " Description = NULL,"
                str_sql1 = str_sql1 & " Transaction_Status = 'Cancel',"
                str_sql1 = str_sql1 & " Transaction_Date = @trans_date"
                str_sql1 = str_sql1 & "  Where Loan_ID = " & Session("pay_id")
                str_sql1 = str_sql1 & "  AND Payment_ID = " & Session("payment_id")

                Dim cmd_upd_payment As New SqlCommand
                cmd_upd_payment.CommandText = str_sql1
                cmd_upd_payment.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                cmd_upd_payment.Connection = open_con.return_con
                cmd_upd_payment.ExecuteNonQuery()
                cmd_upd_payment.Dispose()

                Dim strsql As String
                strsql = "SELECT Tbl_Notice.Notice_ID,Loan_ID "
                strsql = strsql & " FROM Tbl_Notice "
                strsql = strsql & " WHERE Tbl_Notice.Payment_ID = " & Session("payment_id")
                Dim cmd_get_noticeid As New SqlCommand
                cmd_get_noticeid.CommandText = strsql
                cmd_get_noticeid.Connection = open_con.return_con
                cmd_get_noticeid.ExecuteNonQuery()
                Dim adap_get_noticeid As New SqlDataAdapter(cmd_get_noticeid)
                Dim ds_get_noticeid As New DataSet
                adap_get_noticeid.Fill(ds_get_noticeid)
                Dim notice_id As Integer
                notice_id = Val(ds_get_noticeid.Tables(0).Rows(0).Item(0).ToString)
                adap_get_noticeid.Dispose()
                ds_get_noticeid.Dispose()
                cmd_get_noticeid.Dispose()

                Dim cmd As New SqlCommand
                If txt_Description = "Arear notice fee" Or txt_Description = "Statement of account fee" Or txt_Description = "Variation fee" Or txt_Description = "Default notice fee" Or txt_Description = "Letter of demand fee" Or txt_Description = "Dishonoured fee" Or txt_Description = "Cencellation fee" Or txt_Description = "Enforcement fee" Then

                    str_SQL = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Notice_NO, Description, Due_Date, Amount, Payment_Method, Transaction_Date, Date_Updated) values "
                    str_SQL = str_SQL & "(" & Session("pay_id") & "," & open_con.customer_id_val & "," & notice_id & ",'" & txt_Description & "',@new_date," & Session("new_amount") & ",'" & Session("pay_method_new") & "',@trans_date,@date_updated)"
                    cmd.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                    cmd.Parameters.Add("@new_date", SqlDbType.DateTime).Value = Session("new_date")
                    cmd.Parameters.Add("@date_updated", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                ElseIf txt_ContractDate <> "" Then
                    str_SQL = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Notice_NO, Due_Date, Amount, Payment_Method, Transaction_Date, Date_Updated, Contract_Date) values "
                    str_SQL = str_SQL & "(" & Session("pay_id") & "," & open_con.customer_id_val & "," & notice_id & ",@new_date," & Session("new_amount") & ",'" & Session("pay_method_new") & "',@trans_date,@trans_date,@contract_date)"
                    cmd.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                    cmd.Parameters.Add("@new_date", SqlDbType.DateTime).Value = Session("new_date")
                    cmd.Parameters.Add("@contract_date", SqlDbType.DateTime).Value = txt_ContractDate
                Else
                    str_SQL = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Notice_NO, Due_Date, Amount, Payment_Method, Transaction_Date, Date_Updated) values "
                    str_SQL = str_SQL & "(" & Session("pay_id") & "," & open_con.customer_id_val & "," & notice_id & ",@new_date," & Session("new_amount") & ",'" & Session("pay_method_new") & "',@trans_date,@trans_date)"
                    cmd.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                    cmd.Parameters.Add("@new_date", SqlDbType.DateTime).Value = Session("new_date")
                End If


                cmd.CommandText = str_SQL
                cmd.Connection = open_con.return_con
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                If Session("enable") = "True" Then

                    Dim txtamt_cncl_var As New TextBox
                    txtamt_cncl_var = Me.FindControl("txtamt_cancel" & Format(Session("count_cncl_var"), "00"))
                    Session("new_amount_var") = txtamt_cncl_var.Text

                    Dim pay_cncl_var As New DropDownList
                    pay_cncl_var = Me.FindControl("paymethod_cancel" & Format(Session("count_cncl_var"), "00"))
                    Session("new_pay_var") = pay_cncl_var.SelectedItem.Text

                    Dim str_SQL_var As String
                    Dim cmd_var As New SqlCommand
                    str_SQL_var = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Notice_NO, Description, Due_Date, Amount, Payment_Method, Transaction_Date, Fee_Status, Date_Updated) values "
                    str_SQL_var = str_SQL_var & "(" & Session("pay_id") & "," & open_con.customer_id_val & "," & notice_id & ",'Variation fee',@new_date_var,@new_amt_var,@new_pay_var,@trans_date,'Variation fee',@trans_date)"
                    cmd_var.CommandText = str_SQL_var
                    cmd_var.Parameters.Add("@new_date_var", SqlDbType.DateTime).Value = Session("new_date_var")
                    cmd_var.Parameters.Add("@new_amt_var", SqlDbType.VarChar, 50).Value = Session("new_amount_var")
                    cmd_var.Parameters.Add("@new_pay_var", SqlDbType.VarChar, 50).Value = Session("new_pay_var")
                    cmd_var.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                    cmd_var.Connection = open_con.return_con
                    cmd_var.ExecuteNonQuery()
                    cmd_var.Dispose()

                ElseIf Session("enable") = "False" Then

                    Dim txtamt_cncl_var As New TextBox
                    txtamt_cncl_var = Me.FindControl("txtamt_cancel" & Format(Session("count_cncl_var"), "00"))
                    Session("new_amount_var") = txtamt_cncl_var.Text

                    Dim pay_cncl_var As New DropDownList
                    pay_cncl_var = Me.FindControl("paymethod_cancel" & Format(Session("count_cncl_var"), "00"))
                    Session("new_pay_var") = pay_cncl_var.SelectedItem.Text

                    Dim str_SQL_var1 As String
                    Dim cmd_var1 As New SqlCommand
                    str_SQL_var1 = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Notice_NO, Description, Due_Date, Amount, Payment_Method, Transaction_Date, Fee_Status, Date_Updated) values "
                    str_SQL_var1 = str_SQL_var1 & "(" & Session("pay_id") & "," & open_con.customer_id_val & "," & notice_id & ",'Variation fee',@new_date_var,@new_amt_var,@new_pay_var,@trans_date,'Variation fee',@trans_date)"
                    cmd_var1.CommandText = str_SQL_var1
                    cmd_var1.Parameters.Add("@new_date_var", SqlDbType.DateTime).Value = Session("new_date_var")
                    cmd_var1.Parameters.Add("@new_amt_var", SqlDbType.VarChar, 50).Value = Session("new_amount_var")
                    cmd_var1.Parameters.Add("@new_pay_var", SqlDbType.VarChar, 50).Value = Session("new_pay_var")
                    cmd_var1.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                    cmd_var1.Connection = open_con.return_con
                    cmd_var1.ExecuteNonQuery()
                    cmd_var1.Dispose()
                End If

                cancel_routine()
                btncncl_save.Visible = False
                btncnl_cncl.Visible = False
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Payment is cancelled and rescheduled, the letter is created." & "');", True)
            Else

            End If
            open_con.return_con.Dispose()

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
            valid_cancel_sch()
        End Try


    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click

        set_panel()
        Try
            Dim j As Integer
            Dim cal_count As Integer = 0
            For j = 0 To Session("count") - 1

                Dim chk As New CheckBox
                If cal_count < 10 Then
                    chk = Me.FindControl("chk" & "0" & j)
                Else
                    chk = Me.FindControl("chk" & j)
                End If
                If chk.Checked = True Then

                    Dim payment_method As New DropDownList
                    If cal_count < 10 Then
                        payment_method = Me.FindControl("drop" & "0" & j)

                    Else
                        payment_method = Me.FindControl("drop" & j)
                    End If
                    Session("payment_method") = payment_method.SelectedItem.Text

                    If payment_method.SelectedItem.Text = "Sal" Then
                        Session("enable") = "True"
                    Else
                        Session("enable") = "False"
                    End If

                    Dim trans_date As New TextBox
                    If cal_count < 10 Then
                        trans_date = Me.FindControl("txttrans_date" & "0" & j)
                    Else
                        trans_date = Me.FindControl("txttrans_date" & j)
                    End If
                    Session("trans_date") = trans_date.Text

                    Dim trans_des As New TextBox
                    If cal_count < 10 Then
                        trans_des = Me.FindControl("txttrans_des" & "0" & j)
                    Else
                        trans_des = Me.FindControl("txttrans_des" & j)
                    End If
                    trans_des.Text = "Cancelled"
                    Session("trans_des") = "Cancelled"

                    Dim txt_amt As TextBox = Me.FindControl("txtamt" & Format(j, "00"))
                    Session("txt_amt") = txt_amt.Text

                    Dim lbl1 As Label = Me.FindControl("lab1" & Format(j, "00"))

                    If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("beg_loan_id")

                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("beg_loan_id")
                    ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("cur_loan_id")
                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("cur_loan_id")
                    ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("beg_loan_id")

                    ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False And Session("beg_status") <> "Declined" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("cur_loan_id")
                    ElseIf Session("beg_status") = "Declined" Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("beg_loan_id")
                    Else
                        If Val(Session("beg_loan_id")) <> 0 Then
                            ds_loan = find_repay(Session("beg_loan_id"))
                            Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                            Session("pay_id") = Session("beg_loan_id")
                        Else
                            ds_loan = find_repay(Session("cur_loan_id"))
                            Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                            Session("pay_id") = Session("cur_loan_id")
                        End If
                    End If



                    '''''''''''''''''''''''''''''''' Providing row nos to upadte for cancel schedule
                    Session("count_cncl") = j
                    Session("count_cncl_dis") = j + 1
                    Session("count_cncl_var") = j + 2
                    cancel_schedule()
                    btncncl_save.Visible = True
                    btncnl_cncl.Visible = True
                    btncncl_save.ForeColor = Drawing.Color.Red
                    btnshow.Visible = False
                    btnacpt.Visible = False
                    btnenfee.Visible = False
                    btnmodsch.Visible = False
                    btnwaive.Visible = False
                    btncancel.Visible = False
                    '''''''''''''''''''''''''''''''''second line
                    btnwaive1.Visible = False
                    btncncl.Visible = False
                    btnenfrc.Visible = False
                    btncncl_enf.Visible = False
                    btncncl_pay.Visible = False
                    btnsave_pay.Visible = False
                    btnmake_dis.Visible = False
                    btncon_dis.Visible = False
                    btnmake_dis.Visible = False
                    btncon_dis.Visible = False

                    Exit For
                Else
                    cal_count = cal_count + 1
                End If

            Next


            If cal_count = Session("count") Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select the payment number you want to cancel!!!" & "');", True)
            Else
            End If

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub
    Sub cancel_schedule()

        txtPaymentAmount.Text = ""
        lblReturn.Visible = False
        lblRetHead.Visible = False
        Dim label_8 As Label = Me.FindControl("lab8" & Format(Session("count_cncl"), "00"))
        label_8.Visible = True

        Dim label_7 As Label = Me.FindControl("lab7" & Format(Session("count_cncl"), "00"))
        label_7.Visible = True

        Dim txttrans_des As TextBox = Me.FindControl("txttrans_des" & Format(Session("count_cncl"), "00"))
        txttrans_des.Visible = True
        txttrans_des.Text = "Cancelled"
        Dim txttrans_date As TextBox = Me.FindControl("txttrans_date" & Format(Session("count_cncl"), "00"))
        txttrans_date.Visible = True

        Dim tbl_cancel As New Table
        tbl_cancel = PlaceHolder1.FindControl("tbl_dynamic")
        tbl_cancel.ID = "tbl_cancel"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim tr_new As New TableRow()
        Dim td_new As New TableCell()

        td_new.Style.Add("border-style", "solid")
        td_new.Style.Add("border-width", "1px")
        td_new.Style.Add(" border-color", "gray")
        tr_new.Style.Add("border-style", "solid")
        tr_new.Style.Add("border-width", "1px")
        tr_new.Style.Add(" border-color", "gray")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_cancel_new As Label = New Label()
        label_cancel_new.Width = "40"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label1_cancel_new As Label = New Label()
        label1_cancel_new.Width = "30"
        ''''''''''''''''''''''''''''''''''''''''''''''
        Dim drop_cancel_new As Label = New Label
        drop_cancel_new.Width = "110"
        drop_cancel_new.Text = ""
        drop_cancel_new.Style.Add("font-size", "12px")
        drop_cancel_new.Style.Add("font-family", "MS Sans Serif")
        drop_cancel_new.Style.Add("font-weight", "bold")
        drop_cancel_new.Style.Add("text-align", "center")
        ''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_check_new As Label = New Label()
        label_check_new.Width = "15"
        ''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtdt_cancel_new As TextBox = New TextBox
        txtdt_cancel_new.ID = "txtdt_cancel_new" & Format(Session("count_cncl"), "00")
        txtdt_cancel_new.Width = "80"
        txtdt_cancel_new.Style.Add("font-size", "12px")
        txtdt_cancel_new.Style.Add("font-family", "MS Sans Serif")
        txtdt_cancel_new.Style.Add("font-weight", "bold")
        txtdt_cancel_new.Style.Add("text-align", "center")
        txtdt_cancel_new.Style.Add("border-color", "gray")
        txtdt_cancel_new.Style.Add("border-style", "solid")
        txtdt_cancel_new.Style.Add("background-color", "red")
        txtdt_cancel_new.Style.Add("border-width", "1px")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label3_new_new As Label = New Label
        label3_new_new.Text = "$"
        label3_new_new.Width = "15"
        label3_new_new.Style.Add("font-size", "12px")
        label3_new_new.Style.Add("font-family", "MS Sans Serif")
        label3_new_new.Style.Add("font-weight", "bold")
        label3_new_new.Style.Add("text-align", "right")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtamt_cancel_new As TextBox = New TextBox
        txtamt_cancel_new.ID = "txtamt_cancel_new" & Format(Session("count_cncl"), "00")
        txtamt_cancel_new.Width = "50"
        txtamt_cancel_new.Style.Add("font-size", "12px")
        txtamt_cancel_new.Style.Add("font-family", "MS Sans Serif")
        txtamt_cancel_new.Style.Add("font-weight", "bold")
        txtamt_cancel_new.Style.Add("text-align", "left")
        txtamt_cancel_new.Style.Add("border-color", "gray")
        txtamt_cancel_new.Style.Add("border-style", "solid")
        txtamt_cancel_new.Style.Add("border-width", "1px")
        txtamt_cancel_new.Style.Add("background-color", "red")
        txtamt_cancel_new.ReadOnly = True
        txtamt_cancel_new.Text = Session("txt_amt")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pay_new_new As LinkButton = New LinkButton
        pay_new_new.Width = "30"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtpaydt_new_new As Label = New Label
        txtpaydt_new_new.Width = "100"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label4_new_new As Label = New Label
        label4_new_new.Width = "20"
        label4_new_new.Text = ""
        '''''''''''''''''''''''''''''''''''''''''''''''''''''


        Dim drop1_cancel_new As DropDownList = New DropDownList
        drop1_cancel_new.ID = "paymethod_cancel_new" & Format(Session("count_cncl"), "00")
        drop1_cancel_new.Width = "90"
        drop1_cancel_new.Style.Add("font-size", "12px")
        drop1_cancel_new.Style.Add("font-family", "MS Sans Serif")
        drop1_cancel_new.Style.Add("font-weight", "bold")
        drop1_cancel_new.Style.Add("text-align", "center")
        drop1_cancel_new.Items.Add("NAB")
        drop1_cancel_new.Items.Add("Cas")
        drop1_cancel_new.Items.Add("Sal")
        drop1_cancel_new.Items.Add("Chq")
        drop1_cancel_new.Items.Add("CBA")
        drop1_cancel_new.Items.Add("Cre")
        drop1_cancel_new.Items.Add("Def")
        drop1_cancel_new.Items.Add("HOD")
        drop1_cancel_new.Items.Add("WOF")
        '  drop1_cancel_new.SelectedItem.Text = Session("payment_method")
        Dim selText As String = Session("payment_method")
        drop1_cancel_new.Items.FindByText(selText).Selected = True
        If Session("enable") = "True" Then
            drop1_cancel_new.SelectedItem.Text = "Sal"
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label6_new_new As Label = New Label
        label6_new_new.Text = ""
        label6_new_new.Width = "40"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ca_new As New CalendarExtender
        ca_new.ID = "ca_new"
        ca_new.Format = "dd-MMM-yyyy"
        ca_new.TargetControlID = txtdt_cancel_new.ID
        ca_new.OnClientShowing = "showDate"
        ca_new.CssClass = "red"
        ca_new.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        td_new.Controls.Add(label_cancel_new)
        td_new.Controls.Add(label1_cancel_new)
        td_new.Controls.Add(drop_cancel_new)
        td_new.Controls.Add(label_check_new)
        td_new.Controls.Add(txtdt_cancel_new)
        td_new.Controls.Add(ca_new)
        td_new.Controls.Add(label3_new_new)
        td_new.Controls.Add(txtamt_cancel_new)
        td_new.Controls.Add(pay_new_new)
        td_new.Controls.Add(txtpaydt_new_new)
        td_new.Controls.Add(label4_new_new)
        td_new.Controls.Add(drop1_cancel_new)
        td_new.Controls.Add(label6_new_new)
        tr_new.Controls.Add(td_new)
        tbl_cancel.Controls.AddAt(Session("count_cncl") + 2, tr_new) 'index so zero based, zero = row 1   
        PlaceHolder1.Controls.Add(tbl_cancel)
        PlaceHolder1.Controls.Add(New LiteralControl("<br>"))

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim tr_dis As New TableRow()
        Dim td_dis As New TableCell()

        td_dis.Style.Add("border-style", "solid")
        td_dis.Style.Add("border-width", "1px")
        td_dis.Style.Add(" border-color", "gray")
        tr_dis.Style.Add("border-style", "solid")
        tr_dis.Style.Add("border-width", "1px")
        tr_dis.Style.Add(" border-color", "gray")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_cancel_dis As Label = New Label()
        label_cancel_dis.Width = "40"
        label_cancel_dis.Style.Add("font-size", "12px")
        label_cancel_dis.Style.Add("font-family", "MS Sans Serif")
        label_cancel_dis.Style.Add("font-weight", "bold")
        label_cancel_dis.Style.Add("text-align", "left")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label1_cancel_dis As Label = New Label()
        label1_cancel_dis.Width = "30"
        label1_cancel_dis.Style.Add("font-size", "12px")
        label1_cancel_dis.Style.Add("font-family", "MS Sans Serif")
        label1_cancel_dis.Style.Add("font-weight", "bold")
        label1_cancel_dis.Style.Add("text-align", "center")

        ''''''''''''''''''''''''''''''''''''''''''''''
        Dim drop_cancel_dis As TextBox = New TextBox
        drop_cancel_dis.Width = "105"
        drop_cancel_dis.Text = "Dishonoured fee"
        drop_cancel_dis.Style.Add("font-size", "12px")
        drop_cancel_dis.Style.Add("font-family", "MS Sans Serif")
        drop_cancel_dis.Style.Add("font-weight", "bold")
        drop_cancel_dis.Style.Add("text-align", "center")
        drop_cancel_dis.ReadOnly = True

        If Session("enable") = "True" Then
            drop_cancel_dis.Enabled = False
        Else
            drop_cancel_dis.Enabled = False
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_check_dis As Label = New Label()
        label_check_dis.Width = "15"
        ''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtdt_cancel_dis As TextBox = New TextBox
        txtdt_cancel_dis.ID = "txtdt_cancel_dis" & Format(Session("count_cncl_dis"), "00")
        txtdt_cancel_dis.Width = "80"
        txtdt_cancel_dis.Style.Add("font-size", "12px")
        txtdt_cancel_dis.Style.Add("font-family", "MS Sans Serif")
        txtdt_cancel_dis.Style.Add("font-weight", "bold")
        txtdt_cancel_dis.Style.Add("text-align", "center")
        txtdt_cancel_dis.Style.Add("border-color", "gray")
        txtdt_cancel_dis.Style.Add("border-style", "solid")
        txtdt_cancel_dis.Style.Add("border-width", "1px")
        txtdt_cancel_dis.Enabled = False
        If Session("enable") = "True" Then
            txtdt_cancel_dis.Enabled = False
        Else
            txtdt_cancel_dis.Enabled = False
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label3_new_dis As Label = New Label
        label3_new_dis.Text = "$"
        label3_new_dis.Width = "15"
        label3_new_dis.Style.Add("font-size", "12px")
        label3_new_dis.Style.Add("font-family", "MS Sans Serif")
        label3_new_dis.Style.Add("font-weight", "bold")
        label3_new_dis.Style.Add("text-align", "right")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtamt_cancel_dis As TextBox = New TextBox
        txtamt_cancel_dis.ID = "txtamt_cancel_dis" & Format(Session("count_cncl_dis"), "00")
        txtamt_cancel_dis.Width = "50"
        txtamt_cancel_dis.Style.Add("font-size", "12px")
        txtamt_cancel_dis.Style.Add("font-family", "MS Sans Serif")
        txtamt_cancel_dis.Style.Add("font-weight", "bold")
        txtamt_cancel_dis.Style.Add("text-align", "left")
        txtamt_cancel_dis.Style.Add("border-color", "gray")
        txtamt_cancel_dis.Style.Add("border-style", "solid")
        txtamt_cancel_dis.Style.Add("border-width", "1px")
        txtamt_cancel_dis.Enabled = False
        If Session("enable") = "True" Then
            txtamt_cancel_dis.Enabled = False
        Else
            txtamt_cancel_dis.Enabled = False
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pay_new_dis As LinkButton = New LinkButton
        pay_new_dis.Width = "30"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtpaydt_new_dis As Label = New Label
        txtpaydt_new_dis.Width = "100"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label4_new_dis As Label = New Label
        label4_new_dis.Width = "20"
        label4_new_dis.Text = ""
        '''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim drop1_cancel_dis As DropDownList = New DropDownList
        drop1_cancel_dis.ID = "paymethod_cancel_dis" & Format(Session("count_cncl_dis"), "00")
        drop1_cancel_dis.Width = "90"
        drop1_cancel_dis.Style.Add("font-size", "12px")
        drop1_cancel_dis.Style.Add("font-family", "MS Sans Serif")
        drop1_cancel_dis.Style.Add("font-weight", "bold")
        drop1_cancel_dis.Style.Add("text-align", "center")
        drop1_cancel_dis.Items.Add("NAB")
        drop1_cancel_dis.Items.Add("Cas")
        drop1_cancel_dis.Items.Add("Sal")
        drop1_cancel_dis.Items.Add("Chq")
        drop1_cancel_dis.Items.Add("CBA")
        drop1_cancel_dis.Items.Add("Cre")
        drop1_cancel_dis.Items.Add("Def")
        drop1_cancel_dis.Items.Add("HOD")
        drop1_cancel_dis.Items.Add("WOF")
        'drop1_cancel_dis.SelectedItem.Text = Session("payment_method")
        Dim selTex1t As String = Session("payment_method")
        drop1_cancel_dis.Items.FindByText(selTex1t).Selected = True
        If Session("enable") = "True" Then
            drop1_cancel_dis.SelectedItem.Text = "Sal"
            drop1_cancel_dis.Enabled = False
        Else
            drop1_cancel_dis.Enabled = False
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label6_new_dis As Label = New Label
        label6_new_dis.Text = ""
        label6_new_dis.Width = "40"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ca_dis As New CalendarExtender
        ca_dis.ID = "ca_dis"
        ca_dis.Format = "dd-MMM-yyyy"
        ca_dis.TargetControlID = txtdt_cancel_dis.ID
        ca_dis.OnClientShowing = "showDate"
        ca_dis.CssClass = "red"
        ca_dis.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday      ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        td_dis.Controls.Add(label_cancel_dis)
        td_dis.Controls.Add(label1_cancel_dis)
        td_dis.Controls.Add(drop_cancel_dis)
        td_dis.Controls.Add(label_check_dis)
        td_dis.Controls.Add(txtdt_cancel_dis)
        td_dis.Controls.Add(ca_dis)
        td_dis.Controls.Add(label3_new_dis)
        td_dis.Controls.Add(txtamt_cancel_dis)
        td_dis.Controls.Add(pay_new_dis)
        td_dis.Controls.Add(txtpaydt_new_dis)
        td_dis.Controls.Add(label4_new_dis)
        td_dis.Controls.Add(drop1_cancel_dis)
        td_dis.Controls.Add(label6_new_dis)
        tr_dis.Controls.Add(td_dis)

        tbl_cancel.Controls.AddAt(Session("count_cncl") + 3, tr_dis) 'index so zero based, zero = row 1   
        PlaceHolder1.Controls.Add(tbl_cancel)
        PlaceHolder1.Controls.Add(New LiteralControl("<br>"))
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tr As New TableRow()
        Dim td As New TableCell()

        td.Style.Add("border-style", "solid")
        td.Style.Add("border-width", "1px")
        td.Style.Add(" border-color", "gray")
        tr.Style.Add("border-style", "solid")
        tr.Style.Add("border-width", "1px")
        tr.Style.Add(" border-color", "gray")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_cancel As Label = New Label()
        label_cancel.Width = "40"
        label_cancel.Style.Add("font-size", "12px")
        label_cancel.Style.Add("font-family", "MS Sans Serif")
        label_cancel.Style.Add("font-weight", "bold")
        label_cancel.Style.Add("text-align", "left")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label1_cancel As Label = New Label()
        label1_cancel.Width = "30"
        label1_cancel.Style.Add("font-size", "12px")
        label1_cancel.Style.Add("font-family", "MS Sans Serif")
        label1_cancel.Style.Add("font-weight", "bold")
        label1_cancel.Style.Add("text-align", "center")

        ''''''''''''''''''''''''''''''''''''''''''''''
        Dim drop_cancel As TextBox = New TextBox
        drop_cancel.Width = "105"
        drop_cancel.Text = "Variation fee"
        drop_cancel.Style.Add("font-size", "12px")
        drop_cancel.Style.Add("font-family", "MS Sans Serif")
        drop_cancel.Style.Add("font-weight", "bold")
        drop_cancel.Style.Add("text-align", "center")
        drop_cancel.ReadOnly = True
        drop_cancel.Style.Add("background-color", "red")
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_check_cancel As Label = New Label()
        label_check_cancel.Width = "13"
        ''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtdt_cancel As TextBox = New TextBox
        txtdt_cancel.ID = "txtdt_cancel" & Format(Session("count_cncl_var"), "00")
        txtdt_cancel.Width = "80"
        txtdt_cancel.Style.Add("font-size", "12px")
        txtdt_cancel.Style.Add("font-family", "MS Sans Serif")
        txtdt_cancel.Style.Add("font-weight", "bold")
        txtdt_cancel.Style.Add("text-align", "center")
        txtdt_cancel.Style.Add("border-color", "gray")
        txtdt_cancel.Style.Add("background-color", "red")
        txtdt_cancel.Style.Add("border-style", "solid")
        txtdt_cancel.Style.Add("border-width", "1px")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label3_new As Label = New Label
        label3_new.Text = "$"
        label3_new.Width = "15"
        label3_new.Style.Add("font-size", "12px")
        label3_new.Style.Add("font-family", "MS Sans Serif")
        label3_new.Style.Add("font-weight", "bold")
        label3_new.Style.Add("text-align", "right")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtamt_cancel As TextBox = New TextBox
        txtamt_cancel.ID = "txtamt_cancel" & Format(Session("count_cncl_var"), "00")
        txtamt_cancel.Width = "50"
        txtamt_cancel.Style.Add("font-size", "12px")
        txtamt_cancel.Style.Add("font-family", "MS Sans Serif")
        txtamt_cancel.Style.Add("font-weight", "bold")
        txtamt_cancel.Style.Add("text-align", "left")
        txtamt_cancel.Style.Add("border-color", "gray")
        txtamt_cancel.Style.Add("border-style", "solid")
        txtamt_cancel.Style.Add("border-width", "1px")
        txtamt_cancel.Style.Add("background-color", "red")
        txtamt_cancel.ReadOnly = False
        If Session("cancel_pay1") < 200 Then
            txtamt_cancel.Text = "25.00"
            Session("cancel_var_fee") = 25
        ElseIf Session("cancel_pay1") = 200 Then
            txtamt_cancel.Text = "25.00"
            Session("cancel_var_fee") = 25
        Else
            txtamt_cancel.Text = "50.00"
            Session("cancel_var_fee") = 50
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pay_new As LinkButton = New LinkButton
        pay_new.Width = "30"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtpaydt_new As Label = New Label
        txtpaydt_new.Width = "100"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label4_new As Label = New Label
        label4_new.Width = "20"
        label4_new.Text = ""

        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim drop1_cancel As DropDownList = New DropDownList
        drop1_cancel.ID = "paymethod_cancel" & Format(Session("count_cncl_var"), "00")
        drop1_cancel.Width = "90"
        drop1_cancel.Style.Add("font-size", "12px")
        drop1_cancel.Style.Add("font-family", "MS Sans Serif")
        drop1_cancel.Style.Add("font-weight", "bold")
        drop1_cancel.Style.Add("text-align", "center")
        drop1_cancel.Items.Add("NAB")
        drop1_cancel.Items.Add("Cas")
        drop1_cancel.Items.Add("Sal")
        drop1_cancel.Items.Add("Chq")
        drop1_cancel.Items.Add("CBA")
        drop1_cancel.Items.Add("Cre")
        drop1_cancel.Items.Add("Def")
        drop1_cancel.Items.Add("HOD")
        drop1_cancel.Items.Add("WOF")

        ' drop1_cancel.SelectedItem.Text = Session("payment_method")
        Dim selText2 As String = Session("payment_method")
        drop1_cancel.Items.FindByText(selText2).Selected = True
        If Session("enable") = "True" Then
            drop1_cancel.SelectedItem.Text = "Sal"
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label6_new As Label = New Label
        label6_new.Text = ""
        label6_new.Width = "40"

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ca As New CalendarExtender
        ca.ID = "ca"
        ca.Format = "dd-MMM-yyyy"
        ca.TargetControlID = txtdt_cancel.ID
        ca.OnClientShowing = "showDate"
        ca.CssClass = "red"
        ca.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        td.Controls.Add(label_cancel)
        td.Controls.Add(label1_cancel)
        td.Controls.Add(drop_cancel)
        td.Controls.Add(label_check_cancel)
        td.Controls.Add(txtdt_cancel)
        td.Controls.Add(ca)
        td.Controls.Add(label3_new)
        td.Controls.Add(txtamt_cancel)
        td.Controls.Add(pay_new)
        td.Controls.Add(txtpaydt_new)
        td.Controls.Add(label4_new)
        td.Controls.Add(drop1_cancel)
        td.Controls.Add(label6_new)
        tr.Controls.Add(td)

        tbl_cancel.Controls.AddAt(Session("count_cncl") + 4, tr) 'index so zero based, zero = row 1   
        PlaceHolder1.Controls.Add(tbl_cancel)
        PlaceHolder1.Controls.Add(New LiteralControl("<br>"))
    End Sub
    Sub cancel_routine()
        set_panel()
        create_controls()
        For i As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
            If ds_loan.Tables(0).Rows(i).Item("Payment_Status").ToString <> "Paid" Then
                Session("enf") = False
            Else
                Session("enf") = True
                Exit For
            End If
        Next
        If Session("enf") = False Then
            show_dis()
            btnmake_dis.Visible = False
            btncon_dis.Visible = False
            btnwaive.Visible = True
            btnacpt.Visible = True
            btncancel.Visible = True
            btnenfee.Visible = True
            btnmodsch.Visible = True
            btnshow.Visible = True

        Else
            show_dis()

        End If

    End Sub
    Protected Sub btnacpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnacpt.Click
        Try

            set_panel()

            If Val(txtPaymentAmount.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter the payment amount !!!" & "');", True)
                txtPaymentAmount.Focus()
                Exit Sub
            ElseIf ddlTeller.SelectedItem.Value = "0" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select Teller No. !!!" & "');", True)
                Exit Sub
            End If

            Dim j As Integer
            Dim cal_count As Integer = 0
            For j = 0 To Session("count") - 1
                If cal_count < 10 Then
                    chk = Me.FindControl("chk" & "0" & j)
                Else
                    chk = Me.FindControl("chk" & j)
                End If
                If chk.Checked = True Then
                    Dim payment_method_acpt As New DropDownList
                    If cal_count < 10 Then
                        payment_method_acpt = Me.FindControl("drop" & "0" & j)
                    Else
                        payment_method_acpt = Me.FindControl("drop" & j)
                    End If
                    Session("acpt_payment_method") = payment_method_acpt.SelectedItem.Text

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If payment_method_acpt.SelectedItem.Text = "Cas" Then
                    ElseIf payment_method_acpt.SelectedItem.Text = "Chq" Then
                    ElseIf payment_method_acpt.SelectedItem.Text = "NAB" Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please change the Payment Method to cash or cheque." & "');", True)
                        txtPaymentAmount.Text = ""
                        lblReturn.Visible = False
                        lblRetHead.Visible = False
                        Exit For
                    ElseIf payment_method_acpt.SelectedItem.Text = "Cre" Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please change the Payment Method to cash or cheque." & "');", True)
                        txtPaymentAmount.Text = ""
                        lblReturn.Visible = False
                        lblRetHead.Visible = False
                        Exit For
                    ElseIf payment_method_acpt.SelectedItem.Text = "Sal" Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please change the Payment Method to cash or cheque." & "');", True)
                        txtPaymentAmount.Text = ""
                        lblReturn.Visible = False
                        lblRetHead.Visible = False
                        Exit For
                    ElseIf payment_method_acpt.SelectedItem.Text = "CBA" Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please change the Payment Method to cash or cheque." & "');", True)
                        txtPaymentAmount.Text = ""
                        lblReturn.Visible = False
                        lblRetHead.Visible = False
                        Exit For
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If cal_count < 10 Then
                        txtamt = Me.FindControl("txtamt" & "0" & j)
                    Else
                        txtamt = Me.FindControl("txtamt" & j)
                    End If
                    Dim amt_balance As Double
                    amt_balance = CDbl(txtamt.Text) - CDbl(txtPaymentAmount.Text)
                    amt_balance = Math.Round(CDbl(amt_balance), 2)
                    Session("Balance") = open_con.newamount(amt_balance)
                    ' txtamt.Text = txtPaymentAmount.Text
                    If amt_balance > 0 Then
                        Session("txtamt") = CDbl(txtPaymentAmount.Text)
                    ElseIf amt_balance = 0 Then
                        Session("txtamt") = txtamt.Text
                    Else
                        Session("txtamt") = txtamt.Text
                    End If
                    'Session("txtamt") = txtamt.Text
                    txtamt.Width = "50"
                    txtamt.Style.Add("text-align", "left")

                    If amt_balance <= -1 Then
                        lblReturn.Text = String.Format(clsGeneral.getDecimalFormat(), Convert.ToDecimal(amt_balance.ToString().Replace("-", "")))
                        lblReturn.Visible = True
                        lblRetHead.Visible = True
                        txtamt.Text = txtamt.Text
                    ElseIf amt_balance = 0 Then
                        txtamt.Text = CDbl(txtPaymentAmount.Text)
                    ElseIf amt_balance > 0 Then
                        txtamt.Text = CDbl(txtPaymentAmount.Text)
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim acpt_due_date As New TextBox
                    If cal_count < 10 Then
                        acpt_due_date = Me.FindControl("txt" & "0" & j)
                    Else
                        acpt_due_date = Me.FindControl("txt" & j)
                    End If
                    acpt_due_date.Style.Add("border-style", "solid")
                    acpt_due_date.Style.Add("border-width", "1px")
                    acpt_due_date.Style.Add(" border-color", "gray")
                    acpt_due_date.Width = "80"
                    acpt_due_date.ReadOnly = True
                    acpt_due_date.Enabled = False
                    Session("due_date_old") = Trim(acpt_due_date.Text)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim lab2_acpt As New Label
                    If cal_count < 10 Then
                        lab2_acpt = Me.FindControl("lab2" & "0" & j)
                    Else
                        lab2_acpt = Me.FindControl("lab2" & j)
                    End If
                    lab2_acpt.Width = "130"

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim paymentdt_acpt As New TextBox
                    If cal_count < 10 Then
                        paymentdt_acpt = Me.FindControl("txtpaydt" & "0" & j)

                    Else
                        paymentdt_acpt = Me.FindControl("txtpaydt" & j)
                    End If

                    paymentdt_acpt.Text = System.DateTime.Now.Date.ToString("dd-MMM-yyyy")
                    paymentdt_acpt.Style.Add("border-style", "solid")
                    paymentdt_acpt.Style.Add("border-width", "1px")
                    paymentdt_acpt.Style.Add(" border-color", "gray")
                    paymentdt_acpt.Width = "95"
                    paymentdt_acpt.ReadOnly = True
                    paymentdt_acpt.Enabled = False
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim pay_acpt_link As New LinkButton
                    If cal_count < 10 Then
                        pay_acpt_link = Me.FindControl("Pay" & "0" & j)

                    Else
                        pay_acpt_link = Me.FindControl("Pay" & j)
                    End If
                    pay_acpt_link.Text = "P"
                    pay_acpt_link.Width = "42"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Session("count_cncl") = j
                    Session("count_cncl_dis") = j + 1

                    ''''''''''''''' if amound exceed then payment ''''''''''''''''
                    If Convert.ToDecimal(Session("Balance")) > 0 Then
                        payment_schedule()
                    End If

                    'If Val(Session("Balance")) = 0 Then
                    '    Dim txtdt_acpt_new As New TextBox
                    '    If cal_count < 10 Then
                    '        txtdt_acpt_new = Me.FindControl("txtdt_acpt_new" & "0" & j)

                    '    Else
                    '        txtdt_acpt_new = Me.FindControl("txtdt_acpt_new" & j)
                    '    End If
                    '    txtdt_acpt_new.Text = System.DateTime.Now.Date
                    '    txtdt_acpt_new.Enabled = False

                    'End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    btnsave_pay.ForeColor = Drawing.Color.Red
                    txtamt.Style.Add("border-style", "solid")
                    txtamt.Style.Add("border-width", "1px")
                    txtamt.Style.Add(" border-color", "gray")
                    txtamt.ReadOnly = True
                    txtamt.Enabled = False
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    btnsave_pay.Visible = True
                    btncncl_pay.Width = "100"
                    btncncl_pay.Visible = True
                    '''''''''''''''''''''''''''''''top line
                    btnshow.Visible = False
                    btnacpt.Visible = False
                    btnenfee.Visible = False
                    btnmodsch.Visible = False
                    btnwaive.Visible = False
                    btncancel.Visible = False
                    '''''''''''''''''''''''''''''''''second line
                    btnwaive1.Visible = False
                    btncncl.Visible = False
                    btnenfrc.Visible = False
                    btncncl_enf.Visible = False
                    btncncl_save.Visible = False
                    btncnl_cncl.Visible = False
                    btnmake_dis.Visible = False
                    btncon_dis.Visible = False
                    Exit For
                Else
                    cal_count = cal_count + 1
                End If

            Next

            If cal_count = Session("count") Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select the payment number you want to accept!!!" & "');", True)
                Exit Sub
            Else
            End If
            txtPaymentAmount.Enabled = True
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try


    End Sub

    Protected Sub btncncl_pay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncncl_pay.Click
        txtPaymentAmount.Text = ""
        lblReturn.Visible = False
        lblRetHead.Visible = False
        txtPaymentAmount.Enabled = True
        btnsave_pay.Visible = False
        btncncl_pay.Visible = False
        cancel_routine()
        set_panel()
    End Sub

    Sub payment_schedule()

        Dim tbl_acpt As New Table
        tbl_acpt = PlaceHolder1.FindControl("tbl_dynamic")
        tbl_acpt.ID = "tbl_acpt"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tr_acpt As New TableRow()
        Dim td_acpt As New TableCell()

        td_acpt.Style.Add("border-style", "solid")
        td_acpt.Style.Add("border-width", "1px")
        td_acpt.Style.Add(" border-color", "gray")
        tr_acpt.Style.Add("border-style", "solid")
        tr_acpt.Style.Add("border-width", "1px")
        tr_acpt.Style.Add(" border-color", "gray")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_acpt_new As Label = New Label()
        label_acpt_new.Width = "30"
        label_acpt_new.Style.Add("font-size", "12px")
        label_acpt_new.Style.Add("font-family", "MS Sans Serif")
        label_acpt_new.Style.Add("font-weight", "bold")
        label_acpt_new.Style.Add("text-align", "left")
        'label_acpt_new.Text = "&nbsp;"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label1_acpt_new As Label = New Label()
        label1_acpt_new.Width = "30"
        label1_acpt_new.Style.Add("font-size", "12px")
        label1_acpt_new.Style.Add("font-family", "MS Sans Serif")
        label1_acpt_new.Style.Add("font-weight", "bold")
        label1_acpt_new.Style.Add("text-align", "center")
        ' label_acpt_new.Text = "&nbsp;"

        ''''''''''''''''''''''''''''''''''''''''''''''
        Dim drop_acpt_new As Label = New Label
        drop_acpt_new.Width = "110"
        drop_acpt_new.Text = ""
        drop_acpt_new.Style.Add("font-size", "12px")
        drop_acpt_new.Style.Add("font-family", "MS Sans Serif")
        drop_acpt_new.Style.Add("font-weight", "bold")
        drop_acpt_new.Style.Add("text-align", "center")
        'label_acpt_new.Text = "Retrun"
        'label_acpt_new.Style.Add("color", "red")
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_check_payment As Label = New Label()
        label_check_payment.Width = "20"

        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtdt_acpt_new As TextBox = New TextBox
        txtdt_acpt_new.ID = "txtdt_acpt_new" & Format(Session("count_cncl"), "00")
        txtdt_acpt_new.Width = "80"
        txtdt_acpt_new.Style.Add("font-size", "12px")
        txtdt_acpt_new.Style.Add("font-family", "MS Sans Serif")
        txtdt_acpt_new.Style.Add("font-weight", "bold")
        txtdt_acpt_new.Style.Add("text-align", "center")
        txtdt_acpt_new.Style.Add("border-color", "gray")
        txtdt_acpt_new.Style.Add("border-style", "solid")
        txtdt_acpt_new.Style.Add("border-width", "1px")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label3_acpt_new As Label = New Label
        label3_acpt_new.Text = "$"
        label3_acpt_new.Width = "20"
        label3_acpt_new.Style.Add("font-size", "12px")
        label3_acpt_new.Style.Add("font-family", "MS Sans Serif")
        label3_acpt_new.Style.Add("font-weight", "bold")
        label3_acpt_new.Style.Add("text-align", "right")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtamt_acpt_new As TextBox = New TextBox
        txtamt_acpt_new.ID = "txtamt_acpt_new" & Format(Session("count_cncl"), "00")
        txtamt_acpt_new.Width = "50"
        txtamt_acpt_new.Style.Add("font-size", "12px")
        txtamt_acpt_new.Style.Add("font-family", "MS Sans Serif")
        txtamt_acpt_new.Style.Add("font-weight", "bold")
        txtamt_acpt_new.Style.Add("text-align", "left")
        txtamt_acpt_new.Style.Add("border-style", "solid")
        txtamt_acpt_new.Style.Add("border-color", "gray")
        txtamt_acpt_new.Style.Add("border-width", "1px")
        txtamt_acpt_new.ReadOnly = True
        txtamt_acpt_new.Enabled = False
        txtamt_acpt_new.Text = Session("Balance")
        Session("txtamt_acpt_new") = txtamt_acpt_new.Text
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pay_acpt_new As LinkButton = New LinkButton
        pay_acpt_new.Width = "30"
        pay_acpt_new.Visible = True
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtpaydt_acpt_new As Label = New Label
        txtpaydt_acpt_new.Width = "100"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label4_acpt_new As Label = New Label
        label4_acpt_new.Width = "20"
        label4_acpt_new.Text = ""

        Dim drop1_acpt_new As DropDownList = New DropDownList
        drop1_acpt_new.ID = "paymethod_acpt_new" & Format(Session("count_cncl"), "00")
        drop1_acpt_new.Width = "90"
        drop1_acpt_new.Style.Add("font-size", "12px")
        drop1_acpt_new.Style.Add("font-family", "MS Sans Serif")
        drop1_acpt_new.Style.Add("font-weight", "bold")
        drop1_acpt_new.Style.Add("text-align", "center")
        drop1_acpt_new.Items.Add("NAB")
        drop1_acpt_new.Items.Add("Cas")
        drop1_acpt_new.Items.Add("Sal")
        drop1_acpt_new.Items.Add("Chq")
        drop1_acpt_new.Items.Add("CBA")
        drop1_acpt_new.Items.Add("Cre")

        ''''''' exceed amound code ****************************
        If Convert.ToDecimal(Session("Balance")) <= -1 Then
            drop1_acpt_new.Visible = False
        End If


        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label6_acpt_new As Label = New Label
        label6_acpt_new.Text = ""
        label6_acpt_new.Width = "40"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ca_acpt As New CalendarExtender
        ca_acpt.ID = "ca_acpt"
        ca_acpt.Format = "dd-MMM-yyyy"
        ca_acpt.TargetControlID = txtdt_acpt_new.ID
        ca_acpt.OnClientShowing = "showDate"
        ca_acpt.CssClass = "red"
        ca_acpt.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
        txtdt_acpt_new.Text = String.Format("{0:dd-MMM-yyyy}", DateAndTime.Now.Date)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        td_acpt.Controls.Add(label_acpt_new)
        td_acpt.Controls.Add(label1_acpt_new)
        td_acpt.Controls.Add(drop_acpt_new)
        td_acpt.Controls.Add(label_check_payment)
        td_acpt.Controls.Add(txtdt_acpt_new)
        td_acpt.Controls.Add(ca_acpt)
        td_acpt.Controls.Add(label3_acpt_new)
        td_acpt.Controls.Add(txtamt_acpt_new)
        td_acpt.Controls.Add(pay_acpt_new)
        td_acpt.Controls.Add(txtpaydt_acpt_new)
        td_acpt.Controls.Add(label4_acpt_new)
        td_acpt.Controls.Add(drop1_acpt_new)
        td_acpt.Controls.Add(label6_acpt_new)
        tr_acpt.Controls.Add(td_acpt)
        '''''''''''''''''''''''next line always starts from +2 , then +3 and so on.....
        tbl_acpt.Controls.AddAt(Session("count_cncl") + 2, tr_acpt) 'index so zero based, zero = row 1   
        PlaceHolder1.Controls.Add(tbl_acpt)
        PlaceHolder1.Controls.Add(New LiteralControl("<br>"))

    End Sub

    Protected Sub btnsave_pay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave_pay.Click
        Try

            Dim txt_acpt_dt_new As New TextBox
            txt_acpt_dt_new = Me.FindControl("txtdt_acpt_new" & Format(Session("count_cncl"), "00"))
            Session("acpt_due_date_new") = Trim(txt_acpt_dt_new.Text)
            If Val(Session("Balance")) = 0 Then
                ''''''''''''''if balance is 0 it will show the cuttent date
                Session("acpt_due_date_new") = System.DateTime.Now.Date.ToString
            End If

            '''''''''''''''checking if textbox is blank and not in valid format
            If Val(Session("acpt_due_date_new")) <> 0 Then

                If txt_acpt_dt_new.Text < System.DateTime.Now.Date Then
                    txt_acpt_dt_new.Focus()
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                    valid_date_pay()
                    Exit Sub
                End If

                Dim drop_acpt_pay_method As New DropDownList
                drop_acpt_pay_method = Me.FindControl("paymethod_acpt_new" & Format(Session("count_cncl"), "00"))
                Session("acpt_pay_method_new") = drop_acpt_pay_method.SelectedItem.Text
            Else
                txt_acpt_dt_new.Focus()
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                valid_date_pay()
                Exit Sub
            End If
            txtPaymentAmount.Enabled = True
            Dim j As Integer
            Dim cal_count As Integer = 0
            For j = 0 To Session("count") - 1

                If cal_count < 10 Then
                    chk = Me.FindControl("chk" & "0" & j)
                    lab4 = Me.FindControl("lab4" & "0" & j)
                    lab2 = Me.FindControl("lab2" & "0" & j)
                    lab6 = Me.FindControl("lab6" & "0" & j)
                Else
                    chk = Me.FindControl("chk" & j)
                    lab4 = Me.FindControl("lab4" & j)
                    lab2 = Me.FindControl("lab2" & j)
                    lab6 = Me.FindControl("lab6" & j)
                End If

                If chk.Checked = True Then
                    Dim cmd_acpt As New SqlCommand
                    Dim str_SQL_acpt As String
                    str_SQL_acpt = "Update Tbl_Payment set "
                    str_SQL_acpt = str_SQL_acpt & " Amount = " & Session("txtamt") & ","
                    str_SQL_acpt = str_SQL_acpt & " Payment_Status = 'Paid', "
                    str_SQL_acpt = str_SQL_acpt & " Payment_Date  = @Payment_Date,"
                    str_SQL_acpt = str_SQL_acpt & " Payment_Method = '" & Session("acpt_payment_method") & "',"
                    str_SQL_acpt = str_SQL_acpt & " User_ID = " & open_con.user_id_val & ","
                    'str_SQL_acpt = str_SQL_acpt & " User_Machine_ID = '" & Request.ServerVariables("REMOTE_ADDR") & "',"
                    str_SQL_acpt = str_SQL_acpt & " User_Machine_ID = '" & ddlTeller.SelectedItem.Text & "',"
                    str_SQL_acpt = str_SQL_acpt & " Transaction_Date=@Transaction_Date,"
                    str_SQL_acpt = str_SQL_acpt & " Transaction_Time =@Transaction_Time"
                    str_SQL_acpt = str_SQL_acpt & " WHERE Payment_ID = " & lab4.Text
                    cmd_acpt.Parameters.Add("@Payment_Date", SqlDbType.Date).Value = System.DateTime.Now.Date.ToString
                    cmd_acpt.Parameters.Add("@Transaction_Date", SqlDbType.Date).Value = System.DateTime.Now.Date.ToString
                    cmd_acpt.Parameters.Add("@Transaction_Time", SqlDbType.DateTime).Value = System.DateTime.Now.ToString
                    cmd_acpt.CommandText = str_SQL_acpt
                    cmd_acpt.Connection = open_con.return_con
                    cmd_acpt.ExecuteNonQuery()

                    cmd_acpt.Dispose()

                    ''''''''''''''''''''''''''''''
                    If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

                        loan_id_new = Session("beg_loan_id")

                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                        loan_id_new = Session("beg_loan_id")

                    ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                        loan_id_new = Session("cur_loan_id")

                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                        loan_id_new = Session("cur_loan_id")
                    ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                        loan_id_new = Session("beg_loan_id")


                    ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False And Session("beg_status") <> "Declined" Then

                        loan_id_new = Session("cur_loan_id")
                    ElseIf Session("beg_status") = "Declined" Then
                        loan_id_new = Session("beg_loan_id")
                    Else
                        If Val(Session("beg_loan_id")) <> 0 Then
                            loan_id_new = Session("beg_loan_id")
                        Else
                            loan_id_new = Session("cur_loan_id")
                        End If
                    End If



                    If Session("acpt_due_date_new") <> "" And Session("txtamt_acpt_new") <> "" Then
                        Dim amt As Decimal = Decimal.Parse(Session("txtamt_acpt_new"))
                        If amt <= -1 Then
                            Exit For
                        End If
                        Dim cmd_acpt_new As New SqlCommand
                        Dim str_SQL_acpt_new As String
                        str_SQL_acpt_new = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Description, Due_Date, Amount, "
                        If lab6.Text <> "" Then
                            str_SQL_acpt_new = str_SQL_acpt_new & "Contract_Date, "
                        End If
                        str_SQL_acpt_new = str_SQL_acpt_new & " Payment_Method,  Date_Updated) values( "
                        str_SQL_acpt_new = str_SQL_acpt_new & loan_id_new & "," & open_con.customer_id_val & ",'" & lab2.Text & "',@Due_Date," & Session("txtamt_acpt_new") & ","

                        If lab6.Text <> "" Then
                            str_SQL_acpt_new = str_SQL_acpt_new & CDate(lab6.Text) & ","
                        End If

                        str_SQL_acpt_new = str_SQL_acpt_new & "'" & Session("acpt_pay_method_new") & "',@Date_Updated)"
                        cmd_acpt_new.Parameters.Add("@Due_Date", SqlDbType.Date).Value = CDate(Session("acpt_due_date_new"))
                        cmd_acpt_new.Parameters.Add("@Date_Updated", SqlDbType.Date).Value = System.DateTime.Now.Date
                        cmd_acpt_new.CommandText = str_SQL_acpt_new
                        cmd_acpt_new.Connection = open_con.return_con
                        cmd_acpt_new.ExecuteNonQuery()
                        cmd_acpt_new.Dispose()

                    End If
                    cal_count = cal_count + 1
                Else
                    cal_count = cal_count + 1
                End If

            Next
            txtPaymentAmount.Text = ""
            lblReturn.Visible = False
            lblRetHead.Visible = False
            out_come(loan_id_new)
            create_controls()
            If ds_loan.Tables(0).Rows.Count = 0 Then
                Session("enf") = True
            End If
            For i As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
                If ds_loan.Tables(0).Rows(i).Item("Payment_Status").ToString <> "Paid" Then
                    Session("enf") = False
                    Exit For
                Else
                    Session("enf") = True
                End If
            Next
            If Session("enf") = False Then
                btnwaive.Visible = True
                btnacpt.Visible = True
                btncancel.Visible = True
                btnenfee.Visible = True
                btnmodsch.Visible = True
                btnshow.Visible = True
                btncncl_pay.Visible = False
                btnsave_pay.Visible = False
                ds_loan.Dispose()
                open_con.return_con.Dispose()
            Else
                show_dis()
                btnsave_pay.Visible = False
                btncncl_pay.Visible = False
                btnshow.Visible = False
                btnwaive1.Visible = False
                btncncl.Visible = False
                btnwaive.Visible = False
                btnacpt.Visible = False
                btncancel.Visible = False
                btnenfee.Visible = True
                btnmodsch.Visible = False
                ds_loan.Dispose()
                open_con.return_con.Dispose()
            End If
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
            valid_date_pay()
        End Try


    End Sub

    Protected Sub btnshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnshow.Click
        Try

            set_panel()
            If btnshow.Text = "Show" Then


                If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

                    ds_loan = open_con.calculate_loan_repay_show(Session("beg_loan_id"))
                    For i As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
                        If ds_loan.Tables(0).Rows(i).Item(7).ToString = "Paid" Then
                            show_loan_repay(ds_loan)
                            show_dis()
                            btnshow.Text = "Hide"
                            Session("vis_status") = 1
                            Exit Sub
                        End If
                    Next

                ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then

                    ds_loan = open_con.calculate_loan_repay_show(Session("beg_loan_id"))
                    For i As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
                        If ds_loan.Tables(0).Rows(i).Item(7).ToString = "Paid" Then
                            show_dis()
                            show_loan_repay(ds_loan)
                            btnshow.Text = "Hide"
                            Session("vis_status") = 1
                            Exit Sub
                        End If
                    Next

                ElseIf Session("flag_approve") = True Then

                    ds_loan = open_con.calculate_loan_repay_show(Session("cur_loan_id"))
                    For i As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
                        If ds_loan.Tables(0).Rows(i).Item(7).ToString = "Paid" Then
                            show_dis()
                            show_loan_repay(ds_loan)
                            btnshow.Text = "Hide"
                            Session("vis_status") = 1
                            Exit Sub
                        End If
                    Next
                End If

            End If

            If btnshow.Text = "Hide" Then

                If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
                    ds_loan = open_con.calculate_loan_repay(Session("beg_loan_id"))
                    show_loan_repay(ds_loan)

                ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then

                    ds_loan = open_con.calculate_loan_repay(Session("beg_loan_id"))
                    show_loan_repay(ds_loan)

                ElseIf Session("flag_approve") = True Then

                    ds_loan = open_con.calculate_loan_repay(Session("cur_loan_id"))
                    show_loan_repay(ds_loan)

                End If


                If Session("beg_status") = "Declined" Then
                Else
                    If Session("user_type") = "Admin" And Session("beg_status") <> "" Then
                        If Session("beg_status") <> "Pending" And Session("status") <> "1" Then

                            If ds_loan.Tables(0).Rows.Count = 0 Then
                                Session("enf") = True
                            End If
                            For i As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
                                If ds_loan.Tables(0).Rows(i).Item("Payment_Status").ToString <> "Paid" Then
                                    Session("enf") = False
                                    Exit For
                                Else
                                    Session("enf") = True
                                End If
                            Next
                            If Session("enf") = False Then
                                btnwaive.Visible = True
                                btnacpt.Visible = True
                                btncancel.Visible = True
                                btnenfee.Visible = True
                                btnmodsch.Visible = True
                                btnshow.Visible = True
                                btnmake_dis.Visible = False
                                btncon_dis.Visible = False
                            Else
                                If ds_loan.Tables(0).Rows.Count = 0 Then
                                Else
                                    show_dis()
                                End If
                                btnsave_pay.Visible = False
                                btncncl_pay.Visible = False
                                btnshow.Visible = False
                                btnwaive1.Visible = False
                                btncncl.Visible = False
                                btnwaive.Visible = False
                                btnacpt.Visible = False
                                btncancel.Visible = False
                                btnenfee.Visible = True
                                btnmodsch.Visible = False
                            End If
                        Else
                        End If
                    Else
                    End If
                End If

                btnshow.Text = "Show"
                Session("vis_status") = 0
                Exit Sub
            End If

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub

    Function find_repay(ByVal cust_id As Integer) As DataSet
        Dim ds_loan_new As New DataSet
        Dim vis_status As String
        vis_status = Session("vis_status")
        Try
            If Page.IsPostBack = False Then
                If Val(vis_status) = 0 Then
                    ds_loan_new = open_con.calculate_loan_repay(cust_id)
                    show_loan_repay(ds_loan_new)
                    Session("vis_status") = 0
                    btnshow.Text = "Show"
                    Return ds_loan_new



                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf Session("vis_status") = 1 Then

                    ds_loan_new = open_con.calculate_loan_repay_show(cust_id)
                    show_loan_repay(ds_loan_new)
                    btnshow.Text = "Hide"
                    Return ds_loan_new
                ElseIf Val(vis_status) = 0 Then
                    ds_loan_new = open_con.calculate_loan_repay(cust_id)
                    show_loan_repay(ds_loan_new)
                    Session("vis_status") = 0
                    btnshow.Text = "Show"
                    Return ds_loan_new
                End If
            Else
                If Val(vis_status) = 0 Then
                    ds_loan_new = open_con.calculate_loan_repay(cust_id)
                    show_loan_repay(ds_loan_new)
                    btnshow.Text = "Show"
                    Session("vis_status") = 0
                    Return ds_loan_new



                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf Session("vis_status") = 1 Then

                    ds_loan_new = open_con.calculate_loan_repay_show(cust_id)
                    show_loan_repay(ds_loan_new)
                    btnshow.Text = "Hide"
                    Return ds_loan_new
                ElseIf Val(vis_status) = 0 Then
                    ds_loan_new = open_con.calculate_loan_repay(cust_id)
                    show_loan_repay(ds_loan_new)
                    Session("vis_status") = 0
                    btnshow.Text = "Show"
                    Return ds_loan_new
                End If
            End If

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
        Return ds_loan_new
    End Function

    Protected Sub btnmodsch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmodsch.Click
        Session("count_chk") = 0
        Session("old_amt_new") = 0
        Session("cal_count_new") = 0
        Session("c_count") = 1
        'Drppayfreq.Enabled = True


        If btnshow.Text = "Hide" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Hide the paid payments to proceed !!!" & "');", True)
            Exit Sub
        End If
        Try
            Session("tot_SinglePayment") = 0
            Session("txtamt_mod_new1") = 0
            set_panel()

            If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
                loan_id_new = Session("beg_loan_id")

            ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                 loan_id_new = Session("beg_loan_id")

            ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                loan_id_new = Session("cur_loan_id")
            ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                loan_id_new = Session("cur_loan_id")
            ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

               loan_id_new = Session("beg_loan_id")

            ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False And Session("beg_status") <> "Declined" Then

                loan_id_new = Session("cur_loan_id")
            ElseIf Session("beg_status") = "Declined" Then
                loan_id_new = Session("beg_loan_id")
            Else

                If Val(Session("beg_loan_id")) <> 0 Then
                    loan_id_new = Session("beg_loan_id")
                Else
                    loan_id_new = Session("cur_loan_id")
                End If
            End If


         
            Dim cal_countchk As Integer = 0
            Dim cal_new As Integer = 0
            For i As Integer = 0 To Session("count") - 1

                If cal_new < 10 Then
                    chk = Me.FindControl("chk" & "0" & i)
                Else
                    chk = Me.FindControl("chk" & i)
                End If
                If chk.Checked = True Then

                    If cal_new < 10 Then
                        txtamt = Me.FindControl("txtamt" & "0" & i)
                    Else
                        txtamt = Me.FindControl("txtamt" & i)
                    End If
                  
                    Session("txtamt_mod_new1") = CDbl(Session("txtamt_mod_new1")) + CDbl(txtamt.Text)

                    cal_countchk = cal_countchk + 1
                    cal_new = cal_new + 1

                Else
                    cal_new = cal_new + 1
                End If

            Next
            Session("count_cncl") = cal_countchk


            If cal_countchk > 1 And Val(txtaddpaymnt.Text) <> 0 Then
                Dim j As Integer
                Dim count_new As Integer = 0
                Dim cal_count As Integer = 0
                For j = 0 To Session("count") - 1


                    If cal_count < 10 Then
                        chk = Me.FindControl("chk" & "0" & j)
                    Else
                        chk = Me.FindControl("chk" & j)
                    End If
                    ''''''''''''''''''this is show_loan_repay pay method 
                    If chk.Checked = True Then
                        Dim payment_method_acpt As New DropDownList
                        If cal_count < 10 Then
                            payment_method_acpt = Me.FindControl("drop" & "0" & j)
                            payment_method_acpt.Enabled = True
                        Else
                            payment_method_acpt = Me.FindControl("drop" & j)
                            payment_method_acpt.Enabled = True
                        End If

                        payment_method_acpt.Width = "90"
                        payment_method_acpt.Style.Add("font-size", "12px")
                        payment_method_acpt.Style.Add("font-family", "MS Sans Serif")
                        payment_method_acpt.Style.Add("font-weight", "bold")
                        payment_method_acpt.Style.Add("text-align", "center")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ''''''''''''''''''this is show_loan_repay amount
                        If cal_count < 10 Then
                            txtamt = Me.FindControl("txtamt" & "0" & j)
                        Else
                            txtamt = Me.FindControl("txtamt" & j)
                        End If
                        txtamt.Style.Add("border-style", "solid")
                        txtamt.Style.Add("border-width", "1px")
                        txtamt.Style.Add(" border-color", "gray")
                        txtamt.Width = "50"
                        Session("txtamt_mod") = txtamt.Text
                        txtamt.ReadOnly = False
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ''''''''''''''''this is show_loan_repay calendar
                        Dim ca_loan_mod As New CalendarExtender
                        If cal_count < 10 Then
                            ca_loan_mod = Me.FindControl("ca_loan" & "0" & j)
                        Else
                            ca_loan_mod = Me.FindControl("ca_loan" & j)
                        End If
                        ca_loan_mod.Enabled = True
                        ca_loan_mod.Format = "dd-MMM-yyyy"
                        ca_loan_mod.CssClass = "red"
                        ca_loan_mod.OnClientShowing = "showDate"
                        ca_loan_mod.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
                        ''
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ''''''''''''''''''this is show_loan_repay date 
                        Dim acpt_due_date As New TextBox
                        If cal_count < 10 Then
                            acpt_due_date = Me.FindControl("txt" & "0" & j)
                        Else
                            acpt_due_date = Me.FindControl("txt" & j)
                        End If

                        acpt_due_date.Style.Add("border-style", "solid")
                        acpt_due_date.Style.Add("border-width", "1px")
                        acpt_due_date.Style.Add(" border-color", "gray")
                        acpt_due_date.Width = "100"
                        acpt_due_date.ReadOnly = False

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim ca_mod As New CalendarExtender

                        If cal_count < 10 Then
                            ca_mod = Me.FindControl("ca_repay" & "0" & j)
                        Else

                            ca_mod = Me.FindControl("ca_repay" & j)
                        End If
                        'ca_mod.CssClass = "red"
                        'ca_mod.OnClientShowing = "showDate"
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim lab2_acpt As New Label
                        If cal_count < 10 Then
                            lab2_acpt = Me.FindControl("lab2" & "0" & j)
                        Else
                            lab2_acpt = Me.FindControl("lab2" & j)
                        End If
                        lab2_acpt.Width = "130"

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim paymentdt_acpt As New TextBox
                        If cal_count < 10 Then
                            paymentdt_acpt = Me.FindControl("txtpaydt" & "0" & j)

                        Else
                            paymentdt_acpt = Me.FindControl("txtpaydt" & j)
                        End If
                        paymentdt_acpt.Text = ""
                        paymentdt_acpt.Width = "90"
                        paymentdt_acpt.Enabled = True
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim pay_acpt_link As New LinkButton
                        If cal_count < 10 Then
                            pay_acpt_link = Me.FindControl("Pay" & "0" & j)

                        Else
                            pay_acpt_link = Me.FindControl("Pay" & j)
                        End If
                        pay_acpt_link.Width = "50"

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        btnsave_mod.ForeColor = Drawing.Color.Red
                        btnsave_mod.Visible = True
                        btncncl_mod.Visible = True
                        '''''''''''''''''''''''''''''''top line
                        btncncl_pay.Visible = False
                        btnsave_pay.Visible = False
                        btnshow.Visible = False
                        btnacpt.Visible = False
                        btnenfee.Visible = False
                        btnmodsch.Visible = False
                        btnwaive.Visible = False
                        btncancel.Visible = False

                        '''''''''''''''''''''''''''''''''second line
                        btnwaive1.Visible = False
                        btncncl.Visible = False
                        btnenfrc.Visible = False
                        btncncl_enf.Visible = False
                        btncncl_save.Visible = False
                        btncnl_cncl.Visible = False
                        btnmake_dis.Visible = False
                        btncon_dis.Visible = False


                        cal_count = cal_count + 1

                        count_new = count_new + 1

                        Session("more_payment") = 1

                        ' this is if we want to modify one payment only
                        ' Exit For

                    Else
                        cal_count = cal_count + 1
                    End If

                Next
                Session("count_cncl") = count_new
                modify_schedule()
                Session("count_new") = count_new + Val(txtaddpaymnt.Text)



            Else
                Dim j As Integer
                Dim count_new As Integer = 0
                Dim cal_count As Integer = 0
                For j = 0 To Session("count") - 1

                    If cal_count < 10 Then
                        chk = Me.FindControl("chk" & "0" & j)
                    Else
                        chk = Me.FindControl("chk" & j)
                    End If
                    ''''''''''''''''''this is show_loan_repay pay method 
                    If chk.Checked = True Then
                        Dim payment_method_acpt As New DropDownList
                        If cal_count < 10 Then
                            payment_method_acpt = Me.FindControl("drop" & "0" & j)
                            payment_method_acpt.Enabled = True
                        Else
                            payment_method_acpt = Me.FindControl("drop" & j)
                            payment_method_acpt.Enabled = True
                        End If

                        payment_method_acpt.Width = "90"
                        payment_method_acpt.Style.Add("font-size", "12px")
                        payment_method_acpt.Style.Add("font-family", "MS Sans Serif")
                        payment_method_acpt.Style.Add("font-weight", "bold")
                        payment_method_acpt.Style.Add("text-align", "center")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ''''''''''''''''''this is show_loan_repay amount
                        If cal_count < 10 Then
                            txtamt = Me.FindControl("txtamt" & "0" & j)
                        Else
                            txtamt = Me.FindControl("txtamt" & j)
                        End If
                        txtamt.Style.Add("border-style", "solid")
                        txtamt.Style.Add("border-width", "1px")
                        txtamt.Style.Add(" border-color", "gray")
                        txtamt.Width = "50"
                        Session("txtamt_mod") = txtamt.Text
                        txtamt.ReadOnly = False
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ''''''''''''''''this is show_loan_repay calendar
                        Dim ca_loan_mod As New CalendarExtender
                        If cal_count < 10 Then
                            ca_loan_mod = Me.FindControl("ca_loan" & "0" & j)
                        Else
                            ca_loan_mod = Me.FindControl("ca_loan" & j)
                        End If
                        ca_loan_mod.Enabled = True
                        ca_loan_mod.Format = "dd-MMM-yyyy"
                        ca_loan_mod.CssClass = "red"
                        ca_loan_mod.OnClientShowing = "showDate"
                        ca_loan_mod.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ''''''''''''''''''this is show_loan_repay date 
                        Dim acpt_due_date As New TextBox
                        If cal_count < 10 Then
                            acpt_due_date = Me.FindControl("txt" & "0" & j)
                        Else
                            acpt_due_date = Me.FindControl("txt" & j)
                        End If

                        acpt_due_date.Style.Add("border-style", "solid")
                        acpt_due_date.Style.Add("border-width", "1px")
                        acpt_due_date.Style.Add(" border-color", "gray")
                        acpt_due_date.Width = "100"
                        acpt_due_date.ReadOnly = False

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim ca_mod As New CalendarExtender

                        If cal_count < 10 Then
                            ca_mod = Me.FindControl("ca_repay" & "0" & j)
                        Else

                            ca_mod = Me.FindControl("ca_repay" & j)
                        End If
           
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim lab2_acpt As New Label
                        If cal_count < 10 Then
                            lab2_acpt = Me.FindControl("lab2" & "0" & j)
                        Else
                            lab2_acpt = Me.FindControl("lab2" & j)
                        End If
                        lab2_acpt.Width = "130"

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim paymentdt_acpt As New TextBox
                        If cal_count < 10 Then
                            paymentdt_acpt = Me.FindControl("txtpaydt" & "0" & j)

                        Else
                            paymentdt_acpt = Me.FindControl("txtpaydt" & j)
                        End If
                        paymentdt_acpt.Text = ""
                        paymentdt_acpt.Width = "90"
                        paymentdt_acpt.Enabled = True
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim pay_acpt_link As New LinkButton
                        If cal_count < 10 Then
                            pay_acpt_link = Me.FindControl("Pay" & "0" & j)

                        Else
                            pay_acpt_link = Me.FindControl("Pay" & j)
                        End If
                        pay_acpt_link.Width = "50"

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        btnsave_mod.ForeColor = Drawing.Color.Red
                        btnsave_mod.Visible = True
                        btncncl_mod.Visible = True
                        '''''''''''''''''''''''''''''''top line
                        btncncl_pay.Visible = False
                        btnsave_pay.Visible = False
                        btnshow.Visible = False
                        btnacpt.Visible = False
                        btnenfee.Visible = False
                        btnmodsch.Visible = False
                        btnwaive.Visible = False
                        btncancel.Visible = False

                        '''''''''''''''''''''''''''''''''second line
                        btnwaive1.Visible = False
                        btncncl.Visible = False
                        btnenfrc.Visible = False
                        btncncl_enf.Visible = False
                        btncncl_save.Visible = False
                        btncnl_cncl.Visible = False
                        btnmake_dis.Visible = False
                        btncon_dis.Visible = False

                        Session("count_cncl") = j
                        modify_schedule()
                        cal_count = cal_count + 1

                        count_new = count_new + 1

                        Session("more_payment") = 1

                        ' this is if we want to modify one payment only
                        ' Exit For

                    Else
                        cal_count = cal_count + 1
                    End If

                Next



            End If



            Session("c_count") = 0


        Catch ex As Exception
            Response.Write("Error: " & ex.Message)

        End Try
    End Sub

    Protected Sub btncncl_mod_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncncl_mod.Click

        Session("tot_SinglePayment") = 0
        Session("tot_SinglePayment_new") = 0
        txtaddpaymnt.Text = ""
        txtPaymentAmount.Text = ""
        lblReturn.Visible = False
        lblRetHead.Visible = False
        btnsave_mod.Visible = False
        btncncl_mod.Visible = False
        cancel_routine()
        set_panel()
    End Sub
    Sub modify_schedule()


        If Val(txtaddpaymnt.Text) = 0 Then
            Session("tot_SinglePayment") = 0
            Session("old_amt_new") = 0

            Dim tbl_mod As New Table
            If Session("more_payment") = 0 Then
                tbl_mod = PlaceHolder1.FindControl("tbl_dynamic")
                tbl_mod.ID = "tbl_mod"
            End If
            Dim txtamt_mod_old As New TextBox
            txtamt_mod_old = Me.FindControl("txtamt" & Format(Session("count_cncl"), "00"))
            txtamt_mod_old.ReadOnly = False
            txtamt_mod_old.Enabled = True
            Dim dt_mod_old As New TextBox
            dt_mod_old = Me.FindControl("txt" & Format(Session("count_cncl"), "00"))
            dt_mod_old.ReadOnly = False
            dt_mod_old.Enabled = True
            Dim payment_mod_old As New DropDownList
            payment_mod_old = Me.FindControl("drop" & Format(Session("count_cncl"), "00"))
            payment_mod_old.Style.Add("font-size", "12px")
            payment_mod_old.Style.Add("font-family", "MS Sans Serif")
            payment_mod_old.Style.Add("font-weight", "bold")
            payment_mod_old.Style.Add("text-align", "center")
            payment_mod_old.Items.Add("NAB")
            payment_mod_old.Items.Add("Cas")
            payment_mod_old.Items.Add("Sal")
            payment_mod_old.Items.Add("Chq")
            payment_mod_old.Items.Add("CBA")
            payment_mod_old.Items.Add("Cre")
            payment_mod_old.Items.Add("Def")
            payment_mod_old.Items.Add("HOD")
            payment_mod_old.Items.Add("WOF")
       
            Dim cal_count As Integer = 0
            For i As Integer = 0 To Session("count") - 1

                If cal_count < 10 Then
                    chk = Me.FindControl("chk" & "0" & i)
                Else
                    chk = Me.FindControl("chk" & i)
                End If
                If chk.Checked = True Then

                    ''''''''''''''''''these are the show_loan_repay date and amount
                    Dim txtamt_mod_old1 As New TextBox
                    txtamt_mod_old1 = Me.FindControl("txtamt" & Format(i, "00"))
                    Session("tot_SinglePayment") = CDbl(Session("tot_SinglePayment")) + CDbl(txtamt_mod_old1.Text)
                    Dim payment_mod_old1 As New DropDownList
                    payment_mod_old1 = Me.FindControl("drop" & Format(i, "00"))
                    cal_count = cal_count + 1
                Else
                    cal_count = cal_count + 1
                End If
            Next

            If Session("c_count") = 1 Then
                Session("old_amt_new") = CDbl(Session("old_amt_new")) + CDbl(Session("tot_SinglePayment"))

            End If



        Else

            '''''''''''''''''''''''''''''
            Dim cal_count As Integer = 0
            Dim count_again As Integer = 0
            For i As Integer = 0 To Session("count") - 1

                If cal_count < 10 Then
                    chk = Me.FindControl("chk" & "0" & i)
                Else
                    chk = Me.FindControl("chk" & i)
                End If
                If chk.Checked = True Then

                    count_again = count_again + 1
                    cal_count = cal_count + 1
                Else
                    cal_count = cal_count + 1
                End If
            Next
            If count_again = 1 Then
                Session("cal_count_new") = 1
            End If



            If Session("cal_count_new") = 1 Then





                ''''''''''''''''''''''''''''''''

                Dim tbl_mod As New Table
                tbl_mod = PlaceHolder1.FindControl("tbl_dynamic")
                tbl_mod.ID = "tbl_mod"

                Dim txtamt_mod_old As New TextBox
                txtamt_mod_old = Me.FindControl("txtamt" & Format(Session("count_cncl"), "00"))
                txtamt_mod_old.ReadOnly = False
                txtamt_mod_old.Enabled = True
                txtamt_mod_old.Width = "50"
                Dim dt_mod_old As New TextBox
                dt_mod_old = Me.FindControl("txt" & Format(Session("count_cncl"), "00"))
                dt_mod_old.ReadOnly = False
                dt_mod_old.Enabled = True
                dt_mod_old.Width = "80"
                Dim payment_mod_old As New DropDownList
                payment_mod_old = Me.FindControl("drop" & Format(Session("count_cncl"), "00"))
                payment_mod_old.Style.Add("font-size", "12px")
                payment_mod_old.Style.Add("font-family", "MS Sans Serif")
                payment_mod_old.Style.Add("font-weight", "bold")
                payment_mod_old.Style.Add("text-align", "center")
                payment_mod_old.Items.Add("NAB")
                payment_mod_old.Items.Add("Cas")
                payment_mod_old.Items.Add("Sal")
                payment_mod_old.Items.Add("Chq")
                payment_mod_old.Items.Add("CBA")
                payment_mod_old.Items.Add("Cre")
                payment_mod_old.Items.Add("Def")
                payment_mod_old.Items.Add("HOD")
                payment_mod_old.Items.Add("WOF")
                For i As Integer = 1 To Val(txtaddpaymnt.Text) + 1
                    Dim tr_mod As New TableRow()
                    Dim td_mod As New TableCell()

                    td_mod.Style.Add("border-style", "solid")
                    td_mod.Style.Add("border-width", "1px")
                    td_mod.Style.Add(" border-color", "gray")
                    tr_mod.Style.Add("border-style", "solid")
                    tr_mod.Style.Add("border-width", "1px")
                    tr_mod.Style.Add(" border-color", "gray")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim label_mod_new As Label = New Label()
                    label_mod_new.Width = "35"
                    label_mod_new.Style.Add("font-size", "12px")
                    label_mod_new.Style.Add("font-family", "MS Sans Serif")
                    label_mod_new.Style.Add("font-weight", "bold")
                    label_mod_new.Style.Add("text-align", "center")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim label1_mod_new As Label = New Label()
                    label1_mod_new.Width = "30"
                    label1_mod_new.Style.Add("font-size", "12px")
                    label1_mod_new.Style.Add("font-family", "MS Sans Serif")
                    label1_mod_new.Style.Add("font-weight", "bold")
                    label1_mod_new.Style.Add("text-align", "center")

                    ''''''''''''''''''''''''''''''''''''''''''''''
                    Dim drop_mod_new As Label = New Label
                    drop_mod_new.Width = "130"
                    drop_mod_new.Text = ""
                    drop_mod_new.Style.Add("font-size", "12px")
                    drop_mod_new.Style.Add("font-family", "MS Sans Serif")
                    drop_mod_new.Style.Add("font-weight", "bold")
                    drop_mod_new.Style.Add("text-align", "center")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim txtdt_mod_new As TextBox = New TextBox
                    txtdt_mod_new.ID = "txtdt_mod_new" & Format(i, "00")
                    txtdt_mod_new.Width = "80"
                    txtdt_mod_new.Style.Add("font-size", "12px")
                    txtdt_mod_new.Style.Add("font-family", "MS Sans Serif")
                    txtdt_mod_new.Style.Add("font-weight", "bold")
                    txtdt_mod_new.Style.Add("text-align", "center")
                    txtdt_mod_new.Style.Add("border-color", "gray")
                    txtdt_mod_new.Style.Add("border-style", "solid")
                    txtdt_mod_new.Style.Add("border-width", "1px")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim label3_mod_new As Label = New Label
                    label3_mod_new.Text = "$"
                    label3_mod_new.Width = "15"
                    label3_mod_new.Style.Add("font-size", "12px")
                    label3_mod_new.Style.Add("font-family", "MS Sans Serif")
                    label3_mod_new.Style.Add("font-weight", "bold")
                    label3_mod_new.Style.Add("text-align", "right")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim txtamt_mod_new As TextBox = New TextBox
                    txtamt_mod_new.ID = "txtamt_mod_new" & Format(i, "00")
                    txtamt_mod_new.Width = "50"
                    txtamt_mod_new.Style.Add("font-size", "12px")
                    txtamt_mod_new.Style.Add("font-family", "MS Sans Serif")
                    txtamt_mod_new.Style.Add("font-weight", "bold")
                    txtamt_mod_new.Style.Add("text-align", "left")
                    txtamt_mod_new.Style.Add("border-style", "solid")
                    txtamt_mod_new.Style.Add("border-color", "gray")
                    txtamt_mod_new.Style.Add("border-width", "1px")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim pay_mod_new As LinkButton = New LinkButton
                    pay_mod_new.Width = "30"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim txtpaydt_mod_new As Label = New Label
                    txtpaydt_mod_new.Width = "120"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim drop1_mod_new As DropDownList = New DropDownList
                    drop1_mod_new.ID = "paymethod_mod_new" & Format(i, "00")
                    drop1_mod_new.Width = "90"
                    drop1_mod_new.Style.Add("font-size", "12px")
                    drop1_mod_new.Style.Add("font-family", "MS Sans Serif")
                    drop1_mod_new.Style.Add("font-weight", "bold")
                    drop1_mod_new.Style.Add("text-align", "center")
                    drop1_mod_new.Items.Add("NAB")
                    drop1_mod_new.Items.Add("Cas")
                    drop1_mod_new.Items.Add("Sal")
                    drop1_mod_new.Items.Add("Chq")
                    drop1_mod_new.Items.Add("CBA")
                    drop1_mod_new.Items.Add("Cre")
                    drop1_mod_new.Items.Add("Def")
                    drop1_mod_new.Items.Add("HOD")
                    drop1_mod_new.Items.Add("WOF")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim label6_mod_new As Label = New Label
                    label6_mod_new.Text = ""
                    label6_mod_new.Width = "40"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim ca_mod As New CalendarExtender
                    ca_mod.ID = "ca_mod" & Format(i, "00")
                    ca_mod.Format = "dd-MMM-yyyy"
                    ca_mod.TargetControlID = txtdt_mod_new.ID
                    ca_mod.OnClientShowing = "showDate"
                    'ca_mod.CssClass = "red"
                    ca_mod.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    td_mod.Controls.Add(label_mod_new)
                    td_mod.Controls.Add(label1_mod_new)
                    td_mod.Controls.Add(drop_mod_new)
                    td_mod.Controls.Add(txtdt_mod_new)
                    td_mod.Controls.Add(ca_mod)
                    td_mod.Controls.Add(label3_mod_new)
                    td_mod.Controls.Add(txtamt_mod_new)
                    td_mod.Controls.Add(pay_mod_new)
                    td_mod.Controls.Add(txtpaydt_mod_new)
                    td_mod.Controls.Add(drop1_mod_new)
                    td_mod.Controls.Add(label6_mod_new)

                    Dim mod_date As Date
                    Dim int_SinglePayment As Double
                    int_SinglePayment = FormatNumber(Session("txtamt_mod") / (Val(txtaddpaymnt.Text) + 1))

                    If Val(txtaddpaymnt.Text) = 0 Then
                        Exit For
                    Else

                        Dim count_totalSinglePayment As Double
                        If i = 1 Then
                            If payment_mod_old.SelectedItem.Text = "NAB" Then
                                drop1_mod_new.Text = "NAB"
                            ElseIf payment_mod_old.SelectedItem.Text = "Cas" Then
                                drop1_mod_new.Text = "Cas"
                            ElseIf payment_mod_old.SelectedItem.Text = "Sal" Then
                                drop1_mod_new.Text = "Sal"
                            ElseIf payment_mod_old.SelectedItem.Text = "Chq" Then
                                drop1_mod_new.Text = "Chq"
                            ElseIf payment_mod_old.SelectedItem.Text = "CBA" Then
                                drop1_mod_new.SelectedItem.Text = "CBA"
                            ElseIf payment_mod_old.SelectedItem.Text = "Cre" Then
                                drop1_mod_new.Text = "Cre"
                            ElseIf payment_mod_old.SelectedItem.Text = "Def" Then
                                drop1_mod_new.Text = "Def"
                            ElseIf payment_mod_old.SelectedItem.Text = "HOD" Then
                                drop1_mod_new.Text = "HOD"
                            ElseIf payment_mod_old.SelectedItem.Text = "WOF" Then
                                drop1_mod_new.Text = "WOF"
                            End If
                            txtamt_mod_old.Text = Math.Round(CDbl(int_SinglePayment), 2)
                            Session("old_amt") = txtamt_mod_old.Text
                            Session("tot_SinglePayment") = CDbl(Session("tot_SinglePayment")) + CDbl(Session("old_amt"))
                            If Val(Session("count_chk")) = 0 Then
                                Session("old_amt_new") = CDbl(Session("old_amt_new")) + CDbl(txtamt_mod_old.Text)
                            End If
                            count_totalSinglePayment = count_totalSinglePayment + Math.Round(CDbl(int_SinglePayment), 2)
                            mod_date = Session("acpt_due_date_mod")
                            If Drppayfreq.SelectedItem.Text = "Weekly" Then
                                txtdt_mod_new.Text = mod_date.AddDays(7).ToString("dd-MMM-yyyy")
                            ElseIf Drppayfreq.SelectedItem.Text = "Fortnightly" Then
                                txtdt_mod_new.Text = mod_date.AddDays(14).ToString("dd-MMM-yyyy")
                            ElseIf Drppayfreq.SelectedItem.Text = "Monthly" Then
                                txtdt_mod_new.Text = mod_date.AddDays(30).ToString("dd-MMM-yyyy")
                            End If

                        Else

                            '''''''''This following statement is executed in the end..
                            If i = Val(txtaddpaymnt.Text) + 1 Then

                                If payment_mod_old.SelectedItem.Text = "NAB" Then
                                    drop1_mod_new.Text = "NAB"
                                ElseIf payment_mod_old.SelectedItem.Text = "Cas" Then
                                    drop1_mod_new.Text = "Cas"
                                ElseIf payment_mod_old.SelectedItem.Text = "Sal" Then
                                    drop1_mod_new.Text = "Sal"
                                ElseIf payment_mod_old.SelectedItem.Text = "Chq" Then
                                    drop1_mod_new.Text = "Chq"
                                ElseIf payment_mod_old.SelectedItem.Text = "CBA" Then
                                    drop1_mod_new.Text = "CBA"
                                ElseIf payment_mod_old.SelectedItem.Text = "Cre" Then
                                    drop1_mod_new.Text = "Cre"
                                ElseIf payment_mod_old.SelectedItem.Text = "Def" Then
                                    drop1_mod_new.Text = "Def"
                                ElseIf payment_mod_old.SelectedItem.Text = "HOD" Then
                                    drop1_mod_new.Text = "HOD"
                                ElseIf payment_mod_old.SelectedItem.Text = "WOF" Then
                                    drop1_mod_new.Text = "WOF"
                                End If
                                int_SinglePayment = Session("txtamt_mod") - count_totalSinglePayment
                                txtamt_mod_new.Text = Math.Round(CDbl(int_SinglePayment), 2)
                                Session("tot_SinglePayment") = CDbl(Session("tot_SinglePayment")) + CDbl(txtamt_mod_new.Text)
                                mod_date = Session("acpt_due_date_mod")
                                If Val(Session("count_chk")) = 0 Then
                                    Session("old_amt_new") = CDbl(Session("old_amt_new")) + CDbl(txtamt_mod_new.Text)
                                End If

                                If Drppayfreq.SelectedItem.Text = "Weekly" Then
                                    txtdt_mod_new.Text = mod_date.AddDays(7).ToString("dd-MMM-yyyy")
                                ElseIf Drppayfreq.SelectedItem.Text = "Fortnightly" Then
                                    txtdt_mod_new.Text = mod_date.AddDays(14).ToString("dd-MMM-yyyy")
                                ElseIf Drppayfreq.SelectedItem.Text = "Monthly" Then
                                    txtdt_mod_new.Text = mod_date.AddDays(30).ToString("dd-MMM-yyyy")
                                End If
                                tr_mod.Controls.Add(td_mod)
                                '''''''''''''''''''''''next line always starts from +2 , then +3 and so on.....
                                tbl_mod.Controls.AddAt(Session("count") + i - 1, tr_mod) 'index so zero based, zero = row 1   
                                PlaceHolder1.Controls.Add(tbl_mod)
                                PlaceHolder1.Controls.Add(New LiteralControl("<br>"))
                                Session("acpt_due_date_mod") = txtdt_mod_new.Text
                                Exit For
                            End If
                            If payment_mod_old.SelectedItem.Text = "NAB" Then
                                drop1_mod_new.Text = "NAB"
                            ElseIf payment_mod_old.SelectedItem.Text = "Cas" Then
                                drop1_mod_new.Text = "Cas"
                            ElseIf payment_mod_old.SelectedItem.Text = "Sal" Then
                                drop1_mod_new.Text = "Sal"
                            ElseIf payment_mod_old.SelectedItem.Text = "Chq" Then
                                drop1_mod_new.SelectedItem.Text = "Chq"
                            ElseIf payment_mod_old.Text = "CBA" Then
                                drop1_mod_new.Text = "CBA"
                            ElseIf payment_mod_old.SelectedItem.Text = "Cre" Then
                                drop1_mod_new.Text = "Cre"
                            ElseIf payment_mod_old.SelectedItem.Text = "Def" Then
                                drop1_mod_new.Text = "Def"
                            ElseIf payment_mod_old.SelectedItem.Text = "HOD" Then
                                drop1_mod_new.Text = "HOD"
                            ElseIf payment_mod_old.SelectedItem.Text = "WOF" Then
                                drop1_mod_new.Text = "WOF"
                            End If
                            txtamt_mod_new.Text = Math.Round(CDbl(int_SinglePayment), 2)
                            Session("tot_SinglePayment") = CDbl(Session("tot_SinglePayment")) + CDbl(txtamt_mod_new.Text)
                            count_totalSinglePayment = count_totalSinglePayment + Math.Round(CDbl(int_SinglePayment), 2)
                            mod_date = Session("acpt_due_date_mod")
                            If Val(Session("count_chk")) = 0 Then
                                Session("old_amt_new") = CDbl(Session("old_amt_new")) + CDbl(txtamt_mod_new.Text)
                            End If
                            If Drppayfreq.SelectedItem.Text = "Weekly" Then
                                txtdt_mod_new.Text = mod_date.AddDays(7).ToString("dd-MMM-yyyy")
                            ElseIf Drppayfreq.SelectedItem.Text = "Fortnightly" Then
                                txtdt_mod_new.Text = mod_date.AddDays(14).ToString("dd-MMM-yyyy")
                            ElseIf Drppayfreq.SelectedItem.Text = "Monthly" Then
                                txtdt_mod_new.Text = mod_date.AddDays(30).ToString("dd-MMM-yyyy")
                            End If
                            Session("acpt_due_date_mod") = txtdt_mod_new.Text
                            tr_mod.Controls.Add(td_mod)
                            tbl_mod.Controls.AddAt(Session("count") + i - 1, tr_mod) 'index so zero based, zero = row 1   
                            PlaceHolder1.Controls.Clear()
                            PlaceHolder1.Controls.Add(tbl_mod)
                            PlaceHolder1.Controls.Add(New LiteralControl("<br>"))
                        End If

                    End If

                Next
            Else
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''
                'Session("tot_SinglePayment") = 0

                Dim tbl_mod As New Table
                tbl_mod = PlaceHolder1.FindControl("tbl_dynamic")
                tbl_mod.ID = "tbl_mod"
                Dim mod_date As Date
                cal_count = 0


                For l As Integer = 0 To Session("count") - 1

                    If cal_count < 10 Then
                        chk = Me.FindControl("chk" & "0" & l)
                    Else
                        chk = Me.FindControl("chk" & l)
                    End If
                    If chk.Checked = True Then

                        Dim txtamt_mod_old As New TextBox
                        txtamt_mod_old = Me.FindControl("txtamt" & Format(l, "00"))
                        txtamt_mod_old.ReadOnly = False
                        txtamt_mod_old.Enabled = True
                        txtamt_mod_old.Width = "50"
                        Dim dt_mod_old As New TextBox
                        dt_mod_old = Me.FindControl("txt" & Format(l, "00"))
                        dt_mod_old.ReadOnly = False
                        dt_mod_old.Enabled = True
                        dt_mod_old.Width = "80"
                        Dim payment_mod_old As New DropDownList
                        payment_mod_old = Me.FindControl("drop" & Format(l, "00"))
                        payment_mod_old.Style.Add("font-size", "12px")
                        payment_mod_old.Style.Add("font-family", "MS Sans Serif")
                        payment_mod_old.Style.Add("font-weight", "bold")
                        payment_mod_old.Style.Add("text-align", "center")
                        payment_mod_old.Items.Add("NAB")
                        payment_mod_old.Items.Add("Cas")
                        payment_mod_old.Items.Add("Sal")
                        payment_mod_old.Items.Add("Chq")
                        payment_mod_old.Items.Add("CBA")
                        payment_mod_old.Items.Add("Cre")
                        payment_mod_old.Items.Add("Def")
                        payment_mod_old.Items.Add("HOD")
                        payment_mod_old.Items.Add("WOF")
                        Dim int_SinglePayment As Double
                        int_SinglePayment = Math.Round(Session("txtamt_mod_new1") / (txtaddpaymnt.Text + Session("count_cncl")), 2)
                        txtamt_mod_old.Text = int_SinglePayment
                        Session("old_amt") = txtamt_mod_old.Text

                        If Val(Session("count_chk")) = 0 Then
                            Session("old_amt_new") = CDbl(Session("old_amt_new")) + CDbl(txtamt_mod_old.Text)
                            Session("tot_SinglePayment") = FormatNumber(CDbl(Session("tot_SinglePayment")) + CDbl(int_SinglePayment))
                            Session("tot_SinglePayment") = Math.Round(CDbl(Session("tot_SinglePayment")), 2)
                        End If

                        If l = 0 Then
                            Session("acpt_due_date_mod") = dt_mod_old.Text
                        Else
                            mod_date = Session("acpt_due_date_mod")
                            If Drppayfreq.SelectedItem.Text = "Weekly" Then
                                dt_mod_old.Text = mod_date.AddDays(7).ToString("dd-MMM-yyyy")
                            ElseIf Drppayfreq.SelectedItem.Text = "Fortnightly" Then
                                dt_mod_old.Text = mod_date.AddDays(14).ToString("dd-MMM-yyyy")
                            ElseIf Drppayfreq.SelectedItem.Text = "Monthly" Then
                                dt_mod_old.Text = mod_date.AddDays(30).ToString("dd-MMM-yyyy")
                            End If
                            Session("acpt_due_date_mod") = dt_mod_old.Text
                        End If
                        cal_count = cal_count + 1
                    Else
                        Dim dt_mod_old As New TextBox
                        dt_mod_old = Me.FindControl("txt" & Format(l, "00"))
                        dt_mod_old.ReadOnly = False
                        dt_mod_old.Enabled = True
                        dt_mod_old.Width = "80"
                        Session("acpt_due_date_mod") = dt_mod_old.Text
                        cal_count = cal_count + 1

                    End If

                Next



                For i As Integer = 1 To Val(txtaddpaymnt.Text)
                    Dim tr_mod As New TableRow()
                    Dim td_mod As New TableCell()

                    td_mod.Style.Add("border-style", "solid")
                    td_mod.Style.Add("border-width", "1px")
                    td_mod.Style.Add(" border-color", "gray")
                    tr_mod.Style.Add("border-style", "solid")
                    tr_mod.Style.Add("border-width", "1px")
                    tr_mod.Style.Add(" border-color", "gray")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim label_mod_new As Label = New Label()
                    label_mod_new.Width = "35"
                    label_mod_new.Style.Add("font-size", "12px")
                    label_mod_new.Style.Add("font-family", "MS Sans Serif")
                    label_mod_new.Style.Add("font-weight", "bold")
                    label_mod_new.Style.Add("text-align", "center")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim label1_mod_new As Label = New Label()
                    label1_mod_new.Width = "30"
                    label1_mod_new.Style.Add("font-size", "12px")
                    label1_mod_new.Style.Add("font-family", "MS Sans Serif")
                    label1_mod_new.Style.Add("font-weight", "bold")
                    label1_mod_new.Style.Add("text-align", "center")

                    ''''''''''''''''''''''''''''''''''''''''''''''
                    Dim drop_mod_new As Label = New Label
                    drop_mod_new.Width = "130"
                    drop_mod_new.Text = ""
                    drop_mod_new.Style.Add("font-size", "12px")
                    drop_mod_new.Style.Add("font-family", "MS Sans Serif")
                    drop_mod_new.Style.Add("font-weight", "bold")
                    drop_mod_new.Style.Add("text-align", "center")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim txtdt_mod_new As TextBox = New TextBox
                    txtdt_mod_new.ID = "txtdt_mod_new" & Format(i, "00")
                    txtdt_mod_new.Width = "80"
                    txtdt_mod_new.Style.Add("font-size", "12px")
                    txtdt_mod_new.Style.Add("font-family", "MS Sans Serif")
                    txtdt_mod_new.Style.Add("font-weight", "bold")
                    txtdt_mod_new.Style.Add("text-align", "center")
                    txtdt_mod_new.Style.Add("border-color", "gray")
                    txtdt_mod_new.Style.Add("border-style", "solid")
                    txtdt_mod_new.Style.Add("border-width", "1px")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim label3_mod_new As Label = New Label
                    label3_mod_new.Text = "$"
                    label3_mod_new.Width = "15"
                    label3_mod_new.Style.Add("font-size", "12px")
                    label3_mod_new.Style.Add("font-family", "MS Sans Serif")
                    label3_mod_new.Style.Add("font-weight", "bold")
                    label3_mod_new.Style.Add("text-align", "right")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim txtamt_mod_new As TextBox = New TextBox
                    txtamt_mod_new.ID = "txtamt_mod_new" & Format(i, "00")
                    txtamt_mod_new.Width = "50"
                    txtamt_mod_new.Style.Add("font-size", "12px")
                    txtamt_mod_new.Style.Add("font-family", "MS Sans Serif")
                    txtamt_mod_new.Style.Add("font-weight", "bold")
                    txtamt_mod_new.Style.Add("text-align", "left")
                    txtamt_mod_new.Style.Add("border-style", "solid")
                    txtamt_mod_new.Style.Add("border-color", "gray")
                    txtamt_mod_new.Style.Add("border-width", "1px")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim pay_mod_new As LinkButton = New LinkButton
                    pay_mod_new.Width = "30"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim txtpaydt_mod_new As Label = New Label
                    txtpaydt_mod_new.Width = "120"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim drop1_mod_new As DropDownList = New DropDownList
                    drop1_mod_new.ID = "paymethod_mod_new" & Format(i, "00")
                    drop1_mod_new.Width = "90"
                    drop1_mod_new.Style.Add("font-size", "12px")
                    drop1_mod_new.Style.Add("font-family", "MS Sans Serif")
                    drop1_mod_new.Style.Add("font-weight", "bold")
                    drop1_mod_new.Style.Add("text-align", "center")
                    drop1_mod_new.Items.Add("NAB")
                    drop1_mod_new.Items.Add("Cas")
                    drop1_mod_new.Items.Add("Sal")
                    drop1_mod_new.Items.Add("Chq")
                    drop1_mod_new.Items.Add("CBA")
                    drop1_mod_new.Items.Add("Cre")
                    drop1_mod_new.Items.Add("Def")
                    drop1_mod_new.Items.Add("HOD")
                    drop1_mod_new.Items.Add("WOF")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim label6_mod_new As Label = New Label
                    label6_mod_new.Text = ""
                    label6_mod_new.Width = "40"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim ca_mod As New CalendarExtender
                    ca_mod.ID = "ca_mod" & Format(i, "00")
                    ca_mod.Format = "dd-MMM-yyyy"
                    ca_mod.TargetControlID = txtdt_mod_new.ID
                    ca_mod.OnClientShowing = "showDate"
                    ca_mod.CssClass = "red"
                    ca_mod.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    td_mod.Controls.Add(label_mod_new)
                    td_mod.Controls.Add(label1_mod_new)
                    td_mod.Controls.Add(drop_mod_new)
                    td_mod.Controls.Add(txtdt_mod_new)
                    td_mod.Controls.Add(ca_mod)
                    td_mod.Controls.Add(label3_mod_new)
                    td_mod.Controls.Add(txtamt_mod_new)
                    td_mod.Controls.Add(pay_mod_new)
                    td_mod.Controls.Add(txtpaydt_mod_new)
                    td_mod.Controls.Add(drop1_mod_new)
                    td_mod.Controls.Add(label6_mod_new)


                    If Val(txtaddpaymnt.Text) = 0 Then
                        Exit For
                    Else


                        If i = 1 Then
                            'If payment_mod_old.SelectedItem.Text = "NAB" Then
                            '    drop1_mod_new.Text = "NAB"
                            'ElseIf payment_mod_old.SelectedItem.Text = "Cas" Then
                            '    drop1_mod_new.Text = "Cas"
                            'ElseIf payment_mod_old.SelectedItem.Text = "Sal" Then
                            '    drop1_mod_new.Text = "Sal"
                            'ElseIf payment_mod_old.SelectedItem.Text = "Chq" Then
                            '    drop1_mod_new.Text = "Chq"
                            'ElseIf payment_mod_old.SelectedItem.Text = "CBA" Then
                            '    drop1_mod_new.SelectedItem.Text = "CBA"
                            'ElseIf payment_mod_old.SelectedItem.Text = "Cre" Then
                            '    drop1_mod_new.Text = "Cre"
                            'ElseIf payment_mod_old.SelectedItem.Text = "Def" Then
                            '    drop1_mod_new.Text = "Def"
                            'ElseIf payment_mod_old.SelectedItem.Text = "HOD" Then
                            '    drop1_mod_new.Text = "HOD"
                            'ElseIf payment_mod_old.SelectedItem.Text = "WOF" Then
                            '    drop1_mod_new.Text = "WOF"
                            'End If
                            If Val(Session("count_chk")) = 0 Then
                                'If Val(Session("count_cncl")) - Val(txtaddpaymnt.Text) = 1 Then
                                '    txtamt_mod_new.Text = Math.Round(Session("txtamt_mod_new1") - CDbl(Session("tot_SinglePayment")), 2)
                                '    Session("old_amt_new") = CDbl(Session("old_amt_new")) + CDbl(txtamt_mod_new.Text)
                                If Val(txtaddpaymnt.Text) = 1 Then

                                    txtamt_mod_new.Text = Math.Round(Session("txtamt_mod_new1") - CDbl(Session("tot_SinglePayment")), 2)
                                    Session("old_amt_new") = CDbl(Session("old_amt_new")) + CDbl(txtamt_mod_new.Text)
                                Else
                                    txtamt_mod_new.Text = Math.Round(Session("txtamt_mod_new1") / (Val(txtaddpaymnt.Text) + Session("count_cncl")), 2)
                                    Session("old_amt_new") = CDbl(Session("old_amt_new")) + CDbl(txtamt_mod_new.Text)
                                End If
                                Session("tot_SinglePayment") = CDbl(Session("tot_SinglePayment")) + txtamt_mod_new.Text
                            End If





                            mod_date = Session("acpt_due_date_mod")
                            If Drppayfreq.SelectedItem.Text = "Weekly" Then
                                txtdt_mod_new.Text = mod_date.AddDays(7).ToString("dd-MMM-yyyy")
                            ElseIf Drppayfreq.SelectedItem.Text = "Fortnightly" Then
                                txtdt_mod_new.Text = mod_date.AddDays(14).ToString("dd-MMM-yyyy")
                            ElseIf Drppayfreq.SelectedItem.Text = "Monthly" Then
                                txtdt_mod_new.Text = mod_date.AddDays(30).ToString("dd-MMM-yyyy")
                            End If
                            Session("acpt_due_date_mod") = txtdt_mod_new.Text
                            tr_mod.Controls.Add(td_mod)
                            tbl_mod.Controls.AddAt(Session("count") + i, tr_mod) 'index so zero based, zero = row 1   
                        Else

                            '''''''''This following statement is executed in the end..
                            If i = Val(txtaddpaymnt.Text) Then

                                'If payment_mod_old.SelectedItem.Text = "NAB" Then
                                '    drop1_mod_new.Text = "NAB"
                                'ElseIf payment_mod_old.SelectedItem.Text = "Cas" Then
                                '    drop1_mod_new.Text = "Cas"
                                'ElseIf payment_mod_old.SelectedItem.Text = "Sal" Then
                                '    drop1_mod_new.Text = "Sal"
                                'ElseIf payment_mod_old.SelectedItem.Text = "Chq" Then
                                '    drop1_mod_new.Text = "Chq"
                                'ElseIf payment_mod_old.SelectedItem.Text = "CBA" Then
                                '    drop1_mod_new.Text = "CBA"
                                'ElseIf payment_mod_old.SelectedItem.Text = "Cre" Then
                                '    drop1_mod_new.Text = "Cre"
                                'ElseIf payment_mod_old.SelectedItem.Text = "Def" Then
                                '    drop1_mod_new.Text = "Def"
                                'ElseIf payment_mod_old.SelectedItem.Text = "HOD" Then
                                '    drop1_mod_new.Text = "HOD"
                                'ElseIf payment_mod_old.SelectedItem.Text = "WOF" Then
                                '    drop1_mod_new.Text = "WOF"
                                'End If
                                txtamt_mod_new.Text = Math.Round(Session("txtamt_mod_new1") - CDbl(Session("tot_SinglePayment")), 2)
                                If Val(Session("count_chk")) = 0 Then
                                    Session("old_amt_new") = CDbl(Session("old_amt_new")) + CDbl(txtamt_mod_new.Text)
                                    Session("tot_SinglePayment") = CDbl(Session("tot_SinglePayment")) + txtamt_mod_new.Text
                                End If
                                mod_date = Session("acpt_due_date_mod")

                                If Drppayfreq.SelectedItem.Text = "Weekly" Then
                                    txtdt_mod_new.Text = mod_date.AddDays(7).ToString("dd-MMM-yyyy")
                                ElseIf Drppayfreq.SelectedItem.Text = "Fortnightly" Then
                                    txtdt_mod_new.Text = mod_date.AddDays(14).ToString("dd-MMM-yyyy")
                                ElseIf Drppayfreq.SelectedItem.Text = "Monthly" Then
                                    txtdt_mod_new.Text = mod_date.AddDays(30).ToString("dd-MMM-yyyy")
                                End If
                                tr_mod.Controls.Add(td_mod)
                                '''''''''''''''''''''''next line always starts from +2 , then +3 and so on.....
                                tbl_mod.Controls.AddAt(Session("count") + i, tr_mod) 'index so zero based, zero = row 1   
                                PlaceHolder1.Controls.Add(tbl_mod)
                                PlaceHolder1.Controls.Add(New LiteralControl("<br>"))
                                Session("acpt_due_date_mod") = txtdt_mod_new.Text

                                Exit For
                            End If
                            If i <> Val(txtaddpaymnt.Text) Then
                                txtamt_mod_new.Text = Math.Round(Session("txtamt_mod_new1") / (Val(txtaddpaymnt.Text) + Session("count_cncl")), 2)
                                If Val(Session("count_chk")) = 0 Then
                                    Session("old_amt_new") = CDbl(Session("old_amt_new")) + CDbl(txtamt_mod_new.Text)

                                    Session("tot_SinglePayment") = CDbl(Session("tot_SinglePayment")) + CDbl(txtamt_mod_new.Text)
                                End If

                                mod_date = Session("acpt_due_date_mod")
                                If Drppayfreq.SelectedItem.Text = "Weekly" Then
                                    txtdt_mod_new.Text = mod_date.AddDays(7).ToString("dd-MMM-yyyy")
                                ElseIf Drppayfreq.SelectedItem.Text = "Fortnightly" Then
                                    txtdt_mod_new.Text = mod_date.AddDays(14).ToString("dd-MMM-yyyy")
                                ElseIf Drppayfreq.SelectedItem.Text = "Monthly" Then
                                    txtdt_mod_new.Text = mod_date.AddDays(30).ToString("dd-MMM-yyyy")
                                End If
                                Session("acpt_due_date_mod") = txtdt_mod_new.Text
                                tr_mod.Controls.Add(td_mod)
                                tbl_mod.Controls.AddAt(Session("count") + i, tr_mod)
                            End If

                            PlaceHolder1.Controls.Clear()
                            PlaceHolder1.Controls.Add(tbl_mod)
                            PlaceHolder1.Controls.Add(New LiteralControl("<br>"))

                        End If

                    End If



                Next















                ''''''''''''''''''''''''''''''''

            End If


        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Val(txtaddpaymnt.Text) <> 0 Then
            Session("count_chk") = 2
        End If


    End Sub

    Protected Sub btnsave_mod_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave_mod.Click


        Try

            If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
                loan_id_new = Session("beg_loan_id")

            ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                loan_id_new = Session("beg_loan_id")

            ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                loan_id_new = Session("cur_loan_id")
            ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                loan_id_new = Session("cur_loan_id")
            ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                loan_id_new = Session("beg_loan_id")

            ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False And Session("beg_status") <> "Declined" Then

                loan_id_new = Session("cur_loan_id")
            ElseIf Session("beg_status") = "Declined" Then
                loan_id_new = Session("beg_loan_id")
            Else
                If Val(Session("beg_loan_id")) <> 0 Then
                    loan_id_new = Session("beg_loan_id")
                Else
                    loan_id_new = Session("cur_loan_id")
                End If
            End If




            Dim t As Integer
            Dim cal_count1 As Integer = 0
            Dim cal_count_for As Integer = 0
            For t = 0 To Session("count") - 1
                If cal_count_for < 10 Then
                    chk = Me.FindControl("chk" & "0" & t)
                Else
                    chk = Me.FindControl("chk" & t)
                End If
                If chk.Checked = True Then
                    cal_count1 = cal_count1 + 1
                    cal_count_for = cal_count_for + 1
                Else

                    cal_count_for = cal_count_for + 1
                End If
            Next
            If Val(txtaddpaymnt.Text) = 0 Then
                If check_fee() = True Then
                    Dim j As Integer
                    Dim cal_count As Integer = 0
                    For j = 0 To Session("count") - 1

                        If cal_count < 10 Then
                            chk = Me.FindControl("chk" & "0" & j)
                        Else
                            chk = Me.FindControl("chk" & j)
                        End If
                        If chk.Checked = True Then

                            ''''''''''''''''''these are the show_loan_repay date and amount
                            Dim txtamt_chkmod_new As New TextBox
                            txtamt_chkmod_new = Me.FindControl("txtamt" & Format(j, "00"))
                            txtamt_chkmod_new.ReadOnly = False
                            txtamt_chkmod_new.Enabled = True
                            Dim txtdt_chkmod_new As New TextBox
                            txtdt_chkmod_new = Me.FindControl("txt" & Format(j, "00"))
                            txtdt_chkmod_new.ReadOnly = False
                            txtdt_chkmod_new.Enabled = True

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Dim ca_chkmod As New CalendarExtender
                            ca_chkmod.ID = "ca_chkmod" & Format(j, "00")
                            ca_chkmod.Format = "dd-MMM-yyyy"
                            ca_chkmod.OnClientShowing = "showDate"
                            ca_chkmod.CssClass = "red"
                            ca_chkmod.TargetControlID = txtdt_chkmod_new.ID
                            ca_chkmod.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
                            Dim paymethod_chkmod_new As New DropDownList
                            paymethod_chkmod_new = Me.FindControl("drop" & Format(j, "00"))

                            Dim pay_mod_id As New Label
                            pay_mod_id = Me.FindControl("lab4" & Format(j, "00"))

                            Dim str_chkmod, contract_date, str_chkpay, str_pay, str_date As String
                            Dim cmd_chkmod, cmd_due_date As New SqlCommand
                            Dim ds_chkmod As New DataSet
                            Dim cmd_chkpay As New SqlCommand

                            str_date = "update tbl_payment set updated=@due_date where Payment_ID = " & Val(pay_mod_id.Text)
                            cmd_due_date.CommandText = str_date
                            cmd_due_date.Parameters.Add("@due_date", SqlDbType.VarChar, 50).Value = "upd"
                            cmd_due_date.Connection = open_con.return_con
                            cmd_due_date.ExecuteNonQuery()
                            cmd_due_date.Dispose()


                            If Val(pay_mod_id.Text) <> 0 Then
                                '  str_date = "update tbl_payment set Due_Date=@due_date where Payment_ID = " & Val(pay_mod_id.Text)

                                str_chkmod = "Select Contract_Date,Description from Tbl_Payment where Payment_ID=" & Val(pay_mod_id.Text)
                                cmd_chkmod.CommandText = str_chkmod
                                cmd_chkmod.Connection = open_con.return_con
                                cmd_chkmod.ExecuteNonQuery()

                                Dim adap_chkmod As SqlDataAdapter
                                adap_chkmod = New SqlDataAdapter(cmd_chkmod)
                                adap_chkmod.Fill(ds_chkmod)
                                adap_chkmod.Dispose()
                                If ds_chkmod.Tables(0).Rows(0).Item(0).ToString = "" Then
                                    str_chkpay = "insert into tbl_payment(Customer_ID,Loan_ID,Description,Amount,Due_Date,Payment_Method,Date_Updated,Update_ID)values(@Customer_ID,@Loan_ID,@Description,@Amount,@Due_Date,@Payment_Method,@Date_Updated,@Update_ID)"
                                    cmd_chkpay.CommandText = str_chkpay
                                    cmd_chkpay.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
                                    cmd_chkpay.Parameters.Add("@Loan_ID", SqlDbType.Int).Value = loan_id_new
                                    cmd_chkpay.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = ds_chkmod.Tables(0).Rows(0).Item(1).ToString
                                    cmd_chkpay.Parameters.Add("@Amount", SqlDbType.VarChar, 50).Value = txtamt_chkmod_new.Text
                                    cmd_chkpay.Parameters.Add("@Due_Date", SqlDbType.DateTime).Value = txtdt_chkmod_new.Text
                                    cmd_chkpay.Parameters.Add("@Payment_Method", SqlDbType.VarChar, 50).Value = paymethod_chkmod_new.SelectedItem.Text
                                    cmd_chkpay.Parameters.Add("@Date_Updated", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                                    cmd_chkpay.Parameters.Add("@Update_ID", SqlDbType.Int).Value = Val(pay_mod_id.Text)
                                    cmd_chkpay.Connection = open_con.return_con
                                    cmd_chkpay.ExecuteNonQuery()
                                    cmd_chkpay.Dispose()


                                    For i As Integer = 1 To Val(txtaddpaymnt.Text)

                                        Dim cmd_pay As New SqlCommand
                                        Dim txtamt_mod_new As New TextBox
                                        txtamt_mod_new = Me.FindControl("txtamt_mod_new" & Format(i + 1, "00"))

                                        Dim txtdt_mod_new As New TextBox
                                        txtdt_mod_new = Me.FindControl("txtdt_mod_new" & Format(i + 1, "00"))

                                        Dim paymethod_mod_new As New DropDownList
                                        paymethod_mod_new = Me.FindControl("paymethod_mod_new" & Format(i + 1, "00"))

                                        str_pay = "insert into tbl_payment(Customer_ID,Loan_ID,Description,Amount,Due_Date,Payment_Method,Date_Updated)values(" & open_con.customer_id_val & "," & loan_id_new & ",@des," & txtamt_mod_new.Text & ",@due_date,'" & paymethod_mod_new.SelectedItem.Text & "',@date_updated)"
                                        cmd_pay.Parameters.Add("@des", SqlDbType.VarChar, 255).Value = ""
                                        '" & ds_chkmod.Tables(0).Rows(0).Item(1).ToString & "'
                                        cmd_pay.Parameters.Add("@due_date", SqlDbType.DateTime).Value = CDate(txtdt_mod_new.Text)
                                        cmd_pay.Parameters.Add("@date_updated", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                                        cmd_pay.CommandText = str_pay
                                        cmd_pay.Connection = open_con.return_con
                                        cmd_pay.ExecuteNonQuery()
                                        cmd_pay.Dispose()
                                    Next

                                    ds_chkmod.Dispose()
                                    txtaddpaymnt.Text = ""
                                Else

                                    contract_date = ds_chkmod.Tables(0).Rows(0).Item(0).ToString
                                    str_chkpay = "insert into tbl_payment(Customer_ID,Loan_ID,Description,Amount,Due_Date,Contract_Date,Payment_Method,Date_Updated,Update_ID)values(@Customer_ID,@Loan_ID,@Description,@Amount,@Due_Date,@Contract_Date,@Payment_Method,@Date_Updated,@Update_ID)"
                                    cmd_chkpay.CommandText = str_chkpay
                                    cmd_chkpay.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
                                    cmd_chkpay.Parameters.Add("@Loan_ID", SqlDbType.Int).Value = loan_id_new
                                    cmd_chkpay.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = ds_chkmod.Tables(0).Rows(0).Item(1).ToString
                                    cmd_chkpay.Parameters.Add("@Amount", SqlDbType.VarChar, 50).Value = txtamt_chkmod_new.Text
                                    cmd_chkpay.Parameters.Add("@Due_Date", SqlDbType.DateTime).Value = txtdt_chkmod_new.Text
                                    cmd_chkpay.Parameters.Add("@Contract_Date", SqlDbType.DateTime).Value = ds_chkmod.Tables(0).Rows(0).Item(0).ToString
                                    cmd_chkpay.Parameters.Add("@Payment_Method", SqlDbType.VarChar, 50).Value = paymethod_chkmod_new.Text
                                    cmd_chkpay.Parameters.Add("@Date_Updated", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                                    cmd_chkpay.Parameters.Add("@Update_ID", SqlDbType.Int).Value = Val(pay_mod_id.Text)
                                    cmd_chkpay.Connection = open_con.return_con
                                    cmd_chkpay.ExecuteNonQuery()
                                    cmd_chkpay.Dispose()

                                    For i As Integer = 1 To Val(txtaddpaymnt.Text)
                                        Dim cmd_pay As New SqlCommand
                                        Dim txtamt_mod_new As New TextBox
                                        txtamt_mod_new = Me.FindControl("txtamt_mod_new" & Format(i + 1, "00"))

                                        Dim txtdt_mod_new As New TextBox
                                        txtdt_mod_new = Me.FindControl("txtdt_mod_new" & Format(i + 1, "00"))

                                        Dim paymethod_mod_new As New DropDownList
                                        paymethod_mod_new = Me.FindControl("paymethod_mod_new" & Format(i + 1, "00"))
                                        str_pay = "insert into tbl_payment(Customer_ID,Loan_ID,Description,Amount,Due_Date,Contract_Date,Payment_Method,Date_Updated)values(" & open_con.customer_id_val & "," & loan_id_new & ",@des," & txtamt_mod_new.Text & ",@due_date,@contract_date,'" & paymethod_mod_new.SelectedItem.Text & "',@date_updated)"
                                        cmd_pay.CommandText = str_pay
                                        cmd_pay.Parameters.Add("@des", SqlDbType.VarChar, 255).Value = ""
                                        cmd_pay.Parameters.Add("@due_date", SqlDbType.DateTime).Value = CDate(txtdt_mod_new.Text)
                                        cmd_pay.Parameters.Add("@contract_date", SqlDbType.DateTime).Value = CDate(contract_date)
                                        cmd_pay.Parameters.Add("@date_updated", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                                        cmd_pay.Connection = open_con.return_con
                                        cmd_pay.ExecuteNonQuery()
                                        cmd_pay.Dispose()
                                    Next
                                    txtaddpaymnt.Text = ""
                                    ds_chkmod.Dispose()
                                    cmd_chkmod.Dispose()

                                End If
                            End If
                            'Exit For
                            cal_count = cal_count + 1
                        Else
                            cal_count = cal_count + 1
                        End If

                    Next

                    mod_reschedule(loan_id_new)
                    loan_id_new = 0
                    cancel_routine()
                    btnsave_mod.Visible = False
                    btncncl_mod.Visible = False
                    Session("tot_SinglePayment") = 0
                    Session("tot_SinglePayment_new") = 0
                Else
                    check_money()
                End If
            ElseIf Val(txtaddpaymnt.Text) <> 0 And cal_count1 = 1 Then
                If check_fee() = True Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim j As Integer
                    Dim cal_count As Integer = 0
                    For j = 0 To Session("count") - 1

                        If cal_count < 10 Then
                            chk = Me.FindControl("chk" & "0" & j)

                        Else
                            chk = Me.FindControl("chk" & j)
                        End If
                        If chk.Checked = True Then
                            cal_count = cal_count + 1
                        Else
                             cal_count = cal_count + 1
                        End If
                    Next

                    For i As Integer = 0 To cal_count - 1

                        Dim txtamt_chkmod_new As New TextBox
                        txtamt_chkmod_new = Me.FindControl("txtamt" & Format(i, "00"))
                        txtamt_chkmod_new.ReadOnly = False
                        txtamt_chkmod_new.Enabled = True
                        Dim txtdt_chkmod_new As New TextBox
                        txtdt_chkmod_new = Me.FindControl("txt" & Format(i, "00"))
                        txtdt_chkmod_new.ReadOnly = False
                        txtdt_chkmod_new.Enabled = True

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim ca_chkmod As New CalendarExtender
                        ca_chkmod.ID = "ca_chkmod" & Format(i, "00")
                        ca_chkmod.Format = "dd-MMM-yyyy"
                        ca_chkmod.OnClientShowing = "showDate"
                        ca_chkmod.CssClass = "red"
                        ca_chkmod.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
                        ca_chkmod.TargetControlID = txtdt_chkmod_new.ID
                        Dim paymethod_chkmod_new As New DropDownList
                        paymethod_chkmod_new = Me.FindControl("drop" & Format(i, "00"))

                        Dim pay_mod_id As New Label
                        pay_mod_id = Me.FindControl("lab4" & Format(i, "00"))

                        Dim str_chkmod, contract_date, str_chkpay, str_date As String
                        Dim cmd_chkmod, cmd_due_date As New SqlCommand
                        Dim ds_chkmod As New DataSet
                        Dim cmd_chkpay As New SqlCommand

                        str_date = "update tbl_payment set updated=@due_date where Payment_ID = " & Val(pay_mod_id.Text)
                        cmd_due_date.CommandText = str_date
                        cmd_due_date.Parameters.Add("@due_date", SqlDbType.VarChar, 50).Value = "upd"
                        cmd_due_date.Connection = open_con.return_con
                        cmd_due_date.ExecuteNonQuery()
                        cmd_due_date.Dispose()


                        If Val(pay_mod_id.Text) <> 0 Then
                            '  str_date = "update tbl_payment set Due_Date=@due_date where Payment_ID = " & Val(pay_mod_id.Text)

                            str_chkmod = "Select Contract_Date,Description from Tbl_Payment where Payment_ID=" & Val(pay_mod_id.Text)
                            cmd_chkmod.CommandText = str_chkmod
                            cmd_chkmod.Connection = open_con.return_con
                            cmd_chkmod.ExecuteNonQuery()

                            Dim adap_chkmod As SqlDataAdapter
                            adap_chkmod = New SqlDataAdapter(cmd_chkmod)
                            adap_chkmod.Fill(ds_chkmod)
                            adap_chkmod.Dispose()
                            If ds_chkmod.Tables(0).Rows(0).Item(0).ToString = "" Then
                                str_chkpay = "insert into tbl_payment(Customer_ID,Loan_ID,Description,Amount,Due_Date,Payment_Method,Date_Updated,Update_ID)values(@Customer_ID,@Loan_ID,@Description,@Amount,@Due_Date,@Payment_Method,@Date_Updated,@Update_ID)"
                                cmd_chkpay.CommandText = str_chkpay
                                cmd_chkpay.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
                                cmd_chkpay.Parameters.Add("@Loan_ID", SqlDbType.Int).Value = loan_id_new
                                cmd_chkpay.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = ds_chkmod.Tables(0).Rows(0).Item(1).ToString
                                cmd_chkpay.Parameters.Add("@Amount", SqlDbType.VarChar, 50).Value = txtamt_chkmod_new.Text
                                cmd_chkpay.Parameters.Add("@Due_Date", SqlDbType.DateTime).Value = txtdt_chkmod_new.Text
                                cmd_chkpay.Parameters.Add("@Payment_Method", SqlDbType.VarChar, 50).Value = paymethod_chkmod_new.SelectedItem.Text
                                cmd_chkpay.Parameters.Add("@Date_Updated", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                                cmd_chkpay.Parameters.Add("@Update_ID", SqlDbType.Int).Value = Val(pay_mod_id.Text)
                                cmd_chkpay.Connection = open_con.return_con
                                cmd_chkpay.ExecuteNonQuery()
                                cmd_chkpay.Dispose()
                                ds_chkmod.Dispose()
                            Else

                                contract_date = ds_chkmod.Tables(0).Rows(0).Item(0).ToString
                                str_chkpay = "insert into tbl_payment(Customer_ID,Loan_ID,Description,Amount,Due_Date,Contract_Date,Payment_Method,Date_Updated,Update_ID)values(@Customer_ID,@Loan_ID,@Description,@Amount,@Due_Date,@Contract_Date,@Payment_Method,@Date_Updated,@Update_ID)"
                                cmd_chkpay.CommandText = str_chkpay
                                cmd_chkpay.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
                                cmd_chkpay.Parameters.Add("@Loan_ID", SqlDbType.Int).Value = loan_id_new
                                cmd_chkpay.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = ds_chkmod.Tables(0).Rows(0).Item(1).ToString
                                cmd_chkpay.Parameters.Add("@Amount", SqlDbType.VarChar, 50).Value = txtamt_chkmod_new.Text
                                cmd_chkpay.Parameters.Add("@Due_Date", SqlDbType.DateTime).Value = txtdt_chkmod_new.Text
                                cmd_chkpay.Parameters.Add("@Contract_Date", SqlDbType.DateTime).Value = ds_chkmod.Tables(0).Rows(0).Item(0).ToString
                                cmd_chkpay.Parameters.Add("@Payment_Method", SqlDbType.VarChar, 50).Value = paymethod_chkmod_new.Text
                                cmd_chkpay.Parameters.Add("@Date_Updated", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                                cmd_chkpay.Parameters.Add("@Update_ID", SqlDbType.Int).Value = Val(pay_mod_id.Text)
                                cmd_chkpay.Connection = open_con.return_con
                                cmd_chkpay.ExecuteNonQuery()
                                cmd_chkpay.Dispose()



                            End If
                            ds_chkmod.Dispose()
                            cmd_chkmod.Dispose()
                        End If



                    Next
                    Dim str_pay_new As String
                    For k As Integer = 1 To Val(txtaddpaymnt.Text)

                        Dim cmd_pay As New SqlCommand
                        Dim txtamt_mod_new As New TextBox
                        txtamt_mod_new = Me.FindControl("txtamt_mod_new" & Format(k + 1, "00"))

                        Dim txtdt_mod_new As New TextBox
                        txtdt_mod_new = Me.FindControl("txtdt_mod_new" & Format(k + 1, "00"))

                        Dim paymethod_mod_new As New DropDownList
                        paymethod_mod_new = Me.FindControl("paymethod_mod_new" & Format(k + 1, "00"))

                        str_pay_new = "insert into tbl_payment(Customer_ID,Loan_ID,Description,Amount,Due_Date,Payment_Method,Date_Updated)values(" & open_con.customer_id_val & "," & loan_id_new & ",@des," & txtamt_mod_new.Text & ",@due_date,'" & paymethod_mod_new.SelectedItem.Text & "',@date_updated)"
                        cmd_pay.Parameters.Add("@des", SqlDbType.VarChar, 255).Value = ""
                        '" & ds_chkmod.Tables(0).Rows(0).Item(1).ToString & "'
                        cmd_pay.Parameters.Add("@due_date", SqlDbType.DateTime).Value = CDate(txtdt_mod_new.Text)
                        cmd_pay.Parameters.Add("@date_updated", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                        cmd_pay.CommandText = str_pay_new
                        cmd_pay.Connection = open_con.return_con
                        cmd_pay.ExecuteNonQuery()
                        cmd_pay.Dispose()
                    Next
                    txtaddpaymnt.Text = ""
                    mod_reschedule(loan_id_new)
                    loan_id_new = 0
                    cancel_routine()
                    btnsave_mod.Visible = False
                    btncncl_mod.Visible = False
                    Session("tot_SinglePayment") = 0
                    Session("tot_SinglePayment_new") = 0
                Else
                    check_money()
                End If



                ''''''''''''''''''''''''''''''''''''''''''''''''


            ElseIf Session("count") >= cal_count1 And Val(txtaddpaymnt.Text) <> 0 And cal_count1 > 1 Then

                If check_fee() = True Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim j As Integer
                    Dim cal_count As Integer = 0
                    For j = 0 To Session("count") - 1

                        If cal_count < 10 Then
                            chk = Me.FindControl("chk" & "0" & j)
                        Else
                            chk = Me.FindControl("chk" & j)
                        End If
                        If chk.Checked = True Then
                            cal_count = cal_count + 1
                        Else
                            cal_count = cal_count + 1
                        End If
                    Next

                    For i As Integer = 0 To cal_count - 1

                        Dim txtamt_chkmod_new As New TextBox
                        txtamt_chkmod_new = Me.FindControl("txtamt" & Format(i, "00"))
                        txtamt_chkmod_new.ReadOnly = False
                        txtamt_chkmod_new.Enabled = True
                        Dim txtdt_chkmod_new As New TextBox
                        txtdt_chkmod_new = Me.FindControl("txt" & Format(i, "00"))
                        txtdt_chkmod_new.ReadOnly = False
                        txtdt_chkmod_new.Enabled = True

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim ca_chkmod As New CalendarExtender
                        ca_chkmod.ID = "ca_chkmod" & Format(i, "00")
                        ca_chkmod.Format = "dd-MMM-yyyy"
                        ca_chkmod.OnClientShowing = "showDate"
                        ca_chkmod.CssClass = "red"
                        ca_chkmod.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
                        ca_chkmod.TargetControlID = txtdt_chkmod_new.ID
                        Dim paymethod_chkmod_new As New DropDownList
                        paymethod_chkmod_new = Me.FindControl("drop" & Format(i, "00"))

                        Dim pay_mod_id As New Label
                        pay_mod_id = Me.FindControl("lab4" & Format(i, "00"))

                        Dim str_chkmod, contract_date, str_chkpay, str_date As String
                        Dim cmd_chkmod, cmd_due_date As New SqlCommand
                        Dim ds_chkmod As New DataSet
                        Dim cmd_chkpay As New SqlCommand

                        str_date = "update tbl_payment set updated=@due_date where Payment_ID = " & Val(pay_mod_id.Text)
                        cmd_due_date.CommandText = str_date
                        cmd_due_date.Parameters.Add("@due_date", SqlDbType.VarChar, 50).Value = "upd"
                        cmd_due_date.Connection = open_con.return_con
                        cmd_due_date.ExecuteNonQuery()
                        cmd_due_date.Dispose()


                        If Val(pay_mod_id.Text) <> 0 Then
                            '  str_date = "update tbl_payment set Due_Date=@due_date where Payment_ID = " & Val(pay_mod_id.Text)

                            str_chkmod = "Select Contract_Date,Description from Tbl_Payment where Payment_ID=" & Val(pay_mod_id.Text)
                            cmd_chkmod.CommandText = str_chkmod
                            cmd_chkmod.Connection = open_con.return_con
                            cmd_chkmod.ExecuteNonQuery()

                            Dim adap_chkmod As SqlDataAdapter
                            adap_chkmod = New SqlDataAdapter(cmd_chkmod)
                            adap_chkmod.Fill(ds_chkmod)
                            adap_chkmod.Dispose()
                            If ds_chkmod.Tables(0).Rows(0).Item(0).ToString = "" Then
                                str_chkpay = "insert into tbl_payment(Customer_ID,Loan_ID,Description,Amount,Due_Date,Payment_Method,Date_Updated,Update_ID)values(@Customer_ID,@Loan_ID,@Description,@Amount,@Due_Date,@Payment_Method,@Date_Updated,@Update_ID)"
                                cmd_chkpay.CommandText = str_chkpay
                                cmd_chkpay.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
                                cmd_chkpay.Parameters.Add("@Loan_ID", SqlDbType.Int).Value = loan_id_new
                                cmd_chkpay.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = ds_chkmod.Tables(0).Rows(0).Item(1).ToString
                                cmd_chkpay.Parameters.Add("@Amount", SqlDbType.VarChar, 50).Value = txtamt_chkmod_new.Text
                                cmd_chkpay.Parameters.Add("@Due_Date", SqlDbType.DateTime).Value = txtdt_chkmod_new.Text
                                cmd_chkpay.Parameters.Add("@Payment_Method", SqlDbType.VarChar, 50).Value = paymethod_chkmod_new.SelectedItem.Text
                                cmd_chkpay.Parameters.Add("@Date_Updated", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                                cmd_chkpay.Parameters.Add("@Update_ID", SqlDbType.Int).Value = Val(pay_mod_id.Text)
                                cmd_chkpay.Connection = open_con.return_con
                                cmd_chkpay.ExecuteNonQuery()
                                cmd_chkpay.Dispose()
                                ds_chkmod.Dispose()
                            Else

                                contract_date = ds_chkmod.Tables(0).Rows(0).Item(0).ToString
                                str_chkpay = "insert into tbl_payment(Customer_ID,Loan_ID,Description,Amount,Due_Date,Contract_Date,Payment_Method,Date_Updated,Update_ID)values(@Customer_ID,@Loan_ID,@Description,@Amount,@Due_Date,@Contract_Date,@Payment_Method,@Date_Updated,@Update_ID)"
                                cmd_chkpay.CommandText = str_chkpay
                                cmd_chkpay.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
                                cmd_chkpay.Parameters.Add("@Loan_ID", SqlDbType.Int).Value = loan_id_new
                                cmd_chkpay.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = ds_chkmod.Tables(0).Rows(0).Item(1).ToString
                                cmd_chkpay.Parameters.Add("@Amount", SqlDbType.VarChar, 50).Value = txtamt_chkmod_new.Text
                                cmd_chkpay.Parameters.Add("@Due_Date", SqlDbType.DateTime).Value = txtdt_chkmod_new.Text
                                cmd_chkpay.Parameters.Add("@Contract_Date", SqlDbType.DateTime).Value = ds_chkmod.Tables(0).Rows(0).Item(0).ToString
                                cmd_chkpay.Parameters.Add("@Payment_Method", SqlDbType.VarChar, 50).Value = paymethod_chkmod_new.Text
                                cmd_chkpay.Parameters.Add("@Date_Updated", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                                cmd_chkpay.Parameters.Add("@Update_ID", SqlDbType.Int).Value = Val(pay_mod_id.Text)
                                cmd_chkpay.Connection = open_con.return_con
                                cmd_chkpay.ExecuteNonQuery()
                                cmd_chkpay.Dispose()



                            End If
                            ds_chkmod.Dispose()
                            cmd_chkmod.Dispose()
                        End If



                    Next
                    Dim str_pay_new As String
                    For k As Integer = 1 To Val(txtaddpaymnt.Text)

                        Dim cmd_pay As New SqlCommand
                        Dim txtamt_mod_new As New TextBox
                        txtamt_mod_new = Me.FindControl("txtamt_mod_new" & Format(k, "00"))

                        Dim txtdt_mod_new As New TextBox
                        txtdt_mod_new = Me.FindControl("txtdt_mod_new" & Format(k, "00"))

                        Dim paymethod_mod_new As New DropDownList
                        paymethod_mod_new = Me.FindControl("paymethod_mod_new" & Format(k, "00"))

                        str_pay_new = "insert into tbl_payment(Customer_ID,Loan_ID,Description,Amount,Due_Date,Payment_Method,Date_Updated)values(" & open_con.customer_id_val & "," & loan_id_new & ",@des," & txtamt_mod_new.Text & ",@due_date,'" & paymethod_mod_new.SelectedItem.Text & "',@date_updated)"
                        cmd_pay.Parameters.Add("@des", SqlDbType.VarChar, 255).Value = ""
                        '" & ds_chkmod.Tables(0).Rows(0).Item(1).ToString & "'
                        cmd_pay.Parameters.Add("@due_date", SqlDbType.DateTime).Value = CDate(txtdt_mod_new.Text)
                        cmd_pay.Parameters.Add("@date_updated", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                        cmd_pay.CommandText = str_pay_new
                        cmd_pay.Connection = open_con.return_con
                        cmd_pay.ExecuteNonQuery()
                        cmd_pay.Dispose()
                    Next
                    txtaddpaymnt.Text = ""
                    mod_reschedule(loan_id_new)
                    loan_id_new = 0
                    cancel_routine()
                    btnsave_mod.Visible = False
                    btncncl_mod.Visible = False
                    Session("tot_SinglePayment") = 0
                    Session("tot_SinglePayment_new") = 0
                Else
                    check_money()
                End If





                ''''''''''''''''''''''''''''''''''''''''''''''

            End If
           
        Catch ex As Exception

            'Session("tot_SinglePayment") = 0
            'Session("tot_SinglePayment_new") = 0

            'Response.Write("Error: " & ex.Message)
            'If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
            '    ds_loan = open_con.calculate_loan_repay(Session("beg_loan_id"))
            '    show_loan_repay(ds_loan)

            'ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then

            '    ds_loan = open_con.calculate_loan_repay(Session("beg_loan_id"))
            '    show_loan_repay(ds_loan)

            'ElseIf Session("flag_approve") = True Then

            '    ds_loan = open_con.calculate_loan_repay(Session("cur_loan_id"))
            '    show_loan_repay(ds_loan)

            'End If
            'txtaddpaymnt.Text = ""
            btnwaive.Visible = True
            btnsave_mod.Visible = False
            btncncl_mod.Visible = False
            btnacpt.Visible = True
            btncancel.Visible = True
            btnenfee.Visible = True
            btnmodsch.Visible = True
            btnshow.Visible = True
            btnmake_dis.Visible = False
            btncon_dis.Visible = False

        End Try



    End Sub
    Sub create_controls()

        If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
            ds_loan = find_repay(Session("beg_loan_id"))
            out_come(Session("beg_loan_id"))
        ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
            ds_loan = find_repay(Session("beg_loan_id"))
            out_come(Session("beg_loan_id"))
        ElseIf Session("flag_approve") = True Then
            ds_loan = find_repay(Session("cur_loan_id"))
            out_come(Session("cur_loan_id"))
        ElseIf Session("flag_approve") = False And Session("flag_beginning") = True Then
            ds_loan = find_repay(Session("beg_loan_id"))
            out_come(Session("beg_loan_id"))
        ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then
            ds_loan = find_repay(Session("cur_loan_id"))
            out_come(Session("cur_loan_id"))

        ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False And Session("beg_status") <> "Declined" Then
            ds_loan = find_repay(Session("cur_loan_id"))
            out_come(Session("cur_loan_id"))
        ElseIf Session("beg_status") = "Declined" Then
            ds_loan = find_repay(Session("beg_loan_id"))
            out_come(Session("beg_loan_id"))
        Else
            If Val(Session("beg_loan_id")) <> 0 Then
                ds_loan = find_repay(Session("beg_loan_id"))
                out_come(Session("beg_loan_id"))
            Else
                ds_loan = find_repay(Session("cur_loan_id"))
                out_come(Session("cur_loan_id"))
            End If
        End If
    End Sub

    Sub show_dis()
        For i As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
            If ds_loan.Tables(0).Rows(i).Item("Payment_Method").ToString = "NAB" And ds_loan.Tables(0).Rows(i).Item("Payment_Status").ToString = "Paid" And ds_loan.Tables(0).Rows(i).Item("Transaction_Status").ToString = "Dishonour" Then

                btnmake_dis.Enabled = False
                btncon_dis.Enabled = False
                btnmake_dis.Visible = False
                btncon_dis.Visible = False
                Dim radio_vis As New RadioButton
                If i < 10 Then
                    radio_vis = Me.FindControl("radio_repay" & "0" & i)
                    radio_vis.Visible = False
                Else
                    radio_vis = Me.FindControl("radio_repay" & i)
                    radio_vis.Visible = False
                End If

            ElseIf ds_loan.Tables(0).Rows(i).Item("Payment_Method").ToString = "CBA" And ds_loan.Tables(0).Rows(i).Item("Payment_Status").ToString = "Paid" And ds_loan.Tables(0).Rows(i).Item("Transaction_Status").ToString = "Dishonour" Then

                btnmake_dis.Enabled = False
                btncon_dis.Enabled = False
                btnmake_dis.Visible = False
                btncon_dis.Visible = False
                Dim radio_vis As New RadioButton
                If i < 10 Then
                    radio_vis = Me.FindControl("radio_repay" & "0" & i)
                    radio_vis.Visible = False
                Else
                    radio_vis = Me.FindControl("radio_repay" & i)
                    radio_vis.Visible = False
                End If
                '''''''''''''''''''''' for sal '''''''''''
            ElseIf ds_loan.Tables(0).Rows(i).Item("Payment_Method").ToString = "Sal" And ds_loan.Tables(0).Rows(i).Item("Payment_Status").ToString = "Paid" And ds_loan.Tables(0).Rows(i).Item("Transaction_Status").ToString = "Dishonour" Then

                btnmake_dis.Enabled = False
                btncon_dis.Enabled = False
                btnmake_dis.Visible = False
                btncon_dis.Visible = False
                Dim radio_vis As New RadioButton
                If i < 10 Then
                    radio_vis = Me.FindControl("radio_repay" & "0" & i)
                    radio_vis.Visible = False
                Else
                    radio_vis = Me.FindControl("radio_repay" & i)
                    radio_vis.Visible = False
                End If

            ElseIf ds_loan.Tables(0).Rows(i).Item("Payment_Method").ToString = "NAB" And ds_loan.Tables(0).Rows(i).Item("Payment_Status").ToString = "Paid" And ds_loan.Tables(0).Rows(i).Item("Transaction_Status").ToString <> "Dishonour" Then
                btnmake_dis.Enabled = True
                btncon_dis.Enabled = True
                btnmake_dis.Visible = True
                btncon_dis.Visible = True
                Dim radio_vis As New RadioButton
                If i < 10 Then
                    radio_vis = Me.FindControl("radio_repay" & "0" & i)
                    radio_vis.Visible = True
                Else
                    radio_vis = Me.FindControl("radio_repay" & i)
                    radio_vis.Visible = True
                End If
                Exit For
            ElseIf ds_loan.Tables(0).Rows(i).Item("Payment_Method").ToString = "CBA" And ds_loan.Tables(0).Rows(i).Item("Payment_Status").ToString = "Paid" And ds_loan.Tables(0).Rows(i).Item("Transaction_Status").ToString <> "Dishonour" Then
                btnmake_dis.Enabled = True
                btncon_dis.Enabled = True
                btnmake_dis.Visible = True
                btncon_dis.Visible = True
                Dim radio_vis As New RadioButton
                If i < 10 Then
                    radio_vis = Me.FindControl("radio_repay" & "0" & i)
                    radio_vis.Visible = True
                Else
                    radio_vis = Me.FindControl("radio_repay" & i)
                    radio_vis.Visible = True
                End If
                Exit For
                ''for sal
            ElseIf ds_loan.Tables(0).Rows(i).Item("Payment_Method").ToString = "Sal" And ds_loan.Tables(0).Rows(i).Item("Payment_Status").ToString = "Paid" And ds_loan.Tables(0).Rows(i).Item("Transaction_Status").ToString <> "Dishonour" Then
                btnmake_dis.Enabled = True
                btncon_dis.Enabled = True
                btnmake_dis.Visible = True
                btncon_dis.Visible = True
                Dim radio_vis As New RadioButton
                If i < 10 Then
                    radio_vis = Me.FindControl("radio_repay" & "0" & i)
                    radio_vis.Visible = True
                Else
                    radio_vis = Me.FindControl("radio_repay" & i)
                    radio_vis.Visible = True
                End If
                Exit For
            Else
                btnmake_dis.Enabled = False
                btncon_dis.Enabled = False
                btnmake_dis.Visible = False
                btncon_dis.Visible = False
            End If

        Next

        '''''''''''''''for getting radio button on all paid nab payments
        For k As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
            If ds_loan.Tables(0).Rows(k).Item("Payment_Method").ToString = "NAB" And ds_loan.Tables(0).Rows(k).Item("Payment_Status").ToString = "Paid" And ds_loan.Tables(0).Rows(k).Item("Transaction_Status").ToString <> "Dishonour" Then

                Dim radio_vis1 As New RadioButton

                If k < 10 Then
                    radio_vis1 = Me.FindControl("radio_repay" & "0" & k)
                    radio_vis1.Visible = True
                Else
                    radio_vis1 = Me.FindControl("radio_repay" & k)
                    radio_vis1.Visible = True
                End If

            Else
            End If
        Next
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''for getting radio button on all paid cba payments
        For k As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
            If ds_loan.Tables(0).Rows(k).Item("Payment_Method").ToString = "CBA" And ds_loan.Tables(0).Rows(k).Item("Payment_Status").ToString = "Paid" And ds_loan.Tables(0).Rows(k).Item("Transaction_Status").ToString <> "Dishonour" Then

                Dim radio_vis1 As New RadioButton

                If k < 10 Then
                    radio_vis1 = Me.FindControl("radio_repay" & "0" & k)
                    radio_vis1.Visible = True
                Else
                    radio_vis1 = Me.FindControl("radio_repay" & k)
                    radio_vis1.Visible = True
                End If

            Else
            End If
        Next


        '''''''''''''''''for getting radio button on all paid Sal payments
        For k As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
            If ds_loan.Tables(0).Rows(k).Item("Payment_Method").ToString = "Sal" And ds_loan.Tables(0).Rows(k).Item("Payment_Status").ToString = "Paid" And ds_loan.Tables(0).Rows(k).Item("Transaction_Status").ToString <> "Dishonour" Then

                Dim radio_vis1 As New RadioButton

                If k < 10 Then
                    radio_vis1 = Me.FindControl("radio_repay" & "0" & k)
                    radio_vis1.Visible = True
                Else
                    radio_vis1 = Me.FindControl("radio_repay" & k)
                    radio_vis1.Visible = True
                End If

            Else
            End If
        Next

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        For j As Integer = 0 To ds_loan.Tables(0).Rows.Count - 1
            If ds_loan.Tables(0).Rows(j).Item("Payment_Status").ToString <> "Paid" Then
                btnwaive.Visible = True
                btnacpt.Visible = True
                btncancel.Visible = True
                btnenfee.Visible = True
                btnmodsch.Visible = True
                btnshow.Visible = True
                Exit For
            Else

                btnshow.Visible = False
                btnwaive1.Visible = False
                btncncl.Visible = False
                btnwaive.Visible = False
                btnacpt.Visible = False
                btncancel.Visible = False
                btnenfee.Visible = True
                btnmodsch.Visible = False

            End If
        Next
    End Sub
    Sub out_come(ByVal loan_id_new As Integer)
        Try

            If Session("loan_summ") = True And Session("show_msg") = True Then

            Else
                Session("amtpaid") = open_con.amount_settled(loan_id_new)
            End If
            Dim control_txtpaid As New TextBox
            Dim controlid1 As Control = Page.FindControl("tool_6")
            control_txtpaid = controlid1.FindControl("txtamtpaid")
            Dim amtpaid As Double
            amtpaid = Session("amtpaid")
            control_txtpaid.Text = open_con.newamount(amtpaid)
            If Session("loan_summ") = True And Session("show_msg") = True Then

            Else
                Session("balout") = open_con.outstanding_amt(loan_id_new)
            End If

            Dim control_txtamt As New TextBox
            Dim controlid2 As Control = Page.FindControl("tool_6")
            control_txtamt = controlid2.FindControl("txtamtout")
            Dim balout As Double
            balout = Session("balout")
            control_txtamt.Text = open_con.newamount(balout)

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Sub valid_date_enf()
        btnwaive.Visible = False
        btnenfrc.Visible = True
        btncncl_enf.Visible = True
        btnacpt.Visible = False
        btncancel.Visible = False
        btnenfee.Visible = False
        btnmodsch.Visible = False
        btnshow.Visible = False
        btnmake_dis.Visible = False
        btncon_dis.Visible = False
    End Sub
    Sub valid_date_pay()
        btnwaive.Visible = False
        btncncl_pay.Visible = True
        btnsave_pay.Visible = True
        btnacpt.Visible = False
        btncancel.Visible = False
        btnenfee.Visible = False
        btnmodsch.Visible = False
        btnshow.Visible = False
        btnmake_dis.Visible = False
        btncon_dis.Visible = False
    End Sub
    Sub valid_cancel_sch()
        btnwaive.Visible = False
        btncncl_save.Visible = True
        btncnl_cncl.Visible = True
        btnacpt.Visible = False
        btncancel.Visible = False
        btnenfee.Visible = False
        btnmodsch.Visible = False
        btnshow.Visible = False
        btnmake_dis.Visible = False
        btncon_dis.Visible = False
    End Sub
    Sub valid_dis_sch()
        btnwaive.Visible = False
        btnsave_dis.Visible = True
        btncncl_dis.Visible = True
        btnacpt.Visible = False
        btncancel.Visible = False
        btnenfee.Visible = False
        btnmodsch.Visible = False
        btnshow.Visible = False
        btnmake_dis.Visible = False
        btncon_dis.Visible = False
    End Sub

    Protected Sub btnmake_dis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmake_dis.Click
        Try
            set_panel()
            Dim j As Integer
            Dim cal_count As Integer = 0
            Session("contract_dis") = False
            For j = 0 To Session("count") - 1

                Dim radio_dis As New RadioButton
                If cal_count < 10 Then
                    radio_dis = Me.FindControl("radio_repay" & "0" & j)
                Else
                    radio_dis = Me.FindControl("radio_repay" & j)
                End If

                If radio_dis.Checked = True Then

                    Dim payment_method As New DropDownList
                    If cal_count < 10 Then
                        payment_method = Me.FindControl("drop" & "0" & j)
                    Else
                        payment_method = Me.FindControl("drop" & j)
                    End If
                    Session("payment_method") = payment_method.SelectedItem.Text


                    If payment_method.SelectedItem.Text = "NAB" And Session("payment_method") = "NAB" Then
                        Session("enable") = "True"
                    ElseIf payment_method.SelectedItem.Text = "CBA" And Session("payment_method") = "CBA" Then
                        Session("enable") = "True"
                    ElseIf payment_method.SelectedItem.Text = "Sal" And Session("payment_method") = "Sal" Then
                        Session("enable") = "True"
                    Else
                        Session("enable") = "False"
                    End If


                    Dim trans_date As New TextBox
                    If cal_count < 10 Then
                        trans_date = Me.FindControl("txttrans_date" & "0" & j)
                    Else
                        trans_date = Me.FindControl("txttrans_date" & j)
                    End If
                    Session("trans_date") = trans_date.Text


                    Dim trans_des As New TextBox
                    If cal_count < 10 Then
                        trans_des = Me.FindControl("txttrans_des" & "0" & j)
                    Else
                        trans_des = Me.FindControl("txttrans_des" & j)
                    End If
                    trans_des.Text = "Dishonour"
                    Session("trans_des") = "Dishonour"


                    Dim txt_amt As TextBox = Me.FindControl("txtamt" & Format(j, "00"))
                    Session("txt_amt") = txt_amt.Text

                    Dim lbl1 As Label = Me.FindControl("lab1" & Format(j, "00"))

                    If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("beg_loan_id")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''
                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("beg_loan_id")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ElseIf Session("flag_approve") = True Then
                        ds_loan = find_repay(Session("cur_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("cur_loan_id")

                    End If

                    '''''''''''''''''''''''''''''''' Providing row nos to upadte for cancel schedule
                    Session("count_cncl") = j
                    Session("count_cncl_dis") = j + 1
                    Session("count_cncl_var") = j + 2

                    dishonour_schedule()
                    btnsave_dis.Visible = True
                    btncncl_dis.Visible = True
                    btncncl_save.ForeColor = Drawing.Color.Red
                    btnshow.Visible = False
                    btnacpt.Visible = False
                    btnenfee.Visible = False
                    btnmodsch.Visible = False
                    btnwaive.Visible = False
                    btncancel.Visible = False
                    '''''''''''''''''''''''''''''''''second line
                    btnwaive1.Visible = False
                    btncncl.Visible = False
                    btnenfrc.Visible = False
                    btncncl_enf.Visible = False
                    btncncl_pay.Visible = False
                    btnsave_pay.Visible = False
                    btnmake_dis.Visible = False
                    btncon_dis.Visible = False
                    btnmake_dis.Visible = False
                    btncon_dis.Visible = False
                    Exit For
                Else
                    cal_count = cal_count + 1
                End If
            Next

            If cal_count = Session("count") Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select the payment by clicking on the radio button." & "');", True)
            Else
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub

    Sub dishonour_schedule()

        txtPaymentAmount.Text = ""
        lblReturn.Visible = False
        Dim label_8 As Label = Me.FindControl("lab8" & Format(Session("count_cncl"), "00"))
        label_8.Visible = True

        Dim label_7 As Label = Me.FindControl("lab7" & Format(Session("count_cncl"), "00"))
        label_7.Visible = True

        Dim txttrans_des As TextBox = Me.FindControl("txttrans_des" & Format(Session("count_cncl"), "00"))
        txttrans_des.Visible = True
        txttrans_des.Text = "Dishonour"
        Dim txttrans_date As TextBox = Me.FindControl("txttrans_date" & Format(Session("count_cncl"), "00"))
        txttrans_date.Visible = True

        Dim tbl_Dishonour As New Table
        tbl_Dishonour = PlaceHolder1.FindControl("tbl_dynamic")
        tbl_Dishonour.ID = "tbl_Dishonour"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim tr_dis_new As New TableRow()
        Dim td_dis_new As New TableCell()

        td_dis_new.Style.Add("border-style", "solid")
        td_dis_new.Style.Add("border-width", "1px")
        td_dis_new.Style.Add(" border-color", "gray")
        td_dis_new.Style.Add("border-style", "solid")
        td_dis_new.Style.Add("border-width", "1px")
        td_dis_new.Style.Add(" border-color", "gray")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_dis_new As Label = New Label()
        label_dis_new.Width = "30"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label1_dis_new As Label = New Label()
        label1_dis_new.Width = "30"
        ''''''''''''''''''''''''''''''''''''''''''''''
        Dim drop_dis_new As Label = New Label
        drop_dis_new.Width = "110"
        drop_dis_new.Text = ""
        drop_dis_new.Style.Add("font-size", "12px")
        drop_dis_new.Style.Add("font-family", "MS Sans Serif")
        drop_dis_new.Style.Add("font-weight", "bold")
        drop_dis_new.Style.Add("text-align", "center")
        ''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_check_dis_new As Label = New Label()
        label_check_dis_new.Width = "20"
        ''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtdt_dis_new As TextBox = New TextBox
        txtdt_dis_new.ID = "txtdt_dis_new" & Format(Session("count_cncl"), "00")
        txtdt_dis_new.Width = "80"
        txtdt_dis_new.Style.Add("font-size", "12px")
        txtdt_dis_new.Style.Add("font-family", "MS Sans Serif")
        txtdt_dis_new.Style.Add("font-weight", "bold")
        txtdt_dis_new.Style.Add("text-align", "center")
        txtdt_dis_new.Style.Add("border-color", "gray")
        txtdt_dis_new.Style.Add("border-style", "solid")
        txtdt_dis_new.Style.Add("background-color", "red")
        txtdt_dis_new.Style.Add("border-width", "1px")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label3_dis_new_new As Label = New Label
        label3_dis_new_new.Text = "$"
        label3_dis_new_new.Width = "20"
        label3_dis_new_new.Style.Add("font-size", "12px")
        label3_dis_new_new.Style.Add("font-family", "MS Sans Serif")
        label3_dis_new_new.Style.Add("font-weight", "bold")
        label3_dis_new_new.Style.Add("text-align", "right")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtamt_dis_new As TextBox = New TextBox
        txtamt_dis_new.ID = "txtamt_dis_new" & Format(Session("count_cncl"), "00")
        txtamt_dis_new.Width = "50"
        txtamt_dis_new.Style.Add("font-size", "12px")
        txtamt_dis_new.Style.Add("font-family", "MS Sans Serif")
        txtamt_dis_new.Style.Add("font-weight", "bold")
        txtamt_dis_new.Style.Add("text-align", "left")
        txtamt_dis_new.Style.Add("border-color", "gray")
        txtamt_dis_new.Style.Add("border-style", "solid")
        txtamt_dis_new.Style.Add("border-width", "1px")
        txtamt_dis_new.Style.Add("background-color", "red")
        txtamt_dis_new.ReadOnly = True
        txtamt_dis_new.Text = Session("txt_amt")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pay_dis_new_new As LinkButton = New LinkButton
        pay_dis_new_new.Width = "30"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtpaydt_dis_new_new As Label = New Label
        txtpaydt_dis_new_new.Width = "100"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label4_dis_new_new As Label = New Label
        label4_dis_new_new.Width = "20"
        label4_dis_new_new.Text = ""
        '''''''''''''''''''''''''''''''''''''''''''''''''''''


        Dim drop1_dis_new As DropDownList = New DropDownList
        drop1_dis_new.ID = "paymethod_dis_new" & Format(Session("count_cncl"), "00")
        drop1_dis_new.Width = "90"
        drop1_dis_new.Style.Add("font-size", "12px")
        drop1_dis_new.Style.Add("font-family", "MS Sans Serif")
        drop1_dis_new.Style.Add("font-weight", "bold")
        drop1_dis_new.Style.Add("text-align", "center")
        drop1_dis_new.Items.Add("NAB")
        drop1_dis_new.Items.Add("Cas")
        drop1_dis_new.Items.Add("Sal")
        drop1_dis_new.Items.Add("Chq")
        drop1_dis_new.Items.Add("CBA")
        drop1_dis_new.Items.Add("Cre")
        drop1_dis_new.Items.Add("Def")
        drop1_dis_new.Items.Add("HOD")
        drop1_dis_new.Items.Add("WOF")
        If Session("enable") = "True" And Session("payment_method") = "NAB" Then
            drop1_dis_new.SelectedItem.Text = "NAB"
        ElseIf Session("enable") = "True" And Session("payment_method") = "CBA" Then
            drop1_dis_new.SelectedItem.Text = "CBA"
        ElseIf Session("enable") = "True" And Session("payment_method") = "Sal" Then
            drop1_dis_new.SelectedItem.Text = "Sal"
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label6_dis_new As Label = New Label
        label6_dis_new.Text = ""
        label6_dis_new.Width = "40"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ca_dis_new As New CalendarExtender
        ca_dis_new.ID = "ca_new"
        ca_dis_new.Format = "dd-MMM-yyyy"
        ca_dis_new.TargetControlID = txtdt_dis_new.ID
        ca_dis_new.CssClass = "red"
        ca_dis_new.OnClientShowing = "showDate"
        ca_dis_new.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        td_dis_new.Controls.Add(label_dis_new)
        td_dis_new.Controls.Add(label1_dis_new)
        td_dis_new.Controls.Add(drop_dis_new)
        td_dis_new.Controls.Add(label_check_dis_new)
        td_dis_new.Controls.Add(txtdt_dis_new)
        td_dis_new.Controls.Add(ca_dis_new)
        td_dis_new.Controls.Add(label3_dis_new_new)
        td_dis_new.Controls.Add(txtamt_dis_new)
        td_dis_new.Controls.Add(pay_dis_new_new)
        td_dis_new.Controls.Add(txtpaydt_dis_new_new)
        td_dis_new.Controls.Add(label4_dis_new_new)
        td_dis_new.Controls.Add(drop1_dis_new)
        td_dis_new.Controls.Add(label6_dis_new)
        tr_dis_new.Controls.Add(td_dis_new)
        tbl_Dishonour.Controls.AddAt(Session("count_cncl") + 2, tr_dis_new) 'index so zero based, zero = row 1   
        PlaceHolder1.Controls.Add(tbl_Dishonour)
        PlaceHolder1.Controls.Add(New LiteralControl("<br>"))

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim tr_dis_dis As New TableRow()
        Dim td_dis_dis As New TableCell()

        td_dis_dis.Style.Add("border-style", "solid")
        td_dis_dis.Style.Add("border-width", "1px")
        td_dis_dis.Style.Add(" border-color", "gray")
        tr_dis_dis.Style.Add("border-style", "solid")
        tr_dis_dis.Style.Add("border-width", "1px")
        tr_dis_dis.Style.Add(" border-color", "gray")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_dis_dis As Label = New Label()
        label_dis_dis.Width = "30"
        label_dis_dis.Style.Add("font-size", "12px")
        label_dis_dis.Style.Add("font-family", "MS Sans Serif")
        label_dis_dis.Style.Add("font-weight", "bold")
        label_dis_dis.Style.Add("text-align", "left")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label1_dis_dis As Label = New Label()
        label1_dis_dis.Width = "30"
        label1_dis_dis.Style.Add("font-size", "12px")
        label1_dis_dis.Style.Add("font-family", "MS Sans Serif")
        label1_dis_dis.Style.Add("font-weight", "bold")
        label1_dis_dis.Style.Add("text-align", "center")

        ''''''''''''''''''''''''''''''''''''''''''''''
        Dim drop_dis_dis As TextBox = New TextBox
        drop_dis_dis.Width = "110"
        drop_dis_dis.Text = "Dishonoured fee"
        drop_dis_dis.Style.Add("font-size", "12px")
        drop_dis_dis.Style.Add("font-family", "MS Sans Serif")
        drop_dis_dis.Style.Add("font-weight", "bold")
        drop_dis_dis.Style.Add("text-align", "center")
        drop_dis_dis.ReadOnly = True

        If Session("enable") = "True" Then
            drop_dis_dis.Style.Add("background-color", "red")
            drop_dis_dis.Enabled = True
        Else
            drop_dis_dis.Enabled = False
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_check_dis_dis As Label = New Label()
        label_check_dis_dis.Width = "15"
        ''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtdt_dis_dis As TextBox = New TextBox
        txtdt_dis_dis.ID = "txtdt_dis_dis" & Format(Session("count_cncl_dis"), "00")
        txtdt_dis_dis.Width = "80"
        txtdt_dis_dis.Style.Add("font-size", "12px")
        txtdt_dis_dis.Style.Add("font-family", "MS Sans Serif")
        txtdt_dis_dis.Style.Add("font-weight", "bold")
        txtdt_dis_dis.Style.Add("text-align", "center")
        txtdt_dis_dis.Style.Add("border-color", "gray")
        txtdt_dis_dis.Style.Add("border-style", "solid")
        txtdt_dis_dis.Style.Add("border-width", "1px")
        txtdt_dis_dis.Enabled = False
        If Session("enable") = "True" Then
            txtdt_dis_dis.Style.Add("background-color", "red")
            txtdt_dis_dis.Enabled = True
        Else
            txtdt_dis_dis.Enabled = False
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label3_new_dis_dis As Label = New Label
        label3_new_dis_dis.Text = "$"
        label3_new_dis_dis.Width = "20"
        label3_new_dis_dis.Style.Add("font-size", "12px")
        label3_new_dis_dis.Style.Add("font-family", "MS Sans Serif")
        label3_new_dis_dis.Style.Add("font-weight", "bold")
        label3_new_dis_dis.Style.Add("text-align", "right")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtamt_dis_dis As TextBox = New TextBox
        txtamt_dis_dis.ID = "txtamt_dis_dis" & Format(Session("count_cncl_dis"), "00")
        txtamt_dis_dis.Width = "50"
        txtamt_dis_dis.Style.Add("font-size", "12px")
        txtamt_dis_dis.Style.Add("font-family", "MS Sans Serif")
        txtamt_dis_dis.Style.Add("font-weight", "bold")
        txtamt_dis_dis.Style.Add("text-align", "left")
        txtamt_dis_dis.Style.Add("border-color", "gray")
        txtamt_dis_dis.Style.Add("border-style", "solid")
        txtamt_dis_dis.Style.Add("border-width", "1px")
        If Session("enable") = "True" Then
            txtamt_dis_dis.Style.Add("background-color", "red")
            txtamt_dis_dis.Enabled = True

            If Session("contract_dis") = True Then

                If Session("cancel_pay1") < 200 Then
                    txtamt_dis_dis.Text = "30.00"
                    Session("var_fee") = 30
                ElseIf Session("cancel_pay1") = 200 Then
                    txtamt_dis_dis.Text = "30.00"
                    Session("var_fee") = 30
                Else

                    txtamt_dis_dis.Text = "30.00"
                    Session("dis_fee") = 30
                End If
            Else
                If Session("cancel_pay1") < 200 Then
                    txtamt_dis_dis.Text = "15.00"
                    Session("dis_fee") = 15
                ElseIf Session("cancel_pay1") = 200 Then
                    txtamt_dis_dis.Text = "15.00"
                    Session("dis_fee") = 15
                Else

                    txtamt_dis_dis.Text = "30.00"
                    Session("dis_fee") = 30
                End If
            End If


        Else
            txtamt_dis_dis.Enabled = False
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pay_new_dis_dis As LinkButton = New LinkButton
        pay_new_dis_dis.Width = "30"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtpaydt_new_dis_dis As Label = New Label
        txtpaydt_new_dis_dis.Width = "100"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label4_new_dis_dis As Label = New Label
        label4_new_dis_dis.Width = "20"
        label4_new_dis_dis.Text = ""
        '''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim drop1_dis_dis As DropDownList = New DropDownList
        drop1_dis_dis.ID = "paymethod_dis_dis" & Format(Session("count_cncl_dis"), "00")
        drop1_dis_dis.Width = "90"
        drop1_dis_dis.Style.Add("font-size", "12px")
        drop1_dis_dis.Style.Add("font-family", "MS Sans Serif")
        drop1_dis_dis.Style.Add("font-weight", "bold")
        drop1_dis_dis.Style.Add("text-align", "center")
        drop1_dis_dis.Items.Add("NAB")
        drop1_dis_dis.Items.Add("Cas")
        drop1_dis_dis.Items.Add("Sal")
        drop1_dis_dis.Items.Add("Chq")
        drop1_dis_dis.Items.Add("CBA")
        drop1_dis_dis.Items.Add("Cre")
        drop1_dis_dis.Items.Add("Def")
        drop1_dis_dis.Items.Add("HOD")
        drop1_dis_dis.Items.Add("WOF")
        If Session("enable") = "True" And Session("payment_method") = "NAB" Then
            drop1_dis_dis.SelectedItem.Text = "NAB"
        ElseIf Session("enable") = "True" And Session("payment_method") = "CBA" Then
            drop1_dis_dis.SelectedItem.Text = "CBA"
        ElseIf Session("enable") = "True" And Session("payment_method") = "Sal" Then
            drop1_dis_dis.SelectedItem.Text = "Sal"
        Else
            drop1_dis_dis.Enabled = False
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label6_new_dis_dis As Label = New Label
        label6_new_dis_dis.Text = ""
        label6_new_dis_dis.Width = "40"


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ca_dis_dis As New CalendarExtender
        ca_dis_dis.ID = "ca_dis"
        ca_dis_dis.Format = "dd-MMM-yyyy"
        ca_dis_dis.TargetControlID = txtdt_dis_dis.ID
        ca_dis_dis.OnClientShowing = "showDate"
        ca_dis_dis.CssClass = "red"
        ca_dis_dis.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        td_dis_dis.Controls.Add(label_dis_dis)
        td_dis_dis.Controls.Add(label1_dis_dis)
        td_dis_dis.Controls.Add(drop_dis_dis)
        td_dis_dis.Controls.Add(label_check_dis_dis)
        td_dis_dis.Controls.Add(txtdt_dis_dis)
        td_dis_dis.Controls.Add(ca_dis_dis)
        td_dis_dis.Controls.Add(label3_new_dis_dis)
        td_dis_dis.Controls.Add(txtamt_dis_dis)
        td_dis_dis.Controls.Add(pay_new_dis_dis)
        td_dis_dis.Controls.Add(txtpaydt_new_dis_dis)
        td_dis_dis.Controls.Add(label4_new_dis_dis)
        td_dis_dis.Controls.Add(drop1_dis_dis)
        td_dis_dis.Controls.Add(label6_new_dis_dis)
        tr_dis_dis.Controls.Add(td_dis_dis)

        tbl_Dishonour.Controls.AddAt(Session("count_cncl") + 3, tr_dis_dis) 'index so zero based, zero = row 1   
        PlaceHolder1.Controls.Add(tbl_Dishonour)
        PlaceHolder1.Controls.Add(New LiteralControl("<br>"))


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tr_dis_var As New TableRow()
        Dim td_dis_var As New TableCell()

        td_dis_var.Style.Add("border-style", "solid")
        td_dis_var.Style.Add("border-width", "1px")
        td_dis_var.Style.Add(" border-color", "gray")
        tr_dis_var.Style.Add("border-style", "solid")
        tr_dis_var.Style.Add("border-width", "1px")
        tr_dis_var.Style.Add(" border-color", "gray")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_dis_var As Label = New Label()
        label_dis_var.Width = "30"
        label_dis_var.Style.Add("font-size", "12px")
        label_dis_var.Style.Add("font-family", "MS Sans Serif")
        label_dis_var.Style.Add("font-weight", "bold")
        label_dis_var.Style.Add("text-align", "left")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label1_dis_var As Label = New Label()
        label1_dis_var.Width = "30"
        label1_dis_var.Style.Add("font-size", "12px")
        label1_dis_var.Style.Add("font-family", "MS Sans Serif")
        label1_dis_var.Style.Add("font-weight", "bold")
        label1_dis_var.Style.Add("text-align", "center")

        ''''''''''''''''''''''''''''''''''''''''''''''
        Dim drop_dis_var As TextBox = New TextBox
        drop_dis_var.Width = "110"
        drop_dis_var.Text = "Variation fee"
        drop_dis_var.Style.Add("font-size", "12px")
        drop_dis_var.Style.Add("font-family", "MS Sans Serif")
        drop_dis_var.Style.Add("font-weight", "bold")
        drop_dis_var.Style.Add("text-align", "center")
        drop_dis_var.ReadOnly = True
        drop_dis_var.Style.Add("background-color", "red")
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label_check_dis_var As Label = New Label()
        label_check_dis_var.Width = "15"
        ''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtdt_dis_var As TextBox = New TextBox
        txtdt_dis_var.ID = "txtdt_dis_var" & Format(Session("count_cncl_var"), "00")
        txtdt_dis_var.Width = "80"
        txtdt_dis_var.Style.Add("font-size", "12px")
        txtdt_dis_var.Style.Add("font-family", "MS Sans Serif")
        txtdt_dis_var.Style.Add("font-weight", "bold")
        txtdt_dis_var.Style.Add("text-align", "center")
        txtdt_dis_var.Style.Add("border-color", "gray")
        txtdt_dis_var.Style.Add("background-color", "red")
        txtdt_dis_var.Style.Add("border-style", "solid")
        txtdt_dis_var.Style.Add("border-width", "1px")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label3_new_var As Label = New Label
        label3_new_var.Text = "$"
        label3_new_var.Width = "20"
        label3_new_var.Style.Add("font-size", "12px")
        label3_new_var.Style.Add("font-family", "MS Sans Serif")
        label3_new_var.Style.Add("font-weight", "bold")
        label3_new_var.Style.Add("text-align", "right")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtamt_dis_var As TextBox = New TextBox
        txtamt_dis_var.ID = "txtamt_dis_var" & Format(Session("count_cncl_var"), "00")
        txtamt_dis_var.Width = "50"
        txtamt_dis_var.Style.Add("font-size", "12px")
        txtamt_dis_var.Style.Add("font-family", "MS Sans Serif")
        txtamt_dis_var.Style.Add("font-weight", "bold")
        txtamt_dis_var.Style.Add("text-align", "left")
        txtamt_dis_var.Style.Add("border-color", "gray")
        txtamt_dis_var.Style.Add("border-style", "solid")
        txtamt_dis_var.Style.Add("border-width", "1px")
        txtamt_dis_var.Style.Add("background-color", "red")
        txtamt_dis_var.ReadOnly = False
        If Session("contract_dis") = True Then

            If Session("dis_var_pay1") < 200 Then
                txtamt_dis_var.Text = "50.00"
                Session("var_fee") = 50
            ElseIf Session("dis_var_pay1") = 200 Then
                txtamt_dis_var.Text = "50.00"
                Session("var_fee") = 50
            Else

                txtamt_dis_var.Text = "50.00"
                Session("var_fee") = 50
            End If
        Else
            If Session("dis_var_pay1") < 200 Then
                txtamt_dis_var.Text = "25.00"
                Session("var_fee") = 25
            ElseIf Session("dis_var_pay1") = 200 Then
                txtamt_dis_var.Text = "25.00"
                Session("var_fee") = 25
            Else

                txtamt_dis_var.Text = "50.00"
                Session("var_fee") = 50
            End If
        End If


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pay_new_var As LinkButton = New LinkButton
        pay_new_var.Width = "30"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim txtpaydt_new_var As Label = New Label
        txtpaydt_new_var.Width = "100"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label4_new_var As Label = New Label
        label4_new_var.Width = "20"
        label4_new_var.Text = ""

        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim drop1_dis_var As DropDownList = New DropDownList
        drop1_dis_var.ID = "paymethod_dis_var" & Format(Session("count_cncl_var"), "00")
        drop1_dis_var.Width = "90"
        drop1_dis_var.Style.Add("font-size", "12px")
        drop1_dis_var.Style.Add("font-family", "MS Sans Serif")
        drop1_dis_var.Style.Add("font-weight", "bold")
        drop1_dis_var.Style.Add("text-align", "center")
        drop1_dis_var.Items.Add("NAB")
        drop1_dis_var.Items.Add("Cas")
        drop1_dis_var.Items.Add("Sal")
        drop1_dis_var.Items.Add("Chq")
        drop1_dis_var.Items.Add("CBA")
        drop1_dis_var.Items.Add("Cre")
        drop1_dis_var.Items.Add("Def")
        drop1_dis_var.Items.Add("HOD")
        drop1_dis_var.Items.Add("WOF")
        If Session("enable") = "True" And Session("payment_method") = "NAB" Then
            drop1_dis_var.SelectedItem.Text = "NAB"
        ElseIf Session("enable") = "True" And Session("payment_method") = "CBA" Then
            drop1_dis_var.SelectedItem.Text = "CBA"
        ElseIf Session("enable") = "True" And Session("payment_method") = "Sal" Then
            drop1_dis_var.SelectedItem.Text = "Sal"
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim label6_new_var As Label = New Label
        label6_new_var.Text = ""
        label6_new_var.Width = "40"

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ca_var As New CalendarExtender
        ca_var.ID = "ca_var"
        ca_var.Format = "dd-MMM-yyyy"
        ca_var.TargetControlID = txtdt_dis_var.ID
        ca_var.OnClientShowing = "showDate"
        ca_var.CssClass = "red"
        ca_var.FirstDayOfWeek = WebControls.FirstDayOfWeek.Sunday
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        td_dis_var.Controls.Add(label_dis_var)
        td_dis_var.Controls.Add(label1_dis_var)
        td_dis_var.Controls.Add(drop_dis_var)
        td_dis_var.Controls.Add(label_check_dis_var)
        td_dis_var.Controls.Add(txtdt_dis_var)
        td_dis_var.Controls.Add(ca_var)
        td_dis_var.Controls.Add(label3_new_var)
        td_dis_var.Controls.Add(txtamt_dis_var)
        td_dis_var.Controls.Add(pay_new_var)
        td_dis_var.Controls.Add(txtpaydt_new_var)
        td_dis_var.Controls.Add(label4_new_var)
        td_dis_var.Controls.Add(drop1_dis_var)
        td_dis_var.Controls.Add(label6_new_var)
        tr_dis_var.Controls.Add(td_dis_var)

        tbl_Dishonour.Controls.AddAt(Session("count_cncl") + 4, tr_dis_var) 'index so zero based, zero = row 1   
        PlaceHolder1.Controls.Add(tbl_Dishonour)
        PlaceHolder1.Controls.Add(New LiteralControl("<br>"))
    End Sub

    Protected Sub btncncl_dis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncncl_dis.Click
        btnsave_dis.Visible = False
        btncncl_dis.Visible = False
        Session("contract_dis") = False
        cancel_routine()
        set_panel()
    End Sub
    Protected Sub btnsave_dis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave_dis.Click
        '''''''''''''''''''''''''''''''''''''''''''
        Try
            Dim txtdt_dis As New TextBox
            txtdt_dis = Me.FindControl("txtdt_dis_new" & Format(Session("count_cncl"), "00"))

            Session("new_date_dis") = txtdt_dis.Text
            If Session("new_date_dis") <> "" Then
                If Session("new_date_dis") < System.DateTime.Now.Date Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                    txtdt_dis.Focus()
                    valid_dis_sch()
                    Exit Sub
                Else

                End If

            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                txtdt_dis.Focus()
                valid_dis_sch()
                Exit Sub
            End If


            Dim txtpay_dis_new As New DropDownList
            txtpay_dis_new = Me.FindControl("paymethod_dis_new" & Format(Session("count_cncl"), "00"))
            Session("pay_method_new_dis") = txtpay_dis_new.SelectedItem.Text

            Dim txtamt_dis As New TextBox
            txtamt_dis = Me.FindControl("txtamt_dis_new" & Format(Session("count_cncl"), "00"))
            Session("new_amount_dis") = txtamt_dis.Text

            If txtdt_dis.Text <> "" Then
                Dim str_SQL_payment As String
                Dim cmd_dis As New SqlCommand
                Dim adap_dis As SqlDataAdapter
                Dim ds_dis As New DataSet
                Dim txt_Description As String
                Dim txt_ContractDate As String
                Dim amt_dis As Double
                ''''''''''''''''''''this is the query to find description and contract date
                str_SQL_payment = " SELECT Tbl_Payment.Description, Tbl_Payment.Contract_Date,Amount "
                str_SQL_payment = str_SQL_payment & " FROM Tbl_Payment  "
                str_SQL_payment = str_SQL_payment & "  Where Loan_ID = " & Session("pay_id")
                str_SQL_payment = str_SQL_payment & "  AND Payment_ID = " & Session("payment_id")
                cmd_dis.CommandText = str_SQL_payment
                cmd_dis.Connection = open_con.return_con
                cmd_dis.ExecuteNonQuery()
                adap_dis = New SqlDataAdapter(cmd_dis)
                adap_dis.Fill(ds_dis)
                txt_Description = ds_dis.Tables(0).Rows(0).Item(0).ToString
                txt_ContractDate = ds_dis.Tables(0).Rows(0).Item(1).ToString
                amt_dis = ds_dis.Tables(0).Rows(0).Item(2).ToString
                adap_dis.Dispose()
                cmd_dis.Dispose()
                ds_dis.Dispose()
                ''''''''''''''''This is used to find the due amount to be saved in notice table

                Dim str_amount_due As String
                Dim amount_due As Double
                Dim dis_var_fee As String
                Dim dis_dis_fee As String
                str_amount_due = "SELECT Tbl_Payment.Loan_ID, Sum(Tbl_Payment.Amount) AS Amount_Outstanding FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID "
                str_amount_due = str_amount_due & "WHERE (((Tbl_Payment.Description)='Arear notice fee' Or (Tbl_Payment.Description)='Statement of account fee' Or (Tbl_Payment.Description)='Variation fee' Or (Tbl_Payment.Description)='Default notice fee' Or (Tbl_Payment.Description)='Letter of demand fee' Or (Tbl_Payment.Description)='Dishonoured fee' Or (Tbl_Payment.Description)='Enforcement fee' Or (Tbl_Payment.Description) Is Null OR Tbl_Payment.Description = '') AND ((Tbl_Payment.Transaction_Status) Is Null) AND ((Tbl_Payment.Payment_Date) Is Null) AND ((Tbl_Payment_1.Update_ID) Is Null)) "
                str_amount_due = str_amount_due & "GROUP BY Tbl_Payment.Loan_ID HAVING Tbl_Payment.Loan_ID=" & Session("pay_id") & "ORDER BY Tbl_Payment.Loan_ID "

                Dim cmd_amount_due_dis As New SqlCommand
                Dim adap_amount_due_dis As SqlDataAdapter
                Dim ds_amount_due_dis As New DataSet
                cmd_amount_due_dis.CommandText = str_amount_due
                cmd_amount_due_dis.Connection = open_con.return_con
                cmd_amount_due_dis.ExecuteNonQuery()
                adap_amount_due_dis = New SqlDataAdapter(cmd_amount_due_dis)
                adap_amount_due_dis.Fill(ds_amount_due_dis)

                If ds_amount_due_dis.Tables(0).Rows.Count = 0 Then
                    If Val(Session("var_fee")) <> 0 Then
                        dis_var_fee = CDbl(Session("var_fee"))
                    Else
                        dis_var_fee = 0
                    End If
                    If Val(Session("dis_fee")) <> 0 Then
                        dis_dis_fee = CDbl(Session("dis_fee"))
                    Else
                        dis_dis_fee = 0
                    End If

                    amount_due = amt_dis + dis_var_fee + dis_dis_fee
                    Session("amt_out_notice") = amount_due
                    Session("dis_fee") = ""
                    Session("var_fee") = ""

                Else


                    If Val(Session("var_fee")) <> 0 Then
                        dis_var_fee = Session("var_fee")
                    Else
                        dis_var_fee = 0
                    End If
                    If Val(Session("dis_fee")) <> 0 Then
                        dis_dis_fee = Session("dis_fee")
                    Else
                        dis_dis_fee = 0
                    End If

                    amount_due = ds_amount_due_dis.Tables(0).Rows(0).Item(1) + dis_var_fee + dis_dis_fee
                    amount_due = amt_dis + dis_var_fee + dis_dis_fee
                    Session("dis_fee") = ""
                    Session("var_fee") = ""

                End If



                cmd_amount_due_dis.Dispose()
                adap_amount_due_dis.Dispose()
                ds_amount_due_dis.Dispose()

                If Session("enable") = "True" Then
                    Dim txtamt_dis_dis As New TextBox
                    txtamt_dis_dis = Me.FindControl("txtamt_dis_dis" & Format(Session("count_cncl_dis"), "00"))
                    Session("new_amount_dis_dis") = txtamt_dis_dis.Text

                    Dim txtdt_dis_dis As New TextBox
                    txtdt_dis_dis = Me.FindControl("txtdt_dis_dis" & Format(Session("count_cncl_dis"), "00"))
                    Session("new_date_dis_dis") = txtdt_dis_dis.Text
                    If Session("new_date_dis_dis") <> "" Then
                        If Session("new_date_dis_dis") < System.DateTime.Now.Date Then
                            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                            txtdt_dis_dis.Focus()
                            valid_dis_sch()
                            Exit Sub
                        Else
                        End If
                    Else
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                        txtdt_dis_dis.Focus()
                        valid_dis_sch()
                        Exit Sub
                    End If
                    Dim txtdt_dis_var As New TextBox
                    txtdt_dis_var = Me.FindControl("txtdt_dis_var" & Format(Session("count_cncl_var"), "00"))
                    Session("new_date_var_dis") = txtdt_dis_var.Text

                    If Session("new_date_var_dis") <> "" Then
                        If Session("new_date_var_dis") < System.DateTime.Now.Date Then
                            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                            txtdt_dis_var.Focus()
                            valid_dis_sch()
                            Exit Sub
                        Else
                        End If
                    Else
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                        txtdt_dis_var.Focus()
                        valid_dis_sch()
                        Exit Sub
                    End If

                ElseIf Session("enable") = "False" Then

                    Dim txtdt_dis_var As New TextBox
                    txtdt_dis_var = Me.FindControl("txtdt_dis_var" & Format(Session("count_cncl_var"), "00"))
                    Session("new_date_var_dis") = txtdt_dis_var.Text

                    If Session("new_date_var_dis") <> "" Then
                        If Session("new_date_var_dis") < System.DateTime.Now.Date Then
                            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                            txtdt_dis_var.Focus()
                            valid_dis_sch()
                            Exit Sub
                        Else
                        End If
                    Else
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid date!!!" & "');", True)
                        txtdt_dis_var.Focus()
                        valid_dis_sch()
                        Exit Sub
                    End If

                Else
                    If Val(txtdt_dis.Text) = 0 Then
                        txtdt_dis.BackColor = Drawing.Color.Red
                    ElseIf Val(txtdt_dis.Text) = 0 Then
                        txtdt_dis.BackColor = Drawing.Color.Red
                    End If
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter valid Due Date!!!" & "');", True)

                    Exit Sub
                End If


                Dim str_SQL As String
                str_SQL = "Insert into Tbl_Notice(Customer_ID, Loan_ID, Payment_ID, Amount_OutStanding, Notice_Expires_On, Description, User_ID, Notice_Created_On) values "
                str_SQL = str_SQL & "(" & open_con.customer_id_val & "," & Session("pay_id") & "," & Session("payment_id") & ",@amt_out,"

                If Session("payment_method") = "NAB" And Session("contract_dis") = False Then
                    str_SQL = str_SQL & "@notice_expires,'Dishonour Letter'," & open_con.user_id_val & ",@notice_date)"
                ElseIf Session("payment_method") = "NAB" And Session("contract_dis") = True Then
                    str_SQL = str_SQL & "@notice_expires,'Contract Dishonour'," & open_con.user_id_val & ",@notice_date)"
                ElseIf Session("payment_method") = "CBA" And Session("contract_dis") = False Then
                    str_SQL = str_SQL & "@notice_expires,'Dishonour Letter'," & open_con.user_id_val & ",@notice_date)"
                ElseIf Session("payment_method") = "CBA" And Session("contract_dis") = True Then
                    str_SQL = str_SQL & "@notice_expires,'Contract Dishonour'," & open_con.user_id_val & ",@notice_date)"
                ElseIf Session("payment_method") = "Sal" And Session("contract_dis") = False Then
                    str_SQL = str_SQL & "@notice_expires,'Payroll Cancel'," & open_con.user_id_val & ",@notice_date)"
                ElseIf Session("payment_method") = "Sal" And Session("contract_dis") = True Then
                    str_SQL = str_SQL & "@notice_expires,'Contract Dishonour'," & open_con.user_id_val & ",@notice_date)"
                End If

                Dim cmd_notice_dis As New SqlCommand
                cmd_notice_dis.CommandText = str_SQL
                cmd_notice_dis.Parameters.Add("@amt_out", SqlDbType.VarChar, 50).Value = amount_due
                cmd_notice_dis.Parameters.Add("@notice_expires", SqlDbType.DateTime).Value = System.DateTime.Now.AddDays(2)
                cmd_notice_dis.Parameters.Add("@notice_date", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                cmd_notice_dis.Connection = open_con.return_con
                cmd_notice_dis.ExecuteNonQuery()
                cmd_notice_dis.Dispose()

                Dim str_sql1 As String
                str_sql1 = "Update Tbl_Payment set "
                str_sql1 = str_sql1 & " Description = NULL,"
                str_sql1 = str_sql1 & " Transaction_Status = 'Dishonour',"
                str_sql1 = str_sql1 & " Transaction_Date = @trans_date"
                str_sql1 = str_sql1 & "  Where Loan_ID = " & Session("pay_id")
                str_sql1 = str_sql1 & "  AND Payment_ID = " & Session("payment_id")

                Dim cmd_upd_payment_dis As New SqlCommand
                cmd_upd_payment_dis.CommandText = str_sql1
                cmd_upd_payment_dis.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                cmd_upd_payment_dis.Connection = open_con.return_con
                cmd_upd_payment_dis.ExecuteNonQuery()
                cmd_upd_payment_dis.Dispose()


                Dim strsql As String
                strsql = "SELECT Tbl_Notice.Notice_ID,Loan_ID "
                strsql = strsql & " FROM Tbl_Notice "
                strsql = strsql & " WHERE Tbl_Notice.Payment_ID = " & Session("payment_id")
                Dim cmd_get_noticeid_dis As New SqlCommand
                cmd_get_noticeid_dis.CommandText = strsql
                cmd_get_noticeid_dis.Connection = open_con.return_con
                cmd_get_noticeid_dis.ExecuteNonQuery()
                Dim adap_get_noticeid_dis As New SqlDataAdapter(cmd_get_noticeid_dis)
                Dim ds_get_noticeid_dis As New DataSet
                adap_get_noticeid_dis.Fill(ds_get_noticeid_dis)
                Dim notice_id As Integer
                notice_id = Val(ds_get_noticeid_dis.Tables(0).Rows(0).Item(0).ToString)
                adap_get_noticeid_dis.Dispose()
                ds_get_noticeid_dis.Dispose()
                cmd_get_noticeid_dis.Dispose()

                Dim cmd_dis_dis As New SqlCommand
                If txt_Description = "Arear notice fee" Or txt_Description = "Statement of account fee" Or txt_Description = "Variation fee" Or txt_Description = "Default notice fee" Or txt_Description = "Letter of demand fee" Or txt_Description = "Dishonoured fee" Or txt_Description = "Cencellation fee" Or txt_Description = "Enforcement fee" Then

                    str_SQL = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Notice_NO, Description, Due_Date, Amount, Payment_Method, Transaction_Date, Date_Updated) values "
                    str_SQL = str_SQL & "(" & Session("pay_id") & "," & open_con.customer_id_val & "," & notice_id & ",'" & txt_Description & "',@new_date," & Session("new_amount_dis") & ",'" & Session("pay_method_new_dis") & "',@trans_date,@date_updated)"
                    cmd_dis_dis.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                    cmd_dis_dis.Parameters.Add("@new_date", SqlDbType.DateTime).Value = Session("new_date_dis")
                    cmd_dis_dis.Parameters.Add("@date_updated", SqlDbType.DateTime).Value = System.DateTime.Now.Date
                ElseIf txt_ContractDate <> "" Then
                    str_SQL = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Notice_NO, Due_Date, Amount, Payment_Method, Transaction_Date, Date_Updated, Contract_Date) values "
                    str_SQL = str_SQL & "(" & Session("pay_id") & "," & open_con.customer_id_val & "," & notice_id & ",@new_date," & Session("new_amount_dis") & ",'" & Session("pay_method_new_dis") & "',@trans_date,@trans_date,@contract_date)"
                    cmd_dis_dis.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                    cmd_dis_dis.Parameters.Add("@new_date", SqlDbType.DateTime).Value = Session("new_date_dis")
                    cmd_dis_dis.Parameters.Add("@contract_date", SqlDbType.DateTime).Value = txt_ContractDate
                Else
                    str_SQL = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Notice_NO, Due_Date, Amount, Payment_Method, Transaction_Date, Date_Updated) values "
                    str_SQL = str_SQL & "(" & Session("pay_id") & "," & open_con.customer_id_val & "," & notice_id & ",@new_date," & Session("new_amount_dis") & ",'" & Session("pay_method_new_dis") & "',@trans_date,@trans_date)"
                    cmd_dis_dis.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                    cmd_dis_dis.Parameters.Add("@new_date", SqlDbType.DateTime).Value = Session("new_date_dis")
                End If

                cmd_dis_dis.CommandText = str_SQL
                cmd_dis_dis.Connection = open_con.return_con
                cmd_dis_dis.ExecuteNonQuery()
                cmd_dis_dis.Dispose()


                If Session("enable") = "True" Then

                    Dim pay_dis_dis As New DropDownList
                    pay_dis_dis = Me.FindControl("paymethod_dis_dis" & Format(Session("count_cncl_dis"), "00"))
                    Session("new_pay_dis_dis") = pay_dis_dis.SelectedItem.Text

                    Dim txtamt_dis_var As New TextBox
                    txtamt_dis_var = Me.FindControl("txtamt_dis_var" & Format(Session("count_cncl_var"), "00"))
                    If txtamt_dis_var.Text = "" Then
                        Session("new_amount_var_dis") = "0.0"
                    Else
                        Session("new_amount_var_dis") = txtamt_dis_var.Text
                    End If



                    Dim pay_dis_var As New DropDownList
                    pay_dis_var = Me.FindControl("paymethod_dis_var" & Format(Session("count_cncl_var"), "00"))
                    If pay_dis_var.SelectedItem.Text = "" Then
                        Session("new_pay_var_dis") = "0.0"
                    Else
                        Session("new_pay_var_dis") = pay_dis_var.SelectedItem.Text
                    End If


                    Dim str_SQL_dishonour As String
                    Dim cmd_dishonour As New SqlCommand
                    str_SQL_dishonour = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Notice_NO, Description, Due_Date, Amount, Payment_Method, Transaction_Date, Fee_Status, Date_Updated) values "
                    str_SQL_dishonour = str_SQL_dishonour & "(" & Session("pay_id") & "," & open_con.customer_id_val & "," & notice_id & ",'Dishonoured fee',@new_date_dis,@new_amt_dis,@new_pay_dis,@trans_date,'Dishonoured fee',@trans_date)"
                    cmd_dishonour.CommandText = str_SQL_dishonour
                    cmd_dishonour.Parameters.Add("@new_date_dis", SqlDbType.DateTime).Value = Session("new_date_dis_dis")
                    cmd_dishonour.Parameters.Add("@new_amt_dis", SqlDbType.VarChar, 50).Value = Session("new_amount_dis_dis")
                    cmd_dishonour.Parameters.Add("@new_pay_dis", SqlDbType.VarChar, 50).Value = Session("new_pay_dis_dis")
                    cmd_dishonour.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                    cmd_dishonour.Connection = open_con.return_con
                    cmd_dishonour.ExecuteNonQuery()
                    cmd_dishonour.Dispose()

                    Dim str_SQL_var As String
                    Dim cmd_var_dis As New SqlCommand
                    str_SQL_var = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Notice_NO, Description, Due_Date, Amount, Payment_Method, Transaction_Date, Fee_Status, Date_Updated) values "
                    str_SQL_var = str_SQL_var & "(" & Session("pay_id") & "," & open_con.customer_id_val & "," & notice_id & ",'Variation fee',@new_date_var,@new_amt_var,@new_pay_var,@trans_date,'Variation fee',@trans_date)"
                    cmd_var_dis.CommandText = str_SQL_var
                    cmd_var_dis.Parameters.Add("@new_date_var", SqlDbType.DateTime).Value = Session("new_date_var_dis")
                    cmd_var_dis.Parameters.Add("@new_amt_var", SqlDbType.VarChar, 50).Value = Session("new_amount_var_dis")
                    cmd_var_dis.Parameters.Add("@new_pay_var", SqlDbType.VarChar, 50).Value = Session("new_pay_var_dis")
                    cmd_var_dis.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                    cmd_var_dis.Connection = open_con.return_con
                    cmd_var_dis.ExecuteNonQuery()
                    cmd_var_dis.Dispose()

                ElseIf Session("enable") = "False" Then

                    Dim txtamt_dis_var As New TextBox
                    txtamt_dis_var = Me.FindControl("txtamt_dis_var" & Format(Session("count_cncl_var"), "00"))
                    If txtamt_dis_var.Text = "" Then
                        Session("new_amount_var_dis") = "0.0"
                    Else
                        Session("new_amount_var_dis") = txtamt_dis_var.Text

                    End If


                    Dim pay_cncl_var As New DropDownList
                    pay_cncl_var = Me.FindControl("paymethod_dis_var" & Format(Session("count_cncl_var"), "00"))
                    If pay_cncl_var.SelectedItem.Text = "" Then
                        Session("new_pay_var_dis") = "0.0"
                    Else
                        Session("new_pay_var_dis") = pay_cncl_var.SelectedItem.Text
                    End If


                    Dim str_SQL_var1 As String
                    Dim cmd_var1_dis As New SqlCommand
                    str_SQL_var1 = "Insert into Tbl_Payment(Loan_ID, Customer_ID, Notice_NO, Description, Due_Date, Amount, Payment_Method, Transaction_Date, Fee_Status, Date_Updated) values "
                    str_SQL_var1 = str_SQL_var1 & "(" & Session("pay_id") & "," & open_con.customer_id_val & "," & notice_id & ",'Variation fee',@new_date_var,@new_amt_var,@new_pay_var,@trans_date,'Variation fee',@trans_date)"
                    cmd_var1_dis.CommandText = str_SQL_var1
                    cmd_var1_dis.Parameters.Add("@new_date_var", SqlDbType.DateTime).Value = Session("new_date_var_dis")
                    cmd_var1_dis.Parameters.Add("@new_amt_var", SqlDbType.VarChar, 50).Value = Session("new_amount_var_dis")
                    cmd_var1_dis.Parameters.Add("@new_pay_var", SqlDbType.VarChar, 50).Value = Session("new_pay_var_dis")
                    cmd_var1_dis.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = Session("trans_date")
                    cmd_var1_dis.Connection = open_con.return_con
                    cmd_var1_dis.ExecuteNonQuery()
                    cmd_var1_dis.Dispose()
                End If

                cancel_routine()
                btnsave_dis.Visible = False
                btncncl_dis.Visible = False
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Payment is recorded as dishonoured and the letter is created." & "');", True)
            Else

            End If
            open_con.return_con.Dispose()

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
            valid_dis_sch()
        End Try
        ''''''''''''''''''''''''''''''
    End Sub

    Protected Sub btncon_dis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncon_dis.Click

        Try
            set_panel()
            Session("contract_dis") = True
            Dim j As Integer
            Dim cal_count As Integer = 0
            For j = 0 To Session("count") - 1

                Dim radio_dis As New RadioButton
                If cal_count < 10 Then
                    radio_dis = Me.FindControl("radio_repay" & "0" & j)
                Else
                    radio_dis = Me.FindControl("radio_repay" & j)
                End If

                If radio_dis.Checked = True Then

                    Dim payment_method As New DropDownList
                    If cal_count < 10 Then
                        payment_method = Me.FindControl("drop" & "0" & j)
                    Else
                        payment_method = Me.FindControl("drop" & j)
                    End If
                    Session("payment_method") = payment_method.SelectedItem.Text


                    If payment_method.SelectedItem.Text = "NAB" And Session("payment_method") = "NAB" Then
                        Session("enable") = "True"
                    ElseIf payment_method.SelectedItem.Text = "CBA" And Session("payment_method") = "CBA" Then
                        Session("enable") = "True"
                    ElseIf payment_method.SelectedItem.Text = "Sal" And Session("payment_method") = "Sal" Then
                        Session("enable") = "True"
                    Else
                        Session("enable") = "False"
                    End If

                    Dim trans_date As New TextBox
                    If cal_count < 10 Then
                        trans_date = Me.FindControl("txttrans_date" & "0" & j)
                    Else
                        trans_date = Me.FindControl("txttrans_date" & j)
                    End If
                    Session("trans_date") = trans_date.Text


                    Dim trans_des As New TextBox
                    If cal_count < 10 Then
                        trans_des = Me.FindControl("txttrans_des" & "0" & j)
                    Else
                        trans_des = Me.FindControl("txttrans_des" & j)
                    End If
                    trans_des.Text = "Dishonour"
                    Session("trans_des") = "Dishonour"


                    Dim txt_amt As TextBox = Me.FindControl("txtamt" & Format(j, "00"))
                    Session("txt_amt") = txt_amt.Text

                    Dim lbl1 As Label = Me.FindControl("lab1" & Format(j, "00"))


                    If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("beg_loan_id")

                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("beg_loan_id")


                    ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("cur_loan_id")

                    ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("cur_loan_id")
                    ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                        ds_loan = find_repay(Session("beg_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("beg_loan_id")


                    ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False And Session("beg_status") <> "Declined" Then

                        ds_loan = find_repay(Session("cur_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("cur_loan_id")
                    ElseIf Session("beg_status") = "Declined" Then
                        ds_loan = find_repay(Session("beg_loan_id"))
                        Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                        Session("pay_id") = Session("beg_loan_id")
                    Else
                        If Val(Session("beg_loan_id")) <> 0 Then
                            ds_loan = find_repay(Session("beg_loan_id"))
                            Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                            Session("pay_id") = Session("beg_loan_id")
                        Else
                            ds_loan = find_repay(Session("cur_loan_id"))
                            Session("payment_id") = ds_loan.Tables(0).Rows(j).Item(0).ToString()
                            Session("pay_id") = Session("cur_loan_id")
                        End If

                    End If



                    '''''''''''''''''''''''''''''''' Providing row nos to upadte for cancel schedule
                    Session("count_cncl") = j
                    Session("count_cncl_dis") = j + 1
                    Session("count_cncl_var") = j + 2

                    dishonour_schedule()
                    btnsave_dis.Visible = True
                    btncncl_dis.Visible = True
                    btncncl_save.ForeColor = Drawing.Color.Red
                    btnshow.Visible = False
                    btnacpt.Visible = False
                    btnenfee.Visible = False
                    btnmodsch.Visible = False
                    btnwaive.Visible = False
                    btncancel.Visible = False
                    '''''''''''''''''''''''''''''''''second line
                    btnwaive1.Visible = False
                    btncncl.Visible = False
                    btnenfrc.Visible = False
                    btncncl_enf.Visible = False
                    btncncl_pay.Visible = False
                    btnsave_pay.Visible = False
                    btnmake_dis.Visible = False
                    btncon_dis.Visible = False
                    btnmake_dis.Visible = False
                    btncon_dis.Visible = False
                    Exit For
                Else
                    cal_count = cal_count + 1
                End If
            Next

            If cal_count = Session("count") Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select the payment by clicking on the radio button." & "');", True)
            Else
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Sub set_panel()
        Dim panel_1 As Panel = Page.FindControl("panel1")
        panel_1.Visible = False
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
    End Sub
    Sub mod_reschedule(ByVal loan_id_new As Integer)
        Try
            Dim int_Update_Number As Integer
            Dim str_SQL1, str_SQL2, str_SQL3 As String
            Dim cmd_from, cmd_to As New SqlCommand
            Dim adap_from, adap_to As SqlDataAdapter
            Dim ds_from, ds_to, ds_showrepay As New DataSet
            ds_showrepay = open_con.calculate_loan_repay_show(loan_id_new)


            str_SQL1 = " SELECT Tbl_Payment.Payment_ID, Tbl_Payment.Loan_ID "
            str_SQL1 = str_SQL1 & " FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID "
            str_SQL1 = str_SQL1 & " WHERE Tbl_Payment.Loan_ID= " & loan_id_new & " AND Tbl_Payment_1.Update_ID Is Null ORDER BY  Tbl_Payment.Due_Date"
            cmd_from.CommandText = str_SQL1
            cmd_from.Connection = open_con.return_con
            adap_from = New SqlDataAdapter(cmd_from)
            adap_from.Fill(ds_from)

            str_SQL2 = " SELECT max(Update_Number) as Update_Number FROM Tbl_ReSchedule WHERE Loan_ID = " & loan_id_new
            cmd_to.CommandText = str_SQL2
            cmd_to.Connection = open_con.return_con
            adap_to = New SqlDataAdapter(cmd_to)
            adap_to.Fill(ds_to)

            If Val(ds_to.Tables(0).Rows(0).Item(0).ToString) = 0 Then
                int_Update_Number = 1
            Else
                int_Update_Number = ds_to.Tables(0).Rows(0).Item(0) + 1

            End If

            If Val(ds_to.Tables(0).Rows(0).Item(0).ToString) = 0 Then
                For i = 0 To ds_showrepay.Tables(0).Rows.Count - 1
                    str_SQL3 = "insert into Tbl_ReSchedule(Payment_ID,Loan_ID,Update_Number,Date_ReScheduled)values(@Payment_ID,@Loan_ID,@Update_Number,@Date_ReScheduled)"
                    Dim cmd_reschedule1 As New SqlCommand
                    cmd_reschedule1.CommandText = str_SQL3
                    cmd_reschedule1.Parameters.Add("@Payment_ID", SqlDbType.Int).Value = ds_showrepay.Tables(0).Rows(i).Item("Payment_ID").ToString
                    cmd_reschedule1.Parameters.Add("@Loan_ID", SqlDbType.Int).Value = loan_id_new
                    cmd_reschedule1.Parameters.Add("@Update_Number", SqlDbType.Int).Value = Val(int_Update_Number)
                    cmd_reschedule1.Parameters.Add("@Date_ReScheduled", SqlDbType.Date).Value = System.DateTime.Now.Date
                    cmd_reschedule1.Connection = open_con.return_con
                    cmd_reschedule1.ExecuteNonQuery()
                    cmd_reschedule1.Dispose()

                Next
            Else
                For i = 0 To ds_showrepay.Tables(0).Rows.Count - 1
                    Dim cmd_reschedule As New SqlCommand
                    cmd_reschedule.CommandText = "insert into Tbl_ReSchedule(Payment_ID,Loan_ID,Update_Number,Date_ReScheduled)values(@Payment_ID,@Loan_ID,@Update_Number,@Date_ReScheduled)"
                    cmd_reschedule.Parameters.Add("@Payment_ID", SqlDbType.Int).Value = ds_showrepay.Tables(0).Rows(i).Item("Payment_ID").ToString
                    cmd_reschedule.Parameters.Add("@Loan_ID", SqlDbType.Int).Value = loan_id_new
                    cmd_reschedule.Parameters.Add("@Update_Number", SqlDbType.Int).Value = Val(int_Update_Number)
                    cmd_reschedule.Parameters.Add("@Date_ReScheduled", SqlDbType.Date).Value = System.DateTime.Now.Date
                    cmd_reschedule.Connection = open_con.return_con
                    cmd_reschedule.ExecuteNonQuery()
                    cmd_reschedule.Dispose()
                Next
            End If


            cmd_from.Dispose()
            cmd_to.Dispose()
            adap_from.Dispose()
            adap_to.Dispose()
            ds_from.Dispose()
            ds_to.Dispose()
            ds_showrepay.Dispose()

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try


    End Sub
    Function check_fee() As Boolean

        Dim t As Integer
        Dim cal_count1 As Integer = 0
        Dim cal_count As Integer = 0
        Dim cal_count_for As Integer = 0
        For t = 0 To Session("count") - 1
            If cal_count_for < 10 Then
                chk = Me.FindControl("chk" & "0" & t)
            Else
                chk = Me.FindControl("chk" & t)
            End If
            If chk.Checked = True Then
                cal_count1 = cal_count1 + 1
                cal_count_for = cal_count_for + 1
            Else

                cal_count_for = cal_count_for + 1
            End If
        Next
        Try
            If Val(txtaddpaymnt.Text) = 0 Then
                Dim j As Integer

                For j = 0 To Session("count") - 1
                    If cal_count < 10 Then
                        chk = Me.FindControl("chk" & "0" & j)
                    Else
                        chk = Me.FindControl("chk" & j)
                    End If
                    If chk.Checked = True Then
                        Dim txtamt_chkmod_new As New TextBox
                        txtamt_chkmod_new = Me.FindControl("txtamt" & Format(j, "00"))
                        txtamt_chkmod_new.Enabled = True
                        Session("tot_SinglePayment_new") = CDbl(Session("tot_SinglePayment_new")) + CDbl(txtamt_chkmod_new.Text)
                        If cal_count = Session("count_cncl") Then
                            Dim new_payment As Double
                            Dim old_payment As Double
                            new_payment = Math.Round(CDbl(Session("tot_SinglePayment_new")), 2)
                            old_payment = Math.Round(CDbl(Session("old_amt_new")), 2)
                            Session("tot_SinglePayment_new") = new_payment
                            Session("tot_SinglePayment") = old_payment
                            If new_payment < old_payment Then

                                Return False
                            ElseIf new_payment > old_payment Then

                                Return False
                            Else
                                Return True
                            End If
                        End If
                        cal_count = cal_count + 1
                    Else
                        cal_count = cal_count + 1
                    End If
                Next
            ElseIf Val(txtaddpaymnt.Text) <> 0 And cal_count1 = 1 Then

                Dim j As Integer

                For j = 0 To Session("count") - 1
                    If cal_count < 10 Then
                        chk = Me.FindControl("chk" & "0" & j)
                    Else
                        chk = Me.FindControl("chk" & j)
                    End If
                    If chk.Checked = True Then
                        Dim txtamt_chkmod_new As New TextBox
                        txtamt_chkmod_new = Me.FindControl("txtamt" & Format(j, "00"))
                        txtamt_chkmod_new.Enabled = True
                        Session("tot_SinglePayment_new") = CDbl(Session("tot_SinglePayment_new")) + CDbl(txtamt_chkmod_new.Text)
                        cal_count = cal_count + 1
                    Else
                        cal_count = cal_count + 1
                    End If
                Next

                For i As Integer = 1 To Val(txtaddpaymnt.Text)

                    Dim txtamt_mod_new As New TextBox
                    txtamt_mod_new = Me.FindControl("txtamt_mod_new" & Format(i + 1, "00"))
                    Session("tot_SinglePayment_new") = CDbl(Session("tot_SinglePayment_new")) + CDbl(txtamt_mod_new.Text)

                Next
                Session("tot_SinglePayment_new") = CDbl(Session("tot_SinglePayment_new"))
                Session("tot_SinglePayment") = CDbl(Session("old_amt_new"))
              
                Dim new_payment As Double
                Dim old_payment As Double
                new_payment = Math.Round(CDbl(Session("tot_SinglePayment_new")), 2)
                old_payment = Math.Round(CDbl(Session("tot_SinglePayment")), 2)
                Session("tot_SinglePayment_new") = new_payment
                Session("tot_SinglePayment") = old_payment
                If new_payment < old_payment Then

                    Return False
                ElseIf new_payment > old_payment Then

                    Return False

                Else
                    Return True
                End If
            Else
                Dim j As Integer

                For j = 0 To Session("count") - 1
                    If cal_count < 10 Then
                        chk = Me.FindControl("chk" & "0" & j)
                    Else
                        chk = Me.FindControl("chk" & j)
                    End If
                    If chk.Checked = True Then
                        Dim txtamt_chkmod_new As New TextBox
                        txtamt_chkmod_new = Me.FindControl("txtamt" & Format(j, "00"))
                        txtamt_chkmod_new.Enabled = True
                        Session("tot_SinglePayment_new") = CDbl(Session("tot_SinglePayment_new")) + CDbl(txtamt_chkmod_new.Text)
                        cal_count = cal_count + 1
                    Else
                        cal_count = cal_count + 1
                    End If
                Next

                For i As Integer = 1 To Val(txtaddpaymnt.Text)

                    Dim txtamt_mod_new As New TextBox
                    txtamt_mod_new = Me.FindControl("txtamt_mod_new" & Format(i, "00"))
                    Session("tot_SinglePayment_new") = CDbl(Session("tot_SinglePayment_new")) + CDbl(txtamt_mod_new.Text)

                Next
                Session("tot_SinglePayment_new") = CDbl(Session("tot_SinglePayment_new"))
                Session("tot_SinglePayment") = CDbl(Session("old_amt_new"))
              
                Dim new_payment As Double
                Dim old_payment As Double
                new_payment = Math.Round(CDbl(Session("tot_SinglePayment_new")), 2)
                old_payment = Math.Round(CDbl(Session("tot_SinglePayment")), 2)
                Session("tot_SinglePayment_new") = new_payment
                Session("tot_SinglePayment") = old_payment
                If new_payment < old_payment Then

                    Return False
                ElseIf new_payment > old_payment Then

                    Return False

                Else
                    Return True
                End If
            End If

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)

        End Try


    End Function


    Protected Sub s_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles s.Click

      

        Dim j As Integer
        Dim cal_count As Integer = 0
        For j = 0 To Session("count") - 1

            If cal_count < 10 Then
                chk = Me.FindControl("chk" & "0" & j)
                If Session("select_all") = False Then
                    chk.Checked = True
                Else
                    chk.Checked = False
                End If

                cal_count = cal_count + 1
            Else
                chk = Me.FindControl("chk" & j)
                If Session("select_all") = False Then
                    chk.Checked = True
                Else
                    chk.Checked = False
                End If
                cal_count = cal_count + 1



            End If

        Next
   
        If Page.IsPostBack = True And Session("select_all") = True Then
            Session("select_all") = False
        ElseIf Page.IsPostBack = True And Session("select_all") = False Then
            Session("select_all") = True
        End If
    End Sub

    Sub check_money()


        Dim old_payment, new_payment As Double
        new_payment = open_con.newamount(Math.Round(CDbl(Session("tot_SinglePayment_new")), 2))
        old_payment = open_con.newamount(Math.Round(CDbl(Session("tot_SinglePayment")), 2))
        If new_payment > old_payment Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please make adjustment  to repayment(s): subtract $-" & open_con.newamount(Math.Round(CDbl(Session("tot_SinglePayment_new")) - CDbl(Session("tot_SinglePayment")), 2)) & "');", True)
            Session("tot_SinglePayment_new") = 0
            btnshow.Visible = False
            btnenfee.Visible = False
            btnshow.Visible = False
            btnacpt.Visible = False
            btnmodsch.Visible = False
            btnwaive.Visible = False
            btncancel.Visible = False
            btncon_dis.Visible = False
            btnmake_dis.Visible = False
            btnsave_mod.Visible = True
            btncncl_mod.Visible = True
            Exit Sub

        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please make adjustment  to repayment(s): add $+" & open_con.newamount(Math.Round(CDbl(Session("tot_SinglePayment")) - CDbl(Session("tot_SinglePayment_new")), 2)) & "');", True)
            Session("tot_SinglePayment_new") = 0
            btnshow.Visible = False
            btnenfee.Visible = False
            btnshow.Visible = False
            btnacpt.Visible = False
            btnmodsch.Visible = False
            btnwaive.Visible = False
            btncancel.Visible = False
            btncon_dis.Visible = False
            btnmake_dis.Visible = False
            btnsave_mod.Visible = True
            btncncl_mod.Visible = True
            Exit Sub
        End If

     
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
    'Sub abc()
    '    If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
    '        ds_loan = open_con.calculate_loan_repay(Session("beg_loan_id"))
    '        show_loan_repay(ds_loan)
    '    ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then

    '        ds_loan = open_con.calculate_loan_repay(Session("beg_loan_id"))
    '        show_loan_repay(ds_loan)

    '    ElseIf Session("flag_approve") = True Then

    '        ds_loan = open_con.calculate_loan_repay(Session("cur_loan_id"))
    '        show_loan_repay(ds_loan)

    '    End If
    'End Sub

End Class
