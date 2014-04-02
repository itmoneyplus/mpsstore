Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports System.Globalization
Imports System.Net
Imports System.IO
Partial Class toolbaar_Toolbaar2
    Inherits System.Web.UI.UserControl
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then
            Session("show") = 0
            Session("flag_approve") = False
            Dim str_SQL1 As String
            str_SQL1 = " SELECT Tbl_Loan.Amount, Tbl_Loan.Loan_Date,Tbl_Payment.Loan_ID, Tbl_Loan.Loan_Type, Tbl_Loan.Status, Tbl_Loan.Customer_ID "
            str_SQL1 = str_SQL1 & " FROM Tbl_Loan INNER JOIN Tbl_Payment ON Tbl_Loan.Loan_ID = Tbl_Payment.Loan_ID "
            str_SQL1 = str_SQL1 & "GROUP BY Tbl_Loan.Amount, Tbl_Loan.Loan_Date, Tbl_Payment.Loan_ID, Tbl_Loan.Loan_Type, Tbl_Loan.Status, Tbl_Loan.Customer_ID "
            str_SQL1 = str_SQL1 & " HAVING (((Tbl_Loan.Loan_Type)='Loan') AND ((Tbl_Loan.Customer_ID)='" & open_con.customer_id_val & "')) "
            str_SQL1 = str_SQL1 & " ORDER BY Tbl_Loan.Loan_Date DESC"

            Dim cmd_SQL1 As New SqlCommand
            Dim ds_SQL1 As New DataSet
            cmd_SQL1.CommandText = str_SQL1
            cmd_SQL1.Connection = open_con.return_con
            cmd_SQL1.ExecuteNonQuery()

            Dim adap_SQL1 As SqlDataAdapter
            adap_SQL1 = New SqlDataAdapter(cmd_SQL1)
            adap_SQL1.Fill(ds_SQL1)
            open_con.return_con.Dispose()

            Dim rows_count, loanid, noofdis, loan_status, amount As Integer
            Dim description, status, last_payment_date, last_notice As String
            Dim amountout As String
            Dim loan_date As Date

            Dim des_notice_date As String
            rows_count = ds_SQL1.Tables(0).Rows.Count
            drop_table()
            create_table()
            If rows_count = 0 Then
                GridView1.Visible = False
                Label5.Visible = True
                Label3.Visible = False
                Label4.Visible = False
                Label6.Visible = False
            Else
                For i = 0 To rows_count - 1

                    loanid = ds_SQL1.Tables(0).Rows(i).Item(2).ToString
                    amount = Convert.ToInt32(ds_SQL1.Tables(0).Rows(i).Item(0))
                    Session("loanid ") = loanid
                    loan_status = ds_SQL1.Tables(0).Rows(i).Item(4).ToString
                    If loan_status = 0 Then
                        status = "Pending"
                        Session("status") = status
                    ElseIf loan_status = 1 Then
                        status = "Approved"
                        Session("status") = status
                    Else
                        status = "Declined"
                        Session("status") = status


                    End If
                    loan_date = CDate(ds_SQL1.Tables(0).Rows(i).Item(1).ToString)
                    Session("loan_Date") = loan_date
                    amountout = fn_Amount_Outstanding(loanid)
                    Session("amountout") = amountout
                    noofdis = fn_No_Of_Dishonour(loanid)
                    Session("dishonours") = noofdis
                    description = fn_Last_Notice(loanid)
                    des_notice_date = fn_Last_Notice_date(loanid)
                    last_payment_date = fn_Last_payment_date(open_con.customer_id_val, loanid)
                    Session("last_payment_date") = last_payment_date
                    last_notice = description & " " & des_notice_date
                    Session("lastnotice") = last_notice
                    Dim t As DateTime
                    insert_table(i + 1, loan_date, loanid, amountout, amount, last_notice, last_payment_date, noofdis, status, t)


                Next i

                bind_grid()
                Label5.Visible = False
                Label3.Visible = True
                Label4.Visible = True
                Label6.Visible = True

                Dim pos As Integer
                pos = InStr(1, Session("Show"), ".")
                If pos = 0 Then
                    Label4.Text = Session("Show") & ".00"
                Else
                    Dim amtot As String
                    amtot = Session("Show")
                    Label4.Text = open_con.newamount(amtot)
                End If

            End If

            ds_SQL1.Dispose()
            adap_SQL1.Dispose()
            cmd_SQL1.Dispose()
            bindEmails()
        End If

       
    End Sub
    Private Sub bindEmails()
        Try
            Using obj As New clsCustomer()
                Dim ds As DataSet = obj.GetCustomerEmails(open_con.customer_id_val)
                If (ds.Tables(0).Rows.Count > 0) Then
                    gvEmail.DataSource = ds
                    gvEmail.DataBind()
                    trEmail.Visible = True
                Else
                    trEmail.Visible = False
                    gvEmail.DataSource = Nothing
                    gvEmail.DataBind()
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Function fn_Amount_Outstanding(ByVal intLoan As Integer) As String


        Dim str_SQL2 As String

        str_SQL2 = " SELECT Tbl_Payment.Loan_ID, Sum(Tbl_Payment.Amount) AS Amount_Outstanding FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID = Tbl_Payment_1.Update_ID "
        str_SQL2 = str_SQL2 & " WHERE (((Tbl_Payment.Description)='Arear notice fee' Or (Tbl_Payment.Description)='Statement of account fee' Or (Tbl_Payment.Description)='Variation fee' Or (Tbl_Payment.Description)='Default notice fee' Or (Tbl_Payment.Description)='Letter of demand fee' Or (Tbl_Payment.Description)='Dishonoured fee' Or (Tbl_Payment.Description)='Enforcement fee' Or (Tbl_Payment.Description) Is Null OR Tbl_Payment.Description = '') AND ((Tbl_Payment.Transaction_Status) Is Null) AND ((Tbl_Payment.Payment_Date) Is Null) AND ((Tbl_Payment_1.Update_ID) Is Null)) "
        str_SQL2 = str_SQL2 & " GROUP BY Tbl_Payment.Loan_ID HAVING (((Tbl_Payment.Loan_ID)= " & intLoan & ")) ORDER BY Tbl_Payment.Loan_ID "
        Dim cmd_SQL2 As New SqlCommand
        Dim ds_SQL2 As New DataSet

        cmd_SQL2.CommandText = str_SQL2
        cmd_SQL2.Connection = open_con.return_con
        cmd_SQL2.ExecuteNonQuery()
        Dim adap_SQL2 As SqlDataAdapter
        adap_SQL2 = New SqlDataAdapter(cmd_SQL2)
        adap_SQL2.Fill(ds_SQL2)

        Dim intAmount, intamount1, intamount2 As String

        Dim i As Integer = 0

        If i <> ds_SQL2.Tables(0).Rows.Count Then
            Dim pos As Integer
            pos = InStr(1, ds_SQL2.Tables(0).Rows(0).Item(1).ToString, ".")
            intamount1 = ds_SQL2.Tables(0).Rows(0).Item(1).ToString.Substring(pos, 2)
            intamount2 = ds_SQL2.Tables(0).Rows(0).Item(1).ToString.Substring(0, pos - 1)
            intAmount = "$" + intamount2 + "." + intamount1

        Else
            intAmount = 0.0
        End If

        ds_SQL2 = Nothing
        open_con.return_con.Dispose()

        fn_Amount_Outstanding = intAmount


    End Function

    Function fn_No_Of_Dishonour(ByVal int_Loan As Integer) As Integer
        Try
            Dim str_dishonour As String
            str_dishonour = " SELECT Tbl_Payment.Loan_ID, Count(Tbl_Payment.Transaction_Status) AS SUM_Dishonours FROM Tbl_Payment "
            str_dishonour = str_dishonour & " GROUP BY Tbl_Payment.Loan_ID, Tbl_Payment.Transaction_Status "
            str_dishonour = str_dishonour & " HAVING (((Tbl_Payment.Loan_ID)= " & int_Loan & ") AND ((Tbl_Payment.Transaction_Status)='Dishonour'))"

            Dim cmd_dishonour As New SqlCommand
            Dim ds_dishonour As New DataSet

            cmd_dishonour.CommandText = str_dishonour
            cmd_dishonour.Connection = open_con.return_con
            cmd_dishonour.ExecuteNonQuery()

            Dim adap_dishonour As SqlDataAdapter
            adap_dishonour = New SqlDataAdapter(cmd_dishonour)
            adap_dishonour.Fill(ds_dishonour)
            Dim intLoanID As Integer
            If ds_dishonour.Tables(0).Rows.Count <> 0 Then
                intLoanID = ds_dishonour.Tables(0).Rows(0).Item(1).ToString
            End If

            ds_dishonour = Nothing
            open_con.return_con.Dispose()

            fn_No_Of_Dishonour = intLoanID
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Function
    Function fn_Last_Notice(ByVal int_ID As Integer) As String

        Dim str_notice As String
        str_notice = " SELECT MAX(Tbl_Notice.Loan_ID) AS Loan_ID, MAX(Tbl_Notice.Notice_Expires_On) AS Notice_Expires_On, MAX(Tbl_Notice.Notice_Created_On) AS Notice_Created_On, MAX(Tbl_Notice.Description) AS Description, Tbl_Notice.Customer_ID "
        str_notice = str_notice & " FROM Tbl_Notice WHERE (Tbl_Notice.Description <> '') "
        str_notice = str_notice & " GROUP BY Tbl_Notice.Customer_ID, Tbl_Notice.Loan_ID "
        str_notice = str_notice & " HAVING Tbl_Notice.Customer_ID = '" & open_con.customer_id_val & "'"

        Dim cmd_notice As New SqlCommand
        Dim ds_notice As New DataSet
        Dim dr As SqlDataReader
        cmd_notice.CommandText = str_notice
        cmd_notice.Connection = open_con.return_con
        dr = cmd_notice.ExecuteReader

        Dim str_Notice_Description As String
        str_Notice_Description = ""
        Do While dr.Read
            If dr.Item("loan_ID") = int_ID Then
                str_Notice_Description = dr.Item("Description")

                Exit Do
            End If

        Loop
        open_con.return_con.Dispose()
        fn_Last_Notice = str_Notice_Description




    End Function
    Function fn_Last_Notice_date(ByVal int_ID As Integer) As String


        Dim str_notice As String
        str_notice = " SELECT MAX(Tbl_Notice.Loan_ID) AS Loan_ID, MAX(Tbl_Notice.Notice_Expires_On) AS Notice_Expires_On, MAX(Tbl_Notice.Notice_Created_On) AS Notice_Created_On, MAX(Tbl_Notice.Description) AS Description, Tbl_Notice.Customer_ID "
        str_notice = str_notice & " FROM Tbl_Notice WHERE (Tbl_Notice.Description <> '') "
        str_notice = str_notice & " GROUP BY Tbl_Notice.Customer_ID, Tbl_Notice.Loan_ID "
        str_notice = str_notice & " HAVING Tbl_Notice.Customer_ID = '" & open_con.customer_id_val & "'"

        Dim cmd_notice As New SqlCommand
        Dim dr As SqlDataReader
        cmd_notice.CommandText = str_notice
        cmd_notice.Connection = open_con.return_con
        dr = cmd_notice.ExecuteReader
        Dim str_Notice_Date As String
        str_Notice_Date = ""

        Do While dr.Read
            If dr.Item("loan_ID") = int_ID Then
                str_Notice_Date = dr.Item("Notice_Created_On")
                Exit Do
            End If

        Loop
        open_con.return_con.Dispose()
        fn_Last_Notice_date = str_Notice_Date


    End Function
    Function fn_Last_payment_date(ByVal cust_id As Integer, ByVal loan_id As Integer) As String

        Dim str As String
        str = "Select MAX(payment_Date)  from Tbl_Payment where Customer_ID =" & cust_id & "and Loan_ID =" & loan_id & " and Payment_Status ='Paid'"
        Dim cmd_Last_payment_date As New SqlCommand
        Dim ds_Last_payment_date As New DataSet

        cmd_Last_payment_date.CommandText = str
        cmd_Last_payment_date.Connection = open_con.return_con
        cmd_Last_payment_date.ExecuteNonQuery()
        Dim adap As SqlDataAdapter
        adap = New SqlDataAdapter(cmd_Last_payment_date)
        adap.Fill(ds_Last_payment_date)
        Dim str_lastpayment_Date As String
        str_lastpayment_Date = ds_Last_payment_date.Tables(0).Rows(0).Item(0).ToString

        If str_lastpayment_Date = "" Then
            fn_Last_payment_date = str_lastpayment_Date
        Else
            Dim str_lastpayment_Date1 As Date
            str_lastpayment_Date1 = CDate(ds_Last_payment_date.Tables(0).Rows(0).Item(0).ToString)
            fn_Last_payment_date = str_lastpayment_Date1
        End If


        open_con.return_con.Dispose()

    End Function


    Protected Sub create_table()
        Try

            Dim cmd_table As New SqlCommand
            cmd_table.CommandText = "create table userdata(customer_id int,no int NOT NULL,loan_date date null,loan_id int null,amountout varchar (50) null,amount int null,last_notice varchar(50) null,last_paymentdate varchar(50) null,noofdis int null,status varchar(50) null,t datetime)"
            cmd_table.Connection = open_con.return_con
            cmd_table.ExecuteNonQuery()
            cmd_table.Dispose()
            open_con.return_con.Dispose()
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try



    End Sub

    Protected Sub insert_table(ByVal no As Integer, ByVal loan_date As Date, ByVal loanid As Integer, ByVal amountout As String, ByVal amount As Integer, ByVal last_notice As String, ByVal last_payment_date As String, ByVal noofdis As Integer, ByVal status As String, ByVal t As DateTime)

        Try

            Dim cmd_insert_table As New SqlCommand
            cmd_insert_table.CommandText = "insert into userdata values(@customer_id,@no,@loan_date ,@loan_id ,@amountout ,@amount, @last_notice,@last_paymentdate,@noofdis ,@status,@t )"
            cmd_insert_table.Parameters.Add("@customer_id", SqlDbType.Int).Value = open_con.customer_id_val
            cmd_insert_table.Parameters.Add("@no", SqlDbType.Int).Value = no
            cmd_insert_table.Parameters.Add("@loan_date", SqlDbType.Date).Value = loan_date
            If CStr(loanid) <> "" Then
                Session("loanid ") = loanid
            Else
                Session("loanid ") = 0
            End If
            cmd_insert_table.Parameters.Add("@loan_id", SqlDbType.Int).Value = loanid
            cmd_insert_table.Parameters.Add("@amountout", SqlDbType.VarChar, 50).Value = amountout
            cmd_insert_table.Parameters.Add("@amount", SqlDbType.Int).Value = amount
            cmd_insert_table.Parameters.Add("@last_notice", SqlDbType.VarChar, 50).Value = last_notice
            cmd_insert_table.Parameters.Add("@last_paymentdate", SqlDbType.VarChar, 50).Value = last_payment_date
            cmd_insert_table.Parameters.Add("@noofdis", SqlDbType.Int).Value = noofdis
            cmd_insert_table.Parameters.Add("@status", SqlDbType.VarChar, 50).Value = status
            cmd_insert_table.Parameters.Add("@t", SqlDbType.DateTime).Value = DateTime.Now
            cmd_insert_table.Connection = open_con.return_con
            cmd_insert_table.ExecuteNonQuery()
            open_con.return_con.Dispose()
            cmd_insert_table.Dispose()

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Protected Sub bind_grid()
        Try
            Dim cmd_bind_grid As New SqlCommand
            'cmd_bind_grid.CommandText = "Select * from userdata ORDER BY loan_id desc"
            cmd_bind_grid.CommandText = "SELECT 	userdata.*, CAST(isnull(Tbl_Loan.Email_approved,0) AS int) AS Email_approved, CAST(isnull(Tbl_Loan.Email_Transfer,0) AS int) AS Email_Transfer,Tbl_Customer.Email FROM userdata INNER JOIN Tbl_Loan ON Tbl_Loan.Loan_ID = userdata.loan_id  INNER JOIN Tbl_Customer ON Tbl_Customer.Customer_ID = userdata.customer_id ORDER BY loan_id DESC "
            cmd_bind_grid.Connection = open_con.return_con
            cmd_bind_grid.ExecuteNonQuery()
            Dim adap_bind_grid As SqlDataAdapter
            adap_bind_grid = New SqlDataAdapter(cmd_bind_grid)
            Dim ds_bind_grid As New DataSet
            adap_bind_grid.Fill(ds_bind_grid)
            GridView1.DataSource = ds_bind_grid
            GridView1.DataBind()
            cmd_bind_grid.Dispose()
            adap_bind_grid.Dispose()

            Dim cmd_tot_out As New SqlCommand
            cmd_tot_out.CommandText = "select amountout from userdata where status<>'Declined'"
            cmd_tot_out.Connection = open_con.return_con
            cmd_tot_out.ExecuteNonQuery()
            Dim adap_tot_out As SqlDataAdapter
            adap_tot_out = New SqlDataAdapter(cmd_tot_out)
            Dim ds_tot_out As New DataSet
            adap_tot_out.Fill(ds_tot_out)
            For i As Integer = 0 To ds_tot_out.Tables(0).Rows.Count - 1
                Dim out_amt As Double
                out_amt = Left(ds_tot_out.Tables(0).Rows(i).Item(0), 8)
                Dim amt As Double
                amt = amt + out_amt
                Session("show") = amt
            Next

            cmd_tot_out.Dispose()
            ds_tot_out.Dispose()
            adap_tot_out.Dispose()
            open_con.return_con.Dispose()
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try

    End Sub
    Protected Sub drop_table()
        Try

            Dim cmd_droptable As New SqlCommand
            cmd_droptable.CommandText = "drop table userdata"
            cmd_droptable.Connection = open_con.return_con
            cmd_droptable.ExecuteNonQuery()
            cmd_droptable.Dispose()
            open_con.return_con.Dispose()
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try



    End Sub


    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Session("letter") = 0
        Session("bank_nom") = False
        Session("sch_history") = 0
        Session("loan_st") = 0
        Session("pay_re") = False
        Session("pay_sch") = False
        Dim row_index As Integer
        row_index = GridView1.SelectedRow.RowIndex
        Session("flag_beginning") = True
        Session("nominate_msg") = False
        Session("beg_loan_id") = GridView1.Rows(row_index).Cells.Item(3).Text
        Session("beg_status") = GridView1.Rows(row_index).Cells.Item(10).Text
        Session("vis_status") = ""
        Response.Redirect("LoanSummary.aspx", False)


    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow And open_con.customer_status(open_con.customer_id_val).status = False And open_con.followup_status(open_con.customer_id_val) = False Then

            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='none';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("ondblClick", Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex))

        ElseIf e.Row.RowType = DataControlRowType.DataRow And open_con.customer_status(open_con.customer_id_val).status = True Then
            lbldebt.Text = "Debt Recovery"
            lbldebt.Visible = True
            lbldebt_date.Visible = True
            Dim cust_Date As Date
            cust_Date = CDate(open_con.customer_status(open_con.customer_id_val).status_date)
            lbldebt_date.Text = cust_Date.ToLongDateString
        ElseIf e.Row.RowType = DataControlRowType.DataRow And open_con.followup_status(open_con.customer_id_val) = True Then
            lbldebt.Text = "FollowUp Client"
            lbldebt.Visible = True


        End If

    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        e.Row.Cells(1).Visible = False
        If e.Row.Cells.Item(4).Text = "&nbsp;" Then
            e.Row.Cells(4).Text = ""
        ElseIf e.Row.Cells.Item(4).Text = "Amount Outstanding" Then
            e.Row.Cells.Item(4).Text = "Amount Outstanding"
        ElseIf e.Row.Cells(4).Text = 0 Then
            e.Row.Cells(4).Text = "$" & "0.0"
        Else

        End If
        If e.Row.Cells.Item(10).Text = "&nbsp;" Then
            e.Row.Cells(10).Text = ""
        ElseIf e.Row.Cells.Item(10).Text = "Status" Then
            e.Row.Cells.Item(10).Text = "Status"
        ElseIf e.Row.Cells.Item(10).Text = "Approved" Or e.Row.Cells.Item(10).Text = "Pending" Then
            e.Row.Cells(6).Text = ""
        ElseIf e.Row.Cells(10).Text = "Declined" Then
            e.Row.BackColor = Drawing.Color.Silver
            e.Row.Cells(4).Text = ""
            e.Row.Cells(5).Text = ""

            e.Row.Cells(0).Enabled = True
            e.Row.Cells(1).Enabled = True
            e.Row.Cells(2).Enabled = True
            e.Row.Cells(3).Enabled = True
            e.Row.Cells(4).Enabled = True
            e.Row.Cells(5).Enabled = True
            e.Row.Cells(6).Enabled = True
            e.Row.Cells(7).Enabled = True
            e.Row.Cells(8).Enabled = True
            e.Row.Cells(9).Enabled = True
            e.Row.Cells(10).Enabled = True

        Else

        End If
    End Sub

    Protected Sub gvEmail_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEmail.RowCommand
        If e.CommandName = "print" Then
            Dim index = Convert.ToInt32(e.CommandArgument)
            Dim row = gvEmail.Rows(index)

            Dim _panel As Panel = CType(row.FindControl("pnlPrint"), Panel)
            Dim lblText As Label = CType(row.FindControl("lblText"), Label)
            Session("ctrl") = _panel
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('../Reports/Print.aspx','PrintMe','height=600px,width=680px,scrollbars=1');</script>")
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "approved" Then
            Dim loadID As String = e.CommandArgument
            Response.Redirect("~/Customer/Loan_Aprroved_Email.aspx?lid=" & loadID, False)
        ElseIf e.CommandName = "transfer" Then
            Dim client As New WebClient
            Dim LoanId As String = e.CommandArgument
            Dim url As String = Context.Request.Url.ToString().ToLower()
            url = url.Replace("customer/detail.aspx", "email/loan_transfer.aspx?lid=")
            url = url & LoanId
            ' Dim data As Stream = client.OpenRead(url)
            'Dim reader As New StreamReader(data)
            ' Dim str As String = reader.ReadToEnd()
            Dim str As String = clsGeneral.GetHttpResponse(url)
            Dim mailbody As String = str 'clsGeneral.ScreenScrapeHtml(url)

            Dim gvr As GridViewRow = TryCast(DirectCast(e.CommandSource, Control).Parent.Parent, GridViewRow)
            Dim _lblEmail As String = CType(gvr.FindControl("lblEmail"), Label).Text
            Dim _lblCustID As String = CType(gvr.FindControl("lblCustID"), Label).Text
            clsGeneral.SendMail(_lblEmail, "Moneyplus - Netlending (Online)", mailbody, "")
            Using objLoan As New clsLoan()
                objLoan.UpdateLoanEmail(LoanId, _lblCustID, 2)
            End Using
            Using obj As New clsCustomer()
                obj.AddCustomerEmail(_lblCustID.ToString(), "Transfer Email - Loan ID:" & LoanId, mailbody, LoanId)
            End Using
            '   bind_grid()

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Email has been successfully sent!!!" & "');", True)

        End If
        bindEmails()
    End Sub
End Class

