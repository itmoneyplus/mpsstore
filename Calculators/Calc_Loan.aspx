<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Calc_Loan.aspx.vb" Inherits="Calc_Loan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>
<%@ Register Src="~/toolbaar/feelist.ascx"  TagName="Toolbaar4"  TagPrefix="tool4"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reports Statistics</title>
    <script language="JavaScript" type="text/javascript" >
        javascript: window.history.forward(1);

        function setlbl(stdt) {
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

        function a() {

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
                      <asp:LinkButton ID="Link_fees_charges" runat="server"   PostBackUrl="~/Fees_And_Charges/Fees_And_Charges.aspx"
                                    TabIndex="2"  >Fees & Charges</asp:LinkButton>
                       
                    </li>
                    <li>
                      <asp:LinkButton ID="Link_calculators" runat="server" Font-Bold="True" ForeColor="#2E95C9"  PostBackUrl="~/Calculators/Calc_detail.aspx"
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
                                     <asp:LinkButton ID="Link_Calc_loan" runat="server" CssClass="toolbaar1_link_active" PostBackUrl="~/Calculators/Calc_Loan.aspx"
                                TabIndex="1">Loan Application</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                     <asp:LinkButton ID="Link_Calc_cheque" runat="server" CssClass="toolbaar1_link"
                                PostBackUrl="~/Calculators/Calc_cheque.aspx" TabIndex="2">Cheque Cashing</asp:LinkButton>
                                    
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
                                        <asp:Button ID="btn_recalculate" runat="server" style="height: 26px" TabIndex="25" Text="Re-Calculate" Width="129px" /><br />
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
        
       
              
    </div>
    
    </form>
</body>
</html>
