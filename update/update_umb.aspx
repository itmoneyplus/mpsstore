<%@ Page Language="VB" AutoEventWireup="false" CodeFile="update_umb.aspx.vb" Inherits="update_update_umb" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div>
    
        <asp:TextBox ID="TextBox1" runat="server" Columns="150" Rows="30" 
            TextMode="MultiLine"></asp:TextBox>
         
    
    </div>
    <asp:Button ID="Button1" runat="server" Text="Update" OnClientClick="this.disabled='true'; this.value='processing please wait...'; this.width='150px';" UseSubmitBehavior="False" />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        Display="Dynamic" ErrorMessage="Please enter text" 
        ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
    </div>
    </form>
</body>
</html>
