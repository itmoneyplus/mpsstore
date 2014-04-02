<%@ Page Language="VB" Culture="en-AU" AutoEventWireup="false" CodeFile="Contract dishonour.aspx.vb"
    Inherits="Customer_Contract_dishonour" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Notice Using:</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript">
        window.history.forward(1);
        function new_page() {
            window.location.assign("LoanSummary.aspx");
        }
    </script>

</head>
<body ondblclick="new_page();" onload="window.print();">
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <table class="MsoTableGrid" width="562" style="margin-left: .6in; border-style: none"
                cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <img src="../Images/MPNoticeLogo.jpg" alt="logo" style="height: 82px; width: 191px" />
                    </td>
                </tr>
                <tr>
                    <td class="rep_font_new">
                        This notice is sent by Geeghis Pty Ltd
                    </td>
                </tr>
                <tr>
                    <td class="rep_font_new">
                        (ABN 93 139 094 625) T/as Moneyplus
                    </td>
                </tr>
                <tr>
                    <td class="rep_font_new">
                        Netlending on behalf of the credit
                    </td>
                </tr>
                <tr>
                    <td class="rep_font_new">
                        provider Abaz Pty Ltd. Australian
                    </td>
                </tr>
                <tr>
                    <td class="rep_font_new">
                        credit licence number 391104
                    </td>
                </tr>
                <tr>
                    <td class="align-right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align-right">
                        <b>
                            <asp:Label ID="lblstdetail" runat="server" CssClass="rep_font"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <td class="align-right">
                        <b>
                            <asp:Label ID="lblcnctdetail" runat="server" CssClass="rep_font"></asp:Label>
                        </b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="rep_font">
                        <span><b>DIRECT DEBIT DEFAULT NOTICE(Dishonour)</b></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblname" runat="server" CssClass="rep_font"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbladd" runat="server" CssClass="rep_font"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblst" runat="server" CssClass="rep_font"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbltitle" runat="server" CssClass="rep_font"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="rep_font">
                        RE: <b style="text-decoration: underline">Payment Default</b><br />
                    </td>
                </tr>
                <tr>
                    <td class="rep_font">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Loan Contract No:<asp:Label ID="lbllnno"
                            runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="rep_font">
                        Your loan repayment for <b>$<asp:Label ID="lblamt" runat="server"></asp:Label></b>&nbsp;due
                        on
                        <asp:Label ID="lbldt" runat="server" CssClass="rep_font1"></asp:Label>
                        &nbsp;has not been received.This loan has incurred a dishonour fee of&nbsp;
                        <asp:Label ID="lblfee" runat="server" CssClass="rep_font1"></asp:Label>&nbsp;
                        <asp:Label ID="lblvar" runat="server" Text="and a variation fee of">
                        </asp:Label>&nbsp;<asp:Label ID="lblvarfee" runat="server" CssClass="rep_font1"></asp:Label>.<br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="rep_font">
                        This payment needs to be rescheduled. Please Contact us on 02&nbsp;9621&nbsp;4446 to make 
                        an arrangement.
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="rep_font">
                        Please be aware should a repayment be outstanding more than 60 days this may be
                        reported to a Credit Reporting Agency (i.e.Veda).
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr class="align ">
                    <td class="rep_font">
                        Manager
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="rep_font ">
                        <b style="text-decoration: underline">Important Notice:</b>
                    </td>
                </tr>
                <tr>
                    <td class="rep_font">
                        All accounts in arrears will incur administration or enforcement fees
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
