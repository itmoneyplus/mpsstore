<%@ Page Language="VB" AutoEventWireup="false" CodeFile="loan_preapproval.aspx.vb"
    Inherits="email_loan_preapproval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>email</title>
    <link rel="stylesheet" href="../css/print.css" type="text/css" media="print" />
    <style type='text/css'>
        body
        {
            background-color: #ffffff;
            color: #000000;
            font-family: Arial, Helvetica, sans-serif;
        }
        *
        {
            margin: 0px;
            padding: 0px;
        }
        .footer
        {
            background-color: #fff;
            height: 21px;
            line-height: 20px;
            text-align: left;
            color: #000;
            padding-left: 5px;
            padding-right: 5px;
            font-size: 12px;
        }
        .heading
        {
            color: #000;
            font-size: 16px;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            padding-bottom: 8px;
            padding-top: 8px;
            text-align: left;
            vertical-align: middle;
        }
        .padding
        {
            padding-left: 5px;
            padding-right: 5px;
        }
        .name
        {
            font-style: normal;
            font-weight: bold;
            color: #666666;
            text-decoration: none;
            text-align: left;
            font-size: 14pt;
        }
        .name a
        {
            font-style: normal;
            font-weight: bold;
            color: #666666;
            text-decoration: none;
            text-align: left;
        }
        .name a:hover
        {
            font-style: normal;
            font-weight: bold;
            color: #666666;
            text-decoration: none;
            text-align: left;
        }
        .namenormal
        {
            font-size: 14pt;
            font-style: normal;
            font-weight: normal;
            color: #666666;
            line-height: 25px;
            text-align: left;
        }
        p
        {
            font-size: 14px;
            font-style: normal;
            font-weight: normal;
            color: #666666;
            line-height: 25px;
            text-align: left;
            margin-top: 3px;
            margin-bottom: 3px;
            max-width: 595px;
        }
        .namenormal a
        {
            color: #666666;
            text-decoration: none;
        }
        p.sign
        {
            margin-top: 2px;
            margin-bottom: 1px;
            line-height: 20px;
        }
        a
        {
            color: blue;
            text-decoration: underline;
        }
        .namenormal a:hover
        {
            font-size: 12px;
            font-style: normal;
            font-weight: normal;
            color: #666666;
            text-decoration: none;
            text-align: left;
        }
        .namenormalc
        {
            font-size: 12px;
            font-style: normal;
            font-weight: normal;
            color: #666666;
            line-height: 20px;
            padding-left: 5px;
            padding-right: 5px;
            text-align: center;
        }
        .namenormalc a
        {
            font-size: 13px;
            font-style: normal;
            font-weight: bold;
            color: #329344;
            text-decoration: none;
            text-align: center;
        }
        .namenormalc a:hover
        {
            font-size: 13px;
            font-style: normal;
            font-weight: normal;
            color: #666666;
            text-decoration: none;
            text-align: center;
        }
        .main
        {
            margin-left: auto;
            margin-right: auto;
            margin-top: 10px;
            margin-bottom: 0px;
            background-color: #ffffff;
            max-width: 600px;
        }
        .contenttbl tr td
        {
            padding-left: 5px;
            padding-right: 5px;
            line-height: 21px;
            vertical-align: middle;
        }
        .bgc
        {
            background-color: #f5f5f5;
        }
        .grid
        {
            width: 600px;
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
        }
        .grid td
        {
            padding: 5px;
            border: solid 1px #c1c1c1;
            color: #717171;
            line-height: 20px;
        }
        .grid th
        {
            padding: 10px;
            color: #000;
            background-color: #94bc16;
            border-left: solid 1px #525252;
            border-top: 1px solid #525252;
            font-size: 14px;
            font-weight: bold;
        }
        .grid .alt
        {
            background: #f7f7f7;
        }
        .tdr
        {
            text-align: right;
            padding: 5px;
        }
        .total-amount
        {
            color: #323232;
            background: #ebebeb;
            border: 1px solid #d6d6d6;
        }
        .total-amount tr td
        {
            padding: 5px;
            border: 1px solid #fff;
        }
        .amount
        {
            text-align: right;
            padding-right: 10px !important;
            background: #d9d9d9;
            width: 80px;
            color: #323232;
        }
        img
        {
            border: none;
        }
        p.small
        {
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width='600' border='0' align='center' cellpadding='0' cellspacing='0' class='main'>
            <tr>
                <td align="left" style="border-bottom: solid 2px #ED174B; padding-bottom: 5px;">
                    <a href='https://moneyplus.com.au/' target="_blank">
                        <img src='https://moneyplus.com.au/email/moneyplus-logo.png' alt="Money Plus" /></a>
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                        <br />
                        Hi <b>
                            <asp:Label ID="lblCustomer" runat="server"></asp:Label>,</b></p>
                    <p>
                        Congratulations! &nbsp; We have received your online application;</p>
                    <p>
                        Please email or fax the following for a final decision;</p>
                    <p>
                        1)&nbsp; <b>Print out </b>and manually sign the attached.</p>
                    <p>
                        2)&nbsp; A bank statement displaying your Account Name/Surname, BSB, & account number
                        - so we can credit your account accordingly.</p>
                    <p>
                        3)&nbsp; Last 90 days of a transaction listing up to current date showing your wage.</p>
                    <br />
                    <p>
                        If you have any questions call us on (02) 9621 - 4446 or email us <a href='mailto:loans@moneyplus.com.au'>
                            <b>loans@moneyplus.com.au</b></a></p>
                    <p>
                        Thank you for choosing Money Plus Online Service.</p>
                    <p>
                        <i>*If you are an <b><a href='https://moneyplus.com.au/site/general/existing-customer.aspx'
                            target='_blank'>existing</a></b> Moneyplus Client, <a href='https://moneyplus.com.au/site/branch-locations.aspx'
                                target='_blank'><b>Contact your branch</b></a> or <b><a href='https://moneyplus.com.au/site/general/existing-customer.aspx'
                                    target='_blank'>fast track your application online now!</a></b></i></p>
                    <p>
                        Regards,</p>
                    <p class="sign">
                        Money Plus Online Team</p>
                    <p class="sign">
                        <b>p</b>&nbsp;(02) 9621 - 4446</p>
                    <p class="sign">
                        <b>f</b>&nbsp;(02) 9676 - 1066</p>
                    <p class="sign">
                        <a href="http://www.moneyplus.com.au" target="_blank">Moneyplus.com.au</a></p>
                </td>
            </tr>
            <tr>
                <td>
                    <p class="small">
                        ************************************************************************************************************
                    </p>
                    <p class="small">
                        The information contained in this email is intended for the named recipient only.
                        It may contain privileged and confidential information and if you are not the intended
                        recipient, you must not copy, distribute or take any action in reliance upon it,
                        If you have received this message in error, please notify us immediately on (02)
                        9621 4446 Thank you.
                    </p>
                </td>
            </tr>
            <tr>
                <td class='footer'>
                    <br />
                    <p class='small sign'>
                        Paymay Pty Ltd ABN 64 137 270 369<br />
                        Australian Credit Licence Number:391 844</p>
                </td>
            </tr>
            <tr>
                <td><%--<div style="page-break-after:always"></div>--%>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                   <p class="small"><i>WARNING - Do you really need a loan today?*</i></p>
                   <p class="small">It can be expensive to borrow small amounts of money and borrowing may not solve your money problems.<br />Check your options before you borrow: </p>
                   <ul style="padding-left:15px;">
                   <li><p  class="small">
                   For information about other options for managing bills and debts, ring 1800 007 007 from anywhere in Australia to talk to a free and independent financial counsellor
                   </p></li>
                   <li><p class="small">Talk to your electricity, gas, phone or water provider to see if you can work out a payment plan</p></li>
                   <li><p  class="small">If you are on government benefits, ask if you can receive an advance from Centrelink: Phone: 13 17 94</p></li>
                   </ul>
                   <p  class="small">The Government's MoneySmart website shows you how small amount loans work and suggests other options that may help you.</p>
                   <p class="small">* This statement is an Australian Government requirement under the National Consumer Credit Protection Act 2009.</p>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
