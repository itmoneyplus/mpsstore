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
''' created by Umesh Bharvad - bharvad.umesh@gmail.com
Public Class clsTellers
    Implements IDisposable
    Private _connection As SqlConnection

    Sub New()
        _connection = New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString)

    End Sub
    Public Function GetTellers() As DataSet
        Try

            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Return dl.GetDataSet("sp_getTillList")
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetTellerOpeningBalance(ByVal User_Machine_ID As String, ByVal DToday As Date) As Decimal
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@User_Machine_ID", SqlDbType.NVarChar, User_Machine_ID, 20, ParameterDirection.Input)
                    fc.Add("@DToday", SqlDbType.Date, DToday, 0, ParameterDirection.Input)
                    fc.Add("@TotalCashBalance", SqlDbType.Money, 0, 0, ParameterDirection.Output)
                    ' Dim obj As Object = dl.GetScalar("sp_getTellersReport_OpeningBalance", fc)
                    dl.ExecuteNonQuery("sp_getTellersReport_OpeningBalance", fc)
                    Dim obj As Object = fc.GetValue("@TotalCashBalance")
                    Return Convert.ToDecimal(obj)
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetTellerOtherBalance(ByVal User_Machine_ID As String, ByVal DToday As Date) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@User_Machine_ID", SqlDbType.NVarChar, User_Machine_ID, 20, ParameterDirection.Input)
                    fc.Add("@DToday", SqlDbType.Date, DToday, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_getTellersReport_OtherBalance", fc)
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Function
    Public Function BindTellerLOC(ByVal User_Machine_ID As String, ByVal DToday As Date) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@User_Machine_ID", SqlDbType.NVarChar, User_Machine_ID, 20, ParameterDirection.Input)
                    fc.Add("@DToday", SqlDbType.Date, DToday, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_getTellersReport_LOC", fc)
                End Using

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function BindTellerCheqCash(ByVal User_Machine_ID As String, ByVal DToday As Date) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@User_Machine_ID", SqlDbType.NVarChar, User_Machine_ID, 20, ParameterDirection.Input)
                    fc.Add("@DToday", SqlDbType.Date, DToday, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_getTellersReport_ChqCashing", fc)
                End Using

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function BindTellerPaymentCollection(ByVal User_Machine_ID As String, ByVal DToday As Date) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@User_Machine_ID", SqlDbType.NVarChar, User_Machine_ID, 20, ParameterDirection.Input)
                    fc.Add("@DToday", SqlDbType.Date, DToday, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_getTellersReport_PaymentCollection", fc)
                End Using

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BindTellerLoan(ByVal User_Machine_ID As String, ByVal DToday As Date) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@User_Machine_ID", SqlDbType.NVarChar, User_Machine_ID, 20, ParameterDirection.Input)
                    fc.Add("@DToday", SqlDbType.Date, DToday, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_getTellersReport_Loan", fc)
                End Using

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function BindTellerLoanRepay(ByVal User_Machine_ID As String, ByVal DToday As Date) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@User_Machine_ID", SqlDbType.NVarChar, User_Machine_ID, 20, ParameterDirection.Input)
                    fc.Add("@DToday", SqlDbType.Date, DToday, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_getTellersReport_LoanRepayment", fc)
                End Using

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetTillCountDs() As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Return dl.GetDataSet("sp_getTbl_TillCount")
            End Using

        Catch ex As Exception

        End Try
    End Function
    Public Function CheckCustomerExist(ByVal Customer_ID As Integer, ByVal DToday As Date) As Boolean
        Try
            ' Dim CustExist As Boolean = False
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Customer_ID", SqlDbType.Int, Customer_ID, 20, ParameterDirection.Input)
                    fc.Add("@DToday", SqlDbType.Date, DToday, 0, ParameterDirection.Input)
                    fc.Add("@CustExist", SqlDbType.VarChar, 0, 0, ParameterDirection.Output)
                    dl.ExecuteNonQuery("sp_Tbl_CustomerExistCheck", fc)
                    If Convert.ToString(fc.GetValue("@CustExist")) = "Y" Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Function
    Public Sub Dispose() Implements IDisposable.Dispose
        _connection = Nothing
    End Sub
End Class
