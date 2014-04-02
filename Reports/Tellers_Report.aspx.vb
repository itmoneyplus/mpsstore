Imports System.Data
Partial Class Reports_Tellers_Report
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If (Me.IsPostBack = False) Then
            bindTellers()
            txtRepDate.Text = String.Format("{0:dd-MMM-yyyy}", DateAndTime.Now.Date)

            bindReport()
            pnlPrint.Visible = False
            btnDownload.Visible = False
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
                    '  drpTeller.Items.Insert(0, "All Teller")
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
            Dim MachineID As String = drpTeller.SelectedValue.ToString()
            Dim Dtoday As Date = Convert.ToDateTime(txtRepDate.Text)
            BindTotal(MachineID, Dtoday)
            bindLoc(MachineID, Dtoday)
            bindLoan(MachineID, Dtoday)
            bindLoanRepay(MachineID, Dtoday)
            binChqCashIn(MachineID, Dtoday)
            bindPaymentCollection(MachineID, Dtoday)
            bindTillCount()
            If drpTeller.SelectedValue = "" Then
                lblHead.Text = "Tellers  "
            Else
                lblHead.Text = drpTeller.SelectedItem.Text
            End If
            lblHead.Text = lblHead.Text + "  Report as at  " + txtRepDate.Text.ToString()
            lblLoginName.Text = Convert.ToString(Session("username")) & "  " & String.Format(clsGeneral.GetTimeFormat(), System.DateTime.Now)
        Catch ex As Exception
            Throw ex
        End Try
       
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            bindReport()
            btnDownload.Visible = True
            btnPrint.Visible = True
            pnlPrint.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub bindTillCount()
        Try
            Using obj As New clsTellers()
                gvTillCount.DataSource = obj.GetTillCountDs()
                gvTillCount.DataBind()

            End Using

        Catch ex As Exception

        End Try
    End Sub
    Private Sub bindPaymentCollection(ByVal MachineID As String, ByVal Dtoday As Date)
        Try
            Using obj As New clsTellers()
                Dim dsLoan As DataSet = obj.BindTellerPaymentCollection(MachineID, Dtoday)
                If dsLoan.Tables(0).Rows.Count > 0 Then
                  

                    Dim CustAmount As Decimal = 0
                    gvPmtCol.DataSource = dsLoan
                    gvPmtCol.DataBind()
                    If gvPmtCol.Rows.Count > 0 Then
                        gvPmtCol.HeaderRow.TableSection = TableRowSection.TableHeader
                        gvPmtCol.FooterRow.TableSection = TableRowSection.TableFooter
                        For Each gr As GridViewRow In gvPmtCol.Rows
                           
                            Dim lblAmount As Label = CType(gr.FindControl("lblAmount"), Label)
                            CustAmount = CustAmount + Convert.ToDecimal(lblAmount.Text.Replace("$", ""))
                          
                        Next
                      

                        CType(gvPmtCol.FooterRow.FindControl("lblAmountTotal"), Label).Text = String.Format(clsGeneral.GetStringFormat(), CustAmount)

                    End If
                Else

                    gvPmtCol.DataSource = Nothing
                    gvPmtCol.DataBind()
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub BindTotal(ByVal MachineID As String, ByVal Dtoday As Date)
        Try


            Using obj As New clsTellers()
                Dim sf As String = clsGeneral.GetStringFormat()
                ' Dim OpeningBalance As Decimal = obj.GetTellerOpeningBalance(drpTeller.SelectedValue.ToString(), Convert.ToDateTime(txtRepDate.Text))
                Dim OpeningBalance As Decimal = obj.GetTellerOpeningBalance(MachineID, Dtoday)
                lblOB.Text = String.Format(sf, OpeningBalance)
                Dim ds As DataSet = obj.GetTellerOtherBalance(MachineID, Dtoday)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim frmSafeAbaz, frmSafeMplus, MoneyGramSent, MoneyGramRcvd, Repayment, ToSafeAbaz, ToSafeMplus, Loan, intDrawdown, _
                    intDrawdownOut, ChequeCashed, ChequeCashed1, PaymentCollection, TotalCashIn, TotalCashOut, TotalCashBalance As Decimal
                    frmSafeAbaz = ds.Tables(0).Rows(0).Item("frmSafeAbaz")
                    frmSafeMplus = ds.Tables(0).Rows(0).Item("frmSafeMplus")
                    MoneyGramSent = ds.Tables(0).Rows(0).Item("MoneyGramSent")
                    MoneyGramRcvd = ds.Tables(0).Rows(0).Item("MoneyGramRcvd")
                    Repayment = ds.Tables(0).Rows(0).Item("Repayment")
                    ToSafeAbaz = ds.Tables(0).Rows(0).Item("ToSafeAbaz")
                    ToSafeMplus = ds.Tables(0).Rows(0).Item("ToSafeMplus")
                    Loan = ds.Tables(0).Rows(0).Item("Loan")
                    intDrawdown = ds.Tables(0).Rows(0).Item("intDrawdown")
                    intDrawdownOut = ds.Tables(0).Rows(0).Item("intDrawdownOut")
                    ChequeCashed = ds.Tables(0).Rows(0).Item("ChequeCashed")
                    ChequeCashed1 = ds.Tables(0).Rows(0).Item("ChequeCashed1")
                    PaymentCollection = ds.Tables(0).Rows(0).Item("PaymentCollection")
                    TotalCashIn = ds.Tables(0).Rows(0).Item("TotalCashIn")
                    TotalCashOut = ds.Tables(0).Rows(0).Item("TotalCashOut")
                    TotalCashBalance = ds.Tables(0).Rows(0).Item("TotalCashBalance")
                    lblTotalCashout.Text = String.Format(sf, TotalCashOut)
                    Dim clsngBal As Decimal = (OpeningBalance + TotalCashIn) - TotalCashOut
                    lblClosingBalance.Text = String.Format(sf, clsngBal)

                    If frmSafeAbaz <> 0 Then
                        frmSafeAbaztr.Visible = True
                        lblfrmSafeAbaz.Text = String.Format(sf, frmSafeAbaz)
                    Else
                        frmSafeAbaztr.Visible = False
                    End If

                    If frmSafeMplus <> 0 Then
                        frmSafeMplustr.Visible = True
                        lblfrmSafeMplus.Text = String.Format(sf, frmSafeMplus)
                    Else
                        frmSafeMplustr.Visible = False
                    End If

                    If Repayment <> 0 Then
                        RepaymentTr.Visible = True
                        lblRepayment.Text = String.Format(sf, Repayment)
                    Else
                        RepaymentTr.Visible = False

                    End If
                    If PaymentCollection <> 0 Then
                        PaymentCollectionTr.Visible = True
                        lblPaymentCollection.Text = String.Format(sf, PaymentCollection)
                    Else
                        PaymentCollectionTr.Visible = False
                    End If
                    lblTotalCashIn.Text = String.Format(sf, TotalCashIn)
                    If ToSafeAbaz <> 0 Then
                        ToSafeAbazTr.Visible = True
                        lblToSafeAbaz.Text = String.Format(sf, ToSafeAbaz)
                    Else
                        ToSafeAbazTr.Visible = False
                    End If

                    If ToSafeMplus <> 0 Then
                        ToSafeMplusTr.Visible = True
                        lblToSafeMplus.Text = String.Format(sf, ToSafeMplus)
                    Else
                        ToSafeMplusTr.Visible = False
                    End If
                    Dim loanlocdrdwnCashout As Decimal = Loan + intDrawdown + intDrawdownOut
                    If loanlocdrdwnCashout <> 0 Then
                        loanlocdrdwnCashoutTr.Visible = True
                        lblloanlocdrdwnCashout.Text = String.Format(sf, loanlocdrdwnCashout)
                    Else
                        loanlocdrdwnCashoutTr.Visible = False
                    End If
                    Dim chqCashInOut As Decimal = ChequeCashed + ChequeCashed1
                    If chqCashInOut <> 0 Then
                        ChequeCashedTR.Visible = True
                        lblChequeCashed.Text = String.Format(sf, chqCashInOut)
                    Else
                        ChequeCashedTR.Visible = False
                    End If
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub bindLoanRepay(ByVal MachineID As String, ByVal Dtoday As Date)
        Try
            Using obj As New clsTellers()
                Dim dsLoan As DataSet = obj.BindTellerLoanRepay(MachineID, Dtoday)
                If dsLoan.Tables(0).Rows.Count > 0 Then
                    Dim CustET As Integer = 0
                    Dim CustNT As Integer = 0
                    Dim CustFee As Decimal = 0
                    Dim CustAmount As Decimal = 0
                    gvLoanRepay.DataSource = dsLoan
                    gvLoanRepay.DataBind()
                    If gvLoanRepay.Rows.Count > 0 Then
                        gvLoanRepay.HeaderRow.TableSection = TableRowSection.TableHeader
                        gvLoanRepay.FooterRow.TableSection = TableRowSection.TableFooter
                        For Each gr As GridViewRow In gvLoanRepay.Rows
                            Dim CustID As Integer = Convert.ToInt16(CType(gr.FindControl("lblCustID"), Label).Text)
                            ' Dim lblCustNew As Label = CType(gr.FindControl("lblCustNew"), Label)
                            'Dim lblCustExist As Label = CType(gr.FindControl("lblCustExist"), Label)
                            ' Dim lblFee As Label = CType(gr.FindControl("lblFee"), Label)
                            Dim lblAmount As Label = CType(gr.FindControl("lblAmount"), Label)
                            ' CustFee = CustFee + Convert.ToDecimal(lblFee.Text.Replace("$", ""))

                            CustAmount = CustAmount + Convert.ToDecimal(lblAmount.Text.Replace("$", ""))
                            'If (obj.CheckCustomerExist(CustID, Dtoday) = True) Then
                            '    lblCustExist.Text = "E"
                            '    lblCustNew.Text = ""
                            '    CustET = CustET + 1
                            'Else
                            '    lblCustExist.Text = ""
                            '    lblCustNew.Text = "N"
                            '    CustNT = CustNT + 1
                            'End If
                        Next
                        ' CType(gvLoanRepay.FooterRow.FindControl("lblCustNewTotal"), Label).Text = CustNT
                        'CType(gvLoanRepay.FooterRow.FindControl("lblCustExistTotal"), Label).Text = CustET
                        'CType(gvLoanRepay.FooterRow.FindControl("lblFeeTotal"), Label).Text = String.Format(clsGeneral.GetStringFormat(), CustFee)
                        CType(gvLoanRepay.FooterRow.FindControl("lblAmountTotal"), Label).Text = String.Format(clsGeneral.GetStringFormat(), CustAmount)
                    End If
                Else
                    gvLoanRepay.DataSource = Nothing
                    gvLoanRepay.DataBind()

                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub binChqCashIn(ByVal MachineID As String, ByVal Dtoday As Date)
        Try
            Using obj As New clsTellers()
                Dim dsLoan As DataSet = obj.BindTellerCheqCash(MachineID, Dtoday)
                If dsLoan.Tables(0).Rows.Count > 0 Then
                    Dim CustET As Integer = 0
                    Dim CustNT As Integer = 0
                    Dim CustFee As Decimal = 0
                    Dim CustAmount As Decimal = 0
                    Dim Chqamt As Decimal = 0
                    gvChequeCash.DataSource = dsLoan
                    gvChequeCash.DataBind()
                    If gvChequeCash.Rows.Count > 0 Then
                        gvChequeCash.HeaderRow.TableSection = TableRowSection.TableHeader
                        gvChequeCash.FooterRow.TableSection = TableRowSection.TableFooter
                        For Each gr As GridViewRow In gvChequeCash.Rows
                            Dim CustID As Integer = Convert.ToInt16(CType(gr.FindControl("lblCustID"), Label).Text)
                            Dim lblCustNew As Label = CType(gr.FindControl("lblCustNew"), Label)
                            Dim lblCustExist As Label = CType(gr.FindControl("lblCustExist"), Label)
                            Dim lblFee As Label = CType(gr.FindControl("lblFee"), Label)
                            Dim lblAmount As Label = CType(gr.FindControl("lblAmount"), Label)
                            Dim _chqAmt As Label = CType(gr.FindControl("lblChqAmt"), Label)
                            CustFee = CustFee + Convert.ToDecimal(lblFee.Text.Replace("$", ""))
                            Chqamt = Chqamt + Convert.ToDecimal(_chqAmt.Text.Replace("$", ""))
                            CustAmount = CustAmount + Convert.ToDecimal(lblAmount.Text.Replace("$", ""))
                            If (obj.CheckCustomerExist(CustID, Dtoday) = True) Then
                                lblCustExist.Text = "E"
                                lblCustNew.Text = ""
                                CustET = CustET + 1
                            Else
                                lblCustExist.Text = ""
                                lblCustNew.Text = "N"
                                CustNT = CustNT + 1
                            End If
                        Next
                        CType(gvChequeCash.FooterRow.FindControl("lblCustNewTotal"), Label).Text = CustNT
                        CType(gvChequeCash.FooterRow.FindControl("lblCustExistTotal"), Label).Text = CustET
                        CType(gvChequeCash.FooterRow.FindControl("lblFeeTotal"), Label).Text = String.Format(clsGeneral.GetStringFormat(), CustFee)
                        CType(gvChequeCash.FooterRow.FindControl("lblAmountTotal"), Label).Text = String.Format(clsGeneral.GetStringFormat(), CustAmount)
                        CType(gvChequeCash.FooterRow.FindControl("lblChqTotal"), Label).Text = String.Format(clsGeneral.GetStringFormat(), Chqamt)
                    End If
                Else

                    gvChequeCash.DataSource = Nothing
                    gvChequeCash.DataBind()
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub bindLoan(ByVal MachineID As String, ByVal Dtoday As Date)
        Try
            Using obj As New clsTellers()
                Dim dsLoan As DataSet = obj.BindTellerLoan(MachineID, Dtoday)
                If dsLoan.Tables(0).Rows.Count > 0 Then
                    Dim CustET As Integer = 0
                    Dim CustNT As Integer = 0
                    Dim CustFee As Decimal = 0
                    Dim CustAmount As Decimal = 0
                    gvLoan.DataSource = dsLoan
                    gvLoan.DataBind()
                    If gvLoan.Rows.Count > 0 Then
                        gvLoan.HeaderRow.TableSection = TableRowSection.TableHeader
                        gvLoan.FooterRow.TableSection = TableRowSection.TableFooter
                        For Each gr As GridViewRow In gvLoan.Rows
                            Dim CustID As Integer = Convert.ToInt16(CType(gr.FindControl("lblCustID"), Label).Text)
                            Dim lblCustNew As Label = CType(gr.FindControl("lblCustNew"), Label)
                            Dim lblCustExist As Label = CType(gr.FindControl("lblCustExist"), Label)
                            Dim lblFee As Label = CType(gr.FindControl("lblFee"), Label)
                            Dim lblAmount As Label = CType(gr.FindControl("lblAmount"), Label)
                            CustFee = CustFee + Convert.ToDecimal(lblFee.Text.Replace("$", ""))

                            CustAmount = CustAmount + Convert.ToDecimal(lblAmount.Text.Replace("$", ""))
                            If (obj.CheckCustomerExist(CustID, Dtoday) = True) Then
                                lblCustExist.Text = "E"
                                lblCustNew.Text = ""
                                CustET = CustET + 1
                            Else
                                lblCustExist.Text = ""
                                lblCustNew.Text = "N"
                                CustNT = CustNT + 1
                            End If
                        Next
                        CType(gvLoan.FooterRow.FindControl("lblCustNewTotal"), Label).Text = CustNT
                        CType(gvLoan.FooterRow.FindControl("lblCustExistTotal"), Label).Text = CustET
                        CType(gvLoan.FooterRow.FindControl("lblFeeTotal"), Label).Text = String.Format(clsGeneral.GetStringFormat(), CustFee)
                        CType(gvLoan.FooterRow.FindControl("lblAmountTotal"), Label).Text = String.Format(clsGeneral.GetStringFormat(), CustAmount)
                    End If
                Else

                    gvLoan.DataSource = Nothing
                    gvLoan.DataBind()
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub bindLoc(ByVal MachineID As String, ByVal Dtoday As Date)
        Try
            Using obj As New clsTellers()
                Dim dsLoc As DataSet = obj.BindTellerLOC(MachineID, Dtoday)

                gvLoc.DataSource = dsLoc
                gvLoc.DataBind()
                Dim CustET As Integer = 0
                Dim CustNT As Integer = 0
                Dim CustFee As Decimal = 0
                Dim CustAmount As Decimal = 0
                If gvLoc.Rows.Count > 0 Then
                    gvLoc.HeaderRow.TableSection = TableRowSection.TableHeader
                    gvLoc.FooterRow.TableSection = TableRowSection.TableFooter
                    For Each gr As GridViewRow In gvLoc.Rows
                        Dim ri As Integer = gr.RowIndex()
                        'lblCustID lblCustNew lblCustExist lblFee lblAmount 
                        'lblCustExistTotal lblCustNewTotal lblFeeTotal lblAmountTotal
                        Dim CustID As Integer = Convert.ToInt16(CType(gr.FindControl("lblCustID"), Label).Text)
                        Dim lblCustNew As Label = CType(gr.FindControl("lblCustNew"), Label)
                        Dim lblCustExist As Label = CType(gr.FindControl("lblCustExist"), Label)
                        Dim lblFee As Label = CType(gr.FindControl("lblFee"), Label)
                        Dim lblAmount As Label = CType(gr.FindControl("lblAmount"), Label)
                        CustFee = CustFee + Convert.ToDecimal(lblFee.Text.Replace("$", ""))

                        CustAmount = CustAmount + Convert.ToDecimal(lblAmount.Text.Replace("$", ""))
                        If (obj.CheckCustomerExist(CustID, Dtoday) = True) Then
                            lblCustExist.Text = "E"
                            lblCustNew.Text = ""
                            CustET = CustET + 1
                        Else
                            lblCustExist.Text = ""
                            lblCustNew.Text = "N"
                            CustNT = CustNT + 1
                        End If

                    Next
                    CType(gvLoc.FooterRow.FindControl("lblCustNewTotal"), Label).Text = CustNT
                    CType(gvLoc.FooterRow.FindControl("lblCustExistTotal"), Label).Text = CustET
                    CType(gvLoc.FooterRow.FindControl("lblFeeTotal"), Label).Text = String.Format(clsGeneral.GetStringFormat(), CustFee)
                    CType(gvLoc.FooterRow.FindControl("lblAmountTotal"), Label).Text = String.Format(clsGeneral.GetStringFormat(), CustAmount)
                Else
                    gvLoc.DataSource = Nothing
                    gvLoc.DataBind()
                End If


            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindTillCounter()
        Try
            Dim gr As GridViewRow
            Dim total As Decimal = 0
            For Each gr In gvTillCount.Rows
                'lblAmtVal lblValue
                Dim _txtValue As TextBox = CType(gr.FindControl("txtValue"), TextBox)
                Dim lblAmtval As Decimal = CType(gr.FindControl("lblAmtVal"), HiddenField).Value
                Dim _lblValue As Label = CType(gr.FindControl("lblValue"), Label)
                If _txtValue.Text = "" Then
                    _txtValue.Text = 0
                End If
                Dim val As Decimal = Convert.ToDecimal(_txtValue.Text) * Convert.ToDecimal(lblAmtval)
                _lblValue.Text = String.Format(clsGeneral.GetStringFormat(), val)
                total = total + val
            Next
            lblTillTotal.Text = String.Format(clsGeneral.GetStringFormat(), total)
            Dim cb As Decimal = Convert.ToDecimal(lblClosingBalance.Text.Replace("$", ""))
            Dim bal As Decimal = 0
            If cb > total Then
                bal = total - cb
            ElseIf cb < total Then
                bal = total - cb
            Else
                bal = 0.0
            End If

            lblBalance.Text = String.Format(clsGeneral.GetStringFormat(),bal)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub gvLoc_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLoc.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

        End If
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            BindTillCounter()
            Session("ctrl") = pnlPrint

            '  Session("ctrl") = PrintDiv
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        Try
            BindTillCounter()
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment;filename=" & "Teller_Report_" & txtRepDate.Text.ToString() & ".xls")
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
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub

    Protected Sub gvChequeCash_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvChequeCash.SelectedIndexChanged

    End Sub
End Class
