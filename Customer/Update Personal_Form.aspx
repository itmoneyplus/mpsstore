<%@ Page Language="VB" Culture="en-AU" AutoEventWireup="false" CodeFile="Update Personal_Form.aspx.vb" Inherits="Customer_Personal_Form"   %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1"  TagPrefix="tool1"%>
<%@ Register Src="~/toolbaar/tool.ascx"  TagName="Toolbaar3"  TagPrefix="tool3"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

       <html xmlns="http://www.w3.org/1999/xhtml">
       <head runat="server">
       <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
       <title>Update Customer</title>
       <script type="text/javascript" src="../frm_val.js" >
        
       </script>
       <link rel="stylesheet" type="text/css" href="../css/style.css" />
       <link rel="stylesheet" type="text/css" href="../css/menu.css" />
       <style type="text/css">
            #form1
            {
                margin-left: 30px;
            }
            .style1
            {
                          
                padding-left:23px;               
                border:1px solid gray;
                vertical-align :top;            
               
            }
            .style3
            {
                width: 163px;
            }
        </style>
        <script type="text/javascript">

            function Confirm_Black() {
                var confirm_value_black = document.createElement("INPUT");

                if (confirm("Click OK to Blacklist or Cancel to go Back!")) {
                    confirm_value_black.setAttribute("type", "hidden");
                    confirm_value_black.setAttribute("value", "Yes");
                    confirm_value_black.setAttribute("name", "confirm_value_black");
                }
                else {
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

       <body ondblclick="javaScript:history.go(-1);">
       <form id="form1" runat="server" >
       <%--<tool1:Toolbaar1  ID ="tool_first" runat="server" />--%>
       <div id="title" 
                style="padding: 0px; margin: 0px; position: absolute; float: left; top: 0px; left: 0px;">
                <asp:Label ID="lblTitle" runat="server" Text="Money Plus" CssClass="menu_left" ></asp:Label>  
                <a class="menu_right" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                       [Logout]</a>  
                <asp:LinkButton ID="LinkButton_back" runat="server" CssClass="menu_right" TabIndex="8">[Back]</asp:LinkButton>        
            </div>
            <%-- <table id="toolbar_table" cellspacing="0" class="table_toolbaar">
                    <tr class="toolbaar1_tr">
                        <td class="toolbaar1_td">
                            <asp:LinkButton ID="Link_Home" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Default.aspx"
                                TabIndex="1">Home</asp:LinkButton>
                            <asp:Label ID="Label1" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Customer" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/AddSearch.aspx"
                                TabIndex="2">Customer</asp:LinkButton>
                            <asp:Label ID="Label2" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Cash" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File.aspx"
                                TabIndex="3">Cash Movements</asp:LinkButton>
                            <asp:Label ID="Label3" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Reports" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Tab_report.aspx"
                                TabIndex="4">Reports</asp:LinkButton>
                            <asp:Label ID="Label4" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Marketing" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Tab_Marketing.aspx"
                                TabIndex="5">Marketing</asp:LinkButton>
                            <asp:Label ID="Label5" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Audit" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Online_Joined.aspx"
                                TabIndex="6">Online Joined</asp:LinkButton>
                            <asp:Label ID="Label6" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Administration" runat="server" CssClass="toolbaar1_link"
                                TabIndex="7">Administration</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton8" runat="server" CssClass="toolbaar1_link" TabIndex="8">[Back]</asp:LinkButton>
                        </td>
                        <td class="toolbaar1_td_right">
                            <a class="toolbaar1_link" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                                [Logout]</a>
                        </td>
                    </tr>
                </table>--%>
                <ul id="menu" 
                style="padding: 0px; margin: 24px; position: absolute; top: 8px; left: -24px;">
                    <li>
                        <asp:LinkButton ID="Link_Home" runat="server" CssClass="toolbaar1_link"   PostBackUrl="~/Customer/Default.aspx"
                            TabIndex="1">Home</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Customer" runat="server" Font-Bold="True"  ForeColor="#2E95C9"  PostBackUrl="~/Customer/AddSearch.aspx"
                            TabIndex="2">Customer</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Cash" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File_NAB.aspx"
                            TabIndex="3">Cash Movements</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Reports" runat="server" CssClass="toolbaar1_link"    PostBackUrl="~/Customer/Financial_Reports.aspx"
                            TabIndex="4">Reports</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Marketing" runat="server"   CssClass="toolbaar1_link"  PostBackUrl="~/Customer/Marketing_Report.aspx"
                            TabIndex="5">Marketing</asp:LinkButton>
                    </li>
                    <%--<li>
                        <asp:LinkButton ID="Link_Audit" runat="server" CssClass="toolbaar1_link"  PostBackUrl="~/Customer/Online_Joined.aspx"
                            TabIndex="6">Online Joined</asp:LinkButton>
                    </li>--%>
                    <li>
                        <asp:LinkButton ID="Link_Administration" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/CreateUser.aspx"
                            TabIndex="7">Administration</asp:LinkButton>
                        </li>
                   <%--<li class="menu_right"><a class="toolbaar1_link" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                       <b> [Logout]</b></a></li>
                    <li class="menu_right">
                        <asp:LinkButton ID="LinkButton8" runat="server" CssClass="toolbaar1_link" TabIndex="8">[Back]</asp:LinkButton></li>--%>           
                </ul>
       <br/>
       <br />  <br />  <br /> <br />  <br />
        <asp:Panel ID="Panel2" runat="server" >
    <table id="toolbarMarketing_table" cellspacing="0" class="toolbarcustomer_table" 
        cellpadding="0">
        <tr>
            <td align="left">
                 <ul id="navbarCustomer">
                    <li><a href="#" style="font-weight:bold;color:#2E95C9">Customer Info</a>
                        <ul >
                            <li>
                                <asp:LinkButton ID="LinkButton1" PostBackUrl="~/Customer/Update Personal_Form.aspx"
                                    runat="server">Customer Details</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="LinkButton2" PostBackUrl="~/Customer/Bank Detail.aspx" runat="server">Bank Details</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="LinkButton3" PostBackUrl="~/Customer/Comments.aspx" runat="server">Comments</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="LinkButton4" PostBackUrl="~/Customer/Customer_File.aspx" runat="server">Download Documents</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="LinkButton14" PostBackUrl="~/Customer/Upload_docs_new.aspx" runat="server">Upload Documents</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="LinkButton5" PostBackUrl="~/Customer/Export.aspx" runat="server">Export Documents</asp:LinkButton></li>
                        </ul>
                    </li>
                    <li><a href="#">Summary</a>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton6" PostBackUrl="~/Customer/Detail.aspx" runat="server">Loan Summary</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="LinkButton7" PostBackUrl="~/Customer/Cheque Summary.aspx" runat="server">Cheque Summary</asp:LinkButton></li>
                        </ul>
                    </li>
                    <li><a href="#">Applications</a>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton8" PostBackUrl="~/Customer/Loan Application.aspx" runat="server">New Loan Application</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="LinkButton9" PostBackUrl="~/Customer/Cheque Application.aspx"
                                    runat="server">New Cheque Cashing</asp:LinkButton></li>
                        </ul>
                    </li>
                    <li><a href="#">Bad Debt</a>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton10" PostBackUrl="" runat="server" OnClientClick="Confirm_Black();"
                                    CssClass="align">Add to Black List</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="LinkButton11" PostBackUrl="" runat="server" OnClientClick="Confirm_RemoveBlack();"
                                    CssClass="align">Remove from Black List</asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                    <li><a href="#">Add FollowUp</a>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton12" PostBackUrl="" runat="server" OnClientClick="Confirm_Followup();"
                                    CssClass="align">Add to Followup</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="LinkButton13" PostBackUrl="" runat="server" OnClientClick="Confirm_RemoveFollowup();"
                                    CssClass="align">Remove from Followup</asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                </ul>
            </td>
            <td class="toolbaar3_td_customer">
                <asp:Label ID="Label_customername" runat="server" CssClass="" Text="Label"></asp:Label>
            </td>
            
        </tr>
    </table>
   
    <table cellspacing="0" cellpadding="0" width="98%"  >
    <tr>
   
    <td style="border:1px solid gray; width:82%;vertical-align :top">
    <div align="left">
    <br />
            <table align="left" class="w100">
                       <%-- <table border="0" cellpadding="3" cellspacing="0" class="table-top_new1">--%>
                            <tr>
                            <td colspan="4" class="top-italics-style" ><b>Customer Details:</b></td>
                            </tr>
                            <tr>    
                            <td  class="td-personal" >Amount requested:</td>
                            <td class="td-personal"  >
                            <asp:DropDownList id="drop1" runat="server" Width="65px" TabIndex="8">
                            <asp:ListItem ></asp:ListItem>
                            <asp:ListItem >$100</asp:ListItem>
                            <asp:ListItem >$200</asp:ListItem>
                            <asp:ListItem >$300</asp:ListItem>
                            <asp:ListItem >$400</asp:ListItem>
                            <asp:ListItem >$500</asp:ListItem>
                            <asp:ListItem >$600</asp:ListItem>
                            <asp:ListItem >$700</asp:ListItem>
                            <asp:ListItem >$800</asp:ListItem>
                            <asp:ListItem >$900</asp:ListItem>
                            <asp:ListItem >$1000</asp:ListItem>
                           </asp:DropDownList> 
                    *         
                           </td> 
                           <td class="td-personal">Purpose of loan:</td>
                           <td class="td-personal">
                           <asp:DropDownList ID="drop2"  runat ="server" width="180px" height="22px" TabIndex="9" >
	                        <asp:ListItem ></asp:ListItem>
	                        <asp:ListItem >Temporary cash shortfall</asp:ListItem>
	                        <asp:ListItem >Car repairs</asp:ListItem>
	                        <asp:ListItem >Household bills</asp:ListItem>
	                        <asp:ListItem >Educational expenses</asp:ListItem>
	                        <asp:ListItem >Home improvements</asp:ListItem>
	                        <asp:ListItem >Insurance</asp:ListItem>
	                        <asp:ListItem >Medical expenses</asp:ListItem>
	                        <asp:ListItem >Repay existing debts</asp:ListItem>
                            <asp:ListItem >Business use</asp:ListItem>
	                        <asp:ListItem >Travel</asp:ListItem>
	                        <asp:ListItem >Other</asp:ListItem>
	                        </asp:DropDownList>*</td>
                            </tr>   
                            <tr>
                            <td class="td-personal">Customer&nbsp;ID:</td>
                            <td class="td-personal"> 
                            <asp:Label ID="lbl_custid" runat="server" Text="Label"></asp:Label></td>
                            <td class="td-personal">Marketing&nbsp;phrase:</td>
                            <td class="td-personal" >
                            <asp:DropDownList  ID="drop3" runat="server" height="22px" width="120px" TabIndex="12">
                            <asp:ListItem ></asp:ListItem>
                            <asp:ListItem >Television</asp:ListItem>
                            <asp:ListItem >Direct Marketing</asp:ListItem>
                            <asp:ListItem >Internet</asp:ListItem>
                            <asp:ListItem >Word of mouth</asp:ListItem>
                            <asp:ListItem >Relative</asp:ListItem>
                            <asp:ListItem >Friend</asp:ListItem>
                            <asp:ListItem >Walk By</asp:ListItem>
                              <asp:ListItem >Yellow Pages</asp:ListItem>
                                <asp:ListItem >Local Newspaper</asp:ListItem>
                           </asp:DropDownList>*
                           </td>
                           </tr>

                    <%--    ............................................................................--%>
                            <tr>    
                            <td colspan="4" >
                            <hr /></td></tr>
                            <tr>
                            <td class="td-personal"><b>Personal Details</b></td>
                            </tr>
                            <tr>
                       
    	                    <td class="td-personal"   >Title:</td>
    	                    <td class="td-personal"  >
    	                    <asp:DropDownList ID="drop4" runat="server"  Width="55px" TabIndex="13"  >
    	                    <asp:ListItem ></asp:ListItem>
                            <asp:ListItem >Mr</asp:ListItem>
                            <asp:ListItem >Ms</asp:ListItem>
                            <asp:ListItem >Miss</asp:ListItem>
                            <asp:ListItem >Mrs</asp:ListItem>
                            <asp:ListItem >Dr</asp:ListItem>
    	                    </asp:DropDownList>
    	                    *
                            </td>
  		                    <td class="td-personal" >Work&nbsp;phone:</td>
    	                    <td class="td-personal" >
    	                    <asp:TextBox  ID= "txtwrk" runat="server" Width ="165px" MaxLength="10" TabIndex="14" />
                                    
    	                    *</td></tr>
  		                    <tr>
  		                    <td class="td-personal" >Last name:</td>
                            <td class="td-personal"> 
                            <asp:TextBox  ID ="txtlastname"  Width="150px" runat="server" MaxLength="25"  TabIndex="15" ></asp:TextBox>* </td>
                            <td class="td-personal">Home phone:</td>
                            <td  class="td-personal">
		                    <asp:TextBox runat="server" ID="txtHomePhone"  Width="165px" MaxLength="10" TabIndex="16"></asp:TextBox>
		                    </td> 
  		                    </tr>
                            <tr>
  		                    <td class="td-personal">Given name:</td>
                            <td  class="td-personal"> 
                            <asp:TextBox  ID ="txtgvnname"  Width="150px" runat="server" MaxLength="25" TabIndex="17" ></asp:TextBox>* </td>
                            <td  class="td-personal">Mobile:</td>
                            <td  class="td-personal" >
		                    <asp:TextBox runat="server" ID="txtmobile"  Width="150px" MaxLength="10" TabIndex="18"></asp:TextBox>		
	                        *</td> 
  		                    </tr>
                             <tr>
                             <td  class="td-personal" >Date of&nbsp; birth:</td>
                             <td class="td-personal" >                		                		
                             <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
                             EnableScriptLocalization="true" ID="ScriptManager1" />
                            <asp:TextBox ID="txtdtbirth" runat="server" Width ="130px" MaxLength="10" TabIndex="19"  ></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdtbirth" Format="dd/MM/yyyy"   FirstDayOfWeek="Sunday" CssClass="red"  OnClientShowing="showDate">
                            </ajaxToolkit:CalendarExtender>
                            </td>

    	                    <td class="td-personal">Email: </td>
    	                    <td  class="td-personal" >
                            <asp:TextBox ID="txtEmail" runat ="server" Width ="180px" MaxLength="40" TabIndex="20"  ></asp:TextBox>*</td> 
                            </tr><tr>
     	                    <td  class="td-personal"  >Marital status:</td>
     	                    <td class="td-personal" >
     	                    <asp:DropDownList ID="drop5" runat="server" Width ="80px" TabIndex="21">
     	                    <asp:ListItem ></asp:ListItem>
                            <asp:ListItem >Married</asp:ListItem>
                            <asp:ListItem >Divorced</asp:ListItem>
                            <asp:ListItem >Separated</asp:ListItem>
     	                    <asp:ListItem >Single</asp:ListItem>
                            <asp:ListItem >Defacto</asp:ListItem>
                            </asp:DropDownList>
                                    	
                           </td>
	                       </tr>
	                        <tr>
  		                    <td  class="td-personal">Last name (Spouse):</td>
                            <td  class="td-personal"> 
                            <asp:TextBox  ID ="txtlastnamesp"  Width="150px" runat="server" MaxLength="25"  TabIndex="22" ></asp:TextBox></td>
                            <td  class="td-personal">Given name(Spouse):</td>
                            <td  class="td-personal"> 
                            <asp:TextBox  ID ="txtgvnnamesp"  Width="150px" runat="server" MaxLength="25"  TabIndex="23" ></asp:TextBox> </td>
                            </tr> 
                                    
                                <%--    .......................................................--%>
                            <tr>
                            <td colspan="4" >
                            <hr style ="color :#C0C0C0 ; size:1px ;height: -15px"/></td>
                            </tr>
                            <tr>		 
                            <td colspan="4"  class="td-personal">
                            <b>Identity Verifications Information (Select at least one of these two)*</b> 
                            <asp:RadioButton ID="RadioButton1" Text ="Driver's Licence" runat="server" 
                             CssClass="td-personal" AutoPostBack="True" Checked="True" TabIndex="24"  />  
                            <asp:RadioButton ID="RadioButton2" Text ="Passport Number" runat="server" 
                            CssClass="td-personal" AutoPostBack="True" TabIndex="25"  /> </td></tr>
                            <tr>		 
                            <td class="td-personal"></td>
                           </tr>
                           <tr>
                           <td class="td-personal">Driver&nbsp;Licence&nbsp;Number:</td>
                           <td  class="td-personal">
                           <asp:TextBox runat="server" ID="txtDLicence" width="150px" MaxLength="10" TabIndex="26"></asp:TextBox> </td>
                           <td class="td-personal">Passport Number:</td>
                           <td  class="td-personal">
                           <asp:TextBox runat="server" ID="txtPassport" Width="150px" MaxLength="10"  TabIndex="27"></asp:TextBox></td>
                           </tr>
 	                        <tr>
  	                        <td  class="td-personal"  >Licence&nbsp;Card Number:</td>
  	                        <td  class="td-personal" >
                                    		
	                        <asp:TextBox runat="server" ID="txtLicence_card_no" width="150px" 
                            MaxLength="10" TabIndex="28"></asp:TextBox> </td>
                            <td  class="td-personal"  >Place of Birth:</td>
                            <td  class="td-personal"  >
                            <asp:TextBox runat="server" ID="txtPlace_Of_Birth" Width="165px" MaxLength="25"  TabIndex="29"></asp:TextBox></td>
                            </tr>
 	                        <tr>
      	                    <td  class="td-personal">Issuing State:</td>
      	                    <td  class="td-personal"  >
                            <asp:DropDownList ID="drop6" runat ="server" TabIndex="30" AutoPostBack="True"  >
                            <asp:ListItem ></asp:ListItem>
		                    <asp:ListItem >ACT</asp:ListItem >
		                    <asp:ListItem >NSW</asp:ListItem >
		                    <asp:ListItem >NT</asp:ListItem >
		                    <asp:ListItem >QLD</asp:ListItem >
		                    <asp:ListItem >SA</asp:ListItem >
		                    <asp:ListItem >TAS</asp:ListItem >
		                    <asp:ListItem >VIC</asp:ListItem >
		                    <asp:ListItem >WA</asp:ListItem >
		                    </asp:DropDownList></td>
                               
                          <td  class="td-personal">Issuing Country:</td>
                          <td class="td-personal">
                            <asp:DropDownList ID="drop7" runat="server" TabIndex="31" >
                            <asp:ListItem > </asp:ListItem>
                            <asp:ListItem>Afghanistan</asp:ListItem>
                            <asp:ListItem>Åland Islands</asp:ListItem>
                            <asp:ListItem>Albania</asp:ListItem>
                            <asp:ListItem>Algeria</asp:ListItem>
                            <asp:ListItem>American Samoa</asp:ListItem>
                            <asp:ListItem>Andorra</asp:ListItem>
                            <asp:ListItem>Angola</asp:ListItem>
                            <asp:ListItem>Anguilla</asp:ListItem>
                            <asp:ListItem>Antarctica</asp:ListItem>
                            <asp:ListItem>Antigua and Barbuda</asp:ListItem>
                            <asp:ListItem>Argentina</asp:ListItem>
                            <asp:ListItem>Armenia</asp:ListItem>
                            <asp:ListItem>Aruba</asp:ListItem>
                            <asp:ListItem>Australia</asp:ListItem>
                            <asp:ListItem>Austria</asp:ListItem>
                            <asp:ListItem>Azerbaijan</asp:ListItem>
                            <asp:ListItem>Bahamas</asp:ListItem>
                            <asp:ListItem>Bahrain</asp:ListItem>
                            <asp:ListItem>Bangladesh</asp:ListItem>
                            <asp:ListItem>Barbados</asp:ListItem>
                            <asp:ListItem>Belarus</asp:ListItem>
                            <asp:ListItem>Belgium</asp:ListItem>
                            <asp:ListItem>Belize</asp:ListItem>
                            <asp:ListItem>Benin</asp:ListItem>
                            <asp:ListItem>Bermuda</asp:ListItem>
                            <asp:ListItem>Bhutan</asp:ListItem>
                            <asp:ListItem>Bolivia</asp:ListItem>
                            <asp:ListItem>Bosnia and Herzegovina</asp:ListItem>
                            <asp:ListItem>Botswana</asp:ListItem>
                            <asp:ListItem>Bouvet Island</asp:ListItem>
                            <asp:ListItem>Brazil</asp:ListItem>
                            <asp:ListItem>British Indian Ocean Territory</asp:ListItem>
                            <asp:ListItem>Brunei Darussalam</asp:ListItem>
                            <asp:ListItem>Bulgaria</asp:ListItem>
                            <asp:ListItem>Burkina Faso</asp:ListItem>
                            <asp:ListItem>Burundi</asp:ListItem>
                            <asp:ListItem>Cambodia</asp:ListItem>
                            <asp:ListItem>Cameroon</asp:ListItem>
                            <asp:ListItem>Canada</asp:ListItem>
                            <asp:ListItem>Cape Verde</asp:ListItem>
                            <asp:ListItem>Cayman Islands</asp:ListItem>
                            <asp:ListItem>Central African Republic</asp:ListItem>
                            <asp:ListItem>Chad</asp:ListItem>
                            <asp:ListItem>Chile</asp:ListItem>
                            <asp:ListItem>China</asp:ListItem>
                            <asp:ListItem>Christmas Island</asp:ListItem>
                            <asp:ListItem>Cocos (Keeling) Islands</asp:ListItem>
                            <asp:ListItem>Colombia</asp:ListItem>
                            <asp:ListItem>Comoros</asp:ListItem>
                            <asp:ListItem>Congo</asp:ListItem>
                            <asp:ListItem>Congo, The Democratic Republic of The</asp:ListItem>
                            <asp:ListItem>Cook Islands</asp:ListItem>
                            <asp:ListItem>Costa Rica</asp:ListItem>
                            <asp:ListItem>Cote D'ivoire</asp:ListItem>
                            <asp:ListItem>Croatia</asp:ListItem>
                            <asp:ListItem>Cuba</asp:ListItem>
                            <asp:ListItem>Cyprus</asp:ListItem>
                            <asp:ListItem>Czech Republic</asp:ListItem>
                            <asp:ListItem>Denmark</asp:ListItem>
                            <asp:ListItem>Djibouti</asp:ListItem>
                            <asp:ListItem>Dominica</asp:ListItem>
                            <asp:ListItem>Dominican Republic</asp:ListItem>
                            <asp:ListItem>Ecuador</asp:ListItem>
                            <asp:ListItem>Egypt</asp:ListItem>
                            <asp:ListItem>El Salvador</asp:ListItem>
                            <asp:ListItem>Equatorial Guinea</asp:ListItem>
                            <asp:ListItem>Eritrea</asp:ListItem>
                            <asp:ListItem>Estonia</asp:ListItem>
                            <asp:ListItem>Ethiopia</asp:ListItem>
                            <asp:ListItem>Falkland Islands (Malvinas)</asp:ListItem>
                            <asp:ListItem>Faroe Islands</asp:ListItem>
                            <asp:ListItem>Fiji</asp:ListItem>
                            <asp:ListItem>Finland</asp:ListItem>
                            <asp:ListItem>France</asp:ListItem>
                            <asp:ListItem>French Guiana</asp:ListItem>
                            <asp:ListItem>French Polynesia</asp:ListItem>
                            <asp:ListItem>French Southern Territories</asp:ListItem>
                            <asp:ListItem>Gabon</asp:ListItem>
                            <asp:ListItem>Gambia</asp:ListItem>
                            <asp:ListItem>Georgia</asp:ListItem>
                            <asp:ListItem>Germany</asp:ListItem>
                            <asp:ListItem>Ghana</asp:ListItem>
                            <asp:ListItem>Gibraltar</asp:ListItem>
                            <asp:ListItem>Greece</asp:ListItem>
                            <asp:ListItem>Greenland</asp:ListItem>
                            <asp:ListItem>Grenada</asp:ListItem>
                            <asp:ListItem>Guadeloupe</asp:ListItem>
                            <asp:ListItem>Guam</asp:ListItem>
                            <asp:ListItem>Guatemala</asp:ListItem>
                            <asp:ListItem>Guernsey</asp:ListItem>
                            <asp:ListItem>Guinea</asp:ListItem>
                            <asp:ListItem>Guinea-bissau</asp:ListItem>
                            <asp:ListItem>Guyana</asp:ListItem>
                            <asp:ListItem>Haiti</asp:ListItem>
                            <asp:ListItem>Heard Island and Mcdonald Islands</asp:ListItem>
                            <asp:ListItem>Holy See (Vatican City State)</asp:ListItem>
                            <asp:ListItem>Honduras</asp:ListItem>
                            <asp:ListItem>Hong Kong</asp:ListItem>
                            <asp:ListItem>Hungary</asp:ListItem>
                            <asp:ListItem>Iceland</asp:ListItem>
                            <asp:ListItem>India</asp:ListItem>
                            <asp:ListItem>Indonesia</asp:ListItem>
                            <asp:ListItem>Iran, Islamic Republic of</asp:ListItem>
                            <asp:ListItem>Iraq</asp:ListItem>
                            <asp:ListItem>Ireland</asp:ListItem>
                            <asp:ListItem>Isle of Man</asp:ListItem>
                            <asp:ListItem>Israel</asp:ListItem>
                            <asp:ListItem>Italy</asp:ListItem>
                            <asp:ListItem>Jamaica</asp:ListItem>
                            <asp:ListItem>Japan</asp:ListItem>
                            <asp:ListItem>Jersey</asp:ListItem>
                            <asp:ListItem>Jordan</asp:ListItem>
                            <asp:ListItem>Kazakhstan</asp:ListItem>
                            <asp:ListItem>Kenya</asp:ListItem>
                            <asp:ListItem>Kiribati</asp:ListItem>
                            <asp:ListItem>Korea, Democratic People's Republic of</asp:ListItem>
                            <asp:ListItem>Korea, Republic of</asp:ListItem>
                            <asp:ListItem>Kuwait</asp:ListItem>
                            <asp:ListItem>Kyrgyzstan</asp:ListItem>
                            <asp:ListItem>Lao People's Democratic Republic</asp:ListItem>
                            <asp:ListItem>Latvia</asp:ListItem>
                            <asp:ListItem>Lebanon</asp:ListItem>
                            <asp:ListItem>Lesotho</asp:ListItem>
                            <asp:ListItem>Liberia</asp:ListItem>
                            <asp:ListItem>Libyan Arab Jamahiriya</asp:ListItem>
                            <asp:ListItem>Liechtenstein</asp:ListItem>
                            <asp:ListItem>Lithuania</asp:ListItem>
                            <asp:ListItem>Luxembourg</asp:ListItem>
                            <asp:ListItem>Macao</asp:ListItem>
                            <asp:ListItem>>Macedonia, The Former Yugoslav Republic of</asp:ListItem>
                            <asp:ListItem>Madagascar</asp:ListItem>
                            <asp:ListItem>"Malawi" "">Malawi</asp:ListItem>
                            <asp:ListItem>Malaysia</asp:ListItem>
                            <asp:ListItem>Maldives</asp:ListItem>
                            <asp:ListItem>Mali</asp:ListItem>
                            <asp:ListItem>Malta</asp:ListItem>
                            <asp:ListItem>Marshall Islands</asp:ListItem>
                            <asp:ListItem>Martinique</asp:ListItem>
                            <asp:ListItem>Mauritania</asp:ListItem>
                            <asp:ListItem>Mauritius</asp:ListItem>
                            <asp:ListItem>Mayotte</asp:ListItem>
                            <asp:ListItem>Mexico</asp:ListItem>
                            <asp:ListItem>Micronesia, Federated States of</asp:ListItem>
                            <asp:ListItem>Moldova, Republic of</asp:ListItem>
                            <asp:ListItem>Monaco</asp:ListItem>
                            <asp:ListItem>Mongolia</asp:ListItem>
                            <asp:ListItem>Montenegro</asp:ListItem>
                            <asp:ListItem>Montserrat</asp:ListItem>
                            <asp:ListItem>Morocco</asp:ListItem>
                            <asp:ListItem>Mozambique</asp:ListItem>
                            <asp:ListItem>Myanmar</asp:ListItem>
                            <asp:ListItem>Namibia</asp:ListItem>
                            <asp:ListItem>Nauru</asp:ListItem>
                            <asp:ListItem>Nepal</asp:ListItem>
                            <asp:ListItem>Netherlands</asp:ListItem>
                            <asp:ListItem>Netherlands Antilles</asp:ListItem>
                            <asp:ListItem>New Caledonia</asp:ListItem>
                            <asp:ListItem>New Zealand</asp:ListItem>
                            <asp:ListItem>Nicaragua</asp:ListItem>
                            <asp:ListItem>Niger</asp:ListItem>
                            <asp:ListItem>Nigeria</asp:ListItem>
                            <asp:ListItem>Niue</asp:ListItem>
                            <asp:ListItem>Norfolk Island</asp:ListItem>
                            <asp:ListItem>Northern Mariana Islands</asp:ListItem>
                            <asp:ListItem>Norway</asp:ListItem>
                            <asp:ListItem>Oman</asp:ListItem>
                            <asp:ListItem>Pakistan</asp:ListItem>
                            <asp:ListItem>Palau</asp:ListItem>
                            <asp:ListItem>Palestinian Territory, Occupied</asp:ListItem>
                            <asp:ListItem>Panama</asp:ListItem>
                            <asp:ListItem>Papua New Guinea</asp:ListItem>
                            <asp:ListItem>Paraguay</asp:ListItem>
                            <asp:ListItem>Peru</asp:ListItem>
                            <asp:ListItem>Philippines</asp:ListItem>
                            <asp:ListItem>Pitcairn</asp:ListItem>
                            <asp:ListItem>Poland</asp:ListItem>
                            <asp:ListItem>Portugal</asp:ListItem>
                            <asp:ListItem>Puerto Rico</asp:ListItem>
                            <asp:ListItem>Qatar</asp:ListItem>
                            <asp:ListItem>Reunion</asp:ListItem>
                            <asp:ListItem>Romania</asp:ListItem>
                            <asp:ListItem>Russian Federation</asp:ListItem>
                            <asp:ListItem>Rwanda</asp:ListItem>
                            <asp:ListItem>Saint Helena</asp:ListItem>
                            <asp:ListItem>Saint Kitts and Nevis</asp:ListItem>
                            <asp:ListItem>Saint Lucia</asp:ListItem>
                            <asp:ListItem>Saint Pierre and Miquelon</asp:ListItem>
                            <asp:ListItem>Saint Vincent and The Grenadines</asp:ListItem>
                            <asp:ListItem>Samoa</asp:ListItem>
                            <asp:ListItem>San Marino</asp:ListItem>
                            <asp:ListItem>Sao Tome and Principe</asp:ListItem>
                            <asp:ListItem>Saudi Arabia</asp:ListItem>
                            <asp:ListItem>Senegal</asp:ListItem>
                            <asp:ListItem>Serbia</asp:ListItem>
                            <asp:ListItem>Seychelles</asp:ListItem>
                            <asp:ListItem>Sierra Leone</asp:ListItem>
                            <asp:ListItem>Singapore</asp:ListItem>
                            <asp:ListItem>Slovakia</asp:ListItem>
                            <asp:ListItem>Slovenia</asp:ListItem>
                            <asp:ListItem>Solomon Islands</asp:ListItem>
                            <asp:ListItem>Somalia</asp:ListItem>
                            <asp:ListItem>South Africa</asp:ListItem>
                            <asp:ListItem>Sth Georgia and The Sth Sandwich Islands</asp:ListItem>
                            <asp:ListItem>Spain</asp:ListItem>
                            <asp:ListItem>Sri Lanka</asp:ListItem>
                            <asp:ListItem>Sudan</asp:ListItem>
                            <asp:ListItem>Suriname</asp:ListItem>
                            <asp:ListItem>Svalbard and Jan Mayen</asp:ListItem>
                            <asp:ListItem>Swaziland</asp:ListItem>
                            <asp:ListItem>Sweden</asp:ListItem>
                            <asp:ListItem>Switzerland</asp:ListItem>
                            <asp:ListItem>Syrian Arab Republic</asp:ListItem>
                            <asp:ListItem>Taiwan, Province of China</asp:ListItem>
                            <asp:ListItem>Tajikistan</asp:ListItem>
                            <asp:ListItem>Tanzania, United Republic of</asp:ListItem>
                            <asp:ListItem>Thailand</asp:ListItem>
                            <asp:ListItem>Timor-leste</asp:ListItem>
                            <asp:ListItem>Togo</asp:ListItem>
                            <asp:ListItem>Tokelau</asp:ListItem>
                            <asp:ListItem>Tonga</asp:ListItem>
                            <asp:ListItem>Trinidad and Tobago</asp:ListItem>
                            <asp:ListItem>Tunisia</asp:ListItem>
                            <asp:ListItem>Turkey</asp:ListItem>
                            <asp:ListItem>Turkmenistan</asp:ListItem>
                            <asp:ListItem>Turks and Caicos Islands</asp:ListItem>
                            <asp:ListItem>Tuvalu</asp:ListItem>
                            <asp:ListItem>Uganda</asp:ListItem>
                            <asp:ListItem>Ukraine</asp:ListItem>
                            <asp:ListItem>United Arab Emirates</asp:ListItem>
                            <asp:ListItem>United Kingdom</asp:ListItem>
                            <asp:ListItem>United States</asp:ListItem>
                            <asp:ListItem>United States Minor Outlying Islands</asp:ListItem>
                            <asp:ListItem>Uruguay</asp:ListItem>
                            <asp:ListItem>Uzbekistan</asp:ListItem>
                            <asp:ListItem>Vanuatu</asp:ListItem>
                            <asp:ListItem>Venezuela</asp:ListItem>
                            <asp:ListItem>Viet Nam</asp:ListItem>
                            <asp:ListItem>Virgin Islands, British</asp:ListItem>
                            <asp:ListItem>Virgin Islands, U.S.</asp:ListItem>
                            <asp:ListItem>Wallis and Futuna</asp:ListItem>
                            <asp:ListItem>Western Sahara</asp:ListItem>
                            <asp:ListItem>Yemen</asp:ListItem>
                            <asp:ListItem>Zambia</asp:ListItem>
                            <asp:ListItem>Zimbabwe</asp:ListItem>

                    </asp:DropDownList>

                              </td>
                              </tr>
                              <tr>
                              <td  class="td-personal">
                                  <asp:Label ID="Label1" runat="server" Text="Licence Expiry Date" Visible ="false"></asp:Label></td>
                              <td  class="td-personal"> 
                              <asp:TextBox  ID ="txtled"  Width="120px" runat="server"  TabIndex="32" Visible="false" ></asp:TextBox> 
                              </td>
                     	
                                <td  colspan ="2" class="td-personal"></td>
                               
                                </tr>
                              <tr>
                              <td colspan="4" >
                              <hr style ="color :#C0C0C0 ; size:1px ;height: -15px"/></td>
                              </tr>
                              <tr>		 
                              <td colspan="2"  class="td-personal"><b>Residential Address</b></td>
                              <td colspan="2"  class="td-personal"><b>Mailing Address</b></td>
                              </tr>
                              <tr>
                              <td  class="td-personal">Unit number:</td>
                              <td  class="td-personal"> 
                              <asp:TextBox  ID ="txtunitnor"  Width="55px" runat="server" MaxLength="8" TabIndex="33" ></asp:TextBox> 
                              </td>
                     	
                                <td  class="td-personal">Unit number:</td>
                                <td  class="td-personal"> 
                                <asp:TextBox  ID ="txtunitnom"  Width="55px" runat="server" MaxLength="8" TabIndex="34" ></asp:TextBox> </td>
                                </tr>    		
  	                            <tr>
  		                        <td  class="td-personal">Street number:</td>
                                <td  class="td-personal"> 
                                <asp:TextBox  ID ="txtstrtnor"  Width="55px" runat="server" MaxLength="8" TabIndex="35" ></asp:TextBox> 
                           
                                </td>

                                <td  class="td-personal">Street number:</td>
                                <td  class="td-personal">
                                <asp:TextBox  ID ="txtstrtnom"  Width="55px" runat="server" MaxLength="8" TabIndex="36" ></asp:TextBox> </td>
                                </tr>  
                                    		
                                <tr>
      		                    <td  class="td-personal">Street name:</td>
                                <td  class="td-personal"> 
                                <asp:TextBox  ID ="txtstrtnmr"  Width="165px" runat="server" MaxLength="60"  TabIndex="37" ></asp:TextBox> 
                               
                                </td>
                     	
                                <td  class="td-personal">Street name:</td>
                                <td  class="td-personal">
                                <asp:TextBox  ID ="txtstrtnmm"  Width="165px" runat="server" MaxLength="60"  TabIndex="38" ></asp:TextBox> </td>
                                </tr>  
                                    		
                                <tr>
      		                    <td  class="td-personal">Suburb:</td>
                                <td  class="td-personal"> 
                                <asp:TextBox  ID ="txtsubr"  Width="170px" runat="server" MaxLength="25" TabIndex="39" ></asp:TextBox> 
                                   
                                <asp:ImageButton ID="ImageButton2" runat="server" 
                                    ImageUrl="~/Images/Lookup.gif" style="width: 19px; height: 17px;" 
                                    OnClientClick ="getpage()"  />
                                </td>
                     	
 	                               <td  class="td-personal">Suburb:</td>
                                   <td  class="td-personal">
                                   <asp:TextBox  ID ="txtsubm"  Width="180px" runat="server" MaxLength="25"  TabIndex="40" ></asp:TextBox> 
                                   <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/Lookup.gif" OnClientClick ="getpage_m()" />
                                   </td>
                                   </tr>  
                                        		
                                    <tr>
          		                    <td  class="td-personal">Postcode:</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtpstcoder"  Width="55px" runat="server" MaxLength="4" TabIndex="41" ></asp:TextBox> 
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Lookup.gif" OnClientClick ="getpage()" />
                                   
                                    </td>
                     	
 	                                <td  class="td-personal">Postcode:</td>
                                    <td  class="td-personal">
                                    <asp:TextBox  ID ="txtpstcodem"  Width="55px" runat="server" MaxLength="4" TabIndex="42" ></asp:TextBox> 
                                    <asp:ImageButton ID="ImageButton5" runat="server" 
                                    ImageUrl="~/Images/Lookup.gif" OnClientClick ="getpage_m()" 
                                    style="width: 19px" />
                                    </td>
                                    </tr>  
                                        		
                                    <tr>
          		                    <td  class="td-personal">State:</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtstater"  Width="55px" runat="server" MaxLength="3" TabIndex="43"  ></asp:TextBox> 
                                   </td>
                     	
 	                                <td  class="td-personal">State:</td>
                                    <td  class="td-personal">
                                    <asp:TextBox  ID ="txtstatem"  Width="55px" runat="server" MaxLength="3" TabIndex="44" ></asp:TextBox> </td>
                                    </tr>  
                                    <tr>
                                    <td colspan="4" >
	                                <hr style ="color :#C0C0C0 ; size:1px ;height: -15px"/></td>
                                    </tr>

                    <%--................................................................--%>
                                    <tr>
                                    <td colspan="4" class="td-personal"><b>Employer Details</b></td>
                                    </tr>
                                    <tr>
          		                    <td  class="td-personal">Employment Status:</td>
                                    <td  class="td-personal"> 
                                    <asp:DropDownList ID="drop8" runat="server" Width ="100px" TabIndex="45">
                                    <asp:ListItem ></asp:ListItem>
                                        <asp:ListItem >Permanent</asp:ListItem>
                                        <asp:ListItem >Part Time</asp:ListItem>
                                        <asp:ListItem >Casual</asp:ListItem>
                                    </asp:DropDownList>
                                    	
                                        *</td>
                     	
 	                               <td  class="td-personal">Company name:</td>
                                   <td  class="td-personal"> 
                                   <asp:TextBox  ID ="txtcmpnmemp"  Width="190px" runat="server" MaxLength="60" TabIndex="46" ></asp:TextBox> *</td>
                                    </tr>  
                                    <tr>
          		                    <td  class="td-personal">Type&nbsp;of&nbsp;business:</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txttypbus"  Width="165px" runat="server" MaxLength="60"  TabIndex="47" ></asp:TextBox> 
                                   
                                    </td>
 	                                <td  class="td-personal">Contact number:&nbsp;</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtcnctnoemp"  Width="100px" runat="server" MaxLength="10" TabIndex="48" ></asp:TextBox> *</td>
                                    </tr>  
                             
                             
                                    <tr>
          		                    <td  class="td-personal">
                                        Suburb:</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtsub"  Width="150px" runat="server" MaxLength="25"  TabIndex="49" ></asp:TextBox> 
                                   
                                    </td>
                     	
 	                               <td  class="td-personal">Time&nbsp;with&nbsp;employer: </td>
 	                               <td  class="td-personal"> 
                                   <asp:TextBox  ID ="txtyrs"  Width="30px" runat="server" MaxLength="2" TabIndex="50" ></asp:TextBox>Yrs
                                   <asp:TextBox  ID ="txtmnths"  Width="30px" runat="server" MaxLength="2" Height="22px" TabIndex="51" ></asp:TextBox>Mths
                                   </td>
                                   </tr>  
                                   <tr>
          	                       <td  class="td-personal">Position:</td>
                                   <td  class="td-personal"> 
                                   <asp:TextBox  ID ="txtpos"  Width="200px" runat="server" MaxLength="25"  TabIndex="52" ></asp:TextBox> 
                                   </td>
 	                               <td  class="td-personal">Income:</td>
                                   <td  class="td-personal"> 
                                   <asp:TextBox  ID ="txtinc"  Width="75px" runat="server" MaxLength="4" TabIndex="53" ></asp:TextBox>
                                   <asp:DropDownList ID="DropDownList1" runat="server" Width ="120px">
                                       <asp:ListItem>Weekly</asp:ListItem>
                                       <asp:ListItem>Fortnightly</asp:ListItem>
                                       <asp:ListItem>Monthly</asp:ListItem>
                                  
                                   </asp:DropDownList>
                                   </td>
                                    </tr> 
                                     <tr>
          	                       <td  class="td-personal">Attention:</td>
                                   <td  class="td-personal"> 
                                   <asp:TextBox  ID ="txtattention"  Width="200px" runat="server" MaxLength="50"  TabIndex="54" ></asp:TextBox> 
                                   </td>
 	                               <td  class="td-personal">Fax:</td>
                                   <td  class="td-personal"> 
                                   <asp:TextBox  ID ="txtfax"  Width="100px" runat="server" MaxLength="50" TabIndex="55" ></asp:TextBox>  </td>
                                    </tr>  
                                     <tr>
          	                       <td  class="td-personal">Employee No:</td>
                                   <td  class="td-personal"> 
                                   <asp:TextBox  ID ="txtempno"  Width="80px" runat="server" MaxLength="50"  TabIndex="56" ></asp:TextBox> 
                                   </td>
 	                               <td  class="td-personal">E-mail:</td>
                                   <td  class="td-personal"> 
                                   <asp:TextBox  ID ="txt_email"  Width="200px" runat="server" MaxLength="100" TabIndex="57" ></asp:TextBox>  </td>
                                    </tr>     
                                    <tr>
                                    <td  class="td-personal">
                                    <asp:Label ID="Label2" runat="server" Text="Recruitment Agency" ></asp:Label></td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtragency"  Width="120px" runat="server"  TabIndex="58" ></asp:TextBox> 
                                    </td>
                                    <td class="td-personal"> Postcode:</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtemppostcode"  Width="120px" runat="server"  TabIndex="59" ></asp:TextBox> 
                                    </td>
                                    </tr>
                                     <tr>
                                    <td class="td-personal"> Street Name:</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtempstreetname"  Width="220px" runat="server"  TabIndex="60" ></asp:TextBox> 
                                    </td>
                                    </tr>
                                    <tr>
                                    <td colspan="4" ><hr style ="color :#C0C0C0 ; size:1px ;height: -15px"/></td>
                                     </tr>   
                             
                                    <tr> <td colspan="4" class="td-personal" ><b>Residential Details</b></td>
                                    </tr>
                                    <tr>
          		                    <td  class="td-personal">Residential Status:</td>
                                    <td  class="td-personal" > 
                                   <asp:DropDownList ID="drop9" runat="server" Width ="100px" TabIndex="61">
                                    <asp:ListItem ></asp:ListItem>
                                    <asp:ListItem >Rent</asp:ListItem>
                                    <asp:ListItem >Mortgage</asp:ListItem>
                                    <asp:ListItem >Boarding</asp:ListItem>
                                    <asp:ListItem >Own</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                    <td  class="td-personal"></td>
                                    <td  class="td-personal"> 
                                    </td>
                                    </tr>  
                                    <tr>
          		                    <td  class="td-personal" >Company name:&nbsp;</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtcmpnmres"  Width="190px" runat="server" MaxLength="62"  TabIndex="61" ></asp:TextBox> 
                                    *</td>
                     	
 	                                <td  class="td-personal">Contact number:&nbsp;</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtcnctres"  Width="120px" runat="server" MaxLength="10" TabIndex="63" ></asp:TextBox> *</td>
                                    </tr>           
                                    <tr>
                                    <td colspan="4" >
	                                <hr style ="color :#C0C0C0 ; size:1px ;height: -15px"/></td>
                                    </tr> 
                                    <tr> <td colspan="4" class="td-personal" ><b>Financial Details</b><hr style ="color :#C0C0C0 ; size:1px ;height: -15px"/></td>
                                    </tr>
                                    <tr>
          		                    <td  class="td-personal" >Monthly Household:&nbsp;</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox ID ="txthousehold"  Width="80px" runat="server" MaxLength="10"  TabIndex="64" ></asp:TextBox> 
                                    </td>
                     	
 	                                <td  class="td-personal">Rent Mortgage:&nbsp;</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtrentmortgage"  Width="80px" runat="server" MaxLength="10" TabIndex="65" ></asp:TextBox> </td>
                                    </tr>  
                                     <tr>
          		                    <td  class="td-personal" >Loan Repayment:&nbsp;</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtrepay"  Width="80px" runat="server" MaxLength="10"  TabIndex="66" ></asp:TextBox> 
                                    </td>
                     	
 	                                <td  class="td-personal">Monthly Food:&nbsp;</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtfood"  Width="80px" runat="server" MaxLength="10" TabIndex="67" ></asp:TextBox> </td>
                                    </tr>  
                                     <tr>
          		                    <td  class="td-personal" >Monthly Others:&nbsp;</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtothers"  Width="80px" runat="server" MaxLength="10"  TabIndex="68" ></asp:TextBox> 
                                    </td>
                     	
 	                                <td  class="td-personal">Monthly Utilities:&nbsp;</td>
                                    <td  class="td-personal"> 
                                    <asp:TextBox  ID ="txtuti"  Width="80px" runat="server" MaxLength="10" TabIndex="69" ></asp:TextBox> </td>
                                    </tr>  
                                    
                                    
                                    <tr>
                                    <td colspan="4" >
	                                <hr style ="color :#C0C0C0 ; size:1px ;height: -15px"/></td>
                                    </tr>
                                    <tr> <td></td></tr>
                                    <tr>
                                    <td></td>
                                    <td style ="text-align:right"><asp:Button ID="Print_btn" runat="server" Text="Print"   Width ="70px"  />
                                    <br /><br />
                                    </td>
                                    <td>
                                    <asp:Button ID="Update_btn" runat="server" Text="Update"  Width ="70px"  /> 
                                    <br /> <br />
                                    </td>
                                    <td>
                                    </td>
                                    </tr>
     
          
                     
                           <%--</table>--%>
            
            
            
                         
                            </table>                
    
                
                   
                            </div> 
                        </td>
                   </tr>
                  </table>
          </asp:Panel>
       
     
        
    </div>
  </form>
  </body>
</html>
