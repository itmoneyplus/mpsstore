
Partial Class WebUserControl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LinkButton8.Attributes.Add("onClick", "javascript:history.back(); return false;")
    End Sub

    Protected Sub Link_Reports_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link_Reports.Click

    End Sub

    Protected Sub Link_Customer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link_Customer.Click

    End Sub

    Protected Sub LinkButton8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton8.Click

    End Sub
End Class
