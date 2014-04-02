Imports System.Data.SqlClient
Imports System.Data
Partial Class toolbaar_Cheque_detail
    Inherits System.Web.UI.UserControl
    Dim open_con As New Class1
    Dim Cheque_Cashing_ID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
           
            Cheque_Cashing_ID = Request("Cheque_Cashing_ID")
            If Cheque_Cashing_ID = 0 Then
                Cheque_Cashing_ID = Session("Cheque_Cashing_ID")
            End If
            Dim cheque_cmd As New SqlCommand
            Dim ds_cheque As New DataSet
            Dim adap_cheque As SqlDataAdapter
            cheque_cmd.CommandText = "Select * from Tbl_Cheque_Cashing Where Cheque_Cashing_ID =" & Cheque_Cashing_ID
            cheque_cmd.Connection = open_con.return_con
            adap_cheque = New SqlDataAdapter(cheque_cmd)
            adap_cheque.Fill(ds_cheque)
            lblchknm.Text = ds_cheque.Tables(0).Rows(0).Item("Cheque_Name").ToString
            lblchkbsb.Text = ds_cheque.Tables(0).Rows(0).Item("BSB").ToString
            lblcheno.Text = ds_cheque.Tables(0).Rows(0).Item("Cheque_Number").ToString
            lblaccno.Text = ds_cheque.Tables(0).Rows(0).Item("Account_Number").ToString
            lblcheamt.Text = FormatNumber(ds_cheque.Tables(0).Rows(0).Item("Cheque_Amount").ToString, 2)
            lblchefee.Text = FormatNumber(ds_cheque.Tables(0).Rows(0).Item("Cheque_Fee").ToString, 2)
            lblpaidcash.Text = FormatNumber(ds_cheque.Tables(0).Rows(0).Item("Pay_Cash_Now").ToString, 2)
            cheque_cmd.Dispose()
            adap_cheque.Dispose()
            ds_cheque.Dispose()
            open_con.return_con.Dispose()
        End If
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub

    Protected Sub btnprntrecpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprntrecpt.Click
        Response.Redirect("../Reports/Cheque_Receipt.aspx?Cheque_Cashing_ID=" & Cheque_Cashing_ID)
    End Sub

    Protected Sub btndis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndis.Click
        Response.Redirect("../Customer/Cheque Dishonour.aspx?Cheque_Cashing_ID=" & Cheque_Cashing_ID)
    End Sub
End Class
