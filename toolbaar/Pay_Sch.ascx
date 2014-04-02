<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Pay_Sch.ascx.vb" Inherits="toolbaar_Pay_Sch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 <head>
 <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
<title>Payment Receipt</title> 
 <link rel="stylesheet" type="text/css" href="../css/style.css" />
   
 </head>
  <div align="center" >
  <asp:Panel ID="Panel1" runat="server">
  <table  cellspacing="0"   class ="payreceipt_table">
   <tr>
   <td style="font-size:medium;font-weight :bold;text-align: left;height: 22px">
   Payment Schedule
   </td>
   </tr>
   <tr>
   <td style="border-top:1px solid gray; width:50%;vertical-align :top">
   <br />
   <br />
   <div class="align">
   &nbsp;&nbsp;&nbsp;&nbsp;<img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10" height="10"/>
   <asp:LinkButton ID="LinkButton1" runat="server" CssClass="label_style">Please enter statement start date:</asp:LinkButton> &nbsp;
   <asp:TextBox ID="txtpayschfrom" runat="server" CssClass="align-centernew" ></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtpayschfrom" format="dd-MMM-yyyy" FirstDayOfWeek="Sunday" >
    </ajaxToolkit:CalendarExtender>
    <br/>
    <br/>
    &nbsp;&nbsp;&nbsp;&nbsp;<img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10" height="10"/>
    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="label_style">Please enter statement end date:</asp:LinkButton>  &nbsp;&nbsp;
    <asp:TextBox ID="txtpayschto" runat="server" CssClass="align-centernew" ></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtpayschto" format="dd-MMM-yyyy" FirstDayOfWeek="Sunday">
    </ajaxToolkit:CalendarExtender>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnpayschsearch" runat="server"  Text="View Payment Schedule" style="height: 26px" />&nbsp;&nbsp;&nbsp;
    <br/>
    <br /> 
    <br />   
    </div>
    </td>
    </tr>
    </table>
  </asp:Panel>
  </div>   