Imports System.Data

Partial Class Reports_report_loan_debtor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Me.IsPostBack = False Then
            Try
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
    Protected Sub LinkButton_Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_back.Click
        Dim refUrl As Object = ViewState("RefUrl")
        If refUrl IsNot Nothing Then
            Response.Redirect(DirectCast(refUrl, String))
        End If
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        pnlPrint.Visible = True
        Try
            If (chkLoan.Checked = False And chkLoc.Checked = False) Then
                lblHead1.Text = ""
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select Loan / LOC " & "');", True)
                Exit Sub
            End If
            If (chkCurrent.Checked = False And chkDefault.Checked = False And chkHOD.Checked = False And chkWof.Checked = False) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select atleast one debtor category " & "');", True)
                Exit Sub
            End If
            Dim dt As String = String.Format(clsGeneral.GetDateFormat(), System.DateTime.Now)
            lblHead.Text = dt & ";&nbsp;  "

            If chkLoan.Checked = True And chkLoc.Checked = True Then
                lblHead1.Text = "Loan / LOC"
            Else
                If chkLoan.Checked = True Then
                    lblHead1.Text = "Loan"
                ElseIf chkLoc.Checked = True Then
                    lblHead1.Text = "LOC"

                End If
            End If


            Dim chkcur, chkdef, ckhod, chwof, chloan, chloc As String
            lblHead.Text = lblHead.Text & " " & "Debtor category:"
            If chkCurrent.Checked = True Then
                chkcur = "Yes"
                lblHead.Text = lblHead.Text & " CUR "
            Else
                chkcur = ""
            End If
            If chkDefault.Checked = True Then
                chkdef = "Yes"
                lblHead.Text = lblHead.Text & " DEF "
            Else
                chkdef = ""
            End If
            If chkHOD.Checked = True Then
                ckhod = "Yes"
                lblHead.Text = lblHead.Text & " HOD "
            Else
                ckhod = ""
            End If
            If chkWof.Checked = True Then
                chwof = "Yes"
                lblHead.Text = lblHead.Text & " WOF "
            Else
                chwof = ""
            End If
            If chkLoan.Checked = True Then
                chloan = "Loan"
            Else
                chloan = ""
            End If
            If chkLoc.Checked = True Then
                chloc = "LOC"
            Else
                chloc = ""
            End If

            Using obj As New clsReport()
                Dim sb As New StringBuilder()
                Dim sf As String = clsGeneral.GetStringFormat()
                Dim ds As DataSet = obj.getLoanLocDebtorReport(chkcur, chkdef, ckhod, chwof, chloan, chloc)
                If ds.Tables(0).Rows.Count > 0 Then

                    sb.Append("<table  width='99%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                    sb.Append("<tr >")
                    sb.Append("<th width='10%' class='center'>No</th>")
                    sb.Append("<th width='12%' class='center'>Customer ID</th>")
                    sb.Append("<th width='35%' class='center'>Customer Name</th>")
                    sb.Append("<th width='18%' class='center'>Loan / LOC ID </th>")
                    sb.Append("<th width='25%' class='center'>Outstanding Amount</th>")
                    sb.Append("</tr>")
                    Dim total As Decimal = 0
                    Dim dr As DataRow
                    For Each dr In ds.Tables(0).Rows
                        Dim id As Integer = ds.Tables(0).Rows.IndexOf(dr) + 1
                        Dim custNo As String = Convert.ToString(dr("Customer_ID"))
                        Dim gname As String = Convert.ToString(dr("Given_Name"))
                        Dim Lname As String = Convert.ToString(dr("Last_Name"))
                        Dim custName As String = gname & " " & Lname
                        Dim LoanID As String = Convert.ToString(dr("Loan_ID"))
                        Dim amt As Decimal = Convert.ToDecimal(dr("Outstanding_Amount"))
                        total = total + amt
                        sb.Append("<tr  onclick=""javascript:fn_View_Record1('" & custNo & "','" & gname & "','" & Lname & "');"">")
                        sb.Append("<td align='center'>" & id & "</td>")
                        sb.Append("<td align='left'>" & custNo & "</td>")
                        sb.Append("<td align='left'>" & custName & "</td>")
                        sb.Append("<td align='center'>" & LoanID & "</td>")
                        sb.Append("<td align='right'>" & String.Format(sf, amt) & "</td>")

                        sb.Append("</tr>")

                    Next
                    sb.Append("<tr >")

                    sb.Append("<th align='right'  colspan='4'> <b>Total</b></th>")
                    sb.Append("<th align='right'>" & String.Format(sf, total) & "</th>")
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
End Class
