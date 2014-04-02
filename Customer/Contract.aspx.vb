Imports System.Data.SqlClient
Imports System.Data

Partial Class Customer_partcontract
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim loan_id_contract As Integer
            If Session("beg_status") = "" Then
                loan_id_contract = Session("cur_loan_id")
                Label12.Text = open_con.FormatID(loan_id_contract, 4)
                Label_12.Text = open_con.FormatID(loan_id_contract, 4)
            ElseIf Session("beg_status") = "Pending" Then
                loan_id_contract = Session("beg_loan_id")
                Label12.Text = open_con.FormatID(loan_id_contract, 4)
                Label_12.Text = open_con.FormatID(loan_id_contract, 4)
            End If
            Dim str_ACLN As String
            str_ACLN = "Australian Credit Licence Number 391104"
            Dim cmd_CustomerDetail As New SqlCommand
            Dim ds_CustomerDetail As New DataSet
            Dim adap_CustomerDetail As SqlDataAdapter
            Dim str_SQL As String

            str_SQL = " SELECT * FROM Tbl_Customer WHERE Customer_ID = " & open_con.customer_id_val
            cmd_CustomerDetail.CommandText = str_SQL
            cmd_CustomerDetail.Connection = open_con.return_con
            adap_CustomerDetail = New SqlDataAdapter(cmd_CustomerDetail)
            adap_CustomerDetail.Fill(ds_CustomerDetail)

            If ds_CustomerDetail.Tables(0).Rows(0).Item("R_Given_Name").ToString <> "" And ds_CustomerDetail.Tables(0).Rows(0).Item("R_Last_Name").ToString <> "" Then
                Label1.Visible = True
                Label_1.Visible = True
            Else
                Label2.Visible = True
                Label_2.Visible = True
            End If

            Label3.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Last_Name").ToString
            Label_3.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Last_Name").ToString
            Dim unit_no As String
            unit_no = ds_CustomerDetail.Tables(0).Rows(0).Item("Unit_No").ToString()
            If Len(unit_no) <> 0 Then
                Label4.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Unit_No").ToString & "/" & ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Name").ToString
                Label_4.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Unit_No").ToString & "/" & ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Name").ToString
            Else
                Label4.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Name").ToString
                Label_4.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Name").ToString
            End If

            Label5.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("State").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Post_Code").ToString
            Label_5.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("State").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Post_Code").ToString

            If ds_CustomerDetail.Tables(0).Rows(0).Item("Home_Phone").ToString <> "" Then
                Label6.Text = "Tel: " & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Home_Phone").ToString
                Label_6.Text = "Tel: " & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Home_Phone").ToString
            End If

            If ds_CustomerDetail.Tables(0).Rows(0).Item("R_Given_Name").ToString <> "" And ds_CustomerDetail.Tables(0).Rows(0).Item("R_Last_Name").ToString <> "" And ds_CustomerDetail.Tables(0).Rows(0).Item("Joint_Borrowing").ToString = "Yes" Then

                If ds_CustomerDetail.Tables(0).Rows(0).Item("R_Given_Name").ToString <> "" And ds_CustomerDetail.Tables(0).Rows(0).Item("R_Last_Name").ToString <> "" Then
                    Label7.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("R_Given_Name").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("R_Last_Name").ToString
                    Label8.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Name").ToString
                    Label9.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("State").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Post_Code").ToString
                    Label_7.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("R_Given_Name").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("R_Last_Name").ToString
                    Label_8.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Name").ToString
                    Label_9.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("State").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Post_Code").ToString
                    If ds_CustomerDetail.Tables(0).Rows(0).Item("Mobile_Phone").ToString <> "" Then
                        Label10.Text = "Mobile: " & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Mobile_Phone").ToString
                        Label_10.Text = "Mobile: " & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Mobile_Phone").ToString
                    End If
                End If

            End If
            Label11.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label36.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label41.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label42.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label43.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label44.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label46.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label47.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label_11.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label_40.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label_36.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label_41.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label_42.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label_43.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label_44.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label_45.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label_46.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            Label_47.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
            If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
                loan_id_contract = Session("beg_loan_id")
                Label12.Text = open_con.FormatID(loan_id_contract, 4)
                Label_12.Text = open_con.FormatID(loan_id_contract, 4)
            ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                loan_id_contract = Session("beg_loan_id")
                Label12.Text = open_con.FormatID(loan_id_contract, 4)
                Label_12.Text = open_con.FormatID(loan_id_contract, 4)
            ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then
                loan_id_contract = Session("cur_loan_id")
                Label12.Text = open_con.FormatID(loan_id_contract, 4)
                Label_12.Text = open_con.FormatID(loan_id_contract, 4)
            ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                loan_id_contract = Session("cur_loan_id")
                Label12.Text = open_con.FormatID(loan_id_contract, 4)
                Label_12.Text = open_con.FormatID(loan_id_contract, 4)
            ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                loan_id_contract = Session("beg_loan_id")
                Label12.Text = open_con.FormatID(loan_id_contract, 4)
                Label_12.Text = open_con.FormatID(loan_id_contract, 4)
            ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False Then

                loan_id_contract = Session("cur_loan_id")
                Label12.Text = open_con.FormatID(loan_id_contract, 4)
                Label_12.Text = open_con.FormatID(loan_id_contract, 4)
            End If



            Dim str_SQL1 As String
            str_SQL1 = "Select * from Tbl_loan Where Loan_ID =" & loan_id_contract

            Dim cmd_loanDetail As New SqlCommand
            Dim ds_loanDetail As New DataSet
            Dim adap_loanDetail As SqlDataAdapter

            cmd_loanDetail.CommandText = str_SQL1
            cmd_loanDetail.Connection = open_con.return_con
            adap_loanDetail = New SqlDataAdapter(cmd_loanDetail)
            adap_loanDetail.Fill(ds_loanDetail)

            Dim dtm_Loan_Date As Date
            dtm_Loan_Date = ds_loanDetail.Tables(0).Rows(0).Item("Loan_Date").ToString
            Dim loandt, loandt_new, int_Disbursement As String
            int_Disbursement = ds_loanDetail.Tables(0).Rows(0).Item("Method_of_Disbursement").ToString
            loandt = CStr(dtm_Loan_Date)
            Dim month_loan, year_loan, day_loan, day_loan_new As String
            loandt = loandt.Replace("/", " ")
            day_loan = Val(Left(loandt, 2))
            day_loan_new = day_loan
            day_loan = day_loan & open_con.check_day(day_loan)
            month_loan = open_con.cal_short_month(Val(Mid(loandt, 4, 2)))
            year_loan = Val(Right(loandt, 4))
            loandt = day_loan & " " & month_loan & " " & year_loan
            loandt_new = day_loan_new & " " & month_loan & " " & year_loan
            Label13.Text = loandt_new
            Label_13.Text = loandt_new
            Dim int_Loan_Amount As Double
            Dim int_Loan_Term, int_Loan_Period, int_no_of_payment, int_frequency As Integer

            int_Loan_Amount = open_con.check_amount_format(Math.Round(CDbl(ds_loanDetail.Tables(0).Rows(0).Item("Amount")), 2))


            If Val(int_Loan_Amount) > 1000 Then
                P2.Visible = True
                P1.Visible = False
            Else
                P1.Visible = True
                P2.Visible = False

            End If
            int_frequency = ds_loanDetail.Tables(0).Rows(0).Item("Frequency")
            Dim str_frequency As String = ""

            If int_frequency = 7 Then
                str_frequency = "weekly"
            ElseIf int_frequency = 14 Then
                str_frequency = "fornightly"
            ElseIf int_frequency = 30 Then
                str_frequency = "monthly"

            End If
            Label14.Text = open_con.check_amount_format(int_Loan_Amount)
            Label_14.Text = open_con.check_amount_format(int_Loan_Amount)
            'If ds_loanDetail.Tables(0).Rows(0).Item("Term").ToString <> "" Then
            '    int_Loan_Term = ds_loanDetail.Tables(0).Rows(0).Item("Term")
            'Else
            int_Loan_Term = 25
            'End If
            int_Loan_Period = ds_loanDetail.Tables(0).Rows(0).Item("period")
            int_no_of_payment = ds_loanDetail.Tables(0).Rows(0).Item("No_of_Payment")
            Dim str_SQL2 As String
            str_SQL2 = "Select * FROM Tbl_Loan_Fee WHERE Loan_ID = " & loan_id_contract

            Dim cmd_Brokerage_fees As New SqlCommand
            Dim ds_Brokerage_fees As New DataSet
            Dim adap_Brokerage_fees As SqlDataAdapter
            cmd_Brokerage_fees.CommandText = str_SQL2
            cmd_Brokerage_fees.Connection = open_con.return_con
            adap_Brokerage_fees = New SqlDataAdapter(cmd_Brokerage_fees)
            adap_Brokerage_fees.Fill(ds_Brokerage_fees)

            Dim i As Integer
            Dim str_CreditFee As String
            Dim Contract_CR_Fee, int_CreditFee, int_Defer_Fee, Contract_Loan_Amount As Integer
            For i = 0 To ds_Brokerage_fees.Tables(0).Rows.Count - 1

                If ds_Brokerage_fees.Tables(0).Rows(i).Item("description").ToString = "Credit Fee" Then
                    str_CreditFee = "Credit Fee"
                    int_CreditFee = CInt(ds_Brokerage_fees.Tables(0).Rows(i).Item("Fee").ToString)

                    If int_Loan_Term = 12 Then
                        If int_Loan_Amount <= 500 Then
                            Contract_CR_Fee = int_CreditFee + 10
                        Else
                            Contract_CR_Fee = int_CreditFee
                        End If
                    Else
                        Contract_CR_Fee = int_CreditFee / int_Loan_Period
                    End If

                End If

                If ds_Brokerage_fees.Tables(0).Rows(i).Item("description").ToString = "Defer Establishment Fee" Or ds_Brokerage_fees.Tables(0).Rows(i).Item("description").ToString = "Defer EST Fee" Or ds_Brokerage_fees.Tables(0).Rows(i).Item("description").ToString = "Application Fee" Then
                    str_CreditFee = "Defer Establishment Fee"
                    int_Defer_Fee = ds_Brokerage_fees.Tables(0).Rows(i).Item("Fee")
                End If
            Next

            'If int_Loan_Amount = 100 Then
            '    Contract_CR_Fee = int_CreditFee + 8
            'End If
            Dim str_min, str_max As String
            str_min = "Select First_Payment FROM Tbl_loan WHERE Loan_ID = " & loan_id_contract & " and Customer_ID = " & open_con.customer_id_val
            str_max = "Select max(Due_Date) FROM Tbl_payment WHERE Loan_ID = " & loan_id_contract & " and Customer_ID = " & open_con.customer_id_val
            Dim cmd_min, cmd_max As New SqlCommand
            Dim ds_min, ds_max As New DataSet
            Dim adap_min, adap_max As SqlDataAdapter
            cmd_min.CommandText = str_min
            cmd_min.Connection = open_con.return_con
            adap_min = New SqlDataAdapter(cmd_min)
            adap_min.Fill(ds_min)
            Dim min_Loan_Date, max_Loan_Date As Date
            cmd_max.CommandText = str_max
            cmd_max.Connection = open_con.return_con
            adap_max = New SqlDataAdapter(cmd_max)
            adap_max.Fill(ds_max)
            max_Loan_Date = ds_max.Tables(0).Rows(0).Item(0)
            min_Loan_Date = ds_min.Tables(0).Rows(0).Item(0)
            Contract_Loan_Amount = int_Loan_Amount + Contract_CR_Fee * int_Loan_Term

            Label15.Text = open_con.check_amount_format(Math.Round(CDbl(int_Loan_Amount + int_Defer_Fee + int_CreditFee), 2))
            Label16.Text = int_no_of_payment
            Label17.Text = open_con.check_amount_format(Math.Round(CDbl(int_Defer_Fee + int_CreditFee), 2))
            Label18.Text = open_con.check_amount_format(Math.Round(CDbl(int_CreditFee), 2))
            Label19.Text = str_ACLN
            Label48.Text = min_Loan_Date
            Label49.Text = open_con.check_amount_format(Math.Round(CDbl((int_Loan_Amount + int_Defer_Fee + int_CreditFee) / int_no_of_payment), 2))
            Label50.Text = str_frequency
            Label51.Text = max_Loan_Date
            Label52.Text = int_Loan_Period
            Label53.Text = open_con.check_amount_format(Math.Round(CDbl(int_Defer_Fee), 2))
            Label56.Text = open_con.check_amount_format(Math.Round(CDbl(int_Defer_Fee), 2))
            Label57.Text = open_con.check_amount_format(Math.Round(CDbl(int_Loan_Amount), 2))
            Label58.Text = open_con.check_amount_format(Math.Round(CDbl(int_Loan_Amount + int_Defer_Fee + int_CreditFee), 2))
            Label_15.Text = open_con.check_amount_format(Math.Round(CDbl(Contract_Loan_Amount), 2))
            Label_16.Text = 25
            Label_23.Text = int_Loan_Period + 1
            Label22.Text = int_Loan_Period + 1
            Label_24.Text = open_con.check_amount_format(Math.Round(CDbl(int_Defer_Fee), 2))
            Label23.Text = open_con.check_amount_format(Math.Round(CDbl((50 * int_Defer_Fee) / 100), 2))
            Label_17.Text = open_con.check_amount_format(Math.Round(CDbl(Contract_Loan_Amount / 25), 2))
            Label_18.Text = open_con.check_amount_format(Math.Round(CDbl(Contract_CR_Fee), 2))
            Label_19.Text = str_ACLN
            Label_25.Text = open_con.check_amount_format(Contract_Loan_Amount)
            Dim str_SQL3 As String
            str_SQL3 = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val
            Dim cmd_Branch_Detail As New SqlCommand
            Dim ds_Branch_Detail As New DataSet
            Dim adap_Branch_Detail As SqlDataAdapter
            cmd_Branch_Detail.CommandText = str_SQL3
            cmd_Branch_Detail.Connection = open_con.return_con
            adap_Branch_Detail = New SqlDataAdapter(cmd_Branch_Detail)
            adap_Branch_Detail.Fill(ds_Branch_Detail)
            Label20.Text = ds_Branch_Detail.Tables(0).Rows(0).Item("Phone_Number").ToString
            Label21.Text = ds_Branch_Detail.Tables(0).Rows(0).Item("Fax_Number").ToString

            Label27.Text = str_ACLN
            Label28.Text = str_ACLN
            Label29.Text = str_ACLN
            Label30.Text = open_con.check_amount_format(int_Loan_Amount)
            Label31.Text = int_Disbursement
            Label33.Text = ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Name").ToString() & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("State").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Post_Code").ToString
            Label34.Text = str_ACLN
            Label35.Text = str_ACLN
            Label38.Text = str_ACLN
            Label39.Text = loandt
            Label_20.Text = ds_Branch_Detail.Tables(0).Rows(0).Item("Phone_Number").ToString
            Label_21.Text = ds_Branch_Detail.Tables(0).Rows(0).Item("Fax_Number").ToString
            Label_26.Text = str_ACLN
            Label_27.Text = str_ACLN
            Label_28.Text = str_ACLN
            Label_29.Text = str_ACLN
            Label_30.Text = open_con.check_amount_format(int_Loan_Amount)
            Label_31.Text = int_Disbursement
            Label_33.Text = ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Name").ToString() & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("State").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Post_Code").ToString
            Label_34.Text = str_ACLN
            Label_35.Text = str_ACLN
            Label_37.Text = str_ACLN
            Label_38.Text = str_ACLN
            Label_39.Text = loandt

            cmd_Brokerage_fees.Dispose()
            adap_Brokerage_fees.Dispose()
            ds_Brokerage_fees.Dispose()
            cmd_CustomerDetail.Dispose()
            ds_CustomerDetail.Dispose()
            adap_CustomerDetail.Dispose()
            cmd_loanDetail.Dispose()
            ds_loanDetail.Dispose()
            adap_loanDetail.Dispose()
            cmd_max.Dispose()
            cmd_min.Dispose()
            ds_max.Dispose()
            ds_min.Dispose()
            open_con.return_con.Dispose()

        Catch ex As Exception

            Response.Write("Error: " & ex.Message)
        End Try
        
       
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
