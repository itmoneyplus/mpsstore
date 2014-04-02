Imports System.Data.SqlClient
Imports System
Imports System.Data
Partial Class Customer_Bank_Detail
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Dim flag_val As Boolean = False
    Dim r_load As Boolean
   Function fn_AdjustStringForSQL(ByVal psStringtoChange As String) As String

        Dim lStartPosition As Integer
        lStartPosition = 1
        While InStr(lStartPosition, psStringtoChange, "'")
            psStringtoChange = Left(psStringtoChange, InStr(lStartPosition, psStringtoChange, "'")) & Mid(psStringtoChange, InStr(lStartPosition, psStringtoChange, "'"), Len(psStringtoChange))
            lStartPosition = InStr(lStartPosition, psStringtoChange, "'") + 2
        End While
        fn_AdjustStringForSQL = psStringtoChange

    End Function
    Protected Sub binddata()
        Try
            r_load = "True"
            Dim cmd As New SqlCommand
            Dim str_SQL As String
            str_SQL = " SELECT *  FROM Tbl_Customer   where  "
            If txtsearch.Text <> "" Then
                If IsNumeric(Trim(txtsearch.Text)) Then
                    str_SQL = str_SQL & "Customer_ID = " & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & " OR "
                End If
                str_SQL = str_SQL & " Given_Name like '" & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & "%'"
                str_SQL = str_SQL & " OR Last_Name like '" & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & "%'"
                str_SQL = str_SQL & " OR R_Given_Name like '" & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & "%'"
                str_SQL = str_SQL & " OR R_Last_Name like '" & fn_AdjustStringForSQL(Trim(txtsearch.Text)) & "%'"
                str_SQL = str_SQL & " ORDER BY Given_Name, Last_Name "

                cmd.Connection = open_con.return_con
                cmd.CommandText = str_SQL
                cmd.ExecuteNonQuery()
                Dim adap As SqlDataAdapter
                adap = New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                adap.Fill(ds)
                If ds.Tables(0).Rows.Count = 0 Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No such Customer Exist!!!" & "');", True)
                    txtsearch.Text = ""
                    txtsearch.Focus()
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                    label3.Visible = False
                    Exit Sub
                Else
                    txtsearch.Text = ""
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                    label3.Visible = True
                End If
                open_con.return_con.Dispose()
                cmd.Dispose()
                adap.Dispose()
                ds.Dispose()
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid Customer Name or ID!!!" & "');", True)
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Protected Sub LinkButton_AddCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_AddCustomer.Click
        Response.Redirect("./Personal_Form.aspx", False)
    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFBD6'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            e.Row.Attributes.Add("ondblClick", ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex))
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.Cells.Item(4).Text = "&nbsp;" Then
            e.Row.Cells(4).Text = ""
        ElseIf e.Row.Cells.Item(4).Text = "Request Amount" Then
            e.Row.Cells.Item(4).Text = "Request Amount"
        Else
            e.Row.Cells(4).Text = CStr(e.Row.Cells(4).Text.ToString)
        End If

    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row_index As Integer
        row_index = GridView1.SelectedRow.RowIndex
        Dim customer_ID As Integer
        Dim last_name As String
        Dim given_name As String

        customer_ID = GridView1.Rows(row_index).Cells.Item(0).Text
        open_con.customer_id_val = customer_ID

        given_name = GridView1.Rows(row_index).Cells.Item(1).Text
        last_name = GridView1.Rows(row_index).Cells.Item(2).Text

        Session("Customer_name") = given_name & " " & last_name & " " & Session("branch_prefix") & " " & open_con.customer_id_val
        Session("Customer_namebank") = given_name & " " & last_name

        Response.Redirect("./Detail.aspx", False)

    End Sub
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Session("bank_nom") = False
        Session("letter") = 0
        Session("sch_history") = 0
        Session("loan_st") = 0
        Session("r_load") = "True"
        Session("Pay_re") = False
        Session("pay_sch") = False
        If txtsearch.Text <> "" Then
            flag_val = True
        End If
        If flag_val = True And r_load <> True Then
            Session("Show") = 0
            binddata()
            'form1.FindControl("tool3").Visible = False
            form1.FindControl("tool4").Visible = False
            Panel2.Visible = False
        End If
    End Sub

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
            If Page.IsPostBack And txtsearch.Text <> "" And r_load <> True Then
                btnsearch_Click(Nothing, Nothing)
            Else
                txtsearch.Focus()
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
    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub
End Class
