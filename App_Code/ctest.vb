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

Public Class ctest
    Implements IDisposable
    Private _connection As SqlConnection
    Public Sub New()
        _connection = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("ConStr"))

    End Sub

    Public Sub AddAppointment(ByVal UserID As Integer, ByVal AppointmentDate As DateTime, ByVal AppointmentTime As TimeSpan, ByVal AppointmentFor As String, ByVal AppointmentWith As Integer, ByVal InquiryID As Integer)
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection

                Using fc As New FieldsCollection()
                    fc.Add("@UserID", SqlDbType.Int, UserID, 0, ParameterDirection.Input)
                    fc.Add("@AppointmentDate", SqlDbType.DateTime, AppointmentDate, 0, ParameterDirection.Input)
                    fc.Add("@AppointmentTime", SqlDbType.Time, AppointmentTime, 0, ParameterDirection.Input)
                    fc.Add("@AppointmentFor", SqlDbType.VarChar, AppointmentFor.Trim(), 150, ParameterDirection.Input)
                    fc.Add("@AppointmentWith", SqlDbType.Int, AppointmentWith, 0, ParameterDirection.Input)
                    fc.Add("@InquiryID", SqlDbType.Int, InquiryID, 0, ParameterDirection.Input)

                    dl.ExecuteNonQuery("stp_tblAppointmentAdd", fc)
                End Using

            End Using
        Catch generatedExceptionName As Exception

            Throw
        End Try
    End Sub
   


    Public Sub Dispose() Implements IDisposable.Dispose
        _connection = Nothing
    End Sub
End Class
