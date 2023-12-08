var $ = jQuery.noConflict();
$(document).ready(function () {
    getSetWelcomeMessage();
    BindMenu();
    SetMenu();
    $("#issueBody").removeClass("sidebar-mini");
    $("#issueBody").removeClass("layout-fixed");
    function disableBack() { window.history.forward() }
    window.onload = disableBack();
    window.onpageshow = function (evt) { if (evt.persisted) disableBack() }
});


function ChangeBreadCrumb(menuHeading, mainMenu, menuLabel) {
    $("#headingcurrMenu").html(menuHeading);
    $("#lblmainMenu").html(mainMenu);
    $("#lblcurrMenu").html(menuLabel);
}


function Timer() {
    var currdt = new Date();
    $("#txtTime").val(formatAMPM(currdt));
    setTimeout(Timer, 500);
}

function changeDate() {
    var currdt = new Date();
    var mth = (currdt.getMonth()+1);
    var dy = currdt.getDate();
    var yr =Math.abs(currdt.getFullYear());
    if (mth < 10) {   mth = '0' + mth; }
    if (dy < 10) {   dy = '0' + dy; }
    var dt =mth + '/' + dy + '/' + yr;
    $("#txtDate").val(ChangeDateFormat2(dt));
    $("#txtFroDat").val(ChangeDateFormat2(dt));
    $("#txtToDat").val(ChangeDateFormat2(dt));
}



function isEmpty(val) {

    // test results
    //---------------
    // [] true, empty array
    // {} true, empty object
    // null true
    // undefined true
    // "" true, empty string
    // '' true, empty string
    // 0 false, number
    // true false, boolean
    // false false, boolean
    // Date false
    // function false

    if (val === undefined)
        return true;

    if (typeof (val) == 'function' || typeof (val) == 'number' || typeof (val) == 'boolean' || Object.prototype.toString.call(val) === '[object Date]')
        return false;

    if (val == null || val.length === 0) // null or 0 length array
        return true;

    if (typeof (val) == "object") {
        // empty object

        var r = true;

        for (var f in val)
            r = false;

        return r;
    }

    return false;
}




String.format = function () {
    // The string containing the format items (e.g. "{0}")
    // will and always has to be the first argument.
    var theString = arguments[0];
    // start with the second argument (i = 1)
    for (var i = 1; i < arguments.length; i++) {
        // "gm" = RegEx options for Global search (more than one instance)
        // and for Multiline search
        var regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
        theString = theString.replace(regEx, arguments[i]);
    }

    return theString;
}

function getSessionVariables() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/getSessionVariables",
            data: "{}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}


function formatAMPM(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return strTime;
}


function ChangeDateFormat(dt) {
    var formatted_date = "";
    if (dt == null || dt == "") return formatted_date;
    //    var d = new Date(dt);
    var d = new Date(parseInt(dt.substr(6)));
    var date = d.getDate();
    var month = d.getMonth();
    var year = d.getFullYear();
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
    // let current_datetime = new Date()
    var formatted_date = date + "-" + months[month] + "-" + year;
    return formatted_date;
}

function ChangeDateFormat1(dt) {
    var formatted_date = "";
    if (dt == null || dt == "") return formatted_date;
    var d = new Date(dt);
    //    var d = new Date(parseInt(dt.substr(6)));
    var date = d.getDate();
    var month = d.getMonth();
    var year = d.getFullYear();
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
    // let current_datetime = new Date()
    var formatted_date = date + "-" + months[month] + "-" + year;
    return formatted_date;
}

function ChangeDateFormat2(dt) {
    var formatted_date = "";
    if (dt == null || dt == "") return formatted_date;
    var d = new Date(dt);
    var month = d.getMonth();
    var date = d.getDate();
    var year =Math.abs(d.getFullYear());
    if (month < 10) {   month = '0' + month; }
    if (date < 10) {   date = '0' + date; }
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
    // let current_datetime = new Date()
    var formatted_date = date + "-" + months[parseInt(month)] + "-" + year;
    return formatted_date;
}



