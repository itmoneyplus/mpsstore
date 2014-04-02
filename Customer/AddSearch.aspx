<%@ Page EnableEventValidation="false" Culture="en-AU" Language="VB" AutoEventWireup="false"
    CodeFile="AddSearch.aspx.vb" Inherits="Customer_AddSearch" %>

<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Search</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../css/menu.css" />

    <script language="JavaScript" type="text/javascript">
    javascript: window.history.forward(1);
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
       <%-- <tool1:Toolbaar1 ID="tool_first" runat="server" />--%>
       <div id="title" 
                style="padding: 0px; margin: 0px; position: absolute; float: left; top: 0px; left: 0px;">
                <asp:Label ID="lblTitle" runat="server" Text="Money Plus" CssClass="menu_left"></asp:Label>  
                <a class="menu_right" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                       [Logout]</a>  
                <asp:LinkButton ID="LinkButton_back" runat="server" CssClass="menu_right" TabIndex="8">[Back]</asp:LinkButton>        
            </div>
            <%-- <table id="toolbar_table" cellspacing="0" class="table_toolbaar">
                    <tr class="toolbaar1_tr">
                        <td class="toolbaar1_td">
                            <asp:LinkButton ID="Link_Home" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Default.aspx"
                                TabIndex="1">Home</asp:LinkButton>
                            <asp:Label ID="Label1" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Customer" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/AddSearch.aspx"
                                TabIndex="2">Customer</asp:LinkButton>
                            <asp:Label ID="Label2" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Cash" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File.aspx"
                                TabIndex="3">Cash Movements</asp:LinkButton>
                            <asp:Label ID="Label3" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Reports" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Tab_report.aspx"
                                TabIndex="4">Reports</asp:LinkButton>
                            <asp:Label ID="Label4" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Marketing" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Tab_Marketing.aspx"
                                TabIndex="5">Marketing</asp:LinkButton>
                            <asp:Label ID="Label5" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Audit" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Online_Joined.aspx"
                                TabIndex="6">Online Joined</asp:LinkButton>
                            <asp:Label ID="Label6" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Administration" runat="server" CssClass="toolbaar1_link"
                                TabIndex="7">Administration</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton8" runat="server" CssClass="toolbaar1_link" TabIndex="8">[Back]</asp:LinkButton>
                        </td>
                        <td class="toolbaar1_td_right">
                            <a class="toolbaar1_link" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                                [Logout]</a>
                        </td>
                    </tr>
                </table>--%>
                <ul id="menu" 
                style="padding: 0px; margin: 24px; position: absolute; top: 8px; left: -24px;">
                    <li>
                        <asp:LinkButton ID="Link_Home" runat="server" CssClass="toolbaar1_link"   PostBackUrl="~/Customer/Default.aspx"
                            TabIndex="1">Home</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Customer" runat="server" Font-Bold="True"  ForeColor="#2E95C9"  PostBackUrl="~/Customer/AddSearch.aspx"
                            TabIndex="2">Customer</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Cash" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File_NAB.aspx"
                            TabIndex="3">Cash Movements</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Reports" runat="server" CssClass="toolbaar1_link"   PostBackUrl="~/Customer/Financial_Reports.aspx"
                            TabIndex="4">Reports</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Marketing" runat="server"   CssClass="toolbaar1_link"  PostBackUrl="~/Customer/Marketing_Report.aspx"
                            TabIndex="5">Marketing</asp:LinkButton>
                    </li>
                    <%--<li>
                        <asp:LinkButton ID="Link_Audit" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Online_Joined.aspx"
                            TabIndex="6">Online Joined</asp:LinkButton>
                    </li>--%>
                    <li>
                        <asp:LinkButton ID="Link_Administration" runat="server" CssClass="toolbaar1_link"    PostBackUrl="~/Customer/CreateUser.aspx"
                            TabIndex="7">Administration</asp:LinkButton>
                   </li>
                   <%--<li class="menu_right"><a class="toolbaar1_link" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                       <b> [Logout]</b></a></li>
                    <li class="menu_right">
                        <asp:LinkButton ID="LinkButton8" runat="server" CssClass="toolbaar1_link" TabIndex="8">[Back]</asp:LinkButton></li>--%>           
                </ul>
        <table class="table" align="center">
            <tr>
                <td>
                    <asp:TextBox ID="txtsearch" runat="server" TabIndex="8" Style="width: 120px"></asp:TextBox>
                    <asp:Button ID="btnsearch" runat="server" Text="Search" TabIndex="9" Style="width: 60px;
                        height: 25px" />
                    <asp:Label runat="server" ID="label1">|</asp:Label>
                    <asp:LinkButton runat="server" ID="LinkButton1" Text="Add Customer" CssClass="link_text"
                        TabIndex="10"></asp:LinkButton>
                    <asp:Label runat="server" ID="label2">|</asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <asp:Label ID="Label3" runat="server" CssClass="declined_label_text" Text="Customer Search Result"
        Visible="False"></asp:Label>
    <br />
    <br />   
     <asp:GridView ID="GridView1" runat="server" 
    AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Size="14px" 
    ForeColor="Black" RowHeaderColumn="Customer Id" Width="95%" 
    CellSpacing="2"  style="margin-left:30px; margin-top: 20px" >
       <RowStyle BackColor="White" HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
        <Columns>
            <asp:BoundField DataField="Customer_ID" HeaderText="Customer ID"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
            <asp:BoundField DataField="Given_Name" HeaderText="Given Name"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
            <asp:BoundField DataField="Last_Name" HeaderText="Last Name"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
            <asp:BoundField DataField="Date_Of_Birth" HeaderText="Date Of Birth" SortExpression="Date Of Birth"
                DataFormatString="{0:d-MMM-yyyy}" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
            <asp:BoundField DataField="Request_Amount" HeaderText="Request Amount" DataFormatString="{0:c}"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
            <asp:BoundField DataField="Date_Joined" HeaderText="Date Joined" SortExpression="Date Joined"
                DataFormatString="{0:d}" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
            <asp:BoundField DataField="Time_Joined" HeaderText="Time_Joined" SortExpression="Time_Joined"
                DataFormatString="{0:hh:mm tt}" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        </Columns>
    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="black" HorizontalAlign="Center" VerticalAlign="Middle" />
    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
    </asp:GridView>      
    </form>
</body>
</html>
