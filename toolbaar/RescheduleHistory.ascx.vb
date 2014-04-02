Imports System.Data
Imports System.Data.SqlClient
Partial Class toolbaar_RescheduleHistory
    Inherits System.Web.UI.UserControl
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Page.IsPostBack = True Then

                Dim loan_id_reschedule As Integer

                If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
                    loan_id_reschedule = Session("beg_loan_id")
                ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                    loan_id_reschedule = Session("beg_loan_id")

                ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                    loan_id_reschedule = Session("cur_loan_id")

                ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                    loan_id_reschedule = Session("cur_loan_id")

                ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                    loan_id_reschedule = Session("beg_loan_id")

                ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False Then

                    loan_id_reschedule = Session("cur_loan_id")
                End If


                Using obj As New clsReschedule()
                    Dim loanID As Integer = loan_id_reschedule
                    Dim ds As DataSet = obj.GetRescheduleActivity(loanID)
                    RescheduledLoan(loanID, ds)
                    If ds.Tables.Count > 0 Then
                        ltReschdl.Visible = True
                    End If
                End Using
                'Dim cmd_ReSchedule_History As New SqlCommand
                'Dim adap_ReSchedule_History As SqlDataAdapter
                'Dim ds_ReSchedule_History As New DataSet
                'Dim str_SQL As String

                'str_SQL = " SELECT Tbl_Payment.Loan_ID, Tbl_Payment.Description, Tbl_Payment.Amount, Tbl_Payment.Due_Date, Tbl_Payment.Payment_Status, Tbl_Payment.Payment_Date, Tbl_Payment.Payment_Method, Tbl_Payment.Transaction_Status, Tbl_Payment.Transaction_Date, Tbl_ReSchedule.Update_Number, Tbl_ReSchedule.Date_ReScheduled "
                'str_SQL = str_SQL & " FROM Tbl_Payment INNER JOIN Tbl_ReSchedule ON Tbl_Payment.Payment_ID = Tbl_ReSchedule.Payment_ID "
                'str_SQL = str_SQL & " WHERE Tbl_Payment.Loan_ID = " & loan_id_reschedule
                'str_SQL = str_SQL & " ORDER BY Tbl_ReSchedule.Update_Number, Tbl_Payment.Payment_ID, Tbl_ReSchedule.Date_ReScheduled "

                'cmd_ReSchedule_History.CommandText = str_SQL
                'cmd_ReSchedule_History.Connection = open_con.return_con
                'adap_ReSchedule_History = New SqlDataAdapter(cmd_ReSchedule_History)
                'adap_ReSchedule_History.Fill(ds_ReSchedule_History)
                'If ds_ReSchedule_History.Tables(0).Rows.Count = 0 Then
                '    lblreschedule.Visible = True
                'Else
                '    lblreschedule.Visible = False
                '    reschedule_table(ds_ReSchedule_History)
                'End If
                'cmd_ReSchedule_History.Dispose()
                'adap_ReSchedule_History.Dispose()
                'ds_ReSchedule_History.Dispose()
                'open_con.return_con.Dispose()
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Sub RescheduledLoan(ByVal loanID As Integer, ByVal ds As DataSet)
        Try
            Dim sb As New StringBuilder()
            Dim tmp As String = "P stands for payment status"
            sb.Append("<table  width='100%' cellpadding='0' cellspacing='0'  class='tblreport'>")
            sb.Append("<tr>")
            sb.Append("<th width='5%' class='center'>No.</th>")
            sb.Append("<th width='19%' class='center'>Description</th>")
            sb.Append("<th width='13%' class='center'>Due Date</th>")
            sb.Append("<th width='10%' class='center'>Amount</th>")
            sb.Append("<th width='2%' class='center'><a href='javascript:alert(" & Chr(34) & tmp & Chr(34) & ");'>P</a></th>")
            sb.Append("<th width='13%' class='center'>Payment Date</th>")
            sb.Append("<th width='8%' class='center'>Method</th>")
            sb.Append("<th width='15%' class='center'>Transaction Status</th>")
            sb.Append("<th width='15%' class='center'>Transaction Date</th>")
            sb.Append("</tr>")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    sb.Append("<tr>")
                    Dim ri As Integer = ds.Tables(0).Rows.IndexOf(dr) + 1
                    sb.Append("<td colspan='9' align='left' class='blue' style='font-weight:bold;letter-spacing:1px; '>Date Rescheduled: &nbsp;&nbsp;" & String.Format(clsGeneral.GetDateFormat, ds.Tables(0).Rows(0).Item("Date_ReScheduled")) & "&nbsp;&nbsp;&nbsp;Activity &nbsp;" & ri.ToString() & "</td>")
                    sb.Append("</tr>")
                    sb.Append(bindReschDetails(dr, loanID))
                Next
               
            End If
            sb.Append("</table>")
            ltReschdl.Text = sb.ToString()
        Catch ex As Exception

        End Try
    End Sub
    Public Function bindReschDetails(ByVal dr As DataRow, ByVal loanID As Integer) As String
        Try
            Dim sbdtl As New StringBuilder()
            Dim tmp As String = "P stands for payment status"
            Using objdtl As New clsReschedule()
                Dim dsDtl As DataSet = objdtl.GetRescheduleActivityDetails(loanID, Integer.Parse(dr("Update_Number")))
                If dsDtl.Tables(0).Rows.Count > 0 Then
                    For Each r As DataRow In dsDtl.Tables(0).Rows
                        sbdtl.Append("<tr>")
                        Dim ri As Integer = dsDtl.Tables(0).Rows.IndexOf(r) + 1
                        Dim desc As String = Convert.ToString(r.Item("Description"))
                        Dim duedate As String = String.Format(clsGeneral.GetDateFormat(), Convert.ToDateTime(r.Item("Due_Date")))
                        Dim amt As String = String.Format(clsGeneral.GetStringFormat(), Convert.ToDecimal(r.Item("Amount")))
                        Dim payStatus As String = ""
                        If Convert.ToString(r.Item("Payment_Status")) = "Paid" Then
                            payStatus = "<a href='javascript:alert(" & Chr(34) & tmp & Chr(34) & ");' style=" & Chr(34) & "color:green;" & Chr(34) & " >P</a>"
                        End If
                        Dim payDate As String = ""

                        If Convert.ToString(r.Item("Payment_Date")) <> "" Then
                            payDate = String.Format(clsGeneral.GetDateFormat(), Convert.ToDateTime(r.Item("Payment_Date")))

                        End If
                        Dim method As String = Convert.ToString(r.Item("Payment_Method"))
                        Dim ts As String = Convert.ToString(r.Item("Transaction_Status"))
                        Dim td As String = "" '= Convert.ToString(r.Item("Transaction_Date"))
                        If Convert.ToString(r.Item("Transaction_Date")) <> "" Then
                            td = String.Format(clsGeneral.GetDateFormat(), r.Item("Transaction_Date"))
                        End If
                        sbdtl.Append("<td>" & ri & "</td>")
                        sbdtl.Append("<td align='left'>" & desc & "</td>")
                        sbdtl.Append("<td align='center'>" & duedate & "</td>")
                        sbdtl.Append("<td align='right'>" & amt & "</td>")
                        sbdtl.Append("<td >" & payStatus & "</td>")
                        sbdtl.Append("<td>" & payDate & "</td>")
                        sbdtl.Append("<td>" & method & "</td>")
                        sbdtl.Append("<td>" & ts & "</td>")
                        sbdtl.Append("<td>" & td & "</td>")
                        sbdtl.Append("</tr>")

                    Next
                    Return sbdtl.ToString()
                End If
            End Using

        Catch ex As Exception

        End Try
    End Function
    Sub reschedule_table(ByVal ds As DataSet)

    

        Dim tbl As Table = New Table()
        tbl.ID = "tbl_reschedule"
        tbl.Style.Add("border-style", "solid")
        tbl.Style.Add("border-width", "1px")
        tbl.Style.Add(" border-color", "gray")
        ' PlaceHolder1.Controls.Clear()
        ' PlaceHolder1.Controls.Add(tbl)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim snno As Label = New Label()
        snno.Text = "No."
        snno.Font.Bold = True

        snno.Width = "40"
      

        snno.Style.Add("font-size", "14px")
        snno.Style.Add("font-family", "Times New Roman")
        snno.Style.Add("font-weight", "bold")
        snno.Style.Add("text-align", "center")
        snno.Style.Add("background-color", "#E8E8E8")
        snno.Style.Add(" border-style", "solid")
        snno.Style.Add(" border-width", "1px")
        snno.Style.Add(" border-color", "gray")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim des As Label = New Label
        des.Text = "Description"
        des.Font.Bold = True

        des.Width = "110"

        des.Style.Add("font-size", "14px")
        des.Style.Add("font-family", "Times New Roman")
        des.Style.Add("font-weight", "bold")
        des.Style.Add("text-align", "center")
        des.Style.Add("background-color", "#E8E8E8")
        des.Style.Add(" border-style", "solid")
        des.Style.Add(" border-width", "1px")
        des.Style.Add(" border-color", "gray")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim duedt As Label = New Label
        duedt.Text = "Due Date"
        duedt.Font.Bold = True
        duedt.Width = "120"
        duedt.Style.Add("font-size", "14px")
        duedt.Style.Add("font-family", "Times New Roman")
        duedt.Style.Add("font-weight", "bold")
        duedt.Style.Add("text-align", "center")
        duedt.Style.Add("background-color", "#E8E8E8")
        duedt.Style.Add(" border-style", "solid")
        duedt.Style.Add(" border-width", "1px")
        duedt.Style.Add(" border-color", "gray")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim amt As Label = New Label
        amt.Text = "Amount"
        amt.Font.Bold = True
        amt.Width = "80"
        amt.Style.Add("font-size", "14px")
        amt.Style.Add("font-family", "Times New Roman")
        amt.Style.Add("font-weight", "bold")
        amt.Style.Add("text-align", "center")
        amt.Style.Add("background-color", "#E8E8E8")
        amt.Style.Add(" border-style", "solid")
        amt.Style.Add(" border-width", "1px")
        amt.Style.Add(" border-color", "gray")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim p As Label = New Label
        p.ForeColor = Drawing.Color.Blue
        p.Text = "P"
        '  p.OnClientClick = "javascript:alert('P stands for payment status');"
        p.Font.Bold = True

        p.Width = "50"


        p.Style.Add("font-size", "14px")
        p.Style.Add("font-family", "Times New Roman")
        p.Style.Add("font-weight", "bold")
        p.Style.Add("text-align", "center")
        p.Style.Add("background-color", "#E8E8E8")
        p.Style.Add(" border-style", "solid")
        p.Style.Add(" border-width", "1px")
        p.Style.Add(" border-color", "gray")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim pdate As Label = New Label
        pdate.Text = "Payment Date"
        pdate.Font.Bold = True

        pdate.Width = "120"


        pdate.Style.Add("font-size", "14px")
        pdate.Style.Add("font-family", "Times New Roman")
        pdate.Style.Add("font-weight", "bold")
        pdate.Style.Add("text-align", "center")
        pdate.Style.Add("background-color", "#E8E8E8")
        pdate.Style.Add(" border-style", "solid")
        pdate.Style.Add(" border-width", "1px")
        pdate.Style.Add(" border-color", "gray")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim pmethod As Label = New Label
        pmethod.Text = "Method"
        pmethod.Font.Bold = True
        pmethod.Width = "120"
        pmethod.Style.Add("font-size", "14px")
        pmethod.Style.Add("font-family", "Times New Roman")
        pmethod.Style.Add("font-weight", "bold")
        pmethod.Style.Add("text-align", "center")
        pmethod.Style.Add("background-color", "#E8E8E8")
        pmethod.Style.Add(" border-style", "solid")
        pmethod.Style.Add(" border-width", "1px")
        pmethod.Style.Add(" border-color", "gray")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim tdes As Label = New Label
        tdes.Text = "Transaction Status"
        tdes.Font.Bold = True
        tdes.Width = "130"
        tdes.Style.Add("font-size", "14px")
        tdes.Style.Add("font-family", "Times New Roman")
        tdes.Style.Add("font-weight", "bold")
        tdes.Style.Add("text-align", "center")
        tdes.Style.Add("background-color", "#E8E8E8")
        tdes.Style.Add(" border-style", "solid")
        tdes.Style.Add(" border-width", "1px")
        tdes.Style.Add(" border-color", "gray")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim tdate As Label = New Label
        tdate.Text = "Transaction Date"
        tdate.Font.Bold = True

        tdate.Width = "140"


        tdate.Style.Add("font-size", "14px")
        tdate.Style.Add("font-family", "Times New Roman")
        tdate.Style.Add("font-weight", "bold")
        tdate.Style.Add("text-align", "center")
        tdate.Style.Add("background-color", "#E8E8E8")
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


        Dim int_SubTotal, int_Schedule_Number, int_SNO, r_no As Integer
        int_SubTotal = 0
        int_Schedule_Number = 0
        int_SNO = 1

        If Not ds.Tables(0).Rows.Count = 0 Then
            For r_no = 1 To ds.Tables(0).Rows.Count
                Dim lr1 As Label = New Label()
                lr1.Text = "Date Rescheduled:"
                lr1.Font.Bold = True
                lr1.Width = "120"

                lr1.Style.Add("font-size", "14px")


                lr1.Style.Add("font-family", "Times New Roman")
                lr1.Style.Add("font-weight", "bold")
                lr1.Style.Add("text-align", "center")
                lr1.Style.Add("background-color", "white")
                lr1.Style.Add("color", "DarkBlue")
                lr1.Style.Add(" border-style", "none")

                Dim lr2 As Label = New Label()
                lr2.Font.Bold = True
                lr2.Width = "80"

                lr2.Style.Add("font-size", "14px")

                lr2.Style.Add("font-family", "Times New Roman")
                lr2.Style.Add("font-weight", "bold")
                lr2.Style.Add("text-align", "left")
                lr2.Style.Add("background-color", "white")
                lr2.Style.Add("color", "DarkBlue")
                lr2.Style.Add(" border-style", "none")

                Dim lr3 As Label = New Label()
                lr3.Font.Bold = True
                lr3.Width = "80"

                lr3.Style.Add("font-size", "14px")


                lr3.Style.Add("font-family", "Times New Roman")
                lr3.Style.Add("font-weight", "bold")
                lr3.Style.Add("text-align", "left")
                lr3.Style.Add("background-color", "white")
                lr3.Style.Add("color", "DarkBlue")
                lr3.Style.Add(" border-style", "none")

                Dim tcm1 As TableCell = New TableCell()
                Dim trm1 As TableRow = New TableRow()
                tcm1.Style.Add("border-style", "solid")
                tcm1.Style.Add("border-width", "1px")
                tcm1.Style.Add(" border-color", "gray")
                trm1.Style.Add("border-style", "solid")
                trm1.Style.Add("border-width", "1px")
                trm1.Style.Add(" border-color", "gray")
                trm1.Style.Add("text-align", "left")
                tcm1.Controls.Add(lr1)
                tcm1.Controls.Add(lr2)
                tcm1.Controls.Add(lr3)
                trm1.Controls.Add(tcm1)
                tbl.Rows.Add(trm1)

                '''''''''''''''''''''''''''''''''''''''''''''''''

                Dim tcm_val As TableCell = New TableCell()
                Dim trm_val As TableRow = New TableRow()
                tcm_val.Style.Add("border-style", "solid")
                tcm_val.Style.Add("border-width", "1px")
                tcm_val.Style.Add(" border-color", "gray")
                trm_val.Style.Add("border-style", "solid")
                trm_val.Style.Add("border-width", "1px")
                trm_val.Style.Add(" border-color", "gray")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim snno_val As Label = New Label()
                snno_val.ID = "snno_val" & Format(r_no, "00")


                snno_val.Width = "20"
                snno_val.Style.Add("font-size", "14px")
                snno_val.Style.Add("text-align", "left")

                snno_val.Style.Add("font-family", "Times New Roman")
                snno_val.Style.Add("font-weight", "bold")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim des_val As Label = New Label
                des_val.ID = "des_val" & Format(r_no, "00")

                des_val.Width = "110"
                des_val.Style.Add("font-size", "14px")

                des_val.Style.Add("font-family", "Times New Roman")
                des_val.Style.Add("text-align", "center")
                des_val.Style.Add("font-weight", "bold")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim duedt_val As Label = New Label
                duedt_val.ID = "duedt_val" & Format(r_no, "00")
                duedt_val.Width = "130"

                duedt_val.Style.Add("font-size", "14px")
                duedt_val.Style.Add("font-family", "Times New Roman")
                duedt_val.Style.Add("text-align", "center")
                duedt_val.Style.Add("font-weight", "bold")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim sign_val As Label = New Label

                sign_val.Text = "$"

                sign_val.Width = "20"
                sign_val.Style.Add("font-size", "14px")

                sign_val.Style.Add("font-family", "Times New Roman")
                sign_val.Style.Add("text-align", "right")
                sign_val.Style.Add("font-weight", "bold")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim amt_val As Label = New Label
                amt_val.ID = "amt_val" & Format(r_no, "00")
                amt_val.Width = "50"
                amt_val.Style.Add("font-size", "14px")

                amt_val.Style.Add("font-size", "14px")
                amt_val.Style.Add("font-family", "Times New Roman")
                amt_val.Style.Add("text-align", "left")
                amt_val.Style.Add("font-weight", "bold")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim p_val As Label = New Label
                p_val.Visible = False

                '  p_val.OnClientClick = "javascript:alert('P stands for payment status');"
                p_val.Font.Bold = True


                p_val.Width = "60"
                p_val.Style.Add("font-size", "14px")
                p_val.Style.Add("color", "Blue")
                p_val.Style.Add("font-family", "Times New Roman")
                p_val.Style.Add("font-weight", "bold")
                p_val.Style.Add("text-align", "center")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim ex_val As Label = New Label
                ex_val.ID = "amt_val_ex" & Format(r_no, "00")

                ex_val.Width = "60"



                ex_val.Text = ""
                ex_val.Visible = False
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim pdate_val As Label = New Label
                pdate_val.ID = "pdate_val" & Format(r_no, "00")


                pdate_val.Width = "120"
                pdate_val.Style.Add("font-size", "14px")


                pdate_val.Style.Add("font-family", "Times New Roman")
                pdate_val.Style.Add("text-align", "center")
                pdate_val.Style.Add("font-weight", "bold")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim pmethod_val As Label = New Label
                pmethod_val.ID = "pmethod_val" & Format(r_no, "00")
                pmethod_val.Width = "120"

                pmethod_val.Style.Add("font-size", "14px")


                pmethod_val.Style.Add("font-family", "Times New Roman")
                pmethod_val.Style.Add("text-align", "center")
                pmethod_val.Style.Add("font-weight", "bold")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim tdes_val As Label = New Label
                tdes_val.ID = "tdes_val" & Format(r_no, "00")
                tdes_val.Width = "130"

                tdes_val.Style.Add("font-size", "14px")


                tdes_val.Style.Add("font-family", "Times New Roman")
                tdes_val.Style.Add("text-align", "center")
                tdes_val.Style.Add("font-weight", "bold")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim tdate_val As Label = New Label
                tdate_val.ID = "tdate_val" & Format(r_no, "00")
                tdate_val.Width = "120"

                tdate_val.Style.Add("font-size", "14px")


                tdate_val.Style.Add("font-family", "Times New Roman")
                tdate_val.Style.Add("text-align", "center")
                tdate_val.Style.Add("font-weight", "bold")

                Dim re_date As String
                re_date = ds.Tables(0).Rows(r_no - 1).Item("Date_ReScheduled")
                re_date = Replace(re_date, "/", "")
                lr2.Text = cal_date(re_date)

                If r_no = 1 Then
                    lr1.Visible = True
                    lr2.Visible = True
                    lr3.Visible = True
                    lr3.Text = "Activity" & " " & ds.Tables(0).Rows(r_no - 1).Item("Update_Number").ToString
                ElseIf ds.Tables(0).Rows(r_no - 1).Item("Update_Number").ToString = ds.Tables(0).Rows(r_no - 2).Item("Update_Number").ToString Then
                    lr1.Visible = False
                    lr2.Visible = False
                    lr3.Visible = False
                Else
                    lr1.Visible = True
                    lr2.Visible = True
                    lr3.Visible = True
                    lr3.Text = "Activity" & " " & ds.Tables(0).Rows(r_no - 1).Item("Update_Number").ToString
                End If


                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                snno_val.Text = r_no
                If ds.Tables(0).Rows(r_no - 1).Item("Description").ToString = "" Then
                    des_val.Text = ""
                Else
                    des_val.Text = ds.Tables(0).Rows(r_no - 1).Item("Description").ToString
                End If
                If ds.Tables(0).Rows(r_no - 1).Item("Due_Date").ToString = "" Then
                    duedt_val.Text = ""
                Else
                    Dim duedt_re As String
                    duedt_re = ds.Tables(0).Rows(r_no - 1).Item("due_date")
                    duedt_re = Replace(duedt_re, "/", "")
                    duedt_val.Text = cal_date(duedt_re)
                End If
                amt_val.Text = FormatNumber(ds.Tables(0).Rows(r_no - 1).Item("Amount"), 2)
                If ds.Tables(0).Rows(r_no - 1).Item("Payment_Date").ToString = "" Then
                    pdate_val.Text = ""
                Else
                    Dim p_date As String
                    p_date = ds.Tables(0).Rows(r_no - 1).Item("Payment_Date")
                    p_date = Replace(p_date, "/", "")
                    pdate_val.Text = cal_date(p_date)
                End If

                pmethod_val.Text = ds.Tables(0).Rows(r_no - 1).Item("Payment_Method").ToString
                tdes_val.Text = ds.Tables(0).Rows(r_no - 1).Item("Transaction_Status").ToString
                If ds.Tables(0).Rows(r_no - 1).Item("Transaction_Date").ToString = "" Then

                Else
                    Dim t_date As String
                    t_date = ds.Tables(0).Rows(r_no - 1).Item("Transaction_Date")
                    t_date = Replace(t_date, "/", "")
                    tdate_val.Text = cal_date(t_date)
                End If
                If ds.Tables(0).Rows(r_no - 1).Item("Payment_Status").ToString = "Paid" Then
                    p_val.Visible = True
                    p_val.Text = "P"
                    p_val.Style.Add("color", "blue")
                Else
                    ex_val.Visible = True
                    p_val.Visible = False
                End If
                tcm_val.Controls.Add(snno_val)
                tcm_val.Controls.Add(des_val)
                tcm_val.Controls.Add(duedt_val)
                tcm_val.Controls.Add(sign_val)
                tcm_val.Controls.Add(amt_val)
                tcm_val.Controls.Add(p_val)
                tcm_val.Controls.Add(ex_val)
                tcm_val.Controls.Add(pdate_val)
                tcm_val.Controls.Add(pmethod_val)
                tcm_val.Controls.Add(tdes_val)
                tcm_val.Controls.Add(tdate_val)
                trm_val.Cells.Add(tcm_val)
                tbl.Rows.Add(trm_val)
                Session("r_no") = ds.Tables(0).Rows(r_no - 1).Item("Update_Number").ToString
            Next
        End If
    End Sub
    Function cal_date(ByVal duedt_re As String) As String
        If Len(duedt_re) < 8 Then
            duedt_re = "0" & duedt_re
        End If

        Dim month_rech As String
        month_rech = Mid(duedt_re, 3, 2)

        If month_rech = "01" Then
            duedt_re = Left(duedt_re, 2) & " " & "Jan" & " " & Right(duedt_re, 4)
        ElseIf month_rech = "02" Then
            duedt_re = Left(duedt_re, 2) & " " & "Feb" & " " & Right(duedt_re, 4)
        ElseIf month_rech = "03" Then
            duedt_re = Left(duedt_re, 2) & " " & "Mar" & " " & Right(duedt_re, 4)
        ElseIf month_rech = "04" Then
            duedt_re = Left(duedt_re, 2) & " " & "Apr" & " " & Right(duedt_re, 4)
        ElseIf month_rech = "05" Then
            duedt_re = Left(duedt_re, 2) & " " & "May" & " " & Right(duedt_re, 4)
        ElseIf month_rech = "06" Then
            duedt_re = Left(duedt_re, 2) & " " & "Jun" & " " & Right(duedt_re, 4)
        ElseIf month_rech = "07" Then
            duedt_re = Left(duedt_re, 2) & " " & "Jul" & " " & Right(duedt_re, 4)
        ElseIf month_rech = "08" Then
            duedt_re = Left(duedt_re, 2) & " " & "Aug" & " " & Right(duedt_re, 4)
        ElseIf month_rech = "09" Then
            duedt_re = Left(duedt_re, 2) & " " & "Sep" & " " & Right(duedt_re, 4)
        ElseIf month_rech = "10" Then
            duedt_re = Left(duedt_re, 2) & " " & "Oct" & " " & Right(duedt_re, 4)
        ElseIf month_rech = "11" Then
            duedt_re = Left(duedt_re, 2) & " " & "Nov" & " " & Right(duedt_re, 4)
        ElseIf month_rech = "12" Then
            duedt_re = Left(duedt_re, 2) & " " & "Dec" & " " & Right(duedt_re, 4)
        End If

        Return duedt_re
    End Function
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
