Imports System.Data
Partial Class Customer_Payment_Collection
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim Pid As Integer = 0
            Using obj As New clsPmtCol()
                'Pid = obj.AddPaymentCollection(Convert.ToInt16(txtCustomerID.Text), txtCustomerName.Text, drpBranch.SelectedItem.Text, Decimal.Parse(txtInterAmount.Text), drpPurpose.SelectedValue, Session("user_id"), clsGeneral.GetIP4Address())
                Pid = obj.AddPaymentCollection(Convert.ToInt16(txtCustomerID.Text), txtCustomerName.Text, drpBranch.SelectedItem.Text, Decimal.Parse(txtInterAmount.Text), drpPurpose.SelectedValue, Session("user_id"), ddlTeller.SelectedItem.Text)
                If Pid <> 0 Or Convert.ToString(Pid) <> "" Then
                    'tblentry.Visible = False
                    tblPrint.Visible = True
                    BindBranchDeatail()
                    bindDtl(Pid)
                    btnPrint.Visible = True
                    btnBack.Visible = True

                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub BindBranchDeatail()
        Try
            Using obj As New clsBranch()
                Dim dsBranch As DataSet = obj.GetBranchByID(Integer.Parse(Session("branch_id")))
                If dsBranch.Tables(0).Rows.Count > 0 Then
                    Dim dr As DataRow = dsBranch.Tables(0).Rows(0)
                    lblTradingName.Text = Convert.ToString(dr("Trading_Name"))
                    lblStreetNo.Text = Convert.ToString(dr("Street_Number"))
                    lblStreetName.Text = Convert.ToString(dr("Street_Name"))
                    lblSuburb.Text = Convert.ToString(dr("Suburb"))
                    lblState.Text = Convert.ToString(dr("State"))
                    lblPostCode.Text = Convert.ToString(dr("Post_Code"))
                    lblPhoneNo.Text = Convert.ToString(dr("Phone_Number"))
                End If

            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub bindDtl(ByVal PaymentID As Integer)
        Try
            Using obj As New clsPmtCol()
                Dim ds As DataSet = obj.GetPmtCollectionDetails(PaymentID)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim dr As DataRow
                    dr = ds.Tables(0).Rows(0)
                    lblCustNo.Text = Convert.ToString(dr("Customer_ID"))
                    lblCustName.Text = Convert.ToString(dr("Customer_Name"))
                    lblBranchName.Text = Convert.ToString(dr("Branch_Name"))
                    lblPurpose.Text = Convert.ToString(dr("Payment_Purpose"))
                    lblAmount.Text = String.Format(clsGeneral.GetStringFormat(), Convert.ToDecimal(dr("Amount")))
                    lblDate.Text = String.Format(clsGeneral.GetDateFormat(), Convert.ToDateTime(dr("Time_Collect")))
                End If
            End Using
        Catch ex As Exception

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
                tblPrint.Visible = False
                btnPrint.Visible = False
                bindBranch()
                btnBack.Visible = False
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

    Private Sub bindBranch()
        Try
            Using obj As New clsBranch()
                clsGeneral.BindDropDown(drpBranch, obj.GetAllBranch(), "Branch_ID", "Trading_Name", True, "Branch")
            End Using


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Session("ctrl") = pnlprnt
        ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('../Reports/Print.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        clearAll()
        btnPrint.Visible = False
        'tblentry.Visible = True
        tblPrint.Visible = False
    End Sub
    Private Sub clearAll()
        txtCustomerID.Text = ""
        txtCustomerName.Text = ""
        txtInterAmount.Text = ""
        drpBranch.SelectedValue = ""
        drpPurpose.SelectedValue = ""
    End Sub
End Class
