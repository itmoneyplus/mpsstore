<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Money_Gram.aspx.vb" Inherits="Money_Gram" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reports Statistics</title>
 <%--   CSS used--%>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../css/menu.css" />
     <script language="JavaScript" type="text/javascript" >
             javascript: window.history.forward(1);
    </script>
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
            <%--<tool1:Toolbaar1 ID="tool1" runat="server" />--%>
            <div id="title" 
                style="padding: 0px; margin: 0px; position: absolute; float: left; top: 0px; left: 0px;">
                <asp:Label ID="lblTitle" runat="server" Text="Money Plus" CssClass="menu_left"></asp:Label>  
                <a class="menu_right" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                       [Logout]</a>  
                <asp:LinkButton ID="LinkButton_back" runat="server" CssClass="menu_right" TabIndex="8">[Back]</asp:LinkButton>        
            </div>
           
                <ul id="menu" 
                style="padding: 0px; margin: 24px; position: absolute; top: 8px; left: -24px;">
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
                        <asp:LinkButton ID="LinkButton4" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Marketing_Report.aspx"
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
        
        <asp:Panel ID="Panel3" runat="server">
    <table id="toolbarMarketing_table" cellspacing="0" class="toolbartellareport_table" 
        cellpadding="0">
        <tr>
            <td align="left">
                <ul id="navbarMarketing">
                   <li>
                                <asp:LinkButton ID="Link_admin" runat="server" 
                                    PostBackUrl="~/Customer/CreateUser.aspx" TabIndex="1">Admin</asp:LinkButton>
                            </li>
                    <li>
                      <asp:LinkButton ID="Link_fees_charges" runat="server" Font-Bold="True" ForeColor="#2E95C9"  PostBackUrl="~/Fees_And_Charges/Fees_And_Charges.aspx"
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
   
    <table cellspacing="0" cellpadding="0" width="98%"  >
    <tr>
    <td class="style1" >
            <table cellpadding="0" cellspacing="0" border="0" class="toolbar_table">
                
                <tr runat="server" id="trreportAdmin" visible="true">
                    <td class="style3">
                        <table cellpadding="0" cellspacing="0" border="0" class="toolbar_table">
                        
                             <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                     <asp:LinkButton ID="Link_loan" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Fees_And_Charges/Loan.aspx"
                                TabIndex="1">Loan</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                     <asp:LinkButton ID="Link_loc" runat="server" CssClass="toolbaar1_link" 
                                PostBackUrl="~/Fees_And_Charges/LOC.aspx" TabIndex="2">LOC</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                     <asp:LinkButton ID="Link_draw_down" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Fees_And_Charges/Draw_down.aspx"
                                TabIndex="3">Draw down</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                      <asp:LinkButton ID="Link_Money_Gram" runat="server"  CssClass="toolbaar1_link_active"  PostBackUrl="~/Fees_And_Charges/Money_Gram.aspx"
                                TabIndex="4">Money Gram</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            
                            
                        </table>
                    </td>
                </tr>
            </table>
            
    </td> 
    <td style="border:1px solid gray; width:82%;vertical-align :top">
             <div align="left">
                 <br />
                    <table align="left" class="w100">
                                <tr>
                                    <td colspan="3" valign="top">
                                        <asp:Label ID="LabelResult" Font-Bold="true" runat="server" Text="No Record of Result !" Visible="false"></asp:Label>
                                    </td>
                                </tr>                               
                                <tr>
                                    <td colspan="3" valign="top">
                                        <asp:Panel ID="pnl" runat="server" Width="750px">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                                            CellPadding="4" Font-Size="14px"
                                                            ForeColor="Black" Width="100%" CellSpacing="2" Style="margin-top: 20px" 
                                                            ShowFooter="True">
                                                            <RowStyle BackColor="White" HorizontalAlign="Right" BorderColor="#999999" BorderStyle="Solid"
                                                                BorderWidth="1px" />
                                                            <Columns>                                                                
                                                                
                                                                <asp:BoundField DataField="From" HeaderText="From" DataFormatString="{0:C0}">
                                                                    <%--<HeaderStyle Width="80px" />--%>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="To" HeaderText="To" DataFormatString="{0:C0}">
                                                                    <%--<HeaderStyle Width="150px" />--%>
                                                                </asp:BoundField>
                                                                
                                                                <asp:BoundField DataField="Fee" HeaderText="Fee" DataFormatString="{0:C0}">
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
