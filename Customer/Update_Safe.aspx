<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Update_Safe.aspx.vb" Inherits="Customer_Update_Safe" %>
<%@ Register Src="~/toolbaar/tool_main.ascx"  TagName="Toolbaar1"   TagPrefix="tool1"%>
<%@ Register Src="~/toolbaar/tool_bank.ascx" TagName="Toolbaar_Bank"   TagPrefix="tool_bank"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Update Safe</title>
     <%--   CSS used--%>
    <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
    <link rel="stylesheet" type="text/css" href="../css/menu.css" />
     <style type="text/css">
        #form1
        {
            margin-left: 80px;
        }
        .style1
        {
                      
            padding-left:23px;
           
            border:1px solid gray;
            vertical-align :top;            
           
        }
        .style3
        {
            width: 163px;
        }
   </style>    
</head>
<body>
    <form id="form1" runat="server">
    <div class="align" >
    <%--<tool1:Toolbaar1 ID="tool_first" runat="server" />--%>
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
                        <asp:LinkButton ID="Link_Cash" runat="server" Font-Bold="True" 
                                ForeColor="#2E95C9" PostBackUrl="~/Customer/Bank_File_NAB.aspx"
                            TabIndex="3">Cash Movements</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Reports" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Financial_Reports.aspx"
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
                        <asp:LinkButton ID="Link_Administration" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/CreateUser.aspx"
                            TabIndex="7">Administration</asp:LinkButton>
                        </li>
                            
                </ul>
    <br />
    <br />
   <%-- <tool_bank:Toolbaar_Bank ID="t_bank" runat="server" /> --%>
  <asp:Panel ID="Panel2" runat="server">
    <table id="toolbarMarketing_table" cellspacing="0" class="toolbartellareport_table" 
        cellpadding="0">
        <tr>
            <td align="left">
                <ul id="navbarBankFile">
                
                    <li >
                  <asp:LinkButton ID="Link_Till" runat="server" CssClass="toolbaar1_link"  PostBackUrl="~/Customer/Update_Till.aspx"
                                TabIndex="1"  >Update Till</asp:LinkButton></li>
                    
                    <li ><asp:LinkButton ID="Link_Safe" runat="server"  PostBackUrl="~/Customer/Update_Safe.aspx"
                        TabIndex="2" Font-Bold="True" 
                                ForeColor="#2E95C9"  >Update Safe</asp:LinkButton></li>
                    
                    <li ><asp:LinkButton ID="Link_Movements" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/Cash_Movements_Reports.aspx"
                        TabIndex="3"  >Cash Movements</asp:LinkButton></li>
                        
                    <li>
                        
                            <asp:LinkButton ID="Link_NAB" runat="server"  TabIndex="4" CssClass="toolbaar1_link"  PostBackUrl="~/Customer/Bank_File_NAB.aspx">NAB Debit</asp:LinkButton>
                            
                    </li>
                    <li>
                    
                      <asp:LinkButton ID="Link_CBA" runat="server" PostBackUrl="~/Customer/Bank_File_CBA.aspx"
                    TabIndex="5">CBA Debit</asp:LinkButton>
                       
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Customer_Credit" runat="server" 
                    TabIndex="6" PostBackUrl="~/Customer/Customer_Credit.aspx">Customer Credit</asp:LinkButton>
                    </li>
                
                    <li>
                        <asp:LinkButton ID="Link_Payroll" runat="server"  TabIndex="7"
                    PostBackUrl="~/Customer/SalaryDeductions.aspx">Payroll File</asp:LinkButton>
                    </li>
                
                    <li>
                        <asp:LinkButton ID="lbPaymentCollection" runat="server"
                    TabIndex="8" PostBackUrl="~/Customer/Payment_Collection.aspx">Payment Collection</asp:LinkButton>
                    </li>
                    
                </ul>
            </td>
            
        </tr>
    </table>
   
    <table cellspacing="0" cellpadding="0" width="98%"  >
    <tr>
   
    <td style="border:1px solid gray; width:82%;vertical-align :top">
    <div align="left">
    <br />
            <table align="left" class="w100">
                       
                          <tr>
                            <td colspan="3" class="align_width_less">
                            <p>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>Update the SAFE Information</b></p>
                            </td>
                        </tr>
                         <tr>
                            <td style="width:5px ;padding-top:5px; padding-bottom:20px;">
                                <img src="../Images/White_Right_Arrow.GIF" alt="" style="margin-left:60px;" />
                                <asp:Label ID="label2" runat="server" CssClass="label_style">Description:</asp:Label>
                            </td>
                            <td>
                                  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="droplist_updatetill">
                                    <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                    <asp:ListItem Value="ABAZ">Cash brought from Bank for Abaz Safe Account</asp:ListItem>
                                    <asp:ListItem>Amount deducted from Abaz Safe Account due to error</asp:ListItem>
                                    <asp:ListItem>Amount added in Abaz Safe Account due to error</asp:ListItem>
                                    <asp:ListItem Value="M/Plus">Cash brought from Bank for M/Plus Safe Account</asp:ListItem>
                                    <asp:ListItem Value="Amount deducted from M/Plus Safe Account due to error">Amount deducted from M/Plus Safe Account due to error</asp:ListItem>
                                    <asp:ListItem Value="Amount added in M/Plus Safe Account due to error">Amount added in M/Plus Safe Account due to error</asp:ListItem>

                                    </asp:DropDownList>                      
                                
                            </td>
                            <td  >
                               
                             
                            </td>
                        </tr> 
                        <tr>
                            <td style="width:5px; padding-bottom:20px;">
                                <img src="../Images/White_Right_Arrow.GIF" alt=""  style="margin-left:60px;" />
                                <asp:Label ID="label3" runat="server" CssClass="label_style">Enter amount:</asp:Label>
                            </td>
                            <td>
                               <asp:TextBox ID="txt_amt" runat="server" Width="80px" Style=" margin-bottom:20px;" CssClass="align-center_teller"></asp:TextBox> 
                                
                            </td>
                            <td  >
                               
                             
                            </td>
                        </tr>
                        <tr>
                            <td id="tdcheque" style="width:5px; padding-bottom:20px; " runat="server" Visible="false" >
                                <img  src="../Images/White_Right_Arrow.GIF" alt=""   style="margin-left:60px;"  />
                                <asp:Label ID="Label1" runat="server" CssClass="label_style" Visible="false">Cheque number:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtchequeno" runat="server"  Width="80px" Style=" margin-bottom:20px;" CssClass="align-center_teller" Visible="false" ></asp:TextBox>
                              
                                
                            </td>
                            <td  >
                               
                             
                            </td>
                        </tr>
                        
                         <tr>
                            <td style="width:5px; padding-bottom:20px;">
                                <img src="../Images/White_Right_Arrow.GIF" alt="" style="margin-left:60px;" />
                                <asp:Label ID="label4" runat="server" CssClass="label_style">Teller:</asp:Label>
                            </td>
                            <td >
                                <asp:DropDownList ID="ddlTeller" runat="server" CssClass="droplist_updatetill2">
                                  <asp:ListItem Value="0" Text="--Select--" />
                                  <asp:ListItem Value="1" Text="Teller 1" />
                                  <asp:ListItem Value="2" Text="Teller 2" />
                                  <asp:ListItem Value="3" Text="Teller 2" />
                                  <asp:ListItem Value="4" Text="Teller 4" />
                                 </asp:DropDownList>
                                
                            </td>
                            <td  >
                               
                             
                            </td>
                        </tr>
                        
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btn_safe" runat="server" text="Update Safe" CssClass="btn_BankFile" />
                                
                            </td>
                            <td></td>
                        </tr>
                        <tr >
                            <td colspan="3" style="height: 25px;">
                            
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
