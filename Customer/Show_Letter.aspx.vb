Imports System.Data.SqlClient
Imports System.Data

Partial Class Customer_Show_Letter
    Inherits System.Web.UI.Page
    Dim open_con As New Class1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else


            Dim cmd_branch As New SqlCommand
            Dim ds_branch As New DataSet
            Dim adap_branch As SqlDataAdapter
            Dim str_branch As String
            str_branch = "SELECT * FROM sys_Branch WHERE Branch_ID = " & open_con.branch_id_val
            cmd_branch.CommandText = str_branch
            cmd_branch.Connection = open_con.return_con
            adap_branch = New SqlDataAdapter(cmd_branch)
            adap_branch.Fill(ds_branch)
            
            Dim letter_val As String
            letter_val = Request.QueryString("letter_val")
            Dim letter_type As String
            letter_type = Request.QueryString("letter_type")
            Dim pos_int_letter As Integer
            Dim cust_id As Integer
      
            For i = 0 To letter_val.Length - 1
                pos_int_letter = InStr(2, letter_val, ",")
                If pos_int_letter = 0 Then
                    Dim cmd_cust As New SqlCommand
                    Dim ds_cust As New DataSet
                    Dim adap_cust As SqlDataAdapter
                    Dim str_cust As String
                    cust_id = Mid(letter_val, 2, letter_val.Length - 1)
                    str_cust = "SELECT * FROM tbl_customer WHERE Customer_ID = " & cust_id
                    cmd_cust.CommandText = str_cust
                    cmd_cust.Connection = open_con.return_con
                    adap_cust = New SqlDataAdapter(cmd_cust)
                    adap_cust.Fill(ds_cust)
                    If letter_type = "Need Cash Today" Then
                        Need_Cash_Today(ds_branch, ds_cust)
                    ElseIf letter_type = "Easter Letter" Then
                        Easter_Letter(ds_branch, ds_cust)
                    ElseIf letter_type = "Special Occassion" Then
                        Special_Occasion_Letter(ds_branch, ds_cust)
                    ElseIf letter_type = "Valued Customer" Then
                        Valued_Cust_Letter(ds_branch, ds_cust)
                    ElseIf letter_type = "Tax Time" Then
                        Tax_Time(ds_branch, ds_cust)
                    ElseIf letter_type = "Christmas Letter" Then
                        Christmas_Letter(ds_branch, ds_cust)
                    End If
                    cmd_cust.Dispose()
                    ds_cust.Dispose()
                    adap_cust.Dispose()
                    Exit Sub
                Else
                    cust_id = Mid(letter_val, 2, pos_int_letter - 1)
                    letter_val = letter_val.Replace(cust_id & ",", "")

                    Dim cmd_cust As New SqlCommand
                    Dim ds_cust As New DataSet
                    Dim adap_cust As SqlDataAdapter
                    Dim str_cust As String
                    str_cust = "SELECT * FROM tbl_customer WHERE Customer_ID = " & cust_id
                    cmd_cust.CommandText = str_cust
                    cmd_cust.Connection = open_con.return_con
                    adap_cust = New SqlDataAdapter(cmd_cust)
                    adap_cust.Fill(ds_cust)
                    If letter_type = "Need Cash Today" Then
                        Need_Cash_Today(ds_branch, ds_cust)
                    ElseIf letter_type = "Special Occassion" Then
                        Special_Occasion_Letter(ds_branch, ds_cust)
                    ElseIf letter_type = "Valued Customer" Then
                        Valued_Cust_Letter(ds_branch, ds_cust)
                    ElseIf letter_type = "Easter Letter" Then
                        Easter_Letter(ds_branch, ds_cust)
                    ElseIf letter_type = "Tax Time" Then
                        Tax_Time(ds_branch, ds_cust)
                    ElseIf letter_type = "Christmas Letter" Then
                        Christmas_Letter(ds_branch, ds_cust)
                 
                    End If

                    cmd_cust.Dispose()
                    ds_cust.Dispose()
                    adap_cust.Dispose()
                End If

            Next

        End If


    


    End Sub
    Sub Tax_Time(ByVal ds_branch As DataSet, ByVal ds_cust As DataSet)

        Response.Write(" <table class='MsoTableGrid' width='630px' style='margin-left:.6in; border-style:none' cellpadding='0' cellspacing='0'>")
        Response.Write("<tr><td>&nbsp;</td></tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<img src='../Images/MPNoticeLogo.jpg' alt='logo' style='height: 88px; width: 191px'/>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td class='MsoNormal_letter' style='text-align:right'>This is sent by Geeghis Pty Ltd</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>(ABN 93 139  094 625) T/as Moneyplus</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>Netlending on behalf of the credit</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>provider Abaz Pty Ltd. Australian</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>credit licence number 391104</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>&nbsp;</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Street_Number") & " " & ds_branch.Tables(0).Rows(0).Item("Street_Name") & ", " & ds_branch.Tables(0).Rows(0).Item("Suburb") & ", " & ds_branch.Tables(0).Rows(0).Item("State") & " " & ds_branch.Tables(0).Rows(0).Item("Post_Code") & "&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp; Phone:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Phone_Number") & "&nbsp;&nbsp;&nbsp;Fax:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Fax_Number") & "&nbsp;</p>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td valign='top' width='605'>")
        Dim tod_date As String
        tod_date = DateTime.Now.ToString("dd-MM-yyyy")
        Dim tod_day, day_sup As String
        tod_day = Left(tod_date, 2)
        day_sup = open_con.check_day(tod_date)
        tod_day = tod_day & day_sup
        Dim tod_month As String
        tod_month = Mid(tod_date, 4, 2)
        tod_month = open_con.check_month(Val(tod_month))

        Dim tod_year As String
        tod_year = Right(tod_date, 4)

        Dim new_tod_date As String
        new_tod_date = tod_day & " " & tod_month & " " & tod_year
        Response.Write("<p class='MsoNormal_letter'>" & new_tod_date & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'><b>" & ds_cust.Tables(0).Rows(0).Item("Title") & "  " & ds_cust.Tables(0).Rows(0).Item("Given_Name") & " " & ds_cust.Tables(0).Rows(0).Item("Last_Name") & "</b></p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Street_Number") & " " & ds_cust.Tables(0).Rows(0).Item("Street_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Suburb") & " " & ds_cust.Tables(0).Rows(0).Item("State") & " " & ds_cust.Tables(0).Rows(0).Item("Post_Code") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write(" <p class='MsoNormal_letter'>Dear&nbsp;" & ds_cust.Tables(0).Rows(0).Item("Given_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' align='center' style='text-align:center'>")
        Response.Write("<b><span style='font-size: 17.0pt'>TAX TIME!!!</span></b></p>")
        Response.Write("<p class='MsoNormal_letter' align='center' style='text-align:center'>")
        Response.Write("<b><span style='font-size: 12.0pt'>It's your money... Why wait days for it.</span></b></p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-bottom:10.0pt'>Bring you</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>Bring in the correct documents and we will have a decision within 30 minutes.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Are you currently employed?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Earning over $250.00 weekly?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Getting paid electronically into your bank account?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:20.0pt; margin-bottom:10.0pt'>If answered yes to all the above phone 1300 55 8000, drop into your nearest branch, or visit ")
        Response.Write("<a style='color: blue; text-decoration: underline; text-underline: single'>www.moneyplus.com.au</a> for more details. ")
        Response.Write("<font size='1'>*</font><font size='1'>conditions apply</font><font size='2'></font></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>We look forward to assisting your needs. No fuss, no hassles and no assets required.</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>Kind Regards,</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>MoneyPlus Team</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")

        Response.Write("</td>")
        Response.Write(" </tr>")
        Response.Write("</table>")


    End Sub
    Sub Special_Occasion_Letter(ByVal ds_branch As DataSet, ByVal ds_cust As DataSet)

        Response.Write(" <table class='MsoTableGrid' width='630px' style='margin-left:.6in; border-style:none' cellpadding='0' cellspacing='0'>")
        Response.Write("<tr><td>&nbsp;</td></tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<img src='../Images/MPNoticeLogo.jpg' alt='logo' style='height: 88px; width: 191px'/>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td class='MsoNormal_letter' style='text-align:right'>This is sent by Geeghis Pty Ltd</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>(ABN 93 139  094 625) T/as Moneyplus</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>Netlending on behalf of the credit</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>provider Abaz Pty Ltd. Australian</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>credit licence number 391104</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>&nbsp;</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Street_Number") & " " & ds_branch.Tables(0).Rows(0).Item("Street_Name") & ", " & ds_branch.Tables(0).Rows(0).Item("Suburb") & ", " & ds_branch.Tables(0).Rows(0).Item("State") & " " & ds_branch.Tables(0).Rows(0).Item("Post_Code") & "&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp; Phone:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Phone_Number") & "&nbsp;&nbsp;&nbsp;Fax:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Fax_Number") & "&nbsp;</p>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td valign='top' width='605'>")
        Dim tod_date As String
        tod_date = DateTime.Now.ToString("dd-MM-yyyy")
        Dim tod_day, day_sup As String
        tod_day = Left(tod_date, 2)
        day_sup = open_con.check_day(tod_date)
        tod_day = tod_day & day_sup
        Dim tod_month As String
        tod_month = Mid(tod_date, 4, 2)
        tod_month = open_con.check_month(Val(tod_month))

        Dim tod_year As String
        tod_year = Right(tod_date, 4)

        Dim new_tod_date As String
        new_tod_date = tod_day & " " & tod_month & " " & tod_year
        Response.Write("<p class='MsoNormal_letter'>" & new_tod_date & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'><b>" & ds_cust.Tables(0).Rows(0).Item("Title") & "  " & ds_cust.Tables(0).Rows(0).Item("Given_Name") & " " & ds_cust.Tables(0).Rows(0).Item("Last_Name") & "</b></p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Street_Number") & " " & ds_cust.Tables(0).Rows(0).Item("Street_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Suburb") & " " & ds_cust.Tables(0).Rows(0).Item("State") & " " & ds_cust.Tables(0).Rows(0).Item("Post_Code") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write(" <p class='MsoNormal_letter'>Dear&nbsp;" & ds_cust.Tables(0).Rows(0).Item("Given_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' align='center' style='text-align:center'>")
        Response.Write("<b><span style='font-size: 17.0pt'><i>Need Cash For Any Special Occasion?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-bottom:10.0pt'>The staff at MoneyPlus would like to take this opportunity to offer you, your relatives and friends a wide range of loan facilities from $100 to $6000 to help with those unexpected bills and other expenses.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>Bring in the correct documents and we will have a decision within 30 minutes.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Are you currently employed?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Earning over $250.00 weekly?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Getting paid electronically into your bank account?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:20.0pt; margin-bottom:10.0pt'>If answered yes to all the above phone 1300 55 8000, drop into your nearest branch, or visit ")
        Response.Write("<a style='color: blue; text-decoration: underline; text-underline: single'>www.moneyplus.com.au</a> for more details. ")
        Response.Write("<font size='1'>*</font><font size='1'>conditions apply</font><font size='2'></font></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>We look forward to assisting your needs. No fuss, no hassles and no assets required.</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>Kind Regards,</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>MoneyPlus Team</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")

        Response.Write("</td>")
        Response.Write(" </tr>")
        Response.Write("</table>")


    End Sub
    Sub Valued_Cust_Letter(ByVal ds_branch As DataSet, ByVal ds_cust As DataSet)

        Response.Write(" <table class='MsoTableGrid' width='630px' style='margin-left:.6in; border-style:none' cellpadding='0' cellspacing='0'>")
        Response.Write("<tr><td>&nbsp;</td></tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<img src='../Images/MPNoticeLogo.jpg' alt='logo' style='height: 88px; width: 191px'/>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td class='MsoNormal_letter' style='text-align:right'>This is sent by Geeghis Pty Ltd</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>(ABN 93 139  094 625) T/as Moneyplus</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>Netlending on behalf of the credit</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>provider Abaz Pty Ltd. Australian</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>credit licence number 391104</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>&nbsp;</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Street_Number") & " " & ds_branch.Tables(0).Rows(0).Item("Street_Name") & ", " & ds_branch.Tables(0).Rows(0).Item("Suburb") & ", " & ds_branch.Tables(0).Rows(0).Item("State") & " " & ds_branch.Tables(0).Rows(0).Item("Post_Code") & "&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp; Phone:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Phone_Number") & "&nbsp;&nbsp;&nbsp;Fax:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Fax_Number") & "&nbsp;</p>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td valign='top' width='605'>")
        Dim tod_date As String
        tod_date = DateTime.Now.ToString("dd-MM-yyyy")
        Dim tod_day, day_sup As String
        tod_day = Left(tod_date, 2)
        day_sup = open_con.check_day(tod_date)
        tod_day = tod_day & day_sup
        Dim tod_month As String
        tod_month = Mid(tod_date, 4, 2)
        tod_month = open_con.check_month(Val(tod_month))

        Dim tod_year As String
        tod_year = Right(tod_date, 4)

        Dim new_tod_date As String
        new_tod_date = tod_day & " " & tod_month & " " & tod_year
        Response.Write("<p class='MsoNormal_letter'>" & new_tod_date & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'><b>" & ds_cust.Tables(0).Rows(0).Item("Title") & "  " & ds_cust.Tables(0).Rows(0).Item("Given_Name") & " " & ds_cust.Tables(0).Rows(0).Item("Last_Name") & "</b></p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Street_Number") & " " & ds_cust.Tables(0).Rows(0).Item("Street_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Suburb") & " " & ds_cust.Tables(0).Rows(0).Item("State") & " " & ds_cust.Tables(0).Rows(0).Item("Post_Code") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write(" <p class='MsoNormal_letter'>Dear&nbsp;" & ds_cust.Tables(0).Rows(0).Item("Given_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' align='center' style='text-align:center'>")
        Response.Write("<b><span style='font-size: 17.0pt'><i>To Our Valued Customer</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-bottom:10.0pt'>The staff at MoneyPlus would like to take this opportunity to offer you, your relatives and friends a wide range of loan facilities from $100 to $6000 to help with those unexpected bills and other expenses.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>Bring in the correct documents and we will have a decision within 30 minutes.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Are you currently employed?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Earning over $250.00 weekly?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Getting paid electronically into your bank account?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:20.0pt; margin-bottom:10.0pt'>If answered yes to all the above phone 1300 55 8000, drop into your nearest branch, or visit ")
        Response.Write("<a style='color: blue; text-decoration: underline; text-underline: single'>www.moneyplus.com.au</a> for more details. ")
        Response.Write("<font size='1'>*</font><font size='1'>conditions apply</font><font size='2'></font></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>We look forward to assisting your needs. No fuss, no hassles and no assets required.</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>Kind Regards,</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>MoneyPlus Team</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")

        Response.Write("</td>")
        Response.Write(" </tr>")
        Response.Write("</table>")


    End Sub
    Sub Easter_Letter(ByVal ds_branch As DataSet, ByVal ds_cust As DataSet)

        Response.Write(" <table class='MsoTableGrid' width='630px' style='margin-left:.6in; border-style:none' cellpadding='0' cellspacing='0'>")
        Response.Write("<tr><td>&nbsp;</td></tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<img src='../Images/MPNoticeLogo.jpg' alt='logo' style='height: 88px; width: 191px'/>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td class='MsoNormal_letter' style='text-align:right'>This is sent by Geeghis Pty Ltd</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>(ABN 93 139  094 625) T/as Moneyplus</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>Netlending on behalf of the credit</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>provider Abaz Pty Ltd. Australian</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>credit licence number 391104</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>&nbsp;</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Street_Number") & " " & ds_branch.Tables(0).Rows(0).Item("Street_Name") & ", " & ds_branch.Tables(0).Rows(0).Item("Suburb") & ", " & ds_branch.Tables(0).Rows(0).Item("State") & " " & ds_branch.Tables(0).Rows(0).Item("Post_Code") & "&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp; Phone:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Phone_Number") & "&nbsp;&nbsp;&nbsp;Fax:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Fax_Number") & "&nbsp;</p>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td valign='top' width='605'>")
        Dim tod_date As String
        tod_date = DateTime.Now.ToString("dd-MM-yyyy")
        Dim tod_day, day_sup As String
        tod_day = Left(tod_date, 2)
        day_sup = open_con.check_day(tod_date)
        tod_day = tod_day & day_sup
        Dim tod_month As String
        tod_month = Mid(tod_date, 4, 2)
        tod_month = open_con.check_month(Val(tod_month))

        Dim tod_year As String
        tod_year = Right(tod_date, 4)

        Dim new_tod_date As String
        new_tod_date = tod_day & " " & tod_month & " " & tod_year
        Response.Write("<p class='MsoNormal_letter'>" & new_tod_date & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'><b>" & ds_cust.Tables(0).Rows(0).Item("Title") & "  " & ds_cust.Tables(0).Rows(0).Item("Given_Name") & " " & ds_cust.Tables(0).Rows(0).Item("Last_Name") & "</b></p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Street_Number") & " " & ds_cust.Tables(0).Rows(0).Item("Street_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Suburb") & " " & ds_cust.Tables(0).Rows(0).Item("State") & " " & ds_cust.Tables(0).Rows(0).Item("Post_Code") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write(" <p class='MsoNormal_letter'>Dear&nbsp;" & ds_cust.Tables(0).Rows(0).Item("Given_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' align='center' style='text-align:center'>")
        Response.Write("<b><span style='font-size: 17.0pt'><i>Need cash for Easter?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-bottom:10.0pt'>The staff at MoneyPlus would like to take this opportunity to offer you, your relatives and friends a wide range of loan facilities from $100 to $6000 to help with those unexpected bills and other expenses.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>Bring in the correct documents and we will have a decision within 30 minutes.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Are you currently employed?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Earning over $250.00 weekly?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Getting paid electronically into your bank account?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:20.0pt; margin-bottom:10.0pt'>If answered yes to all the above phone 1300 55 8000, drop into your nearest branch, or visit ")
        Response.Write("<a style='color: blue; text-decoration: underline; text-underline: single'>www.moneyplus.com.au</a> for more details. ")
        Response.Write("<font size='1'>*</font><font size='1'>conditions apply</font><font size='2'></font></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>We look forward to assisting your needs. No fuss, no hassles and no assets required.</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>Kind Regards,</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>MoneyPlus Team</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")

        Response.Write("</td>")
        Response.Write(" </tr>")
        Response.Write("</table>")


    End Sub
    Sub Need_Cash_Today(ByVal ds_branch As DataSet, ByVal ds_cust As DataSet)

        Response.Write(" <table class='MsoTableGrid' width='630px' style='margin-left:.6in; border-style:none' cellpadding='0' cellspacing='0'>")
        Response.Write("<tr><td>&nbsp;</td></tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<img src='../Images/MPNoticeLogo.jpg' alt='logo' style='height: 88px; width: 191px'/>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td class='MsoNormal_letter' style='text-align:right'>This is sent by Geeghis Pty Ltd</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>(ABN 93 139  094 625) T/as Moneyplus</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>Netlending on behalf of the credit</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>provider Abaz Pty Ltd. Australian</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>credit licence number 391104</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>&nbsp;</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Street_Number") & " " & ds_branch.Tables(0).Rows(0).Item("Street_Name") & ", " & ds_branch.Tables(0).Rows(0).Item("Suburb") & ", " & ds_branch.Tables(0).Rows(0).Item("State") & " " & ds_branch.Tables(0).Rows(0).Item("Post_Code") & "&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp; Phone:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Phone_Number") & "&nbsp;&nbsp;&nbsp;Fax:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Fax_Number") & "&nbsp;</p>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td valign='top' width='605'>")
        Dim tod_date As String
        tod_date = DateTime.Now.ToString("dd-MM-yyyy")
        Dim tod_day, day_sup As String
        tod_day = Left(tod_date, 2)
        day_sup = open_con.check_day(tod_date)
        tod_day = tod_day & day_sup
        Dim tod_month As String
        tod_month = Mid(tod_date, 4, 2)
        tod_month = open_con.check_month(Val(tod_month))

        Dim tod_year As String
        tod_year = Right(tod_date, 4)

        Dim new_tod_date As String
        new_tod_date = tod_day & " " & tod_month & " " & tod_year
        Response.Write("<p class='MsoNormal_letter'>" & new_tod_date & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'><b>" & ds_cust.Tables(0).Rows(0).Item("Title") & "  " & ds_cust.Tables(0).Rows(0).Item("Given_Name") & " " & ds_cust.Tables(0).Rows(0).Item("Last_Name") & "</b></p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Street_Number") & " " & ds_cust.Tables(0).Rows(0).Item("Street_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Suburb") & " " & ds_cust.Tables(0).Rows(0).Item("State") & " " & ds_cust.Tables(0).Rows(0).Item("Post_Code") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write(" <p class='MsoNormal_letter'>Dear&nbsp;" & ds_cust.Tables(0).Rows(0).Item("Given_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' align='center' style='text-align:center'>")
        Response.Write("<b><span style='font-size: 17.0pt'><i>Need some cash today?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-bottom:10.0pt'>The staff at MoneyPlus would like to take this opportunity to offer you, your relatives and friends a wide range of loan facilities from $100 to $6000 to help with those unexpected bills and other expenses.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>Bring in the correct documents and we will have a decision within 30 minutes.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Are you currently employed?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Earning over $250.00 weekly?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Getting paid electronically into your bank account?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:20.0pt; margin-bottom:10.0pt'>If answered yes to all the above phone 1300 55 8000, drop into your nearest branch, or visit ")
        Response.Write("<a style='color: blue; text-decoration: underline; text-underline: single'>www.moneyplus.com.au</a> for more details. ")
        Response.Write("<font size='1'>*</font><font size='1'>conditions apply</font><font size='2'></font></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>We look forward to assisting your needs. No fuss, no hassles and no assets required.</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>Kind Regards,</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>MoneyPlus Team</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")

        Response.Write("</td>")
        Response.Write(" </tr>")
        Response.Write("</table>")


    End Sub
    Sub Holiday_Letter(ByVal ds_branch As DataSet, ByVal ds_cust As DataSet)

        Response.Write(" <table class='MsoTableGrid' width='630px' style='margin-left:.6in; border-style:none' cellpadding='0' cellspacing='0'>")
        Response.Write("<tr><td>&nbsp;</td></tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<img src='../Images/MPNoticeLogo.jpg' alt='logo' style='height: 88px; width: 191px'/>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td class='MsoNormal_letter' style='text-align:right'>This is sent by Geeghis Pty Ltd</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>(ABN 93 139  094 625) T/as Moneyplus</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>Netlending on behalf of the credit</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>provider Abaz Pty Ltd. Australian</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>credit licence number 391104</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>&nbsp;</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Street_Number") & " " & ds_branch.Tables(0).Rows(0).Item("Street_Name") & ", " & ds_branch.Tables(0).Rows(0).Item("Suburb") & ", " & ds_branch.Tables(0).Rows(0).Item("State") & " " & ds_branch.Tables(0).Rows(0).Item("Post_Code") & "&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp; Phone:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Phone_Number") & "&nbsp;&nbsp;&nbsp;Fax:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Fax_Number") & "&nbsp;</p>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td valign='top' width='605'>")
        Dim tod_date As String
        tod_date = DateTime.Now.ToString("dd-MM-yyyy")
        Dim tod_day, day_sup As String
        tod_day = Left(tod_date, 2)
        day_sup = open_con.check_day(tod_date)
        tod_day = tod_day & day_sup
        Dim tod_month As String
        tod_month = Mid(tod_date, 4, 2)
        tod_month = open_con.check_month(Val(tod_month))

        Dim tod_year As String
        tod_year = Right(tod_date, 4)

        Dim new_tod_date As String
        new_tod_date = tod_day & " " & tod_month & " " & tod_year
        Response.Write("<p class='MsoNormal_letter'>" & new_tod_date & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'><b>" & ds_cust.Tables(0).Rows(0).Item("Title") & "  " & ds_cust.Tables(0).Rows(0).Item("Given_Name") & " " & ds_cust.Tables(0).Rows(0).Item("Last_Name") & "</b></p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Street_Number") & " " & ds_cust.Tables(0).Rows(0).Item("Street_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Suburb") & " " & ds_cust.Tables(0).Rows(0).Item("State") & " " & ds_cust.Tables(0).Rows(0).Item("Post_Code") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write(" <p class='MsoNormal_letter'>Dear&nbsp;" & ds_cust.Tables(0).Rows(0).Item("Given_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' align='center' style='text-align:center'>")
        Response.Write("<b><span style='font-size: 17.0pt'><i>Need cash for this public holiday?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-bottom:10.0pt'>The staff at MoneyPlus would like to take this opportunity to offer you, your relatives and friends a wide range of loan facilities from $100 to $6000 to help with those unexpected bills and other expenses.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>Bring in the correct documents and we will have a decision within 30 minutes.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Are you currently employed?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Earning over $250.00 weekly?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Getting paid electronically into your bank account?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:20.0pt; margin-bottom:10.0pt'>If answered yes to all the above phone 1300 55 8000, drop into your nearest branch, or visit ")
        Response.Write("<a style='color: blue; text-decoration: underline; text-underline: single'>www.moneyplus.com.au</a> for more details. ")
        Response.Write("<font size='1'>*</font><font size='1'>conditions apply</font><font size='2'></font></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>We look forward to assisting your needs. No fuss, no hassles and no assets required.</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>Kind Regards,</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>MoneyPlus Team</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")

        Response.Write("</td>")
        Response.Write(" </tr>")
        Response.Write("</table>")


    End Sub
    Sub Christmas_Letter(ByVal ds_branch As DataSet, ByVal ds_cust As DataSet)

        Response.Write(" <table class='MsoTableGrid' width='630px' style='margin-left:.6in; border-style:none' cellpadding='0' cellspacing='0'>")
        Response.Write("<tr><td>&nbsp;</td></tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<img src='../Images/MPNoticeLogo.jpg' alt='logo' style='height: 88px; width: 191px'/>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td class='MsoNormal_letter' style='text-align:right'>This is sent by Geeghis Pty Ltd</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>(ABN 93 139  094 625) T/as Moneyplus</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>Netlending on behalf of the credit</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>provider Abaz Pty Ltd. Australian</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>credit licence number 391104</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>&nbsp;</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Street_Number") & " " & ds_branch.Tables(0).Rows(0).Item("Street_Name") & ", " & ds_branch.Tables(0).Rows(0).Item("Suburb") & ", " & ds_branch.Tables(0).Rows(0).Item("State") & " " & ds_branch.Tables(0).Rows(0).Item("Post_Code") & "&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp; Phone:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Phone_Number") & "&nbsp;&nbsp;&nbsp;Fax:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Fax_Number") & "&nbsp;</p>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td valign='top' width='605'>")
        Dim tod_date As String
        tod_date = DateTime.Now.ToString("dd-MM-yyyy")
        Dim tod_day, day_sup As String
        tod_day = Left(tod_date, 2)
        day_sup = open_con.check_day(tod_date)
        tod_day = tod_day & day_sup
        Dim tod_month As String
        tod_month = Mid(tod_date, 4, 2)
        tod_month = open_con.check_month(Val(tod_month))

        Dim tod_year As String
        tod_year = Right(tod_date, 4)

        Dim new_tod_date As String
        new_tod_date = tod_day & " " & tod_month & " " & tod_year
        Response.Write("<p class='MsoNormal_letter'>" & new_tod_date & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'><b>" & ds_cust.Tables(0).Rows(0).Item("Title") & "  " & ds_cust.Tables(0).Rows(0).Item("Given_Name") & " " & ds_cust.Tables(0).Rows(0).Item("Last_Name") & "</b></p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Street_Number") & " " & ds_cust.Tables(0).Rows(0).Item("Street_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Suburb") & " " & ds_cust.Tables(0).Rows(0).Item("State") & " " & ds_cust.Tables(0).Rows(0).Item("Post_Code") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write(" <p class='MsoNormal_letter'>Dear&nbsp;" & ds_cust.Tables(0).Rows(0).Item("Given_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' align='center' style='text-align:center'>")
        Response.Write("<b><span style='font-size: 17.0pt'><i>Need cash for Christmas?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-bottom:10.0pt'>The staff at MoneyPlus would like to take this opportunity to offer you, your relatives and friends a wide range of loan facilities from $100 to $6000 to help with those unexpected bills and other expenses.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>Bring in the correct documents and we will have a decision within 30 minutes.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Are you currently employed?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Earning over $250.00 weekly?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:2.0pt; margin-bottom:2.0pt'><b><img src='../Images/images.jpg' style='height: 20px; width: 30px'></img><span style='font-size: 14.0pt'><i>Getting paid electronically into your bank account?</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:20.0pt; margin-bottom:10.0pt'>If answered yes to all the above phone 1300 55 8000, drop into your nearest branch, or visit ")
        Response.Write("<a style='color: blue; text-decoration: underline; text-underline: single'>www.moneyplus.com.au</a> for more details. ")
        Response.Write("<font size='1'>*</font><font size='1'>conditions apply</font><font size='2'></font></p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>We look forward to assisting your needs. No fuss, no hassles and no assets required.</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>Kind Regards,</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>MoneyPlus Team</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")

        Response.Write("</td>")
        Response.Write(" </tr>")
        Response.Write("</table>")


    End Sub
    Sub Almost_There(ByVal ds_branch As DataSet, ByVal ds_cust As DataSet)

        Response.Write(" <table class='MsoTableGrid' width='630px' style='margin-left:.6in; border-style:none' cellpadding='0' cellspacing='0'>")
        Response.Write("<tr><td>&nbsp;</td></tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<img src='../Images/MPNoticeLogo.jpg' alt='logo' style='height: 88px; width: 191px'/>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td class='MsoNormal_letter' style='text-align:right'>This is sent by Geeghis Pty Ltd</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>(ABN 93 139  094 625) T/as Moneyplus</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>Netlending on behalf of the credit</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>provider Abaz Pty Ltd. Australian</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td  class='MsoNormal_letter' style='text-align:right'>credit licence number 391104</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>&nbsp;</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Street_Number") & " " & ds_branch.Tables(0).Rows(0).Item("Street_Name") & ", " & ds_branch.Tables(0).Rows(0).Item("Suburb") & ", " & ds_branch.Tables(0).Rows(0).Item("State") & " " & ds_branch.Tables(0).Rows(0).Item("Post_Code") & "&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='text-align:right'>&nbsp; Phone:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Phone_Number") & "&nbsp;&nbsp;&nbsp;Fax:&nbsp;" & ds_branch.Tables(0).Rows(0).Item("Fax_Number") & "&nbsp;</p>")
        Response.Write("</td>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td valign='top' width='605'>")
        Dim tod_date As String
        tod_date = DateTime.Now.ToString("dd-MM-yyyy")
        Dim tod_day, day_sup As String
        tod_day = Left(tod_date, 2)
        day_sup = open_con.check_day(tod_date)
        tod_day = tod_day & day_sup
        Dim tod_month As String
        tod_month = Mid(tod_date, 4, 2)
        tod_month = open_con.check_month(Val(tod_month))

        Dim tod_year As String
        tod_year = Right(tod_date, 4)

        Dim new_tod_date As String
        new_tod_date = tod_day & " " & tod_month & " " & tod_year
        Response.Write("<p class='MsoNormal_letter'>" & new_tod_date & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'><b>" & ds_cust.Tables(0).Rows(0).Item("Title") & "  " & ds_cust.Tables(0).Rows(0).Item("Given_Name") & " " & ds_cust.Tables(0).Rows(0).Item("Last_Name") & "</b></p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Street_Number") & " " & ds_cust.Tables(0).Rows(0).Item("Street_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>" & ds_cust.Tables(0).Rows(0).Item("Suburb") & " " & ds_cust.Tables(0).Rows(0).Item("State") & " " & ds_cust.Tables(0).Rows(0).Item("Post_Code") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write(" <p class='MsoNormal_letter'>Dear&nbsp;" & ds_cust.Tables(0).Rows(0).Item("Given_Name") & "</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' align='center' style='text-align:center'>")
        Response.Write("<b><span style='font-size: 17.0pt'><i>You were almost there !</i></span></b></p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-bottom:10.0pt'>You were almost there!</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>We were ready to give a cash advance but we're still a little concerned you may be stuck with your application and we didn't do everything possibleto help you.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>If that's the case, please let us know.</p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>We'll call you and help you through the application process or feel free to contact us on </p>")
        Response.Write("<p class='MsoNormal_letter' style='margin-top:10.0pt; margin-bottom:10.0pt'>We look froward to hearing from you soon.</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>Kind Regards,</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>MoneyPlus Team</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")
        Response.Write("<p class='MsoNormal_letter'>&nbsp;</p>")

        Response.Write("</td>")
        Response.Write(" </tr>")
        Response.Write("</table>")


    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
