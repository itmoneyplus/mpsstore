Imports System.Data.SqlClient
Imports System
Imports System.Data
Partial Class Customer_Sex_Status
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
                    Label3.Visible = False
                    Exit Sub
                Else
                    txtsearch.Text = ""
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                    Label3.Visible = True
                End If
                cmd.Dispose()
                adap.Dispose()
                ds.Dispose()
                open_con.return_con.Dispose()

            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid Customer Name or ID!!!" & "');", True)
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("./Personal_Form.aspx", False)
    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='none';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFBD6'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            e.Row.Attributes.Add("ondblClick", Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex))
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
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            If Page.IsPostBack And txtsearch.Text <> "" And r_load <> True Then
                btnsearch_Click(Nothing, Nothing)
                GridView2.Visible = False
            ElseIf txtsearch.Text = "" And Request.QueryString("SEX") <> "" Then
                Panel1.Visible = True
                Label4.Visible = True
                GridView2.Visible = True
                binddata_grid2_()
            Else
                txtsearch.Focus()

            End If
        End If
    End Sub
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Session("bank_nom") = False
        Session("letter") = 0
        Session("sch_history") = 0
        Session("loan_st") = 0
        Session("r_load") = "True"
        Session("Pay_re") = False
        Session("pay_sch") = False
        Label4.Visible = False
        Label5.Visible = False
        btn_print.Visible = False
        GridView2.Visible = False
        If txtsearch.Text <> "" Then
            flag_val = True
        End If
        If flag_val = True And r_load <> True Then
            Session("Show") = 0
            binddata()
        End If
    End Sub
    Sub binddata_grid2_()
        Dim cmd_grid2, cmd_grid3, cmd_grid4 As New SqlCommand
        Dim str_SQL_grid2, str_SQL_grid3, str_SQL_grid4 As String
        Dim adap_grid2 As SqlDataAdapter
        Dim ds_grid2 As New DataSet
        Dim fromdt_grid2, todt_grid2 As String
        Dim fromdt_grid2_new, todt_grid2_new As String
       

        If Request.QueryString("SEX") = "m" And Request.QueryString("SEX_VL") <> 0 Then
            Session("sex") = "m"
            btn_print.Visible = True
            fromdt_grid2 = Request.QueryString("From_Dt")
            Session("fromdt_grid2_sex") = fromdt_grid2
            todt_grid2 = Request.QueryString("To_Dt")
            Session("todt_grid2_sex") = todt_grid2
            fromdt_grid2_new = Date.Parse(fromdt_grid2).ToString("dd-MMM-yyyy")
            fromdt_grid2_new = fromdt_grid2_new.Replace("-", " ")
            todt_grid2_new = Date.Parse(todt_grid2).ToString("dd-MMM-yyyy")
            todt_grid2_new = todt_grid2_new.Replace("-", " ")
            Label4.Text = "Sex Statistics Report for the period " & fromdt_grid2_new & " to " & todt_grid2_new
          
            str_SQL_grid3 = "Select tbl_Loan.customer_id,given_name,last_name,title,amount,loan_date into  abc from tbl_Loan,tbl_customer where  tbl_loan.status<>0 and tbl_loan.status<>2  and Loan_Date>= ' " & fromdt_grid2 & "' and Loan_Date<= ' " & todt_grid2 & "' and tbl_loan.customer_id=tbl_customer.customer_id "
            cmd_grid3.Connection = open_con.return_con
            cmd_grid3.CommandText = str_SQL_grid3
            cmd_grid3.ExecuteNonQuery()
            str_SQL_grid4 = "select * from abc where title ='Mr'"
            cmd_grid4.Connection = open_con.return_con
            cmd_grid4.CommandText = str_SQL_grid4
            adap_grid2 = New SqlDataAdapter(cmd_grid4)
            adap_grid2.Fill(ds_grid2)
            GridView2.DataSource = ds_grid2
            GridView2.DataBind()
            str_SQL_grid2 = "Drop table abc"
            cmd_grid2.Connection = open_con.return_con
            cmd_grid2.CommandText = str_SQL_grid2
            cmd_grid2.ExecuteNonQuery()
            cmd_grid2.Dispose()
            cmd_grid3.Dispose()
            cmd_grid4.Dispose()
            adap_grid2.Dispose()
            ds_grid2.Dispose()
            open_con.return_con.Dispose()
            Session("loan_stats") = "false"

        ElseIf Request.QueryString("SEX") = "f" And Request.QueryString("SEX_VL") <> 0 Then
            btn_print.Visible = True
            Session("sex") = "f"
            fromdt_grid2 = Request.QueryString("From_Dt")
            Session("fromdt_grid2_sex") = fromdt_grid2
            todt_grid2 = Request.QueryString("To_Dt")
            Session("todt_grid2_sex") = todt_grid2
            fromdt_grid2_new = Date.Parse(fromdt_grid2).ToString("dd-MMM-yyyy")
            fromdt_grid2_new = fromdt_grid2_new.Replace("-", " ")
            todt_grid2_new = Date.Parse(todt_grid2).ToString("dd-MMM-yyyy")
            todt_grid2_new = todt_grid2_new.Replace("-", " ")
            Label4.Text = "Sex Statistics Report for the period " & fromdt_grid2_new & " to " & todt_grid2_new
           
            str_SQL_grid3 = "Select tbl_Loan.customer_id,given_name,last_name,title,amount,loan_date into  abc from tbl_Loan,tbl_customer where  tbl_loan.status<>0 and tbl_loan.status<>2  and Loan_Date>= ' " & fromdt_grid2 & "' and Loan_Date<= ' " & todt_grid2 & "' and tbl_loan.customer_id=tbl_customer.customer_id "
            cmd_grid3.Connection = open_con.return_con
            cmd_grid3.CommandText = str_SQL_grid3
            cmd_grid3.ExecuteNonQuery()
            str_SQL_grid4 = "select * from abc where title <>'Mr'"
            cmd_grid4.Connection = open_con.return_con
            cmd_grid4.CommandText = str_SQL_grid4
            adap_grid2 = New SqlDataAdapter(cmd_grid4)
            adap_grid2.Fill(ds_grid2)
            GridView2.DataSource = ds_grid2
            GridView2.DataBind()
            str_SQL_grid2 = "Drop table abc"
            cmd_grid2.Connection = open_con.return_con

            cmd_grid2.CommandText = str_SQL_grid2
            cmd_grid2.ExecuteNonQuery()
            cmd_grid2.Dispose()
            cmd_grid3.Dispose()
            cmd_grid4.Dispose()
            adap_grid2.Dispose()
            ds_grid2.Dispose()
            open_con.return_con.Dispose()
            Session("loan_stats") = "false"

        ElseIf Request.QueryString("SEX_VL") = 0 Then
            Label5.Visible = True
            btn_print.Visible = False

            fromdt_grid2 = Request.QueryString("From_Dt")
            todt_grid2 = Request.QueryString("To_Dt")
            fromdt_grid2_new = Date.Parse(fromdt_grid2).ToString("dd-MMM-yyyy")
            fromdt_grid2_new = fromdt_grid2_new.Replace("-", " ")
            todt_grid2_new = Date.Parse(todt_grid2).ToString("dd-MMM-yyyy")
            todt_grid2_new = todt_grid2_new.Replace("-", " ")
            Label4.Text = "Sex Statistics Report for the period " & fromdt_grid2_new & " to " & todt_grid2_new
            Label5.Text = "No Records Found!!!"
            Session("loan_stats") = "false"
        End If

    End Sub
    Protected Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='none';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFBD6'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            e.Row.Attributes.Add("ondblClick", Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" & e.Row.RowIndex))
        End If
    End Sub
    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged

        Dim row_index As Integer
        row_index = GridView2.SelectedRow.RowIndex
        Dim customer_ID As Integer
        Dim last_name As String
        Dim given_name As String

        customer_ID = GridView2.Rows(row_index).Cells.Item(0).Text
        open_con.customer_id_val = customer_ID

        given_name = GridView2.Rows(row_index).Cells.Item(1).Text
        last_name = GridView2.Rows(row_index).Cells.Item(2).Text

        Session("Customer_name") = given_name & " " & last_name & " " & Session("branch_prefix") & " " & open_con.customer_id_val
        Session("Customer_namebank") = given_name & " " & last_name

        Response.Redirect("./detail.aspx", False)

    End Sub

    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub

    Protected Sub btn_print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_print.Click
        Response.Redirect("../Reports/Print_Sex_Status.aspx")
    End Sub
End Class
