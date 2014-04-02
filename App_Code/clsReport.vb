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

Public Class clsReport
    Implements IDisposable
    Private _connection As SqlConnection
    Sub New()
        _connection = New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString)

    End Sub
    Public Function GetCashMovements(ByVal fromDate As Date, ByVal toDate As DateTime) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_Cash_BalanceMovementReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetChequedCashedReport(ByVal fromDate As Date, ByVal toDate As DateTime) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_Cheque_CashingReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetChequedDishonuredReport(ByVal fromDate As Date, ByVal toDate As DateTime) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_Cheque_CashingDishonoureReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function getRepaymentDue(ByVal fromDate As Date, ByVal toDate As DateTime, ByVal Payment_Method As String) As DataSet
        Try
            '
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    fc.Add("@Payment_Method", SqlDbType.VarChar, Payment_Method, 50, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_PaymentDueReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getTellersSales(ByVal fromDate As Date, ByVal toDate As DateTime, ByVal User_Machine_ID As String) As DataSet
        Try
            '
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    fc.Add("@User_Machine_ID", SqlDbType.VarChar, User_Machine_ID, 50, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_TellerSalesReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getInterBranchPaymentCollection(ByVal fromDate As Date, ByVal toDate As DateTime, ByVal Payment_Purpose As String) As DataSet
        Try
            '
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    fc.Add("@Payment_Purpose", SqlDbType.VarChar, Payment_Purpose, 50, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_Payment_CollectionInterBranchReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getRepaymentReceived(ByVal fromDate As Date, ByVal toDate As DateTime, ByVal Payment_Method As String) As DataSet
        Try
            '
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    fc.Add("@Payment_Method", SqlDbType.VarChar, Payment_Method, 50, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_PaymentRecvdReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getRepaymentWaived(ByVal fromDate As Date, ByVal toDate As DateTime) As DataSet
        Try
            '
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_PaymentWaivedReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetLoanDeclineReport(ByVal fromDate As Date, ByVal toDate As DateTime) As DataSet
        Try
            '
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_LoanDeclineReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function getCustomerBadDebt(ByVal fromDate As Date, ByVal toDate As DateTime) As DataSet
        Try
            '
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_CustomerBadDebtReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function getDefaultLetterNotices(ByVal fromDate As Date, ByVal toDate As DateTime, ByVal NoticeType As String) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    fc.Add("@NoticeType", SqlDbType.VarChar, NoticeType, 50, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_NoticesReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getDirectDebitDishonoured(ByVal fromDate As Date, ByVal toDate As DateTime) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_PaymentDishonouredReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' 
    Public Function getDebtorsasATReport(ByVal _date As Date) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@date", SqlDbType.Date, _date, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_DebtorsasATReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getLoanLocDebtorReport(ByVal chkCurLoan As String, ByVal chkDefLoc As String, ByVal chkWOFLoan As String, ByVal chkOnHoldLoan As String, ByVal chkLoan As String, ByVal ChkLoc As String) As DataSet
        Try
            '
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@chkCurLoan", SqlDbType.VarChar, chkCurLoan, 50, ParameterDirection.Input)
                    fc.Add("@chkDefLoc", SqlDbType.VarChar, chkDefLoc, 50, ParameterDirection.Input)
                    fc.Add("@chkWOFLoan", SqlDbType.VarChar, chkWOFLoan, 50, ParameterDirection.Input)
                    fc.Add("@chkOnHoldLoan", SqlDbType.VarChar, chkOnHoldLoan, 50, ParameterDirection.Input)
                    fc.Add("@chkLoan", SqlDbType.VarChar, chkLoan, 50, ParameterDirection.Input)
                    fc.Add("@ChkLoc", SqlDbType.VarChar, ChkLoc, 50, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_LoanDebtorReport", fc)
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getLoanSettlementReport(ByVal chkLoan As String, ByVal ChkLoc As String, ByVal fromDate As Date, ByVal toDate As DateTime) As DataSet
        Try
            '
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@chkLoan", SqlDbType.VarChar, chkLoan, 50, ParameterDirection.Input)
                    fc.Add("@ChkLoc", SqlDbType.VarChar, ChkLoc, 50, ParameterDirection.Input)
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_LoanSettlementReport", fc)
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getLoanTermLapseReport(ByVal fromDate As Date, ByVal toDate As DateTime) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_LoanTermLapseReport", fc)
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetFinancialStatusReport(ByVal fromDate As Date, ByVal toDate As DateTime) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_FinancialStatusReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function GetLoansCustomerReport(ByVal fromDate As Date, ByVal toDate As DateTime, ByVal fromAmount As Decimal, ByVal toAmount As Decimal) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)
                    fc.Add("@fromAmount", SqlDbType.Decimal, fromAmount, 0, ParameterDirection.Input)
                    fc.Add("@toAmount", SqlDbType.Decimal, toAmount, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_LoanCustomerReport", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCustomerJoinedOnReport(ByVal fromDate As Date, ByVal toDate As DateTime) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@fromDate", SqlDbType.Date, fromDate, 0, ParameterDirection.Input)
                    fc.Add("@toDate", SqlDbType.Date, toDate, 0, ParameterDirection.Input)                    
                    Return dl.GetDataSet("sp_Tbl_Customer_Joined_On", fc)
                    'Return dl.GetDataSet("sp_Tbl_Online_Joined", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getNames() As DataSet
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM sys_User join sys_Branch on sys_Branch.Branch_ID=sys_User.Branch_ID "
            If _connection.State = ConnectionState.Closed Then _connection.Open()
            cmd.Connection = _connection
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
    Public Function getLOC() As DataSet
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = " SELECT * FROM sys_Loan_Fee WHERE type ='LOC' "
            If _connection.State = ConnectionState.Closed Then _connection.Open()
            cmd.Connection = _connection
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
    Public Function getLoan() As DataSet
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = " SELECT * FROM sys_Loan_Fee WHERE type ='Loan' order by Amount"
            If _connection.State = ConnectionState.Closed Then _connection.Open()
            cmd.Connection = _connection
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
    Public Function getLoan(ByVal period As String) As DataSet
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = " SELECT * FROM sys_Loan_Fee WHERE type ='Loan' and period=" & Convert.ToDouble(period) & " order by Amount"
            If _connection.State = ConnectionState.Closed Then _connection.Open()
            cmd.Connection = _connection
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
    Public Function getDraw() As DataSet
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = " SELECT * FROM sys_Loan_Fee WHERE type ='Draw' "
            If _connection.State = ConnectionState.Closed Then _connection.Open()
            cmd.Connection = _connection
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
    Public Function getMoneyGram() As DataSet
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = " SELECT * FROM sys_Money_Gram_Fee "
            If _connection.State = ConnectionState.Closed Then _connection.Open()
            cmd.Connection = _connection
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

    ''
    Public Sub Dispose() Implements IDisposable.Dispose
        _connection = Nothing
    End Sub
End Class
