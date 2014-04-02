Imports System.Data.SqlClient
Imports System.Data
Partial Class Customer_Loan_Status
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Val(txtfrom_loanstatus.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            ElseIf Val(txtto_loanstatus.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid ending date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            ElseIf CDate(txtfrom_loanstatus.Text) > CDate(txtto_loanstatus.Text) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid future date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            Else

                loanstatus_Rep()
                panel2.Visible = True


            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try



    End Sub
    Sub loanstatus_Rep()

        Dim Print_from_loanstatus As String
        Dim Print_to_loanstatus As String

        Print_from_loanstatus = txtfrom_loanstatus.Text
        Print_to_loanstatus = txtto_loanstatus.Text

        Dim new_from_loanstatus As String
        Dim new_to_loanstatus As String
        new_from_loanstatus = Date.Parse(Print_from_loanstatus).ToString("yyyy-MM-dd")
        new_to_loanstatus = Date.Parse(Print_to_loanstatus).ToString("yyyy-MM-dd")


        Print_from_loanstatus = Date.Parse(Print_from_loanstatus).ToString("dd-MMM-yyyy")
        Print_from_loanstatus = Print_from_loanstatus.Replace("-", " ")
        Print_to_loanstatus = Date.Parse(Print_to_loanstatus).ToString("dd-MMM-yyyy")
        Print_to_loanstatus = Print_to_loanstatus.Replace("-", " ")


        Dim dt1, dt2 As DateTime
        dt1 = Convert.ToDateTime(txtto_loanstatus.Text)
        Session("dt1_loanstatus") = dt1
        dt2 = Convert.ToDateTime(txtfrom_loanstatus.Text)
        Session("dt2_loanstatus") = dt2

        Label2.Visible = True
        Label2.Text = "Loans Statistics Report for the period " & Print_from_loanstatus & " to " & Print_to_loanstatus


        Dim int_Total_Loans As Integer
        int_Total_Loans = 0
        Dim str_SQL_loans As String
        str_SQL_loans = " SELECT Count(Status) as Total From Tbl_Loan WHERE Loan_Type ='Loan'"
        Dim cmd_loannew As New SqlCommand
        Dim ds_loannew As New DataSet
        Dim adap_loannew As SqlDataAdapter

        cmd_loannew.CommandText = str_SQL_loans
        cmd_loannew.Connection = open_con.return_con
        adap_loannew = New SqlDataAdapter(cmd_loannew)
        adap_loannew.Fill(ds_loannew)
        Dim j As Integer = 0

        For j = 0 To ds_loannew.Tables(0).Rows.Count - 1
            int_Total_Loans = ds_loannew.Tables(0).Rows(0).Item("Total").ToString
        Next



        Dim str_SQL As String
        Dim str_status As String
        str_SQL = " SELECT Tbl_Loan.Loan_ID, Tbl_Loan.Status, Tbl_Customer.Customer_ID, Tbl_Customer.Last_Name, Tbl_Customer.Given_Name, Tbl_Loan.Loan_Date "
        str_SQL = str_SQL & " FROM Tbl_Customer INNER JOIN Tbl_Loan ON Tbl_Customer.Customer_ID = Tbl_Loan.Customer_ID WHERE  "
        str_SQL = str_SQL & " Tbl_Loan.Loan_Type ='Loan' AND Loan_Date >= '" & new_from_loanstatus & "'  AND Loan_Date <=  '" & new_to_loanstatus & "' ORDER BY Tbl_Loan.Status, Tbl_Loan.Loan_Date"

        Dim cmd_loanstatus As New SqlCommand
        Dim ds_loanstatus As New DataSet
        Dim adap_loanstatus As SqlDataAdapter

        cmd_loanstatus.CommandText = str_SQL
        cmd_loanstatus.Connection = open_con.return_con
        adap_loanstatus = New SqlDataAdapter(cmd_loanstatus)
        adap_loanstatus.Fill(ds_loanstatus)

        Dim sb As New StringBuilder()

        'Response.Write("<body>")
        'Response.Write("<div align='center'>")
        'Response.Write("<table id='tbl' border='1' width='78%' style='font-size:16px;border:0 solid gray; border-collapse: collapse;z-index: 1; left: 285px; top: 300px; position: absolute' cellpadding='0' cellspacing='0' >")
        sb.Append("<tr>")
        sb.Append("<td style='border: 1px solid #C0C0C0;background-color:#EEEEEE'><b>&nbsp;Loan ID</b></td>")
        sb.Append("<td style='border: 1px solid #C0C0C0;background-color:#EEEEEE'><b>&nbsp;Customer_ID</b></td>")
        sb.Append("<td style='border: 1px solid #C0C0C0;background-color:#EEEEEE'><b>&nbsp;Status</b></td>")
        sb.Append("<td style='border: 1px solid #C0C0C0;background-color:#EEEEEE'><b>&nbsp;Customer Name</b></td>")
        sb.Append("<td style='border: 1px solid #C0C0C0;background-color:#EEEEEE'><b>Date of Loan&nbsp;</b></td> ")
        sb.Append("</tr>")
        Dim int_No, int_Pending, int_Declined, int_Approved As Integer
        int_No = 0
        int_Pending = 0
        int_Declined = 0
        int_Approved = 0
        str_status = ""
        If Not ds_loanstatus.Tables(0).Rows.Count = 0 Then
            Dim i As Integer = 0
            For i = 0 To ds_loanstatus.Tables(0).Rows.Count - 1

                If ds_loanstatus.Tables(0).Rows(i).Item("Status").ToString = 1 Then
                    str_status = "<font color=""#008000"">Approved</font>"
                    int_Approved = int_Approved + 1
                ElseIf ds_loanstatus.Tables(0).Rows(i).Item("Status") = 2 Then
                    str_status = "<font color=""#FF0000"">Declined</font>"
                    int_Declined = int_Declined + 1
                ElseIf ds_loanstatus.Tables(0).Rows(i).Item("Status") = 0 Then
                    int_Pending = int_Pending + 1
                    str_status = "<font color=""#000080"">Pending</font>"
                End If

                With sb
                    .Append("<tr>")
                    .Append("<td style='border: 1px solid #C0C0C0;text-align:left'>&nbsp;" & ds_loanstatus.Tables(0).Rows(i).Item("Loan_ID").ToString & "</td>")
                    .Append("<td style='border: 1px solid #C0C0C0'>&nbsp;" & Session("branch_prefix") & " " & ds_loanstatus.Tables(0).Rows(i).Item("Customer_ID").ToString & "</td>")
                    .Append("<td style='border: 1px solid #C0C0C0'>&nbsp;" & str_status & "</td>")
                    .Append("<td style='border: 1px solid #C0C0C0'>&nbsp;" & ds_loanstatus.Tables(0).Rows(i).Item("Given_Name").ToString & " " & ds_loanstatus.Tables(0).Rows(i).Item("Last_Name").ToString & "</td>")
                    .Append("<td style='border: 1px solid #C0C0C0;text-align:right'>" & fn_FormatMPDate(ds_loanstatus.Tables(0).Rows(i).Item("Loan_Date").ToString) & "&nbsp;</td>")
                    .Append("</tr>")
                End With

                int_No = int_No + 1


            Next
        End If

        sb.Append("<tr>")
        sb.Append("<td colspan='4' style='border: 1px solid #C0C0C0;text-align:right'><b>Loans Approved&nbsp;</b></td>")
        sb.Append("<td style='border: 1px solid #C0C0C0;text-align:right'><b>" & int_Approved & "</b></td>")
        sb.Append("</tr>")
        sb.Append("<tr>")
        sb.Append("<td colspan='4' style='border: 1px solid #C0C0C0;text-align:right'><b>Loans Declined&nbsp;</b></td>")
        sb.Append("<td style='border: 1px solid #C0C0C0;text-align:right'><b>" & int_Declined & "</b></td>")
        sb.Append("</tr>")
        sb.Append("<tr>")
        sb.Append("<td colspan='4' style='border: 1px solid #C0C0C0;text-align:right'><b>Loans Pending&nbsp;</b></td>")
        sb.Append("<td style='border: 1px solid #C0C0C0;text-align:right'><b>" & int_Pending & "</b></td>")
        sb.Append("</tr>")
        sb.Append("<tr>")
        sb.Append("<td colspan='4' style='border: 1px solid #C0C0C0;text-align:right'><b>Total Loans&nbsp;</b></td>")
        sb.Append("<td style='border: 1px solid #C0C0C0;text-align:right'><b>" & int_No & "</b></td>")
        sb.Append("</tr>")
        sb.Append("<tr>")
        sb.Append("<td colspan='4' style='border: 1px solid #C0C0C0;text-align:right'><b>Total loans found for this branch&nbsp;</b></td>")
        sb.Append("<td style='border: 1px solid #C0C0C0;text-align:right'><b>" & int_Total_Loans & "</b></td>")
        sb.Append("</tr>")
        sb.Append("<tr>")
        sb.Append("<td colspan='14' style='border-color:white;text-align:center'>")

        sb.Append("<br/>")
        sb.Append("<br/>")

        sb.Append("<input type='button' ID='Button1'  value='Re-Create Again'   onclick='return ClearTextboxes() ' />")
        sb.Append("&nbsp;&nbsp;&nbsp;")
        sb.Append("<input ID='Button2' type='button' value='View & Print' onclick='return Button2_onclick()'/>")
        sb.Append("</td>")
        sb.Append("</tr>")


        sb.Append("</table>")
        'Response.Write("</div>")
        'Response.Write("</body>")
        Literal1.Text = sb.ToString()
        cmd_loanstatus.Dispose()
        cmd_loannew.Dispose()
        ds_loanstatus.Dispose()
        ds_loannew.Dispose()
        adap_loanstatus.Dispose()
        adap_loannew.Dispose()
        open_con.return_con.Dispose()

    End Sub

    Function fn_FormatMPDate(ByVal fn_date As String) As String
        Dim fn_loanstatus As String
        Dim fn_loanstatus_new As Date
        fn_loanstatus_new = Convert.ToDateTime(fn_date)
        fn_loanstatus = Date.Parse(fn_loanstatus_new.ToString("dd-MMM-yyyy"))
        fn_loanstatus = fn_loanstatus.Replace("-", " ")
        Return fn_loanstatus

    End Function
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
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
End Class
