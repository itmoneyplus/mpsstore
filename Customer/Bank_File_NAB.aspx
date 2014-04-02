<%@ Page Language="VB" Culture="en-AU" EnableEventValidation="false" EnableViewState="true"  AutoEventWireup="false" CodeFile="Bank_File_NAB.aspx.vb" Inherits="Customer_Bank_File_NAB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/toolbaar/tool_main.ascx"  TagName="Toolbaar1"   TagPrefix="tool1"%>
<%@ Register Src="~/toolbaar/tool_bank.ascx" TagName="Toolbaar_Bank"   TagPrefix="tool_bank"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
   <html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
   <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
    <title>Bank File NAB</title>
    <%--   CSS used--%>
    <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
    <link rel="stylesheet" type="text/css" href="../css/menu.css" />
    <%--    JAVA SCRIPT --%>
    <script type = "text/javascript">
          function Confirm() {
             var confirm_value = document.createElement("INPUT");
             confirm_value.type = "hidden";
             confirm_value.name = "confirm_value";
             if (confirm("Are you sure you want to create Debit file?")) {
                 confirm_value.value = "Yes";
             } else {
                 confirm_value.value = "No";
             }
             document.forms[0].appendChild(confirm_value);
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
    <asp:Panel ID="Panel2" runat="server">
    <table id="toolbarMarketing_table" cellspacing="0" class="toolbartellareport_table" 
        cellpadding="0">
        <tr>
            <td align="left">
                <ul id="navbarBankFile">
                
                    <li >
                  <asp:LinkButton ID="Link_Till" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Update_Till.aspx"
                                TabIndex="1"  >Update Till</asp:LinkButton></li>
                    
                    <li ><asp:LinkButton ID="Link_Safe" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Update_Safe.aspx"
                        TabIndex="2"  >Update Safe</asp:LinkButton></li>
                    
                    <li ><asp:LinkButton ID="Link_Movements" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/Cash_Movements_Reports.aspx"
                        TabIndex="3"  >Cash Movements</asp:LinkButton></li>
                        
                    <li>
                        
                            <asp:LinkButton ID="Link_NAB" runat="server"  TabIndex="4" Font-Bold="True" 
                                ForeColor="#2E95C9" PostBackUrl="~/Customer/Bank_File_NAB.aspx">NAB Debit</asp:LinkButton>
                            
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
   <%-- <br />--%>
            <table align="left" class="w100">
                         <tr>
                            <td colspan="3" class="align_width_less">
                            <p>
                            &nbsp;&nbsp;<img alt="Logo" src="../Images/nabLogoHP.gif" width="40" height="60" />&nbsp; <b>NAB Debit File</b></p>
                            </td>
                        </tr> 
                        <tr>
                            <td style="width:5px; padding-bottom:20px;">
                                <img src="../Images/White_Right_Arrow.GIF" alt="" style="margin-left:60px;" />
                                <asp:Label ID="label2" runat="server" CssClass="label_style">Please enter a Date:</asp:Label>
                            </td>
                            <td>
                                <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
                                EnableScriptLocalization="true" ID="ScriptManager1" />
                                <asp:TextBox ID="Txt_date" runat="server" style="width:100px;margin-bottom:20px; " CssClass="align-center_teller"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Txt_date" format="dd-MMM-yyyy"     OnClientShowing="showDate" FirstDayOfWeek="Sunday">
                                </ajaxToolkit:CalendarExtender>
                                
                            </td>
                            <td  >
                               
                             
                            </td>
                        </tr>
                        
                        <tr>
                            <td></td>
                            <td>
                               <asp:Button ID="Button1" runat="server" Text="Create Customer List for NAB Debit File" CssClass="btn_BankFile"  />  
                            </td>
                            <td></td>
                        </tr>
                        <tr >
                            <td colspan="3" style="height: 25px;">
                            
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" valign="top">
                                
                                <asp:GridView ID="GridView1" runat="server" 
                                    AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Size="14px" 
                                    ForeColor="Black" RowHeaderColumn="Customer Id" Width="95%" 
                                    CellSpacing="2"  style="margin-left:30px; margin-top: 20px" PageSize="5"  ShowFooter="True">
                                     <RowStyle BackColor="White" HorizontalAlign="Left" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                                    <Columns>
                                    <asp:BoundField DataField="Customer_ID" HeaderText="CustomerID" />
                                    <asp:BoundField DataField="Given_Name" HeaderText="Given Name" />
                                    <asp:BoundField DataField="Last_Name" HeaderText="Last Name" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:c}" />
                                    <asp:BoundField DataField="BSB" HeaderText="BSB" />
                                    <asp:BoundField DataField="Account_Number" HeaderText="Account Number" />
                                    <asp:BoundField DataField="Loan_Type" HeaderText="Type" />
                                    <asp:BoundField DataField="Loan_ID" HeaderText="Loan ID" />
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:GridView>
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: right;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: center;">
                                <br />
                                     <asp:Button ID="cancel" runat ="server"  Text="Cancel & go back" Visible="false" CssClass="align_mid" />&nbsp;&nbsp;
                                       <asp:Button ID="debit_nab" runat="server"  Text="Create Debit file"  Visible="false" CssClass="align_mid" OnClientClick ="Confirm();"/>&nbsp;&nbsp;
                                       <asp:Button ID="nab_print" runat="server"  Text="View & Print" Visible="false" CssClass="align_mid"  />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: center;">
                                 <br />
                                    <asp:Panel ID="Panel_nab" runat="server" >
                                    <div align="center">
                                    <table class="table_AddBank">
                                    <tr>
                                    <td class="align-center">
                                        <asp:Label ID="Label_nab" runat="server"  CssClass ="rptHead_new " Text="List NAB Debit Files:"  ></asp:Label>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="align-center" >
                                   
                                    <asp:GridView ID="GridView_nab" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Size="14px" AllowPaging="True"  PageSize="10"  OnPageIndexChanging="PageIndexChanging" AllowSorting="False"  OnSorting="Sorting"
                                    ForeColor="Black" RowHeaderColumn="Customer Id"  
                                    CellSpacing="2"   style="margin-bottom: 0px" 
                                    Width="50%" DataKeyNames ="Name_NAB_Files">
                                     <RowStyle BackColor="White" HorizontalAlign="Left" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                                    <Columns>
                                    
                                   <asp:BoundField DataField="Name_NAB_Files" HeaderText="File Name"  SortExpression="Name_NAB_Files" />
                                        <asp:BoundField DataField="Date_Created" HeaderText="Date Created"  SortExpression="Date_Created" />
                                   <asp:TemplateField HeaderText="File Path">
                                   <ItemTemplate>
                                    <asp:ImageButton ImageUrl="~/Images/download.png" ID="lnkDownload_nab" runat="server" Text="Download" ToolTip="Download NAB File" OnClick="lnkDownload_Click"  />
                                   
                                   </ItemTemplate>
                                       <ItemStyle HorizontalAlign="Center" />
                                   </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                                    <SelectedRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
                                      </asp:GridView>  
                                      </td>
                                      </tr>
                                      <tr>
                                        <td class="align-center">
                                        <br />
                                      <asp:Button ID="Button_ShowAll" runat="server" Text="Show All" />
                                            <asp:Button ID="Button_Hidden" runat="server" Text="Hidden" Visible="false" />
                                          </td>
                                      </tr>
                                      </table>
                                      </div>
                                      </asp:Panel>    
                                      
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