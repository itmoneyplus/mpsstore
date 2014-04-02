Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports System.Globalization
Imports System.Net
Imports System.IO
Partial Class Customer_ExistingUser
    Inherits System.Web.UI.Page
    Dim open_con As New Class1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            If Page.IsPostBack = False Then
                View_Existing_User()
            End If
        End If
    End Sub
    Sub chkAdmin()
        If clsGeneral.ChkAdmin() = True Then
            Link_Administration.Visible = True
        Else
            Link_Administration.Visible = False

        End If
    End Sub

    Sub View_Existing_User()
        Using obj As New clsReport()
            Dim ds As DataSet = obj.getNames()

            If ds.Tables(0).Rows.Count > 0 Then
                grdExistingUser.DataSource = ds
                grdExistingUser.DataBind()
                pnlExistingUser.Visible = True
            End If
        End Using
        pnlEditUser.Visible = False
    End Sub

    Protected Sub grdExistingUser_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdExistingUser.RowCommand
        If e.CommandName = "deleteUser" Then
            Dim UserID As String = e.CommandArgument
            Using obj As New clsUser()
                obj.deleteUser(UserID)
                View_Existing_User()
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "User deleted successfully!!!" & "');", True)
            End Using            
        ElseIf e.CommandName = "editUser" Then
            Dim UserID As String = e.CommandArgument
            Dim BranchID As Integer
            Using obj As New clsUser()
                Dim ds As DataSet = obj.getUser(UserID)
                hdnUserID.Value = ds.Tables(0).Rows(0).Item("User_ID").ToString()
                txtGivenName.Text = ds.Tables(0).Rows(0).Item("Given_Name").ToString()
                txtLastName.Text = ds.Tables(0).Rows(0).Item("Last_Name").ToString()
                txtLoginName.Text = ds.Tables(0).Rows(0).Item("Logon_ID").ToString()
                txtPassword.Text = ds.Tables(0).Rows(0).Item("Password").ToString()
                ddlUserType.SelectedItem.Text = ds.Tables(0).Rows(0).Item("User_Type").ToString()
                BranchID = ds.Tables(0).Rows(0).Item("Branch_ID")
            End Using
            bindBranch(BranchID)

            pnlEditUser.Visible = True
            pnlExistingUser.Visible = False
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "User updated successfully!!!" & "');", True)
        End If
    End Sub
    Private Sub bindBranch(ByVal BranchID As Integer)
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
                ddlBranch.SelectedValue = BranchID.ToString

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
                query = "UPDATE sys_User SET Branch_ID=@Brabnch_ID ,Given_Name=@givenName, Last_Name=@lastName, Logon_ID=@loginID, Password=@password, User_Type=@userType WHERE User_ID=@userID"
                cmd.Connection = open_con.return_con
                cmd.CommandText = query
                cmd.Parameters.Add("@Brabnch_ID", SqlDbType.Int).Value = Convert.ToInt32(ddlBranch.SelectedValue)
                cmd.Parameters.Add("@givenName", SqlDbType.VarChar, 50).Value = txtGivenName.Text
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar, 50).Value = txtLastName.Text
                cmd.Parameters.Add("@loginID", SqlDbType.VarChar, 50).Value = txtLoginName.Text
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = txtPassword.Text
                cmd.Parameters.Add("@userType", SqlDbType.VarChar, 50).Value = ddlUserType.SelectedItem.Text
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = Convert.ToInt32(hdnUserID.Value)

                cmd.ExecuteNonQuery()
                cmd.Dispose()
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "User edited successfully!!!" & "');", True)                
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub

    Protected Sub btnGoBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGoBack.Click
        View_Existing_User()
    End Sub
End Class
