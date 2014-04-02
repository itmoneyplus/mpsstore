Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Object
Imports System.Security.Cryptography.HashAlgorithm
Imports System.Security.Cryptography.MD5
Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class Class1

    Public con As New SqlConnection
    Public str_MachineName As String
    Public sys_ip As String
    Sub New()
        con.ConnectionString = ConfigurationManager.ConnectionStrings("cn").ConnectionString
    End Sub
    Function fn_FormatMPDate(ByVal fn_date As String) As String
        Dim fn_loanstatus As String
        Dim fn_loanstatus_new As Date
        fn_loanstatus_new = Convert.ToDateTime(fn_date)
        fn_loanstatus = Date.Parse(fn_loanstatus_new.ToString("dd-MMM-yyyy"))
        fn_loanstatus = fn_loanstatus.Replace("-", " ")
        Return fn_loanstatus

    End Function
    Public Function connect_con() As Boolean

        If con.State = ConnectionState.Closed Then con.Open()
        connect_con = True
    End Function
    Public Function abc() As Integer

    End Function
    Public Function return_con() As SqlConnection


        If con.State = ConnectionState.Open Then
            con.Dispose()
            con.ConnectionString = ConfigurationManager.ConnectionStrings("cn").ConnectionString
            con.Open()
        ElseIf con.State = ConnectionState.Closed Then
            con.ConnectionString = ConfigurationManager.ConnectionStrings("cn").ConnectionString
            con.Open()
        End If
        return_con = con
    End Function
    Public Function user_name(ByVal user_id As Integer) As String
        Dim cmd As New SqlCommand
        Dim str_SQL As String
        str_SQL = " SELECT Given_Name from sys_User "

        str_SQL = str_SQL & " WHERE User_Id= @a  "
        cmd.CommandText = str_SQL

        cmd.Parameters.Add("@a", SqlDbType.VarChar, 50).Value = user_id

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        Dim adap As SqlDataAdapter
        adap = New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        adap.Fill(ds)
        Return ds.Tables(0).Rows(0).Item(0).ToString

    End Function

    Public Function manager_name(ByVal user_id As Integer) As String
        Dim cmd As New SqlCommand
        Dim str_SQL As String
        str_SQL = " SELECT user_type from sys_User "

        str_SQL = str_SQL & " WHERE User_Id= @a  "
        cmd.CommandText = str_SQL

        cmd.Parameters.Add("@a", SqlDbType.Int).Value = user_id

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        Dim adap As SqlDataAdapter
        adap = New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        adap.Fill(ds)

        Return ds.Tables(0).Rows(0).Item(0).ToString

    End Function
    Public Structure customer
        Public status As String
        Public status_date As String
    End Structure
    Public Function customer_status(ByVal customer_id As Integer) As customer
        Dim cust As New customer
        Dim cmd As New SqlCommand
        Dim str_SQL As String
        str_SQL = " SELECT Status,Status_Date from tbl_customer "

        str_SQL = str_SQL & " WHERE customer_id= @a  "
        cmd.CommandText = str_SQL

        cmd.Parameters.Add("@a", SqlDbType.Int).Value = customer_id

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        Dim adap As SqlDataAdapter
        adap = New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        adap.Fill(ds)


        cust.status = ds.Tables(0).Rows(0).Item(0).ToString
        cust.status_date = ds.Tables(0).Rows(0).Item(1).ToString().ToString
        Return cust

    End Function
    Public Function followup_status(ByVal customer_id As Integer) As Boolean
        Dim cust As New customer
        Dim cmd As New SqlCommand
        Dim str_SQL As String
        str_SQL = " SELECT followup from tbl_customer "

        str_SQL = str_SQL & " WHERE customer_id= @a  "
        cmd.CommandText = str_SQL

        cmd.Parameters.Add("@a", SqlDbType.Int).Value = customer_id

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        Dim adap As SqlDataAdapter
        adap = New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        adap.Fill(ds)
        Dim status_new As String
        status_new = ds.Tables(0).Rows(0).Item(0).ToString
        Return status_new

    End Function
    Public Function validate_input(ByVal user_nm As String, ByVal pwd As String) As Boolean
        Dim user_name, pwd_name As String
        user_name = user_nm
        pwd_name = pwd

        If (user_name = "") And (pwd_name <> "") Then
            validate_input = False
        End If

        If (pwd_name = "") And (user_name <> "") Then
            validate_input = False
        End If

        If (user_name = "") And (pwd_name = "") Then
            validate_input = False
        End If

        If (user_name <> "") And (pwd_name <> "") Then

            Dim cmd_user As New SqlCommand
            Dim str_SQL_user As String
            str_SQL_user = " SELECT sys_User.Password from sys_User WHERE sys_User.Logon_ID='" & user_name & "'"
            cmd_user.CommandText = str_SQL_user
            If con.State = ConnectionState.Closed Then con.Open()
            cmd_user.Connection = con
            cmd_user.ExecuteNonQuery()
            Dim adap_user As SqlDataAdapter
            adap_user = New SqlDataAdapter(cmd_user)
            Dim ds_user As New DataSet
            adap_user.Fill(ds_user)
            con.Close()
            cmd_user.Dispose()
            adap_user.Dispose()


            Dim cmd As New SqlCommand
            Dim str_SQL As String
            str_SQL = " SELECT sys_User.User_ID, sys_User.Branch_ID AS User_Branch_ID, sys_User.Given_Name, sys_User.Last_Name, sys_User.Logon_ID, sys_User.Password, "
            str_SQL = str_SQL & " sys_User.User_Type, sys_User.FirstTime_Login, sys_Branch.* "
            str_SQL = str_SQL & " FROM sys_Branch INNER JOIN sys_User ON sys_Branch.Branch_ID = sys_User.Branch_ID "
            str_SQL = str_SQL & " WHERE sys_User.Logon_ID= @a and sys_User.Password= @b "
            cmd.CommandText = str_SQL
            cmd.Parameters.Add("@a", SqlDbType.VarChar, 50).Value = user_name
            'Dim hashedBytes As Byte()
            'Dim md5Hasher As New System.Security.Cryptography.MD5CryptoServiceProvider
            ' Dim encoder As New UTF8Encoding
            ' hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(pwd_name))
            'cmd.Parameters.Add("@b", SqlDbType.Binary, 50).Value = hashedBytes
            cmd.Parameters.Add("@b", SqlDbType.NVarChar, 50).Value = pwd_name
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            Dim adap As SqlDataAdapter
            adap = New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            adap.Fill(ds)
            con.Close()
            cmd.Dispose()
            adap.Dispose()
            ds_user.Dispose()
          
            If ds.Tables(0).Rows.Count <> 0 Then
                validate_input = True
            Else
                validate_input = False
            End If
        Else

        End If
    End Function

    Public Function save_customer(ByVal title As String, ByVal last_name As String, ByVal given_name As String, ByVal date_of_birth As Date, ByVal home_phone As String, ByVal work_phone As String, ByVal mobile_phone As String, ByVal street_number As String, ByVal street_name As String, ByVal suburb As String, ByVal state As String, ByVal post_code As String, ByVal m_address As String, ByVal m_street_name As String, ByVal m_suburb As String, ByVal m_state As String, ByVal m_post_code As String, ByVal marital_status As String, ByVal residential_status As String, ByVal joint_borrowing As String, ByVal relationship As String, ByVal r_last_name As String, ByVal r_given_name As String, ByVal marketing_text As String, ByVal employer As String, ByVal e_contact_person As String, ByVal e_street_number As String, ByVal e_building As String, ByVal e_street_name As String, ByVal e_suburb As String, ByVal e_post_code As String, ByVal e_state As String, ByVal e_phone_number As String, ByVal e_fax_number As String, ByVal e_email As String, ByVal payroll_transfer As String, ByVal status As Integer, ByVal status_date As String, ByVal business As String, ByVal position As String, ByVal email As String, ByVal income As String, ByVal employee_no As String, ByVal request_amount As String, ByVal purpose_loan As String, ByVal d_licence As String, ByVal Licence_card_no As String, ByVal d_state As String, ByVal passport As String, ByVal countries As String, ByVal Place_Of_Birth As String, ByVal unit_no As String, ByVal m_unit_no As String, ByVal emp_status As String, ByVal emp_year As String, ByVal emp_mths As String, ByVal agent As String, ByVal agent_no As String, ByVal time_joined As String, ByVal date_joined As Date, ByVal date_updated As String) As Boolean

        Dim cmd As New SqlCommand
        cmd.CommandText = "insert into Tbl_Customer( Title,Last_Name,Given_Name,Date_of_Birth,Home_Phone,Work_Phone,Mobile_Phone,Street_Number,Street_Name,Suburb,State,Post_Code,M_Address,M_Street_Name,M_Suburb,M_State,M_Post_Code,Marital_Status,Residential_Status,Joint_Borrowing,Relationship,R_Last_Name,R_Given_Name,Marketing_Text,Employer,E_Contact_Person,E_Street_Number,E_Building,E_Street_Name,E_Suburb,E_Post_Code,E_State,E_Phone_Number,E_Fax_Number,E_Email,Payroll_Transfer,Status,Status_Date,Business,Position,Email,Income,Employee_no,Request_Amount,Purpose_Loan,D_Licence,Licence_card_no,D_State,Passport,Countries,Place_Of_Birth,Unit_No,M_Unit_No,Emp_Status,Emp_Year,Emp_Mths,Agent,Agent_No,Time_Joined,Date_Joined,Date_Updated)values(@title,@last_name,@given_name,@date_of_birth,@home_phone,@work_phone,@mobile_phone,@street_number ,@street_name ,@suburb,@state ,@post_code ,@m_address ,@m_street_name ,@m_suburb ,@m_state ,@m_post_code,@marital_status ,@residential_status ,@joint_borrowing ,@relationship ,@r_last_name,@r_given_name ,@marketing_text ,@employer ,@e_contact_person ,@e_street_number ,@e_building ,@e_street_name,@e_suburb ,@e_post_code ,@e_state ,@e_phone_number ,@e_fax_number ,@e_email ,@payroll_transfer ,@status ,@status_date ,@business ,@position ,@email ,@income ,@employee_no,@request_amount ,@purpose_loan ,@d_licence ,@Licence_card_no ,@d_state ,@passport ,@countries ,@Place_Of_Birth ,@unit_no ,@m_unit_no ,@emp_status ,@emp_year ,@emp_mths ,@agent ,@agent_no  ,@time_joined ,@date_joined ,@date_updated )"
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.Connection = con
        cmd.Parameters.Add("@title", Data.SqlDbType.VarChar, 255).Value = title
        cmd.Parameters.Add("@last_name", Data.SqlDbType.VarChar, 255).Value = last_name
        cmd.Parameters.Add("@given_name", Data.SqlDbType.VarChar, 255).Value = given_name
        Dim date_count As Integer
        date_count = DateTime.Now.Year - date_of_birth.Year
        If date_count < 18 Then
            save_customer = False
            Exit Function
        Else
            cmd.Parameters.Add("@date_of_birth", Data.SqlDbType.Date).Value = date_of_birth
        End If
        cmd.Parameters.Add("@home_phone", Data.SqlDbType.VarChar, 255).Value = home_phone
        cmd.Parameters.Add("@work_phone", Data.SqlDbType.VarChar, 255).Value = work_phone
        cmd.Parameters.Add("@mobile_phone", Data.SqlDbType.VarChar, 255).Value = mobile_phone
        cmd.Parameters.Add("@street_number", Data.SqlDbType.VarChar, 255).Value = street_number
        cmd.Parameters.Add("@street_name", Data.SqlDbType.VarChar, 255).Value = street_name
        cmd.Parameters.Add("@suburb", Data.SqlDbType.VarChar, 255).Value = suburb
        cmd.Parameters.Add("@state", Data.SqlDbType.VarChar, 255).Value = state

        If post_code = "" Then
            post_code = 0

        End If

        cmd.Parameters.Add("@post_code", Data.SqlDbType.VarChar, 255).Value = post_code
        cmd.Parameters.Add("@m_address ", Data.SqlDbType.VarChar, 255).Value = m_address
        cmd.Parameters.Add("@m_street_name ", Data.SqlDbType.VarChar, 255).Value = m_street_name
        cmd.Parameters.Add("@m_suburb", Data.SqlDbType.VarChar, 255).Value = m_suburb
        cmd.Parameters.Add("@m_state", Data.SqlDbType.VarChar, 255).Value = m_state
        cmd.Parameters.Add("@m_post_code", Data.SqlDbType.VarChar, 255).Value = m_post_code
        cmd.Parameters.Add("@marital_status ", Data.SqlDbType.VarChar, 255).Value = marital_status
        cmd.Parameters.Add("@residential_status ", Data.SqlDbType.VarChar, 255).Value = residential_status
        cmd.Parameters.Add("@joint_borrowing", Data.SqlDbType.VarChar, 255).Value = ""
        cmd.Parameters.Add("@relationship", Data.SqlDbType.VarChar, 255).Value = ""
        cmd.Parameters.Add("@r_last_name", Data.SqlDbType.VarChar, 255).Value = r_last_name
        cmd.Parameters.Add("@r_given_name", Data.SqlDbType.VarChar, 255).Value = r_given_name
        cmd.Parameters.Add("@marketing_text ", Data.SqlDbType.VarChar, 255).Value = marketing_text
        cmd.Parameters.Add("@employer", Data.SqlDbType.VarChar, 255).Value = employer
        cmd.Parameters.Add("@e_contact_person", Data.SqlDbType.VarChar, 255).Value = e_contact_person
        cmd.Parameters.Add("@e_street_number", Data.SqlDbType.VarChar, 255).Value = e_street_number
        cmd.Parameters.Add("@e_building", Data.SqlDbType.VarChar, 255).Value = e_building
        cmd.Parameters.Add("@e_street_name ", Data.SqlDbType.VarChar, 255).Value = e_street_name
        cmd.Parameters.Add("@e_suburb", Data.SqlDbType.VarChar, 255).Value = e_suburb
        cmd.Parameters.Add("@e_post_code", Data.SqlDbType.VarChar, 255).Value = e_post_code
        cmd.Parameters.Add("@e_state", Data.SqlDbType.VarChar, 255).Value = e_state
        cmd.Parameters.Add("@e_phone_number", Data.SqlDbType.VarChar, 255).Value = e_phone_number
        cmd.Parameters.Add("@e_fax_number", Data.SqlDbType.VarChar, 255).Value = e_fax_number
        cmd.Parameters.Add("@e_email", Data.SqlDbType.VarChar, 255).Value = e_email
        cmd.Parameters.Add("@payroll_transfer", Data.SqlDbType.VarChar, 255).Value = payroll_transfer
        cmd.Parameters.Add("@status", Data.SqlDbType.VarChar, 255).Value = status
        cmd.Parameters.Add("@status_date", Data.SqlDbType.VarChar, 255).Value = status_date
        cmd.Parameters.Add("@business", Data.SqlDbType.VarChar, 255).Value = business
        cmd.Parameters.Add("@position", Data.SqlDbType.VarChar, 255).Value = position
        cmd.Parameters.Add("@email", Data.SqlDbType.VarChar, 255).Value = email
        cmd.Parameters.Add("@income", Data.SqlDbType.VarChar, 255).Value = income
        cmd.Parameters.Add("@employee_no ", Data.SqlDbType.VarChar, 255).Value = employee_no
        Dim request_amount1 As Integer

        Dim i As Integer
        i = Len(request_amount)
        request_amount1 = Mid(request_amount, 1)

        cmd.Parameters.Add("@request_amount", Data.SqlDbType.Int).Value = request_amount1
        cmd.Parameters.Add("@purpose_loan", Data.SqlDbType.VarChar, 255).Value = purpose_loan
        cmd.Parameters.Add("@d_licence", Data.SqlDbType.VarChar, 255).Value = d_licence
        cmd.Parameters.Add("@Licence_card_no", Data.SqlDbType.VarChar, 255).Value = Licence_card_no
        cmd.Parameters.Add("@d_state", Data.SqlDbType.VarChar, 255).Value = d_state
        cmd.Parameters.Add("@passport", Data.SqlDbType.VarChar, 255).Value = passport
        cmd.Parameters.Add("@countries", Data.SqlDbType.VarChar, 255).Value = countries
        cmd.Parameters.Add("@Place_Of_Birth", Data.SqlDbType.VarChar, 255).Value = Place_Of_Birth
        cmd.Parameters.Add("@unit_no", Data.SqlDbType.VarChar, 255).Value = unit_no
        cmd.Parameters.Add("@m_unit_no", Data.SqlDbType.VarChar, 255).Value = m_unit_no
        cmd.Parameters.Add("@emp_status", Data.SqlDbType.VarChar, 255).Value = emp_status
        cmd.Parameters.Add("@emp_year", Data.SqlDbType.VarChar, 255).Value = emp_year
        cmd.Parameters.Add("@emp_mths", Data.SqlDbType.VarChar, 255).Value = emp_mths
        cmd.Parameters.Add("@agent", Data.SqlDbType.VarChar, 255).Value = agent
        cmd.Parameters.Add("@agent_no", Data.SqlDbType.VarChar, 255).Value = agent_no
        cmd.Parameters.Add("@time_joined", Data.SqlDbType.DateTime).Value = time_joined
        cmd.Parameters.Add("@date_joined", Data.SqlDbType.Date).Value = date_joined
        cmd.Parameters.Add("@date_updated", Data.SqlDbType.VarChar, 50).Value = date_updated
        cmd.ExecuteNonQuery()
        save_customer = True
        cmd.Dispose()
        con.Close()
    End Function
    Public Function Check_Records(ByVal last_name As String, ByVal given_name As String, ByVal date_of_birth As Date) As Boolean

        Dim cmd As New SqlCommand
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select * from Tbl_Customer where Last_Name=@a and Given_Name=@b and Date_Of_Birth=@c"
        cmd.Parameters.Add("@a", Data.SqlDbType.VarChar, 255).Value = last_name
        cmd.Parameters.Add("@b", Data.SqlDbType.VarChar, 255).Value = given_name
        cmd.Parameters.Add("@c", Data.SqlDbType.Date).Value = date_of_birth
        cmd.ExecuteNonQuery()
        Dim adap_check As SqlDataAdapter
        adap_check = New SqlDataAdapter(cmd)
        Dim ds_check As New DataSet
        adap_check.Fill(ds_check)
        adap_check.Dispose()

        If ds_check.Tables(0).Rows.Count = 0 Then
            con.Close()
            ds_check.Dispose()
            Return True
        Else
            con.Close()
            ds_check.Dispose()
            Return False
        End If
    End Function
    Public Function getuserid(ByVal user_nm As String, ByVal pwd As String) As Integer

        Dim user_name, pwd_name As String
        user_name = user_nm
        pwd_name = pwd

        If (user_name <> "") And (pwd_name <> "") Then

            Dim cmd As New SqlCommand
            Dim str_SQL As String
            str_SQL = " SELECT sys_User.User_ID, sys_User.Branch_ID AS User_Branch_ID, sys_User.Given_Name, sys_User.Last_Name, sys_User.Logon_ID, sys_User.Password, "
            str_SQL = str_SQL & " sys_User.User_Type, sys_User.FirstTime_Login, sys_Branch.* "
            str_SQL = str_SQL & " FROM sys_Branch INNER JOIN sys_User ON sys_Branch.Branch_ID = sys_User.Branch_ID "
            str_SQL = str_SQL & " WHERE sys_User.Logon_ID= @a and sys_User.Password= @b "
            cmd.CommandText = str_SQL
            cmd.Parameters.Add("@a", SqlDbType.VarChar, 50).Value = user_name


            'Dim hashedBytes As Byte()
            ' Dim md5Hasher As New System.Security.Cryptography.MD5CryptoServiceProvider
            '  Dim encoder As New UTF8Encoding
            '  hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(pwd_name))
            'cmd.Parameters.Add("@b", SqlDbType.Binary, 50).Value = hashedBytes
            cmd.Parameters.Add("@b", SqlDbType.NVarChar, 50).Value = pwd_name
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            Dim adap As SqlDataAdapter
            adap = New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            adap.Fill(ds)
            If ds.Tables(0).Rows.Count = 0 Then
                con.Close()
                ds.Dispose()
                adap.Dispose()
                cmd.Dispose()
                getuserid = 0

            Else
                con.Close()

                adap.Dispose()
                cmd.Dispose()
                getuserid = ds.Tables(0).Rows(0).Item(0).ToString
                ds.Dispose()
            End If
        End If

    End Function
    Function check_nominate(ByVal loanid As Integer) As Boolean

        Dim cmd_nominate_id As New SqlCommand
        cmd_nominate_id.CommandText = "select Bank_Account_ID from tbl_loan where loan_id=" & loanid
        If con.State = ConnectionState.Closed Then con.Open()
        cmd_nominate_id.Connection = con
        cmd_nominate_id.ExecuteNonQuery()
        Dim adap_nominate_id As New SqlDataAdapter(cmd_nominate_id)
        Dim ds_nominate_id As New DataSet
        adap_nominate_id.Fill(ds_nominate_id)
        cmd_nominate_id.Dispose()
        adap_nominate_id.Dispose()


        If IsNumeric(ds_nominate_id.Tables(0).Rows(0).Item(0)) = 0 Then
            con.Close()
            ds_nominate_id.Dispose()
            adap_nominate_id.Dispose()
            cmd_nominate_id.Dispose()
            Return False
        Else
            con.Close()
            ds_nominate_id.Dispose()
            adap_nominate_id.Dispose()
            cmd_nominate_id.Dispose()
            Return True
        End If


    End Function
    Function check_status(ByVal loanid As Integer) As Boolean

        Dim cmd_status As New SqlCommand
        cmd_status.CommandText = "select Bank_Account_ID from tbl_loan where loan_id=" & loanid
        If con.State = ConnectionState.Closed Then con.Open()
        cmd_status.Connection = con
        cmd_status.ExecuteNonQuery()
        Dim adap_status As New SqlDataAdapter(cmd_status)
        Dim ds_status As New DataSet
        adap_status.Fill(ds_status)
        cmd_status.Dispose()
        adap_status.Dispose()
        con.Close()
        If ds_status.Tables(0).Rows.Count > 0 Then
            If IsNumeric(ds_status.Tables(0).Rows(0).Item(0)) = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
       
        'If ds_status.Tables(0).Rows.Count = 0 Then
        '    Return False
        'Else
        '    Return True
        'End If



    End Function
    Function decline_loan(ByVal loanid As Integer) As Boolean

        Dim str_dec As String
        Dim cmd_loandec As New SqlCommand
        str_dec = "Update Tbl_Loan set Tbl_Loan.Status =2, Loan_Date =@today_date WHERE Tbl_Loan.Loan_ID =" & loanid
        cmd_loandec.CommandText = str_dec
        cmd_loandec.Parameters.Add("@today_date", SqlDbType.DateTime).Value = DateTime.Now.Date
        If con.State = ConnectionState.Closed Then con.Open()
        cmd_loandec.Connection = con
        cmd_loandec.ExecuteNonQuery()
        cmd_loandec.Dispose()
        con.Close()
        Return True



    End Function
    Function calculate_loan_repay(ByVal loanid As Integer) As DataSet

        Dim cmd_loan_repay As New SqlCommand
        Dim sql_loan_repay As String
        sql_loan_repay = "SELECT Tbl_Payment.* FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description ='Cancellation fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND (Tbl_Payment.Transaction_Status ='dishonour' OR  Tbl_Payment.Transaction_Status is null ) AND Tbl_Payment.Amount <> 0 AND  Tbl_Payment.Loan_ID=@loanid AND Tbl_Payment_1.Update_ID Is Null and Tbl_Payment.payment_status is null ORDER BY  Tbl_Payment.Due_Date, Tbl_Payment.Payment_Date, Tbl_Payment.Amount "
        cmd_loan_repay.CommandText = sql_loan_repay
        If loanid <> 0 Then
            cmd_loan_repay.Parameters.Add("@loanid", SqlDbType.Int).Value = loanid
            If con.State = ConnectionState.Closed Then con.Open()
            cmd_loan_repay.Connection = con
            cmd_loan_repay.ExecuteNonQuery()
            Dim ds_loan_repay As New DataSet
            Dim adap_loan_repay As New SqlDataAdapter(cmd_loan_repay)
            adap_loan_repay.Fill(ds_loan_repay)
            If ds_loan_repay.Tables(0).Rows.Count = 0 Then
                Dim ds As New DataSet
                ds = calculate_loan_repay_show(loanid)
                con.Close()
                adap_loan_repay.Dispose()
                cmd_loan_repay.Dispose()
                Return ds
            Else
                con.Close()
                adap_loan_repay.Dispose()
                cmd_loan_repay.Dispose()
                Return ds_loan_repay
            End If

        Else
            con.Close()
            Dim ds_loan_repay As New DataSet
            Return ds_loan_repay
        End If

    End Function
    Function calculate_loan_repay_show(ByVal loanid As Integer) As DataSet

        Dim cmd_loan_repay As New SqlCommand
        Dim sql_loan_repay As String
        sql_loan_repay = "SELECT Tbl_Payment.* FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description ='Cancellation fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND (Tbl_Payment.Transaction_Status ='dishonour' OR  Tbl_Payment.Transaction_Status is null ) AND Tbl_Payment.Amount <> 0 AND  Tbl_Payment.Loan_ID=@loanid AND Tbl_Payment_1.Update_ID Is Null ORDER BY  Tbl_Payment.Due_Date, Tbl_Payment.Payment_Date, Tbl_Payment.Amount "
        cmd_loan_repay.CommandText = sql_loan_repay
        If loanid <> 0 Then
            cmd_loan_repay.Parameters.Add("@loanid", SqlDbType.Int).Value = loanid
            If con.State = ConnectionState.Closed Then con.Open()
            cmd_loan_repay.Connection = con
            cmd_loan_repay.ExecuteNonQuery()
            Dim ds_loan_repay As New DataSet
            Dim adap_loan_repay As New SqlDataAdapter(cmd_loan_repay)
            adap_loan_repay.Fill(ds_loan_repay)
            cmd_loan_repay.Dispose()
            adap_loan_repay.Dispose()
            ds_loan_repay.Dispose()
            con.Close()
            Return ds_loan_repay
        Else
            con.Close()
            Dim ds_loan_repay As New DataSet
            Return ds_loan_repay
        End If

    End Function
    Function fn_Round_to_Nearest_Five(ByVal Amount As Single) As Single

        Dim Last_Digit_of_Amount As Integer

        Last_Digit_of_Amount = Right(FormatNumber(Amount, 2), 1)

        If Last_Digit_of_Amount = 0 Or Last_Digit_of_Amount = 5 Then
            fn_Round_to_Nearest_Five = Amount

        ElseIf Last_Digit_of_Amount = 1 Or Last_Digit_of_Amount = 2 Then
            fn_Round_to_Nearest_Five = Amount - (((Last_Digit_of_Amount - 5) / 100) - 0.05)

        ElseIf (Last_Digit_of_Amount > 2 And Last_Digit_of_Amount < 5) Or Last_Digit_of_Amount = 6 Then
            fn_Round_to_Nearest_Five = Amount - ((Last_Digit_of_Amount - 5) / 100)

        ElseIf Last_Digit_of_Amount > 6 And Last_Digit_of_Amount <= 9 Then
            fn_Round_to_Nearest_Five = Amount + ((10 - Last_Digit_of_Amount) / 100)
        End If

    End Function
    Function find_bank(ByVal cust_id As Integer) As DataSet

        Dim cmd_bank As New SqlCommand
        Dim str_bank As String
        str_bank = "SELECT Tbl_Bank_Account.Customer_ID, Tbl_Bank_Account.Bank_Account_ID, Tbl_Bank_Account.Account_Name, Tbl_Bank_Account.Account_Number, Tbl_Bank_Account.Bank_Name, Tbl_Bank_Account.Bank_Address, Tbl_Bank_Account.Bank_Suburb, Tbl_Bank_Account.Bank_State, Tbl_Bank_Account.Bank_Post_Code, Tbl_Bank_Account.BSB FROM Tbl_Customer INNER JOIN Tbl_Bank_Account ON Tbl_Customer.Customer_ID = Tbl_Bank_Account.Customer_ID WHERE Tbl_Bank_Account.Customer_ID = " & cust_id
        If con.State = ConnectionState.Closed Then con.Open()
        cmd_bank.Connection = con
        cmd_bank.CommandText = str_bank
        cmd_bank.ExecuteNonQuery()
        Dim adap_bank As SqlDataAdapter
        adap_bank = New SqlDataAdapter(cmd_bank)
        Dim ds_bank As New DataSet
        adap_bank.Fill(ds_bank)
        adap_bank.Dispose()
        cmd_bank.Dispose()
        con.Close()
        Return ds_bank
    End Function
    Function outstanding_amt(ByVal loanid As Integer) As Double
        Dim cmd_outstanding_amt As New SqlCommand
        Dim adap_outstanding_amt As SqlDataAdapter
        Dim ds_outstanding_amt As New DataSet
        cmd_outstanding_amt.CommandText = "SELECT  round(Sum(Tbl_Payment.Amount),2) FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID WHERE (Tbl_Payment.Description = 'Arear notice fee' OR Tbl_Payment.Description = 'Statement of account fee' OR Tbl_Payment.Description = 'Variation fee' OR Tbl_Payment.Description = 'Default notice fee' OR Tbl_Payment.Description = 'Letter of demand fee' OR Tbl_Payment.Description = 'Dishonoured fee' OR Tbl_Payment.Description = 'Cancellation fee' OR Tbl_Payment.Description = 'Enforcement fee' OR Tbl_Payment.Description is NULL OR Tbl_Payment.Description = '') AND Tbl_Payment.Transaction_Status is NULL AND Tbl_Payment.Payment_Date is NULL AND Tbl_Payment.Payment_Status is NULL AND Tbl_Payment.Loan_ID=" & loanid & "AND Tbl_Payment_1.Update_ID Is Null "
        If con.State = ConnectionState.Closed Then con.Open()
        cmd_outstanding_amt.Connection = con
        cmd_outstanding_amt.ExecuteNonQuery()
        adap_outstanding_amt = New SqlDataAdapter(cmd_outstanding_amt)
        adap_outstanding_amt.Fill(ds_outstanding_amt)
        Dim amtout As Double
        If Convert.ToString(ds_outstanding_amt.Tables(0).Rows(0).Item(0)) = "" Then
            amtout = 0.0
        Else
            amtout = ds_outstanding_amt.Tables(0).Rows(0).Item(0)

        End If
        cmd_outstanding_amt.Dispose()
        adap_outstanding_amt.Dispose()
        ds_outstanding_amt.Dispose()
        con.Close()
        Return amtout
       
    End Function
    Function amount_settled(ByVal loanid As Integer) As Double
        Dim cmd_settled As New SqlCommand
        Dim adap_settled As SqlDataAdapter
        Dim ds_settled As New DataSet
        cmd_settled.CommandText = "SELECT  round(Sum(Tbl_Payment.Amount),2) AS Amount_Settled FROM Tbl_Payment LEFT JOIN Tbl_Payment AS Tbl_Payment_1 ON Tbl_Payment.Payment_ID=Tbl_Payment_1.Update_ID WHERE(Tbl_Payment.Transaction_Status Is NULL And Tbl_Payment.Payment_Status Is Not NULL And Tbl_Payment.Loan_ID =" & loanid & " And Tbl_Payment_1.Update_ID Is Null)"
        If con.State = ConnectionState.Closed Then con.Open()
        cmd_settled.Connection = con
        cmd_settled.ExecuteNonQuery()
        adap_settled = New SqlDataAdapter(cmd_settled)
        adap_settled.Fill(ds_settled)
        Dim amtpaid As Double
        If ds_settled.Tables(0).Rows(0).Item(0).ToString = "" Then
            amtpaid = 0

        Else
            amtpaid = ds_settled.Tables(0).Rows(0).Item(0)

        End If
        con.Close()
        cmd_settled.Dispose()
        adap_settled.Dispose()
        ds_settled.Dispose()
        Return amtpaid

       
    End Function
    Function fn_Set_Data(ByVal str_Data As String, ByVal int_Length As Integer, ByVal str_side As String, ByVal str_item As String) As String

        Dim int_index As Integer
        str_Data = str_Data & ""
        int_index = Len(str_Data)

        If Len(str_Data) > int_Length Then
            fn_Set_Data = Left(str_Data, int_Length)
        ElseIf Len(str_Data) < int_Length Then
            Do While int_index < int_Length
                If str_side = "right" Then
                    str_Data = str_Data & str_item
                Else
                    str_Data = str_item & str_Data
                End If
                int_index = int_index + 1
            Loop
            fn_Set_Data = str_Data
        Else
            fn_Set_Data = str_Data
        End If

    End Function
    Function check_month(ByVal month_new As String) As String
        Dim month_loan As String
        month_loan = Val(month_new)
        If month_loan = "1" Then
            month_loan = "January"
        ElseIf month_loan = "2" Then
            month_loan = "February"
        ElseIf month_loan = "3" Then
            month_loan = "March"
        ElseIf month_loan = "4" Then
            month_loan = "April"
        ElseIf month_loan = "5" Then
            month_loan = "May"
        ElseIf month_loan = "6" Then
            month_loan = "June"
        ElseIf month_loan = "7" Then
            month_loan = "July"
        ElseIf month_loan = "8" Then
            month_loan = "August"
        ElseIf month_loan = "9" Then
            month_loan = "September"
        ElseIf month_loan = "10" Then
            month_loan = "October"
        ElseIf month_loan = "11" Then
            month_loan = "November"
        ElseIf month_loan = "12" Then
            month_loan = "December"
        End If
        Return month_loan

    End Function
    Function check_day_name(ByVal day_name_new As String) As String
        Dim day_name As String
        day_name = day_name_new
        If day_name = "0" Then
            day_name = "Sun"
        ElseIf day_name = "1" Then
            day_name = "Mon"
        ElseIf day_name = "2" Then
            day_name = "Tue"
        ElseIf day_name = "3" Then
            day_name = "Wed"
        ElseIf day_name = "4" Then
            day_name = "Thu"
        ElseIf day_name = "5" Then
            day_name = "Fri"
        ElseIf day_name = "6" Then
            day_name = "Sat"
      
        End If
        Return day_name

    End Function
    Function check_day(ByVal day_new As String) As String
        Dim sup_string As String
        Dim day_loan As Integer
        day_loan = Val(day_new)

        If day_loan = 1 Then
            sup_string = "<sup>st</sup>"
        ElseIf day_loan = 21 Then
            sup_string = "<sup>st</sup>"
        ElseIf day_loan = 31 Then
            sup_string = "<sup>st</sup>"
        ElseIf day_loan = 2 Then
            sup_string = "<sup>nd</sup>"
        ElseIf day_loan = 22 Then
            sup_string = "<sup>nd</sup>"
        ElseIf day_loan = 3 Then
            sup_string = "<sup>rd</sup>"
        ElseIf day_loan = 23 Then
            sup_string = "<sup>rd</sup>"
        Else
            sup_string = "<sup>th</sup>"
        End If
        Return sup_string
    End Function
    Function check_day_new(ByVal day_new As String) As String
        Dim sup_string As String
        Dim day_loan As Integer
        day_loan = Val(day_new)

        If day_loan = 1 Then
            sup_string = "st"
        ElseIf day_loan = 21 Then
            sup_string = "st"
        ElseIf day_loan = 31 Then
            sup_string = "st"
        ElseIf day_loan = 2 Then
            sup_string = "nd"
        ElseIf day_loan = 22 Then
            sup_string = "nd"
        ElseIf day_loan = 3 Then
            sup_string = "rd"
        ElseIf day_loan = 23 Then
            sup_string = "rd"
        Else
            sup_string = "th"
        End If
        Return sup_string
    End Function
    Function cal_short_month(ByVal short_month As String) As String

        If short_month = "1" Then
            short_month = "Jan"
        ElseIf short_month = "2" Then
            short_month = "Feb"
        ElseIf short_month = "3" Then
            short_month = "Mar"
        ElseIf short_month = "4" Then
            short_month = "Apr"
        ElseIf short_month = "5" Then
            short_month = "May"
        ElseIf short_month = "6" Then
            short_month = "Jun"
        ElseIf short_month = "7" Then
            short_month = "Jul"
        ElseIf short_month = "8" Then
            short_month = "Aug"
        ElseIf short_month = "9" Then
            short_month = "Sep"
        ElseIf short_month = "10" Then
            short_month = "Oct"
        ElseIf short_month = "11" Then
            short_month = "Nov"
        ElseIf short_month = "12" Then
            short_month = "Dec"
        End If
        Return short_month
    End Function

    Function cal_short_month_new(ByVal short_month As String) As String

        If short_month = "01" Then
            short_month = "Jan"
        ElseIf short_month = "02" Then
            short_month = "Feb"
        ElseIf short_month = "03" Then
            short_month = "Mar"
        ElseIf short_month = "04" Then
            short_month = "Apr"
        ElseIf short_month = "05" Then
            short_month = "May"
        ElseIf short_month = "06" Then
            short_month = "Jun"
        ElseIf short_month = "07" Then
            short_month = "Jul"
        ElseIf short_month = "08" Then
            short_month = "Aug"
        ElseIf short_month = "09" Then
            short_month = "Sep"
        ElseIf short_month = "10" Then
            short_month = "Oct"
        ElseIf short_month = "11" Then
            short_month = "Nov"
        ElseIf short_month = "12" Then
            short_month = "Dec"
        End If
        Return short_month
    End Function
    Function check_amount_format(ByVal amt As String) As String
        Dim pos As Integer
        pos = InStr(1, amt, ".")
        If pos = 0 Then
            amt = amt & ".00"
        Else
            amt = amt
        End If
        Return amt
    End Function
    Function FormatID(ByVal ID As Integer, ByVal Int_Format As Integer) As String
        Dim format_id As String
        If Int_Format > 0 And Int_Format < 5 And ID <> 0 Then

            If ID < 10 Then
                format_id = "000" & ID
                Return format_id
            ElseIf ID < 100 And ID > 9 Then
                format_id = "00" & ID
                Return format_id
            ElseIf ID < 1000 And ID > 99 Then
                format_id = "0" & ID
                Return format_id
            Else
                format_id = ID
                Return format_id
            End If

        Else
            Return ID
        End If
    End Function
    Function new_amount(ByVal amt As Double) As String
        Dim pos_amt As Integer
        pos_amt = InStr(1, CStr(amt), ".")
        If pos_amt = 0 Then
            Return ("$" & amt & ".00")
        Else
            If Len(Mid(amt, pos_amt + 1)) = 1 Then
                Return ("$" & amt & "0")
            Else
                Return ("$" & amt)
            End If
        End If
    End Function
 
    Function newamount(ByVal amt As Double) As String
        Dim pos_amt As Integer
        pos_amt = InStr(1, CStr(amt), ".")
        If pos_amt = 0 Then
            Return (amt & ".00")
        Else
            If Len(Mid(amt, pos_amt + 1)) = 1 Then
                Return (amt & "0")
            Else
                Return (amt)
            End If
        End If
    End Function
    Private user_id As Integer
    Public Property user_id_val() As Integer
        Get
            user_id = HttpContext.Current.Session("user_id")
            Return user_id
        End Get
        Set(ByVal Value As Integer)
            HttpContext.Current.Session("user_id") = Value
        End Set
    End Property


    Private customer_id As Integer
    Public Property customer_id_val() As Integer
        Get
            customer_id = HttpContext.Current.Session("customer_id")
            Return customer_id
        End Get
        Set(ByVal Value As Integer)
            HttpContext.Current.Session("customer_id") = Value
        End Set
    End Property

    Private branch_id As Integer
    Public Property branch_id_val() As Integer
        Get
            branch_id = HttpContext.Current.Session("branch_id")
            Return branch_id
        End Get
        Set(ByVal Value As Integer)
            HttpContext.Current.Session("branch_id") = 26
        End Set
    End Property

    Private loan_id As Integer
    Public Property loan_id_val() As Integer
        Get
            loan_id = HttpContext.Current.Session("loan_id")
            Return loan_id
        End Get
        Set(ByVal Value As Integer)
            HttpContext.Current.Session("loan_id") = Value
        End Set
    End Property
    Function calculate_cent(ByVal int_Value As Integer, ByVal int_sum As Integer) As String
        If int_Value <> 0 And int_sum <> 0 Then
            calculate_cent = Math.Round((int_Value / int_sum) * 100, 2) & " %"

        Else
            calculate_cent = 0

        End If
        Return calculate_cent
    End Function

    'Public Function GetIP4Address() As String

    '    Dim ASCII As New System.Text.ASCIIEncoding()
    '    Dim heserver As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
    '    Dim curAdd As IPAddress
    '    For Each curAdd In heserver.AddressList


    '        If curAdd.AddressFamily.ToString() = "InterNetwork" Then
    '            sys_ip = curAdd.ToString()

    '        End If

    '    Next curAdd
    '    Return sys_ip
    'End Function
    Public Function GetIP4Address() As String
        'Dim ip As String
        'Dim h As System.Net.IPHostEntry = Nothing
        'h = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        'ip = h.AddressList.GetValue(0).ToString
        'Return ip
        Dim str As String = ""
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current()
        Dim sIPAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(sIPAddress) Then
            str = context.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = sIPAddress.Split(New [Char]() {","c})
            str = ipArray(0)
        End If
        Return str
    End Function

   
End Class
