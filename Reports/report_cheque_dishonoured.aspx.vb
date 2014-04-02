Imports System.Data

Partial Class Reports_report_cheque_dishonoured
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Me.IsPostBack = False Then
            Try
                Dim dt As String = String.Format(clsGeneral.GetDateFormat(), System.DateTime.Now)
                txtFrmDate.Text = dt
                txtToDate.Text = dt
                bindReport()
                pnlPrint.Visible = False
            Catch ex As Exception
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
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
    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub
    Sub bindReport()
        Try
            lblHead.Text = " " & txtFrmDate.Text & "  to  " & txtToDate.Text
            Using obj As New clsReport()
                Dim sb As New StringBuilder()
                Dim sf As String = clsGeneral.GetStringFormat()
                Dim ds As DataSet = obj.GetChequedDishonuredReport(Date.Parse(txtFrmDate.Text), Date.Parse(txtToDate.Text))
                If ds.Tables(0).Rows.Count > 0 Then
                    sb.Append("<table  width='99%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                    sb.Append("<tr >")
                    sb.Append("<th width='15%' class='center'>Customer ID</th>")
                    sb.Append("<th width='40%' class='center'>Customer Name</th>")
                    sb.Append("<th width='25%' class='center'>Cheque Amount</th>")
                    sb.Append("<th width='25%' class='center'>Dishonour Date</th>")
                    sb.Append("</tr>")
                    Dim total As Decimal = 0
                    Dim dr As DataRow
                    For Each dr In ds.Tables(0).Rows
                        Dim amt As Decimal = CDec(dr("Cheque_Amount"))
                        sb.Append("<tr>")
                        sb.Append("<td align='left'>" & dr("Customer_ID") & "</td>")
                        sb.Append("<td align='left'>" & dr("Given_Name") & " " & dr("Last_Name") & "</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, amt) & "</td>")
                        sb.Append("<td align='center'>" & String.Format(clsGeneral.GetDateFormat(), dr("Transaction_Date")) & "</td>")
                        sb.Append("</tr>")
                        total = total + amt
                    Next
                    sb.Append("<tr >")
                    sb.Append("<th colspan='2'> Total</th>")
                    sb.Append("<th align='right'>" & String.Format(sf, total) & "</th>")
                    sb.Append("<th align='right'>&nbsp;</th>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    Literal1.Text = sb.ToString()
                    btnPrint.Visible = True
                Else

                    Literal1.Text = ""
                    btnPrint.Visible = False
                End If
            End Using
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Session("ctrl") = pnlPrint
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            bindReport()
            pnlPrint.Visible = True
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
        End Try
    End Sub
End Class
