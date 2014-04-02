Imports System.Data.SqlClient
Imports System.Data
Imports System.String


Partial Class Customer_Grp_search
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedItem.Text = " Customers" Then
            txtcustname.Text = ""
            txtpstcode_new.Text = ""
            txtstname.Text = ""
            txtsub_new.Text = ""
            txtemail.Text = ""
            txtmobile.Text = ""
            Panel1.Visible = True
            Panel3.Visible = False
            Panel2.Visible = True

        Else
            txtempname.Text = ""
            txtepstcode_new.Text = ""
            txtestname.Text = ""
            txtesub_new.Text = ""
            Panel3.Visible = True
            Panel1.Visible = False
            Panel2.Visible = True
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()

        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else

            If Page.IsPostBack = False Then

                RadioButtonList1.ClearSelection()
            End If

        End If

    End Sub

    Sub chkAdmin()
        If clsGeneral.ChkAdmin() = True Then
            Link_Administration.Visible = True
        Else
            Link_Administration.Text = "User"
            Link_Administration.PostBackUrl = "~/Customer/UpdatePassword.aspx"

        End If
    End Sub
    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub

    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        If txtpstcode_new.Text = "" And txtstname.Text = "" And txtsub_new.Text = "" And txtcustname.Text = "" And txtemail.Text = "" And txtmobile.Text = "" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter at least one search criteria!!!" & "');", True)
        Else
            show_address_rec()
            Panel2.Visible = True
            Panel1.Visible = True
            Panel3.Visible = False

        End If
    End Sub

    Protected Sub btnesearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnesearch.Click
        If txtepstcode_new.Text = "" And txtestname.Text = "" And txtesub_new.Text = "" And txtempname.Text = "" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please enter at least one search criteria!!!" & "');", True)
        Else
            show_address_rec_new()
            Panel2.Visible = True
            Panel3.Visible = True
            Panel1.Visible = False
        End If
    End Sub
    Sub show_address_rec()

        Try


            Dim str_SQL As String
            Dim bln_Flag As Boolean
            Dim str_Dsiplay As String
            str_Dsiplay = ""
            bln_Flag = False
          
            str_SQL = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name,Tbl_Customer.Date_Of_Birth, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code, Tbl_Customer.M_Address, Tbl_Customer.M_Suburb, Tbl_Customer.M_State, Tbl_Customer.M_Post_Code,Tbl_Customer.Email,Tbl_Customer.Mobile_Phone "


            str_SQL = str_SQL & " FROM Tbl_Customer  "

            str_SQL = str_SQL & " WHERE "

            If txtstname.Text <> "" Or txtsub_new.Text <> "" Or txtpstcode_new.Text <> "" Or txtcustname.Text <> "" Or txtemail.Text <> "" Or txtmobile.Text <> "" Then
                str_SQL = str_SQL & " ("
            End If

            If txtcustname.Text <> "" Then
                str_SQL = str_SQL & " (Tbl_Customer.Last_Name like '" & txtcustname.Text & "%' OR Tbl_Customer.Given_Name like '" & txtcustname.Text & "%')"
                bln_Flag = True

            End If
          
            If txtemail.Text <> "" Then
                If bln_Flag = True Then
                    str_SQL = str_SQL & " OR "
                End If
                str_SQL = str_SQL & " (Tbl_Customer.Email = '" & txtemail.Text & "')"
                bln_Flag = True

            End If
            Dim ph As String = txtmobile.Text.Replace(" ", "")
            'If txtmobile.Text <> "" Then orignal
            '    If bln_Flag = True Then
            '        str_SQL = str_SQL & " OR "
            '    End If
            '    str_SQL = str_SQL & "( Tbl_Customer.Mobile_Phone ='" & ph & "')"
            '    bln_Flag = True

            'End If
            If txtmobile.Text <> "" Then
                If bln_Flag = True Then
                    str_SQL = str_SQL & " OR "
                End If
                str_SQL = str_SQL & "( REPLACE(ISNULL(Mobile_Phone, ''), ' ', '') like'%" & ph & "%')"
                bln_Flag = True

            End If
            If txtmobile.Text <> "" Then
                If bln_Flag = True Then
                    str_SQL = str_SQL & " OR "
                End If
                'str_SQL = str_SQL & "(REPLACE(ISNULL(Home_Phone, ''), ' ', '') ='" & ph & "')"
                str_SQL = str_SQL & "( REPLACE(ISNULL(Home_Phone, ''), ' ', '') like'%" & ph & "%')"
                bln_Flag = True

            End If
            If txtmobile.Text <> "" Then
                If bln_Flag = True Then
                    str_SQL = str_SQL & " OR "
                End If
                'str_SQL = str_SQL & "(REPLACE(ISNULL(Work_Phone, ''), ' ', '') ='" & ph & "')"
                str_SQL = str_SQL & "( REPLACE(ISNULL(Work_Phone, ''), ' ', '') like'%" & ph & "%')"
                bln_Flag = True

            End If
            If txtmobile.Text <> "" Then
                If bln_Flag = True Then
                    str_SQL = str_SQL & " OR "
                End If
                'str_SQL = str_SQL & "(REPLACE(ISNULL(E_Phone_Number, ''), ' ', '') ='" & ph & "')"
                str_SQL = str_SQL & "( REPLACE(ISNULL(E_Phone_Number, ''), ' ', '') like'%" & ph & "%')"
                bln_Flag = True

            End If
            If txtmobile.Text <> "" Then
                If bln_Flag = True Then
                    str_SQL = str_SQL & " OR "
                End If
                str_SQL = str_SQL & "(REPLACE(ISNULL(Agent_No, ''), ' ', '') ='" & ph & "')"
                bln_Flag = True

            End If
            If txtstname.Text <> "" Then
                If bln_Flag = True Then
                    str_SQL = str_SQL & " OR "
                End If
                str_SQL = str_SQL & " (Tbl_Customer.Street_Name like '" & txtstname.Text & "%' OR Tbl_Customer.M_Address like '" & txtstname.Text & "%')"
                bln_Flag = True
                str_Dsiplay = "NAM"
            End If

            If txtsub_new.Text <> "" Then
                If bln_Flag = True Then
                    str_SQL = str_SQL & " OR "
                End If
                str_SQL = str_SQL & " (Tbl_Customer.Suburb like '" & txtsub_new.Text & "%' OR Tbl_Customer.M_Suburb like '" & txtsub_new.Text & "%')"
                bln_Flag = True
                str_Dsiplay = str_Dsiplay & " SUB"
            End If

            If txtpstcode_new.Text <> "" Then
                If bln_Flag = True Then
                    str_SQL = str_SQL & " OR "
                End If
                str_SQL = str_SQL & " (Tbl_Customer.Post_Code = '" & txtpstcode_new.Text & "' OR Tbl_Customer.M_Post_Code = '" & txtpstcode_new.Text & "')"
                bln_Flag = True
                str_Dsiplay = str_Dsiplay & " POS"
            End If


            If bln_Flag = True Then
                str_SQL = str_SQL & ")"
            End If

            'If Request.QueryString("SaveAs") Then
            '    str_SQL = str_SQL & " GROUP BY Tbl_Customer.Customer_ID, Tbl_Customer.Title, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Loan.Loan_ID,Tbl_Loan.Loan_Type, Tbl_Customer.Date_Of_Birth, Tbl_Customer.Home_Phone, Tbl_Customer.Work_Phone, Tbl_Customer.Mobile_Phone, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code, Tbl_Customer.M_Address, Tbl_Customer.M_Suburb, Tbl_Customer.M_State, Tbl_Customer.M_Post_Code, Tbl_Customer.Employer, Tbl_Customer.E_Contact_Person, Tbl_Customer.E_Street_Number, Tbl_Customer.E_Building, Tbl_Customer.E_Street_Name, Tbl_Customer.E_Suburb, Tbl_Customer.E_Post_Code, Tbl_Customer.E_State, Tbl_Customer.E_Phone_Number, Tbl_Customer.E_Fax_Number "
            'Else
            str_SQL = str_SQL & " GROUP BY Tbl_Customer.Customer_ID, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Customer.Date_Of_Birth, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code, Tbl_Customer.M_Address, Tbl_Customer.M_Suburb, Tbl_Customer.M_State, Tbl_Customer.M_Post_Code, Tbl_Customer.Email, Tbl_Customer.Mobile_Phone "
            'End If
            str_SQL = str_SQL & " ORDER BY Tbl_Customer.Customer_ID "
            'str_SQL = str_SQL & " ORDER BY Tbl_Customer.Customer_ID,Tbl_Loan.Loan_ID "

            Dim cmd_add As New SqlCommand
            Dim ds_add As New DataSet
            Dim adap_add As SqlDataAdapter

            cmd_add.CommandText = str_SQL
            cmd_add.Connection = open_con.return_con
            adap_add = New SqlDataAdapter(cmd_add)
            adap_add.Fill(ds_add)
            Dim r_count As String
            r_count = ds_add.Tables(0).Rows.Count
            Dim sb As New StringBuilder()
            If Val(r_count) <> 0 Then

                'Response.Write("<p>&nbsp;<br /><br /></p><table id='tbl' border='1' width='85%' style='font-size:16px;border:0 solid gray; border-collapse: collapse;z-index: 1; left: 250px; top: 500px; position: absolute' cellpadding='0' cellspacing='0' >")
                'Response.Write("<tr>")
                'Response.Write("<td align='center'><b>CustomerID</b></td>")
                'Response.Write("<td align='center'><b>CustomerName</b></td>")
                'Response.Write("<td align='center'><b>StreetNumber</b></td>")
                'Response.Write("<td align='center'><b>StreetName</b></td>")
                'Response.Write("<td align='center'><b>Suburb</b></td> ")
                'Response.Write("<td align='center'><b>PostCode</b></td>")
                'Response.Write("<td align='center'><b>Email</b></td>")
                'Response.Write("<td align='center'><b>ContactNo.</b></td>")
                'Response.Write("</tr>")

                'sb.Append("<table id='tbl' border='1' width='85%' style='font-size:16px;border:0 solid gray; border-collapse: collapse;z-index: 1; left: 250px; top: 500px; position: absolute' cellpadding='0' cellspacing='0' >")
                sb.Append("<table id='tbl' cellpadding='0' cellspacing='0' class='tblreport_new' width='100%'>")
                sb.Append("<tr>")
                sb.Append("<td align='center'><b>CustomerID</b></td>")
                sb.Append("<td align='center'><b>CustomerName</b></td>")
                sb.Append("<td align='center'><b>StreetNumber</b></td>")
                sb.Append("<td align='center'><b>StreetName</b></td>")
                sb.Append("<td align='center'><b>Suburb</b></td> ")
                sb.Append("<td align='center'><b>PostCode</b></td>")
                sb.Append("<td align='center'><b>Email</b></td>")
                sb.Append("<td align='center'><b>ContactNo.</b></td>")
                sb.Append("</tr>")

                Dim int_Index As Integer
                Dim int_Cust_ID As Integer = 0

                int_Index = 1

                Dim i As Integer = 0
                For i = 0 To ds_add.Tables(0).Rows.Count - 1


                    If int_Cust_ID <> ds_add.Tables(0).Rows(i).Item("Customer_ID").ToString Then

                        'If ds_add.Tables(0).Rows(0).Item("Loan_Type").ToString = "Loan" Then
                        '    str_Type = "Applied for Loan"
                        '    'Else
                        '    '    str_Type = "Applied for LOC"
                        'End If sb.Append

                        'With Response
                        '    .Write("<tr style=""cursor:hand"" onclick=""javascript:fn_View_Record('" & ds_add.Tables(0).Rows(i).Item("Customer_ID").ToString & "','" & ds_add.Tables(0).Rows(i).Item("Given_Name").ToString & "','" & ds_add.Tables(0).Rows(i).Item("Last_Name").ToString & "');"">")

                        '    .Write("<td align='center' >" & Request("txt_Branch_Prefix") & " " & ds_add.Tables(0).Rows(i).Item("Customer_ID").ToString & "</td>")
                        '    .Write("<td align='left'>" & ds_add.Tables(0).Rows(i).Item("Given_Name").ToString & " " & ds_add.Tables(0).Rows(i).Item("Last_Name").ToString & "</td>")
                        '    .Write("<td align='center'>" & ds_add.Tables(0).Rows(i).Item("Street_Number").ToString & "</td>")
                        '    .Write("<td align='left'>" & ds_add.Tables(0).Rows(i).Item("Street_Name").ToString & "</td>")
                        '    .Write("<td align='left'>" & ds_add.Tables(0).Rows(i).Item("Suburb").ToString & "</td>")
                        '    .Write("<td align='center'>" & ds_add.Tables(0).Rows(i).Item("Post_Code").ToString & "</td>")
                        '    .Write("<td align='left'>" & ds_add.Tables(0).Rows(i).Item("Email").ToString & "</td>")
                        '    .Write("<td align='center'>" & ds_add.Tables(0).Rows(i).Item("Mobile_Phone").ToString & "</td>")
                        '    .Write("</tr>")
                        'End With


                        sb.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_Record('" & ds_add.Tables(0).Rows(i).Item("Customer_ID").ToString & "','" & ds_add.Tables(0).Rows(i).Item("Given_Name").ToString & "','" & ds_add.Tables(0).Rows(i).Item("Last_Name").ToString & "');"">")

                        sb.Append("<td align='center' >" & Request("txt_Branch_Prefix") & " " & ds_add.Tables(0).Rows(i).Item("Customer_ID").ToString & "</td>")
                        sb.Append("<td align='left'>" & ds_add.Tables(0).Rows(i).Item("Given_Name").ToString & " " & ds_add.Tables(0).Rows(i).Item("Last_Name").ToString & "</td>")
                        sb.Append("<td align='center'>" & ds_add.Tables(0).Rows(i).Item("Street_Number").ToString & "</td>")
                        sb.Append("<td align='left'>" & ds_add.Tables(0).Rows(i).Item("Street_Name").ToString & "</td>")
                        sb.Append("<td align='left'>" & ds_add.Tables(0).Rows(i).Item("Suburb").ToString & "</td>")
                        sb.Append("<td align='center'>" & ds_add.Tables(0).Rows(i).Item("Post_Code").ToString & "</td>")
                        sb.Append("<td align='left'>" & ds_add.Tables(0).Rows(i).Item("Email").ToString & "</td>")
                        sb.Append("<td align='center'>" & ds_add.Tables(0).Rows(i).Item("Mobile_Phone").ToString & "</td>")
                        sb.Append("</tr>")

                        int_Cust_ID = ds_add.Tables(0).Rows(i).Item("Customer_ID").ToString
                    Else

                    End If




                Next
                sb.Append("</table >")
                Literal1.Text = ""
                Literal1.Text = sb.ToString()
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No Record Found!!!" & "');", True)
            End If
            Session("flag_show") = 0

            
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Sub show_address_rec_new()

        Try


            Dim str_SQL As String
            Dim bln_Flag As Boolean
            Dim str_Dsiplay As String
            str_Dsiplay = ""
            bln_Flag = False
           
            str_SQL = " SELECT Tbl_Customer.Customer_ID, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Customer.Date_Of_Birth, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code, Tbl_Customer.M_Address, Tbl_Customer.M_Suburb, Tbl_Customer.M_State, Tbl_Customer.M_Post_Code,Tbl_Customer.E_Street_Name, Tbl_Customer.E_Suburb, Tbl_Customer.E_Post_Code,Tbl_Customer.Employer "


            str_SQL = str_SQL & " FROM Tbl_Customer  "

            str_SQL = str_SQL & " WHERE "

            If txtestname.Text <> "" Or txtesub_new.Text <> "" Or txtepstcode_new.Text <> "" Or txtempname.Text <> "" Then
                str_SQL = str_SQL & " ("
            End If

            If txtestname.Text <> "" Then
                str_SQL = str_SQL & " (Tbl_Customer.E_Street_Name like '" & txtestname.Text & "%' )"
                bln_Flag = True
                str_Dsiplay = "NAM"
            End If

            If txtesub_new.Text <> "" Then
                If bln_Flag = True Then
                    str_SQL = str_SQL & " OR "
                End If
                str_SQL = str_SQL & " (Tbl_Customer.E_Suburb like '" & txtesub_new.Text & "%')"
                bln_Flag = True
                str_Dsiplay = str_Dsiplay & " SUB"
            End If

            If txtepstcode_new.Text <> "" Then
                If bln_Flag = True Then
                    str_SQL = str_SQL & " OR "
                End If
                str_SQL = str_SQL & " (Tbl_Customer.E_Post_Code = " & txtepstcode_new.Text & ")"
                bln_Flag = True
                str_Dsiplay = str_Dsiplay & " POS"
            End If

            If txtempname.Text <> "" Then
                If bln_Flag = True Then
                    str_SQL = str_SQL & " OR "
                End If
                str_SQL = str_SQL & " (Tbl_Customer.Employer like '" & txtempname.Text & "%')"
                bln_Flag = True
                str_Dsiplay = str_Dsiplay & " EMP"
            End If

            If bln_Flag = True Then
                str_SQL = str_SQL & ")"
            End If

            'If Request.QueryString("SaveAs") Then
            '    str_SQL = str_SQL & " GROUP BY Tbl_Customer.Customer_ID, Tbl_Customer.Title, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Loan.Loan_ID,Tbl_Loan.Loan_Type, Tbl_Customer.Date_Of_Birth, Tbl_Customer.Home_Phone, Tbl_Customer.Work_Phone, Tbl_Customer.Mobile_Phone, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code, Tbl_Customer.M_Address, Tbl_Customer.M_Suburb, Tbl_Customer.M_State, Tbl_Customer.M_Post_Code, Tbl_Customer.Employer, Tbl_Customer.E_Contact_Person, Tbl_Customer.E_Street_Number, Tbl_Customer.E_Building, Tbl_Customer.E_Street_Name, Tbl_Customer.E_Suburb, Tbl_Customer.E_Post_Code, Tbl_Customer.E_State, Tbl_Customer.E_Phone_Number, Tbl_Customer.E_Fax_Number "
            'Else
            str_SQL = str_SQL & " GROUP BY Tbl_Customer.Customer_ID, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name,  Tbl_Customer.Date_Of_Birth, Tbl_Customer.Street_Number, Tbl_Customer.Street_Name, Tbl_Customer.Suburb, Tbl_Customer.State, Tbl_Customer.Post_Code, Tbl_Customer.M_Address, Tbl_Customer.M_Suburb, Tbl_Customer.M_State, Tbl_Customer.M_Post_Code,Tbl_Customer.Employer, Tbl_Customer.E_Street_Name,E_Suburb,E_Post_Code,Tbl_Customer.Employer  "
            'End If

            str_SQL = str_SQL & " ORDER BY Tbl_Customer.Customer_ID "

            Dim cmd_add As New SqlCommand
            Dim ds_add As New DataSet
            Dim adap_add As SqlDataAdapter

            cmd_add.CommandText = str_SQL
            cmd_add.Connection = open_con.return_con
            adap_add = New SqlDataAdapter(cmd_add)
            adap_add.Fill(ds_add)
            Dim r_count As String
            r_count = ds_add.Tables(0).Rows.Count
            Dim sb As New StringBuilder()
            If Val(r_count) <> 0 Then



                'Response.Write("<p>&nbsp;<br /><br /></p><table id='tbl' border='1' width='85%' style='font-size:16px;border:0 solid gray; border-collapse: collapse;z-index: 1; left: 250px; top: 450px; position: absolute' cellpadding='0' cellspacing='0' >")
                'Response.Write("<tr>")

                'Response.Write("<td align='center'><b>Customer ID</b></td>")
                'Response.Write("<td align='center'><b>Customer Name</b></td>")
                'Response.Write("<td align='center'><b>Employer/Agency Name</b></td>")
                'Response.Write("<td align='center'><b>Emp StreetName</b></td>")
                'Response.Write("<td align='center'><b>Emp Suburb</b></td> ")
                'Response.Write("<td align='center'><b>Emp PostCode</b></td>")
                'Response.Write("</tr>")

                'sb.Append("<table id='tbl' border='1' width='85%' style='font-size:16px;border:0 solid gray; border-collapse: collapse;z-index: 1; left: 250px; top: 450px; position: absolute' cellpadding='0' cellspacing='0' >")
                sb.Append("<table id='tbl' cellpadding='0' cellspacing='0' class='tblreport_new' width='100%'>")
                sb.Append("<tr>")
                sb.Append("<td align='center'><b>Customer ID</b></td>")
                sb.Append("<td align='center'><b>Customer Name</b></td>")
                sb.Append("<td align='center'><b>Employer/Agency Name</b></td>")
                sb.Append("<td align='center'><b>Emp StreetName</b></td>")
                sb.Append("<td align='center'><b>Emp Suburb</b></td> ")
                sb.Append("<td align='center'><b>Emp PostCode</b></td>")
                sb.Append("</tr>")

                Dim int_Index As Integer
                Dim int_Cust_ID As Integer = 0

                int_Index = 1

                Dim i As Integer = 0
                For i = 0 To ds_add.Tables(0).Rows.Count - 1


                    If int_Cust_ID <> ds_add.Tables(0).Rows(i).Item("Customer_ID").ToString Then

                        'If ds_add.Tables(0).Rows(0).Item("Loan_Type").ToString = "Loan" Then
                        '    str_Type = "Applied for Loan"
                        '    'Else
                        '    '    str_Type = "Applied for LOC"
                        'End If

                        'With Response
                        '    .Write("<tr style=""cursor:hand"" onclick=""javascript:fn_View_Record('" & ds_add.Tables(0).Rows(i).Item("Customer_ID").ToString & "','" & ds_add.Tables(0).Rows(i).Item("Given_Name").ToString & "','" & ds_add.Tables(0).Rows(i).Item("Last_Name").ToString & "');"">")
                        '    .Write("<td align='center' >" & Request("txt_Branch_Prefix") & " " & ds_add.Tables(0).Rows(i).Item("Customer_ID").ToString & "</td>")
                        '    .Write("<td align='left'>" & ds_add.Tables(0).Rows(i).Item("Given_Name").ToString & " " & ds_add.Tables(0).Rows(i).Item("Last_Name").ToString & "</td>")
                        '    .Write("<td align='left'>" & ds_add.Tables(0).Rows(i).Item("Employer").ToString & "</td>")
                        '    .Write("<td align='center'>" & ds_add.Tables(0).Rows(i).Item("E_Street_Name").ToString & "</td>")
                        '    .Write("<td align='center'>" & ds_add.Tables(0).Rows(i).Item("E_Suburb").ToString & "</td>")
                        '    .Write("<td align='center'>" & ds_add.Tables(0).Rows(i).Item("E_Post_Code").ToString & "</td>")
                        '    .Write("</tr>")
                        'End With

                        With Response
                            sb.Append("<tr style=""cursor:hand"" onclick=""javascript:fn_View_Record('" & ds_add.Tables(0).Rows(i).Item("Customer_ID").ToString & "','" & ds_add.Tables(0).Rows(i).Item("Given_Name").ToString & "','" & ds_add.Tables(0).Rows(i).Item("Last_Name").ToString & "');"">")
                            sb.Append("<td align='center' >" & Request("txt_Branch_Prefix") & " " & ds_add.Tables(0).Rows(i).Item("Customer_ID").ToString & "</td>")
                            sb.Append("<td align='left'>" & ds_add.Tables(0).Rows(i).Item("Given_Name").ToString & " " & ds_add.Tables(0).Rows(i).Item("Last_Name").ToString & "</td>")
                            sb.Append("<td align='left'>" & ds_add.Tables(0).Rows(i).Item("Employer").ToString & "</td>")
                            sb.Append("<td align='center'>" & ds_add.Tables(0).Rows(i).Item("E_Street_Name").ToString & "</td>")
                            sb.Append("<td align='center'>" & ds_add.Tables(0).Rows(i).Item("E_Suburb").ToString & "</td>")
                            sb.Append("<td align='center'>" & ds_add.Tables(0).Rows(i).Item("E_Post_Code").ToString & "</td>")
                            sb.Append("</tr>")
                        End With

                        int_Cust_ID = ds_add.Tables(0).Rows(i).Item("Customer_ID").ToString
                    Else

                    End If

                Next
                sb.Append("</table >")
                Literal1.Text = ""
                Literal1.Text = sb.ToString()
            Else

                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "No Record Found!!!" & "');", True)
            End If
            Session("flag_show") = 0
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
