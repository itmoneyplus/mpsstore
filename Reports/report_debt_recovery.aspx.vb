Imports System.Data
Partial Class Reports_report_debt_recovery
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Me.IsPostBack = False Then
            Dim dt As String = String.Format(clsGeneral.GetDateFormat(), System.DateTime.Now)
            txtFrmDate.Text = dt
            txtToDate.Text = dt
            '  bindReport()
            pnlPrint.Visible = False
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
    Sub bindReport()
        Try
            Using obj As New clsReport()
                Dim ds As DataSet = obj.getCustomerBadDebt(Date.Parse(txtFrmDate.Text), Date.Parse(txtToDate.Text))
                lblHead.Text = " " & txtFrmDate.Text & "  to  " & txtToDate.Text
                Dim df As String = clsGeneral.GetDateFormat()
                Dim sf As String = clsGeneral.GetStringFormat()
                Dim total As Decimal = 0
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim sb As New StringBuilder()
                    sb.Append("<table  width='100%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                    sb.Append("<tr >")
                    sb.Append("<th width='5%' class='center'>NO</th>")
                    sb.Append("<th width='15%' class='center'>Customer ID</th>")
                    sb.Append("<th width='35%' class='center'>Customer Name</th>")
                    sb.Append("<th width='15%' class='center'>Date of Birth</th>")
                    sb.Append("<th width='15%' class='center'>Amount</th>")
                    sb.Append("<th width='15%' class='center'>Defaulted on</th>")
                    sb.Append("</tr>")
                    Dim dr As DataRow
                    For Each dr In ds.Tables(0).Rows
                        Dim id As Integer = ds.Tables(0).Rows.IndexOf(dr) + 1

                        Dim custNo As String = Convert.ToString(dr("Customer_ID"))
                        Dim custName As String = Convert.ToString(dr("Given_Name")) & " " & Convert.ToString(dr("Last_Name"))
                        Dim dob As Date = Convert.ToString(dr("Date_Of_Birth"))
                        Dim Amount As Decimal = Convert.ToString(dr("Outstanding_Amount"))
                        total = total + Amount
                        Dim dudate As Date = Convert.ToDateTime(dr("Status_Date"))
                        sb.Append("<tr >")
                        sb.Append("<td align='left'>" & id & "</td>")
                        sb.Append("<td align='left'>" & custNo & "</td>")
                        sb.Append("<td align='left'>" & custName & "</td>")
                        sb.Append("<td align='center'>" & String.Format(df, dob) & "</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, Amount) & "</td>")
                        sb.Append("<td align='center'>" & String.Format(df, dudate) & "</td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("<tr >")

                    sb.Append("<th align='right'  colspan='4'> <b>Total</b></th>")
                    sb.Append("<th align='right'>" & String.Format(sf, total) & "</th>")
                    sb.Append("<th align='right'  colspan='0'> </th>")
                    sb.Append("</tr>")

                    sb.Append("</table>")
                    Literal1.Text = sb.ToString()
                    btnPrint.Visible = True
                Else
                    Literal1.Text = ""
                    btnPrint.Visible = False
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & " There are no notices created for the given date range and the selected method of repayment " & "');", True)

                End If

            End Using
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            bindReport()
            Session("ctrl") = pnlPrint
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnPrint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Load
       
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            bindReport()
            pnlPrint.Visible = True
        Catch ex As Exception
            ' Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
        End Try
    End Sub

    Protected Sub btnReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Load
       
    End Sub
End Class
