
function getbsb()

 {
    window.open("BSB_Look_Up.aspx?Name=" + document.getElementById("txtBSB").value, "Mywindow", toolbar = 0)

}


function print_account() {
    window.location.assign("../Reports/Accountstprint.aspx", "Mywindow", toolbar = 0)
    }


function addcom() 
{

    var obj = document.getElementById('txtBSB');
    var len = obj.value.length;
    if (len == 3) {
        obj.value += '-';
    }
    else {
        return;
    }
}


function getpage() 
{
    window.open("Address_Look_Up.aspx?Name=" + document.getElementById("txtsubr").value, "Mywindow", toolbar = 0)

}

function getpage_m()
 {
    window.open("Address_Look_Upm.aspx?Name=" + document.getElementById("txtsubm").value, "Mywindow", toolbar = 0)

}

function getpage_new() {
    window.open("Address_Look_Up_New.aspx?Name=" + document.getElementById("txtsub_new").value, "Mywindow", toolbar = 0)

}
function getpage_enew() {
    window.open("Address_Look_Up_ENew.aspx?Name=" + document.getElementById("txtesub_new").value, "Mywindow", toolbar = 0)

}
function fn_View_Record(a,given_Name,last_name) 
{
    var st = a
    var given_name = given_Name
    var last_name = last_name
   window.location.assign("Detail.aspx?Name=" +
a + "&Given_Name=" + given_name + "&Last_Name=" +
last_name);
}
function fn_View_Record1(a, given_Name, last_name) {
    var st = a
    var given_name = given_Name
    var last_name = last_name
    window.location.assign("../Customer/Detail.aspx?Name=" +
a + "&Given_Name=" + given_name + "&Last_Name=" +
last_name);
}
function fn_View_more(loan_amt, from_date, to_date,amt_val)
 {
    var amt_vl=amt_val 
    var amt = loan_amt
    var from_dt = from_date
    var to_dt = to_date
    window.location.assign("loan_stats.aspx?Amt=" +
amt + "&From_Dt=" + from_dt + "&To_Dt=" +
to_dt + "&Amt_VL=" +
amt_vl);
}

function fn_View_sex(sex, from_date, to_date, sex_val) {
    var sex_vl = sex_val
    var Sex = sex
    var from_dt = from_date
    var to_dt = to_date
    window.location.assign("sex_status.aspx?SEX=" +
Sex + "&From_Dt=" + from_dt + "&To_Dt=" +
to_dt + "&SEX_VL=" +
sex_vl);
}
   
   
function clearTextBox(textBoxID1, textBoxID2) {
    document.getElementById(textBoxID1).value = "";
    document.getElementById(textBoxID2).value = "";
}
function CalShown(lbl, txt) {
    alert(lbl);
    var st = document.getElementById(txt).value;
    var myDate = new Date(st);
    document.getElementById(lbl).value = myDate.getday();
   
}


function getpage_add() {
    window.open("Address_Look_Up.aspx?Name=" + document.getElementById("txtsubr").value, "Mywindow", toolbar = 0);


}

function getpage_m_add() {
    window.open("Address_Look_Upm.aspx?Name=" + document.getElementById("txtsubm").value, "Mywindow", toolbar = 0);

}

function showDate(sender, args) {
    if (sender._textbox.get_element().value == "") {
        var todayDate = new Date();
        sender._selectedDate = todayDate;
    }
}