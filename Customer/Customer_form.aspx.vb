Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Partial Class Customer_Customer_form
    Inherits System.Web.UI.Page

    Dim sav As New Class1
    Dim flag_upd As Boolean
    Dim open_con As New Class1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try
                If Not Page.IsPostBack Then

                    txtDLicence.Enabled = False
                    txtLicence_card_no.Enabled = False
                    drop6.Enabled = False
                    drop7.Enabled = False
                    txtPassport.Enabled = False
                    txtPlace_Of_Birth.Enabled = False

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
                    'txtlastnamesp.Text = ds_update.Tables(0).Rows(0).Item("R_Last_Name").ToString
                    'txtgvnnamesp.Text = ds_update.Tables(0).Rows(0).Item("R_Given_Name").ToString
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

End Class
