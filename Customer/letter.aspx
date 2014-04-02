<%@ Page Language="VB" AutoEventWireup="false" CodeFile="letter.aspx.vb" Inherits="Customer_letter" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1"   TagPrefix="tool1"%>
<%@ Register Src="~/toolbaar/Reporttab_Marketing.ascx" TagName="Toolbaar_RepMar"   TagPrefix="tool_repmar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
<title>Letter</title>
 <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
 <link rel="stylesheet" type="text/css" href="../css/menu.css" />
       <%--    Javascript used--%>
 <script type="text/javascript"  >

     function toggle(source) 
     {
         var checkboxes = document.getElementsByName('chkCustomerIDs');
         for (var i = 1, n = checkboxes.length; i < n; i++) {
             checkboxes(i).checked = source.checked;
             document.getElementById("hidden_val").value = document.getElementById("hidden_val").value + "," +checkboxes(i).value;
         }
       
     }
   function add_val(val) 
   {
       document.getElementById("hidden_val").value = document.getElementById("hidden_val").value + "," + val;
     
   }
   function show_let(let_type) 
   {
  
       window.location.assign("Show_Letter.aspx?letter_val=" + document.getElementById("hidden_val").value + "&letter_type=" + let_type);
}

   function ClearTextboxes() 
   {
       document.getElementById('txtfrom_letter').value = '';
       document.getElementById('txtto_letter').value = '';
       var lbl_hide = document.getElementById('Label2');
       lbl_hide.style.display = "none";
       var tbl_hide = document.getElementById('tbl');
       tbl_hide.style.display = "none";


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
    <asp:Panel ID="Panel3" runat="server">
    <table id="toolbarMarketing_table" cellspacing="0" class="toolbartellareport_table" 
        cellpadding="0">
        <tr>
            <td align="left">
                <ul id="navbarMarketing">
                    <li >
                        <asp:LinkButton ID="LinkButton1" runat="server"  PostBackUrl="~/Customer/Marketing_Report.aspx"
                                    TabIndex="1" Font-Bold="True" ForeColor="#2E95C9">Marketing Reports</asp:LinkButton>
                                              
                    </li>
                    <li>
                      <asp:LinkButton ID="LinkButton2" runat="server"  PostBackUrl="~/Customer/Statistics_Report.aspx"
                                    TabIndex="2">Statistics Reports</asp:LinkButton>
                       
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
                                    <asp:LinkButton ID="Link_Marketing_Letter" runat="server"  CssClass="toolbaar1_link_active" PostBackUrl="~/Customer/letter.aspx" TabIndex="1" >Letters</asp:LinkButton>
                                    
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
                           <b>Please select one of the following:</b> 
                        </td>
                        </tr>                   
                       
                         <tr>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="79px" Style="height: 20px;
                                                        width: 299px "  AutoPostBack="true">
                                    <asp:ListItem Text=" Finalised Loans" Value ="0"   ></asp:ListItem>
                                    <asp:ListItem Text=" Balance Outstanding Loans" Value ="1"></asp:ListItem>
                                    <asp:ListItem Text=" Cheque Customers" Value ="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                        </tr>
                        <tr>
                                <td>
                                    &nbsp;
                                </td>
                       </tr>
                       
                        <tr>
                            <td colspan="3" valign="top">
                            <asp:Panel ID="Panel2" runat="server" Visible="false" Width="750px">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;<img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                                        height="10" />
                                                    <asp:Label ID="Label3" runat="server" CssClass="label_style"  >Please enter a beginning date:</asp:Label>
                                                   <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true" EnableScriptLocalization="true" ID="ToolkitScriptManager1" />
                                                    <asp:TextBox ID="txtfrom_letter" runat="server"  CssClass="align-center" style="width:100px" ></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfrom_letter" format="dd-MMM-yyyy"  FirstDayOfWeek="Sunday"   OnClientShowing="showDate">
                                                    </ajaxToolkit:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;<img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                                        height="10" />
                                                    <asp:Label ID="Label4" runat="server" CssClass="label_style"> Please enter an ending date:</asp:Label>&nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="txtto_letter" runat="server" CssClass="align-center" style="width:100px"> </asp:TextBox> 
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtto_letter" format="dd-MMM-yyyy" FirstDayOfWeek="Sunday"  OnClientShowing="showDate" >
                                                    </ajaxToolkit:CalendarExtender>
                                                     <br />
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                    <br />                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;<img id="ImgList" runat="server" alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                                        height="10" />
                                                    <asp:Label ID="Label5" runat="server" CssClass="label_style">Please select from the list:</asp:Label>&nbsp;&nbsp;
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList 
                                                       ID="drp_letter" runat="server" >
                                                    
                                                       <asp:ListItem>Need Cash Today</asp:ListItem>
                                                       <asp:ListItem>Easter Letter</asp:ListItem>
                                                       <asp:ListItem>Christmas Letter</asp:ListItem>
                                                       <asp:ListItem>Special Occassion</asp:ListItem>
                                                       <asp:ListItem>Valued Customer</asp:ListItem>
                                                       <asp:ListItem>Tax Time</asp:ListItem>
                                                      

                                                   </asp:DropDownList>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    
                                                </td>
                                            </tr>
                                             <tr>
                                               
                                                <td class="style4">
                                                    <asp:Button ID="Button1" runat="server" Text="Create List of Customers" CssClass="btn_letter"/>
                                                 
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:Label ID="Label2" runat="server" Text="Label"  CssClass="italics1-doc" Visible="false"  ></asp:Label>
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   <input  type="hidden" id="hidden_val" />
                                                    <asp:GridView ID="gvFl" runat="server" Visible="False" CssClass="tblreport_new" AutoGenerateColumns="False"
                                                        Width="80%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No">
                                                            <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblRowNo"></asp:Label>
                                                            </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="chkAll" runat="server" Text="Select" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkCustID" runat="server" CssClass="chk" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Customer No">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblCustID" Text='<%#Eval("Customer_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Customer Name">
                                                            <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblFirstName" Text='<%#Eval("Given_Name") %>'></asp:Label>&nbsp;<asp:Label runat="server" ID="lblLastName" Text='<%#Eval("Last_Name") %>'></asp:Label>  
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />
                                                    <asp:GridView ID="gvOSL" runat="server" AutoGenerateColumns="False" 
                                                        CssClass="tblreport_new" Visible="False" Width="80%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNo0" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="chkOslH" runat="server" Text="Select" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkOsCustID" runat="server" CssClass="chk" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Customer No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCustID0" runat="server" Text='<%#Eval("Customer_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Customer Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFirstName0" runat="server" Text='<%#Eval("Given_Name") %>'></asp:Label>&nbsp; <asp:Label ID="lblLastName0" runat="server" Text='<%#Eval("Last_Name") %>'></asp:Label>                                                                    
                                                                    
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />
                                                    <asp:GridView ID="gvChq" runat="server" AutoGenerateColumns="False" 
                                                        CssClass="tblreport_new" Visible="False" Width="80%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNo1" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="chkChqH" runat="server" Text="Select" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkChqCustID" runat="server" CssClass="chk" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Customer No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCustID1" runat="server" Text='<%#Eval("Customer_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Customer Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFirstName1" runat="server" Text='<%#Eval("Given_Name") %>'></asp:Label>
                                                                    &nbsp;
                                                                    <asp:Label ID="lblLastName1" runat="server" Text='<%#Eval("Last_Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trBtnRow" visible ="false">
                                            <td align="center">
                                                <asp:Button ID="btnSendPost" runat="server" Text="Print Letter" /> &nbsp;&nbsp;
                                                <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" />
                                                <asp:Button ID="BtnView" runat="server" Text="View & Print" />
                                            </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    
                                          
                                         </td>
                                        </tr>
                                        <tr>
                              
                               
                                <td colspan="3" style="text-align:center;">
                                  
                                  
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
