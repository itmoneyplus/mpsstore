Imports System.Data.SqlClient
Imports System.Data

Partial Class Customer_Contract_dishonour
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try

                If Session("Description") = "Contract Dishonour" Then

                    Dim cmd_str, cmd_str1, cmd_dis, cmd_dis1, cmd_dis2, cmd_dis3 As New SqlCommand
                    Dim str, str1, str_dis, str_dis1, str_dis2, str_dis3 As String
                    Dim str_adap, str1_adap, adap_dis, adap_dis1, adap_dis2, adap_dis3 As SqlDataAdapter
                    Dim ds_str, ds_str1, ds_dis, ds_dis1, ds_dis2, ds_dis3 As New DataSet
                    Dim int_variation, int_dishonour As Double
                    Dim str_ACLN As String
                    str_ACLN = "Australian Credit Licence Number 391104"


                    str = "SELECT sys_Branch.Branch_ID, sys_User.Given_Name, sys_User.Last_Name "
                    str = str & " FROM sys_Branch INNER JOIN sys_User ON sys_Branch.Branch_ID = sys_User.Branch_ID "
                    str = str & " WHERE sys_User.User_Type='Manager' "
                    cmd_str.CommandText = str
                    cmd_str.Connection = open_con.return_con
                    str_adap = New SqlDataAdapter(cmd_str)
                    str_adap.Fill(ds_str)


                    str1 = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val
                    cmd_str1.CommandText = str1
                    cmd_str1.Connection = open_con.return_con
                    str1_adap = New SqlDataAdapter(cmd_str1)
                    str1_adap.Fill(ds_str1)




                    str_dis = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Title, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Customer.M_Address,Tbl_Customer.M_Street_Name, Tbl_Customer.M_Suburb, Tbl_Customer.M_State, Tbl_Customer.M_Post_Code,Tbl_Customer.M_Unit_No,Tbl_Customer.Unit_No, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code, Tbl_Payment.Amount, Tbl_Payment.Due_Date, Tbl_Payment.Transaction_Date, Tbl_Payment.Notice_NO, "
                    str_dis = str_dis & " Tbl_Notice.Loan_ID, Tbl_Notice.Amount_Outstanding, Tbl_Notice.Notice_Created_On, Tbl_Notice.Notice_Created_On, Tbl_Notice.Payment_ID, Tbl_Notice.Notice_ID FROM (Tbl_Customer INNER JOIN Tbl_Payment ON Tbl_Customer.Customer_ID=Tbl_Payment.Customer_ID) INNER JOIN Tbl_Notice ON Tbl_Payment.Payment_ID=Tbl_Notice.Payment_ID "
                    str_dis = str_dis & " WHERE Tbl_Notice.Notice_ID = " & Session("Notice_ID")

                    cmd_dis.CommandText = str_dis
                    cmd_dis.Connection = open_con.return_con
                    adap_dis = New SqlDataAdapter(cmd_dis)
                    adap_dis.Fill(ds_dis)



                    str_dis1 = " SELECT Tbl_Payment.Due_Date FROM Tbl_Payment WHERE Loan_ID = " & ds_dis.Tables(0).Rows(0).Item("Loan_ID") & " AND Notice_NO = " & ds_dis.Tables(0).Rows(0).Item("Notice_ID") & " AND Date_Updated = @dt_dis_upd"
                    str_dis1 = str_dis1 & " AND Fee_Status is NULL"

                    cmd_dis1.CommandText = str_dis1
                    cmd_dis1.Parameters.Add("@dt_dis_upd", SqlDbType.DateTime).Value = ds_dis.Tables(0).Rows(0).Item("Transaction_Date")
                    cmd_dis1.Connection = open_con.return_con
                    adap_dis1 = New SqlDataAdapter(cmd_dis1)
                    adap_dis1.Fill(ds_dis1)


                    str_dis2 = " SELECT Tbl_Payment.Amount FROM Tbl_Payment WHERE Loan_ID = " & ds_dis.Tables(0).Rows(0).Item("Loan_ID") & " AND Notice_NO = " & ds_dis.Tables(0).Rows(0).Item("Notice_ID") & " AND Date_Updated = @dt_dis_upd"
                    str_dis2 = str_dis2 & " AND Fee_Status = 'Variation Fee'"

                    cmd_dis2.CommandText = str_dis2
                    cmd_dis2.Parameters.Add("@dt_dis_upd", SqlDbType.DateTime).Value = ds_dis.Tables(0).Rows(0).Item("Transaction_Date")
                    cmd_dis2.Connection = open_con.return_con
                    adap_dis2 = New SqlDataAdapter(cmd_dis2)
                    adap_dis2.Fill(ds_dis2)
                    If Not ds_dis2.Tables(0).Rows.Count = 0 Then
                        int_variation = Math.Round(CDbl(ds_dis2.Tables(0).Rows(0).Item("Amount")), 2)
                    Else
                        int_variation = 0.0
                    End If

                    str_dis3 = " SELECT Tbl_Payment.Amount FROM Tbl_Payment WHERE Loan_ID = " & ds_dis.Tables(0).Rows(0).Item("Loan_ID") & " AND Notice_NO = " & ds_dis.Tables(0).Rows(0).Item("Notice_ID") & " AND Date_Updated = @dt_dis_upd"
                    str_dis3 = str_dis3 & " AND Fee_Status = 'Dishonoured Fee'"

                    cmd_dis3.CommandText = str_dis3
                    cmd_dis3.Parameters.Add("@dt_dis_upd", SqlDbType.DateTime).Value = ds_dis.Tables(0).Rows(0).Item("Transaction_Date")
                    cmd_dis3.Connection = open_con.return_con
                    adap_dis3 = New SqlDataAdapter(cmd_dis3)
                    adap_dis3.Fill(ds_dis3)

                    If Not ds_dis3.Tables(0).Rows.Count = 0 Then
                        int_dishonour = Math.Round(CDbl(ds_dis3.Tables(0).Rows(0).Item("Amount")), 2)

                    Else
                        int_dishonour = 0
                    End If

                    lblstdetail.Text = ds_str1.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_str1.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_str1.Tables(0).Rows(0).Item("Suburb").ToString & ", " & ds_str1.Tables(0).Rows(0).Item("State").ToString & " " & ds_str1.Tables(0).Rows(0).Item("Post_Code").ToString
                    lblcnctdetail.Text = "Tel: " & ds_str1.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_str1.Tables(0).Rows(0).Item("Fax_Number").ToString

                    lbllnno.Text = ds_dis.Tables(0).Rows(0).Item("Loan_ID")
                    lblname.Text = ds_dis.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_dis.Tables(0).Rows(0).Item("Last_Name").ToString

                    If ds_dis.Tables(0).Rows(0).Item("M_Address").ToString <> "" And ds_dis.Tables(0).Rows(0).Item("M_Suburb").ToString <> "" Then

                        Dim M_Unit_No As String

                        M_Unit_No = Trim(ds_dis.Tables(0).Rows(0).Item("M_Unit_No").ToString())
                        If Len(M_Unit_No) <> 0 Then
                            lbladd.Text = ds_dis.Tables(0).Rows(0).Item("M_Unit_No").ToString & "/" & ds_dis.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_dis.Tables(0).Rows(0).Item("M_Street_Name").ToString
                            lblst.Text = ds_dis.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_dis.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_dis.Tables(0).Rows(0).Item("M_Post_Code").ToString
                        Else
                            lbladd.Text = ds_dis.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_dis.Tables(0).Rows(0).Item("M_Street_Name").ToString
                            lblst.Text = ds_dis.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_dis.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_dis.Tables(0).Rows(0).Item("M_Post_Code").ToString
                        End If


                    Else
                        Dim Unit_No As String

                        Unit_No = Trim(ds_dis.Tables(0).Rows(0).Item("Unit_No").ToString())
                        If Len(Unit_No) <> 0 Then
                            lbladd.Text = ds_dis.Tables(0).Rows(0).Item("Unit_No").ToString & "/" & ds_dis.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_dis.Tables(0).Rows(0).Item("Street_Name").ToString
                            lblst.Text = ds_dis.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_dis.Tables(0).Rows(0).Item("State").ToString & " " & ds_dis.Tables(0).Rows(0).Item("Post_Code").ToString

                        Else
                            lbladd.Text = ds_dis.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_dis.Tables(0).Rows(0).Item("Street_Name").ToString
                            lblst.Text = ds_dis.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_dis.Tables(0).Rows(0).Item("State").ToString & " " & ds_dis.Tables(0).Rows(0).Item("Post_Code").ToString

                        End If

                    End If

                    If ds_dis.Tables(0).Rows(0).Item("Title").ToString <> "" Then
                        lbltitle.Text = "Dear" & " " & ds_dis.Tables(0).Rows(0).Item("Title").ToString & "  " & ds_dis.Tables(0).Rows(0).Item("Last_Name").ToString

                    Else
                        lbltitle.Text = "Dear" & " " & ds_dis.Tables(0).Rows(0).Item("Last_Name").ToString

                    End If
                    Dim tot_amt As Double
                    tot_amt = open_con.check_amount_format(Math.Round(CDbl(ds_dis.Tables(0).Rows(0).Item("Amount")), 2))
                    lblamt.Text = open_con.newamount(tot_amt)
                    Dim dt As String
                    dt = Date.Parse(ds_dis.Tables(0).Rows(0).Item("Due_Date")).ToString("dd-MMM-yyyy")
                    lbldt.Text = dt.Replace("-", " ")

                    If Val(int_variation) <> 0 Then
                        lblvarfee.Text = open_con.new_amount(int_variation)
                    Else
                        lblvarfee.Text = "$0.00"
                    End If


                    If Val(int_dishonour) <> 0 Then

                        lblfee.Text = open_con.new_amount(int_dishonour)
                    Else
                        lblfee.Text = "$0.00"
                    End If

                    Dim day_noticecre, month_noticecre, year_noticecre As String
                    Dim month_cre As String
                    day_noticecre = Val(Left(Date.Parse(ds_dis.Tables(0).Rows(0).Item("Notice_Created_On")).ToString("dd-MMM-yyyy"), 2))
                    month_noticecre = Date.Parse(ds_dis.Tables(0).Rows(0).Item("Notice_Created_On")).Month
                    year_noticecre = Date.Parse(ds_dis.Tables(0).Rows(0).Item("Notice_Created_On")).Year
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

                        Response.Write("<div style='position:absolute;top:310px;left:62px;font-size:15.5px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")


                    ElseIf month_noticecre = "2" Then
                        month_cre = "February"


                        Response.Write("<div style='position:absolute;top:310px;left:62px;font-size:15.5px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")


                    ElseIf month_noticecre = "3" Then
                        month_cre = "March"

                        Response.Write("<div style='position:absolute;top:310px;left:62px;font-size:15.5px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")


                    ElseIf month_noticecre = "4" Then
                        month_cre = "April"

                        Response.Write("<div style='position:absolute;top:310px;left:62px;font-size:15.5px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")


                    ElseIf month_noticecre = "5" Then
                        month_cre = "May"

                        Response.Write("<div style='position:absolute;top:310px;left:62px;font-size:15.5px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")


                    ElseIf month_noticecre = "6" Then
                        month_cre = "June"

                        Response.Write("<div style='position:absolute;top:310px;left:62px;font-size:15.5px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")

                    ElseIf month_noticecre = "7" Then
                        month_cre = "July"

                        Response.Write("<div style='position:absolute;top:310px;left:62px;font-size:15.5px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")


                    ElseIf month_noticecre = "8" Then
                        month_cre = "August"

                        Response.Write("<div style='position:absolute;top:310px;left:62px;font-size:15.5px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")


                    ElseIf month_noticecre = "9" Then
                        month_cre = "September"

                        Response.Write("<div style='position:absolute;top:310px;left:62px;font-size:15.5px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")


                    ElseIf month_noticecre = "10" Then
                        month_cre = "October"

                        Response.Write("<div style='position:absolute;top:310px;left:62px;font-size:15.5px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")


                    ElseIf month_noticecre = "11" Then
                        month_cre = "November"

                        Response.Write("<div style='position:absolute;top:310px;left:62px;font-size:15.5px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")


                    ElseIf month_noticecre = "12" Then
                        month_cre = "December"

                        Response.Write("<div style='position:absolute;top:310px;left:62px;font-size:15.5px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")


                    End If
                    cmd_dis.Dispose()
                    cmd_dis1.Dispose()
                    cmd_dis2.Dispose()
                    cmd_dis3.Dispose()
                    adap_dis.Dispose()
                    adap_dis1.Dispose()
                    adap_dis2.Dispose()
                    adap_dis3.Dispose()
                    ds_dis.Dispose()
                    ds_dis1.Dispose()
                    ds_dis2.Dispose()
                    ds_dis3.Dispose()
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
