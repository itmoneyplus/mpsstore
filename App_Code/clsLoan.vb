Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports MPCommon.SQLDB

Public Class clsLoan
    Implements IDisposable
    Private _connection As SqlConnection
    Sub New()
        _connection = New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString)
    End Sub
    Public Function GetLoadDetailsByID(ByVal Loan_ID As Integer) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Loan_ID", SqlDbType.Int, Loan_ID, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_LoanByLoanId", fc)
                End Using
            End Using

        Catch ex As Exception

        End Try
    End Function
    Public Sub UpdateLoanEmail(ByVal Loan_ID As Integer, ByVal Customer_ID As Integer, ByVal Who As Integer)
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Loan_ID", SqlDbType.Int, Loan_ID, 0, ParameterDirection.Input)
                    fc.Add("@Customer_ID", SqlDbType.Int, Customer_ID, 0, ParameterDirection.Input)
                    fc.Add("@Who", SqlDbType.Int, Who, 0, ParameterDirection.Input)
                    dl.ExecuteNonQuery("sp_Tbl_LoanUpdateEmail", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetAllPayments(ByVal Loan_ID As Integer, ByVal Toshow As Integer) As DataSet
        '
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Loan_ID", SqlDbType.Int, Loan_ID, 0, ParameterDirection.Input)
                    fc.Add("@Toshow", SqlDbType.Int, Toshow, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_PaymentShowAll", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetLastPayment(ByVal Loan_ID As Integer) As String
        Try
            Dim str_paymentDate As String = ""
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Loan_ID", SqlDbType.Int, Loan_ID, 0, ParameterDirection.Input)
                    Dim ds As DataSet = dl.GetDataSet("sp_Tbl_LoanLastPmtByLoanId", fc)

                    If ds.Tables(0).Rows.Count > 0 Then
                        str_paymentDate = Convert.ToDateTime(ds.Tables(0).Rows(0).Item("Payment_Date"))
                    End If
                End Using
                Return str_paymentDate
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        _connection = Nothing
    End Sub
#End Region
End Class
