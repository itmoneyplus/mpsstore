Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Net
Partial Class Customer_ChangePassword
    Inherits System.Web.UI.Page
    Dim open_con As New Class1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()



        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            If Not IsPostBack Then
                Using obj As New clsReport()
                    Dim ds As DataSet = obj.getNames()
                    If ds.Tables(0).Rows.Count > 0 Then
                        ddlNames.DataSource = ds
                        ddlNames.DataTextField = "Given_Name"
                        ddlNames.DataValueField = "User_ID"
                        ddlNames.DataBind()
                        ddlNames.Items.Insert(0, New ListItem("--Select--", "0"))
                    End If
                End Using
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

    Protected Sub btnChangePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        Try
            If txtNewPassword.Text = "" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter New Password!!!" & "');", True)
                Exit Sub
            ElseIf txtConfirmPassword.Text = "" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter Confirm Password!!!" & "');", True)
                Exit Sub
            ElseIf Not (String.Compare(txtNewPassword.Text, txtConfirmPassword.Text) = 0) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Passwords do not match!!!" & "');", True)
                Exit Sub
            Else
                Dim cmd As New SqlCommand
                Dim query As String
                query = "Update sys_User set Password = @password WHERE User_ID = @userID"
                cmd.Connection = open_con.return_con
                cmd.CommandText = query
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = txtNewPassword.Text
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = ddlNames.SelectedValue
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Password Changed!!!" & "');", True)                          
            End If

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
End Class
