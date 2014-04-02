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

Public Class clsPmtCol
    Implements IDisposable
    Private _connection As SqlConnection
    Sub New()
        _connection = New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString)

    End Sub
    Public Function AddPaymentCollection(ByVal Customer_ID As Integer, ByVal Customer_Name As String, ByVal Branch_Name As String, ByVal Amount As Decimal, ByVal Payment_Purpose As String, _
                                 ByVal User_ID As Integer, ByVal User_Machine_ID As String) As Integer
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Customer_ID", SqlDbType.Int, Customer_ID, 0, ParameterDirection.Input)
                    fc.Add("@Customer_Name", SqlDbType.NVarChar, Customer_Name, 50, ParameterDirection.Input)
                    fc.Add("@Branch_Name", SqlDbType.NVarChar, Branch_Name, 50, ParameterDirection.Input)
                    fc.Add("@Amount", SqlDbType.Money, Amount, 0, ParameterDirection.Input)
                    fc.Add("@Payment_Purpose", SqlDbType.NVarChar, Payment_Purpose, 20, ParameterDirection.Input)
                    fc.Add("@User_ID", SqlDbType.Int, User_ID, 0, ParameterDirection.Input)
                    fc.Add("@User_Machine_ID", SqlDbType.VarChar, User_Machine_ID, 20, ParameterDirection.Input)
                    fc.Add("@Payment_Collection_ID", SqlDbType.Int, 0, 0, ParameterDirection.Output)

                    dl.ExecuteNonQuery("sp_Tbl_Payment_CollectionAdd", fc)
                    Dim pid As Integer
                    pid = fc.GetValue("@Payment_Collection_ID")
                    Return pid


                End Using
            End Using

        Catch ex As Exception

        End Try
    End Function
    Public Function GetPmtCollectionDetails(ByVal Payment_Collection_ID As Integer) As DataSet
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Payment_Collection_ID", SqlDbType.Int, Payment_Collection_ID, 0, ParameterDirection.Input)
                    Return dl.GetDataSet("sp_Tbl_Payment_CollectionById", fc)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdatePaymentCollection(ByVal Payment_Collection_ID As Integer, ByVal Customer_ID As Integer, ByVal Customer_Name As String, ByVal Branch_Name As String, ByVal Amount As Decimal, ByVal Payment_Purpose As String, _
                                ByVal User_ID As Integer, ByVal Time_Collect As DateTime, ByVal Date_Updated As DateTime)
        Try
            Using dl As New DataAccessLayer()
                dl.DataSource = _connection
                Using fc As New FieldsCollection()
                    fc.Add("@Payment_Collection_ID", SqlDbType.Int, Payment_Collection_ID, 0, ParameterDirection.Input)
                    fc.Add("@Customer_ID", SqlDbType.Int, Customer_ID, 0, ParameterDirection.Input)
                    fc.Add("@Customer_Name", SqlDbType.NVarChar, Customer_Name, 50, ParameterDirection.Input)
                    fc.Add("@Branch_Name", SqlDbType.NVarChar, Branch_Name, 50, ParameterDirection.Input)
                    fc.Add("@Amount", SqlDbType.Money, Amount, 0, ParameterDirection.Input)
                    fc.Add("@Payment_Purpose", SqlDbType.NVarChar, Payment_Purpose, 20, ParameterDirection.Input)
                    fc.Add("@User_ID", SqlDbType.Int, User_ID, 0, ParameterDirection.Input)
                    fc.Add("@Time_Collect", SqlDbType.DateTime, Time_Collect, 0, ParameterDirection.Input)
                    fc.Add("@Date_Updated", SqlDbType.Date, Date_Updated, 0, ParameterDirection.Input)
                    dl.ExecuteNonQuery("", fc)

                End Using
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        _connection = Nothing
    End Sub
End Class
