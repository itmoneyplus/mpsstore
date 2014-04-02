Imports System.Data
Partial Class Reports_report_sales
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Me.IsPostBack = False Then
            bindTellers()
            Dim dt As String = String.Format(clsGeneral.GetDateFormat(), System.DateTime.Now)
            txtFrmDate.Text = dt
            txtToDate.Text = dt

            pnlPrint.Visible = False
            btnDownLoad.Visible = False
            btnPrint.Visible = False
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
    Private Sub bindTellers()
        Try
            Using obj As New clsTellers()
                Dim ds As DataSet
                ds = obj.GetTellers()
                If ds.Tables(0).Rows.Count > 0 Then
                    drpTeller.DataSource = ds
                    drpTeller.DataValueField = "User_Machine_ID"
                    drpTeller.DataTextField = "User_Machine_ID"
                    drpTeller.DataBind()
                    Dim li As New ListItem
                    li.Text = "All Teller"
                    li.Value = ""
                    drpTeller.Items.Insert(0, li)
                End If
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub bindReport()
        Try
            If drpTeller.SelectedItem.Text <> "All Teller" Then
                lblTellerName.Text = drpTeller.SelectedItem.Text
            Else
                lblTellerName.Text = ""
            End If
            lblHead.Text = " " & txtFrmDate.Text & "  to  " & txtToDate.Text
            Using obj As New clsReport()
                Dim frmdate As Date = Date.Parse(txtFrmDate.Text)
                Dim todate As Date = Date.Parse(txtToDate.Text)
                Dim bln_Display As Boolean
                Dim bln_Flag As Boolean
                Dim locfee As Decimal = 0
                Dim locfeeTotal As Decimal = 0
                Dim drawdownfee As Decimal = 0
                Dim drawdownfeeTotal As Decimal = 0
                Dim loanfee As Decimal = 0
                Dim loanfeeTotal As Decimal = 0
                Dim chqfee As Decimal = 0
                Dim chqfeeTotal As Decimal = 0
                Dim sf As String = clsGeneral.GetStringFormat()

                Dim sb As New StringBuilder()
                sb.Append("<table  width='100%' cellpadding='0' cellspacing='0' align='centre' class='tblreport_new'>")
                sb.Append("<tr>")
                sb.Append("<th width='15%' class='center'>Date</th>")
                sb.Append("<th width='16%' class='center'>LOC Fee</th>")
                sb.Append("<th width='16%' class='center'>Draw down</th>")
                sb.Append("<th width='16%' class='center'>Loan Fee</th>")
                sb.Append("<th width='17%' class='center'>Chq Cash Fee</th>")
                sb.Append("<th width='20%' class='center'>Total</th>")
                sb.Append("</tr>")

                Dim ds As DataSet = obj.getTellersSales(Date.Parse(txtFrmDate.Text), Date.Parse(txtToDate.Text), drpTeller.SelectedItem.Value)
                Dim dr As DataRow
                Do While (frmdate <= todate)
                    For Each dr In ds.Tables(0).Rows
                        If frmdate = Convert.ToDateTime(dr("Loan_Date")) Then
                            locfee = Convert.ToDecimal(dr("LOC_Fee"))
                            locfeeTotal = locfeeTotal + locfee
                            bln_Display = True
                            bln_Flag = False
                        End If
                    Next

                    For Each dr In ds.Tables(1).Rows
                        If frmdate = Convert.ToDateTime(dr("Date_Updated")) Then
                            drawdownfee = Convert.ToDecimal(dr("Draw_Down_Fee"))
                            drawdownfeeTotal = drawdownfeeTotal + drawdownfee
                            bln_Display = True
                            bln_Flag = False
                        End If
                    Next

                    For Each dr In ds.Tables(2).Rows
                        If frmdate = Convert.ToDateTime(dr("Loan_Date")) Then
                            loanfee = Convert.ToDecimal(dr("Loan_Fee"))
                            loanfeeTotal = loanfeeTotal + loanfee
                            bln_Display = True
                            bln_Flag = False
                        End If
                    Next

                    For Each dr In ds.Tables(3).Rows
                        If frmdate = Convert.ToDateTime(dr("Cheque_Cashed_On")) Then
                            chqfee = Convert.ToDecimal(dr("Cheque_Fee"))
                            chqfeeTotal = chqfeeTotal + chqfee
                            bln_Display = True
                            bln_Flag = False
                        End If
                    Next

                    If bln_Display Then
                        sb.Append("<tr >")
                        Dim lf, df, lnf, cf, tot As String
                        If locfee <> 0 Then
                            lf = String.Format(sf, locfee)
                        Else
                            lf = ""
                        End If
                        If drawdownfee <> 0 Then
                            df = String.Format(sf, drawdownfee)
                        Else
                            df = ""
                        End If

                        If loanfee <> 0 Then
                            lnf = String.Format(sf, loanfee)
                        Else
                            lnf = ""
                        End If

                        If chqfee <> 0 Then
                            cf = String.Format(sf, chqfee)
                        Else
                            cf = ""
                        End If
                        Dim total As Decimal = locfee + drawdownfee + loanfee + chqfee

                        If total <> 0 Then
                            tot = String.Format(sf, total)
                        Else
                            tot = ""
                        End If
                        sb.Append("<td align='left'>" & String.Format(clsGeneral.GetDateFormat(), frmdate) & "</td>")
                        sb.Append("<td align='right'>" & lf & "</td>")
                        sb.Append("<td align='right'>" & df & "</td>")
                        sb.Append("<td align='right'>" & lnf & "</td>")
                        sb.Append("<td align='right'>" & cf & "</td>")
                        sb.Append("<td align='right'>" & tot & "</td>")

                        sb.Append("</tr>")
                    End If

                    bln_Display = False
                    loanfee = 0
                    drawdownfee = 0
                    loanfee = 0
                    chqfee = 0
                    frmdate = frmdate.AddDays(1)

                Loop

                sb.Append("<tr >")
                Dim loft, drdf, lnft, chqt As String
                If locfeeTotal <> 0 Then
                    loft = String.Format(sf, locfeeTotal)
                Else
                    loft = ""
                End If
                If drawdownfeeTotal <> 0 Then
                    drdf = String.Format(sf, drawdownfeeTotal)
                Else
                    drdf = ""
                End If
                If loanfeeTotal <> 0 Then
                    lnft = String.Format(sf, loanfeeTotal)
                Else
                    lnft = ""
                End If
                If chqfeeTotal <> 0 Then
                    chqt = String.Format(sf, chqfeeTotal)
                Else
                    chqt = ""
                End If

                Dim Gt As Decimal = locfeeTotal + drawdownfeeTotal + loanfeeTotal + chqfeeTotal

                sb.Append("<th align='right'> <b> Grand Total</b></th>")
                sb.Append("<th align='right'>" & loft & "</th>")
                sb.Append("<th align='right'>" & drdf & "</th>")
                sb.Append("<th align='right'>" & lnft & "</th>")
                sb.Append("<th align='right'>" & chqt & "</th>")
                sb.Append("<th align='right'>" & String.Format(sf, Gt) & "</th>")
                sb.Append("</tr>")
                sb.Append("</table>")
                Literal1.Text = sb.ToString()
                btnPrint.Visible = True
                btnDownLoad.Visible = True
                If ds.Tables(0).Rows.Count = 0 And ds.Tables(1).Rows.Count = 0 And ds.Tables(2).Rows.Count = 0 And ds.Tables(3).Rows.Count = 0 Then
                    btnPrint.Visible = False
                    btnDownLoad.Visible = False
                    Literal1.Text = ""
                End If
            End Using
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
        End Try
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            bindReport()

            pnlPrint.Visible = True
            btnDownLoad.Visible = True
            btnPrint.Visible = True
        Catch ex As Exception
            Throw ex
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

    Protected Sub btnDownLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownLoad.Click

        Try
            bindReport()
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment;filename=" & "SalesReport_" & txtFrmDate.Text.ToString() & "_to_" & txtToDate.Text & ".xls")
            Response.Charset = ""
            Me.EnableViewState = False
            Dim sw As New System.IO.StringWriter()
            Dim htw As New System.Web.UI.HtmlTextWriter(sw)
            pnlPrint.RenderControl(htw)
            Response.Write(sw.ToString())
            Response.End()
        Catch ex As Exception

        End Try
    End Sub
End Class
