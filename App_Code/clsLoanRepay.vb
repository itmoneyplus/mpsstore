Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports MPCommon.SQLDB

Public Class clsLoanRepay
    Implements IDisposable
    Private _connection As SqlConnection
    Sub New()
        _connection = New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString)
    End Sub
    Public Sub UpdateExistingPayment(ByVal Payment_ID As Integer, ByVal Amount As Decimal, ByVal User_ID As Integer, ByVal User_Machine_ID As String)
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Payment_ID", SqlDbType.Int, Payment_ID, 0, ParameterDirection.Input)
                    fc.Add("@Amount", SqlDbType.Decimal, Amount, 0, ParameterDirection.Input)
                    fc.Add("@User_ID", SqlDbType.Int, User_ID, 0, ParameterDirection.Input)
                    fc.Add("@User_Machine_ID", SqlDbType.NVarChar, User_Machine_ID, 20, ParameterDirection.Input)
                    dl.ExecuteNonQuery("sp_Tbl_PaymentUpdateExistingPayment", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub AddNewLoanRepayment()
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()

                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub
#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        _connection = Nothing
    End Sub
#End Region
End Class
