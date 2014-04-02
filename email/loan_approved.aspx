<%@ Page Language="VB" AutoEventWireup="false" CodeFile="loan_approved.aspx.vb" Inherits="email_loan_approved"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loan Approved</title>
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
            font-size:12pt;
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
           max-width:595px;
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
             max-width:600px;
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
            width: 750px;
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
                        Congratulations! Our system has approved you on
                        <asp:Label ID="lblAmount" runat="server"></asp:Label>.</p>
                    <p>
                        Please find attached the pages that you <b>need to print out, fill in and manually sign,</b> once
                        <b>ALL PAGES</b> are emailed or faxed to us within 5 - 10 minutes we can credit your
                        account accordingly.</p>
                    <p>
                        Once this loan has been <b>finalised,</b>  you are able to reapply.</p>
                    <br />
                    <p>
                        If you have any questions call us on (02) 9621 - 4446 or email us  <a href='mailto:loans@moneyplus.com.au'>
                            <b>loans@moneyplus.com.au</b></a></p>
                    <p>
                        Thank you for choosing Money Plus Online Service.</p>
                    <br />
                    <p>
                        &nbsp;</p>
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
                <td align='center' style='padding-left: 0px;'>
                    <table width='600' border='0' align='center' cellpadding='2' cellspacing='2'>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <p class="small">
                        ***********************************************************************************************************************</p>
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
                                   
                    <br />
                    <p class='small sign'>
                        Paymay Pty Ltd ABN 64 137 270 369<br />
                        Australian Credit Licence Number:391 844</p>
                </td>
            </tr>
           
        </table>
    </div>
    </form>
</body>
</html>
