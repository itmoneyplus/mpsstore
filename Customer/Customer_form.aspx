<%@ Page Language="VB" Culture="en-AU" AutoEventWireup="false" CodeFile="Customer_form.aspx.vb" Inherits="Customer_Customer_form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer form</title>
   <script type="text/javascript" src="../frm_val.js" >
    
       </script>
       <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
   
</head>
<body onload='window.print();' ondblclick='JavaScript:history.go(-1);'>
    <form id="form1" runat="server">
    <div align="center" >
     <table border="0" cellpadding="3" cellspacing="0" class="table-top">
        <tr>
        <td colspan="4" class="top-italics-style" ><b>Customer Details:</b></td>
        </tr>
        <tr>    
        <td  class="td-personal_new" >Amount requested:</td>
        <td class="td-personal_new"  >
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
       <td class="td-personal_new">Purpose of loan:</td>
       <td class="td-personal_new">
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
        <td class="td-personal_new">Customer&nbsp;ID:</td>
        <td class="td-personal_new"> 
        <asp:Label ID="lbl_custid" runat="server" Text="Label"></asp:Label></td>
        <td class="td-personal_new">Marketing&nbsp;phrase:</td>
        <td class="td-personal_new" >
        <asp:DropDownList  ID="drop3" runat="server" height="22px" width="120px" TabIndex="12">
                       
        <asp:ListItem ></asp:ListItem>
        <asp:ListItem >Relative</asp:ListItem>
        <asp:ListItem >Friend</asp:ListItem>
        <asp:ListItem >Direct Marketing</asp:ListItem>
        <asp:ListItem >Word of mouth</asp:ListItem>
        <asp:ListItem >Walk By</asp:ListItem>
        <asp:ListItem >Yellow Pages</asp:ListItem>
        <asp:ListItem >Local Newspaper</asp:ListItem>
        <asp:ListItem >The Age</asp:ListItem>
        <asp:ListItem >The SMH</asp:ListItem>
        <asp:ListItem >The Herald Sun</asp:ListItem>
        <asp:ListItem >Television</asp:ListItem>
        <asp:ListItem >Internet</asp:ListItem>
        <asp:ListItem >Radio</asp:ListItem>
        <asp:ListItem >Other</asp:ListItem>
       </asp:DropDownList>*
       </td>
       </tr>

