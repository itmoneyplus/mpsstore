Imports System.Data.SqlClient
Imports System.Data
Partial Class Customer_Customer_PayrollRec
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Val(txtfrom.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                PlaceHolder1.Visible = False
                btnrepay.Visible = False
                btnviewpay.Visible = False
                lbl_head.Visible = False
                Exit Sub
            ElseIf Val(txtto.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid ending date!!!" & "');", True)
                PlaceHolder1.Visible = False
                btnrepay.Visible = False
                btnviewpay.Visible = False
                lbl_head.Visible = False
                Exit Sub
            ElseIf CDate(txtfrom.Text) > CDate(txtto.Text) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                PlaceHolder1.Visible = False
                btnrepay.Visible = False
                btnviewpay.Visible = False
                lbl_head.Visible = False
                Exit Sub
            Else
                PlaceHolder1.Visible = True
                Sal_Pay_Rec()
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub

    Sub Sal_Pay_Rec()

        Dim tbl As Table = New Table()
        PlaceHolder1.Controls.Clear()
        PlaceHolder1.Controls.Add(tbl)
        tbl.BorderWidth = "1"
        tbl.Font.Size = "12"

        Dim cust_no As Label = New Label()
        Dim cust_name As Label = New Label()
        Dim loan_no As Label = New Label()
        Dim due_dt As Label = New Label()
        Dim payment_dt As Label = New Label
        Dim amt As Label = New Label()


        cust_no.Text = "Customer No"
        cust_name.Text = "Customer Name"
        loan_no.Text = "Loan No"
        due_dt.Text = "Due Date"
        payment_dt.Text = "Payment Date"
        amt.Text = "Amount"


        cust_no.Font.Bold = True
        cust_name.Font.Bold = True
        loan_no.Font.Bold = True
        due_dt.Font.Bold = True
        payment_dt.Font.Bold = True
        amt.Font.Bold = True

        cust_no.Width = "100"
        cust_no.Style.Add("text-align", "center")
        cust_name.Width = "150"
        cust_name.Style.Add("text-align", "center")
        loan_no.Width = "100"
        loan_no.Style.Add("text-align", "center")
        due_dt.Width = "100"
        due_dt.Style.Add("text-align", "center")
        payment_dt.Width = "100"
        payment_dt.Style.Add("text-align", "center")
        amt.Width = "100"
        amt.Style.Add("text-align", "center")
        Dim tcm As TableCell = New TableCell()
        Dim trm As TableRow = New TableRow()
        trm.Style.Add("background-color", "#EEEEEE")
        tcm.Controls.Add(cust_no)
        tcm.Controls.Add(cust_name)
        tcm.Controls.Add(loan_no)
        tcm.Controls.Add(due_dt)
        tcm.Controls.Add(payment_dt)
        tcm.Controls.Add(amt)

        Dim cmd_pay_rec As New SqlCommand
        Dim adap_pay_rec As SqlDataAdapter
        Dim ds_pay_rec As New DataSet
        Dim str_pay_rec As String

        Dim rec_from_pay As String
        Dim rec_to_pay As String
        rec_from_pay = Date.Parse(txtfrom.Text).ToString("yyyy-MM-dd")
        Session("rec_from_pay") = rec_from_pay
        rec_to_pay = Date.Parse(txtto.Text).ToString("yyyy-MM-dd")
        Session("rec_to_pay") = rec_to_pay
        str_pay_rec = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Payment.Loan_ID, Tbl_Payment.Payment_Method, Tbl_Payment.Amount,  Tbl_Payment.Due_Date, Tbl_Payment.Payment_Date "
        str_pay_rec = str_pay_rec & " FROM Tbl_Customer INNER JOIN (Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Payment_ID) ON Tbl_Customer.Customer_ID = Tbl_Payment.Customer_ID "
        str_pay_rec = str_pay_rec & " WHERE (Tbl_Payment.Payment_Method='Sal') AND Tbl_Payment.Payment_Date>='" & rec_from_pay & "' And Tbl_Payment.Payment_Date<='" & rec_to_pay & "' AND (Tbl_Payment.Description='Arear notice fee' Or Tbl_Payment.Description='Statement of account fee' Or Tbl_Payment.Description='Variation fee' Or Tbl_Payment.Description='Default notice fee' Or Tbl_Payment.Description='Letter of demand fee' Or Tbl_Payment.Description='Dishonoured fee' Or Tbl_Payment.Description = 'Enforcement fee' Or Tbl_Payment.Description Is Null or Tbl_Payment.Description = '')"
        ' for dishonour
        str_pay_rec = str_pay_rec & "AND (Tbl_Payment.Transaction_Status <>'Dishonour' OR Tbl_Payment.Transaction_Status is NULL)"
        str_pay_rec = str_pay_rec & " ORDER BY Tbl_Payment.Payment_Method, Tbl_Payment.Payment_Date "
        cmd_pay_rec.CommandText = str_pay_rec

        cmd_pay_rec.Connection = open_con.return_con
        adap_pay_rec = New SqlDataAdapter(cmd_pay_rec)
        adap_pay_rec.Fill(ds_pay_rec)
        If ds_pay_rec.Tables(0).Rows.Count = 0 Then

            btnrepay.Visible = False
            btnviewpay.Visible = False
            Exit Sub
        Else
            trm.Cells.Add(tcm)
            tbl.Rows.Add(trm)
            lbl_head.Text = "View Payroll Deductions Report from " & txtfrom.Text.Replace("-", " ") & " to " & txtto.Text.Replace("-", " ")
            lbl_head.Visible = True
            lbl_head.Style.Add(" font-weight", "bold")
            btnrepay.Visible = True
            btnviewpay.Visible = True
            Session("pay_count") = ds_pay_rec.Tables(0).Rows.Count
        End If
        Dim tot_payrec As Double
        For i As Integer = 0 To ds_pay_rec.Tables(0).Rows.Count - 1

            Dim tc As TableCell = New TableCell()
            Dim tr As TableRow = New TableRow()

            Dim lbl_cust_no As Label = New Label
            lbl_cust_no.ID = "cust_no" & Format(i, "00")
            lbl_cust_no.Text = Session("Branch_Prefix") & " " & ds_pay_rec.Tables(0).Rows(i).Item("Customer_ID")
            lbl_cust_no.Style.Add("text-align", "center")
            lbl_cust_no.Width = "100"
            Dim lbl_cust_name As Label = New Label
            lbl_cust_name.ID = "cust" & Format(i, "00")
            lbl_cust_name.Text = ds_pay_rec.Tables(0).Rows(i).Item("Given_Name") & "  " & ds_pay_rec.Tables(0).Rows(i).Item("Last_Name")
            lbl_cust_name.Style.Add("text-align", "left")
            lbl_cust_name.Width = "150"

            Dim lbl_loan_id As Label = New Label
            lbl_loan_id.ID = "loan_id" & Format(i, "00")
            lbl_loan_id.Text = ds_pay_rec.Tables(0).Rows(i).Item("Loan_ID").ToString
            lbl_loan_id.Style.Add("text-align", "center")
            lbl_loan_id.Width = "100"
            Dim lbl_due_dt As Label = New Label
            lbl_due_dt.ID = "due_dt" & Format(i, "00")
            Dim due_dt_new As DateTime
            due_dt_new = ds_pay_rec.Tables(0).Rows(i).Item("Due_Date").ToString()
            lbl_due_dt.Text = due_dt_new.ToString("dd/MM/yyyy")
            lbl_due_dt.Style.Add("text-align", "center")
            lbl_due_dt.Width = "100"
            Dim lbl_pay_dt As Label = New Label
            lbl_pay_dt.ID = "pay_dt" & Format(i, "00")
            Dim pay_dt_new As DateTime
            pay_dt_new = ds_pay_rec.Tables(0).Rows(i).Item("Payment_Date").ToString()
            lbl_pay_dt.Text = pay_dt_new.ToString("dd/MM/yyyy")
            lbl_pay_dt.Style.Add("text-align", "center")
            lbl_pay_dt.Width = "100"
            Dim lbl_amt As Label = New Label
            lbl_amt.ID = "amt" & Format(i, "00")
            Dim amt_payrec As Double
            amt_payrec = CDbl(ds_pay_rec.Tables(0).Rows(i).Item("Amount").ToString)
            amt_payrec = open_con.check_amount_format(Math.Round(amt_payrec, 2))
            lbl_amt.Text = open_con.new_amount(amt_payrec)
            tot_payrec = tot_payrec + amt_payrec
            lbl_amt.Style.Add("text-align", "right")
            lbl_amt.Width = "100"

            tc.Controls.Add(lbl_cust_no)
            tc.Controls.Add(lbl_cust_name)
            tc.Controls.Add(lbl_loan_id)
            tc.Controls.Add(lbl_due_dt)
            tc.Controls.Add(lbl_pay_dt)
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
        tot_payrec = open_con.check_amount_format(Math.Round(tot_payrec, 2))
        lbl_totalamt.Text = open_con.new_amount(tot_payrec)
        lbl_totalamt.Style.Add("font-weight", "bold")
        tc1.Controls.Add(lbl_total)
        tc1.Controls.Add(lbl_totalamt)
        tr1.Controls.Add(tc1)
        tbl.Rows.Add(tr1)
        '''''close the connections
        open_con.return_con.Dispose()
        cmd_pay_rec.Dispose()
        adap_pay_rec.Dispose()
        ds_pay_rec.Dispose()
    End Sub
    Protected Sub btnrepay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrepay.Click
        txtfrom.Text = ""
        txtto.Text = ""
        lbl_head.Visible = False
        btnrepay.Visible = False
        btnviewpay.Visible = False
    End Sub
    Protected Sub btnviewpay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnviewpay.Click
        Response.Redirect("../Reports/Print_PayrollRec.aspx", False)
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
