<%@ Control Language="VB" AutoEventWireup="false" CodeFile="loanrepay.ascx.vb" Inherits="toolbaar_loanrepay" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
    <title>Loan Repayment</title>
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
<div align="center" id="MainContainer_loanrepay">
    <table class="table_loan_repay" align="center">
        <tr>
            <td class="td_repay">
                Loan Repayments
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Payment Amount:" Width="15%" CssClass="lbl_repay"></asp:Label>
                <b>$</b>
                <asp:TextBox ID="txtPaymentAmount" runat="server" Width="5%" BorderColor="Silver"
                    BorderStyle="Ridge" MaxLength="8" TabIndex="2"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Label CssClass="lbl_repay" ID="lblRetHead" runat="server" Text="Return: &nbsp; $" Visible="false" ForeColor="Red"></asp:Label>    <asp:Label ID="lblReturn" runat="server" Font-Bold="true" Text="" ForeColor="Red" Visible="false" CssClass="lbl_repay"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblTeller" runat="server" Text="Teller" CssClass="lbl_repay" Width="5%"></asp:Label>
                <asp:DropDownList ID="ddlTeller" runat="server">
                 <asp:ListItem Value="0" Text="--Select--" />
                 <asp:ListItem Value="1" Text="Teller 1" />
                 <asp:ListItem Value="2" Text="Teller 2" />
                 <asp:ListItem Value="3" Text="Teller 3" />
                <asp:ListItem Value="4" Text="Teller 4" />
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Add Payments:" Width="12%" CssClass="lbl_repay"></asp:Label>
                <asp:TextBox ID="txtaddpaymnt" runat="server" Width="5%" BorderColor="Silver" BorderStyle="Ridge"
                    MaxLength="4" TabIndex="3"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Payment Frequency:" Width="16%" CssClass="lbl_repay"></asp:Label>
                &nbsp;
                <asp:DropDownList ID="Drppayfreq" runat="server" Width="10%" TabIndex="4">
                    <asp:ListItem Value="7">Weekly</asp:ListItem>
                    <asp:ListItem Value="14">Fortnightly</asp:ListItem>
                    <asp:ListItem Value="30">Monthly</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <table class="table_toolbaar_new">
                    <tr>
                        <td colspan="3">
                          <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
                                EnableScriptLocalization="true" ID="ScriptManager1" />
                            <asp:UpdatePanel ID="CollapseDelegate" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                          </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="td_ht">
                            <asp:Button ID="btnshow" runat="server" Text="Show" Width="50px" Height="26px" CssClass="td_ht"
                                TabIndex="5" />
                            &nbsp;
                            <asp:Button ID="btnacpt" runat="server" Text="Accept Payment" Width="115px" Height="26px"
                                CssClass="td_ht" TabIndex="6" />
                            &nbsp;
                            <asp:Button ID="btnmodsch" runat="server" Text="Modify Schedule" Width="115px" Height="26px"
                                CssClass="td_ht" TabIndex="7" />
                            &nbsp;
                            <asp:Button ID="btnwaive" runat="server" Text="Waive" Width="55px" Height="26px"
                                CssClass="td_ht" TabIndex="8" />
                            &nbsp;
                            <asp:Button ID="btncancel" runat="server" Text="Cancel Payment" Width="115px" Height="26px"
                                CssClass="td_ht" TabIndex="9" />
                            &nbsp;
                            <asp:Button ID="btnenfee" runat="server" Text="Add Enforcement Fee" Width="145px"
                                Height="26px" CssClass="td_ht" TabIndex="10" />
                            &nbsp;
                            <asp:Button ID="btnmake_dis" runat="server" Text="MakeDishonour" Enabled="false"
                                Visible="false" Width="110px" Height="26px" CssClass="td_ht" TabIndex="11" />
                            &nbsp;
                            <asp:Button ID="btncon_dis" runat="server" Enabled="false" Text="Contract Dishonour"
                                Visible="false" Width="130px" Height="26px" CssClass="td_ht" TabIndex="12" />
                        </td>
                    </tr>
                    <tr>
                        <td class="align-center" colspan="3">
                            &nbsp;&nbsp;
                            <asp:Button ID="btnwaive1" runat="server" Text="Waive Selected Payment" Visible="false"
                                Width="190px" Height="26px" />&nbsp;&nbsp;
                            <asp:Button ID="btncncl" runat="server" Text="Cancel" Width="70px" Visible="false"
                                Height="26px" />&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="align-center" colspan="3">
                            <asp:Button ID="btnenfrc" runat="server" Text="Save Enforcement Fee" Visible="false"
                                Width="190px" CssClass="position" />&nbsp;&nbsp;
                            <asp:Button ID="btncncl_enf" runat="server" Text="Cancel" Width="70px" Visible="false"
                                CssClass="position_cncl" />&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="align-center" colspan="3">
                            <asp:Button ID="btncncl_save" runat="server" Text="Save Cancelled Payment" Visible="false"
                                Width="190px" CssClass="position" />&nbsp;&nbsp;
                            <asp:Button ID="btncnl_cncl" runat="server" Text="Cancel" Width="70px" Visible="false"
                                CssClass="position_cncl" />&nbsp;&nbsp;
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="align-center" colspan="3">
                            <asp:Button ID="btnsave_pay" runat="server" Text="Save Payment" Visible="false" Width="180px"
                                CssClass="position" />&nbsp;&nbsp;
                            <asp:Button ID="btncncl_pay" runat="server" Text="Cancel" Width="70px" Visible="false"
                                CssClass="position_cncl" />&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="align-center" colspan="3">
                            <asp:Button ID="btnsave_mod" runat="server" Text="Save Modified Schedule" Visible="false"
                                Width="190px" CssClass="position" />&nbsp;&nbsp;
                            <asp:Button ID="btncncl_mod" runat="server" Text="Cancel" Width="70px" Visible="false"
                                CssClass="position_cncl" />&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="align-center" colspan="3">
                            <asp:Button ID="btnsave_dis" runat="server" Text="Save Dishonoured Payment" Visible="false"
                                Width="190px" CssClass="position" />&nbsp;&nbsp;
                            <asp:Button ID="btncncl_dis" runat="server" Text="Cancel" Width="70px" Visible="false"
                                CssClass="position_cncl" />&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </td>
        </tr>
    </table>
</div>