<%--    ............................................................................--%>
        <tr>    
        <td colspan="4" >
        <hr /></td></tr>
        <tr>
        <td class="td-personal_new"><b>Personal Details</b></td>
        </tr>
        <tr>
   
    	<td class="td-personal_new"   >Title:</td>
    	<td class="td-personal_new"  >
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
  		<td class="td-personal_new" >Work&nbsp;phone:</td>
    	<td class="td-personal_new" >
    	<asp:TextBox  ID= "txtwrk" runat="server" Width ="165px" MaxLength="10" TabIndex="14" />
                
    	*</td></tr>
  		<tr>
  		<td class="td-personal_new" >Last name:</td>
        <td class="td-personal_new"> 
        <asp:TextBox  ID ="txtlastname"  Width="150px" runat="server" MaxLength="25"  TabIndex="15" ></asp:TextBox>* </td>
        <td class="td-personal_new">Home phone:</td>
        <td  class="td-personal_new">
		<asp:TextBox runat="server" ID="txtHomePhone"  Width="165px" MaxLength="10" TabIndex="16"></asp:TextBox>
		</td> 
  		</tr>
        <tr>
  		<td class="td-personal_new">Given name:</td>
        <td  class="td-personal_new"> 
        <asp:TextBox  ID ="txtgvnname"  Width="150px" runat="server" MaxLength="25" TabIndex="17" ></asp:TextBox>* </td>
        <td  class="td-personal_new">Mobile:</td>
        <td  class="td-personal_new" >
		<asp:TextBox runat="server" ID="txtmobile"  Width="150px" MaxLength="10" TabIndex="18"></asp:TextBox>		
	    *</td> 
  		</tr>
         <tr>
         <td  class="td-personal_new" >Date of&nbsp; birth:</td>
         <td class="td-personal_new" >                		                		
         
        <asp:TextBox ID="txtdtbirth" runat="server" Width ="130px" MaxLength="10" TabIndex="19"  ></asp:TextBox>
      
        </td>

    	<td class="td-personal_new">Email: </td>
    	<td  class="td-personal_new" >
        <asp:TextBox ID="txtEmail" runat ="server" Width ="180px" MaxLength="40" TabIndex="20"  ></asp:TextBox>*</td> 
        </tr><tr>
     	<td  class="td-personal_new"  >Marital status:</td>
     	<td class="td-personal_new" >
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
                <td  colspan ="2">&nbsp;</td>
                 </tr> 
	   <%-- <tr>
  		<td  class="td-personal_new">LastName(Spouse):</td>
        <td  class="td-personal_new"> 
        <asp:TextBox  ID ="txtlastnamesp"  Width="150px" runat="server" MaxLength="25"  TabIndex="22" ></asp:TextBox></td>
        <td  class="td-personal_new">GivenName(Spouse):</td>
        <td  class="td-personal_new"> 
        <asp:TextBox  ID ="txtgvnnamesp"  Width="150px" runat="server" MaxLength="25"  TabIndex="23" ></asp:TextBox> </td>
        </tr> --%>
         
            <%--    .......................................................--%>
        <tr>
        <td colspan="4" >
        <hr style ="color :#C0C0C0 ; size:1px ;height: -15px"/></td>
        </tr>
        <tr>
        <td class="td-personal_new"><b>Identity Verifications</b></td>
        </tr>
       <tr>
       <td class="td-personal_new">Driver&nbsp;Licence&nbsp;Number:</td>
       <td  class="td-personal_new">
       <asp:TextBox runat="server" ID="txtDLicence" width="150px" MaxLength="10" TabIndex="26"></asp:TextBox> </td>
       <td class="td-personal_new">Passport Number:</td>
       <td  class="td-personal_new">
       <asp:TextBox runat="server" ID="txtPassport" Width="150px" MaxLength="10"  TabIndex="27"></asp:TextBox></td>
       </tr>
 	    <tr>
  	    <td  class="td-personal_new"  >Licence&nbsp;Card Number:</td>
  	    <td  class="td-personal_new" >
                		
	    <asp:TextBox runat="server" ID="txtLicence_card_no" width="150px" 
        MaxLength="10" TabIndex="28"></asp:TextBox> </td>
        <td  class="td-personal_new"  >Place of Birth:</td>
        <td  class="td-personal_new"  >
        <asp:TextBox runat="server" ID="txtPlace_Of_Birth" Width="165px" MaxLength="25"  TabIndex="29"></asp:TextBox></td>
        </tr>
 	    <tr>
      	<td  class="td-personal_new">Issuing State:</td>
      	<td  class="td-personal_new"  >
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
           
      <td  class="td-personal_new">Issuing Country:</td>
      <td class="td-personal_new">
        <asp:DropDownList ID="drop7" runat="server" TabIndex="31" Width ="200px">
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
          <td  class="td-personal_new">
              <asp:Label ID="Label1" runat="server" Text="Licence Expiry Date" Visible ="false"></asp:Label></td>
          <td  class="td-personal_new"> 
          <asp:TextBox  ID ="txtled"  Width="120px" runat="server"  TabIndex="32" Visible="false" ></asp:TextBox> 
          </td>
 	
            <td  colspan ="2" class="td-personal_new"></td>
           
            </tr>
           
          <tr>
          <td colspan="4" >
          <hr style ="color :#C0C0C0 ; size:1px ;height: -15px"/></td>
          </tr>
          
          <tr>		 
          <td colspan="2"  class="td-personal_new"><b>Residential Address</b></td>
          <td colspan="2"  class="td-personal_new"><b>Mailing Address</b></td>
          </tr>
           <tr>
                <td  colspan ="2">&nbsp;</td>
                 </tr> 
          <tr>
          <td  class="td-personal_new">Unit number:</td>
          <td  class="td-personal_new"> 
          <asp:TextBox  ID ="txtunitnor"  Width="55px" runat="server" MaxLength="8" TabIndex="33" ></asp:TextBox> 
          </td>
 	
            <td  class="td-personal_new">Unit number:</td>
            <td  class="td-personal_new"> 
            <asp:TextBox  ID ="txtunitnom"  Width="55px" runat="server" MaxLength="8" TabIndex="34" ></asp:TextBox> </td>
            </tr>    		
  	        <tr>
  		    <td  class="td-personal_new">Street number:</td>
            <td  class="td-personal_new"> 
            <asp:TextBox  ID ="txtstrtnor"  Width="55px" runat="server" MaxLength="8" TabIndex="35" ></asp:TextBox> 
       
            </td>

            <td  class="td-personal_new">Street number:</td>
            <td  class="td-personal_new">
            <asp:TextBox  ID ="txtstrtnom"  Width="55px" runat="server" MaxLength="8" TabIndex="36" ></asp:TextBox> </td>
            </tr>  
                		
            <tr>
      		<td  class="td-personal_new">Street name:</td>
            <td  class="td-personal_new"> 
            <asp:TextBox  ID ="txtstrtnmr"  Width="165px" runat="server" MaxLength="60"  TabIndex="37" ></asp:TextBox> 
           
            </td>
 	
            <td  class="td-personal_new">Street name:</td>
            <td  class="td-personal_new">
            <asp:TextBox  ID ="txtstrtnmm"  Width="165px" runat="server" MaxLength="60"  TabIndex="38" ></asp:TextBox> </td>
            </tr>  
                		
            <tr>
      		<td  class="td-personal_new">Suburb:</td>
            <td  class="td-personal_new"> 
            <asp:TextBox  ID ="txtsubr"  Width="165px" runat="server" MaxLength="25" TabIndex="39" ></asp:TextBox> 
               
            </td>
 	
 	           <td  class="td-personal_new">Suburb:</td>
               <td  class="td-personal_new">
               <asp:TextBox  ID ="txtsubm"  Width="180px" runat="server" MaxLength="25"  TabIndex="40" ></asp:TextBox> 
               
               </td>
               </tr>  
                    		
                <tr>
          		<td  class="td-personal_new">Postcode:</td>
                <td  class="td-personal_new"> 
                <asp:TextBox  ID ="txtpstcoder"  Width="55px" runat="server" MaxLength="4" TabIndex="41" ></asp:TextBox> 
                
               
                </td>
 	
 	            <td  class="td-personal_new">Postcode:</td>
                <td  class="td-personal_new">
                <asp:TextBox  ID ="txtpstcodem"  Width="55px" runat="server" MaxLength="4" TabIndex="42" ></asp:TextBox> 
                
                </td>
                </tr>  
                    		
                <tr>
          		<td  class="td-personal_new">State:</td>
                <td  class="td-personal_new"> 
                <asp:TextBox  ID ="txtstater"  Width="55px" runat="server" MaxLength="3" TabIndex="43"  ></asp:TextBox> 
               </td>
 	
 	            <td  class="td-personal_new">State:</td>
                <td  class="td-personal_new">
                <asp:TextBox  ID ="txtstatem"  Width="55px" runat="server" MaxLength="3" TabIndex="44" ></asp:TextBox> </td>
                </tr>  
               <tr>
                <td  colspan ="2">&nbsp;</td>
                 </tr> 
                <tr>
                <td colspan="4" >
	            <hr style ="color :#C0C0C0 ; size:1px ;height: -15px"/></td>
                </tr>
               
