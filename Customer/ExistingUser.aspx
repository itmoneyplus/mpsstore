﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ExistingUser.aspx.vb" Inherits="Customer_ExistingUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Existing User</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../css/menu.css" />
      <style type="text/css">
        #form1
        {
            margin-left: 80px;
        }
        .style1
        {
            width: 137px;            
            padding-left:23px;
           
            border:1px solid gray;
            vertical-align :top;            
            border-right-style:none;
        }
        .style3
        {
            width: 163px;
        }
        .style4
        {
            height: 66px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
            <%--<tool1:Toolbaar1 ID="Toolbaar1" runat="server" />--%>
            <div id="title" style="padding: 0px; margin: 0px; position: absolute; float: left;
                top: 0px; left: 0px;">
                <asp:Label ID="lblTitle" runat="server" Text="Money Plus" CssClass="menu_left"></asp:Label>
                <a class="menu_right" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                    [Logout]</a>
                <asp:LinkButton ID="LinkButton_back" runat="server" CssClass="menu_right" TabIndex="8">[Back]</asp:LinkButton>
            </div>
            <ul id="menu" style="padding: 0px; margin: 24px; position: absolute; top: 8px; left: -24px;">
                <li>
                        <asp:LinkButton ID="Link_Home" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Default.aspx"
                            TabIndex="1">Home</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Customer" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/AddSearch.aspx"
                            TabIndex="2">Customer</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Cash" runat="server"   CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File_NAB.aspx"
                            TabIndex="3">Cash Movements</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Reports" runat="server"  CssClass="toolbaar1_link"   PostBackUrl="~/Customer/Financial_Reports.aspx"
                            TabIndex="4">Reports</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Marketing" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Marketing_Report.aspx"
                            TabIndex="5">Marketing</asp:LinkButton>
                    </li>
                   <%-- <li>
                        <asp:LinkButton ID="Link_Audit" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Online_Joined.aspx"
                            TabIndex="6">Online Joined</asp:LinkButton>
                    </li>--%>
                    <li>
                        <asp:LinkButton ID="Link_Administration" runat="server" Font-Bold="True" 
                                ForeColor="#2E95C9"    PostBackUrl="~/Customer/CreateUser.aspx"
                            TabIndex="7">Administration</asp:LinkButton>
                    </li>
            </ul>
            <br />
            <br />
        </div>
    <asp:Panel ID="Panel1" runat="server">
            <table id="toolbarMarketing_table" cellspacing="0" class="toolbartellareport_table"
                cellpadding="0">
                <tr>
                    <td align="left">
                        <ul id="navbarMarketing">
                            <li>
                                <asp:LinkButton ID="Link_admin" runat="server" Font-Bold="True" ForeColor="#2E95C9"
                                    PostBackUrl="" TabIndex="1">Admin</asp:LinkButton>
                            </li>
                            <li>
                              <asp:LinkButton ID="Link_fees_charges" runat="server"  PostBackUrl="~/Fees_And_Charges/Fees_And_Charges.aspx"
                                            TabIndex="2"  >Fees & Charges</asp:LinkButton>
                               
                            </li>
                            <li>
                              <asp:LinkButton ID="Link_calculators" runat="server"   PostBackUrl="~/Calculators/Calc_detail.aspx"
                                            TabIndex="3"  >Calculators</asp:LinkButton>
                               
                            </li>
                        </ul>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="98%">
                <tr>
                    <td class="style1">
                        <table cellpadding="0" cellspacing="0" border="0" class="toolbar_table">
                            <tr runat="server" id="trreportAdmin" visible="true">
                                <td class="style3">
                                    <table cellpadding="0" cellspacing="0" border="0" class="toolbar_table">
                                        <tr class="toolbaar1_tr" style="display:none;">
                                            <td class="toolbaar1_td_rep">
                                                <asp:LinkButton ID="Link_creditdue" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/login_track_report.aspx"
                                                    TabIndex="1">Login Report</asp:LinkButton>
                                            </td>
                                        </tr>
                                       
                                        <tr class="toolbaar1_tr">
                                            <td class="toolbaar1_td_rep">
                                                <asp:LinkButton ID="lnkChangePassword" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/ChangePassword.aspx"
                                                    TabIndex="2">Change Password</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr class="toolbaar1_tr">
                                            <td class="toolbaar1_td_rep">
                                                <asp:LinkButton ID="lnkCreateUser" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/CreateUser.aspx"
                                                    TabIndex="2">Create User</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr class="toolbaar1_tr">
                                            <td class="toolbaar1_td_rep">
                                                <asp:LinkButton ID="LinkButtonExistUser" runat="server" CssClass="toolbaar1_link_active" PostBackUrl="~/Customer/ExistingUser.aspx"
                                                    TabIndex="2">Existing User</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="border: 1px solid gray; width: 82%; vertical-align: top">
                        <div align="left">
                            <br />
                            <table align="left" class="w100">
                                <tr>
                                    <td colspan="3" valign="top" > <span>click on <img alt="edit" src="../Images/edit.gif"  /> to edit or click on <img alt="delete" src="../Images/Delete.gif" /> to delete  </span> </td>
                                </tr>
                                <tr>
                                    <td colspan="3" valign="top">
                                        <asp:Panel ID="pnlExistingUser" runat="server" Width="750px">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdExistingUser" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                                            CellPadding="4" Font-Size="14px"
                                                            ForeColor="Black" Width="100%" CellSpacing="2" Style="margin-top: 20px" 
                                                            ShowFooter="True">
                                                            <RowStyle BackColor="White" HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid"
                                                                BorderWidth="1px" />
                                                            <Columns>                                                                
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="~/Images/Delete.gif" ImageAlign="Middle"
                                                                            AlternateText="Delete" OnClientClick="if (!confirm('Are you sure you want delete?')) return false;" CommandArgument='<%#Eval("User_ID") %>' CommandName="deleteUser" />
                                                                            <asp:Label runat="server" ID="lblCustID" Text ='<%#Eval("User_ID") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton runat="server" ID="btnEdit" ImageUrl="~/Images/edit.gif" ImageAlign="Middle"
                                                                            AlternateText="Delete" CommandArgument='<%#Eval("User_ID") %>' CommandName="editUser" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Given_Name" HeaderText="Given Name">
                                                                    <%--<HeaderStyle Width="80px" />--%>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Last_name" HeaderText="Last Name">
                                                                    <%--<HeaderStyle Width="150px" />--%>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Trading_Name" HeaderText="Branch"  >
                                                                </asp:BoundField>
                                                                 <asp:BoundField DataField="Suburb" HeaderText="Suburb"  >
                                                                </asp:BoundField>
                                                                 <asp:BoundField DataField="State" HeaderText="State"  >
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="User_Type" HeaderText="User Type">
                                                                    <%--<HeaderStyle Width="80px" />--%>
                                                                </asp:BoundField>
                                                               
                                                            </Columns>
                                                            <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" BorderColor="#999999"
                                                                BorderStyle="Solid" BorderWidth="1px" />
                                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                                VerticalAlign="Middle" />
                                                            <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="black" HorizontalAlign="Center"
                                                                VerticalAlign="Middle" />
                                                            <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>                                                                                                                                                                                                                                                                                            
                                            </table>
                                        </asp:Panel>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: center;">
                                    <asp:Panel ID="pnlEditUser" runat="server" Width="750px">
                                    
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:HiddenField ID="hdnUserID" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:150px; padding-bottom:20px;">&nbsp;&nbsp;
                                                       <img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                                            height="10" />
                                                        <asp:Label ID="lblGivenName" Text="Given Name:" runat="server" CssClass="label_style"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtGivenName" runat="server" Style="width: 130px; margin-bottom:20px;"></asp:TextBox>
                                                    </td>
                                                    <td style="width:150px; padding-bottom:20px;">&nbsp;
                                                   <img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                                            height="10" />
                                                        <asp:Label ID="lblLastName" runat="server" Text="Last Name:" CssClass="label_style"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtLastName" runat="server" Style="width: 130px; margin-bottom:20px;"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                <td style="width:150px; padding-bottom:20px;">&nbsp;&nbsp;
                                               <img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                                            height="10" />
                                                    <asp:Label ID="lblLoginName" runat="server" Text="Login Name:" CssClass="label_style"></asp:Label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtLoginName" runat="server" Style="width: 130px; margin-bottom:20px;"></asp:TextBox></td>
                                                    <td style="width:150px; padding-bottom:20px;">
                                                        <img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                                            height="10" />
                                                        <asp:Label ID="lblPassword" runat="server" Text="Password:" 
                                                            CssClass="label_style"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Style="width: 130px; margin-bottom:20px;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="float:left;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                                            height="10" />
                                                        <asp:Label ID="lblBranch" runat="server" Text="Branch:" CssClass="label_style"></asp:Label>
                                                    </td>
                                                    <td  > 
                                                       <asp:DropDownList ID="ddlBranch" runat="server" CssClass="dllbranch">
                                                        
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td >
                                                        &nbsp;<img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10" height="10" />
                                                        <asp:Label ID="lblUserType" runat="server" Text="User Type:" CssClass="label_style"></asp:Label>
                                                    </td>
                                                    
                                                    <td style="float:left;">
                                                        &nbsp;&nbsp;
                                                        <asp:DropDownList ID="ddlUserType" runat="server"  >
                                                        <asp:ListItem Text="Teller" Value="1" />
                                                        <asp:ListItem Text="Manager" Value="2" />
                                                        <asp:ListItem Text="Admin" Value="3" />
                                                        </asp:DropDownList>
                                                    </td>                                                   
                                                </tr>
                                                <tr>
                                                    <td>
                                                        </td>
                                                    <td  class="style4">
                                                        <asp:Button ID="btnGoBack" runat="server" Text="Go Back" CssClass="btn_back"  /> &nbsp; <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" />
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>                                                                                              
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
