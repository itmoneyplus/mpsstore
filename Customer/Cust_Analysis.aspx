<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Cust_Analysis.aspx.vb" Inherits="Customer_Cust_Analysis" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1"   TagPrefix="tool1"%>
<%@ Register Src="~/toolbaar/Reporttab_Statistics.ascx" TagName="Toolbaar_Repsta"   TagPrefix="tool_repsta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
    <title>Customer Analysis</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
    <link rel="stylesheet" type="text/css" href="../css/menu.css" /> 
       <%--    Javascript used--%>
    <script type="text/javascript" >
  
// <!CDATA[

        function Button3_onclick() 
        {
            window.location.assign("../Reports/Print_AgeS_Report.aspx");

        }
        function Button4_onclick() {
            window.location.assign("../Reports/Print_LoanS_Report.aspx");

        }

        function Button5_onclick() {
            window.location.assign("../Reports/Print_SexS_Report.aspx");

        }
        function Button6_onclick() {
            window.location.assign("../Reports/Print_EmpS_Report.aspx");

        }
        function Button7_onclick() {
            window.location.assign("../Reports/Print_ResS_Report.aspx");

        }
        
        // ]]>


        function ClearTextboxes() 
             {
                 document.getElementById('txtfrom').value = '';
                 document.getElementById('txtto').value = '';
                 var lbl_hide = document.getElementById('Label2');
                 lbl_hide.style.display = "none";
                 var tbl_hide = document.getElementById('tbl');
                 tbl_hide.style.display = "none";



             }
            
       function fn_View_sex(sex, from_date, to_date, sex_val)
         {
        var sex_vl = sex_val
        var Sex = sex
        var from_dt = from_date
        var to_dt = to_date
        window.location.assign("sex_status.aspx?SEX=" +
        Sex + "&From_Dt=" + from_dt + "&To_Dt=" +
        to_dt + "&SEX_VL=" +
        sex_vl);

    }

        function fn_View_more(loan_amt, from_date, to_date, amt_val)
        {
        var amt_vl = amt_val
        var amt = loan_amt
        var from_dt = from_date
        var to_dt = to_date
        window.location.assign("loan_stats.aspx?Amt=" +
        amt + "&From_Dt=" + from_dt + "&To_Dt=" +
        to_dt + "&Amt_VL=" +
        amt_vl);
        }

        function fn_View_emp(emp_type, from_date, to_date, emp_val) 
        {
        var emp_vl = emp_val
        var emp_ty = emp_type
        var from_dt = from_date
        var to_dt = to_date
        window.location.assign("emp_stats.aspx?Emp_Type=" +
        emp_ty + "&From_Dt=" + from_dt + "&To_Dt=" +
        to_dt + "&Emp_VL=" +
        emp_vl);
        }

        function fn_View_Res(res_type, from_date, to_date, res_val) {
        var res_vl = res_val
        var res_ty = res_type
        var from_dt = from_date
        var to_dt = to_date
        window.location.assign("Res_stats.aspx?Res_Type=" +
        res_ty + "&From_Dt=" + from_dt + "&To_Dt=" +
        to_dt + "&Res_VL=" +
        res_vl);
        }

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
   <asp:Panel ID="Panel4" runat="server">
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
                                     <asp:LinkButton ID="Link_sales" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Grp_search.aspx"
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
                                     <asp:LinkButton ID="Link_cust_analysis" runat="server" CssClass="toolbaar1_link_active" 
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
                           <b>Please select one of the following Statistic Report</b> 
                        </td>
                        </tr>                   
                       
                         <tr>
                                 <td style="vertical-align: top;">
                             <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="79px" Style="height: 20px;
                                                        width: 199px ; margin-bottom:20px" AutoPostBack="true" CellSpacing="3" CellPadding="3">
                                        <asp:ListItem Text=" Employment" Value="0"></asp:ListItem>
                                        <asp:ListItem Text=" Residential" Value="1"></asp:ListItem>
                                        <asp:ListItem Text=" Loans" Value="2"></asp:ListItem>
                                        <asp:ListItem Text=" Age" Value="3"></asp:ListItem>
                                        <asp:ListItem Text=" Gender" Value="4"></asp:ListItem>
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
                                    <asp:Panel ID="panel2" runat="server" Visible="false">
                                        <div align="left">
                                            &nbsp;&nbsp;
                                            <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" />
                                            <asp:Label ID="Label1" runat="server" CssClass="label_style">Please enter a beginning date:</asp:Label>
                                             <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
                                               <asp:TextBox ID="txtfrom" runat="server" CssClass="align-center" style="width:100px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" format="dd-MMM-yyyy" TargetControlID="txtfrom"  OnClientShowing="showDate" FirstDayOfWeek="Sunday"> 
                                               </ajaxToolkit:CalendarExtender>
                                            <br />
                                            <br />
                                            &nbsp;&nbsp;
                                            <img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif" width="10" />
                                            <asp:Label ID="Label3" runat="server" CssClass="label_style">Please enter an ending date:</asp:Label>
                                            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtto" runat="server" CssClass="align-center" style="width:100px"> </asp:TextBox>&nbsp;&nbsp;&nbsp;
   
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" format="dd-MMM-yyyy" TargetControlID="txtto"    OnClientShowing="showDate" FirstDayOfWeek="Sunday">
                                            </ajaxToolkit:CalendarExtender>
    
                                             <br />
                                             <asp:Button ID="Button1" runat="server"  Height="23px" Width="100px" CssClass="btnsearch_Cust_Analysis" Text="Create Report" />
                                             
                                             <br />
                                             <br />
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>
                            
                             <tr>
                                <td>
                                    <div align="left">
                                        &nbsp;&nbsp;
                                        <asp:Label ID="Label2" runat="server" CssClass="italics1-doc" Text="Label"  Visible ="false"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                          
                               <tr>
                                <td>
                                    <asp:Panel runat="server" ID="pnlSearch">
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
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
