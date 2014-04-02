Imports System.Data.SqlClient
Imports System.Data
Partial Class Customer_enforcementletter
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try

                If Session("Description") = "Enforcement Letter" Then
                    Session("enf") = 1


                    Dim str_ACLN_enfrc As String
                    Dim str_enfrc, str_enfrc1 As String
                    str_ACLN_enfrc = "Australian Credit Licence Number 391104"

                    Dim cmd_enfrc As New SqlCommand
                    Dim adap_enfrc As SqlDataAdapter
                    Dim ds_enfrc As New DataSet

                    str_enfrc = "SELECT sys_Branch.Branch_ID, sys_User.Given_Name, sys_User.Last_Name "
                    str_enfrc = str_enfrc & " FROM sys_Branch INNER JOIN sys_User ON sys_Branch.Branch_ID = sys_User.Branch_ID "
                    str_enfrc = str_enfrc & " WHERE sys_User.User_Type='Manager' "

                    cmd_enfrc.CommandText = str_enfrc
                    cmd_enfrc.Connection = open_con.return_con
                    adap_enfrc = New SqlDataAdapter(cmd_enfrc)
                    adap_enfrc.Fill(ds_enfrc)

                    Dim cmd_enfrc1 As New SqlCommand
                    Dim adap_enfrc1 As SqlDataAdapter
                    Dim ds_enfrc1 As New DataSet
                    str_enfrc1 = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val


                    cmd_enfrc1.CommandText = str_enfrc1
                    cmd_enfrc1.Connection = open_con.return_con
                    adap_enfrc1 = New SqlDataAdapter(cmd_enfrc1)
                    adap_enfrc1.Fill(ds_enfrc1)

                    Dim str_SQL As String
                    Dim cmd_enfrc2 As New SqlCommand
                    Dim adap_enfrc2 As SqlDataAdapter
                    Dim ds_enfrc2 As New DataSet
                    Dim enfrc_Outstanding_Amount As String
                    str_SQL = "  SELECT Count(Tbl_Payment.Amount) as No_Of_Outstanding_Amount, Sum(Tbl_Payment.Amount) AS Outstanding_Amount "
                    str_SQL = str_SQL & "  FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID "
                    str_SQL = str_SQL & " WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND Tbl_Payment.Transaction_Status is NULL AND Tbl_Payment.Payment_Date is NULL AND Tbl_Payment.Payment_Status is NULL AND Tbl_Payment.Loan_ID=" & Session("enf_loan_id") & " AND Tbl_Payment_1.Update_ID Is Null "

                    cmd_enfrc2.CommandText = str_SQL
                    cmd_enfrc2.Connection = open_con.return_con
                    adap_enfrc2 = New SqlDataAdapter(cmd_enfrc2)
                    adap_enfrc2.Fill(ds_enfrc2)


                    If Not ds_enfrc2.Tables(0).Rows.Count = 0 Then


                        enfrc_Outstanding_Amount = open_con.newamount(open_con.check_amount_format(Math.Round(CDbl(ds_enfrc2.Tables(0).Rows(0).Item(1)), 2)))

                        Dim pos As Integer
                        pos = InStr(1, enfrc_Outstanding_Amount, ".")
                        If pos = 0 Then
                            lbllnamt.Text = enfrc_Outstanding_Amount & ".00"
                        Else
                            lbllnamt.Text = enfrc_Outstanding_Amount
                        End If

                    Else
                        enfrc_Outstanding_Amount = "0.0"
                        lbllnamt.Text = enfrc_Outstanding_Amount
                    End If

                    Dim str_SQL1 As String
                    Dim cmd_enfrc3 As New SqlCommand
                    Dim adap_enfrc3 As SqlDataAdapter
                    Dim ds_enfrc3 As New DataSet


                    str_SQL1 = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Title, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Customer.M_Address,Tbl_Customer.M_Street_Name, Tbl_Customer.M_Suburb, Tbl_Customer.M_State, Tbl_Customer.M_Post_Code, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code, Tbl_Notice.Loan_ID, Tbl_Notice.Amount_Outstanding, Tbl_Notice.Previous_Notice_Created_On, Tbl_Notice.Notice_Created_On, Tbl_Notice.Notice_ID,Tbl_Customer.Unit_No,Tbl_Customer.M_Unit_No "
                    str_SQL1 = str_SQL1 & " FROM Tbl_Customer INNER JOIN Tbl_Notice ON Tbl_Customer.Customer_ID = Tbl_Notice.Customer_ID "
                    str_SQL1 = str_SQL1 & " WHERE Tbl_Notice.Notice_ID = " & Session("Notice_ID")

                    cmd_enfrc3.CommandText = str_SQL1
                    cmd_enfrc3.Connection = open_con.return_con
                    adap_enfrc3 = New SqlDataAdapter(cmd_enfrc3)
                    adap_enfrc3.Fill(ds_enfrc3)

                    Dim day_noticecre, month_noticecre, year_noticecre As String
                    Dim month_cre As String
                    day_noticecre = Val(Left(Date.Parse(ds_enfrc3.Tables(0).Rows(0).Item("Notice_Created_On")).ToString("dd-MMM-yyyy"), 2))
                    month_noticecre = Date.Parse(ds_enfrc3.Tables(0).Rows(0).Item("Notice_Created_On")).Month
                    year_noticecre = Date.Parse(ds_enfrc3.Tables(0).Rows(0).Item("Notice_Created_On")).Year
                    Dim sup_string As String

                    If day_noticecre = 1 Then
                        sup_string = "<sup>st</sup>"
                    ElseIf day_noticecre = 21 Then
                        sup_string = "<sup>st</sup>"
                    ElseIf day_noticecre = 31 Then
                        sup_string = "<sup>st</sup>"
                    ElseIf day_noticecre = 2 Then
                        sup_string = "<sup>nd</sup>"
                    ElseIf day_noticecre = 22 Then
                        sup_string = "<sup>nd</sup>"
                    ElseIf day_noticecre = 3 Then
                        sup_string = "<sup>rd</sup>"
                    ElseIf day_noticecre = 23 Then
                        sup_string = "<sup>rd</sup>"
                    Else
                        sup_string = "<sup>th</sup>"
                    End If
                    If month_noticecre = "1" Then
                        month_cre = "January"

                        'Response.Write("<div style='position:absolute;top:340px;left:92px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                    ElseIf month_noticecre = "2" Then
                        month_cre = "February"

                        'Response.Write("<div style='position:absolute;top:340px;left:92px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                    ElseIf month_noticecre = "3" Then
                        month_cre = "March"

                        'Response.Write("<div style='position:absolute;top:340px;left:92px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                    ElseIf month_noticecre = "4" Then
                        month_cre = "April"

                        'Response.Write("<div style='position:absolute;top:340px;left:92px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                    ElseIf month_noticecre = "5" Then
                        month_cre = "May"

                        'Response.Write("<div style='position:absolute;top:340px;left:92px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                    ElseIf month_noticecre = "6" Then
                        month_cre = "June"

                        'Response.Write("<div style='position:absolute;top:340px;left:92px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                    ElseIf month_noticecre = "7" Then
                        month_cre = "July"

                        'Response.Write("<div style='position:absolute;top:340px;left:92px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                    ElseIf month_noticecre = "8" Then
                        month_cre = "August"

                        'Response.Write("<div style='position:absolute;top:340px;left:92px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                    ElseIf month_noticecre = "9" Then
                        month_cre = "September"

                        'Response.Write("<div style='position:absolute;top:340px;left:92px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                    ElseIf month_noticecre = "10" Then
                        month_cre = "October"

                        'Response.Write("<div style='position:absolute;top:340px;left:92px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                    ElseIf month_noticecre = "11" Then
                        month_cre = "November"

                        'Response.Write("<div style='position:absolute;top:340px;left:92px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                    ElseIf month_noticecre = "12" Then
                        month_cre = "December"

                        'Response.Write("<div style='position:absolute;top:340px;left:92px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre

                    End If


                    Dim str_SQL2 As String
                    Dim cmd_enfrc4 As New SqlCommand
                    Dim adap_enfrc4 As SqlDataAdapter
                    Dim ds_enfrc4 As New DataSet



                    str_SQL2 = " SELECT Tbl_Payment.Loan_ID, Tbl_Payment.Amount, Tbl_Payment.Payment_Method, Tbl_Payment.Due_Date,Tbl_Payment.Description, Tbl_Payment.Contract_Date "
                    str_SQL2 = str_SQL2 & " FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Payment_ID "
                    str_SQL2 = str_SQL2 & " WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND Tbl_Payment.Transaction_Status is null AND Tbl_Payment.Payment_Date is NULL "
                    str_SQL2 = str_SQL2 & " AND Tbl_Payment.Loan_ID= " & Session("enf_loan_id") & " AND Tbl_Payment.Amount <> 0 AND Tbl_Payment_1.Update_ID Is Null ORDER BY  Tbl_Payment.Contract_Date "

                    cmd_enfrc4.CommandText = str_SQL2
                    cmd_enfrc4.Connection = open_con.return_con
                    adap_enfrc4 = New SqlDataAdapter(cmd_enfrc4)
                    adap_enfrc.Fill(ds_enfrc4)


                    'lblstdetail.Text = ds_enfrc1.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_enfrc1.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_enfrc1.Tables(0).Rows(0).Item("Suburb").ToString & ", " & ds_enfrc1.Tables(0).Rows(0).Item("State").ToString & " " & ds_enfrc1.Tables(0).Rows(0).Item("Post_Code").ToString
                    'lblcnctdetail.Text = "Tel: " & ds_enfrc1.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_enfrc1.Tables(0).Rows(0).Item("Fax_Number").ToString
                    'lblph.Text = "Tel: " & ds_enfrc1.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_enfrc1.Tables(0).Rows(0).Item("Fax_Number").ToString
                    'lblemail.Text = "e-mail: " & ds_enfrc1.Tables(0).Rows(0).Item("Email").ToString
                    lbllnno.Text = ds_enfrc3.Tables(0).Rows(0).Item("Loan_ID")
                    lblname.Text = ds_enfrc3.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("Last_Name").ToString

                    If ds_enfrc3.Tables(0).Rows(0).Item("M_Address").ToString <> "" And ds_enfrc3.Tables(0).Rows(0).Item("M_Suburb").ToString <> "" Then
                        Dim M_Unit_No As String

                        M_Unit_No = Trim(ds_enfrc3.Tables(0).Rows(0).Item("M_Unit_No").ToString())
                        If Len(M_Unit_No) <> 0 Then

                            lbladd.Text = ds_enfrc3.Tables(0).Rows(0).Item("M_Unit_No").ToString & "/" & ds_enfrc3.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("M_Street_Name").ToString
                            lblst.Text = ds_enfrc3.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("M_Post_Code").ToString
                        Else
                            lbladd.Text = ds_enfrc3.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("M_Street_Name").ToString
                            lblst.Text = ds_enfrc3.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("M_Post_Code").ToString
                        End If

                    Else
                        Dim Unit_No As String

                        Unit_No = Trim(ds_enfrc3.Tables(0).Rows(0).Item("Unit_No").ToString())
                        If Len(Unit_No) <> 0 Then
                            lbladd.Text = ds_enfrc3.Tables(0).Rows(0).Item("Unit_No").ToString & "/" & ds_enfrc3.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("Street_Name").ToString
                            lblst.Text = ds_enfrc3.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("State").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("Post_Code").ToString

                        Else
                            lbladd.Text = ds_enfrc3.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("Street_Name").ToString
                            lblst.Text = ds_enfrc3.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("State").ToString & " " & ds_enfrc3.Tables(0).Rows(0).Item("Post_Code").ToString

                        End If

                    End If

                    If ds_enfrc3.Tables(0).Rows(0).Item("Title").ToString <> "" Then
                        lbltitle.Text = "Dear" & " " & ds_enfrc3.Tables(0).Rows(0).Item("Title").ToString & "  " & ds_enfrc3.Tables(0).Rows(0).Item("Last_Name").ToString

                    Else
                        lbltitle.Text = "Dear" & " " & ds_enfrc3.Tables(0).Rows(0).Item("Last_Name").ToString

                    End If

                    cmd_enfrc.Dispose()
                    cmd_enfrc1.Dispose()
                    cmd_enfrc2.Dispose()
                    cmd_enfrc3.Dispose()
                    cmd_enfrc4.Dispose()
                    ds_enfrc.Dispose()
                    ds_enfrc1.Dispose()
                    ds_enfrc2.Dispose()
                    ds_enfrc3.Dispose()
                    ds_enfrc4.Dispose()
                    adap_enfrc.Dispose()
                    adap_enfrc1.Dispose()
                    adap_enfrc2.Dispose()
                    adap_enfrc3.Dispose()
                    adap_enfrc4.Dispose()
                    open_con.return_con.Dispose()

                End If

            Catch ex As Exception
                Response.Write("Error: " & ex.Message)
            End Try
        End If

    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
