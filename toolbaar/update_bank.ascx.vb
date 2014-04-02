Imports System.Data
Imports System.Data.SqlClient
Partial Class toolbaar_update_bank
    Inherits System.Web.UI.UserControl
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label6.Text = Session("Customer_Name")
        Dim ds_getbank As New DataSet
        ds_getbank = open_con.find_bank(open_con.customer_id_val)
        If ds_getbank.Tables(0).Rows.Count = 0 Then
            Session("account_name") = Session("Customer_Namebnk")
        Else
            Session("account_name") = ds_getbank.Tables(0).Rows(0).Item(2).ToString
            open_con.customer_id_val = ds_getbank.Tables(0).Rows(0).Item(0).ToString
        End If
        If ds_getbank.Tables(0).Rows.Count <> 0 Then
            GridView1.DataSource = ds_getbank.Tables(0)
            GridView1.DataBind()
            ds_getbank.Dispose()
            Panel2.Visible = True
            Panel1.Visible = False
        Else
            Panel1.Visible = True
            Panel2.Visible = False
        End If

    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFBD6'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            e.Row.Attributes.Add("ondblClick", Me.Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex))

        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row_index As Integer
        row_index = GridView1.SelectedRow.RowIndex
        Session("row_index") = GridView1.SelectedRow.RowIndex
        If GridView1.Rows(row_index).Cells.Item(0).Text = "&nbsp;" Then
            Session("bsb") = ""
        Else
            Session("bsb") = GridView1.Rows(row_index).Cells.Item(0).Text
        End If
        If GridView1.Rows(row_index).Cells.Item(1).Text = "&nbsp;" Then
            Session("account_number") = ""
        Else
            Session("account_number") = GridView1.Rows(row_index).Cells.Item(1).Text
        End If
        If GridView1.Rows(row_index).Cells.Item(2).Text = "&nbsp;" Then
            Session("bank_name") = ""
        Else
            Session("bank_name") = GridView1.Rows(row_index).Cells.Item(2).Text
        End If
        ' Session("account_name") = Session("Customer_namebank")
        If GridView1.Rows(row_index).Cells.Item(3).Text = "&nbsp;" Then
            Session("suburb") = ""
        Else
            Session("suburb") = GridView1.Rows(row_index).Cells.Item(3).Text
        End If
        If GridView1.Rows(row_index).Cells.Item(4).Text = "&nbsp;" Then
            Session("state") = ""
        Else
            Session("state") = GridView1.Rows(row_index).Cells.Item(4).Text
        End If
        If GridView1.Rows(row_index).Cells.Item(5).Text = "&nbsp;" Then
            Session("postcode") = ""
        Else
            Session("postcode") = GridView1.Rows(row_index).Cells.Item(5).Text
        End If
        If GridView1.Rows(row_index).Cells.Item(6).Text = "&nbsp;" Then
            Session("bank_address") = ""
        Else
            Session("bank_address") = GridView1.Rows(row_index).Cells.Item(6).Text
        End If
        Session("bank_flag") = "0"

        If GridView1.Rows(row_index).Cells.Item(7).Text = "&nbsp;" Then
            Session("Bank_Account_ID") = ""
        Else
            Session("Bank_Account_ID") = GridView1.Rows(row_index).Cells.Item(7).Text
        End If
        If GridView1.Rows(row_index).Cells.Item(8).Text = "&nbsp;" Then
            Session("account_name") = ""
        Else
            Session("account_name") = GridView1.Rows(row_index).Cells.Item(8).Text
        End If
        Session("bank_flag") = "0"
        Response.Redirect("./Add_Bank.aspx", False)

    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Session("bank_flag") = "1"
        Session("account_name") = ""
        Session("account_number") = ""
        Session("bank_address") = ""
        Session("bank_name") = ""
        Session("postcode") = ""
        Session("state") = ""
        Session("suburb") = ""
        Session("bsb") = ""
        Response.Redirect("add_bank.aspx", False)

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Session("bank_flag") = 1
        Response.Redirect("Add_Bank.aspx", False)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        e.Row.Cells(7).Visible = False
        e.Row.Cells(8).Visible = False
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
