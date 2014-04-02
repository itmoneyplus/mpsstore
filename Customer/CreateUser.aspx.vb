Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Net
Partial Class Customer_CreateUser
    Inherits System.Web.UI.Page
    Dim open_con As New Class1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            bindBranch()
        End If
    End Sub
    Sub chkAdmin()
        If clsGeneral.ChkAdmin() = True Then
            Link_Administration.Visible = True
        Else
            Link_Administration.Visible = False

        End If
    End Sub
    Private Sub bindBranch()
        Try
            Dim cmd_document As New SqlCommand
            Dim str_document As String
            str_document = " SELECT * FROM sys_Branch order by Suburb "
            cmd_document.Connection = open_con.return_con
            cmd_document.CommandText = str_document
            cmd_document.ExecuteNonQuery()
            Dim adap_document As SqlDataAdapter
            adap_document = New SqlDataAdapter(cmd_document)
            Dim ds_document As New DataSet
            adap_document.Fill(ds_document)

            If ds_document.Tables(0).Rows.Count > 0 Then

                ddlBranch.DataSource = ds_document
                ddlBranch.DataValueField = "Branch_ID"
                ddlBranch.DataTextField = "Trading_Name" '& " - " & "Suburb"
                ddlBranch.DataBind()
                ddlBranch.SelectedIndex = 1

            End If
            open_con.return_con.Dispose()
            cmd_document.Dispose()
            adap_document.Dispose()
            ds_document.Dispose()
           

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtGivenName.Text = "" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter Given Name!!!" & "');", True)
                Exit Sub
            ElseIf txtLastName.Text = "" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter Last Name!!!" & "');", True)
                Exit Sub
            ElseIf txtLoginName.Text = "" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter Login Name!!!" & "');", True)
                Exit Sub
            ElseIf txtPassword.Text = "" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter Password!!!" & "');", True)
                Exit Sub
                'ElseIf txtConfirmPassword.Text = "" Then
                '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter Confirm Password!!!" & "');", True)
                '    Exit Sub
                'ElseIf Not (String.Compare(txtPassword.Text, txtConfirmPassword.Text) = 0) Then
                '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Passwords do not match!!!" & "');", True)
                '    Exit Sub
            Else
                Dim cmd As New SqlCommand
                Dim query As String
                'query = "INSERT INTO sys_User (Branch_ID, Given_Name, Last_Name, Logon_ID, Password, User_Type, FirstTime_Login) VALUES (26, @givenName, @lastName, @loginID, @password, @userType, 0)"
                query = "INSERT INTO sys_User (Branch_ID, Given_Name, Last_Name, Logon_ID, Password, User_Type, FirstTime_Login) VALUES (@branchID, @givenName, @lastName, @loginID, @password, @userType, 0)"
                cmd.Connection = open_con.return_con
                cmd.CommandText = query
                cmd.Parameters.Add("@branchID", SqlDbType.Int).Value = Convert.ToInt32(ddlBranch.SelectedValue)
                cmd.Parameters.Add("@givenName", SqlDbType.VarChar, 50).Value = txtGivenName.Text
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar, 50).Value = txtLastName.Text
                cmd.Parameters.Add("@loginID", SqlDbType.VarChar, 50).Value = txtLoginName.Text
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = txtPassword.Text
                cmd.Parameters.Add("@userType", SqlDbType.VarChar, 50).Value = ddlUserType.SelectedItem.Text
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "User Created!!!" & "');", True)

                txtGivenName.Text = ""
                txtLastName.Text = ""
                txtLoginName.Text = ""
                txtPassword.Text = ""
                Response.Redirect("ExistingUser.aspx")
            End If

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
End Class
