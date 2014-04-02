<%@ Page Language="VB" Culture="en-AU"  EnableEventValidation="false" EnableViewState="true"  AutoEventWireup="false" CodeFile="Loan Application.aspx.vb" Inherits="Services_Loan_Application" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1"   TagPrefix="tool1"%>
<%@ Register Src="~/toolbaar/tool.ascx" TagName="Toolbaar3"  TagPrefix="tool3"%>
<%@ Register Src="~/toolbaar/feelist.ascx"  TagName="Toolbaar4"  TagPrefix="tool4"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

     <html xmlns="http://www.w3.org/1999/xhtml">
    
     <head  runat="server"> 
     <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
     <title>New Loan Application</title>
     <script language="JavaScript" type="text/javascript" >
         javascript: window.history.forward(1);

     function setlbl(stdt) 
    {
     var weekday = new Array(7);

     weekday[0] = "Sunday";
     weekday[1] = "Monday";
     weekday[2] = "Tuesday";
     weekday[3] = "Wednesday";
     weekday[4] = "Thursday";
     weekday[5] = "Friday";
     weekday[6] = "Saturday";

     var dt = document.getElementById("txtbox" + stdt);
     var spstr = (dt.value).split("/")
     var dtsts = spstr[2] + "/" + spstr[1] + "/" + spstr[0]
     var d = new Date(dtsts);
  

     document.getElementById("lbl" + stdt).innerHTML = weekday[d.getDay()];
     document.getElementById("lbl" + stdt).value = weekday[d.getDay()];

     if ((weekday[d.getDay()] == "Saturday") || (weekday[d.getDay()] == "Sunday")) {
             document.getElementById("lbl" + stdt).style.color = "Red";
     }
     else {
     document.getElementById("lbl" + stdt).style.color = "Black";
          }
     }
     
     function a() 
      {

          var str = "value";
          document.getElementById("Hidden1").value = str;

      }

      function showDate(sender, args) {
          if (sender._textbox.get_element().value == "") {
              var todayDate = new Date();
              sender._selectedDate = todayDate;
          }
      }
     </script>
     <script type="text/javascript"   src="../frm_val.js">    
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
     <asp:TextBox id="txtsearch"  runat="server" TabIndex="8" ></asp:TextBox>
     <asp:Button ID="btnsearch" runat="server"  Text ="Search" TabIndex="9" OnClientClick ="a();" style="height: 26px"  />
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
    <asp:GridView ID="GridView1" runat="server" 
    AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Size="14px" 
    ForeColor="Black" RowHeaderColumn="Customer Id" Width="95%" 
    CellSpacing="2"  style="margin-left:30px; margin-top: 20px">
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
                                        <td colspan="3" class="bld">New Loan Application
                                         <br /><br />
                                        </td>
                                        </tr>
                                        <tr>
                                        <td class="td1_loansumm_new" ><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Loan amount:</td>
                                        <td colspan="3" class="td1_loansumm">
                                        <b>$</b><asp:TextBox ID="txtAmount" runat="server" Width="35%" CssClass="align-center" TabIndex="11" MaxLength="7"  ></asp:TextBox></td>
                                        <td class="td1_loansumm"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> First Payment:
                                        </td>
                                        <td class="align-center1" >
                                       <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true" EnableScriptLocalization="true" ID="ScriptManager1"  />
                                       <asp:TextBox ID="txtFirstPayment" runat="server" Width="46%" MaxLength="10" TabIndex="12" AutoPostBack="True"   ></asp:TextBox>
                                       <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFirstPayment" format="dd/MM/yyyy"  FirstDayOfWeek="Sunday"   OnClientShowing="showDate" >
                                       </ajaxToolkit:CalendarExtender>
                                       </td>
                                       </tr>
                                       <tr>
                                       <td class="td1_loansumm_new"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Defer Establishment :</td>
                                       <td colspan="3" class="td1_loansumm">
                                        <b>$</b><asp:TextBox ID="txtApplicationFee" runat="server" Width="35%" CssClass="align-center" TabIndex="13"></asp:TextBox></td>
                                       <td class="td1_loansumm"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Payment frequency:</td>
                                       <td class="align-center1" >
                                       <asp:DropDownList ID="drpFrequency" runat="server" Width ="48%" TabIndex="14" AutoPostBack="True" >
                                       <asp:ListItem Value="7">Weekly</asp:ListItem>
                                       <asp:ListItem Value="14">Fortnightly</asp:ListItem>
                                       <asp:ListItem Value="30">Monthly</asp:ListItem>
                                       </asp:DropDownList></td>
                                       </tr>
                                       <tr>
                                       <td class="td1_loansumm_new"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Credit fee:</td>
                                       <td colspan="3" class= "td1_loansumm">
                                        <b>$</b><asp:TextBox ID="txtCreditFee" runat="server" Width="35%" CssClass="align-center" TabIndex="15"></asp:TextBox></td>
                                        <td class="td1_loansumm" ><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Method of re-payment:</td>
                                        <td class="align-center1" >
                                        <asp:DropDownList ID="drpMethodOfPayment" runat="server" Width="48%" TabIndex="16">
                                        <asp:ListItem>NAB</asp:ListItem>
                                        <asp:ListItem>Cas</asp:ListItem>
                                        <asp:ListItem>Sal</asp:ListItem>
                                        <asp:ListItem>Chq</asp:ListItem>
                                        <asp:ListItem>CBA</asp:ListItem>
                                        <asp:ListItem>Cre</asp:ListItem>
                                        </asp:DropDownList> </td>
                                        </tr>
                                        <tr>
                                        <td class="td1_loansumm_new"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Variation fee:</td>
                                        <td colspan="3"  class= "td1_loansumm">
                                         <b>$</b><asp:TextBox ID="txtvarfee" runat="server" Width="35%" CssClass="align-center" 
                                                TabIndex="17" AutoPostBack="True" MaxLength="8" ></asp:TextBox></td>
                                        <td  class="td1_loansumm"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> No. of Payments:</td>
                                        <td  class="align-center1">
                                        <asp:TextBox ID="txtNoOfPayment" runat="server" Width="46%" TabIndex="18" 
                                                CssClass="align-center-loanapplication" MaxLength="2"></asp:TextBox> </td>
                                        <td class="align"></td>
                                        </tr>
                                        <tr>
                                        <td class="align-center1">&nbsp;</td>
                                        <td colspan="3" class="bld">&nbsp;</td>
                                        <td class="td1_loansumm"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Disbursement method:</td>
                                        <td class="align-center1" >
                                        <asp:DropDownList ID="drpMethodOfDisbursement" runat="server" Width="48%" TabIndex="19">
                                        <asp:ListItem>Credit</asp:ListItem>
                                        <asp:ListItem>Cheque</asp:ListItem>
                                         <asp:ListItem>Cash</asp:ListItem>
                                        </asp:DropDownList></td>
                                        <td class="align" >&nbsp;</td>
                                        </tr>
                                        <tr>
                                        <td class="align-center1">&nbsp; </td>
                                        <td colspan="3" class="bld" ></td>
                                        <td class="td1_loansumm"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" /> Payment Term:  </td>
                                        <td class="align-center1" >
                                        <asp:DropDownList ID="drpPeriod" runat="server" Width="48%" TabIndex="20" 
                                                AutoPostBack="True">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>1 month</asp:ListItem>
                                        <asp:ListItem>2 months</asp:ListItem>
                                        <asp:ListItem>3 months</asp:ListItem>
                                        <asp:ListItem>4 months</asp:ListItem>
                                        <asp:ListItem>5 months</asp:ListItem>
                                        <asp:ListItem>6 months</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                        <td class="align" >
                                        </td>
                                        </tr>
                                       <%-- <tr>
                                        <td class="align"></td>
                                        <td colspan="3" class="align"></td>
                                        <td  class="td1_loansumm">Loan Term: </td>
                                        <td  class="align-center1" >
                                        <asp:DropDownList ID="drpLoanTerm" runat="server" Width="48%" TabIndex="21" AutoPostBack="True">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="12">12 months</asp:ListItem>
                                        <asp:ListItem Value="24">24 months</asp:ListItem>
                                        </asp:DropDownList></td>
                                        <td class="align"></td>
                                        </tr>--%>
                                            <tr>
                                                <td class="align-center1">
                                                    &nbsp;</td>
                                                <td class="bld" colspan="3">
                                                    &nbsp;</td>
                                                <td class="td1_loansumm"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" />
                                                    Teller:</td>
                                                <td class="align-center1">
                                                    <asp:DropDownList ID="ddlTeller" runat="server" Width="48%">
                                                    <asp:ListItem Value="0" Text="--Select--" />
                                                    <asp:ListItem Value="1" Text="Teller 1" />
                                                    <asp:ListItem Value="2" Text="Teller 2" />
                                                    <asp:ListItem Value="3" Text="Teller 3" />
                                                    <asp:ListItem Value="4" Text="Teller 4" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="align">
                                                    &nbsp;</td>
                                            </tr>
                                        <tr>
                                        <td class="align" colspan="4"   >
                                        <asp:Panel ID="Panel2" runat="server">
                                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="link_text" TabIndex="21"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" style="border:none;" width="10" />Click here to remove following fees</asp:LinkButton>
                                        </asp:Panel>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="link_text" TabIndex="22"><img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" style="border:none;" width="10" />Click here to include other fees</asp:LinkButton>
                                        </td>
                                        <td class="align"></td>
                                        <td class="align"></td>
                                        <td class="align"></td>
                                        </tr>
                                        <tr>
                                        <td class="align-center1">
                                        <asp:Label ID="Label4" runat="server" Text="Loan amount including fee and charges:" style="font-weight: 700"></asp:Label>
                                        </td>
                                        <td class="bld" >
                                        <b><asp:Label ID="Label5" runat="server" Text="$"></asp:Label></b>
                                        <asp:TextBox ID="txtTotal1" runat="server" Width="40%" CssClass="align-center" TabIndex="22" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td class="align">&nbsp;</td>
                                        <td class="align" >&nbsp;</td>
                                        </tr>
                                        <tr>
                                        <td class="align" colspan="6" >
                                        <asp:Panel id="panel1" runat ="server" >     
                                        <tool4:Toolbaar4 id="Toolbaar4" runat ="server"  />
                                        </asp:Panel></td>
                                        <td class="align-right"> 
                                        <asp:Button ID="btncal" runat="server" TabIndex="23" Text="Calculate Fees" Width="129px" /><br />
                                        <asp:Button ID="btncreate" runat="server"  Width="129px" TabIndex="24" Text="Create Schedule"  /><br />
                                        <asp:Button ID="btnsave" runat="server" style="height: 26px" TabIndex="25" Text="Save" Width="129px" /><br />
                                        </td>
                                        </tr> 
                                        <tr>
                                        <td  colspan="6">
                                        <asp:UpdatePanel ID="CollapseDelegate" runat="server">
                                        <ContentTemplate>
                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>         
                                        </td>
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
