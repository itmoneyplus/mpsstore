<%@ Control Language="VB" AutoEventWireup="false" CodeFile="feelist.ascx.vb" Inherits="toolbaar_feelist" %>
<head>
    <title>feelist</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
</head>
<div align="center">
    <asp:Panel ID="panel2" runat="server">
        <table class="table_noborder">
            <tr>
                <td class="align_width " colspan="3">
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="align_width">
                    1. Credit ref report fee:
                </td>
                <td class="align">
                    <b>$</b><asp:TextBox ID="txtCreditRefReportFee" runat="server" Width="55px" CssClass="align-center"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="align">
                    2. Guarantee preparation:
                </td>
                <td class="align">
                    <b>$</b><asp:TextBox ID="txtGuaranteePreparation" runat="server" Width="55px" CssClass="align-center"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="align">
                    3. Bill of sale preparation:
                </td>
                <td class="align">
                    <b>$</b><asp:TextBox ID="txtBillOfSalePreparation" runat="server" Width="55px" CssClass="align-center"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="align">
                    4. REVs inquiry:
                </td>
                <td class="align">
                    <b>$</b><asp:TextBox ID="txtREVsInquiry" runat="server" Width="55px" CssClass="align-center"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="align">
                    5. REVs registration:
                </td>
                <td class="align">
                    <b>$</b><asp:TextBox ID="txtREVsRegistration" runat="server" Width="55px" CssClass="align-center"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="align">
                    6. Stamping:
                </td>
                <td class="align">
                    <b>$</b><asp:TextBox ID="txtStamping" runat="server" Width="55px" CssClass="align-center"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="align">
                    7. Valuation:
                </td>
                <td class="align">
                    <b>$</b><asp:TextBox ID="txtValuation" runat="server" Width="55px" CssClass="align-center"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="align">
                    <b>Loan amount including fee and charges:</b>
                </td>
                <td class="align">
                    <b>$</b><asp:TextBox ID="txtTotal" runat="server" Width="55px" CssClass="align-center"
                        Height="22px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
