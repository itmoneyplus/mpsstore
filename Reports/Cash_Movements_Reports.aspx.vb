Imports System.Data
Imports System.String
Partial Class Reports_Cash_Movements_Reports
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Val(txtfrom_periodic.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid beginning date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            ElseIf Val(txtto_perodic.Text) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid ending date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            ElseIf CDate(txtfrom_periodic.Text) > CDate(txtto_perodic.Text) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please Enter a valid future date!!!" & "');", True)
                Label2.Visible = False
                Exit Sub
            Else
                bindReport()
                panel2.Visible = True
                pnlPrint.Visible = True
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub bindReport()
        Try
            Dim fromDate As Date = Convert.ToDateTime(txtfrom_periodic.Text)
            Dim toDate As Date = Convert.ToDateTime(txtto_perodic.Text)
            Dim sb As New StringBuilder()
            Dim ob As Decimal = 0
            Dim ob2 As Decimal = 0
            sb.Append("<p>" & Session("branch_name") & "</p>")
            sb.Append("<b><h3 style='text-align:center;'>Cash Movements for Abaz from " & txtfrom_periodic.Text.ToString() & " to " & txtto_perodic.Text.ToString() & "</h3> </b>")
            Using obj As New clsReport()
                Dim ds As DataSet = obj.GetCashMovements(fromDate, toDate)
                If ds.Tables(0).Rows.Count > 0 Then
                    sb.Append("<table  width='99%' cellpadding='0' cellspacing='0' align='centre' class='tblreport'>")
                    sb.Append("<tr >")
                    sb.Append("<th width='13%' class='center'>Date</th>")
                    sb.Append("<th width='23%' class='center'>Description</th>")
                    sb.Append("<th width='16%' class='center'>Cash In</th>")
                    sb.Append("<th width='16%' class='center'>Cash Out</th>")
                    sb.Append("<th width='19%' class='center'>Balance</th>")
                    sb.Append("<th width='13%' class='center'>Staff</th>")
                    sb.Append("</tr>")
                    sb.Append("<tr >")
                    sb.Append("<th colspan ='4' align='right' class='white right'> Opening Balance </th>")
                    ob = ds.Tables(0).Rows(0).Item("OB1")
                    sb.Append("<th align='right' class='white right' >" & String.Format(clsGeneral.GetStringFormat(), ob) & "</th>")
                    sb.Append("<th class='white'> </th>")
                    sb.Append("</tr >")
                End If

                If ds.Tables(1).Rows.Count > 0 Then
                    Dim dr As DataRow
                    Dim bal As Decimal = ob
                    For Each dr In ds.Tables(1).Rows
                        Dim dt As Date = dr("date")
                        Dim des As String = ""
                        Dim cashin As String = ""
                        Dim cashout As String = ""
                        Dim amt As Decimal = Convert.ToDecimal(dr("Amount"))
                        Dim desc As String = Convert.ToString(dr("Description"))
                        Dim staff As String = dr("Given_Name")
                        Dim toview As Boolean = False
                        If desc = "Cash brought from Safe to Abaz Teller Account" Then
                            cashin = ""
                            des = "Teller " & Right(Convert.ToString(dr("User_Machine_ID")), 1)
                            cashout = String.Format(clsGeneral.GetStringFormat(), amt)
                            bal = bal - amt
                            toview = True
                        ElseIf desc = "Cash returned to Safe from Abaz Teller Account" Then
                            cashin = String.Format(clsGeneral.GetStringFormat(), amt)
                            des = "Teller " & Right(Convert.ToString(dr("User_Machine_ID")), 1)
                            cashout = ""
                            bal = bal + amt
                            toview = True
                        ElseIf desc = "Amount deducted from Abaz Teller Account due to error" Then
                            cashin = ""
                            des = "Teller " & Right(Convert.ToString(dr("User_Machine_ID")), 1) & " Error -"
                            cashout = String.Format(clsGeneral.GetStringFormat(), amt)
                            ' bal = bal + amt
                            toview = True
                        ElseIf desc = "Amount added in Abaz Teller Account due to error" Then
                            cashin = String.Format(clsGeneral.GetStringFormat(), amt)
                            des = "Teller " & Right(Convert.ToString(dr("User_Machine_ID")), 1) & " Error +"
                            cashout = ""
                            toview = True
                        ElseIf InStr(desc, "ABAZ", CompareMethod.Text) = 1 Then
                            cashin = String.Format(clsGeneral.GetStringFormat(), amt)
                            des = desc
                            cashout = ""
                            bal = bal + amt
                            toview = True
                        ElseIf desc = "Amount deducted from Abaz Safe Account due to error" Then
                            cashin = ""
                            des = "Safe Error -"
                            cashout = String.Format(clsGeneral.GetStringFormat(), amt)
                            bal = bal - amt
                            toview = True
                        ElseIf desc = "Amount added in Abaz Safe Account due to error" Then
                            cashin = String.Format(clsGeneral.GetStringFormat(), amt)
                            des = "Safe Error +"
                            cashout = ""
                            bal = bal + amt
                            toview = True
                        Else
                            toview = False
                        End If
                        If toview = True Then
                            sb.Append("<tr>")
                            sb.Append("<td align='left'>" & String.Format(clsGeneral.GetDateFormat("/"), dt) & "</td>")
                            sb.Append("<td align='left'>" & des & "</td>")
                            sb.Append("<td align='right'>" & cashin & "</td>")
                            sb.Append("<td align='right'>" & cashout & "</td>")
                            sb.Append("<td align='right'>" & String.Format(clsGeneral.GetStringFormat(), bal) & "</td>")
                            sb.Append("<td align='left'>" & staff & "</td>")
                            sb.Append("</tr>")
                        End If
                       
                    Next
                   
                End If
                sb.Append("</table>")

                sb.Append("<b><h3 style='text-align:center;'>Cash Movements for M/Plus from " & txtfrom_periodic.Text.ToString() & " to " & txtto_perodic.Text.ToString() & "</h3> </b>")
                If ds.Tables(0).Rows.Count > 0 Then
                    sb.Append("<table  width='99%' cellpadding='0' cellspacing='0' align='centre' class='tblreport'>")
                    sb.Append("<tr >")
                    sb.Append("<th width='13%' class='center'>Date</th>")
                    sb.Append("<th width='23%' class='center'>Description</th>")
                    sb.Append("<th width='16%' class='center'>Cash In</th>")
                    sb.Append("<th width='16%' class='center'>Cash Out</th>")
                    sb.Append("<th width='19%' class='center'>Balance</th>")
                    sb.Append("<th width='13%' class='center'>Staff</th>")
                    sb.Append("</tr>")
                    sb.Append("<tr >")
                    sb.Append("<th colspan ='4' align='right' class='white right'> Opening Balance </th>")
                    ob2 = ds.Tables(0).Rows(0).Item("OB2")
                    sb.Append("<th align='right' class='white right' >" & String.Format(clsGeneral.GetStringFormat(), ob2) & "</th>")
                    sb.Append("<th class='white'> </th>")
                    sb.Append("</tr >")
                End If

                If ds.Tables(1).Rows.Count > 0 Then
                    Dim dr As DataRow
                    Dim bal2 As Decimal = ob2
                    For Each dr In ds.Tables(1).Rows
                        Dim dt As Date = dr("date")
                        Dim des As String = ""
                        Dim cashin As String = ""
                        Dim cashout As String = ""
                        Dim amt As Decimal = Convert.ToDecimal(dr("Amount"))
                        Dim desc As String = Convert.ToString(dr("Description"))
                        Dim staff As String = dr("Given_Name")
                        Dim toview As Boolean = False

                        If desc = "Cash brought from Safe to M/Plus Teller Account" Then
                            cashin = ""
                            des = "Teller " & Right(Convert.ToString(dr("User_Machine_ID")), 1)
                            cashout = String.Format(clsGeneral.GetStringFormat(), amt)
                            bal2 = bal2 - amt
                            toview = True
                        ElseIf desc = "Cash returned to Safe from M/Plus Teller Account" Then
                            cashin = String.Format(clsGeneral.GetStringFormat(), amt)
                            des = "Teller " & Right(Convert.ToString(dr("User_Machine_ID")), 1)
                            cashout = ""
                            bal2 = bal2 + amt
                            toview = True
                        ElseIf desc = "Amount deducted from M/Plus Teller Account due to error" Then
                            cashin = ""
                            des = "Teller " & Right(Convert.ToString(dr("User_Machine_ID")), 1) & " Error -"
                            cashout = String.Format(clsGeneral.GetStringFormat(), amt)
                            'bal = bal + amt
                            toview = True
                        ElseIf desc = "Amount added in M/Plus Teller Account due to error" Then
                            cashin = String.Format(clsGeneral.GetStringFormat(), amt)
                            des = "Teller " & Right(Convert.ToString(dr("User_Machine_ID")), 1) & "  Error +"
                            cashout = ""
                            'bal = bal + amt
                            toview = True
                        ElseIf InStr(desc, "M/Plus", CompareMethod.Text) = 1 Then
                            cashin = String.Format(clsGeneral.GetStringFormat(), amt)
                            des = desc
                            cashout = ""
                            bal2 = bal2 + amt
                            toview = True
                        ElseIf desc = "Amount deducted from M/Plus Safe Account due to error" Then
                            cashin = ""
                            des = "Safe Error -"
                            cashout = String.Format(clsGeneral.GetStringFormat(), amt)
                            bal2 = bal2 - amt
                            toview = True
                        ElseIf desc = "Amount added in M/Plus Safe Account due to error" Then
                            cashin = String.Format(clsGeneral.GetStringFormat(), amt)
                            des = "Safe Error +"
                            cashout = ""
                            bal2 = bal2 + amt
                            toview = True
                        Else
                            toview = False
                        End If
                        If toview = True Then
                            sb.Append("<tr>")
                            sb.Append("<td align='left'>" & String.Format(clsGeneral.GetDateFormat("/"), dt) & "</td>")
                            sb.Append("<td align='left'>" & des & "</td>")
                            sb.Append("<td align='right'>" & cashin & "</td>")
                            sb.Append("<td align='right'>" & cashout & "</td>")
                            sb.Append("<td align='right'>" & String.Format(clsGeneral.GetStringFormat(), bal2) & "</td>")
                            sb.Append("<td align='left'>" & staff & "</td>")
                            sb.Append("</tr>")
                        End If

                    Next

                End If
                sb.Append("</table>")
            End Using
            llAbaz.Text = sb.ToString()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Me.IsPostBack = False Then
            Try
                Dim dt As String = String.Format("{0:dd-MMM-yyyy}", DateAndTime.Now.Date)
                txtfrom_periodic.Text = dt
                txtto_perodic.Text = dt
                bindReport()
                panel2.Visible = False
                pnlPrint.Visible = False
            Catch ex As Exception

            End Try

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

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

       
        Session("ctrl") = pnlPrint
        ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>")
    End Sub
    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub
End Class
