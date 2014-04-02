<%@ Page Language="VB" Culture="en-AU"  EnableEventValidation="false" EnableViewState="true"  AutoEventWireup="false" CodeFile="Cheque Application.aspx.vb" Inherits="Services_Loan_Application" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1"   TagPrefix="tool1"%>
<%@ Register Src="~/toolbaar/tool.ascx" TagName="Toolbaar3"  TagPrefix="tool3"%>
<%@ Register Src="~/toolbaar/feelist.ascx"  TagName="Toolbaar4"  TagPrefix="tool4"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

     <html xmlns="http://www.w3.org/1999/xhtml">
     <head  runat="server">
     <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
     <title>New Loan Application</title>
     <script language="JavaScript" type="text/javascript" src="../frm_val.js" >
      javascript: window.history.forward(1);
      </script>
       <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
       <link rel="stylesheet" type="text/css" href="../css/menu.css" />
       <style type="text/css">
                #form1
                {
                   
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
            <script type="text/javascript">

                function Confirm_Black() {
                    var confirm_value_black = document.createElement("INPUT");

                    if (confirm("Click OK to Blacklist or Cancel to go Back!")) {
                        confirm_value_black.setAttribute("type", "hidden");
                        confirm_value_black.setAttribute("value", "Yes");
                        confirm_value_black.setAttribute("name", "confirm_value_black");
                    }
                    else {
                        confirm_value_black.setAttribute("type", "hidden");
                        confirm_value_black.setAttribute("value", "No");
                        confirm_value_black.setAttribute("name", "confirm_value_black");
                    }
                    document.forms[0].appendChild(confirm_value_black);
                }
                function Confirm_RemoveBlack() {
                    var confirm_value_reblack = document.createElement("INPUT");

                    if (confirm("Click OK to Remove from Blacklist or Cancel to go Back!")) {
                        confirm_value_reblack.setAttribute("type", "hidden");
                        confirm_value_reblack.setAttribute("value", "Yes");
                        confirm_value_reblack.setAttribute("name", "confirm_value_reblack");
                    }
                    else {
                        confirm_value_reblack.setAttribute("type", "hidden");
                        confirm_value_reblack.setAttribute("value", "No");
                        confirm_value_reblack.setAttribute("name", "confirm_value_reblack");
                    }
                    document.forms[0].appendChild(confirm_value_reblack);
                }

                function Confirm_Followup() {
                    var confirm_value_Followup = document.createElement("INPUT");

                    if (confirm("Click OK to Add to FollowUp or Cancel to go Back!")) {
                        confirm_value_Followup.setAttribute("type", "hidden");
                        confirm_value_Followup.setAttribute("value", "Yes");
                        confirm_value_Followup.setAttribute("name", "confirm_value_Followup");
                    }
                    else {
                        confirm_value_Followup.setAttribute("type", "hidden");
                        confirm_value_Followup.setAttribute("value", "No");
                        confirm_value_Followup.setAttribute("name", "confirm_value_Followup");
                    }
                    document.forms[0].appendChild(confirm_value_Followup);
                }
                function Confirm_RemoveFollowup() {
                    var confirm_value_reFollowup = document.createElement("INPUT");

                    if (confirm("Click OK to Remove from FollowUp or Cancel to go Back!")) {
                        confirm_value_reFollowup.setAttribute("type", "hidden");
                        confirm_value_reFollowup.setAttribute("value", "Yes");
                        confirm_value_reFollowup.setAttribute("name", "confirm_value_reFollowup");
                    }
                    else {
                        confirm_value_reFollowup.setAttribute("type", "hidden");
                        confirm_value_reFollowup.setAttribute("value", "No");
                        confirm_value_reFollowup.setAttribute("name", "confirm_value_reFollowup");
                    }
                    document.forms[0].appendChild(confirm_value_reFollowup);
                }
    </script>
      </head>
     <body>
     <form id="form1" runat="server">
     <div>
     <%--<tool1:Toolbaar1 id="tool_first" runat ="server"  />--%>
     <div id="title" 
                style="padding: 0px; margin: 0px; position: absolute; float: left; top: 0px; left: 0px;">
                <asp:Label ID="lblTitle" runat="server" Text="Money Plus" CssClass="menu_left" ></asp:Label>  
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
                        <asp:LinkButton ID="Link_Reports" runat="server" CssClass="toolbaar1_link"    PostBackUrl="~/Customer/Financial_Reports.aspx"
                            TabIndex="4">Reports</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Marketing" runat="server"   CssClass="toolbaar1_link"  PostBackUrl="~/Customer/Marketing_Report.aspx"
                            TabIndex="5">Marketing</asp:LinkButton>
                    </li>
                    <%--<li>
                        <asp:LinkButton ID="Link_Audit" runat="server" CssClass="toolbaar1_link"  PostBackUrl="~/Customer/Online_Joined.aspx"
                            TabIndex="6">Online Joined</asp:LinkButton>
                    </li>--%>
                    <li>
                        <asp:LinkButton ID="Link_Administration" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/CreateUser.aspx"
                            TabIndex="7">Administration</asp:LinkButton>
                        </li>
                   <%--<li class="menu_right"><a class="toolbaar1_link" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                       <b> [Logout]</b></a></li>
                    <li class="menu_right">
                        <asp:LinkButton ID="LinkButton8" runat="server" CssClass="toolbaar1_link" TabIndex="8">[Back]</asp:LinkButton></li>--%>           
                </ul>
     <table  class="table" align="center">
     <tr>
     <td>
     <asp:TextBox id="txtsearch"  runat ="server" TabIndex="8" ></asp:TextBox>
     <asp:Button ID="btnsearch" runat="server"  Text ="Search" TabIndex="9" style="height: 26px"  />
     <asp:Label runat ="server" ID="label1"  >|</asp:Label>
     <asp:LinkButton runat="server" id="LinkButton_AddCustomer" Text="Add Customer" CssClass="link_text" TabIndex="10"></asp:LinkButton>
     <asp:Label runat ="server" ID="label2"  >|</asp:Label>
     </td>
     </tr> 
     </table>
     </div>
     <br/>
     <asp:Label ID="Label3" runat="server" CssClass="declined_label_text" Text="Customer Search Result" Visible="False"></asp:Label>
     <input id="Hidden1" type="hidden" runat="server" />
     <br />
     <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Size="14px" 
    ForeColor="Black" RowHeaderColumn="Customer Id" Width="95%" 
    CellSpacing="2"  style="margin-left:30px;margin-top: 27px">
    <RowStyle BackColor="White" HorizontalAlign="Left" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
    <Columns>
    <asp:BoundField DataField="Customer_ID" HeaderText="Customer ID" />
    <asp:BoundField DataField="Given_Name" HeaderText="Given Name" />
    <asp:BoundField DataField="Last_Name" HeaderText="Last Name" />
    <asp:BoundField DataField="Date_Of_Birth" HeaderText="Date Of Birth" SortExpression="Date Of Birth" DataFormatString="{0:d-MMM-yyyy}"  HtmlEncode="false"  />
    <asp:BoundField DataField="Request_Amount" HeaderText="Request Amount" 
    DataFormatString="{0:c}" />
    <asp:BoundField DataField="Date_Joined" HeaderText="Date Joined"  SortExpression="Date Joined" DataFormatString="{0:d}"  HtmlEncode="false"  />
    <asp:BoundField DataField="Time_Joined" HeaderText="Time_Joined"  
    SortExpression="Time_Joined" DataFormatString="{0:hh:mm tt}"  
    HtmlEncode="false"  />
    </Columns>
    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="black" HorizontalAlign="Center" VerticalAlign="Middle" />
    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
    </asp:GridView>
    <br />
    <asp:Panel ID="Panel3" runat="server" CssClass="customerContent">
                <table id="toolbarMarketing_table" cellspacing="0" class="toolbarcustomerDetail_table" 
                    cellpadding="0">
                    <tr>
                        <td align="left">
                               <ul id="navbarCustomerDetail">
                                <li><a href="#" >Customer Info</a>
                                    <ul >
                                        <li>
                                            <asp:LinkButton ID="LinkButton1" PostBackUrl="~/Customer/Update Personal_Form.aspx"
                                                runat="server">Customer Details</asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton15" PostBackUrl="~/Customer/Bank Detail.aspx" runat="server">Bank Details</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton16" PostBackUrl="~/Customer/Comments.aspx" runat="server">Comments</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton14" PostBackUrl="~/Customer/Upload_docs_new.aspx" runat="server">Upload Documents</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton5" PostBackUrl="~/Customer/Export.aspx" runat="server">Export Documents</asp:LinkButton></li>
                                    </ul>
                                </li>
                                <li><a href="#">Summary</a>
                                    <ul>
                                        <li>
                                            <asp:LinkButton ID="LinkButton6" PostBackUrl="~/Customer/Detail.aspx" runat="server">Loan Summary</asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton7" PostBackUrl="~/Customer/Cheque Summary.aspx" runat="server">Cheque Summary</asp:LinkButton></li>
                                    </ul>
                                </li>
                                <li><a href="#" style="font-weight:bold;color:#2E95C9">Applications</a>
                                    <ul>
                                        <li>
                                            <asp:LinkButton ID="LinkButton8" PostBackUrl="~/Customer/Loan Application.aspx" runat="server">New Loan Application</asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton9" PostBackUrl="~/Customer/Cheque Application.aspx"
                                                runat="server">New Cheque Cashing</asp:LinkButton></li>
                                    </ul>
                                </li>
                                <li><a href="#">Bad Debt</a>
                                    <ul>
                                        <li>
                                            <asp:LinkButton ID="LinkButton10" PostBackUrl="" runat="server" OnClientClick="Confirm_Black();"
                                                CssClass="align">Add to Black List</asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton11" PostBackUrl="" runat="server" OnClientClick="Confirm_RemoveBlack();"
                                                CssClass="align">Remove from Black List</asp:LinkButton>
                                        </li>
                                    </ul>
                                </li>
                                <li><a href="#">Add FollowUp</a>
                                    <ul>
                                        <li>
                                            <asp:LinkButton ID="LinkButton12" PostBackUrl="" runat="server" OnClientClick="Confirm_Followup();"
                                                CssClass="align">Add to Followup</asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton13" PostBackUrl="" runat="server" OnClientClick="Confirm_RemoveFollowup();"
                                                CssClass="align">Remove from Followup</asp:LinkButton>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </td>
                        <td class="toolbaar3_td_customer_detail">
                            <asp:Label ID="Label_customername" runat="server" CssClass="" Text=""></asp:Label>
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
                                    <td colspan="3" >&nbsp;</td>
                                    </tr>
                                    <tr>
                                    <td colspan="3" ><i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color :black;font-size:20px; font-weight:bold">Cheque Cashing</span></i>&nbsp;</td>
                                    </tr>
                                    <tr>
                                    <td colspan="3" >&nbsp;</td>
                                    </tr>
                                    <tr>
                                    <td style="width:40px">&nbsp;</td>
                                    <td class="td1_cheque_new"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Cheque Drawer:</td>
                                    <td class="td1_chequesumm">
                                    <asp:TextBox ID="txtchedrw" runat="server" TabIndex="11" Width="180px" CssClass ="bld" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td style="width:60px">&nbsp;&nbsp;&nbsp;</td>
                                    <td class="td1_chequesumm"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Cheque Number:
                                    </td>
                                    <td style="width:40px">&nbsp;</td>
                                    <td style="text-align:left" >
                                    <asp:TextBox ID="txtcheno" runat="server" TabIndex="12" Width="50%" MaxLength ="10" CssClass ="bld"></asp:TextBox>
                                    </td>
                                    <td style="width:20px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                    <td style="width:40px">&nbsp;</td>
                                    <td class="td1_cheque_new"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> BSB:</td>
                                    <td class="td1_chequesumm">
                                     &nbsp;&nbsp;<asp:TextBox ID="txtBSB" runat="server" TabIndex ="13" CssClass="align-center"    Width="80px" MaxLength="7"  onkeypress="addcom();" ></asp:TextBox>
                                    </td>
                                    <td style="width:60px">&nbsp;</td>
                                    <td class="td1_chequesumm"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Account Number:
                                    </td><td style="width:40px"></td>
                                    <td style="text-align:left">
                                    <asp:TextBox ID="txtaccno" runat="server" TabIndex="14" Width="50%" MaxLength ="10" CssClass ="bld"></asp:TextBox>
                                    </td>
                                    <td style="width:20px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                    <td style="width:40px">&nbsp;</td>
                                    <td class="td1_cheque_new"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Cheque Amount:</td>
                                    <td class="td1_chequesumm">
                                    $<asp:TextBox ID="txtcheamt" runat="server" TabIndex="15"  Width="80px"  MaxLength ="4" CssClass ="align-center"></asp:TextBox></td>
                                    <td style="width:60px">&nbsp;</td>
                                    <td class="td1_chequesumm"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Amount Payable:
                                    </td>
                                    <td style="width:40px;text-align:right">
                                    $</td>
                                    <td style="text-align:left" >
                                    <asp:TextBox ID="txtamtpay" runat="server" TabIndex="16" Width="30%" CssClass="align-center" Enabled ="false"  ></asp:TextBox>
                                    </td>
                                    <td style="width:20px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                    <td style="width:40px">&nbsp;</td>
                                    <td class="td1_cheque_new"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Cheque Fee:</td>
                                    <td class="td1_chequesumm">
                                    $<asp:TextBox ID="txtchefee" runat="server" TabIndex="17" Width="80px" CssClass ="align-center"   AutoPostBack ="true" MaxLength ="3"></asp:TextBox></td>
                                    <td style="width:60px;text-align :right">
                                    </td>
                                    <td >
                                    <img alt="che_img" src="../Images/White_Right_Arrow.GIF" /> <asp:LinkButton  ID="Button2" runat="server" Text="Calculate:"  CssClass="link_text" /> 
                                    </td>
                                    <td style="width:40px;text-align:right">
                                    </td>
                                    <td style="text-align:left" >
                                    <asp:TextBox ID="txtcal" runat="server" TabIndex="18" Width="25%" CssClass="align-center" ></asp:TextBox>%
                                    </td>
                                    <td style="width:20px">
                                    </td>
                                    </tr>
                                    <tr>
                                    <td style="width:40px">&nbsp;</td>
                                    <td class="td1_cheque_new"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Pay cash(now): </td>
                                    <td class="td1_chequesumm">
                                    $<asp:TextBox ID="txtpaycash" runat="server" TabIndex="19" Width="80px"   CssClass ="align-center"></asp:TextBox></td>
                                    <td style="width:60px">&nbsp;</td>
                                    <td class="td1_chequesumm">
                                    </td>
                                    <td style="width:40px;text-align:right">
                                    </td>
                                    <td style="text-align:left">
                                    </td>
                                    <td style="width:20px">
                                    </td>
                                    </tr>
                                    <tr>
                                    <td style="width:40px">&nbsp;</td>
                                    <td class="td1_cheque_new">
                                        <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> <asp:Label ID="Label4" runat="server" Text="Teller"></asp:Label>
                                        </td>
                                    <td class="td1_chequesumm">
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlTeller" runat="server" Width="36%">
                                         <asp:ListItem Value="0" Text="--Select--" />
                                         <asp:ListItem Value="1" Text="Teller 1" />
                                         <asp:ListItem Value="2" Text="Teller 2" />
                                         <asp:ListItem Value="3" Text="Teller 2" />
                                         <asp:ListItem Value="4" Text="Teller 4" />
                                        </asp:DropDownList>
                                        </td>
                                    <td style="width:60px;text-align :right">&nbsp;</td>
                                    <td class="td1_chequesumm">&nbsp;</td>
                                    <td style="width:40px;text-align:right"></td>
                                    <td style="text-align:left" ></td>
                                    <td style="width:20px"></td>
                                   </tr>
                                   <tr>
                                    <td style="width:40px">&nbsp;</td>
                                    <td class="td1_cheque_new"></td>
                                    <td class="td1_chequesumm"></td>
                                    <td style="width:60px;text-align :right">&nbsp;</td>
                                    <td class="td1_chequesumm">&nbsp;</td>
                                    <td style="width:40px;text-align:right"></td>
                                    <td style="text-align:left" ></td>
                                    <td style="width:20px"></td>
                                   </tr>
                                    <tr>
                                    <td style="width:40px">&nbsp;</td>
                                    <td class="td1_cheque_new"></td>
                                    <td class="td1_chequesumm"></td>
                                    <td style="width:60px;text-align :right">&nbsp;</td>
                                    <td class="td1_chequesumm">&nbsp;</td>
                                    <td style="width:40px;text-align:right"></td>
                                    <td style="text-align:left" ></td>
                                    <td style="width:20px"></td>
                                   </tr>
                                          
                                    <tr>
                                    <td style="width:40px">&nbsp;</td>
                                    <td class="td1_cheque_new"></td>
                                    <td class="td1_chequesumm"></td>
                                    <td style="width:60px;text-align :right">
                                    <asp:Button ID="Button1" runat="server" Text="Save"  Width ="80px"  
                                            TabIndex ="27"   />
                                            <br /><br />
                                    </td>
                                    <td class="td1_chequesumm">&nbsp;<asp:Button ID="Button4" runat="server" Text="Clear"  Width ="80px"  TabIndex ="28"  />
                                    <br /><br />
                                    </td>
                                    <td style="width:40px;text-align:right"></td>
                                    <td style="text-align:left" ></td>
                                    <td style="width:20px"></td>
                                    </tr>
                        
                                     
                                </table>             
                
                            
                               
                                </div> 
                            </td>
                       </tr>
                      </table>
              </asp:Panel>
   
    </form>

</body>
</html>
