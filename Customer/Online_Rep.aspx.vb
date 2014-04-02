Imports System.Data.SqlClient
Imports System.Data
Partial Class Reports_MoneyPlus_Online_Rep
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Dim from_paydt, from_dt As String
            Dim to_paydt, to_dt As String
            from_paydt = Session("from_paydt")
            to_paydt = Session("to_paydt")
            Dim new_from_paydt As DateTime
            Dim new_to_paydt As DateTime
            new_from_paydt = Date.Parse(from_paydt)
            new_to_paydt = Date.Parse(to_paydt)
            from_dt = new_from_paydt.ToString("dd-MMM-yyyy")
            from_dt = from_dt.Replace("-", " ")
            to_dt = new_to_paydt.ToString("dd-MMM-yyyy")
            to_dt = to_dt.Replace("-", " ")
            Dim cmd_paydt As New SqlCommand
            Dim str_paydt As String
            cmd_paydt.Connection = open_con.return_con
            str_paydt = "SELECT Customer_ID, Given_Name, Last_Name, Date_Joined, Time_Joined, Request_Amount From Tbl_Customer WHERE Tbl_Customer.Request_Amount <> 0  AND  Date_Joined "
            str_paydt = str_paydt & " >= '" & from_paydt & "'  AND Date_Joined <=  '" & to_paydt & "' ORDER BY Date_Joined, Time_Joined"
            cmd_paydt.CommandText = str_paydt
            Dim dataadap_paydt As SqlDataAdapter
            Dim ds_paydt As New DataSet
            dataadap_paydt = New SqlDataAdapter(cmd_paydt)
            dataadap_paydt.Fill(ds_paydt)
            Response.Write("<body onload='window.print();' ondblClick='JavaScript:history.go(-1);'>")
            Response.Write("<div style='text-align:left'>")
            Response.Write("<span style='font-size:18px;font-style:italic'>")
            Response.Write("Online Customer Joined for the period ")
            Response.Write(from_dt)
            Response.Write(" to ")
            Response.Write(to_dt)
            Response.Write("</span>")
            Response.Write("</div>")
            Response.Write("<br/>")
            Response.Write("<div align='center'>")
            Response.Write("<table border='1' width='100%' style='font-size:16px;border:0 solid #FFFFFF; border-collapse: collapse' cellpadding='0' cellspacing='0' bordercolor='#C0C0C0'>")
            Response.Write("<tr>")
            Response.Write("<td style='height:20;text-align:center;font-weight:bold' bgcolor='#EFEFEF' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>No</td>")
            Response.Write("<td  style='width:180;height:20;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Customer ID</td>")
            Response.Write("<td  style='width:350;height:20;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Customer Name</td>")
            Response.Write("<td  style='width:350;height:20;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Request Amount</td>")
            Response.Write("<td  style='width:200;height:20;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Date Joined</td>")
            Response.Write("<td  style='width:180;height:20;text-align:center;font-weight:bold' bgcolor='#EFEFEF'  bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>Time</td>")
            Response.Write("</tr>")
            '''''''''''''''''''''''''''''''''''''''''''''
            Dim i As Integer
            For i = 0 To ds_paydt.Tables(0).Rows.Count - 1

                Response.Write("<tr>")
                Response.Write("<td  style='text-align:center' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write(i + 1)
                Response.Write("</td>")
                Response.Write("<td style='width:180;text-align:center' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write(Session("branch_prefix") & " " & CInt(ds_paydt.Tables(0).Rows(i).Item("Customer_ID").ToString))
                Response.Write("</td>")
                Response.Write("<td  style='width:630;text-align:left' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Response.Write(ds_paydt.Tables(0).Rows(i).Item("Given_Name").ToString & " " & ds_paydt.Tables(0).Rows(i).Item("Last_Name").ToString)
                Response.Write("</td>")
                Response.Write("<td  style='width:180;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Dim amt_rep As Double
                amt_rep = CDbl(ds_paydt.Tables(0).Rows(i).Item("Request_Amount").ToString)
                Response.Write("$" & Math.Round(amt_rep, 2) & ".00")
                Response.Write("</td>")
                Response.Write("<td style='width:250;text-align:center' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Dim rep_date As DateTime
                rep_date = Date.Parse(ds_paydt.Tables(0).Rows(i).Item("Date_Joined").ToString)
                Dim new_time1 As String
                new_time1 = rep_date.ToString("dd-MMM-yyyy")
                Response.Write(new_time1.Replace("-", " "))
                Response.Write("</td>")
                Response.Write("<td style='width:200;text-align:center' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
                Dim rep_time As DateTime
                rep_time = Date.Parse(ds_paydt.Tables(0).Rows(i).Item("Time_Joined").ToString)
                Response.Write(rep_time.ToString("hh:mm tt"))
                Response.Write("</td>")
                Response.Write("</tr>")
            Next
            Response.Write("<tr>")
            Response.Write("<td  colspan='5' style='font-weight:bold;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
            Response.Write("Number of customers found for the above period:")
            Response.Write("</td>")
            Response.Write("<td   style='font-weight:bold;text-align:right' bordercolorlight='#C0C0C0' bordercolordark='#C0C0C0'>")
            Response.Write(ds_paydt.Tables(0).Rows.Count)
            Response.Write("</td>")
            Response.Write("</tr>")
            '''''''''''''''''''''''''''''''''''''''''''''
            Response.Write("</table>")
            Response.Write("</div>")
            Response.Write("</body>")

            cmd_paydt.Dispose()
            dataadap_paydt.Dispose()
            ds_paydt.Dispose()
            open_con.return_con.Dispose()

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try



    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
