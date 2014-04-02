Imports Class1
Imports System.Data.SqlClient
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim open_con As New Class1

    Protected Sub btnLogon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogon.Click
        Try

       
            If open_con.connect_con() = True Then

                If open_con.validate_input(txtLogonID.Text, txtPassword.Text) = True Then
                    Session("user_id") = open_con.getuserid(txtLogonID.Text, txtPassword.Text)
                    open_con.user_id_val = Session("user_id")
                    Session("user_name") = open_con.user_name(Session("user_id"))
                    getbranchprefix(txtLogonID.Text, txtPassword.Text)
                    bindLoginTrack()
                    FormsAuthentication.RedirectFromLoginPage(Session("user_name"), False)
                    Response.Redirect("Customer/default.aspx")
                Else
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Invalid UserName or Password!!!" & "');", True)
                End If
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Error in Connecting to server!!!!" & "');", True)


            End If
          
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
        End Try
    End Sub
    Private Sub bindLoginTrack()
        Try
            Using obj As New clsUser()
                obj.ChkLoginTrack(Integer.Parse(Session("user_id")), open_con.GetIP4Address())
            End Using
        Catch ex As Exception
            FormsAuthentication.SignOut()
            Session.Abandon()
            '  FormsAuthentication.RedirectToLoginPage()
            Throw ex
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        If Page.IsPostBack = False Then
            txtLogonID.Focus()

        Else
            txtPassword.Focus()
        End If
        Session("user_name") = ""
        

    End Sub
    Protected Sub getbranchprefix(ByVal user_nm As String, ByVal pwd As String)
        Try
            Dim user_name, pwd_name As String
            user_name = user_nm
            pwd_name = pwd

            If (user_name <> "") And (pwd_name <> "") Then

                Dim cmd As New SqlCommand
                Dim str_SQL As String
                str_SQL = " SELECT sys_Branch.Trading_Name, sys_User.User_ID, sys_User.Branch_ID AS User_Branch_ID, sys_User.Given_Name, sys_User.Last_Name, sys_User.Logon_ID, sys_User.Password, "
                str_SQL = str_SQL & " sys_User.User_Type, sys_User.FirstTime_Login, sys_Branch.* "
                str_SQL = str_SQL & " FROM sys_Branch INNER JOIN sys_User ON sys_Branch.Branch_ID = sys_User.Branch_ID "
                str_SQL = str_SQL & " WHERE sys_User.Logon_ID= @a and sys_User.Password= @b "
                cmd.CommandText = str_SQL
                cmd.Parameters.Add("@a", SqlDbType.VarChar, 50).Value = user_name
                ' Dim hashedBytes As Byte()
                ' Dim md5Hasher As New System.Security.Cryptography.MD5CryptoServiceProvider
                ' Dim encoder As New UTF8Encoding
                ' hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(pwd_name))
                ' cmd.Parameters.Add("@b", SqlDbType.Binary, 50).Value = hashedBytes
                cmd.Parameters.Add("@b", SqlDbType.VarChar, 50).Value = pwd_name

                cmd.Connection = open_con.return_con
                cmd.ExecuteNonQuery()
                Dim adap As SqlDataAdapter
                adap = New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                adap.Fill(ds)

                If ds.Tables(0).Rows.Count = 0 Then
                    Session("branch_prefix") = ""
                Else
                    Session("branch_prefix") = ds.Tables(0).Rows(0).Item("Branch_Prefix").ToString
                    Session("branch_id") = ds.Tables(0).Rows(0).Item("Branch_ID").ToString
                    Session("branch_name") = ds.Tables(0).Rows(0).Item("Trading_Name").ToString
                    open_con.branch_id_val = Session("branch_id")
                End If
                Session("user_type") = ds.Tables(0).Rows(0).Item("User_Type").ToString
                Session("username") = Convert.ToString(ds.Tables(0).Rows(0).Item("Given_Name")) & " " & Convert.ToString(ds.Tables(0).Rows(0).Item("Last_Name"))
                open_con.return_con.Dispose()
                ds.Dispose()
                adap.Dispose()
                cmd.Dispose()
            End If
       
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)

        End Try
       
    End Sub

    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
