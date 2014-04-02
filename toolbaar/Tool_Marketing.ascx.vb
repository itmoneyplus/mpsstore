
Partial Class toolbaar_Tool_Marketing
    Inherits System.Web.UI.UserControl

    Protected Sub Link_Marketing_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link_Marketing.Click
        Toolbaar_mar.Visible = True
        Toolbaar_sta.Visible = False
    End Sub

    Protected Sub Link_Statistics_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link_Statistics.Click
        Toolbaar_mar.Visible = False
        Toolbaar_sta.Visible = True
    End Sub
End Class
