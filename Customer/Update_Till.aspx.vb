Imports System.Data
Imports System.Data.SqlClient
Imports System.Net

Partial Class Customer_Update_Safe
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()

        If Me.IsPostBack = False Then

        End If
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else

            If Session("user_type") = "Manager" Or Session("user_type") = "Admin" Then
            Else
                DropDownList1.Items(2).Enabled = False
                DropDownList1.Items(3).Enabled = False
                DropDownList1.Items(6).Enabled = False
                DropDownList1.Items(7).Enabled = False

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
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
    Protected Sub btn_till_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_till.Click

        Try
            'validation
            If DropDownList1.SelectedItem.Value = "0" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select Description" & "');", True)
                Exit Sub
            ElseIf txt_amt.Text = "" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter Amount" & "');", True)
                Exit Sub
            ElseIf ddlTeller.SelectedItem.Value = "0" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select Teller No." & "');", True)
                Exit Sub
            End If

            Dim cmd_till As New SqlCommand
            cmd_till.CommandText = "Insert into Tbl_Cash_Balance(Branch_ID,Description,Amount,User_ID,User_Machine_ID,Date)values(@Branch_ID,@Description,@Amount,@User_ID,@User_Machine_ID,@Date)"
            cmd_till.Parameters.Add("@Branch_ID", SqlDbType.Int).Value = open_con.branch_id_val
            cmd_till.Parameters.Add("@Description", SqlDbType.VarChar, 255).Value = DropDownList1.SelectedItem.Value
            cmd_till.Parameters.Add("@Amount", SqlDbType.VarChar, 255).Value = txt_amt.Text
            cmd_till.Parameters.Add("@User_ID", SqlDbType.Int).Value = Session("user_id")
            ' to check till name insert. - by Umesh Request.UserHostAddress '
            ' cmd_till.Parameters.Add("@User_Machine_ID", SqlDbType.VarChar, 255).Value = Request.ServerVariables("REMOTE_ADDR")

            'By Nirja
            'cmd_till.Parameters.Add("@User_Machine_ID", SqlDbType.VarChar, 255).Value = Dns.GetHostEntry(Request.ServerVariables("REMOTE_ADDR")).HostName()
            cmd_till.Parameters.Add("@User_Machine_ID", SqlDbType.VarChar, 255).Value = ddlTeller.SelectedItem.Text
            cmd_till.Parameters.Add("@Date", SqlDbType.Date).Value = System.DateTime.Now.Date
            cmd_till.Connection = open_con.return_con
            cmd_till.ExecuteNonQuery()
            txt_amt.Text = ""
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Till has been updated!!!" & "');", True)
            cmd_till.Dispose()
            open_con.return_con.Dispose()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub

   
End Class
