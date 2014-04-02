<%@ Page Language="VB" AutoEventWireup="false" CodeFile="grid.aspx.vb" Inherits="test_grid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../css/style.css"  rel="Stylesheet"/>
    <link href="../css/redmond/jquery-ui-1.10.3.custom.min.css" rel="Stylesheet"/>
    <script src="../scripts/jquery.js" type="text/javascript"></script>
    <script src="../scripts/jquery-ui-custom-min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
        $(".cal").datepicker({
			changeMonth: true,
			changeYear: true,
			dateFormat: 'dd-M-yy' 
		});

		var headerChk = $("input[id*='chkAll']:checkbox");
		var itemChk = $("input[id*='chkSelect']:checkbox");

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

		$('#<%=btnAccept.ClientID%>').click(function() {
		    //  alert("hi");
		var chkboxrowcount = $("#<%=gvPayment.ClientID%> input[id*='chkSelect']:checkbox:checked").size();
		    if (chkboxrowcount == 0) {
		        alert("Please select the payment number you want to accept!!!");
		        return false;
		    }
		    return true;
		});
		
        });
	</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
       Payment Amount: <asp:TextBox ID="txtAmount" runat="server" Width="80px"></asp:TextBox>
       <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Please enter a valid payment amount" ControlToValidate="txtAmount" Display="None" ValidationGroup="accept" MinimumValue="1" MaximumValue="9999" Type="Double"></asp:RangeValidator>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtAmount" runat="server" ErrorMessage="Please enter the amount" ValidationGroup="accept" Display="None"></asp:RequiredFieldValidator>
        <asp:Label ID="lblRetrun" runat="server" Text="Return" Visible="false" ForeColor="Red"></asp:Label> &nbsp;<asp:Label ID="lblReturnAmtValue" runat="server" Visible="false" ForeColor="Red"></asp:Label><p></p>
        <asp:GridView ID="gvPayment" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="tblreport">
            <Columns>
                <asp:TemplateField HeaderText="No">
                    <ItemTemplate>
                   <%# Container.DataItemIndex + 1 %>
                     <asp:Label ID="lblPaymentID" runat="server" Text='<%#eval("Payment_ID") %>' Visible="false"></asp:Label>
                      <asp:Label ID="lblMode" runat="server" Text='<%#eval("Mode") %>' Visible="false"></asp:Label>
                      <asp:Label ID="lblPaymentSatus" runat="server" Text='<%#Eval("Payment_Status") %>' Visible="false"></asp:Label>
                      <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("Customer_ID") %>' Visible="false"></asp:Label>
                      
                      
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Select">
                <HeaderTemplate>
               <asp:CheckBox ID="chkAll" runat="server" Text="Select" />
                </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lblDesc" runat="server" Text='<%#eval("Description") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Due Date">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDueDate" runat="server" CssClass="cal" Text='<%#eval("Due_Date" , "{0:dd-MMM-yyyy}") %>'  Width="80px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        $<asp:TextBox ID="txtAmount" runat="server" Text='<%#Eval("Amount","{0:0.00}") %>' ReadOnly="true" Width="60px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Paid">
                    <ItemTemplate>
                     <a href="javascript:alert('P stands for payment status');">  <asp:Label ID="lblPaid" runat="server" Text="P"></asp:Label></a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Payment Date">
                    <ItemTemplate>
                        <asp:Label ID="lblPaymentDate" runat="server"  Text='<%#eval("Payment_Date" , "{0:dd-MMM-yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Payment Method">
                    <ItemTemplate>
                      <asp:Label ID="lblPaymentMethid" runat="server" Text='<%#Eval("Payment_Method") %>'></asp:Label>
                      <asp:DropDownList ID="drpPaymentMethod"  runat="server" Visible="false"> 
                          <asp:ListItem Value="NAB">NAB</asp:ListItem>
                          <asp:ListItem Value="Cas">Cas</asp:ListItem>
                          <asp:ListItem Value="Sal">Sal</asp:ListItem>
                          <asp:ListItem Value="Chq">Chq</asp:ListItem>
                          <asp:ListItem Value="CBA">CBA</asp:ListItem>
                          <asp:ListItem Value="Cre">Cre</asp:ListItem>
                          <asp:ListItem Value="Def">Def</asp:ListItem>
                          <asp:ListItem Value="HOD">HOD</asp:ListItem>
                          <asp:ListItem Value="WOF">WOF</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transaction Description">
                    <ItemTemplate>
                        <asp:Label ID="lblTransDesc" runat="server" Text='<%#Eval("Transaction_Status") %>' ></asp:Label>
                        <asp:RadioButton ID="rbDishonoure" runat="server"  Visible="false"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transaction Date">
                    <ItemTemplate>
                        <asp:Label ID="lblTransDate" runat="server" Text='<%#Eval("Transaction_Date", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hdRowIndex" runat="server" Value="0" />
    </div>
    <p></p>
    <asp:Panel ID="pnlAbove" runat="server">
  
    <asp:Button ID="btnHide" runat="server" Text="Hide" Visible="False" />&nbsp;
    <asp:Button ID="btnShow" runat="server" Text="Show" />&nbsp;
    <asp:Button ID="btnAccept" runat="server" Text="Accept Payment" ValidationGroup="accept" />&nbsp;
    <asp:Button ID="btnModify" runat="server" Text="Modify Schedule" />&nbsp;
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="accept"  ShowMessageBox="True" ShowSummary="False" />
      </asp:Panel>
      <asp:panel ID="pnlBelow" runat="server">
      <asp:Button ID="btnAccepotOk" runat="server" Text="Save Payment" Visible="false" />&nbsp;
      <asp:Button ID="btnAccepotCancel" runat="server" Text="Cancel" Visible="false" />
      <asp:Button ID="btnModifyOK" runat="server" Text="Save Modified Scheduled" Visible="false" />&nbsp;
      <asp:Button ID="btnModifyCancel" runat="server" Text="Cancel" Visible="false" />
      </asp:panel>
    </form>
</body>
</html

>
