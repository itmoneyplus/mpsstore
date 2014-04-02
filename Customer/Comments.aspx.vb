Imports System.Data.SqlClient
Imports System
Imports System.Data
Partial Class Customer_Comments
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

            str_SQL = " SELECT *  FROM Tbl_Customer where  "
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
                ds.Dispose()
                adap.Dispose()
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

            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='none';"
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

        Response.Redirect("./detail.aspx", False)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            If Page.IsPostBack And txtsearch.Text <> "" And r_load <> True Then
                btnsearch_Click(Nothing, Nothing)
            Else
                txtsearch.Focus()

                txtaddcmnt.Visible = False
                btnsave.Visible = False
                Label5.Visible = True

            End If

            If Page.IsPostBack = False Then
                view_comments()
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
    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Try
            Dim cmd_del_command As New SqlCommand
            cmd_del_command.Connection = open_con.return_con
            cmd_del_command.CommandText = "Delete from Tbl_Comment where Customer_ID =@a and Comment_ID=@b "
            cmd_del_command.Parameters.Add("@a", SqlDbType.Int).Value = open_con.customer_id_val
            cmd_del_command.Parameters.Add("@b", SqlDbType.Int).Value = GridView2.DataKeys(e.RowIndex).Value.ToString()
            cmd_del_command.ExecuteNonQuery()
            bind_grid()
            cmd_del_command.Dispose()
            open_con.return_con.Dispose()

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub
    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        GridView2.EditIndex = e.NewEditIndex
        bind_grid()
    End Sub
    Protected Sub GridView2_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView2.RowCancelingEdit
        GridView2.EditIndex = -1
        bind_grid()
    End Sub
    Function bind_grid() As Boolean

        Dim cmd_bind_grid As New SqlCommand
        Dim str_bind_grid As String
        str_bind_grid = "select * from Tbl_Comment where Customer_ID = '" & open_con.customer_id_val & "'"
        cmd_bind_grid.CommandText = str_bind_grid
        cmd_bind_grid.Connection = open_con.return_con
        cmd_bind_grid.ExecuteNonQuery()
        Dim adap_bind_grid As SqlDataAdapter
        adap_bind_grid = New SqlDataAdapter(cmd_bind_grid)
        Dim ds_bind_grid As New DataSet
        adap_bind_grid.Fill(ds_bind_grid)
        GridView2.DataSource = ds_bind_grid
        GridView2.DataBind()
        If ds_bind_grid.Tables(0).Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If
        cmd_bind_grid.Dispose()
        adap_bind_grid.Dispose()
        ds_bind_grid.Dispose()
        open_con.return_con.Dispose()

    End Function

    Protected Sub GridView2_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView2.RowUpdating
        Try
            Dim cmd_upd_comment As New SqlCommand
            cmd_upd_comment.Connection = open_con.return_con
            cmd_upd_comment.CommandText = "update Tbl_Comment set comment=@c,Added_On=@d,time_on=@e,user_id=@f,Added_By=@g where Customer_ID =@a and comment_ID=@b "
            cmd_upd_comment.Parameters.Add("@a", SqlDbType.Int).Value = open_con.customer_id_val
            cmd_upd_comment.Parameters.Add("@b", SqlDbType.Int).Value = GridView2.DataKeys(e.RowIndex).Value.ToString()
            Dim row As GridViewRow
            row = GridView2.Rows(e.RowIndex)
            Dim type As TextBox = DirectCast(row.FindControl("TextBox1"), TextBox)
            cmd_upd_comment.Parameters.Add("@c", SqlDbType.VarChar, 255).Value = type.Text
            cmd_upd_comment.Parameters.Add("@d", SqlDbType.Date).Value = System.DateTime.Now.Date
            cmd_upd_comment.Parameters.Add("@e", SqlDbType.DateTime).Value = System.DateTime.Now
            cmd_upd_comment.Parameters.Add("@f", SqlDbType.VarChar, 50).Value = open_con.user_id_val
            cmd_upd_comment.Parameters.Add("@g", SqlDbType.VarChar, 50).Value = Session("user_name")
            cmd_upd_comment.ExecuteNonQuery()
            GridView2.EditIndex = -1
            bind_grid2()
            cmd_upd_comment.Dispose()
            open_con.return_con.Dispose()

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub
    Sub bind_grid2()

        Dim cmd_bind_grid2 As New SqlCommand
        Dim str_bind_grid2 As String
        str_bind_grid2 = "select * from Tbl_Comment where Customer_ID = '" & open_con.customer_id_val & "'"
        cmd_bind_grid2.CommandText = str_bind_grid2
        cmd_bind_grid2.Connection = open_con.return_con
        cmd_bind_grid2.ExecuteNonQuery()
        Dim adap_bind_grid2 As SqlDataAdapter
        adap_bind_grid2 = New SqlDataAdapter(cmd_bind_grid2)
        Dim ds_bind_grid2 As New DataSet
        adap_bind_grid2.Fill(ds_bind_grid2)
        GridView2.DataSource = ds_bind_grid2
        GridView2.DataBind()
        open_con.return_con.Dispose()
        cmd_bind_grid2.Dispose()
        adap_bind_grid2.Dispose()
        ds_bind_grid2.Dispose()

    End Sub
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Session("bank_nom") = False
        Session("letter") = 0
        Session("r_load") = "True"
        Session("sch_history") = 0
        Session("loan_st") = 0
        Session("Pay_re") = False
        Session("pay_sch") = False
        If txtsearch.Text <> "" Then
            flag_val = True
        End If
        If flag_val = True And r_load <> True Then
            Session("Show") = 0
            binddata()
            Panel1.Visible = False
            Panel2.Visible = True
        End If


    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            '''''''''''Inserting Comments
            Dim cmd_cmnt As New SqlCommand
            Dim str_cmnt As String
            If Trim(txtaddcmnt.Text) = "" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter the comments to add!!!" & "');", True)
                txtaddcmnt.Visible = True
                btnsave.Visible = True
                btncncl.Visible = True
                Label5.Visible = True
                GridView2.Visible = False
                Exit Sub
            End If

            str_cmnt = "Insert into Tbl_Comment (Customer_ID, Comment, User_ID, Added_On,time_on,Added_By) values (@a,@b,@c,@d,@e,@f)"
            cmd_cmnt.CommandText = str_cmnt
            cmd_cmnt.Parameters.Add("@a", SqlDbType.Int).Value = open_con.customer_id_val
            cmd_cmnt.Parameters.Add("@b", SqlDbType.VarChar, 255).Value = txtaddcmnt.Text
            cmd_cmnt.Parameters.Add("@c", SqlDbType.Int).Value = open_con.user_id_val
            cmd_cmnt.Parameters.Add("@d", SqlDbType.Date).Value = DateTime.Now.Date
            cmd_cmnt.Parameters.Add("@e", SqlDbType.DateTime).Value = System.DateTime.Now
            cmd_cmnt.Parameters.Add("@f", SqlDbType.VarChar, 255).Value = Session("user_name")
            cmd_cmnt.Connection = open_con.return_con
            cmd_cmnt.ExecuteNonQuery()
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Comments have been added!!!" & "');", True)
            txtaddcmnt.Text = ""
            btnadd.Visible = True
            btnsave.Visible = False
            btncncl.Visible = False
            cmd_cmnt.Dispose()
            view_comments()
            open_con.return_con.Dispose()

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        txtaddcmnt.Visible = True
        txtaddcmnt.Text = ""
        btnadd.Visible = False
        btnsave.Visible = True
        btncncl.Visible = True
        Label5.Visible = True
        Label5.Text = "Add Comments!!!"
        GridView2.Visible = False
    End Sub

    'Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
    '    Try
    '        ''''''''''Displaying comments
    '        GridView2.Visible = True
    '        Dim cmd_viewcmnt As New SqlCommand
    '        Dim str_viewcmnt As String
    '        str_viewcmnt = "select * from Tbl_Comment where Customer_ID = '" & open_con.customer_id_val & "'"
    '        cmd_viewcmnt.CommandText = str_viewcmnt
    '        cmd_viewcmnt.Connection = open_con.return_con
    '        cmd_viewcmnt.ExecuteNonQuery()
    '        Dim adap_viewcmnt As SqlDataAdapter
    '        adap_viewcmnt = New SqlDataAdapter(cmd_viewcmnt)
    '        Dim ds_cmnt As New DataSet
    '        adap_viewcmnt.Fill(ds_cmnt)

    '        If ds_cmnt.Tables(0).Rows.Count = 0 Then
    '            Label5.Text = "No Comments Added!!!"

    '        Else
    '            Label5.Text = "Add Comments!!!"
    '            GridView2.DataSource = ds_cmnt
    '            GridView2.DataBind()
    '        End If
    '        open_con.return_con.Dispose()
    '        ds_cmnt.Dispose()
    '        cmd_viewcmnt.Dispose()
    '        adap_viewcmnt.Dispose()

    '    Catch ex As Exception
    '        Response.Write("Error: " & ex.Message)
    '    End Try
    'End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub

    Protected Sub btncncl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncncl.Click
        view_comments()
        btnadd.Visible = True
        btncncl.Visible = False
        btnsave.Visible = False
    End Sub
    Sub view_comments()
        Try
            ''''''''''Displaying comments
            GridView2.Visible = True
            Dim cmd_viewcmnt As New SqlCommand
            Dim str_viewcmnt As String
            str_viewcmnt = "select * from Tbl_Comment where Customer_ID = '" & open_con.customer_id_val & "'"
            cmd_viewcmnt.CommandText = str_viewcmnt
            cmd_viewcmnt.Connection = open_con.return_con
            cmd_viewcmnt.ExecuteNonQuery()
            Dim adap_viewcmnt As SqlDataAdapter
            adap_viewcmnt = New SqlDataAdapter(cmd_viewcmnt)
            Dim ds_cmnt As New DataSet
            adap_viewcmnt.Fill(ds_cmnt)

            If ds_cmnt.Tables(0).Rows.Count = 0 Then
                Label5.Visible = True
                Label5.Text = "No Comments Added"

            Else
                Label5.Visible = True
                Label5.Text = "Add Comments"
                GridView2.DataSource = ds_cmnt
                GridView2.DataBind()
            End If
            open_con.return_con.Dispose()
            ds_cmnt.Dispose()
            cmd_viewcmnt.Dispose()
            adap_viewcmnt.Dispose()

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub

    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub
End Class
