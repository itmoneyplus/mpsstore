<%@ Page Language="VB" Culture="en-AU" AutoEventWireup="false" CodeFile="NAB_DD.aspx.vb" Inherits="Customer_NAB_DD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Document using:</title>
    <script type="text/javascript"  >
   window.history.forward(1);
   function  new_page() {
    window.location.assign("LoanSummary.aspx");
}
</script>
</head>
<body ondblclick="new_page();"  onload="window.print();">
    <form id="form1" runat="server" >
    <div>
    
    </div>
    </form>
</body>
</html>
