<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Loan_Aprroved_Email.aspx.vb"
    Inherits="Customer_Loan_Aprroved_Email" %>

<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>
<%@ Register Src="~/toolbaar/tool_loan.ascx" TagName="Toolbaar2" TagPrefix="tool2" %>
<%@ Register Src="~/toolbaar/tool.ascx" TagName="Toolbaar3" TagPrefix="tool3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loan Approved Email</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript">
        window.history.forward(1);
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <tool1:Toolbaar1 ID="tool_first" runat="server" />
        <br />
        <br />
        <table cellpadding="0" cellspacing="0" align="center" width="800px;">
            <tr>
                <td>
                    <tool3:Toolbaar3 ID="tool3" runat="server" />
                    <br />
                    To:
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    <br />
                    <br />
                    Body:<br />
                    <iframe runat="server" id ="ifrmEmail" height="250px" width="800px" scrolling="yes"></iframe>
                    <asp:Label runat="server" ID="dvEmail" Height="250px" Width="800px" Visible="false" Style="overflow: scroll;"></asp:Label>
                    <br />
                    Attachment:<asp:FileUpload ID="flAttachment" runat="server" /><br />
                    <br />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSend" runat="server" Text="Send Email" CssClass="btn" OnClientClick="this.disabled='true'; this.value='Processing please wait...'; this.width='150px';"
                        UseSubmitBehavior="False" />
                    <asp:HiddenField ID="hdCustID" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
