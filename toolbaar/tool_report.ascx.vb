
Partial Class toolbaar_tool_report
    Inherits System.Web.UI.UserControl

    Protected Sub Link_Financial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link_Financial.Click
        Session("rep") = "fin"
        trfin.Visible = True
        trPer.Visible = False
        'chkAdmin()

    End Sub

    Protected Sub Link_Periodic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link_Periodic.Click
        Session("rep") = "per"
        trPer.Visible = True
        trfin.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If clsGeneral.GetSession("rep") = "" Then
            trPer.Visible = False
            trfin.Visible = False
        ElseIf clsGeneral.GetSession("rep") = "per" Then
            trPer.Visible = True
            trfin.Visible = False
        ElseIf clsGeneral.GetSession("rep") = "fin" Then
            trfin.Visible = True
            trPer.Visible = False
            'chkAdmin()
        Else
            trPer.Visible = False
            trfin.Visible = False
        End If


    End Sub
    Sub chkAdmin()
        If Session("user_type") = "Admin" Then
            trreportAdmin.Visible = True
        Else
            trreportAdmin.Visible = False
        End If
    End Sub
End Class
