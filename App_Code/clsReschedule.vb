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

Public Class clsReschedule
    Implements IDisposable
    Private _connection As SqlConnection
    Sub New()
        _connection = New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString)

    End Sub
    Public Function GetRescheduleActivity(ByVal Loan_ID As Integer) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Loan_ID", SqlDbType.Int, Loan_ID, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_ReScheduleSelectActivity", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetRescheduleActivityDetails(ByVal Loan_ID As Integer, ByVal Update_Number As Integer) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Loan_ID", SqlDbType.Int, Loan_ID, 0, ParameterDirection.Input)
                    fc.Add("@Update_Number", SqlDbType.Int, Update_Number, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_ReScheduleActivityDtls", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Dispose() Implements IDisposable.Dispose
        _connection = Nothing
    End Sub

End Class
