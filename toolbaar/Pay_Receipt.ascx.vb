Imports System.Data.SqlClient
Imports System.Data
Partial Class toolbaar_Pay_Receipt
    Inherits System.Web.UI.UserControl
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim from_new As DateTime
        Dim to_new As DateTime
     
        If Page.IsPostBack = True Then
            from_new = Date.Parse(txtfrom.Text)
            to_new = Date.Parse(txtto.Text)
            txtfrom.Text = from_new.ToString("dd-MMM-yyyy")
            txtto.Text = to_new.ToString("dd-MMM-yyyy")
            Session("from_pay") = txtfrom.Text
            Session("to_pay") = txtto.Text
        Else
            from_new = System.DateTime.Now.Date
            to_new = System.DateTime.Now.Date
            txtfrom.Text = from_new.ToString("dd-MMM-yyyy")
            txtto.Text = to_new.ToString("dd-MMM-yyyy")
            Session("from_pay") = txtfrom.Text
            Session("to_pay") = txtto.Text
        End If
    End Sub

    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            If Val(txtfrom.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                PlaceHolder1.Visible = False
                btnprntre.Visible = False
                btnsearchagn.Visible = False
                Exit Sub
            ElseIf Val(txtto.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid ending date!!!" & "');", True)
                PlaceHolder1.Visible = False
                btnprntre.Visible = False
                btnsearchagn.Visible = False
                Exit Sub
            ElseIf CDate(txtfrom.Text) > CDate(txtto.Text) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                PlaceHolder1.Visible = False
                btnprntre.Visible = False
                btnsearchagn.Visible = False
                Exit Sub
            Else
                Dim pay_loan_id As Integer
                If Session("beg_status") = "Approved" And Session("flag_beginning") = True And Session("flag_approve") = False Then

                  pay_loan_id = Session("beg_loan_id")
                ElseIf Session("flag_approve") = True And Session("flag_beginning") = True Then
                   pay_loan_id = Session("beg_loan_id")

                ElseIf Session("flag_approve") = True And Session("beg_status") = "Approved" Then

                    pay_loan_id = Session("cur_loan_id")

                ElseIf Session("flag_approve") = True And Session("flag_beginning") = False Then

                   pay_loan_id = Session("cur_loan_id")

                ElseIf Session("beg_status") = "Pending" And Session("flag_beginning") = True Then

                 pay_loan_id = Session("beg_loan_id")

                ElseIf Val(Session("beg_status")) = 0 And Session("flag_approve") = False Then

                     pay_loan_id = Session("cur_loan_id")

                End If

              
                Session("pay_loan_id") = pay_loan_id
                PlaceHolder1.Visible = True
                Print_pay_receipt()

            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub

    Sub Print_pay_receipt()
        Try

            Dim cmd_Receipt As New SqlCommand
            Dim ds_Receipt As New DataSet
            Dim adap_Receipt As SqlDataAdapter


            Dim str_SQL As String
            str_SQL = " SELECT Tbl_Payment.Loan_ID, Tbl_Payment.Amount, Tbl_Payment.Payment_Method, Tbl_Payment.Payment_Date "
            str_SQL = str_SQL & " FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID "
            str_SQL = str_SQL & " WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Cancellation fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND Tbl_Payment.Payment_Date is not NULL "

            If txtfrom.Text <> "" And txtto.Text <> "" Then
                str_SQL = str_SQL & " AND Tbl_Payment.Payment_Date >= '" & txtfrom.Text & "' AND  Tbl_Payment.Payment_Date <= '" & txtto.Text & "'"
            End If
            ' str_SQL = str_SQL & " AND Tbl_Payment.Loan_ID= '" & Session("pay_loan_id") & " 'AND Tbl_Payment.Amount <> 0 AND  Tbl_Payment_1.Update_ID Is Null  ORDER BY  Tbl_Payment.Payment_Date "
            'change for dishhonor payment reciept
            str_SQL = str_SQL & " AND Tbl_Payment.Loan_ID= '" & Session("pay_loan_id") & " 'AND Tbl_Payment.Amount <> 0 AND  Tbl_Payment_1.Update_ID Is Null AND Tbl_Payment.Transaction_Status  IS NULL ORDER BY  Tbl_Payment.Payment_Date "

            cmd_Receipt.CommandText = str_SQL
            cmd_Receipt.Connection = open_con.return_con
            adap_Receipt = New SqlDataAdapter(cmd_Receipt)
            adap_Receipt.Fill(ds_Receipt)


            Dim cmd_CustomerAddress As New SqlCommand
            Dim ds_CustomerAddress As New DataSet
            Dim adap_CustomerAddress As SqlDataAdapter

            str_SQL = " SELECT * FROM Tbl_Customer WHERE Customer_ID = " & open_con.customer_id_val

            cmd_CustomerAddress.CommandText = str_SQL
            cmd_CustomerAddress.Connection = open_con.return_con
            adap_CustomerAddress = New SqlDataAdapter(cmd_CustomerAddress)
            adap_CustomerAddress.Fill(ds_CustomerAddress)


            Dim cmd_Branch_Detail As New SqlCommand
            Dim ds_Branch_Detail As New DataSet
            Dim adap_Branch_Detail As SqlDataAdapter

            str_SQL = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val

            cmd_Branch_Detail.CommandText = str_SQL
            cmd_Branch_Detail.Connection = open_con.return_con
            adap_Branch_Detail = New SqlDataAdapter(cmd_Branch_Detail)
            adap_Branch_Detail.Fill(ds_Branch_Detail)

            If ds_Receipt.Tables(0).Rows.Count = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No Payment Receipt found for the given date range!!" & "');", True)
                Panel1.Visible = True
                Panel2.Visible = False
                PlaceHolder1.Visible = False
                lbl_head.Visible = False
                btnprntre.Visible = False
                btnsearchagn.Visible = False

                Exit Sub
            Else
                Panel1.Visible = False
                Panel2.Visible = True
                lbl_head.Text = "Payment receipt from " & txtfrom.Text.Replace("-", " ") & " to " & txtto.Text.Replace("-", " ")
                lbl_head.Visible = True
                lbl_head.Style.Add(" font-weight", "bold")
                btnprntre.Visible = True
                btnsearchagn.Visible = True
            End If

            Dim tbl As Table = New Table()
            tbl.ID = "tbl_payreceived"
            tbl.Style.Add("border-style", "solid")
            tbl.Style.Add("border-width", "1px")
            tbl.Style.Add("width", "100%")
            PlaceHolder1.Controls.Clear()
            PlaceHolder1.Controls.Add(tbl)

            Dim pay_amt As Label = New Label()
            pay_amt.Text = "Amount"
            pay_amt.Font.Bold = True
            pay_amt.Width = "250"
            pay_amt.Style.Add("font-size", "14px")
            pay_amt.Style.Add("font-family", "Times New Roman")
            pay_amt.Style.Add("font-weight", "bold")
            pay_amt.Style.Add("text-align", "center")



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim pay_recvd As Label = New Label
            pay_recvd.Text = "Payment Received"
            pay_recvd.Font.Bold = True
            pay_recvd.Width = "350"
            pay_recvd.Style.Add("font-size", "14px")
            pay_recvd.Style.Add("font-family", "Times New Roman")
            pay_recvd.Style.Add("font-weight", "bold")
            pay_recvd.Style.Add("text-align", "center")

            Dim pay_method As Label = New Label
            pay_method.Text = "Payment Method"
            pay_method.Font.Bold = True
            pay_method.Width = "350"
            pay_method.Style.Add("font-size", "14px")
            pay_method.Style.Add("font-family", "Times New Roman")
            pay_method.Style.Add("font-weight", "bold")
            pay_method.Style.Add("text-align", "center")

            Dim tcm As TableCell = New TableCell()
            Dim tcm_cell1 As TableCell = New TableCell()
            Dim tcm_cell2 As TableCell = New TableCell()

            Dim trm As TableRow = New TableRow()

            tcm.Style.Add("border-style", "solid")
            tcm.Style.Add("border-width", "1px")
            tcm.Style.Add(" border-color", "gray")
            tcm.Style.Add("background-color", "#EFEFEF")
            tcm_cell1.Style.Add("border-style", "solid")
            tcm_cell1.Style.Add("border-width", "1px")
            tcm_cell1.Style.Add(" border-color", "gray")
            tcm_cell1.Style.Add("background-color", "#EFEFEF")
            tcm_cell2.Style.Add("border-style", "solid")
            tcm_cell2.Style.Add("border-width", "1px")
            tcm_cell2.Style.Add(" border-color", "gray")
            tcm_cell2.Style.Add("background-color", "#EFEFEF")
            tcm.Controls.Add(pay_amt)
            tcm_cell1.Controls.Add(pay_recvd)
            tcm_cell2.Controls.Add(pay_method)
            trm.Cells.Add(tcm)
            trm.Cells.Add(tcm_cell1)
            trm.Cells.Add(tcm_cell2)
            tbl.Rows.Add(trm)
            Dim amt As Double
            Dim amt_new As String
            Dim pay_date As DateTime
            Dim pay_datenew As String
            Dim pay_met As String

            If Not ds_Receipt.Tables(0).Rows.Count = 0 Then

                For i As Integer = 0 To ds_Receipt.Tables(0).Rows.Count - 1


                    pay_date = Date.Parse(ds_Receipt.Tables(0).Rows(i).Item("Payment_Date").ToString)
                    pay_datenew = pay_date.ToString("dd-MMM-yyyy")
                    pay_datenew = pay_datenew.Replace("-", " ")
                    amt = ds_Receipt.Tables(0).Rows(i).Item("Amount").ToString()
                    amt = open_con.check_amount_format(Math.Round(amt, 2))
                    amt_new = open_con.new_amount(amt)
                    pay_met = ds_Receipt.Tables(0).Rows(i).Item("Payment_Method").ToString

                    If pay_met = "NAB" Or pay_met = "CBA" Then
                        pay_met = "Direct Debit"
                    ElseIf pay_met = "Cas" Then
                        pay_met = "Cash"
                    ElseIf pay_met = "Sal" Then
                        pay_met = "Salary deduction"
                    ElseIf pay_met = "Chq" Then
                        pay_met = "Cheque"
                    ElseIf pay_met = "Cre" Then
                        pay_met = "Credit"
                    End If

                    ''''''''''''''''''''''''''''''''''''''nxt row
                    Dim pay_amtnew As Label = New Label()
                    pay_amtnew.ID = "pay_amtnew" & Format(i, "00")
                    pay_amtnew.Width = "250"
                    pay_amtnew.Style.Add("font-size", "14px")
                    pay_amtnew.Style.Add("font-family", "Times New Roman")
                    pay_amtnew.Style.Add("font-weight", "bold")
                    pay_amtnew.Style.Add("text-align", "center")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim pay_rec_new As Label = New Label
                    pay_rec_new.ID = "pay_rec_new" & Format(i, "00")
                    pay_rec_new.Width = "350"
                    pay_rec_new.Style.Add("font-size", "14px")
                    pay_rec_new.Style.Add("font-family", "Times New Roman")
                    pay_rec_new.Style.Add("font-weight", "bold")
                    pay_rec_new.Style.Add("text-align", "center")


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim pay_meth_new As Label = New Label
                    pay_meth_new.ID = " pay_meth_new" & Format(i, "00")
                    pay_meth_new.Width = "350"
                    pay_meth_new.Style.Add("font-size", "14px")
                    pay_meth_new.Style.Add("font-family", "Times New Roman")
                    pay_meth_new.Style.Add("font-weight", "bold")
                    pay_meth_new.Style.Add("text-align", "center")



                    '''''''''''''''''''''''''''''''''''''''


                    Dim trm2 As TableRow = New TableRow()
                    Dim tcm2 As TableCell = New TableCell()
                    Dim tcm2_cell1 As TableCell = New TableCell()
                    Dim tcm2_cell2 As TableCell = New TableCell()

                    tcm2.Style.Add("border-style", "solid")
                    tcm2.Style.Add("border-width", "1px")
                    tcm2.Style.Add(" border-color", "gray")

                    tcm2_cell1.Style.Add("border-style", "solid")
                    tcm2_cell1.Style.Add("border-width", "1px")
                    tcm2_cell1.Style.Add(" border-color", "gray")
                    tcm2_cell2.Style.Add("border-style", "solid")
                    tcm2_cell2.Style.Add("border-width", "1px")
                    tcm2_cell2.Style.Add(" border-color", "gray")


                    pay_amtnew.Text = amt_new
                    pay_rec_new.Text = pay_datenew
                    pay_meth_new.Text = pay_met


                    tcm2.Controls.Add(pay_amtnew)
                    tcm2_cell1.Controls.Add(pay_rec_new)
                    tcm2_cell2.Controls.Add(pay_meth_new)

                    trm2.Cells.Add(tcm2)
                    trm2.Cells.Add(tcm2_cell1)
                    trm2.Cells.Add(tcm2_cell2)
                    tbl.Rows.Add(trm2)

                Next

            End If


            '''''close the connections
            cmd_Receipt.Dispose()
            cmd_CustomerAddress.Dispose()
            cmd_Branch_Detail.Dispose()
            ds_Receipt.Dispose()
            ds_CustomerAddress.Dispose()
            ds_Branch_Detail.Dispose()
            adap_Receipt.Dispose()
            adap_CustomerAddress.Dispose()
            adap_Branch_Detail.Dispose()
            open_con.return_con.Dispose()

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub

    Protected Sub btnsearchagn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearchagn.Click
        Panel1.Visible = True
        Panel2.Visible = False
        PlaceHolder1.Visible = False
        lbl_head.Visible = False
        btnprntre.Visible = False
        btnsearchagn.Visible = False
    End Sub

    Protected Sub btnprntre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprntre.Click
        Response.Redirect("Print_pay_receipt.aspx", False)
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
