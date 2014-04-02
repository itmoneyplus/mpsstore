Imports System.Data.SqlClient
Imports System.Data


Partial Class Customer_Export
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            Try
                Dim MyCommand, MyCommand_New As New SqlCommand()
                Dim myDA, myDA_New As New SqlDataAdapter()
                Dim myDS, myDS_New As New export

                MyCommand.Connection = open_con.return_con
                MyCommand.CommandText = "SELECT * FROM tbl_Customer where tbl_Customer.Customer_ID=@Customer_ID"
                MyCommand.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = open_con.customer_id_val
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDS.EnforceConstraints = False
                myDA.Fill(myDS, "Tbl_Customer")


                lblcustname.Text = myDS.Tables(0).Rows(0).Item("Given_Name").ToString & " " & myDS.Tables(0).Rows(0).Item("Last_Name").ToString
                lblcustid.Text = Session("branch_prefix") & " " & open_con.customer_id_val
                titval.Text = myDS.Tables(0).Rows(0).Item("Title").ToString
                wrkval.Text = myDS.Tables(0).Rows(0).Item("Work_Phone").ToString
                lastnameval.Text = myDS.Tables(0).Rows(0).Item("Last_Name").ToString
                homephval.Text = myDS.Tables(0).Rows(0).Item("Home_Phone").ToString
                gvnnmval.Text = myDS.Tables(0).Rows(0).Item("Given_Name").ToString
                mobilephval.Text = myDS.Tables(0).Rows(0).Item("Mobile_Phone").ToString()
                dobval.Text = CDate(myDS.Tables(0).Rows(0).Item("Date_Of_Birth").ToString)
                emailval.Text = myDS.Tables(0).Rows(0).Item("Email").ToString()
                stnoval.Text = myDS.Tables(0).Rows(0).Item("Street_Number").ToString
                maddval.Text = myDS.Tables(0).Rows(0).Item("M_Address").ToString()
                stnmval.Text = myDS.Tables(0).Rows(0).Item("Street_Name").ToString()
                mstnmval.Text = myDS.Tables(0).Rows(0).Item("M_Street_Name").ToString()
                subval.Text = myDS.Tables(0).Rows(0).Item("Suburb").ToString
                msubval.Text = myDS.Tables(0).Rows(0).Item("M_Suburb").ToString()
                postcodeval.Text = myDS.Tables(0).Rows(0).Item("Post_Code").ToString()
                mpostcodeval.Text = myDS.Tables(0).Rows(0).Item("M_Post_Code").ToString()
                stateval.Text = myDS.Tables(0).Rows(0).Item("State").ToString()
                mstateval.Text = myDS.Tables(0).Rows(0).Item("M_State").ToString()
                mstatusval.Text = myDS.Tables(0).Rows(0).Item("Marital_Status").ToString()
                rstatusval.Text = myDS.Tables(0).Rows(0).Item("Residential_Status").ToString()
                rlastnmval.Text = myDS.Tables(0).Rows(0).Item("R_Last_Name").ToString()
                rgvnnmval.Text = myDS.Tables(0).Rows(0).Item("R_Given_Name").ToString()
                mphraseval.Text = myDS.Tables(0).Rows(0).Item("Marketing_Text").ToString()
                empval.Text = myDS.Tables(0).Rows(0).Item("Employer").ToString
                empemailval.Text = myDS.Tables(0).Rows(0).Item("E_Email").ToString
                empcnameval.Text = myDS.Tables(0).Rows(0).Item("E_Contact_Person").ToString
                typebusval.Text = myDS.Tables(0).Rows(0).Item("Business").ToString
                empphval.Text = myDS.Tables(0).Rows(0).Item("E_Phone_Number").ToString()
                ptrval.Text = myDS.Tables(0).Rows(0).Item("Payroll_Transfer").ToString()
                faxnoval.Text = myDS.Tables(0).Rows(0).Item("E_Fax_Number").ToString()
                empstsnval.Text = myDS.Tables(0).Rows(0).Item("E_Street_Number").ToString() & " " & myDS.Tables(0).Rows(0).Item("E_Street_Name").ToString()
                empnoval.Text = myDS.Tables(0).Rows(0).Item("Employee_no").ToString()
                empsuburbval.Text = myDS.Tables(0).Rows(0).Item("E_Suburb").ToString()
                posval.Text = myDS.Tables(0).Rows(0).Item("Position").ToString()
                emppostcodeval.Text = myDS.Tables(0).Rows(0).Item("E_Post_code").ToString()
                incomeval.Text = myDS.Tables(0).Rows(0).Item("Income").ToString()
                empstateval.Text = myDS.Tables(0).Rows(0).Item("E_State").ToString()


                MyCommand.Dispose()
                myDA.Dispose()
                myDS.Dispose()



                MyCommand_New.CommandText = "SELECT * FROM userdata where userdata.Customer_ID=@Customer_ID1"
                MyCommand_New.Parameters.Add("@Customer_ID1", SqlDbType.Int).Value = open_con.customer_id_val
                MyCommand_New.CommandType = CommandType.Text
                myDA_New.SelectCommand = MyCommand
                myDS_New.EnforceConstraints = False
                myDA_New.Fill(myDS_New, "userdata")



                MyCommand_New.Dispose()
                myDA_New.Dispose()
                myDS_New.Dispose()

                open_con.return_con.Dispose()
            Catch ex As Exception
                Response.Write("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
