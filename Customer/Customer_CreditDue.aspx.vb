Imports System.Data
Imports System.Data.SqlClient
Partial Class Customer_Customer_CreditDue
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Val(txtfrom.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                PlaceHolder1.Visible = False
                btnduere.Visible = False
                btndueview.Visible = False
                lbl_head.Visible = False
                Exit Sub
            ElseIf Val(txtto.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid ending date!!!" & "');", True)
                PlaceHolder1.Visible = False
                btnduere.Visible = False
                btndueview.Visible = False
                lbl_head.Visible = False
                Exit Sub
            ElseIf CDate(txtfrom.Text) > CDate(txtto.Text) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                PlaceHolder1.Visible = False
                btnduere.Visible = False
                btndueview.Visible = False
                lbl_head.Visible = False
                Exit Sub
            Else
                PlaceHolder1.Visible = True
                Credit_Due_Cus()
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub

    Sub Credit_Due_Cus()
        Try
            Dim cmd_due As New SqlCommand
            Dim adap_due As SqlDataAdapter
            Dim ds_due As New DataSet
            Dim str_due As String

            Dim from_Credit As String
            Dim to_Credit As String
            from_Credit = Date.Parse(txtfrom.Text).ToString("yyyy-MM-dd")
            Session("from_Credit") = from_Credit
            to_Credit = Date.Parse(txtto.Text).ToString("yyyy-MM-dd")
            Session("to_Credit") = to_Credit

            str_due = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Customer.Employer, Tbl_Customer.Payroll_Transfer, Tbl_Payment.Payment_ID, Tbl_Payment.Loan_ID, Tbl_Payment.Payment_Method, Tbl_Payment.Amount, Tbl_Payment.Due_Date "
            str_due = str_due & " FROM (Tbl_Customer INNER JOIN Tbl_Loan ON Tbl_Customer.Customer_ID = Tbl_Loan.Customer_ID) INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID ) ON Tbl_Loan.Loan_ID = Tbl_Payment.Loan_ID "
            str_due = str_due & " WHERE (Tbl_Payment.Payment_Method='Cre' AND Tbl_Payment_1.Update_ID Is NULL AND Tbl_Loan.Status = '1' AND Tbl_Payment.Transaction_Status is NULL AND (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description='')  AND Tbl_Payment.Amount <> 0 AND Tbl_Payment.Payment_Date Is NULL AND Tbl_Payment.Due_Date >='" & from_Credit & "' AND Tbl_Payment.Due_Date <='" & to_Credit & "')"
            str_due = str_due & " ORDER BY Tbl_Payment.Payment_Method,  Tbl_Payment.Due_Date, Tbl_Customer.Customer_ID"
            cmd_due.CommandText = str_due
            cmd_due.Connection = open_con.return_con
            adap_due = New SqlDataAdapter(cmd_due)
            adap_due.Fill(ds_due)

            If ds_due.Tables(0).Rows.Count = 0 Then
                PlaceHolder1.Visible = False
                lbl_head.Visible = False
                btnduere.Visible = False
                btndueview.Visible = False
                Exit Sub
            Else

                lbl_head.Text = "Credit Due Report from " & txtfrom.Text.Replace("-", " ") & " to " & txtto.Text.Replace("-", " ")
                lbl_head.Visible = True
                lbl_head.Style.Add(" font-weight", "bold")
                btnduere.Visible = True
                btndueview.Visible = True
                Session("cre_due_count") = ds_due.Tables(0).Rows.Count
            End If
            Dim tbl As Table = New Table()
            PlaceHolder1.Controls.Clear()
            PlaceHolder1.Controls.Add(tbl)
            tbl.BorderWidth = "1"
            tbl.Font.Size = "12"
            Dim snno As Label = New Label()
            Dim cust_no As Label = New Label()
            Dim cust_name As Label = New Label()
            Dim trns_ref As Label = New Label()
            Dim loan_no As Label = New Label()
            Dim due_dt As Label = New Label()
            Dim amt As Label = New Label()

            snno.Text = "S"
            cust_no.Text = "Cust No"
            cust_name.Text = "Customer Name"
            trns_ref.Text = "Transfer Reference"
            loan_no.Text = "Loan No"
            due_dt.Text = "Due Date"
            amt.Text = "Amount"

            snno.Font.Bold = True
            cust_no.Font.Bold = True
            cust_name.Font.Bold = True
            trns_ref.Font.Bold = True
            loan_no.Font.Bold = True
            due_dt.Font.Bold = True
            amt.Font.Bold = True
            snno.Width = "20"
            snno.Style.Add("text-align", "center")
            cust_no.Width = "80"
            cust_no.Style.Add("text-align", "center")
            cust_name.Width = "150"
            cust_name.Style.Add("text-align", "center")
            trns_ref.Width = "200"
            trns_ref.Style.Add("text-align", "center")
            loan_no.Width = "100"
            loan_no.Style.Add("text-align", "center")
            due_dt.Width = "100"
            due_dt.Style.Add("text-align", "center")
            amt.Width = "100"
            amt.Style.Add("text-align", "right")
            Dim tcm As TableCell = New TableCell()
            Dim trm As TableRow = New TableRow()
            trm.Style.Add("background-color", "#EEEEEE")
            tcm.Controls.Add(snno)
            tcm.Controls.Add(cust_no)
            tcm.Controls.Add(cust_name)
            tcm.Controls.Add(trns_ref)
            tcm.Controls.Add(loan_no)
            tcm.Controls.Add(due_dt)
            tcm.Controls.Add(amt)

            trm.Cells.Add(tcm)
            tbl.Rows.Add(trm)
            Dim tot_creditdue As Double
            For i As Integer = 0 To ds_due.Tables(0).Rows.Count - 1

                Dim tc As TableCell = New TableCell()
                Dim tr As TableRow = New TableRow()
                Dim chkbox As CheckBox = New CheckBox
                chkbox.ID = "chk" & Format(i, "00")
                chkbox.Width = "20"

                Dim lbl_cust_no As Label = New Label
                lbl_cust_no.ID = "cust_no" & Format(i, "00")
                lbl_cust_no.Text = ds_due.Tables(0).Rows(i).Item("Customer_ID")
                lbl_cust_no.Style.Add("text-align", "center")
                lbl_cust_no.Width = "80"
                Dim lbl_cust_name As Label = New Label
                lbl_cust_name.ID = "cust" & Format(i, "00")
                lbl_cust_name.Text = ds_due.Tables(0).Rows(i).Item("Given_Name") & "  " & ds_due.Tables(0).Rows(i).Item("Last_Name")
                lbl_cust_name.Style.Add("text-align", "left")
                lbl_cust_name.Width = "150"

                Dim lbl_trns_ref As Label = New Label
                lbl_trns_ref.ID = "trns_ref" & Format(i, "00")
                lbl_trns_ref.Text = ds_due.Tables(0).Rows(i).Item("Payroll_Transfer").ToString
                lbl_trns_ref.Style.Add("text-align", "center")
                lbl_trns_ref.Width = "200"

                Dim lbl_pay_id As Label = New Label
                lbl_pay_id.ID = "pay_id" & Format(i, "00")
                lbl_pay_id.Text = ds_due.Tables(0).Rows(i).Item("Payment_ID").ToString
                lbl_pay_id.Visible = False

                Dim lbl_loan_id As Label = New Label
                lbl_loan_id.ID = "loan_id" & Format(i, "00")
                lbl_loan_id.Text = ds_due.Tables(0).Rows(i).Item("Loan_ID").ToString
                lbl_loan_id.Style.Add("text-align", "center")
                lbl_loan_id.Width = "100"
                Dim lbl_due_dt As Label = New Label
                lbl_due_dt.ID = "due_dt" & Format(i, "00")
                Dim due_dt_new As DateTime
                due_dt_new = ds_due.Tables(0).Rows(i).Item("Due_Date").ToString()
                lbl_due_dt.Text = due_dt_new.ToString("dd/MM/yyyy")
                lbl_due_dt.Style.Add("text-align", "right")
                lbl_due_dt.Width = "90"
                Dim lbl_amt As Label = New Label
                lbl_amt.ID = "amt" & Format(i, "00")

                Dim amt_creditdue As Double
                amt_creditdue = CDbl(ds_due.Tables(0).Rows(i).Item("Amount").ToString)
                amt_creditdue = open_con.check_amount_format(Math.Round(amt_creditdue, 2))
                Dim new_amt_creditdue As String
                new_amt_creditdue = open_con.new_amount(amt_creditdue)
                tot_creditdue = tot_creditdue + amt_creditdue
                lbl_amt.Text = new_amt_creditdue
                lbl_amt.Style.Add("text-align", "right")
                lbl_amt.Width = "110"
                tc.Controls.Add(chkbox)
                tc.Controls.Add(lbl_cust_no)
                tc.Controls.Add(lbl_cust_name)
                tc.Controls.Add(lbl_trns_ref)
                tc.Controls.Add(lbl_pay_id)
                tc.Controls.Add(lbl_loan_id)
                tc.Controls.Add(lbl_due_dt)
                tc.Controls.Add(lbl_amt)
                tr.Cells.Add(tc)
                tbl.Rows.Add(tr)
            Next
            Dim tc1 As TableCell = New TableCell()
            Dim tr1 As TableRow = New TableRow()
            tr1.BorderWidth = "1"
            tc1.BorderWidth = "1"
            tc1.BorderStyle = BorderStyle.Solid
            tc1.Style.Add("text-align", "right")

            Dim lbl_total As Label = New Label
            lbl_total.Text = "Total:"

            lbl_total.Style.Add("font-weight", "bold")
            Dim lbl_totalamt As Label = New Label
            lbl_totalamt.ID = "tot"

            tot_creditdue = open_con.check_amount_format(Math.Round(tot_creditdue, 2))
            Dim new_tot_creditdue As String
            new_tot_creditdue = open_con.new_amount(tot_creditdue)
            lbl_totalamt.Text = new_tot_creditdue
            lbl_totalamt.Style.Add("font-weight", "bold")
            tc1.Controls.Add(lbl_total)
            tc1.Controls.Add(lbl_totalamt)
            tr1.Controls.Add(tc1)
            tbl.Rows.Add(tr1)
            '''''close the connections
            cmd_due.Dispose()
            adap_due.Dispose()
            ds_due.Dispose()
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try


    End Sub
    Protected Sub btndueview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndueview.Click
        Response.Redirect("../Reports/Print_CreditDue.aspx", False)
    End Sub
    Protected Sub btnduere_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnduere.Click

        Dim i As Integer
        Dim cre_count As Integer
        Dim chk As CheckBox
        Dim lbl_pay As Label

        cre_count = Session("cre_due_count")
    
        For i = 0 To cre_count - 1
            If i < 10 Then
                chk = Me.FindControl("chk" & "0" & i)
                lbl_pay = Me.FindControl("pay_id" & "0" & i)

            Else
                chk = Me.FindControl("chk" & i)
                lbl_pay = Me.FindControl("pay_id" & i)
            End If

            If chk.Checked = True Then
                Dim str_cre As String
                str_cre = "UPDATE Tbl_Payment  SET Tbl_Payment.Payment_Date = '" & System.DateTime.Now.Date.ToString("dd-MMM-yyyy") & "',"
                str_cre = str_cre & " Tbl_Payment.Payment_Status = 'Paid' "
                str_cre = str_cre & " WHERE Tbl_Payment.Payment_ID = " & lbl_pay.Text
                Dim cmd_rec_cre As New SqlCommand
                cmd_rec_cre.Connection = open_con.return_con
                cmd_rec_cre.CommandText = str_cre
                cmd_rec_cre.ExecuteNonQuery()
                cmd_rec_cre.Dispose()
            End If
        Next
        Credit_Due_Cus()
        open_con.return_con.Dispose()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            If Page.IsPostBack = True Then
                Credit_Due_Cus()
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
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
