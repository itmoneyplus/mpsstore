Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports MPCommon.SQLDB
Public Class clsCustomer
    Implements IDisposable
    Private _connection As SqlConnection
    Sub New()
        _connection = New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString)

    End Sub
    Public Sub UpdateCustomerEmail(ByVal Customer_ID As Integer)
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Customer_ID", Data.SqlDbType.Int, Customer_ID, 0, Data.ParameterDirection.Input)
                    dl.ExecuteNonQuery("sp_Tbl_CustomerUpdateEmail", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '
    Public Function GetCustomerEmails(ByVal Customer_ID As Integer) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Customer_ID", Data.SqlDbType.Int, Customer_ID, 0, Data.ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_Cust_EmailSelectAll", fc)
                End Using
            End Using
        Catch ex As Exception

        End Try

    End Function
    Public Sub AddCustomerEmail(ByVal Customer_ID As String, ByVal CustEmail As String, ByVal CustEmailBody As String)
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Customer_ID", Data.SqlDbType.Int, Customer_ID, 0, Data.ParameterDirection.Input)
                    fc.Add("@CustEmail", Data.SqlDbType.VarChar, CustEmail, 100, Data.ParameterDirection.Input)
                    fc.Add("@CustEmailBody", Data.SqlDbType.VarChar, CustEmailBody, -1, Data.ParameterDirection.Input)
                    dl.ExecuteNonQuery("sp_Tbl_Cust_EmailAdd", fc)
                End Using
            End Using
        Catch ex As Exception

        End Try

    End Sub
    Public Sub AddCustomerEmail(ByVal Customer_ID As String, ByVal CustEmail As String, ByVal CustEmailBody As String, ByVal Loan_ID As Integer)
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Customer_ID", Data.SqlDbType.Int, Customer_ID, 0, Data.ParameterDirection.Input)
                    fc.Add("@CustEmail", Data.SqlDbType.VarChar, CustEmail, 100, Data.ParameterDirection.Input)
                    fc.Add("@CustEmailBody", Data.SqlDbType.VarChar, CustEmailBody, -1, Data.ParameterDirection.Input)
                    fc.Add("@Loan_ID", Data.SqlDbType.Int, Loan_ID, 0, Data.ParameterDirection.Input)
                    dl.ExecuteNonQuery("sp_Tbl_Cust_EmailLoanAdd", fc)
                End Using
            End Using
        Catch ex As Exception

        End Try

    End Sub
    '
    
#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        _connection = Nothing
    End Sub
#End Region

End Class
