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

Public Class clsUser
    Implements IDisposable
    Private _connection As SqlConnection
    Sub New()
        _connection = New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString)

    End Sub
    Public Sub ChkLoginTrack(ByVal User_ID As Integer, ByVal LoginIP As String)
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@User_ID", SqlDbType.Int, User_ID, 0, ParameterDirection.Input)
                    fc.Add("@LoginIP", SqlDbType.VarChar, LoginIP, 50, ParameterDirection.Input)
                    dl.ExecuteNonQuery("sp_sys_UserLogin_Track", fc)

                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetLoginTrackReport(ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal LoginStatus As String) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@startDate", SqlDbType.Date, startDate, 0, ParameterDirection.Input)
                    fc.Add("@endDate", SqlDbType.Date, endDate, 0, ParameterDirection.Input)
                    fc.Add("@LoginStatus", SqlDbType.VarChar, LoginStatus, 25, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_sys_UserLogin_TrackReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub deleteUser(ByVal userID As Int32)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "DELETE FROM sys_User WHERE User_ID=@userid"
            If _connection.State = ConnectionState.Closed Then _connection.Open()
            cmd.Connection = _connection
            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = userID
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            _connection.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function getUser(ByVal userID As Int32) As DataSet
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM sys_User WHERE User_ID=@userid"
            If _connection.State = ConnectionState.Closed Then _connection.Open()
            cmd.Connection = _connection
            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = userID
            cmd.ExecuteNonQuery()
            Dim adap As SqlDataAdapter
            adap = New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            adap.Fill(ds)
            adap.Dispose()
            cmd.Dispose()
            _connection.Close()
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        _connection = Nothing
    End Sub
End Class
