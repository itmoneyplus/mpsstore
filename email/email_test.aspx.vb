Imports System.Net
Imports System.Net.Mail
Partial Class email_email_test
    Inherits System.Web.UI.Page

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try

            clsGeneral.SendMail(TextBox1.Text, "Hello Test", "TEST", "")
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Public Sub SendMail(ByVal toemail As String, ByVal subject As String, ByVal mailBody As String, ByVal attachment As String)
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
            ' Dim smtpUserinfo As New NetworkCredential(SmtpUserName, SmtpPwd)
            emailClient.UseDefaultCredentials = True
            '   emailClient.Credentials
            emailClient.Send(msg)
            msg.Dispose()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
