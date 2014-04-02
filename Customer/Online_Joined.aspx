<%@ Page Language="VB" EnableEventValidation="false" Culture="en-AU" AutoEventWireup="false"
    CodeFile="Online_Joined.aspx.vb" Inherits="Reports_MoneyPlus_Online_Joined" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>
<%@ Register Src="~/toolbaar/Reporttabs.ascx" TagName="Toolbaar_Rep" TagPrefix="tool_rep1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
    <title>Online Joined</title>
    <%--   CSS used--%>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
   
    <script type="text/javascript">

        function showDate(sender, args) {
            if (sender._textbox.get_element().value == "") {
                var todayDate = new Date();
                sender._selectedDate = todayDate;
            }
        }
       
  
    </script>
  

</head>
<body>
    <form id="form1" runat="server">
    <div class="align">
        <tool1:Toolbaar1 ID="tool1" runat="server" />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server">
            &nbsp;&nbsp;<span class="italics1-doc-new"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Online
                Joined Report</span>
            <br />
            <div align="center">
                <table cellspacing="0" style="width: 78%; border: 1px solid gray">
                    <tr>
                        <td>
                            <br />
                            <br />
                            <div style="text-align: left">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp; &nbsp;<img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                    height="10" />
                                <asp:Label ID="label1" runat="server" CssClass="label_style">Please enter a beginning date:</asp:Label>
                                <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
                                    EnableScriptLocalization="true" ID="ToolkitScriptManager1" />
                                <asp:TextBox ID="txtfrom" runat="server" CssClass="align-center" Style="width: 100px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfrom"
                                    Format="dd-MMM-yyyy" FirstDayOfWeek="Sunday" CssClass="red" OnClientShowing="showDate">
                                </ajaxToolkit:CalendarExtender>
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp; &nbsp;<img alt="Select Date" height="10" src="../Images/White_Right_Arrow.gif"
                                    width="10" />
                                <asp:Label ID="label2" runat="server" CssClass="label_style">Please enter an ending date:</asp:Label>
                                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtto" runat="server" CssClass="align-center"
                                    Style="width: 100px"> </asp:TextBox>&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button1" runat="server" Text="Create Online Joined Report" CssClass="button_border" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtto"
                                    Format="dd-MMM-yyyy" FirstDayOfWeek="Sunday" CssClass="red" OnClientShowing="showDate">
                                </ajaxToolkit:CalendarExtender>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                            <div align="center">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                    BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="14px"
                                    ForeColor="Black" RowHeaderColumn="Customer Id" Width="100%" Height="70%" Font-Bold="True"
                                    PageSize="5" CssClass="align-center" CaptionAlign="Top" ShowFooter="True">
                                    <RowStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" BorderStyle="Solid"
                                        BorderWidth="1px" Font-Size="14px" />
                                    <RowStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" BorderStyle="Solid"
                                        BorderWidth="1px" Font-Size="14px" />
                                    <Columns>
                                        <%-- <asp:TemplateField ShowHeader="false">
        <ItemTemplate>
        <asp:CheckBox ID="chkid" runat="server" />
        </ItemTemplate>
        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="No.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Customer-id" DataField="Customer_ID" />
                                        <asp:BoundField HeaderText="Customer Name" DataField="Given_Name" ItemStyle-CssClass="align">
                                            <ItemStyle CssClass="align" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Last_name" />
                                        <asp:BoundField HeaderText="Request Amount" DataFormatString="{0:c}" DataField="Request_Amount" />
                                        <asp:BoundField HeaderText="Date Joined" DataField="Date_Joined" DataFormatString="{0:d}" />
                                        <asp:BoundField HeaderText="Time" DataField="Time_Joined" DataFormatString="{0:hh:mm tt}" />
                                        <asp:BoundField DataField="Current_Bank_Statement" HeaderText="Documents"  />
                                        <asp:BoundField DataField="cust_enable" HeaderText="Printed"  Visible="false"/>
                                      <asp:TemplateField HeaderText="Emailed">
                                        <ItemTemplate>
                                        <img src="../Images/email_sent.png" visible='<%#Eval("email_sent") %>' runat="server" id="imgemail"  alt=""/>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" Text="Select" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkCustID" runat="server" CssClass="chk" />
                                            
                                            <asp:Label ID="lblCustEmail" runat="server" Text='<%#Eval("Email") %>' Visible="false"></asp:Label>
                                             <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("Given_Name") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("Customer_ID") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" BorderColor="Black"
                                        BorderStyle="Solid" BorderWidth="1px" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                        VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="Maroon" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                        VerticalAlign="Middle" />
                                    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                                <br />
                                <asp:Button ID="btnre" runat="server" Text="Re-Create Again" Visible="false" CssClass="align_mid" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnview" runat="server" Text="View & Print" Visible="false" CssClass="align_mid" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnEmail" runat="server" Text="Send Email" Visible="false" CssClass="align_mid" OnClientClick="this.disabled='true'; this.value='Processing please wait...'; this.width='150px';" UseSubmitBehavior="False"   />
                                <br /><br />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
     <script src="../scripts/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            var headerChk = $("input[id*='chkAll']:checkbox");
            var itemChk = $("input[id*='chkCustID']:checkbox");

            headerChk.click(function() {
                itemChk.each(function() {
                    this.checked = headerChk[0].checked;
                })
            });

            itemChk.each(function() {
                $(this).click(function() {
                    if (this.checked == false) { headerChk[0].checked = false; }
                })
            });

            $('#<%=btnEmail.ClientID%>').click(function() {
              //  alert("hi");
                var chkboxrowcount = $("#<%=GridView1.ClientID%> input[id*='chkCustID']:checkbox:checked").size();
                if (chkboxrowcount == 0) {
                    alert("Please select at least one customer");
                    return false;
                }
                return true;
            });
        });

  
        
        </script>
         <%-- <script type="text/javascript">
              function CheckBox_Validation() {
                  var valid = false;
                  var gdvw = document.getElementById('<%= GridView1.ClientID %>');
                  for (var i = 1; i < gdvw.rows.length; i++) {
                      var value = gdvw.rows[i].getElementsByClassName('chk');
                    
                      if (value != null) {
                          if (value[0].type == "checkbox") {
                              if (value[0].checked) {
                                  valid = true;
                                  alert("Checkbox selected successfully");
                                  return true;
                              }
                          }
                      }
                  }
                  alert("Please select atleast one checkbox");
                  return false;
              }
    </script>--%>
    </form>
      

</body>
</html>
