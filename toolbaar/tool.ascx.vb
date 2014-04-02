Imports System.Data.SqlClient
Imports System.Data
Partial Class toolbaar_toolbaar3
    Inherits System.Web.UI.UserControl
    Dim open_con As New Class1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Label1.Text = Session("Customer_name")
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

   
End Class