<%--................................................................--%>
                <tr>
                <td colspan="4" class="td-personal_new"><b>Employer Details</b></td>
                </tr>
                
                <tr>
          		<td  class="td-personal_new">Employment Status:</td>
                <td  class="td-personal_new"> 
                <asp:DropDownList ID="drop8" runat="server" Width ="100px" TabIndex="45">
                <asp:ListItem ></asp:ListItem>
                    <asp:ListItem >Permanent</asp:ListItem>
                    <asp:ListItem >Part Time</asp:ListItem>
                    <asp:ListItem >Casual</asp:ListItem>
                </asp:DropDownList>
                	
                    *</td>
 	
 	           <td  class="td-personal_new">Company name:</td>
               <td  class="td-personal_new"> 
               <asp:TextBox  ID ="txtcmpnmemp"  Width="190px" runat="server" MaxLength="60" TabIndex="46" ></asp:TextBox> *</td>
                </tr>  
                <tr>
          		<td  class="td-personal_new">Type&nbsp;of&nbsp;business:</td>
                <td  class="td-personal_new"> 
                <asp:TextBox  ID ="txttypbus"  Width="165px" runat="server" MaxLength="60"  TabIndex="47" ></asp:TextBox> 
               
                </td>
 	            <td  class="td-personal_new">Contact number:&nbsp;</td>
                <td  class="td-personal_new"> 
                <asp:TextBox  ID ="txtcnctnoemp"  Width="100px" runat="server" MaxLength="10" TabIndex="48" ></asp:TextBox> *</td>
                </tr>  
         
         
                <tr>
          		<td  class="td-personal_new">
                    Suburb:</td>
                <td  class="td-personal_new"> 
                <asp:TextBox  ID ="txtsub"  Width="150px" runat="server" MaxLength="25"  TabIndex="49" ></asp:TextBox> 
               
                </td>
 	
 	           <td  class="td-personal_new">Time&nbsp;with&nbsp;employer: </td>
 	           <td  class="td-personal_new"> 
               <asp:TextBox  ID ="txtyrs"  Width="30px" runat="server" MaxLength="2" TabIndex="50" ></asp:TextBox>Yrs
               <asp:TextBox  ID ="txtmnths"  Width="30px" runat="server" MaxLength="2" Height="22px" TabIndex="51" ></asp:TextBox>Mths
               </td>
               </tr>  
               <tr>
          	   <td  class="td-personal_new">Position:</td>
               <td  class="td-personal_new"> 
               <asp:TextBox  ID ="txtpos"  Width="165px" runat="server" MaxLength="25"  TabIndex="52" ></asp:TextBox> 
               </td>
 	           <td  class="td-personal_new">Income:</td>
               <td  class="td-personal_new"> 
               <asp:TextBox  ID ="txtinc"  Width="75px" runat="server" MaxLength="4" TabIndex="53" ></asp:TextBox>
               <asp:DropDownList ID="DropDownList1" runat="server" Width ="120px">
                   <asp:ListItem>Weekly</asp:ListItem>
                   <asp:ListItem>Fortnightly</asp:ListItem>
                   <asp:ListItem>Monthly</asp:ListItem>
              
               </asp:DropDownList>
               </td>
                </tr> 
                 <tr>
          	   <td  class="td-personal_new">Attention:</td>
               <td  class="td-personal_new"> 
               <asp:TextBox  ID ="txtattention"  Width="165px" runat="server" MaxLength="50"  TabIndex="54" ></asp:TextBox> 
               </td>
 	           <td  class="td-personal_new">Fax:</td>
               <td  class="td-personal_new"> 
               <asp:TextBox  ID ="txtfax"  Width="100px" runat="server" MaxLength="50" TabIndex="55" ></asp:TextBox>  </td>
                </tr>  
                 <tr>
          	   <td  class="td-personal_new">Employee No:</td>
               <td  class="td-personal_new"> 
               <asp:TextBox  ID ="txtempno"  Width="80px" runat="server" MaxLength="50"  TabIndex="56" ></asp:TextBox> 
               </td>
 	           <td  class="td-personal_new">E-mail:</td>
               <td  class="td-personal_new"> 
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
                <asp:TextBox  ID ="txtempstreetname"  Width="165px" runat="server"  TabIndex="60" ></asp:TextBox> 
                </td>
                </tr>
               <tr>
                <td colspan="4" ><hr style ="color :#C0C0C0 ; size:1px ;height: -15px"/></td>
                 </tr>  
                <tr>
                <td colspan="4" ><hr style ="color :#C0C0C0 ; size:1px ;height: -15px"/></td>
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
                <asp:TextBox  ID ="txtcmpnmres"  Width="150px" runat="server" MaxLength="62"  TabIndex="61" ></asp:TextBox> 
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
                
     
           </table>
    </div>
    </form>
</body>
</html>
