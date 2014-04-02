<%@ Page Language="VB" Culture="en-AU" Debug="true" AutoEventWireup="false" CodeFile="Login.aspx.vb"
    Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Screen</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />

    <script type="text/javascript">

        function changeHashOnLoad() {
            window.location.href += "#";
            setTimeout("changeHashAgain()", "50");
        }
        function changeHashAgain() {
            window.location.href += "1";
        }
        var storedHash = window.location.hash;
        window.setInterval(function() {
            if (window.location.hash != storedHash)
            { window.location.hash = storedHash; }
        }, 50);

    </script>

</head>
<body onload="changeHashOnLoad();">
    <form id="form1" runat="server" class="login_border">
    <div align="center">
        <table id="table1" class="login_table1">
            <tr>
                <td class="login_td1">
                    <b>User Name:</b>
                </td>
                <td>
                    <asp:TextBox ID="txtLogonID" MaxLength="12" CssClass="login_pwd" TabIndex="1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="login_td1">
                    <b>Password:</b>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" MaxLength="12" CssClass="login_pwd" TabIndex="2" runat="server"
                        TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLogon" runat="server" Text="Login" CssClass="login_button" />
                </td>
                <td style="width: 150px; height: 20px; background-color: #F9F9F8; border-color: #F0F0F0">
                    <div style="float: right">
                        <img alt="logo" src="Images/Logon.gif" width="100" height="40" />
                    </div>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" class="table_desk">
            <tr>
                <td class="td_desk">
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;
                    </p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p style="height: 19px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
                    <div class="align-right">
                        <img alt="logo" id="img" src="Images/Logon.gif" height="120" /></div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
