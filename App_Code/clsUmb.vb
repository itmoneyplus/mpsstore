Imports System.Data
Imports System.Configuration
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports MPCommon.SQLDB
Imports System.Data.SqlClient

Public Class clsUmb
    '
    Implements IDisposable
    Private _connection As SqlConnection
    Sub New()
        _connection = New SqlConnection("server=mssql01;database=cuykynsisite;user id=cuykynsiweb_ms;password=AdMiN@1@3$5")

    End Sub
    Public Sub updateDB(ByVal str As String)
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                dl.ExecuteNonQuery(str, CommandType.Text)

            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        _connection = Nothing
    End Sub
End Class
