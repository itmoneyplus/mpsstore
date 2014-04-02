
Partial Class Customer_Personal_Form
    Inherits System.Web.UI.Page
    Dim sav As New Class1

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

        If Not Page.IsPostBack Then

            txtDLicence.Enabled = True
            txtLicence_card_no.Enabled = True
            drop6.Enabled = True
            drop7.Enabled = False
            txtPassport.Enabled = False
            txtPlace_Of_Birth.Enabled = False

        End If

    End Sub
    Sub chkAdmin()
        If clsGeneral.ChkAdmin() = True Then
            Link_Administration.Visible = True
        Else
            Link_Administration.Visible = False

        End If
    End Sub

    Protected Sub Save_btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Save_btn.Click

        Dim time_joined As String
        Dim date_joined As date
        Dim flag_save As Boolean = False
        time_joined = System.DateTime.Now.TimeOfDay.ToString
        date_joined = System.DateTime.Now.Date.ToString

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
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Employer Company Name is not Valid!!!" & "');", True)
            'txtcmpnmemp.Focus()
            'Exit Sub

            'ElseIf Len(Trim(txtcnctnoemp.Text)) = 0 Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Employer Contact Number is not Valid!!!" & "');", True)
            'txtcnctnoemp.Focus()
            'Exit Sub
            'ElseIf IsNumeric(Trim(txtcnctnoemp.Text)) = False Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Employer Contact Number is not Valid!!!" & "');", True)
            'txtcnctnoemp.Focus()
            'Exit Sub
            ''ElseIf Len(Trim(txtcnctnoemp.Text)) < 10 Then
            ''    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Employer Contact Number is not Valid!!!" & "');", True)
            ''    txtcnctnoemp.Focus()
            ''    Exit Sub

            'ElseIf Len(Trim(txtinc.Text)) = 0 Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a Valid Income!!!" & "');", True)
            'txtinc.Focus()
            'Exit Sub
            'ElseIf IsNumeric(Trim(txtinc.Text)) = False Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a Valid Income!!!" & "');", True)
            'txtinc.Focus()
            'Exit Sub
            'ElseIf Len(Trim(txtinc.Text)) < 3 Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a Valid Income!!!" & "');", True)
            'txtinc.Focus()
            'Exit Sub
            'ElseIf Len(Trim(txtcmpnmres.Text)) = 0 Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Residential Company Name is not Valid!!!" & "');", True)
            'txtcmpnmres.Focus()
            'Exit Sub

            'ElseIf Len(Trim(txtcnctres.Text)) = 0 Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Residential Contact Number is not Valid!!!" & "');", True)
            'txtcnctres.Focus()
            'Exit Sub
            ''ElseIf Len(Trim(txtcnctres.Text)) < 10 Then
            ''    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Residential Contact Number is not Valid!!!" & "');", True)
            ''    txtcnctres.Focus()
            ''    Exit Sub
            'ElseIf IsNumeric(Trim(txtcnctres.Text)) = False Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Residential Contact Number is not Valid!!!" & "');", True)
            'txtcnctres.Focus()
            'Exit Sub
            'Else
            'If drop1.SelectedItem.Text <> "" And drop2.SelectedItem.Text <> "" And drop3.SelectedItem.Text <> "" And drop4.SelectedItem.Text <> "" And drop8.SelectedItem.Text <> "" And Len(txtlastname.Text) <> 0 And Len(txtwrk.Text) <> 0 And Len(txtmobile.Text) <> 0 And Len(txtgvnname.Text) <> 0 And Len(txtdtbirth.Text) <> 0 And Len(txtEmail.Text) <> 0 And Len(txtcmpnmemp.Text) <> 0 And Len(txtcnctnoemp.Text) <> 0 And Len(txtcmpnmres.Text) <> 0 And Len(txtcnctres.Text) <> 0 Then

            'If Len(txtDLicence.Text) <> 0 And Len(txtLicence_card_no.Text) <> 0 And drop6.SelectedItem.Text <> "" Then
            flag_save = True
            'Else
            'If Len(txtPassport.Text) <> 0 And drop7.SelectedItem.Text <> "" And Len(txtPlace_Of_Birth.Text) <> 0 Then
            '    flag_save = True
            'Else
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Provide Licence Details or Passport Details!!!" & "');", True)

            '    Exit Sub
            'End If

            'End If
            'End If
            'End If

            'If flag_save = True Then

            '    'If Trim(txtHomePhone.Text) <> "" Then
            '    '    If IsNumeric(Trim(txtHomePhone.Text)) = False And Len(Trim(txtHomePhone.Text)) < 10 Then
            '    '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a Valid Home Phone Number!!!" & "');", True)
            '    '        txtHomePhone.Focus()
            '    '        Exit Sub
            '    '    ElseIf IsNumeric(Trim(txtHomePhone.Text)) = True And Len(Trim(txtHomePhone.Text)) < 10 Then
            '    '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a Valid Home Phone Number!!!" & "');", True)
            '    '        txtHomePhone.Focus()
            '    '        Exit Sub

            '    '    End If
            'Else

            'End If


            'If Trim(txtpstcoder.Text) <> "" Then
            '    If IsNumeric(Trim(txtpstcoder.Text)) = False And Len(Trim(txtpstcoder.Text)) < 4 Then
            '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Residential Postcode is not Valid!!!" & "');", True)
            '        txtpstcoder.Focus()
            '        Exit Sub

            '    ElseIf IsNumeric(Trim(txtpstcoder.Text)) = True And Len(Trim(txtpstcoder.Text)) < 4 Then
            '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Residential Postcode is not Valid!!!" & "');", True)
            '        txtpstcoder.Focus()
            '        Exit Sub

            '    End If
            'Else

            'End If

            'If txtpstcodem.Text <> "" Then
            '    If IsNumeric(txtpstcodem.Text) = False And Len(txtpstcodem.Text) < 4 Then
            '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Mailing Postcode is not Valid!!!" & "');", True)
            '        txtpstcodem.Focus()
            '        Exit Sub
            '    ElseIf IsNumeric(Trim(txtpstcodem.Text)) = True And Len(Trim(txtpstcodem.Text)) < 4 Then
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
            '        If txtyrs.Text > 50 Then
            '            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Number of Years are not Valid!!!" & "');", True)
            '            txtyrs.Focus()
            '            Exit Sub
            '        End If
            '    End If
            'Else
            'End If

            'If txtmnths.Text <> "" Then
            '    If IsNumeric(Trim(txtmnths.Text)) = False And Len(Trim(txtmnths.Text)) <> 0 Then
            '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Number of Months are not Valid!!!" & "');", True)
            '        txtmnths.Focus()
            '        Exit Sub
            '    ElseIf IsNumeric(Trim(txtmnths.Text)) = True And Len(Trim(txtmnths.Text)) <> 0 Then
            '        If txtmnths.Text > 12 Then
            '            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Number of Months are not Valid!!!" & "');", True)
            '            txtmnths.Focus()
            '            Exit Sub
            '        End If
            '    Else

            '    End If

            'End If


            If sav.Check_Records(Trim(txtlastname.Text), Trim(txtgvnname.Text), CDate(txtdtbirth.Text)) = False Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Customer already exist in the Database!!!" & "');", True)

            Else


                If sav.save_customer(drop4.SelectedItem.Text, Trim(txtlastname.Text), Trim(txtgvnname.Text), CDate(txtdtbirth.Text), Trim(txtHomePhone.Text), Trim(txtwrk.Text), Trim(txtmobile.Text), Trim(txtstrtnor.Text), Trim(txtstrtnmr.Text), Trim(txtsubr.Text), Trim(txtstater.Text), Trim(txtpstcoder.Text), Trim(txtstrtnom.Text), Trim(txtstrtnmm.Text), Trim(txtsubm.Text), Trim(txtstatem.Text), Trim(txtpstcodem.Text), drop5.SelectedItem.Text, drop9.SelectedItem.Text, "", "", Trim(txtlastnamesp.Text), Trim(txtgvnnamesp.Text), drop3.SelectedItem.Text, Trim(txtcmpnmemp.Text), "", "", "", "", Trim(txtsub.Text), "", 0, Trim(txtcnctnoemp.Text), "", "", "", 0, "", Trim(txttypbus.Text), Trim(txtpos.Text), Trim(txtEmail.Text), Trim(txtinc.Text), "", drop1.SelectedItem.Text, drop2.SelectedItem.Text, Trim(txtDLicence.Text), Trim(txtLicence_card_no.Text), drop6.SelectedItem.Text, Trim(txtPassport.Text), drop7.SelectedItem.Text, Trim(txtPlace_Of_Birth.Text), Trim(txtunitnor.Text), Trim(txtunitnom.Text), drop8.SelectedItem.Text, Trim(txtyrs.Text), Trim(txtmnths.Text), Trim(txtcmpnmres.Text), Trim(txtcnctres.Text), time_joined, CDate(date_joined), "") = True Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Record Saved!!!" & "');", True)
                    drop4.SelectedIndex = 0
                    txtlastname.Text = ""
                    txtgvnname.Text = ""
                    txtdtbirth.Text = ""
                    txtHomePhone.Text = ""
                    txtwrk.Text = ""
                    txtmobile.Text = ""
                    txtstrtnor.Text = ""
                    txtstrtnmr.Text = ""
                    txtsubr.Text = ""
                    txtstater.Text = ""
                    txtpstcoder.Text = ""
                    txtstrtnom.Text = ""
                    txtstrtnmm.Text = ""
                    txtsubm.Text = ""
                    txtstatem.Text = ""
                    txtpstcodem.Text = ""
                    drop5.SelectedIndex = 0
                    drop9.SelectedIndex = 0
                    txtlastnamesp.Text = ""
                    txtgvnnamesp.Text = ""
                    drop3.SelectedIndex = 0
                    txtcmpnmemp.Text = ""
                    txtsub.Text = ""
                    txtcnctnoemp.Text = ""
                    txttypbus.Text = ""
                    txtpos.Text = ""
                    txtEmail.Text = ""
                    txtinc.Text = ""
                    drop1.SelectedIndex = 0
                    drop2.SelectedIndex = 0
                    txtDLicence.Text = ""
                    txtLicence_card_no.Text = ""
                    drop6.SelectedIndex = 0
                    txtPassport.Text = ""
                    drop7.SelectedIndex = 0
                    txtPlace_Of_Birth.Text = ""
                    txtunitnor.Text = ""
                    txtunitnom.Text = ""
                    drop8.SelectedIndex = 0
                    txtyrs.Text = ""
                    txtmnths.Text = ""
                    txtcmpnmres.Text = ""
                    txtcnctres.Text = ""
                Else
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Date of Birth is not Valid!!!" & "');", True)
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

    Protected Sub txtwrk_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwrk.PreRender
        txtwrk.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtlastname.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub
    Protected Sub txtlastname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlastname.PreRender
        txtlastname.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtHomePhone.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub
    Protected Sub txtHomePhone_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHomePhone.PreRender
        txtHomePhone.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtgvnname.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtgvnname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgvnname.PreRender
        txtgvnname.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtmobile.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtmobile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmobile.PreRender
        txtmobile.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtdtbirth.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtdtbirth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdtbirth.PreRender

        txtdtbirth.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtEmail.UniqueID + "').focus();return false;}} else {return true}; ")

    End Sub

    Protected Sub txtEmail_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmail.PreRender
        txtEmail.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtlastnamesp.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

   
    Protected Sub txtlastnamesp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlastnamesp.PreRender
        txtlastnamesp.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtgvnnamesp.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtDLicence_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDLicence.PreRender
        txtDLicence.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtLicence_card_no.UniqueID + "').focus();return false;}} else {return true}; ")

    End Sub

    Protected Sub txtLicence_card_no_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLicence_card_no.PreRender
        txtLicence_card_no.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtunitnor.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtgvnnamesp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgvnnamesp.PreRender
        txtgvnnamesp.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtDLicence.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub
    Protected Sub txtunitnor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtunitnor.PreRender

        txtunitnor.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtunitnom.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtunitnom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtunitnom.PreRender
        txtunitnom.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtstrtnor.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub
    Protected Sub txtstrtnor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstrtnor.PreRender
        txtstrtnor.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtstrtnom.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtstrtnom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstrtnom.PreRender
        txtstrtnom.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtstrtnmr.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtstrtnmr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstrtnmr.PreRender
        txtstrtnmr.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtstrtnmm.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtstrtnmm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstrtnmm.PreRender
        txtstrtnmm.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtsubr.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtsubr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsubr.PreRender
        txtsubr.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtsubm.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtsubm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsubm.PreRender
        txtsubm.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtpstcoder.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtpstcoder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpstcoder.PreRender
        txtpstcoder.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtpstcodem.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtpstcodem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpstcodem.PreRender
        txtpstcodem.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtstater.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtstater_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstater.PreRender
        txtstater.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtstatem.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtstatem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstatem.PreRender
        txtstatem.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtcmpnmemp.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtcmpnmemp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcmpnmemp.PreRender
        txtcmpnmemp.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txttypbus.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txttypbus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttypbus.PreRender
        txttypbus.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtcnctnoemp.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtcnctnoemp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcnctnoemp.PreRender
        txtcnctnoemp.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtsub.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtsub_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsub.PreRender
        txtsub.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtyrs.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtyrs_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtyrs.PreRender
        txtyrs.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtmnths.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtmnths_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmnths.PreRender
        txtmnths.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtpos.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtpos_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpos.PreRender
        txtpos.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtinc.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtinc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinc.PreRender
        txtinc.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtcmpnmres.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtcmpnmres_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcmpnmres.PreRender
        txtcmpnmres.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtcnctres.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtcnctres_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcnctres.PreRender
        txtcnctres.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Save_btn.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtPassport_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassport.PreRender
        txtPassport.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtPlace_Of_Birth.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub txtPlace_Of_Birth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlace_Of_Birth.PreRender
        txtPlace_Of_Birth.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + txtunitnor.UniqueID + "').focus();return false;}} else {return true}; ")
    End Sub

    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub

End Class
