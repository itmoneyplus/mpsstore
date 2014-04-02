Imports System.Data.SqlClient
Imports System.Data

Partial Class toolbaar_loansum
    Inherits System.Web.UI.UserControl
    Dim open_con As New Class1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

            show_repay(Session("beg_loan_id"))

        ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
            show_repay(Session("beg_loan_id"))


        ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

            show_repay(Session("cur_loan_id"))

        ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

            show_repay(Session("cur_loan_id"))
        ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

            show_repay(Session("beg_loan_id"))


        ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False And Session("beg_status") <> "Declined" Then

            show_repay(Session("cur_loan_id"))
        ElseIf Session("beg_status") = "Declined" Then
            show_repay(Session("beg_loan_id"))

        End If


        If Session("loan_summ") = True Then

            Label1.Text = "Loan application:" & Session("loanapp_period") & "," & Session("loanapp_date") & ",Loan Term:" & Session("loanapp_term")
            Label2.Text = "Loan Number:" & Session("cur_loan_id")
            LinkButton1.Attributes.Add("onclick", "javascript:alert('" & "Amount given to " + Session("Customer_namebank") + " by credit on " + Session("loanapp_date") & "')")
            txtloanamt.Text = Session("loanapp_amt")
            txtdefer.Text = Session("loanapp_appfee")
            txtcre.Text = Session("loanapp_crefee")
            txtvar.Text = Session("loanapp_varfee")
            txtothr.Text = Session("loanapp_otrfee")
            txtpayfre.Text = Session("loan_fre")
            txtamtpaid.Text = "0.0"
            txtamtout.Text = Session("loanapp_outamt") & ".00"
            txttotalamt.Text = Session("loanapp_outamt") & ".00"
            Dim fee_amt As Integer
            fee_amt = Val(txttotalamt.Text) - Val(txtloanamt.Text)
            txtpayfre.Text = Session("loanapp_freq")
            txttotal.Text = fee_amt & ".00"
        Else

        End If

    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        LinkButton2.Visible = False
        LinkButton3.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        Label8.Visible = False
        Label9.Visible = True
        Label10.Visible = True
        Label11.Visible = True
        Label12.Visible = True
        txtcre.Visible = True
        txtothr.Visible = True
        txtdefer.Visible = True
        txtvar.Visible = True
        txttotal.Visible = False

    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        LinkButton2.Visible = True
        LinkButton3.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label8.Visible = True
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        txtcre.Visible = False
        txtothr.Visible = False
        txtdefer.Visible = False
        txtvar.Visible = False
        txttotal.Visible = True
    End Sub

    Sub show_repay(ByVal loanid As Integer)
        Try
            Session("loan_summ") = False
            Dim cmd_beg_loan As New SqlCommand
            cmd_beg_loan.CommandText = "select * from tbl_loan where loan_id=" & loanid
            cmd_beg_loan.Connection = open_con.return_con
            Dim adap_beg As New SqlDataAdapter(cmd_beg_loan)
            Dim ds_beg As New DataSet
            adap_beg.Fill(ds_beg)
            Session("beg_loanapp_period") = ds_beg.Tables(0).Rows(0).Item("Period").ToString + "month(s)"
            If ds_beg.Tables(0).Rows(0).Item("Term").ToString = "12" Then
                Session("beg_loanapp_term") = "12months"
            Else
                Session("beg_loanapp_term") = "24months"
            End If
            If ds_beg.Tables(0).Rows(0).Item("Frequency").ToString = "7" Then
                Session("loan_Fre") = "Weekly"
            ElseIf ds_beg.Tables(0).Rows(0).Item("Frequency").ToString = "14" Then
                Session("loan_Fre") = "Fortnightly"
            ElseIf ds_beg.Tables(0).Rows(0).Item("Frequency").ToString = "30" Then
                Session("loan_Fre") = "Monthly"
            End If
            txtpayfre.Text = Session("loan_Fre")
            Dim beg_date1 As DateTime
            beg_date1 = CDate(ds_beg.Tables(0).Rows(0).Item("Loan_Date").ToString)
            Dim beg_date As String
            beg_date = beg_date1.ToString("dd-MMM-yyyy")
            Session("beg_loanapp_date") = beg_date
            Session("beg_loanamt") = ds_beg.Tables(0).Rows(0).Item("Amount").ToString
            Label1.Text = "Loan application:" & Session("beg_loanapp_period") & "," & Session("beg_loanapp_date") & ",Loan Term:" & Session("beg_loanapp_term")
            Label2.Text = "Loan Number:" & loanid
            LinkButton1.Attributes.Add("onclick", "javascript:alert('" & "Amount given to " + Session("Customer_namebank") + " by credit on " + Session("beg_loanapp_date") & "')")
            txtloanamt.Text = Val(Session("beg_loanamt")) & ".00"
            cmd_beg_loan.Dispose()
            adap_beg.Dispose()
            open_con.return_con.Dispose()
            Dim cmd_beg_loanfee As New SqlCommand
            cmd_beg_loanfee.CommandText = "select * from tbl_loan_fee where loan_id=" & loanid
            cmd_beg_loanfee.Connection = open_con.return_con
            cmd_beg_loanfee.ExecuteNonQuery()
            Dim adap_beg_fee As New SqlDataAdapter(cmd_beg_loanfee)
            Dim ds_beg_fee As New DataSet
            adap_beg_fee.Fill(ds_beg_fee)

            For i As Integer = 0 To ds_beg_fee.Tables(0).Rows.Count - 1
                If ds_beg_fee.Tables(0).Rows(i).Item("Description").ToString = "Defer Establishment Fee" Then
                    txtdefer.Text = Val(ds_beg_fee.Tables(0).Rows(i).Item("Fee").ToString)
                End If
                If ds_beg_fee.Tables(0).Rows(i).Item("Description").ToString = "Credit Fee" Then
                    txtcre.Text = Val(ds_beg_fee.Tables(0).Rows(i).Item("Fee").ToString)
                End If
                If ds_beg_fee.Tables(0).Rows(i).Item("Description").ToString = "Other Fee" Then
                    txtothr.Text = Val(ds_beg_fee.Tables(0).Rows(i).Item("Fee").ToString)
                End If
                If ds_beg_fee.Tables(0).Rows(i).Item("Description").ToString = "Variation Fee" Then
                    txtvar.Text = Val(ds_beg_fee.Tables(0).Rows(i).Item("Fee").ToString)
                End If
            Next
            cmd_beg_loanfee.Dispose()
            adap_beg_fee.Dispose()
            open_con.return_con.Dispose()


            If Val(txtdefer.Text) = 0 Then
                txtdefer.Text = "0.0"
            Else
                txtdefer.Text = txtdefer.Text & ".00"
            End If
            If Val(txtothr.Text) = 0 Then
                txtothr.Text = "0.0"
            Else
                txtothr.Text = txtothr.Text & ".00"
            End If

            If Val(txtcre.Text) = 0 Then
                txtcre.Text = "0.0"
            Else
                txtcre.Text = txtcre.Text & ".00"

            End If
            If Val(txtvar.Text) = 0 Then
                txtvar.Text = "0.0"
            Else
                txtvar.Text = txtvar.Text & ".00"
            End If
            Dim amt As Integer
            amt = Val(txtdefer.Text) + Val(txtothr.Text) + Val(txtcre.Text) + Val(txtvar.Text)
            txttotal.Text = amt & ".00"
            Dim tot_amt As Integer
            tot_amt = Val(txttotal.Text) + Val(txtloanamt.Text)
            txttotalamt.Text = tot_amt & ".00"

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
        
    End Sub
   
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
  
End Class
