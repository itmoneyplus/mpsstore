
Imports System.Data.SqlClient
Imports System.Data
Partial Class Customer_PartContract
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Page.IsPostBack = False Then
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
                    ' Label1.Visible = True
                Else
                    ' Label2.Visible = True
                End If

                '   Label3.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Last_Name").ToString
                If ds_CustomerDetail.Tables(0).Rows(0).Item("Unit_No").ToString <> "" Then
                    '  Label29.Visible = True
                    '   Label29.Text = "Unit:" & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Unit_No").ToString
                End If
                'Label4.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Name").ToString
                ' Label5.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("State").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Post_Code").ToString

                If ds_CustomerDetail.Tables(0).Rows(0).Item("Home_Phone").ToString <> "" Then
                    ' Label6.Text = "Tel: " & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Home_Phone").ToString
                End If

                If ds_CustomerDetail.Tables(0).Rows(0).Item("R_Given_Name").ToString <> "" And ds_CustomerDetail.Tables(0).Rows(0).Item("R_Last_Name").ToString <> "" And ds_CustomerDetail.Tables(0).Rows(0).Item("Joint_Borrowing").ToString = "Yes" Then

                    If ds_CustomerDetail.Tables(0).Rows(0).Item("R_Given_Name").ToString <> "" And ds_CustomerDetail.Tables(0).Rows(0).Item("R_Last_Name").ToString <> "" Then
                        '  Label7.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("R_Given_Name").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("R_Last_Name").ToString
                        If ds_CustomerDetail.Tables(0).Rows(0).Item("Unit_No").ToString <> "" Then
                            '   Label30.Visible = True
                            '  Label30.Text = "Unit:" & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Unit_No").ToString
                        End If
                        '  Label8.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Street_Name").ToString
                        ' Label9.Text = ds_CustomerDetail.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("State").ToString & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Post_Code").ToString
                        If ds_CustomerDetail.Tables(0).Rows(0).Item("Mobile_Phone").ToString <> "" Then
                            '   Label10.Text = "Mobile: " & " " & ds_CustomerDetail.Tables(0).Rows(0).Item("Mobile_Phone").ToString
                        End If
                    End If

                End If
                Label11.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
                Label44.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
                Label1.Text = open_con.FormatID(ds_CustomerDetail.Tables(0).Rows(0).Item("Customer_ID"), 4)
                Dim loan_id_contract As Integer

                ''''''''''''''''''''''''
                If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then
                    loan_id_contract = Session("beg_loan_id")


                ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                    loan_id_contract = Session("beg_loan_id")

                ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then
                    loan_id_contract = Session("cur_loan_id")

                ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                    loan_id_contract = Session("cur_loan_id")


                ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                    loan_id_contract = Session("beg_loan_id")


                ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False Then

                    loan_id_contract = Session("cur_loan_id")

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
                ' Label13.Text = loandt_new

                Dim int_Loan_Amount As Double
                Dim int_Loan_Term, int_Loan_Period As Integer
                int_Loan_Amount = open_con.check_amount_format(Math.Round(CDbl(ds_loanDetail.Tables(0).Rows(0).Item("Amount")), 2))
                'Label14.Text = open_con.check_amount_format(int_Loan_Amount)
                If Val(int_Loan_Amount) > 1000 Then
                    P2new.Visible = True
                    P1new.Visible = False
                Else
                    P1new.Visible = True
                    P2new.Visible = False

                End If

                If ds_loanDetail.Tables(0).Rows(0).Item("Term").ToString <> "" Then
                    int_Loan_Term = ds_loanDetail.Tables(0).Rows(0).Item("Term")
                Else
                    int_Loan_Term = 12
                End If
                int_Loan_Period = ds_loanDetail.Tables(0).Rows(0).Item("period")

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

                If int_Loan_Amount = 100 Then
                    Contract_CR_Fee = int_CreditFee + 8
                End If

                Contract_Loan_Amount = int_Loan_Amount + Contract_CR_Fee * int_Loan_Term
                ' Label15.Text = open_con.check_amount_format(Contract_Loan_Amount)
                ' Label16.Text = int_Loan_Term
                ' Label17.Text = open_con.check_amount_format(Math.Round(CDbl(Contract_Loan_Amount / int_Loan_Term), 2))
                '  Label18.Text = open_con.check_amount_format(Math.Round(CDbl(Contract_CR_Fee), 2))
                'Label19.Text = str_ACLN

                Dim str_SQL3 As String
                str_SQL3 = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val
                Dim cmd_Branch_Detail As New SqlCommand
                Dim ds_Branch_Detail As New DataSet
                Dim adap_Branch_Detail As SqlDataAdapter
                cmd_Branch_Detail.CommandText = str_SQL3
                cmd_Branch_Detail.Connection = open_con.return_con
                adap_Branch_Detail = New SqlDataAdapter(cmd_Branch_Detail)
                adap_Branch_Detail.Fill(ds_Branch_Detail)
                '  Label20.Text = ds_Branch_Detail.Tables(0).Rows(0).Item("Phone_Number").ToString
                '  Label21.Text = ds_Branch_Detail.Tables(0).Rows(0).Item("Fax_Number").ToString
                Label22.Text = str_ACLN
                Label38.Text = str_ACLN
                Label23.Text = str_ACLN
                Label24.Text = open_con.check_amount_format(int_Loan_Amount)
                Label30.Text = open_con.check_amount_format(int_Loan_Amount)
                Label25.Text = int_Disbursement
                Label31.Text = int_Disbursement
                Label26.Text = ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Name").ToString() & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("State").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Post_Code").ToString
                Label33.Text = ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Street_Name").ToString() & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("State").ToString & " " & ds_Branch_Detail.Tables(0).Rows(0).Item("Post_Code").ToString
                Label27.Text = loandt
                Label39.Text = loandt
                Label28.Text = loandt
                cmd_Brokerage_fees.Dispose()
                cmd_Branch_Detail.Dispose()
                cmd_CustomerDetail.Dispose()
                cmd_loanDetail.Dispose()
                adap_Branch_Detail.Dispose()
                adap_Brokerage_fees.Dispose()
                adap_CustomerDetail.Dispose()
                adap_loanDetail.Dispose()
                ds_Brokerage_fees.Dispose()
                ds_Branch_Detail.Dispose()
                ds_CustomerDetail.Dispose()
                ds_loanDetail.Dispose()
                open_con.return_con.Dispose()
            End If

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try


    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
