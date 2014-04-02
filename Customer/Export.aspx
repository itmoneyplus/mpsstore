<%@ Page Language="VB"  EnableEventValidation="false" AutoEventWireup="false" CodeFile="Export.aspx.vb" Inherits="Customer_Export" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <title>Export File</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
        </head>
    <body onload="window.print();" ondblclick="javascript:history.back();">
    <form id="form1" runat="server" >
    <table  style="border:1px solid #000000; border-collapse: collapse; margin-left:.15in;width:850px">
    <tr>
    <td  style="text-align:center;font-style: italic;font-size:28px;font-weight:bold">
    <br />Export Customer Documents<br /></td> 
    </tr> 
    </table> 
    <table style="border:1px solid #000000; border-collapse: collapse; margin-left:.15in;width:850px">
    <tr><td colspan ="6">&nbsp;</td></tr>
    <tr>
    <td colspan ="6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:Label ID="lblcustname" runat="server" Text="Label"></asp:Label>&nbsp;<asp:Label ID="lblcustid" runat="server" Text="Label"></asp:Label></td>
    </tr> 
    <tr><td colspan ="6">&nbsp;</td></tr>
    <tr><td colspan ="6" style="font-family:Times New Roman;font-size :21px;text-decoration :underline;text-align:left;font-weight:bold  ">Personal Details:</td></tr>
    <tr><td colspan ="6">&nbsp;</td></tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px">Title:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="titval" runat="server" Text="Label"></asp:Label></td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Work Phone:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="wrkval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Last Name:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="lastnameval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Home Phone:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="homephval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Given Name:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="gvnnmval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Mobile Phone:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="mobilephval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Date Of Birth:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="dobval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Email:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="emailval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> &nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> &nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >&nbsp;</td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> &nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> &nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >&nbsp;</td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Street Number:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="stnoval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Mailing Address:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="maddval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Street Name:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="stnmval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Street Name:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="mstnmval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Suburb:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="subval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Suburb:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="msubval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> PostCode:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="postcodeval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> PostCode:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="mpostcodeval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> State:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="stateval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> State:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="mstateval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"></td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> </td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >&nbsp;</td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"></td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> </td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >&nbsp;</td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Marital Status:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="mstatusval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Residential Status:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="rstatusval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Last Name(Spouse):</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="rlastnmval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Relationship:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="Label22" runat="server" Text=""></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Given Name(spouse):</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="rgvnnmval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Joint Borrowing:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="Label24" runat="server" Text=""></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"> Marketing Phrase:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="mphraseval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px"></td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >&nbsp;</td>
    </tr> 
   
    <tr><td colspan ="6">&nbsp;</td></tr>
    <tr><td colspan ="6">&nbsp;</td></tr>
    <tr><td colspan ="6" style="font-family:Times New Roman;font-size :21px;text-decoration :underline;text-align:left;font-weight:bold  ">Employer Details:</td></tr>
    <tr><td colspan ="6">&nbsp;</td></tr>
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:230px"> Employer:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="empval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:230px">Employers Email:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="empemailval" runat="server" Text="Label"></asp:Label>
   </td>
    </tr> 
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:230px"> Contact Name:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="empcnameval" runat="server" Text="Label" Width="40px"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px">Type of 
        Business:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="typebusval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr> 
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:230px"> Phone Number:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="empphval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px">Pay Transfer Ref:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="ptrval" runat="server" Text="Label"></asp:Label>
   </td>
    </tr> 
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:230px"> Fax Number:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="faxnoval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px">Street No. and Street Name:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="empstsnval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr> 
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:230px"> Employee No.:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="empnoval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px">Suburb:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
        <asp:Label ID="empsuburbval" runat="server" Text="Label"></asp:Label>
                </td>
    </tr> 
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:230px"> Position:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="posval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px">Post Code:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="emppostcodeval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr> 
    <tr>
    <td style="font-family:Times New Roman;font-size :18px;width:20px"></td>
    <td style="font-family:Times New Roman;font-size :18px;width:230px"> Income:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="incomeval" runat="server" Text="Label"></asp:Label>
    </td>
    <td style="font-family:Times New Roman;font-size :18px;width:20px" >&nbsp;</td>
    <td style="font-family:Times New Roman;font-size :18px;width:250px">State:</td>
    <td style="font-family:Times New Roman;font-size :18px;text-align:left;width:300px" >
    <asp:Label ID="empstateval" runat="server" Text="Label"></asp:Label>
    </td>
    </tr> 
     <tr><td colspan ="6">&nbsp;</td></tr>
    <tr><td colspan ="6">&nbsp;</td></tr>
    <tr><td colspan ="6" style="font-family:Times New Roman;font-size :2&nbsp;</td></tr>
    <tr><td colspan ="6" style="font-family:Times New Roman;font-size :21px;text-decoration :underline;text-align:left;font-weight:bold  ">
        Loan Details:</td></tr>
    <tr><td colspan ="6">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="850px">
            <Columns>
                <asp:BoundField HeaderText="Date" />
                <asp:BoundField HeaderText="Loan ID" />
                <asp:BoundField HeaderText="Amount" />
                <asp:BoundField HeaderText="Last Notice" />
                <asp:BoundField HeaderText="Last Payment" />
                <asp:BoundField HeaderText="Dishonours" />
                <asp:BoundField HeaderText="Status" />
            </Columns>
        </asp:GridView>
        </td></tr>
    
    
    </table>
   
    
    </form>
    </body>
    </html>

         
          
         
        
         
           
          
          
           
       
        
           
         
          
           
          
          



