Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports AjaxControlToolkit
Imports System.Globalization
Partial Class Services_Loan_Application
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Dim flag_val As Boolean = False
    Dim r_load As Boolean
    Function fn_AdjustStringForSQL(ByVal psStringtoChange As String) As String
        Dim lStartPosition As Integer
        lStartPosition = 1
        While InStr(lStartPosition, psStringtoChange, "'")
            psStringtoChange = Left(psStringtoChange, InStr(lStartPosition, psStringtoChange, "'")) & Mid(psStringtoChange, InStr(lStartPosition, psStringtoChange, "'"), Len(psStringtoChange))
            lStartPosition = InStr(lStartPosition, psStringtoChange, "'") + 2
        End While
        fn_AdjustStringForSQL = psStringtoChange

    End Function

    Protected Sub binddata()
        Try
            r_load = True
            Dim cmd As New SqlCommand
            Dim str_SQL As String
            str_SQL = " SELECT *  FROM Tbl_Customer   where  "
            If txtsearch.Text <> "" Then
                If IsNumeric(Trim(txtsearch.Text)) Then
                    str_SQL = str_SQL & "Customer_ID = " & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & " OR "
                End If
                str_SQL = str_SQL & " Given_Name like '" & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & "%'"
                str_SQL = str_SQL & " OR Last_Name like '" & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & "%'"
                str_SQL = str_SQL & " OR R_Given_Name like '" & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & "%'"
                str_SQL = str_SQL & " OR R_Last_Name like '" & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & "%'"
                str_SQL = str_SQL & " ORDER BY Given_Name, Last_Name "
                cmd.Connection = open_con.return_con
                cmd.CommandText = str_SQL
                cmd.ExecuteNonQuery()
                Dim adap As SqlDataAdapter
                adap = New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                adap.Fill(ds)
                If ds.Tables(0).Rows.Count = 0 Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No such Customer Exist!!!" & "');", True)
                    txtsearch.Text = ""
                    txtsearch.Focus()
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                    Label3.Visible = False
                    Exit Sub
                Else
                    txtsearch.Text = ""
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                    Label3.Visible = True
                End If
                open_con.return_con.Dispose()
                adap.Dispose()
                cmd.Dispose()
            Else
                If Page.IsPostBack = False Then
                Else
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid Customer Name or ID!!!" & "');", True)
                End If
            End If

        Catch ex As Exception
            ' Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub

    Protected Sub LinkButton_AddCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_AddCustomer.Click
        Response.Redirect("./Personal_Form.aspx", False)
    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='none';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFBD6'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            e.Row.Attributes.Add("ondblClick", ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex))
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.Cells.Item(4).Text = "&nbsp;" Then
            e.Row.Cells(4).Text = ""
        ElseIf e.Row.Cells.Item(4).Text = "Request Amount" Then
            e.Row.Cells.Item(4).Text = "Request Amount"
        Else
            e.Row.Cells(4).Text = CStr(e.Row.Cells(4).Text.ToString)
        End If

    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Dim row_index As Integer
        row_index = GridView1.SelectedRow.RowIndex
        Dim customer_ID As Integer
        Dim last_name As String
        Dim given_name As String
        customer_ID = GridView1.Rows(row_index).Cells.Item(0).Text
        open_con.customer_id_val = customer_ID
        given_name = GridView1.Rows(row_index).Cells.Item(1).Text
        last_name = GridView1.Rows(row_index).Cells.Item(2).Text
        Session("Customer_name") = given_name & " " & last_name & " " & Session("branch_prefix") & " " & open_con.customer_id_val
        Session("Customer_namebank") = given_name & " " & last_name
        Response.Redirect("./detail.aspx", False)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        '------ tool ---------------------

        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Label_customername.Text = Session("Customer_name")
            Session("user_type") = open_con.manager_name(Session("user_id"))

            If open_con.customer_status(open_con.customer_id_val).status = True Or open_con.followup_status(open_con.customer_id_val) = True Then
                LinkButton8.Enabled = False
                LinkButton8.Attributes.CssStyle.Add("background", "Platinum")
                LinkButton8.Attributes.CssStyle.Add("color", "white")
                LinkButton9.Enabled = False
                LinkButton9.Attributes.CssStyle.Add("background", "Platinum")
                LinkButton9.Attributes.CssStyle.Add("color", "white")
            End If


            If Session("user_type") = "Admin" Then
                If open_con.customer_status(open_con.customer_id_val).status = True Then
                    LinkButton10.Enabled = False
                    LinkButton11.Visible = True
                    LinkButton10.Attributes.CssStyle.Add("background", "Platinum")
                    LinkButton10.Attributes.CssStyle.Add("color", "white")

                Else
                    LinkButton10.Visible = True
                    LinkButton11.Visible = True

                End If


            Else
                LinkButton10.Visible = True
                LinkButton11.Enabled = False
                LinkButton11.Attributes.CssStyle.Add("background", "Platinum")
                LinkButton11.Attributes.CssStyle.Add("color", "white")

            End If

            If Session("user_type") = "Admin" Or Session("user_type") = "Manager" Then

                If open_con.followup_status(open_con.customer_id_val) = True Then
                    LinkButton12.Enabled = False
                    LinkButton13.Visible = True
                    LinkButton12.Attributes.CssStyle.Add("background", "Platinum")
                    LinkButton12.Attributes.CssStyle.Add("color", "white")
                Else
                    LinkButton12.Visible = True
                    LinkButton13.Visible = True
                End If

            Else
                LinkButton12.Visible = True
                LinkButton13.Enabled = False
                LinkButton13.Attributes.CssStyle.Add("background", "Platinum")
                LinkButton13.Attributes.CssStyle.Add("color", "white")
            End If
        End If


        '---------------------------------

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
    Protected Sub LinkButton10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton10.Click
        Dim cmd_black As New SqlCommand
        Dim str_black As String

        Dim confirmValue_black As String = Request.Form("confirm_value_black")
        If confirmValue_black = "Yes" Then
            str_black = "update tbl_customer set Status = 1, Status_Date= '" & System.DateTime.Now.Date & "'" & "where customer_id =" & open_con.customer_id_val
            cmd_black.Connection = open_con.return_con
            cmd_black.CommandText = str_black
            cmd_black.ExecuteNonQuery()
            cmd_black.Dispose()
            Response.Redirect("Detail.aspx")

        Else
            Exit Sub
        End If
    End Sub
    Protected Sub LinkButton11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton11.Click
        Dim cmd_reblack As New SqlCommand
        Dim str_reblack As String

        Dim confirmValue_reblack As String = Request.Form("confirm_value_reblack")
        If confirmValue_reblack = "Yes" Then
            str_reblack = "update tbl_customer set Status = 0, Status_Date= '" & System.DateTime.Now.Date & "'" & "where customer_id =" & open_con.customer_id_val
            cmd_reblack.Connection = open_con.return_con
            cmd_reblack.CommandText = str_reblack
            cmd_reblack.ExecuteNonQuery()
            cmd_reblack.Dispose()
            Response.Redirect("Detail.aspx")

        Else
            Exit Sub
        End If
    End Sub
    Protected Sub LinkButton12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton12.Click
        Dim cmd_followup As New SqlCommand
        Dim str_followup As String

        Dim confirmValue_followup As String = Request.Form("confirm_value_Followup")
        If confirmValue_followup = "Yes" Then
            str_followup = "update tbl_customer set followup = 1 where customer_id =" & open_con.customer_id_val
            cmd_followup.Connection = open_con.return_con
            cmd_followup.CommandText = str_followup
            cmd_followup.ExecuteNonQuery()
            cmd_followup.Dispose()
            Response.Redirect("Detail.aspx")

        Else
            Exit Sub
        End If
    End Sub
    Protected Sub LinkButton13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton13.Click
        Dim cmd_refollowup As New SqlCommand
        Dim str_refollowup As String

        Dim confirmValue_refollowup As String = Request.Form("confirm_value_reFollowup")
        If confirmValue_refollowup = "Yes" Then
            str_refollowup = "update tbl_customer set followup = 0 where customer_id =" & open_con.customer_id_val
            cmd_refollowup.Connection = open_con.return_con
            cmd_refollowup.CommandText = str_refollowup
            cmd_refollowup.ExecuteNonQuery()
            cmd_refollowup.Dispose()
            Response.Redirect("Detail.aspx")

        Else
            Exit Sub
        End If
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click


        Try


            If txtchedrw.Text = "" Then

                txtchedrw.Focus()
                txtchedrw.BackColor = Drawing.Color.Red
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid cheque name!!!" & "');", True)
                Exit Sub
            Else
                txtchedrw.BackColor = Drawing.Color.White
            End If
            '''''''''''''put len validation after asking rose

            If IsNumeric(txtcheno.Text) = False Then
                txtcheno.Focus()
                txtcheno.BackColor = Drawing.Color.Red
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid cheque number!!!" & "');", True)
                Exit Sub
            Else
                txtcheno.BackColor = Drawing.Color.White
            End If

            If IsNumeric(txtaccno.Text) = False Then
                txtaccno.Focus()
                txtaccno.BackColor = Drawing.Color.Red
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid account number!!!" & "');", True)
                Exit Sub
            Else
                txtaccno.BackColor = Drawing.Color.White
            End If

            If txtBSB.Text = "" Then
                txtBSB.Focus()
                txtBSB.BackColor = Drawing.Color.Red
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid BSB!!!" & "');", True)
                Exit Sub
            Else
                txtBSB.BackColor = Drawing.Color.White
            End If

            If txtcheamt.Text = "" And Val(txtcheamt.Text) = 0 Then
                txtcheamt.Focus()
                txtcheamt.BackColor = Drawing.Color.Red
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid cheque amount!!!" & "');", True)
                Exit Sub
            Else
                txtcheamt.BackColor = Drawing.Color.White
            End If
            If IsNumeric(txtcheamt.Text) = False Then
                txtcheamt.Focus()
                txtcheamt.BackColor = Drawing.Color.Red
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid cheque amount!!!" & "');", True)
                Exit Sub
            Else
                txtcheamt.BackColor = Drawing.Color.White
            End If

            If txtchefee.Text = "" And Val(txtchefee.Text) = 0 Then
                txtchefee.Focus()
                txtchefee.BackColor = Drawing.Color.Red
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid cheque fee!!!" & "');", True)
                Exit Sub
            Else
                txtchefee.BackColor = Drawing.Color.White
            End If
            If IsNumeric(txtchefee.Text) = False Then
                txtchefee.Focus()
                txtchefee.BackColor = Drawing.Color.Red
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid cheque fee!!!" & "');", True)
                Exit Sub
            Else
                txtchefee.BackColor = Drawing.Color.White
            End If

            If txtcal.Text <> "" Then
                If Val(txtcal.Text) < 0 Then
                    txtcal.Focus()
                    txtcal.BackColor = Drawing.Color.Red
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid percentage amount!!!" & "');", True)
                    Exit Sub
                Else
                    txtcal.BackColor = Drawing.Color.White
                End If
            Else
            End If

            If ddlTeller.SelectedValue = "0" Then
                ddlTeller.Focus()
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select Teller No.!!!" & "');", True)
                Exit Sub
            End If


            Dim cmd_cheque As New SqlCommand
            Dim str_SQL As String
            If Val(txtcheamt.Text) = Val(txtchefee.Text) + Val(txtpaycash.Text) Then
                If Val(txtcheamt.Text) = Val(txtpaycash.Text) Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Check amount cannot be equal to Pay cash amount!!!" & "');", True)
                    Exit Sub
                Else

                End If
                If Val(txtcheamt.Text) = Val(txtchefee.Text) Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Check amount cannot be equal to Check fee amount!!!" & "');", True)
                    Exit Sub
                Else

                End If
                str_SQL = "Insert into Tbl_Cheque_Cashing(Customer_ID,Cheque_Name,Cheque_Number, Account_Number, BSB,Cheque_Amount,Cheque_Fee, Pay_Cash_Now, User_ID, User_Machine_ID,Cheque_Cashed_On) values(@Customer_ID,@Cheque_Name,@Cheque_Number, @Account_Number, @BSB,@Cheque_Amount,@Cheque_Fee, @Pay_Cash_Now, @User_ID, @User_Machine_ID,@Cheque_Cashed_On)"
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid amount!!!" & "');", True)
                Exit Sub
            End If

            Button2_Click(Nothing, Nothing)


            cmd_cheque.Connection = open_con.return_con
            cmd_cheque.CommandText = str_SQL
            cmd_cheque.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
            cmd_cheque.Parameters.Add("@Cheque_Name", SqlDbType.VarChar, 255).Value = txtchedrw.Text
            cmd_cheque.Parameters.Add("@Cheque_Number", SqlDbType.VarChar, 255).Value = txtcheno.Text
            cmd_cheque.Parameters.Add("@Account_Number", SqlDbType.VarChar, 255).Value = txtaccno.Text
            cmd_cheque.Parameters.Add("@BSB", SqlDbType.VarChar, 255).Value = txtBSB.Text
            cmd_cheque.Parameters.Add("@Cheque_Amount", SqlDbType.VarChar, 255).Value = txtcheamt.Text
            cmd_cheque.Parameters.Add("@Cheque_Fee", SqlDbType.VarChar, 255).Value = txtchefee.Text
            cmd_cheque.Parameters.Add("@Pay_Cash_Now", SqlDbType.VarChar, 255).Value = txtpaycash.Text
            cmd_cheque.Parameters.Add("@User_ID", SqlDbType.VarChar, 255).Value = open_con.user_id_val
            'cmd_cheque.Parameters.Add("@User_Machine_ID", SqlDbType.VarChar, 255).Value = open_con.GetIP4Address()
            cmd_cheque.Parameters.Add("@User_Machine_ID", SqlDbType.VarChar, 255).Value = ddlTeller.SelectedItem.Text
            cmd_cheque.Parameters.Add("@Cheque_Cashed_On", SqlDbType.Date).Value = System.DateTime.Now.Date
            cmd_cheque.ExecuteNonQuery()

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Record Saved!!!" & "');", True)
            open_con.return_con.Close()
            cmd_cheque.Dispose()


            txtchedrw.Text = ""
            txtcheno.Text = ""
            txtaccno.Text = ""
            txtBSB.Text = ""
            txtcheamt.Text = ""
            txtchefee.Text = ""
            txtpaycash.Text = ""
            txtamtpay.Text = ""
            txtcal.Text = ""
            Button1.Enabled = False
        Catch ex As Exception
            Response.Write(ex.Message)

        End Try
    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtcheamt.Text <> "" Then

            If IsNumeric(txtcheamt.Text) = True Then
                If Val(txtcheamt.Text) > 0 Then
                    If txtcal.Text <> "" Then
                        If IsNumeric(txtcal.Text) = True Then
                            If Val(txtcal.Text) > 0 Then

                                txtcheamt.Text = FormatNumber(txtcheamt.Text, 2)
                                txtchefee.Text = FormatNumber(((txtcal.Text) / 100) * txtcheamt.Text, 2)
                                txtpaycash.Text = FormatNumber(txtcheamt.Text - txtchefee.Text, 2)
                                txtamtpay.Text = txtpaycash.Text

                                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert1", "alert('" & txtcal.Text & "% is $" & txtchefee.Text & "');", True)
                                txtpaycash.Focus()

                            Else
                                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Enter valid percentage amount!!!" & "');", True)
                                Exit Sub
                            End If
                        End If
                    Else
                        If txtchefee.Text <> "" Then

                            If IsNumeric(txtchefee.Text) = True Then
                                If Val(txtchefee.Text) > 0 Then
                                    If Val(txtchefee.Text) > Val(txtcheamt.Text) Then
                                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Cheque fee may have exceeded cheque amount.Please re-enter!!!" & "');", True)
                                        Button1.Enabled = False

                                        Exit Sub
                                    Else
                                        txtcal.Text = FormatNumber(((txtchefee.Text) * 100) / (txtcheamt.Text), 2)
                                        txtpaycash.Text = FormatNumber(txtcheamt.Text - txtchefee.Text, 2)
                                        Button1.Enabled = True
                                        txtchefee.Text = FormatNumber(txtchefee.Text, 2)
                                        txtcheamt.Text = FormatNumber(txtcheamt.Text, 2)
                                        txtamtpay.Text = txtpaycash.Text
                                        txtpaycash.Focus()
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If


            End If
        End If

    End Sub
    Protected Sub txtchefee_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtchefee.TextChanged
        txtcal.Text = ""
        If Val(txtchefee.Text) >= Val(txtcheamt.Text) Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Cheque fee may have exceeded cheque amount.Please re-enter!!!" & "');", True)
            txtchefee.Focus()
        End If
        Button1.Enabled = True
        Button2_Click(Nothing, Nothing)

    End Sub
   

    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Session("bank_nom") = False
        Session("letter") = 0
        Session("sch_history") = 0
        Session("loan_st") = 0
        Session("r_load") = "True"
        Session("Pay_re") = False
        Session("pay_sch") = False
        If txtsearch.Text <> "" Then
            flag_val = True
        End If
        If flag_val = True And r_load <> True Then
            Panel3.Visible = False
            Session("Show") = 0
            binddata()
        End If
    End Sub

    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub

End Class
