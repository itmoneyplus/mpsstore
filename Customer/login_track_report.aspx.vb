Imports System.Data
Partial Class Customer_login_track_report
    Inherits System.Web.UI.Page

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        bindReport()
        panel2.Visible = True
    End Sub

    Private Sub bindReport()
        Try
            Using obj As New clsUser()
                Dim ds As DataSet
                ds = obj.GetLoginTrackReport(DateTime.Parse(txtfrom_periodic.Text), DateTime.Parse(txtto_perodic.Text), drpLoginStatus.SelectedItem.Value)
                If ds.Tables(0).Rows.Count > 0 Then
                    gvReport.DataSource = ds
                    gvReport.DataBind()
                    gvReport.Visible = True
                Else
                    gvReport.DataSource = Nothing
                    gvReport.DataBind()
                End If

            End Using

        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & ex.Message & "');", True)
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
                txtto_perodic.Text = String.Format("{0:dd-MMM-yyyy}", DateAndTime.Now.Date)
                txtfrom_periodic.Text = String.Format("{0:dd-MMM-yyyy}", DateAndTime.Now.Date.AddDays(0))
                bindReport()
                panel2.Visible = False
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
End Class
