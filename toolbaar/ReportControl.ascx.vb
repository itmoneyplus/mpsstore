
Partial Class toolbaar_ReportControl
    Inherits System.Web.UI.UserControl

    Protected Sub Link_Periodic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link_Periodic.Click
        Toolbaar_Rep1.Visible = False
        Toolbaar_Rep2.Visible = True
    End Sub

    Protected Sub Link_Financial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link_Financial.Click
        ' Toolbaar_Rep1.Visible = True
        'Toolbaar_Rep2.Visible = False
        viewFinance()
    End Sub
    Private Sub viewFinance()
        Toolbaar_Rep1.Visible = True
        Toolbaar_Rep2.Visible = False
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Me.IsPostBack = False) Then
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

            Dim pagename = url.Substring(url.LastIndexOf("/") + 1)
            If pagename = "Tellers_Report.aspx" Then
                viewFinance()

            End If
        End If
    End Sub
End Class
