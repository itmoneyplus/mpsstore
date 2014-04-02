Imports System.Data
Imports System.Data.Sql
Partial Class test_grid
    Inherits System.Web.UI.Page
    Dim LoanID As Integer = 1280
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            '  bind()
            bindPayment(LoanID, clsGeneral.LoanPaidUnpiadAll.Unpaid)
            Session("user_id") = "1"
        End If
    End Sub
    Sub bind()
        Dim dt As New DataTable()
        dt.Columns.Add("Name", GetType(String))

        Dim dr As DataRow
        dr = dt.NewRow()
        dr(0) = "A"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "C"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "B"
        dt.Rows.InsertAt(dr, 1)
        gvPayment.DataSource = dt
        gvPayment.DataBind()
    End Sub
    Sub bindPayment(ByVal LoanID As Integer, ByVal PaidOrAll As Integer)

        Using obj As New clsLoan()
            hdRowIndex.value = 0
            Dim ds As DataSet = obj.GetAllPayments(LoanID, PaidOrAll)
            BindGridPayment(ds.Tables(0), gvPayment)
        End Using

    End Sub
    Sub BindGridPayment(ByVal dt As DataTable, ByVal gv As GridView)
        If dt.Rows.Count > 0 Then
            ViewState("dt") = dt
            gv.DataSource = dt
            gv.DataBind()
        Else
            gv.DataSource = Nothing
            gv.DataBind()
        End If


    End Sub

    Protected Sub gvPayment_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPayment.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            '  Dim _lblRowNo As Label = CType(e.Row.FindControl("lblRowNo"), Label)
            Dim _lbMode As Label = CType(e.Row.FindControl("lblMode"), Label)
            Dim _chkSelect As CheckBox = CType(e.Row.FindControl("chkSelect"), CheckBox)
            Dim _txtDueDate As TextBox = CType(e.Row.FindControl("txtDueDate"), TextBox)
            Dim _lblTransDesc As Label = CType(e.Row.FindControl("lblTransDesc"), Label)
            Dim _rbDishonoure As RadioButton = CType(e.Row.FindControl("rbDishonoure"), RadioButton)
            Dim _lblPaymentSatus As Label = CType(e.Row.FindControl("lblPaymentSatus"), Label)
            Dim _lblPaid As Label = CType(e.Row.FindControl("lblPaid"), Label)
            Dim tdate As DateTime = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "tdate"))
            Dim _lblmode As Label = CType(e.Row.FindControl("lblmode"), Label)
            Dim _paymentMethod As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Payment_Method"))
            If ((_paymentMethod = "Sal" Or _paymentMethod = "NAB" Or _paymentMethod = "CBA" Or _paymentMethod = "Cre") And (_lblTransDesc.Text <> "Dishonour")) Then
                If (DateTime.Parse(_txtDueDate.Text) < tdate And _lblPaymentSatus.Text = "Paid") Then
                    _rbDishonoure.Visible = True
                    _lblTransDesc.Visible = False
                Else
                    _rbDishonoure.Visible = False
                    _lblTransDesc.Visible = True
                End If
            End If
            If (_lblTransDesc.Text = "Dishonour" Or _lblPaymentSatus.Text = "Paid") Then
                _chkSelect.Visible = False

            End If
            If (_lblPaymentSatus.Text = "Paid") Then
                _lblPaid.Visible = True
            Else
                _lblPaid.Visible = False
            End If
            If (_lblmode.Text = "addorg" Or _lblmode.Text = "addnew") Then
                _chkSelect.Checked = True

            End If
            If (_lblmode.Text = "addnew") Then
                'lblPaymentMethid  drpPaymentMethod
                Dim _drpPaymentMethod As DropDownList = CType(e.Row.FindControl("drpPaymentMethod"), DropDownList)
                Dim _lblPaymentMethid As Label = CType(e.Row.FindControl("lblPaymentMethid"), Label)
                _lblPaymentMethid.Visible = False
                _drpPaymentMethod.SelectedIndex = _drpPaymentMethod.Items.IndexOf(CType(_drpPaymentMethod.Items.FindByText(_lblPaymentMethid.Text), ListItem))
                _drpPaymentMethod.Visible = True
                _txtDueDate.Attributes.Add("style", "background-color:Red;color:#fff;")
                _txtDueDate.Text = ""
            End If

            ' hdRowIndex.value = CInt(hdRowIndex.value) + 1
            ' _lblRowNo.Text = CInt(hdRowIndex.value)

        End If
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        hdRowIndex.value = 0
        btnHide.Visible = True
        btnShow.Visible = False
        bindPayment(LoanID, clsGeneral.LoanPaidUnpiadAll.all)
       

    End Sub

    Protected Sub btnHide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHide.Click
        hdRowIndex.value = 0
        btnHide.Visible = False
        btnShow.Visible = True
        bindPayment(LoanID, clsGeneral.LoanPaidUnpiadAll.Unpaid)

    End Sub
    Public Function chkBtnHideVisible() As Boolean

    End Function
    Protected Sub btnAccept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        Try
            If btnHide.Visible = True Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please hide the paid payment to proceed!!!" & "');", True)
                Exit Sub
            End If
            Dim amt As Decimal = Convert.ToDecimal(txtAmount.Text)
            Dim dr As GridViewRow
            For Each dr In gvPayment.Rows
                Dim _chkSelect As CheckBox = CType(dr.FindControl("chkSelect"), CheckBox)
                Dim _txtAmount As TextBox = CType(dr.FindControl("txtAmount"), TextBox)
                Dim _lblPaymentMethid As Label = CType(dr.FindControl("lblPaymentMethid"), Label)
                Dim _lblCustID As Label = CType(dr.FindControl("lblCustID"), Label)
                Dim _lblDesc As Label = CType(dr.FindControl("lblDesc"), Label)
                Dim ri As Integer = dr.RowIndex()
                Dim orgAmt As Decimal = Decimal.Parse(_txtAmount.Text)
                If _chkSelect.Checked = True Then
                    If _lblPaymentMethid.Text <> "Cas" Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please change the payment method to Cheque or Cash!!!" & "');", True)
                        Exit Sub
                    End If
                    If _lblPaymentMethid.Text = "Chq" Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please change the payment method to Cheque or Cash!!!" & "');", True)
                        Exit Sub
                    End If
                    If amt = orgAmt Then

                        pnlAbove.Visible = False
                        pnlBelow.Visible = True
                        btnAccepotOk.Visible = True
                        btnAccepotCancel.Visible = True
                    ElseIf amt > orgAmt Then
                        'return
                        Dim retrunAmt As Decimal = amt - orgAmt
                        lblRetrun.Visible = True
                        lblReturnAmtValue.Visible = True
                        lblReturnAmtValue.Text = String.Format(clsGeneral.GetStringFormat(), retrunAmt)
                        pnlAbove.Visible = False
                        pnlBelow.Visible = True
                        btnAccepotOk.Visible = True
                        btnAccepotCancel.Visible = True
                        Exit Sub
                    ElseIf amt < orgAmt Then
                        'new payment schdule
                        Dim diffAmt As Decimal = orgAmt - amt
                        pnlAbove.Visible = False
                        pnlBelow.Visible = True
                        btnAccepotOk.Visible = True
                        btnAccepotCancel.Visible = True
                        Dim dt As DataTable = ViewState("dt")
                        Dim newdr = dt.NewRow()
                        newdr("Payment_ID") = "0"
                        newdr("Customer_ID") = _lblCustID.Text
                        If (Convert.ToString(_lblDesc.Text) = "") Then
                            newdr("Description") = DBNull.Value
                        Else
                            newdr("Description") = Convert.ToString(_lblDesc.Text)
                        End If

                        newdr("Amount") = diffAmt
                        newdr("Due_Date") = DBNull.Value
                        newdr("Payment_Status") = DBNull.Value
                        newdr("Payment_Date") = DBNull.Value
                        newdr("Payment_Method") = _lblPaymentMethid.Text
                        newdr("Transaction_Status") = DBNull.Value
                        newdr("Transaction_Date") = DBNull.Value
                        newdr("Transaction_Time") = DBNull.Value
                        newdr("tdate") = System.DateTime.Now
                        newdr("mode") = "addnew"
                        dt.Rows(ri)("mode") = "addorg"
                        dt.Rows(ri)("Amount") = txtAmount.Text
                        dt.Rows.InsertAt(newdr, ri + 1)
                        gvPayment.DataSource = dt
                        gvPayment.DataBind()
                        ViewState("dt") = dt

                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function getrow(ByVal Payment_ID As String, ByVal Customer_ID As String, ByVal Description As Object, ByVal diffAmt As Decimal, ByVal Due_Date As Object, ByVal Payment_Status As Object, ByVal Payment_Date As Object, ByVal Payment_Method As String, ByVal Transaction_Status As Object, ByVal Transaction_Date As Object, ByVal Transaction_Time As Object, ByVal mode As String, ByVal tdate As DateTime) As DataRow
        Dim newdr As DataRow
        newdr("Payment_ID") = Payment_ID
        newdr("Customer_ID") = Customer_ID
        newdr("Description") = Description
        newdr("Amount") = diffAmt
        newdr("Due_Date") = Due_Date
        newdr("Payment_Status") = Payment_Status
        newdr("Payment_Date") = Payment_Date
        newdr("Payment_Method") = Payment_Method
        newdr("Transaction_Status") = Transaction_Status
        newdr("Transaction_Date") = Transaction_Date
        newdr("Transaction_Time") = Transaction_Time
        newdr("mode") = mode
        newdr("tdate") = tdate
        Return newdr
    End Function

    Protected Sub btnAccepotCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccepotCancel.Click
        pnlAbove.Visible = True
        pnlBelow.Visible = False
        btnAccepotCancel.Visible = False
        btnAccepotOk.Visible = False
        bindPayment(LoanID, clsGeneral.LoanPaidUnpiadAll.Unpaid)
        lblRetrun.Visible = False
        lblReturnAmtValue.Visible = False
        lblReturnAmtValue.Text = ""
        txtAmount.Text = ""
    End Sub

    Protected Sub btnModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.Click
        If btnHide.Visible = True Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please hide the paid payment to proceed!!!" & "');", True)
            Exit Sub
        End If
        Dim dr As GridViewRow
        Dim dis_bool As Boolean = False
        For Each dr In gvPayment.Rows
            Dim _chkSelect As CheckBox = CType(dr.FindControl("chkSelect"), CheckBox)
            Dim _txtAmount As TextBox = CType(dr.FindControl("txtAmount"), TextBox)
            Dim _txtDueDate As TextBox = CType(dr.FindControl("txtDueDate"), TextBox)
            Dim _lblPaymentMethid As Label = CType(dr.FindControl("lblPaymentMethid"), Label)
            Dim _drpPaymentMethod As DropDownList = CType(dr.FindControl("drpPaymentMethod"), DropDownList)
            If _chkSelect.Checked = True Then
                _drpPaymentMethod.Visible = True
                _lblPaymentMethid.Visible = False
                _txtAmount.ReadOnly = False
                _txtDueDate.ReadOnly = False
                _drpPaymentMethod.SelectedIndex = _drpPaymentMethod.Items.IndexOf(CType(_drpPaymentMethod.Items.FindByText(_lblPaymentMethid.Text), ListItem))
                dis_bool = True
            End If
        Next
        If dis_bool = True Then
            btnModifyOK.Visible = True
            btnModifyCancel.Visible = True
            pnlAbove.Visible = False
            pnlBelow.Visible = True
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please select atleast one payment to modify!!!" & "');", True)
        End If
    End Sub

    Protected Sub btnModifyOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModifyOK.Click
       
    End Sub

    Protected Sub btnModifyCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModifyCancel.Click
        pnlAbove.Visible = True
        pnlBelow.Visible = False
        btnModifyCancel.Visible = False
        btnModifyOK.Visible = False
        bindPayment(LoanID, clsGeneral.LoanPaidUnpiadAll.Unpaid)
        lblRetrun.Visible = False
        lblReturnAmtValue.Visible = False
        lblReturnAmtValue.Text = ""
        txtAmount.Text = ""
    End Sub

  
    Protected Sub btnAccepotOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccepotOk.Click
        Try
            Dim dr As GridViewRow
            For Each dr In gvPayment.Rows
                Dim _txtDueDate1 As TextBox = CType(dr.FindControl("txtDueDate"), TextBox)
                _txtDueDate1.ReadOnly = False
                Dim _chkSelect As CheckBox = CType(dr.FindControl("chkSelect"), CheckBox)
                '  Dim _txtDueDate As TextBox = CType(dr.FindControl("txtDueDate"), TextBox)
                If _chkSelect.Checked = True And _txtDueDate1.Text = "" Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Please  enter a valid due date for outstanding payment!!!" & "');", True)
                    Exit Sub
                End If
            Next
            For Each dr In gvPayment.Rows
                Dim _chkSelect As CheckBox = CType(dr.FindControl("chkSelect"), CheckBox)
                Dim _txtDueDate As TextBox = CType(dr.FindControl("txtDueDate"), TextBox)
                _txtDueDate.ReadOnly = False
                Dim _lblPaymentID As Label = CType(dr.FindControl("lblPaymentID"), Label)
                Dim _txtAmount As TextBox = CType(dr.FindControl("txtAmount"), TextBox)
                Dim _lbMode As Label = CType(dr.FindControl("lblMode"), Label)
                If _chkSelect.Checked = True And _txtDueDate.Text <> "" Then
                    If _lblPaymentID.Text <> 0 And _lbMode.Text = "addorg" Then
                        'update
                        Using obj As New clsLoanRepay()
                            obj.UpdateExistingPayment(CInt(_lblPaymentID.Text), CDec(_txtAmount.Text), clsGeneral.GetSession("user_id"), clsGeneral.GetIPAddress())
                        End Using
                    ElseIf _lblPaymentID.Text = 0 And _lbMode.Text = "addnew" Then
                        'insert

                    End If
                End If
            Next
            bindPayment(LoanID, clsGeneral.LoanPaidUnpiadAll.Unpaid)
            pnlAbove.Visible = True
            pnlBelow.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
