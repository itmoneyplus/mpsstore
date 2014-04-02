Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Partial Class Customer_add_loan_fee
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim cmd_till As New SqlCommand
        'Dim cmd_till1 As New SqlCommand
        'cmd_till.CommandText = "INSERT INTO sys_Loan_Fee (ID,Amount,Application_Fee,Credit_Fee,Period,Percentage,Type)VALUES (351,1100,400,66,3,24,'Loan')"
        'cmd_till.Connection = open_con.return_con
        'cmd_till.ExecuteNonQuery()
        'cmd_till1.CommandText = "INSERT INTO sys_Loan_Fee (ID,Amount,Application_Fee,Credit_Fee,Period,Percentage,Type)VALUES (352,1100,400,66,3,24,'Loan')"
        'cmd_till1.Connection = open_con.return_con
        'cmd_till1.ExecuteNonQuery()
        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "MyAlert", "alert('" & "Loan fee has been updated!!!" & "');", True)
        'cmd_till.Dispose()
        'open_con.return_con.Dispose()
    End Sub
End Class
