<%@ Page Language="VB" AutoEventWireup="false" CodeFile="print.aspx.vb" Inherits="Reports_print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print</title>
   
<%--    <link rel="Stylesheet" href="../css/print.css" media="print" />
    <link rel="Stylesheet" href="../css/print.css" media="screen" />--%>
    <style type="text/css">

	p.MsoNormal
	{
		mso-style-parent:"";
		margin-bottom:.0001pt;
		font-size:12.0pt;
		font-family:"Times New Roman";
		margin-left:0in; margin-right:0in; margin-top:0in
	}
h1
	{margin-top:12.0pt;
	margin-right:0cm;
	margin-bottom:0cm;
	margin-left:35.45pt;
	margin-bottom:.0001pt;
	text-indent:-35.45pt;
	font-size:10.0pt;
	font-family:Helvetica-Narrow;
	font-weight:normal}
 table.MsoNormalTable
	{mso-style-parent:"";
	font-size:10.0pt;
	font-family:"Times New Roman"}
div.Section1
	{page:Section1;}
span.GramE
	{}
-->
  </style>
    <%--<style type='text/css' >
        body{background-color: #ffffff; color: #000000;font-family:  Arial, Helvetica, sans-serif; width: 595px !important;}
        *{margin: 0px;padding: 0px;  }
        .footer{background-color: #fff;height: 21px;line-height: 20px;text-align: left;color: #000;
            padding-left:5px;padding-right:5px;font-size: 12px; }
        .heading {color: #000;font-size: 16px;font-style: normal;font-variant: normal;font-weight: bold; 
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
            font-size: 14px;
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
        }
        .namenormal a
        {
         
            color: #666666;
            text-decoration: none;           
          
        }
        p.sign
        {
        	margin-top:2px;
        	margin-bottom:1px;
        	line-height:20px;
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
        	border:none;}
        p.small
        {
        	font-size:12px;
        }
       </style>--%>
       <script type='text/javascript'>function PrintWindow() {window.print();CheckWindowState();}function CheckWindowState() { if(document.readyState=="complete") {window.close(); } else {setTimeout("CheckWindowState()", 2000)}} PrintWindow();</script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    </form>
</body>
</html>
