Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Net
Imports System.Net.Mail
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls
Imports System.Globalization


''' <summary>
''' Summary description for clsGeneral
''' created by Umesh Bharvad - bharvad.umesh@gmail.com
''' </summary>
Public Class clsGeneral
    Public Shared info As [String] = "notification information"
    Public Shared succes As [String] = "notification success"
    Public Shared [error] As [String] = "notification error"
    Private Shared Function CheckCookie(ByVal cname As String) As Boolean
        Try
            If HttpContext.Current.Request.Cookies(cname) Is Nothing Then
                Return False
            Else
                Return True
            End If
        Catch generatedExceptionName As Exception
            Throw
        End Try
    End Function
    Enum LoanPaidUnpiadAll
        all = 0
        Unpaid = 1
        paidOnly = 2
    End Enum
    Public Shared Function GetStringFormat() As String
        Return "{0:c}"
    End Function
    Public Shared Function GetTimeFormat() As String
        Return "{0:t}"
    End Function
    Public Shared Function GetDateFormat() As String
        Return "{0:dd-MMM-yyyy}"
    End Function
    Public Shared Function GetDateFormat(ByVal seprator As String) As String
        Return "{0:dd" & seprator & "MM" & seprator & "yyyy}"
    End Function
    Public Shared Function getDecimalFormat() As String
        Return "{0:0,0.00}"
    End Function
    Public Shared Function getPercFormat() As String
        Return "{0:0.## %}"
    End Function

    Public Shared Function RemoveStringFormat(ByVal value As String) As Decimal
        Try
            Dim Number As Decimal
            Dim styles As NumberStyles
            styles = NumberStyles.Number Or NumberStyles.AllowCurrencySymbol
            Number = Double.Parse(value, styles)
            Return Number
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Shared Function GetCookie(ByVal cname As String) As String
        Try

            If HttpContext.Current.Request.Cookies(cname) Is Nothing OrElse HttpContext.Current.Request.Cookies(cname).Value Is Nothing Then
                Return ""
            End If

            Return HttpContext.Current.Request.Cookies(cname).Value
        Catch generatedExceptionName As Exception
            Throw
        End Try
    End Function
    Public Shared Function GetSession(ByVal sname As String) As String
        Try
            If HttpContext.Current.Session(sname) Is Nothing Then
                Return ""

            End If
            Return HttpContext.Current.Session(sname)
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Sub ExpireCookie(ByVal cname As String)
        Try

            If CheckCookie(cname) Then

                Dim myCookie As New HttpCookie(cname)
                myCookie.Expires = DateTime.Now.AddDays(-1.0)

                HttpContext.Current.Response.Cookies.Add(myCookie)
            End If
        Catch generatedExceptionName As Exception
            Throw
        End Try
    End Sub
    Public Shared Sub SetCookie(ByVal cname As String, ByVal value As String)
        Try
            If CheckCookie(cname) Then
                HttpContext.Current.Response.Cookies(cname).Value = value
            Else
                HttpContext.Current.Response.Cookies.Add(New HttpCookie(cname, value))
            End If
        Catch generatedExceptionName As Exception
            Throw
        End Try
    End Sub
    Public Shared Function GetQueryString(ByVal qkey As String) As String
        Try
            Dim qvalue = HttpContext.Current.Request.QueryString(qkey)
            If qvalue Is Nothing Then
                Return ""
            Else
                Return qvalue
            End If
        Catch generatedExceptionName As Exception
            Throw
        End Try
    End Function

    Public Shared Function ChkAdmin() As Boolean
        Dim isAdmin As Boolean = False
        Try
            Dim UserType As String = GetSession("user_type")
            If UserType <> "" Then
                If UserType = "Admin" Then
                    isAdmin = True
                End If
            End If
            Return isAdmin
        Catch generatedExceptionName As Exception

            Throw
        End Try
    End Function
    Public Shared Sub BindDropDown(ByVal drp As DropDownList, ByVal ds As DataSet, ByVal ValueField As String, ByVal TextField As String, ByVal WithSelect As [Boolean], ByVal customString As String)
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                drp.DataSource = ds.Tables(0)
                drp.DataTextField = TextField
                drp.DataValueField = ValueField
                drp.DataBind()
            Else
                drp.DataSource = Nothing
                drp.DataBind()
            End If
            If WithSelect Then
                Dim li As New ListItem()
                li.Text = "Please Select" & "  " & Convert.ToString(customString)
                li.Value = ""
                drp.Items.Insert(0, li)

            End If
        Catch generatedExceptionName As Exception

            Throw
        End Try
    End Sub
    Public Shared Function GetIP4Address() As String
        Dim sys_ip As String = ""
        Dim ASCII As New System.Text.ASCIIEncoding()
        Dim heserver As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        Dim curAdd As IPAddress
        For Each curAdd In heserver.AddressList
            If curAdd.AddressFamily.ToString() = "InterNetwork" Then
                sys_ip = curAdd.ToString()

            End If

        Next curAdd
        Return sys_ip
    End Function

    Public Shared Sub BindDropDown(ByVal drp As DropDownList, ByVal ds As DataSet, ByVal ValueField As String, ByVal TextField As String, ByVal WithSelect As [Boolean], ByVal withSelecAll As [Boolean])
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                drp.DataSource = ds.Tables(0)
                drp.DataTextField = TextField
                drp.DataValueField = ValueField
                drp.DataBind()
            Else
                drp.DataSource = Nothing
                drp.DataBind()
            End If
            If WithSelect Then
                Dim li As New ListItem()
                li.Text = "Please Select"
                li.Value = ""
                drp.Items.Insert(0, li)
            End If
            If withSelecAll Then
                Dim li As New ListItem()
                li.Text = "All"
                li.Value = "0"
                drp.Items.Insert(1, li)

            End If
        Catch ex As Exception

            Throw ex
        End Try
    End Sub

    Public Shared Function GetMailHeader() As String
        Try
            Dim theMessage As String = ""

            theMessage = theMessage & "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0  "
            theMessage = theMessage & "Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>"
            theMessage = theMessage & "<html xmlns='http://www.w3.org/1999/xhtml'>"
            theMessage = theMessage & "<head>"
            theMessage = theMessage & "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />"
            theMessage = theMessage & "<style type='text/css'>"
            theMessage = theMessage & "body {background-color:#ffffff; color:#000000; padding-left:10px;}"
            theMessage = theMessage & " * {margin:0px; padding:0px;}"
            theMessage = theMessage & " .footer {background-color:#e0edc9;border-bottom:solid 1px #e0edc9;border-left:solid 9px #cbdbb0;border-right:solid 9px #cbdbb0;border-top:solid 1px #e0edc9;height:38px;line-height:38px;text-align:center;color:#3b3b3b;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:12px;}"
            theMessage = theMessage & ".heading { background-color:#94bc16; color:#000; font-family:Verdana, Arial, Helvetica, sans-serif; font-size:15px; font-style:normal; font-variant:normal; font-weight:bold; padding-left:5px; padding-right:5px; padding-bottom:5px; padding-top:5px;text-align:left; vertical-align:middle;}"
            theMessage = theMessage & ".padding { padding-left:5px; padding-right:5px;}"

            theMessage = theMessage & ".free {font-family:Verdana, Arial, Helvetica, sans-serif; font-size:50px; font-style:normal; font-weight:bold; color:#c71d28; padding-left:5px; padding-right:5px; text-decoration:none; valign:middle; text-align:center;}"
            theMessage = theMessage & ".voucher {font-family:Verdana, Arial, Helvetica, sans-serif; font-size:30px; font-style:normal; font-weight:bold; color:#666666; padding-left:5px; padding-right:5px; text-decoration:none; valign:middle; text-align:center;}"
            theMessage = theMessage & ".voucher span {display:block; padding:7px; border:solid 2px #e7efce; }"
            theMessage = theMessage & ".name {font-family:Verdana, Arial, Helvetica, sans-serif; font-size:12px; font-style:normal; font-weight:bold; color:#666666; padding-left:5px; padding-right:5px; text-decoration:none; valign:middle; text-align:left;}"
            theMessage = theMessage & ".name a{font-family:Verdana, Arial, Helvetica, sans-serif; font-size:12px; font-style:normal; font-weight:bold; color:#666666; text-decoration:none; valign:middle; text-align:left;}"
            theMessage = theMessage & ".name a:hover{font-family:Verdana, Arial, Helvetica, sans-serif; font-size:12px; font-style:normal; font-weight:bold; color:#666666; text-decoration:none; valign:middle;text-align:left; }"
            theMessage = theMessage & ".namenormal {font-family:Verdana, Arial, Helvetica, sans-serif; font-size:12px; font-style:normal; font-weight:normal; color:#666666; line-height:20px; padding-left:5px; padding-right:5px; valign:middle; text-align:left;}"
            theMessage = theMessage & ".namenormal a{font-family:Verdana, Arial, Helvetica, sans-serif; font-size:12px; font-style:normal; font-weight:normal; color:#666666; text-decoration:none; valign:middle; text-align:left;}"
            theMessage = theMessage & ".namenormal a:hover{font-family:Verdana, Arial, Helvetica, sans-serif; font-size:12px; font-style:normal; font-weight:normal; color:#666666; text-decoration:none; valign:middle; text-align:left;}"
            theMessage = theMessage & ".namenormalc {font-family:Verdana, Arial, Helvetica, sans-serif; font-size:12px; font-style:normal; font-weight:normal; color:#666666; line-height:20px; padding-left:5px; padding-right:5px; valign:middle; text-align:center;}"
            theMessage = theMessage & ".namenormalc a{font-family:Verdana, Arial, Helvetica, sans-serif; font-size:13px; font-style:normal; font-weight:bold; color:#329344; text-decoration:none; valign:middle; text-align:center;}"
            theMessage = theMessage & ".namenormalc a:hover{font-family:Verdana, Arial, Helvetica, sans-serif; font-size:13px; font-style:normal; font-weight:normal; color:#666666; text-decoration:none; valign:middle; text-align:center;}"
            theMessage = theMessage & " .main  {margin-left:auto; margin-right:auto; margin-top:10px; margin-bottom:0px; background-color:#ffffff;}"
            theMessage = theMessage & " .contenttbl  tr td {padding-left: 5px; padding-right:5px; line-height: 21px; vertical-align:middle;}"
            theMessage = theMessage & " .bgc {background-color:#f5f5f5;}"
            theMessage = theMessage & "p {margin-top: 3px;margin-bottom: 3px;}"
            theMessage = theMessage & ".grid{width: 750px; background-color: #fff; margin: 5px 0 10px 0; border: solid 1px #525252; border-collapse: collapse;}"
            theMessage = theMessage & ".grid td{padding: 5px; border: solid 1px #c1c1c1; color: #717171; line-height: 20px; }"
            theMessage = theMessage & ".grid th {padding:10px; color: #000; background-color:#94bc16; border-left: solid 1px #525252; border-top: 1px solid #525252; font-size: 14px;font-weight:bold; }"
            theMessage = theMessage & ".grid .alt {background: #f7f7f7;}"
            theMessage = theMessage & ".tdr {text-align:right; padding: 5px; }"
            theMessage = theMessage & ".total-amount {color:#323232;  background:#ebebeb; border:1px solid #d6d6d6;}"
            theMessage = theMessage & ".total-amount tr td {padding:5px; border:1px solid #fff;}"
            theMessage = theMessage & ".amount {text-align:right; padding-right:10px !important; background:#d9d9d9; width:80px; color:#323232;}"

            theMessage = theMessage & "<!--"
            theMessage = theMessage & ".style1 {"
            theMessage = theMessage & vbTab & "font-family: Verdana;"
            theMessage = theMessage & "font-weight: bold;"
            theMessage = theMessage & "font-size: 12px;"
            theMessage = theMessage & "color: #000000;}"
            theMessage = theMessage & ".style3 {"
            theMessage = theMessage & vbTab & "font-family: Verdana;"
            theMessage = theMessage & vbTab & "font-size: 12px;"
            theMessage = theMessage & vbTab & "color: #000000;}"
            theMessage = theMessage & ".style4 {"
            theMessage = theMessage & vbTab & "font-family: Verdana;"
            theMessage = theMessage & "font-weight: bold;"
            theMessage = theMessage & "font-size: 12px;}"
            theMessage = theMessage & ".style5 {font-family: Verdana; font-size: 12px; color: #FF0000; }"
            theMessage = theMessage & ".style6 {font-family: Verdana; font-weight: bold; font-size: 12px; color: #FF0000; }"
            theMessage = theMessage & ".style7 {color: #FF0000;font-weight: bold;font-family: Verdana;font-size: 12px;}"
            theMessage = theMessage & "-->"
            theMessage = theMessage & "</style>"
            theMessage = theMessage & "</head>"
            theMessage = theMessage & "<body>"

            theMessage = theMessage & "<table width='750' border='0' align='center' cellpadding='0' cellspacing='0' class='main'>"
            theMessage = theMessage & "<tr> <td ><img  src='http://www.yahoo.com'/></td></tr>"

            theMessage = theMessage & "<tr> <td >&nbsp;</td></tr>"
            theMessage = theMessage & "<tr> <td align='center' style='padding-left:0px;'><table width='750' border='0' align='center' cellpadding='2' cellspacing='2' >"


            Return theMessage
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Shared Function GetMailFooter() As String
        Try
            Dim theMessage As String = ""

            theMessage = theMessage & "</table></td></tr>"
            theMessage = theMessage & "<tr> <td >&nbsp;</td></tr>"
            theMessage = theMessage & "<tr> <td class='footer'>&nbsp;</td></tr>"
            theMessage = theMessage & "<tr><td ></td> </tr></table></body></html>"

            Return theMessage
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Shared Function ScreenScrapeHtml(ByVal url As String) As String
        Try
            Dim objRequest As WebRequest = System.Net.HttpWebRequest.Create(url)
            Dim sr As New StreamReader(objRequest.GetResponse().GetResponseStream())
            Dim result As String = sr.ReadToEnd()
            sr.Close()
            Return result
        Catch ex As Exception

            Throw ex
        End Try

    End Function
    Public Shared Function CovertToTitleCase(ByVal anyCaseString As String) As String

        Try
            Return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(anyCaseString.ToLower())
        Catch ex As Exception

            Throw ex
        End Try
    End Function
    Public Shared Sub SendMail(ByVal toemail As String, ByVal subject As String, ByVal mailBody As String, ByVal attachment As String)
        Try
            Dim SmtpServer As String, SmtpUserName As String, SmtpPwd As String, AdminEmail As String
            SmtpServer = "localhost" 'System.Configuration.ConfigurationManager.AppSettings("smtpserver")
            SmtpUserName = System.Configuration.ConfigurationManager.AppSettings("smtpuser")
            SmtpPwd = System.Configuration.ConfigurationManager.AppSettings("smtppwd")
            AdminEmail = System.Configuration.ConfigurationManager.AppSettings("AdminEmail")
            Dim fromEmail As String = System.Configuration.ConfigurationManager.AppSettings("frommail")


            Dim msg As New MailMessage(fromEmail, toemail, subject, mailBody)
            If attachment <> "" Then
                Dim at As New Attachment(attachment)
                msg.Attachments.Add(at)
            End If

            msg.IsBodyHtml = True
            msg.Bcc.Add(AdminEmail)


            Dim emailClient As New SmtpClient(SmtpServer)
            '   Dim smtpUserinfo As New NetworkCredential(SmtpUserName, SmtpPwd)
            emailClient.UseDefaultCredentials = True
            '  emailClient.Credentials = smtpUserinfo
            emailClient.Send(msg)
            msg.Dispose()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Sub BindGrid(ByVal gv As GridView, ByVal ds As DataSet, ByVal tableIndex As Integer)
        Try
            If ds.Tables(tableIndex).Rows.Count > 0 Then
                gv.DataSource = ds.Tables(tableIndex)
                gv.DataBind()
            Else
                gv.DataSource = Nothing
                gv.DataBind()
            End If
        Catch ex As Exception

            Throw ex
        End Try
    End Sub

    Public Shared Sub BindRepeater(ByVal rep As Repeater, ByVal ds As DataSet, ByVal tableIndex As Integer)
        Try
            If ds.Tables(tableIndex).Rows.Count > 0 Then
                rep.DataSource = ds.Tables(tableIndex)
                rep.DataBind()
            Else
                rep.DataSource = Nothing
                rep.DataBind()
            End If
        Catch ex As Exception

            Throw ex
        End Try
    End Sub

    Public Shared Function ReplaceString(ByVal str As String, ByVal oldValue As String, ByVal newValue As String, ByVal comparison As StringComparison) As String
        Dim sb As New StringBuilder()

        Dim previousIndex As Integer = 0
        Dim index As Integer = str.IndexOf(oldValue, comparison)
        While index <> -1
            sb.Append(str.Substring(previousIndex, index - previousIndex))
            sb.Append(newValue)
            index += oldValue.Length

            previousIndex = index
            index = str.IndexOf(oldValue, index, comparison)
        End While
        sb.Append(str.Substring(previousIndex))

        Return sb.ToString()
    End Function

    Public Shared Function RemoveSpecialCharacters(ByVal str As String) As String
        Return Regex.Replace(str, "[^a-zA-Z0-9_. /s]+", "", RegexOptions.Compiled)
    End Function

    Public Shared Function RemoveSpecialCharactersb(ByVal str As String) As String
        Dim buffer As Char() = New Char(str.Length - 1) {}
        Dim idx As Integer = 0

        For Each c As Char In str
            If (c >= "0"c AndAlso c <= "9"c) OrElse (c >= "A"c AndAlso c <= "Z"c) OrElse (c >= "a"c AndAlso c <= "z"c) OrElse (c = "."c) OrElse (c = " "c) OrElse (c = "_"c) Then
                buffer(idx) = c
                idx += 1
            End If
        Next

        Return New String(buffer, 0, idx)
    End Function


    Public Shared Function GetHTMLBody(ByVal url As String) As String
        Dim htmlBody As String
        Using client As New WebClient()
            htmlBody = client.DownloadString(url)
        End Using
        Return htmlBody
    End Function
    Public Shared Function GetHttpResponse(ByVal url As String) As String
        Try
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
            Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            Using response
                Dim reader As New StreamReader(response.GetResponseStream())
                Return reader.ReadToEnd()
            End Using
        Catch ex As Exception

        End Try
    End Function
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
End Class