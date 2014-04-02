Imports System.Data.SqlClient
Imports System
Imports System.Data
Partial Class Common_Files_Address_Look_Up
    Inherits System.Web.UI.Page
    Dim open_con As New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_name") = "" Then
            Response.Redirect("https://moneyplus.com.au/application/login.aspx")
        Else
            binddata_Grid()
        End If

    End Sub
    Protected Sub binddata_Grid()
        Try
            Dim subr As String
            Dim cmd As New SqlCommand
            Dim str_SQL As String
            subr = Request.QueryString("Name")
            If subr = "" Then
                str_SQL = "Select * from sys_Post_Code order by suburb"
            Else
                str_SQL = "Select * from sys_Post_Code  where suburb like '" & subr & "%'"
            End If
            cmd.Connection = open_con.return_con
            cmd.CommandText = str_SQL
            cmd.ExecuteNonQuery()
            Dim adap As SqlDataAdapter
            adap = New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            adap.Fill(ds)
            GridView1.DataSource = ds
            GridView1.DataBind()
            open_con.return_con.Dispose()
            cmd.Dispose()
            adap.Dispose()
            ds.Dispose()
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Dim row_index As Integer
        row_index = GridView1.SelectedRow.RowIndex
        Dim strScript = "<script>window.opener.document.forms['form1'].elements['txtsub_new'].value" + " = '" + GridView1.Rows(row_index).Cells.Item(1).Text + "';"
        strScript += "window.opener.document.forms['form1'].elements['txtpstcode_new'].value" + " = '" + GridView1.Rows(row_index).Cells.Item(0).Text + "'; "
        strScript += "self.close()"
        strScript += "</" + "script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "abcd", strScript)

    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes("onmouseover") = "this.style.hiscursor='hand';this.style.textDecoration='underline';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFBD6'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            e.Row.Attributes.Add("ondblClick", Me.Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex))

        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        binddata_Grid()
    End Sub
    Protected Overrides Sub Finalize()
        open_con = Nothing
        System.GC.Collect()
    End Sub
End Class
