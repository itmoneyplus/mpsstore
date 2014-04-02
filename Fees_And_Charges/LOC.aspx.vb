Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports System.Globalization
Imports System.Net
Imports System.IO
Partial Class LOC
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("RefUrl") = Request.UrlReferrer.ToString()
        End If
        'LinkButton_back.Attributes.Add("onClick", "javascript:history.back(); return false;")
        chkAdmin()
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            If Page.IsPostBack = False Then
                View_Data()
            End If
        End If

    End Sub
    Sub View_Data()
        Using obj As New clsReport()
            Dim ds As DataSet = obj.getLOC()

            If ds.Tables(0).Rows.Count > 0 Then
                grd.DataSource = ds
                grd.DataBind()
                pnl.Visible = True
            Else
                pnl.Visible = False
            End If
        End Using

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
