Imports System.Data.SqlClient
Imports System
Imports System.Data
Partial Class Customer_Add_Bank
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
            r_load = True
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
    Protected Sub LinkButton_AddCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_AddCustomer.Click
        Response.Redirect("./Personal_Form.aspx", False)
    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        '''''''''This code is for grid click
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
        Response.Redirect("./detail.aspx", False)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
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

            If Not Page.IsPostBack Then
                If Session("bank_flag") = 0 Then
                    txtAccountName.Text = Session("account_name")
                    txtAccountNumber.Text = Session("account_number")
                    txtBankAddress.Text = Session("bank_address")
                    txtBankName.Text = Session("bank_name")
                    txtBankPostCode.Text = Session("postcode")
                    txtBankState.Text = Session("state")
                    txtBankSuburb.Text = Session("suburb")
                    txtBSB.Text = Session("bsb")
                Else
                    txtAccountName.Text = Session("customer_namebank")
                End If
            End If
            If Page.IsPostBack And txtsearch.Text <> "" And r_load <> True Then
                btnsearch_Click(Nothing, Nothing)
            Else
                txtsearch.Focus()
            End If
        End If
    End Sub
    Protected Sub goback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles goback.Click
        Response.Redirect("bank detail.aspx", False)
    End Sub
    Protected Sub updatebankdetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles updatebankdetail.Click


        'If IsNumeric(Trim(txtBankState.Text)) = True Then
        '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter a valid State!!!" & "');", True)
        '    Exit Sub
        'End If

        If IsNumeric(Trim(txtBankPostCode.Text)) = False Then
            txtBankPostCode.Text = 0
        End If
        Try
            Dim str_bank As String
            If Session("bank_flag") = 1 Then
                '''''''''''''insert bank account 
                Dim cmd_bank As New SqlCommand
                str_bank = "insert into Tbl_Bank_Account(Customer_ID,Account_Name,Account_Number,Bank_Name,Bank_Address,Bank_Suburb,Bank_State,Bank_Post_Code,BSB,Date_Joined) values(@Customer_ID,@Account_Name,@Account_Number,@Bank_Name,@Bank_Address,@Bank_Suburb,@Bank_State,@Bank_Post_Code,@BSB,@Date_Joined)"
                cmd_bank.CommandText = str_bank
                cmd_bank.Connection = open_con.return_con
                cmd_bank.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
                cmd_bank.Parameters.Add("@Account_Name", SqlDbType.VarChar, 255).Value = Trim(txtAccountName.Text)
                cmd_bank.Parameters.Add("@Account_Number", SqlDbType.Int).Value = CInt(Trim(txtAccountNumber.Text))
                cmd_bank.Parameters.Add("@Bank_Name", SqlDbType.VarChar, 255).Value = Trim(txtBankName.Text)
                cmd_bank.Parameters.Add("@Bank_Address", SqlDbType.VarChar, 255).Value = Trim(txtBankAddress.Text)
                cmd_bank.Parameters.Add("@Bank_Suburb", SqlDbType.VarChar, 255).Value = Trim(txtBankSuburb.Text)
                cmd_bank.Parameters.Add("@Bank_State", SqlDbType.VarChar, 255).Value = Trim(txtBankState.Text)
                cmd_bank.Parameters.Add("@Bank_Post_Code", SqlDbType.Int).Value = CInt(Trim(txtBankPostCode.Text))
                cmd_bank.Parameters.Add("@BSB", SqlDbType.VarChar, 255).Value = Trim(txtBSB.Text)
                cmd_bank.Parameters.Add("@Date_Joined", SqlDbType.Date).Value = DateTime.Now.Date
                cmd_bank.ExecuteNonQuery()
                cmd_bank.Dispose()
                open_con.return_con.Dispose()
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Bank details have been added!!!" & "');", True)
                txtAccountName.Text = ""
                txtAccountNumber.Text = ""
                txtBankAddress.Text = ""
                txtBankName.Text = ""
                txtBankPostCode.Text = ""
                txtBankState.Text = ""
                txtBankSuburb.Text = ""
                txtBSB.Text = ""

            Else
                '''''''Update bank account
                Dim cmd_bank As New SqlCommand
                str_bank = "update Tbl_Bank_Account set Account_Name=@Account_Name,Account_Number=@Account_Number,Bank_Name=@Bank_Name,Bank_Address=@Bank_Address,Bank_Suburb=@Bank_Suburb,Bank_State=@Bank_State,Bank_Post_Code=@Bank_Post_Code,BSB=@BSB,Date_Joined=@Date_Joined where Customer_ID=@Customer_ID and  Bank_Account_ID =@Bank_Account_ID"
                cmd_bank.CommandText = str_bank
                cmd_bank.Connection = open_con.return_con
                cmd_bank.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
                cmd_bank.Parameters.Add("@Bank_Account_ID", SqlDbType.Int).Value = Session("Bank_Account_ID")
                cmd_bank.Parameters.Add("@Account_Name", SqlDbType.VarChar, 255).Value = Trim(txtAccountName.Text)
                cmd_bank.Parameters.Add("@Account_Number", SqlDbType.Int).Value = CInt(Trim(txtAccountNumber.Text))
                cmd_bank.Parameters.Add("@Bank_Name", SqlDbType.VarChar, 255).Value = Trim(txtBankName.Text)
                cmd_bank.Parameters.Add("@Bank_Address", SqlDbType.VarChar, 255).Value = Trim(txtBankAddress.Text)
                cmd_bank.Parameters.Add("@Bank_Suburb", SqlDbType.VarChar, 255).Value = Trim(txtBankSuburb.Text)
                cmd_bank.Parameters.Add("@Bank_State", SqlDbType.VarChar, 255).Value = Trim(txtBankState.Text)
                cmd_bank.Parameters.Add("@Bank_Post_Code", SqlDbType.Int).Value = CInt(Trim(txtBankPostCode.Text))
                cmd_bank.Parameters.Add("@BSB", SqlDbType.VarChar, 255).Value = Trim(txtBSB.Text)
                cmd_bank.Parameters.Add("@Date_Joined", SqlDbType.Date).Value = DateTime.Now.Date
                cmd_bank.ExecuteNonQuery()
                cmd_bank.Dispose()
                open_con.return_con.Dispose()
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Bank details have been updated!!!" & "');", True)
            End If

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        ''''''''''These are used so that panel4 which is for letters and panel1 which is for bank is not visible
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
            form1.FindControl("toolbaar3").Visible = False
            Panel1.Visible = False
        End If

    End Sub
    Protected Sub printbnkdet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles printbnkdet.Click
        Response.Redirect("../Reports/Print_Bank_Detail.aspx", False)
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
