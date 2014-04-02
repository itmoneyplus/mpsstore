<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Pay_Receipt.ascx.vb"
    Inherits="toolbaar_Pay_Receipt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
    <title>Payment Receipt</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
</head>
<div align="center">
    <asp:Panel ID="Panel1" runat="server">
        <table cellspacing="0" class="payreceipt_table">
            <tr>
                <td style="font-size: medium; font-weight: bold; text-align: left; height: 22px">
                    Payment Receipt
                </td>
            </tr>
            <tr>
                <td style="border-top: 1px solid gray; width: 50%; vertical-align: top">
                    <br />
                    <br />
                    <div class="align">
                        &nbsp;&nbsp;&nbsp;&nbsp;<img alt="Select Date" src="../Images/White_Right_Arrow.gif"
                            width="10" height="10" />
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="label_style">Please enter statement start date:</asp:LinkButton>
                        &nbsp;
                        <asp:TextBox ID="txtfrom" runat="server" CssClass="align-centernew"></asp:TextBox><ajaxToolkit:CalendarExtender
                            ID="CalendarExtender1" runat="server" TargetControlID="txtfrom" Format="dd-MMM-yyyy"
                            FirstDayOfWeek="Sunday">
                        </ajaxToolkit:CalendarExtender>
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;<img alt="Select Date" src="../Images/White_Right_Arrow.gif"
                            width="10" height="10" />
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="label_style">Please enter statement end date:</asp:LinkButton>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="txtto" runat="server" CssClass="align-centernew"></asp:TextBox><ajaxToolkit:CalendarExtender
                            ID="CalendarExtender2" runat="server" TargetControlID="txtto" Format="dd-MMM-yyyy"
                            FirstDayOfWeek="Sunday">
                        </ajaxToolkit:CalendarExtender>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnsearch" runat="server" Text="Search for receipt" Style="height: 26px" />&nbsp;&nbsp;&nbsp;
                        <br />
                        <br />
                        <br />
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        <table cellspacing="0" class="payreceipt_tablenew">
            <tr>
                <td>
                    <div class="align">
                        <asp:Label ID="lbl_head" runat="server" Visible="false"></asp:Label>
                        <br />
                    </div>
                    <br />
                    <div class="align-center">
                        <asp:UpdatePanel ID="CollapseDelegate" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <asp:Button ID="btnsearchagn" runat="server" Text="Go Back and Search Again" Visible="false" />&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnprntre" runat="server" Text="Print Receipt" Visible="false" />
                    </div>
                </td>
            </tr>
        </table>
       
    </asp:Panel>
     <br />
</div>
