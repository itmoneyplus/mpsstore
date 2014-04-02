Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Partial Class Customer_Personal_Form
    Inherits System.Web.UI.Page
    Dim sav As New Class1
    Dim flag_upd As Boolean
    Dim open_con As New Class1

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
            Try
                If Page.IsPostBack = False Then
                    txtDLicence.Enabled = False
                    txtLicence_card_no.Enabled = False
                    drop6.Enabled = False
                    drop7.Enabled = False
                    txtPassport.Enabled = False
                    txtPlace_Of_Birth.Enabled = False
                    RadioButton1.Checked = False
                    RadioButton2.Checked = False
                    Dim cmd As New SqlCommand
                    cmd.Connection = open_con.return_con
                    cmd.CommandText = "Select * from tbl_customer  where customer_id=" & open_con.customer_id_val
                    cmd.ExecuteNonQuery()
                    Dim update_adap As SqlDataAdapter
                    Dim ds_update As New DataSet
                    update_adap = New SqlDataAdapter(cmd)
                    update_adap.Fill(ds_update)
                    lbl_custid.Text = "NETL " & open_con.customer_id_val
                    drop1.SelectedItem.Text = "$" & Val(ds_update.Tables(0).Rows(0).Item("Request_Amount").ToString)
                    drop2.SelectedItem.Text = ds_update.Tables(0).Rows(0).Item("Purpose_Loan").ToString
                    drop4.SelectedItem.Text = ds_update.Tables(0).Rows(0).Item("Title").ToString
                    txtlastname.Text = ds_update.Tables(0).Rows(0).Item("Last_Name").ToString
                    txtgvnname.Text = ds_update.Tables(0).Rows(0).Item("Given_Name").ToString
                    txtdtbirth.Text = CDate(ds_update.Tables(0).Rows(0).Item("Date_Of_Birth").ToString)
                    txtHomePhone.Text = ds_update.Tables(0).Rows(0).Item("Home_Phone").ToString
                    txtwrk.Text = ds_update.Tables(0).Rows(0).Item("Work_Phone").ToString
                    txtmobile.Text = ds_update.Tables(0).Rows(0).Item("Mobile_Phone").ToString
                    txtstrtnor.Text = ds_update.Tables(0).Rows(0).Item("Street_Number").ToString
                    txtstrtnmr.Text = ds_update.Tables(0).Rows(0).Item("Street_Name").ToString
                    txtsubr.Text = ds_update.Tables(0).Rows(0).Item("Suburb").ToString
                    txtstater.Text = ds_update.Tables(0).Rows(0).Item("State").ToString
                    txtpstcoder.Text = ds_update.Tables(0).Rows(0).Item("Post_Code").ToString
                    txtstrtnom.Text = ds_update.Tables(0).Rows(0).Item("M_Address").ToString
                    txtstrtnmm.Text = ds_update.Tables(0).Rows(0).Item("M_Street_Name").ToString
                    txtsubm.Text = ds_update.Tables(0).Rows(0).Item("M_Suburb").ToString
                    txtstatem.Text = ds_update.Tables(0).Rows(0).Item("M_State").ToString
                    txtpstcodem.Text = ds_update.Tables(0).Rows(0).Item("M_Post_Code").ToString
                    drop5.SelectedItem.Text = ds_update.Tables(0).Rows(0).Item("Marital_Status").ToString
                    drop9.SelectedItem.Text = ds_update.Tables(0).Rows(0).Item("Residential_Status").ToString
                    txtlastnamesp.Text = ds_update.Tables(0).Rows(0).Item("R_Last_Name").ToString
                    txtgvnnamesp.Text = ds_update.Tables(0).Rows(0).Item("R_Given_Name").ToString
                    drop3.SelectedItem.Text = ds_update.Tables(0).Rows(0).Item("Marketing_Text").ToString
                    txtcmpnmemp.Text = ds_update.Tables(0).Rows(0).Item("Employer").ToString
                    txtsub.Text = ds_update.Tables(0).Rows(0).Item("E_Suburb").ToString
                    txtcnctnoemp.Text = ds_update.Tables(0).Rows(0).Item("E_Phone_Number").ToString
                    txttypbus.Text = ds_update.Tables(0).Rows(0).Item("Business").ToString
                    txtpos.Text = ds_update.Tables(0).Rows(0).Item("Position").ToString
                    txtEmail.Text = ds_update.Tables(0).Rows(0).Item("Email").ToString
                    txtinc.Text = ds_update.Tables(0).Rows(0).Item("Income").ToString

                    If ds_update.Tables(0).Rows(0).Item("D_Licence").ToString <> "" Then
                        txtDLicence.Enabled = True
                        txtLicence_card_no.Enabled = True
                        drop6.Enabled = True
                        txtDLicence.Text = ds_update.Tables(0).Rows(0).Item("D_Licence").ToString
                        txtLicence_card_no.Text = ds_update.Tables(0).Rows(0).Item("Licence_card_no").ToString
                        drop6.SelectedItem.Text = ds_update.Tables(0).Rows(0).Item("D_State").ToString
                        RadioButton1.Checked = True
                    Else
                        txtDLicence.Enabled = False
                        txtLicence_card_no.Enabled = False
                        drop6.Enabled = False
                    End If

                    If ds_update.Tables(0).Rows(0).Item("Passport").ToString <> "" Then
                        drop7.Enabled = True
                        txtPassport.Enabled = True
                        txtPlace_Of_Birth.Enabled = True
                        txtPassport.Text = ds_update.Tables(0).Rows(0).Item("Passport").ToString
                        drop7.SelectedItem.Text = ds_update.Tables(0).Rows(0).Item("Countries").ToString
                        txtPlace_Of_Birth.Text = ds_update.Tables(0).Rows(0).Item("Place_Of_Birth").ToString
                        RadioButton2.Checked = True
                    Else

                        drop7.Enabled = False
                        txtPassport.Enabled = False
                        txtPlace_Of_Birth.Enabled = False

                    End If
                    If drop6.SelectedItem.Text = "WA" Then
                        Dim licence_ex As String
                        licence_ex = ds_update.Tables(0).Rows(0).Item("Licence_Expiry_Date").ToString
                        If Val(licence_ex) <> 0 Then
                            Label1.Visible = True
                            txtled.Visible = True
                            txtled.Text = CDate(ds_update.Tables(0).Rows(0).Item("Licence_Expiry_Date").ToString)
                        Else
                            Label1.Visible = True
                            txtled.Visible = True

                        End If


                    End If


                    txtragency.Text = ds_update.Tables(0).Rows(0).Item("R_Agency_Name").ToString
                    txtemppostcode.Text = ds_update.Tables(0).Rows(0).Item("E_Post_Code").ToString
                    txtempstreetname.Text = ds_update.Tables(0).Rows(0).Item("E_Street_Name").ToString
                    txtunitnor.Text = ds_update.Tables(0).Rows(0).Item("Unit_No").ToString
                    txtunitnom.Text = ds_update.Tables(0).Rows(0).Item("M_Unit_No").ToString
                    drop8.SelectedItem.Text = ds_update.Tables(0).Rows(0).Item("Emp_Status").ToString
                    txtyrs.Text = ds_update.Tables(0).Rows(0).Item("Emp_Year").ToString
                    txtmnths.Text = ds_update.Tables(0).Rows(0).Item("Emp_Mths").ToString
                    txtcmpnmres.Text = ds_update.Tables(0).Rows(0).Item("Agent").ToString
                    txtcnctres.Text = ds_update.Tables(0).Rows(0).Item("Agent_No").ToString
                    txtattention.Text = ds_update.Tables(0).Rows(0).Item("e_contact_person").ToString
                    txtfax.Text = ds_update.Tables(0).Rows(0).Item("E_Fax_Number").ToString
                    txtempno.Text = ds_update.Tables(0).Rows(0).Item("Employee_no").ToString
                    txt_email.Text = ds_update.Tables(0).Rows(0).Item("E_Email").ToString
                    DropDownList1.Text = ds_update.Tables(0).Rows(0).Item("Employee_Salary_Period").ToString
                    txthousehold.Text = ds_update.Tables(0).Rows(0).Item("Monthly_Household").ToString
                    txtrentmortgage.Text = ds_update.Tables(0).Rows(0).Item("Rent_Mortgage").ToString
                    txtrepay.Text = ds_update.Tables(0).Rows(0).Item("Loan_Repayment").ToString
                    txtfood.Text = ds_update.Tables(0).Rows(0).Item("Monthly_Food").ToString
                    txtothers.Text = ds_update.Tables(0).Rows(0).Item("Monthly_Others").ToString
                    txtuti.Text = ds_update.Tables(0).Rows(0).Item("Monthly_Utilities").ToString
                    ds_update.Dispose()
                    cmd.Dispose()
                    open_con.return_con.Dispose()
                    update_adap.Dispose()


                End If


            Catch ex As Exception

                Response.Write("Error: " & ex.Message)
            End Try

        End If

    End Sub

    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
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
    Protected Sub update_btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update_btn.Click
        flag_upd = True

        Dim date_updated As String
        Dim flag_update As Boolean = False
        date_updated = System.DateTime.Now.Date.ToString("yyyy-MM-dd")

        Try
            'If drop1.SelectedItem.Text = "" Then


            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Requested Loan is not Valid!!!" & "');", True)
            '    drop1.Focus()
            '    Exit Sub

            'ElseIf drop2.SelectedItem.Text = "" Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Purpose of loan is not Valid!!!" & "');", True)
            '    drop2.Focus()
            '    Exit Sub
            'ElseIf drop3.SelectedItem.Text = "" Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Marketing Phrase is not Valid!!!" & "');", True)
            '    drop3.Focus()
            '    Exit Sub
            'ElseIf drop4.SelectedItem.Text = "" Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Title is not Valid!!!" & "');", True)
            '    drop4.Focus()
            '    Exit Sub
            'ElseIf Len(Trim(txtwrk.Text)) = 0 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & " Work Phone Number cannot be Blank!!!" & "');", True)
            '    txtwrk.Focus()
            '    Exit Sub
            'ElseIf Len(Trim(txtwrk.Text)) < 10 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter Valid Work Phone Number!!!" & "');", True)
            '    txtwrk.Focus()
            '    Exit Sub

            'ElseIf IsNumeric(Trim(txtwrk.Text)) = False Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter Valid Work Phone Number!!!" & "');", True)
            '    txtwrk.Focus()
            '    Exit Sub
            'ElseIf Len(Trim(txtlastname.Text)) = 0 Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter Last Name!!!" & "');", True)
            'txtlastname.Focus()
            'Exit Sub
            'ElseIf Len(Trim(txtmobile.Text)) = 0 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Mobile Phone Number cannot be Blank!!!" & "');", True)
            '    txtmobile.Focus()
            '    Exit Sub
            'ElseIf Len(Trim(txtmobile.Text)) < 10 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Mobile Phone Number is not Valid!!!" & "');", True)
            '    txtmobile.Focus()
            '    Exit Sub

            'ElseIf IsNumeric(Trim(txtmobile.Text)) = False Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter Valid Mobile Phone Number!!!" & "');", True)
            '    txtmobile.Focus()
            '    Exit Sub

            'ElseIf Len(Trim(txtgvnname.Text)) = 0 Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter Given Name!!!" & "');", True)
            'txtgvnname.Focus()
            'Exit Sub


            'ElseIf Len(Trim(txtdtbirth.Text)) = 0 Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Select Valid Date of Birth!!!" & "');", True)
            'txtdtbirth.Focus()
            'Exit Sub
            'ElseIf Len(Trim(txtEmail.Text)) = 0 Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter Valid Email!!!" & "');", True)
            'txtEmail.Focus()
            'Exit Sub

            'ElseIf drop8.SelectedItem.Text = "" Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Employment Status is not Valid!!!" & "');", True)
            'drop8.Focus()
            'Exit Sub
            'ElseIf Len(Trim(txtcmpnmemp.Text)) = 0 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Employer Company Name is not Valid!!!" & "');", True)
            '    txtcmpnmemp.Focus()
            '    Exit Sub

            'ElseIf Len(Trim(txtcnctnoemp.Text)) = 0 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Employer Contact Number is not Valid!!!" & "');", True)
            '    txtcnctnoemp.Focus()
            '    Exit Sub
            'ElseIf IsNumeric(Trim(txtcnctnoemp.Text)) = False Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Employer Contact Number is not Valid!!!" & "');", True)
            '    txtcnctnoemp.Focus()
            '    Exit Sub
            'ElseIf Len(Trim(txtcnctnoemp.Text)) < 10 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Employer Contact Number is not Valid!!!" & "');", True)
            '    txtcnctnoemp.Focus()
            '    Exit Sub

            'ElseIf Len(Trim(txtinc.Text)) = 0 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a Valid Income!!!" & "');", True)
            '    txtinc.Focus()
            '    Exit Sub
            'ElseIf IsNumeric(Trim(txtinc.Text)) = False Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a Valid Income!!!" & "');", True)
            '    txtinc.Focus()
            '    Exit Sub
            'ElseIf Len(Trim(txtinc.Text)) < 3 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a Valid Income!!!" & "');", True)
            '    txtinc.Focus()
            '    Exit Sub
            'ElseIf Len(Trim(txtcmpnmres.Text)) = 0 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Residential Company Name is not Valid!!!" & "');", True)
            '    txtcmpnmres.Focus()
            '    Exit Sub

            'ElseIf Len(Trim(txtcnctres.Text)) = 0 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Residential Contact Number is not Valid!!!" & "');", True)
            '    txtcnctres.Focus()
            '    Exit Sub
            'ElseIf Len(Trim(txtcnctres.Text)) < 10 Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Residential Contact Number is not Valid!!!" & "');", True)
            '    txtcnctres.Focus()
            '    Exit Sub
            'ElseIf IsNumeric(Trim(txtcnctres.Text)) = False Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Residential Contact Number is not Valid!!!" & "');", True)
            '    txtcnctres.Focus()
            '    Exit Sub
            'ElseIf drop1.SelectedItem.Text <> "" And drop2.SelectedItem.Text <> "" And drop3.SelectedItem.Text <> "" And drop4.SelectedItem.Text <> "" And drop8.SelectedItem.Text <> "" And Len(Trim(txtlastname.Text)) <> 0 And Len(Trim(txtwrk.Text)) <> 0 And Len(Trim(txtgvnname.Text)) <> 0 And Len(Trim(txtdtbirth.Text)) <> 0 And Len(Trim(txtmobile.Text)) <> 0 And Len(Trim(txtEmail.Text)) <> 0 And Len(Trim(txtcmpnmemp.Text)) <> 0 And Len(Trim(txtcnctnoemp.Text)) <> 0 And Len(Trim(txtcmpnmres.Text)) <> 0 And Len(Trim(txtcnctres.Text)) <> 0 Then

            'ElseIf Len(Trim(txtDLicence.Text)) <> 0 And Len(Trim(txtLicence_card_no.Text)) <> 0 And drop6.SelectedItem.Text <> "" Then
            flag_update = True
            'Else
            'If Len(Trim(txtPassport.Text)) <> 0 And drop7.SelectedItem.Text <> "" And Len(Trim(txtPlace_Of_Birth.Text)) <> 0 Then
            '    flag_update = True
            'Else
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Provide Licence Details or Passport Details!!!" & "');", True)

            ' Exit Sub
            'End If
            '
            ' End If


            'If flag_update = True Then




            '    'If Trim(txtpstcoder.Text) <> "" Then
            '    '    If IsNumeric(Trim(txtpstcoder.Text)) = False And Len(Trim(txtpstcoder.Text)) < 4 And Trim(txtpstcoder.Text) <> 0 Then
            '    '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Residential Postcode is not Valid!!!" & "');", True)
            '    '        txtpstcoder.Focus()
            '    '        Exit Sub

            '    '    ElseIf IsNumeric(Trim(txtpstcoder.Text)) = True And Len(Trim(txtpstcoder.Text)) < 4 And Trim(txtpstcoder.Text) <> 0 Then
            '    '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Residential Postcode is not Valid!!!" & "');", True)
            '    '        txtpstcoder.Focus()
            '    '        Exit Sub

            '    '    End If
            'Else

            'End If

            'If Trim(txtpstcodem.Text) <> "" Then
            '    If IsNumeric(Trim(txtpstcodem.Text)) = False And Len(Trim(txtpstcodem.Text)) < 4 And Trim(txtpstcodem.Text) <> 0 Then
            '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Mailing Postcode is not Valid!!!" & "');", True)
            '        txtpstcodem.Focus()
            '        Exit Sub
            '    ElseIf IsNumeric(Trim(txtpstcodem.Text)) = True And Len(Trim(txtpstcodem.Text)) < 4 And Trim(txtpstcodem.Text) <> 0 Then
            '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Mailing Postcode is not Valid!!!" & "');", True)
            '        txtpstcodem.Focus()
            '        Exit Sub
            '    End If
            'Else

            'End If

            'If Trim(txtyrs.Text) <> "" Then
            '    If IsNumeric(Trim(txtyrs.Text)) = False And Len(Trim(txtyrs.Text)) <> 0 Then
            '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Number of Years are not Valid!!!" & "');", True)
            '        txtyrs.Focus()
            '        Exit Sub
            '    ElseIf IsNumeric(Trim(txtyrs.Text)) = True And Len(Trim(txtyrs.Text)) <> 0 Then
            '        If Trim(txtyrs.Text) > 50 Then
            '            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Number of Years are not Valid!!!" & "');", True)
            '            txtyrs.Focus()
            '            Exit Sub
            '        End If
            '    End If
            'Else
            'End If

            'If Trim(txtmnths.Text) <> "" Then
            '    If IsNumeric(Trim(txtmnths.Text)) = False And Len(Trim(txtmnths.Text)) <> 0 Then
            '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Number of Months are not Valid!!!" & "');", True)
            '        txtmnths.Focus()
            '        Exit Sub
            '    ElseIf IsNumeric(Trim(txtmnths.Text)) = True And Len(Trim(txtmnths.Text)) <> 0 Then
            '        If Trim(txtmnths.Text) > 12 Then
            '            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Number of Months are not Valid!!!" & "');", True)
            '            txtmnths.Focus()
            '            Exit Sub
            '        End If
            '    Else

            '    End If


            'End If

            If flag_update = True Then
                If update_customer(drop4.SelectedItem.Text, Trim(txtlastname.Text), Trim(txtgvnname.Text), CDate(txtdtbirth.Text), Trim(txtHomePhone.Text), Trim(txtwrk.Text), Trim(txtmobile.Text), Trim(txtstrtnor.Text), Trim(txtstrtnmr.Text), Trim(txtsubr.Text), Trim(txtstater.Text), Trim(txtpstcoder.Text), Trim(txtstrtnom.Text), Trim(txtstrtnmm.Text), Trim(txtsubm.Text), Trim(txtstatem.Text), Trim(txtpstcodem.Text), drop5.SelectedItem.Text, drop9.SelectedItem.Text, "", "", Trim(txtlastnamesp.Text), Trim(txtgvnnamesp.Text), drop3.SelectedItem.Text, Trim(txtcmpnmemp.Text), txtattention.Text, "", "", Trim(txtempstreetname.Text), Trim(txtsub.Text), Trim(txtemppostcode.Text), "", Trim(txtcnctnoemp.Text), txtfax.Text, txt_email.Text, "", Trim(txttypbus.Text), Trim(txtpos.Text), Trim(txtEmail.Text), Trim(txtinc.Text), txtempno.Text, drop1.SelectedItem.Text, drop2.SelectedItem.Text, Trim(txtDLicence.Text), Trim(txtLicence_card_no.Text), drop6.SelectedItem.Text, Trim(txtPassport.Text), drop7.SelectedItem.Text, Trim(txtPlace_Of_Birth.Text), Trim(txtunitnor.Text), Trim(txtunitnom.Text), drop8.SelectedItem.Text, Trim(txtyrs.Text), Trim(txtmnths.Text), Trim(txtcmpnmres.Text), Trim(txtcnctres.Text), CDate(date_updated), DropDownList1.SelectedItem.Text, txthousehold.Text, txtrentmortgage.Text, txtrepay.Text, txtfood.Text, txtothers.Text, txtuti.Text, txtragency.Text, txtled.Text) = True Then

                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Record Updated!!!" & "');", True)

                End If

            End If

            'End If

        Catch ex As Exception

            Response.Write("Error: " & ex.Message)
        End Try

    End Sub

    Protected Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

        RadioButton2.Checked = False
        txtDLicence.Enabled = True
        txtLicence_card_no.Enabled = True
        drop6.Enabled = True
        drop7.Enabled = False
        txtPassport.Enabled = False
        txtPlace_Of_Birth.Enabled = False
        drop7.SelectedItem.Text = ""
        txtPassport.Text = ""
        txtPlace_Of_Birth.Text = ""

    End Sub

    Protected Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        txtDLicence.Text = ""
        txtLicence_card_no.Text = ""
        drop6.SelectedItem.Text = ""
        RadioButton1.Checked = False
        drop7.Enabled = True
        txtPassport.Enabled = True
        txtPlace_Of_Birth.Enabled = True
        txtDLicence.Enabled = False
        txtLicence_card_no.Enabled = False
        drop6.Enabled = False
    End Sub
    Protected Sub txtdtbirth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdtbirth.TextChanged

        txtdtbirth.Attributes.Add("onkeydown", "return (event.keyCode!=13);")
        txtEmail.Focus()

    End Sub
    Public Function update_customer(ByVal title As String, ByVal last_name As String, ByVal given_name As String, ByVal date_of_birth As Date, ByVal home_phone As String, ByVal work_phone As String, ByVal mobile_phone As String, ByVal street_number As String, ByVal street_name As String, ByVal suburb As String, ByVal state As String, ByVal post_code As String, ByVal m_address As String, ByVal m_street_name As String, ByVal m_suburb As String, ByVal m_state As String, ByVal m_post_code As String, ByVal marital_status As String, ByVal residential_status As String, ByVal joint_borrowing As String, ByVal relationship As String, ByVal r_last_name As String, ByVal r_given_name As String, ByVal marketing_text As String, ByVal employer As String, ByVal e_contact_person As String, ByVal e_street_number As String, ByVal e_building As String, ByVal e_street_name As String, ByVal e_suburb As String, ByVal e_post_code As String, ByVal e_state As String, ByVal e_phone_number As String, ByVal e_fax_number As String, ByVal e_email As String, ByVal payroll_transfer As String, ByVal business As String, ByVal position As String, ByVal email As String, ByVal income As String, ByVal employee_no As String, ByVal request_amount As String, ByVal purpose_loan As String, ByVal d_licence As String, ByVal Licence_card_no As String, ByVal d_state As String, ByVal passport As String, ByVal countries As String, ByVal Place_Of_Birth As String, ByVal unit_no As String, ByVal m_unit_no As String, ByVal emp_status As String, ByVal emp_year As String, ByVal emp_mths As String, ByVal agent As String, ByVal agent_no As String, ByVal date_updated As String, ByVal sal_p As String, ByVal txthousehold As String, ByVal txtrent As String, ByVal txtrepay As String, ByVal txtfood As String, ByVal txtother As String, ByVal txtuti As String, ByVal R_Agency_Name As String, ByVal Licence_Expiry_Date As String) As Boolean


        Dim cmd As New SqlCommand
        cmd.CommandText = "Update Tbl_Customer set Title=@title,Last_Name=@last_name,Given_Name=@given_name,Date_of_Birth=@date_of_birth,Home_Phone=@home_phone,Work_Phone=@work_phone,Mobile_Phone=@mobile_phone,Street_Number=@street_number,Street_Name=@street_name,Suburb=@suburb,State=@state,Post_Code=@post_code,M_Address= @m_address ,M_Street_Name=@m_street_name,M_Suburb=@m_suburb ,M_State=@m_state,M_Post_Code=@m_post_code,Marital_Status=@marital_status,Residential_Status=@residential_status,Joint_Borrowing=@joint_borrowing,Relationship=@relationship ,R_Last_Name=@r_last_name,R_Given_Name=@r_given_name,Marketing_Text=@marketing_text,Employer=@employer,E_Contact_Person=@e_contact_person,E_Street_Number=@e_street_number,E_Building=@e_building,E_Street_Name=@e_street_name,E_Suburb=@e_suburb,E_Post_Code=@e_post_code,E_State=@e_state,E_Phone_Number= @e_phone_number,E_Fax_Number= @e_fax_number,E_Email=@e_email,Payroll_Transfer=@payroll_transfer,Business=@business,Position=@position,Email=@email,Income=@income,Employee_no=@employee_no,Request_Amount=@request_amount,Purpose_Loan=@purpose_loan,D_Licence=@d_licence ,Licence_card_no=@Licence_card_no ,D_State=@d_state,Passport=@passport,Countries=@countries,Place_Of_Birth=@Place_Of_Birth,Unit_No=@unit_no,M_Unit_No=@m_unit_no,Emp_Status=@emp_status,Emp_Year=@emp_year,Emp_Mths=@emp_mths,Agent=@agent,Agent_No=@agent_no,Date_Updated=@date_updated,Employee_Salary_Period=@sal_p,Monthly_Household=@txthousehold,Rent_Mortgage=@txtrent,Loan_Repayment=@txtrepay,Monthly_Food=@txtfood,Monthly_Others=@txtothers,Monthly_Utilities=@txtuti,R_Agency_Name=@R_Agency_Name,Licence_Expiry_Date=@Licence_Expiry_Date where customer_id=@customer_id"
        cmd.Connection = open_con.return_con
        cmd.Parameters.Add("@title", Data.SqlDbType.VarChar, 255).Value = title
        cmd.Parameters.Add("@last_name", Data.SqlDbType.VarChar, 255).Value = last_name
        cmd.Parameters.Add("@given_name", Data.SqlDbType.VarChar, 255).Value = given_name
        Dim date_count As Integer
        date_count = DateTime.Now.Year - date_of_birth.Year
        If date_count < 18 Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Date of Birth is not Valid!!!" & "');", True)

            update_customer = False

            Exit Function
        Else
            cmd.Parameters.Add("@date_of_birth", Data.SqlDbType.Date).Value = date_of_birth
        End If

        cmd.Parameters.Add("@home_phone", Data.SqlDbType.VarChar, 255).Value = home_phone
        cmd.Parameters.Add("@work_phone", Data.SqlDbType.VarChar, 255).Value = work_phone
        cmd.Parameters.Add("@mobile_phone", Data.SqlDbType.VarChar, 255).Value = mobile_phone
        cmd.Parameters.Add("@street_number", Data.SqlDbType.VarChar, 255).Value = street_number
        cmd.Parameters.Add("@street_name", Data.SqlDbType.VarChar, 255).Value = street_name
        cmd.Parameters.Add("@suburb", Data.SqlDbType.VarChar, 255).Value = suburb
        cmd.Parameters.Add("@state", Data.SqlDbType.VarChar, 255).Value = state

        If post_code = "" Then
            post_code = 0

        End If
        If e_post_code = "" Then
            e_post_code = 0

        End If


        cmd.Parameters.Add("@post_code", Data.SqlDbType.VarChar, 255).Value = post_code
        cmd.Parameters.Add("@m_address ", Data.SqlDbType.VarChar, 255).Value = m_address
        cmd.Parameters.Add("@m_street_name ", Data.SqlDbType.VarChar, 255).Value = m_street_name
        cmd.Parameters.Add("@m_suburb", Data.SqlDbType.VarChar, 255).Value = m_suburb
        cmd.Parameters.Add("@m_state", Data.SqlDbType.VarChar, 255).Value = m_state
        cmd.Parameters.Add("@m_post_code", Data.SqlDbType.VarChar, 255).Value = m_post_code
        cmd.Parameters.Add("@marital_status ", Data.SqlDbType.VarChar, 255).Value = marital_status
        cmd.Parameters.Add("@residential_status ", Data.SqlDbType.VarChar, 255).Value = residential_status
        cmd.Parameters.Add("@joint_borrowing", Data.SqlDbType.VarChar, 255).Value = ""
        cmd.Parameters.Add("@relationship", Data.SqlDbType.VarChar, 255).Value = ""
        cmd.Parameters.Add("@r_last_name", Data.SqlDbType.VarChar, 255).Value = r_last_name
        cmd.Parameters.Add("@r_given_name", Data.SqlDbType.VarChar, 255).Value = r_given_name
        cmd.Parameters.Add("@marketing_text ", Data.SqlDbType.VarChar, 255).Value = marketing_text
        cmd.Parameters.Add("@employer", Data.SqlDbType.VarChar, 255).Value = employer
        cmd.Parameters.Add("@e_contact_person", Data.SqlDbType.VarChar, 255).Value = e_contact_person
        cmd.Parameters.Add("@e_street_number", Data.SqlDbType.VarChar, 255).Value = e_street_number
        cmd.Parameters.Add("@e_building", Data.SqlDbType.VarChar, 255).Value = e_building
        cmd.Parameters.Add("@e_street_name ", Data.SqlDbType.VarChar, 255).Value = e_street_name
        cmd.Parameters.Add("@e_suburb", Data.SqlDbType.VarChar, 255).Value = e_suburb
        cmd.Parameters.Add("@e_post_code", Data.SqlDbType.VarChar, 255).Value = e_post_code
        cmd.Parameters.Add("@e_state", Data.SqlDbType.VarChar, 255).Value = e_state
        cmd.Parameters.Add("@e_phone_number", Data.SqlDbType.VarChar, 255).Value = e_phone_number
        cmd.Parameters.Add("@e_fax_number", Data.SqlDbType.VarChar, 255).Value = e_fax_number
        cmd.Parameters.Add("@e_email", Data.SqlDbType.VarChar, 255).Value = e_email
        cmd.Parameters.Add("@payroll_transfer", Data.SqlDbType.VarChar, 255).Value = payroll_transfer

        cmd.Parameters.Add("@business", Data.SqlDbType.VarChar, 255).Value = business
        cmd.Parameters.Add("@position", Data.SqlDbType.VarChar, 255).Value = position
        cmd.Parameters.Add("@email", Data.SqlDbType.VarChar, 255).Value = email
        cmd.Parameters.Add("@income", Data.SqlDbType.VarChar, 255).Value = income
        cmd.Parameters.Add("@employee_no ", Data.SqlDbType.VarChar, 255).Value = employee_no
        Dim request_amount1 As Integer

        Dim i As Integer
        i = Len(request_amount)
        request_amount1 = Mid(request_amount, 1)

        cmd.Parameters.Add("@request_amount", Data.SqlDbType.Int).Value = request_amount1
        cmd.Parameters.Add("@purpose_loan", Data.SqlDbType.VarChar, 255).Value = purpose_loan
        cmd.Parameters.Add("@d_licence", Data.SqlDbType.VarChar, 255).Value = d_licence
        cmd.Parameters.Add("@Licence_card_no", Data.SqlDbType.VarChar, 255).Value = Licence_card_no
        cmd.Parameters.Add("@d_state", Data.SqlDbType.VarChar, 255).Value = d_state
        cmd.Parameters.Add("@passport", Data.SqlDbType.VarChar, 255).Value = passport
        cmd.Parameters.Add("@countries", Data.SqlDbType.VarChar, 255).Value = countries
        cmd.Parameters.Add("@Place_Of_Birth", Data.SqlDbType.VarChar, 255).Value = Place_Of_Birth
        cmd.Parameters.Add("@unit_no", Data.SqlDbType.VarChar, 255).Value = unit_no
        cmd.Parameters.Add("@m_unit_no", Data.SqlDbType.VarChar, 255).Value = m_unit_no
        cmd.Parameters.Add("@emp_status", Data.SqlDbType.VarChar, 255).Value = emp_status
        cmd.Parameters.Add("@emp_year", Data.SqlDbType.VarChar, 255).Value = emp_year
        cmd.Parameters.Add("@emp_mths", Data.SqlDbType.VarChar, 255).Value = emp_mths
        cmd.Parameters.Add("@agent", Data.SqlDbType.VarChar, 255).Value = agent
        cmd.Parameters.Add("@agent_no", Data.SqlDbType.VarChar, 255).Value = agent_no
        cmd.Parameters.Add("@date_updated", Data.SqlDbType.VarChar, 50).Value = System.DateTime.Now.Date.ToString("yyyy-MM-dd")
        cmd.Parameters.Add("@sal_p", Data.SqlDbType.VarChar, 255).Value = DropDownList1.SelectedItem.Text
        'cmd.Parameters.Add("@curbank", Data.SqlDbType.VarChar, 255).Value = ""
        'cmd.Parameters.Add("@other_doc", Data.SqlDbType.VarChar, 255).Value = ""
        'cmd.Parameters.Add("@bankst_bit", Data.SqlDbType.VarChar, 255).Value = 0
        'cmd.Parameters.Add("@otherdoc_bit", Data.SqlDbType.VarChar, 255).Value = 0
        cmd.Parameters.Add("@txthousehold", Data.SqlDbType.VarChar, 255).Value = txthousehold
        cmd.Parameters.Add("@txtrent", Data.SqlDbType.VarChar, 255).Value = txtrent
        cmd.Parameters.Add("@txtrepay", Data.SqlDbType.VarChar, 255).Value = txtrepay
        cmd.Parameters.Add("@txtfood", Data.SqlDbType.VarChar, 255).Value = txtfood
        cmd.Parameters.Add("@txtothers", Data.SqlDbType.VarChar, 50).Value = txtother
        cmd.Parameters.Add("@txtuti", Data.SqlDbType.VarChar, 50).Value = txtuti
        cmd.Parameters.Add("@customer_id", Data.SqlDbType.Int).Value = open_con.customer_id_val
        cmd.Parameters.Add("@R_Agency_Name", Data.SqlDbType.VarChar, 255).Value = txtragency.Text
        cmd.Parameters.Add("@emp_postcode", Data.SqlDbType.VarChar, 255).Value = txtemppostcode.Text
        If txtled.Text <> "" Then
            txtled.Text = CDate(txtled.Text).ToString("yyyy-MM-dd")
        Else
            txtled.Text = ""
        End If
        cmd.Parameters.Add("@Licence_Expiry_Date", Data.SqlDbType.VarChar, 255).Value = txtled.Text
        cmd.ExecuteNonQuery()
        update_customer = True
        Session("Customer_name") = given_name & " " & last_name & " " & Session("branch_prefix") & " " & open_con.customer_id_val
        Session("Customer_namebank") = given_name & " " & last_name
        cmd.Dispose()
        open_con.return_con.Dispose()


    End Function

  
    Protected Sub Print_btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Print_btn.Click
        Dim cmd As New SqlCommand
        cmd.CommandText = "Update Tbl_Customer set cust_enable =1 where customer_id=@customer_id"
        cmd.Parameters.Add("@customer_id", Data.SqlDbType.Int).Value = open_con.customer_id_val
        cmd.Connection = open_con.return_con
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        open_con.return_con.Dispose()
        Response.Redirect("Customer_form.aspx", False)
    End Sub

    Protected Sub drop6_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drop6.SelectedIndexChanged
        If drop6.SelectedItem.Text = "WA" Then
            txtled.Visible = True
            Label1.Visible = True

        Else
            txtled.Visible = False
            Label1.Visible = False
            txtled.Text = ""
        End If
    End Sub
    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub
End Class
