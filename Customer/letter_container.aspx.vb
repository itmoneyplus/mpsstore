Imports System.Data.SqlClient
Imports System
Imports System.Data
Partial Class Customer_letter_container
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Dim cmd_str, cmd_str1, cmd_Notices, cmd_variation, cmd_DueDate, cmd_dishonour As New SqlCommand
    Dim str_adap, str1_adap, adap_Notices, adap_variation, adap_DueDate, adap_dishonour As SqlDataAdapter
    Dim ds_str, ds_str1, ds_Notices, ds_variation, ds_DueDate, ds_dishonour As New DataSet
  
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try


                Dim str_ACLN As String
                str_ACLN = "Australian Credit Licence Number 391104"
                Dim str, str1, str2, str3, str4, str5 As String
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



                If Session("Description") = "Dishonour Letter" Then

                    str2 = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Title, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Customer.M_Address,Tbl_Customer.M_Street_Name,Tbl_Customer.M_Suburb, Tbl_Customer.M_State, Tbl_Customer.M_Post_Code, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code, Tbl_Payment.Amount, Tbl_Payment.Due_Date, Tbl_Payment.Transaction_Date, Tbl_Payment.Notice_NO,Tbl_Customer.Unit_No,Tbl_Customer.M_Unit_No, "
                    str2 = str2 & " Tbl_Notice.Loan_ID, Tbl_Notice.Amount_Outstanding, Tbl_Notice.Notice_Created_On, Tbl_Notice.Notice_Created_On, Tbl_Notice.Payment_ID, Tbl_Notice.Notice_ID FROM (Tbl_Customer INNER JOIN Tbl_Payment ON Tbl_Customer.Customer_ID=Tbl_Payment.Customer_ID) INNER JOIN Tbl_Notice ON Tbl_Payment.Payment_ID=Tbl_Notice.Payment_ID "
                    str2 = str2 & " WHERE Tbl_Notice.Notice_ID = '" & Session("Notice_ID") & "'"
                    cmd_Notices.CommandText = str2
                    cmd_Notices.Connection = open_con.return_con
                    adap_Notices = New SqlDataAdapter(cmd_Notices)
                    adap_Notices.Fill(ds_Notices)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    str3 = " SELECT Tbl_Payment.Due_Date FROM Tbl_Payment WHERE Loan_ID = " & ds_Notices.Tables(0).Rows(0).Item("Loan_ID") & " AND Notice_NO = " & ds_Notices.Tables(0).Rows(0).Item("Notice_ID") & " AND Date_Updated = '" & Date.Parse(ds_Notices.Tables(0).Rows(0).Item("Transaction_Date")).ToString("yyyy-MM-dd") & "'"
                    str3 = str3 & " AND Fee_Status is NULL"

                    cmd_DueDate.CommandText = str3

                    cmd_DueDate.Connection = open_con.return_con
                    adap_DueDate = New SqlDataAdapter(cmd_DueDate)
                    adap_DueDate.Fill(ds_DueDate)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    str4 = " SELECT Tbl_Payment.Amount FROM Tbl_Payment WHERE Loan_ID = " & ds_Notices.Tables(0).Rows(0).Item("Loan_ID") & " AND Notice_NO = " & ds_Notices.Tables(0).Rows(0).Item("Notice_ID") & " AND Date_Updated = '" & Date.Parse(ds_Notices.Tables(0).Rows(0).Item("Transaction_Date")).ToString("yyyy-MM-dd") & "'"
                    str4 = str4 & " AND Fee_Status ='Variation Fee'"

                    cmd_variation.CommandText = str4
                    cmd_variation.Connection = open_con.return_con
                    adap_variation = New SqlDataAdapter(cmd_variation)
                    adap_variation.Fill(ds_variation)

                    Dim int_variation As Double
                    If Not ds_variation.Tables(0).Rows.Count = 0 Then
                        int_variation = CDbl(Math.Round(ds_variation.Tables(0).Rows(0).Item("Amount"), 2))
                    Else
                        int_variation = 0.0
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    str5 = " SELECT Tbl_Payment.Amount FROM Tbl_Payment WHERE Loan_ID = " & ds_Notices.Tables(0).Rows(0).Item("Loan_ID") & " AND Notice_NO = " & ds_Notices.Tables(0).Rows(0).Item("Notice_ID") & " AND Date_Updated = '" & Date.Parse(ds_Notices.Tables(0).Rows(0).Item("Transaction_Date")).ToString("yyyy-MM-dd") & "'"
                    str5 = str5 & " AND Fee_Status = 'Dishonoured Fee'"

                    cmd_dishonour.CommandText = str5
                    cmd_dishonour.Connection = open_con.return_con
                    adap_dishonour = New SqlDataAdapter(cmd_dishonour)
                    adap_dishonour.Fill(ds_dishonour)

                    Dim int_Dishonour As Double
                    If Not ds_dishonour.Tables(0).Rows.Count = 0 Then
                        int_Dishonour = CDbl(Math.Round(ds_dishonour.Tables(0).Rows(0).Item("Amount"), 2))
                    Else
                        int_Dishonour = 0.0
                    End If





                    'lblstdetail.Text = ds_str1.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_str1.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_str1.Tables(0).Rows(0).Item("Suburb").ToString & ", " & ds_str1.Tables(0).Rows(0).Item("State").ToString & " " & ds_str1.Tables(0).Rows(0).Item("Post_Code").ToString
                    'lblstdetail1.Text = ds_str1.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_str1.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_str1.Tables(0).Rows(0).Item("Suburb").ToString & ", " & ds_str1.Tables(0).Rows(0).Item("State").ToString & " " & ds_str1.Tables(0).Rows(0).Item("Post_Code").ToString
                    'lblstdetail2.Text = ds_str1.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_str1.Tables(0).Rows(0).Item("Street_Name").ToString & ", " & ds_str1.Tables(0).Rows(0).Item("Suburb").ToString & ", " & ds_str1.Tables(0).Rows(0).Item("State").ToString & " " & ds_str1.Tables(0).Rows(0).Item("Post_Code").ToString

                    'lblcnctdetail.Text = "Tel: " & ds_str1.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_str1.Tables(0).Rows(0).Item("Fax_Number").ToString
                    'lblcnctdetail1.Text = "Tel: " & ds_str1.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_str1.Tables(0).Rows(0).Item("Fax_Number").ToString
                    'lblcnctdetail2.Text = "Tel: " & ds_str1.Tables(0).Rows(0).Item("Phone_Number").ToString & "  " & "Fax: " & ds_str1.Tables(0).Rows(0).Item("Fax_Number").ToString

                    Dim day_noticecre, month_noticecre, year_noticecre As String
                    Dim month_cre As String
                    day_noticecre = Val(Left(Date.Parse(ds_Notices.Tables(0).Rows(0).Item("Notice_Created_On")).ToString("dd-MMM-yyyy"), 2))
                    month_noticecre = Date.Parse(ds_Notices.Tables(0).Rows(0).Item("Notice_Created_On")).Month
                    year_noticecre = Date.Parse(ds_Notices.Tables(0).Rows(0).Item("Notice_Created_On")).Year
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

                        'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:1350px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:2330px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate2.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate3.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                    ElseIf month_noticecre = "2" Then
                        month_cre = "February"

                        'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:1350px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:2330px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate2.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate3.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                    ElseIf month_noticecre = "3" Then
                        month_cre = "March"

                        'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:1350px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:2330px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate2.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate3.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                    ElseIf month_noticecre = "4" Then
                        month_cre = "April"

                        'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:1350px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:2330px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate2.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate3.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                    ElseIf month_noticecre = "5" Then
                        month_cre = "May"

                        'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:1350px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:2330px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate2.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate3.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                    ElseIf month_noticecre = "6" Then
                        month_cre = "June"

                        'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:1350px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:2330px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate2.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate3.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                    ElseIf month_noticecre = "7" Then
                        month_cre = "July"

                        'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:1350px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:2330px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate2.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate3.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                    ElseIf month_noticecre = "8" Then
                        month_cre = "August"

                        'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:1350px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:2330px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate2.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate3.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                    ElseIf month_noticecre = "9" Then
                        month_cre = "September"

                        'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:1350px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:2330px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate2.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate3.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                    ElseIf month_noticecre = "10" Then
                        month_cre = "October"

                        'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:1350px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:2330px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate2.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate3.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                    ElseIf month_noticecre = "11" Then
                        month_cre = "November"

                        'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:1350px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:2330px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate2.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate3.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                    ElseIf month_noticecre = "12" Then
                        month_cre = "December"

                        'Response.Write("<div style='position:absolute;top:370px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:1350px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        'Response.Write("<div style='position:absolute;top:2330px;left:65px;font-size:14px'>" & day_noticecre & sup_string & " " & month_cre & " " & year_noticecre & "</div>")
                        lbldate1.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate2.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                        lbldate3.Text = day_noticecre & sup_string & " " & month_cre & " " & year_noticecre
                    End If


                    lblloanid.Text = ds_Notices.Tables(0).Rows(0).Item("Loan_ID")
                    lblloanid1.Text = ds_Notices.Tables(0).Rows(0).Item("Loan_ID")
                    lblloanid2.Text = ds_Notices.Tables(0).Rows(0).Item("Loan_ID")

                    lblname.Text = ds_Notices.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Last_Name").ToString
                    lblname1.Text = ds_Notices.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Last_Name").ToString
                    lblname2.Text = ds_Notices.Tables(0).Rows(0).Item("Given_Name").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Last_Name").ToString

                    If ds_Notices.Tables(0).Rows(0).Item("M_Address").ToString <> "" And ds_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString <> "" Then
                        Dim M_Unit_No As String

                        M_Unit_No = Trim(ds_Notices.Tables(0).Rows(0).Item("M_Unit_No").ToString())

                        If Len(M_Unit_No) <> 0 Then
                            lbladd.Text = ds_Notices.Tables(0).Rows(0).Item("M_Unit_No").ToString & "/" & ds_Notices.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_Street_Name").ToString
                            lblst.Text = ds_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_Post_Code").ToString
                            lbladd1.Text = ds_Notices.Tables(0).Rows(0).Item("M_Unit_No").ToString & "/" & ds_Notices.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_Street_Name").ToString
                            lblst1.Text = ds_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_Post_Code").ToString
                            lbladd2.Text = ds_Notices.Tables(0).Rows(0).Item("M_Unit_No").ToString & "/" & ds_Notices.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_Street_Name").ToString
                            lblst2.Text = ds_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_Post_Code").ToString
                        Else
                            lbladd.Text = ds_Notices.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_Street_Name").ToString
                            lblst.Text = ds_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_Post_Code").ToString
                            lbladd1.Text = ds_Notices.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_Street_Name").ToString
                            lblst1.Text = ds_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_Post_Code").ToString
                            lbladd2.Text = ds_Notices.Tables(0).Rows(0).Item("M_Address").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_Street_Name").ToString
                            lblst2.Text = ds_Notices.Tables(0).Rows(0).Item("M_Suburb").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_State").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("M_Post_Code").ToString
                        End If
                    Else
                        Dim Unit_No As String

                        Unit_No = Trim(ds_Notices.Tables(0).Rows(0).Item("Unit_No").ToString())
                        If Len(Unit_No) <> 0 Then
                            lbladd.Text = ds_Notices.Tables(0).Rows(0).Item("Unit_No").ToString & "/" & ds_Notices.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Street_Name").ToString
                            lblst.Text = ds_Notices.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("State").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Post_Code").ToString
                            lbladd1.Text = ds_Notices.Tables(0).Rows(0).Item("Unit_No").ToString & "/" & ds_Notices.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Street_Name").ToString
                            lblst1.Text = ds_Notices.Tables(0).Rows(0).Item("Suburb") & " " & ds_Notices.Tables(0).Rows(0).Item("State").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Post_Code").ToString
                            lbladd2.Text = ds_Notices.Tables(0).Rows(0).Item("Unit_No").ToString & "/" & ds_Notices.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Street_Name").ToString
                            lblst2.Text = ds_Notices.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("State").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Post_Code").ToString
                        Else
                            lbladd.Text = ds_Notices.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Street_Name").ToString
                            lblst.Text = ds_Notices.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("State").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Post_Code").ToString
                            lbladd1.Text = ds_Notices.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Street_Name").ToString
                            lblst1.Text = ds_Notices.Tables(0).Rows(0).Item("Suburb") & " " & ds_Notices.Tables(0).Rows(0).Item("State").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Post_Code").ToString
                            lbladd2.Text = ds_Notices.Tables(0).Rows(0).Item("Street_Number").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Street_Name").ToString
                            lblst2.Text = ds_Notices.Tables(0).Rows(0).Item("Suburb").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("State").ToString & " " & ds_Notices.Tables(0).Rows(0).Item("Post_Code").ToString
                        End If

                    End If

                    If ds_Notices.Tables(0).Rows(0).Item("Title").ToString <> "" Then
                        lbltitle.Text = "Dear" & " " & ds_Notices.Tables(0).Rows(0).Item("Title").ToString & "  " & ds_Notices.Tables(0).Rows(0).Item("Last_Name").ToString
                        lbltitle1.Text = "Dear" & " " & ds_Notices.Tables(0).Rows(0).Item("Title").ToString & "  " & ds_Notices.Tables(0).Rows(0).Item("Last_Name").ToString
                        lbltitle2.Text = "Dear" & " " & ds_Notices.Tables(0).Rows(0).Item("Title").ToString & "  " & ds_Notices.Tables(0).Rows(0).Item("Last_Name").ToString
                    Else
                        lbltitle.Text = "Dear" & " " & ds_Notices.Tables(0).Rows(0).Item("Last_Name").ToString
                        lbltitle1.Text = "Dear" & " " & ds_Notices.Tables(0).Rows(0).Item("Last_Name").ToString
                        lbltitle2.Text = "Dear" & " " & ds_Notices.Tables(0).Rows(0).Item("Last_Name").ToString
                    End If
                    Dim dt, dt1, dt2 As String

                    lblamt.Text = open_con.newamount(Math.Round(CDbl(ds_Notices.Tables(0).Rows(0).Item("Amount")), 2))
                    dt = Date.Parse(ds_Notices.Tables(0).Rows(0).Item("Due_Date")).ToString("dd-MMM-yyyy")
                    lblamt1.Text = open_con.newamount(Math.Round(CDbl(ds_Notices.Tables(0).Rows(0).Item("Amount")), 2))
                    dt1 = Date.Parse(ds_Notices.Tables(0).Rows(0).Item("Due_Date")).ToString("dd-MMM-yyyy")
                    lblamt2.Text = open_con.newamount(Math.Round(CDbl(ds_Notices.Tables(0).Rows(0).Item("Amount")), 2))
                    dt2 = Date.Parse(ds_Notices.Tables(0).Rows(0).Item("Due_Date")).ToString("dd-MMM-yyyy")
                    lbldt.Text = dt.Replace("-", " ")
                    lbldt1.Text = dt1.Replace("-", " ")
                    lbldt2.Text = dt2.Replace("-", " ")
                    If Val(int_Dishonour) <> 0 Then
                        lblfee.Text = open_con.new_amount(int_Dishonour)
                        lblfee1.Text = open_con.new_amount(int_Dishonour)
                        lblfee2.Text = open_con.new_amount(int_Dishonour)
                    Else
                        lblfee.Text = "$0.00"
                        lblfee1.Text = "$0.00"
                        lblfee2.Text = "$0.00"
                    End If

                    If Val(int_variation) <> 0 Then
                        lblvar.Visible = True
                        lblvarfee.Visible = True
                        lblfeetotal.Visible = True
                        lblvar1.Visible = True
                        lblvarfee1.Visible = True
                        lblfeetotal1.Visible = True
                        lblvar2.Visible = True
                        lblvarfee2.Visible = True
                        lblfeetotal2.Visible = True
                        lblvarfee.Text = open_con.new_amount(int_variation)
                        lblvarfee1.Text = open_con.new_amount(int_variation)
                        lblvarfee2.Text = open_con.new_amount(int_variation)
                    End If
                    Dim redt, redt1, redt2 As String
                    redt = Date.Parse(ds_DueDate.Tables(0).Rows(0).Item("Due_Date")).ToString("dd-MMM-yyyy")
                    redt1 = Date.Parse(ds_DueDate.Tables(0).Rows(0).Item("Due_Date")).ToString("dd-MMM-yyyy")
                    redt2 = Date.Parse(ds_DueDate.Tables(0).Rows(0).Item("Due_Date")).ToString("dd-MMM-yyyy")
                    lblredt.Text = redt.Replace("-", " ")
                    lblredt1.Text = redt1.Replace("-", " ")
                    lblredt2.Text = redt2.Replace("-", " ")

                    Dim var_amt As Double
                    If Val(int_variation) <> 0 Then

                        var_amt = Math.Round(ds_variation.Tables(0).Rows(0).Item("Amount"), 2)
                    Else
                        var_amt = 0.0

                    End If

                    Dim dis_amt As Double
                    If Val(int_Dishonour) <> 0 Then

                        dis_amt = Math.Round(ds_dishonour.Tables(0).Rows(0).Item("Amount"), 2)
                    Else
                        dis_amt = 0.0

                    End If
                    ltot.Text = "$" & var_amt + dis_amt & ".00"
                    ltot1.Text = "$" & var_amt + dis_amt & ".00"
                    ltot2.Text = "$" & var_amt + dis_amt & ".00"
                    Dim total_amt As Double
                    total_amt = open_con.check_amount_format(Math.Round(CDbl(ds_Notices.Tables(0).Rows(0).Item("Amount")), 2) + var_amt + dis_amt)
                    lbltotal.Text = open_con.newamount(total_amt)
                    lbltotal1.Text = open_con.newamount(total_amt)
                    lbltotal2.Text = open_con.newamount(total_amt)

                    all_con_close()
                End If
            Catch ex As Exception
                Response.Write("Error: " & ex.Message)
                open_con.return_con.Dispose()
            End Try
        End If
    End Sub
    Sub all_con_close()
        cmd_dishonour.Dispose()
        cmd_DueDate.Dispose()
        cmd_Notices.Dispose()
        cmd_str.Dispose()
        cmd_str1.Dispose()
        cmd_variation.Dispose()
        ds_dishonour.Dispose()
        ds_DueDate.Dispose()
        ds_Notices.Dispose()
        ds_str.Dispose()
        ds_str1.Dispose()
        ds_variation.Dispose()
        adap_dishonour.Dispose()
        adap_DueDate.Dispose()
        adap_Notices.Dispose()
        adap_variation.Dispose()
        str1_adap.Dispose()
        str_adap.Dispose()
        open_con.return_con.Dispose()
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
