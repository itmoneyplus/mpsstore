Imports System.Data.SqlClient
Imports System.Data
Partial Class Customer_letter
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Panel2.Visible = True
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
                Label2.Visible = False

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

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Val(txtfrom_letter.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            ElseIf Val(txtto_letter.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid ending date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            ElseIf CDate(txtfrom_letter.Text) > CDate(txtto_letter.Text) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            Else
                Letter_sch()

            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub
    Sub letter_sch()

        Dim sb As New StringBuilder()

        Dim from_letter As String
        Dim to_letter As String

        from_letter = txtfrom_letter.Text
        to_letter = txtto_letter.Text

        Dim new_from_letter As String
        Dim new_to_letter As String
        new_from_letter = Date.Parse(from_letter).ToString("yyyy-MM-dd")
        new_to_letter = Date.Parse(to_letter).ToString("yyyy-MM-dd")


        from_letter = Date.Parse(from_letter).ToString("dd-MMM-yyyy")
        from_letter = from_letter.Replace("-", " ")
        to_letter = Date.Parse(to_letter).ToString("dd-MMM-yyyy")
        to_letter = to_letter.Replace("-", " ")


        Dim dt1, dt2 As DateTime

        dt1 = Convert.ToDateTime(txtto_letter.Text)
        dt2 = Convert.ToDateTime(txtfrom_letter.Text)

        Dim dt1_new, dt2_new As String
        dt1_new = Date.Parse(dt1).ToString("yyyy-MM-dd")
        dt2_new = Date.Parse(dt2).ToString("yyyy-MM-dd")
        If RadioButtonList1.SelectedItem.Text = " Finalised Loans" Then

            Label2.Visible = True
            Label2.Text = "Settled Loan Customer List from" & " " & from_letter & " to " & to_letter
            Dim cmd_SQL_new4 As New SqlCommand


            cmd_SQL_new4.CommandText = "Drop table new_letter_tbl"
            cmd_SQL_new4.Connection = open_con.return_con
            cmd_SQL_new4.ExecuteNonQuery()

            Dim cmd_SQL_new As New SqlCommand
            Dim ds_SQL_new As New DataSet
            Dim adap_SQL_new As SqlDataAdapter
            Dim str_SQL_new As String
            str_SQL_new = "Select Tbl_Customer.Customer_ID, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Loan.Loan_ID, Tbl_Loan.Period, Tbl_Loan.Loan_Type into new_letter_tbl from tbl_loan,tbl_customer where Tbl_Loan.Loan_Type='Loan' and( Tbl_Customer.status='0' or  Tbl_Customer.status is null)  and (Tbl_Customer.followup='0' or Tbl_Customer.followup is null)  and Tbl_Loan.Status='1' and tbl_customer.customer_id=tbl_loan.customer_id  GROUP BY Tbl_Customer.Customer_ID,Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Loan.Loan_ID, Tbl_Loan.Period, Tbl_Loan.Loan_Type,Tbl_Loan.Status HAVING"
            If txtfrom_letter.Text <> "" And txtto_letter.Text <> "" Then
                str_SQL_new = str_SQL_new & "  Max(Tbl_loan.loan_Date) >='" & dt2_new & "' AND Max(Tbl_loan.loan_Date) <= '" & dt1_new & "' ORDER BY Tbl_Customer.Customer_ID "
            End If

            cmd_SQL_new.CommandText = str_SQL_new
            cmd_SQL_new.Connection = open_con.return_con
            adap_SQL_new = New SqlDataAdapter(cmd_SQL_new)
            adap_SQL_new.Fill(ds_SQL_new)

            Dim cmd_SQL_new1 As New SqlCommand
            Dim ds_SQL_new1 As New DataSet
            Dim adap_SQL_new1 As SqlDataAdapter
            Dim str_SQL_new1 As String
            str_SQL_new1 = "select Customer_ID,Last_Name,Given_Name from new_letter_tbl group by customer_id,Last_Name,Given_Name"
            cmd_SQL_new1.Connection = open_con.return_con
            cmd_SQL_new1.CommandText = str_SQL_new1
            adap_SQL_new1 = New SqlDataAdapter(cmd_SQL_new1)
            adap_SQL_new1.Fill(ds_SQL_new1)

            Dim val_bool As Boolean
            Dim str_SQL_new2, str_SQL_new3 As String
            Dim count_loan, k As Integer

            k = 0

            For i As Integer = 0 To ds_SQL_new1.Tables(0).Rows.Count - 1
                count_loan = 0
                str_SQL_new2 = "SELECT  loan_id from tbl_loan where customer_id=@customer_id"
                Dim cmd_SQL_new2 As New SqlCommand
                Dim ds_SQL_new2 As New DataSet
                Dim adap_SQL_new2 As SqlDataAdapter

                cmd_SQL_new2.CommandText = str_SQL_new2
                cmd_SQL_new2.Parameters.Add("@customer_id", SqlDbType.Int).Value = ds_SQL_new1.Tables(0).Rows(i).Item("customer_id").ToString
                cmd_SQL_new2.Connection = open_con.return_con
                adap_SQL_new2 = New SqlDataAdapter(cmd_SQL_new2)
                adap_SQL_new2.Fill(ds_SQL_new2)

                For j As Integer = 0 To ds_SQL_new2.Tables(0).Rows.Count - 1
                    Dim cmd_SQL_new3 As New SqlCommand
                    Dim ds_SQL_new3 As New DataSet
                    Dim adap_SQL_new3 As SqlDataAdapter
                    str_SQL_new3 = "SELECT  round(Sum(Tbl_Payment.Amount),2) as amount_settled FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Cancellation fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND Tbl_Payment.Transaction_Status is NULL AND Tbl_Payment.Payment_Date is NULL AND Tbl_Payment.Payment_Status is NULL AND Tbl_Payment.Loan_ID=" & ds_SQL_new2.Tables(0).Rows(j).Item("loan_id").ToString & "AND Tbl_Payment_1.Update_ID Is Null "
                    cmd_SQL_new3.CommandText = str_SQL_new3
                    cmd_SQL_new3.Connection = open_con.return_con
                    adap_SQL_new3 = New SqlDataAdapter(cmd_SQL_new3)
                    adap_SQL_new3.Fill(ds_SQL_new3)

                    If Val(ds_SQL_new3.Tables(0).Rows(0).Item("amount_settled").ToString) = 0 Then
                        count_loan = count_loan
                    Else
                        count_loan = count_loan + 1
                    End If
                    cmd_SQL_new3.Dispose()
                    ds_SQL_new3.Dispose()
                    adap_SQL_new3.Dispose()
                Next

                If val_bool = True Then

                ElseIf count_loan = 0 And val_bool = False And Val(ds_SQL_new1.Tables(0).Rows.Count) <> 0 Then
                    'Response.Write("<body>")
                    'Response.Write("<div style='text-align:center'>")
                    'Response.Write("<table id='tbl' border='1' width='78%' style='font-size:16px;border:1 solid gray; ' cellpadding='0' cellspacing='0' >")
                    sb.Append("<table id='tbl' cellpadding='0' cellspacing='0' class='tblreport_new' width='100%'>")
                    sb.Append("<tr>")
                    sb.Append("<td width='4%' align='center' bgcolor='#EEEEEE'><b>No</b></td>")
                    sb.Append("<td width='8%' align='center' bgcolor='#EEEEEE'><b><font color='#000000'>Select</font></b><input  onClick='toggle(this)' type=""checkbox""  name=""chkCustomerIDs" & """></td>")
                    sb.Append("<td width='15%' align='center' bgcolor='#EEEEEE'><b>Customer No</td>")
                    sb.Append("<td width='28%' align='center' bgcolor='#EEEEEE'><b>Customer Name</b></td>")
                    sb.Append("</tr>")
                    val_bool = True
                End If

                If count_loan = 0 And Val(ds_SQL_new1.Tables(0).Rows.Count) <> 0 Then
                    With sb
                        .Append("<tr>")
                        .Append("<td bordercolorlight=""#C0C0C0"" bordercolordark=""#C0C0C0"" align=""center""" & ">" & k + 1 & "</td>")
                        .Append("<td bordercolorlight=""#C0C0C0"" bordercolordark=""#C0C0C0"" align=""center""" & ">&nbsp;<input  onclick='add_val(""" & ds_SQL_new1.Tables(0).Rows(i).Item("Customer_ID").ToString & """)' type=""checkbox"" value=""" & ds_SQL_new1.Tables(0).Rows(i).Item("Customer_ID").ToString & """ name=""chkCustomerIDs" & """></td>")
                        .Append("<td bordercolorlight=""#C0C0C0"" bordercolordark=""#C0C0C0"" align=""center""" & ">" & "" & " " & ds_SQL_new1.Tables(0).Rows(i).Item("Customer_ID").ToString & "</td>")
                        .Append("<td bordercolorlight=""#C0C0C0"" bordercolordark=""#C0C0C0""" & ">&nbsp;&nbsp;" & ds_SQL_new1.Tables(0).Rows(i).Item("Given_Name").ToString & " " & ds_SQL_new1.Tables(0).Rows(i).Item("Last_Name").ToString & "&nbsp;</td>")
                        .Append("</tr>")
                    End With
                    k = k + 1
                End If
                cmd_SQL_new2.Dispose()
                ds_SQL_new2.Dispose()
                adap_SQL_new2.Dispose()
            Next

            If val_bool = True And Val(ds_SQL_new1.Tables(0).Rows.Count) <> 0 Then
                sb.Append("<tr>")
                sb.Append("<td colspan='14' style='border-color:white'>")
                sb.Append("<br/>")
                sb.Append("<br/>")

                sb.Append("<input type='button_show' ID='Btn_show' style='width:90px;text-align:center' value='Create Letter'   onclick='return show_let(""" & drp_letter.SelectedItem.Text & """)' />")
                sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                sb.Append("<input type='button_recreate' ID='Btn_recreate'  style='width:120px;text-align:center'   value='Re-Create Again'   onclick='ClearTextboxes()' />")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                'Response.Write("</div>")
                'Response.Write("</body>")
                Literal1.Text = sb.ToString()

            Else
                Literal1.Text = ""
                Label2.Visible = True
                Label2.Text = "No Records found from" & " " & from_letter & " to " & to_letter
            End If
            cmd_SQL_new.Dispose()
            cmd_SQL_new1.Dispose()
            cmd_SQL_new4.Dispose()
            ds_SQL_new.Dispose()
            ds_SQL_new1.Dispose()
            adap_SQL_new.Dispose()
            adap_SQL_new1.Dispose()
            open_con.return_con.Dispose()

        ElseIf RadioButtonList1.SelectedItem.Text = " Balance Outstanding Loans" Then
            Dim sbol As New StringBuilder()
            Label2.Visible = True
            Label2.Text = "Balance Outstanding Loans Customer List from" & " " & from_letter & " to " & to_letter
            Dim str_SQL_new As String
            str_SQL_new = "Select Tbl_Customer.Customer_ID, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Loan.Loan_ID, Tbl_Loan.Period, Tbl_Loan.Loan_Type  from tbl_loan,tbl_customer where Tbl_Loan.Loan_Type='Loan' and ( Tbl_Customer.status='0' or  Tbl_Customer.status is null)  and (Tbl_Customer.followup='0' or Tbl_Customer.followup is null)  and Tbl_Loan.Status='1' and tbl_customer.customer_id=tbl_loan.customer_id  GROUP BY Tbl_Customer.Customer_ID,Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Loan.Loan_ID, Tbl_Loan.Period, Tbl_Loan.Loan_Type,Tbl_Loan.Status HAVING"
            If txtfrom_letter.Text <> "" And txtto_letter.Text <> "" Then
                str_SQL_new = str_SQL_new & "  Max(Tbl_loan.loan_Date) >='" & dt2_new & "' AND Max(Tbl_loan.loan_Date) <= '" & dt1_new & "' ORDER BY Tbl_Customer.Customer_ID "
            End If
            Dim str_SQL As String
            Dim cmd_SQL_new, cmd_SQL As New SqlCommand
            Dim adap_SQL_new As SqlDataAdapter
            Dim ds_SQL_new, ds_SQL As New DataSet
            cmd_SQL_new.CommandText = str_SQL_new
            cmd_SQL_new.Connection = open_con.return_con
            adap_SQL_new = New SqlDataAdapter(cmd_SQL_new)
            adap_SQL_new.Fill(ds_SQL_new)

            If Val(ds_SQL_new.Tables(0).Rows.Count) <> 0 Then
                'Response.Write("<body>")
                'Response.Write("<div style='text-align:center'>")
                'Response.Write("<table id='tbl' border='1' width='78%' style='font-size:16px;border:0 solid gray; ' cellpadding='0' cellspacing='0' >")
                sbol.Append("<table id='tbl' cellpadding='0' cellspacing='0' class='tblreport_new' width='100%'>")
                sbol.Append("<tr>")
                sbol.Append("<td width='4%' align='center' bgcolor='#EEEEEE'><b>No</b></td>")
                sbol.Append("<td width='8%' align='center' bgcolor='#EEEEEE'><b><font color='#000000'>Select</font></b></a></td>")
                sbol.Append("<td width='15%' align='center' bgcolor='#EEEEEE'><b>Customer No</td>")
                sbol.Append("<td width='28%' align='center' bgcolor='#EEEEEE'><b>Customer Name</b></td>")
                sbol.Append("<td width='15%' align='center' bgcolor='#EEEEEE'><b>Loan</b></td>")
                sbol.Append("<td width='15%' align='center' bgcolor='#EEEEEE'><b>Amount</b></td>")
                sbol.Append("<td width='15%' align='center' bgcolor='#EEEEEE' ><b>Loan Period</b></td>")
                sbol.Append("</tr>")
            Else


                Label2.Visible = True
                Label2.Text = "No Records found from" & " " & from_letter & " to " & to_letter
                Exit Sub
            End If
            Dim k As Integer = 0
            For j As Integer = 0 To ds_SQL_new.Tables(0).Rows.Count - 1
                str_SQL = "SELECT  round(Sum(Tbl_Payment.Amount),2) as amount_settled FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Cancellation fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND Tbl_Payment.Transaction_Status is NULL AND Tbl_Payment.Payment_Date is NULL AND Tbl_Payment.Payment_Status is NULL AND Tbl_Payment.Loan_ID=" & ds_SQL_new.Tables(0).Rows(j).Item("loan_id").ToString & " AND Tbl_Payment_1.Update_ID Is Null "
                cmd_SQL.CommandText = str_SQL
                cmd_SQL.Connection = open_con.return_con
                Dim adap_SQL As SqlDataAdapter
                adap_SQL = New SqlDataAdapter(cmd_SQL)
                adap_SQL.Fill(ds_SQL)


                If Val(ds_SQL.Tables(0).Rows(j).Item(0).ToString) <> 0 Then


                    If ds_SQL.Tables(0).Rows.Count <> 0 Then

                    Else
                        Exit Sub
                    End If




                    With sbol
                        .Append("<tr>")
                        .Append("<td bordercolorlight=""#C0C0C0"" bordercolordark=""#C0C0C0"" align=""center""" & ">" & k + 1 & "</td>")
                        .Append("<td bordercolorlight=""#C0C0C0"" bordercolordark=""#C0C0C0"" align=""center""" & ">&nbsp;<input  onclick='add_val(""" & ds_SQL_new.Tables(0).Rows(j).Item("Customer_ID").ToString & """)' type=""checkbox"" value=""" & ds_SQL_new.Tables(0).Rows(j).Item("Customer_ID").ToString & """ name=""chkCustomerIDs" & """></td>")
                        .Append("<td bordercolorlight=""#C0C0C0"" bordercolordark=""#C0C0C0"" align=""center""" & ">" & "" & " " & ds_SQL_new.Tables(0).Rows(j).Item("Customer_ID").ToString & "</td>")
                        .Append("<td bordercolorlight=""#C0C0C0"" bordercolordark=""#C0C0C0""" & ">&nbsp;&nbsp;" & ds_SQL_new.Tables(0).Rows(j).Item("Given_Name").ToString & " " & ds_SQL_new.Tables(0).Rows(j).Item("Last_Name").ToString & "&nbsp;</td>")
                        .Append("<td bordercolorlight=""#C0C0C0"" bordercolordark=""#C0C0C0"" align=""center""" & ">" & ds_SQL_new.Tables(0).Rows(j).Item("Loan_ID").ToString & "&nbsp;</td>")
                        .Append("<td bordercolorlight=""#C0C0C0"" bordercolordark=""#C0C0C0"" align=""right""" & ">&nbsp;&nbsp;$" & FormatNumber(ds_SQL.Tables(0).Rows(j).Item("amount_settled").ToString, 2) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>")
                        If ds_SQL_new.Tables(0).Rows(j).Item("Period").ToString = "1" Then
                            .Append("<td bordercolorlight=""#C0C0C0"" bordercolordark=""#C0C0C0"" align=""left""" & ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & ds_SQL_new.Tables(0).Rows(j).Item("Period").ToString & "&nbsp;Month</td>")
                        Else
                            .Append("<td bordercolorlight=""#C0C0C0"" bordercolordark=""#C0C0C0"" align=""left""" & ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & ds_SQL_new.Tables(0).Rows(j).Item("Period").ToString & "&nbsp;Months</td>")
                        End If

                        .Append("</tr>")
                    End With


                    k = k + 1
                End If


            Next
            If Val(ds_SQL_new.Tables(0).Rows.Count) <> 0 Then
                sbol.Append("<tr>")
                sbol.Append("<td colspan='14' style='border-color:white'>")

                sbol.Append("<br/>")
                sbol.Append("<br/>")

                sbol.Append("<input type='button_show' ID='Btn_show' style='width:90px;text-align:center' value='Create Letter'   onclick='return show_let(""" & drp_letter.SelectedItem.Text & """)' />")
                sbol.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                sbol.Append("<input type='button_recreate' ID='Btn_recreate'  style='width:120px;text-align:center'   value='Re-Create Again'   onclick='ClearTextboxes()' />")

                sbol.Append("</td>")
                sbol.Append("</tr>")
                sbol.Append("</table>")
                'Response.Write("</div>")
                ' Response.Write("</body>")
                Literal1.Text = sbol.ToString()
            End If
            cmd_SQL.Dispose()
            ds_SQL.Dispose()
            ds_SQL_new.Dispose()
            cmd_SQL_new.Dispose()
            adap_SQL_new.Dispose()
            open_con.return_con.Close()




        ElseIf RadioButtonList1.SelectedItem.Text = " Cheque Customers" Then

        End If


    End Sub

    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub

End Class
