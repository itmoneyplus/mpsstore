Imports System.Data.SqlClient
Imports System
Imports System.Data
Partial Class Customer_Detail
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
            Dim str_SQL As String
            Dim ds As New DataSet
            Dim adap As SqlDataAdapter
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

                ds.Tables.Clear()
                adap = New SqlDataAdapter(str_SQL, open_con.return_con)
                adap.Fill(ds)
                adap.Dispose()

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
                ds.Dispose()


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
      
            form1.FindControl("che_id").Visible = False
            form1.FindControl("tool3").Visible = False
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            'If Page.IsPostBack And txtsearch.Text <> "" And r_load <> True Then
            '    btnsearch_Click(Nothing, Nothing)
            'Else
            '    txtsearch.Focus()
            '    If Request.QueryString("Name") <> "" Then
            '        Session("flag_show") = 1
            '        Dim given_name, last_name, id As String
            '        given_name = Request.QueryString("Given_Name")
            '        last_name = Request.QueryString("Last_Name")
            '        id = Request.QueryString("Name")
            '        open_con.customer_id_val = CInt(id)
            '        Session("Customer_name") = given_name & " " & last_name & " " & Session("branch_prefix") & " " & open_con.customer_id_val
            '        Session("Customer_namebank") = given_name & " " & last_name
            '        btnsearch_Click(Nothing, Nothing)
            '    End If
            'End If
        End If
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class


