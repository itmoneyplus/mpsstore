Imports System.Data
Imports System.Globalization
Imports System.Net
Imports System.IO
Imports MPCommon.EmailClient


Partial Class test_test
    Inherits System.Web.UI.Page
    Dim objClass As New Class1

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Dim a As New test()
        ' Dim ds As DataSet = a.t()
        '  Dim a As Decimal = Decimal.Parse("$40.40", Globalization.NumberStyles.AllowCurrencySymbol)
        'Dim value As String
        'Dim styles As NumberStyles
        'value = " $ 6,164.3299  "
        'styles = NumberStyles.Number Or NumberStyles.AllowCurrencySymbol
        'ShowNumericValue(value, styles)
        ' Dim h As String = clsGeneral.GetMailHeader()
        'Dim f As String = clsGeneral.GetMailFooter()

        ' Dim client As New WebClient
        ' Dim data As Stream = client.OpenRead("http://localhost/backOffice/test/email.htm")
        ' Dim str As String = Context.Request.Url.GetLeftPart(UriPartial.Authority)
        ' Dim data As Stream = client.OpenRead(Server.MapPath("~/email/") & "loan_preapproval.aspx?")
        '  Dim reader As New StreamReader(data)
        '  Dim str As String = reader.ReadToEnd()
        '  Session("ctrl") = Panel1
        ' lblPnl.Text = str
        '  Session("ctrl") = PrintDiv
        ' ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('../Reports/Print.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>")
        '   Dim str As String = "umesh k Bharvad   "
        '  str = str.Trim().Replace(" ", "")
        ' clsGeneral.SendMail("loans@moneyplus.com.au", "mail from umesh", str)
        'Response.Write("send")
        '   InStr("", "", CompareMethod.Text)
        '  Dim ip As String = GetIPAddress()

        '  Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Your Ip:" & ip & "');", True)
        '  binddrp()
        Dim a As Boolean = objClass.check_status(1283)
        If a = True Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & " True " & "');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & " false " & "');", True)
        End If

    End Sub
    Sub binddrp()
        Dim drop1_cancel_dis As DropDownList = New DropDownList
        drop1_cancel_dis.ID = "paymethod_cancel_dis" & 1
        drop1_cancel_dis.Width = "90"
        drop1_cancel_dis.Style.Add("font-size", "12px")
        drop1_cancel_dis.Style.Add("font-family", "MS Sans Serif")
        drop1_cancel_dis.Style.Add("font-weight", "bold")
        drop1_cancel_dis.Style.Add("text-align", "center")
        drop1_cancel_dis.Items.Add("NAB")
        drop1_cancel_dis.Items.Add("Cas")
        drop1_cancel_dis.Items.Add("Sal")
        drop1_cancel_dis.Items.Add("Chq")
        drop1_cancel_dis.Items.Add("CBA")
        drop1_cancel_dis.Items.Add("Cre")
        drop1_cancel_dis.Items.Add("Def")
        drop1_cancel_dis.Items.Add("HOD")
        drop1_cancel_dis.Items.Add("WOF")
        '  drop1_cancel_dis.SelectedItem.Text = "Sal"
        ' drop1_cancel_dis.Items.IndexOf(drop1_cancel_dis.Items.FindByText("Sal"))
        drop1_cancel_dis.Items.FindByText("Sal").Selected = True
        '  drop1_cancel_dis.SelectedItem.Value = "Sal"
        'Panel1.Controls.Add(drop1_cancel_dis)
        PlaceHolder1.Controls.Add(drop1_cancel_dis)
    End Sub
    Public Shared Function GetIPAddress() As String
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current()
        Dim sIPAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(sIPAddress) Then
            Return context.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = sIPAddress.Split(New [Char]() {","c})
            Return ipArray(0)
        End If
    End Function
    Private Sub ShowNumericValue(ByVal value As String, ByVal styles As NumberStyles)
        Dim number As Double
        Try
            number = Double.Parse(value, styles)
        Catch e As FormatException

        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Dim ds As DataTable
        'Dim dr As DataRow

        ' ds.Rows.InsertAt(dr, 0)
    End Sub
End Class
