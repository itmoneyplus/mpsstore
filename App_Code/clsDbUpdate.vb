Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports MPCommon.SQLDB



Public Class clsDbUpdate
    Implements IDisposable
    Private _connection As SqlConnection
    Sub New()
        _connection = New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString)
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
