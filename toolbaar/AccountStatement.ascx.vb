Imports System.Data.SqlClient
Imports System.Data

Partial Class toolbaar_AccountStatement
    Inherits System.Web.UI.UserControl
    Dim open_con As New Class1
    Dim loanst_id As Integer
    Protected Sub btnloan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnloan.Click

        btnprnt.Visible = True
        btncnclst.Visible = True
       
        If Val(txtstartdt.Text) = 0 Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid statement start date!!!" & "');", True)
            Exit Sub
        ElseIf Val(txtenddt.Text) = 0 Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid statement end date !!!" & "');", True)
            Exit Sub
    
        Else

            Panel8.Visible = True
            Panel7.Visible = False

            Dim str_SQL, str_SQL1, str_SQL2, str_SQL3, str_SQL4 As String

            str_SQL = " SELECT  Tbl_Payment.Loan_ID, Tbl_Payment.Payment_ID, Tbl_Payment.Payment_Status as description, Tbl_Payment.Amount, Tbl_Payment.Payment_Date, Tbl_Payment.Payment_Method, Tbl_Payment.Fee_Status, '1' AS des1 "
            str_SQL = str_SQL & " FROM Tbl_Payment WHERE   Tbl_Payment.Amount > 0 AND  Tbl_Payment.Payment_Status = 'Paid' AND Tbl_Payment.Loan_ID=" & Session("accst_id")

            str_SQL = str_SQL & " UNION SELECT ALL Tbl_Payment.Loan_ID, Tbl_Payment.Payment_ID, Tbl_Payment.Transaction_Status, Tbl_Payment.Amount, Tbl_Payment.Transaction_Date, Tbl_Payment.Payment_Method, Tbl_Payment.Fee_Status , '2' AS des1 "
            str_SQL = str_SQL & " FROM Tbl_Payment WHERE Tbl_Payment.Amount > 0 AND Tbl_Payment.Transaction_Status ='Waived' AND Tbl_Payment.Loan_ID= " & Session("accst_id")

            str_SQL = str_SQL & " UNION SELECT ALL Tbl_Payment.Loan_ID, Tbl_Payment.Payment_ID, Tbl_Payment.transaction_status, Tbl_Payment.Amount, Tbl_Payment.Transaction_Date, Tbl_Payment.Payment_Method, Tbl_Payment.Fee_Status , '3' AS des1 "
            str_SQL = str_SQL & " FROM Tbl_Payment WHERE Tbl_Payment.Amount > 0 AND Tbl_Payment.transaction_status = 'Dishonour' AND Tbl_Payment.Loan_ID= " & Session("accst_id")

            str_SQL = str_SQL & " UNION SELECT  Tbl_Payment.Loan_ID, Tbl_Payment.Payment_ID, Tbl_Payment.Description, Tbl_Payment.Amount, Tbl_Payment.Date_Updated, Tbl_Payment.Payment_Method, Tbl_Payment.Fee_Status  , '4' AS des1"
            str_SQL = str_SQL & " FROM Tbl_Payment WHERE Tbl_Payment.Amount > 0 AND Tbl_Payment.Fee_Status in ('Credit fee', 'Draw down', 'dishonoured fee', 'Cancellation fee', 'Variation fee', 'Letter of demand fee', 'Default notice fee', 'Arear notice fee', 'Statement of account fee', 'Enforcement fee') AND Tbl_Payment.Loan_ID=" & Session("accst_id")
            str_SQL = str_SQL & " ORDER BY Tbl_Payment.Payment_Date,des1, Tbl_Payment.Payment_ID, Tbl_Payment.Amount "

            Dim ds_Account, ds_CustomerAddress, ds_Branch_Detail, ds_loan, ds_Loan_Fees As New DataSet
            Dim adap_Account, adap_CustomerAddress, adap_Branch_Detail, adap_loan, adap_Loan_Fees As SqlDataAdapter
            Dim cmd_actst, cmd_CustomerAddress, cmd_Branch_Detail, cmd_loan, cmd_Loan_Fees As New SqlCommand
            cmd_actst.CommandText = str_SQL
            cmd_actst.Connection = open_con.return_con
            adap_Account = New SqlDataAdapter(cmd_actst)
            adap_Account.Fill(ds_Account)

            str_SQL1 = " SELECT * FROM Tbl_Customer WHERE Customer_ID = " & open_con.customer_id_val

            cmd_CustomerAddress.CommandText = str_SQL1
            cmd_CustomerAddress.Connection = open_con.return_con
            adap_CustomerAddress = New SqlDataAdapter(cmd_CustomerAddress)
            adap_CustomerAddress.Fill(ds_CustomerAddress)

            str_SQL2 = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val
            cmd_Branch_Detail.CommandText = str_SQL2
            cmd_Branch_Detail.Connection = open_con.return_con
            adap_Branch_Detail = New SqlDataAdapter(cmd_Branch_Detail)
            adap_Branch_Detail.Fill(ds_Branch_Detail)

            str_SQL3 = "SELECT * FROM tbl_loan WHERE loan_id= " & Session("accst_id")
            cmd_loan.CommandText = str_SQL3
            cmd_loan.Connection = open_con.return_con
            adap_loan = New SqlDataAdapter(cmd_loan)
            adap_loan.Fill(ds_loan)
            Session("ln_amt") = ds_loan.Tables(0).Rows(0).Item("Amount").ToString

            str_SQL4 = "Select * FROM Tbl_Loan_Fee WHERE Loan_ID = " & Session("accst_id")
            cmd_Loan_Fees.CommandText = str_SQL4
            cmd_Loan_Fees.Connection = open_con.return_con
            adap_Loan_Fees = New SqlDataAdapter(cmd_Loan_Fees)
            adap_Loan_Fees.Fill(ds_Loan_Fees)
            loan_table(ds_Loan_Fees, ds_Account)
            ds_Account.Dispose()
            ds_Branch_Detail.Dispose()
            ds_CustomerAddress.Dispose()
            ds_loan.Dispose()
            ds_Loan_Fees.Dispose()
            cmd_actst.Dispose()
            cmd_Branch_Detail.Dispose()
            cmd_CustomerAddress.Dispose()
            cmd_loan.Dispose()
            cmd_Loan_Fees.Dispose()
            adap_Account.Dispose()
            adap_Branch_Detail.Dispose()
            adap_CustomerAddress.Dispose()
            adap_loan.Dispose()
            adap_Loan_Fees.Dispose()
            open_con.return_con.Dispose()
            Session("startdt") = txtstartdt.Text
            Session("enddt") = txtenddt.Text

        End If



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim loanst_id As Integer
        Try


            If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
                loanst_id = Session("beg_loan_id")

            ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                loanst_id = Session("beg_loan_id")

            ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                loanst_id = Session("cur_loan_id")

            ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                loanst_id = Session("cur_loan_id")

            ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                loanst_id = Session("beg_loan_id")

            ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False Then

                loanst_id = Session("cur_loan_id")
            End If



            Dim cmd_loanst As New SqlCommand
            Dim ds_loanst As New DataSet
            Dim adap_loanst As SqlDataAdapter
            Dim str_loanst As String

            str_loanst = "Select Loan_date from tbl_loan where loan_id=" & loanst_id
            Session("accst_id") = loanst_id
            cmd_loanst.CommandText = str_loanst
            cmd_loanst.Connection = open_con.return_con
            adap_loanst = New SqlDataAdapter(cmd_loanst)
            adap_loanst.Fill(ds_loanst)
            If ds_loanst.Tables(0).Rows.Count = 0 Then
                Exit Sub
            Else

                txtstartdt.Text = ds_loanst.Tables(0).Rows(0).Item(0)
                Session("loan_date") = ds_loanst.Tables(0).Rows(0).Item(0)

                txtenddt.Text = System.DateTime.Now.Date




            End If



        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Sub loan_table(ByVal ds As DataSet, ByVal ds1 As DataSet)

       

        Dim tbl As Table = New Table()
        tbl.ID = "tbl_loanst"
        tbl.Style.Add("border-style", "solid")
        tbl.Style.Add("border-width", "1px")
        tbl.Style.Add(" border-color", "gray")
        tbl.Style.Add("width", "100%")
        PlaceHolder1.Controls.Clear()
        PlaceHolder1.Controls.Add(tbl)

        Dim date_loanst As Label = New Label()
        date_loanst.Text = "Date"
        date_loanst.Font.Bold = True

        date_loanst.Width = "160"
       

        date_loanst.Style.Add("font-size", "14px")
        date_loanst.Style.Add("font-family", "Times New Roman")
        date_loanst.Style.Add("font-weight", "bold")
        date_loanst.Style.Add("text-align", "center")
        date_loanst.Style.Add("background-color", "#EFEFEF")


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim det As Label = New Label
        det.Text = "Transaction Details"
        det.Font.Bold = True
        det.Width = "250"
        det.Style.Add("font-size", "14px")
        det.Style.Add("font-family", "Times New Roman")
        det.Style.Add("font-weight", "bold")
        det.Style.Add("text-align", "center")
        det.Style.Add("background-color", "#EFEFEF")


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim debit As Label = New Label
        debit.Text = "Debit"
        debit.Font.Bold = True

        debit.Width = "160"
        

        debit.Style.Add("font-size", "14px")
        debit.Style.Add("font-family", "Times New Roman")
        debit.Style.Add("font-weight", "bold")
        debit.Style.Add("text-align", "center")
        debit.Style.Add("background-color", "#EFEFEF")


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim credit As Label = New Label
        credit.Text = "Credit"
        credit.Font.Bold = True

        credit.Width = "160"
       

        credit.Style.Add("font-size", "14px")
        credit.Style.Add("font-family", "Times New Roman")
        credit.Style.Add("font-weight", "bold")
        credit.Style.Add("text-align", "center")
        credit.Style.Add("background-color", "#EFEFEF")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim bal As Label = New Label
        bal.Text = "Balance"
        bal.Font.Bold = True

        bal.Width = "160"
     

        bal.Style.Add("font-size", "14px")
        bal.Style.Add("font-family", "Times New Roman")
        bal.Style.Add("font-weight", "bold")
        bal.Style.Add("text-align", "center")
        bal.Style.Add("background-color", "#EFEFEF")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tcm As TableCell = New TableCell()
        Dim tcm_cell1 As TableCell = New TableCell()
        Dim tcm_cell2 As TableCell = New TableCell()
        Dim tcm_cell3 As TableCell = New TableCell()
        Dim tcm_cell4 As TableCell = New TableCell()
        Dim trm As TableRow = New TableRow()
        tcm.Style.Add("border-style", "solid")
        tcm.Style.Add("border-width", "1px")
        tcm.Style.Add(" border-color", "gray")
        tcm_cell1.Style.Add("border-style", "solid")
        tcm_cell1.Style.Add("border-width", "1px")
        tcm_cell1.Style.Add(" border-color", "gray")
        tcm_cell2.Style.Add("border-style", "solid")
        tcm_cell2.Style.Add("border-width", "1px")
        tcm_cell2.Style.Add(" border-color", "gray")
        tcm_cell3.Style.Add("border-style", "solid")
        tcm_cell3.Style.Add("border-width", "1px")
        tcm_cell3.Style.Add(" border-color", "gray")
        tcm_cell4.Style.Add("border-style", "solid")
        tcm_cell4.Style.Add("border-width", "1px")
        tcm_cell4.Style.Add(" border-color", "gray")
        trm.Style.Add("border-style", "solid")
        trm.Style.Add("border-width", "1px")
        trm.Style.Add(" border-color", "gray")
        tcm.Controls.Add(date_loanst)
        tcm_cell1.Controls.Add(det)
        tcm_cell2.Controls.Add(debit)
        tcm_cell3.Controls.Add(credit)
        tcm_cell4.Controls.Add(bal)
        trm.Cells.Add(tcm)
        trm.Cells.Add(tcm_cell1)
        trm.Cells.Add(tcm_cell2)
        trm.Cells.Add(tcm_cell3)
        trm.Cells.Add(tcm_cell4)
        tbl.Rows.Add(trm)


        Dim str_Description As String
        Dim dtm_Transaction_Date As String
        Dim int_Amount As Double
        Dim int_Amount_new As String
        Dim int_Balance As Double
        Dim int_Balance_new As String
        Dim int_Loan_Amount As Double
        Dim bln_Opening_Balance_Displayed As Boolean

        int_Loan_Amount = Session("ln_amt")
        int_Balance = int_Loan_Amount
        bln_Opening_Balance_Displayed = False
        str_Description = "Loan Amount"
        int_Amount = open_con.check_amount_format(Math.Round(CDbl(int_Loan_Amount), 2))
        int_Amount_new = open_con.new_amount(int_Amount)
        int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Loan_Amount), 2))
        int_Balance_new = open_con.new_amount(int_Balance)
        dtm_Transaction_Date = Session("loan_date")

        Dim transdate_new As String
        transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
        Dim month_trans_new, year_trans_new, day_trans_new As String

        day_trans_new = Left(transdate_new, 2)

        Dim pos_int_Total1 As Integer
        pos_int_Total1 = InStr(1, transdate_new, "/")

        month_trans_new = Mid(transdate_new, pos_int_Total1 + 1, 3)
        year_trans_new = Val(Right(transdate_new, 4))
        transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
        dtm_Transaction_Date = transdate_new

        If Session("loan_date") >= txtstartdt.Text And Session("loan_date") <= txtenddt.Text Then

            Dim date_loanst1 As Label = New Label()
            date_loanst1.Width = "160"
            date_loanst1.Style.Add("font-size", "14px")
            date_loanst1.Style.Add("font-family", "Times New Roman")
            date_loanst1.Style.Add("font-weight", "bold")
            date_loanst1.Style.Add("text-align", "center")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim det1 As Label = New Label
            det1.Width = "250"
            det1.Style.Add("font-size", "14px")
            det1.Style.Add("font-family", "Times New Roman")
            det1.Style.Add("font-weight", "bold")
            det1.Style.Add("text-align", "left")



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim debit1 As Label = New Label
            debit1.Width = "160"
            debit1.Style.Add("font-size", "14px")
            debit1.Style.Add("font-family", "Times New Roman")
            debit1.Style.Add("font-weight", "bold")
            debit1.Style.Add("text-align", "right")



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim credit1 As Label = New Label
            credit1.Width = "160"
            credit1.Style.Add("font-size", "14px")
            credit1.Style.Add("font-family", "Times New Roman")
            credit1.Style.Add("font-weight", "bold")
            credit1.Style.Add("text-align", "right")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim bal1 As Label = New Label
            bal1.Width = "160"
            bal1.Style.Add("font-size", "14px")
            bal1.Style.Add("font-family", "Times New Roman")
            bal1.Style.Add("font-weight", "bold")
            bal1.Style.Add("text-align", "right")



            date_loanst1.Text = dtm_Transaction_Date
            det1.Text = "Opening balance"
            debit1.Text = ""
            credit1.Text = ""
            bal1.Text = "$00.00"

            Dim tcm1 As TableCell = New TableCell()
            Dim tcm1_cell1 As TableCell = New TableCell()
            Dim tcm1_cell2 As TableCell = New TableCell()
            Dim tcm1_cell3 As TableCell = New TableCell()
            Dim tcm1_cell4 As TableCell = New TableCell()
            Dim trm1 As TableRow = New TableRow()
            tcm1.Style.Add("border-style", "solid")
            tcm1.Style.Add("border-width", "1px")
            tcm1.Style.Add(" border-color", "gray")
            tcm1_cell1.Style.Add("border-style", "solid")
            tcm1_cell1.Style.Add("border-width", "1px")
            tcm1_cell1.Style.Add("border-color", "gray")
            tcm1_cell2.Style.Add("border-style", "solid")
            tcm1_cell2.Style.Add("border-width", "1px")
            tcm1_cell2.Style.Add("border-color", "gray")
            tcm1_cell3.Style.Add("border-style", "solid")
            tcm1_cell3.Style.Add("border-width", "1px")
            tcm1_cell3.Style.Add(" border-color", "gray")
            tcm1_cell4.Style.Add(" border-style", "solid")
            tcm1_cell4.Style.Add(" border-width", "1px")
            tcm1_cell4.Style.Add(" border-color", "gray")
            tcm1.Controls.Add(date_loanst1)
            tcm1_cell1.Controls.Add(det1)
            tcm1_cell2.Controls.Add(debit1)
            tcm1_cell3.Controls.Add(credit1)
            tcm1_cell4.Controls.Add(bal1)
            trm1.Cells.Add(tcm1)
            trm1.Cells.Add(tcm1_cell1)
            trm1.Cells.Add(tcm1_cell2)
            trm1.Cells.Add(tcm1_cell3)
            trm1.Cells.Add(tcm1_cell4)
            tbl.Rows.Add(trm1)


            ''''''''''''''''''''''''''''''''''''''nxt row
            Dim date_loanst2 As Label = New Label()
            date_loanst2.Width = "160"
            date_loanst2.Style.Add("font-size", "14px")
            date_loanst2.Style.Add("font-family", "Times New Roman")
            date_loanst2.Style.Add("font-weight", "bold")
            date_loanst2.Style.Add("text-align", "center")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim det2 As Label = New Label
            det2.Width = "250"
            det2.Style.Add("font-size", "14px")
            det2.Style.Add("font-family", "Times New Roman")
            det2.Style.Add("font-weight", "bold")
            det2.Style.Add("text-align", "left")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim debit2 As Label = New Label
            debit2.Width = "160"
            debit2.Style.Add("font-size", "14px")
            debit2.Style.Add("font-family", "Times New Roman")
            debit2.Style.Add("font-weight", "bold")
            debit2.Style.Add("text-align", "right")



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim credit2 As Label = New Label
            credit2.Width = "160"
            credit2.Style.Add("font-size", "14px")
            credit2.Style.Add("font-family", "Times New Roman")
            credit2.Style.Add("font-weight", "bold")
            credit2.Style.Add("text-align", "right")


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim bal2 As Label = New Label
            bal2.Width = "160"
            bal2.Style.Add("font-size", "14px")
            bal2.Style.Add("font-family", "Times New Roman")
            bal2.Style.Add("font-weight", "bold")
            bal2.Style.Add("text-align", "right")

            Dim tcm2 As TableCell = New TableCell()
            Dim tcm2_cell1 As TableCell = New TableCell()
            Dim tcm2_cell2 As TableCell = New TableCell()
            Dim tcm2_cell3 As TableCell = New TableCell()
            Dim tcm2_cell4 As TableCell = New TableCell()
            Dim trm2 As TableRow = New TableRow()

            tcm2.Style.Add("border-style", "solid")
            tcm2.Style.Add("border-width", "1px")
            tcm2.Style.Add(" border-color", "gray")
            tcm2_cell1.Style.Add("border-style", "solid")
            tcm2_cell1.Style.Add("border-width", "1px")
            tcm2_cell1.Style.Add(" border-color", "gray")
            tcm2_cell2.Style.Add("border-style", "solid")
            tcm2_cell2.Style.Add("border-width", "1px")
            tcm2_cell2.Style.Add("border-color", "gray")
            tcm2_cell3.Style.Add("border-style", "solid")
            tcm2_cell3.Style.Add("border-width", "1px")
            tcm2_cell3.Style.Add(" border-color", "gray")
            tcm2_cell4.Style.Add("border-style", "solid")
            tcm2_cell4.Style.Add("border-width", "1px")
            tcm2_cell4.Style.Add(" border-color", "gray")

            date_loanst2.Text = dtm_Transaction_Date
            det2.Text = str_Description
            debit2.Text = int_Amount_new
            credit2.Text = ""
            bal2.Text = int_Balance_new & "Dr"

            tcm2.Controls.Add(date_loanst2)
            tcm2_cell1.Controls.Add(det2)
            tcm2_cell2.Controls.Add(debit2)
            tcm2_cell3.Controls.Add(credit2)
            tcm2_cell4.Controls.Add(bal2)
            trm2.Cells.Add(tcm2)
            trm2.Cells.Add(tcm2_cell1)
            trm2.Cells.Add(tcm2_cell2)
            trm2.Cells.Add(tcm2_cell3)
            trm2.Cells.Add(tcm2_cell4)
            tbl.Rows.Add(trm2)

            bln_Opening_Balance_Displayed = True

        End If
        If Not ds.Tables(0).Rows.Count = 0 Then

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                str_Description = ds.Tables(0).Rows(i).Item("Description").ToString
                int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds.Tables(0).Rows(i).Item("Fee")), 2))
                int_Amount_new = open_con.new_amount(int_Amount)
                int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance + ds.Tables(0).Rows(i).Item("Fee")), 2))
                int_Balance_new = open_con.new_amount(int_Balance)
                'dtm_Transaction_Date = Session("loan_date")

                ''''''''''''''''''''''''''''''''''''''nxt row
                Dim date_loanst3 As Label = New Label()
                date_loanst3.ID = "date_loanst" & Format(i, "00")
                date_loanst3.Width = "160"
                date_loanst3.Style.Add("font-size", "14px")
                date_loanst3.Style.Add("font-family", "Times New Roman")
                date_loanst3.Style.Add("font-weight", "bold")
                date_loanst3.Style.Add("text-align", "center")


                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim det3 As Label = New Label
                det3.ID = "det" & Format(i, "00")
                det3.Width = "250"
                det3.Style.Add("font-size", "14px")
                det3.Style.Add("font-family", "Times New Roman")
                det3.Style.Add("font-weight", "bold")
                det3.Style.Add("text-align", "left")


                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim debit3 As Label = New Label
                debit3.ID = "debit" & Format(i, "00")
                debit3.Width = "160"
                debit3.Style.Add("font-size", "14px")
                debit3.Style.Add("font-family", "Times New Roman")
                debit3.Style.Add("font-weight", "bold")
                debit3.Style.Add("text-align", "right")



                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim credit3 As Label = New Label
                credit3.ID = "credit" & Format(i, "00")
                credit3.Width = "160"
                credit3.Style.Add("font-size", "14px")
                credit3.Style.Add("font-family", "Times New Roman")
                credit3.Style.Add("font-weight", "bold")
                credit3.Style.Add("text-align", "right")


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim bal3 As Label = New Label
                bal3.ID = "bal" & Format(i, "00")
                bal3.Width = "160"
                bal3.Style.Add("font-size", "14px")
                bal3.Style.Add("font-family", "Times New Roman")
                bal3.Style.Add("font-weight", "bold")
                bal3.Style.Add("text-align", "right")

                Dim tcm3 As TableCell = New TableCell()
                Dim trm3 As TableRow = New TableRow()
                Dim tcm3_cell1 As TableCell = New TableCell()
                Dim tcm3_cell2 As TableCell = New TableCell()
                Dim tcm3_cell3 As TableCell = New TableCell()
                Dim tcm3_cell4 As TableCell = New TableCell()
                tcm3.Style.Add("border-style", "solid")
                tcm3.Style.Add("border-width", "1px")
                tcm3.Style.Add(" border-color", "gray")
                tcm3_cell1.Style.Add("border-style", "solid")
                tcm3_cell1.Style.Add("border-width", "1px")
                tcm3_cell1.Style.Add(" border-color", "gray")
                tcm3_cell2.Style.Add("border-style", "solid")
                tcm3_cell2.Style.Add("border-width", "1px")
                tcm3_cell2.Style.Add(" border-color", "gray")
                tcm3_cell3.Style.Add("border-style", "solid")
                tcm3_cell3.Style.Add("border-width", "1px")
                tcm3_cell3.Style.Add(" border-color", "gray")
                tcm3_cell4.Style.Add("border-style", "solid")
                tcm3_cell4.Style.Add("border-width", "1px")
                tcm3_cell4.Style.Add(" border-color", "gray")

                date_loanst3.Text = dtm_Transaction_Date
                det3.Text = str_Description
                debit3.Text = int_Amount_new
                credit3.Text = ""
                bal3.Text = int_Balance_new & "Dr"

                tcm3.Controls.Add(date_loanst3)
                tcm3_cell1.Controls.Add(det3)
                tcm3_cell2.Controls.Add(debit3)
                tcm3_cell3.Controls.Add(credit3)
                tcm3_cell4.Controls.Add(bal3)
                trm3.Cells.Add(tcm3)
                trm3.Cells.Add(tcm3_cell1)
                trm3.Cells.Add(tcm3_cell2)
                trm3.Cells.Add(tcm3_cell3)
                trm3.Cells.Add(tcm3_cell4)
                tbl.Rows.Add(trm3)

            Next

        End If
        Dim strNoticesIDs, strPaymentIDs, strFeeIDs, strDishonourIDs, strWaiveIDs As String

        strNoticesIDs = "0"
        strPaymentIDs = "0"
        strNoticesIDs = "0"
        strFeeIDs = "0"
        strDishonourIDs = "0"
        strWaiveIDs = "0"

        For j As Integer = 0 To ds1.Tables(0).Rows.Count - 1

            If bln_Opening_Balance_Displayed = False And ds1.Tables(0).Rows(j).Item("Payment_Date").ToString >= txtstartdt.Text Then

                ''''''''''''''''''''''''''''''''''''''nxt row
                Dim date_loanst4 As Label = New Label()
                date_loanst4.ID = "date_loanst" & Format(j, "00")
                date_loanst4.Width = "160"
                date_loanst4.Style.Add("font-size", "14px")
                date_loanst4.Style.Add("font-family", "Times New Roman")
                date_loanst4.Style.Add("font-weight", "bold")
                date_loanst4.Style.Add("text-align", "center")


                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim det4 As Label = New Label
                det4.ID = "det" & Format(j, "00")
                det4.Width = "250"
                det4.Style.Add("font-size", "14px")
                det4.Style.Add("font-family", "Times New Roman")
                det4.Style.Add("font-weight", "bold")
                det4.Style.Add("text-align", "left")


                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim debit4 As Label = New Label
                debit4.ID = "debit" & Format(j, "00")
                debit4.Width = "160"
                debit4.Style.Add("font-size", "14px")
                debit4.Style.Add("font-family", "Times New Roman")
                debit4.Style.Add("font-weight", "bold")
                debit4.Style.Add("text-align", "right")



                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim credit4 As Label = New Label
                credit4.ID = "credit" & Format(j, "00")
                credit4.Width = "160"
                credit4.Style.Add("font-size", "14px")
                credit4.Style.Add("font-family", "Times New Roman")
                credit4.Style.Add("font-weight", "bold")
                credit4.Style.Add("text-align", "right")


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim bal4 As Label = New Label
                bal4.ID = "bal" & Format(j, "00")
                bal4.Width = "160"
                bal4.Style.Add("font-size", "14px")
                bal4.Style.Add("font-family", "Times New Roman")
                bal4.Style.Add("font-weight", "bold")
                bal4.Style.Add("text-align", "right")

                Dim tcm4 As TableCell = New TableCell()
                Dim tcm4_cell1 As TableCell = New TableCell()
                Dim tcm4_cell2 As TableCell = New TableCell()
                Dim tcm4_cell3 As TableCell = New TableCell()
                Dim tcm4_cell4 As TableCell = New TableCell()
                Dim trm4 As TableRow = New TableRow()
                tcm4.Style.Add("border-style", "solid")
                tcm4.Style.Add("border-width", "1px")
                tcm4.Style.Add(" border-color", "gray")
                tcm4_cell1.Style.Add("border-style", "solid")
                tcm4_cell1.Style.Add("border-width", "1px")
                tcm4_cell1.Style.Add(" border-color", "gray")
                tcm4_cell2.Style.Add("border-style", "solid")
                tcm4_cell2.Style.Add("border-width", "1px")
                tcm4_cell2.Style.Add(" border-color", "gray")
                tcm4_cell3.Style.Add("border-style", "solid")
                tcm4_cell3.Style.Add("border-width", "1px")
                tcm4_cell3.Style.Add(" border-color", "gray")
                tcm4_cell4.Style.Add("border-style", "solid")
                tcm4_cell4.Style.Add("border-width", "1px")
                tcm4_cell4.Style.Add(" border-color", "gray")

                Dim startdt_new As String
                startdt_new = CDate(txtstartdt.Text).ToString("dd/MMM/yyyy")
                Dim month_startdt, year_startdt, day_startdt As String

                day_startdt = Left(startdt_new, 2)


                pos_int_Total1 = InStr(1, startdt_new, "/")
                month_startdt = Mid(startdt_new, pos_int_Total1 + 1, 3)
                year_startdt = Val(Right(startdt_new, 4))
                startdt_new = day_startdt & "-" & month_startdt & "-" & year_startdt
                txtstartdt.Text = startdt_new
                date_loanst4.Text = txtstartdt.Text
                det4.Text = "Opening balance"
                debit4.Text = ""
                credit4.Text = ""
                bal4.Text = int_Balance_new & "Dr"

                tcm4.Controls.Add(date_loanst4)
                tcm4_cell1.Controls.Add(det4)
                tcm4_cell2.Controls.Add(debit4)
                tcm4_cell3.Controls.Add(credit4)
                tcm4_cell4.Controls.Add(bal4)
                trm4.Cells.Add(tcm4)
                trm4.Cells.Add(tcm4_cell1)
                trm4.Cells.Add(tcm4_cell2)
                trm4.Cells.Add(tcm4_cell3)
                trm4.Cells.Add(tcm4_cell4)
                tbl.Rows.Add(trm4)


                bln_Opening_Balance_Displayed = True

            End If

            If (ds1.Tables(0).Rows(j).Item("Fee_Status").ToString = "Arear notice fee" Or ds1.Tables(0).Rows(j).Item("Fee_Status").ToString = "Variation fee" Or ds1.Tables(0).Rows(j).Item("Fee_Status").ToString = "Letter of demand fee" Or ds1.Tables(0).Rows(j).Item("Fee_Status").ToString = "Default notice fee" Or ds1.Tables(0).Rows(j).Item("Fee_Status").ToString = "Statement of account fee" Or ds1.Tables(0).Rows(j).Item("Fee_Status").ToString = "Enforcement fee") And str_count(strNoticesIDs, ds1.Tables(0).Rows(j).Item("Payment_ID")) = 0 And ds1.Tables(0).Rows(j).Item("description").ToString <> "Paid" Then
                If Trim(ds1.Tables(0).Rows(j).Item("Fee_Status").ToString) = "Arear notice fee" Then
                    str_Description = "Arrears notice fee"
                Else
                    str_Description = ds1.Tables(0).Rows(j).Item("Fee_Status").ToString
                End If

                int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds1.Tables(0).Rows(j).Item("Amount").ToString), 2))
                int_Amount_new = open_con.new_amount(int_Amount)
                int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance + ds1.Tables(0).Rows(j).Item("Amount").ToString), 2))
                int_Balance_new = open_con.new_amount(int_Balance)




                dtm_Transaction_Date = ds1.Tables(0).Rows(j).Item("Payment_Date")
                transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
                day_trans_new = Left(transdate_new, 2)


                pos_int_Total1 = InStr(1, transdate_new, "/")
                month_trans_new = Mid(transdate_new, pos_int_Total1 + 1, 3)
                year_trans_new = Val(Right(transdate_new, 4))
                transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
                dtm_Transaction_Date = transdate_new

                If ds1.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt.Text And ds1.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt.Text Then

                    ''''''''''''''''''''''''''''''''''''''nxt row
                    Dim date_loanst5 As Label = New Label()
                    date_loanst5.ID = "date_loanst" & Format(j, "00")
                    date_loanst5.Width = "160"
                    date_loanst5.Style.Add("font-size", "14px")
                    date_loanst5.Style.Add("font-family", "Times New Roman")
                    date_loanst5.Style.Add("font-weight", "bold")
                    date_loanst5.Style.Add("text-align", "center")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim det5 As Label = New Label
                    det5.ID = "det" & Format(j, "00")
                    det5.Width = "250"
                    det5.Style.Add("font-size", "14px")
                    det5.Style.Add("font-family", "Times New Roman")
                    det5.Style.Add("font-weight", "bold")
                    det5.Style.Add("text-align", "left")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim debit5 As Label = New Label
                    debit5.ID = "debit" & Format(j, "00")
                    debit5.Width = "160"
                    debit5.Style.Add("font-size", "14px")
                    debit5.Style.Add("font-family", "Times New Roman")
                    debit5.Style.Add("font-weight", "bold")
                    debit5.Style.Add("text-align", "right")



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim credit5 As Label = New Label
                    credit5.ID = "credit" & Format(j, "00")
                    credit5.Width = "160"
                    credit5.Style.Add("font-size", "14px")
                    credit5.Style.Add("font-family", "Times New Roman")
                    credit5.Style.Add("font-weight", "bold")
                    credit5.Style.Add("text-align", "right")


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim bal5 As Label = New Label
                    bal5.ID = "bal" & Format(j, "00")
                    bal5.Width = "160"
                    bal5.Style.Add("font-size", "14px")
                    bal5.Style.Add("font-family", "Times New Roman")
                    bal5.Style.Add("font-weight", "bold")
                    bal5.Style.Add("text-align", "right")

                    Dim tcm5 As TableCell = New TableCell()
                    Dim tcm5_cell1 As TableCell = New TableCell()
                    Dim tcm5_cell2 As TableCell = New TableCell()
                    Dim tcm5_cell3 As TableCell = New TableCell()
                    Dim tcm5_cell4 As TableCell = New TableCell()
                    Dim trm5 As TableRow = New TableRow()
                    tcm5.Style.Add("border-style", "solid")
                    tcm5.Style.Add("border-width", "1px")
                    tcm5.Style.Add(" border-color", "gray")
                    tcm5_cell1.Style.Add("border-style", "solid")
                    tcm5_cell1.Style.Add("border-width", "1px")
                    tcm5_cell1.Style.Add(" border-color", "gray")
                    tcm5_cell2.Style.Add("border-style", "solid")
                    tcm5_cell2.Style.Add("border-width", "1px")
                    tcm5_cell2.Style.Add(" border-color", "gray")
                    tcm5_cell3.Style.Add("border-style", "solid")
                    tcm5_cell3.Style.Add("border-width", "1px")
                    tcm5_cell3.Style.Add(" border-color", "gray")
                    tcm5_cell4.Style.Add("border-style", "solid")
                    tcm5_cell4.Style.Add("border-width", "1px")
                    tcm5_cell4.Style.Add(" border-color", "gray")

                    date_loanst5.Text = dtm_Transaction_Date
                    det5.Text = str_Description
                    debit5.Text = int_Amount_new
                    credit5.Text = ""
                    bal5.Text = int_Balance_new & "Dr"

                    tcm5.Controls.Add(date_loanst5)
                    tcm5_cell1.Controls.Add(det5)
                    tcm5_cell2.Controls.Add(debit5)
                    tcm5_cell3.Controls.Add(credit5)
                    tcm5_cell4.Controls.Add(bal5)
                    trm5.Cells.Add(tcm5)
                    trm5.Cells.Add(tcm5_cell1)
                    trm5.Cells.Add(tcm5_cell2)
                    trm5.Cells.Add(tcm5_cell3)
                    trm5.Cells.Add(tcm5_cell4)
                    tbl.Rows.Add(trm5)

                End If
                strNoticesIDs = strNoticesIDs & ds1.Tables(0).Rows(j).Item("Payment_ID").ToString & ","


            ElseIf ds1.Tables(0).Rows(j).Item("description").ToString = "Paid" And str_count(strPaymentIDs, ds1.Tables(0).Rows(j).Item("Payment_ID").ToString) = 0 Then

                If Trim(ds1.Tables(0).Rows(j).Item("Payment_Method").ToString) = "Cas" Then
                    str_Description = "Payment made by cash"
                ElseIf Trim(ds1.Tables(0).Rows(j).Item("Payment_Method").ToString) = "Chq" Then
                    str_Description = "Payment made by cheque"
                ElseIf Trim(ds1.Tables(0).Rows(j).Item("Payment_Method").ToString) = "Sal" Then
                    str_Description = "Payment made by salary deduction"
                ElseIf Trim(ds1.Tables(0).Rows(j).Item("Payment_Method").ToString) = "Cre" Then
                    str_Description = "Payment made by Credit"

                Else
                    str_Description = "Payment made by direct debit"
                End If

                dtm_Transaction_Date = ds1.Tables(0).Rows(j).Item("Payment_Date")
                transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
                day_trans_new = Left(transdate_new, 2)


                pos_int_Total1 = InStr(1, transdate_new, "/")
                month_trans_new = Mid(transdate_new, pos_int_Total1 + 1, 3)
                year_trans_new = Val(Right(transdate_new, 4))
                transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
                dtm_Transaction_Date = transdate_new

                int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds1.Tables(0).Rows(j).Item("Amount").ToString), 2))
                int_Amount_new = open_con.new_amount(int_Amount)
                int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance - ds1.Tables(0).Rows(j).Item("Amount").ToString), 2))
                int_Balance_new = open_con.new_amount(int_Balance)



                If ds1.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt.Text And ds1.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt.Text Then
                    ''''''''''''''''''''''''''''''''''''''nxt row
                    Dim date_loanst6 As Label = New Label()
                    date_loanst6.ID = "date_loanst" & Format(j, "00")
                    date_loanst6.Width = "160"
                    date_loanst6.Style.Add("font-size", "14px")
                    date_loanst6.Style.Add("font-family", "Times New Roman")
                    date_loanst6.Style.Add("font-weight", "bold")
                    date_loanst6.Style.Add("text-align", "center")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim det6 As Label = New Label
                    det6.ID = "det" & Format(j, "00")
                    det6.Width = "250"
                    det6.Style.Add("font-size", "14px")
                    det6.Style.Add("font-family", "Times New Roman")
                    det6.Style.Add("font-weight", "bold")
                    det6.Style.Add("text-align", "left")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim debit6 As Label = New Label
                    debit6.ID = "debit" & Format(j, "00")
                    debit6.Width = "160"
                    debit6.Style.Add("font-size", "14px")
                    debit6.Style.Add("font-family", "Times New Roman")
                    debit6.Style.Add("font-weight", "bold")
                    debit6.Style.Add("text-align", "right")



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim credit6 As Label = New Label
                    credit6.ID = "credit" & Format(j, "00")
                    credit6.Width = "160"
                    credit6.Style.Add("font-size", "14px")
                    credit6.Style.Add("font-family", "Times New Roman")
                    credit6.Style.Add("font-weight", "bold")
                    credit6.Style.Add("text-align", "right")


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim bal6 As Label = New Label
                    bal6.ID = "bal" & Format(j, "00")
                    bal6.Width = "160"
                    bal6.Style.Add("font-size", "14px")
                    bal6.Style.Add("font-family", "Times New Roman")
                    bal6.Style.Add("font-weight", "bold")
                    bal6.Style.Add("text-align", "right")

                    Dim tcm6 As TableCell = New TableCell()
                    Dim tcm6_cell1 As TableCell = New TableCell()
                    Dim tcm6_cell2 As TableCell = New TableCell()
                    Dim tcm6_cell3 As TableCell = New TableCell()
                    Dim tcm6_cell4 As TableCell = New TableCell()
                    Dim trm6 As TableRow = New TableRow()
                    tcm6.Style.Add("border-style", "solid")
                    tcm6.Style.Add("border-width", "1px")
                    tcm6.Style.Add(" border-color", "gray")
                    tcm6_cell1.Style.Add("border-style", "solid")
                    tcm6_cell1.Style.Add("border-width", "1px")
                    tcm6_cell1.Style.Add(" border-color", "gray")
                    tcm6_cell2.Style.Add("border-style", "solid")
                    tcm6_cell2.Style.Add("border-width", "1px")
                    tcm6_cell2.Style.Add(" border-color", "gray")
                    tcm6_cell3.Style.Add("border-style", "solid")
                    tcm6_cell3.Style.Add("border-width", "1px")
                    tcm6_cell3.Style.Add(" border-color", "gray")
                    tcm6_cell4.Style.Add("border-style", "solid")
                    tcm6_cell4.Style.Add("border-width", "1px")
                    tcm6_cell4.Style.Add(" border-color", "gray")

                    date_loanst6.Text = dtm_Transaction_Date
                    det6.Text = str_Description
                    debit6.Text = ""
                    credit6.Text = int_Amount_new
                    bal6.Text = int_Balance_new & "Dr"

                    tcm6.Controls.Add(date_loanst6)
                    tcm6_cell1.Controls.Add(det6)
                    tcm6_cell2.Controls.Add(debit6)
                    tcm6_cell3.Controls.Add(credit6)
                    tcm6_cell4.Controls.Add(bal6)
                    trm6.Cells.Add(tcm6)
                    trm6.Cells.Add(tcm6_cell1)
                    trm6.Cells.Add(tcm6_cell2)
                    trm6.Cells.Add(tcm6_cell3)
                    trm6.Cells.Add(tcm6_cell4)
                    tbl.Rows.Add(trm6)

                End If
                strPaymentIDs = strPaymentIDs & ds1.Tables(0).Rows(j).Item("Payment_ID") & ","

            ElseIf ds1.Tables(0).Rows(j).Item("description").ToString = "Dishonour" And str_count(strDishonourIDs, ds1.Tables(0).Rows(j).Item("Payment_ID")) = 0 Then

                If ds1.Tables(0).Rows(j).Item("Payment_Method") = "Chq" Then
                    str_Description = "Cheque Payment dishonoured"
                ElseIf ds1.Tables(0).Rows(j).Item("Payment_Method") = "Sal" Then
                    str_Description = "Payroll dishonoured"
                Else
                    str_Description = "Direct debit dishonoured"
                End If

                int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds1.Tables(0).Rows(j).Item("Amount")), 2))
                int_Amount_new = open_con.new_amount(int_Amount)
                int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance + ds1.Tables(0).Rows(j).Item("Amount")), 2))
                int_Balance_new = open_con.new_amount(int_Balance)

                dtm_Transaction_Date = ds1.Tables(0).Rows(j).Item("Payment_Date")
                transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
                day_trans_new = Left(transdate_new, 2)


                pos_int_Total1 = InStr(1, transdate_new, "/")
                month_trans_new = Mid(transdate_new, pos_int_Total1 + 1, 3)
                year_trans_new = Val(Right(transdate_new, 4))
                transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
                dtm_Transaction_Date = transdate_new

                If ds1.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt.Text And ds1.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt.Text Then

                    ''''''''''''''''''''''''''''''''''''''nxt row
                    Dim date_loanst7 As Label = New Label()
                    date_loanst7.ID = "date_loanst" & Format(j, "00")
                    date_loanst7.Width = "160"
                    date_loanst7.Style.Add("font-size", "14px")
                    date_loanst7.Style.Add("font-family", "Times New Roman")
                    date_loanst7.Style.Add("font-weight", "bold")
                    date_loanst7.Style.Add("text-align", "center")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim det7 As Label = New Label
                    det7.ID = "det" & Format(j, "00")
                    det7.Width = "250"
                    det7.Style.Add("font-size", "14px")
                    det7.Style.Add("font-family", "Times New Roman")
                    det7.Style.Add("font-weight", "bold")
                    det7.Style.Add("text-align", "left")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim debit7 As Label = New Label
                    debit7.ID = "debit" & Format(j, "00")
                    debit7.Width = "160"
                    debit7.Style.Add("font-size", "14px")
                    debit7.Style.Add("font-family", "Times New Roman")
                    debit7.Style.Add("font-weight", "bold")
                    debit7.Style.Add("text-align", "right")



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim credit7 As Label = New Label
                    credit7.ID = "credit" & Format(j, "00")
                    credit7.Width = "160"
                    credit7.Style.Add("font-size", "14px")
                    credit7.Style.Add("font-family", "Times New Roman")
                    credit7.Style.Add("font-weight", "bold")
                    credit7.Style.Add("text-align", "right")


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim bal7 As Label = New Label
                    bal7.ID = "bal" & Format(j, "00")
                    bal7.Width = "160"
                    bal7.Style.Add("font-size", "14px")
                    bal7.Style.Add("font-family", "Times New Roman")
                    bal7.Style.Add("font-weight", "bold")
                    bal7.Style.Add("text-align", "right")

                    Dim tcm7 As TableCell = New TableCell()
                    Dim tcm7_cell1 As TableCell = New TableCell()
                    Dim tcm7_cell2 As TableCell = New TableCell()
                    Dim tcm7_cell3 As TableCell = New TableCell()
                    Dim tcm7_cell4 As TableCell = New TableCell()
                    Dim trm7 As TableRow = New TableRow()
                    tcm7.Style.Add("border-style", "solid")
                    tcm7.Style.Add("border-width", "1px")
                    tcm7.Style.Add(" border-color", "gray")
                    tcm7_cell1.Style.Add("border-style", "solid")
                    tcm7_cell1.Style.Add("border-width", "1px")
                    tcm7_cell1.Style.Add(" border-color", "gray")
                    tcm7_cell2.Style.Add("border-style", "solid")
                    tcm7_cell2.Style.Add("border-width", "1px")
                    tcm7_cell2.Style.Add(" border-color", "gray")
                    tcm7_cell3.Style.Add("border-style", "solid")
                    tcm7_cell3.Style.Add("border-width", "1px")
                    tcm7_cell3.Style.Add(" border-color", "gray")
                    tcm7_cell4.Style.Add("border-style", "solid")
                    tcm7_cell4.Style.Add("border-width", "1px")
                    tcm7_cell4.Style.Add(" border-color", "gray")

                    date_loanst7.Text = dtm_Transaction_Date
                    det7.Text = str_Description
                    debit7.Text = int_Amount_new
                    credit7.Text = ""
                    bal7.Text = int_Balance_new & "Dr"

                    tcm7.Controls.Add(date_loanst7)
                    tcm7_cell1.Controls.Add(det7)
                    tcm7_cell2.Controls.Add(debit7)
                    tcm7_cell3.Controls.Add(credit7)
                    tcm7_cell4.Controls.Add(bal7)
                    trm7.Cells.Add(tcm7)
                    trm7.Cells.Add(tcm7_cell1)
                    trm7.Cells.Add(tcm7_cell2)
                    trm7.Cells.Add(tcm7_cell3)
                    trm7.Cells.Add(tcm7_cell4)
                    tbl.Rows.Add(trm7)


                End If

                strDishonourIDs = strDishonourIDs & ds1.Tables(0).Rows(j).Item("Payment_ID") & ","

            ElseIf (ds1.Tables(0).Rows(j).Item("Fee_Status").ToString = "Dishonoured fee" Or ds1.Tables(0).Rows(j).Item("Fee_Status").ToString = "Cancellation fee") And str_count(strFeeIDs, ds1.Tables(0).Rows(j).Item("Payment_ID")) = 0 Then

                str_Description = ds1.Tables(0).Rows(j).Item("Fee_Status")

                int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds1.Tables(0).Rows(j).Item("Amount")), 2))
                int_Amount_new = open_con.new_amount(int_Amount)
                int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance + ds1.Tables(0).Rows(j).Item("Amount")), 2))
                int_Balance_new = open_con.new_amount(int_Balance)
                dtm_Transaction_Date = ds1.Tables(0).Rows(j).Item("Payment_Date")
                transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
                day_trans_new = Left(transdate_new, 2)


                pos_int_Total1 = InStr(1, transdate_new, "/")
                month_trans_new = Mid(transdate_new, pos_int_Total1 + 1, 3)
                year_trans_new = Val(Right(transdate_new, 4))
                transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
                dtm_Transaction_Date = transdate_new

                If ds1.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt.Text And ds1.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt.Text Then

                    ''''''''''''''''''''''''''''''''''''''nxt row
                    Dim date_loanst8 As Label = New Label()
                    date_loanst8.ID = "date_loanst" & Format(j, "00")
                    date_loanst8.Width = "160"
                    date_loanst8.Style.Add("font-size", "14px")
                    date_loanst8.Style.Add("font-family", "Times New Roman")
                    date_loanst8.Style.Add("font-weight", "bold")
                    date_loanst8.Style.Add("text-align", "center")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim det8 As Label = New Label
                    det8.ID = "det" & Format(j, "00")
                    det8.Width = "250"
                    det8.Style.Add("font-size", "14px")
                    det8.Style.Add("font-family", "Times New Roman")
                    det8.Style.Add("font-weight", "bold")
                    det8.Style.Add("text-align", "left")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim debit8 As Label = New Label
                    debit8.ID = "debit" & Format(j, "00")
                    debit8.Width = "160"
                    debit8.Style.Add("font-size", "14px")
                    debit8.Style.Add("font-family", "Times New Roman")
                    debit8.Style.Add("font-weight", "bold")
                    debit8.Style.Add("text-align", "right")



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim credit8 As Label = New Label
                    credit8.ID = "credit" & Format(j, "00")
                    credit8.Width = "160"
                    credit8.Style.Add("font-size", "14px")
                    credit8.Style.Add("font-family", "Times New Roman")
                    credit8.Style.Add("font-weight", "bold")
                    credit8.Style.Add("text-align", "right")


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim bal8 As Label = New Label
                    bal8.ID = "bal" & Format(j, "00")
                    bal8.Width = "160"
                    bal8.Style.Add("font-size", "14px")
                    bal8.Style.Add("font-family", "Times New Roman")
                    bal8.Style.Add("font-weight", "bold")
                    bal8.Style.Add("text-align", "right")

                    Dim tcm8 As TableCell = New TableCell()
                    Dim tcm8_cell1 As TableCell = New TableCell()
                    Dim tcm8_cell2 As TableCell = New TableCell()
                    Dim tcm8_cell3 As TableCell = New TableCell()
                    Dim tcm8_cell4 As TableCell = New TableCell()
                    Dim trm8 As TableRow = New TableRow()
                    tcm8.Style.Add("border-style", "solid")
                    tcm8.Style.Add("border-width", "1px")
                    tcm8.Style.Add(" border-color", "gray")
                    tcm8_cell1.Style.Add("border-style", "solid")
                    tcm8_cell1.Style.Add("border-width", "1px")
                    tcm8_cell1.Style.Add(" border-color", "gray")
                    tcm8_cell2.Style.Add("border-style", "solid")
                    tcm8_cell2.Style.Add("border-width", "1px")
                    tcm8_cell2.Style.Add(" border-color", "gray")
                    tcm8_cell3.Style.Add("border-style", "solid")
                    tcm8_cell3.Style.Add("border-width", "1px")
                    tcm8_cell3.Style.Add(" border-color", "gray")
                    tcm8_cell4.Style.Add("border-style", "solid")
                    tcm8_cell4.Style.Add("border-width", "1px")
                    tcm8_cell4.Style.Add(" border-color", "gray")

                    date_loanst8.Text = dtm_Transaction_Date
                    det8.Text = str_Description
                    debit8.Text = int_Amount_new
                    credit8.Text = ""
                    bal8.Text = int_Balance_new & "Dr"

                    tcm8.Controls.Add(date_loanst8)
                    tcm8_cell1.Controls.Add(det8)
                    tcm8_cell2.Controls.Add(debit8)
                    tcm8_cell3.Controls.Add(credit8)
                    tcm8_cell4.Controls.Add(bal8)
                    trm8.Cells.Add(tcm8)
                    trm8.Cells.Add(tcm8_cell1)
                    trm8.Cells.Add(tcm8_cell2)
                    trm8.Cells.Add(tcm8_cell3)
                    trm8.Cells.Add(tcm8_cell4)
                    tbl.Rows.Add(trm8)


                End If
                strFeeIDs = strFeeIDs & ds1.Tables(0).Rows(j).Item("Payment_ID") & ","

            ElseIf ds1.Tables(0).Rows(j).Item("Description").ToString = "Waived" And str_count(strWaiveIDs, ds1.Tables(0).Rows(j).Item("Payment_ID")) = 0 Then

                str_Description = ds1.Tables(0).Rows(j).Item("Description")

                int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds1.Tables(0).Rows(j).Item("Amount")), 2))
                int_Amount_new = open_con.new_amount(int_Amount)
                int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance - ds1.Tables(0).Rows(j).Item("Amount")), 2))
                int_Balance_new = open_con.new_amount(int_Balance)

                dtm_Transaction_Date = ds1.Tables(0).Rows(j).Item("Payment_Date")
                transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
                day_trans_new = Left(transdate_new, 2)


                pos_int_Total1 = InStr(1, transdate_new, "/")
                month_trans_new = Mid(transdate_new, pos_int_Total1 + 1, 3)
                year_trans_new = Val(Right(transdate_new, 4))
                transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
                dtm_Transaction_Date = transdate_new

                If ds1.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt.Text And ds1.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt.Text Then

                    ''''''''''''''''''''''''''''''''''''''nxt row
                    Dim date_loanst9 As Label = New Label()
                    date_loanst9.ID = "date_loanst" & Format(j, "00")
                    date_loanst9.Width = "160"
                    date_loanst9.Style.Add("font-size", "14px")
                    date_loanst9.Style.Add("font-family", "Times New Roman")
                    date_loanst9.Style.Add("font-weight", "bold")
                    date_loanst9.Style.Add("text-align", "center")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim det9 As Label = New Label
                    det9.ID = "det" & Format(j, "00")
                    det9.Width = "250"
                    det9.Style.Add("font-size", "14px")
                    det9.Style.Add("font-family", "Times New Roman")
                    det9.Style.Add("font-weight", "bold")
                    det9.Style.Add("text-align", "left")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim debit9 As Label = New Label
                    debit9.ID = "debit" & Format(j, "00")
                    debit9.Width = "160"
                    debit9.Style.Add("font-size", "14px")
                    debit9.Style.Add("font-family", "Times New Roman")
                    debit9.Style.Add("font-weight", "bold")
                    debit9.Style.Add("text-align", "right")



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim credit9 As Label = New Label
                    credit9.ID = "credit" & Format(j, "00")
                    credit9.Width = "160"
                    credit9.Style.Add("font-size", "14px")
                    credit9.Style.Add("font-family", "Times New Roman")
                    credit9.Style.Add("font-weight", "bold")
                    credit9.Style.Add("text-align", "right")


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim bal9 As Label = New Label
                    bal9.ID = "bal" & Format(j, "00")
                    bal9.Width = "160"
                    bal9.Style.Add("font-size", "14px")
                    bal9.Style.Add("font-family", "Times New Roman")
                    bal9.Style.Add("font-weight", "bold")
                    bal9.Style.Add("text-align", "right")

                    Dim tcm9 As TableCell = New TableCell()
                    Dim tcm9_cell1 As TableCell = New TableCell()
                    Dim tcm9_cell2 As TableCell = New TableCell()
                    Dim tcm9_cell3 As TableCell = New TableCell()
                    Dim tcm9_cell4 As TableCell = New TableCell()
                    Dim trm9 As TableRow = New TableRow()
                    tcm9.Style.Add("border-style", "solid")
                    tcm9.Style.Add("border-width", "1px")
                    tcm9.Style.Add(" border-color", "gray")
                    tcm9_cell1.Style.Add("border-style", "solid")
                    tcm9_cell1.Style.Add("border-width", "1px")
                    tcm9_cell1.Style.Add(" border-color", "gray")
                    tcm9_cell2.Style.Add("border-style", "solid")
                    tcm9_cell2.Style.Add("border-width", "1px")
                    tcm9_cell2.Style.Add(" border-color", "gray")
                    tcm9_cell3.Style.Add("border-style", "solid")
                    tcm9_cell3.Style.Add("border-width", "1px")
                    tcm9_cell3.Style.Add(" border-color", "gray")
                    tcm9_cell4.Style.Add("border-style", "solid")
                    tcm9_cell4.Style.Add("border-width", "1px")
                    tcm9_cell4.Style.Add(" border-color", "gray")



                    date_loanst9.Text = dtm_Transaction_Date
                    det9.Text = "Amount " & LCase(str_Description)
                    debit9.Text = ""
                    credit9.Text = int_Amount_new
                    bal9.Text = int_Balance_new & "Dr"


                    tcm9.Controls.Add(date_loanst9)
                    tcm9_cell1.Controls.Add(det9)
                    tcm9_cell2.Controls.Add(debit9)
                    tcm9_cell3.Controls.Add(credit9)
                    tcm9_cell4.Controls.Add(bal9)
                    trm9.Cells.Add(tcm9)
                    trm9.Cells.Add(tcm9_cell1)
                    trm9.Cells.Add(tcm9_cell2)
                    trm9.Cells.Add(tcm9_cell3)
                    trm9.Cells.Add(tcm9_cell4)
                    tbl.Rows.Add(trm9)

                End If

                strWaiveIDs = strWaiveIDs & ds1.Tables(0).Rows(j).Item("Payment_ID") & ","

            ElseIf ds1.Tables(0).Rows(j).Item("Description").ToString = "Draw down" Or ds1.Tables(0).Rows(j).Item("Description").ToString = "Credit fee" Then
                If Trim(ds1.Tables(0).Rows(j).Item("Description")) = "Credit fee" Then
                    str_Description = "Draw down fee"
                Else
                    str_Description = ds1.Tables(0).Rows(j).Item("Description").ToString
                End If

                'If Trim(ds1.Tables(0).Rows(j).Item("Payment_Method")) = "Credit" And Trim(ds1.Tables(0).Rows(j).Item("Description")) = "Draw down" Then
                '    str_Description = str_Description & fn_Get_Branch(ds1.Tables(0).Rows(j).Item("Payment_ID"))
                'End If
                int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds1.Tables(0).Rows(j).Item("Amount")), 2))
                int_Amount_new = open_con.new_amount(int_Amount)
                int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance + ds1.Tables(0).Rows(j).Item("Amount")), 2))
                int_Balance_new = open_con.new_amount(int_Balance)

                dtm_Transaction_Date = ds1.Tables(0).Rows(j).Item("Payment_Date")
                transdate_new = CDate(dtm_Transaction_Date).ToString("dd/MMM/yyyy")
                day_trans_new = Left(transdate_new, 2)

                pos_int_Total1 = InStr(1, transdate_new, "/")
                month_trans_new = Mid(transdate_new, pos_int_Total1 + 1, 3)
                year_trans_new = Val(Right(transdate_new, 4))
                transdate_new = day_trans_new & "-" & month_trans_new & "-" & year_trans_new
                dtm_Transaction_Date = transdate_new

                If ds1.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt.Text And ds1.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt.Text Then



                    ''''''''''''''''''''''''''''''''''''''nxt row
                    Dim date_loanst10 As Label = New Label()
                    date_loanst10.ID = "date_loanst" & Format(j, "00")
                    date_loanst10.Width = "160"
                    date_loanst10.Style.Add("font-size", "14px")
                    date_loanst10.Style.Add("font-family", "Times New Roman")
                    date_loanst10.Style.Add("font-weight", "bold")
                    date_loanst10.Style.Add("text-align", "center")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim det10 As Label = New Label
                    det10.ID = "det" & Format(j, "00")
                    det10.Width = "250"
                    det10.Style.Add("font-size", "14px")
                    det10.Style.Add("font-family", "Times New Roman")
                    det10.Style.Add("font-weight", "bold")
                    det10.Style.Add("text-align", "left")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim debit10 As Label = New Label
                    debit10.ID = "debit" & Format(j, "00")
                    debit10.Width = "160"
                    debit10.Style.Add("font-size", "14px")
                    debit10.Style.Add("font-family", "Times New Roman")
                    debit10.Style.Add("font-weight", "bold")
                    debit10.Style.Add("text-align", "right")



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim credit10 As Label = New Label
                    credit10.ID = "credit" & Format(j, "00")
                    credit10.Width = "160"
                    credit10.Style.Add("font-size", "14px")
                    credit10.Style.Add("font-family", "Times New Roman")
                    credit10.Style.Add("font-weight", "bold")
                    credit10.Style.Add("text-align", "right")


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim bal10 As Label = New Label
                    bal10.ID = "bal" & Format(j, "00")
                    bal10.Width = "160"
                    bal10.Style.Add("font-size", "14px")
                    bal10.Style.Add("font-family", "Times New Roman")
                    bal10.Style.Add("font-weight", "bold")
                    bal10.Style.Add("text-align", "right")

                    Dim tcm10 As TableCell = New TableCell()
                    Dim tcm10_cell1 As TableCell = New TableCell()
                    Dim tcm10_cell2 As TableCell = New TableCell()
                    Dim tcm10_cell3 As TableCell = New TableCell()
                    Dim tcm10_cell4 As TableCell = New TableCell()
                    Dim trm10 As TableRow = New TableRow()
                    tcm10.Style.Add("border-style", "solid")
                    tcm10.Style.Add("border-width", "1px")
                    tcm10.Style.Add(" border-color", "gray")
                    tcm10_cell1.Style.Add("border-style", "solid")
                    tcm10_cell1.Style.Add("border-width", "1px")
                    tcm10_cell1.Style.Add(" border-color", "gray")
                    tcm10_cell2.Style.Add("border-style", "solid")
                    tcm10_cell2.Style.Add("border-width", "1px")
                    tcm10_cell2.Style.Add(" border-color", "gray")
                    tcm10_cell3.Style.Add("border-style", "solid")
                    tcm10_cell3.Style.Add("border-width", "1px")
                    tcm10_cell3.Style.Add(" border-color", "gray")
                    tcm10_cell4.Style.Add("border-style", "solid")
                    tcm10_cell4.Style.Add("border-width", "1px")
                    tcm10_cell4.Style.Add(" border-color", "gray")

                    date_loanst10.Text = dtm_Transaction_Date
                    det10.Text = str_Description
                    debit10.Text = int_Amount_new
                    credit10.Text = ""
                    bal10.Text = int_Balance_new & "Dr"

                    tcm10.Controls.Add(date_loanst10)
                    tcm10_cell1.Controls.Add(det10)
                    tcm10_cell2.Controls.Add(debit10)
                    tcm10_cell3.Controls.Add(credit10)
                    tcm10_cell4.Controls.Add(bal10)
                    trm10.Cells.Add(tcm10)
                    trm10.Cells.Add(tcm10_cell1)
                    trm10.Cells.Add(tcm10_cell2)
                    trm10.Cells.Add(tcm10_cell3)
                    trm10.Cells.Add(tcm10_cell4)
                    tbl.Rows.Add(trm10)
                End If
                'ElseIf ds1.Tables(0).Rows(j).Item("description").ToString = "Paid" And str_count(strPaymentIDs, ds1.Tables(0).Rows(j).Item("Payment_ID").ToString) = 1 Then

                '    If Trim(ds1.Tables(0).Rows(j).Item("Payment_Method").ToString) = "Cas" Then
                '        str_Description = "Payment made by cash"
                '    ElseIf Trim(ds1.Tables(0).Rows(j).Item("Payment_Method").ToString) = "Chq" Then
                '        str_Description = "Payment made by cheque"
                '    ElseIf Trim(ds1.Tables(0).Rows(j).Item("Payment_Method").ToString) = "Sal" Then
                '        str_Description = "Payment made by salary deduction"
                '    ElseIf Trim(ds1.Tables(0).Rows(j).Item("Payment_Method").ToString) = "Cre" Then
                '        str_Description = "Payment made by Credit"

                '    Else
                '        str_Description = "Payment made by direct debit"
                '    End If

                '    dtm_Transaction_Date = ds1.Tables(0).Rows(j).Item("Payment_Date")
                '    transdate_new = dtm_Transaction_Date
                '    transdate_new = transdate_new.Replace("/", " ")
                '    day_trans_new = Val(Left(transdate_new, 2))
                '    month_trans_new = open_con.cal_short_month(Val(Mid(transdate_new, 4, 2)))
                '    year_trans_new = Val(Right(transdate_new, 4))
                '    transdate_new = day_trans_new & " " & month_trans_new & " " & year_trans_new
                '    dtm_Transaction_Date = transdate_new

                '    int_Amount = open_con.check_amount_format(Math.Round(CDbl(ds1.Tables(0).Rows(j).Item("Amount").ToString), 2))
                '    int_Amount_new = open_con.new_amount(int_Amount)
                '    int_Balance = open_con.check_amount_format(Math.Round(CDbl(int_Balance - ds1.Tables(0).Rows(j).Item("Amount").ToString), 2))
                '    int_Balance_new = open_con.new_amount(int_Balance)



                '    If ds1.Tables(0).Rows(j).Item("Payment_Date") >= txtstartdt.Text And ds1.Tables(0).Rows(j).Item("Payment_Date") <= txtenddt.Text Then
                '        ''''''''''''''''''''''''''''''''''''''nxt row
                '        Dim date_loanst6 As Label = New Label()
                '        date_loanst6.ID = "date_loanst" & Format(j, "00")
                '        date_loanst6.Width = "160"
                '        date_loanst6.Style.Add("font-size", "14px")
                '        date_loanst6.Style.Add("font-family", "Times New Roman")
                '        date_loanst6.Style.Add("font-weight", "bold")
                '        date_loanst6.Style.Add("text-align", "center")


                '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                '        Dim det6 As Label = New Label
                '        det6.ID = "det" & Format(j, "00")
                '        det6.Width = "250"
                '        det6.Style.Add("font-size", "14px")
                '        det6.Style.Add("font-family", "Times New Roman")
                '        det6.Style.Add("font-weight", "bold")
                '        det6.Style.Add("text-align", "left")


                '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '        Dim debit6 As Label = New Label
                '        debit6.ID = "debit" & Format(j, "00")
                '        debit6.Width = "160"
                '        debit6.Style.Add("font-size", "14px")
                '        debit6.Style.Add("font-family", "Times New Roman")
                '        debit6.Style.Add("font-weight", "bold")
                '        debit6.Style.Add("text-align", "right")



                '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '        Dim credit6 As Label = New Label
                '        credit6.ID = "credit" & Format(j, "00")
                '        credit6.Width = "160"
                '        credit6.Style.Add("font-size", "14px")
                '        credit6.Style.Add("font-family", "Times New Roman")
                '        credit6.Style.Add("font-weight", "bold")
                '        credit6.Style.Add("text-align", "right")


                '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '        Dim bal6 As Label = New Label
                '        bal6.ID = "bal" & Format(j, "00")
                '        bal6.Width = "160"
                '        bal6.Style.Add("font-size", "14px")
                '        bal6.Style.Add("font-family", "Times New Roman")
                '        bal6.Style.Add("font-weight", "bold")
                '        bal6.Style.Add("text-align", "right")

                '        Dim tcm6 As TableCell = New TableCell()
                '        Dim tcm6_cell1 As TableCell = New TableCell()
                '        Dim tcm6_cell2 As TableCell = New TableCell()
                '        Dim tcm6_cell3 As TableCell = New TableCell()
                '        Dim tcm6_cell4 As TableCell = New TableCell()
                '        Dim trm6 As TableRow = New TableRow()
                '        tcm6.Style.Add("border-style", "solid")
                '        tcm6.Style.Add("border-width", "1px")
                '        tcm6.Style.Add(" border-color", "gray")
                '        tcm6_cell1.Style.Add("border-style", "solid")
                '        tcm6_cell1.Style.Add("border-width", "1px")
                '        tcm6_cell1.Style.Add(" border-color", "gray")
                '        tcm6_cell2.Style.Add("border-style", "solid")
                '        tcm6_cell2.Style.Add("border-width", "1px")
                '        tcm6_cell2.Style.Add(" border-color", "gray")
                '        tcm6_cell3.Style.Add("border-style", "solid")
                '        tcm6_cell3.Style.Add("border-width", "1px")
                '        tcm6_cell3.Style.Add(" border-color", "gray")
                '        tcm6_cell4.Style.Add("border-style", "solid")
                '        tcm6_cell4.Style.Add("border-width", "1px")
                '        tcm6_cell4.Style.Add(" border-color", "gray")

                '        date_loanst6.Text = dtm_Transaction_Date
                '        det6.Text = str_Description
                '        debit6.Text = ""
                '        credit6.Text = int_Amount_new
                '        bal6.Text = int_Balance_new & "Dr"

                '        tcm6.Controls.Add(date_loanst6)
                '        tcm6_cell1.Controls.Add(det6)
                '        tcm6_cell2.Controls.Add(debit6)
                '        tcm6_cell3.Controls.Add(credit6)
                '        tcm6_cell4.Controls.Add(bal6)
                '        trm6.Cells.Add(tcm6)
                '        trm6.Cells.Add(tcm6_cell1)
                '        trm6.Cells.Add(tcm6_cell2)
                '        trm6.Cells.Add(tcm6_cell3)
                '        trm6.Cells.Add(tcm6_cell4)
                '        tbl.Rows.Add(trm6)

                '    End If
                '    strPaymentIDs = strPaymentIDs & ds1.Tables(0).Rows(j).Item("Payment_ID") & ","
            End If




        Next



    End Sub
    Function str_count(ByVal StringToSearch As String, _
              ByVal StringToFind As String) As Long

        If Len(StringToFind) Then
            str_count = UBound(Split(StringToSearch, StringToFind))
        End If
    End Function

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncnclst.Click
        Panel7.Visible = False
        Session("letter") = 0
        Session("bank_nom") = False
        Session("loan_st") = 0
        Session("sch_history") = 0
        btncnclst.Visible = False
        btnprnt.Visible = False
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

    Protected Sub btnprnt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprnt.Click
        Response.Redirect("Accountstprint.aspx", False)
        Panel8.Visible = True
        Panel7.Visible = False
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
