<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Grp_search.aspx.vb" Inherits="Customer_Grp_search" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1"   TagPrefix="tool1"%>
<%@ Register Src="~/toolbaar/Reporttab_Statistics.ascx" TagName="Toolbaar_Repsta"   TagPrefix="tool_repsta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Group Search</title>
      <link rel="stylesheet" type="text/css" href="../css/style.css" />
      <link rel="stylesheet" type="text/css" href="../css/menu.css" /> 
       <%--    Javascript used--%>
    <script type="text/javascript"  src="../frm_val.js" >
 
  
        window.history.forward(1);
 
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
        </style>
    </head>
    <body>
    <form id="form1" runat="server">
    
    <div class="align">
    <%--<tool1:Toolbaar1  ID="tool1" runat="server" />--%>
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
                        <asp:LinkButton ID="Link_Reports" CssClass="toolbaar1_link" runat="server"  PostBackUrl="~/Customer/Financial_Reports.aspx"
                            TabIndex="4">Reports</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" 
                                ForeColor="#2E95C9"  PostBackUrl="~/Customer/Marketing_Report.aspx"
                            TabIndex="5">Marketing</asp:LinkButton>
                    </li>
                   <%-- <li>
                        <asp:LinkButton ID="Link_Audit" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Online_Joined.aspx"
                            TabIndex="6">Online Joined</asp:LinkButton>
                    </li>--%>
                    <li>
                        <asp:LinkButton ID="Link_Administration" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/CreateUser.aspx"
                            TabIndex="7">Administration</asp:LinkButton>
                    </li>
                            
                </ul>
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server">
    <table id="toolbarMarketing_table" cellspacing="0" class="toolbartellareport_table" 
        cellpadding="0">
        <tr>
            <td align="left">
                <ul id="navbarMarketing">
                     <li >
                         <asp:LinkButton ID="Link_Marketing" runat="server"  PostBackUrl="~/Customer/Marketing_Report.aspx" TabIndex="1">Marketing Reports</asp:LinkButton>
                                              
                    </li>
                    <li>
                      <asp:LinkButton ID="Link_Statistics" runat="server"  PostBackUrl="~/Customer/Statistics_Report.aspx"
                                    TabIndex="2" Font-Bold="True" ForeColor="#2E95C9">Statistics Reports</asp:LinkButton>
                       
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
                                     <asp:LinkButton ID="Link_sales" runat="server" CssClass="toolbaar1_link_active" PostBackUrl="~/Customer/Grp_search.aspx"
                                TabIndex="1">Group Search</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                     <asp:LinkButton ID="Link_cust_analysis" runat="server" CssClass="toolbaar1_link"
                                PostBackUrl="~/Customer/Cust_Analysis.aspx" TabIndex="2">Customer Analysis</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                     <asp:LinkButton ID="LinkButton1" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Loan_Status.aspx"
                                TabIndex="3">Loans Status</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                      <asp:LinkButton ID="LinkButton2" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/statastics-loan-customer.aspx"
                                TabIndex="4">Customers & Loans</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr"  >
                                <td class="toolbaar1_td_rep">
                                      <asp:LinkButton ID="LinkButton3" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/statastics-customer-joined.aspx"
                                TabIndex="5">Customers Joined On</asp:LinkButton>
                                    
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
                        <td colspan="3" class="rptHead" valign="top" >
                           <b>Please select one of the followings group:</b> 
                        </td>
                        </tr>                   
                       
                         <tr>
                                <td>
                                     <asp:RadioButtonList ID="RadioButtonList1" runat="server"  Height="30px" Style="height: 20px;
                                                        width: 199px " AutoPostBack="true"  >
                                    <asp:ListItem Text=" Customers" Value ="0"   ></asp:ListItem>
                                    <asp:ListItem Text=" Employers" Value ="1"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                        </tr>
                        <tr>
                                <td>
                                    &nbsp;
                                </td>
                       </tr>
                       
                        <tr>
                                                <td>
                                                    <asp:Panel ID="Panel1" runat="server"  Visible ="false" style="z-index: 1; left: 265px; top:150px;  bottom: 682px" >
                                                    <div style="text-align:left">
                                                    <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> <asp:Label ID="lblcustname" runat="server" Text="Customer Name / Surname" CssClass ="toolbaar1_text" Width="200px"></asp:Label>&nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="txtcustname" runat="server" Width ="300px"  Height="20px" CssClass="toolbaar1_text_new"></asp:TextBox><br/><br/>
                                                    <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> <asp:Label ID="lblemail" runat="server" Text="Email" CssClass ="toolbaar1_text" Width="200px"></asp:Label>&nbsp;&nbsp;&nbsp; 
                                                    <asp:TextBox ID="txtemail" runat="server" Width ="300px"  Height="20px" CssClass="toolbaar1_text_new"></asp:TextBox><br/><br/>
                                                    <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> <asp:Label ID="lblmobile" runat="server" Text="Contact Number" CssClass ="toolbaar1_text" Width="200px"></asp:Label>&nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="txtmobile" runat="server" Width ="300px"  Height="20px" CssClass="toolbaar1_text_new"></asp:TextBox><br/><br/>
                                                    <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> <asp:Label ID="lblstname" runat="server" Text="Street name" CssClass ="toolbaar1_text" Width="200px"></asp:Label>&nbsp;&nbsp;&nbsp; 
                                                    <asp:TextBox ID="txtstname" runat="server" Width ="300px"  Height="20px" CssClass="toolbaar1_text_new" ></asp:TextBox><br/><br/>
                                                    <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> <asp:Label ID="lblsub" runat="server" Text="Suburb" CssClass ="toolbaar1_text" Width="200px" ></asp:Label>&nbsp;&nbsp;&nbsp; 
                                                    <asp:TextBox ID="txtsub_new" runat="server" Width ="200px" Height="20px"  CssClass="toolbaar1_text_new"></asp:TextBox>&nbsp;  <input type="button" onclick="getpage_new()" 
                                                   style="background-image: url('../Images/Lookup.gif'); background-color:Transparent;background-repeat:no-repeat; height: 19px; width: 20px; border :none"  /> 
                                                  <br />
                                                  <br />
                                                  <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> <asp:Label ID="lblpostnm" runat="server" CssClass="toolbaar1_text" Text="Postcode" Width="200px"></asp:Label>&nbsp;&nbsp;&nbsp;
                                                  <asp:TextBox ID="txtpstcode_new" runat="server" CssClass="toolbaar1_text_new" Height="20px"  Width="100px"></asp:TextBox>&nbsp;
                                                  <input type="button" onclick="getpage_new()" style="background-image: url('../Images/Lookup.gif'); background-color:Transparent;background-repeat:no-repeat; height: 19px; width: 20px; border :none"  />
                                                 <br/><br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnsearch" runat="server" Text="Search" Height="23px" Width ="100px"  />
                                                 </div> 
                                                 </asp:Panel>
                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Panel3" runat="server"  Visible ="false"
                                                              style="z-index: 1; left: 265px; top:150px;  bottom: 682px" >

                                                             <div style="text-align:left">
                                                             <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> <asp:Label ID="lblempdet" runat="server" Text="Employer/Agency Name" CssClass ="toolbaar1_text" Width ="180px"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtempname" runat="server" Width ="300px" CssClass="toolbaar1_text_new" Height="20px" ></asp:TextBox><br/><br/>
                                                             <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> <asp:Label ID="lblestname" runat="server" Text="Street name" CssClass ="toolbaar1_text" Width ="180px"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtestname" runat="server" Width ="300px"  Height="20px" CssClass="toolbaar1_text_new"></asp:TextBox><br/><br/>
                                                             <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> <asp:Label ID="lblesub" runat="server" Text="Suburb" CssClass ="toolbaar1_text" Width ="180px" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtesub_new" runat="server" Width ="200px" Height="20px"  CssClass="toolbaar1_text_new"></asp:TextBox>&nbsp;  <input type="button" onclick="getpage_enew()" 
                                                             style="background-image: url('../Images/Lookup.gif'); background-color:Transparent;background-repeat:no-repeat; height: 19px; width: 20px; border :none"  /> 
                                                             <br /><br />
                                                             <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> <asp:Label ID="lblepostnm" runat="server" CssClass="toolbaar1_text" Text="Postcode" Width ="180px"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtepstcode_new" runat="server" CssClass="toolbaar1_text_new" Height="20px" Width="100px"></asp:TextBox>&nbsp;
                                                             <input type="button" onclick="getpage_enew()" style="background-image: url('../Images/Lookup.gif'); background-color:Transparent;background-repeat:no-repeat; height: 19px; width: 20px; border :none"  />
                                                             <br/> <br/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnesearch" runat="server" Text="Search" Height="23px" Width ="100px"  />
                                                              </div>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td>
                                            &nbsp;
                                            </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
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
