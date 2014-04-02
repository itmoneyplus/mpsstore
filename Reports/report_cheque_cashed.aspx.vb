Imports System.Data
Partial Class Reports_report_cheque_cashed
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
                Throw ex
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
                Dim ds As DataSet = obj.GetChequedCashedReport(Date.Parse(txtFrmDate.Text), Date.Parse(txtToDate.Text))
                If ds.Tables(0).Rows.Count > 0 Then
                    sb.Append("<table  width='99%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                    sb.Append("<tr >")
                    sb.Append("<th width='20%' class='center'>Date</th>")
                    sb.Append("<th width='10%' class='center'>No</th>")
                    sb.Append("<th width='20%' class='center'>Cheque Amount</th>")
                    sb.Append("<th width='20%' class='center'>Cash Given</th>")
                    sb.Append("<th width='15%' class='center'>Cheque Fee</th>")
                    sb.Append("<th width='15%' class='center'>Percentage</th>")
                    sb.Append("</tr>")
                    Dim chqgaTotal, chqaTotal, chqfTotal, ncTotal, perTotal As Decimal
                    Dim dr As DataRow
                    For Each dr In ds.Tables(0).Rows
                        Dim chqga As Decimal = 0
                        Dim chqa As Decimal = CDec(dr("Cheque_Amount"))
                        chqaTotal = chqaTotal + chqa
                        Dim chqf As Decimal = CDec(dr("Cheque_Fee"))
                        chqfTotal = chqfTotal + chqf
                        chqga = chqa - chqf
                        chqgaTotal = chqgaTotal + chqga
                        Dim nc As Integer = CInt(dr("Number_of_Cheques"))
                        ncTotal = ncTotal + nc

                        Dim per As Decimal = chqf / chqa 'CDec(dr("perc"))
                        sb.Append("<tr>")
                        sb.Append("<td align='left'>" & String.Format(clsGeneral.GetDateFormat(), dr("Cheque_Cashed_On")) & "</td>")
                        sb.Append("<td align='center'>" & nc & "</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, chqa) & "</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, chqga) & "</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, chqf) & "</td>")
                        sb.Append("<td align='right'>" & String.Format(clsGeneral.getPercFormat(), per) & "</td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("<tr >")
                    sb.Append("<th > Total</th>")
                    sb.Append("<th align='center'>" & ncTotal & "</th>")
                    sb.Append("<th align='right'>" & String.Format(sf, chqaTotal) & "</th>")
                    sb.Append("<th align='right'>" & String.Format(sf, chqgaTotal) & "</th>")
                    sb.Append("<th align='right'>" & String.Format(sf, chqfTotal) & "</th>")
                    sb.Append("<th align='right'>&nbsp;</th>")
                    sb.Append("</tr>")

                    Dim avgper As Decimal = chqfTotal / chqaTotal

                    sb.Append("<tr>")
                    sb.Append("<th > Average </th>")
                    sb.Append("<th align='right' colspan='5'>" & String.Format(clsGeneral.getPercFormat(), avgper) & "</th>")
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

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Session("ctrl") = pnlPrint
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
