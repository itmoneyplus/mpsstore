Imports System.Data.SqlClient
Imports System.Data

Partial Class toolbaar_tool_cheque
    Inherits System.Web.UI.UserControl
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Dim strSQL As String
            strSQL = "Select Cheque_Cashing_ID, Cheque_Amount,  Cheque_Fee, Pay_Cash_Now, Transaction_Status, Cheque_Cashed_On from Tbl_Cheque_Cashing Where Customer_ID =@Customer_ID  ORDER BY Cheque_Cashed_On DESC "
            Dim adap_cheque As SqlDataAdapter
            Dim cmd_cheque As New SqlCommand
            Dim ds_Cheque As New DataSet
            cmd_cheque.CommandText = strSQL
            cmd_cheque.Parameters.Add("@customer_id", SqlDbType.Int).Value = open_con.customer_id_val
            cmd_cheque.Connection = open_con.return_con
            adap_cheque = New SqlDataAdapter(cmd_cheque)
            adap_cheque.Fill(ds_Cheque)


            If ds_Cheque.Tables(0).Rows.Count <> 0 Then
                GridView1.DataSource = ds_Cheque
                GridView1.DataBind()
                'Label3.Visible = True
                'Label4.Visible = True
                'Dim cheque_tot As Integer


                'For i As Integer = 0 To ds_Cheque.Tables(0).Rows.Count - 1
                '    cheque_tot = cheque_tot + ds_Cheque.Tables(0).Rows(i).Item("cheque_amount")
                'Next
                'Label4.Text = "$" & FormatNumber(cheque_tot, 2)


                ds_Cheque.Dispose()
                cmd_cheque.Dispose()
                adap_cheque.Dispose()
                open_con.return_con.Close()

            Else
                Label3.Visible = False
                Label4.Visible = False
                Label5.Visible = True
            End If



        End If

       
    End Sub

    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='none';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("ondblClick", Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex))


        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim che_fee, che_amt As Double
        If e.Row.Cells.Item(4).Text = "&nbsp;" Then
            e.Row.Cells(4).Text = ""
        ElseIf e.Row.Cells.Item(4).Text = "%age" Then
            e.Row.Cells.Item(4).Text = "%age"
        Else
            If e.Row.Cells.Item(4).Text = "&nbsp;" Then
                e.Row.Cells(4).Text = ""
            ElseIf e.Row.Cells.Item(4).Text = "Cheque Fee" Then
                e.Row.Cells.Item(4).Text = "Cheque Fee"
            Else
                che_fee = e.Row.Cells.Item(4).Text
                e.Row.Cells.Item(4).Text = "$" & FormatNumber(e.Row.Cells.Item(4).Text, 2)
            End If
            If e.Row.Cells.Item(3).Text = "&nbsp;" Then
                e.Row.Cells(3).Text = ""
            ElseIf e.Row.Cells.Item(3).Text = "Cheque Amount" Then
                e.Row.Cells.Item(3).Text = "Cheque Amount"
            Else
                che_amt = e.Row.Cells.Item(3).Text
                e.Row.Cells.Item(3).Text = "$" & FormatNumber(e.Row.Cells.Item(3).Text, 2)
            End If

            If e.Row.Cells.Item(5).Text = "&nbsp;" Then
                e.Row.Cells(5).Text = ""
            ElseIf e.Row.Cells.Item(5).Text = "%age" Then
                e.Row.Cells.Item(5).Text = "%age"
            Else
                e.Row.Cells(5).Text = Val((che_fee * 100) / (che_amt)) & "%"
            End If
            e.Row.Cells.Item(7).Visible = False

        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row_index As Integer
        row_index = GridView1.SelectedRow.RowIndex
        Dim Cheque_Cashing_ID As Integer
        Cheque_Cashing_ID = GridView1.Rows(row_index).Cells.Item(7).Text
        Response.Redirect("Cheque Detail.aspx?Cheque_Cashing_ID=" & Cheque_Cashing_ID, False)
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
