var table;
Timer();

$(document).ready(function () {
    changeDate();
     ChangeBreadCrumb("Administrator", "New User Entry Screen", "Administrator"); 
      $("#issueBody").addClass("sidebar-collapse");
    userDetail();
});

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
    $("#txtDate").val(ChangeDateFormat(dt));
    $("#txtFroDat").val(ChangeDateFormat(dt));
    $("#txtToDat").val(ChangeDateFormat(dt));
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

function validateFloatKeyPress(el, evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    var number = el.value.split('.');
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    //just one dot
    if (number.length > 1 && charCode == 46) {
        return false;
    }
    //get the carat position
    var caratPos = getSelectionStart(el);
    var dotPos = el.value.indexOf(".");
    if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) {
        return false;
    }
    return true;
}

function getSelectionStart(o) {
    if (o.createTextRange) {
        var r = document.selection.createRange().duplicate()
        r.moveEnd('character', o.value.length)
        if (r.text == '') return o.value.length
        return o.value.lastIndexOf(r.text)
    }
    else return o.selectionStart
}


 // App variable to show the confirm response
function getQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) { return pair[1]; }
    }
    return (false);
}


function getID_Detail(emp_cd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Administrator/getID_Detail",
            data: "{'emp_cd' : '" +  emp_cd + "'}",
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




async  function userDetail()
{
    var ErrMsg=null; var res=null; var userList=null; var allUsers=null;
    try {
        $(".loader").fadeIn();
        var txtindempnm = $("input[id*=txtindempnm]");
        var hdfinddep = $("[id*=hdfinddep]");
        var hdfdepcd = $("[id*=hdfdepcd]");
        var txtindepcd = $("input[id*=txtindepcd]");
        var drpindempcd = $("select[id*=drpindempcd] option:Selected");
        var drpapr = $("select[id*=drpapr] option:Selected");
        var drpTPI = $("select[id*=drpTPI] option:Selected");
        var drpSta = $("select[id*=drpSta] option:Selected");
        var btnSave= $("[id*=btnsave]");
        var btnCheck= $("[id*=btncheck]");
         var usercd= $("#hdfUserName").val();
	    if (usercd.length ==0)
	    {
		    $("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		    toastr.error("Session Expired", {timeOut: 200});
		    setTimeout(window.location.href = "/Login/Login", 10000);
		    return;
	    }
        else if(usercd.length >0)
        {
            $("#hdfempcd").val(usercd.toString().trim());
            var res =  await getEmployeeDetail(usercd.toString().trim());
            if (res.response ==-1) {
                ErrMsg =(res.responseMsg);
                throw ErrMsg;
            }
            var objempprp= res.responseObject;
            $("#hdfempcd").val($("#hdfempcd").val().toString().trim());
            $("#hdfempnam").val(objempprp.emp_nm.toString().trim());
            $("#hdfdept").val(objempprp.dept_nm.toString().trim());
            $("#hdfdesig").val(objempprp.desig_nm.toString().trim()); 
            $("#txtempcd").val($("#hdfempcd").val());
            $("#txtempnm").val(objempprp.emp_nm.toString().trim());

            //-------Populate Select Employee DropdownList-----//
            res=null;
            res = await getEmployeeNames();
            if (res.response == -1) 
            {
                ErrMsg =(res.responseMsg);
                throw ErrMsg;
            }
            userList=null; userList =res.responseObjectList;
            allUsers =null; allUsers ='<option value="0">--Select--</option>';
            $.each(userList,function(){
                allUsers += '<option value="'+this["emp_cd"]+'">'+this["emp_nm"]+' </option>';
            });
            $("[id*=drpindempcd]").empty();
            $("[id*=drpindempcd]").append(allUsers);
             //----------------end-------------------------------//

            //-------Populate Select Employee and TPI DropdownList-----//
            res=null;
            res = await getAllUsers();
            if (res.response == -1) 
            {
                ErrMsg =(res.responseMsg);
                throw ErrMsg;
            }
            userList=null; userList =res.responseObjectList;
            allUsers =null; allUsers ='<option value="0">--Select--</option>';
            $.each(userList,function(){
                allUsers += '<option value="'+this["emp_cd"]+'">'+this["emp_nm"]+' </option>';
            });
            $("[id*=drpapr]").empty();
            $("[id*=drpapr]").append(allUsers);
            $("[id*=drpTPI]").empty();
            $("[id*=drpTPI]").append(allUsers);
             //----------------end-------------------------------//
             var mytag = (isEmpty(getQueryVariable("mytag"))) ? -1 :  parseInt(getQueryVariable("mytag").toString());
             var empcd = (isEmpty(getQueryVariable("empcd"))) ? "" : getQueryVariable("empcd").toString();
            if ( mytag != -1 &&  mytag == 20 ) 
            {
                var result = await getID_Detail(empcd);
                if (result.response == -1) 
                {
                    ErrMsg = result.responseMsg;
                    throw ErrMsg;
                }
                var ObjPrphry = result.responseObjectList[0];
                txtindempnm.val(ObjPrphry.emp_nm);
                txtindepcd.val(ObjPrphry.emp_cd);
                hdfinddep.val(ObjPrphry.dept_nm);
                $("select[id*=drpindempcd]").val(empcd.toString().trim());
                $("select[id*=drpapr]").val(ObjPrphry.rpt.toString().trim());
                $("select[id*=drpTPI]").val(ObjPrphry.tpiid.toString().trim());
                $("select[id*=drpSta]").val(ObjPrphry.tag.toString().trim());

//                btnSave.show();
                btnSave.text("Update");             
            }        
        }
    } 
    catch (err) 
    {
      $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
    }
    finally
    {
     $(".loader").fadeOut();
    }
 }

  function getCheckID(emp_cd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Administrator/getCheckID",
            data: "{'emp_cd' : '" + emp_cd + "'}",
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


 function getEmployeeNames() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Administrator/getEmployeeNames",
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


function getIndentory_indropdown() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Administrator/getIndentory_indropdown",
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

function getEmployee_Name(emp_cd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Administrator/getEmployee_Name",
            data: "{'emp_cd' : '" + emp_cd + "'}",
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


function check_validation() {
    return new Promise(function (resolve, reject) {
        var drpindempcd = $("select[id*=drpindempcd] option:Selected");
        var drpapr = $("select[id*=drpapr] option:Selected");
        var drpTPI = $("select[id*=drpTPI] option:Selected");
        var drpSta = $("select[id*=drpSta] option:Selected");

        if (drpindempcd.val() == "0" ) 
        {
            reject("Select Employee for ID");
        }
        else if (drpapr.val() == "0" ) 
        {
           reject("Select Approver Authority");
        }
        else if (drpTPI.val() == "0" ) 
        {
           reject("Select TPI");
        }
        else if (drpSta.val() == "0" ) 
        {
           reject("Select Status");
        }
        else 
        {
           resolve("Record is Validated.");
        }
    });
}

function Save_HRY(com) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Administrator/Save_HRY",
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

function Update_HRY(com) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Administrator/Update_HRY",
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




///////////////Start BUtton click Events////////////////////////
function btnexit_click()
{
    var strUrl = '/Home/Home';
    setTimeout(window.location.href = strUrl, 10000);
}

async function btnCheck_click()
{    
    $(".loader").fadeIn();
    var btncheck =$("[id*=btncheck]");
    check_validation().then(function(result)
    {
        toastr.success( result, {timeOut: 1000});
//        btncheck.Attr("disabled","disabled");
        $(".loader").fadeOut();  
    }).catch(function(error)
    {
//        $("[id*=lblMessage]").text(error); 
//        $("[id*=lblMessage]").css('color', '#ff0000'); // Red color
        toastr.error( error, {timeOut: 1000});
        $(".loader").fadeOut();  
    });


}


async function btnSave_click()
{
    var ErrMsg;
	var usercd= $("#hdfUserName").val();
	if (usercd.length ==0)
	{
		$("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		toastr.error("Session Expired", {timeOut: 200});
		setTimeout(window.location.href = "/Login/Login", 10000);
		return;
	}

    try 
    {
        $(".loader").fadeIn();
        var drpindempcd = $("select[id*=drpindempcd] option:Selected");
        var drpapr = $("select[id*=drpapr] option:Selected");
        var drpTPI = $("select[id*=drpTPI] option:Selected");
        var drpSta = $("select[id*=drpSta] option:Selected");
        var btnSave= $("[id*=btnsave]");
        var btnCheck= $("[id*=btncheck]");
        var ObjPrphry= new Object();
        ObjPrphry.emp_cd = drpindempcd.val().trim();
        ObjPrphry.rpt = drpapr.val().trim();
        ObjPrphry.tpi = drpTPI.val().trim();
        ObjPrphry.tag = drpSta.val().trim();
        if (btnSave.text() == "Save") 
        {
            var res = await Save_HRY(ObjPrphry);
            if (res.response == -1) 
            {
                ErrMsg =(res.responseMsg);
                throw ErrMsg;
            }
            toastr.success( "Login Id For Issue Voucher is created Sucessfully.", {timeOut: 500});
            $(".loader").fadeOut();  
            btnCheck.prop("disabled",true);
            btnSave.prop("disabled",true);
        }
        else if (btnSave.text() == "Update") 
        {
            var res = await Update_HRY(ObjPrphry);
            if (res.response == -1) 
            {
                ErrMsg =(res.responseMsg);
                throw ErrMsg;
            }
            toastr.success( "Issue Voucher Id  is updated Sucessfully.", {timeOut: 500});
            $(".loader").fadeOut();  
            btnCheck.prop("disabled",true);
            btnSave.prop("disabled",true);
            btnSave.val("Update");   
        }    
    } 
    catch (err) 
    {
        toastr.error("Validation", err, {timeOut: 500});
        $(".loader").fadeOut();    
    }
    finally
    {
       $(".loader").fadeOut();    
    }






}

async function drpindempcd_IndexChanged()
{
	var usercd= $("#hdfUserName").val();
	if (usercd.length ==0)
	{
		$("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		toastr.error("Session Expired", {timeOut: 200});
		setTimeout(window.location.href = "/Login/Login", 10000);
		return;
	}
    var ErrMsg=null;
    var drpindempcd = $("select[id*=drpindempcd] option:Selected");
    var txtindempnm = $("input[id*=txtindempnm]");
    var hdfinddep = $("[id*=hdfinddep]");
    var hdfdepcd = $("[id*=hdfdepcd]");
    var txtindepcd = $("input[id*=txtindepcd]");
    try 
    {
        var res= await getCheckID(drpindempcd.val());
        if (res.response == -1) 
        {
            ErrMsg =res.responseMsg;
            throw ErrMsg;
        }
        var m = parseInt(res.CheckID);
        if (m >0) 
        {
             ErrMsg ="Id is already Exist.";
             throw ErrMsg;    
        }
        else 
        {
            $("[id*=lblMessage]").text("");
            var res1= await getEmployee_Name(drpindempcd.val());
            if (res1.response == -1) 
            {
                ErrMsg =res1.responseMsg;
                throw ErrMsg;
            }
            var objempprp= res1.responseObject;
            txtindempnm.val(objempprp.emp_nm1);
            hdfinddep.val(objempprp.dept_nm);
            hdfdepcd.val( objempprp.dept_cd);
            txtindepcd.val(objempprp.dept_nm);
        }
    
    } 
    catch (err) 
    {
//       $("[id*=lblMessage]").text(err); 
        toastr.error("Validation", err, {timeOut: 1000});
        txtindempnm.val("");
        hdfinddep.val("");
        hdfdepcd.val("");
        txtindepcd.val("");
    }
}


///////////////End BUtton click Events////////////////////////