<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login_track_report.aspx.vb"
    Inherits="Customer_login_track_report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>
<%@ Register Src="~/toolbaar/Reports_tab_periodic.ascx" TagName="Toolbaar_Rep1" TagPrefix="tool_rep1" %>
<%@ Register src="../toolbaar/tool_report.ascx" tagname="tool_report" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
    <title>Login Track Report</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
    <link rel="stylesheet" type="text/css" href="../css/menu.css" />

    <script language="javascript" type="text/javascript">
        function showDate(sender, args) {
            if (sender._textbox.get_element().value == "") {
                var todayDate = new Date();
                sender._selectedDate = todayDate;
            }
        }
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
            /*width: 163px;*/
            width: 203px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="align">
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
                        <asp:LinkButton ID="Link_Reports" runat="server" Font-Bold="True" 
                                ForeColor="#2E95C9"   PostBackUrl="~/Customer/Financial_Reports.aspx"
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
                        <asp:LinkButton ID="Link_Administration" runat="server" CssClass="toolbaar1_link"   PostBackUrl="~/Customer/CreateUser.aspx"
                            TabIndex="7">Administration</asp:LinkButton>
                    </li>
                            
                </ul>
        <br />
        <br />
        
        <asp:Panel ID="Panel1" runat="server">
    <table id="toolbarMarketing_table" cellspacing="0" class="toolbartellareport_table" 
        cellpadding="0">
        <tr>
            <td align="left">
                <ul id="navbarMarketing">
                    <li>
                    
                        <asp:LinkButton ID="Link_Financial" runat="server"  TabIndex="1"  PostBackUrl="~/Customer/Financial_Reports.aspx">Financial Reports</asp:LinkButton>
                        
                    </li>
                    <li>
                    
                      <asp:LinkButton ID="Link_Periodic" runat="server" Font-Bold="True" 
                            ForeColor="#2E95C9" TabIndex="2" PostBackUrl="~/Customer/Periodic_Reports.aspx">Periodic Reports</asp:LinkButton>
                       
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
                                   <asp:LinkButton ID="LinkButton2" runat="server" CssClass="toolbaar1_link"  PostBackUrl="~/Reports/report_journal.aspx"
                            TabIndex="1">Financial Status</asp:LinkButton>
                                </td>
                            </tr>
                           <%-- <tr >
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_cheque_cashed.aspx"
                                        TabIndex="4">Cheque Cashed</asp:LinkButton>
                                </td>
                            </tr>--%>
                           <%-- <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton4" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_cheque_dishonoured.aspx"
                                        TabIndex="6">Dishonoured Cheques</asp:LinkButton>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="toolbaar1_link" PostBackUrl="~/Customer/Perodic_Report.aspx"
                            TabIndex="2">Periodic Report</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr"  style="display:none;">
                                            <td class="toolbaar1_td_rep">
                                                <asp:LinkButton ID="LinkButtonMonthlyReport" runat="server"  CssClass="toolbaar1_link"
                                                    PostBackUrl="~/Reports/FinancialMonthlyReport.aspx" TabIndex="3">Financial Monthly Report</asp:LinkButton>
                                            </td>
                                        </tr>
                                       
                           <tr class="toolbaar1_tr" visible="false">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="lbLoginReport" runat="server"  CssClass="toolbaar1_link_active"  PostBackUrl="~/Customer/CreateUser.aspx"
                                        TabIndex="2">Login Report</asp:LinkButton>
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
                        <td colspan="3" class="rptHead" valign="top">
                           <b>Login Reports</b>
                        </td>
                        </tr>
                       
                        <tr>
                            <td  style="width:250px; padding-bottom:20px;">
                                <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                <asp:Label ID="label1" runat="server" CssClass="label_style">Please enter a beginning date:</asp:Label>
                            </td>
                            <td>
                              <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
                                EnableScriptLocalization="true" ID="ToolkitScriptManager1" />
                            <asp:TextBox ID="txtfrom_periodic" runat="server" Style="width: 100px ; margin-bottom:20px;" CssClass="align-center_teller"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfrom_periodic"
                                Format="dd-MMM-yyyy" FirstDayOfWeek="Sunday"  OnClientShowing="showDate">
                            </ajaxToolkit:CalendarExtender>
                            </td>
                             <td rowspan="3" valign="middle">
                               
                                <label>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="rpt" />
                                </label>
                            </td>
                        </tr>
                         <tr>
                            <td style="width:250px; padding-bottom:20px;">
                                <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                <asp:Label ID="label4" runat="server" CssClass="label_style">Please enter an ending date:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtto_perodic" runat="server" Style="width: 100px ; margin-bottom:20px; " CssClass="align-center_teller"> </asp:TextBox>
                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtto_perodic"
                                Format="dd-MMM-yyyy" FirstDayOfWeek="Sunday"  OnClientShowing="showDate">
                            </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                <asp:Label ID="label5" runat="server" CssClass="label_style">Please Select Login attempt:</asp:Label>
                            </td>
                            <td>
                                  <asp:DropDownList
                                    ID="drpLoginStatus" runat="server">
                                    <asp:ListItem>All</asp:ListItem>
                                    <asp:ListItem>Success</asp:ListItem>
                                    <asp:ListItem>Failure</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                           
                        </tr>
                         <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnReport" runat="server" Text="Create Login Track Report" CssClass="btn" />
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 25px;">
                            
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" valign="top">
                                 <asp:Panel ID="panel2" runat="server" >
                                <br /> <br />
                                <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Size="14px" 
                                    ForeColor="Black" RowHeaderColumn="Customer Id" Width="95%" 
                                    CellSpacing="2"  style="margin-left:30px;margin-top: 27px" 
                                                                     ShowFooter="True" >
                                    <RowStyle BackColor="White" HorizontalAlign="Left" BorderColor="#999999" 
                                    BorderStyle="Solid" BorderWidth="1px"/>
                                    <Columns>
                                     
                                        <asp:BoundField DataField="Given_Name" HeaderText="User" />                                     
                                          <asp:TemplateField HeaderText="Location">
                                            <ItemTemplate>                                            
                                            <a href='http://www.geobytes.com/IpLocator.htm?GetLocation&IpAddress=<%# Eval("LoginIP") %>' target="_blank"><%# Eval("LoginIP") %></a>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:BoundField DataField="LoginTime" DataFormatString="{0:d}" 
                                            HeaderText="Date" />
                                        <asp:BoundField DataField="LoginTime" DataFormatString="{0:hh:mm tt}" 
                                            HeaderText="Time" />
                                        <asp:TemplateField HeaderText="Login Status">
                                            <ItemTemplate>                                            
                                            <asp:Label runat="server" ID="lblLogin" Text='<%# Eval("LoginStatus") %>' CssClass='<%# Eval("LoginClass") %>' style="color:Green;"  ></asp:Label>
                                            
                                            </ItemTemplate>
                                            <ItemStyle CssClass="green" />
                                            </asp:TemplateField>
                                          
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                                <br />
                            </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: right;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: center;">
                                                               
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
    <script type="text/javascript" src="../scripts/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {
         $(".red").css("color","red");
//         $(".green").css("color","green");
         });
    </script>
   
</body>
</html>