function DateInYYYYMMDD(date) 
{
    var dateOut = date.split(/[/,-]/); //  (/[!,?,/,-,.]/);  //    .toString().split("/").split("-");
    var resultDate = new Date(dateOut[2] + "/" + dateOut[1] + "/" + dateOut[0]);
    return resultDate; 
}


async function getSetWelcomeMessage()
{
    var ErrMsg=null;
    var userName_Link= $("[id*=userName_Link]");
    try 
    {
//        var usercd= await  getSessionVariables();
        var usercd= $("#hdfUserName").val();
        if (usercd.length ==0)
        {
            $("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
            toastr.error("Session Expired", {timeOut: 200});
//            setTimeout(window.location.href= String.format("{0}/Login/Login",window.location.origin),10000);
            setTimeout(window.location.href = "/Login/Login", 10000);
            return;
        }
        if(usercd.length > 0)
        {
            var res= await Set_Welcome_Message(usercd.toString().trim());
            if (res.response ==-1) {
                ErrMsg = res.responseMsg;
                throw ErrMsg;
            }        
            userName_Link.text(String.format("Welcome, {0}", res.responseObject.empnm));
            userName_Link.removeAttr("href");
            userName_Link.css('color', '#6f42c1');       
        }
    } 
    catch (err) 
    {
    
    }
}


async function BindMenu()
{
//	var usercd= await  getSessionVariables();
 var usercd= $("#hdfUserName").val();
	if (usercd.length ==0)
	{
		$("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		toastr.error("Session Expired", {timeOut: 200});
		setTimeout(window.location.href = "/Login/Login", 10000);
		return;
	}
    if (usercd.length >0) 
    {
        var myData=usercd.toString().trim()
        var navrows =null;
        var menuBar = $("[id*=navigation1]");
        navrows = '<li class="nav-item menu-open"><a href="/Home/Home" class="nav-link active" ><i class="nav-icon fas fa-tachometer-alt"></i><p>Home<i class="right fas fa-angle-left"></i></p></a></li>';
        menuBar.append(navrows);
        //------Add Administrator Menu ------------
        if (myData.toString().trim() == "H21083") 
        {
            navrows =null;
            navrows ='<li class ="nav-item"><a href="#" class="nav-link" id="mnu_Admin"><i class="nav-icon fas fa-cog"></i><p>Administrator<i class="fas fa-angle-left right"></i></p></a><ul class="nav nav-treeview">';
            navrows += '<li class="nav-item"  id="li_NewIDcreate"><a href="/Administrator/NewIssueId" class="nav-link"><i class="far fa-circle nav-icon"></i><p>New ID Creation</p></a></li>' ;
            navrows += '<li class="nav-item" id="li_IssueIDDetail"><a href="/Administrator/UserDetail" class="nav-link"> <i class="far fa-circle nav-icon"></i><p>Issue ID Detail</p></a></li></ul></li>';
            menuBar.append(navrows);
        }
        //-------------end-------------------------

        //-------Add Main Menu---------------------
        navrows =null;
        navrows =  '<li class ="nav-item"><a href="#" class="nav-link" id="mnu_Main"><i class="nav-icon fas fa-edit"></i><p>Main<i class="fas fa-angle-left right"></i></p></a><ul class="nav nav-treeview">';
        navrows += '<li class="nav-item" id="li_VEF"><a href="/Main/MIVEntry" class="nav-link"> <i class="far fa-circle nav-icon"></i><p>Voucher Entry Form</p></a></li>';
        navrows += '<li class="nav-item" id="li_changePassword"><a href="/Main/Password" class="nav-link"> <i class="far fa-circle nav-icon"></i><p>Change Password</p></a></li></ul></li>';
        menuBar.append(navrows);
        //-----------------end---------------------

        //------------Add Action Menu--------------
        navrows =null;
        navrows =  '<li class ="nav-item"><a href="#" class="nav-link" id="mnu_Action"><i class="nav-icon fas fa-edit"></i><p>Action<i class="fas fa-angle-left right"></i></p></a><ul class="nav nav-treeview">';
        navrows += '<li class="nav-item" id="li_Inbox"><a href="/Action/Inbox" class="nav-link"> <i class="far fa-circle nav-icon"></i><p>Inbox</p></a></li>';
        navrows += '<li class="nav-item" id="li_outbox"><a href="/Action/Outbox" class="nav-link"> <i class="far fa-circle nav-icon"></i><p>Outbox</p></a></li></ul></li>';
        menuBar.append(navrows);
        //-------------end-------------------------

        //-----------Add Report Menu---------------
         navrows =null;
         navrows =  '<li class ="nav-item"><a href="#" class="nav-link" id="mnu_Report"><i class="nav-icon fas fa-file"></i><p>Report<i class="fas fa-angle-left right"></i></p></a><ul class="nav nav-treeview">';
         navrows += '<li class="nav-item" id="li_pendingMIV"><a href="/Report/PendingDetail" class="nav-link"> <i class="far fa-circle nav-icon"></i><p>Pending MIV</p></a></li>';
         navrows += '<li class="nav-item" id="li_MIVDetail"><a href="/Report/ReportMIVDetail" class="nav-link"><i class="far fa-circle nav-icon"></i><p>MIV Detail</p></a></li>';
         navrows += '<li class="nav-item" id="li_Cons_costcentreviz"><a href="/Report/ReportConsCos" class="nav-link"> <i class="far fa-circle nav-icon"></i><p>Consumption/Cost Centre viz</p></a></li>';
         navrows += '<li class="nav-item" id="li_checkMIV"><a href="/Report/CHECKMIV" class="nav-link"><i class="far fa-circle nav-icon"></i><p>Check MIV</p></a></li></ul></li>';
         menuBar.append(navrows);
        //----------------end----------------------


        //------------Add Help Menu----------------
//        navrows =null;
//        navrows ='<li class ="nav-item"><a href="#" class="nav-link" id="mnu_Help"><i class="nav-icon fas fa-question-circle"></i><p>Help<i class="fas fa-angle-left right"></i></p></a></li>';
//         menuBar.append(navrows);
        //----------------end----------------------

        //------------Add Logout Menu----------------
        navrows =null;
        navrows ='<li class ="nav-item"><a href="#" class="nav-link" onclick="ClickLogout();"><i class="nav-icon fas fa-question-circle"></i><p>Log Out<i class="fas fa-angle-left right"></i></p></a></li>';
         menuBar.append(navrows);
        //----------------end----------------------
    }
}


function Set_Welcome_Message(usercd) {
   return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/Set_Welcome_Message",
             data: "{'usercd' : '" + usercd + "' }",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                resolve(mData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}



async function SetMenu() {
    var adminMenu = $("#mnu_Admin");
    var mainMenu = $("#mnu_Main");
    var actionMenu = $("#mnu_Action");
    var reportMenu = $("#mnu_Report");
//    var usercd= await  getSessionVariables();
    var usercd= $("#hdfUserName").val();
    if (usercd.length ==0)
    {
        $("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
        toastr.error("Session Expired", {timeOut: 200});
        setTimeout(window.location.href = "/Login/Login", 10000);
        return;
    }
    if(usercd.length > 0)
    {
        if(usercd.toUpperCase() != "H21083") 
        {
            adminMenu.hide();
        }
    }
}


async function ClickLogout()
{
var res= await clearSession();
if(res != "OK")
{
    
}
 setTimeout(window.location.href= String.format("{0}/Login/Login",window.location.origin),10000);
}

function clearSession() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/clearSession",
            data: "{}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}


function Save_UsrLogDtl(com) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/Save_UsrLogDtl",
            data: JSON.stringify({p: com}),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                resolve(mData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}


 function getConsumptionCentre() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/getConsumptionCentre",
            data: "{}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                resolve(mData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}

function getCostCentre() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/getCostCentre",
            data: "{}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                resolve(mData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}

function getEmployeeDetail(empcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/getEmployeeDetail",
            data: "{'varempcd' : '" +  empcd + "'}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                resolve(mData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}

function getDepartment() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/getDepartment",
            data: "{}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                resolve(mData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}

function Save_UsrLogDtl(com) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/Save_UsrLogDtl",
            data: JSON.stringify({p: com}),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                resolve(mData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}


function getAllUsers() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/getAllUsers",
            data: "{}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                resolve(mData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}

