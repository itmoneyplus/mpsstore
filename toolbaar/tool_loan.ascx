<%@ Control Language="VB" AutoEventWireup="false" CodeFile="tool_loan.ascx.vb" Inherits="toolbaar_Toolbaar2" %>
<head>
    <title>tool_loan</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
      <script type="text/javascript" language="javascript">
          function ConfirmSubmit(var1) {
            //  alert(var1);
              if (var1 == 1) {
                  return confirm('This email has been already sent, do you want resend? ');
              }
              if (var1 == 0) {
                  return confirm('Do you want to send approval email?');
              }
          }
          function ConfirmTransfer(var1) {
              // alert(var1);
              if (var1 == 1) {
                  return confirm('This email has been already sent, do you want resend? ');
              }
              if (var1 == 0) {
                  return confirm('Do you want to send transfer email?');
              }
          }
    </script>
</head>
<div align="center">
    <asp:Label ID="lbldebt" runat="server" Visible="false" CssClass="normal-doc_debt"></asp:Label>
    <br />
    <asp:Label ID="lbldebt_date" runat="server" Visible="false" CssClass="td"></asp:Label>
    <table cellspacing="0" class="toolbaar2_table">
        <tr>
            <td class="align">
                <asp:Label ID="Label2" runat="server" Text="Loan Application Summary" CssClass="italics1-doc"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;<b>
                    <asp:GridView ID="GridView1" runat="server" 
    AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Size="14px" 
    ForeColor="Black" RowHeaderColumn="Customer Id" Width="95%" 
    CellSpacing="2"  style="margin-left:30px; margin-top: 20px">
                         <RowStyle BackColor="White" HorizontalAlign="Left" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px"/>
                        <Columns>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="no" HeaderText="No" Visible="False" />
                            <asp:BoundField DataField="loan_date" DataFormatString="{0:d-MMM-yyyy}" HeaderText="Date" />
                            <asp:BoundField DataField="loan_id" HeaderText="Loan ID" />
                            <asp:BoundField DataField="amountout" HeaderText="Amount Outstanding" />
                            <asp:BoundField DataField="amount" HeaderText="Amount Approved" />
                            <asp:BoundField DataField="amount" HeaderText="Amount Declined" />
                            <asp:BoundField DataField="last_notice" HeaderText="Last Notice" />
                            <asp:BoundField DataField="last_paymentdate" HeaderText="Last Payment" />
                            <asp:BoundField DataField="noofdis" HeaderText="Dishonours" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="Appr.">
                            <ItemTemplate>
                            <%--<asp:ImageButton  runat="server" ID="ibApproved" ImageUrl="~/Images/approved.gif" ImageAlign="Middle" AlternateText="Approved"  OnClientClick='javascript:return ConfirmSubmit(<%#Eval("Email_approved") %>)' CommandArgument='<%#Eval("loan_id") %>' CommandName="approved"/>--%>
                            <asp:ImageButton  runat="server" ID="ibApproved" ImageUrl="~/Images/approved.gif" ImageAlign="Middle" AlternateText="Approved"  OnClientClick='<%#Eval("Email_approved","javascript:return ConfirmSubmit({0});")%>' CommandArgument='<%#Eval("loan_id") %>' CommandName="approved"/>
                            <asp:Label runat="server" ID="lblCustID" Text ='<%#Eval("customer_id") %>' Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblEmail" Text ='<%#Eval("Email") %>' Visible="false"></asp:Label>
                            
                            </ItemTemplate>
                            
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Trans">
                            <ItemTemplate>
                             <asp:ImageButton  runat="server" ID="ibTransfer" ImageUrl="~/Images/transfer.png" ImageAlign="Middle" AlternateText="Transfer" OnClientClick='<%#Eval("Email_Transfer","javascript:return ConfirmTransfer({0});")%>' CommandArgument='<%#Eval("loan_id") %>' CommandName="transfer" />
                            </ItemTemplate>
                            
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="black" HorizontalAlign="Center" VerticalAlign="Middle" />
            <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
                    </asp:GridView>
                    <asp:Label ID="Label5" runat="server" Text="No Loans Found" Visible="false" CssClass="italics1-doc">
                    </asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <b>&nbsp; </b>
            </td>
        </tr>
        <tr>
            <td class="toolbaar2td">
                <asp:Label ID="Label3" runat="server" Text="Total Outstanding:" Visible="false"></asp:Label>
                &nbsp;<asp:Label ID="Label6" runat="server" Text="$" Visible="False"></asp:Label>&nbsp;<asp:Label
                    ID="Label4" runat="server" Text="Label" Visible="false"></asp:Label></td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr runat="server" id="trEmail" visible="false">
            <td align="left" >
            <p> <b>Email History:</b></p>
                <asp:GridView ID="gvEmail" runat="server" AutoGenerateColumns="False" Width="90%" BackColor="#CCCCCC"
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" Font-Size="13px"
                        ForeColor="Black" RowHeaderColumn="Customer Id" CellSpacing="2"
                        Font-Bold="True">
                         <RowStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" BorderStyle="Solid"
                            BorderWidth="1px" Font-Size="13px" />
                    <Columns>
                        <asp:BoundField HeaderText="Email" DataField="CustEmail" />
                         <asp:BoundField HeaderText="Sent Date & Time" DataField="CustEmailSent" />
                        <asp:TemplateField HeaderText="Print" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>                        
                            <asp:ImageButton ID="ibPrint" runat="server"  ImageUrl="~/Images/print.png" Height="22px" Width="22px" CommandName="print" CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" />
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                        <ItemTemplate>
                        <div style="display:none;">
                            <asp:Panel ID="pnlPrint" runat="server">
                                <asp:Label ID="lblText" runat="server" Text='<%# Eval("CustEmailBody") %>'></asp:Label>
                            </asp:Panel>
                        </div>
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="black" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <%-- <FooterStyle BackColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Maroon" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                            VerticalAlign="Middle" />--%>
                </asp:GridView>
                <p>&nbsp;</p>
            </td>
        </tr>
    </table>
</div>
