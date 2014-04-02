Imports System.Data
Imports System.Data.SqlClient

Partial Class Customer_Update_Safe
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

            If Session("user_type") = "Manager" Or Session("user_type") = "Admin" Then

            Else

                DropDownList1.Items(2).Enabled = False
                DropDownList1.Items(3).Enabled = False
                DropDownList1.Items(5).Enabled = False
                DropDownList1.Items(6).Enabled = False

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

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If DropDownList1.SelectedItem.Value = "M/Plus" Or DropDownList1.SelectedItem.Value = "ABAZ" Then
            txtchequeno.Visible = True
            Label1.Visible = True
            tdcheque.Visible = True

        Else
            txtchequeno.Visible = False
            Label1.Visible = False
            tdcheque.Visible = False
        End If
    End Sub

    Protected Sub btn_safe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_safe.Click
        Try

            'Validation            
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

            Dim cmd_safe As New SqlCommand
            cmd_safe.CommandText = "Insert into Tbl_Cash_Balance(Branch_ID,Description,Amount,User_ID,User_Machine_ID,Date)values(@Branch_ID,@Description,@Amount,@User_ID,@User_Machine_ID,@Date)"
            cmd_safe.Parameters.Add("@Branch_ID", SqlDbType.Int).Value = open_con.branch_id_val
            If DropDownList1.SelectedItem.Value = "ABAZ" Or DropDownList1.SelectedItem.Value = "M/Plus" Then
                cmd_safe.Parameters.Add("@Description", SqlDbType.VarChar, 255).Value = DropDownList1.SelectedItem.Value & "-" & txtchequeno.Text
            Else
                cmd_safe.Parameters.Add("@Description", SqlDbType.VarChar, 255).Value = DropDownList1.SelectedItem.Value
            End If
            cmd_safe.Parameters.Add("@Amount", SqlDbType.VarChar, 255).Value = txt_amt.Text
            cmd_safe.Parameters.Add("@User_ID", SqlDbType.Int).Value = Session("user_id")
            'cmd_safe.Parameters.Add("@User_Machine_ID", SqlDbType.VarChar, 255).Value = Request.ServerVariables("REMOTE_ADDR")
            cmd_safe.Parameters.Add("@User_Machine_ID", SqlDbType.VarChar, 255).Value = ddlTeller.SelectedItem.Text
            cmd_safe.Parameters.Add("@Date", SqlDbType.Date).Value = System.DateTime.Now.Date
            cmd_safe.Connection = open_con.return_con
            cmd_safe.ExecuteNonQuery()
            txt_amt.Text = ""
            txtchequeno.Text = ""
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "SAFE has been updated!!!" & "');", True)
            cmd_safe.Dispose()
            open_con.return_con.Dispose()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
       
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()

    End Sub

    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub

End Class
