Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Net

Partial Class Reports_MoneyPlus_Online_Joined
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
 
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        bindReport()
    End Sub
    Private Sub bindReport()
        Try
            If Val(txtfrom.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                Exit Sub
            ElseIf Val(txtto.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid ending date!!!" & "');", True)
                Exit Sub
            ElseIf CDate(txtfrom.Text) > CDate(txtto.Text) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid future date!!!" & "');", True)
                Exit Sub
            Else
                grid_online_joined()
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            If Page.IsPostBack = True Then
                txtfrom.Text = txtfrom.Text
                txtto.Text = txtto.Text
                GridView1.Width = "1000"
                GridView1.Caption = "Online Customer Joined for  the period " & txtfrom.Text & " To " & txtto.Text
                GridView1.HeaderStyle.ForeColor = Drawing.Color.White
                GridView1.HeaderStyle.Font.Size = "12"
                GridView1.BorderStyle = BorderStyle.Solid
                GridView1.BorderWidth = "1"
                GridView1.Font.Size = "12"
                GridView1.HeaderStyle.BackColor = Drawing.Color.Maroon
            Else
                GridView1.Width = "1000"
                GridView1.Caption = "Online Customer Joined for the period " & txtfrom.Text & "To " & txtto.Text
                GridView1.HeaderStyle.ForeColor = Drawing.Color.White
                GridView1.HeaderStyle.Font.Size = "12"
                GridView1.BorderStyle = BorderStyle.Solid
                GridView1.BorderWidth = "1"
                GridView1.Font.Size = "12"
                GridView1.HeaderStyle.BackColor = Drawing.Color.Maroon
                Dim NewTime As DateTime
                NewTime = System.DateTime.Now.AddDays(-1)
                txtfrom.Text = NewTime.ToString("dd-MMM-yyyy")
                txtto.Text = System.DateTime.Now.Date.ToString("dd-MMM-yyyy")
            End If
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
 
        '  If e.Row.RowType = DataControlRowType.DataRow Then


        If e.Row.Cells.Item(2).Text = "&nbsp;" Then
            e.Row.Cells(2).Text = ""
        ElseIf e.Row.Cells.Item(2).Text = "Customer Name" Then
            e.Row.Cells.Item(2).Text = "Customer Name"
        Else
            e.Row.Cells(2).Text = e.Row.Cells(2).Text.ToString & " " & e.Row.Cells(3).Text.ToString
        End If
        '''''''''''''''''''''''''''''''
        e.Row.Cells(3).Visible = False
        ''''''''''''''''''''''''''''''''''''
        If e.Row.Cells.Item(4).Text = "&nbsp;" Then
            e.Row.Cells(4).Text = ""
        ElseIf e.Row.Cells.Item(4).Text = "Request Amount" Then
            e.Row.Cells.Item(4).Text = "Request Amount"
        Else
            e.Row.Cells(4).Text = CStr(e.Row.Cells(4).Text.ToString)
        End If
        ''''''''''''''''''''''''''''''''''''''''''''
        If e.Row.Cells.Item(5).Text = "&nbsp;" Then
            e.Row.Cells(5).Text = ""
        ElseIf e.Row.Cells.Item(5).Text = "Date Joined" Then
            e.Row.Cells.Item(5).Text = "Date Joined"
        Else
            e.Row.Cells(5).Text = Date.Parse(e.Row.Cells(5).Text).ToString("dd-MMM-yyyy")
        End If


        If e.Row.Cells.Item(7).Text = "&nbsp;" Then
            e.Row.Cells(7).Text = ""
        ElseIf e.Row.Cells.Item(7).Text = "Documents" Then
            e.Row.Cells.Item(7).Text = "Documents"
        Else
            If e.Row.Cells(7).Text <> "" Then
                e.Row.Cells(7).Text = "YES"
            End If
        End If

        'If e.Row.Cells.Item(8).Text = "&nbsp;" Then
        '    e.Row.Cells(8).Text = ""
        'ElseIf e.Row.Cells.Item(8).Text = "Printed" Then
        '    e.Row.Cells.Item(8).Text = "Printed"
        'Else
        '    If e.Row.Cells(8).Text = 1 Then
        '        e.Row.Cells(8).Text = "YES"
        '    End If
        'End If

        '   End If

    End Sub
    Sub grid_online_joined()




        Dim from_paydt As String
        Dim to_paydt As String
        from_paydt = Date.Parse(txtfrom.Text).ToString("yyyy-MM-dd")
        Session("from_paydt") = from_paydt
        to_paydt = Date.Parse(txtto.Text).ToString("yyyy-MM-dd")
        Session("to_paydt") = to_paydt
        Dim cmd_paydt As New SqlCommand
        Dim str_paydt As String
        cmd_paydt.Connection = open_con.return_con
        str_paydt = "SELECT Customer_ID, Given_Name, Last_Name, Date_Joined, Time_Joined, Request_Amount ,Current_Bank_Statement,cust_enable,email_sent,Email From Tbl_Customer WHERE Tbl_Customer.Request_Amount <> 0  AND  Date_Joined "
        str_paydt = str_paydt & " >= '" & from_paydt & "'  AND Date_Joined <=  '" & to_paydt & "' ORDER BY Date_Joined, Time_Joined"
        cmd_paydt.CommandText = str_paydt
        Dim dataadap_paydt As SqlDataAdapter
        Dim ds_paydt As New DataSet
        dataadap_paydt = New SqlDataAdapter(cmd_paydt)
        dataadap_paydt.Fill(ds_paydt)

        If ds_paydt.Tables(0).Rows.Count = 0 Then
            GridView1.Visible = False
            btnre.Visible = False
            btnview.Visible = False
            btnEmail.Visible = False
            cmd_paydt.Dispose()
            ds_paydt.Dispose()
            dataadap_paydt.Dispose()
            open_con.return_con.Dispose()
            Exit Sub
        Else
            GridView1.Visible = True
            GridView1.DataSource = ds_paydt
            GridView1.DataBind()
            btnre.Visible = True
            btnview.Visible = True
            btnEmail.Visible = True
            cmd_paydt.Dispose()
            ds_paydt.Dispose()
            dataadap_paydt.Dispose()
            open_con.return_con.Dispose()
        End If
    End Sub
    Protected Sub btnre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnre.Click

        Dim NewTime As DateTime
        NewTime = System.DateTime.Now.AddDays(-1)
        txtfrom.Text = NewTime.ToString("dd-MMM-yyyy")
        txtto.Text = System.DateTime.Now.Date.ToString("dd-MMM-yyyy")
        GridView1.Visible = False
        btnre.Visible = False
        btnview.Visible = False
        btnEmail.Visible = False

    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        Response.Redirect("Online_Rep.aspx", False)
        btnre.Visible = False
        btnview.Visible = False
        btnEmail.Visible = False
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Dim row_index As Integer
        row_index = GridView1.SelectedRow.RowIndex
        Dim customer_ID As Integer
        Dim cust_name As String


        customer_ID = GridView1.Rows(row_index).Cells.Item(1).Text
        open_con.customer_id_val = customer_ID

        cust_name = GridView1.Rows(row_index).Cells.Item(2).Text


        Session("Customer_name") = cust_name & " " & Session("branch_prefix") & " " & open_con.customer_id_val
        Session("Customer_namebank") = cust_name

        Response.Redirect("./detail.aspx", False)
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
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub

    Protected Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click
        Try
            Dim attachment As String = Server.MapPath("~/email") & "\P.ACT1.pdf"
            btnEmail.Enabled = False
            For Each gr As GridViewRow In GridView1.Rows
                Dim _lblCustID As Label = CType(gr.FindControl("lblCustID"), Label)
                Dim _lblCustName As Label = CType(gr.FindControl("lblCustName"), Label)
                Dim _lblCustEmail As Label = CType(gr.FindControl("lblCustEmail"), Label)
                Dim _chk As CheckBox = CType(gr.FindControl("chkCustID"), CheckBox)
                If _chk.Checked = True Then
                    If _lblCustEmail.Text <> "" Then
                        Dim client As New WebClient
                        Dim url As String = Context.Request.Url.ToString()
                        url = url.Replace("Customer/Online_Joined.aspx", "email/loan_preapproval.aspx?name=")
                        url = url & _lblCustName.Text()
                        Dim data As Stream = client.OpenRead(url)
                        Dim reader As New StreamReader(data)
                        Dim str As String = reader.ReadToEnd()
                        clsGeneral.SendMail(_lblCustEmail.Text, "Your Money Plus loan application", str, attachment)
                        Using obj As New clsCustomer()
                            obj.UpdateCustomerEmail(Integer.Parse(_lblCustID.Text))
                            obj.AddCustomerEmail(Integer.Parse(_lblCustID.Text), "Pre-approval Email Sent", str)
                        End Using
                    End If
                End If

            Next

            bindReport()
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Email has been successfully sent!!!" & "');", True)
        Catch ex As Exception
            Throw ex
        Finally
            btnEmail.Enabled = True
        End Try
    End Sub
End Class
