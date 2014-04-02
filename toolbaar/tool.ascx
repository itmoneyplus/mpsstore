<%@ Control Language="VB" AutoEventWireup="false" CodeFile="tool.ascx.vb" Inherits="toolbaar_toolbaar3" %>

<head>
    <title>tool</title> 
    <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
    <script type = "text/javascript">

        function Confirm_Black() {
            var confirm_value_black = document.createElement("INPUT");
           
            if (confirm("Click OK to Blacklist or Cancel to go Back!")) 
            {
                confirm_value_black.setAttribute("type", "hidden");
                confirm_value_black.setAttribute("value", "Yes");
                confirm_value_black.setAttribute("name", "confirm_value_black");
            }
            else 
            {
            confirm_value_black.setAttribute("type", "hidden");
            confirm_value_black.setAttribute("value", "No");
            confirm_value_black.setAttribute("name", "confirm_value_black");
            }
            document.forms[0].appendChild(confirm_value_black);
        }
        function Confirm_RemoveBlack() {
            var confirm_value_reblack = document.createElement("INPUT");

            if (confirm("Click OK to Remove from Blacklist or Cancel to go Back!")) {
                confirm_value_reblack.setAttribute("type", "hidden");
                confirm_value_reblack.setAttribute("value", "Yes");
                confirm_value_reblack.setAttribute("name", "confirm_value_reblack");
            }
            else {
                confirm_value_reblack.setAttribute("type", "hidden");
                confirm_value_reblack.setAttribute("value", "No");
                confirm_value_reblack.setAttribute("name", "confirm_value_reblack");
            }
            document.forms[0].appendChild(confirm_value_reblack);
        }

        function Confirm_Followup() {
            var confirm_value_Followup = document.createElement("INPUT");

            if (confirm("Click OK to Add to FollowUp or Cancel to go Back!")) {
                confirm_value_Followup.setAttribute("type", "hidden");
                confirm_value_Followup.setAttribute("value", "Yes");
                confirm_value_Followup.setAttribute("name", "confirm_value_Followup");
            }
            else {
                confirm_value_Followup.setAttribute("type", "hidden");
                confirm_value_Followup.setAttribute("value", "No");
                confirm_value_Followup.setAttribute("name", "confirm_value_Followup");
            }
            document.forms[0].appendChild(confirm_value_Followup);
        }
        function Confirm_RemoveFollowup() {
            var confirm_value_reFollowup = document.createElement("INPUT");

            if (confirm("Click OK to Remove from FollowUp or Cancel to go Back!")) {
                confirm_value_reFollowup.setAttribute("type", "hidden");
                confirm_value_reFollowup.setAttribute("value", "Yes");
                confirm_value_reFollowup.setAttribute("name", "confirm_value_reFollowup");
            }
            else {
                confirm_value_reFollowup.setAttribute("type", "hidden");
                confirm_value_reFollowup.setAttribute("value", "No");
                confirm_value_reFollowup.setAttribute("name", "confirm_value_reFollowup");
            }
            document.forms[0].appendChild(confirm_value_reFollowup);
        }
    </script>
    </head>
    <div align="center" >
    <table  id="toolbar3_table" cellspacing="0" class="toolbaar3_table">
    <tr>
    <td>
    <ul id="navbar">
	<li><a href="#">Customer Info</a>
	<ul>
	<li ><asp:LinkButton ID="LinkButton1" PostBackUrl="~/Customer/Update Personal_Form.aspx"  runat="server">Customer Details</asp:LinkButton> </li>
	<li><asp:LinkButton ID="LinkButton2" PostBackUrl="~/Customer/Bank Detail.aspx" runat="server">Bank Details</asp:LinkButton></li>
	<li><asp:LinkButton ID="LinkButton3" PostBackUrl="~/Customer/Comments.aspx" runat="server">Comments</asp:LinkButton></li>
    <li><asp:LinkButton ID="LinkButton4"  PostBackUrl="~/Customer/Customer_File.aspx" runat="server">Download Documents</asp:LinkButton></li>
    <li><asp:LinkButton ID="LinkButton14"  PostBackUrl="~/Customer/Upload_docs_new.aspx" runat="server">Upload Documents</asp:LinkButton></li>
	<li><asp:LinkButton ID="LinkButton5"  PostBackUrl="~/Customer/Export.aspx" runat="server">Export Documents</asp:LinkButton></li>
    </ul>
    </li>
               
    <li><a href="#">Summary</a>
    <ul>
	<li ><asp:LinkButton ID="LinkButton6" PostBackUrl="~/Customer/Detail.aspx" runat="server">Loan Summary</asp:LinkButton> </li>
	<li><asp:LinkButton ID="LinkButton7" PostBackUrl="~/Customer/Cheque Summary.aspx" runat="server" >Cheque Summary</asp:LinkButton></li>
	</ul> 
	</li>
    <li><a href="#">Applications</a>
    <ul>
	<li ><asp:LinkButton ID="LinkButton8" PostBackUrl="~/Customer/Loan Application.aspx" runat="server">New Loan Application</asp:LinkButton> </li>
	<li><asp:LinkButton ID="LinkButton9" PostBackUrl="~/Customer/Cheque Application.aspx" runat="server" >New Cheque Cashing</asp:LinkButton></li>
	</ul>
	</li>
    <li><a href="#">Bad Debt</a>
    <ul>
	<li><asp:LinkButton ID="LinkButton10" PostBackUrl="" runat="server"   OnClientClick ="Confirm_Black();" CssClass ="align">Add to Black List</asp:LinkButton> </li>
	<li><asp:LinkButton ID="LinkButton11" PostBackUrl="" runat="server"   OnClientClick ="Confirm_RemoveBlack();"  CssClass ="align">Remove from Black List</asp:LinkButton> </li>
	</ul>
	</li>
    <li><a href="#">Add FollowUp</a>
    <ul>
	<li><asp:LinkButton ID="LinkButton12" PostBackUrl="" runat="server"   OnClientClick ="Confirm_Followup();" CssClass ="align">Add to Followup</asp:LinkButton> </li>
	<li><asp:LinkButton ID="LinkButton13" PostBackUrl="" runat="server"   OnClientClick ="Confirm_RemoveFollowup();"  CssClass ="align">Remove from Followup</asp:LinkButton> </li>
	</ul>
	</li>
	</ul>
	</td>
    <td class="toolbaar3_td">
    <asp:Label ID="Label1" runat="server"  CssClass="toolbaar3_label" Text="Label" ></asp:Label> 
    </td>
    </tr> 
    </table> 
    </div>
  
   