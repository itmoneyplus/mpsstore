<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Cheque_dishonoured.ascx.vb" Inherits="toolbaar_Cheque_detail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 <%@ Register Src="~/toolbaar/Cheque_detail_new.ascx" TagName="Toolbaar5" TagPrefix ="tool5"%>
  <head>

  <title>tool_chequedis</title> 
  <link rel="stylesheet" type="text/css" href="../css/style.css" />
  <script type="text/javascript"  src="../frm_val.js" >
  </script>
  <script language="JavaScript" type="text/javascript" >
  
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
    
 </script>

  </head>
  <div align="center" >
  <table style="background-color:#F9F8F4;width:95%;border:1px solid black">
  <tr>
  <td colspan="6"  style="background-color:#C0C0C0;background-color:#EEEEEE;text-align :left">
  <b>Cheque Cashed Dishonoured - Repayments Plan</b></td>
   </tr>
    <tr>
    <td class="td1_loansumm_new" >Cheque amount:</td>
    <td colspan="3" class="td1_loansumm">
    <b>$</b><asp:TextBox ID="txtamt" runat="server" Width="35%" CssClass="align-center" TabIndex="11" MaxLength="7"  ></asp:TextBox></td>
    <td class="td1_loansumm"> First Payment:
    </td>
    <td class="align-center1" >
   <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true" EnableScriptLocalization="true" ID="ScriptManager1"  />
   <asp:TextBox ID="txtfrstpayment" runat="server" Width="40%" MaxLength="10" 
            TabIndex="12"   ></asp:TextBox>
   <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfrstpayment" format="dd/MM/yyyy"  CssClass="red"  OnClientShowing="showDate" FirstDayOfWeek="Sunday" >
   </ajaxToolkit:CalendarExtender>
   </td>
   </tr>
   <tr>
   <td class="td1_loansumm_new">Fee :</td>
   <td colspan="3" class="td1_loansumm">
    <b>$</b><asp:TextBox ID="txtfee" runat="server" Width="35%" CssClass="align-center" Text="30.00" TabIndex="13"></asp:TextBox></td>
   <td class="td1_loansumm"> Payment frequency:</td>
   <td class="align-center1" >
   <asp:DropDownList ID="dropfre" runat="server" Width ="40%" TabIndex="14" >
   <asp:ListItem Value="7">Weekly</asp:ListItem>
   <asp:ListItem Value="14">Fortnightly</asp:ListItem>
   <asp:ListItem Value="30">Monthly</asp:ListItem>
   </asp:DropDownList></td>
   </tr>
   <tr>
   <td class="td1_loansumm_new"></td>
   <td colspan="3" class= "td1_loansumm"></td>
    <td class="td1_loansumm" > Method of re-payment:</td>
    <td class="align-center1" >
    <asp:DropDownList ID="drpmethodpayment" runat="server" Width="40%" TabIndex="14">
    <asp:ListItem>NAB</asp:ListItem>
    <asp:ListItem>Cas</asp:ListItem>
    <asp:ListItem>Sal</asp:ListItem>
    <asp:ListItem>Chq</asp:ListItem>
    <asp:ListItem>CBA</asp:ListItem>
    <asp:ListItem>Cre</asp:ListItem>
    </asp:DropDownList> </td>
    </tr>
    <tr>
   <td class="td1_loansumm_new">
    <asp:Label ID="Label4" runat="server" Text="Total amount:" style="font-weight: 700"></asp:Label>
    </td>
    <td colspan="3"  class= "td1_loansumm"><b><asp:Label ID="Label5" runat="server" Text="$"></asp:Label></b>
    <asp:TextBox ID="txttotfee" runat="server" Width="35%" CssClass="align-center" Enabled="false" ReadOnly="True"></asp:TextBox></td>
    <td  class="td1_loansumm">No. of Payments:</td>
    <td  class="align-center1">
    <asp:TextBox ID="txtnoofpay" runat="server" Width="40%" TabIndex="15" 
            CssClass="align-center" MaxLength="2"></asp:TextBox> </td>
    <td class="align"></td>
    </tr>
    <tr>
    <td class="align-center1">&nbsp;</td>
    <td colspan="3" class="bld">&nbsp;</td>
    <td class="td1_loansumm">Disbursement method:</td>
    <td class="align-center1" >
    <asp:DropDownList ID="drpMethod" runat="server" Width="40%" TabIndex="16">
    <asp:ListItem>Credit</asp:ListItem>
    <asp:ListItem>Cheque</asp:ListItem>
    </asp:DropDownList></td>
    <td class="align" >&nbsp;</td>
    </tr>
 

    <tr>
    <td class="align" colspan="4"></td>
    <td class="align"></td>
    <td class="align"></td>
    <td class="align"></td>
    </tr>
    <tr>
    <td class="td1_loansumm_new">&nbsp;</td>
    <td class="bld" >
    </td>
    <td class="align">&nbsp;</td>
    <td class="align" >&nbsp;</td>
    </tr>
     <tr>
    <td class="td1_loansumm_new">&nbsp;</td>
    <td class="bld" >
    </td>
    <td class="align">&nbsp;</td>
    <td class="align" >&nbsp;</td>
    </tr>
    <tr>

    <td class="align-right" colspan ="7"> 
    <br />
    <asp:Button ID="btncreate_sch" runat="server" Text="Create Schedule" TabIndex ="18"  Width="120px"/><br />
    <asp:Button ID="btnsave_che" runat="server" Text="Save"  TabIndex ="19" Width="120px" /><br />
    </td>
    </tr>
     <tr>
    <td class="td1_loansumm_new">&nbsp;</td>
    <td class="bld" >
    </td>
    <td class="align">&nbsp;</td>
    <td class="align" >&nbsp;</td>
    </tr>
    <tr>
    <td class="td1_loansumm_new">&nbsp;</td>
    <td class="bld" >
    </td>
    <td class="align">&nbsp;</td>
    <td class="align" >&nbsp;</td>
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
     <br />
     <br />
     <tool5:Toolbaar5 id="tool_det_che" runat ="server"/>
   
 
